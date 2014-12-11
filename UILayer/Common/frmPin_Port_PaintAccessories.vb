
Imports IFLBaseDataLayer
Imports IFLCommonLayer

Public Class frmPin_Port_PaintAccessories

#Region "Private Variables"

    Private _strPinMaterial As String
    Private _dblWorkingLengthCalculation_BaseEnd As Double
    Private _dblWorkingLengthCalculation_RodEnd As Double
    Public _dblPinHoleSize_BaseEnd As Double '21-11-14 vamsi made public
    Public _dblPinHoleSize_RodEnd As Double '21-11-14 vamsi made public
    Private _strPortSize_RodEnd As String
    Private _strPortSize_BaseEnd As String
    Private _strPortType_BaseEnd As String
    Private _strPortType_RodEnd As String

    Public _blnIsBaseEndPinsPresent As Boolean          '02_08_2010  Ragava  made Public
    Public _blnIsRodEndPinsPresent As Boolean           '02_08_2010  Ragava  made Public
    Private _blnIsBaseEndPortAccessoriesPresent As Boolean
    Private _blnIsRodEndPortAccessoriesPresent As Boolean

    Private _dtBaseEndPinsDataTable_Selected As DataTable
    Private _dtRodEndPinsDataTable_Selected As DataTable
    Public _strPin_ClipCode_BaseEnd As String
    Public _strPin_ClipCode_RodEnd As String

    Private _dtPortAccessories_BaseEndDataTable As DataTable
    Private _dtPortAccessories_RodEndDataTable As DataTable
    Public _strPortAccessoryCode_BaseEnd As String
    Public _strPortAccessoryCode_RodEnd As String

    'anup 03-01-2011 start
    Private _dtPortAccessories2_BaseEndDataTable As DataTable
    Private _dtPortAccessories2_RodEndDataTable As DataTable
    Public _strPortAccessory2Code_BaseEnd As String
    Public _strPortAccessory2Code_RodEnd As String
    'anup 03-01-2011 till here

    Private _dtGreaseZercs_DataTable As DataTable
    '  Private _strGreaseZercCode As String = Nothing
    'ANUP 23-08-2010
    Private _strGreaseZercCode_1_BaseEnd As String = Nothing
    Private _strGreaseZercCode_2_BaseEnd As String = Nothing
    Private _strGreaseZercCode_1_RodEnd As String = Nothing
    Private _strGreaseZercCode_2_RodEnd As String = Nothing
    '''###################
    ''' 

    Private _dblWorkingLength_BaseEnd As Double
    Private _dblWorkingLength_RodEnd As Double

    'TODO: ANUP 22-07-2010 12.14pm
    Private _blnIsPopulated As Boolean = False

    'Sunny :09-08-10
    Private _strPinCodeBE As String = String.Empty
    Private _strClipCodeBE As String = String.Empty

    Private _strPinCodeRE As String = String.Empty
    Private _strClipCodeRE As String = String.Empty

    Private _strPaintCode As String = Nothing
    '!!!!!!!!!!!!!!!!!!!!!!!!!!!

    'ANUP 08-11-2010 START
    Private _dblNumberOfPorts_BaseEnd As Double = 0
    Private _dblNumberOfPorts_RodEnd As Double = 0
    'ANUP 08-11-2010 TILL HERE

    'anup 27-12-2010 start
    Private _blnIsBaseEndPortAccessories2Present As Boolean
    Private _blnIsRodEndPortAccessories2Present As Boolean
    'anup 27-12-2010 till here

#End Region

#Region "Property"

    Public Property IsPopulated() As Boolean
        Get
            Return _blnIsPopulated
        End Get
        Set(ByVal value As Boolean)
            _blnIsPopulated = value
        End Set
    End Property

    'A0308:   ANUP 03-08-2010 10.54am
    'Integrate the entire Property
    Public ReadOnly Property ControlsData() As ArrayList
        Get
            ControlsData = New ArrayList
            ' If _blnIsBaseEndPinsPresent Then 'vamsi 25-11-2014
            If _blnIsBaseEndPinsPresent AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnInstallPinsandClips_Checked = True Then
                ControlsData.Add(New Object(3) {"DB", "Base End Pins", "R3", "Yes"})
            Else
                ControlsData.Add(New Object(3) {"DB", "Base End Pins", "R3", "No"})
            End If

            'If _blnIsRodEndPinsPresent Then 'vamsi 25-11-2014
            If _blnIsRodEndPinsPresent AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnInstallPinsandClips_Checked = True Then
                ControlsData.Add(New Object(3) {"DB", "Rod End Pins", "R5", "Yes"})
            Else
                ControlsData.Add(New Object(3) {"DB", "Rod End Pins", "R5", "No"})
            End If

            'ANUP 11-10-2010 START
            If _blnIsBaseEndPortAccessoriesPresent Then
                If (cmbAccessoryType_BaseEnd.Text = "Dust Plug" OrElse cmbAccessoryType_BaseEnd.Text = "Permanent Plug") _
                          AndAlso (cmbAccessoryType2_BaseEnd.Text = "Dust Plug" OrElse cmbAccessoryType2_BaseEnd.Text = "Permanent Plug") Then
                    ControlsData.Add(New Object(3) {"DB", "Base End Port Accessories", "R7", "No"})
                    ControlsData.Add(New Object(3) {"DB", "Rod End Port Accessories Code", "R8", ""})
                    ControlsData.Add(New Object(3) {"DB", "Base End Port Accessories 2", "R25", ""})
                Else
                    ControlsData.Add(New Object(3) {"DB", "Base End Port Accessories", "R7", "Yes"})
                    ControlsData.Add(New Object(3) {"DB", "Rod End Port Accessories Code", "R8", _strPortAccessoryCode_BaseEnd})
                    If _blnIsBaseEndPortAccessories2Present Then
                        ControlsData.Add(New Object(3) {"DB", "Base End Port Accessories 2", "R25", _strPortAccessory2Code_BaseEnd})
                    End If
                End If
            Else
                ControlsData.Add(New Object(3) {"DB", "Base End Port Accessories", "R7", "No"})
                ControlsData.Add(New Object(3) {"DB", "Rod End Port Accessories Code", "R8", ""})
                ControlsData.Add(New Object(3) {"DB", "Base End Port Accessories 2", "R25", ""})
            End If


            If _blnIsRodEndPortAccessoriesPresent Then
                If (cmbAccessoryType_RodEnd.Text = "Dust Plug" OrElse cmbAccessoryType_RodEnd.Text = "Permanent Plug") _
                        AndAlso (cmbAccessoryType2_RodEnd.Text = "Dust Plug" OrElse cmbAccessoryType2_RodEnd.Text = "Permanent Plug") Then
                    ControlsData.Add(New Object(3) {"DB", "Rod End Port Accessories", "R9", "No"})
                    ControlsData.Add(New Object(3) {"DB", "Rod End Port Accessories Code", "R10", ""})
                    ControlsData.Add(New Object(3) {"DB", "Rod End Port Accessories 2", "R26", ""})
                Else
                    ControlsData.Add(New Object(3) {"DB", "Rod End Port Accessories", "R9", "Yes"})
                    ControlsData.Add(New Object(3) {"DB", "Rod End Port Accessories Code", "R10", _strPortAccessoryCode_RodEnd})
                    If _blnIsRodEndPortAccessories2Present Then
                        ControlsData.Add(New Object(3) {"DB", "Rod End Port Accessories 2", "R26", _strPortAccessory2Code_RodEnd})
                    End If
                End If
            Else
                ControlsData.Add(New Object(3) {"DB", "Rod End Port Accessories", "R9", "No"})
                ControlsData.Add(New Object(3) {"DB", "Rod End Port Accessories Code", "R10", ""})
                ControlsData.Add(New Object(3) {"DB", "Rod End Port Accessories 2", "R26", ""})
            End If
            'ANUP 11-10-2010 TILL HERE

            'anup 27-12-2010 start
            ''If _blnIsBaseEndPortAccessories2Present Then
            ''    If cmbAccessoryType2_BaseEnd.Text = "Dust Plug" OrElse cmbAccessoryType2_BaseEnd.Text = "Permanent Plug" Then
            ''        ControlsData.Add(New Object(3) {"DB", "Base End Port Accessories 2", "R25", "No"})
            ''    Else
            ''        ControlsData.Add(New Object(3) {"DB", "Base End Port Accessories 2", "R25", "Yes"})
            ''    End If
            ''Else
            ''    ControlsData.Add(New Object(3) {"DB", "Base End Port Accessories 2", "R25", "No"})
            ''End If

            ''If _blnIsRodEndPortAccessories2Present Then
            ''    If cmbAccessoryType2_RodEnd.Text = "Dust Plug" OrElse cmbAccessoryType2_RodEnd.Text = "Permanent Plug" Then
            ''        ControlsData.Add(New Object(3) {"DB", "Rod End Port Accessories 2", "R26", "No"})
            ''    Else
            ''        ControlsData.Add(New Object(3) {"DB", "Rod End Port Accessories 2", "R26", "Yes"})
            ''    End If
            ''Else
            ''    ControlsData.Add(New Object(3) {"DB", "Rod End Port Accessories 2", "R26", "No"})
            ''End If
            'anup 27-12-2010 till here

            If ObjClsWeldedCylinderFunctionalClass.IsPackPinsAndClipsInPlasticBagChecked OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnInstallPinsandClips_Checked = False AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnIncludepinKitPerBom_Checked = False Then       '06_06_2011  RAGAVA condition blnInstallPinsandClips_Checked added
                ControlsData.Add(New Object(3) {"DB", "Pack Pins And Clips In Plastic Bag", "R12", "Yes"})
            Else
                ControlsData.Add(New Object(3) {"DB", "Pack Pins And Clips In Plastic Bag", "R12", "No"})
            End If

            'ANUP 09-11-2010 START
            'If cmbPins_BaseEnd.Text = "Yes" 25-11-14
            If cmbPins_BaseEnd.Text = "Yes" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnInstallPinsandClips_Checked = True Then
                ControlsData.Add(New Object(3) {"DB", "Base End Pins and Clips Code", "R4", _strPin_ClipCode_BaseEnd})
            Else
                ControlsData.Add(New Object(3) {"DB", "Base End Pins and Clips Code", "R4", ""})
            End If

            'If cmbPins_RodEnd.Text = "Yes" 25-11-14
            If cmbPins_RodEnd.Text = "Yes" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnInstallPinsandClips_Checked = True Then
                ControlsData.Add(New Object(3) {"DB", "Rod End Pins and Clips Code", "R6", _strPin_ClipCode_RodEnd})
            Else
                ControlsData.Add(New Object(3) {"DB", "Rod End Pins and Clips Code", "R6", ""})
            End If
            'ANUP 09-11-2010 TILL HERE

            'anup 03-01-2011 commented
            '   ControlsData.Add(New Object(3) {"DB", "Rod End Port Accessories Code", "R8", _strPortAccessoryCode_BaseEnd})
            '   ControlsData.Add(New Object(3) {"DB", "Rod End Port Accessories Code", "R10", _strPortAccessoryCode_RodEnd})


            'ControlsData.Add(New Object(3) {"DB", "Grease Zerc Code", "R11", _strGreaseZercCode})
            'ANUP 23-08-2010
            ControlsData.Add(New Object(3) {"DB", "Grease Zerc Code", "R11", _strGreaseZercCode_1_BaseEnd})
            ControlsData.Add(New Object(3) {"DB", "Grease Zerc Code", "R19", _strGreaseZercCode_2_BaseEnd})
            ControlsData.Add(New Object(3) {"DB", "Grease Zerc Code", "R20", _strGreaseZercCode_1_RodEnd})
            ControlsData.Add(New Object(3) {"DB", "Grease Zerc Code", "R21", _strGreaseZercCode_2_RodEnd})

            'Sunny:09-08-10
            Try

                '06_06_2011  RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnInstallPinsandClips_Checked = False AndAlso (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndKitCode <> "" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndKitCode <> "") Then 'changed to true 25-11-14
                    '05_07_2011   RAGAVA
                    'If ObjClsWeldedCylinderFunctionalClass.ObjFrmGenerate.chkInstallPinAndClips.Checked = True AndAlso (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndKitCode <> "" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndKitCode <> "") Then
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndKitCode = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndKitCode Then
                        clsAddExistingCodes.AddExistingCodeToHashTable("BASE/ROD END KIT", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndKitCode, 1, "EA")
                    Else
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndKitCode <> "" Then
                            clsAddExistingCodes.AddExistingCodeToHashTable("BASE END KIT", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndKitCode, 1, "EA")
                        End If
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndKitCode <> "" Then
                            clsAddExistingCodes.AddExistingCodeToHashTable("ROD END KIT", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndKitCode, 1, "EA")
                        End If
                    End If
                    GoTo ESC_Pin_And_clips
                Else
                    'TILL    HERE
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnInstallPinsandClips_Checked = True Then
                        If _strPinCodeBE.Equals(_strPinCodeRE) Then  'vamsi commented 2-12-2014    
                            clsAddExistingCodes.AddBaseEndPinCode(_strPinCodeBE, 2, "EA")
                        Else
                            clsAddExistingCodes.AddBaseEndPinCode(_strPinCodeBE, 1, "EA")
                            clsAddExistingCodes.AddRodEndPinCode(_strPinCodeRE, 1, "EA")
                        End If
                    End If

                    'vamsi 04-12-2014 start
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnInstallPinsandClips_Checked = True Then
                        If _strClipCodeBE.Equals(_strClipCodeRE) Then
                            clsAddExistingCodes.AddBaseEndClipCode(_strClipCodeBE, 4, "EA")
                        Else
                            clsAddExistingCodes.AddBaseEndClipCode(_strClipCodeBE, 2, "EA")
                            clsAddExistingCodes.AddRodEndClipCode(_strClipCodeRE, 2, "EA")
                        End If
                    End If
                    'End

                End If
            Catch ex As Exception

            End Try

            'Try  'vamsi 02-12-2014 commented
            '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnInstallPinsandClips_Checked = True Then
            '        If _strClipCodeBE.Equals(_strClipCodeRE) Then
            '            clsAddExistingCodes.AddBaseEndClipCode(_strClipCodeBE, 4, "EA")
            '        Else
            '            clsAddExistingCodes.AddBaseEndClipCode(_strClipCodeBE, 2, "EA")
            '            clsAddExistingCodes.AddRodEndClipCode(_strClipCodeRE, 2, "EA")
            '        End If
            '    End If
            'Catch ex As Exception
            'End Try
