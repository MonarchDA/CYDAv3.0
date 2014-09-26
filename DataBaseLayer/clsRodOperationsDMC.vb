Public Class clsRodOperationsDMC

#Region "Private Variables "
    Private _strQuery As String
    Private _strErrorMessage As String
#End Region

#Region "Public Functions"

    Public Function getWCOperations(ByVal dblRulesId As Double) As DataTable
        getWCOperations = Nothing
        Try
            Dim strQuery2 As String = "select Operations from Welded.WCRulesOperation_Rod where Rules = " + dblRulesId.ToString
            _strQuery = "select Operations from Welded.WCOperations_Rod where IFLID in (" + strQuery2 + ")"
            getWCOperations = MonarchConnectionObject.GetTable(_strQuery)

            If IsNothing(getWCOperations) OrElse getWCOperations.Rows.Count <= 0 Then
                getWCOperations = Nothing
                _strErrorMessage = "Error occured while retrieving data from Welded.WCOperations_Rod" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function getWCRulesID(ByVal strRodMaterial As String, ByVal strRodEndConfiguration As String, ByVal strPinHoledrillingRequired As String) As Double
        Try
            _strQuery = "select IFLID from Welded.WCRules_Rod where Material = '" + strRodMaterial + "' and EndCondition = '" + strRodEndConfiguration + "'  and PinHoleDrillingRequired = '" + strPinHoledrillingRequired + "'"
            getWCRulesID = MonarchConnectionObject.GetValue(_strQuery)

            If IsNothing(getWCRulesID) Then
                getWCRulesID = 0
                _strErrorMessage = "Error occured while retrieving data from Welded.WCRules_Rod" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function getWorkCenterDetails(ByVal strWorkStation As String) As DataRow
        getWorkCenterDetails = Nothing
        Try

            _strQuery = "select * from Welded.WorkCenterRates where WorkStation = '" + strWorkStation + "'"
            getWorkCenterDetails = MonarchConnectionObject.GetDataRow(_strQuery)
            If IsNothing(getWorkCenterDetails) OrElse getWorkCenterDetails.ItemArray.Length <= 0 Then
                getWorkCenterDetails = Nothing
                _strErrorMessage = "Error occured while retrieving data from Welded.WorkCenterRates" + vbCrLf
            End If

        Catch ex As Exception

        End Try
    End Function

    Public Function getCuttingStandardCost(ByVal strRodLength As String, ByVal strColumnName As String, ByVal strTableName As String) As Double
        getCuttingStandardCost = Nothing
        Try

            _strQuery = "select  " + strColumnName + "  from " + strTableName + " where RodLength =  '" + strRodLength + "'"
            getCuttingStandardCost = MonarchConnectionObject.GetValue(_strQuery)
            If IsNothing(getCuttingStandardCost) Then
                getCuttingStandardCost = 0
                _strErrorMessage = "Error occured while retrieving data from Welded.WorkCenterRates" + vbCrLf
            End If

        Catch ex As Exception

        End Try
    End Function

    Public Function getMachiningStandardCost(ByVal strRodLength As String, ByVal strColumnName As String, ByVal strTableName As String) As Double
        getMachiningStandardCost = Nothing
        Try

            _strQuery = "select  " + strColumnName + "  from " + strTableName + " where RodLength =  '" + strRodLength + "'"
            getMachiningStandardCost = MonarchConnectionObject.GetValue(_strQuery)
            If IsNothing(getMachiningStandardCost) Then
                getMachiningStandardCost = 0
                _strErrorMessage = "Error occured while retrieving data from Welded.WorkCenterRates" + vbCrLf
            End If

        Catch ex As Exception

        End Try
    End Function

    Public Function getArcTime_CastingTable(ByVal dblRodDiameter As Double, ByVal dblWeldSize As Double) As Double
        Try

            _strQuery = "select top 1 ArcTime from Welded.REWeldSizeDetails_Casting where RodDiameter = " + dblRodDiameter.ToString + " and WeldSizeNumeric >= " + dblWeldSize.ToString        '12_10_2010   RAGAVA
            getArcTime_CastingTable = MonarchConnectionObject.GetValue(_strQuery)
            If IsNothing(getArcTime_CastingTable) Then
                getArcTime_CastingTable = 0
                _strErrorMessage = "Error occured while retrieving data from Welded.REWeldSizeDetails_Casting" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function getArcTime_LatheULugTable(ByVal dblRodDiameter As Double, ByVal dblWeldSize As Double) As Double
        Try

            _strQuery = "select ArcTime from Welded.REULug_LatheWeldDetails where RodDiameter = " + dblRodDiameter.ToString + " and WeldSize >= " + dblWeldSize.ToString       '12_10_2010   RAGAVA



            getArcTime_LatheULugTable = MonarchConnectionObject.GetValue(_strQuery)
            If IsNothing(getArcTime_LatheULugTable) Then
                getArcTime_LatheULugTable = 0
                _strErrorMessage = "Error occured while retrieving data from Welded.REULug_LatheWeldDetails" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function getNumberOfPasses_ManualULugTable(ByVal dblRodDiameter As Double, ByVal dblWeldSize As Double) As Double
        Try

            _strQuery = "select NumberOfPasses from Welded.REULug_ManualWeldDetails where RodDiameter = " + dblRodDiameter.ToString + " and WeldSizeNumeric = " + dblWeldSize.ToString
            getnumberOfPasses_ManualULugTable = MonarchConnectionObject.GetValue(_strQuery)
            If IsNothing(getnumberOfPasses_ManualULugTable) Then
                getnumberOfPasses_ManualULugTable = 0
                _strErrorMessage = "Error occured while retrieving data from Welded.REULug_ManualWeldDetails" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function getNumberOfPasses_ManualCrossTubeTable(ByVal dblRodDiameter As Double, ByVal dblWeldSize As Double) As Double
        Try

            _strQuery = "select NumberOfPasses from dbo.RECT_ManualWeldDetails where RodDiameter = " + dblRodDiameter.ToString + " and WeldSizeNumeric = " + dblWeldSize.ToString
            getNumberOfPasses_ManualCrossTubeTable = MonarchConnectionObject.GetValue(_strQuery)
            If IsNothing(getNumberOfPasses_ManualCrossTubeTable) Then
                getNumberOfPasses_ManualCrossTubeTable = 0
                _strErrorMessage = "Error occured while retrieving data from Welded.RECT_ManualWeldDetails" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function

#End Region


End Class
