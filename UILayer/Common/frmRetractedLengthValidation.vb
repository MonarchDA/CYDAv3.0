Public Class frmRetractedLengthValidation

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

    Private _dblRetractedLength As Double

    Private _dblRodPinHoletoRodStop As Double

    Private _dblUGroove As Double

    Private _dblSkimWidth As Double

    Private _dbldefaultStickOut As Double

    Private _dblBaseEndDistanceFromPinHoletoRodStop As Double

    Private _dblDim8FromPistonEndofRod As Double

    Private _dblStrokeLength As Double

    Private _dblOverAllCylinderLength As Double

    Private _dblStickOut As Double

    Private _strSingle_DoubleRadii As String

    'TODO: ANUP STARTED 24-02-2010
    Private _blnCounterBoreApplicableOrNot As Boolean

    Private _dblCounterBoreDepth2 As Double

    Private _dblRemainingOrificeDistance As Double

    Private _dblRemainingPossibleCounterBoreDepth As Double

    Private _dblOrificeOffset As Double

    Private _dblReductionInRodButtonLength As Double

    Private _dblExtraRodButtonLength1 As Double

    Private _dblPistonTosealDistance As Double

    Private _dblExtraRodButtonLength2 As Double

    Private _dblRodLength As Double

    ' ANUP END 24-02-2010

    Private _dblExtraRodButtonLength3 As Double 'TODO:Sandeep 26-02-10

    ' ANUP SWINGCLEARANCE 05-03-2010 04.46
    Private _dblAdjustSwingClearance_BE As Double
    Private _dblAdjustSwingClearance_RE As Double
    '*********************

    'ANUP 22-03-2010 01.58
    Dim _strCounterboredClevisPlateCode As String
    '*******************

    'TODO: ANUP 06-04-2010 04.45
    Dim _dblCounterBoreClevisPlateThickness As Double
    Dim _dblCounterboredClevisPlateRodStopDistance As Double


#End Region

#Region "enums"

    Public Enum BEULugdetails
        Single_DoubleRadii = 0
    End Enum

#End Region

#Region "Properties"
    Public Property Dim8FromPistonEndofRod() As Double
        Get
            Return _dblDim8FromPistonEndofRod
        End Get
        Set(ByVal value As Double)
            _dblDim8FromPistonEndofRod = value
        End Set
    End Property
#End Region

#Region "Functions"

#End Region

