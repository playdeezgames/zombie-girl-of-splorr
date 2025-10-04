Imports TGGD.Business

Friend Class FactionDialog
    Inherits BaseDialog

    Private Shared ReadOnly CHARACTERS_CHOICE As String = NameOf(CHARACTERS_CHOICE)
    Const CHARACTERS_TEXT = "Characters..."

    Private ReadOnly faction As IFaction

    Public Sub New(faction As IFaction)
        MyBase.New(
            GenerateCaption(faction),
            GenerateChoices(faction),
            GenerateLines(faction))
        Me.faction = faction
    End Sub

    Private Shared Function GenerateLines(faction As IFaction) As IEnumerable(Of IDialogLine)
        Return faction.Description
    End Function

    Private Shared Function GenerateChoices(faction As IFaction) As IEnumerable(Of IDialogChoice)
        Dim result As New List(Of IDialogChoice)
        If faction.HasCharacters Then
            result.Add(New DialogChoice(CHARACTERS_CHOICE, CHARACTERS_TEXT))
        End If
        result.Add(New DialogChoice(GAME_MENU_CHOICE, GAME_MENU_TEXT))
        Return result
    End Function

    Private Shared Function GenerateCaption(faction As IFaction) As String
        Return $"Faction: {faction.Name}"
    End Function

    Public Overrides Function Choose(choice As String) As IDialog
        Select Case choice
            Case GAME_MENU_CHOICE
                Return CancelDialog()
            Case CHARACTERS_CHOICE
                Return New FactionCharactersDialog(faction)
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    Public Overrides Function CancelDialog() As IDialog
        Return New GameMenuDialog(faction.World)
    End Function
End Class
