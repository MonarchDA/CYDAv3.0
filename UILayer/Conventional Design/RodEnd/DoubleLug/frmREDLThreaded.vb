Public Class frmREDLThreaded

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

    Private _blnIsDLThreadDataFound As Boolean
    Public ReadOnly Property IsDLThreadDataFound() As Boolean
        Get
            Return _blnIsDLThreadDataFound
        End Get
    End Property


#Region "Private Variables"

    Private _dblCylinderPullForce As Double = 0

    Private _oMatchedREDLThreadedTable As DataTable

#End Region

#Region "enums"

    Public Enum DoubleLugListViewDetails
        CodeNumber = 0
        Description = 1
        Cost = 2
    End Enum

#End Region

#Region "SubProcedures"

    Public Sub ManualLoad()
        InitialSettings()
        SearchForExistingThreadedDoubleLug()
    End Sub

    ' Private Sub SearchForExistingThreadedDoubleLug()
    Public Sub SearchForExistingThreadedDoubleLug()
        GetCylinderPullForce()
        Dim dblRodDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
        Dim dblRequiredPinHoleSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
        Dim strPinHoleTypeThreade As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType_Threaded_RodEnd_DL
        Dim StrClass As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass

        Dim oDoubleLugThreadedDetails_RE As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
        DoubleLugThreadedDetails_RE(dblRodDiameter, dblRequiredPinHoleSize, _dblCylinderPullForce, strPinHoleTypeThreade, StrClass)

        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedREDLThreadedDataTable = New DataTable

        If Not IsNothing(oDoubleLugThreadedDetails_RE) Then

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedREDLThreadedDataTable = oDoubleLugThreadedDetails_RE.Clone

        End If

        If Not IsNothing(oDoubleLugThreadedDetails_RE) Then
            For Each oDataRow As DataRow In oDoubleLugThreadedDetails_RE.Rows
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedREDLThreadedDataTable.Rows.Add(oDataRow.ItemArray)
            Next
        End If


        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedREDLThreadedDataTable.Rows.Count > 0 Then
            ObjClsWeldedCylinderFunctionalClass.ShowWelded_Thru_Threaded_REDL = False
            pnlDLThreadedYes.Show()
            pnlDLThreadedNo.Hide()
            PopulateInListView()
            _blnIsDLThreadDataFound = True
        Else
            'Show Welded Screens thru Threaded
            ObjClsWeldedCylinderFunctionalClass.ShowWelded_Thru_Threaded_REDL = True
            pnlDLThreadedNo.Show()
            pnlDLThreadedYes.Hide()
            _blnIsDLThreadDataFound = False
        End If
    End Sub

    'ONSITE:  DL- changing the equation
    Private Sub GetCylinderPullForce()

        '_dblCylinderPullForce = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure * ((Math.PI / 4) * _
        ' ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter * 2) - (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter * 2)))

        _dblCylinderPullForce = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure * ((Math.PI / 4) * _
               (Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, 2) - Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, 2)))

        _dblCylinderPullForce = Math.Round(_dblCylinderPullForce, 2)

    End Sub

    Private Sub InitialSettings()
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        txtCodeNumber_Threaded.Enabled = False

        txtLugGap_Threaded.Enabled = False
        txtRequiredLugGap_Threaded.Enabled = False

        txtLugWidth_Threaded.Enabled = False

        txtLugThickness_Threaded.Enabled = False
        txtRequiredLugThickness_Threaded.Enabled = False

        txtPinHoleSize_Threaded.Enabled = False
        txtRequiredPinHoleSize_Threaded.Enabled = False

        txtSwingClearance_Threaded.Enabled = False
        txtRequiredSwingClearance_Threaded.Enabled = False

        txtThreadLength_Threaded.Enabled = False

        txtThreadSize_Threaded.Enabled = False

        txtPinHoleTole_Neg.Enabled = False
        txtPinHoleTole_Pos.Enabled = False

        'rdbResizeThreaded.Checked = True        '02_03_2010  RAGAVA

        txtRequiredLugGap_Threaded.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd
        txtRequiredLugThickness_Threaded.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
        txtRequiredPinHoleSize_Threaded.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
        txtRequiredSwingClearance_Threaded.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd

        rdbUseSelectedSingleLugYes.Checked = True
        'grbNotExactMatchThreaded.Visible = False '5_3_2010 ARUNA
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

    Private Sub PopulateInListView()

        lvwDLThreadedDetails.Clear()
        lvwDLThreadedDetails.Columns.Add("Code No", 100, HorizontalAlignment.Center)
        lvwDLThreadedDetails.Columns.Add("Description", 200, HorizontalAlignment.Center)
        lvwDLThreadedDetails.Columns.Add("Cost", 100, HorizontalAlignment.Center)
        lvwDLThreadedDetails.Columns.Add("Sales", 100, HorizontalAlignment.Center)        '28_11_2012   RAGAVA

        '<<--20-12-2010 Aruna--
        lvwDLThreadedDetails.Columns.Add("Is Existed", 45, HorizontalAlignment.Center)
        '--20-12-2010 Aruna-->>

        Dim intCount As Integer = 0
        Dim oListItem As ListViewItem

        _oMatchedREDLThreadedTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedREDLThreadedDataTable
        Try
            If Not IsNothing(_oMatchedREDLThreadedTable) AndAlso _oMatchedREDLThreadedTable.Rows.Count > 0 Then

                'ANUP 07-10-2010 START
                If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Count > 0 Then
                    ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Clear()
                End If
                'ANUP 07-10-2010 TILL HERE 

                For Each _oMatchedREDLThreadedRow As DataRow In _oMatchedREDLThreadedTable.Rows
                    If Not IsDBNull(_oMatchedREDLThreadedRow("PartCode")) Then

                        'ANUP 07-10-2010 START
                        Dim strPartCode_Purchase As String = ObjClsWeldedCylinderFunctionalClass.PartCOde_Purchased_ListViewClickedValidation(_oMatchedREDLThreadedRow("PartCode"))
                        oListItem = lvwDLThreadedDetails.Items.Add(strPartCode_Purchase)
                        'ANUP 07-10-2010 TILL HERE
                    Else
                        lvwDLThreadedDetails.Items.Add("")
                    End If
                    If Not IsDBNull(_oMatchedREDLThreadedRow("Description")) Then
                        lvwDLThreadedDetails.Items(intCount).SubItems.Add(_oMatchedREDLThreadedRow("Description"))
                    Else
                        lvwDLThreadedDetails.Items(intCount).SubItems.Add("")
                    End If

                    '28_11_2012  RAGAVA
                    Try
                        ObjClsWeldedCylinderFunctionalClass.GetCost_Sales(_oMatchedREDLThreadedRow("PartCode"), lvwDLThreadedDetails, intCount)
                    Catch ex As Exception

                    End Try
                    'If Not IsDBNull(_oMatchedREDLThreadedRow("Cost")) Then
                    '    lvwDLThreadedDetails.Items(intCount).SubItems.Add(_oMatchedREDLThreadedRow("Cost"))
                    'Else
                    '    lvwDLThreadedDetails.Items(intCount).SubItems.Add("")
                    'End If
                    'Till   Here

                    '<<--20-12-2010 Aruna--
                    If Not IsDBNull(_oMatchedREDLThreadedRow("IsExisted")) Then
                        If _oMatchedREDLThreadedRow("IsExisted") = True Then
                            lvwDLThreadedDetails.Items(intCount).SubItems.Add("Yes")
                        Else
                            lvwDLThreadedDetails.Items(intCount).SubItems.Add("No")
                        End If
                    Else
                        lvwDLThreadedDetails.Items(intCount).SubItems.Add("No")
                    End If
                    '--20-12-2010 Aruna-->>

                    intCount += 1
                Next
            End If
            lvwDLThreadedDetails.HideSelection = False
            lvwDLThreadedDetails.FullRowSelect = True
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in PopulateInListView of frmDLCastingYes " + ex.Message)
        End Try
    End Sub

    Private Sub UpdatePreviousFormDetails()
        Try
            'ONSITE: DL - commenting the displaying the message 

            'Dim strMessage As String = "Rod end Configuration Details will be updated with the selected Threaded Double Lug details, " + vbCrLf
            'If MessageBox.Show(strMessage, "Update TubeDetails", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
            'If txtSwingClearance_Threaded.Text <> "" Then
            '    ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Text = txtSwingClearance_Threaded.Text
            'End If

            If txtLugThickness_Threaded.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_RodEnd.Text = txtLugThickness_Threaded.Text
            End If

            If ObjClsWeldedCylinderFunctionalClass.PinHoleSize_source_RodEnd = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.BushingPinHole Then
                If txtPinHoleSize_Threaded.Text <> "" Then
                    ObjClsWeldedCylinderFunctionalClass.CmbBushingPinHoleSize_RodEnd.Text = txtPinHoleSize_Threaded.Text
                End If
            ElseIf ObjClsWeldedCylinderFunctionalClass.PinHoleSize_source_RodEnd = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleCustom Then
                If txtPinHoleSize_Threaded.Text <> "" Then
                    ObjClsWeldedCylinderFunctionalClass.TxtPinHoleSize_RodEnd.Text = txtPinHoleSize_Threaded.Text
                End If
            ElseIf ObjClsWeldedCylinderFunctionalClass.PinHoleSize_source_RodEnd = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleStandard Then
                If txtPinHoleSize_Threaded.Text <> "" Then
                    ObjClsWeldedCylinderFunctionalClass.CmbPinHoleSize_RodEnd.Text = txtPinHoleSize_Threaded.Text
                End If
            End If

            If txtLugWidth_Threaded.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd = Val(txtLugWidth_Threaded.Text)
            End If

            If txtLugGap_Threaded.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd = Val(txtLugGap_Threaded.Text)
            End If
            ' End If

            'anup 31-08-2010
            If Not String.IsNullOrEmpty(txtPinHoleTole_Pos.Text) Then
                ObjClsWeldedCylinderFunctionalClass.TxtToleranceUpperLimit_RodEnd.Text = txtPinHoleTole_Pos.Text
            End If
            If Not String.IsNullOrEmpty(txtPinHoleTole_Neg.Text) Then
                ObjClsWeldedCylinderFunctionalClass.TxtToleranceLowerLimit_RodEnd.Text = txtPinHoleTole_Neg.Text
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Events"

    Private Sub frmREDLThreaded_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ColorTheForm()
        InitialSettings()
        SearchForExistingThreadedDoubleLug()
    End Sub

    Private Sub lvwDLThreadedDetails_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwDLThreadedDetails.SelectedIndexChanged
        'ANUP 10-11-2010 START
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        rdbExactMatchYes.Checked = False
        rdbResizeThreaded.Checked = False
        rdbUseSelectedSingleLugYes.Checked = False
        rdbUseSelectedSingleLugNo.Checked = False
        'ANUP 10-11-2010 TILL HERE
        If lvwDLThreadedDetails.SelectedIndices.Count > 0 Then

            Dim oListViewSelectedItem As ListViewItem = lvwDLThreadedDetails.SelectedItems(0)

            Dim oSelectedThreadedDataRow As DataRow = Nothing

            'ANUP 07-10-2010 START
            Dim strPartCodePassing_Purchased As String = oListViewSelectedItem.SubItems(DoubleLugListViewDetails.CodeNumber).Text
            ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode = strPartCodePassing_Purchased         '12_10_2010   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.ContainsKey(strPartCodePassing_Purchased) Then
                strPartCodePassing_Purchased = ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Item(strPartCodePassing_Purchased).ToString
            End If

            oSelectedThreadedDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
            GetREDoubleLugThreadedSelectedRowDetails(strPartCodePassing_Purchased)

            Try

                If Not IsNothing(oSelectedThreadedDataRow) Then
                    If Not IsDBNull(oSelectedThreadedDataRow("PartCode")) Then
                        txtCodeNumber_Threaded.Text = oListViewSelectedItem.SubItems(DoubleLugListViewDetails.CodeNumber).Text
                        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("DoubleLug Threaded Part Code", oListViewSelectedItem.SubItems(DoubleLugListViewDetails.CodeNumber).Text)
                        'ANUP 07-10-2010 TILL HERE

                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = oSelectedThreadedDataRow("PartCode")
                    End If

                    'If oSelectedThreadedDataRow("PartType").ToString.Contains("IFL_PART") Then
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "IFL_Designed_Existing"
                    '    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_NO_PO_GR_SINGLELUG"
                    'Else
                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "Existing"
                    '    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "Sl_No_Port"
                    'End If

                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "Existing"

                    If Not IsDBNull(oSelectedThreadedDataRow("LugThickness")) Then
                        txtLugThickness_Threaded.Text = oSelectedThreadedDataRow("LugThickness")
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd = oSelectedThreadedDataRow("LugThickness")
                    End If

                    If Not IsDBNull(oSelectedThreadedDataRow("LugWidth")) Then
                        txtLugWidth_Threaded.Text = oSelectedThreadedDataRow("LugWidth")
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd = oSelectedThreadedDataRow("LugWidth")
                    End If

                    If Not IsDBNull(oSelectedThreadedDataRow("LugGap")) Then
                        txtLugGap_Threaded.Text = oSelectedThreadedDataRow("LugGap")
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd = oSelectedThreadedDataRow("LugGap")
                    End If

                    If Not IsDBNull(oSelectedThreadedDataRow("SwingClearanceRadius")) Then
                        txtSwingClearance_Threaded.Text = oSelectedThreadedDataRow("SwingClearanceRadius")
                    End If

                    If Not IsDBNull(oSelectedThreadedDataRow("ThreadSize")) Then
                        txtThreadSize_Threaded.Text = oSelectedThreadedDataRow("ThreadSize")
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadSize_RodEnd = oSelectedThreadedDataRow("ThreadSize")
                    End If

                    If Not IsNothing(oSelectedThreadedDataRow("ThreadLength")) Then
                        txtThreadLength_Threaded.Text = oSelectedThreadedDataRow("ThreadLength")
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength_RodEnd = oSelectedThreadedDataRow("ThreadLength")
                    End If

                    If Not IsNothing(oSelectedThreadedDataRow("PinHoleStandard")) Then
                        txtPinHoleSize_Threaded.Text = oSelectedThreadedDataRow("PinHoleStandard")
                    End If

                    If Not IsDBNull(oSelectedThreadedDataRow("DistanceFromPinHoleToEndOfThreads")) Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = oSelectedThreadedDataRow("DistanceFromPinHoleToEndOfThreads")
                    End If

                    DisplayToleranceValues(oSelectedThreadedDataRow)
                End If
            Catch ex As Exception

            End Try
        Else

            txtCodeNumber_Threaded.Text = ""
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("DoubleLug Threaded Part Code", txtCodeNumber_Threaded.Text)
            txtLugThickness_Threaded.Text = ""
            txtLugWidth_Threaded.Text = ""
            txtLugGap_Threaded.Text = ""
            txtSwingClearance_Threaded.Text = ""
            txtThreadSize_Threaded.Text = ""
            txtThreadLength_Threaded.Text = ""
            txtPinHoleSize_Threaded.Text = ""
            txtPinHoleTole_Pos.Text = ""
            txtPinHoleTole_Neg.Text = ""
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = 0
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = 0
        End If
    End Sub

    'ONSITE:20-05-2010 assign  the tolerance data to GUI fields
    Private Sub DisplayToleranceValues(ByVal oRow As DataRow)
        ''Positive tolerance
        'If Not IsDBNull(oRow("PinHoleCustom_UpperTolerance")) Then
        '    If oRow("PinHoleCustom_UpperTolerance").Equals("N/A") Then
        '        txtPinHoleTole_Pos.Text = "0.010"
        '    Else
        '        txtPinHoleTole_Pos.Text = oRow("PinHoleCustom_UpperTolerance")
        '    End If
        'End If
        ''Negative Tolerance
        'If Not IsDBNull(oRow("PinHoleCustom_LowerTolerance")) Then
        '    If oRow("PinHoleCustom_LowerTolerance").Equals("N/A") Then
        '        txtPinHoleTole_Neg.Text = 0.005
        '    Else
        '        txtPinHoleTole_Neg.Text = oRow("PinHoleCustom_LowerTolerance")
        '    End If
        'End If
        txtPinHoleTole_Pos.Text = "0.010"
        txtPinHoleTole_Neg.Text = 0.005

    End Sub

    Private Sub rdbUseSelectedSingleLugYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedSingleLugYes.CheckedChanged
        If rdbUseSelectedSingleLugYes.Checked Then
            'ONSITE: DL - disabled the selection of threaded options
            'grbUsingSelectedDLThreaded.Visible = True
            grbUsingSelectedDLThreaded.Visible = False
            _blnIsDLThreadDataFound = True
            ISExactMatch()
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = True           '21_10_2010   RAGAVA
            grbNotUsingSelectedDoubleLug.Visible = False
            ObjClsWeldedCylinderFunctionalClass.ShowWelded_Thru_Threaded_REDL = False
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "Existing"
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Cast"
        End If
    End Sub

    Private Sub rdbUseSelectedSingleLugNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedSingleLugNo.CheckedChanged
        If rdbUseSelectedSingleLugNo.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = False        '20_10_2010    RAGAVA
            _blnIsDLThreadDataFound = False
            grbUsingSelectedDLThreaded.Visible = False
            grbNotUsingSelectedDoubleLug.Visible = True
            ObjClsWeldedCylinderFunctionalClass.ShowWelded_Thru_Threaded_REDL = True
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = ""
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = ""
        End If
    End Sub

    Private Sub rdbExactMatchYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbExactMatchYes.CheckedChanged
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = ""    '03_03_2010    ARUNA
        If rdbExactMatchYes.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = True        '20_10_2010    RAGAVA
            ISExactMatch()
        End If
    End Sub
    'ONSITE: DL - separating the code from the existing code
    Private Sub ISExactMatch()
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "Exact"
        ' grbNotExactMatchThreaded.Visible = False '5_3_2010 ARUNA
        UpdatePreviousFormDetails()
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
    End Sub

    Private Sub rdbExactMatchNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If rdbExactMatchNo.Checked Then
        '    grbNotExactMatchThreaded.Visible = True
        'End If
        '5_3_2010 ARUNA
    End Sub

    Private Sub rdbResizeThreaded_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbResizeThreaded.CheckedChanged
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = ""    '03_03_2010    ARUNA
        If rdbResizeThreaded.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = True        '20_10_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "Resize"
            UpdatePreviousFormDetails()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        End If
    End Sub

    Private Sub rdbNewCastingThreaded_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbNewCastingThreaded.CheckedChanged
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = ""    '03_03_2010    ARUNA
        If rdbNewCastingThreaded.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = False        '20_10_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "NewDesign"
            UpdatePreviousFormDetails()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        End If
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, lblDLHeading, LabelGradient4, LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(LabelGradient5)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblExistingDoubleLugIndex_RodEnd)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblUseSelectedThreadedDoubleLug)
    End Sub

End Class