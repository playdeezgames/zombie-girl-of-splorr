Imports TGGD.UI
Imports Contemn.Business

Friend MustInherit Class BaseState
    Implements IUIState
    Sub New(buffer As IUIBuffer(Of Integer), world As IWorld, playSfx As Action(Of String))
        Me.buffer = buffer
        Me.world = world
        Me.playSfx = playSfx
    End Sub

    Protected ReadOnly Property Buffer As IUIBuffer(Of Integer)
    Protected ReadOnly Property World As IWorld
    Protected ReadOnly Property PlaySfx As Action(Of String)
    Public MustOverride Sub Refresh() Implements IUIState.Refresh
    Public MustOverride Function HandleCommand(command As String) As IUIState Implements IUIState.HandleCommand
End Class
