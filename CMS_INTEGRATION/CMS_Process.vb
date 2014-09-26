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
        Try
            oMethdr.Resource = oWCDetails.WorkCenter

            '18_02_2011     RAGAVA
            Dim iMen As Integer = 1
            Try
                Dim strSql As String = "Select * from WorkCenter_MenMachineDetails where WorkCenter = '" & oWCDetails.WorkCenter.ToString.Substring(2, 3) & "'"
                Dim dr1 As DataRow = MonarchConnectionObject.GetDataRow(strSql)
                If Not dr1 Is Nothing Then
                    iMen = dr1("NumberOfMen")
                    'anup 16-03-2011 start
                    oMethdr.NumberOfMen = iMen
                    'anup 16-03-2011 till here
                End If
            Catch ex As Exception
            End Try
            'Till   Here

            If oWCDetails.WorkCenter = "WC631" Then
                'oMethdr.ScheduleRunStandard = ObjClsWeldedCylinderFunctionalClass.PaintStandardCost
                'oMethdr.ScheduleRunStandard = ObjClsWeldedCylinderFunctionalClass.PaintStandardCost * iMen      '18_02_2011     RAGAVA
                oMethdr.ScheduleRunStandard = ObjClsWeldedCylinderFunctionalClass.PaintStandardCost '   05_09_2011  RAGAVA   * iMen      '18_02_2011     RAGAVA
                oMethdr.SetupStandard = oWCDetails.SetupCost
            Else
                'oMethdr.ScheduleRunStandard = oWCDetails.RunCost
                oMethdr.ScheduleRunStandard = oWCDetails.RunCost * iMen     '18_02_2011     RAGAVA
                oMethdr.SetupStandard = oWCDetails.SetupCost
            End If
            Dim dr As DataRow = GetWorkStationRow(oWCDetails.WorkCenter)
            If Not dr Is Nothing Then
                oMethdr.Department = Format(Val(IIf(IsDBNull(dr("DepartmentNumber")), "0", dr("DepartmentNumber"))), "00")      '09_10_2010   RAGAVA  Format Added
                oMethdr.Operation = IIf(IsDBNull(dr("Operation")), "0", dr("Operation"))
            Else
                oMethdr.Department = String.Empty
                oMethdr.Operation = "0"
            End If
        Catch ex As Exception
        End Try
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
