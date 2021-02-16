Public Class Form3
    Public forming As Form2

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ListView1.Columns.Add("Nome", 150, HorizontalAlignment.Left)
            ListView1.Columns.Add("Email", 200, HorizontalAlignment.Left)
            Form1.listusers()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Try
            Form1.searchcontacts()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ListView1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseDoubleClick
        Try
            Dim selrow As Integer = ListView1.FocusedItem.Index
            RichTextBox1.SelectionLength = 1
            RichTextBox1.SelectedText = ListView1.Items(selrow).SubItems(1).Text + Space(2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If ListView1.SelectedItems.Count > 0 Then
                Dim selrow As Integer = ListView1.FocusedItem.Index
                RichTextBox1.SelectionLength = 1
                RichTextBox1.SelectedText = ListView1.Items(selrow).SubItems(1).Text + Space(2)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If ListView1.SelectedItems.Count > 0 Then
                Dim selrow As Integer = ListView1.FocusedItem.Index
                RichTextBox2.SelectionLength = 1
                RichTextBox2.SelectedText = ListView1.Items(selrow).SubItems(1).Text + Space(2)

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If RichTextBox1.Text <> "" Then
                forming.RichTextBox2.AppendText(RichTextBox1.Text)
            End If
            If RichTextBox2.Text <> "" Then
                forming.RichTextBox3.AppendText(RichTextBox2.Text)
            End If
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub


   
   
 
End Class