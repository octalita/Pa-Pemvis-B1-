Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form7

    Private conn As MySqlConnection
    Private cmd As MySqlCommand
    Private rd As MySqlDataReader

    ' Metode untuk menginisialisasi koneksi
    Private Sub koneksi()
        conn = New MySqlConnection("server=localhost;userid=youruserid;password=yourpassword;database=dbtiket")
        Try
            conn.Open()
        Catch ex As MySqlException
            MsgBox("Cannot connect to database: " & ex.Message)
        End Try
    End Sub

    Public Sub addItemsFromDb()
        DataGridView1.Rows.Clear()

        Dim query = "SELECT * FROM tbtiket"
        Try
            cmd = New MySqlCommand(query, conn)
            rd = cmd.ExecuteReader()
            While rd.Read()
                DataGridView1.Rows.Add(rd.Item(0), rd.Item(1), rd.Item(2), rd.Item(3), rd.Item(4), rd.Item(5), rd.Item(6), rd.Item(7))
            End While
        Catch ex As MySqlException
            MsgBox("Error: " & ex.Message)
        Finally
            If rd IsNot Nothing Then rd.Close()
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim ubah As String = "DELETE FROM tbtiket WHERE idTiket = @idTiket"
        Try
            Using CMD As New MySqlCommand(ubah, conn)
                CMD.Parameters.AddWithValue("@idTiket", TextBox2.Text)
                CMD.ExecuteNonQuery()
            End Using
            MsgBox("Data berhasil dihapus")
            addItemsFromDb()
        Catch ex As MySqlException
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        addItemsFromDb()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form6.Show()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then
            Try
                Using CMD As New MySqlCommand("SELECT * FROM tbtiket WHERE idTiket LIKE @idTiket", conn)
                    CMD.Parameters.AddWithValue("@idTiket", "%" & TextBox1.Text & "%")
                    Using RD As MySqlDataReader = CMD.ExecuteReader()
                        If RD.HasRows Then
                            DataGridView1.Rows.Clear()
                            While RD.Read()
                                Dim row As New DataGridViewRow()
                                row.CreateCells(DataGridView1)
                                row.Cells(0).Value = RD("idTiket")
                                row.Cells(1).Value = RD("namaKonser")
                                row.Cells(2).Value = RD("tanggalKonser")
                                row.Cells(3).Value = RD("alamatKonser")
                                row.Cells(4).Value = RD("deskripsi")
                                row.Cells(5).Value = RD("harga")
                                row.Cells(6).Value = RD("gambar")
                                row.Cells(7).Value = RD("stok")
                                DataGridView1.Rows.Add(row)
                            End While
                        Else
                            MsgBox("Data tidak ditemukan")
                        End If
                    End Using
                End Using
            Catch ex As MySqlException
                MsgBox("Error: " & ex.Message)
            End Try
        Else
            addItemsFromDb()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        ' Implementasi jika diperlukan
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim frmForm8 As New Form8()
        frmForm8.Show()
        Me.Hide()
    End Sub
End Class
