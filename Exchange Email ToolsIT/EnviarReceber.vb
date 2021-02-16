Public Class EnviarReceber

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        MyBase.OnSizeChanged(e)
        If Me.WindowState.Equals(FormWindowState.Minimized) Then
            'Do whatever u wanna do
            Me.Hide()
        End If
    End Sub

    Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
        MyBase.OnClosing(e)
        e.Cancel = True
        Me.Hide()

    End Sub




    Private Sub Task1_Load(sender As Object, e As EventArgs) Handles Task1.Load

    End Sub

  
    Private Sub EnviarReceber_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

 
End Class