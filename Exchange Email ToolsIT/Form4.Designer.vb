<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Me.ProgressBar1 = New Wisder.W3Common.WMetroControl.Controls.MetroProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(55, 97)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.Size = New System.Drawing.Size(449, 23)
        Me.ProgressBar1.Style = Wisder.W3Common.WMetroControl.MetroColorStyle.Blue
        Me.ProgressBar1.TabIndex = 0
        Me.ProgressBar1.Theme = Wisder.W3Common.WMetroControl.MetroThemeStyle.Light
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(84, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(357, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Sincronizando pastas Por Favor Espere..."
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Button1.Location = New System.Drawing.Point(201, 126)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Cancelar"
        Me.Button1.UseCustomBackColor = True
        Me.Button1.UseSelectable = True
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 159)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form4"
        Me.ShadowType = Wisder.W3Common.WMetroControl.Forms.MetroFormShadowType.SystemShadow
        Me.Text = "Sincronizar Pastas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBar1 As Wisder.W3Common.WMetroControl.Controls.MetroProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As Wisder.W3Common.WMetroControl.Controls.MetroButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
