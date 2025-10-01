Imports System.Runtime.CompilerServices
Imports TGGD.Business

Friend Module CharacterExtensions
    <Extension>
    Friend Function HandleBump(character As ICharacter, location As ILocation) As IDialog
        character.SetBumpLocation(location)
        Dim result = character.CharacterType.ToCharacterTypeDescriptor.OnBump(character, location)
        Return result
    End Function
    <Extension>
    Friend Sub SetBumpLocation(character As ICharacter, location As ILocation)
        character.SetStatistic(StatisticType.BumpLocationId, location?.LocationId)
    End Sub
    <Extension>
    Friend Sub RemoveAndRecycleItem(character As ICharacter, item As IItem)
        character.RemoveItem(item)
        item.Recycle()
    End Sub
    <Extension>
    Friend Function GetBumpLocation(character As ICharacter) As ILocation
        If Not character.HasStatistic(StatisticType.BumpLocationId) Then
            Return Nothing
        End If
        Return character.World.GetLocation(character.GetStatistic(StatisticType.BumpLocationId))
    End Function
    <Extension>
    Friend Sub HandleLeave(character As ICharacter, location As ILocation)
        character.CharacterType.ToCharacterTypeDescriptor.OnLeave(character, location)
    End Sub
    <Extension>
    Friend Sub HandleEnter(character As ICharacter, location As ILocation)
        character.CharacterType.ToCharacterTypeDescriptor.OnEnter(character, location)
    End Sub
End Module
