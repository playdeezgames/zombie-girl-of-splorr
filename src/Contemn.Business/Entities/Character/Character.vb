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
            Return World.GetFaction(EntityData.FactionId)
        End Get
        Set(value As IFaction)
            Faction.RemoveCharacter(Me)
            EntityData.FactionId = value.FactionId
            Faction.AddCharacter(Me)
        End Set
    End Property

    Public ReadOnly Property Name As String Implements ICharacter.Name
        Get
            Return CharacterType.ToCharacterTypeDescriptor.GetName(Me)
        End Get
    End Property

    Public Overrides ReadOnly Property Description As IEnumerable(Of IDialogLine)
        Get
            Return CharacterType.ToCharacterTypeDescriptor.Describe(Me)
        End Get
    End Property

    Public ReadOnly Property OtherCharactersInLocation As IEnumerable(Of ICharacter) Implements ICharacter.OtherCharactersInLocation
        Get
            Return Location.Characters.Where(Function(x) x.CharacterId <> CharacterId)
        End Get
    End Property

    Public ReadOnly Property HasOtherCharactersInLocation As Boolean Implements ICharacter.HasOtherCharactersInLocation
        Get
            Return OtherCharactersInLocationCount > 0
        End Get
    End Property

    Public ReadOnly Property OtherCharactersInLocationCount As Integer Implements ICharacter.OtherCharactersInLocationCount
        Get
            Return Location.CharacterCount - 1
        End Get
    End Property

    Private Function CanPerform(verbType As String) As Boolean
        Return verbType.ToVerbTypeDescriptor.CanChoose(Me)
    End Function

    Public Overrides Sub Initialize()
        MyBase.Initialize()
        Data.Locations(EntityData.LocationId).CharacterIds.Add(CharacterId)
        CharacterType.ToCharacterTypeDescriptor().OnInitialize(Me)
    End Sub

    Public Function Perform(verbType As String) As IDialog Implements ICharacter.Perform
        Return verbType.ToVerbTypeDescriptor.Perform(Me)
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
End Class
