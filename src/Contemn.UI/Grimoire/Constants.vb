Imports Contemn.Business

Friend Module Constants
    Friend Const SCREEN_HEIGHT = 25
    Friend Const SCREEN_WIDTH = 40
    Friend Const MESSAGE_LINES = 4
    Friend Const VIEW_WIDTH = 25
    Friend Const VIEW_HEIGHT = SCREEN_HEIGHT - MESSAGE_LINES


    Friend ReadOnly MoodColors As IReadOnlyDictionary(Of String, (ForegroundColor As Integer, BackgroundColor As Integer)) =
        New Dictionary(Of String, (ForegroundColor As Integer, BackgroundColor As Integer)) From
        {
            {MoodType.Info, (Hue.LightGray, Hue.Black)},
            {MoodType.Danger, (Hue.Black, Hue.Red)},
            {MoodType.Warning, (Hue.Black, Hue.Yellow)},
            {MoodType.Heading, (Hue.Cyan, Hue.Black)}
        }
End Module
