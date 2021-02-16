Imports System.ComponentModel

Public Class SelectEmails

    Property worker As BackgroundWorker

    Private Sub Cancelar_Click(sender As Object, e As EventArgs) Handles Cancelar.Click
        If worker IsNot Nothing Then
            worker.CancelAsync()
        End If

        Me.Close()
    End Sub

    Private Sub SelectEmails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BringToFront()
    End Sub
End Class