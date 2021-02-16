Imports MetroFramework

Public Class ChooseAccount



    Private Sub ChooseAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim files As String() = System.IO.Directory.GetFiles(My.Application.Info.DirectoryPath, "*.ews")

            For Each f As String In files
                MetroComboBox1.Items.Add(IO.Path.GetFileName(f))
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Try
            If Form1.account Is Nothing Then
                Process.GetCurrentProcess.Kill()
            Else
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Try
    
            My.Settings.ContaPadrao = My.Application.Info.DirectoryPath & "\" & MetroComboBox1.SelectedItem.ToString
            My.Settings.Save()
            If Form1.account Is Nothing Then
                Application.Restart()
            Else
                MetroMessageBox.Show(Me, "Para usar esta conta reinicie o aplicativo ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class