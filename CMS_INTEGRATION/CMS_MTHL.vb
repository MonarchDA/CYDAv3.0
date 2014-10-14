Public Class CMS_MTHL

    Private Shared ReadOnly _methodType As String
    Private Shared ReadOnly _alternateMethodNumber As String
    Private Shared ReadOnly _plantCode As String
    Private Shared ReadOnly _requiredSetup As YesNo
    Private Shared ReadOnly _requiredRun As YesNo
    Private Shared ReadOnly _quantity As String
    Private Shared ReadOnly _units As String

    Private _partNumbers As String
    Private _sequence As String
    Private _lineNumbers As String
    Private _toolNumbers As String
    Private _createdBy As String = String.Empty
    Private _creationDate As String = String.Empty
    Private _updatedBy As String = String.Empty
    Private _updateDate As String = String.Empty
    Private _department As String = String.Empty
    Private _resource As String = String.Empty
    Private _futureUse1 As String = String.Empty
    Private _futureUse2 As String = String.Empty
    Private _futureUse3 As String = String.Empty
    Private _futureUse4 As String = String.Empty
    Private _futureUse5 As String = String.Empty

    Shared Sub New()
        'Defaultly fixed values
        _methodType = 1
        _alternateMethodNumber = 0
        _plantCode = "C01"
        _requiredSetup = YesNo.Yes '"Y"
        _requiredRun = YesNo.Yes '"Y"
        _quantity = 1
        _units = "EA"
    End Sub

    Public WriteOnly Property PartNumbers() As String
        Set(ByVal value As String)
            _partNumbers = value
        End Set
    End Property

    Public WriteOnly Property Sequence() As String
        Set(ByVal value As String)
            _sequence = value
        End Set
    End Property

    Public WriteOnly Property LineNumbers() As String
        Set(ByVal value As String)
            _lineNumbers = value
        End Set
    End Property

    Public WriteOnly Property ToolNumbers() As String
        Set(ByVal value As String)
            _toolNumbers = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Dim strFormat As String
        strFormat = "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}"

        Return String.Format(strFormat, _methodType, _alternateMethodNumber, _plantCode, _partNumbers, _sequence, _lineNumbers, _
                _toolNumbers, GetYesNo(_requiredSetup), GetYesNo(_requiredRun), _quantity, _units, _createdBy, _creationDate, _updatedBy, _
                _updateDate, _department, _resource, _futureUse1, _futureUse2, _futureUse3, _futureUse4, _futureUse5)

    End Function

    Private Function GetYesNo(ByVal yesno As YesNo) As String

        If yesno = CMS_MTHL.YesNo.Yes Then
            Return "Y"
        ElseIf yesno = CMS_MTHL.YesNo.No Then
            Return "N"
        Else
            Return "Not Define"
        End If
    End Function

    Public Enum YesNo
        Yes
        No
    End Enum


End Class

