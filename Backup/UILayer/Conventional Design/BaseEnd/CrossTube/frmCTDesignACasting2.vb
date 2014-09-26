Imports System.IO
Imports System.Data
Public Class frmCTDesignACasting2

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

    Private _dblTempNutSafetyFactor As Double = 0

    Private _dblTempPinHoleSize As Double = 0

    Private _dblTempSwingClearance As Double = 0

    Private _dblWorkingPressure As Double = 0

    Private _intClass As Integer = 0

    Private _dblCrossTubeWidth As Double = 0

    Private _intSafetyFactorCount As Integer = 0
    Private _portType As String

#End Region

#Region "Enum"

    Public Enum WeightListView
        SafetyFactor = 0
        LugWidth = 1
        Weight = 2
    End Enum

#End Region

#Region "SubProcedures"

    Private Sub DefaultSettings()
        txtCrossTubeWidth_DesignCrossTubeCasting.Enabled = True
        txtCrossTubeOD_DesignCrossTubeCasting.Enabled = False
        txtPinHoleSize_DesignCrossTubeCasting.Enabled = False
        txtSwingClearance_DesignCrossTubeCasting.Enabled = False
        txtSafetyFactorOfCasting.Enabled = False
        btnAccept.Enabled = False
        SafetyFactor_LugThickness_Weight_GeneretedDesign()
    End Sub

    Public Sub ManualLoad()
        LoadFunctionality()
    End Sub

    Private Sub LoadFunctionality()
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor <> _dblTempNutSafetyFactor _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize <> _dblTempPinHoleSize _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance <> _dblTempSwingClearance _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure <> _dblWorkingPressure _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass <> _intClass _
         OrElse ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube <> _portType _
         OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth <> _dblCrossTubeWidth Then
            '16-02-10 Sandeep
            If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
                ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation _
                         (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, Me.chkOptimizer.Checked, _
                                     clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube_Cast_NoPort, "2")    '12_07_2012   RAGAVA 
            ElseIf ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
                ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation _
                         (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, Me.chkOptimizer.Checked, _
                                     clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube_Cast_FlushedPort, "2")    '12_07_2012   RAGAVA 
            End If
            '16-02-10 Sandeep

            ' ANUP 19-03-2010 11.00
            lvwSafetyFactor_Weight.Items.Clear()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            _intSafetyFactorCount = 0
            '***************

            _dblTempNutSafetyFactor = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor
            _dblTempPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
            _dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
            _dblWorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure
            _intClass = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass
            _dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
            _portType = ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube

            txtCrossTubeOD_DesignCrossTubeCasting.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD
            txtCrossTubeWidth_DesignCrossTubeCasting.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
            txtPinHoleSize_DesignCrossTubeCasting.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
            txtSwingClearance_DesignCrossTubeCasting.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance

            trbSafetyFactor.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
            trbSafetyFactor.Maximum = trbSafetyFactor.Minimum + 40 'ANUP 09-11-2010 START
            trbSafetyFactor.TickFrequency = 1
            trbSafetyFactor.Value = trbSafetyFactor.Minimum
            txtSafetyFactorOfCasting.Text = trbSafetyFactor.Value

            SetSafetyFactor()
        End If
    End Sub

    Private Sub WidthCalculation()
        Dim dblSafetyFactor As Double = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
        txtSafetyFactorOfCasting.Text = dblSafetyFactor
        '26_10_2010  RAGAVA
        'If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
        '    ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation _
        '             (dblSafetyFactor, _
        '                         clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube_Cast_NoPort)
        'ElseIf ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
        '    ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation _
        '             (dblSafetyFactor, _
        '                         clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube_Cast_FlushedPort)
        'End If
        If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation _
                     (dblSafetyFactor, Me.chkOptimizer.Checked, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube_Cast_NoPort, "2")    '12_07_2012   RAGAVA 
        ElseIf ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation _
                     (dblSafetyFactor, Me.chkOptimizer.Checked, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube_Cast_FlushedPort, "2")    '12_07_2012   RAGAVA 
        End If
        'Till   Here
        txtSwingClearance_DesignCrossTubeCasting.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2    '12_07_2012   RAGAVA 
        txtCrossTubeOD_DesignCrossTubeCasting.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD2    '12_07_2012   RAGAVA 
        '16-02-10 Sandeep
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

    Private Sub frmCTDesignACasting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        DefaultSettings()
        LoadFunctionality()
    End Sub

    Private Sub trbSafetyFactor_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trbSafetyFactor.Scroll
        'btnAccept.Enabled = False
        WidthCalculation()
        For Each oItem As ListViewItem In lvwSafetyFactor_Weight.Items
            oItem.Selected = False
        Next
    End Sub

    Private Sub txtCrossTubeWidth_DesignCrossTubeCasting_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCrossTubeWidth_DesignCrossTubeCasting.Leave
        If txtCrossTubeWidth_DesignCrossTubeCasting.Text <> "" Then
            If txtCrossTubeWidth_DesignCrossTubeCasting.Text <> txtCrossTubeWidth_DesignCrossTubeCasting.IFLDataTag Then
                txtCrossTubeWidth_DesignCrossTubeCasting.IFLDataTag = txtCrossTubeWidth_DesignCrossTubeCasting.Text
                trbSafetyFactor.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
                trbSafetyFactor.Maximum = trbSafetyFactor.Minimum + 40 'ANUP 09-11-2010 START
                trbSafetyFactor.TickFrequency = 1
                trbSafetyFactor.Value = trbSafetyFactor.Minimum
                txtSafetyFactorOfCasting.Text = trbSafetyFactor.Value

                btnAccept.Enabled = False
                '16-02-10 Sandeep
                If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
                    ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation _
                             (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, Me.chkOptimizer.Checked, _
                                         clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube_Cast_NoPort, "2")    '12_07_2012   RAGAVA 
                ElseIf ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
                    ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation _
                             (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, Me.chkOptimizer.Checked, _
                                         clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube_Cast_FlushedPort, "2")    '12_07_2012   RAGAVA 
                End If
                txtSwingClearance_DesignCrossTubeCasting.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2    '12_07_2012   RAGAVA 
                txtCrossTubeOD_DesignCrossTubeCasting.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD2    '12_07_2012   RAGAVA 
                '16-02-10 Sandeep
            End If
        Else
            txtCrossTubeWidth_DesignCrossTubeCasting.IFLDataTag = ""
        End If
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewCastingGenerated = True             '17_10_2012   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndCasting_New = True       '15_03_2012   RAGAVA
        '26_02_2010 Aruna Start
        If txtSafetyFactorOfCasting.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd2 = txtSafetyFactorOfCasting.Text    '12_07_2012   RAGAVA 
        End If

        If txtCrossTubeWidth_DesignCrossTubeCasting.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.TxtCrossTubeWidth_BaseEnd.Text = txtCrossTubeWidth_DesignCrossTubeCasting.Text
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth2 = Val(txtCrossTubeWidth_DesignCrossTubeCasting.Text)    '12_07_2012   RAGAVA 
        End If

        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        btnAccept.Enabled = False
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign2 = "NewDesign"    '12_07_2012   RAGAVA 
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False        '20_10_2010   RAGAVA
        '26_02_2010 Aruna Ends


        '12_07_2012   RAGAVA
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BECrossTubeCastingWithoutPort"
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "Welded.BECrossTubeCastingWithoutPort"
        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then
            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "BECrossTubeRaisedPort"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "BECrossTubeRaisedPort"
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "BECrossTubeRaisedPort90"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "BECrossTubeRaisedPort90"
                End If
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BECrossTubeFlushPort"
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "Welded.BECrossTubeFlushPort"
            End If
        End If
        'Till  Here


        'ObjClsWeldedCylinderFunctionalClass.TxtCrossTubeWidth_BaseEnd.Text = txtCrossTubeWidth_DesignCrossTubeCasting.Text
        ''Added by Sandeep --set  This parameter for retracted length calculation(the value which we are going to insert in db)
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinHoletoRodStop = oSelectedCastingDataRow("DistancefromPinholetoRodStop")

    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Try
            '15_02_2010 Aruna Start 
            ObjClsWeldedCylinderFunctionalClass.GenerateCasting = True
            btnAccept.Enabled = True
            Me.Cursor = Cursors.WaitCursor
            Dim strFilePart As String = ""
            Dim strFilePartDesignTableExcel As String = ""
            Dim strName As String = "NewCrossTubePartCopied"

            '26_02_2010 Aruna Start
            If txtSafetyFactorOfCasting.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd2 = txtSafetyFactorOfCasting.Text
            End If
            '12_07_2012   RAGAVA 
            If txtCrossTubeOD_DesignCrossTubeCasting.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD2 = Val(txtCrossTubeOD_DesignCrossTubeCasting.Text)
            End If
            If txtSwingClearance_DesignCrossTubeCasting.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2 = Val(txtSwingClearance_DesignCrossTubeCasting.Text)
            End If
            'Till   Here
            If txtCrossTubeWidth_DesignCrossTubeCasting.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtCrossTubeWidth_BaseEnd.Text = txtCrossTubeWidth_DesignCrossTubeCasting.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth2 = Val(txtCrossTubeWidth_DesignCrossTubeCasting.Text)    '12_07_2012   RAGAVA 
            End If
            '28_08_2012   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2    '12_07_2012   RAGAVA 


            If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2 = -0.125
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2 = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2 + 0.5

            ElseIf ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then

                '27_04_2010   RAGAVA  NEW DESIGN
                Dim _strQuery As String = ""
                Dim oSelectedBECTDataRow As DataRow = Nothing
                If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then       '19_05_2010   RAGAVA     NEW DESIGN
                        _strQuery = "Select * from PortIntegralRaisedPortDetails where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness and portSize = " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text = "3/4", 0.75, 0.5625).ToString
                        oSelectedBECTDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2 = 0
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2 = 0
                        If Not IsNothing(oSelectedBECTDataRow) Then
                            If Not IsDBNull(oSelectedBECTDataRow("StickOut")) Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2 = oSelectedBECTDataRow("StickOut")
                            End If
                            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Threaded End" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2 = oSelectedBECTDataRow("MinWallThickness") + oSelectedBECTDataRow("ButtonHeight") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength 'min wall THK + button height + swing scearence+thread length
                            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2 = oSelectedBECTDataRow("MinWallThickness") + oSelectedBECTDataRow("ButtonHeight") 'min wall THK + button height 
                            Else
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2 = oSelectedBECTDataRow("MinWallThickness") + oSelectedBECTDataRow("ButtonHeight") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance ' min wall THK + button height + swing scearence
                            End If
                        End If
                        '19_05_2010   RAGAVA     NEW DESIGN
                    Else
                        _strQuery = "Select * from PortIntegralRaisedPortDetails90 where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness and portSize = " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text = "3/4", 0.75, 0.5625).ToString
                        oSelectedBECTDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2 = 0
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2 = 0
                        If Not IsNothing(oSelectedBECTDataRow) Then
                            If Not IsDBNull(oSelectedBECTDataRow("DistanceFromTubeEndToRodStop")) Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2 = oSelectedBECTDataRow("DistanceFromTubeEndToRodStop")
                            End If
                            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Threaded End" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2 = oSelectedBECTDataRow("MinWallThickness") + oSelectedBECTDataRow("ButtonHeight") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength 'min wall THK + button height + swing scearence+thread length
                            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2 = oSelectedBECTDataRow("MinWallThickness") + oSelectedBECTDataRow("ButtonHeight") 'min wall THK + button height 
                            Else
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2 = oSelectedBECTDataRow("MinWallThickness") + oSelectedBECTDataRow("ButtonHeight") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance ' min wall THK + button height + swing scearence
                            End If
                        End If
                    End If
                    'Till  Here
                Else
                    Dim baseDia As Double
                    Dim PortBossDia As Double
                    oSelectedBECTDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortBossDiaAndBaseDia(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter)
                    If Not IsNothing(oSelectedBECTDataRow) Then
                        If Not IsDBNull(oSelectedBECTDataRow("BASEDIA")) Then
                            baseDia = oSelectedBECTDataRow("BASEDIA")
                        End If
                        If Not IsDBNull(oSelectedBECTDataRow("PortBossDia")) Then
                            PortBossDia = oSelectedBECTDataRow("PortBossDia")
                        End If
                    End If

                    Dim dblButtonPosition As Double
                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2 Then
                    '    dblButtonPosition = 0.273
                    'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter > 2 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 3 Then
                    '    dblButtonPosition = 0.281
                    'Else
                    '    dblButtonPosition = 0.5
                    'End If

                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2.5 Then
                        dblButtonPosition = 0.273
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter > 2.5 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 3 Then
                        dblButtonPosition = 0.281
                    Else
                        dblButtonPosition = 0.5
                    End If

                    '5_04_2010 Aruna
                    ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = dblButtonPosition - 0.125
                    _strQuery = ""
                    Dim dblButtonPlane As Double
                    Dim dblTotalWidth As Double
                    _strQuery = "Select * from welded.portIntegralDetails where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and TubeWallThickness= " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " and portDiameter= " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text = "3/4", 1.1, 0.9).ToString
                    oSelectedBECTDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
                    If Not IsNothing(oSelectedBECTDataRow) Then
                        If Not IsDBNull(oSelectedBECTDataRow("ButtonPlane")) Then
                            dblButtonPlane = oSelectedBECTDataRow("ButtonPlane")
                        End If
                        If Not IsDBNull(oSelectedBECTDataRow("TotalWidth")) Then
                            dblTotalWidth = oSelectedBECTDataRow("TotalWidth")
                        End If
                    End If
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2 = dblTotalWidth - dblButtonPlane - 0.125
                    'SELECT * FROM Welded.portintegraldetails where nominalboreDia=2.5 and TubeWallThickness=0.170 and portDiameter=1.10
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2 = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + dblButtonPlane
                End If
            End If
            '26_02_2010 Aruna Ends

            If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" AndAlso _
                     ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "OUTSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_CROSSTUBE\BEC_NO_PO_GR_CROSSTUBE.SLDPRT"
                strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_NO_PO_GR_CROSSTUBE.XLS"
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_NO_PO_GR_CROSSTUBE"     '12_07_2012   RAGAVA 
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart = "BEC_NO_PO_GR_CROSSTUBE"     '17_07_2012   RAGAVA 
                ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_CROSSTUBE", True)
            ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" AndAlso _
                             ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_CROSSTUBE\BEC_FL_PI_GR_CROSSTUBE.SLDPRT"
                strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_FL_PI_GR_CROSSTUBE.XLS"
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_FL_PI_GR_CROSSTUBE"    '12_07_2012   RAGAVA 
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart = "BEC_FL_PI_GR_CROSSTUBE"     '17_07_2012   RAGAVA 
                ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_CROSSTUBE", True)

            ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" AndAlso _
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "OUTSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PO_GR_CROSSTUBE")
                strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PO_GR_CROSSTUBE\BEC_FL_PO_GR_CROSSTUBE.SLDPRT"
                strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_FL_PO_GR_CROSSTUBE.XLS"
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_FL_PO_GR_CROSSTUBE"     '12_07_2012   RAGAVA 
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart = "BEC_FL_PO_GR_CROSSTUBE"     '17_07_2012   RAGAVA 
                ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PO_GR_CROSSTUBE", True)

            ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" AndAlso _
                   ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_GR_CROSSTUBE")
                strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_GR_CROSSTUBE\BEC_RA_PI_GR_CROSSTUBE.SLDPRT"
                strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_RA_PI_GR_CROSSTUBE.XLS"
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_GR_CROSSTUBE"     '12_07_2012   RAGAVA 
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart = "BEC_RA_PI_GR_CROSSTUBE"     '17_07_2012   RAGAVA 
                ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_GR_CROSSTUBE", True)
            ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" AndAlso _
              ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "FILLET" Then
                'ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_CROSSTUBE")
                'strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_CROSSTUBE\BEC_RA_PI_FI_CROSSTUBE.SLDPRT"
                'strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_RA_PI_FI_CROSSTUBE.XLS"
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_CROSSTUBE" '26_02_2010 Aruna
                ''Aruna 19_3_2010
                'ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_CROSSTUBE", True)
                '19_05_2010    RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                    ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_CROSSTUBE")
                    strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_CROSSTUBE\BEC_RA_PI_FI_CROSSTUBE.SLDPRT"
                    strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_RA_PI_FI_CROSSTUBE.XLS"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_FI_CROSSTUBE"    '12_07_2012   RAGAVA 
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart = "BEC_RA_PI_FI_CROSSTUBE"     '17_07_2012   RAGAVA 
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_CROSSTUBE", True)
                Else            'Port type is 90 deg
                    ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_CROSSTUBE_90")
                    strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_CROSSTUBE_90\BEC_RA_PI_FI_CROSSTUBE_90.SLDPRT"
                    strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_RA_PI_FI_CROSSTUBE_90.XLS"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_FI_CROSSTUBE_90"    '12_07_2012   RAGAVA 
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart = "BEC_RA_PI_FI_CROSSTUBE_90"     '17_07_2012   RAGAVA 
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_CROSSTUBE_90", True)
                End If
                'Till    Here
            End If
            ObjClsWeldedCylinderFunctionalClass.Design_New_Part(strFilePart, strFilePartDesignTableExcel, "CrossTubeCastBaseEnd")
            ObjClsWeldedCylinderFunctionalClass.GenerateCasting = False
            Dim dblWeight As Double = ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Weight")
            Dim oListViewItem As ListViewItem
            oListViewItem = lvwSafetyFactor_Weight.Items.Add(txtSafetyFactorOfCasting.Text)
            lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(txtCrossTubeWidth_DesignCrossTubeCasting.Text)
            lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(dblWeight)
            _intSafetyFactorCount += 1
            '15_02_2010 Aruna End
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in btnGenerate_Click of frmCTDesignACasting " + ex.Message)
        End Try
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

    Private Function FindSafetyFactor() As Double
        Dim dblPinHoleSize As Double
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity = 0 Then
            dblPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
        Else
            dblPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingOD_BaseEnd
        End If
        Dim CrossTubeOD As Double = dblPinHoleSize + (2 * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired)
        Dim dblRequiredArea As Double
        Dim dblReqSF As Double
        If CrossTubeOD < ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD Then
            dblRequiredArea = ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD - dblPinHoleSize) * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth) / ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
            dblReqSF = dblRequiredArea * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor
            Return dblReqSF
        End If
        Return 0
    End Function

    Private Sub SetSafetyFactor()
        Dim dblSF As Double = FindSafetyFactor()
        Dim MaxValue As Double = trbSafetyFactor.Minimum + ((trbSafetyFactor.Maximum - trbSafetyFactor.Value) * 0.25) '(trbSafetyFactor_RECT.Maximum - 2) / 4
        If dblSF > MaxValue Then
            dblSF = ObjClsWeldedCylinderFunctionalClass.RoundUp(dblSF, 2)
            Dim strMessage As String = "Safety Factor is : " + dblSF.ToString + " which is above the given range"
            MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Try
                trbSafetyFactor.Value = ((dblSF - trbSafetyFactor.Minimum) / 0.25) + trbSafetyFactor.Minimum
                trbSafetyFactor.Text = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
            Catch ex As Exception
                trbSafetyFactor.Value = trbSafetyFactor.Minimum
                trbSafetyFactor.Text = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
            End Try
        End If
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblDesignNewCasting)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblSafetyFactorIndex)
    End Sub

    Private Sub chkOptimizer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOptimizer.CheckedChanged
        Try
            WidthCalculation()
        Catch ex As Exception
        End Try
    End Sub
End Class