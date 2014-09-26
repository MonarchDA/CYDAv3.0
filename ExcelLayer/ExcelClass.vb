Imports System.Diagnostics
Imports System.io
Imports Microsoft.Office.Interop.Excel
Public Class ExcelClass
    Public IDEnumerator As IDictionaryEnumerator
    Public objApp As Microsoft.Office.Interop.Excel.Application
    Public objBook As Microsoft.Office.Interop.Excel.Workbook
    Public objBooks As Microsoft.Office.Interop.Excel.Workbooks
    Public objSheets As Microsoft.Office.Interop.Excel.Sheets
    Public objSheet As Microsoft.Office.Interop.Excel.Worksheet
    Public objrange As Microsoft.Office.Interop.Excel.Range
    Dim _dirObj_Directory As Directory
    Dim _strSubdirectory As String
    Dim _strFileName As String
    Dim strFileNameSave As String
    Dim intIinput As Integer = 3
    Public xlink As XlLinkType

    Public Sub connectToExcel()
        Try
            objApp = New Microsoft.Office.Interop.Excel.Application
            objApp.AutoRecover.Enabled = False         '22_02_2011    RAGAVA
            If objApp Is Nothing Then
                'MsgBox("EXCEL 2003 is not available in the System")
                ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("EXCEL 2007 is not available in the system")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub checkExcelInstance()
        Try
            If objApp Is Nothing Then
                connectToExcel()
            End If
        Catch ex As Exception
        End Try
    End Sub

    'THE BELOW CODE IS COMMON FOR UPDATING THE MAIN EXCEL SHEET AND INDIVIDUAL EXCEL SHEETS.
    Public Sub updateDesign_Parameters(ByVal strType As String)
        Dim intI As Integer = 0
        Dim intStart As Integer = 0
        Dim intEnd As Integer = 0
        Dim intJ As Integer = 0
        Try
            intI = 1
            intStart = 0

            Do While UCase(objSheet.Range("D" & intI).Value) = UCase("Start")
                intStart = intStart + 1
                intI = intI + 1
            Loop
            intEnd = 0
            intI = 1
            Do While UCase(objSheet.Range("D" & intI).Value) <> UCase("End")
                intEnd = intEnd + 1
                intI = intI + 1
            Loop
            Dim storeVal() As String
            Dim StorePos() As Integer
            ReDim Preserve storeVal(0)
            ReDim Preserve StorePos(0)
            intJ = 0
            For intI = intStart + 1 To intEnd
                If Not objSheet.Range("D" & intI).Value Is Nothing And UCase(objSheet.Range("D" & intI).Value) <> UCase("No") Then
                    ReDim Preserve storeVal(intJ)
                    ReDim Preserve StorePos(intJ)
                    storeVal(intJ) = objSheet.Range("B" & intI).Value
                    StorePos(intJ) = intI
                    intJ = intJ + 1
                End If
            Next intI

            For intI = 0 To storeVal.Length - 1
                While IDEnumerator.MoveNext()
                    If Trim(storeVal(intI)).Equals(IDEnumerator.Key) Then
                        objSheet.Range("C" & StorePos(intI)).Value() = IDEnumerator.Value()
                    End If
                End While
                IDEnumerator.Reset()
            Next intI
            objApp.DisplayAlerts = False        '15_10_2012   RAGAVA
            objBook.Save()
            objBook.Close()
            objApp.DisplayAlerts = True         '15_10_2012   RAGAVA
            objApp.Quit()
            objApp = Nothing
            Exit Sub
        Catch ex As Exception
        End Try
    End Sub

    Public Sub updateGUIParameters(ByVal key As String, ByVal value As String)
        Try
            objSheet.Range("B" & intIinput).Value() = key
            objSheet.Range("C" & intIinput).Value() = value
            intIinput += 1
            Try
                objSheet.Rows.AutoFit()
            Catch ex As Exception

            End Try
            objApp.DisplayAlerts = False         '15_10_2012   RAGAVA
            objBook.Save()
            objApp.DisplayAlerts = True         '15_10_2012   RAGAVA
            Exit Sub
        Catch ex As Exception
        End Try
    End Sub

    'The below code is for updating the design part parameters of individual excel sheets.
    Public Sub getExcelFiles(ByVal strPath As String)
        ProcessDirectory(strPath)
    End Sub

    Public Sub ProcessDirectory(ByVal targetDirectory As String)
        Try
            If objApp Is Nothing Then
                connectToExcel()
            End If
            objApp.Visible = False
            Dim arrFileEntries As String() = Directory.GetFiles(targetDirectory)
            Dim arrFileEntriesSave As String() = Directory.GetFiles(targetDirectory)
            For Each _strFileName In arrFileEntries
                objApp.DisplayAlerts = False
                Try
                    objApp.AskToUpdateLinks = False
                    objBook = objApp.Workbooks.Open(_strFileName)
                    objBook.EnableAutoRecover = False 'anup 14-03-2011 
                    objBook.UpdateLinks = Microsoft.Office.Interop.Excel.XlUpdateLinks.xlUpdateLinksAlways
                    objBook.SaveLinkValues = True
                Catch ex As Exception
                End Try
                objApp.DisplayAlerts = False         '15_10_2012   RAGAVA
                objBook.Save()
                objApp.Workbooks.Close()         '24_02_2011   RAGAVA
                objApp.DisplayAlerts = True         '15_10_2012   RAGAVA
            Next
            Dim arrSubdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
            For Each _strSubdirectory In arrSubdirectoryEntries
                ProcessDirectory(_strSubdirectory)
            Next _strSubdirectory
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub 'ProcessDirectory

    '09_11_2009   Ragava
    Public Sub SaveExcel(ByVal strExcelFile As String)
        Try
            If File.Exists(strExcelFile) Then
                objApp.DisplayAlerts = False
                objApp.AskToUpdateLinks = False
                objBook = objApp.Workbooks.Open(strExcelFile)
                objBook.UpdateLinks = Microsoft.Office.Interop.Excel.XlUpdateLinks.xlUpdateLinksAlways
                objBook.SaveLinkValues = True
                objBook.Save()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BreakXlLink(ByVal FileName As String, ByVal strLink As String)  'safety factor by praveen
        Try
            xlink = XlLinkType.xlLinkTypeExcelLinks
            objBook = objApp.Workbooks.Open(FileName)
            objBook.Save()
            objBook.BreakLink(strLink, xlink)
            objBook.Save()
            objBook.Close()
            objApp = Nothing
        Catch ex As Exception
        End Try
    End Sub
    Public Sub SaveSfSheet(ByVal FileName As String) 'safety factor by praveen
        objBook.SaveAs(FileName)
        objBook.Close()
        objApp = Nothing
    End Sub

End Class
