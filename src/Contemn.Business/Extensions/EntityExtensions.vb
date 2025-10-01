Imports System.Runtime.CompilerServices

Public Module EntityExtensions
    <Extension>
    Friend Sub SetStatisticRange(
                                entity As IEntity,
                                statisticType As String,
                                statisticValue As Integer,
                                statisticMinimum As Integer,
                                statisticMaximum As Integer)
        entity.SetStatisticMinimum(statisticType, statisticMinimum)
        entity.SetStatisticMaximum(statisticType, statisticMaximum)
        entity.SetStatistic(statisticType, statisticValue)
    End Sub
    <Extension>
    Friend Function IsStatisticAtMinimum(entity As IEntity, statisticType As String) As Boolean
        Return entity.GetStatistic(statisticType) = entity.GetStatisticMinimum(statisticType)
    End Function
    <Extension>
    Friend Function IsStatisticAtMaximum(entity As IEntity, statisticType As String) As Boolean
        Return entity.GetStatistic(statisticType) = entity.GetStatisticMaximum(statisticType)
    End Function
End Module
