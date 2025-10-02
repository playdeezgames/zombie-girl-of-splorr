Imports Contemn.Data

Public Class Faction
    Inherits Entity(Of FactionData)
    Implements IFaction

    Public Sub New(
                  data As WorldData,
                  factionId As Integer,
                  playSfx As Action(Of String))
        MyBase.New(data, playSfx)
        Me.FactionId = factionId
    End Sub

    Public ReadOnly Property FactionId As Integer Implements IFaction.FactionId

    Protected Overrides ReadOnly Property EntityData As FactionData
        Get
            Return Data.Factions(FactionId)
        End Get
    End Property

    Public Overrides Sub Recycle()
        Clear()
        Data.RecycledFactions.Add(FactionId)
    End Sub
End Class
