Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Imports System.Data
Public Class clsMaterial_CMS
    Private oHT_CSV As New Hashtable
    Private oExApp As New Excel.Application
    Private oExlWrkBk As Excel.Workbook
    Private oExlWrkSht As Excel.Worksheet
    Private oRng As Excel.Range

    Dim strFileName As String = String.Empty
    Dim strMethodType As String
    Dim strAlternateMethodNumber As String
    Dim strPlantCode As String
    Dim strPartNumber As String = String.Empty
    Dim strSequenceNumber As String
    Dim strLineNumber As String
    Dim strMaterialNumber As String = String.Empty     '
    Dim strMaterialDescription As String = String.Empty
    Dim strManufactured_Purchased As String            '
    Dim strQuantity As String           '
    Dim strUnitOfMeasure As String      '
    Dim strQuantityMultiplier As String
    Dim strRequired_ByProduct As String
    Dim strAllocation As String
    Dim strBackFlush As String
    Dim strBlowThroughPart As String                '
    Dim strMajorComponent As String
    Dim strScrapPercentage As String
    Dim strSparePartsQuantity As String
    Dim strStockLocation As String                  '
    Dim strDrawFromLoc As String
    Dim strBubbleNumber As String                   '
    Dim strItemNumberExtension As String = String.Empty
    Dim strDrawingNumber As String = String.Empty
    Dim strMajorGroupCode As String = String.Empty
    Dim strLeadTime As String
    Dim strFixUsageFlag As String
    Dim strWholeUnitConsumption As String

    Dim strRoundingCutOffDecimalValue As String
    Dim strLastAppliedECNdtl As String
    Dim strLastAppliedECNline As String
    Dim strLastAppliedECNdate As String
    Dim strLastAppliedECN As String
    Dim strECNeffectiveDate As String
    Dim strLastAppliedECNtime As String
    Public Sub New()
        InitializeParameters()
    End Sub

    Public Enum VariableList
        strMethodType
        strAlternateMethodNumber
        strPlantCode
        strPartNumber
        strSequenceNumber
        strLineNumber
        strMaterialNumber
        strMaterialDescription
        strManufactured_Purchased
        strQuantity
        strUnitOfMeasure
        strQuantityMultiplier
        strRequired_ByProduct
        strAllocation
        strBackFlush
        strBlowThroughPart
        strMajorComponent
        strScrapPercentage
        strSparePartsQuantity
        strStockLocation
        strDrawFromLoc
        strBubbleNumber
        strItemNumberExtension
        strDrawingNumber
        strMajorGroupCode
        strLeadTime
        strFixUsageFlag
        strWholeUnitConsumption
        strRoundingCutOffDecimalValue
        strLastAppliedECNdtl
        strLastAppliedECNline
        strLastAppliedECNdate
        strLastAppliedECN
        strECNeffectiveDate
        strLastAppliedECNtime
    End Enum

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

    Private Sub InitializeParameters()
        strMethodType = "1"
        AddtoHashTable(VariableList.strMethodType, strMethodType)
        strAlternateMethodNumber = "0"
        AddtoHashTable(VariableList.strAlternateMethodNumber, strAlternateMethodNumber)
        strPlantCode = "C01"
        AddtoHashTable(VariableList.strPlantCode, strPlantCode)
        strPartNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber
        AddtoHashTable(VariableList.strPartNumber, strPartNumber)
        strSequenceNumber = "10"
        AddtoHashTable(VariableList.strSequenceNumber, strSequenceNumber)
        strLineNumber = "10"
        AddtoHashTable(VariableList.strLineNumber, strLineNumber)
        strMaterialNumber = ""
        AddtoHashTable(VariableList.strMaterialNumber, strMaterialNumber)
        strMaterialDescription = ""
        AddtoHashTable(VariableList.strMaterialDescription, strMaterialDescription)
        strManufactured_Purchased = ""
        AddtoHashTable(VariableList.strManufactured_Purchased, strManufactured_Purchased)
        strQuantity = ""
        AddtoHashTable(VariableList.strQuantity, strQuantity)
        strUnitOfMeasure = ""
        AddtoHashTable(VariableList.strUnitOfMeasure, strUnitOfMeasure)
        strQuantityMultiplier = "1"
        AddtoHashTable(VariableList.strQuantityMultiplier, strQuantityMultiplier)
        strRequired_ByProduct = "R"
        AddtoHashTable(VariableList.strRequired_ByProduct, strRequired_ByProduct)
        strAllocation = "Y"
        AddtoHashTable(VariableList.strAllocation, strAllocation)
        strBackFlush = "Y"
        AddtoHashTable(VariableList.strBackFlush, strBackFlush)
        strBlowThroughPart = String.Empty      '1 for plastic bags
        AddtoHashTable(VariableList.strBlowThroughPart, strBlowThroughPart)
        strMajorComponent = "N"
        AddtoHashTable(VariableList.strMajorComponent, strMajorComponent)
        strScrapPercentage = "0"
        AddtoHashTable(VariableList.strScrapPercentage, strScrapPercentage)
        strSparePartsQuantity = "0"     '23_08_2010    RAGAVA
        AddtoHashTable(VariableList.strSparePartsQuantity, strSparePartsQuantity)
        strStockLocation = "C01BSB"     '23_08_2010  RAGAVA   "C01BW5"
        AddtoHashTable(VariableList.strStockLocation, strStockLocation)
        strDrawFromLoc = "Y"
        AddtoHashTable(VariableList.strDrawFromLoc, strDrawFromLoc)
        strBubbleNumber = "0"
        AddtoHashTable(VariableList.strBubbleNumber, strBubbleNumber)
        strItemNumberExtension = ""
        AddtoHashTable(VariableList.strItemNumberExtension, strItemNumberExtension)
        strDrawingNumber = ""
        AddtoHashTable(VariableList.strDrawingNumber, strDrawingNumber)
        strMajorGroupCode = ""
        AddtoHashTable(VariableList.strMajorGroupCode, strMajorGroupCode)
        strLeadTime = String.Empty
        AddtoHashTable(VariableList.strLeadTime, strLeadTime)
        strFixUsageFlag = ""
        AddtoHashTable(VariableList.strFixUsageFlag, strFixUsageFlag)
        strWholeUnitConsumption = String.Empty
        AddtoHashTable(VariableList.strWholeUnitConsumption, strWholeUnitConsumption)
        strRoundingCutOffDecimalValue = String.Empty
        AddtoHashTable(VariableList.strRoundingCutOffDecimalValue, strRoundingCutOffDecimalValue)
        strLastAppliedECNdtl = String.Empty
        AddtoHashTable(VariableList.strLastAppliedECNdtl, strLastAppliedECNdtl)
        strLastAppliedECNline = String.Empty
        AddtoHashTable(VariableList.strLastAppliedECNline, strLastAppliedECNline)
        strLastAppliedECNdate = String.Empty
        AddtoHashTable(VariableList.strLastAppliedECNdate, strLastAppliedECNdate)
        strLastAppliedECN = String.Empty
        AddtoHashTable(VariableList.strLastAppliedECN, strLastAppliedECN)
        strECNeffectiveDate = String.Empty
        AddtoHashTable(VariableList.strECNeffectiveDate, strECNeffectiveDate)
        strLastAppliedECNtime = String.Empty
        AddtoHashTable(VariableList.strLastAppliedECNtime, strLastAppliedECNtime)
    End Sub

    Private Function GetSelectedRow(ByVal strMaterialNumber As String) As DataRow
        GetSelectedRow = Nothing
        Try
            Dim strSQL As String
            strSQL = "Select * from CostingDetails where PartCode='" & strMaterialNumber & "'"
            GetSelectedRow = ObjClsWeldedCylinderFunctionalClass.ObjClsMIL_TieRodDataClass.MILConnectionObject.GetDataRow(strSQL)
        Catch ex As Exception
        End Try
        Return GetSelectedRow
    End Function

    Private Function GetPaintCodes(ByVal strMaterialNumber As String) As DataRow
        GetPaintCodes = Nothing
        Try
            Dim strSQL As String
            strSQL = "Select * from PaintDetails where PaintCode='" & strMaterialNumber & "'"         '23_08_2010   RAGAVA    Paint from PartCode
            'Dim objDT As Data.DataTable = MonarchConnectionObject.GetTable(strSQL)
            GetPaintCodes = ObjClsWeldedCylinderFunctionalClass.ObjClsMIL_TieRodDataClass.MILConnectionObject.GetDataRow(strSQL)
        Catch ex As Exception
        End Try
        Return GetPaintCodes
    End Function

    Public Sub Generate_BOM_CMS()
        GenerateCylinderBOM_CMS(clsAddExistingCodes.HTExistingCostingCodeList, "METHDM" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber)
        GenerateCylinderBOM_CMS(clsAddExistingCodes.HTTubeCostingCodeList, "METHDM" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT"), ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT"), "TUBE")
        GenerateCylinderBOM_CMS(clsAddExistingCodes.HTRodCostingCodeList, "METHDM" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT"), ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT"), "ROD")
    End Sub

    Private Sub GenerateCylinderBOM_CMS(ByVal HTExistingCostingCodeList As Hashtable, ByVal strFileName As String, ByVal strPartNumber As String, Optional ByVal strType As String = "WELD")
        Try
            strLineNumber = 10
            Dim strfile As String = "C:\CMS.xls"
            If File.Exists("C:\CMS.xls") = False Then
                MsgBox("Create Excel File C:\CMS.xls" & vbNewLine & "then click ok")
            End If
            oExlWrkBk = oExApp.Workbooks.Open(strfile)
            oExlWrkSht = oExlWrkBk.Worksheets("Sheet1")
            Dim strRowNum As String = "1"
            For Each oHTElement As DictionaryEntry In HTExistingCostingCodeList
                Dim oExistingListItems As clsList = oHTElement.Value
                Dim oNewList As New clsList
                strMaterialNumber = oExistingListItems.strPartCode
                strMaterialDescription = IIf(oExistingListItems.strDescription Is Nothing, "", oExistingListItems.strDescription)
                AddtoHashTable(VariableList.strPartNumber, strPartNumber)
                AddtoHashTable(VariableList.strMaterialDescription, strMaterialDescription)
                If UCase(strMaterialDescription).IndexOf("PLASTIC") <> -1 Then
                    strBlowThroughPart = "1"
                Else
                    strBlowThroughPart = ""
                End If
                AddtoHashTable(VariableList.strBlowThroughPart, strBlowThroughPart)

                '23_08_2010   RAGAVA
                If strType = "WELD" Then
                    strUnitOfMeasure = oExistingListItems.strUnit
                    AddtoHashTable(VariableList.strUnitOfMeasure, strUnitOfMeasure)
                ElseIf strType = "TUBE" Then
                    AddtoHashTable(VariableList.strUnitOfMeasure, "FT")
                ElseIf strType = "ROD" Then
                    AddtoHashTable(VariableList.strUnitOfMeasure, "LB")
                End If
                'Till  Here
                strBubbleNumber = "0"      '23_08_2010    RAGAVA
                Dim blnPaint As Boolean = False       '07_09_2010   RAGAVA
                Dim strPrimerCode, strPrimerCatalystCode, strPaintActivatorCode As String         '07_09_2010   RAGAVA
                Dim dr As DataRow
                'Paint Code 
                If strMaterialNumber.StartsWith("270") = True OrElse UCase(strMaterialDescription).IndexOf("PLASTIC") <> -1 OrElse UCase(strMaterialDescription).IndexOf("PIN ") <> -1 OrElse UCase(strMaterialDescription).IndexOf("DECAL ") <> -1 OrElse UCase(strMaterialDescription).IndexOf("LABEL") <> -1 Then        '20_09_2010   RAGAVA  Extended If condition
                    dr = GetPaintCodes(strMaterialNumber)
                    strStockLocation = "C01BPC"
                    blnPaint = True    '07_09_2010   RAGAVA
                    If Not dr Is Nothing Then
                        '07_09_2010    RAGAVA
                        'AddtoHashTable(VariableList.strMaterialNumber, strMaterialNumber & "," & dr("PrimerCode") & "," & dr("PrimerCatalystCode") & "," & dr("PaintActivatorCode"))
                        AddtoHashTable(VariableList.strMaterialNumber, strMaterialNumber)
                        strPrimerCode = dr("PrimerCode")
                        strPrimerCatalystCode = dr("PrimerCatalystCode")
                        strPaintActivatorCode = dr("PaintActivatorCode")
                        'Till   Here
                    End If
                    AddtoHashTable(VariableList.strSequenceNumber, "30")       '23_08_2010   RAGAVA
                Else
                    '23_08_2010   RAGAVA
                    If strMaterialDescription.StartsWith("@") Then
                        strStockLocation = "C01BSB"
                    Else
                        strStockLocation = "C01BW5"
                    End If
                    AddtoHashTable(VariableList.strMaterialNumber, strMaterialNumber)     '24_08_2010    RAGAVA
                    'Till   Here
                    dr = GetSelectedRow(strMaterialNumber)
                    AddtoHashTable(VariableList.strSequenceNumber, "10")       '23_08_2010   RAGAVA

                    If Not dr Is Nothing Then
                        strManufactured_Purchased = dr("Purchased_Manfractured").ToString
                    End If
                    If Not dr Is Nothing Then
                        strBubbleNumber = IIf(dr("ReferenceNumber") Is Nothing, "0", dr("ReferenceNumber"))           '23_08_2010    RAGAVA  "0" from ""
                    End If
                    If strBubbleNumber = "" Then
                        strBubbleNumber = "0"       '23_08_2010   RAGAVA
                    End If
                End If
                AddtoHashTable(VariableList.strStockLocation, strStockLocation)

                If strManufactured_Purchased = "P" Then
                    strManufactured_Purchased = "R"
                End If
                AddtoHashTable(VariableList.strManufactured_Purchased, strManufactured_Purchased)
                strQuantity = Math.Round(oExistingListItems.dblQuantity, 4)      '24_08_2010    RAGAVA   precision 4 digits
                AddtoHashTable(VariableList.strQuantity, strQuantity)
                '23_08_2010   RAGAVA
                'strUnitOfMeasure = oExistingListItems.strUnit
                'AddtoHashTable(VariableList.strUnitOfMeasure, strUnitOfMeasure)
                'Till  Here

                Dim PaintCount As Integer = 0          '07_09_2010    RAGAVA
