Public Class frmREBHExistingNotSelected

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

    'Private _oMatchedRESingleLugDataTable As DataTable

    Private _dblTempNutSafetyFactor As Double = 0

    Private _dblTempPinHoleSize As Double = 0

    Private _dblTempSwingClearance As Double = 0

    Private _dblWorkingPressure As Double = 0

    Private _intClass As Integer = 0

    Private _dblLugThickness As Double = 0

    Private _intSafetyFactorCount As Integer = 0

    Private _oFabrication_DesignNewBHDataTable As DataTable

    'ANUP 01-03-2010 04.37
    Dim _dblTempRodDiameter As Double

    Dim _dblTempBushingWidth As Double

    Dim _dblTempRequiredLugThickness As Double

    Dim _dblTempRequiredPinHoleSize As Double

    Dim _dblTempBushingQuantity As Double

    Dim _dblTempLugWidth As Double
    '***********************

#End Region

#Region "Properties"

    Public ReadOnly Property ControlsData() As ArrayList
        Get
            ControlsData = New ArrayList

            Return ControlsData
        End Get
    End Property

#End Region

#Region "Enum"

    Public Enum WeightListView
        SafetyFactor = 0
        LugThickness = 1
        Weight = 2
    End Enum

#End Region

#Region "Sub Procedures"

    Public Sub ManualLoad()
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        ' ANUP 19-03-2010 12.31
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter <> _dblTempRodDiameter _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth_RodEnd <> _dblTempBushingWidth _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd <> _dblTempRequiredLugThickness _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd <> _dblTempRequiredPinHoleSize _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd <> _dblTempSwingClearance _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity_RodEnd <> _dblTempBushingQuantity Then
            ' OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd <> _dblTempLugWidth Then
            _dblTempRodDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
            _dblTempBushingWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth_RodEnd
            _dblTempRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
            _dblTempRequiredPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
            _dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
            _dblTempBushingQuantity = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity_RodEnd
            ' _dblTempLugWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd

            lvwSafetyFactor_Weight_RodEnd.Items.Clear()
            _intSafetyFactorCount = 0

            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            InitialSettings_REBHMatchNotFound()
        End If
        '***********************
    End Sub

    'Match Not Found
    Private Sub REBHDetails_MatchNotFound_Functionality()
        REBHMatchNotFoundFunctionality()
    End Sub

    Private Sub InitialSettings_REBHMatchNotFound()
        btnAccept_RodEnd.Enabled = False
        txtSafetyFactor_DesignBH_RodEnd.Enabled = False
        txtLugWidth_DesignBH_RodEnd.Enabled = False
        txtLugThickness_DesignBH_RodEnd.Enabled = True
        txtPinHoleSize_DesignBH_RodEnd.Enabled = False
        txtSwingClearance_DesignBH_RodEnd.Enabled = False
        SafetyFactor_LugThickness_Weight_GeneretedDesign()

        ' grbNotExactMatch_RodEnd.Enabled = False '5_3_2010 Aruna
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False

    End Sub

    Private Sub SafetyFactor_LugThickness_Weight_GeneretedDesign()
        lvwSafetyFactor_Weight_RodEnd.Clear()
        lvwSafetyFactor_Weight_RodEnd.Columns.Add("SafetyFactor", 130, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight_RodEnd.Columns.Add("LugThickness", 130, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight_RodEnd.Columns.Add("Weight", 125, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight_RodEnd.FullRowSelect = True
    End Sub

    Private Sub REBHMatchNotFoundFunctionality()
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor <> _dblTempNutSafetyFactor _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize <> _dblTempPinHoleSize _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance <> _dblTempSwingClearance _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure <> _dblWorkingPressure _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass <> _intClass _
         OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness <> _dblLugThickness Then
            _dblTempNutSafetyFactor = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor
            _dblTempPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd

            'ANUP 17-09-2010 START
            '_dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
            _dblTempSwingClearance = Val(ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Text)
            'ANUP 17-09-2010 TILL HERE

            _dblWorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure
            _intClass = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass
            _dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd

            ' ANUP 19-03-2010 11.00
            lvwSafetyFactor_Weight_RodEnd.Items.Clear()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            _intSafetyFactorCount = 0
            '***************

            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd _
         (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, _
                     clsWeldedCylinderFunctionalClass.YeildStrengthConstants.SingleLug_Cast_NoPort)
            txtLugWidth_DesignBH_RodEnd.Text = Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd, 3)
            txtLugThickness_DesignBH_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
            txtPinHoleSize_DesignBH_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd

            'ANUP 17-09-2010 START
            'txtSwingClearance_DesignSingleLug_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
            txtSwingClearance_DesignBH_RodEnd.Text = Val(ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Text)
            'ANUP 17-09-2010 TILL HERE

            trbSafetyFactor_RodEnd.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
            trbSafetyFactor_RodEnd.Maximum = trbSafetyFactor_RodEnd.Minimum + 20
            trbSafetyFactor_RodEnd.TickFrequency = 1
            trbSafetyFactor_RodEnd.Value = trbSafetyFactor_RodEnd.Minimum
            'TODO:Sunny 26-02-10
            Dim dblSafetyFactor As Double = trbSafetyFactor_RodEnd.Minimum + ((trbSafetyFactor_RodEnd.Value - trbSafetyFactor_RodEnd.Minimum) * 0.25)
            txtSafetyFactor_DesignBH_RodEnd.Text = dblSafetyFactor

        End If
    End Sub

    Private Sub WidthCalculation()
        Dim dblSafetyFactor As Double = trbSafetyFactor_RodEnd.Minimum + ((trbSafetyFactor_RodEnd.Value - trbSafetyFactor_RodEnd.Minimum) * 0.25)
        txtSafetyFactor_DesignBH_RodEnd.Text = dblSafetyFactor
        ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd(dblSafetyFactor, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.SingleLug_Cast_NoPort)           '11-12-2009  Ragava
        txtLugWidth_DesignBH_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd
    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, lblBHHeading, LabelGradient4, LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(LabelGradient5)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient1)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblDesignNewCasting)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblSafetyFactorIndex)
    End Sub

