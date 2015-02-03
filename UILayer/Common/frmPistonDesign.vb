Public Class frmPistonDesign

#Region "Private Variables"

    'For temp Comparision
    Private _dblTempBoreDiameter As Double = 0

    Private _strTempPistonShankSeal As String = ""

    Private _strTempPistonConnection As String = ""

    Private _dblTempPistonNutSize As Double = 0

    Private _dblPistonODatSeal As Double

    Private _dblPistonODatSeal_Tol_LL As Double

    Private _dblPistonODatSeal_Tol_UL As Double

    Private _dblPistonSealGrooveWidth As Double

    Private _dblPistonSealGrooveWidth_Tol_LL As Double

    Private _dblPistonSealGrooveWidth_Tol_UL As Double

    Private _dblPistonSealGrooveDiameter As Double

    Private _dblPistonSealGrooveDiameter_Tol_LL As Double

    Private _dblPistonSealGrooveDiameter_Tol_UL As Double

    Private _dblPistonODatWearRing As Double

    Private _dblPistonODatWearRing_Tol_LL As Double

    Private _dblPistonODatWearRing_Tol_UL As Double

    Private _dblWearRingGrooveWidth As Double

    Private _dblWearRingGrooveWidth_Tol_LL As Double

    Private _dblWearRingGrooveWidth_Tol_UL As Double

    Private _dblWearRingGrooveDiameter As Double

    Private _dblWearRingGrooveDiameter_Tol_LL As Double

    Private _dblWearRingGrooveDiameter_Tol_UL As Double

    Private _dblMinimumPistonWidth As Double

    Private _dblMinimumWallThickness As Double = 0.12

    'Added by Sandeep on 12-01-10

    Private _dblX As Double

    Private _dblY As Double

    Private _dblZ As Double

    '---------------------------

    Private _dblCalculatedPistonWidth As Double

    Private _dblFinalPistonWidth As Double

    Private _dblPistonDiameter As Double

    Public _strIsExistingorNewDesign As String

    Private _dblCounterBoreThickness As Double

    Private _dblCounterBoreDepth As Double

    Private _dblCounterBoreDiameter As Double

    Private _strPistonWearRingCode As String

    Private _strPistonSealCode As String

    Private _dblPI_MinDistance_from_RodSide_to_SealGrooveStart As Double

    Private _dblTan_15 As Double = 0.2679491924311227

    'TODO:Sandeep 01--3-10 3pm
    Private _strQuery As String

    Private _strPistonCode As String

    Private _blnRowInserted As Boolean

    'TODO: ANUP 22-07-2010 12.14pm
    Private _blnIsPopulated As Boolean = False

    Private _oTable As DataTable

    Private _oRow As DataRow

    'ANUP 06-10-2010 START
    Private _strPistonCode_Purchased As String = String.Empty
    Public _strPistonWearRingCode_Purchased As String = String.Empty
    Public _strPistonSealCode_Purchased As String = String.Empty
    'ANUP 06-10-2010 TILL HERE




#End Region

