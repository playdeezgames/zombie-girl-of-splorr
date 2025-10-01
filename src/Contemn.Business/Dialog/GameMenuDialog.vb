Imports TGGD.Business

Friend Class GameMenuDialog
    Inherits BaseDialog

    Private Shared ReadOnly CONTINUE_CHOICE As String = NameOf(CONTINUE_CHOICE)
    Private Shared ReadOnly ABANDON_CHOICE As String = NameOf(ABANDON_CHOICE)
    Const CONTINUE_TEXT = "Continue"
    Const ABANDON_TEXT = "Abandon"
    Private ReadOnly character As ICharacter

    Public Sub New(character As ICharacter)
        MyBase.New(
            "Game Menu",
            {
                New DialogChoice(CONTINUE_CHOICE, CONTINUE_TEXT),
                New DialogChoice(ABANDON_CHOICE, ABANDON_TEXT)
            },
            Array.Empty(Of IDialogLine))
        Me.character = character
    End Sub

    Public Overrides Function Choose(choice As String) As IDialog
        Select Case choice
            Case CONTINUE_CHOICE
                Return CancelDialog()
            Case ABANDON_CHOICE
                Return New ConfirmAbandonDialog(character)
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    Public Overrides Function CancelDialog() As IDialog
        Return New NavigationDialog(character)
    End Function
End Class
