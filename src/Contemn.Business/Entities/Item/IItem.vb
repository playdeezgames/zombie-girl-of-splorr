Imports TGGD.Business

Public Interface IItem
    Inherits IEntity
    ReadOnly Property ItemId As Integer
    ReadOnly Property ItemType As String
    ReadOnly Property Name As String
    Function GetAvailableChoices(character As ICharacter) As IEnumerable(Of IDialogChoice)
    Function MakeChoice(character As ICharacter, choice As String) As IDialog
    Function Describe() As IEnumerable(Of IDialogLine)
End Interface
