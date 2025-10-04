Imports System.Data
Imports TGGD.Business
Imports Contemn.Data

Public Class World
    Inherits Entity(Of WorldData)
    Implements IWorld
    Sub New(data As WorldData, playSfx As Action(Of String))
        MyBase.New(data, playSfx)
    End Sub

    Protected Overrides ReadOnly Property EntityData As WorldData
        Get
            Return Data
        End Get
    End Property

    Public ReadOnly Property ActiveLocations As IEnumerable(Of ILocation) Implements IWorld.ActiveLocations
        Get
            Return EntityData.ActiveLocations.Select(Function(x) New Location(Data, x, AddressOf PlaySfx))
        End Get
    End Property

    Public ReadOnly Property Messages As IEnumerable(Of IMessage) Implements IWorld.Messages
        Get
            Return Enumerable.Range(0, EntityData.Messages.Count).Select(Function(x) New Message(Data, x))
        End Get
    End Property

    Public ReadOnly Property Factions As IEnumerable(Of IFaction) Implements IWorld.Factions
        Get
            Dim factionIds As New HashSet(Of Integer)(Enumerable.Range(0, Data.Factions.Count))
            factionIds.RemoveWhere(Function(x) Data.RecycledFactions.Contains(x))
            Return factionIds.Select(Function(x) GetFaction(x))
        End Get
    End Property

    Public Property PlayerFaction As IFaction Implements IWorld.PlayerFaction
        Get
            Return If(
                Data.PlayerFactionId.HasValue,
                GetFaction(Data.PlayerFactionId.Value),
                Nothing)
        End Get
        Set(value As IFaction)
            Data.PlayerFactionId = value?.FactionId
        End Set
    End Property

    Public Overrides ReadOnly Property Description As IEnumerable(Of IDialogLine)
        Get
            Return Array.Empty(Of IDialogLine)
        End Get
    End Property

    Public Overrides Sub Clear()
        MyBase.Clear()
        Data.Locations.Clear()
        Data.RecycledLocations.Clear()
        Data.Characters.Clear()
        Data.RecycledCharacters.Clear()
        Data.Messages.Clear()
        Data.Items.Clear()
        Data.RecycledItems.Clear()
        Data.Generators.Clear()
        Data.PlayerFactionId = Nothing
        Data.ActiveLocations.Clear()
        Data.Factions.Clear()
        Data.RecycledFactions.Clear()
    End Sub
    Public Overrides Sub Initialize()
        MyBase.Initialize()
        CreateFactions()
        PlayerFaction = Factions.Single(Function(x) x.FactionType = NameOf(ZombieGirlFactionTypeDescriptor))
        Dim cemetery = CreateLocation(NameOf(CemeteryLocationTypeDescriptor))
        CreateCharacter(
            NameOf(ZombieGirlCharacterTypeDescriptor),
            cemetery,
            PlayerFaction)
        CreateCharacter(
            NameOf(CuteBoyCharacterTypeDescriptor),
            cemetery,
            Factions.Single(Function(x) x.FactionType = NameOf(CuteBoysFactionTypeDescriptor)))
    End Sub

    Private Sub CreateFactions()
        For Each factionType In FactionTypes.All
            Dim descriptor = factionType.ToFactionTypeDescriptor()
            For Each dummy In Enumerable.Range(0, descriptor.FactionCount)
                CreateFaction(factionType)
            Next
        Next
    End Sub

    Public Sub AddMessage(mood As String, text As String) Implements IWorld.AddMessage
        Data.Messages.Add(New MessageData With {.Mood = mood, .Text = text})
    End Sub

    Public Sub DismissMessages() Implements IWorld.DismissMessages
        Data.Messages.Clear()
    End Sub

    Public Function CreateLocation(locationType As String) As ILocation Implements IWorld.CreateLocation
        Dim locationId = Data.Locations.Count
        Data.Locations.Add(New LocationData With {
                            .LocationType = locationType
                           })
        Dim result = New Location(
            Data,
            locationId,
            AddressOf PlaySfx)
        result.Initialize()
        Return result
    End Function

    Public Function CreateCharacter(
                                   characterType As String,
                                   location As ILocation,
                                   faction As IFaction) As ICharacter Implements IWorld.CreateCharacter
        Dim characterId = Data.Characters.Count
        Data.Characters.Add(New CharacterData With {
                            .CharacterType = characterType,
                            .LocationId = location.LocationId,
                            .FactionId = faction.FactionId})
        Dim result As ICharacter = New Character(
            Data,
            characterId,
            AddressOf PlaySfx)
        result.Initialize()
        faction.AddCharacter(result)
        Return result
    End Function

    Public Function CreateItem(
                              itemType As String,
                              entity As IInventoryEntity) As IItem Implements IWorld.CreateItem
        Dim itemId As Integer
        If Data.RecycledItems.Any Then
            itemId = Data.RecycledItems.First
            Data.RecycledItems.Remove(itemId)
            Data.Items(itemId) = New ItemData With {.ItemType = itemType}
        Else
            itemId = Data.Items.Count
            Data.Items.Add(New ItemData With {.ItemType = itemType})
        End If
        Dim result = New Item(Data, itemId, AddressOf PlaySfx)
        result.Initialize()
        entity.AddItem(result)
        Return result
    End Function

    Public Function GetLocation(locationId As Integer) As ILocation Implements IWorld.GetLocation
        Return New Location(Data, locationId, AddressOf PlaySfx)
    End Function

    Public Function GetItem(itemId As Integer) As IItem Implements IWorld.GetItem
        Return New Item(Data, itemId, AddressOf PlaySfx)
    End Function

    Public Overrides Sub Recycle()
        Clear()
    End Sub

    Public Function GetGenerator(generatorId As Integer) As IGenerator Implements IWorld.GetGenerator
        Return New Generator(Data, generatorId)
    End Function

    Public Function CreateGenerator() As IGenerator Implements IWorld.CreateGenerator
        Dim generatorId As Integer
        If Data.RecycledGenerators.Any Then
            generatorId = Data.RecycledGenerators.First
            Data.Generators(generatorId).Clear()
            Data.RecycledGenerators.Remove(generatorId)
        Else
            generatorId = Data.Generators.Count
            Data.Generators.Add(New Dictionary(Of String, Integer)())
        End If
        Return New Generator(Data, generatorId)
    End Function

    Public Function GetCharacter(characterId As Integer) As ICharacter Implements IWorld.GetCharacter
        Return New Character(Data, characterId, AddressOf PlaySfx)
    End Function

    Public Function ProcessTurn() As IEnumerable(Of IDialogLine) Implements IWorld.ProcessTurn
        For Each location In ActiveLocations
            location.ProcessTurn()
        Next
        Dim result As New List(Of IDialogLine)
        Return result
    End Function

    Public Sub ActivateLocation(location As ILocation) Implements IWorld.ActivateLocation
        EntityData.ActiveLocations.Add(location.LocationId)
    End Sub

    Public Sub DeactivateLocation(location As ILocation) Implements IWorld.DeactivateLocation
        EntityData.ActiveLocations.Remove(location.LocationId)
    End Sub

    Public Function CreateFaction(factionType As String) As IFaction Implements IWorld.CreateFaction
        Dim factionId As Integer
        If Data.RecycledFactions.Any Then
            factionId = Data.RecycledFactions.First
            Data.RecycledFactions.Remove(factionId)
            Data.Factions(factionId) = New FactionData With {.factionType = factionType}
        Else
            factionId = Data.Factions.Count
            Data.Factions.Add(New FactionData With {.factionType = factionType})
        End If
        Dim result As IFaction = New Faction(Data, factionId, AddressOf PlaySfx)
        result.Initialize()
        Return result
    End Function

    Public Function GetFaction(factionId As Integer) As IFaction Implements IWorld.GetFaction
        Return New Faction(Data, factionId, AddressOf PlaySfx)
    End Function
End Class
