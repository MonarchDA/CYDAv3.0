Imports Microsoft.Win32.Registry
Imports Microsoft.Win32.RegistryKey
Imports System.Diagnostics.Process
Imports Microsoft.Office.Interop
Imports Microsoft.Win32
Imports System.IO
Public Class clsCostingExcelFunctionality

#Region "Private Variables"

    Private _strCurrentWorkingDirectory As String = System.Environment.CurrentDirectory

    Private _strMotherExcelPath As String = _strCurrentWorkingDirectory + "\WeldedCosting_Master.xls"

    Private _strchildExcelPath As String = _strCurrentWorkingDirectory + "\Reports\" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber + "Costing.xls"

    Private _oExApplication As Excel.Application

    Private _oExWorkbook As Excel.Workbook

    Private _oExcelSheet_MainAssembly As Excel.Worksheet

    Private _oExcelSheet_NewTube As Excel.Worksheet

    Private _oExcelSheet_NewRod As Excel.Worksheet

    Private _oExcelSheet_BELug As Excel.Worksheet

    Private _oExcelSheet_RELug As Excel.Worksheet

    Private _oClsRulesSequence As clsRulesSequence

    Private _oClsRodRulesSequence As clsRodRulesSequence

    'A0308: ANUP 03-08-2010 02.28pm
    ' "Assembly and Oil test Variables"
    Private _oExcelSheet_AssemblyRunStandard As Excel.Worksheet

    Private _oExcelSheet_OilTestRunStandard As Excel.Worksheet

    Private _dblFirstPortOrientation_Base_Rod As Double

    Private _dblSecondPortOrientation_Base_Rod As Double

    Private _dblFirstAndSecondPortOrientation_Base As Double

    Private _dblFirstAndSecondPortOrientation_Rod As Double

    Private _oExcelSheet_DrillingOne_Rod As Excel.Worksheet

    Private _oExcelSheet_DrillingTwo_Rod As Excel.Worksheet

    Private _strCodeNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber

    Private _strTubeSheetName As String

    Private _strRodSheetName As String

    Private _strBELugSheetName As String

    Private _strRELugSheetName As String

    Private _dblSRQ As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StandardRunQuantity


#End Region

#Region "Enum"

    'Public Enum StuctureElements
    '    WorkCenter = 0
    '    SetupCost = 1
    '    RunCost = 2
    '    LabourCost = 3
    '    FixedBurdenCost = 4
    '    VariableBurdenCost = 5
    'End Enum

    'Public Enum CylinderExcelSheetElments
    '    SNo = 0
    '    Material = 1
    '    Description = 2
    '    QuantityPerUnit = 3
    '    Units = 4
    '    StandardUnitCost = 5
    'End Enum

#End Region

#Region "Sub Procedures "

    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable
    Public Function Costingfunctionality() As Boolean
        Costingfunctionality = False
        Try
            If CreateExcelObjects() Then
                If DropDataToExcel() Then
                    If SaveExcel() Then
                        Costingfunctionality = True
                    End If
                End If
            End If
        Catch ex As Exception
            Costingfunctionality = False
        End Try
    End Function

#Region " Create Excel Functions"

    Private Function CreateExcelObjects() As Boolean
        CreateExcelObjects = False
        Try
            If CheckForExcel() Then
                If CopyTheMasterFile() Then
                    If CreateExcel() Then
                        CreateExcelObjects = True
                    End If
                End If
            End If
        Catch ex As Exception
            CreateExcelObjects = False
        End Try
    End Function

    Private Function CheckForExcel() As Boolean
        CheckForExcel = True
        Dim strSubKey As String = "Excel.Application"
        Dim oKey As RegistryKey = Registry.ClassesRoot
        Dim oSubKey As RegistryKey = oKey.OpenSubKey("Word.Application")
        If Not IsNothing(oSubKey) Then
            oKey.Close()
            Return True
        Else
            MessageBox.Show("Error with Excel" + vbCrLf + "Kindly check whether the Excel is installed" + vbCrLf + _
             "You can proceed with application but, Excel report will not be generated", "Error with Excel", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
            Return False
        End If
    End Function

    Private Function CopyTheMasterFile() As Boolean
        CopyTheMasterFile = False
        Dim blnIsProcessSuccessfull As Boolean = False
        Dim sErrorMessage As String = "Report Master file does not exist"
        Try
            ' This function checks if the master report format exists
            If IsMasterReportFileExists() Then
                Try
                    ' Check if file already exists
                    If File.Exists(_strchildExcelPath) Then
                        If Not IsNothing(_oExApplication) Then
                            _oExApplication = Nothing
                        End If
                        ' Delete the existing file first
                        File.Delete(_strchildExcelPath)
                    End If
                    File.Copy(_strMotherExcelPath, _strchildExcelPath)
                    CopyTheMasterFile = True
                    blnIsProcessSuccessfull = True
                Catch oException As Exception
                    sErrorMessage = "Unable to copy the source file" + vbCrLf + vbCrLf + oException.Message
                End Try
            End If
            If Not blnIsProcessSuccessfull Then
                CopyTheMasterFile = False
                MessageBox.Show(sErrorMessage, "Error in file creation", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Return blnIsProcessSuccessfull
        Catch ex As Exception
            CopyTheMasterFile = False
        End Try
    End Function

    Private Function IsMasterReportFileExists() As Boolean
        IsMasterReportFileExists = File.Exists(_strMotherExcelPath)
    End Function

    Public Function CreateExcel() As Boolean
        CreateExcel = True
        Try
            _oExApplication = New Excel.Application
            _oExApplication.Visible = False
            _oExWorkbook = _oExApplication.Workbooks.Open(_strchildExcelPath)
            _oExWorkbook.EnableAutoRecover = False 'anup 14-03-2011
            _oExcelSheet_MainAssembly = _oExApplication.Sheets(1)
            _oExcelSheet_NewTube = _oExApplication.Sheets(2)
            _oExcelSheet_NewRod = _oExApplication.Sheets(3)
            _oExcelSheet_BELug = _oExApplication.Sheets(4)
            _oExcelSheet_RELug = _oExApplication.Sheets(5)
            _oExcelSheet_AssemblyRunStandard = _oExApplication.Sheets(6)
            _oExcelSheet_OilTestRunStandard = _oExApplication.Sheets(7)
            _oExcelSheet_DrillingOne_Rod = _oExApplication.Sheets(8)
            _oExcelSheet_DrillingTwo_Rod = _oExApplication.Sheets(9)
        Catch ex As Exception
            CreateExcel = False
            MessageBox.Show("Unable to open Excel sheet", "Information", MessageBoxButtons.OK, _
            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Function

    Private Function SaveExcel() As Boolean
        SaveExcel = False
        Try
            _oExWorkbook.Save()
            For Each oProcess As Process In Process.GetProcessesByName("Excel")
                oProcess.Kill()
                GC.Collect()
                System.Threading.Thread.Sleep(1000)
            Next

            'TODO:Sunny 19-04-10 12:20pm
            If Not Directory.Exists("W:\WELDED\COSTING\") Then
                Directory.CreateDirectory("W:\WELDED\COSTING\")
            End If
            If File.Exists(_strchildExcelPath) Then
                If File.Exists("W:\WELDED\COSTING\" + _strCodeNumber + "_Costing.xls") Then
                    File.Delete("W:\WELDED\COSTING\" + _strCodeNumber + "_Costing.xls")
                End If
                File.Move(_strchildExcelPath, "W:\WELDED\COSTING\" + _strCodeNumber + "_Costing.xls")
            End If

            SaveExcel = True
        Catch ex As Exception
            SaveExcel = False
        End Try
    End Function

#End Region

#Region "Drop Data to Excel"

    Private Function DropDataToExcel() As Boolean
        DropDataToExcel = False
        Dim ObjClsFormFinalCostingList As New clsFormFinalCostingList

        'Sunny : 11-08-10-10am
        GetSheetNames()

     
        'ANUP 23-09-2010 START
        'BaseEnd and RodEnd Fabricated part CODE is moved above the base and rod new sheet 
        'because fabricated sheet values should be put in base or rod new sheet
        Try  'BaseEnd Single/DoubleLug FabricatedPart
            Dim strBaseEndConfig As String = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration).ToUpper
            Dim strBaseEndConfigDesignType As String = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType).ToUpper
            Dim strBaseEndConfigDesign As String = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign).ToUpper
            ' If (strBaseEndConfig = "SINGLE LUG" OrElse strBaseEndConfig = "DOUBLE LUG") AndAlso strBaseEndConfigDesignType = "FABRICATED" AndAlso strBaseEndConfigDesign = "NEWDESIGN" Then  'anup 21-03-2011 start
            If (strBaseEndConfig = "SINGLE LUG" OrElse strBaseEndConfig = "DOUBLE LUG") AndAlso strBaseEndConfigDesignType = "FABRICATED" AndAlso ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Lug_BE Then  'anup 21-03-2011 start
                BaseEndLugDetails()
                BaseEndLugWCDetails()
            Else
                _oExcelSheet_BELug.Visible = Excel.XlSheetVisibility.xlSheetHidden
            End If
        Catch ex As Exception
            _oExcelSheet_BELug.Visible = Excel.XlSheetVisibility.xlSheetHidden
        End Try

        Try 'RodEnd DoubleLug FabricatedPart
            Dim strRodEndConfig As String = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration).ToUpper
            Dim strRodEndConfigDesignType As String = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd).ToUpper
            Dim strRodEndConfigDesign As String = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd).ToUpper
            '   If strRodEndConfig = "DOUBLE LUG" AndAlso strRodEndConfigDesignType = "FABRICATED" AndAlso strRodEndConfigDesign = "NEWDESIGN" Then
            If strRodEndConfig = "DOUBLE LUG" AndAlso strRodEndConfigDesignType = "FABRICATED" AndAlso ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Lug_RE Then
                RodEndLugDetails()
                RodEndLugWCDetails()
            Else
                _oExcelSheet_RELug.Visible = Excel.XlSheetVisibility.xlSheetHidden
            End If
        Catch ex As Exception
            _oExcelSheet_RELug.Visible = Excel.XlSheetVisibility.xlSheetHidden
        End Try

        Try 'Tube Sheet
            Dim aFinalTubeCodesDetails As ArrayList = ObjClsFormFinalCostingList.GetFinalCostingList(clsAddExistingCodes.HTTubeCostingCodeList)
            aFinalTubeCodesDetails.Sort()
            ObjClsWeldedCylinderFunctionalClass.METHDM_TUBE_ToolsList = aFinalTubeCodesDetails    '14_10_2010   RAGAVA
            If Not IsNothing(aFinalTubeCodesDetails) AndAlso aFinalTubeCodesDetails.Count > 0 Then
                AddCustomPartDetailsToNewTubeSheet(aFinalTubeCodesDetails)
                DropDataToTubeSheet(aFinalTubeCodesDetails)
                TubeWCDetails()
            End If
        Catch ex As Exception
        End Try

        Try 'Rod Sheet
            Dim aFinalRodCodesDetails As ArrayList = ObjClsFormFinalCostingList.GetFinalCostingList(clsAddExistingCodes.HTRodCostingCodeList)
            Dim strRodEndConfig As String = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration).ToUpper
            'ANUP 24-09-2010 START
            Dim strRodEndConnectionType As String = String.Empty
            If Not IsNothing(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType) Then
                strRodEndConnectionType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType).ToUpper
            End If
            'ANUP 24-09-2010 TILL HERE
            aFinalRodCodesDetails.Sort()
            ObjClsWeldedCylinderFunctionalClass.METHDM_ROD_ToolsList = aFinalRodCodesDetails    '14_10_2010   RAGAVA
            If Not IsNothing(aFinalRodCodesDetails) AndAlso aFinalRodCodesDetails.Count > 0 Then
                If strRodEndConfig = "DOUBLE LUG" AndAlso Not strRodEndConnectionType = "THREADED" Then
                    AddCustomPartDetailsToNewRodSheetOrFinalList(aFinalRodCodesDetails)
                End If
                DropDataToRodSheet(aFinalRodCodesDetails)
                RodWCDetails()
            End If
        Catch ex As Exception
        End Try
        'ANUP 23-09-2010 TILL HERE

        Try 'Existing Sheet
            Dim strRodEndConfig As String = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration).ToUpper
            'ANUP 24-09-2010 START
            Dim strRodEndConnectionType As String = String.Empty
            If Not IsNothing(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType) Then
                strRodEndConnectionType = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType).ToUpper
            End If
            'ANUP 24-09-2010 TILL HERE
            Dim aFinalExistingCodesDetails As ArrayList = ObjClsFormFinalCostingList.GetFinalCostingList(clsAddExistingCodes.HTExistingCostingCodeList)
            aFinalExistingCodesDetails.Sort()
            ObjClsWeldedCylinderFunctionalClass.METHDM_Cylinder_ToolsList = aFinalExistingCodesDetails    '09_10_2010   RAGAVA
            If Not IsNothing(aFinalExistingCodesDetails) AndAlso aFinalExistingCodesDetails.Count > 0 Then
                AddCustomPartDetailsToFinalList(aFinalExistingCodesDetails)
                If strRodEndConfig = "DOUBLE LUG" AndAlso strRodEndConnectionType = "THREADED" Then
                    AddCustomPartDetailsToNewRodSheetOrFinalList(aFinalExistingCodesDetails)
                End If
                DropDataToExistingSheet(aFinalExistingCodesDetails)
            End If
        Catch ex As Exception
        End Try

        DropDataToExcel = True
    End Function

    Private Sub GetSheetNames()
        Dim oRenamingHashTable As Hashtable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable

        If oRenamingHashTable.Count > 0 Then
            _strTubeSheetName = oRenamingHashTable("TUBE_WELDMENT")
            _strRodSheetName = oRenamingHashTable("ROD_WELDMENT")

            Dim strBaseEndConfig As String = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration).ToUpper
            If strBaseEndConfig = "SINGLE LUG" Then
                _strBELugSheetName = oRenamingHashTable("Base_Single_Lug_IFL")
            ElseIf strBaseEndConfig = "DOUBLE LUG" Then
                _strBELugSheetName = oRenamingHashTable("BASE_U_LUG_IFL")
            End If

            _strRELugSheetName = oRenamingHashTable("U_LUG_ROD")
        End If
    End Sub

