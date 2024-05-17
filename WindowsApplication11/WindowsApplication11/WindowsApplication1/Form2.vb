Imports MySql.Data.MySqlClient

Public Class Form2

    Dim connectionString As String = "server=localhost;user=root;password=;database=dbtiket;"


    Private Sub btnregis_Click(sender As Object, e As EventArgs) Handles btnregistrasi.Click
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Periksa apakah nama atau username sudah digunakan
                Dim queryCheck As String = "SELECT COUNT(*) FROM tbuser WHERE NamaUser = @nama OR username = @username"
                Using cmdCheck As New MySqlCommand(queryCheck, conn)
                    cmdCheck.Parameters.AddWithValue("@nama", txtnama.Text)
                    cmdCheck.Parameters.AddWithValue("@username", txtusername.Text)

                    Dim count As Integer = Convert.ToInt32(cmdCheck.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("Nama atau username sudah digunakan. Silakan pilih yang lain.")
                    Else
                        ' Jika tidak ada yang sama, lakukan registrasi
                        Dim queryInsert As String = "INSERT INTO tbuser (IdUser, Username, Password, NamaUser) VALUES ('', @username, @password, @nama)"
                        Using cmdInsert As New MySqlCommand(queryInsert, conn)
                            cmdInsert.Parameters.AddWithValue("@nama", txtnama.Text)
                            cmdInsert.Parameters.AddWithValue("@username", txtusername.Text)
                            cmdInsert.Parameters.AddWithValue("@password", txtpassword.Text)
                            cmdInsert.ExecuteNonQuery()
                            MessageBox.Show("Registrasi berhasil.")
                        End Using
                    End If
                End Using
            End Using

            ' Setelah registrasi berhasil, tampilkan Form1 dan sembunyikan Form2
            Dim form1 As New Form1()
            form1.Show()
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message)
        End Try
    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        ' Tombol "Back" akan kembali ke Form1
        Dim form1 As New Form1()
        form1.Show()
        Me.Hide()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class