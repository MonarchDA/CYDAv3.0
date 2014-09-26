Public Class clsFindCastingCost

#Region "Private Variables"

    Private _dblBoreDiameter As Double '*

    Private _dblRodDiameter As Double

    Private _dblPinHoleDiameter As Double '*

    Private _strPortSize As String '*

    Private _dblMaterialWeight As Double

    Private Const MATERIALTYPE As String = "WCB"

    Private _dblUpperTolerance As Double '*

    Private _dblLowerTolerance As Double '*

    Private _blnIsPortIntegral As Boolean

    Private _strCastingType As String '*

    Private _oWeldedCostingDataBaseClass As clsWeldedCostingDataBaseClass

    Private _blnBaseEnd As Boolean

#End Region


#Region "Subs"


    Public Sub New(ByVal blnBaseEnd As Boolean)
        _oWeldedCostingDataBaseClass = New clsWeldedCostingDataBaseClass
        _blnBaseEnd = blnBaseEnd
        DefaultValues()
    End Sub

    Private Sub DefaultValues()
        _dblBoreDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter
        _dblRodDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter
        If _blnBaseEnd Then
            _strPortSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_BaseEnd
            _dblUpperTolerance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit
            _dblLowerTolerance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit
            _dblPinHoleDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize
            _strCastingType = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration
            _dblMaterialWeight = ObjClsWeldedCylinderFunctionalClass.BaseEndWeight
            If ObjClsWeldedCylinderFunctionalClass.IsPortIntegral_or_PortInTube = "Port Integral" Then
                _blnIsPortIntegral = True
            Else
                _blnIsPortIntegral = False
            End If
        Else
            _strPortSize = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortSize_RodEnd
            _dblUpperTolerance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceUpperLimit_RodEnd
            _dblLowerTolerance = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ToleranceLowerLimit_RodEnd
            _dblPinHoleDiameter = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleSize_RodEnd
            _strCastingType = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration
            _dblMaterialWeight = ObjClsWeldedCylinderFunctionalClass.RodEndWeight
        End If
    End Sub

    Public Function GetCost() As Double
        Dim dblBaseCost As Double
        If _blnBaseEnd Then
            dblBaseCost = _oWeldedCostingDataBaseClass.GetBaseMachiningCost(_dblBoreDiameter)
        Else
            dblBaseCost = _oWeldedCostingDataBaseClass.GetRodMachiningCost(_dblRodDiameter)
        End If
        GetCost = dblBaseCost + FindPinCost() + GetPortCost() + GetMaterialCost()
    End Function

    Private Function FindPinCost() As Double
        Dim dblTolerace As Double = _dblUpperTolerance + _dblLowerTolerance
        If dblTolerace <= 0.005 Then
            dblTolerace = 0.005
        ElseIf dblTolerace <= 0.01 Then
            dblTolerace = 0.01
        Else
            dblTolerace = 0.015
        End If

        Dim dblPinHoleCost As Double
        Dim strPinHoleType As String

        If _blnBaseEnd Then
            strPinHoleType = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType
        Else
            strPinHoleType = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinHoleType_RodEnd
        End If

        If strPinHoleType = "PH" Then
            dblPinHoleCost = _oWeldedCostingDataBaseClass.GetPinHoleMachiningCost(Math.Round(_dblPinHoleDiameter - 0.015), _strCastingType, dblTolerace)
        Else
            dblPinHoleCost = _oWeldedCostingDataBaseClass.GetPinHoleMachiningCost(_dblPinHoleDiameter, _strCastingType, dblTolerace)
        End If
        Return dblPinHoleCost
    End Function

    Private Function GetPortCost() As Double
        If _blnIsPortIntegral Then
            Return _oWeldedCostingDataBaseClass.GetPortMachiningCost(_strPortSize)
        Else
            Return 0
        End If
    End Function

    Private Function GetMaterialCost() As Double
        Return _oWeldedCostingDataBaseClass.GetMaterialCost(_dblMaterialWeight, MATERIALTYPE)
    End Function

#End Region

End Class
