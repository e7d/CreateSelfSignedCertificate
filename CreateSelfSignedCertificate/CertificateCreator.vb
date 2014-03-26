Imports System.ComponentModel
Imports System.Globalization
Imports System.Runtime.ConstrainedExecution
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Permissions
Imports Microsoft.Win32.SafeHandles

Public NotInheritable Class CertificateCreator

#Region "Interop"

#Region "Helpers"

    Friend NotInheritable Class SafeCryptProvHandle
        Inherits SafeHandleZeroOrMinusOneIsInvalid
        ' Methods
        Private Sub New()
            MyBase.New(True)
        End Sub

        Friend Sub New(ByVal handle As IntPtr)
            MyBase.New(True)
            MyBase.SetHandle(handle)
        End Sub

        <SuppressUnmanagedCodeSecurity(), ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), DllImport("advapi32.dll", SetLastError:=True)> _
        Private Shared Function CryptReleaseContext(ByVal hCryptProv As IntPtr, ByVal dwFlags As UInt32) As Boolean
        End Function

        Protected Overrides Function ReleaseHandle() As Boolean
            Return SafeCryptProvHandle.CryptReleaseContext(MyBase.handle, 0)
        End Function

        ' Properties
        Friend Shared ReadOnly Property InvalidHandle() As SafeCryptProvHandle
            Get
                Return New SafeCryptProvHandle(IntPtr.Zero)
            End Get
        End Property
    End Class

    Private NotInheritable Class SafeCertContextHandle
        Inherits SafeHandleZeroOrMinusOneIsInvalid
        ' Methods
        Private Sub New()
            MyBase.New(True)
        End Sub

        Friend Sub New(ByVal handle As IntPtr)
            MyBase.New(True)
            MyBase.SetHandle(handle)
        End Sub

        <SuppressUnmanagedCodeSecurity(), ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), DllImport("crypt32.dll", SetLastError:=True)> _
        Private Shared Function CertFreeCertificateContext(ByVal pCertContext As IntPtr) As Boolean
        End Function

        Protected Overrides Function ReleaseHandle() As Boolean
            Return SafeCertContextHandle.CertFreeCertificateContext(MyBase.handle)
        End Function

        ' Properties
        Friend Shared ReadOnly Property InvalidHandle() As SafeCertContextHandle
            Get
                Return New SafeCertContextHandle(IntPtr.Zero)
            End Get
        End Property

        Public Function ToStructure() As CERT_CONTEXT
            If IsInvalid Then
                Throw New InvalidOperationException("SafeCertContextHandle Is Invalid")
            End If

            Return Marshal.PtrToStructure(handle, GetType(CERT_CONTEXT))
        End Function
    End Class

    Private NotInheritable Class SafeCryptKeyHandle
        Inherits SafeHandleZeroOrMinusOneIsInvalid
        ' Methods
        Private Sub New()
            MyBase.New(True)
        End Sub

        Friend Sub New(ByVal handle As IntPtr)
            MyBase.New(True)
            MyBase.SetHandle(handle)
        End Sub

        <SuppressUnmanagedCodeSecurity(), ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), DllImport("advapi32.dll", SetLastError:=True)> _
        Private Shared Function CryptDestroyKey(ByVal hKey As IntPtr) As Boolean
        End Function

        Protected Overrides Function ReleaseHandle() As Boolean
            Return SafeCryptKeyHandle.CryptDestroyKey(MyBase.handle)
        End Function

        ' Properties
        Friend Shared ReadOnly Property InvalidHandle() As SafeCertContextHandle
            Get
                Return New SafeCertContextHandle(IntPtr.Zero)
            End Get
        End Property
    End Class

    Private NotInheritable Class SafeCertStoreHandle
        Inherits SafeHandleZeroOrMinusOneIsInvalid
        ' Methods
        Private Sub New()
            MyBase.New(True)
        End Sub

        Friend Sub New(ByVal handle As IntPtr)
            MyBase.New(True)
            MyBase.SetHandle(handle)
        End Sub

        <SuppressUnmanagedCodeSecurity(), ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success), DllImport("crypt32.dll", SetLastError:=True)> _
        Private Shared Function CertCloseStore(ByVal hCertStore As IntPtr, ByVal dwFlags As UInt32) As Boolean
        End Function

        Protected Overrides Function ReleaseHandle() As Boolean
            Return SafeCertStoreHandle.CertCloseStore(MyBase.handle, 0)
        End Function

        ' Properties
        Friend Shared ReadOnly Property InvalidHandle() As SafeCertStoreHandle
            Get
                Return New SafeCertStoreHandle(IntPtr.Zero)
            End Get
        End Property

    End Class

