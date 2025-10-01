Imports Contemn.Data
Imports TGGD.Business

Friend Class Generator
    Implements IGenerator
    Private ReadOnly data As WorldData
    Private ReadOnly Property GeneratorId As Integer Implements IGenerator.GeneratorId
    Private ReadOnly Property GeneratorData As Dictionary(Of String, Integer)
        Get
            Return data.Generators(generatorId)
        End Get
    End Property
    Public ReadOnly Property TotalWeight As Integer Implements IGenerator.TotalWeight
        Get
            Return GeneratorData.Values.Sum
        End Get
    End Property
    Public Sub New(data As WorldData, generatorId As Integer)
        Me.data = data
        Me.GeneratorId = generatorId
    End Sub
    Public Function Generate() As String Implements IGenerator.Generate
        Return RNG.FromGenerator(GeneratorData)
    End Function
    Public Sub SetWeight(key As String, weight As Integer) Implements IGenerator.SetWeight
        If weight > 0 Then
            GeneratorData(key) = weight
        Else
            GeneratorData.Remove(key)
        End If
    End Sub
    Public Function GetWeight(key As String) As Integer Implements IGenerator.GetWeight
        Dim weight As Integer
        If GeneratorData.TryGetValue(key, weight) Then
            Return weight
        End If
        Return 0
    End Function

    Public Sub Recycle() Implements IGenerator.Recycle
        GeneratorData.Clear()
        data.RecycledGenerators.Add(GeneratorId)
    End Sub
End Class
