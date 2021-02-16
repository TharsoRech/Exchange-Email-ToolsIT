<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NovaAssinatura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NovaAssinatura))
        Me.MetroButton1 = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.MetroButton2 = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.MetroButton3 = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.MetroButton4 = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.MetroPanel1 = New Wisder.W3Common.WMetroControl.Controls.MetroPanel()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Editor1 = New Exchange_Email_ToolsIT.Editor()
        Me.MetroPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MetroButton1
        '
        Me.MetroButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.MetroButton1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.MetroButton1.Location = New System.Drawing.Point(464, 30)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(75, 27)
        Me.MetroButton1.TabIndex = 1
        Me.MetroButton1.Text = "OK"
        Me.MetroButton1.UseCustomBackColor = True
        Me.MetroButton1.UseSelectable = True
        Me.MetroButton1.UseVisualStyleBackColor = False
        '
        'MetroButton2
        '
        Me.MetroButton2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.MetroButton2.Location = New System.Drawing.Point(545, 30)
        Me.MetroButton2.Name = "MetroButton2"
        Me.MetroButton2.Size = New System.Drawing.Size(75, 27)
        Me.MetroButton2.TabIndex = 2
        Me.MetroButton2.Text = "Cancelar"
        Me.MetroButton2.UseCustomBackColor = True
        Me.MetroButton2.UseSelectable = True
        Me.MetroButton2.UseVisualStyleBackColor = False
        '
        'MetroButton3
        '
        Me.MetroButton3.BackColor = System.Drawing.SystemColors.HotTrack
        Me.MetroButton3.Location = New System.Drawing.Point(84, 30)
        Me.MetroButton3.Name = "MetroButton3"
        Me.MetroButton3.Size = New System.Drawing.Size(75, 27)
        Me.MetroButton3.TabIndex = 4
        Me.MetroButton3.Text = "Salvar"
        Me.MetroButton3.UseCustomBackColor = True
        Me.MetroButton3.UseSelectable = True
        Me.MetroButton3.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'MetroButton4
        '
        Me.MetroButton4.BackColor = System.Drawing.SystemColors.HotTrack
        Me.MetroButton4.Location = New System.Drawing.Point(3, 30)
        Me.MetroButton4.Name = "MetroButton4"
        Me.MetroButton4.Size = New System.Drawing.Size(75, 27)
        Me.MetroButton4.TabIndex = 5
        Me.MetroButton4.Text = "Abrir"
        Me.MetroButton4.UseCustomBackColor = True
        Me.MetroButton4.UseSelectable = True
        Me.MetroButton4.UseVisualStyleBackColor = False
        '
        'MetroPanel1
        '
        Me.MetroPanel1.Controls.Add(Me.MetroButton4)
        Me.MetroPanel1.Controls.Add(Me.MetroButton2)
        Me.MetroPanel1.Controls.Add(Me.MetroButton1)
        Me.MetroPanel1.Controls.Add(Me.MetroButton3)
        Me.MetroPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MetroPanel1.HorizontalScrollbarBarColor = True
        Me.MetroPanel1.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.HorizontalScrollbarSize = 12
        Me.MetroPanel1.Location = New System.Drawing.Point(20, 349)
        Me.MetroPanel1.Name = "MetroPanel1"
        Me.MetroPanel1.Size = New System.Drawing.Size(665, 60)
        Me.MetroPanel1.TabIndex = 6
        Me.MetroPanel1.VerticalScrollbarBarColor = True
        Me.MetroPanel1.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.VerticalScrollbarSize = 10
        '
        'Editor1
        '
        Me.Editor1.BodyBackgroundColor = System.Drawing.Color.White
        Me.Editor1.BodyHtml = Nothing
        Me.Editor1.BodyText = Nothing
        Me.Editor1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Editor1.DocumentText = resources.GetString("Editor1.DocumentText")
        Me.Editor1.EditorBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Editor1.EditorForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Editor1.FontSize = Exchange_Email_ToolsIT.FontSize.Three
        Me.Editor1.Html = Nothing
        Me.Editor1.Location = New System.Drawing.Point(20, 69)
        Me.Editor1.Name = "Editor1"
        Me.Editor1.Size = New System.Drawing.Size(665, 280)
        Me.Editor1.TabIndex = 3
        '
        'NovaAssinatura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(705, 432)
        Me.Controls.Add(Me.Editor1)
        Me.Controls.Add(Me.MetroPanel1)
        Me.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "NovaAssinatura"
        Me.Padding = New System.Windows.Forms.Padding(20, 69, 20, 23)
        Me.Text = "NovaAssinatura"
        Me.MetroPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents MetroButton1 As Wisder.W3Common.WMetroControl.Controls.MetroButton
    Friend WithEvents MetroButton2 As Wisder.W3Common.WMetroControl.Controls.MetroButton
    Friend WithEvents Editor1 As Exchange_Email_ToolsIT.Editor
    Friend WithEvents MetroButton3 As Wisder.W3Common.WMetroControl.Controls.MetroButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MetroButton4 As Wisder.W3Common.WMetroControl.Controls.MetroButton
    Friend WithEvents MetroPanel1 As Wisder.W3Common.WMetroControl.Controls.MetroPanel
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
