Imports System.Runtime.CompilerServices
Imports TGGD.Business

Friend Module CharacterExtensions
    <Extension>
    Friend Sub RemoveAndRecycleItem(character As ICharacter, item As IItem)
        character.RemoveItem(item)
        item.Recycle()
    End Sub
End Module