#Region "Properties"

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
            Dim strexcelPistonSeal As String = ""
            strexcelPistonSeal = cmbPistonSeal.Text
            ControlsData.Add(New Object(3) {"GUI", "PI_Piston Seal", "F3", strexcelPistonSeal})
            ControlsData.Add(New Object(3) {"GUI", "PI_Piston Wear Ring", "F4", cmbPistonWearRing.Text})
            ControlsData.Add(New Object(3) {"GUI", "PI_Wear Ring Quantity", "F5", cmbWearRingQuantity.Text})
            ControlsData.Add(New Object(3) {"DB", "PI_Piston Design", "F28", _strIsExistingorNewDesign})

            Try

            Catch ex As Exception

            End Try

            'ANUP 06-10-2010 START

            'ANUP 07-10-2010 START
            ControlsData.Add(New Object(3) {"GUI", "PI_Piston Code", "F6", _oRow("PistonCode")})
            Try
                ObjClsWeldedCylinderFunctionalClass.PistonCodeNumber = _oRow("PistonCode")   '10_10_2010    RAGAVA
            Catch ex As Exception
            End Try
            'ANUP 07-10-2010 TILL HERE

            clsAddExistingCodes.AddPistonCode(_strPistonCode_Purchased, 1, "EA") 'Costing 03-08-10

            ControlsData.Add(New Object(3) {"DB", "PI_Wear Ring Code", "F31", _strPistonWearRingCode})
            clsAddExistingCodes.AddPistonWearRingCode(_strPistonWearRingCode_Purchased, 1, "EA") 'Costing 03-08-10

            ControlsData.Add(New Object(3) {"DB", "PI_Piston Seal Code", "F32", _strPistonSealCode})
            clsAddExistingCodes.AddPistonSealCode(_strPistonSealCode_Purchased, 1, "EA") 'Costing 03-08-10
            'ANUP 06-10-2010 TILL HERE

            ControlsData.Add(New Object(3) {"GUI", "PI_Piston Width", "F7", _dblFinalPistonWidth})
            '17_02_2010 Aruna Start
            ControlsData.Add(New Object(3) {"DB", "PI_Counterbore Diameter", "F9", _dblCounterBoreDiameter})
            If Not _oRow("CounterBoreDepth") = "N/A" Then
                ControlsData.Add(New Object(3) {"DB", "PI_Counterbore Depth", "F8", _dblFinalPistonWidth - _dblCounterBoreDepth})
            Else
                ControlsData.Add(New Object(3) {"DB", "PI_Counterbore Depth", "F8", _dblCounterBoreDepth})
            End If
            'End If
            '17_02_2010 Aruna Ends

            ControlsData.Add(New Object(3) {"DB", "PI_PistonOD @ Seal", "F10", _dblPistonODatSeal})
            ControlsData.Add(New Object(3) {"DB", "PI_PistonOD @ Seal TOL_UL", "F11", _dblPistonODatSeal_Tol_UL})
            ControlsData.Add(New Object(3) {"DB", "PI_PistonOD @ Seal TOL_LL", "F12", _dblPistonODatSeal_Tol_LL})

            ControlsData.Add(New Object(3) {"DB", "PI_Seal Groove Diameter", "F13", _dblPistonSealGrooveDiameter})
            ControlsData.Add(New Object(3) {"DB", "PI_Seal Groove Diameter TOL_UL", "F14", _dblPistonSealGrooveDiameter_Tol_UL})
            ControlsData.Add(New Object(3) {"DB", "PI_Seal Groove Diameter TOL_LL", "F15", _dblPistonSealGrooveDiameter_Tol_LL})

            ControlsData.Add(New Object(3) {"DB", "PI_Seal Groove Width", "F16", _dblPistonSealGrooveWidth})
            ControlsData.Add(New Object(3) {"DB", "PI_Seal Groove Width TOL_UL", "F17", _dblPistonSealGrooveWidth_Tol_UL})
            ControlsData.Add(New Object(3) {"DB", "PI_Seal Groove Width TOL_LL", "F18", _dblPistonSealGrooveWidth_Tol_LL})

            ControlsData.Add(New Object(3) {"DB", "PI_PistonOD @ Wear Ring", "F19", _dblPistonODatWearRing})
            ControlsData.Add(New Object(3) {"DB", "PI_PistonOD @ Wear Ring TOL_UL", "F20", _dblPistonODatWearRing_Tol_UL})
            ControlsData.Add(New Object(3) {"DB", "PI_PistonOD @ Wear Ring TOL_LL", "F21", _dblPistonODatWearRing_Tol_LL})

            ControlsData.Add(New Object(3) {"DB", "PI_Wear Ring Diameter", "F22", _dblWearRingGrooveDiameter})
            ControlsData.Add(New Object(3) {"DB", "PI_Wear Ring Diameter TOL_UL", "F23", _dblWearRingGrooveDiameter_Tol_UL})
            ControlsData.Add(New Object(3) {"DB", "PI_Wear Ring Diameter TOL_LL", "F24", _dblWearRingGrooveDiameter_Tol_LL})

            ControlsData.Add(New Object(3) {"DB", "PI_Wear Ring Width", "F25", _dblWearRingGrooveWidth})
            ControlsData.Add(New Object(3) {"DB", "PI_Wear Ring Width TOL_UL", "F26", _dblWearRingGrooveWidth_Tol_UL})
            ControlsData.Add(New Object(3) {"DB", "PI_Wear Ring Width TOL_LL", "F27", _dblWearRingGrooveWidth_Tol_LL})

            ControlsData.Add(New Object(3) {"DB", "PI_Wall Thickness @ Rod side", "F29", _dblMinimumWallThickness})
            ControlsData.Add(New Object(3) {"DB", "PI_Min Distance from Rod Side to  Seal Groove Start", "F33", _dblPI_MinDistance_from_RodSide_to_SealGrooveStart})
            ControlsData.Add(New Object(3) {"DB", "PI_Max Distance from Rod Side to  Seal Groove End", "F34", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PI_MaxDistance_from_RodSide_to_SealGrooveEnd})
            '  End If
            Return ControlsData
        End Get
    End Property

