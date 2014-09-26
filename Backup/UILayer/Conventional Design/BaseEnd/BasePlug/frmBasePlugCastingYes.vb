Public Class frmBasePlugCastingYes

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

    Private _strSelectedCastingDetailsIFlID As String

#End Region

#Region "Enum"

    Public Enum BasePlugListViewDetails
        CodeNumber = 0
        Description = 1
        Cost = 2
    End Enum

#End Region

#Region "SubProcedures"

    Private Sub UpdatePreviousFormDetails()
        Dim strMessage As String = "Base end Configuration Details will be updated with the selected BasePlug details, " + vbCrLf
        If MessageBox.Show(strMessage, "Update TubeDetails", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
            If txtSwingClearance.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text = txtSwingClearance.Text
            End If

            If txtBasePlugDia.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtBasePlugDia_BaseEnd.Text = txtBasePlugDia.Text
            End If
        End If
    End Sub

    Private Sub PopulateInListView()
        lvwBasePlugView.Clear()
        lvwBasePlugView.Columns.Add("Code No", 100, HorizontalAlignment.Center)
        lvwBasePlugView.Columns.Add("Description", 220, HorizontalAlignment.Center)

        'TODO:Anup 09-04-10 2pm
        lvwBasePlugView.Columns.Add("SafetyFactor", 100, HorizontalAlignment.Center)
        '***********

        lvwBasePlugView.Columns.Add("Cost", 100, HorizontalAlignment.Center)

        lvwBasePlugView.Columns.Add("Sales", 100, HorizontalAlignment.Center)        '26_11_2012   RAGAVA

        '<<--20-12-2010 Aruna--
        lvwBasePlugView.Columns.Add("Is Existed", 45, HorizontalAlignment.Center)
        '--20-12-2010 Aruna-->>
        Dim intCount As Integer = 0
        Dim oListItem As ListViewItem

        If Not IsNothing(_oMatchedCastingDataTable) AndAlso _oMatchedCastingDataTable.Rows.Count > 0 Then
            'ANUP 07-10-2010 START
            If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Count > 0 Then
                ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Clear()
            End If
            'ANUP 07-10-2010 TILL HERE
            For Each _oMatchedCastingDataRow As DataRow In _oMatchedCastingDataTable.Rows
                If Not IsDBNull(_oMatchedCastingDataRow("PartCode")) Then

                    'ANUP 07-10-2010 START
                    Dim strPartCode_Purchase As String = ObjClsWeldedCylinderFunctionalClass.PartCOde_Purchased_ListViewClickedValidation(_oMatchedCastingDataRow("PartCode"))
                    oListItem = lvwBasePlugView.Items.Add(strPartCode_Purchase)
                    'ANUP 07-10-2010 TILL HERE

                End If

                If Not IsDBNull(_oMatchedCastingDataRow("Description")) Then
                    lvwBasePlugView.Items(intCount).SubItems.Add(_oMatchedCastingDataRow("Description"))
                End If

                'TODO:Anup 09-04-10 2pm
                If Not IsDBNull(_oMatchedCastingDataRow("CalculatedSafetyFactor")) Then
                    lvwBasePlugView.Items(intCount).SubItems.Add(_oMatchedCastingDataRow("CalculatedSafetyFactor"))
                Else
                    lvwBasePlugView.Items(intCount).SubItems.Add("")
                End If
                '***************
                '26_11_2012  RAGAVA
                Try
                    ObjClsWeldedCylinderFunctionalClass.GetCost_Sales(_oMatchedCastingDataRow("PartCode"), lvwBasePlugView, intCount)
                Catch ex As Exception

                End Try
                'If Not IsDBNull(_oMatchedCastingDataRow("Cost")) Then
                '    lvwBasePlugView.Items(intCount).SubItems.Add(_oMatchedCastingDataRow("Cost"))
                'End If
                'Till  Here


                '04_12_2009   RAGAVA  Commented Below
                'If Not IsDBNull(_oMatchedCastingDataRow("IFLID")) Then
                '    lvwBasePlugView.Items(intCount).SubItems.Add(_oMatchedCastingDataRow("IFLID"))
                'End If
                '<<--20-12-2010 Aruna--
                If Not IsDBNull(_oMatchedCastingDataRow("IsExisted")) Then
                    If _oMatchedCastingDataRow("IsExisted") = True Then
                        lvwBasePlugView.Items(intCount).SubItems.Add("Yes")
                    Else
                        lvwBasePlugView.Items(intCount).SubItems.Add("No")
                    End If
                Else
                    lvwBasePlugView.Items(intCount).SubItems.Add("No")
                End If
                '--20-12-2010 Aruna-->>
                intCount += 1
            Next
        End If
        lvwBasePlugView.Items(0).Selected = True
        lvwBasePlugView.HideSelection = False
        lvwBasePlugView.FullRowSelect = True
    End Sub

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
        '_oMatchedCastingDataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBEDLCastingDataTable
        _oMatchedCastingDataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBEBPCastingDataTable
        PopulateInListView()
    End Sub

    Private Sub InitialSettings()
        txtBasePlugDia.Enabled = False
        txtSwingClearance.Enabled = False
        txtRequiredSwingClearance.Enabled = False
        txtRequiredBasePlugDia.Enabled = False
        txtCost.Enabled = False
        txtRequiredCost.Enabled = False
        txtRequiredSwingClearance.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
        txtRequiredBasePlugDia.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter

        'TODO: COMMENTED BY ANUP 02-03-2010 11.31
        'chkUseSelectedBasePlug.Checked = True                 '01_12_2009   RAGAVA
        'chkExactMatch.Checked = False                 '02_12_2009   RAGAVA

        rdbUseSelectedBasePlugYes.Checked = True
        ' rdbExactMatchNo.Checked = True
        '*********************

    End Sub

#End Region

#Region "Events"

    Private Sub frmBasePlugCastingYes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        LoadFunctionality()
    End Sub

    Private Sub lvwBasePlugView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwBasePlugView.SelectedIndexChanged
        'ANUP 10-11-2010 START
        rdbUseSelectedBasePlugYes.Checked = False
        rdbUseSelectedBasePlugNo.Checked = False
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True 'anup 03-02-2011
        'ANUP 10-11-2010 TILL HERE
        If lvwBasePlugView.SelectedIndices.Count > 0 Then
            Dim oListViewSelectedItem As ListViewItem = lvwBasePlugView.SelectedItems(0)
            Dim oSelectedCastingDataRow As DataRow = Nothing

            'ANUP 07-10-2010 START
            Dim strPartCodePassing_Purchased As String = oListViewSelectedItem.SubItems(BasePlugListViewDetails.CodeNumber).Text
            ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode = strPartCodePassing_Purchased         '12_10_2010   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = strPartCodePassing_Purchased    '08_11_2011   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingCodeNumber = strPartCodePassing_Purchased      '07_02_2011    RAGAVA
            If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.ContainsKey(strPartCodePassing_Purchased) Then
                strPartCodePassing_Purchased = ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Item(strPartCodePassing_Purchased)
            End If

            '25_10_2010   RAGAVA
            ''If ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode.StartsWith("7") Then
            ''    ObjClsWeldedCylinderFunctionalClass.DisplayImage("X:\WeldedModels\" & ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode & ".SLDPRT")
            ''End If
            'Till   Here

            '27_04_2010   RAGAVA  NEW DESIGN
            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then       '19_05_2010   RAGAVA     NEW DESIGN
                    oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                                                           GetBEBasePlugCastWithRaisedPortSelectedRowDetails(strPartCodePassing_Purchased)
                    '19_05_2010   RAGAVA     NEW DESIGN
                Else
                    oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                                                                              GetBEBasePlugCastWithRaisedPortSelectedRowDetails90(strPartCodePassing_Purchased)
                End If
            Else
                oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                       GetBEBasePlugCastWithOutPortSelectedRowDetails(strPartCodePassing_Purchased)
            End If
            'oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
            '            GetBEBasePlugCastWithOutPortSelectedRowDetails(oListViewSelectedItem.SubItems(BasePlugListViewDetails.CodeNumber).Text)
            'Till   Here

            '15_11_2011   RAGAVA
            Try
                If oSelectedCastingDataRow("PortSecondOrientation").ToString <> "N/A" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBasePlugTwoPorts = IIf(Val(oSelectedCastingDataRow("PortFirstOrientation")) = Val((oSelectedCastingDataRow("PortSecondOrientation"))), True, False)
                End If
            Catch ex As Exception
            End Try
            'Till   Here

            If Not IsNothing(oSelectedCastingDataRow) Then
                If Not IsDBNull(oSelectedCastingDataRow("PartCode")) Then
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Base Plug without Port Code", oListViewSelectedItem.SubItems(BasePlugListViewDetails.CodeNumber).Text)
                End If
                'ANUP 07-10-2010 TILL HERE


                If Not IsDBNull(oSelectedCastingDataRow("SwingClearanceRadius")) Then
                    txtSwingClearance.Text = oSelectedCastingDataRow("SwingClearanceRadius")
                End If


                If Not IsDBNull(oSelectedCastingDataRow("OutSidePlugDiameter")) Then
                    txtBasePlugDia.Text = oSelectedCastingDataRow("OutSidePlugDiameter")
                End If

                'TODO: COMMENTED BY ANUP 02-03-2010 12.11
                '02_12_2009   RAGAVA
                'If Not IsDBNull(oSelectedCastingDataRow("MilledFlatWidth")) Then
                '    txtMilledFlatWidth.Text = oSelectedCastingDataRow("MilledFlatWidth")
                'End If
                'If Not IsDBNull(oSelectedCastingDataRow("MilledFlatHeight")) Then
                '    txtMilledFlatLength.Text = oSelectedCastingDataRow("MilledFlatHeight")
                'End If
                '********************

                If Not IsDBNull(oSelectedCastingDataRow("PinholeToRodStop")) Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedCastingDataRow("PinholeToRodStop")
                End If
                '02_12_2009   RAGAVA   Till  Here
                '18_03_2010    RAGAVA
                If oSelectedCastingDataRow("PartType").ToString.Contains("IFL_PART") Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "NewDesign"
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "Existing"
                End If
                'Till   Here
            End If
            '18_03_2010    RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "Base_Plug_No_Port"
            ElseIf ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
                '19_05_2010   RAGAVA  NEW   DESIGN
                If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_BASEPLUG"
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_BASEPLUG_90"
                    End If
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "Bp_Flushed_Port"
                End If
            End If
            'Till    Here
        Else
            txtSwingClearance.Text = ""
            txtBasePlugDia.Text = ""
        End If
    End Sub

    'TODO: ANUP 02-03-2010 11.31
    Private Sub rdbUseSelectedBasePlugYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedBasePlugYes.CheckedChanged
        If rdbUseSelectedBasePlugYes.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = True        '20_10_2010    RAGAVA
            btnClickNextButton.Visible = False
            lvwBasePlugView.Tag = "Validation Required"
            ObjClsWeldedCylinderFunctionalClass.ShowCastingNo_Thru_CastingYes = False
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Exact"
            'ANUP 04-10-2010 START
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Cast"
            'ANUP 04-10-2010 TILL HERE
        End If
    End Sub

    Private Sub rdbUseSelectedBasePlugNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedBasePlugNo.CheckedChanged
        If rdbUseSelectedBasePlugNo.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False        '20_10_2010    RAGAVA
            btnClickNextButton.Visible = True
            lvwBasePlugView.Tag = "Validation not Required"
            ObjClsWeldedCylinderFunctionalClass.ShowCastingNo_Thru_CastingYes = True
            btnClickNextButton.Location = New Point(378, 392)
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = ""
            'ANUP 04-10-2010 START
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = ""
            'ANUP 04-10-2010 TILL HERE
        End If
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lbThreadedEndCasting)
    End Sub


End Class