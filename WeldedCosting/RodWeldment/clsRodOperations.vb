Public Class clsRodOperations

#Region "Private Variables "
    Private _strWorkCenter As String
    Private _dblRunStandardCost As Double
    Private _dblSetupStandardCost As Double
    Private _dblSetupLabourRate As Double
    Private _dblSetupFixedBurdenRate As Double
    Private _dblSetupVariableBurdenRate As Double
    Private _dblRodLength As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodLength
    Private _dblRodDia As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
    Private _dblWeldSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldSize_RodEnd

    Private _oRodOperationsDMC As clsRodOperationsDMC
    Private _oWCDetailsHashTable As Hashtable

    Private _strIsCuttingOrWelded As String

    Private _dblPinHoleSize As Double = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
   
#End Region

#Region "Properties"

    Public Property WCDetailsHashTable() As Hashtable
        Get
            Return _oWCDetailsHashTable
        End Get
        Set(ByVal value As Hashtable)
            _oWCDetailsHashTable = value
        End Set
    End Property

    Private ReadOnly Property WorkCenters() As Hashtable
        Get
            WorkCenters = New Hashtable
            WorkCenters.Add("CUTTING", "WC093")
            WorkCenters.Add("DRILLING", "WC199")
            WorkCenters.Add("MACHINING", "WC122")
            WorkCenters.Add("LATHEWELDING", "WC553")
            WorkCenters.Add("MANUALWELDING", "WC550")
            Return WorkCenters
        End Get
    End Property

    Private ReadOnly Property ColumnByBoreDia() As Hashtable
        Get
            ColumnByBoreDia = New Hashtable
            ColumnByBoreDia.Add(0.75, "[RodDia_0.75]")
            ColumnByBoreDia.Add(0.875, "[RodDia_0.875]")
            ColumnByBoreDia.Add(1.0, "[RodDia_1.00]")
            ColumnByBoreDia.Add(1.125, "[RodDia_1.12]")     '09_10_2010    RAGAVA   1.125  from 1.12
            ColumnByBoreDia.Add(1.25, "[RodDia_1.25]")
            ColumnByBoreDia.Add(1.375, "[RodDia_1.38]")     '09_10_2010    RAGAVA   1.375  from 1.38
            ColumnByBoreDia.Add(1.5, "[RodDia_1.50]")
            ColumnByBoreDia.Add(1.75, "[RodDia_1.75]")
            ColumnByBoreDia.Add(2.0, "[RodDia_2.00]")
            Return ColumnByBoreDia
        End Get
    End Property

    Private ReadOnly Property CuttingAndMachiningTablesName_HashTable() As Hashtable
        Get
            CuttingAndMachiningTablesName_HashTable = New Hashtable

            'CUTTING
            CuttingAndMachiningTablesName_HashTable.Add("Chrome", "Welded.WCCutting_Chrome_Rod")
            CuttingAndMachiningTablesName_HashTable.Add("Nitro Steel", "Welded.WCCutting_Nitro_Rod")
            CuttingAndMachiningTablesName_HashTable.Add("LION 1000", "Welded.WCCutting_Chrome_Rod")

            'MACHINING
            CuttingAndMachiningTablesName_HashTable.Add("ThreadedChrome", "Welded.WCMachining_ThreadedChrome_Rod")
            CuttingAndMachiningTablesName_HashTable.Add("ThreadedNitroSteel", "Welded.WCMachining_ThreadedNitro_Rod")
            CuttingAndMachiningTablesName_HashTable.Add("WeldedChrome", "Welded.WCMachining_WeldedChrome_Rod")
            CuttingAndMachiningTablesName_HashTable.Add("WeldedNitroSteel", "Welded.WCMachining_WeldedNitro_Rod")
            CuttingAndMachiningTablesName_HashTable.Add("ThreadedLION1000", "Welded.WCMachining_ThreadedChrome_Rod")
            CuttingAndMachiningTablesName_HashTable.Add("WeldedLION1000", "Welded.WCMachining_WeldedChrome_Rod")

            Return CuttingAndMachiningTablesName_HashTable
        End Get
    End Property

    Private ReadOnly Property DrillingValidation_HashTable() As Hashtable
        Get
            DrillingValidation_HashTable = New Hashtable

            DrillingValidation_HashTable.Add("D5", "G5")
            DrillingValidation_HashTable.Add("D7", "G7")
            DrillingValidation_HashTable.Add("D9", "G9")
            DrillingValidation_HashTable.Add("D14", "G14")
            DrillingValidation_HashTable.Add("D16", "G16")
            DrillingValidation_HashTable.Add("D18", "G18")
            DrillingValidation_HashTable.Add("D23", "G23")
            DrillingValidation_HashTable.Add("D25", "G25")
            DrillingValidation_HashTable.Add("D27", "G27")
            DrillingValidation_HashTable.Add("D32", "G32")
            DrillingValidation_HashTable.Add("D34", "G34")
            DrillingValidation_HashTable.Add("D36", "G36")

            Return DrillingValidation_HashTable
        End Get
    End Property
