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

    Public ReadOnly Property FactionType As String Implements IFaction.FactionType
        Get
            Return EntityData.FactionType
        End Get
    End Property

    Public ReadOnly Property Name As String Implements IFaction.Name
        Get
            Return FactionType.ToFactionTypeDescriptor.GetName(Me)
        End Get
    End Property

    Protected Overrides ReadOnly Property EntityData As FactionData
        Get
            Return Data.Factions(FactionId)
        End Get
    End Property

    Public Overrides Sub Recycle()
        Clear()
        Data.RecycledFactions.Add(FactionId)
    End Sub

    Public Sub AddCharacter(character As ICharacter) Implements IFaction.AddCharacter
        EntityData.CharacterIds.Add(character.CharacterId)
    End Sub

    Public Sub RemoveCharacter(character As ICharacter) Implements IFaction.RemoveCharacter
        EntityData.CharacterIds.Remove(character.CharacterId)
    End Sub
End Class
