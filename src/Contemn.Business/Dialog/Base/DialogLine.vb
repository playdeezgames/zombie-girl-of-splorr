Imports TGGD.Business

Friend Class DialogLine
    Implements IDialogLine
    Public Sub New(mood As String, text As String)
        Me.Mood = mood
        Me.Text = text
    End Sub
    Public ReadOnly Property Mood As String Implements IDialogLine.Mood
    Public ReadOnly Property Text As String Implements IDialogLine.Text
End Class
