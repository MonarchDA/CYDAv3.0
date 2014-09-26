Public Class frmTubeDetails

#Region "Private Variables"

    'TODO: ANUP 22-07-2010 12.14pm
    Private _blnIsPopulated As Boolean = False

    Private _dblTempBoreDiameter As Double = 0

    Private _dblTempWorkingPressure As Double = 0

    Private _strTempClass As String = ""

    Private _dblTubeOD As Double

    Private _dblWallThicknessofTube As Double

    Private _strTubeMaterial As String = String.Empty

    Private _strTubeMaterialCode As String = String.Empty

    Private _strBushingYes_No As String = String.Empty

    Private _dblRodDimension8 As Double

    Private _dblCh_ShankLength As Double

    Private _dblStrokeLength As Double

    'TODO: ANUP 20-04-2010 12.24pm
    Public _strBushingPartNumber_BaseEnd As String = String.Empty
    Private _dblBushingID_BaseEnd As Double
    Private _dblBushingOD_BaseEnd As Double
    '***********

    Private _strTempCylinderHeadDesign As String = ""

    'ANUP 06-10-2010 START
    Private _strTubeMaterialCode_Purchase As String = String.Empty
    Private _strClevisPlateCode_Purchase As String = String.Empty
    Private _strBaseEndConfigurationCode_Purchase As String = String.Empty
    Private _strBushingBaseEndCode_Purchase As String = String.Empty
    Private _strEndCollarCode_Purchase As String = String.Empty
    'ANUP 06-10-2010 TILL HERE


    Private pinHolesAndThicknessList As New Hashtable

#End Region

#Region "Properties"

    Public Property IsPopulated() As Boolean
        Get
            Return _blnIsPopulated
        End Get
        Set(ByVal value As Boolean)
            _blnIsPopulated = value
        End Set
    End Property

    '29_03_2010   RAGAVA
    Public Property TubeMaterialCode() As String
        Get
            Return _strTubeMaterialCode
        End Get
        Set(ByVal value As String)
            _strTubeMaterialCode = value
        End Set
    End Property

    Public ReadOnly Property ControlsData() As ArrayList
        Get
            ControlsData = Nothing
            Try

                Dim strPartCode As String = String.Empty

                ControlsData = New ArrayList
                'ControlsData.Add(New Object(3) {"GUI", "DesignType", "L3", cmbDesignType.Text})
                ControlsData.Add(New Object(3) {"GUI", "DesignType", "L3", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType})    '31_05_2010    RAGAVA
                ControlsData.Add(New Object(3) {"GUI", "BaseEndConfiguration", "L4", cmbBaseEndConfiguration.Text})
                ControlsData.Add(New Object(3) {"GUI", "BaseEndPort", "L5", cmbBaseEndPort.Text})
                ControlsData.Add(New Object(3) {"GUI", "Port Insertion", "L6", cmbPortInsertion.Text})
                If txtSwingClearance.Text <> "" Then
                    If ObjClsWeldedCylinderFunctionalClass.SwingClearanceValidation_PartCondition_BaseEnd() Then
                        ControlsData.Add(New Object(3) {"GUI", "Swing Clearance", "L7", Val(txtSwingClearance.Text) + 0.0625})
                    Else
                        ControlsData.Add(New Object(3) {"GUI", "Swing Clearance", "L7", Val(txtSwingClearance.Text)})
                    End If
                End If
                ControlsData.Add(New Object(3) {"GUI", "Cross Tube Width", "L8", Val(txtCrossTubeWidth.Text)})
                ControlsData.Add(New Object(3) {"GUI", "Lug Width", "L9", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth})
                ControlsData.Add(New Object(3) {"DB", "TubeOD", "L10", _dblTubeOD})
                ControlsData.Add(New Object(3) {"DB", "WallThicknessOfTube", "L11", _dblWallThicknessofTube})
                ControlsData.Add(New Object(3) {"DB", "TubeMaterial", "L12", _strTubeMaterial})
                ControlsData.Add(New Object(3) {"DB", "Tube Material Code", "L13", _strTubeMaterialCode})

                Dim strClevisPlateCode As String = Nothing

                '30_01_2012   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional" AndAlso UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType) = "CAST" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreClevisPlateCode = ""
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode = ""
                End If

                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.IsCounterBoreChecked Then
                    ControlsData.Add(New Object(3) {"DB", "ClevisPlateCode", "L14", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreClevisPlateCode})
                    strClevisPlateCode = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreClevisPlateCode
                    ControlsData.Add(New Object(3) {"GUI", "TUBE END TO ROD STOP DISTANCE", "L70", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterboredClevisPlateRodStopDistance})
                    ControlsData.Add(New Object(3) {"DB", "CLEVIS PLATE THICKNESS", "L39", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreClevisPlateThickness})
                    'ANUP 06-10-2010 START 
                    strPartCode = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreClevisPlateCode)
                    If Not String.IsNullOrEmpty(strPartCode) Then
                        _strClevisPlateCode_Purchase = strPartCode
                    Else
                        _strClevisPlateCode_Purchase = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreClevisPlateCode
                    End If
                    'ANUP 06-10-2010 TILL HERE
                Else
                    ControlsData.Add(New Object(3) {"DB", "CLEVIS PLATE THICKNESS", "L39", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness})
                    ControlsData.Add(New Object(3) {"GUI", "TUBE END TO ROD STOP DISTANCE", "L70", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop})
                    ControlsData.Add(New Object(3) {"DB", "ClevisPlateCode", "L14", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode})
                    strClevisPlateCode = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode
                    'ANUP 06-10-2010 START 
                    strPartCode = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode)             '03_11_2010   RAGAVA
                    If Not String.IsNullOrEmpty(strPartCode) Then
                        _strClevisPlateCode_Purchase = strPartCode
                    Else
                        _strClevisPlateCode_Purchase = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode       '03_11_2010   RAGAVA
                    End If
                End If
                '03_11_2010   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis" OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated" AndAlso ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube") Then
                    clsAddExistingCodes.AddClevisPlateCode(_strClevisPlateCode_Purchase, 1, "EA")
                End If
                'Till   Here
                '***************************
                'ANUP 06-10-2010 TILL HERE

                ControlsData.Add(New Object(3) {"GUI", "Bushing", "L15", _strBushingYes_No})

                'TODO: COMMENTED BY ANUP  19-04-2010 04.15
                ' ControlsData.Add(New Object(3) {"GUI", "Bushing Type", "L16", cmbBushingType.Text})
                ControlsData.Add(New Object(3) {"GUI", "Bushing Material", "L16", cmbMaterial.Text})
                '***********

                ControlsData.Add(New Object(3) {"GUI", "Bushing Quantity", "L17", cmbBushingQuantity.Text})

                ControlsData.Add(New Object(3) {"GUI", "BushingWidth", "L18", txtBushingWidth.Text})
                If cmbBaseEndConfiguration.Text = "Cross Tube" Then
                    If cmbBushingQuantity.Text = 1 Then
                        ControlsData.Add(New Object(3) {"GUI", "BUSHING WIDTH", "L18", Val(txtCrossTubeWidth.Text)})
                    End If
                End If



                ControlsData.Add(New Object(3) {"GUI", "PinHole", "L19", cmbPinHole.Text})
                ControlsData.Add(New Object(3) {"GUI", "PinHoleType", "L20", cmbPinHoleSizeType.Text})

                '04_03_2010   RAGAVA
                If Val(cmbBushingQuantity.Text) = 0 Then
                    If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize" Then
                        If cmbPinHoleSizeType.Text = "Standard" Then
                            ControlsData.Add(New Object(3) {"GUI", "BASE END PIN SIZE", "L79", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize})
                        Else
                            ControlsData.Add(New Object(3) {"GUI", "BASE END PIN SIZE", "L79", Val(txtPinHoleSize.Text)})
                        End If
                    Else
                        If cmbPinHoleSizeType.Text = "Standard" Then
                            ControlsData.Add(New Object(3) {"GUI", "PinHoleSize", "L21", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize})
                        Else
                            ControlsData.Add(New Object(3) {"GUI", "PinHoleSize", "L21", Val(txtPinHoleSize.Text)})
                        End If
                    End If
                Else
                    ControlsData.Add(New Object(3) {"GUI", "PinHoleSize", "L21", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingOD_BaseEnd}) 'TODO: ANUP 20-04-2010 11.24am
                End If

                ControlsData.Add(New Object(3) {"GUI", "Pin hole_UL", "L22", txtToleranceUpperLimit.Text})
                ControlsData.Add(New Object(3) {"GUI", "Pin hole_LL", "L23", txtToleranceLowerLimit.Text})

                ControlsData.Add(New Object(3) {"GUI", "Grease Zercs", "L24", cmbGreaseZercs.Text})
                ControlsData.Add(New Object(3) {"GUI", "Angle of Greasse Zerc 1", "L25", Val(txtAngleOfGreaseZercs1.Text)})
                'ControlsData.Add(New Object(3) {"GUI", "Angle of Greasse Zerc 2", "L26", Val(txtAngleOfGreaseZercs2.Text)})

                '06_09_2010  RAGAVA
                If cmbBaseEndConfiguration.Text = "Base Plug" AndAlso cmbGreaseZercs.Text = "1" Then
                    ControlsData.Add(New Object(3) {"GUI", "Angle of Greasse Zerc 2", "L26", Val(txtAngleOfGreaseZercs1.Text)})
                Else
                    ControlsData.Add(New Object(3) {"GUI", "Angle of Greasse Zerc 2", "L26", Val(txtAngleOfGreaseZercs2.Text)})
                End If
                'Till   Here

                'ToDO : 22-02-10 Sandeep *****************************************
                ControlsData.Add(New Object(3) {"CAL", "Y REQUIRED", "L40", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired})
                ControlsData.Add(New Object(3) {"CAL", "AREA REQUIRED", "L41", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired})
                ControlsData.Add(New Object(3) {"GUI", "LUG THICKNESS", "L42", Val(txtLugThickness.Text)})

                '06_09_2010   RAGAVA
                If cmbBaseEndConfiguration.Text = "Base Plug" Then
                    ControlsData.Add(New Object(3) {"CAL", "CROSS TUBE OD", "L43", Val(txtOutSidePlugDiameter.Text)})
                Else
                    ControlsData.Add(New Object(3) {"CAL", "CROSS TUBE OD", "L43", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD})
                End If
                'Till  Here
                'ControlsData.Add(New Object(3) {"CAL", "CROSS TUBE OD", "L43", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD})
                ControlsData.Add(New Object(3) {"GUI", "CROSS TUBE OFFSET", "L44", Val(txtOffSet.Text)})
                ControlsData.Add(New Object(3) {"GUI", "LUG GAP", "L45", Val(txtLugGap.Text)})
                ControlsData.Add(New Object(3) {"GUI", "BASE END CONFIGURATION SAFETY FACTOR", "L46", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd})
                ControlsData.Add(New Object(3) {"STA", "PILOT HOLE DIAMETER", "L47", 0.25})
                ControlsData.Add(New Object(3) {"GUI", "WELD TYPE", "L69", cmbWeldType.Text & " Weld"})

                ControlsData.Add(New Object(3) {"GUI", "BASE PLUG MILLED FLAT", "L80", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlat})
                '18_03_2010   RAGAVA
                'ControlsData.Add(New Object(3) {"GUI", "BASE PLUG ACROSS FLAT", "L81", Val(txtMilledFlatWidth.Text)})
                'ControlsData.Add(New Object(3) {"GUI", "BASE PLUG FLAT LENGTH", "L82", Val(txtMilledFlatLength.Text)})
                'ControlsData.Add(New Object(3) {"GUI", "BASE PLUG OD", "L83", Val(txtOutSidePlugDiameter.Text)})
                ControlsData.Add(New Object(3) {"GUI", "BASE PLUG ACROSS FLAT", "L81", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatWidth})
                ControlsData.Add(New Object(3) {"GUI", "BASE PLUG FLAT LENGTH", "L82", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatHeight})
                ControlsData.Add(New Object(3) {"GUI", "BASE PLUG OD", "L83", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter})
                '18_03_2010 RAGAVA  Till   Here

                ControlsData.Add(New Object(3) {"GUI", "PIN HOLE TO ROD STOP DISTANCE", "L71", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop})
                ControlsData.Add(New Object(3) {"GUI", "RESIZE, NEW DESIGN OR  EXACT MATCH", "L72", ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize})

                ControlsData.Add(New Object(3) {"GUI", "FABRICATED PART", "L76", ObjClsWeldedCylinderFunctionalClass.FacricatedPart})
                ControlsData.Add(New Object(3) {"GUI", "BASE END CONFIGURATION DESIGN", "L77", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign})
                ControlsData.Add(New Object(3) {"GUI", "BASE END CONFIGURATION DESIGNTYPE", "L78", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType})
                ControlsData.Add(New Object(3) {"GUI", "BASE END CONFIGURATION CODE", "L64", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd})
                'ANUP 06-10-2010 START 
                strPartCode = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd)
                If Not String.IsNullOrEmpty(strPartCode) Then
                    _strBaseEndConfigurationCode_Purchase = strPartCode
                Else
                    '15_10_2010   RAGAVA
                    Try
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName) = True Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                        End If
                    Catch ex As Exception
                    End Try
                    'Till   Here
                    _strBaseEndConfigurationCode_Purchase = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd
                End If


                'MANJULA 10-02-2012
                '10_12_2012   RAGAVA modified condition
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.chkDoubleLug.Checked = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral2.chkDoubleLug.Checked = True Then
                    clsAddExistingCodes.AddBaseEndConfigurationCode(_strBaseEndConfigurationCode_Purchase, 2, "EA")
                Else
                    clsAddExistingCodes.AddBaseEndConfigurationCode(_strBaseEndConfigurationCode_Purchase, 1, "EA")
                End If

                '*********

                '*****************************************************************
                'ANUP 06-10-2010 TILL HERE

                CommenCalculations()

                ControlsData.Add(New Object(3) {"CAL", "TUBE LENGTH", "L50", TubeLengthCalculation()})

                ControlsData.Add(New Object(3) {"CAL", "ORIGINAL TUBE LENGTH", "L95", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalTubeLength.ToString})         '25_05_2010   RAGAVA   CollarDetails

                ControlsData.Add(New Object(3) {"CAL", "TUBEEND TO BASEEND PORT", "L65", TubeEndToBaseEndPortCalculation()})

                ControlsData.Add(New Object(3) {"CAL", "TUBEEND TO RODEND PORT", "L66", TubeEndToRodEndPortCalculation()})

                'ControlsData.Add(New Object(3) {"CAL", "TUBEEND TO BASEEND PORT ORIFICE", "L67", TubeEndToBaseEndPortCalculation()})
                ControlsData.Add(New Object(3) {"CAL", "TUBEEND TO BASEEND PORT ORIFICE", "L67", TubeEndToBaseEndPortCalculation() - PistonPositionInRetraction()})         '01_07_2011    RAGAVA

                ControlsData.Add(New Object(3) {"CAL", "TUBEEND TO RODEND PORT ORIFICE", "L68", TubeEndToRodEndPortCalculation()})

                ControlsData.Add(New Object(3) {"CAL", "ROD DIA", "L88", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter})

                ' ControlsData.Add(New Object(3) {"GUI ", "WELD TYPE", "L69", "Groove Weld"})

                ControlsData.Add(New Object(3) {"CAL", "PISTON NUT ACTUAL SIZE", "C19", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutActualSize})

                ControlsData.Add(New Object(3) {"CAL", "PISTON THICKNESS", "C20", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonWidth})

                ControlsData.Add(New Object(3) {"GUI ", "COUNTER BORE DEPTH", "C21", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreDepth})
                '09_04_2010  Aruna
                ControlsData.Add(New Object(3) {"GUI", "Threaded Length", "L89", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength})
                ControlsData.Add(New Object(3) {"GUI", "Threaded Diameter", "L90", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadDiameter})

                clsAddExistingCodes.AddTubeMaterialCode(_strTubeMaterialCode_Purchase, clsAddExistingCodes.GetTubeLength(), "FT")
                'TODO: ANUP 20-04-2010 02.38pm
                ControlsData.Add(New Object(3) {"GUI", "BUSHING BASE END CODE ", "L86", _strBushingPartNumber_BaseEnd})
                'ANUP 06-10-2010 START 
                strPartCode = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(_strBushingPartNumber_BaseEnd)
                If Not String.IsNullOrEmpty(strPartCode) Then
                    _strBushingBaseEndCode_Purchase = strPartCode
                Else
                    _strBushingBaseEndCode_Purchase = _strBushingPartNumber_BaseEnd
                End If
                clsAddExistingCodes.AddBushingBaseEndCode(_strBushingBaseEndCode_Purchase, 1, "EA")
                'ANUP 06-10-2010 TILL HERE

                ControlsData.Add(New Object(3) {"GUI", "BUSHING ROD END CODE ", "L87", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingPartCode_RodEnd})
                clsAddExistingCodes.AddBushingBaseEndCode(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingPartCode_RodEnd, 1, "EA")
                ControlsData.Add(New Object(3) {"GUI", "BUSH INNER DIA", "L91", _dblBushingID_BaseEnd})
                ControlsData.Add(New Object(3) {"GUI", "BUSHING STYLE ", "L92", cmbStyle.Text})

                'anup 10-02-2011 start
                'ControlsData.Add(New Object(3) {"GUI", "BUSHING STYLE ", "L92", cmbStyle.Text})
                'Dim strStyle As String = String.Empty
                'If cmbStyle.Text = "1 Bushing" Then
                '    strStyle = "Bushing"
                'ElseIf cmbStyle.Text = "2 Bushings Single Bore" Then
                '    strStyle = "Bushings Single Bore"
                'ElseIf cmbStyle.Text = "2 Bushings Individual Bores" Then
                '    strStyle = "Bushings Individual Bores"
                'End If
                'ControlsData.Add(New Object(3) {"GUI", "BUSHING STYLE ", "L92", strStyle})
                'anup 10-02-2011 till here
                '***********

                'TODO: ANUP 23-04-2010 01.39pm
                ControlsData.Add(New Object(3) {"GUI", " CLEVIS PLATE ", "L84", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateImportOrExisting})
                '**************
                ControlsData.Add(New Object(3) {"GUI", "END_COLLAR_CODE", "L94", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CollarCodeNumber})     '25_05_2010   RAGAVA  CollarDetails
                'ANUP 06-10-2010 START 
                strPartCode = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CollarCodeNumber)
                If Not String.IsNullOrEmpty(strPartCode) Then
                    _strEndCollarCode_Purchase = strPartCode
                Else
                    _strEndCollarCode_Purchase = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CollarCodeNumber
                End If
                clsAddExistingCodes.AddEndCollarCode(_strEndCollarCode_Purchase, 1, "EA")
                'ANUP 06-10-2010 TILL HERE
                '25_05_2010   RAGAVA  CollarDetails
                If Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndCodeNumber90 Is Nothing Then
                    ControlsData.Add(New Object(3) {"GUI", "BASE_END_CONFIGURATION", "L93", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndCodeNumber90.ToString})
                End If
                'Till  Here
                Return ControlsData

            Catch ex As Exception
            End Try
        End Get
    End Property

