Public Class frmCTFabricationNew2

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

    Private _intSafetyFactorCount As Integer = 0

    Public Enum WeightListView
        SafetyFactor = 0
        LugWidth = 1
        Weight = 2
    End Enum

    Private Sub SafetyFactor_LugThickness_Weight_GeneretedDesign()
        lvwSafetyFactor_Weight.Clear()
        lvwSafetyFactor_Weight.Columns.Add("SafetyFactor", 130, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight.Columns.Add("CrossTubeWidth", 130, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight.Columns.Add("Weight", 125, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight.FullRowSelect = True
    End Sub

    Private Sub txtCrossTubeWidth_DesignCrossTube_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCrossTubeWidth_DesignCrossTube.Leave
        If txtCrossTubeWidth_DesignCrossTube.Text <> "" Then
            If txtCrossTubeWidth_DesignCrossTube.Text <> txtCrossTubeWidth_DesignCrossTube.IFLDataTag Then
                txtCrossTubeWidth_DesignCrossTube.IFLDataTag = txtCrossTubeWidth_DesignCrossTube.Text

                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth = Val(txtCrossTubeWidth_DesignCrossTube.Text)
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth2 = Val(txtCrossTubeWidth_DesignCrossTube.Text)
                End If
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth = Val(txtCrossTubeWidth_DesignCrossTube.Text)


                trbSafetyFactor.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
                trbSafetyFactor.Maximum = trbSafetyFactor.Minimum + 20
                trbSafetyFactor.TickFrequency = 1
                trbSafetyFactor.Value = trbSafetyFactor.Minimum
                txtSafetyFactor_DesignCrossTube.Text = trbSafetyFactor.Value

                ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation _
                (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, Me.chkOptimizer.Checked, _
                clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube)        '12_11_2009   Ragava
                txtCrossTubeOD_DesignCrossTube.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD
                txtSwingClearance_DesignCrossTube.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
                'ValidLugThickness() 13_11_2009  Ragava
                btnAccept.Enabled = False
            End If
        Else
            txtCrossTubeWidth_DesignCrossTube.IFLDataTag = ""
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth = 0
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth2 = 0
        End If
    End Sub

    Private Sub lvwSafetyFactor_Weight_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwSafetyFactor_Weight.SelectedIndexChanged
        If lvwSafetyFactor_Weight.SelectedIndices.Count > 0 Then
            Dim oListViewSelectedItem As ListViewItem = lvwSafetyFactor_Weight.SelectedItems(0)
            trbSafetyFactor.Value = ((Val(oListViewSelectedItem.SubItems(WeightListView.SafetyFactor).Text) - trbSafetyFactor.Minimum) / 0.25) + trbSafetyFactor.Minimum
            ObjClsWeldedCylinderFunctionalClass.BaseEndWeight = Val(oListViewSelectedItem.SubItems(WeightListView.Weight).Text)
        End If
    End Sub

    Private Sub trbSafetyFactor_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trbSafetyFactor.ValueChanged
        btnAccept.Enabled = False
        WidthCalculation()
    End Sub

    Private Sub trbSafetyFactor_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trbSafetyFactor.Scroll
        'btnAccept.Enabled = False
        WidthCalculation()
        For Each oItem As ListViewItem In lvwSafetyFactor_Weight.Items
            oItem.Selected = False
        Next
    End Sub



    Private Sub WidthCalculation()
        Try
            Dim dblSafetyFactor As Double = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
            txtSafetyFactor_DesignCrossTube.Text = dblSafetyFactor
            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation(dblSafetyFactor, Me.chkOptimizer.Checked, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube)     '12_11_2009   Ragava
            txtCrossTubeOD_DesignCrossTube.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        '26_02_2010 Aruna Start
        Me.Cursor = Cursors.WaitCursor
        Dim strFilePart As String = ""
        Dim strFilePartDesignTableExcel As String = ""
        Dim strName As String = "NewCrossTubeFabrication"
        btnAccept.Enabled = True '2_03_2010 Aruna
        If txtSafetyFactor_DesignCrossTube.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd = txtSafetyFactor_DesignCrossTube.Text
        End If
        If txtCrossTubeWidth_DesignCrossTube.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.TxtCrossTubeWidth_BaseEnd.Text = txtCrossTubeWidth_DesignCrossTube.Text
        End If
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = -0.125
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5

        strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_CROSSTUBE\Base_Crosstube_IFL.SLDPRT"
        'Aruna 19_3_2010
        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_CROSSTUBE", False)
        strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BASE_CROSSTUBE.xls"
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "Base_Crosstube_IFL"
        ObjClsWeldedCylinderFunctionalClass.Design_New_Part(strFilePart, strFilePartDesignTableExcel, "NewCrossTubeFabrication")
        Dim dblWeight As Double = ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Weight")
        Try
            Dim blnDuplicateFound As Boolean = False
            If lvwSafetyFactor_Weight.Items.Count > 0 Then
                For Each oItem As ListViewItem In lvwSafetyFactor_Weight.Items
                    If oItem.SubItems(WeightListView.SafetyFactor).Text.Equals(txtSafetyFactor_DesignCrossTube.Text) AndAlso _
                     oItem.SubItems(WeightListView.LugWidth).Text.Equals(txtCrossTubeWidth_DesignCrossTube.Text) AndAlso oItem.SubItems(WeightListView.Weight).Text.Equals(dblWeight.ToString) Then         '28_10_2010   RAGAVA
                        blnDuplicateFound = True
                    End If
                Next
            End If
            If Not blnDuplicateFound Then
                Dim oListViewItem As ListViewItem
                oListViewItem = lvwSafetyFactor_Weight.Items.Add(txtSafetyFactor_DesignCrossTube.Text)
                lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(txtCrossTubeWidth_DesignCrossTube.Text)
                lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(dblWeight)
                _intSafetyFactorCount += 1
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in btnGenerate_Click of frmCTFabrication " + ex.Message)
        End Try
        '26_02_2010 Aruna Ends
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewFabricationGenerated = True             '17_10_2012   RAGAVA
        '26_02_2010 Aruna Start
        If txtSafetyFactor_DesignCrossTube.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd = txtSafetyFactor_DesignCrossTube.Text
        End If

        If txtCrossTubeWidth_DesignCrossTube.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.TxtCrossTubeWidth_BaseEnd.Text = txtCrossTubeWidth_DesignCrossTube.Text
        End If

        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        btnAccept.Enabled = False
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "NewDesign"

        ObjClsWeldedCylinderFunctionalClass.TxtCrossTubeWidth_BaseEnd.Text = txtCrossTubeOD_DesignCrossTube.Text
        'txtCrossTubeWidth_DesignCrossTube
        ObjClsWeldedCylinderFunctionalClass.TxtCrossTubeWidth_BaseEnd.Text = txtCrossTubeWidth_DesignCrossTube.Text
        '26_02_2010 Aruna End
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False        '20_10_2010   RAGAVA
        ''Added by Sandeep --set  This parameter for retracted length calculation(the value which we are going to insert in db)
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinHoletoRodStop = oSelectedCastingDataRow("DistancefromPinholetoRodStop")

    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblDesignNewCasting)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblSafetyFactorIndex)
    End Sub

    Private Sub frmCTFabricationNew_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        ColorTheForm()
    End Sub

    Private Sub chkOptimizer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOptimizer.CheckedChanged
        Try
            WidthCalculation()
        Catch ex As Exception

        End Try
    End Sub
End Class