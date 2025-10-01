Imports TGGD.Business

Friend MustInherit Class LocationTypeDescriptor
    Friend ReadOnly Property LocationType As String
    Friend ReadOnly Property LocationTypeName As String
    Sub New(locationType As String, locationTypeName As String)
        Me.LocationType = locationType
        Me.LocationTypeName = locationTypeName
    End Sub

    Friend MustOverride Function OnBump(location As ILocation, character As ICharacter) As IDialog
    Friend MustOverride Sub OnLeave(location As ILocation, character As ICharacter)
    Friend MustOverride Function OnEnter(location As ILocation, character As ICharacter) As IDialog
    Friend MustOverride Function CanEnter(location As ILocation, character As ICharacter) As Boolean
    Friend MustOverride Function CanSpawn(location As ILocation, itemType As String) As Boolean
    Friend MustOverride Sub OnInitialize(location As Location)
    Friend Overridable Function GetName(location As Location) As String
        Return LocationTypeName
    End Function

    Friend MustOverride Sub OnProcessTurn(location As Location)
    Friend Overridable Function GenerateBumpLines(location As Location, character As ICharacter) As IEnumerable(Of IDialogLine)
        Return Array.Empty(Of IDialogLine)
    End Function
End Class
