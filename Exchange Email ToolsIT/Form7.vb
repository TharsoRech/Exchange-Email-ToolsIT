Imports MetroFramework

Public Class Form7


    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Copy(Form1.NaviMain3.treeView1, TreeView1)
    End Sub
    Public Sub Copy(ByVal treeview1 As TreeView, ByVal treeview2 As TreeView)
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
            Dim newTn As TreeNode
            For Each tn As TreeNode In willCopied.Nodes
                newTn = New TreeNode(tn.Text)
                parent.Nodes.Add(newTn)
            Next
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TreeView1.SelectedNode.Text <> "" Then
            Else

                MetroMessageBox.Show(Me, "Nenhuma Pasta Escolhida para mover o item",me.text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If Me.Text = "Mover Emails" And Form1.TextBox8.Text = "true" Then
                Form1.moveitems()
                Me.Close()

            End If
            If Me.Text = "Copiar Emails" And Form1.TextBox8.Text = "true" Then
                Form1.copyitems()
                Me.Close()
            End If
            If Me.Text = "Mover Emails" And Form1.TextBox8.Text = "false" Then
                Form1.moveitems2()
                Form1.nodetext = TreeView1.SelectedNode.Text
                Me.Close()

            End If
            If Me.Text = "Copiar Emails" And Form1.TextBox8.Text = "false" Then
                Form1.copyitems2()
                Form1.nodetext = TreeView1.SelectedNode.Text
                Me.Close()
            End If
        Catch ex As Exception
            EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)

            MetroMessageBox.Show(Me, ex.Message,me.text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub


    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

    End Sub
End Class