Public Class frmBHCastingNo_PortIntegral
    'TODO: ANUP 22-07-2010 12.14pm
    Private _blnIsPopulated As Boolean = False
#Region "VARIABLES"
    Public dblBoreDiameter As Double
    Public dblWallThickness As Double
    Public dblBushingWidth As Double
    Public dblRequiredPinHoleSize As Double
    Public dblBushingQuantity As Double
    Public dblRequiredLugThickness As Double
    Public dblSwingClearance As Double
    Public dblLugGap As Double
    Public _rodDiameter As Double



#End Region


    Public Property IsPopulated() As Boolean
        Get
            Return _blnIsPopulated
        End Get
        Set(ByVal value As Boolean)
            _blnIsPopulated = value
        End Set
    End Property

#Region "SubProcedures"

    Private Sub DefaultSettings()
        '23_01_2012   RAGAVA
        'cmbLugInTubeDiameter.Items.Clear()
        'cmbLugInTubeDiameter.Items.Add("Yes")
        'cmbLugInTubeDiameter.Items.Add("No")
        'cmbLugInTubeDiameter.Visible = False
        'lblLugWithInTubeDiameter.Visible = False
        ''rdbDesignACasting.Checked = True
        'Till  Here
        btnDisplayPortInTube.Visible = False
    End Sub

    Public Sub ManualLoad()
        'ONSITE: Commented the BH casting not found message 
        ' If MessageBox.Show("Single Lug Casting not matched.", "No Single Lug", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) = Windows.Forms.DialogResult.OK Then
        ' LoadFunctionality() MANJULA COMMENTED
        SetValuesToPrivateVariables()
        'End If

        'TODO:Sunny 04-06-10
        'rdbDesignACasting.Checked = True               '23_01_2012   RAGAVA
    End Sub

    '08-05-2012 MANJULA ADDED
    Private Sub SetValuesToPrivateVariables()
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
       
        If Not dblBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter _
         OrElse Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter = _rodDiameter _
                       OrElse Not dblWallThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness _
                       OrElse Not dblBushingWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth _
                       OrElse Not dblRequiredPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize _
                       OrElse Not dblBushingQuantity = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity _
                       OrElse Not dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness _
                       OrElse Not dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text _
                       OrElse Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TempWorkingPressure _
                       OrElse Not dblLugGap = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap Then             '31_03_2010   RAGAVA
            dblBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
            dblWallThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness
            dblBushingWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth
            dblRequiredPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
            dblBushingQuantity = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity
            dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
            dblLugGap = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap
            _rodDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter


            'ANUP 17-09-2010 START 
            '  _dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
            dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text
            'ANUP 17-09-2010 TILL HERE

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TempWorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure           '31_03_2010   RAGAVA
            rdbDesignACasting.Checked = False
            rdbFabricated.Checked = False
            rdbDesignACasting.Enabled = True
            rdbFabricated.Enabled = True
            plnPortInTube_Casting.Controls.Clear()
            LoadFunctionality()
        End If
        ' SearchForExistingDoubleLugCastings()
    End Sub



    Private Sub LoadFunctionality()
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
            rdbPortInTube.Checked = False
            rdbPortInTube.Enabled = False
        Else
            rdbPortInTube.Enabled = True
        End If
        If rdbDesignACasting.Checked Then
            '28_06_2012   RAGAVA
            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BEBHCastingRaisedPort"
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BEBHCastingRaisedPort90"
                End If
            Else
                If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "WELDED.Base_End_BH_No_Port"
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "WELDED.Base_End_BH_Flush_Port"
                End If
            End If
            ObjClsWeldedCylinderFunctionalClass.FacricatedPart = ""    '28_06_2012    RAGAVA
            'till  here
            btnDisplayPortInTube.Visible = False
            plnPortInTube_Casting.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmBHDesignACasting.TopLevel = False
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmBHDesignACasting.Created Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmBHDesignACasting.ManualLoad()
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjFrmBHDesignACasting.Show()
            plnPortInTube_Casting.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmBHDesignACasting)
        ElseIf rdbFabricated.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated"
            ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "BH"      '28_06_2012    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "WELDED.BEBHDetails"   '28_06_2012    RAGAVA
            plnPortInTube_Casting.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmBHFabrication.TopLevel = False
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmBHFabrication.Created Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmBHFabrication.ManualLoad()
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjFrmBHFabrication.Show()
            plnPortInTube_Casting.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmBHFabrication)
        ElseIf rdbPortInTube.Checked Then
            plnPortInTube_Casting.Controls.Clear()
            btnDisplayPortInTube.Visible = True
            btnDisplayPortInTube.BringToFront()
        End If
    End Sub

