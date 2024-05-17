Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Membaca semua entri dari database terlebih dahulu
        Dim gambarList As New List(Of String)
        CMD = New MySqlCommand("select * from tbtiket", CONN)
        RD = CMD.ExecuteReader()
        While RD.Read()
            gambarList.Add(RD("gambar"))
        End While
        RD.Close()

        For Each gambar As String In gambarList
            Dim filePath As String = "..\assets\images\" & gambar
            If File.Exists(filePath) Then
                Dim pic As New PictureBox() With {
                    .Size = New Drawing.Size(70, 100),
                    .BorderStyle = BorderStyle.FixedSingle,
                    .SizeMode = PictureBoxSizeMode.StretchImage,
                    .Location = New Point(20, 35),
                    .Image = Image.FromFile(filePath)
                }
                Dim cbox As New Button() With {
                    .Size = New Drawing.Size(70, 20),
                    .Location = New Point(20, 150),
                    .Text = "Pesan"
                }
                Dim lbl As New Label() With {
                    .Text = gambar,
                    .AutoSize = True,
                    .Location = New Point(10, 10)
                }
                Dim panel As New Panel() With {
                    .Size = New Drawing.Size(110, 180)
                }
                panel.Controls.Add(pic)
                panel.Controls.Add(lbl) ' Tambahkan label di bawah gambar
                panel.Controls.Add(cbox) ' Tambahkan button di bawah label
                FlowLayoutPanel1.Controls.Add(panel)
                AddHandler cbox.Click, AddressOf Me.Button_Click
            End If
        Next
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs)
        Dim clickedButton As Button = CType(sender, Button)
        Dim panel As Panel = CType(clickedButton.Parent, Panel)
        Dim lbl As Label = panel.Controls.OfType(Of Label)().FirstOrDefault()
        Dim url As String = "https://web.whatsapp.com/"

        If lbl IsNot Nothing Then
            Dim gambarName As String = lbl.Text
            Try
                Process.Start(New ProcessStartInfo(url) With {
                    .UseShellExecute = True
                })
            Catch ex As Exception
                MsgBox("Failed to open URL: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub
End Class
