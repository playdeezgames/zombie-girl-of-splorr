Imports Contemn.Data

Friend Class Message
    Implements IMessage
    ReadOnly data As WorldData
    ReadOnly line As Integer
    Sub New(data As WorldData, line As Integer)
        Me.data = data
        Me.line = line
    End Sub

    Public ReadOnly Property Mood As String Implements IMessage.Mood
        Get
            Return data.Messages(line).Mood
        End Get
    End Property

    Public ReadOnly Property Text As String Implements IMessage.Text
        Get
            Return data.Messages(line).Text
        End Get
    End Property
End Class
