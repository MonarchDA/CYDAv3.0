Public Class frmBHDesignACasting

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

    Private _dblLugThickness As Double = 0

    Private _intSafetyFactorCount As Integer = 0

    Private _objDt_DesignBH As DataTable             '13_11_2009   Ragava

#End Region

#Region "Enums"

    Public Enum WeightListView
        SafetyFactor = 0
        LugThickness = 1
        Weight = 2
    End Enum

#End Region

#Region "SubProcedures"

    Private Sub DefaultSettings()
        btnAccept.Enabled = False
        txtSafetyFactorOfCasting.Enabled = False
        txtLugWidth.Enabled = False
        txtLugThickness.Enabled = False
        txtPinHoleSize.Enabled = False
        txtSwingClearance.Enabled = False
        SafetyFactor_LugThickness_Weight_GeneretedDesign()

        'Sandeep 25-02-10 10am
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
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
         OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness <> _dblLugThickness Then
            _dblTempNutSafetyFactor = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor
            _dblTempPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
            _dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
            _dblWorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure
            _intClass = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass
            _dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness

            ' ANUP 19-03-2010 11.00
            lvwSafetyFactor_Weight.Items.Clear()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            _intSafetyFactorCount = 0
            '***************

            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation _
         (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, Me.chkOptimizer.Checked, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.BH_Cast_NoPort)
            txtLugWidth.Text = Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth, 3)
            txtLugThickness.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
            txtPinHoleSize.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize

            'ANUP 17-09-2010 START 
            ' txtSwingClearance.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
            txtSwingClearance.Text = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text
            'ANUP 17-09-2010 TILL HERE

            trbSafetyFactor.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
            trbSafetyFactor.Maximum = trbSafetyFactor.Minimum + 20
            trbSafetyFactor.TickFrequency = 1
            trbSafetyFactor.Value = trbSafetyFactor.Minimum
            'TODO:Sunny 26-02-10 
            Dim dblSafetyFactor As Double = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
            txtSafetyFactorOfCasting.Text = dblSafetyFactor

        End If
    End Sub

    Private Sub WidthCalculation()
        Try
            Dim dblSafetyFactor As Double = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
            txtSafetyFactorOfCasting.Text = dblSafetyFactor
            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation(dblSafetyFactor, Me.chkOptimizer.Checked, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.BH_Cast_NoPort)           '11-12-2009  Ragava
            txtLugWidth.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
        Catch ex As Exception
        End Try
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

    Private Sub frmDesignACasting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        DefaultSettings()
        LoadFunctionality()
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            'ANUP 17-09-2010 START 
            If ObjClsWeldedCylinderFunctionalClass.SwingClearanceValidation_PartCondition_BaseEnd() Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance = Val(ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text) + 0.0625
            End If
            'ANUP 17-09-2010 TILL HERE 

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugWidth.Text)        '28_06_2012   RAGAVA

            If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = -0.125
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5
            ElseIf ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then

                '27_04_2010   RAGAVA
                Dim _strQuery As String = ""
                Dim oSelectedREBHDataRow As DataRow = Nothing
                If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then       '19_05_2010   RAGAVA     NEW DESIGN
                        _strQuery = "Select * from PortIntegralRaisedPortDetails where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness and portSize = " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text = "3/4", 0.75, 0.5625).ToString
                        oSelectedREBHDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = 0
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = 0
                        If Not IsNothing(oSelectedREBHDataRow) Then
                            If Not IsDBNull(oSelectedREBHDataRow("StickOut")) Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = oSelectedREBHDataRow("StickOut")
                            End If
                            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Threaded End" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedREBHDataRow("MinWallThickness") + oSelectedREBHDataRow("ButtonHeight") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength 'min wall THK + button height + swing scearence+thread length
                            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedREBHDataRow("MinWallThickness") + oSelectedREBHDataRow("ButtonHeight") 'min wall THK + button height 
                            Else
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedREBHDataRow("MinWallThickness") + oSelectedREBHDataRow("ButtonHeight") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance ' min wall THK + button height + swing scearence
                            End If
                        End If
                        '19_05_2010   RAGAVA     NEW DESIGN
                    Else
                        _strQuery = "Select * from PortIntegralRaisedPortDetails90 where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness and portSize = " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text = "3/4", 0.75, 0.5625).ToString
                        oSelectedREBHDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = 0
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = 0
                        If Not IsNothing(oSelectedREBHDataRow) Then
                            If Not IsDBNull(oSelectedREBHDataRow("DistanceFromTubeEndToRodStop")) Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = oSelectedREBHDataRow("DistanceFromTubeEndToRodStop")
                            End If
                            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Threaded End" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedREBHDataRow("MinWallThickness") + oSelectedREBHDataRow("ButtonHeight") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength 'min wall THK + button height + swing scearence+thread length
                            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedREBHDataRow("MinWallThickness") + oSelectedREBHDataRow("ButtonHeight") 'min wall THK + button height 
                            Else
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedREBHDataRow("MinWallThickness") + oSelectedREBHDataRow("ButtonHeight") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance ' min wall THK + button height + swing scearence
                            End If
                        End If
                    End If
                    'Till  Here
                Else
                    'Till  Here
                    Dim baseDia As Double
                    Dim PortBossDia As Double
                    oSelectedREBHDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortBossDiaAndBaseDia(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter)
                    If Not IsNothing(oSelectedREBHDataRow) Then
                        If Not IsDBNull(oSelectedREBHDataRow("BASEDIA")) Then
                            baseDia = oSelectedREBHDataRow("BASEDIA")
                        End If
                        If Not IsDBNull(oSelectedREBHDataRow("PortBossDia")) Then
                            PortBossDia = oSelectedREBHDataRow("PortBossDia")
                        End If
                    End If

                    Dim dblButtonPosition As Double
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2 Then
                        dblButtonPosition = 0.273
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter > 2 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 3 Then
                        dblButtonPosition = 0.281
                    Else
                        dblButtonPosition = 0.5
                    End If

                    Dim dblOverAllLength As Double
                    Dim dblTan_30 As Double = 0.57735026918962573
                    dblOverAllLength = ((baseDia - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter) / 2) * dblTan_30 + 0.17 + 0.2 + PortBossDia

                    '5_04_2010 Aruna
                    ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = dblButtonPosition - 0.125
                    _strQuery = ""
                    Dim dblButtonPlane As Double
                    Dim dblTotalWidth As Double
                    _strQuery = "Select * from welded.portIntegralDetails where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and TubeWallThickness= " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " and portDiameter= " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text = "3/4", 1.1, 0.9).ToString
                    oSelectedREBHDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
                    If Not IsNothing(oSelectedREBHDataRow) Then
                        If Not IsDBNull(oSelectedREBHDataRow("ButtonPlane")) Then
                            dblButtonPlane = oSelectedREBHDataRow("ButtonPlane")
                        End If
                        If Not IsDBNull(oSelectedREBHDataRow("TotalWidth")) Then
                            dblTotalWidth = oSelectedREBHDataRow("TotalWidth")
                        End If
                    End If
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = dblTotalWidth - dblButtonPlane - 0.125
                    '5_04_2010 Aruna Ends
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = dblButtonPlane + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
                End If
            End If
            If txtSafetyFactorOfCasting.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd = txtSafetyFactorOfCasting.Text
            End If

            If txtLugThickness.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd.Text = txtLugThickness.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness.Text)       '28_06_2012    RAGAVA
            End If
            '15_02_2010  Aruna Start
            ObjClsWeldedCylinderFunctionalClass.GenerateCasting = True
            Dim strFilePart As String = ""
            Dim strFilePartDesignTableExcel As String = ""
            Dim strName As String = "NewBHCastingPartCopied"
            If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" AndAlso _
             ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "OUTSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_BH")
                strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_BH\BEC_NO_PO_GR_BH.SLDPRT"
                strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_NO_PO_GR_BH.XLS"
                '24_02_2010 Aruna  single Line Start
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_NO_PO_GR_BH"
                'Aruna 19_3_2010
                ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_BH", True)
            ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" AndAlso _
                             ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_BH")
                strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_BH\BEC_FL_PI_GR_BH.SLDPRT"
                strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_FL_PI_GR_BH.XLS"
                '24_02_2010 Aruna  single Line Start
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PI_GR_BH"
                'Aruna 19_3_2010
                ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_BH", True)
            ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" AndAlso _
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "OUTSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PO_GR_BH")
                strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PO_GR_BH\BEC_FL_PO_GR_BH.SLDPRT"
                strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_FL_PO_GR_BH.XLS"
                '24_02_2010 Aruna  single Line Start
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PO_GR_BH"
                'Aruna 19_3_2010
                ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PO_GR_BH", True)
            ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" AndAlso _
                   ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_GR_BH")
                strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_GR_BH\BEC_RA_PI_GR_BH.SLDPRT"
                strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_RA_PI_GR_BH.XLS"
                '24_02_2010 Aruna  single Line Start
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_GR_BH"
                'Aruna 19_3_2010
                ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_GR_BH", True)
            ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" AndAlso _
              ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "FILLET" Then
                '19_05_2010   RAGAVA     NEW DESIGN
                If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                    ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_BH")
                    strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_BH\BEC_RA_PI_FI_BH.SLDPRT"
                    strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_RA_PI_FI_BH.XLS"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_BH"
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_BH", True)
                Else
                    ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_BH_90")
                    strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_BH_90\BEC_RA_PI_FI_BH_90.SLDPRT"
                    strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_RA_PI_FI_BH_90.XLS"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_BH_90"
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_BH_90", True)
                End If
                'Till  Here
            End If
            ObjClsWeldedCylinderFunctionalClass.NewSLCastingPartCopied = True
            ObjClsWeldedCylinderFunctionalClass.Design_New_Part(strFilePart, strFilePartDesignTableExcel, strName)
            ObjClsWeldedCylinderFunctionalClass.GenerateCasting = False
            Dim dblWeight As Double = ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Weight")
            '15_02_2010  Aruna End


            Dim blnDuplicateFound As Boolean = False
            If lvwSafetyFactor_Weight.Items.Count > 0 Then
                For Each oItem As ListViewItem In lvwSafetyFactor_Weight.Items
                    If oItem.SubItems(WeightListView.SafetyFactor).Text.Equals(txtSafetyFactorOfCasting.Text) AndAlso _
                     oItem.SubItems(WeightListView.LugThickness).Text.Equals(txtLugThickness.Text) AndAlso oItem.SubItems(WeightListView.Weight).Text.Equals(dblWeight.ToString) Then         '28_10_2010   RAGAVA
                        blnDuplicateFound = True
                        Exit For
                    End If
                Next
            End If
            If Not blnDuplicateFound Then
                Dim oListViewItem As ListViewItem
                oListViewItem = lvwSafetyFactor_Weight.Items.Add(txtSafetyFactorOfCasting.Text)
                lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(txtLugThickness.Text)
                lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(dblWeight)
                _intSafetyFactorCount += 1
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in btnGenerate_Click of frmBHDesignACasting " + ex.Message)
        End Try
    End Sub

    Private Sub trbSafetyFactor_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trbSafetyFactor.Scroll
        For Each oItem As ListViewItem In lvwSafetyFactor_Weight.Items
            oItem.Selected = False
        Next
    End Sub

    Private Sub trbSafetyFactor_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trbSafetyFactor.ValueChanged
        WidthCalculation()
    End Sub

    Private Sub txtLugThickness_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLugThickness.Leave
        If txtLugThickness.Text <> "" Then
            If txtLugThickness.Text <> txtLugThickness.IFLDataTag Then
                txtLugThickness.IFLDataTag = txtLugThickness.Text
                trbSafetyFactor.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
                trbSafetyFactor.Maximum = trbSafetyFactor.Minimum + 20
                trbSafetyFactor.TickFrequency = 1
                trbSafetyFactor.Value = trbSafetyFactor.Minimum
                Dim dblSafetyFactor As Double = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
                txtSafetyFactorOfCasting.Text = dblSafetyFactor
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness.Text)     '28_06_2012   RAGAVA
                '28_06_2012    RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmBHPortIntegral._dblTempLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmBHPortIntegral2._dblTempLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortIntegral.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortIntegral2.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness

                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmBHPortinTube._dblTempLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmBHPortinTube2._dblTempLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortInTube.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortInTube2.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "NewDesign"
                'Till   Here
            End If
        Else
            txtLugThickness.IFLDataTag = ""
        End If
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        Try
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewCastingGenerated = True             '17_10_2012   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndCasting_New = True
            If txtSafetyFactorOfCasting.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd = txtSafetyFactorOfCasting.Text
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast"       '28_06_2012   RAGAVA
            End If
            If txtLugThickness.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd.Text = txtLugThickness.Text
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False        '20_10_2010   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
            btnAccept.Enabled = False
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "NewDesign"
            '28_06_2012    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast"
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness.Text)
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance = Val(txtSwingClearance.Text)
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugWidth.Text)
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Cast"
            '28_06_2012   RAGAVA
            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTable = "BEBHCastingRaisedPort"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart = "BEC_RA_PI_FI_BH"
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTable = "BEBHCastingRaisedPort90"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart = "BEC_RA_PI_FI_BH_90"
                End If
            Else
                If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTable = "WELDED.Base_End_BH_No_Port"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart = "BEC_NO_PO_GR_BH"
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTable = "WELDED.Base_End_BH_Flush_Port"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart = "BEC_FL_PI_GR_BH"
                End If
            End If
            'Till  Here
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lvwSafetyFactor_Weight_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwSafetyFactor_Weight.SelectedIndexChanged
        If lvwSafetyFactor_Weight.SelectedIndices.Count > 0 Then
            Dim oListViewSelectedItem As ListViewItem = lvwSafetyFactor_Weight.SelectedItems(0)
            trbSafetyFactor.Value = ((Val(oListViewSelectedItem.SubItems(WeightListView.SafetyFactor).Text) - trbSafetyFactor.Minimum) / 0.25) + trbSafetyFactor.Minimum
            txtLugThickness.Text = oListViewSelectedItem.SubItems(WeightListView.LugThickness).Text
            btnAccept.Enabled = True
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            ObjClsWeldedCylinderFunctionalClass.BaseEndWeight = Val(oListViewSelectedItem.SubItems(WeightListView.Weight).Text)
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