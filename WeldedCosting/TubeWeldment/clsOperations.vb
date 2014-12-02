Public Class clsOperations

#Region "Private Variables "

    Private _dblSetupStandardCost As Double

    Private _dblSetupLabourRate As Double

    Private _dblSetupFixedBurdenRate As Double

    Private _dblSetupVariableBurdenRate As Double

    Private _dblRunStandardCost As Double

    Private _oOperationsDMC As clsOperationDMC

    Private _dblStrokeLength As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength

    Private _dblTubeThickness As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness

    Private _dblBoreDia As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter

    Private _dblWeldSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd

    Private _dblNoofPorts As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd           '19_10_2010    RAGAVA

    Private _dblPartWeight As Double = 10

    Private _dblPinHoleSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd

    Private _oWCDetailsHashTable As Hashtable

    
    Private _strWorkCenter As String

#End Region

#Region "Properties"

    Private ReadOnly Property ColumnByBoreDia() As Hashtable
        Get
            ColumnByBoreDia = New Hashtable

            ColumnByBoreDia.Add(1.5, "[BoreDia_1.50]")
            ColumnByBoreDia.Add(1.75, "[BoreDia_1.75]")
            ColumnByBoreDia.Add(2.0, "[BoreDia_2.00]")
            ColumnByBoreDia.Add(2.25, "[BoreDia_2.50]") 'vamsi 19-11-2014 changed 2.25 to 2.50
            ColumnByBoreDia.Add(2.5, "[BoreDia_2.50]")
            ColumnByBoreDia.Add(2.75, "[BoreDia_2.75]")
            If _dblTubeThickness.Equals(0.188) Then
                ColumnByBoreDia.Add(3.0, "[BoreDia_3.00_0.188]")
            Else
                ColumnByBoreDia.Add(3.0, "[BoreDia_3.00_0.250]")
            End If
            ColumnByBoreDia.Add(3.25, "[BoreDia_3.50]")
            ColumnByBoreDia.Add(3.5, "[BoreDia_3.50]")  'vamsi 19-11-2014
            ColumnByBoreDia.Add(3.75, "[BoreDia_4.00]") 'vamsi 19-11-2014
            ColumnByBoreDia.Add(4.0, "[BoreDia_4.00]")
            ColumnByBoreDia.Add(4.5, "[BoreDia_4.50]")
            ColumnByBoreDia.Add(4.75, "[BoreDia_5.00]") 'vamsi 19-11-2014
            ColumnByBoreDia.Add(5.0, "[BoreDia_5.00]")
            Return ColumnByBoreDia
        End Get
    End Property

    Private ReadOnly Property WorkCenters() As Hashtable
        Get
            WorkCenters = New Hashtable
            WorkCenters.Add("CUTTING", "WC099")
            WorkCenters.Add("DRILLING", "WC140")
            WorkCenters.Add("THREADING", "WC086")
            WorkCenters.Add("GROOVING", "WC086")        '03_11_2010  RAGAVA
            '01_10_2010   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeRuleId > 1008 Then
                'WorkCenters.Add("SKIVING", "WC087")
                WorkCenters.Add("SKIVING", "WC088")            '01_11_2010   RAGAVA
            Else
                WorkCenters.Add("SKIVING", "WC088")
            End If
            'WorkCenters.Add("SKIVING", "WC088")
            WorkCenters.Add("WELDING", "WC556")
            'Till   Here
            WorkCenters.Add("LATHEWELDING", "WC554")
            WorkCenters.Add("ROBOTWELDING", "WC555")
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected AndAlso (ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "SINGLE LUG" OrElse ObjClsWeldedCylinderFunctionalClass.FacricatedPart2 = "SINGLE LUG") Then  '15_05_2012   RAGAVA Then           '19_01_2012    RAGAVA          Commented
                WorkCenters.Add("MANUALWELDING", "WC550")
            End If
            WorkCenters.Add("PORTWELDING", "WC551")
            WorkCenters.Add("PINHOLE", "WC199")
            WorkCenters.Add("PORTPLUGGING", "WC085")
            Return WorkCenters
        End Get
    End Property

    Public Property WCDetailsHashTable() As Hashtable
        Get
            Return _oWCDetailsHashTable
        End Get
        Set(ByVal value As Hashtable)
            _oWCDetailsHashTable = value
        End Set
    End Property

