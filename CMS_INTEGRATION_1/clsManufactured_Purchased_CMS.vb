Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Public Class clsManufactured_Purchased_CMS
    Private oHT_CSV As New Hashtable
    Private oExApp As New Excel.Application
    Private oExlWrkBk As Excel.Workbook
    Private oExlWrkSht As Excel.Worksheet
    Private oRng As Excel.Range
    Dim strFileName As String = String.Empty
    Public Sub New()
        InitializeParameters()
    End Sub

    Private Enum VariableList
        strInternalPartNumber
        strDefaultPlant
        strManufactured_Purchased
        strDescription1
        strDescription2
        strDescription3
        strGLsalesCode
        strGLExpenseCode
        strInventoryUnit
        strMajorGroup
        strMinorGroup
        strMajorSales
        strMinorSales
        strCustomerCode
        strCustomerPartNumber
        strVendorCode
        strVendorPartNumber
        strCatalogID
        strAssyWeight
        strUnitOfMeasure_AssyWeight
        strShippingVolume
        strUnitOfMeasure_ShippingVolume
        strFreightCode
        strLump
        strLengthConsumed
        strCoil
        strHazardous
        strMaterialTemplateCode
        strUserVerificationTemplateCode
        strShelfLife
        strInventory
        strHarmonizationCode
        strStyleCode
        strSizeCode
        strColorCode
        strAssyCode
        strSubAssyCode
        DefaultUnits
        strApplyGlobalDiscount
        strWholeOrderVolDisc
        strWholeOrderPrcDiscount
        strFIFOtracking
        strAntiDumpingtrack
        strDumpingSubjectIndicator
        strServiceChargePart
        strOneTimePart
        strSeperatePO_APlump
        strCommodityCategoryCode
    End Enum

    Public Sub InitializeParameters()
        Dim strInternalPartNumber As String = String.Empty
        AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
        Dim strDefaultPlant As String = ""
        AddtoHashTable(VariableList.strDefaultPlant, strDefaultPlant)
        Dim strManufactured_Purchased As String = "1"
        AddtoHashTable(VariableList.strManufactured_Purchased, strManufactured_Purchased)
        Dim strDescription1 As String = ""       'Monarch to provide logics
        AddtoHashTable(VariableList.strDescription1, strDescription1)
        Dim strDescription2 As String = ""       'Monarch to provide logics
        AddtoHashTable(VariableList.strDescription2, strDescription2)
        Dim strDescription3 As String = ""
        AddtoHashTable(VariableList.strDescription3, strDescription3)
        Dim strGLsalesCode As String = "WEL"
        AddtoHashTable(VariableList.strGLsalesCode, strGLsalesCode)
        Dim strGLExpenseCode As String = "FGB"
        AddtoHashTable(VariableList.strGLExpenseCode, strGLExpenseCode)
        Dim strInventoryUnit As String = "EA"
        AddtoHashTable(VariableList.strInventoryUnit, strInventoryUnit)
        Dim strMajorGroup As String = "016"
        AddtoHashTable(VariableList.strMajorGroup, strMajorGroup)
        Dim strMinorGroup As String = "W02"              'W03 based on CustomerName "CNH"
        AddtoHashTable(VariableList.strMinorGroup, strMinorGroup)
        Dim strMajorSales As String = strMajorGroup
        AddtoHashTable(VariableList.strMajorSales, strMajorSales)
        Dim strMinorSales As String = strMinorGroup      'W03 based on CustomerName "CNH"
        AddtoHashTable(VariableList.strMinorSales, strMinorSales)
        Dim strCustomerCode As String = ""
        AddtoHashTable(VariableList.strCustomerCode, strCustomerCode)
        Dim strCustomerPartNumber As String = ""
        AddtoHashTable(VariableList.strCustomerPartNumber, strCustomerPartNumber)
        Dim strVendorCode As String = ""
        AddtoHashTable(VariableList.strVendorCode, strVendorCode)
        Dim strVendorPartNumber As String = ""
        AddtoHashTable(VariableList.strVendorPartNumber, strVendorPartNumber)
        Dim strCatalogID As String = "9813.00.00.95"
        AddtoHashTable(VariableList.strCatalogID, strCatalogID)
        Dim strAssyWeight As String = ""
        AddtoHashTable(VariableList.strAssyWeight, strAssyWeight)
        Dim strUnitOfMeasure_AssyWeight As String = "lb"
        AddtoHashTable(VariableList.strUnitOfMeasure_AssyWeight, strUnitOfMeasure_AssyWeight)
        Dim strShippingVolume As String = ""
        AddtoHashTable(VariableList.strShippingVolume, strShippingVolume)
        Dim strUnitOfMeasure_ShippingVolume As String = ""
        AddtoHashTable(VariableList.strUnitOfMeasure_ShippingVolume, strUnitOfMeasure_ShippingVolume)
        Dim strFreightCode As String = ""
        AddtoHashTable(VariableList.strFreightCode, strFreightCode)
        Dim strLump As String = "2"
        AddtoHashTable(VariableList.strLump, strLump)
        Dim strLengthConsumed As String = "2"
        AddtoHashTable(VariableList.strLengthConsumed, strLengthConsumed)
        Dim strCoil As String = "2"
        AddtoHashTable(VariableList.strCoil, strCoil)
        Dim strHazardous As String = "2"
        AddtoHashTable(VariableList.strHazardous, strHazardous)
        Dim strMaterialTemplateCode As String = ""
        AddtoHashTable(VariableList.strMaterialTemplateCode, strMaterialTemplateCode)
        Dim strUserVerificationTemplateCode As String = "Customs"
        AddtoHashTable(VariableList.strUserVerificationTemplateCode, strUserVerificationTemplateCode)
        Dim strShelfLife As String = ""
        AddtoHashTable(VariableList.strShelfLife, strShelfLife)
        Dim strInventory As String = ""
        AddtoHashTable(VariableList.strInventory, strInventory)
        Dim strHarmonizationCode As String = "8412.21.0030"
        AddtoHashTable(VariableList.strHarmonizationCode, strHarmonizationCode)
        Dim strStyleCode As String = ""
        AddtoHashTable(VariableList.strStyleCode, strStyleCode)
        Dim strSizeCode As String = ""
        AddtoHashTable(VariableList.strSizeCode, strSizeCode)
        Dim strColorCode As String = ""
        AddtoHashTable(VariableList.strColorCode, strColorCode)
        Dim strAssyCode As String = ""
        AddtoHashTable(VariableList.strAssyCode, strAssyCode)
        Dim strSubAssyCode As String = ""
        AddtoHashTable(VariableList.strSubAssyCode, strSubAssyCode)
        Dim DefaultUnits As String = "1"
        AddtoHashTable(VariableList.DefaultUnits, DefaultUnits)
        Dim strApplyGlobalDiscount As String = "1"
        AddtoHashTable(VariableList.strApplyGlobalDiscount, strApplyGlobalDiscount)
        Dim strWholeOrderVolDisc As String = "2"
        AddtoHashTable(VariableList.strWholeOrderVolDisc, strWholeOrderVolDisc)
        Dim strWholeOrderPrcDiscount As String = "2"
        AddtoHashTable(VariableList.strWholeOrderPrcDiscount, strWholeOrderPrcDiscount)
        Dim strFIFOtracking As String = "2"
        AddtoHashTable(VariableList.strFIFOtracking, strFIFOtracking)
        Dim strAntiDumpingtrack As String = ""
        AddtoHashTable(VariableList.strAntiDumpingtrack, strAntiDumpingtrack)
        Dim strDumpingSubjectIndicator As String = ""
        AddtoHashTable(VariableList.strDumpingSubjectIndicator, strDumpingSubjectIndicator)
        Dim strServiceChargePart As String = "2"
        AddtoHashTable(VariableList.strServiceChargePart, strServiceChargePart)
        Dim strOneTimePart As String = "2"
        AddtoHashTable(VariableList.strOneTimePart, strOneTimePart)
        Dim strSeperatePO_APlump As String = "2"
        AddtoHashTable(VariableList.strSeperatePO_APlump, strSeperatePO_APlump)
        Dim strCommodityCategoryCode As String = ""
        AddtoHashTable(VariableList.strCommodityCategoryCode, strCommodityCategoryCode)
    End Sub
    Private Sub AddtoHashTable(ByVal Key As String, ByVal Value As String)
        Try
            If oHT_CSV.Contains(Key) = False Then
                oHT_CSV.Add(Key, Value)
            Else
                oHT_CSV(Key) = Value
            End If
        Catch ex As Exception

        End Try
    End Sub
