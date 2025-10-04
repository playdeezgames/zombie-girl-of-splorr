Imports TGGD.Business

Friend Class ZombieGirlFactionTypeDescriptor
    Inherits FactionTypeDescriptor

    Public Sub New()
        MyBase.New(NameOf(ZombieGirlFactionTypeDescriptor), 1)
    End Sub

    Friend Overrides Function GetName(faction As Faction) As String
        Return "Zombie Girls"
    End Function

    Friend Overrides Function Describe(faction As Faction) As IEnumerable(Of IDialogLine)
        Return {}
    End Function
End Class
