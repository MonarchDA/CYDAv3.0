Public Class frmConPlateClevis

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

    ' ANUP 22-03-2010 11.40
#Region "Private Variables"
    Private _strClevisPlateCode As String
#End Region
    '***********

#Region "Sub Procedures"

    Private Sub InitiallSettings()
        'TODO: ANUP 23-04-2010 01.39pm
        ' chkUseMatcchedPlateClevis.Checked = True
        '************

        lblPlateClevis.SendToBack()

        'ANUP 23-09-2010 START 
        ObjClsWeldedCylinderFunctionalClass.IsPlateClevisImported = False
        'ANUP 23-09-2010 TILL HERE
    End Sub

    Public Sub ManualLoad()
        PlateClevisGenerateProcess()    'TODO: ANUP / RAGHAV 03-05-2010 03.51pm
        '03_06_2010    RAGAVA
        ''If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional" Then
        If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" Then
            SearchForPlateClevisInDB()
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndCodeNumber90 = Nothing
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndCodeNumber = Nothing
            If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text) <> "" Then    '03_06_2010   RAGAVA
                ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.GetBaseEndCodeNumber()
                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndCodeNumber90) = "" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndCodeNumber) = "" Then
                    MsgBox("Code Number for this Plate Clevis is Not Found")
                End If
            End If
        End If
        'SearchForPlateClevisInDB()
    End Sub

    Private Sub SearchForPlateClevisInDB()

        '''If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional" Then      '03_06_2010    RAGAVA
        If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" Then
            Dim dblBoreDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
            Dim dblTubeOD As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD
            lblDisplayTBA.Visible = False
            Dim oClevisPlateDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPlateClevisDetails(dblBoreDiameter, dblTubeOD)
            If Not IsNothing(oClevisPlateDataTable) Then
                Dim oPlateClevisDatarow As DataRow = oClevisPlateDataTable.Rows(0)
                _strClevisPlateCode = oPlateClevisDatarow("ClevisPlateCode")
                If IsNumeric(_strClevisPlateCode) Then
                    chkUseMatcchedPlateClevis.Checked = True
                    grbmatchedPlateClevisFound.Visible = True
                    grbMatchedPlateClevisNotFound.Visible = False
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ClevisPlate Code", _strClevisPlateCode)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode = _strClevisPlateCode
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness = oPlateClevisDatarow("ClevisPlateThickness") - oPlateClevisDatarow("ClevisPlateRodStopDistance")
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = oPlateClevisDatarow("ClevisPlateRodStopDistance")
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateThickness
                    Exit Sub
                Else
                    If _strClevisPlateCode.Contains("TBA") Then
                        ' Dim strMessage As String = "Code Number for this Plate Clevis is TBA."
                        lblDisplayTBA.Visible = True
                        lblDisplayTBA.Enabled = False
                        lblDisplayTBA.Text = "Code Number for this Plate Clevis is TBA."
                        ' MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If

            grbMatchedPlateClevisNotFound.Visible = True
            grbmatchedPlateClevisFound.Visible = False
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ClevisPlate Code", "")
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode = ""
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = 0
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = 0
        Else  '03_06_2010    RAGAVA
            If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text) <> "" Then    '03_06_2010   RAGAVA
                ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.GetBaseEndCodeNumber()
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndCodeNumber Is Nothing AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndCodeNumber90 Is Nothing Then
                    MsgBox("Code Number for this Plate Clevis is Not Found")
                    grbMatchedPlateClevisNotFound.Visible = True
                    grbmatchedPlateClevisFound.Visible = False
                Else
                    chkUseMatcchedPlateClevis.Checked = True
                    grbmatchedPlateClevisFound.Visible = True
                    grbMatchedPlateClevisNotFound.Visible = False
                End If
            End If
        End If
    End Sub

    'TODO: ANUP / RAGHAV 03-05-2010 03.51pm
    Private Sub PlateClevisGenerateProcess()
        Try

            If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = -0.125
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + 0.5
            ElseIf ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then

                '27_04_2010   RAGAVA
                Dim _strQuery As String = ""
                Dim oSelectedRESLDataRow As DataRow = Nothing
                If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then       '19_05_2010   RAGAVA     NEW DESIGN
                        _strQuery = "Select * from PortIntegralRaisedPortDetails where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness and portSize = " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text = "3/4", 0.75, 0.5625).ToString
                        oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = 0
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = 0
                        If Not IsNothing(oSelectedRESLDataRow) Then
                            If Not IsDBNull(oSelectedRESLDataRow("StickOut")) Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = oSelectedRESLDataRow("StickOut")
                            End If
                            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Threaded End" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedRESLDataRow("MinWallThickness") + oSelectedRESLDataRow("ButtonHeight") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength 'min wall THK + button height + swing scearence+thread length
                            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedRESLDataRow("MinWallThickness") + oSelectedRESLDataRow("ButtonHeight") 'min wall THK + button height 
                            Else
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedRESLDataRow("MinWallThickness") + oSelectedRESLDataRow("ButtonHeight") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance ' min wall THK + button height + swing scearence
                            End If
                        End If
                        '19_05_2010   RAGAVA     NEW DESIGN
                    Else
                        _strQuery = "Select * from PortIntegralRaisedPortDetails90 where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness and portSize = " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text = "3/4", 0.75, 0.5625).ToString
                        oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = 0
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = 0
                        If Not IsNothing(oSelectedRESLDataRow) Then
                            If Not IsDBNull(oSelectedRESLDataRow("DistanceFromTubeEndToRodStop")) Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = oSelectedRESLDataRow("DistanceFromTubeEndToRodStop")
                            End If
                            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Threaded End" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedRESLDataRow("MinWallThickness") + oSelectedRESLDataRow("ButtonHeight") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength 'min wall THK + button height + swing scearence+thread length
                            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedRESLDataRow("MinWallThickness") + oSelectedRESLDataRow("ButtonHeight") 'min wall THK + button height 
                            Else
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedRESLDataRow("MinWallThickness") + oSelectedRESLDataRow("ButtonHeight") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance ' min wall THK + button height + swing scearence
                            End If
                        End If
                    End If
                    'Till  Here
                Else
                    'Till  Here
                    Dim baseDia As Double
                    Dim PortBossDia As Double
                    oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortBossDiaAndBaseDia(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter)
                    If Not IsNothing(oSelectedRESLDataRow) Then
                        If Not IsDBNull(oSelectedRESLDataRow("BASEDIA")) Then
                            baseDia = oSelectedRESLDataRow("BASEDIA")
                        End If
                        If Not IsDBNull(oSelectedRESLDataRow("PortBossDia")) Then
                            PortBossDia = oSelectedRESLDataRow("PortBossDia")
                        End If
                    End If

                    Dim dblButtonPosition As Double
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2 Then
                        dblButtonPosition = 0.273
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter > 2 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 3 Then
                        dblButtonPosition = 0.281
                    Else
                        dblButtonPosition = 0.5
                    End If

                    Dim dblOverAllLength As Double
                    Dim dblTan_30 As Double = 0.57735026918962573
                    dblOverAllLength = ((baseDia - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter) / 2) * dblTan_30 + 0.17 + 0.2 + PortBossDia

                    '5_04_2010 Aruna
                    ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = dblButtonPosition - 0.125
                    _strQuery = ""
                    Dim dblButtonPlane As Double
                    Dim dblTotalWidth As Double
                    _strQuery = "Select * from welded.portIntegralDetails where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and TubeWallThickness= " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " and portDiameter= " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text = "3/4", 1.1, 0.9).ToString
                    oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
                    If Not IsNothing(oSelectedRESLDataRow) Then
                        If Not IsDBNull(oSelectedRESLDataRow("ButtonPlane")) Then
                            dblButtonPlane = oSelectedRESLDataRow("ButtonPlane")
                        End If
                        If Not IsDBNull(oSelectedRESLDataRow("TotalWidth")) Then
                            dblTotalWidth = oSelectedRESLDataRow("TotalWidth")
                        End If
                    End If
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = dblTotalWidth - dblButtonPlane - 0.125
                    '5_04_2010 Aruna Ends
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = dblButtonPlane + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Events"

    Private Sub frmConPlateClevis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        PlateClevisGenerateProcess()    'TODO: ANUP / RAGHAV 03-05-2010 03.51pm
        InitiallSettings()
        SearchForPlateClevisInDB()
    End Sub

    Private Sub chkUseMatcchedPlateClevis_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseMatcchedPlateClevis.CheckedChanged
        If chkUseMatcchedPlateClevis.Checked Then
            UcBrowsePlateClevis2.Visible = False
            btnMessage2.Visible = True

            'TODO: ANUP 23-04-2010 01.39pm
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateImportOrExisting = "Existing"
            '************
        Else
            UcBrowsePlateClevis2.Visible = True
            btnMessage2.Visible = False
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreClevisPlateCode = ""             '26_11_2010    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateCode = ""            '26_11_2010    RAGAVA
            'TODO: ANUP 23-04-2010 01.39pm
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ClevisPlateImportOrExisting = "Import"
            '**************
        End If
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, LabelGradient5, LabelGradient4, LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblPlateClevis)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient1)
    End Sub

    Private Sub UcBrowsePlateClevis2_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UcBrowsePlateClevis2.Load

    End Sub
    Private Sub UcBrowsePlateClevis1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub UcBrowsePlateClevis2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class