Public Class frmCastingYes_RECT2

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
    Private _oMatchedCrossTubeCastingDataTable As DataTable
#End Region

#Region "enum"
    Public Enum CrossTubeListViewDetails
        CodeNumber = 0
        Description = 1
        Cost = 2
    End Enum
#End Region

#Region "Sub Procedures"
    Public Sub ManualLoad()
        LoadFunctionality()

    End Sub
    Private Sub InitialSettings()
        txtCrossTubeOD_RECT.Enabled = False
        txtCrossTubeOD_RECT.BackColor = Color.Empty

        txtCrossTubeWidth_RECT.Enabled = False
        txtCrossTubeWidth_RECT.BackColor = Color.Empty

        txtRequiredCrossTubeWidth_RECT.Enabled = False
        txtRequiredCrossTubeWidth_RECT.BackColor = Color.Empty

        txtPinHoleSize_RECT.Enabled = False
        txtPinHoleSize_RECT.BackColor = Color.Empty

        txtRequiredPinHoleSize_RECT.Enabled = False
        txtRequiredPinHoleSize_RECT.BackColor = Color.Empty

        txtGreaseZerk_RECT.Enabled = False
        txtGreaseZerk_RECT.BackColor = Color.Empty

        txtRequiredGreaseZerk_RECT.Enabled = False
        txtRequiredGreaseZerk_RECT.BackColor = Color.Empty

        txtAngle1_RECT.Enabled = False
        txtAngle1_RECT.BackColor = Color.Empty

        txtRequiredAngle1_RECT.Enabled = False
        txtRequiredAngle1_RECT.BackColor = Color.Empty

        txtAngle2_RECT.Enabled = False
        txtAngle2_RECT.BackColor = Color.Empty

        txtRequiredAngle2_RECT.Enabled = False
        txtRequiredAngle2_RECT.BackColor = Color.Empty

        txtCost_RECT.Enabled = False
        txtCost_RECT.BackColor = Color.Empty

        txtPinHoleTole_Neg.Enabled = False
        txtPinHoleTole_Neg.BackColor = Color.Empty

        txtPinHoleTole_Pos.Enabled = False
        txtPinHoleTole_Pos.BackColor = Color.Empty

        txtRequiredCost_RECT.Enabled = False
        txtRequiredCost_RECT.BackColor = Color.Empty
        ' grbNotExactMatchCTCasting_RECT.Visible = False  '5_3_2010 ARUNA
        'chkUseSelectedCrossTubeCasting_RECT.Checked = True
        rdbUseSelectedCrossTubeYes.Checked = True
        ' rdbResizeCTCasting_RECT.Checked = True
        ' chkExactMatchCTCasting_RECT.Checked = True

        txtRequiredCrossTubeWidth_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd
        txtRequiredPinHoleSize_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
        txtRequiredGreaseZerk_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs_RodEnd
        txtRequiredAngle1_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1_RodEnd
        txtRequiredAngle2_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2_RodEnd
        txtRequiredCost_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.Cost_RodEnd

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

    Private Sub LoadFunctionality()
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        InitialSettings()
        _oMatchedCrossTubeCastingDataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedRECrossTubeCastingDataTable
        PopulateInListView()
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
    End Sub


    Private Sub PopulateInListView()
        lvwCrossTubeListView_RE.Clear()
        lvwCrossTubeListView_RE.Columns.Add("Code NO", 100, HorizontalAlignment.Center)
        lvwCrossTubeListView_RE.Columns.Add("Description", 220, HorizontalAlignment.Center)

        'TODO:Anup 09-04-10 2pm
        lvwCrossTubeListView_RE.Columns.Add("SafetyFactor", 50, HorizontalAlignment.Center)
        '***********

        lvwCrossTubeListView_RE.Columns.Add("Cost", 50, HorizontalAlignment.Center)
        '<<--20-12-2010 Aruna--
        lvwCrossTubeListView_RE.Columns.Add("Is Existed", 45, HorizontalAlignment.Center)
        '--20-12-2010 Aruna-->>
        Dim intCount As Integer = 0
        Dim oListItem As ListViewItem

        If Not IsNothing(_oMatchedCrossTubeCastingDataTable) AndAlso _oMatchedCrossTubeCastingDataTable.Rows.Count > 0 Then
            Dim strPartCode_Purchase As String = String.Empty
            'ANUP 07-10-2010 START
            If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Count > 0 Then
                ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Clear()
            End If
            'ANUP 07-10-2010 TILL HERE 
            For Each _oMatchedCrossTubeCastingDataRow As DataRow In _oMatchedCrossTubeCastingDataTable.Rows
                If Not IsDBNull(_oMatchedCrossTubeCastingDataRow("PartCode")) Then
                    'ANUP 07-10-2010 START
                    strPartCode_Purchase = ObjClsWeldedCylinderFunctionalClass.PartCOde_Purchased_ListViewClickedValidation(_oMatchedCrossTubeCastingDataRow("PartCode"))
                    oListItem = lvwCrossTubeListView_RE.Items.Add(strPartCode_Purchase)
                    'ANUP 07-10-2010 TILL HERE
                End If
                If Not IsDBNull(_oMatchedCrossTubeCastingDataRow("Description")) Then
                    lvwCrossTubeListView_RE.Items(intCount).SubItems.Add((_oMatchedCrossTubeCastingDataRow("Description")))
                End If


                '31_05_2011  RAGAVA
                Try
                    Dim dblSafetyFactor As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SetSafetyFactorForExisting_RodEnd(strPartCode_Purchase)
                    If dblSafetyFactor > 0 Then
                        lvwCrossTubeListView_RE.Items(intCount).SubItems.Add(dblSafetyFactor.ToString)
                    Else
                        If Not IsDBNull(_oMatchedCrossTubeCastingDataRow("CalculatedSafetyFactor")) Then
                            lvwCrossTubeListView_RE.Items(intCount).SubItems.Add(_oMatchedCrossTubeCastingDataRow("CalculatedSafetyFactor"))
                        Else
                            lvwCrossTubeListView_RE.Items(intCount).SubItems.Add("")
                        End If
                    End If
                Catch ex As Exception
                End Try
                ''TODO:Anup 09-04-10 2pm
                'If Not IsDBNull(_oMatchedCrossTubeCastingDataRow("CalculatedSafetyFactor")) Then
                '    lvwCrossTubeListView_RE.Items(intCount).SubItems.Add(_oMatchedCrossTubeCastingDataRow("CalculatedSafetyFactor"))
                'Else
                '    lvwCrossTubeListView_RE.Items(intCount).SubItems.Add("")
                'End If
                ''***************
                'TILL    HERE

                If Not IsDBNull(_oMatchedCrossTubeCastingDataRow("Cost")) Then
                    lvwCrossTubeListView_RE.Items(intCount).SubItems.Add((_oMatchedCrossTubeCastingDataRow("Cost")))
                End If
                '<<--20-12-2010 Aruna--
                If Not IsDBNull(_oMatchedCrossTubeCastingDataRow("IsExisted")) Then
                    If _oMatchedCrossTubeCastingDataRow("IsExisted") = True Then
                        lvwCrossTubeListView_RE.Items(intCount).SubItems.Add("Yes")
                    Else
                        lvwCrossTubeListView_RE.Items(intCount).SubItems.Add("No")
                    End If
                Else
                    lvwCrossTubeListView_RE.Items(intCount).SubItems.Add("No")
                End If
                '--20-12-2010 Aruna-->>
                intCount += 1
            Next
        End If
        lvwCrossTubeListView_RE.HideSelection = False
        lvwCrossTubeListView_RE.FullRowSelect = True
    End Sub

