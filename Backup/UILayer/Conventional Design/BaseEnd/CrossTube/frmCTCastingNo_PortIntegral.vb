Public Class frmCTCastingNo_PortIntegral

    'TODO: ANUP 22-07-2010 12.14pm
    Private _blnIsPopulated As Boolean = False

#Region "VARIABLES"
    Public dblBoreDiameter As Double
    Public dblWallThickness As Double
    Public dblBushingWidth As Double
    Public dblRequiredPinHoleSize As Double
    Public dblBushingQuantity As Double
    Public dblCrossTubeWidth As Double
    Public dblSwingClearance As Double
    Public dblOffset As Double
    Public strTempPortType As String
    Public _rodDiameter As Double
    
#End Region

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
        ' LoadFunctionality() MANJULA COMMENTED
        SetValuesToPrivateVariables()
        'rdbDesignACasting.Checked = True           '12_01_2012   RAGAVA
    End Sub

    '14-05-2012 MANJULA ADDED
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
                       OrElse Not dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth _
                       OrElse Not dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance _
                       OrElse Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TempWorkingPressure _
                       OrElse Not strTempPortType = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd _
                       OrElse Not dblOffset = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OffSet Then             '31_03_2010   RAGAVA
            dblBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
            dblWallThickness = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness
            dblBushingWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingWidth
            dblRequiredPinHoleSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
            dblBushingQuantity = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity
            dblCrossTubeWidth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth
            dblOffset = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OffSet
            strTempPortType = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd
            _rodDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter


            'ANUP 17-09-2010 START 
            '  _dblTempSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
            dblSwingClearance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
            'ANUP 17-09-2010 TILL HERE

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TempWorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure           '31_03_2010   RAGAVA
            rdbDesignACasting.Checked = False
            rdbFabricated.Checked = False
            rdbDesignACasting.Enabled = True
            rdbFabricated.Enabled = True
            plnPortInTube_Casting.Controls.Clear()
            LoadFunctionality()
        End If
        ' SearchForExistingDoubleLugCastings()
    End Sub


    Private Sub LoadFunctionality()
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        '22_06_2010   RAGAVA
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
            rdbPortInTube.Checked = False
            rdbPortInTube.Enabled = False
        Else
            rdbPortInTube.Enabled = True
        End If
        'Till   Here
        If rdbDesignACasting.Checked Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" 'MANJULA ADDED
            ' rdbFabricated.Enabled = False 'MANJULA ADDED
            btnDisplayPortInTube.Visible = False
            plnPortInTube_Casting.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTDesignACasting.TopLevel = False
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmCTDesignACasting.Created Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTDesignACasting.ManualLoad()
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTDesignACasting.Show()
            plnPortInTube_Casting.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmCTDesignACasting)
        Else
            plnPortInTube_Casting.Controls.Clear()
            btnDisplayPortInTube.Visible = True
            btnDisplayPortInTube.BringToFront()
        End If

    End Sub

    Private Sub DefaultSettings()
        '  rdbDesignACasting.Checked = True MANJULA COMMENTED
        btnDisplayPortInTube.Visible = False
    End Sub

#End Region

#Region "Events"

    Private Sub rdbDesignACasting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDesignACasting.CheckedChanged
        '24_02_2010 Aruna Start--
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = False
        If rdbDesignACasting.Checked = True Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = True
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Cast"
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast"       '11_07_2012    RAGAVA
            ObjClsWeldedCylinderFunctionalClass.FacricatedPart = ""      '11_07_2012    RAGAVA
        End If
        '24_02_2010 Aruna End--
        LoadFunctionality()
    End Sub

    Private Sub frmCTCastingNo_PortIntegral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        DefaultSettings()
        '  LoadFunctionality() MANJULA COMMENTED
        SetValuesToPrivateVariables()

        'TODO:SUNNY 04-06-10
        ' rdbDesignACasting.Checked = True MANJULA COMMENTED
    End Sub

    Private Sub rdbPortInTube_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPortInTube.CheckedChanged
        If rdbPortInTube.Checked Then
            'ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
            ObjClsWeldedCylinderFunctionalClass.ShowPortInTube_Thru_PortIntegral = True
            ObjClsWeldedCylinderFunctionalClass.ChangeScreensFlow()
        Else
            ObjClsWeldedCylinderFunctionalClass.ShowPortInTube_Thru_PortIntegral = False
            'ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        End If
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblCastingNotMatched)
    End Sub

    '11_01_2012   RAGAVA
    Private Sub rdbFabricated_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbFabricated.CheckedChanged
        Try
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = False
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated"
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISFabricationChecked = True
            ObjClsWeldedCylinderFunctionalClass.FacricatedPart = "CROSS TUBE"      '11_07_2012    RAGAVA

            If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
                IsPopulated = True
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" 'MANJULA ADDED
            ' rdbDesignACasting.Enabled = False 'MANJULA ADDED
            plnPortInTube_Casting.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTFabrication.TopLevel = False
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmCTFabrication.Created Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTFabrication.ManualLoad()
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTFabrication.Show()
            plnPortInTube_Casting.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmCTFabrication)
            'ElseIf rdbDesignACasting.Checked Then
            '    plnFabrication_Casting.Controls.Clear()
            '    ObjClsWeldedCylinderFunctionalClass.ObjFrmCTDesignACasting.TopLevel = False
            '    If ObjClsWeldedCylinderFunctionalClass.ObjFrmCTDesignACasting.Created Then
            '        ObjClsWeldedCylinderFunctionalClass.ObjFrmCTDesignACasting.ManualLoad()
            '    End If
            '    ObjClsWeldedCylinderFunctionalClass.ObjFrmCTDesignACasting.Show()
            '    plnFabrication_Casting.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmCTDesignACasting)
            'End If
        Catch ex As Exception

        End Try
    End Sub
End Class