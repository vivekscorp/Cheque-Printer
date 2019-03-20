Imports System.Windows.Forms

Public Class Dialog1

    Public value_str As String
    Public Property Desc() As String
        Get
            Return value_str
        End Get
        Set(value As String)

        End Set
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Dialog1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RichTextBox1.Select()
        OK_Button.Enabled = False
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        value_str = RichTextBox1.Text
        If Not value_str = "" Then
            OK_Button.Enabled = True
        Else
            OK_Button.Enabled = False
        End If
    End Sub
End Class
