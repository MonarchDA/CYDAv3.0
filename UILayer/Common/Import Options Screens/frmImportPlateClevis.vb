Public Class frmImportPlateClevis

    Private _dblPlateClevisThicknessFromTubeEnd As Double = 0
    Private _dblRodStopDistanceFromTubeEnd As Double = 0
    Private _dblClevisPlateOD As Double = 0

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Try
            ofdPlateClevisDetails.InitialDirectory = "C:\windows"
            ofdPlateClevisDetails.FileName = vbNullString
            ofdPlateClevisDetails.Filter = "Part Files (*.sldprt)|*.sldprt"
            ofdPlateClevisDetails.FilterIndex = 1
            ofdPlateClevisDetails.CheckFileExists = True
            ofdPlateClevisDetails.Title = "Import Files"
            If Windows.Forms.DialogResult.OK = ofdPlateClevisDetails.ShowDialog() Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.clevisplatePartFilePath = ofdPlateClevisDetails.FileName.ToString

                'ANUP 16-08-2010
                If Not IsNothing(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.clevisplatePartFilePath) Then
                    btnAccept.Enabled = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPlateClevisThicknessFromTubeEnd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlateClevisThicknessFromTubeEnd.TextChanged
        Try
            If Not IsNothing(txtPlateClevisThicknessFromTubeEnd.Text) Then
                _dblPlateClevisThicknessFromTubeEnd = Val(txtPlateClevisThicknessFromTubeEnd.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtRodStopDistanceFromTubeEnd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRodStopDistanceFromTubeEnd.TextChanged
        Try
            If Not IsNothing(txtRodStopDistanceFromTubeEnd.Text) Then
                _dblRodStopDistanceFromTubeEnd = Val(txtRodStopDistanceFromTubeEnd.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtClevisPlateOD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClevisPlateOD.TextChanged
        Try
            If Not IsNothing(txtClevisPlateOD.Text) Then
                _dblClevisPlateOD = Val(txtClevisPlateOD.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, LabelGradient5, LabelGradient4, LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblGradientContractDetails)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblPlateClevisDetails)
    End Sub

    Private Sub frmImportPlateClevis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()

        'ANUP 16-08-2010
        btnAccept.Enabled = False
        ObjClsWeldedCylinderFunctionalClass.IsPlateClevisImported = False
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = _dblPlateClevisThicknessFromTubeEnd - _dblRodStopDistanceFromTubeEnd
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = _dblRodStopDistanceFromTubeEnd
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness

        ObjClsWeldedCylinderFunctionalClass.IsPlateClevisImported = True  'ANUP 16-08-2010
    End Sub
End Class