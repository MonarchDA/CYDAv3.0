Imports System.IO
Imports System.Data

Public Class frmREDLCasting

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

    Private _dblTempNutSafetyFactor As Double = 0

    Private _dblTempPinHoleSize As Double = 0

    Private _dblTempSwingClearance As Double = 0

    Private _dblWorkingPressure As Double = 0

    Private _intClass As Integer = 0

    Private _dblLugThickness As Double = 0

    Private _intSafetyFactorCount As Integer = 0


#End Region

#Region "Enum"

    Public Enum DoubleLugListViewDetails
        CodeNumber = 0
        Description = 1
        Cost = 2
    End Enum

    Public Enum WeightListView
        SafetyFactor = 0
        LugThickness_REDL = 1
        Weight = 2
    End Enum
#End Region

#Region "Subprocedures"

    Public Sub ManualLoad()
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Casting"       '18_03_2010   RAGAVA 'Sunny 11-05-10
        SearchForExistingDoubleLugCastingDetails()
    End Sub

#Region "CastingYesDetailsSubProcedures"

    Private Sub InitialSettings()
        txtCodeNumber_DLCasting.Enabled = False
        txtSwingClearance_DLCasting.Enabled = False
        txtRequiredSwingClearance_DLCasting.Enabled = False
        txtLugThickness_DLCasting.Enabled = False
        txtRequiredLugThickness_DLCasting.Enabled = False
        txtPinHoleSize_DLCasting.Enabled = False
        txtRequiredPinHoleSize_DLCasting.Enabled = False
        txtLugGap_DLCasting.Enabled = False
        txtRequiredLugGap_DLCasting.Enabled = False
        txtLugWidth_DLCasting.Enabled = False
        txtWeldSize_DLCasting.Enabled = False

        txtRequiredSwingClearance_DLCasting.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
        txtRequiredLugThickness_DLCasting.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
        txtRequiredPinHoleSize_DLCasting.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
        txtRequiredLugGap_DLCasting.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd
        txtRequiredLugGap_DLCasting.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd

        'TODO:Anup 27-02-2010
        rdbUseSelectedSingleLugYes.Checked = True
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        ' Anup END
    End Sub

    Private Sub SearchForExistingDoubleLugCastingDetails()
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        Dim dblRodDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
        Dim dblBushingWidth As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth_RodEnd
        Dim dblRequiredLugThickness As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
        Dim dblRequiredPinHoleSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
        Dim dblBushingQuantity As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity_RodEnd

        'ANUP 17-09-2010 START
        'Dim dblSwingClearance As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
        Dim dblSwingClearance As Double = Val(ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Text)
        'ANUP 17-09-2010 TILL HERE


        Dim dblLugGap As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd


        'TODO: ANUP 28-04-2010 01.03pm
        Dim dblCalculatedWeldSize As Double = ObjClsWeldedCylinderFunctionalClass.WeldSizeCalculation
        Dim WeldSizeDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWeldSize_ForCasting(dblCalculatedWeldSize, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter)

        If Not IsNothing(WeldSizeDataTable) AndAlso Not WeldSizeDataTable.Rows.Count <= 0 Then

            Dim oDRWeldSize As DataRow = WeldSizeDataTable.Rows(0)
            If Not IsNothing(oDRWeldSize) OrElse oDRWeldSize.ItemArray.Length <= 0 Then

                If Not IsDBNull(oDRWeldSize(0)) Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd = oDRWeldSize(0)
                End If
                If Not IsDBNull(oDRWeldSize(1)) Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.JGrooveWidth_RodEnd = oDRWeldSize(1)
                End If
                If Not IsDBNull(oDRWeldSize(2)) Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.JGrooveRadius_RodEnd = oDRWeldSize(2)
                End If
                Me.Enabled = True
                btnPleaseChangeTheRodDiameter.Visible = False
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.Enabled = True
                ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
            End If
        Else
            MessageBox.Show("Weld Size exceeds maximum for selected rod, Please change the Rod Diameter.", "Weld Size is maximum", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.Enabled = False
            btnPleaseChangeTheRodDiameter.Visible = True
            Me.Enabled = False
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            btnPleaseChangeTheRodDiameter.BringToFront()
            btnPleaseChangeTheRodDiameter.Location = New Point(142, 193)
        End If


        '************

        Dim oREDLCastingDetails As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
       REDLCastingDetails(dblRodDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd, dblBushingWidth, dblRequiredPinHoleSize, dblBushingQuantity, dblRequiredLugThickness, _
       dblLugGap, dblSwingClearance)

        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedREDLCastingDataTable = New DataTable
        If Not IsNothing(oREDLCastingDetails) Then

            'TODO:Anup 09-04-10 2pm
            oREDLCastingDetails.Columns.Add("CalculatedSafetyFactor")
            '*************************

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedREDLCastingDataTable = oREDLCastingDetails.Clone

            For Each oDataRow As DataRow In oREDLCastingDetails.Rows
                oDataRow("Area") = 2 * oDataRow("LugThickness") * (oDataRow("LugWidth") - dblRequiredPinHoleSize)
            Next
            For Each oDataRow As DataRow In oREDLCastingDetails.Rows
                ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd _
                (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, oDataRow("YieldStrength"))
                Dim dblRequiredArea As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired_RodEnd

                'TODO:Anup 09-04-10 2pm
                oDataRow("CalculatedSafetyFactor") = Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor + (oDataRow("Area") / dblRequiredArea), 2) - 1
                '*************************

                If Not IsDBNull(oDataRow("Area")) Then
                    If Val(oDataRow("Area")) >= dblRequiredArea Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedREDLCastingDataTable.Rows.Add(oDataRow.ItemArray)
                    End If
                End If
            Next
        End If

        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedREDLCastingDataTable.Rows.Count > 0 Then
            pnlREDLCastingNo.Hide()
            pnlREDLCastingYes.Show()
            InitialSettings()
            PopulateInListView()
        Else
            pnlREDLCastingYes.Hide()
            pnlREDLCastingNo.Show()
            DACInitialSettings()
            DACLoadFunctionality()
        End If
    End Sub

    Private Sub PopulateInListView()
        lvwDLCastingDetails.Clear()
        lvwDLCastingDetails.Columns.Add("Code No", 100, HorizontalAlignment.Center)
        lvwDLCastingDetails.Columns.Add("Description", 220, HorizontalAlignment.Center)

        'TODO:Anup 09-04-10 2pm
        lvwDLCastingDetails.Columns.Add("SafetyFactor", 100, HorizontalAlignment.Center)
        '***********

        lvwDLCastingDetails.Columns.Add("Cost", 100, HorizontalAlignment.Center)
        lvwDLCastingDetails.Columns.Add("Sales", 100, HorizontalAlignment.Center)        '28_11_2012   RAGAVA
        '<<--20-12-2010 Aruna--
        lvwDLCastingDetails.Columns.Add("Is Existed", 45, HorizontalAlignment.Center)
        '--20-12-2010 Aruna-->>

        Dim intCount As Integer = 0
        Dim oListItem As ListViewItem
        _oMatchedCastingDataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedREDLCastingDataTable
        If Not IsNothing(_oMatchedCastingDataTable) AndAlso _oMatchedCastingDataTable.Rows.Count > 0 Then
            Dim strPartCode_Purchase As String = String.Empty
            'ANUP 07-10-2010 START
            If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Count > 0 Then
                ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Clear()
            End If
            'ANUP 07-10-2010 TILL HERE 

            For Each _oMatchedCastingDataRow As DataRow In _oMatchedCastingDataTable.Rows
                If Not IsDBNull(_oMatchedCastingDataRow("PartCode")) Then

                    'ANUP 07-10-2010 START
                    strPartCode_Purchase = ObjClsWeldedCylinderFunctionalClass.PartCOde_Purchased_ListViewClickedValidation(_oMatchedCastingDataRow("PartCode"))
                    If Trim(strPartCode_Purchase) = "" Then
                        lvwDLCastingDetails.Items(intCount).SubItems.Add(_oMatchedCastingDataRow("PartCode"))
                    Else
                        oListItem = lvwDLCastingDetails.Items.Add(strPartCode_Purchase)
                    End If
                    'ANUP 07-10-2010 TILL HERE
                End If

                If Not IsDBNull(_oMatchedCastingDataRow("Description")) Then
                    lvwDLCastingDetails.Items(intCount).SubItems.Add(_oMatchedCastingDataRow("Description"))
                End If


                '31_05_2011  RAGAVA
                Try
                    Dim dblSafetyFactor As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SetSafetyFactorForExisting_RodEnd(strPartCode_Purchase)
                    If dblSafetyFactor > 0 Then
                        lvwDLCastingDetails.Items(intCount).SubItems.Add(dblSafetyFactor.ToString)
                    Else
                        If Not IsDBNull(_oMatchedCastingDataRow("CalculatedSafetyFactor")) Then
                            lvwDLCastingDetails.Items(intCount).SubItems.Add(_oMatchedCastingDataRow("CalculatedSafetyFactor"))
                        Else
                            lvwDLCastingDetails.Items(intCount).SubItems.Add("")
                        End If
                    End If
                Catch ex As Exception
                End Try
                ''TODO:Anup 09-04-10 2pm
                'If Not IsDBNull(_oMatchedCastingDataRow("CalculatedSafetyFactor")) Then
                '    lvwDLCastingDetails.Items(intCount).SubItems.Add(_oMatchedCastingDataRow("CalculatedSafetyFactor"))
                'Else
                '    lvwDLCastingDetails.Items(intCount).SubItems.Add("")
                'End If
                ''***************
                'TILL   HERE

                '28_11_2012  RAGAVA
                Try
                    ObjClsWeldedCylinderFunctionalClass.GetCost_Sales(_oMatchedCastingDataRow("PartCode"), lvwDLCastingDetails, intCount)
                Catch ex As Exception

                End Try
                'If Not IsDBNull(_oMatchedCastingDataRow("Cost")) Then
                '    lvwDLCastingDetails.Items(intCount).SubItems.Add(_oMatchedCastingDataRow("Cost"))
                'End If
                'Till   Here

                '<<--20-12-2010 Aruna--
                If Not IsDBNull(_oMatchedCastingDataRow("IsExisted")) Then
                    If _oMatchedCastingDataRow("IsExisted") = True Then
                        lvwDLCastingDetails.Items(intCount).SubItems.Add("Yes")
                    Else
                        lvwDLCastingDetails.Items(intCount).SubItems.Add("No")
                    End If
                Else
                    lvwDLCastingDetails.Items(intCount).SubItems.Add("No")
                End If
                '--20-12-2010 Aruna-->>

                intCount += 1
            Next
        End If
        lvwDLCastingDetails.HideSelection = False
        lvwDLCastingDetails.FullRowSelect = True
    End Sub

    'TODO:Anup 26-02-2010

    Private Sub UpdatePreviousFormDetails()

        Dim strMessage As String = "Rod end Configuration Details will be updated with the selected DoubleLug casting details, " + vbCrLf
        If MessageBox.Show(strMessage, "Update TubeDetails", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
            If txtSwingClearance_DLCasting.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text = txtSwingClearance_DLCasting.Text
            End If

            If txtLugThickness_DLCasting.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd.Text = txtLugThickness_DLCasting.Text
            End If

            If ObjClsWeldedCylinderFunctionalClass.PinHoleSize_Source = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.BushingPinHole Then
                If txtPinHoleSize_DLCasting.Text <> "" Then
                    ObjClsWeldedCylinderFunctionalClass.CmbBushingPinHoleSize_BaseEnd.Text = txtPinHoleSize_DLCasting.Text
                End If
            ElseIf ObjClsWeldedCylinderFunctionalClass.PinHoleSize_Source = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleCustom Then
                If txtPinHoleSize_DLCasting.Text <> "" Then
                    ObjClsWeldedCylinderFunctionalClass.TxtPinHoleSize_BaseEnd.Text = txtPinHoleSize_DLCasting.Text
                End If
            ElseIf ObjClsWeldedCylinderFunctionalClass.PinHoleSize_Source = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleStandard Then
                If txtPinHoleSize_DLCasting.Text <> "" Then
                    ObjClsWeldedCylinderFunctionalClass.CmbPinHoleSize_BaseEnd.Text = txtPinHoleSize_DLCasting.Text
                End If
            End If

            If txtLugGap_DLCasting.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtLugGap_BaseEnd.Text = txtLugGap_DLCasting.Text
            End If

            If txtLugWidth_DLCasting.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd = Val(txtLugWidth_DLCasting.Text)
            End If

            If txtWeldSize_DLCasting.Text <> "" Then
                'ANUP 16-11-2010 START
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEndDL = Val(txtWeldSize_DLCasting.Text)
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd = Val(txtWeldSize_DLCasting.Text)
                'ANUP 16-11-2010 TILL HERE
            End If

            'anup 31-08-2010

            ObjClsWeldedCylinderFunctionalClass.TxtToleranceUpperLimit_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit
            ObjClsWeldedCylinderFunctionalClass.TxtToleranceLowerLimit_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit


        End If
    End Sub

    'Anup END

#End Region

#Region "DesignACastingSubProcedures"

    Private Sub DACInitialSettings()

        txtLugGap_REDL.Enabled = False
        txtLugWidth_REDL.Enabled = False
        txtLugThickness_REDL.Enabled = True
        txtPinHoleSize_REDL.Enabled = False
        txtSwingClearance_REDL.Enabled = False
        btnAccept_REDL.Enabled = False
        txtSafetyFactorOfCasting_REDL.Enabled = False

        SafetyFactor_LugThickness_Weight_GeneretedDesign()

        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
    End Sub

    Private Sub SafetyFactor_LugThickness_Weight_GeneretedDesign()
        lvwREDLSafetyFactor_Weight.Clear()
        lvwREDLSafetyFactor_Weight.Columns.Add("SafetyFactor", 130, HorizontalAlignment.Center)
        lvwREDLSafetyFactor_Weight.Columns.Add("LugThickness", 130, HorizontalAlignment.Center)
        lvwREDLSafetyFactor_Weight.Columns.Add("Weight", 125, HorizontalAlignment.Center)
        lvwREDLSafetyFactor_Weight.FullRowSelect = True
    End Sub

    Private Sub WidthCalculation()
        Dim dblSafetyFactor As Double = trbSafetyFactor_REDL.Minimum + ((trbSafetyFactor_REDL.Value - trbSafetyFactor_REDL.Minimum) * 0.25)
        txtSafetyFactorOfCasting_REDL.Text = dblSafetyFactor
        ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd(dblSafetyFactor, _
        clsWeldedCylinderFunctionalClass.YeildStrengthConstants.DoubleLug_Cast_NoPort)
        txtLugWidth_REDL.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd
    End Sub

    Private Sub DACLoadFunctionality()

        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor <> _dblTempNutSafetyFactor _
               OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd <> _dblTempPinHoleSize _
               OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd <> _dblTempSwingClearance _
               OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure <> _dblWorkingPressure _
               OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass <> _intClass _
                OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd <> _dblLugThickness Then
            _dblTempNutSafetyFactor = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor
            _dblTempPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd

            'ANUP 17-09-2010 START
            '_dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd
            _dblTempSwingClearance = Val(ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Text)
            'ANUP 17-09-2010 TILL HERE

            _dblWorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure
            _intClass = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass
            _dblLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd

            ' ANUP 19-03-2010 12.31
            lvwREDLSafetyFactor_Weight.Items.Clear()
            _intSafetyFactorCount = 0
            '**********************

            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd _
            (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, _
            clsWeldedCylinderFunctionalClass.YeildStrengthConstants.DoubleLug_Cast_NoPort)
            txtLugGap_REDL.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd
            txtLugWidth_REDL.Text = Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd, 3)
            txtLugThickness_REDL.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd
            txtPinHoleSize_REDL.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
            txtSwingClearance_REDL.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd

            trbSafetyFactor_REDL.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
            trbSafetyFactor_REDL.Maximum = trbSafetyFactor_REDL.Minimum + 20
            trbSafetyFactor_REDL.TickFrequency = 1
            trbSafetyFactor_REDL.Value = trbSafetyFactor_REDL.Minimum
            'txtSafetyFactorOfCasting_REDL.Text = trbSafetyFactor_REDL.Value

            Dim dblSafetyFactor As Double = trbSafetyFactor_REDL.Minimum + ((trbSafetyFactor_REDL.Value - trbSafetyFactor_REDL.Minimum) * 0.25)
            txtSafetyFactorOfCasting_REDL.Text = dblSafetyFactor
        End If

    End Sub

