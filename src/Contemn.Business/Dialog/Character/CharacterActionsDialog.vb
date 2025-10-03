Imports TGGD.Business

Public Class CharacterActionsDialog
    Inherits BaseDialog

    Private ReadOnly character As ICharacter
    Sub New(character As ICharacter, verbCategoryType As String, caption As String)
        MyBase.New(
            caption,
            GenerateChoices(character, verbCategoryType),
            Array.Empty(Of IDialogLine))
        Me.character = character
    End Sub

    Public Shared Function LaunchMenu(character As ICharacter) As Func(Of IDialog)
        Return Function() New CharacterActionsDialog(character, VerbCategoryType.Action, "Actions...")
    End Function

    Private Shared Function GenerateChoices(character As ICharacter, verbCategoryType As String) As IEnumerable(Of IDialogChoice)
        Dim result As New List(Of IDialogChoice) From {
                New DialogChoice(NEVER_MIND_CHOICE, NEVER_MIND_TEXT)
            }
        For Each verbType In character.AvailableVerbsOfCategory(verbCategoryType)
            Dim descriptor = verbType.ToVerbTypeDescriptor
            result.Add(New DialogChoice(verbType, descriptor.VerbTypeName))
        Next
        Return result
    End Function
    Public Overrides Function Choose(choice As String) As IDialog
        Select Case choice
            Case NEVER_MIND_CHOICE
                Return CancelDialog()
            Case Else
                Return choice.ToVerbTypeDescriptor.Perform(character)
        End Select
    End Function

    Public Overrides Function CancelDialog() As IDialog
        Return New CharacterDialog(character)
    End Function
End Class
