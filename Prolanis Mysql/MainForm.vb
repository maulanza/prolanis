Imports MySql.Data.MySqlClient

Public Class MainForm

    Public connectionString As String
    Public connection As MySqlConnection

    'SQL Pasien'
    Public SQLInsert As String = "INSERT INTO tb_pasien(fnama,lnama,jns_kelamin,kategori,no_bpjs,ttl,alamat,no_tlp1,no_tlp2) VALUES(?,?,?,?,?,?,?,?,?)"
    Public SQLUpdate As String = "UPDATE tb_pasien SET fnama = ?,lnama = ?,jns_kelamin = ?,kategori = ?,no_bpjs = ?,ttl = ?,alamat = ?,no_tlp1 = ?,no_tlp2 = ? WHERE id_pasien = ?"
    Public SQLSelect As String = "SELECT * FROM tb_pasien"
    Public SQLSelectToTextBox As String = "SELECT * FROM tb_pasien WHERE id_pasien = ?"
    Public SQLDelete As String = "DELETE FROM tb_pasien WHERE id_pasien = ?"
    Public SQLSelectNoTlp1 As String = "SELECT no_tlp1 FROM tb_pasien WHERE id_pasien = ?"

    'SQl Jadwal'
    Public SQLSelectJadwal As String = "SELECT tb_jadwal.id_jadwal,tb_pasien.id_pasien,tb_pasien.fnama,tb_pasien.lnama,tb_jadwal.jadwal FROM tb_jadwal INNER JOIN tb_pasien ON tb_jadwal.idpasien = tb_pasien.id_pasien"
    Public SQLSelectNamaPasien As String = "SELECT id_pasien,fnama,lnama FROM tb_pasien"
    Public SQLInsertJadwal As String = "INSERT INTO tb_jadwal(jadwal,idpasien) VALUES(?,?)"
    Public SQLSelectToTextBoxJadwal As String = "SELECT tb_jadwal.id_jadwal,tb_pasien.id_pasien,tb_pasien.fnama,tb_jadwal.jadwal FROM tb_jadwal INNER JOIN tb_pasien ON tb_jadwal.idpasien = tb_pasien.id_pasien WHERE id_jadwal = ?"
    Public SQLDeleteJadwal As String = "DELETE FROM tb_jadwal WHERE id_jadwal = ?"
    Public SQLUpdateJadwal As String = "UPDATE tb_jadwal SET jadwal = ? WHERE id_jadwal = ?"

    'SQL Kotak Masuk'
    Public SQLSendMessage As String = "INSERT INTO outbox (DestinationNumber, TextDecoded, CreatorID) VALUES(?,?,?)"
    Public SQLSelectKategori As String = "SELECT Name,ID FROM pbk_groups"
    Public SQLSelectMessageKategori As String = "SELECT * FROM pbk WHERE GroupID = ?"
    Public SQLSelectMessageKategoriAll As String = "SELECT * FROM pbk"

    Public Sub New()
        InitializeComponent()
        connectionString = "server=localhost;Port=3306;user id=root;database=gammu;"
        connection = New MySqlConnection(connectionString)
        DataSources.gammuDataSet = Me.GammuDataSet
    End Sub


    '--------------------------------Menu Sidebar--------------------------------'


    Private Sub MetroTileDashboard_Click(sender As Object, e As EventArgs) Handles MetroTileDashboard.Click
        Me.MetroTabControl.SelectedTab = Me.MetroTabPageDashboard
    End Sub

    Private Sub MetroButtonPasien_Click(sender As Object, e As EventArgs) Handles MetroButtonPasien.Click
        Me.MetroTabControl.SelectedTab = Me.MetroTabPagePasien
    End Sub


    Private Sub MetroButtonJadwal_Click(sender As Object, e As EventArgs) Handles MetroButtonJadwal.Click
        Me.MetroTabControl.SelectedTab = Me.MetroTabPageJadwal
    End Sub

    Private Sub MetroButtonKirimPesan_Click(sender As Object, e As EventArgs) Handles MetroButtonKirimPesan.Click
        Me.MetroTabControl.SelectedTab = Me.MetroTabPageKirimPesan
    End Sub

    Private Sub MetroButtonKotakMasuk_Click(sender As Object, e As EventArgs) Handles MetroButtonKotakMasuk.Click
        Me.MetroTabControl.SelectedTab = Me.MetroTabPageKotakMasuk

        LoadKotakMasuk()
        MetroGrid2.Update()
        MetroGrid2.Refresh()
    End Sub

    Private Sub MetroButtonPesanKeluar_Click(sender As Object, e As EventArgs) Handles MetroButtonPesanKeluar.Click
        Me.MetroTabControl.SelectedTab = Me.MetroTabPagePesanKeluar

        LoadPesanKeluar()
        MetroGrid4.Update()
        MetroGrid4.Refresh()
    End Sub

    Private Sub MetroButtonSettings_Click(sender As Object, e As EventArgs) Handles MetroButtonSettings.Click
        Me.MetroTabControl.SelectedTab = Me.MetroTabPageSettings
    End Sub


    '--------------------------------Form Load--------------------------------'


    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MetroButtonPasien.BackColor = Color.FromArgb(0, 177, 89)
        Me.MetroButtonJadwal.BackColor = Color.FromArgb(0, 177, 89)
        Me.MetroButtonKirimPesan.BackColor = Color.FromArgb(0, 177, 89)
        Me.MetroButtonKotakMasuk.BackColor = Color.FromArgb(0, 177, 89)
        Me.MetroButtonPesanKeluar.BackColor = Color.FromArgb(0, 177, 89)
        Me.MetroButtonSettings.BackColor = Color.FromArgb(0, 177, 89)
        Me.MetroButtonLogout.BackColor = Color.FromArgb(0, 177, 89)

        'Menu Pasien'
        LoadPasien()
        SettingGridPasien()

        'Menu Jadwal'
        LoadJadwal()
        SettingGridJadwal()

        'Menu Kotak Masuk'
        LoadKotakMasuk()
        SettingGridKotakMasuk()

        'Menu Pesan Keluar'
        LoadPesanKeluar()

        'Menu Kirim Pesan'
        LoadComboBoxKategori()

    End Sub


    '--------------------------------Menu Pasien--------------------------------'


    Public Sub LoadPasien()
        'Me.Tb_pasienTableAdapter.Fill(Me.GammuDataSet.tb_pasien)
        If (connection.State <> ConnectionState.Open) Then
            connection.Open()
        End If

        Dim command As MySqlCommand = connection.CreateCommand()
        command.CommandText = SQLSelect

        Dim dt As DataTable = New DataTable()
        Dim da As MySqlDataAdapter = New MySqlDataAdapter(command)
        da.Fill(dt)

        MetroGrid1.DataSource = dt
        connection.Close()
    End Sub

    Private Sub SettingGridPasien()
        MetroGrid1.Columns(0).HeaderText = "ID"
        MetroGrid1.Columns(1).HeaderText = "Nama Depan"
        MetroGrid1.Columns(2).HeaderText = "Nama Belakang"
        MetroGrid1.Columns(3).HeaderText = "Jenis Kel"
        MetroGrid1.Columns(4).HeaderText = "Kategori"
        MetroGrid1.Columns(5).HeaderText = "No BPJS"
        MetroGrid1.Columns(6).HeaderText = "TTL"
        MetroGrid1.Columns(7).HeaderText = "Alamat"
        MetroGrid1.Columns(8).HeaderText = "Telp 1"
        MetroGrid1.Columns(9).HeaderText = "Telp 2"
    End Sub

    Private Sub MetroTileTambahPasien_Click(sender As Object, e As EventArgs) Handles MetroTileTambahPasien.Click
        Dim tambahPasienForm As TambahPasienForm = New TambahPasienForm()
        tambahPasienForm.ShowDialog(Me)
    End Sub

    Private Sub MetroTileEditPasien_Click(sender As Object, e As EventArgs) Handles MetroTileEditPasien.Click
        Dim editPasienForm As EditPasienForm = New EditPasienForm()
        editPasienForm.ShowDialog(Me)
    End Sub

    Private Sub MetroGrid1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles MetroGrid1.CellContentClick
        Dim idpasien As Integer
        idpasien = MetroGrid1.Rows(e.RowIndex).Cells(0).Value
        id = idpasien
    End Sub

    Public Shared id As Integer
    Public Property id_pasien() As Integer
        Get
            Return id
        End Get
        Set(value As Integer)

        End Set
    End Property
    Public Shared idJadwal As Integer
    Public Property id_jadwal() As Integer
        Get
            Return idJadwal
        End Get
        Set(value As Integer)

        End Set
    End Property

    Private Sub MetroTileHapusPasien_Click(sender As Object, e As EventArgs) Handles MetroTileHapusPasien.Click
        Try
            If (connection.State <> ConnectionState.Open) Then
                connection.Open()
            End If

            Dim message As String
            message = MsgBox("Are you sure want to delete this data?  ", vbExclamation + vbYesNo, "Warning")
            If message = vbNo Then Exit Sub

            Dim command As MySqlCommand = connection.CreateCommand()
            command.CommandText = SQLDelete

            command.Parameters.AddWithValue("id_pasien", id_pasien)

            command.ExecuteNonQuery()
            connection.Close()

            MessageBox.Show("Data berhasil dihapus!")
            LoadPasien()
            MetroGrid1.Update()
            MetroGrid1.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub MetroTileKirimPesan_Click(sender As Object, e As EventArgs) Handles MetroTileKirimPesan.Click
        Me.MetroTabControl.SelectedTab = Me.MetroTabPageKirimPesan

        Try
            If (connection.State <> ConnectionState.Open) Then
                connection.Open()
            End If

            Dim reader As MySqlDataReader
            Dim command As MySqlCommand = connection.CreateCommand()
            command.CommandText = SQLSelectNoTlp1

            command.Parameters.AddWithValue("id_pasien", id_pasien)
            reader = command.ExecuteReader(CommandBehavior.Default)
            While reader.Read()
                MetroTextBoxTujuan.Text = reader("no_tlp1").ToString()
            End While

            connection.Close()
        Catch ex As Exception

        End Try

    End Sub


    '--------------------------------Menu Jadwal--------------------------------'


    Public Sub LoadJadwal()
        Dim reader As MySqlDataReader
        If (connection.State <> ConnectionState.Open) Then
            connection.Open()
        End If

        Dim command As MySqlCommand = connection.CreateCommand()
        command.CommandText = SQLSelectJadwal

        Dim dt As DataTable = New DataTable()
        Dim da As MySqlDataAdapter = New MySqlDataAdapter(command)
        da.Fill(dt)

        MetroGrid3.DataSource = dt
        connection.Close()
    End Sub

    Private Sub SettingGridJadwal()
        MetroGrid3.Columns(0).HeaderText = "ID Jadwal"
        MetroGrid3.Columns(1).HeaderText = "ID Pasien"
        MetroGrid3.Columns(2).HeaderText = "Nama Depan"
        MetroGrid3.Columns(3).HeaderText = "Nama Belakang"
        MetroGrid3.Columns(4).HeaderText = "Jadwal"
    End Sub

    Private Sub MetroTileTambahJadwal_Click(sender As Object, e As EventArgs) Handles MetroTileTambahJadwal.Click
        Dim tambahJadwalForm As TambahJadwalForm = New TambahJadwalForm()
        tambahJadwalForm.ShowDialog(Me)
    End Sub

    Private Sub MetroGrid3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles MetroGrid3.CellContentClick
        Dim id As Integer
        id = MetroGrid3.Rows(e.RowIndex).Cells(0).Value
        idJadwal = id
    End Sub

    Private Sub MetroTileEditJadwal_Click(sender As Object, e As EventArgs) Handles MetroTileEditJadwal.Click
        Dim editJadwalForm As EditJadwalForm = New EditJadwalForm()
        editJadwalForm.ShowDialog(Me)
    End Sub

    Private Sub MetroTileHapusJadwal_Click(sender As Object, e As EventArgs) Handles MetroTileHapusJadwal.Click
        Try
            If (connection.State <> ConnectionState.Open) Then
                connection.Open()
            End If

            Dim message As String
            message = MsgBox("Are you sure want to delete this data?  ", vbExclamation + vbYesNo, "Warning")
            If message = vbNo Then Exit Sub

            Dim command As MySqlCommand = connection.CreateCommand()
            command.CommandText = SQLDeleteJadwal

            command.Parameters.AddWithValue("id_jadwal", id_jadwal)

            command.ExecuteNonQuery()
            connection.Close()

            MessageBox.Show("Data berhasil dihapus!")
            LoadJadwal()
            MetroGrid3.Update()
            MetroGrid3.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub


    '--------------------------------Menu Kotak Masuk--------------------------------'


    Private Sub LoadKotakMasuk()
        Me.InboxTableAdapter1.Fill(Me.GammuDataSet1.inbox)
    End Sub

    Private Sub SettingGridKotakMasuk()
        MetroGrid2.Columns(0).Width = 50
        MetroGrid2.Columns(1).Width = 150
        MetroGrid2.Columns(2).Width = 150
    End Sub


    '--------------------------------Menu Kirim Pesan--------------------------------'


    Private Sub LoadComboBoxKategori()
        Try
            If (connection.State <> ConnectionState.Open) Then
                connection.Open()
            End If

            Dim reader As MySqlDataReader
            Dim adapter As MySqlDataAdapter
            adapter = New MySqlDataAdapter(SQLSelectKategori, connection)
            Dim ds As New DataSet()
            adapter.Fill(ds, "pbk_groups")

            With MetroComboBoxKategori
                .DataSource = ds.Tables("pbk_groups")
                .DisplayMember = "Name"
                .ValueMember = "ID"
                .SelectedIndex = 0
            End With

        Catch ex As Exception

        End Try
    End Sub

    Public Shared IDKategori As Integer
    Public Property ID_kategori() As Integer
        Get
            Return IDKategori
        End Get
        Set(value As Integer)

        End Set
    End Property

    Private Sub MetroButtonKirim_Click(sender As Object, e As EventArgs) Handles MetroButtonKirim.Click
        Try
            Dim pesan As String = MetroTextBoxPesan.Text

            If (connection.State <> ConnectionState.Open) Then
                connection.Open()
            End If

            If MetroComboBoxKategori.SelectedValue IsNot Nothing Then
                IDKategori = Convert.ToInt32(MetroComboBoxKategori.SelectedValue)
            End If

            Dim reader As MySqlDataReader
            Dim command As MySqlCommand = connection.CreateCommand()

            If (IDKategori = 1) Then 'Tidak Ada'

                command.CommandText = SQLSendMessage

                command.Parameters.AddWithValue("DestinationNumber", MetroTextBoxTujuan.Text)
                command.Parameters.AddWithValue("TextDecoded", pesan)
                command.Parameters.AddWithValue("CreatorID", "gammu")

                command.ExecuteNonQuery()

            ElseIf (IDKategori = 2) Then 'Hepatitis'
                Dim noTujuan As New List(Of String)
                Dim nomorTujuan As String

                command.CommandText = SQLSelectMessageKategori
                command.Parameters.AddWithValue("GroupID", IDKategori)
                reader = command.ExecuteReader(CommandBehavior.Default)
                While reader.Read()
                    noTujuan.Add(reader.GetString(3))
                End While
                reader.Close()

                For Each nomorTujuan In noTujuan
                    command.CommandText = "INSERT INTO outbox (DestinationNumber, TextDecoded, CreatorID) VALUES('" & nomorTujuan & "','" & pesan & "', 'gammu')"
                    command.ExecuteNonQuery()
                Next
            ElseIf (IDKategori = 3) Then 'Diabetes'
                Dim noTujuan As New List(Of String)
                Dim nomorTujuan As String

                command.CommandText = SQLSelectMessageKategori
                command.Parameters.AddWithValue("GroupID", IDKategori)
                reader = command.ExecuteReader(CommandBehavior.Default)
                While reader.Read()
                    noTujuan.Add(reader.GetString(3))
                End While
                reader.Close()

                For Each nomorTujuan In noTujuan
                    command.CommandText = "INSERT INTO outbox (DestinationNumber, TextDecoded, CreatorID) VALUES('" & nomorTujuan & "','" & pesan & "', 'gammu')"
                    command.ExecuteNonQuery()
                Next
            ElseIf (IDKategori = 4) Then 'Semua Kategori'
                Dim noTujuan As New List(Of String)
                Dim nomorTujuan As String

                command.CommandText = SQLSelectMessageKategoriAll
                reader = command.ExecuteReader(CommandBehavior.Default)
                While reader.Read()
                    noTujuan.Add(reader.GetString(3))
                End While
                reader.Close()

                For Each nomorTujuan In noTujuan
                    command.CommandText = "INSERT INTO outbox (DestinationNumber, TextDecoded, CreatorID) VALUES('" & nomorTujuan & "','" & pesan & "', 'gammu')"
                    command.ExecuteNonQuery()
                Next
            End If

            MessageBox.Show("Pesan Terkirim")

            LoadPesanKeluar()
            MetroGrid4.Update()
            MetroGrid4.Refresh()

            connection.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

    End Sub

    Private Sub MetroTextBoxPesan_TextChanged(sender As Object, e As EventArgs) Handles MetroTextBoxPesan.TextChanged
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        MetroLabelPanjangPesan.Text = MetroTextBoxPesan.Text.Length
    End Sub



    '--------------------------------Menu Pesan Keluar--------------------------------'


    Private Sub LoadPesanKeluar()
        Me.SentitemsTableAdapter1.Fill(Me.GammuDataSet1.sentitems)
    End Sub

    Private Sub MetroTextButtonLogout_Click(sender As Object, e As EventArgs)

        Me.Close()
    End Sub


    '--------------------------------Dashboard--------------------------------'


    Private Sub MetroTileLogout_Click(sender As Object, e As EventArgs)
        Dim loginForm As LoginForm = New LoginForm()
        loginForm.Show()
        Me.Close()
    End Sub


    '--------------------------------Menu Settings--------------------------------'


    Private Sub MetroButtonRun_Click(sender As Object, e As EventArgs) Handles MetroButtonRun.Click
        Dim run As New ProcessStartInfo
        run.WorkingDirectory = "C:\gammu\bin\"
        run.Arguments = "-c smdrc -s"
        run.FileName = "gammu-smsd"
        run.Verb = "runas"
        Process.Start(run)
        MetroLabelStatusGammu.Text = "On"
    End Sub

    Private Sub MetroButtonStop_Click(sender As Object, e As EventArgs) Handles MetroButtonStop.Click
        Dim berhenti As New ProcessStartInfo
        berhenti.WorkingDirectory = "C:\gammu\bin\"
        berhenti.Arguments = "-k"
        berhenti.FileName = "gammu-smsd"
        berhenti.Verb = "runas"
        Process.Start(berhenti)
        MetroLabelStatusGammu.Text = "Off"
    End Sub

    Private Sub MetroButtonLogout_Click(sender As Object, e As EventArgs) Handles MetroButtonLogout.Click
        Dim loginForm As LoginForm = New LoginForm()
        loginForm.Show()
        Me.Close()
    End Sub
End Class
