Imports TGGD.Business

Friend Class DirtLocationTypeDescriptor
    Inherits LocationTypeDescriptor

    Public Sub New()
        MyBase.New(NameOf(DirtLocationTypeDescriptor), "Dirt")
    End Sub

    Friend Overrides Sub OnLeave(location As ILocation, character As ICharacter)
    End Sub

    Friend Overrides Sub OnInitialize(location As Location)
    End Sub

    Friend Overrides Sub OnProcessTurn(location As Location)
        Throw New NotImplementedException()
    End Sub

    Friend Overrides Function OnBump(location As ILocation, character As ICharacter) As IDialog
        Throw New NotImplementedException()
    End Function

    Friend Overrides Function OnEnter(location As ILocation, character As ICharacter) As IDialog
        Return Nothing
    End Function

    Friend Overrides Function CanEnter(location As ILocation, character As ICharacter) As Boolean
        Return True
    End Function

    Friend Overrides Function CanSpawn(location As ILocation, itemType As String) As Boolean
        Return True
    End Function
End Class
