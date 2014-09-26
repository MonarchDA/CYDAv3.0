Public Class CMSUtil

    Private _message As String

    Public ReadOnly Property Message() As String
        Get
            Return _message
        End Get
    End Property

    Public Function Start(ByVal strFolderPath As String) As Boolean
        _message = String.Empty

        If Not CVSFileUtil.isFolder(strFolderPath) Then
            _message = strFolderPath & " is not a folder path or exits."
            Return False
        End If

        'Routing METHDR
        DoProcess(New METHDR_CompleteCylinderProcess, strFolderPath)

        DoProcess(New METHDR_TubeProcess, strFolderPath)

        DoProcess(New METHDR_RodProcess, strFolderPath)

        DoProcess(New METHDR_LugProcess, strFolderPath)

        'Tooling MTHL
        DoProcess(New MTHL_TubeProcess, strFolderPath)

        DoProcess(New MTHL_RodProcess, strFolderPath)

        DoProcess(New MTHL_LugProcess, strFolderPath)

        Return True
    End Function

    Private Sub DoProcess(ByVal oProcess As ICMS_Process, ByVal strFolderPath As String)
        Dim strData As String = String.Empty

        strData = oProcess.Start()

        If String.IsNullOrEmpty(strData) Then
            _message += oProcess.ToString & " failed updation." & vbLf & "Data is not available" & vbLf
            Return
        End If

        If String.IsNullOrEmpty(oProcess.PartNumber) Then
            _message += oProcess.ToString & " failed updation." & vbLf & "Part number is not available" & vbLf
            Return
        End If

        If CVSFileUtil.Write(strData, strFolderPath & "\" & oProcess.FileName & ".csv") Then
            _message += oProcess.ToString & " successfully updated." & vbLf
        Else
            _message += oProcess.ToString & " failed updation." & vbLf & CVSFileUtil.Message & vbLf
        End If
    End Sub
End Class
