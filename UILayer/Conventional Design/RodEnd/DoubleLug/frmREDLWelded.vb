Public Class frmREDLWelded

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

    'Sunny 03-06-10 
    Public Sub ManualLoad()
        ObjClsWeldedCylinderFunctionalClass.ObjFrmREDLNewDesign.IsPrimaryInputsReq = False
        LoadFunctionality()
    End Sub

    'Sunny 03-06-10 
    Private Sub LoadFunctionality()
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmREDLExistingDesign.ExistingDataFound() Then
            pnlExisitng_NewSelection.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmREDLExistingDesign.TopLevel = False
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmREDLExistingDesign.Created Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmREDLExistingDesign.ManualLoad()
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjFrmREDLExistingDesign.Show()
            pnlExisitng_NewSelection.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmREDLExistingDesign)
        Else
            pnlExisitng_NewSelection.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmREDLNewDesign.TopLevel = False
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmREDLNewDesign.Created Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmREDLNewDesign.ManualLoad()
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjFrmREDLNewDesign.Show()
            pnlExisitng_NewSelection.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmREDLNewDesign)
        End If
    End Sub

#End Region

#Region "Events"

    'Sunny 03-06-10 
    Private Sub frmREDLWelded_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        LoadFunctionality()
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, lblDLHeading, LabelGradient4, LabelGradient2)
    End Sub

End Class