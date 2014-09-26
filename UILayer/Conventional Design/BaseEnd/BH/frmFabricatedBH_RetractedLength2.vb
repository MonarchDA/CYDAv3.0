Public Class frmFabricatedBH_RetractedLength2
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

    Private _intSafetyFactorCount As Integer = 0

#End Region

#Region "Enum"

    Public Enum WeightListView
        SafetyFactor = 0
        LugThickness = 1
        Weight = 2
    End Enum

#End Region

#Region "Sub Procedures"

    Private Sub WidthCalculation()
        Try
            Dim dblSafetyFactor As Double = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
            txtSafetyFactor_DesignBH.Text = dblSafetyFactor
            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation(dblSafetyFactor, Me.chkOptimizer.Checked, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.SingleLug, "2")  '28_06_2012   RAGAVA
            txtLugWidth_DesignBH.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ValidLugThickness()
        Try
            Dim ObjDt As DataTable
            Dim dblMaxLugThickness As Double = 0
            Dim dblLugThickNess As Double = Val(txtLugThickness_DesignBH.Text)

            Try
                Dim oDesignBHDataTable As DataTable
                oDesignBHDataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetTableDetails("Select * from Welded.DesignULugValidDetails")

                If Not IsNothing(oDesignBHDataTable) Then
                    For Each dr As DataRow In oDesignBHDataTable.Rows
                        If dblMaxLugThickness < dr("ULugThickness") Then
                            dblMaxLugThickness = dr("ULugThickness")
                        End If
                    Next
                End If
            Catch ex As Exception
            End Try

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "BH" Then
                dblMaxLugThickness = 2
            End If

            If dblMaxLugThickness < dblLugThickNess Then
                MessageBox.Show("No Material Available After LugThickness 2 ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                txtLugThickness_DesignBH.Text = dblMaxLugThickness.ToString
            Else
                ObjDt = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetTableDetails("Select top 1 * from Welded.DesignULugValidDetails Where ULugThickness >= " + dblLugThickNess.ToString)
                ObjClsWeldedCylinderFunctionalClass.BendRadius = ObjDt.Rows(0)("BendRadius")
                txtLugThickness_DesignBH.Text = ObjDt.Rows(0)("ULugThickness")
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in ValidLugThickness of frmBHFabrication " + ex.Message)
        End Try
        '13_11_2009 Ragava Till Here
    End Sub

    Private Sub DefaultSettings()
        txtSafetyFactor_DesignBH.Enabled = False
        txtLugThickness_DesignBH.Enabled = True
        txtLugWidth_DesignBH.Enabled = False
        txtPinHoleSize_DesignBH.Enabled = False
        txtSwingClearance_DesignBH.Enabled = False

        btnAccept.Enabled = False

        lvwSafetyFactor_Weight.Clear()
        lvwSafetyFactor_Weight.Columns.Add("SafetyFactor", 130, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight.Columns.Add("LugThickness", 130, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight.Columns.Add("Weight", 125, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight.FullRowSelect = True

        ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation _
       (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, Me.chkOptimizer.Checked, _
                   clsWeldedCylinderFunctionalClass.YeildStrengthConstants.SingleLug, "2")   '28_06_2012   RAGAVA
        Dim GetLugWidthDataValue As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetLugWidthForComparision(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth)
        txtLugWidth_DesignBH.Text = GetLugWidthDataValue

        txtLugThickness_DesignBH.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
        txtPinHoleSize_DesignBH.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
        txtSwingClearance_DesignBH.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance

        trbSafetyFactor.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
        trbSafetyFactor.Maximum = trbSafetyFactor.Minimum + 20
        trbSafetyFactor.TickFrequency = 1
        trbSafetyFactor.Value = trbSafetyFactor.Minimum
        Dim dblSafetyFactor As Double = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
        txtSafetyFactor_DesignBH.Text = dblSafetyFactor

        btnClose.Enabled = False

    End Sub

#End Region

#Region "Events"

    Private Sub frmFabricatedBH_RetractedLength_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        ColorTheForm()
        DefaultSettings()
    End Sub

    Private Sub trbSafetyFactor_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trbSafetyFactor.Scroll
        For Each oItem As ListViewItem In lvwSafetyFactor_Weight.Items
            oItem.Selected = False
        Next
    End Sub

    Private Sub trbSafetyFactor_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trbSafetyFactor.ValueChanged
        btnAccept.Enabled = False
        WidthCalculation()
    End Sub

    Private Sub txtLugThickness_DesignULug_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLugThickness_DesignBH.Leave
        If txtLugThickness_DesignBH.Text <> "" Then
            If txtLugThickness_DesignBH.Text <> txtLugThickness_DesignBH.IFLDataTag Then
                txtLugThickness_DesignBH.IFLDataTag = txtLugThickness_DesignBH.Text

                ValidLugThickness() '13_11_2009  Ragava

                trbSafetyFactor.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
                trbSafetyFactor.Maximum = trbSafetyFactor.Minimum + 20
                trbSafetyFactor.TickFrequency = 1
                trbSafetyFactor.Value = trbSafetyFactor.Minimum
                Dim dblSafetyFactor As Double = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
                txtSafetyFactor_DesignBH.Text = dblSafetyFactor
            End If
        Else
            txtLugThickness_DesignBH.IFLDataTag = ""
        End If
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewFabricationGenerated = True             '17_10_2012   RAGAVA
        If txtSafetyFactor_DesignBH.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd = txtSafetyFactor_DesignBH.Text
        End If
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnFabricated2SingleLug = True   '05_01_2012  RAGAVA
        If txtLugThickness_DesignBH.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd.Text = txtLugThickness_DesignBH.Text
        End If
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True          '10_01_2012   RAGAVA
        btnAccept.Enabled = False
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "NewDesign"
        btnClose.Enabled = True
    End Sub

    Private Sub lvwSafetyFactor_Weight_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwSafetyFactor_Weight.SelectedIndexChanged
        If lvwSafetyFactor_Weight.SelectedIndices.Count > 0 Then
            Dim oListViewSelectedItem As ListViewItem = lvwSafetyFactor_Weight.SelectedItems(0)
            trbSafetyFactor.Value = ((Val(oListViewSelectedItem.SubItems(WeightListView.SafetyFactor).Text) - trbSafetyFactor.Minimum) / 0.25) + trbSafetyFactor.Minimum
            txtLugThickness_DesignBH.Text = oListViewSelectedItem.SubItems(WeightListView.LugThickness).Text
            btnAccept.Enabled = True
            btnClose.Enabled = False
            ObjClsWeldedCylinderFunctionalClass.BaseEndWeight = Val(oListViewSelectedItem.SubItems(WeightListView.Weight).Text)
        End If
    End Sub

    Private Sub txtLugWidth_DesignSingleLug_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLugWidth_DesignBH.TextChanged
        If txtLugWidth_DesignBH.Text <> "" Then
            If txtLugWidth_DesignBH.Text <> txtLugWidth_DesignBH.IFLDataTag Then
                txtLugWidth_DesignBH.IFLDataTag = txtLugWidth_DesignBH.Text
                Try
                    Dim ObjDt As DataTable
                    Dim dblLugWidth As Double = Val(txtLugWidth_DesignBH.Text)
                    Dim dblMaxLugWidth As Double = 0

                    Try
                        Dim oDesignBHDataTable As DataTable  '13_11_2009   Ragava
                        oDesignBHDataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetTableDetails("Select * from Welded.DesignULugValidDetails")

                        If Not IsNothing(oDesignBHDataTable) Then
                            For Each dr As DataRow In oDesignBHDataTable.Rows
                                If dblMaxLugWidth < dr("ULugWidth") Then
                                    dblMaxLugWidth = dr("ULugWidth")
                                End If
                            Next
                        End If
                    Catch ex As Exception
                    End Try

                    If dblMaxLugWidth < dblLugWidth Then
                        MessageBox.Show("No Material Available After LugWidth 3.50", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                        trbSafetyFactor.Value = trbSafetyFactor.Value - 1
                        Dim dblSafetyFactor As Double = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
                        txtSafetyFactor_DesignBH.Text = dblSafetyFactor
                    Else
                        ObjDt = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetTableDetails("Select top 1 * from Welded.DesignULugValidDetails Where ULugWidth >= " + dblLugWidth.ToString)
                        ObjClsWeldedCylinderFunctionalClass.TopRadius = ObjDt.Rows(0)("TopRadius")
                        txtLugWidth_DesignBH.Text = ObjDt.Rows(0)("ULugWidth")
                        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabricated" Then
                        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugWidth_DesignBH.Text)
                        'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2 = Val(txtLugWidth_DesignBH.Text)
                        'End If
                    End If
                Catch oException As Exception
                    ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in txtLugWidth_DesignBH_TextChanged of frmBHFabrication " + oException.Message)
                End Try
            End If
        Else
            txtLugWidth_DesignBH.IFLDataTag = ""
        End If
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            'To be verified assumed
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2 = -0.125
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2 = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5

            If txtSafetyFactor_DesignBH.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd2 = txtSafetyFactor_DesignBH.Text
            End If

            If txtLugThickness_DesignBH.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd.Text = txtLugThickness_DesignBH.Text
            End If
            If txtLugWidth_DesignBH.Text <> "" Then
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabricated" Then
                '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugWidth_DesignBH.Text)
                'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2 = Val(txtLugWidth_DesignBH.Text)
                'End If
            End If

            '02_03_2010 Aruna
            Dim dblLugHeight As Double
            dblLugHeight = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2 + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2 / 2)
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.lugHeight_BaseEnd = dblLugHeight


            '20_01_2012   RAGAVA
            Try
                If ObjClsWeldedCylinderFunctionalClass.WeldSize_Validation_SL_BaseEnd() Then
                    Exit Try
                End If
            Catch ex As Exception
            End Try
            'Till    Here

            Dim strFilePart As String = ""
            Dim strFilePartDesignTableExcel As String = ""
            strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_BH_LUG\Base_BH_Lug_IFL.SLDPRT"
            '24_02_2010 Aruna  single Line Start
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "Base_BH_Lug_IFL"
            strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BASE_BH_LUG_IFL.xls"
            ObjClsWeldedCylinderFunctionalClass.Design_New_Part(strFilePart, strFilePartDesignTableExcel, "NewBHFabrication")
            Dim dblWeight As Double
            Try
                dblWeight = ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Weight")
            Catch ex As Exception
                dblWeight = 0
            End Try

            'Aruna 19_3_2010
            ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_BH_LUG", True)
            Dim blnDuplicateFound As Boolean = False
            If lvwSafetyFactor_Weight.Items.Count > 0 Then
                For Each oItem As ListViewItem In lvwSafetyFactor_Weight.Items
                    If oItem.SubItems(WeightListView.SafetyFactor).Text.Equals(txtSafetyFactor_DesignBH.Text) AndAlso _
                     oItem.SubItems(WeightListView.LugThickness).Text.Equals(txtLugThickness_DesignBH.Text) Then
                        blnDuplicateFound = True
                    End If
                Next
            End If
            If Not blnDuplicateFound Then
                Dim oListViewItem As ListViewItem
                oListViewItem = lvwSafetyFactor_Weight.Items.Add(txtSafetyFactor_DesignBH.Text)
                lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(txtLugThickness_DesignBH.Text)
                lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(dblWeight)
                _intSafetyFactorCount += 1
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in btnGenerate_Click of frmBHFabrication " + ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblDesignNewCasting)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblSafetyFactorIndex)
    End Sub

    Private Sub chkOptimizer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOptimizer.CheckedChanged
        Try
            WidthCalculation()
        Catch ex As Exception

        End Try
    End Sub

    
End Class