Imports System.Runtime.CompilerServices

Module CharacterTypes
    Friend ReadOnly Descriptors As IReadOnlyDictionary(Of String, CharacterTypeDescriptor) =
        New List(Of CharacterTypeDescriptor) From
        {
            New N00bCharacterTypeDescriptor()
        }.ToDictionary(Function(x) x.CharacterType, Function(x) x)
    Friend ReadOnly Property All As IEnumerable(Of String)
        Get
            Return Descriptors.Keys
        End Get
    End Property
    <Extension>
    Function ToCharacterTypeDescriptor(characterType As String) As CharacterTypeDescriptor
        Return Descriptors(characterType)
    End Function
End Module
