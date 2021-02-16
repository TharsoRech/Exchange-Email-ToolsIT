Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports mshtml
Imports System.Diagnostics
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Web
Imports System.Threading
Imports System.Net.Mail
Imports System.Net.Mime

Public Class Editor
    Public doc As IHTMLDocument2
    Private updatingFontName As Boolean = False
    Private updatingFontSize As Boolean = False
    Private setup As Boolean = False
    Private init_timer As Boolean = False
    Public Event Tick As TickDelegate

    Public Event Navigated As WebBrowserNavigatedEventHandler

    Public Event EnterKeyEvent As EventHandler(Of EnterKeyEventArgs)
    Public Delegate Sub TickDelegate()

    Private Sub Editor_Load(sender As Object, e As EventArgs) Handles Me.Load
        '  SetupTimer()
        ' ' SetupBrowser()
        ' SetupFontComboBox()
        ' SetupFontSizeComboBox()
        ' timer.Start()
    End Sub
    Public Sub New()
      

        ' This call is required by the designer.
        InitializeComponent()
        SetupFontSizeComboBox()
        SetupTimer()
        SetupBrowser()
        SetupFontComboBox()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ParentForm_FormClosed(sender As Object, e As FormClosedEventArgs)
        timer.[Stop]()
        RemoveHandler ParentForm.FormClosed, New FormClosedEventHandler(AddressOf ParentForm_FormClosed)
    End Sub

    ''' <summary>
    ''' Setup navigation and focus event handlers.
    ''' </summary>


    Private Sub webBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles webBrowser1.DocumentCompleted
        webBrowser1.Document.Write(webBrowser1.DocumentText)
        doc.designMode = "On"
        webBrowser1.Document.Body.SetAttribute("contentEditable", "true")
    End Sub



    ''' <summary>
    ''' When this control receives focus, it transfers focus to the 
    ''' document body.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub webBrowser1_GotFocus(sender As Object, e As EventArgs) Handles webBrowser1.GotFocus
        SuperFocus()
    End Sub
  

    ''' <summary>
    ''' This is called when the initial html/body framework is set up, 
    ''' or when document.DocumentText is set.  At this point, the 
    ''' document is editable.
    ''' </summary>
    ''' <param name="sender">sender</param>
    ''' <param name="e">navigation args</param>
    Private Sub webBrowser1_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles webBrowser1.Navigated
        SetBackgroundColor(BackColor)
        RaiseEvent Navigated(Me, e)
    End Sub

    ''' <summary>
    ''' Setup timer with 200ms interval
    ''' </summary>
    Private Sub SetupTimer()
        timer.Interval = 200
        AddHandler timer.Tick, AddressOf timer_Tick
        '  timer.Tick += New EventHandler(AddressOf timer_Tick)
    End Sub


    ''' <summary>
    ''' Add document body, turn on design mode on the whole document, 
    ''' and overred the context menu
    ''' </summary>
    Private Sub SetupBrowser()
        webBrowser1.DocumentText = "<html><body></body></html>"
        doc = TryCast(webBrowser1.Document.DomDocument, IHTMLDocument2)
        doc.designMode = "On"
        AddHandler webBrowser1.Document.ContextMenuShowing, AddressOf Document_ContextMenuShowing
        ' webBrowser1.Document.ContextMenuShowing += New HtmlElementEventHandler(AddressOf Document_ContextMenuShowing)
    End Sub

    ''' <summary>
    ''' Set the focus on the document body.  
    ''' </summary>
    Private Sub SuperFocus()
        If webBrowser1.Document IsNot Nothing AndAlso webBrowser1.Document.Body IsNot Nothing Then
            webBrowser1.Document.Body.Focus()
        End If
    End Sub

    ''' <summary>
    ''' Get/Set the background color of the editor.
    ''' Note that if this is called before the document is rendered and 
    ''' complete, the navigated event handler will set the body's 
    ''' background color based on the state of BackColor.
    ''' </summary>
    <Browsable(True)> _
    Public Overrides Property BackColor() As Color
        Get
            Return MyBase.BackColor
        End Get
        Set(value As Color)
            MyBase.BackColor = value
            If ReadyState = ReadyState.Complete Then
                SetBackgroundColor(value)
            End If
        End Set
    End Property

    ''' <summary>
    ''' Set the background color of the body by setting it's CSS style
    ''' </summary>
    ''' <param name="value">the color to use for the background</param>
    Private Sub SetBackgroundColor(value As Color)
        If webBrowser1.Document IsNot Nothing AndAlso webBrowser1.Document.Body IsNot Nothing Then
            webBrowser1.Document.Body.Style = String.Format("background-color: {0}", value.Name)
        End If
    End Sub

    ''' <summary>
    ''' Clear the contents of the document, leaving the body intact.
    ''' </summary>
    Public Sub Clear()
        If webBrowser1.Document.Body IsNot Nothing Then
            webBrowser1.Document.Body.InnerHtml = ""
        End If
    End Sub

    ''' <summary>
    ''' Get the web browser component's document
    ''' </summary>
    Public ReadOnly Property Document() As System.Windows.Forms.HtmlDocument
        Get
            Return webBrowser1.Document
        End Get
    End Property

    ''' <summary>
    ''' Document text should be used to load/save the entire document, 
    ''' including html and body start/end tags.
    ''' </summary>
    <Browsable(False)> _
    Public Property DocumentText() As String
        Get
            Dim html As String = webBrowser1.DocumentText
            If html IsNot Nothing Then
                html = ReplaceFileSystemImages(html)
            End If
            Return html
        End Get
        Set(value As String)
            webBrowser1.DocumentText = value
        End Set
    End Property

    ''' <summary>
    ''' Get the html document title from document.
    ''' </summary>
    <Browsable(False)> _
    Public ReadOnly Property DocumentTitle() As String
        Get
            Return webBrowser1.DocumentTitle
        End Get
    End Property

    ''' <summary>
    ''' Get/Set the contents of the document Body, in html.
    ''' </summary>
    <Browsable(False)> _
    Public Property BodyHtml() As String
        Get
            If webBrowser1.Document IsNot Nothing AndAlso webBrowser1.Document.Body IsNot Nothing Then
                Dim html As String = webBrowser1.Document.Body.InnerHtml
                If html IsNot Nothing Then
                    html = ReplaceFileSystemImages(html)
                End If
                Return html
            Else
                Return String.Empty
            End If
        End Get
        Set(value As String)
            If webBrowser1.Document.Body IsNot Nothing Then
                webBrowser1.Document.Body.InnerHtml = value
            End If
        End Set
    End Property

    Public Function ToMailMessage() As MailMessage
        If webBrowser1.Document IsNot Nothing AndAlso webBrowser1.Document.Body IsNot Nothing Then
            Dim html As String = webBrowser1.Document.Body.InnerHtml
            If html IsNot Nothing Then
                Return LinkImages(html)
            End If
            Dim msg = New MailMessage()
            msg.IsBodyHtml = True
            Return msg
        Else
            Dim msg = New MailMessage()
            msg.IsBodyHtml = True
            msg.Body = String.Empty
            Return msg
        End If
    End Function

    Private Function LinkImages(html As String) As MailMessage
        Dim msg = New MailMessage()
        msg.IsBodyHtml = True
        Dim matches = Regex.Matches(html, "<img[^>]*?src\s*=\s*([""']?[^'"">]+?['""])[^>]*?>", RegexOptions.IgnoreCase Or RegexOptions.IgnorePatternWhitespace Or RegexOptions.Multiline)
        Dim img_list = New List(Of LinkedResource)()
        Dim cid = 1
        For Each match As Match In matches
            Dim src As String = match.Groups(1).Value
            src = src.Trim(""""c)
            If File.Exists(src) Then
                Dim ext = Path.GetExtension(src)
                If ext.Length > 0 Then
                    ext = ext.Substring(1)
                    Dim res = New LinkedResource(src)
                    res.ContentId = String.Format("img{0}.{1}", System.Math.Max(System.Threading.Interlocked.Increment(cid), cid - 1), ext)
                    res.TransferEncoding = System.Net.Mime.TransferEncoding.Base64
                    res.ContentType.MediaType = String.Format("image/{0}", ext)
                    res.ContentType.Name = res.ContentId
                    img_list.Add(res)
                    src = String.Format("'cid:{0}'", res.ContentId)
                    html = html.Replace(match.Groups(1).Value, src)
                End If
            End If
        Next
        Dim view = AlternateView.CreateAlternateViewFromString(html, Nothing, MediaTypeNames.Text.Html)
        For Each img As LinkedResource In img_list
            view.LinkedResources.Add(img)
        Next
        msg.AlternateViews.Add(view)
        Return msg
    End Function

    Public Function ReplaceFileSystemImages(html As String) As String
        Dim matches = Regex.Matches(html, "<img[^>]*?src\s*=\s*([""']?[^'"">]+?['""])[^>]*?>", RegexOptions.IgnoreCase Or RegexOptions.IgnorePatternWhitespace Or RegexOptions.Multiline)
        For Each match As Match In matches
            Dim src As String = match.Groups(1).Value
            src = src.Trim(""""c)
            If File.Exists(src) Then
                Dim ext = Path.GetExtension(src)
                If ext.Length > 0 Then
                    ext = ext.Substring(1)
                    src = String.Format("'data:image/{0};base64,{1}'", ext, Convert.ToBase64String(File.ReadAllBytes(src)))
                    html = html.Replace(match.Groups(1).Value, src)
                End If
            End If
        Next
        Return html
    End Function

    ''' <summary>
    ''' Get/Set the documents body as text.
    ''' </summary>
    <Browsable(False)> _
    Public Property BodyText() As String
        Get
            If webBrowser1.Document IsNot Nothing AndAlso webBrowser1.Document.Body IsNot Nothing Then
                Return webBrowser1.Document.Body.InnerText
            Else
                Return String.Empty
            End If
        End Get
        Set(value As String)
            Document.OpenNew(True)
            If webBrowser1.Document.Body IsNot Nothing Then
                webBrowser1.Document.Body.InnerText = HttpUtility.HtmlEncode(value)
            End If
        End Set
    End Property

    <Browsable(False)> _
    Public Property Html() As String
        Get
            If webBrowser1.Document IsNot Nothing AndAlso webBrowser1.Document.Body IsNot Nothing Then
                Return webBrowser1.Document.Body.InnerHtml
            Else
                Return String.Empty
            End If
        End Get
        Set(value As String)
            Document.OpenNew(True)
            Dim dom As IHTMLDocument2 = TryCast(Document.DomDocument, IHTMLDocument2)
            Try
                If value Is Nothing Then
                    dom.clear()
                Else
                    dom.write(value)
                End If
            Finally
                dom.close()
            End Try
        End Set
    End Property

    ''' <summary>
    ''' Determine the status of the Undo command in the document editor.
    ''' </summary>
    ''' <returns>whether or not an undo operation is currently valid</returns>
    Public Function CanUndo() As Boolean
        Return doc.queryCommandEnabled("Undo")
    End Function

    ''' <summary>
    ''' Determine the status of the Redo command in the document editor.
    ''' </summary>
    ''' <returns>whether or not a redo operation is currently valid</returns>
    Public Function CanRedo() As Boolean
        Return doc.queryCommandEnabled("Redo")
    End Function

    ''' <summary>
    ''' Determine the status of the Cut command in the document editor.
    ''' </summary>
    ''' <returns>whether or not a cut operation is currently valid</returns>
    Public Function CanCut() As Boolean
        Return doc.queryCommandEnabled("Cut")
    End Function

    ''' <summary>
    ''' Determine the status of the Copy command in the document editor.
    ''' </summary>
    ''' <returns>whether or not a copy operation is currently valid</returns>
    Public Function CanCopy() As Boolean
        Return doc.queryCommandEnabled("Copy")
    End Function

    ''' <summary>
    ''' Determine the status of the Paste command in the document editor.
    ''' </summary>
    ''' <returns>whether or not a copy operation is currently valid</returns>
    Public Function CanPaste() As Boolean
        Return doc.queryCommandEnabled("Paste")
    End Function

    ''' <summary>
    ''' Determine the status of the Delete command in the document editor.
    ''' </summary>
    ''' <returns>whether or not a copy operation is currently valid</returns>
    Public Function CanDelete() As Boolean
        Return doc.queryCommandEnabled("Delete")
    End Function

    ''' <summary>
    ''' Determine whether the current block is left justified.
    ''' </summary>
    ''' <returns>true if left justified, otherwise false</returns>
    Public Function IsJustifyLeft() As Boolean
        Return doc.queryCommandState("JustifyLeft")
    End Function

    ''' <summary>
    ''' Determine whether the current block is right justified.
    ''' </summary>
    ''' <returns>true if right justified, otherwise false</returns>
    Public Function IsJustifyRight() As Boolean
        Return doc.queryCommandState("JustifyRight")
    End Function

    ''' <summary>
    ''' Determine whether the current block is center justified.
    ''' </summary>
    ''' <returns>true if center justified, false otherwise</returns>
    Public Function IsJustifyCenter() As Boolean
        Return doc.queryCommandState("JustifyCenter")
    End Function

    ''' <summary>
    ''' Determine whether the current block is full justified.
    ''' </summary>
    ''' <returns>true if full justified, false otherwise</returns>
    Public Function IsJustifyFull() As Boolean
        Return doc.queryCommandState("JustifyFull")
    End Function

    ''' <summary>
    ''' Determine whether the current selection is in Bold mode.
    ''' </summary>
    ''' <returns>whether or not the current selection is Bold</returns>
    Public Function IsBold() As Boolean
        Return doc.queryCommandState("Bold")
    End Function

    ''' <summary>
    ''' Determine whether the current selection is in Italic mode.
    ''' </summary>
    ''' <returns>whether or not the current selection is Italicized</returns>
    Public Function IsItalic() As Boolean
        Return doc.queryCommandState("Italic")
    End Function

    ''' <summary>
    ''' Determine whether the current selection is in Underline mode.
    ''' </summary>
    ''' <returns>whether or not the current selection is Underlined</returns>
    Public Function IsUnderline() As Boolean
        Return doc.queryCommandState("Underline")
    End Function

    ''' <summary>
    ''' Determine whether the current paragraph is an ordered list.
    ''' </summary>
    ''' <returns>true if current paragraph is ordered, false otherwise</returns>
    Public Function IsOrderedList() As Boolean
        Return doc.queryCommandState("InsertOrderedList")
    End Function

    ''' <summary>
    ''' Determine whether the current paragraph is an unordered list.
    ''' </summary>
    ''' <returns>true if current paragraph is ordered, false otherwise</returns>
    Public Function IsUnorderedList() As Boolean
        Return doc.queryCommandState("InsertUnorderedList")
    End Function

    ''' <summary>
    ''' Called when the editor context menu should be displayed.
    ''' The return value of the event is set to false to disable the 
    ''' default context menu.  A custom context menu (contextMenuStrip1) is 
    ''' shown instead.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">HtmlElementEventArgs</param>
    Private Sub Document_ContextMenuShowing(sender As Object, e As HtmlElementEventArgs)
        e.ReturnValue = False
        cutToolStripMenuItem1.Enabled = CanCut()
        copyToolStripMenuItem2.Enabled = CanCopy()
        pasteToolStripMenuItem3.Enabled = CanPaste()
        deleteToolStripMenuItem.Enabled = CanDelete()
        cSSToolStripMenuItem.Enabled = SelectionType <> Exchange_Email_ToolsIT.SelectionType.None
        contextMenuStrip1.Show(Me, e.ClientMousePosition)
    End Sub

    ''' <summary>
    ''' Populate the font size combobox.
    ''' Add text changed and key press handlers to handle input and update 
    ''' the editor selection font size.
    ''' </summary>
    Private Sub SetupFontSizeComboBox()
        For x As Integer = 1 To 7
            fontSizeComboBox.Items.Add(x.ToString())
        Next
        AddHandler fontSizeComboBox.TextChanged, AddressOf fontComboBox_TextChanged
        '    fontSizeComboBox.TextChanged += New EventHandler(AddressOf fontSizeComboBox_TextChanged)
        AddHandler fontSizeComboBox.KeyPress, AddressOf fontSizeComboBox_KeyPress
        '   fontSizeComboBox.KeyPress += New KeyPressEventHandler(AddressOf fontSizeComboBox_KeyPress)
    End Sub

    ''' <summary>
    ''' Called when a key is pressed on the font size combo box.
    ''' The font size in the boxy box is set to the key press value.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">KeyPressEventArgs</param>
    Private Sub fontSizeComboBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        If [Char].IsNumber(e.KeyChar) Then
            e.Handled = True
            If e.KeyChar <= "7"c AndAlso e.KeyChar > "0"c Then
                fontSizeComboBox.Text = e.KeyChar.ToString()
            End If
        ElseIf Not [Char].IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Set editor's current selection to the value of the font size combo box.
    ''' Ignore if the timer is currently updating the font size to synchronize 
    ''' the font size combo box with the editor's current selection.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub fontSizeComboBox_TextChanged(sender As Object, e As EventArgs) Handles fontSizeComboBox.TextChanged
        If updatingFontSize Then
            Return
        End If
        Select Case fontSizeComboBox.Text.Trim()
            Case "1"
                FontSize = FontSize.One
                Exit Select
            Case "2"
                FontSize = FontSize.Two
                Exit Select
            Case "3"
                FontSize = FontSize.Three
                Exit Select
            Case "4"
                FontSize = FontSize.Four
                Exit Select
            Case "5"
                FontSize = FontSize.Five
                Exit Select
            Case "6"
                FontSize = FontSize.Six
                Exit Select
            Case "7"
                FontSize = FontSize.Seven
                Exit Select
            Case Else
                FontSize = FontSize.Seven
                Exit Select
        End Select
    End Sub

    ''' <summary>
    ''' Populate the font combo box and autocomplete handlers.
    ''' Add a text changed handler to the font combo box to handle new font selections.
    ''' </summary>
    Private Sub SetupFontComboBox()
        Dim ac As New AutoCompleteStringCollection()
        For Each fam As FontFamily In FontFamily.Families
            fontComboBox.Items.Add(fam.Name)
            ac.Add(fam.Name)
        Next
        AddHandler fontComboBox.Leave, AddressOf fontComboBox_TextChanged
        '   fontComboBox.Leave += New EventHandler(AddressOf fontComboBox_TextChanged)
        fontComboBox.AutoCompleteMode = AutoCompleteMode.Suggest
        fontComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource
        fontComboBox.AutoCompleteCustomSource = ac
    End Sub

    ''' <summary>
    ''' Called when the font combo box has changed.
    ''' Ignores the event when the timer is updating the font combo Box 
    ''' to synchronize the editor selection with the font combo box.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub fontComboBox_TextChanged(sender As Object, e As EventArgs) Handles fontComboBox.TextChanged
        If updatingFontName Then
            Return
        End If
        Dim ff As FontFamily
        Try
            ff = New FontFamily(fontComboBox.Text)
        Catch generatedExceptionName As Exception
            updatingFontName = True
            fontComboBox.Text = FontName.GetName(0)
            updatingFontName = False
            Return
        End Try
        FontName = ff
    End Sub

    Private Sub UpdateImageSizes()
        For Each image As HTMLImg In doc.images
            If image IsNot Nothing Then
                If image.height <> image.style.pixelHeight AndAlso image.style.pixelHeight <> 0 Then
                    image.height = image.style.pixelHeight
                End If
                If image.width <> image.style.pixelWidth AndAlso image.style.pixelWidth <> 0 Then
                    image.width = image.style.pixelWidth
                End If
            End If
        Next
    End Sub

    Public Event BoldChanged As MethodInvoker
    Public Event ItalicChanged As MethodInvoker
    Public Event UnderlineChanged As MethodInvoker
    Public Event OrderedListChanged As MethodInvoker
    Public Event UnorderedListChanged As MethodInvoker
    Public Event JustifyLeftChanged As MethodInvoker
    Public Event JustifyCenterChanged As MethodInvoker
    Public Event JustifyRightChanged As MethodInvoker
    Public Event JustifyFullChanged As MethodInvoker
    Public Event IsLinkChanged As MethodInvoker
    Public Event HtmlFontChanged As MethodInvoker
    Public Event HtmlFontSizeChanged As MethodInvoker

    Private lastSplash As DateTime = DateTime.Now

    ''' <summary>
    ''' Called when the timer fires to synchronize the format buttons 
    ''' with the text editor current selection.
    ''' SetupKeyListener if necessary.
    ''' Set bold, italic, underline and link buttons as based on editor state.
    ''' Synchronize the font combo box and the font size combo box.
    ''' Finally, fire the Tick event to allow external components to synchronize 
    ''' their state with the editor.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub timer_Tick(sender As Object, e As EventArgs)
        If Not init_timer Then
            AddHandler ParentForm.FormClosed, New FormClosedEventHandler(AddressOf ParentForm_FormClosed)
            init_timer = True
            lastSplash = DateTime.Now
        End If

        ' don't process until browser is in ready state.
        If ReadyState <> ReadyState.Complete Then
            Return
        End If


        SetupKeyListener()
        boldButton.Checked = IsBold()
        italicButton.Checked = IsItalic()
        underlineButton.Checked = IsUnderline()
        orderedListButton.Checked = IsOrderedList()
        unorderedListButton.Checked = IsUnorderedList()
        justifyLeftButton.Checked = IsJustifyLeft()
        justifyCenterButton.Checked = IsJustifyCenter()
        justifyRightButton.Checked = IsJustifyRight()
        justifyFullButton.Checked = IsJustifyFull()


        UpdateFontComboBox()
        UpdateFontSizeComboBox()
        UpdateImageSizes()
        RaiseEvent Tick()
    End Sub

    ''' <summary>
    ''' Update the font size combo box.
    ''' Sets a flag to indicate that the combo box is updating, and should 
    ''' not update the editor's selection.
    ''' </summary>
    Private Sub UpdateFontSizeComboBox()
        If Not fontSizeComboBox.Focused Then
            Dim foo As Integer
            Select Case FontSize
                Case FontSize.One
                    foo = 1
                    Exit Select
                Case FontSize.Two
                    foo = 2
                    Exit Select
                Case FontSize.Three
                    foo = 3
                    Exit Select
                Case FontSize.Four
                    foo = 4
                    Exit Select
                Case FontSize.Five
                    foo = 5
                    Exit Select
                Case FontSize.Six
                    foo = 6
                    Exit Select
                Case FontSize.Seven
                    foo = 7
                    Exit Select
                Case FontSize.NA
                    foo = 0
                    Exit Select
                Case Else
                    foo = 7
                    Exit Select
            End Select
            Dim fontsize__1 As String = Convert.ToString(foo)
            If fontsize__1 <> fontSizeComboBox.Text Then
                updatingFontSize = True
                fontSizeComboBox.Text = fontsize__1
                RaiseEvent HtmlFontSizeChanged()
                updatingFontSize = False
            End If
        End If
    End Sub

    ''' <summary>
    ''' Update the font combo box.
    ''' Sets a flag to indicate that the combo box is updating, and should 
    ''' not update the editor's selection.
    ''' </summary>
    Private Sub UpdateFontComboBox()
        If Not fontComboBox.Focused Then
            Dim fam As FontFamily = FontName
            If fam IsNot Nothing Then
                Dim fontname__1 As String = fam.Name
                If fontname__1 <> fontComboBox.Text Then
                    updatingFontName = True
                    fontComboBox.Text = fontname__1
                    RaiseEvent HtmlFontChanged()
                    updatingFontName = False
                End If
            End If
        End If
    End Sub

    Public Property BodyBackgroundColor() As Color
        Get
            If doc.body IsNot Nothing AndAlso doc.body.style IsNot Nothing AndAlso doc.body.style.backgroundColor IsNot Nothing Then
                Return ConvertToColor(doc.body.style.backgroundColor.ToString())
            End If
            Return Color.White
        End Get
        Set(value As Color)
            If ReadyState = ReadyState.Complete Then
                If doc.body IsNot Nothing AndAlso doc.body.style IsNot Nothing Then
                    Dim colorstr As String = String.Format("#{0:X2}{1:X2}{2:X2}", value.R, value.G, value.B)
                    doc.body.style.backgroundColor = colorstr
                End If
            End If
        End Set
    End Property

    ''' <summary>
    ''' Set up a key listener on the body once.
    ''' The key listener checks for specific key strokes and takes 
    ''' special action in certain cases.
    ''' </summary>
    Private Sub SetupKeyListener()
        If Not setup Then
            AddHandler webBrowser1.Document.Body.KeyDown, AddressOf Body_KeyDown
            setup = True
        End If
    End Sub
    Public Class EnterKeyEventArgs
        Inherits EventArgs
        Private _cancel As Boolean = False

        Public Property Cancel() As Boolean
            Get
                Return _cancel
            End Get
            Set(value As Boolean)
                _cancel = value
            End Set
        End Property

    End Class

    ''' <summary>
    ''' If the user hits the enter key, and event will fire (EnterKeyEvent), 
    ''' and the consumers of this event can cancel the projecessing of the 
    ''' enter key by cancelling the event.
    ''' This is useful if your application would like to take some action 
    ''' when the enter key is pressed, such as a submission to a web service.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">HtmlElementEventArgs</param>
    Private Sub Body_KeyDown(sender As Object, e As HtmlElementEventArgs)
        If e.KeyPressedCode = 13 AndAlso Not e.ShiftKeyPressed Then
            ' handle enter code cancellation
            Dim cancel As Boolean = False
            ' If EnterKeyEvent IsNot Nothing Then
            'Dim args As New EnterKeyEventArgs()
            '  RaiseEvent EnterKeyEvent(Me, args)
            '  cancel = args.Cancel
            '  End If
            e.ReturnValue = Not cancel
        End If
    End Sub

    ''' <summary>
    ''' Embed a break at the current selection.
    ''' This is a placeholder for future functionality.
    ''' </summary>
    Public Sub EmbedBr()
        Dim range As IHTMLTxtRange = TryCast(doc.selection.createRange(), IHTMLTxtRange)
        range.pasteHTML("<br/>")
        range.collapse(False)
        range.[select]()
    End Sub

    ''' <summary>
    ''' Paste the clipboard text into the current selection.
    ''' This is a placeholder for future functionality.
    ''' </summary>
    Private Sub SuperPaste()
        If Clipboard.ContainsText() Then
            Dim range As IHTMLTxtRange = TryCast(doc.selection.createRange(), IHTMLTxtRange)
            range.pasteHTML(Clipboard.GetText(TextDataFormat.Text))
            range.collapse(False)
            range.[select]()
        End If
    End Sub

    ''' <summary>
    ''' Print the current document
    ''' </summary>
    Public Sub Print()
        webBrowser1.Document.ExecCommand("Print", True, Nothing)
    End Sub

    ''' <summary>
    ''' Insert a paragraph break
    ''' </summary>
    Public Sub InsertParagraph()
        webBrowser1.Document.ExecCommand("InsertParagraph", False, Nothing)
    End Sub

    ''' <summary>
    ''' Insert a horizontal rule
    ''' </summary>
    Public Sub InsertBreak()
        webBrowser1.Document.ExecCommand("InsertHorizontalRule", False, Nothing)
    End Sub

    ''' <summary>
    ''' Select all text in the document.
    ''' </summary>
    Public Sub SelectAll()
        webBrowser1.Document.ExecCommand("SelectAll", False, Nothing)
    End Sub

    ''' <summary>
    ''' Undo the last operation
    ''' </summary>
    Public Sub Undo()
        webBrowser1.Document.ExecCommand("Undo", False, Nothing)
    End Sub

    ''' <summary>
    ''' Redo based on the last Undo
    ''' </summary>
    Public Sub Redo()
        webBrowser1.Document.ExecCommand("Redo", False, Nothing)
    End Sub

    ''' <summary>
    ''' Cut the current selection and place it in the clipboard.
    ''' </summary>
    Public Sub Cut()
        webBrowser1.Document.ExecCommand("Cut", False, Nothing)
    End Sub

    ''' <summary>
    ''' Paste the contents of the clipboard into the current selection.
    ''' </summary>
    Public Sub Paste()
        webBrowser1.Document.ExecCommand("Paste", False, Nothing)
    End Sub

    ''' <summary>
    ''' Copy the current selection into the clipboard.
    ''' </summary>
    Public Sub Copy()
        webBrowser1.Document.ExecCommand("Copy", False, Nothing)
    End Sub

    ''' <summary>
    ''' Toggle the ordered list property for the current paragraph.
    ''' </summary>
    Public Sub OrderedList()
        webBrowser1.Document.ExecCommand("InsertOrderedList", False, Nothing)
    End Sub

    ''' <summary>
    ''' Toggle the unordered list property for the current paragraph.
    ''' </summary>
    Public Sub UnorderedList()
        webBrowser1.Document.ExecCommand("InsertUnorderedList", False, Nothing)
    End Sub

    ''' <summary>
    ''' Toggle the left justify property for the currnet block.
    ''' </summary>
    Public Sub JustifyLeft()
        webBrowser1.Document.ExecCommand("JustifyLeft", False, Nothing)
    End Sub

    ''' <summary>
    ''' Toggle the right justify property for the current block.
    ''' </summary>
    Public Sub JustifyRight()
        webBrowser1.Document.ExecCommand("JustifyRight", False, Nothing)
    End Sub

    ''' <summary>
    ''' Toggle the center justify property for the current block.
    ''' </summary>
    Public Sub JustifyCenter()
        webBrowser1.Document.ExecCommand("JustifyCenter", False, Nothing)
    End Sub

    ''' <summary>
    ''' Toggle the full justify property for the current block.
    ''' </summary>
    Public Sub JustifyFull()
        webBrowser1.Document.ExecCommand("JustifyFull", False, Nothing)
    End Sub

    ''' <summary>
    ''' Toggle bold formatting on the current selection.
    ''' </summary>
    Public Sub Bold()
        webBrowser1.Document.ExecCommand("Bold", False, Nothing)
    End Sub

    ''' <summary>
    ''' Toggle italic formatting on the current selection.
    ''' </summary>
    Public Sub Italic()
        webBrowser1.Document.ExecCommand("Italic", False, Nothing)
    End Sub

    ''' <summary>
    ''' Toggle underline formatting on the current selection.
    ''' </summary>
    Public Sub Underline()
        webBrowser1.Document.ExecCommand("Underline", False, Nothing)
    End Sub

    ''' <summary>
    ''' Delete the current selection.
    ''' </summary>
    Public Sub Delete()
        webBrowser1.Document.ExecCommand("Delete", False, Nothing)
    End Sub

    ''' <summary>
    ''' Insert an imange.
    ''' </summary>
    Public Sub InsertImage()
        webBrowser1.Document.ExecCommand("InsertImage", True, Nothing)
    End Sub

    ''' <summary>
    ''' Indent the current paragraph.
    ''' </summary>
    Public Sub Indent()
        webBrowser1.Document.ExecCommand("Indent", False, Nothing)
    End Sub

    ''' <summary>
    ''' Outdent the current paragraph.
    ''' </summary>
    Public Sub Outdent()
        webBrowser1.Document.ExecCommand("Outdent", False, Nothing)
    End Sub

    ''' <summary>
    ''' Insert a link at the current selection.
    ''' </summary>
    ''' <param name="url">The link url</param>
    Public Sub InsertLink(url As String)
        webBrowser1.Document.ExecCommand("CreateLink", False, url)
    End Sub

    ''' <summary>
    ''' Get the ready state of the internal browser component.
    ''' </summary>
    Public ReadOnly Property ReadyState() As ReadyState
        Get
            Select Case doc.readyState.ToLower()
                Case "uninitialized"
                    Return ReadyState.Uninitialized
                Case "loading"
                    Return ReadyState.Loading
                Case "loaded"
                    Return ReadyState.Loaded
                Case "interactive"
                    Return ReadyState.Interactive
                Case "complete"
                    Return ReadyState.Complete
                Case Else
                    Return ReadyState.Uninitialized
            End Select
        End Get
    End Property

    ''' <summary>
    ''' Get the current selection type.
    ''' </summary>
    Public ReadOnly Property SelectionType() As SelectionType
        Get
            Dim type = doc.selection.type.ToLower()
            Select Case type
                Case "text"
                    Return SelectionType.Text
                Case "control"
                    Return SelectionType.Control
                Case "none"
                    Return SelectionType.None
                Case Else
                    Return SelectionType.None
            End Select
        End Get
    End Property

    ''' <summary>
    ''' Get/Set the current font size.
    ''' </summary>
    <Browsable(True)> _
    Public Property FontSize() As FontSize
        Get
            If ReadyState <> ReadyState.Complete Then
                Return FontSize.NA
            End If
            Select Case doc.queryCommandValue("FontSize").ToString()
                Case "1"
                    Return FontSize.One
                Case "2"
                    Return FontSize.Two
                Case "3"
                    Return FontSize.Three
                Case "4"
                    Return FontSize.Four
                Case "5"
                    Return FontSize.Five
                Case "6"
                    Return FontSize.Six
                Case "7"
                    Return FontSize.Seven
                Case Else
                    Return FontSize.NA
            End Select
        End Get
        Set(value As FontSize)
            Dim sz As Integer
            Select Case value
                Case FontSize.One
                    sz = 1
                    Exit Select
                Case FontSize.Two
                    sz = 2
                    Exit Select
                Case FontSize.Three
                    sz = 3
                    Exit Select
                Case FontSize.Four
                    sz = 4
                    Exit Select
                Case FontSize.Five
                    sz = 5
                    Exit Select
                Case FontSize.Six
                    sz = 6
                    Exit Select
                Case FontSize.Seven
                    sz = 7
                    Exit Select
                Case Else
                    sz = 7
                    Exit Select
            End Select
            webBrowser1.Document.ExecCommand("FontSize", False, sz.ToString())
        End Set
    End Property

    ''' <summary>
    ''' Get/Set the current font name.
    ''' </summary>
    <Browsable(False)> _
    Public Property FontName() As FontFamily
        Get
            If ReadyState <> ReadyState.Complete Then
                Return Nothing
            End If
            Dim name As String = TryCast(doc.queryCommandValue("FontName"), String)
            If name Is Nothing Then
                Return Nothing
            End If
            Return New FontFamily(name)
        End Get
        Set(value As FontFamily)
            If value IsNot Nothing Then
                webBrowser1.Document.ExecCommand("FontName", False, value.Name)
            End If
        End Set
    End Property

    ''' <summary>
    ''' Get/Set the editor's foreground (text) color for the current selection.
    ''' </summary>
    <Browsable(False)> _
    Public Property EditorForeColor() As Color
        Get
            If ReadyState <> ReadyState.Complete Then
                Return Color.Black
            End If
            Return ConvertToColor(doc.queryCommandValue("ForeColor").ToString())
        End Get
        Set(value As Color)
            Dim colorstr As String = String.Format("#{0:X2}{1:X2}{2:X2}", value.R, value.G, value.B)
            webBrowser1.Document.ExecCommand("ForeColor", False, colorstr)
        End Set
    End Property

    ''' <summary>
    ''' Get/Set the editor's background color for the current selection.
    ''' </summary>
    <Browsable(False)> _
    Public Property EditorBackColor() As Color
        Get
            If ReadyState <> ReadyState.Complete Then
                Return Color.White
            End If
            Return ConvertToColor(doc.queryCommandValue("BackColor").ToString())
        End Get
        Set(value As Color)
            Dim colorstr As String = String.Format("#{0:X2}{1:X2}{2:X2}", value.R, value.G, value.B)
            webBrowser1.Document.ExecCommand("BackColor", False, colorstr)
        End Set
    End Property

    Public Sub SelectBodyColor()
        Dim color As Color = BodyBackgroundColor
        If ShowColorDialog(False) Then
            BodyBackgroundColor = color
        End If
    End Sub

    ''' <summary>
    ''' Initiate the foreground (text) color dialog for the current selection.
    ''' </summary>
    Public Sub SelectForeColor()
        Try
            Dim color As Color = EditorForeColor
            If ShowColorDialog(True) Then
                EditorForeColor = color
            End If
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Initiate the background color dialog for the current selection.
    ''' </summary>
    Public Sub SelectBackColor()
        ShowColorDialog(False)
    End Sub

    ''' <summary>
    ''' Convert the custom integer (B G R) format to a color object.
    ''' </summary>
    ''' <param name="clrs">the custorm color as a string</param>
    ''' <returns>the color</returns>
    Private Shared Function ConvertToColor(clrs As String) As Color
        Try
            Dim red As Integer, green As Integer, blue As Integer
            ' sometimes clrs is HEX organized as (RED)(GREEN)(BLUE)
            If clrs.StartsWith("#") Then
                Dim clrn As Integer = Convert.ToInt32(clrs.Substring(1), 16)
                red = (clrn >> 16) And 255
                green = (clrn >> 8) And 255
                blue = clrn And 255
            Else
                ' otherwise clrs is DECIMAL organized as (BlUE)(GREEN)(RED)
                Dim clrn As Integer = Convert.ToInt32(clrs)
                red = clrn And 255
                green = (clrn >> 8) And 255
                blue = (clrn >> 16) And 255
            End If
            Dim incolor As Color = Color.FromArgb(red, green, blue)
            Return incolor
        Catch ex As Exception
        End Try
    End Function

    ''' <summary>
    ''' Called when the cut tool strip button on the editor context menu 
    ''' is clicked.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub cutToolStripButton_Click(sender As Object, e As EventArgs)
        Cut()
    End Sub

    ''' <summary>
    ''' Called when the paste tool strip button on the editor context menu 
    ''' is clicked.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub pasteToolStripButton_Click(sender As Object, e As EventArgs)
        Paste()
    End Sub

    ''' <summary>
    ''' Called when the copy tool strip button on the editor context menu 
    ''' is clicked.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub copyToolStripButton_Click(sender As Object, e As EventArgs)
        Copy()
    End Sub

    ''' <summary>
    ''' Called when the bold button on the tool strip is pressed.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub boldButton_Click(sender As Object, e As EventArgs)
        Bold()
    End Sub

    ''' <summary>
    ''' Called when the italic button on the tool strip is pressed.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub italicButton_Click(sender As Object, e As EventArgs)
        Italic()
    End Sub

    ''' <summary>
    ''' Called when the underline button on the tool strip is pressed.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub underlineButton_Click(sender As Object, e As EventArgs)
        Underline()
    End Sub

    ''' <summary>
    ''' Called when the foreground color button on the tool strip is pressed.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub colorButton_Click(sender As Object, e As EventArgs)
        SelectForeColor()
    End Sub

    ''' <summary>
    ''' Called when the background color button on the tool strip is pressed.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub backColorButton_Click(sender As Object, e As EventArgs)
        SelectBackColor()
    End Sub

    ''' <summary>
    ''' Show the interactive Color dialog.
    ''' </summary>
    ''' <param name="color">the input and output color</param>
    ''' <returns>true if dialog accepted, false if dialog cancelled</returns>
    Private Function ShowColorDialog(ByVal forecolor As Boolean) As Boolean
        Try
            Dim selected As Boolean = False
            Using dlg As New ColorDialog()
                dlg.SolidColorOnly = True
                dlg.AllowFullOpen = False
                dlg.AnyColor = False
                dlg.FullOpen = False
                dlg.CustomColors = Nothing
                If dlg.ShowDialog(Me) = DialogResult.OK Then
                    selected = True
                    If forecolor = True Then
                        EditorForeColor = dlg.Color
                    Else
                        EditorBackColor = dlg.Color
                    End If
                Else
                    Return selected
                End If
            End Using
            Return selected
        Catch ex As Exception
        End Try
    End Function

    ''' <summary>
    ''' Called when the link button on the toolstrip is pressed.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub linkButton_Click(sender As Object, e As EventArgs)
        SelectLink()
    End Sub

    ''' <summary>
    ''' Determine if text is selected and only one or no link is selected.
    ''' </summary>
    ''' <returns>Boolean</returns>
    Public Function CanInsertLink() As Boolean
        'return (SelectionType == SelectionType.Text && !LinksInSelection());
        Return (Not LinksInSelection())
    End Function

    ''' <summary>
    ''' Determine wheter the currently selected text contains two or more links.
    ''' </summary>
    ''' <returns>true if two links or more links are currently selected, false otherwise</returns>
    Private Function LinksInSelection() As Boolean
        Try
            If SelectionType <> Exchange_Email_ToolsIT.SelectionType.Text Then
                Return False
            End If
            Dim twoOrMoreLinksInSelection As Boolean = False
            Dim txtRange As IHTMLTxtRange = DirectCast(doc.selection.createRange(), IHTMLTxtRange)

            If txtRange IsNot Nothing AndAlso Not String.IsNullOrEmpty(txtRange.htmlText) Then
                Dim regex As New Regex("<a href=""[^""]+"">[^<]+</a>", RegexOptions.IgnoreCase Or RegexOptions.CultureInvariant)
                Dim matchCollection As MatchCollection = regex.Matches(txtRange.htmlText)

                ' true if more than one link is selected
                twoOrMoreLinksInSelection = (matchCollection.Count > 1)
            End If
            If twoOrMoreLinksInSelection Then
                Dim type As String = doc.selection.type
            End If
            Return twoOrMoreLinksInSelection
        Catch ex As Exception
        End Try
    End Function

    ''' <summary>
    ''' Show a custom insert link dialog, and create the link.
    ''' </summary>
    Public Sub SelectLink()
        Try
            Dim url As String = String.Empty
            Select Case SelectionType
                Case Exchange_Email_ToolsIT.SelectionType.Control
                    If True Then
                        Dim range As IHTMLControlRange = TryCast(doc.selection.createRange(), IHTMLControlRange)
                        If range IsNot Nothing AndAlso range.length > 0 Then
                            Dim elem = range.item(0)
                            If elem IsNot Nothing AndAlso String.Compare(elem.tagName, "img", True) = 0 Then
                                elem = elem.parentElement
                                If elem IsNot Nothing AndAlso String.Compare(elem.tagName, "a", True) = 0 Then
                                    url = TryCast(elem.getAttribute("href"), String)
                                End If
                            End If
                        End If
                    End If
                    Exit Select
                Case Exchange_Email_ToolsIT.SelectionType.Text
                    If True Then
                        Dim txtRange As IHTMLTxtRange = DirectCast(doc.selection.createRange(), IHTMLTxtRange)
                        If txtRange IsNot Nothing AndAlso Not String.IsNullOrEmpty(txtRange.htmlText) Then
                            Dim regex As New Regex("^\s*<a href=""([^""]+)"">[^<]+</a>\s*$", RegexOptions.IgnoreCase Or RegexOptions.CultureInvariant)
                            Dim match As Match = regex.Match(txtRange.htmlText)

                            If match.Success Then
                                url = match.Groups(1).Value
                            End If
                        End If
                    End If
                    Exit Select
            End Select
            Using dlg As New LinkDialog()
                Dim uri__1 As Uri
                If Uri.TryCreate(url, UriKind.Absolute, uri__1) Then
                    dlg.URL = String.Format("{0}{1}", uri__1.Host, If(uri__1.PathAndQuery Is Nothing, Nothing, uri__1.PathAndQuery.TrimEnd("/"c)))
                    dlg.Scheme = String.Format("{0}://", uri__1.Scheme)
                End If
                dlg.ShowDialog(Me.ParentForm)
                If Not dlg.Accepted Then
                    Return
                End If
                Dim link As String = String.Format("{0}{1}", dlg.Scheme, dlg.URL)
                If link Is Nothing OrElse link.Length = 0 Then
                    MessageBox.Show(Me.ParentForm, "Invalid URL")
                    Return
                End If
                InsertLink(link)
            End Using
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Called when the image button on the toolstrip is clicked.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub imageButton_Click(sender As Object, e As EventArgs) Handles imageButton.Click
        InsertImage()
    End Sub

    ''' <summary>
    ''' Called when the outdent button on the toolstrip is clicked.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub outdentButton_Click(sender As Object, e As EventArgs)
        Outdent()
    End Sub

    ''' <summary>
    ''' Called when the indent button on the toolstrip is clicked.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub indentButton_Click(sender As Object, e As EventArgs) Handles indentButton.Click
        Indent()
    End Sub

    ''' <summary>
    ''' Called when the cut button is clicked on the editor context menu.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub cutToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Cut()
    End Sub

    ''' <summary>
    ''' Called when the copy button is clicked on the editor context menu.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub copyToolStripMenuItem2_Click(sender As Object, e As EventArgs)
        Copy()
    End Sub

    ''' <summary>
    ''' Called when the paste button is clicked on the editor context menu.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub pasteToolStripMenuItem3_Click(sender As Object, e As EventArgs)
        Paste()
    End Sub

    ''' <summary>
    ''' Called when the delete button is clicked on the editor context menu.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub deleteToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Delete()
    End Sub

    ''' <summary>
    ''' Search the document from the current selection, and reset the 
    ''' the selection to the text found, if successful.
    ''' </summary>
    ''' <param name="text">the text for which to search</param>
    ''' <param name="forward">true for forward search, false for backward</param>
    ''' <param name="matchWholeWord">true to match whole word, false otherwise</param>
    ''' <param name="matchCase">true to match case, false otherwise</param>
    ''' <returns></returns>
    Public Function Search(text As String, forward As Boolean, matchWholeWord As Boolean, matchCase As Boolean) As Boolean
        Try
            Dim success As Boolean = False
            If webBrowser1.Document IsNot Nothing Then
                Dim doc As IHTMLDocument2 = TryCast(webBrowser1.Document.DomDocument, IHTMLDocument2)
                Dim body As IHTMLBodyElement = TryCast(doc.body, IHTMLBodyElement)

                If body IsNot Nothing Then
                    Dim range As IHTMLTxtRange
                    If doc.selection IsNot Nothing Then
                        range = TryCast(doc.selection.createRange(), IHTMLTxtRange)
                        Dim dup As IHTMLTxtRange = range.duplicate()
                        dup.collapse(True)
                        ' if selection is degenerate, then search whole body
                        If range.isEqual(dup) Then
                            range = body.createTextRange()
                        Else
                            If forward Then
                                range.moveStart("character", 1)
                            Else
                                range.moveEnd("character", -1)
                            End If
                        End If
                    Else
                        range = body.createTextRange()
                    End If
                    Dim flags As Integer = 0
                    If matchWholeWord Then
                        flags += 2
                    End If
                    If matchCase Then
                        flags += 4
                    End If
                    success = range.findText(text, If(forward, 999999, -999999), flags)
                    If success Then
                        range.[select]()
                        range.scrollIntoView(Not forward)
                    End If
                End If
            End If
            Return success
        Catch ex As Exception
        End Try
    End Function

    ''' <summary>
    ''' Event handler for the ordered list toolbar button
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub orderedListButton_Click(sender As Object, e As EventArgs) Handles orderedListButton.CheckStateChanged
        OrderedList()
    End Sub

    ''' <summary>
    ''' Event handler for the unordered list toolbar button
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub unorderedListButton_Click(sender As Object, e As EventArgs) Handles unorderedListButton.Click
        UnorderedList()
    End Sub

    ''' <summary>
    ''' Event handler for the left justify toolbar button.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub justifyLeftButton_Click(sender As Object, e As EventArgs) Handles justifyLeftButton.Click
        JustifyLeft()
    End Sub

    ''' <summary>
    ''' Event handler for the center justify toolbar button.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub justifyCenterButton_Click(sender As Object, e As EventArgs) Handles justifyCenterButton.Click
        JustifyCenter()
    End Sub

    ''' <summary>
    ''' Event handler for the right justify toolbar button.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub justifyRightButton_Click(sender As Object, e As EventArgs) Handles justifyRightButton.Click
        JustifyRight()
    End Sub

    ''' <summary>
    ''' Event handler for the full justify toolbar button.
    ''' </summary>
    ''' <param name="sender">the sender</param>
    ''' <param name="e">EventArgs</param>
    Private Sub justifyFullButton_Click(sender As Object, e As EventArgs) Handles justifyFullButton.Click
        JustifyFull()
    End Sub

    Private Sub backgroundColorToolStripMenuItem_Click(sender As Object, e As EventArgs)
        SelectBodyColor()
    End Sub



   

   
  
   
   
    Private Sub colorButton_Click_1(sender As Object, e As EventArgs) Handles colorButton.Click
        ShowColorDialog(True)
        webBrowser1.Document.ForeColor = EditorForeColor
    End Sub

    Private Sub backColorButton_Click_1(sender As Object, e As EventArgs) Handles backColorButton.Click
        ShowColorDialog(False)
        webBrowser1.Document.BackColor = EditorBackColor
    End Sub

    Private Sub linkButton_Click_1(sender As Object, e As EventArgs)
        LinkDialog.Show()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Try
            Undo()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Try
            Redo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub boldButton_Click_1(sender As Object, e As EventArgs) Handles boldButton.Click
        doc.execCommand("Bold", False, Nothing)
    End Sub

    Private Sub italicButton_Click_1(sender As Object, e As EventArgs) Handles italicButton.Click
        doc.execCommand("Italic", False, Nothing)
    End Sub

    Private Sub underlineButton_Click_1(sender As Object, e As EventArgs) Handles underlineButton.Click
        doc.execCommand("Underline", False, Nothing)
    End Sub

    
    Private Sub pasteToolStripMenuItem3_Click_1(sender As Object, e As EventArgs) Handles pasteToolStripMenuItem3.Click
        doc.execCommand("Paste", False, Nothing)
    End Sub

    Private Sub copyToolStripMenuItem2_Click_1(sender As Object, e As EventArgs) Handles copyToolStripMenuItem2.Click
        doc.execCommand("Copy", False, Nothing)
    End Sub

    Private Sub deleteToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles deleteToolStripMenuItem.Click
        Document.ExecCommand("Delete", False, Nothing)
    End Sub

    Private Sub cutToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles cutToolStripMenuItem1.Click
        doc.execCommand("Cut", False, Nothing)
    End Sub
End Class

''' <summary>
''' Enumeration of possible font sizes for the Editor component
''' </summary>
Public Enum FontSize
    One
    Two
    Three
    Four
    Five
    Six
    Seven
    NA
End Enum

Public Enum SelectionType
    Text
    Control
    None
End Enum

Public Enum ReadyState
    Uninitialized
    Loading
    Loaded
    Interactive
    Complete
End Enum
