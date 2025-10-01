Imports TGGD.UI

Friend MustInherit Class ConfirmState
    Inherits PickerState
    Shared ReadOnly YES_IDENTIFIER As String = NameOf(YES_IDENTIFIER)
    Const YES_TEXT = "Yes"
    Shared ReadOnly NO_IDENTIFIER As String = NameOf(NO_IDENTIFIER)
    Const NO_TEXT = "No"

    Public Sub New(
                  buffer As IUIBuffer(Of Integer),
                  world As Business.IWorld,
                  playSfx As Action(Of String),
                  title As String,
                  titleForegroundColor As Integer)
        MyBase.New(
            buffer,
            world,
            playSfx,
            title,
            titleForegroundColor,
            {
                (NO_IDENTIFIER, NO_TEXT),
                (YES_IDENTIFIER, YES_TEXT)
            })
    End Sub

    Protected Overrides Function HandleMenuItem(identifier As String) As IUIState
        Select Case identifier
            Case YES_IDENTIFIER
                Return OnConfirm()
            Case NO_IDENTIFIER
                Return OnCancel()
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    Protected MustOverride Function OnCancel() As IUIState
    Protected MustOverride Function OnConfirm() As IUIState
End Class
