Imports MySql.Data.MySqlClient
Imports System.IO
Public Class Form6
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CMD = New MySqlCommand("insert into tbtiket (idTiket, namaKonser, tanggalKonser, alamatKonser, deskripsi, harga, gambar, stok) values ('""', '" & TextBox2.Text & "', '" & DateTimePicker1.Text & "', '" & TextBox5.Text & "', '" & TextBox6.Text & "', '" & TextBox3.Text & "', '" & Label8.Text & "', '" & TextBox4.Text & "')", CONN)
        CMD.ExecuteNonQuery()
        MsgBox("Simpan Data Sukses!")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "Gambar|*.jpg;.png;.jpeg;"
        If openFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim filePath As String = openFileDialog.FileName
            Dim fileName As String = Path.GetFileName(filePath)
            Dim directoryName As String = Path.GetDirectoryName(filePath)
            Label8.Text = fileName

            Dim targetDirectory As String = "..\assets\images\"
            If Not Directory.Exists(targetDirectory) Then
                Directory.CreateDirectory(targetDirectory)
            End If
            Dim targetFilePath As String = Path.Combine(targetDirectory, fileName)
            File.Copy(filePath, targetFilePath, True)
            PictureBox1.BackgroundImage = Image.FromFile(targetFilePath)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Form7.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim ubah As String = "update tbtiket set namaKonser = '" & TextBox2.Text & "', tanggalKonser = '" & DateTimePicker1.Text & "', alamatKonser = '" & TextBox5.Text & "', deskripsi = '" & TextBox6.Text & "', harga = '" & TextBox3.Text & "', gambar = '" & Label8.Text & "', stok = '" & TextBox4.Text & "' where idTiket = '" & TextBox1.Text & "'"
        CMD = New MySqlCommand(ubah, CONN)
        CMD.ExecuteNonQuery()
        MsgBox("Data berhasil diubah")
    End Sub

End Class