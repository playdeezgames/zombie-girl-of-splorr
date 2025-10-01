Imports TGGD.Business

Friend Class MessageDialog
    Inherits BaseDialog

    ReadOnly onCancel As Func(Of IDialog)
    ReadOnly choiceTable As IReadOnlyDictionary(Of String, Func(Of IDialog))

    Public Sub New(
                  lines As IEnumerable(Of IDialogLine),
                  choices As IEnumerable(Of (Choice As String, Text As String, NextDialog As Func(Of IDialog), Enabled As Boolean)),
                  cancelDialog As Func(Of IDialog))
        MyBase.New("Message", choices.Where(Function(x) x.Enabled).Select(Function(x) New DialogChoice(x.Choice, x.Text)), lines)
        Me.choiceTable = choices.Where(Function(x) x.Enabled).ToDictionary(Function(x) x.Choice, Function(x) x.NextDialog)
        Me.onCancel = cancelDialog
    End Sub

    Public Overrides Function Choose(choice As String) As IDialog
        Return choiceTable(choice).Invoke()
    End Function

    Public Overrides Function CancelDialog() As IDialog
        Return onCancel()
    End Function
End Class
