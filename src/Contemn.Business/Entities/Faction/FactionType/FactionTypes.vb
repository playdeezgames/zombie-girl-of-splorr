Imports System.Runtime.CompilerServices

Friend Module FactionTypes
    Friend ReadOnly Descriptors As IReadOnlyDictionary(Of String, FactionTypeDescriptor) =
        New List(Of FactionTypeDescriptor) From
        {
            New ZombieGirlFactionTypeDescriptor(),
            New CuteBoysFactionTypeDescriptor()
        }.ToDictionary(Function(x) x.FactionType, Function(x) x)
    Friend ReadOnly Property All As IEnumerable(Of String)
        Get
            Return Descriptors.Keys
        End Get
    End Property
    <Extension>
    Function ToFactionTypeDescriptor(factionType As String) As FactionTypeDescriptor
        Return Descriptors(factionType)
    End Function
End Module
