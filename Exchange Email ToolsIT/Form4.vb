Imports System
Imports System.Net
Imports System.DirectoryServices
Imports Microsoft.Exchange.WebServices.Data
Imports MetroFramework

Public Class Form4
    Dim stopsearch As Boolean = True
    Dim pass As String = Form1.TextBox2.Text
    Dim user As String = Form1.TextBox1.Text
    Dim server As String = Form1.RichTextBox3.Text
    Dim firsttime As Boolean = False

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BringToFront()
        TimeDelay()
        Timer1.Enabled = True

    End Sub
    Public Sub sincronizefolders()
        firsttime = True
        Dim pass As String = Form1.TextBox2.Text
        Dim user As String = Form1.TextBox1.Text
        Dim server As String = Form1.TextBox3.Text
        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try
            Dim rootfolder As Folder = Folder.Bind(service, WellKnownFolderName.MsgFolderRoot)
            For Each folder In rootfolder.FindFolders(New FolderView(100))
                TimeDelay()
                folder.Load()
                If folder.IsNew Then

                    MetroMessageBox.Show(Me, "Nova Pasta Achanda,Atualize a lista de pastas",me.text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If


            Next
            Me.Close()
        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message,me.text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub





    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        stopsearch = False
        Me.Close()
    End Sub
    Private Sub TimeDelay()
        Try
            stopsearch = True
            Do While stopsearch = True
                Me.Refresh()
                Application.DoEvents()
                ProgressBar1.Refresh()
                stopsearch = False
            Loop
        Catch ex As Exception

        End Try




    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If firsttime = False Then
            TimeDelay()

            sincronizefolders()
        Else
            TimeDelay()
        End If
    End Sub

  
End Class