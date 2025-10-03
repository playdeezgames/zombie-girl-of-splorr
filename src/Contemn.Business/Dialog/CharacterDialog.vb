Imports TGGD.Business

Friend Class CharacterDialog
    Inherits BaseDialog
    Private Shared ReadOnly ACTIONS_CHOICE As String = NameOf(ACTIONS_CHOICE)
    Private Shared ReadOnly MOVE_CHOICE As String = NameOf(MOVE_CHOICE)
    Private Shared ReadOnly FACTION_CHOICE As String = NameOf(FACTION_CHOICE)
    Const ACTIONS_TEXT = "Actions..."
    Const MOVE_TEXT = "Move..."
    Private ReadOnly character As ICharacter

    Public Sub New(character As ICharacter)
        MyBase.New(character.Name, GenerateChoices(character), GenerateLines(character))
        Me.character = character
    End Sub

    Private Shared Function GenerateLines(character As ICharacter) As IEnumerable(Of IDialogLine)
        Dim result = character.World.Messages.Select(Function(x) New DialogLine(x.Mood, x.Text)).ToList
        character.World.DismissMessages()
        Return result
    End Function

    Private Shared Function GenerateChoices(character As ICharacter) As IEnumerable(Of IDialogChoice)
        Return {
            New DialogChoice(FACTION_CHOICE, $"Faction: {character.Faction.Name}"),
            New DialogChoice(MOVE_CHOICE, MOVE_TEXT),
            New DialogChoice(ACTIONS_CHOICE, ACTIONS_TEXT),
            New DialogChoice(GAME_MENU_CHOICE, GAME_MENU_TEXT)
            }
    End Function

    Public Overrides Function Choose(choice As String) As IDialog
        Select Case choice
            Case FACTION_CHOICE
                Return New FactionDialog(character.Faction)
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
