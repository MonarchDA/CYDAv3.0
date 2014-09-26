Imports System.IO
Imports System.Data

Public Class frmDLDesignACasting

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
        txtLugGap.Enabled = False
        txtLugWidth.Enabled = False
        txtLugThickness.Enabled = True
        txtPinHoleSize.Enabled = False
        txtSwingClearance.Enabled = False
        SafetyFactor_LugThickness_Weight_GeneretedDesign()

        'TODO: Sandeep 26-02-10
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
        OrElse ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text <> _dblTempSwingClearance _
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
            (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, Me.chkOptimizer.Checked, _
            clsWeldedCylinderFunctionalClass.YeildStrengthConstants.DoubleLug_Cast_NoPort) '11_12_2009  Ragava
            txtLugGap.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap
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
            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation(dblSafetyFactor, Me.chkOptimizer.Checked, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.DoubleLug_Cast_NoPort) '11_12_2009  Ragava
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

    'TODO:SUNNY 26-02-10
    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click


        'ANUP 17-09-2010 START 
        If ObjClsWeldedCylinderFunctionalClass.SwingClearanceValidation_PartCondition_BaseEnd() Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance = Val(ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text) + 0.0625
        End If
        'ANUP 17-09-2010 TILL HERE 

        ObjClsWeldedCylinderFunctionalClass.dblDL_LugGap = Val(txtLugGap.Text)              '17_02_2010    RAGAVA

        'ObjClsWeldedCylinderFunctionalClass.RdbFabrication.Enabled = True

        'MANJULA COMMENTED
        ''ToDo:Sunny 06-04-10 10am
        'If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
        '    ObjClsWeldedCylinderFunctionalClass.RdbFabrication.Enabled = True
        'End If
        ''************************
        Me.Cursor = Cursors.WaitCursor

        Try
            'TODO:Check for EndofTubetoRodStop and BaseEndDistanceFromPinholetoRodStop from Raghava
            If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = -0.125
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5
            ElseIf ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
                '27_04_2010    RAGAVA  NEW DESIGN
                Dim _strQuery As String = ""
                Dim oSelectedBEDLDataRow As DataRow = Nothing
                If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then       '19_05_2010   RAGAVA     NEW DESIGN
                        _strQuery = "Select * from PortIntegralRaisedPortDetails where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness and portSize = " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text = "3/4", 0.75, 0.5625).ToString
                        oSelectedBEDLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = 0
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = 0
                        If Not IsNothing(oSelectedBEDLDataRow) Then
                            If Not IsDBNull(oSelectedBEDLDataRow("StickOut")) Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = oSelectedBEDLDataRow("StickOut")
                            End If
                            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Threaded End" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedBEDLDataRow("MinWallThickness") + oSelectedBEDLDataRow("ButtonHeight") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength 'min wall THK + button height + swing scearence+thread length
                            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedBEDLDataRow("MinWallThickness") + oSelectedBEDLDataRow("ButtonHeight") 'min wall THK + button height 
                            Else
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedBEDLDataRow("MinWallThickness") + oSelectedBEDLDataRow("ButtonHeight") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance ' min wall THK + button height + swing scearence
                            End If
                        End If
                        '19_05_2010   RAGAVA     NEW DESIGN
                    Else
                        _strQuery = "Select * from PortIntegralRaisedPortDetails90 where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness and portSize = " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text = "3/4", 0.75, 0.5625).ToString
                        oSelectedBEDLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = 0
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = 0
                        If Not IsNothing(oSelectedBEDLDataRow) Then
                            If Not IsDBNull(oSelectedBEDLDataRow("DistanceFromTubeEndToRodStop")) Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = oSelectedBEDLDataRow("DistanceFromTubeEndToRodStop")
                            End If
                            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Threaded End" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedBEDLDataRow("MinWallThickness") + oSelectedBEDLDataRow("ButtonHeight") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength 'min wall THK + button height + swing scearence+thread length
                            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedBEDLDataRow("MinWallThickness") + oSelectedBEDLDataRow("ButtonHeight") 'min wall THK + button height 
                            Else
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedBEDLDataRow("MinWallThickness") + oSelectedBEDLDataRow("ButtonHeight") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance ' min wall THK + button height + swing scearence
                            End If
                        End If
                    End If
                    'Till    Here
                Else
                    'Till   Here
                    '5_04_2010 Aruna
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = -0.125
                    _strQuery = ""
                    Dim dblButtonPlane As Double
                    Dim dblTotalWidth As Double
                    Dim oSelectedRESLDataRow As DataRow = Nothing
                    _strQuery = "Select * from welded.portIntegralDetails where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and TubeWallThickness= " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " and portDiameter= " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text = "3/4", 1.1, 0.9).ToString
                    oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
                    If Not IsNothing(oSelectedRESLDataRow) Then
                        If Not IsDBNull(oSelectedRESLDataRow("ButtonPlane")) Then
                            dblButtonPlane = oSelectedRESLDataRow("ButtonPlane")
                        End If
                        If Not IsDBNull(oSelectedRESLDataRow("TotalWidth")) Then
                            dblTotalWidth = oSelectedRESLDataRow("TotalWidth")
                        End If
                    End If
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = dblTotalWidth - dblButtonPlane - 0.125
                    '5_04_2010 Aruna Ends
                    ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + dblButtonPlane 'ANUP 22-04-2010
                End If
            End If
            If txtSafetyFactorOfCasting.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd = txtSafetyFactorOfCasting.Text
            End If

            If txtLugThickness.Text <> "" Then
                '30_05_2012  RAGAVA
                ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd.Text = txtLugThickness.Text
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness.Text)
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2 = Val(txtLugThickness.Text)
                End If
                'Till   Here
            End If
            Dim strName As String = String.Empty          '27_02_2010   RAGAVA
            Dim strFilePart As String = ""
            Dim strFilePartDesignTableExcel As String = ""
            If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" AndAlso _
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "OUTSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_DOUBLELUG")
                strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_DOUBLELUG\BEC_NO_PO_GR_DOUBLELUG.SLDPRT"
                strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_NO_PO_GR_DOUBLELUG.XLS"
                '20_04_2012  RAGAVA
                'Check
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_NO_PO_GR_DOUBLELUG"
                'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_NO_PO_GR_DOUBLELUG"
                'End If
                'Till  Here

                ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_DOUBLELUG", True)

            ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" AndAlso _
                             ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_DOUBLELUG")
                strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_DOUBLELUG\BEC_FL_PI_GR_DOUBLELUG.SLDPRT"
                strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_FL_PI_GR_DOUBLELUG.XLS"
                '20_04_2012  RAGAVA
                'Check
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PI_GR_DOUBLELUG"
                'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_FL_PI_GR_DOUBLELUG"
                ' End If
                'Till  Here

                'Aruna 19_3_2010
                ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_DOUBLELUG", True)
            ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" AndAlso _
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "OUTSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PO_GR_DOUBLELUG")
                strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PO_GR_DOUBLELUG\BEC_FL_PO_GR_DOUBLELUG.SLDPRT"
                strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_FL_PO_GR_DOUBLELUG.XLS"

                '20_04_2012  RAGAVA
                'Check
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PO_GR_DOUBLELUG"
                'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_FL_PO_GR_DOUBLELUG"
                'End If
                'Till  Here

                ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PO_GR_DOUBLELUG", True)

            ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" AndAlso _
                   ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_GR_DOUBLELUG")
                strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_GR_DOUBLELUG\BEC_RA_PI_GR_DOUBLELUG.SLDPRT"
                strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_RA_PI_GR_DOUBLELUG.XLS"

                '20_04_2012  RAGAVA
                'Check
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_GR_DOUBLELUG"
                'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_GR_DOUBLELUG"
                'End If
                'Till  Here
                ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_GR_DOUBLELUG", True)

            ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" AndAlso _
              ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "FILLET" Then
                If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then       '19_05_2010   RAGAVA     NEW DESIGN
                    ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_DOUBLELUG")
                    strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_DOUBLELUG\BEC_RA_PI_FI_DOUBLELUG.SLDPRT"
                    strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_RA_PI_FI_DOUBLELUG.XLS"
                    '20_04_2012  RAGAVA
                    'Check
                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_DOUBLELUG"
                    'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                    ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_FI_DOUBLELUG"
                    ' End If
                    'Till  Here
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_DOUBLELUG", True)
                    '19_05_2010   RAGAVA     NEW DESIGN
            Else
                ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_DOUBLELUG_90")
                strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_DOUBLELUG_90\BEC_RA_PI_FI_DOUBLELUG_90.SLDPRT"
                strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_RA_PI_FI_DOUBLELUG_90.XLS"
                    '20_04_2012  RAGAVA
                    'Check
                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_DOUBLELUG_90"
                    ' ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                    '  ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_FI_DOUBLELUG_90"
                    ' End If
                    'Till  Here
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_DOUBLELUG_90", True)
            End If
                'Till    Here
            End If



            ObjClsWeldedCylinderFunctionalClass.Design_New_Part(strFilePart, strFilePartDesignTableExcel, strName)
            ObjClsWeldedCylinderFunctionalClass.GenerateCasting = False
            Dim dblWeight As Double = ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Weight")

            Dim blnDuplicateFound As Boolean = False
            If lvwSafetyFactor_Weight.Items.Count > 0 Then
                For Each oItem As ListViewItem In lvwSafetyFactor_Weight.Items
                    If oItem.SubItems(WeightListView.SafetyFactor).Text.Equals(txtSafetyFactorOfCasting.Text) AndAlso _
                     oItem.SubItems(WeightListView.LugThickness).Text.Equals(txtLugThickness.Text) AndAlso oItem.SubItems(WeightListView.Weight).Text.Equals(dblWeight.ToString) Then         '28_10_2010   RAGAVA
                        blnDuplicateFound = True
                    End If
                Next
            End If
            If Not blnDuplicateFound Then
                Dim oListViewItem As ListViewItem
                oListViewItem = lvwSafetyFactor_Weight.Items.Add(txtSafetyFactorOfCasting.Text)
                lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(txtLugThickness.Text)
                lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(dblWeight)            '01_03_2010    RAGAVA
                _intSafetyFactorCount += 1
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in btnGenerate_Click of frmDLDesignACasting " + ex.Message)
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

                '24_02_2010   RAGAVA
                If (Val(txtLugThickness.Text) Mod 0.0625) <> 0 Then
                    Dim dblLugThick As Double = Math.Ceiling(Val(txtLugThickness.Text) / 0.0625)
                    dblLugThick = dblLugThick * 0.0625
                    txtLugThickness.Text = dblLugThick.ToString
                    MessageBox.Show("Value rounded to 1/16 multiple", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                End If
                'Till   Here
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness.Text)     '15_05_2012  RAGAVA
                '05_06_2012   RAGAVA
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
                'Till   Here



                trbSafetyFactor.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
                trbSafetyFactor.Maximum = trbSafetyFactor.Minimum + 20
                trbSafetyFactor.TickFrequency = 1
                trbSafetyFactor.Value = trbSafetyFactor.Minimum
                Dim dblSafetyFactor As Double = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
                txtSafetyFactorOfCasting.Text = dblSafetyFactor
            End If
        Else
            txtLugThickness.IFLDataTag = ""
        End If
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewCastingGenerated = True             '17_10_2012   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndCasting_New = True       '15_03_2012   RAGAVA
        If txtSafetyFactorOfCasting.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd = txtSafetyFactorOfCasting.Text
        End If
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast"       '15_03_2012   RAGAVA
        End If
        If txtLugThickness.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd.Text = txtLugThickness.Text   '30_05_2012  RAGAVA
            '20_04_2012  RAGAVA
            'Check
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness.Text)
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
            '  ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2 = Val(txtLugThickness.Text)
            'End If
            'Till   Here
        End If
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False        '20_10_2010   RAGAVA


        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        btnAccept.Enabled = False

        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast"               'Check
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness.Text)      'Check
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance = Val(txtSwingClearance.Text)  'Check
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugWidth.Text)              'Check
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Cast"       'Check

        '15_05_2012  RAGAVA  For CASTING
        If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTable = "Welded.BEDLCastWithOutPort"
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart = "BEC_NO_PO_GR_DOUBLELUG"
        Else
            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTable = "BEDLCastWithRaisedPort"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart = "BEC_RA_PI_GR_DOUBLELUG"
                Else
                    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTable = "BEDLCastWithRaisedPort"
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart = "BEC_RA_PI_FI_DOUBLELUG"
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTable = "BEDLCastWithRaisedPort90"
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart = "BEC_RA_PI_FI_DOUBLELUG_90"
                    End If
                End If
            ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart = "BEC_FL_PI_GR_DOUBLELUG"
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart = "BEC_FL_PO_GR_DOUBLELUG"
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTable = "Welded.BEDLCastWithFlushPort"
            End If
        End If
        'Till  Here


        ''14_03_2012  RAGAVA
        'Check
        'Try
        '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Cast"
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = True
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = False
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISFabricationChecked = False
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "NewDesign"         '30_05_2012   RAGAVA
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEDLCastWithOutPort"
        '    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then       '20_04_2012   RAGAVA
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign2 = "NewDesign"
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2 = "Cast"
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BEDLCastWithOutPort"
        '    End If
        'Catch ex As Exception

        'End Try
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