ESC_Pin_And_clips:  '06_06_2011    RAGAVA
            '21_10_2010    RAGAVA
            Try
                'If Not (cmbAccessoryType_BaseEnd.Text = "Dust Plug" OrElse cmbAccessoryType_BaseEnd.Text = "Permanent Plug" OrElse cmbAccessoryType2_BaseEnd.Text = "Dust Plug" OrElse cmbAccessoryType2_BaseEnd.Text = "Permanent Plug") Then
                If _strPortAccessoryCode_BaseEnd.Equals(_strPortAccessoryCode_RodEnd) AndAlso _strPortAccessoryCode_BaseEnd <> "" Then
                    clsAddExistingCodes.AddExistingCodeToHashTable("PORT ACCESSORY CODE", _strPortAccessoryCode_BaseEnd, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd, "EA")
                Else
                    If Trim(cmbAccessoryType_BaseEnd.Text) <> "" OrElse Trim(cmbAccessoryType2_BaseEnd.Text) <> "" Then
                        If Not (cmbAccessoryType_BaseEnd.Text = "Dust Plug" OrElse cmbAccessoryType_BaseEnd.Text = "Permanent Plug" OrElse cmbAccessoryType2_BaseEnd.Text = "Dust Plug" OrElse cmbAccessoryType2_BaseEnd.Text = "Permanent Plug") Then
                            clsAddExistingCodes.AddBaseEndPortAccessoryCode(_strPortAccessoryCode_BaseEnd, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd, "EA")
                        End If
                    End If
                    If Trim(cmbAccessoryType_RodEnd.Text) <> "" OrElse Trim(cmbAccessoryType2_RodEnd.Text) <> "" Then
                        If Not (cmbAccessoryType_RodEnd.Text = "Dust Plug" OrElse cmbAccessoryType_RodEnd.Text = "Permanent Plug" OrElse cmbAccessoryType2_RodEnd.Text = "Dust Plug" OrElse cmbAccessoryType2_RodEnd.Text = "Permanent Plug") Then
                            clsAddExistingCodes.AddRodEndPortAccessoryCode(_strPortAccessoryCode_RodEnd, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd, "EA")
                        End If
                    End If
                End If
                '03_11_2010   RAGAVA
                If _strPortAccessoryCode_BaseEnd.Equals(_strPortAccessoryCode_RodEnd) AndAlso _strPortAccessoryCode_BaseEnd <> "" Then
                    If _strPortAccessoryCode_BaseEnd = "177543" Then
                        clsAddExistingCodes.AddExistingCodeToHashTable("Adaptor Cap", "258338", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd, "EA")
                    ElseIf _strPortAccessoryCode_BaseEnd = "258338" Then
                        clsAddExistingCodes.AddExistingCodeToHashTable("Adaptor Cap", "177543", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd, "EA")
                    ElseIf _strPortAccessoryCode_BaseEnd = "177544" Then
                        clsAddExistingCodes.AddExistingCodeToHashTable("Adaptor Cap", "157547", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd, "EA")
                    ElseIf _strPortAccessoryCode_BaseEnd = "157547" Then
                        clsAddExistingCodes.AddExistingCodeToHashTable("Adaptor Cap", "177544", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd, "EA")
                    End If
                Else
                    If _strPortAccessoryCode_BaseEnd = "177543" Then
                        clsAddExistingCodes.AddExistingCodeToHashTable("Base Adaptor Cap", "258338", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd, "EA")
                    ElseIf _strPortAccessoryCode_BaseEnd = "258338" Then
                        clsAddExistingCodes.AddExistingCodeToHashTable("Base Adaptor Cap", "177543", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd, "EA")
                    ElseIf _strPortAccessoryCode_BaseEnd = "177544" Then
                        clsAddExistingCodes.AddExistingCodeToHashTable("Base Adaptor Cap", "157547", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd, "EA")
                    ElseIf _strPortAccessoryCode_BaseEnd = "157547" Then
                        clsAddExistingCodes.AddExistingCodeToHashTable("Base Adaptor Cap", "177544", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd, "EA")
                    End If
                    If _strPortAccessoryCode_RodEnd = "177543" Then
                        clsAddExistingCodes.AddExistingCodeToHashTable("Rod Adaptor Cap", "258338", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd, "EA")
                    ElseIf _strPortAccessoryCode_RodEnd = "258338" Then
                        clsAddExistingCodes.AddExistingCodeToHashTable("Rod Adaptor Cap", "177543", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd, "EA")
                    ElseIf _strPortAccessoryCode_RodEnd = "177544" Then
                        clsAddExistingCodes.AddExistingCodeToHashTable("Rod Adaptor Cap", "157547", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd, "EA")
                    ElseIf _strPortAccessoryCode_RodEnd = "157547" Then
                        clsAddExistingCodes.AddExistingCodeToHashTable("Rod Adaptor Cap", "177544", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd, "EA")
                    End If
                End If
                'Till   Here
                'End If
                'If _strPortAccessoryCode_BaseEnd.Equals(_strPortAccessoryCode_RodEnd) Then
                '    clsAddExistingCodes.AddBaseEndPortAccessoryCode(_strPortAccessoryCode_BaseEnd, 2, "EA")
                'Else
                '    clsAddExistingCodes.AddBaseEndPortAccessoryCode(_strPortAccessoryCode_BaseEnd, 1, "EA")
                '    clsAddExistingCodes.AddRodEndPortAccessoryCode(_strPortAccessoryCode_RodEnd, 1, "EA")
                'End If
            Catch ex As Exception

            End Try

            'Try

            '    Dim dblGreaseZerks As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs + _
            '                                           ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs_RodEnd
            '    ''''MUST BE DONE 
            '    'clsAddExistingCodes.AddGreaseZercCode(_strGreaseZercCode, dblGreaseZerks, "EA")
            '    clsAddExistingCodes.AddGreaseZercCode(_strGreaseZercCode_1_BaseEnd, dblGreaseZerks, "EA")

            'Catch ex As Exception

            'End Try
            Try

                Dim dblGreaseZerks As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs + _
                                                       ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GreaseZercs_RodEnd
                ''''MUST BE DONE 
                GreaseZerkFunctionality()

            Catch ex As Exception

            End Try

            clsAddExistingCodes.AddPaintCode(_strPaintCode, 0.1, "LT")

            clsAddExistingCodes.AddLable(ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked, ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbRodMaterial.Text)    'Neeraja

            If ObjClsWeldedCylinderFunctionalClass.IsBaseEndPortImported Then
                ControlsData.Add(New Object(3) {"DB", "Imported Base End Port", "R14", "Yes"})
            Else
                ControlsData.Add(New Object(3) {"DB", "Imported Base End Port", "R14", "No"})
            End If

            If ObjClsWeldedCylinderFunctionalClass.IsRodEndPortImported Then
                ControlsData.Add(New Object(3) {"DB", "Imported Rod End Port", "R15", "Yes"})
            Else
                ControlsData.Add(New Object(3) {"DB", "Imported Rod End Port", "R15", "No"})
            End If

            If ObjClsWeldedCylinderFunctionalClass.IsPlateClevisImported Then
                ControlsData.Add(New Object(3) {"DB", "Imported Plate Clevis", "R16", "Yes"})
            Else
                ControlsData.Add(New Object(3) {"DB", "Imported Plate Clevis", "R16", "No"})
            End If

            If ObjClsWeldedCylinderFunctionalClass.IsBaseEndPartImported Then
                ControlsData.Add(New Object(3) {"DB", "Imported Base End Part", "R17", "Yes"})
            Else
                ControlsData.Add(New Object(3) {"DB", "Imported Base End Part", "R17", "No"})
            End If

            If ObjClsWeldedCylinderFunctionalClass.IsRodEndPartImported Then
                ControlsData.Add(New Object(3) {"DB", "Imported Rod End Part", "R18", "Yes"})
            Else
                ControlsData.Add(New Object(3) {"DB", "Imported Rod End Part", "R18", "No"})
            End If



            '22_10_2010     RAGAVA
            Dim blnDustPlugsAdded As Boolean = False
            Dim blnPermanentPlugsAdded As Boolean = False
            Try
                If Trim(cmbAccessoryType_BaseEnd.Text) <> "" OrElse Trim(cmbAccessoryType2_BaseEnd.Text) <> "" OrElse Trim(cmbAccessoryType_RodEnd.Text) <> "" OrElse Trim(cmbAccessoryType2_RodEnd.Text) <> "" Then
                    If (cmbAccessoryType_BaseEnd.Text = "Dust Plug" OrElse cmbAccessoryType_BaseEnd.Text = "Permanent Plug") AndAlso (cmbAccessoryType_RodEnd.Text = "Dust Plug" OrElse cmbAccessoryType_RodEnd.Text = "Permanent Plug") Then
                        Dim strQuery As String = String.Empty
                        If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPortCode) <> "" Then
                            strQuery = "select DustPlug,ORB_AND_NPTF_PermanentPlugs,Sealant_For_NPTF from Welded.PortsAndWPDSDetails where PortCode = '" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPortCode & "'"
                        Else
                            strQuery = "select DustPlug,ORB_AND_NPTF_PermanentPlugs,Sealant_For_NPTF from Welded.PortsAndWPDSDetails where PortType = '" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd & "' and PortOrientation = '" & Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleBaseEnd.Text) & "' and port_size = '" & Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text) & "'"
                        End If
                        Dim dr_Base As DataRow = MonarchConnectionObject.GetDataRow(strQuery)

                        If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPortCode) <> "" Then
                            strQuery = "select DustPlug,ORB_AND_NPTF_PermanentPlugs,Sealant_For_NPTF from Welded.PortsAndWPDSDetails where PortCode = '" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPortCode & "'"
                        Else
                            strQuery = "select DustPlug,ORB_AND_NPTF_PermanentPlugs,Sealant_For_NPTF from Welded.PortsAndWPDSDetails where PortType = '" & Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.Text) & "' and PortOrientation = '" & Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text) & "' and port_size = '" & Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.Text) & "'"
                        End If
                        Dim dr_Rod As DataRow = MonarchConnectionObject.GetDataRow(strQuery)
                        Dim strDustPlug_Base, strDustPlug_Rod, strPermanentPlug_Base, strPermanentPlug_Rod As String
                        strDustPlug_Base = String.Empty
                        strDustPlug_Rod = String.Empty
                        strPermanentPlug_Base = String.Empty
                        strPermanentPlug_Rod = String.Empty
                        Dim iDustPlugCount As Integer = 0
                        Dim iPermanentPlugCount As Integer = 0
                        If Not dr_Base Is Nothing Then
                            If cmbAccessoryType_BaseEnd.Text = "Dust Plug" OrElse cmbAccessoryType2_BaseEnd.Text = "Dust Plug" Then
                                strDustPlug_Base = dr_Base("DustPlug").ToString
                            End If
                            If cmbAccessoryType_BaseEnd.Text = "Permanent Plug" OrElse cmbAccessoryType2_BaseEnd.Text = "Permanent Plug" Then
                                strPermanentPlug_Base = dr_Base("ORB_AND_NPTF_PermanentPlugs").ToString
                            End If
                        End If
                        If Not dr_Rod Is Nothing Then
                            If cmbAccessoryType_RodEnd.Text = "Dust Plug" OrElse cmbAccessoryType2_RodEnd.Text = "Dust Plug" Then
                                strDustPlug_Rod = dr_Rod("DustPlug").ToString
                            End If
                            If cmbAccessoryType_RodEnd.Text = "Permanent Plug" OrElse cmbAccessoryType2_RodEnd.Text = "Permanent Plug" Then
                                strPermanentPlug_Rod = dr_Rod("ORB_AND_NPTF_PermanentPlugs").ToString
                            End If
                        End If
                        If (strDustPlug_Base = strDustPlug_Rod AndAlso strDustPlug_Base <> "") OrElse (strPermanentPlug_Base = strPermanentPlug_Rod AndAlso strPermanentPlug_Base <> "") Then
                            If Trim(strDustPlug_Base) = Trim(strDustPlug_Rod) AndAlso strDustPlug_Base <> "" Then
                                If cmbAccessoryType_BaseEnd.Text = "Dust Plug" Then
                                    iDustPlugCount += 1
                                End If
                                If cmbAccessoryType2_BaseEnd.Text = "Dust Plug" Then
                                    iDustPlugCount += 1
                                End If
                                If cmbAccessoryType_RodEnd.Text = "Dust Plug" Then
                                    iDustPlugCount += 1
                                End If
                                If cmbAccessoryType2_RodEnd.Text = "Dust Plug" Then
                                    iDustPlugCount += 1
                                End If
                                If iDustPlugCount > 0 Then
                                    clsAddExistingCodes.AddExistingCodeToHashTable("Dust Plug", strDustPlug_Base, iDustPlugCount, "EA")
                                    If dr_Base("Sealant_For_NPTF").ToString <> "" AndAlso dr_Base("Sealant_For_NPTF").ToString <> "N/A" Then
                                        clsAddExistingCodes.AddExistingCodeToHashTable("Base Sealant", dr_Base("Sealant_For_NPTF").ToString, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd, "EA")
                                    End If
                                    blnDustPlugsAdded = True
                                End If
                            End If
                            If Trim(strPermanentPlug_Base) = Trim(strPermanentPlug_Rod) AndAlso strPermanentPlug_Base <> "" Then
                                If cmbAccessoryType_BaseEnd.Text = "Permanent Plug" Then
                                    iPermanentPlugCount += 1
                                End If
                                If cmbAccessoryType2_BaseEnd.Text = "Permanent Plug" Then
                                    iPermanentPlugCount += 1
                                End If
                                If cmbAccessoryType_RodEnd.Text = "Permanent Plug" Then
                                    iPermanentPlugCount += 1
                                End If
                                If cmbAccessoryType2_RodEnd.Text = "Permanent Plug" Then
                                    iPermanentPlugCount += 1
                                End If
                                If iPermanentPlugCount > 0 Then
                                    clsAddExistingCodes.AddExistingCodeToHashTable("Permanent Plug", strPermanentPlug_Base, iPermanentPlugCount, "EA")
                                    If dr_Rod("Sealant_For_NPTF").ToString <> "" AndAlso dr_Rod("Sealant_For_NPTF").ToString <> "N/A" Then
                                        clsAddExistingCodes.AddExistingCodeToHashTable("Rod Sealant", dr_Rod("Sealant_For_NPTF").ToString, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd, "EA")
                                    End If
                                    blnPermanentPlugsAdded = True
                                End If
                            End If
                            'GoTo Skip
                            'ElseIf (strDustPlug_Base = strDustPlug_Rod AndAlso strDustPlug_Base <> "") Then
                            '    If cmbAccessoryType_BaseEnd.Text = "Dust Plug" Then
                            '        iDustPlugCount += 1
                            '    End If
                            '    If cmbAccessoryType2_BaseEnd.Text = "Dust Plug" Then
                            '        iDustPlugCount += 1
                            '    End If
                            '    If cmbAccessoryType_RodEnd.Text = "Dust Plug" Then
                            '        iDustPlugCount += 1
                            '    End If
                            '    If cmbAccessoryType2_RodEnd.Text = "Dust Plug" Then
                            '        iDustPlugCount += 1
                            '    End If
                            '    If iDustPlugCount > 0 Then
                            '        clsAddExistingCodes.AddExistingCodeToHashTable("Dust Plug", strDustPlug_Base, iDustPlugCount, "EA")
                            '        If dr_Base("Sealant_For_NPTF").ToString <> "" AndAlso dr_Base("Sealant_For_NPTF").ToString <> "N/A" Then
                            '            clsAddExistingCodes.AddExistingCodeToHashTable("Base Sealant", dr_Base("Sealant_For_NPTF").ToString, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd, "EA")
                            '        End If
                            '    End If
                        End If
                    End If
                End If
            Catch ex As Exception
            End Try
            'Till   here
            '18_10_2010   RAGAVA
            Try
                If Trim(cmbAccessoryType_BaseEnd.Text) <> "" OrElse Trim(cmbAccessoryType2_BaseEnd.Text) <> "" Then
                    If cmbAccessoryType_BaseEnd.Text = "Dust Plug" OrElse cmbAccessoryType_BaseEnd.Text = "Permanent Plug" OrElse cmbAccessoryType2_BaseEnd.Text = "Dust Plug" OrElse cmbAccessoryType2_BaseEnd.Text = "Permanent Plug" Then
                        Dim strQuery As String = String.Empty
                        If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPortCode) <> "" Then
                            strQuery = "select DustPlug,ORB_AND_NPTF_PermanentPlugs,Sealant_For_NPTF from Welded.PortsAndWPDSDetails where PortCode = '" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPortCode & "'"
                        Else
                            strQuery = "select DustPlug,ORB_AND_NPTF_PermanentPlugs,Sealant_For_NPTF from Welded.PortsAndWPDSDetails where PortType = '" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd & "' and PortOrientation = '" & Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleBaseEnd.Text) & "' and port_size = '" & Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text) & "'"
                        End If
                        Dim dr As DataRow = MonarchConnectionObject.GetDataRow(strQuery)
                        If Not dr Is Nothing Then
                            '21_10_2010   RAGAVA
                            If Trim(cmbAccessoryType_BaseEnd.Text) = "Dust Plug" AndAlso Trim(cmbAccessoryType2_BaseEnd.Text) = "Dust Plug" AndAlso blnDustPlugsAdded = False Then
                                clsAddExistingCodes.AddExistingCodeToHashTable("Base End Dust Plug", dr("DustPlug").ToString, 2, "EA")
                            ElseIf Trim(cmbAccessoryType_BaseEnd.Text) = "Permanent Plug" AndAlso Trim(cmbAccessoryType2_BaseEnd.Text) = "Permanent Plug" AndAlso blnPermanentPlugsAdded = False Then
                                clsAddExistingCodes.AddExistingCodeToHashTable("Base End Permanent Plug", dr("ORB_AND_NPTF_PermanentPlugs").ToString, 2, "EA")
                            Else
                                If Trim(cmbAccessoryType_BaseEnd.Text) = "Dust Plug" AndAlso blnDustPlugsAdded = False Then
                                    clsAddExistingCodes.AddExistingCodeToHashTable("Base End Dust Plug", dr("DustPlug").ToString, 1, "EA")
                                ElseIf Trim(cmbAccessoryType_BaseEnd.Text) = "Permanent Plug" AndAlso blnPermanentPlugsAdded = False Then
                                    clsAddExistingCodes.AddExistingCodeToHashTable("Base End Permanent Plug", dr("ORB_AND_NPTF_PermanentPlugs").ToString, 1, "EA")
                                End If
                                If Trim(cmbAccessoryType2_BaseEnd.Text) = "Dust Plug" AndAlso blnDustPlugsAdded = False Then
                                    clsAddExistingCodes.AddExistingCodeToHashTable("Base End Dust Plug", dr("DustPlug").ToString, 1, "EA")
                                ElseIf Trim(cmbAccessoryType2_BaseEnd.Text) = "Permanent Plug" AndAlso blnPermanentPlugsAdded = False Then
                                    clsAddExistingCodes.AddExistingCodeToHashTable("Base End Permanent Plug", dr("ORB_AND_NPTF_PermanentPlugs").ToString, 1, "EA")
                                End If
                            End If
                            '' ''If dr("Sealant_For_NPTF").ToString <> "" AndAlso dr("Sealant_For_NPTF").ToString <> "N/A" Then
                            '' ''    clsAddExistingCodes.AddExistingCodeToHashTable("Base Sealant", dr("Sealant_For_NPTF").ToString, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd, "EA")
                            '' ''End If
                            'If dr("DustPlug").ToString <> "" AndAlso dr("DustPlug").ToString <> "N/A" Then
                            '    clsAddExistingCodes.AddExistingCodeToHashTable("Base End Dust Plug", dr("DustPlug").ToString, 1, "EA")
                            'End If
                            'If dr("ORB_AND_NPTF_PermanentPlugs").ToString <> "" AndAlso dr("ORB_AND_NPTF_PermanentPlugs").ToString <> "N/A" Then
                            '    clsAddExistingCodes.AddExistingCodeToHashTable("Base End Permanent Plug", dr("ORB_AND_NPTF_PermanentPlugs").ToString, 1, "EA")
                            'End If
                            'Till   Here
                        End If
                    End If
                End If
            Catch ex As Exception
            End Try
            Try
                If Trim(cmbAccessoryType_RodEnd.Text) <> "" OrElse Trim(cmbAccessoryType2_RodEnd.Text) <> "" Then
                    If cmbAccessoryType_RodEnd.Text = "Dust Plug" OrElse cmbAccessoryType_RodEnd.Text = "Permanent Plug" OrElse cmbAccessoryType2_RodEnd.Text = "Dust Plug" OrElse cmbAccessoryType2_RodEnd.Text = "Permanent Plug" Then
                        Dim strQuery As String = String.Empty
                        If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPortCode) <> "" Then
                            strQuery = "select DustPlug,ORB_AND_NPTF_PermanentPlugs,Sealant_For_NPTF from Welded.PortsAndWPDSDetails where PortCode = '" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPortCode & "'"
                        Else
                            strQuery = "select DustPlug,ORB_AND_NPTF_PermanentPlugs,Sealant_For_NPTF from Welded.PortsAndWPDSDetails where PortType = '" & Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.Text) & "' and PortOrientation = '" & Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text) & "' and port_size = '" & Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.Text) & "'"
                        End If
                        Dim dr As DataRow = MonarchConnectionObject.GetDataRow(strQuery)
                        If Not dr Is Nothing Then
                            '21_10_2010   RAGAVA
                            If Trim(cmbAccessoryType_RodEnd.Text) = "Dust Plug" AndAlso Trim(cmbAccessoryType2_RodEnd.Text) = "Dust Plug" AndAlso blnDustPlugsAdded = False Then
                                clsAddExistingCodes.AddExistingCodeToHashTable("Rod End Dust Plug", dr("DustPlug").ToString, 2, "EA")
                            ElseIf Trim(cmbAccessoryType_RodEnd.Text) = "Permanent Plug" AndAlso Trim(cmbAccessoryType2_RodEnd.Text) = "Permanent Plug" AndAlso blnPermanentPlugsAdded = False Then
                                clsAddExistingCodes.AddExistingCodeToHashTable("Rod End Permanent Plug", dr("ORB_AND_NPTF_PermanentPlugs").ToString, 2, "EA")
                            Else
                                If Trim(cmbAccessoryType_RodEnd.Text) = "Dust Plug" AndAlso blnDustPlugsAdded = False Then
                                    clsAddExistingCodes.AddExistingCodeToHashTable("Rod End Dust Plug", dr("DustPlug").ToString, 1, "EA")
                                ElseIf Trim(cmbAccessoryType_RodEnd.Text) = "Permanent Plug" AndAlso blnPermanentPlugsAdded = False Then
                                    clsAddExistingCodes.AddExistingCodeToHashTable("Rod End Permanent Plug", dr("ORB_AND_NPTF_PermanentPlugs").ToString, 1, "EA")
                                End If
                                If Trim(cmbAccessoryType2_RodEnd.Text) = "Dust Plug" AndAlso blnDustPlugsAdded = False Then
                                    clsAddExistingCodes.AddExistingCodeToHashTable("Rod End Dust Plug", dr("DustPlug").ToString, 1, "EA")
                                ElseIf Trim(cmbAccessoryType2_RodEnd.Text) = "Permanent Plug" AndAlso blnPermanentPlugsAdded = False Then
                                    clsAddExistingCodes.AddExistingCodeToHashTable("Rod End Permanent Plug", dr("ORB_AND_NPTF_PermanentPlugs").ToString, 1, "EA")
                                End If
                            End If
                            '' ''If dr("Sealant_For_NPTF").ToString <> "" AndAlso dr("Sealant_For_NPTF").ToString <> "N/A" Then
                            '' ''    clsAddExistingCodes.AddExistingCodeToHashTable("Rod Sealant", dr("Sealant_For_NPTF").ToString, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd, "EA")
                            '' ''End If
                            'If dr("DustPlug").ToString <> "" AndAlso dr("DustPlug").ToString <> "N/A" Then
                            '    clsAddExistingCodes.AddExistingCodeToHashTable("Rod End Dust Plug", dr("DustPlug").ToString, 1, "EA")
                            'End If
                            'If dr("ORB_AND_NPTF_PermanentPlugs").ToString <> "" AndAlso dr("ORB_AND_NPTF_PermanentPlugs").ToString <> "N/A" Then
                            '    clsAddExistingCodes.AddExistingCodeToHashTable("Rod End Permanent Plug", dr("ORB_AND_NPTF_PermanentPlugs").ToString, 1, "EA")
                            'End If
                            'Till    Here
                        End If
                    End If
                End If
            Catch ex As Exception
            End Try
            'Till    Here

            Return ControlsData
        End Get
    End Property

