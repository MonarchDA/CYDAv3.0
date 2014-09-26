
Public Class frmRodEndConfiguration

#Region "Private Variables"

    Private _dblTempBoreDiameter As Double = 0

    Private _dblTempWorkingPressure As Double = 0

    Private _strTempClass As String = ""

    Private _dblRodLength As Double = 0

    'TODO: ANUP 20-04-2010 12.24pm
    Private _strBushingPartNumber_RodEnd As String
    Private _dblBushingID_RodEnd As Double
    Private _dblBushingOD_RodEnd As Double
    Private _strBushingYesOrNo As String
    Dim _dblBushingWidth_RodEnd As Double
    '***********
    'MANJULA ADDED
    Private pinHolesAndThicknessList As New Hashtable
#End Region

#Region "Properties"

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

    '11_02_2010-ARUNA START
    Public ReadOnly Property ControlsData() As ArrayList
        Get
            ControlsData = New ArrayList
            RodLEngthCalculation()

            'ONSITE:23-05-2010
            If cmbRodEndConfiguration_RodEnd.Text <> "Double Lug" Then
                If ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated" Then
                    ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual"
                Else
                    ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Lathe"
                End If
            End If
            'TODO: ANUP 02-04-2010 01.19
            ControlsData.Add(New Object(3) {"CAL", "RW_ROD LENGTH", "O5", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodLength})
            '**************



            If cmbRodEndConfiguration_RodEnd.Text = "Double Lug" AndAlso cmbConnectionType.Text = "Threaded" Then
                ControlsData.Add(New Object(3) {"GUI", "RW_ROD END CONFIGURATION", "O11", "Double Lug Threaded"})
            Else
                ControlsData.Add(New Object(3) {"GUI", "RW_ROD END CONFIGURATION", "O11", cmbRodEndConfiguration_RodEnd.Text})
            End If


            If cmbRodEndConfiguration_RodEnd.Text = "Flat With Chamfer" OrElse cmbRodEndConfiguration_RodEnd.Text = "Drilled Pin Hole" _
            OrElse cmbRodEndConfiguration_RodEnd.Text = "Threaded Rod" Then
                ControlsData.Add(New Object(3) {"GUI", "RW_ROD END CONFIGURATION DESIGNTYPE", "O13", ""})
            Else
                ControlsData.Add(New Object(3) {"GUI", "RW_ROD END CONFIGURATION DESIGNTYPE", "O13", ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated})
            End If


            ControlsData.Add(New Object(3) {"GUI", "RW_WELD TYPE", "O52", ObjClsWeldedCylinderFunctionalClass.strManual_Lathe})

            If ObjClsWeldedCylinderFunctionalClass.ObjFrmREDLExistingDesign.rdbULugLathe_Existing.Checked Then
                If Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PilotHoleDiameter = "N/A" Then
                    ControlsData.Add(New Object(3) {"GUI", "RW_PILOT HOLE DIAMETER", "O38", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PilotHoleDiameter})
                Else
                    ControlsData.Add(New Object(3) {"GUI", "RW_PILOT HOLE DIAMETER", "O38", 0.25})
                End If
            Else
                ControlsData.Add(New Object(3) {"GUI", "RW_PILOT HOLE DIAMETER", "O38", 0.25})
            End If



            'Available only for Fabrication
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd = 1.25 Or ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd = 1.5 Then
                ControlsData.Add(New Object(3) {"GUI", "RW_U LUG TOP RADIUS", "O40", 1})
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd = 1.75 Or ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd = 2.0 Then
                ControlsData.Add(New Object(3) {"GUI", "RW_U LUG TOP RADIUS", "O40", 1.25})
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd = 2.5 Or ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd = 3.0 Then
                ControlsData.Add(New Object(3) {"GUI", "RW_U LUG TOP RADIUS", "O40", 1.75})
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd = 2.5 Then
                ControlsData.Add(New Object(3) {"GUI", "RW_U LUG TOP RADIUS", "O40", 2})
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd <= 0.5 Then
                ControlsData.Add(New Object(3) {"GUI", "RW_U LUG BEND RADIUS", "O39", 0.25})
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd <= 0.63 Then
                ControlsData.Add(New Object(3) {"GUI", "RW_U LUG BEND RADIUS", "O39", 0.5})
            Else 'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd <= 0.75 Then
                ControlsData.Add(New Object(3) {"GUI", "RW_U LUG BEND RADIUS", "O39", 0.625})
            End If

            'Till   Here


            ControlsData.Add(New Object(3) {"GUI", "RW_LUGTHICKNESS", "O14", Val(txtLugThickness_RodEnd.Text)})
            ControlsData.Add(New Object(3) {"GUI", "RW_LUG GAP", "O15", Val(txtLugGap_RodEnd.Text)})

            'ANUP 17-09-2010 START
            If ObjClsWeldedCylinderFunctionalClass.SwingClearanceValidation_PartCondition_RodEnd Then
                ControlsData.Add(New Object(3) {"GUI", "RW_SWING CLEARANCE", "O16", Val(txtSwingClearance_RodEnd.Text) + 0.0625})
            Else
                ControlsData.Add(New Object(3) {"GUI", "RW_SWING CLEARANCE", "O16", Val(txtSwingClearance_RodEnd.Text)})
            End If
            'ANUP 17-09-2010 TILL HERE

            ControlsData.Add(New Object(3) {"GUI", "RW_AREA REQUIRED", "O17", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd})
            ControlsData.Add(New Object(3) {"GUI", "RW_Y REQUIRED", "O18", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired_RodEnd})
            ControlsData.Add(New Object(3) {"GUI", "RW_LUG(Width)", "O19", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd})

            ControlsData.Add(New Object(3) {"GUI", "RW_BUSHING QUANTITY", "O21", Val(cmbBushingQuantity_RodEnd.Text)})
     
            ControlsData.Add(New Object(3) {"GUI", "RW_GREASE ZERCS", "O35", Val(cmbGreaseZercs_RodEnd.Text)})
            ControlsData.Add(New Object(3) {"GUI", "RW_ANGLE OF GREASSE ZERC 1", "O36", Val(txtAngleOfGreaseZercs1_RodEnd.Text)})
            ControlsData.Add(New Object(3) {"GUI", "RW_ANGLE OF GREASSE ZERC 2", "O37", Val(txtAngleOfGreaseZercs2_RodEnd.Text)})

            Dim dblLugHeight_rodEnd As Double
            dblLugHeight_rodEnd = Val(txtSwingClearance_RodEnd.Text) + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd / 2)
            ControlsData.Add(New Object(3) {"GUI", "RW_LUG(Height)", "O20", dblLugHeight_rodEnd})
            ControlsData.Add(New Object(3) {"GUI", "RW_CROSS TUBE WIDTH", "O43", txtCrossTubeWidth_RodEnd.Text})
            ControlsData.Add(New Object(3) {"GUI", "RW_PIN HOLE", "O24", cmbPinHole_RodEnd.Text})
            ControlsData.Add(New Object(3) {"GUI", "RW_PIN HOLE TYPE", "O25", cmbPinHoleSizeType_RodEnd.Text})
            ControlsData.Add(New Object(3) {"GUI", "RW_DESIGN", "O12", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd})
            ControlsData.Add(New Object(3) {"DB", "RW_SKIM LENGTH", "O48", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SkimWidth})
            ControlsData.Add(New Object(3) {"DB", "RW_RODEND PIN HOLE TO ROD STOP DISTANCE", "O47", (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop) + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop})
            ControlsData.Add(New Object(3) {"DB", "RW_WELD SIZE", "O3", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd})
            ControlsData.Add(New Object(3) {"DB", "RW_WELD PREP RADIUS", "O4", 0.06})
            ControlsData.Add(New Object(3) {"DB", "RW_CROSS TUBE OD", "O42", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd})


            'TODO: ANUP 20-04-2010 12.08pm
            If Val(cmbBushingQuantity_RodEnd.Text) = 0 Then
                If cmbPinHoleSizeType_RodEnd.Text = "Standard" Then
                    If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "Resize" Then
                        If cmbPinHoleSize_RodEnd.Visible = True Then
                            ControlsData.Add(New Object(3) {"GUI", "PinHoleSize", "O9", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd})
                        Else
                            ControlsData.Add(New Object(3) {"GUI", "PinHoleSize", "O9", Val(txtPinHoleSize_RodEnd.Text)})
                        End If
                    Else
                        ControlsData.Add(New Object(3) {"GUI", "RW_PIN HOLE SIZE", "O26", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd})
                    End If
                    ControlsData.Add(New Object(3) {"GUI", "RW_PIN HOLE UPPER TOL", "O27", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd})
                    ControlsData.Add(New Object(3) {"GUI", "RW_PIN HOLE LOWER TOL", "O28", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd})
                ElseIf cmbPinHoleSizeType_RodEnd.Text = "Custom" Then
                    If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "Resize" Then
                        ControlsData.Add(New Object(3) {"GUI", "PinHoleSize", "O9", Val(txtPinHoleSize_RodEnd.Text)})
                    Else
                        ControlsData.Add(New Object(3) {"GUI", "RW_PIN HOLE SIZE", "O26", Val(txtPinHoleSize_RodEnd.Text)})
                    End If
                    If cmbPinHoleSize_RodEnd.Visible = True Then
                        ControlsData.Add(New Object(3) {"GUI", "PinHoleSize", "O9", Val(cmbPinHoleSize_RodEnd.Text)})
                        ControlsData.Add(New Object(3) {"GUI", "RW_PIN HOLE SIZE", "O26", Val(cmbPinHoleSize_RodEnd.Text)})
                    Else
                        ControlsData.Add(New Object(3) {"GUI", "PinHoleSize", "O9", Val(txtPinHoleSize_RodEnd.Text)})
                        ControlsData.Add(New Object(3) {"GUI", "RW_PIN HOLE SIZE", "O26", Val(txtPinHoleSize_RodEnd.Text)})
                    End If
                    ControlsData.Add(New Object(3) {"GUI", "RW_PIN HOLE UPPER TOL", "O27", Val(txtToleranceUpperLimit_RodEnd.Text)})
                    ControlsData.Add(New Object(3) {"GUI", "RW_PIN HOLE LOWER TOL", "O28", Val(txtToleranceLowerLimit_RodEnd.Text)})
                End If
            Else
                ControlsData.Add(New Object(3) {"GUI", "PinHoleSize", "O9", Val(cmbBushingPinHoleSize_RodEnd.Text)})
                ControlsData.Add(New Object(3) {"GUI", "RW_PIN HOLE SIZE", "O26", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingOD_RodEnd})
            End If
            '**************

            ControlsData.Add(New Object(3) {"GUI", "RW_RESIZE, NEW DESIGN OR  EXACT MATCH", "O50", ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd})
            ControlsData.Add(New Object(3) {"GUI", "RW_ROD END CONFIGURATION CODE", "O41", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd})
            'ANUP 06-10-2010 START 
            Dim strPartCode As String = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd)
            Dim strRodEndConfigurationCode_Purchase As String = String.Empty
            If Not String.IsNullOrEmpty(strPartCode) Then
                strRodEndConfigurationCode_Purchase = strPartCode
            Else
                strRodEndConfigurationCode_Purchase = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd
            End If


            '09_10_2010   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Threaded" Then
                clsAddExistingCodes.AddExistingCodeToHashTable("Rod End Configuration Code", strRodEndConfigurationCode_Purchase, 1, "EA")
                '18_10_2010    RAGAVA
                Try
                    Dim strQuery As String = String.Empty
                    strQuery = "select SetScrew,Bushing from Welded.REDLThreaded where partCode = '" & strRodEndConfigurationCode_Purchase & "'"
                    Dim dr As DataRow = MonarchConnectionObject.GetDataRow(strQuery)
                    If Not dr Is Nothing Then
                        '20_04_2011   RAGAVA  'All our offshore castings are now coming in with set screws
                        'If dr("SetScrew").ToString <> "" AndAlso dr("SetScrew").ToString <> "N/A" Then
                        '    clsAddExistingCodes.AddExistingCodeToHashTable("Rod End Set Screw", dr("SetScrew").ToString, 1, "EA")
                        'End If
                        If dr("Bushing").ToString <> "" AndAlso dr("Bushing").ToString <> "N/A" Then
                            clsAddExistingCodes.AddExistingCodeToHashTable("Rod End Bushing", dr("Bushing").ToString, 1, "EA")
                        End If
                    End If
                Catch ex As Exception
                End Try
                'Till   Here
            Else
                If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated") Then      '21_10_2010    RAGAVA   Commented
                    clsAddExistingCodes.AddRodEndConfigurationCode(strRodEndConfigurationCode_Purchase, 1, "EA")
                End If
            End If
                'clsAddExistingCodes.AddRodEndConfigurationCode(strRodEndConfigurationCode_Purchase, 1, "EA")
                '***************************
                'ANUP 06-10-2010 TILL HERE


                '25_02_2010 Aruna
                'TODO: ANUP 31-05-2010 09.13am
                If ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated" Then
                    '****************
                    ControlsData.Add(New Object(3) {"GUI", "RW_WELD PREPERATION", "O44", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd})
                Else
                    ControlsData.Add(New Object(3) {"GUI", "RW_ROD END CONFIGURATION CODE", "O44", "J Groove"})
                End If

                '***************************************************************

                '***************************************************************
                'TODO:Anup 26-02-10 11am
                ControlsData.Add(New Object(3) {"DB", "RW_EXTRA_BUTTON_REQUIRED_TUBE_END", "O53", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ExtraRodButton})
                ControlsData.Add(New Object(3) {"DB", "RW_EXTRA_BUTTON_LENGTH", "O54", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ExtraRodButtonLength})
                '02_03_2010 Aruna
                ControlsData.Add(New Object(3) {"DB", "RW_RODEND PIN HOLE TO ROD START DISTANCE", "O55", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop})
                '*********************
                'Aruna :12-3-2010
                ControlsData.Add(New Object(3) {"GUI", "RW_CHAMFER ANGLE", "O22", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ChamferAngle_RodEnd})
                ControlsData.Add(New Object(3) {"GUI", "RW_CHAMFER SIZE", "O23", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ChamferSize_RodEnd})
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Drilled Pin Hole" Then
                    ControlsData.Add(New Object(3) {"GUI", "RW_PIN HOLE", "O24", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType_RodEnd})
                    ControlsData.Add(New Object(3) {"GUI", "RW_PIN HOLE TYPE", "O25", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSizeType_RodEnd})
                    ControlsData.Add(New Object(3) {"GUI", "RW_PIN HOLE SIZE", "O26", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd})
                    ControlsData.Add(New Object(3) {"GUI", "RW_PIN HOLE UPPER TOL", "O27", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd})
                    ControlsData.Add(New Object(3) {"GUI", "RW_PIN HOLE LOWER TOL", "O28", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd})
                End If
                ControlsData.Add(New Object(3) {"GUI", "RW_THREAD TYPE", "O29", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadType_RodEnd})
                ControlsData.Add(New Object(3) {"GUI", "RW_THREAD SIZE", "O30", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadSize_RodEnd})
                ControlsData.Add(New Object(3) {"GUI", "RW_THREAD LENGTH", "O31", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength_RodEnd})
                ControlsData.Add(New Object(3) {"GUI", "RW_MILLED FLAT", "O32", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlat_RE})
                ControlsData.Add(New Object(3) {"GUI", "RW_ACROSS FLAT", "O33", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AcrossFlatValue_RodEnd})
                ControlsData.Add(New Object(3) {"GUI", "RW_FLAT LENGTH", "O34", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FlatLength_RodEnd})
                ControlsData.Add(New Object(3) {"GUI", "RW_PISTON ROD END TO ROD END PIN HOLE DIST", "O10", (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop)})

            ControlsData.Add(New Object(3) {"GUI", "BUSH INNER DIA", "O56", _dblBushingID_RodEnd})
            ControlsData.Add(New Object(3) {"GUI", "BUSHING STYLE", "O57", cmbStyle_RodEnd.Text})

            'anup 10-02-2011 start
            'ControlsData.Add(New Object(3) {"GUI", "BUSHING STYLE", "O57", cmbStyle_RodEnd.Text})
            'Dim strStyle As String = String.Empty
            'If cmbStyle_RodEnd.Text = "1 Bushing" Then
            '    strStyle = "Bushing"
            'ElseIf cmbStyle_RodEnd.Text = "2 Bushings single bore" Then
            '    strStyle = "Bushings Single Bore"
            'ElseIf cmbStyle_RodEnd.Text = "2 Bushings individual bores" Then
            '    strStyle = "Bushings Individual Bores"
            'End If
            'ControlsData.Add(New Object(3) {"GUI", "BUSHING STYLE", "O57", strStyle})
            ''anup 10-02-2011 till here

                ControlsData.Add(New Object(3) {"GUI", "BUSHING MATERIAL TYPE", "O58", cmbMaterial_RodEnd.Text})
                ControlsData.Add(New Object(3) {"GUI", "BUSHING YES", "O59", _strBushingYesOrNo})

                'TODO: ANUP 23-04-2010 03.53pm
                ControlsData.Add(New Object(3) {"GUI", "BUSHING WIDTH", "O60", _dblBushingWidth_RodEnd})
                If cmbRodEndConfiguration_RodEnd.Text = "Cross Tube" Then
                    If cmbBushingQuantity_RodEnd.Text = 1 Then
                        ControlsData.Add(New Object(3) {"GUI", "BUSHING WIDTH", "O60", Val(txtCrossTubeWidth_RodEnd.Text)})
                    End If
                End If
                '***********


                'TODO: ANUP 28-04-2010 01.03pm
                ControlsData.Add(New Object(3) {"GUI", "WELD SIZE ", "O61", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd})
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Fabricated" Then
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "Chamfer" Then
                        ControlsData.Add(New Object(3) {"GUI", "JGroove Width", "O62", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd})
                        ControlsData.Add(New Object(3) {"GUI", "JGroove Radius", "O63", 0})
                    Else
                        ControlsData.Add(New Object(3) {"GUI", "JGroove Width", "O62", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.JGrooveWidth_RodEnd})
                        ControlsData.Add(New Object(3) {"GUI", "JGroove Radius", "O63", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.JGrooveRadius_RodEnd})
                    End If
                Else
                ControlsData.Add(New Object(3) {"GUI", "JGroove Width", "O62", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.JGrooveWidth_RodEnd})
                    ControlsData.Add(New Object(3) {"GUI", "JGroove Radius", "O63", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.JGrooveRadius_RodEnd})
                End If

            '*****************

            '21_04_2011   RAGAVA
            Try
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentDescription = Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, 2), "0.00").ToString & "-" & Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, 2), "00.00").ToString & "-W"   '21_04_2011   RAGAVA
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodWeldmentDescription = Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, 2), "0.00").ToString & "-" & Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, 2), "00.00").ToString & "-" & Format(Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ShankLength), "00.00").ToString & "-W"
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentDescription = Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, "0.00").ToString & "-" & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, "00.00").ToString & "-W"   '21_04_2011   RAGAVA
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodWeldmentDescription = Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, "0.00").ToString & "-" & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, "00.00").ToString & "-" & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ShankLength, "00.00").ToString & "-W"
                ControlsData.Add(New Object(3) {"GUI", "TubeWeldmentDescription", "O64", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strTubeWeldmentDescription})
                ControlsData.Add(New Object(3) {"GUI", "RodWeldmentDescription", "O65", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodWeldmentDescription})
            Catch ex As Exception
            End Try
            'Till  Here

                Return ControlsData
        End Get
    End Property
    '11_02_2010-ARUNA END

