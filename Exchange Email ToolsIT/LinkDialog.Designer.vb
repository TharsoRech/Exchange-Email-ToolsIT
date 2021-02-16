<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LinkDialog
    Inherits System.Windows.Forms.Form

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
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.comboBox1 = New System.Windows.Forms.ComboBox()
        Me.linkEdit = New System.Windows.Forms.ComboBox()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cancelButton
        '
        Me.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cancelButton1.Location = New System.Drawing.Point(254, 106)
        Me.cancelButton1.Name = "cancelButton"
        Me.cancelButton1.Size = New System.Drawing.Size(75, 23)
        Me.cancelButton1.TabIndex = 2
        Me.cancelButton1.Text = "Cancel"
        Me.cancelButton1.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(174, 106)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 1
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'comboBox1
        '
        Me.comboBox1.FormattingEnabled = True
        Me.comboBox1.Items.AddRange(New Object() {"http://", "https://"})
        Me.comboBox1.Location = New System.Drawing.Point(19, 30)
        Me.comboBox1.Name = "comboBox1"
        Me.comboBox1.Size = New System.Drawing.Size(67, 21)
        Me.comboBox1.TabIndex = 3
        Me.comboBox1.Text = "http://"
        '
        'linkEdit
        '
        Me.linkEdit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.linkEdit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.linkEdit.FormattingEnabled = True
        Me.linkEdit.Location = New System.Drawing.Point(92, 30)
        Me.linkEdit.Name = "linkEdit"
        Me.linkEdit.Size = New System.Drawing.Size(231, 21)
        Me.linkEdit.TabIndex = 4
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Location = New System.Drawing.Point(13, 13)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(316, 87)
        Me.groupBox1.TabIndex = 5
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "URL"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(6, 54)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(0, 13)
        Me.label1.TabIndex = 0
        '
        'LinkDialog
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(341, 141)
        Me.Controls.Add(Me.linkEdit)
        Me.Controls.Add(Me.comboBox1)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.cancelButton1)
        Me.Controls.Add(Me.groupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "LinkDialog"
        Me.Text = "Create a Link"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub


    Private label1 As System.Windows.Forms.Label
    Public WithEvents OKButton As System.Windows.Forms.Button
    Public WithEvents cancelButton1 As System.Windows.Forms.Button
    Public WithEvents comboBox1 As System.Windows.Forms.ComboBox
    Public WithEvents linkEdit As System.Windows.Forms.ComboBox
    Public WithEvents groupBox1 As System.Windows.Forms.GroupBox
End Class
