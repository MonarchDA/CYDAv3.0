Public Class frmFabricatedSingleLug_RetractedLength2

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

    Public _intSafetyFactorCount As Integer = 0

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
            txtSafetyFactor_DesignSingleLug.Text = dblSafetyFactor
            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation(dblSafetyFactor, Me.chkOptimizer.Checked, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.SingleLug, "2")  '30_05_2012  RAGAVA     '12_11_2009   Ragava
            txtLugWidth_DesignSingleLug.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ValidLugThickness()
        Try
            Dim ObjDt As DataTable
            Dim dblMaxLugThickness As Double = 0
            Dim dblLugThickNess As Double = Val(txtLugThickness_DesignSingleLug.Text)

            Try
                Dim oDesignSingleLugDataTable As DataTable
                oDesignSingleLugDataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetTableDetails("Select * from Welded.DesignULugValidDetails")

                If Not IsNothing(oDesignSingleLugDataTable) Then
                    For Each dr As DataRow In oDesignSingleLugDataTable.Rows
                        If dblMaxLugThickness < dr("ULugThickness") Then
                            dblMaxLugThickness = dr("ULugThickness")
                        End If
                    Next
                End If
            Catch ex As Exception
            End Try

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" Then
                dblMaxLugThickness = 2
            End If

            If dblMaxLugThickness < dblLugThickNess Then
                MessageBox.Show("No Material Available After LugThickness 2 ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                txtLugThickness_DesignSingleLug.Text = dblMaxLugThickness.ToString
            Else
                ObjDt = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetTableDetails("Select top 1 * from Welded.DesignULugValidDetails Where ULugThickness >= " + dblLugThickNess.ToString)
                ObjClsWeldedCylinderFunctionalClass.BendRadius = ObjDt.Rows(0)("BendRadius")
                txtLugThickness_DesignSingleLug.Text = ObjDt.Rows(0)("ULugThickness")
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in ValidLugThickness of frmSLFabrication " + ex.Message)
        End Try
        '13_11_2009 Ragava Till Here
    End Sub

    Private Sub DefaultSettings()
        txtSafetyFactor_DesignSingleLug.Enabled = False
        txtLugThickness_DesignSingleLug.Enabled = True
        txtLugWidth_DesignSingleLug.Enabled = False
        txtPinHoleSize_DesignSingleLug.Enabled = False
        txtSwingClearance_DesignSingleLug.Enabled = False

        btnAccept.Enabled = False

        lvwSafetyFactor_Weight.Clear()
        lvwSafetyFactor_Weight.Columns.Add("SafetyFactor", 130, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight.Columns.Add("LugThickness", 130, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight.Columns.Add("Weight", 125, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight.FullRowSelect = True

        ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation _
       (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, Me.chkOptimizer.Checked, _
                   clsWeldedCylinderFunctionalClass.YeildStrengthConstants.SingleLug, "2")  '30_05_2012  RAGAVA
        Dim GetLugWidthDataValue As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetLugWidthForComparision(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth)
        txtLugWidth_DesignSingleLug.Text = GetLugWidthDataValue
        txtLugThickness_DesignSingleLug.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness

        txtPinHoleSize_DesignSingleLug.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
        txtSwingClearance_DesignSingleLug.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance



        trbSafetyFactor.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
        trbSafetyFactor.Maximum = trbSafetyFactor.Minimum + 20
        trbSafetyFactor.TickFrequency = 1
        trbSafetyFactor.Value = trbSafetyFactor.Minimum
        Dim dblSafetyFactor As Double = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
        txtSafetyFactor_DesignSingleLug.Text = dblSafetyFactor

        btnClose.Enabled = False
    End Sub

#End Region

#Region "Events"

    Private Sub frmFabricatedSingleLug_RetractedLength_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub txtLugThickness_DesignULug_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLugThickness_DesignSingleLug.Leave
        If txtLugThickness_DesignSingleLug.Text <> "" Then
            If txtLugThickness_DesignSingleLug.Text <> txtLugThickness_DesignSingleLug.IFLDataTag Then
                txtLugThickness_DesignSingleLug.IFLDataTag = txtLugThickness_DesignSingleLug.Text

                ValidLugThickness() '13_11_2009  Ragava

                trbSafetyFactor.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
                trbSafetyFactor.Maximum = trbSafetyFactor.Minimum + 20
                trbSafetyFactor.TickFrequency = 1
                trbSafetyFactor.Value = trbSafetyFactor.Minimum
                Dim dblSafetyFactor As Double = trbSafetyFactor.Minimum + ((trbSafetyFactor.Value - trbSafetyFactor.Minimum) * 0.25)
                txtSafetyFactor_DesignSingleLug.Text = dblSafetyFactor
            End If
        Else
            txtLugThickness_DesignSingleLug.IFLDataTag = ""
        End If
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        Try
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnNewFabricationGenerated = True             '17_10_2012   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndFabrication_New = True       '15_03_2012   RAGAVA
            If txtSafetyFactor_DesignSingleLug.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd = txtSafetyFactor_DesignSingleLug.Text
            End If
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnFabricated2SingleLug = True   '05_01_2012  RAGAVA
            If txtLugThickness_DesignSingleLug.Text <> "" Then
                'ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd.Text = txtLugThickness_DesignSingleLug.Text        '30_05_2012  RAGAVA
            End If
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True          '10_01_2012   RAGAVA
            btnAccept.Enabled = False

            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" Then
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication"                'Check
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness_DesignSingleLug.Text)              'Check
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance = Val(txtSwingClearance_DesignSingleLug.Text)          'Check
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugWidth_DesignSingleLug.Text)                      'Check
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated"         'Check
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEULDETAILS"    'Check
            'End If
            'Check
            ''14_03_2012  RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" Then
                '30_05_2012   RAGAVA
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication"
                '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated"
                '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISFabricationChecked = True
                '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True
                '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = False
                '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "NewDesign"
                '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness_DesignSingleLug.Text)
                '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance = Val(txtSwingClearance_DesignSingleLug.Text)
                '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugWidth_DesignSingleLug.Text)
                '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BESingleLugDetails"
                'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign2 = "NewDesign"
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2 = "Fabricated"
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BESingleLugDetails"
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2 = Val(txtLugThickness_DesignSingleLug.Text)
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2 = Val(txtSwingClearance_DesignSingleLug.Text)
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2 = Val(txtLugWidth_DesignSingleLug.Text)
                'End If
                'Till   Here
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationTable = "Welded.BESingleLugDetails"      '15_05_2012   RAGAVA
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart = "Base_Single_Lug_IFL"        '15_05_2012   RAGAVA
            End If
            btnClose.Enabled = True
        Catch ex As Exception

        End Try

        'Try
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndFabrication_New = True       '15_03_2012   RAGAVA
        '    If txtSafetyFactor_DesignSingleLug.Text <> "" Then
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd = txtSafetyFactor_DesignSingleLug.Text
        '    End If
        '    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnFabricated2SingleLug = True   '05_01_2012  RAGAVA
        '    If txtLugThickness_DesignSingleLug.Text <> "" Then
        '        ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd.Text = txtLugThickness_DesignSingleLug.Text
        '    End If
        '    ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True          '10_01_2012   RAGAVA
        '    btnAccept.Enabled = False

        '    ''14_03_2012  RAGAVA
        '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated"
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISFabricationChecked = True
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = False
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "NewDesign"
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = Val(txtLugThickness_DesignSingleLug.Text)
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BESingleLugDetails"
        '    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign2 = "NewDesign"
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2 = "Fabricated"
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BESingleLugDetails"
        '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2 = Val(txtLugThickness_DesignSingleLug.Text)
        '    End If
        '    btnClose.Enabled = True
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub lvwSafetyFactor_Weight_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwSafetyFactor_Weight.SelectedIndexChanged
        If lvwSafetyFactor_Weight.SelectedIndices.Count > 0 Then
            Dim oListViewSelectedItem As ListViewItem = lvwSafetyFactor_Weight.SelectedItems(0)
            trbSafetyFactor.Value = ((Val(oListViewSelectedItem.SubItems(WeightListView.SafetyFactor).Text) - trbSafetyFactor.Minimum) / 0.25) + trbSafetyFactor.Minimum
            txtLugThickness_DesignSingleLug.Text = oListViewSelectedItem.SubItems(WeightListView.LugThickness).Text
            btnAccept.Enabled = True
            btnClose.Enabled = False
            ObjClsWeldedCylinderFunctionalClass.BaseEndWeight = Val(oListViewSelectedItem.SubItems(WeightListView.Weight).Text)
        End If
    End Sub

    Private Sub txtLugWidth_DesignSingleLug_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLugWidth_DesignSingleLug.TextChanged
        If txtLugWidth_DesignSingleLug.Text <> "" Then
            If txtLugWidth_DesignSingleLug.Text <> txtLugWidth_DesignSingleLug.IFLDataTag Then
                txtLugWidth_DesignSingleLug.IFLDataTag = txtLugWidth_DesignSingleLug.Text
                Try
                    Dim ObjDt As DataTable
                    Dim dblLugWidth As Double = Val(txtLugWidth_DesignSingleLug.Text)
                    Dim dblMaxLugWidth As Double = 0

                    Try
                        Dim oDesignSingleLugDataTable As DataTable  '13_11_2009   Ragava
                        oDesignSingleLugDataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetTableDetails("Select * from Welded.DesignULugValidDetails")

                        If Not IsNothing(oDesignSingleLugDataTable) Then
                            For Each dr As DataRow In oDesignSingleLugDataTable.Rows
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
                        txtSafetyFactor_DesignSingleLug.Text = dblSafetyFactor
                    Else
                        ObjDt = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetTableDetails("Select top 1 * from Welded.DesignULugValidDetails Where ULugWidth >= " + dblLugWidth.ToString)
                        ObjClsWeldedCylinderFunctionalClass.TopRadius = ObjDt.Rows(0)("TopRadius")
                        txtLugWidth_DesignSingleLug.Text = ObjDt.Rows(0)("ULugWidth")
                        '30_05_2012  RAGAVA
                        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabricated" Then
                        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugWidth_DesignSingleLug.Text)
                        'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2 = Val(txtLugWidth_DesignSingleLug.Text)
                        'End If
                        'Till   Here
                    End If
                Catch oException As Exception
                    ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in txtLugWidth_DesignSingleLug_TextChanged of frmSLFabrication " + oException.Message)
                End Try
            End If
        Else
            txtLugWidth_DesignSingleLug.IFLDataTag = ""
        End If
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            '20_06_2012   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop2 = -0.125
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop2 = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5

            If txtSafetyFactor_DesignSingleLug.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd = txtSafetyFactor_DesignSingleLug.Text
            End If

            If txtLugThickness_DesignSingleLug.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd.Text = txtLugThickness_DesignSingleLug.Text     '06_06_2012   RAGAVA
            End If
            If txtLugWidth_DesignSingleLug.Text <> "" Then
                '30_05_2012  RAGAVA
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabricated" Then
                '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth = Val(txtLugWidth_DesignSingleLug.Text)
                'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2 = Val(txtLugWidth_DesignSingleLug.Text)
                'End If
                'Till   Here
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2 = Val(txtSwingClearance_DesignSingleLug.Text)      '30_05_2012   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness2 = Val(txtLugThickness_DesignSingleLug.Text)      '30_05_2012   RAGAVA
            '02_03_2010 Aruna
            Dim dblLugHeight As Double
            dblLugHeight = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance2 + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth2 / 2)  '30_05_2012  RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.lugHeight_BaseEnd = dblLugHeight


            '20_01_2012   RAGAVA
            Try
                If ObjClsWeldedCylinderFunctionalClass.WeldSize_Validation_SL_BaseEnd() Then
                    Exit Sub
                End If
            Catch ex As Exception
            End Try
            'Till    Here

            Dim strFilePart As String = ""
            Dim strFilePartDesignTableExcel As String = ""
            strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_SINGLE_LUG\Base_Single_Lug_IFL.SLDPRT"
            '30_05_2012  RAGAVA
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "Base_Single_Lug_IFL"
            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = "Base_Single_Lug_IFL"
            'End If
            'Till  Here
            strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BASE_SINGLE_LUG.xls"
            ObjClsWeldedCylinderFunctionalClass.Design_New_Part(strFilePart, strFilePartDesignTableExcel, "NewSingleLugFabrication")
            Dim dblWeight As Double
            Try
                dblWeight = ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Weight")
            Catch ex As Exception
                dblWeight = 0
            End Try

            'Aruna 19_3_2010
            ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_SINGLE_LUG", True)
            Dim blnDuplicateFound As Boolean = False
            If lvwSafetyFactor_Weight.Items.Count > 0 Then
                For Each oItem As ListViewItem In lvwSafetyFactor_Weight.Items
                    If oItem.SubItems(WeightListView.SafetyFactor).Text.Equals(txtSafetyFactor_DesignSingleLug.Text) AndAlso _
                     oItem.SubItems(WeightListView.LugThickness).Text.Equals(txtLugThickness_DesignSingleLug.Text) Then
                        blnDuplicateFound = True
                    End If
                Next
            End If
            If Not blnDuplicateFound Then
                Dim oListViewItem As ListViewItem
                oListViewItem = lvwSafetyFactor_Weight.Items.Add(txtSafetyFactor_DesignSingleLug.Text)
                lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(txtLugThickness_DesignSingleLug.Text)
                lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(dblWeight)
                _intSafetyFactorCount += 1
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in btnGenerate_Click of frmSLFabrication " + ex.Message)
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