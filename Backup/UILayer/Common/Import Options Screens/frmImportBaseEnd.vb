Public Class frmImportBaseEnd

    Private _dblTubeEndToRodStopDistance As Double = 0
    Private _dblPinHoleToRodStopDistance As Double = 0

    Private Sub txtTubeEndToRodStopDistance_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTubeEndToRodStopDistance.TextChanged
        Try

            If Not IsNothing(txtTubeEndToRodStopDistance.Text) Then
                _dblTubeEndToRodStopDistance = Val(txtTubeEndToRodStopDistance.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPinHoleToRodStopDistance_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPinHoleToRodStopDistance.TextChanged
        Try

            If Not IsNothing(txtPinHoleToRodStopDistance.Text) Then
                _dblPinHoleToRodStopDistance = Val(txtPinHoleToRodStopDistance.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Try
            If Windows.Forms.DialogResult.OK = ofdImportBaseEnd.ShowDialog() Then
                ofdImportBaseEnd.OpenFile()
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportBaseEndPartPath = ofdImportBaseEnd.FileName            '16_08_2010   RAGAVA

                'ANUP 16-08-2010
                If Not IsNothing(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportBaseEndPartPath) Then
                    btnAccept.Enabled = True
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ManualLoad()
     
    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, LabelGradient5, LabelGradient4, LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblGradientContractDetails)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblBaseEndDetails)
    End Sub

    Private Sub frmImportBaseEnd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()

        'ANUP 16-08-2010
        btnAccept.Enabled = False
        ObjClsWeldedCylinderFunctionalClass.IsBaseEndPartImported = False
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = _dblTubeEndToRodStopDistance
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = _dblPinHoleToRodStopDistance

        ObjClsWeldedCylinderFunctionalClass.IsBaseEndPartImported = True   'ANUP 16-08-2010
    End Sub
End Class