#End Region

#Region "Enum"
    Public Enum PartWeight
        Weight_10
        Weight_11_15
        Weight_16_20
        Weight_21_40
    End Enum
#End Region

#Region "Procedures "

#Region "Common "

    Public Sub New()
        _oRodOperationsDMC = New clsRodOperationsDMC
        _oWCDetailsHashTable = New Hashtable
    End Sub

    Public Function CuttingAndMachiningValidation() As String
        CuttingAndMachiningValidation = Nothing
        Try

            If _strIsCuttingOrWelded = "CUTTING" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial = "Chrome" _
                                                                 OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial = "Nitro Steel" _
                                                                  OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial = "LION 1000" Then
                    CuttingAndMachiningValidation = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial
                End If
            ElseIf _strIsCuttingOrWelded = "MACHINING" Then
                If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" _
                                                      AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Threaded") _
                                                       OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Threaded Rod" Then
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial = "Chrome" Then
                        CuttingAndMachiningValidation = "ThreadedChrome"
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial = "Nitro Steel" Then
                        CuttingAndMachiningValidation = "ThreadedNitroSteel"
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial = "LION 1000" Then
                        CuttingAndMachiningValidation = "ThreadedLION1000"
                    End If
                Else
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial = "Chrome" Then
                        CuttingAndMachiningValidation = "WeldedChrome"
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial = "Nitro Steel" Then
                        CuttingAndMachiningValidation = "WeldedNitroSteel"
                    ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial = "LION 1000" Then
                        CuttingAndMachiningValidation = "WeldedLION1000"
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Function

    Private Sub getWorkCenterDetails(ByVal _strWorkCenter As String)
        Try

            Dim oCuttingSetupDetails As DataRow = _oRodOperationsDMC.getWorkCenterDetails(_strWorkCenter)
            If Not IsNothing(oCuttingSetupDetails) Then
                Try
                    _dblSetupStandardCost = oCuttingSetupDetails("SetupCost")
                Catch ex As Exception
                End Try

                Try
                    _dblSetupFixedBurdenRate = oCuttingSetupDetails("FixedBurdenCost")
                Catch ex As Exception
                End Try

                Try
                    _dblSetupVariableBurdenRate = oCuttingSetupDetails("VariableBurdenRate")
                Catch ex As Exception
                End Try

                Try
                    _dblSetupLabourRate = oCuttingSetupDetails("LabourRate")
                Catch ex As Exception
                End Try
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub addDataToStructure(ByVal strWorkCenter As String, ByVal dblRunStandardCost As Double)
        Try

            Dim oWCStructure As New WCStructure
            oWCStructure.WorkCenter = strWorkCenter
            oWCStructure.RunCost = dblRunStandardCost
            oWCStructure.FixedBurdenCost = _dblSetupFixedBurdenRate
            oWCStructure.LabourCost = _dblSetupLabourRate
            oWCStructure.SetupCost = _dblSetupStandardCost
            oWCStructure.VariableBurdenCost = _dblSetupVariableBurdenRate

            '03_11_2010  RAGAVA
            If _oWCDetailsHashTable.ContainsKey(_strWorkCenter) Then
                _oWCDetailsHashTable.Add(_strWorkCenter & "_1", oWCStructure)
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodWorkCenterList.Add(_strWorkCenter & "_1")       '01_10_2010   RAGAVA
            Else
                _oWCDetailsHashTable.Add(_strWorkCenter, oWCStructure)
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodWorkCenterList.Add(_strWorkCenter)       '01_10_2010   RAGAVA
            End If
            '_oWCDetailsHashTable.Add(_strWorkCenter, oWCStructure)
            'Till   Here
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Cutting "

    Public Sub CuttingFunctionality()
        Try

            _strIsCuttingOrWelded = "CUTTING"
            _strWorkCenter = WorkCenters("CUTTING")
            getWorkCenterDetails(_strWorkCenter)
            Dim strCuttingAndMachining As String = CuttingAndMachiningValidation()
            If Not IsNothing(strCuttingAndMachining) Then
                _dblRunStandardCost = _oRodOperationsDMC.getCuttingStandardCost(_dblRodLength, ColumnByBoreDia(_dblRodDia), CuttingAndMachiningTablesName_HashTable(strCuttingAndMachining))
                addDataToStructure(_strWorkCenter, _dblRunStandardCost)
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Drilling "

    Public Sub DrillingFunctionality(ByVal dblRulesID As Double, ByVal _oExcelSheet_DrillingOne As Object, ByVal _oExcelSheet_DrillingTwo As Object)
        Try
            '03_11_2010   RAGAVA     Added   "Drilled Pin Hole"  condition
            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize = "Resize" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Drilled Pin Hole" OrElse ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug") AndAlso ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated") Then   '11_10_2010   RAGAVA
                _strWorkCenter = WorkCenters("DRILLING")
                getWorkCenterDetails(_strWorkCenter)
                If dblRulesID = 1004 OrElse dblRulesID = 1008 Then
                    _oExcelSheet_DrillingOne.range(DrillingFunctionality_ExcelCellNumber).value = HoleDepth()
                    _dblRunStandardCost = _oExcelSheet_DrillingOne.range(DrillingValidation_HashTable(DrillingFunctionality_ExcelCellNumber).ToString).value
                ElseIf dblRulesID = 1003 OrElse dblRulesID = 1007 Then
                    _oExcelSheet_DrillingTwo.range(DrillingFunctionality_ExcelCellNumber).value = _dblRodDia
                    _dblRunStandardCost = _oExcelSheet_DrillingTwo.range(DrillingValidation_HashTable(DrillingFunctionality_ExcelCellNumber).ToString).value
                End If
                addDataToStructure(_strWorkCenter, _dblRunStandardCost)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function DrillingFunctionality_ExcelCellNumber() As String
        DrillingFunctionality_ExcelCellNumber = Nothing
        Try
            Dim dblWeight As Double = 0 'Must assign a value
            If dblWeight <= 10 Then
                DrillingFunctionality_ExcelCellNumber = PinHoleSizeFunctionality(PartWeight.Weight_10.ToString)
            ElseIf dblWeight > 10 AndAlso dblWeight <= 15 Then
                DrillingFunctionality_ExcelCellNumber = PinHoleSizeFunctionality(PartWeight.Weight_11_15.ToString)
            ElseIf dblWeight > 15 AndAlso dblWeight <= 20 Then
                DrillingFunctionality_ExcelCellNumber = PinHoleSizeFunctionality(PartWeight.Weight_16_20.ToString)
            ElseIf dblWeight > 20 AndAlso dblWeight <= 40 Then
                DrillingFunctionality_ExcelCellNumber = PinHoleSizeFunctionality(PartWeight.Weight_21_40.ToString)
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Function PinHoleSizeFunctionality(ByVal strPartweight As String) As String
        PinHoleSizeFunctionality = Nothing
        Try
            If _dblPinHoleSize <= 0.75 Then
                If strPartweight = PartWeight.Weight_10.ToString Then
                    PinHoleSizeFunctionality = "D5"
                ElseIf strPartweight = PartWeight.Weight_11_15.ToString Then
                    PinHoleSizeFunctionality = "D14"
                ElseIf strPartweight = PartWeight.Weight_16_20.ToString Then
                    PinHoleSizeFunctionality = "D23"
                ElseIf strPartweight = PartWeight.Weight_21_40.ToString Then
                    PinHoleSizeFunctionality = "D32"
                End If
            ElseIf _dblPinHoleSize > 0.75 AndAlso _dblPinHoleSize <= 1.25 Then
                If strPartweight = PartWeight.Weight_10.ToString Then
                    PinHoleSizeFunctionality = "D7"
                ElseIf strPartweight = PartWeight.Weight_11_15.ToString Then
                    PinHoleSizeFunctionality = "D16"
                ElseIf strPartweight = PartWeight.Weight_16_20.ToString Then
                    PinHoleSizeFunctionality = "D25"
                ElseIf strPartweight = PartWeight.Weight_21_40.ToString Then
                    PinHoleSizeFunctionality = "D34"
                End If
            ElseIf _dblPinHoleSize > 1.25 AndAlso _dblPinHoleSize <= 1.75 Then
                If strPartweight = PartWeight.Weight_10.ToString Then
                    PinHoleSizeFunctionality = "D9"
                ElseIf strPartweight = PartWeight.Weight_11_15.ToString Then
                    PinHoleSizeFunctionality = "D18"
                ElseIf strPartweight = PartWeight.Weight_16_20.ToString Then
                    PinHoleSizeFunctionality = "D27"
                ElseIf strPartweight = PartWeight.Weight_21_40.ToString Then
                    PinHoleSizeFunctionality = "D36"
                End If
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Function HoleDepth() As Double
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
                HoleDepth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeWidth_RodEnd
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Single Lug" Then
                HoleDepth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugWidth_RodEnd
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" Then
                HoleDepth = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.LugThickness_RodEnd * 3
            End If
        Catch ex As Exception

        End Try
    End Function

