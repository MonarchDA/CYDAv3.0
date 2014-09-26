
Imports System.IO
Imports System.Data

Public Class frmDesignACasting_RECT2

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
    Private _dblTempNutSafetyFactor As Double = 0
    Private _dblTempPinHoleSize As Double = 0
    Private _dblTempSwingClearance As Double = 0
    Private _dblWorkingPressure As Double = 0
    Private _intClass As Integer = 0
    Private _dblCrossTubeWidth As Double = 0
    Private _intSafetyFactorCount As Integer = 0
    Private _rodDiameter As Double

#End Region

    '#Region "Properties"

    '    Public ReadOnly Property ControlsData() As ArrayList
    '        Get
    '            ControlsData = New ArrayList
    '            ControlsData.Add(New Object(3) {"GUI", "RW_DESIGN", "O12", ObjClsWeldedCylinderFunctionalClass.ObjFrmRECrossTube._strConfigurationDesign})
    '            ControlsData.Add(New Object(3) {"GUI", "RW_DESIGNTYPE", "O13", ObjClsWeldedCylinderFunctionalClass.ObjFrmRECrossTube._strConfigurationDesignType})
    '            ControlsData.Add(New Object(3) {"GUI", "RW_ROD END CONFIGURATION CODE", "O41", ObjClsWeldedCylinderFunctionalClass.ObjFrmRECrossTube._strConfigurationCode})
    '            ControlsData.Add(New Object(3) {"DB", "RW_SKIM LENGTH", "O48", 0.25})
    '            'RW_ROD LENGTH = Retracted length - distance from rod pinhole to rod stop - distance from base pinhole to rod stop
    '            ControlsData.Add(New Object(3) {"CAL", "RW_ROD LENGTH", "O5", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DistanceFromPinholetoRodStop})
    '            'RW_RODEND PIN HOLE TO ROD STOP DISTANCE
    '            ControlsData.Add(New Object(3) {"DB", "RW_RODEND PIN HOLE TO ROD STOP DISTANCE", "O47", (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DistanceFromPinholetoRodStop) + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop})
    '            Return ControlsData
    '        End Get
    '    End Property

    '#End Region

#Region "enums"

    Public Enum WeightListView
        SafetyFactor = 0
        CrossTubeWidth = 1
        Weight = 2
    End Enum
#End Region

