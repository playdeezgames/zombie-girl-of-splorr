Imports System.Runtime.CompilerServices

Friend Module DirectionTypes
    Friend ReadOnly Descriptors As IReadOnlyDictionary(Of String, DirectionTypeDescriptor) =
        New List(Of DirectionTypeDescriptor) From
        {
            New DirectionTypeDescriptor(Business.DirectionType.North, "north", 0, -1),
            New DirectionTypeDescriptor(Business.DirectionType.East, "east", 1, 0),
            New DirectionTypeDescriptor(Business.DirectionType.South, "south", 0, 1),
            New DirectionTypeDescriptor(Business.DirectionType.West, "west", -1, 0)
        }.ToDictionary(Function(x) x.DirectionType, Function(x) x)
    Friend ReadOnly Property All As IEnumerable(Of String)
        Get
            Return Descriptors.Keys
        End Get
    End Property
    <Extension>
    Function ToDirectionTypeDescriptor(directionType As String) As DirectionTypeDescriptor
        Return Descriptors(directionType)
    End Function
End Module
