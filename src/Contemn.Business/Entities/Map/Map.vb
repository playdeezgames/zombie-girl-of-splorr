Imports Contemn.Data

Friend Class Map
    Inherits Entity(Of MapData)
    Implements IMap
    Public Sub New(data As WorldData, mapId As Integer, playSfx As Action(Of String))
        MyBase.New(data, playSfx)
        Me.MapId = mapId
    End Sub
    Public ReadOnly Property MapId As Integer Implements IMap.MapId
    Public ReadOnly Property MapType As String Implements IMap.MapType
        Get
            Return EntityData.MapType
        End Get
    End Property
    Public Property Columns As Integer Implements IMap.Columns
        Get
            Return EntityData.Columns
        End Get
        Set(value As Integer)
            EntityData.Columns = Math.Max(0, value)
        End Set
    End Property
    Public Property Rows As Integer Implements IMap.Rows
        Get
            Return EntityData.Rows
        End Get
        Set(value As Integer)
            EntityData.Rows = Math.Max(0, value)
        End Set
    End Property
    Public ReadOnly Property Locations As IEnumerable(Of ILocation) Implements IMap.Locations
        Get
            Return EntityData.
                Locations.
                Aggregate(
                    Array.Empty(Of Integer).AsEnumerable,
                    Function(x, y) Enumerable.Concat(x, y.Value.Values)).
                Select(Function(x) New Location(Data, x, AddressOf PlaySfx))
        End Get
    End Property
    Protected Overrides ReadOnly Property EntityData As MapData
        Get
            Return Data.Maps(MapId)
        End Get
    End Property
    Public Overrides Sub Initialize()
        MyBase.Initialize()
        MapType.ToMapTypeDescriptor.OnInitialize(Me)
    End Sub
    Public Sub SetLocation(column As Integer, row As Integer, location As ILocation) Implements IMap.SetLocation
        Dim mapColumn As Dictionary(Of Integer, Integer) = Nothing
        If location IsNot Nothing Then
            If Not EntityData.Locations.TryGetValue(column, mapColumn) Then
                mapColumn = New Dictionary(Of Integer, Integer)
                EntityData.Locations.Add(column, mapColumn)
            End If
            mapColumn(row) = location.LocationId
        Else
            If EntityData.Locations.TryGetValue(column, mapColumn) Then
                mapColumn.Remove(row)
            End If
        End If
    End Sub

    Public Overrides Sub Recycle()
        Clear()
        Data.RecycledMaps.Add(MapId)
    End Sub

    Public Function GetLocation(column As Integer, row As Integer) As ILocation Implements IMap.GetLocation
        Dim mapColumn As Dictionary(Of Integer, Integer) = Nothing
        If EntityData.Locations.TryGetValue(column, mapColumn) Then
            Dim locationId As Integer = 0
            If mapColumn.TryGetValue(row, locationId) Then
                Return New Location(Data, locationId, AddressOf PlaySfx)
            End If
        End If
        Return Nothing
    End Function
    Public Overrides Sub Clear()
        MyBase.Clear()
        EntityData.MapType = Nothing
        EntityData.Columns = 0
        EntityData.Rows = 0
        EntityData.Locations.Clear()
    End Sub
End Class
