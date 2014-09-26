Public Class frmImportRodEnd

    Private _dblRodEndPinHoleToRodStopDistance As Double = 0

    'ANUP 23-09-2010 START 
    Private _strConnectionType As String = String.Empty
    Private _dblThreadLength As Double
    Private _dblThreadSize As Double
    Private _dblChamferSize As Double
    Private _dblChamferAngle As Double
    'ANUP 23-09-2010 TILL HERE

    Public ReadOnly Property ControlsData() As ArrayList
        Get
            ControlsData = New ArrayList

            Try
                ControlsData.Add(New Object(3) {"GUI", "Import Rod End Configuration Type", "R22", _strConnectionType})
            Catch ex As Exception

            End Try

            Return ControlsData
        End Get
    End Property

    Private Sub txtRodEndPinHoleToRodStopDistance_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRodEndPinHoleToRodStopDistance.TextChanged
        Try
            If Not IsNothing(txtRodEndPinHoleToRodStopDistance.Text) Then
                _dblRodEndPinHoleToRodStopDistance = Val(txtRodEndPinHoleToRodStopDistance.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Try
            If Windows.Forms.DialogResult.OK = ofdImportRodEnd.ShowDialog Then
                ofdImportRodEnd.OpenFile()
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportRodEndPartPath = ofdImportRodEnd.FileName

                'ANUP 16-08-2010
                If Not IsNothing(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportRodEndPartPath) Then
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
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblRodEndDetails)
    End Sub

    Private Sub frmImportRodEnd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()

        'ANUP 16-08-2010
        ObjClsWeldedCylinderFunctionalClass.IsRodEndPartImported = False
        btnAccept.Enabled = False

        'ANUP 23-09-2010 START 
        AddingConnectionTypeValus()
        'ANUP 23-09-2010 TILL HERE
    End Sub

    Private Sub AddingConnectionTypeValus()
        cmbConnectionType.Items.Clear()
        cmbConnectionType.Items.Add("Welded")
        cmbConnectionType.Items.Add("Threaded Rod")
        cmbConnectionType.Items.Add("Flat With Chamfer")
        cmbConnectionType.SelectedIndex = 0
        'ANUP 23-09-2010 START 
        gbConnectionType.Enabled = False
        'ANUP 23-09-2010 TILL HERE
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.REDistanceFromPinholetoRodStop = _dblRodEndPinHoleToRodStopDistance
        ObjClsWeldedCylinderFunctionalClass.IsRodEndPartImported = True 'ANUP 16-08-2010
        'ANUP 23-09-2010 START 
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength_RodEnd = _dblThreadLength
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadSize_RodEnd = _dblThreadSize
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ChamferSize_RodEnd = _dblChamferSize
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ChamferAngle_RodEnd = _dblChamferAngle
        'ANUP 23-09-2010 TILL HERE
    End Sub

    'ANUP 23-09-2010 START 
    Private Sub cmbConnectionType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbConnectionType.SelectedIndexChanged
        Try
            If Not String.IsNullOrEmpty(cmbConnectionType.Text) Then
                If Not cmbConnectionType.Text = cmbConnectionType.IFLDataTag Then
                    cmbConnectionType.IFLDataTag = cmbConnectionType.Text
                    _strConnectionType = cmbConnectionType.Text
                    IflTextBox1.Clear()
                    IflTextBox2.Clear()
                    If cmbConnectionType.Text = "Welded" Then
                        gbConnectionType.Enabled = False
                    ElseIf cmbConnectionType.Text = "Threaded Rod" Then
                        gbConnectionType.Enabled = True
                        Label1.Text = "Thread Length"
                        Label2.Text = "Thread Size"
                    ElseIf cmbConnectionType.Text = "Flat With Chamfer" Then
                        gbConnectionType.Enabled = True
                        Label1.Text = "Chamfer Size"
                        Label2.Text = "Chamfer Angle"
                    Else
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IflTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IflTextBox1.TextChanged
        Try
            _dblThreadLength = 0
            _dblChamferSize = 0

            If Not String.IsNullOrEmpty(IflTextBox1.Text) Then
                Dim dblTextBoxValue As Double = Val(IflTextBox1.Text)
                If Label1.Text = "Thread Length" Then
                    _dblThreadLength = dblTextBoxValue
                ElseIf Label1.Text = "Chamfer Size" Then
                    _dblChamferSize = dblTextBoxValue
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IflTextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IflTextBox2.TextChanged
        Try
            _dblThreadSize = 0
            _dblChamferAngle = 0

            If Not String.IsNullOrEmpty(IflTextBox2.Text) Then
                Dim dblTextBoxValue As Double = Val(IflTextBox2.Text)
                If Label2.Text = "Thread Size" Then
                    _dblThreadSize = dblTextBoxValue
                ElseIf Label2.Text = "Chamfer Angle" Then
                    _dblChamferAngle = dblTextBoxValue
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    'ANUP 23-09-2010 TILL HERE

End Class