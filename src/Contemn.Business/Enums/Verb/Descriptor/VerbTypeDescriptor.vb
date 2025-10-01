Imports TGGD.Business

Friend MustInherit Class VerbTypeDescriptor
    ReadOnly Property VerbCategoryType As String
    ReadOnly Property VerbType As String
    ReadOnly Property VerbTypeName As String
    Sub New(verbType As String, verbCategoryType As String, verbTypeName As String)
        Me.VerbType = verbType
        Me.VerbTypeName = verbTypeName
        Me.VerbCategoryType = verbCategoryType
    End Sub
    MustOverride Function Perform(character As ICharacter) As IDialog
    Overridable Function CanPerform(character As ICharacter) As Boolean
        Return True
    End Function
    Function CanChoose(character As ICharacter) As Boolean
        Return Not String.IsNullOrEmpty(VerbTypeName) AndAlso CanPerform(character)
    End Function
End Class
