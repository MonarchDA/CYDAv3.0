Public Class frmREDLNewDesign

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

    Public Enum WeightListView
        SafetyFactor = 0
        LugThickness = 1
        Weight = 2
    End Enum

    Private _dblCalculatedWeldSize As Double
    Private _blnIsPrimaryInputsReq As Boolean = False

    Public Property IsPrimaryInputsReq() As Boolean
        Get
            Return _blnIsPrimaryInputsReq
        End Get
        Set(ByVal value As Boolean)
            _blnIsPrimaryInputsReq = value
        End Set
    End Property


    Public Sub ManualLoad()
        If EnaDisOptionsWeldSize() Then
            LoadFunctionality()
        End If
    End Sub

    Private Sub LoadFunctionality()
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd _
                                  (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.ULug)

        SetValues()
        AddColumns()
        CheckedChanged()
    End Sub

    Private Function EnaDisOptionsWeldSize() As Boolean
        EnaDisOptionsWeldSize = False
        _dblCalculatedWeldSize = ObjClsWeldedCylinderFunctionalClass.WeldSizeCalculation
        If ObjClsWeldedCylinderFunctionalClass.IsWeldSizeLess Then
            showMessage(False)
            Exit Function
        End If

        Dim Status As Boolean
        Status = (GetSetWeldSizeData_ULugManual() OrElse GetSetWeldSizeData_Casting() OrElse GetSetWeldSizeData_ULugLathe())
        showMessage(Status)
        EnaDisOptionsWeldSize = Status
    End Function

    Private Sub showMessage(ByVal blnStatus As Boolean)
        If blnStatus Then
            Me.Enabled = True
            rdbLowVolumeProduct.Enabled = GetSetWeldSizeData_ULugManual()
            rdbHighVolumeProduct.Enabled = (GetSetWeldSizeData_Casting() OrElse GetSetWeldSizeData_ULugLathe())
            If rdbHighVolumeProduct.Enabled Then
                rdbDesignDoubleLugCasting.Enabled = GetSetWeldSizeData_Casting()
                rdbDesignULugLathe.Enabled = GetSetWeldSizeData_ULugLathe()
            End If
            grbNewDesign.BringToFront()
            _blnIsPrimaryInputsReq = False
        Else
            Me.Enabled = False
            grbCalculatedWeldSize.BringToFront()
            _blnIsPrimaryInputsReq = True
        End If

    End Sub


    Private Sub SetValues()
        txtLugGap_NewDesign.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd
        txtLugWidth_NewDesign.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd
        txtLugThickness_NewDesign.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
        txtPinHoleSize_NewDesign.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd

        'ANUP 17-09-2010 START
        '  txtSwingClearance_NewDesign.Text  = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
        txtSwingClearance_NewDesign.Text = Val(ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Text)
        'ANUP 17-09-2010 TILL HERE

        trbSafetyFactor_NewDesign.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
        trbSafetyFactor_NewDesign.Maximum = trbSafetyFactor_NewDesign.Minimum + 20
        trbSafetyFactor_NewDesign.TickFrequency = 1
        trbSafetyFactor_NewDesign.Value = trbSafetyFactor_NewDesign.Minimum
        trbSafetyFactor_NewDesign.Text = trbSafetyFactor_NewDesign.Value
        Dim dblSafetyFactor As Double = trbSafetyFactor_NewDesign.Minimum + ((trbSafetyFactor_NewDesign.Value - trbSafetyFactor_NewDesign.Minimum) * 0.25)
        txtSafetyFactor_NewDesign.Text = dblSafetyFactor

        'SetSafetyFactor()
    End Sub

    Private Sub AddColumns()
        lvwDesignULug_NewDesign.Columns.Add("SafetyFactor", 130, HorizontalAlignment.Center)
        lvwDesignULug_NewDesign.Columns.Add("LugThickness", 130, HorizontalAlignment.Center)
        lvwDesignULug_NewDesign.Columns.Add("Weight", 125, HorizontalAlignment.Center)
        lvwDesignULug_NewDesign.FullRowSelect = True
    End Sub

    Private Sub CheckedChanged()
        lvwDesignULug_NewDesign.Items.Clear()
        If rdbLowVolumeProduct.Checked = True Then
            pnlDesignULugLathe_DoubleLugCasting.Enabled = False
            rdbDesignULugLathe.Checked = False
            rdbDesignDoubleLugCasting.Checked = False
            lblContentName.Text = "Design ULug Manual"
            GetSetWeldSizeData_ULugManual()
            ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated"    '12_08_2010   RAGAVA
        ElseIf rdbHighVolumeProduct.Checked = True Then
            pnlDesignULugLathe_DoubleLugCasting.Enabled = True
            EnableDisableULugOption()
            If rdbDesignULugLathe.Checked = True Then
                lblContentName.Text = "Design ULug Lathe"
                ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated"    '12_08_2010   RAGAVA
                GetSetWeldSizeData_ULugLathe()
            ElseIf rdbDesignDoubleLugCasting.Checked = True Then
                lblContentName.Text = "Design Double Lug Casting"
                ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Cast"    '12_08_2010   RAGAVA
                GetSetWeldSizeData_Casting()
            End If
        End If
    End Sub



    Private Sub rdbLowVolumeProduct_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbLowVolumeProduct.CheckedChanged, rdbHighVolumeProduct.CheckedChanged, rdbDesignULugLathe.CheckedChanged, rdbDesignDoubleLugCasting.CheckedChanged
        CheckedChanged()
        If rdbDesignULugLathe.Checked OrElse rdbLowVolumeProduct.Checked Then
            WidthCalculation_ULug()
            LugWidth_Validation()
            ObjClsWeldedCylinderFunctionalClass.LugGapValidation()
        ElseIf rdbDesignDoubleLugCasting.Checked = True Then
            WidthCalculation_Casting()
        End If
    End Sub

    Private Sub EnableDisableULugOption()
        If rdbHighVolumeProduct.Checked = True Then
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter > 1.5 OrElse Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass) > 2 OrElse (GetSetWeldSizeData_ULugLathe() = False) Then
                rdbDesignULugLathe.Enabled = False
            Else
                rdbDesignULugLathe.Enabled = True
            End If
        End If
    End Sub

    Private Sub frmREDLNewDesign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ColorTheForm()
        If EnaDisOptionsWeldSize() Then
            rdbLowVolumeProduct.Checked = True
            LoadFunctionality()
            If rdbLowVolumeProduct.Checked Then
                LugWidth_Validation()
            End If
        End If
    End Sub

    Private Function FindSafetyFactor() As Double
        Dim dblPinHoleSize As Double
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity = 0 Then
            dblPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
        Else
            dblPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingOD_BaseEnd
        End If
        Dim CrossTubeOD As Double = dblPinHoleSize + (2 * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired)
        Dim dblRequiredArea As Double
        Dim dblReqSF As Double
        If CrossTubeOD < ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD Then
            dblRequiredArea = ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD - dblPinHoleSize) * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth) / ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
            dblReqSF = dblRequiredArea * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor
            Return dblReqSF
        End If
        Return 0
    End Function

    Private Sub SetSafetyFactor()
        Dim dblSF As Double = FindSafetyFactor()
        Dim MaxValue As Double = trbSafetyFactor_NewDesign.Minimum + ((trbSafetyFactor_NewDesign.Maximum - trbSafetyFactor_NewDesign.Value) * 0.25) '(trbSafetyFactor_RECT.Maximum - 2) / 4
        If dblSF > MaxValue Then
            dblSF = ObjClsWeldedCylinderFunctionalClass.RoundUp(dblSF, 2)
            Dim strMessage As String = "Safety Factor is : " + dblSF.ToString + " which is above the given range"
            MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            trbSafetyFactor_NewDesign.Value = ((dblSF - trbSafetyFactor_NewDesign.Minimum) / 0.25) + trbSafetyFactor_NewDesign.Minimum
            trbSafetyFactor_NewDesign.Text = trbSafetyFactor_NewDesign.Minimum + ((trbSafetyFactor_NewDesign.Value - trbSafetyFactor_NewDesign.Minimum) * 0.25)
        End If
    End Sub

    Private Sub btnGenerate_NewDesign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate_NewDesign.Click
        If rdbDesignDoubleLugCasting.Checked = True Then

            GenerateCode_Casting()
        Else
            GenerateCode_ULug()
        End If
    End Sub

    Private Sub GenerateCode_Casting()
        setGlobalValues()

        'ANUP 09-11-2010 START 
        ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Cast"
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Cast"
        ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Lathe"
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "NewDesign"

        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd + 0.36 'TODO:Sunny 13-04-10 5pm
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop
        'ANUP 09-11-2010 TILL HERE

        'ANUP 17-09-2010 START
        If ObjClsWeldedCylinderFunctionalClass.SwingClearanceValidation_PartCondition_RodEnd Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd = Val(ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Text) + 0.0625
        End If
        'ANUP 17-09-2010 TILL HERE

        Dim strName As String = "NewDoubleLugCastPartCopied"
        Dim strFilePart As String = String.Empty
        Dim strFilePartDesignTableExcel As String = String.Empty
        Dim dblWeight As Double
        Try
            strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_END_DOUBLE_LUG_CASTING\ROD_END_DOUBLE_LUG_CASTING.SLDPRT"
            strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\ROD_END_DOUBLE_LUG_CASTING.XLS"
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "ROD_END_DOUBLE_LUG_CASTING"      '01_03_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.Design_New_Part(strFilePart, strFilePartDesignTableExcel, strName)
            dblWeight = ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Weight")
            ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_END_DOUBLE_LUG_CASTING", True)
        Catch ex As Exception
        End Try
        CheckExistingItem(dblWeight)
    End Sub

    Private Sub GenerateCode_ULug()
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BendRadius_RodEnd
        setGlobalValues()
        SetLathe_Manual()
        Dim strName As String = "NewDoubleLugWeldedLathePartCopied"
        Dim strFilePart As String = String.Empty
        Dim strFilePartDesignTableExcel As String = String.Empty
        Dim dblWeight As Double
        Try
            strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\U_LUG_ROD\U_LUG_ROD.SLDPRT"
            strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\U_LUG_ROD.XLS"
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "U_LUG_ROD"
            ObjClsWeldedCylinderFunctionalClass.Design_New_Part(strFilePart, strFilePartDesignTableExcel, strName)
            dblWeight = ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Weight")
            CheckExistingItem(dblWeight)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub setGlobalValues()
        If txtSafetyFactor_NewDesign.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_RodEnd = txtSafetyFactor_NewDesign.Text
        End If
        If txtLugThickness_NewDesign.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_RodEnd.Text = txtLugThickness_NewDesign.Text
        End If
    End Sub

    Private Sub SetLathe_Manual()
        If rdbLowVolumeProduct.Checked = True Then
            ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual"
        ElseIf rdbDesignULugLathe.Checked = True Then
            ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Lathe"
        End If
        ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated"
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Fabricated"
    End Sub


    Private Sub CheckExistingItem(ByVal dblWeight As Double)
        Dim blnDuplicateFound As Boolean
        If lvwDesignULug_NewDesign.Items.Count > 0 Then
            For Each oItem As ListViewItem In lvwDesignULug_NewDesign.Items
                If oItem.Text.Equals(txtSafetyFactor_NewDesign.Text) AndAlso _
                 oItem.SubItems(0).Text.Equals(txtLugThickness_NewDesign.Text) Then
                    blnDuplicateFound = True
                End If
            Next
        End If
        If Not blnDuplicateFound Then
            Dim oListViewItem As New ListViewItem
            oListViewItem.Text = txtSafetyFactor_NewDesign.Text
            oListViewItem.SubItems.Add(txtLugThickness_NewDesign.Text)
            oListViewItem.SubItems.Add(dblWeight)
            lvwDesignULug_NewDesign.Items.Add(oListViewItem)
        End If
    End Sub

    Private Sub btnAccept_NewDesign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept_NewDesign.Click
        If txtSafetyFactor_NewDesign.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_RodEnd = txtSafetyFactor_NewDesign.Text       '31_05_2011  RAGAVA
        End If
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = False        '20_10_2010   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        btnAccept_NewDesign.Enabled = False
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "NewDesign"
    End Sub

    Private Sub WidthCalculation_ULug()
        Try
            Dim dblSafetyFactor As Double = trbSafetyFactor_NewDesign.Minimum + ((trbSafetyFactor_NewDesign.Value - trbSafetyFactor_NewDesign.Minimum) * 0.25)
            txtSafetyFactor_NewDesign.Text = dblSafetyFactor
            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd(dblSafetyFactor, _
            clsWeldedCylinderFunctionalClass.YeildStrengthConstants.ULug)
            txtLugWidth_NewDesign.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd
        Catch ex As Exception
        End Try
    End Sub

    Private Sub WidthCalculation_Casting()
        Dim dblSafetyFactor As Double = trbSafetyFactor_NewDesign.Minimum + ((trbSafetyFactor_NewDesign.Value - trbSafetyFactor_NewDesign.Minimum) * 0.25)
        txtSafetyFactor_NewDesign.Text = dblSafetyFactor
        ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd(dblSafetyFactor, _
        clsWeldedCylinderFunctionalClass.YeildStrengthConstants.DoubleLug_Cast_NoPort)
        txtLugWidth_NewDesign.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd
    End Sub

    Private Sub trbSafetyFactor_NewDesign_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trbSafetyFactor_NewDesign.Scroll
        If rdbDesignDoubleLugCasting.Checked = True Then
            WidthCalculation_Casting()
        Else
            WidthCalculation_ULug()
        End If

    End Sub

    Private Sub lvwDesignULug_NewDesign_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwDesignULug_NewDesign.SelectedIndexChanged
        If lvwDesignULug_NewDesign.SelectedIndices.Count > 0 Then
            Dim oListViewSelectedItem As ListViewItem = lvwDesignULug_NewDesign.SelectedItems(0)
            trbSafetyFactor_NewDesign.Value = ((Val(oListViewSelectedItem.Text) - trbSafetyFactor_NewDesign.Minimum) / 0.25) + trbSafetyFactor_NewDesign.Minimum
            txtLugWidth_NewDesign.Text = oListViewSelectedItem.SubItems(0).Text
            btnAccept_NewDesign.Enabled = True
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            ObjClsWeldedCylinderFunctionalClass.RodEndWeight = Val(oListViewSelectedItem.SubItems(WeightListView.Weight).Text)
        End If
    End Sub

    'TODO: ANUP 04-06-2010 12.38pm
    Private Sub txtLugWidth_NewDesign_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLugWidth_NewDesign.TextChanged
        If lblContentName.Text = "Design ULug Lathe" OrElse lblContentName.Text = "Design ULug Manual" Then
            LugWidth_Validation()
        End If
    End Sub
    '********************
    'TODO: ANUP 04-06-2010 12.38pm
    Private Sub LugWidth_Validation()
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd = ObjClsWeldedCylinderFunctionalClass.LugWidth_SingleLugOrULug_Fabrication(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd)
        txtLugWidth_NewDesign.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd
    End Sub
    '********************


    Private Function GetSetWeldSizeData_ULugLathe() As Boolean
        Try
            GetSetWeldSizeData_ULugLathe = False
            Dim WeldSizeDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWeldSize_Lathe_ForFabrication(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, _dblCalculatedWeldSize)
            If Not IsNothing(WeldSizeDataTable) AndAlso Not WeldSizeDataTable.Rows.Count <= 0 Then
                Dim oDRWeldSize As DataRow = WeldSizeDataTable.Rows(0)
                If Not IsNothing(oDRWeldSize) OrElse oDRWeldSize.ItemArray.Length <= 0 Then
                    If Not IsDBNull(oDRWeldSize("WeldSize")) Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd = oDRWeldSize("WeldSize")
                    End If
                    If Not IsDBNull(oDRWeldSize("WeldPreparation")) Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = oDRWeldSize("WeldPreparation")
                    End If
                End If
                GetSetWeldSizeData_ULugLathe = True
                'Else
                '    Dim StrMessage As String = " Calculated Weld Size is more than Existing weld Size"
                '    MessageBox.Show(StrMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Function GetSetWeldSizeData_Casting() As Boolean
        GetSetWeldSizeData_Casting = False
        Dim WeldSizeDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWeldSize_ForCasting(_dblCalculatedWeldSize, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter)

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
            End If
            GetSetWeldSizeData_Casting = True
        End If
    End Function

    Private Function GetSetWeldSizeData_ULugManual() As Boolean
        GetSetWeldSizeData_ULugManual = False
        Dim dblRodDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
        Dim WeldSizeDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWeldSize_ForFabrication(dblRodDiameter, _dblCalculatedWeldSize, clsWeldedCylinderFunctionalClass.ConfigurationTypes.Ulug, clsWeldedCylinderFunctionalClass.WeldType.ManualWeld)

        If Not IsNothing(WeldSizeDataTable) AndAlso Not WeldSizeDataTable.Rows.Count <= 0 Then
            Dim oDRWeldSize As DataRow = WeldSizeDataTable.Rows(0)
            If Not IsNothing(oDRWeldSize) OrElse oDRWeldSize.ItemArray.Length <= 0 Then
                If Not IsDBNull(oDRWeldSize("WeldSize")) Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd = oDRWeldSize("WeldSize")
                End If
                If Not IsDBNull(oDRWeldSize("WeldPreparation")) Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = oDRWeldSize("WeldPreparation")
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = "J-Groove" Then
                    GetExtensionWeldSizeData()
                End If
            End If
            GetSetWeldSizeData_ULugManual = True
        End If
    End Function


    Private Sub GetExtensionWeldSizeData()
        Dim oDRWeldSize As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetJGroveWidthOrRadius_ForFabrication(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd)
        If Not IsNothing(oDRWeldSize) OrElse oDRWeldSize.ItemArray.Length <= 0 Then
            If Not IsDBNull(oDRWeldSize("Width")) Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.JGrooveWidth_RodEnd = oDRWeldSize("Width")
            End If
            If Not IsDBNull(oDRWeldSize("Radius")) Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.JGrooveRadius_RodEnd = oDRWeldSize("Radius")
            End If
        End If

    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(LabelGradient6)
        'anup 08-03-2011 start
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblNewDesign)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblContentName)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient8)
        'anup 08-03-2011 till here
    End Sub

End Class