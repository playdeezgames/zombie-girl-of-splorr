Imports System.Runtime.CompilerServices
Imports TGGD.Business

Friend Module LocationExtensions
    <Extension>
    Friend Function NextLocation(location As ILocation, direction As String) As ILocation
        Dim descriptor = direction.ToDirectionTypeDescriptor
        Dim nextColumn = descriptor.GetNextColumn(location.Column)
        Dim nextRow = descriptor.GetNextRow(location.Row)
        Return location.Map.GetLocation(nextColumn, nextRow)
    End Function
    <Extension>
    Friend Function HandleBump(location As ILocation, character As ICharacter) As IDialog
        Return location.LocationType.ToLocationTypeDescriptor.OnBump(location, character)
    End Function
    <Extension>
    Friend Sub HandleLeave(location As ILocation, character As ICharacter)
        location.LocationType.ToLocationTypeDescriptor.OnLeave(location, character)
    End Sub
    <Extension>
    Friend Function HandleEnter(location As ILocation, character As ICharacter) As IDialog
        Return location.LocationType.ToLocationTypeDescriptor.OnEnter(location, character)
    End Function
End Module