#Region "Tube"

    Private Sub DropDataToTubeSheet(ByVal aTubeDetails As ArrayList)
        Try
            Dim intTotalCostExcelRange As Integer = 6
            Dim intSNo As Integer = 1
            Dim cSNo As Char = "A"
            Dim cMaterial As Char = "B"
            Dim cDescription As Char = "C"
            Dim cNetQuantity As Char = "D"
            Dim cQuantityPerUnit As Char = "E"
            Dim cUnits As Char = "F"
            Dim cStandardUnitCost As Char = "J"

            For Each oList As clsList In aTubeDetails
                Dim strCodeNumber As String = oList.strPartCode
                Dim strDescription As String = oList.strDescription
                Dim dblCostOfPart As Double = oList.dblCost
                Dim dblQuantityPerUnit As Double = oList.dblQuantity
                Dim strUnit As String = oList.strUnit

                _oExcelSheet_NewTube.Range(cSNo + intTotalCostExcelRange.ToString).Value = intSNo
                _oExcelSheet_NewTube.Range(cMaterial + intTotalCostExcelRange.ToString).Value = strCodeNumber
                _oExcelSheet_NewTube.Range(cDescription + intTotalCostExcelRange.ToString).Value = strDescription
                _oExcelSheet_NewTube.Range(cNetQuantity + intTotalCostExcelRange.ToString).Value = _dblSRQ
                _oExcelSheet_NewTube.Range(cQuantityPerUnit + intTotalCostExcelRange.ToString).Value = dblQuantityPerUnit
                _oExcelSheet_NewTube.Range(cUnits + intTotalCostExcelRange.ToString).Value = strUnit
                _oExcelSheet_NewTube.Range(cStandardUnitCost + intTotalCostExcelRange.ToString).Value = dblCostOfPart
                If dblCostOfPart = 0 Then
                    _oExcelSheet_NewTube.Range(cSNo + intTotalCostExcelRange.ToString).EntireRow.Font.Color = RGB(255, 0, 0)
                End If
                intSNo += 1
                intTotalCostExcelRange += 1
            Next

            _oExcelSheet_NewTube.Name = _strTubeSheetName
            _oExcelSheet_NewTube.Range("B2").Value = _strTubeSheetName
            _oExcelSheet_NewTube.Range("F2").Value = _dblSRQ

            _oExWorkbook.Save()
        Catch ex As Exception

        End Try
    End Sub

    Private Function TubeWCDetails() As Boolean
        TubeWCDetails = True
        Dim intTubeWCStartRange As Double = 21
        _oClsRulesSequence = New clsRulesSequence
        Try
            Dim intSNo As Integer = 1
            Dim cSNo As Char = "A"
            Dim cResource As Char = "B"
            Dim cSetupRun_Standard As Char = "F"
            Dim cLaboreRate As Char = "H"
            Dim cFixedBurdenRate As Char = "I"
            Dim cVariableBurdenRate As Char = "J"

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldedTubeWCDetails = _oClsRulesSequence.ObjOperations.WCDetailsHashTable


            '01_10_2010   RAGAVA
            For Each WC As String In ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWorkCenterList
                Dim oWCStructureElement As WCStructure
                oWCStructureElement = _oClsRulesSequence.ObjOperations.WCDetailsHashTable(WC)
                _oExcelSheet_NewTube.Range(cSNo + intTubeWCStartRange.ToString).Value = intSNo
                _oExcelSheet_NewTube.Range(cResource + intTubeWCStartRange.ToString).Value = oWCStructureElement.WorkCenter
                _oExcelSheet_NewTube.Range(cSetupRun_Standard + intTubeWCStartRange.ToString).Value = oWCStructureElement.SetupCost
                _oExcelSheet_NewTube.Range(cSetupRun_Standard + Val(intTubeWCStartRange + 1).ToString).Value = oWCStructureElement.RunCost
                _oExcelSheet_NewTube.Range(cLaboreRate + intTubeWCStartRange.ToString).Value = oWCStructureElement.LabourCost
                _oExcelSheet_NewTube.Range(cFixedBurdenRate + intTubeWCStartRange.ToString).Value = oWCStructureElement.FixedBurdenCost
                _oExcelSheet_NewTube.Range(cVariableBurdenRate + intTubeWCStartRange.ToString).Value = oWCStructureElement.VariableBurdenCost
                intSNo += 1
                intTubeWCStartRange += 2
            Next
            'For Each oWCStructureElement As WCStructure In _oClsRulesSequence.ObjOperations.WCDetailsHashTable.Values
            '    _oExcelSheet_NewTube.Range(cSNo + intTubeWCStartRange.ToString).Value = intSNo
            '    _oExcelSheet_NewTube.Range(cResource + intTubeWCStartRange.ToString).Value = oWCStructureElement.WorkCenter
            '    _oExcelSheet_NewTube.Range(cSetupRun_Standard + intTubeWCStartRange.ToString).Value = oWCStructureElement.SetupCost
            '    _oExcelSheet_NewTube.Range(cSetupRun_Standard + Val(intTubeWCStartRange + 1).ToString).Value = oWCStructureElement.RunCost
            '    _oExcelSheet_NewTube.Range(cLaboreRate + intTubeWCStartRange.ToString).Value = oWCStructureElement.LabourCost
            '    _oExcelSheet_NewTube.Range(cFixedBurdenRate + intTubeWCStartRange.ToString).Value = oWCStructureElement.FixedBurdenCost
            '    _oExcelSheet_NewTube.Range(cVariableBurdenRate + intTubeWCStartRange.ToString).Value = oWCStructureElement.VariableBurdenCost
            '    intSNo += 1
            '    intTubeWCStartRange += 2
            'Next
            'Till   Here
            _oExWorkbook.Save()
        Catch ex As Exception
            TubeWCDetails = False
        End Try
    End Function

    'ANUP 23-09-2010 START
    Private Sub AddCustomPartDetailsToNewTubeSheet(ByVal aFinalTubeCodesDetails As ArrayList)
        Dim oList As clsList
        Try
            If Not _oExcelSheet_BELug.Visible = Excel.XlSheetVisibility.xlSheetHidden Then
                oList = New clsList
                oList.strPartCode = _oExcelSheet_BELug.Range("B2").Value
                oList.strDescription = "BaseEnd Lug"
                oList.dblCost = _oExcelSheet_BELug.Range("L18").Value
                oList.dblQuantity = 1
                oList.strUnit = "EA"
                aFinalTubeCodesDetails.Add(oList)
            End If
        Catch ex As Exception
        End Try
    End Sub
    'ANUP 23-09-2010 TILL HERE
#End Region

