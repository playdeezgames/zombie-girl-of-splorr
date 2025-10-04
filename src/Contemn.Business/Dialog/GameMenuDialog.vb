Imports TGGD.Business

Friend Class GameMenuDialog
    Inherits BaseDialog

    Private Shared ReadOnly CONTINUE_CHOICE As String = NameOf(CONTINUE_CHOICE)
    Private Shared ReadOnly ABANDON_CHOICE As String = NameOf(ABANDON_CHOICE)
    Private ReadOnly world As IWorld
    Private ReadOnly previousDialog As Func(Of IDialog)
    Const CONTINUE_TEXT = "Continue"
    Const ABANDON_TEXT = "Abandon"


    Public Sub New(world As IWorld, previousDialog As Func(Of IDialog))
        MyBase.New(
            "Game Menu",
            {
                New DialogChoice(CONTINUE_CHOICE, CONTINUE_TEXT),
                New DialogChoice(ABANDON_CHOICE, ABANDON_TEXT)
            },
            Array.Empty(Of IDialogLine))
        Me.world = world
        Me.previousDialog = previousDialog
    End Sub

    Public Overrides Function Choose(choice As String) As IDialog
        Select Case choice
            Case CONTINUE_CHOICE
                Return CancelDialog()
            Case ABANDON_CHOICE
                Return New ConfirmAbandonDialog(world, previousDialog)
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    Public Overrides Function CancelDialog() As IDialog
        Return previousDialog()
    End Function
End Class
