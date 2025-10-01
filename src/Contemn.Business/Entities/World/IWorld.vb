
Imports TGGD.Business

Public Interface IWorld
    Inherits IEntity
    Function CreateMap(mapType As String) As IMap
    ReadOnly Property Maps As IEnumerable(Of IMap)
    Function GetMap(mapId As Integer) As IMap
    Function CreateLocation(locationType As String, map As IMap, column As Integer, row As Integer) As ILocation
    Function GetLocation(locationId As Integer) As ILocation
    Function CreateCharacter(characterType As String, location As ILocation) As ICharacter
    Function GetCharacter(characterId As Integer) As ICharacter
    Function CreateItem(itemType As String, entity As IInventoryEntity) As IItem
    Function GetItem(itemId As Integer) As IItem
    Property Avatar As ICharacter
    Sub AddMessage(mood As String, text As String)
    ReadOnly Property MessageCount As Integer
    Sub DismissMessage()
    Function GetMessage(line As Integer) As IMessage
    Function CreateGenerator() As IGenerator
    Function GetGenerator(generatorId As Integer) As IGenerator
    Function ProcessTurn() As IEnumerable(Of IDialogLine)
    Sub ActivateLocation(location As ILocation)
    Sub DeactivateLocation(location As ILocation)
    ReadOnly Property ActiveLocations As IEnumerable(Of ILocation)
End Interface