#Region "Rod"

    Private Sub DropDataToRodSheet(ByVal aRodDetails As ArrayList)
        Try
            Dim intTotalCostExcelRange As Integer = 6
            Dim intSNo As Integer = 1
            Dim cSNo As Char = "A"
            Dim cMaterial As Char = "B"
            Dim cDescription As Char = "C"
            Dim cNetQuantity As Char = "D"
            Dim cQuantityPerUnit As Char = "E"
            Dim cUnits As Char = "F"
            Dim cStandardUnitCost As Char = "J"

            For Each oList As clsList In aRodDetails

                Dim strCodeNumber As String = oList.strPartCode
                Dim strDescription As String = oList.strDescription
                Dim dblCostOfPart As Double = oList.dblCost
                Dim dblQuantityPerUnit As Double = oList.dblQuantity
                Dim strUnit As String = oList.strUnit

                _oExcelSheet_NewRod.Range(cSNo + intTotalCostExcelRange.ToString).Value = intSNo
                _oExcelSheet_NewRod.Range(cMaterial + intTotalCostExcelRange.ToString).Value = strCodeNumber
                _oExcelSheet_NewRod.Range(cDescription + intTotalCostExcelRange.ToString).Value = strDescription
                _oExcelSheet_NewRod.Range(cNetQuantity + intTotalCostExcelRange.ToString).Value = _dblSRQ
                _oExcelSheet_NewRod.Range(cQuantityPerUnit + intTotalCostExcelRange.ToString).Value = dblQuantityPerUnit
                _oExcelSheet_NewRod.Range(cUnits + intTotalCostExcelRange.ToString).Value = strUnit
                _oExcelSheet_NewRod.Range(cStandardUnitCost + intTotalCostExcelRange.ToString).Value = dblCostOfPart
                If dblCostOfPart = 0 Then
                    _oExcelSheet_NewRod.Range(cSNo + intTotalCostExcelRange.ToString).EntireRow.Font.Color = RGB(255, 0, 0)
                End If
                intSNo += 1
                intTotalCostExcelRange += 1

                '11_10_2010    RAGAVA
                'Try
                '    If UCase(strDescription).IndexOf("RODENDCONFIGURATION") <> -1 Then

                '    End If
                'Catch ex As Exception
                'End Try
                'Till    Here
            Next

            _oExcelSheet_NewRod.Name = _strRodSheetName
            _oExcelSheet_NewRod.Range("B2").Value = _strRodSheetName
            _oExcelSheet_NewRod.Range("F2").Value = _dblSRQ

            _oExWorkbook.Save()
        Catch ex As Exception

        End Try
    End Sub

    Private Function RodWCDetails() As Boolean
        RodWCDetails = True
        Dim intTubeWCStartRange As Double = 17
        _oClsRodRulesSequence = New clsRodRulesSequence(_oExcelSheet_DrillingOne_Rod, _oExcelSheet_DrillingTwo_Rod)
        Try
            Dim intSNo As Integer = 1
            Dim cSNo As Char = "A"
            Dim cResource As Char = "B"
            Dim cSetupRun_Standard As Char = "F"
            Dim cLaboreRate As Char = "H"
            Dim cFixedBurdenRate As Char = "I"
            Dim cVariableBurdenRate As Char = "J"

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldedRodWCDetails = _oClsRodRulesSequence.RodOperations.WCDetailsHashTable

            '01_10_2010   RAGAVA
            For Each WC As String In ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodWorkCenterList
                Dim oWCStructureElement As WCStructure
                oWCStructureElement = _oClsRodRulesSequence.RodOperations.WCDetailsHashTable(WC)
                _oExcelSheet_NewRod.Range(cSNo + intTubeWCStartRange.ToString).Value = intSNo
                _oExcelSheet_NewRod.Range(cResource + intTubeWCStartRange.ToString).Value = oWCStructureElement.WorkCenter
                _oExcelSheet_NewRod.Range(cSetupRun_Standard + intTubeWCStartRange.ToString).Value = oWCStructureElement.SetupCost
                _oExcelSheet_NewRod.Range(cSetupRun_Standard + Val(intTubeWCStartRange + 1).ToString).Value = oWCStructureElement.RunCost
                _oExcelSheet_NewRod.Range(cLaboreRate + intTubeWCStartRange.ToString).Value = oWCStructureElement.LabourCost
                _oExcelSheet_NewRod.Range(cFixedBurdenRate + intTubeWCStartRange.ToString).Value = oWCStructureElement.FixedBurdenCost
                _oExcelSheet_NewRod.Range(cVariableBurdenRate + intTubeWCStartRange.ToString).Value = oWCStructureElement.VariableBurdenCost
                intSNo += 1
                intTubeWCStartRange += 2
            Next
            'For Each oWCStructureElement As WCStructure In _oClsRodRulesSequence.RodOperations.WCDetailsHashTable.Values
            '    _oExcelSheet_NewRod.Range(cSNo + intTubeWCStartRange.ToString).Value = intSNo
            '    _oExcelSheet_NewRod.Range(cResource + intTubeWCStartRange.ToString).Value = oWCStructureElement.WorkCenter
            '    _oExcelSheet_NewRod.Range(cSetupRun_Standard + intTubeWCStartRange.ToString).Value = oWCStructureElement.SetupCost
            '    _oExcelSheet_NewRod.Range(cSetupRun_Standard + Val(intTubeWCStartRange + 1).ToString).Value = oWCStructureElement.RunCost
            '    _oExcelSheet_NewRod.Range(cLaboreRate + intTubeWCStartRange.ToString).Value = oWCStructureElement.LabourCost
            '    _oExcelSheet_NewRod.Range(cFixedBurdenRate + intTubeWCStartRange.ToString).Value = oWCStructureElement.FixedBurdenCost
            '    _oExcelSheet_NewRod.Range(cVariableBurdenRate + intTubeWCStartRange.ToString).Value = oWCStructureElement.VariableBurdenCost
            '    intSNo += 1
            '    intTubeWCStartRange += 2
            'Next
            'Till  Here

            _oExWorkbook.Save()
        Catch ex As Exception
            RodWCDetails = False
        End Try
    End Function

    'ANUP 23-09-2010 START
    Private Sub AddCustomPartDetailsToNewRodSheetOrFinalList(ByVal aFinalCodesDetails As ArrayList)

        Dim oList As clsList
        Try
            If Not _oExcelSheet_RELug.Visible = Excel.XlSheetVisibility.xlSheetHidden Then
                oList = New clsList
                oList.strPartCode = _oExcelSheet_RELug.Range("B2").Value
                'ROD CYL X.XX - XX.XX - X.XX
                'oList.strDescription = "RodEnd Lug"
                '16_11_2011  RAGAVA
                Dim strDesc As String = String.Empty
                strDesc = "ROD CYL " & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, "0.00").ToString & "-" & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, "00.00").ToString & "-" & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInDecimals, "0.00").ToString & "-W"
                oList.strDescription = strDesc
                'Till   Here
                oList.dblCost = _oExcelSheet_RELug.Range("L18").Value
                oList.dblQuantity = 1
                oList.strUnit = "EA"
                aFinalCodesDetails.Add(oList)

                'anup 21-03-2011 start
                Dim strCodeKey As String = oList.strDescription
                If clsAddExistingCodes._htExistingCostingCodeList.Contains(strCodeKey) Then
                    clsAddExistingCodes._htRodCostingCodeList(strCodeKey) = oList
                Else
                    clsAddExistingCodes._htRodCostingCodeList.Add(strCodeKey, oList)
                End If
                'anup 21-03-2011 till here

            End If
        Catch ex As Exception
        End Try
    End Sub
    'ANUP 23-09-2010 TILL HERE
#End Region