#End Region

#Region "SubProcedures"

    Private Sub DefaultSettings()

        ' *********** MANJULA ADDED **********
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

        ' *******************************
        cmbRodEndConfiguration_RodEnd.Items.Clear()
        cmbRodEndConfiguration_RodEnd.Items.Add("Flat With Chamfer")
        cmbRodEndConfiguration_RodEnd.Items.Add("Drilled Pin Hole")
        cmbRodEndConfiguration_RodEnd.Items.Add("Threaded Rod")
        cmbRodEndConfiguration_RodEnd.Items.Add("Single Lug")
        cmbRodEndConfiguration_RodEnd.Items.Add("BH") 'MANJULA ADDED
        cmbRodEndConfiguration_RodEnd.Items.Add("Double Lug")
        cmbRodEndConfiguration_RodEnd.Items.Add("Cross Tube")
        cmbRodEndConfiguration_RodEnd.Items.Add("Import") 'ANUP 16-08-2010

        'TODO: ANUP 28-04-2010 03.25pm
        'cmbRodEndConfiguration_RodEnd.Items.Add("Import Special")
        '*********************

        'ANUP 08-11-2010 START
        'cmbPins_RodEnd.Items.Clear()
        'cmbPins_RodEnd.Items.Add("Yes")
        'cmbPins_RodEnd.Items.Add("No")

        'cmbClips_RodEnd.Items.Clear()
        'cmbClips_RodEnd.Items.Add("Hair Pin")
        'cmbClips_RodEnd.Items.Add("Cotter Pin")
        'cmbClips_RodEnd.Items.Add("Cir Clips")
        'cmbClips_RodEnd.Items.Add("R Clips")
        'cmbClips_RodEnd.Enabled = False

        lblPins_RodEnd.Visible = False
        cmbPins_RodEnd.Visible = False
        'ANUP 08-11-2010 TILL HERE

        'ANUP 12-10-2010 START
        lblClips_RodEnd.Visible = False
        cmbClips_RodEnd.Visible = False
        'ANUP 12-10-2010 TILL HERE

        cmbClips_RodEnd.BackColor = Color.Empty

        'Sunny 11-05-10
        cmbConnectionType.Items.Clear()
        cmbConnectionType.Items.Add("Threaded")
        cmbConnectionType.Items.Add("Welded")
        cmbConnectionType.SelectedIndex = -1
        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass = "3" OrElse _
        '                       ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass = "4" OrElse _
        '                       ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass = "5" Then
        '    cmbConnectionType.Items.Add("Threaded")
        '    cmbConnectionType.Items.Add("Welded")
        '    'cmbConnectionType.Items.Add("Casting")
        '    cmbConnectionType.SelectedIndex = 0
        '    cmbConnectionType.Enabled = False
        'Else
        '    cmbConnectionType.Items.Add("Threaded")
        '    cmbConnectionType.Items.Add("Welded")
        '    cmbConnectionType.SelectedIndex = -1
        '    cmbConnectionType.Enabled = True
        'End If
        '-----------------------------

        cmbRodEndConfiguration_RodEnd.SelectedIndex = 0

        ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_RodEnd = txtLugThickness_RodEnd
        ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd = txtSwingClearance_RodEnd
        ObjClsWeldedCylinderFunctionalClass.CmbPinHoleSize_RodEnd = cmbPinHoleSize_RodEnd
        ObjClsWeldedCylinderFunctionalClass.TxtPinHoleSize_RodEnd = txtPinHoleSize_RodEnd
        ObjClsWeldedCylinderFunctionalClass.CmbGreaseZercs_RodEnd = cmbGreaseZercs_RodEnd
        ObjClsWeldedCylinderFunctionalClass.TxtAngleOfGreaseZercs1_RodEnd = txtAngleOfGreaseZercs1_RodEnd
        ObjClsWeldedCylinderFunctionalClass.TxtAngleOfGreaseZercs2_RodEnd = txtAngleOfGreaseZercs2_RodEnd
        ObjClsWeldedCylinderFunctionalClass.TxtCrossTubeWidth_RodEnd = txtCrossTubeWidth_RodEnd
        ObjClsWeldedCylinderFunctionalClass.TxtLugGap_RodEnd = txtLugGap_RodEnd
        ObjClsWeldedCylinderFunctionalClass.CmbBushingPinHoleSize_RodEnd = cmbBushingPinHoleSize_RodEnd

        ' ANUP 11-03-2010 02.44
        ObjClsWeldedCylinderFunctionalClass.TxtToleranceUpperLimit_RodEnd = txtToleranceUpperLimit_RodEnd
        ObjClsWeldedCylinderFunctionalClass.TxtToleranceLowerLimit_RodEnd = txtToleranceLowerLimit_RodEnd
        '*************************

        'TODO ANUP 02-04-2010 11.15
        ObjClsWeldedCylinderFunctionalClass.CmbRodEndConfiguration_RodEnd = cmbRodEndConfiguration_RodEnd
        '*************************

        'Sunny 11-05-10
        ObjClsWeldedCylinderFunctionalClass.cmbConnectionType_RodEnd = cmbConnectionType
        '*************************

        'ANUP 08-11-2010 START
        'ObjClsWeldedCylinderFunctionalClass.CmbPins_RodEnd = cmbPins_RodEnd
        'ObjClsWeldedCylinderFunctionalClass.CmbClips_RodEnd = cmbClips_RodEnd
        'ANUP 08-11-2010 TILL HERE
    End Sub

    Public Sub RodLEngthCalculation()
        'TODO: ANUP 02-04-2010 03.25
        Try

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

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Threaded" Then
                    _dblRodLength += ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength_RodEnd
                End If
            End If

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodLength = _dblRodLength
            '**************

        Catch ex As Exception

        End Try
    End Sub

    'TODO:  ANUP 24-05-2010 10.36am
    Private Sub SkipRodEndScreens()
        Dim oForm As Form = ObjClsWeldedCylinderFunctionalClass.ObjFrmRetractedLengthValidation
        ObjClsWeldedCylinderFunctionalClass.ObjPnlChildFormArea.Controls.Clear()
        ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm = oForm
        oForm.TopLevel = False
        oForm.Dock = DockStyle.Fill
        If oForm.Created Then
            ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.ManualLoad()
        End If
        oForm.Show()
        ObjClsWeldedCylinderFunctionalClass.ObjPnlChildFormArea.Controls.Add(oForm)
    End Sub
    '*********************

    Public Sub ManualLoad()
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnFabricated2SingleLug = False      '05_01_2012   RAGAVA
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        'TODO:  ANUP 24-05-2010 10.36am
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GoToBaseEndScreenFromRetractedScreen Then
            SkipRodEndScreens()
        End If

        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GoToRodEndScreenFromRetractedScreen Then
            ObjClsWeldedCylinderFunctionalClass.NextClick.PerformClick()
        End If
        '****************

        If Not _dblTempBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter _
                OrElse Not _dblTempWorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure _
                OrElse Not _strTempClass = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass Then
            _dblTempBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
            _dblTempWorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure
            _strTempClass = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass
            ReLoadPinHole()

            'TODO:  ANUP 24-05-2010 10.36am
            cmbConnectionType.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType
            'cmbConnectionType.SelectedIndex = -1
            '************

            ' cmbConnectionType.SelectedIndex = 0
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass = "3" OrElse _
            '                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass = "4" OrElse _
            '                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass = "5" Then

            '    cmbConnectionType.SelectedIndex = -1
            '    cmbConnectionType.Enabled = False
            '    cmbConnectionType.BackColor = Color.Empty

            'Else
            '    cmbConnectionType.Enabled = True
            'End If
        End If

        '28_02_2012   RAGAVA
        cmbConnectionType.Enabled = False
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.ChkASAE.Checked = True Then
                cmbRodEndConfiguration_RodEnd.Text = "Double Lug"
                cmbConnectionType.Text = "Threaded"
                cmbRodEndConfiguration_RodEnd.Enabled = False
                'cmbConnectionType.Enabled = False
            Else
                cmbRodEndConfiguration_RodEnd.Enabled = True
                ' cmbConnectionType.Enabled = True
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ReLoadPinHole()
        If Not cmbBushingQuantity_RodEnd.Text = 0 Then
            CmbPinHoleSizeFunctionality(cmbBushingPinHoleSize_RodEnd)
        Else
            CmbPinHoleSizeFunctionality(cmbPinHoleSize_RodEnd)
        End If
    End Sub

    Private Sub ControlsFunctionality()


        Try
            If cmbRodEndConfiguration_RodEnd.Text = "Flat With Chamfer" OrElse cmbRodEndConfiguration_RodEnd.Text = "Import" Then

                txtLugThickness_RodEnd.Text = ""
                txtLugThickness_RodEnd.BackColor = Color.Empty
                txtLugThickness_RodEnd.Enabled = False

                txtLugGap_RodEnd.Text = ""
                txtLugGap_RodEnd.Enabled = False
                txtLugGap_RodEnd.BackColor = Color.Empty

                txtSwingClearance_RodEnd.Text = ""
                txtSwingClearance_RodEnd.Enabled = False
                txtSwingClearance_RodEnd.BackColor = Color.Empty

                'ANUP 08-11-2010 START
                'cmbPins_RodEnd.SelectedIndex = -1
                'cmbPins_RodEnd.Enabled = False
                'cmbPins_RodEnd.BackColor = Color.Empty
                'ANUP 08-11-2010 TILL HERE

                txtCrossTubeWidth_RodEnd.Text = ""
                txtCrossTubeWidth_RodEnd.Enabled = False
                txtCrossTubeWidth_RodEnd.BackColor = Color.Empty

                cmbConnectionType.Enabled = False
                cmbConnectionType.SelectedIndex = -1
                cmbConnectionType.BackColor = Color.Empty
                '8_3_2010 Aruna
                'txtOffSet_RodEnd.Enabled = False
                'txtOffSet_RodEnd.Text = ""
                'txtOffSet_RodEnd.BackColor = Color.Empty

            ElseIf cmbRodEndConfiguration_RodEnd.Text = "Drilled Pin Hole" Then
                txtLugThickness_RodEnd.Text = ""
                txtLugThickness_RodEnd.BackColor = Color.Empty
                txtLugThickness_RodEnd.Enabled = False

                txtLugGap_RodEnd.Text = ""
                txtLugGap_RodEnd.Enabled = False
                txtLugGap_RodEnd.BackColor = Color.Empty

                txtSwingClearance_RodEnd.Text = ""
                txtSwingClearance_RodEnd.Enabled = False
                txtSwingClearance_RodEnd.BackColor = Color.Empty

                'ANUP 08-11-2010 START
                'cmbPins_RodEnd.Enabled = True
                'cmbPins_RodEnd.SelectedIndex = 1
                'ANUP 08-11-2010 TILL HERE

                txtCrossTubeWidth_RodEnd.Text = ""
                txtCrossTubeWidth_RodEnd.Enabled = False
                txtCrossTubeWidth_RodEnd.BackColor = Color.Empty

                cmbConnectionType.Enabled = False
                cmbConnectionType.SelectedIndex = -1
                cmbConnectionType.BackColor = Color.Empty
                '8_3_2010 Aruna
                'txtOffSet_RodEnd.Enabled = False
                'txtOffSet_RodEnd.Text = ""
                'txtOffSet_RodEnd.BackColor = Color.Empty

            ElseIf cmbRodEndConfiguration_RodEnd.Text = "Threaded Rod" Then
                txtLugThickness_RodEnd.Text = ""
                txtLugThickness_RodEnd.BackColor = Color.Empty
                txtLugThickness_RodEnd.Enabled = False

                txtLugGap_RodEnd.Text = ""
                txtLugGap_RodEnd.Enabled = False
                txtLugGap_RodEnd.BackColor = Color.Empty

                txtSwingClearance_RodEnd.Text = ""
                txtSwingClearance_RodEnd.Enabled = False
                txtSwingClearance_RodEnd.BackColor = Color.Empty

                'ANUP 08-11-2010 START
                'cmbPins_RodEnd.SelectedIndex = -1
                'cmbPins_RodEnd.Enabled = False
                'cmbPins_RodEnd.BackColor = Color.Empty
                'ANUP 08-11-2010 TILL HERE


                txtCrossTubeWidth_RodEnd.Text = ""
                txtCrossTubeWidth_RodEnd.Enabled = False
                txtCrossTubeWidth_RodEnd.BackColor = Color.Empty

                cmbConnectionType.Enabled = False
                cmbConnectionType.SelectedIndex = -1
                cmbConnectionType.BackColor = Color.Empty
                '8_3_2010 Aruna
                'txtOffSet_RodEnd.Enabled = False
                'txtOffSet_RodEnd.Text = ""
                'txtOffSet_RodEnd.BackColor = Color.Empty

            ElseIf cmbRodEndConfiguration_RodEnd.Text = "Single Lug" Then
                txtLugThickness_RodEnd.Enabled = True

                txtLugGap_RodEnd.Text = ""
                txtLugGap_RodEnd.Enabled = False
                txtLugGap_RodEnd.BackColor = Color.Empty

                txtSwingClearance_RodEnd.Enabled = True

                'ANUP 08-11-2010 START
                'cmbPins_RodEnd.Enabled = True
                'cmbPins_RodEnd.SelectedIndex = 1
                'ANUP 08-11-2010 TILL HERE

                txtCrossTubeWidth_RodEnd.Text = ""
                txtCrossTubeWidth_RodEnd.Enabled = False
                txtCrossTubeWidth_RodEnd.BackColor = Color.Empty

                cmbConnectionType.Enabled = False
                cmbConnectionType.SelectedIndex = -1
                cmbConnectionType.BackColor = Color.Empty
                '8_3_2010 Aruna
                'txtOffSet_RodEnd.Enabled = False
                'txtOffSet_RodEnd.Text = ""
                'txtOffSet_RodEnd.BackColor = Color.Empty

            ElseIf cmbRodEndConfiguration_RodEnd.Text = "BH" Then 'MANJULA ADDED

                setBHCmbPinHoleValues(pinHolesAndThicknessList)
                txtLugThickness_RodEnd.Enabled = False

                txtLugGap_RodEnd.Text = ""
                txtLugGap_RodEnd.Enabled = False
                txtLugGap_RodEnd.BackColor = Color.Empty

                txtSwingClearance_RodEnd.Enabled = True

                'ANUP 08-11-2010 START
                'cmbPins_RodEnd.Enabled = True
                'cmbPins_RodEnd.SelectedIndex = 1
                'ANUP 08-11-2010 TILL HERE

                txtCrossTubeWidth_RodEnd.Text = ""
                txtCrossTubeWidth_RodEnd.Enabled = False
                txtCrossTubeWidth_RodEnd.BackColor = Color.Empty

                cmbConnectionType.Enabled = False
                cmbConnectionType.SelectedIndex = -1
                cmbConnectionType.BackColor = Color.Empty
                '8_3_2010 Aruna
                'txtOffSet_RodEnd.Enabled = False
                'txtOffSet_RodEnd.Text = ""
                'txtOffSet_RodEnd.BackColor = Color.Empty

            ElseIf cmbRodEndConfiguration_RodEnd.Text = "Double Lug" Then
                txtLugThickness_RodEnd.Enabled = True

                txtLugGap_RodEnd.Enabled = True

                txtSwingClearance_RodEnd.Enabled = True


                'ANUP 08-11-2010 START
                'cmbPins_RodEnd.Enabled = True
                'cmbPins_RodEnd.SelectedIndex = 1
                'ANUP 08-11-2010 TILL HERE

                txtCrossTubeWidth_RodEnd.Text = ""
                txtCrossTubeWidth_RodEnd.Enabled = False
                txtCrossTubeWidth_RodEnd.BackColor = Color.Empty
                '8_3_2010 Aruna
                'txtOffSet_RodEnd.Enabled = False
                'txtOffSet_RodEnd.Text = ""
                'txtOffSet_RodEnd.BackColor = Color.Empty


                cmbConnectionType.Items.Clear()
                cmbConnectionType.Items.Add("Threaded")
                cmbConnectionType.Items.Add("Welded")

                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass = "3" OrElse _
                '                       ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass = "4" OrElse _
                '                       ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass = "5" Then
                '    cmbConnectionType.Items.Add("Casting")
                'Else
                '    cmbConnectionType.Items.Add("Welded")
                'End If
                cmbConnectionType.SelectedIndex = -1
                cmbConnectionType.Enabled = True

            ElseIf cmbRodEndConfiguration_RodEnd.Text = "Cross Tube" Then
                txtLugThickness_RodEnd.Text = ""
                txtLugThickness_RodEnd.BackColor = Color.Empty
                txtLugThickness_RodEnd.Enabled = False

                txtLugGap_RodEnd.Text = ""
                txtLugGap_RodEnd.Enabled = False
                txtLugGap_RodEnd.BackColor = Color.Empty

                txtSwingClearance_RodEnd.Enabled = True


                ' 'ANUP 08-11-2010 START
                'cmbPins_RodEnd.Enabled = False
                'cmbPins_RodEnd.SelectedIndex = 1   '1 - "NO"
                'ANUP 08-11-2010 TILL HERE

                txtCrossTubeWidth_RodEnd.Enabled = True

                cmbConnectionType.Enabled = False
                cmbConnectionType.SelectedIndex = -1
                cmbConnectionType.BackColor = Color.Empty

                '17-02-10 Sandeep
                txtSwingClearance_RodEnd.Enabled = False
                txtSwingClearance_RodEnd.Text = ""
                txtSwingClearance_RodEnd.BackColor = Color.Empty
                '17-02-10 Sandeep

                'txtOffSet_RodEnd.Enabled = True '4_3_2010 Aruna
                '8_3_2010 Aruna
                'txtOffSet_RodEnd.Enabled = False


            ElseIf cmbRodEndConfiguration_RodEnd.Text = "Import Special" Then
                txtLugThickness_RodEnd.Text = ""
                txtLugThickness_RodEnd.BackColor = Color.Empty
                txtLugThickness_RodEnd.Enabled = False

                txtLugGap_RodEnd.Text = ""
                txtLugGap_RodEnd.Enabled = False
                txtLugGap_RodEnd.BackColor = Color.Empty

                txtSwingClearance_RodEnd.Enabled = True

                'ANUP 08-11-2010 START
                'cmbPins_RodEnd.Enabled = True
                'cmbPins_RodEnd.SelectedIndex = 1
                'ANUP 08-11-2010 TILL HERE

                txtCrossTubeWidth_RodEnd.Text = ""
                txtCrossTubeWidth_RodEnd.Enabled = False
                txtCrossTubeWidth_RodEnd.BackColor = Color.Empty

                cmbConnectionType.Enabled = False
                cmbConnectionType.SelectedIndex = -1
                cmbConnectionType.BackColor = Color.Empty
                '8_3_2010 Aruna
                'txtOffSet_RodEnd.Enabled = False
                'txtOffSet_RodEnd.Text = ""
                'txtOffSet_RodEnd.BackColor = Color.Empty
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BushingQuantityFunctionality()
        cmbBushingQuantity_RodEnd.Items.Clear()
        If cmbRodEndConfiguration_RodEnd.Text = "Flat With Chamfer" OrElse cmbRodEndConfiguration_RodEnd.Text = "Drilled Pin Hole" _
                    OrElse cmbRodEndConfiguration_RodEnd.Text = "Threaded Rod" OrElse cmbRodEndConfiguration_RodEnd.Text = "Import Special" _
                    OrElse cmbRodEndConfiguration_RodEnd.Text = "Import" Then
            cmbBushingQuantity_RodEnd.Items.Add(0)
            cmbBushingQuantity_RodEnd.SelectedIndex = 0
            cmbBushingQuantity_RodEnd.Enabled = False
            cmbBushingQuantity_RodEnd.BackColor = Color.Empty
        Else
            If cmbRodEndConfiguration_RodEnd.Text = "Double Lug" Then
                cmbBushingQuantity_RodEnd.Items.Add(0)
                cmbBushingQuantity_RodEnd.Items.Add(2)
                cmbBushingQuantity_RodEnd.Enabled = True
                cmbBushingQuantity_RodEnd.SelectedIndex = 0
            Else
                cmbBushingQuantity_RodEnd.Items.Add(0)
                cmbBushingQuantity_RodEnd.Items.Add(1)
                If cmbRodEndConfiguration_RodEnd.Text = "Cross Tube" Then
                    cmbBushingQuantity_RodEnd.Items.Add(2)
                End If
                cmbBushingQuantity_RodEnd.Enabled = True
                cmbBushingQuantity_RodEnd.SelectedIndex = 0
                'TODO: ANUP 27-04-2010 11.44am
                cmbGreaseZercs_RodEnd.Enabled = True
            End If

        End If
    End Sub

    Private Sub BushingQuantitySeletedIndexChanged()
        If cmbBushingQuantity_RodEnd.Text <> "" Then
            If cmbBushingQuantity_RodEnd.Text = 0 AndAlso (cmbRodEndConfiguration_RodEnd.Text = "Flat With Chamfer" _
                OrElse cmbRodEndConfiguration_RodEnd.Text = "Threaded Rod" OrElse cmbRodEndConfiguration_RodEnd.Text = "Import Special" _
                OrElse cmbRodEndConfiguration_RodEnd.Text = "Import") Then
                _strBushingYesOrNo = "No"
                cmbBushingPinHoleSize_RodEnd.DataSource = Nothing
                cmbBushingPinHoleSize_RodEnd.IFLDataTag = Nothing
                cmbBushingPinHoleSize_RodEnd.Enabled = False
                cmbBushingPinHoleSize_RodEnd.BackColor = Color.Empty

                'TODO: COMMENTED BY ANUP 20-04-2010 10.47am
                'cmbBushingType_RodEnd.Items.Clear()
                'cmbBushingType_RodEnd.IFLDataTag = Nothing
                'cmbBushingType_RodEnd.Enabled = False
                'cmbBushingType_RodEnd.BackColor = Color.Empty
                '****************

                txtBushingWidth_RodEnd.Text = ""
                txtBushingWidth_RodEnd.IFLDataTag = ""
                txtBushingWidth_RodEnd.Enabled = False
                txtBushingWidth_RodEnd.BackColor = Color.Empty

                cmbPinHole_RodEnd.Items.Clear()
                cmbPinHole_RodEnd.IFLDataTag = Nothing
                cmbPinHole_RodEnd.Enabled = False
                cmbPinHole_RodEnd.BackColor = Color.Empty

                cmbPinHoleSizeType_RodEnd.Items.Clear()
                cmbPinHoleSizeType_RodEnd.IFLDataTag = Nothing
                cmbPinHoleSizeType_RodEnd.Enabled = False
                cmbPinHoleSizeType_RodEnd.BackColor = Color.Empty

                cmbPinHoleSize_RodEnd.DataSource = Nothing
                cmbPinHoleSize_RodEnd.IFLDataTag = Nothing
                cmbPinHoleSize_RodEnd.Enabled = False
                cmbPinHoleSize_RodEnd.BackColor = Color.Empty

                txtPinHoleSize_RodEnd.Text = ""
                txtPinHoleSize_RodEnd.IFLDataTag = Nothing
                txtPinHoleSize_RodEnd.Enabled = False
                txtPinHoleSize_RodEnd.BackColor = Color.Empty

                txtToleranceLowerLimit_RodEnd.Enabled = False
                txtToleranceLowerLimit_RodEnd.BackColor = Color.Empty
                txtToleranceUpperLimit_RodEnd.Enabled = False
                txtToleranceUpperLimit_RodEnd.BackColor = Color.Empty
                '11_02_2010-ARUNA START
                If cmbBushingQuantity_RodEnd.Text = 1 Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType_RodEnd = "BX1"
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType_RodEnd = "BX2"
                End If
                '11_02_2010-ARUNA END

                'TODO: ANUP  20-04-2010 11.00am

                cmbStyle_RodEnd.Items.Clear()
                cmbMaterial_RodEnd.Items.Clear()
                cmbMaterial_RodEnd.Enabled = False
                cmbStyle_RodEnd.Enabled = False
                '*************
            Else
                'If cmbBushingQuantity_RodEnd.Text <> cmbBushingQuantity_RodEnd.IFLDataTag Then
                cmbBushingQuantity_RodEnd.IFLDataTag = cmbBushingQuantity_RodEnd.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity_RodEnd = Val(cmbBushingQuantity_RodEnd.Text)
                If cmbBushingQuantity_RodEnd.Text = 0 Then
                    _strBushingYesOrNo = "No"
                    cmbBushingPinHoleSize_RodEnd.DataSource = Nothing
                    cmbBushingPinHoleSize_RodEnd.IFLDataTag = Nothing
                    cmbBushingPinHoleSize_RodEnd.Enabled = False
                    cmbBushingPinHoleSize_RodEnd.BackColor = Color.Empty

                    'TODO: COMMENTED BY ANUP 20-04-2010 10.47am
                    'cmbBushingType_RodEnd.Items.Clear()
                    'cmbBushingType_RodEnd.IFLDataTag = Nothing
                    'cmbBushingType_RodEnd.Enabled = False
                    'cmbBushingType_RodEnd.BackColor = Color.Empty
                    '***********************

                    txtBushingWidth_RodEnd.Text = ""
                    txtBushingWidth_RodEnd.IFLDataTag = ""
                    txtBushingWidth_RodEnd.Enabled = False
                    txtBushingWidth_RodEnd.BackColor = Color.Empty

                    CmbPinHoleFunctionality()
                    CmbPinHoleSizeFunctionality(cmbPinHoleSize_RodEnd)
                    CmbPinHoleSizeTypeFunctionality()

                    cmbPinHoleSize_RodEnd.Enabled = True
                    txtPinHoleSize_RodEnd.Enabled = True

                    'TODO: ANUP  20-04-2010 11.00am

                    cmbStyle_RodEnd.Items.Clear()
                    cmbMaterial_RodEnd.Items.Clear()
                    cmbMaterial_RodEnd.Enabled = False
                    cmbStyle_RodEnd.Enabled = False
                    '*************
                    'TODO: ANUP 27-04-2010 11.44am
                    If cmbRodEndConfiguration_RodEnd.Text = "Cross Tube" OrElse cmbRodEndConfiguration_RodEnd.Text = "Base Plug" Then
                        cmbGreaseZercs_RodEnd.Enabled = True
                    End If
                    '*************
                Else
                    _strBushingYesOrNo = "Yes"
                    cmbPinHole_RodEnd.Items.Clear()
                    cmbPinHole_RodEnd.IFLDataTag = Nothing
                    cmbPinHole_RodEnd.Enabled = False
                    cmbPinHole_RodEnd.BackColor = Color.Empty

                    cmbPinHoleSizeType_RodEnd.Items.Clear()
                    cmbPinHoleSizeType_RodEnd.IFLDataTag = Nothing
                    cmbPinHoleSizeType_RodEnd.Enabled = False
                    cmbPinHoleSizeType_RodEnd.BackColor = Color.Empty

                    cmbPinHoleSize_RodEnd.DataSource = Nothing
                    cmbPinHoleSize_RodEnd.IFLDataTag = Nothing
                    cmbPinHoleSize_RodEnd.Enabled = False
                    cmbPinHoleSize_RodEnd.BackColor = Color.Empty

                    txtPinHoleSize_RodEnd.Text = ""
                    txtPinHoleSize_RodEnd.IFLDataTag = Nothing
                    txtPinHoleSize_RodEnd.Enabled = False
                    txtPinHoleSize_RodEnd.BackColor = Color.Empty

                    txtToleranceLowerLimit_RodEnd.Enabled = False
                    txtToleranceLowerLimit_RodEnd.BackColor = Color.Empty
                    txtToleranceUpperLimit_RodEnd.Enabled = False
                    txtToleranceUpperLimit_RodEnd.BackColor = Color.Empty

                    CmbPinHoleSizeFunctionality(cmbBushingPinHoleSize_RodEnd)

                    'TODO: COMMENTED BY ANUP 20-04-2010 10.47am
                    'CmbBushingTypeFunctionality()

                    cmbBushingPinHoleSize_RodEnd.Enabled = True
                    txtBushingWidth_RodEnd.Enabled = True

                    'TODO: ANUP  20-04-2010 11.00am

                    cmbMaterial_RodEnd.Items.Clear()
                    cmbStyle_RodEnd.Items.Clear()
                    cmbMaterial_RodEnd.Enabled = True
                    cmbStyle_RodEnd.Enabled = True

                    cmbMaterial_RodEnd.Items.Add("Steel")
                    cmbMaterial_RodEnd.Items.Add("Composite")

                    txtBushingWidth_RodEnd.Enabled = True
                    txtBushingWidth_RodEnd.Clear()

                    If cmbRodEndConfiguration_RodEnd.Text = "Single Lug" Then
                        cmbStyle_RodEnd.Items.Add("1 Bushing")
                        If cmbBushingQuantity_RodEnd.Text = 1 Then
                            cmbStyle_RodEnd.SelectedIndex = 0
                            cmbStyle_RodEnd.Enabled = False
                            txtBushingWidth_RodEnd.Enabled = False
                            txtBushingWidth_RodEnd.Text = txtLugThickness_RodEnd.Text
                        End If
                    ElseIf cmbRodEndConfiguration_RodEnd.Text = "Cross Tube" Then
                        If cmbBushingQuantity_RodEnd.Text = 1 Then
                            cmbStyle_RodEnd.Items.Add("1 Bushing")
                            cmbStyle_RodEnd.SelectedIndex = 0
                            cmbStyle_RodEnd.Enabled = False
                            txtBushingWidth_RodEnd.Text = Val(txtCrossTubeWidth_RodEnd.Text)
                            txtBushingWidth_RodEnd.Enabled = False
                        Else
                            cmbStyle_RodEnd.Items.Add("2 Bushings single bore")
                            cmbStyle_RodEnd.Items.Add("2 Bushings individual bores")
                        End If
                    Else
                        cmbStyle_RodEnd.Items.Clear()
                        cmbStyle_RodEnd.Enabled = False
                    End If

                    'TODO: ANUP 27-04-2010 11.44am
                    If cmbRodEndConfiguration_RodEnd.Text = "Cross Tube" OrElse cmbRodEndConfiguration_RodEnd.Text = "Base Plug" Then
                        If cmbBushingQuantity_RodEnd.Text = 1 Then
                            cmbGreaseZercs_RodEnd.Enabled = False
                        ElseIf cmbBushingQuantity_RodEnd.Text = 2 Then
                            cmbGreaseZercs_RodEnd.Enabled = True
                        End If

                    End If
                    '*************

                    'TODO: ANUP 18-06-2010 10.28am
                    BushingWidth_LugThickness_Validation()
                    '*************

                End If
                'End If
            End If
        Else
            cmbBushingQuantity_RodEnd.IFLDataTag = ""
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity_RodEnd = 0
        End If
    End Sub

    Private Sub BushingWidth_LugThickness_Validation()
        'TODO: ANUP 18-06-2010 10.28am
        txtBushingWidth_RodEnd.Clear()
        If cmbRodEndConfiguration_RodEnd.Text = "Double Lug" AndAlso Not cmbBushingQuantity_RodEnd.Text = 0 Then
            txtBushingWidth_RodEnd.Text = txtLugThickness_RodEnd.Text
            txtBushingWidth_RodEnd.Enabled = False
        End If

    End Sub

    'TODO: COMMENTED BY ANUP 20-04-2010 10.47am
    'Private Sub CmbBushingTypeFunctionality()
    '    cmbBushingType_RodEnd.Enabled = True
    '    cmbBushingType_RodEnd.Items.Clear()
    '    cmbBushingType_RodEnd.Items.Add("Greaseless")
    '    cmbBushingType_RodEnd.Items.Add("Spring Steel")
    '    cmbBushingType_RodEnd.Items.Add("Spring Steel with Grease Groove+")
    '    If cmbRodEndConfiguration_RodEnd.Text = "Single Lug" Then
    '        cmbBushingType_RodEnd.Items.Add("Bearing (Pressed)")
    '        cmbBushingType_RodEnd.Items.Add("Bearing (Retained)")
    '    End If
    '    cmbBushingType_RodEnd.SelectedIndex = 2
    'End Sub

    Private Sub CmbPinHoleSizeFunctionality(ByVal cmbPinHole As ComboBox)
        cmbPinHole.Visible = True
        Dim oPinHoleSizesDatatable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
        GetPinHoleSizes(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter)
        If Not IsNothing(oPinHoleSizesDatatable) Then
            cmbPinHole.DataSource = oPinHoleSizesDatatable
            cmbPinHole.DisplayMember = "PinHole"
            cmbPinHole.ValueMember = "PinHole"
            'TODO: ANUP 27-04-2010 05.35pm
            'cmbPinHole.SelectedIndex = 0
            cmbPinHole.Text = ObjClsWeldedCylinderFunctionalClass.PinHoleSizes_DefaultSettings(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter)
            '*****************
        End If
    End Sub

    Private Sub CmbPinHoleFunctionality()
        cmbPinHole_RodEnd.Items.Clear()
        cmbPinHole_RodEnd.Enabled = True
        cmbPinHole_RodEnd.Items.Add("Standard")
        cmbPinHole_RodEnd.Items.Add("Hardened")
        cmbPinHole_RodEnd.SelectedIndex = 0
    End Sub

    Private Sub CmbPinHoleSizeTypeFunctionality()
        cmbPinHoleSizeType_RodEnd.Enabled = True
        cmbPinHoleSizeType_RodEnd.Items.Clear()
        cmbPinHoleSizeType_RodEnd.Items.Add("Standard")
        cmbPinHoleSizeType_RodEnd.Items.Add("Custom")
        cmbPinHoleSizeType_RodEnd.SelectedIndex = 0
    End Sub
    'MANJULA ADDED
    Private Sub setBHCmbPinHoleValues(ByVal pinHolesList As Hashtable)
        cmbPinHoleSize_RodEnd.DataSource = Nothing
        Dim list As New ArrayList

        For Each pinHoleSize As Double In pinHolesList.Keys
            list.Add(pinHoleSize)
        Next
        list.Sort()

        For Each pinSize As Double In list
            cmbPinHoleSize_RodEnd.Items.Add(pinSize.ToString)
        Next

        cmbPinHoleSize_RodEnd.SelectedIndex = 1

    End Sub

    Private Sub GreaseZercs()
        cmbGreaseZercs_RodEnd.Items.Clear()
        cmbGreaseZercs_RodEnd.Items.Add(0)
        cmbGreaseZercs_RodEnd.Items.Add(1)
        cmbGreaseZercs_RodEnd.Items.Add(2)
        cmbGreaseZercs_RodEnd.SelectedIndex = 0
        'TODO: ANUP 27-04-2010 11.44am
        If cmbRodEndConfiguration_RodEnd.Text = "Cross Tube" Then
            cmbGreaseZercs_RodEnd.Enabled = True
        Else
            cmbGreaseZercs_RodEnd.Enabled = False
        End If
        '****************

        cmbGreaseZercs_RodEnd.BackColor = Color.Empty

        '     'TODO: COMMENTED BY ANUP 20-04-2010 10.47am
        ' If (cmbRodEndConfiguration_RodEnd.Text = "Cross Tube" OrElse cmbRodEndConfiguration_RodEnd.Text = "Single Lug" _
        'OrElse cmbRodEndConfiguration_RodEnd.Text = "Double Lug") Then


        '     'AndAlso cmbBushingType_RodEnd.Text <> "Greaseless" Then
        '     cmbGreaseZercs_RodEnd.Enabled = True
        ' End If
    End Sub

    Private Sub NextButtonFunctionality()
        'MANJULA ADDED BH
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Import Special" Then
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Single Lug" _
         OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "BH" _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Flat With Chamfer" _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Drilled Pin Hole" _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Threaded Rod" _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" _
         OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        End If
    End Sub

    'TODO:  ANUP  20-04-2010 11.00am
    Private Sub GreaseZercsAllowedOrNot()
        If cmbRodEndConfiguration_RodEnd.Text = "Cross Tube" Then
            If cmbBushingQuantity_RodEnd.Text = "0" Then
                cmbGreaseZercs_RodEnd.Enabled = True
            ElseIf cmbBushingQuantity_RodEnd.Text = "2" Then
                If cmbMaterial_RodEnd.Text = "Steel" Then
                    If cmbStyle_RodEnd.Text = "2 Bushings single bore" OrElse cmbStyle_RodEnd.Text = "2 Bushings individual bores" Then
                        cmbGreaseZercs_RodEnd.Enabled = True
                    Else
                        cmbGreaseZercs_RodEnd.Enabled = False
                    End If
                Else
                    cmbGreaseZercs_RodEnd.Enabled = False
                End If
            Else
                cmbGreaseZercs_RodEnd.Enabled = False
            End If
        Else
            cmbGreaseZercs_RodEnd.Enabled = False
        End If
    End Sub
    '******************

    'TODO:  ANUP  20-04-2010 11.51am
    Private Sub SearchForBushingsData()
        Dim oGetBushingDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetBushingDataTable(cmbMaterial_RodEnd.Text, Val(cmbBushingPinHoleSize_RodEnd.Text), Val(txtBushingWidth_RodEnd.Text))
        If Not IsNothing(oGetBushingDataTable) AndAlso Not oGetBushingDataTable.Rows.Count <= 0 Then
            For Each oDataRow As DataRow In oGetBushingDataTable.Rows
                If Not IsDBNull(oDataRow("PartNumber")) Then
                    _strBushingPartNumber_RodEnd = oDataRow("PartNumber")
                Else
                    _strBushingPartNumber_RodEnd = ""
                End If

                If Not IsDBNull(oDataRow("ID")) Then
                    _dblBushingID_RodEnd = oDataRow("ID")
                Else
                    _dblBushingID_RodEnd = 0
                End If

                If Not IsDBNull(oDataRow("OD")) Then
                    _dblBushingOD_RodEnd = oDataRow("OD")
                Else
                    _dblBushingOD_RodEnd = 0
                End If
            Next
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingOD_RodEnd = _dblBushingOD_RodEnd

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingPartCode_RodEnd = _strBushingPartNumber_RodEnd

        End If
    End Sub

