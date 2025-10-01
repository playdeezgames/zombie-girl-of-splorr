Public Interface IUIBuffer(Of THue)
    Sub SetPixel(column As Integer, row As Integer, hue As THue)
    Function GetPixel(column As Integer, row As Integer) As THue
    Sub Fill(column As Integer, row As Integer, columns As Integer, rows As Integer, hue As THue)
    Sub Fill(hue As THue)
    ReadOnly Property Columns As Integer
    ReadOnly Property Rows As Integer
End Interface
