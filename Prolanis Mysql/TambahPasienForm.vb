Imports MySql.Data.MySqlClient
Public Class TambahPasienForm
    Inherits MetroFramework.Forms.MetroForm
    Private errorProvider As ErrorProvider
    Private obj As MainForm = DirectCast(Application.OpenForms("MainForm"), MainForm)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.errorProvider = New ErrorProvider()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Function AreRequiredFieldsValid() As Boolean
        If String.IsNullOrEmpty(Me.MetroTextBoxFnama.Text) Then
            Me.errorProvider.SetError(Me.MetroTextBoxFnama, "Nama Depan harus diisi.")
            Return False
        End If
        If Me.DateTimePickerTTL Is Nothing Then
            Me.errorProvider.SetError(Me.DateTimePickerTTL, "Tempat tanggal lahir harus diisi.")
            Return False
        End If
        If String.IsNullOrEmpty(Me.MetroTextBoxNoBPJS.Text) Then
            Me.errorProvider.SetError(Me.MetroTextBoxNoBPJS, "Nomor BPJS harus diisi.")
            Return False
        End If
        If String.IsNullOrEmpty(Me.MetroTextBoxAlamat.Text) Then
            Me.errorProvider.SetError(Me.MetroTextBoxAlamat, "Alamat harus diisi.")
            Return False
        End If
        If String.IsNullOrEmpty(Me.MetroTextBoxTelp1.Text) Then
            Me.errorProvider.SetError(Me.MetroTextBoxTelp1, "Nomor Telepon 1 harus diisi.")
            Return False
        End If

        Return True
    End Function

    Private Sub MetroButtonTambahPasien_Click(sender As Object, e As EventArgs) Handles MetroButtonTambahPasien.Click
        Dim sex As String
        Dim kategori As String

        If (Not Me.AreRequiredFieldsValid()) Then
            Return
        End If

        Try
            If Me.MetroRadioButtonL.Checked = True Then
                sex = "L"
            Else
                sex = "P"
            End If

            If Me.MetroRadioButtonDiabetes.Checked = True Then
                kategori = "Diabetes"
            Else
                kategori = "Hipertensi"
            End If

            If (mainForm.connection.State <> ConnectionState.Open) Then
                mainForm.connection.Open()
            End If

            Dim command As MySqlCommand = MainForm.connection.CreateCommand()
            command.CommandText = MainForm.SQLInsert

            command.Parameters.AddWithValue("fnama", MetroTextBoxFnama.Text)
            command.Parameters.AddWithValue("lnama", MetroTextBoxLnama.Text)
            command.Parameters.AddWithValue("jns_kelamin", sex)
            command.Parameters.AddWithValue("kategori", kategori)
            command.Parameters.AddWithValue("no_bpjs", MetroTextBoxNoBPJS.Text)
            command.Parameters.AddWithValue("ttl", DateTimePickerTTL.Text)
            command.Parameters.AddWithValue("alamat", MetroTextBoxAlamat.Text)
            command.Parameters.AddWithValue("no_tlp1", MetroTextBoxTelp1.Text)
            command.Parameters.AddWithValue("no_tlp2", MetroTextBoxTelp2.Text)

            command.ExecuteNonQuery()

            obj.LoadPasien()
            obj.LoadJumlahPasien()
            obj.LoadJumlahDiabetes()
            obj.LoadJumlahHipertensi()
            obj.MetroGrid1.Update()
            obj.MetroGrid1.Refresh()

            obj.connection.Close()

            MessageBox.Show("Data telah berhasil disimpan!")

            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Data gagal disimpan")
            MessageBox.Show(ex.ToString())
            'Finally
            '    obj.connection.Dispose()
        End Try
    End Sub

    Private Sub MetroButtonCancel_Click(sender As Object, e As EventArgs) Handles MetroButtonCancel.Click
        Me.Close()
    End Sub
End Class