#End Region

#Region "Events"

    Private Sub frmRodEndConfiguration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ObjClsWeldedCylinderFunctionalClass.IsValueChanged_Revision = False '03-02-2011
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        'Dim oMainWeldedCosting As New clsMainWeldedCosting
        'oMainWeldedCosting.FindCosting()
        ColorTheForm()
        DefaultSettings()
        '28_02_2012   RAGAVA
        cmbConnectionType.Enabled = False
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.ChkASAE.Checked = True Then
                cmbRodEndConfiguration_RodEnd.Text = "Double Lug"
                cmbConnectionType.Text = "Threaded"
                cmbRodEndConfiguration_RodEnd.Enabled = False
                'cmbConnectionType.Enabled = False
            Else
                cmbRodEndConfiguration_RodEnd.Enabled = True
                ' cmbConnectionType.Enabled = True
            End If
        Catch ex As Exception

        End Try
        ObjClsWeldedCylinderFunctionalClass.AddColors(Me)
        ObjClsWeldedCylinderFunctionalClass.CurrentForm_Object = ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration
    End Sub

    Private Sub cmbRodEndConfiguration_RodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRodEndConfiguration_RodEnd.SelectedIndexChanged
        If cmbRodEndConfiguration_RodEnd.Text <> "" Then
            If cmbRodEndConfiguration_RodEnd.Text <> cmbRodEndConfiguration_RodEnd.IFLDataTag Then
                '16_08_2010   RAGAVA
                If Trim(cmbRodEndConfiguration_RodEnd.Text) <> "" AndAlso cmbRodEndConfiguration_RodEnd.Text <> "Import" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportRodEndPartPath = ""
                End If
                'Till   Here
                cmbRodEndConfiguration_RodEnd.IFLDataTag = cmbRodEndConfiguration_RodEnd.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = cmbRodEndConfiguration_RodEnd.Text
                ControlsFunctionality()
                BushingQuantityFunctionality()
                GreaseZercs()
                NextButtonFunctionality()
                AddItemsToPinHoleType()
                'MANJULA ADDED
                If cmbRodEndConfiguration_RodEnd.Text = "BH" Then

                    setBHCmbPinHoleValues(pinHolesAndThicknessList)

                    Dim isFound As Boolean = False

                    For Each pinHoleSize As Double In pinHolesAndThicknessList.Keys

                        If pinHoleSize = Val(cmbPinHoleSize_RodEnd.Text) Then

                            'txtLugThickness.SetValue(pinHolesAndThicknessList(pinHoleSize).ToString)
                            txtLugThickness_RodEnd.Text = pinHolesAndThicknessList(pinHoleSize).ToString
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd = Val(txtLugThickness_RodEnd.Text)
                            isFound = True

                        End If

                    Next
                    If Not isFound Then
                        txtLugThickness_RodEnd.Text = "0"
                    End If
                Else
                    txtLugThickness_RodEnd.Text = ""
                End If
                ObjClsWeldedCylinderFunctionalClass.AddColors(Me)
            
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportRodEndPartPath = ""          '16_08_2010   RAGAVA
            cmbRodEndConfiguration_RodEnd.IFLDataTag = ""
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = ""
        End If
    End Sub

    'ONSITE: 07-06-2010
    Private Sub CheckThreadedRodSizes()
        Dim oThreadSizeDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetThreadSizeValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PullForce)
        If IsNothing(oThreadSizeDataTable) AndAlso oThreadSizeDataTable.Rows.Count < 0 Then
            Dim strMessage As String = " Thread Sizes are not available. Please change the Rod End Configuration."
            MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    'ANUP 08-11-2010 START
    Private Sub cmbPins_RodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPins_RodEnd.SelectedIndexChanged
        'If cmbPins_RodEnd.Text <> "" Then
        '    If cmbPins_RodEnd.Text <> cmbPins_RodEnd.IFLDataTag Then
        '        cmbPins_RodEnd.IFLDataTag = cmbPins_RodEnd.Text
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.Pins_RodEnd = cmbPins_RodEnd.Text
        '        If cmbPins_RodEnd.Text = "Yes" Then
        '            'ANUP 12-10-2010 START
        '            cmbClips_RodEnd.Enabled = False
        '            'ANUP 12-10-2010 TILL HERE
        '            cmbClips_RodEnd.SelectedIndex = 0
        '        ElseIf cmbPins_RodEnd.Text = "No" Then
        '            cmbClips_RodEnd.SelectedIndex = -1
        '            cmbClips_RodEnd.Enabled = False
        '            cmbClips_RodEnd.BackColor = Color.Empty
        '        End If
        '    End If
        'Else
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.Pins_RodEnd = ""
        '    cmbPins_RodEnd.IFLDataTag = ""
        '    cmbClips_RodEnd.SelectedIndex = -1
        '    cmbClips_RodEnd.Enabled = False
        '    cmbClips_RodEnd.BackColor = Color.Empty
        'End If
    End Sub
    'ANUP 08-11-2010 TILL HERE

    Private Sub cmbBushingQuantity_RodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBushingQuantity_RodEnd.SelectedIndexChanged
        BushingQuantitySeletedIndexChanged()
    End Sub

    Private Sub cmbPinHoleSizeType_RodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPinHoleSizeType_RodEnd.SelectedIndexChanged
        If cmbPinHoleSizeType_RodEnd.Text <> "" Then
            If cmbPinHoleSizeType_RodEnd.Text <> cmbPinHoleSizeType_RodEnd.IFLDataTag Then
                cmbPinHoleSizeType_RodEnd.IFLDataTag = cmbPinHoleSizeType_RodEnd.Text
                txtToleranceUpperLimit_RodEnd.Text = ""
                txtToleranceLowerLimit_RodEnd.Text = ""
                cmbPinHoleSize_RodEnd.IFLDataTag = Nothing
                If cmbPinHoleSizeType_RodEnd.Text = "Standard" Then
                    CmbPinHoleSizeFunctionality(cmbPinHoleSize_RodEnd)
                    txtPinHoleSize_RodEnd.Visible = False
                    txtToleranceLowerLimit_RodEnd.Enabled = False
                    txtToleranceLowerLimit_RodEnd.BackColor = Color.Empty
                    txtToleranceUpperLimit_RodEnd.Enabled = False
                    txtToleranceUpperLimit_RodEnd.BackColor = Color.Empty
                ElseIf cmbPinHoleSizeType_RodEnd.Text = "Custom" Then
                    txtPinHoleSize_RodEnd.Clear()             '31_01_2011         RAGAVA
                    txtPinHoleSize_RodEnd.IFLDataTag = Nothing       '31_01_2011         RAGAVA
                    cmbPinHoleSize_RodEnd.Visible = False
                    txtPinHoleSize_RodEnd.Visible = True
                    txtToleranceLowerLimit_RodEnd.Enabled = True
                    txtToleranceUpperLimit_RodEnd.Enabled = True
                End If
            End If
        Else
            txtToleranceLowerLimit_RodEnd.Enabled = False
            txtToleranceLowerLimit_RodEnd.BackColor = Color.Empty
            txtToleranceUpperLimit_RodEnd.Enabled = False
            txtToleranceUpperLimit_RodEnd.BackColor = Color.Empty
            cmbPinHoleSizeType_RodEnd.IFLDataTag = Nothing
            cmbPinHoleSize_RodEnd.IFLDataTag = Nothing
        End If
    End Sub


    Private Sub cmbGreaseZercs_RodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGreaseZercs_RodEnd.SelectedIndexChanged
        If cmbGreaseZercs_RodEnd.Text <> "" Then
            If cmbGreaseZercs_RodEnd.Text <> cmbGreaseZercs_RodEnd.IFLDataTag Then
                cmbGreaseZercs_RodEnd.IFLDataTag = cmbGreaseZercs_RodEnd.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs_RodEnd = Val(cmbGreaseZercs_RodEnd.Text)
                If cmbGreaseZercs_RodEnd.Text = "0" Then
                    txtAngleOfGreaseZercs1_RodEnd.Text = ""
                    txtAngleOfGreaseZercs2_RodEnd.Text = ""
                    txtAngleOfGreaseZercs1_RodEnd.Enabled = False
                    txtAngleOfGreaseZercs1_RodEnd.BackColor = Color.Empty
                    txtAngleOfGreaseZercs2_RodEnd.Enabled = False
                    txtAngleOfGreaseZercs2_RodEnd.BackColor = Color.Empty
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1_RodEnd = 0
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2_RodEnd = 0
                ElseIf cmbGreaseZercs_RodEnd.Text = "1" Then
                    txtAngleOfGreaseZercs2_RodEnd.Text = ""
                    txtAngleOfGreaseZercs1_RodEnd.Enabled = True
                    txtAngleOfGreaseZercs2_RodEnd.Enabled = False
                    txtAngleOfGreaseZercs2_RodEnd.BackColor = Color.Empty
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1_RodEnd = Val(txtAngleOfGreaseZercs1_RodEnd.Text)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2_RodEnd = 0
                ElseIf cmbGreaseZercs_RodEnd.Text = "2" Then
                    txtAngleOfGreaseZercs1_RodEnd.Enabled = True
                    txtAngleOfGreaseZercs2_RodEnd.Enabled = True
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1_RodEnd = Val(txtAngleOfGreaseZercs1_RodEnd.Text)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2_RodEnd = Val(txtAngleOfGreaseZercs2_RodEnd.Text)
                End If
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs_RodEnd = 0
            cmbGreaseZercs_RodEnd.IFLDataTag = Nothing
        End If
    End Sub

    Private Sub txtLugThickness_RodEnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLugThickness_RodEnd.Leave
        '19_02_2010    RAGAVA
        Try
            If txtLugThickness_RodEnd.Text <> "" Then
                If txtLugThickness_RodEnd.Text <> txtLugThickness_RodEnd.IFLDataTag Then
                    txtLugThickness_RodEnd.IFLDataTag = txtLugThickness_RodEnd.Text
                    If (Val(txtLugThickness_RodEnd.Text) Mod 0.0625) <> 0 Then
                        Dim dblLugThick As Double = Math.Round(Val(txtLugThickness_RodEnd.Text) / 0.0625)
                        dblLugThick = dblLugThick * 0.0625
                        txtLugThickness_RodEnd.Text = dblLugThick.ToString
                        MessageBox.Show("Value rounded to 1/16 multiple", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                    End If
                    SL_LugThickValid()
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd = Val(txtLugThickness_RodEnd.Text)

                    'TODO: ANUP 18-06-2010 10.28am
                    BushingWidth_LugThickness_Validation()
                    '*************
                End If
            Else
                txtLugThickness_RodEnd.IFLDataTag = Nothing
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd = 0
            End If
        Catch ex As Exception
        End Try
        'Till   Here
        'If txtLugThickness_RodEnd.Text <> "" Then
        '    If txtLugThickness_RodEnd.Text <> txtLugThickness_RodEnd.IFLDataTag Then
        '        txtLugThickness_RodEnd.IFLDataTag = txtLugThickness_RodEnd.Text
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd = txtLugThickness_RodEnd.Text
        '    End If
        'Else
        '    txtLugThickness_RodEnd.IFLDataTag = ""
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd = 0
        'End If
    End Sub

    'ONSITE:27-05-2010 to check the lug thickness value with rod diameter
    Private Sub SL_LugThickValid()
        If Val(txtLugThickness_RodEnd.Text) >= ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter Then
            Dim strMessage As String = " This is not valid design. Please select Cross Tube configuration. OR" + vbCrLf + _
                                        " Change Lug Thickness value lower than Rod Diameter ( " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString + " )"
            MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtLugThickness_RodEnd.SelectAll()
            txtLugThickness_RodEnd.Focus()
        End If
    End Sub

    Private Sub txtLugGap_RodEnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLugGap_RodEnd.Leave
        '19_02_2010    RAGAVA
        Try
            If txtLugGap_RodEnd.Text <> "" Then
                If txtLugGap_RodEnd.Text <> txtLugGap_RodEnd.IFLDataTag Then
                    txtLugGap_RodEnd.IFLDataTag = txtLugGap_RodEnd.Text
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd = Val(txtLugGap_RodEnd.Text)

                    If (Val(txtLugGap_RodEnd.Text) Mod 0.0625) <> 0 Then
                        Dim dblLugGap As Double = Math.Round(Val(txtLugGap_RodEnd.Text) / 0.0625)
                        dblLugGap = dblLugGap * 0.0625
                        txtLugGap_RodEnd.Text = dblLugGap.ToString
                        MessageBox.Show("Value rounded to 1/16 multiple", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                    End If
                End If
            Else
                txtLugGap_RodEnd.IFLDataTag = Nothing
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd = 0
            End If
        Catch ex As Exception
        End Try
        'Till   Here
        If txtLugGap_RodEnd.Text <> "" Then
            If txtLugGap_RodEnd.Text <> txtLugGap_RodEnd.IFLDataTag Then
                txtLugGap_RodEnd.IFLDataTag = txtLugGap_RodEnd.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd = txtLugGap_RodEnd.Text
            End If
        Else
            txtLugGap_RodEnd.IFLDataTag = ""
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd = 0
        End If
    End Sub

    'Private Sub txtSwingClearance_RodEnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSwingClearance_RodEnd.Leave
    '    If txtSwingClearance_RodEnd.Text <> "" Then
    '        If txtSwingClearance_RodEnd.Text <> txtSwingClearance_RodEnd.IFLDataTag Then
    '            txtSwingClearance_RodEnd.IFLDataTag = txtSwingClearance_RodEnd.Text
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd = txtSwingClearance_RodEnd.Text
    '        End If
    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd = Val(txtSwingClearance_RodEnd.Text)      '25_02_2010    RAGAVA
    '    Else
    '        txtSwingClearance_RodEnd.IFLDataTag = ""
    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd = 0
    '    End If
    'End Sub

    Private Sub cmbClips_RodEnd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbClips_RodEnd.SelectedIndexChanged
        If cmbClips_RodEnd.Text <> "" Then
            If cmbClips_RodEnd.Text <> cmbClips_RodEnd.IFLDataTag Then
                cmbClips_RodEnd.IFLDataTag = cmbClips_RodEnd.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.Clips_RodEnd = cmbClips_RodEnd.Text
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.Clips_RodEnd = ""
            cmbClips_RodEnd.IFLDataTag = ""
        End If
    End Sub

    Private Sub txtCrossTubeWidth_RodEnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCrossTubeWidth_RodEnd.Leave
        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables._blnIsFocusedInRevision = False Then 'anup 11-02-2011
        If txtCrossTubeWidth_RodEnd.Text <> "" Then
            If txtCrossTubeWidth_RodEnd.Text <> txtCrossTubeWidth_RodEnd.IFLDataTag Then
                txtCrossTubeWidth_RodEnd.IFLDataTag = txtCrossTubeWidth_RodEnd.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd = txtCrossTubeWidth_RodEnd.Text
                CT_WidthValidation()
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables._blnIsFocusedInRevision = False Then 'anup 14-02-2011
                    If Val(txtCrossTubeWidth_RodEnd.Text) > 2 Then
                        cmbBushingQuantity_RodEnd.Items.Clear()
                        cmbBushingQuantity_RodEnd.Items.Add(0)
                        cmbBushingQuantity_RodEnd.Items.Add(2)
                    Else
                        cmbBushingQuantity_RodEnd.Items.Clear()
                        cmbBushingQuantity_RodEnd.Items.Add(0)
                        cmbBushingQuantity_RodEnd.Items.Add(1)
                        cmbBushingQuantity_RodEnd.Items.Add(2)
                    End If
                    cmbBushingQuantity_RodEnd.Enabled = True
                    cmbBushingQuantity_RodEnd.SelectedIndex = 0
                End If 'anup 14-02-2011
            End If
        Else
            txtCrossTubeWidth_RodEnd.IFLDataTag = ""
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd = 0
        End If
        'End If   'anup 11-02-2011
    End Sub

    'ONSITE:27-05-2010
    Private Sub CT_WidthValidation()
        If Val(txtCrossTubeWidth_RodEnd.Text) < ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter Then
            Dim strMessage As String = "Casting is not Available for the corresponding Cross Tube as cross Tube Width is less than Rod Diamter ( " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString + " )"
            MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtAcrossFlatValue_RodEnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        'If txtAcrossFlatValue_RodEnd.Text <> "" Then
        '    If txtAcrossFlatValue_RodEnd.Text <> txtAcrossFlatValue_RodEnd.IFLDataTag Then
        '        txtAcrossFlatValue_RodEnd.IFLDataTag = txtAcrossFlatValue_RodEnd.Text
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AcrossFlatValue_RodEnd = txtAcrossFlatValue_RodEnd.Text
        '    End If
        'Else
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AcrossFlatValue_RodEnd = 0
        '    txtAcrossFlatValue_RodEnd.IFLDataTag = ""
        'End If
    End Sub

    Private Sub txtFlatLength_RodEnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        'If txtFlatLength_RodEnd.Text <> "" Then
        '    If txtFlatLength_RodEnd.Text <> txtFlatLength_RodEnd.IFLDataTag Then
        '        txtFlatLength_RodEnd.IFLDataTag = txtFlatLength_RodEnd.Text
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FlatLength_RodEnd = txtFlatLength_RodEnd.Text
        '    End If
        'Else
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FlatLength_RodEnd = 0
        '    txtFlatLength_RodEnd.IFLDataTag = ""
        'End If
    End Sub

    Private Sub cmbBushingPinHoleSize_RodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBushingPinHoleSize_RodEnd.SelectedIndexChanged
        If cmbBushingPinHoleSize_RodEnd.Text <> "" AndAlso cmbBushingPinHoleSize_RodEnd.Text <> "System.Data.DataRowView" Then
            If cmbBushingPinHoleSize_RodEnd.Text <> cmbBushingPinHoleSize_RodEnd.IFLDataTag Then
                cmbBushingPinHoleSize_RodEnd.IFLDataTag = cmbBushingPinHoleSize_RodEnd.Text
                ObjClsWeldedCylinderFunctionalClass.PinHoleSize_source_RodEnd = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.BushingPinHole
                Dim oPinHoleDetailsDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPinHoleDetails(cmbBushingPinHoleSize_RodEnd.Text)
                If Not IsNothing(oPinHoleDetailsDataRow) Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd = oPinHoleDetailsDataRow("PinHoleDimension")
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd = 0
                End If
            End If
        Else
            cmbBushingPinHoleSize_RodEnd.IFLDataTag = Nothing
        End If
        'TODO:  ANUP  20-04-2010 02.07pm
        SearchForBushingsData()
    End Sub

    'TODO: ANUP  20-04-2010 11.00am
    'ANUP 20-09-2010 START
    Private Sub txtBushingWidth_RodEnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBushingWidth_RodEnd.Leave
        'ANUP 20-09-2010 TILL HERE
        If txtBushingWidth_RodEnd.Text <> "" Then
            If txtBushingWidth_RodEnd.Text <> txtBushingWidth_RodEnd.IFLDataTag Then
                If (Val(txtBushingWidth_RodEnd.Text) Mod 0.125) <> 0 Then
                    Dim dblBushingWidth_RodEnd As Double = Math.Ceiling(Val(txtBushingWidth_RodEnd.Text) / 0.125)
                    dblBushingWidth_RodEnd = dblBushingWidth_RodEnd * 0.125
                    txtBushingWidth_RodEnd.Text = dblBushingWidth_RodEnd.ToString
                    MessageBox.Show("Value rounded to 1/8 multiple", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                End If
                txtBushingWidth_RodEnd.IFLDataTag = txtBushingWidth_RodEnd.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth_RodEnd = Val(txtBushingWidth_RodEnd.Text)         '14_02_2011   RAGAVA
            End If
        Else
            txtBushingWidth_RodEnd.IFLDataTag = ""
        End If

        If txtBushingWidth_RodEnd.Text <> "" Then
            If Val(txtBushingWidth_RodEnd.Text) < 0.5 OrElse Val(txtBushingWidth_RodEnd.Text) > 2 Then
                Dim strMessage As String = "Bushing width must be >= 0.5 and <= 2"
                MessageBox.Show(strMessage, "Bushing Width cannot be used", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                txtBushingWidth_RodEnd.Clear()
                txtBushingWidth_RodEnd.Focus()
            Else

                SearchForBushingsData()

                Try

                    If Not txtBushingWidth_RodEnd.Text = "" Then

                        '''''SINGLE LUG AND DOUBLE LUG'''''
                        If cmbRodEndConfiguration_RodEnd.Text = "Single Lug" OrElse cmbRodEndConfiguration_RodEnd.Text = "Double Lug" Then
                            If Val(txtBushingWidth_RodEnd.Text) <= Val(txtLugThickness_RodEnd.Text) Then
                                _dblBushingWidth_RodEnd = txtBushingWidth_RodEnd.Text
                            Else
                                If (MessageBox.Show("Bushing Width must be less than or equal to Lug Thickness", "Bushing Width is more", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)) = Windows.Forms.DialogResult.OK Then
                                    txtBushingWidth_RodEnd.Text = ""
                                    txtBushingWidth_RodEnd.Focus()
                                End If
                            End If

                            '''''CROSS TUBE'''''
                        ElseIf cmbRodEndConfiguration_RodEnd.Text = "Cross Tube" Then
                            If cmbStyle_RodEnd.Text = "1 Bushing" Then
                                If Val(txtBushingWidth_RodEnd.Text) <= Val(txtCrossTubeWidth_RodEnd.Text) Then
                                    _dblBushingWidth_RodEnd = txtBushingWidth_RodEnd.Text
                                Else
                                    If (MessageBox.Show("Bushing Width must be less than or equal to CrossTube Width", "Bushing Width is more", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)) = Windows.Forms.DialogResult.OK Then
                                        txtBushingWidth_RodEnd.Text = ""
                                        txtBushingWidth_RodEnd.Focus()
                                    End If
                                End If
                            ElseIf cmbStyle_RodEnd.Text = "2 Bushings single bore" OrElse cmbStyle_RodEnd.Text = "2 Bushings individual bores" Then
                                If Val(txtBushingWidth_RodEnd.Text) <= (Val(txtCrossTubeWidth_RodEnd.Text) - 0.125) / 2 Then
                                    _dblBushingWidth_RodEnd = txtBushingWidth_RodEnd.Text
                                Else
                                    If (MessageBox.Show("Bushing Width must be less than or equal to (CrossTube Width - 0.125) / 2", "Bushing Width is more", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)) = Windows.Forms.DialogResult.OK Then
                                        txtBushingWidth_RodEnd.Text = ""
                                        txtBushingWidth_RodEnd.Focus()
                                    End If
                                End If
                            End If
                        End If
                    End If
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub
    '***********

    'TODO: COMMENTED BY ANUP 20-04-2010 10.47am
    'Private Sub cmbBushingType_RodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If cmbBushingType_RodEnd.Text <> "" AndAlso cmbBushingType_RodEnd.Text <> "System.Data.DataRowView" Then
    '        If cmbBushingType_RodEnd.Text <> cmbBushingType_RodEnd.IFLDataTag Then
    '            cmbBushingType_RodEnd.IFLDataTag = cmbBushingType_RodEnd.Text
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingType_RodEnd = cmbBushingType_RodEnd.Text
    '            GreaseZercs()
    '        End If
    '    Else
    '        GreaseZercs()
    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingType_RodEnd = ""
    '    End If
    'End Sub

    'Private Sub txtAngleOfGreaseZercs1_RodEnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAngleOfGreaseZercs1_RodEnd.Leave
    '    If txtAngleOfGreaseZercs1_RodEnd.Text <> "" Then
    '        If txtAngleOfGreaseZercs1_RodEnd.Text <> txtAngleOfGreaseZercs1_RodEnd.IFLDataTag Then
    '            txtAngleOfGreaseZercs1_RodEnd.IFLDataTag = txtAngleOfGreaseZercs1_RodEnd.Text
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1_RodEnd = txtAngleOfGreaseZercs1_RodEnd.Text
    '        End If
    '    Else
    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1_RodEnd = 0
    '        txtAngleOfGreaseZercs1_RodEnd.IFLDataTag = ""
    '    End If
    'End Sub

    'Private Sub txtAngleOfGreaseZercs2_RodEnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAngleOfGreaseZercs2_RodEnd.Leave
    '    If txtAngleOfGreaseZercs2_RodEnd.Text <> "" Then
    '        If txtAngleOfGreaseZercs2_RodEnd.Text <> txtAngleOfGreaseZercs2_RodEnd.IFLDataTag Then
    '            txtAngleOfGreaseZercs2_RodEnd.IFLDataTag = txtAngleOfGreaseZercs2_RodEnd.Text
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2_RodEnd = txtAngleOfGreaseZercs2_RodEnd.Text
    '        End If
    '    Else
    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2_RodEnd = 0
    '        txtAngleOfGreaseZercs2_RodEnd.IFLDataTag = ""
    '    End If
    'End Sub

    'TODO: ANUP 27-02-2010 12.41
    Private Sub txtAngleOfGreaseZercs2_RodEnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtAngleOfGreaseZercs2_RodEnd.Leave, txtAngleOfGreaseZercs1_RodEnd.Leave
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
                If cmbGreaseZercs_RodEnd.Text = "2" Then
                    If txtAngleOfGreaseZercs2_RodEnd.Text <> "" AndAlso txtAngleOfGreaseZercs1_RodEnd.Text <> "" Then
                        If sender.Text <> sender.IFLDataTag Then
                            sender.IFLDataTag = sender.Text
                            If Val(txtAngleOfGreaseZercs2_RodEnd.Text) = -Val(txtAngleOfGreaseZercs1_RodEnd.Text) Then
                                MessageBox.Show("Difference between Grease Zercs Angle should not be same", "Change Grease Zercs Angle value", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                sender.IFLDataTag = Nothing
                            Else
                                If Math.Abs(Val(txtAngleOfGreaseZercs2_RodEnd.Text) + Val(txtAngleOfGreaseZercs1_RodEnd.Text)) < 15 Then
                                    MessageBox.Show("Difference between Grease Zercs Angle should be minimum 15", "Change Grease Zercs Angle value", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    sender.IFLDataTag = Nothing
                                    Exit Sub
                                End If
                            End If
                        End If
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1_RodEnd = Val(txtAngleOfGreaseZercs1_RodEnd.Text)
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2_RodEnd = Val(txtAngleOfGreaseZercs2_RodEnd.Text)
                    Else
                        sender.IFLDataTag = Nothing
                    End If
                ElseIf cmbGreaseZercs_RodEnd.Text = "1" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1_RodEnd = Val(txtAngleOfGreaseZercs1_RodEnd.Text)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2_RodEnd = 0
                End If
            End If
        End If
    End Sub
    '#########################
    Private Sub cmbPinHoleSize_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPinHoleSize_RodEnd.SelectedIndexChanged, txtPinHoleSize_RodEnd.Leave 'ANUP 05-10-2010 JUST CHANGE TO LEAVE
        If cmbPinHoleSizeType_RodEnd.Text = "Standard" Then
            If cmbPinHoleSize_RodEnd.Text <> "" AndAlso cmbPinHoleSize_RodEnd.Text <> "System.Data.DataRowView" Then
                If cmbPinHoleSize_RodEnd.Text <> cmbPinHoleSize_RodEnd.IFLDataTag Then
                    cmbPinHoleSize_RodEnd.IFLDataTag = cmbPinHoleSize_RodEnd.Text
                    ObjClsWeldedCylinderFunctionalClass.PinHoleSize_source_RodEnd = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleStandard
                    Dim oPinHoleDetailsDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPinHoleDetails(cmbPinHoleSize_RodEnd.Text)
                    If Not IsNothing(oPinHoleDetailsDataRow) Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd = oPinHoleDetailsDataRow("PinHoleDimension")
                        txtToleranceLowerLimit_RodEnd.Text = oPinHoleDetailsDataRow("ToleranceLowerLimit")
                        txtToleranceUpperLimit_RodEnd.Text = oPinHoleDetailsDataRow("ToleranceUpperLimit")
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd = oPinHoleDetailsDataRow("ToleranceUpperLimit")
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd = oPinHoleDetailsDataRow("ToleranceLowerLimit")
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd = 0
                        txtToleranceLowerLimit_RodEnd.Text = ""
                        txtToleranceUpperLimit_RodEnd.Text = ""
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd = 0
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd = 0
                    End If
                End If
                'MANJULA ADDED
                If cmbRodEndConfiguration_RodEnd.Text = "BH" Then

                    Dim isFound As Boolean = False

                    For Each pinHoleSize As Double In pinHolesAndThicknessList.Keys

                        If pinHoleSize = Val(cmbPinHoleSize_RodEnd.Text) Then

                            'txtLugThickness.SetValue(pinHolesAndThicknessList(pinHoleSize).ToString)
                            txtLugThickness_RodEnd.Text = pinHolesAndThicknessList(pinHoleSize).ToString
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd = Val(txtLugThickness_RodEnd.Text)
                            isFound = True

                        End If

                    Next
                    If Not isFound Then
                        txtLugThickness_RodEnd.Text = "0"
                    End If
                End If
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd = 0
                cmbPinHoleSize_RodEnd.IFLDataTag = Nothing
                txtToleranceLowerLimit_RodEnd.Text = ""
                txtToleranceUpperLimit_RodEnd.Text = ""
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd = 0
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd = 0
            End If
        ElseIf cmbPinHoleSizeType_RodEnd.Text = "Custom" Then
            If txtPinHoleSize_RodEnd.Text <> "" Then
                If txtPinHoleSize_RodEnd.Text <> txtPinHoleSize_RodEnd.IFLDataTag Then
                    ObjClsWeldedCylinderFunctionalClass.PinHoleSize_source_RodEnd = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleCustom
                    txtPinHoleSize_RodEnd.IFLDataTag = txtPinHoleSize_RodEnd.Text
                    'Dim oPinHoleDetailsDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPinHoleDetails(txtPinHoleSize_RodEnd.Text)
                    'If Not IsNothing(oPinHoleDetailsDataRow) Then
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd = oPinHoleDetailsDataRow("PinHoleDimension")
                    'txtToleranceLowerLimit_RodEnd.Text = oPinHoleDetailsDataRow("ToleranceLowerLimit")
                    'txtToleranceUpperLimit_RodEnd.Text = oPinHoleDetailsDataRow("ToleranceUpperLimit")
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd = txtPinHoleSize_RodEnd.Text
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd = Val(txtToleranceUpperLimit_RodEnd.Text)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd = Val(txtToleranceLowerLimit_RodEnd.Text)

                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd = oPinHoleDetailsDataRow("ToleranceUpperLimit")
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd = oPinHoleDetailsDataRow("ToleranceLowerLimit")
                End If         '31_01_2011   RAGAVA
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd = 0
                txtToleranceLowerLimit_RodEnd.Text = ""
                txtToleranceUpperLimit_RodEnd.Text = ""
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd = 0
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd = 0
                'End If         '31_01_2011   RAGAVA
            End If
        Else
            txtPinHoleSize_RodEnd.IFLDataTag = Nothing
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd = 0
            txtToleranceLowerLimit_RodEnd.Text = ""
            txtToleranceUpperLimit_RodEnd.Text = ""
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd = 0
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd = 0
        End If
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSizeType_RodEnd = cmbPinHoleSizeType_RodEnd.Text
    End Sub

    Private Sub txtToleranceLowerLimit_RodEnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
       txtToleranceLowerLimit_RodEnd.Leave, txtToleranceUpperLimit_RodEnd.Leave

        If txtToleranceLowerLimit_RodEnd.Text <> "" Then
            If txtToleranceLowerLimit_RodEnd.Text <> txtToleranceLowerLimit_RodEnd.IFLDataTag Then
                txtToleranceLowerLimit_RodEnd.IFLDataTag = txtToleranceLowerLimit_RodEnd.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd = txtToleranceLowerLimit_RodEnd.Text
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd = 0
            txtToleranceLowerLimit_RodEnd.IFLDataTag = ""
        End If
        If txtToleranceUpperLimit_RodEnd.Text <> "" Then
            If txtToleranceUpperLimit_RodEnd.Text <> txtToleranceUpperLimit_RodEnd.IFLDataTag Then
                txtToleranceUpperLimit_RodEnd.IFLDataTag = txtToleranceUpperLimit_RodEnd.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd = txtToleranceUpperLimit_RodEnd.Text
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd = 0
            txtToleranceUpperLimit_RodEnd.IFLDataTag = ""
        End If


        If txtToleranceUpperLimit_RodEnd.Text <> "" AndAlso txtToleranceLowerLimit_RodEnd.Text <> "" Then
            Dim dblTotalTolerance As Double = Val(txtToleranceLowerLimit_RodEnd.Text) + Val(txtToleranceUpperLimit_RodEnd.Text)

            'ANUP 10-10-2010 START CHANGED 0.004 to 0.002
            If dblTotalTolerance < 0.002 Then
                'ANUP 10-10-2010 TILL HERE

                MessageBox.Show("Tolerance is Unachievable", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf dblTotalTolerance > 0.025 Then
                If MessageBox.Show("Recommend using standard Tolerance, Do you want to proceed with Non-Standard Tolerances", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then
                    Dim oPinHoleDetailsDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPinHoleDetails(cmbPinHoleSize_RodEnd.Text)
                    If Not IsNothing(oPinHoleDetailsDataRow) Then
                        txtToleranceLowerLimit_RodEnd.Text = oPinHoleDetailsDataRow("ToleranceLowerLimit")
                        txtToleranceUpperLimit_RodEnd.Text = oPinHoleDetailsDataRow("ToleranceUpperLimit")
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd = oPinHoleDetailsDataRow("ToleranceLowerLimit")
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd = oPinHoleDetailsDataRow("ToleranceUpperLimit")
                    End If
                Else

                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd = txtToleranceUpperLimit_RodEnd.Text
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd = txtToleranceLowerLimit_RodEnd.Text
                End If
            End If
        End If
    End Sub

    Private Sub cmbConnectionType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbConnectionType.SelectedIndexChanged
        If cmbConnectionType.Text <> "" AndAlso cmbConnectionType.Text <> "System.Data.DataRowView" Then
            If cmbConnectionType.Text <> cmbConnectionType.IFLDataTag Then
                cmbConnectionType.IFLDataTag = cmbConnectionType.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = cmbConnectionType.Text
                AddItemsToPinHoleType()
                DisContThreadedDL()
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = ""
        End If
    End Sub

    'ONSITE:26-05-2010 To disable and enbled controls based on the connection type selection for double lug
    Private Sub DisContThreadedDL()
        Try
            cmbBushingQuantity_RodEnd.Items.Clear()
            ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = ""    '12_08_2010   RAGAVA
            If cmbConnectionType.Text = "Threaded" Then
                ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Cast"    '12_08_2010   RAGAVA
                txtSwingClearance_RodEnd.Text = 1.87
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd = "1.87"
                cmbBushingQuantity_RodEnd.Items.Add(0)
                cmbBushingQuantity_RodEnd.SelectedIndex = 0
                cmbBushingQuantity_RodEnd.Enabled = False
                cmbBushingQuantity_RodEnd.BackColor = Color.Empty
                txtLugThickness_RodEnd.Enabled = False
                txtLugThickness_RodEnd.BackColor = Color.Empty
                txtLugThickness_RodEnd.Text = ""
                txtLugGap_RodEnd.Enabled = False
                txtLugGap_RodEnd.BackColor = Color.Empty
                txtLugGap_RodEnd.Text = ""
                EnaDisPinHoleForDL(False)
            ElseIf cmbConnectionType.Text = "Welded" OrElse cmbConnectionType.Text = "Casting" Then
                txtLugThickness_RodEnd.Enabled = True
                txtLugGap_RodEnd.Enabled = True
                txtLugGap_RodEnd.BackColor = Color.Empty
                cmbBushingQuantity_RodEnd.Items.Add(0)
                cmbBushingQuantity_RodEnd.Items.Add(2)
                cmbBushingQuantity_RodEnd.Enabled = True
                cmbBushingQuantity_RodEnd.SelectedIndex = 0
                EnaDisPinHoleForDL(True)
                ObjClsWeldedCylinderFunctionalClass.AddColors(Me)
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd = Val(txtSwingClearance_RodEnd.Text)

            End If
        Catch ex As Exception

        End Try
    End Sub
    'ONSITE:30-05-2010  to enable or disable pin hole controls when selecting threaded type of double lug
    Private Sub EnaDisPinHoleForDL(ByVal blnStatus As Boolean)
        cmbPinHole_RodEnd.Enabled = blnStatus
        cmbPinHoleSizeType_RodEnd.Enabled = blnStatus
        If blnStatus = False Then
            cmbPinHole_RodEnd.Text = ""
            cmbPinHoleSizeType_RodEnd.Text = ""
        End If
    End Sub

    Private Sub txtSwingClearance_RodEnd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSwingClearance_RodEnd.TextChanged
        If cmbRodEndConfiguration_RodEnd.Text = "Double Lug" Then
            If cmbConnectionType.Text = "Threaded" AndAlso txtSwingClearance_RodEnd.Text <> "1.87" Then
                MessageBox.Show("THE CONNECTION TYPE WILL BE CHANGED TO WELDED  BECAUSE THREADED ONLY ACCEPTS 1.870 SWING CLEARANCE", _
                "SWING CLEARANCE CANNOT BE CHANGED ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                cmbConnectionType.Text = "Welded"
            End If
        End If
        If txtSwingClearance_RodEnd.Text <> "" Then
            If txtSwingClearance_RodEnd.Text <> txtSwingClearance_RodEnd.IFLDataTag Then
                txtSwingClearance_RodEnd.IFLDataTag = txtSwingClearance_RodEnd.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd = Val(txtSwingClearance_RodEnd.Text)
            End If
        Else
            txtSwingClearance_RodEnd.IFLDataTag = ""
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd = 0
        End If
    End Sub

    Private Sub txtOffSet_RodEnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        '24_02_2010 Aruna Start --
        'If txtOffSet_RodEnd.Text <> "" Then
        '    If txtOffSet_RodEnd.Text <> txtOffSet_RodEnd.IFLDataTag Then
        '        txtOffSet_RodEnd.IFLDataTag = txtOffSet_RodEnd.Text
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OffSet_RodEnd = Val(txtOffSet_RodEnd.Text)
        '    End If
        'Else
        '    txtOffSet_RodEnd.IFLDataTag = 0
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OffSet_RodEnd = 0
        ' End If
        '24_02_2010 Aruna End --
    End Sub

    Private Sub cmbPinHole_RodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPinHole_RodEnd.SelectedIndexChanged
        If Trim(sender.text) <> "" Then
            If sender.Text = "Standard" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType_RodEnd = "PH"
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType_RodEnd = "BH"
            End If
        End If
    End Sub

    ' ANUP 01-04-2010 11.39
    Private Sub grbBaseEndSelection_RodEnd_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles grbBaseEndSelection_RodEnd.MouseHover, txtSwingClearance_RodEnd.MouseHover, _
    txtCrossTubeWidth_RodEnd.MouseHover, txtLugGap_RodEnd.MouseHover, txtLugThickness_RodEnd.MouseHover, cmbRodEndConfiguration_RodEnd.MouseHover
        '****************
        If cmbRodEndConfiguration_RodEnd.Text <> "" Then
            If cmbRodEndConfiguration_RodEnd.Text = "Cross Tube" Then
                ObjClsWeldedCylinderFunctionalClass.MdiPictureBox.ImageLocation = ObjClsWeldedCylinderFunctionalClass.CurrentWorkingDirectory + "\Images\cross_tube.PNG"
            ElseIf cmbRodEndConfiguration_RodEnd.Text = "Single Lug" Then
                ObjClsWeldedCylinderFunctionalClass.MdiPictureBox.ImageLocation = ObjClsWeldedCylinderFunctionalClass.CurrentWorkingDirectory + "\Images\single_lug.PNG"
            ElseIf cmbRodEndConfiguration_RodEnd.Text = "Double Lug" Then
                ObjClsWeldedCylinderFunctionalClass.MdiPictureBox.ImageLocation = ObjClsWeldedCylinderFunctionalClass.CurrentWorkingDirectory + "\Images\double_lug.PNG"
            Else
                ObjClsWeldedCylinderFunctionalClass.MdiPictureBox.ImageLocation = ""
            End If
        End If
    End Sub

    ' ANUP 01-04-2010 11.39
    Private Sub grbGreaseZerk_RodEnd_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles grbGreaseZerk_RodEnd.MouseHover, txtAngleOfGreaseZercs1_RodEnd.MouseHover, txtAngleOfGreaseZercs2_RodEnd.MouseHover
        '****************
        If cmbGreaseZercs_RodEnd.Text <> "" AndAlso Val(cmbGreaseZercs_RodEnd.Text) >= 1 Then
            ObjClsWeldedCylinderFunctionalClass.MdiPictureBox.ImageLocation = ObjClsWeldedCylinderFunctionalClass.CurrentWorkingDirectory + "\Images\Grease2.jpg"
        Else
            ObjClsWeldedCylinderFunctionalClass.MdiPictureBox.ImageLocation = ""
        End If
    End Sub

    'TODO:  ANUP  20-04-2010 11.00am
    Private Sub cmbStyle_RodEnd_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbStyle_RodEnd.TextChanged
        GreaseZercsAllowedOrNot()
    End Sub

    Private Sub cmbMaterial_RodEnd_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMaterial_RodEnd.TextChanged
        GreaseZercsAllowedOrNot()
        SearchForBushingsData()
    End Sub
    '**********************

    Public Function AreaCalculation() As Boolean
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Drilled Pin Hole" Then
                ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.txtRodMaterialYield.Text))
                Dim dblAreaRequired As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd

                Dim dblAreaOfRod As Double = ObjClsWeldedCylinderFunctionalClass.AreaOfRodWithPinHoleCalculation(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd)

                If dblAreaOfRod < dblAreaRequired Then
                    Dim strMessage As String = "Area is not suffiecient for the selected RodDia or PinHoleDia, Please change one of them. "
                    MessageBox.Show(strMessage, "Area is not suffiecient", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception

        End Try
    End Function
    'ONSITE: 19-05-2010 adding the pinholetype control for Double lug threaded connection
    Private Sub AddItemsToPinHoleType()
        If cmbRodEndConfiguration_RodEnd.Text = "Double Lug" AndAlso cmbConnectionType.Text = "Threaded" Then
            Dim oTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPinHoleTypeData()
            'TODO: ANUP 07-07-2010 10.30am
            cmbPinHoleType.DataSource = PinHoleTypeDataInCapitals(oTable)
            cmbPinHoleType.DisplayMember = "PinHoleType"
            cmbPinHoleType.Text = "Standard"
            cmbPinHoleType.Enabled = True
            cmbPinHoleType.SelectedIndex = 3
        Else
            cmbPinHoleType.Enabled = False
        End If
    End Sub

    'TODO: ANUP 07-07-2010 10.30am
    Private Function PinHoleTypeDataInCapitals(ByVal oTable As DataTable) As DataTable
        PinHoleTypeDataInCapitals = oTable
        For Each oDataRow As DataRow In PinHoleTypeDataInCapitals.Rows
            If oDataRow("PinHoleType") = "aus" Then
                oDataRow("PinHoleType") = "AUS"
            ElseIf oDataRow("PinHoleType") = "bushing" Then
                oDataRow("PinHoleType") = "Bushing"
            ElseIf oDataRow("PinHoleType") = "ind" Then
                oDataRow("PinHoleType") = "IND"
            ElseIf oDataRow("PinHoleType") = "std" Then
                oDataRow("PinHoleType") = "STD"
            End If
        Next
        Return PinHoleTypeDataInCapitals
    End Function
    '**********************

    Private Sub cmbPinHoleType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPinHoleType.SelectedIndexChanged
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType_Threaded_RodEnd_DL = cmbPinHoleType.Text
    End Sub

    'ONSITE:20-05-2010 cross tube width >0
    Private Sub txtCrossTubeWidth_RodEnd_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCrossTubeWidth_RodEnd.Validating
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables._blnIsFocusedInRevision = False Then 'anup 11-02-2011
            If txtCrossTubeWidth_RodEnd.Text <> "" Then
                If Val(txtCrossTubeWidth_RodEnd.Text) = 0 Then
                    MessageBox.Show("Please enter Cross Tube Width value Should be greater than 0.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtCrossTubeWidth_RodEnd.SelectAll()
                    e.Cancel = True
                End If
            End If
        End If  'anup 11-02-2011
    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, lblRodWeldment, LabelGradient4, LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(LabelGradient1)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(LabelGradient5)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(LabelGradient6)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblRodEndSelection)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblBushingDetails)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblPinHoleDetails)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient7)
    End Sub

#End Region


    'ANUP 20-09-2010 START
    Private Sub cmbStyle_RodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStyle_RodEnd.SelectedIndexChanged
        Try
            If IsStyle_2BushingsIndividualBore() Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISBushingStyle_2BushingsIndividualBore_RodEnd = "Yes"
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISBushingStyle_2BushingsIndividualBore_RodEnd = "No"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Function IsStyle_2BushingsIndividualBore() As Boolean
        If cmbRodEndConfiguration_RodEnd.Text = "Cross Tube" Then
            If Trim(cmbStyle_RodEnd.Text) <> "" AndAlso cmbStyle_RodEnd.Text = "2 Bushings individual bores" Then
                Return True
            End If
        End If
        Return False
    End Function
    'ANUP 20-09-2010 TILL HERE

    'ANUP 11-10-2010 START
    Private Sub cmbPinHoleSize_RodEnd_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPinHoleSize_RodEnd.DropDownClosed, txtPinHoleSize_RodEnd.TextChanged, _
                                                                                cmbRodEndConfiguration_RodEnd.DropDownClosed, cmbConnectionType.DropDownClosed, cmbBushingQuantity_RodEnd.DropDownClosed
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.New_Revision = "Revision'" Then
                ObjClsWeldedCylinderFunctionalClass.IsValueChanged_Revision = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    'ANUP 11-10-2010 TILL START

End Class