Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.Data
Imports System.IO

'08_10_2010   RAGAVA
Public Class clsMETHE_Process
    Dim oExApp As New Excel.Application
    Dim oExlWrkBk As Excel.Workbook
    Dim oExlWrkSht As Excel.Worksheet
    Dim oRng As Excel.Range
    Dim strQuery As String = String.Empty
    Dim objDT As System.Data.DataTable
    Dim strPortBase As String = String.Empty     '20_12_2011  RAGAVA
    'Public Sub METHE_WeldedCylinder_Functionality()
    Public Sub METHE_WeldedCylinder_Functionality(ByVal strFolderPath As String)          '27_06_2011  RAGAVA
        Try
            Dim _blnIsNewTube As Boolean = ObjClsWeldedCylinderFunctionalClass._blnIsNewTube      '09_10_2010   RAGAVA
            Dim _blnIsNewRod As Boolean = ObjClsWeldedCylinderFunctionalClass._blnIsNewRod        '09_10_2010   RAGAVA
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT").ToString.StartsWith("7") Then
            '    _blnIsNewTube = True
            'End If
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT").ToString.StartsWith("7") Then
            '    _blnIsNewRod = True
            'End If
CHECK_CMS:
            If File.Exists("C:\CMS.xls") = False Then
                MsgBox("Create Excel File C:\CMS.xls" & vbNewLine & "then click ok")
                GoTo CHECK_CMS
            End If

            '20_12_2011  RAGAVA
            Try
                Dim strQuery As String = String.Empty
                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPortCode) <> "" Then
                    strQuery = "select * from Welded.PortsAndWPDSDetails where PortCode = '" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPortCode & "'"
                Else
                    strQuery = "select * from Welded.PortsAndWPDSDetails where PortType = '" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd & "' and PortOrientation = '" & Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleBaseEnd.Text) & "' and port_size = '" & Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text) & "'"
                End If
                Dim dr_Base As DataRow = MonarchConnectionObject.GetDataRow(strQuery)
                strPortBase = dr_Base("PORT_BASE")
            Catch ex As Exception
            End Try
            'Till  Here


            'TUBE FILE GENERATION
            If _blnIsNewTube OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_TubeWeldment Then 'anup 10-03-2011
                Try
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "01" Then
                        GetSheet1_Tools(strQuery)
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "02" Then
                        GetSheet2_Tools(strQuery)
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "03" Then
                        GetSheet3_Tools(strQuery)
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "04" Then
                        GetSheet4_Tools(strQuery)
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "05" Then
                        GetSheet5_Tools(strQuery)
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "06" Then
                        GetSheet6_Tools(strQuery)
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "07" Then
                        GetSheet7_Tools(strQuery)
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "08" Then
                        GetSheet8_Tools(strQuery)
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "09" Then
                        GetSheet9_Tools(strQuery)
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "10" Then
                        GetSheet10_Tools(strQuery)
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "11" Then
                        GetSheet11_Tools(strQuery)
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "12" Then
                        GetSheet12_Tools(strQuery)



                        '29_02_2012   RAGAVA
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "13" Then
                        GetSheet13_Tools(strQuery)
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "14" Then
                        GetSheet14_Tools(strQuery)
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "15" Then
                        GetSheet15_Tools(strQuery)
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "16" Then
                        GetSheet16_Tools(strQuery)
                    End If
                    objDT = MonarchConnectionObject.GetTable(strQuery)
                    Dim strfile As String = "C:\CMS.xls"
                    oExlWrkBk = Nothing        '14_10_2010   RAGAVA
                    oExlWrkBk = oExApp.Workbooks.Open(strfile)
                    oExlWrkBk.EnableAutoRecover = False 'anup 16-03-2011
                    oExlWrkSht = oExlWrkBk.Worksheets("Sheet1")
                    Dim icount As Integer = 1


                    Dim seqCount As Integer = 1        '11_10_2010    RAGAVA
                    For Each dr As DataRow In objDT.Rows
                        oRng = oExlWrkSht.Range("A" & icount.ToString)
                        oRng.Value2 = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT").ToString
                        oRng = oExlWrkSht.Range("B" & icount.ToString)


                        '11_10_2010    RAGAVA
                        oRng.Value2 = "'" & Format(seqCount, "00").ToString
                        If icount Mod 15 = 0 Then
                            seqCount = seqCount + 1
                        End If
                        'Till   Here

                        oRng = oExlWrkSht.Range("C" & icount.ToString)
                        oRng.Value2 = "'" & Format(Val(dr(2)), "00").ToString
                        oRng = oExlWrkSht.Range("D" & icount.ToString)
                        oRng.Value2 = dr(3).ToString.Replace("'", "")
                        icount = icount + 1




                    Next
                    'oExlWrkBk.SaveAs("W:\WELDED\CMS\" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString + "_CMS" & "\" & "METHDE" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT").ToString & ".csv", XlFileFormat.xlCSVMSDOS)
                    oExlWrkBk.SaveAs(strFolderPath & "\" & "METHDE" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT").ToString & ".csv", XlFileFormat.xlCSVMSDOS)
                    oExlWrkBk = Nothing      '12_10_2010   RAGAVA
                    objDT.Clear()
                    KillExcel()
                    'anup 28-02-2011 start
                    CVSFileUtil.DoesFileContainDoubleQuotation(strFolderPath & "\" & "METHDE" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT").ToString & ".csv")
                    'anup 28-02-2011 till here
                Catch ex As Exception
                    oExlWrkBk = Nothing      '12_10_2010   RAGAVA
                    KillExcel()
                    'MsgBox("Error in METHDE TUBE")
                End Try
            End If


            'ROD FILE GENERATION
            If _blnIsNewRod OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_RodWeldment Then 'anup 10-03-2011
                strQuery = ""
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RulesID_Rod = 1001 Then
                    GetRodTools_Sheet1(strQuery)
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RulesID_Rod = 1002 Then
                    GetRodTools_Sheet2(strQuery)
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RulesID_Rod = 1003 Then
                    GetRodTools_Sheet3(strQuery)
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RulesID_Rod = 1004 Then
                    GetRodTools_Sheet4(strQuery)
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RulesID_Rod = 1005 Then
                    GetRodTools_Sheet5(strQuery)
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RulesID_Rod = 1006 Then
                    GetRodTools_Sheet6(strQuery)
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RulesID_Rod = 1007 Then
                    GetRodTools_Sheet7(strQuery)
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RulesID_Rod = 1008 Then
                    GetRodTools_Sheet8(strQuery)
                End If
                objDT = MonarchConnectionObject.GetTable(strQuery)
                Dim strfile As String = "C:\CMS.xls"
                'oExlWrkBk = Nothing        '14_10_2010   RAGAVA
                oExApp = New Excel.Application         '14_10_2010   RAGAVA
                oExlWrkBk = oExApp.Workbooks.Open(strfile)
                oExlWrkBk.EnableAutoRecover = False 'anup 16-03-2011
                oExlWrkSht = oExlWrkBk.Worksheets("Sheet1")
                Dim icount As Integer = 1

                Dim seqCount As Integer = 1        '11_10_2010    RAGAVA
                For Each dr As DataRow In objDT.Rows
                    oRng = oExlWrkSht.Range("A" & icount.ToString)
                    oRng.Value2 = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT").ToString
                    oRng = oExlWrkSht.Range("B" & icount.ToString)

                    '11_10_2010    RAGAVA
                    oRng.Value2 = "'" & Format(seqCount, "00").ToString
                    If icount Mod 15 = 0 Then
                        seqCount = seqCount + 1
                    End If
                    'If objDT.Rows.Count = 30 Then
                    '    oRng.Value2 = "'" & Format((Val(dr(1)) - 1), "00").ToString
                    'Else
                    '    oRng.Value2 = "'" & Format(Val(dr(1)), "00").ToString
                    'End If
                    'Till   Here

                    oRng = oExlWrkSht.Range("C" & icount.ToString)
                    oRng.Value2 = "'" & Format(Val(dr(2)), "00").ToString
                    oRng = oExlWrkSht.Range("D" & icount.ToString)
                    oRng.Value2 = dr(3).ToString.Replace("'", "")
                    icount = icount + 1
                Next
                oExlWrkBk.SaveAs(strFolderPath & "\" & "METHDE" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT").ToString & ".csv", XlFileFormat.xlCSVMSDOS)
                objDT.Clear()
                oExlWrkBk = Nothing      '12_10_2010   RAGAVA
                'anup 28-02-2011 start
                KillExcel()
                CVSFileUtil.DoesFileContainDoubleQuotation(strFolderPath & "\" & "METHDE" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT").ToString & ".csv")
                'anup 28-02-2011 till here
            End If
        Catch ex As Exception
            oExlWrkBk = Nothing
            'MsgBox("Error in METHDE ROD")
        End Try
        '18_10_2010   RAGAVA
        Try
            '08_12_2011   RAGAVA   COMMENTED
            'METHDE_BASEEND_LUG(strFolderPath)
            'METHDE_RODEND_LUG(strFolderPath)
            KillExcel()       '22_12_2010   RAGAVA
        Catch ex As Exception

        End Try
    End Sub

    '14_10_2010   RAGAVA         killing excel
    Private Sub KillExcel()
        Try
            For Each oProcess As Process In Process.GetProcessesByName("Excel")
                oProcess.Kill()
                GC.Collect()
                System.Threading.Thread.Sleep(1000)
            Next
        Catch ex As Exception
        End Try
    End Sub

