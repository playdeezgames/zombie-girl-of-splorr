Imports TGGD.Business

Friend Class CharacterDialog
    Inherits BaseDialog
    Private Shared ReadOnly ACTIONS_CHOICE As String = NameOf(ACTIONS_CHOICE)
    Private Shared ReadOnly FACTION_CHOICE As String = NameOf(FACTION_CHOICE)
    Private Shared ReadOnly LOCATION_CHOICE As String = NameOf(LOCATION_CHOICE)
    Const ACTIONS_TEXT = "Actions..."
    Private ReadOnly character As ICharacter

    Public Sub New(character As ICharacter)
        MyBase.New(character.Name, GenerateChoices(character), GenerateLines(character))
        Me.character = character
    End Sub

    Private Shared Function GenerateLines(character As ICharacter) As IEnumerable(Of IDialogLine)
        Return character.Description
    End Function

    Private Shared Function GenerateChoices(character As ICharacter) As IEnumerable(Of IDialogChoice)
        Dim result As New List(Of IDialogChoice) From {
            New DialogChoice(FACTION_CHOICE, $"Faction: {character.Faction.Name}"),
            New DialogChoice(LOCATION_CHOICE, $"Location: {character.Location.Name}")
            }
        If character.Faction.IsPlayerFaction Then
            result.Add(New DialogChoice(ACTIONS_CHOICE, ACTIONS_TEXT))
        End If
        Return result
    End Function

    Public Overrides Function Choose(choice As String) As IDialog
        Select Case choice
            Case FACTION_CHOICE
                Return CancelDialog()
            Case ACTIONS_CHOICE
                Return New CharacterActionsDialog(character, VerbCategoryType.Action, ACTIONS_TEXT)
            Case LOCATION_CHOICE
                Return New LocationDialog(character.Location)
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    Public Overrides Function CancelDialog() As IDialog
        Return New FactionDialog(character.Faction)
    End Function
End Class
