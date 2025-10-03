Imports TGGD.Business

Friend Class GameMenuDialog
    Inherits BaseDialog

    Private Shared ReadOnly CONTINUE_CHOICE As String = NameOf(CONTINUE_CHOICE)
    Private Shared ReadOnly ABANDON_CHOICE As String = NameOf(ABANDON_CHOICE)
    Const CONTINUE_TEXT = "Continue"
    Const ABANDON_TEXT = "Abandon"
    Private ReadOnly world As IWorld

    Public Sub New(world As IWorld)
        MyBase.New(
            "Game Menu",
            {
                New DialogChoice(CONTINUE_CHOICE, CONTINUE_TEXT),
                New DialogChoice(ABANDON_CHOICE, ABANDON_TEXT)
            },
            Array.Empty(Of IDialogLine))
        Me.world = world
    End Sub

    Public Overrides Function Choose(choice As String) As IDialog
        Select Case choice
            Case CONTINUE_CHOICE
                Return CancelDialog()
            Case ABANDON_CHOICE
                Return New ConfirmAbandonDialog(world)
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    Public Overrides Function CancelDialog() As IDialog
        Return New FactionDialog(world.Avatar.Faction)
    End Function
End Class
