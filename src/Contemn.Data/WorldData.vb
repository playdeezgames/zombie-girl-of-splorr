Public Class WorldData
    Inherits EntityData
    Property Maps As New List(Of MapData)
    Property RecycledMaps As New HashSet(Of Integer)
    Property Locations As New List(Of LocationData)
    Property RecycledLocations As New HashSet(Of Integer)
    Property Characters As New List(Of CharacterData)
    Property RecycledCharacters As New HashSet(Of Integer)
    Property AvatarCharacterId As Integer?
    Property Messages As New List(Of MessageData)
    Property Items As New List(Of ItemData)
    Property RecycledItems As New HashSet(Of Integer)
    Property Generators As New List(Of Dictionary(Of String, Integer))
    Property RecycledGenerators As New HashSet(Of Integer)
    Property ActiveLocations As New HashSet(Of Integer)
End Class
