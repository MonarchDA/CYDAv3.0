Imports Microsoft.Win32.Registry
Imports Microsoft.Win32.RegistryKey
Imports System.Diagnostics.Process
Imports Microsoft.Office.Interop
Imports Microsoft.Win32
Imports System.IO

Public Class clsReleaseCylinderFunctionality

#Region "Variables"

    Private _strCurrentWorkingDirectory As String = System.Environment.CurrentDirectory + "\ECR"
    Private _strSourceExcelPath As String = _strCurrentWorkingDirectory + "\ECR_Codes.xls"
    'anup 04-02-2011 start
    'Private _strDestinationExcelPath As String = "W:\ECR_Welded\ECR_Codes.xls"
    Private _strDestinationExcelPath As String = "W:\ECR\ECR_Codes.xls"
    'anup 04-02-2011 till here
    Private _oExApplication As Excel.Application
    Private _oExWorkbook As Excel.Workbook
    Private _oExcelSheet_MainAssembly As Excel.Worksheet

    Private _strCylinderCodeNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber

    Private _blnIsNewTubeWeldment As Boolean
    Private _blnIsNewRodWeldment As Boolean
    Private _blnIsNewCylinderHead As Boolean
    Private _blnIsNewPiston As Boolean
    Private _blnIsNewSteelCasting_BaseEnd As Boolean
    Private _blnIsNewSteelCasting_RodEnd As Boolean
    Private _blnIsNewCrossTube_BaseEnd As Boolean
    Private _blnIsNewCrossTube_RodEnd As Boolean
    Private _blnIsNewStopTube As Boolean
    Private _blnIsNewLug_BaseEnd As Boolean
    Private _blnIsNewLug_RodEnd As Boolean


    Private _strECRNumber As String = String.Empty
    Private _strNewExcelPath As String = String.Empty

    Public _htCodeNumbers As New Hashtable        '23_06_2011   RAGAVA  Private to Public
    Private _strTableDrawingNumber As String = String.Empty
    Private _IsDrawingRevisedOrCreated As Boolean

    'anup 17-02-2011 start
    Private _strTubeWeldment As String
    Private _strRodWeldment As String
    Private _strLug_BE As String
    Private _strLug_RE As String
    Private _strCylinderHead As String
    Private _strPiston As String
    Private _strCrossTube_BE As String
    Private _strCrossTube_RE As String
    Private _strCasting_BE As String
    Private _strCasting_RE As String
    Private _strStopTube As String

    'anup 17-02-2011 till here

#End Region

    Public Function MainFunctionality() As Boolean
        MainFunctionality = False
        Try
            If ReleaseExcelFunctionality() Then
                If CreateExcelBasedOnNewPartsGenerated() Then
                    If DropReleasedCodeNumbersToDB() Then
                        'anup 23-12-2010 start
                        'If ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Released" Then
                        '    RevisionCounterValidation()
                        'End If
                        'anup 23-12-2010 till here
                        MainFunctionality = True
                    End If
                End If
            End If
        Catch ex As Exception
            MainFunctionality = False
        End Try
    End Function

