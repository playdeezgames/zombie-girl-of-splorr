Imports TGGD.UI
Imports Contemn.Business

Friend Class TitleState
    Inherits BaseState

    Public Sub New(
                  buffer As IUIBuffer(Of Integer),
                  world As Business.IWorld,
                  playSfx As Action(Of String))
        MyBase.New(buffer, world, playSfx)
    End Sub

    Public Overrides Sub Refresh()
        Buffer.Fill()
        Buffer.WriteCentered(Buffer.Rows \ 2 - 1, "Zombie Girl of SPLORR!!", Hue.LightCyan, Hue.Black)
        Buffer.WriteCentered(Buffer.Rows \ 2, "(Three Great Jams, One Lousy Game!)", Hue.Cyan, Hue.Black)
        Buffer.WriteCentered(Buffer.Rows \ 2 + 2, "A Production of TheGrumpyGameDev", Hue.DarkGray, Hue.Black)
        Buffer.WriteCentered(Buffer.Rows \ 2 + 3, "For:", Hue.DarkGray, Hue.Black)
        Buffer.WriteCentered(Buffer.Rows \ 2 + 4, "Zombie Girl Game Jam 2", Hue.DarkGray, Hue.Black)
        Buffer.WriteCentered(Buffer.Rows \ 2 + 5, "The Bare-Bones Jam", Hue.DarkGray, Hue.Black)
        Buffer.WriteCentered(Buffer.Rows \ 2 + 6, "Devtober 2025", Hue.DarkGray, Hue.Black)
        Buffer.WriteCentered(Buffer.Rows \ 2 + 8, "October 2025", Hue.DarkGray, Hue.Black)
        Buffer.WriteCentered(Buffer.Rows - 1, "Press <SPACE>", Hue.White, Hue.Black)
    End Sub

    Public Overrides Function HandleCommand(command As String) As IUIState
        If command = UI.Command.Green Then
            Return New MainMenuState(Buffer, World, PlaySfx)
        End If
        Return Me
    End Function
End Class
