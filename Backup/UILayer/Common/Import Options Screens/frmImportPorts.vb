Public Class frmImportPorts

    Private _strPortEndType As String
    Private _dblPortHeight As Double
    Private _dblPortODAtWeld As Double
    Private _oPortDeatils As PortDetails_Import
    'ANUP 20-09-2010 START
    Private _dblOrificeSize As Double
    'ANUP 20-09-2010 TILL HERE

    Private Sub frmImportPorts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ColorTheForm()

            'ANUP 16-08-2010
            btnAccept.Enabled = False
            ObjClsWeldedCylinderFunctionalClass.IsBaseEndPortImported = False
            ObjClsWeldedCylinderFunctionalClass.IsRodEndPortImported = False

            LabelNameValidation()
            PortEndTypes_ComboBoxAdding()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LabelNameValidation()
        If ObjClsWeldedCylinderFunctionalClass.IsPort_BaseEndOrRodEnd Then
            lblPortsDetails.Text = "Base End Port details"
        Else
            lblPortsDetails.Text = "Rod End Port details"
        End If
    End Sub

    Private Sub PortEndTypes_ComboBoxAdding()
        Try
            cmbPortEndType.Items.Clear()
            cmbPortEndType.Items.Add("RADIUS")
            cmbPortEndType.Items.Add("FLAT")
            cmbPortEndType.SelectedIndex = 0

            txtPortHeight.Clear()
            txtPortODAtWeld.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbPortEndType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPortEndType.SelectedIndexChanged
        Try
            If Not IsNothing(cmbPortEndType.Text) Then
                _strPortEndType = cmbPortEndType.Text
            Else
                _strPortEndType = Nothing
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPortHeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPortHeight.TextChanged
        Try
            If Not IsNothing(txtPortHeight.Text) Then
                _dblPortHeight = Val(txtPortHeight.Text)
            Else
                _dblPortHeight = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPortODAtWeld_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPortODAtWeld.TextChanged
        Try
            If Not IsNothing(txtPortODAtWeld.Text) Then
                _dblPortODAtWeld = Val(txtPortODAtWeld.Text)
            Else
                _dblPortODAtWeld = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

    'ANUP 20-09-2010 START
    Private Sub txtOrificeSize_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOrificeSize.TextChanged
        Try
            If Not IsNothing(txtOrificeSize.Text) Then
                _dblOrificeSize = Val(txtOrificeSize.Text)
            Else
                _dblOrificeSize = 0
            End If
        Catch ex As Exception

        End Try
    End Sub
    'ANUP 20-09-2010 TILL HERE

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Try
            If Windows.Forms.DialogResult.OK = ofdPortDetails.ShowDialog() Then
                ofdPortDetails.OpenFile()

                '16_08_2010   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.IsPort_BaseEndOrRodEnd Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportBaseEndPortPartPath = ofdPortDetails.FileName
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportRodEndPortPartPath = ofdPortDetails.FileName
                End If
                'Till   Here

                'ANUP 16-08-2010
                If Not IsNothing(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportBaseEndPortPartPath) OrElse _
                                  Not IsNothing(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportRodEndPortPartPath) Then
                    btnAccept.Enabled = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, LabelGradient5, LabelGradient4, LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblGradientContractDetails)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblPortsDetails)
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
   
        If lblPortsDetails.Text = "Base End Port details" Then
            ObjClsWeldedCylinderFunctionalClass.IsBaseEndPortImported = True 'ANUP 16-08-2010
            _oPortDeatils.strPortEndType_BaseEnd = _strPortEndType
            _oPortDeatils.dblPortHeight_BaseEnd = _dblPortHeight
            _oPortDeatils.dblPortODAtWeld_BaseEnd = _dblPortODAtWeld
            'ANUP 20-09-2010 START
            _oPortDeatils.dblOrificeSize_BaseEnd = _dblOrificeSize
            'ANUP 20-09-2010 TILL HERE
        ElseIf lblPortsDetails.Text = "Rod End Port details" Then
            ObjClsWeldedCylinderFunctionalClass.IsRodEndPortImported = True 'ANUP 16-08-2010
            _oPortDeatils.strPortEndType_RodEnd = _strPortEndType
            _oPortDeatils.dblPortHeight_RodEnd = _dblPortHeight
            _oPortDeatils.dblPortODAtWeld_RodEnd = _dblPortODAtWeld
            'ANUP 20-09-2010 START
            _oPortDeatils.dblOrificeSize_RodEnd = _dblOrificeSize
            'ANUP 20-09-2010 TILL HERE
        End If
    End Sub

    Public Function PortEndTypeBaseEnd_ControlsDataExcel() As String
        PortEndTypeBaseEnd_ControlsDataExcel = Nothing
        If Not IsNothing(_oPortDeatils.strPortEndType_BaseEnd) Then
            PortEndTypeBaseEnd_ControlsDataExcel = _oPortDeatils.strPortEndType_BaseEnd
        End If
    End Function

    Public Function PortEndTypeRodEnd_ControlsDataExcel() As String
        PortEndTypeRodEnd_ControlsDataExcel = Nothing
        If Not IsNothing(_oPortDeatils.strPortEndType_RodEnd) Then
            PortEndTypeRodEnd_ControlsDataExcel = _oPortDeatils.strPortEndType_RodEnd
        End If
    End Function


    Public Function PortODAtWeld_ControlsDataExcel() As Double
        If Not IsNothing(_oPortDeatils.dblPortODAtWeld_BaseEnd) Then
            PortODAtWeld_ControlsDataExcel = _oPortDeatils.dblPortODAtWeld_BaseEnd
        End If
    End Function

 

End Class

Public Structure PortDetails_Import
    Dim strPortEndType_BaseEnd As String
    Dim dblPortHeight_BaseEnd As Double
    Dim dblPortODAtWeld_BaseEnd As Double
    Dim strPortEndType_RodEnd As String
    Dim dblPortHeight_RodEnd As Double
    Dim dblPortODAtWeld_RodEnd As Double
    'ANUP 20-09-2010 START
    Dim dblOrificeSize_BaseEnd As Double
    Dim dblOrificeSize_RodEnd As Double
    'ANUP 20-09-2010 TILL HERE
End Structure