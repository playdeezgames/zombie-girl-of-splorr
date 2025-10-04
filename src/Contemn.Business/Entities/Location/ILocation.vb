Imports TGGD.Business

Public Interface ILocation
    Inherits IInventoryEntity
    ReadOnly Property LocationId As Integer
    Property LocationType As String
    ReadOnly Property HasCharacters As Boolean
    ReadOnly Property Characters As IEnumerable(Of ICharacter)
    ReadOnly Property Name As String
    Sub ProcessTurn()
    ReadOnly Property CharacterCount As Integer
End Interface
