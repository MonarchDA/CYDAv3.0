Public Class frmFlatWithChamfer


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

    'ONSITE: Adding the flat With chamfer image when form is loading
    Public Sub ManualLoad()
        ObjClsWeldedCylinderFunctionalClass.MdiPictureBox.ImageLocation = ObjClsWeldedCylinderFunctionalClass.CurrentWorkingDirectory + "\Images\ROD_WITH_CHAMFER.JPG"
    End Sub

    Private Sub txtChamferAngle_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChamferAngle.Leave
        
        If txtChamferAngle.Text <> "" Then
            If txtChamferAngle.Text <> txtChamferAngle.IFLDataTag Then
                txtChamferAngle.IFLDataTag = txtChamferAngle.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ChamferAngle_RodEnd = txtChamferAngle.Text
            End If

        Else
            txtChamferAngle.IFLDataTag = ""

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ChamferAngle_RodEnd = 0
        End If

    End Sub

    Private Sub txtChamferSize_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtChamferSize.Leave
        If txtChamferSize.Text <> "" Then
            If txtChamferSize.Text <> txtChamferSize.IFLDataTag Then
                If Val(txtChamferSize.Text) < 0 OrElse Val(txtChamferSize.Text) > (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter / 2) - 0.1 Then
                    Dim strMessage As String = "Chamfer Size must be > 0 and < " + ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter / 2) - 0.1).ToString
                    MessageBox.Show(strMessage, "Change Chamfer Size", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)
                    txtChamferSize.Clear()
                    txtChamferSize.Focus()
                Else
                    txtChamferSize.IFLDataTag = txtChamferSize.Text
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ChamferSize_RodEnd = txtChamferSize.Text
                End If
            End If
        Else
            txtChamferSize.IFLDataTag = ""
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ChamferSize_RodEnd = 0
        End If
    End Sub

    Private Sub frmFlatWithChamfer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ColorTheForm()
        ManualLoad()
    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, lblSLHeading, LabelGradient4, LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblFlatWithChamferInsidePanel)
    End Sub

End Class