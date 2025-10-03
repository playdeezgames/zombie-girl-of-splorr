Public Interface IFaction
    Inherits IEntity
    ReadOnly Property FactionId As Integer
    ReadOnly Property FactionType As String
    ReadOnly Property Name As String
    Sub AddCharacter(character As ICharacter)
    Sub RemoveCharacter(character As ICharacter)
    ReadOnly Property HasCharacters As Boolean
    ReadOnly Property CharacterCount As Integer
    ReadOnly Property Characters As IEnumerable(Of ICharacter)
End Interface