#End Region

#Region "Events"

    Private Sub frmCastingYes_RECT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        LoadFunctionality()
    End Sub

    Private Sub lvwCrossTubeListView_RE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwCrossTubeListView_RE.SelectedIndexChanged
        'ANUP 10-11-2010 START
        rdbExactMatchYes.Checked = False
        rdbResizeCTCasting_RECT.Checked = False
        rdbUseSelectedCrossTubeYes.Checked = False
        rdbUseSelectedCrossTubeNo.Checked = False
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        'ANUP 10-11-2010 TILL HERE
        If lvwCrossTubeListView_RE.SelectedIndices.Count > 0 Then
            '1_03_2010 Aruna
            ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Lathe"
            If rdbUseSelectedCrossTubeNo.Checked Then
                ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
            ElseIf rdbUseSelectedCrossTubeYes.Checked = False Then
                ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            End If

            Dim oListViewSelectedItem As ListViewItem = lvwCrossTubeListView_RE.SelectedItems(0)

            Dim oSelectedCastingDataRow As DataRow = Nothing

            'ANUP 07-10-2010 START
            Dim strPartCodePassing_Purchased As String = oListViewSelectedItem.SubItems(CrossTubeListViewDetails.CodeNumber).Text
            Try
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_RodEnd = oListViewSelectedItem.SubItems(2).Text      '31_05_2011   ragava
            Catch ex As Exception
            End Try
            ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode2 = strPartCodePassing_Purchased         '12_10_2010   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndCastingCodeNumber2 = ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode2    '07_02_2011 
            If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.ContainsKey(strPartCodePassing_Purchased) Then
                strPartCodePassing_Purchased = ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Item(strPartCodePassing_Purchased).ToString
            End If


            oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                            GetRECrossTubeCastingDetailsSelectedRowDetails(strPartCodePassing_Purchased)
            'ANUP 07-10-2010 TILL HERE

            If Not IsNothing(oSelectedCastingDataRow) Then

                If Not IsDBNull(oSelectedCastingDataRow("CrossTubeOD")) Then
                    txtCrossTubeOD_RECT.Text = oSelectedCastingDataRow("CrossTubeOD")
                End If

                If Not IsDBNull(oSelectedCastingDataRow("CrossTubeWidth")) Then
                    txtCrossTubeWidth_RECT.Text = oSelectedCastingDataRow("CrossTubeWidth")
                End If

                If Not IsDBNull(oSelectedCastingDataRow("PinHoleSizeCombined")) Then
                    txtPinHoleSize_RECT.Text = oSelectedCastingDataRow("PinHoleSizeCombined")
                End If

                'If Not IsDBNull(oSelectedCastingDataRow("GreaseZerk")) Then
                '    txtGreaseZerk_RECT.Text = oSelectedCastingDataRow("GreaseZerk")
                'End If

                If Not IsDBNull(oSelectedCastingDataRow("GreaseZerkAngle1")) Then
                    txtAngle1_RECT.Text = oSelectedCastingDataRow("GreaseZerkAngle1")
                End If

                If Not IsDBNull(oSelectedCastingDataRow("GreaseZerkAngle2")) Then
                    txtAngle2_RECT.Text = oSelectedCastingDataRow("GreaseZerkAngle2")
                End If

                txtGreaseZerk_RECT.Text = ObjClsWeldedCylinderFunctionalClass.GetGreekZercQty(txtAngle1_RECT.Text, txtAngle2_RECT.Text)

                If Not IsDBNull(oSelectedCastingDataRow("COst")) Then
                    txtCost_RECT.Text = oSelectedCastingDataRow("Cost")
                End If
                If Not IsDBNull(oSelectedCastingDataRow("DistanceFromPinHoleToRodStop")) Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = oSelectedCastingDataRow("DistancefromPinholetoRodStop")
                End If

                '26_02_2010 Aruna Start
                If oSelectedCastingDataRow("PartType").ToString.Contains("IFL_PART") Then
                    ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "IFL_Designed_Existing"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd2 = "NewDesign" '1_03_2010
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName2 = "ROD_END_CROSS_TUBE_CASTING"
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd2 = "Existing"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName2 = "CT-CAST-ROD-END"
                End If
                '26_02_2010 Aruna End
                ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd2
                '1_03_2010 Aruna
                If Not IsDBNull(oSelectedCastingDataRow("PartCode")) Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd2 = oSelectedCastingDataRow("PartCode")
                End If

                '06_03_2010   RAGAVA
                If Not IsDBNull(oSelectedCastingDataRow("WeldSize")) Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEndCT = Val(oSelectedCastingDataRow("WeldSize"))
                End If
                'Till   Here
                '1_03_2010 Aruna
                ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated2 = "Cast"
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd2 = "Cast"

                DisplayToleranceValues(oSelectedCastingDataRow)
                ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
            End If
        Else
            txtCrossTubeOD_RECT.Text = ""
            txtCrossTubeWidth_RECT.Text = ""
            txtPinHoleSize_RECT.Text = ""
            txtGreaseZerk_RECT.Text = ""
            txtAngle1_RECT.Text = ""
            txtAngle2_RECT.Text = ""
            txtCost_RECT.Text = ""
            txtPinHoleTole_Neg.Text = ""
            txtPinHoleTole_Pos.Text = ""
        End If
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

    'Private Sub chkUseSelectedCrossTubeCasting_RECT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If chkUseSelectedCrossTubeCasting_RECT.Checked Then
    '        grbUsingSelectedCrossTubeCasting_RECT.Visible = True
    '        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
    '        ' btnClickNextButton_RECT.Visible = False
    '    Else
    '        grbUsingSelectedCrossTubeCasting_RECT.Visible = False
    '        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
    '        'btnClickNextButton_RECT.Visible = True
    '        '  btnClickNextButton_RECT.Location = New Point(280, 430)
    '    End If
    'End Sub

    'Private Sub chkExactMatchCTCasting_RECT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If chkExactMatchCTCasting_RECT.Checked Then
    '        grbNotExactMatchCTCasting_RECT.Visible = False
    '        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
    '        btnMessageExactMatchCTCasting_RECT.Location = New Point(126, 100)
    '    Else
    '        grbNotExactMatchCTCasting_RECT.Visible = True
    '        btnMessageExactMatchCTCasting_RECT.Location = New Point(126, 121)
    '    End If
    'End Sub
