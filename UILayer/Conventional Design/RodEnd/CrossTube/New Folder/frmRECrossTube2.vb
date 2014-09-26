Public Class frmRECrossTube

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

    Public _strConfigurationDesign As String
    Public _strConfigurationDesignType As String
    Public _strConfigurationCode As String

#Region "Properties"

    'Public ReadOnly Property ControlsData() As ArrayList
    '    Get
    '        ControlsData = New ArrayList
    '        'ControlsData.Add(New Object(3) {"GUI", "RW_DESIGN", "O12", _strConfigurationDesign})
    '        'ControlsData.Add(New Object(3) {"GUI", "RW_DESIGNTYPE", "O13", _strConfigurationDesignType})
    '        'ControlsData.Add(New Object(3) {"GUI", "RW_ROD END CONFIGURATION CODE", "O41", _strConfigurationCode})
    '        'ControlsData.Add(New Object(3) {"DB", "RW_SKIM LENGTH", "O48", 0.25})
    '        ''26_02_2010 AKumari
    '        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = 0.5 - 0.06 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
    '        ''RW_ROD LENGTH = Retracted length - distance from rod pinhole to rod stop - distance from base pinhole to rod stop
    '        'ControlsData.Add(New Object(3) {"CAL", "RW_ROD LENGTH", "O5", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop})
    '        ''RW_RODEND PIN HOLE TO ROD STOP DISTANCE
    '        'ControlsData.Add(New Object(3) {"DB", "RW_RODEND PIN HOLE TO ROD STOP DISTANCE", "O47", (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop) + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop})
    '        Return ControlsData
    '    End Get
    'End Property

    '04_03_2010   RAGAVA
    Public ReadOnly Property ControlsData() As ArrayList
        Get
            ControlsData = New ArrayList
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingYes_RECT.rdbUseSelectedCrossTubeYes.Checked = True Then 'anup 16-02-2011 
                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingYes_RECT.txtPinHoleSize_RECT.Text) <> "" Then
                    ControlsData.Add(New Object(3) {"GUI", "RW_PIN HOLE SIZE", "O26", Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingYes_RECT.txtPinHoleSize_RECT.Text)})
                End If
            End If
            Return ControlsData
        End Get
    End Property
    'Till   Here

#End Region

#Region "Sub Procedures"

    Public Sub ManualLoad()
        ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.IsPrimaryInputsReq = False
        SearchForExistingCrossTubeCastingsRE()
    End Sub

    Private Sub SearchForExistingCrossTubeCastingsRE()
        Try
            'ANUP 11-10-2010 START
            If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
                IsPopulated = True
            End If
            'ANUP 11-10-2010 TILL HERE
            Dim dblRodDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
            'Dim dblWeldSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWeldSize_RECT(dblRodDiameter)
            Dim dblBushingWidth As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth_RodEnd
            Dim dblRequiredPinHoleSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
            Dim dblCrossTubeOD As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd
            Dim dblBushingQuantity As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity_RodEnd
            Dim dblCrossTubeWidth As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd



            '17-02-10 Sandeep
            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd _
                    (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, _
                    clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube_RodEnd_Casting)

            ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.btnPleaseChangeTheRodDiameter.Visible = False
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.btnPleaseChangeTheRodDiameter.SendToBack()

            Dim dblCalculatedWeldSize As Double = Math.Round(ObjClsWeldedCylinderFunctionalClass.WeldSizeCalculation, 3)


            If ObjClsWeldedCylinderFunctionalClass.IsWeldSizeLess Then
                Me.Enabled = False
            Else
                Me.Enabled = True
            End If

            Dim WeldSizeDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWeldSize_ForCasting(dblCalculatedWeldSize, dblRodDiameter)

            If Not IsNothing(WeldSizeDataTable) AndAlso WeldSizeDataTable.Rows.Count > 0 Then

                Dim oDRWeldSize As DataRow = WeldSizeDataTable.Rows(0)

                '04_05_2011  RAGAVA
                If Not (dblRodDiameter = 0.5 OrElse dblRodDiameter = 0.75) Then         '27_09_2011   RAGAVA
                    If dblRodDiameter - (2 * oDRWeldSize("WeldSizeNumeric")) < 0.5 Then
                        GoTo RodWeldValidation
                    End If
                End If
                'Till  Here

                If Not IsNothing(oDRWeldSize) AndAlso oDRWeldSize.ItemArray.Length > 0 Then
                    If Not IsDBNull(oDRWeldSize("WeldSizeNumeric")) Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd = oDRWeldSize("WeldSizeNumeric")
                    End If
                    If Not IsDBNull(oDRWeldSize("Width")) Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.JGrooveWidth_RodEnd = Val(oDRWeldSize("Width")) - (Val(oDRWeldSize("Radius")) - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RadiusConstant)
                    End If
                    'If Not IsDBNull(oDRWeldSize("Radius")) Then
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.JGrooveRadius_RodEnd = oDRWeldSize("Radius")
                    'End If
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.JGrooveRadius_RodEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RadiusConstant
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.Enabled = True
                End If
            Else
