Public Class frmCTCastingNo_PortInTube

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

#Region "SubProcedures"

    Private Sub DefaultSettings()
        'rdbFabrication.Checked = True
    End Sub

    Public Sub ManualLoad()
        ' LoadFunctionality()  MANJULA COMMENTED
        SetValuesToPrivateVariables()
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
                       OrElse Not strTempPortType = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd _
                       OrElse Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TempWorkingPressure _
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
            rdbFabrication.Checked = False
            rdbDesignACasting.Checked = False
            rdbDesignACasting.Enabled = True
            rdbFabrication.Enabled = True
            plnFabrication_Casting.Controls.Clear()
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
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OffSet > 0 Then
            rdbFabrication.Enabled = False
        Else
            rdbFabrication.Enabled = True
        End If
        If rdbFabrication.Checked Then
            plnFabrication_Casting.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTFabrication.TopLevel = False
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmCTFabrication.Created Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTFabrication.ManualLoad()
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTFabrication.Show()
            plnFabrication_Casting.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmCTFabrication)
        ElseIf rdbDesignACasting.Checked Then
            plnFabrication_Casting.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTDesignACasting.TopLevel = False
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmCTDesignACasting.Created Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmCTDesignACasting.ManualLoad()
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjFrmCTDesignACasting.Show()
            plnFabrication_Casting.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmCTDesignACasting)
        End If
    End Sub

#End Region

#Region "Events"

    Private Sub rdbFabrication_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    rdbFabrication.CheckedChanged, rdbDesignACasting.CheckedChanged
        '24_02_2010 Aruna Start --
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = False
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = False
        If rdbFabrication.Checked = True Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" '14-05-2012 MANJULA ADDED
            rdbDesignACasting.Enabled = False '14-05-2012 MANJULA ADDED

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated"

            'TODO: ANUP 06-04-2010 02.16
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISFabricationChecked = True
            '***********
            plnFabrication_Casting.Controls.Clear() '14-05-2012 MANJULA ADDED
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" '14-05-2012 MANJULA ADDED
            rdbFabrication.Enabled = False '14-05-2012 MANJULA ADDED
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = True
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Cast"

            'TODO: ANUP 06-04-2010 02.16
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISFabricationChecked = False
            '***********

        End If
        '24_02_2010 Aruna End --
        LoadFunctionality()
    End Sub

    Private Sub frmCTCastingNo_PortInTube_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        DefaultSettings()
        'LoadFunctionality() MANJULA COMMENTED
        SetValuesToPrivateVariables()
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblCastingNotMatched)
    End Sub

End Class