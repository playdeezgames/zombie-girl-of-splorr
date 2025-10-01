Public Interface IMap
    Inherits IEntity
    ReadOnly Property MapId As Integer
    ReadOnly Property MapType As String
    Property Columns As Integer
    Property Rows As Integer
    Sub SetLocation(column As Integer, row As Integer, location As ILocation)
    Function GetLocation(column As Integer, row As Integer) As ILocation
    ReadOnly Property Locations As IEnumerable(Of ILocation)
End Interface
