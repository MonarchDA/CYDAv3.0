Public Class frmBHPortInTube2

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
    Public _rodDiameter As Double




#End Region

#Region "Properties"

    Public ReadOnly Property ControlsData() As ArrayList
        Get
            ControlsData = New ArrayList

            Return ControlsData
        End Get
    End Property

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
                OrElse Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TempWorkingPressure Then             '31_03_2010   RAGAVA
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

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TempWorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure           '31_03_2010   RAGAVA
            SearchForExistingBHCastings()
        End If
    End Sub

    Private Sub SearchForExistingBHCastings()
        Try
            Dim oBEBHCastWithOutPortDetails As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
            BEBHCastingWithoutPortDetails(_dblTempBoreDiameter, _dblTempWallThickness, _dblTempBushingWidth, _dblTempPinHoleSize, _dblTempBushingQuantity, _dblTempLugThickness, _
            _dblTempSwingClearance, "2")   '02_07_2012   RAGAVA

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBESLCastingDataTable = New DataTable
            If Not IsNothing(oBEBHCastWithOutPortDetails) Then

                'TODO:Anup 09-04-10 2pm
                oBEBHCastWithOutPortDetails.Columns.Add("CalculatedSafetyFactor")
                '*************************

                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBESLCastingDataTable = oBEBHCastWithOutPortDetails.Clone
                For Each oDataRow As DataRow In oBEBHCastWithOutPortDetails.Rows
                    oDataRow("Area") = Math.Round(oDataRow("LugThickness") * (oDataRow("LugWidth") - _dblTempPinHoleSize), 2)
                Next

                For Each oDataRow As DataRow In oBEBHCastWithOutPortDetails.Rows
                    If Not IsDBNull(oDataRow("Area")) Then
                        ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation(ObjClsWeldedCylinderFunctionalClass. _
                        ObjClsWeldedGlobalVariables.EndConditionSafetyFactor, False, oDataRow("YieldStrength"))
                        Dim dblRequiredArea As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired

                        'TODO:Anup 09-04-10 2pm
                        oDataRow("CalculatedSafetyFactor") = Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor + (oDataRow("Area") / dblRequiredArea), 2) - 1
                        '*************************

                        If Val(oDataRow("Area")) >= dblRequiredArea Then 'AndAlso Val(oDataRow("Area")) <= Val(dblRequiredArea * 1.25) Then   '05_04_2010   RAGAVA
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBESLCastingDataTable.Rows.Add(oDataRow.ItemArray)
                        End If
                    End If
                Next
            End If

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBESLCastingDataTable.Rows.Count > 0 Then
                pnlBHCasting_YesNo.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes2.TopLevel = False
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes2.Created Then
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes2.ManualLoad()
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes2.Show()
                pnlBHCasting_YesNo.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingYes2)
                ObjClsWeldedCylinderFunctionalClass.PortIntegral_ExistingDetailsFound = True '08-05-2012 MANJULA ADDED
            Else
                ObjClsWeldedCylinderFunctionalClass.ShowCastingNo_Thru_CastingYes = False
                pnlBHCasting_YesNo.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortInTube2.TopLevel = False
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortInTube2.Created Then
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortInTube2.ManualLoad()
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortInTube2.Show()
                pnlBHCasting_YesNo.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmBHCastingNo_PortInTube2)
                ObjClsWeldedCylinderFunctionalClass.PortIntegral_ExistingDetailsFound = False '08-05-2012 MANJULA ADDED
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in SearchForExistingBHCastings of frmBHPortinTube " + ex.Message)
        End Try
    End Sub

#End Region
    Private Sub frmBHPortInTube_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        SetValuesToPrivateVariables()
    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, lblBHHeading, LabelGradient4, LabelGradient2)
    End Sub
End Class