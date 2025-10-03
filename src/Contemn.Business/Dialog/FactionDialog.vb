Imports TGGD.Business

Friend Class FactionDialog
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
        Return {
            New DialogChoice(GAME_MENU_CHOICE, GAME_MENU_TEXT)
            }
    End Function

    Private Shared Function GenerateCaption(faction As IFaction) As String
        Return $"Faction: {faction.Name}"
    End Function

    Public Overrides Function Choose(choice As String) As IDialog
        Select Case choice
            Case GAME_MENU_CHOICE
                Return New GameMenuDialog(faction.World)
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    Public Overrides Function CancelDialog() As IDialog
        Return Me
    End Function
End Class
