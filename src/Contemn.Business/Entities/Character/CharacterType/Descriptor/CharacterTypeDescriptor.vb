Imports TGGD.Business

Friend MustInherit Class CharacterTypeDescriptor
    ReadOnly Property CharacterType As String
    ReadOnly Property CharacterCount As Integer
    Sub New(characterType As String, characterCount As Integer)
        Me.CharacterType = characterType
        Me.CharacterCount = characterCount
    End Sub
    Friend MustOverride Function CanSpawnMap(map As IMap) As Boolean
    Friend MustOverride Function CanSpawnLocation(location As ILocation) As Boolean
    Friend MustOverride Sub OnInitialize(character As ICharacter)
    Friend MustOverride Function OnBump(character As ICharacter, location As ILocation) As IDialog
    Friend MustOverride Sub OnEnter(character As ICharacter, location As ILocation)
    Friend MustOverride Sub OnLeave(character As ICharacter, location As ILocation)
    Friend MustOverride Sub HandleAddItem(character As ICharacter, item As IItem)
    Friend MustOverride Sub HandleRemoveItem(character As ICharacter, item As IItem)
    Friend MustOverride Function OnInteract(target As ICharacter, initiator As ICharacter) As IDialog
    Friend MustOverride Function OnProcessTurn(character As ICharacter) As IEnumerable(Of IDialogLine)
    Friend MustOverride Function OnNavigate(character As Character) As IDialog
    Friend MustOverride Function GetName(character As Character) As String
End Class
