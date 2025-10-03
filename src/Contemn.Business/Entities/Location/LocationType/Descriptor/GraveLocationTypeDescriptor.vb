Friend Class GraveLocationTypeDescriptor
    Inherits LocationTypeDescriptor

    Public Sub New()
        MyBase.New(NameOf(GraveLocationTypeDescriptor), "Grave")
    End Sub

    Friend Overrides Sub OnInitialize(location As Location)
    End Sub

    Friend Overrides Sub OnProcessTurn(location As Location)
        Throw New NotImplementedException()
    End Sub
End Class
