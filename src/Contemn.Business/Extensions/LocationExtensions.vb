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
End Module