#Region "Manufactured"
    Private Sub WeldedCylinder_CSV()
        Try
            AddtoHashTable(VariableList.strAssyWeight, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strWeldCylinderVolume)        '24_08_2010   RAGAVA
            AddtoHashTable(VariableList.strInternalPartNumber, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber)
            strFileName = "STKMM" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CustomerName_ContractDetails.IndexOf("CNH") <> -1 Then
                AddtoHashTable(VariableList.strMinorGroup, "W03")
            End If
            If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PartCode_ContractDetails) <> "" AndAlso UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PartCode_ContractDetails) <> "TDA" Then
                AddtoHashTable(VariableList.strCustomerPartNumber, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PartCode_ContractDetails)
            End If
            GenerateCSVfiles(oHT_CSV)
        Catch ex As Exception
            MsgBox("Error in " & ex.TargetSite.ToString)
        End Try
    End Sub

    Public Sub Generate_Manufactured_Purchased_CMS()
        WeldedCylinder_CSV()
        TubeWeldment_CSV()
        RodWeldment_CSV()
        CylinderHead_CSV()
        CrossTube_CSV()
        Lug_CSV()
        Piston_CSV()
        SteelCasting_CSV()
        StopTube_CSV()
    End Sub

    Private Sub TubeWeldment_CSV()
        Try
            Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT")
            If Not strInternalPartNumber Is Nothing Then
                strFileName = "STKMM" & strInternalPartNumber
                AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                AddtoHashTable(VariableList.strGLExpenseCode, "SFB")
                AddtoHashTable(VariableList.strMajorGroup, Format("017", "000"))  '24_08_2010    RAGAVA   format added
                AddtoHashTable(VariableList.strMinorGroup, "W51")
                AddtoHashTable(VariableList.strMajorSales, Format("017", "000"))  '24_08_2010    RAGAVA   format added
                AddtoHashTable(VariableList.strMinorSales, "W51")
                AddtoHashTable(VariableList.strCatalogID, "9813.00.00.95")
                AddtoHashTable(VariableList.strAssyWeight, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentVolume)        '24_08_2010   RAGAVA
                AddtoHashTable(VariableList.strHarmonizationCode, "8412.90.9005")
                AddtoHashTable(VariableList.strCustomerPartNumber, "")    '23_08_2010   RAGAVA
                GenerateCSVfiles(oHT_CSV)
            End If
        Catch ex As Exception
            MsgBox("Error in " & ex.TargetSite.ToString)
        End Try
    End Sub

    Private Sub RodWeldment_CSV()
        Try
            Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT")
            If Not strInternalPartNumber Is Nothing Then
                strFileName = "STKMM" & strInternalPartNumber
                AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                AddtoHashTable(VariableList.strGLExpenseCode, "SFB")
                AddtoHashTable(VariableList.strMajorGroup, Format("017", "000"))  '24_08_2010    RAGAVA   format added
                AddtoHashTable(VariableList.strMinorGroup, "W51")
                AddtoHashTable(VariableList.strMajorSales, Format("017", "000"))  '24_08_2010    RAGAVA   format added
                AddtoHashTable(VariableList.strMinorSales, "W51")
                AddtoHashTable(VariableList.strCatalogID, "8413.00.00.95")
                AddtoHashTable(VariableList.strAssyWeight, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodWeldmentVolume)       '24_08_2010    RAGAVA
                AddtoHashTable(VariableList.strHarmonizationCode, "8412.90.9005")
                AddtoHashTable(VariableList.strCustomerPartNumber, "")    '23_08_2010   RAGAVA
                GenerateCSVfiles(oHT_CSV)
            End If
        Catch ex As Exception
            MsgBox("Error in " & ex.TargetSite.ToString)
        End Try
    End Sub
