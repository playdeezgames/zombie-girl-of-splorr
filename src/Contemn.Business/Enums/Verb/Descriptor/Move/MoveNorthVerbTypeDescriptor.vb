Friend Class MoveNorthVerbTypeDescriptor
    Inherits MoveVerbTypeDescriptor

    Public Sub New()
        MyBase.New(NameOf(MoveNorthVerbTypeDescriptor), DirectionType.North)
    End Sub
End Class
