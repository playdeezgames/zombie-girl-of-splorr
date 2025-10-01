Imports TGGD.Business
Imports TGGD.UI
Imports Contemn.Business
Imports Contemn.Data

Public Class UIContext
    Implements IUIContext
    ReadOnly buffer As IUIBuffer(Of Integer)
    Private state As IUIState = Nothing
    Private ReadOnly eventQueue As New Queue(Of IEnumerable(Of String))
    Private ReadOnly worldData As New WorldData
    Private ReadOnly Property World As IWorld
        Get
            Return New Business.World(worldData, AddressOf PlaySfx)
        End Get
    End Property
    Const EVENT_PLAY_SFX = "PlaySfx"
    Private Sub PlaySfx(sfx As String)
        eventQueue.Enqueue({EVENT_PLAY_SFX, sfx})
    End Sub
    Sub New(columns As Integer, rows As Integer, frameBuffer As Integer())
        Me.buffer = New UIBuffer(Of Integer)(columns, rows, frameBuffer)
        state = New TitleState(buffer, World, AddressOf PlaySfx)
    End Sub

    Public ReadOnly Property [Event] As IEnumerable(Of String) Implements IUIContext.Event
        Get
            Return If(eventQueue.Any, eventQueue.Peek, Nothing)
        End Get
    End Property

    Public Sub NextEvent() Implements IUIContext.NextEvent
        If eventQueue.Any Then
            eventQueue.Dequeue()
        End If
    End Sub

    Public Sub Refresh() Implements IUIContext.Refresh
        state.Refresh()
    End Sub

    Public Sub HandleCommand(command As String) Implements IUIContext.HandleCommand
        state = state.HandleCommand(command)
    End Sub
End Class
