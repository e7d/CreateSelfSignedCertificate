Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Threading

Public Class Main
    Private PasswordForm As Password
    Private PasswordIsValid As Boolean
    Private LocalHostname As String = Dns.GetHostName()
    Private GeneratedCertificate As X509Certificate2

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxHost.Items.Add("localhost")
        ComboBoxHost.Items.Add(LocalHostname)
        ComboBoxHost.Text = LocalHostname
        DateTimePickerValidFrom.MaxDate = Today
        DateTimePickerValidFrom.Value = Today
        DateTimePickerValidUntil.MinDate = Today
        DateTimePickerValidUntil.Value = Today.AddYears(10)
    End Sub

    Private Sub ButtonGenerate_Click(sender As Object, e As EventArgs) Handles ButtonCreate.Click
        If String.IsNullOrEmpty(ComboBoxHost.Text) Then ComboBoxHost.Text = "localhost"
        SaveFileDialogCertificate.FileName = ComboBoxHost.Text
        SaveFileDialogCertificate.ShowDialog()
    End Sub

    Private Sub SaveFileDialogCertificate_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialogCertificate.FileOk
        Try
            GeneratedCertificate = CertificateCreator.CreateSelfSignedCertificate(New X500DistinguishedName("CN=" & ComboBoxHost.Text), DateTimePickerValidFrom.Value, DateTimePickerValidUntil.Value)

            Dim RootStore As New X509Store(StoreName.My, StoreLocation.LocalMachine)
            RootStore.Open(OpenFlags.ReadOnly)
            For Each RootStoreCertificate As X509Certificate2 In RootStore.Certificates
                If RootStoreCertificate.SerialNumber.Equals(GeneratedCertificate.SerialNumber) Then
                    GeneratedCertificate = RootStoreCertificate
                End If
            Next
            RootStore.Close()

            Using CertificateStreamWriter As New FileStream(SaveFileDialogCertificate.FileName, FileMode.Create, FileAccess.Write)
                Dim CertData() As Byte = {}
                Select Case SaveFileDialogCertificate.FilterIndex
                    Case 1 '.crt Binary
                        CertData = GeneratedCertificate.GetRawCertData()
                    Case 2 '.pfx, .p12
                        PasswordForm = New Password()
                        PasswordIsValid = False
                        While Not PasswordIsValid
                            Select Case PasswordForm.ShowDialog()
                                Case Windows.Forms.DialogResult.OK
                                    If PasswordForm.TextBoxPassword.Text.Length = 0 Then
                                        MessageBox.Show("You have to specify a password.", "Certificate Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    ElseIf Not PasswordForm.TextBoxPassword.Text = PasswordForm.TextBoxConfirm.Text Then
                                        MessageBox.Show("Passwords do not match.", "Certificate Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Else
                                        PasswordIsValid = True
                                    End If
                                Case Windows.Forms.DialogResult.Cancel
                                    CertificateStreamWriter.Close()
                                    Return
                                Case Windows.Forms.DialogResult.Ignore
                                    If MessageBox.Show("A PKCS #12 certificate without password may not be used in external applications." & vbCrLf & "Do you want to create a certificate without password?", "Certificate Password", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
                                        PasswordIsValid = True
                                    End If
                            End Select
                        End While
                        If Not String.IsNullOrEmpty(PasswordForm.TextBoxPassword.Text) Then
                            CertData = GeneratedCertificate.Export(X509ContentType.Pfx, PasswordForm.TextBoxPassword.Text)
                        Else
                            CertData = GeneratedCertificate.Export(X509ContentType.Pfx)
                        End If
                End Select
                CertificateStreamWriter.Write(CertData, 0, CertData.Length)
                CertificateStreamWriter.Close()
            End Using
        Catch Ex As Exception
            MessageBox.Show("An error occured during the certificate generation.", "Runtime Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
