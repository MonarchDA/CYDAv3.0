Imports IFLBaseDataLayer.IFLConnectionClass
Imports IFLCommonLayer
Imports IFLCustomUILayer

Public Class frmPrimaryInputs

#Region "Variables"

    Private _aPistonListView As ArrayList

    Private _dblTempMaxNutThickness As Double

    'TODO: ANUP 22-07-2010 12.14pm
    Private _blnIsPopulated As Boolean = False


    Private _strRodMaterialCode As String = Nothing

#End Region

#Region "Properties"

    Private ReadOnly Property StopTubeOD() As ArrayList
        Get
            StopTubeOD = New ArrayList
            StopTubeOD.Add(New Object(1) {0.5, 0.88})
            StopTubeOD.Add(New Object(1) {0.75, 1.13})
            StopTubeOD.Add(New Object(1) {0.88, 1.26})
            StopTubeOD.Add(New Object(1) {1.0, 1.38})
            StopTubeOD.Add(New Object(1) {1.13, 1.5})
            StopTubeOD.Add(New Object(1) {1.25, 1.75})
            StopTubeOD.Add(New Object(1) {1.38, 1.88})
            StopTubeOD.Add(New Object(1) {1.5, 2.0})
            StopTubeOD.Add(New Object(1) {1.75, 2.25})
            StopTubeOD.Add(New Object(1) {2.0, 2.5})
            StopTubeOD.Add(New Object(1) {2.5, 3.0})
            Return StopTubeOD
        End Get
    End Property

    Public ReadOnly Property ControlsData() As ArrayList
        Get
            ControlsData = New ArrayList
            ControlsData.Add(New Object(3) {"txtStrokeLength", "StrokeLength", "C3", txtStrokeLength.Text})
            ControlsData.Add(New Object(3) {"txtRetractedLength", "RetractedLength", "C4", txtRetractedLength.Text})
            ControlsData.Add(New Object(3) {"txtWorkingPressure", "WorkingPressure", "C5", txtWorkingPressure.Text})
            ControlsData.Add(New Object(3) {"cmbRodMaterial", "RodMaterial", "C6", cmbRodMaterial.Text})
            ControlsData.Add(New Object(3) {"cmbClass", "Class", "C7", cmbClass.Text})
            ControlsData.Add(New Object(3) {"txtNutSafetyFactor", "NutSafetyFactor", "C8", txtNutSafetyFactor.Text})
            ControlsData.Add(New Object(3) {"txtRodMaterialYield", "RodMaterialYield", "C9", txtRodMaterialYield.Text})
            ControlsData.Add(New Object(3) {"cmbBoreDiameters", "BoreDiameter", "C10", cmbBoreDiameters.Text})
            ControlsData.Add(New Object(3) {"txtStopTubeRequired", "StopTubeLength", "C11", txtStopTubeRequired.Text})
            ControlsData.Add(New Object(3) {"txtStandardRunQuantity", "StandardRunQuantity", "C12", txtStandardRunQuantity.Text})
            ControlsData.Add(New Object(3) {"txtRecommendedStopTubeLength", "RecommendedStopTubeLength", "C13", txtRecommendedStopTubeLength.Text})
            ControlsData.Add(New Object(3) {"cmbPistonConnection", "PistonConnection", "C14", cmbPistonConnection.Text})
            ControlsData.Add(New Object(3) {"cmbPistonShankSeal", "PistonShankSeal", "C15", cmbPistonShankSeal.Text})
            ControlsData.Add(New Object(3) {"PistonNutMaxThickness", "PistonNutMaxThickness", "C16", _dblTempMaxNutThickness})
            ControlsData.Add(New Object(3) {"Rod Diameter", "Rod Diameter", "C17", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter})
            ControlsData.Add(New Object(3) {"DB", "PI_Piston Nut Size", "F30", Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInDecimals, 2)})
            ControlsData.Add(New Object(3) {"GUI", "Rephasing", "R22", Me.cmbRephasing.Text})         '22_12_2010   RAGAVA
            Try
                ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.RodLEngthCalculation()             '21_10_2010     RAGAVA
            Catch ex As Exception
            End Try
            'Sunny 09-08-10-3pm
            clsAddExistingCodes.AddRodMaterialCode(_strRodMaterialCode, clsAddExistingCodes.RodWeight(), "LB") 'Costing 03-08-10
            Return ControlsData
        End Get
    End Property

    Public Property IsPopulated() As Boolean
        Get
            Return _blnIsPopulated
        End Get
        Set(ByVal value As Boolean)
            _blnIsPopulated = value
        End Set
    End Property

#End Region

#Region "Enums"

    Private Enum BoreDiameters
        RodDiameter = 0
        NutSize = 1
    End Enum

    Private Enum NutSizes
        NutSize = 0
        ThreadTensileArea = 1
    End Enum

    Private Enum PressureListViewItems
        RodDiameter = 0
        NutSize = 1
        'Max_Pressure = 2
        Derate_Pressure = 2
    End Enum

    Private Enum PistonListView
        NutSize = 0
        MaxPressure = 1
    End Enum

    Private Enum PistonArrayListItems
        RodDiameter = 0
        NutSize = 1
        Area_at_Root_of_Thread = 2
    End Enum

    Private Enum EStopTubeOD
        RodDiameter = 0
        StopTubeOD = 1
    End Enum

#End Region

