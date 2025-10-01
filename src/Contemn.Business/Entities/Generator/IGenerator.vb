Public Interface IGenerator
    ReadOnly Property GeneratorId As Integer
    Function Generate() As String
    Sub SetWeight(key As String, weight As Integer)
    Function GetWeight(key As String) As Integer
    ReadOnly Property TotalWeight As Integer
    Sub Recycle()
End Interface
