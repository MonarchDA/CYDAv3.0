Imports System.IO

Public Class frmDLFabrication

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

    Private _strULugCode As String

    Private _oFilterWithAreaDataTable As DataTable

    Private _oDataTableDesignULug As DataTable             '13_11_2009   Ragava

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

    Public Enum ULugListViewDetails
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
        ObjClsWeldedCylinderFunctionalClass.IsPlateClevisImported = False
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
        txtSafetyFactor_DesignULug.Enabled = False
        txtLugGap_DesignULug.Enabled = False
        txtLugWidth_DesignULug.Enabled = False
        txtLugThickness_DesignULug.Enabled = True
        txtPinHoleSize_DesignULug.Enabled = False
        txtSwingClearance_DesignULug.Enabled = False

        SafetyFactor_LugThickness_Weight_GeneretedDesign()
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
    End Sub

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
        txtRequiredLugWidth.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
        txtRequiredLugHeight.Text = "UnKnown"
        txtRequiredPinHoleSize.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
        txtRequiredSwingClearance.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
        DisableReqPinToleranceControls()
        lvwSafetyFactor_Weight.Items.Clear() 'MANJULA ADDED
        _intSafetyFactorCount = 0
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

            'lvwSafetyFactor_Weight.Items.Clear()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            '_intSafetyFactorCount = 0

            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, Me.chkOptimizer.Checked, _
           clsWeldedCylinderFunctionalClass.YeildStrengthConstants.ULug)
            txtLugGap_DesignULug.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap
            txtLugWidth_DesignULug.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
            txtLugThickness_DesignULug.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
            txtPinHoleSize_DesignULug.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
            txtSwingClearance_DesignULug.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance

            trbSafetyFactor.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
            trbSafetyFactor.Maximum = trbSafetyFactor.Minimum + 20
            trbSafetyFactor.TickFrequency = 1
            trbSafetyFactor.Value = trbSafetyFactor.Minimum

            Dim dblSafetyFactor As Double = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
            txtSafetyFactor_DesignULug.Text = dblSafetyFactor
        End If
    End Sub

    Public Sub SearchForExistingPlateClevis()
        Dim strClassType As String = ""
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional" Then
            strClassType = "ConventionalDesignClass"
        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
            strClassType = "NewDesignClass"
        End If
        strClassType += ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass


        '12_01_2012    RAGAVA
        Dim oClevisPlateDetails As DataTable = Nothing
        If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated" Then
            ObjClsWeldedCylinderFunctionalClass.GetClevisPlateDetails_WR(oClevisPlateDetails)
        Else
            oClevisPlateDetails = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
          GetPlateClevisDetails(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, _
         ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD)
        End If
        'Till   Here
        Try
            If Not IsNothing(oClevisPlateDetails) AndAlso oClevisPlateDetails.Rows.Count > 0 Then
                Try
                    ObjClsWeldedCylinderFunctionalClass.objfrmFabricatedSingleLug.UcBrowsePlateClevis1.Visible = False
                    ObjClsWeldedCylinderFunctionalClass.objfrmFabricatedSingleLug.btnPlateClevis.Visible = True
                Catch ex As Exception

                End Try
                UcBrowsePlateClevis1.Visible = False
                btnPlateClevis.Visible = True
                Dim oPlateClevisDatarow As DataRow = oClevisPlateDetails.Rows(0)


                If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated" Then
                    _strClevisPlateCode = oPlateClevisDatarow("CodeNumber")
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ClevisPlate Code", _strClevisPlateCode)
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode = _strClevisPlateCode
                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then 'Check
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode = _strClevisPlateCode
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = oPlateClevisDatarow("StandardClevisPlateThickness") - oPlateClevisDatarow("StandardClevisPlateRodStopDistance")
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateImportOrExisting = "Existing"
                    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = 0.075 + oPlateClevisDatarow("PortDiameter") + 0.075 - 0.3
                        _dblStandardClevisPlateRodStopDistance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness - oPlateClevisDatarow("MinWallThickness") - oPlateClevisDatarow("ButtonHeight")
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = oPlateClevisDatarow("TotalWidth") - 0.3
                        _dblStandardClevisPlateRodStopDistance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness - oPlateClevisDatarow("MinWallThickness") - oPlateClevisDatarow("ButtonHeight")
                    End If
                    'Check
                    'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode2 = _strClevisPlateCode
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2 = oPlateClevisDatarow("StandardClevisPlateThickness") - oPlateClevisDatarow("StandardClevisPlateRodStopDistance")
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateImportOrExisting2 = "Existing"
                    '    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2 = 0.075 + oPlateClevisDatarow("PortDiameter") + 0.075 - 0.3
                    '        _dblStandardClevisPlateRodStopDistance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2 - oPlateClevisDatarow("MinWallThickness") - oPlateClevisDatarow("ButtonHeight")
                    '    Else
                    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2 = oPlateClevisDatarow("TotalWidth") - 0.3
                    '        _dblStandardClevisPlateRodStopDistance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2 - oPlateClevisDatarow("MinWallThickness") - oPlateClevisDatarow("ButtonHeight")
                    '    End If
                    'End If
                Else

                    _strClevisPlateCode = oPlateClevisDatarow("StandardClevisPlateCode")
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ClevisPlate Code", _strClevisPlateCode)
                    '21_03_2012   RAGAVA
                    'Check
                    ' If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode = _strClevisPlateCode
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = oPlateClevisDatarow("StandardClevisPlateThickness") - oPlateClevisDatarow("StandardClevisPlateRodStopDistance")
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateImportOrExisting = "Existing"
                    'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode2 = _strClevisPlateCode
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2 = oPlateClevisDatarow("StandardClevisPlateThickness") - oPlateClevisDatarow("StandardClevisPlateRodStopDistance")
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateImportOrExisting2 = "Existing"
                    'End If
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode = _strClevisPlateCode
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = oPlateClevisDatarow("StandardClevisPlateThickness") - oPlateClevisDatarow("StandardClevisPlateRodStopDistance")

                    _dblStandardClevisPlateRodStopDistance = oPlateClevisDatarow("StandardClevisPlateRodStopDistance")
                End If
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateImportOrExisting = "Existing"
            Else
                Try
                    ObjClsWeldedCylinderFunctionalClass.objfrmFabricatedSingleLug.UcBrowsePlateClevis1.Visible = True
                    ObjClsWeldedCylinderFunctionalClass.objfrmFabricatedSingleLug.btnPlateClevis.Visible = False
                Catch ex As Exception

                End Try
                UcBrowsePlateClevis1.Visible = True
                btnPlateClevis.Visible = False
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ClevisPlate Code", "")

                _dblStandardClevisPlateRodStopDistance = 0
                'Check
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateImportOrExisting = "Import"
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = 0
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateImportOrExisting = "Existing"
                ' ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2 = 0
                ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateImportOrExisting2 = "Existing"
                'End If
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ClevisPlate Code", "")
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = 0
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in SearchForExistingPlateClevis of frmSLFabrication " + ex.Message)
        End Try
    End Sub

    Private Sub SearchForExistingULug()
        Dim dblBushingWidth As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth
        Dim dblRequiredLugThickness As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
        Dim dblRequiredPinHoleSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
        Dim dblBushingQuantity As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity
        Dim dblRequiredLugGap As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap
        Dim strPinWithInTubeDia As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinWithInTubeDiameter
        Dim dblTubeOD As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD
        Dim dblRequiredSwingClearance As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance

        Dim oULugDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
        BEULUgDetails(dblBushingQuantity, dblBushingWidth, dblRequiredPinHoleSize, dblRequiredLugThickness, strPinWithInTubeDia, dblTubeOD, dblRequiredLugGap)
        Try
            If Not IsNothing(oULugDataTable) AndAlso oULugDataTable.Rows.Count > 0 Then
                Dim oFilterWithHeightDataTable As New DataTable
                oFilterWithHeightDataTable = oULugDataTable.Clone
                For Each oFilterWithHeightDataRow As DataRow In oULugDataTable.Rows
                    If oFilterWithHeightDataRow("PilotHole_Y_N") = "Y" Then
                        Try
                            If Not IsDBNull(oFilterWithHeightDataRow("SwingClearanceRadius")) AndAlso oFilterWithHeightDataRow("SwingClearanceRadius") <> "N/A" Then
                                If oFilterWithHeightDataRow("SwingClearanceRadius") >= dblRequiredSwingClearance AndAlso oFilterWithHeightDataRow("SwingClearanceRadius") <= Val(dblRequiredSwingClearance * 1.25) Then
                                    oFilterWithHeightDataTable.Rows.Add(oFilterWithHeightDataRow.ItemArray)
                                End If
                            End If
                        Catch ex As Exception

                        End Try
                    ElseIf oFilterWithHeightDataRow("PilotHole_Y_N") = "N" Then
                        Try
                            If Not IsDBNull(oFilterWithHeightDataRow("HeighttoRadiusEnd")) AndAlso oFilterWithHeightDataRow("HeighttoRadiusEnd") <> "N/A" Then
                                If oFilterWithHeightDataRow("HeighttoRadiusEnd") >= (dblRequiredSwingClearance + (oFilterWithHeightDataRow("LugWidth") / 2)) _
                                                                           AndAlso oFilterWithHeightDataRow("HeighttoRadiusEnd") <= (dblRequiredSwingClearance + (oFilterWithHeightDataRow("LugWidth") / 2) * 2) Then
                                    oFilterWithHeightDataTable.Rows.Add(oFilterWithHeightDataRow.ItemArray)
                                End If
                            End If
                        Catch ex As Exception

                        End Try
                    End If
                Next

                oFilterWithHeightDataTable.Columns.Add("CalculatedSafetyFactor")
 
                _oFilterWithAreaDataTable = New DataTable
                _oFilterWithAreaDataTable = oFilterWithHeightDataTable.Clone
                For Each oFilterWithAreaDataRow As DataRow In oFilterWithHeightDataTable.Rows
                    oFilterWithAreaDataRow("Area") = (oFilterWithAreaDataRow("LugWidth") - dblRequiredPinHoleSize) * oFilterWithAreaDataRow("LugThickness") * 2
                Next

                For Each oFilterWithAreaDataRow2Row As DataRow In oFilterWithHeightDataTable.Rows
                    ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation(ObjClsWeldedCylinderFunctionalClass. _
                    ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, Me.chkOptimizer.Checked, oFilterWithAreaDataRow2Row("YieldStrength"))
                    Dim dblRequiredArea As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired

                    oFilterWithAreaDataRow2Row("CalculatedSafetyFactor") = Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor + (oFilterWithAreaDataRow2Row("Area") / dblRequiredArea), 2) - 1

                    If Val(oFilterWithAreaDataRow2Row("Area")) >= dblRequiredArea Then 'AndAlso Val(oFilterWithAreaDataRow2Row("Area")) <= Val(dblRequiredArea * 1.25) Then  '05_04_2010   RAGAVA
                        _oFilterWithAreaDataTable.Rows.Add(oFilterWithAreaDataRow2Row.ItemArray)
                    End If
                Next

                If Not IsNothing(_oFilterWithAreaDataTable) AndAlso _oFilterWithAreaDataTable.Rows.Count > 0 Then
                    grbMatchedULugsFound.Visible = True
                    grbMatchedULugNotFound.Visible = False
                    PopulateDataInListView()
                Else
                    lvwExistingLugListView.Clear()
                    grbMatchedULugNotFound.Visible = True
                    grbMatchedULugsFound.Visible = False
                    LugGapValidation()

                    Try
                        ObjClsWeldedCylinderFunctionalClass.ObjClsExcelClass.checkExcelInstance()
                        ObjClsWeldedCylinderFunctionalClass.WriteGUIDataToExcel()
                    Catch ex As Exception
                    End Try

                End If
            Else
                lvwExistingLugListView.Clear()
                grbMatchedULugNotFound.Visible = True
                grbMatchedULugsFound.Visible = False
                LugGapValidation()
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in SearchForExistingSingleLug of frmDLFabrication " + ex.Message)
        End Try
    End Sub

    Private Sub LugGapValidation()
        Dim dblBendRadius As Double
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness < 0.625 Then
            dblBendRadius = 0.25
        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = 0.625 Then
            dblBendRadius = 0.5
        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness > 0.625 Then
            dblBendRadius = 0.75
        End If
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap < 2 * dblBendRadius Then
            Dim strMessage As String = "LugGap is not sufficient for the selected LugThickness, kindly change the lugthickness"
            strMessage += "LugGap should be greater than " + (2 * dblBendRadius).ToString
            MessageBox.Show(strMessage, "LugGap is not sufficient", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        End If
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BendRadius_BaseEnd = dblBendRadius
        '--------------------------------
    End Sub

    Private Sub LoadFunctionality()
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        LoadDefaultvalues()
        SearchForExistingPlateClevis()
        SearchForExistingULug()
        ValidLugThickness()
    End Sub

    Public Sub ManualLoad()
        LoadFunctionality()
        ValidLugThickness()
    End Sub

    Private Sub PopulateDataInListView()
        lvwExistingLugListView.Clear()
        lvwExistingLugListView.Columns.Add("Code No", 100, HorizontalAlignment.Center)
        lvwExistingLugListView.Columns.Add("Description", 245, HorizontalAlignment.Center)

        lvwExistingLugListView.Columns.Add("SafetyFactor", 100, HorizontalAlignment.Center)

        lvwExistingLugListView.Columns.Add("Cost", 100, HorizontalAlignment.Center)
        lvwExistingLugListView.Columns.Add("Sales", 100, HorizontalAlignment.Center)        '28_11_2012   RAGAVA
        lvwExistingLugListView.Columns.Add("IFLID", 70, HorizontalAlignment.Center)
        Dim intCount As Integer = 0
        Dim oListItem As ListViewItem
        Try
            If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Count > 0 Then
                ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Clear()
            End If
            For Each oFilterWithAreaDataRow As DataRow In _oFilterWithAreaDataTable.Rows
                Dim strPartCode_Purchase As String = String.Empty
                If Not IsDBNull(oFilterWithAreaDataRow("PartCode")) Then
                    strPartCode_Purchase = ObjClsWeldedCylinderFunctionalClass.PartCOde_Purchased_ListViewClickedValidation(oFilterWithAreaDataRow("PartCode"))
                    oListItem = lvwExistingLugListView.Items.Add(strPartCode_Purchase)
                Else
                    lvwExistingLugListView.Items.Add("")
                End If

                If Not IsDBNull(oFilterWithAreaDataRow("Description")) Then
                    lvwExistingLugListView.Items(intCount).SubItems.Add(oFilterWithAreaDataRow("Description"))
                Else
                    lvwExistingLugListView.Items(intCount).SubItems.Add("")
                End If
                Try
                    Dim dblSafetyFactor As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SetSafetyFactorForExisting(strPartCode_Purchase)
                    If dblSafetyFactor > 0 Then
                        lvwExistingLugListView.Items(intCount).SubItems.Add(dblSafetyFactor.ToString)
                    Else
                        If Not IsDBNull(oFilterWithAreaDataRow("CalculatedSafetyFactor")) Then
                            lvwExistingLugListView.Items(intCount).SubItems.Add(oFilterWithAreaDataRow("CalculatedSafetyFactor"))
                        Else
                            lvwExistingLugListView.Items(intCount).SubItems.Add("")
                        End If
                    End If
                Catch ex As Exception

                End Try
                '28_11_2012  RAGAVA
                Try
                    ObjClsWeldedCylinderFunctionalClass.GetCost_Sales(oFilterWithAreaDataRow("PartCode"), lvwExistingLugListView, intCount)
                Catch ex As Exception

                End Try
                'If Not IsDBNull(oFilterWithAreaDataRow("Cost")) Then
                '    lvwExistingLugListView.Items(intCount).SubItems.Add(oFilterWithAreaDataRow("Cost"))
                'Else
                '    lvwExistingLugListView.Items(intCount).SubItems.Add("")
                'End If
                'Till   Here

                If Not IsDBNull(oFilterWithAreaDataRow("IFLID")) Then
                    lvwExistingLugListView.Items(intCount).SubItems.Add(oFilterWithAreaDataRow("IFLID"))
                Else
                    lvwExistingLugListView.Items(intCount).SubItems.Add("")
                End If
                intCount += 1
            Next
            lvwExistingLugListView.Items(0).Selected = True
            lvwExistingLugListView.HideSelection = False
            lvwExistingLugListView.FullRowSelect = True
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in PopulateDataInListView of frmDLFabrication " + ex.Message)
        End Try
    End Sub

    Private Sub WidthCalculation()
        Try
            Dim dblSafetyFactor As Double = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
            txtSafetyFactor_DesignULug.Text = dblSafetyFactor
            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation(dblSafetyFactor, Me.chkOptimizer.Checked, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.ULug)     '12_11_2009   Ragava
            txtLugWidth_DesignULug.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
        Catch ex As Exception
        End Try
    End Sub

    '13_11_2009  Ragava
    Private Sub ValidLugThickness()
        Try
            Dim oDataTable As DataTable
            Dim dblMaxLugThickness As Double = 0
            Dim dblLugThickNess As Double = Val(txtLugThickness_DesignULug.Text)
            If _oDataTableDesignULug Is Nothing Then
                _oDataTableDesignULug = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetTableDetails("Select * from Welded.DesignULugValidDetails")
            End If
            For Each oDataRow As DataRow In _oDataTableDesignULug.Rows
                If dblMaxLugThickness < oDataRow("ULugThickness") Then
                    dblMaxLugThickness = oDataRow("ULugThickness")
                End If
            Next
            If dblMaxLugThickness < dblLugThickNess Then
                MessageBox.Show("No Material Available After LugThickness 0.75", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                txtLugThickness_DesignULug.Text = dblMaxLugThickness.ToString
                ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd.Text = txtLugThickness_DesignULug.Text
            Else
                oDataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetTableDetails("Select top 1 * from Welded.DesignULugValidDetails Where ULugThickness >= " & dblLugThickNess)
                ObjClsWeldedCylinderFunctionalClass.BendRadius = oDataTable.Rows(0)("BendRadius")
                txtLugThickness_DesignULug.Text = oDataTable.Rows(0)("ULugThickness")
            End If
            'Check
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness_DesignULug.Text)
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
            ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2 = Val(txtLugThickness_DesignULug.Text)
            'End If
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness_DesignULug.Text) 
        Catch ex As Exception
        End Try
        'Till   Here
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
            btnAccept.Enabled = True
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = -0.125
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness + Val(txtLugThickness_DesignULug.Text) + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BendRadius_BaseEnd 'TODO: ANUP 01-06-2010 'Anup 08-06-2010 11.17  

            If txtSafetyFactor_DesignULug.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd = txtSafetyFactor_DesignULug.Text
            End If

            If txtLugThickness_DesignULug.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd.Text = txtLugThickness_DesignULug.Text
            End If
            If txtSwingClearance_DesignULug.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text = txtSwingClearance_DesignULug.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance = Val(txtSwingClearance_DesignULug.Text)
            End If
            If txtLugWidth_DesignULug.Text <> "" Then
                'Check
                ' If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugWidth_DesignULug.Text)
                'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2 = Val(txtLugWidth_DesignULug.Text)
                'End If
            End If

            ObjClsWeldedCylinderFunctionalClass.GenerateULug = True
            'ObjClsWeldedCylinderFunctionalClass.RdbDesignANewCasting.Enabled = True
            Me.Cursor = Cursors.WaitCursor
            ObjClsWeldedCylinderFunctionalClass.dblDL_LugGap = Val(txtLugGap_DesignULug.Text)              '17_02_2010    RAGAVA

            Dim strFilePart As String = ""
            Dim strFilePartDesignTableExcel As String = ""
            Dim strName As String = "GenerateULug"
            strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_U_LUG\Base_U_Lug_IFL.SLDPRT"
            strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BASE_U_LUG.XLS"
            '16_03_2012  RAGAVA
            'Check
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BASE_U_LUG_IFL"
            '  Else
            ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BASE_U_LUG_IFL"
            ' End If
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BASE_U_LUG_IFL"       '01_03_2010    RAGAVA
            'Till  Here
            ObjClsWeldedCylinderFunctionalClass.Design_New_Part(strFilePart, strFilePartDesignTableExcel, "GenerateULug")
            Dim dblWeight As Double = ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Weight")
            ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_U_LUG", True)


            Dim blnDuplicateFound As Boolean = False
            If lvwSafetyFactor_Weight.Items.Count > 0 Then
                For Each oItem As ListViewItem In lvwSafetyFactor_Weight.Items
                    If oItem.SubItems(WeightListView.SafetyFactor).Text.Equals(txtSafetyFactor_DesignULug.Text) AndAlso _
                     oItem.SubItems(WeightListView.LugThickness).Text.Equals(txtLugThickness_DesignULug.Text) AndAlso oItem.SubItems(WeightListView.Weight).Text.Equals(dblWeight.ToString) Then         '28_10_2010   RAGAVA
                        blnDuplicateFound = True
                    End If
                Next
            End If
            If Not blnDuplicateFound Then
                Dim oListViewItem As ListViewItem
                oListViewItem = lvwSafetyFactor_Weight.Items.Add(txtSafetyFactor_DesignULug.Text)
                lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(txtLugThickness_DesignULug.Text)
                lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(dblWeight)
                _intSafetyFactorCount += 1
            End If
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in btnGenerate_Click of frmDLFabrication " + ex.Message)
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

    Private Sub txtLugThickness_DesignULug_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLugThickness_DesignULug.Leave
        If txtLugThickness_DesignULug.Text <> "" Then
            If txtLugThickness_DesignULug.Text <> txtLugThickness_DesignULug.IFLDataTag Then
                txtLugThickness_DesignULug.IFLDataTag = txtLugThickness_DesignULug.Text

                ValidLugThickness() '13_11_2009  Ragava

                trbSafetyFactor.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
                trbSafetyFactor.Maximum = trbSafetyFactor.Minimum + 20
                trbSafetyFactor.TickFrequency = 1
                trbSafetyFactor.Value = trbSafetyFactor.Minimum
                Dim dblSafetyFactor As Double = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
                txtSafetyFactor_DesignULug.Text = dblSafetyFactor
            End If
        Else
            txtLugThickness_DesignULug.IFLDataTag = ""
        End If
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewFabricationGenerated = True             '17_10_2012   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndFabrication_New = True       '15_03_2012   RAGAVA
        If txtSafetyFactor_DesignULug.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd = txtSafetyFactor_DesignULug.Text
        End If
        'Check
        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "" Then
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication"       '15_03_2012   RAGAVA
        'End If

        If txtLugThickness_DesignULug.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd.Text = txtLugThickness_DesignULug.Text
        End If
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False        '20_10_2010   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        btnAccept.Enabled = False

        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication"                'Check
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness_DesignULug.Text)              'Check
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance = Val(txtSwingClearance_DesignULug.Text)          'Check
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugWidth_DesignULug.Text)                      'Check
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated"         'Check
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEULDETAILS"    'Check
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationTable = "Welded.BEULDETAILS"      '15_05_2012   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart = "BASE_U_LUG_IFL"        '15_05_2012   RAGAVA

        ''14_03_2012  RAGAVA
        'Check
        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated"
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISFabricationChecked = True
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = False
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "NewDesign"        '30_05_2012   RAGAVA
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEULDETAILS"
        'Else
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign2 = "NewDesign"
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2 = "Fabricated"
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BEULDETAILS"
        'End If

        'MANJULA ADDED
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLPortIntegral.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLPortIntegral2.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral2.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness

        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLPortInTubeDetails.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLPortInTubeDetails2.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness

        End If
        '********************************
    End Sub

    Private Sub lvwSafetyFactor_Weight_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwSafetyFactor_Weight.SelectedIndexChanged
        If lvwSafetyFactor_Weight.SelectedIndices.Count > 0 Then
            Dim oListViewSelectedItem As ListViewItem = lvwSafetyFactor_Weight.SelectedItems(0)
            trbSafetyFactor.Value = ((Val(oListViewSelectedItem.SubItems(WeightListView.SafetyFactor).Text) - trbSafetyFactor.Minimum) / 0.25) + trbSafetyFactor.Minimum
            txtLugThickness_DesignULug.Text = oListViewSelectedItem.SubItems(WeightListView.LugThickness).Text
            btnAccept.Enabled = True
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            ObjClsWeldedCylinderFunctionalClass.BaseEndWeight = Val(oListViewSelectedItem.SubItems(WeightListView.Weight).Text)
        End If
    End Sub

    Private Sub txtLugWidth_DesignULug_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLugWidth_DesignULug.TextChanged
        If txtLugWidth_DesignULug.Text <> "" Then
            If txtLugWidth_DesignULug.Text <> txtLugWidth_DesignULug.IFLDataTag Then
                txtLugWidth_DesignULug.IFLDataTag = txtLugWidth_DesignULug.Text
                Try
                    Dim oDataTable As DataTable
                    Dim dblLugWidth As Double = Val(txtLugWidth_DesignULug.Text)
                    Dim dblMaxLugWidth As Double = 0
                    If _oDataTableDesignULug Is Nothing Then
                        _oDataTableDesignULug = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetTableDetails("Select * from Welded.DesignULugValidDetails")
                    End If
                    For Each oDataRow As DataRow In _oDataTableDesignULug.Rows
                        If dblMaxLugWidth < oDataRow("ULugWidth") Then
                            dblMaxLugWidth = oDataRow("ULugWidth")
                        End If
                    Next
                    If dblMaxLugWidth < dblLugWidth Then
                        MessageBox.Show("No Material Available After LugWidth 3.50", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                        Me.trbSafetyFactor.Value = Val(Me.trbSafetyFactor.Value) - 1        '19_11_2009  RAGAVA
                        Dim dblSafetyFactor As Double = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
                        ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation(dblSafetyFactor, False, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.ULug)
                        txtLugWidth_DesignULug.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth.ToString
                        txtSafetyFactor_DesignULug.Text = dblSafetyFactor
                    Else
                        oDataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetTableDetails("Select top 1 * from Welded.DesignULugValidDetails Where ULugWidth >= " & dblLugWidth)
                        ObjClsWeldedCylinderFunctionalClass.TopRadius = oDataTable.Rows(0)("TopRadius")
                        txtLugWidth_DesignULug.Text = oDataTable.Rows(0)("ULugWidth")
                        'Check
                        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabricated" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugWidth_DesignULug.Text)
                        ' ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2 = Val(txtLugWidth_DesignULug.Text)
                        ' End If
                    End If
                Catch ex As Exception
                End Try
            End If
        Else
            txtLugWidth_DesignULug.IFLDataTag = ""
        End If
    End Sub

    Private Sub lvwExistingLugListView_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwExistingLugListView.SelectedIndexChanged
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        rdbUseSelectedULug.Checked = False
        rdbDesignaULug.Checked = False

        If lvwExistingLugListView.SelectedIndices.Count > 0 Then

            LugGapValidation() 'TODO: ANUP 02-05-2010 01.33pm

            If rdbUseSelectedULug.Checked = False Then
                ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            End If
            '----------------------------

            Dim oListViewSelectedItem As ListViewItem = lvwExistingLugListView.SelectedItems(0)
            Dim strPartCodePassing_Purchased As String = oListViewSelectedItem.SubItems(ULugListViewDetails.CodeNumber).Text
            Try
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd = oListViewSelectedItem.SubItems(2).Text      '31_05_2011   ragava
            Catch ex As Exception
            End Try
            ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode = strPartCodePassing_Purchased         '12_10_2010   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.ContainsKey(strPartCodePassing_Purchased) Then
                strPartCodePassing_Purchased = ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Item(strPartCodePassing_Purchased).ToString
            End If
            Dim oSelectedULugDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
            GetBEULDetailsSelectedRowDetails(strPartCodePassing_Purchased, "Base End")
            If Not IsNothing(oSelectedULugDataRow) Then
                If Not IsDBNull(oSelectedULugDataRow("PartCode")) Then
                    _strULugCode = oListViewSelectedItem.SubItems(ULugListViewDetails.CodeNumber).Text
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ULug Code", _strULugCode)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = oSelectedULugDataRow("PartCode")
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PartCodeFromUlugCode = oSelectedULugDataRow("PartCode")
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PartCodeFromUlugCode = ""
                End If
                ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = ""
                If oSelectedULugDataRow("PartType").ToString.Contains("IFL_PART") Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "IFL_Designed_Existing"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BASE_U_LUG_IFL"
                    'ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "NewDesign"         '06_06_2012    RAGAVA
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "Existing"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "Base_U_Lug"
                End If
                If Not IsDBNull(oSelectedULugDataRow("PinHoleCombined")) Then
                    txtPinHoleSize.Text = oSelectedULugDataRow("PinHoleCombined")
                End If

                If Not IsDBNull(oSelectedULugDataRow("Height")) Then
                    txtLugHeight.Text = oSelectedULugDataRow("Height")
                End If

                If Not IsDBNull(oSelectedULugDataRow("LugThickness")) Then
                    txtLugThickness.Text = oSelectedULugDataRow("LugThickness")
                End If

                If Not IsDBNull(oSelectedULugDataRow("LugWidth")) Then
                    txtLugWidth.Text = oSelectedULugDataRow("LugWidth")
                End If


                If Not IsDBNull(oSelectedULugDataRow("SwingClearanceRadius")) Then
                    txtSwingClearance.Text = oSelectedULugDataRow("SwingClearanceRadius")
                End If


                If Not IsDBNull(oSelectedULugDataRow("LugGap")) Then
                    txtLugGap.Text = oSelectedULugDataRow("LugGap")
                End If

                DisplayToleranceValues(oSelectedULugDataRow)
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = _dblStandardClevisPlateRodStopDistance
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness + Val(txtLugThickness.Text) + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BendRadius_BaseEnd 'TODO: ANUP 01-06-2010'Anup 08-06-2010 11.17
            End If
        Else
            _strULugCode = ""
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ULug Code", "")
            txtPinHoleSize.Text = ""
            txtLugHeight.Text = ""
            txtLugThickness.Text = ""
            txtLugWidth.Text = ""
            txtSwingClearance.Text = ""
            txtLugGap.Text = ""
            txtPinHoleTole_Neg.Text = ""
            txtPinHoleTole_Pos.Text = ""
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = 0
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = 0
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = 0
        End If
    End Sub

    Private Sub DisplayToleranceValues(ByVal oRow As DataRow)
        If Not IsDBNull(oRow("PinHoleCustom_UpperTolerance")) Then
            If oRow("PinHoleCustom_UpperTolerance").Equals("N/A") Then
                txtPinHoleTole_Pos.Text = "0.010"
            Else
                txtPinHoleTole_Pos.Text = oRow("PinHoleCustom_UpperTolerance")
            End If
        End If
        If Not IsDBNull(oRow("PinHoleCustom_LowerTolerance")) Then
            If oRow("PinHoleCustom_LowerTolerance").Equals("N/A") Then
                txtPinHoleTole_Neg.Text = 0.005
            Else
                txtPinHoleTole_Neg.Text = oRow("PinHoleCustom_LowerTolerance")
            End If
        End If
    End Sub

    Private Sub rdbUseSelectedULug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedULug.CheckedChanged
        If rdbUseSelectedULug.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewFabricationGenerated = False             '17_10_2012   RAGAVA
            'Check
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "" Then
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication"       '15_03_2012   RAGAVA
            'End If
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = True        '20_10_2010    RAGAVA

            '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------009
            Dim strMessage As String = "Base end Configuration will be updated with the selected ULug Fabrication details, " + vbCrLf
            If MessageBox.Show(strMessage, "Update TubeDetails", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Or ObjClsWeldedCylinderFunctionalClass.MultiGenerate = True Then

                ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True

                If txtLugThickness.Text <> "" Then
                    'ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd.Text = txtLugThickness.Text       '20_04_2012  RAGAVA
                    '09_04_2012   RAGAVA
                    'Check
                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness_DesignULug.Text)
                    'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2 = Val(txtLugThickness_DesignULug.Text)
                    'End If
                    'Till   Here
                End If

                If txtSwingClearance.Text <> "" Then
                    ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text = txtSwingClearance.Text
                End If

                If txtLugGap.Text <> "" Then
                    ObjClsWeldedCylinderFunctionalClass.TxtLugGap_BaseEnd.Text = txtLugGap.Text
                End If
                'Check
                'If txtLugWidth.Text <> "" Then
                '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then       '20_04_2012  RAGAVA
                '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugWidth.Text)
                '    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2 = Val(txtLugWidth.Text)
                '    End If
                'End If

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
                'MANJULA ADDED
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then


                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLPortIntegral.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLPortIntegral.dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text

                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLPortIntegral2.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLPortIntegral2.dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text

                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text

                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral2.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral2.dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text


                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLPortInTubeDetails.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLPortInTubeDetails.dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text

                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLPortInTubeDetails2.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLPortInTubeDetails2.dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text

                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text

                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text

                End If
                ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = ""  'Raghavendra 27_02_2010

                ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Exact"
                ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True

                If Not String.IsNullOrEmpty(txtPinHoleTole_Pos.Text) Then
                    ObjClsWeldedCylinderFunctionalClass.TxtToleranceUpperLimit.Text = txtPinHoleTole_Pos.Text
                End If
                If Not String.IsNullOrEmpty(txtPinHoleTole_Neg.Text) Then
                    ObjClsWeldedCylinderFunctionalClass.TxtToleranceLowerLimit.Text = txtPinHoleTole_Neg.Text
                End If
            End If


            ''14_03_2012  RAGAVA
            'Check
            'If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.rdbFabrication.Checked Then
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated"
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISFabricationChecked = True
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = False
            'Else
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2 = "Fabricated"
            'End If
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEULDETAILS"
            'Else
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BEULDETAILS"
            'End If
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.rdbDesignACasting.Checked Then
            '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
            '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Cast"
            '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = True
            '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = False
            '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISFabricationChecked = False
            '    Else
            '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2 = "Cast"
            '    End If
            '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
            '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEDLCastWithOutPort"
            '    Else
            '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BEDLCastWithOutPort"
            '    End If
            'End If

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication"                       'Check
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness.Text)              'Check
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance = Val(txtSwingClearance.Text)          'Check
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugWidth.Text)                      'Check
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated"               'Check
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEULDETAILS"    'Check
        End If
    End Sub

    Private Sub rdbDesignaULug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDesignaULug.CheckedChanged
        If rdbDesignaULug.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False        '20_10_2010    RAGAVA
            'ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "NewDesign"          '06_06_2012    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEULDetails"
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False

            If MessageBox.Show("Click Ok to Design a U Lug", "Design a ULug", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) = Windows.Forms.DialogResult.OK Then
                LugGapValidation() 'TODO: ANUP 02-05-2010 01.19pm
                grbMatchedULugsFound.Visible = False
                grbMatchedULugNotFound.Visible = True
                grbMatchedULugNotFound.BringToFront()
            End If
        End If
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblSafetyFactorIndex)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblDesignNewCasting)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblExistingULugsDetails)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblShowImage)
    End Sub

    Private Sub chkOptimizer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOptimizer.CheckedChanged
        Try
            WidthCalculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnRodWeldmentScreensDisplayedNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRodWeldmentScreensDisplayedNext.Click

    End Sub
End Class