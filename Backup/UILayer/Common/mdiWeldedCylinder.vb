Imports System.Windows.Forms
Imports IFLBaseDataLayer
Imports IFLCustomUILayer
Imports IFLCommonLayer
Imports System.Drawing.Drawing2D
Imports Microsoft.Win32.Registry
Imports Microsoft.Win32.RegistryKey
Imports System.Diagnostics.Process
Imports Microsoft.Office.Interop
Imports Microsoft.Win32
Imports System.IO
Imports System.Threading

Public Class mdiWeldedCylinder

#Region "Variables"

    Private _sMiddle As Single = 0
    Private _sDelta As Single = 0.1

#End Region

#Region "Properties"

#End Region

#Region "Default Subs"

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Global.System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer = 0

#End Region

#Region "SubProcedures"

    Private Sub CreateObjectOfFunctionalClass()
        ObjClsWeldedCylinderFunctionalClass = New clsWeldedCylinderFunctionalClass
    End Sub

    'Private Sub LoadFirstForm()
    '    ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm = ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs
    '    ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.TopLevel = False
    '    ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.Show()
    '    ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.ManualLoad()
    '    pnlChildFormArea.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs)
    '    ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.Dock = DockStyle.Fill
    '    btnBack.Enabled = False
    '    ObjClsWeldedCylinderFunctionalClass.BackClick = btnBack
    '    ObjClsWeldedCylinderFunctionalClass.NextClick = btnNext
    'End Sub

    Private Sub GetUserAndServerDetails()
        lvwLoginDetails.Items.Clear()
        If Not IsNothing(MonarchConnectionObject) Then
            lvwLoginDetails.Columns.Add("Property", 107, HorizontalAlignment.Center)
            lvwLoginDetails.Columns.Add("Value", 200, HorizontalAlignment.Center)

            Dim oListviewItem1 As ListViewItem
            oListviewItem1 = lvwLoginDetails.Items.Add("ServerName")
            lvwLoginDetails.Items(0).SubItems.Add(MonarchConnectionObject.ServerName)

            Dim oListViewItem2 As ListViewItem
            oListViewItem2 = lvwLoginDetails.Items.Add("DataBase")
            lvwLoginDetails.Items(1).SubItems.Add(MonarchConnectionObject.DataBaseName)

            Dim oListViewItem3 As ListViewItem
            oListViewItem3 = lvwLoginDetails.Items.Add("UserName")
            lvwLoginDetails.Items(2).SubItems.Add(My.User.Name)

            Dim oListViewItem4 As ListViewItem
            oListViewItem4 = lvwLoginDetails.Items.Add("ComputerName")
            lvwLoginDetails.Items(3).SubItems.Add(My.Computer.Name)

            Dim oListViewItem5 As ListViewItem
            oListViewItem5 = lvwLoginDetails.Items.Add("DomainName")
            lvwLoginDetails.Items(4).SubItems.Add(System.Environment.UserDomainName)
        End If
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        If ObjClsWeldedCylinderFunctionalClass.CheckForExcel() Then
            If ObjClsWeldedCylinderFunctionalClass.GetPathForExcel() Then
                If ObjClsWeldedCylinderFunctionalClass.CopyTheMasterFile() Then
                    If ObjClsWeldedCylinderFunctionalClass.CreateExcel() Then
                        ObjClsWeldedCylinderFunctionalClass.WriteGUIDataToExcel()
                        Process.Start(ObjClsWeldedCylinderFunctionalClass.ChildExcelPath)
                        'Application.Exit()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub NewMenuItemClicked(ByVal ObjNextForm As Object)
        Try
            ''22_06_2011   RAGAVA
            'If ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Released" Then
            '    'Me.btnNext.Visible = False
            '    'Me.btnBack.Visible = False
            '    If Not Directory.Exists("W:\WELDED\CMS\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & "_CMS") Then
            '        Directory.Move("W:\WELDED\CMS_TEMP\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & "_CMS", "W:\WELDED\CMS")
            '        File.Move("W:\WELDED\CNC_TEMP\" & "0" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & "1.MIN", "W:\WELDED\CNC")
            '    End If
            '    Try
            '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.UpdateExistedCasting()
            '        Dim oClsReleaseCylinderFunctionality As New clsReleaseCylinderFunctionality
            '        oClsReleaseCylinderFunctionality.RevisionCounterValidation()
            '        If Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ECR_MainFunctionality() Then
            '            MessageBox.Show("Release Cylinder Validation Failed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            '        End If
            '    Catch ex As Exception
            '        MsgBox("Error in updating Existing Casting Details")
            '    End Try
            '    'Till   Here
            'Else
            'Me.btnNext.Visible = True     '22_06_2011   RAGAVA
            'Me.btnBack.Visible = True     '22_06_2011   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm = ObjNextForm
            ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.TopLevel = False
            pnlChildFormArea.Controls.Clear()
            ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.Show()
            ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.ManualLoad()
            pnlChildFormArea.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm)
            ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.Dock = DockStyle.Fill
            btnBack.Enabled = False
            ObjClsWeldedCylinderFunctionalClass.BackClick = btnBack
            ObjClsWeldedCylinderFunctionalClass.NextClick = btnNext
            EnableButtons() '30_12_2010   RAGAVA
            'End If
        Catch ex As Exception
        End Try
    End Sub


