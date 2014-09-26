Public Class frmBasePlugCastingNoPortIntegral

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
        LoadFunctionality()

        'TODO:Sunny 04-06-10
        rdbDesignABasePlug.Checked = True
    End Sub

    Private Sub LoadFunctionality()
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        If rdbDesignABasePlug.Checked Then
            btnDisplayPortInTube.Visible = False
            plnPortInTube_BasePlug.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignABasePlug.TopLevel = False
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignABasePlug.Created Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignABasePlug.ManualLoad()
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignABasePlug.Show()
            plnPortInTube_BasePlug.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignABasePlug)

        ElseIf rdbPortInTube.Checked Then
            plnPortInTube_BasePlug.Controls.Clear()
            btnDisplayPortInTube.Visible = True
            btnDisplayPortInTube.BringToFront()
        End If
    End Sub

    Private Sub DefaultSettings()
        btnDisplayPortInTube.Visible = False
    End Sub

#End Region

#Region "Events"

    Private Sub rdbDesignABasePlug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDesignABasePlug.CheckedChanged
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = False
        If rdbDesignABasePlug.Checked = True Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = True
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Cast"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = ""        '11_03_2010   RAGAVA
        End If
        LoadFunctionality()
    End Sub

    Private Sub frmBasePlugCastingNoPortIntegral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        DefaultSettings()
        LoadFunctionality()

        'TODO:Sunny 04-06-10
        rdbDesignABasePlug.Checked = True
    End Sub

    Private Sub rdbPortInTube_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPortInTube.CheckedChanged
        If rdbPortInTube.Checked Then
            btnDisplayPortInTube.Visible = True
            btnDisplayPortInTube.BringToFront()
            ObjClsWeldedCylinderFunctionalClass.ShowPortInTube_Thru_PortIntegral = True
            ObjClsWeldedCylinderFunctionalClass.ChangeScreensFlow()
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        Else
            ObjClsWeldedCylinderFunctionalClass.ShowPortInTube_Thru_PortIntegral = False
        End If
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lbBasePlugNotMatched)
    End Sub

End Class

