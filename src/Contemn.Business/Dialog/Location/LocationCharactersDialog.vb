Imports TGGD.Business

Friend Class LocationCharactersDialog
    Inherits BaseDialog

    Private ReadOnly location As ILocation

    Public Sub New(location As ILocation)
        MyBase.New(
            GenerateCaption(location),
            GenerateChoices(location),
            GenerateLines(location))
        Me.location = location
    End Sub

    Private Shared Function GenerateLines(location As ILocation) As IEnumerable(Of IDialogLine)
        Return Array.Empty(Of IDialogLine)
    End Function

    Private Shared Function GenerateChoices(location As ILocation) As IEnumerable(Of IDialogChoice)
        Dim result As New List(Of IDialogChoice) From {
            New DialogChoice(NEVER_MIND_CHOICE, NEVER_MIND_TEXT)
            }
        result.AddRange(location.Characters.Select(Function(x) New DialogChoice(x.CharacterId.ToString, x.Name)))
        Return result
    End Function

    Private Shared Function GenerateCaption(location As ILocation) As String
        Return $"Characters in {location.Name}"
    End Function

    Public Overrides Function Choose(choice As String) As IDialog
        Select Case choice
            Case NEVER_MIND_CHOICE
                Return CancelDialog()
            Case Else
                Return New CharacterDialog(location.World.GetCharacter(CInt(choice)))
        End Select
    End Function

    Public Overrides Function CancelDialog() As IDialog
        Return New LocationDialog(location)
    End Function
End Class