#Region "SubProcedures"

    Private Sub DefaultSettings()

        txtCrossTubeWidth_DesignCrossTubeCasting_RECT.Enabled = True
        txtCrossTubeOD_DesignCrossTubeCasting_RECT.Enabled = False
        txtPinHoleSize_DesignCrossTubeCasting_RECT.Enabled = False
        txtSwingClearance_DesignCrossTubeCasting_RECT.Enabled = False
        btnAccept_RECT.Enabled = False

        SafetyFactor_LugThickness_Weight_GeneretedDesign()

    End Sub
    Public Sub ManualLoad()
        LoadFunctionality()
    End Sub
    Public Sub SafetyFactor_LugThickness_Weight_GeneretedDesign()

        lvwSafetyFactor_Weight_RECT.Clear()
        lvwSafetyFactor_Weight_RECT.Columns.Add("SafetyFactor", 130, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight_RECT.Columns.Add("CrossTubeWidth", 130, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight_RECT.Columns.Add("Weight", 125, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight_RECT.FullRowSelect = True
    End Sub

    Public Sub LoadFunctionality()
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        lvwSafetyFactor_Weight_RECT.Items.Clear()
        _intSafetyFactorCount = 0

        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor <> _dblTempNutSafetyFactor _
       OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd <> _dblTempPinHoleSize _
       OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd <> _dblTempSwingClearance _
       OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure <> _dblWorkingPressure _
       OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass <> _intClass _
       OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter <> _rodDiameter _
        OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd <> _dblCrossTubeWidth Then

            ' ANUP 19-03-2010 11.00
            ' lvwSafetyFactor_Weight_RECT.Items.Clear()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            ' _intSafetyFactorCount = 0
            '***************

            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd _
         (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, _
                     clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube_RodEnd_Casting, "2")      '24_07_2012   RAGAVA

            _dblTempNutSafetyFactor = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor
            _dblTempPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
            _dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
            _dblWorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure
            _intClass = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass
            _dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd
            _rodDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter

            txtCrossTubeOD_DesignCrossTubeCasting_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd
            txtCrossTubeWidth_DesignCrossTubeCasting_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd
            txtPinHoleSize_DesignCrossTubeCasting_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
            txtSwingClearance_DesignCrossTubeCasting_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd

            trbSafetyFactor_RECT.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
            trbSafetyFactor_RECT.Maximum = trbSafetyFactor_RECT.Minimum + 40 'ANUP 09-11-2010 START
            trbSafetyFactor_RECT.TickFrequency = 1
            trbSafetyFactor_RECT.Value = trbSafetyFactor_RECT.Minimum
            txtSafetyFactorOfCasting_RECT.Text = trbSafetyFactor_RECT.Value

            SetSafetyFactor()
        End If

    End Sub

    Private Sub WidthCalculation()
        Dim dblSafetyFactor As Double = trbSafetyFactor_RECT.Minimum + ((trbSafetyFactor_RECT.Value - trbSafetyFactor_RECT.Minimum) * 0.25)
        txtSafetyFactorOfCasting_RECT.Text = dblSafetyFactor
        ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd(dblSafetyFactor, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube_RodEnd_Casting, "2")  '24_07_2012   RAGAVA
        txtCrossTubeOD_DesignCrossTubeCasting_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd2
    End Sub

    Private Function FindSafetyFactor() As Double
        Dim dblPinHoleSize As Double
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity_RodEnd = 0 Then
            dblPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
        Else
            dblPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingOD_RodEnd
        End If
        Dim CrossTubeOD As Double = dblPinHoleSize + (2 * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired_RodEnd)
        Dim dblRequiredArea As Double
        Dim dblReqSF As Double
        If CrossTubeOD < ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd Then
            dblRequiredArea = ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd - dblPinHoleSize) * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd) / ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd
            dblReqSF = dblRequiredArea * ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor
            Return dblReqSF
        End If
        Return 0
    End Function

    Private Sub SetSafetyFactor()

        Dim dblSF As Double = FindSafetyFactor()
        Dim MaxValue As Double = trbSafetyFactor_RECT.Minimum + ((trbSafetyFactor_RECT.Maximum - trbSafetyFactor_RECT.Value) * 0.25) '(trbSafetyFactor_RECT.Maximum - 2) / 4
        If dblSF > MaxValue Then
            dblSF = ObjClsWeldedCylinderFunctionalClass.RoundUp(dblSF, 2)
            Dim strMessage As String = "Safety Factor is : " + dblSF.ToString + " which is above the given range"
            MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            trbSafetyFactor_RECT.Value = ((dblSF - trbSafetyFactor_RECT.Minimum) / 0.25) + trbSafetyFactor_RECT.Minimum
            txtSafetyFactorOfCasting_RECT.Text = trbSafetyFactor_RECT.Minimum + ((trbSafetyFactor_RECT.Value - trbSafetyFactor_RECT.Minimum) * 0.25)
        End If
    End Sub

#End Region

#Region "Events"

    Private Sub frmDesignACasting_RECT_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ColorTheForm()
        DefaultSettings()
        LoadFunctionality()
    End Sub

    Private Sub trbSafetyFactor_RECT_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trbSafetyFactor_RECT.Scroll

        btnAccept_RECT.Enabled = False
        WidthCalculation()
    End Sub

    Private Sub txtCrossTubeWidth_DesignCrossTubeCasting_RECT_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCrossTubeWidth_DesignCrossTubeCasting_RECT.Leave

        If txtCrossTubeWidth_DesignCrossTubeCasting_RECT.Text <> "" Then
            If txtCrossTubeWidth_DesignCrossTubeCasting_RECT.Text <> txtCrossTubeWidth_DesignCrossTubeCasting_RECT.IFLDataTag Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd2 = Val(txtCrossTubeWidth_DesignCrossTubeCasting_RECT.Text)         '25_07_2012   RAGAVA
                txtCrossTubeWidth_DesignCrossTubeCasting_RECT.IFLDataTag = txtCrossTubeWidth_DesignCrossTubeCasting_RECT.Text
                trbSafetyFactor_RECT.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
                trbSafetyFactor_RECT.Maximum = trbSafetyFactor_RECT.Minimum + 40 'ANUP 09-11-2010 START
                trbSafetyFactor_RECT.TickFrequency = 1
                trbSafetyFactor_RECT.Value = trbSafetyFactor_RECT.Minimum
                txtSafetyFactorOfCasting_RECT.Text = trbSafetyFactor_RECT.Value

                btnAccept_RECT.Enabled = False
                ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd _
                 (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, _
                 clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube_RodEnd_Casting, "2")       '24_07_2012   RAGAVA
                txtCrossTubeOD_DesignCrossTubeCasting_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd2
            End If
        Else
            txtCrossTubeWidth_DesignCrossTubeCasting_RECT.IFLDataTag = ""
        End If
    End Sub

    Private Sub btnAccept_RECT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept_RECT.Click
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndDesignSelected2 = True            '24_07_2012   RAGAVA
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = 0.36 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd2 = False        '20_10_2010   RAGAVA
        '26_02_2010 Aruna Start
        If txtSafetyFactorOfCasting_RECT.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_RodEnd2 = txtSafetyFactorOfCasting_RECT.Text
        End If

        If txtCrossTubeWidth_DesignCrossTubeCasting_RECT.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.TxtCrossTubeWidth_RodEnd.Text = txtCrossTubeWidth_DesignCrossTubeCasting_RECT.Text
        End If
        ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd2
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        btnAccept_RECT.Enabled = False
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd2 = "NewDesign"
        '1_03_2010 Aruna
        ObjClsWeldedCylinderFunctionalClass.strManual_Lathe2 = "Lathe"
        '26_02_2010 Aruna Ends

        'If MsgBox("Do you want to Generate Model", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '    ObjClsWeldedCylinderFunctionalClass.generateMainAssembly()
        'End If

        '24-05-2012 MANJULA ADDED
        ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT._dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd2       '24_07_2012   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT2._dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd2       '24_07_2012   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.ObjFrmRECrossTube._dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd2       '24_07_2012   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.ObjFrmRECrossTube2._dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd2       '24_07_2012   RAGAVA
        '**********************
    End Sub


    Private Sub btnGenerate_RECT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate_RECT.Click
        '15_02_2010 Aruna Start
        Me.Cursor = Cursors.WaitCursor
        ObjClsWeldedCylinderFunctionalClass.GenerateCasting = True
        btnAccept_RECT.Enabled = True
        Me.Cursor = Cursors.WaitCursor
        Dim strFilePart As String = ""
        Dim strFilePartDesignTableExcel As String = ""
        Dim strName As String = "NewCrossTubePartCopied"

        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd + 0.5
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = 0.36 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
        '26_02_2010 Akumari
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = 0.5 - 0.06 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd

        '02_03_2010 Aruna
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd2 = "Cast"
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop2 = 0.5 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd2

        '26_02_2010 Aruna Start
        If txtSafetyFactorOfCasting_RECT.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_RodEnd2 = txtSafetyFactorOfCasting_RECT.Text
        End If

        If txtCrossTubeWidth_DesignCrossTubeCasting_RECT.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.TxtCrossTubeWidth_RodEnd.Text = txtCrossTubeWidth_DesignCrossTubeCasting_RECT.Text
        End If
        ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd2

        strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD END CROSS TUBE CASTING\ROD_END_CROSS_TUBE_CASTING.SLDPRT"
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName2 = "ROD_END_CROSS_TUBE_CASTING" '26_02_2010 Aruna

        ObjClsWeldedCylinderFunctionalClass.Design_New_Part(strFilePart, strFilePartDesignTableExcel, "CrossTubeCastRodEnd")
        ObjClsWeldedCylinderFunctionalClass.GenerateCasting = False
        Dim dblWeight As Double = ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Weight")
        'Aruna 19_3_2010
        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD END CROSS TUBE CASTING", True)
        Dim blnDuplicateFound As Boolean = False
        If lvwSafetyFactor_Weight_RECT.Items.Count > 0 Then
            For Each oItem As ListViewItem In lvwSafetyFactor_Weight_RECT.Items
                If oItem.SubItems(WeightListView.SafetyFactor).Text.Equals(txtSafetyFactorOfCasting_RECT.Text) AndAlso _
                 oItem.SubItems(WeightListView.CrossTubeWidth).Text.Equals(txtSafetyFactorOfCasting_RECT.Text) Then
                    blnDuplicateFound = True
                End If
            Next
        End If
        If Not blnDuplicateFound Then
            Dim oListViewItem As ListViewItem
            oListViewItem = lvwSafetyFactor_Weight_RECT.Items.Add(txtSafetyFactorOfCasting_RECT.Text)
            lvwSafetyFactor_Weight_RECT.Items(_intSafetyFactorCount).SubItems.Add(txtCrossTubeWidth_DesignCrossTubeCasting_RECT.Text)
            lvwSafetyFactor_Weight_RECT.Items(_intSafetyFactorCount).SubItems.Add(dblWeight)
            _intSafetyFactorCount += 1
        End If
        Me.Cursor = Cursors.Default
        '15_02_2010 Aruna End
    End Sub

    Private Sub lvwSafetyFactor_Weight_RECT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwSafetyFactor_Weight_RECT.SelectedIndexChanged
        If lvwSafetyFactor_Weight_RECT.SelectedIndices.Count > 0 Then
            Dim oListViewSelectedItem As ListViewItem = lvwSafetyFactor_Weight_RECT.SelectedItems(0)
            trbSafetyFactor_RECT.Value = ((Val(oListViewSelectedItem.SubItems(WeightListView.SafetyFactor).Text) - trbSafetyFactor_RECT.Minimum) / 0.25) + trbSafetyFactor_RECT.Minimum
            txtCrossTubeWidth_DesignCrossTubeCasting_RECT.Text = oListViewSelectedItem.SubItems(WeightListView.CrossTubeWidth).Text
            ObjClsWeldedCylinderFunctionalClass.RodEndWeight = Val(oListViewSelectedItem.SubItems(WeightListView.Weight).Text)
        End If
    End Sub
#End Region

    Private Sub pnlDesignCasting_RECT_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlDesignCasting_RECT.Paint

    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblDesignNewCasting_RECT)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblSafetyFactorIndex_RECT)
    End Sub

End Class