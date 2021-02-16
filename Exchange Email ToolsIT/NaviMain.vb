Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports MetroFramework


Public Class NaviMain
    Inherits UserControl

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        tlstrpNaviButtons.Renderer = New System.Windows.Forms.ProToolstripRenderer(True)
        tlsNaviHelper.Renderer = New System.Windows.Forms.ProToolstripRenderer(False)
    End Sub

    Private Sub btnInbox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInbox.Click

        Try
            Form1.Label1.Text = "Caixa De Entrada"
            Form1.ContextMenuStrip3.Enabled = True
            Form1.ContextMenuStrip2.Enabled = True
            Form1.ContextMenuStrip1.Enabled = True
            Form1.ribbonPanel1.Enabled = True
            Form1.ribbonPanel2.Enabled = True
            Form1.RibbonPanel3.Enabled = True
            Form1.RibbonPanel4.Enabled = True
            Form1.RibbonPanel5.Enabled = True
            Form1.RibbonPanel6.Enabled = True
            Form1.RibbonPanel7.Enabled = True
            Form1.RibbonPanel8.Enabled = True
            Form1.RibbonPanel9.Enabled = True
            Form1.RibbonPanel10.Enabled = True
            Form1.ribbonButton14.Enabled = True
            Form1.ribbonButton16.Enabled = True
            Form1.ribbonButton13.Enabled = True
            Form1.ribbonButton17.Enabled = True
            Form1.ribbonButton18.Enabled = True
            Form1.NaviMain3.treeView1.Nodes.Clear()
            Form1.start()

            'Form1.findfolders2()
        Catch ex As Exception

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        'Form1.readpstfile2()
        Try

            Form1.ContextMenuStrip3.Enabled = False
            Form1.Label1.Text = "Arquivo Morto"
            Form1.ribbonPanel1.Enabled = False
            Form1.ribbonPanel2.Enabled = False
            Form1.RibbonPanel3.Enabled = False
            Form1.RibbonPanel4.Enabled = False
            Form1.RibbonPanel5.Enabled = False
            Form1.RibbonPanel6.Enabled = False
            Form1.RibbonPanel7.Enabled = False
            Form1.RibbonPanel8.Enabled = False
            Form1.RibbonPanel9.Enabled = False
            Form1.RibbonPanel10.Enabled = False
            Form1.ContextMenuStrip1.Enabled = False
            Form1.ContextMenuStrip2.Enabled = False
            Form1.ribbonButton14.Enabled = False
            Form1.ribbonButton16.Enabled = False
            Form1.ribbonButton13.Enabled = False
            Form1.ribbonButton17.Enabled = False
            Form1.ribbonButton18.Enabled = False
            Form1.NaviMain3.treeView1.Nodes.Clear()
            Form1.readpstfile()
        Catch ex As Exception

            MetroMessageBox.Show(Me, ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub




    Private Sub treeView1MouseUp(sender As Object, e As MouseEventArgs) Handles treeView1.MouseUp
        Try
            treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y)

            If e.Button = MouseButtons.Right Then
                ' Select the clicked node

                If treeView1.SelectedNode IsNot Nothing Then
                    Form1.ContextMenuStrip3.Show(treeView1, e.Location)
                End If
            Else
                If treeView1.SelectedNode.ForeColor = Color.Gray Then
                    Exit Sub
                End If
                Form1.selecttreeview()
            End If
        Catch ex As Exception
            '  EnviarReceber.Task1.adderror(ex.GetType.ToString, ex.Message, ex.StackTrace, Now.ToString)
        End Try
    End Sub

  

End Class

