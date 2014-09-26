Public Class frmCTCastingYes

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

#Region "Enum"

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

        txtCodeNumber.Enabled = False
        txtCodeNumber.BackColor = Color.Empty

        txtCrossTubeOD.Enabled = False
        txtCrossTubeOD.BackColor = Color.Empty

        txtCrossTubeWidth.Enabled = False
        txtCrossTubeWidth.BackColor = Color.Empty

        txtRequiredCrossTubeWidth.Enabled = False
        txtRequiredCrossTubeWidth.BackColor = Color.Empty

        txtPinHoleSize.Enabled = False
        txtPinHoleSize.BackColor = Color.Empty

        txtRequiredPinHoleSize.Enabled = False
        txtRequiredPinHoleSize.BackColor = Color.Empty

        txtGreaseZerk.Enabled = False
        txtGreaseZerk.BackColor = Color.Empty

        txtRequiredGreaseZerk.Enabled = False
        txtRequiredGreaseZerk.BackColor = Color.Empty

        txtAngle1.Enabled = False
        txtAngle1.BackColor = Color.Empty

        txtRequiredAngle1.Enabled = False
        txtRequiredAngle1.BackColor = Color.Empty

        txtAngle2.Enabled = False
        txtAngle2.BackColor = Color.Empty

        txtRequiredAngle2.Enabled = False
        txtRequiredAngle2.BackColor = Color.Empty

        txtOffset.Enabled = False
        txtOffset.BackColor = Color.Empty

        txtRequiredOffset.Enabled = False
        txtRequiredOffset.BackColor = Color.Empty

        ' chkUseSelectedCrossTubeCasting.Checked = True
        'rdbResize.Checked = True        '27_02_2010    RAGAVA
        ' rdbUseSelectedCrossTubeYes.Checked = True '3_3_2010 Aruna
        '  grbNotExactMatch.Visible = False '05_03_2010 ARUNA
        txtRequiredCrossTubeWidth.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
        txtRequiredPinHoleSize.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
        txtRequiredGreaseZerk.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs
        txtRequiredAngle1.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle1
        txtRequiredAngle2.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercAngle2
        txtRequiredOffset.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OffSet

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
        _oMatchedCrossTubeCastingDataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBECrossTubeCastingDataTable
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Cast" '27_02_2010 

        PopulateInListView()
    End Sub

    Private Sub PopulateInListView()
        lvwCrossTubeListView.Clear()
        lvwCrossTubeListView.Columns.Add("Code No", 100, HorizontalAlignment.Center)
        lvwCrossTubeListView.Columns.Add("Description", 220, HorizontalAlignment.Center)

        'TODO:Anup 09-04-10 2pm
        lvwCrossTubeListView.Columns.Add("SafetyFactor", 100, HorizontalAlignment.Center)
        '***********

        lvwCrossTubeListView.Columns.Add("Cost", 100, HorizontalAlignment.Center)
        '<<--20-12-2010 Aruna--

        lvwCrossTubeListView.Columns.Add("Sales", 100, HorizontalAlignment.Center)        '26_11_2012   RAGAVA

        lvwCrossTubeListView.Columns.Add("Is Existed", 45, HorizontalAlignment.Center)
        '--20-12-2010 Aruna-->>
        Dim intCount As Integer = 0
        Dim oListItem As ListViewItem
        Try
            If Not IsNothing(_oMatchedCrossTubeCastingDataTable) AndAlso _oMatchedCrossTubeCastingDataTable.Rows.Count > 0 Then
                Dim strPartCode_Purchase As String = String.Empty
                'ANUP 07-10-2010 START
                If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Count > 0 Then
                    ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Clear()
                End If
                'ANUP 07-10-2010 TILL HERE.
                For Each _oMatchedCrossTubeCastingDataRow As DataRow In _oMatchedCrossTubeCastingDataTable.Rows
                    If Not IsDBNull(_oMatchedCrossTubeCastingDataRow("PartCode")) Then

                        'ANUP 07-10-2010 START
                        strPartCode_Purchase = ObjClsWeldedCylinderFunctionalClass.PartCOde_Purchased_ListViewClickedValidation(_oMatchedCrossTubeCastingDataRow("PartCode"))
                        oListItem = lvwCrossTubeListView.Items.Add(strPartCode_Purchase)
                        'ANUP 07-10-2010 TILL HERE
                    End If

                    If Not IsDBNull(_oMatchedCrossTubeCastingDataRow("Description")) Then
                        lvwCrossTubeListView.Items(intCount).SubItems.Add(_oMatchedCrossTubeCastingDataRow("Description"))
                    End If


                    '31_05_2011  RAGAVA
                    Try
                        Dim dblSafetyFactor As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SetSafetyFactorForExisting(strPartCode_Purchase)
                        If dblSafetyFactor > 0 Then
                            lvwCrossTubeListView.Items(intCount).SubItems.Add(dblSafetyFactor.ToString)
                        Else
                            If Not IsDBNull(_oMatchedCrossTubeCastingDataRow("CalculatedSafetyFactor")) Then
                                lvwCrossTubeListView.Items(intCount).SubItems.Add(_oMatchedCrossTubeCastingDataRow("CalculatedSafetyFactor"))
                            Else
                                lvwCrossTubeListView.Items(intCount).SubItems.Add("")
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    ''TODO:Anup 09-04-10 2pm
                    'If Not IsDBNull(_oMatchedCrossTubeCastingDataRow("CalculatedSafetyFactor")) Then
                    '    lvwCrossTubeListView.Items(intCount).SubItems.Add(_oMatchedCrossTubeCastingDataRow("CalculatedSafetyFactor"))
                    'Else
                    '    lvwCrossTubeListView.Items(intCount).SubItems.Add("")
                    'End If
                    ''***************


                    '26_11_2012  RAGAVA
                    Try
                        ObjClsWeldedCylinderFunctionalClass.GetCost_Sales(_oMatchedCrossTubeCastingDataRow("PartCode"), lvwCrossTubeListView, intCount)
                    Catch ex As Exception

                    End Try
                    'If Not IsDBNull(_oMatchedCrossTubeCastingDataRow("Cost")) Then
                    '    lvwCrossTubeListView.Items(intCount).SubItems.Add(_oMatchedCrossTubeCastingDataRow("Cost"))
                    'End If
                    'TILL  HERE

                    '<<--20-12-2010 Aruna--
                    If Not IsDBNull(_oMatchedCrossTubeCastingDataRow("IsExisted")) Then
                        If _oMatchedCrossTubeCastingDataRow("IsExisted") = True Then
                            lvwCrossTubeListView.Items(intCount).SubItems.Add("Yes")
                            lvwCrossTubeListView.Items(intCount).ForeColor = Color.Red         '02_02_2011   RAGAVA
                        Else
                            lvwCrossTubeListView.Items(intCount).SubItems.Add("No")
                        End If
                    Else
                        lvwCrossTubeListView.Items(intCount).SubItems.Add("No")
                    End If
                    '--20-12-2010 Aruna-->>
                    intCount += 1
                Next
            End If
            lvwCrossTubeListView.HideSelection = False
            lvwCrossTubeListView.FullRowSelect = True
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in PopulateInListView of frmCTCastingYes " + ex.Message)
        End Try
    End Sub

