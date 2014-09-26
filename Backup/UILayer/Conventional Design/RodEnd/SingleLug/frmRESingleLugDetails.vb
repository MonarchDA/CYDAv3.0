Public Class frmRESingleLugDetails

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

    'Private _oMatchedRESingleLugDataTable As DataTable

    Private _dblTempNutSafetyFactor As Double = 0

    Private _dblTempPinHoleSize As Double = 0

    Private _dblTempSwingClearance As Double = 0

    Private _dblWorkingPressure As Double = 0

    Private _intClass As Integer = 0

    Private _dblLugThickness As Double = 0

    Private _intSafetyFactorCount As Integer = 0

    'Public _strConfigurationDesign As String

    'Private _strConfigurationDesignType As String

    ' Private _strConfigurationCode As String
    Private _oFabrication_DesignNewSingleLugDataTable As DataTable

    'ANUP 01-03-2010 04.37
    Dim _dblTempRodDiameter As Double

    Dim _dblTempBushingWidth As Double

    Dim _dblTempRequiredLugThickness As Double

    Dim _dblTempRequiredPinHoleSize As Double

    Dim _dblTempBushingQuantity As Double

    Dim _dblTempLugWidth As Double
    '***********************

#End Region

#Region "Properties"

    Public ReadOnly Property ControlsData() As ArrayList
        Get
            ControlsData = New ArrayList
          
            Return ControlsData
        End Get
    End Property

#End Region

#Region "Enum"

    Public Enum RESingleLugListViewDetails
        CodeNumber = 0
        Description = 1
        Cost = 2
        IFLID = 3
        Configuration = 4
    End Enum

    Public Enum WeightListView
        SafetyFactor = 0
        LugThickness = 1
        Weight = 2
    End Enum

#End Region

