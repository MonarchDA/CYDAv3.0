Public MustInherit Class CMS_Process
    Implements ICMS_Process

    Protected _partNumber As String

    Protected Sub New(ByVal partNumber As String)
        _partNumber = partNumber
    End Sub

    '13_08_2010   RAGAVA
    Protected Function GetWorkStationRow(ByVal strWS As String) As DataRow
        GetWorkStationRow = Nothing
        Try
            Dim strSql As String = "Select * from Welded.WorkCenterRates where WorkStation = '" & strWS & "'"
            GetWorkStationRow = MonarchConnectionObject.GetDataRow(strSql)
        Catch ex As Exception
        End Try
        Return GetWorkStationRow
    End Function

    Protected Sub SetValues(ByVal oMethdr As CMS_METHDR, ByVal oWCDetails As WCStructure)

        oMethdr.Resource = oWCDetails.WorkCenter
        oMethdr.ScheduleRunStandard = oWCDetails.RunCost
        oMethdr.SetupStandard = oWCDetails.SetupCost

        Dim dr As DataRow = GetWorkStationRow(oWCDetails.WorkCenter)
        If Not dr Is Nothing Then
            oMethdr.Department = IIf(IsDBNull(dr("DepartmentNumber")), "0", dr("DepartmentNumber"))
            oMethdr.Operation = IIf(IsDBNull(dr("Operation")), "0", dr("Operation"))
        Else
            oMethdr.Department = String.Empty
            oMethdr.Operation = "0"
        End If
    End Sub

    Public ReadOnly Property PartNumber() As String Implements ICMS_Process.PartNumber
        Get
            Return _partNumber
        End Get
    End Property

    Public MustOverride ReadOnly Property FileName() As String Implements ICMS_Process.FileName

    Public MustOverride Function Start() As String Implements ICMS_Process.Start

    Public Overrides Function ToString() As String Implements ICMS_Process.ToString
        Return "Abstract CMS Process"
    End Function

End Class
