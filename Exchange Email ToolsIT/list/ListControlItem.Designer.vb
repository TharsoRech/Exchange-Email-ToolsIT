<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListControlItem
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ListControlItem))
        Me.lblDuration = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.RatingBar1 = New WindowsApplication1.RatingBar()
        Me.SuspendLayout()
        '
        'lblDuration
        '
        Me.lblDuration.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDuration.AutoSize = True
        Me.lblDuration.BackColor = System.Drawing.Color.Transparent
        Me.lblDuration.Location = New System.Drawing.Point(433, 34)
        Me.lblDuration.Name = "lblDuration"
        Me.lblDuration.Size = New System.Drawing.Size(39, 17)
        Me.lblDuration.TabIndex = 3
        Me.lblDuration.Text = "00:00"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "1429729026_71664.ico")
        Me.ImageList1.Images.SetKeyName(1, "Eventvwr_icon.png")
        '
        'RatingBar1
        '
        Me.RatingBar1.BackColor = System.Drawing.Color.Transparent
        Me.RatingBar1.Location = New System.Drawing.Point(385, 4)
        Me.RatingBar1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.RatingBar1.MaximumSize = New System.Drawing.Size(87, 20)
        Me.RatingBar1.MinimumSize = New System.Drawing.Size(87, 20)
        Me.RatingBar1.Name = "RatingBar1"
        Me.RatingBar1.Size = New System.Drawing.Size(87, 20)
        Me.RatingBar1.Stars = 3
        Me.RatingBar1.TabIndex = 4
        '
        'ListControlItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.RatingBar1)
        Me.Controls.Add(Me.lblDuration)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI Light", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "ListControlItem"
        Me.Size = New System.Drawing.Size(484, 75)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDuration As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents RatingBar1 As WindowsApplication1.RatingBar


End Class
