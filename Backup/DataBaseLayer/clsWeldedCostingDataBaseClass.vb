
Public Class clsWeldedCostingDataBaseClass

    Private _strQuery As String

    Public Function GetBaseMachiningCost(ByVal dblBoreDiameter As Double) As Double
        Try
            _strQuery = "select Cost from Welded.BaseMachiningCost where BoreDiameter = " + dblBoreDiameter.ToString
            GetBaseMachiningCost = MonarchConnectionObject.GetValue(_strQuery)
        Catch ex As Exception

        End Try
    End Function

    Public Function GetRodMachiningCost(ByVal dblRodDiameter As Double) As Double
        Try
            _strQuery = "select top 1 Cost from RodMechiningCost where RodDaimeter >= " + dblRodDiameter.ToString
            GetRodMachiningCost = MonarchConnectionObject.GetValue(_strQuery)
        Catch ex As Exception

        End Try
    End Function

    Public Function GetPinHoleMachiningCost(ByVal dblPinHoleDiameter As Double, ByVal strCastingType As String, ByVal dblTolerance As Double) As Double
        Try
            _strQuery = "select Cost from Welded.PinHoleMachiningCost where PinHoleDiameter = " + dblPinHoleDiameter.ToString + " and CastingType = '" + strCastingType + "' and Tolerance = " + dblTolerance.ToString
            GetPinHoleMachiningCost = MonarchConnectionObject.GetValue(_strQuery)
        Catch ex As Exception

        End Try
    End Function

    Public Function GetPortMachiningCost(ByVal strPortSize As String) As Double
        Try
            _strQuery = "select Cost from Welded.PortMachiningCost where PortSize = '" + strPortSize + "'"
            GetPortMachiningCost = MonarchConnectionObject.GetValue(_strQuery)
        Catch ex As Exception

        End Try
    End Function

    Public Function GetMaterialCost(ByVal dblWeight As Double, ByVal strMaterialType As String) As Double
        Try
            _strQuery = "select Cost from Welded.MaterialCost where MaterialType = '" + strMaterialType + "' and '" + dblWeight.ToString + "' between MinWeight and MaxWeight"
            GetMaterialCost = MonarchConnectionObject.GetValue(_strQuery)
        Catch ex As Exception

        End Try
    End Function

    Public Function GetMaterialCode(ByVal strLugThickness As String, ByVal strLugWidth As String) As String
        GetMaterialCode = Nothing
        Try
            _strQuery = "select MaterialCode from LugDesignDetails where LugThickness = " + Math.Round(Val(strLugThickness) + 0.005, 2).ToString + " and LugWidth = " + strLugWidth + ""
            GetMaterialCode = MonarchConnectionObject.GetValue(_strQuery)
            If IsNothing(GetMaterialCode) Then
                GetMaterialCode = Nothing
            End If
        Catch ex As Exception

        End Try
    End Function

End Class
