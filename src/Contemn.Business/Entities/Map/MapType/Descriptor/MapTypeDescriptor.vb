Friend MustInherit Class MapTypeDescriptor
    ReadOnly Property MapType As String
    ReadOnly Property MapCount As Integer
    Sub New(mapType As String, mapCount As Integer)
        Me.MapType = mapType
        Me.MapCount = mapCount
    End Sub
    Friend MustOverride Sub OnInitialize(map As IMap)
End Class
