Public Class frmThreadedEndCastingYes_PortIntegral

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

    Public Enum ThreadedEndListViewDetails
        CodeNumber = 0
        Description = 1
        Cost = 2
    End Enum

#End Region

#Region "SubProcedures"

    Private Sub PopulateInListView()
        lvwThreadedEndListView.Clear()
        lvwThreadedEndListView.Columns.Add("Code No", 100, HorizontalAlignment.Center)
        lvwThreadedEndListView.Columns.Add("Description", 220, HorizontalAlignment.Center)
        lvwThreadedEndListView.Columns.Add("Cost", 100, HorizontalAlignment.Center)
        lvwThreadedEndListView.Columns.Add("Sales", 100, HorizontalAlignment.Center)        '28_11_2012   RAGAVA
        '<<--20-12-2010 Aruna--
        lvwThreadedEndListView.Columns.Add("Is Existed", 45, HorizontalAlignment.Center)
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
                    oListItem = lvwThreadedEndListView.Items.Add(strPartCode_Purchase)
                    'ANUP 07-10-2010 TILL HERE
                End If

                If Not IsDBNull(_oMatchedCastingDataRow("PartDescription")) Then
                    lvwThreadedEndListView.Items(intCount).SubItems.Add(_oMatchedCastingDataRow("PartDescription"))
                End If
                '28_11_2012  RAGAVA
                Try
                    ObjClsWeldedCylinderFunctionalClass.GetCost_Sales(_oMatchedCastingDataRow("PartCode"), lvwThreadedEndListView, intCount)
                Catch ex As Exception

                End Try
                'If Not IsDBNull(_oMatchedCastingDataRow("Cost")) Then
                '    lvwThreadedEndListView.Items(intCount).SubItems.Add(_oMatchedCastingDataRow("Cost"))
                'End If
                'Till   Here

                '<<--20-12-2010 Aruna--
                If Not IsDBNull(_oMatchedCastingDataRow("IsExisted")) Then
                    If _oMatchedCastingDataRow("IsExisted") = True Then
                        lvwThreadedEndListView.Items(intCount).SubItems.Add("Yes")
                    Else
                        lvwThreadedEndListView.Items(intCount).SubItems.Add("No")
                    End If
                Else
                    lvwThreadedEndListView.Items(intCount).SubItems.Add("No")
                End If
                '--20-12-2010 Aruna-->>

                intCount += 1
            Next
        End If
        lvwThreadedEndListView.Items(0).Selected = True
        lvwThreadedEndListView.HideSelection = False
        lvwThreadedEndListView.FullRowSelect = True
    End Sub

    Public Sub ManualLoad()
        LoadFunctionality()
    End Sub

    Private Sub LoadFunctionality()
        InitialSettings()
        _oMatchedCastingDataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BEMatchedThreadedEndcastingDataTable
        PopulateInListView()
    End Sub

    Private Sub InitialSettings()

        txtSwingClearance.Enabled = False
        txtRequiredSwingClearance.Enabled = False
        txtRequiredSwingClearance.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance

        txtCost.Enabled = False
        txtRequiredCost.Enabled = False

        txtPortType.Enabled = False
        txtRequiredPortType.Enabled = False
        txtRequiredPortType.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd

        txtPortSize.Enabled = False
        txtRequiredPortSize.Enabled = False
        txtRequiredPortSize.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd

        txtNoOfPorts.Enabled = False
        txtRequiredNoOfPorts.Enabled = False
        txtRequiredNoOfPorts.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd

        txtThreadDiameter.Enabled = False
        txtRequiredThreadDiameter.Enabled = False
        txtRequiredThreadDiameter.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadDiameter

        txtSecondPortOrientation.Enabled = False
        txtRequiredSecondPortOrientation.Enabled = False
        txtRequiredSecondPortOrientation.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSecondOrientation

    End Sub

#End Region

