Imports TGGD.Business

Friend Class OtherCharactersDialog
    Inherits BaseDialog

    Private ReadOnly character As ICharacter

    Public Sub New(character As ICharacter)
        MyBase.New(
            GenerateCaption(character),
            GenerateChoices(character),
            GenerateLines(character))
        Me.character = character
    End Sub

    Private Shared Function GenerateLines(character As ICharacter) As IEnumerable(Of IDialogLine)
        Return Array.Empty(Of IDialogLine)
    End Function

    Private Shared Function GenerateChoices(character As ICharacter) As IEnumerable(Of IDialogChoice)
        Return {
            New DialogChoice(NEVER_MIND_CHOICE, NEVER_MIND_TEXT)
            }.Concat(character.OtherCharactersInLocation.Select(Function(x) New DialogChoice(x.CharacterId.ToString, x.Name)))
    End Function

    Private Shared Function GenerateCaption(character As ICharacter) As String
        Return $"Others near {character.Name}"
    End Function

    Public Overrides Function Choose(choice As String) As IDialog
        Select Case choice
            Case NEVER_MIND_CHOICE
                Return New CharacterDialog(
                    character)
            Case Else
                Return New CharacterDialog(
                    character.World.GetCharacter(CInt(choice)))
        End Select
    End Function

    Public Overrides Function CancelDialog() As IDialog
        Return New CharacterDialog(Character)
    End Function
End Class
