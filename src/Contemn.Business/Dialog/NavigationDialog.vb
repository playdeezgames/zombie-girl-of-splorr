Imports TGGD.Business

Friend Class NavigationDialog
    Inherits BaseDialog
    Private Shared ReadOnly ACTIONS_CHOICE As String = NameOf(ACTIONS_CHOICE)
    Private Shared ReadOnly GAME_MENU_CHOICE As String = NameOf(GAME_MENU_CHOICE)
    Private Shared ReadOnly MOVE_CHOICE As String = NameOf(MOVE_CHOICE)
    Const ACTIONS_TEXT = "Actions..."
    Const GAME_MENU_TEXT = "Game Menu..."
    Const MOVE_TEXT = "Move..."
    Private ReadOnly character As ICharacter

    Public Sub New(character As ICharacter)
        MyBase.New(character.Name, GenerateChoices(character), GenerateLines(character))
        Me.character = character
    End Sub

    Private Shared Function GenerateLines(character As ICharacter) As IEnumerable(Of IDialogLine)
        Dim result = character.World.Messages.Select(Function(x) New DialogLine(x.Mood, x.Text)).ToList
        character.World.DismissMessages()
        Return result.
            Append(New DialogLine(MoodType.Info, $"Faction: {character.Faction.Name}"))
    End Function

    Private Shared Function GenerateChoices(character As ICharacter) As IEnumerable(Of IDialogChoice)
        Return {
            New DialogChoice(MOVE_CHOICE, MOVE_TEXT),
            New DialogChoice(ACTIONS_CHOICE, ACTIONS_TEXT),
            New DialogChoice(GAME_MENU_CHOICE, GAME_MENU_TEXT)
            }
    End Function

    Public Overrides Function Choose(choice As String) As IDialog
        Select Case choice
            Case ACTIONS_CHOICE
                Return New VerbListDialog(character, VerbCategoryType.Action, ACTIONS_TEXT)
            Case GAME_MENU_CHOICE
                Return CancelDialog()
            Case MOVE_CHOICE
                Return New VerbListDialog(character, VerbCategoryType.Move, MOVE_TEXT)
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    Public Overrides Function CancelDialog() As IDialog
        Return New GameMenuDialog(character)
    End Function
End Class
