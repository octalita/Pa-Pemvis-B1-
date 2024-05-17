Imports MySql.Data.MySqlClient

Public Class Form1
    Private connectionString As String = "server=localhost;user=root;password=;database=dbtiket;"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtusername.Focus()
        txtpassword.UseSystemPasswordChar = True
        koneksi()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        Dim Username As String = txtusername.Text
        Dim Password As String = txtpassword.Text

        ' Periksa apakah kredensial sesuai dengan admin
        If Username = "admin" And Password = "admin" Then
            MessageBox.Show("Anda Berhasil login sebagai admin!", "Login Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Hide()
            Dim frmForm6 As New Form6
            frmForm6.Show()
        Else
            Dim querySelect As String = "SELECT COUNT(*) FROM tbuser WHERE username = @username AND password = @password"
            Using cmdSelect As New MySqlCommand(querySelect, CONN)
                cmdSelect.Parameters.AddWithValue("@username", Username)
                cmdSelect.Parameters.AddWithValue("@password", Password)
                Dim count As Integer = Convert.ToInt32(cmdSelect.ExecuteScalar())

                If count > 0 Then
                    MessageBox.Show("Login berhasil.", "Login Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Hide()
                    Dim nama As String = txtusername.Text
                    Dim frmForm3 As New Form3
                    frmForm3.Show()
                Else
                    MessageBox.Show("Username atau password salah!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        End If
    End Sub

    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnregistrasi.Click
        Dim frmForm2 As New Form2()
        frmForm2.Show()
        Me.Hide()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        ' Bisa digunakan untuk tindakan tambahan saat label diklik
    End Sub

    Private Sub txtpassword_TextChanged(sender As Object, e As EventArgs) Handles txtpassword.TextChanged
        ' Bisa digunakan untuk tindakan tambahan saat teks password berubah
    End Sub

    Private Sub CheckBoxlihatpassword_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxlihatpassword.CheckedChanged
        txtpassword.UseSystemPasswordChar = Not CheckBoxlihatpassword.Checked
        txtpassword.Focus()
    End Sub
End Class

