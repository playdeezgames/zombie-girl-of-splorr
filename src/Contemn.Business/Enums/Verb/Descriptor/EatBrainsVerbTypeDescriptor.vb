Imports TGGD.Business

Friend Class EatBrainsVerbTypeDescriptor
    Inherits VerbTypeDescriptor

    Public Sub New()
        MyBase.New(NameOf(EatBrainsVerbTypeDescriptor), Business.VerbCategoryType.Action, "Eat Brains...")
    End Sub

    Public Overrides Function Perform(character As ICharacter) As IDialog
        Return New EatBrainsDialog(character)
    End Function

    Public Overrides Function CanPerform(character As ICharacter) As Boolean
        Return MyBase.CanPerform(character) AndAlso
            character.GetTag(TagType.IsZombie) AndAlso
            character.OtherCharactersInLocation.Any(Function(x) x.GetTag(TagType.HasTastyBrains))
    End Function
End Class
