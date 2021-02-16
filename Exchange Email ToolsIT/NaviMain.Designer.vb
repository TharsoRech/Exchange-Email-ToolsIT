<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NaviMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NaviMain))
        Me.tlsNaviHelper = New System.Windows.Forms.ToolStrip()
        Me.tsbtnPin = New System.Windows.Forms.ToolStripButton()
        Me.tlstrpNaviButtons = New System.Windows.Forms.ToolStrip()
        Me.btnInbox = New System.Windows.Forms.ToolStripButton()
        Me.btnSearch = New System.Windows.Forms.ToolStripButton()
        Me.lstViewImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.treeView1 = New Exchange_Email_ToolsIT.AssetBrowserControl.SerializableTreeView()
        Me.tlsNaviHelper.SuspendLayout()
        Me.tlstrpNaviButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlsNaviHelper
        '
        Me.tlsNaviHelper.AutoSize = False
        Me.tlsNaviHelper.BackColor = System.Drawing.Color.Black
        Me.tlsNaviHelper.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsNaviHelper.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.tlsNaviHelper.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnPin})
        Me.tlsNaviHelper.Location = New System.Drawing.Point(0, 0)
        Me.tlsNaviHelper.Name = "tlsNaviHelper"
        Me.tlsNaviHelper.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.tlsNaviHelper.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tlsNaviHelper.Size = New System.Drawing.Size(404, 24)
        Me.tlsNaviHelper.TabIndex = 3
        Me.tlsNaviHelper.Text = "ToolStrip1"
        '
        'tsbtnPin
        '
        Me.tsbtnPin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtnPin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnPin.Name = "tsbtnPin"
        Me.tsbtnPin.Size = New System.Drawing.Size(23, 21)
        Me.tsbtnPin.Text = "ToolStripButton1"
        Me.tsbtnPin.ToolTipText = "Hide Navigation Panel"
        '
        'tlstrpNaviButtons
        '
        Me.tlstrpNaviButtons.AutoSize = False
        Me.tlstrpNaviButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tlstrpNaviButtons.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.tlstrpNaviButtons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlstrpNaviButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnInbox, Me.btnSearch})
        Me.tlstrpNaviButtons.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.tlstrpNaviButtons.Location = New System.Drawing.Point(0, 713)
        Me.tlstrpNaviButtons.MinimumSize = New System.Drawing.Size(250, 30)
        Me.tlstrpNaviButtons.Name = "tlstrpNaviButtons"
        Me.tlstrpNaviButtons.Padding = New System.Windows.Forms.Padding(0, 2, 0, 0)
        Me.tlstrpNaviButtons.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.tlstrpNaviButtons.Size = New System.Drawing.Size(404, 104)
        Me.tlstrpNaviButtons.Stretch = True
        Me.tlstrpNaviButtons.TabIndex = 4
        '
        'btnInbox
        '
        Me.btnInbox.BackColor = System.Drawing.Color.Transparent
        Me.btnInbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnInbox.Checked = True
        Me.btnInbox.CheckOnClick = True
        Me.btnInbox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnInbox.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInbox.Image = CType(resources.GetObject("btnInbox.Image"), System.Drawing.Image)
        Me.btnInbox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInbox.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnInbox.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.btnInbox.Margin = New System.Windows.Forms.Padding(0)
        Me.btnInbox.Name = "btnInbox"
        Me.btnInbox.Padding = New System.Windows.Forms.Padding(3)
        Me.btnInbox.Size = New System.Drawing.Size(403, 42)
        Me.btnInbox.Tag = "Inbox"
        Me.btnInbox.Text = "Caixa De Entrada"
        Me.btnInbox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.Transparent
        Me.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSearch.CheckOnClick = True
        Me.btnSearch.Font = New System.Drawing.Font("Georgia", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnSearch.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(0)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Padding = New System.Windows.Forms.Padding(3)
        Me.btnSearch.Size = New System.Drawing.Size(403, 42)
        Me.btnSearch.Tag = "Search"
        Me.btnSearch.Text = "Arquivo Morto"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lstViewImageList
        '
        Me.lstViewImageList.ImageStream = CType(resources.GetObject("lstViewImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.lstViewImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.lstViewImageList.Images.SetKeyName(0, "Folder-icon2.png")
        '
        'treeView1
        '
        Me.treeView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.treeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeView1.Font = New System.Drawing.Font("Franklin Gothic Medium", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.treeView1.ForeColor = System.Drawing.Color.Black
        Me.treeView1.FullRowSelect = True
        Me.treeView1.ImageIndex = 0
        Me.treeView1.ImageList = Me.lstViewImageList
        Me.treeView1.Location = New System.Drawing.Point(0, 24)
        Me.treeView1.Name = "treeView1"
        Me.treeView1.SelectedImageIndex = 0
        Me.treeView1.ShowNodeToolTips = True
        Me.treeView1.Size = New System.Drawing.Size(404, 689)
        Me.treeView1.TabIndex = 5
        '
        'NaviMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.treeView1)
        Me.Controls.Add(Me.tlsNaviHelper)
        Me.Controls.Add(Me.tlstrpNaviButtons)
        Me.Name = "NaviMain"
        Me.Size = New System.Drawing.Size(404, 817)
        Me.tlsNaviHelper.ResumeLayout(False)
        Me.tlsNaviHelper.PerformLayout()
        Me.tlstrpNaviButtons.ResumeLayout(False)
        Me.tlstrpNaviButtons.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend tlsNaviHelper As System.Windows.Forms.ToolStrip

    Friend tsbtnPin As System.Windows.Forms.ToolStripButton

    Friend tlstrpNaviButtons As System.Windows.Forms.ToolStrip

    Friend WithEvents btnInbox As System.Windows.Forms.ToolStripButton

    Friend WithEvents btnSearch As System.Windows.Forms.ToolStripButton


    Friend lstViewImageList As System.Windows.Forms.ImageList
    Public WithEvents treeView1 As AssetBrowserControl.SerializableTreeView


    



 



End Class
