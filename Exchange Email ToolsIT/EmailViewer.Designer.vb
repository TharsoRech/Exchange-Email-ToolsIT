<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmailViewer
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmailViewer))
        Me.MetroTabControl1 = New Wisder.W3Common.WMetroControl.Controls.MetroTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.MetroGrid1 = New Wisder.W3Common.WMetroControl.Controls.MetroGrid()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New Wisder.W3Common.WMetroControl.Controls.MetroContextMenu(Me.components)
        Me.SalvarComoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaalvarTodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WTextBox1 = New Wisder.W3Common.WControl.WTextBox()
        Me.WTextBox2 = New Wisder.W3Common.WControl.WTextBox()
        Me.MetroLabel1 = New Wisder.W3Common.WMetroControl.Controls.MetroLabel()
        Me.MetroLabel2 = New Wisder.W3Common.WMetroControl.Controls.MetroLabel()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.MetroTile1 = New Wisder.W3Common.WMetroControl.Controls.MetroTile()
        Me.MetroPanel1 = New Wisder.W3Common.WMetroControl.Controls.MetroPanel()
        Me.WTextBox5 = New Wisder.W3Common.WControl.WTextBox()
        Me.WTextBox4 = New Wisder.W3Common.WControl.WTextBox()
        Me.WTextBox3 = New Wisder.W3Common.WControl.WTextBox()
        Me.MetroTile4 = New Wisder.W3Common.WMetroControl.Controls.MetroTile()
        Me.MetroTile3 = New Wisder.W3Common.WMetroControl.Controls.MetroTile()
        Me.MetroTile2 = New Wisder.W3Common.WMetroControl.Controls.MetroTile()
        Me.MetroButton1 = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.MetroTabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.MetroGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.MetroPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MetroTabControl1
        '
        Me.MetroTabControl1.Controls.Add(Me.TabPage1)
        Me.MetroTabControl1.Location = New System.Drawing.Point(16, 165)
        Me.MetroTabControl1.Name = "MetroTabControl1"
        Me.MetroTabControl1.Padding = New System.Drawing.Point(6, 8)
        Me.MetroTabControl1.SelectedIndex = 0
        Me.MetroTabControl1.Size = New System.Drawing.Size(906, 122)
        Me.MetroTabControl1.TabIndex = 0
        Me.MetroTabControl1.UseSelectable = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.MetroGrid1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 38)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(898, 80)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Anexos"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'MetroGrid1
        '
        Me.MetroGrid1.AllowUserToResizeRows = False
        Me.MetroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MetroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MetroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.MetroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MetroGrid1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.MetroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MetroGrid1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.MetroGrid1.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MetroGrid1.DefaultCellStyle = DataGridViewCellStyle2
        Me.MetroGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetroGrid1.EnableHeadersVisualStyles = False
        Me.MetroGrid1.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.MetroGrid1.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MetroGrid1.Location = New System.Drawing.Point(3, 3)
        Me.MetroGrid1.MultiSelect = False
        Me.MetroGrid1.Name = "MetroGrid1"
        Me.MetroGrid1.ReadOnly = True
        Me.MetroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(17, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MetroGrid1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.MetroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.MetroGrid1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.MetroGrid1.Size = New System.Drawing.Size(892, 74)
        Me.MetroGrid1.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Anexos"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalvarComoToolStripMenuItem, Me.AbrirToolStripMenuItem, Me.SaalvarTodoToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(173, 70)
        Me.ContextMenuStrip1.Style = Wisder.W3Common.WMetroControl.MetroColorStyle.Blue
        Me.ContextMenuStrip1.Theme = Wisder.W3Common.WMetroControl.MetroThemeStyle.Light
        '
        'SalvarComoToolStripMenuItem
        '
        Me.SalvarComoToolStripMenuItem.Image = CType(resources.GetObject("SalvarComoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SalvarComoToolStripMenuItem.Name = "SalvarComoToolStripMenuItem"
        Me.SalvarComoToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.SalvarComoToolStripMenuItem.Text = "Salvar Como.."
        '
        'AbrirToolStripMenuItem
        '
        Me.AbrirToolStripMenuItem.Image = CType(resources.GetObject("AbrirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AbrirToolStripMenuItem.Name = "AbrirToolStripMenuItem"
        Me.AbrirToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.AbrirToolStripMenuItem.Text = "Abrir"
        '
        'SaalvarTodoToolStripMenuItem
        '
        Me.SaalvarTodoToolStripMenuItem.Image = CType(resources.GetObject("SaalvarTodoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SaalvarTodoToolStripMenuItem.Name = "SaalvarTodoToolStripMenuItem"
        Me.SaalvarTodoToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.SaalvarTodoToolStripMenuItem.Text = "Salvar todos ( .Zip)"
        '
        'WTextBox1
        '
        Me.WTextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.WTextBox1.Icon = Nothing
        Me.WTextBox1.IconIsButton = False
        Me.WTextBox1.IconRect = New System.Drawing.Rectangle(1, 1, 20, 20)
        Me.WTextBox1.IsSystemPasswordChar = False
        Me.WTextBox1.Lines = New String(-1) {}
        Me.WTextBox1.Location = New System.Drawing.Point(95, 139)
        Me.WTextBox1.MaxLength = 32767
        Me.WTextBox1.Multiline = False
        Me.WTextBox1.Name = "WTextBox1"
        Me.WTextBox1.PasswordChat = Global.Microsoft.VisualBasic.ChrW(0)
        Me.WTextBox1.ReadOnly = True
        Me.WTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.WTextBox1.Size = New System.Drawing.Size(811, 26)
        Me.WTextBox1.TabIndex = 1
        Me.WTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.WTextBox1.WaterColor = System.Drawing.Color.DarkGray
        Me.WTextBox1.WaterFont = New System.Drawing.Font("SimSun", 9.0!)
        Me.WTextBox1.WaterText = ""
        Me.WTextBox1.WordWrap = True
        '
        'WTextBox2
        '
        Me.WTextBox2.BackColor = System.Drawing.SystemColors.Control
        Me.WTextBox2.Icon = Nothing
        Me.WTextBox2.IconIsButton = False
        Me.WTextBox2.IconRect = New System.Drawing.Rectangle(1, 1, 20, 20)
        Me.WTextBox2.IsSystemPasswordChar = False
        Me.WTextBox2.Lines = New String(-1) {}
        Me.WTextBox2.Location = New System.Drawing.Point(95, 89)
        Me.WTextBox2.MaxLength = 32767
        Me.WTextBox2.Multiline = False
        Me.WTextBox2.Name = "WTextBox2"
        Me.WTextBox2.PasswordChat = Global.Microsoft.VisualBasic.ChrW(0)
        Me.WTextBox2.ReadOnly = True
        Me.WTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.WTextBox2.Size = New System.Drawing.Size(811, 26)
        Me.WTextBox2.TabIndex = 2
        Me.WTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.WTextBox2.WaterColor = System.Drawing.Color.DarkGray
        Me.WTextBox2.WaterFont = New System.Drawing.Font("SimSun", 9.0!)
        Me.WTextBox2.WaterText = ""
        Me.WTextBox2.WordWrap = True
        '
        'MetroLabel1
        '
        Me.MetroLabel1.AutoSize = True
        Me.MetroLabel1.Font = New System.Drawing.Font("Franklin Gothic Medium", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroLabel1.Location = New System.Drawing.Point(50, 89)
        Me.MetroLabel1.Name = "MetroLabel1"
        Me.MetroLabel1.Size = New System.Drawing.Size(39, 19)
        Me.MetroLabel1.TabIndex = 3
        Me.MetroLabel1.Text = "Para:"
        Me.MetroLabel1.UseCustomForeColor = True
        '
        'MetroLabel2
        '
        Me.MetroLabel2.AutoSize = True
        Me.MetroLabel2.Location = New System.Drawing.Point(43, 146)
        Me.MetroLabel2.Name = "MetroLabel2"
        Me.MetroLabel2.Size = New System.Drawing.Size(30, 19)
        Me.MetroLabel2.TabIndex = 4
        Me.MetroLabel2.Text = "CC:"
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.WebBrowser1.Location = New System.Drawing.Point(20, 293)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(912, 371)
        Me.WebBrowser1.TabIndex = 1
        '
        'MetroTile1
        '
        Me.MetroTile1.ActiveControl = Nothing
        Me.MetroTile1.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroTile1.Location = New System.Drawing.Point(488, 3)
        Me.MetroTile1.Name = "MetroTile1"
        Me.MetroTile1.Size = New System.Drawing.Size(69, 45)
        Me.MetroTile1.TabIndex = 8
        Me.MetroTile1.Text = "Imprimir"
        Me.MetroTile1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.MetroTile1.TileImage = CType(resources.GetObject("MetroTile1.TileImage"), System.Drawing.Image)
        Me.MetroTile1.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.MetroTile1.UseCustomBackColor = True
        Me.MetroTile1.UseCustomForeColor = True
        Me.MetroTile1.UseSelectable = True
        Me.MetroTile1.UseTileImage = True
        Me.MetroTile1.UseVisualStyleBackColor = True
        '
        'MetroPanel1
        '
        Me.MetroPanel1.Controls.Add(Me.WTextBox5)
        Me.MetroPanel1.Controls.Add(Me.WTextBox4)
        Me.MetroPanel1.Controls.Add(Me.WTextBox3)
        Me.MetroPanel1.Controls.Add(Me.MetroTile4)
        Me.MetroPanel1.Controls.Add(Me.MetroTile3)
        Me.MetroPanel1.Controls.Add(Me.MetroTile2)
        Me.MetroPanel1.Controls.Add(Me.MetroTile1)
        Me.MetroPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.MetroPanel1.HorizontalScrollbarBarColor = True
        Me.MetroPanel1.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.HorizontalScrollbarSize = 10
        Me.MetroPanel1.Location = New System.Drawing.Point(20, 30)
        Me.MetroPanel1.Name = "MetroPanel1"
        Me.MetroPanel1.Size = New System.Drawing.Size(912, 53)
        Me.MetroPanel1.TabIndex = 9
        Me.MetroPanel1.VerticalScrollbarBarColor = True
        Me.MetroPanel1.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.VerticalScrollbarSize = 10
        '
        'WTextBox5
        '
        Me.WTextBox5.BackColor = System.Drawing.SystemColors.Control
        Me.WTextBox5.Icon = Nothing
        Me.WTextBox5.IconIsButton = False
        Me.WTextBox5.IconRect = New System.Drawing.Rectangle(1, 1, 20, 20)
        Me.WTextBox5.IsSystemPasswordChar = False
        Me.WTextBox5.Lines = New String(-1) {}
        Me.WTextBox5.Location = New System.Drawing.Point(319, 28)
        Me.WTextBox5.MaxLength = 32767
        Me.WTextBox5.Multiline = False
        Me.WTextBox5.Name = "WTextBox5"
        Me.WTextBox5.PasswordChat = Global.Microsoft.VisualBasic.ChrW(0)
        Me.WTextBox5.ReadOnly = True
        Me.WTextBox5.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.WTextBox5.Size = New System.Drawing.Size(163, 22)
        Me.WTextBox5.TabIndex = 14
        Me.WTextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.WTextBox5.WaterColor = System.Drawing.Color.DarkGray
        Me.WTextBox5.WaterFont = New System.Drawing.Font("SimSun", 9.0!)
        Me.WTextBox5.WaterText = ""
        Me.WTextBox5.WordWrap = True
        '
        'WTextBox4
        '
        Me.WTextBox4.BackColor = System.Drawing.SystemColors.Control
        Me.WTextBox4.Icon = Nothing
        Me.WTextBox4.IconIsButton = False
        Me.WTextBox4.IconRect = New System.Drawing.Rectangle(1, 1, 20, 20)
        Me.WTextBox4.IsSystemPasswordChar = False
        Me.WTextBox4.Lines = New String(-1) {}
        Me.WTextBox4.Location = New System.Drawing.Point(7, 26)
        Me.WTextBox4.MaxLength = 32767
        Me.WTextBox4.Multiline = False
        Me.WTextBox4.Name = "WTextBox4"
        Me.WTextBox4.PasswordChat = Global.Microsoft.VisualBasic.ChrW(0)
        Me.WTextBox4.ReadOnly = True
        Me.WTextBox4.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.WTextBox4.Size = New System.Drawing.Size(306, 22)
        Me.WTextBox4.TabIndex = 13
        Me.WTextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.WTextBox4.WaterColor = System.Drawing.Color.DarkGray
        Me.WTextBox4.WaterFont = New System.Drawing.Font("SimSun", 9.0!)
        Me.WTextBox4.WaterText = ""
        Me.WTextBox4.WordWrap = True
        '
        'WTextBox3
        '
        Me.WTextBox3.BackColor = System.Drawing.SystemColors.Control
        Me.WTextBox3.Icon = Nothing
        Me.WTextBox3.IconIsButton = False
        Me.WTextBox3.IconRect = New System.Drawing.Rectangle(1, 1, 20, 20)
        Me.WTextBox3.IsSystemPasswordChar = False
        Me.WTextBox3.Lines = New String(-1) {}
        Me.WTextBox3.Location = New System.Drawing.Point(7, 3)
        Me.WTextBox3.MaxLength = 32767
        Me.WTextBox3.Multiline = False
        Me.WTextBox3.Name = "WTextBox3"
        Me.WTextBox3.PasswordChat = Global.Microsoft.VisualBasic.ChrW(0)
        Me.WTextBox3.ReadOnly = True
        Me.WTextBox3.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.WTextBox3.Size = New System.Drawing.Size(475, 22)
        Me.WTextBox3.TabIndex = 12
        Me.WTextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.WTextBox3.WaterColor = System.Drawing.Color.DarkGray
        Me.WTextBox3.WaterFont = New System.Drawing.Font("SimSun", 9.0!)
        Me.WTextBox3.WaterText = ""
        Me.WTextBox3.WordWrap = True
        '
        'MetroTile4
        '
        Me.MetroTile4.ActiveControl = Nothing
        Me.MetroTile4.Font = New System.Drawing.Font("Mistral", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroTile4.Location = New System.Drawing.Point(788, 3)
        Me.MetroTile4.Name = "MetroTile4"
        Me.MetroTile4.Size = New System.Drawing.Size(114, 45)
        Me.MetroTile4.TabIndex = 11
        Me.MetroTile4.Text = "Encaminhar"
        Me.MetroTile4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.MetroTile4.TileImage = CType(resources.GetObject("MetroTile4.TileImage"), System.Drawing.Image)
        Me.MetroTile4.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.MetroTile4.UseCustomBackColor = True
        Me.MetroTile4.UseCustomForeColor = True
        Me.MetroTile4.UseSelectable = True
        Me.MetroTile4.UseTileImage = True
        Me.MetroTile4.UseVisualStyleBackColor = True
        '
        'MetroTile3
        '
        Me.MetroTile3.ActiveControl = Nothing
        Me.MetroTile3.Font = New System.Drawing.Font("Mistral", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroTile3.Location = New System.Drawing.Point(665, 3)
        Me.MetroTile3.Name = "MetroTile3"
        Me.MetroTile3.Size = New System.Drawing.Size(132, 45)
        Me.MetroTile3.TabIndex = 10
        Me.MetroTile3.Text = "Responder a todos"
        Me.MetroTile3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.MetroTile3.TileImage = CType(resources.GetObject("MetroTile3.TileImage"), System.Drawing.Image)
        Me.MetroTile3.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.MetroTile3.UseCustomBackColor = True
        Me.MetroTile3.UseCustomForeColor = True
        Me.MetroTile3.UseSelectable = True
        Me.MetroTile3.UseTileImage = True
        Me.MetroTile3.UseVisualStyleBackColor = True
        '
        'MetroTile2
        '
        Me.MetroTile2.ActiveControl = Nothing
        Me.MetroTile2.Font = New System.Drawing.Font("Mistral", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroTile2.Location = New System.Drawing.Point(563, 5)
        Me.MetroTile2.Name = "MetroTile2"
        Me.MetroTile2.Size = New System.Drawing.Size(87, 45)
        Me.MetroTile2.TabIndex = 9
        Me.MetroTile2.Text = "Responder"
        Me.MetroTile2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.MetroTile2.TileImage = CType(resources.GetObject("MetroTile2.TileImage"), System.Drawing.Image)
        Me.MetroTile2.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.MetroTile2.UseCustomBackColor = True
        Me.MetroTile2.UseCustomForeColor = True
        Me.MetroTile2.UseSelectable = True
        Me.MetroTile2.UseTileImage = True
        Me.MetroTile2.UseVisualStyleBackColor = True
        '
        'MetroButton1
        '
        Me.MetroButton1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.MetroButton1.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroButton1.Location = New System.Drawing.Point(574, 165)
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Size = New System.Drawing.Size(332, 23)
        Me.MetroButton1.TabIndex = 10
        Me.MetroButton1.Text = "Caso Não Carregue alguma Imagem Abaixo Aperte aqui."
        Me.MetroButton1.UseCustomBackColor = True
        Me.MetroButton1.UseCustomForeColor = True
        Me.MetroButton1.UseSelectable = True
        Me.MetroButton1.UseVisualStyleBackColor = False
        '
        'EmailViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(952, 684)
        Me.Controls.Add(Me.MetroButton1)
        Me.Controls.Add(Me.MetroPanel1)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.MetroLabel2)
        Me.Controls.Add(Me.MetroLabel1)
        Me.Controls.Add(Me.WTextBox2)
        Me.Controls.Add(Me.WTextBox1)
        Me.Controls.Add(Me.MetroTabControl1)
        Me.DisplayHeader = False
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EmailViewer"
        Me.Padding = New System.Windows.Forms.Padding(20, 30, 20, 20)
        Me.Text = "EmailViewer"
        Me.MetroTabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.MetroGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.MetroPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents MetroLabel1 As Wisder.W3Common.WMetroControl.Controls.MetroLabel
    Friend WithEvents MetroLabel2 As Wisder.W3Common.WMetroControl.Controls.MetroLabel
    Public WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Public WithEvents MetroTabControl1 As Wisder.W3Common.WMetroControl.Controls.MetroTabControl
    Public WithEvents WTextBox1 As Wisder.W3Common.WControl.WTextBox
    Public WithEvents WTextBox2 As Wisder.W3Common.WControl.WTextBox
    Public WithEvents MetroGrid1 As Wisder.W3Common.WMetroControl.Controls.MetroGrid
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MetroTile1 As Wisder.W3Common.WMetroControl.Controls.MetroTile
    Friend WithEvents MetroPanel1 As Wisder.W3Common.WMetroControl.Controls.MetroPanel
    Friend WithEvents MetroTile4 As Wisder.W3Common.WMetroControl.Controls.MetroTile
    Friend WithEvents MetroTile3 As Wisder.W3Common.WMetroControl.Controls.MetroTile
    Friend WithEvents MetroTile2 As Wisder.W3Common.WMetroControl.Controls.MetroTile
    Public WithEvents WTextBox5 As Wisder.W3Common.WControl.WTextBox
    Public WithEvents WTextBox4 As Wisder.W3Common.WControl.WTextBox
    Public WithEvents WTextBox3 As Wisder.W3Common.WControl.WTextBox
    Friend WithEvents MetroButton1 As Wisder.W3Common.WMetroControl.Controls.MetroButton
    Friend WithEvents ContextMenuStrip1 As Wisder.W3Common.WMetroControl.Controls.MetroContextMenu
    Friend WithEvents SalvarComoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbrirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaalvarTodoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
