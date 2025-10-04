Imports TGGD.Business

Friend Class CuteBoyCharacterTypeDescriptor
    Inherits CharacterTypeDescriptor

    Public Sub New()
        MyBase.New(NameOf(CuteBoyCharacterTypeDescriptor), 1)
    End Sub

    Friend Overrides Sub OnInitialize(character As ICharacter)
        character.SetMetadata(MetadataType.Name, "Ryu Shigeru")
    End Sub

    Friend Overrides Sub HandleAddItem(character As ICharacter, item As IItem)
    End Sub

    Friend Overrides Sub HandleRemoveItem(character As ICharacter, item As IItem)
    End Sub

    Friend Overrides Function CanSpawnLocation(location As ILocation) As Boolean
        Return True
    End Function

    Friend Overrides Function OnInteract(target As ICharacter, initiator As ICharacter) As IDialog
        Return Nothing
    End Function

    Friend Overrides Function OnProcessTurn(character As ICharacter) As IEnumerable(Of IDialogLine)
        Return Array.Empty(Of IDialogLine)
    End Function

    Friend Overrides Function GetName(character As Character) As String
        Return character.GetMetadata(MetadataType.Name)
    End Function

    Friend Overrides Function Describe(character As Character) As IEnumerable(Of IDialogLine)
        Return Array.Empty(Of IDialogLine)
    End Function
End Class
