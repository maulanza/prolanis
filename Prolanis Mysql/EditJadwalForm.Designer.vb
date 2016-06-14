<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditJadwalForm
    Inherits MetroFramework.Forms.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MetroLabel1 = New MetroFramework.Controls.MetroLabel()
        Me.MetroComboBoxPasien = New MetroFramework.Controls.MetroComboBox()
        Me.MetroLabel2 = New MetroFramework.Controls.MetroLabel()
        Me.MetroButtonTambahJadwal = New MetroFramework.Controls.MetroButton()
        Me.MetroButtonCancel = New MetroFramework.Controls.MetroButton()
        Me.DateTimePickerJadwal = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(48, 101)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(85, 19)
        Me.MetroLabel1.TabIndex = 0
        Me.MetroLabel1.Text = "Nama Pasien"
        '
        'MetroComboBoxPasien
        '
        Me.MetroComboBoxPasien.FormattingEnabled = True
        Me.MetroComboBoxPasien.ItemHeight = 23
        Me.MetroComboBoxPasien.Location = New System.Drawing.Point(170, 91)
        Me.MetroComboBoxPasien.Name = "MetroComboBoxPasien"
        Me.MetroComboBoxPasien.Size = New System.Drawing.Size(292, 29)
        Me.MetroComboBoxPasien.TabIndex = 1
        Me.MetroComboBoxPasien.UseSelectable = True
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(48, 147)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(48, 19)
        Me.MetroLabel2.TabIndex = 2
        Me.MetroLabel2.Text = "Jadwal"
        '
        'MetroButtonTambahJadwal
        '
        Me.MetroButtonTambahJadwal.FontSize = MetroFramework.MetroButtonSize.Tall
        Me.MetroButtonTambahJadwal.FontWeight = MetroFramework.MetroButtonWeight.Regular
        Me.MetroButtonTambahJadwal.Location = New System.Drawing.Point(148, 235)
        Me.MetroButtonTambahJadwal.Name = "MetroButtonTambahJadwal"
        Me.MetroButtonTambahJadwal.Size = New System.Drawing.Size(111, 32)
        Me.MetroButtonTambahJadwal.Style = MetroFramework.MetroColorStyle.Green
        Me.MetroButtonTambahJadwal.TabIndex = 17
        Me.MetroButtonTambahJadwal.Text = "Tambah"
        Me.MetroButtonTambahJadwal.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroButtonTambahJadwal.UseCustomBackColor = True
        Me.MetroButtonTambahJadwal.UseSelectable = True
        Me.MetroButtonTambahJadwal.UseStyleColors = True
        '
        'MetroButtonCancel
        '
        Me.MetroButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.MetroButtonCancel.FontSize = MetroFramework.MetroButtonSize.Tall
        Me.MetroButtonCancel.FontWeight = MetroFramework.MetroButtonWeight.Regular
        Me.MetroButtonCancel.Location = New System.Drawing.Point(274, 235)
        Me.MetroButtonCancel.Name = "MetroButtonCancel"
        Me.MetroButtonCancel.Size = New System.Drawing.Size(111, 32)
        Me.MetroButtonCancel.Style = MetroFramework.MetroColorStyle.Green
        Me.MetroButtonCancel.TabIndex = 18
        Me.MetroButtonCancel.Text = "Cancel"
        Me.MetroButtonCancel.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroButtonCancel.UseCustomBackColor = True
        Me.MetroButtonCancel.UseSelectable = True
        Me.MetroButtonCancel.UseStyleColors = True
        '
        'DateTimePickerJadwal
        '
        Me.DateTimePickerJadwal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerJadwal.Location = New System.Drawing.Point(170, 147)
        Me.DateTimePickerJadwal.Name = "DateTimePickerJadwal"
        Me.DateTimePickerJadwal.Size = New System.Drawing.Size(292, 20)
        Me.DateTimePickerJadwal.TabIndex = 20
        '
        'EditJadwalForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 300)
        Me.Controls.Add(Me.DateTimePickerJadwal)
        Me.Controls.Add(Me.MetroButtonCancel)
        Me.Controls.Add(Me.MetroButtonTambahJadwal)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroComboBoxPasien)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Name = "EditJadwalForm"
        Me.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow
        Me.Style = MetroFramework.MetroColorStyle.Green
        Me.Text = "Edit Jadwal Pasien"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MetroLabel1 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroComboBoxPasien As MetroFramework.Controls.MetroComboBox
    Friend WithEvents MetroLabel2 As MetroFramework.Controls.MetroLabel
    Friend WithEvents MetroButtonTambahJadwal As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroButtonCancel As MetroFramework.Controls.MetroButton
    Friend WithEvents DateTimePickerJadwal As DateTimePicker
End Class
