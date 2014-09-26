Imports System.IO
Public Class CMSUtil

    Private _message As String

    Public ReadOnly Property Message() As String
        Get
            Return _message
        End Get
    End Property

    Public Function Start(ByVal strFolderPath As String) As Boolean
        _message = String.Empty
        Dim oMTHL_TubeProcess As New MTHL_TubeProcess          '01_11_2010   RAGAVA

        If Not CVSFileUtil.isFolder(strFolderPath) Then
            _message = strFolderPath & " is not a folder path or exits."
            Return False
        End If

        'Routing METHDR
        DoProcess(New METHDR_CompleteCylinderProcess, strFolderPath)

        DoProcess(New METHDR_TubeProcess, strFolderPath)

        DoProcess(New METHDR_RodProcess, strFolderPath)

        'DoProcess(New METHDR_LugProcess, strFolderPath)        '08_12_2011   RAGAVA   COMMENTED

        'Tooling MTHL
        DoProcess(New MTHL_TubeProcess, strFolderPath)

        DoProcess(New MTHL_RodProcess, strFolderPath)

        DoProcess(New MTHL_CylinderProcess, strFolderPath)

        Try
            '08_12_2011   RAGAVA   COMMENTED
            'Dim strData As String = String.Empty
            'Dim FileName As String = String.Empty
            'strData = oMTHL_TubeProcess.MTHL_BASEEND_LUG(FileName)
            'If FileName <> "" Then
            '    CVSFileUtil.Write(strData, strFolderPath & "\MTHL" & FileName & ".csv")
            'End If
            'FileName = ""
            'strData = oMTHL_TubeProcess.MTHL_RODEND_LUG(FileName)
            'If FileName <> "" Then
            '    CVSFileUtil.Write(strData, strFolderPath & "\MTHL" & FileName & ".csv")
            'End If
        Catch ex As Exception

        End Try


        Dim oMETHE As New clsMETHE_Process
        'oMETHE.METHE_WeldedCylinder_Functionality()
        oMETHE.METHE_WeldedCylinder_Functionality(strFolderPath)      '27_06_2011  RAGAVA

        '16_12_2010   RAGAVA
        Try
            ShuffleCMSfiles(strFolderPath)
        Catch ex As Exception
        End Try
        'Till    Here
        Return True
    End Function




    '16_12_2010       RAGAVA
    Private Sub ShuffleCMSfiles(ByVal strFolderPath As String)
        Try
            reEnteringFileData(strFolderPath)
            Dim strFileList() As String = Directory.GetFiles(strFolderPath)

            'CYLINDER
            Directory.CreateDirectory(strFolderPath & "\CYLINDER" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString)
            For Each strfile As String In strFileList
                If strfile.EndsWith(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber & ".csv") = True Then
                    strfile = strfile.Substring(strfile.LastIndexOf("\") + 1, strfile.Length - (strfile.LastIndexOf("\") + 1))
                    File.Move(strFolderPath & "\" & strfile, strFolderPath & "\CYLINDER" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & "\" & strfile.Replace(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber, "RO"))
                End If
            Next
            Try
                ReModify_STKAfiles(strFolderPath & "\CYLINDER" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString)            '10_01_2011   RAGAVA
            Catch ex As Exception
            End Try

            'TUBE WELDMENT
            Dim strTubeWeldment As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT")
            Directory.CreateDirectory(strFolderPath & "\TUBE" & strTubeWeldment.ToString)
            For Each strfile As String In strFileList
                If strfile.EndsWith(strTubeWeldment & ".csv") = True Then
                    strfile = strfile.Substring(strfile.LastIndexOf("\") + 1, strfile.Length - (strfile.LastIndexOf("\") + 1))
                    File.Move(strFolderPath & "\" & strfile, strFolderPath & "\TUBE" & strTubeWeldment.ToString & "\" & strfile.Replace(strTubeWeldment, "RO"))
                End If
            Next
            Try
                ReModify_STKAfiles(strFolderPath & "\TUBE" & strTubeWeldment.ToString)            '10_01_2011   RAGAVA
            Catch ex As Exception
            End Try

            'ROD WELDMENT
            Dim strRodWeldment As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT")
            Directory.CreateDirectory(strFolderPath & "\ROD" & strRodWeldment.ToString)
            For Each strfile As String In strFileList
                If strfile.EndsWith(strRodWeldment & ".csv") = True Then
                    strfile = strfile.Substring(strfile.LastIndexOf("\") + 1, strfile.Length - (strfile.LastIndexOf("\") + 1))
                    File.Move(strFolderPath & "\" & strfile, strFolderPath & "\ROD" & strRodWeldment.ToString & "\" & strfile.Replace(strRodWeldment, "RO"))
                End If
            Next
            Try
                ReModify_STKAfiles(strFolderPath & "\ROD" & strRodWeldment.ToString)            '10_01_2011   RAGAVA
            Catch ex As Exception
            End Try

            'BASE END LUG
            ' If Trim(ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode) = "" Then 'anup 18-03-2011
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2 = "Fabricated" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" Then
                    Dim strBaseLug As String = ""
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated" Then
                        strBaseLug = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2 = "Fabricated" Then
                        strBaseLug = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2
                    End If
                    If (Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd) <> "" _
                    OrElse Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2) <> "") _
                    AndAlso (Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd) >= _
                    Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) _
                    OrElse Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2) >= _
                    Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart)) _
                    OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Lug_BE Then 'anup 10-03-2011

                        Directory.CreateDirectory(strFolderPath & "\BASELUG" & strBaseLug)
                        For Each strfile As String In strFileList
                            If strfile.EndsWith(strBaseLug & ".csv") = True Then
                                strfile = strfile.Substring(strfile.LastIndexOf("\") + 1, strfile.Length - (strfile.LastIndexOf("\") + 1))
                                File.Move(strFolderPath & "\" & strfile, strFolderPath & "\BASELUG" & strBaseLug.ToString & "\" & strfile.Replace(strBaseLug, "RO"))
                            End If
                        Next
                        Try
                            ReModify_STKAfiles(strFolderPath & "\BASELUG" & strBaseLug)            '10_01_2011   RAGAVA
                        Catch ex As Exception
                        End Try
                    End If
                End If
            End If
            '     End If

            'ROD END LUG 
            '  If Trim(ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode) = "" Then  'anup 18-03-2011
            If ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" Then
                    If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd) <> "" AndAlso Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd) >= Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Lug_RE Then  'anup 10-03-2011
                        Dim strRodLug As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd
                        Directory.CreateDirectory(strFolderPath & "\RODLUG" & strRodLug)
                        For Each strfile As String In strFileList
                            If strfile.EndsWith(strRodLug & ".csv") = True Then
                                strfile = strfile.Substring(strfile.LastIndexOf("\") + 1, strfile.Length - (strfile.LastIndexOf("\") + 1))
                                File.Move(strFolderPath & "\" & strfile, strFolderPath & "\RODLUG" & strRodLug.ToString & "\" & strfile.Replace(strRodLug, "RO"))
                            End If
                        Next
                        Try
                            ReModify_STKAfiles(strFolderPath & "\RODLUG" & strRodLug)            '10_01_2011   RAGAVA
                        Catch ex As Exception
                        End Try
                    End If
                End If
            End If
            '  End If

            'CYLINDER HEAD
            Dim oExistingListItems_CylinderHead As clsList = clsAddExistingCodes._htExistingCostingCodeList(clsAddExistingCodes.CYLINDERHEADCODE)
            If Not oExistingListItems_CylinderHead Is Nothing Then
                Dim strCylinderCode As String = oExistingListItems_CylinderHead.strPartCode
                If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strCylinderCode) Then 'OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_CylinderHead Then 'anup 28-02-2011 commented
                    Directory.CreateDirectory(strFolderPath & "\CYLINDERHEAD" & strCylinderCode)
                    For Each strfile As String In strFileList
                        If strfile.EndsWith(strCylinderCode & ".csv") = True Then
                            strfile = strfile.Substring(strfile.LastIndexOf("\") + 1, strfile.Length - (strfile.LastIndexOf("\") + 1))
                            File.Move(strFolderPath & "\" & strfile, strFolderPath & "\CYLINDERHEAD" & strCylinderCode.ToString & "\" & strfile.Replace(strCylinderCode, "RO"))
                        End If
                    Next
                    Try
                        ReModify_STKAfiles(strFolderPath & "\CYLINDERHEAD" & strCylinderCode)            '10_01_2011   RAGAVA
                    Catch ex As Exception
                    End Try
                End If
            End If

            'PISTON
            Dim oExistingListItems_Piston As clsList = clsAddExistingCodes._htExistingCostingCodeList(clsAddExistingCodes.PISTONCODE)
            If Not oExistingListItems_Piston Is Nothing Then
                Dim strPistonCode As String = oExistingListItems_Piston.strPartCode
                If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strPistonCode) Then 'OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Piston Then  'anup 28-02-2011 commented
                    Directory.CreateDirectory(strFolderPath & "\PISTON" & strPistonCode)
                    For Each strfile As String In strFileList
                        If strfile.EndsWith(strPistonCode & ".csv") = True Then
                            strfile = strfile.Substring(strfile.LastIndexOf("\") + 1, strfile.Length - (strfile.LastIndexOf("\") + 1))
                            File.Move(strFolderPath & "\" & strfile, strFolderPath & "\PISTON" & strPistonCode.ToString & "\" & strfile.Replace(strPistonCode, "RO"))
                        End If
                    Next
                    Try
                        ReModify_STKAfiles(strFolderPath & "\PISTON" & strPistonCode)            '10_01_2011   RAGAVA
                    Catch ex As Exception
                    End Try
                End If
            End If

            'BASE END CROSS TUBE
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" Then
                If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType) = "FABRICATED" OrElse UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2) = "FABRICATED" Then
                    Dim strBaseCrossTubeCode As String = ""
                    strBaseCrossTubeCode = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart)
                    If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strBaseCrossTubeCode) OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_CrossTube_BE Then  'anup 10-03-2011
                        If Directory.Exists(strFolderPath & "\BASECROSSTUBE" & strBaseCrossTubeCode) = False Then
                            Directory.CreateDirectory(strFolderPath & "\BASECROSSTUBE" & strBaseCrossTubeCode)
                        End If
                        For Each strfile As String In strFileList
                            If strfile.EndsWith(strBaseCrossTubeCode & ".csv") = True Then
                                strfile = strfile.Substring(strfile.LastIndexOf("\") + 1, strfile.Length - (strfile.LastIndexOf("\") + 1))
                                If File.Exists(strFolderPath & "\" & strfile) Then
                                    File.Move(strFolderPath & "\" & strfile, strFolderPath & "\BASECROSSTUBE" & strBaseCrossTubeCode.ToString & "\" & strfile.Replace(strBaseCrossTubeCode, "RO"))
                                End If
                            End If
                        Next
                        Try
                            ReModify_STKAfiles(strFolderPath & "\BASECROSSTUBE" & strBaseCrossTubeCode)            '10_01_2011   RAGAVA
                        Catch ex As Exception
                        End Try
                    End If
                End If
            End If

            'ROD END CROSS TUBE
            '  If Trim(ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode) = "" Then  'anup 18-03-2011
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
                If UCase(ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated) = "FABRICATED" Then 'OrElse UCase(ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated2) = "FABRICATED" Then        '31_08_2012   RAGAVA  Commented   Weldment
                    Dim strRodCrossTubeCode As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_CROSSTUBE_IFL")
                    If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strRodCrossTubeCode) OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_CrossTube_RE Then 'anup 10-03-2011
                        If Directory.Exists(strFolderPath & "\RODCROSSTUBE" & strRodCrossTubeCode) = False Then
                            Directory.CreateDirectory(strFolderPath & "\RODCROSSTUBE" & strRodCrossTubeCode)
                        End If
                        For Each strfile As String In strFileList
                            If strfile.EndsWith(strRodCrossTubeCode & ".csv") = True Then
                                strfile = strfile.Substring(strfile.LastIndexOf("\") + 1, strfile.Length - (strfile.LastIndexOf("\") + 1))
                                If File.Exists(strFolderPath & "\" & strfile) Then
                                    File.Move(strFolderPath & "\" & strfile, strFolderPath & "\RODCROSSTUBE" & strRodCrossTubeCode.ToString & "\" & strfile.Replace(strRodCrossTubeCode, "RO"))
                                End If
                            End If
                        Next
                        Try
                            ReModify_STKAfiles(strFolderPath & "\RODCROSSTUBE" & strRodCrossTubeCode)            '10_01_2011   RAGAVA
                        Catch ex As Exception
                        End Try
                    End If
                End If
            End If
            ' End If

            'BASE END CASTING
            '  If Trim(ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode) = "" Then 'anup 18-03-2011
            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType) = "CAST" OrElse UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2) = "CAST" Then
                Dim strBaseEndCast As String = ""
                If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType) = "CAST" Then
                    strBaseEndCast = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd)
                ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2) = "CAST" Then
                    strBaseEndCast = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd2)
                End If
                If Trim(strBaseEndCast) <> "" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName) _
                OrElse Trim(strBaseEndCast) <> "" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName2) Then

                    If strBaseEndCast = "" Then
                        strBaseEndCast = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart)
                    End If
                    If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strBaseEndCast) OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Casting_BE Then  'anup 10-03-2011
                        If Directory.Exists(strFolderPath & "\BASEENDCAST" & strBaseEndCast) = False Then
                            Directory.CreateDirectory(strFolderPath & "\BASEENDCAST" & strBaseEndCast)
                        End If
                        For Each strfile As String In strFileList
                            If strfile.EndsWith(strBaseEndCast & ".csv") = True Then
                                strfile = strfile.Substring(strfile.LastIndexOf("\") + 1, strfile.Length - (strfile.LastIndexOf("\") + 1))
                                If File.Exists(strFolderPath & "\" & strfile) Then
                                    File.Move(strFolderPath & "\" & strfile, strFolderPath & "\BASEENDCAST" & strBaseEndCast.ToString & "\" & strfile.Replace(strBaseEndCast, "RO"))
                                End If
                            End If
                        Next
                        Try
                            ReModify_STKAfiles(strFolderPath & "\BASEENDCAST" & strBaseEndCast)            '10_01_2011   RAGAVA
                        Catch ex As Exception
                        End Try
                    End If
                End If
            End If
            '      End If

            'ROD END CASTING
            ' If Trim(ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode) = "" Then         '14_10_2010   RAGAVA  'anup 18-03-2011
            If UCase(ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated) = "CAST" Then 'OrElse UCase(ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated2) = "CAST" Then       '31_08_2012   RAGAVA  Commented   Weldment
                'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName) Then

                '25_07_2012   RAGAVA
                'Dim strRodEndCast As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                Dim strRodEndCast As String = ""
                If UCase(ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated) = "CAST" Then
                    strRodEndCast = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                    '31_08_2012   RAGAVA  Commented   Weldment
                    'ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated2) = "CAST" Then
                    '    strRodEndCast = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName2)
                End If

                If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strRodEndCast) OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Casting_RE Then         '11_10_2010   RAGAVA  'anup 10-03-2011
                    If Directory.Exists(strFolderPath & "\RODENDCAST" & strRodEndCast) = False Then
                        Directory.CreateDirectory(strFolderPath & "\RODENDCAST" & strRodEndCast)
                    End If
                    For Each strfile As String In strFileList
                        If strfile.EndsWith(strRodEndCast & ".csv") = True Then
                            strfile = strfile.Substring(strfile.LastIndexOf("\") + 1, strfile.Length - (strfile.LastIndexOf("\") + 1))
                            If File.Exists(strFolderPath & "\" & strfile) Then
                                File.Move(strFolderPath & "\" & strfile, strFolderPath & "\RODENDCAST" & strRodEndCast.ToString & "\" & strfile.Replace(strRodEndCast, "RO"))
                            End If
                        End If
                    Next
                    Try
                        ReModify_STKAfiles(strFolderPath & "\RODENDCAST" & strRodEndCast)            '10_01_2011   RAGAVA
                    Catch ex As Exception
                    End Try
                End If
                'End If
            End If
            '    End If

            'STOP TUBE
            Dim strStopTubeCode As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("Stop_tube")
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkStopTube.Checked = True Then       '07_03_2011   RAGAVA
                If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strStopTubeCode) OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_StopTube Then  'anup 10-03-2011
                    Directory.CreateDirectory(strFolderPath & "\STOPTUBE" & strStopTubeCode)
                    For Each strfile As String In strFileList
                        If strfile.EndsWith(strStopTubeCode & ".csv") = True Then
                            strfile = strfile.Substring(strfile.LastIndexOf("\") + 1, strfile.Length - (strfile.LastIndexOf("\") + 1))
                            File.Move(strFolderPath & "\" & strfile, strFolderPath & "\STOPTUBE" & strStopTubeCode.ToString & "\" & strfile.Replace(strStopTubeCode, "RO"))
                        End If
                    Next
                    Try
                        ReModify_STKAfiles(strFolderPath & "\STOPTUBE" & strStopTubeCode)            '10_01_2011   RAGAVA
                    Catch ex As Exception
                    End Try
                End If
            End If
            '19-07-2012    RAGAVA
            Dim strBaseEndCasting As String = ""
            Dim strBaseEndFabrication As String = ""
            'strBaseEndCasting = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
            strBaseEndCasting = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingPart)
            strBaseEndFabrication = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart)
            'If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd) <> "" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName) Then
            '    strBaseEndCasting = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd)
            'End If
            If ObjClsWeldedCylinderFunctionalClass.IsReleaseCylinderChecked Then   '23_06_2011  RAGAVA
                Dim oClsReleaseCylinderFunctionality As New clsReleaseCylinderFunctionality
                oClsReleaseCylinderFunctionality.DropRod_Tube_StoptubeCodesToDB(strTubeWeldment, strRodWeldment, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber, _
                oExistingListItems_CylinderHead.strPartCode, oExistingListItems_Piston.strPartCode, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName), _
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName), _
                strBaseEndCasting, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName), strStopTubeCode)
            End If

        Catch ex As Exception
            'MsgBox("Error in Shuffling CMS files")
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error in Shuffling CMS Files")
        End Try
    End Sub
    'MANJULA 27-03-2012

    Private Sub reEnteringFileData(ByVal strFolderLocation As String)
        Try
            Dim strFiles As String() = Directory.GetFiles(strFolderLocation)
            For Each strFile As String In strFiles
                Dim sr As New StreamReader(strFile)
                Dim fs1 As New FileStream(strFolderLocation & "\dummy.txt", FileMode.Create)
                Dim sw As New StreamWriter(fs1)

                Dim listText As New List(Of String)

                While (Not (sr.EndOfStream))
                    listText.Add(sr.ReadLine())
                End While

                For I As Integer = 0 To listText.Count - 1
                    If I = listText.Count - 1 Then
                        sw.Write(listText.Item(I))
                    Else
                        sw.WriteLine(listText.Item(I))
                    End If

                Next

                sw.Close()
                sr.Close()
                GC.Collect()
                File.Delete(strFile)

                File.Move(strFolderLocation & "\dummy.txt", strFile)
            Next
        Catch ex As Exception
        End Try

    End Sub

    '10_01_2011    RAGAVA
    Private Sub ReModify_STKAfiles(ByVal strFolderLocation As String)
        Try
            Dim strFiles As String() = Directory.GetFiles(strFolderLocation)
            For Each strFile As String In strFiles
                If strFile.IndexOf("STKA") <> -1 Then
                    Dim sr As New StreamReader(strFile)
                    Dim fs1 As New FileStream(strFolderLocation & "\dummy.txt", FileMode.Create)
                    Dim sw As New StreamWriter(fs1)

                    sw.Write(sr.ReadLine)
                    sw.Close()
                    sr.Close()
                    GC.Collect()
                    File.Delete(strFile)
                    File.Move(strFolderLocation & "\dummy.txt", strFolderLocation & "\STKARO.CSV")
               

                End If
            Next
        Catch ex As Exception
        End Try
    End Sub


    Private Sub DoProcess(ByVal oProcess As ICMS_Process, ByVal strFolderPath As String)
        Try
            Dim strData As String = String.Empty

            strData = oProcess.Start()

            If String.IsNullOrEmpty(strData) Then
                _message += oProcess.ToString & " failed updation." & vbLf & "Data is not available" & vbLf
                Return
            End If

            If String.IsNullOrEmpty(oProcess.PartNumber) Then
                _message += oProcess.ToString & " failed updation." & vbLf & "Part number is not available" & vbLf
                Return
            End If

            If CVSFileUtil.Write(strData, strFolderPath & "\" & oProcess.FileName & ".csv") Then
                _message += oProcess.ToString & " successfully updated." & vbLf
            Else
                _message += oProcess.ToString & " failed updation." & vbLf & CVSFileUtil.Message & vbLf
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