#End Region

#Region "Constants"

    Private Const AT_KEYEXCHANGE As UInt32 = 1

    Private Const CERT_KEY_PROV_INFO_PROP_ID As UInt32 = 2
    Private Const CERT_STORE_ADD_REPLACE_EXISTING As UInt32 = 3
    Private Const CERT_STORE_PROV_SYSTEM As UInt32 = 10
    Private Const CERT_SYSTEM_STORE_LOCAL_MACHINE As UInt32 = &H20000
    Private Const CRYPT_EXPORTABLE As UInt32 = 1
    Private Const CRYPT_MACHINE_KEYSET As UInt32 = &H20
    Private Const CRYPT_NEWKEYSET As UInt32 = 8
    Private Const CRYPT_SILENT As UInt32 = &H40
    Private Const MS_STRONG_PROV As String = "Microsoft Strong Cryptographic Provider"
    Private Const PROV_RSA_FULL As UInt32 = 1
    Private Const szOID_RSA_SHA512RSA As String = "1.2.840.113549.1.1.13"

#End Region

#Region "Structures"

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure SYSTEMTIME
        Public wYear As Short
        Public wMonth As Short
        Public wDayOfWeek As Short
        Public wDay As Short
        Public wHour As Short
        Public wMinute As Short
        Public wSecond As Short
        Public wMilliseconds As Short
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Private Structure CRYPT_KEY_PROV_INFO
        Friend pwszContainerName As String
        Friend pwszProvName As String
        Friend dwProvType As UInt32
        Friend dwFlags As UInt32
        Friend cProvParam As UInt32
        Friend rgProvParam As IntPtr
        Friend dwKeySpec As UInt32
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Private Structure CERT_CONTEXT
        Public dwCertEncodingType As UInt32
        Public pbCertEncoded As IntPtr
        Public cbCertEncoded As UInt32
        Public pCertInfo As IntPtr
        Public hCertStore As IntPtr
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Private Structure CERT_INFO
        Public dwVersion As UInt32
        Public SerialNumber As CRYPTOAPI_BLOB
        Public SignatureAlgorithm As CRYPT_ALGORITHM_IDENTIFIER
        Public Issuer As CRYPTOAPI_BLOB
        Public NotBefore As System.Runtime.InteropServices.ComTypes.FILETIME
        Public NotAfter As System.Runtime.InteropServices.ComTypes.FILETIME
        Public Subject As CRYPTOAPI_BLOB
        Public SubjectPublicKeyInfo As CERT_PUBLIC_KEY_INFO
        Public IssuerUniqueId As CRYPT_BIT_BLOB
        Public SubjectUniqueId As CRYPT_BIT_BLOB
        Public cExtension As UInt32
        Public rgExtension As IntPtr
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Private Structure CRYPT_BIT_BLOB
        Public cbData As UInt32
        Public pbData As IntPtr
        Public cUnusedBits As UInt32
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Private Structure CRYPTOAPI_BLOB
        Public cbData As UInt32
        Public pbData As IntPtr
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Private Structure CERT_PUBLIC_KEY_INFO
        Public Algorithm As CRYPT_ALGORITHM_IDENTIFIER
        Public PublicKey As CRYPT_BIT_BLOB
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Private Structure CRYPT_ALGORITHM_IDENTIFIER
        <MarshalAs(UnmanagedType.LPStr)> _
        Public pszObjId As String
        Public Parameters As CRYPTOAPI_BLOB
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Private Structure CERT_EXTENSION
        <MarshalAs(UnmanagedType.LPStr)> _
        Friend pszObjId As String
        Friend fCritical As Boolean
        Friend Value As CRYPTOAPI_BLOB
    End Structure

