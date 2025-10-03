Imports TGGD.Business

Public Interface ILocation
    Inherits IInventoryEntity
    ReadOnly Property LocationId As Integer
    Property LocationType As String
    ReadOnly Property HasCharacter As Boolean
    ReadOnly Property Character As ICharacter
    ReadOnly Property Name As String
    Sub ProcessTurn()
End Interface