#Region "SubProcedures"

    Private Sub DefaultSettings()

        txtCompressCylinderHead.Enabled = False
        txtReducingSkimLengthOfRod.Enabled = False
        txtOffsetPortOrifice.Enabled = False
        txtReplaceFabricatedULugwithFabricatedDoubleLug.Enabled = False

        ' ANUP SWINGCLEARANCE 05-03-2010 04.46
        'txtAdjustSwingClearance_BE.Enabled = False
        'txtAdjustSwingClearance_RE.Enabled = False
        '*********************

        txtCompressCylinderHead.Text = "0.13"
        txtReducingSkimLengthOfRod.Text = "0.125"
        txtRequiredRetractedLength.Enabled = False
        txtRequiredRetractedLength.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength
        txtRecommendedRetractedLength.Enabled = False
        txtStickOutDistance.Enabled = False

        If ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.cmbHeadType.Text = "Threaded" Then
            chkCompressCylinderHead.Enabled = True
        Else
            chkCompressCylinderHead.Enabled = False
        End If

        'TODO: ANUP 05-07-2010 12.47pm
        If ObjClsWeldedCylinderFunctionalClass.CmbRodEndConfiguration_RodEnd.Text = "Threaded Rod" OrElse ObjClsWeldedCylinderFunctionalClass.CmbRodEndConfiguration_RodEnd.Text = "Flat With Chamfer" _
        OrElse ObjClsWeldedCylinderFunctionalClass.CmbRodEndConfiguration_RodEnd.Text = "Drilled Pin Hole" Then
            chkReducingSkimLengthOfRod.Enabled = False
            _dblSkimWidth = 0
        ElseIf ObjClsWeldedCylinderFunctionalClass.CmbRodEndConfiguration_RodEnd.Text = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.cmbConnectionType_RodEnd.Text = "Threaded" Then
            chkReducingSkimLengthOfRod.Enabled = False
            _dblSkimWidth = 0
        Else
            chkReducingSkimLengthOfRod.Enabled = True
            _dblSkimWidth = 0.25
        End If


        ' ANUP SWINGCLEARANCE 05-03-2010 04.46
        'chkAdjustSwingClearance_BE.Enabled = False
        'chkAdjustSwingClearance_RE.Enabled = False
        'chkAdjustSwingClearance_RE.Checked = False
        '***********************

        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False

        'chkCounterBorePistonAndOffsetPortOrifice.Checked = False
        'chkCounterBorePistonAndOffsetPortOrifice.Enabled = True

        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" Then
        '    chkAdjustSwingClearance_BE.Enabled = False
        '    txtAdjustSwingClearance_BE.Enabled = False
        'Else
        '    chkAdjustSwingClearance_BE.Enabled = True
        '    SwingClearance_BE()
        'End If

        'If ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbRodEndConfiguration_RodEnd.Text = "Cross Tube" Then
        '    chkAdjustSwingClearance_RE.Checked = False
        '    chkAdjustSwingClearance_RE.Enabled = False
        '    txtAdjustSwingClearance_RE.Enabled = False
        'Else
        '    chkAdjustSwingClearance_RE.Checked = False
        '    chkAdjustSwingClearance_RE.Enabled = True
        '    SwingClearance_RE()
        'End If
        'txtCounterBorePiston.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreDepth_RetractedLength

        ' ANUP SWINGCLEARANCE 05-03-2010 04.46
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbBaseEndConfiguration.Text = "Single Lug" OrElse _
       ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbBaseEndConfiguration.Text = "Double Lug" Then
            txtAdjustSwingClearance_BE.Enabled = True
        Else
            chkAdjustSwingClearance_BE.Enabled = False
            txtAdjustSwingClearance_BE.Enabled = False
        End If

        SwingClearance_BE()

        If ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbRodEndConfiguration_RodEnd.Text = "Single Lug" OrElse _
                  ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbRodEndConfiguration_RodEnd.Text = "Double Lug" Then
            txtAdjustSwingClearance_RE.Enabled = True
        Else
            chkAdjustSwingClearance_RE.Enabled = False
            txtAdjustSwingClearance_RE.Enabled = False
        End If
        SwingClearance_RE()
        '**********

        ' ANUP 22-03-2010 12.13
        'SearchForCounterBoreClevisPlates()
        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis" AndAlso Not _strCounterboredClevisPlateCode = "N/A" Then
        '    If _strCounterboredClevisPlateCode = "TBA" Then
        '        MessageBox.Show("There is no Counter Bore Clevis Plate for the selected details", "Choose different Bore Diameter or TubeOD", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)
        '        chkCounterBoreClevisPlate.Enabled = False
        '        txtCounterBoreClevisPlate.Enabled = False
        '        txtCounterBoreClevisPlate.Text = ""
        '    Else
        '        chkCounterBoreClevisPlate.Enabled = True
        '        txtCounterBoreClevisPlate.Enabled = False
        '    End If
        'Else
        '    Aruna 01_4_2010
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode = 0
        '    chkCounterBoreClevisPlate.Enabled = False
        '    txtCounterBoreClevisPlate.Enabled = False
        '    txtCounterBoreClevisPlate.Text = ""
        'End If
        '****************
        ' ANUP 05-04-2010 04.20
        ' ANUP 06-04-2010 010.20
        chkCounterBoreClevisPlate.Enabled = False
        txtCounterBoreClevisPlate.Enabled = False
        txtCounterBoreClevisPlate.Text = ""
        '************
        'TODO: ANUP 22-04-2010 11.23am
        CounterBoreClevisPlateValidation()
        '************

        'TODO:  ANUP 24-05-2010 10.36am
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GoToBaseEndScreenFromRetractedScreen = False
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GoToRodEndScreenFromRetractedScreen = False
        '**********************

    End Sub

    'TODO: ANUP 22-04-2010 11.23am
    Public Sub CounterBoreClevisPlateValidation()
        SearchForCounterBoreClevisPlates()
        'TODO: ANUP 06-04-2010 04.45
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISFabricationChecked = True Then
            '***********
            'If Not _strCounterboredClevisPlateCode = "N/A" Then
            '    If _strCounterboredClevisPlateCode = "TBA" Then
            '        'MessageBox.Show("There is no Counter Bore Clevis Plate for the selected details", "Choose different Bore Diameter or TubeOD", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)
            '        chkCounterBoreClevisPlate.Enabled = False
            '        txtCounterBoreClevisPlate.Enabled = False
            '        txtCounterBoreClevisPlate.Text = ""
            '    Else
            chkCounterBoreClevisPlate.Enabled = True
            txtCounterBoreClevisPlate.Enabled = False
            'End If
        Else
            'Aruna 01_4_2010
            ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode = 0
            chkCounterBoreClevisPlate.Enabled = False
            txtCounterBoreClevisPlate.Enabled = False
            txtCounterBoreClevisPlate.Text = ""
            'End If
        End If
        '****************
    End Sub
    '************

    ' ANUP 22-03-2010 02.20
    Public Sub SearchForCounterBoreClevisPlates()
        Try

            Dim oCounterBoreClevisPlatesDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPlateClevisDetails(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, _
                                                          ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD)

            Dim dblStandardClevisPlateRodStopDistance As Double

            If Not IsNothing(oCounterBoreClevisPlatesDataTable) AndAlso oCounterBoreClevisPlatesDataTable.Rows.Count > 0 Then
                ' ANUP 06-04-2010 010.20
                Dim oCounterBoreClevisPlatesDataRow As DataRow = oCounterBoreClevisPlatesDataTable.Rows(0)
                _dblCounterboredClevisPlateRodStopDistance = oCounterBoreClevisPlatesDataRow("CounterboredClevisPlateRodStopDistance")
                dblStandardClevisPlateRodStopDistance = oCounterBoreClevisPlatesDataRow("StandardClevisPlateRodStopDistance")
                _strCounterboredClevisPlateCode = oCounterBoreClevisPlatesDataRow("CounterboredClevisPlateCode")

                ' MANJULA 09-02-2012
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode = oCounterBoreClevisPlatesDataRow("StandardClevisPlateCode")
                '*************
                '28_12_2011   RAGAVA
                'TODO: ANUP 06-04-2010 04.45
                _dblCounterBoreClevisPlateThickness = oCounterBoreClevisPlatesDataRow("CounterboredClevisPlateThickness")
                '************

                txtCounterBoreClevisPlate.Text = _dblCounterboredClevisPlateRodStopDistance - dblStandardClevisPlateRodStopDistance

            Else
                'TODO:Sunny 13-04-10 12:10pm
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = 0
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = 0
            End If
        Catch ex As Exception
        End Try

    End Sub
    '****************

    Public Sub ManualLoad()
        DefaultSettings()
        CounterBoreValidationVariables()
        CalculatedVariablesDefault()
        CalculateStickOutLength(True)
        ReplaceFULugWithFDLug()

        'TODO: ANUP 06-04-2010 11.34
        SwingClearanceLabelDisplay()
        '********

    End Sub

    Public Sub CalculateStickOutLength(ByVal blnIsCalledFromLoad As Boolean)      '05_01_2012  RAGAVA
        Me.Enabled = True
        Dim dblRetractedLength As Double = _dblRetractedLength
        Dim dblRodPinHoletoRodStop As Double = _dblRodPinHoletoRodStop
        Dim dblUGroove As Double = _dblUGroove
        Dim dblSkimWidth As Double = _dblSkimWidth
        Dim dblBaseEndDistanceFromPinHoletoRodStop As Double = _dblBaseEndDistanceFromPinHoletoRodStop
        Dim dblDim8FromPistonEndofRod As Double = _dblDim8FromPistonEndofRod
        Dim dblStrokeLength As Double = _dblStrokeLength
        Dim dblOverAllCylinderLength As Double = _dblOverAllCylinderLength
        Try
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            'TODO Anup 27-02-2010 11am

            'TODO: ANUP 12-04-2010 02.12
            '_dblStickOut = Math.Round(dblRetractedLength - dblRodPinHoletoRodStop - dblUGroove - dblSkimWidth - dblBaseEndDistanceFromPinHoletoRodStop - _
            '               dblDim8FromPistonEndofRod - dblStrokeLength - dblOverAllCylinderLength - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StopTubeLength - 0.08 - 0.03, 3)
            _dblStickOut = Math.Round(dblRetractedLength - dblRodPinHoletoRodStop - dblUGroove - dblSkimWidth - dblBaseEndDistanceFromPinHoletoRodStop - _
                          dblDim8FromPistonEndofRod - dblStrokeLength - dblOverAllCylinderLength - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StopTubeLength - 0.1, 3)

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StickOut = _dblStickOut
            '**************************
            If _dblStickOut < 0 Then
                txtRecommendedRetractedLength.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength - _dblStickOut
                'TODO: ANUP 23-03-2010 12.10
                'ObjClsWeldedCylinderFunctionalClass.SkipRetractedIfNegative = True
                '**************
            Else
                txtRecommendedRetractedLength.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength

                'TODO:  ANUP 22-04-2010 11.53am
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate = False
                If blnIsCalledFromLoad Then
                    Me.Enabled = False
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SkipRetractedIfPositiveFromGenerate = True
                    ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
                    ObjClsWeldedCylinderFunctionalClass.NextClick.PerformClick()
                    '***************
                End If

                'TODO: ANUP 23-03-2010 12.10
                'ObjClsWeldedCylinderFunctionalClass.SkipRetractedIfNegative = False
                '**************
            End If
            txtRecommendedRetractedLength.Text = Math.Round(Val(txtRecommendedRetractedLength.Text), 2) 'Aruna 19_3_2010
        Catch ex As Exception

        End Try

        txtStickOutDistance.Text = _dblStickOut

    End Sub

    Public Sub CalculatedVariablesDefault()         '05_01_2012   RAGAVA
        'Retracted Length
        _dblRetractedLength = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength

        'RodPinHoleToRodStop
        'TODO ANUP 02-04-2010 11.15
        Dim dblRodPinHoletoRodStopVariable As Double

        If ObjClsWeldedCylinderFunctionalClass.CmbRodEndConfiguration_RodEnd.Text = "Threaded Rod" Then
            dblRodPinHoletoRodStopVariable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength_RodEnd + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FlatLength_RodEnd
        ElseIf ObjClsWeldedCylinderFunctionalClass.CmbRodEndConfiguration_RodEnd.Text = "Flat With Chamfer" Then
            dblRodPinHoletoRodStopVariable = 0
        ElseIf ObjClsWeldedCylinderFunctionalClass.CmbRodEndConfiguration_RodEnd.Text = "Drilled Pin Hole" Then
            dblRodPinHoletoRodStopVariable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd / 2
        Else
            dblRodPinHoletoRodStopVariable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop
        End If


        'If chkReplaceFabricatedULugwithFabricatedDoubleLug.Checked AndAlso chkAdjustSwingClearance_RE.Checked Then
        '    _dblRodPinHoletoRodStop = dblRodPinHoletoRodStopVariable - Val(txtReplaceFabricatedULugwithFabricatedDoubleLug.Text) - _
        '                                                          (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd - Val(txtAdjustSwingClearance_RE.Text))
        'ElseIf chkReplaceFabricatedULugwithFabricatedDoubleLug.Checked Then
        '    _dblRodPinHoletoRodStop = dblRodPinHoletoRodStopVariable - Val(txtReplaceFabricatedULugwithFabricatedDoubleLug.Text)

        If chkAdjustSwingClearance_RE.Checked Then
            _dblRodPinHoletoRodStop = dblRodPinHoletoRodStopVariable - (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd - Val(txtAdjustSwingClearance_RE.Text))
        Else
            _dblRodPinHoletoRodStop = dblRodPinHoletoRodStopVariable
        End If
        '*********************

        'BaseEndDistanceFromPinHoletoRodStop
        Dim dblBaseEndDistanceFromPinHoletoRodStop As Double

        If chkReplaceFabricatedULugwithFabricatedDoubleLug.Checked AndAlso chkAdjustSwingClearance_BE.Checked Then
            dblBaseEndDistanceFromPinHoletoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop - Val(txtReplaceFabricatedULugwithFabricatedDoubleLug.Text) - _
                                                                  (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance - Val(txtAdjustSwingClearance_BE.Text))
        ElseIf chkReplaceFabricatedULugwithFabricatedDoubleLug.Checked Then
            dblBaseEndDistanceFromPinHoletoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop - Val(txtReplaceFabricatedULugwithFabricatedDoubleLug.Text)
        ElseIf chkAdjustSwingClearance_BE.Checked Then
            dblBaseEndDistanceFromPinHoletoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop - _
                                                    (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance - Val(txtAdjustSwingClearance_BE.Text))
        Else
            dblBaseEndDistanceFromPinHoletoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop
        End If

        If chkCounterBoreClevisPlate.Checked Then
            _dblBaseEndDistanceFromPinHoletoRodStop = dblBaseEndDistanceFromPinHoletoRodStop - Val(txtCounterBoreClevisPlate.Text)
        Else
            _dblBaseEndDistanceFromPinHoletoRodStop = dblBaseEndDistanceFromPinHoletoRodStop
        End If

        'UGroove

        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Flat With Chamfer" Then
            _dblUGroove = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ChamferSize_RodEnd / Math.Tan(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ChamferAngle_RodEnd * (Math.PI / 180))
        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Drilled Pin Hole" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Threaded Rod" Then
            _dblUGroove = 0
        Else
            _dblUGroove = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.JGrooveWidth_RodEnd
        End If

        'ONSITE:06-06-2010
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Fabricated" Then
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "Chamfer" Then
                _dblUGroove = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd
            End If
        End If

        'TODO: ANUP 27-02-2010 1pm

        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Fabricated" Then
        '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter >= 1 Then
        '        _dblUGroove = 0.25
        '    Else
        '        _dblUGroove = 0.125
        '    End If
        'Else
        '    _dblUGroove = 0.11
        'End If
        '_dblUGroove = 0.11

        'TODO: ANUP 05-07-2010 12.47pm
        'SkimWidth
        If chkReducingSkimLengthOfRod.Checked Then
            _dblSkimWidth = 0.25 - Val(txtReducingSkimLengthOfRod.Text) '0.25 - 0.125
        End If

        'TODO: ANUP 27-02-2010 12.54
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SkimWidth = _dblSkimWidth
        '###########################

        'TODO:Sunny 27-02-10 3pm
        'ANUP 12-08-2010
        Dim dblNutSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInDecimals
        Dim dbldefaultStickOut As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.StickOutAdderDefault_RetractedLengthCalculation(dblNutSize)
        'ANUP 10-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsCounterBoreOrNot Then
            _dblDim8FromPistonEndofRod = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutActualSize + _
                                                dbldefaultStickOut + _
                                               ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ExtraRodButtonLength + _
                                               ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreDepth
        Else
            _dblDim8FromPistonEndofRod = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutActualSize + _
                                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonWidth + dbldefaultStickOut + _
                                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ExtraRodButtonLength - _
                                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreDepth
        End If
        'ANUP 10-10-2010 TILL HERE

        'StrokeLength
        'StrokeLength
        _dblStrokeLength = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength

        'TODO: ANUP 04-03-2010 07.12
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.cmbHeadType.Text = "Threaded" Then
            If chkCompressCylinderHead.Checked Then
                _dblOverAllCylinderLength = 2
            Else
                _dblOverAllCylinderLength = 2.13
            End If
        Else
            _dblOverAllCylinderLength = 2
        End If

    End Sub

    'TODO ANUP  24-02-2010 START
    Private Sub CounterBoreValidationVariables()
        'TODO:Sandeep 26-02-10
        If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then

            Dim dblTan_30 As Double = 0.57735026918962573
            Dim dblCylinder_Chamfer_width As Double = dblTan_30 * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness - 0.04)

            Dim dblMinimumPortEndDistanceFromTubeEnd As Double = 0.2 + dblCylinder_Chamfer_width

            Dim dblPortOuterDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd

            ' ANUP 02-07-2010
            Dim dblPortEndDistanceFromTubeEnd1 As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutActualSize + 0.125 - _
              ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop - (dblPortOuterDiameter / 2) - (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreDepth - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonWidth)
            '**************************


            Dim dblPortEndDistanceFromTubeEnd As Double

            If dblPortEndDistanceFromTubeEnd1 < dblMinimumPortEndDistanceFromTubeEnd Then
                dblPortEndDistanceFromTubeEnd = dblMinimumPortEndDistanceFromTubeEnd
                _dblExtraRodButtonLength1 = dblMinimumPortEndDistanceFromTubeEnd - dblPortEndDistanceFromTubeEnd1
            Else
                dblPortEndDistanceFromTubeEnd = dblPortEndDistanceFromTubeEnd1
                _dblExtraRodButtonLength1 = 0
            End If

            dblPortEndDistanceFromTubeEnd = dblPortEndDistanceFromTubeEnd + (dblPortOuterDiameter / 2)
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortEndDistanceFromTubeEnd = dblPortEndDistanceFromTubeEnd
            ExtraRodButtonLength2Calculation()

            If _dblExtraRodButtonLength1 > 0 Then
                chkCounterBorePistonAndOffsetPortOrifice.Enabled = True
                GetOffsetPortOrifice()
            Else
                chkCounterBorePistonAndOffsetPortOrifice.Enabled = False
                txtOffsetPortOrifice.Text = 0
                _dblOrificeOffset = 0
                _dblReductionInRodButtonLength = 0
            End If
            ExtraRodButtonLengthCalculation()
        Else
            Dim dblNominalBoreDia As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
            Dim dblTubeWallThickeness As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness
            Dim dblPortDiameter As Double
            'TODO Anup 27-02-2010 11am
            Dim dblOrificeDia As Double
            If ObjClsWeldedCylinderFunctionalClass.CmbPortSizeBaseEnd.Text = "3/4" Then
                dblPortDiameter = 1.1
                dblOrificeDia = 0.39
            Else
                dblPortDiameter = 0.9
                dblOrificeDia = 0.3
            End If

            Dim oGetButtonToPartCenterDataTable As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonToPartCenter(dblNominalBoreDia, dblTubeWallThickeness, dblPortDiameter)
            Dim dblOrificeToRodStop As Double = oGetButtonToPartCenterDataTable + (dblOrificeDia / 2)
            '**************************
            If (0.125 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutActualSize + _
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreDepth + _dblPistonTosealDistance) - dblOrificeToRodStop < 0.0625 Then
                _dblExtraRodButtonLength3 = 0.0625 - ((0.125 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutActualSize + _
                                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreDepth + _dblPistonTosealDistance) - dblOrificeToRodStop)
            Else
                _dblExtraRodButtonLength3 = 0
            End If

            'TODO: ANUP 05-07-2010 11.02am
            If ObjClsWeldedCylinderFunctionalClass.CmbWeldType_BaseEnd.Text = "Groove" Then
                Dim dblVariable1 As Double = 0.125 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop

                Dim dblIfCounterBoreZero As Double
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreDepth = 0 Then
                    dblIfCounterBoreZero = 0
                Else
                    dblIfCounterBoreZero = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonWidth - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreDepth
                End If

                'Dim dblVariable2 As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutThickness + 0.125 - dblIfCounterBoreZero

                'ANUP 14-10-2010 START
                Dim dblNutSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInDecimals
                Dim dblStickOutAdder As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.StickOutAdderDefault_RetractedLengthCalculation(dblNutSize)

                'Dim dblVariable2 As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutThickness + 0.125 - dblIfCounterBoreZero
                Dim dblVariable2 As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutThickness + dblStickOutAdder - dblIfCounterBoreZero
                'ANUP 14-10-2010 TILL HERE

                If dblVariable1 > dblVariable2 Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ExtraRodButtonLength = Math.Round(dblVariable1 - dblVariable2 + 0.02, 3) 'ANUP 01-11-2010
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ExtraRodButton = "Yes"
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ExtraRodButton = "No"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ExtraRodButtonLength = 0
                End If
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ExtraRodButton = "No"
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ExtraRodButtonLength = 0
            End If

        End If
        '***********************
    End Sub

    Private Sub ExtraRodButtonLength2Calculation()
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonWearRing = "None" Then
            Dim dblOrificeToSealDistance_cal As Double
            _dblPistonTosealDistance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonWidth - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PI_MaxDistance_from_RodSide_to_SealGrooveEnd
            dblOrificeToSealDistance_cal = _dblPistonTosealDistance - (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_BaseEnd / 2)
            If dblOrificeToSealDistance_cal < 0.065 Then
                _dblExtraRodButtonLength2 = 0.065 - dblOrificeToSealDistance_cal
            Else
                _dblExtraRodButtonLength2 = 0
            End If
        Else
            _dblExtraRodButtonLength2 = 0
        End If
    End Sub

    Private Sub ExtraRodButtonLengthCalculation()
        'TODO:Anup 26-02-10
        Dim dblRodButtonLengthCalculation As Double = _dblExtraRodButtonLength3 + _dblExtraRodButtonLength2 + _dblExtraRodButtonLength1 - _dblReductionInRodButtonLength
        '******************

        '01_07_2011   RAGAVA
        Dim dblPistonValueToMove As Double = ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.PistonPositionInRetraction()
        Dim Z As Double = (Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd) - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_BaseEnd) / 2
        If dblPistonValueToMove > Z Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ExtraRodButton = "Yes"
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ExtraRodButtonLength = Z - dblPistonValueToMove
            Exit Sub
        End If
        'Till  Here

        If dblRodButtonLengthCalculation > 0 Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ExtraRodButton = "Yes"
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ExtraRodButtonLength = dblRodButtonLengthCalculation
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ExtraRodButton = "No"
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ExtraRodButtonLength = 0
        End If
    End Sub

    Private Sub GetOffsetPortOrifice()
        Dim strPortSize As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd
        Dim strPortType As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd
        Dim strOrificeSize As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_BaseEnd

        Dim oGetOffsetPortOrifice As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortLocatorCode(strOrificeSize, strPortSize, strPortType)

        If Not IsNothing(oGetOffsetPortOrifice) AndAlso oGetOffsetPortOrifice.Rows.Count > 0 Then
            Dim oOffsetPortOrificeRow As DataRow = oGetOffsetPortOrifice.Rows(0)
            txtOffsetPortOrifice.Text = oOffsetPortOrificeRow("OrificeOffSet")
            'TODO: ANUP 27-02-2010 11am
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OffsetPortOrifice = txtOffsetPortOrifice.Text
            txtOffsetPortOrifice.Text = Math.Round(Val(txtOffsetPortOrifice.Text), 2) 'Aruna 19_3_2010
        Else
            txtOffsetPortOrifice.Text = ""
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OffsetPortOrifice = 0
        End If
    End Sub

    Private Sub ReplaceFULugWithFDLug()

        If ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbBaseEndConfiguration.Text = "Double Lug" Then
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.rdbFabrication.Checked AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated" Then
                chkReplaceFabricatedULugwithFabricatedDoubleLug.Enabled = True

                Dim dblLuggap As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap
                Dim dblLugThickness As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                Dim strPartCode As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PartCodeFromUlugCode
                Dim strGetSingle_DoubleRadii As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetSingle_DoubleRadii(strPartCode)
                _strSingle_DoubleRadii = strGetSingle_DoubleRadii

                If Not IsNothing(_strSingle_DoubleRadii) Then
                    If _strSingle_DoubleRadii = "S" Then
                        txtReplaceFabricatedULugwithFabricatedDoubleLug.Text = dblLuggap / 2
                    Else
                        If dblLugThickness < "0.63" Then
                            txtReplaceFabricatedULugwithFabricatedDoubleLug.Text = "0.25"
                        ElseIf dblLugThickness = "0.63" Then
                            txtReplaceFabricatedULugwithFabricatedDoubleLug.Text = "0.5"
                        Else
                            txtReplaceFabricatedULugwithFabricatedDoubleLug.Text = "0.625"
                        End If
                    End If
                Else
                    txtReplaceFabricatedULugwithFabricatedDoubleLug.Text = ""
                End If

            End If
        Else
            chkReplaceFabricatedULugwithFabricatedDoubleLug.Enabled = False
        End If
    End Sub

    Private Sub SwingClearance_BE()
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbBaseEndConfiguration.Text = "Single Lug" Then
            ' Dim strLugWidth As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
            'txtAdjustSwingClearance_BE.Text = Val(strLugWidth / 2)
            txtAdjustSwingClearance_BE.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize / 2)
        Else
            txtAdjustSwingClearance_BE.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
        End If
        ' ANUP 06-04-2010 01.37
        txtAdjustSwingClearance_BE.Text = Math.Round(Val(txtAdjustSwingClearance_BE.Text), 2)
        '**************
    End Sub

    Private Sub SwingClearance_RE()
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbRodEndConfiguration_RodEnd.Text = "Single Lug" Then
            'Dim strLugWidth As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd
            'txtAdjustSwingClearance_RE.Text = Val(strLugWidth / 2)
            txtAdjustSwingClearance_RE.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired_RodEnd + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd / 2)
        Else
            txtAdjustSwingClearance_RE.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
        End If
        txtAdjustSwingClearance_RE.Text = Math.Round(Val(txtAdjustSwingClearance_RE.Text), 2) 'Aruna 19_3_2010
    End Sub

    'TODO: ANUP 06-04-2010 11.34
    Private Sub SwingClearanceLabelDisplay()
        _dblAdjustSwingClearance_BE = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize / 2)
        _dblAdjustSwingClearance_RE = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired_RodEnd + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd / 2)
        _dblAdjustSwingClearance_BE = Math.Round(_dblAdjustSwingClearance_BE, 2)
        lblBaseEndSwingClearanceMinMax.Text = "Minimum Swing clearance : " + _dblAdjustSwingClearance_BE.ToString + "   Maximum SwingClearance : " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance.ToString

        'TODO: ANUP 12-.4-2010 10.35
        If _dblAdjustSwingClearance_BE >= ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance Then
            chkAdjustSwingClearance_BE.Enabled = False
            txtAdjustSwingClearance_BE.Enabled = False
        Else
            chkAdjustSwingClearance_BE.Enabled = True
            txtAdjustSwingClearance_BE.Enabled = True
        End If
        '***********************

        _dblAdjustSwingClearance_RE = Math.Round(_dblAdjustSwingClearance_RE, 2)
        lblRodeEndSwingClearanceMinMax.Text = "Minimum Swing clearance : " + _dblAdjustSwingClearance_RE.ToString + "   Maximum SwingClearance : " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd.ToString

        'TODO: ANUP 12-.4-2010 10.35
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbRodEndConfiguration_RodEnd.Text = "Single Lug" OrElse _
                ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbRodEndConfiguration_RodEnd.Text = "Double Lug" Then
            If _dblAdjustSwingClearance_RE < ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd Then
                chkAdjustSwingClearance_RE.Enabled = True
                txtAdjustSwingClearance_RE.Enabled = True
            Else
                chkAdjustSwingClearance_RE.Enabled = False
                txtAdjustSwingClearance_RE.Enabled = False
            End If
        Else
            chkAdjustSwingClearance_RE.Enabled = False
            txtAdjustSwingClearance_RE.Enabled = False
        End If


    End Sub

