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
        Dim strMajorGroup As String = "'" & Format(16, "000") '09_10_2010   RAGAVA  ' "016"
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
        Dim strUnitOfMeasure_AssyWeight As String = "LB"
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
            AddtoHashTable(VariableList.strAssyWeight, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strWeldCylinderWeight)  '09_10_2010  RAGAVA      '24_08_2010   RAGAVA
            AddtoHashTable(VariableList.strInternalPartNumber, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber)
            strFileName = "STKMM" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CustomerName_ContractDetails.IndexOf("CNH") <> -1 Then
            '    AddtoHashTable(VariableList.strMinorGroup, "W03")
            'End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CustomerName_ContractDetails.IndexOf("CNH") <> -1 Then  'Priyanka
                AddtoHashTable(VariableList.strMinorGroup, "W03")
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 4.5 Then
                AddtoHashTable(VariableList.strMinorGroup, "W30")
            End If
            If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PartCode_ContractDetails) <> "" AndAlso UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PartCode_ContractDetails) <> "TBA" Then
                AddtoHashTable(VariableList.strCustomerPartNumber, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PartCode_ContractDetails)
            End If

            '20_09_2010   RAGAVA
            Dim PartCode1 As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PartCode_ContractDetails
            Dim CustomerName As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CustomerName_ContractDetails
            ' anup 08-03-2011 start
            Dim strCylinderModelNumber As String = Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter * 10, 2).ToString + _
                                                                                "WR" + Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, 2), "00.00") + "-" + _
                                                                                 (Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, 2) * 100).ToString

            Dim strDescription As String = String.Empty
            Dim intLength As Integer
            If CustomerName.Length < 4 Then
                strDescription = "CYL " + strCylinderModelNumber + CustomerName.Substring(0, 3)
                intLength = 3
            Else
                strDescription = "CYL " + strCylinderModelNumber + CustomerName.Substring(0, 4)
                intLength = 4
            End If

            If UCase(PartCode1) <> "TBA" AndAlso PartCode1 <> "" Then
                Dim strTempDescription As String = "CYL " + strCylinderModelNumber + CustomerName.Substring(0, intLength) + "#" + PartCode1
                If strTempDescription.Length <= 30 Then
                    strDescription += "#" + PartCode1
                End If
            End If
            AddtoHashTable(VariableList.strDescription1, strDescription)

            'If UCase(PartCode1) <> "TBA" OrElse PartCode1 <> "" Then
            '    'objclsCMS_STKMM_STKMP_CylinderSheet.PartDescriptionLine1 = "CYL " + SetCodeDesciption + CustomerName + "#" + PartCode1
            '    If CustomerName.Length < 4 Then
            '        AddtoHashTable(VariableList.strDescription1, "CYL " + CustomerName.Substring(0, 3) + "#" + PartCode1)   '06_09_2010    RAGAVA
            '    Else
            '        AddtoHashTable(VariableList.strDescription1, "CYL " + CustomerName.Substring(0, 4) + "#" + PartCode1)    '06_09_2010    RAGAVA
            '    End If
            'Else
            '    'objclsCMS_STKMM_STKMP_CylinderSheet.PartDescriptionLine1 = "CYL " + SetCodeDesciption + CustomerName
            '    If CustomerName.Length < 4 Then
            '        AddtoHashTable(VariableList.strDescription1, "CYL " + CustomerName.Substring(0, 3))    '06_09_2010   RAGAVA
            '    Else
            '        AddtoHashTable(VariableList.strDescription1, "CYL " + CustomerName.Substring(0, 4))    '06_09_2010   RAGAVA
            '    End If
            'End If
            'Till   Here
            ' anup 08-03-2011 till here

            GenerateCSVfiles(oHT_CSV)
        Catch ex As Exception
            'MsgBox("Error in " & ex.TargetSite.ToString)
        End Try
    End Sub

    Public Sub Generate_Manufactured_Purchased_CMS()

        'STKMM
        WeldedCylinder_CSV()
        TubeWeldment_CSV()
        RodWeldment_CSV()
        'Lug_CSV()

        'STKMP
        CylinderHead_CSV()
        CrossTube_CSV()
        Piston_CSV()
        SteelCasting_CSV()
        StopTube_CSV()
        STKMP_LUG()
    End Sub

    Private Sub TubeWeldment_CSV()
        Try
            Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT")
            If Not strInternalPartNumber Is Nothing Then
                strFileName = "STKMM" & strInternalPartNumber
                AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                AddtoHashTable(VariableList.strGLExpenseCode, "SFB")
                AddtoHashTable(VariableList.strMajorGroup, "'" & Format(17, "000"))  '24_08_2010    RAGAVA   format added
                AddtoHashTable(VariableList.strMinorGroup, "W51")
                AddtoHashTable(VariableList.strMajorSales, "'" & Format(17, "000"))  '24_08_2010    RAGAVA   format added
                AddtoHashTable(VariableList.strMinorSales, "W51")
                AddtoHashTable(VariableList.strCatalogID, "9813.00.00.95")
                AddtoHashTable(VariableList.strAssyWeight, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentWeight)   '09_10_2010  RAGAVA       '24_08_2010   RAGAVA
                AddtoHashTable(VariableList.strHarmonizationCode, "8412.90.9005")
                AddtoHashTable(VariableList.strCustomerPartNumber, "")    '23_08_2010   RAGAVA
                Try
                    Dim strDesc As String = String.Empty
                    strDesc = "TUBE WELDT " & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, "0.00").ToString & "-" & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, "00.00").ToString & "-W"          '16_11_2011  RAGAVA
                    AddtoHashTable(VariableList.strDescription1, strDesc)       '16_11_2011   RAGAVA
                    'AddtoHashTable(VariableList.strDescription1, "TUBE CYL " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength.ToString)      '20_09_2010   RAGAVA
                Catch ex As Exception
                End Try
                GenerateCSVfiles(oHT_CSV)
            End If
        Catch ex As Exception
            'MsgBox("Error in " & ex.TargetSite.ToString)
        End Try
    End Sub

    Private Sub RodWeldment_CSV()
        Try
            Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT")
            If Not strInternalPartNumber Is Nothing Then
                strFileName = "STKMM" & strInternalPartNumber
                AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                AddtoHashTable(VariableList.strGLExpenseCode, "SFB")
                AddtoHashTable(VariableList.strMajorGroup, "'" & Format(17, "000"))  '24_08_2010    RAGAVA   format added
                AddtoHashTable(VariableList.strMinorGroup, "W51")
                AddtoHashTable(VariableList.strMajorSales, "'" & Format(17, "000"))  '24_08_2010    RAGAVA   format added
                AddtoHashTable(VariableList.strMinorSales, "W51")
                AddtoHashTable(VariableList.strCatalogID, "8413.00.00.95")
                AddtoHashTable(VariableList.strAssyWeight, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodWeldmentWeight)   '09_10_2010  RAGAVA      '24_08_2010    RAGAVA
                AddtoHashTable(VariableList.strHarmonizationCode, "8412.90.9005")
                AddtoHashTable(VariableList.strCustomerPartNumber, "")    '23_08_2010   RAGAVA
                Try
                    'objclsCMS_STKMM_STKMP_RodSheet.PartDescriptionLine1 = "ROD CYL " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength.ToString + "-"
                    'If IsNothing(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonThreadSize) Then
                    '    objclsCMS_STKMM_STKMP_RodSheet.PartDescriptionLine1 += dblRodThreadSize.ToString
                    'Else
                    '    objclsCMS_STKMM_STKMP_RodSheet.PartDescriptionLine1 += PistonThreadSize.ToString + "_" + dblRodThreadSize.ToString
                    'End If
                    Dim strDesc As String = String.Empty

                    If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Threaded") OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Threaded Rod" Then
                        strDesc = "ROD CYL " & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, "0.00").ToString & "-" & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, "00.00").ToString & "-" & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInDecimals, "0.00").ToString
                    Else
                        strDesc = "ROD WELDT " & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, "0.00").ToString & "-" & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, "00.00").ToString & "-" & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInDecimals, "0.00").ToString & "-W"          '16_11_2011  RAGAVA
                    End If
                    'AddtoHashTable(VariableList.strDescription1, "ROD CYL " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength.ToString)      '20_09_2010   RAGAVA
                    AddtoHashTable(VariableList.strDescription1, strDesc)   '16_11_2011  RAGAVA
                Catch ex As Exception
                End Try
                GenerateCSVfiles(oHT_CSV)
            End If
        Catch ex As Exception
            'MsgBox("Error in " & ex.TargetSite.ToString)
        End Try
    End Sub
