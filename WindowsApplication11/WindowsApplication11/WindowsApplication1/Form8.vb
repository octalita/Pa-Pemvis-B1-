Public Class Form8

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim align As New StringFormat()
        align.Alignment = StringAlignment.Near
        e.Graphics.DrawString("Contoh Alignment Near", Font, black, 827 / 2,
        e.MarginBounds.Top, align)
        align.Alignment = StringAlignment.Center
        e.Graphics.DrawString("Contoh Alignment Center", Font, black, 827 / 2,
        e.MarginBounds.Top + 30, align)
        align.Alignment = StringAlignment.Far
        e.Graphics.DrawString("Contoh Alignment Far", Font, black, 827 / 2,
        e.MarginBounds.Top + 60, align)
    End Sub
End Class