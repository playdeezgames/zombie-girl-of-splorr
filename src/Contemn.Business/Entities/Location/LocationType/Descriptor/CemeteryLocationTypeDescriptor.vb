Imports TGGD.Business

Friend Class CemeteryLocationTypeDescriptor
    Inherits LocationTypeDescriptor

    Public Sub New()
        MyBase.New(NameOf(CemeteryLocationTypeDescriptor), "Cemetery")
    End Sub

    Friend Overrides Sub OnInitialize(location As ILocation)
    End Sub

    Friend Overrides Sub OnProcessTurn(location As ILocation)
        Throw New NotImplementedException()
    End Sub

    Friend Overrides Function Describe(location As ILocation) As IEnumerable(Of IDialogLine)
        Return {}
    End Function
End Class
