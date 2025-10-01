Public Interface IDialog
    ReadOnly Property Caption As String
    ReadOnly Property Choices As IEnumerable(Of IDialogChoice)
    ReadOnly Property Lines As IEnumerable(Of IDialogLine)
    Function Choose(choice As String) As IDialog
    Function CancelDialog() As IDialog
End Interface
