Imports MetroFramework
Imports Microsoft.Exchange.WebServices.Data
Imports System.Net

Public Class DownloadEmails
    Public canclose As Boolean = False
    Public Sub changetextfolder(ByVal value As String)
        MetroTextBox1.Text = value
        Me.Update()
    End Sub
    Public Sub changetextemail(ByVal value As String)
        MetroTextBox2.Text = value
        Me.Update()
    End Sub

    Public Sub changeprogress(ByVal value As Integer)
        If value > 100 Then
            MetroProgressBar1.Value = 0
            Exit Sub
        End If
        If MetroProgressBar1.Value > 100 Then
            MetroProgressBar1.Value = 0
        End If
        MetroProgressBar1.Value += value
        Me.Update()
        MetroProgressBar1.Update()
    End Sub
    Public Sub changeprogress2(ByVal value As Integer)
        If value > MetroProgressBar2.Maximum Then
            MetroProgressBar2.Value = 0
            Exit Sub
        End If
        If MetroProgressBar2.Value > MetroProgressBar2.Maximum Then
            MetroProgressBar2.Value = 0
        End If
        MetroProgressBar2.Value += value
        Me.Update()
        MetroProgressBar2.Update()
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        canclose = True
        Form1.BackgroundWorker2.CancelAsync()
        Form1.Show()
        Me.Close()

    End Sub


 
  
   
    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)
        If canclose = False Then
            e.Cancel = True
            MetroMessageBox.Show(Me, "Não é possivel Fechar enquanto  esta baixando emails", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Form1.BackgroundWorker2.CancelAsync()

        End If



    End Sub
   


    Private Sub DownloadEmails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BringToFront()
    End Sub
End Class