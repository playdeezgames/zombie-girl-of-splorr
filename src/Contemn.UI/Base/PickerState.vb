Imports TGGD.UI
Imports Contemn.Business

Friend MustInherit Class PickerState
    Inherits BaseState
    ReadOnly menuItems As IReadOnlyList(Of (Identifier As String, Text As String))
    Private ReadOnly title As String
    Private ReadOnly titleForegroundColor As Integer
    Private menuItemIndex As Integer = 0

    Protected Sub New(
                     buffer As IUIBuffer(Of Integer),
                     world As Business.IWorld,
                     playSfx As Action(Of String),
                     title As String,
                     titleForegroundColor As Integer,
                     menuItems As IEnumerable(Of (Identifier As String, Text As String)))
        MyBase.New(buffer, world, playSfx)
        Me.menuItems = menuItems.ToList
        Me.title = title
        Me.titleforegroundcolor = titleForegroundColor
    End Sub

    Public Overrides Sub Refresh()
        Buffer.Fill()
        Buffer.Fill(0, Buffer.Rows \ 2, Buffer.Columns, 1, backgroundColor:=Hue.LightGray)
        Dim y = Buffer.Rows \ 2 - menuItemIndex
        For Each menuItem In menuItems
            Dim foregroundColor = If(y = Buffer.Rows \ 2, Hue.Black, Hue.LightGray)
            Dim backgroundColor = If(y = Buffer.Rows \ 2, Hue.LightGray, Hue.Black)
            Buffer.WriteCentered(y, menuItem.Text, foregroundColor, backgroundColor)
            y += 1
        Next
        Buffer.WriteCentered(0, title, titleForegroundColor, Hue.Black)
    End Sub

    Public Overrides Function HandleCommand(command As String) As IUIState
        Select Case command
            Case UI.Command.Up
                menuItemIndex = (menuItemIndex + menuItems.Count - 1) Mod menuItems.Count
                Return Me
            Case UI.Command.Down
                menuItemIndex = (menuItemIndex + 1) Mod menuItems.Count
                Return Me
            Case UI.Command.Green
                Return HandleMenuItem(menuItems(menuItemIndex).Identifier)
            Case UI.Command.Red
                Return HandleCancel()
            Case Else
                Return Me
        End Select
    End Function

    Protected MustOverride Function HandleCancel() As IUIState
    Protected MustOverride Function HandleMenuItem(identifier As String) As IUIState
End Class
