Public Class clsRodRulesSequence

#Region "Private Variables"

    Private _oRodOperationsDMC As clsRodOperationsDMC
    Private _oRodOperations As clsRodOperations

    Private _dblWCRulesID As Double
    Private _dblWCOperations As DataTable
    Private _strRodMaterial As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodMaterial
    Private _strRodEndConfiguration As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration
    Private _oExcelSheet_DrillingOne As Object
    Private _oExcelSheet_DrillingTwo As Object

#End Region

#Region "Public Properties"

    Public Property RodOperations() As clsRodOperations
        Get
            Return _oRodOperations
        End Get
        Set(ByVal value As clsRodOperations)
            _oRodOperations = value
        End Set
    End Property

    Public ReadOnly Property RodMaterial_RodEndConfiguration_HashTable() As Hashtable
        Get
            RodMaterial_RodEndConfiguration_HashTable = New Hashtable

            Try

          
                'ROD MATERIAL DATA 
                RodMaterial_RodEndConfiguration_HashTable.Add("Chrome", "Chrome or Nitro")
                RodMaterial_RodEndConfiguration_HashTable.Add("Nitro Steel", "Chrome or Nitro")
                RodMaterial_RodEndConfiguration_HashTable.Add("Induction Hardened", "Ind Hardened")
                RodMaterial_RodEndConfiguration_HashTable.Add("LION 1000", "Chrome or Nitro")


                'ROD END CONFIGURATION DATA
                RodMaterial_RodEndConfiguration_HashTable.Add("Threaded", "Threaded")
                RodMaterial_RodEndConfiguration_HashTable.Add("Drilled Pin Hole", "Driiled Pin Hole")
                RodMaterial_RodEndConfiguration_HashTable.Add("Welded", "Welded")
                RodMaterial_RodEndConfiguration_HashTable.Add("Welded Pin Hole Drilling", "Welded_PinHoleDrilling")

                Return RodMaterial_RodEndConfiguration_HashTable

            Catch ex As Exception

            End Try
        End Get
    End Property


#End Region

#Region "Sub Procedures "

    Public Sub New(ByVal oExcelSheet_DrillingOne As Object, ByVal oExcelSheet_DrillingTwo As Object)
        _oRodOperationsDMC = New clsRodOperationsDMC
        _oRodOperations = New clsRodOperations
        _oExcelSheet_DrillingOne = oExcelSheet_DrillingOne
        _oExcelSheet_DrillingTwo = oExcelSheet_DrillingTwo
        GetRulesOperationsSequence()
    End Sub

    Private Sub ThreadedValidation()
        Try
            If (_strRodEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConnectionType = "Threaded") _
                                                           OrElse _strRodEndConfiguration = "Threaded Rod" Then
                _strRodEndConfiguration = "Threaded"
            ElseIf _strRodEndConfiguration = "Drilled Pin Hole" Then
                _strRodEndConfiguration = "Drilled Pin Hole"
            ElseIf WeldedPinHoleDrillingValidation() Then
                _strRodEndConfiguration = "Welded Pin Hole Drilling"
            Else
                _strRodEndConfiguration = "Welded"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function WeldedPinHoleDrillingValidation() As Boolean
        WeldedPinHoleDrillingValidation = False
        '03_11_2010   RAGAVA      CrossTube Condition Added
        Try
            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "Resize" _
                                        OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "NewDesign" _
                                                    AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Fabricated" _
                                                    AndAlso (ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual" OrElse ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Lathe") AndAlso (Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube")) _
                                         OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSizeType_RodEnd = "Custom" _
                                                     AndAlso ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd + _
                                                                  ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd) < 0.015)) _
                                         OrElse (Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity_RodEnd = 0 _
                                                        AndAlso ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated") Then

                WeldedPinHoleDrillingValidation = True

            End If

        Catch ex As Exception

        End Try

    End Function

    Private Function WCRulesId() As Double
        Dim strPinHoleDrillingRequired As String = "N"
        If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" AndAlso ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated") OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Drilled Pin Hole" Then       '03_11_2010    RAGAVA  Drilled Condition Added
            strPinHoleDrillingRequired = "Y"
            '03_11_2010   RAGAVA
        Else
            If ObjClsWeldedCylinderFunctionalClass.IsExact_NewDesign_Resize_RodEnd = "Resize" _
                                        OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesign_RodEnd = "NewDesign" _
                                                    AndAlso ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationDesignType_RodEnd = "Fabricated" _
                                                    AndAlso (ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual" OrElse ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Lathe") AndAlso (Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube")) _
                                         OrElse (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSizeType_RodEnd = "Custom" _
                                                     AndAlso ((ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd + _
                                                                  ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd) < 0.015)) _
                                         OrElse (Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BushingQuantity_RodEnd = 0 _
                                                        AndAlso ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated") Then

                strPinHoleDrillingRequired = "Y"
                'Till    Here
            End If
        End If
        WCRulesId = _oRodOperationsDMC.getWCRulesID(RodMaterial_RodEndConfiguration_HashTable(_strRodMaterial), _
                                                              RodMaterial_RodEndConfiguration_HashTable(_strRodEndConfiguration), _
                                                              strPinHoleDrillingRequired)

        '03_11_2010   RAGAVA    Safe Side
        Try
            If WCRulesId <= 0 Then
                WCRulesId = 1002
            End If
        Catch ex As Exception
        End Try
        'Till   Here

        Try
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Rod = WCRulesId.ToString.Substring(3, 1)        '23_09_2010   RAGAVA
        Catch ex As Exception

        End Try
    End Function

    Public Sub GetRulesOperationsSequence()
        Try

            ThreadedValidation()

            _dblWCRulesID = WCRulesId()
            'ANUP 27-09-2010 START
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RulesID_Rod = _dblWCRulesID
            'ANUP 27-09-2010 TILL HERE
            _dblWCOperations = _oRodOperationsDMC.getWCOperations(_dblWCRulesID)

            If Not IsNothing(_dblWCOperations) Then
                For Each oOperations As DataRow In _dblWCOperations.Rows
                    If oOperations(0).ToString.Equals("Cutting") Then
                        _oRodOperations.CuttingFunctionality()
                    ElseIf oOperations(0).ToString.Equals("Drilling") Then
                        _oRodOperations.DrillingFunctionality(_dblWCRulesID, _oExcelSheet_DrillingOne, _oExcelSheet_DrillingTwo)
                    ElseIf oOperations(0).ToString.Equals("LatheWelding") Then
                        If ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Lathe" Then          '15_10_2010    RAGAVA
                            _oRodOperations.LatheWeldingFunctionality()
                        End If
                    ElseIf oOperations(0).ToString.Equals("ManualWelding_One") Then
                        If ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual" Then          '15_10_2010    RAGAVA
                            _oRodOperations.ManualWeldingFunctionality_One()
                        End If
                    ElseIf oOperations(0).ToString.Equals("ManualWelding_Two") Then
                        If ObjClsWeldedCylinderFunctionalClass.strManual_Lathe = "Manual" Then          '15_10_2010    RAGAVA
                            _oRodOperations.ManualWeldingFunctionality_Two()
                        End If
                    ElseIf oOperations(0).ToString.Equals("Machining") Then
                        _oRodOperations.MachiningFunctionality()
                    End If
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