PaintLoop:      '07_09_2010   RAGAVA
                AddtoHashTable(VariableList.strLineNumber, strLineNumber)        '23_08_2010   RAGAVA
                AddtoHashTable(VariableList.strBubbleNumber, strBubbleNumber)
                Dim bln2ndloop As Boolean = False
                Dim bln3rdLoop As Boolean = False
                Dim i As Integer = 65
                Dim icount As Integer = 0     '23_08_2010  RAGAVA  1 to 0
                For icount = 0 To oHT_CSV.Keys.Count
                    Dim ch As String = Convert.ToChar(i)
                    If bln2ndloop = True Then
                        ch = "A" & ch
                    ElseIf bln3rdLoop = True Then
                        ch = "B" & ch
                    End If
                    oRng = oExlWrkSht.Range(ch & strRowNum)
                    oRng.Value2 = oHT_CSV(icount.ToString)
                    If ch = "Z" Then
                        i = 64
                        bln2ndloop = True
                    ElseIf ch = "AZ" Then
                        bln3rdLoop = True
                        i = 64
                    End If
                    i = i + 1
                Next
                strRowNum = (Val(strRowNum) + 1).ToString
                strLineNumber = (Val(strLineNumber) + 10).ToString
                '07_09_2010   RAGAVA
                If blnPaint Then
                    PaintCount = PaintCount + 1
                    If PaintCount < 2 Then
                        AddtoHashTable(VariableList.strMaterialNumber, strPrimerCode)
                    ElseIf PaintCount < 3 Then
                        AddtoHashTable(VariableList.strMaterialNumber, strPrimerCatalystCode)
                    ElseIf PaintCount < 4 Then
                        AddtoHashTable(VariableList.strMaterialNumber, strPaintActivatorCode)
                        blnPaint = False
                    End If
                    GoTo PaintLoop
                End If
                    'Till   Here
                    'AddtoHashTable(VariableList.strLineNumber, strLineNumber)
            Next
            oExlWrkBk.SaveAs(ObjClsWeldedCylinderFunctionalClass.strCMSfileLocation & "\" & strFileName & ".csv", XlFileFormat.xlCSVMSDOS)
            'oExApp.Workbooks.Close()
        Catch ex As Exception
        End Try
    End Sub
End Class

Public Class clsPlant_Part_Master_CMS
    Private oHT_CSV As New Hashtable

    Private oExApp As New Excel.Application
    Private oExlWrkBk As Excel.Workbook
    Private oExlWrkSht As Excel.Worksheet
    Private oRng As Excel.Range
    Dim strFileName As String = String.Empty

    Dim strInternalPartNumber As String = String.Empty       'Condition
    Dim strPlantCode As String = "C01"
    Dim strUnitOfIssue As String = "EA"
    Dim strReplenishmentType As String = "1"
    Dim strSourcePlant As String = String.Empty
    Dim strVendorLeadTime As String = String.Empty
    Dim strMinimumTransferTime As String = "1"
    Dim strTransferPolicy As String = "1"
    Dim strTransferMultiplier As String = "1"
    Dim strAvailabilityInquiryDisplayUnit As String = String.Empty
    Dim strStatus As String = "I"   '23_08_2010   RAGAVA  1 to I
    Dim strInactiveReasonCode As String = "DM"
    Dim strMinimumQuantity As String = "0"
    Dim strMaximumQuantity As String = "0"
    Dim strEstimatedAnnualVolume As String = "0"
    Dim strLotNumber As String = "N"
    Dim strCreateLot As String = "N"
    Dim strMaintainLotBalance As String = "N"
    Dim strValidateLotNumbers As String = "N"
    Dim strSerializedMandatory As String = "N"
    Dim strABCcode As String = String.Empty
    Dim strCycleCountStartDate As String = String.Empty
    Dim strCycleCountsPerYear As String = String.Empty

    Dim strSellablePart As String = "Y"
    Dim strRepriceLock As String = String.Empty
    Dim strPricingUnit As String = "EA"
    Dim strMinimumOrderQuantity As String = "1"
    Dim strDefaultContainer As String = String.Empty
    Dim strDefaultPalletContainer As String = String.Empty
    Dim strStandardPackSize As String = String.Empty
    Dim strStandardPackSizeUOM As String = String.Empty
    Dim strMasterPackSize As String = String.Empty
    Dim strMasterPackSizeUOM As String = String.Empty
    Dim strShipFromLocation As String = String.Empty
    Dim strAllocationTimeFence As String = "30"
    Dim strKitCode As String = String.Empty
    Dim strDirectBuyFlag As String = "3"
    Dim strDirectBuyActionFlag As String = "1"
    Dim strSCDPart As String = "2"
    Dim strStandAlonePrintFlag As String = "N"
    Dim strStandAloneNumberOfCopies As String = String.Empty
    Dim strStandAloneLabelFormatCode As String = String.Empty
    Dim strStandAlonePrintFlag_PR As String = "N"
    Dim strStandAloneNumberOfCopies_PR As String = String.Empty
    Dim strStandAloneLabelFormatCode_PR As String = String.Empty
    Dim strStandAlonePrintFlag_CP As String = "N"
    Dim strStandAloneNumberOfCopies_CP As String = String.Empty
    Dim strStandAloneLabelFormatCode_CP As String = String.Empty
    Dim strStandAloneNumberOfCopies_Shipping As String = String.Empty
    Dim strStandAloneLabelFormatCode_Shipping As String = String.Empty
    Dim strMasterPrintFlag As String = "N"
    Dim strMasterNumberOfCopies As String = String.Empty
    Dim strMasterLabelFormatCode As String = String.Empty
    Dim strMasterPrintFlag_CP As String = "N"
    Dim strMasterNumberOfCopies_CP As String = String.Empty
    Dim strMasterLabelFormatCode_CP As String = String.Empty
    Dim strMasterPrintFlag_Shipping As String = "N"
    Dim strMasterNumberOfCopies_Shipping As String = String.Empty
    Dim strMasterLabelFormatCode_Shipping As String = String.Empty
    Dim strCreateSingleMasterSerial As String = "2"
    Dim strBuyerCode As String = String.Empty
    Dim strPlannerCode As String = "WC"
    Dim strReceivingContainer As String = String.Empty
    Dim strReceivingPackSize As String = String.Empty
    Dim strReceivingPackSizeUOM As String = String.Empty

    Dim strReceiveToLocation As String = String.Empty            'BPC - Cyld & BW5 - Tube & Rod and BS1 - Lug
    Dim strDrawFromLocation As String = String.Empty

    Dim strInspectionProcedure As String = String.Empty    'ISIR - Cyld & PROTO - Manfactured
    Dim strMaterialPreparationLeadTime As String = String.Empty   'condition

    Dim strRequisitionerCode As String = String.Empty
    Dim strRequisitionsRequireApproval As String = String.Empty
    Dim strCountryOfOrigin As String = "CA"
    Dim strProvinceOfOrigin As String = String.Empty
    Dim strPurchaseOrderUnit As String = "EA"
    Dim strApprovedSupplierRequired As String = "2"
    Dim strGenerateCOGS As String = "2"

    Dim strScheduleType As String = String.Empty   'blank for Cyld & B - components

    Dim strOptimumRun As String = "SRQ"    'condition
    Dim strMinimumRun As String = "1"
    Dim strProductionMultiplier As String = "0"
    Dim strShrinkageFactor As String = "0"
    Dim strManufaturingLeadTime As String = String.Empty
    Dim strLongestLeadTime As String = String.Empty
    Dim strOrderReleaseLeadTime As String = "1"
    Dim strOrderPolicy As String = "1"
    Dim strSalesForcastTimeFence As String = "90"
    Dim strSecuredTimeFence As String = String.Empty
    Dim strOrderLookAhead As String = String.Empty
    Dim strLoadingTimeFence As String = String.Empty
    Dim strMRP_AutoReleaseProduction As String = "N"
    Dim strRepetitiveControl As String = "N"
    Dim strPercentComplete As String = "100"
    Dim strBalance As String = String.Empty
    Dim strCommonMaterial As String = String.Empty
    Dim strRestrictCurrentStandard As String = String.Empty
    Dim strMaterialIssueLocation As String = String.Empty
    Dim strMattecPart As String = String.Empty
    Dim strMattecMaterialType As String = String.Empty
    Dim strStorageClass As String = String.Empty
    Dim strvelocityCode As String = String.Empty
    Dim strNumberOfReceivingPallet As String = String.Empty
    Dim strReceivingPackComment As String = String.Empty
    Dim strNumberOfMasterPackPerPallet As String = String.Empty
    Dim strMasterPackComment As String = String.Empty

    Private Enum VariableList
        strInternalPartNumber
        strPlantCode
        strUnitOfIssue
        strReplenishmentType
        strSourcePlant
        strVendorLeadTime
        strMinimumTransferTime
        strTransferPolicy
        strTransferMultiplier
        strAvailabilityInquiryDisplayUnit
        strStatus
        strInactiveReasonCode
        strMinimumQuantity
        strMaximumQuantity
        strEstimatedAnnualVolume
        strLotNumber
        strCreateLot
        strMaintainLotBalance
        strValidateLotNumbers
        strSerializedMandatory
        strABCcode
        strCycleCountStartDate
        strCycleCountsPerYear
        strSellablePart
        strRepriceLock
        strPricingUnit
        strMinimumOrderQuantity
        strDefaultContainer
        strDefaultPalletContainer
        strStandardPackSize
        strStandardPackSizeUOM
        strMasterPackSize
        strMasterPackSizeUOM
        strShipFromLocation
        strAllocationTimeFence
        strKitCode
        strDirectBuyFlag
        strDirectBuyActionFlag
        strSCDPart
        strStandAlonePrintFlag
        strStandAloneNumberOfCopies
        strStandAloneLabelFormatCode
        strStandAlonePrintFlag_PR
        strStandAloneNumberOfCopies_PR
        strStandAloneLabelFormatCode_PR
        strStandAlonePrintFlag_CP
        strStandAloneNumberOfCopies_CP
        strStandAloneLabelFormatCode_CP
        strStandAloneNumberOfCopies_Shipping
        strStandAloneLabelFormatCode_Shipping
        strMasterPrintFlag
        strMasterNumberOfCopies
        strMasterLabelFormatCode
        strMasterPrintFlag_CP
        strMasterNumberOfCopies_CP
        strMasterLabelFormatCode_CP
        strMasterPrintFlag_Shipping
        strMasterNumberOfCopies_Shipping
        strMasterLabelFormatCode_Shipping
        strCreateSingleMasterSerial
        strBuyerCode
        strPlannerCode
        strReceivingContainer
        strReceivingPackSize
        strReceivingPackSizeUOM
        strReceiveToLocation
        strDrawFromLocation
        strInspectionProcedure
        strMaterialPreparationLeadTime
        strRequisitionerCode
        strRequisitionsRequireApproval
        strCountryOfOrigin
        strProvinceOfOrigin
        strPurchaseOrderUnit
        strApprovedSupplierRequired
        strGenerateCOGS
        strScheduleType
        strOptimumRun
        strMinimumRun
        strProductionMultiplier
        strShrinkageFactor
        strManufaturingLeadTime
        strLongestLeadTime
        strOrderReleaseLeadTime
        strOrderPolicy
        strSalesForcastTimeFence
        strSecuredTimeFence
        strOrderLookAhead
        strLoadingTimeFence
        strMRP_AutoReleaseProduction
        strRepetitiveControl
        strPercentComplete
        strBalance
        strCommonMaterial
        strRestrictCurrentStandard
        strMaterialIssueLocation
        strMattecPart
        strMattecMaterialType
        strStorageClass
        strvelocityCode
        strNumberOfReceivingPallet
        strReceivingPackComment
        strNumberOfMasterPackPerPallet
        strMasterPackComment
    End Enum

    Public Sub New()
        InitializeParameters()
    End Sub

    Private Sub InitializeParameters()
        AddtoHashTable(VariableList.strInternalPartNumber, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber)
        AddtoHashTable(VariableList.strPlantCode, strPlantCode)
        AddtoHashTable(VariableList.strUnitOfIssue, strUnitOfIssue)
        AddtoHashTable(VariableList.strReplenishmentType, strReplenishmentType)
        AddtoHashTable(VariableList.strSourcePlant, strSourcePlant)
        AddtoHashTable(VariableList.strVendorLeadTime, strVendorLeadTime)
        AddtoHashTable(VariableList.strMinimumTransferTime, strMinimumTransferTime)
        AddtoHashTable(VariableList.strTransferPolicy, strTransferPolicy)
        AddtoHashTable(VariableList.strTransferMultiplier, strTransferMultiplier)
        AddtoHashTable(VariableList.strAvailabilityInquiryDisplayUnit, strAvailabilityInquiryDisplayUnit)
        AddtoHashTable(VariableList.strStatus, strStatus)
        AddtoHashTable(VariableList.strInactiveReasonCode, strInactiveReasonCode)
        AddtoHashTable(VariableList.strMinimumQuantity, strMinimumQuantity)
        AddtoHashTable(VariableList.strMaximumQuantity, strMaximumQuantity)
        AddtoHashTable(VariableList.strEstimatedAnnualVolume, strEstimatedAnnualVolume)
        AddtoHashTable(VariableList.strLotNumber, strLotNumber)
        AddtoHashTable(VariableList.strCreateLot, strCreateLot)
        AddtoHashTable(VariableList.strMaintainLotBalance, strMaintainLotBalance)
        AddtoHashTable(VariableList.strValidateLotNumbers, strValidateLotNumbers)
        AddtoHashTable(VariableList.strSerializedMandatory, strSerializedMandatory)
        AddtoHashTable(VariableList.strABCcode, strABCcode)
        AddtoHashTable(VariableList.strCycleCountStartDate, strCycleCountStartDate)
        AddtoHashTable(VariableList.strCycleCountsPerYear, strCycleCountsPerYear)
        AddtoHashTable(VariableList.strSellablePart, strSellablePart)
        AddtoHashTable(VariableList.strRepriceLock, strRepriceLock)
        AddtoHashTable(VariableList.strPricingUnit, strPricingUnit)
        AddtoHashTable(VariableList.strMinimumOrderQuantity, strMinimumOrderQuantity)
        AddtoHashTable(VariableList.strDefaultContainer, strDefaultContainer)
        AddtoHashTable(VariableList.strDefaultPalletContainer, strDefaultPalletContainer)
        AddtoHashTable(VariableList.strStandardPackSize, strStandardPackSize)
        AddtoHashTable(VariableList.strStandardPackSizeUOM, strStandardPackSizeUOM)
        AddtoHashTable(VariableList.strMasterPackSize, strMasterPackSize)
        AddtoHashTable(VariableList.strMasterPackSizeUOM, strMasterPackSizeUOM)
        AddtoHashTable(VariableList.strShipFromLocation, strShipFromLocation)
        AddtoHashTable(VariableList.strAllocationTimeFence, strAllocationTimeFence)
        AddtoHashTable(VariableList.strKitCode, strKitCode)
        AddtoHashTable(VariableList.strDirectBuyFlag, strDirectBuyFlag)
        AddtoHashTable(VariableList.strDirectBuyActionFlag, strDirectBuyActionFlag)
        AddtoHashTable(VariableList.strSCDPart, strSCDPart)
        AddtoHashTable(VariableList.strStandAlonePrintFlag, strStandAlonePrintFlag)
        AddtoHashTable(VariableList.strStandAloneNumberOfCopies, strStandAloneNumberOfCopies)
        AddtoHashTable(VariableList.strStandAloneLabelFormatCode, strStandAloneLabelFormatCode)
        AddtoHashTable(VariableList.strStandAlonePrintFlag_PR, strStandAlonePrintFlag_PR)
        AddtoHashTable(VariableList.strStandAloneNumberOfCopies_PR, strStandAloneNumberOfCopies_PR)
        AddtoHashTable(VariableList.strStandAloneLabelFormatCode_PR, strStandAloneLabelFormatCode_PR)
        AddtoHashTable(VariableList.strStandAlonePrintFlag_CP, strStandAlonePrintFlag_CP)
        AddtoHashTable(VariableList.strStandAloneNumberOfCopies_CP, strStandAloneNumberOfCopies_CP)
        AddtoHashTable(VariableList.strStandAloneLabelFormatCode_CP, strStandAloneLabelFormatCode_CP)
        AddtoHashTable(VariableList.strStandAloneNumberOfCopies_Shipping, strStandAloneNumberOfCopies_Shipping)
        AddtoHashTable(VariableList.strStandAloneLabelFormatCode_Shipping, strStandAloneLabelFormatCode_Shipping)
        AddtoHashTable(VariableList.strMasterPrintFlag, strMasterPrintFlag)
        AddtoHashTable(VariableList.strMasterNumberOfCopies, strMasterNumberOfCopies)
        AddtoHashTable(VariableList.strMasterLabelFormatCode, strMasterLabelFormatCode)
        AddtoHashTable(VariableList.strMasterPrintFlag_CP, strMasterPrintFlag_CP)
        AddtoHashTable(VariableList.strMasterNumberOfCopies_CP, strMasterNumberOfCopies_CP)
        AddtoHashTable(VariableList.strMasterLabelFormatCode_CP, strMasterLabelFormatCode_CP)
        AddtoHashTable(VariableList.strMasterPrintFlag_Shipping, strMasterPrintFlag_Shipping)
        AddtoHashTable(VariableList.strMasterNumberOfCopies_Shipping, strMasterNumberOfCopies_Shipping)
        AddtoHashTable(VariableList.strMasterLabelFormatCode_Shipping, strMasterLabelFormatCode_Shipping)
        AddtoHashTable(VariableList.strCreateSingleMasterSerial, strCreateSingleMasterSerial)
        AddtoHashTable(VariableList.strBuyerCode, strBuyerCode)
        AddtoHashTable(VariableList.strPlannerCode, strPlannerCode)
        AddtoHashTable(VariableList.strReceivingContainer, strReceivingContainer)
        AddtoHashTable(VariableList.strReceivingPackSize, strReceivingPackSize)
        AddtoHashTable(VariableList.strReceivingPackSizeUOM, strReceivingPackSizeUOM)

        strReceiveToLocation = "BPC"            'BPC - Cyld & BW5 - Tube & Rod and BS1 - Lug
        AddtoHashTable(VariableList.strReceiveToLocation, strReceiveToLocation)
        AddtoHashTable(VariableList.strDrawFromLocation, strDrawFromLocation)

        '20_09_2010    RAGAVA
        If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CustomerName_ContractDetails).IndexOf("CNH") <> -1 Then
            strInspectionProcedure = "ISIR"
        Else
            strInspectionProcedure = "PROTO"
        End If
        'strInspectionProcedure = "ISIR"   'ISIR - Cyld & PROTO - Manfactured
        'Till   Here

        AddtoHashTable(VariableList.strInspectionProcedure, strInspectionProcedure)

        If ObjClsWeldedCylinderFunctionalClass.ObjFrmGenerate.ChkPaint.Checked = False Then
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2.5 Then
                strMaterialPreparationLeadTime = 8
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 2.75 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 3 Then
                strMaterialPreparationLeadTime = 9
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 3.5 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 4 Then
                strMaterialPreparationLeadTime = 10
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter > 4 Then
                strMaterialPreparationLeadTime = 11
            End If
        Else
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2.5 Then
                strMaterialPreparationLeadTime = 10
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 2.75 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 3 Then
                strMaterialPreparationLeadTime = 10
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 3.5 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 4 Then
                strMaterialPreparationLeadTime = 11
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter > 4 Then
                strMaterialPreparationLeadTime = 11
            End If
        End If
        AddtoHashTable(VariableList.strMaterialPreparationLeadTime, strMaterialPreparationLeadTime)
        AddtoHashTable(VariableList.strRequisitionerCode, strRequisitionerCode)
        AddtoHashTable(VariableList.strRequisitionsRequireApproval, strRequisitionsRequireApproval)
        AddtoHashTable(VariableList.strCountryOfOrigin, strCountryOfOrigin)
        AddtoHashTable(VariableList.strProvinceOfOrigin, strProvinceOfOrigin)
        AddtoHashTable(VariableList.strPurchaseOrderUnit, strPurchaseOrderUnit)
        AddtoHashTable(VariableList.strApprovedSupplierRequired, strApprovedSupplierRequired)
        AddtoHashTable(VariableList.strGenerateCOGS, strGenerateCOGS)

        strScheduleType = String.Empty   'blank for Cyld & B - components
        AddtoHashTable(VariableList.strScheduleType, strScheduleType)
        strOptimumRun = ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.txtStandardRunQuantity.Text
        AddtoHashTable(VariableList.strOptimumRun, strOptimumRun)
        AddtoHashTable(VariableList.strMinimumRun, strMinimumRun)
        AddtoHashTable(VariableList.strProductionMultiplier, strProductionMultiplier)
        AddtoHashTable(VariableList.strShrinkageFactor, strShrinkageFactor)
        AddtoHashTable(VariableList.strManufaturingLeadTime, strManufaturingLeadTime)
        AddtoHashTable(VariableList.strLongestLeadTime, strLongestLeadTime)
        AddtoHashTable(VariableList.strOrderReleaseLeadTime, strOrderReleaseLeadTime)
        AddtoHashTable(VariableList.strOrderPolicy, strOrderPolicy)
        AddtoHashTable(VariableList.strSalesForcastTimeFence, strSalesForcastTimeFence)
        AddtoHashTable(VariableList.strSecuredTimeFence, strSecuredTimeFence)
        AddtoHashTable(VariableList.strOrderLookAhead, strOrderLookAhead)
        AddtoHashTable(VariableList.strLoadingTimeFence, strLoadingTimeFence)
        AddtoHashTable(VariableList.strMRP_AutoReleaseProduction, strMRP_AutoReleaseProduction)
        AddtoHashTable(VariableList.strRepetitiveControl, strRepetitiveControl)
        AddtoHashTable(VariableList.strPercentComplete, strPercentComplete)
        AddtoHashTable(VariableList.strBalance, strBalance)
        AddtoHashTable(VariableList.strCommonMaterial, strCommonMaterial)
        AddtoHashTable(VariableList.strRestrictCurrentStandard, strRestrictCurrentStandard)
        AddtoHashTable(VariableList.strMaterialIssueLocation, strMaterialIssueLocation)
        AddtoHashTable(VariableList.strMattecPart, strMattecPart)
        AddtoHashTable(VariableList.strMattecMaterialType, strMattecMaterialType)
        AddtoHashTable(VariableList.strStorageClass, strStorageClass)
        AddtoHashTable(VariableList.strvelocityCode, strvelocityCode)
        AddtoHashTable(VariableList.strNumberOfReceivingPallet, strNumberOfReceivingPallet)
        AddtoHashTable(VariableList.strReceivingPackComment, strReceivingPackComment)
        AddtoHashTable(VariableList.strNumberOfMasterPackPerPallet, strNumberOfMasterPackPerPallet)
        AddtoHashTable(VariableList.strMasterPackComment, strMasterPackComment)
    End Sub

    Private Sub Initialize_Tube()
        AddtoHashTable(VariableList.strInternalPartNumber, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT"))
        strScheduleType = "B"
        AddtoHashTable(VariableList.strScheduleType, strScheduleType)
        strMaterialPreparationLeadTime = "3"
        AddtoHashTable(VariableList.strMaterialPreparationLeadTime, strMaterialPreparationLeadTime)

        strReceiveToLocation = "BW5"
        AddtoHashTable(VariableList.strReceiveToLocation, strReceiveToLocation)
 
        strInspectionProcedure = "PROTO"

        AddtoHashTable(VariableList.strInspectionProcedure, strInspectionProcedure)
    End Sub

    Private Sub Initialize_Rod()
        AddtoHashTable(VariableList.strInternalPartNumber, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT"))
        strScheduleType = "B"
        AddtoHashTable(VariableList.strScheduleType, strScheduleType)
        strMaterialPreparationLeadTime = "3"
        AddtoHashTable(VariableList.strMaterialPreparationLeadTime, strMaterialPreparationLeadTime)

        strReceiveToLocation = "BW5"
        AddtoHashTable(VariableList.strReceiveToLocation, strReceiveToLocation)
        strInspectionProcedure = "PROTO"
        AddtoHashTable(VariableList.strInspectionProcedure, strInspectionProcedure)
    End Sub


    Public Sub GenerateCylinder_STKA_CMS()
        Try
            InitializeParameters()
            'Welded Cylinder Assy
            strFileName = "STKA" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber
            GenerateCSVfiles(oHT_CSV)
            'Tube Weldment
            strFileName = "STKA" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT")
            Initialize_Tube()
            GenerateCSVfiles(oHT_CSV)
            'Rod Weldment
            strFileName = "STKA" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT")
            Initialize_Rod()
            GenerateCSVfiles(oHT_CSV)
        Catch ex As Exception

        End Try
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

#Region "CSV File Generation"
    Private Sub GenerateCSVfiles(ByVal HtList As Hashtable)
        Try
            'oExApp.Visible = False
            If File.Exists("C:\CMS.xls") = False Then
                MsgBox("Create Excel File C:\CMS.xls" & vbNewLine & "then click ok")
            End If
            Dim strfile As String = "C:\CMS.xls"
            oExlWrkBk = oExApp.Workbooks.Open(strfile)
            oExlWrkSht = oExlWrkBk.Worksheets("Sheet1")
            Dim blnsndloop As Boolean = False
            Dim blnThirdLoop As Boolean = False
            Dim blnFourthLoop As Boolean = False
            Dim blnFifthLoop As Boolean = False
            Dim blnSixthLoop As Boolean = False
            Dim i As Integer = 65
            Dim icount As Integer = 0
            For icount = 0 To oHT_CSV.Keys.Count
                Dim ch As String = Convert.ToChar(i)
                If blnsndloop = True Then
                    ch = "A" & ch
                ElseIf blnThirdLoop = True Then
                    ch = "B" & ch
                ElseIf blnFourthLoop = True Then
                    ch = "C" & ch
                ElseIf blnFifthLoop = True Then
                    ch = "D" & ch
                ElseIf blnSixthLoop = True Then
                    ch = "E" & ch
                End If
                oRng = oExlWrkSht.Range(ch & "1")
                oRng.Value2 = oHT_CSV(icount.ToString)
                If ch = "Z" Then
                    i = 64
                    blnsndloop = True
                ElseIf ch = "AZ" Then
                    blnThirdLoop = True
                    blnsndloop = False
                    i = 64
                ElseIf ch = "BZ" Then
                    blnFourthLoop = True
                    blnThirdLoop = False
                    i = 64
                ElseIf ch = "CZ" Then
                    blnFifthLoop = True
                    blnFourthLoop = False
                    i = 64
                ElseIf ch = "DZ" Then
                    blnSixthLoop = True
                    blnFifthLoop = False
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