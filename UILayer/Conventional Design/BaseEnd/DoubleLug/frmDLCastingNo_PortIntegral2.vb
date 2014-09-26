Public Class frmDLCastingNo_PortIntegral2

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
        'rdbDesignACasting.Checked = True           '23_01_2012   RAGAVA
        btnDisplayPortInTubeScreen.Visible = False
    End Sub

    Public Sub ManualLoad()

        SetValuesToPrivateVariables()

        'TODO:Sunny 04-06-10
        'rdbDesignACasting.Checked = True '27-04-2012 MANJULA COMMENTED
    End Sub

    '30-04-2012 MANJULA ADDED
    Private Sub SetValuesToPrivateVariables()
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral2.rdbDesignACasting.Checked = False AndAlso ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral2.rdbFabricated.Checked = False Then
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then 'AndAlso _
                'ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral2.rdbDesignACasting.Checked = True Then      '30_05_2012   RAGAVA
                rdbDesignACasting.Checked = False
                rdbDesignACasting.Enabled = False
                rdbFabricated.Enabled = True
                rdbFabricated.Checked = False
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then 'AndAlso _
                'ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortIntegral2.rdbFabricated.Checked = True Then     '30_05_2012   RAGAVA
                rdbFabricated.Checked = False
                rdbFabricated.Enabled = False
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
            plnPortInTube_Casting.Controls.Clear()
            LoadFunctionality()
        End If
        ' SearchForExistingDoubleLugCastings()
    End Sub


    Private Sub LoadFunctionality()

        Try

            If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
                IsPopulated = True
            End If
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
                rdbPortInTube.Checked = False
                rdbPortInTube.Enabled = False
            Else
                rdbPortInTube.Enabled = True
            End If
            If rdbDesignACasting.Checked Then
                btnDisplayPortInTubeScreen.Visible = False
                plnPortInTube_Casting.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLDesignACasting2.TopLevel = False
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLDesignACasting2.Created Then
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLDesignACasting2.ManualLoad()
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjFrmDLDesignACasting2.Show()
                plnPortInTube_Casting.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmDLDesignACasting2)
            ElseIf rdbFabricated.Checked Then
                If Me.chkULug.Checked Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BEULDETAILS" '15_05_2012   RAGAVA
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication2.TopLevel = False
                    If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication2.Created Then
                        ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication2.ManualLoad()
                    End If
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication2.Show()
                    plnPortInTube_Casting.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication2)
                    ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
                ElseIf Me.chkDoubleLug.Checked Then
                    plnPortInTube_Casting.Controls.Clear()
                    ObjClsWeldedCylinderFunctionalClass.objfrmFabricatedSingleLug2.TopLevel = False        '30_05_2012   RAGAVA
                    ObjClsWeldedCylinderFunctionalClass.objfrmFabricatedSingleLug2.btnClose.Enabled = False        '30_05_2012   RAGAVA
                    ObjClsWeldedCylinderFunctionalClass.objfrmFabricatedSingleLug2.Show()        '30_05_2012   RAGAVA
                    'plnPortInTube_Casting.Controls.Add(ObjClsWeldedCylinderFunctionalClass.objfrmFabricatedSingleLug)
                    plnPortInTube_Casting.Controls.Add(ObjClsWeldedCylinderFunctionalClass.objfrmFabricatedSingleLug2)         '30_05_2012   RAGAVA
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication2.SearchForExistingPlateClevis()
                    ObjClsWeldedCylinderFunctionalClass.FacricatedPart2 = "SINGLE LUG" '15_05_2012   RAGAVA
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BESingleLugDetails" '15_05_2012   RAGAVA
                    ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
                End If
            ElseIf rdbPortInTube.Checked Then
                plnPortInTube_Casting.Controls.Clear()
                btnDisplayPortInTubeScreen.Visible = True
                btnDisplayPortInTubeScreen.BringToFront()
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Events"

    Private Sub rdbDesignACasting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbDesignACasting.CheckedChanged, rdbFabricated.CheckedChanged
        Try
            '23_01_2012    RAGAVA
            grp2SingleLugs.Visible = False
            If rdbFabricated.Checked = False Then
                grp2SingleLugs.Visible = False
                Me.chkULug.Checked = False
                Me.chkDoubleLug.Checked = False
            End If
            If rdbFabricated.Checked = True Then
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" '30_05_2012  RAGAVA 'MANJULA ADDED
                grp2SingleLugs.Visible = True
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = False
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2 = "Fabricated"      '30_05_2012   RAGAVA
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISFabricationChecked = True
                plnPortInTube_Casting.Controls.Clear() 'MANJULA ADDED
            ElseIf rdbDesignACasting.Checked = True Then
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast"   '30_05_2012  RAGAVA 'MANJULA ADDED
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2 = ""       '15_05_2012   RAGAVA
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2 = ""       '15_05_2012   RAGAVA
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign2 = ""       '15_05_2012   RAGAVA
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2 = "Cast"     '30_05_2012   RAGAVA
                LoadFunctionality()

                If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "BEDLCastWithRaisedPort" '15_05_2012   RAGAVA
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "BEDLCastWithRaisedPort90" '15_05_2012   RAGAVA
                    End If
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BEDLCastWithFlushPort"      '15_05_2012   RAGAVA
                End If

                If rdbDesignACasting.Checked = True Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = True
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = False
                End If
            End If
        Catch ex As Exception

        End Try





    End Sub

    Private Sub frmDLCastingNo_PortIntegral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        DefaultSettings()
        ' LoadFunctionality()
        SetValuesToPrivateVariables()

        ''TODO:Sunny 04-06-10
        'rdbDesignACasting.Checked = True
    End Sub

    Private Sub rdbPortInTube_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPortInTube.CheckedChanged
        If rdbPortInTube.Checked Then
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
            ObjClsWeldedCylinderFunctionalClass.ShowPortInTube_Thru_PortIntegral = True
            ObjClsWeldedCylinderFunctionalClass.ChangeScreensFlow()
        Else
            ObjClsWeldedCylinderFunctionalClass.ShowPortInTube_Thru_PortIntegral = False
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        End If
    End Sub

