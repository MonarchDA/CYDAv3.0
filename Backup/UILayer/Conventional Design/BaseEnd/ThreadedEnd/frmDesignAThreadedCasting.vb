Imports System.Data
Imports System.IO
Public Class frmDesignAThreadedCasting

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

#Region "Private Variables"

    Private _intSafetyFactorCount As Integer = 0

#End Region

#Region "Enums"

    Public Enum WeightListView
        swingClearance = 0
        ThreadLength = 1
        Weight = 2
    End Enum

#End Region

#Region "SubProcedures"

    Public Sub ManualLoad()
        DefaultSettings()
        cmbThreadedDiameter.Text = ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbThreadSize.Text
        txtThreadedLength.Text = ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.txtThreadLength.Text
        txtSwingClearance.Text = ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.txtSwingClearance.Text
    End Sub

    Private Sub DefaultSettings()
        txtSwingClearance.Enabled = False
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        SafetyFactor_LugThickness_Weight_GeneretedDesign()
    End Sub

    'Private Sub LVWThreadedDetails_GeneretedDesign()
    '    Try
    '        lvwThreadedDetails.Clear()
    '        lvwThreadedDetails.Columns.Add("Threaded Diameter", 130, HorizontalAlignment.Center)
    '        lvwThreadedDetails.Columns.Add("Threaded Length", 130, HorizontalAlignment.Center)
    '        lvwThreadedDetails.Columns.Add("Swing Clearance", 125, HorizontalAlignment.Center)
    '        lvwThreadedDetails.FullRowSelect = True
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub LoadThreadSize()
        Try
            cmbThreadedDiameter.DataSource = Nothing
            Dim oThreadSizeDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetThreadSizeValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PullForce)
            If Not IsNothing(oThreadSizeDataTable) Then
                cmbThreadedDiameter.DataSource = oThreadSizeDataTable
                cmbThreadedDiameter.DisplayMember = "ThreadDiscription"
                cmbThreadedDiameter.ValueMember = "ThreadValue"
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Events"

    Private Sub frmDesignAThreadedCasting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        DefaultSettings()
        LoadThreadSize()
        cmbThreadedDiameter.Text = ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbThreadSize.Text
        txtThreadedLength.Text = ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.txtThreadLength.Text
        txtSwingClearance.Text = ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.txtSwingClearance.Text
        'LVWThreadedDetails_GeneretedDesign()
    End Sub

    'Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        ObjClsWeldedCylinderFunctionalClass.GenerateCasting = True
    '        btnAccept.Enabled = True
    '        Me.Cursor = Cursors.WaitCursor
    '        'Dim strFilePart As String = ""
    '        'Dim strFilePartDesignTableExcel As String = "" '5_01_10
    '        'Dim strName As String = "NewThreadedEndPartCopied"
    '        'If Directory.Exists("C:\MONARCH_TESTING") = False Then
    '        '    Directory.CreateDirectory("C:\MONARCH_TESTING")
    '        'End If
    '        'If Directory.Exists("C:\WELD_DESIGN_TABLES") = True Then
    '        '    Directory.Delete("C:\WELD_DESIGN_TABLES", True)
    '        'End If
    '        'Directory.CreateDirectory("C:\WELD_DESIGN_TABLES")

    '        'If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" AndAlso _
    '        '         ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "OUTSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
    '        '    ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory("C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_NO_PO_GR_THREADEDEND")
    '        '    If File.Exists("C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_NO_PO_GR_THREADEDEND\BEC_NO_PO_GR_THREADEDEND.SLDPRT") = False Then
    '        '        File.Copy("X:\Welded_Master_Library\WELD_DESIGN_TABLES_MAIN\WELDED_LIBRARY\BEC_NO_PO_GR_THREADEDEND\BEC_NO_PO_GR_THREADEDEND.SLDPRT", "C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_NO_PO_GR_THREADEDEND\BEC_NO_PO_GR_THREADEDEND.SLDPRT")
    '        '    End If
    '        '    strFilePart = "C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_NO_PO_GR_THREADEDEND\BEC_NO_PO_GR_THREADEDEND.SLDPRT"
    '        '    File.Copy("X:\Welded_Master_Library\WELD_DESIGN_TABLES_MAIN\BEC_NO_PO_GR_THREADEDEND.XLS", "C:\WELD_DESIGN_TABLES\BEC_NO_PO_GR_THREADEDEND.XLS")
    '        '    strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_NO_PO_GR_THREADEDEND.XLS"

    '        'ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" AndAlso _
    '        '                 ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
    '        '    ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory("C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_FL_PI_GR_THREADEDEND")
    '        '    If File.Exists("C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_FL_PI_GR_THREADEDEND\BEC_FL_PI_GR_THREADEDEND.SLDPRT") = False Then
    '        '        File.Copy("X:\Welded_Master_Library\WELDED_LIBRARY\BEC_FL_PI_GR_THREADEDEND\BEC_FL_PI_GR_THREADEDEND.SLDPRT", "C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_FL_PI_GR_THREADEDEND\BEC_FL_PI_GR_THREADEDEND.SLDPRT")
    '        '    End If
    '        '    strFilePart = "C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_FL_PI_GR_THREADEDEND\BEC_FL_PI_GR_THREADEDEND.SLDPRT"
    '        '    File.Copy("X:\Welded_Master_Library\WELD_DESIGN_TABLES_MAIN\BEC_FL_PI_GR_THREADEDEND.XLS", "C:\WELD_DESIGN_TABLES\BEC_FL_PI_GR_THREADEDEND.XLS")
    '        '    strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_FL_PI_GR_THREADEDEND.XLS"

    '        'ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" AndAlso _
    '        '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "OUTSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
    '        '    ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory("C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_FL_PO_GR_THREADEDEND")
    '        '    If File.Exists("C:\MONARCH_TESTING\WELDED_LIBRARY\BASE_END_THREADED\BEC_FL_PO_GR_THREADEDEND\BEC_FL_PO_GR_THREADEDEND.SLDPRT") = False Then
    '        '        File.Copy("X:\Welded_Master_Library\WELDED_LIBRARY\BASE_END_THREADED\BEC_FL_PO_GR_THREADEDEND\BEC_FL_PO_GR_THREADEDEND.SLDPRT", "C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_FL_PO_GR_THREADEDEND\BEC_FL_PO_GR_THREADEDEND.SLDPRT")
    '        '    End If
    '        '    strFilePart = "C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_FL_PO_GR_THREADEDEND\BEC_FL_PO_GR_THREADEDEND.SLDPRT"
    '        '    File.Copy("X:\Welded_Master_Library\WELD_DESIGN_TABLES_MAIN\BEC_FL_PO_GR_THREADEDEND.XLS", "C:\WELD_DESIGN_TABLES\BEC_FL_PO_GR_THREADEDEND.XLS")
    '        '    strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_FL_PO_GR_THREADEDEND.XLS"
    '        'ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" AndAlso _
    '        '       ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
    '        '    ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory("C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_RA_PI_GR_THREADEDEND")
    '        '    If File.Exists("C:\MONARCH_TESTING\WELDED_LIBRARY\BASE_END_THREADED\BEC_RA_PI_GR_THREADEDEND\BEC_RA_PI_GR_THREADEDEND.SLDPRT") = False Then
    '        '        File.Copy("X:\Welded_Master_Library\WELDED_LIBRARY\BASE_END_THREADED\BEC_RA_PI_GR_THREADEDENDBEC_RA_PI_GR_THREADEDEND.SLDPRT", "C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_RA_PI_GR_THREADEDEND\BEC_RA_PI_GR_THREADEDEND.SLDPRT")
    '        '    End If
    '        '    strFilePart = "C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_RA_PI_GR_THREADEDEND\BEC_RA_PI_GR_THREADEDEND.SLDPRT"
    '        '    File.Copy("X:\Welded_Master_Library\WELD_DESIGN_TABLES_MAIN\BEC_RA_PI_GR_THREADEDEND.XLS", "C:\WELD_DESIGN_TABLES\BEC_RA_PI_GR_THREADEDEND.XLS")
    '        '    strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_RA_PI_GR_THREADEDEND.XLS"
    '        'ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" AndAlso _
    '        '  ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "FILLET" Then
    '        '    ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory("C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_RA_PI_FI_THREADEDEND")
    '        '    If File.Exists("C:\MONARCH_TESTING\WELDED_LIBRARY\BASE_END_THREADED\BEC_RA_PI_GR_THREADEDEND\BEC_RA_PI_FI_THREADEDEND.SLDPRT") = False Then
    '        '        File.Copy("X:\Welded_Master_Library\WELDED_LIBRARY\BASE_END_THREADED\BEC_RA_PI_GR_THREADEDEND\BEC_RA_PI_FI_THREADEDEND.SLDPRT", "C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_RA_PI_GR_THREADEDEND\BEC_RA_PI_FI_THREADEDEND.SLDPRT")
    '        '    End If
    '        '    strFilePart = "C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_RA_PI_GR_THREADEDEND\BEC_RA_PI_FI_THREADEDEND.SLDPRT"
    '        '    File.Copy("X:\Welded_Master_Library\WELD_DESIGN_TABLES_MAIN\BEC_RA_PI_FI_THREADEDEND.XLS", "C:\WELD_DESIGN_TABLES\BEC_RA_PI_FI_THREADEDEND.XLS")
    '        '    strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_RA_PI_FI_THREADEDEND.XLS"
    '        'End If
    '        'ObjClsWeldedCylinderFunctionalClass.Design_New_Part(strFilePart, strFilePartDesignTableExcel, strName)
    '        'ObjClsWeldedCylinderFunctionalClass.GenerateCasting = False
    '        Dim oListViewItem As ListViewItem
    '        oListViewItem = lvwThreadedDetails.Items.Add(txtThreadedDiameter.Text)
    '        lvwThreadedDetails.Items(_intSafetyFactorCount).SubItems.Add(txtThreadedLength.Text)
    '        lvwThreadedDetails.Items(_intSafetyFactorCount).SubItems.Add(txtSwingClearance.Text)
    '        _intSafetyFactorCount += 1
    '        Me.Cursor = Cursors.Default
    '    Catch ex As Exception
    '    End Try
    'End Sub