#End Region

#Region "Functions"

    <DllImport("advapi32.dll", EntryPoint:="CryptAcquireContextA", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Private Shared Function CryptAcquireContext(<[In](), Out()> ByRef hCryptProv As SafeCryptProvHandle, <[In](), MarshalAs(UnmanagedType.LPStr)> ByVal pszContainer As String, <[In](), MarshalAs(UnmanagedType.LPStr)> ByVal pszProvider As String, <[In]()> ByVal dwProvType As UInt32, <[In]()> ByVal dwFlags As UInt32) As Boolean
    End Function

    <DllImport("crypt32.dll", SetLastError:=True)> _
    Private Shared Function CertCreateSelfSignCertificate( _
        ByVal hCryptProvOrNCryptKey As SafeCryptProvHandle, _
        <[In]()> ByRef pSubjectIssuerBlob As CRYPTOAPI_BLOB, _
        ByVal dwFlags As Integer, _
        <[In]()> ByRef pKeyProvInfo As CRYPT_KEY_PROV_INFO, _
        <[In]()> ByRef pSignatureAlgorithm As CRYPT_ALGORITHM_IDENTIFIER, _
        <[In]()> ByRef pStartTime As SYSTEMTIME, _
        <[In]()> ByRef pEndTime As SYSTEMTIME, _
        <MarshalAs(UnmanagedType.LPArray), [In]()> ByVal pExtensions() As CERT_EXTENSION) As SafeCertContextHandle
    End Function


    <DllImport("advapi32.dll", SetLastError:=True)> _
    Private Shared Function CryptGenKey( _
        ByVal hProv As SafeCryptProvHandle, _
        ByVal Algid As Integer, _
        ByVal dwFlags As Integer, _
        ByRef phKey As SafeCryptKeyHandle) As Boolean
    End Function

    <DllImport("crypt32.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
    Private Shared Function CertOpenStore(<[In]()> ByVal lpszStoreProvider As IntPtr, <[In]()> ByVal dwMsgAndCertEncodingType As UInt32, <[In]()> ByVal hCryptProv As IntPtr, <[In]()> ByVal dwFlags As UInt32, <[In]()> ByVal pvPara As String) As SafeCertStoreHandle
    End Function

    <DllImport("crypt32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Private Shared Function CertAddCertificateContextToStore(<[In]()> ByVal hCertStore As SafeCertStoreHandle, <[In]()> ByVal pCertContext As SafeCertContextHandle, <[In]()> ByVal dwAddDisposition As UInt32, <[In](), Out()> ByRef ppStoreContext As SafeCertContextHandle) As Boolean
    End Function

    <DllImport("crypt32.dll", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Private Shared Function CertSetCertificateContextProperty( _
        ByVal certificateContext As SafeCertContextHandle, _
        ByVal propertyId As Integer, _
        ByVal flags As Integer, _
        <[In]()> ByRef data As CRYPT_KEY_PROV_INFO) As Boolean
    End Function

#End Region

#End Region

    Public Shared Function CreateSelfSignedCertificate(ByVal DistinguishedName As X500DistinguishedName, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As X509Certificate2
        Dim NameData As Byte() = DistinguishedName.RawData
        Dim DataHandle As GCHandle = GCHandle.Alloc(NameData, GCHandleType.Pinned)
        Try
            Dim SubjectBlob As CRYPTOAPI_BLOB
            SubjectBlob.cbData = NameData.Length
            SubjectBlob.pbData = DataHandle.AddrOfPinnedObject()

            Dim Container As String = Guid.NewGuid().ToString()
            Dim Context As New SafeCryptProvHandle(IntPtr.Zero)
            If Not CryptAcquireContext(Context, Container, MS_STRONG_PROV, PROV_RSA_FULL, CRYPT_NEWKEYSET Or CRYPT_MACHINE_KEYSET Or CRYPT_SILENT) Then
                Throw New Win32Exception(Marshal.GetLastWin32Error())
            End If
            Try
                Dim KeyPtr As New SafeCryptKeyHandle(IntPtr.Zero)
                If Not CryptGenKey(Context, AT_KEYEXCHANGE, (2048 << 16) Or CRYPT_EXPORTABLE, KeyPtr) Then
                    Throw New Win32Exception(Marshal.GetLastWin32Error())
                End If
                KeyPtr.Dispose()

                Dim SysStartTime As New SYSTEMTIME() With { _
                        .wMonth = StartDate.Month, .wDay = StartDate.Day, .wYear = StartDate.Year, .wDayOfWeek = StartDate.DayOfWeek, _
                        .wHour = StartDate.Hour, .wMinute = StartDate.Minute, .wSecond = StartDate.Second, .wMilliseconds = StartDate.Minute _
                    }

                Dim SysEndTime As New SYSTEMTIME() With { _
                    .wMonth = EndDate.Month, .wDay = EndDate.Day, .wYear = EndDate.Year, .wDayOfWeek = EndDate.DayOfWeek, _
                    .wHour = EndDate.Hour, .wMinute = EndDate.Minute, .wSecond = EndDate.Second, .wMilliseconds = EndDate.Minute _
                }

                Dim KeyInfo As New CRYPT_KEY_PROV_INFO()
                KeyInfo.pwszContainerName = Container
                KeyInfo.pwszProvName = MS_STRONG_PROV
                KeyInfo.dwProvType = PROV_RSA_FULL
                KeyInfo.dwKeySpec = AT_KEYEXCHANGE
                KeyInfo.dwFlags = CRYPT_MACHINE_KEYSET

                Dim Alg As New CRYPT_ALGORITHM_IDENTIFIER()
                Alg.pszObjId = szOID_RSA_SHA512RSA

                Dim CertContextHandle As SafeCertContextHandle = CertCreateSelfSignCertificate(Context, SubjectBlob, 0, KeyInfo, Alg, SysStartTime, SysEndTime, Nothing)
                If CertContextHandle.IsInvalid Then
                    Throw New Win32Exception(Marshal.GetLastWin32Error())
                End If
                Try
                    Dim MyStore As SafeCertStoreHandle = CertOpenStore(New IntPtr(CERT_STORE_PROV_SYSTEM), 0, IntPtr.Zero, _
                                                               CERT_SYSTEM_STORE_LOCAL_MACHINE, "My")
                    If MyStore.IsInvalid Then
                        Throw New Win32Exception(Marshal.GetLastWin32Error())
                    End If
                    Try
                        Dim StoreCertContext As New SafeCertContextHandle(IntPtr.Zero)
                        If Not CertAddCertificateContextToStore(MyStore, CertContextHandle, CERT_STORE_ADD_REPLACE_EXISTING, StoreCertContext) Then
                            Throw New Win32Exception(Marshal.GetLastWin32Error())
                        End If
                        Try
                            If Not CertSetCertificateContextProperty(StoreCertContext, CERT_KEY_PROV_INFO_PROP_ID, 0, KeyInfo) Then
                                Throw New Win32Exception(Marshal.GetLastWin32Error())
                            End If

                            Dim CertContext As CERT_CONTEXT = StoreCertContext.ToStructure()
                            Dim buffer(CertContext.cbCertEncoded - 1) As Byte
                            Marshal.Copy(CertContext.pbCertEncoded, buffer, 0, CertContext.cbCertEncoded)
                            Return New X509Certificate2(buffer)
                        Finally
                            StoreCertContext.Dispose()
                        End Try
                    Finally
                        MyStore.Dispose()
                    End Try
                Finally
                    CertContextHandle.Dispose()
                End Try
            Finally
                Context.Dispose()
            End Try
        Finally
            DataHandle.Free()
        End Try
    End Function

End Class
