Public Class ucBrowsePlateClevis

    'A0308: ANUP 09-08-2010 02.15pm
    Private _oFrmImportPlateClevis As frmImportPlateClevis

    'ANUP 23-09-2010 START 
    Private _dblPlateClevisThicknessFromTubeEnd As Double = 0
    Private _dblRodStopDistanceFromTubeEnd As Double = 0
    Private _dblClevisPlateOD As Double = 0
    'ANUP 23-09-2010 TILL HERE

    'A0308: ANUP 09-08-2010 02.15pm
    Public Property ObjFrmImportPlateClevis() As frmImportPlateClevis
        Get
            Return _oFrmImportPlateClevis
        End Get
        Set(ByVal value As frmImportPlateClevis)
            _oFrmImportPlateClevis = value
        End Set
    End Property

#Region "Events"

    'Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
    '    'If Windows.Forms.DialogResult.OK = ofdULugBrowse.ShowDialog() Then
    '    '    ofdULugBrowse.OpenFile()
    '    '    txtPath.Text = ofdULugBrowse.FileName.ToString
    '    '29_03_2010   RAGAVA
    '    ofdULugBrowse.InitialDirectory = "C:\windows"
    '    ofdULugBrowse.FileName = vbNullString
    '    ofdULugBrowse.Filter = "Part Files (*.sldprt)|*.sldprt"
    '    ofdULugBrowse.FilterIndex = 1
    '    ofdULugBrowse.CheckFileExists = True
    '    ofdULugBrowse.Title = "Import Files"
    '    If ofdULugBrowse.ShowDialog() = DialogResult.OK Then
    '        'ofdULugBrowse.OpenFile()
    '        txtPath.Text = ofdULugBrowse.FileName.ToString
    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.clevisplatePartFilePath = txtPath.Text
    '    End If
    '    'End If
    'End Sub

    'A0308: ANUP 09-08-2010 02.15pm
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click

        'ANUP 23-09-2010 START 
        '_oFrmImportPlateClevis = New frmImportPlateClevis
        'ObjFrmImportPlateClevis.ShowDialog()
        'txtPath.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.clevisplatePartFilePath
        If Not String.IsNullOrEmpty(txtClevisPlateThickness.Text) OrElse Not String.IsNullOrEmpty(txtClevisPlateRodStopDistance.Text) OrElse Not String.IsNullOrEmpty(txtClevisPlateOD.Text) Then

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = _dblPlateClevisThicknessFromTubeEnd - _dblRodStopDistanceFromTubeEnd
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = _dblRodStopDistanceFromTubeEnd
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness

            Try
                ofdULugBrowse.InitialDirectory = "C:\windows"
                ofdULugBrowse.FileName = vbNullString
                ofdULugBrowse.Filter = "Part Files (*.sldprt)|*.sldprt"
                ofdULugBrowse.FilterIndex = 1
                ofdULugBrowse.CheckFileExists = True
                ofdULugBrowse.Title = "Import Files"
                If Windows.Forms.DialogResult.OK = ofdULugBrowse.ShowDialog() Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.clevisplatePartFilePath = ofdULugBrowse.FileName.ToString
                End If

                If Not String.IsNullOrEmpty(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.clevisplatePartFilePath) Then
                    txtPath.Text = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.clevisplatePartFilePath
                    ObjClsWeldedCylinderFunctionalClass.IsPlateClevisImported = True
                Else
                    ObjClsWeldedCylinderFunctionalClass.IsPlateClevisImported = False
                End If

            Catch ex As Exception

            End Try
        Else
            Dim _strMessage As String = "Clevis Plate Thickness/Rod Stop Distance/Clevis Plate OD should be entered."
            MessageBox.Show(_strMessage, "values should be entered", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
        End If
        'ANUP 23-09-2010 TILL HERE
    End Sub

#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    'Private Sub txtClevisPlateThickness_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClevisPlateThickness.Leave
    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = Val(txtClevisPlateThickness.Text)
    'End Sub

    'Private Sub txtClevisPlateRodStopDistance_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClevisPlateRodStopDistance.Leave
    '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateRodStopDistance = Val(txtClevisPlateRodStopDistance.Text)
    'End Sub

    'Private Sub ColorTheForm()
    '    ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblBrowseULug)
    'End Sub

    'Private Sub ucBrowsePlateClevis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    ColorTheForm()
    'End Sub

    'ANUP 23-09-2010 START 
    Private Sub txtClevisPlateThickness_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClevisPlateThickness.TextChanged
        Try
            If Not IsNothing(txtClevisPlateThickness.Text) Then
                _dblPlateClevisThicknessFromTubeEnd = Val(txtClevisPlateThickness.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtClevisPlateRodStopDistance_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClevisPlateRodStopDistance.TextChanged
        Try
            If Not IsNothing(txtClevisPlateRodStopDistance.Text) Then
                _dblRodStopDistanceFromTubeEnd = Val(txtClevisPlateRodStopDistance.Text)
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

    'ANUP 23-09-2010 TILL HERE
End Class