#Region "Existing"

    Private Function SortHastTable(ByVal htExistingCostingCodeList As Hashtable) As Hashtable
        Dim htTemp As New Hashtable
        Try
            For Each dicElement As DictionaryEntry In htExistingCostingCodeList
                htTemp.Add(dicElement.Value, dicElement.Key)
            Next
        Catch ex As Exception
        End Try
        
        Dim keys As ICollection = htTemp.Keys
        Dim keysArray(htExistingCostingCodeList.Count - 1) As String
        keys.CopyTo(keysArray, 0)
        Array.Sort(keysArray)
        Dim htFinalHashTable As New Hashtable
        For Each strKey As String In keysArray
            htFinalHashTable.Add(htTemp(strKey), strKey)
        Next

        Return htFinalHashTable
    End Function

    Private Sub AddCustomPartDetailsToFinalList(ByVal aFinalExistingCodesDetails As ArrayList)
        Dim oList As clsList
        Dim strDesc As String = String.Empty         '16_11_2011   ragava
        Try
            oList = New clsList
            oList.strPartCode = _oExcelSheet_NewTube.Range("B2").Value
            strDesc = "TUBE WELDT " & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, "0.00").ToString & "-" & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, "00.00").ToString & "-W"          '16_11_2011  RAGAVA
            'oList.strDescription = "Tube Weldment"
            oList.strDescription = strDesc      '16_11_2011  RAGAVA
            oList.dblCost = _oExcelSheet_NewTube.Range("L49").Value
            oList.dblQuantity = 1
            oList.strUnit = "EA"
            aFinalExistingCodesDetails.Add(oList)
        Catch ex As Exception
        End Try

        Try
            oList = New clsList
            oList.strPartCode = _oExcelSheet_NewRod.Range("B2").Value
            If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Threaded") OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Threaded Rod" Then
                strDesc = "ROD CYL " & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, "0.00").ToString & "-" & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, "00.00").ToString & "-" & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInDecimals, "0.00").ToString
            Else
                strDesc = "ROD WELDT " & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, "0.00").ToString & "-" & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, "00.00").ToString & "-" & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInDecimals, "0.00").ToString & "-W"          '16_11_2011  RAGAVA
            End If
            'oList.strDescription = "Rod Weldment"
            oList.strDescription = strDesc        '16_11_2011    RAGAVA
            oList.dblCost = _oExcelSheet_NewRod.Range("L33").Value
            oList.dblQuantity = 1
            oList.strUnit = "EA"
            aFinalExistingCodesDetails.Add(oList)
        Catch ex As Exception
        End Try

        'ANUP 23-09-2010 START
        'Try
        '    If Not _oExcelSheet_BELug.Visible = Excel.XlSheetVisibility.xlSheetHidden Then
        '        oList = New clsList
        '        oList.strPartCode = _oExcelSheet_BELug.Range("B2").Value
        '        oList.strDescription = "BaseEnd Lug"
        '        oList.dblCost = _oExcelSheet_BELug.Range("L18").Value
        '        oList.dblQuantity = 1
        '        oList.strUnit = "EA"
        '        aFinalExistingCodesDetails.Add(oList)
        '    End If
        'Catch ex As Exception
        'End Try

        'Try
        '    If Not _oExcelSheet_RELug.Visible = Excel.XlSheetVisibility.xlSheetHidden Then
        '        oList = New clsList
        '        oList.strPartCode = _oExcelSheet_RELug.Range("B2").Value
        '        oList.strDescription = "RodEnd Lug"
        '        oList.dblCost = _oExcelSheet_RELug.Range("L18").Value
        '        oList.dblQuantity = 1
        '        oList.strUnit = "EA"
        '        aFinalExistingCodesDetails.Add(oList)
        '    End If
        'Catch ex As Exception
        'End Try
        'ANUP 23-09-2010 TILL HERE
    End Sub

    Private Sub DropDataToExistingSheet(ByVal aExistingDetails As ArrayList)
        Dim intTotalCostExcelRange As Integer = 6
        Dim intSNo As Integer = 1
        Dim cSNo As Char = "A"
        Dim cMaterial As Char = "B"
        Dim cDescription As Char = "C"
        Dim cQuantityPerUnit As Char = "D"
        Dim cUnits As Char = "E"
        Dim cStandardUnitCost As Char = "F"
        Try
            For Each oList As clsList In aExistingDetails

                Dim strCodeNumber As String = oList.strPartCode
                Dim strDescription As String = oList.strDescription
                Dim dblCostOfPart As Double = oList.dblCost
                Dim dblQuantityPerUnit As Double = oList.dblQuantity
                Dim strUnit As String = oList.strUnit

                _oExcelSheet_MainAssembly.Range(cSNo + intTotalCostExcelRange.ToString).Value = intSNo
                _oExcelSheet_MainAssembly.Range(cMaterial + intTotalCostExcelRange.ToString).Value = strCodeNumber
                _oExcelSheet_MainAssembly.Range(cDescription + intTotalCostExcelRange.ToString).Value = strDescription
                _oExcelSheet_MainAssembly.Range(cQuantityPerUnit + intTotalCostExcelRange.ToString).Value = dblQuantityPerUnit
                _oExcelSheet_MainAssembly.Range(cUnits + intTotalCostExcelRange.ToString).Value = strUnit
                _oExcelSheet_MainAssembly.Range(cStandardUnitCost + intTotalCostExcelRange.ToString).Value = dblCostOfPart
                If dblCostOfPart = 0 Then
                    _oExcelSheet_MainAssembly.Range(cSNo + intTotalCostExcelRange.ToString).EntireRow.Font.Color = RGB(255, 0, 0)
                End If
                intSNo += 1
                intTotalCostExcelRange += 1
            Next

            _oExcelSheet_MainAssembly.Name = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber
            _oExcelSheet_MainAssembly.Range("B2").Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber
            _oExcelSheet_MainAssembly.Range("E2").Value = _dblSRQ
            _oExWorkbook.Save()

            ExistingWCData()

            'Delete emptyrows
            While (IsNothing(_oExcelSheet_MainAssembly.Range("A" + intTotalCostExcelRange.ToString).Value))
                _oExcelSheet_MainAssembly.Range("A" + intTotalCostExcelRange.ToString, "A" + intTotalCostExcelRange.ToString).EntireRow.Delete()
            End While

            _oExWorkbook.Save()
        Catch ex As Exception

        End Try
    End Sub

   

    Private Sub ExistingWCData()
        Dim oOperationsDMC As New clsOperationDMC

        Dim _htTempExistingWCDetails As New Hashtable

        'Cylinder Assembly WC details
        Try
            '13_06_2011  RAGAVA
            Dim strAssemblyWC As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GetWC_619_622()
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strWC_619_622 = strAssemblyWC    '30_12_2011   RAGAVA
            'Dim strAssemblyWC As String = "WC619"
            'TILL    HERE

            '03_01_2012    RAGAVA
            Dim iMen As Integer = 1
            Try
                Dim strSql As String = "Select * from WorkCenter_MenMachineDetails where WorkCenter = '" & strAssemblyWC.ToString.Substring(2, 3) & "'"
                Dim dr1 As DataRow = MonarchConnectionObject.GetDataRow(strSql)
                If Not dr1 Is Nothing Then
                    iMen = dr1("NumberOfMen")
                End If
            Catch ex As Exception
            End Try
            'Till   Here
            Dim dblSetupCostAssemblyWC As Double = 0
            Dim dblRunCostAssemblyWC As Double = AssemblyRunStandardValue(strAssemblyWC)   '30_12_2011  RAGAVA  AssemblyRunStandardValue()
            Dim dblFixedBurdenAssemblyWC As Double = 0
            Dim dblSetupVariableAssemblyWC As Double = 0
            Dim dblSetupLabourAssemblyWC As Double = 0
            Dim oAssemblySetupDetails As DataRow = oOperationsDMC.getWorkCenterDetails(strAssemblyWC)
            If Not IsNothing(oAssemblySetupDetails) Then
                Try
                    dblSetupCostAssemblyWC = oAssemblySetupDetails("SetupCost")
                Catch ex As Exception
                End Try

                Try
                    dblFixedBurdenAssemblyWC = oAssemblySetupDetails("FixedBurdenCost")
                Catch ex As Exception
                End Try

                Try
                    dblSetupVariableAssemblyWC = oAssemblySetupDetails("VariableBurdenRate")
                Catch ex As Exception
                End Try

                Try
                    dblSetupLabourAssemblyWC = oAssemblySetupDetails("LabourRate")
                Catch ex As Exception
                End Try
            End If
            _htTempExistingWCDetails.Add(strAssemblyWC, addDataToCompleteCylinderHashTable(strAssemblyWC, dblSetupCostAssemblyWC, dblRunCostAssemblyWC, _
            dblFixedBurdenAssemblyWC, dblSetupVariableAssemblyWC, dblSetupLabourAssemblyWC))

            _oExcelSheet_MainAssembly.Range("B58").Value = strAssemblyWC
            _oExcelSheet_MainAssembly.Range("E58").Value = dblSetupCostAssemblyWC
            _oExcelSheet_MainAssembly.Range("F58").Value = dblSetupLabourAssemblyWC
            _oExcelSheet_MainAssembly.Range("G58").Value = dblFixedBurdenAssemblyWC
            _oExcelSheet_MainAssembly.Range("H58").Value = dblSetupVariableAssemblyWC
            '_oExcelSheet_MainAssembly.Range("E59").Value = dblRunCostAssemblyWC
            _oExcelSheet_MainAssembly.Range("E59").Value = dblRunCostAssemblyWC * iMen     '03_01_2012    RAGAVA

        Catch ex As Exception

        End Try
        _oExWorkbook.Save()

        'Cylinder OilTest WC details
        Try
            Dim strOilTestWC As String = "WC625"
            Dim dblSetupCostOilTestWC As Double = 0
            Dim dblRunCostOilTestWC As Double = OilTestStandardValue()
            Dim dblFixedBurdenOilTestWC As Double = 0
            Dim dblSetupVariableOilTestWC As Double = 0
            Dim dblSetupLabourOilTestWC As Double = 0
            Dim oOilTestSetupDetails As DataRow = oOperationsDMC.getWorkCenterDetails(strOilTestWC)
            If Not IsNothing(oOilTestSetupDetails) Then
                Try
                    dblSetupCostOilTestWC = oOilTestSetupDetails("SetupCost")
                Catch ex As Exception
                End Try

                Try
                    dblFixedBurdenOilTestWC = oOilTestSetupDetails("FixedBurdenCost")
                Catch ex As Exception
                End Try

                Try
                    dblSetupVariableOilTestWC = oOilTestSetupDetails("VariableBurdenRate")
                Catch ex As Exception
                End Try

                Try
                    dblSetupLabourOilTestWC = oOilTestSetupDetails("LabourRate")
                Catch ex As Exception
                End Try
            End If

            _htTempExistingWCDetails.Add(strOilTestWC, addDataToCompleteCylinderHashTable(strOilTestWC, dblSetupCostOilTestWC, dblRunCostOilTestWC, _
            dblFixedBurdenOilTestWC, dblSetupVariableOilTestWC, dblSetupLabourOilTestWC))

            _oExcelSheet_MainAssembly.Range("B60").Value = strOilTestWC
            _oExcelSheet_MainAssembly.Range("E60").Value = dblSetupCostOilTestWC
            _oExcelSheet_MainAssembly.Range("F60").Value = dblSetupLabourOilTestWC
            _oExcelSheet_MainAssembly.Range("G60").Value = dblFixedBurdenOilTestWC
            _oExcelSheet_MainAssembly.Range("H60").Value = dblSetupVariableOilTestWC
            _oExcelSheet_MainAssembly.Range("E61").Value = dblRunCostOilTestWC
        Catch ex As Exception

        End Try
        _oExWorkbook.Save()

        'Cylinder Painting WC details
        Try
            Dim strPaintingWC As String = "WC631"
            Dim dblSetupCostPaintingWC As Double = 0
            'Dim dblRunCostPaintingWC As Double = 1
            'Dim dblRunCostPaintingWC As Double = IIf(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strWeldCylinderWeight < 41, 22, 11)
            Dim dblRunCostPaintingWC As Double = 0
            Dim dblFixedBurdenPaintingWC As Double = 0
            Dim dblSetupVariablePaintingWC As Double = 0
            Dim dblSetupLabourPaintingWC As Double = 0
            Dim oPaintingSetupDetails As DataRow = oOperationsDMC.getWorkCenterDetails(strPaintingWC)
            If Not IsNothing(oPaintingSetupDetails) Then
                Try
                    dblSetupCostPaintingWC = oPaintingSetupDetails("SetupCost")
                Catch ex As Exception
                End Try

                Try
                    dblFixedBurdenPaintingWC = oPaintingSetupDetails("FixedBurdenCost")
                Catch ex As Exception
                End Try

                Try
                    dblSetupVariablePaintingWC = oPaintingSetupDetails("VariableBurdenRate")
                Catch ex As Exception
                End Try

                Try
                    dblSetupLabourPaintingWC = oPaintingSetupDetails("LabourRate")
                Catch ex As Exception
                End Try
            End If

            '07_10_2010  RAGAVA
            Try
                Dim TempExcelApp As Excel.Application
                Dim TempWorkBook As Excel.Workbook
                Dim tempWorkSheet As Excel.Worksheet
                Dim Rng As Excel.Range
                TempExcelApp = New Excel.Application
                TempExcelApp.Visible = False
                TempWorkBook = TempExcelApp.Workbooks.Open(System.Environment.CurrentDirectory & "\CMS_WELDED_PAINTING.xls")
                tempWorkSheet = TempExcelApp.Sheets("Paint Standards")
                '05_09_2011   RAGAVA
                Rng = tempWorkSheet.Range("L20")
                Rng.Value = 0
                Rng = tempWorkSheet.Range("L21")
                Rng.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength
                Rng = tempWorkSheet.Range("L22")
                Rng.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
                Rng = tempWorkSheet.Range("L23")
                If ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration <> "Cross Tube" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration <> "Cross Tube") AndAlso (Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType).ToUpper = "FABRICATED" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndFabricationSelected = True)) OrElse (ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "Resize" OrElse ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize") Then
                    Rng.Value = 1
                Else
                    Rng.Value = 0
                End If
                Rng = tempWorkSheet.Range("L24")
                If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.Pins_RodEnd = "Yes" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinsYesOrNo = "yes") Then
                    '06_06_2011   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnInstallPinsandClips_Checked = False Then
                        Rng.Value = 0
                    Else
                        Rng.Value = 1
                    End If
                    'Rng.Value = 1
                    'TILL  HERE
                Else
                    Rng.Value = 0
                End If
                Rng = tempWorkSheet.Range("L25")
                Rng.Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strWeldCylinderWeight
                Rng = tempWorkSheet.Range("L26")
                dblRunCostPaintingWC = Rng.Value
                ObjClsWeldedCylinderFunctionalClass.PaintStandardCost = dblRunCostPaintingWC     '09_10_2010    RAGAVA
            Catch ex As Exception
            End Try
            'Till    Here

            _htTempExistingWCDetails.Add(strPaintingWC, addDataToCompleteCylinderHashTable(strPaintingWC, dblSetupCostPaintingWC, _
           dblRunCostPaintingWC, dblFixedBurdenPaintingWC, dblSetupVariablePaintingWC, dblSetupLabourPaintingWC))

            _oExcelSheet_MainAssembly.Range("B62").Value = strPaintingWC
            _oExcelSheet_MainAssembly.Range("E62").Value = dblSetupCostPaintingWC
            _oExcelSheet_MainAssembly.Range("F62").Value = dblSetupLabourPaintingWC
            _oExcelSheet_MainAssembly.Range("G62").Value = dblFixedBurdenPaintingWC
            _oExcelSheet_MainAssembly.Range("H62").Value = dblSetupVariablePaintingWC
            _oExcelSheet_MainAssembly.Range("E63").Value = dblRunCostPaintingWC
        Catch ex As Exception

        End Try

        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldedCompleteCylinderWCDetails = _htTempExistingWCDetails
        _oExWorkbook.Save()
    End Sub

    Private Function addDataToCompleteCylinderHashTable(ByVal strWorkCenter As String, ByVal dblSetupStandardCost _
    As Double, ByVal dblRunStandardCost As Double, ByVal dblFixedBurdenPaintingWC As Double, ByVal dblSetupVariablePaintingWC As Double, _
    ByVal dblSetupLabourPaintingWC As Double) As WCStructure
        Dim oWCStructure As New WCStructure
        oWCStructure.WorkCenter = strWorkCenter
        oWCStructure.RunCost = dblRunStandardCost
        oWCStructure.FixedBurdenCost = dblFixedBurdenPaintingWC
        oWCStructure.LabourCost = dblSetupLabourPaintingWC
        oWCStructure.SetupCost = dblSetupStandardCost
        oWCStructure.VariableBurdenCost = dblSetupVariablePaintingWC
        addDataToCompleteCylinderHashTable = oWCStructure
    End Function

    'A0308: ANUP 03-08-2010 02.28pm