#End Region

    Private Sub rdbNewCTCasting_RECT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbNewCTCasting_RECT.CheckedChanged
        '26_02_2010 Aruna Start
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd2 = ""    '03_03_2010    ARUNA
        If rdbNewCTCasting_RECT.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd2 = False        '20_10_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd2 = "NewDesign"
            UpdatePreviousFormDetails()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        End If
        '26_02_2010 Aruna Ends
    End Sub

    Private Sub rdbResizeCTCasting_RECT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbResizeCTCasting_RECT.CheckedChanged
        '26_02_2010 Aruna Start
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd2 = ""    '03_03_2010    ARUNA
        If rdbResizeCTCasting_RECT.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd2 = True        '20_10_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd2 = "Resize"
            UpdatePreviousFormDetails()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        End If
        '26_02_2010 Aruna Ends
    End Sub

    Private Sub rdbExactMatchYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbExactMatchYes.CheckedChanged
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndDesignSelected2 = False        '24_07_2012   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd2 = ""    '03_03_2010    ARUNA
        If rdbExactMatchYes.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd2 = True        '20_10_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd2 = "Exact"
            'grbNotExactMatchCTCasting_RECT.Visible = False '5_3_2010 ARUNA
            UpdatePreviousFormDetails()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        End If
        '26_02_2010 Aruna Ends
    End Sub

    Private Sub rdbExactMatchNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '5_03_2010 Aruna Start
        'If rdbExactMatchNo.Checked Then
        '    grbNotExactMatchCTCasting_RECT.Visible = True
        'End If
        '5_03_2010 Aruna Ends
    End Sub
    '26_02_2010 Aruna Start
    Private Sub UpdatePreviousFormDetails()
        Dim strMessage As String = "Rod end Configuration will be updated with the selected Cross Tube casting details, " + vbCrLf
        If MessageBox.Show(strMessage, "Update TubeDetails", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
            If ObjClsWeldedCylinderFunctionalClass.PinHoleSize_Source = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.BushingPinHole Then
                If txtPinHoleSize_RECT.Text <> "" Then
                    ObjClsWeldedCylinderFunctionalClass.CmbBushingPinHoleSize_RodEnd.Text = txtPinHoleSize_RECT.Text
                End If
            ElseIf ObjClsWeldedCylinderFunctionalClass.PinHoleSize_Source = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleCustom Then
                If txtPinHoleSize_RECT.Text <> "" Then
                    ObjClsWeldedCylinderFunctionalClass.TxtPinHoleSize_RodEnd.Text = txtPinHoleSize_RECT.Text
                End If
            ElseIf ObjClsWeldedCylinderFunctionalClass.PinHoleSize_Source = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleStandard Then
                If txtPinHoleSize_RECT.Text <> "" Then
                    ObjClsWeldedCylinderFunctionalClass.CmbPinHoleSize_RodEnd.Text = txtPinHoleSize_RECT.Text
                End If
            End If

            If txtGreaseZerk_RECT.Text <> "" AndAlso txtGreaseZerk_RECT.Text <> "N/A" Then
                ObjClsWeldedCylinderFunctionalClass.CmbGreaseZercs_RodEnd.Text = txtGreaseZerk_RECT.Text
            End If

            If txtAngle1_RECT.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtAngleOfGreaseZercs1_RodEnd.Text = txtAngle1_RECT.Text
            End If

            If txtAngle2_RECT.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtAngleOfGreaseZercs2_RodEnd.Text = txtAngle2_RECT.Text
            End If
            If txtCrossTubeWidth_RECT.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtCrossTubeWidth_RodEnd.Text = txtCrossTubeWidth_RECT.Text
            End If
            ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd2

            'anup 31-08-2010
            If Not String.IsNullOrEmpty(txtPinHoleTole_Pos.Text) Then
                ObjClsWeldedCylinderFunctionalClass.TxtToleranceUpperLimit_RodEnd.Text = txtPinHoleTole_Pos.Text
            End If
            If Not String.IsNullOrEmpty(txtPinHoleTole_Neg.Text) Then
                ObjClsWeldedCylinderFunctionalClass.TxtToleranceLowerLimit_RodEnd.Text = txtPinHoleTole_Neg.Text
            End If

        End If
    End Sub
    '26_02_2010 Aruna Ends
    Private Sub rdbUseSelectedCrossTubeNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedCrossTubeNo.CheckedChanged
        If rdbUseSelectedCrossTubeNo.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd2 = False        '20_10_2010    RAGAVA
            grbUsingSelectedCrossTubeCasting_RECT.Visible = False
            grbNotUsingSelectedcrosstubeCasting_RECT.Visible = True
            ObjClsWeldedCylinderFunctionalClass.ShowCastingNo_Thru_CastingYes_RodEnd = True
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
            lvwCrossTubeListView_RE.Tag = "Validation Not Required"
            ' lvwCrossTubeListView_RE.Tag = "Validation Required"
            '24-05-2012 MANJULA ADDED
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.plnFabrication_Casting_RECT.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.rdbDesignACasting_RECT.Checked = False
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.rdbFabrication_RECT.Checked = False

            ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT2.plnFabrication_Casting_RECT.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT2.rdbDesignACasting_RECT.Checked = False
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT2.rdbFabrication_RECT.Checked = False
            '**********************
        End If
    End Sub

    Private Sub rdbUseSelectedCrossTubeYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedCrossTubeYes.CheckedChanged
        If rdbUseSelectedCrossTubeYes.Checked Then
            'ONSITE:19-05-2010 
            If txtPinHoleSize_RECT.Text <> "" AndAlso txtRequiredPinHoleSize_RECT.Text <> "" Then
                If ObjClsWeldedCylinderFunctionalClass.PinHoleSizeDiffere(Val(txtPinHoleSize_RECT.Text), Val(txtRequiredPinHoleSize_RECT.Text)) Then
                    ' grbUsingSelectedCrossTubeCasting_RECT.Visible = False  'anup 23-12-2010 
                    rdbExactMatchYes.Checked = True
                Else
                    grbUsingSelectedCrossTubeCasting_RECT.Visible = True
                End If
            Else
                grbUsingSelectedCrossTubeCasting_RECT.Visible = True
            End If
            grbUsingSelectedCrossTubeCasting_RECT.Visible = True
            grbNotUsingSelectedcrosstubeCasting_RECT.Visible = False
            ObjClsWeldedCylinderFunctionalClass.ShowCastingNo_Thru_CastingYes_RodEnd = False
            'ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False            '16_08_2010  ANUP
            lvwCrossTubeListView_RE.Tag = "Validation Required"

            '24-05-2012 MANJULA ADDED
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.plnFabrication_Casting_RECT.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.rdbDesignACasting_RECT.Checked = False
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.rdbFabrication_RECT.Checked = False

            ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT2.plnFabrication_Casting_RECT.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT2.rdbDesignACasting_RECT.Checked = False
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT2.rdbFabrication_RECT.Checked = False

            ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated2 = "Cast"
            '************************
        End If
    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblCrossTubeCasting_RE)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblNotUsingSelectedSingleLug)

        'A0308: ANUP 03-08-2010 02.28pm
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblUsingSelectedCrossTubeCasting_RECT)
    End Sub

   
End Class