<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox_ac_payee = New System.Windows.Forms.PictureBox()
        Me.bearer_x = New System.Windows.Forms.TextBox()
        Me.reff = New System.Windows.Forms.TextBox()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.dateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.y2 = New System.Windows.Forms.TextBox()
        Me.y1 = New System.Windows.Forms.TextBox()
        Me.m2 = New System.Windows.Forms.TextBox()
        Me.m1 = New System.Windows.Forms.TextBox()
        Me.d2 = New System.Windows.Forms.TextBox()
        Me.d1 = New System.Windows.Forms.TextBox()
        Me.words1 = New System.Windows.Forms.RichTextBox()
        Me.words = New System.Windows.Forms.RichTextBox()
        Me.amount = New System.Windows.Forms.RichTextBox()
        Me.payee = New System.Windows.Forms.RichTextBox()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.menu = New System.Windows.Forms.ComboBox()
        Me.mode_cb = New System.Windows.Forms.ComboBox()
        Me.close = New System.Windows.Forms.Button()
        Me.bearer_cb = New System.Windows.Forms.CheckBox()
        Me.acpayee_cb = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolTip_payee = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip_date = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip_amount = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip_ref = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip_mode = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip_menu = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.company = New System.Windows.Forms.ComboBox()
        Me.ToolTip_comp = New System.Windows.Forms.ToolTip(Me.components)
        Me.panel1.SuspendLayout()
        CType(Me.PictureBox_ac_payee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel2.SuspendLayout()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panel1.Controls.Add(Me.PictureBox_ac_payee)
        Me.panel1.Controls.Add(Me.bearer_x)
        Me.panel1.Controls.Add(Me.reff)
        Me.panel1.Controls.Add(Me.panel2)
        Me.panel1.Controls.Add(Me.y2)
        Me.panel1.Controls.Add(Me.y1)
        Me.panel1.Controls.Add(Me.m2)
        Me.panel1.Controls.Add(Me.m1)
        Me.panel1.Controls.Add(Me.d2)
        Me.panel1.Controls.Add(Me.d1)
        Me.panel1.Controls.Add(Me.words1)
        Me.panel1.Controls.Add(Me.words)
        Me.panel1.Controls.Add(Me.amount)
        Me.panel1.Controls.Add(Me.payee)
        Me.panel1.Controls.Add(Me.pictureBox1)
        Me.panel1.Controls.Add(Me.CrystalReportViewer1)
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(1020, 450)
        Me.panel1.TabIndex = 1
        '
        'PictureBox_ac_payee
        '
        Me.PictureBox_ac_payee.Image = Global.Check_Writer.My.Resources.Resources.AC_PAYEE
        Me.PictureBox_ac_payee.InitialImage = CType(resources.GetObject("PictureBox_ac_payee.InitialImage"), System.Drawing.Image)
        Me.PictureBox_ac_payee.Location = New System.Drawing.Point(450, 36)
        Me.PictureBox_ac_payee.Name = "PictureBox_ac_payee"
        Me.PictureBox_ac_payee.Size = New System.Drawing.Size(151, 69)
        Me.PictureBox_ac_payee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox_ac_payee.TabIndex = 30
        Me.PictureBox_ac_payee.TabStop = False
        '
        'bearer_x
        '
        Me.bearer_x.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.bearer_x.Location = New System.Drawing.Point(673, 163)
        Me.bearer_x.Name = "bearer_x"
        Me.bearer_x.Size = New System.Drawing.Size(100, 15)
        Me.bearer_x.TabIndex = 29
        Me.bearer_x.Text = "XXXXXXXX"
        '
        'reff
        '
        Me.reff.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.reff.Location = New System.Drawing.Point(198, 398)
        Me.reff.Name = "reff"
        Me.reff.Size = New System.Drawing.Size(126, 22)
        Me.reff.TabIndex = 4
        '
        'panel2
        '
        Me.panel2.Controls.Add(Me.dateTimePicker1)
        Me.panel2.Location = New System.Drawing.Point(748, 21)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(237, 47)
        Me.panel2.TabIndex = 13
        '
        'dateTimePicker1
        '
        Me.dateTimePicker1.CustomFormat = "dd/MM/yy"
        Me.dateTimePicker1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dateTimePicker1.Font = New System.Drawing.Font("Microsoft PhagsPa", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateTimePicker1.Location = New System.Drawing.Point(0, 0)
        Me.dateTimePicker1.Name = "dateTimePicker1"
        Me.dateTimePicker1.Size = New System.Drawing.Size(237, 29)
        Me.dateTimePicker1.TabIndex = 5
        '
        'y2
        '
        Me.y2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.y2.Location = New System.Drawing.Point(945, 25)
        Me.y2.MaxLength = 1
        Me.y2.Name = "y2"
        Me.y2.Size = New System.Drawing.Size(38, 38)
        Me.y2.TabIndex = 21
        Me.y2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'y1
        '
        Me.y1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.y1.Location = New System.Drawing.Point(906, 25)
        Me.y1.MaxLength = 1
        Me.y1.Name = "y1"
        Me.y1.Size = New System.Drawing.Size(38, 38)
        Me.y1.TabIndex = 20
        Me.y1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'm2
        '
        Me.m2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m2.Location = New System.Drawing.Point(866, 25)
        Me.m2.MaxLength = 1
        Me.m2.Name = "m2"
        Me.m2.Size = New System.Drawing.Size(38, 38)
        Me.m2.TabIndex = 19
        Me.m2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'm1
        '
        Me.m1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m1.Location = New System.Drawing.Point(825, 25)
        Me.m1.MaxLength = 1
        Me.m1.Name = "m1"
        Me.m1.Size = New System.Drawing.Size(38, 38)
        Me.m1.TabIndex = 18
        Me.m1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'd2
        '
        Me.d2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.d2.Location = New System.Drawing.Point(786, 25)
        Me.d2.MaxLength = 1
        Me.d2.Name = "d2"
        Me.d2.Size = New System.Drawing.Size(38, 38)
        Me.d2.TabIndex = 17
        Me.d2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'd1
        '
        Me.d1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.d1.Location = New System.Drawing.Point(747, 25)
        Me.d1.MaxLength = 1
        Me.d1.Name = "d1"
        Me.d1.Size = New System.Drawing.Size(38, 38)
        Me.d1.TabIndex = 16
        Me.d1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'words1
        '
        Me.words1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.words1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.words1.Location = New System.Drawing.Point(41, 253)
        Me.words1.MaxLength = 74
        Me.words1.Multiline = False
        Me.words1.Name = "words1"
        Me.words1.ReadOnly = True
        Me.words1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.words1.Size = New System.Drawing.Size(593, 23)
        Me.words1.TabIndex = 15
        Me.words1.Text = ""
        '
        'words
        '
        Me.words.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.words.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.words.Location = New System.Drawing.Point(113, 202)
        Me.words.MaxLength = 65
        Me.words.Multiline = False
        Me.words.Name = "words"
        Me.words.ReadOnly = True
        Me.words.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.words.Size = New System.Drawing.Size(521, 23)
        Me.words.TabIndex = 14
        Me.words.Text = ""
        '
        'amount
        '
        Me.amount.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.amount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.amount.Location = New System.Drawing.Point(700, 185)
        Me.amount.MaxLength = 15
        Me.amount.Multiline = False
        Me.amount.Name = "amount"
        Me.amount.Size = New System.Drawing.Size(259, 41)
        Me.amount.TabIndex = 3
        Me.amount.Text = ""
        '
        'payee
        '
        Me.payee.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.payee.Location = New System.Drawing.Point(67, 151)
        Me.payee.MaxLength = 64
        Me.payee.Multiline = False
        Me.payee.Name = "payee"
        Me.payee.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.payee.Size = New System.Drawing.Size(567, 23)
        Me.payee.TabIndex = 2
        Me.payee.Text = ""
        '
        'pictureBox1
        '
        Me.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pictureBox1.Image = CType(resources.GetObject("pictureBox1.Image"), System.Drawing.Image)
        Me.pictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(1020, 450)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBox1.TabIndex = 0
        Me.pictureBox1.TabStop = False
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(141, 77)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(129, 73)
        Me.CrystalReportViewer1.TabIndex = 23
        Me.CrystalReportViewer1.Visible = False
        '
        'menu
        '
        Me.menu.BackColor = System.Drawing.SystemColors.HotTrack
        Me.menu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.menu.FormattingEnabled = True
        Me.menu.Items.AddRange(New Object() {"PAYMENT", "RECEIPT"})
        Me.menu.Location = New System.Drawing.Point(3, 142)
        Me.menu.Name = "menu"
        Me.menu.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.menu.Size = New System.Drawing.Size(125, 24)
        Me.menu.TabIndex = 7
        Me.menu.TabStop = False
        '
        'mode_cb
        '
        Me.mode_cb.BackColor = System.Drawing.SystemColors.HotTrack
        Me.mode_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.mode_cb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.mode_cb.FormattingEnabled = True
        Me.mode_cb.Items.AddRange(New Object() {"CASH", "CHEQUE"})
        Me.mode_cb.Location = New System.Drawing.Point(3, 101)
        Me.mode_cb.Name = "mode_cb"
        Me.mode_cb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.mode_cb.Size = New System.Drawing.Size(125, 24)
        Me.mode_cb.TabIndex = 6
        Me.mode_cb.TabStop = False
        '
        'close
        '
        Me.close.BackColor = System.Drawing.SystemColors.Highlight
        Me.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.close.Location = New System.Drawing.Point(0, 370)
        Me.close.Name = "close"
        Me.close.Size = New System.Drawing.Size(131, 38)
        Me.close.TabIndex = 28
        Me.close.Text = "CLOSE"
        Me.close.UseVisualStyleBackColor = False
        '
        'bearer_cb
        '
        Me.bearer_cb.AutoSize = True
        Me.bearer_cb.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.bearer_cb.Checked = True
        Me.bearer_cb.CheckState = System.Windows.Forms.CheckState.Checked
        Me.bearer_cb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bearer_cb.Location = New System.Drawing.Point(13, 55)
        Me.bearer_cb.Name = "bearer_cb"
        Me.bearer_cb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.bearer_cb.Size = New System.Drawing.Size(69, 21)
        Me.bearer_cb.TabIndex = 27
        Me.bearer_cb.Text = "Bearer"
        Me.bearer_cb.UseVisualStyleBackColor = False
        '
        'acpayee_cb
        '
        Me.acpayee_cb.AutoSize = True
        Me.acpayee_cb.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.acpayee_cb.Checked = True
        Me.acpayee_cb.CheckState = System.Windows.Forms.CheckState.Checked
        Me.acpayee_cb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.acpayee_cb.Location = New System.Drawing.Point(13, 16)
        Me.acpayee_cb.Name = "acpayee_cb"
        Me.acpayee_cb.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.acpayee_cb.Size = New System.Drawing.Size(92, 21)
        Me.acpayee_cb.TabIndex = 26
        Me.acpayee_cb.Text = "A/C Payee"
        Me.acpayee_cb.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(0, 303)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(131, 40)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "PRINT"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ToolTip_payee
        '
        Me.ToolTip_payee.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        '
        'ToolTip_date
        '
        Me.ToolTip_date.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        '
        'ToolTip_amount
        '
        Me.ToolTip_amount.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        '
        'ToolTip_ref
        '
        Me.ToolTip_ref.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Highlight
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(0, 232)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(131, 40)
        Me.Button2.TabIndex = 33
        Me.Button2.Text = "VIEW LOG"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(1022, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.TextBox1.Size = New System.Drawing.Size(131, 15)
        Me.TextBox1.TabIndex = 34
        Me.TextBox1.Text = "Menu"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.company)
        Me.Panel3.Controls.Add(Me.close)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.acpayee_cb)
        Me.Panel3.Controls.Add(Me.bearer_cb)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.menu)
        Me.Panel3.Controls.Add(Me.mode_cb)
        Me.Panel3.Location = New System.Drawing.Point(1022, 31)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(131, 419)
        Me.Panel3.TabIndex = 31
        '
        'company
        '
        Me.company.BackColor = System.Drawing.SystemColors.HotTrack
        Me.company.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.company.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.company.FormattingEnabled = True
        Me.company.Items.AddRange(New Object() {"Company 1", "Company 2"})
        Me.company.Location = New System.Drawing.Point(3, 184)
        Me.company.Name = "company"
        Me.company.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.company.Size = New System.Drawing.Size(125, 24)
        Me.company.TabIndex = 34
        Me.company.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(1153, 450)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.PictureBox_ac_payee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel2.ResumeLayout(False)
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents panel1 As Panel
    Private WithEvents panel2 As Panel
    Private WithEvents dateTimePicker1 As DateTimePicker
    Private WithEvents y2 As TextBox
    Private WithEvents y1 As TextBox
    Private WithEvents m2 As TextBox
    Private WithEvents m1 As TextBox
    Private WithEvents d2 As TextBox
    Private WithEvents d1 As TextBox
    Private WithEvents words1 As RichTextBox
    Private WithEvents words As RichTextBox
    Private WithEvents amount As RichTextBox
    Private WithEvents payee As RichTextBox
    Private WithEvents pictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents reff As TextBox
    Friend WithEvents acpayee_cb As CheckBox
    Friend WithEvents bearer_cb As CheckBox
    Friend WithEvents close As Button
    Friend WithEvents ToolTip_payee As ToolTip
    Friend WithEvents ToolTip_date As ToolTip
    Friend WithEvents ToolTip_amount As ToolTip
    Friend WithEvents ToolTip_ref As ToolTip
    Friend WithEvents bearer_x As TextBox
    Friend WithEvents PictureBox_ac_payee As PictureBox
    Friend WithEvents mode_cb As ComboBox
    Friend WithEvents menu As ComboBox
    Friend WithEvents ToolTip_mode As ToolTip
    Friend WithEvents ToolTip_menu As ToolTip
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents company As ComboBox
    Friend WithEvents ToolTip_comp As ToolTip
End Class
