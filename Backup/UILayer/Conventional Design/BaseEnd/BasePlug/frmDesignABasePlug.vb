Imports System.IO
Public Class frmDesignABasePlug

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

#Region "SubProcedures"

    Private Sub DefaultSettings()
        txtOutsidePlugDia.Enabled = False
        txtMilledFlatWidth.Enabled = False
        txtMilledFlatHeight.Enabled = False
        txtSwingClearance.Enabled = False
        txtPinHoleSize.Enabled = False
        txtWeight.Enabled = False
        btnAccept.Enabled = True
    End Sub

    Private Sub InitialValues()
        'ANUP 11-10-2010 START
        If ObjClsWeldedCylinderFunctionalClass.IsAnyValueChangedWhileRevision() Then
            IsPopulated = True
        End If
        'ANUP 11-10-2010 TILL HERE
        txtOutsidePlugDia.Text = ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.txtOutSidePlugDiameter.Text
        txtMilledFlatHeight.Text = ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.txtMilledFlatLength.Text
        txtMilledFlatWidth.Text = ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.txtMilledFlatWidth.Text
        txtPinHoleSize.Text = ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.txtPinHoleSize.Text
        If Trim(txtPinHoleSize.Text) = "" Then
            txtPinHoleSize.Text = ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbPinHoleSize.Text
        End If
        txtSwingClearance.Text = ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.txtSwingClearance.Text
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = False
        btnAccept.Enabled = True
    End Sub

    Public Sub ManualLoad()
        InitialValues()
    End Sub

    'Private Sub SafetyFactor_LugThickness_Weight_GeneretedDesign()
    '    lvwSafetyFactor_Weight.Clear()
    '    lvwSafetyFactor_Weight.Columns.Add("BasePlugDia", 130, HorizontalAlignment.Center)
    '    lvwSafetyFactor_Weight.Columns.Add("PinHoleSize", 130, HorizontalAlignment.Center)
    '    lvwSafetyFactor_Weight.Columns.Add("SwingClearance", 130, HorizontalAlignment.Center)
    '    lvwSafetyFactor_Weight.Columns.Add("Weight", 125, HorizontalAlignment.Center)
    '    lvwSafetyFactor_Weight.FullRowSelect = True
    'End Sub

#End Region