#End Region

#Region "Sub Procedures"

    Public Sub ManualLoad()
        SetPistonSeal()
    End Sub

    Private Sub GetPistonDetails()
        Try
            If cmbPistonSeal.Text <> "" AndAlso cmbWearRingQuantity.Text <> "" AndAlso cmbPistonWearRing.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Seal", cmbPistonSeal.Text)

                Try

                    ''ANUP 07-10-2010 START  COMMENTED BY ANUP
                    ''     ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Code", _oRow("PistonCode"))
                    'Dim strPartCode As String = PartCode_Purchased_Validation(_oRow("PistonCode"))
                    'If Not String.IsNullOrEmpty(strPartCode) Then
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Code", _strPistonCode_Purchased)
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.StrPistonSeal = cmbPistonSeal.Text  'vamsi 29-1-2015
                    '    _strPistonCode_Purchased = strPartCode
                    'Else
                    '    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Code", _oRow("PistonCode"))
                    '    _strPistonCode_Purchased = _oRow("PistonCode")
                    'End If
                    ''ANUP 06-10-2010 TILL HERE
                    ''ANUP 07-10-2010 TILL HERE

                    _dblFinalPistonWidth = _oRow("PistonWidth")
                    ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Width", _oRow("PistonWidth"))
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonWidth = _oRow("PistonWidth")

                    'ANUP 02-07-2010
                    ObjClsWeldedCylinderFunctionalClass.IsCounterBoreOrNot = False
                    If Not _oRow("CounterBoreDepth") = "N/A" Then
                        _dblCounterBoreDepth = _oRow("CounterBoreDepth")
                        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("CounterBoreDepth", _oRow("CounterBoreDepth"))
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreDepth = _oRow("CounterBoreDepth")
                        ObjClsWeldedCylinderFunctionalClass.IsCounterBoreOrNot = True
                    Else
                        _dblCounterBoreDepth = 0
                        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("CounterBoreDepth", 0)
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CounterBoreDepth = 0
                    End If

                    GetCounterBoreDiameter() 'TODO: ANUP 08-06-2010 02.55pm

                    'Piston Seal Details
                    PistonSealDetails_Existing(_oRow)

                    'Piston Wear Ring Details
                    If cmbWearRingQuantity.Text <> "0" Then
                        WearRingDetailsforExisting(_oRow)
                    End If

                    'Sandeep 26-02-10-2pm
                    _strIsExistingorNewDesign = "Existing"
                    '************************

                    'Sandeep 18-02-10

                    'PistonWear Code
                    If cmbWearRingQuantity.Text = 0 Then
                        _strPistonWearRingCode = "N/A"
                    ElseIf cmbWearRingQuantity.Text = 1 Then
                        If Not IsDBNull(_oRow("SingleWearRing")) Then
                            _strPistonWearRingCode = _oRow("SingleWearRing")
                        End If

                    End If

                    'ANUP 06-10-2010 START 
                    '       ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston WearRing Code", _strPistonWearRingCode)
                    Dim strPartCode As String = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(_strPistonWearRingCode)
                    If Not String.IsNullOrEmpty(strPartCode) Then
                        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston WearRing Code", strPartCode)
                        _strPistonWearRingCode_Purchased = strPartCode
                    Else
                        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston WearRing Code", _strPistonWearRingCode)
                        _strPistonWearRingCode_Purchased = _strPistonWearRingCode
                    End If
                    'ANUP 06-10-2010 TILL HERE

                    If cmbPistonSeal.Text = "Wyn Seal" Then

                        'ANUP 06-10-2010 START 
                        '          ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Seal Code", _oRow("PSP"))
                        strPartCode = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(_oRow("PSP"))
                        If Not String.IsNullOrEmpty(strPartCode) Then
                            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Seal Code", strPartCode)
                            _strPistonSealCode_Purchased = strPartCode
                        Else
                            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Seal Code", _oRow("PSP"))
                            _strPistonSealCode_Purchased = _oRow("PSP")
                        End If
                        'ANUP 06-10-2010 TILL HERE
                        _strPistonSealCode = _oRow("PSP")

                    ElseIf cmbPistonSeal.Text = "Glyd-P Seal" Then

                        'ANUP 06-10-2010 START 
                        '                 ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Seal Code", _oRow("ZMacro"))
                        strPartCode = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(_oRow("ZMacro"))
                        If Not String.IsNullOrEmpty(strPartCode) Then
                            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Seal Code", strPartCode)
                            _strPistonSealCode_Purchased = strPartCode
                        Else
                            ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Piston Seal Code", _oRow("ZMacro"))
                            _strPistonSealCode_Purchased = _oRow("ZMacro")
                        End If
                        'ANUP 06-10-2010 TILL HERE
                        _strPistonSealCode = _oRow("ZMacro")

                    End If

                    If Not IsDBNull(_oRow("MinDistanceFromRodSideToSealGrooveStart")) Then
                        _dblPI_MinDistance_from_RodSide_to_SealGrooveStart = _oRow("MinDistanceFromRodSideToSealGrooveStart")
                        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Min Distance from RodSide to Seal Groove Start", _oRow("MinDistanceFromRodSideToSealGrooveStart"))
                    End If

                    If Not IsDBNull(_oRow("MaxDistanceFromRodSideToSealGrooveEnd")) Then
                        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PI_MaxDistance_from_RodSide_to_SealGrooveEnd = _oRow("MaxDistanceFromRodSideToSealGrooveEnd")
                        ObjClsWeldedCylinderFunctionalClass.AddGeneralInformationValues("Max Distance from RodSide to Seal Groove End", _oRow("MaxDistanceFromRodSideToSealGrooveEnd"))
                    End If

                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in GetPistonCode of frmPistonDesign " + ex.Message)
        End Try
    End Sub

    Private Sub SetZeroToExcelVariables()
        _dblMinimumPistonWidth = 0
        _dblCounterBoreThickness = 0
        _dblCounterBoreDepth = 0
        _dblPistonODatWearRing = 0
        _dblPistonODatWearRing_Tol_UL = 0
        _dblPistonODatWearRing_Tol_LL = 0
        _dblWearRingGrooveDiameter = 0
        _dblWearRingGrooveDiameter_Tol_UL = 0
        _dblWearRingGrooveDiameter_Tol_LL = 0
        _dblWearRingGrooveWidth = 0
        _dblWearRingGrooveWidth_Tol_UL = 0
        _dblWearRingGrooveWidth_Tol_LL = 0
        _dblPistonODatSeal = 0
        _dblPistonODatSeal_Tol_LL = 0
        _dblPistonODatSeal_Tol_UL = 0
        _dblPistonSealGrooveDiameter = 0
        _dblPistonSealGrooveDiameter_Tol_UL = 0
        _dblPistonSealGrooveDiameter_Tol_LL = 0
        _dblPistonSealGrooveWidth = 0
        _dblPistonSealGrooveWidth_Tol_UL = 0
        _dblPistonSealGrooveWidth_Tol_LL = 0
        _dblCalculatedPistonWidth = 0
        _dblFinalPistonWidth = 0
        _dblPistonDiameter = 0
    End Sub

    Private Sub PistonSealDetails_Existing(ByVal _oRow As DataRow)
        Try

            If Not IsDBNull(_oRow("PistonODatSeal")) Then
                _dblPistonODatSeal = _oRow("PistonODatSeal")
            End If

            If Not IsDBNull(_oRow("PistonODatSeal_TOL_LL")) Then
                _dblPistonODatSeal_Tol_LL = _oRow("PistonODatSeal_TOL_LL")
            End If

            If Not IsDBNull(_oRow("PistonODatSeal_TOL_UL")) Then
                _dblPistonODatSeal_Tol_UL = _oRow("PistonODatSeal_TOL_UL")
            End If

            If Not IsDBNull(_oRow("SealGrooveDiameter")) Then
                _dblPistonSealGrooveDiameter = _oRow("SealGrooveDiameter")
            End If

            If Not IsDBNull(_oRow("SealGrooveDiameter_TOL_UL")) Then
                _dblPistonSealGrooveDiameter_Tol_UL = _oRow("SealGrooveDiameter_TOL_UL")
            End If

            If Not IsDBNull(_oRow("SealGrooveDiameter_TOL_LL")) Then
                _dblPistonSealGrooveDiameter_Tol_LL = _oRow("SealGrooveDiameter_TOL_LL")
            End If

            If Not IsDBNull(_oRow("SealGrooveWidth")) Then
                _dblPistonSealGrooveWidth = _oRow("SealGrooveWidth")
            End If

            If Not IsDBNull(_oRow("SealGrooveWidth_TOL_UL")) Then
                _dblPistonSealGrooveWidth_Tol_UL = _oRow("SealGrooveWidth_TOL_UL")
            End If

            If Not IsDBNull(_oRow("SealGrooveWidth_TOL_LL")) Then
                _dblPistonSealGrooveWidth_Tol_LL = _oRow("SealGrooveWidth_TOL_LL")
            End If

        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in PistonSeal_PSP of frmPistonDesign " + ex.Message)
        End Try
    End Sub

    Private Sub WearRingDetailsforExisting(ByVal oPistonDataRow As DataRow)
        Try

            If Not IsDBNull(oPistonDataRow("PistonODatWearRing")) Then
                _dblPistonODatWearRing = oPistonDataRow("PistonODatWearRing")
            End If

            If Not IsDBNull(oPistonDataRow("PistonODatWearRing_TOL_UL")) Then
                _dblPistonODatWearRing_Tol_UL = oPistonDataRow("PistonODatWearRing_TOL_UL")
            End If

            If Not IsDBNull(oPistonDataRow("PistonODatWearRing_TOL_LL")) Then
                _dblPistonODatWearRing_Tol_LL = oPistonDataRow("PistonODatWearRing_TOL_LL")
            End If

            If Not IsDBNull(oPistonDataRow("WearRingDiameter")) Then
                _dblWearRingGrooveDiameter = oPistonDataRow("WearRingDiameter")
            End If

            If Not IsDBNull(oPistonDataRow("WearRingDiameter_TOL_UL")) Then
                _dblWearRingGrooveDiameter_Tol_UL = oPistonDataRow("WearRingDiameter_TOL_UL")
            End If

            If Not IsDBNull(oPistonDataRow("WearRingDiameter_TOL_LL")) Then
                _dblWearRingGrooveDiameter_Tol_LL = oPistonDataRow("WearRingDiameter_TOL_LL")
            End If

            If Not IsDBNull(oPistonDataRow("WearRingWidth")) Then
                _dblWearRingGrooveWidth = oPistonDataRow("WearRingWidth")
            End If

            If Not IsDBNull(oPistonDataRow("WearRingWidth_TOL_UL")) Then
                _dblWearRingGrooveWidth_Tol_UL = oPistonDataRow("WearRingWidth_TOL_UL")
            End If

            If Not IsDBNull(oPistonDataRow("WearRingWidth_TOL_LL")) Then
                _dblWearRingGrooveWidth_Tol_LL = oPistonDataRow("WearRingWidth_TOL_LL")
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in WearRingDetails of frmPistonDesign " + ex.Message)
        End Try
    End Sub

    Private Sub GetCounterBoreDiameter()
        Try
            Dim strCounterBoreDiameter As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass. _
            GetCounterBoreDiameter(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, _
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInDecimals)
            If Not strCounterBoreDiameter = "N/A" AndAlso Not IsNothing(strCounterBoreDiameter) Then
                _dblCounterBoreDiameter = Val(strCounterBoreDiameter)
            Else
                _dblCounterBoreDiameter = 0
            End If
        Catch ex As Exception
            ObjClsWeldedCylinderFunctionalClass.WriteLogInformation("Error occured in GetCounterBoreDiameter of frmPistonDesign " + ex.Message)
        End Try
    End Sub

