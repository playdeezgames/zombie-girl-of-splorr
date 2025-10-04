Imports TGGD.Business

Friend Class LocationDialog
    Inherits BaseDialog
    ReadOnly location As ILocation
    Shared ReadOnly CHARACTERS_CHOICE As String = NameOf(CHARACTERS_CHOICE)

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
        Return {
            New DialogChoice(NEVER_MIND_CHOICE, NEVER_MIND_TEXT),
            New DialogChoice(CHARACTERS_CHOICE, $"Characters({location.CharacterCount})")
            }
    End Function

    Private Shared Function GenerateCaption(location As ILocation) As String
        Return $"Location: {location.Name}"
    End Function

    Public Overrides Function Choose(choice As String) As IDialog
        Select Case choice
            Case NEVER_MIND_CHOICE
                Return CancelDialog()
            Case CHARACTERS_CHOICE
                Return New LocationCharactersDialog(location)
            Case Else
                Throw New NotImplementedException
        End Select
    End Function

    Public Overrides Function CancelDialog() As IDialog
        Return New FactionDialog(Location.World.PlayerFaction)
    End Function
End Class
