Imports TGGD.Business

Friend Class ZombieGirlCharacterTypeDescriptor
    Inherits CharacterTypeDescriptor

    Public Sub New()
        MyBase.New(NameOf(ZombieGirlCharacterTypeDescriptor), 1)
    End Sub

    Friend Overrides Sub OnInitialize(character As ICharacter)
        character.Faction = character.World.Factions.Single(Function(x) x.FactionType = NameOf(ZombieGirlFactionTypeDescriptor))
        character.World.Avatar = character
    End Sub

    Friend Overrides Function OnBump(character As ICharacter, location As ILocation) As IDialog
        Return location.HandleBump(character)
    End Function

    Friend Overrides Sub OnEnter(character As ICharacter, location As ILocation)
        For Each line In character.World.ProcessTurn()
            character.World.AddMessage(line.Mood, line.Text)
        Next
        Dim items = location.Items
        For Each item In items
            location.RemoveItem(item)
            character.World.AddMessage(MoodType.Info, $"You pick up {item.Name}.")
            character.AddItem(item)
        Next
    End Sub

    Friend Overrides Function OnProcessTurn(character As ICharacter) As IEnumerable(Of IDialogLine)
        Dim result As New List(Of IDialogLine)
        Return result
    End Function

    Friend Overrides Sub OnLeave(character As ICharacter, location As ILocation)
    End Sub

    Friend Overrides Function CanSpawnMap(map As IMap) As Boolean
        Return True
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
        Return New NavigationDialog(character)
    End Function
End Class
