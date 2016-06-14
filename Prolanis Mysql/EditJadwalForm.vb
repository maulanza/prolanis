Imports MySql.Data.MySqlClient

Public Class EditJadwalForm
    Private errorProvider As ErrorProvider
    Private obj As MainForm = DirectCast(Application.OpenForms("MainForm"), MainForm)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.errorProvider = New ErrorProvider()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Function AreRequiredFieldsValid() As Boolean
        If String.IsNullOrEmpty(Me.MetroComboBoxPasien.Text) Then
            Me.errorProvider.SetError(Me.MetroComboBoxPasien, "Nama pasien harus dipilih.")
            Return False
        End If
        If String.IsNullOrEmpty(Me.DateTimePickerJadwal.Text) Then
            Me.errorProvider.SetError(Me.DateTimePickerJadwal, "Jadwal harus dipilih.")
            Return False
        End If
        Return True
    End Function

    Private Sub EditJadwalForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load Combobox'
        LoadComboBox()

        'Load isi Form'
        LoadIsiForm()

    End Sub

    Private Sub LoadComboBox()
        Dim mainForm As MainForm = New MainForm()

        'Isi combobox dengan nama pasien'
        Try
            If (mainForm.connection.State <> ConnectionState.Open) Then
                mainForm.connection.Open()
            End If

            Dim reader As MySqlDataReader
            Dim adapter As MySqlDataAdapter
            'Dim command As SQLiteCommand = mainForm.connection.CreateCommand()
            'command.CommandText = mainForm.SQLSelectNamaPasien
            adapter = New MySqlDataAdapter(mainForm.SQLSelectNamaPasien, mainForm.connection)
            Dim ds As New DataSet()
            adapter.Fill(ds, "tb_pasien")

            With MetroComboBoxPasien
                .DataSource = ds.Tables("tb_pasien")
                .DisplayMember = "fnama"
                .ValueMember = "id_pasien"
                .SelectedIndex = 0
            End With
            'reader = command.ExecuteReader(CommandBehavior.Default)
            'While reader.Read()
            '    Dim id = reader.GetInt32(0)
            '    Dim namaDepan = reader.GetString(1)
            '    Dim namaBelakang = reader.GetString(2)
            '    Dim namaPasien As Object = namaDepan + " " + namaBelakang
            '    MetroComboBoxPasien.Items.Add(namaPasien)
            '    MessageBox.Show(id.ToString())
            'End While

            mainForm.connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub LoadIsiForm()
        Dim mainForm As MainForm = New MainForm()

        Try
            If (mainForm.connection.State <> ConnectionState.Open) Then
                mainForm.connection.Open()
            End If

            Dim reader As MySqlDataReader
            Dim command As MySqlCommand = mainForm.connection.CreateCommand()
            command.CommandText = mainForm.SQLSelectToTextBoxJadwal

            command.Parameters.AddWithValue("id_jadwal", mainForm.id_jadwal)
            reader = command.ExecuteReader(CommandBehavior.Default)
            While reader.Read()
                MetroComboBoxPasien.Text = reader("fnama").ToString()
                DateTimePickerJadwal.Value = reader("jadwal").ToString()
            End While
            MetroComboBoxPasien.Enabled = False
            mainForm.connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Public Shared idShared As Integer
    Public Property id_shared() As Integer
        Get
            Return idShared
        End Get
        Set(value As Integer)

        End Set
    End Property

    Private Sub MetroButtonTambahJadwal_Click(sender As Object, e As EventArgs) Handles MetroButtonTambahJadwal.Click
        Dim mainForm As MainForm = New MainForm()

        If (Not Me.AreRequiredFieldsValid()) Then
            Return
        End If

        Try
            If (mainForm.connection.State <> ConnectionState.Open) Then
                mainForm.connection.Open()
            End If

            Dim command As MySqlCommand = mainForm.connection.CreateCommand()
            command.CommandText = mainForm.SQLUpdateJadwal

            command.Parameters.AddWithValue("jadwal", DateTimePickerJadwal.Text)
            command.Parameters.AddWithValue("id_jadwal", mainForm.id_jadwal)
            command.ExecuteNonQuery()

            obj.LoadJadwal()
            obj.MetroGrid3.Update()
            obj.MetroGrid3.Refresh()

            obj.connection.Close()

            MessageBox.Show("Data telah berhasil diperbaharui!")

            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

    End Sub
End Class