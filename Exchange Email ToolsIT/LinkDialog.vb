Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Web
Public Class LinkDialog

    Private _accepted As Boolean = False
    Private Sub linkEdit_TextChanged(sender As Object, e As EventArgs) Handles linkEdit.TextChanged
        label1.Text = comboBox1.Text + linkEdit.Text
    End Sub

    Public Property URL() As String
        Get
            Return linkEdit.Text.Trim()
        End Get
        Set(value As String)
            linkEdit.Text = value
        End Set
    End Property

    Public Property Scheme() As String
        Get
            Return comboBox1.Text
        End Get
        Set(value As String)
            comboBox1.Text = value
        End Set
    End Property

    Public ReadOnly Property Accepted() As Boolean
        Get
            Return _accepted
        End Get
    End Property

    Private Sub LinkDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
        label1.Text = comboBox1.Text + URL
        BeginInvoke(DirectCast(Sub() linkEdit.Focus(), MethodInvoker))
    End Sub

    Private Sub LoadUrls()
     
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        Dim url As String = linkEdit.Text

        _accepted = True
        Close()
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton1.Click
        _accepted = False
        Close()
    End Sub

    Private Sub comboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboBox1.SelectedIndexChanged
        label1.Text = comboBox1.Text + URL
    End Sub


    
End Class