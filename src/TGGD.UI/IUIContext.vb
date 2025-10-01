Public Interface IUIContext
    ReadOnly Property [Event] As IEnumerable(Of String)
    Sub NextEvent()
    Sub Refresh()
    Sub HandleCommand(command As String)
End Interface
