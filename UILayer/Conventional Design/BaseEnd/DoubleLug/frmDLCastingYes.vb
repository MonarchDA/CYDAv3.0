Public Class frmDLCastingYes

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

    Private _oMatchedCastingDataTable As DataTable

#End Region

#Region "Enum"

    Public Enum DoubleLugListViewDetails
        CodeNumber = 0
        Description = 1
        Cost = 2
    End Enum

#End Region

#Region "Properties"

#End Region

#Region "Subprocedures"

    Private Sub InitialSettings()
        txtCodeNumber.Enabled = False
        txtSwingClearance.Enabled = False
        txtRequiredSwingClearance.Enabled = False
        txtLugThickness.Enabled = False
        txtRequiredLugThickness.Enabled = False
        txtPinHoleSize.Enabled = False
        txtRequiredPinHoleSize.Enabled = False
        txtLugsGap.Enabled = False
        txtRequiredLugsGap.Enabled = False
        txtLugsWidth.Enabled = False
        txtRequiredLugsWidth.Enabled = False
        txtGreaseZerk.Enabled = False
        txtRequiredGreaseZerk.Enabled = False
        txtAngle1.Enabled = False
        txtRequiredAngle1.Enabled = False
        txtAngle2.Enabled = False
        txtRequiredAngle2.Enabled = False

        txtRequiredSwingClearance.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
        txtRequiredLugThickness.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
        txtRequiredPinHoleSize.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
        txtRequiredLugsGap.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap
        txtRequiredLugsWidth.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
        txtRequiredGreaseZerk.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs
        txtRequiredAngle1.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1
        txtRequiredAngle2.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2

        'TODO:Anup 26-02-2010
        rdbUseSelectedSingleLugYes.Checked = True
        'grbNotExactMatch.Visible = False '5_3_2010 ARUNA
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        ' Anup END

        DisableReqPinToleranceControls()
    End Sub

    'ONSITE: 26-05-2010 To disable the required tolerace and display the content
    Private Sub DisableReqPinToleranceControls()
        txtPinHoleTole_Neg_Req.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit
        txtPinHoleTole_Pos_Req.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit
        txtPinHoleTole_Pos_Req.Enabled = False
        txtPinHoleTole_Neg_Req.Enabled = False
        txtPinHoleTole_Pos.Enabled = False
        txtPinHoleTole_Neg.Enabled = False
    End Sub

    'TODO:Anup 26-02-2010
    Private Sub PopulateInListView()
        lvwDoubleLugListView.Clear()
        lvwDoubleLugListView.Columns.Add("Code No", 100, HorizontalAlignment.Center)
        lvwDoubleLugListView.Columns.Add("Description", 220, HorizontalAlignment.Center)

        'TODO:Anup 09-04-10 2pm
        lvwDoubleLugListView.Columns.Add("SafetyFactor", 100, HorizontalAlignment.Center)
        '***********

        lvwDoubleLugListView.Columns.Add("Cost", 100, HorizontalAlignment.Center)
        lvwDoubleLugListView.Columns.Add("Sales", 100, HorizontalAlignment.Center)        '28_11_2012   RAGAVA
        '<<--20-12-2010 Aruna--
        lvwDoubleLugListView.Columns.Add("Is Existed", 45, HorizontalAlignment.Center)
        '--20-12-2010 Aruna-->>
        lvwDoubleLugListView.Columns.Add("IFLID", 45, HorizontalAlignment.Center)

        Dim intCount As Integer = 0
        Dim oListItem As ListViewItem

        If Not IsNothing(_oMatchedCastingDataTable) AndAlso _oMatchedCastingDataTable.Rows.Count > 0 Then
            'ANUP 07-10-2010 START
            If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Count > 0 Then
                ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Clear()
            End If
            'ANUP 07-10-2010 TILL HERE

            For Each _oMatchedCastingDataRow As DataRow In _oMatchedCastingDataTable.Rows
                Dim strPartCode_Purchase As String = String.Empty
                If Not IsDBNull(_oMatchedCastingDataRow("PartCode")) Then

                    'ANUP 07-10-2010 START
                    strPartCode_Purchase = ObjClsWeldedCylinderFunctionalClass.PartCOde_Purchased_ListViewClickedValidation(_oMatchedCastingDataRow("PartCode"))
                    oListItem = lvwDoubleLugListView.Items.Add(strPartCode_Purchase)
                    'ANUP 07-10-2010 TILL HERE
                Else
                    lvwDoubleLugListView.Items.Add("")
                End If

                If Not IsDBNull(_oMatchedCastingDataRow("Description")) Then
                    lvwDoubleLugListView.Items(intCount).SubItems.Add(_oMatchedCastingDataRow("Description"))
                Else
                    lvwDoubleLugListView.Items(intCount).SubItems.Add("")
                End If



                '31_05_2011  RAGAVA
                Try
                    Dim dblSafetyFactor As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SetSafetyFactorForExisting(strPartCode_Purchase)
                    If dblSafetyFactor > 0 Then
                        lvwDoubleLugListView.Items(intCount).SubItems.Add(dblSafetyFactor.ToString)
                    Else
                        If Not IsDBNull(_oMatchedCastingDataRow("CalculatedSafetyFactor")) Then
                            lvwDoubleLugListView.Items(intCount).SubItems.Add(_oMatchedCastingDataRow("CalculatedSafetyFactor"))
                        Else
                            lvwDoubleLugListView.Items(intCount).SubItems.Add("")
                        End If
                    End If
                Catch ex As Exception

                End Try

                ''TODO:Anup 09-04-10 2pm
                'If Not IsDBNull(_oMatchedCastingDataRow("CalculatedSafetyFactor")) Then
                '    lvwDoubleLugListView.Items(intCount).SubItems.Add(_oMatchedCastingDataRow("CalculatedSafetyFactor"))
                'Else
                '    lvwDoubleLugListView.Items(intCount).SubItems.Add("")
                'End If
                '***************
                'TILL   HERE

                '28_11_2012  RAGAVA
                Try
                    ObjClsWeldedCylinderFunctionalClass.GetCost_Sales(_oMatchedCastingDataRow("PartCode"), lvwDoubleLugListView, intCount)
                Catch ex As Exception

                End Try
                'If Not IsDBNull(_oMatchedCastingDataRow("Cost")) Then
                '    lvwDoubleLugListView.Items(intCount).SubItems.Add(_oMatchedCastingDataRow("Cost"))
                'Else
                '    lvwDoubleLugListView.Items(intCount).SubItems.Add("")
                'End If
                'Till   Here

                '<<--20-12-2010 Aruna--
                If Not IsDBNull(_oMatchedCastingDataRow("IsExisted")) Then
                    If _oMatchedCastingDataRow("IsExisted") = True Then
                        lvwDoubleLugListView.Items(intCount).SubItems.Add("Yes")
                    Else
                        lvwDoubleLugListView.Items(intCount).SubItems.Add("No")
                    End If
                Else
                    lvwDoubleLugListView.Items(intCount).SubItems.Add("No")
                End If
                '--20-12-2010 Aruna-->>
                If Not IsDBNull(_oMatchedCastingDataRow("IFLID")) Then
                    lvwDoubleLugListView.Items(intCount).SubItems.Add(_oMatchedCastingDataRow("IFLID"))
                Else
                    lvwDoubleLugListView.Items(intCount).SubItems.Add("")
                End If
                intCount += 1
            Next
        End If
        lvwDoubleLugListView.HideSelection = False
        lvwDoubleLugListView.FullRowSelect = True
    End Sub
    'Anup END

    Public Sub ManualLoad()
        LoadFunctionality()
    End Sub

    Private Sub LoadFunctionality()
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        InitialSettings()
        _oMatchedCastingDataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBEDLCastingDataTable
        PopulateInListView()

        'TODO:Sandeep 26-02-10-4
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Cast"
        '*************************
    End Sub

    'TODO:Anup 26-02-2010
    Private Sub UpdatePreviousFormDetails()
        '--------------------------------------------------------------------------------------------------------------------------------009
        If ObjClsWeldedCylinderFunctionalClass.MultiGenerate <> True Then
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnPrtNumChkd <> True Then
                Dim strMessage As String = "Base end Configuration will be updated with the selected DoubleLug casting details, " + vbCrLf
                If MessageBox.Show(strMessage, "Update TubeDetails", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
                    updatedetailsdoublelug()
                End If
            End If
        Else
            updatedetailsdoublelug()
        End If
        '----------------------------------------------------------------------------------------------------------------------------------009
    End Sub
    Sub updatedetailsdoublelug()
        If txtSwingClearance.Text <> "" Then
            '20_04_2012   RAGAVA 
            'Check
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance = Val(txtSwingClearance.Text)
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
            '   ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2 = Val(txtSwingClearance.Text)
            '  End If
            ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text = txtSwingClearance.Text
            'Till  Here
        End If

        '20_04_2012   RAGAVA            
        If txtLugThickness.Text <> "" Then
            'Check
            ' If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness.Text)
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2 = Val(txtLugThickness.Text)
            ' End If
            'commented for Weldment Option
            'ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd.Text = txtLugThickness.Text       '05_06_2012   RAGAVA
        End If
        'Till  Here
        If ObjClsWeldedCylinderFunctionalClass.PinHoleSize_Source = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.BushingPinHole Then
            'If txtPinHoleSize.Text <> "" Then
            '    ObjClsWeldedCylinderFunctionalClass.CmbBushingPinHoleSize_BaseEnd.Text = txtRequiredPinHoleSize.Text  'vamsi 30-01-2014
            'End If
            If txtPinHoleSize.Text <> "" And rdbResize.Checked = True Then
                ObjClsWeldedCylinderFunctionalClass.CmbBushingPinHoleSize_BaseEnd.Text = txtRequiredPinHoleSize.Text 'vamsi 30-01-2014
            Else
                ObjClsWeldedCylinderFunctionalClass.CmbBushingPinHoleSize_BaseEnd.Text = txtPinHoleSize.Text
            End If
        ElseIf ObjClsWeldedCylinderFunctionalClass.PinHoleSize_Source = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleCustom Then
            'If txtPinHoleSize.Text <> "" Then
            '    ObjClsWeldedCylinderFunctionalClass.TxtPinHoleSize_BaseEnd.Text = txtPinHoleSize.Text
            'End If.

            If txtPinHoleSize.Text <> "" And rdbResize.Checked = True Then
                ObjClsWeldedCylinderFunctionalClass.TxtPinHoleSize_BaseEnd.Text = txtRequiredPinHoleSize.Text 'vamsi 30-01-2014
            Else

                ObjClsWeldedCylinderFunctionalClass.TxtPinHoleSize_BaseEnd.Text = txtPinHoleSize.Text
            End If
        ElseIf ObjClsWeldedCylinderFunctionalClass.PinHoleSize_Source = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleStandard Then
            'If txtPinHoleSize.Text <> "" Then
            '    ObjClsWeldedCylinderFunctionalClass.CmbPinHoleSize_BaseEnd.Text = txtPinHoleSize.Text
            'End If
            If txtPinHoleSize.Text <> "" And rdbResize.Checked = True Then
                ObjClsWeldedCylinderFunctionalClass.CmbPinHoleSize_BaseEnd.Text = txtRequiredPinHoleSize.Text 'vamsi 30-01-2014

            Else

                ObjClsWeldedCylinderFunctionalClass.CmbPinHoleSize_BaseEnd.Text = txtPinHoleSize.Text
            End If
        End If

        If txtLugsGap.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.TxtLugGap_BaseEnd.Text = txtLugsGap.Text
        End If

        If txtLugsWidth.Text <> "" Then
            ' Check
            ' If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugsWidth.Text)
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2 = Val(txtLugsWidth.Text)
            ' End If
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugsWidth.Text)
        End If

        If txtGreaseZerk.Text <> "" AndAlso txtGreaseZerk.Text <> "N/A" Then
            ObjClsWeldedCylinderFunctionalClass.CmbGreaseZercs_BaseEnd.Text = txtGreaseZerk.Text
        End If

        If txtAngle1.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.TxtAngleOfGreaseZercs1_BaseEnd.Text = txtAngle1.Text
        End If

        If txtAngle2.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.TxtAngleOfGreaseZercs2_BaseEnd.Text = txtAngle2.Text
        End If

        'anup 30-08-2010
        If Not String.IsNullOrEmpty(txtPinHoleTole_Pos.Text) Then
            ObjClsWeldedCylinderFunctionalClass.TxtToleranceUpperLimit.Text = txtPinHoleTole_Pos.Text
        End If
        If Not String.IsNullOrEmpty(txtPinHoleTole_Neg.Text) Then
            ObjClsWeldedCylinderFunctionalClass.TxtToleranceLowerLimit.Text = txtPinHoleTole_Neg.Text
        End If
    End Sub

    'Anup END

