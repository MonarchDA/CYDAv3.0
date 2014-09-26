Public Class frmPortDetails

#Region "Private Variables"

    Public _strBaseEndPortCode As String

    Private _strBaseEndPortLocatorCode As String
    Private _strRodEndPortLocatorCode As String
    Public _strRodEndPortCode As String
    Private _strTempDesignType As String = ""

    Private _strTempBaseEndConfiguration As String = ""

    Private _strTempBaseEndPort As String = ""

    Private _strTempPortInsertion As String = ""

    Private _dblPortOD_Weld As Double

    Private _strDustPlug As String

    Private _strPermamentPlug As String

    Private _strRodEndPortBase As String

    Private _strBaseEndPortBase As String

    Private _blnCheckBocCheckedFunctionality_SelectedIndex As Boolean

    'A0308: ANUP 09-08-2010 02.15pm
    Private _oFrmImportPorts As frmImportPorts

    'ANUP 06-10-2010 START
    Private _strBaseEndPortCode_Purchase As String = String.Empty
    Private _strRodEndPortCode_Purchase As String = String.Empty
    Public _strBaseEndPortLocatorCode_Purchase As String = String.Empty
    Public _strRodEndPortLocatorCode_Purchase As String = String.Empty
    'ANUP 06-10-2010 TILL HERE

#End Region

#Region "Properties"

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

    Public ReadOnly Property ControlsData() As ArrayList
        Get
            ControlsData = New ArrayList
            ControlsData.Add(New Object(3) {"GUI", "BASE END NOOFPORTS", "L27", cmbNoofPortsBaseEnd.Text})
            ControlsData.Add(New Object(3) {"GUI", "BASE END PORTTYPE", "L28", cmbPortTypeBaseEnd.Text})

            '01-03-10 Sandeep 10am
            Dim strPortAngle_BaseEnd As String = ""
            If cmbPortAngleBaseEnd.Text = "90" Then
                strPortAngle_BaseEnd = "90 degrees"
            Else
                strPortAngle_BaseEnd = cmbPortAngleBaseEnd.Text
            End If
            ControlsData.Add(New Object(3) {"GUI", "BASE END PORTANGLE", "L29", strPortAngle_BaseEnd})
            '***************************

            ControlsData.Add(New Object(3) {"GUI", "BASE END ORIFICESIZE", "L30", cmbOrificeSizeBaseEnd.Text})

            ' Sandeep 26-02-10-11am
            If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
                ControlsData.Add(New Object(3) {"GUI", "BASE END PORTSIZE", "L31", ConvertFractionsToDecimals(Trim(cmbPortSizeBaseEnd.Text))})
            Else
                ControlsData.Add(New Object(3) {"GUI", "BASE END PORTSIZE", "L31", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd})
            End If
            '***************************

            ControlsData.Add(New Object(3) {"DB", "BASE END PORTLOCATOR", "L32", _strBaseEndPortLocatorCode})

            ControlsData.Add(New Object(3) {"DB", "BASE END PORTCODE", "L33", _strBaseEndPortCode})
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPortCode = _strBaseEndPortCode           '18_10_2010   RAGAVA

            If ObjClsWeldedCylinderFunctionalClass.IsImportPortsButtonClicked Then
                ControlsData.Add(New Object(3) {"DB", "BASE END PORTODATWELD", "L34", ObjFrmImportPorts.PortODAtWeld_ControlsDataExcel})
            Else
                ControlsData.Add(New Object(3) {"DB", "BASE END PORTODATWELD", "L34", _dblPortOD_Weld})
            End If


            ControlsData.Add(New Object(3) {"DB", "DUSTPLUG", "L35", _strDustPlug})
            ControlsData.Add(New Object(3) {"DB", "PERMANENTPLUG", "L36", _strPermamentPlug})

            ControlsData.Add(New Object(3) {"DB", "WPDS", "L37", ""})

            ControlsData.Add(New Object(3) {"GUI", "RODEND NO OF PORTS", "L51", Val(cmbNoofPortsRodEnd.Text)})

            ControlsData.Add(New Object(3) {"GUI", "RODEND PORTTYPE ", "L52", cmbPortTypeRodEnd.Text})
            '01-03-10 Sandeep 10am
            Dim strPortAngle_RodEnd As String = ""
            If cmbPortAngleRodEnd.Text = "90" Then
                strPortAngle_RodEnd = "90 degrees"
            Else
                strPortAngle_RodEnd = cmbPortAngleRodEnd.Text
            End If
            ControlsData.Add(New Object(3) {"GUI", "RODEND PORTANGLE", "L53", strPortAngle_RodEnd})
            '***************************

            ControlsData.Add(New Object(3) {"GUI", "RODEND ORIFICESIZE ", "L54", cmbOrificeSizeRodEnd.Text})

            ' Sandeep 24-02-10-5:30pm
            'ControlsData.Add(New Object(3) {"GUI", "RODEND PORTSIZE ", "L55", ConvertFractionsToDecimals(Trim(cmbPortSizeRodEnd.Text))})

            'Sandeep 26-02-10-11am
            ControlsData.Add(New Object(3) {"GUI", "RODEND PORTSIZE", "L55", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_RodEnd})
            '***************************

            ControlsData.Add(New Object(3) {"DB", "ROD END PORTLOCATOR CODE", "L56", _strRodEndPortLocatorCode})

            ControlsData.Add(New Object(3) {"DB", "ROD END PORTCODE", "L57", _strRodEndPortCode})

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPortCode = _strRodEndPortCode           '18_10_2010   RAGAVA

            If Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
                'anup 04-03-2011 start 
                'If _strBaseEndPortLocatorCode.Equals(_strRodEndPortLocatorCode) Then
                '    If Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then
                '        clsAddExistingCodes.AddBaseEndPortLocatorCode(_strBaseEndPortLocatorCode_Purchase, 2, "EA")
                '    End If
                'Else
                '    If Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then
                '        clsAddExistingCodes.AddBaseEndPortLocatorCode(_strBaseEndPortLocatorCode_Purchase, 1, "EA")
                '    End If
                '    clsAddExistingCodes.AddRodEndPortLocatorCode(_strRodEndPortLocatorCode_Purchase, 1, "EA")
                'End If
                'anup 04-03-2011 till here

                If _strBaseEndPortCode.Equals(_strRodEndPortCode) Then
                    '29_10_2010   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then
                        clsAddExistingCodes.AddRodEndPortCode(_strRodEndPortCode_Purchase, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd.ToString, "EA")
                    Else
                        clsAddExistingCodes.AddRodEndPortCode(_strRodEndPortCode_Purchase, (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd).ToString, "EA")
                    End If
                    'Till  Here
                Else
                    If Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then
                        clsAddExistingCodes.AddBaseEndPortCode(_strBaseEndPortCode_Purchase, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd.ToString, "EA")
                    End If
                    clsAddExistingCodes.AddRodEndPortCode(_strRodEndPortCode_Purchase, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd.ToString, "EA")
                End If
            End If

            ControlsData.Add(New Object(3) {"GUI", "BASEEND FIRST PORTORIENTATION", "L58", Val(txtFirstPortOrientationBaseEnd.Text)})
            ControlsData.Add(New Object(3) {"GUI", "BASEEND SECOND PORTORIENTATION", "L59", Val(txtSecondPortOrientationBaseEnd.Text)})
            ControlsData.Add(New Object(3) {"GUI", "BASEEND PORTFACING", "L60", cmbPortFacingBaseEnd.Text})

            ControlsData.Add(New Object(3) {"GUI", "RODEND FIRST PORTORIENTATION", "L61", Val(txtFirstPortOrientationRodEnd.Text)})
            ControlsData.Add(New Object(3) {"GUI", "RODEND SECOND PORTORIENTATION", "L62", Val(txtSecondPortOrientationRodEnd.Text)})
            ControlsData.Add(New Object(3) {"GUI", "RODEND PORTFACING", "L63", cmbPortFacingRodEnd.Text})

            If ObjClsWeldedCylinderFunctionalClass.IsImportPortsButtonClicked Then
                ControlsData.Add(New Object(3) {"DB", "ROD END PORT BASE", "L74", ObjFrmImportPorts.PortEndTypeBaseEnd_ControlsDataExcel()})
                ControlsData.Add(New Object(3) {"DB", "ROD END PORT BASE", "L75", ObjFrmImportPorts.PortEndTypeRodEnd_ControlsDataExcel()})
            Else
                ControlsData.Add(New Object(3) {"DB", "BASE END PORT BASE", "L74", _strBaseEndPortBase})
                ControlsData.Add(New Object(3) {"DB", "ROD END PORT BASE", "L75", _strRodEndPortBase})
            End If

            Return ControlsData
        End Get
    End Property

    Public ReadOnly Property PortSizes_Decimals() As ArrayList
        Get
            Dim aPortSizes_Decimals As New ArrayList
            aPortSizes_Decimals.Add(New Object(1) {"1/2", 0.5})
            aPortSizes_Decimals.Add(New Object(1) {"1/4", 0.25})
            aPortSizes_Decimals.Add(New Object(1) {"1/8", 0.125})
            aPortSizes_Decimals.Add(New Object(1) {"1/16", 0.0625})
            aPortSizes_Decimals.Add(New Object(1) {"3/4", 0.75})
            aPortSizes_Decimals.Add(New Object(1) {"3/8", 0.375})
            aPortSizes_Decimals.Add(New Object(1) {"7/8", 0.875})
            aPortSizes_Decimals.Add(New Object(1) {"7/16", 0.4375})
            aPortSizes_Decimals.Add(New Object(1) {"9/16", 0.5625})
            aPortSizes_Decimals.Add(New Object(1) {"1 1/16", 1.0625})
            Return aPortSizes_Decimals
        End Get
    End Property

    'A0308: ANUP 09-08-2010 02.15pm
    Public Property ObjFrmImportPorts() As frmImportPorts
        Get
            Return _oFrmImportPorts
        End Get
        Set(ByVal value As frmImportPorts)
            _oFrmImportPorts = value
        End Set
    End Property