#End Region

#Region "Events"

    Private Sub frmCTCastingYes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        LoadFunctionality()
    End Sub

    Private Sub lvwCrossTubeListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwCrossTubeListView.SelectedIndexChanged
        'ANUP 10-11-2010 START
        rdbExactMatchYes.Checked = False
        rdbResize.Checked = False
        rdbUseSelectedCrossTubeYes.Checked = False
        rdbUseSelectedCrossTubeNo.Checked = False
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        'ANUP 10-11-2010 TILL HERE
        Try
            If lvwCrossTubeListView.SelectedIndices.Count > 0 Then
                '1_03_2010 Aruna
                If rdbUseSelectedCrossTubeNo.Checked Then
                    ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
                ElseIf rdbUseSelectedCrossTubeYes.Checked = False Then
                    ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
                End If

                Dim oListViewSelectedItem As ListViewItem = lvwCrossTubeListView.SelectedItems(0)
                Dim oSelectedCastingDataRow As DataRow = Nothing

                'ANUP 07-10-2010 START
                Dim strPartCodePassing_Purchased As String = oListViewSelectedItem.SubItems(CrossTubeListViewDetails.CodeNumber).Text
                Try
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd = oListViewSelectedItem.SubItems(2).Text      '31_05_2011   ragava
                Catch ex As Exception
                End Try
                ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode = strPartCodePassing_Purchased         '12_10_2010   RAGAVA
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingCodeNumber = ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode      '07_02_2011 
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
                                GetBECrossTubeCastWithOutPortSelectedRowDetails(strPartCodePassing_Purchased)
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then
                    '27_04_2010    RAGAVA  NEW DESIGN
                    If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                        If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then          '19_05_2010   RAGAVA     NEW DESIGN
                            oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                                                            GetBECrossTubeCastRaisedPortSelectedRowDetails(strPartCodePassing_Purchased)
                            '19_05_2010   RAGAVA     NEW DESIGN
                        Else
                            oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                                                                                       GetBECrossTubeCastRaisedPortSelectedRowDetails90(strPartCodePassing_Purchased)
                        End If
                        'Till   Here
                    Else
                        oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                                GetBECrossTubeCastFlushPortSelectedRowDetails(oListViewSelectedItem.SubItems(CrossTubeListViewDetails.CodeNumber).Text)
                    End If
                    'oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                    '            GetBECrossTubeCastFlushPortSelectedRowDetails(oListViewSelectedItem.SubItems(CrossTubeListViewDetails.CodeNumber).Text)
                    'Till   here
                End If

                If Not IsNothing(oSelectedCastingDataRow) Then
                    If Not IsDBNull(oSelectedCastingDataRow("PartCode")) Then
                        txtCodeNumber.Text = oListViewSelectedItem.SubItems(CrossTubeListViewDetails.CodeNumber).Text

                        '1_03_2010 Aruna
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = oSelectedCastingDataRow("PartCode")
                        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("CrossTube without Port Code", oListViewSelectedItem.SubItems(CrossTubeListViewDetails.CodeNumber).Text)
                    End If
                    'ANUP 07-10-2010 TILL HERE

                    If Not IsDBNull(oSelectedCastingDataRow("CrossTubeOD")) Then
                        txtCrossTubeOD.Text = oSelectedCastingDataRow("CrossTubeOD")
                    End If

                    If Not IsDBNull(oSelectedCastingDataRow("CrossTubeWidth")) Then
                        txtCrossTubeWidth.Text = oSelectedCastingDataRow("CrossTubeWidth")
                    End If

                    If Not IsDBNull(oSelectedCastingDataRow("PinHole_Combined")) Then
                        txtPinHoleSize.Text = oSelectedCastingDataRow("PinHole_Combined")
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

                    If Not IsDBNull(oSelectedCastingDataRow("OffSet")) Then
                        txtOffset.Text = oSelectedCastingDataRow("OffSet")
                    End If

                    If Not IsDBNull(oSelectedCastingDataRow("DistanceFromPinHoleToRodStop")) Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedCastingDataRow("DistanceFromPinHoleToRodStop")
                    End If
                    '27_02_2010
                    If Not IsDBNull(oSelectedCastingDataRow("DistanceFromTubeEdgeToRodStop")) Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = oSelectedCastingDataRow("DistanceFromTubeEdgeToRodStop")
                    End If

                    DisplayToleranceValues(oSelectedCastingDataRow)

                    txtGreaseZerk.Text = ObjClsWeldedCylinderFunctionalClass.GetGreekZercQty(txtAngle1.Text, txtAngle2.Text)

                    '26_02_2010 Aruna Start
                    If oSelectedCastingDataRow("PartType").ToString.Contains("IFL_PART") Then
                        '16_04_2012    RAGAVA
                        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "NewDesign"
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_NO_PO_GR_CROSSTUBE"
                        'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign2 = "NewDesign"
                        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_NO_PO_GR_CROSSTUBE"
                        'End If
                        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "NewDesign" 
                        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_NO_PO_GR_CROSSTUBE"
                        'Till  Here


                        '27_04_2010    RAGAVA
                        If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                            If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then       '19_05_2010   RAGAVA     NEW DESIGN
                                ''16_04_2012    RAGAVA
                                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_CROSSTUBE"
                                'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                                '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_FI_CROSSTUBE"
                                'End If
                                ''ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_CROSSTUBE"
                                'Till  Here
                            Else
                                ''16_04_2012    RAGAVA
                                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_CROSSTUBE_90"
                                'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                                '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "BEC_RA_PI_FI_CROSSTUBE_90"
                                'End If
                                ''ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_CROSSTUBE_90"
                                'Till  Here
                            End If
                            'Till  Here
                        End If
                        'Till  Here
                    Else
                        '16_04_2012    RAGAVA
                        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "Existing"
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "CT_No_Port"
                        'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign2 = "Existing"
                        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "CT_No_Port"
                        'End If
                        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "Existing"
                        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "CT_No_Port"
                        'Till   Here
                    End If
                    '1_03_2010 Aruna
                    ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Cast"
                    '26_02_2010 Aruna End
                End If

                If rdbUseSelectedCrossTubeYes.Checked = True Then
                    UpdateValues()
                End If
            Else
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("CrossTube without Port Code", txtCodeNumber.Text)
                txtCodeNumber.Text = ""
                txtCrossTubeOD.Text = ""
                txtCrossTubeWidth.Text = ""
                txtPinHoleSize.Text = ""
                txtGreaseZerk.Text = ""
                txtAngle1.Text = ""
                txtAngle2.Text = ""
                txtOffset.Text = ""
                txtPinHoleTole_Neg.Text = ""
                txtPinHoleTole_Pos.Text = ""
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in lvwCrossTubeListView_SelectedIndexChanged of frmCTCastingYes " + ex.Message)
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


    'Private Sub chkUseSelectedCrossTubeCasting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If chkUseSelectedCrossTubeCasting.Checked Then
    '        grbUsingSelectedSingleLug.Visible = True
    '        ObjClsWeldedCylinderFunctionalClass.ShowCastingNo_Thru_CastingYes = False
    '        btnClickNextButton.Visible = False
    '    Else
    '        grbUsingSelectedSingleLug.Visible = False
    '        ObjClsWeldedCylinderFunctionalClass.ShowCastingNo_Thru_CastingYes = True
    '        btnClickNextButton.Visible = True
    '        btnClickNextButton.Location = New Point(350, 430)
    '    End If
    'End Sub

    'Private Sub chkExactMatch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If chkExactMatch.Checked Then
    '        grbNotExactMatch.Visible = False
    '    Else
    '        grbNotExactMatch.Visible = True
    '    End If
    'End Sub


    Private Sub rdbResize_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbResize.CheckedChanged
        '26_02_2010 Aruna Start
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = ""    '03_03_2010    ARUNA
        If rdbResize.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = True        '20_10_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize"
            UpdatePreviousFormDetails()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        End If
        '26_02_2010 Aruna Ends
    End Sub

    Private Sub rdbNewCasting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbNewCasting.CheckedChanged
        '26_02_2010 Aruna Start
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = ""    '03_03_2010    ARUNA
        If rdbNewCasting.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False        '20_10_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "NewDesign"
            UpdatePreviousFormDetails()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        End If
        '26_02_2010 Aruna Ends
    End Sub

    Private Sub rdbExactMatchYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbExactMatchYes.CheckedChanged
        '26_02_2010 Aruna Start
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = ""    '03_03_2010    ARUNA
        If rdbExactMatchYes.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewCastingGenerated = False             '17_10_2012   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTable = ""       '17_07_2012   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart = ""        '17_07_2012   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndCasting_New = False     '17_07_2012   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = True        '20_10_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Exact"
            ' grbNotExactMatch.Visible = False
            UpdatePreviousFormDetails()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        End If
        '26_02_2010 Aruna Ends
    End Sub

    '26_02_2010 Aruna Start
    Private Sub UpdatePreviousFormDetails()
        Dim strMessage As String = "Base end Configuration will be updated with the selected Cross Tube casting details, " + vbCrLf
        If MessageBox.Show(strMessage, "Update TubeDetails", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
            UpdateValues()
        End If
    End Sub
    '26_02_2010 Aruna Ends

    Private Sub UpdateValues()
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

        If txtGreaseZerk.Text <> "" AndAlso txtGreaseZerk.Text <> "N/A" Then
            ObjClsWeldedCylinderFunctionalClass.CmbGreaseZercs_BaseEnd.Text = txtGreaseZerk.Text
        End If

        If txtAngle1.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.TxtAngleOfGreaseZercs1_BaseEnd.Text = txtAngle1.Text
        End If

        If txtAngle2.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.TxtAngleOfGreaseZercs2_BaseEnd.Text = txtAngle2.Text
        End If
        If txtCrossTubeWidth.Text <> "" Then
            '16_04_2012  RAGAVA
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth = Val(txtCrossTubeWidth.Text)
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth2 = Val(txtCrossTubeWidth.Text)
            'End If
            'Till  Here
            'ObjClsWeldedCylinderFunctionalClass.TxtCrossTubeWidth_BaseEnd.Text = txtCrossTubeWidth.Text
        End If
        If txtOffset.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.TxtCrossTubeOffset_BaseEnd.Text = txtOffset.Text
        End If
        ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance

        'anup 30-08-2010
        If Not String.IsNullOrEmpty(txtPinHoleTole_Pos.Text) Then
            ObjClsWeldedCylinderFunctionalClass.TxtToleranceUpperLimit.Text = txtPinHoleTole_Pos.Text
        End If
        If Not String.IsNullOrEmpty(txtPinHoleTole_Neg.Text) Then
            ObjClsWeldedCylinderFunctionalClass.TxtToleranceLowerLimit.Text = txtPinHoleTole_Neg.Text
        End If
    End Sub

    Private Sub rdbUseSelectedCrossTubeYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedCrossTubeYes.CheckedChanged
        If rdbUseSelectedCrossTubeYes.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast"          '16_04_2012   RAGAVA
            '16_04_2012  RAGAVA
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD = Val(txtCrossTubeOD.Text)
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth = Val(txtCrossTubeWidth.Text)
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD2 = Val(txtCrossTubeOD.Text)
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth2 = Val(txtCrossTubeWidth.Text)
            'End If


            '14-04-2012 MANJULA ADDED
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then

                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.plnPortInTube_Casting.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.rdbDesignACasting.Checked = True
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.rdbFabricated.Checked = False

                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral2.plnPortInTube_Casting.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral2.rdbDesignACasting.Checked = False
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral2.rdbFabricated.Checked = False

            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then

                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.plnFabrication_Casting.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.rdbDesignACasting.Checked = True
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.rdbFabrication.Checked = False

                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube2.plnFabrication_Casting.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube2.rdbDesignACasting.Checked = False
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube2.rdbFabrication.Checked = False

            End If
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast"

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTPortIntegral.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTPortIntegral2.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral2.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth

            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTPortInTube.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTPortInTube2.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube2.dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth

            End If
            '********************************

            'Till  Here
            If txtPinHoleSize.Text <> "" AndAlso txtRequiredPinHoleSize.Text <> "" Then
                If ObjClsWeldedCylinderFunctionalClass.PinHoleSizeDiffere(Val(txtPinHoleSize.Text), Val(txtRequiredPinHoleSize.Text)) Then
                    '  grbUsingSelectedCrossTube.Visible = False 'anup 23-12-2010 
                    rdbExactMatchYes.Checked = True
                Else
                    grbUsingSelectedCrossTube.Visible = True
                End If
            Else
                grbUsingSelectedCrossTube.Visible = True
            End If
            grbNotUsingSelectedCrossTubeCasting.Visible = False
            ObjClsWeldedCylinderFunctionalClass.ShowCastingNo_Thru_CastingYes = False
            lvwCrossTubeListView.Tag = "Validation Required"
        End If
    End Sub

    Private Sub rdbUseSelectedCrossTubeNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedCrossTubeNo.CheckedChanged
        If rdbUseSelectedCrossTubeNo.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = ""          '11_04_2012   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False        '20_10_2010    RAGAVA
            grbUsingSelectedCrossTube.Visible = False
            grbNotUsingSelectedCrossTubeCasting.Visible = True
            ObjClsWeldedCylinderFunctionalClass.ShowCastingNo_Thru_CastingYes = True
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
            '15-05-2012 MANJULA ADDED
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then

                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.plnPortInTube_Casting.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.rdbDesignACasting.Checked = False
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.rdbFabricated.Checked = False
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.rdbDesignACasting.Enabled = True
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral.rdbFabricated.Enabled = True


                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral2.plnPortInTube_Casting.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral2.rdbDesignACasting.Checked = False
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortIntegral2.rdbFabricated.Checked = False

            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then

                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.plnFabrication_Casting.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.rdbDesignACasting.Checked = False
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.rdbFabrication.Checked = False
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.rdbDesignACasting.Enabled = True
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube.rdbFabrication.Enabled = True


                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube2.plnFabrication_Casting.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube2.rdbDesignACasting.Checked = False
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube2.rdbFabrication.Checked = False

            End If
            '*****************************
            lvwCrossTubeListView.Tag = "Validation Not Required"
        End If
    End Sub
#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblCrossTubeCasting)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblUsingSelectedCrossTube)
        'A0308: ANUP 03-08-2010 02.28pm
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient1)
    End Sub



    Private Sub txtCrossTubeOD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCrossTubeOD.TextChanged
        Try
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD = Val(txtCrossTubeOD.Text)         '05_08_2011    RAGAVA
        Catch ex As Exception

        End Try
    End Sub
End Class