Imports MetroFramework
Imports Microsoft.Exchange.WebServices.Data
Imports System.Net
Imports System.ComponentModel

Public Class EmailViewer
    Dim user As String = Form1.TextBox1.Text
    Dim pass As String = Form1.TextBox2.Text
    Dim server As String = Form1.TextBox3.Text
    Dim htmlbody As String = ""


    Public Property idmessage As String = ""
    Public Property Folder As String = ""

    Private Sub MetroTile1_Click(sender As Object, e As EventArgs) Handles MetroTile1.Click
        Try
            Form1.WebBrowser1.DocumentText = "<html><br>" & "De:" & WTextBox3.Text & "Para:" & WTextBox2.Text & "<br>" & "CC:" & WTextBox1.Text & "<br>" _
               & "Assunto:" & WTextBox3.Text & "<br>" & "Enviada em:" & WTextBox5.Text & "<html/>" & WebBrowser1.DocumentText
            Form1.WebBrowser1.ShowPrintPreviewDialog()



        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub Responder(ByVal form As Form2)




        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try
            ' TimeDelay()
            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders45(Folder), New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, idmessage), New ItemView(5))
            For Each message As Item In foundItems
                message.Load()
                message.Body.BodyType = BodyType.HTML

                Dim test As String = message.DisplayTo.ToString
                Dim senderEmail As String = CType(message, EmailMessage).From.Address
                Dim recp2 As Integer = CType(message, EmailMessage).ToRecipients.Count
                For l As Integer = 0 To recp2 - 1
                    Dim recpEmail As String = CType(message, EmailMessage).ToRecipients.Item(l).Address
                    If recpEmail.IndexOf(user, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                    Else
                        form.RichTextBox2.AppendText(recpEmail & Space(2))
                    End If
                Next

                form.RichTextBox2.AppendText(senderEmail & Space(2))
                Dim recp3 As Integer = CType(message, EmailMessage).CcRecipients.Count
                For l As Integer = 0 To recp3 - 1
                    Dim recpEmail1 As String = CType(message, EmailMessage).CcRecipients.Item(l).Address
                    If recpEmail1.IndexOf(user, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                    Else
                        form.RichTextBox3.AppendText(recpEmail1 & Space(2))
                    End If
                Next

                If message.Subject <> "" Then
                    form.RichTextBox4.Text = "RES:" & message.Subject
                End If

                If WebBrowser1.Document.Body.InnerHtml <> "" Then
                    htmlbody = WebBrowser1.Document.Body.InnerHtml
                Else
                    htmlbody = message.Body
                End If

            Next
            ' Dim Path As String = Application.StartupPath & "\" & Form1.account.assinatura
            ' Form2.Editor1.webBrowser1.Document.Body.InnerHtml = "<html><br><br><br><br><br><br><br><html/>" & "<img src='" & Path & "' />" & "<html><br><br><br><html/>" & htmlbody
            'form.Editor1.webBrowser1.DocumentText = "<html><br><br><br><br><br><br><br><html/>" & "<img src='" & Path & "' />" & "<html><br><br><br><html/>" & htmlbody
            If Form1.account.assinatura IsNot Nothing And Form1.account.assinatura <> "" Then
                Dim Path As String = Application.StartupPath & "\" & Form1.account.assinatura
                form.Editor1.webBrowser1.DocumentText = "<html><br><br><br><br><br><br><br><html/>" & "<img src='" & Path & "' />" & "<html><br><br><br><html/>" & htmlbody
            Else
                form.Editor1.webBrowser1.DocumentText = "<html><br><br><br><html/>" & htmlbody
            End If


        Catch ex As ServiceRequestException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As WebException
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Public Function findfolders45(ByVal namefolder As String) As FolderId

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

    Public Sub startpwidnows()
        Try
            Dim h As New ProgresWindows
            Application.Run(h)
        Catch ex As Exception
            'EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub

    Private Sub MetroTile2_Click(sender As Object, e As EventArgs) Handles MetroTile2.Click
        Try
            Dim th As New Threading.Thread(Sub() startpwidnows())
            th.TrySetApartmentState(Threading.ApartmentState.STA)
            th.Start()
            Dim form3 As New Form2
            Responder(form3)
            th.Abort()
            Dim th1 As New Threading.Thread(Sub() Application.Run(form3))

            form3.Show()
        Catch ex As Exception
            'EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub
    Public Sub EncaminharEmail(ByVal form As Form2)




        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
        Try


            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders45(Folder), New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, idmessage), New ItemView(5))

            For Each message As Item In foundItems
                message.Load()
                message.Body.BodyType = BodyType.HTML
                Dim senderEmail As String = CType(message, EmailMessage).From.Address
                If message.Subject <> "" Then
                    form.RichTextBox4.Text = "ENC:" & message.Subject
                End If

                If WebBrowser1.Document.Body.InnerHtml <> "" Then
                    htmlbody = WebBrowser1.Document.Body.InnerHtml
                Else
                    htmlbody = message.Body
                End If
                Dim htmlbefore As String = "<html><br>" & "De:" & senderEmail & "<br>" & "Para:" & message.DisplayTo & "<br>" & "CC:" & message.DisplayCc & "<br>" _
