Imports Contemn.Data

Friend MustInherit Class InventoryEntity(Of TEntityData As InventoryEntityData)
    Inherits Entity(Of TEntityData)
    Implements IInventoryEntity

    Protected Sub New(data As WorldData, playSfx As Action(Of String))
        MyBase.New(data, playSfx)
    End Sub

    Public ReadOnly Property HasItems As Boolean Implements IInventoryEntity.HasItems
        Get
            Return EntityData.ItemIds.Any
        End Get
    End Property

    Public ReadOnly Property Items As IEnumerable(Of IItem) Implements IInventoryEntity.Items
        Get
            Return EntityData.ItemIds.Select(Function(x) World.GetItem(x))
        End Get
    End Property

    Public Sub AddItem(item As IItem) Implements IInventoryEntity.AddItem
        EntityData.ItemIds.Add(item.ItemId)
        HandleAddItem(item)
    End Sub

    Protected MustOverride Sub HandleAddItem(item As IItem)

    Public Sub RemoveItem(item As IItem) Implements IInventoryEntity.RemoveItem
        HandleRemoveItem(item)
        EntityData.ItemIds.Remove(item.ItemId)
    End Sub

    Protected MustOverride Sub HandleRemoveItem(item As IItem)

    Public Function GetCountOfItemType(itemType As String) As Integer Implements IInventoryEntity.GetCountOfItemType
        Return Items.Count(Function(x) x.ItemType = itemType)
    End Function

    Public Function GetItemOfType(itemType As String) As IItem Implements IInventoryEntity.GetItemOfType
        Return Items.First(Function(x) x.ItemType = itemType)
    End Function

    Public Function HasItemsOfType(itemType As String) As Boolean Implements IInventoryEntity.HasItemsOfType
        Return Items.Any(Function(x) x.ItemType = itemType)
    End Function

    Public Function ItemsOfType(itemType As String) As IEnumerable(Of IItem) Implements IInventoryEntity.ItemsOfType
        Return Items.Where(Function(x) x.ItemType = itemType)
    End Function

    Public Overrides Sub Clear()
        MyBase.Clear()
        EntityData.ItemIds.Clear()
    End Sub
End Class
