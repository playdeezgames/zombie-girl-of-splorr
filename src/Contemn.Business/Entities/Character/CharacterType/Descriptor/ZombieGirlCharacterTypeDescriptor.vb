Imports TGGD.Business

Friend Class ZombieGirlCharacterTypeDescriptor
    Inherits CharacterTypeDescriptor

    Public Sub New()
        MyBase.New(NameOf(ZombieGirlCharacterTypeDescriptor), 1)
    End Sub

    Friend Overrides Sub OnInitialize(character As ICharacter)
        character.Faction = character.World.Factions.Single(Function(x) x.FactionType = NameOf(ZombieGirlFactionTypeDescriptor))
        character.World.Avatar = character
        character.SetMetadata(MetadataType.Name, "Fumiko Fujimoto")
    End Sub

    Friend Overrides Function OnProcessTurn(character As ICharacter) As IEnumerable(Of IDialogLine)
        Dim result As New List(Of IDialogLine)
        Return result
    End Function

    Friend Overrides Function CanSpawnLocation(location As ILocation) As Boolean
        Return Not location.HasCharacter AndAlso location.LocationType = NameOf(DirtLocationTypeDescriptor)
    End Function

    Friend Overrides Sub HandleAddItem(character As ICharacter, item As IItem)
        item.ItemType.ToItemTypeDescriptor.HandleAddItem(item, character)
    End Sub

    Friend Overrides Sub HandleRemoveItem(character As ICharacter, item As IItem)
        item.ItemType.ToItemTypeDescriptor.HandleRemoveItem(item, character)
    End Sub

    Friend Overrides Function OnInteract(target As ICharacter, initiator As ICharacter) As IDialog
        Throw New NotImplementedException()
    End Function

    Friend Overrides Function OnNavigate(character As Character) As IDialog
        Return New FactionDialog(character.Faction)
    End Function

    Friend Overrides Function GetName(character As Character) As String
        Return character.GetMetadata(MetadataType.Name)
    End Function
End Class
