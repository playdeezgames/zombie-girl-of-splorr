Public Class FactionData
    Inherits EntityData
    Property FactionType As String
    Property CharacterIds As New HashSet(Of Integer)
End Class
