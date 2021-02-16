Imports System
Imports System.Net
Imports System.DirectoryServices
Imports AutocompleteMenuNS
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports Microsoft.Exchange.WebServices.Data
Public Class Form6
    Dim user As String = ""
    Dim pass As String = ""
    Dim server As String = ""
    Dim th1 As Threading.Thread




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If th1 IsNot Nothing Then
                th1.Abort()
            End If
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

 


    Public Sub startsaving()
        Try
            Dim th1 As New Threading.Thread(Sub() Me.Invoke(Sub() saveallmesagges()))
            th1.TrySetApartmentState(Threading.ApartmentState.STA)
            th1.Start()

        Catch ex As Exception

        End Try
    End Sub
    Public Sub saveallmesagges()
        Try
            user = Form1.TextBox1.Text
            pass = Form1.TextBox2.Text
            server = Form1.TextBox3.Text
            Dim service As New Global.Microsoft.Exchange.WebServices.Data.ExchangeService
            service.Credentials = New WebCredentials(user, pass, Environment.UserDomainName)
            service.Url = New Uri("https://" & server & "/ews/Exchange.asmx")
            Try
        


                Dim offset As Integer = 0
                Dim pageSize As Integer = 1000000000
                Dim more As Boolean = True
                Dim view As ItemView = New ItemView(pageSize)

                Dim findResults As FindItemsResults(Of Item)

                Dim folder1 As String = Form1.Label2.Text
                findResults = service.FindItems(Form1.findfolders45(folder1), view)
                ProgressBar1.Maximum = findResults.TotalCount
                For i As Integer = 0 To findResults.Items.Count - 1
                    Me.Refresh()
                    Me.Update()
                    ProgressBar1.Value += 1
                    Me.Refresh()
                    Me.Update()
                    ProgressBar1.Refresh()
                    ProgressBar1.Update()
                    Dim value As String
                    Dim d As EmailMessage = TryCast(findResults.Items(i), EmailMessage)
                    Label1.Text = "Salvando Mensagem" & Space(2) & d.Subject
                    Label2.Text = i.ToString & Space(2) & "de:" & Space(2) & findResults.TotalCount
                    value = d.DateTimeReceived.Date.ToString
                    Me.Refresh()
                    Me.Update()
                    Dim Res As String = ""
                    For Each c As Char In value
                        If IsNumeric(c) Then
                            Me.Refresh()
                            Me.Update()
                            Res = Res & c
                        End If
                    Next
                    Res = Res & d.From.Address
                    Me.Refresh()
                    Me.Update()
                    d.Load(New PropertySet(ItemSchema.MimeContent))
                    Dim mc As MimeContent = d.MimeContent
                    If IO.Directory.Exists(Form1.TextBox5.Text & "\" & folder1) = False Then
                        IO.Directory.CreateDirectory(Form1.TextBox5.Text & "\" & folder1)
                    End If
                    Dim fs As IO.FileStream = New IO.FileStream(Form1.TextBox5.Text & "\" & folder1 & "\" & Res & ".eml", IO.FileMode.Create)
                    fs.Write(mc.Content, 0, mc.Content.Length)
                    fs.Close()
                    value = ""
                    Res = ""
                    Me.Refresh()
                    Me.Update()

                Next

                Me.Close()

            Catch ex As WebException
                Me.Invoke(Sub() EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString))
            End Try
        Catch ex As Exception
            Me.Invoke(Sub() EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString))
        End Try
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class