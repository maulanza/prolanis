<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginForm
    'Inherits System.Windows.Forms.Form
    Inherits MetroFramework.Forms.MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTextBoxUsername = New MetroFramework.Controls.MetroTextBox()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.MetroTextBoxPassword = New MetroFramework.Controls.MetroTextBox()
        Me.MetroButtonLogin = New MetroFramework.Controls.MetroButton()
        Me.MetroLabel3 = New MetroFramework.Controls.MetroLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(44, 229)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(68, 19)
        Me.MetroLabel1.TabIndex = 0
        Me.MetroLabel1.Text = "Username"
        '
        'MetroTextBoxUsername
        '
        '
        '
        '
        Me.MetroTextBoxUsername.CustomButton.Image = Nothing
        Me.MetroTextBoxUsername.CustomButton.Location = New System.Drawing.Point(105, 1)
        Me.MetroTextBoxUsername.CustomButton.Name = ""
        Me.MetroTextBoxUsername.CustomButton.Size = New System.Drawing.Size(18, 18)
        Me.MetroTextBoxUsername.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroTextBoxUsername.CustomButton.TabIndex = 1
        Me.MetroTextBoxUsername.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroTextBoxUsername.CustomButton.UseSelectable = True
        Me.MetroTextBoxUsername.CustomButton.Visible = False
        Me.MetroTextBoxUsername.Lines = New String(-1) {}
        Me.MetroTextBoxUsername.Location = New System.Drawing.Point(155, 229)
        Me.MetroTextBoxUsername.MaxLength = 32767
        Me.MetroTextBoxUsername.Name = "MetroTextBoxUsername"
        Me.MetroTextBoxUsername.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBoxUsername.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBoxUsername.SelectedText = ""
        Me.MetroTextBoxUsername.SelectionLength = 0
        Me.MetroTextBoxUsername.SelectionStart = 0
        Me.MetroTextBoxUsername.Size = New System.Drawing.Size(145, 23)
        Me.MetroTextBoxUsername.TabIndex = 1
        Me.MetroTextBoxUsername.UseSelectable = True
        Me.MetroTextBoxUsername.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.MetroTextBoxUsername.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(44, 272)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(63, 19)
        Me.MetroLabel2.TabIndex = 2
        Me.MetroLabel2.Text = "Password"
        '
        'MetroTextBoxPassword
        '
        '
        '
        '
        Me.MetroTextBoxPassword.CustomButton.Image = Nothing
        Me.MetroTextBoxPassword.CustomButton.Location = New System.Drawing.Point(105, 1)
        Me.MetroTextBoxPassword.CustomButton.Name = ""
        Me.MetroTextBoxPassword.CustomButton.Size = New System.Drawing.Size(18, 18)
        Me.MetroTextBoxPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroTextBoxPassword.CustomButton.TabIndex = 1
        Me.MetroTextBoxPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroTextBoxPassword.CustomButton.UseSelectable = True
        Me.MetroTextBoxPassword.CustomButton.Visible = False
        Me.MetroTextBoxPassword.Lines = New String(-1) {}
        Me.MetroTextBoxPassword.Location = New System.Drawing.Point(155, 272)
        Me.MetroTextBoxPassword.MaxLength = 32767
        Me.MetroTextBoxPassword.Name = "MetroTextBoxPassword"
        Me.MetroTextBoxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBoxPassword.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBoxPassword.SelectedText = ""
        Me.MetroTextBoxPassword.SelectionLength = 0
        Me.MetroTextBoxPassword.SelectionStart = 0
        Me.MetroTextBoxPassword.Size = New System.Drawing.Size(145, 23)
        Me.MetroTextBoxPassword.TabIndex = 3
        Me.MetroTextBoxPassword.UseSelectable = True
        Me.MetroTextBoxPassword.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.MetroTextBoxPassword.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroButtonLogin
        '
        Me.MetroButtonLogin.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MetroButtonLogin.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.MetroButtonLogin.Location = New System.Drawing.Point(21, 328)
        Me.MetroButtonLogin.Name = "MetroButtonLogin"
        Me.MetroButtonLogin.Size = New System.Drawing.Size(306, 34)
        Me.MetroButtonLogin.TabIndex = 4
        Me.MetroButtonLogin.Text = "LOGIN"
        Me.MetroButtonLogin.UseSelectable = True
        '
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = True
        Me.MetroLabel3.BackColor = System.Drawing.Color.White
        Me.MetroLabel3.ForeColor = System.Drawing.Color.LimeGreen
        Me.MetroLabel3.Location = New System.Drawing.Point(64, 182)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(227, 19)
        Me.MetroLabel3.TabIndex = 5
        Me.MetroLabel3.Text = "Program Pengelolaan Penyakit Kronis"
        Me.MetroLabel3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(96, 49)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(160, 120)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle
        Me.ClientSize = New System.Drawing.Size(348, 382)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MetroLabel3)
        Me.Controls.Add(Me.MetroButtonLogin)
        Me.Controls.Add(Me.MetroTextBoxPassword)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroTextBoxUsername)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LoginForm"
        Me.Padding = New System.Windows.Forms.Padding(21, 60, 21, 20)
        Me.Resizable = False
        Me.Style = MetroFramework.MetroColorStyle.Green
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroTextBoxUsername As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroTextBoxPassword As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroButtonLogin As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroLabel3 As MetroFramework.Controls.MetroLabel
    Friend WithEvents PictureBox1 As PictureBox
End Class
