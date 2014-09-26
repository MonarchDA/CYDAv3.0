Public Class frmBasePlugPortInTube


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

#Region "Sub Procedures"

    Public Sub ManualLoad()
        SearchForExistingBasePlugCastings()
    End Sub

    Private Sub SearchForExistingBasePlugCastings()
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation(0, False)

        Dim dblBoreDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
        Dim dblWallThickness As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness
        Dim dblRequiredPinHoleSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
        Dim dblBushingQuantity As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity
        Dim dblSwingClearance As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
        Dim strPortType As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_RodEnd
        Dim dblRequiredArea As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
        Dim dblMilledFlatWidth As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatWidth
        Dim dblBushingWidth As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth
        Dim dblBPOD As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter
        Dim dblOutSidePlugDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter

        '04_12_2009   Ragava
        'Dim oBEBasePlugCastWithOutPortDetails As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
        '        BEBasePlugCastingWithoutPortDetails(dblBoreDiameter, dblWallThickness, dblBushingWidth, dblRequiredPinHoleSize, dblBushingQuantity, _
        '         dblSwingClearance, dblBPOD, dblOutSidePlugDiameter)
        Dim oBEBasePlugCastWithOutPortDetails As DataTable
        If dblBushingQuantity = 0 Then
            dblBushingWidth = dblMilledFlatWidth
        End If
        oBEBasePlugCastWithOutPortDetails = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                BEBasePlugCastingWithoutPortDetails(dblBoreDiameter, dblWallThickness, dblBushingWidth, dblRequiredPinHoleSize, dblBushingQuantity, _
                 dblSwingClearance, dblBPOD, dblOutSidePlugDiameter)

        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBEBPCastingDataTable = New DataTable
        If Not IsNothing(oBEBasePlugCastWithOutPortDetails) Then

            'TODO:Anup 09-04-10 2pm
            oBEBasePlugCastWithOutPortDetails.Columns.Add("CalculatedSafetyFactor")
            '*************************

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBEBPCastingDataTable = oBEBasePlugCastWithOutPortDetails.Clone
            Dim oMatchedULugDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBEBPCastingDataTable.NewRow
            For Each oDataRow As DataRow In oBEBasePlugCastWithOutPortDetails.Rows
                Try
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlat = "No" Then
                        oDataRow("AreaBasedonPinholeRequired") = (Math.PI * (Math.Pow(oDataRow("OutsidePlugDiameter"), 2)) / 4) - (Val(oDataRow("PinHoleCustomID")) * oDataRow("OutsidePlugDiameter"))
                    Else
                        '04_12_2009  RAGAVA
                        'oDataRow("AreaBasedonPinholeRequired") = oDataRow("OutsidePlugDiameter") * ((Val(oDataRow("MilledFlatWidth"))) - dblRequiredPinHoleSize)
                        Dim OuterDia As Double = oDataRow("OutsidePlugDiameter")
                        Dim MilledFlatWidth As Double = Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.txtMilledFlatWidth.Text)
                        Dim h As Double = (OuterDia - MilledFlatWidth) / 2
                        Dim PinHoleArea As Double = dblRequiredPinHoleSize * MilledFlatWidth
                        Dim AreaOfSegment As Double = (4 / 3) * Math.Pow(h, 2) * Math.Sqrt((OuterDia / h) - 0.608)
                        Dim AreaOfCircle As Double = (Math.PI * (Math.Pow(OuterDia, 2)) / 4)
                        oDataRow("AreaBasedonPinholeRequired") = AreaOfCircle - (2 * AreaOfSegment + PinHoleArea)
                        '04_12_2009  RAGAVA   Till  Here
                    End If
                Catch ex As Exception
                End Try
            Next
            For Each oDataRow As DataRow In oBEBasePlugCastWithOutPortDetails.Rows

                'TODO:Anup 09-04-10 2pm
                Try
                    oDataRow("CalculatedSafetyFactor") = Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor + (oDataRow("AreaBasedonPinholeRequired") / dblRequiredArea), 2) - 1
                Catch ex As Exception

                End Try
                '*************************

                If Val(oDataRow("AreaBasedonPinholeRequired")) >= dblRequiredArea Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBEBPCastingDataTable.Rows.Add(oDataRow.ItemArray)
                End If
            Next
        End If

        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBEBPCastingDataTable.Rows.Count > 0 Then
            pnlCasting_YesNo.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmBasePlugCastingYes.TopLevel = False
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmBasePlugCastingYes.Created Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmBasePlugCastingYes.ManualLoad()
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjFrmBasePlugCastingYes.Show()
            pnlCasting_YesNo.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmBasePlugCastingYes)
        Else
            '02_12_2009   RAGAVA
            pnlCasting_YesNo.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ShowCastingNo_Thru_CastingYes = False
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignABasePlug.TopLevel = False
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignABasePlug.Created Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignABasePlug.ManualLoad()
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignABasePlug.Show()
            pnlCasting_YesNo.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignABasePlug)
        End If
    End Sub

#End Region

#Region "Events"

    Private Sub frmBasePlugPortInTube_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        SearchForExistingBasePlugCastings()
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, LabelGradient5, LabelGradient4, LabelGradient2)
    End Sub
End Class