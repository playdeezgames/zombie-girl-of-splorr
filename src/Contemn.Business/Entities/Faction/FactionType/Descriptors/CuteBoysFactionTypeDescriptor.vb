Friend Class CuteBoysFactionTypeDescriptor
    Inherits FactionTypeDescriptor

    Public Sub New()
        MyBase.New(NameOf(CuteBoysFactionTypeDescriptor), 1)
    End Sub

    Friend Overrides Function GetName(faction As IFaction) As String
        Return "Cute Boys"
    End Function
End Class
