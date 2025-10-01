Public Interface IEntity
    Sub PlaySfx(sfx As String)
    Sub Clear()
    Sub Recycle()
    Sub Initialize()
    ReadOnly Property World As IWorld
    Sub SetStatistic(statisticType As String, statisticValue As Integer?)
    Function GetStatistic(statisticType As String) As Integer
    Function HasStatistic(statisticType As String) As Boolean
    Sub SetStatisticMaximum(statisticType As String, statisticMaximum As Integer?)
    Sub SetStatisticMinimum(statisticType As String, statisticMinimum As Integer?)
    Function GetStatisticMaximum(statisticType As String) As Integer
    Function GetStatisticMinimum(statisticType As String) As Integer
    Sub SetMetadata(metadataType As String, metadataValue As String)
    Function GetMetadata(metadataType As String) As String
    Function HasMetadata(metadataType As String) As Boolean
    Sub SetTag(tagType As String, value As Boolean)
    Function GetTag(tagType As String) As Boolean
    Function FormatStatistic(statisticType As String) As String
    Function ChangeStatistic(statisticType As String, delta As Integer) As Integer
End Interface
