Public Class AccountEdit
    Public account1 As User
 
    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Try
            If account1 IsNot Nothing Then
                account1.user = TextBox1.Text
                account1.password = MetroTextBox2.Text
                account1.server = MetroTextBox1.Text
                Dim seri6 As New ObjectSerializer(Of User)
                seri6.SaveSerializedObject(account1, Form1.TextBox1.Text & ".Ews")
            End If
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

  
End Class