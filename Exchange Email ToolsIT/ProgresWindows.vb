Imports MetroFramework

Public Class ProgresWindows







    Private Sub ProgresWindows_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim p As New MahApps.Metro.Controls.ProgressRing
        p.Foreground = System.Windows.Media.Brushes.DarkBlue
        p.Width = ElementHost1.Width - Me.Width
        p.Height = ElementHost1.Height
        ElementHost1.Child = p


    End Sub


    Private Sub MetroTile1_Click(sender As Object, e As EventArgs) Handles MetroTile1.Click
        cancelmsg()
    End Sub
    Public Sub cancelmsg()
        Try

            Me.Close()

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

        End Try
    End Sub

   
End Class