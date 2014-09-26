Imports System.IO
Public Class BatchRun
    Public Shared Sub deleteBatchrunRow()

        Dim strDeleteQuery As String
        strDeleteQuery = "Delete top (1) from dbo.BatchRun"

        Try
            MonarchConnectionObject.ExecuteQuery(strDeleteQuery)
        Catch ex As Exception
        End Try
    End Sub
    'Public Sub WriteLog()
    '    Dim writer As StreamWriter
    '    writer = File.AppendText(LogFilePath + OldName)
    '    writer.WriteLine("-----------------------------------------------------------")
    '    writer.WriteLine(DateTime.Now.ToString("d MMM yyyy  HH:MM:s tt") + vbCrLf)
    '    writer.WriteLine("Customer: " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CustomerName_ContractDetails.ToString)
    '    writer.WriteLine("Code Number: " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString)
    '    writer.WriteLine("Model generated successfully at location " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AssyGeneratePath)
    '    writer.WriteLine("start time: " + ObjClsWeldedCylinderFunctionalClass.startTime + ", End time: " + DateTime.Now.ToString("HH:mmm:s tt"))
    '    writer.Close()
    'End Sub
    Public Shared p As String = "C:\WELDED_TESTING\BatchRunLogs\" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString() + ".txt"
    Public Shared Sub CreateLog4fail()

        Dim writer1 As FileStream = Nothing
        If File.Exists(p) = True Then
            File.Delete(p)
            writer1 = File.Create(p)
            writer1.Close()
        Else
            writer1 = File.Create(p)
            writer1.Close()
        End If
    End Sub

    Public Shared Sub writelogfail()
        Dim errorclass As New IFLGetSetUI.IFLGetSetUIClass

        Dim writer2 As StreamWriter = Nothing
        writer2 = File.AppendText(p)
        writer2.WriteLine("Failed Generation")
        'writer2.WriteLine(errorclass.ErrorMessage.ToString)
        'writer2.WriteLine(errorclass._oErrorObject.Source.ToString())
        'writer2.WriteLine(IFLGetSetUI.IFLGetSetUIClass._oErrorObject.StackTrace.ToString())
        'writer2.WriteLine(IFLGetSetUI.IFLGetSetUIClass._oErrorObject.TargetSite.ToString())
        'writer2.WriteLine(IFLGetSetUI.IFLGetSetUIClass._oErrorObject.InnerException.Message.ToString())
        writer2.WriteLine("Customer: " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CustomerName_ContractDetails.ToString)
        writer2.WriteLine("Code Number: " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString)
        writer2.Close()

    End Sub

End Class
