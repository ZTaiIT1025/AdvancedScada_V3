
Imports System.Windows.Forms

Public Class GroupByGrid
    Inherits DataGridView
    Protected Overrides Sub OnCellFormatting(ByVal args As DataGridViewCellFormattingEventArgs)
        MyBase.OnCellFormatting(args)
        ' First row always displays
        If args.RowIndex = 0 Then
            Return
        End If
        'If args.RowIndex > 0 And args.ColumnIndex = 0 Then
        '    If Me.Item(0, args.RowIndex - 1).Value = args.Value Then
        '        args.Value = ""
        '    ElseIf args.RowIndex < Me.Rows.Count - 1 Then
        '        Me.Rows(args.RowIndex).DefaultCellStyle.BackColor = Color.Yellow
        '    End If
        'End If
        If IsRepeatedCellValue(args.RowIndex, args.ColumnIndex) Then
            If args.ColumnIndex = 1 Then
                args.Value = String.Empty
                args.FormattingApplied = True
            End If

        End If
    End Sub
    Private Function IsRepeatedCellValue(ByVal rowIndex As Integer, ByVal colIndex As Integer) As Boolean
        Dim currCell As DataGridViewCell = Rows(rowIndex).Cells(colIndex)
        Dim prevCell As DataGridViewCell = Rows(rowIndex - 1).Cells(colIndex)
        If (currCell.Value Is prevCell.Value) OrElse (currCell.Value IsNot Nothing AndAlso prevCell.Value IsNot Nothing AndAlso currCell.Value.ToString() = prevCell.Value.ToString()) Then
            Return True
        Else
            Return False
        End If
    End Function
    Protected Overrides Sub OnCellPainting(ByVal args As DataGridViewCellPaintingEventArgs)
        MyBase.OnCellPainting(args)
        args.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None
        ' Ignore column and row headers and first row
        If args.RowIndex < 1 OrElse args.ColumnIndex < 0 Then
            Return
        End If



        If IsRepeatedCellValue(args.RowIndex, args.ColumnIndex) Then
            args.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None
        Else
            args.AdvancedBorderStyle.Top = AdvancedCellBorderStyle.Top
        End If
    End Sub
End Class
