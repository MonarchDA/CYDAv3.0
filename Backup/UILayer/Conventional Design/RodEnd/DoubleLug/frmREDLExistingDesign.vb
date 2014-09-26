Public Class frmREDLExistingDesign

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

#Region "Variables"

    Private _oExistingULugLatheData As DataTable

    Private _oExistingDLCastingData As DataTable

    Private _strPartCode As String

    Private _blnULuglathe_DataFound As Boolean
    Private _blnDoubleLug_DataFound As Boolean

    'TODO: ANUP 04-06-2010 01.52pm
    Private _dblWeldSize_ULugLathe As Double
    Private _strWeldPreperation_ULugLathe As String
    Private _dblJGrooveWidth_RodEnd_ULugLathe As Double
    Private _dblJGrooveRadius_RodEnd_ULugLathe As Double
    Private _dblWeldSize_Casting As Double
    Private _dblJGrooveWidth_RodEnd_Casting As Double
    Private _dblJGrooveRadius_RodEnd_Casting As Double
    '********************

#End Region

#Region "Enum"

    Public Enum ExistingDataColumns
        CodeNumber = 0
        Description = 1
        SafetyFactor = 2
        Cost = 3
    End Enum

#End Region

#Region "Sub Proceduers"

    'Sunny 03-06-10
    Public Function ExistingDataFound() As Boolean
        Try
            ' TODO: Sunny 04-06-10 If RodDiameter > 1.5 then skip ULugLathe
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter <= 1.5 AndAlso Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass) <= 2 Then
                _blnULuglathe_DataFound = SearchForExistingULugLathe()
            Else
                _blnULuglathe_DataFound = False
            End If
            '*************************************************************
            _blnDoubleLug_DataFound = SearchForExistingDoubleLugCastingDetails()
            ExistingDataFound = (_blnULuglathe_DataFound OrElse _blnDoubleLug_DataFound)
        Catch ex As Exception
            ExistingDataFound = False
        End Try
    End Function

    'Sunny 03-06-10
    Public Sub ManualLoad()
        EnDisOptions()
        LoadFunctionality()
        CheckChanged()
    End Sub

    'Sunny 03-06-10
    Private Sub LoadFunctionality()
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        DisplayDataInRequiredFields()
    End Sub

    'Sunny 03-06-10
    Private Sub InitialSettings()
        txtCodeNumber_Existing.Enabled = False
        txtLugThickness_Existing.Enabled = False
        txtLugThicknessRequired_Existing.Enabled = False
        txtLugWidth_Existing.Enabled = False
        txtLugWidthRequired_Existing.Enabled = False
        txtLugGap_Existing.Enabled = False
        txtLugGap_Required.Enabled = False
        txtPinHoleSize_Existing.Enabled = False
        txtPinHoleSizeRequired_Existing.Enabled = False
        txtSwingClearance_Existing.Enabled = False
        txtSwingClearanceRequired_Existing.Enabled = False
        txtLugHeight_Existing.Enabled = False
        txtLugHeight_Required.Enabled = False
        txtWeldSize_Existing.Enabled = False
        txtWeldSize_Required.Enabled = False
        txtPinHoleTole_Pos.Enabled = False
        txtPinHoleTole_Pos_Req.Enabled = False
        txtPinHoleTole_Neg.Enabled = False
        txtPinHoleTole_Neg_Req.Enabled = False
        txtPinHoleTole_Pos.Enabled = False
        txtPinHoleTole_Pos_Req.Enabled = False
        txtPinHoleTole_Neg.Enabled = False
        txtPinHoleTole_Neg_Req.Enabled = False

        rdbULugLathe_Existing.Checked = False
        rdbDoubleLugExisitng.Checked = False

        EnDisOptions()

        pnlMessage.Visible = False
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
    End Sub

    Private Sub EnDisOptions()
        rdbULugLathe_Existing.Enabled = _blnULuglathe_DataFound
        rdbDoubleLugExisitng.Enabled = _blnDoubleLug_DataFound
    End Sub

    Private Sub AddColumnsToListview()
        Try
            lvwExistingData.Columns.Add("Code No", 100, HorizontalAlignment.Center)
            lvwExistingData.Columns.Add("Description", 220, HorizontalAlignment.Center)
            lvwExistingData.Columns.Add("SafetyFactor", 100, HorizontalAlignment.Center)
            lvwExistingData.Columns.Add("Cost", 100, HorizontalAlignment.Center)
            lvwExistingData.Columns.Add("Sales", 100, HorizontalAlignment.Center)        '28_11_2012   RAGAVA

            '<<--20-12-2010 Aruna--
            lvwExistingData.Columns.Add("Is Existed", 45, HorizontalAlignment.Center)
            '--20-12-2010 Aruna-->>
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DisplayDataInListview(ByVal oTable As DataTable)
        Try
            lvwExistingData.Items.Clear()
            Dim oListViewItem As ListViewItem
            'ANUP 07-10-2010 START
            If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Count > 0 Then
                ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Clear()
            End If
            'ANUP 07-10-2010 TILL HERE 

            For Each oRow As DataRow In oTable.Rows
                Dim strPartCode_Purchase As String = String.Empty
                oListViewItem = New ListViewItem()

                If Not IsDBNull(oRow("PartCode")) Then

                    'ANUP 07-10-2010 START
                    strPartCode_Purchase = ObjClsWeldedCylinderFunctionalClass.PartCOde_Purchased_ListViewClickedValidation(oRow("PartCode"))
                    oListViewItem.Text = strPartCode_Purchase
                    'ANUP 07-10-2010 TILL HERE
                    'oListViewItem.Text = ""          '04_11_2010   RAGAVA
                End If

                If Not IsDBNull(oRow("Description")) Then
                    oListViewItem.SubItems.Add(oRow("Description"))
                Else
                    oListViewItem.SubItems.Add("")
                End If



                '31_05_2011  RAGAVA
                Try
                    Dim dblSafetyFactor As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SetSafetyFactorForExisting_RodEnd(strPartCode_Purchase)
                    If dblSafetyFactor > 0 Then
                        oListViewItem.SubItems.Add(dblSafetyFactor.ToString)
                    Else
                        If Not IsDBNull(oRow("CalculatedSafetyFactor")) Then
                            oListViewItem.SubItems.Add(oRow("CalculatedSafetyFactor"))
                        Else
                            oListViewItem.SubItems.Add("")
                        End If
                    End If
                Catch ex As Exception
                End Try
                'If Not IsDBNull(oRow("CalculatedSafetyFactor")) Then
                '    oListViewItem.SubItems.Add(oRow("CalculatedSafetyFactor"))
                'Else
                '    oListViewItem.SubItems.Add("")
                'End If
                'TILL   HERE


                '28_11_2012  RAGAVA
                Try
                    Dim _strQuery As String = ""
                    _strQuery = "SELECT * FROM CostingDetails WHERE PartCode = '" + oRow("PartCode") + "'"
                    Dim dr As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsMIL_TieRodDataClass.MILConnectionObject.GetDataRow(_strQuery)
                    If Not dr Is Nothing Then
                        If Not IsDBNull(dr("Cost")) Then
                            oListViewItem.SubItems.Add(dr("Cost"))
                        Else
                            oListViewItem.SubItems.Add("NULL")
                        End If
                        If Not IsDBNull(dr("Sales")) Then
                            oListViewItem.SubItems.Add(dr("Sales"))
                        Else
                            oListViewItem.SubItems.Add("NULL")
                        End If
                    Else
                        oListViewItem.SubItems.Add("NULL")
                        oListViewItem.SubItems.Add("NULL")
                    End If
                Catch ex As Exception

                End Try
               
                'Till   Here

                '<<--20-12-2010 Aruna--
                If Not IsDBNull(oRow("IsExisted")) Then
                    If oRow("IsExisted") = True Then
                        oListViewItem.SubItems.Add("Yes")
                    Else
                        oListViewItem.SubItems.Add("No")
                    End If
                Else
                    oListViewItem.SubItems.Add("No")
                End If
                '--20-12-2010 Aruna-->>
                lvwExistingData.Items.Add(oListViewItem)
            Next
            lvwExistingData.Items(0).Selected = True
            lvwExistingData.HideSelection = False
            lvwExistingData.FullRowSelect = True
        Catch ex As Exception

        End Try
    End Sub

    'Sunny 03-06-10
    Private Sub DisplayDataInRequiredFields()
        txtLugThicknessRequired_Existing.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
        txtLugWidthRequired_Existing.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd
        txtLugGap_Required.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd
        txtPinHoleSizeRequired_Existing.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
        txtSwingClearanceRequired_Existing.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
        txtLugHeight_Required.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.lugHeight_RodEnd
        txtWeldSize_Required.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd
        txtPinHoleTole_Neg_Req.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd
        txtPinHoleTole_Pos_Req.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd
    End Sub

    'Sunny 03-06-10
    Private Sub FindSetData(ByVal strPartCode As String)
        Try
            'ANUP 07-10-2010 START
            Dim strPartCodePassing_Purchased As String = strPartCode
            If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.ContainsKey(strPartCodePassing_Purchased) Then
                strPartCodePassing_Purchased = ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Item(strPartCodePassing_Purchased).ToString
            End If

            _strPartCode = strPartCodePassing_Purchased
            ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode = strPartCodePassing_Purchased         '12_10_2010   RAGAVA
            If rdbULugLathe_Existing.Checked = True Then
                Dim oSelectedLatheDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetBEULDetailsSelectedRowDetails(_strPartCode)
                SetSelectedLatheData(oSelectedLatheDataRow)
            ElseIf rdbDoubleLugExisitng.Checked = True Then
                Dim oSelectedDoubleLugDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetREDoubleLugCastingDetailsSelectedRowDetails(_strPartCode)
                SetSelectedCastingData(oSelectedDoubleLugDataRow)
            End If
            'ANUP 07-10-2010 TILL HERE
        Catch ex As Exception
        End Try
    End Sub

    'Here write the code to set the Lathe data to controls and some global variables
    Private Sub SetSelectedLatheData(ByVal oSelectedLatheDataRow As DataRow)
        ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated"
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Fabricated"
        If Not IsNothing(oSelectedLatheDataRow) Then
            Try
                If Not IsDBNull(oSelectedLatheDataRow("PartCode")) Then
                    'ANUP 07-10-2010 START
                    txtCodeNumber_Existing.Text = lvwExistingData.SelectedItems(0).Text
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ULug Lathe Code", lvwExistingData.SelectedItems(0).Text)
                    'ANUP 07-10-2010 TILL HERE
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = oSelectedLatheDataRow("PartCode")
                    Try
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSetScrew = oSelectedLatheDataRow("SetScrew")             '24_06_2010    RAGAVA
                    Catch ex As Exception
                    End Try
                End If

                If Not IsDBNull(oSelectedLatheDataRow("LugThickness")) Then
                    txtLugThickness_Existing.Text = oSelectedLatheDataRow("LugThickness")
                End If

                If Not IsDBNull(oSelectedLatheDataRow("LugWidth")) Then
                    txtLugWidth_Existing.Text = oSelectedLatheDataRow("LugWidth")
                End If

                If Not IsDBNull(oSelectedLatheDataRow("LugGap")) Then
                    txtLugGap_Existing.Text = oSelectedLatheDataRow("LugGap")
                End If

                If Not IsDBNull(oSelectedLatheDataRow("PinHoleCombined")) Then
                    txtPinHoleSize_Existing.Text = oSelectedLatheDataRow("PinHoleCombined")
                End If

                If Not IsDBNull(oSelectedLatheDataRow("SwingClearanceRadius")) Then
                    txtSwingClearance_Existing.Text = oSelectedLatheDataRow("SwingClearanceRadius")
                End If

                If Not IsDBNull(oSelectedLatheDataRow("Height")) Then
                    txtLugHeight_Existing.Text = oSelectedLatheDataRow("Height")
                End If

                txtWeldSize_Existing.Text = ""

                If oSelectedLatheDataRow("PartType").ToString.Contains("IFL_PART") Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "IFL_Designed_Existing"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "U_LUG_ROD"       '14_10_2010   RAGAVA
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "Existing"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "Base_U_Lug"                '14_10_2010   RAGAVA
                End If

                If Not IsDBNull(oSelectedLatheDataRow("PinHoletoBottomofLug")) Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = oSelectedLatheDataRow("PinHoletoBottomofLug")
                End If

                If Not IsDBNull(oSelectedLatheDataRow("PilotHole")) Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PilotHoleDiameter = oSelectedLatheDataRow("PilotHole").ToString
                End If

                DisplayToleranceValues(oSelectedLatheDataRow)

            Catch ex As Exception
            End Try
        Else
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ULug Lathe Code", "")
            txtCodeNumber_Existing.Text = ""
            txtLugThickness_Existing.Text = ""
            txtLugWidth_Existing.Text = ""
            txtLugGap_Existing.Text = ""
            txtPinHoleSize_Existing.Text = ""
            txtSwingClearance_Existing.Text = ""
            txtLugHeight_Existing.Text = ""
            txtWeldSize_Existing.Text = ""
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = ""
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = 0
        End If
    End Sub

    'Here write the code to set the casting data to controls and some global variables
    Private Sub SetSelectedCastingData(ByVal oSelectedDoubleLugDataRow As DataRow)
        ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Cast"
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Cast"
        If Not IsNothing(oSelectedDoubleLugDataRow) Then
            If Not IsDBNull(oSelectedDoubleLugDataRow("PartCode")) Then
                'ANUP 07-10-2010 START
                txtCodeNumber_Existing.Text = lvwExistingData.SelectedItems(0).Text
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("DoubleLug without Port Code", lvwExistingData.SelectedItems(0).Text)
                'ANUP 07-10-2010 TILL HERE
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = oSelectedDoubleLugDataRow("PartCode")
            End If

            If Not IsDBNull(oSelectedDoubleLugDataRow("LugThickness")) Then
                txtLugThickness_Existing.Text = oSelectedDoubleLugDataRow("LugThickness")
            End If

            If Not IsDBNull(oSelectedDoubleLugDataRow("LugWidth")) Then
                txtLugWidth_Existing.Text = oSelectedDoubleLugDataRow("LugWidth")
            End If

            If Not IsDBNull(oSelectedDoubleLugDataRow("LugGap")) Then
                txtLugGap_Existing.Text = oSelectedDoubleLugDataRow("LugGap")
            End If

            If Not IsDBNull(oSelectedDoubleLugDataRow("PinHoleSizeCombined")) Then
                txtPinHoleSize_Existing.Text = oSelectedDoubleLugDataRow("PinHoleSizeCombined")
            End If

            If Not IsDBNull(oSelectedDoubleLugDataRow("SwingClearanceRadius")) Then
                txtSwingClearance_Existing.Text = oSelectedDoubleLugDataRow("SwingClearanceRadius")
            End If

            txtLugHeight_Existing.Text = ""

            If Not IsDBNull(oSelectedDoubleLugDataRow("WeldSize")) Then
                txtWeldSize_Existing.Text = oSelectedDoubleLugDataRow("WeldSize")
            End If

            If oSelectedDoubleLugDataRow("PartType").ToString.Contains("IFL_PART") Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "IFL_Designed_Existing" 'ANUP 09-11-2010 START
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "ROD_END_DOUBLE_LUG_CASTING"
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "Existing"
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "U_LUG_ROD"
            End If

            If Not IsDBNull(oSelectedDoubleLugDataRow("DistanceFromPinHoleToRodStop")) Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = oSelectedDoubleLugDataRow("DistanceFromPinHoleToRodStop")
            End If

            DisplayToleranceValues(oSelectedDoubleLugDataRow)

            'If Not IsDBNull(oSelectedCastingDataRow("EndofTubetoRodStop")) Then
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = oSelectedCastingDataRow("EndofTubetoRodStop")
            'End If
        Else
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("DoubleLug without Port Code", "")
            txtCodeNumber_Existing.Text = ""
            txtLugThickness_Existing.Text = ""
            txtLugWidth_Existing.Text = ""
            txtLugGap_Existing.Text = ""
            txtPinHoleSize_Existing.Text = ""
            txtSwingClearance_Existing.Text = ""
            txtLugHeight_Existing.Text = ""
            txtWeldSize_Existing.Text = ""
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = ""
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = 0
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = 0           '04_11_2010   RAGAVA
        End If
    End Sub

    'Sunny 03-06-10
    Private Sub DisplayToleranceValues(ByVal oSelectedRow As DataRow)
        'Positive tolerance
        If Not IsDBNull(oSelectedRow("PinHoleCustom_UpperTolerance")) Then
            If oSelectedRow("PinHoleCustom_UpperTolerance").Equals("N/A") Then
                txtPinHoleTole_Pos.Text = "0.010"
            Else
                txtPinHoleTole_Pos.Text = oSelectedRow("PinHoleCustom_UpperTolerance")
            End If
        End If
        'Negative Tolerance
        If Not IsDBNull(oSelectedRow("PinHoleCustom_LowerTolerance")) Then
            If oSelectedRow("PinHoleCustom_LowerTolerance").Equals("N/A") Then
                txtPinHoleTole_Neg.Text = 0.005
            Else
                txtPinHoleTole_Neg.Text = oSelectedRow("PinHoleCustom_LowerTolerance")
            End If
        End If
    End Sub

    'Sunny 03-06-10
    Private Sub UpdatePreviousFormDetails_Lathe()
        Dim strMessage As String = "Rod End Configuration Details will be updated with the selected ULug Lathe details, " + vbCrLf
        If MessageBox.Show(strMessage, "Update TubeDetails", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
            If txtSwingClearance_Existing.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Text = txtSwingClearance_Existing.Text
            End If

            If txtLugThickness_Existing.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_RodEnd.Text = txtLugThickness_Existing.Text
            End If

            If ObjClsWeldedCylinderFunctionalClass.PinHoleSize_source_RodEnd = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.BushingPinHole Then
                If txtPinHoleSize_Existing.Text <> "" Then
                    ObjClsWeldedCylinderFunctionalClass.CmbBushingPinHoleSize_RodEnd.Text = txtPinHoleSize_Existing.Text
                End If
            ElseIf ObjClsWeldedCylinderFunctionalClass.PinHoleSize_source_RodEnd = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleCustom Then
                If txtPinHoleSize_Existing.Text <> "" Then
                    ObjClsWeldedCylinderFunctionalClass.TxtPinHoleSize_RodEnd.Text = txtPinHoleSize_Existing.Text
                End If
            ElseIf ObjClsWeldedCylinderFunctionalClass.PinHoleSize_source_RodEnd = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleStandard Then
                If txtPinHoleSize_Existing.Text <> "" Then
                    ObjClsWeldedCylinderFunctionalClass.CmbPinHoleSize_RodEnd.Text = txtPinHoleSize_Existing.Text
                End If
            End If

            If txtLugWidth_Existing.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd = Val(txtLugWidth_Existing.Text)
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

#Region "To Find Existing U Lug Lathe Data"

    'ONSITE:03-06-2010 This function is used to get the existing U Lug Lathe details
    Private Function SearchForExistingULugLathe() As Boolean
        Try
            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd _
                                  (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.ULug)
            If Get_AssignWeldSizeData() = False Then
                Return False
            End If
            _oExistingULugLatheData = GetFilterWithAreaData()
            If (Not IsNothing(_oExistingULugLatheData)) AndAlso _oExistingULugLatheData.Rows.Count > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception

        End Try

    End Function

    Private Function Get_AssignWeldSizeData() As Boolean
        Try
            Get_AssignWeldSizeData = False
            Dim dblRodDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
            Dim dblCalculatedWeldSize As Double = ObjClsWeldedCylinderFunctionalClass.WeldSizeCalculation
            Dim WeldSizeDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWeldSize_Lathe_ForFabrication(dblRodDiameter, dblCalculatedWeldSize)
            If Not IsNothing(WeldSizeDataTable) AndAlso Not WeldSizeDataTable.Rows.Count <= 0 Then
                Get_AssignWeldSizeData = True
                Dim oDRWeldSize As DataRow = WeldSizeDataTable.Rows(0)
                If Not IsNothing(oDRWeldSize) OrElse oDRWeldSize.ItemArray.Length <= 0 Then
                    If Not IsDBNull(oDRWeldSize("WeldSize")) Then
                        _dblWeldSize_ULugLathe = oDRWeldSize("WeldSize")   'TODO: ANUP 04-06-2010 01.52pm
                    End If
                    If Not IsDBNull(oDRWeldSize("WeldPreparation")) Then
                        _strWeldPreperation_ULugLathe = oDRWeldSize("WeldPreparation") 'TODO: ANUP 04-06-2010 01.52pm
                    End If
                    _dblJGrooveWidth_RodEnd_ULugLathe = _dblWeldSize_ULugLathe   'TODO: ANUP 04-06-2010 01.52pm
                    _dblJGrooveRadius_RodEnd_ULugLathe = 0   'TODO: ANUP 04-06-2010 01.52pm
                End If
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Function GetFilterWithAreaData() As DataTable
        Dim dblRequiredPinHoleSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
        Dim oFilterWithHeightDataTable As DataTable
        Dim _oFilterWithAreaDataTable As DataTable
        Dim dblRequiredArea As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd

        oFilterWithHeightDataTable = GetFilterWithHeightData()
        If IsNothing(oFilterWithHeightDataTable) Then
            Return Nothing
        End If

        oFilterWithHeightDataTable.Columns.Add("CalculatedSafetyFactor")
        For Each oFilterWithAreaDataRow As DataRow In oFilterWithHeightDataTable.Rows
            oFilterWithAreaDataRow("Area") = (oFilterWithAreaDataRow("LugWidth") - dblRequiredPinHoleSize) * oFilterWithAreaDataRow("LugThickness") * 2
        Next

        _oFilterWithAreaDataTable = New DataTable
        _oFilterWithAreaDataTable = oFilterWithHeightDataTable.Clone

        For Each oFilterWithAreaDataRow2Row As DataRow In oFilterWithHeightDataTable.Rows
            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd(ObjClsWeldedCylinderFunctionalClass. _
            ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, oFilterWithAreaDataRow2Row("YieldStrength"))

            oFilterWithAreaDataRow2Row("CalculatedSafetyFactor") = Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor + (oFilterWithAreaDataRow2Row("Area") / dblRequiredArea), 2) - 1
            If Val(oFilterWithAreaDataRow2Row("Area")) >= dblRequiredArea Then
                _oFilterWithAreaDataTable.Rows.Add(oFilterWithAreaDataRow2Row.ItemArray)
            End If
        Next
        Return _oFilterWithAreaDataTable
    End Function

    Private Function GetFilterWithHeightData() As DataTable
        Dim dblBushingWidth As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth_RodEnd
        Dim dblRequiredLugThickness As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
        Dim dblRequiredPinHoleSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
        Dim dblBushingQuantity As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity_RodEnd
        Dim dblRequiredLugGap As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd
        Dim dblRequiredSwingClearance As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
        Dim dblBoreDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
        Dim oULugLatheDataTable As DataTable

        oULugLatheDataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                                       BEULugDetailsLathe(dblBushingQuantity, dblBushingWidth, dblRequiredPinHoleSize, dblRequiredLugThickness, dblRequiredLugGap, dblBoreDiameter)

        If Not IsNothing(oULugLatheDataTable) AndAlso oULugLatheDataTable.Rows.Count > 0 Then
            Dim oFilterWithHeightDataTable As New DataTable
            oFilterWithHeightDataTable = oULugLatheDataTable.Clone
            For Each oFilterWithHeightDataRow As DataRow In oULugLatheDataTable.Rows
                Try
                    If oFilterWithHeightDataRow("PilotHole_Y_N") = "Y" Then
                        If oFilterWithHeightDataRow("SwingClearanceRadius") >= dblRequiredSwingClearance AndAlso oFilterWithHeightDataRow("SwingClearanceRadius") <= Val(dblRequiredSwingClearance * 1.25) AndAlso oFilterWithHeightDataRow("SwingClearanceRadius") <> "N/A" Then
                            oFilterWithHeightDataTable.Rows.Add(oFilterWithHeightDataRow.ItemArray)
                        End If
                    ElseIf oFilterWithHeightDataRow("PilotHole_Y_N") = "N" Then
                        If oFilterWithHeightDataRow("HeighttoRadiusEnd") >= (dblRequiredSwingClearance + (oFilterWithHeightDataRow("LugWidth") / 2)) _
                                                AndAlso oFilterWithHeightDataRow("HeighttoRadiusEnd") <= (dblRequiredSwingClearance + (oFilterWithHeightDataRow("LugWidth") / 2) * 2) _
                                                AndAlso oFilterWithHeightDataRow("HeighttoRadiusEnd") <> "N/A" Then
                            oFilterWithHeightDataTable.Rows.Add(oFilterWithHeightDataRow.ItemArray)
                        End If

                    End If
                Catch ex As Exception
                End Try
            Next
            Return oFilterWithHeightDataTable
        End If
        Return Nothing
    End Function