#Region "Lug METHDE"
    Private Sub METHDE_BASEEND_LUG(ByVal strFolderPath As String)
        Try
            If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2 = "Fabricated") AndAlso _
                   (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug") Then

                Dim strFabricationCode As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart)       '19_07_2012   RAGAVA
                If (Trim(strFabricationCode) <> "" AndAlso Val(strFabricationCode) >= Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart)) OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Lug_BE Then   '19_07_2012   RAGAVA
                    'If (Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd) <> "" AndAlso Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd) >= Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart)) OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Lug_BE Then
                    KillExcel()
                    oExlWrkBk = Nothing
                    strQuery = "Select * from METHDE_LUG_10"
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" Then
                        strQuery = strQuery & " Union Select * from METHDE_LUG_20"
                    End If
                    objDT = MonarchConnectionObject.GetTable(strQuery)
                    Dim strfile As String = "C:\CMS.xls"
                    oExApp = New Excel.Application
                    oExlWrkBk = oExApp.Workbooks.Open(strfile)
                    oExlWrkBk.EnableAutoRecover = False 'anup 16-03-2011
                    oExlWrkSht = oExlWrkBk.Worksheets("Sheet1")
                    Dim icount As Integer = 1
                    Dim seqCount As Integer = 1        '11_10_2010    RAGAVA
                    For Each dr As DataRow In objDT.Rows
                        oRng = oExlWrkSht.Range("A" & icount.ToString)
                        'oRng.Value2 = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd
                        oRng.Value2 = strFabricationCode     '19_07_2012   RAGAVA
                        oRng = oExlWrkSht.Range("B" & icount.ToString)
                        '11_10_2010    RAGAVA
                        oRng.Value2 = "'" & Format(seqCount, "00").ToString
                        If icount Mod 15 = 0 Then
                            seqCount = seqCount + 1
                        End If
                        oRng = oExlWrkSht.Range("C" & icount.ToString)
                        oRng.Value2 = "'" & Format(Val(dr(2)), "00").ToString
                        oRng = oExlWrkSht.Range("D" & icount.ToString)
                        oRng.Value2 = dr(3).ToString.Replace("'", "")
                        icount = icount + 1
                    Next
                    'oExlWrkBk.SaveAs(strFolderPath & "\" & "METHDE" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd.ToString & ".csv", XlFileFormat.xlCSVMSDOS)
                    oExlWrkBk.SaveAs(strFolderPath & "\" & "METHDE" & strFabricationCode & ".csv", XlFileFormat.xlCSVMSDOS)    '19_07_2012   RAGAVA
                    objDT.Clear()
                    oExlWrkBk = Nothing
                End If
            End If
        Catch ex As Exception
            'MsgBox("Error in generating METHDE BASE LUG")
        End Try
    End Sub

    Private Sub METHDE_RODEND_LUG(ByVal strFolderPath As String)
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Fabricated" AndAlso _
                   (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug") Then
                If (Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd) <> "" AndAlso Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd) >= Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart)) OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Lug_RE Then
                    KillExcel()
                    oExlWrkBk = Nothing
                    strQuery = "Select * from METHDE_LUG_10"
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" Then
                        strQuery = strQuery & " Union Select * from METHDE_LUG_20"
                    End If
                    objDT = MonarchConnectionObject.GetTable(strQuery)
                    Dim strfile As String = "C:\CMS.xls"
                    oExApp = New Excel.Application
                    oExlWrkBk = oExApp.Workbooks.Open(strfile)
                    oExlWrkBk.EnableAutoRecover = False 'anup 16-03-2011
                    oExlWrkSht = oExlWrkBk.Worksheets("Sheet1")
                    Dim icount As Integer = 1
                    Dim seqCount As Integer = 1        '11_10_2010    RAGAVA
                    For Each dr As DataRow In objDT.Rows
                        oRng = oExlWrkSht.Range("A" & icount.ToString)
                        oRng.Value2 = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd
                        oRng = oExlWrkSht.Range("B" & icount.ToString)
                        '11_10_2010    RAGAVA
                        oRng.Value2 = "'" & Format(seqCount, "00").ToString
                        If icount Mod 15 = 0 Then
                            seqCount = seqCount + 1
                        End If
                        oRng = oExlWrkSht.Range("C" & icount.ToString)
                        oRng.Value2 = "'" & Format(Val(dr(2)), "00").ToString
                        oRng = oExlWrkSht.Range("D" & icount.ToString)
                        oRng.Value2 = dr(3).ToString.Replace("'", "")
                        icount = icount + 1
                    Next
                    oExlWrkBk.SaveAs(strFolderPath & "\" & "METHDE" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd.ToString & ".csv", XlFileFormat.xlCSVMSDOS)
                    objDT.Clear()
                    oExlWrkBk = Nothing
                End If
            End If
        Catch ex As Exception
            'MsgBox("Error in generating METHDE ROD LUG")
        End Try
    End Sub
#End Region

#Region "Rod Sheet Logics"
    Private Sub GetRodTools_Sheet1(ByRef strQuery As String)
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial.ToUpper = "CHROME" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial.ToUpper = "LION 1000" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "Chamfer" Then
                    strQuery = "select * from ROD_OP_010_1 union select * from ROD_OP_020_1_1"
                Else
                    strQuery = "select * from ROD_OP_010_1 union select * from ROD_OP_020_1_2"
                End If
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial.ToUpper.IndexOf("NITRO") <> -1 Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "Chamfer" Then
                    strQuery = "select * from ROD_OP_010_2 union select * from ROD_OP_020_3_1"
                Else
                    strQuery = "select * from ROD_OP_010_2 union select * from ROD_OP_020_3_2"
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetRodTools_Sheet2(ByRef strQuery As String)
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial.ToUpper = "CHROME" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial.ToUpper = "LION 1000" Then
                If ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual" Then
                    'OP(10 - 1)
                    'OP(20 - 2)
                    'OP(40 - 1)
                    'OP(41 - 1)
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "Chamfer" Then
                        strQuery = "select * from ROD_OP_010_1 union select * from ROD_OP_020_2_1 union select * from ROD_OP_040_1 union select * from ROD_OP_041_1"
                    Else
                        strQuery = "select * from ROD_OP_010_1 union select * from ROD_OP_020_2_2 union select * from ROD_OP_040_1 union select * from ROD_OP_041_1"
                    End If
                Else
                    'OP(10 - 1)
                    'OP(20 - 2)
                    'OP(30 - 1)
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "Chamfer" Then
                        strQuery = "select * from ROD_OP_010_1 union select * from ROD_OP_020_2_1 union select * from ROD_OP_030_1"
                    Else
                        strQuery = "select * from ROD_OP_010_1 union select * from ROD_OP_020_2_2 union select * from ROD_OP_030_1"
                    End If
                End If
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial.ToUpper.IndexOf("NITRO") <> -1 Then
                If ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual" Then
                    'OP(10 - 2)
                    'OP(20 - 4)
                    'OP(40 - 1)
                    'OP(41 - 1)
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "Chamfer" Then
                        strQuery = "select * from ROD_OP_010_2 union select * from ROD_OP_020_4_1 union select * from ROD_OP_040_1 union select * from ROD_OP_041_1"
                    Else
                        strQuery = "select * from ROD_OP_010_2 union select * from ROD_OP_020_4_2 union select * from ROD_OP_040_1 union select * from ROD_OP_041_1"
                    End If
                Else
                    'OP(10 - 2)
                    'OP(20 - 4)
                    'OP(30 - 1)
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "Chamfer" Then
                        strQuery = "select * from ROD_OP_010_2 union select * from ROD_OP_020_4_1 union select * from ROD_OP_030_1"
                    Else
                        strQuery = "select * from ROD_OP_010_2 union select * from ROD_OP_020_4_2 union select * from ROD_OP_030_1"
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetRodTools_Sheet3(ByRef strQuery As String)
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial.ToUpper = "CHROME" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial.ToUpper = "LION 1000" Then
                'OP(10 - 1)
                'OP(20 - 2)
                'OP(50 - 2)
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "Chamfer" Then
                    strQuery = "select * from ROD_OP_010_1 union select * from ROD_OP_020_2_1 union select * from ROD_OP_050_2"
                Else
                    strQuery = "select * from ROD_OP_010_1 union select * from ROD_OP_020_2_2 union select * from ROD_OP_050_2"
                End If
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial.ToUpper.IndexOf("NITRO") <> -1 Then
                'OP(10 - 2)
                'OP(20 - 4)
                'OP(50 - 2)
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "Chamfer" Then
                    strQuery = "select * from ROD_OP_010_1 union select * from ROD_OP_020_4_1 union select * from ROD_OP_050_2"
                Else
                    strQuery = "select * from ROD_OP_010_1 union select * from ROD_OP_020_4_2 union select * from ROD_OP_050_2"
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetRodTools_Sheet4(ByRef strQuery As String)
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial.ToUpper = "CHROME" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial.ToUpper = "LION 1000" Then
                If ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual" Then
                    'OP(10 - 1)
                    'OP(20 - 2)
                    'OP(40 - 1)
                    'OP(41 - 1)
                    'OP(50 - 1)

                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "Chamfer" Then
                        strQuery = "select * from ROD_OP_010_1 union select * from ROD_OP_020_2_1 union select * from ROD_OP_040_1 union select * from ROD_OP_041_1 union select * from ROD_OP_050_1"
                    Else
                        strQuery = "select * from ROD_OP_010_1 union select * from ROD_OP_020_2_2 union select * from ROD_OP_040_1 union select * from ROD_OP_041_1 union select * from ROD_OP_050_1"
                    End If
                Else
                    'OP(10 - 1)
                    'OP(20 - 2)
                    'OP(30 - 1)
                    'OP(50 - 2)

                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "Chamfer" Then
                        strQuery = "select * from ROD_OP_010_1 union select * from ROD_OP_020_2_1 union select * from ROD_OP_030_1 union select * from ROD_OP_050_2"
                    Else
                        strQuery = "select * from ROD_OP_010_1 union select * from ROD_OP_020_2_2 union select * from ROD_OP_030_1 union select * from ROD_OP_050_2"
                    End If
                End If
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial.ToUpper.IndexOf("NITRO") <> -1 Then
                If ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual" Then
                    'OP(10 - 2)
                    'OP(20 - 4)
                    'OP(40 - 1)
                    'OP(41 - 1)
                    'OP(50 - 1)

                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "Chamfer" Then
                        strQuery = "select * from ROD_OP_010_2 union select * from ROD_OP_020_4_1 union select * from ROD_OP_040_1 union select * from ROD_OP_041_1 union select * from ROD_OP_050_1"
                    Else
                        strQuery = "select * from ROD_OP_010_2 union select * from ROD_OP_020_4_2 union select * from ROD_OP_040_1 union select * from ROD_OP_041_1 union select * from ROD_OP_050_1"
                    End If
                Else
                    'OP(10 - 2)
                    'OP(20 - 4)
                    'OP(30 - 1)
                    'OP(50 - 2)

                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "Chamfer" Then
                        strQuery = "select * from ROD_OP_010_2 union select * from ROD_OP_020_4_1 union select * from ROD_OP_030_1 union select * from ROD_OP_050_2"
                    Else
                        strQuery = "select * from ROD_OP_010_2 union select * from ROD_OP_020_4_2 union select * from ROD_OP_030_1 union select * from ROD_OP_050_2"
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetRodTools_Sheet5(ByRef strQuery As String)
        Try
            'OP 020-1
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "Chamfer" Then
                strQuery = "select * from ROD_OP_020_1_1"
            Else
                strQuery = "select * from ROD_OP_020_1_2"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetRodTools_Sheet6(ByRef strQuery As String)
        Try
            If ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual" Then
                'OP(20 - 2)
                'OP(40 - 1)
                'OP(41 - 1)
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "Chamfer" Then
                    strQuery = "select * from ROD_OP_020_2_1 union select * from ROD_OP_040_1 union select * from ROD_OP_041_1"
                Else
                    strQuery = "select * from ROD_OP_020_2_2 union select * from ROD_OP_040_1 union select * from ROD_OP_041_1"
                End If
            Else
                'OP(20 - 2)
                'OP(30 - 1)
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "Chamfer" Then
                    strQuery = "select * from ROD_OP_020_2_1 union select * from ROD_OP_030_1"
                Else
                    strQuery = "select * from ROD_OP_020_2_2 union select * from ROD_OP_030_1"
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetRodTools_Sheet7(ByRef strQuery As String)
        Try
            'OP(20 - 2)
            'OP(50 - 2)
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "Chamfer" Then
                strQuery = "select * from ROD_OP_020_2_1 union select * from ROD_OP_050_2"
            Else
                strQuery = "select * from ROD_OP_020_2_2 union select * from ROD_OP_050_2"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetRodTools_Sheet8(ByRef strQuery As String)
        Try
            If ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual" Then
                'OP(20 - 2)
                'OP(40 - 1)
                'OP(41 - 1)
                'OP(50 - 1)
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "Chamfer" Then
                    strQuery = "select * from ROD_OP_020_2_1 union select * from ROD_OP_040_1 union select * from ROD_OP_041_1 union select * from ROD_OP_050_1"
                Else
                    strQuery = "select * from ROD_OP_020_2_2 union select * from ROD_OP_040_1 union select * from ROD_OP_041_1 union select * from ROD_OP_050_1"
                End If
            Else
                'OP(20 - 2)
                'OP(30 - 1)
                'OP(50 - 2)
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "Chamfer" Then
                    strQuery = "select * from ROD_OP_020_2_1 union select * from ROD_OP_030_1 union select * from ROD_OP_050_2"
                Else
                    strQuery = "select * from ROD_OP_020_2_2 union select * from ROD_OP_030_1 union select * from ROD_OP_050_2"
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "Tube Sheet Logics"
    Private Sub GetSheet1_Tools(ByRef strQuery As String)
        Try
            '10_1
            '20_1
            '30_1
            'If ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port Integral" Then
            '    strQuery = "select * from TUBE_OP_010_1 union select * from TUBE_OP_020_1_1 union select * from TUBE_OP_030_1_1"
            'Else
            '    strQuery = "select * from TUBE_OP_010_1 union select * from TUBE_OP_020_1_2 union select * from TUBE_OP_030_1_2"
            'End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional" Then     '19_01_2012   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port Integral" Then 'OrElse (strPortBase = "RADIUS" AndAlso ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port In Tube") Then       '20_12_2011  RAGAVA
                    strQuery = "select * from TUBE_OP_010_1 union select * from TUBE_OP_020_1_1 union select * from TUBE_OP_030_1_1"
                Else
                    strQuery = "select * from TUBE_OP_010_1 union select * from TUBE_OP_020_1_2 union select * from TUBE_OP_030_1_2"
                End If
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strRodEndPortLocatorCode_Purchase <> ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strBaseEndPortLocatorCode_Purchase Then        '07_10_2010    RAGAVA
                '31_1
                strQuery = strQuery & " Union Select * from TUBE_OP_031_1"
            End If
            If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleBaseEnd.Text) = "Straight" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text) = "Straight" AndAlso (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationBaseEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text) Then
                '40_1
                strQuery = strQuery & " Union Select * from TUBE_OP_040_1"
            Else
                '40_2
                strQuery = strQuery & " Union Select * from TUBE_OP_040_2"
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_BaseEnd >= 0.125 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_RodEnd >= 0.125 Then
                '50-1 
                strQuery = strQuery & " Union Select * from TUBE_OP_050_1"
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_BaseEnd <= 0.125 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_RodEnd <= 0.125 Then
                '50-2
                strQuery = strQuery & " Union Select * from TUBE_OP_050_2"
            Else
                '50-3
                strQuery = strQuery & " Union Select * from TUBE_OP_050_3"
            End If
            '60_1
            strQuery = strQuery & " Union Select * from TUBE_OP_060_1"
            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize" Then
                '70_1
                strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetSheet2_Tools(ByRef strQuery As String)
        Try
            '10_1
            '20_1
            '30_1
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional" Then       '19_01_2012   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port Integral" Then 'OrElse (strPortBase = "RADIUS" AndAlso ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port In Tube") Then       '20_12_2011  RAGAVA
                    strQuery = "select * from TUBE_OP_010_1 union select * from TUBE_OP_020_1_1 union select * from TUBE_OP_030_1_1"
                Else
                    strQuery = "select * from TUBE_OP_010_1 union select * from TUBE_OP_020_1_2 union select * from TUBE_OP_030_1_2"
                End If
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strRodEndPortLocatorCode_Purchase <> ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strBaseEndPortLocatorCode_Purchase Then        '07_10_2010    RAGAVA
                '31_1
                strQuery = strQuery & " Union Select * from TUBE_OP_031_1"
            End If
            If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleBaseEnd.Text) = "Straight" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text) = "Straight" AndAlso (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationBaseEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text) Then
                '40_1
                strQuery = strQuery & " Union Select * from TUBE_OP_040_1"
            Else
                '40_2
                strQuery = strQuery & " Union Select * from TUBE_OP_040_2"
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_BaseEnd >= 0.125 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_RodEnd >= 0.125 Then
                '50-1 
                strQuery = strQuery & " Union Select * from TUBE_OP_050_1"
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_BaseEnd <= 0.125 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_RodEnd <= 0.125 Then
                '50-2
                strQuery = strQuery & " Union Select * from TUBE_OP_050_2"
            Else
                '50-3
                strQuery = strQuery & " Union Select * from TUBE_OP_050_3"
            End If
            '61-1
            'If ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port Integral" Then   
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then    '20_12_2011  RAGAVA
            '    strQuery = strQuery & " Union Select * from TUBE_OP_061_1_1"

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso (ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "SINGLE LUG" OrElse ObjClsWeldedCylinderFunctionalClass.FacricatedPart2 = "SINGLE LUG") Then  '15_05_2012   RAGAVA Then
                strQuery = strQuery & " Union Select * from TUBE_OP_061_1_2"
            Else
                strQuery = strQuery & " Union Select * from TUBE_OP_061_1_1"
            End If

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso (ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "SINGLE LUG" OrElse ObjClsWeldedCylinderFunctionalClass.FacricatedPart2 = "SINGLE LUG") Then  '15_05_2012   RAGAVA Then
                '62-1
                strQuery = strQuery & " Union Select * from TUBE_OP_062_1"
            End If

            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize" Then
                '70-3
                strQuery = strQuery & " Union Select * from TUBE_OP_070_3"
            Else
                '70-1
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" _
                AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                    strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" _
                AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                    strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" _
                AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso _
                (Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbPinHoleSizeType.Text) = "Custom" OrElse _
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity > 0) Then
                    strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetSheet3_Tools(ByRef strQuery As String)
        Try
            '11_1
            '20_1
            '30_1
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional" Then       '19_01_2012   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port Integral" Then 'OrElse (strPortBase = "RADIUS" AndAlso ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port In Tube") Then       '20_12_2011  RAGAVA
                    strQuery = "select * from TUBE_OP_011_1 union select * from TUBE_OP_020_1_1 union select * from TUBE_OP_030_1_1"
                Else
                    strQuery = "select * from TUBE_OP_011_1 union select * from TUBE_OP_020_1_2 union select * from TUBE_OP_030_1_2"
                End If
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strRodEndPortLocatorCode_Purchase <> ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strBaseEndPortLocatorCode_Purchase Then        '07_10_2010    RAGAVA
                '31_1
                strQuery = strQuery & " Union Select * from TUBE_OP_031_1"
            End If
            If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleBaseEnd.Text) = "Straight" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text) = "Straight" AndAlso (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationBaseEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text) Then
                '40_1
                strQuery = strQuery & " Union Select * from TUBE_OP_040_1"
            Else
                '40_2
                strQuery = strQuery & " Union Select * from TUBE_OP_040_2"
            End If
            '60-1
            strQuery = strQuery & " Union Select * from TUBE_OP_060_1"
            '70-3
            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize" Then
                strQuery = strQuery & " Union Select * from TUBE_OP_070_3"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetSheet4_Tools(ByRef strQuery As String)
        Try
            '11_1
            '20_1
            '30_1
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional" Then       '19_01_2012   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port Integral" Then 'OrElse (strPortBase = "RADIUS" AndAlso ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port In Tube") Then       '20_12_2011  RAGAVA
                    strQuery = "select * from TUBE_OP_011_1 union select * from TUBE_OP_020_1_1 union select * from TUBE_OP_030_1_1"
                Else
                    strQuery = "select * from TUBE_OP_011_1 union select * from TUBE_OP_020_1_2 union select * from TUBE_OP_030_1_2"
                End If
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strRodEndPortLocatorCode_Purchase <> ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strBaseEndPortLocatorCode_Purchase Then        '07_10_2010    RAGAVA
                '31_1
                strQuery = strQuery & " Union Select * from TUBE_OP_031_1"
            End If
            If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleBaseEnd.Text) = "Straight" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text) = "Straight" AndAlso (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationBaseEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text) Then
                '40_1
                strQuery = strQuery & " Union Select * from TUBE_OP_040_1"
            Else
                '40_2
                strQuery = strQuery & " Union Select * from TUBE_OP_040_2"
            End If
            '061-1
            'If ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port Integral" Then
            '    strQuery = strQuery & " Union Select * from TUBE_OP_061_1_1"
            'Else
            '    strQuery = strQuery & " Union Select * from TUBE_OP_061_1_2"
            'End If
            '19_01_2012   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso (ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "SINGLE LUG" OrElse ObjClsWeldedCylinderFunctionalClass.FacricatedPart2 = "SINGLE LUG") Then  '15_05_2012   RAGAVA Then
                strQuery = strQuery & " Union Select * from TUBE_OP_061_1_2"
            Else
                strQuery = strQuery & " Union Select * from TUBE_OP_061_1_1"
            End If
            '16_12_2011   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso (ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "SINGLE LUG" OrElse ObjClsWeldedCylinderFunctionalClass.FacricatedPart2 = "SINGLE LUG") Then  '15_05_2012   RAGAVA Then
                '62-1
                strQuery = strQuery & " Union Select * from TUBE_OP_062_1"
            End If
            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize" Then
                '70-3
                strQuery = strQuery & " Union Select * from TUBE_OP_070_3"
            Else
                '70-1
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" _
                AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                    strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" _
                AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                    strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" _
                AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso _
                (Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbPinHoleSizeType.Text) = "Custom" OrElse _
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity > 0) Then
                    strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetSheet5_Tools(ByRef strQuery As String)
        Try
            '10_1
            '20_1
            '30_1
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional" Then       '19_01_2012   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port Integral" Then 'OrElse (strPortBase = "RADIUS" AndAlso ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port In Tube") Then       '20_12_2011  RAGAVA
                    strQuery = "select * from TUBE_OP_010_1 union select * from TUBE_OP_020_1_1 union select * from TUBE_OP_030_1_1"
                Else
                    strQuery = "select * from TUBE_OP_010_1 union select * from TUBE_OP_020_1_2 union select * from TUBE_OP_030_1_2"
                End If
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strRodEndPortLocatorCode_Purchase <> ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strBaseEndPortLocatorCode_Purchase Then        '07_10_2010    RAGAVA
                '31_1
                strQuery = strQuery & " Union Select * from TUBE_OP_031_1"
            End If
            If (ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd.StartsWith("90") = True OrElse ObjClsWeldedCylinderFunctionalClass.strPortAngle_RodEnd.StartsWith("90") = True) OrElse Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleBaseEnd.Text) = "Straight" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text) = "Straight" AndAlso (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationBaseEnd.Text <> ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text) Then 'anup 01-03-2011 changed "<>" for "="
                '45-1
                strQuery = strQuery & " Union Select * from TUBE_OP_045_1"
            ElseIf (ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd.StartsWith("90") = True AndAlso ObjClsWeldedCylinderFunctionalClass.strPortAngle_RodEnd.StartsWith("90") = True) Then
                '45-2
                strQuery = strQuery & " Union Select * from TUBE_OP_045_2"
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_BaseEnd >= 0.125 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_RodEnd >= 0.125 Then
                '50-1 
                strQuery = strQuery & " Union Select * from TUBE_OP_050_1"
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_BaseEnd <= 0.125 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_RodEnd <= 0.125 Then
                '50-2
                strQuery = strQuery & " Union Select * from TUBE_OP_050_2"
            Else
                '50-3
                strQuery = strQuery & " Union Select * from TUBE_OP_050_3"
            End If
            '55-1
            strQuery = strQuery & " Union Select * from TUBE_OP_055_1"
            '60-1
            strQuery = strQuery & " Union Select * from TUBE_OP_060_1"
            '70-3
            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize" Then
                strQuery = strQuery & " Union Select * from TUBE_OP_070_3"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetSheet6_Tools(ByRef strQuery As String)
        Try
            '10_1
            '20_1
            '30_1
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional" Then       '19_01_2012   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port Integral" Then 'OrElse (strPortBase = "RADIUS" AndAlso ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port In Tube") Then       '20_12_2011  RAGAVA
                    strQuery = "select * from TUBE_OP_010_1 union select * from TUBE_OP_020_1_1 union select * from TUBE_OP_030_1_1"
                Else
                    strQuery = "select * from TUBE_OP_010_1 union select * from TUBE_OP_020_1_2 union select * from TUBE_OP_030_1_2"
                End If
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strRodEndPortLocatorCode_Purchase <> ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strBaseEndPortLocatorCode_Purchase Then        '07_10_2010    RAGAVA
                '31_1
                strQuery = strQuery & " Union Select * from TUBE_OP_031_1"
            End If
            If (ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd.StartsWith("90") = True OrElse ObjClsWeldedCylinderFunctionalClass.strPortAngle_RodEnd.StartsWith("90") = True) OrElse Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleBaseEnd.Text) = "Straight" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text) = "Straight" AndAlso (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationBaseEnd.Text <> ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text) Then 'AndAlso ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text <> "0") Then         '23_12_2010   RAGAVA   0 angle condition added    'anup 01-03-2011 changed "<>" for "=" 
                '45-1
                strQuery = strQuery & " Union Select * from TUBE_OP_045_1"
            ElseIf (ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd.StartsWith("90") = True AndAlso ObjClsWeldedCylinderFunctionalClass.strPortAngle_RodEnd.StartsWith("90") = True) Then
                '45-2
                strQuery = strQuery & " Union Select * from TUBE_OP_045_2"
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_BaseEnd >= 0.125 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_RodEnd >= 0.125 Then
                '50-1 
                strQuery = strQuery & " Union Select * from TUBE_OP_050_1"
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_BaseEnd <= 0.125 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_RodEnd <= 0.125 Then
                '50-2
                strQuery = strQuery & " Union Select * from TUBE_OP_050_2"
            Else
                '50-3
                strQuery = strQuery & " Union Select * from TUBE_OP_050_3"
            End If
            '55-1
            strQuery = strQuery & " Union Select * from TUBE_OP_055_1"
            '61-1
            'If ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port Integral" Then
            '    strQuery = strQuery & " Union Select * from TUBE_OP_061_1_1"
            'Else
            '    strQuery = strQuery & " Union Select * from TUBE_OP_061_1_2"
            'End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso (ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "SINGLE LUG" OrElse ObjClsWeldedCylinderFunctionalClass.FacricatedPart2 = "SINGLE LUG") Then  '15_05_2012   RAGAVA Then
                strQuery = strQuery & " Union Select * from TUBE_OP_061_1_2"
            Else
                strQuery = strQuery & " Union Select * from TUBE_OP_061_1_1"
            End If
            '62-1
            '16_12_2011   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso (ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "SINGLE LUG" OrElse ObjClsWeldedCylinderFunctionalClass.FacricatedPart2 = "SINGLE LUG") Then  '15_05_2012   RAGAVA Then
                strQuery = strQuery & " Union Select * from TUBE_OP_062_1"
            End If
            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize" Then
                '70-3
                strQuery = strQuery & " Union Select * from TUBE_OP_070_3"
            Else
                '70-1
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" _
                AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                    strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" _
                AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                    strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" _
                AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso _
                (Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbPinHoleSizeType.Text) = "Custom" OrElse _
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity > 0) Then
                    strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetSheet7_Tools(ByRef strQuery As String)
        Try
            '11_1
            '20_1
            '30_1
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional" Then       '19_01_2012   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port Integral" Then 'OrElse (strPortBase = "RADIUS" AndAlso ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port In Tube") Then       '20_12_2011  RAGAVA
                    strQuery = "select * from TUBE_OP_011_1 union select * from TUBE_OP_020_1_1 union select * from TUBE_OP_030_1_1"
                Else
                    strQuery = "select * from TUBE_OP_011_1 union select * from TUBE_OP_020_1_2 union select * from TUBE_OP_030_1_2"
                End If
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strRodEndPortLocatorCode_Purchase <> ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strBaseEndPortLocatorCode_Purchase Then        '07_10_2010    RAGAVA
                '31_1
                strQuery = strQuery & " Union Select * from TUBE_OP_031_1"
            End If
            '55-1
            strQuery = strQuery & " Union Select * from TUBE_OP_055_1"
            '60-1
            strQuery = strQuery & " Union Select * from TUBE_OP_060_1"
            '70-3
            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize" Then
                strQuery = strQuery & " Union Select * from TUBE_OP_070_3"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetSheet8_Tools(ByRef strQuery As String)
        Try
            '11_1
            '20_1
            '30_1
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional" Then       '19_01_2012   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port Integral" Then 'OrElse (strPortBase = "RADIUS" AndAlso ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port In Tube") Then       '20_12_2011  RAGAVA
                    strQuery = "select * from TUBE_OP_011_1 union select * from TUBE_OP_020_1_1 union select * from TUBE_OP_030_1_1"
                Else
                    strQuery = "select * from TUBE_OP_011_1 union select * from TUBE_OP_020_1_2 union select * from TUBE_OP_030_1_2"
                End If
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strRodEndPortLocatorCode_Purchase <> ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strBaseEndPortLocatorCode_Purchase Then        '07_10_2010    RAGAVA
                '31_1
                strQuery = strQuery & " Union Select * from TUBE_OP_031_1"
            End If
            '55-1
            strQuery = strQuery & " Union Select * from TUBE_OP_055_1"
            '061-1
            'If ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port Integral" Then
            '    strQuery = strQuery & " Union Select * from TUBE_OP_061_1_1"
            'Else
            '    strQuery = strQuery & " Union Select * from TUBE_OP_061_1_2"
            'End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso (ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "SINGLE LUG" OrElse ObjClsWeldedCylinderFunctionalClass.FacricatedPart2 = "SINGLE LUG") Then  '15_05_2012   RAGAVA Then
                strQuery = strQuery & " Union Select * from TUBE_OP_061_1_2"
            Else
                strQuery = strQuery & " Union Select * from TUBE_OP_061_1_1"
            End If
            '62-1
            '16_12_2011   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso (ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "SINGLE LUG" OrElse ObjClsWeldedCylinderFunctionalClass.FacricatedPart2 = "SINGLE LUG") Then  '15_05_2012   RAGAVA Then
                strQuery = strQuery & " Union Select * from TUBE_OP_062_1"
            End If
            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize" Then
                '70-3
                strQuery = strQuery & " Union Select * from TUBE_OP_070_3"
            Else
                '70-1
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" _
                AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                    strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" _
                AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                    strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" _
                AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso _
                (Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbPinHoleSizeType.Text) = "Custom" OrElse _
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity > 0) Then
                    strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetSheet9_Tools(ByRef strQuery As String)
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "FILLET" Then
                '10-3
                strQuery = "select * from TUBE_OP_010_3"
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                '10-4
                strQuery = "select * from TUBE_OP_010_4"
            End If
            '50-4
            strQuery = strQuery & " Union Select * from TUBE_OP_050_4"
            '59-1
            strQuery = strQuery & " Union Select * from TUBE_OP_059_1"
            '60-1
            strQuery = strQuery & " Union Select * from TUBE_OP_060_1"          '19_10_2010       RAGAVA
            '70-3
            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize" Then
                strQuery = strQuery & " Union Select * from TUBE_OP_070_3"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetSheet10_Tools(ByRef strQuery As String)
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "FILLET" Then
                '10-3
                strQuery = "select * from TUBE_OP_010_3"
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                '10-4
                strQuery = "select * from TUBE_OP_010_4"
            End If
            '50-4
            strQuery = strQuery & " Union Select * from TUBE_OP_050_4"
            '59-1
            strQuery = strQuery & " Union Select * from TUBE_OP_059_1"
            '061-1
            'If ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port Integral" Then
            '    strQuery = strQuery & " Union Select * from TUBE_OP_061_1_1"
            'Else
            '    strQuery = strQuery & " Union Select * from TUBE_OP_061_1_2"
            'End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso (ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "SINGLE LUG" OrElse ObjClsWeldedCylinderFunctionalClass.FacricatedPart2 = "SINGLE LUG") Then  '15_05_2012   RAGAVA Then
                strQuery = strQuery & " Union Select * from TUBE_OP_061_1_2"
            Else
                strQuery = strQuery & " Union Select * from TUBE_OP_061_1_1"
            End If
            '62-1
            '16_12_2011   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso (ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "SINGLE LUG" OrElse ObjClsWeldedCylinderFunctionalClass.FacricatedPart2 = "SINGLE LUG") Then  '15_05_2012   RAGAVA Then
                strQuery = strQuery & " Union Select * from TUBE_OP_062_1"
            End If
            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize" Then
                '70-3
                strQuery = strQuery & " Union Select * from TUBE_OP_070_3"
            Else
                '70-1
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" _
                AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                    strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" _
                AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                    strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" _
                AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso _
                (Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbPinHoleSizeType.Text) = "Custom" OrElse _
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity > 0) Then
                    strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetSheet11_Tools(ByRef strQuery As String)
        Try
            '11-2 & 11-3 are not available
            '59-1
            strQuery = "Select * from TUBE_OP_059_1"
            '60-1
            strQuery = strQuery & " Union Select * from TUBE_OP_060_1"
            '70-3
            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize" Then
                strQuery = strQuery & " Union Select * from TUBE_OP_070_3"
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetSheet12_Tools(ByRef strQuery As String)
        Try
            '11-2 & 11-3 are not available
            '59-1
            strQuery = "Select * from TUBE_OP_059_1"
            '061-1
            'If ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port Integral" Then
            '    strQuery = strQuery & " Union Select * from TUBE_OP_061_1_1"
            'Else
            '    strQuery = strQuery & " Union Select * from TUBE_OP_061_1_2"
            'End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso (ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "SINGLE LUG" OrElse ObjClsWeldedCylinderFunctionalClass.FacricatedPart2 = "SINGLE LUG") Then  '15_05_2012   RAGAVA Then
                strQuery = strQuery & " Union Select * from TUBE_OP_061_1_2"
            Else
                strQuery = strQuery & " Union Select * from TUBE_OP_061_1_1"
            End If
            '62-1
            '16_12_2011   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso (ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "SINGLE LUG" OrElse ObjClsWeldedCylinderFunctionalClass.FacricatedPart2 = "SINGLE LUG") Then  '15_05_2012   RAGAVA Then
                strQuery = strQuery & " Union Select * from TUBE_OP_062_1"
            End If
            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize" Then
                '70-3
                strQuery = strQuery & " Union Select * from TUBE_OP_070_3"
            Else
                '70-1
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" _
                AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                    strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" _
                AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                    strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" _
                AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso _
                (Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbPinHoleSizeType.Text) = "Custom" OrElse _
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity > 0) Then
                    strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    '29_02_2012   RAGAVA
    Private Sub GetSheet13_Tools(ByRef strQuery As String)
        Try
            strQuery = "select * from TUBE_OP_010_1"
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked = True Then
                strQuery = strQuery & " Union select * from TUBE_OP_022_1"
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Bothends" Then
                '42-2
                strQuery = strQuery & " Union select * from TUBE_OP_042_2"
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType.StartsWith("Rephasing") = True Then
                '42-1
                strQuery = strQuery & " Union select * from TUBE_OP_042_1"
            End If
            strQuery = strQuery & " Union select * from TUBE_OP_043_1"
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strRodEndPortLocatorCode_Purchase <> ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strBaseEndPortLocatorCode_Purchase Then        '07_10_2010    RAGAVA
                strQuery = strQuery & " Union select * from TUBE_OP_044_1"
            End If
            If (ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd.StartsWith("90") = True OrElse ObjClsWeldedCylinderFunctionalClass.strPortAngle_RodEnd.StartsWith("90") = True) OrElse Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleBaseEnd.Text) = "Straight" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text) = "Straight" AndAlso (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationBaseEnd.Text <> ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text AndAlso ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text <> "0") Then   '06_04_2011  RAGAVA changed = to <>       '23_12_2010   RAGAVA   0 angle condition added
                '45-1
                strQuery = strQuery & " Union select * from TUBE_OP_045_1"
            ElseIf (ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd.StartsWith("90") = True AndAlso ObjClsWeldedCylinderFunctionalClass.strPortAngle_RodEnd.StartsWith("90") = True) Then
                '45-2
                strQuery = strQuery & " Union select * from TUBE_OP_045_2"
            End If
            strQuery = strQuery & " Union Select * from TUBE_OP_055_1"
            strQuery = strQuery & " Union Select * from TUBE_OP_060_1"
            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize" Then
                strQuery = strQuery & " Union Select * from TUBE_OP_070_3"
            End If
        Catch ex As Exception

        End Try
    End Sub
    '29_02_2012   RAGAVA
    Private Sub GetSheet14_Tools(ByRef strQuery As String)
        Try
            strQuery = "select * from TUBE_OP_010_1"
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked = True Then
                strQuery = strQuery & " Union select * from TUBE_OP_022_1"
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Bothends" Then
                '42-2
                strQuery = strQuery & " Union select * from TUBE_OP_042_2"
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType.StartsWith("Rephasing") = True Then
                '42-1
                strQuery = strQuery & " Union select * from TUBE_OP_042_1"
            End If
            strQuery = strQuery & " Union select * from TUBE_OP_043_1"
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strRodEndPortLocatorCode_Purchase <> ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails._strBaseEndPortLocatorCode_Purchase Then        '07_10_2010    RAGAVA
                strQuery = strQuery & " Union select * from TUBE_OP_044_1"
            End If
            If (ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd.StartsWith("90") = True OrElse ObjClsWeldedCylinderFunctionalClass.strPortAngle_RodEnd.StartsWith("90") = True) OrElse Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleBaseEnd.Text) = "Straight" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text) = "Straight" AndAlso (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationBaseEnd.Text <> ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text AndAlso ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text <> "0") Then   '06_04_2011  RAGAVA changed = to <>       '23_12_2010   RAGAVA   0 angle condition added
                '45-1
                strQuery = strQuery & " Union select * from TUBE_OP_045_1"
            ElseIf (ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd.StartsWith("90") = True AndAlso ObjClsWeldedCylinderFunctionalClass.strPortAngle_RodEnd.StartsWith("90") = True) Then
                '45-2
                strQuery = strQuery & " Union select * from TUBE_OP_045_2"
            End If
            strQuery = strQuery & " Union Select * from TUBE_OP_055_1"
            strQuery = strQuery & " Union Select * from TUBE_OP_060_1"
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso (ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "SINGLE LUG" OrElse ObjClsWeldedCylinderFunctionalClass.FacricatedPart2 = "SINGLE LUG") Then  '15_05_2012   RAGAVA Then
                strQuery = strQuery & " Union Select * from TUBE_OP_062_1"
            End If
            '70-1
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" _
            AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" _
            AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" _
            AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso _
            (Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbPinHoleSizeType.Text) = "Custom" OrElse _
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity > 0) Then
                strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
            End If
            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize" Then
                strQuery = strQuery & " Union Select * from TUBE_OP_070_3"
            End If
        Catch ex As Exception

        End Try
    End Sub

    '05_03_2012   RAGAVA
    Private Sub GetSheet15_Tools(ByRef strQuery As String)
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "FILLET" Then
                '10-3
                strQuery = "select * from TUBE_OP_010_3"
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                '10-4
                strQuery = "select * from TUBE_OP_010_4"
            End If
            strQuery = strQuery & " Union select * from TUBE_OP_042_3"
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_BaseEnd >= 0.125 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_RodEnd >= 0.125 Then
                '50-1 
                strQuery = strQuery & " Union Select * from TUBE_OP_050_1"
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_BaseEnd <= 0.125 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_RodEnd <= 0.125 Then
                '50-2
                strQuery = strQuery & " Union Select * from TUBE_OP_050_2"
            Else
                '50-3
                strQuery = strQuery & " Union Select * from TUBE_OP_050_3"
            End If
            strQuery = strQuery & " Union Select * from TUBE_OP_059_1"
            strQuery = strQuery & " Union Select * from TUBE_OP_060_1"
            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize" Then
                strQuery = strQuery & " Union Select * from TUBE_OP_070_3"
            End If
        Catch ex As Exception

        End Try
    End Sub
    '05_03_2012   RAGAVA
    Private Sub GetSheet16_Tools(ByRef strQuery As String)
        Try
            'GetTools_10_3_Logics()
            'GetTools_42_Logics("42-3")
            'GetTools_50_Logics()
            'GetTools_59_Logics()
            'GetTools_61_Logics()
            'GetTools_62_Logics()
            'GetTools_70_Logics()
            'GetTools_70_3_Logics()
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "FILLET" Then
                '10-3
                strQuery = "select * from TUBE_OP_010_3"
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                '10-4
                strQuery = "select * from TUBE_OP_010_4"
            End If
            strQuery = strQuery & " Union select * from TUBE_OP_042_3"
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_BaseEnd >= 0.125 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_RodEnd >= 0.125 Then
                '50-1 
                strQuery = strQuery & " Union Select * from TUBE_OP_050_1"
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_BaseEnd <= 0.125 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_RodEnd <= 0.125 Then
                '50-2
                strQuery = strQuery & " Union Select * from TUBE_OP_050_2"
            Else
                '50-3
                strQuery = strQuery & " Union Select * from TUBE_OP_050_3"
            End If
            strQuery = strQuery & " Union Select * from TUBE_OP_059_1"
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso (ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "SINGLE LUG" OrElse ObjClsWeldedCylinderFunctionalClass.FacricatedPart2 = "SINGLE LUG") Then  '15_05_2012   RAGAVA Then
                strQuery = strQuery & " Union Select * from TUBE_OP_061_1_2"
            Else
                strQuery = strQuery & " Union Select * from TUBE_OP_061_1_1"
            End If
            '62-1
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso (ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "SINGLE LUG" OrElse ObjClsWeldedCylinderFunctionalClass.FacricatedPart2 = "SINGLE LUG") Then  '15_05_2012   RAGAVA Then
                strQuery = strQuery & " Union Select * from TUBE_OP_062_1"
            End If
            '70-1
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" _
            AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" _
            AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" _
            AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso _
            (Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbPinHoleSizeType.Text) = "Custom" OrElse _
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity > 0) Then
                strQuery = strQuery & " Union Select * from TUBE_OP_070_1"
            End If
            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize" Then
                strQuery = strQuery & " Union Select * from TUBE_OP_070_3"
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region
End Class