RodWeldValidation:  '04_05_2011  RAGAVA
                Dim strMessage As String = "Weld Size exceeds maximum for selected rod (Calculated Weld Size =" + dblCalculatedWeldSize.ToString + " Table Weld Size =" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd.ToString + ")"
                MessageBox.Show(strMessage, "Please change the Rod Diameter", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.Enabled = False
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.btnPleaseChangeTheRodDiameter.Visible = True
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.btnPleaseChangeTheRodDiameter.BringToFront()
            End If

            '************

            Dim dblRequiredArea As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd
            Dim dblSwingClearance As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
            '17-02-10 Sandeep

            Dim oRECrossTubeCastingDetails As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.RECrossTubeCastingDetails( _
                dblRodDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd, dblCrossTubeWidth, dblBushingWidth, dblRequiredPinHoleSize, dblCrossTubeOD, dblBushingQuantity)


            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedRECrossTubeCastingDataTable = New DataTable
            If Not IsNothing(oRECrossTubeCastingDetails) Then

                'TODO:Anup 09-04-10 2pm
                oRECrossTubeCastingDetails.Columns.Add("CalculatedSafetyFactor")
                '*************************

                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedRECrossTubeCastingDataTable = oRECrossTubeCastingDetails.Clone
                For Each oDataRow As DataRow In oRECrossTubeCastingDetails.Rows
                    oDataRow("Area") = Math.Round(oDataRow("CrossTubeWidth") * (oDataRow("CrossTubeOD") - dblRequiredPinHoleSize), 2)
                Next
                For Each oDataRow As DataRow In oRECrossTubeCastingDetails.Rows

                    'TODO:Anup 09-04-10 2pm
                    oDataRow("CalculatedSafetyFactor") = Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor + (oDataRow("Area") / dblRequiredArea), 2) - 1
                    '*************************

                    If Not IsDBNull(oDataRow("Area")) Then
                        If Val(oDataRow("Area")) >= dblRequiredArea Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedRECrossTubeCastingDataTable.Rows.Add(oDataRow.ItemArray)
                        End If
                    End If
                Next
            End If
            If Not IsNothing(oRECrossTubeCastingDetails) AndAlso oRECrossTubeCastingDetails.Rows.Count > 0 Then
                _strConfigurationDesign = "Existing"
            Else
                _strConfigurationDesign = "NewDesign"
                _strConfigurationDesignType = "Cast"
            End If
            ObjClsWeldedCylinderFunctionalClass.ShowCastingNo_Thru_CastingYes_RodEnd = False
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedRECrossTubeCastingDataTable.Rows.Count > 0 Then
                pnlRECTCasting_YesNo.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingYes_RECT.TopLevel = False
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingYes_RECT.Created Then
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingYes_RECT.ManualLoad()
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingYes_RECT.Show()
                pnlRECTCasting_YesNo.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingYes_RECT)
            Else
                pnlRECTCasting_YesNo.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.TopLevel = False
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.Created Then
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.ManualLoad()
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.Show()
                pnlRECTCasting_YesNo.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT)
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Events"

    Private Sub frmRECrossTube_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm() 'ANUP 04-10-2010
        ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.IsPrimaryInputsReq = False
        SearchForExistingCrossTubeCastingsRE()
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, LabelGradient5, LabelGradient4, LabelGradient2)
    End Sub

End Class