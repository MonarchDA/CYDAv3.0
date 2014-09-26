Public Class frmREDrilledPinHole

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

#Region "Events"

    Private Sub frmREDrilledPinHole_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        DefaultSettings()
        'PopulateData()
    End Sub

    '   ANUP 11-03-2010 02.44
    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        If MessageBox.Show("Click OK to change the Pin Hole Data with the existing data", "Update Pin Hole Size", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) = Windows.Forms.DialogResult.OK Then
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSizeType_RodEnd = "Standard" Then
                If ObjClsWeldedCylinderFunctionalClass.PinHoleSize_source_RodEnd = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleStandard Then
                    If cmbDrilledPinHoleSize_RodEnd.Text <> "" Then
                        ObjClsWeldedCylinderFunctionalClass.CmbPinHoleSize_RodEnd.Text = cmbDrilledPinHoleSize_RodEnd.Text
                    End If
                End If
            Else
                If ObjClsWeldedCylinderFunctionalClass.PinHoleSize_source_RodEnd = clsWeldedCylinderFunctionalClass.PinHoleSourceTypes.PinHoleCustom Then
                    If txtDrilledPinHoleSize_RodEnd.Text <> "" Then
                        ObjClsWeldedCylinderFunctionalClass.TxtPinHoleSize_RodEnd.Text = txtDrilledPinHoleSize_RodEnd.Text
                    End If
                End If
                ObjClsWeldedCylinderFunctionalClass.TxtToleranceUpperLimit_RodEnd.Text = txtUpperTolerance_DPHRE.Text
                ObjClsWeldedCylinderFunctionalClass.TxtToleranceLowerLimit_RodEnd.Text = txtLowerTolerance_DPHRE.Text
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = False        '20_10_2010   RAGAVA
        End If
    End Sub
    '*******************

#End Region

#Region "Sub Procedures"

    Public Sub ManualLoad()
        'PopulateData()
        DefaultSettings()
    End Sub

    Private Sub CmbPinHoleSizeFunctionality()
        Dim oPinHoleSizesDatatable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
        GetPinHoleSizes(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter)
        If Not IsNothing(oPinHoleSizesDatatable) Then
            cmbDrilledPinHoleSize_RodEnd.DataSource = oPinHoleSizesDatatable
            cmbDrilledPinHoleSize_RodEnd.DisplayMember = "PinHole"
            cmbDrilledPinHoleSize_RodEnd.ValueMember = "PinHole"
            cmbDrilledPinHoleSize_RodEnd.SelectedIndex = 0
        End If
    End Sub

    'Private Sub PopulateData()
    '    txtDrilledPinHoleSize_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
    '    txtUpperTolerance_DPHRE.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd
    '    txtLowerTolerance_DPHRE.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd
    'End Sub

    Private Sub DefaultSettings()
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSizeType_RodEnd = "Standard" Then
            pnlDrilledPinHoleCustom_RodEnd.Hide()
            pnlDrilledPinHoleStandard_RodEnd.Show()
            CmbPinHoleSizeFunctionality()
        Else
            pnlDrilledPinHoleStandard_RodEnd.Hide()
            pnlDrilledPinHoleCustom_RodEnd.Show()
            pnlDrilledPinHoleCustom_RodEnd.BringToFront()
            txtDrilledPinHoleSize_RodEnd.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
            txtUpperTolerance_DPHRE.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd
            txtLowerTolerance_DPHRE.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd
        End If
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, lblSLHeading, LabelGradient4, LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient1)

        'A0308: ANUP 04-08-2010 03.26pm
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblStandardPinHole)
    End Sub

End Class