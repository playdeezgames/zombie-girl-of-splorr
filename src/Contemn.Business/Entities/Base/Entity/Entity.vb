Imports Contemn.Data

Public MustInherit Class Entity(Of TEntityData As EntityData)
    Implements IEntity

    Private ReadOnly Property _playSfx As Action(Of String)
    Protected ReadOnly Data As WorldData
    Protected MustOverride ReadOnly Property EntityData As TEntityData

    Public ReadOnly Property World As IWorld Implements IEntity.World
        Get
            Return New World(Data, _playSfx)
        End Get
    End Property

    Sub New(data As WorldData, playSfx As Action(Of String))
        Me.Data = data
        Me._playSfx = playSfx
    End Sub
    Public Overridable Sub Clear() Implements IEntity.Clear
        EntityData.Statistics.Clear()
        EntityData.StatisticMaximums.Clear()
        EntityData.StatisticMinimums.Clear()
        EntityData.Metadatas.Clear()
        EntityData.Tags.Clear()
    End Sub

    Public Overridable Sub Initialize() Implements IEntity.Initialize
    End Sub

    Public Sub SetStatistic(statisticType As String, statisticValue As Integer?) Implements IEntity.SetStatistic
        If statisticValue.HasValue Then
            EntityData.Statistics(statisticType) = statisticValue.Value
        Else
            EntityData.Statistics.Remove(statisticType)
        End If
    End Sub

    Public Function GetStatistic(statisticType As String) As Integer Implements IEntity.GetStatistic
        Return Math.Clamp(EntityData.Statistics(statisticType), GetStatisticMinimum(statisticType), GetStatisticMaximum(statisticType))
    End Function

    Public Sub SetMetadata(metadataType As String, metadataValue As String) Implements IEntity.SetMetadata
        If metadataValue IsNot Nothing Then
            EntityData.Metadatas(metadataType) = metadataValue
        Else
            EntityData.Metadatas.Remove(metadataType)
        End If
    End Sub

    Public Function GetMetadata(metadataType As String) As String Implements IEntity.GetMetadata
        Dim result As String = Nothing
        If EntityData.Metadatas.TryGetValue(metadataType, result) Then
            Return result
        End If
        Return Nothing
    End Function

    Public Sub SetTag(tagType As String, value As Boolean) Implements IEntity.SetTag
        If value Then
            EntityData.Tags.Add(tagType)
        Else
            EntityData.Tags.Remove(tagType)
        End If
    End Sub

    Public Function GetTag(tagType As String) As Boolean Implements IEntity.GetTag
        Return EntityData.Tags.Contains(tagType)
    End Function

    Public Sub SetStatisticMaximum(statisticType As String, statisticMaximum As Integer?) Implements IEntity.SetStatisticMaximum
        If statisticMaximum.HasValue Then
            EntityData.StatisticMaximums(statisticType) = statisticMaximum.Value
        Else
            EntityData.StatisticMaximums.Remove(statisticType)
        End If
    End Sub

    Public Sub SetStatisticMinimum(statisticType As String, statisticMinimum As Integer?) Implements IEntity.SetStatisticMinimum
        If statisticMinimum.HasValue Then
            EntityData.StatisticMinimums(statisticType) = statisticMinimum.Value
        Else
            EntityData.StatisticMinimums.Remove(statisticType)
        End If
    End Sub

    Public Function GetStatisticMaximum(statisticType As String) As Integer Implements IEntity.GetStatisticMaximum
        Dim result As Integer
        If EntityData.StatisticMaximums.TryGetValue(statisticType, result) Then
            Return result
        End If
        Return Integer.MaxValue
    End Function

    Public Function GetStatisticMinimum(statisticType As String) As Integer Implements IEntity.GetStatisticMinimum
        Dim result As Integer
        If EntityData.StatisticMinimums.TryGetValue(statisticType, result) Then
            Return result
        End If
        Return Integer.MinValue
    End Function

    Public Function FormatStatistic(statisticType As String) As String Implements IEntity.FormatStatistic
        Return statisticType.ToStatisticTypeDescriptor().Format(
            GetStatistic(statisticType),
            GetStatisticMinimum(statisticType),
            GetStatisticMaximum(statisticType))
    End Function

    Public Function ChangeStatistic(statisticType As String, delta As Integer) As Integer Implements IEntity.ChangeStatistic
        SetStatistic(statisticType, GetStatistic(statisticType) + delta)
        Return GetStatistic(statisticType)
    End Function

    Public MustOverride Sub Recycle() Implements IEntity.Recycle

    Public Sub PlaySfx(sfx As String) Implements IEntity.PlaySfx
        _playSfx.Invoke(sfx)
    End Sub

    Public Function HasMetadata(metadataType As String) As Boolean Implements IEntity.HasMetadata
        Return EntityData.Metadatas.ContainsKey(metadataType)
    End Function

    Public Function HasStatistic(statisticType As String) As Boolean Implements IEntity.HasStatistic
        Return EntityData.Statistics.ContainsKey(statisticType)
    End Function
End Class
