Imports Excel = Microsoft.Office.Interop.Excel

Public Class GlobalExcel
    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet
    Dim custName As String
    Public Sub New()
        
        
    End Sub


    Public Sub open()
        xlWorkBook = xlApp.Workbooks.Open("C:\Documents and Settings\vamsi.devavarapu\Desktop\Mona.xlsx")
        xlWorkSheet = xlWorkBook.Worksheets("Sheet1")
    End Sub

    Public Function LoadExcelData() As String

        custName = xlWorkSheet.Range("B3").Value

        Return custName
    End Function
End Class