#End Region

#Region "Events"

    Private Sub rdbDesignACasting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDesignACasting.CheckedChanged, rdbFabricated.CheckedChanged
        Try
            'grp2SingleLugs.Visible = False
            If rdbDesignACasting.Checked Then
                '28_06_2012   RAGAVA
                If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BEBHCastingRaisedPort"
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BEBHCastingRaisedPort90"
                    End If
                Else
                    If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "WELDED.Base_End_BH_No_Port"
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "WELDED.Base_End_BH_Flush_Port"
                    End If
                End If
                'till  here
                ObjClsWeldedCylinderFunctionalClass.FacricatedPart = ""    '28_06_2012    RAGAVA
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" 'MANJULA ADDED
                rdbFabricated.Enabled = False 'MANJULA ADDED
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = False
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = True
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Cast"
                LoadFunctionality()
            ElseIf rdbFabricated.Checked Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "WELDED.BEBHDetails"    '28_06_2012    RAGAVA
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" 'MANJULA ADDED
                rdbDesignACasting.Enabled = False 'MANJULA ADDED
                ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "BH"    '28_06_2012    RAGAVA
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = False
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISFabricationChecked = True
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True
                LoadFunctionality()
                ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
            ElseIf rdbFabricated.Checked = False Then
                'chkULug.Checked = False
                'chkDoubleLug.Checked = False
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmBHCastingNo_PortIntegral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        DefaultSettings()
        ' LoadFunctionality() 'MANJULA COMMENTED
        SetValuesToPrivateVariables()
        'End If

        'TODO:Sunny 04-06-10
        'rdbDesignACasting.Checked = True MANJULA COMMENTED
    End Sub

    Private Sub rdbPortInTube_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPortInTube.CheckedChanged
        If rdbPortInTube.Checked Then
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
            ObjClsWeldedCylinderFunctionalClass.ShowPortInTube_Thru_PortIntegral = True
            ObjClsWeldedCylinderFunctionalClass.ChangeScreensFlow()
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Cast"
            ObjClsWeldedCylinderFunctionalClass.ShowPortInTube_Thru_PortIntegral = False
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        End If
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblCastingNotMatched)
    End Sub

    ''23_01_2012   RAGAVA
    'Private Sub chkULug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try

    '        ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "SINGLE LUG"
    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = False
    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = False
    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISFabricationChecked = True
    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True
    '        If chkULug.Checked = True Then
    '            chkDoubleLug.Checked = False
    '            Dim dblBendRadius As Double
    '            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness < 0.625 Then
    '                dblBendRadius = 0.25
    '            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = 0.625 Then
    '                dblBendRadius = 0.5
    '            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness > 0.625 Then
    '                dblBendRadius = 0.75
    '            End If
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBendradius_error = False
    '            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap < 2 * dblBendRadius Then
    '                Dim strMessage As String = "LugGap is not sufficient for the selected LugThickness kindly go BACK to change, the lugthickness OR " + vbNewLine
    '                strMessage += "Increase LugGap (LugGap should be greater than " + (2 * dblBendRadius).ToString + ") OR Choose Double Lug" + vbNewLine
    '                MessageBox.Show(strMessage, "Bend radius error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
    '                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBendradius_error = True
    '                Me.chkULug.Checked = False
    '            Else
    '                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEULDETAILS"
    '                ObjClsWeldedCylinderFunctionalClass.FacricatedPart = ""
    '                LoadFunctionality()
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    '23_01_2012   RAGAVA
    'Private Sub cmbLugInTubeDiameter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLugInTubeDiameter.SelectedIndexChanged
    '    If cmbLugInTubeDiameter.Text <> "" Then
    '        If cmbLugInTubeDiameter.Text <> cmbLugInTubeDiameter.IFLDataTag Then
    '            cmbLugInTubeDiameter.IFLDataTag = cmbLugInTubeDiameter.Text
    '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinWithInTubeDiameter = cmbLugInTubeDiameter.Text
    '        End If
    '        LoadFunctionality()
    '        'btnRadioButtonsSelectionMessage.Enabled = False
    '    Else
    '        cmbLugInTubeDiameter.IFLDataTag = Nothing
    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinWithInTubeDiameter = ""
    '    End If
    'End Sub

End Class