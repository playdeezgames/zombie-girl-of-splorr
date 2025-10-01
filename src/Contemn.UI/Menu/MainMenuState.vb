Imports TGGD.UI
Imports Contemn.Business

Friend Class MainMenuState
    Inherits PickerState
    Shared ReadOnly EMBARK_IDENTIFIER As String = NameOf(EMBARK_IDENTIFIER)
    Const EMBARK_TEXT = "Embark!"
    Shared ReadOnly ABOUT_IDENTIFIER As String = NameOf(ABOUT_IDENTIFIER)
    Const ABOUT_TEXT = "About"
    Public Sub New(
                  buffer As IUIBuffer(Of Integer),
                  world As Business.IWorld,
                  playSfx As Action(Of String))
        MyBase.New(
            buffer,
            world,
            playSfx,
            "Main Menu",
            Hue.Magenta,
            {
                (EMBARK_IDENTIFIER, EMBARK_TEXT),
                (ABOUT_IDENTIFIER, ABOUT_TEXT)
            })
    End Sub

    Protected Overrides Function HandleMenuItem(identifier As String) As IUIState
        Select Case identifier
            Case EMBARK_IDENTIFIER
                Return HandleEmbarkation()
            Case ABOUT_IDENTIFIER
                Return New AboutState(Buffer, World, PlaySfx)
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    Private Function HandleEmbarkation() As IUIState
        World.Initialize()
        Return NeutralState.DetermineState(Buffer, World, PlaySfx)
    End Function

    Protected Overrides Function HandleCancel() As IUIState
        Return Me
    End Function
End Class