#Region "Sub Procedures"

    Public Sub ManualLoad()
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        ' ANUP 19-03-2010 12.31
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter <> _dblTempRodDiameter _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth_RodEnd <> _dblTempBushingWidth _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd <> _dblTempRequiredLugThickness _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd <> _dblTempRequiredPinHoleSize _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd <> _dblTempSwingClearance _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity_RodEnd <> _dblTempBushingQuantity Then
            ' OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd <> _dblTempLugWidth Then
            _dblTempRodDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
            _dblTempBushingWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth_RodEnd
            _dblTempRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
            _dblTempRequiredPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
            _dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
            _dblTempBushingQuantity = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity_RodEnd
            ' _dblTempLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd

            SearchForExistingRodEndSingleLugDetails()
            lvwSafetyFactor_Weight_RodEnd.Items.Clear()
            _intSafetyFactorCount = 0

            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            If Not IsNothing(_oFabrication_DesignNewSingleLugDataTable) AndAlso _oFabrication_DesignNewSingleLugDataTable.Rows.Count > 0 Then
                InitialSettings_RESLMatchFound()
            Else
                InitialSettings_RESLMatchNotFound()
            End If
        End If
        '***********************
    End Sub

    Private Sub SearchForExistingRodEndSingleLugDetails()
        ' ANUP 19-03-2010 12.31
        'Dim dblRodDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
        'Dim dblBushingWidth As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth_RodEnd
        'Dim dblRequiredLugThickness As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
        'Dim dblRequiredPinHoleSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
        'Dim dblBushingQuantity As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity_RodEnd
        'Dim dblSwingClearance As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
        'Dim dblLugWidth As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd
        _dblTempRodDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
        _dblTempBushingWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth_RodEnd
        _dblTempRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
        _dblTempRequiredPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd

        'ANUP 17-09-2010 START
        _dblTempSwingClearance = Val(ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Text)
        'ANUP 17-09-2010 TILL HERE

        _dblTempBushingQuantity = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity_RodEnd
        '_dblTempLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd
        '***************************
        Try
            'Dim dblWeldSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWeldSize_RESL(_dblTempRodDiameter)

            btnPleaseChangeTheRodDiameter.Visible = False

            'TODO: ANUP 28-04-2010 01.03pm
            Dim dblCalculatedWeldSize As Double = ObjClsWeldedCylinderFunctionalClass.WeldSizeCalculation
            'TODO: ANUP 31-05-2010 10.13am
            If ObjClsWeldedCylinderFunctionalClass.IsWeldSizeLess Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmRESLDetails.Enabled = False
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjFrmRESLDetails.Enabled = True
            End If
            '***********

            Dim WeldSizeDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWeldSize_ForCasting(dblCalculatedWeldSize, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter)

            If Not IsNothing(WeldSizeDataTable) AndAlso Not WeldSizeDataTable.Rows.Count <= 0 Then

                Dim oDRWeldSize As DataRow = WeldSizeDataTable.Rows(0)
                If Not IsNothing(oDRWeldSize) OrElse oDRWeldSize.ItemArray.Length <= 0 Then

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
                    Me.Enabled = True

                    ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True

                End If
            Else
                MessageBox.Show("Weld Size exceeds maximum for selected rod, Please change the Rod Diameter.", "Weld Size is maximum", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                Me.Enabled = False
                btnPleaseChangeTheRodDiameter.Visible = True
                ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
                btnPleaseChangeTheRodDiameter.BringToFront()
                btnPleaseChangeTheRodDiameter.Location = New Point(142, 193)
                Exit Sub
            End If

            '************

            _oFabrication_DesignNewSingleLugDataTable = New DataTable
            _oFabrication_DesignNewSingleLugDataTable.Columns.Add("PartCode")
            _oFabrication_DesignNewSingleLugDataTable.Columns.Add("Description")
            _oFabrication_DesignNewSingleLugDataTable.Columns.Add("Cost")
            _oFabrication_DesignNewSingleLugDataTable.Columns.Add("IFLID")
            _oFabrication_DesignNewSingleLugDataTable.Columns.Add("Configuration")
            'TODO:Anup 09-04-10 2pm
            _oFabrication_DesignNewSingleLugDataTable.Columns.Add("CalculatedSafetyFactor")

            '<<--20-12-2010 Aruna--
            _oFabrication_DesignNewSingleLugDataTable.Columns.Add("IsExisted")
            '--20-12-2010 Aruna-->>


            '*************************
            '5_3_2010 Aruna 
            Dim oCombinedDataRow As DataRow
            'Dim strPinWithInTubeDia As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinWithInTubeDiameter
            'Dim dblTubeOD As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD
            'Dim oSingleLugDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
            'BESingleLUgDetails(dblBushingQuantity, dblBushingWidth, dblRequiredPinHoleSize, dblRequiredLugThickness, strPinWithInTubeDia, dblTubeOD, dblSwingClearance, "Rod End")

            'If Not IsNothing(oSingleLugDataTable) AndAlso oSingleLugDataTable.Rows.Count > 0 Then

            '    Dim oFilterWithAreaDataTable As DataTable
            '    oFilterWithAreaDataTable = New DataTable
            '    oFilterWithAreaDataTable = oSingleLugDataTable.Clone

            '    For Each oFilterWithAreaDataRow As DataRow In oSingleLugDataTable.Rows
            '        '24_02_2010 Aruna Start
            '        'oFilterWithAreaDataRow("Area") = (oFilterWithAreaDataRow("Width") - dblRequiredPinHoleSize) * oFilterWithAreaDataRow("Thickness") * 2
            '        oFilterWithAreaDataRow("Area") = Math.Round((oFilterWithAreaDataRow("Width") - dblRequiredPinHoleSize) * oFilterWithAreaDataRow("Thickness"), 2)
            '        '24_02_2010 Aruna End
            '    Next

            '    For Each oFilterWithAreaDataRow2Row As DataRow In oSingleLugDataTable.Rows
            '        ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd(ObjClsWeldedCylinderFunctionalClass. _
            '        ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, oFilterWithAreaDataRow2Row("YieldStrength"))    '12_11_2009  Ragava
            '        Dim dblRequiredArea As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd
            '        If Val(oFilterWithAreaDataRow2Row("Area")) >= dblRequiredArea AndAlso Val(oFilterWithAreaDataRow2Row("Area")) <= Val(dblRequiredArea * 1.25) Then
            '            oCombinedDataRow = _oFabrication_DesignNewSingleLugDataTable.NewRow
            '            oCombinedDataRow("PartCode") = oFilterWithAreaDataRow2Row("PartCode")
            '            oCombinedDataRow("Description") = oFilterWithAreaDataRow2Row("Description")
            '            oCombinedDataRow("Cost") = oFilterWithAreaDataRow2Row("Cost")
            '            oCombinedDataRow("IFLID") = oFilterWithAreaDataRow2Row("IFLID")
            '            oCombinedDataRow("Configuration") = "Fabrication"
            '            _oFabrication_DesignNewSingleLugDataTable.Rows.Add(oCombinedDataRow)
            '        End If
            '    Next

            'End If
            Dim oRESLDetails As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetRESLDetails(_dblTempRodDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd, _dblTempRequiredPinHoleSize, _
                                              _dblTempRequiredLugThickness, _dblTempSwingClearance)
            If Not IsNothing(oRESLDetails) Then
                For Each oDataRow As DataRow In oRESLDetails.Rows
                    oDataRow("Area") = Math.Round(oDataRow("LugThickness") * (oDataRow("LugWidth") - _dblTempRequiredPinHoleSize), 2)
                Next

                For Each oDataRow As DataRow In oRESLDetails.Rows
                    If Not IsDBNull(oDataRow("Area")) Then
                        ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd(ObjClsWeldedCylinderFunctionalClass. _
                        ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, oDataRow("YieldStrength"))
                        Dim dblRequiredArea As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd
                        Dim dblRequiredLugWidth As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd
                        Dim blnLugWidthCondition_Satisfied As Boolean = False
                        If _dblTempBushingQuantity = 2 Then
                            If oDataRow("LugWidth") >= (_dblTempBushingWidth * 2 + 0.125) AndAlso oDataRow("LugWidth") <= (_dblTempBushingWidth * 2 * 1.5) Then
                                blnLugWidthCondition_Satisfied = True
                            End If
                        ElseIf _dblTempBushingQuantity = 1 Then
                            If oDataRow("LugWidth") = _dblTempBushingWidth Then
                                blnLugWidthCondition_Satisfied = True
                            End If
                        ElseIf _dblTempBushingQuantity = 0 Then
                            If oDataRow("LugWidth") >= dblRequiredLugWidth AndAlso oDataRow("LugWidth") <= dblRequiredLugWidth + 0.5 Then
                                blnLugWidthCondition_Satisfied = True
                            End If
                        End If
                        If Val(oDataRow("Area")) >= dblRequiredArea Then 'AndAlso Val(oDataRow("Area")) <= Val(dblRequiredArea * 1.25) Then    '05_04_2010   RAGAVA
                            If blnLugWidthCondition_Satisfied Then
                                oCombinedDataRow = _oFabrication_DesignNewSingleLugDataTable.NewRow
                                oCombinedDataRow("PartCode") = oDataRow("PartCode")
                                oCombinedDataRow("Description") = oDataRow("Description")
                                oCombinedDataRow("Cost") = oDataRow("Cost")
                                oCombinedDataRow("IFLID") = oDataRow("IFLID")
                                oCombinedDataRow("Configuration") = "Cast"
                                oCombinedDataRow("CalculatedSafetyFactor") = Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor + (oDataRow("Area") / dblRequiredArea), 2)
                                _oFabrication_DesignNewSingleLugDataTable.Rows.Add(oCombinedDataRow)
                            End If
                        End If
                    End If
                Next
            End If
            If Not IsNothing(_oFabrication_DesignNewSingleLugDataTable) AndAlso _oFabrication_DesignNewSingleLugDataTable.Rows.Count > 0 Then
                '_strConfigurationDesign = "Existing"
                RESingleLugDetails_MatchFound_Functionality()
            Else
                ' _strConfigurationDesign = "New"
                ' _strConfigurationDesignType = "Cast"
                RESingleLugDetails_MatchNotFound_Functionality()
            End If


        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in SearchForExistingRodEndSingleLugDetails of frmRESingleLugDetails " + ex.Message)
        End Try
    End Sub

    'Match Found
    Private Sub RESingleLugDetails_MatchFound_Functionality()
        plnMatchingSingleLugREFound.Visible = True
        pnlMatchingSingleLugNotFound.Visible = False
        PopulateIn_RESL_MatchFound_ListView()
    End Sub

    Private Sub InitialSettings_RESLMatchFound()
        txtCodeNumber_RodEnd.Enabled = False
        txtLugThickness_RodEnd.Enabled = False
        txtRequiredLugThickness_RodEnd.Enabled = False
        txtLugsWidth_RodEnd.Enabled = False
        txtRequiredLugsWidth_RodEnd.Enabled = False
        txtPinHoleSize_RodEnd.Enabled = False
        txtRequiredPinHoleSize_RodEnd.Enabled = False
        txtLugHeight_RodEnd.Enabled = False
        txtRequiredLugHeight_RodEnd.Enabled = False
        txtSwingClearance_RodEnd.Enabled = False
        txtRequiredSwingClearance_RodEnd.Enabled = False
        txtGreaseZerk_RodEnd.Enabled = False
        txtRequiredGreaseZerk_RodEnd.Enabled = False
        txtAngle1_RodEnd.Enabled = False
        txtRequiredAngle1_RodEnd.Enabled = False
        txtAngle2_RodEnd.Enabled = False
        txtRequiredAngle2_RodEnd.Enabled = False

        '  grbNotExactMatch_RodEnd.Enabled = False '5_3_2010 Aruna
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False

        'chkUseSelectedSingleLugCasting_RodEnd.Checked = True
        'TODO:24-02-10 Sandeep
        btnAccept_RodEnd.Enabled = False

        txtRequiredSwingClearance_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
        txtRequiredLugThickness_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
        txtRequiredPinHoleSize_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
        txtRequiredLugsWidth_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd
        txtRequiredGreaseZerk_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs_RodEnd
        txtRequiredAngle1_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1_RodEnd
        txtRequiredAngle2_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1_RodEnd

        ' Sandeep 25-02-10 10am
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False

        DisableReqPinToleranceControls()
    End Sub

    'ONSITE: 26-05-2010 To disable the required tolerace and display the content
    Private Sub DisableReqPinToleranceControls()
        txtPinHoleTole_Neg_Req.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd
        txtPinHoleTole_Pos_Req.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd
        txtPinHoleTole_Pos_Req.Enabled = False
        txtPinHoleTole_Neg_Req.Enabled = False
        txtPinHoleTole_Pos.Enabled = False
        txtPinHoleTole_Neg.Enabled = False
    End Sub

    Private Sub PopulateIn_RESL_MatchFound_ListView()
        lvwRodEndSingleLugListView_RodEnd.Clear()
        lvwRodEndSingleLugListView_RodEnd.Columns.Add("Code No", 100, HorizontalAlignment.Center)
        lvwRodEndSingleLugListView_RodEnd.Columns.Add("Description", 220, HorizontalAlignment.Center)

        'TODO:Anup 09-04-10 2pm
        lvwRodEndSingleLugListView_RodEnd.Columns.Add("SafetyFactor", 100, HorizontalAlignment.Center)
        '***********

        lvwRodEndSingleLugListView_RodEnd.Columns.Add("Cost", 100, HorizontalAlignment.Center)
        lvwRodEndSingleLugListView_RodEnd.Columns.Add("Sales", 100, HorizontalAlignment.Center)        '28_11_2012   RAGAVA

        lvwRodEndSingleLugListView_RodEnd.Columns.Add("IFLID", 45, HorizontalAlignment.Center)
        lvwRodEndSingleLugListView_RodEnd.Columns.Add("Configuration", 100, HorizontalAlignment.Center)

        '<<--20-12-2010 Aruna--
        lvwRodEndSingleLugListView_RodEnd.Columns.Add("Is Existed", 45, HorizontalAlignment.Center)
        '--20-12-2010 Aruna-->>
        lvwRodEndSingleLugListView_RodEnd.Scrollable = False
        Dim intCount As Integer = 0
        Dim oListItem As ListViewItem
        Try
            If Not IsNothing(_oFabrication_DesignNewSingleLugDataTable) AndAlso _oFabrication_DesignNewSingleLugDataTable.Rows.Count > 0 Then
                Dim strPartCode_Purchase As String = String.Empty
                'ANUP 07-10-2010 START
                If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Count > 0 Then
                    ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Clear()
                End If
                'ANUP 07-10-2010 TILL HERE 

                For Each oMatchedRESLDataRow As DataRow In _oFabrication_DesignNewSingleLugDataTable.Rows
                    If Not IsDBNull(oMatchedRESLDataRow("PartCode")) Then

                        'ANUP 07-10-2010 START
                        strPartCode_Purchase = ObjClsWeldedCylinderFunctionalClass.PartCOde_Purchased_ListViewClickedValidation(oMatchedRESLDataRow("PartCode"))
                        oListItem = lvwRodEndSingleLugListView_RodEnd.Items.Add(strPartCode_Purchase)
                        'ANUP 07-10-2010 TILL HERE
                    Else
                        oListItem = lvwRodEndSingleLugListView_RodEnd.Items.Add("")
                    End If

                    If Not IsDBNull(oMatchedRESLDataRow("Description")) Then
                        lvwRodEndSingleLugListView_RodEnd.Items(intCount).SubItems.Add(oMatchedRESLDataRow("Description"))
                    Else
                        lvwRodEndSingleLugListView_RodEnd.Items(intCount).SubItems.Add("")
                    End If




                    '31_05_2011  RAGAVA
                    Try
                        Dim dblSafetyFactor As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SetSafetyFactorForExisting_RodEnd(strPartCode_Purchase)
                        If dblSafetyFactor > 0 Then
                            lvwRodEndSingleLugListView_RodEnd.Items(intCount).SubItems.Add(dblSafetyFactor.ToString)
                        Else
                            If Not IsDBNull(oMatchedRESLDataRow("CalculatedSafetyFactor")) Then
                                lvwRodEndSingleLugListView_RodEnd.Items(intCount).SubItems.Add(oMatchedRESLDataRow("CalculatedSafetyFactor"))
                            Else
                                lvwRodEndSingleLugListView_RodEnd.Items(intCount).SubItems.Add("")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    ''TODO:Anup 09-04-10 2pm
                    'If Not IsDBNull(oMatchedRESLDataRow("CalculatedSafetyFactor")) Then
                    '    lvwRodEndSingleLugListView_RodEnd.Items(intCount).SubItems.Add(oMatchedRESLDataRow("CalculatedSafetyFactor"))
                    'Else
                    '    lvwRodEndSingleLugListView_RodEnd.Items(intCount).SubItems.Add("")
                    'End If
                    ''***************
                    'TILL    HERE

                    '28_11_2012  RAGAVA
                    Try
                        ObjClsWeldedCylinderFunctionalClass.GetCost_Sales(oMatchedRESLDataRow("PartCode"), lvwRodEndSingleLugListView_RodEnd, intCount)
                    Catch ex As Exception

                    End Try
                    'If Not IsDBNull(oMatchedRESLDataRow("Cost")) Then
                    '    lvwRodEndSingleLugListView_RodEnd.Items(intCount).SubItems.Add(oMatchedRESLDataRow("Cost"))
                    'Else
                    '    lvwRodEndSingleLugListView_RodEnd.Items(intCount).SubItems.Add("")
                    'End If
                    'Till  Here

                    If Not IsDBNull(oMatchedRESLDataRow("IFLID")) Then
                        lvwRodEndSingleLugListView_RodEnd.Items(intCount).SubItems.Add(oMatchedRESLDataRow("IFLID"))
                    Else
                        lvwRodEndSingleLugListView_RodEnd.Items(intCount).SubItems.Add("")
                    End If

                    If Not IsDBNull(oMatchedRESLDataRow("Configuration")) Then
                        lvwRodEndSingleLugListView_RodEnd.Items(intCount).SubItems.Add(oMatchedRESLDataRow("Configuration"))
                    Else
                        lvwRodEndSingleLugListView_RodEnd.Items(intCount).SubItems.Add("")
                    End If
                    '<<--20-12-2010 Aruna--
                    If Not IsDBNull(oMatchedRESLDataRow("IsExisted")) Then
                        If oMatchedRESLDataRow("IsExisted") = True Then
                            lvwRodEndSingleLugListView_RodEnd.Items(intCount).SubItems.Add("Yes")
                        Else
                            lvwRodEndSingleLugListView_RodEnd.Items(intCount).SubItems.Add("No")
                        End If
                    Else
                        lvwRodEndSingleLugListView_RodEnd.Items(intCount).SubItems.Add("No")
                    End If
                    '--20-12-2010 Aruna-->>
                    intCount += 1
                Next
            End If
            lvwRodEndSingleLugListView_RodEnd.HideSelection = False
            lvwRodEndSingleLugListView_RodEnd.FullRowSelect = True
            'If lvwRodEndSingleLugListView_RodEnd.Items.Count > 0 Then
            '    lvwRodEndSingleLugListView_RodEnd.Items(0).Selected = True
            'End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in PopulateIn_RESL_MatchFound_ListView of frmRESingleLugDetails " + ex.Message)
        End Try
    End Sub

    'Match Not Found
    Private Sub RESingleLugDetails_MatchNotFound_Functionality()
        plnMatchingSingleLugREFound.Visible = False
        pnlMatchingSingleLugNotFound.Visible = True
        RESLMatchNotFoundFunctionality()
    End Sub

    Private Sub InitialSettings_RESLMatchNotFound()
        btnAccept_RodEnd.Enabled = False
        txtSafetyFactor_DesignSingleLug_RodEnd.Enabled = False
        txtLugWidth_DesignSingleLug_RodEnd.Enabled = False
        txtLugThickness_DesignSingleLug_RodEnd.Enabled = True
        txtPinHoleSize_DesignSingleLug_RodEnd.Enabled = False
        txtSwingClearance_DesignSingleLug_RodEnd.Enabled = False
        SafetyFactor_LugThickness_Weight_GeneretedDesign()

        ' grbNotExactMatch_RodEnd.Enabled = False '5_3_2010 Aruna
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False

    End Sub

    Private Sub SafetyFactor_LugThickness_Weight_GeneretedDesign()
        lvwSafetyFactor_Weight_RodEnd.Clear()
        lvwSafetyFactor_Weight_RodEnd.Columns.Add("SafetyFactor", 130, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight_RodEnd.Columns.Add("LugThickness", 130, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight_RodEnd.Columns.Add("Weight", 125, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight_RodEnd.FullRowSelect = True
    End Sub

    Private Sub RESLMatchNotFoundFunctionality()
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor <> _dblTempNutSafetyFactor _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize <> _dblTempPinHoleSize _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance <> _dblTempSwingClearance _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure <> _dblWorkingPressure _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass <> _intClass _
         OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness <> _dblLugThickness Then
            _dblTempNutSafetyFactor = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor
            _dblTempPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd

            'ANUP 17-09-2010 START
            '_dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
            _dblTempSwingClearance = Val(ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Text)
            'ANUP 17-09-2010 TILL HERE

            _dblWorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure
            _intClass = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass
            _dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd

            ' ANUP 19-03-2010 11.00
            lvwSafetyFactor_Weight_RodEnd.Items.Clear()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            _intSafetyFactorCount = 0
            '***************

            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd _
         (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, _
                     clsWeldedCylinderFunctionalClass.YeildStrengthConstants.SingleLug_Cast_NoPort)
            txtLugWidth_DesignSingleLug_RodEnd.Text = Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd, 3)
            txtLugThickness_DesignSingleLug_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
            txtPinHoleSize_DesignSingleLug_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd

            'ANUP 17-09-2010 START
            txtSwingClearance_DesignSingleLug_RodEnd.Text = Val(ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Text)
            'ANUP 17-09-2010 TILL HERE

            trbSafetyFactor_RodEnd.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
            trbSafetyFactor_RodEnd.Maximum = trbSafetyFactor_RodEnd.Minimum + 20
            trbSafetyFactor_RodEnd.TickFrequency = 1
            trbSafetyFactor_RodEnd.Value = trbSafetyFactor_RodEnd.Minimum
            'TODO:Sunny 26-02-10
            Dim dblSafetyFactor As Double = trbSafetyFactor_RodEnd.Minimum + ((trbSafetyFactor_RodEnd.Value - trbSafetyFactor_RodEnd.Minimum) * 0.25)
            txtSafetyFactor_DesignSingleLug_RodEnd.Text = dblSafetyFactor

        End If
    End Sub

    Private Sub WidthCalculation()
        Dim dblSafetyFactor As Double = trbSafetyFactor_RodEnd.Minimum + ((trbSafetyFactor_RodEnd.Value - trbSafetyFactor_RodEnd.Minimum) * 0.25)
        txtSafetyFactor_DesignSingleLug_RodEnd.Text = dblSafetyFactor
        ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd(dblSafetyFactor, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.SingleLug_Cast_NoPort)           '11-12-2009  Ragava
        txtLugWidth_DesignSingleLug_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd
    End Sub

    Private Sub UpdatePreviousFormDetails()
        'Sandeep 25-02-10 10am
        Dim strMessage As String = "Rod end Configuration Details will be updated with the selected SingleLug casting details, " + vbCrLf
        If MessageBox.Show(strMessage, "Update TubeDetails", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then

            If txtSwingClearance_RodEnd.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Text = txtSwingClearance_RodEnd.Text
            End If

            If txtLugThickness_RodEnd.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_RodEnd.Text = txtLugThickness_RodEnd.Text
            End If

            If ObjClsWeldedCylinderFunctionalClass.PinHoleSize_source_RodEnd = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.BushingPinHole Then
                If txtPinHoleSize_RodEnd.Text <> "" Then
                    ObjClsWeldedCylinderFunctionalClass.CmbBushingPinHoleSize_RodEnd.Text = txtPinHoleSize_RodEnd.Text
                End If
            ElseIf ObjClsWeldedCylinderFunctionalClass.PinHoleSize_source_RodEnd = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleCustom Then
                If txtPinHoleSize_RodEnd.Text <> "" Then
                    ObjClsWeldedCylinderFunctionalClass.TxtPinHoleSize_RodEnd.Text = txtPinHoleSize_RodEnd.Text
                End If
            ElseIf ObjClsWeldedCylinderFunctionalClass.PinHoleSize_source_RodEnd = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleStandard Then
                If txtPinHoleSize_RodEnd.Text <> "" Then
                    ObjClsWeldedCylinderFunctionalClass.CmbPinHoleSize_RodEnd.Text = txtPinHoleSize_RodEnd.Text
                End If
            End If

            If txtLugsWidth_RodEnd.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd = Val(txtLugsWidth_RodEnd.Text)
            End If

            If txtGreaseZerk_RodEnd.Text <> "" AndAlso txtGreaseZerk_RodEnd.Text <> "N/A" Then
                ObjClsWeldedCylinderFunctionalClass.CmbGreaseZercs_RodEnd.Text = txtGreaseZerk_RodEnd.Text
            End If

            If txtAngle1_RodEnd.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtAngleOfGreaseZercs1_RodEnd.Text = txtAngle1_RodEnd.Text
            End If

            If txtAngle2_RodEnd.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtAngleOfGreaseZercs2_RodEnd.Text = txtAngle2_RodEnd.Text
            End If

            'anup 31-08-2010
            If Not String.IsNullOrEmpty(txtPinHoleTole_Pos.Text) Then
                ObjClsWeldedCylinderFunctionalClass.TxtToleranceUpperLimit_RodEnd.Text = txtPinHoleTole_Pos.Text
            End If
            If Not String.IsNullOrEmpty(txtPinHoleTole_Neg.Text) Then
                ObjClsWeldedCylinderFunctionalClass.TxtToleranceLowerLimit_RodEnd.Text = txtPinHoleTole_Neg.Text
            End If
        End If
    End Sub

#End Region

#Region "Events"

    Private Sub frmRESLDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        ColorTheForm()
        SearchForExistingRodEndSingleLugDetails()
        If Not IsNothing(_oFabrication_DesignNewSingleLugDataTable) AndAlso _oFabrication_DesignNewSingleLugDataTable.Rows.Count > 0 Then
            InitialSettings_RESLMatchFound()
        Else
            InitialSettings_RESLMatchNotFound()
        End If
    End Sub

    Private Sub btnGenerate_RodEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate_RodEnd.Click
        Me.Cursor = Cursors.WaitCursor

        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Cast"

        'ANUP 17-09-2010 START
        If ObjClsWeldedCylinderFunctionalClass.SwingClearanceValidation_PartCondition_RodEnd Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd = Val(ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Text) + 0.0625
        End If
        'ANUP 17-09-2010 TILL HERE

        Dim blnDuplicateFound As Boolean = False
        Try

            '5_3_2010 Aruna
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = _
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd 



            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = _
                       ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd + 0.5 'TODO: ANUP 01-06-2010  10.51am

            If txtSafetyFactor_DesignSingleLug_RodEnd.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_RodEnd = txtSafetyFactor_DesignSingleLug_RodEnd.Text
            End If

            If txtLugThickness_RodEnd.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_RodEnd.Text = txtLugThickness_RodEnd.Text
            End If
            Dim dblLugHeight As Double
            dblLugHeight = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd / 2)
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.lugHeight_RodEnd = dblLugHeight
            Dim strFilePart As String = ""
            Dim strFilePartDesignTableExcel As String = ""
            Dim strName As String = "NewSingleLugRodEndNewDesignPart"
            'ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_END_SINGLE_LUG_CAST")
            'strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_END_SINGLE_LUG_CAST\ROD_END_SINGLE_LUG_CAST.SLDPRT"
            ''24_02_2010 Aruna 
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "ROD_END_SINGLE_LUG_CAST"
            '25_02_2010 Aruna 

            '05_03_2010    RAGAVA
            'ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\SINGLE_LUG_ROD")
            'strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\SINGLE_LUG_ROD\SINGLE_LUG_ROD.SLDPRT"
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "SINGLE_LUG_ROD"
            'strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\SINGLE_LUG_ROD.XLS"
            ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_END_SINGLE_LUG_CAST")
            strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_END_SINGLE_LUG_CAST\ROD_END_SINGLE_LUG_CAST.SLDPRT"
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "ROD_END_SINGLE_LUG_CAST"
            strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\ROD_END_SINGLE_LUG_CAST.XLS"
            'Till   Here
            'Aruna 19_3_2010
            ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_END_SINGLE_LUG_CAST", True)
            ObjClsWeldedCylinderFunctionalClass.Design_New_Part(strFilePart, strFilePartDesignTableExcel, strName)
            ObjClsWeldedCylinderFunctionalClass.GenerateCasting = False '20_11_2009  Ragava
            Dim dblWeight As Double = ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Weight")

            If lvwSafetyFactor_Weight_RodEnd.Items.Count > 0 Then
                For Each oItem As ListViewItem In lvwSafetyFactor_Weight_RodEnd.Items
                    If oItem.SubItems(WeightListView.SafetyFactor).Text.Equals(txtSafetyFactor_DesignSingleLug_RodEnd.Text) AndAlso _
                     oItem.SubItems(WeightListView.LugThickness).Text.Equals(txtLugThickness_DesignSingleLug_RodEnd.Text) Then
                        blnDuplicateFound = True
                    End If
                Next
            End If
            If Not blnDuplicateFound Then
                Dim oListViewItem As ListViewItem
                oListViewItem = lvwSafetyFactor_Weight_RodEnd.Items.Add(txtSafetyFactor_DesignSingleLug_RodEnd.Text)
                lvwSafetyFactor_Weight_RodEnd.Items(_intSafetyFactorCount).SubItems.Add(txtLugThickness_DesignSingleLug_RodEnd.Text)
                lvwSafetyFactor_Weight_RodEnd.Items(_intSafetyFactorCount).SubItems.Add(dblWeight)
                _intSafetyFactorCount += 1
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub trbSafetyFactor_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trbSafetyFactor_RodEnd.Scroll
        For Each oItem As ListViewItem In lvwSafetyFactor_Weight_RodEnd.Items
            oItem.Selected = False
        Next
    End Sub

    Private Sub trbSafetyFactor_RodEnd_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trbSafetyFactor_RodEnd.ValueChanged
        WidthCalculation()
    End Sub

    Private Sub txtLugThickness_DesignSingleLug_RodEnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLugThickness_DesignSingleLug_RodEnd.Leave
        If txtLugThickness_DesignSingleLug_RodEnd.Text <> "" Then
            If txtLugThickness_DesignSingleLug_RodEnd.Text <> txtLugThickness_DesignSingleLug_RodEnd.IFLDataTag Then
                txtLugThickness_DesignSingleLug_RodEnd.IFLDataTag = txtLugThickness_DesignSingleLug_RodEnd.Text
                trbSafetyFactor_RodEnd.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
                trbSafetyFactor_RodEnd.Maximum = trbSafetyFactor_RodEnd.Minimum + 20
                trbSafetyFactor_RodEnd.TickFrequency = 1
                trbSafetyFactor_RodEnd.Value = trbSafetyFactor_RodEnd.Minimum
                Dim dblSafetyFactor As Double = trbSafetyFactor_RodEnd.Minimum + ((trbSafetyFactor_RodEnd.Value - trbSafetyFactor_RodEnd.Minimum) * 0.25)
                txtSafetyFactor_DesignSingleLug_RodEnd.Text = dblSafetyFactor
            End If
        Else
            txtLugThickness_DesignSingleLug_RodEnd.IFLDataTag = ""
        End If
    End Sub

    Private Sub btnAccept_RodEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept_RodEnd.Click
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = 0.36 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd / 2

        If txtSafetyFactor_DesignSingleLug_RodEnd.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_RodEnd = txtSafetyFactor_DesignSingleLug_RodEnd.Text
        End If

        If txtLugThickness_RodEnd.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_RodEnd.Text = txtLugThickness_RodEnd.Text
        End If
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = False        '20_10_2010   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        btnAccept_RodEnd.Enabled = False
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Cast"
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "NewDesign"
        '5_3_2010 Aruna
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnd_NewDesign_TableName = "WELDED.RESLDetails"
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Cast"
        '25_02_2010 Aruna
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Fabricated"
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Cast"         '05_03_2010    RAGAVA
        ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Cast"
    End Sub

    Private Sub lvwSafetyFactor_Weight_RodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwSafetyFactor_Weight_RodEnd.SelectedIndexChanged
        If lvwSafetyFactor_Weight_RodEnd.SelectedIndices.Count > 0 Then
            Dim oListViewSelectedItem As ListViewItem = lvwSafetyFactor_Weight_RodEnd.SelectedItems(0)
            trbSafetyFactor_RodEnd.Value = ((Val(oListViewSelectedItem.SubItems(WeightListView.SafetyFactor).Text) - trbSafetyFactor_RodEnd.Minimum) / 0.25) + trbSafetyFactor_RodEnd.Minimum
            txtLugThickness_DesignSingleLug_RodEnd.Text = oListViewSelectedItem.SubItems(WeightListView.LugThickness).Text
            btnAccept_RodEnd.Enabled = True
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            ObjClsWeldedCylinderFunctionalClass.RodEndWeight = Val(oListViewSelectedItem.SubItems(WeightListView.Weight).Text)
        End If
    End Sub

    Private Sub lvwRodEndSingleLugListView_RodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwRodEndSingleLugListView_RodEnd.SelectedIndexChanged
        'ANUP 10-11-2010 START
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        rdbUseSelectedSingleLugYes.Checked = False
        rdbResize_RodEnd.Checked = False
        'ANUP 10-11-2010 TILL HERE
        Try
            If lvwRodEndSingleLugListView_RodEnd.SelectedIndices.Count > 0 Then

                ' Sandeep 25-02-10 10am
                ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False

                Dim oListViewSelectedItem As ListViewItem = lvwRodEndSingleLugListView_RodEnd.SelectedItems(0)
                Dim oSelectedRESLDataRow As DataRow = Nothing

                'ANUP 07-10-2010 START
                Dim strPartCodePassing_Purchased As String = oListViewSelectedItem.SubItems(RESingleLugListViewDetails.CodeNumber).Text
                Try
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_RodEnd = oListViewSelectedItem.SubItems(2).Text      '31_05_2011   ragava
                Catch ex As Exception
                End Try
                ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode = strPartCodePassing_Purchased         '12_10_2010   RAGAVA
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndCastingCodeNumber = strPartCodePassing_Purchased   '07_02_2011 
                If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.ContainsKey(strPartCodePassing_Purchased) Then
                    strPartCodePassing_Purchased = ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Item(strPartCodePassing_Purchased).ToString
                End If

                If oListViewSelectedItem.SubItems(RESingleLugListViewDetails.Configuration).Text = "Fabrication" Then
                    oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                                           GetREBESingleLugDetails_FabricationSelectedRowDetails(strPartCodePassing_Purchased)
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Fabricated"
                    ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated"
                    If Not IsNothing(oSelectedRESLDataRow) Then
                        If Not IsDBNull(oSelectedRESLDataRow("PartCode")) Then
                            txtCodeNumber_RodEnd.Text = oListViewSelectedItem.SubItems(RESingleLugListViewDetails.CodeNumber).Text
                            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd SingleLug Code", oListViewSelectedItem.SubItems(RESingleLugListViewDetails.CodeNumber).Text)
                            'ANUP 07-10-2010 TILL HERE

                            '1_03_2010
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = oSelectedRESLDataRow("PartCode")

                            If oSelectedRESLDataRow("partType").ToString.Contains("IFL_PART") Then
                                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "IFL_Designed_Existing"
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "NewDesign"
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "ROD_END_SINGLE_LUG_CAST"
                            Else
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "Existing"
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "SL_ROD_END_CAST"

                            End If
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = oSelectedRESLDataRow("PartCode")
                        End If

                        If Not IsDBNull(oSelectedRESLDataRow("Thickness")) Then
                            txtLugThickness_RodEnd.Text = oSelectedRESLDataRow("Thickness")
                        End If

                        If Not IsDBNull(oSelectedRESLDataRow("PinHole_Combined")) Then
                            txtPinHoleSize_RodEnd.Text = oSelectedRESLDataRow("PinHole_Combined")
                        End If

                        'If Not IsDBNull(oSelectedRESLDataRow("GreaseZerk")) Then
                        '    txtGreaseZerk_RodEnd.Text = oSelectedRESLDataRow("GreaseZerk")
                        'End If

                        If Not IsDBNull(oSelectedRESLDataRow("GreaseZerkAngle1")) Then
                            txtAngle1_RodEnd.Text = oSelectedRESLDataRow("GreaseZerkAngle1")
                        End If
                        If Not IsDBNull(oSelectedRESLDataRow("GreaseZerkAngle2")) Then
                            txtAngle2_RodEnd.Text = oSelectedRESLDataRow("GreaseZerkAngle2")
                        End If

                        txtGreaseZerk_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.GetGreekZercQty(txtAngle1_RodEnd.Text, txtAngle2_RodEnd.Text)

                        Dim dblLugHeight As Double
                        Dim dblLugWidth As Double

                        If Not IsDBNull(oSelectedRESLDataRow("Height")) Then
                            dblLugHeight = oSelectedRESLDataRow("Height")
                            txtLugHeight_RodEnd.Text = dblLugHeight
                        End If

                        If Not IsDBNull(oSelectedRESLDataRow("Width")) Then
                            txtLugsWidth_RodEnd.Text = oSelectedRESLDataRow("Width")
                            dblLugWidth = oSelectedRESLDataRow("Width")
                        End If

                        'TODO: ANUP 01-06-2010 03.21pm
                        If Not IsNothing(txtPinHoleTole_Pos_Req.Text) Then
                            txtPinHoleTole_Pos.Text = Val(txtPinHoleTole_Pos_Req.Text)
                        End If

                        If Not IsNothing(txtPinHoleTole_Neg_Req.Text) Then
                            txtPinHoleTole_Neg.Text = Val(txtPinHoleTole_Neg_Req.Text)
                        End If
                        '************************

                        DisplayToleranceValues(oSelectedRESLDataRow)

                        '2_3_2010 Aruna
                        If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd) <> dblLugHeight - (dblLugWidth / 2) Then
                            MessageBox.Show("Swing Clearance value will be changing to  " + (dblLugHeight - (dblLugWidth / 2)).ToString, "Informaton", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Text = dblLugHeight - (dblLugWidth / 2)
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd = dblLugHeight - (dblLugWidth / 2)
                        End If
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = dblLugHeight - (dblLugWidth / 2)
                        '*************************************
                        txtSwingClearance_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
                    End If
                Else : oListViewSelectedItem.SubItems(RESingleLugListViewDetails.Configuration).Text = "Cast"
                    oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                                          GetRESLSelectedRowDetails(oListViewSelectedItem.SubItems(RESingleLugListViewDetails.CodeNumber).Text)
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Fabricated"
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Cast"
                    ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Cast"
                    If Not IsNothing(oSelectedRESLDataRow) Then
                        If Not IsDBNull(oSelectedRESLDataRow("PartCode")) Then
                            txtCodeNumber_RodEnd.Text = oSelectedRESLDataRow("PartCode")
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = oSelectedRESLDataRow("PartCode")
                            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd SingleLug Code", oSelectedRESLDataRow("PartCode"))
                            If oSelectedRESLDataRow("partType").ToString.Contains("IFL_PART") Then
                                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "IFL_Designed_Existing"
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "NewDesign"
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "ROD_END_SINGLE_LUG_CAST"
                            Else
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "Existing"
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "SL_ROD_END_CAST"
                            End If
                        End If
                        If Not IsDBNull(oSelectedRESLDataRow("LugThickness")) Then
                            txtLugThickness_RodEnd.Text = oSelectedRESLDataRow("LugThickness")
                        End If

                        If Not IsDBNull(oSelectedRESLDataRow("LugWidth")) Then
                            txtLugsWidth_RodEnd.Text = oSelectedRESLDataRow("LugWidth")
                        End If

                        If Not IsDBNull(oSelectedRESLDataRow("PinHoleCombined")) Then
                            txtPinHoleSize_RodEnd.Text = oSelectedRESLDataRow("PinHoleCombined")
                        End If

                        If Not IsDBNull(oSelectedRESLDataRow("SwingClearanceRadius")) Then
                            txtSwingClearance_RodEnd.Text = oSelectedRESLDataRow("SwingClearanceRadius")
                        End If

                        If Not IsDBNull(oSelectedRESLDataRow("GreaseZerk")) Then
                            txtGreaseZerk_RodEnd.Text = oSelectedRESLDataRow("GreaseZerk")
                        End If

                        If Not IsDBNull(oSelectedRESLDataRow("GreaseZerkAngle1")) Then
                            txtAngle1_RodEnd.Text = oSelectedRESLDataRow("GreaseZerkAngle1")
                        End If

                        If Not IsDBNull(oSelectedRESLDataRow("GreaseZerkAngle2")) Then
                            txtAngle2_RodEnd.Text = oSelectedRESLDataRow("GreaseZerkAngle2")
                        End If

                        If Not IsDBNull(oSelectedRESLDataRow("DistanceFromPinHoleToRodStop")) Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = oSelectedRESLDataRow("DistanceFromPinHoleToRodStop")
                        End If

                        'TODO: ANUP 01-06-2010 03.21pm
                        If Not IsNothing(txtPinHoleTole_Pos_Req.Text) Then
                            txtPinHoleTole_Pos.Text = Val(txtPinHoleTole_Pos_Req.Text)
                        End If

                        If Not IsNothing(txtPinHoleTole_Neg_Req.Text) Then
                            txtPinHoleTole_Neg.Text = Val(txtPinHoleTole_Neg_Req.Text)
                        End If
                        '************************

                    End If
                End If
            Else
                txtCodeNumber_RodEnd.Text = ""
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd SingleLug Code", txtCodeNumber_RodEnd.Text)
                txtSwingClearance_RodEnd.Text = ""
                txtLugThickness_RodEnd.Text = ""
                txtPinHoleSize_RodEnd.Text = ""
                txtLugsWidth_RodEnd.Text = ""
                txtGreaseZerk_RodEnd.Text = ""
                txtAngle1_RodEnd.Text = ""
                txtAngle2_RodEnd.Text = ""
                txtPinHoleTole_Neg.Text = ""
                txtPinHoleTole_Pos.Text = ""
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = 0
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in lvwRodEndSingleLugListView_RodEnd_SelectedIndexChanged of frmRESingleLugDetails " + ex.Message)
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

    Private Sub rdbUseSelectedSingleLugYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedSingleLugYes.CheckedChanged
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = ""    '03_03_2010    ARUNA
        If rdbUseSelectedSingleLugYes.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = True        '20_10_2010    RAGAVA
            '  grbNotExactMatch_RodEnd.Visible = False '5_3_2010 Aruna
            UpdatePreviousFormDetails()
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "Exact"

            'Sandeep 25-02-10 10am
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        Else
            ' grbNotExactMatch_RodEnd.Visible = True '5_3_2010 Aruna
        End If
    End Sub

    Private Sub rdbResize_RodEnd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbResize_RodEnd.CheckedChanged
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = ""    '03_03_2010    ARUNA
        If rdbResize_RodEnd.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = True        '20_10_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "Resize"
            UpdatePreviousFormDetails()
            'Sandeep 25-02-10 10am
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        End If
    End Sub

    Private Sub rdbNewCasting_RodEnd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbNewCasting_RodEnd.CheckedChanged
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = ""    '03_03_2010    ARUNA
        If rdbNewCasting_RodEnd.Checked = True Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = False        '20_10_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "NewDesign"
            UpdatePreviousFormDetails()
            'Sandeep 25-02-10 10am
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        End If
    End Sub

    Private Sub rdbUseSelectedSingleLugNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '2_03_2010 Aruna
        'If rdbUseSelectedSingleLugNo.Checked Then
        '    grbNotExactMatch_RodEnd.Visible = True
        '    grbNotExactMatch_RodEnd.Enabled = True
        'End If
        ' grbNotExactMatch_RodEnd.Visible = True
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, lblSLHeading, LabelGradient4, LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(LabelGradient5)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient1)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblDesignNewCasting)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblSafetyFactorIndex)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblUsingSelectedSingleLug_RodEnd)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblExistingSingleLugIndex_RodEnd)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblNotUsingSelectedSingleLug)
    End Sub

    'ANUP 12-08-2010 
    Private Sub rdbUseSlectedSingleLugYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSlectedSingleLugYes.CheckedChanged
        If rdbUseSlectedSingleLugYes.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ShowCasting_Thru_ExistingRESL = False
            grbUsingSelectedSingleLug_RodEnd.Visible = True
            grbNotUsingSelectedcrosstubeCasting_RECT.Visible = False
            grbUsingSelectedSingleLug_RodEnd.BringToFront()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        End If
    End Sub

    'ANUP 12-08-2010 
    Private Sub rdbUseSelectedSingleLugNo_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedSingleLugNo.CheckedChanged
        If rdbUseSelectedSingleLugNo.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = False        '20_10_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ShowCasting_Thru_ExistingRESL = True
            grbUsingSelectedSingleLug_RodEnd.Visible = False
            grbNotUsingSelectedcrosstubeCasting_RECT.Visible = True
            grbNotUsingSelectedcrosstubeCasting_RECT.BringToFront()
            'If MessageBox.Show("Click OK to Design a Casting", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) = Windows.Forms.DialogResult.OK Then
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
            'plnMatchingSingleLugREFound.Visible = False
            'pnlMatchingSingleLugNotFound.Visible = True
            'RESingleLugDetails_MatchNotFound_Functionality()
            'InitialSettings_RESLMatchNotFound()
            'End If
        End If
    End Sub

End Class