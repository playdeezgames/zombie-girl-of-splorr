Imports TGGD.Business

Friend MustInherit Class CharacterTypeDescriptor
    ReadOnly Property CharacterType As String
    ReadOnly Property CharacterCount As Integer
    Sub New(characterType As String, characterCount As Integer)
        Me.CharacterType = characterType
        Me.CharacterCount = characterCount
    End Sub
    Friend MustOverride Function CanSpawnLocation(location As ILocation) As Boolean
    Friend MustOverride Sub OnInitialize(character As ICharacter)
    Friend MustOverride Sub HandleAddItem(character As ICharacter, item As IItem)
    Friend MustOverride Sub HandleRemoveItem(character As ICharacter, item As IItem)
    Friend MustOverride Function OnInteract(target As ICharacter, initiator As ICharacter) As IDialog
    Friend MustOverride Function OnProcessTurn(character As ICharacter) As IEnumerable(Of IDialogLine)
    Friend MustOverride Function GetName(character As Character) As String
    Friend Overridable Function Describe(character As Character) As IEnumerable(Of IDialogLine)
        Return Array.Empty(Of IDialogLine).
            AppendIf(character.GetTag(TagType.IsZombie), New DialogLine(MoodType.Info, "Is a zombie!")).
            AppendIf(character.GetTag(TagType.HasTastyBrains), New DialogLine(MoodType.Info, "Has tasty brains!"))
    End Function
End Class
