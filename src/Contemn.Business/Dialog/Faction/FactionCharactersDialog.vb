Imports TGGD.Business

Friend Class FactionCharactersDialog
    Inherits BaseDialog

    Private ReadOnly faction As IFaction

    Public Sub New(faction As IFaction)
        MyBase.New(
            GenerateCaption(faction),
            GenerateChoices(faction),
            GenerateLines(faction))
        Me.faction = faction
    End Sub

    Private Shared Function GenerateLines(faction As IFaction) As IEnumerable(Of IDialogLine)
        Return Array.Empty(Of IDialogLine)
    End Function

    Private Shared Function GenerateChoices(faction As IFaction) As IEnumerable(Of IDialogChoice)
        Dim result As New List(Of IDialogChoice) From
            {
                New DialogChoice(NEVER_MIND_CHOICE, NEVER_MIND_TEXT)
            }
        For Each character In faction.Characters
            result.Add(New DialogChoice(character.CharacterId.ToString, character.Name))
        Next
        Return result
    End Function

    Private Shared Function GenerateCaption(faction As IFaction) As String
        Return $"{faction.Name} Characters:"
    End Function

    Public Overrides Function Choose(choice As String) As IDialog
        Select Case choice
            Case NEVER_MIND_CHOICE
                Return CancelDialog()
            Case Else
                Return ChooseCharacter(CInt(choice))
        End Select
    End Function

    Private Function ChooseCharacter(characterId As Integer) As IDialog
        Return New CharacterDialog(faction.World.GetCharacter(characterId))
    End Function

    Public Overrides Function CancelDialog() As IDialog
        Return New FactionDialog(faction)
    End Function
End Class
