Public Class frmSLPortIntegral2

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
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
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
            SearchForExistingSingleLugCastings()

        End If
    End Sub


    Private Sub SearchForExistingSingleLugCastings()

        ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation(ObjClsWeldedCylinderFunctionalClass. _
                        ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, False, clsWeldedCylinderFunctionalClass.YeildStrengthConstants.SingleLug_Cast_FlushedPort, "2")       '18_07_2012   RAGAVA

        Dim dblRequiredArea As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
        Try
            '27_04_2010   RAGAVA
            Dim oBESLCastingWithPortDetails As DataTable
            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                '19_05_2010   RAGAVA     NEW DESIGN
                If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                    oBESLCastingWithPortDetails = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                                                BESLCastingWithRaisedPortDetails(_dblTempBoreDiameter, _dblTempWallThickness, _dblTempBushingWidth, _dblTempPinHoleSize, _dblTempBushingQuantity, _dblTempLugThickness, _
                                                 _dblTempSwingClearance, _strTempPortType, "2")       '18_07_2012   RAGAVA
                Else
                    oBESLCastingWithPortDetails = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                                                                  BESLCastingWithRaisedPortDetails90(_dblTempBoreDiameter, _dblTempWallThickness, _dblTempBushingWidth, _dblTempPinHoleSize, _dblTempBushingQuantity, _dblTempLugThickness, _
                                                                   _dblTempSwingClearance, _strTempPortType, "2")       '18_07_2012   RAGAVA
                End If
                'Till   Here
            Else
                oBESLCastingWithPortDetails = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                            BESLCastingWithFlushedPortDetails(_dblTempBoreDiameter, _dblTempWallThickness, _dblTempBushingWidth, _dblTempPinHoleSize, _dblTempBushingQuantity, _dblTempLugThickness, _
                             _dblTempSwingClearance, _strTempPortType, "2")       '18_07_2012   RAGAVA
            End If
            'Dim oBESLCastingWithFlushedPortDetails As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
            'BESLCastingWithFlushedPortDetails(_dblTempBoreDiameter, _dblTempWallThickness, _dblTempBushingWidth, _dblTempPinHoleSize, _dblTempBushingQuantity, _dblTempLugThickness, _
            ' _dblTempSwingClearance, _strTempPortType)
            '27_04_2010   RAGAVA   Till   Here

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBESLCastingDataTable = New DataTable
            If Not IsNothing(oBESLCastingWithPortDetails) Then

                'TODO:Anup 09-04-10 2pm
                oBESLCastingWithPortDetails.Columns.Add("CalculatedSafetyFactor")
                '*************************

                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBESLCastingDataTable = oBESLCastingWithPortDetails.Clone
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBESLCastingDataTable.NewRow()
                For Each oDataRow As DataRow In oBESLCastingWithPortDetails.Rows
                    oDataRow("Area") = Math.Round(oDataRow("LugThickness") * (oDataRow("LugWidth") - _dblTempPinHoleSize), 2) '07_04_2010 Aruna
                Next

                For Each oDataRow As DataRow In oBESLCastingWithPortDetails.Rows

                    'TODO:Anup 09-04-10 2pm
                    oDataRow("CalculatedSafetyFactor") = Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor + (oDataRow("Area") / dblRequiredArea), 2) - 1
                    '*************************

                    If Val(oDataRow("Area")) >= dblRequiredArea Then 'AndAlso Val(oDataRow("Area")) <= dblRequiredArea Then '06_04_2010 Aruna
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBESLCastingDataTable.Rows.Add(oDataRow.ItemArray)
                    End If
                Next
            End If

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBESLCastingDataTable.Rows.Count > 0 Then
                pnlSLCasting_YesNo.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingYes2.TopLevel = False
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingYes2.Created Then
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingYes2.ManualLoad()
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingYes2.Show()
                pnlSLCasting_YesNo.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingYes2)

                'TODO:Sunny 04-06-10
                ObjClsWeldedCylinderFunctionalClass.PortIntegral_ExistingDetailsFound = True
            Else
                pnlSLCasting_YesNo.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral2.TopLevel = False
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral2.Created Then
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral2.ManualLoad()
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral2.Show()
                pnlSLCasting_YesNo.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmSLCastingNo_PortIntegral2)

                'TODO:Sunny 04-06-10
                ObjClsWeldedCylinderFunctionalClass.PortIntegral_ExistingDetailsFound = False
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in SearchForExistingSingleLugCastings of frmSLPortIntegral " + ex.Message)
        End Try
    End Sub

#End Region

#Region "Events"

    Private Sub frmSLPortIntegral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        SetValuesToPrivateVariables()
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, lblSLHeading, LabelGradient4, LabelGradient2)
    End Sub

    Private Sub lblSLHeading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSLHeading.Click

    End Sub
End Class