#End Region

#Region "To Find Existing DL Casting Data"

    Private Function SearchForExistingDoubleLugCastingDetails() As Boolean
        Try
            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd _
                                  (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.ULug)
            If GetSetWeldSize_Casting() = False Then
                Return False
            End If
            _oExistingDLCastingData = GetCastingData()
            If (Not IsNothing(_oExistingDLCastingData)) AndAlso _oExistingDLCastingData.Rows.Count > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception

        End Try

    End Function

    Private Function GetSetWeldSize_Casting() As Boolean
        Try
            GetSetWeldSize_Casting = False
            Dim dblCalculatedWeldSize As Double = ObjClsWeldedCylinderFunctionalClass.WeldSizeCalculation
            Dim WeldSizeDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWeldSize_ForCasting(dblCalculatedWeldSize, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter)

            If Not IsNothing(WeldSizeDataTable) AndAlso Not WeldSizeDataTable.Rows.Count <= 0 Then
                GetSetWeldSize_Casting = True
                Dim oDRWeldSize As DataRow = WeldSizeDataTable.Rows(0)
                If Not IsNothing(oDRWeldSize) OrElse oDRWeldSize.ItemArray.Length <= 0 Then
                    If Not IsDBNull(oDRWeldSize("WeldSizeNumeric")) Then
                        _dblWeldSize_Casting = oDRWeldSize("WeldSizeNumeric")
                    End If
                    If Not IsDBNull(oDRWeldSize("Width")) Then
                        _dblJGrooveWidth_RodEnd_Casting = Val(oDRWeldSize("Width")) - (Val(oDRWeldSize("Radius")) - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RadiusConstant)
                    End If
                    'If Not IsDBNull(oDRWeldSize("Radius")) Then
                    '    _dblJGrooveRadius_RodEnd_Casting = oDRWeldSize("Radius")
                    'End If
                    _dblJGrooveRadius_RodEnd_Casting = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RadiusConstant
                End If
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Function GetCastingData() As DataTable
        Dim dblRodDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
        Dim dblBushingWidth As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth_RodEnd
        Dim dblRequiredLugThickness As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
        Dim dblRequiredPinHoleSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
        Dim dblBushingQuantity As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity_RodEnd

        'ANUP 17-09-2010 START
        ' Dim dblSwingClearance As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
        Dim dblSwingClearance As Double = Val(ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Text)
        'ANUP 17-09-2010 TILL HERE

        Dim dblLugGap As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd

        Dim oREDLCastingDetails As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
               REDLCastingDetails(dblRodDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd, dblBushingWidth, dblRequiredPinHoleSize, dblBushingQuantity, dblRequiredLugThickness, _
               dblLugGap, dblSwingClearance)

        If IsNothing(oREDLCastingDetails) Then
            Return Nothing
        End If

        oREDLCastingDetails.Columns.Add("CalculatedSafetyFactor")
        Dim oCastingTable As DataTable = New DataTable
        oCastingTable = oREDLCastingDetails.Clone
        Dim dblRequiredArea As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd

        For Each oDataRow As DataRow In oREDLCastingDetails.Rows
            oDataRow("Area") = 2 * oDataRow("LugThickness") * (oDataRow("LugWidth") - dblRequiredPinHoleSize)
            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd _
            (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, oDataRow("YieldStrength"))
            oDataRow("CalculatedSafetyFactor") = Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor + (oDataRow("Area") / dblRequiredArea), 2) - 1
            If Not IsDBNull(oDataRow("Area")) Then
                If Val(oDataRow("Area")) >= dblRequiredArea Then
                    oCastingTable.Rows.Add(oDataRow.ItemArray)
                End If
            End If
        Next

        Return oCastingTable
    End Function

    'TODO: ANUP 04-06-2010 01.52pm
    Private Sub WeldSizeValues_ULug()
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd = _dblWeldSize_ULugLathe
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = _strWeldPreperation_ULugLathe
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.JGrooveWidth_RodEnd = _dblJGrooveWidth_RodEnd_ULugLathe
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.JGrooveRadius_RodEnd = _dblJGrooveRadius_RodEnd_ULugLathe
    End Sub

    'TODO: ANUP 04-06-2010 01.52pm
    Private Sub WeldSizeValues_Casting()
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd = _dblWeldSize_Casting
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = ""
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.JGrooveWidth_RodEnd = _dblJGrooveWidth_RodEnd_Casting
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.JGrooveRadius_RodEnd = _dblJGrooveRadius_RodEnd_Casting
    End Sub

