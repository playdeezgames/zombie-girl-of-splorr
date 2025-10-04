Public Class WorldData
    Inherits EntityData
    Property Locations As New List(Of LocationData)
    Property RecycledLocations As New HashSet(Of Integer)
    Property Characters As New List(Of CharacterData)
    Property RecycledCharacters As New HashSet(Of Integer)
    Property PlayerFactionId As Integer?
    Property Messages As New List(Of MessageData)
    Property Items As New List(Of ItemData)
    Property RecycledItems As New HashSet(Of Integer)
    Property Generators As New List(Of Dictionary(Of String, Integer))
    Property RecycledGenerators As New HashSet(Of Integer)
    Property ActiveLocations As New HashSet(Of Integer)
    Property Factions As New List(Of FactionData)
    Property RecycledFactions As New HashSet(Of Integer)
End Class
