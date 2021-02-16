<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChooseAccount
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChooseAccount))
        Me.MetroComboBox1 = New MetroFramework.Controls.MetroComboBox()
        Me.MetroButton1 = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.MetroButton2 = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.MetroLabel1 = New Wisder.W3Common.WMetroControl.Controls.MetroLabel()
        Me.SuspendLayout()
        '
        'MetroComboBox1
        '
        Me.MetroComboBox1.FormattingEnabled = True
        Me.MetroComboBox1.ItemHeight = 23
        Me.MetroComboBox1.Location = New System.Drawing.Point(39, 95)
        Me.MetroComboBox1.Name = "MetroComboBox1"
        Me.MetroComboBox1.Size = New System.Drawing.Size(306, 29)
        Me.MetroComboBox1.TabIndex = 0
        Me.MetroComboBox1.UseSelectable = True
        '
        'MetroButton1
        '
        Me.MetroButton1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.MetroButton1.Location = New System.Drawing.Point(65, 197)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(100, 23)
        Me.MetroButton1.TabIndex = 1
        Me.MetroButton1.Text = "OK"
        Me.MetroButton1.UseCustomBackColor = True
        Me.MetroButton1.UseSelectable = True
        Me.MetroButton1.UseVisualStyleBackColor = False
        '
        'MetroButton2
        '
        Me.MetroButton2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.MetroButton2.Location = New System.Drawing.Point(206, 197)
        Me.MetroButton2.Name = "MetroButton2"
        Me.MetroButton2.Size = New System.Drawing.Size(100, 23)
        Me.MetroButton2.TabIndex = 2
        Me.MetroButton2.Text = "Cancelar"
        Me.MetroButton2.UseCustomBackColor = True
        Me.MetroButton2.UseSelectable = True
        Me.MetroButton2.UseVisualStyleBackColor = False
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(13, 148)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(345, 19)
        Me.MetroLabel1.TabIndex = 3
        Me.MetroLabel1.Text = "OBS:a conta selecionada sera automaticamente a padrao"
        '
        'ChooseAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(368, 243)
        Me.ControlBox = False
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.MetroButton2)
        Me.Controls.Add(Me.MetroButton1)
        Me.Controls.Add(Me.MetroComboBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ChooseAccount"
        Me.ShadowType = Wisder.W3Common.WMetroControl.Forms.MetroFormShadowType.SystemShadow
        Me.Text = "Escolha Uma Conta:"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MetroComboBox1 As MetroFramework.Controls.MetroComboBox
    Friend WithEvents MetroButton1 As Wisder.W3Common.WMetroControl.Controls.MetroButton
    Friend WithEvents MetroButton2 As Wisder.W3Common.WMetroControl.Controls.MetroButton
    Friend WithEvents MetroLabel1 As Wisder.W3Common.WMetroControl.Controls.MetroLabel
End Class