#End Region

#Region "Enums"

    Private Enum WallThicknessListView
        WallThickness = 0
        MaterialType = 1
        Status = 2
        Comment = 3
        IFLID = 4
    End Enum

#End Region

#Region "SubProcedures"

    Private Sub DefaultSettings()


        pinHolesAndThicknessList.Add(0.5, 0.645)
        pinHolesAndThicknessList.Add(0.625, 0.791)
        pinHolesAndThicknessList.Add(0.75, 0.884)
        pinHolesAndThicknessList.Add(0.875, 0.978)
        pinHolesAndThicknessList.Add(1.0, 1.096)
        pinHolesAndThicknessList.Add(1.25, 1.283)
        pinHolesAndThicknessList.Add(1.375, 1.413)
        pinHolesAndThicknessList.Add(1.5, 1.507)
        pinHolesAndThicknessList.Add(1.75, 1.728)
        pinHolesAndThicknessList.Add(2.0, 1.95)


        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PullForce = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure * (Math.PI / 4) * (Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, 2) - Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, 2))

        'TODO:  COMMENTED BY ANUP ----- CHECK THE DesignTypeValidation() ------ 02-052010 
        'cmbDesignType.Items.Add("Conventional")
        'cmbDesignType.Items.Add("WR Cylinder")              '27_04_2010    RAGAVA
        'cmbDesignType.SelectedIndex = 0
        ''cmbDesignType.Enabled = False         '27_04_2010    RAGAVA
        'cmbDesignType.BackColor = Color.Empty
        '*******************

        'TODO:  COMMENTED BY ANUP ----- CHECK THE BaseEndConfigurationValidation() ------ 03-05-2010 10.23am
        'cmbBaseEndConfiguration.Items.Add("Plate Clevis")
        'cmbBaseEndConfiguration.Items.Add("Cross Tube")
        'cmbBaseEndConfiguration.Items.Add("Single Lug")
        'cmbBaseEndConfiguration.Items.Add("Double Lug")
        'cmbBaseEndConfiguration.Items.Add("Base Plug")
        'cmbBaseEndConfiguration.Items.Add("Threaded End")

        'TODO: ANUP 12-04-2010 02.12
        'cmbBaseEndConfiguration.Items.Add("Import Special")
        '*****************

        'cmbBaseEndConfiguration.SelectedIndex = 0
        '*******************

        '8_3_2010 Aruna
        'cmbLugInTubeDiameter.Items.Clear()
        'cmbLugInTubeDiameter.Items.Add("Yes")
        'cmbLugInTubeDiameter.Items.Add("No")
        'cmbLugInTubeDiameter.SelectedIndex = 0

        'ANUP 08-11-2010 START
        'COMMENTED BECAUSE CLIPS IS REMOVED (VISIBLE =FALSE) IN THIS FORM
        'lblClips.Enabled = False
        'cmbClips.Enabled = False
        'cmbClips.Items.Add("Hair Pin")
        'cmbClips.Items.Add("Cotter Pin")
        'cmbClips.Items.Add("Cir Clips")
        'cmbClips.Items.Add("R Clips")
        'cmbClips.SelectedIndex = 0
        lblPins.Visible = False
        cmbPins.Visible = False
        'ANUP 08-11-2010 TILL HERE
        'ANUP 12-10-2010 START
        lblClips.Visible = False
        cmbClips.Visible = False
        'ANUP 12-10-2010 TILL HERE
        rdbMilledFlatYes.Checked = False

        ' ANUP 28-04-2010 10.23am
        rdbMilledFlatNo.Checked = True
        '***********

        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlat = "No"

        ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd = txtLugThickness
        ObjClsWeldedCylinderFunctionalClass.TxtCrossTubeWidth_BaseEnd = txtCrossTubeWidth
        ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd = txtSwingClearance
        ObjClsWeldedCylinderFunctionalClass.TxtLugGap_BaseEnd = txtLugGap
        ObjClsWeldedCylinderFunctionalClass.CmbBushingPinHoleSize_BaseEnd = cmbBushingPinHoleSize
        ObjClsWeldedCylinderFunctionalClass.CmbPinHoleSize_BaseEnd = cmbPinHoleSize
        ObjClsWeldedCylinderFunctionalClass.TxtPinHoleSize_BaseEnd = txtPinHoleSize
        ObjClsWeldedCylinderFunctionalClass.CmbGreaseZercs_BaseEnd = cmbGreaseZercs
        ObjClsWeldedCylinderFunctionalClass.TxtAngleOfGreaseZercs1_BaseEnd = txtAngleOfGreaseZercs1
        ObjClsWeldedCylinderFunctionalClass.TxtAngleOfGreaseZercs2_BaseEnd = txtAngleOfGreaseZercs2
        '26_02_2010 Aruna Start
        ObjClsWeldedCylinderFunctionalClass.TxtCrossTubeOffset_BaseEnd = txtOffSet
        '26_02_2010 Aruna Ends

        'ObjClsWeldedCylinderFunctionalClass.TxtBasePlugDia_BaseEnd = txtBasePlugDiameter

        ' ANUP 10-03-2010 03.44
        ObjClsWeldedCylinderFunctionalClass.TxtThreadDiameter_BaseEnd = cmbThreadSize
        ObjClsWeldedCylinderFunctionalClass.TxtThreadLength_BaseEnd = txtThreadLength
        '*****************

        ' ANUP 05-07-2010 11.02am
        ObjClsWeldedCylinderFunctionalClass.CmbWeldType_BaseEnd = cmbWeldType

        'TODO: ANUP 12-07-2010 12.03pm
        ObjClsWeldedCylinderFunctionalClass.CmbBaseEndConfiguration = cmbBaseEndConfiguration

        'TODO: ANUP 23-07-2010 09.24am
        'ANUP 08-11-2010 START
        'ObjClsWeldedCylinderFunctionalClass.CmbPins_BaseEnd = cmbPins
        'ObjClsWeldedCylinderFunctionalClass.CmbClips_BaseEnd = cmbClips
        'ANUP 08-11-2010 TILL HERE

        'anup 31-08-2010 
        ObjClsWeldedCylinderFunctionalClass.TxtToleranceUpperLimit = txtToleranceUpperLimit
        ObjClsWeldedCylinderFunctionalClass.TxtToleranceLowerLimit = txtToleranceLowerLimit

        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.New_Revision = "Revision'" Then
            ObjClsWeldedCylinderFunctionalClass.IsValueChanged_Revision = False
        End If
        'ANUP 11-10-2010 TILL HERE
    End Sub

    Public Sub ManualLoad()
        Try

            If Not _dblTempBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter _
            OrElse Not _dblTempWorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure _
            OrElse Not _strTempClass = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass _
            OrElse Not _strTempCylinderHeadDesign = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CylinderHeadDesign Then
                _dblTempBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
                _dblTempWorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure
                _strTempClass = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass
                _strTempCylinderHeadDesign = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CylinderHeadDesign
                PopulateWallThicknessListView()
                ReLoadPinHole()
                'DesignTypeValidation() 'TODO: ANUP 02-05-2010 01.53pm    'anup 27-12-2010 
            End If
            DesignTypeValidation() 'anup 27-12-2010 

            '27_02_2012   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.ChkASAE.Checked = True Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 3 Then
                    cmbDesignType.Text = "WR Cylinder"
                Else
                    cmbDesignType.Text = "Conventional"
                End If
                cmbDesignType.Enabled = False
                cmbBaseEndConfiguration.Text = "Double Lug"
                cmbBaseEndConfiguration.Enabled = False
                txtLugGap.Text = "1.125"
                txtLugGap.Enabled = False
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 4.75 Then
                    cmbPinHoleSize.Text = "1.265"
                Else
                    cmbPinHoleSize.Text = "1.015"
                End If
                txtPinHoleSize.Enabled = False
            Else
                cmbDesignType.Enabled = True
                txtPinHoleSize.Clear()
                txtPinHoleSize.Enabled = True
                txtLugGap.Clear()
                txtLugGap.Enabled = True
                cmbBaseEndConfiguration.Enabled = True
            End If
            'Till  Here

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CommenCalculations()
        'TODO ANUP 27-02-2010 1pm
        'ANUP 23-09-2010 START
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreDepth = 0 Then
            _dblRodDimension8 = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutActualSize + _
                                        (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonWidth - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreDepth) _
                                       + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.StickOutAdderDefault_RetractedLengthCalculation(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInDecimals) + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ExtraRodButtonLength
        Else
            _dblRodDimension8 = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutActualSize + _
                            (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonWidth - (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonWidth - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreDepth)) _
                           + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.StickOutAdderDefault_RetractedLengthCalculation(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInDecimals) + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ExtraRodButtonLength
        End If

        'ANUP 27-09-2010 START 
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.Dimension8 = _dblRodDimension8
        'ANUP 27-09-2010 TILL HERE

        'ANUP 23-09-2010 TILL HERE
        '***********************
        _dblCh_ShankLength = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ShankLength
        _dblStrokeLength = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength
    End Sub

    Private Function TubeLengthCalculation() As Double
        TubeLengthCalculation = 0
        Try
            TubeLengthCalculation = _dblCh_ShankLength + _dblStrokeLength + _dblRodDimension8 - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop + _
                                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StopTubeLength
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalTubeLength = TubeLengthCalculation '28-05-2010 raghava
            TubeLengthCalculation = TubeLengthCalculation - GetCollarCylinderLength()         '25_05_2010   RAGAVA   CollarDetails
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalTubeLength = TubeLengthCalculation '21-10-2010 raghava
        Catch ex As Exception
            TubeLengthCalculation = 0
        End Try
    End Function


    '25_05_2010   RAGAVA   CollarDetails
    Public Function GetCollarCylinderLength() As Double
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
                '21_12_2010  RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked = True Then
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Extension" Then
                        Dim strQuery As String = "Select * from CollarDetails_RodEndRephasing where BoreDiameter = " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness  and portSize = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.Text.ToString) + "' and PortType = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.Text.ToString) + "' and PortAngle = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text.ToString) + "' and NumberOfPorts = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsRodEnd.Text.ToString) + "'"
                        Dim _oRow As DataRow = MonarchConnectionObject.GetDataRow(strQuery)
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CollarCodeNumber = _oRow("CodeNumber").ToString
                        If IsDBNull(_oRow("CylinderLength")) Then
                            Return 0
                        End If
                        Return _oRow("CylinderLength")
                    Else
                        MsgBox("Data for Rephasing collardetails are available for RodEnd Only")
                    End If
                    'Till   Here
                Else
                    Dim strQuery As String = "Select * from CollarDetails where BoreDiameter = " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness  and portSize = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.Text.ToString) + "' and PortType = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.Text.ToString) + "' and PortAngle = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text.ToString) + "' and NumberOfPorts = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsRodEnd.Text.ToString) + "'"
                    If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text.ToString) = "90" Then
                        strQuery = strQuery + " and PortFacingEnd = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortFacingRodEnd.Text.ToString) + "'"
                    End If
                    Dim _oRow As DataRow = MonarchConnectionObject.GetDataRow(strQuery)
                    If Not _oRow Is Nothing Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CollarCodeNumber = _oRow("CodeNumber").ToString
                        Return _oRow("CylinderLength")
                    Else
                        Return 0
                    End If
                End If
            Else
                Return 0
            End If
        Catch ex As Exception
            MsgBox("Error in Retrieving CollarCylinderLength")
        End Try
    End Function

    Private Function TubeEndToBaseEndPortCalculation() As Double
        TubeEndToBaseEndPortCalculation = 0
        Try
            'ANUP 02-07-2010
            ''If ObjClsWeldedCylinderFunctionalClass.IsCounterBoreOrNot Then
            ''    TubeEndToBaseEndPortCalculation = _dblRodDimension8 - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop - _
            ''                               ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonWidth + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonWidth - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreDepth)
            ''Else

            ' Removed on 01-02-2011 by Ram
            TubeEndToBaseEndPortCalculation = _dblRodDimension8 - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop - _
                       ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonWidth
            ''End If
        Catch ex As Exception
            TubeEndToBaseEndPortCalculation = 0
        End Try
    End Function

    '01_07_2011   RAGAVA
    Public Function PistonPositionInRetraction() As Double
        Try
            PistonPositionInRetraction = 0.0
            Dim dblAllowableDistPistonCanMove As Double = 0.0
            Dim _strQuery As String = "select OrificeDistanceToMove from WELDED.PistonDetails where PistonCode= '" & ObjClsWeldedCylinderFunctionalClass.ObjFrmPistonDesign.txtPistonCode.Text & "'"
            dblAllowableDistPistonCanMove = MonarchConnectionObject.GetValue(_strQuery)
            CommenCalculations()
            Dim x As Double = 0.125 + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortOD / 2)
            Dim Y As Double = _dblRodDimension8 - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonWidth - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop
            Dim Z As Double = (Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd) - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_BaseEnd) / 2
            If x > Y Then
                If (x - Y) > dblAllowableDistPistonCanMove Then
                    If (x - Y - dblAllowableDistPistonCanMove) <= Z Then
                        PistonPositionInRetraction = x - Y - dblAllowableDistPistonCanMove
                    End If
                End If
            End If
            Return PistonPositionInRetraction
        Catch ex As Exception

        End Try
    End Function

    Private Function TubeEndToRodEndPortCalculation() As Double
        TubeEndToRodEndPortCalculation = 0
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CylinderHeadDesign = "WireRing" Then
                TubeEndToRodEndPortCalculation = TubeLengthCalculation() - (_dblCh_ShankLength - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoseLength) - _
                (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_RodEnd / 2)
            Else
                'TubeEndToRodEndPortCalculation = TubeLengthCalculation() - (_dblCh_ShankLength - 0.31) - _
                '   (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_RodEnd / 2)
                TubeEndToRodEndPortCalculation = TubeLengthCalculation() - (_dblCh_ShankLength - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CylinderThreadedHeadChamferLength) - _
   (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_RodEnd / 2)
            End If
        Catch ex As Exception
            TubeEndToRodEndPortCalculation = 0
        End Try
    End Function

    Private Sub PopulateWallThicknessListView()
        Try
            lvwWallThickness.FullRowSelect = True
            lvwWallThickness.MultiSelect = False 'anup 10-02-2011
            lvwWallThickness.HideSelection = False

            Dim strClassType As String = ""
            If cmbDesignType.Text = "Conventional" Then
                strClassType = "ConventionalDesignClass"
                'ElseIf cmbDesignType.Text = "New" Then
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then       '31_05_2010    RAGAVA
                strClassType = "NewDesignClass"
            End If
            strClassType += ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass

            Dim oWallThicknessDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
            GetWallThickness(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure, strClassType)

            lvwWallThickness.Columns.Clear()
            lvwWallThickness.Items.Clear()
            lvwWallThickness.Columns.Add("Wall Thickness", 100, HorizontalAlignment.Center)
            lvwWallThickness.Columns.Add("Material Type", 100, HorizontalAlignment.Center)
            lvwWallThickness.Columns.Add("Status", 75, HorizontalAlignment.Center)
            lvwWallThickness.Columns.Add("Comment", 160, HorizontalAlignment.Center)
            lvwWallThickness.Columns.Add("IFLID", 100, HorizontalAlignment.Center)
            If Not IsNothing(oWallThicknessDataTable) Then
                For Each oWallThicknessRow As DataRow In oWallThicknessDataTable.Rows
                    Dim oWallThicknessListItem As ListViewItem
                    oWallThicknessListItem = lvwWallThickness.Items.Add(oWallThicknessRow("TubeWallThickness"))
                    oWallThicknessListItem.SubItems.Add(oWallThicknessRow("TubeMaterial"))
                    If oWallThicknessRow(7).contains("D") Then
                        oWallThicknessListItem.SubItems.Add("D")
                    ElseIf oWallThicknessRow(7).contains("Y") Then
                        oWallThicknessListItem.SubItems.Add("Y")
                    Else
                        oWallThicknessListItem.SubItems.Add(oWallThicknessRow(7))
                    End If

                    Dim strComment As String = ""
                    If oWallThicknessRow(7).Equals("YR") Then
                        strComment = "Requires Design Validation"
                        oWallThicknessListItem.ForeColor = Color.Red
                    ElseIf oWallThicknessRow(7).Equals("DR") Then
                        strComment = "Requires Design Validation"
                        oWallThicknessListItem.ForeColor = Color.Red
                    End If

                    ' ANUP 24-06-2010 
                    If oWallThicknessRow(7).Equals("DY") OrElse oWallThicknessRow(7).Equals("YY") Then
                        strComment = "Requires Design Validation"
                        oWallThicknessListItem.ForeColor = Color.Red
                    ElseIf oWallThicknessRow(7).Equals("NR") OrElse oWallThicknessRow(7).Equals("N") Then
                        strComment = "Tube Material is not available "
                        oWallThicknessListItem.ForeColor = Color.Red
                    End If

                    If oWallThicknessRow(7).Equals("DY") Then
                        strComment = "Requires Design Validation"
                        oWallThicknessListItem.ForeColor = Color.Red
                    ElseIf oWallThicknessRow(7).Equals("YY") Then
                        strComment = "Requires Design Validation"
                        oWallThicknessListItem.ForeColor = Color.Red
                    End If
                    '**********************

                    oWallThicknessListItem.SubItems.Add(strComment)
                    oWallThicknessListItem.SubItems.Add(oWallThicknessRow("IFLID"))
                    If oWallThicknessRow(7).contains("D") Then
                        oWallThicknessListItem.Selected = True  'anup 08-03-2011 
                        'lvwWallThickness.Items(0).Selected = True
                    End If

                    'anup 27-12-2010 start
                    lvwWallThickness.Enabled = True
                    If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked = True Then 'anup 03-01-2011
                        If cmbDesignType.Text = "WR Cylinder" Then
                            lvwWallThickness.Items(0).Selected = True
                            lvwWallThickness.Enabled = False
                            Exit For
                        End If
                    End If
                    'anup 27-12-2010 till here

                Next
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured while populating lvwWallThickness(PopulateWallThicknessListView) of frmTubeDetails " + ex.Message)
        End Try
    End Sub

    'TODO: COMMENTED BY ANUP  19-04-2010 04.15
    'Private Sub CmbBushingTypeFunctionality()
    '    cmbBushingType.Enabled = True
    '    cmbBushingType.Items.Add("Greaseless")
    '    cmbBushingType.Items.Add("Spring Steel")
    '    cmbBushingType.Items.Add("Spring Steel with Grease Groove+")
    '    If cmbBaseEndConfiguration.Text = "Single Lug" Then
    '        cmbBushingType.Items.Add("Bearing (Pressed)")
    '        cmbBushingType.Items.Add("Bearing (Retained)")
    '    End If
    '    cmbBushingType.SelectedIndex = 2
    'End Sub
    '********************

    Private Sub CmbPinHoleFunctionality()
        If cmbBaseEndConfiguration.Text = "Single Lug" OrElse cmbBaseEndConfiguration.Text = "Double Lug" _
        OrElse cmbBaseEndConfiguration.Text = "Base Plug" OrElse cmbBaseEndConfiguration.Text = "Cross Tube" Then
            cmbPinHole.Enabled = True
            cmbPinHole.Items.Add("Standard")
            cmbPinHole.Items.Add("Hardened")
            cmbPinHole.SelectedIndex = 0
        ElseIf cmbBaseEndConfiguration.Text = "BH" Then 'MANJULA 15-02-12 ADDED CONDITION

            cmbPinHole.Enabled = False
            cmbPinHole.Items.Add("Standard")
            cmbPinHole.SelectedIndex = 0
        Else

            cmbPinHole.Items.Clear()
            cmbPinHole.Enabled = False
            cmbPinHole.BackColor = Color.Empty
        End If
    End Sub

    Private Sub CmbPinHoleSizeTypeFunctionality()
        If cmbBaseEndConfiguration.Text = "BH" Then 'MANJULA 15-02-12 ADDED CONDITION
            cmbPinHoleSizeType.Enabled = False
            cmbPinHoleSizeType.Items.Add("Standard")
            cmbPinHoleSizeType.Items.Add("Custom")
            cmbPinHoleSizeType.SelectedIndex = 0
        Else
            cmbPinHoleSizeType.Enabled = True
            cmbPinHoleSizeType.Items.Add("Standard")
            cmbPinHoleSizeType.Items.Add("Custom")
            cmbPinHoleSizeType.SelectedIndex = 0

        End If
        
    End Sub

    Private Sub CmbPinHoleSizeFunctionality(ByVal cmbPinHole As ComboBox)
        cmbPinHoleSize.Visible = True
        Try
            Dim oPinHoleSizesDatatable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                    GetPinHoleSizes(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter)
            If Not IsNothing(oPinHoleSizesDatatable) Then
                cmbPinHole.DataSource = oPinHoleSizesDatatable
                cmbPinHole.DisplayMember = "PinHole"
                cmbPinHole.ValueMember = "PinHole"
                'TODO: ANUP 27-04-2010 05.35pm
                'cmbPinHole.SelectedIndex = 0
                cmbPinHole.Text = ObjClsWeldedCylinderFunctionalClass.PinHoleSizes_DefaultSettings(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter)
                cmbPinHole.SelectedIndex = cmbPinHole.SelectedIndex
                '******************
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured while populating cmbPinHole(CmbPinHoleSizeFunctionality) of frmTubeDetails " + ex.Message)
        End Try
    End Sub

    Private Sub ControlsEnabling()

        pnlCrossTube_Thread.Visible = False
        'pnlBasePlugDetails.Visible = False

        txtOutSidePlugDiameter.Visible = False
        lblOutSidePlugDiameter.Visible = False

        lblCrossTubeWidth.Visible = False
        txtCrossTubeWidth.Visible = False

        txtLugThickness.Visible = True
        lblLugThickness.Visible = True
        txtLugThickness.Text = ""
        txtLugThickness.Enabled = False
        txtLugThickness.BackColor = Color.Empty

        txtLugGap.Text = ""
        txtLugGap.Enabled = False
        txtLugGap.BackColor = Color.Empty

        lblOffSet.Visible = False
        txtOffSet.Text = ""
        txtOffSet.Visible = False
        txtOffSet.BackColor = Color.Empty

        cmbThreadSize.Text = ""
        cmbThreadSize.Enabled = False
        cmbThreadSize.BackColor = Color.Empty

        txtThreadLength.Text = ""
        txtThreadLength.Enabled = False
        txtThreadLength.BackColor = Color.Empty

        If cmbBaseEndConfiguration.Text = "Single Lug" Then
            pnlCrossTube_Thread.Visible = True
            txtLugThickness.Enabled = True
        ElseIf cmbBaseEndConfiguration.Text = "Double Lug" Then
            pnlCrossTube_Thread.Visible = True
            txtLugThickness.Enabled = True
            txtLugGap.Enabled = True
            txtLugGap.Visible = True
            lblLugGap.Visible = True
        ElseIf cmbBaseEndConfiguration.Text = "Cross Tube" Then
            pnlCrossTube_Thread.Visible = True
            txtCrossTubeWidth.Visible = True
            lblCrossTubeWidth.Visible = True
            txtLugThickness.Visible = False
            lblLugThickness.Visible = False
            txtOffSet.Visible = True
            txtOffSet.Text = 0
            txtLugGap.Visible = False
            lblOffSet.Visible = True
            lblLugGap.Visible = False
        ElseIf cmbBaseEndConfiguration.Text = "Base Plug" Then
            ' pnlBasePlugDetails.Visible = True
            txtOutSidePlugDiameter.Visible = True
            lblOutSidePlugDiameter.Visible = True
            txtLugThickness.Visible = False
            lblLugThickness.Visible = False
        ElseIf cmbBaseEndConfiguration.Text = "Threaded End" Then
            pnlCrossTube_Thread.Visible = True
            cmbThreadSize.Enabled = True
            txtThreadLength.Enabled = True
        ElseIf cmbBaseEndConfiguration.Text = "Import Special" OrElse cmbBaseEndConfiguration.Text = "Plate Clevis" Then
            pnlCrossTube_Thread.Visible = True
        End If
    End Sub

    Private Sub ControlsEnabling1()
        txtSwingClearance.Enabled = True       '01_04_2010   RAGAVA
        cmbBaseEndPort.Items.Clear()
      
        'TODO: ANUP 26-05-2010 3.34am
        'If cmbDesignType.Text = "New" Then
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then       '31_05_2010    RAGAVA
            cmbBaseEndPort.Items.Add("Port Integral")
            cmbBaseEndPort.Enabled = False
        Else
            cmbBaseEndPort.Items.Add("Port In Tube")
            cmbBaseEndPort.Items.Add("Port Integral")
            cmbBaseEndPort.Enabled = True
        End If
        '*****************
        cmbBaseEndPort.SelectedIndex = 0

        'ANUP 08-11-2010 START
        'cmbPins.Items.Clear()
        'cmbPins.Items.Add("Yes")
        'cmbPins.Items.Add("No")
        'cmbPins.SelectedIndex = 1
        'cmbPins.Enabled = True
        'ANUP 08-11-2010 TILL HERE

        lblLugThickness.Visible = True
        txtLugThickness.Visible = True

        txtLugThickness.Enabled = False
       
        lblCrossTubeWidth.Visible = False
        txtCrossTubeWidth.Visible = False
        txtCrossTubeWidth.Enabled = False

        lblOutSidePlugDiameter.Visible = False
        txtOutSidePlugDiameter.Visible = False
        txtOutSidePlugDiameter.Enabled = False

        grbBasePlugDetails.Visible = False
        grbBasePlugDetails.Enabled = False
        pnlCrossTube_Thread.Visible = True
        pnlCrossTube_Thread.Enabled = False

        cmbBushingQuantity.Items.Clear()
        cmbBushingQuantity.IFLDataTag = Nothing

        cmbGreaseZercs.Items.Clear()
        cmbGreaseZercs.Items.Add(0)
        cmbGreaseZercs.Items.Add(1)
        cmbGreaseZercs.Items.Add(2)
        cmbGreaseZercs.SelectedIndex = 0
        cmbGreaseZercs.Enabled = False
        cmbGreaseZercs.BackColor = Color.Empty

        If cmbBaseEndConfiguration.Text = "Plate Clevis" Then
            cmbBaseEndPort.Items.Clear()
            cmbBaseEndPort.Items.Add("Port In Tube")
            '27_04_2010    RAGAVA   NEW DESIGN
            'cmbBaseEndPort.Enabled = False
            cmbBaseEndPort.BackColor = Color.Empty
            cmbBaseEndPort.SelectedIndex = 0

            cmbBushingQuantity.Items.Add(0)
            cmbBushingQuantity.SelectedIndex = 0
            cmbBushingQuantity.Enabled = False
            cmbBushingQuantity.BackColor = Color.Empty
            txtSwingClearance.Clear()               '01_04_2010   RAGAVA
            txtSwingClearance.Enabled = False       '01_04_2010   RAGAVA

            cmbPinHoleSizeType.Enabled = False
            cmbPinHoleSize.Enabled = False
            txtPinHoleSize.Enabled = False
            txtToleranceUpperLimit.Enabled = False
            txtToleranceLowerLimit.Enabled = False

            'ANUP 08-11-2010 START
            'cmbPins.Items.Clear()
            'cmbPins.Items.Add("No")
            'cmbPins.SelectedIndex = 0
            'cmbPins.Enabled = False
            'cmbPins.BackColor = Color.Empty
            'ANUP 08-11-2010 TILL HERE

        ElseIf cmbBaseEndConfiguration.Text = "Cross Tube" Then
            txtSwingClearance.Enabled = False
            txtSwingClearance.Text = ""
            txtSwingClearance.BackColor = Color.Empty


            'ANUP 08-11-2010 START
            'cmbPins.Items.Clear()
            'cmbPins.Items.Add("No")
            'cmbPins.SelectedIndex = 0
            'cmbPins.Enabled = False
            'cmbPins.BackColor = Color.Empty
            'ANUP 08-11-2010 TILL HERE

            lblCrossTubeWidth.Visible = True
            txtCrossTubeWidth.Visible = True
            txtCrossTubeWidth.Enabled = True

            lblLugThickness.Visible = False
            txtLugThickness.Visible = False
            txtLugThickness.Enabled = False

            pnlCrossTube_Thread.Enabled = True

            txtLugGap.Visible = False
            lblLugGap.Visible = False
            txtLugGap.Enabled = False
            cmbThreadSize.Enabled = False
            txtThreadLength.Enabled = False

            lblOffSet.Visible = True
            txtOffSet.Visible = True
            txtOffSet.Enabled = True

            cmbBushingQuantity.Items.Add(0)
            cmbBushingQuantity.Items.Add(1)
            cmbBushingQuantity.Items.Add(2)
            cmbBushingQuantity.Enabled = True
            cmbBushingQuantity.SelectedIndex = 0
            'TODO: ANUP 27-04-2010 11.44am
            cmbGreaseZercs.Enabled = True

            'TODO: COMMENTED BY ANUP  20-04-2010 09.27am
            'cmbGreaseZercs.Enabled = True

            'MANJULA 14-02-12
        ElseIf cmbBaseEndConfiguration.Text = "BH" Then 'MANJULA 15-02-12 ADDED CONDITION

            txtLugThickness.Enabled = False
            cmbBushingQuantity.Items.Add(0)
            cmbBushingQuantity.Items.Add(1)

            'TODO: ANUP 27-04-2010 04.18pm
            'cmbBushingQuantity.Items.Add(2)
            '**********

            cmbBushingQuantity.Enabled = True
            cmbBushingQuantity.SelectedIndex = 0
            '*********

        ElseIf cmbBaseEndConfiguration.Text = "Single Lug" Then
            txtLugThickness.Enabled = True

            cmbBushingQuantity.Items.Add(0)
            cmbBushingQuantity.Items.Add(1)

            'TODO: ANUP 27-04-2010 04.18pm
            'cmbBushingQuantity.Items.Add(2)
            '**********

            cmbBushingQuantity.Enabled = True
            cmbBushingQuantity.SelectedIndex = 0

            'TODO: COMMENTED BY ANUP  20-04-2010 09.27am
            ' cmbGreaseZercs.Enabled = True


        ElseIf cmbBaseEndConfiguration.Text = "Double Lug" Then
            txtLugThickness.Enabled = True

            pnlCrossTube_Thread.Enabled = True

            lblOffSet.Visible = False
            txtOffSet.Visible = False
            txtOffSet.Enabled = False

            txtLugGap.Visible = True
            lblLugGap.Visible = True
            txtLugGap.Enabled = True

            cmbBushingQuantity.Items.Add(0)
            cmbBushingQuantity.Items.Add(2)
            cmbBushingQuantity.Enabled = True
            cmbBushingQuantity.SelectedIndex = 0

            'ANUP 01-03-2010 12.07
            cmbThreadSize.Text = ""
            txtThreadLength.Text = ""
            cmbThreadSize.Enabled = False
            txtThreadLength.Enabled = False
            '****************


        ElseIf cmbBaseEndConfiguration.Text = "Base Plug" Then
            cmbGreaseZercs.Items.Remove(2)       '06_09_2010    RAGAVA
            grbBasePlugDetails.Visible = True
            pnlCrossTube_Thread.Visible = False
            pnlCrossTube_Thread.Enabled = False
            grbBasePlugDetails.Enabled = True

            lblOutSidePlugDiameter.Visible = True
            txtOutSidePlugDiameter.Visible = True
            txtOutSidePlugDiameter.Enabled = True

            lblLugThickness.Visible = False
            txtLugThickness.Visible = False
            txtLugThickness.Enabled = False

            cmbBushingQuantity.Items.Add(0)
            cmbBushingQuantity.Items.Add(1)
            cmbBushingQuantity.Items.Add(2)
            cmbBushingQuantity.Enabled = True
            cmbBushingQuantity.SelectedIndex = 0
            'TODO: ANUP 27-04-2010 11.44am
            cmbGreaseZercs.Enabled = True

            'TODO: COMMENTED BY ANUP  20-04-2010 09.27am
            ' cmbGreaseZercs.Enabled = True

        ElseIf cmbBaseEndConfiguration.Text = "Threaded End" Then

            pnlCrossTube_Thread.Enabled = True

            'ANUP 08-11-2010 START
            'cmbPins.Items.Clear()
            'cmbPins.Items.Add("No")
            'cmbPins.SelectedIndex = 0
            'cmbPins.Enabled = False
            'cmbPins.BackColor = Color.Empty
            'ANUP 08-11-2010 TILL HERE


            cmbThreadSize.Enabled = True
            txtThreadLength.Enabled = True

            lblOffSet.Visible = False
            txtOffSet.Visible = False
            txtOffSet.Enabled = False
            txtLugGap.Visible = True
            lblLugGap.Visible = True
            txtLugGap.Enabled = False

            cmbBushingQuantity.Items.Add(0)
            cmbBushingQuantity.SelectedIndex = 0
            cmbBushingQuantity.Enabled = False
            cmbBushingQuantity.BackColor = Color.Empty

            cmbPinHoleSizeType.Enabled = False
            cmbPinHoleSize.Enabled = False
            txtPinHoleSize.Enabled = False
            txtToleranceUpperLimit.Enabled = False
            txtToleranceLowerLimit.Enabled = False

        ElseIf cmbBaseEndConfiguration.Text = "Import Special" Then
            cmbBushingQuantity.Items.Add(0)
            cmbBushingQuantity.SelectedIndex = 0
            cmbBushingQuantity.Enabled = False
            cmbBushingQuantity.BackColor = Color.Empty

            'ANUP 16-08-2010
        ElseIf cmbBaseEndConfiguration.Text = "Import" Then
            txtSwingClearance.Enabled = False
            txtSwingClearance.Text = ""
            txtSwingClearance.BackColor = Color.Empty

            'ANUP 08-11-2010 START
            'cmbPins.Enabled = False
            'cmbPins.BackColor = Color.Empty
            'ANUP 08-11-2010 TILL HERE

            'ANUP 17-09-2010 START
            cmbBushingQuantity.Items.Add(0)
            cmbBushingQuantity.SelectedIndex = 0
            cmbBushingQuantity.Enabled = False
            cmbBushingQuantity.BackColor = Color.Empty

            cmbPinHoleSizeType.Enabled = False
            cmbPinHoleSize.Enabled = False
            txtPinHoleSize.Enabled = False
            txtToleranceUpperLimit.Enabled = False
            txtToleranceLowerLimit.Enabled = False
            'ANUP 17-09-2010 TILL HERE

        End If

    End Sub

    'TODO: COMMENTED BY ANUP  20-04-2010 09.27am
    'Private Sub GreaseZercs()
    '    cmbGreaseZercs.Items.Clear()
    '    cmbGreaseZercs.Items.Add(0)
    '    cmbGreaseZercs.Items.Add(1)
    '    cmbGreaseZercs.Items.Add(2)
    '    cmbGreaseZercs.SelectedIndex = 0
    '    cmbGreaseZercs.Enabled = False
    '    cmbGreaseZercs.BackColor = Color.Empty
    '    If cmbBaseEndConfiguration.Text = "Cross Tube" OrElse cmbBaseEndConfiguration.Text = "Base Plug" _
    '   OrElse cmbBaseEndConfiguration.Text = "Single Lug" Then
    '        cmbGreaseZercs.Enabled = True
    '    End If
    'End Sub

    Private Sub ReLoadPinHole()
        If Not cmbBushingQuantity.Text = 0 Then
            If cmbBaseEndConfiguration.Text = "BH" Then 'MANJULA 15-02-12 ADDED CONDITION
                setBHCmbPinHoleValues(pinHolesAndThicknessList)
            Else
                CmbPinHoleSizeFunctionality(cmbBushingPinHoleSize)

            End If

        Else
            If cmbBaseEndConfiguration.Text = "BH" Then 'MANJULA 15-02-12 ADDED CONDITION
                setBHCmbPinHoleValues(pinHolesAndThicknessList)
            Else
                CmbPinHoleSizeFunctionality(cmbPinHoleSize)

            End If

        End If
    End Sub

    Private Sub BushingFunctionality()
        If cmbBushingQuantity.Text <> "" Then
            If cmbBushingQuantity.Text <> cmbBushingQuantity.IFLDataTag Then
                cmbBushingQuantity.IFLDataTag = cmbBushingQuantity.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity = Val(cmbBushingQuantity.Text)
                cmbBushingPinHoleSize.DataSource = Nothing

                'TODO: COMMENTED BY ANUP  19-04-2010 04.15
                'cmbBushingType.Items.Clear()
                'cmbBushingType.IFLDataTag = Nothing
                '*******

                txtBushingWidth.Text = ""
                cmbPinHole.Items.Clear()
                cmbPinHole.IFLDataTag = Nothing
                cmbPinHoleSizeType.Items.Clear()
                cmbPinHoleSizeType.IFLDataTag = Nothing

                If Not cmbBushingQuantity.Text = 0 Then
                    _strBushingYes_No = "Yes"
                    cmbBushingPinHoleSize.Enabled = True


                    'TODO: COMMENTED BY ANUP  19-04-2010 04.15
                    'CmbBushingTypeFunctionality()
                    '**********

                    txtBushingWidth.Enabled = True

                    cmbPinHole.Enabled = False
                    cmbPinHole.BackColor = Color.Empty

                    cmbPinHoleSizeType.Enabled = False
                    cmbPinHoleSizeType.BackColor = Color.Empty

                    cmbPinHoleSize.DataSource = Nothing
                    cmbPinHoleSize.Enabled = False
                    cmbPinHoleSize.BackColor = Color.Empty

                    txtPinHoleSize.Enabled = False
                    txtPinHoleSize.BackColor = Color.Empty

                    txtPinHoleSize.Text = ""
                    txtToleranceLowerLimit.Text = ""
                    txtToleranceUpperLimit.Text = ""
                    txtToleranceLowerLimit.Enabled = False
                    txtToleranceLowerLimit.BackColor = Color.Empty

                    txtToleranceUpperLimit.Enabled = False
                    txtToleranceUpperLimit.BackColor = Color.Empty
                    If cmbBaseEndConfiguration.Text = "BH" Then 'MANJULA 15-02-12 ADDED CONDITION
                        setBHCmbPinHoleValues(pinHolesAndThicknessList)
                    Else
                        CmbPinHoleSizeFunctionality(cmbBushingPinHoleSize)

                    End If




                    '11_02_2010-ARUNA START
                    If cmbBushingQuantity.Text = 1 Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType = "BX1"
                        'TODO: ANUP 27-04-2010 11.44am
                        If cmbBaseEndConfiguration.Text = "Cross Tube" OrElse cmbBaseEndConfiguration.Text = "Base Plug" Then
                            cmbGreaseZercs.Enabled = False
                        End If
                        '************
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType = "BX2"
                        'TODO: ANUP 27-04-2010 11.44am
                        If cmbBaseEndConfiguration.Text = "Cross Tube" OrElse cmbBaseEndConfiguration.Text = "Base Plug" Then
                            cmbGreaseZercs.Enabled = True
                        End If
                        '*************
                    End If
                    '11_02_2010-ARUNA END

                    'TODO: ANUP  19-04-2010 04.28

                    cmbMaterial.Items.Clear()
                    cmbStyle.Items.Clear()
                    cmbMaterial.Enabled = True
                    cmbStyle.Enabled = True

                    cmbMaterial.Items.Add("Steel")
                    cmbMaterial.Items.Add("Composite")

                    txtBushingWidth.Enabled = True
                    txtBushingWidth.Clear()

                    If cmbBaseEndConfiguration.Text = "Single Lug" Then
                        cmbStyle.Items.Add("1 Bushing")
                        If cmbBushingQuantity.Text = 1 Then
                            cmbStyle.SelectedIndex = 0
                            cmbStyle.Enabled = False
                            txtBushingWidth.Enabled = False
                            txtBushingWidth.Text = txtLugThickness.Text
                        End If
                    ElseIf cmbBaseEndConfiguration.Text = "Cross Tube" OrElse cmbBaseEndConfiguration.Text = "Base Plug" Then
                        cmbStyle.Items.Clear()
                        If cmbBushingQuantity.Text = 1 Then
                            cmbStyle.Items.Add("1 Bushing")
                            cmbStyle.SelectedIndex = 0
                            cmbStyle.Enabled = False
                            txtBushingWidth.Text = Val(txtCrossTubeWidth.Text)
                            txtBushingWidth.Enabled = False
                        Else
                            cmbStyle.Items.Add("2 Bushings Single Bore")
                            cmbStyle.Items.Add("2 Bushings Individual Bores")
                        End If
                    Else
                        cmbStyle.Items.Clear()
                        cmbStyle.Enabled = False
                    End If
                    '*************

                    'TODO: ANUP 18-06-2010 10.28am
                    BushingWidth_LugThickness_validation()
                    '******************

                Else
                    _strBushingYes_No = "No"
                    cmbBushingPinHoleSize.Enabled = False
                    cmbBushingPinHoleSize.BackColor = Color.Empty

                    'TODO: COMMENTED BY ANUP  19-04-2010 04.15
                    'cmbBushingType.Enabled = False
                    'cmbBushingType.BackColor = Color.Empty
                    '***************

                    txtBushingWidth.Enabled = False
                    txtBushingWidth.BackColor = Color.Empty

                    CmbPinHoleFunctionality()
                    CmbPinHoleSizeTypeFunctionality()
                    cmbPinHoleSize.Enabled = True
                    txtPinHoleSize.Enabled = True
                    'txtToleranceLowerLimit.Enabled = True
                    'txtToleranceUpperLimit.Enabled = True


                    'TODO: ANUP  19-04-2010 04.28
                    cmbStyle.Items.Clear()
                    cmbMaterial.Items.Clear()
                    cmbMaterial.Enabled = False
                    cmbStyle.Enabled = False
                    '*************

                    'TODO: ANUP 27-04-2010 11.44am
                    If cmbBaseEndConfiguration.Text = "Cross Tube" OrElse cmbBaseEndConfiguration.Text = "Base Plug" Then
                        cmbGreaseZercs.Enabled = True
                    End If
                    '*************

                End If
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity = 0
            cmbBushingQuantity.IFLDataTag = Nothing

            'TODO: COMMENTED BY ANUP  19-04-2010 04.15
            'cmbBushingType.Items.Clear()
            '***********

            txtBushingWidth.Text = ""
            cmbPinHoleSizeType.IFLDataTag = Nothing

        End If
    End Sub

    'TODO:  ANUP  20-04-2010 09.33am
    Private Sub GreaseZercsAllowedOrNot()
        If cmbBaseEndConfiguration.Text = "Cross Tube" OrElse cmbBaseEndConfiguration.Text = "Base Plug" Then
            If cmbBushingQuantity.Text = "0" Then
                cmbGreaseZercs.Enabled = True
            ElseIf cmbBushingQuantity.Text = "2" Then
                If cmbMaterial.Text = "Steel" Then
                    If cmbStyle.Text = "2 Bushings Single Bore" OrElse cmbStyle.Text = "2 Bushings Individual Bores" Then
                        cmbGreaseZercs.Enabled = True
                    Else
                        cmbGreaseZercs.Enabled = False
                    End If
                Else
                    cmbGreaseZercs.Enabled = False
                End If
            Else
                cmbGreaseZercs.Enabled = False
            End If
        Else
            cmbGreaseZercs.Enabled = False
        End If
    End Sub
    '******************

    'TODO:  ANUP  20-04-2010 11.51am
    Private Sub SearchForBushingsData()
        If cmbMaterial.Text <> "" AndAlso cmbBushingPinHoleSize.Text <> "" AndAlso txtBushingWidth.Text <> "" Then
            Dim oGetBushingDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetBushingDataTable(cmbMaterial.Text, Val(cmbBushingPinHoleSize.Text), Val(txtBushingWidth.Text))
            If Not IsNothing(oGetBushingDataTable) AndAlso Not oGetBushingDataTable.Rows.Count <= 0 Then
                For Each oDataRow As DataRow In oGetBushingDataTable.Rows
                    If Not IsDBNull(oDataRow("PartNumber")) Then
                        _strBushingPartNumber_BaseEnd = oDataRow("PartNumber")
                    Else
                        _strBushingPartNumber_BaseEnd = ""
                    End If

                    If Not IsDBNull(oDataRow("ID")) Then
                        _dblBushingID_BaseEnd = oDataRow("ID")
                    Else
                        _dblBushingID_BaseEnd = 0
                    End If

                    If Not IsDBNull(oDataRow("OD")) Then
                        _dblBushingOD_BaseEnd = oDataRow("OD")
                    Else
                        _dblBushingOD_BaseEnd = 0
                    End If
                Next

                'TODO: ANUP 20-04-2010 11.24am
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingOD_BaseEnd = _dblBushingOD_BaseEnd
                '**********
            End If
        End If
    End Sub

    'TODO: ANUP  23-04-2010 04.59pm
    Private Sub BushingWidthValueRounding()
        Try

            If (Val(txtBushingWidth.Text) Mod 0.125) <> 0 Then
                Dim dblBushingWidth As Double = Math.Round(Val(txtBushingWidth.Text) / 0.125)
                txtBushingWidth.Text = dblBushingWidth * 0.125
                MessageBox.Show("Value rounded to 1/8 multiple", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadThreadSize()
        Try
            cmbThreadSize.DataSource = Nothing
            If cmbBaseEndConfiguration.Text = "Threaded End" Then
                Dim oThreadSizeDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetThreadSizeValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PullForce)
                If Not IsNothing(oThreadSizeDataTable) Then
                    cmbThreadSize.DataSource = oThreadSizeDataTable
                    cmbThreadSize.ValueMember = "ThreadValue"
                    cmbThreadSize.DisplayMember = "ThreadDiscription"
                    cmbThreadSize.SelectedIndex = 0
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    'TODO: ANUP 02-05-2010 01.53pm 
    Private Sub DesignTypeValidation()
        cmbDesignType.Enabled = True
        cmbDesignType.Items.Clear()
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked = True Then

            '07_12_2011   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbRephasing.Text = "Rephasing at Extension" Then
                cmbDesignType.Items.Add("Conventional")
                cmbDesignType.Items.Add("WR Cylinder")
            Else
                cmbDesignType.Items.Add("Conventional")
            End If
            'cmbDesignType.Items.Add("Conventional")
            'cmbDesignType.Items.Add("WR Cylinder")
            'TILL  HERE

            cmbDesignType.Enabled = True
        Else
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CylinderHeadDesign = "Threaded" Then
                cmbDesignType.Items.Add("Conventional")
                cmbDesignType.Enabled = False
            Else
                cmbDesignType.Items.Add("Conventional")
                cmbDesignType.Items.Add("WR Cylinder")
            End If
        End If
        'anup 27-12-2010 till here
        cmbDesignType.BackColor = Color.Empty
        cmbDesignType.SelectedIndex = 0
    End Sub
    '*************

    'TODO: ANUP 03-05-2010 10.27am 
    Private Sub BaseEndConfigurationValidation()
        cmbBaseEndConfiguration.Items.Clear()
        If cmbDesignType.Text = "Conventional" Or ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then     '22_06_2010    RAGAVA
            cmbBaseEndConfiguration.Items.Add("Plate Clevis")
            cmbBaseEndConfiguration.Items.Add("Cross Tube")
            cmbBaseEndConfiguration.Items.Add("BH") 'MANJULA 14-02-12 ADDED 
            cmbBaseEndConfiguration.Items.Add("Single Lug")
            cmbBaseEndConfiguration.Items.Add("Double Lug")
            cmbBaseEndConfiguration.Items.Add("Base Plug")
            cmbBaseEndConfiguration.Items.Add("Threaded End")
            'A0308: ANUP 09-08-2010 02.15pm
            cmbBaseEndConfiguration.Items.Add("Import")
        Else
            cmbBaseEndConfiguration.Items.Add("Plate Clevis")
            cmbBaseEndConfiguration.Items.Add("Cross Tube")
            cmbBaseEndConfiguration.Items.Add("BH") 'MANJULA ADDED
            cmbBaseEndConfiguration.Items.Add("Single Lug")
            cmbBaseEndConfiguration.Items.Add("Double Lug")
            'A0308: ANUP 09-08-2010 02.15pm
            cmbBaseEndConfiguration.Items.Add("Import")
        End If
        cmbBaseEndConfiguration.SelectedIndex = 0
    End Sub
    '*************

    'TODO: ANUP 18-06-2010 10.28am
    Private Sub BushingWidth_LugThickness_validation()
        txtBushingWidth.Clear()
        If cmbBaseEndConfiguration.Text = "Double Lug" AndAlso Not cmbBushingQuantity.Text = 0 Then
            txtBushingWidth.Text = txtLugThickness.Text
            txtBushingWidth.Enabled = False
        End If
    End Sub
    '****************

    Private Sub TempVariables_DefaultValues()
        _dblTempBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
        _dblTempWorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure
        _strTempClass = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass
        _strTempCylinderHeadDesign = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CylinderHeadDesign
    End Sub