#Region "Events"

    'Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        'Dim strFilePart As String = ""
    '        'Dim strFilePartDesignTableExcel As String = ""
    '        'Dim strName As String = "NewBasePlugPartCopied"
    '        '' If ObjClsWeldedCylinderFunctionalClass.NewBasePlugPartCopied = False Then
    '        'If Directory.Exists("C:\MONARCH_TESTING") = False Then
    '        '    Directory.CreateDirectory("C:\MONARCH_TESTING")
    '        'End If

    '        'If Directory.Exists("C:\WELD_DESIGN_TABLES") = True Then
    '        '    Directory.Delete("C:\WELD_DESIGN_TABLES", True)
    '        'End If
    '        'Directory.CreateDirectory("C:\WELD_DESIGN_TABLES")

    '        ''05_01_2009 Aruna Code Starts Here

    '        'If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" AndAlso _
    '        ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "OUTSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
    '        '    ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory("C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_NO_PO_GR_BASEPLUG")
    '        '    If File.Exists("C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_NO_PO_GR_BASEPLUG\BEC_NO_PO_GR_BASEPLUG.SLDPRT") = False Then
    '        '        File.Copy("X:\Welded_Master_Library\WELDED_LIBRARY\BEC_NO_PO_GR_BASEPLUG\BEC_NO_PO_GR_BASEPLUG.SLDPRT", "C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_NO_PO_GR_BASEPLUG\BEC_NO_PO_GR_BASEPLUG.SLDPRT")
    '        '    End If
    '        '    strFilePart = "C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_NO_PO_GR_BASEPLUG\BEC_NO_PO_GR_BASEPLUG.SLDPRT"
    '        '    File.Copy("X:\Welded_Master_Library\WELD_DESIGN_TABLES_MAIN\BEC_NO_PO_GR_BASEPLUG.XLS", "C:\WELD_DESIGN_TABLES\BEC_NO_PO_GR_BASEPLUG.XLS")
    '        '    strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_NO_PO_GR_BASEPLUG.XLS"
    '        'ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" AndAlso _
    '        '                 ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
    '        '    ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory("C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_FL_PI_GR_BASEPLUG")
    '        '    If File.Exists("C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_FL_PI_GR_BASEPLUG\BEC_FL_PI_GR_BASEPLUG.SLDPRT") = False Then
    '        '        File.Copy("X:\Welded_Master_Library\WELDED_LIBRARY\BEC_FL_PI_GR_BASEPLUG\BEC_FL_PI_GR_BASEPLUG.SLDPRT", "C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_FL_PI_GR_BASEPLUG\BEC_FL_PI_GR_BASEPLUG.SLDPRT")
    '        '    End If
    '        '    strFilePart = "C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_FL_PI_GR_BASEPLUG\BEC_FL_PI_GR_BASEPLUG.SLDPRT"
    '        '    File.Copy("X:\Welded_Master_Library\WELD_DESIGN_TABLES_MAIN\BEC_FL_PI_GR_BASEPLUG.XLS", "C:\WELD_DESIGN_TABLES\BEC_FL_PI_GR_BASEPLUG.XLS")
    '        '    strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_FL_PI_GR_BASEPLUG.XLS"
    '        'ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "FLUSHED" AndAlso _
    '        '            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "OUTSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
    '        '    ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory("C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_FL_PO_GR_BASEPLUG")
    '        '    If File.Exists("C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_FL_PO_GR_BASEPLUG\BEC_FL_PO_GR_BASEPLUG.SLDPRT") = False Then
    '        '        File.Copy("X:\Welded_Master_Library\WELDED_LIBRARY\BEC_FL_PO_GR_BASEPLUG\BEC_FL_PO_GR_BASEPLUG.SLDPRT", "C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_FL_PO_GR_BASEPLUG\BEC_FL_PO_GR_BASEPLUG.SLDPRT")
    '        '    End If
    '        '    strFilePart = "C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_FL_PO_GR_BASEPLUG\BEC_FL_PO_GR_BASEPLUG.SLDPRT"
    '        '    File.Copy("X:\Welded_Master_Library\WELD_DESIGN_TABLES_MAIN\BEC_FL_PI_GR_BASEPLUG.XLS", "C:\WELD_DESIGN_TABLES\BEC_FL_PO_GR_BASEPLUG.XLS")
    '        '    strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_FL_PO_GR_BASEPLUG.XLS"
    '        'ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" AndAlso _
    '        '       ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "GROOVE" Then
    '        '    ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory("C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_RA_PI_GR_BASEPLUG")
    '        '    If File.Exists("C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_RA_PI_GR_BASEPLUG\BEC_RA_PI_GR_BASEPLUG.SLDPRT") = False Then
    '        '        File.Copy("X:\Welded_Master_Library\WELDED_LIBRARY\BEC_RA_PI_GR_BASEPLUG\BEC_RA_PI_GR_BASEPLUG.SLDPRT", "C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_RA_PI_GR_BASEPLUG\BEC_RA_PI_GR_BASEPLUG.SLDPRT")
    '        '    End If
    '        '    strFilePart = "C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_RA_PI_GR_BASEPLUG\BEC_RA_PI_GR_BASEPLUG.SLDPRT"
    '        '    File.Copy("X:\Welded_Master_Library\WELD_DESIGN_TABLES_MAIN\BEC_FL_PI_GR_BASEPLUG.XLS", "C:\WELD_DESIGN_TABLES\BEC_RA_PI_GR_BASEPLUG.XLS")
    '        '    strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_RA_PI_GR_BASEPLUG.XLS"
    '        'ElseIf UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" AndAlso _
    '        '  ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonLocation = "INSIDE" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldType = "FILLET" Then
    '        '    ObjClsWeldedCylinderFunctionalClass.checkAndCreateDirectory("C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_RA_PI_FI_BASEPLUG")
    '        '    If File.Exists("C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_RA_PI_FI_BASEPLUG\BEC_RA_PI_FI_BASEPLUG.SLDPRT") = False Then
    '        '        File.Copy("X:\Welded_Master_Library\WELDED_LIBRARY\BEC_RA_PI_FI_BASEPLUG\BEC_RA_PI_FI_BASEPLUG.SLDPRT", "C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_RA_PI_FI_BASEPLUG\BEC_RA_PI_FI_BASEPLUG.SLDPRT")
    '        '    End If
    '        '    strFilePart = "C:\MONARCH_TESTING\WELDED_LIBRARY\BEC_RA_PI_FI_BASEPLUG\BEC_RA_PI_FI_BASEPLUG.SLDPRT"
    '        '    File.Copy("X:\Welded_Master_Library\WELD_DESIGN_TABLES_MAIN\BEC_RA_PI_FI_BASEPLUG.XLS", "C:\WELD_DESIGN_TABLES\BEC_RA_PI_FI_BASEPLUG.XLS")
    '        '    strFilePartDesignTableExcel = "C:\WELD_DESIGN_TABLES\BEC_RA_PI_FI_BASEPLUG.XLS"
    '        'End If
    '        ''05_01_2009 Aruna Code Ends Here

    '        ''If File.Exists("C:\MONARCH_TESTING\WELDED_LIBRARY\BE_BASEPLUG\BE_Baseplug_IFL.SLDPRT") = False Then
    '        ''    File.Copy("X:\Welded_Master_Library\WELDED_LIBRARY\BE_BASEPLUG\BE_Baseplug_IFL.SLDPRT", "C:\MONARCH_TESTING\WELDED_LIBRARY\BE_BASEPLUG\BE_Baseplug_IFL.SLDPRT")
    '        ''End If
    '        '' ObjClsWeldedCylinderFunctionalClass.NewBasePlugPartCopied = True
    '        ''  End If
    '        ''"C:\WELD_DESIGN_TABLES\

    '        'ObjClsWeldedCylinderFunctionalClass.Design_New_Part(strFilePart, strFilePartDesignTableExcel, strName)
    '        ''24_11_2009    Ragava
    '        'txtWeight.Text = ObjClsWeldedCylinderFunctionalClass.GetCustomPropertyValue("Weight")
    '        '24_11_2009    Ragava   Till  Here
    '        Dim oListViewItem As ListViewItem
    '        oListViewItem = lvwSafetyFactor_Weight.Items.Add(txtBasePlugDia.Text)
    '        lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(txtPinHoleSize.Text)
    '        lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(txtSwingClearance.Text)
    '        lvwSafetyFactor_Weight.Items(_intSafetyFactorCount).SubItems.Add(txtWeight.Text)
    '        _intSafetyFactorCount += 1
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub frmDesignABasePlug_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        DefaultSettings()
        InitialValues()
    End Sub

    Private Sub btnAccept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccept.Click
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.blnExistingPartSelected_BaseEnd = False        '20_10_2010   RAGAVA
        ''Added by Sandeep --set  This parameter for retracted length calculation(the value which we are going to insert in db)
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinHoletoRodStop = oSelectedCastingDataRow("DistancefromPinholetoRodStop")
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = Val(txtSwingClearance.Text) + 0.5      '18_03_2010   RAGAVA
        '5_04_2010 Aruna
        ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = dblButtonPosition - 0.125
        If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = -0.125
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = Val(txtSwingClearance.Text) + 0.5      '18_03_2010   RAGAVA

        ElseIf ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then

            '27_04_2010   RAGAVA
            Dim _strQuery As String = ""
            Dim oSelectedRESLDataRow As DataRow = Nothing
            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then          '19_05_2010   RAGAVA     NEW DESIGN
                    _strQuery = "Select * from PortIntegralRaisedPortDetails where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness and portSize = " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text = "3/4", 0.75, 0.5625).ToString
                    oSelectedRESLDataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = 0
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = 0
                    If Not IsNothing(oSelectedRESLDataRow) Then
                        If Not IsDBNull(oSelectedRESLDataRow("StickOut")) Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = oSelectedRESLDataRow("StickOut")
                        End If
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Threaded End" Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedRESLDataRow("MinWallThickness") + oSelectedRESLDataRow("ButtonHeight") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength 'min wall THK + button height + swing scearence+thread length
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis" Then
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedRESLDataRow("MinWallThickness") + oSelectedRESLDataRow("ButtonHeight") 'min wall THK + button height 
                        Else
                            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = oSelectedRESLDataRow("MinWallThickness") + oSelectedRESLDataRow("ButtonHeight") + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance ' min wall THK + button height + swing scearence
                        End If
                    End If
                    '19_05_2010   RAGAVA  NEW  DESIGN
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

                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2.5 Then
                    dblButtonPosition = 0.273
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter > 2.5 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 3 Then
                    dblButtonPosition = 0.281
                Else
                    dblButtonPosition = 0.5
                End If
                _strQuery = ""
                Dim dblButtonPlane As Double

                Dim dblOverAllLength As Double
                Dim dblTan_30 As Double = 0.57735026918962573
                dblOverAllLength = ((baseDia - (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter + 0.08)) / 2) * dblTan_30 + 0.17 + 0.2 + PortBossDia
                'dblOverAllLength = ((baseDia - (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter + 0.08)) / 2) * dblTan_30 + 0.045 + 0.125 + 0.2 + PortBossDia

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
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.EndofTubetoRodStop = -0.125
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndDistanceFromPinholetoRodStop = dblOverAllLength + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SwingClearance
            End If
        End If
        '5_04_2010 Aruna Ends
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesign = "NewDesign"             '11_03_2010   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Cast" '05_04_2010 Aruna
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        '18_03_2010    RAGAVA
        If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port In Tube" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_NO_PO_GR_BASEPLUG"
        ElseIf ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
            '27_04_2010   RAGAVA  NEW DESIGN
            If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_BASEPLUG"
                '19_05_2010   RAGAVA     NEW DESIGN
                If ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "Straight" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_BASEPLUG"
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_RA_PI_FI_BASEPLUG_90"
                End If
                'Till   Here
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PI_GR_BASEPLUG"
            End If
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPartName = "BEC_FL_PI_GR_BASEPLUG"
            'Till   Here
        End If
        'Till    Here
        ObjClsWeldedCylinderFunctionalClass.NextClick.Enabled = True
        btnAccept.Enabled = False
    End Sub

#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblDesignNewBasePlug)
    End Sub

End Class