#End Region

#Region "Events"

    Private Sub frmPistonAndHeadDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        SetPistonSeal()
        ObjClsWeldedCylinderFunctionalClass.AddColors(Me)
    End Sub

    Private Sub cmbPistonWearRing_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPistonWearRing.SelectedIndexChanged
        If cmbPistonWearRing.Text <> "" Then
            SetQuantity(cmbPistonWearRing.Text)
        End If
    End Sub

#End Region

#Region "New"

    Private Sub SetPistonSeal()
        Try
            DefaultSettings() 'TODO: ANUP 08-07-2010 03.54
            _oTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetPistonSeal(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInDecimals)
            cmbPistonSeal.Items.Clear()

            For Each oRow As DataRow In _oTable.Rows
                If oRow("PSP") <> "N/A" Then
                    cmbPistonSeal.Items.Add("Wyn Seal")
                End If
                If oRow("ZMacro") <> "N/A" Then
                    cmbPistonSeal.Items.Add("Glyd-P Seal")
                End If
            Next
            cmbPistonSeal.SelectedIndex = 0


      
            '21_12_2010  RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked = True Then
                cmbPistonSeal.SelectedIndex = 1
                cmbPistonSeal.Enabled = False
            Else
                cmbPistonSeal.Enabled = True
            End If
            'Till   Here
        Catch ex As Exception

        End Try
    End Sub

    'TODO: ANUP 08-07-2010 03.54
    Private Sub DefaultSettings()
        txtPistonCode.Enabled = False
        cmbPistonWearRing.Enabled = False
        cmbWearRingQuantity.Enabled = False
    End Sub

    Private Sub SetPistonWearRing(ByVal strPistonSeal As String)
        Dim strFiledName As String = String.Empty
        If strPistonSeal = "Wyn Seal" Then
            strFiledName = "PSP"
        ElseIf strPistonSeal = "Glyd-P Seal" Then
            strFiledName = "ZMacro"
        End If
        cmbPistonWearRing.Items.Clear()
        Dim strExpression As String = strFiledName + " <> 'N/A'"
        Dim oRows() As DataRow = _oTable.Select(strExpression)
        If oRows(0)("SingleWearRing") <> "N/A" Then
            cmbPistonWearRing.Items.Add("YES")
        Else
            cmbPistonWearRing.Items.Add("NO")
        End If
        _oRow = oRows(0)
        cmbPistonWearRing.SelectedIndex = 0
    End Sub

    Private Sub SetQuantity(ByVal WearRingType As String)
        cmbWearRingQuantity.Items.Clear()
        If WearRingType = "YES" Then
            cmbWearRingQuantity.Items.Add("1")
        ElseIf WearRingType = "NO" Then
            cmbWearRingQuantity.Items.Add("0")
        End If
        cmbWearRingQuantity.SelectedIndex = 0
    End Sub

    Private Sub cmbPistonSeal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPistonSeal.SelectedIndexChanged
        If cmbPistonSeal.Text <> String.Empty AndAlso cmbPistonSeal.Text <> "System.Data.DataRowView" Then
            SetPistonWearRing(cmbPistonSeal.Text)

            'ANUP 07-10-2010 START 
            Dim strPartCode As String = ObjClsWeldedCylinderFunctionalClass.PartCode_Purchased_Validation(_oRow("PistonCode"))
            If Not String.IsNullOrEmpty(strPartCode) Then
                _strPistonCode_Purchased = strPartCode
            Else
                _strPistonCode_Purchased = _oRow("PistonCode")
            End If
            'ANUP 07-10-2010 TILL HERE

            txtPistonCode.Text = _strPistonCode_Purchased
            GetPistonDetails()
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedPistonSeal = cmbPistonSeal.Text
        End If
    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, LabelGradient5, LabelGradient4, LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblPistonDesign)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblPistonDesignIndex)
    End Sub

#End Region

End Class