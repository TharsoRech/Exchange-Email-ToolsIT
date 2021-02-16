Imports MetroFramework

Public Class Form5
  
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub





    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            TextBox2.Text = Form1.TextBox1.Text
            TextBox1.Text = Form1.TextBox3.Text
            If Form1.account IsNot Nothing Then
                TextBox3.Text = Form1.account.PstFile
            End If

            If Form1.account.assinatura IsNot Nothing Then
                MetroButton2.Enabled = False
                MetroButton1.Enabled = True
                MetroTextBox1.PromptText = Form1.account.assinatura
            Else
                MetroButton2.Enabled = True
            End If
            Dim files As String() = System.IO.Directory.GetFiles(My.Application.Info.DirectoryPath, "*.ews")
                For Each f As String In files
                    If IO.File.Exists(f) And f.ToLower.Contains("@") Then
                        Dim account1 As User
                        Dim seri1 As New ObjectSerializer(Of User)
                        account1 = seri1.GetSerializedObject(f)
                        If account1 IsNot Nothing Then
                            Dim row1 As String() = New String() {account1.user, account1.server, f}
                            MetroGrid2.Rows.Add(row1)
                        End If
                End If
                Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
    
            If CheckBox1.Checked Then
                IO.File.Delete(TextBox2.Text & "Folders" & ".FL")
                IO.File.Delete(TextBox2.Text & ".Ews")
                Application.Restart()
            Else
                Me.Close()
            End If
        Catch ex As Exception

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            OpenFileDialog1.Filter = "PST Files (.PST)|*.pst"
            If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                TextBox3.Text = OpenFileDialog1.FileName
                If Form1.account IsNot Nothing Then
                    Form1.account.PstFile = TextBox3.Text
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            TextBox3.Text = Nothing
            If Form1.account IsNot Nothing Then
                Form1.account.PstFile = ""
            End If
        Catch ex As Exception

        End Try
    End Sub







    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Try
            Form1.account.assinatura = ""
            Form1.save()
            MetroTextBox1.Text = ""
            MetroButton2.Enabled = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Try
            NovaAssinatura.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        Try
            '  NovaAssinatura.Editor1.doc.designMode = "Off"
            NovaAssinatura.Show()
            Dim Path As String = Application.StartupPath & "\" & Form1.account.assinatura
            NovaAssinatura.Editor1.webBrowser1.DocumentText = "<html>" & "<img src='" & Path & "' />" & "<html/>"

        Catch ex As Exception

        End Try
    End Sub

    Private Sub MetroButton4_Click(sender As Object, e As EventArgs)
        Try
            For Each f1 As FolderEmail In Form1.account.folders(0).items
                If f1.name.ToLower.Contains(Form1.Label2.Text.ToLower) Then
                    For Each m1 As Email In f1.emails.emails
                        f1.emails.emails.Remove(m1)
                        Form1.save()

                    Next
                End If
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub MetroButton4_Click_1(sender As Object, e As EventArgs) Handles MetroButton4.Click
        Try
            If MetroGrid2.SelectedRows(0) IsNot Nothing Then
                Dim seri10 As New ObjectSerializer(Of User)
                AccountEdit.account1 = seri10.GetSerializedObject(MetroGrid2.SelectedRows(0).Cells(2).Value)
                AccountEdit.TextBox1.Text = AccountEdit.account1.user
                AccountEdit.MetroTextBox2.Text = AccountEdit.account1.password
                AccountEdit.MetroTextBox1.Text = AccountEdit.account1.server
                AccountEdit.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MetroButton5_Click(sender As Object, e As EventArgs) Handles MetroButton5.Click
        Try
            AddAccount.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MetroButton6_Click(sender As Object, e As EventArgs) Handles MetroButton6.Click
        Try
            If MetroGrid2.SelectedRows(0) IsNot Nothing Then
                If MetroGrid2.Rows.Count > 1 Then
                    IO.File.Delete(MetroGrid2.SelectedRows(0).Cells(2).Value)
                    MetroGrid2.Rows.Remove(MetroGrid2.SelectedRows(0))
                    MetroMessageBox.Show(Me, "Conta Removida Com Sucesso!!! ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    IO.File.Delete(MetroGrid2.SelectedRows(0).Cells(2).Value)
                    MetroGrid2.Rows.Remove(MetroGrid2.SelectedRows(0))
                    MetroMessageBox.Show(Me, "Conta Removida Com Sucesso,Sera Preciso Reiniciar o aplicativo ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Application.Restart()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MetroButton7_Click(sender As Object, e As EventArgs) Handles MetroButton7.Click
        Try
            ChooseAccount.Show()
        Catch ex As Exception

        End Try
    End Sub
End Class