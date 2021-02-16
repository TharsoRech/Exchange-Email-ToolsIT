<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProgresWindows
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProgresWindows))
        Me.ElementHost1 = New System.Windows.Forms.Integration.ElementHost()
        Me.MetroLabel1 = New Wisder.W3Common.WMetroControl.Controls.MetroLabel()
        Me.MetroTile1 = New Wisder.W3Common.WMetroControl.Controls.MetroTile()
        Me.SuspendLayout()
        '
        'ElementHost1
        '
        Me.ElementHost1.BackColor = System.Drawing.Color.Transparent
        Me.ElementHost1.BackColorTransparent = True
        Me.ElementHost1.Location = New System.Drawing.Point(-4, 27)
        Me.ElementHost1.Name = "ElementHost1"
        Me.ElementHost1.Size = New System.Drawing.Size(213, 202)
        Me.ElementHost1.TabIndex = 1
        Me.ElementHost1.Text = "ElementHost1"
        Me.ElementHost1.Child = Nothing
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.BackColor = System.Drawing.Color.Transparent
        Me.MetroLabel1.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroLabel1.FontWeight = Wisder.W3Common.WMetroControl.MetroLabelWeight.Bold
        Me.MetroLabel1.ForeColor = System.Drawing.Color.White
        Me.MetroLabel1.LabelMode = Wisder.W3Common.WMetroControl.Controls.MetroLabelMode.Selectable
        Me.MetroLabel1.Location = New System.Drawing.Point(12, 5)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(89, 19)
        Me.MetroLabel1.Style = Wisder.W3Common.WMetroControl.MetroColorStyle.Blue
        Me.MetroLabel1.TabIndex = 2
        Me.MetroLabel1.Text = "Carregando"
        Me.MetroLabel1.Theme = Wisder.W3Common.WMetroControl.MetroThemeStyle.Light
        Me.MetroLabel1.UseCustomBackColor = True
        Me.MetroLabel1.UseCustomForeColor = True
        Me.MetroLabel1.UseStyleColors = True
        '
        'MetroTile1
        '
        Me.MetroTile1.ActiveControl = Nothing
        Me.MetroTile1.BackColor = System.Drawing.Color.Transparent
        Me.MetroTile1.Image = CType(resources.GetObject("MetroTile1.Image"), System.Drawing.Image)
        Me.MetroTile1.Location = New System.Drawing.Point(188, 5)
        Me.MetroTile1.Name = "MetroTile1"
        Me.MetroTile1.Size = New System.Drawing.Size(21, 20)
        Me.MetroTile1.Style = Wisder.W3Common.WMetroControl.MetroColorStyle.Blue
        Me.MetroTile1.TabIndex = 3
        Me.MetroTile1.Text = "MetroTile1"
        Me.MetroTile1.Theme = Wisder.W3Common.WMetroControl.MetroThemeStyle.Light
        Me.MetroTile1.TileImage = CType(resources.GetObject("MetroTile1.TileImage"), System.Drawing.Image)
        Me.MetroTile1.UseCustomBackColor = True
        Me.MetroTile1.UseSelectable = True
        Me.MetroTile1.UseTileImage = True
        Me.MetroTile1.UseVisualStyleBackColor = False
        '
        'ProgresWindows
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(206, 227)
        Me.Controls.Add(Me.MetroTile1)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.ElementHost1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ProgresWindows"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ProgresWindows"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ElementHost1 As System.Windows.Forms.Integration.ElementHost
    Friend WithEvents MetroLabel1 As Wisder.W3Common.WMetroControl.Controls.MetroLabel
    Friend WithEvents MetroTile1 As Wisder.W3Common.WMetroControl.Controls.MetroTile
End Class