#End Region

#Region "Events"

    Private Sub frmREBHDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        ColorTheForm()
        REBHDetails_MatchNotFound_Functionality()
        InitialSettings_REBHMatchNotFound()
    End Sub

    Private Sub btnGenerate_RodEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate_RodEnd.Click
        Me.Cursor = Cursors.WaitCursor

        'ANUP 17-09-2010 START
        If ObjClsWeldedCylinderFunctionalClass.SwingClearanceValidation_PartCondition_RodEnd Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd = Val(ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Text) + 0.0625
        End If
        'ANUP 17-09-2010 TILL HERE

        Dim blnDuplicateFound As Boolean = False
        Try

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Cast"

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = _
                       ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd + 0.5 'TODO: ANUP 01-06-2010  10.51am

            If txtSafetyFactor_DesignBH_RodEnd.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_RodEnd = txtSafetyFactor_DesignBH_RodEnd.Text
            End If

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd <> 0 Then
                ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
            End If
            Dim dblLugHeight As Double
            dblLugHeight = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd + (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd / 2)
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.lugHeight_RodEnd = dblLugHeight
            Dim strFilePart As String = ""
            Dim strFilePartDesignTableExcel As String = ""
            Dim strName As String = "NewBHRodEndNewDesignPart"

            ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_END_BH_CAST")
            strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_END_BH_CAST\ROD_END_BH_CAST.SLDPRT"
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "ROD_END_BH_CAST"
            strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\ROD_END_BH_CAST.XLS"

            ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_END_BH_CAST", True)
            ObjClsWeldedCylinderFunctionalClass.Design_New_Part(strFilePart, strFilePartDesignTableExcel, strName)
            ObjClsWeldedCylinderFunctionalClass.GenerateCasting = False '20_11_2009  Ragava
            Dim dblWeight As Double = ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Weight")

            If lvwSafetyFactor_Weight_RodEnd.Items.Count > 0 Then
                For Each oItem As ListViewItem In lvwSafetyFactor_Weight_RodEnd.Items
                    If oItem.SubItems(WeightListView.SafetyFactor).Text.Equals(txtSafetyFactor_DesignBH_RodEnd.Text) AndAlso _
                     oItem.SubItems(WeightListView.LugThickness).Text.Equals(txtLugThickness_DesignBH_RodEnd.Text) Then
                        blnDuplicateFound = True
                    End If
                Next
            End If
            If Not blnDuplicateFound Then
                Dim oListViewItem As ListViewItem
                oListViewItem = lvwSafetyFactor_Weight_RodEnd.Items.Add(txtSafetyFactor_DesignBH_RodEnd.Text)
                lvwSafetyFactor_Weight_RodEnd.Items(_intSafetyFactorCount).SubItems.Add(txtLugThickness_DesignBH_RodEnd.Text)
                lvwSafetyFactor_Weight_RodEnd.Items(_intSafetyFactorCount).SubItems.Add(dblWeight)
                _intSafetyFactorCount += 1
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub trbSafetyFactor_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trbSafetyFactor_RodEnd.Scroll
        For Each oItem As ListViewItem In lvwSafetyFactor_Weight_RodEnd.Items
            oItem.Selected = False
        Next
    End Sub

    Private Sub trbSafetyFactor_RodEnd_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trbSafetyFactor_RodEnd.ValueChanged
        WidthCalculation()
    End Sub

    Private Sub txtLugThickness_DesignBH_RodEnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLugThickness_DesignBH_RodEnd.Leave
        If txtLugThickness_DesignBH_RodEnd.Text <> "" Then
            If txtLugThickness_DesignBH_RodEnd.Text <> txtLugThickness_DesignBH_RodEnd.IFLDataTag Then
                txtLugThickness_DesignBH_RodEnd.IFLDataTag = txtLugThickness_DesignBH_RodEnd.Text
                trbSafetyFactor_RodEnd.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
                trbSafetyFactor_RodEnd.Maximum = trbSafetyFactor_RodEnd.Minimum + 20
                trbSafetyFactor_RodEnd.TickFrequency = 1
                trbSafetyFactor_RodEnd.Value = trbSafetyFactor_RodEnd.Minimum
                Dim dblSafetyFactor As Double = trbSafetyFactor_RodEnd.Minimum + ((trbSafetyFactor_RodEnd.Value - trbSafetyFactor_RodEnd.Minimum) * 0.25)
                txtSafetyFactor_DesignBH_RodEnd.Text = dblSafetyFactor
            End If
        Else
            txtLugThickness_DesignBH_RodEnd.IFLDataTag = ""
        End If
    End Sub

    Private Sub btnAccept_RodEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept_RodEnd.Click
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = 0.36 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd / 2

        If txtSafetyFactor_DesignBH_RodEnd.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_RodEnd = txtSafetyFactor_DesignBH_RodEnd.Text
        End If

        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd <> 0 Then
            ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
        End If
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = False        '20_10_2010   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        btnAccept_RodEnd.Enabled = False
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Cast"
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "NewDesign"
        '5_3_2010 Aruna
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnd_NewDesign_TableName = "WELDED.RodEndBH"
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Cast"
        '25_02_2010 Aruna
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Fabricated"
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Cast"         '05_03_2010    RAGAVA
        ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Cast"
    End Sub

    Private Sub lvwSafetyFactor_Weight_RodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwSafetyFactor_Weight_RodEnd.SelectedIndexChanged
        If lvwSafetyFactor_Weight_RodEnd.SelectedIndices.Count > 0 Then
            Dim oListViewSelectedItem As ListViewItem = lvwSafetyFactor_Weight_RodEnd.SelectedItems(0)
            trbSafetyFactor_RodEnd.Value = ((Val(oListViewSelectedItem.SubItems(WeightListView.SafetyFactor).Text) - trbSafetyFactor_RodEnd.Minimum) / 0.25) + trbSafetyFactor_RodEnd.Minimum
            txtLugThickness_DesignBH_RodEnd.Text = oListViewSelectedItem.SubItems(WeightListView.LugThickness).Text
            btnAccept_RodEnd.Enabled = True
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            ObjClsWeldedCylinderFunctionalClass.RodEndWeight = Val(oListViewSelectedItem.SubItems(WeightListView.Weight).Text)
        End If
    End Sub


#End Region

End Class