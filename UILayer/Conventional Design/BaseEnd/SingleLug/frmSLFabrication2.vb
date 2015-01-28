Imports System.IO

Public Class frmSLFabrication2

    'TODO: ANUP 22-07-2010 12.14pm
    Private _blnIsPopulated As Boolean = False

    Public Property IsPopulated() As Boolean
        Get
            Return _blnIsPopulated
        End Get
        Set(ByVal value As Boolean)
            _blnIsPopulated = value
        End Set
    End Property

#Region "Private Variables"

    Private _strClevisPlateCode As String

    Private _oFilterWithAreaDataTable As DataTable

    Private _strSingleLugCode As String

    Private _dblTempNutSafetyFactor As Double = 0

    Private _dblTempPinHoleSize As Double = 0

    Private _dblTempSwingClearance As Double = 0

    Private _dblWorkingPressure As Double = 0

    Private _intClass As Integer = 0

    Private _dblLugThickness As Double = 0

    Private _intSafetyFactorCount As Integer = 0

    Private _dblStandardClevisPlateRodStopDistance As Double

#End Region

#Region "Enum"

    Public Enum SingleLugListViewDetails
        CodeNumber = 0
        Description = 1
        Cost = 2
    End Enum

    Public Enum WeightListView
        SafetyFactor = 0
        LugThickness = 1
        Weight = 2
    End Enum

#End Region

