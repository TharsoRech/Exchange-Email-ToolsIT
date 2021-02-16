<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TaskControl
    Inherits Wisder.W3Common.WMetroControl.Controls.MetroUserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.MetroProgressBar1 = New Wisder.W3Common.WMetroControl.Controls.MetroProgressBar()
        Me.WTextBox1 = New Wisder.W3Common.WControl.WTextBox()
        Me.MetroButton1 = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.SuspendLayout()
        '
        'MetroProgressBar1
        '
        Me.MetroProgressBar1.Location = New System.Drawing.Point(168, 3)
        Me.MetroProgressBar1.Name = "MetroProgressBar1"
        Me.MetroProgressBar1.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.MetroProgressBar1.Size = New System.Drawing.Size(176, 19)
        Me.MetroProgressBar1.TabIndex = 0
        '
        'WTextBox1
        '
        Me.WTextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.WTextBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.WTextBox1.Icon = Nothing
        Me.WTextBox1.IconIsButton = False
        Me.WTextBox1.IconRect = New System.Drawing.Rectangle(1, 1, 20, 20)
        Me.WTextBox1.IsSystemPasswordChar = False
        Me.WTextBox1.Lines = New String(-1) {}
        Me.WTextBox1.Location = New System.Drawing.Point(0, 0)
        Me.WTextBox1.MaxLength = 32767
        Me.WTextBox1.Multiline = False
        Me.WTextBox1.Name = "WTextBox1"
        Me.WTextBox1.PasswordChat = Global.Microsoft.VisualBasic.ChrW(0)
        Me.WTextBox1.ReadOnly = True
        Me.WTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.WTextBox1.Size = New System.Drawing.Size(162, 25)
        Me.WTextBox1.TabIndex = 1
        Me.WTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.WTextBox1.WaterColor = System.Drawing.Color.DarkGray
        Me.WTextBox1.WaterFont = New System.Drawing.Font("SimSun", 9.0!)
        Me.WTextBox1.WaterText = ""
        Me.WTextBox1.WordWrap = True
        '
        'MetroButton1
        '
        Me.MetroButton1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.MetroButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.MetroButton1.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroButton1.Location = New System.Drawing.Point(350, 0)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(108, 25)
        Me.MetroButton1.TabIndex = 2
        Me.MetroButton1.Text = "Cancelar"
        Me.MetroButton1.UseCustomBackColor = True
        Me.MetroButton1.UseCustomForeColor = True
        Me.MetroButton1.UseSelectable = True
        Me.MetroButton1.UseVisualStyleBackColor = False
        '
        'TaskControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Controls.Add(Me.MetroButton1)
        Me.Controls.Add(Me.WTextBox1)
        Me.Controls.Add(Me.MetroProgressBar1)
        Me.Name = "TaskControl"
        Me.Size = New System.Drawing.Size(458, 25)
        Me.Style = Wisder.W3Common.WMetroControl.MetroColorStyle.Blue
        Me.Theme = Wisder.W3Common.WMetroControl.MetroThemeStyle.Light
        Me.UseStyleColors = True
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents MetroProgressBar1 As Wisder.W3Common.WMetroControl.Controls.MetroProgressBar
    Friend WithEvents WTextBox1 As Wisder.W3Common.WControl.WTextBox
    Friend WithEvents MetroButton1 As Wisder.W3Common.WMetroControl.Controls.MetroButton

End Class
