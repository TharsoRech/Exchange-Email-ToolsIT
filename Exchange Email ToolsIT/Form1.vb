Imports System
Imports System.Net
Imports System.DirectoryServices
Imports AutocompleteMenuNS
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports Guifreaks.NavigationBar
Imports System.Windows.Forms.Ribbon
Imports Microsoft.Exchange.WebServices.Data
Imports NetSpell.SpellChecker
Imports System.IO.File
Imports System.Reflection
Imports Abhinaba.TransDlg
Imports System.IO
Imports Wisder.W3Common
Imports MetroFramework
Imports System.Runtime.InteropServices
Imports PSTParse
Imports PSTParse.Message_Layer
Imports System.Xml.Serialization
Imports System.Text.RegularExpressions
Imports MetroFramework.Drawing.Html
Imports TheArtOfDev.HtmlRenderer
Imports System.Drawing.Imaging
Imports mshtml
Imports System.Text
Imports System.Xml
Imports OfficeList



Public Class Form1

    Dim user As String = ""
    Dim pass As String = ""
    Dim server As String = ""
    Dim domainName As String = Environment.UserDomainName
    Dim mailbox As String = ""
    Dim itemmail As String = ""
    Dim anexo As String = ""
    Dim mailbox2 As String = ""
    Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
    Dim selectfolder As String = ""
    Dim htmlbody As String = ""
    Dim indexitem As Integer = 0
    Public listofcontrols As List(Of Control) = New List(Of Control)
    Public listofcontrols2 As List(Of Control) = New List(Of Control)
    Dim stopsearch As Boolean = False
    Private Delegate Function selectnodetext() As String
    Private Delegate Sub SendTextDelegate(ByVal from1 As String, ByVal Subject As String, ByVal displayto As String, ByVal datatime As String, ByVal idmessage As String, ByVal isread As Boolean, ByVal atthas As Boolean)
    Dim listofidmessage As List(Of String)
    Dim countsearch As Integer = 0
    Dim controlstodo As List(Of String) = New List(Of String)

    Dim pstfile As PSTFile
    Public arquivomorto As Boolean = False
    Const maxSize As Integer = 1 * 1024 * 1000
    Dim lisfolders As List(Of String) = New List(Of String)
    Dim foldernow As String = ""
    Dim emailnow As String = ""
    Dim foldercountnow As Integer = 0
    Dim emailsprogressnow As Integer = 0
    Dim doemails As String = ""
    Public nodetext As String = ""
    Dim foldercount As Integer = 0
    Dim lastindexfile As Integer = 0
    Dim moreemails As List(Of String) = New List(Of String)
    Public itemcount As Integer = 0
    Public itemcount2 As Integer = 0
    Dim listthread As Threading.Thread
    Dim checktrhead As Threading.Thread
    Public account As User
    Private Const XmlNodeTag As String = "node"

    Private Const XmlNodeTextAtt As String = "text"
    Private Const XmlNodeTagAtt As String = "tag"
    Private Const XmlNodeImageIndexAtt As String = "imageindex"


    Protected Overrides Sub OnClosed(e As EventArgs)
        BackgroundWorker1.CancelAsync()
        BackgroundWorker2.CancelAsync()
        BackgroundWorker3.CancelAsync()

        MyBase.OnClosed(e)


    End Sub




    Public Function allreadyxists(ByVal id As String) As Boolean
        Dim alreadyhave As Boolean = False
        Try
            For Each c1 As ListControlItem In listofcontrols2
                TimeDelay()
                If c1.idmessage.ToLower.Contains(id) Then
                    alreadyhave = True
                    Exit For
                End If
            Next
            Return alreadyhave
        Catch ex As Exception
            Return alreadyhave
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try


    End Function
    Public Function allreadyxists(ByVal id As String, ByVal list1 As List(Of Control)) As Boolean
        Dim alreadyhave As Boolean = False
        Try
            For Each c1 As ListControlItem In list1
                ' TimeDelay()
                If c1.idmessage.ToLower = id.Trim.ToLower Then
                    alreadyhave = True
                    Return alreadyhave
                    Exit Function
                End If
            Next
            Return alreadyhave
        Catch ex As Exception
            Return alreadyhave
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try


    End Function

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    End Sub




    Private Sub Form1_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Try

            For Each Control As Control In Me.Controls
                If Control.GetType() Is GetType(StatusStrip) Or Control.GetType() Is GetType(EmailReader.EmailReader) Then

                Else
                    Control.Dock = DockStyle.Fill
                    Control.Anchor = AnchorStyles.Top + AnchorStyles.Bottom + AnchorStyles.Left + AnchorStyles.Right
                End If


            Next
            Me.Size = Screen.PrimaryScreen.WorkingArea.Size
            NaviMain3.Height = Me.Height - StatusStrip1.Height - ribbon1.Height - 70
            ArboScrollableListBox2.Height = Me.Height - StatusStrip1.Height - ribbon1.Height - RichTextBox3.Height - Label8.Height - MetroProgressBar1.Height - 75
            EmailReader1.Height = NaviMain3.Height
            EmailReader1.Dock = DockStyle.Right
            EmailReader1.Anchor = AnchorStyles.Top + AnchorStyles.Bottom + AnchorStyles.Left + AnchorStyles.Right
            EmailReader1.WebBrowser1.Anchor = AnchorStyles.Top + AnchorStyles.Bottom + AnchorStyles.Left + AnchorStyles.Right
            EmailReader1.WebBrowser1.Height = EmailReader1.Height - EmailReader1.PictureBox1.Height - EmailReader1.DisplayTo.Height - 70
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub
    Public Function GetAll(control As Control) As IEnumerable(Of Control)
        Dim controls = control.Controls.Cast(Of Control)()

        Return controls.SelectMany(Function(ctrl) GetAll(ctrl)).Concat(controls).Where(Function(c) c.[GetType].FullName.ToLower.Contains("Wisder".ToLower))
    End Function


    Public Function GetAll(control As Control, type As Type) As IEnumerable(Of Control)
        Dim controls = control.Controls.Cast(Of Control)()

        Return controls.SelectMany(Function(ctrl) GetAll(ctrl, type)).Concat(controls).Where(Function(c) c.[GetType].Module.FullyQualifiedName.ToLower.Contains("Wisder".ToLower))
    End Function
    Public Shared Function HasProperty(obj As Object, propertyName As String) As Boolean
        Try
            Return obj.[GetType]().GetProperty(propertyName) IsNot Nothing

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Function
    Public Sub changevalue(ByVal obj As Object, propertyname As String, ByVal newvalue As Object)
        Try
            obj.[GetType]().GetProperty(propertyname).SetValue(obj, newvalue, Nothing)
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub
    Public Shared Function Getvalue(obj As Object, propertyName As String) As String
        Try
            Return obj.[GetType]().GetProperty(propertyName).GetValue(obj, Nothing).ToString

        Catch ex As Exception
            Return ""
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Function


    Public Sub start()
        Try

            user = TextBox1.Text
            pass = TextBox2.Text
            server = TextBox3.Text
            ' Me.Update()
            Me.Refresh()
            Me.Update()



            If account IsNot Nothing Then

                If IO.File.Exists(account.user & "Folders" & ".FL") Then
                    Dim seri1 As New ObjectSerializer(Of AssetBrowserControl.SerializableTreeView)
                    Dim newTn As TreeNode
                    For Each tn As TreeNode In seri1.GetSerializedObject(account.user & "Folders" & ".FL").Nodes
                        newTn = New TreeNode(tn.Text)
                        CopyChilds(newTn, tn)
                        NaviMain3.treeView1.Nodes.Add(newTn)
                        If account.folders.Count = 0 Then
                            Dim newflist As New FolderList
                            account.folders.Add(newflist)
                            save()
                            If account.folders(0).items.Count > 0 Then
                                For Each f1 As FolderEmail In account.folders(0).items
                                    ' MsgBox(f1.name)
                                    If findfolderaccount(f1.name) = False Then
                                        Dim newf1 As New FolderEmail
                                        newf1.name = newTn.Text
                                        account.folders(0).items.Add(newf1)

                                    End If
                                Next
                            Else
                                Dim newf1 As New FolderEmail
                                newf1.name = newTn.Text
                                account.folders(0).items.Add(newf1)
                            End If

                        Else
                            If findfolderaccount(tn.Text) = False Then
                                Dim newf1 As New FolderEmail
                                newf1.name = tn.Text
                                account.folders(0).items.Add(newf1)

                            End If

                        End If

                    Next
                Else

                    findfolders2()
                    Dim seri As New ObjectSerializer(Of AssetBrowserControl.SerializableTreeView)
                    seri.SaveSerializedObject(NaviMain3.treeView1, account.user & "Folders" & ".FL")
                    Dim seri11 As New ObjectSerializer(Of AssetBrowserControl.SerializableTreeView)
                    For Each tn2 As TreeNode In seri11.GetSerializedObject(account.user & "Folders" & ".FL").Nodes
                        Dim newTn2 As TreeNode
                        newTn2 = New TreeNode(tn2.Text)
                        If account.folders.Count = 0 Then
                            Dim newflist As New FolderList
                            account.folders.Add(newflist)
                            save()
                            If account.folders(0).items.Count > 0 Then
                                For Each f1 As FolderEmail In account.folders(0).items
                                    ' MsgBox(f1.name)
                                    If findfolderaccount(f1.name) = False Then
                                        Dim newf1 As New FolderEmail
                                        newf1.name = newTn2.Text
                                        account.folders(0).items.Add(newf1)

                                    End If
                                Next
                            Else
                                Dim newf1 As New FolderEmail
                                newf1.name = newTn2.Text
                                account.folders(0).items.Add(newf1)
                            End If

                        Else
                            If findfolderaccount(tn2.Text) = False Then
                                Dim newf1 As New FolderEmail
                                newf1.name = tn2.Text
                                account.folders(0).items.Add(newf1)

                            End If

                        End If
                    Next

                End If



            End If





            mailbox = "Caixa De Entrada"
            selectfolder = "Caixa De Entrada"
            Label2.Text = selectfolder
            Me.Refresh()
            Me.Update()



        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try


    End Sub
    Public Function findfolderaccount(ByVal folder As String) As Boolean
        Try
            For Each f2 As FolderEmail In account.folders(0).items
                If f2.name.ToLower.Contains(folder.ToLower) Then
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub SerializeTreeView(treeView As TreeView, fileName As String)
        Try
            Dim textWriter As New XmlTextWriter(fileName, System.Text.Encoding.ASCII)
            ' writing the xml declaration tag
            textWriter.WriteStartDocument()
            'textWriter.WriteRaw("\r\n");
            ' writing the main tag that encloses all node tags
            textWriter.WriteStartElement("TreeView")

            ' save the nodes, recursive method
            SaveNodes(treeView.Nodes, textWriter)

            textWriter.WriteEndElement()

            textWriter.Close()
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub

    Public Shared Function Before(value As String, a As String) As String
        Dim posA As Integer = value.IndexOf(a)
        If posA = -1 Then
            Return ""
        End If
        Return value.Substring(0, posA)
    End Function

    Public Sub DeserializeTreeView(treeView As TreeView, fileName As String)
        Dim reader As XmlTextReader = Nothing
        Try
            ' disabling re-drawing of treeview till all nodes are added
            treeView.BeginUpdate()
            reader = New XmlTextReader(fileName)
            Dim parentNode As TreeNode = Nothing
            While reader.Read()
                If reader.NodeType = XmlNodeType.Element Then
                    If reader.Name = XmlNodeTag Then
                        Dim newNode As New TreeNode()
                        Dim isEmptyElement As Boolean = reader.IsEmptyElement

                        ' loading node attributes
                        Dim attributeCount As Integer = reader.AttributeCount
                        If attributeCount > 0 Then
                            For i As Integer = 0 To attributeCount - 1
                                reader.MoveToAttribute(i)

                                '  SetAttributeValue(newNode, reader.Name, reader.Value)
                            Next
                        End If
                        ' add new node to Parent Node or TreeView
                        If parentNode IsNot Nothing Then
                            'MsgBox(newNode.Text)
                            parentNode.Nodes.Add(newNode)
                        Else
                            treeView.Nodes.Add(newNode)
                        End If

                        ' making current node 'ParentNode' if its not empty
                        If Not isEmptyElement Then
                            parentNode = newNode
                        End If
                    End If
                    ' moving up to in TreeView if end tag is encountered
                ElseIf reader.NodeType = XmlNodeType.EndElement Then
                    If reader.Name = XmlNodeTag Then
                        parentNode = parentNode.Parent
                    End If
                    'Ignore Xml Declaration                    
                ElseIf reader.NodeType = XmlNodeType.XmlDeclaration Then
                ElseIf reader.NodeType = XmlNodeType.None Then
                    Return
                ElseIf reader.NodeType = XmlNodeType.Text Then
                    parentNode.Nodes.Add(reader.Value)

                End If
            End While
        Finally
            ' enabling redrawing of treeview after all nodes are added
            treeView.EndUpdate()
            reader.Close()
        End Try
    End Sub

    Private Sub SaveNodes(nodesCollection As TreeNodeCollection, textWriter As XmlTextWriter)
        For i As Integer = 0 To nodesCollection.Count - 1
            Dim node As TreeNode = nodesCollection(i)
            textWriter.WriteStartElement(XmlNodeTag)
            textWriter.WriteAttributeString(XmlNodeTextAtt, node.Text)
            textWriter.WriteAttributeString(XmlNodeImageIndexAtt, node.ImageIndex.ToString())
            If node.Tag IsNot Nothing Then
                textWriter.WriteAttributeString(XmlNodeTagAtt, node.Tag.ToString())
            End If
            ' add other node properties to serialize here  
            If node.Nodes.Count > 0 Then
                SaveNodes(node.Nodes, textWriter)
            End If
            textWriter.WriteEndElement()
        Next
    End Sub





    Function ResolveNames(ByVal service As ExchangeService, ByVal name As String) As String
        Try
            ' Identify the mailbox folders to search for potential name resolution matches.
            Dim folders As New List(Of FolderId)
            folders.Add(New FolderId(WellKnownFolderName.Contacts))

            ' Search for all contact entries in the default mailbox contacts folder and in Active Directory. 
            ' This results in a call to EWS.
            Dim resolutions As NameResolutionCollection = service.ResolveName(name, _
                                                                              folders, _
                                                                              ResolveNameSearchLocation.ContactsThenDirectory, _
                                                                              True)

            Dim resolution As NameResolution

            For Each resolution In resolutions

                Return resolution.Mailbox.Address

            Next
        Catch ex As Exception
            Return ""
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Function

    Public Sub createnewfolder(ByVal foldername As String, ByVal folderid As FolderId)

        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text
        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try


            Dim folder As New Folder(service)
            folder.DisplayName = foldername
            folder.FolderClass = "IPF.MyCustomFolderClass"

            ' Create the folder as a child of the Inbox folder.
            folder.Save(folderid)
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub


    Public Sub findfolders2()

        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text
        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        NaviMain3.treeView1.Nodes.Clear()

        Dim str(1) As String
        Dim itm As ListViewItem
        Try

            Dim rootfolder As Folder = Folder.Bind(service, WellKnownFolderName.MsgFolderRoot)
            For Each folder In rootfolder.FindFolders(New FolderView(100))

                str(0) = (folder.DisplayName)
                str(1) = (folder.TotalCount)
                itm = New ListViewItem(str)

                Dim node As New TreeNode(str(0))
                TimeDelay()
                FindAllSubFolders(service, findfolders45(folder.DisplayName), node)
                NaviMain3.treeView1.Nodes.Add(node)


            Next





        Catch ex As ServiceRequestException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)


        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

        End Try
    End Sub


    Protected Sub GetAllNodes(ByVal subRoot As TreeNode, ByVal allNodes As List(Of TreeNode), info As IO.DirectoryInfo)
        Try
            ' check for null (this can be removed since within th
            If (subRoot Is Nothing) Then
                Exit Sub
            End If

            ' add subroot
            allNodes.Add(subRoot)
            info.CreateSubdirectory(subRoot.Text)
            Dim info2 As New IO.DirectoryInfo(info.FullName & "\" & subRoot.Text)

            ' add all it's children
            For i As Integer = 0 To subRoot.Nodes.Count - 1
                GetAllNodes(subRoot.Nodes(i), allNodes, info2)
            Next
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function FindAllSubFolders(ByVal service As ExchangeService, ByVal parentFolderId As FolderId, ByVal node As TreeNode) As String
        Try
            'search for sub folders
            Dim folderView As FolderView = New FolderView(1000)
            Dim foundFolders As FindFoldersResults = service.FindFolders(parentFolderId, folderView)

            ' Add the list to the growing complete list

            If foundFolders.TotalCount > 0 Then
            Else
                Return "no"
                Exit Function
            End If
            ' Now recurse
            For Each folder As Folder In foundFolders
                folder.Load()
                node.Nodes.Add(folder.DisplayName)
                Dim subfolders As String = FindAllSubFolders2(service, folder.Id, node)
                If subfolders <> "no" Then
                    node.LastNode.Nodes.Add(subfolders)
                    FindAllSubFolders(service, findfolders45(subfolders), node.LastNode.LastNode)
                End If
            Next
        Catch ex As Exception
            Return "no"
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Function
    Private Function FindAllSubFolders2(ByVal service As ExchangeService, ByVal parentFolderId As FolderId, ByVal node As TreeNode) As String
        Try
            'search for sub folders
            Dim folderView As FolderView = New FolderView(1000)
            Dim foundFolders As FindFoldersResults = service.FindFolders(parentFolderId, folderView)

            ' Add the list to the growing complete list

            If foundFolders.TotalCount > 0 Then
            Else
                Return "no"
                Exit Function
            End If
            ' Now recurse
            For Each folder As Folder In foundFolders
                folder.Load()
                Return (folder.DisplayName)
            Next
        Catch ex As Exception
            Return "no"
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Function


    Public Sub changecomboxbox(sender As Object, e As RibbonItemEventArgs) Handles RibbonComboBox2.DropDownItemClicked
        My.Settings.ThemeRibbon = e.Item.Text
        If e.Item.Text = "Office 2007" Then
            ribbon1.OrbStyle = RibbonOrbStyle.Office_2007
        End If
        If e.Item.Text = "Office 2010" Then
            ribbon1.OrbStyle = RibbonOrbStyle.Office_2010
        End If
        If e.Item.Text = "Office 2013" Then
            ribbon1.OrbStyle = RibbonOrbStyle.Office_2013
        End If
    End Sub


    Public Sub refreshthemeandcolor()
        If My.Settings.ThemeRibbon = "Office 2007" Then
            ribbon1.OrbStyle = RibbonOrbStyle.Office_2007
        End If
        If My.Settings.ThemeRibbon = "Office 2010" Then
            ribbon1.OrbStyle = RibbonOrbStyle.Office_2010
        End If
        If My.Settings.ThemeRibbon = "Office 2013" Then
            ribbon1.OrbStyle = RibbonOrbStyle.Office_2013
        End If
    End Sub


    Public Sub copyngiitems(sender As Object, e As DoWorkEventArgs)

        Try

            If nodetext <> "" Then
                Dim bp As BackgroundWorker = TryCast(sender, BackgroundWorker)
                bp.ReportProgress(0)


                For i As Integer = 0 To controlstodo.Count - 1
                    Dim control1 As ListControlItem = TryCast(GetControlByName(controlstodo.Item(i)), ListControlItem)
                    If control1.CheckBox1.CheckState = CheckState.Checked Then
                        itemmail = control1.idmessage
                        emailnow = control1.subject
                        bp.ReportProgress(1)
                        mailbox2 = nodetext
                        mailbox = Label2.Text
                        selectfolder = Label2.Text
                        findfolders16()
                        For Each x5 As FolderEmail In account.folders(0).items
                            If x5.name.ToLower.Contains(mailbox.ToLower) Then
                                For Each m1 As Email In x5.emails.emails
                                    If m1.idmessage.ToLower.Contains(itemmail.ToLower) Then
                                        '  copytofolderaccount(m1, mailbox2)
                                        Exit For
                                    End If
                                Next


                            End If

                        Next
                    End If

                Next
            End If







            controlstodo.Clear()
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub movingitems(sender As Object, e As DoWorkEventArgs)
        Try

            If nodetext <> "" Then
                Dim bp As BackgroundWorker = TryCast(sender, BackgroundWorker)
                bp.ReportProgress(0)
                For i As Integer = 0 To controlstodo.Count - 1
                    Dim control1 As ListControlItem = TryCast(GetControlByName(controlstodo.Item(i)), ListControlItem)
                    If control1.CheckBox1.CheckState = CheckState.Checked Then
                        itemmail = control1.idmessage
                        emailnow = control1.subject
                        bp.ReportProgress(1)
                        mailbox2 = nodetext
                        mailbox = Label2.Text
                        selectfolder = Label2.Text
                        findfolders6()
                        Me.Invoke(Sub() clearlist(control1))
                        For Each x5 As FolderEmail In account.folders(0).items
                            If x5.name.ToLower.Contains(mailbox.ToLower) Then
                                For Each m1 As Email In x5.emails.emails
                                    If m1.idmessage.ToLower.Contains(itemmail.ToLower) Then
                                        'movetofolderaccount(m1, mailbox2)
                                        deletefromfolderaccount(m1, mailbox)
                                        x5.emails.emails.Remove(m1)
                                        save()
                                        Exit For
                                    End If
                                Next


                            End If
                        Next
                    End If



                Next

            End If

            controlstodo.Clear()



        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Protected Overrides Sub OnClosing(e As CancelEventArgs)
        MyBase.OnClosing(e)
        Process.GetCurrentProcess.Kill()
    End Sub
    Public Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.Update()
            Me.Refresh()
            LoginForm1.Show()
            Me.Refresh()
            Me.Update()
            Me.Hide()
            If TextBox3.Text <> "" Then
                Me.Hide()
                Me.Refresh()
                Me.EmailReader1.changecontextmenulistview(Me.ContextMenuStrip1)

                start()
                ribbon1.Refresh()
                Me.Refresh()
                Me.Update()

                If NaviMain3.treeView1.Nodes.Count > 0 Then
                    NaviMain3.treeView1.SelectedNode = FindNode(NaviMain3.treeView1, Label2.Text)
                    selectfolder = NaviMain3.treeView1.SelectedNode.Text
                End If
                Timer2.Enabled = True
                Timer2.Start()
            Else
                Me.Hide()
                ribbon1.Refresh()
                Me.Refresh()
                Me.Update()
                start()
                If NaviMain3.treeView1.Nodes.Count > 0 Then
                    NaviMain3.treeView1.SelectedNode = FindNode(NaviMain3.treeView1, Label2.Text)
                    selectfolder = NaviMain3.treeView1.SelectedNode.Text
                End If

                Exit Sub
            End If

            RibbonComboBox2.TextBoxText = My.Settings.ThemeRibbon
            refreshthemeandcolor()

            Me.Refresh()

            listthread = New Threading.Thread(Sub() startimport())
            listthread.TrySetApartmentState(Threading.ApartmentState.STA)
            listthread.Start()
            orderlist(True)
            checktrhead = New Threading.Thread(Sub() checkemails(Label2.Text))
            checktrhead.TrySetApartmentState(Threading.ApartmentState.STA)
            checktrhead.Start()
            Me.Show()
        Catch ex As Exception
            '  MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try

    End Sub
    Public Sub startimport()
        Try
            Me.Invoke(Sub() importemails(Label2.Text))
            Me.Invoke(Sub() orderlist(True))
        Catch ex As Exception
            '  MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Invoke(Sub() EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString))
        End Try
    End Sub

    Private Function FindNode(ByVal tvSelection As TreeView, ByVal matchText As String) As TreeNode
        Try
            For Each node As TreeNode In tvSelection.Nodes

                If node.Text.ToLower.Contains(matchText.Trim.ToLower) Then

                    Return node
                    Exit Function
                Else
                    If node.Nodes.Count > 0 Then
                        Dim nodeChild As TreeNode = findchildnode(node, matchText)
                        If nodeChild IsNot Nothing Then
                            Return nodeChild
                            Exit Function
                        End If
                    End If
                End If
            Next
            Return DirectCast(Nothing, TreeNode)
        Catch ex As Exception
            Return Nothing
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Function
    Public Function findchildnode(ByVal node As TreeNode, ByVal matchtext As String) As TreeNode
        Try

            For Each node1 As TreeNode In node.Nodes
                If node1.Text.ToLower.Contains(matchtext.Trim.ToLower) Then
                    '    MsgBox(node1.Text)

                    Return node1

                    Exit Function
                Else
                    If node1.Nodes.Count > 0 Then
                        Dim nodeChild As TreeNode = findchildnode(node1, matchtext)
                        If nodeChild IsNot Nothing Then
                            Return nodeChild
                            Exit Function
                        End If
                    End If
                End If
            Next
            Return NaviMain3.treeView1.Nodes(0)
        Catch ex As Exception

            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
            Return NaviMain3.treeView1.Nodes(0)
        End Try
    End Function




    Public Sub orderlist(ByVal crescente As Boolean)
        Try
            If crescente = True Then
                ArboScrollableListBox2.BeginUpdate()
                ArboScrollableListBox2.Items.Sort(Function(x As ListControlItem, y As ListControlItem) Convert.ToDateTime(y.Duration).CompareTo(Convert.ToDateTime(x.Duration)))
                ArboScrollableListBox2.EndUpdate()
            Else
                ArboScrollableListBox2.BeginUpdate()
                ArboScrollableListBox2.Items.Sort(Function(x As ListControlItem, y As ListControlItem) Convert.ToDateTime(x.Duration).CompareTo(Convert.ToDateTime(y.Duration)))
                ArboScrollableListBox2.EndUpdate()
            End If
            ToolStripStatusLabel3.Text = "Items:" & ArboScrollableListBox2.Items.Count
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub TimeDelay()
        Try
            stopsearch = True
            Do While stopsearch = True
                Application.DoEvents()
                System.Threading.Thread.Sleep(1)
                Me.Update()
                Exit Do
            Loop

        Catch ex As Exception
            'EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try


    End Sub




    Sub checkchar(ByVal name As String)
        Try
            Dim str As String = name
            Dim separador() As Char
            Dim sep As String = ";"
            'definindo o separador a ser usado
            If name = String.Empty Then
                separador = New Char() {" "c}
            Else
                separador = New Char() + sep.ToCharArray
            End If

            ' Separa string baseado no delimitador
            Dim palavras As String() = str.Split(separador)

            Dim palavra As String
            For Each palavra In palavras
                'resolvename2(palavra)
            Next
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub



    Sub checkchar2(ByVal name As String)
        Try
            Dim str As String = name
            Dim separador() As Char
            Dim sep As String = ";"
            'definindo o separador a ser usado
            If name = String.Empty Then
                separador = New Char() {" "c}
            Else
                separador = New Char() + sep.ToCharArray
            End If

            ' Separa string baseado no delimitador
            Dim palavras As String() = str.Split(separador)

            Dim palavra As String
            For Each palavra In palavras
                ' resolvename4(palavra)
            Next
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub




    Private Sub base64Encode(ByVal sData As String)
        Try
            Dim encData_byte As Byte() = New Byte(sData.Length - 1) {}
            encData_byte = System.Text.Encoding.UTF8.GetBytes(sData)
            Dim encodedData As String = Convert.ToBase64String(encData_byte)
            ' WriteToRegistry(Global.Microsoft.Win32.RegistryHive.CurrentUser, "SOFTWARE\ExchangeEmailToolsIT\", "Pass", encodedData)
        Catch ex As Exception
            Throw (New Exception("Error in base64Encode" & ex.Message))
        End Try
    End Sub







    Public Shared Function encode(ByVal str As String) As String
        Try
            'supply True as the construction parameter to indicate
            'that you wanted the class to emit BOM (Byte Order Mark)
            'NOTE: this BOM value is the indicator of a UTF-8 string
            Dim utf8Encoding As New System.Text.UTF8Encoding(True)
            Dim encodedString() As Byte

            encodedString = utf8Encoding.GetBytes(str)

            Return utf8Encoding.GetString(encodedString)
        Catch ex As Exception
            Return ""
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Function

    Function testreplace(ByVal value As String, ByVal valuetoreplace As String, ByVal valuereplaced As String) As String
        Try
            Dim builder As New System.Text.StringBuilder(value)
            builder.Replace(valuetoreplace, valuereplaced)
            Return builder.ToString

        Catch ex As Exception
            Return ""
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try


    End Function

    Public Shared Function ToHtml(ByVal s As String, ByVal nofollow As Boolean) As String
        Try
            Application.DoEvents()
            Threading.Thread.Sleep(1)
            s = Web.HttpUtility.HtmlEncode(s)
            Dim paragraphs() As String = s.Split(New String() {"" & vbCrLf & vbCrLf}, StringSplitOptions.None)
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder
            For Each par As String In paragraphs
                Application.DoEvents()
                Threading.Thread.Sleep(1)
                sb.AppendLine("<p>")
                Dim p As String = par.Replace(Environment.NewLine, "<br />" & vbCrLf)
                If nofollow Then
                    p = System.Text.RegularExpressions.Regex.Replace(p, "\[\[(.+)\]\[(.+)\]\]", "<a href=\""$2\"" rel=\""nofollow\"">$1</a>")
                    p = System.Text.RegularExpressions.Regex.Replace(p, "\[\[(.+)\]\]", "<a href=\""$1\"" rel=\""nofollow\"">$1</a>")
                Else
                    p = System.Text.RegularExpressions.Regex.Replace(p, "\[\[(.+)\]\[(.+)\]\]", "<a href=\""$2\"">$1</a>")
                    p = System.Text.RegularExpressions.Regex.Replace(p, "\[\[(.+)\]\]", "<a href=\""$1\"">$1</a>")
                    sb.AppendLine(p)
                End If
                sb.AppendLine("</p>")
            Next
            Return sb.ToString
        Catch ex As Exception
            Return ""
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try


    End Function






    Public Sub findfolders6()

        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text
        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try
            Application.DoEvents()


            Dim allFoldersType As ExtendedPropertyDefinition = New ExtendedPropertyDefinition(13825, MapiPropertyType.Integer)
            Dim rootFolderId As FolderId = New FolderId(WellKnownFolderName.Root)
            Dim folderView As FolderView = New FolderView(1000)
            folderView.Traversal = FolderTraversal.Deep
            Dim searchFilter2 As SearchFilter = New SearchFilter.IsEqualTo(FolderSchema.DisplayName, mailbox2)
            Dim searchFilterCollection As SearchFilter.SearchFilterCollection = New SearchFilter.SearchFilterCollection(LogicalOperator.And)
            searchFilterCollection.Add(searchFilter2)

            Dim findFoldersResults As FindFoldersResults = service.FindFolders(rootFolderId, searchFilterCollection, folderView)

            If findFoldersResults.Folders.Count > 0 Then
                Dim allItemsFolder As Folder = findFoldersResults.Folders(0)
                findfolders5(allItemsFolder.Id)
            End If




        Catch ex As ServiceRequestException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '   MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '   MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Public Sub findfolders5(ByVal folder5 As FolderId)
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text
        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try
            Application.DoEvents()
            If selectfolder = "" Or selectfolder = "Caixa De Entrada" Then
                MoveEmail(WellKnownFolderName.Inbox, folder5)
                Exit Sub
            End If

            Dim allFoldersType As ExtendedPropertyDefinition = New ExtendedPropertyDefinition(13825, MapiPropertyType.Integer)
            Dim rootFolderId As FolderId = New FolderId(WellKnownFolderName.Root)
            Dim folderView As FolderView = New FolderView(1000)
            folderView.Traversal = FolderTraversal.Deep
            Dim searchFilter2 As SearchFilter = New SearchFilter.IsEqualTo(FolderSchema.DisplayName, selectfolder)
            Dim searchFilterCollection As SearchFilter.SearchFilterCollection = New SearchFilter.SearchFilterCollection(LogicalOperator.And)
            searchFilterCollection.Add(searchFilter2)

            Dim findFoldersResults As FindFoldersResults = service.FindFolders(rootFolderId, searchFilterCollection, folderView)

            If findFoldersResults.Folders.Count > 0 Then
                Dim allItemsFolder As Folder = findFoldersResults.Folders(0)
                MoveEmail(allItemsFolder.Id, folder5)
            End If




        Catch ex As ServiceRequestException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '  MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '   MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Public Sub findfolders16()
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text
        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try
            Application.DoEvents()


            Dim allFoldersType As ExtendedPropertyDefinition = New ExtendedPropertyDefinition(13825, MapiPropertyType.Integer)
            Dim rootFolderId As FolderId = New FolderId(WellKnownFolderName.Root)
            Dim folderView As FolderView = New FolderView(1000)
            folderView.Traversal = FolderTraversal.Deep
            Dim searchFilter2 As SearchFilter = New SearchFilter.IsEqualTo(FolderSchema.DisplayName, mailbox2)
            Dim searchFilterCollection As SearchFilter.SearchFilterCollection = New SearchFilter.SearchFilterCollection(LogicalOperator.And)
            searchFilterCollection.Add(searchFilter2)

            Dim findFoldersResults As FindFoldersResults = service.FindFolders(rootFolderId, searchFilterCollection, folderView)

            If findFoldersResults.Folders.Count > 0 Then
                Dim allItemsFolder As Folder = findFoldersResults.Folders(0)
                findfolders15(allItemsFolder.Id)
            End If




        Catch ex As ServiceRequestException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '   MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '    MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Public Sub findfolders15(ByVal folder5 As FolderId)
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text
        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try
            Application.DoEvents()
            If selectfolder = "" Or selectfolder = "Caixa De Entrada" Then
                CopyEmails(WellKnownFolderName.Inbox, folder5)
                Exit Sub
            End If

            Dim allFoldersType As ExtendedPropertyDefinition = New ExtendedPropertyDefinition(13825, MapiPropertyType.Integer)
            Dim rootFolderId As FolderId = New FolderId(WellKnownFolderName.Root)
            Dim folderView As FolderView = New FolderView(1000)
            folderView.Traversal = FolderTraversal.Deep
            Dim searchFilter2 As SearchFilter = New SearchFilter.IsEqualTo(FolderSchema.DisplayName, selectfolder)
            Dim searchFilterCollection As SearchFilter.SearchFilterCollection = New SearchFilter.SearchFilterCollection(LogicalOperator.And)
            searchFilterCollection.Add(searchFilter2)

            Dim findFoldersResults As FindFoldersResults = service.FindFolders(rootFolderId, searchFilterCollection, folderView)

            If findFoldersResults.Folders.Count > 0 Then
                Dim allItemsFolder As Folder = findFoldersResults.Folders(0)
                CopyEmails(allItemsFolder.Id, folder5)
            End If




        Catch ex As ServiceRequestException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            'MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Public Sub MoveEmail(ByVal folder3 As FolderId, ByVal folder4 As FolderId)
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text



        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try
            Application.DoEvents()
            Threading.Thread.Sleep(1)

            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(folder3, New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, itemmail), New ItemView(5))

            For Each message As Item In foundItems
                message.Load()
                message.Move(folder4)
            Next




        Catch ex As ServiceRequestException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '  MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '    MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub movetofolderaccount(ByVal email As Email, ByVal tofolder As String)
        Try
            For Each x5 As FolderEmail In account.folders(0).items
                If x5.name.ToLower.Contains(tofolder.ToLower) Then
                    x5.emails.emails.Add(email)
                    save()
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Public Sub copytofolderaccount(ByVal email As Email, ByVal tofolder As String)
        Try
            For Each x5 As FolderEmail In account.folders(0).items
                If x5.name.ToLower.Contains(tofolder.ToLower) Then
                    x5.emails.emails.Add(email)
                    save()
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Public Sub deletefromfolderaccount(ByVal email As Email, ByVal tofolder As String)
        Try
            For Each x5 As FolderEmail In account.folders(0).items
                If x5.name.ToLower.Contains(tofolder.ToLower) Then
                    x5.emails.emails.Remove(email)
                    Me.Invoke(Sub() save())
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Public Sub CopyTreeview(ByVal treeview1 As TreeView, ByVal treeview2 As TreeView)
        Try
            Dim newTn As TreeNode
            For Each tn As TreeNode In treeview1.Nodes
                newTn = New TreeNode(tn.Text)
                CopyChilds(newTn, tn)
                treeview2.Nodes.Add(newTn)

            Next
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub
    Public Sub CopyTreeview(ByVal treeview1 As AssetBrowserControl.SerializableTreeView, ByVal treeview2 As TreeView)
        Try
            Dim newTn As TreeNode
            For Each tn As TreeNode In treeview1.Nodes
                newTn = New TreeNode(tn.Text)
                CopyChilds(newTn, tn)
                treeview2.Nodes.Add(newTn)

            Next
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub

    Public Sub CopyChilds(ByVal parent As TreeNode, ByVal willCopied As TreeNode)
        Try
            Dim newTn1 As TreeNode
            For Each tn As TreeNode In willCopied.Nodes
                newTn1 = New TreeNode(tn.Text)
                parent.Nodes.Add(newTn1)
            Next
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub
    Public Sub selecttingfolder(sender As Object, e As EventArgs)
        Try

            Dim f5 As OfficeList.FolderOffice = sender.parent
            NaviMain3.treeView1.SelectedNode = FindNode(NaviMain3.treeView1, f5.namefolder)
            selecttreeview()

        Catch ex As Exception

        End Try
    End Sub
    Public Sub CopyEmails(ByVal folder3 As FolderId, ByVal folder4 As FolderId)
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text



        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try
            Application.DoEvents()
            Threading.Thread.Sleep(1)

            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(folder3, New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, itemmail), New ItemView(5))

            For Each message As Item In foundItems
                message.Load()
                message.Copy(folder4)
                ' Dim filetosearch As String = userconf & "\" & selectfolder & "\" & ExtractNumber(itemmail) & ".txt"
                ' If navimain3.treeView1.SelectedNode IsNot Nothing Then
                ' filetosearch = navimain3.treeView1.SelectedNode.FullPath & "\" & ExtractNumber(itemmail) & ".txt"
                '  End If
                '  If IO.File.Exists(filetosearch) Then
                '  If navimain3.treeView1.SelectedNode IsNot Nothing Then
                ' IO.File.Copy(filetosearch, Form7.TreeView1.SelectedNode.FullPath & "\" & IO.Path.GetFileName(filetosearch))
                'Else

                'IO.File.Copy(filetosearch, userconf & "\" & folder4.FolderName & "\" & IO.Path.GetFileName(filetosearch))
                'End If
                'End If
            Next


        Catch ex As ServiceRequestException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '   MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
            '
            '  MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




    Public Sub importemails(ByVal folder As String)
        Try


            Dim countfiles As Integer = 0
            moreemails.Clear()

            MetroProgressBar1.Value = 0
            If account.folders(0).items.Count > 0 Then
                For Each x10 As FolderEmail In account.folders(0).items

                    If x10.name.ToLower.Contains(folder.ToLower) Then
                        If x10.emails.emails.Count > 0 Then
                            Dim emailslist As List(Of Email) = x10.emails.emails.OrderByDescending(Function(x) x.data).ToList()
                            MetroProgressBar1.Maximum = x10.emails.emails.Count
                            For Each m1 As Email In emailslist
                                TimeDelay()
                                If ArboScrollableListBox2.Items.Count > 900 Then
                                    moreemails.Add(m1.idmessage)
                                Else

                                    Dim c As New ListControlItem



                                    c.Name = "item" & countfiles
                                    c.from = m1.De
                                    c.displayto = m1.Para
                                    c.Duration = m1.data.ToString
                                    c.idmessage = m1.idmessage
                                    c.subject = m1.Assunto
                                    c.PictureBox1.Visible = m1.hasatt

                                    c.folder = m1.folder

                                    If m1.read = False Then
                                        c.Panel1.BackColor = Color.Maroon
                                    End If
                                    Dim canadd As Boolean = True

                                    If c.folder <> "" Then

                                        If c.folder.ToLower.Contains(Label2.Text.ToLower) And allreadyxists(c.idmessage, ArboScrollableListBox2.Items) = False Then
                                            canadd = True

                                        Else
                                            canadd = False


                                        End If
                                    End If

                                    If canadd = True And allreadyxists(c.idmessage, ArboScrollableListBox2.Items) = False Then

                                        AddHandler c.SelectionChanged, AddressOf ListControl1.SelectionChanged
                                        AddHandler c.Click, AddressOf ListControl1.ItemClicked
                                        AddHandler c.CheckBox1.CheckedChanged, AddressOf checkchange
                                        reloadlistcontrol(c)
                                        ArboScrollableListBox2.Update()
                                        MetroProgressBar1.Value += 1
                                        countfiles = countfiles + 1
                                    End If
                                End If

                            Next
                            MetroProgressBar1.Value = MetroProgressBar1.Maximum
                        Else
                            If NaviMain3.treeView1.SelectedNode Is Nothing Then
                                DownloadEmails.Show()
                                downloadstartemail()
                            Else
                                DownloadEmails.Show()
                                downloadstartemail(NaviMain3.treeView1.SelectedNode.Text)
                            End If

                        End If
                    End If
                Next
            End If



            'selecttreeview()
            If moreemails.Count > 0 Then
                MetroButton2.Enabled = True
                MetroButton2.Text = "+ Emails" & "(" & moreemails.Count & ")"
            End If

        Catch mem As InsufficientMemoryException

            EnviarReceber.Task1.adderror(mem.GetType.ToString, mem.Message, mem.StackTrace, Now.ToString)
        Catch ex As Exception

            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

        End Try
    End Sub
    Public Sub reloadlist(ByVal list1 As List(Of Control))
        Try
            For Each c As ListControlItem In list1
                If allreadyxists(c.idmessage, ArboScrollableListBox2.Items) = False Then
                    ArboScrollableListBox2.BeginUpdate()
                    ArboScrollableListBox2.Items.Add(c)
                    AddHandler c.SelectionChanged, AddressOf ArboScrollableListBox2_oncontrolselect
                    AddHandler c.DoubleClick, AddressOf ArboScrollableListBox2_doubleclick
                    ArboScrollableListBox2.EndUpdate()
                End If

            Next
        Catch mem As InsufficientMemoryException
            EnviarReceber.Task1.adderror(mem.GetType.ToString, mem.Message, mem.StackTrace, Now.ToString)
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            'MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub importmoreemails()
        Try
            Dim countfiles As Integer = 0
            Dim read As Boolean = True
            Dim hasatt As Boolean = False
            Dim more As Boolean = False
            Dim newlist As New List(Of String)
            If moreemails IsNot Nothing And moreemails.Count > 0 Then
                If moreemails.Count > 900 Then
                    MetroProgressBar1.Maximum = 900
                Else
                    MetroProgressBar1.Maximum = moreemails.Count
                End If
                For Each x As String In moreemails
                    If ArboScrollableListBox2.Items.Count > 900 Then
                        Exit Sub
                    End If


                    TimeDelay()
                    countfiles = countfiles + 1
                    If countfiles > 900 Then

                        newlist.Add(x)
                        more = True
                    Else
                        Dim c As New ListControlItem
                        If checkemail(Label2.Text, x) IsNot Nothing Then
                            Dim m1 As Email = TryCast(checkemail(Label2.Text, x), Email)

                            itemcount = itemcount + 1
                            c.Name = "itemMoreEmail" & itemcount.ToString
                            c.from = m1.De
                            c.displayto = m1.Para
                            c.Duration = m1.data.ToString
                            c.idmessage = m1.idmessage
                            c.subject = m1.Assunto
                            c.PictureBox1.Visible = m1.hasatt
                            c.folder = m1.folder
                            If m1.read = False Then
                                c.Panel1.BackColor = Color.Maroon
                            End If
                            Dim canadd As Boolean = True
                            If c.folder <> "" Then
                                If c.folder.ToLower.Contains(Label2.Text.ToLower) Then
                                    canadd = True
                                Else
                                    canadd = False

                                End If
                            End If
                            If canadd = True Then
                                AddHandler c.SelectionChanged, AddressOf ListControl1.SelectionChanged
                                AddHandler c.Click, AddressOf ListControl1.ItemClicked
                                AddHandler c.CheckBox1.CheckedChanged, AddressOf checkchange
                                reloadlistcontrol(c)
                                ArboScrollableListBox2.Update()
                                MetroProgressBar1.Value += 1
                            End If
                        End If


                    End If
                Next
            End If
            orderlist(True)
            If more = True Then
                importmoreemails(newlist)
            End If

        Catch mem As InsufficientMemoryException

            EnviarReceber.Task1.adderror(mem.GetType.ToString, mem.Message, mem.StackTrace, Now.ToString)
        Catch ex As Exception

            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            'MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub importmoreemails(ByVal list1 As List(Of String))

        Try
            Dim countfiles As Integer = 0
            Dim read As Boolean = True
            Dim hasatt As Boolean = False
            Dim more As Boolean = False
            Dim newlist As New List(Of String)
            If moreemails IsNot Nothing And moreemails.Count > 0 Then
                If moreemails.Count > 900 Then
                    MetroProgressBar1.Maximum = 900
                Else
                    MetroProgressBar1.Maximum = moreemails.Count
                End If
                For Each x As String In list1
                    If ArboScrollableListBox2.Items.Count > 900 Then
                        Exit Sub
                    End If


                    TimeDelay()
                    countfiles = countfiles + 1
                    If countfiles > 900 Then

                        newlist.Add(x)
                        more = True
                    Else
                        Dim c As New ListControlItem
                        If checkemail(Label2.Text, x) IsNot Nothing Then
                            Dim m1 As Email = TryCast(checkemail(Label2.Text, x), Email)

                            itemcount = itemcount + 1
                            c.Name = "itemMoreOld" & itemcount.ToString
                            c.from = m1.De
                            c.displayto = m1.Para
                            c.Duration = m1.data.ToString
                            c.idmessage = m1.idmessage
                            c.subject = m1.Assunto
                            c.PictureBox1.Visible = m1.hasatt
                            c.folder = m1.folder
                            If m1.read = False Then
                                c.Panel1.BackColor = Color.Maroon
                            End If
                            Dim canadd As Boolean = True
                            If c.folder <> "" Then
                                If c.folder.ToLower.Contains(Label2.Text.ToLower) Then
                                    canadd = True
                                Else
                                    canadd = False

                                End If
                            End If
                            If canadd = True Then
                                AddHandler c.SelectionChanged, AddressOf ListControl1.SelectionChanged
                                AddHandler c.Click, AddressOf ListControl1.ItemClicked
                                AddHandler c.CheckBox1.CheckedChanged, AddressOf checkchange
                                reloadlistcontrol(c)
                                ArboScrollableListBox2.Update()
                                MetroProgressBar1.Value += 1
                            End If
                        End If


                    End If
                Next
            End If
            orderlist(True)
            If more = True Then
                importmoreemails(newlist)
            End If

        Catch mem As InsufficientMemoryException

            EnviarReceber.Task1.adderror(mem.GetType.ToString, mem.Message, mem.StackTrace, Now.ToString)
        Catch ex As Exception

            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            'MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub Emailsdownload(ByVal folder As String)
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text
        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try
            Dim offset As Integer = 0
            Dim pageSize As Integer = 1000
            Dim more As Boolean = True
            Dim view As New ItemView(pageSize, offset, OffsetBasePoint.Beginning)
            Dim mfrom As String = ""
            Dim subject As String = ""
            Dim displayto As String = ""
            Dim datatimereceived As String = ""
            Dim internentmessageid As String = ""
            Dim messagebody As String = ""
            Dim cc As String = ""
            Dim read As Boolean = False
            Dim hasatt As Boolean = False
            Dim mfromadress As String = ""
            Dim findResults As FindItemsResults(Of Item)
            If BackgroundWorker2.CancellationPending = True Then
                Exit Sub
            End If

            findResults = service.FindItems(findfolders45(folder), view)
            foldercount = findResults.TotalCount
            foldercountnow = foldercount
            emailsprogressnow = 0
            BackgroundWorker2.ReportProgress(0)
            For Each Item As EmailMessage In findResults
                If BackgroundWorker2.CancellationPending = True Then
                    Exit Sub
                End If
                Dim indexitem As Integer = findResults.Items.IndexOf(Item)
                emailsprogressnow = 1
                emailnow = Item.Subject
                foldercountnow = foldercountnow - 1
                BackgroundWorker2.ReportProgress(0)
                If indexitem = 999 Or indexitem > 999 Then
                    Emailsdownload(folder, foldercountnow)
                    Exit Sub
                End If

                If Item.InternetMessageId IsNot Nothing Then
                    internentmessageid = Item.InternetMessageId

                Else
                    internentmessageid = ""
                End If

                If checkemailaccount(folder, internentmessageid) = False Then

                    Dim newemail As New Email

                    Item.Load()
                    Item.Body.BodyType = BodyType.HTML
                    If Item.Body IsNot Nothing Then
                        messagebody = Item.Body

                    End If

                    If Item.From IsNot Nothing Then
                        mfrom = Item.From.Name
                        mfromadress = Item.From.Address
                    Else
                        mfrom = ""
                    End If
                    If Item.Subject IsNot Nothing Then
                        subject = Item.Subject
                    Else
                        subject = ""
                    End If

                    If Item.DisplayTo IsNot Nothing Then
                        displayto = Item.DisplayTo
                    Else
                        displayto = ""
                    End If

                    If Item.DisplayCc IsNot Nothing Then
                        cc = Item.DisplayCc
                    End If

                    If Item.DateTimeReceived.ToString IsNot Nothing Then
                        datatimereceived = Item.DateTimeReceived.ToString
                    Else
                        datatimereceived = ""
                    End If

                    If Item.HasAttachments Then
                        For j As Integer = 0 To Item.Attachments.Count - 1


                            Me.Invoke(Sub() addattachaments(Item.Attachments.Item(j).Name, Item.Attachments.Item(j).Id.ToString))


                        Next
                        For Each x1 As DataGridViewRow In MetroGrid1.Rows

                            If x1.Cells(0).Value IsNot Nothing Then
                                newemail.anexos.Add(x1.Cells(0).Value.ToString)
                            End If
                            If x1.Cells(1).Value IsNot Nothing Then
                                newemail.anexosid.Add(x1.Cells(1).Value.ToString)
                            End If




                        Next
                    End If

                    Me.Invoke(Sub() MetroGrid1.Rows.Clear())
                    newemail.De = mfrom
                    newemail.Assunto = subject
                    newemail.idmessage = internentmessageid
                    newemail.CC = cc
                    newemail.Html = messagebody
                    newemail.Para = displayto
                    newemail.read = Item.IsRead
                    newemail.hasatt = Item.HasAttachments
                    newemail.data = Item.DateTimeReceived
                    Dim foldername As Microsoft.Exchange.WebServices.Data.Folder = Microsoft.Exchange.WebServices.Data.Folder.Bind(service, Item.ParentFolderId)
                    newemail.folder = foldername.DisplayName
                    For Each x5 As FolderEmail In account.folders(0).items
                        If x5.name.ToLower.Contains(newemail.folder.ToLower) Then
                            If checkemailaccount(folder, internentmessageid) = False Then
                                x5.emails.emails.Add(newemail)
                                save()
                            End If
                        End If
                    Next
                    If BackgroundWorker2.CancellationPending = True Then
                        Exit Sub
                    End If
                    If ArboScrollableListBox2.Items.Count < 900 Then
                        Dim c As New ListControlItem
                        c.from = mfrom
                        c.displayto = displayto
                        c.Duration = datatimereceived
                        c.idmessage = internentmessageid
                        c.subject = subject
                        c.PictureBox1.Visible = Item.HasAttachments
                        If Item.IsRead = False Then
                            c.Panel1.BackColor = Color.Maroon
                        End If
                        AddHandler c.SelectionChanged, AddressOf ListControl1.SelectionChanged
                        AddHandler c.Click, AddressOf ListControl1.ItemClicked
                        AddHandler c.CheckBox1.CheckedChanged, AddressOf checkchange
                        Me.Invoke(Sub() reloadlistcontrol(c))
                        Me.Invoke(Sub() ArboScrollableListBox2.Update())
                    End If
                End If
            Next

        Catch ex As ServiceRequestException

        Catch ex As Exception
            Me.Invoke(Sub() EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString))

            ' MetroMessageBox.Show(Me, ex.StackTrace & "," & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub save()
        Try
            Dim seri As New ObjectSerializer(Of User)
            seri.SaveSerializedObject(account, user & ".Ews")
        Catch ex As Exception

        End Try
    End Sub
    Public Sub addattachaments(ByVal name As String, ByVal id As String)

        Try
            Dim row As DataGridViewRow = DirectCast(MetroGrid1.Rows(0).Clone(), DataGridViewRow)
            Dim row1 As String() = New String() {name, id}
            MetroGrid1.Rows.Add(row1)
        Catch ex As Exception

        End Try

    End Sub


    Public Sub Emailsdownload(ByVal folder1 As String, ByVal offset As Integer)
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text
        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try

            Dim pageSize As Integer = 1000
            Dim more As Boolean = True
            Dim view As New ItemView(pageSize, offset, OffsetBasePoint.Beginning)
            Dim mfrom As String = ""
            Dim subject As String = ""
            Dim displayto As String = ""
            Dim datatimereceived As String = ""
            Dim internentmessageid As String = ""
            Dim messagebody As String = ""
            Dim cc As String = ""
            Dim read As Boolean = False
            Dim hasatt As Boolean = False
            Dim mfromadress As String = ""
            Dim findResults As FindItemsResults(Of Item)
            If BackgroundWorker2.CancellationPending = True Then
                Exit Sub
            End If

            findResults = service.FindItems(findfolders45(folder1), view)
            foldercount = findResults.TotalCount
            foldercountnow = foldercount
            emailsprogressnow = 0
            BackgroundWorker2.ReportProgress(0)
            For Each Item As EmailMessage In findResults
                If BackgroundWorker2.CancellationPending = True Then
                    Exit Sub
                End If
                Dim indexitem As Integer = findResults.Items.IndexOf(Item)
                emailsprogressnow = 1
                emailnow = Item.Subject
                foldercountnow = foldercountnow - 1
                BackgroundWorker2.ReportProgress(0)
                If indexitem = 999 Or indexitem > 999 Then
                    Emailsdownload(folder1, foldercountnow)
                    Exit Sub
                End If

                If Item.InternetMessageId IsNot Nothing Then
                    internentmessageid = Item.InternetMessageId

                Else
                    internentmessageid = ""
                End If
                If checkemailaccount(folder1, internentmessageid) = False Then

                    Dim newemail As New Email

                    Item.Load()
                    Item.Body.BodyType = BodyType.HTML
                    If Item.Body IsNot Nothing Then
                        messagebody = Item.Body

                    End If

                    If Item.From IsNot Nothing Then
                        mfrom = Item.From.Name
                        mfromadress = Item.From.Address
                    Else
                        mfrom = ""
                    End If
                    If Item.Subject IsNot Nothing Then
                        subject = Item.Subject
                    Else
                        subject = ""
                    End If

                    If Item.DisplayTo IsNot Nothing Then
                        displayto = Item.DisplayTo
                    Else
                        displayto = ""
                    End If

                    If Item.DisplayCc IsNot Nothing Then
                        cc = Item.DisplayCc
                    End If

                    If Item.DateTimeReceived.ToString IsNot Nothing Then
                        datatimereceived = Item.DateTimeReceived.ToString
                    Else
                        datatimereceived = ""
                    End If

                    If Item.HasAttachments Then
                        For j As Integer = 0 To Item.Attachments.Count - 1


                            Me.Invoke(Sub() addattachaments(Item.Attachments.Item(j).Name, Item.Attachments.Item(j).Id.ToString))


                        Next
                    End If

                    ' Dim filetosearch2 As String = searchfolders(folder) & "\anexos" & ExtractNumber(internentmessageid) & ".txt"

                    '  If IO.File.Exists(filetosearch2) = False Then
                    'Dim fs1 As IO.FileStream = New IO.FileStream(filetosearch2, IO.FileMode.Create)
                    '  fs1.Close()
                    ' Me.Invoke(Sub() SaveGridDataInFile(filetosearch2, MetroGrid1))
                    For Each x1 As DataGridViewRow In EmailReader1.ListView1.Rows
                        newemail.anexos.Add(x1.Cells(0).Value.ToString)
                        newemail.anexosid.Add(x1.Cells(0).Value.ToString)

                    Next
                    Me.Invoke(Sub() MetroGrid1.Rows.Clear())
                    'End If
                    newemail.De = mfrom
                    newemail.Assunto = subject
                    newemail.idmessage = internentmessageid
                    newemail.CC = cc
                    newemail.Html = messagebody
                    newemail.Para = displayto
                    newemail.read = Item.IsRead
                    newemail.hasatt = Item.HasAttachments
                    newemail.data = Item.DateTimeReceived
                    Dim foldername As Microsoft.Exchange.WebServices.Data.Folder = Microsoft.Exchange.WebServices.Data.Folder.Bind(service, Item.ParentFolderId)
                    newemail.folder = foldername.DisplayName
                    For Each x5 As FolderEmail In account.folders(0).items
                        If x5.name.ToLower.Contains(newemail.folder.ToLower) Then
                            x5.emails.emails.Add(newemail)
                        End If
                    Next
                    If BackgroundWorker2.CancellationPending = True Then
                        Exit Sub
                    End If
                    If ArboScrollableListBox2.Items.Count < 900 Then
                        Dim c As New ListControlItem
                        c.from = mfrom
                        c.displayto = displayto
                        c.Duration = datatimereceived
                        c.idmessage = internentmessageid
                        c.subject = subject
                        c.PictureBox1.Visible = Item.HasAttachments
                        If Item.IsRead = False Then
                            c.Panel1.BackColor = Color.Maroon
                        End If
                        AddHandler c.SelectionChanged, AddressOf ListControl1.SelectionChanged
                        AddHandler c.Click, AddressOf ListControl1.ItemClicked
                        AddHandler c.CheckBox1.CheckedChanged, AddressOf checkchange
                        Me.Invoke(Sub() reloadlistcontrol(c))
                        Me.Invoke(Sub() ArboScrollableListBox2.Update())
                    End If
                End If
            Next

        Catch ex As ServiceRequestException

        Catch ex As Exception
            Me.Invoke(Sub() EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString))

            ' MetroMessageBox.Show(Me, ex.StackTrace & "," & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function readfile(ByVal value As String, ByVal patch As String) As String

        Try

            Dim counter As Integer = 0
            Dim valuestring As String = ""
            ' Dim line As String

            ' Read the file and display it line by line.
            Dim file As New System.IO.StreamReader(patch)
            Do

                Dim line As String = file.ReadLine()
                If line Is Nothing Then Exit Do
                If line.Contains(value) Then
                    valuestring = After(line, "=")
                End If

            Loop


            file.Close()

            Return valuestring
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
            Return ""


            '  MetroMessageBox.Show(Me, ex.StackTrace & "," & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function
    Public Sub replacevaluefile(ByVal file As String, ByVal lastvalue As String, ByVal newvalue As String)
        Try
            Dim text As String = IO.File.ReadAllText(file)
            text = text.Replace(lastvalue, newvalue)
            IO.File.WriteAllText(file, text)
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '  MetroMessageBox.Show(Me, ex.StackTrace & "," & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function readalltext(ByVal file As String) As String
        Try
            Dim text1 As String = IO.File.ReadAllText(file)
            Return text1

        Catch ex As Exception
            Return ""
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '  MetroMessageBox.Show(Me, ex.StackTrace & "," & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Public Shared Function After(value As String, a As String) As String
        Try
            Dim posA As Integer = value.LastIndexOf(a)
            If posA = -1 Then
                Return ""
            End If
            Dim adjustedPosA As Integer = posA + a.Length
            If adjustedPosA >= value.Length Then
                Return ""
            End If
            Return value.Substring(adjustedPosA)
        Catch ex As Exception
            Return ""
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '  MetroMessageBox.Show(Me, ex.StackTrace & "," & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function



    Public Function ExtractNumber(original As String) As String
        Return New String(original.Where(Function(c) [Char].IsDigit(c)).ToArray())
    End Function











    Public Function findfolders44() As FolderId
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text
        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")

        Try
            Application.DoEvents()
            Threading.Thread.Sleep(1)
            Application.DoEvents()
            Threading.Thread.Sleep(1)
            selectfolder = Label2.Text

            Dim allFoldersType As ExtendedPropertyDefinition = New ExtendedPropertyDefinition(13825, MapiPropertyType.Integer)
            Dim rootFolderId As FolderId = New FolderId(WellKnownFolderName.Root)
            Dim folderView As FolderView = New FolderView(1000)
            folderView.Traversal = FolderTraversal.Deep
            Dim searchFilter2 As SearchFilter = New SearchFilter.IsEqualTo(FolderSchema.DisplayName, selectfolder)
            Dim searchFilterCollection As SearchFilter.SearchFilterCollection = New SearchFilter.SearchFilterCollection(LogicalOperator.And)
            searchFilterCollection.Add(searchFilter2)

            Dim findFoldersResults As FindFoldersResults = service.FindFolders(rootFolderId, searchFilterCollection, folderView)
            If findFoldersResults.Folders.Count > 0 Then
                Dim allItemsFolder As Folder = findFoldersResults.Folders(0)
                Return allItemsFolder.Id
            End If


        Catch ex As ServiceRequestException

            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
            Return Nothing
            '   MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
            Return Nothing
            '   MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Function
    Public Function findfolders45() As FolderId
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text
        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")

        Try

            If NaviMain3.treeView1.SelectedNode IsNot Nothing Then
                selectfolder = NaviMain3.treeView1.SelectedNode.Text
            Else
                selectfolder = Label2.Text
            End If
            '   If selectfolder = Nothing Or selectfolder = "Caixa De Entrada" Then
            'Return WellKnownFolderName.Inbox
            '  Exit Function
            '  End If

            Dim allFoldersType As ExtendedPropertyDefinition = New ExtendedPropertyDefinition(13825, MapiPropertyType.Integer)
            Dim rootFolderId As FolderId = New FolderId(WellKnownFolderName.Root)
            Dim folderView As FolderView = New FolderView(1000)
            folderView.Traversal = FolderTraversal.Deep
            Dim searchFilter2 As SearchFilter = New SearchFilter.IsEqualTo(FolderSchema.DisplayName, selectfolder)
            Dim searchFilterCollection As SearchFilter.SearchFilterCollection = New SearchFilter.SearchFilterCollection(LogicalOperator.And)
            searchFilterCollection.Add(searchFilter2)

            Dim findFoldersResults As FindFoldersResults = service.FindFolders(rootFolderId, searchFilterCollection, folderView)

            If findFoldersResults.Folders.Count > 0 Then
                Dim allItemsFolder As Folder = findFoldersResults.Folders(0)
                Return allItemsFolder.Id
            End If


        Catch ex As ServiceRequestException
            Return ""
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            'MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            Return ""
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '   MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Function
    Public Function findfolders45(ByVal namefolder As String) As FolderId
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text
        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")

        Try



            Dim allFoldersType As ExtendedPropertyDefinition = New ExtendedPropertyDefinition(13825, MapiPropertyType.Integer)
            Dim rootFolderId As FolderId = New FolderId(WellKnownFolderName.Root)
            Dim folderView As FolderView = New FolderView(1000)
            folderView.Traversal = FolderTraversal.Deep
            Dim searchFilter2 As SearchFilter = New SearchFilter.IsEqualTo(FolderSchema.DisplayName, namefolder)
            Dim searchFilterCollection As SearchFilter.SearchFilterCollection = New SearchFilter.SearchFilterCollection(LogicalOperator.And)
            searchFilterCollection.Add(searchFilter2)

            Dim findFoldersResults As FindFoldersResults = service.FindFolders(rootFolderId, searchFilterCollection, folderView)

            If findFoldersResults.Folders.Count > 0 Then
                Dim allItemsFolder As Folder = findFoldersResults.Folders(0)
                Return allItemsFolder.Id
            End If


        Catch ex As ServiceRequestException

            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '  MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '  MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Function
    Public Sub Responder()
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text



        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try
            ' TimeDelay()
            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders45, New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, itemmail), New ItemView(5))
            For Each message As Item In foundItems
                message.Load()
                message.Body.BodyType = BodyType.HTML
                Dim test As String = message.DisplayTo.ToString
                Dim senderEmail As String = CType(message, EmailMessage).From.Address
                Form2.RichTextBox2.AppendText(senderEmail & Space(2))
                If message.Subject <> "" Then
                    Form2.RichTextBox4.Text = "RES:" & message.Subject
                End If
                If EmailReader1.WebBrowser1.Document.Body.InnerHtml <> "" Then
                    htmlbody = EmailReader1.WebBrowser1.Document.Body.InnerHtml
                Else
                    htmlbody = message.Body
                End If
                TimeDelay()
            Next
            If account.assinatura IsNot Nothing And account.assinatura <> "" Then
                Dim Path As String = Application.StartupPath & "\" & account.assinatura
                Form2.Editor1.webBrowser1.Document.Body.InnerHtml = "<html><br><br><br><br><br><br><br><html/>" & "<img src='" & Path & "' />" & "<html><br><br><br><html/>" & htmlbody
            Else
                Form2.Editor1.webBrowser1.Document.Body.InnerHtml = "<html><br><br><br><html/>" & htmlbody
            End If



        Catch ex As ServiceRequestException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Public Sub Responder(ByVal form As Form2)
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text



        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try
            ' TimeDelay()
            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders45, New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, itemmail), New ItemView(5))
            For Each message As Item In foundItems
                message.Load()
                message.Body.BodyType = BodyType.HTML
                Dim test As String = message.DisplayTo.ToString
                Dim senderEmail As String = CType(message, EmailMessage).From.Address
                form.RichTextBox2.AppendText(senderEmail & Space(2))
                If message.Subject <> "" Then
                    form.RichTextBox4.Text = "RES:" & message.Subject
                End If
                If EmailReader1.WebBrowser1.Document.Body.InnerHtml <> "" Then
                    htmlbody = EmailReader1.WebBrowser1.Document.Body.InnerHtml
                Else
                    htmlbody = message.Body
                End If
                TimeDelay()
            Next
            If account.assinatura IsNot Nothing And account.assinatura <> "" Then
                Dim Path As String = Application.StartupPath & "\" & account.assinatura
                form.Editor1.webBrowser1.Document.Body.InnerHtml = "<html><br><br><br><br><br><br><br><html/>" & "<img src='" & Path & "' />" & "<html><br><br><br><html/>" & htmlbody
            Else
                form.Editor1.webBrowser1.Document.Body.InnerHtml = "<html><br><br><br><html/>" & htmlbody
            End If




        Catch ex As ServiceRequestException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Public Function ConvertHtmlToImage(ByVal html As String) As Image
        Try
            Return TheArtOfDev.HtmlRenderer.WinForms.HtmlRender.RenderToImage(html)

        Catch ex As WebException

            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ImageList1.Images(0)
        End Try
    End Function
    Public Sub Excluiremail()
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text



        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try
            Application.DoEvents()
            Threading.Thread.Sleep(1)

            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders44, New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, itemmail), New ItemView(5))

            For Each message As Item In foundItems
                Dim result As Integer = MessageBox.Show("Voce Tem Certeza que deseja deletar este item?", "Deletar Item Para Itens Excluidos", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then






                    Exit Sub
                ElseIf result = DialogResult.Yes Then
                    Dim th As New Threading.Thread(Sub() startpwidnows("Excluindo Email..."))
                    th.TrySetApartmentState(Threading.ApartmentState.STA)
                    th.Start()



                    message.Delete(DeleteMode.MoveToDeletedItems)
                    Dim c As ListControlItem = TryCast(ArboScrollableListBox2.Items(indexitem), ListControlItem)
                    ArboScrollableListBox2.BeginUpdate()
                    ArboScrollableListBox2.Remove(c)
                    ' remove the event hook
                    RemoveHandler c.SelectionChanged, AddressOf ArboScrollableListBox2_oncontrolselect
                    RemoveHandler c.DoubleClick, AddressOf ArboScrollableListBox2_doubleclick
                    ' now dispose off properly
                    c.Dispose()
                    ArboScrollableListBox2.EndUpdate()

                    th.Abort()


                    For Each x5 As FolderEmail In account.folders(0).items
                        If x5.name.ToLower.Contains(Label2.Text.ToLower) Then
                            For Each m1 As Email In x5.emails.emails
                                If m1.idmessage.ToLower.Contains(itemmail.ToLower) Then
                                    deletefromfolderaccount(m1, Label2.Text)
                                    save()
                                End If
                            Next


                        End If

                    Next

                End If

            Next


        Catch ex As ServiceRequestException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub saveemailstodraft()
        Try




            user = TextBox1.Text
            pass = TextBox2.Text
            server = TextBox3.Text

            Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
            service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
            service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")

            Dim s As String = Form2.RichTextBox2.Text
            Dim s1 As String = Form2.RichTextBox3.Text
            ' Split string based on spaces
            Dim words As String() = s.Split(New Char() {" "c})
            Dim words1 As String() = s1.Split(New Char() {" "c})
            ' Use For Each loop over words and display them
            Dim word As String
            Dim word1 As String
            'Create message in the Drafts folder          
            Dim message As New EmailMessage(service)
            message.Subject = Form2.RichTextBox4.Text
            message.Body = New MessageBody(BodyType.HTML, Form2.Editor1.DocumentText)
            Dim list1 As New List(Of String)
            For Each img As HtmlElement In Form2.Editor1.webBrowser1.Document.Images
                Dim filename As String = Between(After(img.OuterHtml, "src="), """", """")
                list1.Add(filename)

                '   newatt.Load(filename)
                '   message.Update(ConflictResolutionMode.AlwaysOverwrite)
                ' Form2.Editor1.webBrowser1.Document.Body.InnerHtml = Form2.Editor1.webBrowser1.Document.Body.InnerHtml.Replace(filename, "Cid:" & IO.Path.GetFileName(filename))
            Next
            Form2.prepare()
            If s <> "" Then
                For Each word In words
                    If word.Contains("@") Then
                        message.ToRecipients.Add(word)
                        createfile(word)
                    End If
                Next
            End If
            If s1 <> "" Then
                For Each word1 In words1
                    If word1.Contains("@") Then
                        message.CcRecipients.Add(word1)
                        createfile(word1)
                    End If
                Next

            End If
            For l_index As Integer = 0 To Form2.ListBox2.Items.Count - 1
                Dim l_text As String = CStr(Form2.ListBox2.Items(l_index).ToString)
                message.Attachments.AddFileAttachment(l_text)


            Next
            For Each x1 As String In list1
                Dim x2 As String = After(x1, "file:///")
                If x2 <> "" Then
                    x1 = x2
                End If
                If IO.File.Exists(x1) Then
                    Dim newatt As FileAttachment = message.Attachments.AddFileAttachment(x1)
                    newatt.IsInline = True
                    newatt.ContentId = IO.Path.GetFileName(x1)
                    TimeDelay()
                    Form2.Refresh()
                Else
                    If account.assinatura IsNot Nothing And x1.Contains(account.assinatura) Then
                        Dim newatt As FileAttachment = message.Attachments.AddFileAttachment(Application.StartupPath & "\" & account.assinatura)
                        newatt.IsInline = True
                        newatt.ContentId = IO.Path.GetFileName(Application.StartupPath & "\" & account.assinatura)
                        TimeDelay()
                        Form2.Refresh()
                    End If
                End If
            Next

            'Send message 
            message.Save(WellKnownFolderName.Drafts)


        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub
    Public Shared Function Between(value As String, a As String, b As String) As String
        Dim posA As Integer = value.IndexOf(a)
        Dim posB As Integer = value.LastIndexOf(b)
        If posA = -1 Then
            Return ""
        End If
        If posB = -1 Then
            Return ""
        End If
        Dim adjustedPosA As Integer = posA + a.Length
        If adjustedPosA >= posB Then
            Return ""
        End If
        Return value.Substring(adjustedPosA, posB - adjustedPosA)
    End Function

    Public Sub DeleteItem()
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text



        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try
      

            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders44, New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, itemmail), New ItemView(5))

            For Each message As Item In foundItems

                message.Delete(DeleteMode.MoveToDeletedItems)


            Next


        Catch ex As ServiceRequestException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)


        End Try
    End Sub
    Public Sub DeleteHardItem()
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text



        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try
   

            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders44, New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, itemmail), New ItemView(5))

            For Each message As Item In foundItems

                message.Delete(DeleteMode.HardDelete)


            Next


        Catch ex As ServiceRequestException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)


        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

        End Try
    End Sub
    Public Sub savemsg()
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text



        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try
            Application.DoEvents()
            Threading.Thread.Sleep(1)

            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders44, New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, itemmail), New ItemView(5))

            For Each message As Item In foundItems
                message.Load(New PropertySet(ItemSchema.MimeContent))
                Dim mc As MimeContent = message.MimeContent
                Dim fs As IO.FileStream = New IO.FileStream(TextBox6.Text & ".eml", IO.FileMode.Create)
                fs.Write(mc.Content, 0, mc.Content.Length)
                fs.Close()

            Next


        Catch ex As ServiceRequestException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub DeleteEmail()
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text



        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try


            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders44, New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, itemmail), New ItemView(5))

            For Each message As Item In foundItems
                Dim result As Integer = MessageBox.Show("Voce Tem Certeza que deseja deletar este item?", "Deletar Item Permanentemente", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then






                    Exit Sub
                ElseIf result = DialogResult.Yes Then
                    Dim th As New Threading.Thread(Sub() startpwidnows("Deletando Email..."))
                    th.TrySetApartmentState(Threading.ApartmentState.STA)
                    th.Start()



                    message.Delete(DeleteMode.HardDelete)
                    Dim c As ListControlItem = TryCast(ArboScrollableListBox2.Items(indexitem), ListControlItem)
                    ArboScrollableListBox2.BeginUpdate()
                    ArboScrollableListBox2.Remove(c)
                    ' remove the event hook
                    RemoveHandler c.SelectionChanged, AddressOf ArboScrollableListBox2_oncontrolselect
                    RemoveHandler c.DoubleClick, AddressOf ArboScrollableListBox2_doubleclick
                    ' now dispose off properly
                    c.Dispose()
                    ArboScrollableListBox2.EndUpdate()
                    th.Abort()

                    For Each x5 As FolderEmail In account.folders(0).items
                        If x5.name.ToLower.Contains(Label2.Text.ToLower) Then
                            For Each m1 As Email In x5.emails.emails
                                If m1.idmessage.ToLower.Contains(itemmail.ToLower) Then
                                    deletefromfolderaccount(m1, Label2.Text)
                                    save()
                                End If
                            Next


                        End If

                    Next

                End If

            Next


        Catch ex As ServiceRequestException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Responderatodos()
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text



        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")

        Try
            Application.DoEvents()
            Threading.Thread.Sleep(1)

            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders44, New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, itemmail), New ItemView(5))

            For Each message As Item In foundItems
                message.Load()
                message.Body.BodyType = BodyType.HTML

                Dim test As String = message.DisplayTo.ToString
                Dim senderEmail As String = CType(message, EmailMessage).From.Address
                Dim recp2 As Integer = CType(message, EmailMessage).ToRecipients.Count
                For l As Integer = 0 To recp2 - 1
                    Dim recpEmail As String = CType(message, EmailMessage).ToRecipients.Item(l).Address
                    If recpEmail.IndexOf(TextBox1.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                    Else
                        Form2.RichTextBox2.AppendText(recpEmail & Space(2))
                    End If
                Next

                Form2.RichTextBox2.AppendText(senderEmail & Space(2))
                Dim recp3 As Integer = CType(message, EmailMessage).CcRecipients.Count
                For l As Integer = 0 To recp3 - 1
                    Dim recpEmail1 As String = CType(message, EmailMessage).CcRecipients.Item(l).Address
                    If recpEmail1.IndexOf(TextBox1.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                    Else
                        Form2.RichTextBox3.AppendText(recpEmail1 & Space(2))
                    End If
                Next

                If message.Subject <> "" Then
                    Form2.RichTextBox4.Text = "RES:" & message.Subject
                End If

                If EmailReader1.WebBrowser1.Document.Body.InnerHtml <> "" Then
                    htmlbody = EmailReader1.WebBrowser1.Document.Body.InnerHtml
                Else
                    htmlbody = message.Body
                End If
                ' If msgFile.BodyHtmlText = Nothing Then
                Application.DoEvents()
                Threading.Thread.Sleep(1)
                'Dim s As String = ToHtml(message2.BodyPlainText, False)

                'htmlbody = s

                'End If
                If account.assinatura IsNot Nothing And account.assinatura <> "" Then
                    Dim Path As String = Application.StartupPath & "\" & account.assinatura
                    Form2.Editor1.webBrowser1.Document.Body.InnerHtml = "<html><br><br><br><br><br><br><br><html/>" & "<img src='" & Path & "' />" & "<html><br><br><br><html/>" & htmlbody
                Else
                    Form2.Editor1.webBrowser1.Document.Body.InnerHtml = "<html><br><br><br><html/>" & htmlbody
                End If

            Next


        Catch ex As ServiceRequestException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub Responderatodos(ByVal form As Form2)
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text



        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")

        Try
            Application.DoEvents()
            Threading.Thread.Sleep(1)

            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders44, New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, itemmail), New ItemView(5))

            For Each message As Item In foundItems
                message.Load()
                message.Body.BodyType = BodyType.HTML

                Dim test As String = message.DisplayTo.ToString
                Dim senderEmail As String = CType(message, EmailMessage).From.Address
                Dim recp2 As Integer = CType(message, EmailMessage).ToRecipients.Count
                For l As Integer = 0 To recp2 - 1
                    Dim recpEmail As String = CType(message, EmailMessage).ToRecipients.Item(l).Address
                    If recpEmail.IndexOf(TextBox1.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                    Else
                        form.RichTextBox2.AppendText(recpEmail & Space(2))
                    End If
                Next

                form.RichTextBox2.AppendText(senderEmail & Space(2))
                Dim recp3 As Integer = CType(message, EmailMessage).CcRecipients.Count
                For l As Integer = 0 To recp3 - 1
                    Dim recpEmail1 As String = CType(message, EmailMessage).CcRecipients.Item(l).Address
                    If recpEmail1.IndexOf(TextBox1.Text, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                    Else
                        form.RichTextBox3.AppendText(recpEmail1 & Space(2))
                    End If
                Next

                If message.Subject <> "" Then
                    form.RichTextBox4.Text = "RES:" & message.Subject
                End If

                If EmailReader1.WebBrowser1.Document.Body.InnerHtml <> "" Then
                    htmlbody = EmailReader1.WebBrowser1.Document.Body.InnerHtml
                Else
                    htmlbody = message.Body
                End If
                ' If msgFile.BodyHtmlText = Nothing Then
                Application.DoEvents()
                Threading.Thread.Sleep(1)
                'Dim s As String = ToHtml(message2.BodyPlainText, False)

                'htmlbody = s

                'End If
                If account.assinatura IsNot Nothing And account.assinatura <> "" Then
                    Dim Path As String = Application.StartupPath & "\" & account.assinatura
                    form.Editor1.webBrowser1.Document.Body.InnerHtml = "<html><br><br><br><br><br><br><br><html/>" & "<img src='" & Path & "' />" & "<html><br><br><br><html/>" & htmlbody
                Else
                    form.Editor1.webBrowser1.Document.Body.InnerHtml = "<html><br><br><br><html/>" & htmlbody
                End If
            Next


        Catch ex As ServiceRequestException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub EncaminharEmail()
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text



        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try
            Application.DoEvents()
            Threading.Thread.Sleep(1)

            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders44, New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, itemmail), New ItemView(5))

            For Each message As Item In foundItems
                message.Load()
                message.Body.BodyType = BodyType.HTML

                If message.Subject <> "" Then
                    Form2.RichTextBox4.Text = "ENC:" & message.Subject
                End If

                If EmailReader1.WebBrowser1.Document.Body.InnerHtml <> "" Then
                    htmlbody = EmailReader1.WebBrowser1.Document.Body.InnerHtml
                Else
                    htmlbody = message.Body
                End If
                ' If msgFile.BodyHtmlText = Nothing Then
                Application.DoEvents()
                Threading.Thread.Sleep(1)
                'Dim s As String = ToHtml(message2.BodyPlainText, False)

                'htmlbody = s

                'End If


                Dim htmlbefore As String = "<html><br>" & "De:" & EmailReader1.FromEmail.Text & "<br>" & "Para:" & EmailReader1.DisplayTo.Text & "<br>" & "CC:" & EmailReader1.CC.Text & "<br>" _
               & "Assunto:" & EmailReader1.Subject.Text & "<br>" & "Enviada em:" & EmailReader1.Enviadaem.Text & "<html/>" & "<html><br><br><br><html/>"
                If account.assinatura IsNot Nothing And account.assinatura <> "" Then
                    Dim Path As String = Application.StartupPath & "\" & account.assinatura
                    Form2.Editor1.webBrowser1.Document.Body.InnerHtml = "<html><br><br><br><br><br><br><br><html/>" & "<img src='" & Path & "' />" & "<html><br><br><br><html/>" & htmlbefore & "<html><br><br><br><html/>" & htmlbody
                Else
                    Form2.Editor1.webBrowser1.Document.Body.InnerHtml = "<html><br><br><br><html/>" & htmlbefore & "<html><br><br><br><html/>" & htmlbody
                End If

                If message.Attachments.Count = 0 Then
                    RichTextBox1.Text = message.Body



                Else
                    For j As Integer = 0 To message.Attachments.Count - 1
                        Dim fileAttachment As FileAttachment = CType(message.Attachments(j), FileAttachment)
                        fileAttachment.Load()


                        Application.DoEvents()
                        Threading.Thread.Sleep(1)
                        If fileAttachment.IsInline = False Then
                            Form2.RichTextBox5.AppendText(Space(2) + fileAttachment.Name)
                        Else
                            Form2.attsinline.Add(fileAttachment.Name)
                        End If
                        anexo = fileAttachment.Id
                        Application.DoEvents()
                        Threading.Thread.Sleep(1)
                        saveatt(fileAttachment.Name, fileAttachment)
                        Form2.ListBox2.Items.Add(IO.Path.GetTempPath & fileAttachment.Name)

                    Next
                End If
                'End If
            Next


        Catch ex As ServiceRequestException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub EncaminharEmail(ByVal form As Form2)
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text



        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try
            Application.DoEvents()
            Threading.Thread.Sleep(1)

            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders44, New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, itemmail), New ItemView(5))

            For Each message As Item In foundItems
                message.Load()
                message.Body.BodyType = BodyType.HTML

                If message.Subject <> "" Then
                    form.RichTextBox4.Text = "ENC:" & message.Subject
                End If

                If EmailReader1.WebBrowser1.Document.Body.InnerHtml <> "" Then
                    htmlbody = EmailReader1.WebBrowser1.Document.Body.InnerHtml
                Else
                    htmlbody = message.Body
                End If
                ' If msgFile.BodyHtmlText = Nothing Then
                Application.DoEvents()
                Threading.Thread.Sleep(1)
                'Dim s As String = ToHtml(message2.BodyPlainText, False)

                'htmlbody = s

                'End If
                Dim htmlbefore As String = "<html><br>" & "De:" & EmailReader1.FromEmail.Text & "<br>" & "Para:" & EmailReader1.DisplayTo.Text & "<br>" & "CC:" & EmailReader1.CC.Text & "<br>" _
                & "Assunto:" & EmailReader1.Subject.Text & "<br>" & "Enviada em:" & EmailReader1.Enviadaem.Text & "<html/>" & "<html><br><br><br><html/>"
                If account.assinatura IsNot Nothing And account.assinatura <> "" Then
                    Dim Path As String = Application.StartupPath & "\" & account.assinatura
                    form.Editor1.webBrowser1.Document.Body.InnerHtml = "<html><br><br><br><br><br><br><br><html/>" & "<img src='" & Path & "' />" & "<html><br><br><br><html/>" & htmlbefore & "<html><br><br><br><html/>" & htmlbody
                Else
                    form.Editor1.webBrowser1.Document.Body.InnerHtml = "<html><br><br><br><html/>" & htmlbefore & "<html><br><br><br><html/>" & htmlbody
                End If
                If message.Attachments.Count = 0 Then
                    RichTextBox1.Text = message.Body



                Else
                    For j As Integer = 0 To message.Attachments.Count - 1
                        Dim fileAttachment As FileAttachment = CType(message.Attachments(j), FileAttachment)
                        fileAttachment.Load()


                        Application.DoEvents()
                        Threading.Thread.Sleep(1)
                        If fileAttachment.IsInline = False Then
                            form.RichTextBox5.AppendText(Space(2) + fileAttachment.Name)
                        Else
                            form.attsinline.Add(fileAttachment.Name)
                        End If
                        anexo = fileAttachment.Id
                        Application.DoEvents()
                        Threading.Thread.Sleep(1)
                        saveatt(fileAttachment.Name, fileAttachment)
                        form.ListBox2.Items.Add(IO.Path.GetTempPath & fileAttachment.Name)

                    Next
                End If
                'End If
            Next


        Catch ex As ServiceRequestException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub seacrhmsgbysubject44()


        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text
        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try
            Application.DoEvents()
            Threading.Thread.Sleep(1)


            Dim mfrom As String = ""
            Dim mfromadress As String = ""
            Dim subject As String = ""
            Dim displayto As String = ""
            Dim datatimereceived As String = ""
            Dim internentmessageid As String = ""
            Dim messagebody As String = ""

            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders44, New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, itemmail), New ItemView(5))


            For Each message As Item In foundItems
                TimeDelay()
                Dim item As EmailMessage = TryCast(message, EmailMessage)


                message.Load()

                message.Body.BodyType = BodyType.HTML


                If message.Body Is Nothing Then
                    message.Body.BodyType = BodyType.Text
                End If
                Dim cc As String = ""
                If message.DisplayCc <> "" Then
                    cc = message.DisplayCc
                Else
                    cc = ""
                End If

                Application.DoEvents()
                Threading.Thread.Sleep(1)
                RichTextBox1.Text = message.Body
                Dim displayadress As String = ""
                Dim recp2 As Integer = CType(message, EmailMessage).ToRecipients.Count
                For l As Integer = 0 To recp2 - 1
                    Dim recpEmail2 As String = CType(message, EmailMessage).ToRecipients.Item(l).Address
                    displayadress = displayadress + recpEmail2 + Space(2)
                Next
                TimeDelay()
                MetroToolTip2.SetToolTip(EmailReader1.DisplayTo, displayadress)
                Dim ccadress As String = ""
                Dim recp3 As Integer = CType(message, EmailMessage).CcRecipients.Count
                For l As Integer = 0 To recp3 - 1
                    Dim recpEmail1 As String = CType(message, EmailMessage).CcRecipients.Item(l).Address
                    ccadress = ccadress + recpEmail1 + Space(2)
                Next
                If ccadress <> "" Then


                    MetroToolTip1.SetToolTip(EmailReader1.CC, ccadress)
                End If
                If item.From IsNot Nothing Then
                    mfrom = item.From.Name
                    mfromadress = item.From.Address

                Else
                    mfrom = ""
                    mfromadress = ""
                End If
                If item.Subject IsNot Nothing Then
                    subject = item.Subject
                Else
                    subject = ""
                End If
                If item.DisplayTo IsNot Nothing Then
                    displayto = item.DisplayTo
                Else
                    displayto = ""
                End If
                If item.DateTimeReceived.ToString IsNot Nothing Then
                    datatimereceived = item.DateTimeReceived.ToString
                Else
                    datatimereceived = ""
                End If
                If item.InternetMessageId IsNot Nothing Then
                    internentmessageid = item.InternetMessageId



                Else
                    internentmessageid = ""
                End If
                EmailReader1.read(datatimereceived, mfrom & Space(2) & "< " & mfromadress & ">", subject, displayto, cc, Nothing, item.HasAttachments)
                TimeDelay()

                messagebody = message.Body
                For Each f1 As FolderEmail In account.folders(0).items
                    If f1.name.ToLower.Contains(Label2.Text.ToLower) Then
                        For Each m1 As Email In f1.emails.emails
                            If m1.idmessage.ToLower.Contains(internentmessageid.ToLower) Then
                                m1.CC = cc
                                m1.Html = messagebody
                                save()
                            End If
                        Next
                    End If
                Next


                For j As Integer = 0 To message.Attachments.Count - 1

                    TimeDelay()
                    Dim fileAttachment As FileAttachment = CType(message.Attachments(j), FileAttachment)

                    addattachaments(fileAttachment.Name, fileAttachment.Id)

                    TimeDelay()
                    For Each f1 As FolderEmail In account.folders(0).items
                        If f1.name.ToLower.Contains(Label2.Text.ToLower) Then
                            For Each m1 As Email In f1.emails.emails
                                If m1.idmessage.ToLower.Contains(internentmessageid.ToLower) Then
                                    m1.anexos.Add(fileAttachment.Name)
                                    m1.anexosid.Add(fileAttachment.Id)
                                End If
                            Next

                        End If
                    Next

                Next
                Application.DoEvents()
                Threading.Thread.Sleep(1)

            Next
            service.LoadPropertiesForItems(foundItems, New PropertySet(MeetingMessageSchema.IsRead))
            Application.DoEvents()
            Threading.Thread.Sleep(1)
            For Each message2 As EmailMessage In foundItems
                message2.Load(New PropertySet({EmailMessageSchema.IsRead}))
                If message2.IsRead = False Then
                    message2.IsRead = True
                    message2.Update(ConflictResolutionMode.AlwaysOverwrite)


                End If
                Application.DoEvents()
                Threading.Thread.Sleep(1)



            Next



            htmlbody = RichTextBox1.Text
            If htmlbody <> Nothing Then
                WebBrowser1.DocumentText = htmlbody
                EmailReader1.bodyhtml(htmlbody)
            Else
                htmlbody = "<html>" & "No Message Found" & "<Html/>"
                WebBrowser1.DocumentText = htmlbody
                EmailReader1.bodyhtml(htmlbody)
            End If


            Dim c As ListControlItem = TryCast(ArboScrollableListBox2.Items(indexitem), ListControlItem)
            c.Panel1.BackColor = Color.DarkBlue




        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub seacrhmsgbysubject45(ByVal messageid As String)


        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text
        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try
            Application.DoEvents()
            Threading.Thread.Sleep(1)


            Dim mfrom As String = ""
            Dim mfromadress As String = ""
            Dim subject As String = ""
            Dim displayto As String = ""
            Dim datatimereceived As String = ""
            Dim internentmessageid As String = ""
            Dim messagebody As String = ""

            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders44, New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, messageid), New ItemView(5))


            For Each message As Item In foundItems
                TimeDelay()
                Dim item As EmailMessage = TryCast(message, EmailMessage)


                message.Load()

                message.Body.BodyType = BodyType.HTML


                If message.Body Is Nothing Then
                    message.Body.BodyType = BodyType.Text
                End If
                Dim cc As String = ""
                If message.DisplayCc <> "" Then
                    cc = message.DisplayCc
                Else
                    cc = ""
                End If

                Application.DoEvents()
                Threading.Thread.Sleep(1)
                RichTextBox1.Text = message.Body
                Dim displayadress As String = ""
                Dim recp2 As Integer = CType(message, EmailMessage).ToRecipients.Count
                For l As Integer = 0 To recp2 - 1
                    Dim recpEmail2 As String = CType(message, EmailMessage).ToRecipients.Item(l).Address
                    displayadress = displayadress + recpEmail2 + Space(2)
                Next
                TimeDelay()
                MetroToolTip2.SetToolTip(EmailReader1.DisplayTo, displayadress)
                Dim ccadress As String = ""
                Dim recp3 As Integer = CType(message, EmailMessage).CcRecipients.Count
                For l As Integer = 0 To recp3 - 1
                    Dim recpEmail1 As String = CType(message, EmailMessage).CcRecipients.Item(l).Address
                    ccadress = ccadress + recpEmail1 + Space(2)
                Next
                If ccadress <> "" Then


                    MetroToolTip1.SetToolTip(EmailReader1.CC, ccadress)
                End If
                If item.From IsNot Nothing Then
                    mfrom = item.From.Name
                    mfromadress = item.From.Address

                Else
                    mfrom = ""
                    mfromadress = ""
                End If
                If item.Subject IsNot Nothing Then
                    subject = item.Subject
                Else
                    subject = ""
                End If
                If item.DisplayTo IsNot Nothing Then
                    displayto = item.DisplayTo
                Else
                    displayto = ""
                End If
                If item.DateTimeReceived.ToString IsNot Nothing Then
                    datatimereceived = item.DateTimeReceived.ToString
                Else
                    datatimereceived = ""
                End If
                If item.InternetMessageId IsNot Nothing Then
                    internentmessageid = item.InternetMessageId



                Else
                    internentmessageid = ""
                End If
                EmailReader1.read(datatimereceived, mfrom & Space(2) & "< " & mfromadress & ">", subject, displayto, cc, Nothing, item.HasAttachments)
                TimeDelay()

                messagebody = message.Body
                For Each f1 As FolderEmail In account.folders(0).items
                    If f1.name.ToLower.Contains(Label2.Text.ToLower) Then
                        For Each m1 As Email In f1.emails.emails
                            If m1.idmessage.ToLower.Contains(internentmessageid.ToLower) Then
                                m1.Html = messagebody
                                save()
                            End If
                        Next
                    End If
                Next


                For j As Integer = 0 To message.Attachments.Count - 1

                    TimeDelay()
                    Dim fileAttachment As FileAttachment = CType(message.Attachments(j), FileAttachment)

                    addattachaments(fileAttachment.Name, fileAttachment.Id)

                    TimeDelay()
                    For Each f1 As FolderEmail In account.folders(0).items
                        If f1.name.ToLower.Contains(Label2.Text.ToLower) Then
                            For Each m1 As Email In f1.emails.emails
                                If m1.idmessage.ToLower.Contains(internentmessageid.ToLower) Then
                                    m1.anexos.Add(fileAttachment.Name)
                                    m1.anexosid.Add(fileAttachment.Id)
                                End If
                            Next

                        End If
                    Next

                Next
                Application.DoEvents()
                Threading.Thread.Sleep(1)

            Next
            service.LoadPropertiesForItems(foundItems, New PropertySet(MeetingMessageSchema.IsRead))
            Application.DoEvents()
            Threading.Thread.Sleep(1)
            For Each message2 As EmailMessage In foundItems
                message2.Load(New PropertySet({EmailMessageSchema.IsRead}))
                If message2.IsRead = False Then
                    message2.IsRead = True
                    message2.Update(ConflictResolutionMode.AlwaysOverwrite)


                End If
                Application.DoEvents()
                Threading.Thread.Sleep(1)



            Next



            htmlbody = RichTextBox1.Text
            If htmlbody <> Nothing Then
                WebBrowser1.DocumentText = htmlbody
                EmailReader1.bodyhtml(htmlbody)
            Else
                htmlbody = "<html>" & "No Message Found" & "<Html/>"
                WebBrowser1.DocumentText = htmlbody
                EmailReader1.bodyhtml(htmlbody)
            End If


            Dim c As ListControlItem = TryCast(ArboScrollableListBox2.Items(indexitem), ListControlItem)
            c.Panel1.BackColor = Color.DarkBlue




        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try




    End Sub


    Private Sub SalvarComoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalvarComoToolStripMenuItem.Click
        Try
            user = TextBox1.Text
            pass = TextBox2.Text
            server = TextBox3.Text
            Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
            service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
            service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
            Dim filename As String = EmailReader1.ListView1.SelectedRows(0).Cells(0).Value.ToString
            If filename <> "" Then
                SaveFileDialog1.Filter = "All|*."
                SaveFileDialog1.FilterIndex = 1
                SaveFileDialog1.Title = "Save File"
                SaveFileDialog1.AddExtension = True
                SaveFileDialog1.FileName = filename
                If SaveFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then




                    Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders44, New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, itemmail.Trim), New ItemView(5))

                    If foundItems.TotalCount = 0 Then


                        Exit Sub
                    End If
                    Dim th As New Threading.Thread(Sub() startpwidnows("Salvando Anexo..."))
                    th.TrySetApartmentState(Threading.ApartmentState.STA)
                    th.Start()
                    For Each message As Item In foundItems
                        TimeDelay()
                        message.Load()
                        For j As Integer = 0 To message.Attachments.Count - 1
                            Dim fileAttachment As FileAttachment = CType(message.Attachments(j), FileAttachment)
                            If fileAttachment.Name.Contains(filename) Then


                                fileAttachment.Load()
                                TimeDelay()
                                Dim fileAttachment3 As FileAttachment = DirectCast(fileAttachment, FileAttachment)

                                Dim fileStream As New IO.FileStream(SaveFileDialog1.FileName, IO.FileMode.Create)
                                Dim buffer As Byte() = fileAttachment3.Content
                                fileStream.Write(buffer, 0, buffer.Length)
                                fileStream.Close()
                            End If
                        Next
                    Next
                    th.Abort()

                End If

            End If

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'End If
    End Sub

    Private Sub AbrirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirToolStripMenuItem.Click
        Try




            user = TextBox1.Text
            pass = TextBox2.Text
            server = TextBox3.Text
            Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
            service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
            service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
            Dim filename As String = EmailReader1.ListView1.SelectedRows(0).Cells(0).Value.ToString
            If filename <> Nothing Then

                ' If selectfolder = Nothing Then
                'selectfolder = WellKnownFolderName.Inbox
                'End If
                If IO.File.Exists(IO.Path.GetTempPath & filename) Then
                    Process.Start(IO.Path.GetTempPath & "\" & filename)


                    Exit Sub
                End If
                Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders45(Label2.Text), New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, itemmail), New ItemView(5))

                If foundItems.TotalCount = 0 Then


                    Exit Sub
                End If
                Dim th As New Threading.Thread(Sub() startpwidnows("Abrindo Anexo..."))
                th.TrySetApartmentState(Threading.ApartmentState.STA)
                th.Start()
                For Each message As Item In foundItems
                    TimeDelay()
                    message.Load()
                    For j As Integer = 0 To message.Attachments.Count - 1
                        Dim fileAttachment As FileAttachment = CType(message.Attachments(j), FileAttachment)

                        If fileAttachment.Name.Trim.ToLower.Contains(filename.Trim.ToLower) Then
                            fileAttachment.Load()
                            Dim fileAttachment3 As FileAttachment = DirectCast(fileAttachment, FileAttachment)
                            If IO.File.Exists(IO.Path.GetTempPath & filename) Then
                                IO.File.Delete(IO.Path.GetTempPath & filename)
                            End If
                            TimeDelay()
                            Dim fileStream As New IO.FileStream(IO.Path.GetTempPath & filename, IO.FileMode.Create)
                            Dim buffer As Byte() = fileAttachment3.Content
                            fileStream.Write(buffer, 0, buffer.Length)
                            fileStream.Close()



                            TimeDelay()
                            Dim p As Process = Process.Start(IO.Path.GetTempPath & "\" & filename)

                        End If

                    Next
                Next
                th.Abort()
            End If

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub checkimgatt()
        Try


            user = TextBox1.Text
            pass = TextBox2.Text
            server = TextBox3.Text
            Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
            service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
            service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")


            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders45(Label2.Text), New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, itemmail), New ItemView(5))

            If foundItems.TotalCount = 0 Then


                Exit Sub
            End If
            For Each message As Item In foundItems
                message.Load()
                For j As Integer = 0 To message.Attachments.Count - 1
                    Dim file1 As FileAttachment = CType(message.Attachments(j), FileAttachment)
                    file1.Load()
                    Dim sType As String = file1.ContentType.ToLower()
                    If file1.IsInline And sType.Contains("image") Then

                        Dim sID As String = file1.ContentId
                        sType = sType.Replace("image/", "")
                        Dim sFilename As String = sID & "." & sType

                        Dim sPathPlusFilename As String = IO.Path.GetTempPath & sFilename

                        Dim oldString As String = "cid:" & sID
                        If IO.File.Exists(sPathPlusFilename) And Me.Invoke(Function() EmailReader1.WebBrowser1.DocumentText.Contains(IO.Path.GetFileName(sPathPlusFilename))) = False Then

                            Me.Invoke(Sub() EmailReader1.WebBrowser1.DocumentText = EmailReader1.WebBrowser1.DocumentText.Replace(oldString, "file://" & sPathPlusFilename))
                        Else
                            Dim fileStream As New IO.FileStream(sPathPlusFilename, IO.FileMode.Create)
                            Dim buffer As Byte() = file1.Content
                            fileStream.Write(buffer, 0, buffer.Length)
                            fileStream.Close()
                            Me.Invoke(Sub() EmailReader1.WebBrowser1.DocumentText = EmailReader1.WebBrowser1.DocumentText.Replace(oldString, "file://" & sPathPlusFilename))
                        End If


                    End If

                Next
            Next
            '  End If

        Catch ex As Exception

            '   Me.Invoke(Sub() EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString))

            ' MetroMessageBox.Show(Me, ex.Message & ex.StackTrace, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub checkimgatt2()
        Try


            user = TextBox1.Text
            pass = TextBox2.Text
            server = TextBox3.Text
            Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
            service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
            service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")


            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders45(Label2.Text), New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, itemmail), New ItemView(5))

            If foundItems.TotalCount = 0 Then


                Exit Sub
            End If
            For Each message As Item In foundItems
                message.Load()
                For j As Integer = 0 To message.Attachments.Count - 1
                    Dim file1 As FileAttachment = CType(message.Attachments(j), FileAttachment)
                    file1.Load()
                    Dim sType As String = file1.ContentType.ToLower()
                    If file1.IsInline And sType.Contains("image") Then

                        Dim sID As String = file1.ContentId
                        sType = sType.Replace("image/", "")
                        Dim sFilename As String = sID & "." & sType
                        Dim sPathPlusFilename As String = IO.Path.GetTempPath & sFilename

                        Dim oldString As String = "cid:" & sID
                        If IO.File.Exists(sPathPlusFilename) And Me.Invoke(Function() Form2.Editor1.webBrowser1.DocumentText.Contains(IO.Path.GetFileName(sPathPlusFilename))) = False Then
                            Me.Invoke(Sub() Form2.Editor1.webBrowser1.Document.Body.InnerHtml = Form2.Editor1.webBrowser1.Document.Body.InnerHtml.Replace(oldString, "file://" & sPathPlusFilename))
                        Else
                            Dim fileStream As New IO.FileStream(sPathPlusFilename, IO.FileMode.Create)
                            Dim buffer As Byte() = file1.Content
                            fileStream.Write(buffer, 0, buffer.Length)
                            fileStream.Close()
                            Me.Invoke(Sub() Form2.Editor1.webBrowser1.Document.Body.InnerHtml = Form2.Editor1.webBrowser1.Document.Body.InnerHtml.Replace(oldString, "file://" & sPathPlusFilename))
                        End If


                    End If

                Next
            Next
            '  End If

        Catch ex As Exception

            Me.Invoke(Sub() EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString))

            ' MetroMessageBox.Show(Me, ex.Message & ex.StackTrace, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub ExcluirToolStripMenuItem_AvailableChanged(sender As Object, e As EventArgs) Handles ExcluirToolStripMenuItem.AvailableChanged

    End Sub





    Private Sub ExcluirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcluirToolStripMenuItem.Click
        Try

            selectfolder = Label2.Text
            Excluiremail()
            mailbox = Label2.Text
            ArboScrollableListBox2.Update()
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub listusers()
        Try
            Dim userName As String = Environment.UserName
            Dim domainName As String = Environment.UserDomainName
            Dim str(2) As String
            Dim itm As ListViewItem
            Dim entry As DirectoryEntry = New DirectoryEntry("LDAP://" & domainName & "")
            Dim dSearch As DirectorySearcher = New DirectorySearcher(entry)
            dSearch.Filter = "(objectClass=user)"
            For Each sResultSet As SearchResult In dSearch.FindAll
                If (sResultSet.Properties("mail").Count > 0) Then
                    str(0) = ((sResultSet.Properties("samaccountname")(0).ToString))
                    str(1) = ((sResultSet.Properties("mail")(0).ToString))
                    itm = New ListViewItem(str)
                    Form3.ListView1.Items.Add(itm)
                End If
            Next
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Public Sub searchcontacts()
        Try
            If Form3.TextBox1.Text = Nothing Then
                listusers()
                Exit Sub
            End If
            If Form3.TextBox1.Text <> "" Then
                Dim Found As Boolean = False
                For I As Integer = 0 To Form3.ListView1.Items.Count - 1
                    Dim LVI As ListViewItem = Form3.ListView1.Items(I)
                    LVI.BackColor = Form3.ListView1.BackColor
                    Dim T As String = UCase(LVI.SubItems(0).Text)
                    If T.Contains(UCase(Form3.TextBox1.Text)) Then
                        LVI.BackColor = Color.LightBlue
                        Found = True
                        Form3.ListView1.EnsureVisible(I)
                    End If
                Next
                If Not Found Then
                    search2()
                Else

                End If
            Else
                For Each LVI As ListViewItem In Form3.ListView1.Items
                    LVI.BackColor = Form3.ListView1.BackColor
                Next
            End If
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub search2()

        If Form3.TextBox1.Text <> "" Then
            Dim Found As Boolean = False
            For I As Integer = 0 To Form3.ListView1.Items.Count - 1
                Dim LVI As ListViewItem = Form3.ListView1.Items(I)
                LVI.BackColor = Form3.ListView1.BackColor
                Dim T As String = UCase(LVI.SubItems(0).Text)
                If T.Contains(UCase(Form3.TextBox1.Text)) Then
                    LVI.BackColor = Color.LightBlue
                    Found = True
                    Form3.ListView1.EnsureVisible(I)
                End If
            Next

        Else
            For Each LVI As ListViewItem In Form3.ListView1.Items
                LVI.BackColor = Form3.ListView1.BackColor
            Next
        End If

    End Sub
    Private Sub ResponderATodosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResponderATodosToolStripMenuItem.Click
        Try
            Dim th As New Threading.Thread(Sub() startpwidnows())
            th.TrySetApartmentState(Threading.ApartmentState.STA)
            th.Start()




            selectfolder = Label2.Text
            Responderatodos()
            th.Abort()

            Form2.Show()
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub




    Private Sub EncaminharToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EncaminharToolStripMenuItem.Click
        Try

            Dim th As New Threading.Thread(Sub() startpwidnows())
            th.TrySetApartmentState(Threading.ApartmentState.STA)
            th.Start()



            selectfolder = Label2.Text
            EncaminharEmail()
            th.Abort()

            Form2.Show()
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




    Private Sub ResponderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResponderToolStripMenuItem.Click
        Try

            Dim th As New Threading.Thread(Sub() startpwidnows())
            th.TrySetApartmentState(Threading.ApartmentState.STA)
            th.Start()



            Responder()
            th.Abort()
            Form2.Show()



        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '  MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ImprimirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImprimirToolStripMenuItem.Click
        Try
            selectfolder = Label2.Text
            DeleteEmail()
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Function CheckemailOnline(ByVal messageid As String, ByVal folder As String) As Boolean

        Dim found As Boolean = False
        user = Me.Invoke(Function() TextBox1.Text)
        pass = Me.Invoke(Function() TextBox2.Text)
        server = Me.Invoke(Function() TextBox3.Text)
        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try

            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders45(folder), New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, messageid), New ItemView(5))

            If foundItems.Count > 0 Then
                found = True
            End If

            Return found
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
            Return found
            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function


    Public Sub startsearch()
        Try
            Me.Invoke(Sub() searchlistview())
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub searchlistview()
        Try
            Dim searchtext As String = getPropertyValueFromProperty(RichTextBox3, "Text")
            If searchtext <> "" And account IsNot Nothing Then
                For Each x10 As FolderEmail In account.folders(0).items
                    Dim foldertosearch As String = getPropertyValueFromProperty(Label2, "Text")
                    If x10.name.ToLower.Contains(foldertosearch.ToLower) Then
                        If x10.emails.emails.Count > 0 Then
                            Me.Invoke(Sub() MetroProgressBar1.Maximum = x10.emails.emails.Count)
                            For Each m1 As Email In x10.emails.emails
                                Dim cc As String = ""
                                If m1.CC IsNot Nothing And m1.CC <> "" Then
                                    cc = m1.CC
                                End If
                                If m1.Html.ToLower.Contains(searchtext.ToLower.ToString) Or m1.Assunto.ToLower.Contains(searchtext.ToLower) Or cc.Contains(searchtext.ToLower) Or m1.Para.ToLower.Contains(searchtext.ToLower) Or m1.De.ToLower.Contains(searchtext.ToLower) Or m1.data.ToString.ToLower.Contains(searchtext.ToLower) Then
                                    countsearch = countsearch + 1
                                    Dim c As New ListControlItem
                                    c.Name = "itemFound" & countsearch.ToString
                                    c.from = m1.De
                                    c.displayto = m1.Para
                                    c.Duration = m1.data.ToString
                                    c.idmessage = m1.idmessage
                                    c.subject = m1.Assunto
                                    c.PictureBox1.Visible = m1.hasatt

                                    c.folder = m1.folder

                                    If m1.read = False Then
                                        c.Panel1.BackColor = Color.Maroon
                                    End If
                                    Dim canadd As Boolean = True

                                    If c.folder <> "" Then

                                        If c.folder.ToLower.Contains(Label2.Text.ToLower) And allreadyxists(c.idmessage, ArboScrollableListBox2.Items) = False Then
                                            canadd = True

                                        Else
                                            canadd = False


                                        End If
                                    End If

                                    If canadd = True And allreadyxists(c.idmessage, ArboScrollableListBox2.Items) = False Then

                                        AddHandler c.SelectionChanged, AddressOf ListControl1.SelectionChanged
                                        AddHandler c.Click, AddressOf ListControl1.ItemClicked
                                        AddHandler c.CheckBox1.CheckedChanged, AddressOf checkchange
                                        reloadlistcontrol(c)
                                        ArboScrollableListBox2.Update()
                                        MetroProgressBar1.Value += 1
                                    End If

                                End If

                            Next
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub







    Public Sub searchfilestext(ByVal valuetosearch As String)
        Try
            Dim mfrom As String = ""
            Dim subject As String = ""
            Dim displayto As String = ""
            Dim datatimereceived As String = ""
            Dim messageid As String = ""
            Dim messagebody As String = ""
            Dim cc As String = ""
            Dim hasatt As Boolean = False
            Dim read As Boolean = True
            Dim foldertosearch As String = selectfolder
            If NaviMain3.treeView1.SelectedNode IsNot Nothing Then
                foldertosearch = NaviMain3.treeView1.SelectedNode.FullPath
            End If
            Dim dr As New IO.DirectoryInfo(foldertosearch)
            Dim files() As IO.FileInfo = dr.GetFiles
            If files.Count > 0 Then
                MetroProgressBar1.Value = 0
                MetroProgressBar1.Maximum = files.Count
                For Each file1 As IO.FileInfo In files
                    TimeDelay()
                    MetroProgressBar1.Value += 1
                    If countsearch > 900 Then
                        MetroMessageBox.Show(Me, "Muitos resultados Encontrados Pesquise por outras palavras caso não ache oque precise!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub

                    Else

                        If readalltext(file1.FullName).ToLower.Contains(RichTextBox3.Text.ToLower) Then
                            If allreadyxists(ExtractNumber(file1.Name)) = False Then
                                '  Dim filetosearch As String = searchfolders(selectfolder) & "\" & ExtractNumber(file1.Name) & ".txt"
                                '  If IO.File.Exists(filetosearch) Then
                                '   mfrom = readfile("From", filetosearch)
                                '   subject = readfile("Subject", filetosearch)
                                '   displayto = readfile("DisplayTo", filetosearch)
                                '   datatimereceived = readfile("Time", filetosearch)
                                '   messageid = readfile("MessageId", filetosearch).Trim


                                '   If readfile("Read", filetosearch).ToLower.Contains("True".ToLower) Then
                                '     read = True
                                'Else
                                '     read = False
                                '  End If
                                '
                                'If readfile("hasatt", filetosearch).ToLower.Contains("True".ToLower) Then
                                'hasatt = True
                                '  Else
                                '    hasatt = False
                                '  End If
                                '   TimeDelay()
                                'Dim c As New ListControlItem
                                '  c.from = mfrom
                                '  c.displayto = displayto
                                '  c.Duration = datatimereceived
                                '  c.idmessage = messageid
                                '  c.subject = subject
                                ' c.PictureBox1.Visible = hasatt
                                '  If read = False Then
                                'c.Panel1.BackColor = Color.Maroon
                                ' End If
                                'AddHandler c.SelectionChanged, AddressOf ListControl1.SelectionChanged
                                ' AddHandler c.Click, AddressOf ListControl1.ItemClicked
                                ' AddHandler c.CheckBox1.CheckedChanged, AddressOf checkchange
                                ' reloadlistcontrol(c)
                                ' ArboScrollableListBox2.Update()
                                ' countsearch = countsearch + 1
                                ' End If
                            End If
                        End If
                    End If
                Next

            End If
            If moreemails.Count > 0 Then
                MetroButton2.Enabled = True
                MetroButton2.Text = "+ Emails" & "(" & moreemails.Count & ")"
            End If

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form4.Show()

    End Sub




    Private Sub PictureBox1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form4.Show()

    End Sub
    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoginForm1.Show()
    End Sub



    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim myemail As String = TextBox4.Text
        Form5.Show()
    End Sub


    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            FolderBrowserDialog1.ShowDialog()
            If FolderBrowserDialog1.SelectedPath.Count <> 0 Then
                TextBox5.Text = FolderBrowserDialog1.SelectedPath
                Form6.Show()
                'Form6.saveallmesagges()
            End If
        Catch ex As Exception

        End Try
    End Sub




    Public Sub checkimage(ByVal name As String, ByVal id As FileAttachment)
        Try
            Dim str As String = name

            If (str.IndexOf("jpg") <> -1) Or (str.IndexOf("png") <> -1) Or (str.IndexOf("bmp") <> -1) Then
                saveimage(name, id)
            Else

            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub saveimage(ByVal filename As String, ByVal id As FileAttachment)
        Try
            user = TextBox1.Text
            pass = TextBox2.Text
            server = TextBox3.Text

            Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
            service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
            service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
            Dim attachment As FileAttachment = id




            If TypeOf attachment Is FileAttachment Then

                Dim fileAttachment As FileAttachment = DirectCast(attachment, FileAttachment)
                If IO.File.Exists(IO.Path.GetTempPath & filename) Then
                    IO.File.Delete(IO.Path.GetTempPath & filename)
                End If

                Dim fileStream As New IO.FileStream(IO.Path.GetTempPath & filename, IO.FileMode.Create)
                Dim buffer As Byte() = fileAttachment.Content
                Using fileStream
                    fileStream.Write(buffer, 0, buffer.Length)
                End Using
                fileStream.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub saveatt(ByVal filename As String, ByVal id As FileAttachment)
        Try

            user = TextBox1.Text
            pass = TextBox2.Text
            server = TextBox3.Text

            Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
            service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
            service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
            Dim attachment As FileAttachment = id




            If TypeOf attachment Is FileAttachment Then

                Dim fileAttachment As FileAttachment = DirectCast(attachment, FileAttachment)
                If IO.File.Exists(IO.Path.GetTempPath & filename) Then
                    IO.File.Delete(IO.Path.GetTempPath & filename)
                End If

                Dim fileStream As New IO.FileStream(IO.Path.GetTempPath & filename, IO.FileMode.Create)
                Dim buffer As Byte() = fileAttachment.Content
                Using fileStream
                    fileStream.Write(buffer, 0, buffer.Length)
                End Using
                fileStream.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SalvarEmailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalvarEmailToolStripMenuItem.Click
        Try
            Dim value As String = ""
            value = getPropertyValueFromProperty(ArboScrollableListBox2.Items(indexitem), "Duration")
            SaveFileDialog1.FilterIndex = 1
            SaveFileDialog1.Title = "Save File"
            SaveFileDialog1.AddExtension = True
            Dim Res As String = ""
            For Each c As Char In value
                If IsNumeric(c) Then
                    Res = Res & c
                End If
            Next
            Dim value2 As String = getPropertyValueFromProperty(ArboScrollableListBox2.Items(indexitem), "from")
            SaveFileDialog1.FileName = value2 & Res
            If SaveFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then




                TextBox6.Text = SaveFileDialog1.FileName

                selectfolder = Label2.Text
                savemsg()


            End If
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ribbonbutton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ribbonButton3.Click
        Try '
            Dim form3 As New Form2
            Dim th1 As New Threading.Thread(Sub() Application.Run(form3))
           


            form3.Show()
            If account.assinatura IsNot Nothing And account.assinatura <> "" Then
                Dim Path As String = Application.StartupPath & "\" & account.assinatura
                form3.Editor1.webBrowser1.DocumentText = "<html><br><br><br><br><br><br><br><html/>" & "<img src='" & Path & "' />" & "<html><br><br><br><html/>"
            Else
                form3.Editor1.webBrowser1.DocumentText = ""
            End If


        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ribbonbutton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ribbonButton4.Click
        Try


            selectfolder = Label2.Text
            Dim th As New Threading.Thread(Sub() startpwidnows())
            th.TrySetApartmentState(Threading.ApartmentState.STA)
            th.Start()
            Dim form3 As New Form2
            Responder(form3)
            th.Abort()
            Dim th1 As New Threading.Thread(Sub() Application.Run(form3))

            form3.Show()





        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ribbonbutton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ribbonButton5.Click
        Try






            selectfolder = Label2.Text
            Dim th As New Threading.Thread(Sub() startpwidnows())
            th.TrySetApartmentState(Threading.ApartmentState.STA)
            th.Start()
            Dim form3 As New Form2
            Responderatodos(form3)
            th.Abort()
            Dim th1 As New Threading.Thread(Sub() Application.Run(form3))

            form3.Show()


        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ribbonbutton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ribbonButton6.Click
        Try





            selectfolder = Label2.Text
            Dim th As New Threading.Thread(Sub() startpwidnows())
            th.TrySetApartmentState(Threading.ApartmentState.STA)
            th.Start()
            Dim form3 As New Form2
            EncaminharEmail(form3)
            th.Abort()
            Dim th1 As New Threading.Thread(Sub() Application.Run(form3))

            form3.Show()
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ribbonbutton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ribbonButton7.Click
        Try
            selectfolder = Label2.Text
            Excluiremail()
            ArboScrollableListBox2.BeginUpdate()
            ArboScrollableListBox2.panelControls.Controls.RemoveAt(indexitem)
            ArboScrollableListBox2.EndUpdate()

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ribbonbutton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ribbonButton8.Click

        Application.Exit()
    End Sub

    Private Sub ribbonbutton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ribbonButton9.Click
        Try

            Form4.Show()
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub

    Private Sub ribbonbutton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ribbonButton10.Click

        Try
            arquivomorto = False

            listofcontrols.Clear()
            controlstodo.Clear()

            If NaviMain3.treeView1.SelectedNode IsNot Nothing Then
                selectfolder = NaviMain3.treeView1.SelectedNode.Text
                mailbox = NaviMain3.treeView1.SelectedNode.Text
            Else
                selectfolder = Label2.Text
                mailbox = Label2.Text
            End If

            DownloadEmails.Show()
            downloadstartemail(selectfolder)
            If listofcontrols.Count > 0 Then
                Do
                    If ArboScrollableListBox2.panelControls.Controls.Count = 0 Then Exit Do
                    Dim c As ListControlItem = TryCast(ArboScrollableListBox2.panelControls.Controls(0), ListControlItem)
                    ArboScrollableListBox2.BeginUpdate()
                    ArboScrollableListBox2.Remove(c)
                    ' remove the event hook
                    RemoveHandler c.SelectionChanged, AddressOf ArboScrollableListBox2_oncontrolselect
                    RemoveHandler c.DoubleClick, AddressOf ArboScrollableListBox2_doubleclick
                    ' now dispose off properly
                    c.Dispose()
                    ArboScrollableListBox2.EndUpdate()
                Loop
                For Each c As ListControlItem In listofcontrols
                    ArboScrollableListBox2.BeginUpdate()
                    ArboScrollableListBox2.Items.Add(c)
                    AddHandler c.SelectionChanged, AddressOf ArboScrollableListBox2_oncontrolselect
                    AddHandler c.DoubleClick, AddressOf ArboScrollableListBox2_doubleclick
                    ArboScrollableListBox2.EndUpdate()
                Next
                ArboScrollableListBox2.Update()
                orderlist(True)
            End If
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ribbonbutton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ribbonButton11.Click
        Try
            FolderBrowserDialog1.ShowDialog()
            If FolderBrowserDialog1.SelectedPath.Count <> 0 Then
                TextBox5.Text = FolderBrowserDialog1.SelectedPath
                Form6.Show()
                Form6.startsaving()
            End If
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ribbonbutton12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ribbonButton12.Click
        Try

            Form5.Show()
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub RibbonOrbMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ribbonOrbMenuItem2.Click

        Process.GetCurrentProcess.Kill()
    End Sub

    Private Sub RibbonOrbMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ribbonOrbMenuItem1.Click
        Try
            Form5.Show()
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub findvalues2(ByVal html As String, ByVal selectvalue As String)
        Dim reImg As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("<img\s[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        Dim reSrc As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("src=(?:(['""""])(?<src>(?:(?!\1).)*)\1|(?<src>[^\s>]+))", (System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Singleline))
        Dim mc As System.Text.RegularExpressions.MatchCollection = reImg.Matches(html)
        For Each mImg As System.Text.RegularExpressions.Match In mc
            If reSrc.IsMatch(mImg.Groups(0).Value) Then
                Dim mSrc As System.Text.RegularExpressions.Match = reSrc.Match(mImg.Groups(0).Value)
                If mSrc.Value.Contains(selectvalue) Then

                    Dim html2 As String = testreplace(html, mSrc.Groups(0).Value, "src= " & "file://" & IO.Path.GetTempPath & selectvalue & "")
                    RichTextBox1.Text = html2


                End If
            End If
        Next


    End Sub
    Public Function findvalues(ByVal html As String, ByVal selectvalue As String) As String
        Dim reImg As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("<img\s[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        Dim reSrc As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("src=(?:(['""""])(?<src>(?:(?!\1).)*)\1|(?<src>[^\s>]+))", (System.Text.RegularExpressions.RegexOptions.IgnoreCase Or System.Text.RegularExpressions.RegexOptions.Singleline))
        Dim mc As System.Text.RegularExpressions.MatchCollection = reImg.Matches(html)
        For Each mImg As System.Text.RegularExpressions.Match In mc
            If reSrc.IsMatch(mImg.Groups(0).Value) Then
                Dim mSrc As System.Text.RegularExpressions.Match = reSrc.Match(mImg.Groups(0).Value)
                If mSrc.Value.Contains(selectvalue) Then

                    Dim html2 As String = testreplace(html, mSrc.Groups(0).Value, "src= " & "file://" & IO.Path.GetTempPath & selectvalue & "")
                    Return html2
                    Exit Function

                End If
            End If
        Next
        Return ""

    End Function

    Sub replacevalue(ByVal file As String, ByVal value As String, ByVal replace As String)
        Try
            Dim lines() As String = IO.File.ReadAllLines(file)
            For x As Integer = 0 To lines.GetUpperBound(0)
                If lines(x).Contains(value) Then
                    lines(x) = lines(x).Replace(value, replace)
                End If
            Next

            IO.File.WriteAllLines(file, lines)
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub

    Public Sub sendmessage(ByVal form As Form2)
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text

        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try

            Dim th As New Threading.Thread(Sub() startpwidnows("Enviando Mensagem..."))
            th.TrySetApartmentState(Threading.ApartmentState.STA)
            th.Start()


            Dim s As String = form.RichTextBox2.Text
            Dim s1 As String = form.RichTextBox3.Text
            ' Split string based on spaces
            Dim words As String() = s.Split(New Char() {" "c})
            Dim words1 As String() = s1.Split(New Char() {" "c})
            ' Use For Each loop over words and display them
            Dim word As String
            Dim word1 As String
            'Create message in the Drafts folder          
            Dim message As New EmailMessage(service)
            message.Subject = form.RichTextBox4.Text
            Dim list1 As New List(Of String)
            For Each img As HtmlElement In form.Editor1.webBrowser1.Document.Images
                Dim filename As String = Between(After(img.OuterHtml, "src="), """", """")
                list1.Add(filename)


            Next
            form.prepare()
            ' If list1.Count < 0 Then

            ' End If

            message.Body = New MessageBody(BodyType.HTML, form.Editor1.webBrowser1.Document.Body.InnerHtml)

            '   message.Attachments.AddFileAttachment(account.assinatura)
            '  Dim newatt As FileAttachment
            '  newatt.i()
            If s <> "" Then
                For Each word In words
                    If word.Contains("@") Then
                        message.ToRecipients.Add(word)
                        createfile(word)
                    End If
                Next
            End If
            If s1 <> "" Then
                For Each word1 In words1
                    If word1.Contains("@") Then
                        message.CcRecipients.Add(word1)
                        createfile(word1)
                    End If
                Next

            End If
            If form.ListBox2.Items.Count > 0 Then
                For l_index As Integer = 0 To form.ListBox2.Items.Count - 1
                    Dim l_text As String = CStr(form.ListBox2.Items(l_index).ToString)
                    Dim att As FileAttachment = message.Attachments.AddFileAttachment(l_text)
                    If form.attsinline.Count > 0 Then
                        For Each x1 As String In form.attsinline
                            If l_text.ToLower.Contains(x1.ToLower) Then
                                att.IsInline = True
                            End If
                        Next
                    End If
                    TimeDelay()
                    form.Refresh()

                Next
            End If
            For Each x1 As String In list1
                Dim x2 As String = After(x1, "file:///")
                If x2 <> "" Then
                    x1 = x2
                End If
                If IO.File.Exists(x1) Then
                    Dim newatt As FileAttachment = message.Attachments.AddFileAttachment(x1)
                    newatt.IsInline = True
                    newatt.ContentId = IO.Path.GetFileName(x1)
                    TimeDelay()
                    form.Refresh()
                Else
                    If account.assinatura IsNot Nothing And x1.Contains(account.assinatura) Then
                        Dim newatt As FileAttachment = message.Attachments.AddFileAttachment(Application.StartupPath & "\" & account.assinatura)
                        newatt.IsInline = True
                        newatt.ContentId = IO.Path.GetFileName(Application.StartupPath & "\" & account.assinatura)
                        TimeDelay()
                        form.Refresh()
                    End If
                End If
            Next

            'Send message 
            message.Save()
            message.SendAndSaveCopy(WellKnownFolderName.SentItems)


            form.Close()
            th.Abort()
        Catch ex As ServiceRequestException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub sendmessage(ByVal msg As EmailMessage, ByVal form As Form2)
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text

        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try

            Dim th As New Threading.Thread(Sub() startpwidnows("Enviando Mensagem..."))
            th.TrySetApartmentState(Threading.ApartmentState.STA)
            th.Start()


            Dim s As String = form.RichTextBox2.Text
            Dim s1 As String = form.RichTextBox3.Text
            ' Split string based on spaces
            Dim words As String() = s.Split(New Char() {" "c})
            Dim words1 As String() = s1.Split(New Char() {" "c})
            ' Use For Each loop over words and display them
            Dim word As String
            Dim word1 As String
            'Create message in the Drafts folder          
            Dim message As EmailMessage = msg
            message.Subject = form.RichTextBox4.Text
            Dim list1 As New List(Of String)
            For Each img As HtmlElement In form.Editor1.webBrowser1.Document.Images
                Dim filename As String = Between(After(img.OuterHtml, "src="), """", """")
                list1.Add(filename)


            Next
            form.prepare()
            ' If list1.Count < 0 Then

            ' End If

            message.Body = New MessageBody(BodyType.HTML, form.Editor1.webBrowser1.Document.Body.InnerHtml)

            '   message.Attachments.AddFileAttachment(account.assinatura)
            '  Dim newatt As FileAttachment
            '  newatt.i()
            If s <> "" Then
                For Each word In words
                    If word.Contains("@") Then
                        message.ToRecipients.Add(word)
                        createfile(word)
                    End If
                Next
            End If
            If s1 <> "" Then
                For Each word1 In words1
                    If word1.Contains("@") Then
                        message.CcRecipients.Add(word1)
                        createfile(word1)
                    End If
                Next

            End If

            For Each x1 As String In list1
                Dim x2 As String = After(x1, "file:///")
                If x2 <> "" Then
                    x1 = x2
                End If
                If IO.File.Exists(x1) Then
                    Dim newatt As FileAttachment = message.Attachments.AddFileAttachment(x1)
                    newatt.IsInline = True
                    newatt.ContentId = IO.Path.GetFileName(x1)
                    TimeDelay()
                    form.Refresh()
                Else
                    If account.assinatura IsNot Nothing And x1.Contains(account.assinatura) Then
                        Dim newatt As FileAttachment = message.Attachments.AddFileAttachment(Application.StartupPath & "\" & account.assinatura)
                        newatt.IsInline = True
                        newatt.ContentId = IO.Path.GetFileName(Application.StartupPath & "\" & account.assinatura)
                        TimeDelay()
                        form.Refresh()
                    End If
                End If
            Next

            'Send message 
            message.Save()
            message.SendAndSaveCopy(WellKnownFolderName.SentItems)


            form.Close()
            th.Abort()
        Catch ex As ServiceRequestException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub





    Public Sub imageshtlm()
        For Each img As HtmlElement In Form2.Editor1.webBrowser1.Document.Images
            Dim filename As String = Between(After(img.OuterHtml, "src="), """", """")
            '  Dim newatt As FileAttachment = Message.Attachments.AddFileAttachment(IO.Path.GetFileName(filename), filename)
            ' newatt.IsInline = True
            '  newatt.ContentId = IO.Path.GetFileName(filename)
            Form2.Editor1.webBrowser1.Document.Body.InnerHtml = Form2.Editor1.webBrowser1.Document.Body.InnerHtml.Replace(filename, "Cid:" & IO.Path.GetFileName(filename))
            ' MsgBox(Form2.Editor1.webBrowser1.Document.Body.InnerHtml)
        Next

    End Sub
    Public Sub createfile(ByVal writethis As String)
        Try
            Dim filepath As String = "ContactsSend.txt"
            If IO.File.Exists(filepath) Then
                Dim hash As HashSet(Of String) = New HashSet(Of String)(IO.File.ReadAllLines(filepath))

                If Not hash.Contains(writethis) Then
                    Dim w As New IO.StreamWriter(filepath, True)
                    w.WriteLine(writethis, True)
                    w.Close()
                Else
                    'Item is already in text file
                End If
            Else
                IO.File.CreateText(filepath).Close()
                createfile(writethis)
            End If
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub









    Public Sub selecttreeview()
        Try
            If listthread.IsAlive Then
                listthread.Abort()
            End If
            If Label1.Text.Contains("Morto") Then
                selecfolderpst()
                Exit Sub
            End If
            If ToolStripStatusLabel2.Text = "Offline" Then
                MetroMessageBox.Show(Me, "Você esta usando o email offline você sera capaz apenas de visualizar seus emails ja baixados", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                listofcontrols.Clear()
                controlstodo.Clear()
                selectfolder = NaviMain3.treeView1.SelectedNode.Text
                mailbox = NaviMain3.treeView1.SelectedNode.Text
                Label2.Text = NaviMain3.treeView1.SelectedNode.Text

                Do
                    If ArboScrollableListBox2.panelControls.Controls.Count = 0 Then Exit Do
                    Dim c As ListControlItem = TryCast(ArboScrollableListBox2.panelControls.Controls(0), ListControlItem)
                    ArboScrollableListBox2.BeginUpdate()
                    ArboScrollableListBox2.Remove(c)
                    ' remove the event hook
                    RemoveHandler c.SelectionChanged, AddressOf ArboScrollableListBox2_oncontrolselect
                    RemoveHandler c.DoubleClick, AddressOf ArboScrollableListBox2_doubleclick
                    ' now dispose off properly
                    c.Dispose()
                    ArboScrollableListBox2.EndUpdate()
                Loop

                listthread = New Threading.Thread(Sub() startimport())
                listthread.TrySetApartmentState(Threading.ApartmentState.STA)
                listthread.Start()
                Exit Sub

            End If
            If listthread.IsAlive Then
                listthread.Abort()
            End If
            If checktrhead.IsAlive Then
                checktrhead.Abort()
            End If
            arquivomorto = False
            listofcontrols.Clear()
            controlstodo.Clear()
            selectfolder = NaviMain3.treeView1.SelectedNode.Text
            mailbox = NaviMain3.treeView1.SelectedNode.Text
            Label2.Text = NaviMain3.treeView1.SelectedNode.Text

            Do
                If ArboScrollableListBox2.panelControls.Controls.Count = 0 Then Exit Do
                Dim c As ListControlItem = TryCast(ArboScrollableListBox2.panelControls.Controls(0), ListControlItem)
                ArboScrollableListBox2.BeginUpdate()
                ArboScrollableListBox2.Remove(c)
                ' remove the event hook
                RemoveHandler c.SelectionChanged, AddressOf ArboScrollableListBox2_oncontrolselect
                RemoveHandler c.DoubleClick, AddressOf ArboScrollableListBox2_doubleclick
                ' now dispose off properly
                c.Dispose()
                ArboScrollableListBox2.EndUpdate()
            Loop
            If listthread.IsAlive Then
                listthread.Abort()
            End If
            If checktrhead.IsAlive Then
                checktrhead.Abort()
            End If
            listthread = New Threading.Thread(Sub() startimport())
            listthread.TrySetApartmentState(Threading.ApartmentState.STA)
            listthread.Start()
            checktrhead = New Threading.Thread(Sub() checkemails(Label2.Text))
            checktrhead.TrySetApartmentState(Threading.ApartmentState.STA)
            checktrhead.Start()

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Public Sub startpwidnows()
        Try
            Dim h As New ProgresWindows
            Application.Run(h)
        Catch ex As Exception
            'EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub
    Public Sub startpwidnows(ByVal text As String)
        Try
            Dim h As New ProgresWindows
            h.MetroLabel1.Text = text
            Application.Run(h)
        Catch ex As Exception
            'EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub

    Private Sub CriarPastaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CriarPastaToolStripMenuItem.Click
        Try
            If NaviMain3.treeView1.Focused Then

                Dim message, title As String
                Dim myValue As String
                ' Set prompt.
                message = "Nome da nova Pasta"
                ' Set title.
                title = "Criar Pasta"

                ' Display message, title, and default value.
                myValue = InputBox(message, title, "Nova Pasta")
                ' If user has clicked Cancel, set myValue to defaultValue
                Dim result As Integer = MessageBox.Show("Voce Tem Certeza  que deseja Criar Essa Pasta dentro da pasta " & NaviMain3.treeView1.SelectedNode.Text & "?", "Criar Nova Pasta", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    Exit Sub
                ElseIf result = DialogResult.Yes Then
                    createnewfolder(myValue.ToString, findfolders45)
                    Dim lastnode As TreeNode = NaviMain3.treeView1.SelectedNode
                    Dim node As TreeNode = NaviMain3.treeView1.SelectedNode.Nodes.Add(myValue)
                    Dim g As NodeLabelEditEventArgs = New NodeLabelEditEventArgs(node)
                    NaviMain3.treeView1.SelectedNode = node
                    NaviMain3.treeView1.SelectedNode.ExpandAll()
                    ' getAllFolders2(userconf, lastnode.Text, myValue)

                End If

                NaviMain3.treeView1.SelectedNode.Expand()
                If account IsNot Nothing Then

                    If IO.File.Exists(account.user & "Folders" & ".FL") Then

                        Dim seri As New ObjectSerializer(Of AssetBrowserControl.SerializableTreeView)
                        seri.SaveSerializedObject(NaviMain3.treeView1, account.user & "Folders" & ".FL")

                    End If
                End If




            End If
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DeletarPastaToolStripMenuItem_AvailableChanged(sender As Object, e As EventArgs) Handles DeletarPastaToolStripMenuItem.AvailableChanged

    End Sub






    Private Sub DeletarPastaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeletarPastaToolStripMenuItem.Click
        Try
            If NaviMain3.treeView1.Focused Then
                Dim result As Integer = MessageBox.Show("Voce Tem Certeza  que deseja Deletar Essa Pasta Permanentemente " & NaviMain3.treeView1.SelectedNode.Text & "?", "Deletar Pasta", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    Exit Sub
                ElseIf result = DialogResult.Yes Then
                    Dim lastnode As TreeNode = NaviMain3.treeView1.SelectedNode
                    Deletefolder(findfolders45)
                    NaviMain3.treeView1.SelectedNode.Remove()
                    If account IsNot Nothing Then

                        If IO.File.Exists(account.user & "Folders" & ".FL") Then

                            Dim seri As New ObjectSerializer(Of AssetBrowserControl.SerializableTreeView)
                            seri.SaveSerializedObject(NaviMain3.treeView1, account.user & "Folders" & ".FL")

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub


    Public Sub Deletefolder(ByVal folderid As FolderId)
        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text
        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try
            Dim folder As Folder = folder.Bind(service, folderid)
            folder.Delete(DeleteMode.HardDelete)

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function getAllFolders(ByVal directory As String, ByVal foldertosearch As String) As String()
        Try
            'Create object
            Dim fi As New IO.DirectoryInfo(directory)
            'Array to store paths
            Dim path() As String = {}
            'Loop through subfolders
            For Each subfolder As IO.DirectoryInfo In fi.GetDirectories()
                'Add this folders name
                If subfolder.Name = foldertosearch Then
                    subfolder.Delete()
                    Exit Function
                End If
                Array.Resize(path, path.Length + 1)
                path(path.Length - 1) = subfolder.FullName

                'Recall function with each subdirectory
                For Each s As String In getAllFolders(subfolder.FullName, foldertosearch)
                    Array.Resize(path, path.Length + 1)
                    path(path.Length - 1) = s
                Next
            Next
            Return path
        Catch ex As Exception
            Return Nothing
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Function
    Private Function getAllFolders2(ByVal directory As String, ByVal foldertosearch As String, ByVal foldername As String) As String()
        Try
            'Create object
            Dim fi As New IO.DirectoryInfo(directory)
            'Array to store paths
            Dim path() As String = {}
            'Loop through subfolders
            For Each subfolder As IO.DirectoryInfo In fi.GetDirectories()
                'Add this folders name
                If subfolder.Name = foldertosearch Then
                    subfolder.CreateSubdirectory(foldername)
                    Exit Function
                End If
                Array.Resize(path, path.Length + 1)
                path(path.Length - 1) = subfolder.FullName

                'Recall function with each subdirectory
                For Each s As String In getAllFolders(subfolder.FullName, foldertosearch)
                    Array.Resize(path, path.Length + 1)
                    path(path.Length - 1) = s
                Next
            Next
            Return path
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Function


    Private Sub SpellChecker_DeletedWord(ByVal sender As Object, ByVal e As NetSpell.SpellChecker.SpellingEventArgs) Handles SpellChecker.DeletedWord
        'save existing selecting
        Try
            Form2.Editor1.webBrowser1.Document.Body.InnerHtml = Form2.Editor1.webBrowser1.Document.Body.InnerHtml.Replace(e.Word, "")
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub

    Private Sub SpellChecker_ReplacedWord(ByVal sender As Object, ByVal e As NetSpell.SpellChecker.ReplaceWordEventArgs) Handles SpellChecker.ReplacedWord
        Try

            Form2.Editor1.webBrowser1.Document.Body.InnerHtml = Form2.Editor1.webBrowser1.Document.Body.InnerHtml.Replace(e.Word, e.ReplacementWord)
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try

    End Sub








    Public Shared Function ByteArrayToString(ByVal ba() As Byte) As String
        Try
            Dim hex As System.Text.StringBuilder = New System.Text.StringBuilder((ba.Length * 2))
            For Each b As Byte In ba
                hex.AppendFormat("{0:x2}", b)
            Next
            Return hex.ToString
        Catch ex As Exception
            Return ""
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Function





    Private Sub ribbonbutton14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ribbonButton14.Click
        Try
            For i As Integer = 0 To ArboScrollableListBox2.Items.Count - 1
                Dim control1 As ListControlItem = TryCast(ArboScrollableListBox2.Items(i), ListControlItem)
                If control1.CheckBox1.Checked = True Then
                    control1.CheckBox1.Checked = False
                ElseIf control1.CheckBox1.Checked = False Then
                    control1.CheckBox1.Checked = True
                End If
            Next

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub
    Private Sub ribbonbutton16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ribbonButton16.Click

        Try

            Dim result As Integer = MessageBox.Show("Voce Tem Certeza que deseja deletar os items selecionados?", "Deletar Item Para Itens Excluidos", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                Exit Sub
            ElseIf result = DialogResult.Yes Then
                SelectEmails.Show()
                Dim bp As New BackgroundWorker
                AddHandler bp.DoWork, AddressOf excluirtodos
                AddHandler bp.ProgressChanged, AddressOf progresselect
                AddHandler bp.RunWorkerCompleted, AddressOf doneemails
                bp.WorkerReportsProgress = True
                bp.WorkerSupportsCancellation = True
                doemails = "Excluindo Emails"
                SelectEmails.worker = bp
                bp.RunWorkerAsync()
            End If



        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub
    Private Sub progresselect(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs)
        Try
            SelectEmails.MetroLabel3.Text = doemails
            SelectEmails.Items.Text = controlstodo.Count.ToString
            SelectEmails.MetroProgressBar1.Maximum = controlstodo.Count
            SelectEmails.MetroProgressBar1.Value += e.ProgressPercentage
            SelectEmails.Email.Text = emailnow
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub progresselect2(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs)
        Try

            SelectEmails.MetroLabel3.Text = doemails
            SelectEmails.Items.Text = itemcount2.ToString
            SelectEmails.MetroProgressBar1.Maximum = itemcount2
            SelectEmails.MetroProgressBar1.Value += e.ProgressPercentage
            SelectEmails.Email.Text = emailnow
            Me.Invoke(Sub() TimeDelay())
        Catch ex As Exception
            Me.Invoke(Sub() EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString))

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub doneemails()
        Try

            ArboScrollableListBox2.BeginUpdate()
            ArboScrollableListBox2.Refresh()
            ArboScrollableListBox2.EndUpdate()

            SelectEmails.Close()

        Catch ex As Exception
            '  EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function GetControlByName(Name As String) As Control
        For Each c As Control In ArboScrollableListBox2.Items
            If c.Name.ToLower.Contains(Name.ToLower) Then
                Return c
            End If
        Next

        Return Nothing
    End Function

    Public Sub excluirtodos(ByVal sender As Object, e As DoWorkEventArgs)
        Try
            Dim bp As BackgroundWorker = TryCast(sender, BackgroundWorker)
            bp.ReportProgress(0)
            For i As Integer = 0 To controlstodo.Count - 1
                Dim control1 As ListControlItem = TryCast(GetControlByName(controlstodo.Item(i)), ListControlItem)
                If control1.CheckBox1.CheckState = CheckState.Checked Then
                    emailnow = control1.subject
                    itemmail = control1.idmessage
                    bp.ReportProgress(1)
                    selectfolder = Label2.Text
                    Me.Invoke(Sub() DeleteItem())
                    Dim c As ListControlItem = control1
                    Me.Invoke(Sub() clearlist(control1))
                    For Each x5 As FolderEmail In account.folders(0).items
                        If x5.name.ToLower.Contains(Label2.Text.ToLower) Then
                            For Each m1 As Email In x5.emails.emails
                                If m1.idmessage.ToLower.Contains(itemmail.ToLower) Then
                                    Me.Invoke(Sub() deletefromfolderaccount(m1, Label2.Text))
                                    Me.Invoke(Sub() save())
                                    Exit For
                                End If
                            Next


                        End If

                    Next
                End If


            Next


            controlstodo.Clear()
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub clearlist(ByVal c As ListControlItem)
        Try
            ArboScrollableListBox2.BeginUpdate()
            ArboScrollableListBox2.Remove(c)
            ' remove the event hook
            RemoveHandler c.SelectionChanged, AddressOf ArboScrollableListBox2_oncontrolselect
            RemoveHandler c.DoubleClick, AddressOf ArboScrollableListBox2_doubleclick
            ' now dispose off properly
            c.Dispose()
            ArboScrollableListBox2.EndUpdate()

        Catch ex As Exception

        End Try
    End Sub


    Private Sub ribbonbutton18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ribbonButton18.Click
        Try
            Dim result As Integer = MessageBox.Show("Voce Tem Certeza que deseja deletar Permanentemente os items selecionados?", "Deletar Item Para Itens Excluidos", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                Exit Sub
            ElseIf result = DialogResult.Yes Then
                SelectEmails.Show()
                Dim bp As New BackgroundWorker
                AddHandler bp.DoWork, AddressOf deletartodospermanentemente
                AddHandler bp.ProgressChanged, AddressOf progresselect
                AddHandler bp.RunWorkerCompleted, AddressOf doneemails
                bp.WorkerReportsProgress = True
                bp.WorkerSupportsCancellation = True
                SelectEmails.worker = bp
                doemails = "Excluindo Emails"
                bp.RunWorkerAsync()
            End If


        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub deletartodospermanentemente(ByVal sender As Object, e As DoWorkEventArgs)
        Try
            Dim bp As BackgroundWorker = TryCast(sender, BackgroundWorker)
            bp.ReportProgress(0)
            For Each i As String In controlstodo
                Dim control1 As ListControlItem = TryCast(GetControlByName(i), ListControlItem)
                If control1.CheckBox1.CheckState = CheckState.Checked Then
                    emailnow = control1.subject
                    itemmail = control1.idmessage
                    bp.ReportProgress(1)
                    selectfolder = Label2.Text
                    Me.Invoke(Sub() DeleteHardItem())
                    Me.Invoke(Sub() ArboScrollableListBox2.BeginUpdate())
                    Me.Invoke(Sub() ArboScrollableListBox2.Remove(control1))
                    ' remove the event hook
                    Me.Invoke(Sub() RemoveHandler control1.SelectionChanged, AddressOf ArboScrollableListBox2_oncontrolselect)
                    Me.Invoke(Sub() RemoveHandler control1.DoubleClick, AddressOf ArboScrollableListBox2_doubleclick)
                    ' now dispose off properly
                    Me.Invoke(Sub() control1.Dispose())
                    Me.Invoke(Sub() ArboScrollableListBox2.EndUpdate())
                    ' Me.Invoke(Sub() clearlist(control1))
                    For Each x5 As FolderEmail In account.folders(0).items
                        If x5.name.ToLower.Contains(selectfolder.ToLower) Then
                            For Each m1 As Email In x5.emails.emails
                                If m1.idmessage.ToLower.Contains(itemmail.ToLower) Then
                                    Me.Invoke(Sub() deletefromfolderaccount(m1, selectfolder))
                                    Exit For
                                End If
                            Next
                        End If

                    Next
                End If


            Next


            controlstodo.Clear()
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ribbonbutton17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ribbonButton17.Click
        Try
            Form7.Text = "Mover Emails"
            TextBox8.Text = "false"
            Form7.Show()
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ribbonbutton13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ribbonButton13.Click
        Try
            Form7.Text = "Copiar Emails"
            TextBox8.Text = "false"
            Form7.Show()
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ribbonbutton15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ribbonButton15.Click
        Try
            TimeDelay()
            WebBrowser1.DocumentText = "<html><br>" & "De:" & EmailReader1.FromEmail.Text & "<br>" & "Para:" & EmailReader1.DisplayTo.Text & "<br>" & "CC:" & EmailReader1.CC.Text & "<br>" _
               & "Assunto:" & EmailReader1.Subject.Text & "<br>" & "Enviada em:" & EmailReader1.Enviadaem.Text & "<html/>" & EmailReader1.WebBrowser1.DocumentText
            TimeDelay()
            WebBrowser1.ShowPrintPreviewDialog()


        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub copyitems()
        Try
            If Form7.TreeView1.SelectedNode.Text <> Nothing Then




                mailbox2 = Form7.TreeView1.SelectedNode.Text
                mailbox = Label2.Text
                selectfolder = Label2.Text
                findfolders16()
                For Each x5 As FolderEmail In account.folders(0).items
                    If x5.name.ToLower.Contains(mailbox.ToLower) Then
                        For Each m1 As Email In x5.emails.emails
                            If m1.idmessage.ToLower.Contains(itemmail.ToLower) Then
                                ' copytofolderaccount(m1, mailbox2)
                                save()
                            End If
                        Next


                    End If

                Next

            End If
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub moveitems()
        Try
            If NaviMain3.treeView1.SelectedNode.Text <> "" Then




                mailbox2 = Form7.TreeView1.SelectedNode.Text
                mailbox = Label2.Text
                selectfolder = Label2.Text
                findfolders6()
                Dim c As ListControlItem = TryCast(ArboScrollableListBox2.Items(indexitem), ListControlItem)
                ArboScrollableListBox2.BeginUpdate()
                ArboScrollableListBox2.Remove(c)
                ' remove the event hook
                RemoveHandler c.SelectionChanged, AddressOf ArboScrollableListBox2_oncontrolselect
                RemoveHandler c.DoubleClick, AddressOf ArboScrollableListBox2_doubleclick
                ' now dispose off properly
                c.Dispose()
                ArboScrollableListBox2.EndUpdate()

                For Each x5 As FolderEmail In account.folders(0).items
                    If x5.name.ToLower.Contains(mailbox.ToLower) Then
                        For Each m1 As Email In x5.emails.emails
                            If m1.idmessage.ToLower.Contains(itemmail.ToLower) Then
                                ' copytofolderaccount(m1, mailbox2)
                                deletefromfolderaccount(m1, mailbox)
                                save()
                            End If
                        Next


                    End If
                Next


            End If
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub CopyItemToToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyItemToToolStripMenuItem.Click
        Form7.Text = "Copiar Emails"
        TextBox8.Text = "true"
        Form7.Show()
    End Sub

    Private Sub MoveItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoveItemToolStripMenuItem.Click

        Form7.Text = "Mover Emails"
        TextBox8.Text = "true"
        Form7.Show()
    End Sub
    Public Sub copyitems2()
        Try
            SelectEmails.Show()
            Dim bp As New BackgroundWorker
            AddHandler bp.DoWork, AddressOf copyngiitems
            AddHandler bp.ProgressChanged, AddressOf progresselect
            AddHandler bp.RunWorkerCompleted, AddressOf doneemails
            bp.WorkerReportsProgress = True
            bp.WorkerSupportsCancellation = True
            doemails = "Copiando Emails"
            SelectEmails.worker = bp
            bp.RunWorkerAsync()
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub moveitems2()
        Try
            SelectEmails.Show()

            Dim bp As New BackgroundWorker
            AddHandler bp.DoWork, AddressOf movingitems
            AddHandler bp.ProgressChanged, AddressOf progresselect
            AddHandler bp.RunWorkerCompleted, AddressOf doneemails
            bp.WorkerReportsProgress = True
            bp.WorkerSupportsCancellation = True
            doemails = "Movendo Emails"
            SelectEmails.worker = bp
            bp.RunWorkerAsync()


        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub





    Private Shared Function getPropertyValueFromProperty(control As Object, propertyName As String) As String
        Try
            Dim controlType = control.[GetType]()
            Dim [property] = controlType.GetProperty(propertyName, BindingFlags.[Static] Or BindingFlags.Instance Or BindingFlags.[Public] Or BindingFlags.NonPublic)
            If [property] Is Nothing Then

            End If
            If [property].PropertyType IsNot GetType(String) Then

            End If
            Return DirectCast([property].GetValue(control, Nothing), String)
        Catch ex As Exception
            Return ""
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Function






    Public Sub ArboScrollableListBox2_oncontrolselect(control As ListControlItem) Handles ArboScrollableListBox2.OnControlSelected
        Try



            TimeDelay()
            Dim index As Integer = ArboScrollableListBox2.Items.IndexOf(control)
            indexitem = index

            Dim idmessage As String = control.idmessage
            TimeDelay()
            If Label1.Text = "Caixa De Entrada" And arquivomorto = True Then

                Exit Sub
            End If
            If Label1.Text.Contains("Morto") And arquivomorto = False Then
                MetroMessageBox.Show(Me, "Mensagem não é do arquivo morto atualize a pasta", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            htmlbody = Nothing
            itemmail = idmessage
            EmailReader1.ListView1.Rows.Clear()
            If Label1.Text = "Caixa De Entrada" And arquivomorto = False Then
                Dim found As Boolean = False
                Dim mfrom As String = ""
                Dim subject As String = ""
                Dim mfromadress As String = ""
                Dim displayto As String = ""
                Dim datatimereceived As String = ""
                Dim internentmessageid As String = ""
                Dim messagebody As String = ""
                Dim cc As String = ""
                Dim read As Boolean = False
                Dim hasatt As Boolean = False
                If account IsNot Nothing Then

                    If account.folders(0).items.Count > 0 Then
                        For Each f1 As FolderEmail In account.folders(0).items
                            If f1.name.ToLower.Contains(Label2.Text.ToLower) Then
                                For Each m1 As Email In f1.emails.emails
                                    If m1.idmessage.ToLower.Contains(itemmail.ToLower) Then
                                        found = True

                                        If m1.Html Is Nothing Then

                                            TimeDelay()
                                            mailbox = Label2.Text
                                            seacrhmsgbysubject44()
                                        Else
                                            EmailReader1.CC.Text = ""
                                            messagebody = m1.Html
                                            EmailReader1.read(m1.data.ToString, m1.De, m1.Assunto, m1.Para, m1.CC, Nothing, m1.hasatt)

                                            For Each x1 As String In m1.anexos
                                                EmailReader1.ListView1.Rows.Add({x1, m1.anexosid.Item(m1.anexos.IndexOf(x1))})
                                                EmailReader1.ListView1.Update()
                                            Next

                                            If m1.read = False Then
                                                m1.read = True
                                                reademail()
                                                save()
                                            End If
                                            EmailReader1.WebBrowser1.Navigate("about:blank")
                                            EmailReader1.WebBrowser1.Document.OpenNew(False)
                                            EmailReader1.WebBrowser1.Document.Write(messagebody)
                                            EmailReader1.WebBrowser1.Refresh()
                                            Exit For


                                        End If



                                    End If
                                Next
                            End If
                        Next
                        If found = False Then
                            seacrhmsgbysubject44()
                        End If
                
                        Dim th1 As New BackgroundWorker
                        AddHandler th1.DoWork, AddressOf checkimgatt
                        th1.RunWorkerAsync()
                        EmailReader1.ListView1.Height = EmailReader1.Height - EmailReader1.WebBrowser1.Height - EmailReader1.PictureBox1.Height - EmailReader1.DisplayTo.Height + 10
                    End If



                End If





            Else
                readpst(NaviMain3.treeView1.SelectedNode.Text, idmessage)



            End If
        Catch ex1 As InsufficientExecutionStackException
            EnviarReceber.Task1.adderror(ex1.GetType.ToString, ex1.Message, ex1.StackTrace, Now.ToString)
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function searchfile(ByVal namefile As String) As String
        For Each x As String In IO.Directory.GetFiles(IO.Path.GetTempPath)
            If x.ToLower.Contains(namefile.ToLower) Then
                Return x
                Exit Function
            End If
        Next
        Return ""
    End Function
    Public Function searchfile(ByVal namefile As String, ByVal folder As String) As String
        For Each x As String In IO.Directory.GetFiles(folder)
            If x.ToLower.Contains(namefile.ToLower) Then
                Return x
                Exit Function
            End If
        Next
        Return ""
    End Function
    Public Function FetchLinksFromSource(htmlSource As String) As List(Of String)
        Dim links As New List(Of String)()
        Dim regexImgSrc As String = "<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>"
        Dim matchesImgSrc As MatchCollection = Regex.Matches(htmlSource, regexImgSrc, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        For Each m As Match In matchesImgSrc
            Dim href As String = m.Groups(1).Value
            links.Add(href)
        Next
        Return links
    End Function
    Public Function GetImagesInHTMLString(htmlString As String) As List(Of String)
        Dim images As New List(Of String)()
        Dim pattern As String = "<(img)\b[^>]*>"

        Dim rgx As New Regex(pattern, RegexOptions.IgnoreCase)
        Dim matches As MatchCollection = rgx.Matches(htmlString)

        Dim i As Integer = 0, l As Integer = matches.Count
        While i < l
            images.Add(matches(i).Value)
            i += 1
        End While

        Return images
    End Function

    Private Sub Button1_AutoSizeChanged(sender As Object, e As EventArgs) Handles Button1.AutoSizeChanged

    End Sub







    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If listthread IsNot Nothing And listthread.IsAlive Then
                listthread.Abort()
            End If
            clearlist()
            moreemails.Clear()
            countsearch = 0
            listthread = New Threading.Thread(Sub() startsearch())
            listthread.TrySetApartmentState(Threading.ApartmentState.STA)
            listthread.Start()
            While listthread.IsAlive
                Application.DoEvents()
            End While
            If countsearch > 0 Then


            Else
                MetroMessageBox.Show(Me, "Nenhum Email Achado Pela Chave:" & RichTextBox3.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                importemails(Label2.Text)
            End If


            countsearch = 0

            ' orderlist(True)
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            'MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try

            If BackgroundWorker1.IsBusy Then
                ' BackgroundWorker1.CancelAsync()
            Else
                BackgroundWorker1.RunWorkerAsync()
            End If

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub


    Public Sub sincronizeitems2()
        Try

            Dim pass As String = TextBox2.Text
            Dim user As String = TextBox1.Text
            Dim server As String = TextBox3.Text
            Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
            service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
            service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
            Dim icc As ChangeCollection(Of ItemChange) = service.SyncFolderItems(New FolderId(WellKnownFolderName.Inbox), PropertySet.FirstClassProperties, Nothing, 512, SyncFolderItemsScope.NormalItems, Nothing)
            If (icc.Count = 0) Then
            Else
                For Each ic As ItemChange In icc
                    Dim email As EmailMessage = TryCast(ic.Item, EmailMessage)

                    If email.IsRead = False Then
                        ToolStripStatusLabel1.Text = "Atualizando Pasta..."
                        Dim p5 As New Exchange_Email_ToolsIT.DiffuseDlgDemo.Notification()
                        p5.linkLabel1.Text = email.From.Name
                        p5.label1.Text = email.Subject
                        p5.email = email
                        Me.Invoke(New MethodInvoker(AddressOf p5.Show))
                        checktrhead = New Threading.Thread(Sub() checkemails(Label2.Text))
                        checktrhead.TrySetApartmentState(Threading.ApartmentState.STA)
                        checktrhead.Start()
                        ' Me.Invoke(New SendTextDelegate(AddressOf addnew), email.From.Name.ToString, email.Subject, email.DisplayTo, email.DateTimeReceived, email.InternetMessageId, email.IsRead, email.HasAttachments)

                    End If
                    'TODO: Create item on the client.
                Next

            End If
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub
    Public Sub addnew(ByVal from1 As String, ByVal Subject As String, ByVal displayto As String, ByVal datatime As String, ByVal idmessage As String, ByVal isread As Boolean, ByVal atthas As Boolean)
        Try

            ListControl1.Add(from1, Subject, displayto, datatime, idmessage, isread, atthas)
        Catch ex As Exception
            Me.Invoke(Sub() EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString))
        End Try
    End Sub






    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            sincronizeitems2()
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Try
            Me.Invoke(Sub() ToolStripStatusLabel1.Text = "Pasta Atualizada")
        Catch ex As Exception
            Me.Invoke(Sub() EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString))
        End Try
    End Sub

    Public Sub additem(ByVal controlitem As ListControlItem)

        Try

            Dim mfrom As String = ""
            Dim subject As String = ""
            Dim displayto As String = ""
            Dim datatimereceived As String = ""
            Dim internentmessageid As String = ""
            Dim messagebody As String = ""
            Dim read As Boolean = False
            Dim hasatt As Boolean = False
            Dim foud As Boolean = False
            If controlitem.idmessage IsNot Nothing Then
                internentmessageid = controlitem.idmessage

            Else
                internentmessageid = ""
            End If
       

            If checkemailaccount(controlitem.folder, internentmessageid) = False Then

           
                If controlitem.from IsNot Nothing Then
                    mfrom = controlitem.from
                Else
                    mfrom = ""
                End If
           
                If controlitem.subject IsNot Nothing Then
                    subject = controlitem.subject
                Else
                    subject = ""
                End If
            
        
                If controlitem.displayto IsNot Nothing Then
                    displayto = controlitem.displayto
                Else
                    displayto = ""
                End If
              

                If controlitem.Duration.ToString IsNot Nothing Then
                    datatimereceived = controlitem.Duration.ToString
                Else
                    datatimereceived = ""
                End If
               
                If controlitem.BackColor = Color.Maroon Then
                    read = False
                Else
                    read = True
                End If
              
                If controlitem.PictureBox1.Visible = True Then
                    hasatt = True
                Else
                    hasatt = False
                End If
              
                Dim c2 As New Email

            
                c2.De = mfrom
                
                c2.Assunto = subject
           
                c2.Para = displayto
            
                c2.data = Convert.ToDateTime(datatimereceived)
               
                c2.idmessage = internentmessageid
                
                c2.read = read
              
                c2.hasatt = hasatt
              
                c2.folder = selectfolder
             
                For Each x5 As FolderEmail In account.folders(0).items
                    If x5.name.ToLower.Contains(c2.folder.ToLower) Then
                        For Each m1 As Email In x5.emails.emails
                            If m1.idmessage.ToLower.Contains(c2.idmessage.ToLower) Then
                                foud = True
                                Exit For
                            End If
                        Next
                        If foud = False Then
                            x5.emails.emails.Add(c2)
                            save()
                        End If
                    End If
                Next
         


            End If
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs)
        If listofcontrols.Count > 0 Then
            For Each c As ListControlItem In listofcontrols
                ArboScrollableListBox2.BeginUpdate()
                ArboScrollableListBox2.Items.Add(c)
                AddHandler c.SelectionChanged, AddressOf ArboScrollableListBox2_oncontrolselect
                AddHandler c.DoubleClick, AddressOf ArboScrollableListBox2_doubleclick
                ArboScrollableListBox2.EndUpdate()
            Next
        End If

    End Sub



    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            If moreemails.Count > 0 Then
                MetroButton2.Enabled = True
            End If
            RichTextBox3.Text = ""
            If Label1.Text.Contains("Morto") Then
                selecfolderpst()
                Exit Sub
            End If
            If listthread IsNot Nothing And listthread.IsAlive Then
                listthread.Abort()
            Else
                clearlist()
                selecttreeview()
            End If






        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub VerificarSubPastaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerificarSubPastaToolStripMenuItem.Click
        Try
            If NaviMain3.treeView1.Focused Then




                findfolders4()
                If account IsNot Nothing Then

                    If IO.File.Exists(account.user & "Folders" & ".FL") Then

                        Dim seri As New ObjectSerializer(Of AssetBrowserControl.SerializableTreeView)
                        seri.SaveSerializedObject(NaviMain3.treeView1, account.user & "Folders" & ".FL")

                    End If
                End If
            End If

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub
    Public Sub reademail()

        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text
        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try
            Application.DoEvents()
            Threading.Thread.Sleep(1)
            Dim mfrom As String = ""
            Dim mfromadress As String = ""
            Dim subject As String = ""
            Dim displayto As String = ""
            Dim datatimereceived As String = ""
            Dim internentmessageid As String = ""
            Dim messagebody As String = ""

            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders44, New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, itemmail), New ItemView(5))


            For Each message2 As EmailMessage In foundItems
                TimeDelay()
                message2.Load(New PropertySet({EmailMessageSchema.IsRead}))
                If message2.IsRead = False Then
                    message2.IsRead = True
                    message2.Update(ConflictResolutionMode.AlwaysOverwrite)
                    TimeDelay()

                End If
                Application.DoEvents()
                Threading.Thread.Sleep(1)


            Next
            TimeDelay()
            Dim c As ListControlItem = TryCast(ArboScrollableListBox2.Items(indexitem), ListControlItem)
            c.Panel1.BackColor = Color.DarkBlue

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function getselectnodetext() As String
        If NaviMain3.treeView1.SelectedNode Is Nothing Then
            Return ""
        Else
            Return NaviMain3.treeView1.SelectedNode.FullPath
        End If
    End Function


    Public Function checkemailaccount(ByVal Folder1 As String, ByVal id As String) As Boolean
        Try
            Dim found As Boolean = False
            If account IsNot Nothing Then
                For Each f1 As FolderEmail In account.folders(0).items
                    If Folder1.ToString.ToLower.Contains(f1.name.ToString.ToLower) = True Then
                        If f1.emails.emails IsNot Nothing Then
                            If f1.emails.emails.Count > 0 Then
                                For Each m1 As Email In f1.emails.emails
                                    If m1.idmessage.ToLower.Contains(id.ToLower) Then
                                        found = True
                                        ' If allreadyxists(m1.idmessage, ArboScrollableListBox2.Items) = False Then
                                        'Dim c As ListControlItem = emailtolistcontrolitem(m1)
                                        '  AddHandler c.SelectionChanged, AddressOf ListControl1.SelectionChanged
                                        '  AddHandler c.Click, AddressOf ListControl1.ItemClicked
                                        '  AddHandler c.CheckBox1.CheckedChanged, AddressOf checkchange
                                        '  reloadlistcontrol(c)
                                        '  ArboScrollableListBox2.Update()
                                        ' End If
                                        Exit For

                                    End If

                                Next
                            End If
                        End If
                    End If
                Next
                Return found
            End If
        Catch ex As Exception
            ' Me.Invoke(Sub() EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString))


        End Try

    End Function
    Public Function emailtolistcontrolitem(ByVal m1 As Email) As ListControlItem
        Dim c As New ListControlItem
        Try
            c.Name = "item" & ExtractNumber(m1.idmessage)
            c.from = m1.De
            c.displayto = m1.Para
            c.Duration = m1.data.ToString
            c.idmessage = m1.idmessage
            c.subject = m1.Assunto
            c.PictureBox1.Visible = m1.hasatt

            c.folder = m1.folder

            If m1.read = False Then
                c.Panel1.BackColor = Color.Maroon
            End If
            Return c
        Catch ex As Exception
            Return c
        End Try
    End Function
    Public Function checkemail(ByVal Folder As String, ByVal id As String) As Email
        Try
            If account IsNot Nothing Then
                For Each f1 As FolderEmail In account.folders(0).items
                    If f1.name.ToLower.Contains(Folder.ToLower) Then
                        If f1.emails.emails IsNot Nothing Then
                            If f1.emails.emails.Count > 0 Then
                                For Each m1 As Email In f1.emails.emails
                                    If m1.idmessage.ToLower.Contains(id.ToLower) Then
                                        Return m1
                                        Exit For

                                    End If

                                Next
                            End If
                        End If
                    Else
                    End If
                Next
                Return Nothing
            End If
        Catch ex As Exception
            Me.Invoke(Sub() EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString))

            ' MetroMessageBox.Show(Me, ex.StackTrace & "," & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function

    Public Sub findfolders4()
        Try
            user = TextBox1.Text
            pass = TextBox2.Text
            server = TextBox3.Text
            Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
            service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
            service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
            Try
                Application.DoEvents()

                Dim allFoldersType As ExtendedPropertyDefinition = New ExtendedPropertyDefinition(13825, MapiPropertyType.Integer)
                Dim rootFolderId As FolderId = New FolderId(WellKnownFolderName.Root)
                Dim folderView As FolderView = New FolderView(1000)
                folderView.Traversal = FolderTraversal.Deep
                Dim searchFilter2 As SearchFilter = New SearchFilter.IsEqualTo(FolderSchema.DisplayName, NaviMain3.treeView1.SelectedNode.Text)
                Dim searchFilterCollection As SearchFilter.SearchFilterCollection = New SearchFilter.SearchFilterCollection(LogicalOperator.And)
                searchFilterCollection.Add(searchFilter2)

                Dim findFoldersResults As FindFoldersResults = service.FindFolders(rootFolderId, searchFilterCollection, folderView)

                If findFoldersResults.Folders.Count > 0 Then
                    Dim allItemsFolder As Folder = findFoldersResults.Folders(0)
                    If FindAllSubFolders3(service, allItemsFolder.Id, New TreeNode) = "no" Then
                        MetroMessageBox.Show(Me, "Nenhuma SubPasta Da pasta Encontrada:" & NaviMain3.treeView1.SelectedNode.Text, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If




            Catch ex As ServiceRequestException
                EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            Catch ex As Exception
                EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Function FindAllSubFolders3(ByVal service As ExchangeService, ByVal parentFolderId As FolderId, ByVal node As TreeNode) As String
        Try
            'search for sub folders
            Dim folderView As FolderView = New FolderView(1000)
            Dim foundFolders As FindFoldersResults = service.FindFolders(parentFolderId, folderView)

            ' Add the list to the growing complete list

            If foundFolders.TotalCount > 0 Then
            Else
                Return "no"
                Exit Function
            End If
            ' Now recurse
            For Each folder As Folder In foundFolders
                folder.Load()
                For Each node1 As TreeNode In NaviMain3.treeView1.SelectedNode.Nodes
                    If node1.Text.Contains(folder.DisplayName) Then

                    Else
                        NaviMain3.treeView1.SelectedNode.Nodes.Add(folder.DisplayName)
                        '  getAllFolders2(userconf, navimain3.treeView1.SelectedNode.Text, folder.DisplayName)
                    End If
                Next
                Dim subfolders As String = FindAllSubFolders2(service, folder.Id, node)
                If subfolders <> "no" Then
                    For Each node1 As TreeNode In NaviMain3.treeView1.SelectedNode.Nodes
                        If node1.Text.Contains(subfolders) Then

                        Else
                            NaviMain3.treeView1.SelectedNode.Nodes.Add(subfolders)
                            '  getAllFolders2(userconf, navimain3.treeView1.SelectedNode.Text, folder.DisplayName)
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            Return "no"
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Function
    Public Sub checkchange(sender As Object, e As EventArgs)
        Try
            Dim index2 As Integer = ArboScrollableListBox2.Items.IndexOf(sender.parent)
            Dim c As ListControlItem = TryCast(ArboScrollableListBox2.Items(index2), ListControlItem)
            Dim containsItem As Boolean = False
            Dim indextoremove As String = ""
            If controlstodo.Count > 0 Then
                For Each x As String In controlstodo
                    If x = c.Name Then
                        containsItem = True
                        indextoremove = x
                    End If
                Next
            End If


            If c.CheckBox1.CheckState = CheckState.Checked Then
                If containsItem = True Then
                Else
                    controlstodo.Add(c.Name)
                End If
            Else
                If containsItem = True Then
                    controlstodo.Remove(indextoremove)
                End If
            End If


        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub




    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Try




            '  Dim f As IO.DirectoryInfo = New DirectoryInfo(userconf)
            ' For Each Dir As IO.DirectoryInfo In f.GetDirectories
            '  Dir.Delete(True)
            ' Next
            NaviMain3.treeView1.Nodes.Clear()
            findfolders2()
            start()
            '  GetAllNodes()

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub


    Public Sub ArboScrollableListBox2_doubleclick(sender As Object, e As EventArgs)
        Try
            Dim c As ListControlItem = TryCast(sender, ListControlItem)
            Dim viewer As New EmailViewer



            viewer.WTextBox3.Text = EmailReader1.Subject.Text
            viewer.WTextBox5.Text = EmailReader1.Enviadaem.Text
            viewer.WTextBox4.Text = "De:" & EmailReader1.FromEmail.Text
            viewer.WTextBox2.Text = EmailReader1.DisplayTo.Text
            If EmailReader1.CC.Text <> "" Then
                viewer.WTextBox1.Text = EmailReader1.CC.Text
            End If
            viewer.idmessage = c.idmessage
            viewer.WebBrowser1.DocumentText = EmailReader1.WebBrowser1.DocumentText
            viewer.Folder = Label2.Text
            For Each x1 As DataGridViewRow In EmailReader1.ListView1.Rows
                viewer.MetroGrid1.Rows.Add(x1.Cells(0).Value)

            Next
            Dim th1 As New Threading.Thread(Sub() Application.Run(viewer))

            viewer.Show()

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub


    Public Sub readaccount()

        Try
            If IO.File.Exists("c:\" & user & ".Ews") Then
                Dim seri As New ObjectSerializer(Of User)
                account = seri.GetSerializedObject(user & ".Ews")
                If account Is Nothing Then
                    MetroMessageBox.Show(Me, "Arquivo Corrompido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                For Each x2 As FolderEmail In account.folders.Item(0).items
                    If x2.name.ToLower.Contains(Label2.Text.ToLower) Then
                        For Each x As Email In x2.emails.emails
                            MsgBox(x.Assunto)
                        Next
                        ' Dim newemail As New Email
                        ' newemail.Assunto = EmailReader1.Subject.Text

                        ' newemail.CC = EmailReader1.CC.Text
                        ' newemail.De = "De:" & EmailReader1.FromEmail.Text
                        ' newemail.data = EmailReader1.Enviadaem.Text
                        ' newemail.Para = EmailReader1.DisplayTo.Text
                        ' newemail.Html = EmailReader1.WebBrowser1.DocumentText
                        ' newemail.folder = Label2.Text
                        '  newemail.read = False
                        '  For Each x1 As DataGridViewRow In EmailReader1.ListView1.Rows
                        'newemail.anexos.Rows.Add(x1.Cells(0).Value)

                        '  Next
                        'x2.emails.emails.Add(newemail)

                    End If
                Next
            Else
                IO.File.Create("c:\" & user & ".Ews").Close()
                account = New User
                account.user = user
                account.password = pass
                account.server = server




                Dim folderlist1 As New FolderList

                For Each x1 As TreeNode In NaviMain3.treeView1.Nodes(0).Nodes
                    Dim newf As New FolderEmail
                    newf.name = x1.Text
                    folderlist1.items.Add(newf)

                Next

                account.folders.Add(folderlist1)
                Dim seri As New ObjectSerializer(Of User)
                seri.SaveSerializedObject(account, "c:\" & user & ".Ews")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub openemaileviewer(ByVal idmessage As String)
        Try
            Dim viewer As New EmailViewer

            viewer.WTextBox3.Text = EmailReader1.Subject.Text
            viewer.WTextBox5.Text = EmailReader1.Enviadaem.Text
            viewer.WTextBox4.Text = "De:" & EmailReader1.FromEmail.Text
            viewer.WTextBox2.Text = EmailReader1.DisplayTo.Text
            viewer.WTextBox1.Text = EmailReader1.CC.Text
            viewer.idmessage = idmessage
            viewer.WebBrowser1.DocumentText = EmailReader1.WebBrowser1.DocumentText
            viewer.Folder = Label2.Text
            For Each x1 As DataGridViewRow In EmailReader1.ListView1.Rows
                viewer.MetroGrid1.Rows.Add(x1.Cells(0).Value)

            Next
            Dim th1 As New Threading.Thread(Sub() Application.Run(viewer))

            viewer.Show()
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub




    Private Sub ToolStripProgressBar1_Click(sender As Object, e As EventArgs) Handles ToolStripProgressBar1.Click
        Try
            EnviarReceber.Show()
            EnviarReceber.BringToFront()
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Sub readpstfile()
        Try
            Dim filename As String = ""
            If account IsNot Nothing Then
                If account.PstFile <> "" Then

                    filename = TextBox7.Text
                Else
                    OpenFileDialog1.Filter = "PST Files (.PST)|*.pst"
                    If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Abort Then
                        filename = OpenFileDialog1.FileName
                    End If
                End If
            End If


            If pstfile Is Nothing Then
                pstfile = New PSTFile(filename)
            End If



            Dim stack = New Stack(Of MailFolder)()
            stack.Push(pstfile.TopOfPST)
            NaviMain3.treeView1.Nodes.Clear()

            Dim totalCount = 0
            While stack.Count > 0
                Dim curFolder = stack.Pop()

                For Each child As MailFolder In curFolder.SubFolders
                    stack.Push(child)
                    Dim currentnode As TreeNode = NaviMain3.treeView1.Nodes.Add(child.DisplayName)
                    searchsubfolderspst(currentnode, child)
                Next

            End While






        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub searchsubfolderspst(ByVal node As TreeNode, ByVal folder As MailFolder)
        Try
            If folder.SubFolders.Count > 0 Then
                For Each f As MailFolder In folder.SubFolders

                    Dim node1 As TreeNode = node.Nodes.Add(f.DisplayName)
                    searchsubfolderspst(node1, f)
                Next

            End If
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub

    Public Sub selecfolderpst()
        Try
            arquivomorto = True
            listofcontrols.Clear()
            controlstodo.Clear()

            selectfolder = NaviMain3.treeView1.SelectedNode.Text
            mailbox = NaviMain3.treeView1.SelectedNode.Text
            Label2.Text = NaviMain3.treeView1.SelectedNode.Text





            Do
                If ArboScrollableListBox2.panelControls.Controls.Count = 0 Then Exit Do
                Dim c As ListControlItem = TryCast(ArboScrollableListBox2.panelControls.Controls(0), ListControlItem)
                ArboScrollableListBox2.BeginUpdate()
                ArboScrollableListBox2.Remove(c)
                ' remove the event hook
                RemoveHandler c.SelectionChanged, AddressOf ArboScrollableListBox2_oncontrolselect
                RemoveHandler c.DoubleClick, AddressOf ArboScrollableListBox2_doubleclick
                ' now dispose off properly
                c.Dispose()
                ArboScrollableListBox2.EndUpdate()
            Loop
            findfolderpst(NaviMain3.treeView1.SelectedNode.Text)


            For Each c As ListControlItem In listofcontrols
                ArboScrollableListBox2.BeginUpdate()
                ArboScrollableListBox2.Items.Add(c)
                AddHandler c.SelectionChanged, AddressOf ArboScrollableListBox2_oncontrolselect
                AddHandler c.DoubleClick, AddressOf ArboScrollableListBox2_doubleclick
                ArboScrollableListBox2.EndUpdate()
            Next
            ArboScrollableListBox2.Update()
            '  p.Cancel()
            '  p = Nothing



        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Public Sub findfolderpst(ByVal foldername As String)
        Try
            TimeDelay()
            Dim mfrom As String = ""
            Dim mfromadress As String = ""
            Dim subject As String = ""
            Dim displayto As String = ""
            Dim datatimereceived As String = ""
            Dim internentmessageid As String = ""
            For Each Folder As MailFolder In pstfile.TopOfPST.SubFolders
                If Folder.DisplayName = foldername Then

                    For Each Item1 In Folder



                        If Item1.GetType Is GetType(PSTParse.Message_Layer.Message) Then

                            Dim item As Message = TryCast(Item1, Message)

                            If item.From IsNot Nothing Then
                                mfrom = item.SenderName

                            Else
                                mfrom = "Not Found"
                            End If
                            If item.Subject IsNot Nothing Then
                                subject = item.Subject
                            Else
                                subject = "Not Found"
                            End If
                            If item.To IsNot Nothing Then
                                For Each t As Message_Layer.Recipient In item.To
                                    displayto = displayto & t.DisplayName & ","
                                Next
                            Else
                                displayto = "Not Found"
                            End If
                            If item.LastModificationTime.ToString IsNot Nothing Then
                                datatimereceived = item.LastModificationTime.ToString
                            Else
                                datatimereceived = "Not Found"
                            End If
                            If item.InternetMessageID IsNot Nothing Then
                                internentmessageid = item.InternetMessageID

                            Else
                                internentmessageid = "Not Found"
                            End If


                            ListControl1.Add(mfrom, subject, displayto, datatimereceived.ToString, internentmessageid, item.Read, item.HasAttachments)
                        End If
                    Next


                End If


            Next


        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '  MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Public Sub readpst(ByVal foldername As String, ByVal id As String)
        Try
            TimeDelay()
            Dim mfrom As String = ""
            Dim mfromadress As String = ""
            Dim subject As String = ""
            Dim displayto As String = ""
            Dim datatimereceived As String = ""
            Dim internentmessageid As String = ""
            Dim read As Boolean = True
            Dim hasatt As Boolean = False
            Dim cc As String = ""
            For Each Folder As MailFolder In pstfile.TopOfPST.SubFolders
                If Folder.DisplayName = foldername Then

                    For Each Item1 In Folder



                        If Item1.GetType Is GetType(PSTParse.Message_Layer.Message) Then

                            Dim item As Message = Item1
                            If item.InternetMessageID = id Then
                                If item.From IsNot Nothing Then
                                    mfrom = item.SenderName

                                Else
                                    mfrom = "Not Found"
                                End If
                                If item.Subject IsNot Nothing Then
                                    subject = item.Subject
                                Else
                                    subject = "Not Found"
                                End If
                                If item.To IsNot Nothing Then
                                    For Each t As Message_Layer.Recipient In item.To
                                        displayto = displayto & t.DisplayName & ","
                                    Next
                                Else
                                    displayto = "Not Found"
                                End If
                                If item.LastModificationTime.ToString IsNot Nothing Then
                                    datatimereceived = item.LastModificationTime.ToString
                                Else
                                    datatimereceived = "Not Found"
                                End If
                                If item.InternetMessageID IsNot Nothing Then
                                    internentmessageid = item.InternetMessageID

                                Else
                                    internentmessageid = "Not Found"
                                End If
                                If item.Read.ToString IsNot Nothing Then
                                    read = item.Read
                                End If
                                If item.HasAttachments.ToString IsNot Nothing Then
                                    hasatt = item.HasAttachments
                                End If
                                If item.CC IsNot Nothing Then
                                    For Each t1 As Message_Layer.Recipient In item.CC
                                        cc = cc & t1.DisplayName & ","
                                    Next
                                End If
                                RichTextBox1.Text = item.BodyPlainText

                                EmailReader1.read(datatimereceived.ToString, mfrom, subject, displayto, cc, cc, hasatt)
                                If item.HasAttachments Then
                                    EmailReader1.ListView1.Columns(0).HeaderText = "Anexos:" & item.Attachments.Count

                                    For Each x As PSTParse.Message_Layer.Attachment In item.Attachments
                                        EmailReader1.addattachments(x.Filename, x.LTPRowID)
                                        TimeDelay()

                                        findvalues2(RichTextBox1.Text, x.Filename)


                                    Next

                                End If
                                Dim p As New RTFtoHTML
                                p.rtf = RichTextBox1.Rtf

                                EmailReader1.bodyhtml(p.html)


                                Exit For
                            End If
                        End If
                    Next


                End If


            Next


        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub







    Private Sub MetroComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MetroComboBox1.SelectedIndexChanged
        Try
            If ArboScrollableListBox2.Items.Count > 0 Then
                Dim selecttext As String = MetroComboBox1.SelectedItem.ToString
                If selecttext.Contains("Data") Then
                    orderlist(True)
                End If
                If selecttext.Contains("De") Then
                    ArboScrollableListBox2.BeginUpdate()
                    ArboScrollableListBox2.Items.Sort(Function(x As ListControlItem, y As ListControlItem) x.from.CompareTo(y.from))
                    ArboScrollableListBox2.EndUpdate()
                End If
                If selecttext.Contains("Assunto") Then
                    ArboScrollableListBox2.BeginUpdate()
                    ArboScrollableListBox2.Items.Sort(Function(x As ListControlItem, y As ListControlItem) y.subject.CompareTo(x.subject))
                    ArboScrollableListBox2.EndUpdate()

                End If
                If selecttext.Contains("Anexos") Then
                    ArboScrollableListBox2.BeginUpdate()
                    ArboScrollableListBox2.Items.Sort(Function(x As ListControlItem, y As ListControlItem) y.PictureBox1.Visible.CompareTo(x.PictureBox1.Visible))
                    ArboScrollableListBox2.EndUpdate()

                End If
                If selecttext.Contains("Lido") Then
                    ArboScrollableListBox2.BeginUpdate()
                    ArboScrollableListBox2.Items.Sort(Function(x As ListControlItem, y As ListControlItem) x.Panel1.BackColor.ToArgb.CompareTo(y.Panel1.BackColor.ToArgb))
                    ArboScrollableListBox2.EndUpdate()

                End If
            End If
            ToolStripStatusLabel3.Text = "Items:" & ArboScrollableListBox2.Items.Count
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub


    Private Sub BackgroundWorker2_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork

        Try
            Me.Invoke(Sub() NaviMain3.treeView1.Enabled = False)
            emaildownloading()

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '  MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub emaildownloading()
        Try
            For Each folder1 As String In lisfolders
                foldernow = folder1
                BackgroundWorker2.ReportProgress(1)
                Emailsdownload(folder1)
            Next

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub back_done(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        Try
            Me.Invoke(Sub() NaviMain3.treeView1.Enabled = True)
            DownloadEmails.canclose = True
            DownloadEmails.Close()
            TimeDelay()
            Dim seri2 As New ObjectSerializer(Of User)
            seri2.SaveSerializedObject(account, user & ".Ews")
            If e.Error IsNot Nothing Then
                Dim ex = e.Error
                EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
            End If
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub back_progress(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker2.ProgressChanged
        Try

            DownloadEmails.changetextfolder(foldernow)
            DownloadEmails.changeprogress(e.ProgressPercentage)
            DownloadEmails.changetextemail(emailnow)
            DownloadEmails.MetroLabel5.Text = "Emails:" & foldercountnow
            DownloadEmails.MetroProgressBar2.Maximum = foldercount
            DownloadEmails.changeprogress2(emailsprogressnow)
            If lisfolders.Count = 0 Then
                DownloadEmails.MetroProgressBar1.Maximum = 100
            Else
                DownloadEmails.MetroProgressBar1.Maximum = lisfolders.Count
            End If

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub downloadstartemail(ByVal folder As String)
        Try
            lisfolders.Clear()
            lisfolders.Add(folder)
            If BackgroundWorker2.IsBusy Then
            Else
                BackgroundWorker2.RunWorkerAsync()
            End If
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '  MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub downloadstartemail()
        Try

            lisfolders.Clear()
            For Each node As TreeNode In NaviMain3.treeView1.Nodes
                If node.Nodes.Count = 0 Then
                    lisfolders.Add(node.Text)
                Else
                    For Each node1 As TreeNode In node.Nodes
                        lisfolders.Add(node1.Text)


                    Next
                End If

            Next
            If BackgroundWorker2.IsBusy Then
            Else
                BackgroundWorker2.RunWorkerAsync()
            End If

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '  MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub back_done3(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker3.RunWorkerCompleted
        Try
            If BackgroundWorker3.CancellationPending = True Then
                Exit Sub
            End If

            Me.Invoke(Sub() SelectEmails.Close())
            Me.Invoke(Sub() selecttreeview())


        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub reloadlist()
        Try
            For Each c As ListControlItem In listofcontrols
                ArboScrollableListBox2.BeginUpdate()
                ArboScrollableListBox2.Items.Add(c)
                AddHandler c.SelectionChanged, AddressOf ArboScrollableListBox2_oncontrolselect
                AddHandler c.DoubleClick, AddressOf ArboScrollableListBox2_doubleclick
                ArboScrollableListBox2.EndUpdate()
                additem(c)
            Next
            ToolStripStatusLabel3.Text = "Items:" & ArboScrollableListBox2.Items.Count
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub reloadlist(ByVal c As ListControlItem)
        Try

            ArboScrollableListBox2.BeginUpdate()
            ArboScrollableListBox2.Items.Add(c)
            AddHandler c.SelectionChanged, AddressOf ArboScrollableListBox2_oncontrolselect
            AddHandler c.DoubleClick, AddressOf ArboScrollableListBox2_doubleclick
            ArboScrollableListBox2.EndUpdate()
            additem(c)
            TimeDelay()
            ToolStripStatusLabel3.Text = "Items:" & ArboScrollableListBox2.Items.Count
            TimeDelay()
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub reloadlistcontrol(ByVal c As ListControlItem)
        Try

            ArboScrollableListBox2.BeginUpdate()
            ArboScrollableListBox2.Items.Add(c)
            AddHandler c.SelectionChanged, AddressOf ArboScrollableListBox2_oncontrolselect
            AddHandler c.DoubleClick, AddressOf ArboScrollableListBox2_doubleclick
            ArboScrollableListBox2.EndUpdate()
            additem(c)
            ToolStripStatusLabel3.Text = "Items:" & ArboScrollableListBox2.Items.Count
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub reloadlistcontrol(ByVal c As ListControlItem, ByVal insert As Boolean)
        Try

            ArboScrollableListBox2.BeginUpdate()
            ArboScrollableListBox2.Items.Insert(0, c)
            AddHandler c.SelectionChanged, AddressOf ArboScrollableListBox2_oncontrolselect
            AddHandler c.DoubleClick, AddressOf ArboScrollableListBox2_doubleclick
            ArboScrollableListBox2.EndUpdate()
            additem(c)
            ToolStripStatusLabel3.Text = "Items:" & ArboScrollableListBox2.Items.Count
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub





    Private Sub MetroButton2_Click(sender As Object, e As EventArgs) Handles MetroButton2.Click
        Try

            If moreemails.Count > 0 Then
                clearlist()
                importmoreemails()
                MetroButton2.Enabled = False
                checktrhead = New Threading.Thread(Sub() checkemails(Label2.Text))
                checktrhead.TrySetApartmentState(Threading.ApartmentState.STA)
                checktrhead.Start()

            Else
                MetroButton2.Enabled = False
            End If
      
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub clearlist()
        Try
            Do
                If ArboScrollableListBox2.panelControls.Controls.Count = 0 Then Exit Do
                Dim c As ListControlItem = TryCast(ArboScrollableListBox2.panelControls.Controls(0), ListControlItem)
                ArboScrollableListBox2.BeginUpdate()
                ArboScrollableListBox2.Remove(c)
                ' remove the event hook
                RemoveHandler c.SelectionChanged, AddressOf ArboScrollableListBox2_oncontrolselect
                RemoveHandler c.DoubleClick, AddressOf ArboScrollableListBox2_doubleclick
                ' now dispose off properly
                c.Dispose()
                ArboScrollableListBox2.EndUpdate()
            Loop
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub SaalvarTodoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaalvarTodoToolStripMenuItem.Click
        Try
            SaveFileDialog1.Filter = "Zip|*zip."
            SaveFileDialog1.FilterIndex = 1
            SaveFileDialog1.Title = "Save File"
            SaveFileDialog1.FileName = "Anexos"
            SaveFileDialog1.AddExtension = True
            If SaveFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                Dim file As Ionic.Zip.ZipFile = New Ionic.Zip.ZipFile
                Dim th As New Threading.Thread(Sub() startpwidnows("Salvando Anexos..."))
                th.TrySetApartmentState(Threading.ApartmentState.STA)
                th.Start()
                saveatts()
                Dim rootDirectoryInfo As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(IO.Path.GetTempPath & "Anexos")
                file.AddDirectory(rootDirectoryInfo.FullName)
                'For Each x1 As FileInfo In rootDirectoryInfo.GetFiles
                'file.AddFile(x1.FullName)
                '  Next
                file.Save(SaveFileDialog1.FileName & ".zip")
                th.Abort()
            End If
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub saveatts()
        Try
            user = TextBox1.Text
            pass = TextBox2.Text
            server = TextBox3.Text
            Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
            service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
            service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")


            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders45(Label2.Text), New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, itemmail), New ItemView(5))

            If foundItems.TotalCount = 0 Then


                Exit Sub
            Else
                If IO.Directory.Exists(IO.Path.GetTempPath & "Anexos") Then
                    IO.Directory.Delete(IO.Path.GetTempPath & "Anexos", True)
                    IO.Directory.CreateDirectory(IO.Path.GetTempPath & "Anexos")
                Else
                    IO.Directory.CreateDirectory(IO.Path.GetTempPath & "Anexos")
                End If
            End If
            For Each message As Item In foundItems

                message.Load()

                For j As Integer = 0 To message.Attachments.Count - 1
                    Dim file1 As FileAttachment = CType(message.Attachments(j), FileAttachment)
                    file1.Load()

                    Dim sFilename As String = file1.Name

                    Dim sPathPlusFilename As String = IO.Path.GetTempPath & "Anexos" & "\" & sFilename
                    Dim fileStream As New IO.FileStream(sPathPlusFilename, IO.FileMode.Create)
                    Dim buffer As Byte() = file1.Content
                    fileStream.Write(buffer, 0, buffer.Length)
                    fileStream.Close()
                Next
            Next
            '  End If

        Catch ex As Exception

            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message & ex.StackTrace, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MostrarTodosAnexosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostrarTodosAnexosToolStripMenuItem.Click
        EmailReader1.ListView1.Height = EmailReader1.Height - EmailReader1.WebBrowser1.Height - EmailReader1.PictureBox1.Height - EmailReader1.DisplayTo.Height
    End Sub
    Private Sub copyControl(sourceControl As Control, targetControl As Control)
        ' make sure these are the same
        If sourceControl.[GetType]() <> targetControl.[GetType]() Then
            ' Throw New Exception("Incorrect control types")
        End If

        For Each sourceProperty As PropertyInfo In sourceControl.[GetType]().GetProperties()
            Dim newValue As Object = sourceProperty.GetValue(sourceControl, Nothing)

            Dim mi As MethodInfo = sourceProperty.GetSetMethod(True)
            If mi IsNot Nothing Then
                sourceProperty.SetValue(targetControl, newValue, Nothing)
            End If
        Next
    End Sub

    Private Sub BackgroundWorker4_DoWork(sender As Object, e As DoWorkEventArgs)
        Try
            Me.Invoke(Sub() startimport())
        Catch ex As Exception

        End Try
    End Sub

    Public Sub checklistemails()
        Try
            SelectEmails.Show()
            SelectEmails.worker = BackgroundWorker3
            AddHandler BackgroundWorker3.ProgressChanged, AddressOf progresselect2
            doemails = "Verificando se algum email esta Faltando ou Esta Inexistente..."
            BackgroundWorker3.RunWorkerAsync()
        Catch ex As Exception

        End Try

    End Sub
    Public Sub checkemails(ByVal folder As String)

        user = TextBox1.Text
        pass = TextBox2.Text
        server = TextBox3.Text
        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try



            Dim mfrom As String = ""
            Dim mfromadress As String = ""
            Dim subject As String = ""
            Dim displayto As String = ""
            Dim datatimereceived As String = ""
            Dim internentmessageid As String = ""
            Dim messagebody As String = ""
            Dim offset As Integer = 0
            Dim pageSize As Integer = 1000
            Dim view As New ItemView(pageSize, offset, OffsetBasePoint.Beginning)
            Dim findResults As FindItemsResults(Of Item)
            findResults = service.FindItems(findfolders45(folder), view)
            For Each message As Item In findResults
                Dim foud As Boolean = False
                Dim item As EmailMessage = TryCast(message, EmailMessage)
                internentmessageid = item.InternetMessageId
          

                If checkemailaccount(folder, internentmessageid) = False Then
                    message.Load()

                    message.Body.BodyType = BodyType.HTML


                    If message.Body Is Nothing Then
                        message.Body.BodyType = BodyType.Text
                    End If
                    Dim cc As String = ""
                    If message.DisplayCc <> "" Then
                        cc = message.DisplayCc
                    Else
                        cc = ""
                    End If

                    If item.From IsNot Nothing Then
                        mfrom = item.From.Name
                        mfromadress = item.From.Address

                    Else
                        mfrom = ""
                        mfromadress = ""
                    End If
                    If item.Subject IsNot Nothing Then
                        subject = item.Subject
                    Else
                        subject = ""
                    End If
                    If item.DisplayTo IsNot Nothing Then
                        displayto = item.DisplayTo
                    Else
                        displayto = ""
                    End If
                    If item.DateTimeReceived.ToString IsNot Nothing Then
                        datatimereceived = item.DateTimeReceived.ToString
                    Else
                        datatimereceived = ""
                    End If



                    messagebody = message.Body
                    Dim c2 As New Email


                    c2.De = mfrom
                    c2.Assunto = subject
                    c2.Para = displayto
                    c2.data = datatimereceived
                    c2.idmessage = internentmessageid
                    c2.read = item.IsRead
                    c2.hasatt = item.HasAttachments
                    c2.folder = folder
                    c2.Html = messagebody
                    c2.CC = cc
                    For Each x5 As FolderEmail In account.folders(0).items
                        If x5.name.ToLower.Contains(c2.folder.ToLower) Then
                            For Each m1 As Email In x5.emails.emails
                                If m1.idmessage.ToLower.Contains(c2.idmessage.ToLower) Then
                                    foud = True
                                    Exit For
                                End If
                            Next

                            If foud = False Then
                                x5.emails.emails.Add(c2)
                                save()
                                Dim c As ListControlItem = emailtolistcontrolitem(c2)
                                If c IsNot Nothing Then
                                    Dim canadd As Boolean = False
                                    If c.folder <> "" Then

                                        If allreadyxists(c.idmessage, ArboScrollableListBox2.Items) = False Then
                                            canadd = True

                                        Else
                                            canadd = False


                                        End If
                                    End If

                                    If canadd = True And allreadyxists(c.idmessage, ArboScrollableListBox2.Items) = False And ArboScrollableListBox2.Items.Count < 1000 Then

                                        AddHandler c.SelectionChanged, AddressOf ListControl1.SelectionChanged
                                        AddHandler c.Click, AddressOf ListControl1.ItemClicked
                                        AddHandler c.CheckBox1.CheckedChanged, AddressOf checkchange
                                        reloadlistcontrol(c)
                                        Me.Invoke(Sub() orderlist(True))
                                    End If

                                End If

                            End If
                        End If
                    Next


                    For j As Integer = 0 To message.Attachments.Count - 1

                        Dim fileAttachment As Object
                        If message.Attachments(j).GetType() Is GetType(FileAttachment) Then
                            fileAttachment = CType(message.Attachments(j), FileAttachment)
                        Else
                            fileAttachment = CType(message.Attachments(j), ItemAttachment)
                        End If

                        '  addattachaments(fileAttachment.Name, fileAttachment.Id)


                        For Each f1 As FolderEmail In account.folders(0).items
                            If f1.name.ToLower.Contains(folder.ToLower) Then
                                For Each m1 As Email In f1.emails.emails
                                    If m1.idmessage.ToLower.Contains(internentmessageid.ToLower) Then
                                        m1.anexos.Add(fileAttachment.Name)
                                        m1.anexosid.Add(fileAttachment.Id)
                                    End If
                                Next

                            End If
                        Next
                        save()
                    Next

                End If

            Next


            For Each c1 As ListControlItem In ArboScrollableListBox2.Items
                If CheckemailOnline(c1.idmessage, folder) = False Then
                    For Each x5 As FolderEmail In account.folders(0).items
                        If x5.name.ToLower.Contains(folder.ToLower) Then
                            For Each m1 As Email In x5.emails.emails
                                If m1.idmessage.ToLower.Contains(c1.idmessage.ToLower) Then
                                    Me.Invoke(Sub() deletefromfolderaccount(m1, Label2.Text))
                                    Me.Invoke(Sub() clearlist(c1))
                                    Exit For
                                End If
                            Next


                        End If

                    Next
                End If
            Next








        Catch ex As Exception
            'Me.Invoke(Sub() EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString))

            ' MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub



    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub BackgroundWorker3_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker3.DoWork

    End Sub

    Private Sub navimain3_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Click(sender As Object, e As EventArgs) Handles Me.Click

    End Sub

    Private Sub BaixarEmaiNovamenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BaixarEmaiNovamenteToolStripMenuItem.Click
        Try
            seacrhmsgbysubject44()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Try

        Catch ex As Exception

        End Try
    End Sub


End Class


