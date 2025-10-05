Imports TGGD.Business

Friend MustInherit Class LocationTypeDescriptor
    Friend ReadOnly Property LocationType As String
    Friend ReadOnly Property LocationTypeName As String
    Sub New(locationType As String, locationTypeName As String)
        Me.LocationType = locationType
        Me.LocationTypeName = locationTypeName
    End Sub
    Friend MustOverride Sub OnInitialize(location As ILocation)
    Friend Overridable Function GetName(location As ILocation) As String
        Return LocationTypeName
    End Function
    Friend MustOverride Sub OnProcessTurn(location As ILocation)

    Friend MustOverride Function Describe(location As ILocation) As IEnumerable(Of IDialogLine)
End Class
