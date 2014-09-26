Imports System.io
Public Class frmFabrication_RECT

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

#Region "Private variables"

    Private _oFilterWithAreaDataTable As DataTable

    Private _strCrossTubeCode As String

    Private _dblTempNutSafetyFactor As Double = 0

    Private _dblTempPinHoleSize As Double = 0

    Private _dblTempSwingClearance As Double = 0

    Private _dblWorkingPressure As Double = 0

    Private _intClass As Integer = 0

    Private _dblCrossTubeWidth As Double = 0

    Private _intSafetyFactorCount As Integer = 0
    Private _rodDiameter As Double

#End Region

#Region "Enum"

    Public Enum CrossTubeListViewDetails
        CodeNumber = 0
        Description = 1
        Cost = 2
    End Enum

    Public Enum WeightListView
        SafetyFactor = 0
        CrossTubeWidth = 1
        Weight = 2
    End Enum
#End Region

#Region "Sub Procedures"

    Private Sub DefaultSettings()

        txtCrossTubeOD_RECT.Enabled = False

        txtCrossTubeWidth_RECT.Enabled = False
        txtRequiredCrossTubeWidth_RECT.Enabled = False

        txtSwingClearance_RECT.Enabled = False
        txtRequiredSwingClearance_RECT.Enabled = False

        txtCost_RECT.Enabled = False
        txtRequiredCost_RECT.Enabled = False

        'chkUseSelectedCrossTube_RECT.Checked = True             '14_02_2011   RAGAVA
        chkUseSelectedCrossTube_RECT.Enabled = True              '14_02_2011   RAGAVA

        'TODO:Sunny 07-04-10 2pm
        txtPinHoleSize_RECT.Enabled = False
        txtRequiredPinHoleSize_RECT.Enabled = False

        txtGreaseZerk_RECT.Enabled = False
        txtRequiredGreaseZerk_RECT.Enabled = False

        txtAngle1_RECT.Enabled = False
        txtRequiredAngle1_RECT.Enabled = False

        txtAngle2_RECT.Enabled = False
        txtRequiredAngle2_RECT.Enabled = False
        '*********************
        'rdbResize_RECT.Checked = True
        'chkExactMatch_RECT.Checked = True

        txtCrossTubeWidth_DesignCrossTubeCT_RECT.Enabled = True
        txtCrossTubeOD_DesignCrossTubeCT_RECT.Enabled = False
        txtPinHoleSize_DesignCrossTubeCT_RECT.Enabled = False
        txtSwingClearance_DesignCrossTubeCT_RECT.Enabled = False
        btnAcceptCT_RECT.Enabled = False
        SafetyFactor_WeightCT_RECT_GeneratedDesign()
    End Sub

    Private Sub SafetyFactor_WeightCT_RECT_GeneratedDesign()
        lvwSafetyFactor_WeightCT_RECT.Clear()
        lvwSafetyFactor_WeightCT_RECT.Columns.Add("SafetyFactor", 130, HorizontalAlignment.Center)
        lvwSafetyFactor_WeightCT_RECT.Columns.Add("CrossTubeWidth", 130, HorizontalAlignment.Center)
        lvwSafetyFactor_WeightCT_RECT.Columns.Add("Weight", 125, HorizontalAlignment.Center)
        lvwSafetyFactor_WeightCT_RECT.FullRowSelect = True
    End Sub


    'ONSITE: 26-05-2010 To disable the required tolerace and display the content
    Private Sub DisableReqPinToleranceControls()
        txtPinHoleTole_Neg_Req.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd
        txtPinHoleTole_Pos_Req.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd
        txtPinHoleTole_Pos_Req.Enabled = False
        txtPinHoleTole_Neg_Req.Enabled = False
        txtPinHoleTole_Pos.Enabled = False
        txtPinHoleTole_Neg.Enabled = False
    End Sub


    Private Sub LoadDefaultValues()

        txtRequiredCrossTubeWidth_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd
        txtRequiredSwingClearance_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
        txtRequiredCost_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.Cost_RodEnd
        txtRequiredPinHoleSize_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
        DisableReqPinToleranceControls()
        lvwSafetyFactor_WeightCT_RECT.Items.Clear()
        _intSafetyFactorCount = 0
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor <> _dblTempNutSafetyFactor _
      OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd <> _dblTempPinHoleSize _
      OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd <> _dblTempSwingClearance _
      OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure <> _dblWorkingPressure _
      OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass <> _intClass _
      OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter <> _rodDiameter _
      OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd <> _dblCrossTubeWidth Then

            ' ANUP 19-03-2010 11.00
            '  lvwSafetyFactor_WeightCT_RECT.Items.Clear() MANJULA COMMENTED
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            '  _intSafetyFactorCount = 0 MANJULA COMMENTED
            '***************

            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd _
                       (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, _
                       clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube)

            '17-02-10 Sandeep
            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd _
                   (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, _
                   clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube)
            _dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
            '17-02-10 Sandeep


            _dblTempNutSafetyFactor = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor
            _dblTempPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
            _dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
            _dblWorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure
            _intClass = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass
            _dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd
            _rodDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter


            txtCrossTubeOD_DesignCrossTubeCT_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd
            txtCrossTubeWidth_DesignCrossTubeCT_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd
            txtPinHoleSize_DesignCrossTubeCT_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
            txtSwingClearance_DesignCrossTubeCT_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd

            trbSafetyFactorCT_RECT.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
            trbSafetyFactorCT_RECT.Maximum = trbSafetyFactorCT_RECT.Minimum + 20
            trbSafetyFactorCT_RECT.TickFrequency = 1
            trbSafetyFactorCT_RECT.Value = trbSafetyFactorCT_RECT.Minimum
            txtSafetyFactor_DesignCrossTubeCT_RECT.Text = trbSafetyFactorCT_RECT.Value
        End If


    End Sub

    Private Sub SearchForExistingCrossTube()
        Dim dblRequiredCrossTubeWidth As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd
        Dim dblBushingWidth As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth_RodEnd
        Dim dblBushingQuantity As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity_RodEnd
        Dim dblRequiredPinHoleSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd

        'TODO: ANUP 28-04-2010 01.03pm
        Dim dblRodDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
        Dim dblCalculatedWeldSize As Double = ObjClsWeldedCylinderFunctionalClass.WeldSizeCalculation
        Dim WeldSizeDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWeldSize_ForFabrication(dblRodDiameter, dblCalculatedWeldSize, clsWeldedCylinderFunctionalClass.ConfigurationTypes.CrossTube, clsWeldedCylinderFunctionalClass.WeldType.ManualWeld)

        btnPleaseChangeTheRodDiameter.Visible = False
        Try
            If Not IsNothing(WeldSizeDataTable) AndAlso WeldSizeDataTable.Rows.Count > 0 Then

                Dim oDRWeldSize As DataRow = WeldSizeDataTable.Rows(0)
                If Not IsNothing(oDRWeldSize) AndAlso oDRWeldSize.ItemArray.Length > 0 Then

                    Me.Enabled = True
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.Enabled = True
                    If Not IsDBNull(oDRWeldSize("WeldSize")) Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd = oDRWeldSize("WeldSize")
                    End If
                    If Not IsDBNull(oDRWeldSize("WeldPreparation")) Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldPreperation_RodEnd = oDRWeldSize("WeldPreparation")
                    End If

                    Dim dblJGrooveWidthOrRadius As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetJGroveWidthOrRadius_ForFabrication(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.JGrooveWidth_RodEnd = dblJGrooveWidthOrRadius("Width")
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.JGrooveRadius_RodEnd = dblJGrooveWidthOrRadius("Radius")

                End If
            Else
                ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True 'MANJULA ADDED
                MessageBox.Show("Weld Size exceeds maximum for selected rod, Please change the Rod Diameter.", "Weld Size is maximum", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                Me.Enabled = False
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.Enabled = False
                btnPleaseChangeTheRodDiameter.Visible = True

                btnPleaseChangeTheRodDiameter.BringToFront()
                btnPleaseChangeTheRodDiameter.Location = New Point(142, 193)

            End If

        Catch ex As Exception

        End Try
        '**************



        '17-02-10 Sandeep
        ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd _
               (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, _
               clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube)

        Dim dblRequiredSwingClearance As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
        Dim dblRequiredArea As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd
        '17-02-10 Sandeep


        Dim oCrossTubeDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.RECrossTubeDetails( _
       dblBushingQuantity, dblBushingWidth, dblRequiredPinHoleSize, dblRequiredSwingClearance, dblRequiredCrossTubeWidth)

        _oFilterWithAreaDataTable = New DataTable

        If Not IsNothing(oCrossTubeDataTable) AndAlso oCrossTubeDataTable.Rows.Count > 0 Then

            'TODO:Anup 09-04-10 2pm
            oCrossTubeDataTable.Columns.Add("CalculatedSafetyFactor")
            '*************************

            _oFilterWithAreaDataTable = oCrossTubeDataTable.Clone

            For Each oCrossTubeDataTableDataRow As DataRow In oCrossTubeDataTable.Rows
                oCrossTubeDataTableDataRow("Area") = Math.Round((oCrossTubeDataTableDataRow("Diameter") - dblRequiredPinHoleSize) * oCrossTubeDataTableDataRow("Width"), 2)
            Next


            For Each oFilterWithAreaDataRow As DataRow In oCrossTubeDataTable.Rows

                'TODO:Anup 09-04-10 2pm
                oFilterWithAreaDataRow("CalculatedSafetyFactor") = Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor + (oFilterWithAreaDataRow("Area") / dblRequiredArea), 2) - 1
                '*************************

                If Not IsDBNull(oFilterWithAreaDataRow("Area")) Then '
                    If Val(oFilterWithAreaDataRow("Area")) >= dblRequiredArea Then
                        _oFilterWithAreaDataTable.Rows.Add(oFilterWithAreaDataRow.ItemArray)
                    End If
                End If

            Next

            If Not IsNothing(_oFilterWithAreaDataTable) AndAlso _oFilterWithAreaDataTable.Rows.Count > 0 Then
                grbMatchedCrossTubeFound_RECT.Visible = True
                grbMatchedCrossTubeNotFound_RECT.Visible = False
                PopulateDataInListView()
                chkUseSelectedCrossTube_RECT.Checked = True 'anup 0302-2010 
            Else
                lvwExistingCrossTubeListView_RECT.Clear()
                grbMatchedCrossTubeFound_RECT.Visible = False
                grbMatchedCrossTubeNotFound_RECT.Visible = True
                Try
                    ObjClsWeldedCylinderFunctionalClass.ObjClsExcelClass.checkExcelInstance()
                    ObjClsWeldedCylinderFunctionalClass.WriteGUIDataToExcel()
                Catch ex As Exception

                End Try

            End If
        Else
            lvwExistingCrossTubeListView_RECT.Clear()
            grbMatchedCrossTubeFound_RECT.Visible = False
            grbMatchedCrossTubeNotFound_RECT.Visible = True

        End If
    End Sub

    Private Sub PopulateDataInListView()

        lvwExistingCrossTubeListView_RECT.Clear()
        lvwExistingCrossTubeListView_RECT.Columns.Add("Code No", 100, HorizontalAlignment.Center)
        lvwExistingCrossTubeListView_RECT.Columns.Add("Description", 245, HorizontalAlignment.Center)

        'TODO:Anup 09-04-10 2pm
        lvwExistingCrossTubeListView_RECT.Columns.Add("SafetyFactor", 100, HorizontalAlignment.Center)
        '***********

        lvwExistingCrossTubeListView_RECT.Columns.Add("Cost", 100, HorizontalAlignment.Center)
        lvwExistingCrossTubeListView_RECT.Columns.Add("Sales", 100, HorizontalAlignment.Center)        '28_11_2012   RAGAVA

        Dim intCount As Integer = 0
        Dim oListItem As ListViewItem

        'ANUP 07-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Count > 0 Then
            ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Clear()
        End If
        'ANUP 07-10-2010 TILL HERE 

        For Each oFilterWithAreaDataRow As DataRow In _oFilterWithAreaDataTable.Rows
            Dim strPartCode_Purchase As String = String.Empty
            If Not IsDBNull(oFilterWithAreaDataRow("PartCode")) Then

                'ANUP 07-10-2010 START
                strPartCode_Purchase = ObjClsWeldedCylinderFunctionalClass.PartCOde_Purchased_ListViewClickedValidation(oFilterWithAreaDataRow("PartCode"))
                oListItem = lvwExistingCrossTubeListView_RECT.Items.Add(strPartCode_Purchase)
                'ANUP 07-10-2010 TILL HERE

            End If

            If Not IsDBNull(oFilterWithAreaDataRow("Description")) Then
                lvwExistingCrossTubeListView_RECT.Items(intCount).SubItems.Add(oFilterWithAreaDataRow("Description"))
            End If


            '31_05_2011  RAGAVA
            Try
                Dim dblSafetyFactor As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SetSafetyFactorForExisting_RodEnd(strPartCode_Purchase)
                If dblSafetyFactor > 0 Then
                    lvwExistingCrossTubeListView_RECT.Items(intCount).SubItems.Add(dblSafetyFactor.ToString)
                Else
                    If Not IsDBNull(oFilterWithAreaDataRow("CalculatedSafetyFactor")) Then
                        lvwExistingCrossTubeListView_RECT.Items(intCount).SubItems.Add(oFilterWithAreaDataRow("CalculatedSafetyFactor"))
                    Else
                        lvwExistingCrossTubeListView_RECT.Items(intCount).SubItems.Add("")
                    End If
                End If
            Catch ex As Exception
            End Try
            ''TODO:Anup 09-04-10 2pm
            'If Not IsDBNull(oFilterWithAreaDataRow("CalculatedSafetyFactor")) Then
            '    lvwExistingCrossTubeListView_RECT.Items(intCount).SubItems.Add(oFilterWithAreaDataRow("CalculatedSafetyFactor"))
            'Else
            '    lvwExistingCrossTubeListView_RECT.Items(intCount).SubItems.Add("")
            'End If
            ''***************
            'TILL   HERE

            '28_11_2012  RAGAVA
            Try
                ObjClsWeldedCylinderFunctionalClass.GetCost_Sales(oFilterWithAreaDataRow("PartCode"), lvwExistingCrossTubeListView_RECT, intCount)
            Catch ex As Exception

            End Try
            'If Not IsDBNull(oFilterWithAreaDataRow("Cost")) Then
            '    lvwExistingCrossTubeListView_RECT.Items(intCount).SubItems.Add(oFilterWithAreaDataRow("Cost"))
            'End If
            'Till   Here

            intCount += 1
        Next
        lvwExistingCrossTubeListView_RECT.Items(0).Selected = True
        lvwExistingCrossTubeListView_RECT.HideSelection = False
        lvwExistingCrossTubeListView_RECT.FullRowSelect = True

    End Sub

    Public Sub LoadFunctionality()
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        LoadDefaultValues()
        SearchForExistingCrossTube()

    End Sub
    Public Sub ManualLoad()
        LoadFunctionality()
    End Sub

    Private Sub WidthCalculation()

        Dim dblSafetyFactor As Double = trbSafetyFactorCT_RECT.Minimum + ((trbSafetyFactorCT_RECT.Value - trbSafetyFactorCT_RECT.Minimum) * 0.25)
        txtSafetyFactor_DesignCrossTubeCT_RECT.Text = dblSafetyFactor
        ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd(dblSafetyFactor, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube)
        'txtCrossTubeOD_DesignCrossTubeCT_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD
        txtCrossTubeOD_DesignCrossTubeCT_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd    '02_02_2011   RAGAVA
    End Sub

#End Region

#Region "Events"
    Private Sub frmFabrication_RECT_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ColorTheForm()
        DefaultSettings()
        LoadFunctionality()

    End Sub

    Private Sub lvwExistingCrossTubeListView_RECT_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwExistingCrossTubeListView_RECT.SelectedIndexChanged
        'ANUP 10-11-2010 START
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        rdbExactMatchYes.Checked = False
        rdbResize_RECT.Checked = False
        'ANUP 10-11-2010 TILL HERE
        If lvwExistingCrossTubeListView_RECT.SelectedIndices.Count > 0 Then

            If chkUseSelectedCrossTube_RECT.Checked = True Then
                ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
            End If

            Dim oListViewSelectedItem As ListViewItem = lvwExistingCrossTubeListView_RECT.SelectedItems(0)
            Dim oSelectedCrossTubeDataRow As DataRow = Nothing

            'ANUP 07-10-2010 START
            Dim strPartCodePassing_Purchased As String = oListViewSelectedItem.SubItems(CrossTubeListViewDetails.CodeNumber).Text
            Try
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_RodEnd = oListViewSelectedItem.SubItems(2).Text      '31_05_2011   ragava
            Catch ex As Exception
            End Try
            ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode = strPartCodePassing_Purchased         '12_10_2010   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.ContainsKey(strPartCodePassing_Purchased) Then
                strPartCodePassing_Purchased = ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Item(strPartCodePassing_Purchased).ToString
            End If

            oSelectedCrossTubeDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
           GetRECrossTubeDetailsSelectedRowDetails(strPartCodePassing_Purchased)

            If Not IsNothing(oSelectedCrossTubeDataRow) Then

                If Not IsDBNull(oSelectedCrossTubeDataRow("PartCode")) Then
                    _strCrossTubeCode = oListViewSelectedItem.SubItems(CrossTubeListViewDetails.CodeNumber).Text
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("CrossTubeCode", oListViewSelectedItem.SubItems(CrossTubeListViewDetails.CodeNumber).Text)
                    '1_03_2010 Aruna
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = oSelectedCrossTubeDataRow("PartCode")
                End If
            End If
            'ANUP 07-10-2010 TILL HERE

            If Not IsDBNull(oSelectedCrossTubeDataRow("Diameter")) Then
                txtCrossTubeOD_RECT.Text = oSelectedCrossTubeDataRow("Diameter")
                txtSwingClearance_RECT.Text = Math.Round(Val(txtCrossTubeOD_RECT.Text) / 2, 2)
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd = txtSwingClearance_RECT.Text
            End If

            If Not IsDBNull(oSelectedCrossTubeDataRow("Width")) Then
                txtCrossTubeWidth_RECT.Text = oSelectedCrossTubeDataRow("Width")
            End If

            'txtSwingClearance_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd

            If Not IsDBNull(oSelectedCrossTubeDataRow("Cost")) Then
                txtCost_RECT.Text = oSelectedCrossTubeDataRow("Cost")
            End If
            '8_3_2010 Aruna
            If Not IsDBNull(oSelectedCrossTubeDataRow("PinHoleCombined")) Then
                txtPinHoleSize_RECT.Text = oSelectedCrossTubeDataRow("PinHoleCombined")
            End If

            'If Not IsDBNull(oSelectedCrossTubeDataRow("GreaseZerk")) Then
            '    txtGreaseZerk_RECT.Text = oSelectedCrossTubeDataRow("GreaseZerk")
            'End If

            If Not IsDBNull(oSelectedCrossTubeDataRow("GreaseZerkAngle1")) Then
                'txtAngle1_RECT.Text = Val(oSelectedCrossTubeDataRow("GreaseZerkAngle1")) / 2
                txtAngle1_RECT.Text = oSelectedCrossTubeDataRow("GreaseZerkAngle1")
            End If

            If Not IsDBNull(oSelectedCrossTubeDataRow("GreaseZerkAngle2")) Then
                'txtAngle2_RECT.Text = Val(oSelectedCrossTubeDataRow("GreaseZerkAngle2")) / 2
                txtAngle2_RECT.Text = oSelectedCrossTubeDataRow("GreaseZerkAngle2")
            End If

            txtGreaseZerk_RECT.Text = ObjClsWeldedCylinderFunctionalClass.GetGreekZercQty(txtAngle1_RECT.Text, txtAngle2_RECT.Text)

            DisplayToleranceValues(oSelectedCrossTubeDataRow)

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = Val(txtCrossTubeOD_RECT.Text) / 2 'oSelectedCastingDataRow("DistancefromPinholetoRodStop")
            If oSelectedCrossTubeDataRow("PartType").ToString.Contains("IFL_PART") Then
                ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "IFL_Designed_Existing"
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "NewDesign" '1_03_2010

                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "Rod_Crosstube_IFL"
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "Existing"
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "Base_Cross_Tube"
            End If
            '1_03_2010 Aruna
            ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated"
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Fabricated"

            UpdatePreviousFormDetails()
        Else
            _strCrossTubeCode = ""
            txtCrossTubeOD_RECT.Text = ""
            txtCrossTubeWidth_RECT.Text = ""
            txtSwingClearance_RECT.Text = ""
            txtCost_RECT.Text = ""
            txtPinHoleTole_Neg.Text = ""
            txtPinHoleTole_Pos.Text = ""
        End If

    End Sub

    'ONSITE:20-05-2010 assign  the tolerance data to GUI fields
    Private Sub DisplayToleranceValues(ByVal oRow As DataRow)
        'Positive tolerance
        If Not IsDBNull(oRow("PinHoleCustomUpperTolerance")) Then
            If oRow("PinHoleCustomUpperTolerance").Equals("N/A") Then
                txtPinHoleTole_Pos.Text = "0.010"
            Else
                txtPinHoleTole_Pos.Text = oRow("PinHoleCustomUpperTolerance")
            End If
        End If
        'Negative Tolerance
        If Not IsDBNull(oRow("PinHoleCustomLowerTolerance")) Then
            If oRow("PinHoleCustomLowerTolerance").Equals("N/A") Then
                txtPinHoleTole_Neg.Text = 0.005
            Else
                txtPinHoleTole_Neg.Text = oRow("PinHoleCustomLowerTolerance")
            End If
        End If
    End Sub

    Private Sub trbSafetyFactorCT_RECT_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trbSafetyFactorCT_RECT.Scroll
        btnAcceptCT_RECT.Enabled = False
        WidthCalculation()
    End Sub

    Private Sub btnGenerateCT_RECT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateCT_RECT.Click
        '15_02_2010  Aruna Start
        Try
            btnAcceptCT_RECT.Enabled = True
            Me.Cursor = Cursors.WaitCursor
            Dim strFilePart As String = ""
            Dim strFilePartDesignTableExcel As String = ""
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Fabricated"
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = Val(txtCrossTubeOD_DesignCrossTubeCT_RECT.Text) / 2
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd = Val(txtCrossTubeOD_DesignCrossTubeCT_RECT.Text)
            strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_CROSSTUBE\Rod_Crosstube_IFL.SLDPRT"
            strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\ROD_CROSSTUBE.xls"
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "ROD_CROSSTUBE_IFL"            '25_07_2012    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.Design_New_Part(strFilePart, strFilePartDesignTableExcel, "NewCrossTubeFabrication")
            Dim dblWeight As Double = ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Weight")
            'Aruna 19_3_2010
            ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BASE_CROSSTUBE", True)
            Dim blnDuplicateFound As Boolean = False
            If lvwSafetyFactor_WeightCT_RECT.Items.Count > 0 Then
                For Each oItem As ListViewItem In lvwSafetyFactor_WeightCT_RECT.Items
                    If oItem.SubItems(WeightListView.SafetyFactor).Text.Equals(txtSafetyFactor_DesignCrossTubeCT_RECT.Text) AndAlso _
                     oItem.SubItems(WeightListView.CrossTubeWidth).Text.Equals(txtSafetyFactor_DesignCrossTubeCT_RECT.Text) Then
                        blnDuplicateFound = True
                    End If
                Next
            End If
            If Not blnDuplicateFound Then
                Dim oListViewItem As ListViewItem
                oListViewItem = lvwSafetyFactor_WeightCT_RECT.Items.Add(txtSafetyFactor_DesignCrossTubeCT_RECT.Text)
                lvwSafetyFactor_WeightCT_RECT.Items(_intSafetyFactorCount).SubItems.Add(txtCrossTubeWidth_DesignCrossTubeCT_RECT.Text)
                lvwSafetyFactor_WeightCT_RECT.Items(_intSafetyFactorCount).SubItems.Add(dblWeight)
                _intSafetyFactorCount += 1
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in btnGenerate_Click of frmSLDesignACasting " + ex.Message)
        End Try
        '15_02_2010  Aruna End
    End Sub

    Private Sub btnAcceptCT_RECT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcceptCT_RECT.Click
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndFabricationSelected = True            '24_07_2012   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = Val(txtCrossTubeOD_DesignCrossTubeCT_RECT.Text) / 2
        ' ObjClsWeldedCylinderFunctionalClass.TxtCrossTubeWidth_BaseEnd.Text = txtCrossTubeOD_DesignCrossTubeCT_RECT.Text
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "NewDesign" '1_03_2010
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Fabricated"
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = False        '15_02_2011   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = ""                                      '15_02_2011   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        btnAcceptCT_RECT.Enabled = False
        If txtSafetyFactor_DesignCrossTubeCT_RECT.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_RodEnd = txtSafetyFactor_DesignCrossTubeCT_RECT.Text         '31_05_2011  RAGAVA
        End If
        '24-05-2012 MANJULA ADDED
        ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT._dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd
        'ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT2._dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd       '31_08_2012   RAGAVA  Commented   Weldment
        ObjClsWeldedCylinderFunctionalClass.ObjFrmRECrossTube._dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd
        'ObjClsWeldedCylinderFunctionalClass.ObjFrmRECrossTube2._dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd       '31_08_2012   RAGAVA  Commented   Weldment
        '**********************
    End Sub

    Private Sub txtCrossTubeWidth_DesignCrossTubeCT_RECT_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCrossTubeWidth_DesignCrossTubeCT_RECT.Leave

        If txtCrossTubeWidth_DesignCrossTubeCT_RECT.Text <> "" Then
            If txtCrossTubeWidth_DesignCrossTubeCT_RECT.Text <> txtCrossTubeWidth_DesignCrossTubeCT_RECT.IFLDataTag Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd = Val(txtCrossTubeWidth_DesignCrossTubeCT_RECT.Text)         '25_07_2012   RAGAVA
                txtCrossTubeWidth_DesignCrossTubeCT_RECT.IFLDataTag = txtCrossTubeWidth_DesignCrossTubeCT_RECT.Text
                trbSafetyFactorCT_RECT.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
                trbSafetyFactorCT_RECT.Maximum = trbSafetyFactorCT_RECT.Minimum + 20
                trbSafetyFactorCT_RECT.TickFrequency = 1
                trbSafetyFactorCT_RECT.Value = trbSafetyFactorCT_RECT.Minimum
                txtSafetyFactor_DesignCrossTubeCT_RECT.Text = trbSafetyFactorCT_RECT.Value

                ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd _
                (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, _
                clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube)

                txtCrossTubeOD_DesignCrossTubeCT_RECT.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd       '02_02_2011   RAGAVA
                btnAcceptCT_RECT.Enabled = False
            End If
        Else
            txtCrossTubeWidth_DesignCrossTubeCT_RECT.IFLDataTag = ""

        End If
    End Sub
    Private Sub chkUseSelectedCrossTube_RECT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseSelectedCrossTube_RECT.CheckedChanged
        grbUsingSelectedCrossTube_RECT.Visible = False
        If chkUseSelectedCrossTube_RECT.Checked Then
            'grbUsingSelectedCrossTube_RECT.Visible = True
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
            rdbExactMatchYes.Checked = True
        Else
            'grbUsingSelectedCrossTube_RECT.Visible = False
            ActivateNewDesignGroupBox()
            'ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True

        End If
    End Sub

    'Private Sub chkExactMatch_RECT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If chkExactMatch_RECT.Checked Then
    '        grbNotExactMatch_RECT.Visible = False
    '        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
    '        btnMessageExactMatch_RECT.Location = New Point(126, 100)
    '    Else
    '        grbNotExactMatch_RECT.Visible = True
    '        btnMessageExactMatch_RECT.Location = New Point(126, 121)
    '    End If
    'End Sub

    Private Sub lvwSafetyFactor_WeightCT_RECT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwSafetyFactor_WeightCT_RECT.SelectedIndexChanged

        If lvwSafetyFactor_WeightCT_RECT.SelectedIndices.Count > 0 Then
            Dim oListViewSelectedItem As ListViewItem = lvwSafetyFactor_WeightCT_RECT.SelectedItems(0)
            trbSafetyFactorCT_RECT.Value = ((Val(oListViewSelectedItem.SubItems(WeightListView.SafetyFactor).Text) - trbSafetyFactorCT_RECT.Minimum) / 0.25) + trbSafetyFactorCT_RECT.Minimum
            txtCrossTubeWidth_DesignCrossTubeCT_RECT.Text = oListViewSelectedItem.SubItems(WeightListView.CrossTubeWidth).Text
            btnAcceptCT_RECT.Enabled = True
            ObjClsWeldedCylinderFunctionalClass.RodEndWeight = Val(oListViewSelectedItem.SubItems(WeightListView.Weight).Text)
        End If
    End Sub

    'Private Sub rdbNewCasting_RECT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbNewCasting_RECT.CheckedChanged
    '    '26_02_2010 Aruna Start
    '    ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = ""    '03_03_2010    ARUNA
    '    If rdbNewCasting_RECT.Checked Then
    '        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "NewDesign"
    '        UpdatePreviousFormDetails()
    '        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
    '    End If
    '    '26_02_2010 Aruna Ends
    'End Sub

    'TODO: ANUP 20-05-2010
    Private Sub rdbNewCasting_RECT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbNewCasting_RECT.CheckedChanged
        '26_02_2010 Aruna Start
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = ""    '03_03_2010    ARUNA
        If rdbNewCasting_RECT.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = False        '20_10_2010    RAGAVA
            ActivateNewDesignGroupBox()
        End If
        '26_02_2010 Aruna Ends
    End Sub
    '***********************
    'ONSITE:21-05-2010
    Private Sub ActivateNewDesignGroupBox()
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "NewDesign"
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = False          '14_02_2011   RAGAVA
        Dim strMessage As String = "Click OK to go to the CrossTube Design screens "
        If MessageBox.Show(strMessage, "Design CrossTube", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.OK Then
            grbMatchedCrossTubeFound_RECT.Hide()
            grbMatchedCrossTubeNotFound_RECT.Show()
            grbMatchedCrossTubeNotFound_RECT.BringToFront()
        Else
            rdbNewCasting_RECT.Checked = False
        End If
    End Sub

    Private Sub rdbExactMatchYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbExactMatchYes.CheckedChanged
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = ""    '03_03_2010    ARUNA
        If rdbExactMatchYes.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndFabricationSelected = False        '24_07_2012   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = True        '20_10_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "Exact"
            ' grbNotExactMatch_RECT.Visible = False '5_3_2010 Aruna
            UpdatePreviousFormDetails()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        End If
        '26_02_2010 Aruna Ends
    End Sub

    Private Sub rdbExactMatchNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '5_3_2010 Aruna
        'If rdbExactMatchNo.Checked Then
        '    grbNotExactMatch_RECT.Visible = True
        'End If

    End Sub

    Private Sub rdbResize_RECT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbResize_RECT.CheckedChanged
        '26_02_2010 Aruna Start
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = ""    '03_03_2010    ARUNA
        If rdbResize_RECT.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = True        '20_10_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "Resize"
            UpdatePreviousFormDetails()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        End If
        '26_02_2010 Aruna Ends
    End Sub
    '26_02_2010 Aruna Start
    Private Sub UpdatePreviousFormDetails()
        'Dim strMessage As String = "Rod end Configuration Details will be updated with the selected Cross Tube Fabrication details, " + vbCrLf
        'If MessageBox.Show(strMessage, "Update TubeDetails", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then

        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True

        If txtCrossTubeOD_RECT.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd = Val(txtCrossTubeOD_RECT.Text)
        End If

        If txtCrossTubeWidth_RECT.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd = Val(txtCrossTubeWidth_RECT.Text)
        End If

        If txtSwingClearance_RECT.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd = Val(txtSwingClearance_RECT.Text)
        End If
        'ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = ""    '03_03_2010    RAGAVA
        If rdbExactMatchYes.Checked Then
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "Exact"
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        ElseIf rdbNewCasting_RECT.Checked Then
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "NewDesign"
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        End If

        '24-05-2012 MANJULA ADDED
        ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT._dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd
        'ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT2._dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd       '31_08_2012   RAGAVA  Commented   Weldment
        ObjClsWeldedCylinderFunctionalClass.ObjFrmRECrossTube._dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd
        'ObjClsWeldedCylinderFunctionalClass.ObjFrmRECrossTube2._dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd       '31_08_2012   RAGAVA  Commented   Weldment
        '**********************

        'End If
    End Sub
    '26_02_2010 Aruna Ends

    Private Sub txtAngle1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAngle1_RECT.TextChanged

    End Sub

    Private Sub txtAngle2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAngle2_RECT.TextChanged

    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblDesignNewCrossTube_RECT)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblSafetyFactorIndexCT_RECT)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblExistingULugsDetails_RECT)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblShowImage_RECT)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblUsingSelectedCrossTube_RECT)
    End Sub
End Class