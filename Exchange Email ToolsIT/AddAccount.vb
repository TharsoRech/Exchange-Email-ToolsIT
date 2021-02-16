Imports MetroFramework
Imports Microsoft.Exchange.WebServices.Data

Public Class AddAccount
    Dim account1 As User
    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Try
            Dim user As String = TextBox1.Text
            Dim pass As String = MetroTextBox2.Text
            Dim server As String = MetroTextBox1.Text
            Dim service1 As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
            service1.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
            service1.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
            Dim rootfolder As Folder = Folder.Bind(service1, WellKnownFolderName.MsgFolderRoot)
            'A GetFolder operation has been performed.
            'Now do something with the folder, such as display each child folder's name and id.
            rootfolder.Load()
            If IO.File.Exists(user & ".Ews") Then
                MetroMessageBox.Show(Me, "Conta Já existente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                IO.File.Create(user & ".Ews").Close()
                account1 = New User
                account1.user = user
                account1.password = pass
                account1.server = server
                Dim seri As New ObjectSerializer(Of User)
                seri.SaveSerializedObject(account1, user & ".Ews")
                MetroMessageBox.Show(Me, "Conta Adicionada Com Sucesso,Para usar  Reinicie o Exchange Email ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Form5.Close()
                Form5.Show()
            End If
            Me.Close()
        Catch ex As Exception
            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class