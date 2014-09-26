
Public Class clsMacLicense
    Public MacIdFromFile As String
    Public NoOfDaysFromFile As String
    Public Path As String


    Public Function GetMAC() As Boolean
        'Dim PlainText As String
        Dim moReturn As Management.ManagementObjectCollection
        Dim moSearch As Management.ManagementObjectSearcher
        Dim mo As Management.ManagementObject
        Dim MacId As String
        moSearch = New Management.ManagementObjectSearcher("Select * from Win32_NetworkAdapter where AdapterTypeID = 0")
        Debug.WriteLine("Network")
        moReturn = moSearch.Get

        For Each mo In moReturn
            Try
                MacId = mo("MACaddress").ToString
                If MacIdFromFile = MacId Then
                    GetMAC = True
                    'MessageBox.Show("License is OK")
                    Exit For
                Else
                    GetMAC = False
                    'MessageBox.Show("license is not valid")
                End If
                'MessageBox.Show(String.Format("{0} {1} ", mo("Name").ToString, mo("MACaddress").ToString))
            Catch
            End Try
        Next
    End Function

    '''Add this code in your form
    Private Function ISValidDate() As Boolean
        'The purpose of this module is to allow you to place a time
        'limit on the unregistered use of your shareware application.
        'This module can not be defeated by rolling back the system clock.
        'Simply call the DateGood function when your application is first
        'loading, passing it the number of days it can be used without
        'registering.
        '
        'Register Parameters:
        ' CRD: Current Run Date
        ' LRD: Last Run Date
        ' FRD: First Run Date
        Dim NumDays As Long
        NumDays = CLng(NoOfDaysFromFile)

        Dim TmpCRD As New Date
        Dim TmpLRD As Date
        Dim TmpFRD As Date

        ' TmpCRD = Format(Now, "d/m/yyyy")
        'this parameter will be registered in following registry
        'which we can view by run -------> regedit
        'HKEY_CURRENT_USER\Software\VB and VBA Program Settings\ FolderWithEXEName \ LicParam

        'Dim TodayDate As Date

        TmpCRD = Date.Today
        Dim ExeName As String

        'ExeName = Application

        ExeName = System.Reflection.Assembly.GetExecutingAssembly.Location.Replace(Application.StartupPath & "\", "")
        TmpLRD = GetSetting(ExeName, "CDALicParam", "LRD", "12/12/2006")
        TmpFRD = GetSetting(ExeName, "CDALicParam", "FRD", "12/12/2006")

        'If this is the applications first load, write initial settings
        'to the register
        If TmpLRD = "#12/12/2006#" Then
            SaveSetting(ExeName, "CDALicParam", "LRD", TmpCRD)
            SaveSetting(ExeName, "CDALicParam", "FRD", TmpCRD)
        End If

        'Read LRD and FRD from register
        TmpLRD = GetSetting(ExeName, "CDALicParam", "LRD", "12/12/2006")
        TmpFRD = GetSetting(ExeName, "CDALicParam", "FRD", "12/12/2006")
        Dim ExpDate As Date
        ExpDate = DateAdd("d", NumDays, TmpFRD)
        '    MessageBox.Show "Last run date" & TmpLRD
        '    MessageBox.Show "First run date" & TmpFRD
        If TmpFRD > TmpCRD Then 'System clock rolled back
            ISValidDate = False
        ElseIf TmpCRD > ExpDate Then 'Expiration expired
            ISValidDate = False
        ElseIf TmpCRD > TmpLRD Then 'Everything OK write New LRD date
            SaveSetting(System.Reflection.Assembly.GetExecutingAssembly.Location, "CDALicParam", "LRD", TmpCRD)
            ISValidDate = True
        ElseIf TmpCRD = TmpLRD Then
            ISValidDate = True
        Else
            ISValidDate = False
        End If

    End Function

    Public Function DecryptText(ByVal EncyptText As String, ByVal ShiftSize As Integer) As String
        Dim PlainText As String = ""
        Dim Letter As String
        Dim C As Integer
        ' Extract each alphabet and give it to the ROtate function which
        ' performs the rotation (encryption).
        ' In Rotate you have to mention the Letter extracted and by how
        ' much you gotta shift
        For C = 1 To Len(EncyptText)
            Letter = Mid$(EncyptText, C, 1)
            PlainText = PlainText & Rotate1(Letter, ShiftSize)
        Next C
        ' Return the Encrypted text to CCipher
        DecryptText = PlainText

    End Function

    Private Function Rotate1(ByVal Letter As String, ByVal ShiftAmount As Integer) As String
        Rotate1 = Chr(Asc(Letter) + ShiftAmount)
    End Function

    Private Sub ReadFile(ByVal Path As String)
        Dim file As New System.IO.StreamReader(Path & "IFLLic.lic")
        MacIdFromFile = file.ReadLine()
        NoOfDaysFromFile = file.ReadLine()
        'While (oneLine <> "")
        '    Console.WriteLine(oneLine)
        '    oneLine = file.ReadLine()
        'End While
        file.Close()
    End Sub

    Public Function App_Path() As String
        Return System.AppDomain.CurrentDomain.BaseDirectory()
    End Function

    Public Function LicenseValidation() As Boolean
        Dim CheckMACId As Boolean
        Dim CheckDays As Boolean
        Path = App_Path()
        ReadFile(Path)
        MacIdFromFile = DecryptText(MacIdFromFile, 10)
        NoOfDaysFromFile = DecryptText(NoOfDaysFromFile, 10)
        ' MacIdFromFile = MacIdFromFile.Replace("-", ":")
        CheckMACId = GetMAC()
        CheckDays = ISValidDate()
        If CheckDays = True And CheckMACId = True Then
            LicenseValidation = True
        Else
            LicenseValidation = False
        End If
    End Function

End Class
