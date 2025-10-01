Imports TGGD.Business

Friend Class ConfirmAbandonDialog
    Inherits BaseDialog
    Private Shared ReadOnly NO_CHOICE As String = NameOf(NO_CHOICE)
    Private Shared ReadOnly YES_CHOICE As String = NameOf(YES_CHOICE)
    Private ReadOnly character As ICharacter
    Const NO_TEXT = "No"
    Const YES_TEXT = "Yes"

    Public Sub New(character As ICharacter)
        MyBase.New(
            "Are you sure you want to abandon?",
            {
                New DialogChoice(NO_CHOICE, NO_TEXT),
                New DialogChoice(YES_CHOICE, YES_TEXT)
            },
            Array.Empty(Of IDialogLine))
        Me.character = character
    End Sub

    Public Overrides Function Choose(choice As String) As IDialog
        Select Case choice
            Case NO_CHOICE
                Return CancelDialog()
            Case YES_CHOICE
                character.World.Clear()
                Return Nothing
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    Public Overrides Function CancelDialog() As IDialog
        Return New GameMenuDialog(character)
    End Function
End Class
