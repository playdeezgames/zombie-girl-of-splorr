Imports TGGD.Business

Friend MustInherit Class MoveVerbTypeDescriptor
    Inherits VerbTypeDescriptor
    ReadOnly directionType As String
    Public Sub New(verbType As String, directionType As String)
        MyBase.New(verbType, Business.VerbCategoryType.Move, directionType)
        Me.directionType = directionType
    End Sub

    Public Overrides Function Perform(character As ICharacter) As IDialog
        Dim descriptor = directionType.ToDirectionTypeDescriptor
        Dim nextColumn = descriptor.GetNextColumn(character.Column)
        Dim nextRow = descriptor.GetNextRow(character.Row)
        Dim nextLocation = character.Map.GetLocation(nextColumn, nextRow)
        If nextLocation IsNot Nothing Then
            Return character.MoveTo(nextLocation)
        End If
        Return Nothing
    End Function

    Public Overrides Function CanPerform(character As ICharacter) As Boolean
        Return MyBase.CanPerform(character)
    End Function
End Class
