Public Class frmCTPortInTube2

    'TODO: ANUP 22-07-2010 12.14pm
    Private _blnIsPopulated As Boolean = False

#Region "Variables"

    Public dblBoreDiameter As Double
    Public dblWallThickness As Double
    Public dblBushingWidth As Double
    Public dblRequiredPinHoleSize As Double
    Public dblBushingQuantity As Double
    Public dblSwingClearance As Double
    Public dblCrossTubeWidth As Double
    Public dblOffSet As Double
    Public dblTubeOD As Double
    Public strTempPortType As String
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

#Region "Sub Procedures"
    '04_03_2010   RAGAVA
    Public ReadOnly Property ControlsData() As ArrayList
        Get
            ControlsData = New ArrayList
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingYes.rdbUseSelectedCrossTubeYes.Checked = True Then 'anup 16-02-2011
                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingYes.txtPinHoleSize.Text) <> "" Then
                    ControlsData.Add(New Object(3) {"GUI", "PinHoleSize", "L21", Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingYes.txtPinHoleSize.Text)})
                End If
            End If
            Return ControlsData
        End Get
    End Property

    Public Sub ManualLoad()
        'SearchForExistingCrossTubeCastings()manjula commented
        SetValuesToPrivateVariables()
    End Sub

    Private Sub SetValuesToPrivateVariables()

        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If

        If Not dblBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter _
         OrElse Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter = _rodDiameter _
              OrElse Not dblWallThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness _
              OrElse Not dblBushingWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth _
              OrElse Not dblRequiredPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize _
              OrElse Not dblBushingQuantity = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity _
              OrElse Not dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth _
              OrElse Not dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance _
              OrElse Not dblOffSet = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OffSet _
              OrElse Not strTempPortType = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd Then
            dblBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
            dblWallThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness
            dblBushingWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth
            dblRequiredPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
            dblBushingQuantity = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity
            dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
            dblOffSet = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OffSet
            dblTubeOD = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD
            _rodDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter

            'ANUP 17-09-2010 START 
            '  _dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
            dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
            'ANUP 17-09-2010 TILL HERE

            strTempPortType = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd

            SearchForExistingCrossTubeCastings()
        End If
    End Sub

    Private Sub SearchForExistingCrossTubeCastings()
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE

        'MANJULA COMMENTED

        'Dim dblBoreDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
        'Dim dblWallThickness As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness
        'Dim dblBushingWidth As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth
        'Dim dblRequiredPinHoleSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
        'Dim dblBushingQuantity As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity
        'Dim dblCrossTubeWidth As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
        'Dim dblOffSet As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OffSet
        'Dim dblTubeOD As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD
        'Dim dblSwingClearance As Double
        Try
            '16-02-10 by Sandeep
            ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation _
            (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, False, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.CrossTube_Cast_NoPort, "2")     '12_07_2012    RAGAVA
            dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
            Dim dblRequiredArea As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
            '16-02-10 by Sandeep

            Dim oBECrossTubeCastWithOutPortDetails As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
            BECrossTubeCastingWithoutPortDetails(dblBoreDiameter, dblWallThickness, dblBushingWidth, dblRequiredPinHoleSize, _
            dblBushingQuantity, dblSwingClearance, dblCrossTubeWidth, dblOffSet, dblTubeOD)

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBECrossTubeCastingDataTable = New DataTable
            If Not IsNothing(oBECrossTubeCastWithOutPortDetails) Then

                'TODO:Anup 09-04-10 2pm
                oBECrossTubeCastWithOutPortDetails.Columns.Add("CalculatedSafetyFactor")
                '*************************

                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBECrossTubeCastingDataTable = oBECrossTubeCastWithOutPortDetails.Clone

                For Each oDataRow As DataRow In oBECrossTubeCastWithOutPortDetails.Rows
                    oDataRow("Area") = Math.Round(oDataRow("CrossTubeWidth") * (oDataRow("CrossTubeOD") - dblRequiredPinHoleSize), 2)
                Next

                For Each oDataRow As DataRow In oBECrossTubeCastWithOutPortDetails.Rows
                    '16-02-10 by Sandeep
                    'ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation _
                    '(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, oDataRow("YieldStrength"))
                    '16-02-10 by Sandeep

                    'TODO:Anup 09-04-10 2pm
                    oDataRow("CalculatedSafetyFactor") = Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor + (oDataRow("Area") / dblRequiredArea), 2) - 1
                    '*************************

                    If Not IsDBNull(oDataRow("Area")) Then
                        If Val(oDataRow("Area")) >= dblRequiredArea Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBECrossTubeCastingDataTable.Rows.Add(oDataRow.ItemArray)
                        End If
                    End If
                Next
            End If

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBECrossTubeCastingDataTable.Rows.Count > 0 Then
                pnlCasting_YesNo.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingYes2.TopLevel = False
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingYes2.Created Then
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingYes2.ManualLoad()
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingYes2.Show()
                pnlCasting_YesNo.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingYes2)
                ObjClsWeldedCylinderFunctionalClass.PortIntegral_ExistingDetailsFound = True '14-05-2012 MANJULA ADDED
            Else
                pnlCasting_YesNo.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube2.TopLevel = False
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube2.Created Then
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube2.ManualLoad()
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube2.Show()
                pnlCasting_YesNo.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmCTCastingNo_PortInTube2)
                ObjClsWeldedCylinderFunctionalClass.PortIntegral_ExistingDetailsFound = False '14-05-2012 MANJULA ADDED
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in SearchForExistingCrossTubeCastings of frmCTPortInTube " + ex.Message)
        End Try

    End Sub

#End Region

#Region "Events"

    Private Sub frmCTPortInTube_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ColorTheForm()
        'SearchForExistingCrossTubeCastings() MANJULA COMMENTED
        SetValuesToPrivateVariables()
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, LabelGradient5, LabelGradient4, LabelGradient2)
    End Sub


End Class