#End Region

#Region "Purchased"
    Private Sub Initialize_Purchased()
        AddtoHashTable(VariableList.strManufactured_Purchased, "2")
        AddtoHashTable(VariableList.strGLExpenseCode, "RAB")
        AddtoHashTable(VariableList.strMajorGroup, "'" & Format(17, "000"))  '24_08_2010    RAGAVA   format added
        AddtoHashTable(VariableList.strMinorGroup, "W52")
        AddtoHashTable(VariableList.strMajorSales, "'" & Format(17, "000"))  '24_08_2010    RAGAVA   format added
        AddtoHashTable(VariableList.strMinorSales, "W52")
        AddtoHashTable(VariableList.strCatalogID, "9814.00.00.95")
        AddtoHashTable(VariableList.strAssyWeight, "")
        AddtoHashTable(VariableList.strUserVerificationTemplateCode, "")
        AddtoHashTable(VariableList.strHarmonizationCode, "8412.90.9005")
        AddtoHashTable(VariableList.strAntiDumpingtrack, "2")
        AddtoHashTable(VariableList.strDumpingSubjectIndicator, "2")
        AddtoHashTable(VariableList.strServiceChargePart, "")
    End Sub

    '16_12_2011   RAGAVA
    Private Sub STKMP_LUG()
        Try
            If Trim(ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode) = "" OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Lug_BE Then           '14_10_2010   RAGAVA    'anup 18-03-2011 
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "BH" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" Then
                    If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType) = "FABRICATED" OrElse UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2) = "FABRICATED" Then
                        'Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                        Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart)      '19_07_2012   RAGAVA
                        If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strInternalPartNumber) OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_CrossTube_BE Then         '11_10_2010   RAGAVA 'anup 17-02-2011 'anup 10-03-2011
                            If Not strInternalPartNumber Is Nothing Then
                                strFileName = "STKMP" & strInternalPartNumber
                                Initialize_Purchased()
                                AddtoHashTable(VariableList.strDescription1, "BASE END LUG")       '11_10_2010   RAGAVA
                                AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                                GenerateCSVfiles(oHT_CSV)
                            End If
                        End If
                    End If
                End If
            End If
            If Trim(ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode) = "" OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Lug_RE Then         '14_10_2010   RAGAVA 'anup 18-03-2011
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "BH" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" Then
                    If UCase(ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated) = "FABRICATED" Then
                        Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                        If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strInternalPartNumber) OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_CrossTube_RE Then         '11_10_2010   RAGAVA 'anup 17-02-2011  'anup 10-03-2011
                            If Not strInternalPartNumber Is Nothing Then
                                strFileName = "STKMP" & strInternalPartNumber
                                Initialize_Purchased()
                                AddtoHashTable(VariableList.strDescription1, "ROD END LUG")       '11_10_2010   RAGAVA
                                AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                                GenerateCSVfiles(oHT_CSV)
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            'MsgBox("error in " & ex.TargetSite.ToString)
        End Try
    End Sub



    Private Sub CylinderHead_CSV()
        Try
            Dim oExistingListItems As clsList = clsAddExistingCodes._htExistingCostingCodeList(clsAddExistingCodes.CYLINDERHEADCODE)
            If Not oExistingListItems Is Nothing Then         '29_10_2010   RAGAVA
                Dim strInternalPartNumber As String = oExistingListItems.strPartCode
                If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strInternalPartNumber) Then 'OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_CylinderHead Then         '11_10_2010   RAGAVA 'anup 17-02-2011 'anup 28-02-2011
                    If Not strInternalPartNumber Is Nothing Then
                        strFileName = "STKMP" & strInternalPartNumber
                        Initialize_Purchased()
                        AddtoHashTable(VariableList.strDescription1, "CYLINDER HEAD")       '11_10_2010   RAGAVA
                        AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                        GenerateCSVfiles(oHT_CSV)
                    End If
                End If
            End If
        Catch ex As Exception
            'MsgBox("error in " & ex.TargetSite.ToString)
        End Try
    End Sub
    Private Sub Piston_CSV()
        Try
            Dim oExistingListItems As clsList = clsAddExistingCodes._htExistingCostingCodeList(clsAddExistingCodes.PISTONCODE)
            If Not oExistingListItems Is Nothing Then         '29_10_2010   RAGAVA
                Dim strInternalPartNumber As String = oExistingListItems.strPartCode
                If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strInternalPartNumber) Then 'OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Piston Then         '11_10_2010   RAGAVA 'anup17-02-2011  'anup 28-02-2011
                    If Not strInternalPartNumber Is Nothing Then
                        strFileName = "STKMP" & strInternalPartNumber
                        Initialize_Purchased()
                        AddtoHashTable(VariableList.strDescription1, "PISTON")       '11_10_2010   RAGAVA
                        AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                        GenerateCSVfiles(oHT_CSV)
                    End If
                End If
            End If
        Catch ex As Exception
            'MsgBox("error in " & ex.TargetSite.ToString)
        End Try
    End Sub
    Private Sub SteelCasting_CSV()
        'Fabricated
        Try
            If Trim(ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode) = "" OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Casting_BE Then         '14_10_2010   RAGAVA 'anup 18-03-2011
                If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType) = "CAST" OrElse UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2) = "CAST" Then      '19_07_2012   RAGAVA
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                    Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart)   '19_07_2012    RAGAVA
                    'If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd) <> "" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName) Then
                    
                    If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strInternalPartNumber) OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Casting_BE Then         '11_10_2010   RAGAVA  'anup 17-02-2011  'anup 10-03-2011
                        If Not strInternalPartNumber Is Nothing Then
                            strFileName = "STKMP" & strInternalPartNumber
                            Initialize_Purchased()
                            AddtoHashTable(VariableList.strDescription1, "BASE END CONFIGURATION")       '11_10_2010   RAGAVA
                            AddtoHashTable(VariableList.strAssyWeight, ObjClsWeldedCylinderFunctionalClass.BaseEndWeight.ToString)      '11_10_2010   RAGAVA
                            AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                            GenerateCSVfiles(oHT_CSV)
                        End If
                    End If
                End If
            End If
            If Trim(ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode) = "" OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Casting_RE Then          '14_10_2010   RAGAVA 'anup 18-03-2011
                If UCase(ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated) = "CAST" Then 'OrElse UCase(ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated2) = "CAST" Then       '31_08_2012   RAGAVA  Commented   Weldment
                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName) Then
                    '25_07_2012   RAGAVA
                    Dim strInternalPartNumber As String = ""
                    If UCase(ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated) = "CAST" Then
                        strInternalPartNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                        '31_08_2012   RAGAVA  Commented   Weldment
                        'ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated2) = "CAST" Then
                        '    strInternalPartNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName2)
                    End If
                    If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strInternalPartNumber) OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Casting_RE Then         '11_10_2010   RAGAVA  'anup 17-02-2011 'anup 10-03-2011
                        If Not strInternalPartNumber Is Nothing Then
                            strFileName = "STKMP" & strInternalPartNumber
                            Initialize_Purchased()
                            AddtoHashTable(VariableList.strDescription1, "ROD END CONFIGURATION")       '11_10_2010   RAGAVA
                            AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                            AddtoHashTable(VariableList.strAssyWeight, ObjClsWeldedCylinderFunctionalClass.RodEndWeight.ToString)      '11_10_2010   RAGAVA
                            GenerateCSVfiles(oHT_CSV)
                        End If
                    End If
                    'End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CrossTube_CSV()
        Try
            If Trim(ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode) = "" OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_CrossTube_BE Then           '14_10_2010   RAGAVA    'anup 18-03-2011 
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" Then
                    If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType) = "FABRICATED" OrElse UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2) = "FABRICATED" Then
                        Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart)
                        If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strInternalPartNumber) OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_CrossTube_BE Then         '11_10_2010   RAGAVA 'anup 17-02-2011 'anup 10-03-2011
                            If Not strInternalPartNumber Is Nothing Then
                                strFileName = "STKMP" & strInternalPartNumber
                                Initialize_Purchased()
                                AddtoHashTable(VariableList.strDescription1, "BASE END CROSS TUBE")       '11_10_2010   RAGAVA
                                AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                                GenerateCSVfiles(oHT_CSV)
                            End If
                        End If
                    End If
                End If
            End If
            If Trim(ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode) = "" OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_CrossTube_RE Then         '14_10_2010   RAGAVA 'anup 18-03-2011
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
                    If UCase(ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated) = "FABRICATED" Then 'OrElse UCase(ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated2) = "FABRICATED" Then       '31_08_2012   RAGAVA  Commented   Weldment
                        'Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("CROSSTUBE_ROD")
                        Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_CROSSTUBE_IFL")       '25_07_2012   RAGAVA
                        If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strInternalPartNumber) OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_CrossTube_RE Then         '11_10_2010   RAGAVA 'anup 17-02-2011  'anup 10-03-2011
                            If Not strInternalPartNumber Is Nothing Then
                                strFileName = "STKMP" & strInternalPartNumber
                                Initialize_Purchased()
                                AddtoHashTable(VariableList.strDescription1, "ROD END CROSS TUBE")       '11_10_2010   RAGAVA
                                AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                                GenerateCSVfiles(oHT_CSV)
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            'MsgBox("error in " & ex.TargetSite.ToString)
        End Try
    End Sub

    Private Sub StopTube_CSV()
        Try
            Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("Stop_tube")
            If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strInternalPartNumber) OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_StopTube Then         '11_10_2010   RAGAVA 'anup 17-02-2011'anup 10-03-2011
                If Not strInternalPartNumber Is Nothing Then
                    strFileName = "STKMP" & strInternalPartNumber
                    AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                    Initialize_Purchased()
                    Try
                        AddtoHashTable(VariableList.strDescription1, "STOP TUBE " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StopTubeLength.ToString + "-" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength.ToString)         '20_09_2010   RAGAVA
                    Catch ex As Exception
                    End Try
                    GenerateCSVfiles(oHT_CSV)
                End If
            End If
        Catch ex As Exception
            'MsgBox("error in " & ex.TargetSite.ToString)
        End Try
    End Sub

    Private Sub Lug_CSV()
        Try
            If Trim(ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode) = "" OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Lug_BE Then                '14_10_2010   RAGAVA  'anup 18-03-2011
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2 = "Fabricated" Then
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "BH" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" Then
                        If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd) <> "" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart) Then
                            'If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd) >= Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) Then
                            'Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd
                            'If strInternalPartNumber = "" Then
                            '    strInternalPartNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            'End If
                            Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart)
                            If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strInternalPartNumber) OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Lug_BE Then         '11_10_2010   RAGAVA 'anup 17-02-2011 'anup 10-03-2011
                                strFileName = "STKMM" & strInternalPartNumber    '23_08_2010   RAGAVA  STKMP to STKMM
                                AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                                AddtoHashTable(VariableList.strGLExpenseCode, "SFB")
                                AddtoHashTable(VariableList.strMajorGroup, "'" & Format(17, "000"))       '09_10_2010   RAGAVA  'anup 18-03-2011
                                AddtoHashTable(VariableList.strMinorGroup, "W51")
                                AddtoHashTable(VariableList.strMajorSales, "'" & Format(17, "000"))       '09_10_2010   RAGAVA  'anup 18-03-2011
                                AddtoHashTable(VariableList.strMinorSales, "W51")
                                AddtoHashTable(VariableList.strCatalogID, "9814.00.00.95")
                                AddtoHashTable(VariableList.strAssyWeight, ObjClsWeldedCylinderFunctionalClass.BaseEndWeight)      '24_08_2010   RAGAVA
                                AddtoHashTable(VariableList.strHarmonizationCode, "8412.90.9005")
                                AddtoHashTable(VariableList.strCustomerPartNumber, "")    '23_08_2010   RAGAVA
                                GenerateCSVfiles(oHT_CSV)
                            End If
                        End If
                    End If
                End If
            End If
            If Trim(ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode) = "" OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Lug_RE Then         '14_10_2010   RAGAVA 'anup 18-003-2011
                If ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated" Then
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "BH" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" Then
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName) Then
                            Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                            If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strInternalPartNumber) OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Lug_RE Then         '11_10_2010   RAGAVA 'anup 17-02-2011'anup 10-03-2011
                                strFileName = "STKMM" & strInternalPartNumber          '23_08_2010   RAGAVA  STKMP to STKMM
                                AddtoHashTable(VariableList.strInternalPartNumber, strInternalPartNumber)
                                AddtoHashTable(VariableList.strGLExpenseCode, "SFB")
                                AddtoHashTable(VariableList.strMajorGroup, "'" & Format(17, "000"))       '09_10_2010   RAGAVA  'anup 18-03-2011
                                AddtoHashTable(VariableList.strMinorGroup, "W51")
                                AddtoHashTable(VariableList.strMajorSales, "'" & Format(17, "000"))       '09_10_2010   RAGAVA  'anup 18-03-2011
                                AddtoHashTable(VariableList.strMinorSales, "W51")
                                AddtoHashTable(VariableList.strCatalogID, "9814.00.00.95")
                                AddtoHashTable(VariableList.strAssyWeight, ObjClsWeldedCylinderFunctionalClass.RodEndWeight)      '24_08_2010   RAGAVA
                                AddtoHashTable(VariableList.strHarmonizationCode, "8412.90.9005")
                                AddtoHashTable(VariableList.strCustomerPartNumber, "")    '23_08_2010   RAGAVA
                                GenerateCSVfiles(oHT_CSV)
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            'MsgBox("ERROR IN STKMM LUG")
        End Try
    End Sub
#End Region

#Region "CSV File Generation"

    Private Sub GenerateCSVfiles(ByVal HtList As Hashtable)

        Try
            KillExcel()
        Catch ex As Exception
        End Try
        Try
            If File.Exists("C:\CMS.xls") = False Then
                MsgBox("Create an Excel File C:\CMS.xls" & vbNewLine & "then click ok")
            End If
            Dim strfile As String = "C:\CMS.xls"
            oExlWrkBk = oExApp.Workbooks.Open(strfile)
            oExlWrkBk.EnableAutoRecover = False 'anup 16-03-2011
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
            oExlWrkBk = Nothing      '12_10_2010   RAGAVA
        Catch ex As Exception
            oExlWrkBk = Nothing      '12_10_2010   RAGAVA
            'MsgBox("Error in " & ex.TargetSite.ToString)
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
        Try
            oExApp = New Excel.Application
        Catch ex As Exception
        End Try
    End Sub
#End Region
End Class