#End Region

#Region "Enums"

#End Region

#Region "Procedures "

#Region "Common"

    Public Sub New()
        _oOperationsDMC = New clsOperationDMC
        _oWCDetailsHashTable = New Hashtable
    End Sub

    Private Sub getWorkCenterDetails(ByVal _strWorkCenter As String)
        Dim oCuttingSetupDetails As DataRow = _oOperationsDMC.getWorkCenterDetails(_strWorkCenter)
        If Not IsNothing(oCuttingSetupDetails) Then
            Try
                _dblSetupStandardCost = oCuttingSetupDetails("SetupCost")
            Catch ex As Exception
            End Try

            Try
                _dblSetupFixedBurdenRate = oCuttingSetupDetails("FixedBurdenCost")
            Catch ex As Exception
            End Try

            Try
                _dblSetupVariableBurdenRate = oCuttingSetupDetails("VariableBurdenRate")
            Catch ex As Exception
            End Try

            Try
                _dblSetupLabourRate = oCuttingSetupDetails("LabourRate")
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub addDataToStructure(ByVal strWorkCenter As String, ByVal dblRunStandardCost As Double)
        Try
            Dim oWCStructure As New WCStructure
            oWCStructure.WorkCenter = strWorkCenter
            oWCStructure.RunCost = dblRunStandardCost
            oWCStructure.FixedBurdenCost = _dblSetupFixedBurdenRate
            oWCStructure.LabourCost = _dblSetupLabourRate
            oWCStructure.SetupCost = _dblSetupStandardCost
            oWCStructure.VariableBurdenCost = _dblSetupVariableBurdenRate
            _oWCDetailsHashTable.Add(_strWorkCenter, oWCStructure)
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWorkCenterList.Add(_strWorkCenter)       '01_10_2010   RAGAVA

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Cutting "

    Public Sub CuttingFunctionality()
        Try
            _strWorkCenter = WorkCenters("CUTTING")
            getWorkCenterDetails(_strWorkCenter)
            '_dblRunStandardCost = _oOperationsDMC.getCuttingStandardCost(_dblStrokeLength, ColumnByBoreDia(_dblBoreDia))
            _dblRunStandardCost = _oOperationsDMC.getCuttingStandardCost((Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalTubeLength)).ToString, ColumnByBoreDia(_dblBoreDia))             '08_11_2010    RAGAVA
            addDataToStructure(_strWorkCenter, _dblRunStandardCost)
            '12_10_2010     RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.ContainsKey(_strWorkCenter) = False Then
                ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.Add(_strWorkCenter, 10)
            End If
            'Till   Here

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Drilling "

    Public Sub DrillingFunctionality()
        Try
            _strWorkCenter = WorkCenters("DRILLING")
            getWorkCenterDetails(_strWorkCenter)
            '  _dblRunStandardCost = _oOperationsDMC.getDrillingStandardCost(_dblStrokeLength, ColumnByBoreDia(_dblBoreDia))
            _dblRunStandardCost = _oOperationsDMC.getDrillingStandardCost((Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalTubeLength)).ToString, ColumnByBoreDia(_dblBoreDia))       '07_12_2010   RAGAVA
            addDataToStructure(_strWorkCenter, _dblRunStandardCost)
            '12_10_2010     RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.ContainsKey(_strWorkCenter) = False Then
                ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.Add(_strWorkCenter, 20)
            End If
            'Till   Here

        Catch ex As Exception

        End Try
    End Sub

