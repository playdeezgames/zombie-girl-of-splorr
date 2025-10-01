Public Class UIBuffer(Of THue)
    Implements IUIBuffer(Of THue)

    Private ReadOnly pixelBuffer As THue()

    Sub New(columns As Integer, rows As Integer, pixelBuffer As THue())
        Me.Columns = columns
        Me.Rows = rows
        Me.pixelBuffer = pixelBuffer
    End Sub

    Public ReadOnly Property Columns As Integer Implements IUIBuffer(Of THue).Columns

    Public ReadOnly Property Rows As Integer Implements IUIBuffer(Of THue).Rows

    Public Sub SetPixel(column As Integer, row As Integer, hue As THue) Implements IUIBuffer(Of THue).SetPixel
        If column >= 0 AndAlso column < Columns AndAlso row >= 0 AndAlso row < Rows Then
            pixelBuffer(column + row * Columns) = hue
        End If
    End Sub

    Public Sub Fill(column As Integer, row As Integer, columns As Integer, rows As Integer, hue As THue) Implements IUIBuffer(Of THue).Fill
        For Each y In Enumerable.Range(row, rows)
            For Each x In Enumerable.Range(column, columns)
                SetPixel(x, y, hue)
            Next
        Next
    End Sub

    Public Sub Fill(hue As THue) Implements IUIBuffer(Of THue).Fill
        Fill(0, 0, Columns, Rows, hue)
    End Sub

    Public Function GetPixel(column As Integer, row As Integer) As THue Implements IUIBuffer(Of THue).GetPixel
        If column >= 0 AndAlso column < Columns AndAlso row >= 0 AndAlso row < Rows Then
            Return pixelBuffer(column + row * Columns)
        End If
        Return CType(Nothing, THue)
    End Function
End Class
