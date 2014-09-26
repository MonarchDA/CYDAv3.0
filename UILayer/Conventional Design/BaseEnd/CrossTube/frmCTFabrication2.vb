Imports System.io
Public Class frmCTFabrication2

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

    'Private _objDt_DesignSingleLug As DataTable             '13_11_2009   Ragava

    Private _strCrossTubeCode As String

    Private _dblTempNutSafetyFactor As Double = 0

    Private _dblTempPinHoleSize As Double = 0

    Private _dblTempSwingClearance As Double = 0

    Private _dblWorkingPressure As Double = 0

    Private _intClass As Integer = 0
    Private _portType As String

    Private _dblCrossTubeWidth As Double = 0

    Private _intSafetyFactorCount As Integer = 0
    Private _dblStandardClevisPlateRodStopDistance As Double '26_02_2010 Aruna 
#End Region

#Region "Enum"

    Public Enum SingleLugListViewDetails
        CodeNumber = 0
        Description = 1
        Cost = 2
    End Enum

    Public Enum WeightListView
        SafetyFactor = 0
        LugWidth = 1
        Weight = 2
    End Enum
#End Region

#Region "SubProcedures"

    Private Sub DefaultSettings()
        Try

            'ANUP 23-09-2010 START 
            ObjClsWeldedCylinderFunctionalClass.IsPlateClevisImported = False
            'ANUP 23-09-2010 TILL HERE

            txtCrossTubeOD.Enabled = False

            txtCrossTubeWidth.Enabled = False
            txtRequiredCrossTubeWidth.Enabled = False

            txtPinHoleSize.Enabled = False
            txtRequiredPinHoleSize.Enabled = False

            txtGreaseZerk.Enabled = False
            txtRequiredGreaseZerk.Enabled = False

            txtAngle1.Enabled = False
            txtRequiredAngle1.Enabled = False

            txtAngle2.Enabled = False
            txtRequiredAngle2.Enabled = False

            txtPinHoleSize.Enabled = False
            'rdbDesignaCrossTube.Checked = True

            btnAccept.Enabled = False
            txtSafetyFactor_DesignCrossTube.Enabled = False
            txtCrossTubeOD_DesignCrossTube.Enabled = False
            txtCrossTubeWidth_DesignCrossTube.Enabled = True
            txtPinHoleSize_DesignCrossTube.Enabled = False
            txtSwingClearance_DesignCrossTube.Enabled = False

            SafetyFactor_LugThickness_Weight_GeneretedDesign()

        Catch ex As Exception

        End Try
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
        txtRequiredCrossTubeWidth.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
        txtRequiredPinHoleSize.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
        txtGreaseZerk.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1
        txtRequiredAngle1.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1
        txtRequiredAngle2.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2

        DisableReqPinToleranceControls()
        lvwSafetyFactor_Weight.Items.Clear() 'MANJULA ADDED
        _intSafetyFactorCount = 0 'MANJULA ADDED
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor <> _dblTempNutSafetyFactor _
       OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize <> _dblTempPinHoleSize _
       OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance <> _dblTempSwingClearance _
       OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure <> _dblWorkingPressure _
       OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass <> _intClass _
       OrElse ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube <> _portType _
       OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth <> _dblCrossTubeWidth Then

            ' ANUP 19-03-2010 11.00
            ' lvwSafetyFactor_Weight.Items.Clear()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            ' _intSafetyFactorCount = 0
            '***************

            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation _
           (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, Me.chkOptimizer.Checked, _
           clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube, "2")    '12_07_2012    RAGAVA

            _dblTempNutSafetyFactor = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor
            _dblTempPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
            _dblWorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure
            _intClass = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass
            _dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
            _dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
            _portType = ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube

            txtCrossTubeOD_DesignCrossTube.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD
            txtCrossTubeWidth_DesignCrossTube.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
            txtPinHoleSize_DesignCrossTube.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
            txtSwingClearance_DesignCrossTube.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance

            trbSafetyFactor.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
            trbSafetyFactor.Maximum = trbSafetyFactor.Minimum + 20
            trbSafetyFactor.TickFrequency = 1
            trbSafetyFactor.Value = trbSafetyFactor.Minimum
            txtSafetyFactor_DesignCrossTube.Text = trbSafetyFactor.Value
        End If
    End Sub

    '26_02_2010 Aruna Start
    'Private Sub SearchForExistingPlateClevis()
    '    Dim strClassType As String = ""
    '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional" Then
    '        strClassType = "ConventionalDesignClass"
    '    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
    '        strClassType = "NewDesignClass"
    '    End If
    '    strClassType += ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass
    '    Try
    '        Dim oClevisPlateDetails As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
    '        GetPlateClevisDetails(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, _
    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD)

    '        If Not IsNothing(oClevisPlateDetails) AndAlso oClevisPlateDetails.Rows.Count > 0 Then
    '            UcBrowsePlateClevis1.Visible = False
    '            btnPlateClevis.Visible = True
    '            Dim oPlateClevisDatarow As DataRow = oClevisPlateDetails.Rows(0)
    '            _strClevisPlateCode = oPlateClevisDatarow("ClevisPlateCode")
    '            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ClevisPlate Code", _strClevisPlateCode)
    '            ''ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.ClevisPlateCode = _strClevisPlateCode
    '        Else
    '            UcBrowsePlateClevis1.Visible = True
    '            btnPlateClevis.Visible = False
    '            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ClevisPlate Code", "")
    '            '' ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.ClevisPlateCode = ""
    '        End If
    '    Catch ex As Exception
    '        ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in SearchForExistingPlateClevis of frmCTFabrication " + ex.Message)
    '    End Try
    'End Sub

    Private Sub SearchForExistingPlateClevis()
        Dim strClassType As String = ""
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional" Then
            strClassType = "ConventionalDesignClass"
        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
            strClassType = "NewDesignClass"
        End If
        strClassType += ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass

        Try
            'Dim oClevisPlateDetails As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
            'GetPlateClevisDetails(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, _
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD)


            '12_01_2012    RAGAVA
            Dim oClevisPlateDetails As DataTable = Nothing
            If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2 = "Fabricated" Then
                ObjClsWeldedCylinderFunctionalClass.GetClevisPlateDetails_WR(oClevisPlateDetails, "2")    '12_07_2012    RAGAVA
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
                '12_01_2012    RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2 = "Fabricated" Then
                    _strClevisPlateCode = oPlateClevisDatarow("CodeNumber")
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ClevisPlate Code", _strClevisPlateCode)
                    '12_07_2012    RAGAVA  Commented
                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode = _strClevisPlateCode
                    '    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = 0.075 + oPlateClevisDatarow("PortDiameter") + 0.075 - 0.3
                    '        _dblStandardClevisPlateRodStopDistance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness - oPlateClevisDatarow("MinWallThickness") - oPlateClevisDatarow("ButtonHeight")
                    '    Else
                    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = oPlateClevisDatarow("TotalWidth") - 0.3
                    '        _dblStandardClevisPlateRodStopDistance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness - oPlateClevisDatarow("MinWallThickness") - oPlateClevisDatarow("ButtonHeight")
                    '    End If
                    'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode2 = _strClevisPlateCode
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
                    _strClevisPlateCode = oPlateClevisDatarow("StandardClevisPlateCode")
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ClevisPlate Code", _strClevisPlateCode)
                    '12_07_2012    RAGAVA  Commented
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
                    _dblStandardClevisPlateRodStopDistance = oPlateClevisDatarow("StandardClevisPlateRodStopDistance")
                End If
            Else
                UcBrowsePlateClevis1.Visible = True
                btnPlateClevis.Visible = False
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ClevisPlate Code", "")
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode = 0


                _dblStandardClevisPlateRodStopDistance = 0

                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = 0
                '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateImportOrExisting = "Import"
                'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2 = 0
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateImportOrExisting2 = "Import"
                'End If
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ClevisPlate Code", "")
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = 0
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2 = 0
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in SearchForExistingPlateClevis of frmSLFabrication " + ex.Message)
        End Try
    End Sub
    '26_02_2010 Aruna Ends
    Private Sub SearchForExistingCrossTube()
        Dim dblBushingWidth As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth
        Dim dblRequiredPinHoleSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
        Dim dblBushingQuantity As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity
        Dim dblRequiredSwingClearance As Double
        Dim dblRequiredCrossTubeWidth As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
        Try
            '16-02-10 by Sandeep
            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation _
            (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, False, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube_Cast_FlushedPort, "2")    '12_07_2012    RAGAVA
            dblRequiredSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
            Dim dblRequiredArea As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
            '16-02-10 by Sandeep

            Dim oCrossTubeDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
            BECrossTubeDetails(dblBushingQuantity, dblBushingWidth, dblRequiredPinHoleSize, dblRequiredSwingClearance, dblRequiredCrossTubeWidth, "2")    '12_07_2012    RAGAVA

            If Not IsNothing(oCrossTubeDataTable) AndAlso oCrossTubeDataTable.Rows.Count > 0 Then

                'TODO:Anup 09-04-10 2pm
                oCrossTubeDataTable.Columns.Add("CalculatedSafetyFactor")
                '*************************

                For Each oCrossTubeDataTableDataRow As DataRow In oCrossTubeDataTable.Rows
                    oCrossTubeDataTableDataRow("Area") = Math.Round((oCrossTubeDataTableDataRow("Diameter") - dblRequiredPinHoleSize) * oCrossTubeDataTableDataRow("Width"), 2)
                Next

                _oFilterWithAreaDataTable = New DataTable
                _oFilterWithAreaDataTable = oCrossTubeDataTable.Clone
                For Each oFilterWithAreaDataRow As DataRow In oCrossTubeDataTable.Rows
                    '16-02-10 by Sandeep
                    'ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation _
                    '(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, oFilterWithAreaDataRow("YieldStrength"))
                    '16-02-10 by Sandeep

                    'TODO:Anup 09-04-10 2pm
                    oFilterWithAreaDataRow("CalculatedSafetyFactor") = Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor + (oFilterWithAreaDataRow("Area") / dblRequiredArea), 2) - 1
                    '*************************

                    If Val(oFilterWithAreaDataRow("Area")) >= dblRequiredArea Then
                        _oFilterWithAreaDataTable.Rows.Add(oFilterWithAreaDataRow.ItemArray)
                    End If
                Next

                If Not IsNothing(_oFilterWithAreaDataTable) AndAlso _oFilterWithAreaDataTable.Rows.Count > 0 Then
                    grbMatchedCrossTubeFound.Visible = True
                    grbMatchedCrossTubeNotFound.Visible = False
                    PopulateDataInListView()
                Else
                    lvwExistingCrossTubeListView.Clear()
                    grbMatchedCrossTubeNotFound.Visible = True
                    grbMatchedCrossTubeFound.Visible = False
                    Try
                        ObjClsWeldedCylinderFunctionalClass.ObjClsExcelClass.checkExcelInstance()
                        ObjClsWeldedCylinderFunctionalClass.WriteGUIDataToExcel()
                    Catch ex As Exception

                    End Try
                End If
            Else
                lvwExistingCrossTubeListView.Clear()
                grbMatchedCrossTubeNotFound.Visible = True
                grbMatchedCrossTubeFound.Visible = False
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in SearchForExistingCrossTube of frmCTFabrication " + ex.Message)
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
        SearchForExistingCrossTube()
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2 = "Fabricated" '27_02_2010

        'ValidLugThickness() '13_11_2009  Ragava
    End Sub

    Public Sub ManualLoad()
        LoadFunctionality()
    End Sub

    Private Sub PopulateDataInListView()
        lvwExistingCrossTubeListView.Clear()
        lvwExistingCrossTubeListView.Columns.Add("Code No", 100, HorizontalAlignment.Center)
        lvwExistingCrossTubeListView.Columns.Add("Description", 245, HorizontalAlignment.Center)

        'TODO:Anup 09-04-10 2pm
        lvwExistingCrossTubeListView.Columns.Add("SafetyFactor", 100, HorizontalAlignment.Center)
        '***********

        lvwExistingCrossTubeListView.Columns.Add("Cost", 100, HorizontalAlignment.Center)
        lvwExistingCrossTubeListView.Columns.Add("Sales", 100, HorizontalAlignment.Center)        '26_11_2012   RAGAVA

        Dim intCount As Integer = 0
        Dim oListItem As ListViewItem

        'ANUP 07-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Count > 0 Then
            ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Clear()
        End If
        'ANUP 07-10-2010 TILL HERE.

        For Each oFilterWithAreaDataRow As DataRow In _oFilterWithAreaDataTable.Rows
            Dim strPartCode_Purchase As String = String.Empty
            If Not IsDBNull(oFilterWithAreaDataRow("PartCode")) Then
                'ANUP 07-10-2010 START
                strPartCode_Purchase = ObjClsWeldedCylinderFunctionalClass.PartCOde_Purchased_ListViewClickedValidation(oFilterWithAreaDataRow("PartCode"))
                oListItem = lvwExistingCrossTubeListView.Items.Add(strPartCode_Purchase)
                'ANUP 07-10-2010 TILL HERE
            End If

            If Not IsDBNull(oFilterWithAreaDataRow("Description")) Then
                lvwExistingCrossTubeListView.Items(intCount).SubItems.Add(oFilterWithAreaDataRow("Description"))
            End If


            '31_05_2011  RAGAVA
            Try
                Dim dblSafetyFactor As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SetSafetyFactorForExisting(strPartCode_Purchase)
                If dblSafetyFactor > 0 Then
                    lvwExistingCrossTubeListView.Items(intCount).SubItems.Add(dblSafetyFactor.ToString)
                Else
                    If Not IsDBNull(oFilterWithAreaDataRow("CalculatedSafetyFactor")) Then
                        lvwExistingCrossTubeListView.Items(intCount).SubItems.Add(oFilterWithAreaDataRow("CalculatedSafetyFactor"))
                    Else
                        lvwExistingCrossTubeListView.Items(intCount).SubItems.Add("")
                    End If
                End If
            Catch ex As Exception
            End Try
            'TODO:Anup 09-04-10 2pm
            'If Not IsDBNull(oFilterWithAreaDataRow("CalculatedSafetyFactor")) Then
            '    lvwExistingCrossTubeListView.Items(intCount).SubItems.Add(oFilterWithAreaDataRow("CalculatedSafetyFactor"))
            'Else
            '    lvwExistingCrossTubeListView.Items(intCount).SubItems.Add("")
            'End If
            '***************
            'TILL  HERE

            '26_11_2012  RAGAVA
            Try
                ObjClsWeldedCylinderFunctionalClass.GetCost_Sales(oFilterWithAreaDataRow("PartCode"), lvwExistingCrossTubeListView, intCount)
            Catch ex As Exception

            End Try
            'If Not IsDBNull(oFilterWithAreaDataRow("Cost")) Then
            '    lvwExistingCrossTubeListView.Items(intCount).SubItems.Add(oFilterWithAreaDataRow("Cost"))
            'End If
            'Till   Here

            intCount += 1
        Next
        lvwExistingCrossTubeListView.Items(0).Selected = True
        lvwExistingCrossTubeListView.HideSelection = False
        lvwExistingCrossTubeListView.FullRowSelect = True
    End Sub

    Private Sub WidthCalculation()
        Try
            Dim dblSafetyFactor As Double = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
            txtSafetyFactor_DesignCrossTube.Text = dblSafetyFactor
            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation(dblSafetyFactor, Me.chkOptimizer.Checked, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube)     '12_11_2009   Ragava
            txtCrossTubeOD_DesignCrossTube.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SafetyFactor_LugThickness_Weight_GeneretedDesign()
        lvwSafetyFactor_Weight.Clear()
        lvwSafetyFactor_Weight.Columns.Add("SafetyFactor", 130, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight.Columns.Add("CrossTubeWidth", 130, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight.Columns.Add("Weight", 125, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight.FullRowSelect = True
    End Sub

#End Region

#Region "Events"

    Private Sub frmCTFabrication_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        DefaultSettings()
        LoadFunctionality()
    End Sub

    Private Sub lvwExistingCrossTubeListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwExistingCrossTubeListView.SelectedIndexChanged
        'ANUP 10-11-2010 START
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        rdbUseSelectedULug.Checked = False
        rdbDesignaCrossTube.Checked = False
        'ANUP 10-11-2010 TILL HERE
        Try
            If lvwExistingCrossTubeListView.SelectedIndices.Count > 0 Then
                Dim oListViewSelectedItem As ListViewItem = lvwExistingCrossTubeListView.SelectedItems(0)

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

                Dim oSelectedCrossTubeDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                GetBECrossTubeDetailsSelectedRowDetails(strPartCodePassing_Purchased, "2")    '12_07_2012    RAGAVA
                If Not IsNothing(oSelectedCrossTubeDataRow) Then
                    If Not IsDBNull(oSelectedCrossTubeDataRow("PartCode")) Then
                        _strCrossTubeCode = oListViewSelectedItem.SubItems(SingleLugListViewDetails.CodeNumber).Text

                        '1_03_2010 Aruna   
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2 = oSelectedCrossTubeDataRow("PartCode")

                        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("CrossTube Code", oListViewSelectedItem.SubItems(SingleLugListViewDetails.CodeNumber).Text)
                    End If
                    'ANUP 07-10-2010 TILL HERE

                    If Not IsDBNull(oSelectedCrossTubeDataRow("Diameter")) Then
                        txtCrossTubeOD.Text = oSelectedCrossTubeDataRow("Diameter")
                    End If

                    If Not IsDBNull(oSelectedCrossTubeDataRow("Width")) Then
                        txtCrossTubeWidth.Text = oSelectedCrossTubeDataRow("Width")
                    End If

                    If Not IsDBNull(oSelectedCrossTubeDataRow("PinHoleCombined")) Then
                        txtPinHoleSize.Text = oSelectedCrossTubeDataRow("PinHoleCombined")
                    End If

                    'If Not IsDBNull(oSelectedCrossTubeDataRow("GreaseZerk")) Then
                    '    txtGreaseZerk.Text = oSelectedCrossTubeDataRow("GreaseZerk")
                    'End If

                    If Not IsDBNull(oSelectedCrossTubeDataRow("GreaseZerkAngle1")) Then
                        'txtAngle1.Text = Val(oSelectedCrossTubeDataRow("GreaseZerkAngle1")) / 2
                        txtAngle1.Text = oSelectedCrossTubeDataRow("GreaseZerkAngle1")
                    End If

                    If Not IsDBNull(oSelectedCrossTubeDataRow("GreaseZerkAngle2")) Then
                        'txtAngle2.Text = Val(oSelectedCrossTubeDataRow("GreaseZerkAngle2")) / 2
                        txtAngle2.Text = oSelectedCrossTubeDataRow("GreaseZerkAngle2")
                    End If

                    DisplayToleranceValues(oSelectedCrossTubeDataRow)
                    txtGreaseZerk.Text = ObjClsWeldedCylinderFunctionalClass.GetGreekZercQty(txtAngle1.Text, txtAngle2.Text)

                    '26_02_2010 Aruna Start
                    If oSelectedCrossTubeDataRow("PartType").ToString.Contains("IFL_PART") Then
                        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "IFL_Designed_Existing"
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign2 = "NewDesign" '27_02_2010
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BASE_CROSSTUBE_IFL"
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign2 = "Existing"
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "Base_Cross_Tube"
                    End If
                    '1_03_2010 Aruna
                    ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated"
                    If ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port In Tube" Then         '24_01_2012    RAGAVA
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2 = _dblStandardClevisPlateRodStopDistance
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2 = _
                            Val(txtCrossTubeOD.Text) / 2 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2
                    End If
                    '26_02_2010 Aruna End
                End If

                If rdbUseSelectedULug.Checked = True Then
                    UpdateValues()
                End If

            Else
                _strCrossTubeCode = ""
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("CrossTube Code", "")
                txtCrossTubeOD.Text = ""
                txtCrossTubeWidth.Text = ""
                txtPinHoleSize.Text = ""
                txtGreaseZerk.Text = ""
                txtAngle1.Text = ""
                txtAngle2.Text = ""
                txtPinHoleTole_Pos.Text = ""
                txtPinHoleTole_Neg.Text = ""
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in lvwExistingCrossTubeListView_SelectedIndexChanged of frmCTFabrication " + ex.Message)
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

    Private Sub trbSafetyFactor_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trbSafetyFactor.Scroll
        'btnAccept.Enabled = False
        WidthCalculation()
        For Each oItem As ListViewItem In lvwSafetyFactor_Weight.Items
            oItem.Selected = False
        Next
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        '26_02_2010 Aruna Start
        Me.Cursor = Cursors.WaitCursor
        Dim strFilePart As String = ""
        Dim strFilePartDesignTableExcel As String = ""
        Dim strName As String = "NewCrossTubeFabrication"
        btnAccept.Enabled = True '2_03_2010 Aruna
        If txtSafetyFactor_DesignCrossTube.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd2 = txtSafetyFactor_DesignCrossTube.Text
        End If
        If txtCrossTubeWidth_DesignCrossTube.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.TxtCrossTubeWidth_BaseEnd.Text = txtCrossTubeWidth_DesignCrossTube.Text
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth2 = Val(txtCrossTubeWidth_DesignCrossTube.Text)   '12_07_2012   RAGAVA
        End If
        If txtCrossTubeOD_DesignCrossTube.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD2 = Val(txtCrossTubeOD_DesignCrossTube.Text)   '12_07_2012   RAGAVA
        End If
        If txtSwingClearance_DesignCrossTube.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text = txtSwingClearance_DesignCrossTube.Text   '28_08_2012   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2 = Val(txtSwingClearance_DesignCrossTube.Text)   '12_07_2012   RAGAVA
        End If


        If ObjClsWeldedCylinderFunctionalClass._strIsPortIntegral_or_PortInTube = "Port In Tube" Then         '24_01_2012    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2 = -0.125
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2 = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness2 'TODO: ANUP 02-05-2010
        End If
        strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_CROSSTUBE\Base_Crosstube_IFL.SLDPRT"
        'Aruna 19_3_2010
        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_CROSSTUBE", False)
        strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BASE_CROSSTUBE.xls"
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BASE_CROSSTUBE_IFL"
        ObjClsWeldedCylinderFunctionalClass.Design_New_Part(strFilePart, strFilePartDesignTableExcel, "NewCrossTubeFabrication")
        Dim dblWeight As Double = ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Weight")
        Try
            Dim blnDuplicateFound As Boolean = False
            If lvwSafetyFactor_Weight.Items.Count > 0 Then
                For Each oItem As ListViewItem In lvwSafetyFactor_Weight.Items
                    If oItem.SubItems(WeightListView.SafetyFactor).Text.Equals(txtSafetyFactor_DesignCrossTube.Text) AndAlso _
                     oItem.SubItems(WeightListView.LugWidth).Text.Equals(txtCrossTubeWidth_DesignCrossTube.Text) AndAlso oItem.SubItems(WeightListView.Weight).Text.Equals(dblWeight.ToString) Then         '28_10_2010   RAGAVA
                        blnDuplicateFound = True
                    End If
                Next
            End If
            If Not blnDuplicateFound Then
                Dim oListViewItem As ListViewItem
                oListViewItem = lvwSafetyFactor_Weight.Items.Add(txtSafetyFactor_DesignCrossTube.Text)
                lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(txtCrossTubeWidth_DesignCrossTube.Text)
                lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(dblWeight)
                _intSafetyFactorCount += 1
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in btnGenerate_Click of frmCTFabrication " + ex.Message)
        End Try
        '26_02_2010 Aruna Ends
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewFabricationGenerated = True             '17_10_2012   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndFabrication_New = True       '15_03_2012   RAGAVA
        '26_02_2010 Aruna Start
        If txtSafetyFactor_DesignCrossTube.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd2 = txtSafetyFactor_DesignCrossTube.Text
        End If

        If txtCrossTubeWidth_DesignCrossTube.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.TxtCrossTubeWidth_BaseEnd.Text = txtCrossTubeWidth_DesignCrossTube.Text
        End If

        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        btnAccept.Enabled = False
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign2 = "NewDesign"
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2 = "Fabricated"
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BECrossTubeDetails"
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationTable = "Welded.BECrossTubeDetails"       '17_07_2012   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart = "BASE_CROSSTUBE_IFL"               '17_07_2012   RAGAVA

        ObjClsWeldedCylinderFunctionalClass.TxtCrossTubeWidth_BaseEnd.Text = txtCrossTubeOD_DesignCrossTube.Text
        'txtCrossTubeWidth_DesignCrossTube
        ObjClsWeldedCylinderFunctionalClass.TxtCrossTubeWidth_BaseEnd.Text = txtCrossTubeWidth_DesignCrossTube.Text
        '26_02_2010 Aruna End
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False        '20_10_2010   RAGAVA
        ''Added by Sandeep --set  This parameter for retracted length calculation(the value which we are going to insert in db)
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinHoletoRodStop = oSelectedCastingDataRow("DistancefromPinholetoRodStop")
        'MANJULA ADDED
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTPortIntegral.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTPortIntegral2.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral2.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth

        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTPortInTube.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTPortInTube2.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube2.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth

        End If
    End Sub

    Private Sub txtCrossTubeWidth_DesignCrossTube_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCrossTubeWidth_DesignCrossTube.Leave
        If txtCrossTubeWidth_DesignCrossTube.Text <> "" Then
            If txtCrossTubeWidth_DesignCrossTube.Text <> txtCrossTubeWidth_DesignCrossTube.IFLDataTag Then
                txtCrossTubeWidth_DesignCrossTube.IFLDataTag = txtCrossTubeWidth_DesignCrossTube.Text
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth = Val(txtCrossTubeWidth_DesignCrossTube.Text)
                'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth2 = Val(txtCrossTubeWidth_DesignCrossTube.Text)
                'End If
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth = Val(txtCrossTubeWidth_DesignCrossTube.Text)
                trbSafetyFactor.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
                trbSafetyFactor.Maximum = trbSafetyFactor.Minimum + 20
                trbSafetyFactor.TickFrequency = 1
                trbSafetyFactor.Value = trbSafetyFactor.Minimum
                txtSafetyFactor_DesignCrossTube.Text = trbSafetyFactor.Value

                ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation _
                (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, Me.chkOptimizer.Checked, _
                clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube, "2")        '12_07_2012   Ragava
                txtCrossTubeOD_DesignCrossTube.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD
                txtSwingClearance_DesignCrossTube.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
                'ValidLugThickness() 13_11_2009  Ragava
                btnAccept.Enabled = False
            End If
        Else
            txtCrossTubeWidth_DesignCrossTube.IFLDataTag = ""
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth = 0
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth2 = 0
        End If
    End Sub

    Private Sub lvwSafetyFactor_Weight_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwSafetyFactor_Weight.SelectedIndexChanged
        If lvwSafetyFactor_Weight.SelectedIndices.Count > 0 Then
            Dim oListViewSelectedItem As ListViewItem = lvwSafetyFactor_Weight.SelectedItems(0)
            trbSafetyFactor.Value = ((Val(oListViewSelectedItem.SubItems(WeightListView.SafetyFactor).Text) - trbSafetyFactor.Minimum) / 0.25) + trbSafetyFactor.Minimum
            ObjClsWeldedCylinderFunctionalClass.BaseEndWeight = Val(oListViewSelectedItem.SubItems(WeightListView.Weight).Text)
        End If
    End Sub

    Private Sub trbSafetyFactor_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trbSafetyFactor.ValueChanged
        btnAccept.Enabled = False
        WidthCalculation()
    End Sub

    'Private Sub rdbUseSelectedULug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedULug.CheckedChanged, rdbDesignaCrossTube.CheckedChanged
    '    Dim strMessage As String = "Base end Configuration will be updated with the selected Cross Tube Fabrication details, " + vbCrLf
    '    If MessageBox.Show(strMessage, "Update TubeDetails", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then

    '        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True

    '        If txtCrossTubeOD.Text <> "" Then
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD = Val(txtCrossTubeOD.Text)
    '        End If

    '        If txtCrossTubeWidth.Text <> "" Then
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth = Val(txtCrossTubeWidth.Text)
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
    '        ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance

    '        'ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = ""    '03_03_2010    RAGAVA
    '        If rdbUseSelectedULug.Checked Then
    '            'ONSITE: 
    '            ObjClsWeldedCylinderFunctionalClass.ShowCastingNo_Thru_CastingYes = False
    '            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Exact"
    '            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
    '        ElseIf rdbDesignaCrossTube.Checked Then
    '            ' ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "NewDesign"
    '            'ONSITE: 
    '            ObjClsWeldedCylinderFunctionalClass.ShowCastingNo_Thru_CastingYes = True
    '            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
    '        End If
    '    End If
    'End Sub

    Private Sub rdbUseSelectedULug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedULug.CheckedChanged
        If rdbUseSelectedULug.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewFabricationGenerated = False             '17_10_2012   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = True        '20_10_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationTable = ""       '17_07_2012   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart = ""        '17_07_2012   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndFabrication_New = False     '17_07_2012   RAGAVA
            '---------------------------------------------------------------------------------------------------------------------------------009
            If ObjClsWeldedCylinderFunctionalClass.MultiGenerate <> True Then
                Dim strMessage As String = "Base end Configuration will be updated with the selected Cross Tube Fabrication details, " + vbCrLf
                If MessageBox.Show(strMessage, "Update TubeDetails", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
                    UpdateValues()
                End If
            Else
                UpdateValues()
            End If
            '---------------------------------------------------------------------------------------------------------------------------------009
        End If
    End Sub

    Private Sub UpdateValues()
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True

        If txtCrossTubeOD.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD2 = Val(txtCrossTubeOD.Text)
        End If

        If txtCrossTubeWidth.Text <> "" Then
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth = Val(txtCrossTubeWidth.Text)
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth2 = Val(txtCrossTubeWidth.Text)
            'End If
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth = Val(txtCrossTubeWidth.Text)
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

        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2 = (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD2 / 2)
        '28_08_2012   RAGAVA
        'ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2


        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize2 = "Exact"
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True

        'anup 30-08-2010
        If Not String.IsNullOrEmpty(txtPinHoleTole_Pos.Text) Then
            ObjClsWeldedCylinderFunctionalClass.TxtToleranceUpperLimit.Text = txtPinHoleTole_Pos.Text
        End If
        If Not String.IsNullOrEmpty(txtPinHoleTole_Neg.Text) Then
            ObjClsWeldedCylinderFunctionalClass.TxtToleranceLowerLimit.Text = txtPinHoleTole_Neg.Text
        End If

        'MANJULA ADDED
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then

            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTPortIntegral.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTPortIntegral.dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance

            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTPortIntegral2.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTPortIntegral2.dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance

            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance

            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral2.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral2.dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance


        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTPortInTube.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTPortInTube.dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance

            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTPortInTube2.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTPortInTube2.dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance

            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance

            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube2.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube2.dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance

        End If
    End Sub
    '***************

    'TODO: ANUP 20-05-2010
    Private Sub rdbDesignaCrossTube_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDesignaCrossTube.CheckedChanged
        If rdbDesignaCrossTube.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False        '20_10_2010    RAGAVA
            Dim strMessage As String = "Click OK to go to the CrossTube Design screens "
            If MessageBox.Show(strMessage, "Design CrossTube", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.OK Then
                grbMatchedCrossTubeFound.Hide()
                grbMatchedCrossTubeNotFound.Show()
                grbMatchedCrossTubeNotFound.BringToFront()
            Else
                rdbDesignaCrossTube.Checked = False
            End If
        End If
    End Sub
    '*****************

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblDesignNewCasting)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblSafetyFactorIndex)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblExistingULugsDetails)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblShowImage)
    End Sub

    Private Sub chkOptimizer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOptimizer.CheckedChanged
        Try
            WidthCalculation()      '27_10_2010    RAGAVA
        Catch ex As Exception
        End Try
    End Sub
End Class