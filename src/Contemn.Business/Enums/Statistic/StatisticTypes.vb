Imports System.Runtime.CompilerServices

Friend Module StatisticTypes
    Friend ReadOnly Descriptors As IReadOnlyDictionary(Of String, StatisticTypeDescriptor) =
        New List(Of StatisticTypeDescriptor) From
        {
        }.ToDictionary(Function(x) x.StatisticType, Function(x) x)
    Friend ReadOnly Property All As IEnumerable(Of String)
        Get
            Return Descriptors.Keys
        End Get
    End Property
    <Extension>
    Function ToStatisticTypeDescriptor(statisticType As String) As StatisticTypeDescriptor
        Return Descriptors(statisticType)
    End Function
End Module