#End Region

#Region "Events"

    Private Sub mdiWeldedCylinder_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub mdiWeldedCylinder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CreateObjectOfFunctionalClass()
        MIL_Image()

        'TODO: ANUP 28-04-2010 10.39am
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetConnection() Then
            '*****************

            ObjClsWeldedCylinderFunctionalClass.GeneralInformationListview = Me.lvwGeneralInformation
            ObjClsWeldedCylinderFunctionalClass.AddItemsToGeneralInformationListView()
            ' LoadFirstForm()
            GetUserAndServerDetails()
            'ObjClsWeldedCylinderFunctionalClass.MessagesRichTextBox = Me.rtxtMessages
            '19_11_2009   RAGAVA
            Try
                ObjClsWeldedCylinderFunctionalClass.KillAllSolidWorksServices()
                ObjClsWeldedCylinderFunctionalClass.CloseExcel(True)
                If Directory.Exists("C:\WELD_DESIGN_TABLES") Then
                    Directory.Delete("C:\WELD_DESIGN_TABLES", True)
                End If
                Directory.CreateDirectory("C:\WELD_DESIGN_TABLES")
                Dim fso As New Scripting.FileSystemObject
                '17_02_2010 
                Dim strSeriesCode As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetMaxWeldedSeriesCode("welded.WeldedCylinderCodeNumber")

                If Not IsNothing(strSeriesCode) Then
                    strSeriesCode = Val(strSeriesCode) + 1
                Else
                    strSeriesCode = 675000
                End If


                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber = strSeriesCode

                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalCodeNumber = strSeriesCode        '16_08_2010    RAGAVA

                Try
                    Dim _strQuery = "Insert into welded.WeldedCylinderCodeNumber values(" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber + ",0)"
                    MonarchConnectionObject.ExecuteQuery(_strQuery)
                Catch ex As Exception

                End Try

                fso.CopyFolder("X:\Welded_Master_Library\WELD_DESIGN_TABLES_MAIN", "C:\WELD_DESIGN_TABLES", True)
                If Directory.Exists("C:\WELDED_TESTING") = False Then
                    Directory.CreateDirectory("C:\WELDED_TESTING")
                End If
                'strSeriesCode
                If Directory.Exists("C:\WELDED_TESTING\" + strSeriesCode) = False Then
                    Directory.CreateDirectory("C:\WELDED_TESTING\" + strSeriesCode)
                Else
                    Try
                        Directory.Delete("C:\WELDED_TESTING\" + strSeriesCode, True)
                        Directory.CreateDirectory("C:\WELDED_TESTING\" + strSeriesCode)
                    Catch ex As Exception

                    End Try

                End If
                fso.CopyFolder("X:\Welded_Master_Library\WELDED_LIBRARY", "C:\WELDED_TESTING\" + strSeriesCode + "\WELDED_LIBRARY", True)
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath = "C:\WELDED_TESTING\" + strSeriesCode + "\WELDED_LIBRARY"
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath_Drawings = "C:\WELDED_TESTING\" + strSeriesCode + "\WELDED_DRAWINGS"  '04_03_2010   RAGAVA 
                Directory.CreateDirectory(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath_Drawings)       '04_03_2010    RAGAVA
            Catch ex As Exception
            End Try

            ' ANUP 19-03-2010 11.00
            ObjClsWeldedCylinderFunctionalClass.ObjPnlChildFormArea = Me.pnlChildFormArea
            '*****************

            '19_11_2009   RAGAVA    Till   Here


            ''24_02_2010 Aruna Start--
            'Try
            '    Dim objDTRow As DataRow
            '    objDTRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPurchaseAndManufactureCode("welded.Configurations_PartCode")
            '    If Not objDTRow Is Nothing Then
            '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PurchaseCode = objDTRow("ManufacturedPartCode")
            '        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ManufactureCode = objDTRow("PurchasedPartCode")
            '    End If
            'Catch ex As Exception
            'End Try
            ''24_02_2010 Aruna Ends--

            'ToDo:Sunny 31-03-10
            ObjClsWeldedCylinderFunctionalClass.MdiPictureBox = Me.picCommonBox
        End If
    End Sub

    '19_11_2009  RAGAVA 
    Private Sub killSolidWorks(ByVal _strProcessName As String)
        Dim proc As System.Diagnostics.Process
        Try
            For Each proc In System.Diagnostics.Process.GetProcessesByName(_strProcessName)
                If proc.HasExited = False Then
                    proc.Kill()
                End If
            Next
        Catch oException As Exception
        End Try
    End Sub

    '19_11_2009   RAGAVA 
    Private Sub KillAllSolidWorksServices()
        killSolidWorks("SLDWORKS")
        killSolidWorks("SolidWorksLicTemp.0001")
        killSolidWorks("SolidWorksLicensing")
        killSolidWorks("swvbaserver")
    End Sub

    Private Sub FormNavigation(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click, btnNext.Click

        ''ONSITE:19-05-2010 calling the next button functinality
        'If sender.Equals(btnNext) Then
        '    If NextButtonFunctionality() Then
        '        Exit Sub
        '    End If
        'End If
        ''E
        If sender.Equals(btnNext) Then
            If ChangeRodEndConfigScreen() Then
                Exit Sub
            End If
        End If

        For Each oItem As Object In ObjClsWeldedCylinderFunctionalClass.FormNavigationOrder
            If oItem(clsWeldedCylinderFunctionalClass.EOrderOfFormNavigationArraylist.CurrentFormName).ToString.Equals(ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.name) Then
                Dim oForm As Form = Nothing
                Dim oCurrentForm As Form = Nothing
                If sender.Equals(btnBack) Then
                    oForm = CType(oItem(clsWeldedCylinderFunctionalClass.EOrderOfFormNavigationArraylist.PreviousFormObject), Form)
                    ''05_01_2012   RAGAVA
                    'If ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.name = "frmDLPortInTubeDetails" Then
                    '    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.rdbDesignACasting.Checked = False
                    '    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.rdbFabrication.Checked = False
                    '    ObjClsWeldedCylinderFunctionalClass.ObjFrmDLCastingNo_PortInTube.plnFabrication_Casting.Controls.Clear()
                    'End If
                    ''Till  Here
                    If Not IsNothing(oForm) Then
                        pnlChildFormArea.Controls.Clear()
                        ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm = oForm
                        oForm.TopLevel = False
                        oForm.Dock = DockStyle.Fill
                        If Not oForm.Enabled Then
                            ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.ManualLoad()
                        Else
                            oForm.Show()
                        End If
                        Application.DoEvents()
                        pnlChildFormArea.Controls.Add(oForm)
                        Exit For
                    End If
                ElseIf sender.Equals(btnNext) Then
                    If ObjClsWeldedCylinderFunctionalClass.ValidationFunctionality(ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm) Then
                        If AreaIsLessCalculation() Then
                            GetRevisionData(ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm)
                            oForm = CType(oItem(clsWeldedCylinderFunctionalClass.EOrderOfFormNavigationArraylist.NextFormObject), Form)
                            If Not IsNothing(oForm) Then
                                pnlChildFormArea.Controls.Clear()
                                ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm = oForm
                                oForm.TopLevel = False
                                oForm.Dock = DockStyle.Fill
                                If oForm.Created Then
                                    ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.ManualLoad()
                                End If
                                oForm.Show()
                                pnlChildFormArea.Controls.Add(oForm)
                                PopulateFormData()
                                'anup 11-02-2011 start
                                'If oForm.Name = "" Then
                                '    ObjClsWeldedCylinderFunctionalClass.BackClick.PerformClick()
                                'End If
                                'anup 11-02-2011 till here
                                Exit For
                            End If
                        End If
                    Else
                        Dim strMessage As String = "" '= "Please enter values in the following fields" + vbCrLf
                        For Each oEmptyControls As Object In ObjClsWeldedCylinderFunctionalClass.EmptyControlData
                            strMessage += oEmptyControls + vbCrLf
                        Next
                        MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                    End If
                End If
            End If
        Next

        btnBack.Enabled = True
        btnNext.Enabled = True
        For Each oItem As Object In ObjClsWeldedCylinderFunctionalClass.FormNavigationOrder
            If oItem(clsWeldedCylinderFunctionalClass.EOrderOfFormNavigationArraylist.CurrentFormName).ToString.Equals(ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.name) Then
                If IsNothing(oItem(clsWeldedCylinderFunctionalClass.EOrderOfFormNavigationArraylist.PreviousFormObject)) Then
                    btnBack.Enabled = False
                End If
                If IsNothing(oItem(clsWeldedCylinderFunctionalClass.EOrderOfFormNavigationArraylist.NextFormObject)) Then
                    btnNext.Enabled = False
                End If
            End If
        Next

    End Sub

    'ONSITE:03-06-2010
    Private Function ChangeRodEndConfigScreen() As Boolean
        If ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.Name = "frmREDLThreaded" Then
            If ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.IsDLThreadDataFound = False Then
                Dim oForm As Form = ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration
                ShowingTheForm(oForm)
                Return True
            End If
        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.Name = "frmREDLWelded" Then
            Try
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmREDLNewDesign.IsPrimaryInputsReq = True Then
                    Dim oForm As Form = ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs
                    ShowingTheForm(oForm)
                    Return True
                End If
            Catch ex As Exception

            End Try
        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.Name = "frmRECrossTube" Then
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmCastingNo_RECT.IsPrimaryInputsReq = True Then
                Dim oForm As Form = ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs
                ShowingTheForm(oForm)
                Return True
            End If

        End If
        Return False
    End Function

    Private Sub ShowingTheForm(ByVal oForm As Form)
        ObjClsWeldedCylinderFunctionalClass.ObjPnlChildFormArea.Controls.Clear()
        ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm = oForm
        oForm.TopLevel = False
        oForm.Dock = DockStyle.Fill
        If oForm.Created Then
            ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.ManualLoad()
        End If
        oForm.Show()
        ObjClsWeldedCylinderFunctionalClass.ObjPnlChildFormArea.Controls.Add(oForm)
    End Sub

#Region " Populating Back"

    Private Sub GetRevisionData(ByVal oForm As Object)
        If oForm.Name = "frmMonarchRevision" Then
            Dim _oPopulating As PopulatingBackClass = PopulatingBackClass.GetPopulatingObject()
            _oPopulating.GetFormDataFromDB(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RevisionContractNo)
        End If
    End Sub

    Private Sub PopulateFormData()

        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.New_Revision = "Revision'" Then
            'If Not ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.Created Then
            If ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.IsPopulated = False Then
                Dim _oPopulating As PopulatingBackClass = PopulatingBackClass.GetPopulatingObject()
                _oPopulating.SetDataToForm(ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm)
                'ANUP 25-10-2010 START
                If Not ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.Name = "frmPrimaryInputs" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.IsPopulated = True
                End If
                'ANUP 25-10-2010 TILL HERE
                'ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.IsPopulated = True
            End If
            'End If
        End If
    End Sub

#End Region

    'ONSITE:19-05-2010 providing next button functinality 
    Private Function NextButtonFunctionality() As Boolean
        Dim oForm As Form = Nothing
        If ObjClsWeldedCylinderFunctionalClass.ValidationFunctionality(ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm) Then
            Try
                oForm = ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.GetNextFormObject()
            Catch ex As Exception
                Return False
            End Try

            If Not IsNothing(oForm) Then
                pnlChildFormArea.Controls.Clear()
                ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm = oForm
                oForm.TopLevel = False
                oForm.Dock = DockStyle.Fill
                If oForm.Created Then
                    ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.ManualLoad()
                End If
                oForm.Show()
                pnlChildFormArea.Controls.Add(oForm)
                btnNext.Enabled = True
            Else
                btnNext.Enabled = False
            End If
        Else
            Dim strMessage As String = "" '= "Please enter values in the following fields" + vbCrLf
            For Each oEmptyControls As Object In ObjClsWeldedCylinderFunctionalClass.EmptyControlData
                strMessage += oEmptyControls + vbCrLf
            Next
            MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        End If
        Return True
    End Function

    Private Function AreaIsLessCalculation() As Boolean
        AreaIsLessCalculation = True
        If ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.Name = "frmRodEndConfiguration" Then
            AreaIsLessCalculation = ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.AreaCalculation()
        End If
    End Function


    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHome.Click
        If MessageBox.Show("Do you really want to restart the application ?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
            Application.Restart()
        End If
    End Sub

    Private Sub timerCurrentDateAndTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerCurrentDateAndTime.Tick
        lblDate.Text = My.Computer.Clock.LocalTime
        ' picScroll.Invalidate()
        picIFLLOGO.Invalidate()
    End Sub

    'TODO: ANUP 09-04-2010 04.02
    Private Sub btnNext_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.MouseHover, btnBack.MouseHover
        picCommonBox.ImageLocation = ""
    End Sub
    '**************

    ': ANUP 27-05-2010 01.51pm
    Private Sub RevisionMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RevisionMenuItem.Click, ReleasedMenuItem.Click
        'ANUP 01-11-2010 START
        If sender.name = "RevisionMenuItem" Then
            NewMenuItem.Checked = False
            RevisionMenuItem.Checked = True
            ReleasedMenuItem.Checked = False
            ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Revision"
        ElseIf sender.name = "ReleasedMenuItem" Then
            NewMenuItem.Checked = False
            RevisionMenuItem.Checked = False
            ReleasedMenuItem.Checked = True
            ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Released"
        End If
        'ANUP 01-11-2010 TILL HERE
        CastingsUpdationToolStripMenuItem.Checked = False '<<--9-12-2010 Aruna-->>
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.New_Revision = "Revision'"
        Dim ObjCurrentForm As Object = ObjClsWeldedCylinderFunctionalClass.ObjFrmMonarchRevision
        NewMenuItemClicked(ObjCurrentForm)
    End Sub

    Private Sub NewMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewMenuItem.Click
        Try
            ObjClsWeldedCylinderFunctionalClass.ObjFrmContractDetails.cmbCustomerName.SelectedIndex = -1
            NewMenuItem.Checked = True
            RevisionMenuItem.Checked = False
            CastingsUpdationToolStripMenuItem.Checked = False '<<--9-12-2010 Aruna-->>
            'ANUP 01-11-2010 START
            ReleasedMenuItem.Checked = False
            ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "New"
            'ANUP 01-11-2010 TILL HERE
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.New_Revision = "New'"

            '16_08_2010   RAGAVA
            Try
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RevisionContractNo <> "" Then
                    If Directory.Exists("C:\WELDED_TESTING\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalCodeNumber) = False Then
                        Directory.Move("C:\WELDED_TESTING\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RevisionContractNo, "C:\WELDED_TESTING\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalCodeNumber)
                    End If
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RevisionContractNo = ""
            Catch ex As Exception
            End Try
            'Till   Here

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalCodeNumber         '16_08_2010    RAGAVA

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath = "C:\WELDED_TESTING\" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalCodeNumber + "\WELDED_LIBRARY"         '15_10_2010   RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath_Drawings = "C:\WELDED_TESTING\" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OriginalCodeNumber + "\WELDED_DRAWINGS"         '15_10_2010   RAGAVA
            Dim ObjCurrentForm As Object = ObjClsWeldedCylinderFunctionalClass.ObjFrmContractDetails
            NewMenuItemClicked(ObjCurrentForm)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MIL_Image()
        picMIL_Image.ImageLocation = ObjClsWeldedCylinderFunctionalClass.CurrentWorkingDirectory + "\Images\MIL.jpg"
    End Sub
#End Region

    '<<--9-12-2010 Aruna--
#Region "Casting Updations"
    Private Sub CastingUpdationsMenuItemClicked(ByVal ObjNextForm As Object)
        ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm = ObjNextForm
        ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.TopLevel = False
        pnlChildFormArea.Controls.Clear()
        ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.Show()
        ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.ManualLoad()
        pnlChildFormArea.Controls.Add(ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm)
        ObjClsWeldedCylinderFunctionalClass.ObjCurrentForm.Dock = DockStyle.Fill
        btnBack.Enabled = False
        btnNext.Enabled = False
        btnExcel.Enabled = False
        btnHome.Enabled = False
    End Sub

    '30_12_2010   RAGAVA
    Private Sub EnableButtons()
        Try
            btnBack.Enabled = True
            btnNext.Enabled = True
            btnExcel.Enabled = True
            btnHome.Enabled = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CastingsUpdationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CastingsUpdationToolStripMenuItem.Click
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.New_Revision = "Casting Updations"
        NewMenuItem.Checked = False
        RevisionMenuItem.Checked = False
        CastingsUpdationToolStripMenuItem.Checked = True
        Dim ObjCurrentForm As Object = ObjClsWeldedCylinderFunctionalClass.ObjFrmUpdateRecords
        CastingUpdationsMenuItemClicked(ObjCurrentForm)
    End Sub
#End Region
    '--29-10-2010 ARuna-->>

    Private Sub ReleaseWithoutFullGenerationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub
End Class
