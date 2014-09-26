Public Class frmDLCastingNo_PortInTube2

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

#Region "SubProcedures"

    Private Sub DefaultSettings()
        'rdbFabrication.Checked = True
    End Sub

    Public Sub ManualLoad()
        SetValuesToPrivateVariables()
    End Sub

    '30-04-2012 MANJULA ADDED
    Private Sub SetValuesToPrivateVariables()
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.rdbFabrication.Checked = False AndAlso ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube2.rdbDesignACasting.Checked = False Then        '30_05_2012   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then ' AndAlso _
                'ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.rdbDesignACasting.Checked = True Then
                rdbDesignACasting.Checked = False
                rdbDesignACasting.Enabled = False
                rdbFabrication.Enabled = True
                rdbFabrication.Checked = False
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then 'AndAlso _
                'ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.rdbFabrication.Checked = True Then
                rdbFabrication.Checked = False
                rdbFabrication.Enabled = False
                rdbDesignACasting.Enabled = True
                rdbDesignACasting.Checked = False
            End If
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
        If rdbFabrication.Checked Then
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated"     '14_03_2012  RAGAVA
            If Me.chkULug.Checked = True Then
                plnFabrication_Casting.Controls.Clear() 'MANJULA ADDED
                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication2.TopLevel = False
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication2.Created Then
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication2.ManualLoad()
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication2.Show()
                plnFabrication_Casting.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication2)
            End If
        ElseIf rdbDesignACasting.Checked Then
            'TODO:Sunny 26-02-10
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Cast"     '14_03_2012  RAGAVA
            plnFabrication_Casting.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLDesignACasting2.TopLevel = False
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLDesignACasting2.Created Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLDesignACasting2.ManualLoad()
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLDesignACasting2.Show()
            plnFabrication_Casting.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmDLDesignACasting2)
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("ClevisPlate Code", "N/A")
        End If
    End Sub

#End Region

