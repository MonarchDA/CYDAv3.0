Imports System.IO
Public Class frmGenerate

    Private Sub btnBackPage3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        getBackFunctionality()
    End Sub
    '19_03_2010   RAGAVA
    Public Sub ManualLoad()
        Try

            Try
                '29_12_2011   RAGAVA  If condition added
                'ChkMaskBushings.Enabled = False '24TH MAY 2013  12th August 2013
                'chkInstallPinAndClips.Enabled = False '24TH MAY 2013
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbPins_BaseEnd.Text = "Yes" OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbPins_RodEnd.Text = "Yes" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.Validate_PinandClipsNotes()    '06_06_2011  RAGAVA
                End If
                chkMaskPerBOM.Checked = False
                'txtMaskBushings.Clear()  12th August 2013
                txtMaskPerBOM.Enabled = False
                chkMaskPerBOM.Enabled = False

                'THREADED ROD
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Threaded Rod" Then
                    chkMaskPerBOM.Checked = True
                    chkMaskPerBOM.Enabled = False
                End If
                'BUSHINGS
                If Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbBushingQuantity_RodEnd.Text) > 0 Then
                    chkMaskPerBOM.Checked = True
                    chkMaskPerBOM.Enabled = False
                End If
                'STICKOUT LENGTH
                If Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmRetractedLengthValidation.txtStickOutDistance.Text) > 4 Then
                    chkMaskPerBOM.Checked = True
                    chkMaskPerBOM.Enabled = False
                End If
                'chkMaskPerBOM
            Catch ex As Exception

            End Try
            chkByPass.Enabled = False
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType.IndexOf("Rephasing") <> -1 Then
                chkByPass.Checked = True
                chkByPass.Enabled = False
            Else
                chkByPass.Checked = False
            End If
            ChkRephaseExtension.Enabled = False
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType.Equals("Rephasing at Extension") OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType.IndexOf("Bothends") <> -1 Then
                ChkRephaseExtension.Checked = True
                ChkRephaseExtension.Enabled = False
            Else
                ChkRephaseExtension.Checked = False
            End If
            ChkRephaseRetraction.Enabled = False
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType.Equals("Rephasing at Retraction") OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType.IndexOf("Bothends") <> -1 Then
                ChkRephaseRetraction.Checked = True
                ChkRephaseRetraction.Enabled = False
            Else
                ChkRephaseRetraction.Checked = False
            End If
            chkOrifice.Enabled = False
            'If Not (Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbOrificeSizeBaseEnd.Text) = "" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbOrificeSizeRodEnd.Text) = "") Then
            '    chkOrifice.Checked = True
            'Else
            '    chkOrifice.Checked = False   //commented by vamsi 09/05/13
            'End If
            chkPlugBreatherForPainting.Enabled = False
            chkREMOVEPLUGANDINSTALLBREATHERPLUG.Enabled = False 'vamsi 05-02-2014

            If ((Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbAccessoryType_BaseEnd.SelectedItem).ToString.IndexOf("Breather") <> -1 OrElse Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbAccessoryType_RodEnd.SelectedItem).ToString.IndexOf("Breather") <> -1) And ((UCase(ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbPaint.Text).ToString.IndexOf("PRIME") <> -1) Or ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbPaint.Enabled = True)) Then
                chkPlugBreatherForPainting.Checked = True
                chkPlugBreatherForPainting.Enabled = False
                chkREMOVEPLUGANDINSTALLBREATHERPLUG.Checked = True 'vamsi 05-02-2014
                chkREMOVEPLUGANDINSTALLBREATHERPLUG.Enabled = False
            Else
                chkPlugBreatherForPainting.Checked = False
                chkREMOVEPLUGANDINSTALLBREATHERPLUG.Checked = False 'vamsi 05-02-2014
            End If
            chkInstallBreather.Enabled = False
            If ((Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbAccessoryType_BaseEnd.SelectedItem).ToString.IndexOf("Breather") <> -1 OrElse Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbAccessoryType_RodEnd.SelectedItem).ToString.IndexOf("Breather") <> -1) And ((Not (UCase(ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbPaint.Text).ToString.IndexOf("PRIME") <> -1)) Or ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbPaint.Enabled = True)) Then
                chkInstallBreather.Checked = True
                chkInstallBreather.Enabled = False
            Else
                chkInstallBreather.Checked = False
            End If
        Catch ex As Exception
        End Try
        If chkAssemblyNotes.Checked = True Then
            RichTextBox1.Enabled = False

        Else
            RichTextBox1.Enabled = False
        End If
        If chkPaintingNote.Checked = True Then
            RichTextBox2.Enabled = False

        Else
            RichTextBox2.Enabled = False
        End If
        ChkPins.Checked = True
        ChkPins.Enabled = False
        chkSetScrew.Checked = True
        chkSetScrew.Enabled = False

        ChkRetractedLength.Checked = True
        ChkRetractedLength.Enabled = False
        ChkExtendedLength.Checked = True
        ChkExtendedLength.Enabled = False
        ChkRodDiameter.Checked = True
        ChkRodDiameter.Enabled = False
        chk100AirTest.Checked = True
        chk100AirTest.Enabled = False
        chk100OilTest.Checked = True
        chk100OilTest.Enabled = False

        'vamsi start 27-11-13
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbBaseGreaseZercType1.Text.ToString.IndexOf("Set Screw") <> -1 OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbBaseGreaseZercType2.Text.ToString.IndexOf("Set Screw") <> -1 OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbRodGreaseZercType1.Text.ToString.IndexOf("Set Screw") <> -1 OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbRodGreaseZercType2.Text.ToString.IndexOf("Set Screw") <> -1 Then
            chkSetScrew.Checked = True
            chkSetScrew.Enabled = False
        Else
            chkSetScrew.Checked = False
            chkSetScrew.Enabled = False
        End If '  end  vamsi added 27-11-2013 

        'chkSetScrew.Checked = True
        'chkSetScrew.Enabled = False

        ChkRetractedLength.Checked = True
        ChkRetractedLength.Enabled = False
        ChkExtendedLength.Checked = True
        ChkExtendedLength.Enabled = False
        ChkRodDiameter.Checked = True
        ChkRodDiameter.Enabled = False
        chk100AirTest.Checked = True
        chk100AirTest.Enabled = False
        chk100OilTest.Checked = True
        chk100OilTest.Enabled = False
        If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text) = Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationBaseEnd.Text) Then
            If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationBaseEnd.Text).IndexOf("90") <> -1 Then       '07_03_2011   RAGAVA
                ChkPins.Text = "PINS ARE 90° TO PORTS"
            ElseIf Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationBaseEnd.Text).IndexOf("0") <> -1 Then
                ChkPins.Text = "PINS ARE IN LINE WITH PORTS"
                ' else
                'ChkPins.Text = "PINS ARE AS SHOWN"  'vamsi 08thAugust2013 'commented by Neeraja
            End If
        Else
            ' ChkPins.Text = "Rod End Port " & Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationRodEnd.Text) & ", Base End Port " & Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.txtFirstPortOrientationBaseEnd.Text) 'commented by Neeraja
            ChkPins.Text = "PINS ARE AS SHOWN"                          'Neeraja 13-10-2014
        End If

        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSetScrew <> "" Then  vamsi 12 august 2013
        '    chkSetScrew.Checked = True
        '    chkSetScrew.Enabled = False
        '    chkInstallSetScrewAfterOilTest.Checked = True
        '    chkInstallSetScrewAfterOilTest.Enabled = False
        'Else
        '    chkSetScrew.Checked = False
        '    chkSetScrew.Enabled = False
        '    chkInstallSetScrewAfterOilTest.Checked = False
        '    chkInstallSetScrewAfterOilTest.Enabled = False
        'End If
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs > 0 OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs_RodEnd > 0 Then
            chkGreaseZerc.Checked = True
            chkGreaseZerc.Enabled = False
            txtGreaseZerc.Enabled = True ''VAMSI 06-03-14
        Else
            chkGreaseZerc.Checked = False
            chkGreaseZerc.Enabled = False
        End If
        ChkRodMaterial.Enabled = False
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbRodMaterial.SelectedItem.ToString.IndexOf("Nitro") <> -1 Then
            ChkRodMaterial.Checked = True
            ChkRodMaterial.Enabled = False
        Else
            ChkRodMaterial.Checked = False
        End If
        chkInstallAdaptorFitting.Enabled = False
        If (Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbAccessoryType_BaseEnd.SelectedItem).ToString.IndexOf("Adaptor") <> -1 OrElse Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbAccessoryType_RodEnd.SelectedItem).ToString.IndexOf("Adaptor") <> -1) Then
            chkInstallAdaptorFitting.Checked = True
            chkInstallAdaptorFitting.Enabled = False
        Else
            chkInstallAdaptorFitting.Checked = False
        End If
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkStopTube.Checked = True Then
            ChkAssemblyStopTube.Checked = True
            ChkAssemblyStopTube.Enabled = False
        Else
            ChkAssemblyStopTube.Checked = False
            ChkAssemblyStopTube.Enabled = False
        End If
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity > 0 Then
            ChkHardenedBushingsBaseEnd.Checked = True
            ChkHardenedBushingsBaseEnd.Enabled = False
        Else
            ChkHardenedBushingsBaseEnd.Checked = False
            ChkHardenedBushingsBaseEnd.Enabled = False
        End If
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity_RodEnd > 0 Then
            ChkHardenedBushingsRodEnd.Checked = True
            ChkHardenedBushingsRodEnd.Enabled = False
        Else
            ChkHardenedBushingsRodEnd.Checked = False
            ChkHardenedBushingsRodEnd.Enabled = False
        End If
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity > 0 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity_RodEnd > 0 Then
            ChkInstallHardenedBushings.Checked = True
            ChkInstallHardenedBushings.Enabled = False
        Else
            ChkInstallHardenedBushings.Checked = False
            ChkInstallHardenedBushings.Enabled = False
        End If
        ChkRephaseExtension.Enabled = False
        ChkRephaseRetraction.Enabled = False
        ChkPaint.Enabled = False
        ChkPrime.Enabled = False
        chkNoPaintOrPrimer.Enabled = False
        chkCleanCylinder.Enabled = False
        chkBoxMustBeLined.Enabled = False
        chkBagMustBeTightlySealed.Enabled = False


        '06_06_2011   RAGAVA
        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnInstallPinsandClips = False Then
        '    chkInstallPinAndClips.Checked = False
        '    chkInstallPinAndClips.Enabled = False
        '    'Else
        '    '    chkInstallPinAndClips.Enabled = False '28-01-14 vamsi 
        '    '    chkInstallPinAndClips.Checked = True '28-01-14 vamsi
        '    '    txtInstallPinandClips.Enabled = True '28-01-14 vamsi
        'End If

        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinsYesOrNo = "Yes" Then   'priyanka coment it 
        '    ' chkInstallPinAndClips.Enabled = False '28-01-14 vamsi VAMSI 06-03-14
        '    chkInstallPinAndClips.Checked = True '28-01-14 vamsi
        '    txtInstallPinandClips.Enabled = True '28-01-14 vamsi
        '    chkInstallPinAndClips.Enabled = False '28-01-14 vamsi

        'Else
        '    chkInstallPinAndClips.Checked = False
        '    chkInstallPinAndClips.Enabled = False
        'End If

        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinsYesOrNo = "Yes" Then  'priyanka 


            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbPinClips_BaseEnd.Text <> "" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbPinClips_BaseEnd.Text <> "" Then
                ChkIncludePinkitPerBom.Checked = True
                txtIncludePinkitPerBom.Enabled = True
                ' ChkIncludePinkitPerBom.Enabled = False
                chkInstallPinAndClips.Enabled = True
                txtInstallPinandClips.Enabled = False
            Else
                chkInstallPinAndClips.Checked = True
                txtInstallPinandClips.Enabled = True
                chkInstallPinAndClips.Enabled = False

            End If
        Else
            ChkIncludePinkitPerBom.Checked = False
            ChkIncludePinkitPerBom.Enabled = False
            txtIncludePinkitPerBom.Enabled = False
            chkInstallPinAndClips.Enabled = False
            chkInstallPinAndClips.Checked = False
        End If


        'TILL   HERE
        '12th August 2013 start
        'If ChkMaskBushings.Checked = False Then
        '    txtMaskBushings.Enabled = False

        'End If
        'End vamsi


        If ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.chkPaint.Checked = True Then
            chkAffixLabel.Checked = True
            chkAffixLabel.Enabled = False
            ChkPaint.Checked = True
            ChkPaint.Enabled = False
            chkNoPaintOrPrimer.Checked = False
            chkCleanCylinder.Checked = False
            chkBoxMustBeLined.Checked = False
            chkBagMustBeTightlySealed.Checked = False
            If Not (UCase(ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbPaint.Text).ToString.IndexOf("PRIME") <> -1 OrElse UCase(ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbPaint.Text).ToString.IndexOf("TOPCOAT") = -1) Then       '30_09_2010  RAGAVA  TOPCOAT added
                ChkPrime.Checked = False
            Else
                ChkPrime.Checked = True
                ChkPrime.Enabled = False
            End If
        Else
            chkAffixLabel.Checked = False
            ChkPaint.Checked = False
            ChkPrime.Checked = False
            chkNoPaintOrPrimer.Checked = True
            chkNoPaintOrPrimer.Enabled = False
            chkCleanCylinder.Checked = True
            chkCleanCylinder.Enabled = False
            chkBoxMustBeLined.Checked = True
            chkBoxMustBeLined.Enabled = False
            chkBagMustBeTightlySealed.Checked = True
            chkBagMustBeTightlySealed.Enabled = False
        End If

    End Sub

    Private Sub btnGenerateModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateModel.Click
        'Sunny 05-08-10
        GenerateModel()
        create_sf_sheet()
        '' GenerateCostingSheet()

    End Sub

    Private Sub GenerateCostingSheet()
        'Costing30_07:Sunny 30-07-10
        ''ObjClsWeldedCylinderFunctionalClass.UpdateNewDesignPartParams("")
        Dim oCosting As New clsCostingExcelFunctionality
        oCosting.Costingfunctionality()
        'Application.Exit()
        '**************************
    End Sub

    Private Sub GenerateModel()
        '                Commented by sandeep for costing testing
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked = True Then
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbRephasing.Text.IndexOf("Bothends") <> -1 Then
                    clsAddExistingCodes.AddCheckBallCode("110499", 2, "EA")
                Else
                    clsAddExistingCodes.AddCheckBallCode("110499", 1, "EA")
                End If
            End If
        Catch ex As Exception

        End Try
        '19_03_2010   RAGAVA
        Try
            Dim ErrorMessage As String = String.Empty
            If Not validateForm(Me, ErrorMessage) Is Nothing Then
                MessageBox.Show(ErrorMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Focus()
                If SaveDetails = True Then               'added if condition to facilitate batchrun----------------------------------------009
                    ValidationFailedNotification = True
                End If                                   '---------------------------------------------------------------------------------009
                Exit Sub
            End If
        Catch ex As Exception
        End Try


        ObjClsWeldedCylinderFunctionalClass.StopWatchAndProgressBar = "Start" 'vamsi 11-06-14
        'Start---009      10-12-2013
        'toplevel If Loop is added to facilitate Batchrun
        '----------------------------------------------------------------------------------------------------------------------------------009
        If ObjClsWeldedCylinderFunctionalClass.MultiGenerate <> True Then

            Dim oPopulatin As PopulatingBackClass = PopulatingBackClass.GetPopulatingObject()
            oPopulatin.RevisionContractNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RevisionContractNo
            oPopulatin.StoreFormDataIntoDB()

        End If

        '----------------------------------------------------------------------------------------------------------------------------------009
        'end---009

        'anup 23-12-2010 start
        Dim oClsReleaseCylinderFunctionality As New clsReleaseCylinderFunctionality
        If ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Released" Then
            oClsReleaseCylinderFunctionality.RevisionCounterValidation()
        End If
        'anup 23-12-2010 till here

        '29_06_2010  RAGAVA


        'Start---009      3-12-2013
        'toplevel If Loop is added to facilitate Batchrun
        '----------------------------------------------------------------------------------------------------------------------------------009
        If ObjClsWeldedCylinderFunctionalClass.MultiGenerate <> True Then

            Dim ofrmRevision As New frmRevisionTable
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.New_Revision = "Revision'" Then
                Try
                    ofrmRevision.UpdateRevision_Details(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables._intContractRevisionNumber + 1)
                Catch ex As Exception
                End Try
                ofrmRevision.ShowDialog()
            End If

        End If
        '----------------------------------------------------------------------------------------------------------------------------------009
        'end---009

        'Till   Here
        getNextFunctionality()
        '                Commented by Sandeep for Costing purpose
    End Sub

    Public Sub getNextFunctionality()

        '04_01_2011   RAGAVA
        'clsAddExistingCodes.AddExistingCodeToHashTable("PLASTIC BAG", dr("BagPartNumber"), 1, "EA")
        Try
            Dim dblThreadSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadSize_RodEnd

            'THREADED ROD
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Threaded Rod" Then
                If dblThreadSize = 0.5 Then
                    clsAddExistingCodes.AddExistingCodeToHashTable("MASKING TUBE", "174005", 1, "EA")
                ElseIf dblThreadSize = 0.75 Then
                    clsAddExistingCodes.AddExistingCodeToHashTable("MASKING TUBE", "174004", 1, "EA")
                ElseIf dblThreadSize = 1 Then
                    If Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmREThreadedRod.txtThreadLength_RodEnd.Text) <= 2 Then
                        clsAddExistingCodes.AddExistingCodeToHashTable("MASKING TUBE", "174013", 1, "EA")
                    ElseIf Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmREThreadedRod.txtThreadLength_RodEnd.Text) > 2 AndAlso Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmREThreadedRod.txtThreadLength_RodEnd.Text) <= 2.5 Then
                        clsAddExistingCodes.AddExistingCodeToHashTable("MASKING TUBE", "174001", 1, "EA")
                    ElseIf Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmREThreadedRod.txtThreadLength_RodEnd.Text) > 2.5 Then
                        clsAddExistingCodes.AddExistingCodeToHashTable("MASKING TUBE", "174015", 1, "EA")
                    End If
                ElseIf dblThreadSize = 1.125 Then
                    If Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmREThreadedRod.txtThreadLength_RodEnd.Text) <= 1.2 Then
                        clsAddExistingCodes.AddExistingCodeToHashTable("MASKING TUBE", "174007", 1, "EA")
                    ElseIf Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmREThreadedRod.txtThreadLength_RodEnd.Text) > 1.2 Then
                        clsAddExistingCodes.AddExistingCodeToHashTable("MASKING TUBE", "174017", 1, "EA")
                    End If
                ElseIf dblThreadSize = 1.25 Then
                    clsAddExistingCodes.AddExistingCodeToHashTable("MASKING TUBE", "174002", 1, "EA")
                ElseIf dblThreadSize = 1.5 Then
                    If Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmREThreadedRod.txtThreadLength_RodEnd.Text) <= 1.5 Then
                        clsAddExistingCodes.AddExistingCodeToHashTable("MASKING TUBE", "174016", 1, "EA")
                    ElseIf Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmREThreadedRod.txtThreadLength_RodEnd.Text) > 1.5 Then
                        clsAddExistingCodes.AddExistingCodeToHashTable("MASKING TUBE", "174003", 1, "EA")
                    End If
                End If
            End If



            'BUSHINGS
            If Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbBushingQuantity_RodEnd.Text) > 0 Then
                Dim dblwidth As Double = 0.0
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
                    dblwidth = Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.txtCrossTubeWidth_RodEnd.Text)
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Single Lug" _
                OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "BH" Then
                    dblwidth = Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.txtLugThickness_RodEnd.Text)
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" Then
                    dblwidth = Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.txtLugGap_RodEnd.Text) + (2 * Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.txtLugThickness_RodEnd.Text))
                End If
                If dblwidth > 3 Then
                    clsAddExistingCodes.AddExistingCodeToHashTable("MASKING PAPER", "174022", 1, "EA")
                ElseIf dblwidth <= 3 Then
                    clsAddExistingCodes.AddExistingCodeToHashTable("MASKING PAPER", "174023", 1, "EA")
                End If
            End If
            '29_12_2011   RAGAVA
            If Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbBushingQuantity.Text) > 0 Then
                Dim dblwidth As Double = 0.0
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" Then
                    dblwidth = Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.txtCrossTubeWidth.Text)
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" _
               OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "BH" Then 'MANJULA ADDED
                    dblwidth = Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.txtLugThickness.Text)
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" Then
                    dblwidth = Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.txtLugGap.Text) + (2 * Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.txtLugThickness.Text))
                End If
                If dblwidth > 3 Then
                    clsAddExistingCodes.AddExistingCodeToHashTable("MASKING PAPER", "174022", 1, "EA")
                ElseIf dblwidth <= 3 Then
                    clsAddExistingCodes.AddExistingCodeToHashTable("MASKING PAPER", "174023", 1, "EA")
                End If
            End If
            'Till  Here
            'STICKOUT LENGTH
            If Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmRetractedLengthValidation.txtStickOutDistance.Text) > 4 AndAlso Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmRetractedLengthValidation.txtStickOutDistance.Text) <= 5.5 Then
                clsAddExistingCodes.AddExistingCodeToHashTable("MASKING PAPER", "174025", 1, "EA")
            ElseIf Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmRetractedLengthValidation.txtStickOutDistance.Text) > 5.5 Then
                clsAddExistingCodes.AddExistingCodeToHashTable("MASKING PAPER", "174024", 1, "EA")
            End If

            '29_12_2011   RAGAVA
            If Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbGreaseZercs_RodEnd.Text) > 0 OrElse Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbGreaseZercs.Text) > 0 Then
                clsAddExistingCodes.AddExistingCodeToHashTable("MASKING", "174035", 1, "EA")
            End If


            'BALL PIN HOLE is In FUTURE
            '174028 if pin Type = "Ball Pin Hole"
            '174018 if pin size = 1.75
            '174026 if pin Type = "Hose"
        Catch ex As Exception

        End Try
        'Till   Here


        'ANUP 27-10-2010
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text = "New Design" Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.ExecuteQuery_HeadDesign()
            End If
        Catch ex As Exception

        End Try

        '16_10_2012   RAGAVA
        ''20_10_2010    RAGAVA
        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = False Then
        '    ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode = ""
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd = ""
        'End If
        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False Then
        '    ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode = ""
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd = ""
        'End If
        'Till   Here


        'GetBaseEndCodeNumber()          '25_05_2010   RAGAVA
        '**************************************SINGLE LUG DESIGN************************************************
        'Base End configuration Single Lug Design a casting
        Try
            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False Then       '27_03_2012  RAGAVA  commented
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
                    'If (ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize <> "Exact" AndAlso ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize <> "Resize") OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False Then         '20_10_2010    RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndFabrication_New Then 'orelse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                        'ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.besinglelugdetails", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName, "Base End")
                        ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart, "Base End", False)
                    End If
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndCasting_New Then ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected Then
                        ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart, "Base End", True)
                        'ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.BESLCASTINGNOPORT", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                    End If
                    If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "NewDesign" Then
                        ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                    End If
                    If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize2 = "NewDesign" Then
                        ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2)
                    End If
                Else
                    'If (ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize <> "Exact" AndAlso ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize <> "Resize") OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False Then         '20_10_2010    RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndFabrication_New Then ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                        'ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.besinglelugdetails", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName, "Base End")
                        ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart, "Base End", False)
                    End If
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndCasting_New Then ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected Then
                        ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart, "Base End", True)
                        'If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                        '    '19_05_2010   RAGAVA     NEW DESIGN
                        '    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                        '        ObjClsWeldedCylinderFunctionalClass.storeData("BESLCASTINGRAISEDPORT", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                        '    Else
                        '        ObjClsWeldedCylinderFunctionalClass.storeData("BESLCASTINGRAISEDPORT90", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                        '    End If
                        '    'Till  Here
                        'Else
                        '    ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.BESLCASTINGFLUSHPORT", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                        'End If
                    End If
                    If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "NewDesign" Then
                        ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                    End If
                    If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize2 = "NewDesign" Then
                        ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2)
                    End If
                End If
                    'Manjula Added
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "BH" Then

                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
                    'If (ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize <> "Exact" AndAlso ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize <> "Resize") OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False Then         '20_10_2010    RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndFabrication_New Then 'OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected2) Then
                        ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart, "Base End", False)
                        'ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.BEBHDetails", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName, "Base End")
                    End If
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndCasting_New Then 'OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected2) Then
                        ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart, "Base End", True)
                        'ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.Base_End_BH_No_Port", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                    End If
                    If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "NewDesign" Then
                        ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                    End If
                    If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize2 = "NewDesign" Then
                        ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2)
                    End If
                Else
                    'If (ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize <> "Exact" AndAlso ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize <> "Resize") OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False Then         '20_10_2010    RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndFabrication_New Then 'OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected2) Then
                        ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart, "Base End", False)
                        'ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.BEBHDetails", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName, "Base End")
                    End If
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndCasting_New Then 'OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected2) Then
                        ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart, "Base End", True)
                        'If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                        '    '19_05_2010   RAGAVA     NEW DESIGN
                        '    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                        '        ObjClsWeldedCylinderFunctionalClass.storeData("BEBHCastingRaisedPort", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                        '    Else
                        '        ObjClsWeldedCylinderFunctionalClass.storeData("BEBHCastingRaisedPort90", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                        '    End If
                        '    'Till  Here
                        'Else
                        '    ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.BEBHCASTINGFLUSHPORT", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                        'End If
                    End If
                    If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "NewDesign" Then
                        ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                    End If
                    If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize2 = "NewDesign" Then
                        ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2)
                    End If
                End If
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" Then
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndFabrication_New = True Then
                            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                            '    ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName, "BASE END")
                            '    'ObjClsWeldedCylinderFunctionalClass.storeData("Welded.becrossTubeDetails", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName, "BASE END")
                            'Else
                            '    ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2, "BASE END")
                            'End If
                            ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart, "Base End", False)
                        End If
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndCasting_New = True Then       '11_04_2012   RAGAVA  Then
                            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                            '    ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            '    'ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.BECrossTubeCastingWithoutPort", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            'Else
                            '    ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2)
                            '    'ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.BECrossTubeCastingWithoutPort", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            'End If
                            ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart, "Base End", True)
                        End If
                        If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "NewDesign" Then
                            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName) = UCase("Welded.besinglelugdetails") Then
                                ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName, "Base End") 'Rod End
                            Else
                                ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            End If
                        End If
                        If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize2 = "NewDesign" Then
                            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2) = UCase("Welded.besinglelugdetails") Then
                                ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2, "Base End") 'Rod End
                            Else
                                ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2)
                            End If
                            'ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                        End If
                        'End If
                    Else
                        'If (ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize <> "Exact" AndAlso ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize <> "Resize") OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False Then         '20_10_2010    RAGAVA
                        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndFabrication_New = True Then
                            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                            '    ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName, "BASE END")            '14_12_2011  RAGAVA
                            'Else
                            '    ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2, "BASE END")            '14_12_2011  RAGAVA
                            'End If
                            ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart, "Base End", False)
                            'ObjClsWeldedCylinderFunctionalClass.storeData("Welded.becrossTubeDetails", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName, "BASE END")            '14_12_2011  RAGAVA
                        End If
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndCasting_New = True Then
                            'If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                            '    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                            '        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                            '            ObjClsWeldedCylinderFunctionalClass.storeData("BECrossTubeRaisedPort", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            '        Else
                            '            ObjClsWeldedCylinderFunctionalClass.storeData("BECrossTubeRaisedPort", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2)
                            '        End If
                            '        'ObjClsWeldedCylinderFunctionalClass.storeData("BECrossTubeRaisedPort", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            '    Else
                            '        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                            '            ObjClsWeldedCylinderFunctionalClass.storeData("BECrossTubeRaisedPort90", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            '        Else
                            '            ObjClsWeldedCylinderFunctionalClass.storeData("BECrossTubeRaisedPort90", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2)
                            '        End If
                            '        'ObjClsWeldedCylinderFunctionalClass.storeData("BECrossTubeRaisedPort90", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            '    End If
                            'Else
                            '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                            '        ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.BECrossTubeFlushPort", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            '    Else
                            '        ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.BECrossTubeFlushPort", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2)
                            '    End If
                            '    'ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.BECrossTubeFlushPort", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            'End If
                            ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart, "Base End", True)
                        End If
                        If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "NewDesign" Then
                            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                            ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            'Else
                            '    ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2)
                            'End If
                            'ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                        End If
                        If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize2 = "NewDesign" Then
                            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                            '    ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            'Else
                            ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2)
                            'End If
                        End If
                        'End If
                    End If
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" Then

                    '15_05_2012  RAGAVA
                Try
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
                        'If (ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize <> "Exact") OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False Then         '27_03_2012    RAGAVA       Commented
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndCasting_New = True Then       '15_03_2012   RAGAVA  ' If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected Then
                            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                            '    ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            'Else
                            '    ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2)
                            'End If   ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart
                            ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart, "Base End", True) '30_05_2012  RAGAVA
                        End If
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndFabrication_New = True Then       '15_03_2012   RAGAVA     '  ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                            '    If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName) = UCase("Welded.besinglelugdetails") Then
                            '        ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName, "Base End") ', "Rod End")
                            '    Else
                            '        ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            '    End If
                            'Else
                            '    If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2) = UCase("Welded.besinglelugdetails") Then
                            '        ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2, "Base End") ', "Rod End")
                            '    Else
                            '        ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2)
                            '    End If
                            'End If
                            ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart, "Base End") '30_05_2012  RAGAVA
                        End If


                        '=================== VAMSI 29-01-2014 START =========================================
                        If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize" Then
                            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName) = UCase("Welded.besinglelugdetails") Then
                                ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName, "Rod End")
                            Else
                                ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            End If
                            '06_06_2012   RAGAVA
                        End If


                        '========================= END ======================================================

                        If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "NewDesign" Then
                            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName) = UCase("Welded.besinglelugdetails") Then
                                ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName, "Rod End")
                            Else
                                ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            End If
                            '06_06_2012   RAGAVA
                        End If
                        If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize2 = "NewDesign" Then
                            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2) = UCase("Welded.besinglelugdetails") Then
                                ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2, "Rod End")
                            Else
                                ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2)
                            End If
                        End If
                        'End If
                    Else
                        'If (ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize <> "Exact") OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False Then         '27_03_2012    RAGAVA      Commented
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndCasting_New = True Then       '15_03_2012   RAGAVA If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected Then
                            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Cast" Then
                            '    ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            'Else
                            '    ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2)
                            'End If
                            ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart, "Base End", True)       '30_05_2012   RAGAVA
                        End If
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBaseEndFabrication_New = True Then       '15_03_2012   RAGAVA ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndFabricationSelected Then
                            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strCast_Fabricated_1st = "Fabrication" Then
                            '    ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            'Else
                            '    ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2)
                            'End If
                            ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart, "Base End")       '30_05_2012   RAGAVA
                        End If
                        If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "NewDesign" Then
                            ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                        ElseIf ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize2 = "NewDesign" Then
                            ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2)
                        End If
                        'End If
                    End If
                Catch ex As Exception
                End Try



            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Threaded End" Then
                    Try
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
                            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected Then
                                ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.BEThreadedBaseNoPort", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            ElseIf ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "NewDesign" Then
                                ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.BEThreadedBaseNoPort", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            End If
                        Else
                            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected Then
                                If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                                    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                                        ObjClsWeldedCylinderFunctionalClass.storeData("BEThreadedEndRaisedPort", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                                    Else
                                        ObjClsWeldedCylinderFunctionalClass.storeData("BEThreadedEndRaisedPort90", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                                    End If
                                Else
                                    ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.BEThreadedEndFlushPort", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                                End If
                            ElseIf ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "NewDesign" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False Then         '20_10_2010    RAGAVA
                                If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                                    ObjClsWeldedCylinderFunctionalClass.storeData("BEThreadedEndRaisedPort", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                                Else
                                    ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.BEThreadedEndFlushPort", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    '18_03_2010   RAGAVA
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Base Plug" Then
                    If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
                        If (ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize <> "Exact" AndAlso ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize <> "Resize") OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False Then         '20_10_2010    RAGAVA
                            '27_04_2010   RAGAVA   NEW DESIGN
                            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                                '19_05_2010   RAGAVA     NEW DESIGN
                                If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                                    ObjClsWeldedCylinderFunctionalClass.storeData("BasePlugRaisedPort", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                                Else
                                    ObjClsWeldedCylinderFunctionalClass.storeData("BasePlugRaisedPort90", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                                End If
                                'Till  Here
                            Else
                                ObjClsWeldedCylinderFunctionalClass.storeData("Welded.BasePlugFlushedPort", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            End If
                            'ObjClsWeldedCylinderFunctionalClass.storeData("Welded.BasePlugFlushedPort", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            'Till   here
                        End If
                    ElseIf ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
                        If (ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize <> "Exact" AndAlso ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize <> "Resize") OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False Then         '20_10_2010    RAGAVA
                            ObjClsWeldedCylinderFunctionalClass.storeData("Welded.BEBasePlugCastWithOutPort", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                        End If

                    End If
                    '18_03_2010   RAGAVA   Till   Here

                    '02_11_2011   RAGAVA
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis" Then
                    If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" Then

                    Else  'RAISED
                        If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndCodeNumber) = False Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.Add("CLEVIS_PLATE_WR", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndCodeNumber)
                                clsAddExistingCodes.AddTubeCodeToHashTable("CLEVIS PLATE", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndCodeNumber, 1, "EA")
                            End If
                        ElseIf ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "90" Then
                            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndCodeNumber90) = False Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.Add("CLEVIS_PLATE_WR_90", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndCodeNumber90)
                                clsAddExistingCodes.AddTubeCodeToHashTable("CLEVIS PLATE 90", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndCodeNumber90, 1, "EA")
                            End If
                        End If
                    End If
            End If
            'End If
        Catch ex As Exception
        End Try

        'Rod End configuration Single Lug Design a casting
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = False Then         '08_11_2010   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Single Lug" Then
                    If (ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd <> "Exact" AndAlso ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd <> "Resize") OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = False Then         '20_10_2010    RAGAVA
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "NewDesign" Then
                            ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.RESLDetails", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                            'ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.BESingleLugDetails", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                        ElseIf ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "NewDesign" Then
                            ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                        End If
                    End If
                    ' MANJULA ADDED
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "BH" Then
                    If (ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd <> "Exact" AndAlso ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd <> "Resize") OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = False Then         '20_10_2010    RAGAVA
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "NewDesign" Then
                            ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.Rod_End_BH", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                            'ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.BESingleLugDetails", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                        ElseIf ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "NewDesign" Then
                            ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                        End If
                    End If
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
                    'If (ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd <> "Exact" AndAlso ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd <> "Resize") OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = False Then         '20_10_2010    RAGAVA
                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndDesignSelected = True OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndFabricationSelected = True Then
                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndFabricationSelected = True Then            '14_02_2011   RAGAVA
                    '    ObjClsWeldedCylinderFunctionalClass.storeData("Welded.BECrossTubeDetails", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName, "ROD END")            '14_12_2011  RAGAVA
                    'Else
                    '    ObjClsWeldedCylinderFunctionalClass.storeData("Welded.RECrossTubeCasting", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                    'End If
                    'ElseIf ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "NewDesign" Then
                    'ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                    'End If
                    'End If

                    '24_07_2012    RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndFabricationSelected = True OrElse ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "NewDesign" Then            '14_02_2011   RAGAVA
                        ObjClsWeldedCylinderFunctionalClass.storeData("Welded.BECrossTubeDetails", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName, "ROD END")            '14_12_2011  RAGAVA
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndFabricationSelected2 = True OrElse ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd2 = "NewDesign" Then
                        ObjClsWeldedCylinderFunctionalClass.storeData("Welded.BECrossTubeDetails", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName2, "ROD END")            '14_12_2011  RAGAVA
                    End If
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndDesignSelected = True OrElse ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "NewDesign" Then            '14_02_2011   RAGAVA
                        ObjClsWeldedCylinderFunctionalClass.storeData("Welded.RECrossTubeCasting", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnddesignSelected2 = True OrElse ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd2 = "NewDesign" Then
                        ObjClsWeldedCylinderFunctionalClass.storeData("Welded.RECrossTubeCasting", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName2)
                    End If

                    ''ElseIf ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "NewDesign" Then
                    'ObjClsWeldedCylinderFunctionalClass.storeData(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnd_NewDesign_TableName, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)



                    'Double Lug
                    '27_02_2010  RAGAVA
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" Then
                    '15_02_2010   RAGAVA- Not using selected ULug Welded
                    Try
                        If (ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd <> "Exact") OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = False Then         '20_10_2010    RAGAVA
                            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Welded" Then
                                If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "NewDesign" Then
                                    ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.BEULDetails", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                                ElseIf ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated" Then       '01_03_2010   RAGAVA
                                    ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.BEULDetails", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                                    'End If
                                    'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Casting" Then
                                ElseIf ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd <> "Resize" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = False Then         '20_10_2010    RAGAVA
                                    If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "NewDesign" Then
                                        ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.REDLCasting", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                                    ElseIf ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Cast" Then        '01_03_2010   RAGAVA
                                        ObjClsWeldedCylinderFunctionalClass.storeData("WELDED.REDLCasting", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                                    End If
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    'Till   Here
                End If
            End If
        Catch ex As Exception
        End Try
        'Model Generation

        '----------------------------------------------------------------------------------------------------009
        '840---1036

        If SaveDetails <> True Then

            Try
                GenerateNotes()     '25_03_2010     RAGAVA
            Catch ex As Exception
            End Try

            Try
                ObjClsWeldedCylinderFunctionalClass.generateMainAssembly()
            Catch ex As Exception
            End Try


            Try
                ObjClsWeldedCylinderFunctionalClass.KillAllSolidWorksServices()
                ObjClsWeldedCylinderFunctionalClass.CloseExcel(False)
            Catch ex As Exception

            End Try

            Dim strParentExcelPath As String = "C:\WELD_DESIGN_TABLES\WELD_GUI_PARAMETERS.xls"
            Dim strChildExcelPath As String = "C:\WELDED_TESTING\" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber + "\" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber + "WELD_GUI_PARAMETERS.xls"
            If System.IO.File.Exists(strParentExcelPath) Then
                System.IO.File.Copy(strParentExcelPath, strChildExcelPath)
            End If

            Try
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.SetCodeStatus()
            Catch ex As Exception

            End Try

            '----------------------------------------------------------------------------------------------------------------------------------------------009
            '----------------------------------------------------------------------------------------------------------------------------------------------009

            If ObjClsWeldedCylinderFunctionalClass.MultiGenerate <> True Then


                Dim strMsg = "Model generated successfully" + vbNewLine
                strMsg += "At Location" + vbNewLine
                'strMsg += ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath
                strMsg += ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AssyGeneratePath     '14_07_2010   RAGAVA


                'TODO: ANUP 22-04-2010 10.41am
                If MessageBox.Show(strMsg, "Model Generation", MessageBoxButtons.OK, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then

                    Finalise()

                End If
            End If
            '----------------------------------------------------------------------------------------------------------------------------------------------009
            '----------------------------------------------------------------------------------------------------------------------------------------------009


            If ObjClsWeldedCylinderFunctionalClass.MultiGenerate = True Then

                Finalise()
            End If


            
        End If

        '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------009
    End Sub



    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------009
    '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------009
    'seperated to subprocedure Finalise() to facilitate BatchRun
    Public Sub Finalise()

        'ANUP 01-11-2010 START
        'Put Release Cylinder Data into Excel
        If ObjClsWeldedCylinderFunctionalClass.IsReleaseCylinderChecked Then
            Dim oClsReleaseCylinderFunctionality As New clsReleaseCylinderFunctionality
            If Not oClsReleaseCylinderFunctionality.MainFunctionality() Then
                MessageBox.Show("Release Cylinder Validation Failed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        End If
        'ANUP 01-11-2010 TILL HERE

        'anup 21-03-2011 start
        Dim oClsReleaseCylinderFunc As New clsReleaseCylinderFunctionality
        oClsReleaseCylinderFunc.AssigningValuesToIsReleasedOrNot()
        'anup 21-03-2011 till here


        'Sunny-05-08-10
        '' Dim oHashTable As Hashtable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable
        GenerateCostingSheet()
        ' GenerateSafetyFactorSheet() 'vamsi 13th August 2013

        '31_05_2011  RAGAVA
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_RodEnd = False Then
                Dim strQuery As String = String.Empty
                strQuery = "select * from Contract_SafetyFactor_Details where ContractNumber = '" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber & "'"
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd <> "" Then
                    strQuery = strQuery + " and BaseEndCodeNumber = '" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd & "'"
                End If
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd <> "" Then
                    strQuery = strQuery + " and RodEndCodeNumber ='" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd & "'"
                End If

                Dim Objdt As DataTable
                Objdt = MonarchConnectionObject.GetTable(strQuery)
                If Objdt.Rows.Count > 0 Then
                    strQuery = "Update Contract_SafetyFactor_Details set BaseEndSafetyFactor = '" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd.ToString & "' and RodEndSafetyFactor = '" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_RodEnd.ToString & "' where ContractNumber = '" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber & "' and RodEndCodeNumber ='" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd & "' and BaseEndCodeNumber ='" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd & "'"
                Else
                    strQuery = "Insert into Contract_SafetyFactor_Details values ('" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & "','" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd & "'," & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_BaseEnd & ",'" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd & "'," & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SafetyFactor_RodEnd & ")"
                End If
                MonarchConnectionObject.ExecuteQuery(strQuery)
            End If
        Catch ex As Exception

        End Try
        'Till  Here



        'If ObjClsWeldedCylinderFunctionalClass.IsReleaseCylinderChecked Then

        Try
            If ObjClsWeldedCylinderFunctionalClass.IsReleaseCylinderChecked Then
                ObjClsWeldedCylinderFunctionalClass.strCMSfileLocation = "W:\WELDED\CMS\" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber + "_CMS"
                If Not Directory.Exists("W:\WELDED\CMS\") Then
                    Directory.CreateDirectory("W:\WELDED\CMS\")
                End If
                If Directory.Exists(ObjClsWeldedCylinderFunctionalClass.strCMSfileLocation) Then
                    Directory.Delete(ObjClsWeldedCylinderFunctionalClass.strCMSfileLocation, True)
                End If
                Directory.CreateDirectory(ObjClsWeldedCylinderFunctionalClass.strCMSfileLocation)
            Else
                'ObjClsWeldedCylinderFunctionalClass.strCMSfileLocation = "C:\WELDED_TESTING\CMS_TEMP\" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber + "_CMS"
                'If Not Directory.Exists("C:\WELDED_TESTING\CMS_TEMP\") Then
                '    Directory.CreateDirectory("C:\WELDED_TESTING\CMS_TEMP\") VAMSI 25 JUNE 2013
                'End If
                ' VAMSI 25 JUNE 2013 start

                ObjClsWeldedCylinderFunctionalClass.strCMSfileLocation = "K:\USR\_CYLINDER\CYLOEM\IFL DWG NR\WELDED\CMS\" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber + "_CMS"

                If Directory.Exists(ObjClsWeldedCylinderFunctionalClass.strCMSfileLocation) Then
                    Directory.Delete(ObjClsWeldedCylinderFunctionalClass.strCMSfileLocation, True)
                End If

                If Not Directory.Exists("K:\USR\_CYLINDER\CYLOEM\IFL DWG NR\WELDED\CMS\") Then
                    Directory.CreateDirectory("K:\USR\_CYLINDER\CYLOEM\IFL DWG NR\WELDED\CMS\")
                End If

                'VAMSI 25 JUNE 2013 end


                
                Directory.CreateDirectory(ObjClsWeldedCylinderFunctionalClass.strCMSfileLocation)
            End If
            'anup 21-03-2011 code is called before costing
            ''anup 17-02-2011 start
            'Dim oClsReleaseCylinderFunctionality As New clsReleaseCylinderFunctionality
            'oClsReleaseCylinderFunctionality.AssigningValuesToIsReleasedOrNot()
            ''anup 17-02-2011 till here

            'CMS for Manufactured & Purchased
            Dim oclsManufactured_Purchased_CMS As New clsManufactured_Purchased_CMS
            oclsManufactured_Purchased_CMS.Generate_Manufactured_Purchased_CMS()

            'ObjClsWeldedCylinderFunctionalClass.CloseExcel(False)
            'ObjClsWeldedCylinderFunctionalClass.CreateExcel()
            'CMS for BOM List
            Dim oclsMaterial_CMS As New clsMaterial_CMS
            oclsMaterial_CMS.Generate_BOM_CMS()

            'CMS for STKA
            Dim oclsPlant_Part_Master_CMS As New clsPlant_Part_Master_CMS
            oclsPlant_Part_Master_CMS.GenerateCylinder_STKA_CMS()


            'ROUTING
            Dim oCMSUtil As New CMSUtil
            Dim blnSuccess As Boolean = False
            blnSuccess = oCMSUtil.Start(ObjClsWeldedCylinderFunctionalClass.strCMSfileLocation)
            If ObjClsWeldedCylinderFunctionalClass.IsReleaseCylinderChecked Then      '22_06_2011  RAGAVA
                MsgBox("CMS completed successfully")
            End If
            CNC_Code()

            '24_06_2011   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.InsertData_PartsDetails_ReleaseOnClick()
            'Till   Here

        Catch ex As Exception

        End Try
        Try
            If ObjClsWeldedCylinderFunctionalClass.IsReleaseCylinderChecked Then         '22_06_2011    RAGAVA
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.UpdateExistedCasting()      '07_02_2011   RAGAVA
            End If
        Catch ex As Exception
            MsgBox("Error in updating Existing Casting Details")

        End Try

        '22_02_2011   RAGAVA
        Try
            ObjClsWeldedCylinderFunctionalClass.ObjClsExcelClass.checkExcelInstance()
            ObjClsWeldedCylinderFunctionalClass.ObjClsExcelClass.objApp.Workbooks.Open(System.Environment.CurrentDirectory + "\WeldedCosting_Master.xls")
            ObjClsWeldedCylinderFunctionalClass.ObjClsExcelClass.objApp.Workbooks.Close()
        Catch ex As Exception

        End Try
        'ANUP 01-11-2010 TILL HERE

        ObjClsWeldedCylinderFunctionalClass.CloseExcel()

        If ObjClsWeldedCylinderFunctionalClass.MultiGenerate <> True Then
            ObjClsWeldedCylinderFunctionalClass.StopWatchAndProgressBar = "Stop"  'vamsi 11-06-14
            Application.Exit()
        End If

    End Sub



    Private Sub CNC_Code()
        Dim oCyl As New clsCNCUtil
        If oCyl.DoCNCCodeGeneration() Then
            If ObjClsWeldedCylinderFunctionalClass.IsReleaseCylinderChecked Then
                MsgBox("CNC Code generated ")
            End If
        Else
            MessageBox.Show(oCyl.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


        'If CVSFileUtil.Check("C:\CNCCode\01111111.MIN", "C:\CNCCode\access\01111111.MIN") Then
        '    MessageBox.Show("CNC CODE Checked Success")
        'Else
        '    MessageBox.Show("CNC CODE Checked Failed")
        'End If

    End Sub

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



    '******************************************************************************
    '31_03_2010     RAGAVA
    'Private _strGeneralNotes As String
    'Private _strPaintPackagingNotes As String
    'Private _strAssemblyNotes As String
    'Private _iAssyNotesCount As Integer
    'Private _iPaintingNotesCount As Integer

    'Public Property strPaintPackagingNotes() As String
    '    Get
    '        Return _strPaintPackagingNotes
    '    End Get
    '    Set(ByVal value As String)
    '        _strPaintPackagingNotes = value
    '    End Set
    'End Property
    'Public Property strAssemblyNotes() As String
    '    Get
    '        Return _strAssemblyNotes
    '    End Get
    '    Set(ByVal value As String)
    '        _strAssemblyNotes = value
    '    End Set
    'End Property
    'Public Property GeneralNotes() As String
    '    Get
    '        Return _strGeneralNotes
    '    End Get
    '    Set(ByVal value As String)
    '        _strGeneralNotes = value
    '    End Set
    'End Property
    'Public Property iAssyNotesCount() As Integer
    '    Get
    '        Return _iAssyNotesCount
    '    End Get
    '    Set(ByVal value As Integer)
    '        _iAssyNotesCount = value
    '    End Set
    'End Property
    'Public Property iPaintingNotesCount() As Integer
    '    Get
    '        Return _iPaintingNotesCount
    '    End Get
    '    Set(ByVal value As Integer)
    '        _iPaintingNotesCount = value
    '    End Set
    'End Property
    Public Sub GenerateNotes()
        Dim iNotes As Integer = 0
        Dim HT_AssemblyNotes As New Hashtable
        Dim HT_PaintNotes As New Hashtable
        Try
            If ChkPins.Checked = True Then
                If Trim(txtPins.Text) <> "" Then
                    iNotes = Val(txtPins.Text)
                Else
                    iNotes += 1
                End If
                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(ChkPins.Text))
            End If
            If Trim(txtRetractedLength.Text) <> "" Then
                iNotes = Val(txtRetractedLength.Text)
            Else
                iNotes += 1
            End If
            HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(ChkRetractedLength.Text) & " ______________________")
            If Trim(txtExtenedLength.Text) <> "" Then
                iNotes = Val(txtExtenedLength.Text)
            Else
                iNotes += 1
            End If
            HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(ChkExtendedLength.Text) & " ______________________")
            If Trim(txtRodDiameter.Text) <> "" Then
                iNotes = Val(txtRodDiameter.Text)
            Else
                iNotes += 1
            End If
            HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(ChkRodDiameter.Text) & " ______________________")
            If chkSetScrew.Checked = True Then
                If Trim(txtSetScrew.Text) <> "" Then
                    iNotes = Val(txtSetScrew.Text)
                Else
                    iNotes += 1
                End If
                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(chkSetScrew.Text))
            End If
            '24_06_2010   RAGAVA
            If chkGreaseZerc.Checked = True Then
                If Trim(txtGreaseZerc.Text) <> "" Then
                    iNotes = Val(txtGreaseZerc.Text)
                Else
                    iNotes += 1
                End If
                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(chkGreaseZerc.Text))
            End If
            'Till   Here
            If chk100AirTest.Checked = True Then
                If Trim(txtAirTest.Text) <> "" Then
                    iNotes = Val(txtAirTest.Text)
                Else
                    iNotes += 1
                End If
                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(chk100AirTest.Text))
            End If
            If chk100OilTest.Checked = True Then
                If Trim(txtOilTest.Text) <> "" Then
                    iNotes = Val(txtOilTest.Text)
                Else
                    iNotes += 1
                End If
                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(chk100OilTest.Text))
            End If
            '21_09_2012   RAGAVA
            If chkByPass.Checked = True Then
                If Trim(txtByPass.Text) <> "" Then
                    iNotes = Val(txtByPass.Text)
                Else
                    iNotes += 1
                End If
                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(chkByPass.Text))
            End If
            'Till  Here
            If ChkRephaseExtension.Checked = True Then
                If Trim(txtRephaseOnExtension.Text) <> "" Then
                    iNotes = Val(txtRephaseOnExtension.Text)
                Else
                    iNotes += 1
                End If
                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(ChkRephaseExtension.Text))
            End If
            If ChkRephaseRetraction.Checked = True Then
                If Trim(txtRephaseOnRetraction.Text) <> "" Then
                    iNotes = Val(txtRephaseOnRetraction.Text)
                Else
                    iNotes += 1
                End If
                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(ChkRephaseRetraction.Text))
            End If

            'vamsi 10-03-14 start.
            If chkCushionsonExtension.Checked = True Then
                If Trim(txtCushionsOnExtension.Text) <> "" Then
                    iNotes = Val(txtCushionsOnExtension.Text)
                Else
                    iNotes += 1
                End If
                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(chkCushionsonExtension.Text))
            End If

            If chkCushionsOnRetraction.Checked = True Then
                If Trim(txtCusionsOnRetraction.Text) <> "" Then
                    iNotes = Val(txtCusionsOnRetraction.Text)
                Else
                    iNotes += 1
                End If
                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(chkCushionsOnRetraction.Text))
            End If


            'vamsi End




            '21_09_2012   RAGAVA
            If chkInstallAdaptorFitting.Checked = True Then
                If Trim(txtInstallAdaptorFitting.Text) <> "" Then
                    iNotes = Val(txtInstallAdaptorFitting.Text)
                Else
                    iNotes += 1
                End If
                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(chkInstallAdaptorFitting.Text))
            End If
            If chkOrifice.Checked = True Then
                If Trim(txtOrifice.Text) <> "" Then
                    iNotes = Val(txtOrifice.Text)
                Else
                    iNotes += 1
                End If
                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(chkOrifice.Text))
            End If
            'Till  Here
            'If chkInstallSetScrewAfterOilTest.Checked = True Then  vamsi 12 august 2013
            '    If Trim(txtInstallSetScrewAfterOilTesting.Text) <> "" Then
            '        iNotes = Val(txtInstallSetScrewAfterOilTesting.Text)
            '    Else
            '        iNotes += 1
            '    End If
            '    HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(chkInstallSetScrewAfterOilTest.Text))
            'End If

            '21_09_2012   RAGAVA
            If chkPlugBreatherForPainting.Checked = True Then
                If Trim(txtPlugBreatherForPainting.Text) <> "" Then
                    iNotes = Val(txtPlugBreatherForPainting.Text)
                Else
                    iNotes += 1
                End If
                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(chkPlugBreatherForPainting.Text))
            End If
            If chkInstallBreather.Checked = True Then
                If Trim(txtInstallBreather.Text) <> "" Then
                    iNotes = Val(txtInstallBreather.Text)
                Else
                    iNotes += 1
                End If
                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(chkInstallBreather.Text))
            End If
            'Till  Here


            If chkStampCustomerPartandDate.Checked = True Then
                If Trim(txtStampCustomerPartandDate.Text) <> "" Then
                    iNotes = Val(txtStampCustomerPartandDate.Text)
                Else
                    iNotes += 1
                End If
                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(chkStampCustomerPartandDate.Text))
            End If
            If chkStampCustomerPartOnTube.Checked = True Then
                If Trim(txtStampCustomerPart.Text) <> "" Then
                    iNotes = Val(txtStampCustomerPart.Text)
                Else
                    iNotes += 1
                End If
                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(chkStampCustomerPartOnTube.Text))
            End If
            If ChkStampCountryOfOrigin.Checked = True Then
                If Trim(txtStampCountry.Text) <> "" Then
                    iNotes = Val(txtStampCountry.Text)
                Else
                    iNotes += 1
                End If
                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(ChkStampCountryOfOrigin.Text))
            End If
            If ChkRodMaterial.Checked = True Then
                If Trim(txtRodMaterialNitroSteel.Text) <> "" Then
                    iNotes = Val(txtRodMaterialNitroSteel.Text)
                Else
                    iNotes += 1
                End If
                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(ChkRodMaterial.Text))
            End If
            If ChkInstallHardenedBushings.Checked = True Then
                If Trim(txtInstallSteelPlugs.Text) <> "" Then
                    iNotes = Val(txtInstallSteelPlugs.Text)
                Else
                    iNotes += 1
                End If
                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(ChkInstallHardenedBushings.Text))
            End If
            If ChkHardenedBushingsRodEnd.Checked = True Then
                If Trim(txtInstallHardenedBushingsRodEnd.Text) <> "" Then
                    iNotes = Val(txtInstallHardenedBushingsRodEnd.Text)
                Else
                    iNotes += 1
                End If
                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(ChkHardenedBushingsRodEnd.Text))
            End If
            If ChkHardenedBushingsBaseEnd.Checked = True Then
                If Trim(txtInstallHardenedBushingsBaseEnd.Text) <> "" Then
                    iNotes = Val(txtInstallHardenedBushingsBaseEnd.Text)
                Else
                    iNotes += 1
                End If
                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(ChkHardenedBushingsBaseEnd.Text))
            End If
            If ChkAssemblyStopTube.Checked = True Then
                If Trim(txtAssemblyStopTube.Text) <> "" Then
                    iNotes = Val(txtAssemblyStopTube.Text)
                Else
                    iNotes += 1
                End If
                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(ChkAssemblyStopTube.Text))
            End If
            If chkAssemblyNotes.Checked = True AndAlso Trim(RichTextBox1.Text) <> "" Then
                Dim strText As String() = RichTextBox1.Lines
                For Each str As String In strText
                    If Trim(str) <> "" Then
                        Dim strSplit() As String
                        strSplit = str.Split("}")
                        Dim strNumber As String = strSplit(LBound(strSplit))
                        Try
                            If strNumber = "" Then
                                iNotes += 1
                                HT_AssemblyNotes.Add(iNotes.ToString & ".0", UCase(strSplit(UBound(strSplit))))
                            Else
                                HT_AssemblyNotes.Add(strNumber & ".0", UCase(strSplit(UBound(strSplit))))
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Next
            End If
            Dim AssyNotesCount As Integer = HT_AssemblyNotes.Keys.Count
            For Each Item As Object In HT_AssemblyNotes.Keys
                If AssyNotesCount < Val(Item) Then
                    AssyNotesCount = Val(Item)
                End If
            Next
            Dim iCount As Integer = 1
            For iCount = 1 To AssyNotesCount
                If HT_AssemblyNotes.ContainsKey(iCount.ToString & ".0") = True Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strAssemblyNotes = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strAssemblyNotes & iCount.ToString & ". " & Trim(HT_AssemblyNotes((iCount.ToString & ".0"))) & vbNewLine
                End If
            Next
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.iAssyNotesCount = HT_AssemblyNotes.Keys.Count
            '*********  END OF ASSEMBLY NOTES GENERATION **********************************************
            'PAINT NOTES GENERATION
            iCount = 1
            iNotes = 0

            '09_05_2011  RAGAVA
            If chkMaskPerBOM.Checked = True Then             '05_12_2011   RAGAVA
                If Trim(txtMaskPerBOM.Text) <> "" Then
                    iNotes = Val(txtMaskPerBOM.Text)
                Else
                    iNotes += 1
                End If
                HT_PaintNotes.Add(iNotes.ToString & ".0", chkMaskPerBOM.Text)
                iCount += 1
            End If
            'Till  Here
            'vamsi 12th August 2013 
            'If ChkMaskBushings.Checked = True Then
            '    If Trim(txtMaskBushings.Text) <> "" Then
            '        iNotes = Val(txtMaskBushings.Text)
            '    Else
            '        iNotes += 1
            '    End If
            '    HT_PaintNotes.Add(iNotes.ToString & ".0", ChkMaskBushings.Text)
            '    iCount += 1
            'End If
            'Till here

            '24_09_2010   RAGAVA
            If chkNoPaintOrPrimer.Checked = True Then
                If Trim(txtNoPaintOrPrimer.Text) <> "" Then
                    iNotes = Val(txtNoPaintOrPrimer.Text)
                Else
                    iNotes += 1
                End If
                HT_PaintNotes.Add(iNotes.ToString & ".0", chkNoPaintOrPrimer.Text)
                iCount += 1
            End If
            'Till  Here

            If ChkPrime.Checked = True Then
                If Trim(txtPrime.Text) <> "" Then
                    iNotes = Val(txtPrime.Text)
                Else
                    iNotes += 1
                End If
                HT_PaintNotes.Add(iNotes.ToString & ".0", ChkPrime.Text)
                iCount += 1
            End If
            If ChkPaint.Checked = True Then
                If Trim(txtPaint.Text) <> "" Then
                    iNotes = Val(txtPaint.Text)
                Else
                    iNotes += 1
                End If
                'HT_PaintNotes.Add(iNotes.ToString & ".0", ChkPaint.Text & " " & UCase(ofrmTieRod2.cmbPaint.SelectedItem.ToString.Substring(0, ofrmTieRod2.cmbPaint.SelectedItem.ToString.IndexOf("-"))))
                'HT_PaintNotes.Add(iNotes.ToString & ".0", ChkPaint.Text & " " & Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbPaint.SelectedItem))           '20_08_2010     RAGAVA vamsi commented 18-02-14

                'VAMSI PAINT DESCRIPTION START
                Dim oDataRow As String = ObjClsWeldedCylinderFunctionalClass.ObjClsMIL_TieRodDataClass.GetPaintDescription(ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbPaint.Text)

                HT_PaintNotes.Add(iNotes.ToString & ".0", ChkPaint.Text & " " & oDataRow)

                'END

                iCount += 1
            End If
            '================== vamsi 2-02-2014 start ==================
            If chkREMOVEPLUGANDINSTALLBREATHERPLUG.Checked = True Then
                If Trim(txtREMOVEPLUGANDINSTALLBREATHERPLUG.Text) <> "" Then
                    iNotes = Val(txtREMOVEPLUGANDINSTALLBREATHERPLUG.Text)
                Else
                    iNotes += 1

                End If
                HT_PaintNotes.Add(iNotes.ToString & ".0", chkREMOVEPLUGANDINSTALLBREATHERPLUG.Text)
                iCount += 1
            End If

            '============= vamsi end ======================================
            If chkAffixLabel.Checked = True Then
                If Trim(txtAffixLabel.Text) <> "" Then
                    iNotes = Val(txtAffixLabel.Text)
                Else
                    iNotes += 1
                End If
                HT_PaintNotes.Add(iNotes.ToString & ".0", chkAffixLabel.Text)
                iCount += 1
            End If


            '24_09_2010   RAGAVA
            If chkCleanCylinder.Checked = True Then
                If Trim(txtCleanCylinder.Text) <> "" Then
                    iNotes = Val(txtCleanCylinder.Text)
                Else
                    iNotes += 1
                End If
                HT_PaintNotes.Add(iNotes.ToString & ".0", chkCleanCylinder.Text)
                iCount += 1
            End If
            If chkBoxMustBeLined.Checked = True Then
                If Trim(txtBoxMustBeLined.Text) <> "" Then
                    iNotes = Val(txtBoxMustBeLined.Text)
                Else
                    iNotes += 1
                End If
                HT_PaintNotes.Add(iNotes.ToString & ".0", chkBoxMustBeLined.Text)
                iCount += 1
            End If
            If chkBagMustBeTightlySealed.Checked = True Then
                If Trim(txtBagMustBeTightlySealed.Text) <> "" Then
                    iNotes = Val(txtBagMustBeTightlySealed.Text)
                Else
                    iNotes += 1
                End If
                HT_PaintNotes.Add(iNotes.ToString & ".0", chkBagMustBeTightlySealed.Text)
                iCount += 1
            End If
            'Till  Here

            If chkInstallPinAndClips.Checked = True Then
                If Trim(txtInstallPinandClips.Text) <> "" Then
                    iNotes = Val(txtInstallPinandClips.Text)
                Else
                    iNotes += 1
                End If
                HT_PaintNotes.Add(iNotes.ToString & ".0", chkInstallPinAndClips.Text)
                iCount += 1
            End If

            If ChkIncludePinkitPerBom.Checked = True Then      'priyanak 
                If Trim(txtIncludePinkitPerBom.Text) <> "" Then
                    iNotes = Val(txtIncludePinkitPerBom.Text)
                Else
                    iNotes += 1
                End If
                HT_PaintNotes.Add(iNotes.ToString & ".0", ChkIncludePinkitPerBom.Text)
                iCount += 1
            End If

            'vamsi 12th August 2013 start
            'If chkPackCylinderInPlasticBag.Checked = True Then
            '    If Trim(txtPackCylinder.Text) <> "" Then
            '        iNotes = Val(txtPackCylinder.Text)
            '    Else
            '        iNotes += 1
            '    End If
            '    HT_PaintNotes.Add(iNotes.ToString & ".0", chkPackCylinderInPlasticBag.Text)
            '    iCount += 1
            'End If
            'till here


            'vamsi 12th August 2013 start
            If chkNoLabelOnCylinder.Checked = True Then
                If Trim(txtNoLabelOnCylinder.Text) <> "" Then
                    iNotes = Val(txtNoLabelOnCylinder.Text)
                Else
                    iNotes += 1
                End If
                HT_PaintNotes.Add(iNotes.ToString & ".0", chkNoLabelOnCylinder.Text)
                iCount += 1

            End If

            'End
            If chkPackagePerSOP.Checked = True Then
                If Trim(txtPackagePerSOP.Text) <> "" Then
                    iNotes = Val(txtPackagePerSOP.Text)
                Else
                    iNotes += 1
                End If
                HT_PaintNotes.Add(iNotes.ToString & ".0", chkPackagePerSOP.Text)
                iCount += 1
            End If

            'If chkSingleActingPullAppliction.Checked = True Then               'priyanka
            '    If Trim(txtSingleActingPullApplication.Text) <> "" Then
            '        iNotes = Val(txtSingleActingPullApplication.Text)
            '    Else
            '        iNotes += 1
            '    End If
            '    HT_PaintNotes.Add(iNotes.ToString & ".0", txtSingleActingPullApplication.Text)
            '    iCount += 1
            'End If

            'If chkSingleActingPushApplication.Checked = True Then                'priyanka
            '    If Trim(txtSingleActingPushApplication.Text) <> "" Then
            '        iNotes = Val(txtSingleActingPushApplication.Text)
            '    Else
            '        iNotes += 1
            '    End If
            '    HT_PaintNotes.Add(iNotes.ToString & ".0", chkSingleActingPushApplication.Text)
            '    iCount += 1
            'End If

            If chkPaintingNote.Checked = True AndAlso Trim(RichTextBox2.Text) <> "" Then
                Dim strText As String() = RichTextBox2.Lines
                For Each str As String In strText
                    If Trim(str) <> "" Then
                        Dim strSplit() As String
                        strSplit = str.Split("}")
                        Dim strNumber As String = strSplit(LBound(strSplit))
                        Try
                            If Trim(strNumber) = "" Then
                                iNotes += 1
                                HT_PaintNotes.Add(iNotes.ToString & ".0", UCase(strSplit(UBound(strSplit))))
                            Else
                                HT_PaintNotes.Add(strNumber & ".0", UCase(strSplit(UBound(strSplit))))
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                Next
            End If
            Dim PaintNotesCount As Integer = HT_PaintNotes.Keys.Count
            For Each Item As Object In HT_PaintNotes.Keys
                If PaintNotesCount < Val(Item) Then
                    PaintNotesCount = Val(Item)
                End If
            Next
            iCount = 1
            For iCount = 1 To PaintNotesCount
                If HT_PaintNotes.ContainsKey(iCount.ToString & ".0") = True Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strPaintPackagingNotes = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strPaintPackagingNotes & iCount.ToString & ". " & UCase(Trim(HT_PaintNotes((iCount.ToString & ".0")))) & vbNewLine
                End If
            Next
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.iPaintingNotesCount = HT_PaintNotes.Keys.Count
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneralNotes = "BORE " & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString, "0.00").ToString & " X " & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, "0.00").ToString & " STROKE " & vbNewLine
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneralNotes = Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString, "0.00").ToString & "BORE X " & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrokeLength, "0.00").ToString & " STROKE " & vbNewLine          '09_05_2011  RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneralNotes = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneralNotes & "MAX. WORKING PRESSURE " & Format(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WorkingPressure, "0").ToString & " PSI" & vbNewLine
            If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ColumnLoadDeratePressure) <> "" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ColumnLoadDeratePressure) <> "N/A" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneralNotes = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneralNotes & "MAX. WORKING PRESSURE " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ColumnLoadDeratePressure & " PSI FULL EXTENSION" & vbNewLine
            End If
            '25_03_2010     RAGAVA   Commented
            '' ''If Trim(ofrmContractDetails.txtlPartCode.Text) <> "" AndAlso Trim(ofrmContractDetails.txtlPartCode.Text) <> "N/A" Then
            '' ''    GeneralNotes = GeneralNotes & "CUSTOMER PART # " & Trim(ofrmContractDetails.txtlPartCode.Text)
            '' ''End If
        Catch ex As Exception
            MsgBox("Error in Retrieving Notes")
        End Try
    End Sub
    '25_03_2010     RAGAVA  Till   Here

    Public Sub getBackFunctionality()
        Me.Hide()
    End Sub

    Private Sub btnNumberNotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNumberNotes.Click
        Try
            Dim iCount As Integer = 1
            If ChkPins.Checked = True Then
                txtPins.Text = iCount.ToString
                iCount += 1
            Else
                txtPins.Clear()
            End If
            txtRetractedLength.Text = iCount.ToString
            iCount += 1
            txtExtenedLength.Text = iCount.ToString
            iCount += 1
            txtRodDiameter.Text = iCount.ToString
            iCount += 1
            If chkSetScrew.Checked = True Then
                txtSetScrew.Text = iCount.ToString
                iCount += 1
            Else
                txtSetScrew.Clear()
            End If

            '25_06_2010   RAGAVA
            If chkGreaseZerc.Checked = True Then
                txtGreaseZerc.Text = iCount.ToString
                iCount += 1
            Else
                txtGreaseZerc.Clear()
            End If
            If chkInstallStrokeControl.Checked = True Then
                txtInstallStrokeControl.Text = iCount.ToString
                iCount += 1
            Else
                txtInstallStrokeControl.Clear()
            End If
            'Till   Here

            If chk100AirTest.Checked = True Then
                txtAirTest.Text = iCount.ToString
                iCount += 1
            Else
                txtAirTest.Clear()
            End If
            If chk100OilTest.Checked = True Then
                txtOilTest.Text = iCount.ToString
                iCount += 1
            Else
                txtOilTest.Clear()
            End If

            '25_06_2010   RAGAVA
            If chkByPass.Checked = True Then
                txtByPass.Text = iCount.ToString
                iCount += 1
            Else
                txtByPass.Clear()
            End If
            'Till   Here

            If ChkRephaseExtension.Checked = True Then
                txtRephaseOnExtension.Text = iCount.ToString
                iCount += 1
            Else
                txtRephaseOnExtension.Clear()
            End If
            If ChkRephaseRetraction.Checked = True Then
                txtRephaseOnRetraction.Text = iCount.ToString
                iCount += 1
            Else
                txtRephaseOnRetraction.Clear()
            End If
            '10-03-14 vamsi start
            If chkCushionsonExtension.Checked = True Then
                txtCushionsOnExtension.Text = iCount.ToString
                iCount += 1
            Else
                txtCushionsOnExtension.Clear()
            End If
            If chkCushionsOnRetraction.Checked = True Then
                txtCusionsOnRetraction.Text = iCount.ToString
                iCount += 1
            Else
                txtCusionsOnRetraction.Clear()
            End If

            'End

            '25_06_2010   RAGAVA
            If chkInstallAdaptorFitting.Checked = True Then
                txtInstallAdaptorFitting.Text = iCount.ToString
                iCount += 1
            Else
                txtInstallAdaptorFitting.Clear()
            End If
            If chkOrifice.Checked = True Then
                txtOrifice.Text = iCount.ToString
                iCount += 1
            Else
                txtOrifice.Clear()
            End If
            'Till   Here

            'If chkInstallSetScrewAfterOilTest.Checked = True Then  vamsi 12th august 2013
            '    txtInstallSetScrewAfterOilTesting.Text = iCount.ToString
            '    iCount += 1
            'Else
            '    txtInstallSetScrewAfterOilTesting.Clear()
            'End If
            'vamsi 12th August 2013 start
            If chkNoLabelOnCylinder.Checked = True Then
                txtNoLabelOnCylinder.Text = iCount.ToString
                iCount += 1
            Else
                txtNoLabelOnCylinder.Clear()
            End If

            'till  here

            '25_06_2010   RAGAVA
            If chkPlugBreatherForPainting.Checked = True Then
                txtPlugBreatherForPainting.Text = iCount.ToString
                iCount += 1
            Else
                txtPlugBreatherForPainting.Clear()
            End If
            If chkInstallBreather.Checked = True Then
                txtInstallBreather.Text = iCount.ToString
                iCount += 1
            Else
                txtInstallBreather.Clear()
            End If
            'Till   Here

            If chkStampCustomerPartandDate.Checked = True Then
                txtStampCustomerPartandDate.Text = iCount.ToString
                iCount += 1
            Else
                txtStampCustomerPartandDate.Clear()
            End If
            If chkStampCustomerPartOnTube.Checked = True Then
                txtStampCustomerPart.Text = iCount.ToString
                iCount += 1
            Else
                txtStampCustomerPart.Clear()
            End If
            If ChkStampCountryOfOrigin.Checked = True Then
                txtStampCountry.Text = iCount.ToString
                iCount += 1
            Else
                txtStampCountry.Clear()
            End If
            If ChkRodMaterial.Checked = True Then
                txtRodMaterialNitroSteel.Text = iCount.ToString
                iCount += 1
            Else
                txtRodMaterialNitroSteel.Clear()
            End If
            If ChkInstallHardenedBushings.Checked = True Then
                txtInstallSteelPlugs.Text = iCount.ToString
                iCount += 1
            Else
                txtInstallSteelPlugs.Clear()
            End If
            If ChkHardenedBushingsRodEnd.Checked = True Then
                txtInstallHardenedBushingsRodEnd.Text = iCount.ToString
                iCount += 1
            Else
                txtInstallHardenedBushingsRodEnd.Clear()
            End If
            If ChkHardenedBushingsBaseEnd.Checked = True Then
                txtInstallHardenedBushingsBaseEnd.Text = iCount.ToString
                iCount += 1
            Else
                txtInstallHardenedBushingsBaseEnd.Clear()
            End If
            If ChkAssemblyStopTube.Checked = True Then
                txtAssemblyStopTube.Text = iCount.ToString
                iCount += 1
            Else
                txtAssemblyStopTube.Clear()
            End If
            If chkAssemblyNotes.Checked = True Then
                Dim strRichTextBox1Text As String = String.Empty
                For Each str As String In RichTextBox1.Lines
                    If Trim(strRichTextBox1Text) <> "" Then
                        strRichTextBox1Text = strRichTextBox1Text & vbNewLine
                    End If
                    If str.IndexOf("}") <> -1 Then
                        If str.IndexOf("}") > 0 Then
                            str = str.Replace(str.Substring(0, str.IndexOf("}")), iCount.ToString)
                        Else
                            str = str.Insert(0, iCount.ToString)
                        End If
                    Else
                        str = iCount.ToString & "} " & str
                    End If
                    iCount += 1
                    strRichTextBox1Text = strRichTextBox1Text & str
                Next
                RichTextBox1.Text = strRichTextBox1Text
            End If


            'Paint Notes Numbering
            iCount = 1

            '09_05_2011  RAGAVA
            If chkMaskPerBOM.Checked = True Then
                txtMaskPerBOM.Text = iCount.ToString
                iCount += 1
            Else
                txtMaskPerBOM.Clear()
            End If
            'Till  Here

            'vamsi 12th August 2013 start
            'If ChkMaskBushings.Checked = True Then
            '    txtMaskBushings.Text = iCount.ToString
            '    iCount += 1
            'Else
            '    txtMaskBushings.Clear()
            'End If

            'till here

            If chkNoPaintOrPrimer.Checked = True Then
                txtNoPaintOrPrimer.Text = iCount.ToString
                iCount += 1
            Else
                txtNoPaintOrPrimer.Clear()
            End If
            If ChkPrime.Checked = True Then
                txtPrime.Text = iCount.ToString
                iCount += 1
            Else
                txtPrime.Clear()
            End If
            If ChkPaint.Checked = True Then
                txtPaint.Text = iCount.ToString
                iCount += 1
            Else
                txtPaint.Clear()
            End If

            'vamsi  10-03-2014
            If chkREMOVEPLUGANDINSTALLBREATHERPLUG.Checked = True Then
                txtREMOVEPLUGANDINSTALLBREATHERPLUG.Text = iCount.ToString
                iCount += 1
            Else
                txtREMOVEPLUGANDINSTALLBREATHERPLUG.Clear()
            End If
            'end

            If chkAffixLabel.Checked = True Then
                txtAffixLabel.Text = iCount.ToString
                iCount += 1
            Else
                txtAffixLabel.Clear()
            End If

            '25_06_2010   RAGAVA
            If chkCleanCylinder.Checked = True Then
                txtCleanCylinder.Text = iCount.ToString
                iCount += 1
            Else
                txtCleanCylinder.Clear()
            End If
            If chkBoxMustBeLined.Checked = True Then
                txtBoxMustBeLined.Text = iCount.ToString
                iCount += 1
            Else
                txtBoxMustBeLined.Clear()
            End If
            If chkBagMustBeTightlySealed.Checked = True Then
                txtBagMustBeTightlySealed.Text = iCount.ToString
                iCount += 1
            Else
                txtBagMustBeTightlySealed.Clear()
            End If
            'Till  Here

            If chkInstallPinAndClips.Checked = True Then
                txtInstallPinandClips.Text = iCount.ToString
                iCount += 1
            Else
                txtInstallPinandClips.Clear()
            End If

            If ChkIncludePinkitPerBom.Checked = True Then      'priyanka
                txtIncludePinkitPerBom.Text = iCount.ToString
                iCount += 1
            Else
                txtIncludePinkitPerBom.Clear()
            End If


            'vamsi 12th August 2013 start
            'If chkPackCylinderInPlasticBag.Checked = True Then
            '    txtPackCylinder.Text = iCount.ToString
            '    iCount += 1
            'Else
            '    txtPackCylinder.Clear()
            'End If
            'till here   
            'vamsi 12th August 2013 start

            If chkNoLabelOnCylinder.Checked = True Then
                txtNoLabelOnCylinder.Text = iCount.ToString()
                iCount += 1
            Else
                txtNoLabelOnCylinder.Text = ""
            End If
            'till here   
            txtPackagePerSOP.Text = iCount.ToString
            iCount += 1

            'If chkSingleActingPullAppliction.Checked = True Then          'priyanka
            '    txtSingleActingPullApplication.Text = iCount.ToString()
            '    iCount += 1
            'Else
            '    txtSingleActingPullApplication.Clear()
            'End If

            'If chkSingleActingPushApplication.Checked = True Then           'priyanka
            '    txtSingleActingPushApplication.Text = iCount.ToString()
            '    iCount += 1
            'Else
            '    txtSingleActingPushApplication.Clear()
            'End If

            If chkPaintingNote.Checked = True Then
                Dim strRichTextBox2Text As String = String.Empty
                For Each str As String In RichTextBox2.Lines
                    If Trim(strRichTextBox2Text) <> "" Then
                        strRichTextBox2Text = strRichTextBox2Text & vbNewLine
                    End If
                    If str.IndexOf("}") <> -1 Then
                        If str.IndexOf("}") > 0 Then
                            str = str.Replace(str.Substring(0, str.IndexOf("}")), iCount.ToString)
                        Else
                            str = str.Insert(0, iCount.ToString)
                        End If
                    Else
                        str = iCount.ToString & "} " & str
                    End If
                    iCount += 1
                    strRichTextBox2Text = strRichTextBox2Text & str
                Next
                RichTextBox2.Text = strRichTextBox2Text
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub chkAssemblyNotes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAssemblyNotes.CheckedChanged
        If sender.Checked = True Then
            RichTextBox1.Enabled = True
        Else
            RichTextBox1.Enabled = False
        End If
    End Sub

    Private Sub chkPaintingNote_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPaintingNote.CheckedChanged
        If sender.Checked = True Then
            RichTextBox2.Enabled = True
        Else
            RichTextBox2.Enabled = False
        End If
    End Sub

    Private Sub chkPackPinsAndClipsInPlasticBag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            'TODO: ANUP 21-07-2010 02-15pm
            ObjClsWeldedCylinderFunctionalClass.IsPackPinsAndClipsInPlasticBagChecked = True
            chkInstallPinAndClips.Checked = False
            txtInstallPinandClips.Clear()
        Else
            'TODO: ANUP 21-07-2010 02-15pm
            ObjClsWeldedCylinderFunctionalClass.IsPackPinsAndClipsInPlasticBagChecked = False
        End If
    End Sub

    Private Sub chkInstallPinAndClips_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInstallPinAndClips.CheckedChanged
        If sender.Checked = True Then
            txtInstallPinandClips.Enabled = True
            ChkIncludePinkitPerBom.Checked = False
            ChkIncludePinkitPerBom.Enabled = True
            txtIncludePinkitPerBom.Enabled = False
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnInstallPinsandClips_Checked = True           '06_06_2011   RAGAVA
        Else
            txtInstallPinandClips.Enabled = False
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinsYesOrNo = "Yes" Then
                ChkIncludePinkitPerBom.Checked = True
            End If

            ' txtIncludePinkitPerBom.Enabled = False
            txtInstallPinandClips.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnInstallPinsandClips_Checked = False           '06_06_2011   RAGAVA
        End If
    End Sub

    Private Sub ChkIncludePinkitPerBom_CheckedChanged_1(sender As System.Object, e As System.EventArgs) Handles ChkIncludePinkitPerBom.CheckedChanged 'priyanka
        If sender.Checked = True Then
            txtIncludePinkitPerBom.Enabled = True
            chkInstallPinAndClips.Checked = False
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnIncludepinKitPerBom_Checked = True
        Else
            '  chkInstallPinAndClips.Checked = True
            txtIncludePinkitPerBom.Enabled = False
            txtIncludePinkitPerBom.Clear()
            ChkIncludePinkitPerBom.Checked = False
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinsYesOrNo = "Yes" Then
                chkInstallPinAndClips.Checked = True
            End If

            ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnIncludepinKitPerBom_Checked = False
            End If
    End Sub

    Private Sub ChkPins_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPins.CheckedChanged
        If sender.Checked = True Then
            txtPins.Enabled = True
        Else
            txtPins.Enabled = False
            txtPins.Clear()
        End If
    End Sub

    Private Sub ChkRetractedLength_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRetractedLength.CheckedChanged
        If sender.Checked = True Then
            txtRetractedLength.Enabled = True
        Else
            txtRetractedLength.Enabled = False
            txtRetractedLength.Clear()
        End If
    End Sub

    Private Sub ChkExtendedLength_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkExtendedLength.CheckedChanged
        If sender.Checked = True Then
            txtExtenedLength.Enabled = True
        Else
            txtExtenedLength.Enabled = False
            txtExtenedLength.Clear()
        End If
    End Sub

    Private Sub ChkRodDiameter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRodDiameter.CheckedChanged
        If sender.Checked = True Then
            txtRodDiameter.Enabled = True
        Else
            txtRodDiameter.Enabled = False
            txtRodDiameter.Clear()
        End If
    End Sub

    Private Sub ChkPorts_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSetScrew.CheckedChanged
        If sender.Checked = True Then
            txtSetScrew.Enabled = True
        Else
            txtSetScrew.Enabled = False
            txtSetScrew.Clear()
        End If
    End Sub
 Private Sub chk100AirTest_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chk100AirTest.CheckedChanged
        If sender.Checked = True Then
            txtAirTest.Enabled = True
        Else
            txtAirTest.Enabled = False
            txtAirTest.Clear()
        End If
    End Sub

    Private Sub chk100OilTest_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk100OilTest.CheckedChanged
        If sender.Checked = True Then
            txtOilTest.Enabled = True
        Else
            txtOilTest.Enabled = False
            txtOilTest.Clear()
        End If
    End Sub

    Private Sub ChkRephaseExtension_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRephaseExtension.CheckedChanged
        If sender.Checked = True Then
            txtRephaseOnExtension.Enabled = True
        Else
            txtRephaseOnExtension.Enabled = False
            txtRephaseOnExtension.Clear()
        End If
    End Sub

    Private Sub ChkRephaseRetraction_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRephaseRetraction.CheckedChanged
        If sender.Checked = True Then
            txtRephaseOnRetraction.Enabled = True
        Else
            txtRephaseOnRetraction.Enabled = False
            txtRephaseOnRetraction.Clear()
        End If
    End Sub

    'Private Sub chkInstallStrokeControl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInstallSetScrewAfterOilTest.CheckedChanged
    '    If sender.Checked = True Then
    '        txtInstallSetScrewAfterOilTesting.Enabled = True   vamsi 12th august 2013
    '    Else
    '        txtInstallSetScrewAfterOilTesting.Enabled = False
    '        txtInstallSetScrewAfterOilTesting.Clear()
    '    End If
    'End Sub

    Private Sub chkStampCustomerPartandDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStampCustomerPartandDate.CheckedChanged
        If sender.Checked = True Then
            txtStampCustomerPartandDate.Enabled = True
        Else
            txtStampCustomerPartandDate.Enabled = False
            txtStampCustomerPartandDate.Clear()
        End If
    End Sub

    Private Sub chkStampCustomerPartOnTube_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStampCustomerPartOnTube.CheckedChanged
        If sender.Checked = True Then
            txtStampCustomerPart.Enabled = True
        Else
            txtStampCustomerPart.Enabled = False
            txtStampCustomerPart.Clear()
        End If
    End Sub

    Private Sub ChkStampCountryOfOrigin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkStampCountryOfOrigin.CheckedChanged
        If sender.Checked = True Then
            txtStampCountry.Enabled = True
        Else
            txtStampCountry.Enabled = False
            txtStampCountry.Clear()
        End If
    End Sub

    Private Sub ChkRodMaterial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            txtRodMaterialNitroSteel.Enabled = True
        Else
            txtRodMaterialNitroSteel.Enabled = False
            txtRodMaterialNitroSteel.Clear()
        End If
    End Sub

    Private Sub ChkInstallSteelPlugs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkInstallHardenedBushings.CheckedChanged
        If sender.Checked = True Then
            txtInstallSteelPlugs.Enabled = True
        Else
            txtInstallSteelPlugs.Enabled = False
            txtInstallSteelPlugs.Clear()
        End If
    End Sub

    Private Sub ChkHardenedBushingsRodClevisEnd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkHardenedBushingsRodEnd.CheckedChanged
        If sender.Checked = True Then
            txtInstallHardenedBushingsRodEnd.Enabled = True
        Else
            txtInstallHardenedBushingsRodEnd.Enabled = False
            txtInstallHardenedBushingsRodEnd.Clear()
        End If
    End Sub

    Private Sub ChkHardenedBushingsClevisCapEnd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkHardenedBushingsBaseEnd.CheckedChanged
        If sender.Checked = True Then
            txtInstallHardenedBushingsBaseEnd.Enabled = True
        Else
            txtInstallHardenedBushingsBaseEnd.Enabled = False
            txtInstallHardenedBushingsBaseEnd.Clear()
        End If
    End Sub

    Private Sub chkAffixLabelToBag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Checked = True Then
            txtAffixLabel.Clear()
            txtAffixLabel.Enabled = False
            chkAffixLabel.Checked = False
        End If
    End Sub

    Private Sub ChkAssemblyStopTube_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAssemblyStopTube.CheckedChanged
        If sender.Checked = True Then
            txtAssemblyStopTube.Enabled = True
        Else
            txtAssemblyStopTube.Enabled = False
            txtAssemblyStopTube.Clear()
        End If
    End Sub
    'vamsi 12th august 2013
    'Private Sub ChkMaskBushings_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMaskBushings.CheckedChanged
    '    If sender.Checked = True Then

    '        txtMaskBushings.Enabled = False '24TH MAY 2013
    '    Else
    '        txtMaskBushings.Enabled = False
    '        txtMaskBushings.Clear()
    '    End If
    'End Sub


    Private Sub ChkPrime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPrime.CheckedChanged
        If sender.Checked = True Then
            txtPrime.Enabled = True
        Else
            txtPrime.Enabled = False
            txtPrime.Clear()
        End If

    End Sub

    Private Sub ChkPaint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkPaint.CheckedChanged
        If sender.Checked = True Then
            txtPaint.Enabled = True
        Else
            txtPaint.Enabled = False
            txtPaint.Clear()
        End If
    End Sub

    Private Sub chkAffixValueLineLabel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAffixLabel.CheckedChanged
        If sender.Checked = True Then
            txtAffixLabel.Enabled = True
        Else
            txtAffixLabel.Enabled = False
            txtAffixLabel.Clear()
        End If
    End Sub

    'Private Sub chkPackCylinderInPlasticBag_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPackCylinderInPlasticBag.CheckedChanged
    '    If sender.Checked = True Then
    '        txtPackCylinder.Enabled = True
    '    Else
    '        txtPackCylinder.Enabled = False
    '        txtPackCylinder.Clear()
    '    End If
    'End Sub

    Private Sub chkShipLabelLooseWithCylinder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPackagePerSOP.CheckedChanged
        If sender.Checked = True Then
            txtAffixLabel.Clear()
            txtAffixLabel.Enabled = False
            chkAffixLabel.Checked = False
            txtPackagePerSOP.Enabled = True 'vamsi 09-06-14
        Else
            txtPackagePerSOP.Enabled = False
        End If
    End Sub
    Private Sub chkSingleActingPullAppliction_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSingleActingPullAppliction.CheckedChanged
        If sender.Checked = True Then
            'txtSingleActingPullApplication.Enabled = True
            chkSingleActingPushApplication.Checked = False
        Else
            'txtSingleActingPullApplication.Enabled = False

            'txtSingleActingPullApplication.Clear()
        End If
    End Sub
    Private Sub chkSingleActingPushApplication_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSingleActingPushApplication.CheckedChanged
        If sender.Checked = True Then
            'txtSingleActingPushApplication.Enabled = True
            chkSingleActingPullAppliction.Checked = False
        Else
            'txtSingleActingPushApplication.Enabled = False
            ' txtSingleActingPushApplication.Clear()
        End If
    End Sub

    '19_03_2010   RAGAVA
    Public Function validateForm(ByVal FormName As Form, ByRef ErrorMessage As String) As Control
        validateForm = Nothing
        Dim ctl As GroupBox
        Dim CtrlGrp As GroupBox
        Try

            If FormName.Name.IndexOf("frmGenerate") <> -1 Then
                For Each objControl As Object In FormName.Controls
                    If TypeOf (objControl) Is GroupBox Then
                        ctl = CType(objControl, GroupBox)

                        Dim AL_RtxBxNumbering As New ArrayList
                        For Each ctlRichtxtBox1 As Control In ctl.Controls
                            If TypeOf (ctlRichtxtBox1) Is GroupBox Then
                                CtrlGrp = CType(ctlRichtxtBox1, GroupBox)
                                For Each ctlRichtxtBox As Control In CtrlGrp.Controls
                                    If TypeOf (ctlRichtxtBox) Is RichTextBox Then
                                        Dim CtrlRich As RichTextBox = CType(ctlRichtxtBox, RichTextBox)
                                        For Each str As String In CtrlRich.Lines
                                            If Trim(str).IndexOf("}") < 1 Then
                                                ErrorMessage = "Oops! Numbering is not done... Please number the notes to proceed" + vbNewLine
                                                validateForm = CtrlRich
                                                Return validateForm
                                            End If
                                            If AL_RtxBxNumbering.Count > 0 Then
                                                If AL_RtxBxNumbering.Contains(str.Substring(0, str.IndexOf("}"))) = True Then
                                                    ErrorMessage = "Numbering sequence is not unique" + vbNewLine
                                                    validateForm = ctlRichtxtBox
                                                    Return validateForm
                                                End If
                                            End If
                                            AL_RtxBxNumbering.Add(str.Substring(0, str.IndexOf("}")))
                                        Next
                                    End If
                                Next
                            End If
                        Next
                        For Each ctl1 As Control In ctl.Controls
                            Dim ctlObject As Control
                            If TypeOf (ctl1) Is TextBox Then
                                ctlObject = CType(ctl1, TextBox)
                                If Trim(ctlObject.Text) <> "" Then
                                    Dim ctlObject1 As Control
                                    For Each ctl2 As Control In ctl.Controls
                                        If TypeOf (ctl2) Is TextBox Then
                                            ctlObject1 = CType(ctl2, TextBox)
                                            If Trim(ctlObject.Name) <> Trim(ctlObject1.Name) Then
                                                If (Trim(ctlObject.Text) = Trim(ctlObject1.Text)) Or (AL_RtxBxNumbering.Contains(Trim(ctlObject.Text))) Then           '20_10_2009  ragava
                                                    ErrorMessage = "Numbering sequence is not unique" + vbNewLine
                                                    validateForm = ctl2
                                                    Return validateForm
                                                End If
                                            End If
                                        End If
                                    Next
                                Else
                                    If ctlObject.Enabled = True Then
                                        ErrorMessage = "Oops! Numbering is not done... Please number the notes to proceed" + vbNewLine
                                        validateForm = ctlObject
                                        Return validateForm
                                    End If
                                End If
                            End If
                        Next
                    End If
                Next
                Return validateForm
            End If
        Catch ex As Exception
        End Try
    End Function

    Private Sub frmGenerate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        ManualLoad()   '19_03_2010   RAGAVA

    End Sub
    '25_06_2010   RAGAVA
    Private Sub chkByPass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkByPass.CheckedChanged
        If sender.Checked = True Then
            txtByPass.Enabled = True
        Else
            txtByPass.Enabled = False
            txtByPass.Clear()
        End If
    End Sub
    '25_06_2010   RAGAVA
    Private Sub chkInstallAdaptorFitting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInstallAdaptorFitting.CheckedChanged
        If sender.Checked = True Then
            txtInstallAdaptorFitting.Enabled = True
        Else
            txtInstallAdaptorFitting.Enabled = False
            txtInstallAdaptorFitting.Clear()
        End If
    End Sub
    '25_06_2010   RAGAVA
    Private Sub chkOrifice_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOrifice.CheckedChanged
        If sender.Checked = True Then
            txtOrifice.Enabled = True
        Else
            txtOrifice.Enabled = False
            txtOrifice.Clear()
        End If
    End Sub
    '25_06_2010   RAGAVA
    Private Sub chkPlugBreatherForPainting_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPlugBreatherForPainting.CheckedChanged
        If sender.Checked = True Then
            txtPlugBreatherForPainting.Enabled = True
        Else
            txtPlugBreatherForPainting.Enabled = False
            txtPlugBreatherForPainting.Clear()
        End If
    End Sub
    '25_06_2010   RAGAVA
    Private Sub chkInstallBreather_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInstallBreather.CheckedChanged
        If sender.Checked = True Then
            txtInstallBreather.Enabled = True
        Else
            txtInstallBreather.Enabled = False
            txtInstallBreather.Clear()
        End If
    End Sub
    '25_06_2010   RAGAVA
    Private Sub chkNoPaintOrPrimer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNoPaintOrPrimer.CheckedChanged
        If sender.Checked = True Then
            txtNoPaintOrPrimer.Enabled = True
        Else
            txtNoPaintOrPrimer.Enabled = False
            txtNoPaintOrPrimer.Clear()
        End If
    End Sub
    '25_06_2010   RAGAVA
    Private Sub chkCleanCylinder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCleanCylinder.CheckedChanged
        If sender.Checked = True Then
            txtCleanCylinder.Enabled = True
        Else
            txtCleanCylinder.Enabled = False
            txtCleanCylinder.Clear()
        End If
    End Sub
    '25_06_2010   RAGAVA
    Private Sub chkBoxMustBeLined_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxMustBeLined.CheckedChanged
        If sender.Checked = True Then
            txtBoxMustBeLined.Enabled = True
        Else
            txtBoxMustBeLined.Enabled = False
            txtBoxMustBeLined.Clear()
        End If
    End Sub
    '25_06_2010   RAGAVA
    Private Sub chkBagMustBeTightlySealed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBagMustBeTightlySealed.CheckedChanged
        If sender.Checked = True Then
            txtBagMustBeTightlySealed.Enabled = True
        Else
            txtBagMustBeTightlySealed.Enabled = False
            txtBagMustBeTightlySealed.Clear()
        End If
    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, LabelGradient5, LabelGradient4, LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(LabelGradient1)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient15)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient16)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient17)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient18)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient19)

    End Sub


    Private Sub chkMaskPerBOM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMaskPerBOM.CheckedChanged
        If sender.Checked = True Then
            txtMaskPerBOM.Enabled = True
        Else
            txtMaskPerBOM.Enabled = False
            txtMaskPerBOM.Clear()
        End If
    End Sub

    Private Sub chkCushionsonExtension_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCushionsonExtension.CheckedChanged
        If sender.checked = True Then
            txtCushionsOnExtension.Enabled = True
        Else
            txtCushionsOnExtension.Enabled = False
            txtCushionsOnExtension.Clear()
        End If
    End Sub

   


    Private Sub chkNoLabelOnCylinder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNoLabelOnCylinder.CheckedChanged
        If sender.checked = True Then
            txtNoLabelOnCylinder.Enabled = True
        Else
            txtNoLabelOnCylinder.Enabled = False
            txtNoLabelOnCylinder.Clear()
        End If

    End Sub
    'vamsi 12th august 2013
    Private Sub rbNoLabelRequired_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNoLabelRequired.CheckedChanged
        If sender.checked = True Then
            chkNoLabelOnCylinder.Checked = True
            txtNoLabelOnCylinder.Text = ""
            txtNoLabelOnCylinder.Enabled = True
            txtAffixLabel.Enabled = False
            txtAffixLabel.Text = ""
            chkAffixLabel.Enabled = False
            chkAffixLabel.Checked = False
        Else
            rbYesLabelRequired.Checked = True
            chkNoLabelOnCylinder.Checked = False
            chkNoLabelOnCylinder.Enabled = False
            txtNoLabelOnCylinder.Enabled = False
            txtAffixLabel.Enabled = True
            txtAffixLabel.Text = ""
            chkAffixLabel.Enabled = False
            chkAffixLabel.Checked = True

        End If
        'rbNoLabelRequired.Checked = False
        'chkNoLabelOnCylinder.Enabled = True
        'chkNoLabelOnCylinder.Checked = True
        'txtNoLabelOnCylinder.Enabled = True
        'txtNoLabelOnCylinder.Text = ""
        'txtAffixLabel.Enabled = False
        'txtAffixLabel.Text = ""
        'chkAffixLabel.Enabled = False
        'chkAffixLabel.Checked = False
    End Sub
    'vamsi 12th august 2013
    Private Sub rbYesLabelRequired_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbYesLabelRequired.CheckedChanged
        chkNoLabelOnCylinder.Checked = False
        chkNoLabelOnCylinder.Enabled = False
        txtNoLabelOnCylinder.Enabled = False
        'If sender.checked = True Then
        '    If ChkPrime.Checked Or ChkPaint.Checked And rbYesBagRequired.Checked Then
        '        If chkNoLabelOnCylinder.Checked Then
        '            txtAffixLabel.Enabled = True
        '            txtAffixLabel.Text = ""
        '            chkAffixLabel.Enabled = True
        '            chkAffixLabel.Checked = True
        '            chkNoLabelOnCylinder.Checked = False
        '            txtNoLabelOnCylinder.Enabled = False
        '            chkNoLabelOnCylinder.Checked = False
        '            txtNoLabelOnCylinder.Text = ""
        '        End If
        '    Else
        '        rbNoLabelRequired.Checked = True
        '    End If
        'End If

    End Sub

    Public SaveDetails As Boolean
    Public ValidationFailedNotification As Boolean = False

    Private Sub SaveDetailsAndContinueForNextCyl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveDetailsAndContinueForNextCyl.Click

        If MessageBox.Show("Saving current Design" + vbNewLine + "Click ok to save and proceed", "Save Notification", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
            SaveDetails = True
            ValidationFailedNotification = False
            Me.GenerateModel()
            If ValidationFailedNotification = False Then
                Try
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.SetCodeStatus()
                Catch ex As Exception
                End Try
            End If
            EndProcess()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub create_sf_sheet() 'safety factor by praveen
        ObjClsWeldedCylinderFunctionalClass.CloseExcel(True)
        Dim FileName As String = "K:\Design Engineering Files\Design review checklist & SF calculation sheet\SF calculation sheet\" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber + " Safety Factor Calculation.xls"
        ObjClsWeldedCylinderFunctionalClass.ObjClsExcelClass.connectToExcel()
        ObjClsWeldedCylinderFunctionalClass.ObjClsExcelClass.BreakXlLink("C:\WELD_DESIGN_TABLES\Safety Factor Calculator.xls", "C:\WELD_DESIGN_TABLES\WELD_GUI_PARAMETERS.xls")
        ObjClsWeldedCylinderFunctionalClass.CloseExcel(True)
        SaveSF(FileName)
        'ObjClsWeldedCylinderFunctionalClass.ObjClsExcelClass.SaveSfSheet(FileName)

    End Sub
   
    Private Sub SaveSF(ByVal FileName) 'safety factor by praveen
        Try
            If Not Directory.Exists("K:\Design Engineering Files\Design review checklist & SF calculation sheet\SF calculation sheet\") Then
                Directory.CreateDirectory("K:\Design Engineering Files\Design review checklist & SF calculation sheet\SF calculation sheet\")
            End If
            If File.Exists(FileName) = True Then
                File.Delete(FileName)
                File.Copy("C:\WELD_DESIGN_TABLES\Safety Factor Calculator.xls", FileName)
            Else
                File.Copy("C:\WELD_DESIGN_TABLES\Safety Factor Calculator.xls", FileName)
            End If
        Catch ex As Exception

        End Try

    End Sub


    'Public Function SaveCodeToBatchRun() As Boolean
    '    SaveCodeToBatchRun = True
    '    Dim StrQuery As String = String.Empty
    '    Dim falseVal As Boolean = False
    '    Try
    '        StrQuery = "Insert into BatchRun values('" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CustomerName_ContractDetails.ToString & "'," & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString() & ",'" & falseVal & "')"

    '        SaveCodeToBatchRun = MonarchConnectionObject.ExecuteQuery(StrQuery)

    '        If Not SaveCodeToBatchRun Then
    '            SaveCodeToBatchRun = False

    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Function

    Public LogFilePath As String = "C:\WELDED_TESTING\BatchRunLogs"
    Public OldName As String = "\BatchRun_Log.txt"
    Public LastCylinderGenrtNotify As Boolean = False
    Public LastCylinderDsgnNotify As Boolean = False

    Public Sub GenerateMultiple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateMultiple.Click
        Try
            'ObjClsWeldedCylinderFunctionalClass.ObjFrmGenerate.ParentForm.WindowState = FormWindowState.Minimized
            If ObjClsWeldedCylinderFunctionalClass.MultiGenerate = True Then
                ObjClsWeldedCylinderFunctionalClass.ObjFrmGenerate.ParentForm.WindowState = FormWindowState.Minimized
                Me.GenerateModel()
                'MsgBox("Succ")
                Try
                    Me.deleteBatchrunRow()
                Catch ex As Exception
                End Try
                'Try
                '    LogProcess()
                'Catch ex As Exception
                'End Try
                If ObjClsWeldedCylinderFunctionalClass.RowCount - 1 = 0 Then
                    LastCylinderGenrtNotify = True
                End If
                EndProcess()
            Else
                LastCylinderDsgnNotify = True
                SaveDetailsAndContinueForNextCyl.PerformClick()
                'EndProcess()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub LogProcess()
        If Directory.Exists(LogFilePath) Then
            If LastCylinderDsgnNotify = True Then
                CreateLogFile()
                Exit Sub
            End If
            If LastCylinderDsgnNotify <> True Then
                WriteLog()
            End If
        Else
            Directory.CreateDirectory(LogFilePath)
            CreateLogFile()
            WriteLog()
        End If
    End Sub

    Public Sub CreateLogFile()
        Dim writer As FileStream = Nothing
        If File.Exists(LogFilePath + OldName) <> True Then
            writer = File.Create(LogFilePath + OldName)
            writer.Close()
        End If

    End Sub

    Public Sub WriteLog()
        Dim writer As StreamWriter
        writer = File.AppendText(LogFilePath + OldName)
        writer.WriteLine(vbNewLine)
        'writer.WriteLine("-----------------------------------------------------------")
        'writer.WriteLine(DateTime.Now.ToString("d MMM yyyy  HH:MM:s tt") + vbCrLf)
        writer.WriteLine("Customer: " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CustomerName_ContractDetails.ToString)
        writer.WriteLine("Code Number: " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString)
        writer.WriteLine("Model generated successfully at location " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AssyGeneratePath)
        writer.WriteLine("start time: " + ObjClsWeldedCylinderFunctionalClass.startTime + ", End time: " + DateTime.Now.ToString("HH:mmm:s tt"))
        writer.Close()
    End Sub



    Public Sub deleteBatchrunRow()

        Dim strDeleteQuery As String
        strDeleteQuery = "Delete top (1) from dbo.BatchRun"

        Try
            MonarchConnectionObject.ExecuteQuery(strDeleteQuery)
        Catch ex As Exception
        End Try
    End Sub

    'Public rowcount As Integer

    'Public Function BatchRunCount() As Integer
    '    Dim strquery As String = String.Empty

    '    strquery = "select COUNT( *) from BatchRun"
    '    Try
    '        rowcount = MonarchConnectionObject.GetValue(strquery)
    '        Return rowcount
    '    Catch ex As Exception

    '    End Try

    'End Function




    Public Sub EndProcess()
        If ValidationFailedNotification = False And SaveDetails = True And LastCylinderDsgnNotify = False Then
            ObjClsWeldedCylinderFunctionalClass.ObjFrmGenerate.ParentForm.WindowState = FormWindowState.Minimized
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.SaveCodeToBatchRun()
            BackgroundWorker_Notification.RunWorkerAsync(argument:="S")
            Threading.Thread.Sleep(2500)
            Application.Restart()
        ElseIf ValidationFailedNotification = False And SaveDetails = True And LastCylinderDsgnNotify = True Then
            ObjClsWeldedCylinderFunctionalClass.ObjFrmGenerate.ParentForm.WindowState = FormWindowState.Minimized
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.SaveCodeToBatchRun()
            Dim strquery As String = String.Empty
            strquery = "update batchrun set status='true' where status='false'"
            MonarchConnectionObject.ExecuteQuery(strquery)
            BackgroundWorker_Notification.RunWorkerAsync(argument:="R")
            LogProcess()
            Threading.Thread.Sleep(2500)
            Application.Restart()
        ElseIf ValidationFailedNotification = True And SaveDetails = True And LastCylinderDsgnNotify = False Then
            Exit Sub
        ElseIf ValidationFailedNotification = True And LastCylinderDsgnNotify = True Then
            ObjClsWeldedCylinderFunctionalClass.ObjFrmGenerate.ParentForm.WindowState = FormWindowState.Maximized
            Exit Sub
        ElseIf ObjClsWeldedCylinderFunctionalClass.MultiGenerate = True And LastCylinderGenrtNotify = False And ValidationFailedNotification = False Then
            LogProcess()
            Application.Restart()
        ElseIf ObjClsWeldedCylinderFunctionalClass.MultiGenerate = True And LastCylinderGenrtNotify = True And ValidationFailedNotification = False Then
            Try
                LogProcess()
                Dim newname As String = LogFilePath + "\BatchRun_Log_" + DateTime.Now.ToString("d MMM yyyy_HH;mm;s") + ".txt"
                FileSystem.Rename(LogFilePath + OldName, newname)
                Process.Start(newname)
            Catch ex As Exception
            End Try
            Application.Exit()
        End If
    End Sub

    Private Sub chkREMOVEPLUGANDINSTALLBREATHERPLUG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkREMOVEPLUGANDINSTALLBREATHERPLUG.CheckedChanged
        If sender.Checked = True Then
            txtREMOVEPLUGANDINSTALLBREATHERPLUG.Enabled = True
        Else
            txtREMOVEPLUGANDINSTALLBREATHERPLUG.Enabled = False
            txtREMOVEPLUGANDINSTALLBREATHERPLUG.Clear()
        End If

    End Sub

    Private Sub chkCushionsOnRetraction_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCushionsOnRetraction.CheckedChanged
        If sender.checked = True Then
            txtCusionsOnRetraction.Enabled = True
        Else
            txtCusionsOnRetraction.Enabled = False
            txtCusionsOnRetraction.Clear()
        End If
    End Sub


    'BatchRun
    Private Sub BackgroundWorker_Notification_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker_Notification.DoWork
        Dim notify As New NotificationWindow
        notify.Show()
        'notify.MdiParent = Me
        notify.BringToFront()
        Me.TopMost = True

        If e.Argument = "S" Then
            notify.Notification_Label.Text = "Design saved successfully, Please wait while application restarts for next cylindeer design"
        ElseIf e.Argument = "R" Then
            notify.Notification_Label.Text = "Please note application will restart for several times during the BatchRun process"
        End If
        notify.Refresh()
        'Threading.Thread.Sleep(2500)
        'notify.Dispose()
    End Sub

    Private Sub btnGenerateModel_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateModel.MouseHover
        Me.ToolTip1.ToolTipIcon = ToolTipIcon.Info
        Me.ToolTip1.SetToolTip(btnGenerateModel, "Generates model for the current Session")
    End Sub

    Private Sub SaveDetailsAndContinueForNextCyl_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveDetailsAndContinueForNextCyl.MouseHover
        Me.ToolTip1.ToolTipIcon = ToolTipIcon.Info
        Me.ToolTip1.SetToolTip(SaveDetailsAndContinueForNextCyl, "Saves current session details and restarts to take next session details")
    End Sub

    Private Sub btnGenerateMultiple_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateMultiple.MouseHover
        Me.ToolTip1.ToolTipIcon = ToolTipIcon.Info
        Me.ToolTip1.SetToolTip(btnGenerateMultiple, "Generates models for all saved sessions")
    End Sub

    Private Sub ChkbxBatchRun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkbxBatchRun.CheckedChanged
        If ChkbxBatchRun.Checked = True Then
            SaveDetailsAndContinueForNextCyl.Enabled = True
            btnGenerateMultiple.Enabled = True
        ElseIf ChkbxBatchRun.Checked = False Then
            SaveDetailsAndContinueForNextCyl.Enabled = False
            btnGenerateMultiple.Enabled = False
        End If
    End Sub

    Private Sub ChkbxBatchRun_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkbxBatchRun.MouseHover
        Me.ToolTip1.ToolTipIcon = ToolTipIcon.Info
        Me.ToolTip1.SetToolTip(ChkbxBatchRun, "Check to enable BatchRun controls")
    End Sub
End Class

