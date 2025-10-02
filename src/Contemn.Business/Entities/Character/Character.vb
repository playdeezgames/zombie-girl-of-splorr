Imports TGGD.Business
Imports Contemn.Data

Friend Class Character
    Inherits InventoryEntity(Of CharacterData)
    Implements ICharacter

    Public Sub New(data As WorldData, characterId As Integer, playSfx As Action(Of String))
        MyBase.New(data, playSfx)
        Me.CharacterId = characterId
    End Sub

    Public ReadOnly Property CharacterType As String Implements ICharacter.CharacterType
        Get
            Return EntityData.CharacterType
        End Get
    End Property

    Public ReadOnly Property CharacterId As Integer Implements ICharacter.CharacterId

    Public ReadOnly Property Location As ILocation Implements ICharacter.Location
        Get
            Return New Location(Data, EntityData.LocationId, AddressOf PlaySfx)
        End Get
    End Property

    Public ReadOnly Property Map As IMap Implements ICharacter.Map
        Get
            Return Location.Map
        End Get
    End Property

    Public ReadOnly Property Column As Integer Implements ICharacter.Column
        Get
            Return Location.Column
        End Get
    End Property

    Public ReadOnly Property Row As Integer Implements ICharacter.Row
        Get
            Return Location.Row
        End Get
    End Property

    Protected Overrides ReadOnly Property EntityData As CharacterData
        Get
            Return Data.Characters(CharacterId)
        End Get
    End Property

    Public ReadOnly Property AvailableVerbs As IEnumerable(Of String) Implements ICharacter.AvailableVerbs
        Get
            Return VerbTypes.All.Where(Function(x) CanPerform(x))
        End Get
    End Property

    Public Property Faction As IFaction Implements ICharacter.Faction
        Get
            Dim factionId As Integer? = TryGetStatistic(StatisticType.FactionId)
            If factionId.HasValue Then
                Return New Faction(Data, factionId.Value, AddressOf PlaySfx)
            End If
            Return Nothing
        End Get
        Set(value As IFaction)
            If value IsNot Nothing Then
                SetStatistic(StatisticType.FactionId, value.FactionId)
            Else
                SetStatistic(StatisticType.FactionId, Nothing)
            End If
        End Set
    End Property

    Private Function CanPerform(verbType As String) As Boolean
        Return verbType.ToVerbTypeDescriptor.CanChoose(Me)
    End Function

    Public Overrides Sub Initialize()
        MyBase.Initialize()
        Data.Locations(EntityData.LocationId).CharacterId = CharacterId
        CharacterType.ToCharacterTypeDescriptor().OnInitialize(Me)
    End Sub

    Public Function Perform(verbType As String) As IDialog Implements ICharacter.Perform
        Return verbType.ToVerbTypeDescriptor.Perform(Me)
    End Function

    Public Function MoveTo(destination As ILocation) As IDialog Implements ICharacter.MoveTo
        If destination Is Nothing Then
            Leave()
            Return Nothing
        End If
        If CanEnter(destination) Then
            Return Enter(destination)
        End If
        Return Bump(destination)
    End Function

    Private Function Bump(nextLocation As ILocation) As IDialog
        Return HandleBump(nextLocation)
    End Function

    Private Function HandleBump(nextLocation As ILocation) As IDialog
        SetBumpLocation(nextLocation)
        Return nextLocation.LocationType.ToLocationTypeDescriptor.OnBump(nextLocation, Me)
    End Function

    Private Function Enter(nextLocation As ILocation) As IDialog
        Leave()
        EntityData.LocationId = nextLocation.LocationId
        Data.Locations(EntityData.LocationId).CharacterId = CharacterId
        Me.HandleEnter(Location)
        Return Location.HandleEnter(Me)
    End Function

    Private Sub Leave()
        SetBumpLocation(Nothing)
        Me.HandleLeave(Location)
        Location.HandleLeave(Me)
        Data.Locations(EntityData.LocationId).CharacterId = Nothing
    End Sub

    Private Function CanEnter(nextLocation As ILocation) As Boolean
        Return Not nextLocation.HasCharacter AndAlso nextLocation.LocationType.ToLocationTypeDescriptor.CanEnter(nextLocation, Me)
    End Function

    Public Overrides Sub Recycle()
        Clear()
        Data.RecycledCharacters.Add(CharacterId)
    End Sub

    Protected Overrides Sub HandleAddItem(item As IItem)
        CharacterType.ToCharacterTypeDescriptor.HandleAddItem(Me, item)
    End Sub

    Protected Overrides Sub HandleRemoveItem(item As IItem)
        CharacterType.ToCharacterTypeDescriptor.HandleRemoveItem(Me, item)
    End Sub

    Public Function Interact(initiator As ICharacter) As IDialog Implements ICharacter.Interact
        Return CharacterType.ToCharacterTypeDescriptor.OnInteract(Me, initiator)
    End Function

    Public Function AvailableVerbsOfCategory(verbCategoryType As String) As IEnumerable(Of String) Implements ICharacter.AvailableVerbsOfCategory
        Dim candidates = VerbTypes.AllOfCategory(verbCategoryType).ToList
        Return candidates.Where(Function(x) CanPerform(x))
    End Function

    Public Function ProcessTurn() As IEnumerable(Of IDialogLine) Implements ICharacter.ProcessTurn
        Return CharacterType.ToCharacterTypeDescriptor.OnProcessTurn(Me)
    End Function

    Public Overrides Sub Clear()
        MyBase.Clear()
        EntityData.LocationId = 0
        EntityData.CharacterType = Nothing
    End Sub

    Public Function Navigate() As IDialog Implements ICharacter.Navigate
        Return CharacterType.ToCharacterTypeDescriptor.OnNavigate(Me)
    End Function
End Class
