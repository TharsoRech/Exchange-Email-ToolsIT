Imports Microsoft.Exchange.WebServices.Data
Imports MetroFramework
Imports System.Net
Imports System.Windows.Forms.Form
Imports Wisder.W3Common.WMetroControl.Controls.MetroUserControl
Imports ARBOControls.ARBOScrollableListBox

Public Class TaskControl
    Public form As Form2
    Public thmessage As Threading.Thread
    Dim user As String = Form1.TextBox1.Text
    Dim pass As String = Form1.TextBox2.Text
    Dim server As String = Form1.TextBox3.Text
 

    Public Sub start()
        Try
    
            thmessage = New Threading.Thread(AddressOf sendmessage)
            thmessage.TrySetApartmentState(Threading.ApartmentState.STA)
            thmessage.Start()
        Catch ex As Exception
            Me.Invoke(Sub() EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString))
            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Public Function returntext(ByVal control As Control) As String
        Try
            Return control.Text
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Sub sendmessage()
        Try
        

            Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
            service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
            service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")





            Me.Invoke(Sub() WTextBox1.Text = "Enviando Email...")

            Dim s As String = Me.Invoke(Function() returntext(form.RichTextBox2))
            Dim s1 As String = Me.Invoke(Function() returntext(form.RichTextBox3))
            ' Split string based on spaces
            Dim words As String() = s.Split(New Char() {" "c})
            Dim words1 As String() = s1.Split(New Char() {" "c})
            ' Use For Each loop over words and display them
            Dim word As String
            Dim word1 As String
            'Create message in the Drafts folder    

            Dim message As New EmailMessage(service)
            message.Subject = Me.Invoke(Function() returntext(form.RichTextBox4))
            Dim list1 As New List(Of String)

            For Each img As HtmlElement In Me.Invoke(Function() form.Editor1.webBrowser1.Document.Images)
                Dim filename As String = Between(After(img.OuterHtml, "src="), """", """")
                list1.Add(filename)


            Next

            Me.Invoke(Sub() form.prepare())

            message.Body = New MessageBody(BodyType.HTML, Me.Invoke(Function() form.Editor1.webBrowser1.Document.Body.InnerHtml))

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

            If Me.Invoke(Function() form.ListBox2.Items.Count) > 0 Then
                Me.Invoke(Sub() WTextBox1.Text = "Fazendo Upload Dos Anexos...")
                For l_index As Integer = 0 To Me.Invoke(Function() form.ListBox2.Items.Count) - 1
                    Dim l_text As String = CStr(Me.Invoke(Function() form.ListBox2.Items(l_index).ToString))
                    Dim att As FileAttachment = message.Attachments.AddFileAttachment(l_text)
                    If Me.Invoke(Function() form.attsinline.Count) > 0 Then
                        For Each x1 As String In Me.Invoke(Function() form.attsinline)
                            If l_text.ToLower.Contains(x1.ToLower) Then
                                att.IsInline = True
                            End If
                        Next
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


                Else

                    Dim assinatura1 As String = Me.Invoke(Function() Form1.account.assinatura)

                    If assinatura1 IsNot Nothing And x1.Contains(assinatura1) Then
                        Dim newatt As FileAttachment = message.Attachments.AddFileAttachment(Application.StartupPath & "\" & assinatura1)
                        newatt.IsInline = True
                        newatt.ContentId = IO.Path.GetFileName(Application.StartupPath & "\" & assinatura1)

                    End If
                End If
            Next

            'Send message 
            message.Save()
            message.SendAndSaveCopy(WellKnownFolderName.SentItems)


            Me.Invoke(Sub() form.Close())
            Me.Invoke(Sub() WTextBox1.Text = "Email Enviando Com Sucesso")
            Me.Invoke(Sub() MetroProgressBar1.ProgressBarStyle = ProgressBarStyle.Blocks)
            Me.Invoke(Sub() MetroProgressBar1.Value = 100)
            Me.Invoke(Sub() MetroButton1.Text = "Remover")

        Catch ex As ServiceRequestException
            Me.Invoke(Sub() EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString))
            Me.Invoke(Sub() WTextBox1.Text = "Erro No Envio" & Space(2) & ex.Message)

        Catch ex As Exception

            Me.Invoke(Sub() EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString))
            Me.Invoke(Sub() WTextBox1.Text = "Erro No Envio" & Space(2) & ex.Message)


        End Try
        

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

    Private Sub MetroButton1_Click(sender As Object, e As EventArgs) Handles MetroButton1.Click
        Try
            If thmessage IsNot Nothing And thmessage.IsAlive Then
                thmessage.Abort()
            End If
            WTextBox1.Text = "Envio Cancelado."
            EnviarReceber.Task1.clearlist(Me)
        Catch ex As Exception

        End Try
    End Sub


    
 
    
    
    
    Private Sub MetroProgressBar1_Click(sender As Object, e As EventArgs) Handles MetroProgressBar1.Click

    End Sub

    Private Sub TaskControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
