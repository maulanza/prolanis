Imports MySql.Data.MySqlClient

Public Class LoginForm
    Public SQLLogin As String = "SELECT * FROM tb_admin WHERE username = ? AND password = ?"
    Private Sub cekKoneksi()
        Dim mainForm As MainForm = New MainForm()
        Try
            mainForm.connection.Open()
        Catch ex As Exception
            MsgBox("Cek Koneksi!")
            mainForm.connection.Close()
        End Try
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MetroTextBoxPassword.UseSystemPasswordChar = True
        cekKoneksi()
    End Sub

    Private Sub MetroButtonLogin_Click(sender As Object, e As EventArgs) Handles MetroButtonLogin.Click
        Dim mainForm As MainForm = New MainForm()
        Try
            mainForm.connection.Open()
            'strSql = String.Format("SELECT * FROM tb_admin WHERE username = '{0}' AND password = '{1}'", Me.MetroTextBoxUsername.Text.Trim(), Me.MetroTextBoxPassword.Text.Trim())

            Dim nilai As Boolean = False
            Dim reader As MySqlDataReader
            Dim command As MySqlCommand = mainForm.connection.CreateCommand()
            command.CommandText = SQLLogin

            command.Parameters.AddWithValue("username", MetroTextBoxUsername.Text)
            command.Parameters.AddWithValue("password", MetroTextBoxPassword.Text)
            reader = command.ExecuteReader(CommandBehavior.Default)
            If reader.HasRows Then
                reader.Read()
                nilai = True
            Else
                MessageBox.Show("Log In gagal!")
            End If

            mainForm.connection.Close()
            If (nilai = True) Then
                mainForm.Show()
            End If
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
End Class