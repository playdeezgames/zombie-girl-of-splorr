Imports System.Runtime.CompilerServices

Friend Module LocationTypes
    Friend ReadOnly Descriptors As IReadOnlyDictionary(Of String, LocationTypeDescriptor) =
        New List(Of LocationTypeDescriptor) From
        {
            New DirtLocationTypeDescriptor()
        }.ToDictionary(Function(x) x.LocationType, Function(x) x)
    Friend ReadOnly Property All As IEnumerable(Of String)
        Get
            Return Descriptors.Keys
        End Get
    End Property
    <Extension>
    Function ToLocationTypeDescriptor(locationType As String) As LocationTypeDescriptor
        Return Descriptors(locationType)
    End Function
End Module
