<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DownloadEmails
    Inherits Wisder.W3Common.WMetroControl.Forms.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DownloadEmails))
        Me.MetroProgressBar1 = New Wisder.W3Common.WMetroControl.Controls.MetroProgressBar()
        Me.MetroLabel1 = New Wisder.W3Common.WMetroControl.Controls.MetroLabel()
        Me.MetroLabel2 = New Wisder.W3Common.WMetroControl.Controls.MetroLabel()
        Me.MetroButton1 = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.MetroTextBox1 = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.MetroTextBox2 = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.MetroLabel3 = New Wisder.W3Common.WMetroControl.Controls.MetroLabel()
        Me.MetroProgressBar2 = New Wisder.W3Common.WMetroControl.Controls.MetroProgressBar()
        Me.MetroLabel5 = New Wisder.W3Common.WMetroControl.Controls.MetroLabel()
        Me.MetroLabel4 = New Wisder.W3Common.WMetroControl.Controls.MetroLabel()
        Me.SuspendLayout()
        '
        'MetroProgressBar1
        '
        Me.MetroProgressBar1.HideProgressText = False
        Me.MetroProgressBar1.Location = New System.Drawing.Point(13, 172)
        Me.MetroProgressBar1.Name = "MetroProgressBar1"
        Me.MetroProgressBar1.Size = New System.Drawing.Size(798, 33)
        Me.MetroProgressBar1.TabIndex = 0
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(10, 60)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(43, 19)
        Me.MetroLabel1.TabIndex = 1
        Me.MetroLabel1.Text = "Pasta:"
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(9, 98)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(44, 19)
        Me.MetroLabel2.TabIndex = 2
        Me.MetroLabel2.Text = "Email:"
        '
        'MetroButton1
        '
        Me.MetroButton1.Location = New System.Drawing.Point(724, 225)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(86, 23)
        Me.MetroButton1.TabIndex = 4
        Me.MetroButton1.Text = "Cancelar"
        Me.MetroButton1.UseSelectable = True
        Me.MetroButton1.UseVisualStyleBackColor = True
        '
        'MetroTextBox1
        '
        Me.MetroTextBox1.Lines = New String(-1) {}
        Me.MetroTextBox1.Location = New System.Drawing.Point(73, 63)
        Me.MetroTextBox1.MaxLength = 32767
        Me.MetroTextBox1.Name = "MetroTextBox1"
        Me.MetroTextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox1.ReadOnly = True
        Me.MetroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox1.SelectedText = ""
        Me.MetroTextBox1.Size = New System.Drawing.Size(737, 23)
        Me.MetroTextBox1.TabIndex = 5
        Me.MetroTextBox1.UseSelectable = True
        '
        'MetroTextBox2
        '
        Me.MetroTextBox2.Lines = New String(-1) {}
        Me.MetroTextBox2.Location = New System.Drawing.Point(73, 98)
        Me.MetroTextBox2.MaxLength = 32767
        Me.MetroTextBox2.Name = "MetroTextBox2"
        Me.MetroTextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox2.ReadOnly = True
        Me.MetroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox2.SelectedText = ""
        Me.MetroTextBox2.Size = New System.Drawing.Size(738, 23)
        Me.MetroTextBox2.TabIndex = 6
        Me.MetroTextBox2.UseSelectable = True
        '
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = True
        Me.MetroLabel3.Location = New System.Drawing.Point(10, 242)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(709, 19)
        Me.MetroLabel3.TabIndex = 7
        Me.MetroLabel3.Text = "Obs: O download dos email é para maior rapidez na leiitura dos emails ,caso queir" & _
    "a cancelar aperte no botão do lado."
        '
        'MetroProgressBar2
        '
        Me.MetroProgressBar2.HideProgressText = False
        Me.MetroProgressBar2.Location = New System.Drawing.Point(86, 136)
        Me.MetroProgressBar2.Name = "MetroProgressBar2"
        Me.MetroProgressBar2.Size = New System.Drawing.Size(724, 30)
        Me.MetroProgressBar2.TabIndex = 9
        '
        'MetroLabel5
        '
        Me.MetroLabel5.AutoSize = True
        Me.MetroLabel5.Location = New System.Drawing.Point(9, 136)
        Me.MetroLabel5.Name = "MetroLabel5"
        Me.MetroLabel5.Size = New System.Drawing.Size(53, 19)
        Me.MetroLabel5.TabIndex = 10
        Me.MetroLabel5.Text = "Emails :"
        '
        'MetroLabel4
        '
        Me.MetroLabel4.AutoSize = True
        Me.MetroLabel4.Location = New System.Drawing.Point(325, 208)
        Me.MetroLabel4.Name = "MetroLabel4"
        Me.MetroLabel4.Size = New System.Drawing.Size(0, 0)
        Me.MetroLabel4.TabIndex = 11
        '
        'DownloadEmails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 268)
        Me.Controls.Add(Me.MetroLabel4)
        Me.Controls.Add(Me.MetroLabel5)
        Me.Controls.Add(Me.MetroProgressBar2)
        Me.Controls.Add(Me.MetroLabel3)
        Me.Controls.Add(Me.MetroTextBox2)
        Me.Controls.Add(Me.MetroTextBox1)
        Me.Controls.Add(Me.MetroButton1)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.MetroProgressBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "DownloadEmails"
        Me.ShadowType = Wisder.W3Common.WMetroControl.Forms.MetroFormShadowType.SystemShadow
        Me.Text = "Baixando Emails:"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MetroLabel1 As Wisder.W3Common.WMetroControl.Controls.MetroLabel
    Friend WithEvents MetroLabel2 As Wisder.W3Common.WMetroControl.Controls.MetroLabel
    Friend WithEvents MetroButton1 As Wisder.W3Common.WMetroControl.Controls.MetroButton
    Friend WithEvents MetroLabel3 As Wisder.W3Common.WMetroControl.Controls.MetroLabel
    Public WithEvents MetroProgressBar1 As Wisder.W3Common.WMetroControl.Controls.MetroProgressBar
    Public WithEvents MetroTextBox1 As Wisder.W3Common.WMetroControl.Controls.MetroTextBox
    Public WithEvents MetroTextBox2 As Wisder.W3Common.WMetroControl.Controls.MetroTextBox
    Public WithEvents MetroProgressBar2 As Wisder.W3Common.WMetroControl.Controls.MetroProgressBar
    Friend WithEvents MetroLabel5 As Wisder.W3Common.WMetroControl.Controls.MetroLabel
    Friend WithEvents MetroLabel4 As Wisder.W3Common.WMetroControl.Controls.MetroLabel
End Class
