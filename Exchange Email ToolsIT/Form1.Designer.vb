Imports EmailReader
Imports Wisder.W3Common
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    ' Inherits System.Windows.Forms.Form
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.NaviBand6 = New Guifreaks.NavigationBar.NaviBand(Me.components)
        Me.NaviBand5 = New Guifreaks.NavigationBar.NaviBand(Me.components)
        Me.naviBand1 = New Guifreaks.NavigationBar.NaviBand(Me.components)
        Me.naviBand3 = New Guifreaks.NavigationBar.NaviBand(Me.components)
        Me.naviBand2 = New Guifreaks.NavigationBar.NaviBand(Me.components)
        Me.WordDictionary = New NetSpell.SpellChecker.Dictionary.WordDictionary(Me.components)
        Me.SpellChecker = New NetSpell.SpellChecker.Spelling(Me.components)
        Me.TextBox6 = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.TextBox3 = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.TextBox2 = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.ContextMenuStrip2 = New Wisder.W3Common.WMetroControl.Controls.MetroContextMenu(Me.components)
        Me.MoveItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyItemToToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResponderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResponderATodosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EncaminharToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalvarEmailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BaixarEmaiNovamenteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExcluirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1 = New Wisder.W3Common.WMetroControl.Controls.MetroContextMenu(Me.components)
        Me.SalvarComoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaalvarTodoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MostrarTodosAnexosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.DirectoryEntry1 = New System.DirectoryServices.DirectoryEntry()
        Me.DirectorySearcher1 = New System.DirectoryServices.DirectorySearcher()
        Me.RichTextBox3 = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.naviGroup1 = New Guifreaks.NavigationBar.NaviGroup(Me.components)
        Me.naviGroup2 = New Guifreaks.NavigationBar.NaviGroup(Me.components)
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.txtThemeFile = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboOfficeStyle = New System.Windows.Forms.ComboBox()
        Me.lblLoadTheme = New System.Windows.Forms.Label()
        Me.cboChooseTheme = New System.Windows.Forms.ComboBox()
        Me.btThemeSaveXML = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.btThemeSaveIni = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.txtDateCreated = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.txtAuthorWebsite = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.txtAuthorEmail = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.txtAuthor = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.txtThemeName = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.btLoadFile = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.btGenerateThemeClass = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.c1 = New System.Windows.Forms.Label()
        Me.c2 = New System.Windows.Forms.Label()
        Me.c3 = New System.Windows.Forms.Label()
        Me.c4 = New System.Windows.Forms.Label()
        Me.ribbon1 = New System.Windows.Forms.Ribbon()
        Me.ribbonOrbMenuItem1 = New System.Windows.Forms.RibbonOrbMenuItem()
        Me.ribbonOrbMenuItem2 = New System.Windows.Forms.RibbonOrbMenuItem()
        Me.RibbonSeparator1 = New System.Windows.Forms.RibbonSeparator()
        Me.ribbonTab1 = New System.Windows.Forms.RibbonTab()
        Me.ribbonPanel1 = New System.Windows.Forms.RibbonPanel()
        Me.ribbonButton3 = New System.Windows.Forms.RibbonButton()
        Me.ribbonPanel2 = New System.Windows.Forms.RibbonPanel()
        Me.ribbonButton4 = New System.Windows.Forms.RibbonButton()
        Me.RibbonPanel3 = New System.Windows.Forms.RibbonPanel()
        Me.ribbonButton5 = New System.Windows.Forms.RibbonButton()
        Me.RibbonPanel4 = New System.Windows.Forms.RibbonPanel()
        Me.ribbonButton6 = New System.Windows.Forms.RibbonButton()
        Me.RibbonPanel5 = New System.Windows.Forms.RibbonPanel()
        Me.ribbonButton7 = New System.Windows.Forms.RibbonButton()
        Me.RibbonPanel6 = New System.Windows.Forms.RibbonPanel()
        Me.ribbonButton8 = New System.Windows.Forms.RibbonButton()
        Me.RibbonPanel11 = New System.Windows.Forms.RibbonPanel()
        Me.ribbonButton14 = New System.Windows.Forms.RibbonButton()
        Me.ribbonButton16 = New System.Windows.Forms.RibbonButton()
        Me.ribbonButton17 = New System.Windows.Forms.RibbonButton()
        Me.ribbonButton13 = New System.Windows.Forms.RibbonButton()
        Me.ribbonButton18 = New System.Windows.Forms.RibbonButton()
        Me.RibbonPanel12 = New System.Windows.Forms.RibbonPanel()
        Me.ribbonButton15 = New System.Windows.Forms.RibbonButton()
        Me.ribbonTab2 = New System.Windows.Forms.RibbonTab()
        Me.RibbonPanel7 = New System.Windows.Forms.RibbonPanel()
        Me.ribbonButton9 = New System.Windows.Forms.RibbonButton()
        Me.RibbonPanel8 = New System.Windows.Forms.RibbonPanel()
        Me.ribbonButton10 = New System.Windows.Forms.RibbonButton()
        Me.ribbonTab3 = New System.Windows.Forms.RibbonTab()
        Me.RibbonPanel9 = New System.Windows.Forms.RibbonPanel()
        Me.ribbonButton11 = New System.Windows.Forms.RibbonButton()
        Me.RibbonPanel10 = New System.Windows.Forms.RibbonPanel()
        Me.ribbonButton12 = New System.Windows.Forms.RibbonButton()
        Me.RibbonSeparator2 = New System.Windows.Forms.RibbonSeparator()
        Me.RibbonComboBox2 = New System.Windows.Forms.RibbonComboBox()
        Me.RibbonLabel1 = New System.Windows.Forms.RibbonLabel()
        Me.RibbonLabel2 = New System.Windows.Forms.RibbonLabel()
        Me.RibbonLabel3 = New System.Windows.Forms.RibbonLabel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox5 = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.RibbonTab4 = New System.Windows.Forms.RibbonTab()
        Me.TextBox1 = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.TextBox4 = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.ContextMenuStrip3 = New Wisder.W3Common.WMetroControl.Controls.MetroContextMenu(Me.components)
        Me.CriarPastaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeletarPastaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerificarSubPastaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.TextBox7 = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.TextBox8 = New Wisder.W3Common.WMetroControl.Controls.MetroTextBox()
        Me.RibbonComboBox1 = New System.Windows.Forms.RibbonComboBox()
        Me.RibbonItemGroup1 = New System.Windows.Forms.RibbonItemGroup()
        Me.Button1 = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Button2 = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.MetroToolTip1 = New Wisder.W3Common.WMetroControl.Components.MetroToolTip()
        Me.MetroButton1 = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.EmailReader1 = New EmailReader.EmailReader()
        Me.MetroComboBox1 = New Wisder.W3Common.WMetroControl.Controls.MetroComboBox()
        Me.MetroToolTip2 = New Wisder.W3Common.WMetroControl.Components.MetroToolTip()
        Me.MetroStyleManager1 = New Wisder.W3Common.WMetroControl.Components.MetroStyleManager(Me.components)
        Me.MetroStyleExtender1 = New Wisder.W3Common.WMetroControl.Components.MetroStyleExtender(Me.components)
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker3 = New System.ComponentModel.BackgroundWorker()
        Me.MetroGrid1 = New Wisder.W3Common.WMetroControl.Controls.MetroGrid()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MetroButton2 = New Wisder.W3Common.WMetroControl.Controls.MetroButton()
        Me.MetroProgressBar1 = New Wisder.W3Common.WMetroControl.Controls.MetroProgressBar()
        Me.ArboScrollableListBox2 = New ARBOControls.ARBOScrollableListBox()
        Me.ListControl1 = New Exchange_Email_ToolsIT.ListControl()
        Me.NaviMain3 = New Exchange_Email_ToolsIT.NaviMain()
        Me.NaviBand6.SuspendLayout()
        Me.NaviBand5.SuspendLayout()
        Me.naviBand1.SuspendLayout()
        Me.naviBand3.SuspendLayout()
        Me.naviBand2.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.naviGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.naviGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip3.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MetroGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NaviBand6
        '
        '
        'NaviBand6.ClientArea
        '
        resources.ApplyResources(Me.NaviBand6.ClientArea, "NaviBand6.ClientArea")
        Me.NaviBand6.ClientArea.Name = "ClientArea"
        resources.ApplyResources(Me.NaviBand6, "NaviBand6")
        Me.NaviBand6.Name = "NaviBand6"
        '
        'NaviBand5
        '
        '
        'NaviBand5.ClientArea
        '
        resources.ApplyResources(Me.NaviBand5.ClientArea, "NaviBand5.ClientArea")
        Me.NaviBand5.ClientArea.Name = "ClientArea"
        resources.ApplyResources(Me.NaviBand5, "NaviBand5")
        Me.NaviBand5.Name = "NaviBand5"
        '
        'naviBand1
        '
        '
        'naviBand1.ClientArea
        '
        resources.ApplyResources(Me.naviBand1.ClientArea, "naviBand1.ClientArea")
        Me.naviBand1.ClientArea.Name = "ClientArea"
        resources.ApplyResources(Me.naviBand1, "naviBand1")
        Me.naviBand1.Name = "naviBand1"
        '
        'naviBand3
        '
        '
        'naviBand3.ClientArea
        '
        resources.ApplyResources(Me.naviBand3.ClientArea, "naviBand3.ClientArea")
        Me.naviBand3.ClientArea.Name = "ClientArea"
        resources.ApplyResources(Me.naviBand3, "naviBand3")
        Me.naviBand3.Name = "naviBand3"
        '
        'naviBand2
        '
        '
        'naviBand2.ClientArea
        '
        resources.ApplyResources(Me.naviBand2.ClientArea, "naviBand2.ClientArea")
        Me.naviBand2.ClientArea.Name = "ClientArea"
        resources.ApplyResources(Me.naviBand2, "naviBand2")
        Me.naviBand2.Name = "naviBand2"
        '
        'WordDictionary
        '
        Me.WordDictionary.DictionaryFile = "pt-BR.dic"
        Me.WordDictionary.DictionaryFolder = "dic"
        '
        'SpellChecker
        '
        Me.SpellChecker.AlertComplete = False
        Me.SpellChecker.Dictionary = Me.WordDictionary
        '
        'TextBox6
        '
        Me.TextBox6.Lines = New String(-1) {}
        resources.ApplyResources(Me.TextBox6, "TextBox6")
        Me.TextBox6.MaxLength = 32767
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBox6.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBox6.SelectedText = ""
        Me.TextBox6.UseSelectable = True
        '
        'TextBox3
        '
        Me.TextBox3.Lines = New String(-1) {}
        resources.ApplyResources(Me.TextBox3, "TextBox3")
        Me.TextBox3.MaxLength = 32767
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBox3.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBox3.SelectedText = ""
        Me.TextBox3.UseSelectable = True
        '
        'TextBox2
        '
        Me.TextBox2.Lines = New String(-1) {}
        resources.ApplyResources(Me.TextBox2, "TextBox2")
        Me.TextBox2.MaxLength = 32767
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBox2.SelectedText = ""
        Me.TextBox2.UseSelectable = True
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ContextMenuStrip2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MoveItemToolStripMenuItem, Me.CopyItemToToolStripMenuItem, Me.ResponderToolStripMenuItem, Me.ResponderATodosToolStripMenuItem, Me.EncaminharToolStripMenuItem, Me.SalvarEmailToolStripMenuItem, Me.BaixarEmaiNovamenteToolStripMenuItem, Me.ExcluirToolStripMenuItem, Me.ImprimirToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        resources.ApplyResources(Me.ContextMenuStrip2, "ContextMenuStrip2")
        '
        'MoveItemToolStripMenuItem
        '
        resources.ApplyResources(Me.MoveItemToolStripMenuItem, "MoveItemToolStripMenuItem")
        Me.MoveItemToolStripMenuItem.Name = "MoveItemToolStripMenuItem"
        '
        'CopyItemToToolStripMenuItem
        '
        resources.ApplyResources(Me.CopyItemToToolStripMenuItem, "CopyItemToToolStripMenuItem")
        Me.CopyItemToToolStripMenuItem.Name = "CopyItemToToolStripMenuItem"
        '
        'ResponderToolStripMenuItem
        '
        resources.ApplyResources(Me.ResponderToolStripMenuItem, "ResponderToolStripMenuItem")
        Me.ResponderToolStripMenuItem.Name = "ResponderToolStripMenuItem"
        '
        'ResponderATodosToolStripMenuItem
        '
        resources.ApplyResources(Me.ResponderATodosToolStripMenuItem, "ResponderATodosToolStripMenuItem")
        Me.ResponderATodosToolStripMenuItem.Name = "ResponderATodosToolStripMenuItem"
        '
        'EncaminharToolStripMenuItem
        '
        resources.ApplyResources(Me.EncaminharToolStripMenuItem, "EncaminharToolStripMenuItem")
        Me.EncaminharToolStripMenuItem.Name = "EncaminharToolStripMenuItem"
        '
        'SalvarEmailToolStripMenuItem
        '
        resources.ApplyResources(Me.SalvarEmailToolStripMenuItem, "SalvarEmailToolStripMenuItem")
        Me.SalvarEmailToolStripMenuItem.Name = "SalvarEmailToolStripMenuItem"
        '
        'BaixarEmaiNovamenteToolStripMenuItem
        '
        resources.ApplyResources(Me.BaixarEmaiNovamenteToolStripMenuItem, "BaixarEmaiNovamenteToolStripMenuItem")
        Me.BaixarEmaiNovamenteToolStripMenuItem.Name = "BaixarEmaiNovamenteToolStripMenuItem"
        '
        'ExcluirToolStripMenuItem
        '
        resources.ApplyResources(Me.ExcluirToolStripMenuItem, "ExcluirToolStripMenuItem")
        Me.ExcluirToolStripMenuItem.Name = "ExcluirToolStripMenuItem"
        '
        'ImprimirToolStripMenuItem
        '
        resources.ApplyResources(Me.ImprimirToolStripMenuItem, "ImprimirToolStripMenuItem")
        Me.ImprimirToolStripMenuItem.Name = "ImprimirToolStripMenuItem"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalvarComoToolStripMenuItem, Me.AbrirToolStripMenuItem, Me.SaalvarTodoToolStripMenuItem, Me.MostrarTodosAnexosToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        resources.ApplyResources(Me.ContextMenuStrip1, "ContextMenuStrip1")
        Me.ContextMenuStrip1.Style = Wisder.W3Common.WMetroControl.MetroColorStyle.Blue
        Me.ContextMenuStrip1.Theme = Wisder.W3Common.WMetroControl.MetroThemeStyle.Light
        '
        'SalvarComoToolStripMenuItem
        '
        resources.ApplyResources(Me.SalvarComoToolStripMenuItem, "SalvarComoToolStripMenuItem")
        Me.SalvarComoToolStripMenuItem.Name = "SalvarComoToolStripMenuItem"
        '
        'AbrirToolStripMenuItem
        '
        resources.ApplyResources(Me.AbrirToolStripMenuItem, "AbrirToolStripMenuItem")
        Me.AbrirToolStripMenuItem.Name = "AbrirToolStripMenuItem"
        '
        'SaalvarTodoToolStripMenuItem
        '
        resources.ApplyResources(Me.SaalvarTodoToolStripMenuItem, "SaalvarTodoToolStripMenuItem")
        Me.SaalvarTodoToolStripMenuItem.Name = "SaalvarTodoToolStripMenuItem"
        '
        'MostrarTodosAnexosToolStripMenuItem
        '
        resources.ApplyResources(Me.MostrarTodosAnexosToolStripMenuItem, "MostrarTodosAnexosToolStripMenuItem")
        Me.MostrarTodosAnexosToolStripMenuItem.Name = "MostrarTodosAnexosToolStripMenuItem"
        '
        'DirectorySearcher1
        '
        Me.DirectorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01")
        '
        'RichTextBox3
        '
        Me.RichTextBox3.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.RichTextBox3, "RichTextBox3")
        Me.RichTextBox3.FontSize = Wisder.W3Common.WMetroControl.MetroTextBoxSize.Medium
        Me.RichTextBox3.Lines = New String(-1) {}
        Me.RichTextBox3.MaxLength = 32767
        Me.RichTextBox3.Name = "RichTextBox3"
        Me.RichTextBox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.RichTextBox3.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.RichTextBox3.SelectedText = ""
        Me.RichTextBox3.Style = Wisder.W3Common.WMetroControl.MetroColorStyle.Blue
        Me.RichTextBox3.Theme = Wisder.W3Common.WMetroControl.MetroThemeStyle.Light
        Me.RichTextBox3.UseSelectable = True
        Me.RichTextBox3.UseStyleColors = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'naviGroup1
        '
        Me.naviGroup1.Caption = Nothing
        resources.ApplyResources(Me.naviGroup1, "naviGroup1")
        Me.naviGroup1.ExpandedHeight = 110
        Me.naviGroup1.HeaderContextMenuStrip = Nothing
        Me.naviGroup1.LayoutStyle = Guifreaks.NavigationBar.NaviLayoutStyle.Office2007Black
        Me.naviGroup1.Name = "naviGroup1"
        '
        'naviGroup2
        '
        Me.naviGroup2.Caption = Nothing
        Me.naviGroup2.HeaderContextMenuStrip = Nothing
        resources.ApplyResources(Me.naviGroup2, "naviGroup2")
        Me.naviGroup2.Name = "naviGroup2"
        '
        'panel1
        '
        resources.ApplyResources(Me.panel1, "panel1")
        Me.panel1.Name = "panel1"
        '
        'txtThemeFile
        '
        Me.txtThemeFile.Lines = New String(-1) {}
        resources.ApplyResources(Me.txtThemeFile, "txtThemeFile")
        Me.txtThemeFile.MaxLength = 32767
        Me.txtThemeFile.Name = "txtThemeFile"
        Me.txtThemeFile.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtThemeFile.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtThemeFile.SelectedText = ""
        Me.txtThemeFile.UseSelectable = True
        '
        'groupBox1
        '
        resources.ApplyResources(Me.groupBox1, "groupBox1")
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.TabStop = False
        '
        'cboOfficeStyle
        '
        resources.ApplyResources(Me.cboOfficeStyle, "cboOfficeStyle")
        Me.cboOfficeStyle.Name = "cboOfficeStyle"
        '
        'lblLoadTheme
        '
        resources.ApplyResources(Me.lblLoadTheme, "lblLoadTheme")
        Me.lblLoadTheme.Name = "lblLoadTheme"
        '
        'cboChooseTheme
        '
        resources.ApplyResources(Me.cboChooseTheme, "cboChooseTheme")
        Me.cboChooseTheme.Name = "cboChooseTheme"
        '
        'btThemeSaveXML
        '
        resources.ApplyResources(Me.btThemeSaveXML, "btThemeSaveXML")
        Me.btThemeSaveXML.Name = "btThemeSaveXML"
        Me.btThemeSaveXML.UseSelectable = True
        '
        'btThemeSaveIni
        '
        resources.ApplyResources(Me.btThemeSaveIni, "btThemeSaveIni")
        Me.btThemeSaveIni.Name = "btThemeSaveIni"
        Me.btThemeSaveIni.UseSelectable = True
        '
        'txtDateCreated
        '
        Me.txtDateCreated.Lines = New String(-1) {}
        resources.ApplyResources(Me.txtDateCreated, "txtDateCreated")
        Me.txtDateCreated.MaxLength = 32767
        Me.txtDateCreated.Name = "txtDateCreated"
        Me.txtDateCreated.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDateCreated.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtDateCreated.SelectedText = ""
        Me.txtDateCreated.UseSelectable = True
        '
        'txtAuthorWebsite
        '
        Me.txtAuthorWebsite.Lines = New String(-1) {}
        resources.ApplyResources(Me.txtAuthorWebsite, "txtAuthorWebsite")
        Me.txtAuthorWebsite.MaxLength = 32767
        Me.txtAuthorWebsite.Name = "txtAuthorWebsite"
        Me.txtAuthorWebsite.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtAuthorWebsite.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtAuthorWebsite.SelectedText = ""
        Me.txtAuthorWebsite.UseSelectable = True
        '
        'txtAuthorEmail
        '
        Me.txtAuthorEmail.Lines = New String(-1) {}
        resources.ApplyResources(Me.txtAuthorEmail, "txtAuthorEmail")
        Me.txtAuthorEmail.MaxLength = 32767
        Me.txtAuthorEmail.Name = "txtAuthorEmail"
        Me.txtAuthorEmail.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtAuthorEmail.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtAuthorEmail.SelectedText = ""
        Me.txtAuthorEmail.UseSelectable = True
        '
        'txtAuthor
        '
        Me.txtAuthor.Lines = New String(-1) {}
        resources.ApplyResources(Me.txtAuthor, "txtAuthor")
        Me.txtAuthor.MaxLength = 32767
        Me.txtAuthor.Name = "txtAuthor"
        Me.txtAuthor.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtAuthor.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtAuthor.SelectedText = ""
        Me.txtAuthor.UseSelectable = True
        '
        'txtThemeName
        '
        Me.txtThemeName.Lines = New String(-1) {}
        resources.ApplyResources(Me.txtThemeName, "txtThemeName")
        Me.txtThemeName.MaxLength = 32767
        Me.txtThemeName.Name = "txtThemeName"
        Me.txtThemeName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtThemeName.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtThemeName.SelectedText = ""
        Me.txtThemeName.UseSelectable = True
        '
        'btLoadFile
        '
        resources.ApplyResources(Me.btLoadFile, "btLoadFile")
        Me.btLoadFile.Name = "btLoadFile"
        Me.btLoadFile.UseSelectable = True
        '
        'btGenerateThemeClass
        '
        resources.ApplyResources(Me.btGenerateThemeClass, "btGenerateThemeClass")
        Me.btGenerateThemeClass.Name = "btGenerateThemeClass"
        Me.btGenerateThemeClass.UseSelectable = True
        '
        'tableLayoutPanel1
        '
        resources.ApplyResources(Me.tableLayoutPanel1, "tableLayoutPanel1")
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        '
        'c1
        '
        resources.ApplyResources(Me.c1, "c1")
        Me.c1.Name = "c1"
        '
        'c2
        '
        resources.ApplyResources(Me.c2, "c2")
        Me.c2.Name = "c2"
        '
        'c3
        '
        resources.ApplyResources(Me.c3, "c3")
        Me.c3.Name = "c3"
        '
        'c4
        '
        resources.ApplyResources(Me.c4, "c4")
        Me.c4.Name = "c4"
        '
        'ribbon1
        '
        resources.ApplyResources(Me.ribbon1, "ribbon1")
        Me.ribbon1.BackColor = System.Drawing.Color.White
        Me.ribbon1.CaptionBarVisible = False
        Me.ribbon1.ForeColor = System.Drawing.Color.Black
        Me.ribbon1.Minimized = False
        Me.ribbon1.Name = "ribbon1"
        '
        '
        '
        Me.ribbon1.OrbDropDown.BorderRoundness = 8
        Me.ribbon1.OrbDropDown.Location = CType(resources.GetObject("ribbon1.OrbDropDown.Location"), System.Drawing.Point)
        Me.ribbon1.OrbDropDown.MenuItems.Add(Me.ribbonOrbMenuItem1)
        Me.ribbon1.OrbDropDown.MenuItems.Add(Me.ribbonOrbMenuItem2)
        Me.ribbon1.OrbDropDown.MenuItems.Add(Me.RibbonSeparator1)
        Me.ribbon1.OrbDropDown.Name = ""
        Me.ribbon1.OrbDropDown.Size = CType(resources.GetObject("ribbon1.OrbDropDown.Size"), System.Drawing.Size)
        Me.ribbon1.OrbDropDown.TabIndex = CType(resources.GetObject("ribbon1.OrbDropDown.TabIndex"), Integer)
        Me.ribbon1.OrbImage = Nothing
        Me.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013
        Me.ribbon1.OrbText = "ARQUIVO"
        Me.ribbon1.RibbonTabFont = New System.Drawing.Font("Britannic Bold", 9.0!)
        Me.ribbon1.Tabs.Add(Me.ribbonTab1)
        Me.ribbon1.Tabs.Add(Me.ribbonTab2)
        Me.ribbon1.Tabs.Add(Me.ribbonTab3)
        Me.ribbon1.TabsMargin = New System.Windows.Forms.Padding(12, 2, 20, 0)
        Me.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue
        '
        'ribbonOrbMenuItem1
        '
        Me.ribbonOrbMenuItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.ribbonOrbMenuItem1.Image = CType(resources.GetObject("ribbonOrbMenuItem1.Image"), System.Drawing.Image)
        Me.ribbonOrbMenuItem1.SmallImage = CType(resources.GetObject("ribbonOrbMenuItem1.SmallImage"), System.Drawing.Image)
        resources.ApplyResources(Me.ribbonOrbMenuItem1, "ribbonOrbMenuItem1")
        '
        'ribbonOrbMenuItem2
        '
        Me.ribbonOrbMenuItem2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left
        Me.ribbonOrbMenuItem2.Image = CType(resources.GetObject("ribbonOrbMenuItem2.Image"), System.Drawing.Image)
        Me.ribbonOrbMenuItem2.SmallImage = CType(resources.GetObject("ribbonOrbMenuItem2.SmallImage"), System.Drawing.Image)
        resources.ApplyResources(Me.ribbonOrbMenuItem2, "ribbonOrbMenuItem2")
        '
        'ribbonTab1
        '
        Me.ribbonTab1.Panels.Add(Me.ribbonPanel1)
        Me.ribbonTab1.Panels.Add(Me.ribbonPanel2)
        Me.ribbonTab1.Panels.Add(Me.RibbonPanel3)
        Me.ribbonTab1.Panels.Add(Me.RibbonPanel4)
        Me.ribbonTab1.Panels.Add(Me.RibbonPanel5)
        Me.ribbonTab1.Panels.Add(Me.RibbonPanel6)
        Me.ribbonTab1.Panels.Add(Me.RibbonPanel11)
        Me.ribbonTab1.Panels.Add(Me.RibbonPanel12)
        resources.ApplyResources(Me.ribbonTab1, "ribbonTab1")
        '
        'ribbonPanel1
        '
        Me.ribbonPanel1.Items.Add(Me.ribbonButton3)
        resources.ApplyResources(Me.ribbonPanel1, "ribbonPanel1")
        '
        'ribbonButton3
        '
        Me.ribbonButton3.Image = CType(resources.GetObject("ribbonButton3.Image"), System.Drawing.Image)
        Me.ribbonButton3.SmallImage = CType(resources.GetObject("ribbonButton3.SmallImage"), System.Drawing.Image)
        resources.ApplyResources(Me.ribbonButton3, "ribbonButton3")
        '
        'ribbonPanel2
        '
        Me.ribbonPanel2.Items.Add(Me.ribbonButton4)
        resources.ApplyResources(Me.ribbonPanel2, "ribbonPanel2")
        '
        'ribbonButton4
        '
        Me.ribbonButton4.Image = CType(resources.GetObject("ribbonButton4.Image"), System.Drawing.Image)
        Me.ribbonButton4.SmallImage = CType(resources.GetObject("ribbonButton4.SmallImage"), System.Drawing.Image)
        '
        'RibbonPanel3
        '
        Me.RibbonPanel3.Items.Add(Me.ribbonButton5)
        resources.ApplyResources(Me.RibbonPanel3, "RibbonPanel3")
        '
        'ribbonButton5
        '
        Me.ribbonButton5.Image = CType(resources.GetObject("ribbonButton5.Image"), System.Drawing.Image)
        Me.ribbonButton5.SmallImage = CType(resources.GetObject("ribbonButton5.SmallImage"), System.Drawing.Image)
        '
        'RibbonPanel4
        '
        Me.RibbonPanel4.Items.Add(Me.ribbonButton6)
        resources.ApplyResources(Me.RibbonPanel4, "RibbonPanel4")
        '
        'ribbonButton6
        '
        Me.ribbonButton6.Image = CType(resources.GetObject("ribbonButton6.Image"), System.Drawing.Image)
        Me.ribbonButton6.SmallImage = CType(resources.GetObject("ribbonButton6.SmallImage"), System.Drawing.Image)
        '
        'RibbonPanel5
        '
        Me.RibbonPanel5.Items.Add(Me.ribbonButton7)
        resources.ApplyResources(Me.RibbonPanel5, "RibbonPanel5")
        '
        'ribbonButton7
        '
        Me.ribbonButton7.Image = CType(resources.GetObject("ribbonButton7.Image"), System.Drawing.Image)
        Me.ribbonButton7.SmallImage = CType(resources.GetObject("ribbonButton7.SmallImage"), System.Drawing.Image)
        '
        'RibbonPanel6
        '
        Me.RibbonPanel6.Items.Add(Me.ribbonButton8)
        resources.ApplyResources(Me.RibbonPanel6, "RibbonPanel6")
        '
        'ribbonButton8
        '
        Me.ribbonButton8.Image = CType(resources.GetObject("ribbonButton8.Image"), System.Drawing.Image)
        Me.ribbonButton8.SmallImage = CType(resources.GetObject("ribbonButton8.SmallImage"), System.Drawing.Image)
        '
        'RibbonPanel11
        '
        Me.RibbonPanel11.Items.Add(Me.ribbonButton14)
        Me.RibbonPanel11.Items.Add(Me.ribbonButton16)
        Me.RibbonPanel11.Items.Add(Me.ribbonButton17)
        Me.RibbonPanel11.Items.Add(Me.ribbonButton13)
        Me.RibbonPanel11.Items.Add(Me.ribbonButton18)
        resources.ApplyResources(Me.RibbonPanel11, "RibbonPanel11")
        '
        'ribbonButton14
        '
        Me.ribbonButton14.Image = CType(resources.GetObject("ribbonButton14.Image"), System.Drawing.Image)
        Me.ribbonButton14.SmallImage = CType(resources.GetObject("ribbonButton14.SmallImage"), System.Drawing.Image)
        resources.ApplyResources(Me.ribbonButton14, "ribbonButton14")
        '
        'ribbonButton16
        '
        Me.ribbonButton16.Image = CType(resources.GetObject("ribbonButton16.Image"), System.Drawing.Image)
        Me.ribbonButton16.SmallImage = CType(resources.GetObject("ribbonButton16.SmallImage"), System.Drawing.Image)
        resources.ApplyResources(Me.ribbonButton16, "ribbonButton16")
        '
        'ribbonButton17
        '
        Me.ribbonButton17.Image = CType(resources.GetObject("ribbonButton17.Image"), System.Drawing.Image)
        Me.ribbonButton17.SmallImage = CType(resources.GetObject("ribbonButton17.SmallImage"), System.Drawing.Image)
        resources.ApplyResources(Me.ribbonButton17, "ribbonButton17")
        '
        'ribbonButton13
        '
        Me.ribbonButton13.Image = CType(resources.GetObject("ribbonButton13.Image"), System.Drawing.Image)
        Me.ribbonButton13.SmallImage = CType(resources.GetObject("ribbonButton13.SmallImage"), System.Drawing.Image)
        resources.ApplyResources(Me.ribbonButton13, "ribbonButton13")
        '
        'ribbonButton18
        '
        Me.ribbonButton18.Image = CType(resources.GetObject("ribbonButton18.Image"), System.Drawing.Image)
        Me.ribbonButton18.SmallImage = CType(resources.GetObject("ribbonButton18.SmallImage"), System.Drawing.Image)
        resources.ApplyResources(Me.ribbonButton18, "ribbonButton18")
        '
        'RibbonPanel12
        '
        Me.RibbonPanel12.Items.Add(Me.ribbonButton15)
        resources.ApplyResources(Me.RibbonPanel12, "RibbonPanel12")
        '
        'ribbonButton15
        '
        Me.ribbonButton15.Image = CType(resources.GetObject("ribbonButton15.Image"), System.Drawing.Image)
        Me.ribbonButton15.SmallImage = CType(resources.GetObject("ribbonButton15.SmallImage"), System.Drawing.Image)
        '
        'ribbonTab2
        '
        Me.ribbonTab2.Panels.Add(Me.RibbonPanel7)
        Me.ribbonTab2.Panels.Add(Me.RibbonPanel8)
        resources.ApplyResources(Me.ribbonTab2, "ribbonTab2")
        '
        'RibbonPanel7
        '
        Me.RibbonPanel7.Items.Add(Me.ribbonButton9)
        resources.ApplyResources(Me.RibbonPanel7, "RibbonPanel7")
        '
        'ribbonButton9
        '
        Me.ribbonButton9.Image = CType(resources.GetObject("ribbonButton9.Image"), System.Drawing.Image)
        Me.ribbonButton9.SmallImage = CType(resources.GetObject("ribbonButton9.SmallImage"), System.Drawing.Image)
        '
        'RibbonPanel8
        '
        Me.RibbonPanel8.Items.Add(Me.ribbonButton10)
        resources.ApplyResources(Me.RibbonPanel8, "RibbonPanel8")
        '
        'ribbonButton10
        '
        Me.ribbonButton10.Image = CType(resources.GetObject("ribbonButton10.Image"), System.Drawing.Image)
        Me.ribbonButton10.SmallImage = CType(resources.GetObject("ribbonButton10.SmallImage"), System.Drawing.Image)
        '
        'ribbonTab3
        '
        Me.ribbonTab3.Panels.Add(Me.RibbonPanel9)
        Me.ribbonTab3.Panels.Add(Me.RibbonPanel10)
        resources.ApplyResources(Me.ribbonTab3, "ribbonTab3")
        '
        'RibbonPanel9
        '
        Me.RibbonPanel9.Items.Add(Me.ribbonButton11)
        resources.ApplyResources(Me.RibbonPanel9, "RibbonPanel9")
        '
        'ribbonButton11
        '
        Me.ribbonButton11.Image = CType(resources.GetObject("ribbonButton11.Image"), System.Drawing.Image)
        Me.ribbonButton11.SmallImage = CType(resources.GetObject("ribbonButton11.SmallImage"), System.Drawing.Image)
        '
        'RibbonPanel10
        '
        Me.RibbonPanel10.Items.Add(Me.ribbonButton12)
        Me.RibbonPanel10.Items.Add(Me.RibbonSeparator2)
        Me.RibbonPanel10.Items.Add(Me.RibbonComboBox2)
        resources.ApplyResources(Me.RibbonPanel10, "RibbonPanel10")
        '
        'ribbonButton12
        '
        Me.ribbonButton12.Image = CType(resources.GetObject("ribbonButton12.Image"), System.Drawing.Image)
        Me.ribbonButton12.SmallImage = CType(resources.GetObject("ribbonButton12.SmallImage"), System.Drawing.Image)
        '
        'RibbonComboBox2
        '
        Me.RibbonComboBox2.DropDownItems.Add(Me.RibbonLabel1)
        Me.RibbonComboBox2.DropDownItems.Add(Me.RibbonLabel2)
        Me.RibbonComboBox2.DropDownItems.Add(Me.RibbonLabel3)
        resources.ApplyResources(Me.RibbonComboBox2, "RibbonComboBox2")
        Me.RibbonComboBox2.TextBoxText = ""
        Me.RibbonComboBox2.Value = ""
        '
        'RibbonLabel1
        '
        resources.ApplyResources(Me.RibbonLabel1, "RibbonLabel1")
        '
        'RibbonLabel2
        '
        resources.ApplyResources(Me.RibbonLabel2, "RibbonLabel2")
        '
        'RibbonLabel3
        '
        resources.ApplyResources(Me.RibbonLabel3, "RibbonLabel3")
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Name = "Label8"
        '
        'TextBox5
        '
        Me.TextBox5.Lines = New String(-1) {}
        resources.ApplyResources(Me.TextBox5, "TextBox5")
        Me.TextBox5.MaxLength = 32767
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBox5.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBox5.SelectedText = ""
        Me.TextBox5.UseSelectable = True
        '
        'RibbonTab4
        '
        resources.ApplyResources(Me.RibbonTab4, "RibbonTab4")
        '
        'TextBox1
        '
        Me.TextBox1.Lines = New String(-1) {}
        resources.ApplyResources(Me.TextBox1, "TextBox1")
        Me.TextBox1.MaxLength = 32767
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBox1.SelectedText = ""
        Me.TextBox1.UseSelectable = True
        '
        'TextBox4
        '
        Me.TextBox4.Lines = New String(-1) {}
        resources.ApplyResources(Me.TextBox4, "TextBox4")
        Me.TextBox4.MaxLength = 32767
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBox4.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBox4.SelectedText = ""
        Me.TextBox4.UseSelectable = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.HotTrack
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Name = "Label2"
        '
        'RichTextBox1
        '
        resources.ApplyResources(Me.RichTextBox1, "RichTextBox1")
        Me.RichTextBox1.Name = "RichTextBox1"
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ContextMenuStrip3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ContextMenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CriarPastaToolStripMenuItem, Me.DeletarPastaToolStripMenuItem, Me.VerificarSubPastaToolStripMenuItem})
        Me.ContextMenuStrip3.Name = "ContextMenuStrip3"
        resources.ApplyResources(Me.ContextMenuStrip3, "ContextMenuStrip3")
        '
        'CriarPastaToolStripMenuItem
        '
        resources.ApplyResources(Me.CriarPastaToolStripMenuItem, "CriarPastaToolStripMenuItem")
        Me.CriarPastaToolStripMenuItem.Name = "CriarPastaToolStripMenuItem"
        '
        'DeletarPastaToolStripMenuItem
        '
        resources.ApplyResources(Me.DeletarPastaToolStripMenuItem, "DeletarPastaToolStripMenuItem")
        Me.DeletarPastaToolStripMenuItem.Name = "DeletarPastaToolStripMenuItem"
        '
        'VerificarSubPastaToolStripMenuItem
        '
        resources.ApplyResources(Me.VerificarSubPastaToolStripMenuItem, "VerificarSubPastaToolStripMenuItem")
        Me.VerificarSubPastaToolStripMenuItem.Name = "VerificarSubPastaToolStripMenuItem"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "Folder.ico")
        Me.ImageList2.Images.SetKeyName(1, "29-16.png")
        '
        'TextBox7
        '
        Me.TextBox7.Lines = New String(-1) {}
        resources.ApplyResources(Me.TextBox7, "TextBox7")
        Me.TextBox7.MaxLength = 32767
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBox7.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBox7.SelectedText = ""
        Me.TextBox7.UseSelectable = True
        '
        'TextBox8
        '
        Me.TextBox8.Lines = New String(-1) {}
        resources.ApplyResources(Me.TextBox8, "TextBox8")
        Me.TextBox8.MaxLength = 32767
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.TextBox8.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.TextBox8.SelectedText = ""
        Me.TextBox8.UseSelectable = True
        '
        'RibbonComboBox1
        '
        Me.RibbonComboBox1.TextBoxText = ""
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.DodgerBlue
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Name = "Button1"
        Me.Button1.Style = Wisder.W3Common.WMetroControl.MetroColorStyle.Blue
        Me.Button1.Theme = Wisder.W3Common.WMetroControl.MetroThemeStyle.Light
        Me.Button1.UseCustomBackColor = True
        Me.Button1.UseCustomForeColor = True
        Me.Button1.UseSelectable = True
        Me.Button1.UseStyleColors = True
        Me.Button1.UseVisualStyleBackColor = False
        '
        'StatusStrip1
        '
        Me.MetroStyleExtender1.SetApplyMetroTheme(Me.StatusStrip1, True)
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode
        Me.StatusStrip1.Stretch = False
        '
        'ToolStripProgressBar1
        '
        resources.ApplyResources(Me.ToolStripProgressBar1, "ToolStripProgressBar1")
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.ToolStripStatusLabel1, "ToolStripStatusLabel1")
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel2
        '
        resources.ApplyResources(Me.ToolStripStatusLabel2, "ToolStripStatusLabel2")
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel2.LinkColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        '
        'ToolStripStatusLabel3
        '
        resources.ApplyResources(Me.ToolStripStatusLabel3, "ToolStripStatusLabel3")
        Me.ToolStripStatusLabel3.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        '
        'WebBrowser1
        '
        resources.ApplyResources(Me.WebBrowser1, "WebBrowser1")
        Me.WebBrowser1.Name = "WebBrowser1"
        '
        'Timer2
        '
        Me.Timer2.Interval = 20000
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.DodgerBlue
        resources.ApplyResources(Me.Button2, "Button2")
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Name = "Button2"
        Me.Button2.UseCustomBackColor = True
        Me.Button2.UseCustomForeColor = True
        Me.Button2.UseSelectable = True
        Me.Button2.UseVisualStyleBackColor = False
        '
        'MetroToolTip1
        '
        Me.MetroToolTip1.Style = Wisder.W3Common.WMetroControl.MetroColorStyle.Blue
        Me.MetroToolTip1.StyleManager = Nothing
        Me.MetroToolTip1.Theme = Wisder.W3Common.WMetroControl.MetroThemeStyle.Light
        '
        'MetroButton1
        '
        Me.MetroButton1.BackColor = System.Drawing.SystemColors.HotTrack
        resources.ApplyResources(Me.MetroButton1, "MetroButton1")
        Me.MetroButton1.ForeColor = System.Drawing.Color.White
        Me.MetroButton1.Name = "MetroButton1"
        Me.MetroButton1.Style = Wisder.W3Common.WMetroControl.MetroColorStyle.Black
        Me.MetroButton1.Theme = Wisder.W3Common.WMetroControl.MetroThemeStyle.Light
        Me.MetroButton1.UseCustomBackColor = True
        Me.MetroButton1.UseCustomForeColor = True
        Me.MetroButton1.UseSelectable = True
        Me.MetroButton1.UseStyleColors = True
        Me.MetroButton1.UseVisualStyleBackColor = False
        '
        'EmailReader1
        '
        resources.ApplyResources(Me.EmailReader1, "EmailReader1")
        Me.EmailReader1.Name = "EmailReader1"
        '
        'MetroComboBox1
        '
        Me.MetroComboBox1.DisplayFocus = True
        Me.MetroComboBox1.DropDownWidth = 100
        resources.ApplyResources(Me.MetroComboBox1, "MetroComboBox1")
        Me.MetroComboBox1.FormattingEnabled = True
        Me.MetroComboBox1.Items.AddRange(New Object() {resources.GetString("MetroComboBox1.Items"), resources.GetString("MetroComboBox1.Items1"), resources.GetString("MetroComboBox1.Items2"), resources.GetString("MetroComboBox1.Items3"), resources.GetString("MetroComboBox1.Items4")})
        Me.MetroComboBox1.Name = "MetroComboBox1"
        Me.MetroComboBox1.PromptText = "Data:"
        Me.MetroComboBox1.UseSelectable = True
        Me.MetroComboBox1.UseStyleColors = True
        '
        'MetroToolTip2
        '
        Me.MetroToolTip2.Style = Wisder.W3Common.WMetroControl.MetroColorStyle.Blue
        Me.MetroToolTip2.StyleManager = Nothing
        Me.MetroToolTip2.Theme = Wisder.W3Common.WMetroControl.MetroThemeStyle.Light
        '
        'MetroStyleManager1
        '
        Me.MetroStyleManager1.Owner = Me
        '
        'BackgroundWorker2
        '
        Me.BackgroundWorker2.WorkerReportsProgress = True
        Me.BackgroundWorker2.WorkerSupportsCancellation = True
        '
        'BackgroundWorker3
        '
        Me.BackgroundWorker3.WorkerReportsProgress = True
        Me.BackgroundWorker3.WorkerSupportsCancellation = True
        '
        'MetroGrid1
        '
        Me.MetroGrid1.AllowUserToResizeRows = False
        Me.MetroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MetroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MetroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.MetroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MetroGrid1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.MetroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MetroGrid1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(136, Byte), Integer))
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MetroGrid1.DefaultCellStyle = DataGridViewCellStyle11
        Me.MetroGrid1.EnableHeadersVisualStyles = False
        resources.ApplyResources(Me.MetroGrid1, "MetroGrid1")
        Me.MetroGrid1.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MetroGrid1.Name = "MetroGrid1"
        Me.MetroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(219, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MetroGrid1.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.MetroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.MetroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'Column1
        '
        resources.ApplyResources(Me.Column1, "Column1")
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        resources.ApplyResources(Me.Column2, "Column2")
        Me.Column2.Name = "Column2"
        '
        'MetroButton2
        '
        Me.MetroButton2.BackColor = System.Drawing.Color.DodgerBlue
        resources.ApplyResources(Me.MetroButton2, "MetroButton2")
        Me.MetroButton2.ForeColor = System.Drawing.Color.Black
        Me.MetroButton2.Name = "MetroButton2"
        Me.MetroButton2.UseCustomBackColor = True
        Me.MetroButton2.UseCustomForeColor = True
        Me.MetroButton2.UseSelectable = True
        Me.MetroButton2.UseVisualStyleBackColor = False
        '
        'MetroProgressBar1
        '
        resources.ApplyResources(Me.MetroProgressBar1, "MetroProgressBar1")
        Me.MetroProgressBar1.Name = "MetroProgressBar1"
        '
        'ArboScrollableListBox2
        '
        Me.ArboScrollableListBox2.AdaptControlHeight = True
        Me.ArboScrollableListBox2.AdaptControlWidth = True
        resources.ApplyResources(Me.ArboScrollableListBox2, "ArboScrollableListBox2")
        Me.ArboScrollableListBox2.Comparer = Nothing
        Me.ArboScrollableListBox2.ContextMenuStrip = Me.ContextMenuStrip2
        Me.ArboScrollableListBox2.CurrentSelected = Nothing
        Me.ArboScrollableListBox2.Name = "ArboScrollableListBox2"
        Me.ArboScrollableListBox2.Orientation = ARBOControls.ARBOScrollableListBox.OrientationEnum.Vertical
        '
        'ListControl1
        '
        resources.ApplyResources(Me.ListControl1, "ListControl1")
        Me.ListControl1.BackColor = System.Drawing.SystemColors.Window
        Me.ListControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListControl1.Name = "ListControl1"
        '
        'NaviMain3
        '
        Me.NaviMain3.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.NaviMain3, "NaviMain3")
        Me.NaviMain3.Name = "NaviMain3"
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ListControl1)
        Me.Controls.Add(Me.ArboScrollableListBox2)
        Me.Controls.Add(Me.MetroButton1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MetroProgressBar1)
        Me.Controls.Add(Me.MetroButton2)
        Me.Controls.Add(Me.MetroGrid1)
        Me.Controls.Add(Me.MetroComboBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.EmailReader1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox8)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ribbon1)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.RichTextBox3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.NaviMain3)
        Me.DisplayHeader = False
        Me.ForeColor = System.Drawing.Color.White
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.ShadowType = Wisder.W3Common.WMetroControl.Forms.MetroFormShadowType.SystemShadow
        Me.TransparencyKey = System.Drawing.Color.Empty
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.NaviBand6.ResumeLayout(False)
        Me.NaviBand5.ResumeLayout(False)
        Me.naviBand1.ResumeLayout(False)
        Me.naviBand3.ResumeLayout(False)
        Me.naviBand2.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.naviGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.naviGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip3.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.MetroStyleManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MetroGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub
    Friend WithEvents ContextMenuStrip1 As Wisder.W3Common.WMetroControl.Controls.MetroContextMenu
    Friend WithEvents SalvarComoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbrirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ContextMenuStrip2 As Wisder.W3Common.WMetroControl.Controls.MetroContextMenu
    Friend WithEvents ImprimirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResponderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResponderATodosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EncaminharToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExcluirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoveItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyItemToToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DirectoryEntry1 As System.DirectoryServices.DirectoryEntry
    Friend WithEvents DirectorySearcher1 As System.DirectoryServices.DirectorySearcher
    Friend WithEvents RichTextBox3 As Wisder.W3Common.WMetroControl.Controls.MetroTextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TextBox3 As Wisder.W3Common.WMetroControl.Controls.MetroTextBox
    Friend WithEvents TextBox2 As Wisder.W3Common.WMetroControl.Controls.MetroTextBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents SalvarEmailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextBox6 As Wisder.W3Common.WMetroControl.Controls.MetroTextBox
    Private WithEvents naviButton1 As Guifreaks.NavigationBar.NaviButton
    Friend WithEvents NaviBand6 As Guifreaks.NavigationBar.NaviBand
    Friend WithEvents NaviBand5 As Guifreaks.NavigationBar.NaviBand
    Private WithEvents naviBand1 As Guifreaks.NavigationBar.NaviBand
    Private WithEvents naviBand3 As Guifreaks.NavigationBar.NaviBand
    Private WithEvents naviGroup1 As Guifreaks.NavigationBar.NaviGroup
    Private WithEvents naviGroup2 As Guifreaks.NavigationBar.NaviGroup
    Private WithEvents naviBand2 As Guifreaks.NavigationBar.NaviBand
    Private panel1 As System.Windows.Forms.Panel
    Private txtThemeFile As Wisder.W3Common.WMetroControl.Controls.MetroTextBox

    Private groupBox1 As System.Windows.Forms.GroupBox



    Private txtDateCreated As Wisder.W3Common.WMetroControl.Controls.MetroTextBox

    Private txtAuthorWebsite As Wisder.W3Common.WMetroControl.Controls.MetroTextBox

    Private txtAuthorEmail As Wisder.W3Common.WMetroControl.Controls.MetroTextBox

    Private txtAuthor As Wisder.W3Common.WMetroControl.Controls.MetroTextBox

    Private txtThemeName As Wisder.W3Common.WMetroControl.Controls.MetroTextBox



    Private tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel

    Private c1 As System.Windows.Forms.Label

    Private c2 As System.Windows.Forms.Label

    Private c3 As System.Windows.Forms.Label

    Private c4 As System.Windows.Forms.Label

    Private ribbonTab1 As System.Windows.Forms.RibbonTab

    Friend ribbonPanel1 As System.Windows.Forms.RibbonPanel


    Friend ribbonPanel2 As System.Windows.Forms.RibbonPanel

    Private WithEvents ribbonOrbMenuItem1 As System.Windows.Forms.RibbonOrbMenuItem

    Private WithEvents ribbonOrbMenuItem2 As System.Windows.Forms.RibbonOrbMenuItem

    Private lblLoadTheme As System.Windows.Forms.Label

    Private cboChooseTheme As System.Windows.Forms.ComboBox


    Private cboOfficeStyle As System.Windows.Forms.ComboBox

    Private ribbonTab2 As System.Windows.Forms.RibbonTab

    Private ribbonTab3 As System.Windows.Forms.RibbonTab

    Private WithEvents ribbonButton3 As System.Windows.Forms.RibbonButton
    Friend WithEvents RibbonPanel3 As System.Windows.Forms.RibbonPanel
    Friend WithEvents RibbonPanel4 As System.Windows.Forms.RibbonPanel
    Friend WithEvents RibbonPanel5 As System.Windows.Forms.RibbonPanel
    Friend WithEvents RibbonPanel6 As System.Windows.Forms.RibbonPanel
    Friend WithEvents RibbonPanel7 As System.Windows.Forms.RibbonPanel
    Friend WithEvents RibbonPanel8 As System.Windows.Forms.RibbonPanel
    Friend WithEvents RibbonPanel9 As System.Windows.Forms.RibbonPanel
    Friend WithEvents RibbonPanel10 As System.Windows.Forms.RibbonPanel
    Friend WithEvents ribbonButton4 As System.Windows.Forms.RibbonButton
    Friend WithEvents ribbonButton5 As System.Windows.Forms.RibbonButton
    Friend WithEvents ribbonButton6 As System.Windows.Forms.RibbonButton
    Friend WithEvents ribbonButton7 As System.Windows.Forms.RibbonButton
    Friend WithEvents ribbonButton8 As System.Windows.Forms.RibbonButton
    Friend WithEvents ribbonButton9 As System.Windows.Forms.RibbonButton
    Friend WithEvents ribbonButton10 As System.Windows.Forms.RibbonButton
    Friend WithEvents ribbonButton11 As System.Windows.Forms.RibbonButton
    Friend WithEvents ribbonButton12 As System.Windows.Forms.RibbonButton
    Friend WithEvents ribbonButton13 As System.Windows.Forms.RibbonButton
    Friend WithEvents ribbonButton14 As System.Windows.Forms.RibbonButton
    Friend WithEvents ribbonButton15 As System.Windows.Forms.RibbonButton
    Friend WithEvents ribbonButton16 As System.Windows.Forms.RibbonButton
    Friend WithEvents ribbonButton17 As System.Windows.Forms.RibbonButton
    Friend WithEvents ribbonButton18 As System.Windows.Forms.RibbonButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As Wisder.W3Common.WMetroControl.Controls.MetroTextBox
    Friend WithEvents RibbonSeparator1 As System.Windows.Forms.RibbonSeparator
    Friend WithEvents RibbonTab4 As System.Windows.Forms.RibbonTab
    Friend WithEvents TextBox1 As Wisder.W3Common.WMetroControl.Controls.MetroTextBox
    Friend WithEvents TextBox4 As Wisder.W3Common.WMetroControl.Controls.MetroTextBox

    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents CriarPastaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeletarPastaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpellChecker As NetSpell.SpellChecker.Spelling
    Friend WithEvents WordDictionary As NetSpell.SpellChecker.Dictionary.WordDictionary
    Friend WithEvents TextBox7 As Wisder.W3Common.WMetroControl.Controls.MetroTextBox
    Friend WithEvents RibbonPanel11 As System.Windows.Forms.RibbonPanel
    Friend WithEvents TextBox8 As Wisder.W3Common.WMetroControl.Controls.MetroTextBox
    Friend WithEvents RibbonPanel12 As System.Windows.Forms.RibbonPanel

    Friend WithEvents RibbonComboBox1 As System.Windows.Forms.RibbonComboBox
    Friend WithEvents RibbonItemGroup1 As System.Windows.Forms.RibbonItemGroup
    Friend WithEvents Button1 As New Wisder.W3Common.WMetroControl.Controls.MetroButton
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button2 As New Wisder.W3Common.WMetroControl.Controls.MetroButton
    Friend WithEvents VerificarSubPastaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MetroToolTip1 As Wisder.W3Common.WMetroControl.Components.MetroToolTip
    Friend WithEvents MetroToolTip2 As Wisder.W3Common.WMetroControl.Components.MetroToolTip
    Friend WithEvents MetroStyleManager1 As Wisder.W3Common.WMetroControl.Components.MetroStyleManager
    Friend WithEvents ContextMenuStrip3 As Wisder.W3Common.WMetroControl.Controls.MetroContextMenu
    Private WithEvents btThemeSaveXML As Wisder.W3Common.WMetroControl.Controls.MetroButton
    Private WithEvents btThemeSaveIni As Wisder.W3Common.WMetroControl.Controls.MetroButton
    Private WithEvents btLoadFile As Wisder.W3Common.WMetroControl.Controls.MetroButton
    Private WithEvents btGenerateThemeClass As Wisder.W3Common.WMetroControl.Controls.MetroButton
    Friend WithEvents MetroButton1 As Wisder.W3Common.WMetroControl.Controls.MetroButton
    Friend WithEvents EmailReader1 As EmailReader.EmailReader
    Friend WithEvents MetroStyleExtender1 As Wisder.W3Common.WMetroControl.Components.MetroStyleExtender
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MetroComboBox1 As Wisder.W3Common.WMetroControl.Controls.MetroComboBox
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BackgroundWorker3 As System.ComponentModel.BackgroundWorker
    Public WithEvents ribbon1 As System.Windows.Forms.Ribbon
    Friend WithEvents RibbonComboBox2 As System.Windows.Forms.RibbonComboBox
    Friend WithEvents RibbonLabel1 As System.Windows.Forms.RibbonLabel
    Friend WithEvents RibbonLabel2 As System.Windows.Forms.RibbonLabel
    Friend WithEvents RibbonLabel3 As System.Windows.Forms.RibbonLabel
    Friend WithEvents RibbonSeparator2 As System.Windows.Forms.RibbonSeparator
    Friend WithEvents MetroGrid1 As Wisder.W3Common.WMetroControl.Controls.MetroGrid
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MetroButton2 As Wisder.W3Common.WMetroControl.Controls.MetroButton
    Friend WithEvents MetroProgressBar1 As Wisder.W3Common.WMetroControl.Controls.MetroProgressBar
    Friend WithEvents SaalvarTodoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MostrarTodosAnexosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BaixarEmaiNovamenteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents ArboScrollableListBox2 As ARBOControls.ARBOScrollableListBox
    Friend WithEvents ListControl1 As Exchange_Email_ToolsIT.ListControl
    Friend WithEvents NaviMain3 As Exchange_Email_ToolsIT.NaviMain


End Class