#Region "Sub Procedures"

    Private Sub DefaultSettings()

        'ANUP 23-09-2010 START 
        ObjClsWeldedCylinderFunctionalClass.IsPlateClevisImported = False
        'ANUP 23-09-2010 TILL HERE

        txtLugHeight.Enabled = False
        txtLugThickness.Enabled = False
        txtLugGap.Enabled = False
        txtLugWidth.Enabled = False
        txtPinHoleSize.Enabled = False
        txtSwingClearance.Enabled = False

        txtRequiredLugHeight.Enabled = False
        txtRequiredLugGap.Enabled = False
        txtRequiredLugThickness.Enabled = False
        txtRequiredLugWidth.Enabled = False
        txtRequiredPinHoleSize.Enabled = False
        txtRequiredSwingClearance.Enabled = False

        btnAccept.Enabled = False
        txtSafetyFactor_DesignSingleLug.Enabled = False
        txtLugWidth_DesignSingleLug.Enabled = False
        txtLugThickness_DesignSingleLug.Enabled = True
        txtPinHoleSize_DesignSingleLug.Enabled = False
        txtSwingClearance_DesignSingleLug.Enabled = False

        SafetyFactor_LugThickness_Weight_GeneretedDesign()

        'Sandeep 25-02-10 10am
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
    End Sub

    'ONSITE: 26-05-2010 To disable the required tolerace and display the content
    Private Sub DisableReqPinToleranceControls()
        txtPinHoleTole_Neg_Req.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit
        txtPinHoleTole_Pos_Req.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit
        txtPinHoleTole_Pos_Req.Enabled = False
        txtPinHoleTole_Neg_Req.Enabled = False
        txtPinHoleTole_Pos.Enabled = False
        txtPinHoleTole_Neg.Enabled = False
    End Sub

    Private Sub LoadDefaultvalues()
        txtRequiredLugGap.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap
        txtRequiredLugThickness.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
        'txtRequiredLugWidth.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
        txtRequiredLugHeight.Text = "UnKnown"
        txtRequiredPinHoleSize.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
        txtRequiredSwingClearance.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance

        DisableReqPinToleranceControls()
        lvwSafetyFactor_Weight.Items.Clear() '10-05-2012 MANJULA ADDED
        _intSafetyFactorCount = 0 '10-05-2012 MANJULA ADDED

        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor <> _dblTempNutSafetyFactor _
       OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize <> _dblTempPinHoleSize _
       OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance <> _dblTempSwingClearance _
       OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure <> _dblWorkingPressure _
       OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass <> _intClass _
       OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness <> _dblLugThickness Then
            _dblTempNutSafetyFactor = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor
            _dblTempPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
            _dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
            _dblWorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure
            _intClass = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass
            _dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness

            ' ANUP 19-03-2010 11.00
            'lvwSafetyFactor_Weight.Items.Clear()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            '_intSafetyFactorCount = 0
            '***************

            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation _
           (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, Me.chkOptimizer.Checked, _
                       clsWeldedCylinderFunctionalClass.YeildStrengthConstants.SingleLug, "2")       '18_07_2012   RAGAVA
            'txtLugWidth_DesignSingleLug.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
            Dim GetLugWidthDataValue As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetLugWidthForComparision(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth)
            txtLugWidth_DesignSingleLug.Text = GetLugWidthDataValue

            txtLugThickness_DesignSingleLug.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
            txtPinHoleSize_DesignSingleLug.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
            txtSwingClearance_DesignSingleLug.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance

            trbSafetyFactor.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
            trbSafetyFactor.Maximum = trbSafetyFactor.Minimum + 20
            trbSafetyFactor.TickFrequency = 1
            trbSafetyFactor.Value = trbSafetyFactor.Minimum
            'TODO:Sunny 26-02-10
            Dim dblSafetyFactor As Double = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
            txtSafetyFactor_DesignSingleLug.Text = dblSafetyFactor

        End If
        txtRequiredLugWidth.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
    End Sub

    Private Sub SearchForExistingPlateClevis()
        Dim strClassType As String = ""
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional" Then
            strClassType = "ConventionalDesignClass"
        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
            strClassType = "NewDesignClass"
        End If
        strClassType += ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass

        Try

            '12_01_2012    RAGAVA
            Dim oClevisPlateDetails As DataTable = Nothing
            If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated" Then
                ObjClsWeldedCylinderFunctionalClass.GetClevisPlateDetails_WR(oClevisPlateDetails, "2")       '18_07_2012   RAGAVA
            Else
                oClevisPlateDetails = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
            GetPlateClevisDetails(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, _
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD)
            End If
            'Till   Here





            If Not IsNothing(oClevisPlateDetails) AndAlso oClevisPlateDetails.Rows.Count > 0 Then
                UcBrowsePlateClevis1.Visible = False
                btnPlateClevis.Visible = True
                Dim oPlateClevisDatarow As DataRow = oClevisPlateDetails.Rows(0)



                If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated" Then
                    _strClevisPlateCode = oPlateClevisDatarow("CodeNumber")
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ClevisPlate Code", _strClevisPlateCode)
                    '21_03_2012  RAGAVA
                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode = _strClevisPlateCode
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateImportOrExisting = "Existing"
                    '    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = 0.075 + oPlateClevisDatarow("PortDiameter") + 0.075 - 0.3
                    '        _dblStandardClevisPlateRodStopDistance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness - oPlateClevisDatarow("MinWallThickness") - oPlateClevisDatarow("ButtonHeight")
                    '    Else
                    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = oPlateClevisDatarow("TotalWidth") - 0.3
                    '        _dblStandardClevisPlateRodStopDistance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness - oPlateClevisDatarow("MinWallThickness") - oPlateClevisDatarow("ButtonHeight")
                    '    End If
                    'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode2 = _strClevisPlateCode
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2 = oPlateClevisDatarow("StandardClevisPlateThickness") - oPlateClevisDatarow("StandardClevisPlateRodStopDistance")
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateImportOrExisting2 = "Existing"
                    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2 = 0.075 + oPlateClevisDatarow("PortDiameter") + 0.075 - 0.3
                        _dblStandardClevisPlateRodStopDistance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2 - oPlateClevisDatarow("MinWallThickness") - oPlateClevisDatarow("ButtonHeight")
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2 = oPlateClevisDatarow("TotalWidth") - 0.3
                        _dblStandardClevisPlateRodStopDistance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2 - oPlateClevisDatarow("MinWallThickness") - oPlateClevisDatarow("ButtonHeight")
                    End If
                    'End If
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode = _strClevisPlateCode



                Else
                    _strClevisPlateCode = oPlateClevisDatarow("StandardClevisPlateCode") '06_04_2010 Aruna
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ClevisPlate Code", _strClevisPlateCode)

                    '21_03_2012  RAGAVA
                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode = _strClevisPlateCode
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = oPlateClevisDatarow("StandardClevisPlateThickness") - oPlateClevisDatarow("StandardClevisPlateRodStopDistance")
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateImportOrExisting = "Existing"
                    'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode2 = _strClevisPlateCode
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2 = oPlateClevisDatarow("StandardClevisPlateThickness") - oPlateClevisDatarow("StandardClevisPlateRodStopDistance")
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateImportOrExisting2 = "Existing"
                    'End If
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode = _strClevisPlateCode
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = oPlateClevisDatarow("StandardClevisPlateThickness") - oPlateClevisDatarow("StandardClevisPlateRodStopDistance") '06_04_2010 Aruna

                    _dblStandardClevisPlateRodStopDistance = oPlateClevisDatarow("StandardClevisPlateRodStopDistance")
                End If
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateImportOrExisting = "Existing"
            Else
                UcBrowsePlateClevis1.Visible = True
                btnPlateClevis.Visible = False
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ClevisPlate Code", "")
                ''21_03_2012  RAGAVA
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = 0
                '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateImportOrExisting = "Import"
                'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2 = 0
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateImportOrExisting2 = "Import"
                'End If


                _dblStandardClevisPlateRodStopDistance = 0


            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ClevisPlate Code", "")
            ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode = 0
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2 = 0
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in SearchForExistingPlateClevis of frmSLFabrication " + ex.Message)
        End Try
    End Sub

    Private Sub SearchForExistingSingleLug()
        ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation(ObjClsWeldedCylinderFunctionalClass. _
                                            ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, False, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.SingleLug, "2")       '18_07_2012   RAGAVA

        Dim dblBushingWidth As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth
        Dim dblRequiredLugThickness As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
        Dim dblRequiredPinHoleSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
        Dim dblBushingQuantity As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity
        Dim dblRequiredLugGap As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap
        Dim strPinWithInTubeDia As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinWithInTubeDiameter
        Dim dblTubeOD As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD
        Dim dblRequiredSwingClearance As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance

        Try
            Dim oSingleLugDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
            BESingleLUgDetails(dblBushingQuantity, dblBushingWidth, dblRequiredPinHoleSize, dblRequiredLugThickness, strPinWithInTubeDia, dblTubeOD, dblRequiredSwingClearance, "Base End", "2")       '18_07_2012   RAGAVA

            If Not IsNothing(oSingleLugDataTable) AndAlso oSingleLugDataTable.Rows.Count > 0 Then

                'TODO:Anup 09-04-10 2pm
                oSingleLugDataTable.Columns.Add("CalculatedSafetyFactor")
                '*************************

                For Each oFilterWithAreaDataRow As DataRow In oSingleLugDataTable.Rows
                    oFilterWithAreaDataRow("Area") = Math.Round((oFilterWithAreaDataRow("Width") - dblRequiredPinHoleSize) * oFilterWithAreaDataRow("Thickness"), 2) '* 2
                Next

                _oFilterWithAreaDataTable = New DataTable
                _oFilterWithAreaDataTable = oSingleLugDataTable.Clone
                For Each oFilterWithAreaDataRow2Row As DataRow In oSingleLugDataTable.Rows
                    ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation(ObjClsWeldedCylinderFunctionalClass. _
                    ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, False, oFilterWithAreaDataRow2Row("YieldStrength"), "2")       '18_07_2012   RAGAVA   '12_11_2009  Ragava
                    Dim dblRequiredArea As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired

                    'TODO:Anup 09-04-10 2pm
                    oFilterWithAreaDataRow2Row("CalculatedSafetyFactor") = Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor + (oFilterWithAreaDataRow2Row("Area") / dblRequiredArea), 2) - 1
                    '*************************

                    If Val(oFilterWithAreaDataRow2Row("Area")) >= dblRequiredArea Then 'AndAlso Val(oFilterWithAreaDataRow2Row("Area")) <= Val(dblRequiredArea * 1.25) Then  '05_04_2010   RAGAVA
                        _oFilterWithAreaDataTable.Rows.Add(oFilterWithAreaDataRow2Row.ItemArray)
                    End If
                Next

                If Not IsNothing(_oFilterWithAreaDataTable) AndAlso _oFilterWithAreaDataTable.Rows.Count > 0 Then
                    grbMatchedSingleLugsFound.Visible = True
                    grbMatchedSingleLugNotFound.Visible = False
                    PopulateDataInListView()
                Else
                    lvwExistingSingleLugListView.Clear()
                    grbMatchedSingleLugNotFound.Visible = True
                    grbMatchedSingleLugsFound.Visible = False
                    Try
                        ObjClsWeldedCylinderFunctionalClass.ObjClsExcelClass.checkExcelInstance()
                        ObjClsWeldedCylinderFunctionalClass.WriteGUIDataToExcel()
                    Catch ex As Exception
                    End Try

                End If
            Else
                lvwExistingSingleLugListView.Clear()
                grbMatchedSingleLugNotFound.Visible = True
                grbMatchedSingleLugsFound.Visible = False
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in SearchForExistingSingleLug of frmSLFabrication " + ex.Message)
        End Try
    End Sub

    Private Sub LoadFunctionality()
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        LoadDefaultvalues()
        SearchForExistingPlateClevis()
        SearchForExistingSingleLug()
        ValidLugThickness() '13_11_2009  Ragava
    End Sub

    Public Sub ManualLoad()
        LoadFunctionality()
    End Sub

    Private Sub PopulateDataInListView()
        Try
            lvwExistingSingleLugListView.Clear()
            lvwExistingSingleLugListView.Columns.Add("Code No", 100, HorizontalAlignment.Center)
            lvwExistingSingleLugListView.Columns.Add("Description", 245, HorizontalAlignment.Center)

            'TODO:Anup 09-04-10 2pm
            lvwExistingSingleLugListView.Columns.Add("SafetyFactor", 100, HorizontalAlignment.Center)
            '***********

            lvwExistingSingleLugListView.Columns.Add("Cost", 100, HorizontalAlignment.Center)
            lvwExistingSingleLugListView.Columns.Add("Sales", 100, HorizontalAlignment.Center)        '28_11_2012   RAGAVA
            Dim intCount As Integer = 0
            Dim oListItem As ListViewItem

            'ANUP 07-10-2010 START
            If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Count > 0 Then
                ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Clear()
            End If
            'ANUP 07-10-2010 TILL HERE 

            For Each oFilterWithAreaDataRow As DataRow In _oFilterWithAreaDataTable.Rows
                Dim strPartCode_Purchase As String = String.Empty       '31_05_2011  RAGAVA
                If Not IsDBNull(oFilterWithAreaDataRow("PartCode")) Then
                    'ANUP 07-10-2010 START
                    strPartCode_Purchase = ObjClsWeldedCylinderFunctionalClass.PartCOde_Purchased_ListViewClickedValidation(oFilterWithAreaDataRow("PartCode"))
                    oListItem = lvwExistingSingleLugListView.Items.Add(strPartCode_Purchase)
                    'ANUP 07-10-2010 TILL HERE
                Else
                    lvwExistingSingleLugListView.Items.Add("")
                End If

                If Not IsDBNull(oFilterWithAreaDataRow("Description")) Then
                    lvwExistingSingleLugListView.Items(intCount).SubItems.Add(oFilterWithAreaDataRow("Description"))
                Else
                    lvwExistingSingleLugListView.Items(intCount).SubItems.Add("")
                End If



                '31_05_2011  RAGAVA
                Try
                    Dim dblSafetyFactor As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SetSafetyFactorForExisting(strPartCode_Purchase)
                    If dblSafetyFactor > 0 Then
                        lvwExistingSingleLugListView.Items(intCount).SubItems.Add(dblSafetyFactor.ToString)
                    Else
                        If Not IsDBNull(oFilterWithAreaDataRow("CalculatedSafetyFactor")) Then
                            lvwExistingSingleLugListView.Items(intCount).SubItems.Add(oFilterWithAreaDataRow("CalculatedSafetyFactor"))
                        Else
                            lvwExistingSingleLugListView.Items(intCount).SubItems.Add("")
                        End If
                    End If
                Catch ex As Exception

                End Try
                ''TODO:Anup 09-04-10 2pm
                'If Not IsDBNull(oFilterWithAreaDataRow("CalculatedSafetyFactor")) Then
                '    lvwExistingSingleLugListView.Items(intCount).SubItems.Add(oFilterWithAreaDataRow("CalculatedSafetyFactor"))
                'Else
                '    lvwExistingSingleLugListView.Items(intCount).SubItems.Add("")
                'End If
                ''***************
                'TILL   HERE

                '28_11_2012  RAGAVA
                Try
                    ObjClsWeldedCylinderFunctionalClass.GetCost_Sales(oFilterWithAreaDataRow("PartCode"), lvwExistingSingleLugListView, intCount)
                Catch ex As Exception

                End Try
                'If Not IsDBNull(oFilterWithAreaDataRow("Cost")) Then
                '    lvwExistingSingleLugListView.Items(intCount).SubItems.Add(oFilterWithAreaDataRow("Cost"))
                'Else
                '    lvwExistingSingleLugListView.Items(intCount).SubItems.Add("")
                'End If
                'Till   Here
                If Not IsDBNull(oFilterWithAreaDataRow("IFLID")) Then
                    lvwExistingSingleLugListView.Items(intCount).SubItems.Add(oFilterWithAreaDataRow("IFLID"))
                Else
                    lvwExistingSingleLugListView.Items(intCount).SubItems.Add("")
                End If
                intCount += 1
            Next
            lvwExistingSingleLugListView.Items(0).Selected = True
            lvwExistingSingleLugListView.HideSelection = False
            lvwExistingSingleLugListView.FullRowSelect = True
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in PopulateDataInListView of frmSLFabrication " + ex.Message)
        End Try
    End Sub

    Private Sub WidthCalculation()
        Try
            Dim dblSafetyFactor As Double = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
            txtSafetyFactor_DesignSingleLug.Text = dblSafetyFactor
            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation(dblSafetyFactor, Me.chkOptimizer.Checked, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.SingleLug, "2")       '18_07_2012   RAGAVA
            txtLugWidth_DesignSingleLug.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
        Catch ex As Exception
        End Try
    End Sub

    '13_11_2009  Ragava
    Private Sub ValidLugThickness()
        Try
            Dim ObjDt As DataTable
            Dim dblMaxLugThickness As Double = 0
            Dim dblLugThickNess As Double = Val(txtLugThickness_DesignSingleLug.Text)

            Try
                Dim oDesignSingleLugDataTable As DataTable
                oDesignSingleLugDataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetTableDetails("Select * from Welded.DesignULugValidDetails")

                If Not IsNothing(oDesignSingleLugDataTable) Then
                    For Each dr As DataRow In oDesignSingleLugDataTable.Rows
                        If dblMaxLugThickness < dr("ULugThickness") Then
                            dblMaxLugThickness = dr("ULugThickness")
                        End If
                    Next
                End If
            Catch ex As Exception
            End Try

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" Then
                dblMaxLugThickness = 2
            End If

            If dblMaxLugThickness < dblLugThickNess Then
                MessageBox.Show("No Material Available After LugThickness 2 ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                txtLugThickness_DesignSingleLug.Text = dblMaxLugThickness.ToString
            Else
                ObjDt = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetTableDetails("Select top 1 * from Welded.DesignULugValidDetails Where ULugThickness >= " + dblLugThickNess.ToString)
                ObjClsWeldedCylinderFunctionalClass.BendRadius = ObjDt.Rows(0)("BendRadius")
                txtLugThickness_DesignSingleLug.Text = ObjDt.Rows(0)("ULugThickness")
            End If
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness_DesignSingleLug.Text)
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2 = Val(txtLugThickness_DesignSingleLug.Text)
            'End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in ValidLugThickness of frmSLFabrication " + ex.Message)
        End Try
        '13_11_2009 Ragava Till Here
    End Sub

    Private Sub SafetyFactor_LugThickness_Weight_GeneretedDesign()
        lvwSafetyFactor_Weight.Clear()
        lvwSafetyFactor_Weight.Columns.Add("SafetyFactor", 130, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight.Columns.Add("LugThickness", 130, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight.Columns.Add("Weight", 125, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight.FullRowSelect = True
    End Sub

#End Region

#Region "Events"

    Private Sub frmFabrication_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        DefaultSettings()
        LoadFunctionality()
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            'To be verified assumed



            'If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated" Then
            '    _strClevisPlateCode = oPlateClevisDatarow("CodeNumber")
            '    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ClevisPlate Code", _strClevisPlateCode)
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode = _strClevisPlateCode
            '    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
            '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = 0.075 + oPlateClevisDatarow("PortDiameter") + 0.075 - 0.3
            '        _dblStandardClevisPlateRodStopDistance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness - oPlateClevisDatarow("MinWallThickness") - oPlateClevisDatarow("ButtonHeight")
            '    Else
            '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = oPlateClevisDatarow("TotalWidth") - 0.3
            '        _dblStandardClevisPlateRodStopDistance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness - oPlateClevisDatarow("MinWallThickness") - oPlateClevisDatarow("ButtonHeight")
            '    End If

            'Else
            '    _strClevisPlateCode = oPlateClevisDatarow("StandardClevisPlateCode")
            '    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ClevisPlate Code", _strClevisPlateCode)
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode = _strClevisPlateCode
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = oPlateClevisDatarow("StandardClevisPlateThickness") - oPlateClevisDatarow("StandardClevisPlateRodStopDistance")
            '    _dblStandardClevisPlateRodStopDistance = oPlateClevisDatarow("StandardClevisPlateRodStopDistance")
            'End If


            If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2 = -0.125
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2 = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2 'TODO: ANUP 02-06-2010
            End If
            If txtSafetyFactor_DesignSingleLug.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd2 = txtSafetyFactor_DesignSingleLug.Text
            End If

            If txtLugThickness_DesignSingleLug.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd.Text = txtLugThickness_DesignSingleLug.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2 = Val(txtLugThickness_DesignSingleLug.Text)       '18_07_2012   RAGAVA
            End If
            If txtSwingClearance_DesignSingleLug.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2 = Val(txtSwingClearance_DesignSingleLug.Text)       '18_07_2012   RAGAVA
            End If
            If txtLugWidth_DesignSingleLug.Text <> "" Then
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugWidth_DesignSingleLug.Text)
                'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2 = Val(txtLugWidth_DesignSingleLug.Text)
                'End If
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugWidth_DesignSingleLug.Text)
            End If

            '02_03_2010 Aruna
            Dim dblLugHeight As Double
            dblLugHeight = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2 + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2 / 2)
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.lugHeight_BaseEnd = dblLugHeight

            '20_01_2012   RAGAVA
            Try
                If ObjClsWeldedCylinderFunctionalClass.WeldSize_Validation_SL_BaseEnd() Then
                    Exit Try
                End If
            Catch ex As Exception
            End Try
            'Till    Here


            Dim strFilePart As String = ""
            Dim strFilePartDesignTableExcel As String = ""
            strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_SINGLE_LUG\Base_Single_Lug_IFL.SLDPRT"
            '24_02_2010 Aruna  single Line Start
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BASE_SINGLE_LUG_IFL"
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart = "BASE_SINGLE_LUG_IFL"        '18_07_2012   RAGAVA
            strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BASE_SINGLE_LUG.xls"
            ObjClsWeldedCylinderFunctionalClass.Design_New_Part(strFilePart, strFilePartDesignTableExcel, "NewSingleLugFabrication")
            Dim dblWeight As Double = ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Weight")
            'Aruna 19_3_2010
            ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_SINGLE_LUG", True)
            Dim blnDuplicateFound As Boolean = False
            If lvwSafetyFactor_Weight.Items.Count > 0 Then
                For Each oItem As ListViewItem In lvwSafetyFactor_Weight.Items
                    If oItem.SubItems(WeightListView.SafetyFactor).Text.Equals(txtSafetyFactor_DesignSingleLug.Text) AndAlso _
                     oItem.SubItems(WeightListView.LugThickness).Text.Equals(txtLugThickness_DesignSingleLug.Text) AndAlso oItem.SubItems(WeightListView.Weight).Text.Equals(dblWeight.ToString) Then         '28_10_2010   RAGAVA
                        blnDuplicateFound = True
                    End If
                Next
            End If
            If Not blnDuplicateFound Then
                Dim oListViewItem As ListViewItem
                oListViewItem = lvwSafetyFactor_Weight.Items.Add(txtSafetyFactor_DesignSingleLug.Text)
                lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(txtLugThickness_DesignSingleLug.Text)
                lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(dblWeight)
                _intSafetyFactorCount += 1
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in btnGenerate_Click of frmSLFabrication " + ex.Message)
        End Try
    End Sub

    Private Sub trbSafetyFactor_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trbSafetyFactor.Scroll
        For Each oItem As ListViewItem In lvwSafetyFactor_Weight.Items
            oItem.Selected = False
        Next
    End Sub

    Private Sub trbSafetyFactor_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trbSafetyFactor.ValueChanged
        btnAccept.Enabled = False
        WidthCalculation()
    End Sub

    Private Sub txtLugThickness_DesignULug_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLugThickness_DesignSingleLug.Leave
        If txtLugThickness_DesignSingleLug.Text <> "" Then
            If txtLugThickness_DesignSingleLug.Text <> txtLugThickness_DesignSingleLug.IFLDataTag Then
                txtLugThickness_DesignSingleLug.IFLDataTag = txtLugThickness_DesignSingleLug.Text

                ValidLugThickness() '13_11_2009  Ragava

                trbSafetyFactor.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
                trbSafetyFactor.Maximum = trbSafetyFactor.Minimum + 20
                trbSafetyFactor.TickFrequency = 1
                trbSafetyFactor.Value = trbSafetyFactor.Minimum
                Dim dblSafetyFactor As Double = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
                txtSafetyFactor_DesignSingleLug.Text = dblSafetyFactor
            End If
        Else
            txtLugThickness_DesignSingleLug.IFLDataTag = ""
        End If
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewFabricationGenerated = True             '17_10_2012   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndFabrication_New = True   '18_07_2012   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationTable = "Welded.BESingleLugDetails"   '18_07_2012   RAGAVA
        If txtSafetyFactor_DesignSingleLug.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd2 = txtSafetyFactor_DesignSingleLug.Text
        End If

        If txtLugThickness_DesignSingleLug.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd.Text = txtLugThickness_DesignSingleLug.Text
        End If
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False        '20_10_2010   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        btnAccept.Enabled = False
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign2 = "NewDesign"
        'MANJULA ADDED
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then
            ObjClsWeldedCylinderFunctionalClass.ObjFrmSLPortIntegral._dblTempLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
            ObjClsWeldedCylinderFunctionalClass.ObjFrmSLPortIntegral2._dblTempLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
            ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
            ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral2.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2

        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
            ObjClsWeldedCylinderFunctionalClass.ObjFrmSLPortinTube._dblTempLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
            ObjClsWeldedCylinderFunctionalClass.ObjFrmSLPortinTube2._dblTempLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
            ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2
            ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube2.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2

        End If
    End Sub

    Private Sub lvwSafetyFactor_Weight_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwSafetyFactor_Weight.SelectedIndexChanged
        If lvwSafetyFactor_Weight.SelectedIndices.Count > 0 Then
            Dim oListViewSelectedItem As ListViewItem = lvwSafetyFactor_Weight.SelectedItems(0)
            trbSafetyFactor.Value = ((Val(oListViewSelectedItem.SubItems(WeightListView.SafetyFactor).Text) - trbSafetyFactor.Minimum) / 0.25) + trbSafetyFactor.Minimum
            txtLugThickness_DesignSingleLug.Text = oListViewSelectedItem.SubItems(WeightListView.LugThickness).Text
            btnAccept.Enabled = True
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            ObjClsWeldedCylinderFunctionalClass.BaseEndWeight = Val(oListViewSelectedItem.SubItems(WeightListView.Weight).Text)
        End If
    End Sub

    '13_11_2009   Ragava
    Private Sub txtLugWidth_DesignSingleLug_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLugWidth_DesignSingleLug.TextChanged
        If txtLugWidth_DesignSingleLug.Text <> "" Then
            If txtLugWidth_DesignSingleLug.Text <> txtLugWidth_DesignSingleLug.IFLDataTag Then
                txtLugWidth_DesignSingleLug.IFLDataTag = txtLugWidth_DesignSingleLug.Text
                Try
                    Dim ObjDt As DataTable
                    Dim dblLugWidth As Double = Val(txtLugWidth_DesignSingleLug.Text)
                    Dim dblMaxLugWidth As Double = 0

                    Try
                        Dim oDesignSingleLugDataTable As DataTable  '13_11_2009   Ragava
                        oDesignSingleLugDataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetTableDetails("Select * from Welded.DesignULugValidDetails")

                        If Not IsNothing(oDesignSingleLugDataTable) Then
                            For Each dr As DataRow In oDesignSingleLugDataTable.Rows
                                If dblMaxLugWidth < dr("ULugWidth") Then
                                    dblMaxLugWidth = dr("ULugWidth")
                                End If
                            Next
                        End If
                    Catch ex As Exception
                    End Try

                    If dblMaxLugWidth < dblLugWidth Then
                        MessageBox.Show("No Material Available After LugWidth 3.50", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                        trbSafetyFactor.Value = trbSafetyFactor.Value - 1
                        Dim dblSafetyFactor As Double = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
                        txtSafetyFactor_DesignSingleLug.Text = dblSafetyFactor
                    Else
                        ObjDt = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetTableDetails("Select top 1 * from Welded.DesignULugValidDetails Where ULugWidth >= " + dblLugWidth.ToString)
                        ObjClsWeldedCylinderFunctionalClass.TopRadius = ObjDt.Rows(0)("TopRadius")
                        txtLugWidth_DesignSingleLug.Text = ObjDt.Rows(0)("ULugWidth")
                        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugWidth_DesignSingleLug.Text)
                        'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2 = Val(txtLugWidth_DesignSingleLug.Text)
                        'End If
                        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugWidth_DesignSingleLug.Text)
                    End If
                Catch oException As Exception
                    ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in txtLugWidth_DesignSingleLug_TextChanged of frmSLFabrication " + oException.Message)
                End Try
            End If
        Else
            txtLugWidth_DesignSingleLug.IFLDataTag = ""
        End If
    End Sub

    Private Sub lvwExistingSingleLugListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwExistingSingleLugListView.SelectedIndexChanged
        'ANUP 10-11-2010 START
        rdbUseSelectedSingleLug.Checked = False
        rdbDesignaSingleLug.Checked = False
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        'ANUP 10-11-2010 TILL HERE
        Try
            If lvwExistingSingleLugListView.SelectedIndices.Count > 0 Then
                'Sandeep 25-02-10 10am
                If rdbUseSelectedSingleLug.Checked = False Then
                    ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
                End If

                Dim oListViewSelectedItem As ListViewItem = lvwExistingSingleLugListView.SelectedItems(0)

                'ANUP 07-10-2010 START
                Dim strPartCodePassing_Purchased As String = oListViewSelectedItem.SubItems(SingleLugListViewDetails.CodeNumber).Text
                Try
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd2 = oListViewSelectedItem.SubItems(2).Text      '31_05_2011   ragava
                Catch ex As Exception
                End Try
                ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode2 = strPartCodePassing_Purchased         '12_10_2010   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.ContainsKey(strPartCodePassing_Purchased) Then
                    strPartCodePassing_Purchased = ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Item(strPartCodePassing_Purchased).ToString
                End If

                '25_10_2010   RAGAVA
                ''If ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode.StartsWith("7") Then
                ''    ObjClsWeldedCylinderFunctionalClass.DisplayImage("X:\WeldedModels\" & ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode & ".SLDPRT")
                ''End If
                'Till   Here

                Dim oSelectedULugDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                GetBESingleLDetailsSelectedRowDetails(strPartCodePassing_Purchased)
                If Not IsNothing(oSelectedULugDataRow) Then
                    Try

                        If Not IsDBNull(oSelectedULugDataRow("PartCode")) Then
                            _strSingleLugCode = oListViewSelectedItem.SubItems(SingleLugListViewDetails.CodeNumber).Text
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2 = oSelectedULugDataRow("PartCode")
                            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("SingleLug Code", _strSingleLugCode)
                        End If
                        'ANUP 07-10-2010 TILL HERE


                        '24_02_2010 Aruna Start
                        If oSelectedULugDataRow("PartType").ToString.Contains("IFL_PART") Then
                            ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "IFL_Designed_Existing"
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign2 = "NewDesign"
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BASE_SINGLE_LUG_IFL"
                        Else
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign2 = "Existing"
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "Base_Lug_single"
                        End If
                        '24_02_2010 Aruna End

                        If Not IsDBNull(oSelectedULugDataRow("PinHole_Combined")) Then
                            txtPinHoleSize.Text = oSelectedULugDataRow("PinHole_Combined")
                        End If

                        If Not IsDBNull(oSelectedULugDataRow("Thickness")) Then
                            txtLugThickness.Text = oSelectedULugDataRow("Thickness")
                        End If

                        Dim dblLugHeight As Double
                        Dim dblLugWidth As Double

                        If Not IsDBNull(oSelectedULugDataRow("Height")) Then
                            txtLugHeight.Text = oSelectedULugDataRow("Height")
                            dblLugHeight = oSelectedULugDataRow("Height")
                        End If

                        If Not IsDBNull(oSelectedULugDataRow("Width")) Then
                            txtLugWidth.Text = oSelectedULugDataRow("Width")
                            dblLugWidth = oSelectedULugDataRow("Width")
                        End If

                        DisplayToleranceValues(oSelectedULugDataRow)

                        txtSwingClearance.Text = dblLugHeight - (dblLugWidth / 2)

                        'If Not IsDBNull(oSelectedULugDataRow("LugGap")) Then
                        '    txtLugGap.Text = oSelectedULugDataRow("LugGap")
                        'End If

                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2 = _dblStandardClevisPlateRodStopDistance
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2 = _
                        Val(txtSwingClearance.Text) + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2
                    Catch ex As Exception

                    End Try
                End If
            Else
                _strSingleLugCode = ""
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("SingleLug Code", "")
                txtPinHoleSize.Text = ""
                txtLugHeight.Text = ""
                txtLugThickness.Text = ""
                txtLugWidth.Text = ""
                txtSwingClearance.Text = ""
                txtLugGap.Text = ""
                txtPinHoleTole_Neg.Text = ""
                txtPinHoleTole_Pos.Text = ""
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2 = 0
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2 = 0
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2 = 0
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in lvwExistingSingleLugListView_SelectedIndexChanged of frmSLFabrication " + ex.Message)
        End Try
    End Sub

    'ONSITE:20-05-2010 assign  the tolerance data to GUI fields
    Private Sub DisplayToleranceValues(ByVal oRow As DataRow)
        'Positive tolerance
        If Not IsDBNull(oRow("PinHoleCustomUpperTolerance")) Then
            If oRow("PinHoleCustomUpperTolerance").Equals("N/A") Then
                txtPinHoleTole_Pos.Text = "0.010"
            Else
                txtPinHoleTole_Pos.Text = oRow("PinHoleCustomUpperTolerance")
            End If
        End If
        'Negative Tolerance
        If Not IsDBNull(oRow("PinHoleCustomLowerTolerance")) Then
            If oRow("PinHoleCustomLowerTolerance").Equals("N/A") Then
                txtPinHoleTole_Neg.Text = 0.005
            Else
                txtPinHoleTole_Neg.Text = oRow("PinHoleCustomLowerTolerance")
            End If
        End If
    End Sub

    'Private Sub rdbUseSelectedSingleLug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedSingleLug.CheckedChanged, rdbDesignaSingleLug.CheckedChanged
    '    ' Sandeep 25-02-10 10am
    '    Dim strMessage As String = "Base end Configuration will be updated with the selected SingleLug Fabrication details, " + vbCrLf
    '    If MessageBox.Show(strMessage, "Update TubeDetails", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then

    '        ' Sandeep 25-02-10 10am
    '        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True

    '        If txtLugThickness.Text <> "" Then
    '            ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd.Text = txtLugThickness.Text
    '        End If

    '        If txtSwingClearance.Text <> "" Then
    '            ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text = txtSwingClearance.Text
    '        End If

    '        If txtLugGap.Text <> "" Then
    '            ObjClsWeldedCylinderFunctionalClass.TxtLugGap_BaseEnd.Text = txtLugGap.Text
    '        End If

    '        If txtLugWidth.Text <> "" Then
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugWidth.Text)
    '        End If

    '        If ObjClsWeldedCylinderFunctionalClass.PinHoleSize_Source = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.BushingPinHole Then
    '            If txtPinHoleSize.Text <> "" Then
    '                ObjClsWeldedCylinderFunctionalClass.CmbBushingPinHoleSize_BaseEnd.Text = txtPinHoleSize.Text
    '            End If
    '        ElseIf ObjClsWeldedCylinderFunctionalClass.PinHoleSize_Source = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleCustom Then
    '            If txtPinHoleSize.Text <> "" Then
    '                ObjClsWeldedCylinderFunctionalClass.TxtPinHoleSize_BaseEnd.Text = txtPinHoleSize.Text
    '            End If
    '        ElseIf ObjClsWeldedCylinderFunctionalClass.PinHoleSize_Source = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleStandard Then
    '            If txtPinHoleSize.Text <> "" Then
    '                ObjClsWeldedCylinderFunctionalClass.CmbPinHoleSize_BaseEnd.Text = txtPinHoleSize.Text
    '            End If
    '        End If
    '        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = ""    '03_03_2010    ARUNA
    '        If rdbUseSelectedSingleLug.Checked Then
    '            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Exact"
    '            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
    '        ElseIf rdbDesignaSingleLug.Checked Then
    '            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "NewDesign"
    '            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
    '        End If
    '    End If
    'End Sub

    'TODO: ANUP 20-05-2010
    Private Sub rdbUseSelectedSingleLug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedSingleLug.CheckedChanged
        If rdbUseSelectedSingleLug.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewFabricationGenerated = False             '17_10_2012   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = True        '20_10_2010    RAGAVA
            ' Sandeep 25-02-10 10am
            '--------------------------------------------------------------------------------------------------------------------------------------------------------------------009
            Dim strMessage As String = "Base end Configuration will be updated with the selected SingleLug Fabrication details, " + vbCrLf
            If MessageBox.Show(strMessage, "Update TubeDetails", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Or ObjClsWeldedCylinderFunctionalClass.MultiGenerate = True Then

                ' Sandeep 25-02-10 10am
                ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True

                If txtLugThickness.Text <> "" Then
                    '20_04_2012  RAGAVA
                    'ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd.Text = txtLugThickness.Text
                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness_DesignSingleLug.Text)
                    'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2 = Val(txtLugThickness_DesignSingleLug.Text)
                    'End If
                    ''Till   Here
                End If

                If txtSwingClearance.Text <> "" Then
                    ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text = txtSwingClearance.Text
                End If

                If txtLugGap.Text <> "" Then
                    ObjClsWeldedCylinderFunctionalClass.TxtLugGap_BaseEnd.Text = txtLugGap.Text
                End If

                If txtLugWidth.Text <> "" Then
                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugWidth.Text)
                    'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2 = Val(txtLugWidth.Text)
                    'End If
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugWidth.Text)
                End If

                If ObjClsWeldedCylinderFunctionalClass.PinHoleSize_Source = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.BushingPinHole Then
                    If txtPinHoleSize.Text <> "" Then
                        ObjClsWeldedCylinderFunctionalClass.CmbBushingPinHoleSize_BaseEnd.Text = txtPinHoleSize.Text
                    End If
                ElseIf ObjClsWeldedCylinderFunctionalClass.PinHoleSize_Source = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleCustom Then
                    If txtPinHoleSize.Text <> "" Then
                        ObjClsWeldedCylinderFunctionalClass.TxtPinHoleSize_BaseEnd.Text = txtPinHoleSize.Text
                    End If
                ElseIf ObjClsWeldedCylinderFunctionalClass.PinHoleSize_Source = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleStandard Then
                    If txtPinHoleSize.Text <> "" Then
                        ObjClsWeldedCylinderFunctionalClass.CmbPinHoleSize_BaseEnd.Text = txtPinHoleSize.Text
                    End If
                End If
                ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize2 = ""    '03_03_2010    ARUNA

                ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize2 = "Exact"
                ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True

                'anup 30-08-2010
                If Not String.IsNullOrEmpty(txtPinHoleTole_Pos.Text) Then
                    ObjClsWeldedCylinderFunctionalClass.TxtToleranceUpperLimit.Text = txtPinHoleTole_Pos.Text
                End If
                If Not String.IsNullOrEmpty(txtPinHoleTole_Neg.Text) Then
                    ObjClsWeldedCylinderFunctionalClass.TxtToleranceLowerLimit.Text = txtPinHoleTole_Neg.Text
                End If
            End If
            ''14_03_2012  RAGAVA
            'If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.rdbFabrication.Checked Then
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated"
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISFabricationChecked = True
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = False
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2 = "Fabricated"
            'End If
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BESingleLugDetails"
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BESingleLugDetails"
            'End If
            'MANJULA ADDED
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then


                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLPortIntegral._dblTempLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLPortIntegral._dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text

                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLPortIntegral2._dblTempLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLPortIntegral2._dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text

                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text

                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral2.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral2.dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text


            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLPortinTube._dblTempLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLPortinTube._dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text

                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLPortinTube2._dblTempLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLPortinTube2._dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text

                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text

                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube2.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube2.dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text

            End If
        End If
    End Sub
    '*************

    'TODO: ANUP 20-05-2010
    Private Sub rdbDesignaSingleLug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDesignaSingleLug.CheckedChanged
        If rdbDesignaSingleLug.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False        '20_10_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "NewDesign"
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False

            Dim strMessage As String = "Click OK to go to the Single Lug Design screens "
            If MessageBox.Show(strMessage, "Design Single Lug", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.OK Then
                grbMatchedSingleLugsFound.Hide()
                grbMatchedSingleLugNotFound.Show()
                grbMatchedSingleLugNotFound.BringToFront()
            Else
                rdbDesignaSingleLug.Checked = False
            End If

        End If
    End Sub
    '*************

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblDesignNewCasting)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblSafetyFactorIndex)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblExistingSingleLugsDetails)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblShowImage)
    End Sub

    Private Sub chkOptimizer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOptimizer.CheckedChanged
        Try
            WidthCalculation()
        Catch ex As Exception

        End Try
    End Sub
End Class