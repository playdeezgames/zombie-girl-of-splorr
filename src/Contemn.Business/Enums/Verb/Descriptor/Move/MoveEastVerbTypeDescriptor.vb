Friend Class MoveEastVerbTypeDescriptor
    Inherits MoveVerbTypeDescriptor

    Public Sub New()
        MyBase.New(NameOf(MoveEastVerbTypeDescriptor), DirectionType.East)
    End Sub
End Class