#End Region

#Region "Sub-Procedures and Functions"

    Private Sub GreaseZerkFunctionality()
        Dim aFinalZerkList As New Hashtable

        If Not IsNothing(cmbBaseGreaseZercType1.Text) AndAlso cmbBaseGreaseZercType1.Text.Length > 0 Then
            AddItemsToZerksList(aFinalZerkList, _strGreaseZercCode_1_BaseEnd)
        End If
        If Not IsNothing(cmbBaseGreaseZercType2.Text) AndAlso cmbBaseGreaseZercType2.Text.Length > 0 Then
            AddItemsToZerksList(aFinalZerkList, _strGreaseZercCode_2_BaseEnd)
        End If
        If Not IsNothing(cmbRodGreaseZercType1.Text) AndAlso cmbRodGreaseZercType1.Text.Length > 0 Then
            AddItemsToZerksList(aFinalZerkList, _strGreaseZercCode_1_RodEnd)
        End If
        If Not IsNothing(cmbRodGreaseZercType2.Text) AndAlso cmbRodGreaseZercType2.Text.Length > 0 Then
            AddItemsToZerksList(aFinalZerkList, _strGreaseZercCode_2_RodEnd)
        End If

        For Each oItem As DictionaryEntry In aFinalZerkList
            clsAddExistingCodes.AddGreaseZercCode(oItem.Key, oItem.Value, "EA")
        Next
    End Sub


    Private Sub AddItemsToZerksList(ByVal aFinalZerkList As Hashtable, ByVal strKey As String)
        If aFinalZerkList.ContainsKey(strKey) Then
            aFinalZerkList.Item(strKey) = aFinalZerkList.Item(strKey) + 1
        Else
            aFinalZerkList.Add(strKey, 1)
        End If
    End Sub


    Public Sub ManualLoad()
        PinHoleSizeCalc()
        'ANUP 08-11-2010 START
        Pins_Default()
        '  BaseEndPinsValidation()
        'RodEndPinsValidation()
        'ANUP 08-11-2010 TILL HERE.
        'TODO: ANUP 22-07-2010 10.19am
        '  GreaseZercs_Adding()
        'ANUP 23-08-2010
        GreaseZercsBaseEnd_Adding()
        GreaseZercsRodEnd_Adding()

        PortSizeCalc()
        'ANUP 11-10-2010 START
        PortAccessories_Paint_DefaultSettings()
        'ANUP 11-10-2010 TILL HERE
    End Sub

    Private Sub PinHoleSizeCalc()
        _dblPinHoleSize_BaseEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize - 0.015
        _dblPinHoleSize_RodEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd - 0.015
    End Sub

    Private Sub BaseEndPinsValidation()
        Try
            ' _blnIsBaseEndPinsPresent = False  'ANUP 09-11-2010 START
            cmbPinMaterial_BaseEnd.Items.Clear()
            cmbPinClips_BaseEnd.Items.Clear()
            If ObjClsWeldedCylinderFunctionalClass.CmbBaseEndConfiguration.Text = "Double Lug" AndAlso cmbPins_BaseEnd.Text = "Yes" Then 'ANUP 08-11-2010 START
                _dblWorkingLengthCalculation_BaseEnd = WorkingLengthCalculation(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness)
                Dim oPinDetailsDataTable_BaseEnd As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPinsDetails_AccessoriesForm(_dblPinHoleSize_BaseEnd, _dblWorkingLengthCalculation_BaseEnd)
                If DisplayingPinsMaterial(oPinDetailsDataTable_BaseEnd, cmbPinMaterial_BaseEnd) Then
                    grbBaseEndPinsDetails.Enabled = True
                    If cmbPinMaterial_BaseEnd.Items.Contains("Standard") Then
                        cmbPinMaterial_BaseEnd.Text = "Standard"
                    End If
                    '   cmbPinMaterial_BaseEnd.SelectedIndex = 0
                    '  _blnIsBaseEndPinsPresent = True  'ANUP 09-11-2010 START
                Else
                    MsgBox("BaseEnd Pin Details are not available in the database for the selected pin diameter")         '25_03_2011   RAGAVA
                    cmbPins_BaseEnd.Text = "No"         '25_03_2011   RAGAVA
                    grbBaseEndPinsDetails.Enabled = False
                End If
            Else
                grbBaseEndPinsDetails.Enabled = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RodEndPinsValidation()
        Try
            ' _blnIsRodEndPinsPresent = False 'ANUP 09-11-2010 START
            cmbPinMaterial_RodEnd.Items.Clear()
            cmbPinClips_RodEnd.Items.Clear()
            If ObjClsWeldedCylinderFunctionalClass.CmbRodEndConfiguration_RodEnd.Text = "Double Lug" AndAlso cmbPins_RodEnd.Text = "Yes" Then 'ANUP 08-11-2010 START
                _dblWorkingLengthCalculation_RodEnd = WorkingLengthCalculation(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugGap_RodEnd, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd)
                Dim oPinDetailsDataTable_RodEnd As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPinsDetails_AccessoriesForm(_dblPinHoleSize_RodEnd, _dblWorkingLengthCalculation_RodEnd)
                If DisplayingPinsMaterial(oPinDetailsDataTable_RodEnd, cmbPinMaterial_RodEnd) Then
                    grbRodEndPinsDetails.Enabled = True
                    If cmbPinMaterial_RodEnd.Items.Contains("Standard") Then
                        cmbPinMaterial_RodEnd.Text = "Standard"
                    End If
                    'cmbPinMaterial_RodEnd.SelectedIndex = 0
                    '_blnIsRodEndPinsPresent = True 'ANUP 09-11-2010 START
                Else
                    MsgBox("RodEnd Pin Details are not available in the database for the selected pin diameter")         '25_03_2011   RAGAVA
                    cmbPins_RodEnd.Text = "No"         '25_03_2011   RAGAVA
                    grbRodEndPinsDetails.Enabled = False
                End If

            Else
                grbRodEndPinsDetails.Enabled = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function DisplayingPinsMaterial(ByVal oDataTable As DataTable, ByVal oComboBox As ComboBox) As Boolean
        Try
            DisplayingPinsMaterial = False
            If Not IsNothing(oDataTable) Then
                For Each oDataRow As DataRow In oDataTable.Rows
                    If Not IsNothing(oDataRow("PinMaterial")) Then
                        oComboBox.Items.Add(oDataRow("PinMaterial"))
                        DisplayingPinsMaterial = True
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Function WorkingLengthCalculation(ByVal dblLugGap As Double, ByVal dblLugThickness As Double) As Double
        WorkingLengthCalculation = dblLugGap + dblLugThickness * 2
    End Function

    Private Sub AddingPinMaterial_ComboBox(ByVal cmbComboBox As ComboBox)
        Try

            cmbComboBox.Items.Clear()
            cmbComboBox.Items.Add("Standard")
            cmbComboBox.Items.Add("Hardened")
            cmbComboBox.SelectedIndex = 0

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PinMaterialVariable(ByVal cmbComboBox As ComboBox)
        If cmbComboBox.Text = "Hardend" Then
            _strPinMaterial = "Y"
        ElseIf cmbComboBox.Text = "Standard" Then
            _strPinMaterial = "N"
        End If
    End Sub

    'Private Sub GreaseZercs_Adding()
    '    If ObjClsWeldedCylinderFunctionalClass.CmbGreaseZercs_BaseEnd.Text = "1" OrElse ObjClsWeldedCylinderFunctionalClass.CmbGreaseZercs_BaseEnd.Text = "2" _
    '       OrElse ObjClsWeldedCylinderFunctionalClass.CmbGreaseZercs_RodEnd.Text = "1" OrElse ObjClsWeldedCylinderFunctionalClass.CmbGreaseZercs_RodEnd.Text = "2" Then
    '        cmbBaseGreaseZercType1.Enabled = True
    '        _dtGreaseZercs_DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetGreaseZercs_AccessoriesForm()
    '        cmbBaseGreaseZercType1.Items.Clear()
    '        For Each oDataRow As DataRow In _dtGreaseZercs_DataTable.Rows
    '            If Not IsNothing(oDataRow("Description")) Then
    '                cmbBaseGreaseZercType1.Items.Add(oDataRow("Description"))
    '            End If
    '        Next
    '        cmbBaseGreaseZercType1.SelectedIndex = 0
    '    Else
    '        cmbBaseGreaseZercType1.Enabled = False
    '    End If

    'End Sub

    'ANUP 23-08-2010
    Private Sub GreaseZercsBaseEnd_Adding()

        cmbBaseGreaseZercType1.Enabled = False
        cmbBaseGreaseZercType2.Enabled = False
        cmbBaseGreaseZercType1.Items.Clear()
        cmbBaseGreaseZercType2.Items.Clear()

        If ObjClsWeldedCylinderFunctionalClass.CmbGreaseZercs_BaseEnd.Text = "2" Then
            GreaseZercs_AddingToComboBox(cmbBaseGreaseZercType1)
            GreaseZercs_AddingToComboBox(cmbBaseGreaseZercType2)
        ElseIf ObjClsWeldedCylinderFunctionalClass.CmbGreaseZercs_BaseEnd.Text = "1" Then
            GreaseZercs_AddingToComboBox(cmbBaseGreaseZercType1)
        End If

    End Sub

    'ANUP 23-08-2010
    Private Sub GreaseZercsRodEnd_Adding()

        cmbRodGreaseZercType1.Enabled = False
        cmbRodGreaseZercType2.Enabled = False
        cmbRodGreaseZercType1.Items.Clear()
        cmbRodGreaseZercType2.Items.Clear()

        If ObjClsWeldedCylinderFunctionalClass.CmbGreaseZercs_RodEnd.Text = "2" Then
            GreaseZercs_AddingToComboBox(cmbRodGreaseZercType1)
            GreaseZercs_AddingToComboBox(cmbRodGreaseZercType2)
        ElseIf ObjClsWeldedCylinderFunctionalClass.CmbGreaseZercs_RodEnd.Text = "1" Then
            GreaseZercs_AddingToComboBox(cmbRodGreaseZercType1)
        End If
    End Sub

    'ANUP 23-08-2010
    Private Sub GreaseZercs_AddingToComboBox(ByVal GreaseZercComboBox As ComboBox)
        GreaseZercComboBox.Enabled = True
        _dtGreaseZercs_DataTable = Nothing
        _dtGreaseZercs_DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetGreaseZercs_AccessoriesForm()
        For Each oDataRow As DataRow In _dtGreaseZercs_DataTable.Rows
            If Not IsNothing(oDataRow("Description")) Then
                GreaseZercComboBox.Items.Add(oDataRow("Description"))
            End If
        Next
        GreaseZercComboBox.SelectedIndex = 0
    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, LabelGradient5, LabelGradient4, LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblPistonDesign)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblPinMaterialAndGreaseZercDetails)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblPortAccessoriesAndPaintDetails)
    End Sub

    'ANUP 08-11-2010 START
    Private Sub Pins_Default()
        Try

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" Then
                cmbPins_BaseEnd.Enabled = True
                cmbPins_BaseEnd.Items.Clear()
                cmbPins_BaseEnd.Items.Add("Yes")
                cmbPins_BaseEnd.Items.Add("No")
                '26_11_2010   ANUP
                'cmbPins_BaseEnd.SelectedIndex = 0
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize = 1 Then
                    cmbPins_BaseEnd.SelectedIndex = 0
                Else
                    cmbPins_BaseEnd.SelectedIndex = 1
                End If
                'Till  Here
            Else
                Pins_Dafault_ControlsEnabling(cmbPins_BaseEnd, cmbPinMaterial_BaseEnd, cmbPinClips_BaseEnd)
            End If

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" Then
                cmbPins_RodEnd.Enabled = True
                cmbPins_RodEnd.Items.Clear()
                cmbPins_RodEnd.Items.Add("Yes")
                cmbPins_RodEnd.Items.Add("No")
                '26_11_2010   ANUP
                'cmbPins_RodEnd.SelectedIndex = 0
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd = 1 Then
                    cmbPins_RodEnd.SelectedIndex = 0
                Else
                    cmbPins_RodEnd.SelectedIndex = 1
                End If
                'Till  Here
            Else
                Pins_Dafault_ControlsEnabling(cmbPins_RodEnd, cmbPinMaterial_RodEnd, cmbPinClips_RodEnd)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Pins_Dafault_ControlsEnabling(ByVal cmbComboBox1 As ComboBox, ByVal cmbComboBox2 As ComboBox, ByVal cmbComboBox3 As ComboBox)
        Try
            cmbComboBox1.Items.Clear()
            cmbComboBox1.SelectedIndex = -1
            cmbComboBox1.Enabled = False
            cmbComboBox2.Items.Clear()
            cmbComboBox2.Enabled = False
            cmbComboBox3.Items.Clear()
            cmbComboBox3.Enabled = False
        Catch ex As Exception

        End Try
    End Sub
    'ANUP 08-11-2010 TILL HERE


