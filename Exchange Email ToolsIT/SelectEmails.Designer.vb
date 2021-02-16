<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectEmails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectEmails))
        Me.Cancelar = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.MetroProgressBar1 = New Wisder.W3Common.WMetroControl.Controls.MetroProgressBar()
        Me.Email = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.MetroLabel2 = New Wisder.W3Common.WMetroControl.Controls.MetroLabel()
        Me.Items = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.MetroLabel3 = New Wisder.W3Common.WMetroControl.Controls.MetroLabel()
        Me.MetroLabel1 = New Wisder.W3Common.WMetroControl.Controls.MetroLabel()
        Me.SuspendLayout()
        '
        'Cancelar
        '
        Me.Cancelar.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Cancelar.Location = New System.Drawing.Point(551, 165)
        Me.Cancelar.Name = "Cancelar"
        Me.Cancelar.Size = New System.Drawing.Size(75, 23)
        Me.Cancelar.TabIndex = 0
        Me.Cancelar.Text = "Cancelar"
        Me.Cancelar.UseCustomBackColor = True
        Me.Cancelar.UseSelectable = True
        Me.Cancelar.UseVisualStyleBackColor = False
        '
        'MetroProgressBar1
        '
        Me.MetroProgressBar1.HideProgressText = False
        Me.MetroProgressBar1.Location = New System.Drawing.Point(26, 121)
        Me.MetroProgressBar1.Name = "MetroProgressBar1"
        Me.MetroProgressBar1.Size = New System.Drawing.Size(622, 31)
        Me.MetroProgressBar1.TabIndex = 1
        '
        'Email
        '
        Me.Email.Lines = New String(-1) {}
        Me.Email.Location = New System.Drawing.Point(72, 92)
        Me.Email.MaxLength = 32767
        Me.Email.Name = "Email"
        Me.Email.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.Email.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Email.SelectedText = ""
        Me.Email.Size = New System.Drawing.Size(571, 23)
        Me.Email.TabIndex = 2
        Me.Email.UseSelectable = True
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(22, 92)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(44, 19)
        Me.MetroLabel2.TabIndex = 4
        Me.MetroLabel2.Text = "Email:"
        '
        'Items
        '
        Me.Items.Lines = New String(-1) {}
        Me.Items.Location = New System.Drawing.Point(73, 60)
        Me.Items.MaxLength = 32767
        Me.Items.Name = "Items"
        Me.Items.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.Items.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.Items.SelectedText = ""
        Me.Items.Size = New System.Drawing.Size(141, 23)
        Me.Items.TabIndex = 5
        Me.Items.UseSelectable = True
        '
        'MetroLabel3
        '
        Me.MetroLabel3.AutoSize = True
        Me.MetroLabel3.Font = New System.Drawing.Font("Franklin Gothic Medium", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroLabel3.FontSize = Wisder.W3Common.WMetroControl.MetroLabelSize.Tall
        Me.MetroLabel3.Location = New System.Drawing.Point(29, 19)
        Me.MetroLabel3.Name = "MetroLabel3"
        Me.MetroLabel3.Size = New System.Drawing.Size(160, 25)
        Me.MetroLabel3.TabIndex = 6
        Me.MetroLabel3.Text = "Items Selecionados:"
        Me.MetroLabel3.UseCustomForeColor = True
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Font = New System.Drawing.Font("Franklin Gothic Medium", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroLabel1.Location = New System.Drawing.Point(23, 60)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(43, 19)
        Me.MetroLabel1.TabIndex = 3
        Me.MetroLabel1.Text = "Items:"
        '
        'SelectEmails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 203)
        Me.Controls.Add(Me.MetroLabel3)
        Me.Controls.Add(Me.Items)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.Email)
        Me.Controls.Add(Me.MetroProgressBar1)
        Me.Controls.Add(Me.Cancelar)
        Me.DisplayHeader = False
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SelectEmails"
        Me.Padding = New System.Windows.Forms.Padding(20, 30, 20, 20)
        Me.ShadowType = Wisder.W3Common.WMetroControl.Forms.MetroFormShadowType.SystemShadow
        Me.Text = "SelectEmails"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Cancelar As Wisder.W3Common.WMetroControl.Controls.MetroButton
    Friend WithEvents MetroProgressBar1 As Wisder.W3Common.WMetroControl.Controls.MetroProgressBar
    Friend WithEvents Email As Wisder.W3Common.WMetroControl.Controls.MetroTextBox
    Friend WithEvents MetroLabel2 As Wisder.W3Common.WMetroControl.Controls.MetroLabel
    Friend WithEvents Items As Wisder.W3Common.WMetroControl.Controls.MetroTextBox
    Friend WithEvents MetroLabel3 As Wisder.W3Common.WMetroControl.Controls.MetroLabel
    Friend WithEvents MetroLabel1 As Wisder.W3Common.WMetroControl.Controls.MetroLabel
End Class