#End Region

#Region "Purchased"
    Private Sub Initialize_Purchased()
        AddtoHashTable(VariableList.strManufactured_Purchased, "2")
        AddtoHashTable(VariableList.strGLExpenseCode, "RAB")
        AddtoHashTable(VariableList.strMajorGroup, Format("017", "000"))  '24_08_2010    RAGAVA   format added
        AddtoHashTable(VariableList.strMinorGroup, "W52")
        AddtoHashTable(VariableList.strMajorSales, Format("017", "000"))  '24_08_2010    RAGAVA   format added
        AddtoHashTable(VariableList.strMinorSales, "W52")
        AddtoHashTable(VariableList.strCatalogID, "9814.00.00.95")
        AddtoHashTable(VariableList.strAssyWeight, "")
        AddtoHashTable(VariableList.strUserVerificationTemplateCode, "")
        AddtoHashTable(VariableList.strHarmonizationCode, "8412.90.9005")
        AddtoHashTable(VariableList.strAntiDumpingtrack, "2")
        AddtoHashTable(VariableList.strDumpingSubjectIndicator, "2")
        AddtoHashTable(VariableList.strServiceChargePart, "")
    End Sub
    Private Sub CylinderHead_CSV()
        Try
            Dim oExistingListItems As clsList = clsAddExistingCodes._htExistingCostingCodeList(clsAddExistingCodes.CYLINDERHEADCODE)
            Dim strInternalPartNumber As String = oExistingListItems.strPartCode
            If Not strInternalPartNumber Is Nothing Then
                strFileName = "STKMP" & strInternalPartNumber
                AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                Initialize_Purchased()
                GenerateCSVfiles(oHT_CSV)
            End If
        Catch ex As Exception
            MsgBox("error in " & ex.TargetSite.ToString)
        End Try
    End Sub
    Private Sub Piston_CSV()
        Try
            Dim oExistingListItems As clsList = clsAddExistingCodes._htExistingCostingCodeList(clsAddExistingCodes.PISTONCODE)
            Dim strInternalPartNumber As String = oExistingListItems.strPartCode
            If Not strInternalPartNumber Is Nothing Then
                strFileName = "STKMP" & strInternalPartNumber
                AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                Initialize_Purchased()
                GenerateCSVfiles(oHT_CSV)
            End If
        Catch ex As Exception
            MsgBox("error in " & ex.TargetSite.ToString)
        End Try
    End Sub
    Private Sub SteelCasting_CSV()
        'Fabricated
        Try
            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType) = "CAST" Then
                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd) <> "" Then
                    Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd
                    If Not strInternalPartNumber Is Nothing Then
                        strFileName = "STKMP" & strInternalPartNumber
                        AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                        Initialize_Purchased()
                        GenerateCSVfiles(oHT_CSV)
                    End If
                End If
            End If
            If UCase(ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated) = "CAST" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName) Then
                    Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                    If Not strInternalPartNumber Is Nothing Then
                        strFileName = "STKMP" & strInternalPartNumber
                        AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                        Initialize_Purchased()
                        GenerateCSVfiles(oHT_CSV)
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CrossTube_CSV()
        Try
            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType) = "FABRICATED" Then
                Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("Base_Crosstube_IFL")
                If Not strInternalPartNumber Is Nothing Then
                    strFileName = "STKMP" & strInternalPartNumber
                    AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                    Initialize_Purchased()
                    GenerateCSVfiles(oHT_CSV)
                End If
            End If
            If UCase(ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated) = "FABRICATED" Then
                Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("CROSSTUBE_ROD")
                If Not strInternalPartNumber Is Nothing Then
                    strFileName = "STKMP" & strInternalPartNumber
                    AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                    Initialize_Purchased()
                    GenerateCSVfiles(oHT_CSV)
                End If
            End If
        Catch ex As Exception
            MsgBox("error in " & ex.TargetSite.ToString)
        End Try
    End Sub

    Private Sub StopTube_CSV()
        Try
            Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("Stop_tube")
            If Not strInternalPartNumber Is Nothing Then
                strFileName = "STKMP" & strInternalPartNumber
                AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                Initialize_Purchased()
                GenerateCSVfiles(oHT_CSV)
            End If
        Catch ex As Exception
            MsgBox("error in " & ex.TargetSite.ToString)
        End Try
    End Sub

    Private Sub Lug_CSV()
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" Then
                    If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd) <> "" Then
                        Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd
                        strFileName = "STKMM" & strInternalPartNumber    '23_08_2010   RAGAVA  STKMP to STKMM
                        AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                        AddtoHashTable(VariableList.strGLExpenseCode, "SFB")
                        AddtoHashTable(VariableList.strMajorGroup, "O17")
                        AddtoHashTable(VariableList.strMinorGroup, "W51")
                        AddtoHashTable(VariableList.strMajorSales, "O17")
                        AddtoHashTable(VariableList.strMinorSales, "W51")
                        AddtoHashTable(VariableList.strCatalogID, "9813.00.00.95")
                        AddtoHashTable(VariableList.strAssyWeight, ObjClsWeldedCylinderFunctionalClass.BaseEndWeight)      '24_08_2010   RAGAVA
                        AddtoHashTable(VariableList.strHarmonizationCode, "8412.90.9005")
                        AddtoHashTable(VariableList.strCustomerPartNumber, "")    '23_08_2010   RAGAVA
                        GenerateCSVfiles(oHT_CSV)
                    End If
                End If
            End If
            If ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" Then
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName) Then
                        Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                        strFileName = "STKMM" & strInternalPartNumber          '23_08_2010   RAGAVA  STKMP to STKMM
                        AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                        AddtoHashTable(VariableList.strGLExpenseCode, "SFB")
                        AddtoHashTable(VariableList.strMajorGroup, "O17")
                        AddtoHashTable(VariableList.strMinorGroup, "W51")
                        AddtoHashTable(VariableList.strMajorSales, "O17")
                        AddtoHashTable(VariableList.strMinorSales, "W51")
                        AddtoHashTable(VariableList.strCatalogID, "9813.00.00.95")
                        AddtoHashTable(VariableList.strAssyWeight, ObjClsWeldedCylinderFunctionalClass.RodEndWeight)      '24_08_2010   RAGAVA
                        AddtoHashTable(VariableList.strHarmonizationCode, "8412.90.9005")
                        AddtoHashTable(VariableList.strCustomerPartNumber, "")    '23_08_2010   RAGAVA
                        GenerateCSVfiles(oHT_CSV)
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("error in " & ex.TargetSite.ToString)
        End Try
    End Sub
