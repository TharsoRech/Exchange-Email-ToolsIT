Imports System.Windows.Forms

Public Class frmProcess
    Inherits System.Windows.Forms.Form
    Public MESSAGE As String
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Private components As System.ComponentModel.IContainer
    Friend WithEvents lblMensaje  as  Wisder.W3Common.WMetroControl.Controls.MetroTextBox
    Public TIMERON As Boolean = False

    Private Sub frmProcess_FormClosing(ByVal sender As Object, _
            ByVal e As System.Windows.Forms.FormClosingEventArgs) _
            Handles Me.FormClosing
        Me.Timer1.Enabled = False
    End Sub
    Public Sub CloseIt()
        Me.Close()
        Me.Dispose()
    End Sub
    Public Overloads Sub ShowDialog(ByVal Mensaje As String)
        CheckForIllegalCrossThreadCalls = False
        Try
            TIMERON = True
            Me.Timer1.Enabled = True
            MESSAGE = Mensaje
            Me.lblMensaje.Text = Mensaje
            Me.ShowDialog()
        Catch
        End Try
    End Sub

    Public Sub stopForm()
        TIMERON = False
    End Sub

    Private Sub frmProcess_Load(ByVal sender As System.Object, _
                ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            If TIMERON = False Then
                Me.Close()
                Me.Timer1.Enabled = False
                Me.Dispose()
            Else
                Me.lblMensaje.Text = MESSAGE
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblMensaje =  new  Wisder.W3Common.WMetroControl.Controls.MetroTextBox
        Me.SuspendLayout()
        '
        'lblMensaje
        '
        Me.lblMensaje.Location = New System.Drawing.Point(81, 70)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(100, 20)
        Me.lblMensaje.TabIndex = 0
        '
        'frmProcess
        '
        Me.ClientSize = New System.Drawing.Size(284, 157)
        Me.Controls.Add(Me.lblMensaje)
       me.name = "frmProcess"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class
