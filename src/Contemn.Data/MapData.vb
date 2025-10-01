Public Class MapData
    Inherits EntityData
    Public Property MapType As String
    Public Property Columns As Integer
    Public Property Rows As Integer
    Public Property Locations As New Dictionary(Of Integer, Dictionary(Of Integer, Integer))
End Class