#End Region

#Region "CSV File Generation"

    Private Sub GenerateCSVfiles(ByVal HtList As Hashtable)
        Try
            If File.Exists("C:\CMS.xls") = False Then
                MsgBox("Create an Excel File C:\CMS.xls" & vbNewLine & "then click ok")
            End If
            Dim strfile As String = "C:\CMS.xls"
            oExlWrkBk = oExApp.Workbooks.Open(strfile)
            oExlWrkSht = oExlWrkBk.Worksheets("Sheet1")
            Dim blnsndloop As Boolean = False
            Dim blnThirdLoop As Boolean = False
            Dim i As Integer = 65
            Dim icount As Integer = 0
            For icount = 0 To oHT_CSV.Keys.Count
                Dim ch As String = Convert.ToChar(i)
                If blnsndloop = True Then
                    ch = "A" & ch
                ElseIf blnThirdLoop = True Then
                    ch = "B" & ch
                End If
                oRng = oExlWrkSht.Range(ch & "1")
                oRng.Value2 = oHT_CSV(icount.ToString)
                If ch = "Z" Then
                    i = 64
                    blnsndloop = True
                ElseIf ch = "AZ" Then
                    blnThirdLoop = True
                    i = 64
                End If
                i = i + 1
            Next
            oExlWrkBk.SaveAs(ObjClsWeldedCylinderFunctionalClass.strCMSfileLocation & "\" & strFileName & ".csv", XlFileFormat.xlCSVMSDOS)
        Catch ex As Exception
            MsgBox("Error in " & ex.TargetSite.ToString)
        End Try
    End Sub
#End Region
End Class