#End Region

    


#End Region

#Region "Events"

    'Sunny 03-06-10
    Private Sub frmREDLExistingDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        InitialSettings()
        AddColumnsToListview()
        LoadFunctionality()
        CheckChanged()
    End Sub

    Private Sub rdbULugLathe_Existing_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbULugLathe_Existing.CheckedChanged, rdbDoubleLugExisitng.CheckedChanged
        CheckChanged()
    End Sub
    Private Sub CheckChanged()
        If rdbULugLathe_Existing.Checked = True Then
            lblExistingULugManualIndex.Text = "Existing ULug Lathe Details"
            DisplayDataInListview(_oExistingULugLatheData)
            WeldSizeValues_ULug()
        ElseIf rdbDoubleLugExisitng.Checked = True Then
            lblExistingULugManualIndex.Text = "Existing Double Lug Casting Details"
            DisplayDataInListview(_oExistingDLCastingData)
            WeldSizeValues_Casting()
        End If
    End Sub

    Private Sub lvwExistingData_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwExistingData.SelectedIndexChanged
        'ANUP 10-11-2010 START
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        rdbUseSelectedULUGManualYes.Checked = False
        rdbUseSelectedULUGManualNo.Checked = False
        'ANUP 10-11-2010 TILL HERE
        Try
            If lvwExistingData.SelectedItems.Count > 0 Then
                FindSetData(lvwExistingData.SelectedItems(0).Text)
                Try
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_RodEnd = lvwExistingData.SelectedItems(0).SubItems(2).Text      '31_05_2011   ragava
                Catch ex As Exception
                End Try
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = True           '21_10_2010   RAGAVA
            End If
        Catch ex As Exception

        End Try
        Try
            If lblExistingULugManualIndex.Text = "Existing ULug Lathe Details" Then
                ObjClsWeldedCylinderFunctionalClass.LugGapValidation()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rdbUseSelectedULUGManualYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedULUGManualYes.CheckedChanged
        If rdbUseSelectedULUGManualYes.Checked Then
            ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Lathe"
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = True        '20_10_2010    RAGAVA
            pnlMessage.Visible = False
            ObjClsWeldedCylinderFunctionalClass.BlnShowNewDesign_Thru_ExistingDesign_DoubleLug = False
            UpdatePreviousFormDetails_Lathe()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        End If
    End Sub

    Private Sub rdbUseSelectedULUGManualNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedULUGManualNo.CheckedChanged
        'ANUP 09-11-2010 START
        For Each oListViewItem As ListViewItem In lvwExistingData.Items
            If oListViewItem.Selected Then
                oListViewItem.Selected = True
            End If
        Next
        'ANUP 09-11-2010 TILL HERE

        If rdbUseSelectedULUGManualNo.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = False        '20_10_2010    RAGAVA
            pnlMessage.Visible = True
            ObjClsWeldedCylinderFunctionalClass.BlnShowNewDesign_Thru_ExistingDesign_DoubleLug = True
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
            'lvwExistingData.Refresh()          '21_10_2010    RAGAVA
        End If
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(LabelGradient6)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblExistingULugManualIndex)
    End Sub

End Class

