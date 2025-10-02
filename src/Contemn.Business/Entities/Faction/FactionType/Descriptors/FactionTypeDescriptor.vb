Friend MustInherit Class FactionTypeDescriptor
    Friend ReadOnly Property FactionType As String
    Friend ReadOnly Property FactionCount As Integer
    Sub New(factionType As String, factionCount As Integer)
        Me.FactionType = factionType
        Me.FactionCount = factionCount
    End Sub
End Class
