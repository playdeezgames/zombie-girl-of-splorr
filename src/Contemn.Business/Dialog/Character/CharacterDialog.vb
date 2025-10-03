Imports TGGD.Business

Friend Class CharacterDialog
    Inherits BaseDialog
    Private Shared ReadOnly ACTIONS_CHOICE As String = NameOf(ACTIONS_CHOICE)
    Private Shared ReadOnly FACTION_CHOICE As String = NameOf(FACTION_CHOICE)
    Const ACTIONS_TEXT = "Actions..."
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
            New DialogChoice(ACTIONS_CHOICE, ACTIONS_TEXT)
            }
    End Function

    Public Overrides Function Choose(choice As String) As IDialog
        Select Case choice
            Case FACTION_CHOICE
                Return CancelDialog()
            Case ACTIONS_CHOICE
                Return New CharacterActionsDialog(character, VerbCategoryType.Action, ACTIONS_TEXT)
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    Public Overrides Function CancelDialog() As IDialog
        Return New FactionDialog(character.Faction)
    End Function
End Class
