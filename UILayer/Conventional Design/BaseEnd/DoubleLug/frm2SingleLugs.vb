Public Class frm2SingleLugs

    'Private Sub optULug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optULug.CheckedChanged
    '    'Try
    '    '    Dim dblBendRadius As Double
    '    '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness < 0.625 Then
    '    '        dblBendRadius = 0.25
    '    '    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = 0.625 Then
    '    '        dblBendRadius = 0.5
    '    '    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness > 0.625 Then
    '    '        dblBendRadius = 0.75
    '    '    End If
    '    '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap < 2 * dblBendRadius Then
    '    '        Dim strMessage As String = "LugGap is not sufficient for the selected LugThickness kindly go BACK to change, the lugthickness OR " + vbNewLine
    '    '        strMessage += "Increase LugGap (LugGap should be greater than " + (2 * dblBendRadius).ToString + ") OR" + vbNewLine
    '    '        MessageBox.Show(strMessage, "Choose Double Lug", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
    '    '    End If
    '    '    Me.Close()
    '    'Catch ex As Exception

    '    'End Try
    'End Sub

    'Private Sub optDoubleLug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDoubleLug.CheckedChanged
    '    'Try
    '    '    ObjClsWeldedCylinderFunctionalClass.ObjFrmRetractedLengthValidation.CalculatedVariablesDefault()
    '    '    ObjClsWeldedCylinderFunctionalClass.ObjFrmRetractedLengthValidation.CalculateStickOutLength(False)
    '    '    If MessageBox.Show("SingleLug Fabricated design is going to be generated, do you want to continue", "Fabricated SingleLug", _
    '    '                                       MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
    '    '        Dim oFrmFabricatedSingleLug_RetractedLength As New frmFabricatedSingleLug_RetractedLength
    '    '        ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "SINGLE LUG"
    '    '        oFrmFabricatedSingleLug_RetractedLength.ShowDialog()
    '    '    End If
    '    'Catch ex As Exception

    '    'End Try
    'End Sub

    Private Sub chkULug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkULug.CheckedChanged
        Try
            If chkULug.Checked = True Then
                Dim dblBendRadius As Double
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness < 0.625 Then
                    dblBendRadius = 0.25
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = 0.625 Then
                    dblBendRadius = 0.5
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness > 0.625 Then
                    dblBendRadius = 0.75
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBendradius_error = False
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap < 2 * dblBendRadius Then
                    Dim strMessage As String = "LugGap is not sufficient for the selected LugThickness kindly go BACK to change, the lugthickness OR " + vbNewLine
                    strMessage += "Increase LugGap (LugGap should be greater than " + (2 * dblBendRadius).ToString + ") OR Choose Double Lug" + vbNewLine
                    MessageBox.Show(strMessage, "Bend radius error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBendradius_error = True
                Else
                    Me.Visible = False
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated"
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.plnFabrication_Casting.Controls.Clear()
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication.TopLevel = False
                    If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication.Created Then
                        ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication.ManualLoad()
                    End If
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication.Show()
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.plnFabrication_Casting.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication)
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.bln2SingleLugSelected = True            '05_01_2012   RAGAVA
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkDoubleLug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDoubleLug.CheckedChanged
        Try
            'ObjClsWeldedCylinderFunctionalClass.ObjFrmRetractedLengthValidation.CalculatedVariablesDefault()
            'ObjClsWeldedCylinderFunctionalClass.ObjFrmRetractedLengthValidation.CalculateStickOutLength(False)
            If MessageBox.Show("SingleLug Fabricated design is going to be generated, do you want to continue", "Fabricated SingleLug", _
                                               MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBendradius_error = False
                Dim oFrmFabricatedSingleLug_RetractedLength As New frmFabricatedSingleLug_RetractedLength
                ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "SINGLE LUG"
                Me.Visible = False
                oFrmFabricatedSingleLug_RetractedLength.ShowDialog()

                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.bln2SingleLugSelected = True            '05_01_2012   RAGAVA
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBendradius_error = True
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISFabricationChecked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub
End Class