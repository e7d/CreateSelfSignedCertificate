<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Password
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Password))
        Me.TextBoxPassword = New System.Windows.Forms.TextBox()
        Me.LabelPassword = New System.Windows.Forms.Label()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.LabelConfirm = New System.Windows.Forms.Label()
        Me.TextBoxConfirm = New System.Windows.Forms.TextBox()
        Me.ButtonNone = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxPassword.Location = New System.Drawing.Point(87, 12)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.Size = New System.Drawing.Size(205, 20)
        Me.TextBoxPassword.TabIndex = 1
        Me.TextBoxPassword.UseSystemPasswordChar = True
        '
        'LabelPassword
        '
        Me.LabelPassword.AutoSize = True
        Me.LabelPassword.Location = New System.Drawing.Point(12, 15)
        Me.LabelPassword.Name = "LabelPassword"
        Me.LabelPassword.Size = New System.Drawing.Size(53, 13)
        Me.LabelPassword.TabIndex = 0
        Me.LabelPassword.Text = "Password"
        '
        'ButtonOK
        '
        Me.ButtonOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonOK.Location = New System.Drawing.Point(136, 64)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOK.TabIndex = 4
        Me.ButtonOK.Text = "OK"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'LabelConfirm
        '
        Me.LabelConfirm.AutoSize = True
        Me.LabelConfirm.Location = New System.Drawing.Point(12, 41)
        Me.LabelConfirm.Name = "LabelConfirm"
        Me.LabelConfirm.Size = New System.Drawing.Size(42, 13)
        Me.LabelConfirm.TabIndex = 0
        Me.LabelConfirm.Text = "Confirm"
        '
        'TextBoxConfirm
        '
        Me.TextBoxConfirm.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxConfirm.Location = New System.Drawing.Point(87, 38)
        Me.TextBoxConfirm.Name = "TextBoxConfirm"
        Me.TextBoxConfirm.Size = New System.Drawing.Size(205, 20)
        Me.TextBoxConfirm.TabIndex = 2
        Me.TextBoxConfirm.UseSystemPasswordChar = True
        '
        'ButtonNone
        '
        Me.ButtonNone.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonNone.DialogResult = System.Windows.Forms.DialogResult.Ignore
        Me.ButtonNone.Location = New System.Drawing.Point(12, 64)
        Me.ButtonNone.Name = "ButtonNone"
        Me.ButtonNone.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNone.TabIndex = 3
        Me.ButtonNone.Text = "None"
        Me.ButtonNone.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Location = New System.Drawing.Point(217, 64)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancel.TabIndex = 5
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'Password
        '
        Me.AcceptButton = Me.ButtonOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 99)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonNone)
        Me.Controls.Add(Me.LabelConfirm)
        Me.Controls.Add(Me.TextBoxConfirm)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.LabelPassword)
        Me.Controls.Add(Me.TextBoxPassword)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Password"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Certificate Password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxPassword As System.Windows.Forms.TextBox
    Friend WithEvents LabelPassword As System.Windows.Forms.Label
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents LabelConfirm As System.Windows.Forms.Label
    Friend WithEvents TextBoxConfirm As System.Windows.Forms.TextBox
    Friend WithEvents ButtonNone As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
End Class