#End Region

    '03_11_2010   RAGAVA
#Region "Grooving"
    Public Sub GroovingFunctionality()
        Try
            _strWorkCenter = WorkCenters("GROOVING")
            getWorkCenterDetails(_strWorkCenter)
            _dblRunStandardCost = _oOperationsDMC.getGrooveDetailsStandardCost((Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalTubeLength)).ToString, ColumnByBoreDia(_dblBoreDia))       '07_12_2010   RAGAVA
            'MsgBox("Grooving OP(55-1) sheet is not Available")
            '_dblRunStandardCost = 0
            addDataToStructure(_strWorkCenter, _dblRunStandardCost)
            '12_10_2010     RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.ContainsKey(_strWorkCenter) = False Then
                ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.Add(_strWorkCenter, 55)
            End If
            'Till   Here

        Catch ex As Exception

        End Try
    End Sub
#End Region


#Region "Threading "

    Public Sub ThreadingFunctionality()
        _strWorkCenter = WorkCenters("THREADING")
        getWorkCenterDetails(_strWorkCenter)
        '_dblRunStandardCost = _oOperationsDMC.getThreadedDetailsStandardCost(_dblStrokeLength, ColumnByBoreDia(_dblBoreDia))
        _dblRunStandardCost = _oOperationsDMC.getThreadedDetailsStandardCost((Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalTubeLength)).ToString, ColumnByBoreDia(_dblBoreDia))           '07_12_2010     RAGAVA
        addDataToStructure(_strWorkCenter, _dblRunStandardCost)
        '12_10_2010     RAGAVA
        If ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.ContainsKey(_strWorkCenter) = False Then
            ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.Add(_strWorkCenter, 40)
        End If
        'Till   Here
    End Sub

#End Region