#End Region

    ''COMMENTED BY ANUP-------   This SubProcedure is used for all configurations so I copied it to clsWeldedCylinderFunctionalClass and used it from there.
    ''ONSITE: DL - Changing the screens flow when if u select the port in tube option
    'Private Sub ChangeScreensFlow()
    '    ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
    '    ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbBaseEndPort.Text = "Port In Tube"
    '    Dim oForm As Form = ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails
    '    ObjClsWeldedCylinderFunctionalClass.ObjPnlChildFormArea.Controls.Clear()
    '    ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm = oForm
    '    oForm.TopLevel = False
    '    oForm.Dock = DockStyle.Fill
    '    If oForm.Created Then
    '        ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.ManualLoad()
    '    End If
    '    oForm.Show()
    '    ObjClsWeldedCylinderFunctionalClass.ObjPnlChildFormArea.Controls.Add(oForm)
    'End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblCastingNotMatched)
    End Sub

    'Private Sub rdbFabricated_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbFabricated.CheckedChanged
    '    Try
    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = False
    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True
    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated"
    '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISFabricationChecked = True


    '        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
    '            IsPopulated = True
    '        End If

    '        plnPortInTube_Casting.Controls.Clear()
    '        ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication.TopLevel = False
    '        If ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication.Created Then
    '            ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication.ManualLoad()
    '        End If
    '        ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication.Show()
    '        plnPortInTube_Casting.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmDLFabrication)
    '    Catch ex As Exception

    '    End Try
    'End Sub

    '23_01_2012    RAGAVA
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
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkDoubleLug_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDoubleLug.CheckedChanged
        Try
            If chkDoubleLug.Checked = True Then
                chkULug.Checked = False
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBendradius_error = False
                LoadFunctionality()
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBendradius_error = True
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected = True
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ISFabricationChecked = True
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class