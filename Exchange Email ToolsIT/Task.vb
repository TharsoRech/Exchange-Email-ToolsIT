Imports ARBOControls.ARBOScrollableListBox
Public Class Task

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        MetroGrid1.Rows.Clear()
    End Sub
    Public Sub adderror(ByVal errorr As String, ByVal descripition As String, ByVal stacktrace As String, ByVal datatime As String)
        Try

            Dim row As DataGridViewRow = DirectCast(MetroGrid1.Rows(0).Clone(), DataGridViewRow)
            Dim row1 As String() = New String() {errorr, descripition, stacktrace, datatime}
            MetroGrid1.Rows.Add(row1)

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub








    Public Sub clearlist()
        Try
            Do
                If ArboScrollableListBox1.panelControls.Controls.Count = 0 Then Exit Do
                Dim c As TaskControl = TryCast(ArboScrollableListBox1.panelControls.Controls(0), TaskControl)
                If c.thmessage IsNot Nothing And c.thmessage.IsAlive Then
                    c.thmessage.Abort()
                End If
                ArboScrollableListBox1.BeginUpdate()
                ArboScrollableListBox1.Remove(c)
                ' remove the event hook
                ' now dispose off properly
                c.Dispose()
                ArboScrollableListBox1.EndUpdate()
            Loop
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub clearlist(ByVal c As TaskControl)
        Try
            ArboScrollableListBox1.BeginUpdate()
            ArboScrollableListBox1.Remove(c)
            c.Dispose()
            ArboScrollableListBox1.EndUpdate()
        Catch ex As Exception

        End Try
    End Sub



    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Try
            clearlist()
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    



End Class
