Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Check_Writer.function_class_namespace

Public Class Form1

    Dim paye, day1, day2, mon1, mon2, year1, year2, sgd, amount_words, amount_words1, date_vou, comp, ref_no, desc, mode, menu_str, sql_cmd As String
    Dim voucher_no, date_vou_db As String
    Dim rpt, rpt2, rpt3 As ReportDocument
    Dim acpayee As Boolean = True
    Dim pay_mode, receipt_mode As Boolean

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim MyForm As New Form2
        MyForm.ShowDialog()
    End Sub

    Dim bearer As Boolean = True


    Private Sub Menu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles menu.SelectedIndexChanged
        ToolTip_menu.RemoveAll()
        menu_str = menu.Text
        If menu_str = "PAYMENT" Then
            pay_mode = True
            receipt_mode = False
        Else
            pay_mode = False
            receipt_mode = True
        End If
    End Sub

    Private Sub Mode_cb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mode_cb.SelectedIndexChanged
        ToolTip_mode.RemoveAll()
        mode = mode_cb.Text
    End Sub

    Private Sub Payee_TextChanged(sender As Object, e As EventArgs) Handles payee.TextChanged
        ToolTip_payee.RemoveAll()
    End Sub

    Private Sub Reff_TextChanged(sender As Object, e As EventArgs) Handles reff.TextChanged
        ToolTip_ref.RemoveAll()
        Dim digitsOnly As Regex = New Regex("[^\d]")
        reff.Text = digitsOnly.Replace(reff.Text, "")
    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles close.Click
        Application.Exit()
    End Sub

    Private Sub Amount_TextChanged(sender As Object, e As EventArgs) Handles amount.TextChanged
        sgd = amount.Text
        words1.Text = ""
        words.Text = ""
        amount_words = ""
        amount_words1 = ""
        Dim words_currency As String = AmountInWords(sgd)
        Dim words_space As String() = words_currency.Split(New Char() {" "c})
        For Each wrds As String In words_space
            If Not words.Text.Length > 50 Then
                words.AppendText(wrds + " ")
                amount_words += wrds + " "
            Else
                words1.AppendText(wrds + " ")
                amount_words1 += wrds + " "
            End If
        Next

        If amount_words1 IsNot "" Then
            amount_words1 += "Only"
            words1.AppendText("Only")
        Else
            amount_words += "Only"
            words.AppendText("Only")
        End If

        ToolTip_amount.RemoveAll()
    End Sub

    Private Sub amount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles amount.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not e.KeyChar = "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub Bearer_cb_CheckedChanged(sender As Object, e As EventArgs) Handles bearer_cb.CheckedChanged
        If bearer_cb.Checked Then
            bearer = True
            bearer_x.Visible = True
        Else
            bearer = False
            bearer_x.Visible = False
        End If
    End Sub

    Private Sub Acpayee_cb_CheckedChanged(sender As Object, e As EventArgs) Handles acpayee_cb.CheckedChanged
        If acpayee_cb.Checked Then
            acpayee = True
            PictureBox_ac_payee.Visible = True
        Else
            acpayee = False
            PictureBox_ac_payee.Visible = False
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not sgd.Contains(".") Then
            amount.AppendText(".00")
        End If
        If Process_report() Then
            If pay_mode AndAlso mode_cb.Text = "CHEQUE" Then
                CrystalReportViewer1.ReportSource = rpt
                CrystalReportViewer1.PrintReport()
            ElseIf receipt_mode Then
                CrystalReportViewer1.ReportSource = rpt3
                CrystalReportViewer1.PrintReport()
                sql_cmd = "INSERT INTO log (Cheque_Date,Voucher_No,Payer_Payee,Mode,Reference_No,Amount, Created_On, Description, Type, Company) 
                            VALUES ('" + date_vou_db + "','" + voucher_no + "','" + paye + "','" + mode + "','" + ref_no + "','" + sgd + "', CURRENT_TIMESTAMP, '" + desc + "', '" + menu_str + "', '" + comp + "')"
                Console.WriteLine(sql_cmd)
                Run_sql_cmd(sql_cmd)
            End If

            If Not receipt_mode Then
                CrystalReportViewer1.ReportSource = rpt2
                CrystalReportViewer1.PrintReport()
                sql_cmd = "INSERT INTO log (Cheque_Date,Voucher_No,Payer_Payee,Mode,Reference_No,Amount, Created_On, Description, Type, Company) 
                            VALUES ('" + date_vou_db + "','" + voucher_no + "','" + paye + "','" + mode + "','" + ref_no + "','" + sgd + "', CURRENT_TIMESTAMP, '" + desc + "', '" + menu_str + "', '" + comp + "')"
                Console.WriteLine(sql_cmd)
                Run_sql_cmd(sql_cmd)
            End If
            dateTimePicker1.Visible = True
            panel2.Visible = True
        End If
    End Sub

    Function Process_report() As Boolean
        'Get Data from field
        paye = payee.Text
        ref_no = reff.Text
        comp = company.Text
        If comp.Contains("'") Then
            comp = comp.Insert(comp.IndexOf("'"), "'")
        End If
        If desc = "" Then
            desc = Get_description()
        End If

        'end
        'Check if all fields are entered
        Dim processed As Boolean = False
        If mode = "" Then
            ToolTip_mode.Show("Select Mode", mode_cb)
        ElseIf menu_str = "" Then
            ToolTip_menu.Show("Select Type", menu)
        ElseIf sgd = "" Then
            amount.Select()
            ToolTip_amount.Show("Enter Amount", amount)
        ElseIf paye = "" Then
            payee.Select()
            ToolTip_payee.Show("Enter Payee Name", payee)
        ElseIf day1 = "" Then
            dateTimePicker1.Select()
            ToolTip_date.Show("Select Date", dateTimePicker1)
        ElseIf ref_no = "" Then
            reff.Select()
            ToolTip_ref.Show("Enter Reference Number", reff)
        ElseIf comp = "" Then
            ToolTip_comp.Show("Select Company Name", company)
        ElseIf desc = "" Then
            MsgBox("Please enter voucher description and try again !!", MsgBoxStyle.Critical)
        Else
            Dim ds As DataSet = New DataSet()
            Dim dt As DataTable = New DataTable("DataTable")
            dt.Columns.Add("date", GetType(System.String))
            dt.Columns.Add("date2", GetType(System.String))
            dt.Columns.Add("dateX", GetType(System.Double))
            dt.Columns.Add("dateW", GetType(System.Double))
            dt.Columns.Add("voucherNo", GetType(System.String))
            dt.Columns.Add("payee", GetType(System.String))
            dt.Columns.Add("payeeX", GetType(System.Double))
            dt.Columns.Add("payeeW", GetType(System.Double))
            dt.Columns.Add("amount", GetType(System.String))
            dt.Columns.Add("amountX", GetType(System.Double))
            dt.Columns.Add("amountW", GetType(System.Double))
            dt.Columns.Add("amountWords", GetType(System.String))
            dt.Columns.Add("amountWordsX", GetType(System.Double))
            dt.Columns.Add("amountWordsW", GetType(System.Double))
            dt.Columns.Add("amountWords1", GetType(System.String))
            dt.Columns.Add("amountWords1X", GetType(System.Double))
            dt.Columns.Add("amountWords1W", GetType(System.Double))
            dt.Columns.Add("company", GetType(System.String))
            dt.Columns.Add("mode", GetType(System.String))
            dt.Columns.Add("reference", GetType(System.String))
            dt.Columns.Add("description", GetType(System.String))
            dt.Columns.Add("acpayee", GetType(System.Boolean))
            dt.Columns.Add("bearer", GetType(System.Boolean))
            Dim dr As DataRow = dt.NewRow()
            dr("date") = day1 & Space(6) & day2 & Space(6) & mon1 & Space(6) & mon2 & Space(5) & year1 & Space(6) & year2
            dr("dateX") = 0
                    dr("dateW") = 0.2
                    voucher_no = Get_voucher_num()
                    dr("voucherNo") = voucher_no
                    dr("payee") = paye
                    dr("amount") = sgd
            dr("amountWords") = amount_words
            dr("amountWords1") = amount_words1
            dr("company") = comp
            dr("mode") = mode
            dr("reference") = ref_no
            dr("description") = desc
            dr("acpayee") = acpayee
            dr("bearer") = bearer
            dt.Rows.Add(dr)
            ds.Tables.Add(dt)
            rpt = New ReportDocument()
            rpt.Load("DBScheque.rpt")
            rpt.SetDataSource(ds)

            dr("date2") = date_vou
            rpt2 = New ReportDocument()
            rpt2.Load("PaymentVoucher.rpt")
            rpt2.SetDataSource(ds)

            rpt3 = New ReportDocument
            rpt3.Load("OfficialReceipt.rpt")
            rpt3.SetDataSource(ds)
            processed = True
        End If
        'end
        Return processed
    End Function

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles dateTimePicker1.ValueChanged
        ToolTip_date.RemoveAll()
        date_vou = dateTimePicker1.Value.Date.ToString("dd/MM/yy")
        date_vou_db = dateTimePicker1.Value.Date.ToString("yyyy/MM/dd")
        day1 = dateTimePicker1.Value.Date.ToString("dd").Substring(0, 1)
        d1.Text = day1
        day2 = dateTimePicker1.Value.Date.ToString("dd").Substring(1, 1)
        d2.Text = day2

        mon1 = dateTimePicker1.Value.Date.ToString("MM").Substring(0, 1)
        m1.Text = mon1
        mon2 = dateTimePicker1.Value.Date.ToString("MM").Substring(1, 1)
        m2.Text = mon2

        year1 = dateTimePicker1.Value.Date.ToString("yy").Substring(0, 1)
        y1.Text = year1
        year2 = dateTimePicker1.Value.Date.ToString("yy").Substring(1, 1)
        y2.Text = year2

        dateTimePicker1.Visible = False
        panel2.Visible = False
    End Sub

    Private isMouseDown As Boolean = False
    Private mouseOffset As Point

    ' Left mouse button pressed
    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles pictureBox1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' Get the new position
            mouseOffset = New Point(-e.X, -e.Y)
            ' Set that left button is pressed
            isMouseDown = True
        End If
    End Sub

    ' MouseMove used to check if mouse cursor is moving
    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles pictureBox1.MouseMove
        If isMouseDown Then
            Dim mousePos As Point = Control.MousePosition
            ' Get the new form position
            mousePos.Offset(mouseOffset.X, mouseOffset.Y)
            Me.Location = mousePos
        End If
    End Sub

    ' Left mouse button released, form should stop moving
    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles pictureBox1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            isMouseDown = False
        End If
    End Sub


End Class