#End Region

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False        '20_10_2010   RAGAVA
        ''Added by Sandeep --set  This parameter for retracted length calculation(the value which we are going to insert in db)
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinHoletoRodStop = oSelectedCastingDataRow("DistancefromPinholetoRodStop")
        ' If (MessageBox.Show("Click OK if you want to change the Tube Details with the selected one's", "Chnage Tube details", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign)) = Windows.Forms.DialogResult.OK Then
        ObjClsWeldedCylinderFunctionalClass.TxtThreadDiameter_BaseEnd.Text = cmbThreadedDiameter.Text
        ObjClsWeldedCylinderFunctionalClass.TxtThreadLength_BaseEnd.Text = txtThreadedLength.Text
        'End If
        'Aruna :11-3-2010---------------
        If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = -0.125
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = 0.5 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength
        ElseIf ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" Then           '14_05_2010       RAGAVA
                Dim oSelectedRESLDataRow As DataRow = Nothing
                Dim baseDia As Double
                Dim PortBossDia As Double
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortBossDiaAndBaseDia(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter)
                If Not IsNothing(oSelectedRESLDataRow) Then
                    If Not IsDBNull(oSelectedRESLDataRow("BASEDIA")) Then
                        baseDia = oSelectedRESLDataRow("BASEDIA")
                    End If
                    If Not IsDBNull(oSelectedRESLDataRow("PortBossDia")) Then
                        PortBossDia = oSelectedRESLDataRow("PortBossDia")
                    End If
                End If
                Dim dblButtonPosition As Double
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2 Then
                    dblButtonPosition = 0.273
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter > 2 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 3 Then
                    dblButtonPosition = 0.281
                Else
                    dblButtonPosition = 0.5
                End If

                Dim dblOverAllLength As Double
                Dim dblTan_30 As Double = 0.57735026918962573
                dblOverAllLength = ((baseDia - ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter) / 2) * dblTan_30 + 0.17 + 0.2 + PortBossDia
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = dblButtonPosition - 0.125

                Dim _strQuery As String = ""
                Dim dblButtonPlane As Double
                Dim dblTotalWidth As Double
                Dim oSelectedREThreadedCastingDataRow As DataRow = Nothing
                _strQuery = "Select * from welded.portIntegralDetails where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and TubeWallThickness= " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " and portDiameter= " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text = "3/4", 1.1, 0.9).ToString
                oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
                If Not IsNothing(oSelectedREThreadedCastingDataRow) Then
                    If Not IsDBNull(oSelectedREThreadedCastingDataRow("ButtonPlane")) Then
                        dblButtonPlane = oSelectedREThreadedCastingDataRow("ButtonPlane")
                    End If
                    If Not IsDBNull(oSelectedREThreadedCastingDataRow("TotalWidth")) Then
                        dblTotalWidth = oSelectedREThreadedCastingDataRow("TotalWidth")
                    End If
                End If
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = -0.125   'jinka
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = dblButtonPlane + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength
            End If
        End If
        btnAccept.Enabled = False
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
    End Sub
    Private Sub SafetyFactor_LugThickness_Weight_GeneretedDesign()
        lvwSafetyFactor_Weight.Clear()
        lvwSafetyFactor_Weight.Columns.Add("SafetyFactor", 130, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight.Columns.Add("LugThickness", 130, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight.Columns.Add("Weight", 125, HorizontalAlignment.Center)
        lvwSafetyFactor_Weight.FullRowSelect = True
    End Sub
    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Try
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDesignSelected = True          '01_04_2010   ARUNA
            Me.Cursor = Cursors.WaitCursor
            If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = -0.125
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DistanceFromPinholetoRodStop = 0.5 + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength
            ElseIf ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then

                '27_04_2010   RAGAVA  NEW DESIGN
                Dim _strQuery As String = ""
                Dim oSelectedRESLDataRow As DataRow = Nothing
                If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then       '19_05_2010   RAGAVA     NEW DESIGN
                        _strQuery = "Select * from PortIntegralRaisedPortDetails where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness and portSize = " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text = "3/4", 0.75, 0.5625).ToString
                        oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = 0
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = 0
                        If Not IsNothing(oSelectedRESLDataRow) Then
                            If Not IsDBNull(oSelectedRESLDataRow("StickOut")) Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = oSelectedRESLDataRow("StickOut")
                            End If
                            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Threaded End" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedRESLDataRow("MinWallTHickness") + oSelectedRESLDataRow("ButtonHeight") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength 'min wall THK + button height + swing scearence+thread length
                            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedRESLDataRow("MinWallTHickness") + oSelectedRESLDataRow("ButtonHeight") 'min wall THK + button height 
                            Else
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedRESLDataRow("MinWallTHickness") + oSelectedRESLDataRow("ButtonHeight") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance ' min wall THK + button height + swing scearence
                            End If
                        End If
                        '19_05_2010   RAGAVA     NEW DESIGN
                    Else
                        _strQuery = "Select * from PortIntegralRaisedPortDetails90 where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness and portSize = " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text = "3/4", 0.75, 0.5625).ToString
                        oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = 0
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = 0
                        If Not IsNothing(oSelectedRESLDataRow) Then
                            If Not IsDBNull(oSelectedRESLDataRow("DistanceFromTubeEndToRodStop")) Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = oSelectedRESLDataRow("DistanceFromTubeEndToRodStop")
                            End If
                            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Threaded End" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedRESLDataRow("MinWallThickness") + oSelectedRESLDataRow("ButtonHeight") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength 'min wall THK + button height + swing scearence+thread length
                            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis" Then
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedRESLDataRow("MinWallThickness") + oSelectedRESLDataRow("ButtonHeight") 'min wall THK + button height 
                            Else
                                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedRESLDataRow("MinWallThickness") + oSelectedRESLDataRow("ButtonHeight") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance ' min wall THK + button height + swing scearence
                            End If
                        End If
                    End If
                    'Till  Here
                Else
                    Dim baseDia As Double
                    Dim PortBossDia As Double
                    oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortBossDiaAndBaseDia(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter)
                    If Not IsNothing(oSelectedRESLDataRow) Then
                        If Not IsDBNull(oSelectedRESLDataRow("BASEDIA")) Then
                            baseDia = oSelectedRESLDataRow("BASEDIA")
                        End If
                        If Not IsDBNull(oSelectedRESLDataRow("PortBossDia")) Then
                            PortBossDia = oSelectedRESLDataRow("PortBossDia")
                        End If
                    End If
                    Dim dblButtonPosition As Double
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2 Then
                        dblButtonPosition = 0.273
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter > 2 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 3 Then
                        dblButtonPosition = 0.281
                    Else
                        dblButtonPosition = 0.5
                    End If
                    Dim dblOverAllLength As Double
                    Dim dblTan_30 As Double = 0.57735026918962573
                    dblOverAllLength = ((baseDia - (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter + 0.08)) / 2) * dblTan_30 + 0.17 + 0.2 + PortBossDia
                    '5_04_2010 Aruna
                    ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = dblButtonPosition - 0.125
                    _strQuery = ""
                    Dim dblButtonPlane As Double
                    Dim dblTotalWidth As Double
                    _strQuery = "Select * from welded.portIntegralDetails where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and TubeWallThickness= " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " and portDiameter= " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text = "3/4", 1.1, 0.9).ToString
                    oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
                    If Not IsNothing(oSelectedRESLDataRow) Then
                        If Not IsDBNull(oSelectedRESLDataRow("ButtonPlane")) Then
                            dblButtonPlane = oSelectedRESLDataRow("ButtonPlane")
                        End If
                        If Not IsDBNull(oSelectedRESLDataRow("TotalWidth")) Then
                            dblTotalWidth = oSelectedRESLDataRow("TotalWidth")
                        End If
                    End If
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = dblTotalWidth - dblButtonPlane - 0.125
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = -0.125  'jinka
                    '5_04_2010 Aruna Ends

                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = dblOverAllLength + dblButtonPosition + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = dblOverAllLength + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength
                End If
            End If

            If txtThreadedLength.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.TxtThreadLength_BaseEnd.Text = txtThreadedLength.Text
            End If
            ObjClsWeldedCylinderFunctionalClass.GenerateCasting = True
            Dim strFilePart As String = ""
            Dim strFilePartDesignTableExcel As String = ""
            Dim strName As String = "NewSingleLugCastingPartCopied"
            If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
                strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_THREADEDEND\BEC_NO_PO_GR_THREADEDEND.SLDPRT"
                strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_NO_PO_GR_THREADEDEND.XLS"
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_NO_PO_GR_THREADEDEND"
                'Aruna 19_3_2010
                ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_THREADEDEND", True)
            Else
                If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then    '08_06_2010    RAGAVA
                    '27_04_2010   RAGAVA   NEW DESIGN
                    If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then       '19_05_2010   RAGAVA     NEW DESIGN
                        strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_THREADEDEND\BEC_RA_PI_FI_THREADEDEND.SLDPRT"
                        strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_RA_PI_FI_THREADEDEND.XLS"
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_THREADEDEND"
                        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_THREADEDEND", True)
                        '19_05_2010   RAGAVA     NEW DESIGN
                    Else
                        strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_RA_PI_FI_THREADEDEND_90\BEC_RA_PI_FI_THREADEDEND_90.SLDPRT"
                        strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_RA_PI_FI_THREADEDEND_90.XLS"
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_THREADEDEND_90"
                        ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_NO_PO_GR_THREADEDEND_90", True)
                    End If
                    '08_06_2010    RAGAVA
                Else
                    strFilePart = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_THREADEDEND\BEC_FL_PI_GR_THREADEDEND.SLDPRT"
                    strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_FL_PI_GR_THREADEDEND.XLS"
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PI_GR_THREADEDEND"
                    ObjClsWeldedCylinderFunctionalClass.UpdateHashTableValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FolderDeletionHashTable, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath + "\BEC_FL_PI_GR_THREADEDEND", True)
                End If
                'Till    Here
            End If
            ObjClsWeldedCylinderFunctionalClass.NewSLCastingPartCopied = True
            ObjClsWeldedCylinderFunctionalClass.Design_New_Part(strFilePart, strFilePartDesignTableExcel, strName)
            ObjClsWeldedCylinderFunctionalClass.GenerateCasting = False
            Dim dblWeight As Double = ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Weight")
            Dim blnDuplicateFound As Boolean = False
            If lvwSafetyFactor_Weight.Items.Count > 0 Then
                For Each oItem As ListViewItem In lvwSafetyFactor_Weight.Items
                    If oItem.SubItems(WeightListView.ThreadLength).Text.Equals(txtThreadedLength.Text) AndAlso _
                    oItem.SubItems(WeightListView.swingClearance).Text.Equals(txtSwingClearance.Text) Then
                        blnDuplicateFound = True
                    End If
                Next
            End If
            If Not blnDuplicateFound Then
                Dim oListViewItem As New ListViewItem
                oListViewItem.Text = txtSwingClearance.Text
                oListViewItem.SubItems.Add(txtThreadedLength.Text)
                oListViewItem.SubItems.Add(dblWeight)
                lvwSafetyFactor_Weight.Items.Add(oListViewItem)
                'lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(txtThreadedLength.Text)
                'lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(dblWeight)
                '_intSafetyFactorCount += 1
            End If
            Me.Cursor = Cursors.Default
            '09_04_2010 Aruna
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength = Val(txtThreadedLength.Text)
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadDiameter = Val(cmbThreadedDiameter.SelectedValue)
            '9_04_2010 Aruna
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Cast"
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "NewDesign"

            '------------------

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in btnGenerate_Click of frmThreadedEndDesignCasting " + ex.Message)
        End Try
    End Sub

    Private Sub lvwSafetyFactor_Weight_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwSafetyFactor_Weight.SelectedIndexChanged
        If lvwSafetyFactor_Weight.SelectedIndices.Count > 0 Then
            Dim oListViewSelectedItem As ListViewItem = lvwSafetyFactor_Weight.SelectedItems(0)
            txtThreadedLength.Text = oListViewSelectedItem.SubItems(WeightListView.ThreadLength).Text
            txtSwingClearance.Text = oListViewSelectedItem.SubItems(WeightListView.swingClearance).Text
            btnAccept.Enabled = True
            ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
            ObjClsWeldedCylinderFunctionalClass.BaseEndWeight = Val(oListViewSelectedItem.SubItems(WeightListView.Weight).Text)
        End If
    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblDesignNewCasting)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblSafetyFactorIndex)
    End Sub
    
End Class