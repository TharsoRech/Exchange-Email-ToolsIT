Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Abhinaba.TransDlg
Imports Microsoft.Exchange.WebServices.Data

Namespace DiffuseDlgDemo
    Public Class Notification
        Inherits TransDialog
#Region "Ctor, init code and dispose"
        Public Sub New()
            MyBase.New(True)
            InitializeComponent()
        End Sub

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing Then
                If components IsNot Nothing Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub
#End Region

#Region "Event handler"
        Private Sub Notification_Load(sender As Object, e As System.EventArgs)
            Try
                Dim screenWidth As Integer = Screen.PrimaryScreen.WorkingArea.Width
                Dim screenHeight As Integer = Screen.PrimaryScreen.WorkingArea.Height
                Me.Left = screenWidth - Me.Width
                Me.Top = screenHeight - Me.Height

                timer1.Enabled = True
            Catch ex As Exception

            End Try
        End Sub
        Public Property email As EmailMessage

        Private Sub timer1_Tick(sender As Object, e As System.EventArgs) Handles timer1.Tick
            Me.Close()
        End Sub

        Private Sub linkLabel1_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked
            Try
                Form1.Update()
                Form1.BringToFront()
                Form1.Show()
                Form1.seacrhmsgbysubject45(email.InternetMessageId)
                Form1.TimeDelay()
                Form1.TimeDelay()
                Form1.TimeDelay()
                Form1.TimeDelay()
                Form1.openemaileviewer(email.InternetMessageId)
                Me.Close()
            Catch ex As Exception

            End Try
        End Sub
#End Region

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Notification))
            Me.label1 = New System.Windows.Forms.Label()
            Me.pictureBox1 = New System.Windows.Forms.PictureBox()
            Me.timer1 = New System.Windows.Forms.Timer(Me.components)
            Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.MetroPanel1 = New Wisder.W3Common.WMetroControl.Controls.MetroPanel()
            CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'label1
            '
            Me.label1.ForeColor = System.Drawing.Color.Black
            Me.label1.Location = New System.Drawing.Point(92, 60)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(96, 16)
            Me.label1.TabIndex = 0
            '
            'pictureBox1
            '
            Me.pictureBox1.Image = CType(resources.GetObject("pictureBox1.Image"), System.Drawing.Image)
            Me.pictureBox1.Location = New System.Drawing.Point(12, 9)
            Me.pictureBox1.Name = "pictureBox1"
            Me.pictureBox1.Size = New System.Drawing.Size(69, 67)
            Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.pictureBox1.TabIndex = 1
            Me.pictureBox1.TabStop = False
            '
            'timer1
            '
            Me.timer1.Interval = 10000
            '
            'linkLabel1
            '
            Me.linkLabel1.Font = New System.Drawing.Font("Monotype Corsiva", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.linkLabel1.Location = New System.Drawing.Point(92, 29)
            Me.linkLabel1.Name = "linkLabel1"
            Me.linkLabel1.Size = New System.Drawing.Size(96, 22)
            Me.linkLabel1.TabIndex = 2
            Me.linkLabel1.TabStop = True
            Me.linkLabel1.Text = "Novo Email"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("Monotype Corsiva", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(92, 9)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(129, 18)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "Novo Emal Recebido"
            '
            'MetroPanel1
            '
            Me.MetroPanel1.BackColor = System.Drawing.Color.Transparent
            Me.MetroPanel1.BackgroundImage = CType(resources.GetObject("MetroPanel1.BackgroundImage"), System.Drawing.Image)
            Me.MetroPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.MetroPanel1.HorizontalScrollbarBarColor = True
            Me.MetroPanel1.HorizontalScrollbarHighlightOnWheel = False
            Me.MetroPanel1.HorizontalScrollbarSize = 10
            Me.MetroPanel1.Location = New System.Drawing.Point(181, 54)
            Me.MetroPanel1.Name = "MetroPanel1"
            Me.MetroPanel1.Size = New System.Drawing.Size(41, 24)
            Me.MetroPanel1.TabIndex = 4
            Me.MetroPanel1.UseCustomBackColor = True
            Me.MetroPanel1.VerticalScrollbarBarColor = True
            Me.MetroPanel1.VerticalScrollbarHighlightOnWheel = False
            Me.MetroPanel1.VerticalScrollbarSize = 10
            '
            'Notification
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.White
            Me.ClientSize = New System.Drawing.Size(234, 88)
            Me.Controls.Add(Me.MetroPanel1)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.linkLabel1)
            Me.Controls.Add(Me.pictureBox1)
            Me.Controls.Add(Me.label1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "Notification"
            Me.ShowInTaskbar = False
            Me.Text = "Notification"
            Me.TopMost = True
            CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents label1 As System.Windows.Forms.Label
#End Region

#Region "Designer generated variables"
        Private pictureBox1 As System.Windows.Forms.PictureBox
        Private WithEvents timer1 As System.Windows.Forms.Timer
        Public WithEvents linkLabel1 As System.Windows.Forms.LinkLabel
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents MetroPanel1 As Wisder.W3Common.WMetroControl.Controls.MetroPanel
        Private components As System.ComponentModel.IContainer
#End Region

        Private Sub Notification_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
            Try
                Dim screenWidth As Integer = Screen.PrimaryScreen.WorkingArea.Width
                Dim screenHeight As Integer = Screen.PrimaryScreen.WorkingArea.Height
                Me.Left = screenWidth - Me.Width
                Me.Top = screenHeight - Me.Height

                timer1.Enabled = True
            Catch ex As Exception

            End Try
        End Sub


        Private Sub MetroButton1_Click(sender As Object, e As EventArgs)
            Try
                Me.Close()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub MetroPanel1_Paint(sender As Object, e As PaintEventArgs) Handles MetroPanel1.Paint
            Try
                Me.Close()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

        End Sub
    End Class
End Namespace