#End Region

#End Region

#Region "Events"

    Private Sub frmREDLCasting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ColorTheForm()
        SearchForExistingDoubleLugCastingDetails()
        'PopulateInListView()
    End Sub

#Region "CastingYesDetailsEvents"


    Private Sub lvwDLCastingDetails_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwDLCastingDetails.SelectedIndexChanged
        'ANUP 10-11-2010 START
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        rdbExactMatchYes.Checked = False
        rdbResize_DLCasting.Checked = False
        'ANUP 10-11-2010 TILL HERE
        If lvwDLCastingDetails.SelectedIndices.Count > 0 Then

            'TODO:Anup 27-02-2010
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            'Anup END
            ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Cast"            '02_03_2010   RAGAVA
            Dim oListViewSelectedItem As ListViewItem = lvwDLCastingDetails.SelectedItems(0)
            Dim oSelectedCastingDataRow As DataRow = Nothing

            'ANUP 07-10-2010 START
            Dim strPartCodePassing_Purchased As String = oListViewSelectedItem.SubItems(DoubleLugListViewDetails.CodeNumber).Text
            Try
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_RodEnd = oListViewSelectedItem.SubItems(2).Text      '31_05_2011   ragava
            Catch ex As Exception
            End Try
            ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode = strPartCodePassing_Purchased         '12_10_2010   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndCastingCodeNumber = strPartCodePassing_Purchased    '07_02_2011 
            If ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.ContainsKey(strPartCodePassing_Purchased) Then
                strPartCodePassing_Purchased = ObjClsWeldedCylinderFunctionalClass._htPartCode_Purchase_ListViewSelectedValidation.Item(strPartCodePassing_Purchased).ToString
            End If

            oSelectedCastingDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                        GetREDoubleLugCastingDetailsSelectedRowDetails(strPartCodePassing_Purchased)

            If Not IsNothing(oSelectedCastingDataRow) Then
                If Not IsDBNull(oSelectedCastingDataRow("PartCode")) Then
                    txtCodeNumber_DLCasting.Text = oListViewSelectedItem.SubItems(DoubleLugListViewDetails.CodeNumber).Text
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("DoubleLug without Port Code", oListViewSelectedItem.SubItems(DoubleLugListViewDetails.CodeNumber).Text)
                End If
                'ANUP 07-10-2010 TILL HERE

                'TODO:Anup 27-02-2010
                If oSelectedCastingDataRow("PartType").ToString.Contains("IFL_PART") Then
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "IFL_Designed_Existing"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "NewDesign"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "ROD_END_DOUBLE_LUG_CASTING"
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "Existing"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "U_LUG_ROD"
                End If
                'Anup END


                If Not IsDBNull(oSelectedCastingDataRow("SwingClearanceRadius")) Then
                    txtSwingClearance_DLCasting.Text = oSelectedCastingDataRow("SwingClearanceRadius")
                End If

                If Not IsDBNull(oSelectedCastingDataRow("LugThickness")) Then
                    txtLugThickness_DLCasting.Text = oSelectedCastingDataRow("LugThickness")
                End If

                If Not IsDBNull(oSelectedCastingDataRow("PinHoleSizeCombined")) Then
                    txtPinHoleSize_DLCasting.Text = oSelectedCastingDataRow("PinHoleSizeCombined")
                End If

                If Not IsDBNull(oSelectedCastingDataRow("LugGap")) Then
                    txtLugGap_DLCasting.Text = oSelectedCastingDataRow("LugGap")
                End If

                If Not IsDBNull(oSelectedCastingDataRow("LugWidth")) Then
                    txtLugWidth_DLCasting.Text = oSelectedCastingDataRow("LugWidth")
                End If

                If Not IsDBNull(oSelectedCastingDataRow("WeldSize")) Then
                    txtWeldSize_DLCasting.Text = oSelectedCastingDataRow("WeldSize")
                End If


                If Not IsDBNull(oSelectedCastingDataRow("DistanceFromPinHoleToRodStop")) Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = oSelectedCastingDataRow("DistanceFromPinHoleToRodStop")
                End If


                'If Not IsDBNull(oSelectedCastingDataRow("EndofTubetoRodStop")) Then
                '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = oSelectedCastingDataRow("EndofTubetoRodStop")
                'End If

            End If
        Else
            txtCodeNumber_DLCasting.Text = ""
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("DoubleLug without Port Code", txtCodeNumber_DLCasting.Text)
            txtSwingClearance_DLCasting.Text = ""
            txtLugThickness_DLCasting.Text = ""
            txtPinHoleSize_DLCasting.Text = ""
            txtLugGap_DLCasting.Text = ""
            txtLugWidth_DLCasting.Text = ""
            txtWeldSize_DLCasting.Text = ""

            'TODO:Anup 27-02-2010
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = 0
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = 0
            'Anup END
        End If

    End Sub

    'Private Sub chkUseSelectedDoubleLugCasting_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If chkUseSelectedDoubleLugCasting.Checked Then
    '        grbUsingSelectedDLCasting.Visible = True
    '        btnClickNextButton_RECT.Visible = False
    '    Else
    '        grbUsingSelectedDLCasting.Visible = False
    '        btnClickNextButton_RECT.Visible = False
    '    End If
    'End Sub

    'Private Sub chkExactMatchDLCasting_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If chkExactMatchDLCasting.Checked Then
    '        grbNotExactMatchCasting.Visible = False
    '        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
    '        ' btnMessageExactMatchDlCasting.Location = New Point(274, 463)
    '    Else
    '        grbNotExactMatchCasting.Visible = True
    '        ' btnMessageExactMatchDlCasting.Location = New Point(274, 463)
    '    End If
    'End Sub

    Private Sub rdbUseSelectedSingleLugYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedSingleLugYes.CheckedChanged
        If rdbUseSelectedSingleLugYes.Checked Then
            grbUsingSelectedDLCasting.Visible = True
            grbUsingSelectedDLCasting.BringToFront()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        End If
    End Sub

    Private Sub rdbUseSelectedSingleLugNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbUseSelectedSingleLugNo.CheckedChanged
        If rdbUseSelectedSingleLugNo.Checked Then
            grbUsingSelectedDLCasting.Visible = False
            pnlREDLCastingYes.Visible = False
            pnlREDLCastingNo.Visible = True
            pnlREDLCastingNo.BringToFront()
        End If
    End Sub

    Private Sub rdbExactMatchYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbExactMatchYes.CheckedChanged
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = ""    '03_03_2010    ARUNA
        If rdbExactMatchYes.Checked Then
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "Exact"
            ' grbNotExactMatchCasting.Visible = False '5_3_2010 ARUNA
            UpdatePreviousFormDetails()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        End If
    End Sub


    Private Sub rdbResize_DLCasting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbResize_DLCasting.CheckedChanged
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = ""    '03_03_2010    ARUNA
        If rdbResize_DLCasting.Checked Then
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "Resize"
            UpdatePreviousFormDetails()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        End If
    End Sub

    Private Sub rdbNewCasting_DlCasting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbNewCasting_DlCasting.CheckedChanged
        ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = ""    '03_03_2010    ARUNA
        If rdbNewCasting_DlCasting.Checked Then
            ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "NewDesign"
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "ROD_END_DOUBLE_LUG_CASTING"      '02_03_2010    RAGAVA
            UpdatePreviousFormDetails()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        End If
    End Sub

