Imports TGGD.Business
Imports TGGD.UI
Imports Contemn.Business

Friend Class DialogState
    Inherits BaseState

    ReadOnly dialog As IDialog
    Private choiceIndex As Integer

    Public Sub New(
                  buffer As IUIBuffer(Of Integer),
                  world As Business.IWorld,
                  playSfx As Action(Of String),
                  dialog As IDialog)
        MyBase.New(buffer, world, playSfx)
        Me.dialog = dialog
        choiceIndex = 0
    End Sub

    Public Overrides Sub Refresh()
        Buffer.Fill()
        Buffer.WriteCentered(0, dialog.Caption, Hue.Brown, Hue.Black)
        Dim topRow = 1
        For Each line In dialog.Lines
            Dim colors = MoodColors(line.Mood)
            Buffer.WriteCentered(topRow, line.Text, colors.ForegroundColor, colors.BackgroundColor)
            topRow += 1
        Next
        Dim centerRow = (topRow + Buffer.Rows - 1) \ 2
        Buffer.Fill(0, centerRow, Buffer.Columns, 1, 0, Hue.Black, Hue.LightGray)
        Dim row = centerRow - choiceIndex
        For Each choice In dialog.Choices
            If row >= topRow AndAlso row < Buffer.Rows - 1 Then
                If row = centerRow Then
                    Buffer.WriteCentered(row, choice.Text, Hue.Black, Hue.LightGray)
                Else
                    Buffer.WriteCentered(row, choice.Text, Hue.LightGray, Hue.Black)
                End If
            End If
            row += 1
        Next
    End Sub

    Public Overrides Function HandleCommand(command As String) As IUIState
        Select Case command
            Case UI.Command.Up
                choiceIndex = (choiceIndex + dialog.Choices.Count - 1) Mod dialog.Choices.Count
                Return Me
            Case UI.Command.Down
                choiceIndex = (choiceIndex + 1) Mod dialog.Choices.Count
                Return Me
            Case UI.Command.Green
                Dim nextDialog = dialog.Choose(dialog.Choices.ToArray()(choiceIndex).Choice)
                Return SetNextDialog(nextDialog)
            Case UI.Command.Red
                Return SetNextDialog(dialog.CancelDialog())
            Case Else
                Return Me
        End Select
    End Function

    Private Function SetNextDialog(nextDialog As IDialog) As IUIState
        If nextDialog IsNot Nothing Then
            Return New DialogState(Buffer, World, PlaySfx, nextDialog)
        Else
            Return NeutralState.DetermineState(Buffer, World, PlaySfx)
        End If
    End Function
End Class
