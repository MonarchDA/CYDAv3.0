Public Class frmCastingNo_RECT

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

#Region "SubProcedures"

    Private _blnIsPrimaryInputsReq As Boolean = False

    Public Property IsPrimaryInputsReq() As Boolean
        Get
            Return _blnIsPrimaryInputsReq
        End Get
        Set(ByVal value As Boolean)
            _blnIsPrimaryInputsReq = value
        End Set
    End Property

    Public Sub ManualLoad()
        If DiableOptions() = False Then
            LoadFunctionality()
        End If
    End Sub

    Private Sub LoadFunctionality()
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        If rdbFabrication_RECT.Checked Then
            plnFabrication_Casting_RECT.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmFabrication_RECT.TopLevel = False
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmFabrication_RECT.Created Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmFabrication_RECT.ManualLoad()
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjFrmFabrication_RECT.Show()
            plnFabrication_Casting_RECT.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmFabrication_RECT)
        ElseIf rdbDesignACasting_RECT.Checked Then
            plnFabrication_Casting_RECT.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignACasting_RECT.TopLevel = False
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignACasting_RECT.Created Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignACasting_RECT.ManualLoad()
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignACasting_RECT.Show()
            plnFabrication_Casting_RECT.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignACasting_RECT)
        End If
        DisableCastingOption()
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
    End Sub

    Private Function DiableOptions() As Boolean
        DiableOptions = False
        _blnIsPrimaryInputsReq = False
        ObjClsWeldedCylinderFunctionalClass.WeldSizeCalculation()
        If ObjClsWeldedCylinderFunctionalClass.IsWeldSizeLess Then
            Me.Enabled = False
            DiableOptions = True
            _blnIsPrimaryInputsReq = True
        End If
    End Function



    'ONSITE:27-05-2010 To Disable the Casting option when cross tube width is less than rod diameter
    Private Sub DisableCastingOption()
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd < ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter Then
            rdbDesignACasting_RECT.Enabled = False
        Else
            rdbDesignACasting_RECT.Enabled = True
        End If
    End Sub
#End Region

#Region "Events"

    Private Sub rdbFabrication_RECT_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
      rdbFabrication_RECT.CheckedChanged, rdbDesignACasting_RECT.CheckedChanged
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        '24_02_2010 Aruna Start --
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndFabricationSelected = False
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndDesignSelected = False
        If rdbFabrication_RECT.Checked = True Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndFabricationSelected = True
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Fabricated"
            ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndDesignSelected = True
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Cast"
            ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Cast"
        End If
        '24_02_2010 Aruna End --
        LoadFunctionality()
    End Sub


    Private Sub frmCastingNo_RECT_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ColorTheForm()
        If DiableOptions() = False Then
            LoadFunctionality()
        End If
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblCastingNotMatched_RECT)
    End Sub

End Class