#End Region

#Region "Events"

    Private Sub frmRetractedLengthValidation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        DefaultSettings()
        CounterBoreValidationVariables()
        CalculatedVariablesDefault()
        CalculateStickOutLength(True)
        ReplaceFULugWithFDLug()

        'TODO: ANUP 06-04-2010 11.34
        SwingClearanceLabelDisplay()
        '_dblAdjustSwingClearance_BE = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize / 2)
        '_dblAdjustSwingClearance_RE = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired_RodEnd + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd / 2)
        '_dblAdjustSwingClearance_BE = Math.Round(_dblAdjustSwingClearance_BE, 2)
        'lblBaseEndSwingClearanceMinMax.Text = "Minimum Swing clearance : " + _dblAdjustSwingClearance_BE.ToString + "   Maximum SwingClearance : " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance.ToString
        '_dblAdjustSwingClearance_RE = Math.Round(_dblAdjustSwingClearance_RE, 2)
        'lblRodeEndSwingClearanceMinMax.Text = "Minimum Swing clearance : " + _dblAdjustSwingClearance_RE.ToString + "   Maximum SwingClearance : " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd.ToString
        '********
    End Sub



    'Private Sub txtAdjustSwingClearance_BE_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAdjustSwingClearance_BE.Leave
    '    If txtAdjustSwingClearance_BE.Text > ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance.ToString _
    '                OrElse txtAdjustSwingClearance_BE.Text < "0" Then
    '        MessageBox.Show("Swing Clearance value must be between 0 and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance.ToString + " (the entered value in Tube Details Form)", _
    '        "RE-ENTER SWING CLEARANCE", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
    '        txtAdjustSwingClearance_BE.Focus()
    '    Else

    '        CalculatedVariablesDefault()
    '        CalculateStickOutLength()
    '    End If


    'End Sub

    'Private Sub txtAdjustSwingClearance_RE_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAdjustSwingClearance_RE.Leave

    '    If txtAdjustSwingClearance_RE.Text > ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd.ToString _
    '                   OrElse txtAdjustSwingClearance_RE.Text < "0" Then
    '        MessageBox.Show("Swing Clearance value must be between 0 and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd.ToString + " (the entered value in RodEnd Details Form)", _
    '        "RE-ENTER SWING CLEARANCE", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
    '        txtAdjustSwingClearance_RE.Focus()
    '    Else

    '        CalculatedVariablesDefault()
    '        CalculateStickOutLength()
    '    End If


    'End Sub

    'Private Sub txtAdjustSwingClearance_BE_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAdjustSwingClearance_BE.Leave
    '    If txtAdjustSwingClearance_BE.Text > ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance.ToString _
    '                OrElse txtAdjustSwingClearance_BE.Text < _dblAdjustSwingClearance_BE.ToString Then
    '        MessageBox.Show("Swing Clearance value must be between " + _dblAdjustSwingClearance_BE.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance.ToString + " (the entered value in Tube Details Form)", _
    '        "RE-ENTER SWING CLEARANCE", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
    '        txtAdjustSwingClearance_BE.Focus()
    '        'Else
    '        'If chkAdjustSwingClearance_BE.Checked Then
    '        '    CalculatedVariablesDefault()
    '        '    CalculateStickOutLength()
    '        'End If
    '    Else
    '        If MessageBox.Show("Click OK to go to the Tube Details screen", "Go To Tube Details Screen", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) = Windows.Forms.DialogResult.OK Then
    '            Dim oForm As Form = ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails
    '            ObjClsWeldedCylinderFunctionalClass.ObjPnlChildFormArea.Controls.Clear()
    '            ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm = oForm
    '            oForm.TopLevel = False
    '            oForm.Dock = DockStyle.Fill
    '            If oForm.Created Then
    '                ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.ManualLoad()
    '            End If
    '            oForm.Show()
    '            ObjClsWeldedCylinderFunctionalClass.ObjPnlChildFormArea.Controls.Add(oForm)
    '        End If
    '    End If
    'End Sub

    ' ANUP 19-03-2010 11.00

    Private Sub txtAdjustSwingClearance_BE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAdjustSwingClearance_BE.Validating
        ' If txtAdjustSwingClearance_BE.Text <> txtAdjustSwingClearance_BE.IFLDataTag Then
        If chkAdjustSwingClearance_BE.Checked Then
            If Val(txtAdjustSwingClearance_BE.Text) > ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance _
                                    OrElse Val(txtAdjustSwingClearance_BE.Text) < _dblAdjustSwingClearance_BE Then
                MessageBox.Show("Swing Clearance value must be between " + _dblAdjustSwingClearance_BE.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance.ToString + " (the entered value in Tube Details Form)", _
                "RE-ENTER SWING CLEARANCE", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                txtAdjustSwingClearance_BE.Focus()
            Else
                If MessageBox.Show("Click OK to go to the Tube Details screen", "Go To Tube Details Screen", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) = Windows.Forms.DialogResult.OK Then
                    txtAdjustSwingClearance_BE.IFLDataTag = txtAdjustSwingClearance_BE.Text
                    'TODO:  ANUP 24-05-2010 10.36am
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GoToBaseEndScreenFromRetractedScreen = True
                    '**********************
                    ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" AndAlso (ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Cast") Then
                        ObjClsWeldedCylinderFunctionalClass.TxtCrossTubeOffset_BaseEnd.Text = Val(txtAdjustSwingClearance_BE.Text) - _dblAdjustSwingClearance_BE
                        ObjClsWeldedCylinderFunctionalClass.TxtCrossTubeOffset_BaseEnd.Text = Val(txtAdjustSwingClearance_BE.Text) - _dblAdjustSwingClearance_BE
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OffSet = Val(txtAdjustSwingClearance_BE.Text) - _dblAdjustSwingClearance_BE
                    End If
                    ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text = txtAdjustSwingClearance_BE.Text
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance = Val(txtAdjustSwingClearance_BE.Text)

                    Dim oForm As Form = ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails
                    ObjClsWeldedCylinderFunctionalClass.ObjPnlChildFormArea.Controls.Clear()
                    ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm = oForm
                    oForm.TopLevel = False
                    oForm.Dock = DockStyle.Fill
                    If oForm.Created Then
                        ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.ManualLoad()
                    End If
                    oForm.Show()
                    ObjClsWeldedCylinderFunctionalClass.ObjPnlChildFormArea.Controls.Add(oForm)
                    ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Focus()

                Else
                    txtAdjustSwingClearance_BE.Text = _dblAdjustSwingClearance_BE
                End If
            End If
        End If
        'End If
    End Sub

    '***********
    '
    'Private Sub txtAdjustSwingClearance_RE_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAdjustSwingClearance_RE.Leave
    '    If txtAdjustSwingClearance_RE.Text > ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd.ToString _
    '                   OrElse txtAdjustSwingClearance_RE.Text < _dblAdjustSwingClearance_RE.ToString Then
    '        MessageBox.Show("Swing Clearance value must be between " + _dblAdjustSwingClearance_RE.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd.ToString + " (the entered value in RodEnd Details Form)", _
    '        "RE-ENTER SWING CLEARANCE", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
    '        txtAdjustSwingClearance_RE.Focus()
    '        'Else
    '        'If chkAdjustSwingClearance_RE.Checked Then
    '        '    CalculatedVariablesDefault()
    '        '    CalculateStickOutLength()
    '        'End If
    '    End If
    '    CalculatedVariablesDefault()
    '    CalculateStickOutLength()
    'End Sub
    '***************************

    Private Sub txtAdjustSwingClearance_RE_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAdjustSwingClearance_RE.Validating
        If chkAdjustSwingClearance_RE.Checked Then

            If txtAdjustSwingClearance_RE.Text > ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd.ToString _
                                       OrElse txtAdjustSwingClearance_RE.Text < _dblAdjustSwingClearance_RE.ToString Then
                MessageBox.Show("Swing Clearance value must be between " + _dblAdjustSwingClearance_RE.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd.ToString + " (the entered value in RodEnd Details Form)", _
                "RE-ENTER SWING CLEARANCE", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                txtAdjustSwingClearance_RE.Focus()
            Else
                If MessageBox.Show("Click OK to go to the RodEnd Details screen", "Go To RodEnd Details Screen", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) = Windows.Forms.DialogResult.OK Then

                    'TODO:  ANUP 24-05-2010 10.36am
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GoToRodEndScreenFromRetractedScreen = True
                    '**********************

                    ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
                    ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Text = txtAdjustSwingClearance_RE.Text
                    Dim oForm As Form = ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration
                    ObjClsWeldedCylinderFunctionalClass.ObjPnlChildFormArea.Controls.Clear()
                    ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm = oForm
                    oForm.TopLevel = False
                    oForm.Dock = DockStyle.Fill
                    If oForm.Created Then
                        ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.ManualLoad()
                    End If
                    oForm.Show()
                    ObjClsWeldedCylinderFunctionalClass.ObjPnlChildFormArea.Controls.Add(oForm)
                    ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Focus()
                Else
                    txtAdjustSwingClearance_RE.Text = _dblAdjustSwingClearance_RE
                End If
            End If
        End If
    End Sub
    '****************************

    Private Sub chkCounterBorePistonAndOffsetPortOrifice_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCounterBorePistonAndOffsetPortOrifice.CheckedChanged
        If chkCounterBorePistonAndOffsetPortOrifice.Checked Then
            _dblOrificeOffset = Val(txtOffsetPortOrifice.Text)
            If _dblOrificeOffset <= _dblExtraRodButtonLength1 Then
                _dblReductionInRodButtonLength = _dblOrificeOffset
            Else
                _dblReductionInRodButtonLength = _dblExtraRodButtonLength1
            End If
            'TODO: ANUP 04-03-2010 05.22
        Else
            _dblOrificeOffset = 0
            _dblReductionInRodButtonLength = 0
        End If
        CounterBoreValidationVariables()
        CalculatedVariablesDefault()
        CalculateStickOutLength(False)
        '*************
    End Sub

    Private Sub chkCompressCylinderHead_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCompressCylinderHead.CheckedChanged
        If chkCompressCylinderHead.Checked Then
            'TODO:Sandeep 01-03-10 3pm
            ObjClsWeldedCylinderFunctionalClass.CompressCylinderChecked = True
            ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.GetCylinderHeadCode()
        Else
            'TODO:Sandeep 01-03-10 3pm
            ObjClsWeldedCylinderFunctionalClass.CompressCylinderChecked = False
        End If
        CalculatedVariablesDefault()
        CalculateStickOutLength(False)
    End Sub

    Private Sub chkReducingSkimLengthOfRod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReducingSkimLengthOfRod.CheckedChanged
        If chkReducingSkimLengthOfRod.Checked = True Then
            txtReducingSkimLengthOfRod.Enabled = True
        Else
            txtReducingSkimLengthOfRod.Enabled = False
        End If
        CalculatedVariablesDefault()
        CalculateStickOutLength(False)
        'End If
    End Sub

    Private Sub chkReplaceFabricatedULugwithFabricatedDoubleLug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReplaceFabricatedULugwithFabricatedDoubleLug.CheckedChanged
        'If chkReplaceFabricatedULugwithFabricatedDoubleLug.Checked Then
        CalculatedVariablesDefault()
        CalculateStickOutLength(False)
        If chkReplaceFabricatedULugwithFabricatedDoubleLug.Checked = True Then
            If MessageBox.Show("SingleLug Fabricated design is going to be generated, do you want to continue", "Fabricated SingleLug", _
                                               MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
                Dim oFrmFabricatedSingleLug_RetractedLength As New frmFabricatedSingleLug_RetractedLength
                ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "SINGLE LUG"
                oFrmFabricatedSingleLug_RetractedLength.ShowDialog()
            End If
        End If
        'End If
    End Sub

    ' ANUP SWINGCLEARANCE 05-03-2010 04.46
    Private Sub chkAdjustSwingClearance_BE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAdjustSwingClearance_BE.CheckedChanged
        CalculatedVariablesDefault()
        CalculateStickOutLength(False)
        'If chkAdjustSwingClearance_BE.Checked Then
        '    txtAdjustSwingClearance_BE.Focus()
        'End If
    End Sub

    Private Sub chkAdjustSwingClearance_RE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAdjustSwingClearance_RE.CheckedChanged
        CalculatedVariablesDefault()
        CalculateStickOutLength(False)
        'If chkAdjustSwingClearance_RE.Checked Then
        '    txtAdjustSwingClearance_RE.Focus()
        'End If
    End Sub
    '****************************

    'Private Sub chkAdjustSwingClearance_BE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAdjustSwingClearance_BE.CheckedChanged
    '    If chkAdjustSwingClearance_BE.Checked Then
    '        txtAdjustSwingClearance_BE.Enabled = True
    '        CalculatedVariablesDefault()
    '        CalculateStickOutLength()
    '    Else
    '        txtAdjustSwingClearance_BE.Enabled = False
    '    End If
    'End Sub

    'Private Sub chkAdjustSwingClearance_RE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAdjustSwingClearance_RE.CheckedChanged
    '    If chkAdjustSwingClearance_RE.Checked Then
    '        txtAdjustSwingClearance_RE.Enabled = True
    '        CalculatedVariablesDefault()
    '        CalculateStickOutLength()
    '    Else
    '        txtAdjustSwingClearance_RE.Enabled = False
    '    End If
    'End Sub

    'Private Sub btnAcceptRetractedLength_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcceptRetractedLength.Click
    '    If _dblStickOut < 0 Then
    '        If MessageBox.Show("Do you want to continue with the RetractedLength :" + txtRecommendedRetractedLength.Text, "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
    '            ObjClsWeldedCylinderFunctionalClass.TxtRetractedLength.Text = txtRecommendedRetractedLength.Text
    '            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
    '            ObjClsWeldedCylinderFunctionalClass.RetractedLengthChangedFromRetractedValidationScreen = True
    '        Else
    '            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
    '        End If
    '    End If
    'End Sub
    Private Sub btnAcceptRetractedLength_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcceptRetractedLength.Click
        'Aruna:12-3-2010
        If chkAdjustSwingClearance_BE.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance = Val(txtAdjustSwingClearance_BE.Text)
            'ObjClsWeldedCylinderFunctionalClass.ShowCastingNo_Thru_CastingYes = True
            'ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm = ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails
            'Else
            'ObjClsWeldedCylinderFunctionalClass.ShowCastingNo_Thru_CastingYes = False
        End If
        If _dblStickOut < 0 Then
            If MessageBox.Show("Do you want to continue with the RetractedLength :" + txtRecommendedRetractedLength.Text, "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                'TODO:Sunny 27-02-10 3pm
                ObjClsWeldedCylinderFunctionalClass.RetractedLengthChangedFromRetractedValidationScreen = True
                ObjClsWeldedCylinderFunctionalClass.TxtRetractedLength.Text = txtRecommendedRetractedLength.Text
                ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
                btnAcceptRetractedLength.Enabled = True

                'anup 23-12-2010 start
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength = Val(txtRecommendedRetractedLength.Text)
                'anup 23-12-2010 start

                'TODO: ANUP 02-04-2010 01.13
                If ObjClsWeldedCylinderFunctionalClass.CmbRodEndConfiguration_RodEnd.Text = "Flat With Chamfer" OrElse ObjClsWeldedCylinderFunctionalClass.CmbRodEndConfiguration_RodEnd.Text = "Threaded Rod" Then
                    _dblRodLength = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength - _
                                          ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop
                ElseIf ObjClsWeldedCylinderFunctionalClass.CmbRodEndConfiguration_RodEnd.Text = "Drilled Pin Hole" Then
                    _dblRodLength = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength + _
                                          ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd / 2 + 0.5 - _
                                           ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop
                Else
                    _dblRodLength = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength - _
                                           ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop - _
                                           ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop
                End If

                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodLength = _dblRodLength
                '**************
            Else
                ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
                'btnAcceptRetractedLength.Enabled = False
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        End If
    End Sub

    'TODO:Sunny 13-04-10 12:10pm
    'TODO: ANUP 06-04-2010 04.45

    Private Sub chkCounterBoreClevisPlate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCounterBoreClevisPlate.CheckedChanged

        If chkCounterBoreClevisPlate.Checked Then

            'TODO: ANUP 22-04-2010 11.23am
            If _strCounterboredClevisPlateCode = "N/A" OrElse _strCounterboredClevisPlateCode = "TBA" Then
                MessageBox.Show("There is no Counter Bore Clevis Plate for the selected details", "Choose different Bore Diameter or TubeOD", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign)
                chkCounterBoreClevisPlate.Checked = False
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreClevisPlateCode = _strCounterboredClevisPlateCode
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ClevisPlate Code", _strCounterboredClevisPlateCode)
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreClevisPlateThickness = _dblCounterBoreClevisPlateThickness
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterboredClevisPlateRodStopDistance = _dblCounterboredClevisPlateRodStopDistance
                '' txtStickOutDistance.Text = _dblStickOut + Val(txtCounterBoreClevisPlate.Text)  'anup 09-04-2010
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.IsCounterBoreChecked = True

                'TODO:Sunny 13-04-10 12:10pm
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = _dblCounterboredClevisPlateRodStopDistance
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = _dblCounterBoreClevisPlateThickness - _dblCounterboredClevisPlateRodStopDistance
                '*****************************

            End If

        Else
            'TODO:Sunny 13-04-10 12:10pm
            Dim oClevisPlateDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPlateClevisDetails(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, _
                                                          ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD)
            If Not IsNothing(oClevisPlateDataTable) Then
                Dim oPlateClevisDatarow As DataRow = oClevisPlateDataTable.Rows(0)
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = oPlateClevisDatarow("ClevisPlateThickness") - oPlateClevisDatarow("ClevisPlateRodStopDistance")
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = oPlateClevisDatarow("ClevisPlateRodStopDistance")
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness
            End If
            '*****************************
            txtStickOutDistance.Text = _dblStickOut
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.IsCounterBoreChecked = False
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ClevisPlate Code", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode)
        End If
    End Sub
    '*******************

#End Region

    'ONSITE:31-05-2010
    Private Sub txtReducingSkimLengthOfRod_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtReducingSkimLengthOfRod.Validating
        If txtReducingSkimLengthOfRod.Text <> "" Then
            If Val(txtReducingSkimLengthOfRod.Text) < 0 OrElse Val(txtReducingSkimLengthOfRod.Text) > 0.125 Then
                Dim strMessage As String = " Pleasse enter value between 0 and 0.125."
                MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            Else
                CalculatedVariablesDefault()
                CalculateStickOutLength(False)
            End If
        End If
    End Sub

    Private Sub txtReducingSkimLengthOfRod_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReducingSkimLengthOfRod.TextChanged
        If txtReducingSkimLengthOfRod.Text <> "" Then
            If Val(txtReducingSkimLengthOfRod.Text) < 0 OrElse Val(txtReducingSkimLengthOfRod.Text) > 0.125 Then
            Else
                CalculatedVariablesDefault()
                CalculateStickOutLength(False)
            End If
        End If
    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, LabelGradient5, LabelGradient4, LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblHeadDesign)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(LabelGradient6)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblBaseEndSelection)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient1)
        
    End Sub

End Class