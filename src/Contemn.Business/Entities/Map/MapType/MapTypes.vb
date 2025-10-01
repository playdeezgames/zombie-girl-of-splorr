Imports System.Runtime.CompilerServices

Friend Module MapTypes
    Friend ReadOnly Descriptors As IReadOnlyDictionary(Of String, MapTypeDescriptor) =
        New List(Of MapTypeDescriptor) From
        {
            New OverworldMapTypeDescriptor()
        }.ToDictionary(Function(x) x.MapType, Function(x) x)
    Friend ReadOnly Property All As IEnumerable(Of String)
        Get
            Return Descriptors.Keys
        End Get
    End Property
    <Extension>
    Function ToMapTypeDescriptor(mapType As String) As MapTypeDescriptor
        Return Descriptors(mapType)
    End Function
End Module