& "Assunto:" & message.IsSubmitted & "<br>" & "Enviada em:" & message.DateTimeReceived & "<html/>" & "<html><br><br><br><html/>"
                If Form1.account.assinatura IsNot Nothing And Form1.account.assinatura <> "" Then
                    Dim Path As String = Application.StartupPath & "\" & Form1.account.assinatura
                    form.Editor1.webBrowser1.Document.Body.InnerHtml = "<html><br><br><br><br><br><br><br><html/>" & "<img src='" & Path & "' />" & "<html><br><br><br><html/>" & htmlbefore & "<html><br><br><br><html/>" & htmlbody
                Else
                    form.Editor1.webBrowser1.Document.Body.InnerHtml = "<html><br><br><br><html/>" & htmlbefore & "<html><br><br><br><html/>" & htmlbody
                End If
                If message.Attachments.Count = 0 Then

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
                        Application.DoEvents()
                        Threading.Thread.Sleep(1)
                        Form1.saveatt(fileAttachment.Name, fileAttachment)
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

    Private Sub MetroTile4_Click(sender As Object, e As EventArgs) Handles MetroTile4.Click
        Try
            Dim th As New Threading.Thread(Sub() startpwidnows())
            th.TrySetApartmentState(Threading.ApartmentState.STA)
            th.Start()
            Dim form3 As New Form2
            EncaminharEmail(form3)
            th.Abort()
            Dim th1 As New Threading.Thread(Sub() Application.Run(form3))

            form3.Show()
        Catch ex As Exception
            'EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub
    Public Sub Responderatodos(ByVal form As Form2)




        Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
        service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
        service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")

        Try
    

            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders45(Folder), New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, idmessage), New ItemView(5))

            For Each message As Item In foundItems
                message.Load()
                message.Body.BodyType = BodyType.HTML

                Dim test As String = message.DisplayTo.ToString
                Dim senderEmail As String = CType(message, EmailMessage).From.Address
                Dim recp2 As Integer = CType(message, EmailMessage).ToRecipients.Count
                For l As Integer = 0 To recp2 - 1
                    Dim recpEmail As String = CType(message, EmailMessage).ToRecipients.Item(l).Address
                    If recpEmail.IndexOf(user, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                    Else
                        form.RichTextBox2.AppendText(recpEmail & Space(2))
                    End If
                Next

                form.RichTextBox2.AppendText(senderEmail & Space(2))
                Dim recp3 As Integer = CType(message, EmailMessage).CcRecipients.Count
                For l As Integer = 0 To recp3 - 1
                    Dim recpEmail1 As String = CType(message, EmailMessage).CcRecipients.Item(l).Address
                    If recpEmail1.IndexOf(user, 0, StringComparison.CurrentCultureIgnoreCase) > -1 Then
                    Else
                        form.RichTextBox3.AppendText(recpEmail1 & Space(2))
                    End If
                Next

                If message.Subject <> "" Then
                    form.RichTextBox4.Text = "RES:" & message.Subject
                End If

                If WebBrowser1.Document.Body.InnerHtml <> "" Then
                    htmlbody = WebBrowser1.Document.Body.InnerHtml
                Else
                    htmlbody = message.Body
                End If
                If Form1.account.assinatura IsNot Nothing And Form1.account.assinatura <> "" Then
                    Dim Path As String = Application.StartupPath & "\" & Form1.account.assinatura
                    form.Editor1.webBrowser1.DocumentText = "<html><br><br><br><br><br><br><br><html/>" & "<img src='" & Path & "' />" & "<html><br><br><br><html/>" & htmlbody
                Else
                    form.Editor1.webBrowser1.DocumentText = "<html><br><br><br><html/>" & htmlbody
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

    Private Sub MetroTile3_Click(sender As Object, e As EventArgs) Handles MetroTile3.Click
        Try
            Dim th As New Threading.Thread(Sub() startpwidnows())
            th.TrySetApartmentState(Threading.ApartmentState.STA)
            th.Start()
            Dim form3 As New Form2
            Responderatodos(form3)
            th.Abort()
            Dim th1 As New Threading.Thread(Sub() Application.Run(form3))

            form3.Show()
        Catch ex As Exception
            'EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub

  
    Public Sub checkimgatt()
        Try



            Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
            service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
            service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")


            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders45(Folder), New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, idmessage), New ItemView(5))

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
                        If IO.File.Exists(sPathPlusFilename) And Me.Invoke(Function() WebBrowser1.DocumentText.Contains(IO.Path.GetFileName(sPathPlusFilename))) = False Then
                            Me.Invoke(Sub() WebBrowser1.DocumentText = WebBrowser1.DocumentText.Replace(oldString, "file://" & sPathPlusFilename))
                        Else
                            Dim fileStream As New IO.FileStream(sPathPlusFilename, IO.FileMode.Create)
                            Dim buffer As Byte() = file1.Content
                            fileStream.Write(buffer, 0, buffer.Length)
                            fileStream.Close()
                            Me.Invoke(Sub() WebBrowser1.DocumentText = WebBrowser1.DocumentText.Replace(oldString, "file://" & sPathPlusFilename))
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

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Try
            Dim th1 As New BackgroundWorker
            AddHandler th1.DoWork, AddressOf checkimgatt
            th1.RunWorkerAsync()
        Catch ex As Exception

            Me.Invoke(Sub() EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString))

            ' MetroMessageBox.Show(Me, ex.Message & ex.StackTrace, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SalvarComoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalvarComoToolStripMenuItem.Click
        Try

            Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
            service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
            service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
            Dim filename As String = MetroGrid1.SelectedRows(0).Cells(0).Value.ToString
            If filename <> "" Then
                SaveFileDialog1.Filter = "All|*."
                SaveFileDialog1.FilterIndex = 1
                SaveFileDialog1.Title = "Save File"
                SaveFileDialog1.AddExtension = True
                SaveFileDialog1.FileName = filename
                If SaveFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then




                    Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders45(Folder), New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, idmessage), New ItemView(5))

                    If foundItems.TotalCount = 0 Then


                        Exit Sub
                    End If
                    Dim th As New Threading.Thread(Sub() startpwidnows("Salvando Anexo..."))
                    th.TrySetApartmentState(Threading.ApartmentState.STA)
                    th.Start()
                    For Each message As Item In foundItems
                        message.Load()
                        For j As Integer = 0 To message.Attachments.Count - 1
                            Dim fileAttachment As FileAttachment = CType(message.Attachments(j), FileAttachment)
                            If fileAttachment.Name.Contains(filename) Then


                                fileAttachment.Load()

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

    Private Sub AbrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirToolStripMenuItem.Click
        Try



            Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
            service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
            service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
            Dim filename As String = MetroGrid1.SelectedRows(0).Cells(0).Value.ToString
            If filename <> Nothing Then

                ' If selectfolder = Nothing Then
                'selectfolder = WellKnownFolderName.Inbox
                'End If
                If IO.File.Exists(IO.Path.GetTempPath & filename) Then
                    Process.Start(IO.Path.GetTempPath & "\" & filename)


                    Exit Sub
                End If
                Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders45(Folder), New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, idmessage), New ItemView(5))

                If foundItems.TotalCount = 0 Then


                    Exit Sub
                End If
                Dim th As New Threading.Thread(Sub() startpwidnows("Abrindo Anexo..."))
                th.TrySetApartmentState(Threading.ApartmentState.STA)
                th.Start()
                For Each message As Item In foundItems

                    message.Load()
                    For j As Integer = 0 To message.Attachments.Count - 1
                        Dim fileAttachment As FileAttachment = CType(message.Attachments(j), FileAttachment)

                        If fileAttachment.Name.Trim.ToLower.Contains(filename.Trim.ToLower) Then
                            fileAttachment.Load()
                            Dim fileAttachment3 As FileAttachment = DirectCast(fileAttachment, FileAttachment)
                            If IO.File.Exists(IO.Path.GetTempPath & filename) Then
                                IO.File.Delete(IO.Path.GetTempPath & filename)
                            End If

                            Dim fileStream As New IO.FileStream(IO.Path.GetTempPath & filename, IO.FileMode.Create)
                            Dim buffer As Byte() = fileAttachment3.Content
                            fileStream.Write(buffer, 0, buffer.Length)
                            fileStream.Close()

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
  
            Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
            service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
            service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")


            Dim foundItems As FindItemsResults(Of Item) = service.FindItems(findfolders45(Folder), New SearchFilter.IsEqualTo(EmailMessageSchema.InternetMessageId, idmessage), New ItemView(5))

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
    Public Sub startpwidnows(ByVal text As String)
        Try
            Dim h As New ProgresWindows
            h.MetroLabel1.Text = text
            Application.Run(h)
        Catch ex As Exception
            'EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub

    Private Sub EmailViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class