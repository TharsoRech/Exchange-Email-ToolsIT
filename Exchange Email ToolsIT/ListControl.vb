Public Class ListControl

    Public Event ItemClick(sender As Object, Index As Integer)
    Public Event checkchanged1(sender As Object)
    Dim countname As Integer = 0

    Public Sub Add(mfrom As String, subject As String, displayto As String, Duration As String, messageid As String, read As Boolean, itemhasattachment As Boolean)
        Try

            Dim c As New ListControlItem
            With c

                .Name = "NewitemControl" & countname

                .Margin = New Padding(0)
                If read = False Then
                    .Panel1.BackColor = Color.Maroon
                End If
                If itemhasattachment = False Then
                    .PictureBox1.Visible = False
                End If

                .from = mfrom
                .subject = subject
                .displayto = displayto
                .Duration = Duration
                .idmessage = messageid
            End With

            AddHandler c.SelectionChanged, AddressOf SelectionChanged
            AddHandler c.Click, AddressOf ItemClicked
            AddHandler c.CheckBox1.CheckedChanged, AddressOf Form1.checkchange

            countname = countname + 1

            Form1.listofcontrols.Add(c)

        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub
 

    Public Sub Remove(Index As Integer)
        Try
            Dim c As ListControlItem = TryCast(flpListBox.Controls(Index), ListControlItem)
            Remove(c.Name)  ' call the below sub
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Remove(name As String)
        Try
            ' grab which control is being removed
            Dim c As ListControlItem = TryCast(flpListBox.Controls(name), ListControlItem)
            flpListBox.Controls.Remove(c)
            ' remove the event hook
            RemoveHandler c.SelectionChanged, AddressOf SelectionChanged
            RemoveHandler c.Click, AddressOf ItemClicked
            RemoveHandler c.CheckBox1.CheckedChanged, AddressOf checkchanged
            ' now dispose off properly
            c.Dispose()
            SetupAnchors()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub checkchanged(sender As Object, e As EventArgs)
        RaiseEvent checkchanged1(sender)
    End Sub
    Public Sub Clear()
        Try
            Do
                If flpListBox.Controls.Count = 0 Then Exit Do
                Dim c As ListControlItem = TryCast(flpListBox.Controls(0), ListControlItem)
                flpListBox.Controls.Remove(c)
                ' remove the event hook
                RemoveHandler c.SelectionChanged, AddressOf SelectionChanged
                RemoveHandler c.Click, AddressOf ItemClicked
                RemoveHandler c.CheckBox1.CheckedChanged, AddressOf checkchanged
                ' now dispose off properly
                c.Dispose()
            Loop
            mLastSelected = Nothing
        Catch ex As Exception
        End Try
    End Sub

    Public ReadOnly Property Count() As Integer
        Get
            Return flpListBox.Controls.Count
        End Get
    End Property

    Private Sub SetupAnchors()
        Try
            If flpListBox.Controls.Count > 0 Then

                For i = 0 To flpListBox.Controls.Count - 1
                    Dim c As Control = flpListBox.Controls(i)

                    If i = 0 Then
                        ' Its the first control, all subsequent controls follow 
                        ' the anchor behavior of this control.
                        c.Anchor = AnchorStyles.Left + AnchorStyles.Top
                        c.Width = flpListBox.Width - SystemInformation.VerticalScrollBarWidth

                    Else
                        ' It is not the first control. Set its anchor to
                        ' copy the width of the first control in the list.
                        c.Anchor = AnchorStyles.Left + AnchorStyles.Right
                    End If

                Next

            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub flpListBox_Resize(sender As Object, e As System.EventArgs) Handles flpListBox.Resize
        If flpListBox.Controls.Count > 0 Then
            flpListBox.Controls(0).Width = flpListBox.Width - SystemInformation.VerticalScrollBarWidth
        End If
    End Sub

    Dim mLastSelected As ListControlItem = Nothing
    Public Sub SelectionChanged(sender As Object)
        Try
            If mLastSelected IsNot Nothing Then
                mLastSelected.Selected = False
            End If
            mLastSelected = sender
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ItemClicked(sender As Object, e As System.EventArgs)
        RaiseEvent ItemClick(Me, flpListBox.Controls.IndexOfKey(sender.name))
    End Sub



  

    Private Sub flpListBox_Paint(sender As Object, e As PaintEventArgs) Handles flpListBox.Paint

    End Sub
End Class
