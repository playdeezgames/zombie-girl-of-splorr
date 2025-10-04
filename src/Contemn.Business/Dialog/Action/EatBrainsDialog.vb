Imports TGGD.Business

Friend Class EatBrainsDialog
    Inherits BaseDialog

    Private ReadOnly character As ICharacter

    Public Sub New(character As ICharacter)
        MyBase.New(
            GenerateCaption(character),
            GenerateChoices(character),
            GenerateLines(character))
        Me.character = character
    End Sub

    Private Shared Function GenerateLines(character As ICharacter) As IEnumerable(Of IDialogLine)
        Return {}
    End Function

    Private Shared Function GenerateChoices(character As ICharacter) As IEnumerable(Of IDialogChoice)
        Dim result As New List(Of IDialogChoice) From
            {
                New DialogChoice(NEVER_MIND_CHOICE, NEVER_MIND_TEXT)
            }
        result.AddRange(
            character.OtherCharactersInLocation.
            Where(
                Function(x) x.GetTag(TagType.HasTastyBrains)).
                Select(Function(x) New DialogChoice(x.CharacterId.ToString, x.Name)))
        Return result
    End Function

    Private Shared Function GenerateCaption(character As ICharacter) As String
        Return "Eat Brains of..."
    End Function

    Public Overrides Function Choose(choice As String) As IDialog
        Select Case choice
            Case NEVER_MIND_CHOICE
                Return CancelDialog()
            Case Else
                Return EatBrains(character.World.GetCharacter(CInt(choice)))
        End Select
    End Function

    Private Function EatBrains(target As ICharacter) As IDialog
        target.SetTag(TagType.HasTastyBrains, False)
        Return New OkDialog(
            {
                New DialogLine(MoodType.Info, $"You eat {target.Name}'s brains.")
            },
            EatBrainsDialog.LaunchMenu(character))
    End Function

    Friend Shared Function LaunchMenu(character As ICharacter) As Func(Of IDialog)
        Dim descriptor = NameOf(EatBrainsVerbTypeDescriptor).ToVerbTypeDescriptor
        Return Function() If(
            descriptor.CanPerform(character),
            New EatBrainsDialog(character),
            CharacterActionsDialog.LaunchMenu(character).Invoke())
    End Function

    Public Overrides Function CancelDialog() As IDialog
        Return CharacterActionsDialog.LaunchMenu(character).Invoke()
    End Function
End Class
