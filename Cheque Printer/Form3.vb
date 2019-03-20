
Imports Excel = Microsoft.Office.Interop.Excel

Public Class Form3

    Public DataGridView As DataGridView
    Dim ExcelApp As Excel.Application
    Dim ExcelWorkBk As Excel.Workbook
    Dim ExcelWorkSht As Excel.Worksheet
    Dim i, j As Integer
    Dim str As String

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Label1.Visible = False
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Label1.Visible = True
        ExcelApp = New Excel.Application
        ExcelWorkBk = ExcelApp.Workbooks.Add()
        ExcelWorkSht = ExcelWorkBk.Sheets("Sheet1")

        'Export Header Names Start
        Dim columnsCount As Integer = DataGridView.Columns.Count

        'For Each column In dgvOrderNonShipped.Columns
        'ExcelWorkSht.Cells(1, column.Index + 1) = column.HeaderText
        'Next
        'Export the data from the datagrid to an excel spreadsheet
        For i = 0 To DataGridView.RowCount - 1
            ProgressBar1.Maximum = DataGridView.RowCount - 1
            For j = 0 To DataGridView.ColumnCount - 1
                For k As Integer = 1 To DataGridView.Columns.Count
                    ExcelWorkSht.Cells(1, k) = DataGridView.Columns(k - 1).HeaderText
                    ExcelWorkSht.Cells(i + 1, j + 1) = DataGridView(j, i).Value
                Next
            Next
            ProgressBar1.PerformStep()
        Next

        With ExcelApp
            .Visible = True
            .Columns.AutoFit()
            .Rows("1:1").Font.FontStyle = "Bold"
            .Rows("1:1").Font.Size = 11
            .Cells.Select()
            .Cells.EntireColumn.AutoFit()
            .Cells(1, 1).Select()
        End With

        Me.Close()
    End Sub

End Class