#End Region

#Region "Welding "

    Public Sub LatheWeldingFunctionality()
        _strWorkCenter = WorkCenters("LATHEWELDING")
        getWorkCenterDetails(_strWorkCenter)
        _dblRunStandardCost = LatheWelding_Calculation()
        addDataToStructure(_strWorkCenter, _dblRunStandardCost)
    End Sub

    Private Function LatheWelding_Calculation() As Double
        Dim dblHandlingTime As Double
        Dim dblArcTime As Double
        Dim dblRodLength_Diameter As Double = _dblRodLength * _dblRodDia

        If dblRodLength_Diameter <= 50 Then
            dblHandlingTime = 20
        ElseIf dblRodLength_Diameter > 50 AndAlso dblRodLength_Diameter < 100 Then
            dblHandlingTime = 30
        ElseIf dblRodLength_Diameter >= 100 Then
            dblHandlingTime = 40
        End If
        dblArcTime = ArcTime_Calculation()

        LatheWelding_Calculation = 3600 / (1.05 * (dblHandlingTime + 10 + dblArcTime))
    End Function

    Public Function ArcTime_Calculation() As Double
        If ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Cast" Then
            ArcTime_Calculation = _oRodOperationsDMC.getArcTime_CastingTable(_dblRodDia, _dblWeldSize)
        ElseIf ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Lathe" Then
            ArcTime_Calculation = _oRodOperationsDMC.getArcTime_LatheULugTable(_dblRodDia, _dblWeldSize)
        End If
    End Function

    Public Sub ManualWeldingFunctionality_One()
        If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" AndAlso ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated") OrElse ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual" Then      '11_10_2010   RAGAVA
            _strWorkCenter = WorkCenters("MANUALWELDING")
            getWorkCenterDetails(_strWorkCenter)
            _dblRunStandardCost = ManulWeldOneCalculation()
            addDataToStructure(_strWorkCenter, _dblRunStandardCost)
        End If
    End Sub

    Public Function ManulWeldOneCalculation() As Double
        Dim dblRodLength_Diameter As Double = _dblRodLength * _dblRodDia

        If dblRodLength_Diameter <= 50 Then
            ManulWeldOneCalculation = 35
        ElseIf dblRodLength_Diameter > 50 AndAlso dblRodLength_Diameter < 100 Then
            ManulWeldOneCalculation = 30
        ElseIf dblRodLength_Diameter >= 100 Then
            ManulWeldOneCalculation = 25
        End If
    End Function

    Public Sub ManualWeldingFunctionality_Two()
        If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" AndAlso ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated") OrElse ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual" Then      '11_10_2010   RAGAVA
            _strWorkCenter = WorkCenters("MANUALWELDING")
            getWorkCenterDetails(_strWorkCenter)
            _dblRunStandardCost = ManualWeldTwoCalculation()
            addDataToStructure(_strWorkCenter, _dblRunStandardCost)
        End If
    End Sub

    Public Function ManualWeldTwoCalculation() As Double
        Try
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" AndAlso ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated" Then
                ManualWeldTwoCalculation = _oRodOperationsDMC.getNumberOfPasses_ManualCrossTubeTable(_dblRodDia, _dblWeldSize)
            ElseIf ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual" Then
                ManualWeldTwoCalculation = _oRodOperationsDMC.getNumberOfPasses_ManualULugTable(_dblRodDia, _dblWeldSize)
            End If

            '03_11_2010   RAGAVA
            Dim dblRodLength_Diameter As Double = _dblRodLength * _dblRodDia
            If dblRodLength_Diameter <= 50 Then
                ManualWeldTwoCalculation = 100 / (1.5 + ManualWeldTwoCalculation)
            ElseIf dblRodLength_Diameter > 50 AndAlso dblRodLength_Diameter < 100 Then
                ManualWeldTwoCalculation = 100 / (2 + ManualWeldTwoCalculation)
            ElseIf dblRodLength_Diameter >= 100 Then
                ManualWeldTwoCalculation = 100 / (2.5 + ManualWeldTwoCalculation)
            End If
            'Till  Here
        Catch ex As Exception
        End Try
    End Function
#End Region

#Region "MACHINING"

    Public Sub MachiningFunctionality()
        Try

            _strIsCuttingOrWelded = "MACHINING"
            _strWorkCenter = WorkCenters("MACHINING")
            getWorkCenterDetails(_strWorkCenter)
            Dim strCuttingAndMachining As String = CuttingAndMachiningValidation()
            If Not IsNothing(strCuttingAndMachining) Then
                _dblRunStandardCost = _oRodOperationsDMC.getMachiningStandardCost(_dblRodLength, ColumnByBoreDia(_dblRodDia), CuttingAndMachiningTablesName_HashTable(strCuttingAndMachining))
                addDataToStructure(_strWorkCenter, _dblRunStandardCost)
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#End Region

End Class
