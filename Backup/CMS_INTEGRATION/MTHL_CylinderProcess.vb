Public Class MTHL_CylinderProcess
    Inherits CMS_Process

    Private oToolList As New ArrayList
    Private SequenceCount As New ArrayList        '07_10_2010   RAGAVA
    Public Sub New()
        MyBase.New(String.Empty)
    End Sub

    Public Overrides Function Start() As String
        Try
            Dim strData As New System.Text.StringBuilder
            Dim intSequence As Integer = 10

            '28_09_2010   RAGAVA
            _partNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber
            GetTools_Cylinder()
            GetOilTestTools_Cylinder()    '07_10_2010   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.chkPaint.Checked = True Then    '09_10_2010    RAGAVA
                GetPaintTools_Cylinder()      '07_10_2010   RAGAVA
            End If
            Dim icount As Integer = 0
            Dim iCount1 As Integer = 0

            For Each oItem As String In oToolList
                
                strData.AppendLine(DoEachRowProcess(intSequence, oItem, icount))


                '07_10_2010   RAGAVA
                'icount = icount + 1
                If (icount + 1) >= SequenceCount(iCount1) Then
                    iCount1 = iCount1 + 1
                    intSequence = intSequence + 10
                    icount = 0
                Else
                    icount = icount + 1
                End If
                'Till    Here
            Next
            Return strData.ToString
        Catch ex As Exception
        End Try
    End Function

    '07_10_2010   RAGAVA
    Private Sub GetPaintTools_Cylinder()
        Try
            'oToolList.Add("WI09-E-09")
            oToolList.Add("WI09-E-11")        '08_11_2010    RAGAVA
            '06_07_2011  RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmGenerate.chkPackCylinderInPlasticBag.Checked = True Then
                oToolList.Add("275010")
            Else
                oToolList.Add("275254")
            End If
            'Till  Here
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strWeldCylinderWeight > 40 Then
                oToolList.Add("CAUTION WEIGHT")
            End If

            '07_10_2010    RAGAVA
            Dim nCount As Int16
            For i As Integer = 0 To SequenceCount.Count - 1
                nCount = nCount + SequenceCount(i)
            Next
            SequenceCount.Add(oToolList.Count - nCount)
            'Till    Here
        Catch ex As Exception

        End Try
    End Sub

    '07_10_2010   RAGAVA
    Private Sub GetOilTestTools_Cylinder()
        Try
            '09_10_2010   RAGAVA   Commented for Temporarly... need clarification from CLIENT
            '' ''oToolList.Add("WI09-E-56")
            '' ''If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.Breather <> 0 Then
            '' ''    oToolList.Add("CYLINDER STYLE 2")
            '' ''    'If Rephasing is YES
            '' ''    'oToolList.Add("CYLINDER STYLE 3")
            '' ''Else
            '' ''    oToolList.Add("CYLINDER STYLE 1")
            '' ''    'If Rephasing is YES
            '' ''    'oToolList.Add("CYLINDER STYLE 4")
            '' ''End If
            ' '' ''If Rephasing is YES
            ' '' ''REPHASING FLOW .2GPM
            '' ''oToolList.Add("SEE DRAWING")
            '' ''If ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbBaseGreaseZercType1.Text.ToString.IndexOf("Set Screw") <> -1 OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbBaseGreaseZercType2.Text.ToString.IndexOf("Set Screw") <> -1 OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbAccessoryType_BaseEnd.Text.ToString.IndexOf("Set Screw") <> -1 OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbAccessoryType_RodEnd.Text.ToString.IndexOf("Set Screw") <> -1 Then
            '' ''    oToolList.Add("SST-03")
            '' ''End If
            ' '' ''07_10_2010    RAGAVA
            'TILL    HERE

            '24_12_2010   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked = True Then
                oToolList.Add("WI10-E-48")
                oToolList.Add("CYLINDER STYLE 4")
                oToolList.Add("REPHASING FLOW HIGH")
                oToolList.Add("CYL TEST PRESSURE 2")
            Else
                oToolList.Add("WI10-E-48")
                oToolList.Add("CYLINDER STYLE 1")
                oToolList.Add("CYL TEST PRESSURE 2")
            End If
            'oToolList.Add("WI10-E-48")
            'oToolList.Add("CYLINDER STYLE 1")
            'oToolList.Add("CYL TEST PRESSURE 2")
            'Till   Here
            Dim nCount As Int16
            For i As Integer = 0 To SequenceCount.Count - 1
                nCount = nCount + SequenceCount(i)
            Next
            SequenceCount.Add(oToolList.Count - nCount)
            'Till    Here
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GetTools_Cylinder()
        Try
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objApp = Nothing
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.checkExcelInstance()
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objBook = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objApp.Workbooks.Open(System.Environment.CurrentDirectory & "\CMS_Tooling_WeldedAssembly.xls")
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objBook.Worksheets("Lookup")

            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("B1")
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("B2")

            Dim dblpinHoleSize, dblpinHoleSize_Rod As Double
            If (Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize) Mod 0.125) <> 0 Then
                dblpinHoleSize = Math.Round(Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize) / 0.125)
                dblpinHoleSize = dblpinHoleSize * 0.125
            End If
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value = dblpinHoleSize
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("B3")
            If (Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd) Mod 0.125) <> 0 Then
                dblpinHoleSize_Rod = Math.Round(Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd) / 0.125)
                dblpinHoleSize_Rod = dblpinHoleSize_Rod * 0.125
            End If
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value = dblpinHoleSize_Rod
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("B4")
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value = ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign._strCH_CylinderHeadCode
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("B5")
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInDecimals
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("B6")
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("B7")
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("B8")
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value = "n"      'PTFE piston seal... always new seal is used..!
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("B9")
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Threaded" Then
                ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value = "y"
            Else
                ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value = "n"
            End If
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("B10")
            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.cmbHeadType.Text) = "WIRERING" Then
                ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value = "y"
            Else
                ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value = "n"
            End If
            ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objBook.Save()
            For i As Int16 = 11 To 24     '01_11_2010   RAGAVA   '24
                '30_12_2011   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strWC_619_622 = "WC622" Then
                    If i = 13 OrElse i = 15 OrElse i = 16 OrElse i = 17 OrElse i = 18 OrElse i = 19 Then
                        Continue For
                    End If
                End If
                If i = 19 AndAlso UCase(ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.cmbHeadType.Text) = "WIRERING" Then
                    Dim strTool As String = String.Empty
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter >= 0.5 AndAlso _
                 ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter <= 2.5 AndAlso _
                 ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodLength <= 44 AndAlso _
                 ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodLength >= 10.75 _
                 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalTubeLength >= 14.06 _
                 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalTubeLength <= 54 AndAlso _
                  ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 1.5 AndAlso _
                     ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 3.0 AndAlso _
                 ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength >= 8 Then
                        strTool = ""
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 1.5 Then
                            strTool = "501142"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 1.75 Then
                            strTool = "501143"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2 Then
                            strTool = "501144"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2.25 Then
                            strTool = "501145"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2.5 Then
                            strTool = "501146"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2.75 Then
                            strTool = "501147"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 3 Then
                            strTool = "501148"
                        End If
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
                        strTool = ""
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 1.25 Then
                            strTool = "501222"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 1.5 Then
                            strTool = "501223"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 1.75 Then
                            strTool = "501224"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2 Then
                            strTool = "501225"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2.25 Then
                            strTool = "501226"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2.5 Then
                            strTool = "501227"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2.75 Then
                            strTool = "501228"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 3 Then
                            strTool = "501229"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 3.25 Then
                            strTool = "501230"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 3.5 Then
                            strTool = "501231"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 3.75 Then
                            strTool = "501232"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 4 Then
                            strTool = "501233"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 4.25 Then
                            strTool = "501234"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 4.5 Then
                            strTool = "501235"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 4.75 Then
                            strTool = "501236"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 5 Then
                            strTool = "501237"
                        End If
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional" Then
                        strTool = ""
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 1.25 Then
                            strTool = "500798"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 1.5 Then
                            strTool = "500723"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 1.75 Then
                            strTool = "500724"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2 Then
                            strTool = "500725"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2.25 Then
                            strTool = "500726"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2.5 Then
                            strTool = "500727"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 2.75 Then
                            strTool = "500728"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 3 Then
                            strTool = "500729"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 3.25 Then
                            strTool = "500874"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 3.5 Then
                            strTool = "500875"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 3.75 Then
                            strTool = "500876"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 4 Then
                            strTool = "500877"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 4.25 Then
                            strTool = "500878"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 4.5 Then
                            strTool = "500879"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 4.75 Then
                            strTool = "500880"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 5 Then
                            strTool = "500881"
                        End If
                    End If
                    If strTool <> "" Then
                        ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("B" & i.ToString)
                        oToolList.Add(strTool)
                        Continue For
                    End If
                End If
                'Till   Here
                ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange = ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objSheet.Range("B" & i.ToString)
                If Trim(ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value) <> "" AndAlso ((ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value).ToString <> "0") AndAlso (ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value).ToString.StartsWith("-") = False Then 'AndAlso (ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value).ToString.IndexOf("#N/A") <> -1 Then          '14_10_2010  RAGAVA   '-' condition added
                    oToolList.Add(ObjClsWeldedCylinderFunctionalClass._oClsExcelClass.objrange.Value)
                End If
            Next
            SequenceCount.Add(oToolList.Count)   '07_10_2010   RAGAVA
        Catch ex As Exception

        End Try
    End Sub

    Private Function DoEachRowProcess(ByVal intSequence As Integer, ByVal oItem As String, ByVal icount As Integer)
        Dim oMthl As New CMS_MTHL()
        oMthl.PartNumbers = _partNumber
        oMthl.ToolNumbers = oItem
        oMthl.LineNumbers = icount + 1      '07_10_2010  RAGAVA  +1
        oMthl.Sequence = intSequence
        Return oMthl.ToString()
    End Function

    Public Overrides ReadOnly Property FileName() As String
        Get
            Return "MTHL" & _partNumber
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return "MTHL Lug Process"
    End Function

End Class
