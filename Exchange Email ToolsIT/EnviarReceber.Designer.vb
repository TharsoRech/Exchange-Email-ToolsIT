<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnviarReceber
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EnviarReceber))
        Me.Task1 = New Exchange_Email_ToolsIT.Task()
        Me.SuspendLayout()
        '
        'Task1
        '
        Me.Task1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Task1.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Task1.Location = New System.Drawing.Point(20, 30)
        Me.Task1.Name = "Task1"
        Me.Task1.Size = New System.Drawing.Size(509, 215)
        Me.Task1.TabIndex = 0
        Me.Task1.UseSelectable = True
        '
        'EnviarReceber
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 265)
        Me.Controls.Add(Me.Task1)
        Me.DisplayHeader = False
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "EnviarReceber"
        Me.Padding = New System.Windows.Forms.Padding(20, 30, 20, 20)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents Task1 As Exchange_Email_ToolsIT.Task
End Class
