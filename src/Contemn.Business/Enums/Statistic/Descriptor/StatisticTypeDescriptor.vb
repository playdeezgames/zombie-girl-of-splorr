Friend MustInherit Class StatisticTypeDescriptor
    ReadOnly Property StatisticType As String
    ReadOnly Property StatisticTypeName As String
    Sub New(statisticType As String, statisticTypeName As String)
        Me.StatisticType = statisticType
        Me.StatisticTypeName = statisticTypeName
    End Sub

    Friend MustOverride Function Format(statisticValue As Integer, statisticMinimum As Integer, statisticMaximum As Integer) As String
End Class
