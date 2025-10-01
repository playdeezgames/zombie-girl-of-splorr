Imports System
Imports System.Drawing

Module Program
    Const InputFilename = "romfont8x8.png"
    Const OutputFilename = "output.png"
    Const CellWidth = 8
    Const CellHeight = 8
    ReadOnly Palette As Color() =
        {
            Color.FromArgb(0, 0, 0),
            Color.FromArgb(0, 0, 170),
            Color.FromArgb(0, 170, 0),
            Color.FromArgb(0, 170, 170),
            Color.FromArgb(170, 0, 0),
            Color.FromArgb(170, 0, 170),
            Color.FromArgb(170, 85, 0),
            Color.FromArgb(170, 170, 170),
            Color.FromArgb(85, 85, 85),
            Color.FromArgb(85, 85, 255),
            Color.FromArgb(85, 255, 85),
            Color.FromArgb(85, 255, 255),
            Color.FromArgb(255, 85, 85),
            Color.FromArgb(255, 85, 255),
            Color.FromArgb(255, 255, 85),
            Color.FromArgb(255, 255, 255)
        }
    Sub Main(args As String())
        Dim sourceBmp As New Bitmap(InputFilename)
        Dim sourceCellColumns = sourceBmp.Width \ CellWidth
        Dim sourceCellRows = sourceBmp.Height \ CellHeight
        Dim destinationCellColumns = sourceCellColumns * sourceCellRows
        Dim destinationCellRows = Palette.Length * Palette.Length
        Dim destinationBmp As New Bitmap(CellWidth * destinationCellColumns, CellHeight * destinationCellRows)
        For Each destinationColumn In Enumerable.Range(0, destinationCellColumns)
            Dim sourceCellColumn = destinationColumn Mod sourceCellColumns
            Dim sourceCellRow = destinationColumn \ sourceCellColumns
            Dim destinationX = destinationColumn * CellWidth
            Dim sourceX = sourceCellColumn * CellWidth
            Dim sourceY = sourceCellRow * CellHeight
            For Each x In Enumerable.Range(0, CellWidth)
                For Each y In Enumerable.Range(0, CellHeight)
                    Dim sourcePixel = sourceBmp.GetPixel(x + sourceX, y + sourceY)
                    For Each destinationRow In Enumerable.Range(0, destinationCellRows)
                        Dim foregroundColor = Palette(destinationRow Mod Palette.Length)
                        Dim backgroundColor = Palette(destinationRow \ Palette.Length)
                        Dim destinationPixel = If(sourcePixel.R > 0, foregroundColor, backgroundColor)
                        Dim destinationY = destinationRow * CellHeight
                        destinationBmp.SetPixel(destinationX + x, destinationY + y, destinationPixel)
                    Next
                Next
            Next
        Next
        destinationBmp.Save(OutputFilename)
    End Sub
End Module
