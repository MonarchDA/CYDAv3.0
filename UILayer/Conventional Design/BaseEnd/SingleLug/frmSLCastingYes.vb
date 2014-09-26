Public Class frmSLCastingYes

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

    Private _oMatchedSingleLugCastingDataTable As DataTable

#End Region

#Region "Enum"

    Public Enum SingleLugListViewDetails
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
        rdbUseSelectedSingleLugYes.Checked = True
        ' grbNotExactMatch.Visible = False
        txtCodeNumber.Enabled = False
        txtSwingClearance.Enabled = False
        txtRequiredSwingClearance.Enabled = False
        txtLugThickness.Enabled = False
        txtRequiredLugThickness.Enabled = False
        txtPinHoleSize.Enabled = False
        txtRequiredPinHoleSize.Enabled = False
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
        txtRequiredLugsWidth.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
        txtRequiredGreaseZerk.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs
        txtRequiredAngle1.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1
        txtRequiredAngle2.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2

        'Sandeep 25-02-10 10am
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False

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

    Private Sub LoadFunctionality()
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        InitialSettings()
        _oMatchedSingleLugCastingDataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBESLCastingDataTable
        PopulateInListView()
        'TODO:Sandeep 26-02-10-2pm
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Cast"
        '*************************
    End Sub

    Private Sub PopulateInListView()
        lvwSingleLugListView.Clear()
        lvwSingleLugListView.Columns.Add("Code No", 100, HorizontalAlignment.Center)
        lvwSingleLugListView.Columns.Add("Description", 220, HorizontalAlignment.Center)

        'TODO:Anup 09-04-10 2pm
        lvwSingleLugListView.Columns.Add("SafetyFactor", 100, HorizontalAlignment.Center)
        '***********

        lvwSingleLugListView.Columns.Add("Cost", 100, HorizontalAlignment.Center)
        lvwSingleLugListView.Columns.Add("Sales", 100, HorizontalAlignment.Center)        '28_11_2012   RAGAVA
      
        '<<--20-12-2010 Aruna--
        lvwSingleLugListView.Columns.Add("Is Existed", 45, HorizontalAlignment.Center)
        '--20-12-2010 Aruna-->>
        lvwSingleLugListView.Columns.Add("IFLID", 45, HorizontalAlignment.Center)
        Dim intCount As Integer = 0
        Dim oListItem As ListViewItem
        Try
            If Not IsNothing(_oMatchedSingleLugCastingDataTable) AndAlso _oMatchedSingleLugCastingDataTable.Rows.Count > 0 Then
                Dim strPartCode_Purchase As String = String.Empty
                'ANUP 07-10-2010 START
                If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Count > 0 Then
                    ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Clear()
                End If
                'ANUP 07-10-2010 TILL HERE 

                For Each _oMatchedSingleLugCastingDataRow As DataRow In _oMatchedSingleLugCastingDataTable.Rows
                    If Not IsDBNull(_oMatchedSingleLugCastingDataRow("PartCode")) Then

                        'ANUP 07-10-2010 START
                        strPartCode_Purchase = ObjClsWeldedCylinderFunctionalClass.PartCOde_Purchased_ListViewClickedValidation(_oMatchedSingleLugCastingDataRow("PartCode"))
                        oListItem = lvwSingleLugListView.Items.Add(strPartCode_Purchase)
                        'ANUP 07-10-2010 TILL HERE

                    Else
                        lvwSingleLugListView.Items.Add("")
                    End If

                    If Not IsDBNull(_oMatchedSingleLugCastingDataRow("Description")) Then
                        lvwSingleLugListView.Items(intCount).SubItems.Add(_oMatchedSingleLugCastingDataRow("Description"))
                    Else
                        lvwSingleLugListView.Items(intCount).SubItems.Add("")
                    End If



                    '31_05_2011  RAGAVA
                    Try
                        Dim dblSafetyFactor As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SetSafetyFactorForExisting(strPartCode_Purchase)
                        If dblSafetyFactor > 0 Then
                            lvwSingleLugListView.Items(intCount).SubItems.Add(dblSafetyFactor.ToString)
                        Else
                            If Not IsDBNull(_oMatchedSingleLugCastingDataRow("CalculatedSafetyFactor")) Then
                                lvwSingleLugListView.Items(intCount).SubItems.Add(_oMatchedSingleLugCastingDataRow("CalculatedSafetyFactor"))
                            Else
                                lvwSingleLugListView.Items(intCount).SubItems.Add("")
                            End If
                        End If
                    Catch ex As Exception

                    End Try

                    ''TODO:Anup 09-04-10 2pm
                    'If Not IsDBNull(_oMatchedSingleLugCastingDataRow("CalculatedSafetyFactor")) Then
                    '    lvwSingleLugListView.Items(intCount).SubItems.Add(_oMatchedSingleLugCastingDataRow("CalculatedSafetyFactor"))
                    'Else
                    '    lvwSingleLugListView.Items(intCount).SubItems.Add("")
                    'End If
                    ''***************
                    'TILL   HERE
                    '28_11_2012  RAGAVA
                    Try
                        ObjClsWeldedCylinderFunctionalClass.GetCost_Sales(_oMatchedSingleLugCastingDataRow("PartCode"), lvwSingleLugListView, intCount)
                    Catch ex As Exception

                    End Try
                    'If Not IsDBNull(_oMatchedSingleLugCastingDataRow("Cost")) Then
                    '    lvwSingleLugListView.Items(intCount).SubItems.Add(_oMatchedSingleLugCastingDataRow("Cost"))
                    'Else
                    '    lvwSingleLugListView.Items(intCount).SubItems.Add("")
                    'End If
                    'Till   Here

                    '<<--20-12-2010 Aruna--
                    If Not IsDBNull(_oMatchedSingleLugCastingDataRow("IsExisted")) Then
                        If _oMatchedSingleLugCastingDataRow("IsExisted") = True Then
                            lvwSingleLugListView.Items(intCount).SubItems.Add("Yes")
                        Else
                            lvwSingleLugListView.Items(intCount).SubItems.Add("No")
                        End If
                    Else
                        lvwSingleLugListView.Items(intCount).SubItems.Add("No")
                    End If
                    '--20-12-2010 Aruna-->>

                    If Not IsDBNull(_oMatchedSingleLugCastingDataRow("IFLID")) Then
                        lvwSingleLugListView.Items(intCount).SubItems.Add(_oMatchedSingleLugCastingDataRow("IFLID"))
                    Else
                        lvwSingleLugListView.Items(intCount).SubItems.Add("")
                    End If
                    intCount += 1
                Next
            End If
            lvwSingleLugListView.HideSelection = False
            lvwSingleLugListView.FullRowSelect = True
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in PopulateInListView of frmSLCastingYes " + ex.Message)
        End Try
    End Sub

    Private Sub UpdatePreviousFormDetails()
        'Sandeep 25-02-10 10am

        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------009

        If ObjClsWeldedCylinderFunctionalClass.MultiGenerate <> True Then
            Dim strMessage As String = "Base end Configuration will be updated with the selected SingleLug casting details, " + vbCrLf
            If MessageBox.Show(strMessage, "Update TubeDetails", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
                UpdatePreviousFormDetails1()
            End If
        Else
            UpdatePreviousFormDetails1()
        End If

       
    End Sub
    Public Sub UpdatePreviousFormDetails1()
        If txtSwingClearance.Text <> "" Then
            ''20_04_2012   RAGAVA 
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance = Val(txtSwingClearance.Text)
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2 = Val(txtSwingClearance.Text)
            'End If
            ''ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text = txtSwingClearance.Text
            ''Till  Here
        End If

        '20_04_2012   RAGAVA            
        If txtLugThickness.Text <> "" Then
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness.Text)
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2 = Val(txtLugThickness.Text)
            'End If
            'commented for Weldment Option
            'ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd.Text = txtLugThickness.Text
        End If
        'Till  Here

        If ObjClsWeldedCylinderFunctionalClass.PinHoleSize_Source = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.BushingPinHole Then
            If txtPinHoleSize.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.CmbBushingPinHoleSize_BaseEnd.Text = txtPinHoleSize.Text
            End If
        ElseIf ObjClsWeldedCylinderFunctionalClass.PinHoleSize_Source = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleCustom Then
            If txtPinHoleSize.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtPinHoleSize_BaseEnd.Text = txtPinHoleSize.Text
            End If
        ElseIf ObjClsWeldedCylinderFunctionalClass.PinHoleSize_Source = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleStandard Then
            If txtPinHoleSize.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.CmbPinHoleSize_BaseEnd.Text = txtPinHoleSize.Text
            End If
        End If

        If txtLugsWidth.Text <> "" Then
            '20_04_2012   RAGAVA  
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugsWidth.Text)
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2 = Val(txtLugsWidth.Text)
            'End If
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugsWidth.Text)
            'Till   Here
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
#End Region

