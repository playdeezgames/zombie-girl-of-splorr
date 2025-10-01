Imports TGGD.UI
Imports Contemn.Business

Friend Class AboutState
    Inherits BaseState

    Public Sub New(buffer As IUIBuffer(Of Integer), world As Business.IWorld, playSfx As Action(Of String))
        MyBase.New(buffer, world, playSfx)
    End Sub

    Public Overrides Sub Refresh()
        Buffer.Fill
        Buffer.WriteCentered(0, "About", Hue.Brown, Hue.Black)
        Dim y = 1
        Buffer.Write(0, y, "A production of TheGrumpyGameDev", Hue.LightGray, Hue.Black)
        y += 1
        Buffer.Write(0, y, "For:", Hue.LightGray, Hue.Black)
        y += 1
        Buffer.Write(0, y, "* Zombie Girl Game Jam 2", Hue.LightGray, Hue.Black)
        y += 1
        Buffer.Write(0, y, "* The Bare-Bones Jam", Hue.LightGray, Hue.Black)
        y += 1
        Buffer.Write(0, y, "* Devtober 2025", Hue.LightGray, Hue.Black)
        y += 2
        Buffer.Write(0, y, "October 2025", Hue.LightGray, Hue.Black)
    End Sub

    Public Overrides Function HandleCommand(command As String) As IUIState
        Return New MainMenuState(Buffer, World, PlaySfx)
    End Function
End Class
