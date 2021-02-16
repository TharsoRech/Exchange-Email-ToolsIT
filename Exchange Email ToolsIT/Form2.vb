Imports System.Drawing.Font
Imports System.Drawing.FontFamily
Imports System.Drawing.FontConverter
Imports AutocompleteMenuNS
Imports System.Text.RegularExpressions
Imports MetroFramework
Imports System.DirectoryServices
Imports Microsoft.Exchange.WebServices.Data

Public Class Form2
    Dim h As Boolean = False
    Private _Occurences As Integer
    Public attsinline As List(Of String) = New List(Of String)

    Private Sub BindCombo()
        Try
 
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '  MetroMessageBox.Show(Me, ex.Message,me.text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

   

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
       
            listemailusers()

            RichTextBox5.Enabled = False
       
        Catch ex As Exception
        End Try
    End Sub



   
    Public Sub imageshtlm()
        For Each img As HtmlElement In Editor1.webBrowser1.Document.Images
            Dim filename As String = Between(After(img.OuterHtml, "src="), """", """")
            '  Dim newatt As FileAttachment = Message.Attachments.AddFileAttachment(IO.Path.GetFileName(filename), filename)
            ' newatt.IsInline = True
            '  newatt.ContentId = IO.Path.GetFileName(filename)
            Editor1.webBrowser1.Document.Body.InnerHtml = Editor1.webBrowser1.Document.Body.InnerHtml.Replace(filename, "Cid:" & IO.Path.GetFileName(filename))
            ' MsgBox(Form2.Editor1.webBrowser1.Document.Body.InnerHtml)
        Next

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







    Public Sub CopyFromRichTextBox(ByVal rtb As RichTextBox, _
    Optional ByVal availableAfterEnd As Boolean = False)
        On Error Resume Next
        Dim data As New DataObject()

        ' get the selected RTF text if there is a selection,
        ' or the entire text is no text is selected
        Dim rtfText, plainText As String
        If rtb.SelectionLength > 0 Then
            rtfText = rtb.SelectedRtf
            plainText = rtb.SelectedText
        Else
            rtfText = rtb.Rtf
            plainText = rtb.Text
        End If
        ' do the copy only if there is something to be copied
        If rtfText.Length > 0 Then data.SetData(DataFormats.Rtf, rtfText)
        If plainText.Length > 0 Then data.SetData(DataFormats.Text, plainText)

        ' finally copy into the clipboard
        Clipboard.SetDataObject(data, availableAfterEnd)
    End Sub



    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Try
            Form3.Show()
            Form3.forming = Me
        Catch ex As Exception
         
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form3.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form3.Show()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Try
            Dim fname As String
            OpenFileDialog1.Filter = "All Files (*.*)|*.*"
            OpenFileDialog1.Title = "Inserir Anexo"
            OpenFileDialog1.Multiselect = True
            OpenFileDialog1.FileName = ""
            If OpenFileDialog1.ShowDialog = DialogResult.OK Then

                For Each fname In OpenFileDialog1.FileNames
                    Dim namefile As String
                    namefile = IO.Path.GetFileName(fname)
                    RichTextBox5.SelectionLength = 1
                    RichTextBox5.SelectedText = namefile + ";" & Space(2)
                    ListBox2.Items.Add(fname)

                Next

            End If
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message,me.text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim fname As String
            OpenFileDialog1.Filter = "All Files (*.*)|*.*"
            OpenFileDialog1.Title = "Inserir Anexo"
            OpenFileDialog1.Multiselect = True
            OpenFileDialog1.FileName = ""
            If OpenFileDialog1.ShowDialog = DialogResult.OK Then

                For Each fname In OpenFileDialog1.FileNames
                    Dim namefile As String
                    namefile = IO.Path.GetFileName(fname)
                    RichTextBox5.SelectionLength = 1
                    RichTextBox5.SelectedText = namefile + ";" & Space(2)
                    ListBox2.Items.Add(fname)


                Next

            End If
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            ' MetroMessageBox.Show(Me, ex.Message,me.text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RichTextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox2.TextChanged
        Try
            Dim AutocompleteMenu1 As New AutocompleteMenu
            Dim AutocompleteItem1 As New AutocompleteItem
            For l_index As Integer = 0 To ListBox1.Items.Count - 1
                Dim l_text As String = CStr(ListBox1.Items(l_index).ToString)
                AutocompleteMenu1.AddItem(l_text)
            Next
            AutocompleteMenu1.Show(RichTextBox2, False)
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '  MetroMessageBox.Show(Me, ex.Message,me.text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Function Compare(ByVal fragmentText As String) As CompareResult
        Try
            If (fragmentText = Text) Then
                Return CompareResult.VisibleAndSelected
            End If
            If fragmentText.Contains(RichTextBox2.Text) Or fragmentText.Contains(RichTextBox3.Text) Then
                Return CompareResult.Visible
            End If
            Return CompareResult.Hidden
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            '  MetroMessageBox.Show(Me, ex.Message,me.text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function









    Private Sub RichTextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox3.TextChanged
        Try
            Dim AutocompleteMenu1 As New AutocompleteMenu
            Dim AutocompleteItem1 As New AutocompleteItem


            For l_index As Integer = 0 To ListBox1.Items.Count - 1
                Dim l_text As String = CStr(ListBox1.Items(l_index).ToString)
                AutocompleteMenu1.AddItem(l_text)
            Next
            AutocompleteMenu1.Show(RichTextBox3, False)
            h = True
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub

    Public Sub listemailusers()

        Try
            listsendcontacts()
            Dim userName As String = Environment.UserName
            Dim domainName As String = Environment.UserDomainName
            Dim entry As DirectoryServices.DirectoryEntry = New DirectoryServices.DirectoryEntry("LDAP://" & domainName & "")
            Dim dSearch As DirectoryServices.DirectorySearcher = New DirectoryServices.DirectorySearcher(entry)
            dSearch.Filter = "(objectClass=user)"
            For Each sResultSet As DirectoryServices.SearchResult In dSearch.FindAll()
                If (sResultSet.Properties("mail").Count > 0) Then
                    ' AutocompleteMenu1.AddItem(((sResultSet.Properties("mail")(0).ToString)))
                    'AutocompleteMenu1.AddItem(New SnippetAutocompleteItem(sResultSet.Properties("mail")(0).ToString))

                    ListBox1.Items.Add(New SnippetAutocompleteItem(sResultSet.Properties("mail")(0).ToString))

                End If
            Next

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
            ' MetroMessageBox.Show(Me, ex.StackTrace, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        Try

            Dim t10 As New TaskControl
            t10.form = Me
            t10.Parent = EnviarReceber.Task1.ArboScrollableListBox1.panelControls
            EnviarReceber.Task1.ArboScrollableListBox1.BeginUpdate()
            EnviarReceber.Task1.ArboScrollableListBox1.Items.Add(t10)
            EnviarReceber.Task1.ArboScrollableListBox1.EndUpdate()

            EnviarReceber.Show()
            EnviarReceber.BringToFront()
            EnviarReceber.Task1.TabPage1.Show()
            t10.start()
        Catch ex As Exception
            Me.Invoke(Sub() EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString))
            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try


            ListBox2.Items.Clear()
            RichTextBox5.Text = ""

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub
    Public Sub prepare()
        For Each img As HtmlElement In Editor1.webBrowser1.Document.Images
            Dim filename As String = Between(After(img.OuterHtml, "src="), """", """")
            Editor1.webBrowser1.Document.Body.InnerHtml = Editor1.webBrowser1.Document.Body.InnerHtml.Replace(filename, "Cid:" & IO.Path.GetFileName(filename))
        Next

        Dim hasexit As Boolean = False
        While hasexit = False
            imageshtlm()
            Dim hasexit2 As Boolean = False
            For Each img As HtmlElement In Editor1.webBrowser1.Document.Images
                Dim filename As String = Between(After(img.OuterHtml, "src="), """", """")
                If filename.ToLower.Contains("file".ToLower) Then
                    hasexit2 = False
                    Exit For
                Else
                    hasexit2 = True
                End If
            Next
            If hasexit2 = True Then
                For Each img As HtmlElement In Editor1.webBrowser1.Document.Images
                    Dim filename As String = Between(img.OuterHtml, "IMG", "src")
                    If filename <> "" Then
                        Editor1.webBrowser1.Document.Body.InnerHtml = Editor1.webBrowser1.Document.Body.InnerHtml.Replace(filename, Space(2) & "")
                    End If
                Next
                hasexit = True
            Else
                Exit Sub
            End If
        End While
    End Sub
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
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'searchtxt3()
            searchtxt()
        Catch ex As Exception

        End Try
    End Sub


    Public Sub searchtxt3()
        Try
            Dim word As String = RichTextBox2.Text
            Dim wordArr As String() = word.Split(";")
            For l As Integer = 0 To wordArr.Length - 1
                Dim result As String = wordArr(l)
                If wordArr(l).Contains("@") Then


                End If
            Next
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

        End Try
    End Sub
    Public Sub searchtxt()
        Try
            Dim s As String = RichTextBox2.Text

            ' Split string based on spaces
            Dim words As String() = s.Split(New Char() {" "c})

            ' Use For Each loop over words and display them
            Dim word As String
            For Each word In words

            Next
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try

    End Sub












    Public Sub listsendcontacts()
        Try
            Dim filepath As String = "ContactsSend.txt"
            If IO.File.Exists(filepath) Then
                Dim allLines() As String = IO.File.ReadAllLines(filepath)
                For Each line As String In allLines


                    Dim s As String = line
                    ' Split string based on spaces
                    Dim words As String() = s.Split(New Char() {" "c})
                    ' Use For Each loop over words and display them
                    Dim word As String
                    If s <> "" Then
                        For Each word In words
                            If word.Contains("@") Then
                                ListBox1.Items.Add(word)
                            End If
                        Next
                    End If
                Next
            End If
        Catch ex As Exception
        End Try

    End Sub


    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Form1.SpellChecker.Text = Editor1.Document.Body.InnerText
            Form1.SpellChecker.SpellCheck()
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
            '  MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Try
            Dim th As New Threading.Thread(Sub() Form1.startpwidnows("Salvando em Rascunhos..."))
            th.TrySetApartmentState(Threading.ApartmentState.STA)
            th.Start()
            Form1.saveemailstodraft()
            th.Abort()
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
            '  MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


   
End Class