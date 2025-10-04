Imports TGGD.Business

Friend MustInherit Class FactionTypeDescriptor
    Friend ReadOnly Property FactionType As String
    Friend ReadOnly Property FactionCount As Integer
    Sub New(factionType As String, factionCount As Integer)
        Me.FactionType = factionType
        Me.FactionCount = factionCount
    End Sub

    Friend MustOverride Function GetName(faction As Faction) As String
    Friend Overridable Function Describe(faction As Faction) As IEnumerable(Of IDialogLine)
        Return {
            New DialogLine(MoodType.Info, $"Characters: {faction.CharacterCount}")
            }
    End Function
End Class
