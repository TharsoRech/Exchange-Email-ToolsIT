<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Carregando
    Inherits System.Windows.Forms.UserControl

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
        Me.MetroProgressSpinner1 = New Wisder.W3Common.WMetroControl.Controls.MetroProgressSpinner()
        Me.MetroLabel1 = New Wisder.W3Common.WMetroControl.Controls.MetroLabel()
        Me.SuspendLayout()
        '
        'MetroProgressSpinner1
        '
        Me.MetroProgressSpinner1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.MetroProgressSpinner1.Location = New System.Drawing.Point(0, 22)
        Me.MetroProgressSpinner1.Maximum = 100
        Me.MetroProgressSpinner1.Name = "MetroProgressSpinner1"
        Me.MetroProgressSpinner1.Size = New System.Drawing.Size(193, 183)
        Me.MetroProgressSpinner1.Speed = 2.0!
        Me.MetroProgressSpinner1.Style = Wisder.W3Common.WMetroControl.MetroColorStyle.Blue
        Me.MetroProgressSpinner1.TabIndex = 0
        Me.MetroProgressSpinner1.Text = "MetroProgressSpinner1"
        Me.MetroProgressSpinner1.Theme = Wisder.W3Common.WMetroControl.MetroThemeStyle.Light
        Me.MetroProgressSpinner1.UseSelectable = True
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.BackColor = System.Drawing.Color.Black
        Me.MetroLabel1.Font = New System.Drawing.Font("Mistral", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroLabel1.FontWeight = Wisder.W3Common.WMetroControl.MetroLabelWeight.Bold
        Me.MetroLabel1.ForeColor = System.Drawing.Color.White
        Me.MetroLabel1.LabelMode = Wisder.W3Common.WMetroControl.Controls.MetroLabelMode.Selectable
        Me.MetroLabel1.Location = New System.Drawing.Point(14, 0)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(101, 19)
        Me.MetroLabel1.Style = Wisder.W3Common.WMetroControl.MetroColorStyle.Blue
        Me.MetroLabel1.TabIndex = 1
        Me.MetroLabel1.Text = "Carregando..."
        Me.MetroLabel1.Theme = Wisder.W3Common.WMetroControl.MetroThemeStyle.Light
        Me.MetroLabel1.UseCustomBackColor = True
        Me.MetroLabel1.UseCustomForeColor = True
        Me.MetroLabel1.UseStyleColors = True
        '
        'Carregando
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.MetroProgressSpinner1)
        Me.Name = "Exchange Email ToolsIT"
        Me.Size = New System.Drawing.Size(195, 208)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MetroProgressSpinner1 As Wisder.W3Common.WMetroControl.Controls.MetroProgressSpinner
    Public WithEvents MetroLabel1 As Wisder.W3Common.WMetroControl.Controls.MetroLabel

End Class
