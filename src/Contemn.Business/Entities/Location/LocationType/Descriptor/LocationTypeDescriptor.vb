Imports TGGD.Business

Friend MustInherit Class LocationTypeDescriptor
    Friend ReadOnly Property LocationType As String
    Friend ReadOnly Property LocationTypeName As String
    Sub New(locationType As String, locationTypeName As String)
        Me.LocationType = locationType
        Me.LocationTypeName = locationTypeName
    End Sub
    Friend MustOverride Sub OnInitialize(location As Location)
    Friend Overridable Function GetName(location As Location) As String
        Return LocationTypeName
    End Function
    Friend MustOverride Sub OnProcessTurn(location As Location)
End Class
