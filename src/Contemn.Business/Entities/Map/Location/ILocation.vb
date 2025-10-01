Imports TGGD.Business

Public Interface ILocation
    Inherits IInventoryEntity
    ReadOnly Property LocationId As Integer
    Property LocationType As String
    ReadOnly Property Column As Integer
    ReadOnly Property Row As Integer
    ReadOnly Property Map As IMap
    ReadOnly Property HasCharacter As Boolean
    ReadOnly Property Character As ICharacter
    ReadOnly Property Name As String
    Sub ProcessTurn()
    Function GenerateBumpLines(character As ICharacter) As IEnumerable(Of IDialogLine)
End Interface
