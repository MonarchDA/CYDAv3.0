Public Class frmThreadedEndPortIntegral

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

    Dim _dblTempBoreDiameter As Double
    Dim _dblTempWallThickness As Double
    Dim _dblTempThreadDiameter As Double
    Dim _dblTempThreadLength As Double
#End Region

#Region "Sub Procedures"

    Public Sub ManualLoad()
        'If Not _dblTempBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter _
        'OrElse Not _dblTempWallThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness _
        'OrElse Not _dblTempThreadDiameter = Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.txtThreadDiameter.Text) _
        'OrElse Not _dblTempThreadLength = Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.txtThreadLength.Text) Then
        _dblTempBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
        _dblTempWallThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness
        _dblTempThreadDiameter = Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbThreadSize.Text)
        _dblTempThreadLength = Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.txtThreadLength.Text)
        SearchForExistingThreadedEndCastings()
        'End If
    End Sub

    Private Sub SearchForExistingThreadedEndCastings()

        ObjClsWeldedCylinderFunctionalClass.Area_Y_LugWidth_LugThickness_Calculation(0, False)

        Dim dblSafetyFactor As Double = 1

        '27_04_2010   RAGAVA   NEW DESIGN
        Dim oBEThreadedEndCastingWithFlushedPortDetails As DataTable
        If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
            '19_05_2010   RAGAVA     NEW DESIGN
            If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                oBEThreadedEndCastingWithFlushedPortDetails = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                GetBEThreadedBaseRaisedPortDetails(_dblTempBoreDiameter, _dblTempWallThickness, _dblTempThreadDiameter, _dblTempThreadLength, dblSafetyFactor)
            Else
                oBEThreadedEndCastingWithFlushedPortDetails = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
               GetBEThreadedBaseRaisedPortDetails90(_dblTempBoreDiameter, _dblTempWallThickness, _dblTempThreadDiameter, _dblTempThreadLength, dblSafetyFactor)
            End If
            'Till  Here
        Else
            oBEThreadedEndCastingWithFlushedPortDetails = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
           GetBEThreadedBaseFlushPortDetails(_dblTempBoreDiameter, _dblTempWallThickness, _dblTempThreadDiameter, _dblTempThreadLength, dblSafetyFactor)
        End If
        'Dim oBEThreadedEndCastingWithFlushedPortDetails As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
        'GetBEThreadedBaseFlushPortDetails(_dblTempBoreDiameter, _dblTempWallThickness, _dblTempThreadDiameter, _dblTempThreadLength, dblSafetyFactor)
        'Till   Here

        If Not IsNothing(oBEThreadedEndCastingWithFlushedPortDetails) Then
            ObjClsWeldedCylinderFunctionalClass.ShowPortInTube_Thru_PortIntegral = False
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BEMatchedThreadedEndcastingDataTable = oBEThreadedEndCastingWithFlushedPortDetails
            pnlCasting_YesNo.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmThreadedEndCastingYes_PortIntegral.TopLevel = False
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmThreadedEndCastingYes_PortIntegral.Created Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmThreadedEndCastingYes_PortIntegral.ManualLoad()
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjFrmThreadedEndCastingYes_PortIntegral.Show()
            pnlCasting_YesNo.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmThreadedEndCastingYes_PortIntegral)

            'TODO:Sunny 04-06-10
            ObjClsWeldedCylinderFunctionalClass.PortIntegral_ExistingDetailsFound = True
        Else
            pnlCasting_YesNo.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmBEThreadedEndCastingNo_PortIntegral.TopLevel = False
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmBEThreadedEndCastingNo_PortIntegral.Created Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmBEThreadedEndCastingNo_PortIntegral.ManualLoad()
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjFrmBEThreadedEndCastingNo_PortIntegral.Show()
            pnlCasting_YesNo.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmBEThreadedEndCastingNo_PortIntegral)

            'TODO:Sunny 04-06-10
            ObjClsWeldedCylinderFunctionalClass.PortIntegral_ExistingDetailsFound = False
        End If

    End Sub

#End Region

#Region "Events"

    Private Sub frmSLPortIntegral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        ManualLoad() '02_04_2010 ARuna
        SearchForExistingThreadedEndCastings()
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, LabelGradient5, LabelGradient4, LabelGradient2)
    End Sub
End Class