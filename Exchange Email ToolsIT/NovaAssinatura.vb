Imports System.IO
Imports System.Text

Public Class NovaAssinatura

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Try
            Form1.ConvertHtmlToImage(Editor1.DocumentText).Save(Form1.account.user & ".Jpeg", Imaging.ImageFormat.Jpeg)

            Form1.account.assinatura = Form1.account.user & ".Jpeg"
            Form1.save()
            Form5.Close()
            Form5.Show()

            Me.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Me.Close()
    End Sub


    Private Sub MetroButton3_Click(sender As Object, e As EventArgs) Handles MetroButton3.Click
        Try
            SaveFileDialog1.Filter = "Html (.Html)|*.Html"
            If SaveFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                Using fs As New IO.FileStream(SaveFileDialog1.FileName, FileMode.Create)
                    Using w As New IO.StreamWriter(fs, Encoding.UTF8)
                        w.WriteLine(Editor1.DocumentText)

                    End Using
                    fs.Close()
                End Using
            End If
        Catch ex As Exception
        End Try
    End Sub




    Private Sub MetroButton4_Click(sender As Object, e As EventArgs) Handles MetroButton4.Click
        Try
            OpenFileDialog1.Filter = "Html (.Html)|*.Html"
            If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                Dim html As String = IO.File.ReadAllText(OpenFileDialog1.FileName)
                Editor1.webBrowser1.DocumentText = html
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub NovaAssinatura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If IO.File.Exists(Form1.account.assinatura) Then
                Dim html As String = IO.File.ReadAllText(Form1.account.assinatura)
                Editor1.webBrowser1.DocumentText = html
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Editor1_Load(sender As Object, e As EventArgs) Handles Editor1.Load

    End Sub
End Class