#Region "Events"

    Private Sub frmSLCastingYes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        LoadFunctionality()
    End Sub

    Private Sub lvwSingleLugListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwSingleLugListView.SelectedIndexChanged
        'ANUP 10-11-2010 START
        rdbExactMatchYes.Checked = False
        rdbResize.Checked = False
        rdbUseSelectedSingleLugYes.Checked = False
        rdbUseSelectedSingleLugNo.Checked = False
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        'ANUP 10-11-2010 TILL HERE
        Try
            If lvwSingleLugListView.SelectedIndices.Count > 0 Then

                'Sandeep 25-02-10 10am
                '1_03_2010 Aruna
                If rdbUseSelectedSingleLugNo.Checked Then
                    ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
                ElseIf rdbUseSelectedSingleLugYes.Checked = False Then
                    ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
                End If

                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SearchFound = "BaseEndSingleLugFound"
                Dim oListViewSelectedItem As ListViewItem = lvwSingleLugListView.SelectedItems(0)
                Dim oSelectedCastingDataRow As DataRow = Nothing
                'ANUP 07-10-2010 START
                Dim strPartCodePassing_Purchased As String = oListViewSelectedItem.SubItems(SingleLugListViewDetails.CodeNumber).Text
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
                                GetBESLCastWithOutPortSelectedRowDetails(strPartCodePassing_Purchased)
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then
                    'oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                    '            GetBESLCastingWithFlushedPortSelectedRowDetails(oListViewSelectedItem.SubItems(SingleLugListViewDetails.CodeNumber).Text)
                    '27_04_2010    RAGAVA
                    If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                        '19_05_2010   RAGAVA     NEW DESIGN
                        If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                            oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetBESLCastingWithRaisedPortSelectedRowDetails(strPartCodePassing_Purchased)
                        Else
                            oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetBESLCastingWithRaisedPortSelectedRowDetails90(strPartCodePassing_Purchased)
                        End If
                        'Till    Here
                    Else
                        oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
            GetBESLCastingWithFlushedPortSelectedRowDetails(oListViewSelectedItem.SubItems(SingleLugListViewDetails.CodeNumber).Text)
                    End If
                    'Till   Here
                End If

                If Not IsNothing(oSelectedCastingDataRow) Then
                    Try

                        If Not IsDBNull(oSelectedCastingDataRow("PartCode")) Then
                            txtCodeNumber.Text = oListViewSelectedItem.SubItems(SingleLugListViewDetails.CodeNumber).Text
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = oSelectedCastingDataRow("PartCode")
                            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("SingleLug without Port Code", oListViewSelectedItem.SubItems(SingleLugListViewDetails.CodeNumber).Text)
                        End If
                        'ANUP 07-10-2010 TILL HERE

                        '24_02_2010 Aruna Start
                        If oSelectedCastingDataRow("PartType").ToString.Contains("IFL_PART") Then
                            '20_04_2012  RAGAVA
                            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "NewDesign"
                            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_NO_PO_GR_SINGLELUG"
                            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "NewDesign"
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_NO_PO_GR_SINGLELUG"
                            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign2 = "NewDesign"
                            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_NO_PO_GR_SINGLELUG"
                            'End If
                            'Till  Here
                            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_SINGLELUG"

                                If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                                    ''20_04_2012  RAGAVA
                                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_SINGLELUG"
                                    'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_FI_SINGLELUG"
                                    'End If
                                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_SINGLELUG"
                                    'Till  Here
                                Else
                                    '20_04_2012  RAGAVA
                                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_SINGLELUG_90"
                                    'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                                    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_FI_SINGLELUG_90"
                                    'End If
                                    'ObjClsWeldedCylinderFunctionaClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_SINGLELUG_90"
                                    'Till   Here
                                End If
                            End If
                            'Till  Here
                        Else
                            '20_04_2012  RAGAVA
                            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "Existing"
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "Sl_No_Port"
                            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign2 = "Existing"
                            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "Sl_No_Port"
                            'End If
                            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "Existing"
                            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "Sl_No_Port"
                            'Till   Here
                        End If
                        '24_02_2010 Aruna End

                        If Not IsDBNull(oSelectedCastingDataRow("SwingClearanceRadius")) Then
                            txtSwingClearance.Text = oSelectedCastingDataRow("SwingClearanceRadius")
                        End If

                        If Not IsDBNull(oSelectedCastingDataRow("LugThickness")) Then
                            txtLugThickness.Text = oSelectedCastingDataRow("LugThickness")
                        End If

                        If Not IsDBNull(oSelectedCastingDataRow("PinHole_Combined")) Then
                            txtPinHoleSize.Text = oSelectedCastingDataRow("PinHole_Combined")
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

                        If Not IsDBNull(oSelectedCastingDataRow("EndofTubetoRodStop")) Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = oSelectedCastingDataRow("EndofTubetoRodStop")
                        End If

                        If Not IsDBNull(oSelectedCastingDataRow("DistancefromPinholetoRodStop")) Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedCastingDataRow("DistancefromPinholetoRodStop")
                        End If

                        DisplayToleranceValues(oSelectedCastingDataRow)
                    Catch ex As Exception

                    End Try
                End If
            Else
                txtCodeNumber.Text = ""
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("SingleLug without Port Code", txtCodeNumber.Text)
                txtSwingClearance.Text = ""
                txtLugThickness.Text = ""
                txtPinHoleSize.Text = ""
                txtLugsWidth.Text = ""
                txtGreaseZerk.Text = ""
                txtAngle1.Text = ""
                txtAngle2.Text = ""
                txtPinHoleTole_Neg.Text = ""
                txtPinHoleTole_Pos.Text = ""
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = 0
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = 0
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = 0
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in lvwSingleLugListView_SelectedIndexChanged of frmSLCastingYes " + ex.Message)
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
        If rdbUseSelectedSingleLugYes.Checked Then
            '20_04_2012  RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast"
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness.Text)
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2 = Val(txtLugThickness.Text)
            'End If
            'Till  Here
            '10-05-2012 MANJULA ADDED
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then

                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.plnPortInTube_Casting.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.rdbDesignACasting.Checked = True
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.rdbFabricated.Checked = False

                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral2.plnPortInTube_Casting.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral2.rdbDesignACasting.Checked = False
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral2.rdbFabricated.Checked = False

            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then

                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.plnFabrication_Casting.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.rdbDesignACasting.Checked = True
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.rdbFabrication.Checked = False

                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube2.plnFabrication_Casting.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube2.rdbDesignACasting.Checked = False
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube2.rdbFabrication.Checked = False

            End If
           
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLPortIntegral._dblTempLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLPortIntegral2._dblTempLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral2.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness

            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLPortinTube._dblTempLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLPortinTube2._dblTempLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube2.dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness

            End If
            '********************************
           
            If txtPinHoleSize.Text <> "" AndAlso txtRequiredPinHoleSize.Text <> "" Then
                If ObjClsWeldedCylinderFunctionalClass.PinHoleSizeDiffere(Val(txtPinHoleSize.Text), Val(txtRequiredPinHoleSize.Text)) Then
                    ' grbUsingSelectedSingleLug.Visible = False    'anup 23-12-2010 
                    rdbExactMatchYes.Checked = True
                Else
                    grbUsingSelectedSingleLug.Visible = True
                End If
            Else
                grbUsingSelectedSingleLug.Visible = True
            End If
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True 'MANJULA ADDED
            grbNotUsingSelectedSingleLugCasting.Visible = False
            ObjClsWeldedCylinderFunctionalClass.ShowCastingNo_Thru_CastingYes = False

            lvwSingleLugListView.Tag = "Validation Required"
        End If
    End Sub

    Private Sub rdbUseSelectedSingleLugNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedSingleLugNo.CheckedChanged
        If rdbUseSelectedSingleLugNo.Checked Then
            '08-05-2012 MANJULA ADDED
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then

                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.plnPortInTube_Casting.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.rdbDesignACasting.Checked = False
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.rdbFabricated.Checked = False
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.rdbDesignACasting.Enabled = True
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral.rdbFabricated.Enabled = True


                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral2.plnPortInTube_Casting.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral2.rdbDesignACasting.Checked = False
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral2.rdbFabricated.Checked = False

            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then

                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.plnFabrication_Casting.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.rdbDesignACasting.Checked = False
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.rdbFabrication.Checked = False
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.rdbDesignACasting.Enabled = True
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube.rdbFabrication.Enabled = True


                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube2.plnFabrication_Casting.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube2.rdbDesignACasting.Checked = False
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortInTube2.rdbFabrication.Checked = False

            End If
            '*****************************
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = ""       '20_04_2012   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False        '20_10_2010    RAGAVA
            grbUsingSelectedSingleLug.Visible = False
            grbNotUsingSelectedSingleLugCasting.Visible = True
            ObjClsWeldedCylinderFunctionalClass.ShowCastingNo_Thru_CastingYes = True
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True

            lvwSingleLugListView.Tag = "Validation Not Required"
        End If
    End Sub

    Private Sub rdbExactMatchYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbExactMatchYes.CheckedChanged
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewCastingGenerated = False             '17_10_2012   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = ""    '03_03_2010    ARUNA
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndCasting_New = False       '18_07_2012   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast"       '20_04_2012   RAGAVA
        ''20_04_2012  RAGAVA
        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness.Text)
        'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2 = Val(txtLugThickness.Text)
        'End If
        ''Till  Here

        If rdbExactMatchYes.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = True        '20_10_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Exact"
            ' grbNotExactMatch.Visible = False
            UpdatePreviousFormDetails()

            'Sandeep 25-02-10 10am
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        End If
    End Sub

    Private Sub rdbExactMatchNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If rdbExactMatchNo.Checked Then
        '    grbNotExactMatch.Visible = True

        'End If
    End Sub

    Private Sub rdbResize_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbResize.CheckedChanged
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = ""    '03_03_2010    ARUNA
        If rdbResize.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = True        '20_10_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize"
            UpdatePreviousFormDetails()

            'Sandeep 25-02-10 10am
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        End If
    End Sub

    Private Sub rdbNewCasting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbNewCasting.CheckedChanged
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = ""    '03_03_2010    ARUNA
        If rdbNewCasting.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False        '20_10_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "NewDesign"
            UpdatePreviousFormDetails()

            'Sandeep 25-02-10 10am
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        End If
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblSingleLugCasting)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblUsingSelectedSingleLug)
        'A0308: ANUP 03-08-2010 02.28pm
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblNotUsingSelectedSingleLug)
    End Sub
   
End Class