#End Region

#Region "Events"

    Private Sub chkPaint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPaint.CheckedChanged
        If chkPaint.Checked Then
            PaintValidation()      '07_09_2010   RAGAVA
            cmbPaint.Enabled = True
        Else
            cmbPaint.Items.Clear()      '07_09_2010   RAGAVA
            cmbPaint.Enabled = False
        End If
    End Sub

    Private Sub cmbPinMaterial_BaseEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPinMaterial_BaseEnd.SelectedIndexChanged
        PinMaterialVariable(cmbPinMaterial_BaseEnd)
        _dblWorkingLength_BaseEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWorkingLength_Pins(_dblWorkingLengthCalculation_BaseEnd)
        _dtBaseEndPinsDataTable_Selected = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPinsClips_AccessoriesForm(cmbPinMaterial_BaseEnd, _dblPinHoleSize_BaseEnd, _dblWorkingLength_BaseEnd, _strPinMaterial)
        cmbPinClips_BaseEnd.Items.Clear()
        If Not IsNothing(_dtBaseEndPinsDataTable_Selected) Then
            For Each oDataRow As DataRow In _dtBaseEndPinsDataTable_Selected.Rows
                cmbPinClips_BaseEnd.Items.Add(oDataRow("ClipsType"))
            Next
            cmbPinClips_BaseEnd.Enabled = True
            'ANUP 08-11-2010 START
            'Clips_WhichAreToBeSelectedDefault_BaseEnd()    'ANUP 17-08-2010
            cmbPinClips_BaseEnd.SelectedIndex = 0
            Try
                cmbPinClips_BaseEnd.Text = "Cotter Pin"  '26_07_2011  RAGAVA
            Catch ex As Exception

            End Try
            'ANUP 08-11-2010 TILL HERE
        Else
            cmbPinClips_BaseEnd.Enabled = False
        End If

    End Sub

    'ANUP 17-08-2010
    Private Sub Clips_WhichAreToBeSelectedDefault_BaseEnd()
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbPins.Text = "Yes" Then
            If ObjClsWeldedCylinderFunctionalClass.CmbClips_BaseEnd.Text = "Hair Pin" Then
                cmbPinClips_BaseEnd.Text = "Hair Pin"
            ElseIf ObjClsWeldedCylinderFunctionalClass.CmbClips_BaseEnd.Text = "Cotter Pin" Then
                cmbPinClips_BaseEnd.Text = "Cotter Pin"
            ElseIf ObjClsWeldedCylinderFunctionalClass.CmbClips_BaseEnd.Text = "Cir Clips" Then
                cmbPinClips_BaseEnd.Text = "C-Clip"
            ElseIf ObjClsWeldedCylinderFunctionalClass.CmbClips_BaseEnd.Text = "R Clips" Then
                cmbPinClips_BaseEnd.Text = "R-Clip"
            End If
        Else
            cmbPinClips_BaseEnd.SelectedIndex = 0
        End If
    End Sub

    Private Sub cmbPinMaterial_RodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPinMaterial_RodEnd.SelectedIndexChanged
        PinMaterialVariable(cmbPinMaterial_RodEnd)
        _dblWorkingLength_RodEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetWorkingLength_Pins(_dblWorkingLengthCalculation_RodEnd)
        _dtRodEndPinsDataTable_Selected = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPinsClips_AccessoriesForm(cmbPinMaterial_RodEnd, _dblPinHoleSize_RodEnd, _dblWorkingLength_RodEnd, _strPinMaterial)
        cmbPinClips_RodEnd.Items.Clear()
        If Not IsNothing(_dtRodEndPinsDataTable_Selected) Then
            For Each oDataRow As DataRow In _dtRodEndPinsDataTable_Selected.Rows
                cmbPinClips_RodEnd.Items.Add(oDataRow("ClipsType"))
            Next
            cmbPinClips_RodEnd.Enabled = True
            'ANUP 08-11-2010 START
            ' Clips_WhichAreToBeSelectedDefault_RodEnd()   'ANUP 17-08-2010
            cmbPinClips_RodEnd.SelectedIndex = 0
            Try
                cmbPinClips_RodEnd.Text = "Cotter Pin"  '26_07_2011  RAGAVA
            Catch ex As Exception

            End Try
            'ANUP 08-11-2010 TILL HERE
        Else
            cmbPinClips_RodEnd.Enabled = False
        End If
    End Sub

    'ANUP 17-08-2010
    Private Sub Clips_WhichAreToBeSelectedDefault_RodEnd()
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.cmbPins_RodEnd.Text = "Yes" Then
            If ObjClsWeldedCylinderFunctionalClass.CmbClips_RodEnd.Text = "Hair Pin" Then
                cmbPinClips_RodEnd.Text = "Hair Pin"
            ElseIf ObjClsWeldedCylinderFunctionalClass.CmbClips_RodEnd.Text = "Cotter Pin" Then
                cmbPinClips_RodEnd.Text = "Cotter Pin"
            ElseIf ObjClsWeldedCylinderFunctionalClass.CmbClips_RodEnd.Text = "Cir Clips" Then
                cmbPinClips_RodEnd.Text = "C-Clip"
            ElseIf ObjClsWeldedCylinderFunctionalClass.CmbClips_RodEnd.Text = "R Clips" Then
                cmbPinClips_RodEnd.Text = "R-Clip"
            End If
        Else
            cmbPinClips_RodEnd.SelectedIndex = 0
        End If
    End Sub

    Private Sub frmPin_Port_PaintAccessories_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        PinHoleSizeCalc()
        'ANUP 08-11-2010 START
        Pins_Default()

        'BaseEndPinsValidation()
        'RodEndPinsValidation()
        'ANUP 08-11-2010 TILL HERE
        'GreaseZercs_Adding()
        'ANUP 23-08-2010
        GreaseZercsBaseEnd_Adding()
        GreaseZercsRodEnd_Adding()

        PortSizeCalc()
        PortAccessories_Paint_DefaultSettings()
        'ANUP 08-11-2010 START
        chkPaint.Checked = True
        '   PaintValidation()
        'ANUP 08-11-2010 TILL HERE
    End Sub

    Private Sub chkBaseEndPortAccessories_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBaseEndPortAccessories.CheckedChanged
        Try
            cmbAccessoryType_BaseEnd.Items.Clear()
            If chkBaseEndPortAccessories.Checked Then
                _blnIsBaseEndPortAccessoriesPresent = True
                cmbAccessoryType_BaseEnd.Enabled = True
                _dtPortAccessories_BaseEndDataTable = PortAccessoriesDataTable(chkBaseEndPortAccessories, _strPortSize_BaseEnd, _strPortType_BaseEnd)
                If Not IsNothing(_dtPortAccessories_BaseEndDataTable) AndAlso _dtPortAccessories_BaseEndDataTable.Rows.Count > 0 Then
                    For Each oDataRow As DataRow In _dtPortAccessories_BaseEndDataTable.Rows
                        cmbAccessoryType_BaseEnd.Items.Add(oDataRow("Accessory"))
                    Next
                    'ANUP 11-10-2010 START
                    AddingExtraTwoValuesToAccessoryComboBox(cmbAccessoryType_BaseEnd)
                    'anup 22-12-2010 start
                Else
                    chkBaseEndPortAccessories.Checked = False
                    chkBaseEndPortAccessories.Enabled = False
                    'anup 22-12-2010 till here
                End If
                'ANUP 08-11-2010 START
                'cmbAccessoryType_BaseEnd.SelectedIndex = 0
                cmbAccessoryType_BaseEnd.Text = "Dust Plug"
                'ANUP 08-11-2010 TILL HERE
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd = 2 Then
                '    chkBaseEndPortAccessories2.Enabled = True
                '    chkBaseEndPortAccessories2.Checked = True
                '    cmbAccessoryType2_BaseEnd.Enabled = True
                'End If

                'MANJULA 14-02-12

                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBasePlugTwoPorts = False Then
                    chkBaseEndPortAccessories2.Enabled = True
                    chkBaseEndPortAccessories2.Checked = True
                    cmbAccessoryType2_BaseEnd.Enabled = True
                Else
                    chkBaseEndPortAccessories2.Enabled = False
                    chkBaseEndPortAccessories2.Checked = False
                    cmbAccessoryType2_BaseEnd.Enabled = False

                End If
                '*********

            Else
                cmbAccessoryType2_BaseEnd.Items.Clear()
                _blnIsBaseEndPortAccessoriesPresent = False
                cmbAccessoryType_BaseEnd.Enabled = False
                chkBaseEndPortAccessories2.Checked = False
                chkBaseEndPortAccessories2.Enabled = False
                cmbAccessoryType2_BaseEnd.Enabled = False

                'ANUP 11-10-2010 TILL HERE
            End If

        Catch ex As Exception

        End Try
    End Sub

    'ANUP 11-10-2010 START
    Private Sub PortAccessories_Paint_DefaultSettings()
        '   If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd = 2 Then
        'ANUP 08-11-2010 START

        If Not _dblNumberOfPorts_BaseEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd Then

            _dblNumberOfPorts_BaseEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd
            chkBaseEndPortAccessories.Checked = False

            cmbAccessoryType_BaseEnd.Items.Clear()
            cmbAccessoryType_BaseEnd.Enabled = False
            cmbAccessoryType2_BaseEnd.Items.Clear()
            chkBaseEndPortAccessories.Checked = True
            cmbAccessoryType2_BaseEnd.Enabled = False
            chkBaseEndPortAccessories2.Enabled = False
            chkBaseEndPortAccessories2.Checked = False

            'MANJULA 14-02-12 COMMENTED

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd = 2 Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd = 2 OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBasePlugTwoPorts = False Then       '15_11_2011   RAGAVA
                    chkBaseEndPortAccessories2.Enabled = True
                    chkBaseEndPortAccessories2.Checked = True
                    cmbAccessoryType2_BaseEnd.Enabled = True

                End If

            End If
        End If

        If Not _dblNumberOfPorts_RodEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd Then
            _dblNumberOfPorts_RodEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd
            chkRodEndPortAccessories.Checked = False
            chkRodEndPortAccessories2.Enabled = False
            cmbAccessoryType_RodEnd.Items.Clear()
            cmbAccessoryType_RodEnd.Enabled = False
            cmbAccessoryType2_RodEnd.Items.Clear()
            cmbAccessoryType2_RodEnd.Enabled = False
            chkRodEndPortAccessories.Checked = True

            'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd = 2 Then
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd = 2 OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBasePlugTwoPorts_RodEnd = True Then       '15_11_2011   RAGAVA
                chkRodEndPortAccessories2.Enabled = True
                chkRodEndPortAccessories2.Checked = True
                cmbAccessoryType2_RodEnd.Enabled = True
            End If

        End If

        ' MANJULA 14-02-2012

        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnBasePlugTwoPorts = False Then
            'vamsi 12th august 2013 start commented
            'chkBaseEndPortAccessories2.Enabled = True
            'chkBaseEndPortAccessories2.Checked = True
            'cmbAccessoryType2_BaseEnd.Enabled = True

            'till here
        Else
            chkBaseEndPortAccessories2.Enabled = False
            chkBaseEndPortAccessories2.Checked = False
            cmbAccessoryType2_BaseEnd.Enabled = False

        End If

        '*********


        '  End If
        ' cmbPaint.Enabled = False
        'ANUP 08-11-2010 TILL HERE
    End Sub

    Private Sub AddingExtraTwoValuesToAccessoryComboBox(ByVal oComboBox As ComboBox)
        Try
            oComboBox.Items.Add("Dust Plug")
            oComboBox.Items.Add("Permanent Plug")
        Catch ex As Exception

        End Try
    End Sub
    'ANUP 11-10-2010 TILL HERE

    Private Sub PortSizeCalc()
        Try
            _strPortSize_BaseEnd = ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text
            _strPortSize_RodEnd = ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.Text
            _strPortType_BaseEnd = ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeBaseEnd.Text
            _strPortType_RodEnd = ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Function PortAccessoriesDataTable(ByVal clPortAccessory As Control, ByVal strPortSize As String, ByVal strPortType As String, Optional ByVal strPortAccessoryType As String = "") As DataTable
        PortAccessoriesDataTable = Nothing
        Try
            PortAccessoriesDataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.PortAccessories_DataTable(clPortAccessory, strPortSize, strPortType, strPortAccessoryType)
            If IsNothing(PortAccessoriesDataTable) OrElse PortAccessoriesDataTable.Rows.Count <= 0 Then
                PortAccessoriesDataTable = Nothing
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Sub chkRodEndPortAccessories_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRodEndPortAccessories.CheckedChanged
        Try
            cmbAccessoryType_RodEnd.Items.Clear()
            If chkRodEndPortAccessories.Checked Then
                _blnIsRodEndPortAccessoriesPresent = True
                cmbAccessoryType_RodEnd.Enabled = True
                _dtPortAccessories_RodEndDataTable = PortAccessoriesDataTable(chkRodEndPortAccessories, _strPortSize_RodEnd, _strPortType_RodEnd)
                If Not IsNothing(_dtPortAccessories_RodEndDataTable) AndAlso _dtPortAccessories_RodEndDataTable.Rows.Count > 0 Then
                    For Each oDataRow As DataRow In _dtPortAccessories_RodEndDataTable.Rows
                        cmbAccessoryType_RodEnd.Items.Add(oDataRow("Accessory"))
                    Next
                    'ANUP 11-10-2010 START
                    AddingExtraTwoValuesToAccessoryComboBox(cmbAccessoryType_RodEnd)
                    'anup 22-12-2010 start
                Else
                    chkRodEndPortAccessories.Checked = False
                    chkRodEndPortAccessories.Enabled = False
                    'anup 22-12-2010 till here
                End If
                'ANUP 08-11-2010 START
                ' cmbAccessoryType_RodEnd.SelectedIndex = 0
                cmbAccessoryType_RodEnd.Text = "Dust Plug"
                'ANUP 08-11-2010 TILL HERE
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd = 2 Then
                    chkRodEndPortAccessories2.Enabled = True
                    chkRodEndPortAccessories2.Checked = True
                    cmbAccessoryType2_RodEnd.Enabled = True
                End If
            Else
                _blnIsRodEndPortAccessoriesPresent = False
                cmbAccessoryType_RodEnd.Enabled = False
                chkRodEndPortAccessories2.Checked = False
                chkRodEndPortAccessories2.Enabled = False
                cmbRodGreaseZercType2.Items.Clear()
                cmbRodGreaseZercType2.Enabled = False
                'ANUP 11-10-2010 TILL HERE
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbPinClips_BaseEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPinClips_BaseEnd.SelectedIndexChanged
        Try
            Dim strPinClips As String = cmbPinClips_BaseEnd.Text
            If Not IsNothing(strPinClips) Then
                'ANUP 08-11-2010 START
                'SelectedClipsAdding_BaseEndConfiguration(strPinClips)     'ANUP 17-08-2010
                'ANUP 08-11-2010 TILL HERE
                _dtBaseEndPinsDataTable_Selected = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPinsClips_AccessoriesForm(cmbPinClips_BaseEnd, _dblPinHoleSize_BaseEnd, _dblWorkingLength_BaseEnd, _strPinMaterial, strPinClips)
                For Each oDataRow As DataRow In _dtBaseEndPinsDataTable_Selected.Rows
                    _strPinCodeBE = oDataRow("PartCode").ToString 'Pin code is mentioned as PartCode in DB
                    _strClipCodeBE = oDataRow("PinCode").ToString 'Clip code is mentioned as PinCode in DB
                    _strPin_ClipCode_BaseEnd = _strPinCodeBE + "-" + _strClipCodeBE
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    'ANUP 17-08-2010
    Private Sub SelectedClipsAdding_BaseEndConfiguration(ByVal strClips As String)
        If strClips = "Hair Pin" Then
            ObjClsWeldedCylinderFunctionalClass.CmbClips_BaseEnd.Text = "Hair Pin"
        ElseIf strClips = "Cotter Pin" Then
            ObjClsWeldedCylinderFunctionalClass.CmbClips_BaseEnd.Text = "Cotter Pin"
        ElseIf strClips = "C-Clip" Then
            ObjClsWeldedCylinderFunctionalClass.CmbClips_BaseEnd.Text = "Cir Clips"
        ElseIf strClips = "R-Clip" Then
            ObjClsWeldedCylinderFunctionalClass.CmbClips_BaseEnd.Text = "R Clips"
        End If

    End Sub

    Private Sub cmbPinClips_RodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPinClips_RodEnd.SelectedIndexChanged
        Try
            Dim strPinClips As String = cmbPinClips_RodEnd.Text
            If Not IsNothing(strPinClips) Then
                'ANUP 08-11-2010 START
                '   SelectedClipsAdding_RodEndConfiguration(strPinClips)
                'ANUP 08-11-2010 TILL HERE
                _dtRodEndPinsDataTable_Selected = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPinsClips_AccessoriesForm(cmbPinClips_RodEnd, _dblPinHoleSize_RodEnd, _dblWorkingLength_RodEnd, _strPinMaterial, strPinClips)
                For Each oDataRow As DataRow In _dtRodEndPinsDataTable_Selected.Rows
                    _strPinCodeRE = oDataRow("PartCode").ToString 'Pin code is mentioned as PartCode in DB
                    _strClipCodeRE = oDataRow("PinCode").ToString 'Clip code is mentioned as PinCode in DB
                    _strPin_ClipCode_RodEnd = _strPinCodeRE + "-" + _strClipCodeRE
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub


    'ANUP 17-08-2010
    Private Sub SelectedClipsAdding_RodEndConfiguration(ByVal strClips As String)
        If strClips = "Hair Pin" Then
            ObjClsWeldedCylinderFunctionalClass.CmbClips_RodEnd.Text = "Hair Pin"
        ElseIf strClips = "Cotter Pin" Then
            ObjClsWeldedCylinderFunctionalClass.CmbClips_RodEnd.Text = "Cotter Pin"
        ElseIf strClips = "C-Clip" Then
            ObjClsWeldedCylinderFunctionalClass.CmbClips_RodEnd.Text = "Cir Clips"
        ElseIf strClips = "R-Clip" Then
            ObjClsWeldedCylinderFunctionalClass.CmbClips_RodEnd.Text = "R Clips"
        End If

    End Sub


    'Private Sub cmbAccessoryType_BaseEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAccessoryType_BaseEnd.SelectedIndexChanged
    '    Try
    '        Dim strccessoryType As String = cmbAccessoryType_BaseEnd.Text
    '        If Not IsNothing(strccessoryType) Then
    '            'ANUP 11-10-2010 START
    '            _strPortAccessoryCode_BaseEnd = ""         '22_10_2010   RAGAVA
    '            cmbAccessoryType2_BaseEnd.Items.Clear()
    '            If strccessoryType = "Dust Plug" OrElse strccessoryType = "Permanent Plug" Then
    '                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd = 2 Then
    '                    chkBaseEndPortAccessories2.Enabled = True
    '                    cmbAccessoryType2_BaseEnd.Enabled = True
    '                    AddingExtraTwoValuesToAccessoryComboBox(cmbAccessoryType2_BaseEnd)
    '                    'ANUP 08-11-2010 START
    '                    '  cmbAccessoryType2_BaseEnd.SelectedIndex = 0
    '                    chkBaseEndPortAccessories2.Checked = True
    '                    cmbAccessoryType2_BaseEnd.Text = "Permanent Plug"
    '                    'ANUP 08-11-2010 TILL HERE
    '                End If
    '            Else
    '                _dtPortAccessories_BaseEndDataTable = PortAccessoriesDataTable(cmbAccessoryType_BaseEnd, _strPortSize_BaseEnd, _strPortType_BaseEnd, strccessoryType)
    '                For Each oDataRow As DataRow In _dtPortAccessories_BaseEndDataTable.Rows
    '                    _strPortAccessoryCode_BaseEnd = oDataRow("Code1").ToString
    '                Next
    '                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd = 2 Then
    '                    chkBaseEndPortAccessories2.Enabled = True
    '                    chkBaseEndPortAccessories2.Checked = True
    '                    chkBaseEndPortAccessories2.Enabled = False
    '                    cmbAccessoryType2_BaseEnd.Enabled = True
    '                    cmbAccessoryType2_BaseEnd.Items.Add(strccessoryType)
    '                    cmbAccessoryType2_BaseEnd.SelectedIndex = 0
    '                    cmbAccessoryType2_BaseEnd.Enabled = False
    '                End If
    '            End If
    '                'ANUP 11-10-2010 TILL HERE
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub cmbAccessoryType_RodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAccessoryType_RodEnd.SelectedIndexChanged
    '    Try
    '        Dim strccessoryType As String = cmbAccessoryType_RodEnd.Text
    '        If Not IsNothing(strccessoryType) Then
    '            _strPortAccessoryCode_RodEnd = ""    '22_10_2010     RAGAVA
    '            cmbAccessoryType2_RodEnd.Items.Clear()
    '            If strccessoryType = "Dust Plug" OrElse strccessoryType = "Permanent Plug" Then
    '                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd = 2 Then
    '                    chkRodEndPortAccessories2.Enabled = True
    '                    cmbAccessoryType2_RodEnd.Enabled = True
    '                    AddingExtraTwoValuesToAccessoryComboBox(cmbAccessoryType2_RodEnd)
    '                    'ANUP 08-11-2010 START
    '                    '      cmbAccessoryType2_RodEnd.SelectedIndex = 0
    '                    chkRodEndPortAccessories2.Checked = True
    '                    cmbAccessoryType2_RodEnd.Text = "Permanent Plug"
    '                    'ANUP 08-11-2010 TILL HERE
    '                End If
    '            Else
    '                _dtPortAccessories_RodEndDataTable = PortAccessoriesDataTable(cmbAccessoryType_RodEnd, _strPortSize_RodEnd, _strPortType_RodEnd, strccessoryType)
    '                For Each oDataRow As DataRow In _dtPortAccessories_RodEndDataTable.Rows
    '                    _strPortAccessoryCode_RodEnd = oDataRow("Code1").ToString
    '                Next
    '                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd = 2 Then
    '                    chkRodEndPortAccessories2.Enabled = True
    '                    chkRodEndPortAccessories2.Checked = True
    '                    chkRodEndPortAccessories2.Enabled = False
    '                    cmbAccessoryType2_RodEnd.Enabled = True
    '                    cmbAccessoryType2_RodEnd.Items.Add(strccessoryType)
    '                    cmbAccessoryType2_RodEnd.SelectedIndex = 0
    '                    cmbAccessoryType2_RodEnd.Enabled = False
    '                End If
    '            End If
    '            'ANUP 11-10-2010 TILL HERE
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub cmbGreaseZercType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBaseGreaseZercType1.SelectedIndexChanged, cmbRodGreaseZercType1.SelectedIndexChanged, cmbRodGreaseZercType2.SelectedIndexChanged, cmbBaseGreaseZercType2.SelectedIndexChanged
    '    Try

    '        If Not IsNothing(cmbBaseGreaseZercType1.Text) AndAlso Trim(cmbBaseGreaseZercType1.Text.Length) > 0 Then
    '            Dim oDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetGreaseZercs_cmbGreaseZercTypeSelected_AccessoriesForm(cmbBaseGreaseZercType1.Text)
    '            _strGreaseZercCode = oDataRow("PartCode").ToString
    '        Else
    '            _strGreaseZercCode = Nothing
    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub

    'ANUP 09-12-2010 START
    Private Sub cmbAccessoryType_BaseEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAccessoryType_BaseEnd.SelectedIndexChanged
        Try
            Dim strccessoryType As String = cmbAccessoryType_BaseEnd.Text
            If Not IsNothing(strccessoryType) Then
                'ANUP 11-10-2010 START
                _strPortAccessoryCode_BaseEnd = ""         '22_10_2010   RAGAVA
                ' cmbAccessoryType2_BaseEnd.Items.Clear()
                '  If strccessoryType = "Dust Plug" OrElse strccessoryType = "Permanent Plug" Then
                '   If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd = 2 Then
                'chkBaseEndPortAccessories2.Enabled = True
                ' cmbAccessoryType2_BaseEnd.Enabled = True
                ' AddingExtraTwoValuesToAccessoryComboBox(cmbAccessoryType2_BaseEnd)
                'ANUP 08-11-2010 START
                '  cmbAccessoryType2_BaseEnd.SelectedIndex = 0
                'chkBaseEndPortAccessories2.Checked = True
                'cmbAccessoryType2_BaseEnd.Text = "Permanent Plug"
                'ANUP 08-11-2010 TILL HERE
                ' End If
                ''Else
                _dtPortAccessories_BaseEndDataTable = PortAccessoriesDataTable(cmbAccessoryType_BaseEnd, _strPortSize_BaseEnd, _strPortType_BaseEnd, strccessoryType)
                If Not IsNothing(_dtPortAccessories_BaseEndDataTable) Then
                    For Each oDataRow As DataRow In _dtPortAccessories_BaseEndDataTable.Rows
                        _strPortAccessoryCode_BaseEnd = oDataRow("Code1").ToString
                        '  cmbAccessoryType2_BaseEnd.Items.Add(oDataRow("Accessory"))  'anup 24-12-2010 
                    Next
                End If

                ' '' AddingExtraTwoValuesToAccessoryComboBox(cmbAccessoryType2_BaseEnd)
                ''If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd = 2 Then
                ''    chkBaseEndPortAccessories2.Enabled = True
                ''    chkBaseEndPortAccessories2.Checked = True
                ''    ' chkBaseEndPortAccessories2.Enabled = False  'anup 24-12-2010 
                ''    cmbAccessoryType2_BaseEnd.Enabled = True
                ''    ' cmbAccessoryType2_BaseEnd.Items.Add(strccessoryType)  'anup 24-12-2010 
                ''    cmbAccessoryType2_BaseEnd.SelectedIndex = 0
                ''    '  cmbAccessoryType2_BaseEnd.Enabled = False 'anup 24-12-2010 
                ''End If
            End If
            'ANUP 11-10-2010 TILL HERE
            '  End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub cmbAccessoryType_RodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAccessoryType_RodEnd.SelectedIndexChanged
        Try
            Dim strccessoryType As String = cmbAccessoryType_RodEnd.Text
            If Not IsNothing(strccessoryType) Then
                _strPortAccessoryCode_RodEnd = ""    '22_10_2010     RAGAVA
                '    cmbAccessoryType2_RodEnd.Items.Clear()
                'If strccessoryType = "Dust Plug" OrElse strccessoryType = "Permanent Plug" Then
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd = 2 Then
                'chkRodEndPortAccessories2.Enabled = True
                ' cmbAccessoryType2_RodEnd.Enabled = True
                ' AddingExtraTwoValuesToAccessoryComboBox(cmbAccessoryType2_RodEnd)
                'ANUP 08-11-2010 START
                '      cmbAccessoryType2_RodEnd.SelectedIndex = 0
                '  chkRodEndPortAccessories2.Checked = True
                ' cmbAccessoryType2_RodEnd.Text = "Permanent Plug"
                'ANUP 08-11-2010 TILL HERE
                'End If
                ' Else
                _dtPortAccessories_RodEndDataTable = PortAccessoriesDataTable(cmbAccessoryType_RodEnd, _strPortSize_RodEnd, _strPortType_RodEnd, strccessoryType)
                If Not IsNothing(_dtPortAccessories_RodEndDataTable) Then
                    For Each oDataRow As DataRow In _dtPortAccessories_RodEndDataTable.Rows
                        _strPortAccessoryCode_RodEnd = oDataRow("Code1").ToString
                        'cmbAccessoryType2_RodEnd.Items.Add(oDataRow("Accessory"))  'anup 24-12-2010 
                    Next
                End If
                ' '' AddingExtraTwoValuesToAccessoryComboBox(cmbAccessoryType2_RodEnd)
                ''If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd = 2 Then
                ''    chkRodEndPortAccessories2.Enabled = True
                ''    chkRodEndPortAccessories2.Checked = True
                ''    'chkRodEndPortAccessories2.Enabled = False  'anup 24-12-2010 
                ''    cmbAccessoryType2_RodEnd.Enabled = True
                ''    ' cmbAccessoryType2_RodEnd.Items.Add(strccessoryType)  'anup 24-12-2010 
                ''    cmbAccessoryType2_RodEnd.SelectedIndex = 0
                ''    ' cmbAccessoryType2_RodEnd.Enabled = False  'anup 24-12-2010 
                ''End If
            End If
            'ANUP 11-10-2010 TILL HERE
            '  End If
        Catch ex As Exception

        End Try
    End Sub
    'ANUP 09-12-2010 TILL HERE


    Private Sub cmbGreaseZercType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBaseGreaseZercType1.SelectedIndexChanged, cmbRodGreaseZercType1.SelectedIndexChanged, cmbRodGreaseZercType2.SelectedIndexChanged, cmbBaseGreaseZercType2.SelectedIndexChanged
        Try
            Dim strGreaseZercPartCode As String = GreaseZercsSelectedIndex_Validation(sender)
            'anup commented on 30-08-2010 
            '_strGreaseZercCode_1_BaseEnd = Nothing
            '_strGreaseZercCode_2_BaseEnd = Nothing
            '_strGreaseZercCode_1_RodEnd = Nothing
            '_strGreaseZercCode_2_RodEnd = Nothing
            If sender.name = "cmbBaseGreaseZercType1" Then
                _strGreaseZercCode_1_BaseEnd = strGreaseZercPartCode
            ElseIf sender.name = "cmbBaseGreaseZercType2" Then
                _strGreaseZercCode_2_BaseEnd = strGreaseZercPartCode
            ElseIf sender.name = "cmbRodGreaseZercType1" Then
                _strGreaseZercCode_1_RodEnd = strGreaseZercPartCode
            ElseIf sender.name = "cmbRodGreaseZercType2" Then
                _strGreaseZercCode_2_RodEnd = strGreaseZercPartCode
            End If
        Catch ex As Exception

        End Try
    End Sub

    'ANUP 23-08-2010
    Private Function GreaseZercsSelectedIndex_Validation(ByVal CmbGreaseZerc As ComboBox) As String
        If Not IsNothing(CmbGreaseZerc.Text) AndAlso Trim(CmbGreaseZerc.Text.Length) > 0 Then
            Dim oDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetGreaseZercs_cmbGreaseZercTypeSelected_AccessoriesForm(CmbGreaseZerc.Text)
            GreaseZercsSelectedIndex_Validation = oDataRow("PartCode").ToString
        Else
            GreaseZercsSelectedIndex_Validation = Nothing
        End If
    End Function


    Private Sub PaintValidation()
        Dim dtPaintDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsMIL_TieRodDataClass.PaintDataTable()
        cmbPaint.Items.Clear()
        'TODO: ANUP 22-07-2010 10.19am
        'cmbPaint.Enabled = True
        If Not IsNothing(dtPaintDataTable) Then
            For Each oPaintDataRow As DataRow In dtPaintDataTable.Rows
                If Not IsDBNull(oPaintDataRow("PaintColor")) Then
                    cmbPaint.Items.Add(oPaintDataRow("PaintColor"))
                End If
            Next
            cmbPaint.SelectedIndex = 0
        Else
            cmbPaint.Enabled = False
        End If
    End Sub

    Private Sub cmbPaint_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPaint.SelectedIndexChanged
        If Not IsNothing(cmbPaint.Text) AndAlso Trim(cmbPaint.ToString.Length) > 0 Then
            _strPaintCode = ObjClsWeldedCylinderFunctionalClass.ObjClsMIL_TieRodDataClass.GetPaintCode(cmbPaint.Text)
        Else
            _strPaintCode = Nothing
        End If
    End Sub

