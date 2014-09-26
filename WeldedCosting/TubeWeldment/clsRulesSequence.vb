Public Class clsRulesSequence

#Region "Private Variables"

    Private _dblWCRulesID As Double

    Private _oOperationsDMC As clsOperationDMC

    Private _oOperations As clsOperations

    Private _strDesignType As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType

    Private _strCylinderDesignType As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CylinderHeadDesign

    Private _strTubeMaterial As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeMaterial

    Private _strCasting_Fabrication As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType


#End Region

#Region "Public Properties"

    Public Property ObjOperations() As clsOperations
        Get
            Return _oOperations
        End Get
        Set(ByVal value As clsOperations)
            _oOperations = value
        End Set
    End Property

#End Region

#Region "Sub Procedures "

    Public Sub New()
        _oOperationsDMC = New clsOperationDMC
        _oOperations = New clsOperations
        getRulesOperationsSequence()
    End Sub

    Private Sub getRulesOperationsSequence()
        Dim intOneorTwoPiece As Integer
        intOneorTwoPiece = 2
        If Not IsNothing(_strCasting_Fabrication) Then
            If _strCasting_Fabrication.ToLower = "cast" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Plate Clevis" Then            '03_11_2010    RAGAVA  Plate Clevis Condition Added
                intOneorTwoPiece = 1
            End If
        End If
        _dblWCRulesID = _oOperationsDMC.getWCRuledID(_strDesignType, _strCylinderDesignType, _strTubeMaterial, intOneorTwoPiece)

        '03_11_2010  RAGAVA     Safe Side
        Try
            If _dblWCRulesID <= 0 Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
                    _dblWCRulesID = 1009
                Else
                    _dblWCRulesID = 1005
                End If
            End If
        Catch ex As Exception
        End Try
        'Till   Here

        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeRuleId = _dblWCRulesID       '01_10_2010   RAGAVA
        Try
            If _dblWCRulesID > 9 Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = _dblWCRulesID.ToString.Substring(2, 2)        '23_09_2010   RAGAVA
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = _dblWCRulesID.ToString.Substring(3, 1)        '23_09_2010   RAGAVA
            End If
        Catch ex As Exception

        End Try
        Dim oRulesOperations As DataTable = _oOperationsDMC.getWCRulesOperations(_dblWCRulesID)
        If Not IsNothing(oRulesOperations) Then
            For Each oOperations As DataRow In oRulesOperations.Rows
                If oOperations(0).ToString.Equals("Cutting") Then
                    _oOperations.CuttingFunctionality()
                ElseIf oOperations(0).ToString.StartsWith("Drilling") = True Then   '01_03_2012   RAGAVA
                    _oOperations.DrillingFunctionality()
                ElseIf oOperations(0).ToString.Equals("Threading (Standard buttress or UN)") Then
                    _oOperations.ThreadingFunctionality()
                ElseIf oOperations(0).ToString.StartsWith("Skiving") = True Then    '01_03_2012   RAGAVA
                    _oOperations.SkivingFunctionality()
                ElseIf oOperations(0).ToString.Equals("LatheWelding") Then
                    _oOperations.LatheWeldingFunctionality()
                ElseIf oOperations(0).ToString.Equals("RobotWelding") Then
                    _oOperations.RobotWeldingFunctionality()
                ElseIf oOperations(0).ToString.Equals("ManualWelding") Then
                    _oOperations.ManualWeldingFunctionality()
                ElseIf oOperations(0).ToString.StartsWith("Port Welding") = True Then       '01_03_2012   RAGAVA
                    _oOperations.PortWeldingFunctionality()
                ElseIf oOperations(0).ToString.Equals("Pin Drilling") Then
                    _oOperations.PinHoleFunctionality()
                ElseIf oOperations(0).ToString.Equals("Port Plugging") Then
                    _oOperations.PortPluggingFunctionality()
                    '01_10_2010   RAGAVA
                ElseIf oOperations(0).ToString.Equals("Welding") Then
                    _oOperations.WeldingFunctionality()
                    'Till   Here
                    '03_11_2010   RAGAVA
                ElseIf oOperations(0).ToString.Equals("Grooving (for RR tubes)") Then
                    _oOperations.GroovingFunctionality()
                End If
            Next
        End If
    End Sub

#End Region

End Class
