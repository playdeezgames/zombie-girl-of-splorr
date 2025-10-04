Imports Contemn.Data

Friend Class Location
    Inherits InventoryEntity(Of LocationData)
    Implements ILocation

    Public Sub New(data As WorldData, locationId As Integer, playSfx As Action(Of String))
        MyBase.New(data, playSfx)
        Me.LocationId = locationId
    End Sub

    Public ReadOnly Property LocationId As Integer Implements ILocation.LocationId

    Public Overrides Sub Initialize()
        MyBase.Initialize()
        LocationType.ToLocationTypeDescriptor.OnInitialize(Me)
    End Sub

    Public Property LocationType As String Implements ILocation.LocationType
        Get
            Return EntityData.LocationType
        End Get
        Set(value As String)
            If value <> EntityData.LocationType Then
                World.DeactivateLocation(Me)
                EntityData.Statistics.Clear()
                EntityData.StatisticMinimums.Clear()
                EntityData.StatisticMaximums.Clear()
                EntityData.Metadatas.Clear()
                EntityData.Tags.Clear()
                EntityData.LocationType = value
                Initialize()
            End If
        End Set
    End Property

    Public Overrides Sub Clear()
        MyBase.Clear()
        EntityData.LocationType = Nothing
        EntityData.CharacterIds.Clear()
        World.DeactivateLocation(Me)
    End Sub

    Public ReadOnly Property HasCharacters As Boolean Implements ILocation.HasCharacters
        Get
            Return EntityData.CharacterIds.Any
        End Get
    End Property

    Protected Overrides ReadOnly Property EntityData As LocationData
        Get
            Return Data.Locations(LocationId)
        End Get
    End Property

    Public ReadOnly Property Name As String Implements ILocation.Name
        Get
            Return LocationType.ToLocationTypeDescriptor.GetName(Me)
        End Get
    End Property

    Public ReadOnly Property CharacterCount As Integer Implements ILocation.CharacterCount
        Get
            Return EntityData.CharacterIds.Count
        End Get
    End Property

    Public ReadOnly Property Characters As IEnumerable(Of ICharacter) Implements ILocation.Characters
        Get
            Return EntityData.CharacterIds.Select(Function(x) World.GetCharacter(x))
        End Get
    End Property

    Public Overrides Sub Recycle()
        Clear()
        Data.RecycledLocations.Add(LocationId)
    End Sub

    Protected Overrides Sub HandleAddItem(item As IItem)
    End Sub

    Protected Overrides Sub HandleRemoveItem(item As IItem)
    End Sub

    Public Sub ProcessTurn() Implements ILocation.ProcessTurn
        LocationType.ToLocationTypeDescriptor.OnProcessTurn(Me)
    End Sub
End Class
