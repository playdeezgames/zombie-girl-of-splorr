Imports TGGD.Business

Friend MustInherit Class BaseMapTypeDescriptor
    Inherits MapTypeDescriptor

    Private ReadOnly terrainGenerator As IReadOnlyDictionary(Of String, Integer)

    Public Sub New(mapType As String, mapCount As Integer, terrainGenerator As IReadOnlyDictionary(Of String, Integer))
        MyBase.New(mapType, mapCount)
        Me.terrainGenerator = terrainGenerator
    End Sub

    Friend Overrides Sub OnInitialize(map As IMap)
        map.Columns = ROOM_COLUMNS
        map.Rows = ROOM_ROWS
        For Each column In Enumerable.Range(0, map.Columns)
            For Each row In Enumerable.Range(0, map.Rows)
                Dim locationType = RNG.FromGenerator(terrainGenerator)
                map.World.CreateLocation(locationType, map, column, row)
            Next
        Next
    End Sub
End Class
