Imports TGGD.Business

Friend Class OkDialog
    Inherits MessageDialog


    Public Sub New(lines As IEnumerable(Of IDialogLine), nextDialog As Func(Of IDialog))
        MyBase.New(lines, {(OK_CHOICE, OK_TEXT, nextDialog, True)}, nextDialog)
    End Sub
End Class
