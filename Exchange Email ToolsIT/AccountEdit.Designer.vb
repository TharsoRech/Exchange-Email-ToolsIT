<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccountEdit
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
        Me.MetroLabel1 = New Wisder.W3Common.WMetroControl.Controls.MetroLabel()
        Me.MetroLabel2 = New Wisder.W3Common.WMetroControl.Controls.MetroLabel()
        Me.MetroLabel3 = New Wisder.W3Common.WMetroControl.Controls.MetroLabel()
        Me.MetroButton1 = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.MetroButton2 = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.TextBox1 = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.MetroTextBox1 = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.MetroTextBox2 = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.SuspendLayout()
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Location = New System.Drawing.Point(42, 77)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(56, 19)
        Me.MetroLabel1.TabIndex = 0
        Me.MetroLabel1.Text = "Usuario:"
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(42, 118)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(61, 19)
        Me.MetroLabel2.TabIndex = 4
        Me.MetroLabel2.Text = "Servidor:"
        '
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = True
        Me.MetroLabel3.Location = New System.Drawing.Point(51, 150)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(47, 19)
        Me.MetroLabel3.TabIndex = 5
        Me.MetroLabel3.Text = "Senha:"
        '
        'MetroButton1
        '
        Me.MetroButton1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.MetroButton1.Location = New System.Drawing.Point(88, 192)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(75, 23)
        Me.MetroButton1.TabIndex = 6
        Me.MetroButton1.Text = "Salvar "
        Me.MetroButton1.UseCustomBackColor = True
        Me.MetroButton1.UseSelectable = True
        Me.MetroButton1.UseVisualStyleBackColor = False
        '
        'MetroButton2
        '
        Me.MetroButton2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.MetroButton2.Location = New System.Drawing.Point(169, 192)
        Me.MetroButton2.Name = "MetroButton2"
        Me.MetroButton2.Size = New System.Drawing.Size(75, 23)
        Me.MetroButton2.TabIndex = 7
        Me.MetroButton2.Text = "Cancelar"
        Me.MetroButton2.UseCustomBackColor = True
        Me.MetroButton2.UseSelectable = True
        Me.MetroButton2.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Lines = New String(-1) {}
        Me.TextBox1.Location = New System.Drawing.Point(114, 77)
        Me.TextBox1.MaxLength = 32767
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBox1.SelectedText = ""
        Me.TextBox1.Size = New System.Drawing.Size(172, 20)
        Me.TextBox1.TabIndex = 8
        Me.TextBox1.UseSelectable = True
        '
        'MetroTextBox1
        '
        Me.MetroTextBox1.Lines = New String(-1) {}
        Me.MetroTextBox1.Location = New System.Drawing.Point(114, 118)
        Me.MetroTextBox1.MaxLength = 32767
        Me.MetroTextBox1.Name = "MetroTextBox1"
        Me.MetroTextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.MetroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox1.SelectedText = ""
        Me.MetroTextBox1.Size = New System.Drawing.Size(172, 20)
        Me.MetroTextBox1.TabIndex = 9
        Me.MetroTextBox1.UseSelectable = True
        '
        'MetroTextBox2
        '
        Me.MetroTextBox2.Lines = New String(-1) {}
        Me.MetroTextBox2.Location = New System.Drawing.Point(114, 150)
        Me.MetroTextBox2.MaxLength = 32767
        Me.MetroTextBox2.Name = "MetroTextBox2"
        Me.MetroTextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(46)
        Me.MetroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox2.SelectedText = ""
        Me.MetroTextBox2.Size = New System.Drawing.Size(172, 20)
        Me.MetroTextBox2.TabIndex = 10
        Me.MetroTextBox2.UseSelectable = True
        '
        'AccountEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 232)
        Me.Controls.Add(Me.MetroTextBox2)
        Me.Controls.Add(Me.MetroTextBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.MetroButton2)
        Me.Controls.Add(Me.MetroButton1)
        Me.Controls.Add(Me.MetroLabel3)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Name = "AccountEdit"
        Me.ShadowType = Wisder.W3Common.WMetroControl.Forms.MetroFormShadowType.SystemShadow
        Me.Text = "Editar Conta"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MetroLabel1 As Wisder.W3Common.WMetroControl.Controls.MetroLabel
    Friend WithEvents MetroLabel2 As Wisder.W3Common.WMetroControl.Controls.MetroLabel
    Friend WithEvents MetroLabel3 As Wisder.W3Common.WMetroControl.Controls.MetroLabel
    Friend WithEvents MetroButton1 As Wisder.W3Common.WMetroControl.Controls.MetroButton
    Friend WithEvents MetroButton2 As Wisder.W3Common.WMetroControl.Controls.MetroButton
    Friend WithEvents TextBox1 As Wisder.W3Common.WMetroControl.Controls.MetroTextBox
    Friend WithEvents MetroTextBox1 As Wisder.W3Common.WMetroControl.Controls.MetroTextBox
    Friend WithEvents MetroTextBox2 As Wisder.W3Common.WMetroControl.Controls.MetroTextBox
End Class
