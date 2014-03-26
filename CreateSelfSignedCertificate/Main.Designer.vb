<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePickerValidFrom = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerValidUntil = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ButtonCreate = New System.Windows.Forms.Button()
        Me.SaveFileDialogCertificate = New System.Windows.Forms.SaveFileDialog()
        Me.ComboBoxHost = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Host"
        '
        'DateTimePickerValidFrom
        '
        Me.DateTimePickerValidFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePickerValidFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerValidFrom.Location = New System.Drawing.Point(87, 38)
        Me.DateTimePickerValidFrom.Name = "DateTimePickerValidFrom"
        Me.DateTimePickerValidFrom.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DateTimePickerValidFrom.Size = New System.Drawing.Size(205, 20)
        Me.DateTimePickerValidFrom.TabIndex = 2
        '
        'DateTimePickerValidUntil
        '
        Me.DateTimePickerValidUntil.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePickerValidUntil.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerValidUntil.Location = New System.Drawing.Point(87, 64)
        Me.DateTimePickerValidUntil.Name = "DateTimePickerValidUntil"
        Me.DateTimePickerValidUntil.Size = New System.Drawing.Size(205, 20)
        Me.DateTimePickerValidUntil.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Valid from"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Valid until"
        '
        'ButtonCreate
        '
        Me.ButtonCreate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCreate.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ButtonCreate.Location = New System.Drawing.Point(217, 90)
        Me.ButtonCreate.Name = "ButtonCreate"
        Me.ButtonCreate.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCreate.TabIndex = 4
        Me.ButtonCreate.Text = "Create"
        Me.ButtonCreate.UseVisualStyleBackColor = True
        '
        'SaveFileDialogCertificate
        '
        Me.SaveFileDialogCertificate.DefaultExt = "crt"
        Me.SaveFileDialogCertificate.Filter = "DER encoded binary X.509 certificates|*.crt;*.cer|Personal Information Exchange -" & _
    " PKCS #12 certificates|*.pfx;*.p12"
        '
        'ComboBoxHost
        '
        Me.ComboBoxHost.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxHost.FormattingEnabled = True
        Me.ComboBoxHost.Location = New System.Drawing.Point(87, 12)
        Me.ComboBoxHost.Name = "ComboBoxHost"
        Me.ComboBoxHost.Size = New System.Drawing.Size(205, 21)
        Me.ComboBoxHost.TabIndex = 1
        '
        'Main
        '
        Me.AcceptButton = Me.ButtonCreate
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 125)
        Me.Controls.Add(Me.ComboBoxHost)
        Me.Controls.Add(Me.ButtonCreate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DateTimePickerValidUntil)
        Me.Controls.Add(Me.DateTimePickerValidFrom)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.Text = "Create Self-Signed Certificate"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerValidFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerValidUntil As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ButtonCreate As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialogCertificate As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ComboBoxHost As System.Windows.Forms.ComboBox

End Class
