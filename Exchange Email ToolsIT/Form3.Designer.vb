<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.TextBox1 = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.Button1 = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.Button2 = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.Button3 = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.Button4 = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Lines = New String(-1) {}
        Me.TextBox1.Location = New System.Drawing.Point(225, 37)
        Me.TextBox1.MaxLength = 32767
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBox1.SelectedText = ""
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.Style = Wisder.W3Common.WMetroControl.MetroColorStyle.Blue
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Theme = Wisder.W3Common.WMetroControl.MetroThemeStyle.Light
        Me.TextBox1.UseSelectable = True
        Me.TextBox1.UseStyleColors = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Liberation Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(162, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Search:"
        '
        'ListView1
        '
        Me.ListView1.HideSelection = False
        Me.ListView1.LabelEdit = True
        Me.ListView1.Location = New System.Drawing.Point(1, 63)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(715, 241)
        Me.ListView1.TabIndex = 2
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(151, 325)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(525, 22)
        Me.RichTextBox1.TabIndex = 3
        Me.RichTextBox1.Text = ""
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Location = New System.Drawing.Point(151, 363)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(525, 22)
        Me.RichTextBox2.TabIndex = 4
        Me.RichTextBox2.Text = ""
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Button1.Location = New System.Drawing.Point(80, 323)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Para..."
        Me.Button1.UseCustomBackColor = True
        Me.Button1.UseSelectable = True
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Button2.Location = New System.Drawing.Point(80, 363)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(65, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Cc..."
        Me.Button2.UseCustomBackColor = True
        Me.Button2.UseSelectable = True
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Button3.Location = New System.Drawing.Point(506, 393)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(65, 23)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "Ok"
        Me.Button3.UseCustomBackColor = True
        Me.Button3.UseSelectable = True
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Button4.Location = New System.Drawing.Point(597, 393)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(65, 23)
        Me.Button4.TabIndex = 11
        Me.Button4.Text = "Cancel"
        Me.Button4.UseCustomBackColor = True
        Me.Button4.UseSelectable = True
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 428)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.RichTextBox2)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.DisplayHeader = False
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form3"
        Me.Padding = New System.Windows.Forms.Padding(20, 30, 20, 20)
        Me.ShadowType = Wisder.W3Common.WMetroControl.Forms.MetroFormShadowType.SystemShadow
        Me.Text = "Contatos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1  as  Wisder.W3Common.WMetroControl.Controls.MetroTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents RichTextBox2 As System.Windows.Forms.RichTextBox
    Friend WithEvents Button1 As Wisder.W3Common.WMetroControl.Controls.MetroButton
    Friend WithEvents Button2 As Wisder.W3Common.WMetroControl.Controls.MetroButton
    Friend WithEvents Button3 As Wisder.W3Common.WMetroControl.Controls.MetroButton
    Friend WithEvents Button4 As Wisder.W3Common.WMetroControl.Controls.MetroButton
End Class