#Region "ECR Code Generation Excel Functionality"

    Public Function ReleaseExcelFunctionality() As Boolean         '23_06_2011  RAGAVA  Private to Public
        ReleaseExcelFunctionality = False
        Try
            If CreateExcelObjects() Then
                If DropDataToExistingSheet() Then
                    If SaveExcel() Then
                        ReleaseExcelFunctionality = True
                    End If
                End If
            End If
        Catch ex As Exception
            ReleaseExcelFunctionality = False
        End Try
    End Function

    Private Function CreateExcelObjects() As Boolean
        CreateExcelObjects = False
        Try
            If CheckForExcel() Then
                If DoesExcelExists() Then
                    If CreateExcel() Then
                        CreateExcelObjects = True
                    End If
                End If
            End If
        Catch ex As Exception
            CreateExcelObjects = False
        End Try
    End Function

    Private Function CheckForExcel() As Boolean
        CheckForExcel = True
        Dim strSubKey As String = "Excel.Application"
        Dim oKey As RegistryKey = Registry.ClassesRoot
        Dim oSubKey As RegistryKey = oKey.OpenSubKey("Word.Application")
        If Not IsNothing(oSubKey) Then
            oKey.Close()
            Return True
        Else
            MessageBox.Show("Error with Excel" + vbCrLf + "Kindly check whether the Excel is installed" + vbCrLf + _
             "You can proceed with application but, Excel report will not be generated", "Error with Excel", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
            Return False
        End If
    End Function

    Private Function DoesExcelExists() As Boolean
        DoesExcelExists = False

        Try
            'anup 04-02-2011 start
            'If Not Directory.Exists("W:\ECR_Welded\") Then
            '    Directory.CreateDirectory("W:\ECR_Welded\")
            'End If

            If Not Directory.Exists("W:\ECR\") Then
                Directory.CreateDirectory("W:\ECR\")
            End If
            'anup 04-02-2011 till here

            If Not File.Exists(_strDestinationExcelPath) Then
                File.Copy(_strSourceExcelPath, _strDestinationExcelPath, True)
            End If

            If Not IsNothing(_oExApplication) Then
                _oExApplication = Nothing
            End If
            DoesExcelExists = True

        Catch ex As Exception
            DoesExcelExists = False
        End Try

    End Function

    Private Function CreateExcel() As Boolean
        CreateExcel = True
        Try
            _oExApplication = New Excel.Application
            _oExApplication.Visible = False
            _oExWorkbook = _oExApplication.Workbooks.Open(_strDestinationExcelPath)
            _oExcelSheet_MainAssembly = _oExApplication.Sheets(1)

        Catch ex As Exception
            CreateExcel = False
            MessageBox.Show("Unable to open Excel sheet", "Information", MessageBoxButtons.OK, _
            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try
    End Function

    Private Function SaveExcel() As Boolean
        SaveExcel = False
        Try
            _oExWorkbook.Save()
            For Each oProcess As Process In Process.GetProcessesByName("Excel")
                oProcess.Kill()
                GC.Collect()
                System.Threading.Thread.Sleep(1000)
            Next

            SaveExcel = True
        Catch ex As Exception
            SaveExcel = False
        End Try
    End Function

    Private Function DropDataToExistingSheet() As Boolean
        DropDataToExistingSheet = False



        Dim intTotalCostExcelRange As Integer = 2

        Do
            If IsNothing(_oExcelSheet_MainAssembly.Range("A" + intTotalCostExcelRange.ToString).Value) Then
                intTotalCostExcelRange = intTotalCostExcelRange
                Exit Do
            Else
                intTotalCostExcelRange += 1
            End If
        Loop

        Dim intrSNo As Integer = intTotalCostExcelRange - 1

        Try

            Dim strDescription As String = "Release " & _strCylinderCodeNumber & " Cylinder"

            'anup 04-02-2011 start
            '  _oExcelSheet_MainAssembly.Range("A" + intTotalCostExcelRange.ToString).Value = "10IFL"
            _oExcelSheet_MainAssembly.Range("A" + intTotalCostExcelRange.ToString).Value = "11IFL"
            'anup 04-02-2011 till here

            _oExcelSheet_MainAssembly.Range("C" + intTotalCostExcelRange.ToString).Value = intrSNo
            _oExcelSheet_MainAssembly.Range("D" + intTotalCostExcelRange.ToString).Value = strDescription
            _oExcelSheet_MainAssembly.Range("E" + intTotalCostExcelRange.ToString).Value = Date.Today
            _oExcelSheet_MainAssembly.Range("F" + intTotalCostExcelRange.ToString).Value = 1 'IT MAY CHANGE IN FUTURE

            'anup 04-02-2011 start
            '_strECRNumber = "10IFL-" & intrSNo.ToString
            _strECRNumber = "11IFL-" & intrSNo.ToString
            'anup 04-02-2011 till here

            _oExWorkbook.Save()

            DropDataToExistingSheet = True
        Catch ex As Exception
            DropDataToExistingSheet = False
        End Try
    End Function

#End Region

#Region " Excel For Each ECR Code Generated Functionality"

    Private Function CreateExcelBasedOnNewPartsGenerated() As Boolean
        CreateExcelBasedOnNewPartsGenerated = False
        Try
            Dim strTubeWeldment As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT")
            Dim strRodWeldment As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT")
            Dim strStopTube As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("Stop_tube")

            Dim strCylinderHeadCode As String
            If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text) <> "New Design" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text) <> "" Then
                strCylinderHeadCode = Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmHeadDesign.txtCylinderHeadCode.Text)
            Else
                strCylinderHeadCode = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("CYL HEAD")
            End If

            Dim strPistonCode As String = ObjClsWeldedCylinderFunctionalClass.PistonCodeNumber
            Dim strCylinderCode As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber

            If CreateDirectoryForNewExcel() Then

                If strCylinderCode <> "" Then
                    _htCodeNumbers.Add("CYLINDER_CODE", strCylinderCode)
                    _blnIsNewTubeWeldment = True
                End If

                If strTubeWeldment <> "" Then
                    _htCodeNumbers.Add("TUBE_WELDMENT", strTubeWeldment)
                    _blnIsNewTubeWeldment = CheckForNewOrExisting(strTubeWeldment)
                End If
                If strRodWeldment <> "" Then
                    _htCodeNumbers.Add("ROD_WELDMENT", strRodWeldment)
                    _blnIsNewRodWeldment = CheckForNewOrExisting(strRodWeldment)
                End If
                If strCylinderHeadCode <> "" Then
                    _htCodeNumbers.Add("CYL HEAD", strCylinderHeadCode)
                    _blnIsNewCylinderHead = CheckForNewOrExisting(strCylinderHeadCode)
                End If
                If strPistonCode <> "" Then
                    _htCodeNumbers.Add("PISTONCODE", strPistonCode)
                    _blnIsNewPiston = False
                End If
                SteelCasting()
                CrossTube()
                If strStopTube <> "" Then
                    _htCodeNumbers.Add("Stop_tube", strStopTube)
                    _blnIsNewStopTube = CheckForNewOrExisting(strTubeWeldment)
                End If
                Lug()

                If DropDataToNewExcelSheet() Then
                    CreateExcelBasedOnNewPartsGenerated = True
                End If
            End If
        Catch ex As Exception
            CreateExcelBasedOnNewPartsGenerated = False
        End Try
    End Function

    Private Sub SteelCasting()
        Try
            If Trim(ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode) = "" Then
                If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType) = "CAST" Then
                    If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd) <> "" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName) Then
                        Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                        If strInternalPartNumber <> "" Then
                            _htCodeNumbers.Add("BASEEND_STEELCASTING", strInternalPartNumber)
                            _blnIsNewSteelCasting_BaseEnd = CheckForNewOrExisting(strInternalPartNumber)
                        End If
                    End If
                End If
            End If
            If Trim(ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode) = "" Then
                If UCase(ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated) = "CAST" Then
                    If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd) <> "" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName) Then
                        Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                        If strInternalPartNumber <> "" Then
                            _htCodeNumbers.Add("RODEND_STEELCASTING", strInternalPartNumber)
                            _blnIsNewSteelCasting_RodEnd = CheckForNewOrExisting(strInternalPartNumber)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CrossTube()
        Try
            If Trim(ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode) = "" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Cross Tube" Then
                    If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType) = "FABRICATED" Then
                        If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd) <> "" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName) Then
                            Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            If strInternalPartNumber <> "" Then
                                _htCodeNumbers.Add("CROSSTUBE_BASEEND", strInternalPartNumber)
                                _blnIsNewCrossTube_BaseEnd = CheckForNewOrExisting(strInternalPartNumber)
                            End If
                        End If
                    End If
                End If
            End If
            If Trim(ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode) = "" Then         '14_10_2010   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
                    If UCase(ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated) = "FABRICATED" Then
                        If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_RodEnd) <> "" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName) Then
                            Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                            If strInternalPartNumber <> "" Then
                                _htCodeNumbers.Add("CROSSTUBE_RODEND", strInternalPartNumber)
                                _blnIsNewCrossTube_RodEnd = CheckForNewOrExisting(strInternalPartNumber)
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("error in " & ex.TargetSite.ToString)
        End Try
    End Sub

    Private Sub Lug()
        Try
            If Trim(ObjClsWeldedCylinderFunctionalClass.strExistingBaseEndPartCode) = "" Then         '
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated" Then
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" _
                    OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "BH" _
                    OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" Then
                        If Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd) <> "" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName) Then
                            Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
                            If strInternalPartNumber <> "" Then
                                _htCodeNumbers.Add("LUG_BASEEND", strInternalPartNumber)
                                _blnIsNewLug_BaseEnd = CheckForNewOrExisting(strInternalPartNumber)
                            End If
                        End If
                    End If
                End If
            End If
            If Trim(ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode) = "" Then
                If ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated" Then
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Single Lug" _
                    OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "BH" _
                    OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" Then
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName) Then
                            Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                            If strInternalPartNumber <> "" Then
                                _htCodeNumbers.Add("LUG_RODEND", strInternalPartNumber)
                                _blnIsNewLug_RodEnd = CheckForNewOrExisting(strInternalPartNumber)
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function CheckForNewOrExisting(ByVal strCode As String) As Boolean         '23_06_2011  RAGAVA   Private to Public
        Try
            CheckForNewOrExisting = False
            If Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strCode) Then
                Return True
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function CreateDirectoryForNewExcel() As Boolean    '23_06_2011  RAGAVA  Private to public
        CreateDirectoryForNewExcel = False
        Try

            'anup 04-02-2011 start
            'If Not Directory.Exists("W:\ECR_Welded\ECR_NewExcels\") Then
            '    Directory.CreateDirectory("W:\ECR_Welded\ECR_NewExcels\")
            'End If
            If Not Directory.Exists("W:\ECR\ECR_NewExcels\") Then
                Directory.CreateDirectory("W:\ECR\ECR_NewExcels\")
            End If
            'anup 04-02-2011 till here

            Dim strNewReleasedExcel As String = _strCurrentWorkingDirectory + "\MasterNewPartsExcel.xls\"


            If File.Exists(_strCurrentWorkingDirectory & "\MasterNewPartsExcel.xls") Then
                'anup 04-02-2011 start
                'File.Copy(_strCurrentWorkingDirectory & "\MasterNewPartsExcel.xls", "W:\ECR_Welded\ECR_NewExcels\" & _strECRNumber & ".xls", True)
                '_strNewExcelPath = "W:\ECR_Welded\ECR_NewExcels\" & _strECRNumber & ".xls"
                File.Copy(_strCurrentWorkingDirectory & "\MasterNewPartsExcel.xls", "W:\ECR\ECR_NewExcels\" & _strECRNumber & ".xls", True)
                _strNewExcelPath = "W:\ECR\ECR_NewExcels\" & _strECRNumber & ".xls"
                'anup 04-02-2011 till here
                CreateDirectoryForNewExcel = True
            Else
                MessageBox.Show("MasterNewPartsExcel.xls dosn't exist", "Check the path for Excel", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            CreateDirectoryForNewExcel = False
        End Try
    End Function

    Public Function DropDataToNewExcelSheet(Optional ByVal drECR_Details As DataRow = Nothing) As Boolean          '23_06_2011   RAGAVA   private to public
        DropDataToNewExcelSheet = False
        Try
            _oExApplication = New Excel.Application
            _oExApplication.Visible = False
            _oExWorkbook = _oExApplication.Workbooks.Open(_strNewExcelPath)
            _oExcelSheet_MainAssembly = _oExApplication.Sheets(1)

            Dim IsNewOrExisting As Boolean
            Dim strRoutingRevised As String = String.Empty
            Dim intTotalCostExcelRange As Integer = 2
            Dim intItemCounter As Integer = 0

            Try

                For Each oItem As DictionaryEntry In _htCodeNumbers

                    If oItem.Key = "CYLINDER_CODE" Then
                        If Not drECR_Details Is Nothing Then
                            IsNewOrExisting = drECR_Details("IsNewTubeWeldment")
                        Else
                            IsNewOrExisting = _blnIsNewTubeWeldment
                        End If
                        strRoutingRevised = IsNewOrExisting.ToString
                    ElseIf oItem.Key = "TUBE_WELDMENT" Then
                        If Not drECR_Details Is Nothing Then
                            IsNewOrExisting = drECR_Details("IsNewTubeWeldment")
                        Else
                            IsNewOrExisting = _blnIsNewTubeWeldment
                        End If
                        strRoutingRevised = IsNewOrExisting.ToString
                    ElseIf oItem.Key = "ROD_WELDMENT" Then
                        If Not drECR_Details Is Nothing Then
                            IsNewOrExisting = drECR_Details("IsNewRodWeldment")
                        Else
                            IsNewOrExisting = _blnIsNewRodWeldment
                        End If
                        strRoutingRevised = IsNewOrExisting.ToString
                    ElseIf oItem.Key = "CYL HEAD" Then
                        If Not drECR_Details Is Nothing Then
                            IsNewOrExisting = drECR_Details("IsNewCylinderHead")
                        Else
                            IsNewOrExisting = _blnIsNewCylinderHead
                        End If
                        strRoutingRevised = String.Empty
                    ElseIf oItem.Key = "PISTONCODE" Then
                        If Not drECR_Details Is Nothing Then
                            IsNewOrExisting = drECR_Details("IsNewPiston")
                        Else
                            IsNewOrExisting = _blnIsNewPiston
                        End If
                        strRoutingRevised = String.Empty
                    ElseIf oItem.Key = "BASEEND_STEELCASTING" Then
                        If Not drECR_Details Is Nothing Then
                            IsNewOrExisting = drECR_Details("IsNewBaseEndSteelCasting")
                        Else
                            IsNewOrExisting = _blnIsNewSteelCasting_BaseEnd
                        End If
                        strRoutingRevised = String.Empty
                    ElseIf oItem.Key = "RODEND_STEELCASTING" Then
                        If Not drECR_Details Is Nothing Then
                            IsNewOrExisting = drECR_Details("IsNewRodEndSteelCasting")
                        Else
                            IsNewOrExisting = _blnIsNewSteelCasting_RodEnd
                        End If
                        strRoutingRevised = String.Empty
                    ElseIf oItem.Key = "CROSSTUBE_BASEEND" Then
                        If Not drECR_Details Is Nothing Then
                            IsNewOrExisting = drECR_Details("IsNewCrossTube_BaseEnd")
                        Else
                            IsNewOrExisting = _blnIsNewCrossTube_BaseEnd
                        End If
                        strRoutingRevised = String.Empty
                    ElseIf oItem.Key = "CROSSTUBE_RODEND" Then
                        If Not drECR_Details Is Nothing Then
                            IsNewOrExisting = drECR_Details("IsNewCrossTube_RodEnd")
                        Else
                            IsNewOrExisting = _blnIsNewCrossTube_RodEnd
                        End If

                        strRoutingRevised = String.Empty
                    ElseIf oItem.Key = "Stop_tube" Then
                        If Not drECR_Details Is Nothing Then
                            IsNewOrExisting = drECR_Details("IsNewStopTube")
                        Else
                            IsNewOrExisting = _blnIsNewStopTube
                        End If
                    ElseIf oItem.Key = "LUG_BASEEND" Then
                        If Not drECR_Details Is Nothing Then
                            IsNewOrExisting = drECR_Details("IsNewLug_baseEnd")
                        Else
                            IsNewOrExisting = _blnIsNewLug_BaseEnd
                        End If

                        strRoutingRevised = IsNewOrExisting.ToString
                    ElseIf oItem.Key = "LUG_RODEND" Then
                        If Not drECR_Details Is Nothing Then
                            IsNewOrExisting = drECR_Details("IsNewLug_RodEnd")
                        Else
                            IsNewOrExisting = _blnIsNewLug_RodEnd
                        End If
                        strRoutingRevised = IsNewOrExisting.ToString
                    End If


                    _oExcelSheet_MainAssembly.Range("A" + intTotalCostExcelRange.ToString).Value = oItem.Value
                    _oExcelSheet_MainAssembly.Range("B" + intTotalCostExcelRange.ToString).Value = IsNewOrExisting
                    _oExcelSheet_MainAssembly.Range("C" + intTotalCostExcelRange.ToString).Value = IsNewOrExisting
                    _oExcelSheet_MainAssembly.Range("D" + intTotalCostExcelRange.ToString).Value = String.Empty
                    _oExcelSheet_MainAssembly.Range("E" + intTotalCostExcelRange.ToString).Value = strRoutingRevised

                    intTotalCostExcelRange += 1
                    intItemCounter += 1
                Next

                _oExWorkbook.Save()
                DropDataToNewExcelSheet = True
                SaveExcel()
            Catch ex As Exception
                DropDataToNewExcelSheet = False
            End Try
        Catch ex As Exception
            DropDataToNewExcelSheet = False
        End Try
    End Function

    Public Function DropReleasedCodeNumbersToDB() As Boolean          '23_06_2011   RAGAVA   private to public
        DropReleasedCodeNumbersToDB = False
        Try
            If ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Released" OrElse ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Revision" Then 'anup 21-03-2011 added revision
                Dim strQuery1 As String = String.Empty
                strQuery1 = "DELETE FROM [MIL_WELDED].[dbo].[ReleasedCylinderCodes] WHERE ReleasedCylinderCodeNumber = '" & _strCylinderCodeNumber & "'"
                MonarchConnectionObject.ExecuteQuery(strQuery1)

                Dim strQuery As String = String.Empty
                strQuery = "INSERT INTO dbo.ReleasedCylinderCodes(ReleasedCylinderCodeNumber) VALUES(" & _strCylinderCodeNumber & ")"
                DropReleasedCodeNumbersToDB = MonarchConnectionObject.ExecuteQuery(strQuery)
                If DropReleasedCodeNumbersToDB = False Then
                    MessageBox.Show("Error in updating Released Cylinder Code to Data Table", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            DropReleasedCodeNumbersToDB = False
        End Try
    End Function

    'anup 17-02-2011 start

    Public Function DropRod_Tube_StoptubeCodesToDB(ByVal strTubeWeldment As String, ByVal strRodWeldment As String, ByVal strLug_BE As String, ByVal strLug_RE As String, _
    ByVal strReleasedCylinderCode As String, ByVal strCylinderHead As String, ByVal strPiston As String, ByVal strCrossTube_BE As String, ByVal strCrossTube_RE As String, ByVal strCasting_BE As String, ByVal strCasting_RE As String, ByVal strStopTube As String) As Boolean
        DropRod_Tube_StoptubeCodesToDB = False
        Try
            _strTubeWeldment = strTubeWeldment
            _strRodWeldment = strRodWeldment
            _strLug_BE = strLug_BE
            _strLug_RE = strLug_RE
            _strCylinderHead = strCylinderHead
            _strPiston = strPiston
            _strCrossTube_BE = strCrossTube_BE
            _strCrossTube_RE = strCrossTube_RE
            _strCasting_BE = strCasting_BE
            _strCasting_RE = strCasting_RE
            _strStopTube = strStopTube

            Dim strQuery As String = String.Empty
            strQuery = "UPDATE dbo.ReleasedCylinderCodes   SET TubeWeldment = '" & strTubeWeldment & "',RodWeldment ='" & strRodWeldment & "',Lug_BaseEnd = '" & strLug_BE & "'"
            strQuery += ",Lug_RodEnd = '" & strLug_RE & "' ,CylinderHead = '" & strCylinderHead & "' ,Piston = '" & strPiston & "' ,CrossTube_BaseEnd = '" & strCrossTube_BE & "' "
            strQuery += ",CrossTube_RodEnd = '" & strCrossTube_RE & "' ,Casting_BaseEnd = '" & strCasting_BE & "' ,Casting_RodEnd = '" & strCasting_RE & "' ,StopTube = '" & strStopTube & "' "
            strQuery += " WHERE ReleasedCylinderCodeNumber = '" & strReleasedCylinderCode & "'"
            DropRod_Tube_StoptubeCodesToDB = MonarchConnectionObject.ExecuteQuery(strQuery)
            If DropRod_Tube_StoptubeCodesToDB = False Then
                MessageBox.Show("Error in updating Released Codes to Data Table", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            DropRod_Tube_StoptubeCodesToDB = False
        End Try
    End Function

    Private ReadOnly Property ColumnName() As Hashtable
        Get
            Dim htColumnName As New Hashtable
            htColumnName.Add("TUBEWELDMENT", "TubeWeldment")
            htColumnName.Add("RODWELDMENT", "RodWeldment")
            htColumnName.Add("LUG_BE", "Lug_BaseEnd")
            htColumnName.Add("LUG_RE", "Lug_RodEnd")
            htColumnName.Add("CYLINDERHEAD", "CylinderHead")
            htColumnName.Add("PISTON", "Piston")
            htColumnName.Add("CROSSTUBE_BE", "CrossTube_BaseEnd")
            htColumnName.Add("CROSSTUBE_RE", "CrossTube_RodEnd")
            htColumnName.Add("CASTING_BE", "Casting_BaseEnd")
            htColumnName.Add("CASTING_RE", "Casting_RodEnd")
            htColumnName.Add("STOPTUBE", "StopTube")

            Return htColumnName
        End Get
    End Property

    Public Function DoesCodeExistInDB(ByVal strCode As String, Optional ByVal strCodeName As String = "") As Boolean
        DoesCodeExistInDB = False
        Try
            If strCode.StartsWith("7") Then 'anup 16-03-2011
                Dim strColoumnName As String = String.Empty
                strColoumnName = ColumnName.Item(strCodeName)

                If Not String.IsNullOrEmpty(strColoumnName) Then
                    Dim strQuery As String = String.Empty
                    strQuery = "select * from ReleasedCylinderCodes where " & strColoumnName & " ='" & strCode & "'"
                    Dim dtDoesCodeExistInDB As DataTable = Nothing
                    dtDoesCodeExistInDB = MonarchConnectionObject.GetTable(strQuery)
                    If IsNothing(dtDoesCodeExistInDB) OrElse dtDoesCodeExistInDB.Rows.Count < 1 Then
                        DoesCodeExistInDB = True
                    End If
                End If
            End If
        Catch ex As Exception
            DoesCodeExistInDB = False
        End Try
    End Function

    Public Sub AssigningValuesToIsReleasedOrNot()
        Try

            'TUBE WELDMENT
            If DoesCodeExistInDB(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT"), "TUBEWELDMENT") Then
                ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_TubeWeldment = True
            End If

            'RODE WELDMENT
            If DoesCodeExistInDB(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT"), "RODWELDMENT") Then
                ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_RodWeldment = True
            End If

            'LUG BE
            Dim strInternalPartNumber_LUG_BE As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd
            If strInternalPartNumber_LUG_BE = "" Then
                strInternalPartNumber_LUG_BE = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
            End If
            If DoesCodeExistInDB(strInternalPartNumber_LUG_BE, "LUG_BE") Then
                ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Lug_BE = True
            End If

            'LUG RE
            If DoesCodeExistInDB(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName), "LUG_RE") Then
                ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Lug_RE = True
            End If

            'CYLINDER HEAD
            Dim oExistingListItems_CylinderHead As clsList = clsAddExistingCodes._htExistingCostingCodeList(clsAddExistingCodes.CYLINDERHEADCODE)
            Dim strInternalPartNumber_CylinderHead As String = oExistingListItems_CylinderHead.strPartCode
            If DoesCodeExistInDB(strInternalPartNumber_CylinderHead, "CYLINDERHEAD") Then
                ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_CylinderHead = True
            End If

            'PISTON
            Dim oExistingListItems_PistonCode As clsList = clsAddExistingCodes._htExistingCostingCodeList(clsAddExistingCodes.PISTONCODE)
            Dim strInternalPartNumber_PistonCode As String = oExistingListItems_PistonCode.strPartCode
            If DoesCodeExistInDB(strInternalPartNumber_PistonCode, "PISTON") Then
                ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Piston = True
            End If

            'CROSS TUBE BE
            Dim strInternalPartNumber_CTBE As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("BASE_CROSSTUBE_IFL")
            If DoesCodeExistInDB(strInternalPartNumber_CTBE, "CROSSTUBE_BE") Then
                ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_CrossTube_BE = True
            End If

            'CROSS TUBE RE
            Dim strInternalPartNumber_CTRE As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("CROSSTUBE_ROD")
            If DoesCodeExistInDB(strInternalPartNumber_CTRE, "CROSSTUBE_RE") Then
                ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_CrossTube_RE = True
            End If

            'CASTING BE
            Dim strInternalPartNumber_CASTING_BE As String = Trim(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd)
            If strInternalPartNumber_CASTING_BE = "" Then
                strInternalPartNumber_CASTING_BE = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName)
            End If
            If DoesCodeExistInDB(strInternalPartNumber_CASTING_BE, "CASTING_BE") Then
                ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Casting_BE = True
            End If

            'CASTING RE
            If DoesCodeExistInDB(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName), "CASTING_RE") Then
                ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Casting_RE = True
            End If

            'STOPTUBE
            If DoesCodeExistInDB(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("Stop_tube"), "STOPTUBE") Then
                ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_StopTube = True
            End If
        Catch ex As Exception

        End Try
    End Sub


    'anup 17-02-2011 till here

#End Region

#Region "Setting Revision Counter To Zero"

    Private Sub SettingRevisionCounterToZero()
        Try
            Dim strQuery As String = String.Empty
            strQuery = "UPDATE dbo.ContractMaster SET ContractRevision = 0 where ContractNumber = " & _strCylinderCodeNumber
            MonarchConnectionObject.ExecuteQuery(strQuery)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeletingExistingRevisionDetails()
        Try
            Dim strQuery As String = String.Empty
            strQuery = "DELETE FROM dbo.RevisionTable WHERE ContractNumber =" & _strCylinderCodeNumber
            MonarchConnectionObject.ExecuteQuery(strQuery)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub RevisionCounterValidation()
        Try
            DeletingExistingRevisionDetails()
            SettingRevisionCounterToZero()
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class