'23_09_2010    RAGAVA
Public Class CMS_MTHL_TubeTools

    Public TubeToolList As New ArrayList
    Public SequenceCount As New ArrayList       '24_09_2010   RAGAVA
    'Public RodToolList As New ArrayList       


    Public Sub GetTools_10_Logics()
        Try
            '10-1
            'TubeToolList.Add("10&WI10-E-99")
            TubeToolList.Add("10&WI09-E-99")          '21_10_2010    RAGAVA
            GetProgram_Tools(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, "10-1")
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight > 40 Then
                TubeToolList.Add("10&CAUTION WEIGHT")
            End If

            '13_06_2011  RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth > 4 Then
                TubeToolList.Add("10&299801")       'Call Process Engineer
            End If
            'Till   HERE



            '07_10_2010    RAGAVA
            Dim nCount As Int16 = 0
            If SequenceCount.Count > 0 Then
                For i As Integer = 0 To SequenceCount.Count - 1
                    nCount = nCount + SequenceCount(i)
                Next
            End If
            SequenceCount.Add(TubeToolList.Count - nCount)

            ''10-2     SPECIAL CONDITION
            'TubeToolList.Add("10&WI10-E-99")
            'GetProgram_Tools(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, "10-2")
            'If TubeWeight >= 40 Then
            '    TubeToolList.Add("10&Caution Weight")
            'End If
            'SequenceCount.Add(TubeToolList.Count - SequenceCount(0))
        Catch ex As Exception
        End Try
    End Sub
    Public Sub GetTools_10_3_Logics()    'for sheet9
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "FILLET" Then
                'TubeToolList.Add("10&WI10-E-99")
                TubeToolList.Add("10&WI09-E-99")          '21_10_2010    RAGAVA
                GetProgram_Tools(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, "10-3")
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight > 40 Then
                    TubeToolList.Add("10&CAUTION WEIGHT")
                End If
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                'TubeToolList.Add("10&WI10-E-99")
                TubeToolList.Add("10&WI09-E-99")          '21_10_2010    RAGAVA
                GetProgram_Tools(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, "10-4")
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight > 40 Then
                    TubeToolList.Add("10&CAUTION WEIGHT")
                End If
            End If
            '07_10_2010    RAGAVA
            Dim nCount As Int16
            For i As Integer = 0 To SequenceCount.Count - 1
                nCount = nCount + SequenceCount(i)
            Next
            SequenceCount.Add(TubeToolList.Count - nCount)
            'client has to give logic for groove type
        Catch ex As Exception
        End Try
    End Sub
    
    '09_11_2010   RAGAVA
    Public Sub GetTools_11_Logics()
        Try
            '11-2
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "FILLET" Then
                Dim strTool As String = GetFilletWeldTools()
                If Trim(strTool) <> "" Then
                    TubeToolList.Add("11&" & strTool)
                End If
                '11-3
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                Dim strTool As String = GetGrooveWeldTools()
                If Trim(strTool) <> "" Then
                    TubeToolList.Add("11&" & strTool)
                End If
            End If

            'TubeToolList.Add("11&Client Logic")
            'TubeToolList.Add("11&Client Logic")
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight >= 40 Then
                TubeToolList.Add("11&Caution Weight")
            End If
            '11-2 sheet missing
        Catch ex As Exception
        End Try
    End Sub
    '09_11_2010   RAGAVA
    Private Function GetFilletWeldTools() As String
        Try
            GetFilletWeldTools = ""
            Dim strQuery As String = "Select ToolId from FilletWeldTools_op11 where BoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString & " and WallThickness = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString
            Dim objDT As DataTable = MonarchConnectionObject.GetTable(strQuery)
            If objDT.Rows.Count > 0 Then
                GetFilletWeldTools = objDT.Rows(0).Item("ToolId").ToString()
            End If
            Return GetFilletWeldTools
        Catch ex As Exception
        End Try
    End Function
    '09_11_2010   RAGAVA
    Private Function GetGrooveWeldTools() As String
        Try
            GetGrooveWeldTools = ""
            Dim strQuery As String = "Select ToolId from GrooveWeldTools_op11 where BoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString & " and WallThickness = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString
            Dim objDT As DataTable = MonarchConnectionObject.GetTable(strQuery)
            If objDT.Rows.Count > 0 Then
                GetGrooveWeldTools = objDT.Rows(0).Item("ToolId").ToString()
            End If
            Return GetGrooveWeldTools
        Catch ex As Exception
        End Try
    End Function
    Public Sub GetTools_20_Logics()
        Try
            '20-1
            'TubeToolList.Add("20&WI10-E-75")
            TubeToolList.Add("20&WI09-E-75")      '14_10_2010   RAGAVA
            TubeToolList.Add("20&WI10-E-24")      '15_12_2010   RAGAVA
            'TubeToolList.Add("20&WI09-E-78")
            'ANUP 01-12-2010 TILL HERE
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight > 40 Then
                TubeToolList.Add("20&CAUTION WEIGHT")
            End If
            '07_10_2010    RAGAVA
            Dim nCount As Int16
            For i As Integer = 0 To SequenceCount.Count - 1
                nCount = nCount + SequenceCount(i)
            Next
            SequenceCount.Add(TubeToolList.Count - nCount)
            'Till    Here
            '20-2    SPECIAL CONDITION
            '20-3    SPECIAL CONDITION
            '20-4    SPECIAL CONDITION
            '20-5    SPECIAL CONDITION

        Catch ex As Exception
        End Try
    End Sub

    '29_02_2012   RAGAVA
    Public Sub GetTools_22_Logics()
        Try
            TubeToolList.Add("22&WI09-E-76")
            TubeToolList.Add("22&WI09-E-78")
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight > 40 Then
                TubeToolList.Add("22&CAUTION WEIGHT")
            End If
            Dim nCount As Int16
            For i As Integer = 0 To SequenceCount.Count - 1
                nCount = nCount + SequenceCount(i)
            Next
            SequenceCount.Add(TubeToolList.Count - nCount)
           

        Catch ex As Exception
        End Try
    End Sub

    Public Sub GetTools_30_Logics()
        Try
            '30-1
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objApp = Nothing
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.checkExcelInstance()
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objBook = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objApp.Workbooks.Open(System.Environment.CurrentDirectory & "\TUBE_CMS.xls")
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objBook.Worksheets("OP 30-1")
            'Tube OD
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("C34")
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD
            'Port OD
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("C35")
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortOD
            'objSheet.Range("B" & intI).Value
            TubeToolList.Add("30&WI09-E-27")
            TubeToolList.Add("30&" & ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("C47").Value)        'CAM
            If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortLocatorCode_Tube) <> "" Then
                TubeToolList.Add("30&" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortLocatorCode_Tube)   'Port Locator
            End If
            If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WPDS_PortCode_Tube) <> "" Then
                TubeToolList.Add("30&" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WPDS_PortCode_Tube)     'WPDS
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight > 40 Then
                TubeToolList.Add("30&CAUTION WEIGHT")
            End If
            Dim nCount As Integer = 0
            For i As Integer = 0 To SequenceCount.Count - 1
                nCount = nCount + SequenceCount(i)
            Next
            SequenceCount.Add(TubeToolList.Count - nCount)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub GetTools_31_Logics()
        Try
            '31-1       SPECIAL CONDITION      'This OP is only used if port welding OP is split up
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strRodEndPortLocatorCode_Purchase <> ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strBaseEndPortLocatorCode_Purchase Then        '07_10_2010    RAGAVA
                ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objApp = Nothing
                ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.checkExcelInstance()
                ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objBook = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objApp.Workbooks.Open(System.Environment.CurrentDirectory & "\TUBE_CMS.xls")
                ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objBook.Worksheets("OP 31-1")
                'Tube OD
                ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("C24")
                ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD
                'Port OD
                ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("C25")
                ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortOD
                'objSheet.Range("B" & intI).Value
                TubeToolList.Add("31&WI09-E-67")
                TubeToolList.Add("31&" & ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("C37").Value)        'CAM
                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortLocatorCode_Tube) <> "" Then
                    TubeToolList.Add("31&" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortLocatorCode_Tube)   'Port Locator
                End If
                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WPDS_PortCode_Tube) <> "" Then
                    TubeToolList.Add("31&" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WPDS_PortCode_Tube)     'WPDS
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight > 40 Then
                    TubeToolList.Add("31&CAUTION WEIGHT")
                End If

                'SequenceCount.Add(TubeToolList.Count - (SequenceCount(0) + SequenceCount(1) + SequenceCount(2)))      '24_09_2010   RAGAVA
                Dim nCount As Integer = 0
                For i As Integer = 0 To SequenceCount.Count - 1
                    nCount = nCount + SequenceCount(i)       '24_09_2010   RAGAVA
                Next
                SequenceCount.Add(TubeToolList.Count - nCount)      '24_09_2010   RAGAVA
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub GetTools_40_Logics()
        Try
            '40-1
            If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleBaseEnd.Text) = "Straight" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text) = "Straight" AndAlso (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationBaseEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text) Then
                'TubeToolList.Add("40&WI10-E-91")
                TubeToolList.Add("40&WI09-E-91")          '14_10_2010   RAGAVA
                'PROGRAM CHART  & GUAGE CHART  From Client Required
                '09_11_2010   RAGAVA
                Dim strTool As String = GetProgramChartTools()
                Dim strGaugeTool As String = GetGuageChartTools()
                If Trim(strTool) <> "" Then
                    TubeToolList.Add("40&" & strTool)
                End If
                If Trim(strGaugeTool) <> "" Then
                    TubeToolList.Add("40&" & strGaugeTool)
                End If
                'Till  Here
                'GetProgram_Tools(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, "40-1")
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight > 40 Then
                    TubeToolList.Add("40&CAUTION WEIGHT")
                End If
            Else 'If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleBaseEnd.Text) = "90" OrElse Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text) = "90" Then
                '40-2
                'TubeToolList.Add("40&WI10-E-91")
                TubeToolList.Add("40&WI09-E-91")          '14_10_2010   RAGAVA

                'PROGRAM CHART  & GUAGE CHART  From Client Required

                '09_11_2010   RAGAVA
                Dim strTool As String = GetProgramChartTools()
                Dim strGaugeTool As String = GetGuageChartTools()
                If Trim(strTool) <> "" Then
                    TubeToolList.Add("40&" & strTool)
                End If
                If Trim(strGaugeTool) <> "" Then
                    TubeToolList.Add("40&" & strGaugeTool)
                End If
                'Till  Here
                'GetProgram_Tools(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, "40-2")
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight > 40 Then
                    TubeToolList.Add("40&CAUTION WEIGHT")
                End If
            End If
            Dim nCount As Integer = 0
            For i As Integer = 0 To SequenceCount.Count - 1
                nCount = nCount + SequenceCount(i)
            Next
            SequenceCount.Add(TubeToolList.Count - nCount)
            '40-5    'SHEETS NOT AVAILABLE
            '40-6    'SHEETS NOT AVAILABLE
        Catch ex As Exception

        End Try
    End Sub

    '29_02_2012   RAGAVA
    Public Sub GetTools_42_Logics(Optional ByVal strOPT As String = "")
        Try

            '42-2
            If strOPT = "" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Bothends" Then
                    TubeToolList.Add("42&WI09-E-75")
                    TubeToolList.Add("42&WI10-E-24")
                    TubeToolList.Add(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT"))
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight > 40 Then
                        TubeToolList.Add("42&CAUTION WEIGHT")
                    End If
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType.StartsWith("Rephasing") = True Then
                    '42-1
                    TubeToolList.Add("42&WI09-E-75")
                    TubeToolList.Add("42&WI10-E-24")
                    TubeToolList.Add(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT"))
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight > 40 Then
                        TubeToolList.Add("42&CAUTION WEIGHT")
                    End If
                End If
            Else
                '42-3
                TubeToolList.Add("42&WI09-E-75")
                TubeToolList.Add("42&WI10-E-24")
                TubeToolList.Add(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT"))
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight > 40 Then
                    TubeToolList.Add("42&CAUTION WEIGHT")
                End If
            End If
            Dim nCount As Integer = 0
            For i As Integer = 0 To SequenceCount.Count - 1
                nCount = nCount + SequenceCount(i)
            Next
            SequenceCount.Add(TubeToolList.Count - nCount)
        Catch ex As Exception

        End Try
    End Sub

    '29_02_2012   RAGAVA
    Public Sub GetTools_43_Logics()
        Try
            TubeToolList.Add("43&WI09-E-27")

            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objApp = Nothing
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.checkExcelInstance()
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objBook = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objApp.Workbooks.Open(System.Environment.CurrentDirectory & "\OP_043_1.xls")
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objBook.Worksheets("OP 043-1")
            'Tube OD
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("C34")
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD
            'Port OD
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("C35")
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortOD
         
            TubeToolList.Add("43&" & ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("C47").Value)        'CAM
            If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortLocatorCode_Tube) <> "" Then
                TubeToolList.Add("43&" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortLocatorCode_Tube)   'Port Locator
            End If
            If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WPDS_PortCode_Tube) <> "" Then
                TubeToolList.Add("43&" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WPDS_PortCode_Tube)     'WPDS
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight > 40 Then
                TubeToolList.Add("43&CAUTION WEIGHT")
            End If
            Dim nCount As Integer = 0
            For i As Integer = 0 To SequenceCount.Count - 1
                nCount = nCount + SequenceCount(i)
            Next
            SequenceCount.Add(TubeToolList.Count - nCount)
        Catch ex As Exception

        End Try
    End Sub

    '29_02_2012   RAGAVA
    Public Sub GetTools_44_Logics()
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strRodEndPortLocatorCode_Purchase <> ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strBaseEndPortLocatorCode_Purchase Then        '07_10_2010    RAGAVA

                TubeToolList.Add("44&WI09-E-27")

                ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objApp = Nothing
                ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.checkExcelInstance()
                ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objBook = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objApp.Workbooks.Open(System.Environment.CurrentDirectory & "\OP_044_1.xls")
                ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objBook.Worksheets("OP 043-1")
                'Tube OD
                ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("C34")
                ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD
                'Port OD
                ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("C35")
                ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortOD

                TubeToolList.Add("44&" & ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("C47").Value)        'CAM
                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortLocatorCode_Tube) <> "" Then
                    TubeToolList.Add("44&" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortLocatorCode_Tube)   'Port Locator
                End If
                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WPDS_PortCode_Tube) <> "" Then
                    TubeToolList.Add("44&" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WPDS_PortCode_Tube)     'WPDS
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight > 40 Then
                    TubeToolList.Add("44&CAUTION WEIGHT")
                End If
                Dim nCount As Integer = 0
                For i As Integer = 0 To SequenceCount.Count - 1
                    nCount = nCount + SequenceCount(i)
                Next
                SequenceCount.Add(TubeToolList.Count - nCount)
            End If
        Catch ex As Exception

        End Try
    End Sub
    



    '09_11_2010   RAGAVA
    Private Function GetProgramChartTools() As String
        Try
            GetProgramChartTools = ""
            Dim strQuery As String = "Select ToolId from ButtressThreadsTool where BoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString & " and WallThickness = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString
            Dim objDT As DataTable = MonarchConnectionObject.GetTable(strQuery)
            If objDT.Rows.Count > 0 Then
                GetProgramChartTools = objDT.Rows(0).Item("ToolId").ToString()
            End If
            Return GetProgramChartTools
        Catch ex As Exception
        End Try
    End Function

    '09_11_2010   RAGAVA
    Private Function GetGuageChartTools() As String
        Try
            GetGuageChartTools = ""
            Dim strQuery As String = "Select GaugeNumber from ButtressGaugeChart_op40 where BoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
            Dim objDT As DataTable = MonarchConnectionObject.GetTable(strQuery)
            If objDT.Rows.Count > 0 Then
                GetGuageChartTools = objDT.Rows(0).Item("GaugeNumber").ToString()
            End If
            Return GetGuageChartTools
        Catch ex As Exception
        End Try
    End Function

    Public Sub GetTools_45_Logics()
        Try
            '45-1
            If (ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd.StartsWith("90") = True OrElse ObjClsWeldedCylinderFunctionalClass.strPortAngle_RodEnd.StartsWith("90") = True) OrElse Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleBaseEnd.Text) = "Straight" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text) = "Straight" AndAlso (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationBaseEnd.Text <> ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text AndAlso ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text <> "0") Then   '06_04_2011  RAGAVA changed = to <>       '23_12_2010   RAGAVA   0 angle condition added
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight > 40 Then
                    TubeToolList.Add("45&CAUTION WEIGHT")
                End If

                '45-2
            ElseIf (ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd.StartsWith("90") = True AndAlso ObjClsWeldedCylinderFunctionalClass.strPortAngle_RodEnd.StartsWith("90") = True) Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight > 40 Then
                    TubeToolList.Add("45&CAUTION WEIGHT")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub GetTools_50_Logics()
        Try
            '50-1    
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_BaseEnd >= 0.125 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_RodEnd >= 0.125 Then
                '50-1 
                'TubeToolList.Add("50&WI10-E-76")
                'TubeToolList.Add("50&WI10-E-78")
                TubeToolList.Add("50&WI09-E-76")
                TubeToolList.Add("50&WI09-E-78")
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_BaseEnd <= 0.125 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_RodEnd <= 0.125 Then
                '50-2
                'TubeToolList.Add("50&WI10-E-76")
                'TubeToolList.Add("50&WI10-E-78")
                TubeToolList.Add("50&WI09-E-76")
                TubeToolList.Add("50&WI09-E-78")
            Else
                '50-3
                'TubeToolList.Add("50&WI10-E-76")
                'TubeToolList.Add("50&WI10-E-78")
                TubeToolList.Add("50&WI09-E-76")
                TubeToolList.Add("50&WI09-E-78")
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight > 40 Then
                TubeToolList.Add("50&CAUTION WEIGHT")
            End If
            Dim nCount As Integer = 0
            For i As Integer = 0 To SequenceCount.Count - 1
                nCount = nCount + SequenceCount(i)
            Next
            SequenceCount.Add(TubeToolList.Count - nCount)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub GetTools_50_4_Logics()
        Try
            TubeToolList.Add("50&WI10-E-24")
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight > 40 Then
                TubeToolList.Add("50&CAUTION WEIGHT")
            End If
            Dim nCount As Integer = 0
            For i As Integer = 0 To SequenceCount.Count - 1
                nCount = nCount + SequenceCount(i)
            Next
            SequenceCount.Add(TubeToolList.Count - nCount)
        Catch ex As Exception

        End Try
    End Sub

    'anup 07-03-2011 start
    'Public Sub GetTools_55_Logics()
    '    Try
    '        '07_12_2010   RAGAVA
    '        TubeToolList.Add("55&WI09-E-91")
    '        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 1.5 Then
    '            TubeToolList.Add("55&0695")
    '        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 1.75 Then
    '            TubeToolList.Add("55&0696")
    '        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2 Then
    '            TubeToolList.Add("55&0665")
    '        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2.25 Then
    '            TubeToolList.Add("55&0674")
    '        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2.5 Then
    '            TubeToolList.Add("55&0705")
    '        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2.75 Then
    '            TubeToolList.Add("55&0677")
    '        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 3 Then
    '            TubeToolList.Add("55&0701")
    '        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 3.5 Then
    '            TubeToolList.Add("55&1041")
    '        End If
    '        'Till   Here
    '    Catch ex As Exception

    '    End Try
    'End Sub
    Public Sub GetTools_55_Logics()
        Try
            '07_12_2010   RAGAVA
            'TubeToolList.Add("55&WI09-E-91")
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 1.5 Then
            '    TubeToolList.Add("55&O0695")
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 1.75 Then
            '    TubeToolList.Add("55&O0696")
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2 Then
            '    TubeToolList.Add("55&O0665")
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2.25 Then
            '    TubeToolList.Add("55&O0674")
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2.5 Then
            '    TubeToolList.Add("55&O0705")
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2.75 Then
            '    TubeToolList.Add("55&O0677")
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 3 Then
            '    TubeToolList.Add("55&O0701")
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 3.25 Then
            '    TubeToolList.Add("55&O1041")
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 3.5 Then
            '    TubeToolList.Add("55&O1052")
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 3.75 Then
            '    TubeToolList.Add("55&O1053")
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 4.5 Then
            '    TubeToolList.Add("55&O1060")
            'End If
            ''Till   Here


            TubeToolList.Add("55&WI09-E-91")
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 1.5 Then
                TubeToolList.Add("55&O0695")
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 1.75 Then
                TubeToolList.Add("55&O0696")
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2 Then
                TubeToolList.Add("55&O0665")
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2.25 Then
                TubeToolList.Add("55&O0674")
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2.5 Then
                TubeToolList.Add("55&O0705")
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2.75 Then
                TubeToolList.Add("55&O0677")
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 3 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness <= 1.88 Then
                TubeToolList.Add("55&O0701")
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 3 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness <= 0.25 Then
                TubeToolList.Add("55&O1041")
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 3.25 Then
                TubeToolList.Add("55&O1052")
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 3.5 Then
                TubeToolList.Add("55&O0038")
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 3.75 Then
                TubeToolList.Add("55&O1097")
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 4 Then
                TubeToolList.Add("55&O1093")
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 4.25 Then
                TubeToolList.Add("55&O1094")
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 4.5 Then
                TubeToolList.Add("55&O1095")
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 5 Then
                TubeToolList.Add("55&O1138")
            End If
            



        Catch ex As Exception

        End Try
    End Sub
    'anup 07-03-2011 till here

    Public Sub GetTools_59_Logics()
        Try
            '59-1
            TubeToolList.Add("59&WI09-E-106")
            'Dim strQuery As String = "select TWDD.WPDS from TubeWeldDataDetails TWDD,TubeWallThicknessDetails TWTD,BoreDiameterDetails BDD where BDD.ID=TWDD.BoreID and BDD.BoreDiameter = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString & " and TWTD.ID = TWDD.TubeThickID and TWTD.MinWallThickness <= " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString & " and TWTD.MaxWallThickness >= " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString & " and TWDD.Groove_Fillet = '" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType & "'"
            Dim strQuery As String = "select TWDD.WPDS from TubeWeldDataDetails TWDD,TubeWallThicknessDetails TWTD,BoreDiameterDetails BDD where BDD.ID=TWDD.BoreID and BDD.BoreDiameter = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString & " and TWTD.ID = TWDD.TubeThickID and TWTD.MinWallThickness <= " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString & " and TWTD.MaxWallThickness >= " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString & " and TWDD.Groove_Fillet = 'Fillet'"       '03_11_2010   RAGAVA
            Dim WPDS As String = MonarchConnectionObject.GetValue(strQuery)
            If Not WPDS Is Nothing Then
                TubeToolList.Add("59&" & WPDS)
            Else
                TubeToolList.Add("59&299800")          '20_10_2010     RAGAVA
            End If
            strQuery = "Select ColletNumber From CmsColletDetails where BoreDiameter = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString
            Dim ColletNumber As String = MonarchConnectionObject.GetValue(strQuery)
            If Not ColletNumber Is Nothing Then
                TubeToolList.Add("59&" & ColletNumber)
            End If
            '26_11_2010   RAGAVA
            Try
                strQuery = "Select GaugeNumber From CmsColletDetails where BoreDiameter = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString      '26_11_2010   RAGAVA  GaugeNumber  added
                Dim GaugeNumber As String = MonarchConnectionObject.GetValue(strQuery)
                If Not GaugeNumber Is Nothing Then
                    TubeToolList.Add("59&" & GaugeNumber)
                End If
            Catch ex As Exception
            End Try    
            'Till   Here
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight > 40 Then
                TubeToolList.Add("59&CAUTION WEIGHT")
            End If
            Dim nCount As Integer = 0
            For i As Integer = 0 To SequenceCount.Count - 1
                nCount = nCount + SequenceCount(i)       '24_09_2010   RAGAVA
            Next
            SequenceCount.Add(TubeToolList.Count - nCount)      '24_09_2010   RAGAVA
        Catch ex As Exception

        End Try
    End Sub
    Public Sub GetTools_60_Logics()
        Try
            '60-1    'LATHE WELD
            TubeToolList.Add("60&WI09-E-63")
            Dim strQuery As String = "select TWDD.WPDS from TubeWeldDataDetails TWDD,TubeWallThicknessDetails TWTD,BoreDiameterDetails BDD where BDD.ID=TWDD.BoreID and BDD.BoreDiameter = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString & " and TWTD.ID = TWDD.TubeThickID and TWTD.MinWallThickness <= " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString & " and TWTD.MaxWallThickness >= " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString & " and TWDD.Groove_Fillet = '" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType & "'"
            Dim WPDS As String = MonarchConnectionObject.GetValue(strQuery)
            If Not WPDS Is Nothing Then
                TubeToolList.Add("60&" & WPDS)
            Else
                TubeToolList.Add("60&299800")          '20_10_2010     RAGAVA
            End If
            TubeToolList.Add("60&299800")
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight > 40 Then
                TubeToolList.Add("60&CAUTION WEIGHT")
            End If
            Dim nCount As Integer = 0
            For i As Integer = 0 To SequenceCount.Count - 1
                nCount = nCount + SequenceCount(i)
            Next
            SequenceCount.Add(TubeToolList.Count - nCount)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub GetTools_61_Logics()
        Try
            TubeToolList.Add("61&WI09-E-67")
            Dim strQuery As String = "select TWDD.WPDS from TubeWeldDataDetails TWDD,TubeWallThicknessDetails TWTD,BoreDiameterDetails BDD where BDD.ID=TWDD.BoreID and BDD.BoreDiameter = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString & " and TWTD.ID = TWDD.TubeThickID and TWTD.MinWallThickness <= " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString & " and TWTD.MaxWallThickness >= " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString & " and TWDD.Groove_Fillet = '" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType & "'"
            Dim WPDS As String = MonarchConnectionObject.GetValue(strQuery)
            If Not WPDS Is Nothing Then
                TubeToolList.Add("61&" & WPDS)
            Else
                TubeToolList.Add("61&299800")          '20_10_2010     RAGAVA
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" Then
                TubeToolList.Add("61&500991")
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "BH" Then
                TubeToolList.Add("61&500990")
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected Then
                    TubeToolList.Add("61&500990")
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                    TubeToolList.Add("61&500990")      'Spacer Required
                End If
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight > 40 Then
                TubeToolList.Add("61&CAUTION WEIGHT")
            End If
            Dim nCount As Integer = 0
            For i As Integer = 0 To SequenceCount.Count - 1
                nCount = nCount + SequenceCount(i)
            Next
            SequenceCount.Add(TubeToolList.Count - nCount)      '24_09_2010   RAGAVA
        Catch ex As Exception

        End Try
    End Sub
    Public Sub GetTools_62_Logics()
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso (ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "SINGLE LUG" OrElse ObjClsWeldedCylinderFunctionalClass.FacricatedPart2 = "SINGLE LUG") Then  '15_05_2012   RAGAVA Then           '19_01_2012    RAGAVA    
                TubeToolList.Add("62&WI09-E-67")
                TubeToolList.Add("62&299770")
                TubeToolList.Add("62&Roller Jig")
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight > 40 Then
                    TubeToolList.Add("62&CAUTION WEIGHT")
                End If
                Dim nCount As Integer = 0
                For i As Integer = 0 To SequenceCount.Count - 1
                    nCount = nCount + SequenceCount(i)       '24_09_2010   RAGAVA
                Next
                SequenceCount.Add(TubeToolList.Count - nCount)      '24_09_2010   RAGAVA
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub GetTools_70_3_Logics()   'For Sheet1 Logics
        Try
            '70-3
            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize" Then
                TubeToolList.Add("70&299801")       'Call Process Engineer
                Dim nCount As Integer = 0
                For i As Integer = 0 To SequenceCount.Count - 1
                    nCount = nCount + SequenceCount(i)
                Next
                SequenceCount.Add(TubeToolList.Count - nCount)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub GetTools_70_Logics()     'For Sheet 2 logics
        Try
            '70-1
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                TubeToolList.Add("70&299801")       'Call Process Engineer
                Dim nCount As Integer = 0
                For i As Integer = 0 To SequenceCount.Count - 1
                    nCount = nCount + SequenceCount(i)       '24_09_2010   RAGAVA
                Next
                SequenceCount.Add(TubeToolList.Count - nCount)      '24_09_2010   RAGAVA
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                TubeToolList.Add("70&299801")       'Call Process Engineer
                Dim nCount As Integer = 0
                For i As Integer = 0 To SequenceCount.Count - 1
                    nCount = nCount + SequenceCount(i)       '24_09_2010   RAGAVA
                Next
                SequenceCount.Add(TubeToolList.Count - nCount)      '24_09_2010   RAGAVA
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso (Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbPinHoleSizeType.Text) = "Custom" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity > 0) Then
                TubeToolList.Add("70&299801")       'Call Process Engineer
                Dim nCount As Integer = 0
                For i As Integer = 0 To SequenceCount.Count - 1
                    nCount = nCount + SequenceCount(i)       '24_09_2010   RAGAVA
                Next
                SequenceCount.Add(TubeToolList.Count - nCount)      '24_09_2010   RAGAVA
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function GetSheet1_Tools() As ArrayList
        Try
            GetTools_10_Logics()
            GetTools_20_Logics()
            GetTools_30_Logics()
            GetTools_31_Logics()
            GetTools_40_Logics()
            GetTools_50_Logics()
            GetTools_60_Logics()
            GetTools_70_3_Logics()
        Catch ex As Exception
        End Try
        Return TubeToolList
    End Function
    Public Function GetSheet2_Tools() As ArrayList
        Try
            GetTools_10_Logics()
            GetTools_20_Logics()
            GetTools_30_Logics()
            GetTools_31_Logics()
            GetTools_40_Logics()
            GetTools_50_Logics()
            GetTools_61_Logics()
            GetTools_62_Logics()
            GetTools_70_Logics()
        Catch ex As Exception
        End Try
        Return TubeToolList
    End Function

    Public Function GetSheet3_Tools() As ArrayList
        Try
            GetTools_11_Logics()
            GetTools_20_Logics()
            GetTools_30_Logics()
            GetTools_31_Logics()
            GetTools_40_Logics()
            GetTools_60_Logics()
            GetTools_70_3_Logics()
        Catch ex As Exception
        End Try
        Return TubeToolList
    End Function
    Public Function GetSheet4_Tools() As ArrayList
        Try
            GetTools_11_Logics()
            GetTools_20_Logics()
            GetTools_30_Logics()
            GetTools_31_Logics()
            GetTools_40_Logics()
            GetTools_61_Logics()
            GetTools_62_Logics()
            GetTools_70_Logics()
        Catch ex As Exception
        End Try
        Return TubeToolList
    End Function
    Public Function GetSheet5_Tools() As ArrayList
        Try
            GetTools_10_Logics()
            GetTools_20_Logics()
            GetTools_30_Logics()
            GetTools_31_Logics()
            GetTools_45_Logics()
            GetTools_50_Logics()
            GetTools_55_Logics()   'Logics Missing
            GetTools_60_Logics()
            GetTools_70_3_Logics()
        Catch ex As Exception
        End Try
        Return TubeToolList
    End Function
    Public Function GetSheet6_Tools() As ArrayList
        Try
            GetTools_10_Logics()
            GetTools_20_Logics()
            GetTools_30_Logics()
            GetTools_31_Logics()
            GetTools_45_Logics()
            GetTools_50_Logics()
            GetTools_55_Logics()   'Logics Missing
            GetTools_61_Logics()
            GetTools_62_Logics()
            GetTools_70_Logics()
            GetTools_70_3_Logics()        '29_02_2012   RAGAVA
        Catch ex As Exception
        End Try
        Return TubeToolList
    End Function
    Public Function GetSheet7_Tools() As ArrayList
        Try
            GetTools_11_Logics()
            GetTools_20_Logics()
            GetTools_30_Logics()
            GetTools_31_Logics()
            GetTools_55_Logics()   'Logics Missing
            GetTools_60_Logics()
            GetTools_62_Logics()
            GetTools_70_3_Logics()
        Catch ex As Exception
        End Try
        Return TubeToolList
    End Function

    Public Function GetSheet8_Tools() As ArrayList
        Try
            GetTools_11_Logics()
            GetTools_20_Logics()
            GetTools_30_Logics()
            GetTools_31_Logics()
            GetTools_55_Logics()   'Logics Missing
            GetTools_61_Logics()
            GetTools_62_Logics()
            GetTools_70_Logics()
        Catch ex As Exception
        End Try
        Return TubeToolList
    End Function
    Public Function GetSheet9_Tools() As ArrayList
        Try
            GetTools_10_3_Logics()
            GetTools_50_4_Logics()
            GetTools_59_Logics()
            GetTools_60_Logics()
            GetTools_70_3_Logics()
        Catch ex As Exception
        End Try
        Return TubeToolList
    End Function
    Public Function GetSheet10_Tools() As ArrayList
        Try
            GetTools_10_3_Logics()
            GetTools_50_4_Logics()
            GetTools_59_Logics()     'CONDITIONAL
            GetTools_61_Logics()
            GetTools_62_Logics()
            GetTools_70_Logics()
        Catch ex As Exception
        End Try
        Return TubeToolList
    End Function
    Public Function GetSheet11_Tools() As ArrayList
        Try
            '09_11_2010  RAGAVA
            GetTools_11_Logics()    'sheet num's & Logic need to be provided by client
            GetTools_59_Logics()     'CONDITIONAL
            GetTools_60_Logics()
            GetTools_70_3_Logics()
        Catch ex As Exception
        End Try
        Return TubeToolList
    End Function
    Public Function GetSheet12_Tools() As ArrayList
        Try
            'GetTools_11_Logics()    'sheet num's & Logic need to be provided by client
            GetTools_59_Logics()     'CONDITIONAL
            GetTools_61_Logics()
            GetTools_62_Logics()
            GetTools_70_Logics()
        Catch ex As Exception
        End Try
        Return TubeToolList
    End Function

    '29_02_2012   RAGAVA
    Public Function GetSheet13_Tools() As ArrayList
        Try
            GetTools_10_Logics()
            GetTools_22_Logics()
            GetTools_42_Logics()
            GetTools_43_Logics()
            GetTools_44_Logics()
            GetTools_45_Logics()
            GetTools_55_Logics()
            GetTools_60_Logics()
            GetTools_70_3_Logics()
        Catch ex As Exception
        End Try
        Return TubeToolList
    End Function
    '29_02_2012   RAGAVA
    Public Function GetSheet14_Tools() As ArrayList
        Try
            GetTools_10_Logics()
            GetTools_22_Logics()
            GetTools_42_Logics()
            GetTools_43_Logics()
            GetTools_44_Logics()
            GetTools_45_Logics()
            GetTools_55_Logics()
            GetTools_60_Logics()
            GetTools_62_Logics()
            GetTools_70_Logics()
            GetTools_70_3_Logics()
        Catch ex As Exception
        End Try
        Return TubeToolList
    End Function

    '05_03_2012   RAGAVA
    Public Function GetSheet15_Tools() As ArrayList
        Try
            GetTools_10_3_Logics()
            GetTools_42_Logics("42-3")
            GetTools_50_Logics()
            GetTools_59_Logics()
            GetTools_60_Logics()
            GetTools_70_3_Logics()       
        Catch ex As Exception
        End Try
        Return TubeToolList
    End Function

    '05_03_2012   RAGAVA
    Public Function GetSheet16_Tools() As ArrayList
        Try
            GetTools_10_3_Logics()
            GetTools_42_Logics("42-3")
            GetTools_50_Logics()
            GetTools_59_Logics()
            GetTools_61_Logics()
            GetTools_62_Logics()
            GetTools_70_Logics()
            GetTools_70_3_Logics()
        Catch ex As Exception
        End Try
        Return TubeToolList
    End Function


    Private Sub GetProgram_Tools(ByVal BoreDiameter As Double, ByVal sheet As String)
        Try
            Dim strQuery As String
            strQuery = "select * from Tube_Program_Tool_Details where BoreDiameter = " & BoreDiameter.ToString
            Dim objDT As DataTable = MonarchConnectionObject.GetTable(strQuery)
            If objDT.Rows.Count > 0 Then
                If sheet = "10-1" Then
                    If BoreDiameter = 3 Then
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness <= 0.188 Then
                            TubeToolList.Add("10&" & objDT.Rows(0).Item("ProgramNumber1").ToString)
                            TubeToolList.Add("10&" & objDT.Rows(0).Item("ToolNumber1").ToString)
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness <= 0.25 Then
                            TubeToolList.Add("10&" & objDT.Rows(1).Item("ProgramNumber1").ToString)
                            TubeToolList.Add("10&" & objDT.Rows(1).Item("ToolNumber1").ToString)
                        End If
                    Else
                        TubeToolList.Add("10&" & objDT.Rows(0).Item("ProgramNumber1").ToString)
                        TubeToolList.Add("10&" & objDT.Rows(0).Item("ToolNumber1").ToString)
                    End If
                ElseIf sheet = "10-2" Then
                    If BoreDiameter = 3 Then
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness <= 0.188 Then
                            TubeToolList.Add("10&" & objDT.Rows(0).Item("ProgramNumber2").ToString)
                            TubeToolList.Add("10&" & objDT.Rows(0).Item("ToolNumber2").ToString)
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness <= 0.25 Then
                            TubeToolList.Add("10&" & objDT.Rows(1).Item("ProgramNumber2").ToString)
                            TubeToolList.Add("10&" & objDT.Rows(1).Item("ToolNumber2").ToString)
                        End If
                    Else
                        TubeToolList.Add("10&" & objDT.Rows(0).Item("ProgramNumber2").ToString)
                        TubeToolList.Add("10&" & objDT.Rows(0).Item("ToolNumber2").ToString)
                    End If
                ElseIf sheet = "10-3" Then
                    If BoreDiameter = 3 Then
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness <= 0.188 Then
                            TubeToolList.Add("10&" & objDT.Rows(0).Item("ProgramNumber3").ToString)
                            TubeToolList.Add("10&" & objDT.Rows(0).Item("ToolNumber3").ToString)
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness <= 0.25 Then
                            TubeToolList.Add("10&" & objDT.Rows(1).Item("ProgramNumber3").ToString)
                            TubeToolList.Add("10&" & objDT.Rows(1).Item("ToolNumber3").ToString)
                        End If
                    Else
                        TubeToolList.Add("10&" & objDT.Rows(0).Item("ProgramNumber3").ToString)
                        TubeToolList.Add("10&" & objDT.Rows(0).Item("ToolNumber3").ToString)
                    End If
                    '07_10_2010   RAGAVA
                ElseIf sheet = "10-4" Then
                    TubeToolList.Add("10&" & objDT.Rows(0).Item("ProgramNumber4").ToString)
                    TubeToolList.Add("10&" & objDT.Rows(0).Item("ToolNumber4").ToString)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