#End Region

    Private Sub chkBaseEndPortAccessories2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBaseEndPortAccessories2.CheckedChanged
        Try
            If chkBaseEndPortAccessories2.Checked Then
                cmbAccessoryType2_BaseEnd.Items.Clear()
                _blnIsBaseEndPortAccessories2Present = True 'anup 27-12-2010 
                _dtPortAccessories_BaseEndDataTable = PortAccessoriesDataTable(chkBaseEndPortAccessories, _strPortSize_BaseEnd, _strPortType_BaseEnd)
                If Not IsNothing(_dtPortAccessories_BaseEndDataTable) AndAlso _dtPortAccessories_BaseEndDataTable.Rows.Count > 0 Then
                    For Each oDataRow As DataRow In _dtPortAccessories_BaseEndDataTable.Rows
                        cmbAccessoryType2_BaseEnd.Items.Add(oDataRow("Accessory"))
                    Next
                    AddingExtraTwoValuesToAccessoryComboBox(cmbAccessoryType2_BaseEnd)
                Else
                    chkBaseEndPortAccessories2.Checked = False
                    chkBaseEndPortAccessories2.Enabled = False
                End If
                cmbAccessoryType2_BaseEnd.SelectedIndex = 0
                Try
                    cmbAccessoryType2_BaseEnd.Text = "Permanent Plug"        '26_07_2011   RAGAVA
                Catch ex As Exception

                End Try
                cmbAccessoryType2_BaseEnd.Enabled = True

            Else
                _blnIsBaseEndPortAccessories2Present = False 'anup 27-12-2010 
                cmbAccessoryType2_BaseEnd.SelectedIndex = -1
                cmbAccessoryType2_BaseEnd.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkRodEndPortAccessories2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRodEndPortAccessories2.CheckedChanged
        Try
            If chkRodEndPortAccessories2.Checked Then
                cmbAccessoryType2_RodEnd.Items.Clear()
                _blnIsRodEndPortAccessories2Present = True   'anup 27-12-2010 
                _dtPortAccessories_RodEndDataTable = PortAccessoriesDataTable(chkRodEndPortAccessories, _strPortSize_RodEnd, _strPortType_RodEnd)
                If Not IsNothing(_dtPortAccessories_RodEndDataTable) AndAlso _dtPortAccessories_RodEndDataTable.Rows.Count > 0 Then
                    For Each oDataRow As DataRow In _dtPortAccessories_RodEndDataTable.Rows
                        cmbAccessoryType2_RodEnd.Items.Add(oDataRow("Accessory"))
                    Next
                    AddingExtraTwoValuesToAccessoryComboBox(cmbAccessoryType2_RodEnd)
                Else
                    chkRodEndPortAccessories2.Checked = False
                    chkRodEndPortAccessories2.Enabled = False
                End If
                cmbAccessoryType2_RodEnd.SelectedIndex = 0
                Try
                    cmbAccessoryType2_RodEnd.Text = "Permanent Plug"         '26_07_2011   RAGAVA
                Catch ex As Exception

                End Try
                'ANUP 08-11-2010 START
                'If cmbAccessoryType_RodEnd.Text = "Dust Plug" Then
                'cmbAccessoryType2_RodEnd.Text = "Permanent Plug"
                'End If
                'ANUP 08-11-2010 TILL HERE
                cmbAccessoryType2_RodEnd.Enabled = True
            Else
                _blnIsRodEndPortAccessories2Present = False  'anup 27-12-2010 
                cmbAccessoryType2_RodEnd.SelectedIndex = -1
                cmbAccessoryType2_RodEnd.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    'ANUP 08-11-2010 START
    Private Sub cmbPins_BaseEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPins_BaseEnd.SelectedIndexChanged
        Try
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinsYesOrNo = cmbPins_BaseEnd.Text
            If cmbPins_BaseEnd.Text = "Yes" Then
                cmbPinMaterial_BaseEnd.Enabled = True
                cmbPinClips_BaseEnd.Enabled = True
                _blnIsBaseEndPinsPresent = True 'ANUP 09-11-2010 START
                BaseEndPinsValidation()
            ElseIf cmbPins_BaseEnd.Text = "No" Then
                cmbPinMaterial_BaseEnd.Items.Clear()
                cmbPinClips_BaseEnd.Items.Clear()
                cmbPinMaterial_BaseEnd.Enabled = False
                cmbPinClips_BaseEnd.Enabled = False
                _blnIsBaseEndPinsPresent = False 'ANUP 09-11-2010 START
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbPins_RodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPins_RodEnd.SelectedIndexChanged
        Try
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.Pins_RodEnd = cmbPins_RodEnd.Text
            If cmbPins_RodEnd.Text = "Yes" Then
                cmbPinMaterial_RodEnd.Enabled = True
                cmbPinClips_RodEnd.Enabled = True
                _blnIsRodEndPinsPresent = True 'ANUP 09-11-2010 START
                RodEndPinsValidation()
            ElseIf cmbPins_RodEnd.Text = "No" Then
                cmbPinMaterial_RodEnd.Items.Clear()
                cmbPinClips_RodEnd.Items.Clear()
                cmbPinMaterial_RodEnd.Enabled = False
                cmbPinClips_RodEnd.Enabled = False
                _blnIsRodEndPinsPresent = False 'ANUP 09-11-2010 START
            End If
        Catch ex As Exception

        End Try
    End Sub
    'ANUP 08-11-2010 TILL HERE

    Private Sub cmbAccessoryType2_BaseEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAccessoryType2_BaseEnd.SelectedIndexChanged
        Try
            Dim strccessoryType As String = cmbAccessoryType2_BaseEnd.Text
            _dtPortAccessories2_BaseEndDataTable = PortAccessoriesDataTable(cmbAccessoryType2_BaseEnd, _strPortSize_BaseEnd, _strPortType_BaseEnd, strccessoryType)
            For Each oDataRow As DataRow In _dtPortAccessories2_BaseEndDataTable.Rows
                _strPortAccessory2Code_BaseEnd = oDataRow("Code1").ToString
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbAccessoryType2_RodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAccessoryType2_RodEnd.SelectedIndexChanged
        Try
            Dim strccessoryType As String = cmbAccessoryType2_RodEnd.Text
            _dtPortAccessories2_RodEndDataTable = PortAccessoriesDataTable(cmbAccessoryType2_RodEnd, _strPortSize_BaseEnd, _strPortType_BaseEnd, strccessoryType)
            For Each oDataRow As DataRow In _dtPortAccessories2_RodEndDataTable.Rows
                _strPortAccessory2Code_RodEnd = oDataRow("Code1").ToString
            Next
        Catch ex As Exception

        End Try
    End Sub

    '06_06_2011  RAGAVA
    Public Function GetPinKits_Details(ByVal strPinCode As String, ByVal strClip As String, ByVal strBaseOrRod As String) As String
        Try
            GetPinKits_Details = String.Empty
            Dim strQuery As String = ""
            If strBaseOrRod = "BASE" Then
                strQuery = "select PinKitCodeNumber from Pin_Kit_Details where FirstPin = '" & strPinCode & "' and ClipType = '" & strClip & "'"
            ElseIf strBaseOrRod = "ROD" Then
                strQuery = "select PinKitCodeNumber from Pin_Kit_Details where SecondPin = '" & strPinCode & "' and ClipType = '" & strClip & "'"
            End If
            Dim dr_KitCode As DataRow = MonarchConnectionObject.GetDataRow(strQuery)
            GetPinKits_Details = dr_KitCode("PinKitCodeNumber").ToString
            'If strPinCode = "268900" AndAlso strClip = "Cotter Pin" Then
            '    GetPinKits_Details = "235004"
            'ElseIf strPinCode = "134953" AndAlso strClip = "R-Clip" Then
            '    GetPinKits_Details = "235012"
            'ElseIf strPinCode = "134953" AndAlso strClip = "Cotter Pin" Then
            '    GetPinKits_Details = "235005"
            'ElseIf strPinCode = "257832" AndAlso strClip = "Cotter Pin" Then
            '    GetPinKits_Details = "235006"
            'ElseIf strPinCode = "257835" AndAlso strClip = "Cotter Pin" Then
            '    GetPinKits_Details = "235007"
            '    'ObjClsWeldedCylinderFunctionalClass.CmbClips_BaseEnd.Text = "Hair Pin"
            'End If
        Catch ex As Exception
        End Try
    End Function

    '06_06_2011  RAGAVA
    Public Function Validate_PinandClipsNotes() As Boolean
        Try
            Dim strKitCode_BaseEnd As String = GetPinKits_Details(_strPinCodeBE, ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbPinClips_BaseEnd.Text, "BASE")
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndKitCode = strKitCode_BaseEnd         '06_06_2011   RAGAVA
            Dim strKitCode_RodEnd As String = GetPinKits_Details(_strPinCodeRE, ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbPinClips_RodEnd.Text, "ROD")
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndKitCode = strKitCode_RodEnd         '06_06_2011   RAGAVA
            If strKitCode_BaseEnd = strKitCode_RodEnd AndAlso (strKitCode_BaseEnd <> "" Or strKitCode_RodEnd <> "") Then
                Validate_PinandClipsNotes = True
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnInstallPinsandClips = False
            Else
                Validate_PinandClipsNotes = False
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnInstallPinsandClips = True
            End If
        Catch ex As Exception
        End Try
    End Function
End Class
