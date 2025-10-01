Imports TGGD.Business

Friend Class DialogChoice
    Implements IDialogChoice

    Public Sub New(choice As String, text As String)
        Me.Choice = choice
        Me.Text = text
    End Sub
    Public ReadOnly Property Choice As String Implements IDialogChoice.Choice
    Public ReadOnly Property Text As String Implements IDialogChoice.Text
End Class
