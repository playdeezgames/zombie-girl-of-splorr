Imports System.Runtime.CompilerServices

Friend Module RecipeTypes
    Friend ReadOnly Descriptors As IReadOnlyDictionary(Of String, RecipeTypeDescriptor) =
        New List(Of RecipeTypeDescriptor) From
        {
        }.ToDictionary(
            Function(x) x.RecipeType,
            Function(x) x)
    Friend ReadOnly Property All As IEnumerable(Of String)
        Get
            Return Descriptors.Keys
        End Get
    End Property
    <Extension>
    Function ToRecipeTypeDescriptor(recipeType As String) As RecipeTypeDescriptor
        Return Descriptors(recipeType)
    End Function
End Module