#End Region

#Region "Events"

    Private Sub frmCastingYes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        LoadFunctionality()
    End Sub

    Private Sub lvwCastingListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwDoubleLugListView.SelectedIndexChanged
        rdbExactMatchYes.Checked = False             '09_11_2010    RAGAVA
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False      '09_11_2010    RAGAVA
        'ANUP 10-11-2010 START
        rdbResize.Checked = False
        rdbUseSelectedSingleLugYes.Checked = False
        rdbUseSelectedSingleLugNo.Checked = False
        'ANUP 10-11-2010 TILL HERE

        If lvwDoubleLugListView.SelectedIndices.Count > 0 Then
            'TODO:Anup 26-02-2010
            If rdbUseSelectedSingleLugYes.Checked = False Then
                ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            End If
            'TODO: ANUP 22-04-2010 03.42pm
            ' rdbUseSelectedSingleLugYes.Checked = True    'anup 22-12-2010 
            'Anup END

            Dim oListViewSelectedItem As ListViewItem = lvwDoubleLugListView.SelectedItems(0)
            Dim oSelectedCastingDataRow As DataRow = Nothing

            'ANUP 07-10-2010 START
            Dim strPartCodePassing_Purchased As String = oListViewSelectedItem.SubItems(DoubleLugListViewDetails.CodeNumber).Text
            Try
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd = oListViewSelectedItem.SubItems(2).Text      '31_05_2011   ragava
            Catch ex As Exception
            End Try
            ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode = strPartCodePassing_Purchased         '12_10_2010   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingCodeNumber = ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode    '07_02_2011 
            If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.ContainsKey(strPartCodePassing_Purchased) Then
                strPartCodePassing_Purchased = ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Item(strPartCodePassing_Purchased).ToString
            End If

            '25_10_2010   RAGAVA
            ''If ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode.StartsWith("7") Then
            ''    ObjClsWeldedCylinderFunctionalClass.DisplayImage("X:\WeldedModels\" & ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode & ".SLDPRT")
            ''End If
            'Till   Here

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
                oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                            GetBEDLCastWithOutPortSelectedRowDetails(strPartCodePassing_Purchased)
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then
                '27_04_2010    RAGAVA  NEW DESIGN
                If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                    'oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                    '                            GetBEDLCastingWithRaisedPortSelectedRowDetails(oListViewSelectedItem.SubItems(DoubleLugListViewDetails.CodeNumber).Text)
                    '19_05_2010   RAGAVA     NEW DESIGN
                    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                        oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                                                                        GetBEDLCastingWithRaisedPortSelectedRowDetails(strPartCodePassing_Purchased)
                    Else
                        oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                                                GetBEDLCastingWithRaisedPortSelectedRowDetails90(strPartCodePassing_Purchased)
                    End If
                    'Till   Here
                Else
                    oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                                                GetBEDLCastingWithFlushedPortSelectedRowDetails(strPartCodePassing_Purchased)
                End If
                'oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                '            GetBEDLCastingWithFlushedPortSelectedRowDetails(oListViewSelectedItem.SubItems(DoubleLugListViewDetails.CodeNumber).Text)
                'Till   Here
            End If

            If Not IsNothing(oSelectedCastingDataRow) Then
                If Not IsDBNull(oSelectedCastingDataRow("PartCode")) Then
                    txtCodeNumber.Text = oListViewSelectedItem.SubItems(DoubleLugListViewDetails.CodeNumber).Text
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = oSelectedCastingDataRow("PartCode")
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("DoubleLug without Port Code", oListViewSelectedItem.SubItems(DoubleLugListViewDetails.CodeNumber).Text)
                End If
                'ANUP 07-10-2010 TILL HERE

                DisplayToleranceValues(oSelectedCastingDataRow)

                'Raghavendra 26-02-2010
                If oSelectedCastingDataRow("PartType").ToString.Contains("IFL_PART") Then
                    '27_03_2012   RAGAVA
                    ' Check
                    ' If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "NewDesign"
                    'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                    ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign2 = "NewDesign"
                    ' End If
                    'Till  Here
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
                        '27_03_2012   RAGAVA
                        ' Check
                        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_NO_PO_GR_DOUBLELUG"
                        'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                        ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_NO_PO_GR_DOUBLELUG"
                        ' End If
                        'Till  Here
                    Else
                        If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                            If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                                '27_03_2012   RAGAVA
                                ' Check
                                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_DOUBLELUG"
                                'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                                '  ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_FI_DOUBLELUG"
                                'End If
                                'Till  Here
                            Else
                                '27_03_2012   RAGAVA
                                ' Check
                                ' If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_DOUBLELUG_90"
                                ' ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                                ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_FI_DOUBLELUG_90"
                                'End If
                                'Till  Here
                            End If
                        Else
                            '27_03_2012   RAGAVA
                            ' Check
                            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PI_GR_DOUBLELUG"
                            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                            ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_FL_PI_GR_DOUBLELUG"
                            'End If
                            'Till  Here
                        End If
                    End If
                Else
                    '27_03_2012   RAGAVA
                    ' Check
                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "Existing"
                    'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign2 = "Existing"
                    'End If
                    'Till  Here
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
                        '27_03_2012   RAGAVA
                        ' Check
                        ' If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "Dl_No_Port"
                        'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                        ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "Dl_No_Port"
                        ' End If
                        'Till  Here
                    Else
                        If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                            If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                                '27_03_2012   RAGAVA
                                ' Check
                                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_DOUBLELUG"
                                'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_FI_DOUBLELUG"
                                'End If
                                'Till  Here
                            Else
                                '27_03_2012   RAGAVA
                                ' Check
                                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_DOUBLELUG_90"
                                'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_FI_DOUBLELUG_90"
                                ' End If
                                'Till  Here
                            End If
                            'Till   Here
                        Else
                            '27_03_2012   RAGAVA
                            ' Check
                            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "Dl_Flused_Port"
                            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "Dl_Flused_Port"
                            'End If
                            'Till  Here
                        End If
                    End If
                End If
                If Not IsDBNull(oSelectedCastingDataRow("SwingClearanceRadius")) Then
                    txtSwingClearance.Text = oSelectedCastingDataRow("SwingClearanceRadius")
                End If


                If Not IsDBNull(oSelectedCastingDataRow("LugThickness")) Then
                    txtLugThickness.Text = oSelectedCastingDataRow("LugThickness")
                End If

                If Not IsDBNull(oSelectedCastingDataRow("PinHole_Combined")) Then
                    txtPinHoleSize.Text = oSelectedCastingDataRow("PinHole_Combined")
                End If

                If Not IsDBNull(oSelectedCastingDataRow("LugGap")) Then
                    txtLugsGap.Text = oSelectedCastingDataRow("LugGap")
                End If

                If Not IsDBNull(oSelectedCastingDataRow("LugWidth")) Then
                    txtLugsWidth.Text = oSelectedCastingDataRow("LugWidth")
                End If

                'If Not IsDBNull(oSelectedCastingDataRow("GreaseZerk")) Then
                '    txtGreaseZerk.Text = oSelectedCastingDataRow("GreaseZerk")
                'End If

                If Not IsDBNull(oSelectedCastingDataRow("GreaseZerkAngle1")) Then
                    txtAngle1.Text = oSelectedCastingDataRow("GreaseZerkAngle1")
                End If

                If Not IsDBNull(oSelectedCastingDataRow("GreaseZerkAngle2")) Then
                    txtAngle2.Text = oSelectedCastingDataRow("GreaseZerkAngle2")
                End If

                txtGreaseZerk.Text = ObjClsWeldedCylinderFunctionalClass.GetGreekZercQty(txtAngle1.Text, txtAngle2.Text)

                'TODO:Anup 26-02-2010
                If Not IsDBNull(oSelectedCastingDataRow("EndofTubetoRodStop")) Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = oSelectedCastingDataRow("EndofTubetoRodStop")
                End If

                If Not IsDBNull(oSelectedCastingDataRow("DistancefromPinHoletoRodStop")) Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedCastingDataRow("DistancefromPinHoletoRodStop")
                End If

                'Anup END
            End If
            rdbUseSelectedSingleLugYes.Checked = True   'anup 22-12-2010 
        Else
            txtCodeNumber.Text = ""
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("DoubleLug without Port Code", txtCodeNumber.Text)
            txtSwingClearance.Text = ""
            txtLugThickness.Text = ""
            txtPinHoleSize.Text = ""
            txtLugsGap.Text = ""
            txtLugsWidth.Text = ""
            txtGreaseZerk.Text = ""
            txtAngle1.Text = ""
            txtAngle2.Text = ""
            txtPinHoleTole_Neg.Text = ""
            txtPinHoleTole_Pos.Text = ""
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = 0
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = 0
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

    'TODO:Anup 26-02-2010
    Private Sub rdbUseSelectedSingleLugYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedSingleLugYes.CheckedChanged

        
        If rdbUseSelectedSingleLugYes.Checked Then

            '27-04-2012 MANJULA ADDED
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then

                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.plnPortInTube_Casting.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.rdbDesignACasting.Checked = True
                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.rdbFabricated.Checked = False

                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral2.plnPortInTube_Casting.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral2.rdbDesignACasting.Checked = False
                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral2.rdbFabricated.Checked = False

            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then

                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.plnFabrication_Casting.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.rdbDesignACasting.Checked = True
                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.rdbFabrication.Checked = False

                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.plnFabrication_Casting.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.rdbDesignACasting.Checked = False
                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.rdbFabrication.Checked = False

            End If
            '**************************

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast"               'Check
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness.Text)      'Check
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance = Val(txtSwingClearance.Text)  'Check
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugsWidth.Text)             'Check

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
            '********************************

            'Till  Here
            'ONSITE:19-05-2010
            If txtPinHoleSize.Text <> "" AndAlso txtRequiredPinHoleSize.Text <> "" Then
                If ObjClsWeldedCylinderFunctionalClass.PinHoleSizeDiffere(Val(txtPinHoleSize.Text), Val(txtRequiredPinHoleSize.Text)) Then
                    'grbUsingSelectedDoubleLug.Visible = False  'anup 23-12-2010 
                    grbUsingSelectedDoubleLug.Visible = True 'anup 18-03-2011
                    rdbExactMatchYes.Checked = False 'anup 18-03-2011 changed true to false
                Else
                    grbUsingSelectedDoubleLug.Visible = True
                End If
            Else
                grbUsingSelectedDoubleLug.Visible = True
            End If

            grbNotUsingSelectedDoubleLugCasting.Visible = False
            ObjClsWeldedCylinderFunctionalClass.ShowCastingNo_Thru_CastingYes = False
        End If
    End Sub

    'TODO:Anup 26-02-2010
    Private Sub rdbUseSelectedSingleLugNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedSingleLugNo.CheckedChanged
        Try
            If rdbUseSelectedSingleLugNo.Checked Then

                '27-04-2012 MANJULA ADDED
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then

                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.plnPortInTube_Casting.Controls.Clear()
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.rdbDesignACasting.Checked = False
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.rdbFabricated.Checked = False
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.rdbDesignACasting.Enabled = True
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.rdbFabricated.Enabled = True
                    

                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral2.plnPortInTube_Casting.Controls.Clear()
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral2.rdbDesignACasting.Checked = False
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral2.rdbFabricated.Checked = False

                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then

                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.plnFabrication_Casting.Controls.Clear()
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.rdbDesignACasting.Checked = False
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.rdbFabrication.Checked = False
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.rdbDesignACasting.Enabled = True
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.rdbFabrication.Enabled = True

                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.plnFabrication_Casting.Controls.Clear()
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.rdbDesignACasting.Checked = False
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.rdbFabrication.Checked = False

                End If
                '*****************************
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = ""       '15_03_2012   RAGAVA

                '30_05_2012   RAGAVA
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.txtLugThickness.Text)      'Check
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance = Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.txtSwingClearance.Text)  'Check
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

                grbUsingSelectedDoubleLug.Visible = False
                grbNotUsingSelectedDoubleLugCasting.Visible = True
                ObjClsWeldedCylinderFunctionalClass.ShowCastingNo_Thru_CastingYes = True
                ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False        '20_10_2010    RAGAVA
                '13_03_2012   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.rdbFabricated.Checked = False
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.rdbFabrication.Checked = False
                End If
                'Till  Here
            End If
        Catch ex As Exception
        End Try
    End Sub

    'TODO:Anup 26-02-2010
    Private Sub rdbExactMatchYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbExactMatchYes.CheckedChanged
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = ""    '03_03_2010    ARUNA
        If rdbExactMatchYes.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewCastingGenerated = False             '17_10_2012   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Exact"
            ' grbNotExactMatch.Visible = False '5_3_2010 ARUNA
            UpdatePreviousFormDetails()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = True        '20_10_2010    RAGAVA
        End If
    End Sub

    'TODO:Anup 26-02-2010
    Private Sub rdbExactMatchNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If rdbExactMatchNo.Checked Then
        '    grbNotExactMatch.Visible = True
        'End If
        '5_3_2010 ARUNA
    End Sub

    'TODO:Anup 26-02-2010
    Private Sub rdbResize_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbResize.CheckedChanged
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = ""    '03_03_2010    ARUNA
        If rdbResize.Checked Then
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize"
            UpdatePreviousFormDetails()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = True        '20_10_2010    RAGAVA
        End If
    End Sub

    'TODO:Anup 26-02-2010
    Private Sub rdbNewCasting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbNewCasting.CheckedChanged
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = ""    '03_03_2010    ARUNA
        If rdbNewCasting.Checked Then
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "NewDesign"
            UpdatePreviousFormDetails()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False        '20_10_2010    RAGAVA
        End If
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblDoubleLugCasting)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblUsingSelectedDoubleLug)
        'A0308: ANUP 03-08-2010 02.28pm
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblNotUsingSelectedDoubleLug)
    End Sub

End Class