#Region "Sub Procedures"

    Private Sub DefaultSettings()
        Try
            LoadBoreDiameter()

            txtWorkingPressure.Text = 3000

            LoadClass()

            cmbRodMaterial.Items.Add("Chrome")
            cmbRodMaterial.Items.Add("Nitro Steel")
            cmbRodMaterial.Items.Add("Induction Hardened")
            cmbRodMaterial.Items.Add("LION 1000")     '16_08_2010    RAGAVA
            cmbRodMaterial.SelectedIndex = 0

            txtRodMaterialYield.Enabled = False
            txtRodMaterialYield.BackColor = Color.Empty
            chkStopTube.Checked = True 'ANUP 25-06-2010
            chkStopTube.Checked = False
            txtRecommendedStopTubeLength.Enabled = False
            txtRecommendedStopTubeLength.BackColor = Color.Empty
            txtStandardRunQuantity.Text = 25      '11_10_2010   RAGAVA   '100
            ObjClsWeldedCylinderFunctionalClass.TxtRetractedLength = txtRetractedLength
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.New_Revision <> "Revision'" Then    '22_12_2010   RAGAVA
                chkRephasing.Visible = True        '22_12_2010   RAGAVA
                cmbRephasing.Visible = False       '22_12_2010   RAGAVA
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, LabelGradient5, LabelGradient4, LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblPrimaryInputs)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblPressureSelection)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(LabelGradient6)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblPrimaryInputsSet1)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblNutSelection)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblPistonConnectionIndex)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient1)
    End Sub

    Public Sub ManualLoad()
        'TODO: ANUP 28-05-2010 12.20pm
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CustomerNameComboBOxChanged = True Then
            DefaultSettings()
            ObjClsWeldedCylinderFunctionalClass.AddColors(Me)
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CustomerNameComboBOxChanged = False
        End If
        '***************
        '11_10_2010   RAGAVA
        Try
            If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) = "" Then
                Dim _strQuery As String = String.Empty
                _strQuery = "Select top 1 CodeNumber from MIL.dbo.CodeNumberDetails"
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart = MonarchConnectionObject.GetValue(_strQuery)
            End If
        Catch ex As Exception
        End Try

        'ANUP 01-11-2010 START
        CylinderReleasedFunctionality()
        'ANUP 01-11-2010 TILL HERE


    End Sub

    Private Sub LoadBoreDiameter()
        For dblBoreDiameter As Double = 1.25 To 6 Step 0.25
            If ChkASAE.Checked = True AndAlso (dblBoreDiameter < 2.5) Then
                Continue For
            End If
            'If dblBoreDiameter <> 4.25 AndAlso dblBoreDiameter <> 4.75 AndAlso dblBoreDiameter <> 5.25 AndAlso dblBoreDiameter <> 5.75 Then    '27_02_2012   RAGAVA
            If dblBoreDiameter > 5 AndAlso chkRephasing.Checked = True Then
                Continue For
            End If
            cmbBoreDiameters.Items.Add(dblBoreDiameter)
            'End If
        Next
        cmbBoreDiameters.SelectedIndex = 0
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = Val(cmbBoreDiameters.Text)
        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Bore Diameter", cmbBoreDiameters.Text)
    End Sub

    Private Sub LoadClass()
        Try
            Dim oClassTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetClass()
            If Not IsNothing(oClassTable) Then
                cmbClass.Items.Clear()
                For Each oClassDataRow As DataRow In oClassTable.Rows
                    If Not IsDBNull(oClassDataRow("LifeCycleClass")) Then
                        cmbClass.Items.Add(oClassDataRow("LifeCycleClass"))
                    End If
                Next
                cmbClass.SelectedIndex = 1
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured while populating cmbClass in frmPrimaryInputs " + ex.Message)
        End Try
    End Sub

    Private Sub LoadNutSafetyFactor()
        Try
            Dim oClassDetailsRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.NutSafetyFactor(cmbClass.Text)
            If Not IsNothing(oClassDetailsRow) Then
                If Not IsDBNull(oClassDetailsRow("NutSafetyFactor")) Then
                    txtNutSafetyFactor.Text = Val(oClassDetailsRow("NutSafetyFactor"))
                    txtNutSafetyFactor.Enabled = False
                    txtNutSafetyFactor.BackColor = Color.Empty
                End If
                If Not IsDBNull(oClassDetailsRow("EndConditionSafetyFactor")) Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor = oClassDetailsRow("EndConditionSafetyFactor")
                End If
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured while populating txtNutSafetyFactor in frmPrimaryInputs " + ex.Message)
        End Try
    End Sub

    Private Sub PopulatePressureListView()
        Try
            'If lvwPressureSelection.Items.Count >= 1 Then
            '    lvwPressureSelection.Items(0).Selected = True
            '    lvwPressureSelection.Items(0).Selected = False
            'End If
            lvwPressureSelection.Items.Clear()
            lvwPressureSelection.Columns.Clear()

            lvwPressureSelection.Columns.Add("Rod Diameter", 105, HorizontalAlignment.Center)
            lvwPressureSelection.Columns.Add("Max Nut Size", 113, HorizontalAlignment.Center)
            ' lvwPressureSelection.Columns.Add("Max Pressure at Max Nut Size", 160, HorizontalAlignment.Center)
            lvwPressureSelection.Columns.Add("Derate Pressure at Max Extension", 180, HorizontalAlignment.Center)

            If cmbBoreDiameters.Text <> "" AndAlso txtNutSafetyFactor.Text <> "" AndAlso txtRodMaterialYield.Text <> "" _
            AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength.ToString <> "" AndAlso txtRetractedLength.Text <> "" Then
                Dim dblPistonNutSize_Bore As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPistonNutSize_Bore(cmbBoreDiameters.Text)
                _aPistonListView = New ArrayList
                If dblPistonNutSize_Bore <> 0 Then

                    Dim oRodDiameters As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetRodDiameters(cmbBoreDiameters.Text)
                    If Not IsNothing(oRodDiameters) Then

                        Dim oPressureListViewItem As ListViewItem
                        Dim intCount As Integer = 0
                        Dim dblPistonNutSizeInDecimals As Double = 0
                        Dim strPistonNutSizeInFractions As String = ""




                        Dim oNutSizeTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetThreadTensileArea
                        If Not IsNothing(oNutSizeTable) Then
                            For Each oRodDiameterRow As DataRow In oRodDiameters.Rows
                                If Not IsDBNull(oRodDiameterRow(BoreDiameters.RodDiameter)) Then
                                    oPressureListViewItem = lvwPressureSelection.Items.Add(oRodDiameterRow(BoreDiameters.RodDiameter))
                                End If
                                If Not IsDBNull(oRodDiameterRow(BoreDiameters.NutSize)) Then
                                    If Val(oRodDiameterRow(BoreDiameters.NutSize)) <= dblPistonNutSize_Bore Then
                                        For Each oNutSizes As Object In ObjClsWeldedCylinderFunctionalClass.NutSizesInFractions
                                            If Val(oNutSizes(1)) = Val(oRodDiameterRow(BoreDiameters.NutSize)) Then
                                                dblPistonNutSizeInDecimals = oNutSizes(1)
                                                strPistonNutSizeInFractions = oNutSizes(0)
                                                Exit For
                                            End If
                                        Next
                                        lvwPressureSelection.Items(intCount).SubItems.Add(strPistonNutSizeInFractions)
                                        'lvwPressureSelection.Items(intCount).SubItems.Add(oRodDiameterRow(BoreDiameters.NutSize))
                                    Else
                                        For Each oNutSizes As Object In ObjClsWeldedCylinderFunctionalClass.NutSizesInFractions
                                            If Val(oNutSizes(1)) = Val(dblPistonNutSize_Bore) Then
                                                dblPistonNutSizeInDecimals = oNutSizes(1)
                                                strPistonNutSizeInFractions = oNutSizes(0)
                                                Exit For
                                            End If
                                        Next
                                        lvwPressureSelection.Items(intCount).SubItems.Add(strPistonNutSizeInFractions)
                                        ' lvwPressureSelection.Items(intCount).SubItems.Add(dblPistonNutSize_Bore)
                                    End If
                                End If
                                'Get Area_at_Root_of_Thread from db for calculating Max_Pressure_at_Max_Nut_Size
                                Dim dblArea_at_Root_of_Thread As Double
                                For Each oNutSizes As Object In ObjClsWeldedCylinderFunctionalClass.NutSizesInFractions
                                    If oNutSizes(0) = lvwPressureSelection.Items(intCount).SubItems(PressureListViewItems.NutSize).Text Then
                                        dblPistonNutSizeInDecimals = oNutSizes(1)
                                        strPistonNutSizeInFractions = oNutSizes(0)
                                        Exit For
                                    End If
                                Next

                                For Each oNutSizeRow As DataRow In oNutSizeTable.Rows
                                    If Not IsDBNull(oNutSizeRow(NutSizes.NutSize)) Then
                                        If Val(oNutSizeRow(NutSizes.NutSize)).Equals(dblPistonNutSizeInDecimals) Then
                                            dblArea_at_Root_of_Thread = oNutSizeRow(NutSizes.ThreadTensileArea)
                                            Exit For
                                        End If
                                    End If
                                Next
                                'For Each oNutSizeRow As DataRow In oNutSizeTable.Rows
                                '    If Val(oNutSizeRow(NutSizes.NutSize)).Equals(Val(lvwPressureSelection.Items(intCount). _
                                '    SubItems(PressureListViewItems.NutSize).Text)) Then
                                '        dblArea_at_Root_of_Thread = oNutSizeRow(NutSizes.ThreadTensileArea)
                                '        Exit For
                                '    End If
                                'Next

                                _aPistonListView.Add(New Object(2) {oRodDiameterRow(BoreDiameters.RodDiameter), dblPistonNutSizeInDecimals, _
                                dblArea_at_Root_of_Thread})
                                '_aPistonListView.Add(New Object(2) {oRodDiameterRow(BoreDiameters.RodDiameter), _
                                'lvwPressureSelection.Items(intCount).SubItems(PressureListViewItems.NutSize).Text, dblArea_at_Root_of_Thread})

                                Dim dblMax_Pressure_at_Max_Nut_Size As Double = (Val(txtRodMaterialYield.Text) * dblArea_at_Root_of_Thread * 4) _
                                / (Math.PI * (Math.Pow(Val(cmbBoreDiameters.Text), 2) - _
                                Math.Pow(Val(lvwPressureSelection.Items(intCount).SubItems(PressureListViewItems.RodDiameter).Text), 2)) _
                                * Val(txtNutSafetyFactor.Text))

                                ' ANUP 24-06-2010 
                                'If dblMax_Pressure_at_Max_Nut_Size < Val(txtWorkingPressure.Text) Then
                                '    lvwPressureSelection.Items(intCount).SubItems.Add(Math.Ceiling(dblMax_Pressure_at_Max_Nut_Size))
                                'Else
                                '    lvwPressureSelection.Items(intCount).SubItems.Add(txtWorkingPressure.Text)
                                'End If

                                Dim dblDerate_Pressure As Double = (Math.PI * _
                                Math.Pow(Val(lvwPressureSelection.Items(intCount).SubItems(PressureListViewItems.RodDiameter).Text), 4) * _
                                1470000 * 4) / _
                                (Math.Pow(Val(cmbBoreDiameters.Text), 2) * Math.Pow((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength + Val(txtRetractedLength.Text)), 2))
                                If dblDerate_Pressure < Val(txtWorkingPressure.Text) Then
                                    'lvwPressureSelection.Items(intCount).SubItems.Add(Math.Round(dblDerate_Pressure, 2))
                                    lvwPressureSelection.Items(intCount).SubItems.Add(Math.Ceiling(dblDerate_Pressure))
                                Else
                                    lvwPressureSelection.Items(intCount).SubItems.Add("N/A")
                                End If

                                intCount += 1
                            Next
                            ChangeRodDia()
                        Else
                            MessageBox.Show(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.ErrorMessage, "Information", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                        End If

                        lvwPressureSelection.FullRowSelect = True
                        'If lvwPressureSelection.Items.Count >= 1 Then
                        '    lvwPressureSelection.Items(0).Selected = True
                        'End If
                        lvwPressureSelection.HideSelection = False
                    Else
                        MessageBox.Show(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.ErrorMessage, "Information", MessageBoxButtons.OK, _
                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                    End If
                Else
                    MessageBox.Show(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.ErrorMessage, "Information", MessageBoxButtons.OK, _
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                End If
                'Else
                '    MessageBox.Show("Bore Diameter, RodMaterialYield, NutSafetyFactor, StrokeLength and RetractedLength should not be empty", "Information", _
                '    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured while populating lvwPressureSelection in frmPrimaryInputs " + ex.Message)
        End Try
    End Sub

    'ONSITE:06-06-2010  to display rod diamters values
    Private Sub ChangeRodDia()
        Dim htList As New Hashtable
        htList.Add("0.875", 0.88)
        htList.Add("1.125", 1.13)
        htList.Add("1.375", 1.38)

        For Each oItem As ListViewItem In lvwPressureSelection.Items
            If htList.ContainsKey(oItem.Text) Then
                oItem.Text = htList(oItem.Text)
            Else
                oItem.Text = Math.Round(Val(oItem.Text), 2)
            End If
        Next
    End Sub

    Private Sub PopulatePistonlistView()

        Try

            If lvwPistonDetails.Items.Count >= 1 Then

                lvwPistonDetails.Items(0).Selected = True

                lvwPistonDetails.Items(0).Selected = False

            End If

            lvwPistonDetails.Items.Clear()

            lvwPistonDetails.Columns.Clear()

            lvwPistonDetails.Columns.Add("Nut Size", 120, HorizontalAlignment.Center)

            lvwPistonDetails.Columns.Add("Max Pressure", 110, HorizontalAlignment.Center)

            Dim dblPistonNutSizeInDecimals As Double = 0

            Dim oNutSizeTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetThreadTensileArea

            Dim oListViewItem As ListViewItem

            Dim dblTensileArea As Double

            Dim oRows() As DataRow = GetNutSizeASC_Order()

            For Each oRow As DataRow In oRows

                oListViewItem = New ListViewItem()

                oListViewItem.Text = oRow("NutSize")

                dblPistonNutSizeInDecimals = oRow("NutSizeDec")

                dblTensileArea = GetTensileArea(oNutSizeTable, dblPistonNutSizeInDecimals)

                Dim dblMax_Pressure_at_Max_Nut_Size As Double = (Val(txtRodMaterialYield.Text) * dblTensileArea * 4) _
                                    / (Math.PI * (Math.Pow(Val(cmbBoreDiameters.Text), 2) - Math.Pow(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, 2)) * Val(txtNutSafetyFactor.Text))

                If dblMax_Pressure_at_Max_Nut_Size < Val(txtWorkingPressure.Text) Then

                    oListViewItem.SubItems.Add(Math.Ceiling(dblMax_Pressure_at_Max_Nut_Size))

                Else

                    oListViewItem.SubItems.Add(txtWorkingPressure.Text)

                End If

                lvwPistonDetails.Items.Add(oListViewItem)

            Next

            lvwPistonDetails.FullRowSelect = True

            lvwPistonDetails.HideSelection = False
            lvwPistonDetails.Items(0).Selected = True 'vamsi 13-02-14

        Catch ex As Exception

            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured while populating lvwPistonDetails in frmPrimaryInputs " + ex.Message)

        End Try

    End Sub

    Private Function GetNutSizeASC_Order() As DataRow()
        'Dim oTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPistonNutSize(cmbBoreDiameters.Text, lvwPressureSelection.SelectedItems(0).SubItems(PressureListViewItems.RodDiameter).Text)
        Dim oTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPistonNutSize(cmbBoreDiameters.Text, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter)
        Dim oColumn As DataColumn = New DataColumn("NutSizeDec", GetType(System.Double))
        oTable.Columns.Add(oColumn)
        For Each oRow As DataRow In oTable.Rows
            oRow("NutSizeDec") = GetSizeValue(oRow("NutSize"))
        Next
        Return oTable.Select("NutSizeDec > 0")
    End Function

    Private Function GetTensileArea(ByVal oTable As DataTable, ByVal dblNutSize As Double) As Double

        Dim oRows() As DataRow = oTable.Select("NutSize=" + dblNutSize.ToString)

        If oRows.Length > 0 Then

            Return oRows(0)("ThreadTensileArea")

        End If

        Return 0

    End Function

    Private Function GetSizeValue(ByVal strSize As String) As Double

        For Each oNutSizes As Object In ObjClsWeldedCylinderFunctionalClass.NutSizesInFractions

            If oNutSizes(0).Equals(strSize) Then

                Return oNutSizes(1)

            End If

        Next

        Return 0

    End Function

    Private Sub GetRodMaterialCodeFromDB(ByVal strRodMaterial As String)

        Try
            Dim oRodMaterialCode As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetRodMaterialCode(strRodMaterial)
            If Not IsNothing(oRodMaterialCode) Then
                If cmbRodMaterial.Text = "Chrome" Then 'OrElse cmbRodMaterial.Text = "LION 1000" Then     'ANUP 21-09-2010 
                    If Not IsDBNull(oRodMaterialCode(0)) Then
                        _strRodMaterialCode = oRodMaterialCode(0)
                    End If
                ElseIf cmbRodMaterial.Text = "Nitro Steel" Then
                    If Not IsDBNull(oRodMaterialCode(1)) Then
                        _strRodMaterialCode = oRodMaterialCode(1)
                    End If
                    'ANUP 21-09-2010 START
                ElseIf cmbRodMaterial.Text = "LION 1000" Then
                    If Not IsDBNull(oRodMaterialCode(2)) Then
                        _strRodMaterialCode = oRodMaterialCode(2)
                    End If
                    'ANUP 21-09-2010 TILL HERE
                Else
                    _strRodMaterialCode = Nothing
                End If
            Else
                _strRodMaterialCode = Nothing
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in GetRodMaterialCodeFromDB of frmPrimaryInputs " + ex.Message)
        End Try

        'ANUP 06-10-2010 START 
        '   ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Rod Material Code", _strRodMaterialCode)
        Dim strPartCode As String = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(_strRodMaterialCode)
        If Not String.IsNullOrEmpty(strPartCode) Then
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Rod Material Code", strPartCode)
            _strRodMaterialCode = strPartCode
        Else
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Rod Material Code", _strRodMaterialCode)
        End If
        'ANUP 06-10-2010 TILL HERE

    End Sub

    Private Sub StopTubeLengthCalculation(Optional ByVal StrokeLength As Double = 0)
        'If chkStopTube.Checked = True Then
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength.ToString <> "" AndAlso txtRetractedLength.Text <> "" Then
            Dim dblExtendedLength As Double = StrokeLength + Val(txtRetractedLength.Text)
            If dblExtendedLength <= 40 Then
                'pnlStopTubeLength.Enabled = False
                'chkStopTube.Checked = False
            Else
                ' pnlStopTubeLength.Enabled = True
                'chkStopTube.Checked = True
                Dim dblStopTubeLength As Double = Math.Ceiling(((dblExtendedLength - 40) / 10) / 0.125)
                dblStopTubeLength = dblStopTubeLength * 0.125
                txtRecommendedStopTubeLength.Text = dblStopTubeLength
                If chkStopTube.Checked = True Then
                    txtStopTubeRequired.Text = dblStopTubeLength
                    txtStopTubeRequired.BackColor = Color.White
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Stop Tube Length", txtStopTubeRequired.Text)
                    GetStopTubeCodeFromDB()
                End If
            End If
            'Else
            'MessageBox.Show("StrokeLength, RetractedLength should not be zero", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, _
            'MessageBoxDefaultButton.Button2)
        End If
        'End If
    End Sub

    Private Sub LoadPistonConnectionItems()
        cmbPistonConnection.Items.Clear()
        cmbPistonConnection.Items.Add("Nut")
        cmbPistonConnection.Items.Add("Bolt")
        If cmbClass.Text <> "3" AndAlso cmbClass.Text <> "4" Then
            cmbPistonConnection.Items.Add("TXPiston")
        End If
        cmbPistonConnection.SelectedIndex = 0
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonConnection = cmbPistonConnection.Text
        cmbPistonConnection.Enabled = False
        cmbPistonConnection.BackColor = Color.Empty
    End Sub

    Private Sub LoadPistonShankSealType()
        cmbPistonShankSeal.Items.Clear()
        cmbPistonShankSeal.Items.Add("PressFit")
        If cmbPistonConnection.Text <> "TXPiston" Then
            cmbPistonShankSeal.Items.Add("ORing")
        End If
        cmbPistonShankSeal.SelectedIndex = 0
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonShankSeal = cmbPistonShankSeal.Text
        cmbPistonShankSeal.Enabled = False
        cmbPistonShankSeal.BackColor = Color.Empty
    End Sub

    Private Sub GetStopTubeCodeFromDB()
        If Not txtStopTubeRequired.Text = "" AndAlso txtStopTubeRequired.Text <> 0 Then
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter <> 0 Then
                Dim dblHigherStopTubeLength As Double = Val(txtStopTubeRequired.Text) + 0.125
                Dim dblLowerStopTubeLength As Double = Val(txtStopTubeRequired.Text)
                Dim strStopTubeCode As String = Nothing
                Try
                    Dim oStopTubeDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetStopTubeCode _
                                    (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, dblLowerStopTubeLength, dblHigherStopTubeLength)
                    If Not IsNothing(oStopTubeDataTable) Then
                        Dim oStopTubeDatarow As DataRow = oStopTubeDataTable.Rows(0)
                        If Not IsDBNull(oStopTubeDatarow("StopTubeCode")) Then
                            strStopTubeCode = oStopTubeDatarow("StopTubeCode")
                        End If
                        pnlInsertStopTubeDetailIntoDB.Visible = False
                        pnlStopTubeLength.Location = New Point(37, 24)
                    Else
                        If InsertStopTubeDetailsToDB() Then
                            pnlInsertStopTubeDetailIntoDB.Visible = True
                            pnlStopTubeLength.Location = New Point(37, 5)
                            lblInsertStopTubeDetailsInDB.Text = "New StopTube is Generated"
                        Else
                            pnlInsertStopTubeDetailIntoDB.Visible = True
                            pnlStopTubeLength.Location = New Point(37, 5)
                            lblInsertStopTubeDetailsInDB.Text = "New StopTube is not Generated"
                        End If
                    End If
                Catch ex As Exception
                    ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in GetStopTubeCodeFromDB of frmPrimaryInputs " + ex.Message)
                End Try

                'ANUP 06-10-2010 START 
                'ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Stop Tube Code", strStopTubeCode)
                Dim strPartCode As String = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(strStopTubeCode)
                If Not String.IsNullOrEmpty(strPartCode) Then
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Stop Tube Code", strPartCode)
                    strStopTubeCode = strPartCode
                Else
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Stop Tube Code", strStopTubeCode)
                End If
                'ANUP 06-10-2010 TILL HERE

                clsAddExistingCodes.AddStopTubeCode(strStopTubeCode, 1, "EA") 'Costing 03-08-10
            Else
                pnlInsertStopTubeDetailIntoDB.Visible = True
                pnlStopTubeLength.Location = New Point(37, 5)
                lblInsertStopTubeDetailsInDB.Text = "RodDiameter not selected"
            End If
        End If
    End Sub

    Private Function InsertStopTubeDetailsToDB() As Boolean
        Try
            InsertStopTubeDetailsToDB = False
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Stop Tube Code", "")

            Dim strDrawingNumber As String = "495598"
            Dim strMaxStopTubeCode As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetMaxStopTubeCode
            If Not IsNothing(strMaxStopTubeCode) Then
                If strMaxStopTubeCode.Contains("IFLST") Then
                    strMaxStopTubeCode = strMaxStopTubeCode.Substring(5)
                    strMaxStopTubeCode = Val(strMaxStopTubeCode) + 1
                Else
                    strMaxStopTubeCode = 1001
                End If
            End If
            strMaxStopTubeCode = "IFLST" + strMaxStopTubeCode

            Dim strIFLID As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetMaxIFLID("Welded.StopTubeDetails")
            strIFLID = Val(strIFLID) + 1

            Dim dblStopTubeLength As Double = Val(txtStopTubeRequired.Text)
            Dim dblRodDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
            Dim dblStopTubeID As Double = Math.Round(dblRodDiameter + 0.015, 2)
            Dim dblStopTubeOD As Double = 0
            For Each oItem As Object In StopTubeOD
                If oItem(EStopTubeOD.RodDiameter).Equals(dblRodDiameter) Then
                    dblStopTubeOD = oItem(EStopTubeOD.StopTubeOD)
                    Exit For
                End If
            Next

            If Not strMaxStopTubeCode = "" AndAlso dblStopTubeLength <> 0 AndAlso dblStopTubeOD <> 0 Then
                Dim dblNominalWall As Double = Math.Round((dblStopTubeOD - dblStopTubeID) / 2, 2)
                Dim strStopTubeDescription As String = dblRodDiameter.ToString + "-" + dblStopTubeOD.ToString + "-" + dblStopTubeLength.ToString
                Dim strMessage As String = "IFLID = " + strIFLID + vbCrLf
                strMessage += "DrawingNumber = 495598" + vbCrLf
                strMessage += "StopTubeCode = " + strMaxStopTubeCode + vbCrLf
                strMessage += "StopTubeDescription = " + strStopTubeDescription + vbCrLf
                strMessage += "RodDiameter = " + dblRodDiameter.ToString + vbCrLf
                strMessage += "StopTubeOD = " + dblStopTubeOD.ToString + vbCrLf
                strMessage += "StopTube NominalWall = " + dblNominalWall.ToString + vbCrLf
                strMessage += "StopTubeLength = " + dblStopTubeLength.ToString

                InsertStopTubeDetailsToDB = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                InsertStopTubeDetails(strIFLID, strDrawingNumber, strMaxStopTubeCode, strStopTubeDescription, dblRodDiameter, dblStopTubeOD, _
                dblNominalWall, dblStopTubeLength)


                'ANUP 06-10-2010 START 
                ' ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Stop Tube Code", strMaxStopTubeCode)
                Dim strPartCode As String = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(strMaxStopTubeCode)
                If Not String.IsNullOrEmpty(strPartCode) Then
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Stop Tube Code", strPartCode)
                Else
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Stop Tube Code", strMaxStopTubeCode)
                End If
                'ANUP 06-10-2010 TILL HERE

            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured while inserting StopTubeDetails to DB in frmPrimaryInputs " + ex.Message)
        End Try

    End Function

#End Region

#Region "Events"

    Private Sub frmPrimaryInputs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        DefaultSettings()
        ObjClsWeldedCylinderFunctionalClass.AddColors(Me)
        'TODO: ANUP 28-05-2010 12.20pm
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CustomerNameComboBOxChanged = False
        '*********
        '11_10_2010   RAGAVA
        Try
            Dim _strQuery As String = String.Empty
            If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) = "" Then
                _strQuery = "Select top 1 CodeNumber from MIL.dbo.CodeNumberDetails"
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart = MonarchConnectionObject.GetValue(_strQuery)
            End If
        Catch ex As Exception
        End Try

        'ANUP 01-11-2010 START
        CylinderReleasedFunctionality()
        'ANUP 01-11-2010 TILL HERE

    End Sub

    Private Sub cmbBoreDiameters_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    cmbBoreDiameters.SelectedIndexChanged
        If cmbBoreDiameters.Text <> "" Then
            If cmbBoreDiameters.Text <> cmbBoreDiameters.IFLDataTag Then
                cmbBoreDiameters.IFLDataTag = cmbBoreDiameters.Text
                If cmbRodMaterial.Text <> "" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter = Val(cmbBoreDiameters.Text)
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Bore Diameter", cmbBoreDiameters.Text)
                    PopulatePressureListView()
                End If
            End If
        Else
            cmbBoreDiameters.IFLDataTag = Nothing
        End If
    End Sub

    Private Sub lvwPressureSelection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwPressureSelection.SelectedIndexChanged
        If lvwPressureSelection.SelectedItems.Count > 0 Then

            Dim oListViewSelectedItem As ListViewItem = lvwPressureSelection.SelectedItems(0)

            'Sandeep 18-02-10
            ' If Val(oListViewSelectedItem.SubItems(PressureListViewItems.RodDiameter).Text) = 0.88 OrElse Val(oListViewSelectedItem.SubItems(PressureListViewItems.RodDiameter).Text) = 0.5 Then
            'OrElse Val(oListViewSelectedItem.SubItems(PressureListViewItems.RodDiameter).Text) = 1.13 Then 'ANUP 06-07-2010
            'TODO: ANUP 06-07-2010
            If Val(oListViewSelectedItem.SubItems(PressureListViewItems.RodDiameter).Text) = 0.5 Then
                MessageBox.Show("Cylinder Head details are not available for selected RodDiameter, Please select different RodDiameter", "CylinderHead Details Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
            End If
            'Sandeep 18-02-10

            GetRodMaterialCodeFromDB(oListViewSelectedItem.SubItems(PressureListViewItems.RodDiameter).Text)
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure = Val(txtWorkingPressure.Text)
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Working Pressure", txtWorkingPressure.Text)
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Rod Diameter", oListViewSelectedItem.SubItems(PressureListViewItems.RodDiameter).Text)
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter = Val(oListViewSelectedItem.SubItems(PressureListViewItems.RodDiameter).Text)
            setRodDiameterValue(oListViewSelectedItem.Text)
            If Val(oListViewSelectedItem.SubItems(PressureListViewItems.Derate_Pressure).Text) < ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ColumnLoadDeratePressure = oListViewSelectedItem.SubItems(PressureListViewItems.Derate_Pressure).Text
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Column Load Derate Pressure", oListViewSelectedItem.SubItems(PressureListViewItems.Derate_Pressure).Text)
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ColumnLoadDeratePressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Column Load Derate Pressure", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure)
            End If
            PopulatePistonlistView()
            GetStopTubeCodeFromDB()
        Else
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Rod Material Code", "")
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Rod Diameter", "")
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter = 0
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ColumnLoadDeratePressure = ""
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Column Load Derate Pressure", "")
            lvwPistonDetails.Items.Clear()
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Stop Tube Code", "")

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInDecimals = 0
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInFractions = ""
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Nut Size", "")
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Nut Code", "")
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Nut Max Thickness", "")

        End If
    End Sub
    'ONSITE:06-06-2010
    Private Sub setRodDiameterValue(ByVal strRod As String)
        Dim htRodData As New Hashtable
        htRodData.Add("0.88", 0.875)
        htRodData.Add("1.13", 1.125)
        htRodData.Add("1.38", 1.375)
        If htRodData.ContainsKey(strRod) Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter = htRodData(strRod)
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter = strRod
        End If

    End Sub

    Private Sub txtStopTubeRequired_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStopTubeRequired.Leave
        If txtStopTubeRequired.Text <> "" Then
            If txtStopTubeRequired.Text <> txtStopTubeRequired.IFLDataTag Then
                txtStopTubeRequired.IFLDataTag = txtStopTubeRequired.Text
                Dim dblStopTubeLength As Double = Math.Ceiling(Val(txtStopTubeRequired.Text) / 0.125)
                dblStopTubeLength = dblStopTubeLength * 0.125
                txtStopTubeRequired.Text = dblStopTubeLength
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Stop Tube Length", txtStopTubeRequired.Text)
                GetStopTubeCodeFromDB()
            End If
        Else
            txtStopTubeRequired.IFLDataTag = Nothing
        End If
    End Sub

    Private Sub chkStopTube_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStopTube.CheckedChanged
        If chkStopTube.Checked Then
            txtStopTubeRequired.Enabled = True
        Else
            txtStopTubeRequired.Enabled = False
            txtStopTubeRequired.BackColor = Color.Empty
            txtRecommendedStopTubeLength.Text = ""
            txtStopTubeRequired.Text = 0
            pnlInsertStopTubeDetailIntoDB.Visible = False
            pnlStopTubeLength.Location = New Point(37, 24)
        End If
        StopTubeLengthCalculation()
        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Stop Tube Length", txtStopTubeRequired.Text)
    End Sub

    Private Sub lvwPistonDetails_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    lvwPistonDetails.SelectedIndexChanged
        If lvwPistonDetails.SelectedIndices.Count > 0 Then

            Dim oListViewSelectedItem As ListViewItem = lvwPistonDetails.SelectedItems(0)
            If Val(oListViewSelectedItem.SubItems(PistonListView.MaxPressure).Text) < Val(txtWorkingPressure.Text) Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure = Val(oListViewSelectedItem.SubItems(PistonListView.MaxPressure).Text)
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Working Pressure", oListViewSelectedItem.SubItems(PistonListView.MaxPressure).Text)
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure = Val(txtWorkingPressure.Text)
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Working Pressure", Val(txtWorkingPressure.Text))
            End If

            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Nut Size", oListViewSelectedItem.SubItems(PistonListView.NutSize).Text)

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ColumnLoadDeratePressure <> "" Then
                If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ColumnLoadDeratePressure) > ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure Then
                    'MessageBox.Show("Working Pressure is lessthan ColumnLoad Derate Pressure", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ColumnLoadDeratePressure = ""
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Column Load Derate Pressure", "")
                End If
            Else
                Dim oPressureListViewSelectedItem As ListViewItem = lvwPressureSelection.SelectedItems(0)
                If Val(oPressureListViewSelectedItem.SubItems(PressureListViewItems.Derate_Pressure).Text) < ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ColumnLoadDeratePressure = oPressureListViewSelectedItem.SubItems(PressureListViewItems.Derate_Pressure).Text
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Column Load Derate Pressure", oPressureListViewSelectedItem.SubItems(PressureListViewItems.Derate_Pressure).Text)
                End If
            End If

            'Dim dblPistonNutSizeInDecimals As Double = 0
            'Dim strPistonNutSizeInFractions As String = ""
            For Each oNutSizes As Object In ObjClsWeldedCylinderFunctionalClass.NutSizesInFractions
                If oNutSizes(0) = lvwPistonDetails.SelectedItems(0).SubItems(PistonListView.NutSize).Text Then
                    'dblPistonNutSizeInDecimals = oNutSizes(1)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInDecimals = oNutSizes(1)
                    'strPistonNutSizeInFractions = oNutSizes(0)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInFractions = oNutSizes(0)
                    Exit For
                End If
            Next

            Dim strPistonNutCode As String = Nothing
            Try
                Dim oNutCodeDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                GetNutCodeAndThickness(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInDecimals)

                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Nut Code", "")
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Nut Max Thickness", "")
                _dblTempMaxNutThickness = Nothing
                If Not IsNothing(oNutCodeDataRow) Then
                    If Not oNutCodeDataRow(1) = "" Then
                        strPistonNutCode = oNutCodeDataRow(1)
                    End If

                    '17-02-10 Sandeep
                    'Comment : To BE integarted
                    If Not IsDBNull(oNutCodeDataRow(3)) Then
                        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Nut Max Thickness", oNutCodeDataRow(3))
                        _dblTempMaxNutThickness = oNutCodeDataRow(3)
                    Else
                        _dblTempMaxNutThickness = Nothing
                        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Nut Max Thickness", "")
                    End If
                    'TODO: ANUP 05-07-2010 11.02am
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutThickness = _dblTempMaxNutThickness
                    '17-02-10 Sandeep

                    If Not IsDBNull(oNutCodeDataRow("ActualThickness")) Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutActualSize = oNutCodeDataRow("ActualThickness")
                    End If
                End If
            Catch ex As Exception
                ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in lvwPistonDetails_SelectedIndexChanged of frmPrimaryInputs " + ex.Message)
            End Try


            'ANUP 06-10-2010 START 
            '  ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Nut Code", strPistonNutCode)
            Dim strPartCode As String = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(strPistonNutCode)
            If Not String.IsNullOrEmpty(strPartCode) Then
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Nut Code", strPartCode)
                strPistonNutCode = strPartCode
            Else
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Nut Code", strPistonNutCode)
            End If
            'ANUP 06-10-2010 TILL HERE

            clsAddExistingCodes.AddPistonNutCode(strPistonNutCode, 1, "EA") 'Costing 03-08-10
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInDecimals = 0
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInFractions = ""
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Nut Size", "")
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Nut Code", "")
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Nut Max Thickness", "")
        End If
    End Sub

    Private Sub cmbRodMaterial_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRodMaterial.Leave
        Try
            If cmbRodMaterial.Text <> "" Then
                PopulatePressureListView()            '12_03_2012   RAGAVA
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbRodMaterial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    cmbRodMaterial.SelectedIndexChanged
        If cmbRodMaterial.Text <> "" Then
            If cmbRodMaterial.Text <> cmbRodMaterial.IFLDataTag Then
                cmbRodMaterial.IFLDataTag = cmbRodMaterial.Text
                If cmbRodMaterial.Text = "Chrome" Then
                    txtRodMaterialYield.Text = 83500
                ElseIf cmbRodMaterial.Text = "Nitro Steel" Then
                    txtRodMaterialYield.Text = 75000
                ElseIf cmbRodMaterial.Text = "Induction Hardened" Then
                    txtRodMaterialYield.Text = 75000
                Else
                    txtRodMaterialYield.Text = 83500        '16_08_2010    RAGAVA
                End If

                'A0308: ANUP 04-08-2010 03.26pm
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial = cmbRodMaterial.Text

                'PopulatePressureListView()
            End If
        Else
            cmbRodMaterial.IFLDataTag = Nothing
        End If
    End Sub

    Private Sub cmbClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClass.SelectedIndexChanged
        If cmbClass.Text <> "" Then
            If cmbClass.Text <> cmbClass.IFLDataTag Then
                cmbClass.IFLDataTag = cmbClass.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass = cmbClass.Text
                LoadNutSafetyFactor()
                LoadPistonConnectionItems()
                Try
                    lvwPressureSelection.SelectedItems(0).Focused = False
                    lvwPressureSelection.SelectedItems(0).Selected = False
                Catch ex As Exception

                End Try
            End If
        Else
            cmbClass.IFLDataTag = Nothing
        End If
    End Sub

    Private Sub cmbStrokeLength_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbStrokeLength.Leave
        Try
            Dim dblCastingSum As Double = 0
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength = 8 Then
                dblCastingSum = 12.25
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength = 16 Then
                dblCastingSum = 15.5
            End If
            'If ofrmTieRod1.cmbStyle.Text = "ASAE" Then
            '    intASAEFactor = 2
            'ElseIf ofrmTieRod1.cmbStyle.Text = "NON ASAE" Then
            '    intASAEFactor = 0
            'End If
            'txtRetractedLength.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength + StopTubeLength + RodAdder + dblCastingSum
            txtRetractedLength.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength + dblCastingSum
            cmbRodMaterial.Focus()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub txtNutSafetyFactor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNutSafetyFactor.TextChanged, txtRodMaterialYield.TextChanged, txtWorkingPressure.TextChanged, _
     txtRetractedLength.Leave, txtStrokeLength.TextChanged, cmbStrokeLength.SelectedIndexChanged
        If sender.Text <> "" Then
            If Not sender.Text.IndexOf(".") = sender.Text.LastIndexOf(".") Then
                MessageBox.Show(sender.name + " TextBox contains more than one '.'")
                sender.focus()
                Exit Sub
            End If
            'anup13-01-2010 till here

            Dim dblRetracedLenth_Minimum As Double = 6
            If Not (txtStrokeLength.Text = "" AndAlso sender.name = "txtRetractedLength") OrElse Not (cmbStrokeLength.Text = "" AndAlso sender.name = "cmbStrokeLength") Then 'OrElse cmbStrokeLength.Text = "") Then
                Dim dblstrokelength As Double = Val(txtStrokeLength.Text)
                If dblstrokelength = 0 Then
                    dblstrokelength = Val(cmbStrokeLength.Text)
                End If
                Dim dblMinimumRetractedLengthRequired As Double = dblstrokelength + 2
                If dblMinimumRetractedLengthRequired > 6 Then
                    dblRetracedLenth_Minimum = dblMinimumRetractedLengthRequired
                End If
            End If
            If sender.name = "txtRetractedLength" Then
                If Val(txtRetractedLength.Text) < dblRetracedLenth_Minimum OrElse Val(txtRetractedLength.Text) > 96 Then
                    Dim strMessage As String = "Value must be between " & dblRetracedLenth_Minimum & " and 96"
                    MessageBox.Show(strMessage, "Change value", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    txtRetractedLength.Clear()
                    txtRetractedLength.Focus()
                    Exit Sub
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength = sender.Text
            End If

            If sender.name = "txtStrokeLength" Then
                If (Val(txtStrokeLength.Text) < 1 OrElse Val(txtStrokeLength.Text) > 72) Then 'OrElse (Val(cmbStrokeLength.Text) < 1 OrElse Val(cmbStrokeLength.Text) > 72) Then
                    Dim strMessage As String = "Value must be between 1 and 72"
                    MessageBox.Show(strMessage, "Change value", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    If sender.name = "txtStrokeLength" Then
                        txtStrokeLength.Clear()
                        txtStrokeLength.Focus()
                    ElseIf sender.name = "cmbStrokeLength" Then
                        cmbStrokeLength.SelectedIndex = 0
                        cmbStrokeLength.Focus()
                    End If
                    Exit Sub
                Else
                    'anup 22-03-2011
                    'If Not txtStrokeLength.Text.Contains(".") Then
                    '    If txtStrokeLength.Text > 9 Then
                    '        txtStrokeLength.AppendText(".")
                    '    End If
                    'End If
                End If

            End If
            If sender.text <> "" AndAlso (sender.name = "txtStrokeLength" OrElse sender.name = "cmbStrokeLength") Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength = Val(sender.Text)
            End If


            ' ANUP 01-04-2010 04.02
            'If Not ObjClsWeldedCylinderFunctionalClass.RetractedLengthChangedFromRetractedValidationScreen Then
            '    PopulatePressureListView()
            '    StopTubeLengthCalculation()
            '    ObjClsWeldedCylinderFunctionalClass.RetractedLengthChangedFromRetractedValidationScreen = False
            'End If
            PopulatePressureListView()
            StopTubeLengthCalculation(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength)

            '27_02_2012   RAGAVA
            Try
                Dim rod As String = ""
                If Me.cmbBoreDiameters.Text <= 2.75 Then
                    rod = "1.13"
                ElseIf Me.cmbBoreDiameters.Text <= 3.5 Then
                    rod = "1.25"
                ElseIf Me.cmbBoreDiameters.Text <= 4 Then
                    rod = "1.38"
                ElseIf Me.cmbBoreDiameters.Text <= 4.75 Then
                    rod = "1.5"
                ElseIf Me.cmbBoreDiameters.Text <= 5 Then
                    rod = "2"
                End If
                Dim index As Integer = 0
                For Each oListViewItem As ListViewItem In lvwPressureSelection.Items
                    If rod = oListViewItem.SubItems(0).Text Then
                        lvwPressureSelection.Items(index).Selected = True
                        Exit For
                    Else
                        index = index + 1
                    End If
                Next
            Catch ex As Exception

            End Try
            'Till  Here


            '*************
            'End If
        Else
            MessageBox.Show("BoreDiameter, WorkingPressure, RodMaterialYield, NutSafetyFactor, StrokeLength and RetractedLength should not be empty", "Information", _
           MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
            If sender.name = "txtRetractedLength" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength = 0
            End If
            If sender.name = "txtStrokeLength" OrElse sender.name = "cmbStrokeLength" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength = 0
            End If
            lvwPressureSelection.Items.Clear()
            '   sender.IFLDataTag = ""
        End If
    End Sub


    'Private Sub txtNutSafetyFactor_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNutSafetyFactor.TextChanged, txtRodMaterialYield.TextChanged, txtWorkingPressure.TextChanged, _
    ' txtRetractedLength.Leave, txtStrokeLength.TextChanged
    '    If sender.Text <> "" Then
    '        If Not sender.Text.IndexOf(".") = sender.Text.LastIndexOf(".") Then
    '            MessageBox.Show(sender.name + " TextBox contains more than one '.'")
    '            sender.focus()
    '            Exit Sub
    '        End If
    '        'anup13-01-2010 till here

    '        Dim dblRetracedLenth_Minimum As Double = 6
    '        If Not (txtStrokeLength.Text = "") Then 'OrElse cmbStrokeLength.Text = "") Then
    '            Dim dblstrokelength As Double = Val(txtStrokeLength.Text)
    '            If dblstrokelength = 0 Then
    '                dblstrokelength = Val(cmbStrokeLength.Text)
    '            End If
    '            Dim dblMinimumRetractedLengthRequired As Double = dblstrokelength + 2
    '            If dblMinimumRetractedLengthRequired > 6 Then
    '                dblRetracedLenth_Minimum = dblMinimumRetractedLengthRequired
    '            End If
    '        End If
    '        If sender.name = "txtRetractedLength" Then
    '            If Val(txtRetractedLength.Text) < dblRetracedLenth_Minimum OrElse Val(txtRetractedLength.Text) > 96 Then
    '                Dim strMessage As String = "Value must be between " & dblRetracedLenth_Minimum & " and 96"
    '                MessageBox.Show(strMessage, "Change value", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '                txtRetractedLength.Clear()
    '                txtRetractedLength.Focus()
    '                Exit Sub
    '            End If
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength = sender.Text
    '        End If

    '        If sender.name = "txtStrokeLength" Then 'OrElse sender.name = "cmbStrokeLength" Then
    '            If (Val(txtStrokeLength.Text) < 1 OrElse Val(txtStrokeLength.Text) > 72) Then 'OrElse (Val(cmbStrokeLength.Text) < 1 OrElse Val(cmbStrokeLength.Text) > 72) Then
    '                Dim strMessage As String = "Value must be between 1 and 72"
    '                MessageBox.Show(strMessage, "Change value", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '                If sender.name = "txtStrokeLength" Then
    '                    txtStrokeLength.Clear()
    '                    txtStrokeLength.Focus()
    '                ElseIf sender.name = "cmbStrokeLength" Then
    '                    cmbStrokeLength.SelectedIndex = 0
    '                    cmbStrokeLength.Focus()
    '                End If
    '                Exit Sub
    '            Else
    '                'anup 22-03-2011
    '                'If Not txtStrokeLength.Text.Contains(".") Then
    '                '    If txtStrokeLength.Text > 9 Then
    '                '        txtStrokeLength.AppendText(".")
    '                '    End If
    '                'End If
    '            End If

    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength = sender.Text

    '        End If



    '        ' ANUP 01-04-2010 04.02
    '        'If Not ObjClsWeldedCylinderFunctionalClass.RetractedLengthChangedFromRetractedValidationScreen Then
    '        '    PopulatePressureListView()
    '        '    StopTubeLengthCalculation()
    '        '    ObjClsWeldedCylinderFunctionalClass.RetractedLengthChangedFromRetractedValidationScreen = False
    '        'End If
    '        PopulatePressureListView()
    '        StopTubeLengthCalculation(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength)
    '        '*************
    '        'End If
    '    Else
    '        MessageBox.Show("BoreDiameter, WorkingPressure, RodMaterialYield, NutSafetyFactor, StrokeLength and RetractedLength should not be empty", "Information", _
    '       MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
    '        If sender.name = "txtRetractedLength" Then
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RetractedLength = 0
    '        End If
    '        If sender.name = "txtStrokeLength" OrElse sender.name = "cmbStrokeLength" Then
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength = 0
    '        End If
    '        lvwPressureSelection.Items.Clear()
    '        '   sender.IFLDataTag = ""
    '    End If
    'End Sub
    'ANUP 15-12-2010 TILL HERE

    Private Sub cmbPistonConnection_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPistonConnection.SelectedIndexChanged
        If cmbPistonConnection.Text <> "" Then
            If cmbPistonConnection.Text <> cmbPistonConnection.IFLDataTag Then
                cmbPistonConnection.IFLDataTag = cmbPistonConnection.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonConnection = cmbPistonConnection.Text
                LoadPistonShankSealType()
            End If
        Else
            cmbPistonConnection.IFLDataTag = Nothing
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonConnection = ""
        End If
    End Sub

    Private Sub cmbPistonShankSeal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPistonShankSeal.SelectedIndexChanged
        If cmbPistonShankSeal.Text <> "" Then
            If cmbPistonShankSeal.Text <> cmbPistonShankSeal.IFLDataTag Then
                cmbPistonShankSeal.IFLDataTag = cmbPistonShankSeal.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonShankSeal = cmbPistonShankSeal.Text
            End If
        Else
            cmbPistonShankSeal.IFLDataTag = Nothing
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonShankSeal = ""
        End If
    End Sub

    Private Sub txtNutSafetyFactor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNutSafetyFactor.TextChanged
        If txtNutSafetyFactor.Text <> "" Then
            If txtNutSafetyFactor.Text <> txtNutSafetyFactor.IFLDataTag Then
                txtNutSafetyFactor.IFLDataTag = txtNutSafetyFactor.Text
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor = Val(txtNutSafetyFactor.Text)
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor = 0
            txtNutSafetyFactor.IFLDataTag = Nothing
        End If
    End Sub

    Private Sub txtStopTubeRequired_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStopTubeRequired.TextChanged
        If txtStopTubeRequired.Text <> "" Then
            If txtStopTubeRequired.Text <> txtStopTubeRequired.IFLDataTag Then
                txtStopTubeRequired.IFLDataTag = txtStopTubeRequired.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StopTubeLength = Val(txtStopTubeRequired.Text)
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StopTubeLength = 0
            txtStopTubeRequired.IFLDataTag = Nothing
        End If
    End Sub

    'A0308: ANUP 03-08-2010 02.28pm
    Private Sub txtStandardRunQuantity_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStandardRunQuantity.TextChanged
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StandardRunQuantity = txtStandardRunQuantity.Text
    End Sub

#End Region

    '22_12_2010   RAGAVA
    Private Sub chkRephasing_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRephasing.CheckedChanged
        Try
            If chkRephasing.Checked = True Then
                cmbRephasing.Visible = True
            Else
                cmbRephasing.SelectedIndex = 0
                cmbRephasing.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    '22_12_2010   RAGAVA
    Private Sub cmbRephasing_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRephasing.SelectedIndexChanged
        Try
            '07_12_2011   RAGAVA COMMENTED
            'If cmbRephasing.Text <> "" AndAlso cmbRephasing.Text <> "Rephasing at Extension" Then
            '    MsgBox("Rephasing details are not available for current selection")
            '    cmbRephasing.SelectedIndex = 0
            '    Exit Try
            'End If
            'TILL  HERE
            If Trim(cmbRephasing.Text) <> "" AndAlso chkRephasing.Checked = True Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = Trim(cmbRephasing.Text)
            End If
            'cmbBoreDiameters.Items.Clear()        '23_12_2010   RAGAVA
            'LoadBoreDiameter()                    '23_12_2010   RAGAVA
        Catch ex As Exception
        End Try
    End Sub

    'ANUP 01-11-2010 START
    Private Sub chkReleaseCylinder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReleaseCylinder.CheckedChanged
        Try
            'anup 24-01-2011 start
            If ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Released" Then
                ObjClsWeldedCylinderFunctionalClass.IsReleaseCylinderChecked = True
            ElseIf ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Revision" Then
                If Not ReleasedRevisionFunctionality() Is Nothing Then
                    ObjClsWeldedCylinderFunctionalClass.IsReleaseCylinderChecked = True
                End If
                'anup 24-01-2011 till here
            Else
                ObjClsWeldedCylinderFunctionalClass.IsReleaseCylinderChecked = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CylinderReleasedFunctionality()
        Try
            If ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Revision" Then
                If Not ReleasedRevisionFunctionality() Is Nothing Then
                    chkReleaseCylinder.Checked = True
                    chkReleaseCylinder.Enabled = False
                Else
                    chkReleaseCylinder.Checked = False
                    chkReleaseCylinder.Enabled = False
                End If
            ElseIf ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Released" Then
                chkReleaseCylinder.Checked = True
                chkReleaseCylinder.Enabled = True
                chkReleaseCylinder.Visible = False
            ElseIf ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "New" Then
                chkReleaseCylinder.Checked = False
                chkReleaseCylinder.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function ReleasedRevisionFunctionality() As String 'anup 23-12-2010 change private to public
        ReleasedRevisionFunctionality = Nothing
        Try
            Dim strQuery As String = String.Empty
            strQuery = "select ReleasedCylinderCodeNumber from dbo.ReleasedCylinderCodes where ReleasedCylinderCodeNumber =" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber
            ReleasedRevisionFunctionality = MonarchConnectionObject.GetValue(strQuery)
        Catch ex As Exception
            ReleasedRevisionFunctionality = Nothing
        End Try
    End Function

    '24_01_2012    RAGAVA
    Private Sub ChkASAE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkASAE.CheckedChanged
        If ChkASAE.Checked Then
            txtStrokeLength.Clear()
            txtStrokeLength.Enabled = False
            txtRetractedLength.Enabled = False
            cmbStrokeLength.Visible = True
            cmbStrokeLength.DropDownStyle = ComboBoxStyle.DropDownList


        Else
            txtRetractedLength.Enabled = True
            txtStrokeLength.Clear()
            txtStrokeLength.Enabled = True
            cmbStrokeLength.SelectedIndex = 0
            cmbStrokeLength.Visible = False
        End If

        If ObjClsWeldedCylinderFunctionalClass.MultiGenerate = True Then
            cmbBoreDiameters.Items.Clear()
            LoadBoreDiameter()
        End If

              '27_02_2012   RAGAVA
    End Sub

    Private Sub cmbStrokeLength_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStrokeLength.SelectedIndexChanged
        Try
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength = Val(cmbStrokeLength.Text)       '24_01_2012   RAGAVA
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtRetractedLength_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRetractedLength.TextChanged

    End Sub
End Class