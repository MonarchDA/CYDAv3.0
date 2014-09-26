Public Class frmSLCastingNo_PortInTube

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
        'rdbFabrication.Checked = True

        cmbLugInTubeDiameter.Items.Clear()
        cmbLugInTubeDiameter.Items.Add("Yes")
        cmbLugInTubeDiameter.Items.Add("No")
        'cmbLugInTubeDiameter.SelectedIndex = 0
        cmbLugInTubeDiameter.Visible = False
        lblLugWithInTubeDiameter.Visible = False
    End Sub

    Public Sub ManualLoad()
        'ONSITE: Commented the SL casting not found message 
        ' If MessageBox.Show("Single Lug Casting not matched.", "No Single Lug", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) = Windows.Forms.DialogResult.OK Then
        ' LoadFunctionality() MANJULA COMMENTED
        SetValuesToPrivateVariables()
        'End If
    End Sub


    '30-04-2012 MANJULA ADDED
    Private Sub SetValuesToPrivateVariables()
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        If Not rdbFabrication.Checked Then
            cmbLugInTubeDiameter.Visible = False
            cmbLugInTubeDiameter.SelectedIndex = -1
            lblLugWithInTubeDiameter.Visible = False
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
            rdbFabrication.Checked = False
            rdbDesignACasting.Checked = False
            rdbDesignACasting.Enabled = True
            rdbFabrication.Enabled = True
            plnFabrication_Casting.Controls.Clear()

            LoadFunctionality()

        End If
        ' SearchForExistingDoubleLugCastings()
    End Sub
    Private Sub LoadFunctionality()
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        If rdbFabrication.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated"
            plnFabrication_Casting.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmSLFabrication.TopLevel = False
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmSLFabrication.Created Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLFabrication.ManualLoad()
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjFrmSLFabrication.Show()
            plnFabrication_Casting.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmSLFabrication)
        ElseIf rdbDesignACasting.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Cast"
            plnFabrication_Casting.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmSLDesignACasting.TopLevel = False
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmSLDesignACasting.Created Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLDesignACasting.ManualLoad()
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjFrmSLDesignACasting.Show()
            plnFabrication_Casting.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmSLDesignACasting)
        End If
    End Sub

#End Region

#Region "Events"

    Private Sub rdbFabrication_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    rdbFabrication.CheckedChanged, rdbDesignACasting.CheckedChanged
        ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "SINGLE LUG"
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = False
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = False
        If rdbFabrication.Checked = True Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" '08-05-2012 MANJULA ADDED
            rdbDesignACasting.Enabled = False '08-05-2012 MANJULA ADDED
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISFabricationChecked = True
            cmbLugInTubeDiameter.Visible = True
            lblLugWithInTubeDiameter.Visible = True
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True
            If Trim(cmbLugInTubeDiameter.Text) = "" Then
                If MsgBox("Select the Lug In Tube Diameter option", MsgBoxStyle.SystemModal, "Selection of Lug in tube diameter") = MsgBoxResult.Ok Then
                    cmbLugInTubeDiameter.Focus()
                    ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
                    Exit Sub
                End If
                'Else
                '    ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
            End If
            plnFabrication_Casting.Controls.Clear() '10-05-2012 MANJULA ADDED
        ElseIf rdbDesignACasting.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" '10-05-2012 MANJULA ADDED
            rdbFabrication.Enabled = False '10-05-2012 MANJULA ADDED
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
            cmbLugInTubeDiameter.Visible = False
            lblLugWithInTubeDiameter.Visible = False
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = True
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISFabricationChecked = False
        End If
        LoadFunctionality()
        btnRadioButtonsSelectionMessage.Enabled = False
    End Sub

    Private Sub frmCastingNo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        DefaultSettings()
        ' LoadFunctionality() MANJULA COMMENTED
        SetValuesToPrivateVariables()
    End Sub

#End Region

    Private Sub cmbLugInTubeDiameter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLugInTubeDiameter.SelectedIndexChanged
        If cmbLugInTubeDiameter.Text <> "" Then
            If cmbLugInTubeDiameter.Text <> cmbLugInTubeDiameter.IFLDataTag Then
                cmbLugInTubeDiameter.IFLDataTag = cmbLugInTubeDiameter.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinWithInTubeDiameter = cmbLugInTubeDiameter.Text
            End If
            LoadFunctionality()
            btnRadioButtonsSelectionMessage.Enabled = False
        Else
            cmbLugInTubeDiameter.IFLDataTag = Nothing
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinWithInTubeDiameter = ""
        End If
    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblCastingNotMatched)
    End Sub
End Class