#Region "Assembly and Oil Test Run Standard Values"

#Region "Assembly"

    ''' <summary>
    ''' AssemblyRunStandardValue Function:::::
    ''' This function calculates the Assembly Run Standard Value 
    ''' by sending all the required values to the excel
    ''' </summary>
    ''' <returns>AssemblyRunStandardValue</returns>
    ''' <remarks></remarks>
    Private Function AssemblyRunStandardValue(Optional ByVal strWC As String = "") As Double
        Try

            Dim dblBoreDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
            Dim dblRetractedLength As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength
            Dim dblRephase As Double = 0
            Dim dblRRTypeHead As Double = RRTypeHead_Validation()
            Dim dblBushing As Double = Bushing_Validation()
            Dim dblRodClevis As Double = RodClevis_Validation()
            Dim dblToolB As Double = ToolB_Validation()
            '30_12_2011  RAGAVA
            If strWC = "WC622" Then
                dblToolB = 1
            End If
            'Till   Here
            Dim dblPTFEPistonSeal As Double = 0
            Dim dblStandardRunQuantity As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StandardRunQuantity

            _oExcelSheet_AssemblyRunStandard.Range("C3").Value = dblBoreDiameter
            _oExcelSheet_AssemblyRunStandard.Range("C4").Value = dblRetractedLength
            _oExcelSheet_AssemblyRunStandard.Range("C5").Value = dblRephase
            _oExcelSheet_AssemblyRunStandard.Range("C6").Value = dblRRTypeHead
            _oExcelSheet_AssemblyRunStandard.Range("C7").Value = dblBushing
            _oExcelSheet_AssemblyRunStandard.Range("C8").Value = dblRodClevis
            _oExcelSheet_AssemblyRunStandard.Range("C9").Value = dblToolB
            _oExcelSheet_AssemblyRunStandard.Range("C10").Value = dblPTFEPistonSeal
            _oExcelSheet_AssemblyRunStandard.Range("C11").Value = dblStandardRunQuantity

            _oExWorkbook.Save()

            AssemblyRunStandardValue = _oExcelSheet_AssemblyRunStandard.Range("C15").Value

        Catch ex As Exception

        End Try

    End Function

    ''' <summary>
    ''' RRTypeHead_Validation Function:::::
    ''' If the Head Type is Threaded then the function
    ''' returns 1 else 0
    ''' </summary>
    ''' <returns>RRTypeHead_Validation</returns>
    ''' <remarks></remarks>
    Private Function RRTypeHead_Validation() As Double
        Try
            '01_10_2010   RAGAVA
            'If ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.cmbHeadType.Text = "Threaded" Then
            '    RRTypeHead_Validation = 1
            'Else
            '    RRTypeHead_Validation = 0
            'End If
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.cmbHeadType.Text = "Threaded" Then
                RRTypeHead_Validation = 0
            Else
                RRTypeHead_Validation = 1
            End If
            'Till   Here
        Catch ex As Exception

        End Try
    End Function

    ''' <summary>
    ''' RodClevis_Validation Function:::::
    ''' If Double Lug configuration is selected with Threaded Connection Type
    ''' at RodEnd then the function returns1 else 0
    ''' </summary>
    ''' <returns>RodClevis_Validation</returns>
    ''' <remarks></remarks>
    Private Function RodClevis_Validation() As Double
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Threaded" Then
                RodClevis_Validation = 1
            Else
                RodClevis_Validation = 0
            End If
        Catch ex As Exception

        End Try
    End Function

    ''' <summary>
    ''' ToolB_Validation Function:::::
    ''' If Stroke Length is less than 6 then the function
    ''' returns 1 else 0
    ''' </summary>
    ''' <returns>ToolB_Validation</returns>
    ''' <remarks></remarks>
    Private Function ToolB_Validation() As Double
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength < 6 Then
                ToolB_Validation = 1
            Else
                ToolB_Validation = 0
            End If
        Catch ex As Exception

        End Try
    End Function

    ''' <summary>
    ''' Bushing_Validation Function:::::
    ''' This Function adds the Number of bushings selected at the BaseEnd and RodEnd
    ''' and returns the added value
    ''' </summary>
    ''' <returns>Bushing_Validation</returns>
    ''' <remarks></remarks>
    Private Function Bushing_Validation() As Double
        Try
            Bushing_Validation = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity_RodEnd
        Catch ex As Exception

        End Try
    End Function

#End Region

#Region "Oil Test"

    ''' <summary>
    ''' OilTestStandardValue Function ::::::
    ''' This function calculates the Oil Test Standard Value 
    ''' by sending all the required values to the excel
    ''' </summary>
    ''' <returns>OilTestStandardValue</returns>
    ''' <remarks></remarks>
    ''' 
    Private Function OilTestStandardValue() As Double
        Try

            Dim dblBoreDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
            Dim dblStrokeLength As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength
            Dim dblNumberOfPorts As Double = NumberOfPorts()
            Dim dblBreather As Double = Breather()
            Dim strThreadProtectorOnRod As String = ThreadProtectorOnRod()
            Dim strBothPortsSameSize As String = BothPortsSameSize()
            Dim str90DegreePorts As Integer = Ports_90Degrees()
            Dim strNPTPorts As Integer = NPTPorts()
            Dim dblAnglebetweenPorts As Double = AngleBetweenPorts()
            Dim strSingleActing As String = "n"

            '05_09_2011   RAGAVA

            '_oExcelSheet_OilTestRunStandard.Range("B2").Value = dblBoreDiameter
            '_oExcelSheet_OilTestRunStandard.Range("B3").Value = dblStrokeLength
            '_oExcelSheet_OilTestRunStandard.Range("B4").Value = dblNumberOfPorts
            '_oExcelSheet_OilTestRunStandard.Range("B5").Value = dblBreather
            '_oExcelSheet_OilTestRunStandard.Range("B6").Value = strThreadProtectorOnRod
            '_oExcelSheet_OilTestRunStandard.Range("B7").Value = strBothPortsSameSize
            '_oExcelSheet_OilTestRunStandard.Range("B8").Value = str90DegreePorts
            '_oExcelSheet_OilTestRunStandard.Range("B9").Value = strNPTPorts
            '_oExcelSheet_OilTestRunStandard.Range("B10").Value = dblAnglebetweenPorts
            '_oExcelSheet_OilTestRunStandard.Range("B11").Value = strSingleActing


            _oExcelSheet_OilTestRunStandard.Range("C4").Value = dblBoreDiameter
            _oExcelSheet_OilTestRunStandard.Range("C5").Value = dblStrokeLength
            _oExcelSheet_OilTestRunStandard.Range("C6").Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StandardRunQuantity 'dblNumberOfPorts
            _oExcelSheet_OilTestRunStandard.Range("C7").Value = IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmGenerate.chkPackCylinderInPlasticBag.Checked = True, 1, 0)
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Extension" Then
                _oExcelSheet_OilTestRunStandard.Range("C8").Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Retraction" Then
                _oExcelSheet_OilTestRunStandard.Range("C8").Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Bothends" Then
                _oExcelSheet_OilTestRunStandard.Range("C8").Value = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd
            End If
            _oExcelSheet_OilTestRunStandard.Range("C9").Value = IIf(strSingleActing = "n", 0, 1) ' strBothPortsSameSize
            _oExcelSheet_OilTestRunStandard.Range("C10").Value = 0        'Cushioning
            _oExcelSheet_OilTestRunStandard.Range("C11").Value = str90DegreePorts
            _oExcelSheet_OilTestRunStandard.Range("C12").Value = strNPTPorts
            Dim iCount_Accessories As Int16 = 0
            If Not (ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbAccessoryType_BaseEnd.Text = "Dust Plug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbAccessoryType_BaseEnd.Text = "Permanent Plug") AndAlso ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbAccessoryType_BaseEnd.Text <> "" Then
                iCount_Accessories = iCount_Accessories + 1
            End If
            If Not (ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbAccessoryType2_BaseEnd.Text = "Dust Plug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbAccessoryType2_BaseEnd.Text = "Permanent Plug") AndAlso ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbAccessoryType2_BaseEnd.Text <> "" Then
                iCount_Accessories = iCount_Accessories + 1
            End If
            If Not (ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbAccessoryType_RodEnd.Text = "Dust Plug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbAccessoryType_RodEnd.Text = "Permanent Plug") AndAlso ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbAccessoryType_RodEnd.Text <> "" Then
                iCount_Accessories = iCount_Accessories + 1
            End If
            If Not (ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbAccessoryType2_RodEnd.Text = "Dust Plug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbAccessoryType2_RodEnd.Text = "Permanent Plug") AndAlso ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbAccessoryType2_RodEnd.Text <> "" Then
                iCount_Accessories = iCount_Accessories + 1
            End If
            iCount_Accessories = iCount_Accessories + Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbGreaseZercs.Text)
            iCount_Accessories = iCount_Accessories + Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbGreaseZercs_RodEnd.Text)
            _oExcelSheet_OilTestRunStandard.Range("C13").Value = iCount_Accessories
            _oExcelSheet_OilTestRunStandard.Range("C14").Value = 0   'Torque
            _oExWorkbook.Save()

            OilTestStandardValue = _oExcelSheet_OilTestRunStandard.Range("C15").Value
            'Till   Here
        Catch ex As Exception

        End Try
    End Function

    ''' <summary>
    ''' NumberOfPorts Function:::::
    ''' This function adds the NUMBER  OF PORTS selected at both BaseEnd and RodEnd
    ''' and returns the added value.
    ''' </summary>
    ''' <returns>NumberOfPorts</returns>
    ''' <remarks></remarks>
    Private Function NumberOfPorts() As Double
        Try
            NumberOfPorts = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd + _
                                                  ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd
        Catch ex As Exception

        End Try
    End Function

    ''' <summary>
    ''' Breather Function:::::
    ''' If Port Accessory Type is BREATHER at both BaseEnd and RodEnd the function returns 2,
    '''  if Breather is selected at any one end then it returns 1,
    ''' if no breather selected then it returns 0.
    ''' </summary>
    ''' <returns>Breather</returns>
    ''' <remarks></remarks>
    Private Function Breather() As Double
        Try
            If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortAccessoryType_BaseEnd = "Breather, 40 micron - SS" _
                               OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortAccessoryType_BaseEnd = "Breather" _
                               OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortAccessoryType_BaseEnd = "Breather, 10 micron") _
                               AndAlso (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortAccessoryType_RodEnd = "Breather, 40 micron - SS" _
                               OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortAccessoryType_RodEnd = "Breather" _
                               OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortAccessoryType_RodEnd = "Breather, 10 micron") Then
                Breather = 2
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.Breather = 2     '07_10_2010   RAGAVA
            ElseIf (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortAccessoryType_BaseEnd = "Breather, 40 micron - SS" _
                               OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortAccessoryType_BaseEnd = "Breather" _
                               OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortAccessoryType_BaseEnd = "Breather, 10 micron") _
                               OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortAccessoryType_RodEnd = "Breather, 40 micron - SS" _
                               OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortAccessoryType_RodEnd = "Breather" _
                               OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortAccessoryType_RodEnd = "Breather, 10 micron") Then
                Breather = 1
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.Breather = 1     '07_10_2010   RAGAVA
            Else
                Breather = 0
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.Breather = 0     '07_10_2010   RAGAVA
            End If
        Catch ex As Exception

        End Try
    End Function

    ''' <summary>
    ''' ThreadProtectorOnRod Function:::::
    ''' If Threaded Rod Configuration is selected at RodEnd side 
    ''' then the function returns 'Y' (yes)
    ''' else 'n' (no) 
    ''' </summary>
    ''' <returns>ThreadProtectorOnRod</returns>
    ''' <remarks></remarks>
    Private Function ThreadProtectorOnRod() As String
        ThreadProtectorOnRod = Nothing
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Threaded Rod" Then
                ThreadProtectorOnRod = "y"
            Else
                ThreadProtectorOnRod = "n"
            End If
        Catch ex As Exception

        End Try
    End Function

    ''' <summary>
    ''' BothPortsSameSize Function:::::
    ''' If Port Sizes at BaseEnd and RodEnd are same
    ''' then the function returns 'Y' else 'N'
    ''' </summary>
    ''' <returns>BothPortsSameSize</returns>
    ''' <remarks></remarks>
    Private Function BothPortsSameSize() As String
        BothPortsSameSize = Nothing
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd = _
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_RodEnd Then
                BothPortsSameSize = "Y"
            Else
                BothPortsSameSize = "N"
            End If
        Catch ex As Exception

        End Try
    End Function

    ''' <summary>
    ''' Ports_90Degrees Function:::::
    ''' If Port Angle is 90 at either BaseEnd or RodEnd side
    ''' then the function returns 'Y' else 'N'
    ''' </summary>
    ''' <returns>Ports_90Degrees</returns>
    ''' <remarks></remarks>
    Private Function Ports_90Degrees() As Integer
        Ports_90Degrees = 0
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleBaseEnd.Text = "90" Then
                Ports_90Degrees = Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsBaseEnd.Text)
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text = "90" Then
                Ports_90Degrees = Ports_90Degrees + Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsRodEnd.Text)
            End If
            Return Ports_90Degrees
        Catch ex As Exception

        End Try
    End Function

    ''' <summary>
    ''' NPTPorts Function:::::
    ''' If Port Type is 'NPTF' at either BaseEnd or RodEnd side
    ''' then the function returns 'Y' else 'N'
    ''' </summary>
    ''' <returns>NPTPorts</returns>
    ''' <remarks></remarks>
    Private Function NPTPorts() As Integer
        NPTPorts = 0
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd = "NPTF" Then
                NPTPorts = Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsBaseEnd.Text)
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_RodEnd = "NPTF" Then
                NPTPorts = NPTPorts + Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsRodEnd.Text)
            End If
            Return NPTPorts
        Catch ex As Exception

        End Try
    End Function

    ''' <summary>
    ''' AngleBetweenPorts Function:::::
    ''' Based on the Number of Ports selected on BaseEnd and RodEnd side
    ''' the Port orientation Values are passed to the functions called 
    ''' to calculate the difference between the angles.
    ''' </summary>
    ''' <returns>AngleBetweenPorts</returns>
    ''' <remarks></remarks>
    Private Function AngleBetweenPorts() As Double
        Try

            Dim dblFirst_Base As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FirstPortOrientation_BaseEnd
            'Dim dblFirst_Rod As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FirstPortOrientation_RodEnd
            Dim dblFirst_Rod As Double = Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text)     '07_03_2011   RAGAVA
            Dim dblSecond_Base As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SecondPortOrientation_BaseEnd
            Dim dblSecond_Rod As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SecondPortOrientation_RodEnd
            Dim dblFinalCalculation As Double

            If Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd = 0 AndAlso _
                                     Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd = 0 Then

                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd = 2 _
                                                       AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd = 2 Then
                    dblFinalCalculation = NumberOfPorts_2_2(dblFirst_Base, dblFirst_Rod, dblSecond_Base, dblSecond_Rod)
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd = 2 _
                                                      AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd = 1 Then
                    dblFinalCalculation = NumberOfPorts_2_1(dblFirst_Base, dblFirst_Rod, dblSecond_Base)
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd = 1 _
                                                     AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd = 2 Then
                    dblFinalCalculation = NumberOfPorts_1_2(dblFirst_Base, dblFirst_Rod, dblSecond_Rod)
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd = 1 _
                                                     AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd = 1 Then
                    dblFinalCalculation = NumberOfPorts_1_1(dblFirst_Base, dblFirst_Rod)
                End If

                AngleBetweenPorts = dblFinalCalculation

            Else
                AngleBetweenPorts = 0
            End If

        Catch ex As Exception

        End Try
    End Function

    ''' <summary>
    ''' NumberOfPorts_2_2 Function:::::
    ''' This Function is used if selected number of ports are 2 each at both sides
    ''' Difference between the angles are found 
    ''' and the highest value is returned
    ''' </summary>
    ''' <param name="dblFirst_Base">First Port Orientation at Base End</param>
    ''' <param name="dblFirst_Rod">First Port Orientation at Rod End</param>
    ''' <param name="dblSecond_Base">Second Port Orientation at Base End</param>
    ''' <param name="dblSecond_Rod">Second Port Orientation at Rod End</param>
    ''' <returns>NumberOfPorts_2_2</returns>
    ''' <remarks></remarks>
    Private Function NumberOfPorts_2_2(ByVal dblFirst_Base As Double, ByVal dblFirst_Rod As Double, _
                                                                ByVal dblSecond_Base As Double, ByVal dblSecond_Rod As Double) As Double
        Try
            _dblFirstPortOrientation_Base_Rod = Math.Abs(dblFirst_Base - dblFirst_Rod)
            _dblSecondPortOrientation_Base_Rod = Math.Abs(dblSecond_Base - dblSecond_Rod)
            _dblFirstAndSecondPortOrientation_Base = Math.Abs(dblFirst_Base - dblSecond_Base)
            _dblFirstAndSecondPortOrientation_Rod = Math.Abs(dblFirst_Rod - dblSecond_Rod)

            If _dblFirstPortOrientation_Base_Rod >= _dblSecondPortOrientation_Base_Rod Then
                NumberOfPorts_2_2 = _dblFirstPortOrientation_Base_Rod
            Else
                NumberOfPorts_2_2 = _dblSecondPortOrientation_Base_Rod
            End If

            If Not NumberOfPorts_2_2 >= _dblFirstAndSecondPortOrientation_Base Then
                NumberOfPorts_2_2 = _dblFirstAndSecondPortOrientation_Base
            End If

            If Not NumberOfPorts_2_2 >= _dblFirstAndSecondPortOrientation_Rod Then
                NumberOfPorts_2_2 = _dblFirstAndSecondPortOrientation_Rod
            End If
        Catch ex As Exception

        End Try
    End Function

    ''' <summary>
    ''' NumberOfPorts_2_1 Function:::::
    ''' This Function is used if selected number of ports are 2 at BaseEnd and 1 at RodEnd
    ''' Difference between the angles are found 
    ''' and the highest value is returned
    ''' </summary>
    ''' <param name="dblFirst_Base">First Port Orientation at Base End</param>
    ''' <param name="dblFirst_Rod">First Port Orientation at Rod End</param>
    ''' <param name="dblSecond_Base">Second Port Orientation at Base End</param>
    ''' <returns>NumberOfPorts_2_1</returns>
    ''' <remarks></remarks>
    Private Function NumberOfPorts_2_1(ByVal dblFirst_Base As Double, ByVal dblFirst_Rod As Double, ByVal dblSecond_Base As Double) As Double
        Try
            _dblFirstAndSecondPortOrientation_Base = Math.Abs(dblFirst_Base - dblSecond_Base)
            _dblFirstPortOrientation_Base_Rod = Math.Abs(dblFirst_Base - dblFirst_Rod)

            If _dblFirstAndSecondPortOrientation_Base >= _dblFirstPortOrientation_Base_Rod Then
                NumberOfPorts_2_1 = _dblFirstAndSecondPortOrientation_Base
            Else
                NumberOfPorts_2_1 = _dblFirstPortOrientation_Base_Rod
            End If
        Catch ex As Exception

        End Try
    End Function

    ''' <summary>
    ''' NumberOfPorts_1_2 Function:::::
    ''' This Function is used if selected number of ports are 1 at BaseEnd and 2 at RodEnd
    ''' Difference between the angles are found 
    ''' and the highest value is returned
    ''' </summary>
    ''' <param name="dblFirst_Base">First Port Orientation at Base End</param>
    ''' <param name="dblFirst_Rod">First Port Orientation at Rod End</param>
    ''' <param name="dblSecond_Rod">Second Port Orientation at Rod End</param>
    ''' <returns>NumberOfPorts_1_2</returns>
    ''' <remarks></remarks>
    Private Function NumberOfPorts_1_2(ByVal dblFirst_Base As Double, ByVal dblFirst_Rod As Double, ByVal dblSecond_Rod As Double) As Double
        Try
            _dblFirstPortOrientation_Base_Rod = Math.Abs(dblFirst_Base - dblFirst_Rod)
            _dblFirstAndSecondPortOrientation_Rod = Math.Abs(dblFirst_Rod - dblSecond_Rod)

            If _dblFirstPortOrientation_Base_Rod >= _dblFirstAndSecondPortOrientation_Rod Then
                NumberOfPorts_1_2 = _dblFirstPortOrientation_Base_Rod
            Else
                NumberOfPorts_1_2 = _dblFirstAndSecondPortOrientation_Rod
            End If
        Catch ex As Exception

        End Try
    End Function

    ''' <summary>
    ''' NumberOfPorts_1_1 Function:::::
    ''' This Function is used if selected number of ports are 1 at BaseEnd and 1 at RodEnd
    ''' Difference between the angles are found 
    ''' and the value is returned
    ''' </summary>
    ''' <param name="dblFirst_Base">First Port Orientation at Base End</param>
    ''' <param name="dblFirst_Rod">First Port Orientation at Rod End</param>
    ''' <returns>NumberOfPorts_1_1</returns>
    ''' <remarks></remarks>
    Private Function NumberOfPorts_1_1(ByVal dblFirst_Base As Double, ByVal dblFirst_Rod As Double) As Double
        Try
            _dblFirstPortOrientation_Base_Rod = Math.Abs(dblFirst_Base - dblFirst_Rod)
            NumberOfPorts_1_1 = _dblFirstPortOrientation_Base_Rod
        Catch ex As Exception

        End Try
    End Function

#End Region

#End Region

#End Region

#Region "BaseEnd Lug"

    Private Sub BaseEndLugDetails()
        Dim dblLugThickness As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
        Dim dblLugWidth As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
        Dim dblSwingClearanceBE As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
        Dim strBaseEndConfig As String = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration).ToUpper
        Dim dblLugGap As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap
        Dim dblLuglength As Double = GetLugLengthBE(strBaseEndConfig, dblSwingClearanceBE, dblLugWidth, dblLugThickness, dblLugGap)


        Dim intSeq As Integer = 1
        Dim strMaterialCode As String = ""
        Try
            Dim objWeldedCostingDataBaseClass As New clsWeldedCostingDataBaseClass
            strMaterialCode = objWeldedCostingDataBaseClass.GetMaterialCode(dblLugThickness, dblLugWidth)
        Catch ex As Exception
        End Try

        Dim strDescription As String = "BaseEnd Fabricated Lug"
        Dim dblQuantityPerPart As Double = (dblLuglength + 0.875) * (0.2833333 * dblLugThickness * dblLugWidth)
        Dim strUnits As String = "LB"
        Dim dblStandardUnitCost As Double = 5

        _oExcelSheet_BELug.Range("A6").Value = intSeq
        _oExcelSheet_BELug.Range("B6").Value = strMaterialCode
        _oExcelSheet_BELug.Range("C6").Value = strDescription
        _oExcelSheet_BELug.Range("D6").Value = _dblSRQ
        _oExcelSheet_BELug.Range("E6").Value = dblQuantityPerPart
        _oExcelSheet_BELug.Range("F6").Value = strUnits
        _oExcelSheet_BELug.Range("J6").Value = dblStandardUnitCost

        _oExcelSheet_BELug.Range("B2").Value = _strBELugSheetName
        _oExcelSheet_BELug.Range("F2").Value = _dblSRQ
        _oExcelSheet_BELug.Name = _strBELugSheetName
        _oExWorkbook.Save()

        'anup 21-03-2011 start
        Dim htBaseEndLugDetails As New Hashtable
        Dim oClsMaterial_CMS As New clsMaterial_CMS
        htBaseEndLugDetails.Add(oClsMaterial_CMS.MATERIAL_CODE, strMaterialCode)
        htBaseEndLugDetails.Add(oClsMaterial_CMS.MATERIAL_DESCRIPTION, strDescription)
        htBaseEndLugDetails.Add(oClsMaterial_CMS.QUANTITY_PER_PART, dblQuantityPerPart)
        htBaseEndLugDetails.Add(oClsMaterial_CMS.UNITS, strUnits)
        htBaseEndLugDetails.Add(oClsMaterial_CMS.STANDARD_UNIT_COST, dblStandardUnitCost)
        ObjClsWeldedCylinderFunctionalClass.METHDM_LUG_TUBE_HashTable = htBaseEndLugDetails
        'anup 21-03-2011 till here
    End Sub

    Private Sub BaseEndLugWCDetails()
        Dim _htTempBELugWCDetails As New Hashtable

        Dim intSeq As Integer = 1
        Dim strShearingWCBE As String = "WC404"
        Dim dblShearingSetupCost As Double = 0.75
        Dim dblShearingRunCost As Double = 200
        Dim dblShearingLabourCost As Double = 17.75
        Dim dblShearingFixedBurdenCost As Double = 24
        Dim dblShearingVariableBurdenCost As Double = 16

        _oExcelSheet_BELug.Range("A12").Value = intSeq
        _oExcelSheet_BELug.Range("B12").Value = strShearingWCBE
        _oExcelSheet_BELug.Range("F12").Value = dblShearingSetupCost
        _oExcelSheet_BELug.Range("H12").Value = dblShearingLabourCost
        _oExcelSheet_BELug.Range("I12").Value = dblShearingFixedBurdenCost
        _oExcelSheet_BELug.Range("J12").Value = dblShearingVariableBurdenCost
        _oExcelSheet_BELug.Range("F13").Value = dblShearingRunCost
        _htTempBELugWCDetails.Add(strShearingWCBE, addDataToCompleteCylinderHashTable(strShearingWCBE, dblShearingSetupCost, dblShearingRunCost, _
          dblShearingFixedBurdenCost, dblShearingVariableBurdenCost, dblShearingLabourCost))
        _oExWorkbook.Save()

        If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration).ToUpper = "DOUBLE LUG" Then
            Dim strBendingWCBE As String = "WC401"
            Dim dblBendingSetupCost As Double = 0.75
            Dim dblBendingRunCost As Double = 120
            Dim dblBendingLabourCost As Double = 17.75
            Dim dblBendingFixedBurdenCost As Double = 24
            Dim dblBendingVariableBurdenCost As Double = 16

            _oExcelSheet_BELug.Range("A14").Value = intSeq + 1
            _oExcelSheet_BELug.Range("B14").Value = strBendingWCBE
            _oExcelSheet_BELug.Range("F14").Value = dblBendingSetupCost
            _oExcelSheet_BELug.Range("H14").Value = dblBendingLabourCost
            _oExcelSheet_BELug.Range("I14").Value = dblBendingFixedBurdenCost
            _oExcelSheet_BELug.Range("J14").Value = dblBendingVariableBurdenCost
            _oExcelSheet_BELug.Range("F15").Value = dblBendingRunCost
            _htTempBELugWCDetails.Add(strBendingWCBE, addDataToCompleteCylinderHashTable(strBendingWCBE, dblBendingSetupCost, dblBendingRunCost, _
                                                      dblBendingFixedBurdenCost, dblBendingVariableBurdenCost, dblBendingLabourCost))
            _oExWorkbook.Save()
        End If
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldedBELugWCDetails = _htTempBELugWCDetails
    End Sub

    Private Function GetLugLengthBE(ByVal strBaseEndConfig As String, ByVal dblSwingClearanceBE As Double, ByVal dblLugWidth As Double, ByVal dblLugThickness As String, ByVal dblLugGap As Double) As Double

        If strBaseEndConfig = "SINGLE LUG" Then
            GetLugLengthBE = dblSwingClearanceBE + (dblLugWidth / 2)
        Else
            Dim dblInnerRadius As Double = 0
            If dblLugThickness <= 0.5 Then
                dblInnerRadius = 0.25
            ElseIf dblLugThickness <= 0.625 Then
                dblInnerRadius = 0.5
            Else
                dblInnerRadius = 0.625
            End If
            GetLugLengthBE = (2 * ((dblLugWidth / 2) + dblSwingClearanceBE + dblInnerRadius)) + dblLugGap
        End If
    End Function

#End Region

#Region "RodEnd Lug"

    Private Sub RodEndLugDetails()
        Dim dblLugThickness As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
        Dim dblLugWidth As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd
        Dim dblSwingClearance As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
        Dim dblLugGap As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd
        Dim dblLuglength As Double = GetLugLengthRE(dblSwingClearance, dblLugWidth, dblLugThickness)

        Dim intSeq As Integer = 1

        Dim strMaterialCode As String = Nothing
        Try
            Dim objWeldedCostingDataBaseClass As New clsWeldedCostingDataBaseClass
            strMaterialCode = objWeldedCostingDataBaseClass.GetMaterialCode(dblLugThickness, dblLugWidth)
        Catch ex As Exception
        End Try

        Dim strDescription As String = "RodEnd Fabricated Lug"
        Dim dblQuantityPerPart As Double = (dblLuglength + 0.875) * (0.2833333 * dblLugThickness * dblLugWidth) + dblLugGap
        Dim strUnits As String = "LB"
        Dim dblStandardUnitCost As Double = 5

        _oExcelSheet_RELug.Range("A6").Value = intSeq
        _oExcelSheet_RELug.Range("B6").Value = strMaterialCode
        _oExcelSheet_RELug.Range("C6").Value = strDescription
        _oExcelSheet_RELug.Range("D6").Value = _dblSRQ
        _oExcelSheet_RELug.Range("E6").Value = dblQuantityPerPart
        _oExcelSheet_RELug.Range("F6").Value = strUnits
        _oExcelSheet_RELug.Range("J6").Value = dblStandardUnitCost

        _oExcelSheet_RELug.Range("B2").Value = _strRELugSheetName
        _oExcelSheet_RELug.Range("F2").Value = _dblSRQ
        _oExcelSheet_RELug.Name = _strRELugSheetName
        _oExWorkbook.Save()

        'anup 21-03-2011 start
        Dim htRodLugDetails As New Hashtable
        Dim oClsMaterial_CMS As New clsMaterial_CMS
        htRodLugDetails.Add(oClsMaterial_CMS.MATERIAL_CODE, strMaterialCode)
        htRodLugDetails.Add(oClsMaterial_CMS.MATERIAL_DESCRIPTION, strDescription)
        htRodLugDetails.Add(oClsMaterial_CMS.QUANTITY_PER_PART, dblQuantityPerPart)
        htRodLugDetails.Add(oClsMaterial_CMS.UNITS, strUnits)
        htRodLugDetails.Add(oClsMaterial_CMS.STANDARD_UNIT_COST, dblStandardUnitCost)
        ObjClsWeldedCylinderFunctionalClass.METHDM_LUG_ROD_HashTable = htRodLugDetails
        'anup 21-03-2011 till here
    End Sub

    Private Sub RodEndLugWCDetails()
        Dim _htTempRELugWCDetails As New Hashtable

        Dim intSeq As Integer = 1
        Dim strShearingWCRE As String = "WC404"
        Dim dblShearingSetupCost As Double = 0.75
        Dim dblShearingRunCost As Double = 200
        Dim dblShearingLabourCost As Double = 17.75
        Dim dblShearingFixedBurdenCost As Double = 24
        Dim dblShearingVariableBurdenCost As Double = 16

        _oExcelSheet_BELug.Range("A12").Value = intSeq
        _oExcelSheet_RELug.Range("B12").Value = strShearingWCRE
        _oExcelSheet_RELug.Range("F12").Value = dblShearingSetupCost
        _oExcelSheet_RELug.Range("H12").Value = dblShearingLabourCost
        _oExcelSheet_RELug.Range("I12").Value = dblShearingFixedBurdenCost
        _oExcelSheet_RELug.Range("J12").Value = dblShearingVariableBurdenCost
        _oExcelSheet_RELug.Range("F13").Value = dblShearingRunCost
        _htTempRELugWCDetails.Add(strShearingWCRE, addDataToCompleteCylinderHashTable(strShearingWCRE, dblShearingSetupCost, dblShearingRunCost, _
         dblShearingFixedBurdenCost, dblShearingVariableBurdenCost, dblShearingLabourCost))
        _oExWorkbook.Save()


        Dim strBendingWCBE As String = "WC401"
        Dim dblBendingSetupCost As Double = 0.75
        Dim dblBendingRunCost As Double = 120
        Dim dblBendingLabourCost As Double = 17.75
        Dim dblBendingFixedBurdenCost As Double = 24
        Dim dblBendingVariableBurdenCost As Double = 16

        _oExcelSheet_BELug.Range("A14").Value = intSeq + 1
        _oExcelSheet_RELug.Range("B14").Value = strBendingWCBE
        _oExcelSheet_RELug.Range("F14").Value = dblBendingSetupCost
        _oExcelSheet_RELug.Range("H14").Value = dblBendingLabourCost
        _oExcelSheet_RELug.Range("I14").Value = dblBendingFixedBurdenCost
        _oExcelSheet_RELug.Range("J14").Value = dblBendingVariableBurdenCost
        _oExcelSheet_RELug.Range("F15").Value = dblBendingRunCost
        _htTempRELugWCDetails.Add(strBendingWCBE, addDataToCompleteCylinderHashTable(strBendingWCBE, dblBendingSetupCost, dblBendingRunCost, _
                                                      dblBendingFixedBurdenCost, dblBendingVariableBurdenCost, dblBendingLabourCost))
        _oExWorkbook.Save()
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldedRELugWCDetails = _htTempRELugWCDetails
    End Sub

    Private Function GetLugLengthRE(ByVal dblSwingClearance As Double, ByVal dblLugWidth As Double, ByVal dblLugThickness As String) As Double

        Dim dblInnerRadius As Double = 0
        If dblLugThickness <= 0.5 Then
            dblInnerRadius = 0.25
        ElseIf dblLugThickness <= 0.625 Then
            dblInnerRadius = 0.5
        Else
            dblInnerRadius = 0.625
        End If

        GetLugLengthRE = 2 * ((dblLugWidth / 2) + dblSwingClearance + dblInnerRadius)

    End Function

#End Region

#End Region

#Region "Commented"

    'Private Function ChangeSheetNamesAndVisibility() As Boolean
    '    ChangeSheetNamesAndVisibility = False
    '    Try
    '        _oExcelSheet_MainAssembly.Name = CylinderCodeNumber

    '        If _blnIsNewTube Then
    '            If Not IsNothing(_strNewTubeName) Then
    '                _oExcelSheet_NewTube.Name = _strNewTubeName
    '            End If
    '            _oExcelSheet_NewTube.Visible = Excel.XlSheetVisibility.xlSheetVisible
    '        Else
    '            If Not IsNothing(_strNewTubeName) Then
    '                _oExcelSheet_NewTube.Name = _strNewTubeName
    '            End If
    '            _oExcelSheet_NewTube.Visible = Excel.XlSheetVisibility.xlSheetHidden
    '        End If

    '        If _blnIsNewRod Then
    '            If Not IsNothing(_strNewRodName) Then
    '                _oExcelSheet_NewRod.Name = _strNewRodName
    '            End If
    '            _oExcelSheet_NewRod.Visible = Excel.XlSheetVisibility.xlSheetVisible
    '        Else
    '            If Not IsNothing(_strNewRodName) Then
    '                _oExcelSheet_NewRod.Name = _strNewRodName
    '            End If
    '            _oExcelSheet_NewRod.Visible = Excel.XlSheetVisibility.xlSheetHidden
    '        End If

    '        ChangeSheetNamesAndVisibility = True
    '    Catch ex As Exception
    '        ChangeSheetNamesAndVisibility = False
    '    End Try
    'End Function
    'For Each oItem As Object In oWCStructureElement
    '    _oExcelSheet_NewTube.Range(cSNo + intTubeWCStartRange.ToString).Value = intSNo
    '    _oExcelSheet_NewTube.Range(cResource + intTubeWCStartRange.ToString).Value = oItem(StuctureElements.WorkCenter).ToString
    '    _oExcelSheet_NewTube.Range(cSetupRun_Standard + intTubeWCStartRange.ToString).Value = oItem(StuctureElements.SetupCost).ToString
    '    _oExcelSheet_NewTube.Range(cLaboreRate + intTubeWCStartRange.ToString).Value = oItem(StuctureElements.LabourCost).ToString
    '    _oExcelSheet_NewTube.Range(cFixedBurdenRate + intTubeWCStartRange.ToString).Value = oItem(StuctureElements.FixedBurdenCost).ToString
    '    _oExcelSheet_NewTube.Range(cVariableBurdenRate + intTubeWCStartRange.ToString).Value = oItem(StuctureElements.VariableBurdenCost).ToString
    'Next

    'Private Function DropDataToExcel() As Boolean
    '    DropDataToExcel = False
    '    Try
    '        If ExistingDataFunctionality() Then
    '            If PutDataToExcelCylinder() Then
    '                If PutDataToExcelTube() Then
    '                    DropDataToExcel = True
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        DropDataToExcel = False
    '    End Try
    'End Function   



    'Private Function DeleteEmptyRows() As Boolean
    '    DeleteEmptyRows = False
    '    Try
    '        Dim strRowCount As String = 6
    '        Dim strStart_EmptyCellRange As String = ""

    '        While (strRowCount > 0)
    '            If IsNothing(_oExcelSheet_MainAssembly.Range("A" + strRowCount).Value) Then
    '                strStart_EmptyCellRange = "A" + strRowCount
    '                Exit While
    '            End If
    '            strRowCount += 1
    '        End While

    '        While (IsNothing(_oExcelSheet_MainAssembly.Range("A" + strRowCount).Value))
    '            _oExcelSheet_MainAssembly.Range("A" + strRowCount, "A" + strRowCount).EntireRow.Delete()
    '        End While

    '        _oExWorkbook.Save()

    '        DeleteEmptyRows = True
    '    Catch ex As Exception
    '        DeleteEmptyRows = False
    '    End Try
    'End Function


#End Region

#End Region

End Class
