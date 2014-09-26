Public Class frmBasePlugPortIntegral

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
        SearchForExistingBasePlugCastingsPortIntegral()
    End Sub

    Private Sub SearchForExistingBasePlugCastingsPortIntegral()
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
        Dim dblBPOD As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BasePlugODPortIntegral
        'Dim dblOutSidePlugDiameterRequired As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BasePlugOutSidePlugDiameterRequiredPortIntegral
        Dim dblOutSidePlugDiameterRequired As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OutSidePlugDiameter      '18_03_2010    RAGAVA
        Try
            '27_04_2010   RAGAVA  NEW DESIGN
            Dim oBEBasePlugCastWithPortDetails As DataTable
            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                '19_05_2010   RAGAVA   NEW   DESIGN
                If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                    oBEBasePlugCastWithPortDetails = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                                                        BEBasePlugCastingWithRaisedPortDetails(dblBoreDiameter, dblWallThickness, dblBushingWidth, dblRequiredPinHoleSize, dblBushingQuantity, _
                                                          dblSwingClearance, dblBPOD, dblOutSidePlugDiameterRequired)
                Else
                    oBEBasePlugCastWithPortDetails = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                                                                           BEBasePlugCastingWithRaisedPortDetails90(dblBoreDiameter, dblWallThickness, dblBushingWidth, dblRequiredPinHoleSize, dblBushingQuantity, _
                                                                             dblSwingClearance, dblBPOD, dblOutSidePlugDiameterRequired)
                End If
                'Till   Here
            Else
                oBEBasePlugCastWithPortDetails = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                     BEBasePlugCastingWithPortDetails(dblBoreDiameter, dblWallThickness, dblBushingWidth, dblRequiredPinHoleSize, dblBushingQuantity, _
                       dblSwingClearance, dblBPOD, dblOutSidePlugDiameterRequired)
            End If
            '     Dim oBEBasePlugCastWithPortDetails As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
            'BEBasePlugCastingWithPortDetails(dblBoreDiameter, dblWallThickness, dblBushingWidth, dblRequiredPinHoleSize, dblBushingQuantity, _
            '  dblSwingClearance, dblBPOD, dblOutSidePlugDiameterRequired)
            'Till   Here

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBEBPCastingDataTable = New DataTable
            If Not IsNothing(oBEBasePlugCastWithPortDetails) Then

                'TODO:Anup 09-04-10 2pm
                oBEBasePlugCastWithPortDetails.Columns.Add("CalculatedSafetyFactor")
                '*************************

                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBEBPCastingDataTable = oBEBasePlugCastWithPortDetails.Clone
                Dim oMatchedULugDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBEBPCastingDataTable.NewRow
                For Each oDataRow As DataRow In oBEBasePlugCastWithPortDetails.Rows
                    oDataRow("Area") = Math.Round((Math.PI * (Math.Pow(oDataRow("OutsidePlugDiameter"), 2)) / 4) - (oDataRow("PinHoleSizeCombined") * oDataRow("OutsidePlugDiameter")), 2) '07_04_2010 Aruna
                Next


                For Each oDataRow As DataRow In oBEBasePlugCastWithPortDetails.Rows

                    'TODO:Anup 09-04-10 2pm
                    oDataRow("CalculatedSafetyFactor") = Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor + (oDataRow("Area") / dblRequiredArea), 2) - 1
                    '*************************

                    If Val(oDataRow("Area")) >= dblRequiredArea Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBEBPCastingDataTable.Rows.Add(oDataRow.ItemArray)
                    End If
                Next
            End If

        Catch ex As Exception

        End Try

        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBEBPCastingDataTable.Rows.Count > 0 Then
                pnlCasting_YesNo.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmBasePlugCastingYesPortIntegral.TopLevel = False
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmBasePlugCastingYesPortIntegral.Created Then
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmBasePlugCastingYesPortIntegral.ManualLoad()
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjFrmBasePlugCastingYesPortIntegral.Show()
                pnlCasting_YesNo.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmBasePlugCastingYesPortIntegral)

                'TODO:Sunny 04-06-10 
                ObjClsWeldedCylinderFunctionalClass.PortIntegral_ExistingDetailsFound = True
            Else
                pnlCasting_YesNo.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmBasePlugCastingNoPortIntegral.TopLevel = False
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmBasePlugCastingNoPortIntegral.Created Then
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmBasePlugCastingNoPortIntegral.ManualLoad()
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjFrmBasePlugCastingNoPortIntegral.Show()
                pnlCasting_YesNo.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmBasePlugCastingNoPortIntegral)

                'TODO:Sunny 04-06-10 
                ObjClsWeldedCylinderFunctionalClass.PortIntegral_ExistingDetailsFound = False
            End If
        Catch ex As Exception

        End Try
        
    End Sub

#End Region

#Region "Events"

    Private Sub frmBasePlugPortIntegral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        SearchForExistingBasePlugCastingsPortIntegral()
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, LabelGradient5, LabelGradient4, LabelGradient2)
    End Sub
End Class