#End Region

#Region "DesignACastingEvents"

    Private Sub trbSafetyFactor_REDL_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trbSafetyFactor_REDL.Scroll
        For Each oItem As ListViewItem In lvwREDLSafetyFactor_Weight.Items
            oItem.Selected = False
        Next
    End Sub

    Private Sub trbSafetyFactor_REDL_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trbSafetyFactor_REDL.ValueChanged
        WidthCalculation()
    End Sub


    Private Sub txtLugThickness_REDL_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLugThickness_REDL.Leave
        If txtLugThickness_REDL.Text <> "" Then
            If txtLugThickness_REDL.Text <> txtLugThickness_REDL.IFLDataTag Then
                txtLugThickness_REDL.IFLDataTag = txtLugThickness_REDL.Text
                trbSafetyFactor_REDL.Minimum = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor
                trbSafetyFactor_REDL.Maximum = trbSafetyFactor_REDL.Minimum + 20
                trbSafetyFactor_REDL.TickFrequency = 1
                trbSafetyFactor_REDL.Value = trbSafetyFactor_REDL.Minimum
                ' txtSafetyFactorOfCasting_REDL.Text = trbSafetyFactor_REDL.Value

                'btnAccept_REDL.Enabled = False
                Dim dblSafetyFactor As Double = trbSafetyFactor_REDL.Minimum + ((trbSafetyFactor_REDL.Value - trbSafetyFactor_REDL.Minimum) * 0.25)
                txtLugThickness_REDL.Text = dblSafetyFactor

                'ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation_RodEnd(ObjClsWeldedCylinderFunctionalClass. _
                'ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.DoubleLug_Cast_NoPort)
                'txtLugWidth_REDL.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd
            End If
        Else
            txtLugThickness_REDL.IFLDataTag = ""
        End If
    End Sub

    Private Sub btnGenerate_REDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate_REDL.Click
        'TODO: ANUP 27-04-2010 09.54am
        btnAccept_REDL.Enabled = False
        '***********
        Me.Cursor = Cursors.WaitCursor

        'ANUP 17-09-2010 START
        If ObjClsWeldedCylinderFunctionalClass.SwingClearanceValidation_PartCondition_RodEnd Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd = Val(ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_RodEnd.Text) + 0.0625
        End If
        'ANUP 17-09-2010 TILL HERE

        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance_RodEnd + 0.36 'TODO:Sunny 13-04-10 5pm

        If txtSafetyFactorOfCasting_REDL.Text <> "" Then
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd = txtSafetyFactorOfCasting_REDL.Text
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_RodEnd = txtSafetyFactorOfCasting_REDL.Text
        End If

        If txtLugThickness_REDL.Text <> "" Then
            'ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd.Text = txtLugThickness_REDL.Text
            ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_RodEnd.Text = txtLugThickness_REDL.Text
        End If
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Casting"       '18_03_2010   RAGAVA Sunny 11-05-10
        '17_02_2010   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Cast"
        ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Lathe"
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "NewDesign"
        Dim strName As String = "NewDoubleLugCastPartCopied"
        Dim strFilePart As String = String.Empty
        Dim strFilePartDesignTableExcel As String = String.Empty
        Dim dblWeight As Double
        Try
            strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_END_DOUBLE_LUG_CASTING\ROD_END_DOUBLE_LUG_CASTING.SLDPRT"
            strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\ROD_END_DOUBLE_LUG_CASTING.XLS"
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName = "ROD_END_DOUBLE_LUG_CASTING"      '01_03_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.Design_New_Part(strFilePart, strFilePartDesignTableExcel, strName)
            'ObjClsWeldedCylinderFunctionalClass.GenerateCasting = False
            dblWeight = ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Weight")
            'Aruna 19_3_2010
            ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\ROD_END_DOUBLE_LUG_CASTING", True)
        Catch ex As Exception
        End Try
        'Till   Here


        Dim blnDuplicateFound As Boolean = False
        If lvwREDLSafetyFactor_Weight.Items.Count > 0 Then
            For Each oItem As ListViewItem In lvwREDLSafetyFactor_Weight.Items
                If oItem.SubItems(WeightListView.SafetyFactor).Text.Equals(txtSafetyFactorOfCasting_REDL.Text) AndAlso _
                 oItem.SubItems(WeightListView.LugThickness_REDL).Text.Equals(txtSafetyFactorOfCasting_REDL.Text) Then
                    blnDuplicateFound = True
                End If
            Next
        End If
        If Not blnDuplicateFound Then
            Dim oListViewItem As New ListViewItem
            oListViewItem.Text = txtSafetyFactorOfCasting_REDL.Text
            oListViewItem.SubItems.Add(txtLugThickness_REDL.Text)
            oListViewItem.SubItems.Add(dblWeight)
            lvwREDLSafetyFactor_Weight.Items.Add(oListViewItem)
            'oListViewItem = lvwREDLSafetyFactor_Weight.Items.Add(txtSafetyFactorOfCasting_REDL.Text)
            'lvwREDLSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(txtLugThickness_REDL.Text)
            'lvwREDLSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(dblWeight)
            _intSafetyFactorCount += 1
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub lvwREDLSafetyFactor_Weight_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwREDLSafetyFactor_Weight.SelectedIndexChanged
        If lvwREDLSafetyFactor_Weight.SelectedIndices.Count > 0 Then
            Dim oListViewSelectedItem As ListViewItem = lvwREDLSafetyFactor_Weight.SelectedItems(0)
            trbSafetyFactor_REDL.Value = ((Val(oListViewSelectedItem.SubItems(WeightListView.SafetyFactor).Text) - trbSafetyFactor_REDL.Minimum) / 0.25) + trbSafetyFactor_REDL.Minimum
            txtLugThickness_REDL.Text = oListViewSelectedItem.SubItems(WeightListView.LugThickness_REDL).Text
            btnAccept_REDL.Enabled = True
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        End If
    End Sub

    Private Sub btnAccept_REDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept_REDL.Click
        If txtSafetyFactorOfCasting_REDL.Text <> "" Then
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd = txtSafetyFactorOfCasting_REDL.Text
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_RodEnd = txtSafetyFactorOfCasting_REDL.Text
        End If

        If txtLugThickness_REDL.Text <> "" Then
            'ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_BaseEnd.Text = txtLugThickness_REDL.Text
            ObjClsWeldedCylinderFunctionalClass.TxtLugThickness_RodEnd.Text = txtLugThickness_REDL.Text
        End If
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = False        '20_10_2010   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        btnAccept_REDL.Enabled = False
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "NewDesign"
    End Sub

#End Region

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, lblDLHeading, LabelGradient4, LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(LabelGradient5)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblExistingDoubleLugIndex_RodEnd)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblUseSelectedDoubleLugCasting)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblDesignNewCasting)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblSafetyFactorIndex_REDL)
    End Sub

End Class