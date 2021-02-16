Imports System
Imports System.Net
Imports System.DirectoryServices
Imports AutocompleteMenuNS
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows.Data
Imports System.Drawing
Imports Microsoft.Exchange
Imports Microsoft.Exchange.WebServices.Data
Imports MetroFramework

Public Class LoginForm1
    Public account As User
    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try
            Dim user As String = UsernameTextBox.Text
            Dim pass As String = PasswordTextBox.Text
            Dim server As String = TextBox1.Text
            Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
            service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
            service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
            Dim rootfolder As Folder = Folder.Bind(service, WellKnownFolderName.MsgFolderRoot)
            'A GetFolder operation has been performed.
            'Now do something with the folder, such as display each child folder's name and id.
            rootfolder.Load()
   
            If IO.File.Exists(user & ".Ews") Then
                Dim seri As New ObjectSerializer(Of User)
                account = seri.GetSerializedObject(user & ".Ews")
            Else
                IO.File.Create(user & ".Ews").Close()
                account = New User
                account.user = user
                account.password = pass
                account.server = server
                Dim seri As New ObjectSerializer(Of User)
                seri.SaveSerializedObject(account, user & ".Ews")

            End If
       
            If rootfolder.FindFolders(New FolderView(100)).Count <> 0 Then

                Form1.TextBox1.Text = user
                Form1.TextBox2.Text = pass
                Form1.TextBox3.Text = server
                Form1.TextBox7.Text = TextBox2.Text
                Form1.account = account
                Form1.ToolStripStatusLabel2.Text = "Conectado"
                Form1.Show()
                Me.Close()


            End If
        Catch ep As Exception
            Form1.ToolStripStatusLabel2.Text = "Offline"
            MetroMessageBox.Show(Me, ep.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Application.Exit()
    End Sub

    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Update()
            Me.Refresh()
            Dim files As String() = System.IO.Directory.GetFiles(My.Application.Info.DirectoryPath, "*.ews")
            If files.Count = 1 Then
                For Each f As String In files
                    Me.Update()
                    Me.Refresh()
                    If IO.File.Exists(f) And f.ToLower.Contains("@") Then

                        Dim seri As New ObjectSerializer(Of User)
                        account = seri.GetSerializedObject(f)
                        If account Is Nothing Then
                            MetroMessageBox.Show(Me, "Arquivo Corrompido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        Else

                            PasswordTextBox.Text = account.password
                            UsernameTextBox.Text = account.user
                            TextBox1.Text = account.server
                            OK.PerformClick()


                        End If


                    Else

                    End If
                Next
            ElseIf files.Count > 1 Then
                If My.Settings.ContaPadrao <> """" Then
                    Dim seri As New ObjectSerializer(Of User)
                    account = seri.GetSerializedObject(My.Settings.ContaPadrao)
                    PasswordTextBox.Text = account.password
                    UsernameTextBox.Text = account.user
                    TextBox1.Text = account.server
                    OK.PerformClick()
                    Exit Sub
                End If
                Form1.Hide()
                ChooseAccount.Show()
                ChooseAccount.BringToFront()
                Me.Hide()
           

            End If

        Catch ex As Exception

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub base64Decode(ByVal sData As String)
        Try
            Dim encoder As New System.Text.UTF8Encoding()
            Dim utf8Decode As System.Text.Decoder = encoder.GetDecoder()
            Dim todecode_byte As Byte() = Convert.FromBase64String(sData)
            Dim charCount As Integer = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length)
            Dim decoded_char As Char() = New Char(charCount - 1) {}
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0)
            Dim result As String = New [String](decoded_char)
            PasswordTextBox.Text = result
        Catch ex As Exception

        End Try
    End Sub




 
End Class
