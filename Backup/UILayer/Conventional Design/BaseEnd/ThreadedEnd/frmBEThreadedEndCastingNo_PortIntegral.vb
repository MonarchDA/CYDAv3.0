Public Class frmBEThreadedEndCastingNo_PortIntegral

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

    Private Sub DefaultSettings()
        rdbDesignACasting.Checked = True
        btnDisplayPortInTube.Visible = False
    End Sub

    Public Sub ManualLoad()
        LoadFunctionality()

        'TODO:Sunny 04-06-10
        rdbDesignACasting.Checked = True
    End Sub

    Private Sub LoadFunctionality()
        '22_06_2010   RAGAVA
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
            rdbPortInTube.Checked = False
            rdbPortInTube.Enabled = False
        Else
            rdbPortInTube.Enabled = True
        End If
        'Till   Here
        If rdbDesignACasting.Checked Then
            btnDisplayPortInTube.Visible = False
            pnlThreadedEndDesingaCasting.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignAThreadedCasting.TopLevel = False
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignAThreadedCasting.Created Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignAThreadedCasting.ManualLoad()
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignAThreadedCasting.Show()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignAThreadedCasting.BackColor = Color.Ivory
            pnlThreadedEndDesingaCasting.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmDesignAThreadedCasting)
        Else
            pnlThreadedEndDesingaCasting.Controls.Clear()
            btnDisplayPortInTube.Visible = True
            btnDisplayPortInTube.BringToFront()
        End If
    End Sub

#End Region

#Region "Events"

    Private Sub frmDLCastingNo_PortIntegral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        DefaultSettings()
        LoadFunctionality()

        'TODO:Sunny 04-06-10
        rdbDesignACasting.Checked = True
    End Sub

    Private Sub rdbPortInTube_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPortInTube.CheckedChanged, rdbDesignACasting.CheckedChanged
        If rdbPortInTube.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ShowPortInTube_Thru_PortIntegral = True
            ObjClsWeldedCylinderFunctionalClass.ChangeScreensFlow()
        ElseIf rdbDesignACasting.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ShowPortInTube_Thru_PortIntegral = False
        End If
        'Aruna:11-3-2010
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Cast"
        LoadFunctionality()
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblCastingNotMatched)
    End Sub

End Class