#End Region

#Region "SubProcedures"

    Public Sub ManualLoad()

        'TODO:  ANUP 24-05-2010 10.36am
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GoToBaseEndScreenFromRetractedScreen Then
            ObjClsWeldedCylinderFunctionalClass.NextClick.PerformClick()
        End If
        '***************

        If Not _strTempDesignType = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType _
        OrElse Not _strTempBaseEndConfiguration = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration _
         OrElse Not _strTempBaseEndPort = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort _
          OrElse Not _strTempPortInsertion = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion Then
            _strTempDesignType = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType
            _strTempBaseEndConfiguration = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration
            _strTempBaseEndPort = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort
            _strTempPortInsertion = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion
            LoadFunctionality_BaseEnd()
        End If

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        _oFrmImportPorts = New frmImportPorts

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Function ConvertFractionsToDecimals(ByVal strFractionValue As String) As Double
        ConvertFractionsToDecimals = 0
        Try
            For Each oItem As Object In PortSizes_Decimals
                If oItem(0).Equals(strFractionValue) Then
                    ConvertFractionsToDecimals = oItem(1)
                    Exit Function
                End If
            Next
        Catch ex As Exception
            ConvertFractionsToDecimals = 0
        End Try
    End Function

    Private Sub LoadFunctionality_BaseEnd()

        ObjClsWeldedCylinderFunctionalClass.IsImportPortsButtonClicked = False

        LoadNoOfPorts_BaseEnd()
        LoadPortType_BaseEnd()
        LoadPortAngle_BaseEnd()
        LoadPortSizes_BaseEnd()

        'TODO:Sandeep 26-02-10 2pm
        'TODO: ANUP 03-05-2010 10.45am 
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then
            '**********************
            chkRodEndPortSelection.Checked = False
            CheckBoxUnCheckFunctionaity()
            '3_3_2010 Aruna
            chkRodEndPortSelection.Enabled = False
        Else
            chkRodEndPortSelection.Checked = False
            CheckBoxUnCheckFunctionaity()
            '3_3_2010 Aruna
            chkRodEndPortSelection.Enabled = True
        End If
        '************************
    End Sub

    Private Sub DefaultSettings()
        _strTempDesignType = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType
        _strTempBaseEndConfiguration = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration
        _strTempBaseEndPort = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort
        _strTempPortInsertion = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion

        '1-03-10-Sandeep 10am
        ObjClsWeldedCylinderFunctionalClass.CmbPortSizeBaseEnd = cmbPortSizeBaseEnd

        ' ANUP 02-03-2010 04.55
        ObjClsWeldedCylinderFunctionalClass.CmbPortType_BaseEnd = cmbPortTypeBaseEnd
        ObjClsWeldedCylinderFunctionalClass.TxtFirstPortOrientation_BaseEnd = txtFirstPortOrientationBaseEnd
        ObjClsWeldedCylinderFunctionalClass.TxtSecondPortOrientation_BaseEnd = txtSecondPortOrientationBaseEnd
    End Sub

    Private Sub LoadNoOfPorts_BaseEnd()
        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis" _
        '      OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Threaded End" Then
        '3_3_2010 Aruna
        cmbNoofPortsBaseEnd.Items.Clear()

        'TODO: ANUP 22-07-2010 11.50am
        ''If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2.5 Then
        ''    cmbNoofPortsBaseEnd.Items.Add(1)
        ''Else
        ''    cmbNoofPortsBaseEnd.Items.Add(1)
        ''    cmbNoofPortsBaseEnd.Items.Add(2)
        ''End If
        cmbNoofPortsBaseEnd.Items.Add(1)
        If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Retraction" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Bothends") Then         '21_12_2010   RAGAVA
            cmbNoofPortsBaseEnd.Items.Add(2)
        End If
        cmbNoofPortsBaseEnd.SelectedIndex = 0
        cmbNoofPortsBaseEnd.Enabled = True

        'Else
        'cmbNoofPortsBaseEnd.Items.Add(1)
        'cmbNoofPortsBaseEnd.SelectedIndex = 0
        'cmbNoofPortsBaseEnd.Enabled = False
        'cmbNoofPortsBaseEnd.BackColor = Color.Empty
        'End If
    End Sub

    Private Sub LoadPortType_BaseEnd()
        cmbPortTypeBaseEnd.Items.Clear()
        'TODO:Sandeep 26-02-10 2pm
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
            cmbPortTypeBaseEnd.Items.Add("ORB")
            cmbPortTypeBaseEnd.Items.Add("NPTF")
            If cmbPortTypeBaseEnd.SelectedIndex = "1" Then
                cmbPortTypeBaseEnd.Text = "NPT"
            End If
        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then
            cmbPortTypeBaseEnd.Items.Add("ORB")
        End If
        cmbPortTypeBaseEnd.SelectedIndex = 0
        '************************
    End Sub

    Private Sub LoadPortAngle_BaseEnd()
        cmbPortAngleBaseEnd.Items.Clear()
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion = "Flushed" Then
            cmbPortAngleBaseEnd.Enabled = False
            cmbPortAngleBaseEnd.Items.Add("Straight")
            cmbPortAngleBaseEnd.SelectedIndex = 0
            cmbPortAngleBaseEnd.BackColor = Color.Empty
        Else
            cmbPortAngleBaseEnd.Enabled = True
            cmbPortAngleBaseEnd.Items.Add("Straight")
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked = False Then         '21_12_2010   RAGAVA
                cmbPortAngleBaseEnd.Items.Add("90")
            End If
            cmbPortAngleBaseEnd.SelectedIndex = 0
        End If
    End Sub

    Private Sub LoadPortSizes_BaseEnd()
        Try
            btnBrowsePort_BaseEnd.Visible = False
            cmbPortSizeBaseEnd.Items.Clear()
            'TODO:Sandeep 26-02-10 2pm

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then
                '25_06_2010   RAGAVA
                If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortSizes_BaseEnd("3/4")) Then
                    cmbPortSizeBaseEnd.Items.Add("3/4")
                End If
                If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortSizes_BaseEnd("9/16")) Then
                    cmbPortSizeBaseEnd.Items.Add("9/16")
                End If
                'Till   Here
            Else
                Dim oPortSizesDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortSizesfromDB(cmbPortTypeBaseEnd.Text)
                If Not IsNothing(oPortSizesDataTable) Then
                    For Each oPortSizeDataRow As DataRow In oPortSizesDataTable.Rows
                        '25_06_2010   RAGAVA
                        If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortSizes_BaseEnd(oPortSizeDataRow(0))) Then
                            cmbPortSizeBaseEnd.Items.Add(oPortSizeDataRow(0))
                        End If
                        'Till   Here
                    Next
                End If
            End If
            '07_12_2011   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked = True Then
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbRephasing.Text = "Rephasing at Retraction" OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbRephasing.Text.IndexOf("Bothends") <> -1 Then
                    cmbPortSizeBaseEnd.Items.Clear()
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 2 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 5 Then
                        cmbPortSizeBaseEnd.Items.Add("3/4")
                    End If
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2.5 Then
                        cmbPortSizeBaseEnd.Items.Add("9/16")
                    End If
                End If
            End If
            'TILL   HERE
            '************************
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in LoadPortSizes_BaseEnd of frmTubeDetails " + ex.Message)
        End Try
    End Sub

    'ANUP 12-08-2010 
    'Copy the entire procedure
    Private Sub LoadPortFacing_BaseEnd()
        cmbPortFacingBaseEnd.Items.Clear()

        If cmbPortAngleBaseEnd.Text = "90" Then
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then
                cmbPortFacingBaseEnd.Items.Add("In")
                cmbPortFacingBaseEnd.SelectedIndex = 0
                cmbPortFacingBaseEnd.Enabled = False
            Else
                cmbPortFacingBaseEnd.Enabled = True
                cmbPortFacingBaseEnd.Items.Add("In")
                cmbPortFacingBaseEnd.Items.Add("Out")
                cmbPortFacingBaseEnd.SelectedIndex = 0
                cmbPortFacingBaseEnd.Enabled = True
            End If
        Else
            cmbPortFacingBaseEnd.Enabled = False
            cmbPortFacingBaseEnd.BackColor = Color.Empty
        End If


        'If cmbPortAngleBaseEnd.Text = "90" Then
        '    cmbPortFacingBaseEnd.Enabled = True
        '    cmbPortFacingBaseEnd.Items.Add("In")
        '    cmbPortFacingBaseEnd.Items.Add("Out")
        '    cmbPortFacingBaseEnd.SelectedIndex = 0
        'Else
        '    cmbPortFacingBaseEnd.Enabled = False
        '    cmbPortFacingBaseEnd.BackColor = Color.Empty
        'End If
    End Sub

    Private Sub PortOrientationFunctionality_BaseEnd()
        txtFirstPortOrientationBaseEnd.Text = ""
        txtFirstPortOrientationBaseEnd.Enabled = False
        txtFirstPortOrientationBaseEnd.BackColor = Color.Empty

        txtSecondPortOrientationBaseEnd.Text = ""
        txtSecondPortOrientationBaseEnd.Enabled = False
        txtSecondPortOrientationBaseEnd.BackColor = Color.Empty

        If cmbNoofPortsBaseEnd.Text = 2 Then
            txtFirstPortOrientationBaseEnd.Enabled = True
            txtSecondPortOrientationBaseEnd.Enabled = True
        ElseIf cmbNoofPortsBaseEnd.Text = 1 Then
            txtFirstPortOrientationBaseEnd.Enabled = True
        End If
    End Sub

    Private Sub GetPortCode_BaseEnd()
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD <> 0 AndAlso cmbPortAngleBaseEnd.Text <> "" _
            AndAlso cmbPortTypeBaseEnd.Text <> "" AndAlso cmbPortSizeBaseEnd.Text <> "" Then
                Dim oPortCodeDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                GetPortCode(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD, cmbPortAngleBaseEnd.Text, _
                cmbPortTypeBaseEnd.Text, cmbPortSizeBaseEnd.Text)

                '08_12_2011   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked = True Then
                    If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbRephasing.Text = "Rephasing at Retraction" OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbRephasing.Text.IndexOf("Bothends") <> -1 Then
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter < 2 Then
                            _strBaseEndPortCode = "259151"
                            _strBaseEndPortCode_Purchase = "259151"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 2 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2.5 AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.SelectedItem) = "9/16" Then
                            _strBaseEndPortCode = "258276"
                            _strBaseEndPortCode_Purchase = "258276"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 2 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2.75 AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.SelectedItem) = "3/4" Then
                            _strBaseEndPortCode = "259161"
                            _strBaseEndPortCode_Purchase = "259161"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 3 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 5 Then
                            _strBaseEndPortCode = "258265"
                            _strBaseEndPortCode_Purchase = "258265"
                        End If
                        Exit Sub
                    End If
                End If
                'TILL  HERE


                If Not IsNothing(oPortCodeDataTable) Then
                    Dim oPortCodeDataRow As DataRow = oPortCodeDataTable.Rows(0)

                    'ANUP 06-10-2010 START 
                    '    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("BaseEnd Port Code", oPortCodeDataRow("PortCode"))
                    Dim strPartCode As String = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(oPortCodeDataRow("PortCode"))
                    If Not String.IsNullOrEmpty(strPartCode) Then
                        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("BaseEnd Port Code", strPartCode)
                        _strBaseEndPortCode_Purchase = strPartCode
                    Else
                        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("BaseEnd Port Code", oPortCodeDataRow("PortCode"))
                        _strBaseEndPortCode_Purchase = oPortCodeDataRow("PortCode")
                    End If
                    'ANUP 06-10-2010 TILL HERE

                    _strBaseEndPortCode = oPortCodeDataRow("PortCode")
                    btnBrowsePort_BaseEnd.Visible = False
                    _strBaseEndPortBase = oPortCodeDataRow("PORT_BASE")

                    '23_09_2010   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.Skived_Honed_Tube = "Skived" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WPDS_PortCode_Tube = oPortCodeDataRow("WPDS_Skived")
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.Skived_Honed_Tube = "Honed" Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WPDS_PortCode_Tube = oPortCodeDataRow("WPDS_Honed")
                    End If
                    'Till   Here
                Else
                    'TODO:Raghavendra 23-04-10
                    'TODO:Sandeep 26-02-10 2pm
                    'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
                        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("BaseEnd Port Code", "")
                        _strBaseEndPortCode = ""
                        'ANUP 20-09-2010 START
                        cmbOrificeSizeBaseEnd.Enabled = False
                        'ANUP 20-09-2010 TILL HERE 
                        btnBrowsePort_BaseEnd.Visible = True
                        _strBaseEndPortBase = ""
                        MessageBox.Show("PortCode not available for seleted PortDetalils, Kindly change selection", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                    Else
                        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("BaseEnd Port Code", "")
                        _strBaseEndPortCode = ""
                        btnBrowsePort_BaseEnd.Visible = False
                        _strBaseEndPortBase = ""
                    End If
                    '************************
                End If
            Else
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("BaseEnd Port Code", "")
                _strBaseEndPortCode = ""
                btnBrowsePort_BaseEnd.Visible = False
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in GetPortCode_BaseEnd of frmTubeDetails " + ex.Message)
        End Try
    End Sub

    Private Sub GetPortLocatorCode_BaseEnds()
        Try
            If cmbOrificeSizeBaseEnd.Text <> "" AndAlso cmbPortTypeBaseEnd.Text <> "" AndAlso cmbPortSizeBaseEnd.Text <> "" Then
                Dim oPortLocatorCodeDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
                GetPortLocatorCode(cmbOrificeSizeBaseEnd.Text, cmbPortSizeBaseEnd.Text, cmbPortTypeBaseEnd.Text)
                If Not IsNothing(oPortLocatorCodeDataTable) Then
                    Dim oPortLocatorCodeDataRow As DataRow = oPortLocatorCodeDataTable.Rows(0)

                    'ANUP 06-10-2010 START 
                    '         ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("BaseEnd PortLocator Code", oPortLocatorCodeDataRow("PortLocatorCode"))
                    Dim strPartCode As String = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(oPortLocatorCodeDataRow("PortLocatorCode"))
                    If Not String.IsNullOrEmpty(strPartCode) Then
                        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("BaseEnd PortLocator Code", strPartCode)
                        _strBaseEndPortLocatorCode_Purchase = strPartCode
                    Else
                        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("BaseEnd PortLocator Code", oPortLocatorCodeDataRow("PortLocatorCode"))
                        _strBaseEndPortLocatorCode_Purchase = oPortLocatorCodeDataRow("PortLocatorCode")
                    End If
                    'ANUP 06-10-2010 TILL HERE

                    _strBaseEndPortLocatorCode = oPortLocatorCodeDataRow("PortLocatorCode")
                Else
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("BaseEnd PortLocator Code", "")
                    _strBaseEndPortLocatorCode = ""
                End If
            Else
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("BaseEnd PortLocator Code", "")
                _strBaseEndPortLocatorCode = ""
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortLocatorCode_Tube = _strBaseEndPortLocatorCode      '23_09_2010    RAGAVA
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in GetPortLocatorCode_BaseEnds of frmTubeDetails " + ex.Message)
        End Try
    End Sub

    'TODO: 26-02-10 Sandeep 12pm
    Private Sub GetOrificeSizeFunctionaity(ByVal cmbOrificeSize As ComboBox, ByVal strPortAngle As String)
        Try
            cmbOrificeSize.Items.Clear()

            If cmbOrificeSize.Name = "cmbOrificeSizeBaseEnd" Then
                If cmbPortTypeBaseEnd.Text <> "" AndAlso cmbPortSizeBaseEnd.Text <> "" Then
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional" _
                                                AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
                        'AndAlso strPortAngle = "Straight" Then
                        cmbOrificeSize.Enabled = True
                        Dim oOrificeSizesDataTable As DataTable = Nothing
                        If cmbPortAngleBaseEnd.Text = "90" Then
                            oOrificeSizesDataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetOrificesSizes_90Deg(cmbPortTypeBaseEnd.Text, cmbPortSizeBaseEnd.Text, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD) '4_3_2010 Aruna 
                        Else
                            oOrificeSizesDataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetOrificesSizes(cmbPortTypeBaseEnd.Text, cmbPortSizeBaseEnd.Text) '4_3_2010 Aruna 
                        End If
                        If Not IsNothing(oOrificeSizesDataTable) Then
                            For Each oOrificeRow As Object In oOrificeSizesDataTable.Rows
                                cmbOrificeSize.Items.Add(oOrificeRow(0))
                            Next
                            '5_3_2010 Aruna
                            Dim OrficeSizeDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.SetOrificesSizesDefault(cmbPortTypeBaseEnd.Text, cmbPortSizeBaseEnd.Text)
                            If Not OrficeSizeDataRow Is Nothing Then
                                cmbOrificeSize.Text = OrficeSizeDataRow("OrificeSize")
                            Else
                                cmbOrificeSize.SelectedIndex = 0
                            End If
                        End If

                    Else
                        cmbOrificeSize.Enabled = False
                        cmbOrificeSize.BackColor = Color.Empty
                    End If
                End If
            Else : cmbOrificeSize.Name = "cmbOrificeSizeRodEnd"
                If cmbPortTypeRodEnd.Text <> "" AndAlso cmbPortSizeRodEnd.Text <> "" Then
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "Conventional" Then        '27_04_2010  RAGAVA  "New" Condition Added
                        'AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port In Tube" Then
                        'AndAlso strPortAngle = "Straight" Then
                        cmbOrificeSize.Enabled = True
                        Dim oOrificeSizesDataTable As DataTable = Nothing
                        If cmbPortAngleRodEnd.Text = "90" Then
                            oOrificeSizesDataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetOrificesSizes_90Deg(cmbPortTypeRodEnd.Text, cmbPortSizeRodEnd.Text, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD) '4_3_2010 Aruna 
                        Else
                            oOrificeSizesDataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetOrificesSizes(cmbPortTypeRodEnd.Text, cmbPortSizeRodEnd.Text) '4_3_2010 Aruna 
                        End If
                        If Not IsNothing(oOrificeSizesDataTable) Then
                            For Each oOrificeRow As Object In oOrificeSizesDataTable.Rows
                                cmbOrificeSize.Items.Add(oOrificeRow(0))
                            Next
                            '5_3_2010 Aruna
                            Dim OrficeSizeDataRow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.SetOrificesSizesDefault(cmbPortTypeRodEnd.Text, cmbPortSizeRodEnd.Text)
                            If Not OrficeSizeDataRow Is Nothing Then
                                cmbOrificeSize.Text = OrficeSizeDataRow("OrificeSize")
                            Else
                                cmbOrificeSize.SelectedIndex = 0
                            End If
                            For Each oItems As Object In cmbOrificeSizeRodEnd.Items
                                If Not IsNothing(cmbOrificeSizeBaseEnd.SelectedItem) Then
                                    If cmbOrificeSizeBaseEnd.SelectedItem.Equals(oItems) Then
                                        cmbOrificeSizeRodEnd.Text = oItems
                                        Exit For
                                    End If
                                End If
                            Next
                        End If
                    Else
                        cmbOrificeSize.Enabled = False
                        cmbOrificeSize.BackColor = Color.Empty
                    End If
                End If
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in GetOrificeSizeFunctionaity of frmTubeDetails " + ex.Message)
        End Try
        '************************
    End Sub

    Private Sub CheckBoxCheckedFunctionality()
        If chkRodEndPortSelection.Checked Then
            cmbNoofPortsRodEnd.Items.Clear()
            cmbNoofPortsRodEnd.Items.Add(cmbNoofPortsBaseEnd.Text)
            cmbNoofPortsRodEnd.SelectedIndex = 0
            cmbNoofPortsRodEnd.Enabled = False
            cmbNoofPortsRodEnd.BackColor = Color.Empty

            cmbPortTypeRodEnd.Items.Clear()
            cmbPortTypeRodEnd.Items.Add(cmbPortTypeBaseEnd.Text)
            ' cmbPortTypeRodEnd.SelectedIndex = 0



            cmbPortTypeRodEnd.Enabled = False
            cmbPortTypeRodEnd.BackColor = Color.Empty
            cmbPortTypeRodEnd.IFLDataTag = cmbPortTypeRodEnd.Text '05_04_2010 Aruna

            cmbPortAngleRodEnd.Items.Clear()
            cmbPortAngleRodEnd.Items.Add(cmbPortAngleBaseEnd.Text)
            cmbPortAngleRodEnd.SelectedIndex = 0
            cmbPortAngleRodEnd.Enabled = False
            cmbPortAngleRodEnd.BackColor = Color.Empty
            cmbPortAngleRodEnd.IFLDataTag = cmbPortAngleRodEnd.Text '05_04_2010 Aruna

            cmbPortFacingRodEnd.Items.Clear()
            cmbPortFacingRodEnd.Items.Add(cmbPortFacingBaseEnd.Text)
            cmbPortFacingRodEnd.SelectedIndex = 0
            cmbPortFacingRodEnd.Enabled = False
            cmbPortFacingRodEnd.BackColor = Color.Empty
            cmbPortFacingRodEnd.IFLDataTag = cmbPortFacingRodEnd.Text '05_04_2010 Aruna

            txtFirstPortOrientationRodEnd.Text = txtFirstPortOrientationBaseEnd.Text
            txtFirstPortOrientationRodEnd.Enabled = False
            txtFirstPortOrientationRodEnd.BackColor = Color.Empty

            txtSecondPortOrientationRodEnd.Text = txtSecondPortOrientationBaseEnd.Text
            txtSecondPortOrientationRodEnd.Enabled = False
            txtSecondPortOrientationRodEnd.BackColor = Color.Empty

            cmbOrificeSizeRodEnd.Items.Clear()
            cmbOrificeSizeRodEnd.Items.Add(cmbOrificeSizeBaseEnd.Text)
            cmbOrificeSizeRodEnd.Enabled = False
            cmbOrificeSizeRodEnd.SelectedIndex = 0
            cmbOrificeSizeRodEnd.BackColor = Color.Empty

            cmbPortSizeRodEnd.Items.Clear()
            cmbPortSizeRodEnd.Items.Add(cmbPortSizeBaseEnd.Text)
            ' cmbPortSizeRodEnd.SelectedIndex = 0



            ' If Not _blnCheckBocCheckedFunctionality_SelectedIndex Then
            cmbPortTypeRodEnd.SelectedIndex = 0
            cmbPortSizeRodEnd.SelectedIndex = 0
            'ONSITE: PORT DETAILS - disabled the orificesize control of rod end
            cmbOrificeSizeRodEnd.Enabled = False
            'End If

            cmbPortSizeRodEnd.Enabled = False
            cmbPortSizeRodEnd.BackColor = Color.Empty
            cmbPortSizeRodEnd.IFLDataTag = cmbPortSizeRodEnd.Text '05_04_2010 Aruna
            btnBrowsePort_RodEnd.Visible = btnBrowsePort_BaseEnd.Visible

            _strRodEndPortCode = _strBaseEndPortCode
            _strRodEndPortLocatorCode = _strBaseEndPortLocatorCode

            'ANUP 06-10-2010 START 
            '  ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd Port Code", _strRodEndPortCode)
            Dim strPartCode As String = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(_strRodEndPortCode)
            If Not String.IsNullOrEmpty(strPartCode) Then
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd Port Code", strPartCode)
                _strRodEndPortCode_Purchase = strPartCode
            Else
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd Port Code", _strRodEndPortCode)
                _strRodEndPortCode_Purchase = _strRodEndPortCode
            End If

            If cmbPortAngleRodEnd.Text = "Straight" Then
                'ANUP 06-10-2010 START
                ' ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd PortLocator Code", _strRodEndPortLocatorCode)
                RodEndPortLoocatorCode_Purchase_Validation()
                'ANUP 06-10-2010 TILL HERE
            Else
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd PortLocator Code", "")
            End If
            'ANUP 06-10-2010 TILL HERE

            _strRodEndPortBase = _strBaseEndPortBase

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_RodEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_BaseEnd

            ' Sandeep 24-02-10-5:30pm
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_RodEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd

            'A0308: ANUP 03-08-2010 02.28pm
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd

            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortLocatorCode_Tube = _strBaseEndPortLocatorCode    '23_09_2010  RAGAVA
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortLocatorCode_Rod = _strRodEndPortLocatorCode      '23_09_2010  RAGAVA
        End If
    End Sub

    Private Sub CheckBoxUnCheckFunctionaity()
        LoadFunctionality_RodEnd()

        ' ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd Port Code", "")
        'ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd PortLocator Code", "")
    End Sub

    Private Sub AssignValuesToExcelvariables()
        Try
            _dblPortOD_Weld = 0
            _strDustPlug = ""
            _strPermamentPlug = ""
            Dim oPort_WPDSDetailsDatarow As DataRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
            GetPort_WPDSDetails(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD, _
            cmbPortAngleBaseEnd.Text, cmbPortTypeBaseEnd.Text, cmbPortSizeBaseEnd.Text)
            If Not IsNothing(oPort_WPDSDetailsDatarow) Then
                If Not IsDBNull(oPort_WPDSDetailsDatarow("ODatWeld")) Then
                    _dblPortOD_Weld = oPort_WPDSDetailsDatarow("ODatWeld")
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortOD = _dblPortOD_Weld       '23_09_2010   RAGAVA
                End If

                If Not IsDBNull(oPort_WPDSDetailsDatarow("DustPlug")) Then
                    _strDustPlug = oPort_WPDSDetailsDatarow("DustPlug")
                End If

                If Not IsDBNull(oPort_WPDSDetailsDatarow("ORB_AND_NPTF_PermanentPlugs")) Then
                    _strPermamentPlug = oPort_WPDSDetailsDatarow("ORB_AND_NPTF_PermanentPlugs")
                End If
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in AssignValuesToExcelvariables of frmTubeDetails " + ex.Message)
        End Try
    End Sub

    Private Sub LoadFunctionality_RodEnd()
        LoadNoOfPorts_RodEnd()
        LoadPortType_RodEnd()
        LoadPortAngle_RodEnd()
        LoadPortSizes_RodEnd()
        txtFirstPortOrientationRodEnd.Text = txtFirstPortOrientationBaseEnd.Text
        txtSecondPortOrientationRodEnd.Text = txtSecondPortOrientationBaseEnd.Text
    End Sub

    Private Sub LoadNoOfPorts_RodEnd()
        cmbNoofPortsRodEnd.Items.Clear()


        'TODO: ANUP 22-07-2010 11.52am
        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
        '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2.5 Then
        '        cmbNoofPortsRodEnd.Items.Add(1)
        '    Else
        '        cmbNoofPortsRodEnd.Items.Add(1)
        '        cmbNoofPortsRodEnd.Items.Add(2)
        '    End If
        'Else
        '    cmbNoofPortsRodEnd.Items.Add(1)
        '    cmbNoofPortsRodEnd.Items.Add(2)
        'End If
        '****************

        cmbNoofPortsRodEnd.Items.Add(1)
        If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Extension" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Bothends") Then         '21_12_2010   RAGAVA
            cmbNoofPortsRodEnd.Items.Add(2)
        End If
        cmbNoofPortsRodEnd.SelectedIndex = 0
        cmbNoofPortsRodEnd.Enabled = True
        For Each oItems As Object In cmbNoofPortsRodEnd.Items
            If Not IsNothing(cmbNoofPortsBaseEnd.SelectedItem) Then
                If cmbNoofPortsBaseEnd.SelectedItem.Equals(oItems) Then
                    cmbNoofPortsRodEnd.Text = oItems
                    Exit For
                End If
            End If
        Next
    End Sub

    Private Sub LoadPortType_RodEnd()
        cmbPortTypeRodEnd.Enabled = True
        cmbPortTypeRodEnd.Items.Clear()

        'TODO:  ANUP 24-05-2010 04.00pm
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
            cmbPortTypeRodEnd.Items.Add("ORB")
        Else
            cmbPortTypeRodEnd.Items.Add("ORB")
            cmbPortTypeRodEnd.Items.Add("NPTF")
        End If
        '*****************

        cmbPortTypeRodEnd.SelectedIndex = 0
        For Each oItems As Object In cmbPortTypeRodEnd.Items
            If Not IsNothing(cmbPortTypeBaseEnd.SelectedItem) Then
                If cmbPortTypeBaseEnd.SelectedItem.Equals(oItems) Then
                    cmbPortTypeRodEnd.Text = oItems
                    Exit For
                End If
            End If
        Next
    End Sub

    Private Sub LoadPortAngle_RodEnd()
        cmbPortAngleRodEnd.Items.Clear()
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion = "Flushed" Then
            cmbPortAngleRodEnd.Enabled = True
            cmbPortAngleRodEnd.Items.Add("Straight")
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked = False Then         '21_12_2010   RAGAVA
                cmbPortAngleRodEnd.Items.Add("90")
            End If
            cmbPortAngleRodEnd.SelectedIndex = 0
            cmbPortAngleRodEnd.BackColor = Color.Empty
        Else
            cmbPortAngleRodEnd.Enabled = True
            cmbPortAngleRodEnd.Items.Add("Straight")
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked = False Then         '21_12_2010   RAGAVA
                cmbPortAngleRodEnd.Items.Add("90")
            End If
            'cmbPortAngleRodEnd.SelectedIndex = 1
            For Each oItems As Object In cmbPortAngleRodEnd.Items
                If Not IsNothing(cmbPortAngleBaseEnd.SelectedItem) Then
                    If cmbPortAngleBaseEnd.SelectedItem.Equals(oItems) Then
                        cmbPortAngleRodEnd.Text = oItems
                        Exit For
                    End If
                End If
            Next
            'ONSITE:PORT DETAILS - if rodend portangle is empty, then we are keeping the default value
            If cmbPortAngleRodEnd.Text = "" Then
                cmbPortAngleRodEnd.SelectedIndex = 1
            End If
        End If
    End Sub

    Private Sub LoadPortSizes_RodEnd()
        Try
            btnBrowsePort_RodEnd.Visible = False
            cmbPortSizeRodEnd.Enabled = True
            cmbPortSizeRodEnd.Items.Clear()

            'TODO:  ANUP 24-05-2010 04.00pm
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
                '25_06_2010   RAGAVA
                If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortSizes_RodEnd("3/4")) Then
                    cmbPortSizeRodEnd.Items.Add("3/4")
                End If
                If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortSizes_RodEnd("9/16")) Then
                    cmbPortSizeRodEnd.Items.Add("9/16")
                End If
                'Till  Here
            Else
                Dim oPortSizesDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortSizesfromDB(cmbPortTypeRodEnd.Text)
                If Not IsNothing(oPortSizesDataTable) Then
                    For Each oPortSizeDataRow As DataRow In oPortSizesDataTable.Rows
                        '25_06_2010   RAGAVA
                        If Not (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortSizes_RodEnd(oPortSizeDataRow(0))) Then
                            cmbPortSizeRodEnd.Items.Add(oPortSizeDataRow(0))
                        End If
                        'Till   Here
                    Next
                End If
            End If
            '*****************

            For Each oItems As Object In cmbPortSizeRodEnd.Items
                If Not IsNothing(cmbPortSizeBaseEnd.SelectedItem) Then
                    If cmbPortSizeBaseEnd.SelectedItem.Equals(oItems) Then
                        cmbPortSizeRodEnd.Text = oItems
                        Exit For
                    End If
                End If
            Next
            '07_12_2011   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked = True Then
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbRephasing.Text = "Rephasing at Extension" OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbRephasing.Text.IndexOf("Bothends") <> -1 Then
                    cmbPortSizeRodEnd.Items.Clear()
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 2 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 5 Then
                        cmbPortSizeRodEnd.Items.Add("3/4")
                    End If
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2.5 Then
                        cmbPortSizeRodEnd.Items.Add("9/16")
                    End If
                End If
            End If
            'TILL   HERE
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in LoadPortSizes_RodEnd of frmTubeDetails " + ex.Message)
        End Try
    End Sub

    'ANUP 12-08-2010 
    'Copy the entire procedure
    Private Sub LoadPortFacing_RodEnd()
        cmbPortFacingRodEnd.Items.Clear()
        If cmbPortAngleRodEnd.Text = "90" Then
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndPort = "Port Integral" Then
                cmbPortFacingRodEnd.Items.Add("In")
                cmbPortFacingRodEnd.SelectedIndex = 0
                cmbPortFacingRodEnd.Enabled = False
            Else
                cmbPortFacingRodEnd.Enabled = True
                cmbPortFacingRodEnd.Items.Add("In")
                cmbPortFacingRodEnd.Items.Add("Out")
                cmbPortFacingRodEnd.SelectedIndex = 0
                For Each oItems As Object In cmbPortFacingRodEnd.Items
                    If Not IsNothing(cmbPortFacingBaseEnd.SelectedItem) Then
                        If cmbPortFacingBaseEnd.SelectedItem.Equals(oItems) Then
                            cmbPortFacingRodEnd.Text = oItems
                            Exit For
                        End If
                    End If
                Next
            End If
        Else
            cmbPortFacingRodEnd.Enabled = False
            cmbPortFacingRodEnd.BackColor = Color.Empty
        End If
    End Sub
    Private Sub PortOrientationFunctionality_RodEnd()
        txtFirstPortOrientationRodEnd.Text = ""
        txtFirstPortOrientationRodEnd.Enabled = False
        txtFirstPortOrientationRodEnd.BackColor = Color.Empty

        txtSecondPortOrientationRodEnd.Enabled = False
        txtSecondPortOrientationRodEnd.Text = ""
        txtSecondPortOrientationRodEnd.BackColor = Color.Empty

        If cmbNoofPortsRodEnd.Text = 2 Then
            txtFirstPortOrientationRodEnd.Enabled = True
            txtSecondPortOrientationRodEnd.Enabled = True
        ElseIf cmbNoofPortsRodEnd.Text = 1 Then
            txtFirstPortOrientationRodEnd.Enabled = True
        End If
    End Sub

    Private Sub GetPortCode_RodEnd()
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD <> 0 AndAlso cmbPortAngleRodEnd.Text <> "" _
            AndAlso cmbPortTypeRodEnd.Text <> "" AndAlso cmbPortSizeRodEnd.Text <> "" Then


                '08_12_2011   RAGAVA
                'If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked = True Then
                '    If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbRephasing.Text = "Rephasing at Extension" OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbRephasing.Text.IndexOf("Bothends") <> -1 Then
                '        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter < 2 Then
                '            _strRodEndPortCode = "259151"
                '            _strRodEndPortCode_Purchase = "259151"
                '            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 2 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2.5 Then
                '        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 2 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2.5 AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.SelectedItem) = "9/16" Then
                '            _strRodEndPortCode = "258276"
                '            _strRodEndPortCode_Purchase = "258276"
                '            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 2 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2.75 Then
                '        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 2 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2.75 AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.SelectedItem) = "3/4" Then
                '            _strRodEndPortCode = "259161"
                '            _strRodEndPortCode_Purchase = "259161"
                '        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 3 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 5 Then
                '            _strRodEndPortCode = "258265"
                '            _strRodEndPortCode_Purchase = "258265"
                '        End If
                '    End If
                '    Exit Sub
                'End If
                '28_08_2012   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked = True Then
                    If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbRephasing.Text = "Rephasing at Extension" OrElse ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.cmbRephasing.Text.IndexOf("Bothends") <> -1 Then
                        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter < 2 Then
                            _strRodEndPortCode = "259151"
                            _strRodEndPortCode_Purchase = "259151"
                            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 2 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2.5 Then
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 2 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2.5 AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.SelectedItem) = "9/16" Then        '28_08_2012   RAGAVA
                            _strRodEndPortCode = "258276"
                            _strRodEndPortCode_Purchase = "258276"
                            'ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 2 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2.75 Then
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 2 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 2.75 AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.SelectedItem) = "3/4" Then
                            _strRodEndPortCode = "259161"
                            _strRodEndPortCode_Purchase = "259161"
                        ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter >= 3 AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter <= 5 Then
                            _strRodEndPortCode = "258265"
                            _strRodEndPortCode_Purchase = "258265"
                        End If
                        Exit Sub
                    End If
                End If
                'TILL  HERE


                Dim oPortCodeDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortCode(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeOD, _
                            cmbPortAngleRodEnd.Text, cmbPortTypeRodEnd.Text, cmbPortSizeRodEnd.Text)
                If Not IsNothing(oPortCodeDataTable) Then
                    Dim oPortCodeDataRow As DataRow = oPortCodeDataTable.Rows(0)

                    'ANUP 06-10-2010 START 
                    '    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd Port Code", oPortCodeDataRow("PortCode"))
                    Dim strPartCode As String = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(oPortCodeDataRow("PortCode"))
                    If Not String.IsNullOrEmpty(strPartCode) Then
                        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd Port Code", strPartCode)
                        _strRodEndPortCode_Purchase = strPartCode
                    Else
                        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd Port Code", oPortCodeDataRow("PortCode"))
                        _strRodEndPortCode_Purchase = oPortCodeDataRow("PortCode")
                    End If
                    'ANUP 06-10-2010 TILL HERE

                    _strRodEndPortCode = oPortCodeDataRow("PortCode")
                    btnBrowsePort_RodEnd.Visible = False
                    _strRodEndPortBase = oPortCodeDataRow("PORT_BASE")
                Else
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd Port Code", "")
                    _strRodEndPortCode = ""
                    btnBrowsePort_RodEnd.Visible = True
                    _strRodEndPortBase = ""
                    MessageBox.Show("Ports at RodEnd are not available for seleted PortType, PortAngle and PortSize", "Information", _
                   MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                    'ANUP 20-09-2010 START
                    cmbOrificeSizeRodEnd.Enabled = False
                    'ANUP 20-09-2010 TILL HERE 
                End If
            Else
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd Port Code", "")
                btnBrowsePort_RodEnd.Visible = False
                _strRodEndPortCode = ""
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in GetPortCode_RodEnd of frmTubeDetails " + ex.Message)
        End Try
    End Sub

    Private Sub GetPortLocatorCode_RodEnd()
        Try
            If cmbOrificeSizeRodEnd.Text <> "" AndAlso cmbPortTypeRodEnd.Text <> "" AndAlso cmbPortSizeRodEnd.Text <> "" Then
                Dim oPortLocatorCodeDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortLocatorCode(cmbOrificeSizeRodEnd.Text, cmbPortSizeRodEnd.Text, cmbPortTypeRodEnd.Text)
                If Not IsNothing(oPortLocatorCodeDataTable) Then
                    Dim oPortLocatorCodeDataRow As DataRow = oPortLocatorCodeDataTable.Rows(0)
                    '  ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd PortLocator Code", oPortLocatorCodeDataRow("PortLocatorCode"))
                    _strRodEndPortLocatorCode = oPortLocatorCodeDataRow("PortLocatorCode")
                Else
                    'ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd PortLocator Code", "")
                    _strRodEndPortLocatorCode = ""
                End If
            Else
                ' ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd PortLocator Code", "")
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortLocatorCode_Rod = _strRodEndPortLocatorCode       '23_09_2010   RAGAVA
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in GetPortLocatorCode_RodEnd of frmTubeDetails " + ex.Message)
        End Try
    End Sub

#End Region

#Region "Events"

    Private Sub frmPortDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        LoadFunctionality_BaseEnd()
        DefaultSettings()
        ObjClsWeldedCylinderFunctionalClass.AddColors(Me)
    End Sub

    Private Sub chkRodEndPortSelection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRodEndPortSelection.CheckedChanged
        cmbNoofPortsRodEnd.IFLDataTag = Nothing
        cmbPortTypeRodEnd.IFLDataTag = Nothing
        cmbPortAngleRodEnd.IFLDataTag = Nothing
        cmbPortFacingRodEnd.IFLDataTag = Nothing
        txtFirstPortOrientationRodEnd.IFLDataTag = Nothing
        txtSecondPortOrientationRodEnd.IFLDataTag = Nothing
        cmbOrificeSizeRodEnd.IFLDataTag = Nothing
        cmbPortSizeRodEnd.IFLDataTag = Nothing
        If chkRodEndPortSelection.Checked Then
            CheckBoxCheckedFunctionality()
        Else
            CheckBoxUnCheckFunctionaity()
        End If
    End Sub

    'Private Sub btnBrowsePort_BaseEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowsePort_BaseEnd.Click, btnBrowsePort_RodEnd.Click
    '    If Windows.Forms.DialogResult.OK = ofdPort.ShowDialog() Then
    '        ofdPort.OpenFile()
    '    End If
    'End Sub

    'A0308: ANUP 09-08-2010 02.15pm
    Private Sub btnBrowsePort_BaseEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowsePort_BaseEnd.Click, btnBrowsePort_RodEnd.Click
        'If Windows.Forms.DialogResult.OK = ofdPort.ShowDialog() Then 'uncommented if condition vamsi 24th may 2013
        '    ofdPort.OpenFile()
        'End If

        ObjClsWeldedCylinderFunctionalClass.IsImportPortsButtonClicked = True

        If sender.name = "btnBrowsePort_BaseEnd" Then
            ObjClsWeldedCylinderFunctionalClass.IsPort_BaseEndOrRodEnd = True
        ElseIf sender.name = "btnBrowsePort_RodEnd" Then
            ObjClsWeldedCylinderFunctionalClass.IsPort_BaseEndOrRodEnd = False
        End If

        ObjFrmImportPorts.ShowDialog()

    End Sub

    Private Sub cmbNoofPortsBaseEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNoofPortsBaseEnd.SelectedIndexChanged
        _blnCheckBocCheckedFunctionality_SelectedIndex = False
        If cmbNoofPortsBaseEnd.Text <> "" Then

            If cmbNoofPortsBaseEnd.Text <> cmbNoofPortsBaseEnd.IFLDataTag Then
                'If cmbPortTypeBaseEnd.Text = "NPTF" Then 'vamsi 08-05-2013
                '    cmbPortTypeBaseEnd.Text = "NPT"
                'End If
                cmbNoofPortsBaseEnd.IFLDataTag = cmbNoofPortsBaseEnd.Text
                ' ANUP 10-03-2010 02.05
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd = cmbNoofPortsBaseEnd.Text
                PortOrientationFunctionality_BaseEnd()
                If chkRodEndPortSelection.Checked Then
                    CheckBoxCheckedFunctionality()
                End If
            End If
        Else
            cmbNoofPortsBaseEnd.IFLDataTag = Nothing
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_BaseEnd = 0
            '***********************
        End If
    End Sub

    Private Sub cmbPortTypeBaseEnd_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPortTypeBaseEnd.SelectedIndexChanged
        _blnCheckBocCheckedFunctionality_SelectedIndex = False
        If cmbPortTypeBaseEnd.Text <> "" Then
            If cmbPortTypeBaseEnd.Text <> cmbPortTypeBaseEnd.IFLDataTag Then
                cmbPortTypeBaseEnd.IFLDataTag = cmbPortTypeBaseEnd.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd = cmbPortTypeBaseEnd.Text
                LoadPortSizes_BaseEnd()
                GetPortCode_BaseEnd()
                GetPortLocatorCode_BaseEnds()
                If chkRodEndPortSelection.Checked Then
                    CheckBoxCheckedFunctionality()
                End If
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortType_BaseEnd = ""
            cmbPortTypeBaseEnd.IFLDataTag = Nothing
        End If
    End Sub

    ''25_05_2010    RAGAVA
    'Public Sub GetBaseEndCodeNumber()
    '    Try
    '        If UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" AndAlso ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = "90" Then
    '            Dim oRow As DataRow = Nothing
    '            Dim _strQuery As String
    '            _strQuery = "Select * from PortIntegralRaisedPortDetails90 where NominalBoreDia = " & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness and portSize = " + IIf(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text = "3/4", 0.75, 0.5625).ToString
    '            oRow = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetButtonPlane(_strQuery)
    '            If Not IsNothing(oRow) Then
    '                If Not IsDBNull(oRow("CodeNumber")) Then
    '                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndCodeNumber90 = oRow("CodeNumber")
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub cmbPortAngleBaseEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPortAngleBaseEnd.SelectedIndexChanged
        _blnCheckBocCheckedFunctionality_SelectedIndex = False
        If cmbPortAngleBaseEnd.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.strPortAngle_BaseEnd = Trim(cmbPortAngleBaseEnd.Text)        '03_03_2010   RAGAVA
            If cmbPortAngleBaseEnd.Text <> cmbPortAngleBaseEnd.IFLDataTag Then
                cmbPortAngleBaseEnd.IFLDataTag = cmbPortAngleBaseEnd.Text
                LoadPortFacing_BaseEnd()
                GetOrificeSizeFunctionaity(cmbOrificeSizeBaseEnd, cmbPortAngleBaseEnd.Text)
                GetPortCode_BaseEnd()
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" AndAlso Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text) <> "" Then    '03_06_2010   RAGAVA
                    ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.GetBaseEndCodeNumber()          '25_05_2010   RAGAVA
                    '03_06_2010   RAGAVA
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndCodeNumber90 Is Nothing AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndCodeNumber Is Nothing Then
                        MsgBox("Code Number for this Plate Clevis is Not Found")
                    End If
                End If
                If chkRodEndPortSelection.Checked Then
                    CheckBoxCheckedFunctionality()
                End If
            End If
        Else
            cmbPortAngleBaseEnd.IFLDataTag = Nothing
        End If
        If cmbPortAngleBaseEnd.Text = "Straight" Then
            'ANUP 06-10-2010 START
            'ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("BaseEnd PortLocator Code", _strBaseEndPortLocatorCode)
            BaseEndPortLoocatorCode_Purchase_Validation(_strBaseEndPortLocatorCode)
            'ANUP 06-10-2010 TILL HERE
        Else
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("BaseEnd PortLocator Code", "")
        End If
    End Sub

    Private Sub cmbPortFacingBaseEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles cmbPortFacingBaseEnd.SelectedIndexChanged
        _blnCheckBocCheckedFunctionality_SelectedIndex = False
        If cmbPortFacingBaseEnd.Text <> "" Then
            If cmbPortFacingBaseEnd.Text <> cmbPortFacingBaseEnd.IFLDataTag Then
                cmbPortFacingBaseEnd.IFLDataTag = cmbPortFacingBaseEnd.Text
                If chkRodEndPortSelection.Checked Then
                    CheckBoxCheckedFunctionality()
                End If
            End If
        Else
            sender.IFLDataTag = Nothing
        End If
    End Sub

    Private Sub txtSecondPortOrientationBaseEnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtSecondPortOrientationBaseEnd.Leave, txtFirstPortOrientationBaseEnd.Leave


        If cmbNoofPortsBaseEnd.Text = 2 Then

            If txtSecondPortOrientationBaseEnd.Text <> "" AndAlso txtFirstPortOrientationBaseEnd.Text <> "" Then
                If sender.Text <> sender.IFLDataTag Then
                    sender.IFLDataTag = sender.Text
                    If Val(txtSecondPortOrientationBaseEnd.Text) = Val(txtFirstPortOrientationBaseEnd.Text) Then
                        MessageBox.Show("Difference between First and Second Port Orientation should be minimum 15", "Change Port Orientation value", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        txtFirstPortOrientationBaseEnd.Clear()
                        txtSecondPortOrientationBaseEnd.Clear()
                        txtFirstPortOrientationBaseEnd.Focus()
                        sender.IFLDataTag = Nothing
                    Else
                        If Val(txtSecondPortOrientationBaseEnd.Text) > Val(txtFirstPortOrientationBaseEnd.Text) Then
                            If Val(txtSecondPortOrientationBaseEnd.Text) > 180 AndAlso Val(txtFirstPortOrientationBaseEnd.Text) > 180 Then
                                If Val(txtSecondPortOrientationBaseEnd.Text) - Val(txtFirstPortOrientationBaseEnd.Text) < 15 Then
                                    MessageBox.Show("Difference between First and Second Port Orientation should be minimum 15", "Change Port Orientation value", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    txtFirstPortOrientationBaseEnd.Focus()
                                    sender.IFLDataTag = Nothing
                                End If
                            ElseIf Val(txtSecondPortOrientationBaseEnd.Text) > 180 Then
                                If ((360 - Val(txtSecondPortOrientationBaseEnd.Text)) + Val(txtFirstPortOrientationBaseEnd.Text)) < 15 Then
                                    MessageBox.Show("Difference between First and Second Port Orientation should be minimum 15", "Change Port Orientation value", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    txtFirstPortOrientationBaseEnd.Clear()
                                    txtSecondPortOrientationBaseEnd.Clear()
                                    txtFirstPortOrientationBaseEnd.Focus()
                                    sender.IFLDataTag = Nothing
                                End If

                            Else
                                If Val(txtSecondPortOrientationBaseEnd.Text) - Val(txtFirstPortOrientationBaseEnd.Text) < 15 Then
                                    MessageBox.Show("Difference between First and Second Port Orientation should be minimum 15", "Change Port Orientation value", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    txtFirstPortOrientationBaseEnd.Clear()
                                    txtSecondPortOrientationBaseEnd.Clear()
                                    txtFirstPortOrientationBaseEnd.Focus()
                                    sender.IFLDataTag = Nothing
                                End If

                                '    If Val(txtSecondPortOrientationBaseEnd.Text) - Val(txtFirstPortOrientationBaseEnd.Text) <> 15 Then
                                '        MessageBox.Show("First and Second Port Orientations difference should be 15", "Change Port Orientation value", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                '        sender.IFLDataTag = Nothing
                                '    End If
                                'Else
                                '    If Val(txtFirstPortOrientationBaseEnd.Text) - Val(txtSecondPortOrientationBaseEnd.Text) <> 15 Then
                                '        MessageBox.Show("First and Second Port Orientations difference should be 15", "Change Port Orientation value", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                '        sender.IFLDataTag = Nothing
                                '    End If
                            End If
                        Else
                            If Val(txtFirstPortOrientationBaseEnd.Text) > 180 AndAlso Val(txtSecondPortOrientationBaseEnd.Text) > 180 Then
                                If Val(txtFirstPortOrientationBaseEnd.Text) - Val(txtSecondPortOrientationBaseEnd.Text) < 15 Then
                                    MessageBox.Show("Difference between First and Second Port Orientation should be minimum 15", "Change Port Orientation value", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    txtFirstPortOrientationBaseEnd.Clear()
                                    txtSecondPortOrientationBaseEnd.Clear()
                                    txtFirstPortOrientationBaseEnd.Focus()
                                    sender.IFLDataTag = Nothing
                                End If
                            ElseIf Val(txtFirstPortOrientationBaseEnd.Text) > 180 Then
                                If ((360 - Val(txtFirstPortOrientationBaseEnd.Text)) + Val(txtSecondPortOrientationBaseEnd.Text)) < 15 Then
                                    MessageBox.Show("Difference between First and Second Port Orientation should be minimum 15", "Change Port Orientation value", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    txtFirstPortOrientationBaseEnd.Clear()
                                    txtSecondPortOrientationBaseEnd.Clear()
                                    txtFirstPortOrientationBaseEnd.Focus()
                                    sender.IFLDataTag = Nothing
                                End If
                            Else
                                If Val(txtFirstPortOrientationBaseEnd.Text) - Val(txtSecondPortOrientationBaseEnd.Text) < 15 Then
                                    MessageBox.Show("Difference between First and Second Port Orientation should be minimum 15", "Change Port Orientation value", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    txtFirstPortOrientationBaseEnd.Clear()
                                    txtSecondPortOrientationBaseEnd.Clear()
                                    txtFirstPortOrientationBaseEnd.Focus()
                                    sender.IFLDataTag = Nothing
                                End If
                            End If
                        End If

                    End If
                End If
                'A0308: ANUP 03-08-2010 02.28pm
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FirstPortOrientation_BaseEnd = txtFirstPortOrientationBaseEnd.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SecondPortOrientation_BaseEnd = txtSecondPortOrientationBaseEnd.Text
            Else
                sender.IFLDataTag = Nothing
            End If

        ElseIf cmbNoofPortsBaseEnd.Text = 1 Then  'MANJULA 13-02-12 CONDITION ADDED...
            If txtFirstPortOrientationBaseEnd.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FirstPortOrientation_BaseEnd = txtFirstPortOrientationBaseEnd.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SecondPortOrientation_BaseEnd = "0"
            End If

        End If


        If chkRodEndPortSelection.Checked Then
            CheckBoxCheckedFunctionality()
        End If
    End Sub

    Private Sub cmbOrificeSizeBaseEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOrificeSizeBaseEnd.SelectedIndexChanged
        _blnCheckBocCheckedFunctionality_SelectedIndex = True
        If cmbOrificeSizeBaseEnd.Text <> "" Then
            If cmbOrificeSizeBaseEnd.Text <> cmbOrificeSizeBaseEnd.IFLDataTag Then
                cmbOrificeSizeBaseEnd.IFLDataTag = cmbOrificeSizeBaseEnd.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_BaseEnd = cmbOrificeSizeBaseEnd.Text
                ' GetPortLocatorCode_BaseEnds() '02_04_2010 Aruna
                GetPortLocatorCode_BaseEnds()
                If chkRodEndPortSelection.Checked Then
                    CheckBoxCheckedFunctionality()
                End If
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_BaseEnd = 0
            cmbOrificeSizeBaseEnd.IFLDataTag = Nothing
        End If

        If cmbPortAngleBaseEnd.Text = "Straight" Then
            'ANUP 06-10-2010 START
            'ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("BaseEnd PortLocator Code", _strBaseEndPortLocatorCode)
            BaseEndPortLoocatorCode_Purchase_Validation(_strBaseEndPortLocatorCode)
            'ANUP 06-10-2010 TILL HERE
        End If
    End Sub

    Private Sub cmbPortSizeBaseEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPortSizeBaseEnd.SelectedIndexChanged
        _blnCheckBocCheckedFunctionality_SelectedIndex = False
        If cmbPortSizeBaseEnd.Text <> "" Then
            If cmbPortSizeBaseEnd.Text <> cmbPortSizeBaseEnd.IFLDataTag Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportBaseEndPortPartPath = ""   '16_08_2010   RAGAVA
                cmbPortSizeBaseEnd.IFLDataTag = cmbPortSizeBaseEnd.Text
                ' Sandeep 24-02-10-5:30pm
                Dim dblPortSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortSizeFromDB(cmbPortSizeBaseEnd.Text, cmbPortTypeBaseEnd.Text, cmbPortAngleBaseEnd.Text)
                If Not dblPortSize = 0 Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd = dblPortSize
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd = 0
                End If
                '****************
                GetPortCode_BaseEnd()
                GetPortLocatorCode_BaseEnds()
                If chkRodEndPortSelection.Checked Then
                    CheckBoxCheckedFunctionality()
                End If
                AssignValuesToExcelvariables()
            End If
        Else
            cmbPortSizeBaseEnd.IFLDataTag = Nothing
        End If
    End Sub

    Private Sub cmbNoofPortsRodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNoofPortsRodEnd.SelectedIndexChanged
        If Not chkRodEndPortSelection.Checked Then
            If cmbNoofPortsRodEnd.Text <> "" Then
                If cmbNoofPortsRodEnd.Text <> cmbNoofPortsRodEnd.IFLDataTag Then
                    cmbNoofPortsRodEnd.IFLDataTag = cmbNoofPortsRodEnd.Text
                    IsCallerAvailable()
                    PortOrientationFunctionality_RodEnd()
                    'A0308: ANUP 03-08-2010 02.28pm
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.NoOfPorts_RodEnd = cmbNoofPortsRodEnd.Text
                End If
            Else
                cmbNoofPortsRodEnd.IFLDataTag = Nothing
            End If
        End If
    End Sub

    Private Sub cmbPortTypeRodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPortTypeRodEnd.SelectedIndexChanged
        If Not chkRodEndPortSelection.Checked Then
            If cmbPortAngleRodEnd.Text <> "" AndAlso cmbPortTypeRodEnd.Text <> "" Then
                IsCallerAvailable()
                LoadPortSizes_RodEnd()
                If Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then           '02_07_2010   RAGAVA
                    GetPortCode_RodEnd()
                End If
                GetPortLocatorCode_RodEnd()
            End If
        End If
    End Sub

    Private Sub cmbPortAngleRodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPortAngleRodEnd.SelectedIndexChanged
        If Not chkRodEndPortSelection.Checked Then
            If cmbPortAngleRodEnd.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.strPortAngle_RodEnd = Trim(cmbPortAngleRodEnd.Text)       '27_09_2010   RAGAVA
                If cmbPortAngleRodEnd.Text <> cmbPortAngleRodEnd.IFLDataTag Then
                    IsCallerAvailable()
                    cmbPortAngleRodEnd.IFLDataTag = cmbPortAngleRodEnd.Text
                    LoadPortFacing_RodEnd()
                    If Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then           '02_07_2010   RAGAVA
                        GetPortCode_RodEnd()
                    End If
                    GetOrificeSizeFunctionaity(cmbOrificeSizeRodEnd, cmbPortAngleRodEnd.Text)
                End If
            Else
                cmbPortAngleRodEnd.IFLDataTag = Nothing
            End If
        End If
        If cmbPortAngleRodEnd.Text = "Straight" Then
            'ANUP 06-10-2010 START
            ' ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd PortLocator Code", _strRodEndPortLocatorCode)
            RodEndPortLoocatorCode_Purchase_Validation()
            'ANUP 06-10-2010 TILL HERE
        Else
            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd PortLocator Code", "")
        End If
    End Sub


    'TODO: ANUP 27-02-2010 12.35
    Private Sub txtSecondPortOrientationRodEnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtSecondPortOrientationRodEnd.Leave, txtFirstPortOrientationRodEnd.Leave
        If txtSecondPortOrientationRodEnd.Text <> "" AndAlso txtFirstPortOrientationRodEnd.Text <> "" Then
            If sender.Text <> sender.IFLDataTag Then
                sender.IFLDataTag = sender.Text
                If Val(txtSecondPortOrientationRodEnd.Text) = Val(txtFirstPortOrientationRodEnd.Text) Then
                    MessageBox.Show("Difference between First and Second Port Orientation should be minimum 15", "Change Port Orientation value", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtFirstPortOrientationRodEnd.Clear()
                    txtSecondPortOrientationRodEnd.Clear()
                    txtFirstPortOrientationRodEnd.Focus()
                    sender.IFLDataTag = Nothing
                Else
                    If Val(txtSecondPortOrientationRodEnd.Text) > Val(txtFirstPortOrientationRodEnd.Text) Then
                        If Val(txtSecondPortOrientationRodEnd.Text) > 180 AndAlso Val(txtFirstPortOrientationRodEnd.Text) > 180 Then
                            If Val(txtSecondPortOrientationRodEnd.Text) - Val(txtFirstPortOrientationRodEnd.Text) < 15 Then
                                MessageBox.Show("Difference between First and Second Port Orientation should be minimum 15", "Change Port Orientation value", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                txtFirstPortOrientationRodEnd.Focus()
                                sender.IFLDataTag = Nothing
                            End If
                        ElseIf Val(txtSecondPortOrientationRodEnd.Text) > 180 Then
                            If ((360 - Val(txtSecondPortOrientationRodEnd.Text)) + Val(txtFirstPortOrientationRodEnd.Text)) < 15 Then
                                MessageBox.Show("Difference between First and Second Port Orientation should be minimum 15", "Change Port Orientation value", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                txtFirstPortOrientationRodEnd.Clear()
                                txtSecondPortOrientationRodEnd.Clear()
                                txtFirstPortOrientationRodEnd.Focus()
                                sender.IFLDataTag = Nothing
                            End If

                        Else
                            If Val(txtSecondPortOrientationRodEnd.Text) - Val(txtFirstPortOrientationRodEnd.Text) < 15 Then
                                MessageBox.Show("Difference between First and Second Port Orientation should be minimum 15", "Change Port Orientation value", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                txtFirstPortOrientationRodEnd.Clear()
                                txtSecondPortOrientationRodEnd.Clear()
                                txtFirstPortOrientationRodEnd.Focus()
                                sender.IFLDataTag = Nothing
                            End If
                        End If
                    Else
                        If Val(txtFirstPortOrientationRodEnd.Text) > 180 AndAlso Val(txtSecondPortOrientationRodEnd.Text) > 180 Then
                            If Val(txtFirstPortOrientationRodEnd.Text) - Val(txtSecondPortOrientationRodEnd.Text) < 15 Then
                                MessageBox.Show("Difference between First and Second Port Orientation should be minimum 15", "Change Port Orientation value", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                txtFirstPortOrientationRodEnd.Clear()
                                txtSecondPortOrientationRodEnd.Clear()
                                txtFirstPortOrientationRodEnd.Focus()
                                sender.IFLDataTag = Nothing
                            End If
                        ElseIf Val(txtFirstPortOrientationBaseEnd.Text) > 180 Then
                            If ((360 - Val(txtFirstPortOrientationRodEnd.Text)) + Val(txtSecondPortOrientationRodEnd.Text)) < 15 Then
                                MessageBox.Show("Difference between First and Second Port Orientation should be minimum 15", "Change Port Orientation value", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                txtFirstPortOrientationRodEnd.Clear()
                                txtSecondPortOrientationRodEnd.Clear()
                                txtFirstPortOrientationRodEnd.Focus()
                                sender.IFLDataTag = Nothing
                            End If
                        Else
                            If Val(txtFirstPortOrientationRodEnd.Text) - Val(txtSecondPortOrientationRodEnd.Text) < 15 Then
                                MessageBox.Show("Difference between First and Second Port Orientation should be minimum 15", "Change Port Orientation value", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                txtFirstPortOrientationRodEnd.Clear()
                                txtSecondPortOrientationRodEnd.Clear()
                                txtFirstPortOrientationRodEnd.Focus()
                                sender.IFLDataTag = Nothing
                            End If
                        End If
                    End If

                End If
            End If
            'A0308: ANUP 03-08-2010 02.28pm
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FirstPortOrientation_RodEnd = txtFirstPortOrientationRodEnd.Text
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SecondPortOrientation_RodEnd = txtSecondPortOrientationRodEnd.Text
        Else
            sender.IFLDataTag = Nothing
        End If
        If chkRodEndPortSelection.Checked Then
            CheckBoxCheckedFunctionality()
        End If
        ObjClsWeldedCylinderFunctionalClass.FirstPortOrientation_RodEnd = Trim(txtFirstPortOrientationRodEnd.Text)           '23_06_2010   RAGAVA
    End Sub
    '------------------------------

    Private Sub cmbOrificeSizeRodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOrificeSizeRodEnd.SelectedIndexChanged
        If Not chkRodEndPortSelection.Checked Then
            If cmbOrificeSizeRodEnd.Text <> "" Then
                If cmbOrificeSizeRodEnd.Text <> cmbOrificeSizeRodEnd.IFLDataTag Then
                    cmbOrificeSizeRodEnd.IFLDataTag = cmbOrificeSizeRodEnd.Text
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_RodEnd = Val(cmbOrificeSizeRodEnd.Text)
                    GetPortLocatorCode_RodEnd() '02_04_2010 Aruna

                End If
            Else
                cmbOrificeSizeRodEnd.IFLDataTag = Nothing
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.OrificeSize_RodEnd = 0
            End If
        End If
        If cmbPortAngleRodEnd.Text = "Straight" Then
            'ANUP 06-10-2010 START
            ' ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd PortLocator Code", _strRodEndPortLocatorCode)
            RodEndPortLoocatorCode_Purchase_Validation()
            'ANUP 06-10-2010 TILL HERE
        End If
    End Sub

    Private Sub cmbPortSizeRodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPortSizeRodEnd.SelectedIndexChanged
        If Not chkRodEndPortSelection.Checked Then
            If cmbPortSizeRodEnd.Text <> "" Then
                If cmbPortSizeRodEnd.Text <> cmbPortSizeRodEnd.IFLDataTag Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ImportRodEndPortPartPath = ""   '16_08_2010   RAGAVA
                    cmbPortSizeRodEnd.IFLDataTag = cmbPortSizeRodEnd.Text
                    IsCallerAvailable()
                    ' Sandeep 24-02-10-5:30pm
                    Dim dblPortSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPortSizeFromDB(cmbPortSizeRodEnd.Text, cmbPortTypeRodEnd.Text, cmbPortAngleRodEnd.Text)
                    If Not dblPortSize = 0 Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_RodEnd = dblPortSize
                    Else
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_RodEnd = 0
                    End If
                    '***************
                    If Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then           '02_07_2010   RAGAVA
                        GetPortCode_RodEnd()
                    End If
                    GetPortLocatorCode_RodEnd()
                End If
            Else
                cmbPortSizeRodEnd.IFLDataTag = Nothing
            End If
        End If
    End Sub

#End Region

    '4_3_2010 Aruna
#Region "Client Modifications"
    Private Sub setPortOrficeSizesBaseEnd(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPortSizeBaseEnd.SelectedIndexChanged, cmbPortTypeBaseEnd.SelectedIndexChanged
        If Not cmbPortSizeBaseEnd.Text Is Nothing AndAlso Not cmbPortTypeBaseEnd.Text Is Nothing Then
            GetOrificeSizeFunctionaity(cmbOrificeSizeBaseEnd, cmbPortAngleBaseEnd.Text)
        End If
    End Sub

    Private Sub setPortOrficeSizesRodEnd(ByVal sender As Object, ByVal e As EventArgs) Handles cmbPortSizeRodEnd.SelectedIndexChanged, cmbPortTypeRodEnd.SelectedIndexChanged
        If Not cmbPortSizeRodEnd.Text Is Nothing AndAlso Not cmbPortTypeRodEnd.Text Is Nothing Then
            GetOrificeSizeFunctionaity(cmbOrificeSizeRodEnd, cmbPortAngleRodEnd.Text)
        End If
    End Sub

    Private Sub IsCallerAvailable()
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
            If cmbNoofPortsRodEnd.Text <> "" AndAlso cmbPortTypeRodEnd.Text <> "" AndAlso cmbPortSizeRodEnd.Text <> "" AndAlso cmbPortAngleRodEnd.Text <> "" Then
                If (cmbPortAngleRodEnd.Text = "90" AndAlso cmbPortFacingRodEnd.Text <> "") OrElse cmbPortAngleRodEnd.Text = "Straight" Then
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetCollarCylinderLength() Then
                        MessageBox.Show("Collar Length is not available .Please change selection.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmbPortFacingRodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPortFacingRodEnd.SelectedIndexChanged
        IsCallerAvailable()
    End Sub

    Private Sub txtFirstPortOrientationRodEnd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFirstPortOrientationRodEnd.TextChanged

    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, lblPortDetailsIndex, LabelGradient4, LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(LabelGradient5)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(LabelGradient6)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblBaseEndPortDetails)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblRodEndPortDetails)
    End Sub

#End Region

    'ANUP 06-10-2010 START
    Private Sub RodEndPortLoocatorCode_Purchase_Validation()
        Try

            '       ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd PortLocator Code", _strRodEndPortLocatorCode)
            Dim strPartCode As String = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(_strRodEndPortLocatorCode)
            If Not String.IsNullOrEmpty(strPartCode) Then
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd PortLocator Code", strPartCode)
                _strRodEndPortLocatorCode_Purchase = strPartCode
            Else
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("RodEnd PortLocator Code", _strRodEndPortLocatorCode)
                _strRodEndPortLocatorCode_Purchase = _strRodEndPortLocatorCode
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BaseEndPortLoocatorCode_Purchase_Validation(ByVal strPartCode_Call As String)
        Try
            '         ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("BaseEnd PortLocator Code", oPortLocatorCodeDataRow("PortLocatorCode"))
            Dim strPartCode As String = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(strPartCode_Call)
            If Not String.IsNullOrEmpty(strPartCode) Then
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("BaseEnd PortLocator Code", strPartCode)
                _strBaseEndPortLocatorCode_Purchase = strPartCode
            Else
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("BaseEnd PortLocator Code", strPartCode_Call)
                _strBaseEndPortLocatorCode_Purchase = strPartCode_Call
            End If
        Catch ex As Exception

        End Try
    End Sub
    'ANUP 06-10-2010 TILL HERE


    Private Sub grbPortDetails_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles grbPortDetails.MouseHover, txtFirstPortOrientationBaseEnd.MouseHover, txtFirstPortOrientationRodEnd.MouseHover, txtSecondPortOrientationBaseEnd.MouseHover, txtSecondPortOrientationRodEnd.MouseHover, GroupBox1.MouseHover
        If txtFirstPortOrientationBaseEnd.Text <> "" OrElse txtFirstPortOrientationRodEnd.Text <> "" Then
            ObjClsWeldedCylinderFunctionalClass.MdiPictureBox.ImageLocation = ObjClsWeldedCylinderFunctionalClass.CurrentWorkingDirectory + "\Images\BaseEnd_RodEnd_PortAngle.PNG"
        Else
            ObjClsWeldedCylinderFunctionalClass.MdiPictureBox.ImageLocation = ""
        End If
    End Sub
End Class