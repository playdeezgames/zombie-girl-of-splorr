Imports TGGD.Business

Friend Class ConfirmAbandonDialog
    Inherits BaseDialog
    Private Shared ReadOnly NO_CHOICE As String = NameOf(NO_CHOICE)
    Private Shared ReadOnly YES_CHOICE As String = NameOf(YES_CHOICE)
    Private ReadOnly world As IWorld
    Private previousDialog As Func(Of IDialog)
    Const NO_TEXT = "No"
    Const YES_TEXT = "Yes"

    Public Sub New(world As IWorld, previousDialog As Func(Of IDialog))
        MyBase.New(
            "Are you sure you want to abandon?",
            {
                New DialogChoice(NO_CHOICE, NO_TEXT),
                New DialogChoice(YES_CHOICE, YES_TEXT)
            },
            Array.Empty(Of IDialogLine))
        Me.world = world
        Me.previousDialog = previousDialog
    End Sub

    Public Overrides Function Choose(choice As String) As IDialog
        Select Case choice
            Case NO_CHOICE
                Return CancelDialog()
            Case YES_CHOICE
                world.Clear()
                Return Nothing
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    Public Overrides Function CancelDialog() As IDialog
        Return New GameMenuDialog(world, previousDialog)
    End Function
End Class
