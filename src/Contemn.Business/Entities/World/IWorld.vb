
Imports TGGD.Business

Public Interface IWorld
    Inherits IEntity
    Function CreateLocation(locationType As String) As ILocation
    Function GetLocation(locationId As Integer) As ILocation
    Function CreateCharacter(characterType As String, location As ILocation, faction As IFaction) As ICharacter
    Function GetCharacter(characterId As Integer) As ICharacter
    Function CreateItem(itemType As String, entity As IInventoryEntity) As IItem
    Function GetItem(itemId As Integer) As IItem
    Property Avatar As ICharacter
    Sub AddMessage(mood As String, text As String)
    Sub DismissMessages()
    ReadOnly Property Messages As IEnumerable(Of IMessage)
    Function CreateGenerator() As IGenerator
    Function GetGenerator(generatorId As Integer) As IGenerator
    Function ProcessTurn() As IEnumerable(Of IDialogLine)
    Sub ActivateLocation(location As ILocation)
    Sub DeactivateLocation(location As ILocation)
    ReadOnly Property ActiveLocations As IEnumerable(Of ILocation)
    Function CreateFaction(factionType As String) As IFaction
    ReadOnly Property Factions As IEnumerable(Of IFaction)
    Function GetFaction(factionId As Integer) As IFaction
End Interface