#End Region

#Region "Events"

    Private Sub cmbBaseEndPort_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBaseEndPort.SelectedIndexChanged
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = cmbBaseEndPort.Text
        If Not cmbBaseEndPort.Text = "" Then

            cmbPistonLocation.Items.Clear()
            If cmbBaseEndPort.Text = "Port In Tube" Then
                'TODO: Sandeep 04.01pm 
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion = ""
                '*********
                cmbPortInsertion.Items.Clear()
                cmbPortInsertion.Enabled = False
                cmbPortInsertion.BackColor = Color.Empty
                ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube"

                'Piston Location Code Added by Sandeep on 04-01-10
                cmbPistonLocation.Items.Add("OutSide")
                cmbPistonLocation.SelectedIndex = 0
                cmbPistonLocation.Enabled = False
            ElseIf cmbBaseEndPort.Text = "Port Integral" Then
                ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral"
                If cmbDesignType.Text = "Conventional" Then
                    cmbPortInsertion.Items.Clear()
                    cmbPortInsertion.Enabled = False
                    cmbPortInsertion.BackColor = Color.Empty
                    cmbPortInsertion.Items.Add("Flushed")
                    cmbPortInsertion.Items.Add("Raised")          '22_06_2010   RAGAVA
                    cmbPortInsertion.SelectedIndex = 0
                    'ElseIf cmbDesignType.Text = "New" Then
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then       '31_05_2010    RAGAVA
                    'cmbPortInsertion.Enabled = False
                    'cmbPortInsertion.BackColor = Color.Empty
                    'cmbPortInsertion.Items.Add("Raised")
                    'cmbPortInsertion.Items.Add("Flushed")         '22_06_2010   RAGAVA
                    'cmbPortInsertion.SelectedIndex = 0
                End If

                'Piston Location Code Added by Sandeep on 04-01-10
                cmbPistonLocation.Items.Add("InSide")
                cmbPistonLocation.SelectedIndex = 0
                cmbPistonLocation.Enabled = False
            End If
        End If
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = cmbPistonLocation.Text
    End Sub

    Private Sub frmTubeDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        TempVariables_DefaultValues()
        DesignTypeValidation() 'TODO: ANUP 02-05-2010 01.53pm 
        DefaultSettings()
        PopulateWallThicknessListView()
        ObjClsWeldedCylinderFunctionalClass.AddColors(Me)
        Try
            '27_02_2012   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.ChkASAE.Checked = True Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 3 Then
                    cmbDesignType.Text = "WR Cylinder"
                Else
                    cmbDesignType.Text = "Conventional"
                End If
                cmbDesignType.Enabled = False
                cmbBaseEndConfiguration.Text = "Double Lug"
                cmbBaseEndConfiguration.Enabled = False
                txtLugGap.Text = "1.125"
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap = 1.125        '30_05_2012   RAGAVA
                txtLugGap.Enabled = False
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = 4.75 Then
                    cmbPinHoleSize.Text = "1.265"
                Else
                    cmbPinHoleSize.Text = "1.015"
                End If
                txtPinHoleSize.Enabled = False
            Else
                cmbDesignType.Enabled = True
                txtPinHoleSize.Clear()
                txtPinHoleSize.Enabled = True
                txtLugGap.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap = 0        '30_05_2012   RAGAVA
                txtLugGap.Enabled = True
                cmbBaseEndConfiguration.Enabled = True
            End If
            'Till  Here
        Catch ex As Exception

        End Try
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.New_Revision = "Revision'" Then
            Dim _oPopulating As PopulatingBackClass = PopulatingBackClass.GetPopulatingObject()
            _oPopulating.SetDataToForm(Me)
        End If
    End Sub


    'Private Sub txtBushingWidth_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBushingWidth.Leave

    '    'If txtBushingWidth.Text <> "" Then
    '    '    If (Val(txtBushingWidth.Text) Mod 0.125) <> 0 Then
    '    '        Dim dblBushingWidth As Double = Math.Ceiling(Val(txtBushingWidth.Text) / 0.125)
    '    '        dblBushingWidth = dblBushingWidth * 0.125
    '    '        txtBushingWidth.Text = dblBushingWidth.ToString
    '    '    End If
    '    'End If
    '    
    'End Sub
    '********************

    'ANUP 20-09-2010 START
    'Changed textchanged to leave
    Private Sub txtBushingWidth_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBushingWidth.Leave
        'ANUP 20-09-2010 TILL HERE

        'If txtBushingWidth.Text <> "" Then
        '    If txtBushingWidth.Text <> txtBushingWidth.IFLDataTag Then
        '        If (Val(txtBushingWidth.Text) Mod 0.125) <> 0 Then
        '            Dim dblBushingWidth_BaseEnd As Double = Math.Ceiling(Val(txtBushingWidth.Text) / 0.125)
        '            dblBushingWidth_BaseEnd = dblBushingWidth_BaseEnd * 0.125
        '            txtBushingWidth.Text = dblBushingWidth_BaseEnd.ToString
        '            MessageBox.Show("Value rounded to 1/8 multiple", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        '        End If
        '        txtBushingWidth.IFLDataTag = txtBushingWidth.Text
        '    End If
        'Else
        '    txtBushingWidth.IFLDataTag = ""
        'End If
        If txtBushingWidth.Text <> "" Then
            BushingWidthValueRounding()

            If txtBushingWidth.Text < 0.5 OrElse txtBushingWidth.Text > 2 Then
                Dim strMessage As String = "Bushing width must be >= 0.5 and <= 2"
                MessageBox.Show(strMessage, "Bushing Width cannot be used", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                txtBushingWidth.Clear()
                txtBushingWidth.Focus()
            Else
                SearchForBushingsData()

                Dim dblBushingWidth As Double

                Try

                    If Not txtBushingWidth.Text = "" Then
                        If txtBushingWidth.Text <> txtBushingWidth.IFLDataTag Then

                            '''''SINGLE LUG AND DOUBLE LUG'''''
                            If cmbBaseEndConfiguration.Text = "Single Lug" OrElse cmbBaseEndConfiguration.Text = "Double Lug" Then
                                If Val(txtBushingWidth.Text) <= Val(txtLugThickness.Text) Then
                                    dblBushingWidth = txtBushingWidth.Text
                                Else
                                    If (MessageBox.Show("Bushing Width must be less than or equal to Lug Thickness", "Bushing Width is more", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)) = Windows.Forms.DialogResult.OK Then
                                        txtBushingWidth.Text = ""
                                        txtBushingWidth.Focus()
                                    End If
                                End If

                                '''''CROSS TUBE'''''
                            ElseIf cmbBaseEndConfiguration.Text = "Cross Tube" Then
                                If cmbStyle.Text = "1 Bushing" Then
                                    If Val(txtBushingWidth.Text) <= Val(txtCrossTubeWidth.Text) Then
                                        dblBushingWidth = txtBushingWidth.Text
                                    Else
                                        If (MessageBox.Show("Bushing Width must be less than or equal to CrossTube Width", "Bushing Width is more", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)) = Windows.Forms.DialogResult.OK Then
                                            txtBushingWidth.Text = ""
                                            txtBushingWidth.Focus()
                                        End If
                                    End If
                                ElseIf cmbStyle.Text = "2 Bushings Single Bore" OrElse cmbStyle.Text = "2 Bushings Individual Bores" Then
                                    If Val(txtBushingWidth.Text) <= (Val(txtCrossTubeWidth.Text) - 0.125) / 2 Then
                                        dblBushingWidth = txtBushingWidth.Text
                                    Else
                                        If (MessageBox.Show("Bushing Width must be less than or equal to (CrossTube Width - 0.125) / 2", "Bushing Width is more", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)) = Windows.Forms.DialogResult.OK Then
                                            txtBushingWidth.Text = ""
                                            txtBushingWidth.Focus()
                                        End If
                                    End If
                                End If

                                '''''BASEPLUG'''''
                            ElseIf cmbBaseEndConfiguration.Text = "Base Plug" Then

                                If cmbStyle.Text = "1 Bushing" Then
                                    If Val(txtBushingWidth.Text) <= Val(txtOutSidePlugDiameter.Text) Then
                                        dblBushingWidth = txtBushingWidth.Text
                                    Else
                                        If (MessageBox.Show("Bushing Width must be less than or equal to Base Plug Diameter", "Bushing Width is more", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)) = Windows.Forms.DialogResult.OK Then
                                            txtBushingWidth.Text = ""
                                            txtBushingWidth.Focus()
                                        End If
                                    End If
                                ElseIf cmbStyle.Text = "2 Bushings Single Bore" OrElse cmbStyle.Text = "2 Bushings Individual Bores" Then
                                    If Val(txtBushingWidth.Text) <= (Val(txtOutSidePlugDiameter.Text) - 0.125) / 2 Then
                                        dblBushingWidth = txtBushingWidth.Text
                                    Else
                                        If (MessageBox.Show("Bushing Width must be less than or equal to (Base Plug Diameter - 0.125) / 2", "Bushing Width is more", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)) = Windows.Forms.DialogResult.OK Then
                                            txtBushingWidth.Text = ""
                                            txtBushingWidth.Focus()
                                        End If
                                    End If
                                End If
                            End If
                            txtBushingWidth.IFLDataTag = dblBushingWidth
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth = dblBushingWidth
                        End If
                    Else
                        txtBushingWidth.IFLDataTag = Nothing
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth = 0
                    End If
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub


    Private Sub cmbBaseEndConfiguration_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBaseEndConfiguration.SelectedIndexChanged
        If cmbBaseEndConfiguration.Text <> "" Then

            LoadThreadSize()

            '01_04_2010   RAGAVA
            If cmbBaseEndConfiguration.Text = "Base Plug" Or cmbBaseEndConfiguration.Text = "Threaded End" Then
                If cmbBaseEndConfiguration.Text = "Base Plug" Then
                    txtOutSidePlugDiameter.Text = GetBasePlugOuterDia()
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = -0.125
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2 = -0.125  '06_06_2012   RAGAVA
            End If
            '01_04_2010   RAGAVA   TILL  HERE

            '16_08_2010   RAGAVA
            If cmbBaseEndConfiguration.Text <> "Plate Clevis" AndAlso Trim(cmbBaseEndConfiguration.Text) <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.clevisplatePartFilePath = ""
            End If
            If cmbBaseEndConfiguration.Text <> "Import" AndAlso Trim(cmbBaseEndConfiguration.Text) <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportBaseEndPartPath = ""
            End If
            'Till   Here

            If cmbBaseEndConfiguration.Text <> cmbBaseEndConfiguration.IFLDataTag Then
                cmbBaseEndConfiguration.IFLDataTag = cmbBaseEndConfiguration.Text

                ObjClsWeldedCylinderFunctionalClass.NewSLCastingPartCopied = False
                ObjClsWeldedCylinderFunctionalClass.NewCastingPartCopied = False
                ObjClsWeldedCylinderFunctionalClass.NewUlugPartCopied = False

                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = cmbBaseEndConfiguration.Text

                ControlsEnabling1()

                'cmbBushingQuantity.Items.Clear()
                'cmbBushingQuantity.IFLDataTag = Nothing




                'If cmbDesignType.Text = "Conventional" Then
                '    If cmbBaseEndConfiguration.Text = "Plate Clevis" Then
                '        cmbBaseEndPort.Items.Clear()
                '        cmbBaseEndPort.Items.Add("Port In Tube")
                '        cmbBaseEndPort.Enabled = False
                '        cmbBaseEndPort.BackColor = Color.Empty
                '        cmbBaseEndPort.SelectedIndex = 0
                '    Else
                '        cmbBaseEndPort.Items.Clear()
                '        cmbBaseEndPort.Items.Add("Port In Tube")
                '        cmbBaseEndPort.Items.Add("Port Integral")
                '        cmbBaseEndPort.SelectedIndex = 0
                '        cmbBaseEndPort.Enabled = True
                '    End If
                'End If


                'txtLugGap.Text = ""
                'txtLugGap.Enabled = False
                'txtLugGap.BackColor = Color.Empty
                'If cmbBaseEndConfiguration.Text = "Threaded End" OrElse cmbBaseEndConfiguration.Text = "Plate Clevis" _
                'OrElse cmbBaseEndConfiguration.Text = "Import Special" Then
                '    cmbBushingQuantity.Items.Add(0)
                '    cmbBushingQuantity.SelectedIndex = 0
                '    cmbBushingQuantity.Enabled = False
                '    cmbBushingQuantity.BackColor = Color.Empty
                'Else
                '    If cmbBaseEndConfiguration.Text = "Double Lug" Then
                '        ' txtLugGap.Enabled = True
                '        cmbBushingQuantity.Items.Add(0)
                '        cmbBushingQuantity.Items.Add(2)
                '    Else
                '        cmbBushingQuantity.Items.Add(0)
                '        cmbBushingQuantity.Items.Add(1)
                '        cmbBushingQuantity.Items.Add(2)
                '    End If
                '    cmbBushingQuantity.Enabled = True
                '    cmbBushingQuantity.SelectedIndex = 0
                'End If


                ' GreaseZercs()
            End If

            '16-02-10
            'If cmbBaseEndConfiguration.Text = "Cross Tube" Then
            '    txtSwingClearance.Enabled = False
            '    txtSwingClearance.Text = ""
            '    txtSwingClearance.BackColor = Color.Empty

            '    cmbPins.Items.Clear()
            '    cmbPins.Items.Add("No")
            '    cmbPins.SelectedIndex = 0
            '    cmbPins.Enabled = False
            '    cmbPins.BackColor = Color.Empty
            'Else
            '    txtSwingClearance.Enabled = True

            '    cmbPins.Items.Clear()
            '    cmbPins.Items.Add("Yes")
            '    cmbPins.Items.Add("No")
            '    cmbPins.SelectedIndex = 0
            '    cmbPins.Enabled = True
            'End If

            ObjClsWeldedCylinderFunctionalClass.AddColors(Me)
        Else
            cmbBaseEndConfiguration.IFLDataTag = Nothing
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = ""
        End If
        '02_03_2010   RAGAVA
        If Trim(cmbBaseEndConfiguration.SelectedItem) = "Double Lug" Then
            'ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "U LUG"       '30_05_2012    RAGAVA
        End If

        If Trim(cmbBaseEndConfiguration.SelectedItem) = "BH" Then
            'ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "U LUG"        '30_05_2012    RAGAVA
        End If
        'Till    Here
        '8_3_2010 Aruna
        'If Trim(cmbBaseEndConfiguration.SelectedItem) = "Single Lug" Then
        '    cmbLugInTubeDiameter.Enabled = True
        'Else
        '    cmbLugInTubeDiameter.Enabled = False
        'End If

        'TODO: ANUP 19-04-2010 06.17


    End Sub

    Private Sub cmbDesignType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDesignType.SelectedIndexChanged
        BaseEndConfigurationValidation()   'TODO: ANUP 03-05-2010 10.27am 
        cmbBaseEndPort.Items.Clear()
        cmbBaseEndPort.IFLDataTag = Nothing
        cmbWeldType.Items.Clear()
        If cmbDesignType.Text = "Conventional" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = Trim(cmbDesignType.Text)        '31_05_2010   RAGAVA
            If cmbBaseEndConfiguration.Text = "Plate Clevis" Then
                cmbBaseEndPort.Enabled = False
                cmbBaseEndPort.BackColor = Color.Empty
                cmbBaseEndPort.Items.Add("Port In Tube")
                cmbBaseEndPort.SelectedIndex = 0
            Else
                cmbBaseEndPort.Items.Add("Port In Tube")
                cmbBaseEndPort.Items.Add("Port Integral")
                cmbBaseEndPort.SelectedIndex = 0
                cmbBaseEndPort.Enabled = True
            End If

            'Added by Sandeep on 04-01-10
            cmbWeldType.Items.Add("Groove")
            cmbWeldType.SelectedIndex = 0
            cmbWeldType.Enabled = False

        ElseIf cmbDesignType.Text = "WR Cylinder" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New"
            cmbBaseEndPort.Enabled = False
            cmbBaseEndPort.BackColor = Color.Empty
            cmbBaseEndPort.Items.Add("Port Integral")
            cmbBaseEndPort.SelectedIndex = 0

            'Added by Sandeep on 04-01-10
            cmbWeldType.Items.Add("Groove")
            cmbWeldType.Items.Add("Fillet")
            cmbWeldType.SelectedIndex = 1
            'cmbWeldType.Enabled = False
            cmbWeldType.Enabled = True           '22_06_2010    RAGAVA
        End If
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = cmbWeldType.Text
        PopulateWallThicknessListView()
    End Sub

    Private Sub lvwWallThickness_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwWallThickness.SelectedIndexChanged
        Try
            _dblTubeOD = 0
            _dblWallThicknessofTube = 0
            _strTubeMaterial = ""
            _strTubeMaterialCode = ""

            If lvwWallThickness.SelectedIndices.Count > 0 Then

                'TODO: ANUP 24-06-2010 
                Dim _strStatus As String = lvwWallThickness.SelectedItems(0).SubItems(2).Text
                If _strStatus = "N" OrElse _strStatus = "NR" Then
                    '    MessageBox.Show("Tube Material is not available", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)   'anup 08-03-2011
                    ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
                Else
                    ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
                    '*************

                    Dim oWallThicknessListViewItem As ListViewItem = lvwWallThickness.SelectedItems(0)
                    '5_3_2010 Aruna
                    If cmbBaseEndPort.Text = "Port Integral" Then
                        Dim _strQuery As String = ""
                        Dim strMsg As String = ""
                        Dim oSelectedPortIntegralDataRow As DataRow
                        _strQuery = "Select * from welded.portIntegralDetails where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and TubeWallThickness= " + oWallThicknessListViewItem.Text
                        oSelectedPortIntegralDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
                        If IsNothing(oSelectedPortIntegralDataRow) Then
                            strMsg = "Data is not available for the selected wall thickness = " + oWallThicknessListViewItem.Text + " In Port Integral"
                            MessageBox.Show(strMsg, "Data is Not Available", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.DefaultDesktopOnly)
                            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
                        Else
                            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
                        End If
                    Else
                        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
                    End If

                    Dim oTube_ClevisPlateDetailsDatarow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                    GetTubeDetails(oWallThicknessListViewItem.SubItems(WallThicknessListView.IFLID).Text)
                    If Not IsNothing(oTube_ClevisPlateDetailsDatarow) Then
                        If Not IsDBNull(oTube_ClevisPlateDetailsDatarow("TubeOD")) Then
                            _dblTubeOD = oTube_ClevisPlateDetailsDatarow("TubeOD")
                        End If
                        If Not IsDBNull(oTube_ClevisPlateDetailsDatarow("TubeWallThickness")) Then
                            _dblWallThicknessofTube = oTube_ClevisPlateDetailsDatarow("TubeWallThickness")
                        End If
                        If Not IsDBNull(oTube_ClevisPlateDetailsDatarow("TubeMaterial")) Then
                            _strTubeMaterial = oTube_ClevisPlateDetailsDatarow("TubeMaterial")
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.Skived_Honed_Tube = _strTubeMaterial       '23_09_2010   RAGAVA
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.Skived_Honed_Rod = _strTubeMaterial       '23_09_2010   RAGAVA
                        End If
                        If Not IsDBNull(oTube_ClevisPlateDetailsDatarow("TubeCode")) Then
                            _strTubeMaterialCode = oTube_ClevisPlateDetailsDatarow("TubeCode")
                        End If
                    End If
                End If
            End If

            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("TubeOD", _dblTubeOD)
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Tube Wall Thickness", _dblWallThicknessofTube)
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Tube Material", _strTubeMaterial)

            'ANUP 06-10-2010 START 
            '         ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Tube Code", _strTubeMaterialCode)
            Dim strPartCode As String = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(_strTubeMaterialCode)
            If Not String.IsNullOrEmpty(strPartCode) Then
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Tube Code", strPartCode)
                _strTubeMaterialCode_Purchase = strPartCode
            Else
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Tube Code", _strTubeMaterialCode)
                _strTubeMaterialCode_Purchase = _strTubeMaterialCode
            End If
            'ANUP 06-10-2010 TILL HERE

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD = _dblTubeOD
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness = _dblWallThicknessofTube
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeMaterial = _strTubeMaterial
            TubeMaterialCode = _strTubeMaterialCode       '29_03_2010   RAGAVA
            If cmbBaseEndConfiguration.Text = "Base Plug" Then 'anup 28-02-2011
                txtOutSidePlugDiameter.Text = GetBasePlugOuterDia()
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in lvwWallThickness_SelectedIndexChanged of frmTubeDetails " + ex.Message)
        End Try
    End Sub

    'ONSITE: 01-06-2010
    Private Function GetBasePlugOuterDia() As Double
        Dim OuterDia As Double
        OuterDia = (2 * _dblWallThicknessofTube) + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
        Return OuterDia
    End Function

    'MANJULA 15-02-12
    Private Sub setBHCmbPinHoleValues(ByVal pinHolesList As Hashtable)
        cmbPinHoleSize.DataSource = Nothing
        Dim list As New ArrayList

        For Each pinHoleSize As Double In pinHolesList.Keys
            list.Add(pinHoleSize)
        Next
        list.Sort()

        For Each pinSize As Double In list
            cmbPinHoleSize.Items.Add(pinSize.ToString)
        Next

        cmbPinHoleSize.SelectedIndex = 1

    End Sub

    Private Sub cmbPinHoleSizeType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPinHoleSizeType.SelectedIndexChanged
        If cmbPinHoleSizeType.Text <> "" Then
            If cmbPinHoleSizeType.Text <> cmbPinHoleSizeType.IFLDataTag Then
                cmbPinHoleSizeType.IFLDataTag = cmbPinHoleSizeType.Text
                txtToleranceLowerLimit.Text = ""
                txtToleranceUpperLimit.Text = ""
                cmbPinHoleSize.IFLDataTag = Nothing
                If cmbPinHoleSizeType.Text = "Standard" Then

                    If cmbBaseEndConfiguration.Text = "BH" Then        'MANJULA 15-02-12 ADDED C
                        setBHCmbPinHoleValues(pinHolesAndThicknessList)
                    Else
                        CmbPinHoleSizeFunctionality(cmbPinHoleSize)
                    End If

                    txtPinHoleSize.Visible = False
                    txtToleranceLowerLimit.Enabled = False
                    txtToleranceLowerLimit.BackColor = Color.Empty
                    txtToleranceUpperLimit.Enabled = False
                    txtToleranceUpperLimit.BackColor = Color.Empty
                    lblPinHoleSize.Text = "Nominal Pin Size"
                ElseIf cmbPinHoleSizeType.Text = "Custom" Then
                    cmbPinHoleSize.Visible = False
                    txtPinHoleSize.Visible = True
                    txtToleranceLowerLimit.Enabled = True
                    txtToleranceUpperLimit.Enabled = True
                    lblPinHoleSize.Text = "Pin Hole Diameter"
                End If
            End If
        Else
            cmbPinHoleSizeType.IFLDataTag = Nothing
            cmbPinHoleSize.IFLDataTag = Nothing
        End If
    End Sub

    Private Sub cmbGreaseZercs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGreaseZercs.SelectedIndexChanged
        If cmbGreaseZercs.Text <> "" Then
            If cmbGreaseZercs.Text <> cmbGreaseZercs.IFLDataTag Then
                cmbGreaseZercs.IFLDataTag = cmbGreaseZercs.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = Val(cmbGreaseZercs.Text)
                If cmbGreaseZercs.Text = "0" Then
                    txtAngleOfGreaseZercs1.Text = ""
                    txtAngleOfGreaseZercs2.Text = ""
                    txtAngleOfGreaseZercs1.Enabled = False
                    txtAngleOfGreaseZercs1.BackColor = Color.Empty
                    txtAngleOfGreaseZercs2.Enabled = False
                    txtAngleOfGreaseZercs2.BackColor = Color.Empty
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1 = 0
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2 = 0
                ElseIf cmbGreaseZercs.Text = "1" Then
                    txtAngleOfGreaseZercs2.Text = ""
                    '06_09_2010  RAGAVA
                    If cmbBaseEndConfiguration.Text = "Base Plug" Then
                        txtAngleOfGreaseZercs1.Enabled = True
                        txtAngleOfGreaseZercs1.Text = "90"
                    Else
                        txtAngleOfGreaseZercs1.Enabled = True
                        txtAngleOfGreaseZercs1.Clear()
                    End If
                    'Till   Here

                    txtAngleOfGreaseZercs2.Enabled = False
                    txtAngleOfGreaseZercs2.BackColor = Color.Empty
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1 = Val(txtAngleOfGreaseZercs1.Text)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2 = 0
                ElseIf cmbGreaseZercs.Text = "2" Then
                    txtAngleOfGreaseZercs1.Enabled = True
                    txtAngleOfGreaseZercs2.Enabled = True
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1 = Val(txtAngleOfGreaseZercs1.Text)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2 = Val(txtAngleOfGreaseZercs2.Text)
                End If
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs = 0
            cmbGreaseZercs.IFLDataTag = Nothing
        End If
    End Sub

    'Private Sub txtAngleOfGreaseZercs1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAngleOfGreaseZercs1.Leave, txtAngleOfGreaseZercs2.Leave
    '    If sender.text <> "" Then
    '        Dim dblAngle As Double = Val(sender.text)
    '        dblAngle = Math.Ceiling(dblAngle / 5)
    '        dblAngle = dblAngle * 5
    '        sender.text = dblAngle.ToString
    '    End If
    'End Sub

    'TODO: ANUP 27-02-2010 12.41
    Private Sub txtAngleOfGreaseZercs2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtAngleOfGreaseZercs2.Leave, txtAngleOfGreaseZercs1.Leave

        '26_07_2011  RAGAVA
        If sender.name = "txtAngleOfGreaseZercs1" AndAlso cmbBaseEndConfiguration.Text = "Base Plug" Then
            If txtAngleOfGreaseZercs1.Text <> "N/A" Then
                If Not (txtAngleOfGreaseZercs1.Text = "0" Or txtAngleOfGreaseZercs1.Text = "90" Or txtAngleOfGreaseZercs1.Text = "-90") Then
                    MsgBox("Please enter 0 or 90 as input")
                    txtAngleOfGreaseZercs1.Clear()
                    Exit Sub
                End If
            End If
        End If
        'Till  Here

        'anup 01-09-2010 
        If Not String.IsNullOrEmpty(sender.text) Then
            If sender.text > 120 AndAlso sender.text < 240 Then
                MessageBox.Show("Grease Zerc Angle must be from 0 to 120 or 240 to 360", "Invalid Grease Zerc Angle", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                sender.clear()
                sender.focus()
            ElseIf sender.text > 360 Then
                MessageBox.Show("Grease Zerc Angle must be from 0 to 120 or 240 to 360", "Invalid Grease Zerc Angle", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                sender.clear()
                sender.focus()
            Else
                If cmbGreaseZercs.Text = "2" Then
                    If txtAngleOfGreaseZercs2.Text <> "" AndAlso txtAngleOfGreaseZercs1.Text <> "" Then
                        If sender.Text <> sender.IFLDataTag Then
                            sender.IFLDataTag = sender.Text
                            If Val(txtAngleOfGreaseZercs2.Text) = -Val(txtAngleOfGreaseZercs1.Text) Then
                                MessageBox.Show("Difference between Grease Zercs Angle should not be same", "Change Grease Zercs Angle value", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                sender.IFLDataTag = Nothing
                            Else

                                If Math.Abs(Val(txtAngleOfGreaseZercs2.Text) + Val(txtAngleOfGreaseZercs1.Text)) < 15 Then
                                    MessageBox.Show("Difference between Grease Zercs Angle should be minimum 15", "Change Grease Zercs Angle value", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    sender.IFLDataTag = Nothing
                                End If
                            End If
                        End If
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1 = Val(txtAngleOfGreaseZercs1.Text)
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2 = Val(txtAngleOfGreaseZercs2.Text)
                    Else
                        sender.IFLDataTag = Nothing
                    End If
                ElseIf cmbGreaseZercs.Text = "1" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1 = Val(txtAngleOfGreaseZercs1.Text)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2 = 0
                End If
            End If
        End If
    End Sub

    '#########################

    Private Sub cmbPortInsertion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPortInsertion.SelectedIndexChanged, cmbPortInsertion.SelectedValueChanged     '22_06_2010   RAGAVA
        If cmbPortInsertion.Text <> "" Then
            'If cmbPortInsertion.Text <> cmbPortInsertion.IFLDataTag Then         '27_04_2010    RAGAVA
            cmbPortInsertion.IFLDataTag = cmbPortInsertion.Text
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion = cmbPortInsertion.Text
            'End If
        Else
            cmbPortInsertion.IFLDataTag = Nothing
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion = ""
        End If
    End Sub

    Private Sub txtToleranceUpperLimit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtToleranceUpperLimit.Leave, txtToleranceLowerLimit.Leave
        Try
            If txtToleranceUpperLimit.Text <> "" AndAlso txtToleranceLowerLimit.Text <> "" Then
                Dim dblTotalTolerance As Double = Val(txtToleranceLowerLimit.Text) + Val(txtToleranceUpperLimit.Text)

                'ANUP 10-10-2010 START CHANGED 0.004 to 0.002
                If dblTotalTolerance < 0.002 Then
                    'ANUP 10-10-2010 TILL HERE

                    MessageBox.Show("Tolerance is Unachievable", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf dblTotalTolerance > 0.025 Then
                    If MessageBox.Show("Recommend using standard Tolerance, Do you want to proceed with Non-Standard Tolerances", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                        Dim oPinHoleDetailsDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPinHoleDetails(cmbPinHoleSize.Text)
                        If Not IsNothing(oPinHoleDetailsDataRow) Then
                            txtToleranceLowerLimit.Text = oPinHoleDetailsDataRow("ToleranceLowerLimit")
                            txtToleranceUpperLimit.Text = oPinHoleDetailsDataRow("ToleranceUpperLimit")
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit = oPinHoleDetailsDataRow("ToleranceUpperLimit")
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit = oPinHoleDetailsDataRow("ToleranceUpperLimit")
                        End If
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit = txtToleranceUpperLimit.Text
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit = txtToleranceLowerLimit.Text
                    End If
                End If
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in txtToleranceUpperLimit_Leave of frmTubeDetails " + ex.Message)
        End Try
    End Sub

    Private Sub txtCrossTubeWidth_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCrossTubeWidth.Leave, txtLugThickness.Leave
        Dim oTextBox As TextBox = sender
        If oTextBox.Text <> "" Then
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.New_Revision.IndexOf("New") <> -1 Then         '30_05_2011  RAGAVA
                If (Val(oTextBox.Text) Mod 0.125) <> 0 Then
                    Dim dblTubeWidth As Double = Math.Round(Val(oTextBox.Text) / 0.125)
                    dblTubeWidth = dblTubeWidth * 0.125
                    oTextBox.Text = dblTubeWidth.ToString
                    MessageBox.Show("Value rounded to 1/8 multiple", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                End If
            End If
            If oTextBox.Name = "txtCrossTubeWidth" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth = Val(oTextBox.Text)
                If Val(txtCrossTubeWidth.Text) > 2 Then
                    cmbBushingQuantity.Items.Clear()
                    cmbBushingQuantity.Items.Add(0)
                    cmbBushingQuantity.Items.Add(2)
                Else
                    cmbBushingQuantity.Items.Clear()
                    cmbBushingQuantity.Items.Add(0)
                    cmbBushingQuantity.Items.Add(1)
                    cmbBushingQuantity.Items.Add(2)
                End If
                txtCrossTubeWidth.Enabled = True
                cmbBushingQuantity.SelectedIndex = 0
            ElseIf oTextBox.Name = "txtLugThickness" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(oTextBox.Text)

                'TODO: ANUP 18-06-2010 10.28am
                BushingWidth_LugThickness_validation()
                '******************
            End If
        End If
    End Sub

    Private Sub cmbBushingQuantity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBushingQuantity.SelectedIndexChanged
        BushingFunctionality()
    End Sub

    Private Sub cmbBushingPinHoleSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBushingPinHoleSize.SelectedIndexChanged
        Try
            If cmbBushingPinHoleSize.Text <> "" AndAlso cmbBushingPinHoleSize.Text <> "System.Data.DataRowView" Then
                ' If cmbBushingPinHoleSize.Text <> cmbBushingPinHoleSize.IFLDataTag Then
                cmbBushingPinHoleSize.IFLDataTag = cmbBushingPinHoleSize.Text
                Dim oPinHoleDetailsDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPinHoleDetails(cmbBushingPinHoleSize.Text)
                ObjClsWeldedCylinderFunctionalClass.PinHoleSize_Source = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.BushingPinHole
                If Not IsNothing(oPinHoleDetailsDataRow) Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize = oPinHoleDetailsDataRow("PinHoleDimension")
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize = 0
                End If
                'End If
            Else
                cmbBushingPinHoleSize.IFLDataTag = Nothing
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in cmbBushingPinHoleSize_SelectedIndexChanged of frmTubeDetails " + ex.Message)
        End Try
        'TODO: ANUP 20-04-2010 12.24pm
        SearchForBushingsData()
    End Sub



    Private Sub txtSwingClearance_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSwingClearance.TextChanged
        If txtSwingClearance.Text <> "" Then
            If txtSwingClearance.Text <> txtSwingClearance.IFLDataTag Then
                txtSwingClearance.IFLDataTag = txtSwingClearance.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance = Val(txtSwingClearance.Text)
            End If
        Else
            txtSwingClearance.IFLDataTag = Nothing
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance = 0
        End If
    End Sub



    'Private Sub txtBushingWidth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBushingWidth.TextChanged
    '    If txtBushingWidth.Text <> "" Then
    '        If txtBushingWidth.Text <> txtBushingWidth.IFLDataTag Then
    '            txtBushingWidth.IFLDataTag = txtBushingWidth.Text
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth = Val(txtBushingWidth.Text)
    '        End If
    '    Else
    '        txtBushingWidth.IFLDataTag = Nothing
    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth = 0
    '    End If
    'End Sub

    'Private Sub txtLugThickness_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLugThickness.TextChanged
    '    If txtLugThickness.Text <> "" Then
    '        If txtLugThickness.Text <> txtLugThickness.IFLDataTag Then
    '            txtLugThickness.IFLDataTag = txtLugThickness.Text
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness.Text)

    '            If (Val(txtLugThickness.Text) Mod 0.125) <> 0 Then
    '                Dim dblLugThickness As Double = Math.Ceiling(Val(txtLugThickness.Text) / 0.125)
    '                dblLugThickness = dblLugThickness * 0.125
    '                txtLugThickness.Text = dblLugThickness.ToString
    '                MessageBox.Show("Value rounded to 1/8 multiple", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
    '            End If

    '        End If
    '    Else
    '        txtBushingWidth.IFLDataTag = Nothing
    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = 0
    '    End If
    'End Sub

    'Private Sub txtAngleOfGreaseZercs1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAngleOfGreaseZercs1.TextChanged, txtAngleOfGreaseZercs2.TextChanged
    '    If sender.Text <> "" AndAlso sender.Text <> "System.Data.DataRowView" Then
    '        If sender.Text <> sender.IFLDataTag Then
    '            sender.IFLDataTag = sender.Text
    '            If sender.name = "txtAngleOfGreaseZercs1" Then
    '                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1 = Val(txtAngleOfGreaseZercs1.Text)
    '            Else
    '                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2 = Val(txtAngleOfGreaseZercs2.Text)
    '            End If
    '        End If
    '    Else
    '        sender.IFLDataTag = Nothing
    '        If sender.name = "txtAngleOfGreaseZercs1" Then
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1 = 0
    '        Else
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2 = 0
    '        End If
    '    End If
    'End Sub

    Private Sub cmbLugInTubeDiameter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If cmbLugInTubeDiameter.Text <> "" Then
        '    If cmbLugInTubeDiameter.Text <> cmbLugInTubeDiameter.IFLDataTag Then
        '        cmbLugInTubeDiameter.IFLDataTag = cmbLugInTubeDiameter.Text
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinWithInTubeDiameter = cmbLugInTubeDiameter.Text
        '    End If
        'Else
        '    cmbLugInTubeDiameter.IFLDataTag = Nothing
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinWithInTubeDiameter = ""
        'End If
    End Sub

    Private Sub txtOutSidePlugDiameter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOutSidePlugDiameter.TextChanged
        If txtOutSidePlugDiameter.Text <> "" Then
            If txtOutSidePlugDiameter.Text <> txtOutSidePlugDiameter.IFLDataTag Then
                txtOutSidePlugDiameter.IFLDataTag = txtOutSidePlugDiameter.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter = Val(txtOutSidePlugDiameter.Text)
            End If
        Else
            txtOutSidePlugDiameter.IFLDataTag = 0
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter = 0
        End If
    End Sub

    Private Sub txtMilledFlatWidth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMilledFlatWidth.TextChanged
        If txtMilledFlatWidth.Text <> "" Then
            If txtMilledFlatWidth.Text <> txtMilledFlatWidth.IFLDataTag Then
                txtMilledFlatWidth.IFLDataTag = txtMilledFlatWidth.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatWidth = Val(txtMilledFlatWidth.Text)
            End If
        Else
            txtMilledFlatWidth.IFLDataTag = 0
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatWidth = 0
        End If
    End Sub

    Private Sub rdbMilledFlatYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbMilledFlatYes.CheckedChanged, rdbMilledFlatNo.CheckedChanged
        txtMilledFlatWidth.Text = ""
        If rdbMilledFlatYes.Checked Then
            txtMilledFlatWidth.Enabled = True
            txtMilledFlatLength.Enabled = True
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlat = "Yes"
        Else
            txtMilledFlatWidth.Enabled = False
            txtMilledFlatWidth.BackColor = Color.Empty
            txtMilledFlatLength.Enabled = False
            txtMilledFlatLength.BackColor = Color.Empty
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlat = "No"
        End If
    End Sub

    Private Sub txtOffSet_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOffSet.Leave
        If txtOffSet.Text <> "" Then
            If txtOffSet.Text <> txtOffSet.IFLDataTag Then
                txtOffSet.IFLDataTag = txtOffSet.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OffSet = Val(txtOffSet.Text)
            End If
            If Val(txtOffSet.Text) > 0 Then
                Dim strMessage As String = "Cross Tube Fabrication is not possible because Offset  > 0"
                MessageBox.Show(strMessage, "Fabrication is not poassible", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            End If
        Else
            txtOffSet.IFLDataTag = 0
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OffSet = 0
        End If
    End Sub

    '04_12_2009   RAGAVA
    Private Sub rdbMilledFlatNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbMilledFlatNo.CheckedChanged
        If rdbMilledFlatNo.Checked = True Then
            txtMilledFlatLength.Clear()
            txtMilledFlatWidth.Clear()

            'TODO: ANUP 28-04-2010 10.23am
            'cmbBushingQuantity.SelectedIndex = 0
            'grbBushingDetails.Enabled = False
            '*****************
        End If
    End Sub

    ''04_12_2009   RAGAVA
    'Private Sub txtBasePlugDiameter_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If txtBasePlugDiameter.Text <> "" Then
    '        If txtBasePlugDiameter.Text <> txtBasePlugDiameter.IFLDataTag Then
    '            txtBasePlugDiameter.IFLDataTag = txtBasePlugDiameter.Text
    ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BasePlugOD = Val(txtBasePlugDiameter.Text)
    '        End If
    '    Else
    '        txtBasePlugDiameter.IFLDataTag = 0
    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BasePlugOD = 0
    '    End If

    'End Sub

    '04_12_2009   RAGAVA
    Private Sub txtMilledFlatLength_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMilledFlatLength.TextChanged
        If txtMilledFlatLength.Text <> "" Then
            If txtMilledFlatLength.Text <> txtMilledFlatLength.IFLDataTag Then
                txtMilledFlatLength.IFLDataTag = txtMilledFlatLength.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatHeight = Val(txtMilledFlatLength.Text)
            End If
        Else
            txtMilledFlatLength.IFLDataTag = 0
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatHeight = 0
        End If
    End Sub
    'check it later
    'Private Sub txtThreadDiameter_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbThreadSize.TextChanged
    '    If cmbThreadSize.Text <> "" Then
    '        If cmbThreadSize.Text <> cmbThreadSize.IFLDataTag Then
    '            cmbThreadSize.IFLDataTag = cmbThreadSize.Text
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadDiameter = Val(cmbThreadSize.Text)
    '        End If
    '    Else
    '        cmbThreadSize.IFLDataTag = 0
    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadDiameter = 0
    '    End If
    'End Sub

    Private Sub txtThreadLength_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtThreadLength.TextChanged
        If txtThreadLength.Text <> "" Then
            If txtThreadLength.Text <> txtThreadLength.IFLDataTag Then
                txtThreadLength.IFLDataTag = txtThreadLength.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength = Val(txtThreadLength.Text)
            End If
        Else
            txtThreadLength.IFLDataTag = 0
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength = 0
        End If
    End Sub

    Private Sub cmbPinHoleSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPinHoleSize.SelectedIndexChanged, txtPinHoleSize.Leave 'ANUP 05-10-2010
        Try
            If cmbPinHoleSizeType.Text = "Standard" Then
                If cmbBaseEndConfiguration.Text = "BH" Then 'MANJULA 15-02-12 ADDED 
                    Dim isFound As Boolean = False
                    For Each pinHoleSize As Double In pinHolesAndThicknessList.Keys

                        If pinHoleSize = Val(cmbPinHoleSize.Text) Then

                            'txtLugThickness.SetValue(pinHolesAndThicknessList(pinHoleSize).ToString)
                            txtLugThickness.Text = pinHolesAndThicknessList(pinHoleSize).ToString
                            txtLugThickness.Enabled = True
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness.Text)
                            isFound = True
                            Exit For
                        End If

                    Next
                    If Not isFound Then
                        txtLugThickness.Text = "0"
                    End If

                End If

               
                If cmbPinHoleSize.Text <> "" AndAlso cmbPinHoleSize.Text <> "System.Data.DataRowView" Then
                    If cmbPinHoleSize.Text <> cmbPinHoleSize.IFLDataTag Then
                        cmbPinHoleSize.IFLDataTag = cmbPinHoleSize.Text
                        ObjClsWeldedCylinderFunctionalClass.PinHoleSize_Source = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleStandard
                        Dim oPinHoleDetailsDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPinHoleDetails(cmbPinHoleSize.Text)
                        If Not IsNothing(oPinHoleDetailsDataRow) Then

                            If Not cmbBaseEndConfiguration.Text = "Plate Clevis" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize = oPinHoleDetailsDataRow("PinHoleDimension")
                                txtToleranceLowerLimit.Text = oPinHoleDetailsDataRow("ToleranceLowerLimit")
                                txtToleranceUpperLimit.Text = oPinHoleDetailsDataRow("ToleranceUpperLimit")
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit = oPinHoleDetailsDataRow("ToleranceUpperLimit")
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit = oPinHoleDetailsDataRow("ToleranceLowerLimit")
                            Else
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize = 0.5
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit = 0
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit = 0
                            End If

                        Else
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize = 0
                            txtToleranceLowerLimit.Text = ""
                            txtToleranceUpperLimit.Text = ""
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit = 0
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit = 0
                        End If
                    End If
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize = 0
                    cmbPinHoleSize.IFLDataTag = Nothing
                    txtToleranceLowerLimit.Text = ""
                    txtToleranceUpperLimit.Text = ""
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit = 0
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit = 0
                End If
            ElseIf cmbPinHoleSizeType.Text = "Custom" Then
                If txtPinHoleSize.Text <> "" Then
                    If txtPinHoleSize.Text <> txtPinHoleSize.IFLDataTag Then
                        txtPinHoleSize.IFLDataTag = txtPinHoleSize.Text
                        ObjClsWeldedCylinderFunctionalClass.PinHoleSize_Source = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleCustom
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize = Val(txtPinHoleSize.Text)
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit = Val(txtToleranceUpperLimit.Text)
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit = Val(txtToleranceLowerLimit.Text)
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize = 0
                        txtToleranceLowerLimit.Text = ""
                        txtToleranceUpperLimit.Text = ""
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit = 0
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit = 0
                    End If
                End If
            Else
                txtPinHoleSize.IFLDataTag = Nothing
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize = 0
                txtToleranceLowerLimit.Text = ""
                txtToleranceUpperLimit.Text = ""
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit = 0
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit = 0
            End If

        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in cmbPinHoleSize_SelectedIndexChanged of frmTubeDetails " + ex.Message)
        End Try
    End Sub

    Private Sub cmbPinHole_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPinHole.SelectedIndexChanged
        If Trim(sender.text) <> "" Then

            If sender.Text = "Standard" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType = "PH"
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType = "BH"
            End If

        End If
    End Sub

    Private Sub txtLugGap_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLugGap.Leave
        If txtLugGap.Text <> "" Then
            If txtLugGap.Text <> txtLugGap.IFLDataTag Then

                'anup 18-03-2011 start 
                If (Val(txtLugGap.Text) Mod 0.0625) <> 0 Then
                    Dim dblLugGap As Double = Math.Round(Val(txtLugGap.Text) / 0.0625)
                    dblLugGap = dblLugGap * 0.0625
                    txtLugGap.Text = dblLugGap.ToString
                    MessageBox.Show("Value rounded to 1/16 multiple", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                End If

                txtLugGap.IFLDataTag = txtLugGap.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap = Val(txtLugGap.Text)

                'If (Val(txtLugGap.Text) Mod 0.0625) <> 0 Then
                '    Dim dblLugGap As Double = Math.Round(Val(txtLugGap.Text) / 0.0625)
                '    dblLugGap = dblLugGap * 0.0625
                '    txtLugGap.Text = dblLugGap.ToString
                '    MessageBox.Show("Value rounded to 1/16 multiple", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                'End If
                'anup 18-03-2011 till here
            End If
        Else
            txtLugGap.IFLDataTag = Nothing
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap = 0
        End If
    End Sub

    '11_02_2010-ARUNA END

    ' ANUP 01-04-2010 11.39

    Private Sub grbBaseEndSelection_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles grbBaseEndSelection.MouseHover, txtSwingClearance.MouseHover, txtCrossTubeWidth.MouseHover, _
    txtOffSet.MouseHover, txtLugGap.MouseHover, txtLugThickness.MouseHover, cmbBaseEndConfiguration.MouseHover
        '****************
        If cmbBaseEndConfiguration.Text <> "" Then
            If cmbBaseEndConfiguration.Text = "Cross Tube" Then
                ObjClsWeldedCylinderFunctionalClass.MdiPictureBox.ImageLocation = ObjClsWeldedCylinderFunctionalClass.CurrentWorkingDirectory + "\Images\cross_tube.PNG"
            ElseIf cmbBaseEndConfiguration.Text = "Single Lug" Then
                ObjClsWeldedCylinderFunctionalClass.MdiPictureBox.ImageLocation = ObjClsWeldedCylinderFunctionalClass.CurrentWorkingDirectory + "\Images\single_lug.PNG"
            ElseIf cmbBaseEndConfiguration.Text = "Double Lug" Then
                ObjClsWeldedCylinderFunctionalClass.MdiPictureBox.ImageLocation = ObjClsWeldedCylinderFunctionalClass.CurrentWorkingDirectory + "\Images\double_lug.PNG"
            Else
                ObjClsWeldedCylinderFunctionalClass.MdiPictureBox.ImageLocation = ""
            End If
        End If
    End Sub

    ' ANUP 01-04-2010 11.39
    Private Sub GroupBox1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox1.MouseHover, txtAngleOfGreaseZercs1.MouseHover, txtAngleOfGreaseZercs2.MouseHover
        '**************
        If cmbGreaseZercs.Text <> "" AndAlso Val(cmbGreaseZercs.Text) >= 1 Then
            ObjClsWeldedCylinderFunctionalClass.MdiPictureBox.ImageLocation = ObjClsWeldedCylinderFunctionalClass.CurrentWorkingDirectory + "\Images\Grease1.jpg"
        Else
            ObjClsWeldedCylinderFunctionalClass.MdiPictureBox.ImageLocation = ""
        End If
    End Sub

    'TODO:  ANUP  20-04-2010 09.33am
    Private Sub cmbStyle_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbStyle.TextChanged
        GreaseZercsAllowedOrNot()
    End Sub

    Private Sub cmbMaterial_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMaterial.TextChanged
        GreaseZercsAllowedOrNot()
        SearchForBushingsData()
    End Sub
    '**********************

    'ANUP 08-11-2010 START
    Private Sub cmbPins_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPins.SelectedIndexChanged
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinsYesOrNo = cmbPins.Text
        'ANUP 12-10-2010 START
        'If cmbPins.Text = "Yes" Then
        '    cmbClips.Enabled = True
        'ElseIf cmbPins.Text = "No" Then
        '    cmbClips.Enabled = False
        'End If
        'cmbClips.Enabled = False
        'ANUP 12-10-2010 TILL HERE
    End Sub
    'ANUP 08-11-2010 TILL HERE

    Private Sub txtAngleOfGreaseZercs2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAngleOfGreaseZercs2.TextChanged

    End Sub
    'ONSITE:20-05-2010 cross tube width >0 base end
    Private Sub txtCrossTubeWidth_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCrossTubeWidth.Validating
        If txtCrossTubeWidth.Text <> "" Then
            If Val(txtCrossTubeWidth.Text) = 0 Then
                MessageBox.Show("Please enter Cross Tube Width value Should be greater than 0.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCrossTubeWidth.SelectAll()
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub cmbThreadSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbThreadSize.SelectedIndexChanged
        If cmbThreadSize.Text <> "" AndAlso cmbThreadSize.Text <> "System.Data.DataRowView" Then
            Try
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadDiameter = Val(cmbThreadSize.SelectedValue)
            Catch ex As Exception

            End Try
        End If
    End Sub

    'ONSITE:01-06-2010 To validate the outer diamter for base plug
    Private Sub txtOutSidePlugDiameter_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtOutSidePlugDiameter.Validating
        If txtOutSidePlugDiameter.Text <> "" Then
            'anup 01-03-2011 start
            Dim OuterDia As Double
            If cmbBaseEndConfiguration.Text = "Base Plug" Then
                OuterDia = GetBasePlugOuterDia()
            End If
            'anup 01-03-2011 till here
            If Val(txtOutSidePlugDiameter.Text) < 0.75 OrElse Val(txtOutSidePlugDiameter.Text) > OuterDia Then
                Dim strMessage As String = " Please enter Base Plug Turn Down Diameter value between 0.75 and " + OuterDia.ToString()
                MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtOutSidePlugDiameter.SelectAll()
                e.Cancel = True
            End If
        End If
    End Sub

    '03_06_2010    RAGAVA
    Public Sub GetBaseEndCodeNumber()
        Try
            Dim oRow As DataRow = Nothing
            Dim _strQuery As String = String.Empty
            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" AndAlso ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "90" Then
                _strQuery = "Select * from PortIntegralRaisedPortDetails90 where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness and portSize = " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text = "3/4", 0.75, 0.5625).ToString
                oRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
                If Not IsNothing(oRow) Then
                    If Not IsDBNull(oRow("CodeNumber")) Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndCodeNumber90 = oRow("CodeNumber")
                    End If
                End If
            ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" AndAlso ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                _strQuery = "Select * from PortIntegralRaisedPortDetails where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness and portSize = " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text = "3/4", 0.75, 0.5625).ToString
                oRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
                If Not IsNothing(oRow) Then
                    If Not IsDBNull(oRow("CodeNumber")) Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndCodeNumber = oRow("CodeNumber")
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    '22_06_2010   RAGAVA
    Private Sub cmbWeldType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbWeldType.SelectedIndexChanged
        Try
            If Trim(cmbWeldType.Text) <> "" Then
                cmbPortInsertion.Items.Clear()
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then       '31_05_2010    RAGAVA
                    cmbPortInsertion.Enabled = False
                    cmbPortInsertion.BackColor = Color.Empty
                    cmbPortInsertion.Items.Add("Raised")
                    cmbPortInsertion.Items.Add("Flushed")         '22_06_2010   RAGAVA
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = cmbWeldType.Text
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
                    cmbPortInsertion.SelectedItem = "Flushed"
                    If Not cmbBaseEndConfiguration.Items.IndexOf("Base Plug") >= 0 Then
                        cmbBaseEndConfiguration.Items.Add("Base Plug")
                        cmbBaseEndConfiguration.Items.Add("Threaded End")
                    End If
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "FILLET" Then
                    cmbPortInsertion.SelectedItem = "Raised"
                    If cmbBaseEndConfiguration.Items.IndexOf("Base Plug") >= 0 Then
                        cmbBaseEndConfiguration.Items.Remove("Base Plug")
                        cmbBaseEndConfiguration.Items.Remove("Threaded End")
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, lblTubeWeldment, LabelGradient4, LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(LabelGradient1)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(LabelGradient5)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(LabelGradient6)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblBaseEndSelection)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblBushingDetails)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblPinHoleDetails)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient7)
    End Sub

#End Region

    Private Sub cmbClips_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClips.SelectedIndexChanged

    End Sub

    Private Sub txtAngleOfGreaseZercs1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAngleOfGreaseZercs1.TextChanged

    End Sub


    'ANUP 20-09-2010 START
    Private Sub cmbStyle_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStyle.SelectedIndexChanged
        Try
            If IsStyle_2BushingsIndividualBore() Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISBushingStyle_2BushingsIndividualBore = "Yes"
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISBushingStyle_2BushingsIndividualBore = "No"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Function IsStyle_2BushingsIndividualBore() As Boolean
        If cmbBaseEndConfiguration.Text = "Cross Tube" Then
            If Trim(cmbStyle.Text) <> "" AndAlso cmbStyle.Text = "2 Bushings Individual Bores" Then
                Return True
            End If
        End If
        Return False
    End Function
    'ANUP 20-09-2010 TILL HERE

    'ANUP 11-10-2010 START
    Private Sub cmbPinHoleSize_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPinHoleSize.DropDownClosed, txtPinHoleSize.TextChanged, _
                                                               cmbBaseEndConfiguration.DropDownClosed, cmbDesignType.DropDownClosed, cmbWeldType.DropDownClosed, cmbBushingQuantity.DropDownClosed
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.New_Revision = "Revision'" Then
                ObjClsWeldedCylinderFunctionalClass.IsValueChanged_Revision = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    'ANUP 11-10-2010 TILL START

    Private Sub LabelGradient1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelGradient1.Click

    End Sub
End Class