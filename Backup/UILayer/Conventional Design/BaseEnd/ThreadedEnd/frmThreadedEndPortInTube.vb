Public Class frmThreadedEndPortInTube

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

#Region "Private Variables"
    Dim _dblTempBoreDiameter As Double
    Dim _dblTempWallThickness As Double
    Dim _dblTempThreadDiameter As Double
    Dim _dblTempThreadLength As Double
#End Region

#Region "SubProcedures"

    Public Sub ManualLoad()
        'If Not _dblTempBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter _
        'OrElse Not _dblTempWallThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness _
        'OrElse Not _dblTempThreadDiameter = Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.txtThreadDiameter.Text) _
        'OrElse Not _dblTempThreadLength = Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.txtThreadLength.Text) Then
        _dblTempBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
        _dblTempWallThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness
        _dblTempThreadDiameter = Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbThreadSize.Text)
        _dblTempThreadLength = Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.txtThreadLength.Text)
        SearchForMatchingThreaded()
        'End If
    End Sub

    Private Sub SearchForMatchingThreaded()
        Try
           
            Dim dblSafetyFactor As Double = 1     'This is a Calculated Value and Calculation need to be added

            Dim oThreadedBaseNoPortDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetBEThreadedBaseNoPortDetails _
            (_dblTempBoreDiameter, _dblTempWallThickness, _dblTempThreadDiameter, _dblTempThreadLength, dblSafetyFactor)
            If Not IsNothing(oThreadedBaseNoPortDataTable) Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BEMatchedThreadedEndcastingDataTable = oThreadedBaseNoPortDataTable
                pnlCasting_YesNo.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmThreadedCastingYes.TopLevel = False
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmThreadedCastingYes.Created Then
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmThreadedCastingYes.ManualLoad()
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjFrmThreadedCastingYes.Show()
                pnlCasting_YesNo.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmThreadedCastingYes)
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BEMatchedThreadedEndcastingDataTable = Nothing
                pnlCasting_YesNo.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignAThreadedCasting.TopLevel = False
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignAThreadedCasting.Created Then
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignAThreadedCasting.ManualLoad()
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignAThreadedCasting.Show()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignAThreadedCasting.BackColor = Color.Black
                pnlCasting_YesNo.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignAThreadedCasting)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadFunctionality()
        ManualLoad() '02_04_2010 Aruna
        SearchForMatchingThreaded()
    End Sub

#End Region

#Region "Events"

    Private Sub frmThreadedEndPortInTube_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        LoadFunctionality()
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, LabelGradient5, LabelGradient4, LabelGradient2)
    End Sub
End Class