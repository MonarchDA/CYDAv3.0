Public Class frmDLPortIntegral

    'TODO: ANUP 22-07-2010 12.14pm
    Private _blnIsPopulated As Boolean = False
    Public dblBoreDiameter As Double
    Public dblWallThickness As Double
    Public dblBushingWidth As Double
    Public dblRequiredPinHoleSize As Double
    Public dblBushingQuantity As Double
    Public dblRequiredLugThickness As Double
    Public dblSwingClearance As Double
    Public dblLugGap As Double
    Public _rodDiameter As Double

      

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
        SetValuesToPrivateVariables()
    End Sub

    '30-04-2012 MANJULA ADDED
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
                       OrElse Not dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness _
                       OrElse Not dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text _
                       OrElse Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TempWorkingPressure _
                       OrElse Not dblLugGap = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap Then             '31_03_2010   RAGAVA
            dblBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
            dblWallThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness
            dblBushingWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth
            dblRequiredPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
            dblBushingQuantity = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity
            dblRequiredLugThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
            dblLugGap = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap
            _rodDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter



            'ANUP 17-09-2010 START 
            '  _dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
            dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text
            'ANUP 17-09-2010 TILL HERE

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TempWorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure           '31_03_2010   RAGAVA
            SearchForExistingDoubleLugCastings()
        End If
        ' SearchForExistingDoubleLugCastings()
    End Sub

    Private Sub SearchForExistingDoubleLugCastings()
        'ANUP 11-10-2010 START
        'If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
        '    IsPopulated = True
        'End If
        'ANUP 11-10-2010 TILL HERE
        ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation(0, False)
        '30-04-2012 MANJULA COMMENTED
        'Dim dblBoreDiameter As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
        'Dim dblWallThickness As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness
        'Dim dblBushingWidth As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth
        'Dim dblRequiredLugThickness As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness
        'Dim dblRequiredPinHoleSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
        'Dim dblBushingQuantity As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity

        ''ANUP 17-09-2010 START 
        '' Dim dblSwingClearance As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
        'Dim dblSwingClearance As Double = ObjClsWeldedCylinderFunctionalClass.TxtSwingClearance_BaseEnd.Text
        'ANUP 17-09-2010 TILL HERE

        Dim strPortType As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd          '01_03_2010    RAGAVA
        Dim dblRequiredArea As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AreaRequired
        'Dim dblLugGap As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap

        '27_04_2010   RAGAVA   NEW DESIGN
        Dim oBEDLCastingPortDetails As DataTable
        If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
            '19_05_2010   RAGAVA     NEW DESIGN
            If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                oBEDLCastingPortDetails = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                                    BEDLCastingWithRaisedPortDetails(dblBoreDiameter, dblWallThickness, dblBushingWidth, dblRequiredPinHoleSize, dblBushingQuantity, dblRequiredLugThickness, _
                                    dblLugGap, dblSwingClearance, strPortType)
            Else
                oBEDLCastingPortDetails = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                    BEDLCastingWithRaisedPortDetails90(dblBoreDiameter, dblWallThickness, dblBushingWidth, dblRequiredPinHoleSize, dblBushingQuantity, dblRequiredLugThickness, _
                    dblLugGap, dblSwingClearance, strPortType)
            End If
            'Till    Here
        Else
            oBEDLCastingPortDetails = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
        BEDLCastingWithFlushedPortDetails(dblBoreDiameter, dblWallThickness, dblBushingWidth, dblRequiredPinHoleSize, dblBushingQuantity, dblRequiredLugThickness, _
        dblLugGap, dblSwingClearance, strPortType)
        End If
        'Till    Here

        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBEDLCastingDataTable = New DataTable
        If Not IsNothing(oBEDLCastingPortDetails) Then

            'TODO:Anup 09-04-10 2pm
            oBEDLCastingPortDetails.Columns.Add("CalculatedSafetyFactor")
            '*************************

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBEDLCastingDataTable = oBEDLCastingPortDetails.Clone
            Dim oMatchedULugDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBEDLCastingDataTable.NewRow
            For Each oDataRow As DataRow In oBEDLCastingPortDetails.Rows
                'oDataRow("AreaBasedonPinholeRequired") = 2 * Math.Round(oDataRow("LugThickness") * (oDataRow("LugWidth") - dblRequiredPinHoleSize), 2) '07_04_2010 Aruna
                oDataRow("AreaBasedonPinholeRequired") = 2 * Val(oDataRow("AreaBasedonPinholeRequired")) 'ANUP 14-10-2010
            Next

            For Each oDataRow As DataRow In oBEDLCastingPortDetails.Rows

                'TODO:Anup 09-04-10 2pm
                oDataRow("CalculatedSafetyFactor") = Math.Round(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NutSafetyFactor + (oDataRow("AreaBasedonPinholeRequired") / dblRequiredArea), 2) - 1
                '*************************

                If Val(oDataRow("AreaBasedonPinholeRequired")) >= dblRequiredArea Then 'AndAlso Val(oDataRow("AreaBasedonPinholeRequired")) <= dblRequiredArea Then 'Val(dblRequiredArea * 1.25) Then 07_04_2010 Aruna
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBEDLCastingDataTable.Rows.Add(oDataRow.ItemArray)
                End If
            Next
        End If

        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MatchedBEDLCastingDataTable.Rows.Count > 0 Then
            pnlCasting_YesNo.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingYes.TopLevel = False
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingYes.Created Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingYes.ManualLoad()
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingYes.Show()
            pnlCasting_YesNo.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingYes)

            'TODO:Sunny 04-06-10
            ObjClsWeldedCylinderFunctionalClass.PortIntegral_ExistingDetailsFound = True
        Else
            pnlCasting_YesNo.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.TopLevel = False
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.Created Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.ManualLoad()
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral.Show()
            pnlCasting_YesNo.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral)

            'TODO:Sunny 04-06-10
            ObjClsWeldedCylinderFunctionalClass.PortIntegral_ExistingDetailsFound = False
        End If
    End Sub

#End Region

#Region "Events"

    Private Sub frmDLPortIntegral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        SetValuesToPrivateVariables()
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, LabelGradient5, LabelGradient4, LabelGradient2)
    End Sub

End Class