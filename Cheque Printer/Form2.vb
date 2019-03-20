Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports Check_Writer.function_class_namespace
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class Form2
    Dim rpt As ReportDocument
    Dim amount_words, amount_words1, company, type, mode, from_date, to_date, sql_cmd As String
    Private GridPrinter As DataGridPrinter

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sql_cmd = "Select Cheque_Date, Voucher_No, Payer_Payee, Mode, Reference_No, Type, CAST(Amount As NUMERIC(20,2)) as Amount, Company from log order by Created_On desc"
        DataGridView1.DataSource = Get_logs(sql_cmd).Tables(0)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Get_amount_words()
        Dim ds As DataSet = New DataSet()
        Dim dt As DataTable = New DataTable("DataTable")
        dt.Columns.Add("date2", GetType(System.String))
        dt.Columns.Add("voucherNo", GetType(System.String))
        dt.Columns.Add("payee", GetType(System.String))
        dt.Columns.Add("amount", GetType(System.String))
        dt.Columns.Add("amountWords", GetType(System.String))
        dt.Columns.Add("amountWords1", GetType(System.String))
        dt.Columns.Add("company", GetType(System.String))
        dt.Columns.Add("mode", GetType(System.String))
        dt.Columns.Add("reference", GetType(System.String))
        dt.Columns.Add("description", GetType(System.String))
        dt.Columns.Add("acpayee", GetType(System.Boolean))
        dt.Columns.Add("bearer", GetType(System.Boolean))
        Dim dr As DataRow = dt.NewRow()
        dr("date2") = DataGridView1.SelectedRows.Item(0).Cells(0).Value.ToString
        dr("voucherNo") = DataGridView1.SelectedRows.Item(0).Cells(1).Value.ToString
        dr("payee") = DataGridView1.SelectedRows.Item(0).Cells(2).Value.ToString
        dr("amount") = DataGridView1.SelectedRows.Item(0).Cells(6).Value.ToString
        dr("amountWords") = amount_words
        dr("amountWords1") = amount_words1
        dr("company") = DataGridView1.SelectedRows.Item(0).Cells(7).Value.ToString
        dr("mode") = DataGridView1.SelectedRows.Item(0).Cells(3).Value.ToString
        dr("reference") = DataGridView1.SelectedRows.Item(0).Cells(4).Value.ToString
        dr("description") = "desc"
        dr("acpayee") = True
        dr("bearer") = True
        dt.Rows.Add(dr)
        ds.Tables.Add(dt)

        If DataGridView1.SelectedRows.Item(0).Cells(5).Value.ToString = "PAYMENT" Then
            rpt = New ReportDocument()
            rpt.Load("PaymentVoucherKings.rpt")
            rpt.SetDataSource(ds)
        Else
            rpt = New ReportDocument()
            rpt.Load("OfficialReceipt.rpt")
            rpt.SetDataSource(ds)
        End If
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.ShowGroupTreeButton = False
    End Sub

    Private Sub DataGridView1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseUp
        If e.Button <> Windows.Forms.MouseButtons.Right Then Return
        Dim cms = New ContextMenuStrip
        Dim item1 = cms.Items.Add("PDF")
        'item1.Tag = 1
        AddHandler item1.Click, AddressOf Print_menuChoice
        Dim item2 = cms.Items.Add("EXCEL")
        'item2.Tag = 2
        AddHandler item2.Click, AddressOf Print_menuChoice
        Dim item3 = cms.Items.Add("PRINT")
        'item3.Tag = 3
        AddHandler item3.Click, AddressOf Print_menuChoice
        cms.Show(DataGridView1, e.Location)
    End Sub

    Private Sub Print_menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        If item.Text = "PDF" Then
            SaveFileDialog1.ShowDialog()
            If SaveFileDialog1.FileName = "" Then
                MsgBox("Enter Filename to create PDF")
                Exit Sub
            Else
                Dim Paragraph As New Paragraph ' declaration for new paragraph
                Dim PdfFile As New Document(PageSize.A4, 40, 40, 40, 20) ' set pdf page size
                PdfFile.AddTitle("FIDS_LOG") ' set our pdf title
                Dim Write As PdfWriter = PdfWriter.GetInstance(PdfFile, New FileStream(SaveFileDialog1.FileName + ".pdf", FileMode.Create))
                PdfFile.Open()

                ' declaration font type
                Dim pTitle As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
                Dim pTable As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

                ' insert title into pdf file
                Paragraph = New Paragraph(New Chunk("Log Data", pTitle))
                Paragraph.Alignment = Element.ALIGN_CENTER
                Paragraph.SpacingAfter = 7.0F

                ' set and add page with current settings
                PdfFile.Add(Paragraph)

                ' create data into table
                Dim PdfTable As New PdfPTable(DataGridView1.Columns.Count)
                ' setting width of table
                PdfTable.TotalWidth = 500.0F
                PdfTable.LockedWidth = True

                Dim widths(0 To DataGridView1.Columns.Count - 1) As Single
                For i As Integer = 0 To DataGridView1.Columns.Count - 1
                    widths(i) = 1.0F
                Next

                PdfTable.SetWidths(widths)
                PdfTable.HorizontalAlignment = 0
                PdfTable.SpacingBefore = 5.0F

                ' declaration pdf cells
                Dim pdfcell As PdfPCell = New PdfPCell

                ' create pdf header
                For i As Integer = 0 To DataGridView1.Columns.Count - 1

                    pdfcell = New PdfPCell(New Phrase(New Chunk(DataGridView1.Columns(i).HeaderText, pTable)))
                    ' alignment header table
                    pdfcell.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                    ' add cells into pdf table
                    PdfTable.AddCell(pdfcell)
                Next

                ' add data into pdf table
                For i As Integer = 0 To DataGridView1.Rows.Count - 2

                    For j As Integer = 0 To DataGridView1.Columns.Count - 1
                        pdfcell = New PdfPCell(New Phrase(DataGridView1(j, i).Value.ToString(), pTable))
                        PdfTable.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                        PdfTable.AddCell(pdfcell)
                    Next
                Next
                ' add pdf table into pdf document
                PdfFile.Add(PdfTable)
                PdfFile.Close() ' close all sessions

                ' show message if hasben exported
                MessageBox.Show("PDF export successfull !", "Informations", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        ElseIf item.Text = "EXCEL" Then
            Dim MyForm1 As New Form3
            MyForm1.DataGridView = DataGridView1
            MyForm1.ShowDialog()
        Else
            If GridPrinter Is Nothing Then
                GridPrinter = New DataGridPrinter(DataGridView1)
            End If

            With GridPrinter
                .HeaderText = "Log File"
                .username = "Admin"
                .HeaderHeightPercent = 5
                .FooterHeightPercent = 5
                .InterSectionSpacingPercent = 2
            End With

            With Me.PrintPreviewDialog1
                .Document = GridPrinter.PrintDocument
                If .ShowDialog = DialogResult.OK Then
                    GridPrinter.Print()
                End If
            End With
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sql_cmd = "Select Cheque_Date, Voucher_No, Payer_Payee, Mode, Reference_No, Type, CAST(Amount as NUMERIC(20,2)) as Amount, Company from log"
        If Not type = "ALL" Then
            sql_cmd += " where Type='" + type + "'"
        End If
        If Not mode = "ALL" Then
            If sql_cmd.Contains("where") Then
                sql_cmd += " and Mode='" + mode + "'"
            Else
                sql_cmd += " where Mode='" + mode + "'"
            End If
        End If
        If Not company = "ALL" Then
            If company.Contains("'") And Not company.Contains("''") Then
                company = company.Replace("'", "''")
            End If
            If sql_cmd.Contains("where") Then
                sql_cmd += " and Company='" + company + "'"
            Else
                sql_cmd += " where Company='" + company + "'"
            End If
        End If

        If sql_cmd.Contains("where") Then
            sql_cmd += " and Cheque_Date>='" + from_date + "' and  Cheque_Date<='" + to_date + "'"
        Else
            sql_cmd += " where Cheque_Date>='" + from_date + "' and  Cheque_Date<='" + to_date + "'"
        End If

        sql_cmd += " order by Created_On desc"
        Console.WriteLine(sql_cmd)
        DataGridView1.DataSource = Get_logs(sql_cmd).Tables(0)
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        from_date = DateTimePicker1.Value.Date.ToString("yyyy/MM/dd")
    End Sub
    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        to_date = DateTimePicker2.Value.Date.ToString("yyyy/MM/dd")
    End Sub

    Private Sub Type_cb_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles type_cb.SelectedIndexChanged
        type = type_cb.Text
    End Sub
    Private Sub Type_cb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mode_cb.SelectedIndexChanged
        mode = mode_cb.Text
    End Sub

    Private Sub Company_cb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles company_cb.SelectedIndexChanged
        company = company_cb.Text
    End Sub

    Sub Get_amount_words()
        Dim sgd As String = DataGridView1.SelectedRows.Item(0).Cells(6).Value.ToString
        amount_words = ""
        amount_words1 = ""
        Dim words_currency As String = AmountInWords(sgd)
        Dim words_space As String() = words_currency.Split(New Char() {" "c})
        For Each wrds As String In words_space
            If Not amount_words.Length > 50 Then
                amount_words += wrds + " "
            Else
                amount_words1 += wrds + " "
            End If
        Next

        If amount_words1 IsNot "" Then
            amount_words1 += "Only"
        Else
            amount_words += "Only"
        End If
    End Sub
End Class