#Region "Events"

    Private Sub rdbFabrication_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
    rdbFabrication.CheckedChanged, rdbDesignACasting.CheckedChanged
        Try
            '06_01_2012   RAGAVA
            If sender.Name = "rdbFabrication" AndAlso sender.Checked = True Then
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication"
                grp2SingleLugs.Visible = True
                plnFabrication_Casting.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2 = "Fabricated"      '30_05_2012   RAGAVA
            ElseIf rdbFabrication.Checked = False Then
                grp2SingleLugs.Visible = False
                Me.chkULug.Checked = False
                Me.chkDoubleLug.Checked = False
            Else
                grp2SingleLugs.Visible = False
            End If
            'Till  Here
        Catch ex As Exception
        End Try
        If sender.Name = "rdbDesignACasting" AndAlso sender.Checked = True Then
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast"
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2 = "Cast"      '30_05_2012   RAGAVA
            LoadFunctionality()
        End If
        ''02_03_2010   RAGAVA
        'If sender.Name = "rdbFabrication" Then
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEULDETAILS"
        'ElseIf sender.Name = "rdbDesignACasting" Then
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEDLCastWithOutPort"
        'End If
        ''Till   Here
        btnRadioButtonsSelectionMessage.Enabled = False
        '01_03_2010    RAGAVA
        'If sender.Name = "rdbFabrication" Then
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True
        '    TODO: ANUP 06-04-2010 02.16
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISFabricationChecked = True
        '    ***********
        'ElseIf sender.Name = "rdbDesignACasting" Then
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = True
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = False
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISFabricationChecked = False
        '    ***********
        'End If
        'Till    Here
    End Sub

    Private Sub frmCastingNo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.RdbDesignANewCasting = Me.rdbDesignACasting
        ObjClsWeldedCylinderFunctionalClass.RdbFabrication = Me.rdbFabrication
        DefaultSettings()
        ' LoadFunctionality()
        SetValuesToPrivateVariables()
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblCastingNotMatched)
    End Sub


    '06_01_2012    RAGAVA
    Private Sub chkULug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkULug.CheckedChanged
        Try
            If chkULug.Checked = True Then
                ObjClsWeldedCylinderFunctionalClass.FacricatedPart2 = "U LUG" '15_05_2012   RAGAVA
                chkDoubleLug.Checked = False
                Dim dblBendRadius As Double
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness < 0.625 Then
                    dblBendRadius = 0.25
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness = 0.625 Then
                    dblBendRadius = 0.5
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness > 0.625 Then
                    dblBendRadius = 0.75
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBendradius_error = False
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap < 2 * dblBendRadius Then
                    Dim strMessage As String = "LugGap is not sufficient for the selected LugThickness kindly go BACK to change, the lugthickness OR " + vbNewLine
                    strMessage += "Increase LugGap (LugGap should be greater than " + (2 * dblBendRadius).ToString + ") OR Choose Double Lug" + vbNewLine
                    MessageBox.Show(strMessage, "Bend radius error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBendradius_error = True
                    Me.chkULug.Checked = False
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BEULDETAILS" '15_05_2012   RAGAVA
                    'ObjClsWeldedCylinderFunctionalClass.FacricatedPart = ""
                    LoadFunctionality()
                    'Me.Visible = False
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated"
                    'ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.plnFabrication_Casting.Controls.Clear()
                    'ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication.TopLevel = False
                    'If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication.Created Then
                    '    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication.ManualLoad()
                    'End If
                    'ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication.Show()
                    'ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.plnFabrication_Casting.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication)
                    ''ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.bln2SingleLugSelected = True            '05_01_2012   RAGAVA
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    '06_01_2012    RAGAVA
    Private Sub chkDoubleLug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDoubleLug.CheckedChanged
        Try
            If chkDoubleLug.Checked = True Then
                chkULug.Checked = False
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBendradius_error = False
                'Dim oFrmFabricatedSingleLug_RetractedLength As New frmFabricatedSingleLug_RetractedLength
                'oFrmFabricatedSingleLug_RetractedLength.ShowDialog()


                plnFabrication_Casting.Controls.Clear()
                '30_05_2012   RAGAVA
                'ObjClsWeldedCylinderFunctionalClass.objfrmFabricatedSingleLug.TopLevel = False
                'ObjClsWeldedCylinderFunctionalClass.objfrmFabricatedSingleLug.btnClose.Enabled = False
                'ObjClsWeldedCylinderFunctionalClass.objfrmFabricatedSingleLug.Show()
                'ObjClsWeldedCylinderFunctionalClass.objfrmFabricatedSingleLug.lvwSafetyFactor_Weight.Items.Clear() 'MANJULA ADDED
                'ObjClsWeldedCylinderFunctionalClass.objfrmFabricatedSingleLug._intSafetyFactorCount = 0
                'plnFabrication_Casting.Controls.Add(ObjClsWeldedCylinderFunctionalClass.objfrmFabricatedSingleLug)
                ObjClsWeldedCylinderFunctionalClass.objfrmFabricatedSingleLug2.TopLevel = False
                ObjClsWeldedCylinderFunctionalClass.objfrmFabricatedSingleLug2.btnClose.Enabled = False
                ObjClsWeldedCylinderFunctionalClass.objfrmFabricatedSingleLug2.Show()
                ObjClsWeldedCylinderFunctionalClass.objfrmFabricatedSingleLug2.lvwSafetyFactor_Weight.Items.Clear() 'MANJULA ADDED
                ObjClsWeldedCylinderFunctionalClass.objfrmFabricatedSingleLug2._intSafetyFactorCount = 0
                plnFabrication_Casting.Controls.Add(ObjClsWeldedCylinderFunctionalClass.objfrmFabricatedSingleLug2)


                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication2.SearchForExistingPlateClevis()       '10_01_2012   RAGAVA

                ObjClsWeldedCylinderFunctionalClass.FacricatedPart2 = "SINGLE LUG" '15_05_2012   RAGAVA
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BESingleLugDetails" '15_05_2012   RAGAVA
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.bln2SingleLugSelected = True
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBendradius_error = True
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISFabricationChecked = True



                ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True           '10_01_2012   RAGAVA


            End If
        Catch ex As Exception

        End Try
    End Sub
End Class