#Region "Skiving "

    Public Sub SkivingFunctionality()
        try
            _strWorkCenter = WorkCenters("SKIVING")
            getWorkCenterDetails(_strWorkCenter)
            '_dblRunStandardCost = _oOperationsDMC.getSkivingDetailsStandardCost(_dblStrokeLength, ColumnByBoreDia(_dblBoreDia))
            _dblRunStandardCost = _oOperationsDMC.getSkivingDetailsStandardCost((Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalTubeLength)).ToString, "[BoreDia_" & Format(_dblBoreDia, "0.00").ToString & "]")     '07_12_2010  RAGAVA 
            addDataToStructure(_strWorkCenter, _dblRunStandardCost)
            '12_10_2010     RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.ContainsKey(_strWorkCenter) = False Then
                ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.Add(_strWorkCenter, 50)
            End If
            'Till   Here

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Welding "

    Public Sub LatheWeldingFunctionality()
        Try
            _strWorkCenter = WorkCenters("LATHEWELDING")
            getWorkCenterDetails(_strWorkCenter)
            '_dblRunStandardCost = _oOperationsDMC.getLatheWeldingDetailsStandardCost(_dblBoreDia, _dblStrokeLength)
            _dblRunStandardCost = _oOperationsDMC.getLatheWeldingDetailsStandardCost(_dblBoreDia, (Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalTubeLength)).ToString)        '07_12_2010    RAGAVA
            addDataToStructure(_strWorkCenter, _dblRunStandardCost)
            '12_10_2010     RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.ContainsKey(_strWorkCenter) = False Then
                ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.Add(_strWorkCenter, 60)
            End If
            'Till   Here

        Catch ex As Exception

        End Try
    End Sub

    Public Sub RobotWeldingFunctionality()
        Try

            _strWorkCenter = WorkCenters("ROBOTWELDING")
            getWorkCenterDetails(_strWorkCenter)
            '      _dblRunStandardCost = _oOperationsDMC.getRobotWeldingDetailsStandardCost(_dblBoreDia, _dblStrokeLength)
            _dblRunStandardCost = _oOperationsDMC.getRobotWeldingDetailsStandardCost(_dblBoreDia, (Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalTubeLength)).ToString)            '07_12_2010   RAGAVA
            addDataToStructure(_strWorkCenter, _dblRunStandardCost)
            '12_10_2010     RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.ContainsKey(_strWorkCenter) = False Then
                ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.Add(_strWorkCenter, 61)
            End If
            'Till   Here

        Catch ex As Exception

        End Try
    End Sub

    Public Sub ManualWeldingFunctionality()
        Try

            _strWorkCenter = WorkCenters("MANUALWELDING")
            getWorkCenterDetails(_strWorkCenter)
            '  _dblRunStandardCost = _oOperationsDMC.getManualWeldingDetailsStandardCost(_dblBoreDia, _dblStrokeLength, _dblWeldSize)
            _dblRunStandardCost = _oOperationsDMC.getManualWeldingDetailsStandardCost(_dblBoreDia, (Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalTubeLength)).ToString, _dblWeldSize)       '07_12_2010   RAGAVA
            addDataToStructure(_strWorkCenter, _dblRunStandardCost)
            '12_10_2010     RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.ContainsKey(_strWorkCenter) = False Then
                ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.Add(_strWorkCenter, 62)
            End If
            'Till   Here

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Port Welding "

    'Public Sub PortWeldingFunctionality()
    '    _strWorkCenter = WorkCenters("PORTWELDING")
    '    getWorkCenterDetails(_strWorkCenter)
    '    '_dblRunStandardCost = _oOperationsDMC.getPortWeldingDetailsStandardCost(_dblStrokeLength, _dblNoofPorts)
    '    _dblRunStandardCost = _oOperationsDMC.getPortWeldingDetailsStandardCost((Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalTubeLength)).ToString, _dblNoofPorts)         '07_12_2010   RAGAVA
    '    addDataToStructure(_strWorkCenter, _dblRunStandardCost)
    '    '12_10_2010     RAGAVA
    '    If ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.ContainsKey(_strWorkCenter) = False Then
    '        ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.Add(_strWorkCenter, 30)
    '    End If
    '    'Till   Here
    'End Sub


    '19_01_2012     RAGAVA
    Public Sub PortWeldingFunctionality()
        Try

            Dim strOP_Number As Integer = 30
            _strWorkCenter = WorkCenters("PORTWELDING")
            getWorkCenterDetails(_strWorkCenter)
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional" Then
                If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortLocatorCode_Tube = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortLocatorCode_Rod Then
                        _dblNoofPorts = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd
                        If _dblNoofPorts > 2 Then
                            _dblNoofPorts = 2
                        End If
                    Else
                        strOP_Number = 31
                    End If
                Else
                    _dblNoofPorts = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd
                End If
            End If
            _dblRunStandardCost = _oOperationsDMC.getPortWeldingDetailsStandardCost(((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalTubeLength).ToString * (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString)), _dblNoofPorts)         '07_12_2010   RAGAVA  '19-11-2014 vamsi added borediameter
            addDataToStructure(_strWorkCenter, _dblRunStandardCost)
            '12_10_2010     RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.ContainsKey(_strWorkCenter) = False Then
                ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.Add(_strWorkCenter, strOP_Number)
            End If
            'Till   Here

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Pin Hole "

    Public Sub PinHoleFunctionality()
        Try
            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize" OrElse ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug") AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType.ToUpper = "FABRICATED") Then   '11_10_2010   RAGAVA
                _strWorkCenter = WorkCenters("PINHOLE")
                getWorkCenterDetails(_strWorkCenter)
                _dblRunStandardCost = _oOperationsDMC.getPinHoleDetailsStandardCost(_dblPartWeight, _dblPinHoleSize)
                addDataToStructure(_strWorkCenter, _dblRunStandardCost)
                '12_10_2010     RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.ContainsKey(_strWorkCenter) = False Then
                    ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.Add(_strWorkCenter, 70)
                End If
                'Till   Here
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "PortPlugging"

    Public Sub PortPluggingFunctionality()
        Try
            'If (ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd.StartsWith("90") = True OrElse ObjClsWeldedCylinderFunctionalClass.strPortAngle_RodEnd.StartsWith("90") = True) OrElse Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleBaseEnd.Text) = "Straight" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text) = "Straight" AndAlso (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationBaseEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text) OrElse ((ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd.StartsWith("90") = True AndAlso ObjClsWeldedCylinderFunctionalClass.strPortAngle_RodEnd.StartsWith("90") = True)) Then         
            If (ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd.StartsWith("90") = True OrElse ObjClsWeldedCylinderFunctionalClass.strPortAngle_RodEnd.StartsWith("90") = True) OrElse Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleBaseEnd.Text) = "Straight" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text) = "Straight" AndAlso (ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationBaseEnd.Text <> ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text) OrElse ((ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd.StartsWith("90") = True AndAlso ObjClsWeldedCylinderFunctionalClass.strPortAngle_RodEnd.StartsWith("90") = True)) Then   '06_04_2011   RAGAVA
                _strWorkCenter = WorkCenters("PORTPLUGGING")
                getWorkCenterDetails(_strWorkCenter)
                '_dblRunStandardCost = _oOperationsDMC.getPortPluggingCost(_dblPartWeight, _dblPinHoleSize, True)
                _dblRunStandardCost = _oOperationsDMC.getPortPluggingCost(_dblPartWeight, ColumnByBoreDia(_dblBoreDia), True)            '19_10_2010   RAGAVA
                addDataToStructure(_strWorkCenter, _dblRunStandardCost)
                '12_10_2010     RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.ContainsKey(_strWorkCenter) = False Then
                    ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.Add(_strWorkCenter, 45)
                End If
                'Till   Here
            End If
        Catch ex As Exception
        End Try
    End Sub
    '01_10_2010   RAGAVA
    Public Sub WeldingFunctionality()
        Try
            _strWorkCenter = WorkCenters("WELDING")
            getWorkCenterDetails(_strWorkCenter)
            _dblRunStandardCost = 0
            'ANUP 04-10-2010 START
            _dblRunStandardCost = _oOperationsDMC.getHeadWeldingCost(_dblBoreDia, TubeLengthValidation_WeldingFunctionality)
            'ANUP 04-10-2010 TILL HERE
            addDataToStructure(_strWorkCenter, _dblRunStandardCost)
            '12_10_2010     RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.ContainsKey(_strWorkCenter) = False Then
                ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.Add(_strWorkCenter, 59)
            End If
            'Till   Here
        Catch ex As Exception

        End Try

    End Sub

    'ANUP 04-10-2010 START
    Private Function TubeLengthValidation_WeldingFunctionality() As String
        TubeLengthValidation_WeldingFunctionality = String.Empty
        Try
            Dim dblTubeLength As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalTubeLength
            If dblTubeLength <= 18 Then
                Return "[LessThan-18]"
            ElseIf dblTubeLength >= 19 AndAlso dblTubeLength < 24 Then
                Return "[19-24]"
            ElseIf dblTubeLength >= 24 AndAlso dblTubeLength < 36 Then
                Return "[24-36]"
            ElseIf dblTubeLength >= 36 AndAlso dblTubeLength < 48 Then
                Return "[36-48]"
            ElseIf dblTubeLength >= 48 AndAlso dblTubeLength < 60 Then
                Return "[48-60]"
            ElseIf dblTubeLength >= 60 Then
                Return "[60-Greater]"
            End If
        Catch ex As Exception

        End Try
    End Function
    'ANUP 04-10-2010 TILL HERE

#End Region

#End Region

End Class

Public Structure WCStructure
    Public WorkCenter As String
    Public SetupCost As Double
    Public RunCost As Double
    Public LabourCost As Double
    Public FixedBurdenCost As Double
    Public VariableBurdenCost As Double
End Structure