#Region "Events"

    Private Sub frmThreadedEndCastingYes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        LoadFunctionality()
    End Sub

    Private Sub lvwThreadedEndListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwThreadedEndListView.SelectedIndexChanged
        'ANUP 10-11-2010 START
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        rdbUseSelectedThreadedEndYes.Checked = False
        rdbUseSelectedThreadedEndNo.Checked = False
        'ANUP 10-11-2010 TILL HERE
        If lvwThreadedEndListView.SelectedIndices.Count > 0 Then
            Dim oListViewSelectedItem As ListViewItem = lvwThreadedEndListView.SelectedItems(0)
            Dim oSelectedCastingDataRow As DataRow = Nothing



            'ANUP 07-10-2010 START
            Dim strPartCodePassing_Purchased As String = oListViewSelectedItem.SubItems(ThreadedEndListViewDetails.CodeNumber).Text
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

            '27_04_2010   RAGAVA   NEW DESIGN
            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                '19_05_2010   RAGAVA     NEW DESIGN
                If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                    oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                                             GetBEThrededEndRaisedPortSelectedRowDetails(strPartCodePassing_Purchased)
                Else
                    oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                                                                GetBEThrededEndRaisedPortSelectedRowDetails90(strPartCodePassing_Purchased)
                End If
                'Till   Here
            Else
                oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                            GetBEThrededEndFlushPortSelectedRowDetails(strPartCodePassing_Purchased)
            End If
            'oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
            '            GetBEThrededEndFlushPortSelectedRowDetails(oListViewSelectedItem.SubItems(ThreadedEndListViewDetails.CodeNumber).Text)
            'Till   Here

            If Not IsNothing(oSelectedCastingDataRow) Then
                If Not IsDBNull(oSelectedCastingDataRow("PartCode")) Then
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ThreadedEnd without Port Code", oListViewSelectedItem.SubItems(ThreadedEndListViewDetails.CodeNumber).Text)
                    'ANUP 07-10-2010 TILL HERE

                    'Aruna :11-3-2010---------------
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = oSelectedCastingDataRow("PartCode")
                    '---------------------------------

                End If

                If Not IsDBNull(oSelectedCastingDataRow("SwingClearanceRadius")) Then
                    txtSwingClearance.Text = oSelectedCastingDataRow("SwingClearanceRadius")
                End If
                If Not IsDBNull(oSelectedCastingDataRow("PortType")) Then
                    txtPortType.Text = oSelectedCastingDataRow("PortType")
                End If
                If Not IsDBNull(oSelectedCastingDataRow("PortSize")) Then
                    txtPortSize.Text = oSelectedCastingDataRow("PortSize")
                End If
                If Not IsDBNull(oSelectedCastingDataRow("PortQuantity")) Then
                    txtNoOfPorts.Text = oSelectedCastingDataRow("PortQuantity")
                End If
                If Not IsDBNull(oSelectedCastingDataRow("SecondPortOrientation")) Then
                    txtSecondPortOrientation.Text = oSelectedCastingDataRow("SecondPortOrientation")
                End If
                If Not IsDBNull(oSelectedCastingDataRow("ThreadSize")) Then
                    txtThreadDiameter.Text = oSelectedCastingDataRow("ThreadSize")
                End If
                '09_04_2010 Aruna
                If Not IsDBNull(oSelectedCastingDataRow("ThreadLength")) Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength = oSelectedCastingDataRow("ThreadLength")
                End If


                'Aruna :11-3-2010---------------
                If Not IsDBNull(oSelectedCastingDataRow("EndofTubetoRodStop")) Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = oSelectedCastingDataRow("EndofTubetoRodStop")
                End If
                If Not IsDBNull(oSelectedCastingDataRow("BaseofThreadtoRodStop")) Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedCastingDataRow("BaseofThreadtoRodStop")
                End If
                If oSelectedCastingDataRow("PartType").ToString.Contains("IFL_PART") Then
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "IFL_Designed_Existing"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "NewDesign"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = ""
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "Existing"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BE_Threaded_Rod"
                End If
                '---------------------------------
                '9_04_2010 Aruna
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Cast"
            End If
        Else
            txtSwingClearance.Text = ""
            txtPortType.Text = ""
            txtPortSize.Text = ""
            txtNoOfPorts.Text = ""
            txtSecondPortOrientation.Text = ""
        End If
    End Sub

    'ANUP 11-03-2010 11.00
    Private Sub rdbUseSelectedThreadedEndNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedThreadedEndNo.CheckedChanged
        If rdbUseSelectedThreadedEndNo.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False        '20_10_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ShowCastingNo_Thru_CastingYes = True
        End If
    End Sub

    Private Sub rdbUseSelectedThreadedEndYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedThreadedEndYes.CheckedChanged
        If rdbUseSelectedThreadedEndYes.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = True        '20_10_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ShowCastingNo_Thru_CastingYes = False
            '09_04_2010 Aruna
            UpdatePreviousFormDetails()
        End If
    End Sub
    'Aruna 9_04_2010
    Private Sub UpdatePreviousFormDetails()

        Dim strMessage As String = "Base end Configuration will be updated with the selected ThreadedEnd casting details, " + vbCrLf
        If MessageBox.Show(strMessage, "Update TubeDetails", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
            If txtSwingClearance.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text = txtSwingClearance.Text
            End If
            If txtThreadDiameter.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtThreadDiameter_BaseEnd.Text = txtThreadDiameter.Text
            End If
            ObjClsWeldedCylinderFunctionalClass.TxtThreadLength_BaseEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength.ToString
        End If
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lbThreadedEndCasting)
    End Sub

End Class