Public Interface IInventoryEntity
    Inherits IEntity
    Sub AddItem(item As IItem)
    ReadOnly Property HasItems As Boolean
    ReadOnly Property Items As IEnumerable(Of IItem)
    Sub RemoveItem(item As IItem)
    Function GetCountOfItemType(itemType As String) As Integer
    Function GetItemOfType(itemType As String) As IItem
    Function HasItemsOfType(itemType As String) As Boolean
    Function ItemsOfType(itemType As String) As IEnumerable(Of IItem)
End Interface
