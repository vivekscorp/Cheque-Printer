Imports System.Data.SqlClient

Namespace function_class_namespace
    Module function_class
        Dim conn_str As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\KingsTech\source\repos\Check_Writer\Check_Writer\Database.mdf;Integrated Security=True"
        Dim cnn As New SqlConnection

        '-------------------------------------------------Database Functions---------------------------------------------------
        Function Dbconn() As Boolean
            cnn.Close()
            cnn.ConnectionString = conn_str
            Try
                cnn.Open()
                Return True
            Catch ex As SqlException
                Return False
            End Try
        End Function
        Sub Run_sql_cmd(cmd_str As String)
            Dim conn As New SqlConnection
            Dim cmd As New SqlCommand
            Try
                conn.ConnectionString = conn_str
                conn.Open()
                cmd.Connection = conn
                cmd.CommandText = cmd_str
                'MsgBox(cmd_str)
                cmd.ExecuteNonQuery()
            Catch ex As SqlException
                MsgBox(ex.Message.ToString)
            Finally
                conn.Close()
            End Try
        End Sub

        Function Get_logs(com As String) As DataSet
            If Dbconn() Then
                Dim Adpt As New SqlDataAdapter(com, cnn)
                Dim ds As New DataSet()
                Adpt.Fill(ds, "dat")
                Return ds
            End If
        End Function

        '----------------------------------------------------End Database Functions-----------------------------------------------

        '----------------------------------------------------Start Report Functions-----------------------------------------------
        Public Function AmountInWords(ByVal nAmount As String, Optional ByVal wAmount _
             As String = vbNullString, Optional ByVal nSet As Object = Nothing) As String
            'Let's make sure entered value is numeric
            If Not IsNumeric(nAmount) Then Return "Please enter numeric values only."

            Dim tempDecValue As String = String.Empty : If InStr(nAmount, ".") Then _
            tempDecValue = nAmount.Substring(nAmount.IndexOf("."))
            nAmount = Replace(nAmount, tempDecValue, String.Empty)

            Try
                Dim intAmount As Long = nAmount
                If intAmount > 0 Then
                    nSet = IIf((intAmount.ToString.Trim.Length / 3) _
                    > (CLng(intAmount.ToString.Trim.Length / 3)),
                  CLng(intAmount.ToString.Trim.Length / 3) + 1,
                      CLng(intAmount.ToString.Trim.Length / 3))
                    Dim eAmount As Long = Microsoft.VisualBasic.Left(intAmount.ToString.Trim,
                  (intAmount.ToString.Trim.Length - ((nSet - 1) * 3)))
                    Dim multiplier As Long = 10 ^ (((nSet - 1) * 3))

                    Dim Ones() As String =
                {"", "One", "Two", "Three",
                  "Four", "Five",
                  "Six", "Seven", "Eight", "Nine"}
                    Dim Teens() As String = {"",
                "Eleven", "Twelve", "Thirteen",
                  "Fourteen", "Fifteen",
                  "Sixteen", "Seventeen", "Eighteen", "Nineteen"}
                    Dim Tens() As String = {"", "Ten",
                "Twenty", "Thirty",
                  "Forty", "Fifty", "Sixty",
                  "Seventy", "Eighty", "Ninety"}
                    Dim HMBT() As String = {"", "",
                "Thousand", "Million",
                  "Billion", "Trillion",
                  "Quadrillion", "Quintillion"}

                    intAmount = eAmount

                    Dim nHundred As Integer = intAmount \ 100 : intAmount = intAmount Mod 100
                    Dim nTen As Integer = intAmount \ 10 : intAmount = intAmount Mod 10
                    Dim nOne As Integer = intAmount \ 1

                    If nHundred > 0 Then wAmount = wAmount &
                Ones(nHundred) & " Hundred " 'This is for hundreds                
                    If nTen > 0 Then 'This is for tens and teens
                        If nTen = 1 And nOne > 0 Then 'This is for teens 
                            wAmount = wAmount & Teens(nOne) & " "
                        Else 'This is for tens, 10 to 90
                            wAmount = wAmount & Tens(nTen) & IIf(nOne > 0, " ", " ")
                            If nOne > 0 Then wAmount = wAmount & Ones(nOne) & " "
                        End If
                    Else 'This is for ones, 1 to 9
                        If nOne > 0 Then wAmount = wAmount & Ones(nOne) & " "
                    End If
                    wAmount = wAmount & HMBT(nSet) & " "
                    wAmount = AmountInWords(CStr(CLng(nAmount) -
                  (eAmount * multiplier)).Trim & tempDecValue, wAmount, nSet - 1)
                Else
                    If Val(nAmount) = 0 Then nAmount = nAmount &
                tempDecValue : tempDecValue = String.Empty
                    If (Math.Round(Val(nAmount), 2) * 100) > 0 Then wAmount =
                  Trim(AmountInWords(CStr(Math.Round(Val(nAmount), 2) * 100),
                  wAmount.Trim & " Dollars And Cents ", 1)) & " "
                End If
            Catch ex As Exception
                MessageBox.Show("Error Encountered: " & ex.Message,
              "Convert Numbers To Words",
              MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return "!#ERROR_ENCOUNTERED"
            End Try

            'Trap null values
            If IsNothing(wAmount) = True Then wAmount = String.Empty Else wAmount =
          IIf(InStr(wAmount.Trim.ToLower, "dollars"),
          wAmount.Trim, wAmount.Trim & " Dollars")

            'Display the result
            Return wAmount
        End Function

        Function Get_voucher_num() As String
            Dim number As String = ""
            number = "PV" + Today.Date.ToString("ddMMyy") + TimeOfDay.ToString("Hmmss")
            Return number
        End Function
        Function Get_description() As String
            Dim value As String = ""
            Using options = New Dialog1()
                If DialogResult.OK = options.ShowDialog() Then
                    value = options.Desc
                End If
            End Using
            Return value
        End Function

        '---------------------------------------------------------End Report Functions-----------------------------------------------
    End Module
End Namespace
