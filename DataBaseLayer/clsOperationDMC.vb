Public Class clsOperationDMC

#Region "Private Variables "

    Private _strQuery As String

    Private _strErrorMessage As String

#End Region

#Region "Public Functions "

    Public Function getWorkCenterDetails(ByVal strWorkStation As String) As DataRow
        Try
            getWorkCenterDetails = Nothing
            _strQuery = "select * from Welded.WorkCenterRates where WorkStation = '" + strWorkStation + "'"
            getWorkCenterDetails = MonarchConnectionObject.GetDataRow(_strQuery)
            If IsNothing(getWorkCenterDetails) OrElse getWorkCenterDetails.ItemArray.Length <= 0 Then
                getWorkCenterDetails = Nothing
                _strErrorMessage = "Error occured while retrieving data from Welded.WorkCenterRates" + vbCrLf
            End If

        Catch ex As Exception

        End Try
    End Function

    Public Function getCuttingStandardCost(ByVal strStrokeLength As String, ByVal strColumnName As String) As Double
        Try
            getCuttingStandardCost = Nothing
            _strQuery = "select  " + strColumnName + "  from Welded.WCCuttingDetails where StrokeLength =  '" + strStrokeLength + "'"
            getCuttingStandardCost = MonarchConnectionObject.GetValue(_strQuery)
            If IsNothing(getCuttingStandardCost) Then
                getCuttingStandardCost = 0
                _strErrorMessage = "Error occured while retrieving data from Welded.WorkCenterRates" + vbCrLf
            End If

        Catch ex As Exception

        End Try
    End Function

    Public Function getDrillingStandardCost(ByVal strStrokeLength As String, ByVal strColumnName As String) As Double
        Try
            getDrillingStandardCost = Nothing

            '01_03_2012  RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked = True Then
                _strQuery = "select  " + strColumnName + "  from WCDrilling_Rephasing where StrokeLength =  '" + strStrokeLength + "'"
            Else
                _strQuery = "select  " + strColumnName + "  from Welded.WCDrillingDetails where StrokeLength =  '" + strStrokeLength + "'"
            End If
            'Till  Here

            getDrillingStandardCost = MonarchConnectionObject.GetValue(_strQuery)
            If IsNothing(getDrillingStandardCost) Then
                getDrillingStandardCost = 0
                _strErrorMessage = "Error occured while retrieving data from Welded.WCDrillingDetails" + vbCrLf
            End If
        Catch ex As Exception

        End Try
       
    End Function

    '07_12_2010    RAGAVA
    Public Function getGrooveDetailsStandardCost(ByVal strStrokeLength As String, ByVal strColumnName As String) As Double
        Try
            getGrooveDetailsStandardCost = Nothing
            _strQuery = "select  " + strColumnName + "  from Welded.WCGroovingDetails where StrokeLength =  '" + strStrokeLength + "'"
            getGrooveDetailsStandardCost = MonarchConnectionObject.GetValue(_strQuery)
            If IsNothing(getGrooveDetailsStandardCost) Then
                getGrooveDetailsStandardCost = 0
                _strErrorMessage = "Error occured while retrieving data from Welded.WCGroovingDetails" + vbCrLf
            End If
        Catch ex As Exception
        End Try
    End Function

    Public Function getThreadedDetailsStandardCost(ByVal strStrokeLength As String, ByVal strColumnName As String) As Double
        getThreadedDetailsStandardCost = Nothing
        _strQuery = "select  " + strColumnName + "  from Welded.WCThreadedDetails where StrokeLength =  '" + strStrokeLength + "'"
        getThreadedDetailsStandardCost = MonarchConnectionObject.GetValue(_strQuery)
        If IsNothing(getThreadedDetailsStandardCost) Then
            getThreadedDetailsStandardCost = 0
            _strErrorMessage = "Error occured while retrieving data from Welded.WCThreadedDetails" + vbCrLf
        End If
    End Function

    Public Function getSkivingDetailsStandardCost(ByVal strStrokeLength As String, ByVal strColumnName As String) As Double
        Try
            getSkivingDetailsStandardCost = Nothing
            '01_03_2012  RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked = True Then
                _strQuery = "select  " + strColumnName + "  from WCSkiving_Rephasing where StrokeLength =  '" + strStrokeLength + "'"
            Else
                _strQuery = "select  " + strColumnName + "  from Welded.WCSkiving where StrokeLength =  '" + strStrokeLength + "'"
            End If
            'Till  Here
            getSkivingDetailsStandardCost = MonarchConnectionObject.GetValue(_strQuery)
            If IsNothing(getSkivingDetailsStandardCost) Then
                getSkivingDetailsStandardCost = 0
                _strErrorMessage = "Error occured while retrieving data from Welded.WCSkiving" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function getLatheWeldingDetailsStandardCost(ByVal strBoreDimater As String, ByVal strStrokeLength As String) As Double
        Try
            getLatheWeldingDetailsStandardCost = Nothing
            _strQuery = "select top 1 Cost from Welded.WCLatheWelding where  (" + strStrokeLength + " between MinimumLength and MaximumLength) and BoreDiameter >= " + strBoreDimater
            getLatheWeldingDetailsStandardCost = MonarchConnectionObject.GetValue(_strQuery)
            If IsNothing(getLatheWeldingDetailsStandardCost) Then
                getLatheWeldingDetailsStandardCost = 0
                _strErrorMessage = "Error occured while retrieving data from Welded.WCLatheWelding" + vbCrLf
            End If

        Catch ex As Exception

        End Try
    End Function

    Public Function getRobotWeldingDetailsStandardCost(ByVal strBoreDimater As String, ByVal strStrokeLength As String) As Double
        Try
            getRobotWeldingDetailsStandardCost = Nothing
            _strQuery = " select top 1 Cost from Welded.WCRobotWeldng where  (" + strStrokeLength + "  between MinimumLength and MaximumLength) and (" + strBoreDimater + "   between MinimumBoreDiameter and MaximumBoreDiameter) "
            getRobotWeldingDetailsStandardCost = MonarchConnectionObject.GetValue(_strQuery)
            If IsNothing(getRobotWeldingDetailsStandardCost) Then
                getRobotWeldingDetailsStandardCost = 0
                _strErrorMessage = "Error occured while retrieving data from Welded.WCRobotWeldng" + vbCrLf
            End If

        Catch ex As Exception

        End Try
    End Function

    Public Function getManualWeldingDetailsStandardCost(ByVal strBoreDimater As String, ByVal strStrokeLength As String, ByVal strWeldSize As String) As Double
        Try
            getManualWeldingDetailsStandardCost = Nothing
            _strQuery = " select top 1 cost from Welded.WCManualLugWelding where  (" + strStrokeLength + "  between MinimumLength and MaximumLength) and (" + strBoreDimater + "  between MinimumBoreDiameter and MaximumBoreDiameter) and (" + strWeldSize + "  between MinimumWeldSize and MaximumWeldSize)"
            getManualWeldingDetailsStandardCost = MonarchConnectionObject.GetValue(_strQuery)
            If IsNothing(getManualWeldingDetailsStandardCost) Then
                getManualWeldingDetailsStandardCost = 0
                _strErrorMessage = "Error occured while retrieving data from Welded.WCManualLugWelding" + vbCrLf
            End If

        Catch ex As Exception

        End Try
    End Function

    Public Function getPortWeldingDetailsStandardCost(ByVal strStrokeLength As String, ByVal strNoOfPorts As String) As Double
        Try
            getPortWeldingDetailsStandardCost = Nothing
            _strQuery = "select top 1 cost from Welded.WCPortWelding where (" + strStrokeLength + "  between MinimumLength and MaximumLength) and NumberOFPorts = " + strNoOfPorts + ""
            getPortWeldingDetailsStandardCost = MonarchConnectionObject.GetValue(_strQuery)
            If IsNothing(getPortWeldingDetailsStandardCost) Then
                getPortWeldingDetailsStandardCost = 0
                _strErrorMessage = "Error occured while retrieving data from Welded.WCPortWelding" + vbCrLf
            End If

        Catch ex As Exception

        End Try
    End Function

    Public Function getPinHoleDetailsStandardCost(ByVal strPartWeight As String, ByVal strPinHoleSize As String) As Double
        Try
            getPinHoleDetailsStandardCost = Nothing
            _strQuery = "   select top 1 standardcost from Welded.WCPinHoleDetails where (" + strPartWeight + "  between MinimumPartWeight and MaximumPartWeight) and (" + strPinHoleSize + " between MinimumPinHoleSize and MaximumPinHoleSize)"
            getPinHoleDetailsStandardCost = MonarchConnectionObject.GetValue(_strQuery)
            If IsNothing(getPinHoleDetailsStandardCost) Then
                getPinHoleDetailsStandardCost = 0
                _strErrorMessage = "Error occured while retrieving data from Welded.WCPortWelding" + vbCrLf
            End If

        Catch ex As Exception

        End Try
    End Function

    Public Function getPortPluggingCost(ByVal strStrokeLength As String, ByVal strColumnName As String, ByVal blnValue As Boolean) As Double
        Try
            getPortPluggingCost = Nothing
            If blnValue Then
                _strQuery = "select  " + strColumnName + "  from Welded.WCPortPluggingOne90deg where StrokeLength =  '" + strStrokeLength + "'"
            Else
                _strQuery = "select  " + strColumnName + "  from Welded.WCPortPluggingTwo90deg where StrokeLength =  '" + strStrokeLength + "'"
            End If
            getPortPluggingCost = MonarchConnectionObject.GetValue(_strQuery)
            If IsNothing(getPortPluggingCost) Then
                getPortPluggingCost = 0
                _strErrorMessage = "Error occured while retrieving data from Welded.WCPortPluggingOne90deg or Welded.WCPortPluggingTwo90deg " + vbCrLf
            End If

        Catch ex As Exception

        End Try
    End Function

    Public Function getWCRuledID(ByVal strDesignType As String, ByVal strCylinderHeadType As String, ByVal strTubeMaterial As String, ByVal intOneOrTwoPiece As Integer) As Double
        Try
            getWCRuledID = Nothing
            _strQuery = "select * from Welded.WCRules where DesignType = '" + strDesignType + "' and CylinderHeadType = '" + strCylinderHeadType + "' and TubeMaterial = '" + strTubeMaterial + "' and OneOrTwoPieceBaseEnd = " + intOneOrTwoPiece.ToString
            If ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.chkRephasing.Checked = True Then
                _strQuery = _strQuery & " and Rephasing = 'Y'"
            End If
            getWCRuledID = MonarchConnectionObject.GetValue(_strQuery)
            If IsNothing(getWCRuledID) Then
                getWCRuledID = 0
                _strErrorMessage = "Error occured while retrieving data from Welded.WCRules" + vbCrLf
            End If

        Catch ex As Exception

        End Try
    End Function

    Public Function getWCRulesOperations(ByVal strRuledID As String) As DataTable
        Try
            getWCRulesOperations = Nothing
            If Val(strRuledID) > 8 Then     '01_10_2010  RAGAVA
                _strQuery = "select Wco.Operations from Welded.WCOperations wco,(select Operations from Welded.WCRulesOperation where Rules = '" + strRuledID + "')  wcro where wcro.Operations = wco.IFLID"      '01_10_2010  RAGAVA
            Else
                _strQuery = "select Operations from Welded.WCOperations where IFLID in(select Operations from  Welded.WCRulesOperation where Rules = " + strRuledID + " )"
            End If
            getWCRulesOperations = MonarchConnectionObject.GetTable(_strQuery)
            If IsNothing(getWCRulesOperations) OrElse getWCRulesOperations.Rows.Count < 1 Then
                getWCRulesOperations = Nothing
                _strErrorMessage = "Error occured while retrieving data from Welded.WCRulesOperation" + vbCrLf
            End If

        Catch ex As Exception

        End Try
    End Function

    'ANUP 04-10-2010 START 
    Public Function getHeadWeldingCost(ByVal dblTubeDiameter As Double, ByVal strTubeLengthColoumnName As String) As Double
        Try
            If dblTubeDiameter <= 2 Then
                _strQuery = "select " + strTubeLengthColoumnName + " from Welded.WCWelding where TubeDiameter <= 2 "
            Else
                _strQuery = "select " + strTubeLengthColoumnName + " from Welded.WCWelding where TubeDiameter = " + dblTubeDiameter.ToString
            End If

            getHeadWeldingCost = MonarchConnectionObject.GetValue(_strQuery)
            If getHeadWeldingCost = 0 Then
                _strErrorMessage = "Error occured while retrieving data from Welded.WCWelding" + vbCrLf
            End If

        Catch ex As Exception

        End Try
    End Function
    'ANUP 04-09-2010 TILL HERE

#End Region

End Class
