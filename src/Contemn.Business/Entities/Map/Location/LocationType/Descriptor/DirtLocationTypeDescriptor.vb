Imports TGGD.Business

Friend Class DirtLocationTypeDescriptor
    Inherits LocationTypeDescriptor

    Public Sub New()
        MyBase.New(NameOf(DirtLocationTypeDescriptor), "Dirt")
    End Sub

    Friend Overrides Sub OnInitialize(location As Location)
    End Sub

    Friend Overrides Sub OnProcessTurn(location As Location)
        Throw New NotImplementedException()
    End Sub

    Friend Overrides Function CanSpawn(location As ILocation, itemType As String) As Boolean
        Return True
    End Function
End Class
