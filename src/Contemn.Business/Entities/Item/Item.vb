Imports Contemn.Data
Imports TGGD.Business

Friend Class Item
    Inherits Entity(Of ItemData)
    Implements IItem

    Public Sub New(
                  data As WorldData,
                  itemId As Integer,
                  playSfx As Action(Of String))
        MyBase.New(data, playSfx)
        Me.ItemId = itemId
    End Sub

    Public ReadOnly Property ItemId As Integer Implements IItem.ItemId

    Public ReadOnly Property ItemType As String Implements IItem.ItemType
        Get
            Return EntityData.ItemType
        End Get
    End Property

    Public ReadOnly Property Name As String Implements IItem.Name
        Get
            Return ItemType.ToItemTypeDescriptor.GetName(Me)
        End Get
    End Property

    Protected Overrides ReadOnly Property EntityData As ItemData
        Get
            Return Data.Items(ItemId)
        End Get
    End Property

    Public Overrides Sub Recycle()
        Clear()
        Data.RecycledItems.Add(ItemId)
    End Sub

    Public Function GetAvailableChoices(character As ICharacter) As IEnumerable(Of IDialogChoice) Implements IItem.GetAvailableChoices
        Return ItemType.ToItemTypeDescriptor.GetAvailableChoices(Me, character)
    End Function

    Public Overrides Sub Initialize()
        MyBase.Initialize()
        ItemType.ToItemTypeDescriptor.HandleInitialize(Me)
    End Sub

    Public Function MakeChoice(character As ICharacter, choice As String) As IDialog Implements IItem.MakeChoice
        Return ItemType.ToItemTypeDescriptor.Choose(Me, character, choice)
    End Function

    Public Function Describe() As IEnumerable(Of IDialogLine) Implements IItem.Describe
        Return ItemType.ToItemTypeDescriptor.Describe(Me)
    End Function

    Public Overrides Sub Clear()
        MyBase.Clear()
        EntityData.ItemType = Nothing
    End Sub
End Class
