Imports TGGD.UI
Imports Contemn.Business

Friend Module NeutralState
    Friend Function DetermineState(
                                  buffer As IUIBuffer(Of Integer),
                                  world As IWorld,
                                  playSfx As Action(Of String)) As IUIState
        Dim avatar = world.Avatar
        If avatar Is Nothing Then
            Return New MainMenuState(buffer, world, playSfx)
        End If
        Return New DialogState(buffer, world, playSfx, avatar.Navigate())
    End Function
End Module
