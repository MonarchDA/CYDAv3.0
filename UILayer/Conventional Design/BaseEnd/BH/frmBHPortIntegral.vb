Public Class frmBHPortIntegral

    Private _blnIsPopulated As Boolean = False

    Public Property IsPopulated() As Boolean
        Get
            Return _blnIsPopulated
        End Get
        Set(ByVal value As Boolean)
            _blnIsPopulated = value
        End Set
    End Property

#Region "Variables"

    Public _dblTempBoreDiameter As Double
    Public _dblTempWallThickness As Double
    Public _dblTempBushingWidth As Double
    Public _dblTempPinHoleSize As Double
    Public _dblTempBushingQuantity As Double
    Public _dblTempLugThickness As Double
    Public _dblTempSwingClearance As Double
    Public _strTempPortType As String
    Public _rodDiameter As Double




#End Region

#Region "Sub Procedures"

    Public Sub ManualLoad()
        SetValuesToPrivateVariables()
    End Sub

    Private Sub SetValuesToPrivateVariables()

        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If

        If Not _dblTempBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter _
         OrElse Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter = _rodDiameter _
              OrElse Not _dblTempWallThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness _
              OrElse Not _dblTempBushingWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth _
              OrElse Not _dblTempPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize _
              OrElse Not _dblTempBushingQuantity = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity _
              OrElse Not _dblTempLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness _
              OrElse Not _dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text _
              OrElse Not _strTempPortType = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd Then
            _dblTempBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
            _dblTempWallThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness
            _dblTempBushingWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth
            _dblTempPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
            _dblTempBushingQuantity = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity
            _dblTempLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
            _rodDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter

            'ANUP 17-09-2010 START 
            '  _dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
            _dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text
            'ANUP 17-09-2010 TILL HERE

            _strTempPortType = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd

            SearchForExistingBHCastings()
        End If
    End Sub

    Private Sub SearchForExistingBHCastings()

        ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation(ObjClsWeldedCylinderFunctionalClass. _
                        ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, False, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.SingleLug_Cast_FlushedPort)

        Dim dblRequiredArea As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
        Try
            '27_04_2010   RAGAVA
            Dim oBEBHCastingWithPortDetails As DataTable
            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                '19_05_2010   RAGAVA     NEW DESIGN
                If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                    oBEBHCastingWithPortDetails = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                                                BEBHCastingWithRaisedPortDetails(_dblTempBoreDiameter, _dblTempWallThickness, _dblTempBushingWidth, _dblTempPinHoleSize, _dblTempBushingQuantity, _dblTempLugThickness, _
                                                 _dblTempSwingClearance, _strTempPortType)
                Else
                    oBEBHCastingWithPortDetails = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                                                                  BEBHCastingWithRaisedPortDetails90(_dblTempBoreDiameter, _dblTempWallThickness, _dblTempBushingWidth, _dblTempPinHoleSize, _dblTempBushingQuantity, _dblTempLugThickness, _
                                                                   _dblTempSwingClearance, _strTempPortType)
                End If
                'Till   Here
            Else
                oBEBHCastingWithPortDetails = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                            BEBHCastingWithFlushedPortDetails(_dblTempBoreDiameter, _dblTempWallThickness, _dblTempBushingWidth, _dblTempPinHoleSize, _dblTempBushingQuantity, _dblTempLugThickness, _
                             _dblTempSwingClearance, _strTempPortType)
            End If
            'Dim oBESLCastingWithFlushedPortDetails As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
            'BESLCastingWithFlushedPortDetails(_dblTempBoreDiameter, _dblTempWallThickness, _dblTempBushingWidth, _dblTempPinHoleSize, _dblTempBushingQuantity, _dblTempLugThickness, _
            ' _dblTempSwingClearance, _strTempPortType)
            '27_04_2010   RAGAVA   Till   Here

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBESLCastingDataTable = New DataTable
            If Not IsNothing(oBEBHCastingWithPortDetails) Then

                'TODO:Anup 09-04-10 2pm
                oBEBHCastingWithPortDetails.Columns.Add("CalculatedSafetyFactor")
                '*************************

                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBESLCastingDataTable = oBEBHCastingWithPortDetails.Clone
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBESLCastingDataTable.NewRow()
                For Each oDataRow As DataRow In oBEBHCastingWithPortDetails.Rows
                    oDataRow("Area") = Math.Round(oDataRow("LugThickness") * (oDataRow("LugWidth") - _dblTempPinHoleSize), 2) '07_04_2010 Aruna
                Next

                For Each oDataRow As DataRow In oBEBHCastingWithPortDetails.Rows

                    'TODO:Anup 09-04-10 2pm
                    oDataRow("CalculatedSafetyFactor") = Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor + (oDataRow("Area") / dblRequiredArea), 2) - 1
                    '*************************

                    If Val(oDataRow("Area")) >= dblRequiredArea Then 'AndAlso Val(oDataRow("Area")) <= dblRequiredArea Then '06_04_2010 Aruna
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBESLCastingDataTable.Rows.Add(oDataRow.ItemArray)
                    End If
                Next
            End If

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBESLCastingDataTable.Rows.Count > 0 Then
                pnlBHCasting_YesNo.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes.TopLevel = False
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes.Created Then
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes.ManualLoad()
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes.Show()
                pnlBHCasting_YesNo.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes)

                'TODO:Sunny 04-06-10
                ObjClsWeldedCylinderFunctionalClass.PortIntegral_ExistingDetailsFound = True
            Else
                pnlBHCasting_YesNo.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortIntegral.TopLevel = False
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortIntegral.Created Then
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortIntegral.ManualLoad()
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortIntegral.Show()
                pnlBHCasting_YesNo.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortIntegral)

                'TODO:Sunny 04-06-10
                ObjClsWeldedCylinderFunctionalClass.PortIntegral_ExistingDetailsFound = False
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in SearchForExistingBHCastings of frmBHPortIntegral " + ex.Message)
        End Try
    End Sub

#End Region

#Region "Events"

    Private Sub frmBHPortIntegral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        SetValuesToPrivateVariables()
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, lblBHHeading, LabelGradient4, LabelGradient2)
    End Sub

End Class