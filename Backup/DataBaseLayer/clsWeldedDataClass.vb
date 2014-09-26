Imports IFLBaseDataLayer
Imports IFLCommonLayer
Public Class clsWeldedDataClass

#Region "Class Variables"

    Private _strQuery As String

    Private _strErrorMessage As String

#End Region

#Region "Properties"

    Public Property ErrorMessage() As String
        Get
            Return _strErrorMessage
        End Get
        Set(ByVal value As String)
            _strErrorMessage = value
        End Set
    End Property

#End Region

#Region "SubProcedures"

    'TODO: ANUP 28-04-2010 10.39am ALSO ADDED XML FILE IN DEBUG
    'Public Sub SetConnectionObject()
    '    ' MonarchConnectionObject = IFLConnectionClass.GetConnectionObject("M724-CAD\SQLEXPRESS", "MIL_WELDED", "System.Data.SqlClient", , , True)
    '    'MonarchConnectionObject = IFLConnectionClass.GetConnectionObject("IEGHPDCWS106\SQLEXPRESS", "MIL_WELDED", "System.Data.SqlClient", , , True)
    'End Sub

    Public Function GetConnection() As Boolean
        GetConnection = False
        Try
            Dim strXMLFilePath As String = System.Environment.CurrentDirectory + "\MILWeldedConnection.xml"
            Dim oDataSet As New DataSet
            oDataSet.ReadXml(strXMLFilePath)
            If Not oDataSet.Tables.Count <= 0 Then
                Dim strServer As String = oDataSet.Tables(0).Rows(0).Item(0).ToString
                Dim strDataBase As String = oDataSet.Tables(0).Rows(0).Item(1).ToString
                MonarchConnectionObject = IFLBaseDataLayer.IFLConnectionClass.GetConnectionObject(strServer, strDataBase, "System.Data.SqlClient", "", "", "SSPI")
                GetConnection = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error occured while connecting to server", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button3)
        End Try
    End Function
    '************************

#End Region


#Region "Functions"

    '13_11_2009   Ragava
    Public Function GetTableDetails(ByVal strQuery As String) As DataTable
        GetTableDetails = Nothing
        Try
            Dim Objdt As DataTable
            _strQuery = strQuery
            Objdt = MonarchConnectionObject.GetTable(_strQuery)
            Return Objdt
        Catch ex As Exception
        End Try
    End Function

    Public Function GetPistonNutSize_Bore(ByVal strBoreDiameter As String) As Double
        GetPistonNutSize_Bore = 0
        _strQuery = "SELECT DISTINCT(PistonNutSize) FROM WELDED.TubeDetails WHERE BOREDIAMETER=" + strBoreDiameter
        GetPistonNutSize_Bore = MonarchConnectionObject.GetValue(_strQuery)
        If GetPistonNutSize_Bore = 0 Then
            GetPistonNutSize_Bore = 0
            _strErrorMessage = "Data not retrieved from TubeDetails table" + vbCrLf
            _strErrorMessage += "PistonNutSize not available for selected BoreDiameter"
        End If
    End Function

    Public Function GetRodDiameters(ByVal strBoreDiameter As String) As DataTable
        GetRodDiameters = Nothing
        _strQuery = " select RODDIAMETER, MaximumPistonNutSize from Welded.RodDiameterDetails where RodDiameter between (select RodDiameter_Min "
        _strQuery += "from Welded.RodDiameterRangeDetails where BoreDiameter = " + strBoreDiameter + ") and (select RodDiameter_Max "
        _strQuery += "from Welded.RodDiameterRangeDetails where BoreDiameter = " + strBoreDiameter + ")"
        GetRodDiameters = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetRodDiameters) OrElse GetRodDiameters.Rows.Count = 0 Then
            GetRodDiameters = Nothing
            _strErrorMessage = "Data not retrieved from RodDiameterDetails table" + vbCrLf
            _strErrorMessage += "RodDiameter and MaximumPistonNutSize not available for seleted BoreDiameter"
        End If
    End Function

    Public Function GetClass() As DataTable
        GetClass = Nothing
        _strQuery = "SELECT LIFECYCLECLASS FROM WELDED.LIFECYCLEDETAILS"
        GetClass = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetClass) OrElse GetClass.Rows.Count = 0 Then
            GetClass = Nothing
            _strErrorMessage = "Data not retrieved from LifeCycleDetails table" + vbCrLf
        End If
    End Function

    Public Function GetThreadSizeValues(ByVal intCycle As Integer, ByVal dblDiameter As Double, ByVal dblPullupforce As Double) As DataTable
        GetThreadSizeValues = Nothing
        _strQuery = "select StressOfThreadAtRoot from welded.LifeCycleDetails where LifeCycleClass =" + intCycle.ToString
        Dim Area As Double = MonarchConnectionObject.GetValue(_strQuery)
        _strQuery = "select ThreadDiscription,ThreadValue from dbo.ThreadedRodDetails where ThreadValue <= " + dblDiameter.ToString + " and (" + dblPullupforce.ToString + "/ RootStressArea) <=" + Area.ToString
        GetThreadSizeValues = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetThreadSizeValues) OrElse GetThreadSizeValues.Rows.Count <= 0 Then
            GetThreadSizeValues = Nothing
            _strErrorMessage = "Data not retrieved from ThreadedRodDetails table" + vbCrLf
        End If

    End Function

    Public Function NutSafetyFactor(ByVal strSelectedClass As String) As DataRow
        NutSafetyFactor = Nothing
        _strQuery = "select * from Welded.LifeCycleDetails where LifeCycleClass = " + strSelectedClass
        NutSafetyFactor = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(NutSafetyFactor) OrElse NutSafetyFactor.ItemArray.Length <= 0 Then
            NutSafetyFactor = Nothing
            _strErrorMessage = "Data not retrieved from LifeCycleDetails table" + vbCrLf
        End If
    End Function

    Public Function GetRodMaterialCode(ByVal strRodDiameter As String) As DataRow
        GetRodMaterialCode = Nothing
        'ANUP 21-09-2010 START  just added RodMaterialCode_LION1000 
        _strQuery = "select RodMaterialCode_Crome, RodMaterialCode_NitroSteel, RodMaterialCode_LION1000 from WELDED.RODDIAMETERDETAILS where RodDiameter=" + strRodDiameter
        'ANUP 21-09-2010 TILL HERE
        GetRodMaterialCode = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetRodMaterialCode) OrElse GetRodMaterialCode.ItemArray.Length <= 0 Then
            GetRodMaterialCode = Nothing
            _strErrorMessage = "Data not retrieved from RodDiameterDetails table" + vbCrLf
            _strErrorMessage = "RodMaterialCode is not available in Table RodDiameterDetails for selected RodDiameter"
            '_strErrorMessage += MonarchConnectionObject.ErrorMessage
        End If
    End Function

    Public Function GetStopTubeCode(ByVal dblRodDiamter As Double, ByVal dblLowerStopTubeLength As Double, ByVal dblHigherStopTubeLength As Double) As DataTable
        GetStopTubeCode = Nothing
        _strQuery = "SELECT DrawingNumber, StopTubeCode, RodDiameter, StopTubeOD, StopTubeNominalWallThickness, StopTubeLength FROM Welded.StopTubeDetails"
        _strQuery += " WHERE RodDiameter=" + dblRodDiamter.ToString + " AND StopTubeLength BETWEEN " + dblLowerStopTubeLength.ToString + " AND " + dblHigherStopTubeLength.ToString
        GetStopTubeCode = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetStopTubeCode) OrElse GetStopTubeCode.Rows.Count <= 0 Then
            GetStopTubeCode = Nothing
            _strErrorMessage = "Data not retrieved from StopTubeDetails table" + vbCrLf
            _strErrorMessage = "StopTubeCode is not available in Table StopTubeDetails for selected RodDiameter and StopTubeLength"
            '_strErrorMessage += MonarchConnectionObject.ErrorMessage
        End If
    End Function

    Public Function GetThreadTensileArea() As DataTable
        GetThreadTensileArea = Nothing
        _strQuery = "SELECT NutSize,ThreadTensileArea FROM WELDED.NutDimensionDetails"
        GetThreadTensileArea = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetThreadTensileArea) OrElse GetThreadTensileArea.Rows.Count <= 0 Then
            GetThreadTensileArea = Nothing
            _strErrorMessage = "Data not retrieved from NutDimensionDetails table" + vbCrLf
            _strErrorMessage = "NutSize, ThreadTensileArea are not available in Table NutDimensionDetails"
            '_strErrorMessage += MonarchConnectionObject.ErrorMessage
        End If
    End Function

    '5_3_2010 Aruna

    Public Function GetPistonNutsizes(ByVal boreDiameter As String) As DataTable
        GetPistonNutsizes = Nothing
        _strQuery = "select  nutsize from welded.nutdimensionDetails where " + boreDiameter + ">=borediameter_min and " + boreDiameter + "<=borediameter_max"
        GetPistonNutsizes = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetThreadTensileArea) OrElse GetThreadTensileArea.Rows.Count <= 0 Then
            GetPistonNutsizes = Nothing
            _strErrorMessage = "Data not retrieved from NutDimensionDetails table" + vbCrLf
            _strErrorMessage = "NutSize, ThreadTensileArea are not available in Table NutDimensionDetails"
            '_strErrorMessage += MonarchConnectionObject.ErrorMessage
        End If
    End Function

    Public Function GetNutCodeAndThickness(ByVal strNutSize As String) As DataRow
        GetNutCodeAndThickness = Nothing
        _strQuery = "SELECT NutSize, NutCode, MaximumThickness,ActualThickness FROM WELDED.NutDimensionDetails WHERE NutSize=" + strNutSize
        GetNutCodeAndThickness = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetNutCodeAndThickness) OrElse GetNutCodeAndThickness.ItemArray.Length <= 0 Then
            GetNutCodeAndThickness = Nothing
            _strErrorMessage = "Data not retrieved from NutDimensionDetails table" + vbCrLf
            _strErrorMessage = "NutCode, MaximumThickness are not available in Table NutDimensionDetails for selected NutSize"
            '_strErrorMessage += MonarchConnectionObject.ErrorMessage
        End If
    End Function

    Public Function GetPistonDetails(ByVal strBoreDiameter As String, ByVal strSealType As String, ByVal strSingleWearRing As String, _
    ByVal strDoubleWearRing As String, ByVal strPistonConnection As String, ByVal strPistonShankSeal As String, ByVal strPistonNutSize As String) As DataTable
        GetPistonDetails = Nothing
        Try
            _strQuery = "SELECT IFLID, PistonCode, BoreDiameter, PistonNutSize, PistonWidth, CounterBoreDepth, MinDistanceFromRodSideToSealGrooveStart, "
            _strQuery += " MaxDistanceFromRodSideToSealGrooveEnd, " + strSealType + ", PistonConnection, PistonShankSeal, SingleWearRing, PistonDesign,DoubleWearRing,"
            _strQuery += " PistonODatSeal, PistonODatSeal_TOL_UL, PistonODatSeal_TOL_LL, SealGrooveDiameter, SealGrooveDiameter_TOL_UL, SealGrooveDiameter_TOL_LL, SealGrooveWidth, SealGrooveWidth_TOL_UL, SealGrooveWidth_TOL_LL,"
            _strQuery += " PistonODatWearRing, PistonODatWearRing_TOL_UL, PistonODatWearRing_TOL_LL, WearRingDiameter, WearRingDiameter_TOL_UL, WearRingDiameter_TOL_LL, WearRingWidth, WearRingWidth_TOL_UL, WearRingWidth_TOL_LL,Part_Type"
            _strQuery += " FROM Welded.PistonDetails WHERE BOREDIAMETER=" + strBoreDiameter + " AND PistonNutSize = " + strPistonNutSize
            _strQuery += " AND " + strSealType + " <> 'N/A' AND SingleWearRing " + strSingleWearRing + " AND DoubleWearRing" + strDoubleWearRing
            _strQuery += " AND PistonConnection='" + strPistonConnection + "' AND PistonShankSeal='" + strPistonShankSeal + "'"
            GetPistonDetails = MonarchConnectionObject.GetTable(_strQuery)
        Catch ex As Exception

        End Try
        If IsNothing(GetPistonDetails) OrElse GetPistonDetails.Rows.Count <= 0 Then
            GetPistonDetails = Nothing
            _strErrorMessage = "Data not retrieved from PistonDetails table" + vbCrLf
            _strErrorMessage += "PistonCode not available for selected values of BoreDiameter, SealType, WearRing ,PistonConnection and PistonShankSeal"
            '_strErrorMessage += MonarchConnectionObject.ErrorMessage
        End If
    End Function

    Public Function GetCylinderHeadDetails(ByVal strBoreDiameter As String, ByVal strRodDiameter As String, ByVal strHeadType As String, _
    ByVal strRodSeal As String, ByVal strRodWiperType As String, ByVal strSingleWearRing As String, ByVal strDoubleWearRing As String, _
    ByVal strWearRing As String, ByVal strStandardOrCompressed As String) As DataTable
        GetCylinderHeadDetails = Nothing
        Try
            _strQuery = "SELECT CylinderHeadCode, BoreDiameter, RodDiameter, HeadType, UCupRodSeal605, ZDeepRodMacroSeal, SingleWearRing"
            _strQuery += ", DoubleWearRing, Notes, SnapInRodWiper, ORing, BackUpRing,ShankLength,Overalllength, StaticSealPosition, StickOutFromTube, Part_Type FROM Welded.CylinderHeadDetails WHERE BoreDiameter =" + strBoreDiameter
            _strQuery += " AND RodDiameter=" + strRodDiameter + " AND HeadType = '" + strHeadType + "' AND " + strRodSeal + " <> 'N/A' AND"
            _strQuery += " " + strRodWiperType + " <> 'N/A' AND SingleWearRing " + strSingleWearRing + ""
            '_strQuery += " AND DoubleWearRing " + strDoubleWearRing + " AND Notes = '" + strWearRing + "' AND StandardOrCompressed ='" + strStandardOrCompressed + "'"
            _strQuery += " AND DoubleWearRing " + strDoubleWearRing + " AND StandardOrCompressed ='" + strStandardOrCompressed + "'"
            GetCylinderHeadDetails = MonarchConnectionObject.GetTable(_strQuery)
        Catch ex As Exception

        End Try
        If IsNothing(GetCylinderHeadDetails) OrElse GetCylinderHeadDetails.Rows.Count <= 0 Then
            GetCylinderHeadDetails = Nothing
            _strErrorMessage = "Data not retrieved from CylinderHeadDetails table" + vbCrLf
            _strErrorMessage += "CylinderHeadCode not available for selected values of BoreDiameter, RodDiameter, HeadType and WearRing"
            '_strErrorMessage += MonarchConnectionObject.ErrorMessage
        End If
    End Function

    Public Function InsertStopTubeDetails(ByVal strIFLID As String, ByVal strDrawingNumber As String, ByVal strStopTubeCode As String, ByVal strStopTubeDescription As String, _
    ByVal dblRodDiameter As Double, ByVal dblStopTubeOD As Double, ByVal dblStopTubeNominalWallThickness As Double, ByVal dblStopTubeLength As Double) As Boolean
        InsertStopTubeDetails = True
        _strQuery = "Insert into Welded.StopTubeDetails(IFLID,DrawingNumber,StopTubeCode,StopTubeDescription,RodDiameter,StopTubeOD,StopTubeNominalWallThickness,StopTubeLength)"
        _strQuery += "values(" + strIFLID + "," + strDrawingNumber + ",'" + strStopTubeCode + "','" + strStopTubeDescription + "'," + dblRodDiameter.ToString + "," _
        + dblStopTubeOD.ToString + "," + dblStopTubeNominalWallThickness.ToString + "," + dblStopTubeLength.ToString + ")"
        InsertStopTubeDetails = MonarchConnectionObject.ExecuteQuery(_strQuery)
        If Not InsertStopTubeDetails Then
            InsertStopTubeDetails = False
            _strErrorMessage = "Data not inserted into table StopTubeDetails" + vbCrLf
        End If
    End Function

    Public Function GetMaxStopTubeCode() As String
        _strQuery = "SELECT MAX(StopTubeCode) FROM Welded.StopTubeDetails"
        GetMaxStopTubeCode = MonarchConnectionObject.GetValue(_strQuery)
        If IsNothing(GetMaxStopTubeCode) Then
            GetMaxStopTubeCode = Nothing
            _strErrorMessage = "Data not retrieved from StopTubeDetails table" + vbCrLf
            '_strErrorMessage += MonarchConnectionObject.ErrorMessage
        End If
    End Function

    Public Function GetWallThickness(ByVal dblBoreDiameter As Double, ByVal dblWorkingPressure As Double, ByVal strClass As String) As DataTable
        GetWallThickness = Nothing
        _strQuery = "SELECT  BoreDiameter, WorkingPressure, TubeCode, TubeMaterial, TubeWallThickness, TubeOD, RodDiameter, " + strClass + ", IFLID "
        _strQuery += "FROM Welded.TubeDetails WHERE BoreDiameter = " + dblBoreDiameter.ToString + " AND WorkingPressure = "
        _strQuery += "(SELECT TOP 1 WorkingPressure FROM Welded.TubeDetails WHERE WorkingPressure >= " + dblWorkingPressure.ToString
        _strQuery += ") AND " + strClass + " <> 'N'"
        GetWallThickness = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetWallThickness) OrElse GetWallThickness.Rows.Count = 0 Then
            GetWallThickness = Nothing
            _strErrorMessage = "Data not retrieved from TubeDetails table" + vbCrLf
        End If
    End Function

    Public Function GetPinHoleSizes(ByVal strBoreDiameter As String) As DataTable
        GetPinHoleSizes = Nothing
        _strQuery = "SELECT DISTINCT(PinHole) FROM Welded.PinHoleDetails where BoreDiameter = " + strBoreDiameter
        GetPinHoleSizes = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetPinHoleSizes) OrElse GetPinHoleSizes.Rows.Count = 0 Then
            GetPinHoleSizes = Nothing
            _strErrorMessage = "Data not retrieved from PinHoleSizeDetails table" + vbCrLf
            '_strErrorMessage += MonarchConnectionObject.ErrorMessage
        End If
    End Function

    Public Function GetPinHoleDetails(ByVal strPinHoleSize As String) As DataRow
        GetPinHoleDetails = Nothing
        _strQuery = "SELECT NominalPinHoleSize, PinHoleDimension, ToleranceUpperLimit, ToleranceLowerLimit "
        _strQuery += "FROM Welded.PinHoleSizeDetails WHERE NominalPinHoleSize = " + strPinHoleSize
        GetPinHoleDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetPinHoleDetails) OrElse GetPinHoleDetails.ItemArray.Length <= 0 Then
            GetPinHoleDetails = Nothing
            _strErrorMessage = "Data not retrieved from PinHoleSizeDetails table" + vbCrLf
        End If
    End Function

    Public Function GetNominalPinHoleSize(ByVal PinHoleDimension As Double) As Double
        GetNominalPinHoleSize = Nothing
        _strQuery = "SELECT NominalPinHoleSize FROM Welded.PinHoleSizeDetails WHERE PinHoleDimension = " + PinHoleDimension.ToString
        GetNominalPinHoleSize = MonarchConnectionObject.GetValue(_strQuery)
        If GetNominalPinHoleSize = 0 Then
            _strErrorMessage = "Data not retrieved from PinHoleSizeDetails table" + vbCrLf
        End If
    End Function

    Public Function GetPortCode(ByVal dblTubeOD As Double, ByVal strPortOrientation As String, ByVal strPortType As String, ByVal strPortSize As String) As DataTable
        GetPortCode = Nothing
        dblTubeOD = ObjClsWeldedCylinderFunctionalClass.RoundUp(dblTubeOD, 2)
        _strQuery = "SELECT * FROM Welded.PortsAndWPDSDetails WHERE " + dblTubeOD.ToString + " BETWEEN MinimumTubeOD AND MaximumTubeOD "
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType.StartsWith("Rephasing") = True Then
            _strQuery += "AND PortOrientation = '" + strPortOrientation + "' AND PortType = '" + strPortType + "' AND PORT_SIZE = '" + strPortSize + "'  order by Port_Base"
        Else
            _strQuery += "AND PortOrientation = '" + strPortOrientation + "' AND PortType = '" + strPortType + "' AND PORT_SIZE = '" + strPortSize + "'"
        End If
        '_strQuery += "AND PortOrientation = '" + strPortOrientation + "' AND PortType = '" + strPortType + "' AND PORT_SIZE = '" + strPortSize + "'  order by Port_Base"
        GetPortCode = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetPortCode) OrElse GetPortCode.Rows.Count = 0 Then
            GetPortCode = Nothing
            _strErrorMessage = "Data not retrieved from PortsAndWPDSDetails table" + vbCrLf
            '_strErrorMessage += MonarchConnectionObject.ErrorMessage
        End If
    End Function

    Public Function GetOrificesSizes(ByVal portType As String, ByVal portSize As String) As DataTable '4_3_2010 Aruna Function modified
        GetOrificesSizes = Nothing
        _strQuery = "SELECT DISTINCT(OrificeSize) FROM Welded.PortLocators where portType='" + portType + "' and PortSize='" + portSize + "' And PortLocatorCode <> 'N/A'"
        GetOrificesSizes = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetOrificesSizes) OrElse GetOrificesSizes.Rows.Count = 0 Then
            GetOrificesSizes = Nothing
            _strErrorMessage = "Data not retrieved from PortLocators table" + vbCrLf
            '_strErrorMessage += MonarchConnectionObject.ErrorMessage
        End If
    End Function


    Public Function SetOrificesSizesDefault(ByVal portType As String, ByVal portSize As String) As DataRow '5_3_2010 Aruna Function modified
        SetOrificesSizesDefault = Nothing
        _strQuery = "SELECT DISTINCT(OrificeSize) FROM Welded.PortLocators where portType='" + portType + "' and PortSize='" + portSize + "' and DefaultValue='yes'"
        SetOrificesSizesDefault = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(SetOrificesSizesDefault) Then
            SetOrificesSizesDefault = Nothing
            _strErrorMessage = "Data not retrieved from PortLocators table" + vbCrLf
            '_strErrorMessage += MonarchConnectionObject.ErrorMessage
        End If
    End Function
    'TODO: OrificeOffSet Added
    Public Function GetPortLocatorCode(ByVal strOrificeSize As String, ByVal strPortSize As String, ByVal strPortType As String) As DataTable
        GetPortLocatorCode = Nothing
        _strQuery = "SELECT IFLID, PortSize, PortType, OrificeSize, PortLocatorCode, OrificeOffSet FROM Welded.PortLocators WHERE "
        _strQuery += "OrificeSize = '" + strOrificeSize + "' AND PortSize = '" + strPortSize + "' AND PortType = '" + strPortType + "'"
        GetPortLocatorCode = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetPortLocatorCode) OrElse GetPortLocatorCode.Rows.Count = 0 Then
            GetPortLocatorCode = Nothing
            _strErrorMessage = "Data not retrieved from PortsAndWPDSDetails table" + vbCrLf
            '_strErrorMessage += MonarchConnectionObject.ErrorMessage
        End If
    End Function

    Public Function GetPistonDesignData(ByVal strBoreDiameter As String) As DataRow
        GetPistonDesignData = Nothing
        _strQuery = "SELECT * FROM Welded.PistonDesignData WHERE BoreDiameter = " + strBoreDiameter
        GetPistonDesignData = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetPistonDesignData) OrElse GetPistonDesignData.ItemArray.Length <= 0 Then
            GetPistonDesignData = Nothing
            _strErrorMessage = "Data not retrieved from PistonDesignData table" + vbCrLf
        End If
    End Function

    Public Function GetCounterBoreDiameter(ByVal dblBoreDiameter As Double, ByVal dblPistonNutSize As Double) As String
        GetCounterBoreDiameter = Nothing
        _strQuery = "SELECT DISTINCT(CounterBoreDiameter) FROM Welded.CounterBoreDiameterDetails WHERE BoreDiameter = " + dblBoreDiameter.ToString
        _strQuery += " AND PistonNutSize = " + dblPistonNutSize.ToString
        GetCounterBoreDiameter = MonarchConnectionObject.GetValue(_strQuery)
        If IsNothing(GetCounterBoreDiameter) Then
            GetCounterBoreDiameter = Nothing
            _strErrorMessage = "Data not retrieved from CounterBoreDiameterDetails table" + vbCrLf
            _strErrorMessage += "CounterBore Diameter not available in table CounterBoreDiameterDetails for selected BoreDiameter and PistonNutSize"
            '_strErrorMessage += MonarchConnectionObject.ErrorMessage
        End If
    End Function

    Public Function InsertNewDetails(ByVal strQuery As String) As Boolean
        Try
            InsertNewDetails = True
            InsertNewDetails = MonarchConnectionObject.ExecuteQuery(strQuery)
            If Not InsertNewDetails Then
                InsertNewDetails = False
                _strErrorMessage = "Data not inserted into table" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function GetMaxIFLID(ByVal strTableName As String) As String
        GetMaxIFLID = Nothing
        _strQuery = "SELECT MAX(IFLID) FROM " + strTableName
        If Not IsDBNull(MonarchConnectionObject.GetValue(_strQuery)) Then
            GetMaxIFLID = MonarchConnectionObject.GetValue(_strQuery)
        Else
            GetMaxIFLID = Nothing
        End If

        If IsNothing(GetMaxIFLID) Then
            GetMaxIFLID = Nothing
            _strErrorMessage = "Data not retrieved from " + strTableName + "table" + vbCrLf
        End If
    End Function

    Public Function GetMaxPistonCode() As String
        _strQuery = "SELECT MAX(PistonCode) FROM Welded.PistonDetails"
        GetMaxPistonCode = MonarchConnectionObject.GetValue(_strQuery)
        If IsNothing(GetMaxPistonCode) Then
            GetMaxPistonCode = Nothing
            _strErrorMessage = "Data not retrieved from PistonDetails table" + vbCrLf
        End If
    End Function

    Public Function GetBoreDiameters_SealCodesDetails(ByVal strBoreDiameter As String) As DataRow
        GetBoreDiameters_SealCodesDetails = Nothing
        _strQuery = "SELECT * FROM Welded.RoDDiamters_SealCodes WHERE BoreDiameter = " + strBoreDiameter
        GetBoreDiameters_SealCodesDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetBoreDiameters_SealCodesDetails) OrElse GetBoreDiameters_SealCodesDetails.ItemArray.Length <= 0 Then
            GetBoreDiameters_SealCodesDetails = Nothing
            _strErrorMessage = "Data not retrieved from RoDDiamters_SealCodes table" + vbCrLf
        End If
    End Function

    Public Function GetCylinderDesignData(ByVal strRodDiameter As String) As DataRow
        GetCylinderDesignData = Nothing
        _strQuery = "SELECT * FROM Welded.CylinderHeadDesignDetails WHERE RodDiameter=" + strRodDiameter
        GetCylinderDesignData = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetCylinderDesignData) OrElse GetCylinderDesignData.ItemArray.Length <= 0 Then
            GetCylinderDesignData = Nothing
            _strErrorMessage = "Data not retrieved from CylinderHeadDesignDetails table" + vbCrLf
        End If
    End Function

    '30_09_2010  RAGAVA
    Public Function GetExistingCylinderDesignData(ByVal HeadCodeNumber As String) As DataRow
        Try
            GetExistingCylinderDesignData = Nothing
            _strQuery = "SELECT * FROM Welded.CylinderHeadDetails WHERE CylinderHeadCode='" & HeadCodeNumber & "'"
            GetExistingCylinderDesignData = MonarchConnectionObject.GetDataRow(_strQuery)
        Catch ex As Exception

        End Try
    End Function

    Public Function GetMaxCylinderHeadCode() As String
        _strQuery = "SELECT MAX(CylinderHeadCode) FROM Welded.CylinderHeadDetails"
        GetMaxCylinderHeadCode = MonarchConnectionObject.GetValue(_strQuery)
        If IsNothing(GetMaxCylinderHeadCode) Then
            GetMaxCylinderHeadCode = Nothing
            _strErrorMessage = "Data not retrieved from CylinderHeadDetails table" + vbCrLf
        End If
    End Function

    Public Function GetStaticSealDetails(ByVal strBoreDiameter As String) As DataRow
        GetStaticSealDetails = Nothing
        _strQuery = "SELECT * FROM Welded.StaticSealDetails WHERE BoreDiameter = " + strBoreDiameter
        GetStaticSealDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetStaticSealDetails) OrElse GetStaticSealDetails.ItemArray.Length <= 0 Then
            GetStaticSealDetails = Nothing
            _strErrorMessage = "Data not retrieved from StaticSealDetails table" + vbCrLf
        End If
    End Function

    Public Function GetORing_BackUpCodes(ByVal strBoreDiameter As String, ByVal strThd_RR As String) As DataRow
        GetORing_BackUpCodes = Nothing
        _strQuery = "SELECT * FROM Welded.ORing_BackupCodes WHERE BoreDiameter =" + strBoreDiameter + " AND Threaded_RR = '" + strThd_RR + "'"
        GetORing_BackUpCodes = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetORing_BackUpCodes) OrElse GetORing_BackUpCodes.ItemArray.Length <= 0 Then
            GetORing_BackUpCodes = Nothing
            _strErrorMessage = "Data not retrieved from ORing_BackupCodes table" + vbCrLf
        End If
    End Function

    Public Function GetTubeDetails(ByVal strIFLID As String) As DataRow
        GetTubeDetails = Nothing
        _strQuery = "SELECT * FROM Welded.TubeDetails WHERE IFLID = '" + strIFLID + " '"
        GetTubeDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetTubeDetails) OrElse GetTubeDetails.ItemArray.Length <= 0 Then
            GetTubeDetails = Nothing
            _strErrorMessage = "Data not retrieved from TubeDetails table" + vbCrLf
        End If
    End Function

    Public Function GetPort_WPDSDetails(ByVal dblTubeOD As Double, ByVal strPortAngle As String, ByVal strPortType As String, ByVal strPortSize As String) As DataRow
        GetPort_WPDSDetails = Nothing
        _strQuery = "SELECT * FROM Welded.PortsAndWPDSDetails WHERE " + dblTubeOD.ToString + " BETWEEN MinimumTubeOD AND MaximumTubeOD "
        _strQuery += "AND PortOrientation = '" + strPortAngle + "' AND PortType = '" + strPortType + "' AND PORT_SIZE = '" + strPortSize + "'"
        GetPort_WPDSDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetPort_WPDSDetails) OrElse GetPort_WPDSDetails.ItemArray.Length <= 0 Then
            GetPort_WPDSDetails = Nothing
            _strErrorMessage = "Data not retrieved from PortsAndWPDSDetails table" + vbCrLf
        End If
    End Function

    Public Function BEDLCastingWithoutPortDetails(ByVal strBoreDiameter As String, ByVal strWallThickness As String, _
    ByVal strBushingWidth As String, ByVal strPinHoleSize As String, ByVal strBushingQuantity As String, ByVal strLugThickness As String, _
    ByVal strLugGap As String, ByVal strSwingClearance As String) As DataTable
        BEDLCastingWithoutPortDetails = Nothing
        If strBushingQuantity = 2 Then
            _strQuery = "SELECT * FROM Welded.BEDLCastWithOutPort WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue "
            _strQuery += " AND LugThickness = " + strBushingWidth + " AND PinHole_Combined <= " + strPinHoleSize
            _strQuery += " AND LugGap >= " + strLugGap + " AND LugGap <= " + Val(Val(strLugGap) + 0.25).ToString


            'MANJULA 09-02-2012
            ' _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString

            '*********




        ElseIf strBushingQuantity = 0 Then
            _strQuery = "SELECT * FROM Welded.BEDLCastWithOutPort WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue "
            _strQuery += " AND LugThickness >= " + strLugThickness + " AND LugThickness <= " + Val(Val(strLugThickness) + 0.25).ToString
            _strQuery += " AND PinHole_Combined <= " + strPinHoleSize
            _strQuery += " AND LugGap >= " + strLugGap + " AND LugGap <= " + Val(Val(strLugGap) + 0.25).ToString

            'MANJULA 09-02-2012
            '  _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString

            '*********


        End If
        BEDLCastingWithoutPortDetails = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(BEDLCastingWithoutPortDetails) OrElse BEDLCastingWithoutPortDetails.Rows.Count = 0 Then
            BEDLCastingWithoutPortDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEDLCastWithOutPort table" + vbCrLf
        End If
    End Function

    Public Function BEDLCastingWithFlushedPortDetails(ByVal strBoreDiameter As String, ByVal strWallThickness As String, _
    ByVal strBushingWidth As String, ByVal strPinHoleSize As String, ByVal strBushingQuantity As String, ByVal strLugThickness As String, _
    ByVal strLugGap As String, ByVal strSwingClearance As String, ByVal strPortType As String) As DataTable
        BEDLCastingWithFlushedPortDetails = Nothing
        If strBushingQuantity = 2 Then
            _strQuery = "SELECT * FROM Welded.BEDLCastWithFlushPort WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue "
            _strQuery += " AND LugThickness = " + strBushingWidth + " AND PinHole_Combined <= " + strPinHoleSize
            _strQuery += " AND LugGap >= " + strLugGap + " AND LugGap <= " + Val(Val(strLugGap) + 0.25).ToString
            '26_07_2011  RAGAVA  COmmented
            '_strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            _strQuery += " AND PortType = '" + strPortType + "'"
        ElseIf strBushingQuantity = 0 Then
            _strQuery = "SELECT * FROM Welded.BEDLCastWithFlushPort WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue "
            _strQuery += " AND LugThickness >= " + strLugThickness + " AND LugThickness <= " + Val(Val(strLugThickness) + 0.25).ToString
            _strQuery += " AND PinHole_Combined <= " + strPinHoleSize
            _strQuery += " AND LugGap >= " + strLugGap + " AND LugGap <= " + Val(Val(strLugGap) + 0.25).ToString
            '26_07_2011  RAGAVA  COmmented
            '_strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            _strQuery += " AND PortType = '" + strPortType + "'"
        End If
        BEDLCastingWithFlushedPortDetails = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(BEDLCastingWithFlushedPortDetails) OrElse BEDLCastingWithFlushedPortDetails.Rows.Count = 0 Then
            BEDLCastingWithFlushedPortDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEDLCastWithFlushPort table" + vbCrLf
        End If
    End Function

    Public Function GetPlateClevisDetails(ByVal strBoreDiameter As String, ByVal strTubeOD As String) As DataTable
        GetPlateClevisDetails = Nothing
        _strQuery = "SELECT * FROM Welded.ClevisPlateDetails WHERE IFLID = ( "
        _strQuery += "SELECT top 1 IFLID FROM Welded.ClevisPlateDetails WHERE BoreDiameter = " + strBoreDiameter + " AND TubeOD = " + strTubeOD + ")"
        GetPlateClevisDetails = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetPlateClevisDetails) OrElse GetPlateClevisDetails.Rows.Count = 0 Then
            GetPlateClevisDetails = Nothing
            _strErrorMessage = "Data not retrieved from ClevisPlateDetails table" + vbCrLf
        End If
    End Function

    Public Function BEULUgDetails(ByVal strBushingQuantity As String, ByVal strBushingWidth As String, ByVal strPinHoleSize As String, _
   ByVal strLugThickness As String, ByVal strPinWithInTubeDia As String, ByVal strTubeOD As String, ByVal strLugGap As String, Optional ByVal str1st_2nd As String = "1") As DataTable       '15_05_2012   RAGAVA
        BEULUgDetails = Nothing
        If strBushingQuantity = 2 Then
            _strQuery = "SELECT * FROM Welded.BEULDetails WHERE LugThickness = " + strBushingWidth + " AND PinHoleCombined <= '" + strPinHoleSize + "'"
            If strPinWithInTubeDia = "Yes" Then
                _strQuery += " AND LugDiagonal <= " + strTubeOD
            End If
            _strQuery += " AND LugGap >= " + strLugGap + " AND LugGap <= " + Val(Val(strLugGap) + 0.25).ToString
        ElseIf strBushingQuantity = 0 Then
            _strQuery = "SELECT * FROM Welded.BEULDetails WHERE LugThickness >= " + strLugThickness
            _strQuery += " AND LugThickness <= " + Val(Val(strLugThickness) + 0.25).ToString + " AND PinHoleCombined <= '" + strPinHoleSize + "'"
            If strPinWithInTubeDia = "Yes" Then
                _strQuery += " AND LugDiagonal <= " + strTubeOD
            End If
            _strQuery += " AND LugGap >= " + strLugGap + " AND LugGap <= " + Val(Val(strLugGap) + 0.25).ToString
        End If
        BEULUgDetails = MonarchConnectionObject.GetTable(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEULDetails"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BEULDetails"
        End If
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEULDetails"       '02_03_2010   RAGAVA
        'Till   Here
        If IsNothing(BEULUgDetails) OrElse BEULUgDetails.Rows.Count = 0 Then
            BEULUgDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEULDetails table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
        End If
    End Function

    Public Function GetBEDLCastWithOutPortSelectedRowDetails(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow   '15_05_2012   RAGAVA
        GetBEDLCastWithOutPortSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BEDLCastWithOutPort WHERE PartCode = '" + strPartCode + "'"
        GetBEDLCastWithOutPortSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEDLCastWithOutPort"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BEDLCastWithOutPort"
        End If
        'Till   Here
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEDLCastWithOutPort"
        If IsNothing(GetBEDLCastWithOutPortSelectedRowDetails) OrElse GetBEDLCastWithOutPortSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBEDLCastWithOutPortSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEDLCastWithOutPort table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "Welded.BEDLCastWithOutPort"    '07_02_2011 
        End If
    End Function

    Public Function GetBEDLCastingWithFlushedPortSelectedRowDetails(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow     '15_05_2012   RAGAVA
        GetBEDLCastingWithFlushedPortSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BEDLCastWithFlushPort WHERE PartCode = '" + strPartCode + "'"
        GetBEDLCastingWithFlushedPortSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEDLCastWithFlushPort"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BEDLCastWithFlushPort"
        End If
        'Till   Here
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEDLCastWithFlushPort"


        If IsNothing(GetBEDLCastingWithFlushedPortSelectedRowDetails) OrElse GetBEDLCastingWithFlushedPortSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBEDLCastingWithFlushedPortSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEDLCastWithFlushPort table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "Welded.BEDLCastWithFlushPort"    '07_02_2011 
        End If
    End Function

    'ANUP 13-10-2010 START
    Public Function GetBEULDetailsSelectedRowDetails(ByVal strPartCode As String, Optional ByVal CalledFromBaseEndOrRodEnd As String = "Rod End", Optional ByVal str1st_2nd As String = "1") As DataRow       '15_05_2012   RAGAVA
        GetBEULDetailsSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BEULDetails WHERE PartCode = '" + strPartCode + "'"
        GetBEULDetailsSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            If CalledFromBaseEndOrRodEnd = "Base End" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEULDetails"
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnd_NewDesign_TableName = "Welded.BEULDetails"
            End If
        Else
            If CalledFromBaseEndOrRodEnd = "Base End" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BEULDetails"
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnd_NewDesign_TableName = "Welded.BEULDetails"
            End If
        End If
        'Till   Here
        'If CalledFromBaseEndOrRodEnd = "Base End" Then
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEULDetails"
        'Else
        '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnd_NewDesign_TableName = "Welded.BEULDetails"
        'End If

        If IsNothing(GetBEULDetailsSelectedRowDetails) OrElse GetBEULDetailsSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBEULDetailsSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEULDetails table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
        End If
    End Function
    'ANUP 13-10-2010 TILL HERE

    Public Function GetBEBHDetailsSelectedRowDetails(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow  '15_05_2012  RAGAVA
        GetBEBHDetailsSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BEBHDetails WHERE PartCode = '" + strPartCode + "'"
        GetBEBHDetailsSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BEBHDetails"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "BEBHDetails"
        End If
        If IsNothing(GetBEBHDetailsSelectedRowDetails) OrElse GetBEBHDetailsSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBEBHDetailsSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEBHDetails table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
        End If
    End Function

    Public Function GetBESingleLDetailsSelectedRowDetails(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow        '15_05_2012   RAGAVA
        GetBESingleLDetailsSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BESingleLugDetails WHERE PartCode = '" + strPartCode + "'"
        GetBESingleLDetailsSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BESingleLugDetails"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "BESingleLugDetails"
        End If
        If IsNothing(GetBESingleLDetailsSelectedRowDetails) OrElse GetBESingleLDetailsSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBESingleLDetailsSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from BESingleLugDetails table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
        End If
    End Function

    ' ANUP 08-03-2010 04.45
    Public Function GetBEBasePlugCastWithPortSelectedRowDetails(ByVal strPartCode As String) As DataRow
        GetBEBasePlugCastWithPortSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BasePlugFlushedPort WHERE PartCode = '" + strPartCode + "'"
        GetBEBasePlugCastWithPortSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetBEBasePlugCastWithPortSelectedRowDetails) OrElse GetBEBasePlugCastWithPortSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBEBasePlugCastWithPortSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEBasePlugCastWithOutPort table" + vbCrLf
        End If
    End Function
    '******************

    '19_05_2010   RAGAVA   NEW DESIGN
    Public Function GetBEThreadedBaseRaisedPortDetails90(ByVal dblBoreDiameter As Double, ByVal dblWallThickness As Double, ByVal dblThreadSize As Double, _
   ByVal dblThreadLength As Double, ByVal dblSafetyFactor As Double) As DataTable
        GetBEThreadedBaseRaisedPortDetails90 = Nothing
        _strQuery = "select * from BEThreadedEndRaisedPort90 where BoreDiameter = " + dblBoreDiameter.ToString
        _strQuery += " and " + dblWallThickness.ToString + " between TubeWallThickness_LowerLimit and TubeWallThickness_UpperLimit "      '12_03_2010  RAGAVA   Space is added
        _strQuery += "and ThreadLength >= " + dblThreadLength.ToString + " and ThreadSize = " + dblThreadSize.ToString
        GetBEThreadedBaseRaisedPortDetails90 = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetBEThreadedBaseRaisedPortDetails90) OrElse GetBEThreadedBaseRaisedPortDetails90.Rows.Count = 0 Then
            GetBEThreadedBaseRaisedPortDetails90 = Nothing
            _strErrorMessage = "Data not retrieved from BEThreadedEndRaisedPort90 table" + vbCrLf
        End If
    End Function


    Public Function BEBHCastingWithRaisedPortDetails90(ByVal strBoreDiameter As String, ByVal strWallThickness As String, _
            ByVal strBushingWidth As String, ByVal strPinHoleSize As String, ByVal strBushingQuantity As String, ByVal strLugThickness As String, _
            ByVal strSwingClearance As String, ByVal strPortType As String, Optional ByVal str1st_2nd As String = "1") As DataTable        '15_05_2012   RAGAVA
        BEBHCastingWithRaisedPortDetails90 = Nothing
        If strBushingQuantity = 2 Then
            _strQuery = "SELECT * FROM BEBHCastingRaisedPort90 WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerLimit  AND WallThicknessUpperLimit "
            _strQuery += " AND LugThickness >= " + ((Val(strBushingWidth) * 2) + 0.125).ToString + " AND LugThickness <= " + ((Val(strBushingWidth) * 2) * 1.5).ToString
            _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            ' _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

            _strQuery += " AND PortType = '" + strPortType + "'"
        ElseIf strBushingQuantity = 1 Then
            _strQuery = "SELECT * FROM BEBHCastingRaisedPort90 WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerLimit   AND WallThicknessUpperLimit "
            _strQuery += " AND LugThickness = " + strBushingWidth
            _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            '_strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********


            _strQuery += " AND PortType = '" + strPortType + "'"
        ElseIf strBushingQuantity = 0 Then
            _strQuery = "SELECT * FROM BEBHCastingRaisedPort90 WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerLimit   AND  WallThicknessUpperLimit"
            _strQuery += " AND LugThickness >= " + strLugThickness + " AND LugThickness <= " + Val(Val(strLugThickness) + 0.25).ToString
            _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            ' _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

            _strQuery += " AND PortType = '" + strPortType + "'"
        End If
        BEBHCastingWithRaisedPortDetails90 = MonarchConnectionObject.GetTable(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BEBHCastingRaisedPort90"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "BEBHCastingRaisedPort90"
        End If
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BEBHCastingRaisedPort90"
        'Till   Here
        If IsNothing(BEBHCastingWithRaisedPortDetails90) OrElse BEBHCastingWithRaisedPortDetails90.Rows.Count = 0 Then
            BEBHCastingWithRaisedPortDetails90 = Nothing
            _strErrorMessage = "Data not retrieved from BEBHCastingRaisedPort90 table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            'Till   Here
        End If
    End Function

    '19_05_2010   RAGAVA     NEW  DESIGN
    Public Function BESLCastingWithRaisedPortDetails90(ByVal strBoreDiameter As String, ByVal strWallThickness As String, _
    ByVal strBushingWidth As String, ByVal strPinHoleSize As String, ByVal strBushingQuantity As String, ByVal strLugThickness As String, _
    ByVal strSwingClearance As String, ByVal strPortType As String, Optional ByVal str1st_2nd As String = "1") As DataTable      '15_05_2012  RAGAVA
        BESLCastingWithRaisedPortDetails90 = Nothing
        If strBushingQuantity = 2 Then
            _strQuery = "SELECT * FROM BESLCastingRaisedPort90 WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerLimit  AND WallThicknessUpperLimit "
            _strQuery += " AND LugThickness >= " + ((Val(strBushingWidth) * 2) + 0.125).ToString + " AND LugThickness <= " + ((Val(strBushingWidth) * 2) * 1.5).ToString
            _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            ' _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

            _strQuery += " AND PortType = '" + strPortType + "'"
        ElseIf strBushingQuantity = 1 Then
            _strQuery = "SELECT * FROM BESLCastingRaisedPort90 WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerLimit   AND WallThicknessUpperLimit "
            _strQuery += " AND LugThickness = " + strBushingWidth
            _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            '_strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********


            _strQuery += " AND PortType = '" + strPortType + "'"
        ElseIf strBushingQuantity = 0 Then
            _strQuery = "SELECT * FROM BESLCastingRaisedPort90 WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerLimit   AND  WallThicknessUpperLimit"
            _strQuery += " AND LugThickness >= " + strLugThickness + " AND LugThickness <= " + Val(Val(strLugThickness) + 0.25).ToString
            _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            ' _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

            _strQuery += " AND PortType = '" + strPortType + "'"
        End If
        BESLCastingWithRaisedPortDetails90 = MonarchConnectionObject.GetTable(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BESLCastingRaisedPort90"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "BESLCastingRaisedPort90"
        End If
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BESLCastingRaisedPort90"
        'Till   Here
        If IsNothing(BESLCastingWithRaisedPortDetails90) OrElse BESLCastingWithRaisedPortDetails90.Rows.Count = 0 Then
            BESLCastingWithRaisedPortDetails90 = Nothing
            _strErrorMessage = "Data not retrieved from BESLCastingRaisedPort90 table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
            'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
        End If
    End Function

    '27_04_2010    RAGAVA   NEW DESIGN
    '19_05_2010    RAGAVA   Modified Function Name
    Public Function GetBEBasePlugCastWithRaisedPortSelectedRowDetails(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow          '15_05_2012  RAGAVA
        GetBEBasePlugCastWithRaisedPortSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM BasePlugRaisedPort WHERE PartCode = '" + strPartCode + "'"
        GetBEBasePlugCastWithRaisedPortSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BasePlugRaisedPort"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "BasePlugRaisedPort"
        End If
        If IsNothing(GetBEBasePlugCastWithRaisedPortSelectedRowDetails) OrElse GetBEBasePlugCastWithRaisedPortSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBEBasePlugCastWithRaisedPortSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from BasePlugRaisedPort table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "BasePlugRaisedPort"      '07_02_2011    RAGAVA
        End If
    End Function

    Public Function GetBEBHCastingWithRaisedPortSelectedRowDetails90(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow       '15_05_2012   RAGAVA
        GetBEBHCastingWithRaisedPortSelectedRowDetails90 = Nothing
        _strQuery = "SELECT * FROM BEBHCastingRaisedPort90 WHERE PartCode = '" + strPartCode + "'"
        GetBEBHCastingWithRaisedPortSelectedRowDetails90 = MonarchConnectionObject.GetDataRow(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BEBHCastingRaisedPort90"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "BEBHCastingRaisedPort90"
        End If
        If IsNothing(GetBEBHCastingWithRaisedPortSelectedRowDetails90) OrElse GetBEBHCastingWithRaisedPortSelectedRowDetails90.ItemArray.Length <= 0 Then
            GetBEBHCastingWithRaisedPortSelectedRowDetails90 = Nothing
            _strErrorMessage = "Data not retrieved from BEBHCastingRaisedPort90 table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "BEBHCastingRaisedPort90"    '07_02_2011 
        End If
    End Function

    '19_05_2010   RAGAVA     New  DESIGN
    Public Function GetBESLCastingWithRaisedPortSelectedRowDetails90(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow          '15_05_2012   RAGAVA
        GetBESLCastingWithRaisedPortSelectedRowDetails90 = Nothing
        _strQuery = "SELECT * FROM BESLCastingRaisedPort90 WHERE PartCode = '" + strPartCode + "'"
        GetBESLCastingWithRaisedPortSelectedRowDetails90 = MonarchConnectionObject.GetDataRow(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BESLCastingRaisedPort90"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "BESLCastingRaisedPort90"
        End If
        If IsNothing(GetBESLCastingWithRaisedPortSelectedRowDetails90) OrElse GetBESLCastingWithRaisedPortSelectedRowDetails90.ItemArray.Length <= 0 Then
            GetBESLCastingWithRaisedPortSelectedRowDetails90 = Nothing
            _strErrorMessage = "Data not retrieved from BESLCastingRaisedPort90 table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "BESLCastingRaisedPort90"    '07_02_2011 
        End If
    End Function

    '19_05_2010    RAGAVA  NEW  DESIGN
    Public Function GetBEBasePlugCastWithRaisedPortSelectedRowDetails90(ByVal strPartCode As String) As DataRow
        GetBEBasePlugCastWithRaisedPortSelectedRowDetails90 = Nothing
        _strQuery = "SELECT * FROM BasePlugRaisedPort90 WHERE PartCode = '" + strPartCode + "'"
        GetBEBasePlugCastWithRaisedPortSelectedRowDetails90 = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetBEBasePlugCastWithRaisedPortSelectedRowDetails90) OrElse GetBEBasePlugCastWithRaisedPortSelectedRowDetails90.ItemArray.Length <= 0 Then
            GetBEBasePlugCastWithRaisedPortSelectedRowDetails90 = Nothing
            _strErrorMessage = "Data not retrieved from BasePlugRaisedPort90 table" + vbCrLf
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "BasePlugRaisedPort90"      '07_02_2011 
        End If
    End Function

    '19_05_2010   RAGAVA NEW DESIGN
    Public Function BEBasePlugCastingWithRaisedPortDetails90(ByVal strBoreDiameter As String, ByVal strWallThickness As String, _
   ByVal strBushingWidth As String, ByVal strPinHoleSize As String, ByVal strBushingQuantity As String, _
   ByVal strSwingClearance As String, ByVal dblBasePlugOD As Double, ByVal dblOutSidePlugDiameterRequired As Double) As DataTable

        BEBasePlugCastingWithRaisedPortDetails90 = Nothing
        Try

            '23_11_2011  RAGAVA  COMMENTED... will be Uncommented later when Michael requests
           _strQuery = "SELECT * FROM BasePlugRaisedPort90 WHERE BoreDiameter = " + strBoreDiameter


            'If strBushingQuantity = 2 Then
            '    ' ANUP CHANGE THE DATABASE NAME ONLY 08-03-2010 04.45
            '    _strQuery = "SELECT * FROM BasePlugRaisedPort90 WHERE BoreDiameter = " + strBoreDiameter
            '    _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue "
            '    _strQuery += " AND (PinHoleStandardNominalSize <= '" + strPinHoleSize + "' or PinHoleCustomID <= '" + strPinHoleSize + "')"        '02_12_2009   Ragava
            '    _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '    _strQuery += " AND " + (dblOutSidePlugDiameterRequired - 1 / 4).ToString + " <= OutSidePlugDiameter  And OutSidePlugDiameter <= " + (dblOutSidePlugDiameterRequired + 1 / 4).ToString
            '    _strQuery += " AND " + (Val(strBushingWidth) * 2 + 1 / 8).ToString + " <= MilledFlatWidth  And MilledFlatWidth <= " + (Val(strBushingWidth) * 2 * 1.5).ToString
            'ElseIf strBushingQuantity = 1 Then
            '    _strQuery = "SELECT * FROM BasePlugRaisedPort WHERE BoreDiameter = " + strBoreDiameter
            '    _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue "
            '    _strQuery += " AND (PinHoleStandardNominalSize <= '" + strPinHoleSize + "' or PinHoleCustomID <= '" + strPinHoleSize + "')"        '02_12_2009   Ragava
            '    _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '    _strQuery += " AND " + (dblOutSidePlugDiameterRequired - 1 / 4).ToString + " <= OutSidePlugDiameter and OutSidePlugDiameter <= " + (dblOutSidePlugDiameterRequired + 1 / 4).ToString
            '    _strQuery += " AND " + strBushingWidth + " <= MilledFlatWidth "
            'ElseIf strBushingQuantity = 0 Then
            '    _strQuery = "SELECT * FROM BasePlugRaisedPort WHERE BoreDiameter = " + strBoreDiameter
            '    _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue "
            '    _strQuery += " AND (PinHoleStandardNominalSize <= '" + strPinHoleSize + "' or PinHoleCustomID <= '" + strPinHoleSize + "')"        '02_12_2009   Ragava
            '    _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '    _strQuery += " AND " + (dblOutSidePlugDiameterRequired - 1 / 4).ToString + " <= OutSidePlugDiameter  and OutSidePlugDiameter <= " + (dblOutSidePlugDiameterRequired + 1 / 4).ToString
            '    '18_03_2010   RAGAVA
            '    '_strQuery += " AND " + strBushingWidth + " <= MilledFlatWidth and MilledFlatWidth <= " + (Val(strBushingWidth) + 1 / 2).ToString
            '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatWidth > 0 Then
            '        _strQuery += " AND '" + (Val(strBushingWidth)).ToString + "' <= MilledFlatWidth and MilledFlatWidth <= '" + (Val(strBushingWidth) + 1 / 2).ToString + "'"
            '    Else
            '        _strQuery += " AND MilledFlatWidth = 'N/A'"
            '    End If
            'End If

            'Till    Here


            BEBasePlugCastingWithRaisedPortDetails90 = MonarchConnectionObject.GetTable(_strQuery)
            If IsNothing(BEBasePlugCastingWithRaisedPortDetails90) OrElse BEBasePlugCastingWithRaisedPortDetails90.Rows.Count = 0 Then
                BEBasePlugCastingWithRaisedPortDetails90 = Nothing
                _strErrorMessage = "Data not retrieved from BasePlugRaisedPort90 table" + vbCrLf
            End If
        Catch ex As Exception

        End Try

    End Function

    '27_04_2010    RAGAVA  NEW DESIGN
    '19_05_2010   RAGAVA  Table Name Modified
    Public Function GetBEBasePlugCastWithFlushedPortSelectedRowDetails(ByVal strPartCode As String) As DataRow
        GetBEBasePlugCastWithFlushedPortSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BasePlugFlushedPort WHERE PartCode = '" + strPartCode + "'"
        GetBEBasePlugCastWithFlushedPortSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetBEBasePlugCastWithFlushedPortSelectedRowDetails) OrElse GetBEBasePlugCastWithFlushedPortSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBEBasePlugCastWithFlushedPortSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from BasePlugFlushedPort table" + vbCrLf
        End If
    End Function

    Public Function GetBEBHCastingWithRaisedPortSelectedRowDetails(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow        '15_05_2012   RAGAVA
        GetBEBHCastingWithRaisedPortSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM BEBHCastingRaisedPort WHERE PartCode = '" + strPartCode + "'"
        GetBEBHCastingWithRaisedPortSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BEBHCastingRaisedPort"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "BEBHCastingRaisedPort"
        End If
        If IsNothing(GetBEBHCastingWithRaisedPortSelectedRowDetails) OrElse GetBEBHCastingWithRaisedPortSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBEBHCastingWithRaisedPortSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEBHCastingRaisedPort table" + vbCrLf
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "BEBHCastingRaisedPort"    '07_02_2011 
        End If
    End Function

    '27_04_2010   RAGAVA
    Public Function GetBESLCastingWithRaisedPortSelectedRowDetails(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow       '15_05_2012   RAGAVA
        GetBESLCastingWithRaisedPortSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM BESLCastingRaisedPort WHERE PartCode = '" + strPartCode + "'"
        GetBESLCastingWithRaisedPortSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BESLCastingRaisedPort"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "BESLCastingRaisedPort"
        End If
        If IsNothing(GetBESLCastingWithRaisedPortSelectedRowDetails) OrElse GetBESLCastingWithRaisedPortSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBESLCastingWithRaisedPortSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from BESLCastingRaisedPort table" + vbCrLf
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "BESLCastingRaisedPort"    '07_02_2011 
        End If
    End Function

    '27_04_2010   RAGAVA   NEW DESIGN
    Public Function GetBEThreadedBaseRaisedPortDetails(ByVal dblBoreDiameter As Double, ByVal dblWallThickness As Double, ByVal dblThreadSize As Double, _
   ByVal dblThreadLength As Double, ByVal dblSafetyFactor As Double) As DataTable
        GetBEThreadedBaseRaisedPortDetails = Nothing
        _strQuery = "select * from BEThreadedEndRaisedPort where BoreDiameter = " + dblBoreDiameter.ToString
        _strQuery += " and " + dblWallThickness.ToString + " between TubeWallThickness_LowerLimit and TubeWallThickness_UpperLimit "      '12_03_2010  RAGAVA   Space is added
        _strQuery += "and ThreadLength >= " + dblThreadLength.ToString + " and ThreadSize = " + dblThreadSize.ToString
        GetBEThreadedBaseRaisedPortDetails = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetBEThreadedBaseRaisedPortDetails) OrElse GetBEThreadedBaseRaisedPortDetails.Rows.Count = 0 Then
            GetBEThreadedBaseRaisedPortDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEThreadedEndRaisedPort table" + vbCrLf
        End If
    End Function

    Public Function BEBHCastingWithRaisedPortDetails(ByVal strBoreDiameter As String, ByVal strWallThickness As String, _
      ByVal strBushingWidth As String, ByVal strPinHoleSize As String, ByVal strBushingQuantity As String, ByVal strLugThickness As String, _
      ByVal strSwingClearance As String, ByVal strPortType As String, Optional ByVal str1st_2nd As String = "1") As DataTable          '15_05_2012   RAGAVA
        BEBHCastingWithRaisedPortDetails = Nothing
        If strBushingQuantity = 2 Then
            _strQuery = "SELECT * FROM BEBHCastingRaisedPort WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerLimit  AND WallThicknessUpperLimit "
            _strQuery += " AND LugThickness >= " + ((Val(strBushingWidth) * 2) + 0.125).ToString + " AND LugThickness <= " + ((Val(strBushingWidth) * 2) * 1.5).ToString
            _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            '_strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

            _strQuery += " AND PortType = '" + strPortType + "'"
        ElseIf strBushingQuantity = 1 Then
            _strQuery = "SELECT * FROM BEBHCastingRaisedPort WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerLimit   AND WallThicknessUpperLimit "
            _strQuery += " AND LugThickness = " + strBushingWidth
            _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            '_strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

            _strQuery += " AND PortType = '" + strPortType + "'"
        ElseIf strBushingQuantity = 0 Then
            _strQuery = "SELECT * FROM BEBHCastingRaisedPort WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerLimit   AND  WallThicknessUpperLimit"
            _strQuery += " AND LugThickness >= " + strLugThickness + " AND LugThickness <= " + Val(Val(strLugThickness) + 0.25).ToString
            _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            ' _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

            _strQuery += " AND PortType = '" + strPortType + "'"
        End If
        BEBHCastingWithRaisedPortDetails = MonarchConnectionObject.GetTable(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BEBHCastingRaisedPort"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "BEBHCastingRaisedPort"
        End If
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BEBHCastingRaisedPort"
        'Till  Here
        If IsNothing(BEBHCastingWithRaisedPortDetails) OrElse BEBHCastingWithRaisedPortDetails.Rows.Count = 0 Then
            BEBHCastingWithRaisedPortDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEBHCastingRaisedPort table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
            'Till  Here
        End If
    End Function

    '27_04_2010   RAGAVA
    Public Function BESLCastingWithRaisedPortDetails(ByVal strBoreDiameter As String, ByVal strWallThickness As String, _
    ByVal strBushingWidth As String, ByVal strPinHoleSize As String, ByVal strBushingQuantity As String, ByVal strLugThickness As String, _
    ByVal strSwingClearance As String, ByVal strPortType As String, Optional ByVal str1st_2nd As String = "1") As DataTable          '15_05_2012   RAGAVA
        BESLCastingWithRaisedPortDetails = Nothing
        If strBushingQuantity = 2 Then
            _strQuery = "SELECT * FROM BESLCastingRaisedPort WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerLimit  AND WallThicknessUpperLimit "
            _strQuery += " AND LugThickness >= " + ((Val(strBushingWidth) * 2) + 0.125).ToString + " AND LugThickness <= " + ((Val(strBushingWidth) * 2) * 1.5).ToString
            _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            '_strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

            _strQuery += " AND PortType = '" + strPortType + "'"
        ElseIf strBushingQuantity = 1 Then
            _strQuery = "SELECT * FROM BESLCastingRaisedPort WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerLimit   AND WallThicknessUpperLimit "
            _strQuery += " AND LugThickness = " + strBushingWidth
            _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            '_strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

            _strQuery += " AND PortType = '" + strPortType + "'"
        ElseIf strBushingQuantity = 0 Then
            _strQuery = "SELECT * FROM BESLCastingRaisedPort WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerLimit   AND  WallThicknessUpperLimit"
            _strQuery += " AND LugThickness >= " + strLugThickness + " AND LugThickness <= " + Val(Val(strLugThickness) + 0.25).ToString
            _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            ' _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

            _strQuery += " AND PortType = '" + strPortType + "'"
        End If
        BESLCastingWithRaisedPortDetails = MonarchConnectionObject.GetTable(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BESLCastingRaisedPort"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "BESLCastingRaisedPort"
        End If
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BESLCastingRaisedPort"
        'Till   Here
        If IsNothing(BESLCastingWithRaisedPortDetails) OrElse BESLCastingWithRaisedPortDetails.Rows.Count = 0 Then
            BESLCastingWithRaisedPortDetails = Nothing
            _strErrorMessage = "Data not retrieved from BESLCastingRaisedPort table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
            'Till  Here
        End If
    End Function

    'Aruna-9_11_2009
    Public Function BEBasePlugCastingWithoutPortDetails(ByVal strBoreDiameter As String, ByVal strWallThickness As String, _
   ByVal strBushingWidth As String, ByVal strPinHoleSize As String, ByVal strBushingQuantity As String, _
   ByVal strSwingClearance As String, ByVal dblBasePlugOD As Double, ByVal dblOutSidePlugDiameterRequired As Double) As DataTable

        BEBasePlugCastingWithoutPortDetails = Nothing
        '23_11_2011  RAGAVA  COMMENTED... will be Uncommented later when Michael requests
        _strQuery = "SELECT * FROM Welded.BEBasePlugCastWithOutPort WHERE BoreDiameter = " + strBoreDiameter


        'If strBushingQuantity = 2 Then
        '    _strQuery = "SELECT * FROM Welded.BEBasePlugCastWithOutPort WHERE BoreDiameter = " + strBoreDiameter
        '    _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue "
        '    _strQuery += " AND (PinHoleStandardNominalSize <= '" + strPinHoleSize + "' or PinHoleCustomID <= '" + strPinHoleSize + "')"        '02_12_2009   Ragava
        '    _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
        '    _strQuery += " AND " + (dblOutSidePlugDiameterRequired - 1 / 4).ToString + " <= OutSidePlugDiameter  And OutSidePlugDiameter <= " + (dblOutSidePlugDiameterRequired + 1 / 4).ToString    '02_12_2009   Ragava
        '    _strQuery += " AND '" + (Val(strBushingWidth) * 2 + 1 / 8).ToString + "' <= MilledFlatWidth  And MilledFlatWidth <= '" + (Val(strBushingWidth) * 2 * 1.5).ToString + "'"
        'ElseIf strBushingQuantity = 1 Then
        '    _strQuery = "SELECT * FROM Welded.BEBasePlugCastWithOutPort WHERE BoreDiameter = " + strBoreDiameter
        '    _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue "
        '    _strQuery += " AND (PinHoleStandardNominalSize <= '" + strPinHoleSize + "' or PinHoleCustomID <= '" + strPinHoleSize + "')"        '02_12_2009   Ragava
        '    _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
        '    _strQuery += " AND " + (dblOutSidePlugDiameterRequired - 1 / 4).ToString + " <= OutSidePlugDiameter and OutSidePlugDiameter <= " + (dblOutSidePlugDiameterRequired + 1 / 4).ToString
        '    _strQuery += " AND  '" + strBushingWidth.ToString + "' <= MilledFlatWidth "
        'ElseIf strBushingQuantity = 0 Then
        '    _strQuery = "SELECT * FROM Welded.BEBasePlugCastWithOutPort WHERE BoreDiameter = " + strBoreDiameter
        '    _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue "
        '    _strQuery += " AND (PinHoleStandardNominalSize <= '" + strPinHoleSize + "' or PinHoleCustomID <= '" + strPinHoleSize + "')"        '02_12_2009   Ragava
        '    _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
        '    _strQuery += " AND " + (dblOutSidePlugDiameterRequired - 1 / 4).ToString + " <= OutSidePlugDiameter  and OutSidePlugDiameter <= " + (dblOutSidePlugDiameterRequired + 1 / 4).ToString      '02_12_2009   Ragava
        '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatWidth > 0 Then
        '        _strQuery += " AND '" + (Val(strBushingWidth)).ToString + "' <= MilledFlatWidth and MilledFlatWidth <= '" + (Val(strBushingWidth) + 1 / 2).ToString + "'"
        '    Else
        '        _strQuery += " AND MilledFlatWidth = 'N/A'"
        '    End If
        'End If

        'TILL   HERE



        BEBasePlugCastingWithoutPortDetails = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(BEBasePlugCastingWithoutPortDetails) OrElse BEBasePlugCastingWithoutPortDetails.Rows.Count = 0 Then
            BEBasePlugCastingWithoutPortDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEBasePlugCastWithOutPort table" + vbCrLf
        End If
    End Function

    Public Function GetBEBasePlugCastWithOutPortSelectedRowDetails(ByVal strPartCode As String) As DataRow
        GetBEBasePlugCastWithOutPortSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BEBasePlugCastWithOutPort WHERE PartCode = '" + strPartCode + "'"
        GetBEBasePlugCastWithOutPortSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetBEBasePlugCastWithOutPortSelectedRowDetails) OrElse GetBEBasePlugCastWithOutPortSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBEBasePlugCastWithOutPortSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEBasePlugCastWithOutPort table" + vbCrLf
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "Welded.BEBasePlugCastWithOutPort"      '07_02_2011 
        End If
    End Function
    'Aruna-9_11_2009
    Public Function BEBasePlugCastingWithPortDetails(ByVal strBoreDiameter As String, ByVal strWallThickness As String, _
   ByVal strBushingWidth As String, ByVal strPinHoleSize As String, ByVal strBushingQuantity As String, _
   ByVal strSwingClearance As String, ByVal dblBasePlugOD As Double, ByVal dblOutSidePlugDiameterRequired As Double) As DataTable

        BEBasePlugCastingWithPortDetails = Nothing
        Try
            '23_11_2011  RAGAVA  COMMENTED... will be Uncommented later when Michael requests
            _strQuery = "SELECT * FROM Welded.BasePlugFlushedPort WHERE BoreDiameter = " + strBoreDiameter

            'If strBushingQuantity = 2 Then
            '    ' ANUP CHANGE THE DATABASE NAME ONLY 08-03-2010 04.45
            '    _strQuery = "SELECT * FROM Welded.BasePlugFlushedPort WHERE BoreDiameter = " + strBoreDiameter
            '    _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue "
            '    _strQuery += " AND (PinHoleStandardNominalSize <= '" + strPinHoleSize + "' or PinHoleCustomID <= '" + strPinHoleSize + "')"        '02_12_2009   Ragava
            '    _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '    _strQuery += " AND " + (dblOutSidePlugDiameterRequired - 1 / 4).ToString + " <= OutSidePlugDiameter  And OutSidePlugDiameter <= " + (dblOutSidePlugDiameterRequired + 1 / 4).ToString

            '    'anup 11-02-2011 start
            '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlat = "Yes" Then
            '        _strQuery += " AND '" + (Val(strBushingWidth) * 2 + 1 / 8).ToString + "' <= MilledFlatWidth  And MilledFlatWidth <= '" + (Val(strBushingWidth) * 2 * 1.5).ToString + "'" 'anup 11-02-2011 
            '    End If
            '    'anup 11-02-2011 till here

            'ElseIf strBushingQuantity = 1 Then
            '    _strQuery = "SELECT * FROM Welded.BasePlugFlushedPort WHERE BoreDiameter = " + strBoreDiameter
            '    _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue "
            '    _strQuery += " AND (PinHoleStandardNominalSize <= '" + strPinHoleSize + "' or PinHoleCustomID <= '" + strPinHoleSize + "')"        '02_12_2009   Ragava
            '    _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '    _strQuery += " AND " + (dblOutSidePlugDiameterRequired - 1 / 4).ToString + " <= OutSidePlugDiameter and OutSidePlugDiameter <= " + (dblOutSidePlugDiameterRequired + 1 / 4).ToString

            '    'anup 11-02-2011 start
            '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlat = "Yes" Then
            '        _strQuery += " AND " + strBushingWidth + " <= MilledFlatWidth "
            '    End If
            '    'anup 11-02-2011 till here

            'ElseIf strBushingQuantity = 0 Then
            '    _strQuery = "SELECT * FROM Welded.BasePlugFlushedPort WHERE BoreDiameter = " + strBoreDiameter
            '    _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue "
            '    _strQuery += " AND (PinHoleStandardNominalSize <= '" + strPinHoleSize + "' or PinHoleCustomID <= '" + strPinHoleSize + "')"        '02_12_2009   Ragava
            '    _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '    _strQuery += " AND " + (dblOutSidePlugDiameterRequired - 1 / 4).ToString + " <= OutSidePlugDiameter  and OutSidePlugDiameter <= " + (dblOutSidePlugDiameterRequired + 1 / 4).ToString
            '    '18_03_2010   RAGAVA
            '    '_strQuery += " AND " + strBushingWidth + " <= MilledFlatWidth and MilledFlatWidth <= " + (Val(strBushingWidth) + 1 / 2).ToString
            '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatWidth > 0 Then
            '        _strQuery += " AND '" + (Val(strBushingWidth)).ToString + "' <= MilledFlatWidth and MilledFlatWidth <= '" + (Val(strBushingWidth) + 1 / 2).ToString + "'"
            '    Else
            '        _strQuery += " AND MilledFlatWidth = 'N/A'"
            '    End If
            'End If

            'Till    Here

            BEBasePlugCastingWithPortDetails = MonarchConnectionObject.GetTable(_strQuery)
            If IsNothing(BEBasePlugCastingWithPortDetails) OrElse BEBasePlugCastingWithPortDetails.Rows.Count = 0 Then
                BEBasePlugCastingWithPortDetails = Nothing
                _strErrorMessage = "Data not retrieved from BEDLCastWithOutPort table" + vbCrLf
            End If
        Catch ex As Exception

        End Try

    End Function

    Public Function GetWireRingDetails(ByVal strBoreDiameter As String) As DataRow
        GetWireRingDetails = Nothing
        _strQuery = "SELECT * FROM Welded.WireRingHeadDetails WHERE BoreDiameter = '" + strBoreDiameter + "'"
        GetWireRingDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetWireRingDetails) OrElse GetWireRingDetails.ItemArray.Length <= 0 Then
            GetWireRingDetails = Nothing
            _strErrorMessage = "Data not retrieved from WireRingHeadDetails table" + vbCrLf
        End If
    End Function

    Public Function BEBHCastingWithoutPortDetails(ByVal strBoreDiameter As String, ByVal strWallThickness As String, _
        ByVal strBushingWidth As String, ByVal strPinHoleSize As String, ByVal strBushingQuantity As String, ByVal strLugThickness As String, _
        ByVal strSwingClearance As String, Optional ByVal str1st_2nd As String = "1") As DataTable            '15_05_2012   RAGAVA
        BEBHCastingWithoutPortDetails = Nothing
        If strBushingQuantity = 2 Then
            _strQuery = "SELECT * FROM Welded.Base_End_BH_No_Port WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue   AND WallThicknessUpperValue "
            _strQuery += " AND LugThickness >= " + ((Val(strBushingWidth) * 2) + 0.125).ToString + " AND LugThickness <= " + ((Val(strBushingWidth) * 2) * 1.5).ToString
            '_strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            '_strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

        ElseIf strBushingQuantity = 1 Then
            _strQuery = "SELECT * FROM Welded.Base_End_BH_No_Port WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue   AND WallThicknessUpperValue "
            _strQuery += " AND LugThickness = " + strBushingWidth
            ' _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            '  _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

        ElseIf strBushingQuantity = 0 Then
            _strQuery = "SELECT * FROM Welded.Base_End_BH_No_Port WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue   AND WallThicknessUpperValue "
            _strQuery += " AND LugThickness >= " + strLugThickness + " AND LugThickness <= " + Val(Val(strLugThickness) + 0.25).ToString
            '_strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            ' _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

        End If
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.Base_End_BH_No_Port"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.Base_End_BH_No_Port"
        End If
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.Base_End_BH_No_Port"
        'Till Here
        BEBHCastingWithoutPortDetails = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(BEBHCastingWithoutPortDetails) OrElse BEBHCastingWithoutPortDetails.Rows.Count = 0 Then
            BEBHCastingWithoutPortDetails = Nothing
            _strErrorMessage = "Data not retrieved from Base_End_BH_No_Port table" + vbCrLf
            '24_02_2010 Aruna
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
            'Till   Here
        End If
    End Function

    Public Function BESLCastingWithoutPortDetails(ByVal strBoreDiameter As String, ByVal strWallThickness As String, _
    ByVal strBushingWidth As String, ByVal strPinHoleSize As String, ByVal strBushingQuantity As String, ByVal strLugThickness As String, _
    ByVal strSwingClearance As String, Optional ByVal str1st_2nd As String = "1") As DataTable        '15_05_2012   RAGAVA
        BESLCastingWithoutPortDetails = Nothing
        If strBushingQuantity = 2 Then
            _strQuery = "SELECT * FROM Welded.BESLCastingNoPort WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue   AND WallThicknessUpperValue "
            _strQuery += " AND LugThickness >= " + ((Val(strBushingWidth) * 2) + 0.125).ToString + " AND LugThickness <= " + ((Val(strBushingWidth) * 2) * 1.5).ToString
            _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            '_strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

        ElseIf strBushingQuantity = 1 Then
            _strQuery = "SELECT * FROM Welded.BESLCastingNoPort WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue   AND WallThicknessUpperValue "
            _strQuery += " AND LugThickness = " + strBushingWidth
            _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            '  _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

        ElseIf strBushingQuantity = 0 Then
            _strQuery = "SELECT * FROM Welded.BESLCastingNoPort WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue   AND WallThicknessUpperValue "
            _strQuery += " AND LugThickness >= " + strLugThickness + " AND LugThickness <= " + Val(Val(strLugThickness) + 0.25).ToString
            _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            ' _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

        End If
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BESLCastingNoPort"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BESLCastingNoPort"
        End If
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BESLCastingNoPort"
        'Till   Here
        BESLCastingWithoutPortDetails = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(BESLCastingWithoutPortDetails) OrElse BESLCastingWithoutPortDetails.Rows.Count = 0 Then
            BESLCastingWithoutPortDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEDLCastWithOutPort table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If

        End If
    End Function

    Public Function GetBEBHCastWithOutPortSelectedRowDetails(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow    '15_05_2012   RAGAVA
        GetBEBHCastWithOutPortSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.Base_End_BH_No_Port WHERE PartCode = '" + strPartCode + "'"
        GetBEBHCastWithOutPortSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.Base_End_BH_No_Port"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.Base_End_BH_No_Port"
        End If
        If IsNothing(GetBEBHCastWithOutPortSelectedRowDetails) OrElse GetBEBHCastWithOutPortSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBEBHCastWithOutPortSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from Base_End_BH_No_Port table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "Welded.Base_End_BH_No_Port"    '07_02_2011 
        End If
    End Function

    Public Function GetBESLCastWithOutPortSelectedRowDetails(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow      '15_05_2012   RAGAVA
        GetBESLCastWithOutPortSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BESLCastingNoPort WHERE PartCode = '" + strPartCode + "'"
        GetBESLCastWithOutPortSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BESLCastingNoPort"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BESLCastingNoPort"
        End If
        'Till  Here
        If IsNothing(GetBESLCastWithOutPortSelectedRowDetails) OrElse GetBESLCastWithOutPortSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBESLCastWithOutPortSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from BESLCastingNoPort table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "Welded.BESLCastingNoPort"    '07_02_2011 
        End If
    End Function

    Public Function GetBEBHCastingWithFlushedPortSelectedRowDetails(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow         '15_05_2012   RAGAVA
        GetBEBHCastingWithFlushedPortSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.WHERE PartCode = '" + strPartCode + "'"
        GetBEBHCastingWithFlushedPortSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.Base_End_BH_Flush_Port"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.Base_End_BH_Flush_Port"
        End If
        'Till  Here
        If IsNothing(GetBEBHCastingWithFlushedPortSelectedRowDetails) OrElse GetBEBHCastingWithFlushedPortSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBEBHCastingWithFlushedPortSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from Base_End_BH_Flush_Port table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "Welded.Base_End_BH_Flush_Port"    '07_02_2011 
        End If
    End Function

    Public Function GetBESLCastingWithFlushedPortSelectedRowDetails(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow         '15_05_2012    RAGAVA
        GetBESLCastingWithFlushedPortSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BESLCastingFlushPort WHERE PartCode = '" + strPartCode + "'"
        GetBESLCastingWithFlushedPortSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetBESLCastingWithFlushedPortSelectedRowDetails) OrElse GetBESLCastingWithFlushedPortSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBESLCastingWithFlushedPortSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from BESLCastingFlushPort table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
        Else
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BESLCastingFlushPort"
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BESLCastingFlushPort"
            End If
            'Till  Here
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "Welded.BESLCastingFlushPort"    '07_02_2011 
        End If
    End Function

    Public Function BEBHDetails(ByVal strBushingQuantity As String, ByVal strBushingWidth As String, ByVal strPinHoleSize As String, _
      ByVal strLugThickness As String, ByVal strPinWithInTubeDia As String, ByVal strTubeOD As String, ByVal swingClearance As Double, ByVal strConfiguration As String, Optional ByVal str1st_2nd As String = "1") As DataTable        '15_05_2012    RAGAVA
        BEBHDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BEBHDetails WHERE"

        If strBushingQuantity = 2 Then
            _strQuery += " Thickness >= " + ((Val(strBushingWidth) * 2) + 0.125).ToString + "AND Thickness <= " + ((Val(strBushingWidth) * 2) * 1.5).ToString
        ElseIf strBushingQuantity = 1 Then
            _strQuery += " Thickness = " + strBushingWidth
        ElseIf strBushingQuantity = 0 Then
            _strQuery += " Thickness >= " + strLugThickness + " AND Thickness <= " + Val(Val(strLugThickness) + 0.25).ToString
        End If

        'ANUP 08-11-2010 START
        'COMMENTED BECAUSE PIN OPTION IS REMOVED 
        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinsYesOrNo = "Yes" Then
        '    _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
        'Else
        Dim dblCalculatedValue As Double = Math.Round(swingClearance + (Val(strPinHoleSize) / 2) + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired + Val(strLugThickness), 3)
        _strQuery += " AND Height >=" + dblCalculatedValue.ToString + " and Height <=" + (dblCalculatedValue * 1.5).ToString + " and PinHole_Combined is null"
        ' End If
        'ANUP 08-11-2010 TILL HERE

        If strPinWithInTubeDia = "Yes" Then
            _strQuery += " AND LugDiagonal <= " + strTubeOD
        End If

        '2_3_2010 Aruna
        If strConfiguration = "Base End" Then
            _strQuery += " And " + swingClearance.ToString + "  <= (Height-(width/2))"
        End If
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEBHDetails"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BEBHDetails"
        End If
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEBHDetails"
        'Till  Here
        BEBHDetails = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(BEBHDetails) OrElse BEBHDetails.Rows.Count = 0 Then
            BEBHDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEBHDetails table" + vbCrLf
            '24_02_2010 Aruna
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
        End If
    End Function

    Public Function BESingleLUgDetails(ByVal strBushingQuantity As String, ByVal strBushingWidth As String, ByVal strPinHoleSize As String, _
    ByVal strLugThickness As String, ByVal strPinWithInTubeDia As String, ByVal strTubeOD As String, ByVal swingClearance As Double, ByVal strConfiguration As String, Optional ByVal str1st_2nd As String = "1") As DataTable          '15_05_2012   RAGAVA
        BESingleLUgDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BESingleLugDetails WHERE"

        If strBushingQuantity = 2 Then
            _strQuery += " Thickness >= " + ((Val(strBushingWidth) * 2) + 0.125).ToString + "AND Thickness <= " + ((Val(strBushingWidth) * 2) * 1.5).ToString
        ElseIf strBushingQuantity = 1 Then
            _strQuery += " Thickness = " + strBushingWidth
        ElseIf strBushingQuantity = 0 Then
            _strQuery += " Thickness >= " + strLugThickness + " AND Thickness <= " + Val(Val(strLugThickness) + 0.25).ToString
        End If

        'ANUP 08-11-2010 START
        'COMMENTED BECAUSE PIN OPTION IS REMOVED 
        'If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PinsYesOrNo = "Yes" Then
        '    _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
        'Else
        Dim dblCalculatedValue As Double = Math.Round(swingClearance + (Val(strPinHoleSize) / 2) + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.YRequired + Val(strLugThickness), 3)
        _strQuery += " AND Height >=" + dblCalculatedValue.ToString + " and Height <=" + (dblCalculatedValue * 1.5).ToString + " and PinHole_Combined is null"
        ' End If
        'ANUP 08-11-2010 TILL HERE

        If strPinWithInTubeDia = "Yes" Then
            _strQuery += " AND LugDiagonal <= " + strTubeOD
        End If

        '2_3_2010 Aruna
        If strConfiguration = "Base End" Then
            _strQuery += " And " + swingClearance.ToString + "  <= (Height-(width/2))"
        End If
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BESingleLugDetails"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BESingleLugDetails"
        End If
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BESingleLugDetails"
        'Till   Here
        BESingleLUgDetails = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(BESingleLUgDetails) OrElse BESingleLUgDetails.Rows.Count = 0 Then
            BESingleLUgDetails = Nothing
            _strErrorMessage = "Data not retrieved from BESingleLugDetails table" + vbCrLf
            '24_02_2010 Aruna
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
        End If
    End Function

    Public Function BEBHCastingWithFlushedPortDetails(ByVal strBoreDiameter As String, ByVal strWallThickness As String, _
       ByVal strBushingWidth As String, ByVal strPinHoleSize As String, ByVal strBushingQuantity As String, ByVal strLugThickness As String, _
       ByVal strSwingClearance As String, ByVal strPortType As String, Optional ByVal str1st_2nd As String = "1") As DataTable       '15_05_2012   RAGAVA
        BEBHCastingWithFlushedPortDetails = Nothing
        If strBushingQuantity = 2 Then
            _strQuery = "SELECT * FROM Welded.Base_End_BH_Flush_Port WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerLimit  AND WallThicknessUpperLimit "
            _strQuery += " AND LugThickness >= " + ((Val(strBushingWidth) * 2) + 0.125).ToString + " AND LugThickness <= " + ((Val(strBushingWidth) * 2) * 1.5).ToString
            ' _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            '  _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

            _strQuery += " AND PortType = '" + strPortType + "'"
        ElseIf strBushingQuantity = 1 Then
            _strQuery = "SELECT * FROM Welded.Base_End_BH_Flush_Port WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerLimit   AND WallThicknessUpperLimit "
            _strQuery += " AND LugThickness = " + strBushingWidth
            ' _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            '_strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

            _strQuery += " AND PortType = '" + strPortType + "'"
        ElseIf strBushingQuantity = 0 Then
            _strQuery = "SELECT * FROM Welded.Base_End_BH_Flush_Port WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerLimit   AND  WallThicknessUpperLimit"
            _strQuery += " AND LugThickness >= " + strLugThickness + " AND LugThickness <= " + Val(Val(strLugThickness) + 0.25).ToString
            ' _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            '_strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

            _strQuery += " AND PortType = '" + strPortType + "'"
        End If
        BEBHCastingWithFlushedPortDetails = MonarchConnectionObject.GetTable(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.Base_End_BH_Flush_Port"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.Base_End_BH_Flush_Port"
        End If
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.Base_End_BH_Flush_Port"

        If IsNothing(BEBHCastingWithFlushedPortDetails) OrElse BEBHCastingWithFlushedPortDetails.Rows.Count = 0 Then
            BEBHCastingWithFlushedPortDetails = Nothing
            _strErrorMessage = "Data not retrieved from Base_End_BH_Flush_Port table" + vbCrLf
            '24_02_2010 Aruna
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If

        End If
    End Function

    Public Function BESLCastingWithFlushedPortDetails(ByVal strBoreDiameter As String, ByVal strWallThickness As String, _
    ByVal strBushingWidth As String, ByVal strPinHoleSize As String, ByVal strBushingQuantity As String, ByVal strLugThickness As String, _
    ByVal strSwingClearance As String, ByVal strPortType As String, Optional ByVal str1st_2nd As String = "1") As DataTable        '15_05_2012   RAGAVA
        BESLCastingWithFlushedPortDetails = Nothing
        If strBushingQuantity = 2 Then
            _strQuery = "SELECT * FROM Welded.BESLCastingFlushPort WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerLimit  AND WallThicknessUpperLimit "
            _strQuery += " AND LugThickness >= " + ((Val(strBushingWidth) * 2) + 0.125).ToString + " AND LugThickness <= " + ((Val(strBushingWidth) * 2) * 1.5).ToString
            '_strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            '  _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

            _strQuery += " AND PortType = '" + strPortType + "'"
        ElseIf strBushingQuantity = 1 Then
            _strQuery = "SELECT * FROM Welded.BESLCastingFlushPort WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerLimit   AND WallThicknessUpperLimit "
            _strQuery += " AND LugThickness = " + strBushingWidth
            '_strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            '_strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

            _strQuery += " AND PortType = '" + strPortType + "'"
        ElseIf strBushingQuantity = 0 Then
            _strQuery = "SELECT * FROM Welded.BESLCastingFlushPort WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerLimit   AND  WallThicknessUpperLimit"
            _strQuery += " AND LugThickness >= " + strLugThickness + " AND LugThickness <= " + Val(Val(strLugThickness) + 0.25).ToString
            '_strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
            'MANJULA 09-02-2012
            '_strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

            _strQuery += " AND PortType = '" + strPortType + "'"
        End If
        BESLCastingWithFlushedPortDetails = MonarchConnectionObject.GetTable(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BESLCastingFlushPort"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BESLCastingFlushPort"
        End If
        'Till  Here
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BESLCastingFlushPort"

        If IsNothing(BESLCastingWithFlushedPortDetails) OrElse BESLCastingWithFlushedPortDetails.Rows.Count = 0 Then
            BESLCastingWithFlushedPortDetails = Nothing
            _strErrorMessage = "Data not retrieved from BESLCastingFlushPort table" + vbCrLf
            '24_02_2010 Aruna
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
            'Till  Here

        End If
    End Function

    Public Function GetPortSizesfromDB(ByVal strPortType As String) As DataTable
        GetPortSizesfromDB = Nothing
        _strQuery = "SELECT DISTINCT PORT_SIZE  FROM Welded.PortsAndWPDSDetails WHERE PORT_SIZE NOT IN ('M12','M18') AND "
        _strQuery += "PortType = '" + strPortType + "' ORDER BY PORT_SIZE ASC"
        GetPortSizesfromDB = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetPortSizesfromDB) OrElse GetPortSizesfromDB.Rows.Count = 0 Then
            GetPortSizesfromDB = Nothing
            _strErrorMessage = "Data not retrieved from PortsAndWPDSDetails table" + vbCrLf
        End If
    End Function

    '27_02_2010
    Public Function BECrossTubeCastingWithoutPortDetails(ByVal strBoreDiameter As String, ByVal strWallThickness As String, _
 ByVal strBushingWidth As String, ByVal strPinHoleSize As String, ByVal strBushingQuantity As String, _
 ByVal strSwingClearance As String, ByVal strCrossTubeWidth As String, ByVal strOffSet As String, ByVal strTubeOD As String, Optional ByVal str1st_2nd As String = "1") As DataTable          '15_05_2012   RAGAVA
        BECrossTubeCastingWithoutPortDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BECrossTubeCastingWithoutPort WHERE BoreDiameter = " + strBoreDiameter
        '_strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessHigherValue  AND WallThicknessLowerValue "
        _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue "     '04_03_2010   RAGAVA
        If strBushingQuantity = 2 Then
            _strQuery += " AND CrossTubeWidth >= " + ((Val(strBushingWidth) * 2) + 0.125).ToString + " AND CrossTubeWidth <= " + ((Val(strBushingWidth) * 2) * 1.5).ToString
        ElseIf strBushingQuantity = 1 Then
            _strQuery += " AND CrossTubeWidth = " + strBushingWidth
        ElseIf strBushingQuantity = 0 Then
            _strQuery += " AND CrossTubeWidth >= " + strCrossTubeWidth + " AND CrossTubeWidth <= " + Val(Val(strCrossTubeWidth) + 0.5).ToString
        End If
        _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
        _strQuery += " AND CrossTubeOD >= " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD.ToString '(Val(strPinHoleSize) + 0.5).ToString
        If Val(strOffSet) > 0 Then
            _strQuery += " AND OffSet >= " + strOffSet
        Else
            _strQuery += " AND OffSet <= 0.25"
        End If
        If Val(strCrossTubeWidth) <= Val(strTubeOD) + 0.25 Then
            _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance
        End If

        'ANUP 20-09-2010 START
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.IsStyle_2BushingsIndividualBore Then
            _strQuery += " and Is2BushingsIndividualBore = 'Yes'"
        End If
        'ANUP 20-09-2010 TILL HERE

        BECrossTubeCastingWithoutPortDetails = MonarchConnectionObject.GetTable(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BECrossTubeCastingWithoutPort"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BECrossTubeCastingWithoutPort"
        End If
        'Till  Here
        If IsNothing(BECrossTubeCastingWithoutPortDetails) OrElse BECrossTubeCastingWithoutPortDetails.Rows.Count = 0 Then
            BECrossTubeCastingWithoutPortDetails = Nothing
            _strErrorMessage = "Data not retrieved from BECrossTubeCastingWithoutPort table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
            'Till  Here
        End If
    End Function

    Public Function GetBECrossTubeCastWithOutPortSelectedRowDetails(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow          '15_05_2012   RAGAVA
        GetBECrossTubeCastWithOutPortSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BECrossTubeCastingWithoutPort WHERE PartCode = '" + strPartCode + "'"
        GetBECrossTubeCastWithOutPortSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)

        If IsNothing(GetBECrossTubeCastWithOutPortSelectedRowDetails) OrElse GetBECrossTubeCastWithOutPortSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBECrossTubeCastWithOutPortSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from BESLCastingNoPort table" + vbCrLf
        Else
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BECrossTubeCastingWithoutPort"
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BECrossTubeCastingWithoutPort"
            End If
            'Till  Here
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "Welded.BECrossTubeCastingWithoutPort"      '07_02_2011 
        End If
    End Function

    Public Function BECrossTubeDetails(ByVal strBushingQuantity As String, ByVal strBushingWidth As String, ByVal strPinHoleSize As String, _
   ByVal strSwingClearance As String, ByVal strCrossTubeWidth As String, Optional ByVal str1st_2nd As String = "1") As DataTable     '15_05_2012   RAGAVA
        BECrossTubeDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BECrossTubeDetails WHERE PinHoleCombined <= '" + strPinHoleSize + "'"
        'Val(ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.cmbPinHoleSize.Text) + 0.5
        '12_01_2012   RAGAVA
        '_strQuery += " AND Diameter >= " + (Val(strPinHoleSize) + 0.5).ToString
        '_strQuery += " AND Diameter >= " + (Val(strSwingClearance) * 2).ToString
        _strQuery += " AND (Diameter >= " + (Val(strPinHoleSize) + 0.5).ToString
        _strQuery += " OR Diameter >= " + (Val(strSwingClearance) * 2).ToString + ")"
        'Till   Here
        If strBushingQuantity = 2 Then
            _strQuery += " AND Width >= " + ((Val(strBushingWidth) * 2) + 0.125).ToString + "AND Width <= " + ((Val(strBushingWidth) * 2) + 1.5).ToString 'ANUP 20-09-2010 make * to +
        ElseIf strBushingQuantity = 1 Then
            _strQuery += " AND Width = " + strBushingWidth
        ElseIf strBushingQuantity = 0 Then
            _strQuery += " AND Width >= " + strCrossTubeWidth + " AND Width <= " + Val(Val(strCrossTubeWidth) + 0.25).ToString
        End If

        'ANUP 20-09-2010 START
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.IsStyle_2BushingsIndividualBore Then
            _strQuery += " and Is2BushingsIndividualBore = 'Yes'"
        End If
        'ANUP 20-09-2010 TILL HERE
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BECrossTubeDetails"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BECrossTubeDetails"
        End If
        'Till  Here
        BECrossTubeDetails = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(BECrossTubeDetails) OrElse BECrossTubeDetails.Rows.Count = 0 Then
            BECrossTubeDetails = Nothing
            _strErrorMessage = "Data not retrieved from BECrossTubeDetails table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
            'Till  Here
        End If
    End Function

    Public Function GetBECrossTubeDetailsSelectedRowDetails(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow       '15_05_2012   RAGAVA
        GetBECrossTubeDetailsSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BECrossTubeDetails WHERE PartCode = '" + strPartCode + "'"
        GetBECrossTubeDetailsSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BECrossTubeDetails"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BECrossTubeDetails"
        End If
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BECrossTubeDetails"
        'Till  Here
        If IsNothing(GetBECrossTubeDetailsSelectedRowDetails) OrElse GetBECrossTubeDetailsSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBECrossTubeDetailsSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from BECrossTubeDetails table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
            'Till  Here
        End If
    End Function
    '25_02_2010
    Public Function GetWeldSize_RESL(ByVal dblRodDiameter As Double) As Double
        GetWeldSize_RESL = 0
        _strQuery = "SELECT WELDSIZE FROM Welded.RodWeldData WHERE WeldType = 'LatheWeld' AND Cofiguration = 'UGroove' AND RodDiameter = " + dblRodDiameter.ToString
        GetWeldSize_RESL = MonarchConnectionObject.GetValue(_strQuery)
        If IsNothing(GetWeldSize_RESL) OrElse GetWeldSize_RESL = 0 Then
            GetWeldSize_RESL = 0
            _strErrorMessage = "Data not retrieved from RodWeldData table" + vbCrLf
        End If
    End Function

    Public Function GetRESLDetails(ByVal dblRodDiameter As Double, ByVal dblWeldSize As Double, ByVal dblPinHoleSize As Double, _
  ByVal dblLugThickness As Double, ByVal dblSwingClearance As Double) As DataTable
        GetRESLDetails = Nothing
        _strQuery = "SELECT * FROM Welded.RESLDetails WHERE RodDiamater = " + dblRodDiameter.ToString + " AND WeldSize >= " + dblWeldSize.ToString
        _strQuery += " AND PinHoleCombined <= '" + dblPinHoleSize.ToString + "'"
        If dblLugThickness <= dblRodDiameter Then
            'MANJULA 09-02-2012
            ' _strQuery += " AND SwingClearanceRadius >= " + dblSwingClearance.ToString + " AND SwingClearanceRadius <= " + Val(dblSwingClearance * 1.25).ToString
            '*********
        End If
        GetRESLDetails = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetRESLDetails) OrElse GetRESLDetails.Rows.Count = 0 Then
            GetRESLDetails = Nothing
            _strErrorMessage = "Data not retrieved from RESLDetails table" + vbCrLf
        End If
    End Function

    Public Function GetREBHDetails(ByVal dblRodDiameter As Double, ByVal dblWeldSize As Double, ByVal dblPinHoleSize As Double, _
 ByVal dblLugThickness As Double, ByVal dblSwingClearance As Double) As DataTable
        GetREBHDetails = Nothing
        _strQuery = "SELECT * FROM Welded.Rod_End_BH WHERE RodDiamater = " + dblRodDiameter.ToString + " AND WeldSize >= " + dblWeldSize.ToString
        _strQuery += " AND PinHoleCombined <= '" + dblPinHoleSize.ToString + "'"
        If dblLugThickness <= dblRodDiameter Then
            'MANJULA 09-02-2012
            ' _strQuery += " AND SwingClearanceRadius >= " + dblSwingClearance.ToString + " AND SwingClearanceRadius <= " + Val(dblSwingClearance * 1.25).ToString
            '*********
        End If
        GetREBHDetails = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetREBHDetails) OrElse GetREBHDetails.Rows.Count = 0 Then
            GetREBHDetails = Nothing
            _strErrorMessage = "Data not retrieved from RodEndBH table" + vbCrLf
        End If
    End Function

    Public Function GetRESLSelectedRowDetails(ByVal strPartCode As String) As DataRow
        GetRESLSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.RESLDetails WHERE PartCode = '" + strPartCode + "'"
        GetRESLSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        '24_02_2010 Aruna
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnd_NewDesign_TableName = "Welded.RESLDetails"

        If IsNothing(GetRESLSelectedRowDetails) OrElse GetRESLSelectedRowDetails.ItemArray.Length <= 0 Then
            GetRESLSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from Welded.RESLDetails table" + vbCrLf
            '24_02_2010 Aruna
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnd_NewDesign_TableName = ""
        Else
        End If
    End Function


    Public Function GetREBHSelectedRowDetails(ByVal strPartCode As String) As DataRow
        GetREBHSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.Rod_End_BH WHERE PartCode = '" + strPartCode + "'"
        GetREBHSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        '24_02_2010 Aruna
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnd_NewDesign_TableName = "Welded.Rod_End_BH"

        If IsNothing(GetREBHSelectedRowDetails) OrElse GetREBHSelectedRowDetails.ItemArray.Length <= 0 Then
            GetREBHSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from Welded.Rod_End_BH table" + vbCrLf
            '24_02_2010 Aruna
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnd_NewDesign_TableName = ""
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndCastingTableName = "Welded.Rod_End_BH"   '07_02_2011 
        End If
    End Function

    Public Function GetPlateClevisDetails(ByVal dblBoreDiameter As Double, ByVal dblTubeOD As Double) As DataTable
        GetPlateClevisDetails = Nothing
        _strQuery = "select * from Welded.ClevisPlateDetails where BoreDiameter = " + dblBoreDiameter.ToString + " and TubeOD = " + dblTubeOD.ToString
        GetPlateClevisDetails = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetPlateClevisDetails) OrElse GetPlateClevisDetails.Rows.Count = 0 Then
            GetPlateClevisDetails = Nothing
            _strErrorMessage = "Data not retrieved from ClevisPlateDetails table" + vbCrLf
        End If
    End Function
    '02_04_2010 Aruna
    Public Function GetBEThreadedBaseNoPortDetails(ByVal dblBoreDiameter As Double, ByVal dblWallThickness As Double, ByVal dblThreadSize As Double, _
    ByVal dblThreadLength As Double, ByVal dblSafetyFactor As Double) As DataTable
        GetBEThreadedBaseNoPortDetails = Nothing
        _strQuery = "select * from welded.BEThreadedBaseNoPort where BoreDiameter = " + dblBoreDiameter.ToString
        _strQuery += " and " + dblWallThickness.ToString + " between TubeWallThickness_LowerLimit   and TubeWallThickness_UpperLimit "      '12_03_2010  RAGAVA   Space is added
        _strQuery += "and ThreadLength >= " + dblThreadLength.ToString + " and ThreadSize = '" + dblThreadSize.ToString + "'" '07_04_2010 Aruna
        GetBEThreadedBaseNoPortDetails = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetBEThreadedBaseNoPortDetails) OrElse GetBEThreadedBaseNoPortDetails.Rows.Count = 0 Then
            GetBEThreadedBaseNoPortDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEThreadedBaseNoPort table" + vbCrLf
        End If
    End Function

    '27_04_2010   RAGAVA  NEW DESIGN
    Public Function GetBEDLCastingWithRaisedPortSelectedRowDetails(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow        '15_05_2012   RAGAVA
        GetBEDLCastingWithRaisedPortSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM BEDLCastWithRaisedPort WHERE PartCode = '" + strPartCode + "'"
        GetBEDLCastingWithRaisedPortSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BEDLCastWithRaisedPort"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "BEDLCastWithRaisedPort"
        End If
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BEDLCastWithRaisedPort"
        'Till   Here
        If IsNothing(GetBEDLCastingWithRaisedPortSelectedRowDetails) OrElse GetBEDLCastingWithRaisedPortSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBEDLCastingWithRaisedPortSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEDLCastWithRaisedPort table" + vbCrLf
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "BEDLCastWithRaisedPort"    '07_02_2011 
        End If
    End Function

    '27_04_2010   RAGAVA NEW DESIGN
    Public Function BEBasePlugCastingWithRaisedPortDetails(ByVal strBoreDiameter As String, ByVal strWallThickness As String, _
   ByVal strBushingWidth As String, ByVal strPinHoleSize As String, ByVal strBushingQuantity As String, _
   ByVal strSwingClearance As String, ByVal dblBasePlugOD As Double, ByVal dblOutSidePlugDiameterRequired As Double) As DataTable

        BEBasePlugCastingWithRaisedPortDetails = Nothing
        Try
            '23_11_2011  RAGAVA  COMMENTED... will be Uncommented later when Michael requests
            _strQuery = "SELECT * FROM BasePlugRaisedPort WHERE BoreDiameter = " + strBoreDiameter

            'If strBushingQuantity = 2 Then
            '    ' ANUP CHANGE THE DATABASE NAME ONLY 08-03-2010 04.45
            '    _strQuery = "SELECT * FROM BasePlugRaisedPort WHERE BoreDiameter = " + strBoreDiameter
            '    _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue "
            '    _strQuery += " AND (PinHoleStandardNominalSize <= '" + strPinHoleSize + "' or PinHoleCustomID <= '" + strPinHoleSize + "')"        '02_12_2009   Ragava
            '    _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '    _strQuery += " AND " + (dblOutSidePlugDiameterRequired - 1 / 4).ToString + " <= OutSidePlugDiameter  And OutSidePlugDiameter <= " + (dblOutSidePlugDiameterRequired + 1 / 4).ToString
            '    _strQuery += " AND " + (Val(strBushingWidth) * 2 + 1 / 8).ToString + " <= MilledFlatWidth  And MilledFlatWidth <= " + (Val(strBushingWidth) * 2 * 1.5).ToString
            'ElseIf strBushingQuantity = 1 Then
            '    _strQuery = "SELECT * FROM BasePlugRaisedPort WHERE BoreDiameter = " + strBoreDiameter
            '    _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue "
            '    _strQuery += " AND (PinHoleStandardNominalSize <= '" + strPinHoleSize + "' or PinHoleCustomID <= '" + strPinHoleSize + "')"        '02_12_2009   Ragava
            '    _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '    _strQuery += " AND " + (dblOutSidePlugDiameterRequired - 1 / 4).ToString + " <= OutSidePlugDiameter and OutSidePlugDiameter <= " + (dblOutSidePlugDiameterRequired + 1 / 4).ToString
            '    _strQuery += " AND " + strBushingWidth + " <= MilledFlatWidth "
            'ElseIf strBushingQuantity = 0 Then
            '    _strQuery = "SELECT * FROM BasePlugRaisedPort WHERE BoreDiameter = " + strBoreDiameter
            '    _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue "
            '    _strQuery += " AND (PinHoleStandardNominalSize <= '" + strPinHoleSize + "' or PinHoleCustomID <= '" + strPinHoleSize + "')"        '02_12_2009   Ragava
            '    _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '    _strQuery += " AND " + (dblOutSidePlugDiameterRequired - 1 / 4).ToString + " <= OutSidePlugDiameter  and OutSidePlugDiameter <= " + (dblOutSidePlugDiameterRequired + 1 / 4).ToString
            '    '18_03_2010   RAGAVA
            '    '_strQuery += " AND " + strBushingWidth + " <= MilledFlatWidth and MilledFlatWidth <= " + (Val(strBushingWidth) + 1 / 2).ToString
            '    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlatWidth > 0 Then
            '        _strQuery += " AND '" + (Val(strBushingWidth)).ToString + "' <= MilledFlatWidth and MilledFlatWidth <= '" + (Val(strBushingWidth) + 1 / 2).ToString + "'"
            '    Else
            '        _strQuery += " AND MilledFlatWidth = 'N/A'"
            '    End If
            '    'Till    Here
            'End If

            'TILL   HERE

            BEBasePlugCastingWithRaisedPortDetails = MonarchConnectionObject.GetTable(_strQuery)
            If IsNothing(BEBasePlugCastingWithRaisedPortDetails) OrElse BEBasePlugCastingWithRaisedPortDetails.Rows.Count = 0 Then
                BEBasePlugCastingWithRaisedPortDetails = Nothing
                _strErrorMessage = "Data not retrieved from BasePlugRaisedPort table" + vbCrLf
            End If
        Catch ex As Exception

        End Try

    End Function

    '27_04_2010   RAGAVA  NEW DESIGN
    Public Function GetBEThrededEndRaisedPortSelectedRowDetails(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow       '15_05_2012   RAGAVA
        GetBEThrededEndRaisedPortSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM BEThreadedEndRaisedPort WHERE PartCode = '" + strPartCode + "'"
        GetBEThrededEndRaisedPortSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetBEThrededEndRaisedPortSelectedRowDetails) OrElse GetBEThrededEndRaisedPortSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBEThrededEndRaisedPortSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEThreadedEndRaisedPort table" + vbCrLf
        Else
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BEThreadedEndRaisedPort"
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "BEThreadedEndRaisedPort"
            End If
            'Till  Here
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "BEThreadedEndRaisedPort"    '07_02_2011 
        End If
    End Function

    '27_04_2010   RAGAVA  NEW DESIGN
    '19_05_2010   RAGAVA  Modified
    Public Function GetBECrossTubeCastRaisedPortSelectedRowDetails(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow        '15_05_2012   RAGAVA
        GetBECrossTubeCastRaisedPortSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM BECrossTubeRaisedPort WHERE PartCode = '" + strPartCode + "'"
        GetBECrossTubeCastRaisedPortSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BECrossTubeRaisedPort"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "BECrossTubeRaisedPort"
        End If
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BECrossTubeRaisedPort"
        'Till  Here
        If IsNothing(GetBECrossTubeCastRaisedPortSelectedRowDetails) OrElse GetBECrossTubeCastRaisedPortSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBECrossTubeCastRaisedPortSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from BECrossTubeRaisedPort table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "BECrossTubeRaisedPort"      '07_02_2011 
        End If
    End Function
    '19_05_2010   RAGAVA  NEW DESIGN
    Public Function GetBEDLCastingWithRaisedPortSelectedRowDetails90(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow         '15_05_2012   RAGAVA
        GetBEDLCastingWithRaisedPortSelectedRowDetails90 = Nothing
        _strQuery = "SELECT * FROM BEDLCastWithRaisedPort90 WHERE PartCode = '" + strPartCode + "'"
        GetBEDLCastingWithRaisedPortSelectedRowDetails90 = MonarchConnectionObject.GetDataRow(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BEDLCastWithRaisedPort90"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "BEDLCastWithRaisedPort90"
        End If
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BEDLCastWithRaisedPort90"
        'Till  Here
        If IsNothing(GetBEDLCastingWithRaisedPortSelectedRowDetails90) OrElse GetBEDLCastingWithRaisedPortSelectedRowDetails90.ItemArray.Length <= 0 Then
            GetBEDLCastingWithRaisedPortSelectedRowDetails90 = Nothing
            _strErrorMessage = "Data not retrieved from BEDLCastWithRaisedPort90 table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "BEDLCastWithRaisedPort90"    '07_02_2011 
        End If
    End Function

    '19_05_2010   RAGAVA  NEW DESIGN
    Public Function BECrossTubeCastingRaisedPortDetails90(ByVal strBoreDiameter As String, ByVal strWallThickness As String, _
ByVal strBushingWidth As String, ByVal strPinHoleSize As String, ByVal strBushingQuantity As String, _
ByVal strSwingClearance As String, ByVal strCrossTubeWidth As String, ByVal strOffSet As String, ByVal strTubeOD As String) As DataTable
        BECrossTubeCastingRaisedPortDetails90 = Nothing
        _strQuery = "SELECT * FROM BECrossTubeRaisedPort90 WHERE BoreDiameter = " + strBoreDiameter
        _strQuery += " AND " + strWallThickness + " BETWEEN TubeWallThicknessUpperLimit  AND TubeWallThicknessLowerLimit "
        If strBushingQuantity = 2 Then
            _strQuery += " AND CrossTubeWidth >= " + ((Val(strBushingWidth) * 2) + 0.125).ToString + " AND CrossTubeWidth <= " + ((Val(strBushingWidth) * 2) * 1.5).ToString
        ElseIf strBushingQuantity = 1 Then
            _strQuery += " AND CrossTubeWidth = " + strBushingWidth
        ElseIf strBushingQuantity = 0 Then
            _strQuery += " AND CrossTubeWidth >= " + strCrossTubeWidth + " AND CrossTubeWidth <= " + Val(Val(strCrossTubeWidth) + 0.5).ToString
        End If
        _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
        _strQuery += " AND CrossTubeOD >= " + (Val(strPinHoleSize) + 0.5).ToString
        If Val(strOffSet) > 0 Then
            _strQuery += " AND OffSet >= " + strOffSet
        Else
            _strQuery += " AND OffSet <= 0.100"
        End If
        If Val(strCrossTubeWidth) <= Val(strTubeOD) + 0.25 Then
            _strQuery += " AND SwingClearance >= " + strSwingClearance
        End If

        'ANUP 20-09-2010 START
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.IsStyle_2BushingsIndividualBore Then
            _strQuery += " and Is2BushingsIndividualBore = 'Yes'"
        End If
        'ANUP 20-09-2010 TILL HERE

        BECrossTubeCastingRaisedPortDetails90 = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(BECrossTubeCastingRaisedPortDetails90) OrElse BECrossTubeCastingRaisedPortDetails90.Rows.Count = 0 Then
            BECrossTubeCastingRaisedPortDetails90 = Nothing
            _strErrorMessage = "Data not retrieved from BECrossTubeRaisedPort table" + vbCrLf
        End If
    End Function

    '19_05_2010   RAGAVA  NEW DESIGN
    Public Function BEDLCastingWithRaisedPortDetails90(ByVal strBoreDiameter As String, ByVal strWallThickness As String, _
   ByVal strBushingWidth As String, ByVal strPinHoleSize As String, ByVal strBushingQuantity As String, ByVal strLugThickness As String, _
   ByVal strLugGap As String, ByVal strSwingClearance As String, ByVal strPortType As String) As DataTable
        BEDLCastingWithRaisedPortDetails90 = Nothing
        If strBushingQuantity = 2 Then
            _strQuery = "SELECT * FROM BEDLCastWithRaisedPort90 WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue "
            _strQuery += " AND LugThickness = " + strBushingWidth + " AND PinHole_Combined <= " + strPinHoleSize
            _strQuery += " AND LugGap >= " + strLugGap + " AND LugGap <= " + Val(Val(strLugGap) + 0.25).ToString
            '26_07_2011  RAGAVA  COmmented
            '_strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            _strQuery += " AND PortType = '" + strPortType + "'"
        ElseIf strBushingQuantity = 0 Then
            _strQuery = "SELECT * FROM BEDLCastWithRaisedPort90 WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue "
            _strQuery += " AND LugThickness >= " + strLugThickness + " AND LugThickness <= " + Val(Val(strLugThickness) + 0.25).ToString
            _strQuery += " AND PinHole_Combined <= " + strPinHoleSize
            _strQuery += " AND LugGap >= " + strLugGap + " AND LugGap <= " + Val(Val(strLugGap) + 0.25).ToString
            '26_07_2011  RAGAVA  COmmented
            '_strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            _strQuery += " AND PortType = '" + strPortType + "'"
        End If
        BEDLCastingWithRaisedPortDetails90 = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(BEDLCastingWithRaisedPortDetails90) OrElse BEDLCastingWithRaisedPortDetails90.Rows.Count = 0 Then
            BEDLCastingWithRaisedPortDetails90 = Nothing
            _strErrorMessage = "Data not retrieved from BEDLCastWithRaisedPort90 table" + vbCrLf
        End If
    End Function

    '19_05_2010   RAGAVA  NEW DESIGN
    Public Function GetBEThrededEndRaisedPortSelectedRowDetails90(ByVal strPartCode As String) As DataRow
        GetBEThrededEndRaisedPortSelectedRowDetails90 = Nothing
        _strQuery = "SELECT * FROM BEThreadedEndRaisedPort90 WHERE PartCode = '" + strPartCode + "'"
        GetBEThrededEndRaisedPortSelectedRowDetails90 = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetBEThrededEndRaisedPortSelectedRowDetails90) OrElse GetBEThrededEndRaisedPortSelectedRowDetails90.ItemArray.Length <= 0 Then
            GetBEThrededEndRaisedPortSelectedRowDetails90 = Nothing
            _strErrorMessage = "Data not retrieved from BEThreadedEndRaisedPort90 table" + vbCrLf
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "BEThreadedEndRaisedPort90"    '07_02_2011 
        End If
    End Function

    '19_05_2010     RAGAVA   NEW DESIGN
    Public Function GetBECrossTubeCastRaisedPortSelectedRowDetails90(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow       '15_05_2012    RAGAVA
        GetBECrossTubeCastRaisedPortSelectedRowDetails90 = Nothing
        _strQuery = "SELECT * FROM BECrossTubeRaisedPort90 WHERE PartCode = '" + strPartCode + "'"
        GetBECrossTubeCastRaisedPortSelectedRowDetails90 = MonarchConnectionObject.GetDataRow(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BECrossTubeRaisedPort90"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "BECrossTubeRaisedPort90"
        End If
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "BECrossTubeRaisedPort90"
        'Till  Here
        If IsNothing(GetBECrossTubeCastRaisedPortSelectedRowDetails90) OrElse GetBECrossTubeCastRaisedPortSelectedRowDetails90.ItemArray.Length <= 0 Then
            GetBECrossTubeCastRaisedPortSelectedRowDetails90 = Nothing
            _strErrorMessage = "Data not retrieved from BECrossTubeRaisedPort90 table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "BECrossTubeRaisedPort90"      '07_02_2011 
        End If
    End Function

    '27_04_2010   RAGAVA  NEW DESIGN
    Public Function BECrossTubeCastingRaisedPortDetails(ByVal strBoreDiameter As String, ByVal strWallThickness As String, _
ByVal strBushingWidth As String, ByVal strPinHoleSize As String, ByVal strBushingQuantity As String, _
ByVal strSwingClearance As String, ByVal strCrossTubeWidth As String, ByVal strOffSet As String, ByVal strTubeOD As String) As DataTable
        BECrossTubeCastingRaisedPortDetails = Nothing
        _strQuery = "SELECT * FROM BECrossTubeRaisedPort WHERE BoreDiameter = " + strBoreDiameter
        _strQuery += " AND " + strWallThickness + " BETWEEN TubeWallThicknessUpperLimit  AND TubeWallThicknessLowerLimit "
        If strBushingQuantity = 2 Then
            _strQuery += " AND CrossTubeWidth >= " + ((Val(strBushingWidth) * 2) + 0.125).ToString + " AND CrossTubeWidth <= " + ((Val(strBushingWidth) * 2) * 1.5).ToString
        ElseIf strBushingQuantity = 1 Then
            _strQuery += " AND CrossTubeWidth = " + strBushingWidth
        ElseIf strBushingQuantity = 0 Then
            _strQuery += " AND CrossTubeWidth >= " + strCrossTubeWidth + " AND CrossTubeWidth <= " + Val(Val(strCrossTubeWidth) + 0.5).ToString
        End If
        _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
        _strQuery += " AND CrossTubeOD >= " + (Val(strPinHoleSize) + 0.5).ToString
        If Val(strOffSet) > 0 Then
            _strQuery += " AND OffSet >= " + strOffSet
        Else
            _strQuery += " AND OffSet <= 0.100"
        End If
        If Val(strCrossTubeWidth) <= Val(strTubeOD) + 0.25 Then
            _strQuery += " AND SwingClearance >= " + strSwingClearance
        End If

        'ANUP 20-09-2010 START
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.IsStyle_2BushingsIndividualBore Then
            _strQuery += " and Is2BushingsIndividualBore = 'Yes'"
        End If
        'ANUP 20-09-2010 TILL HERE

        BECrossTubeCastingRaisedPortDetails = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(BECrossTubeCastingRaisedPortDetails) OrElse BECrossTubeCastingRaisedPortDetails.Rows.Count = 0 Then
            BECrossTubeCastingRaisedPortDetails = Nothing
            _strErrorMessage = "Data not retrieved from BECrossTubeRaisedPort table" + vbCrLf
        End If
    End Function


    '27_04_2010   RAGAVA  NEW DESIGN
    Public Function BEDLCastingWithRaisedPortDetails(ByVal strBoreDiameter As String, ByVal strWallThickness As String, _
   ByVal strBushingWidth As String, ByVal strPinHoleSize As String, ByVal strBushingQuantity As String, ByVal strLugThickness As String, _
   ByVal strLugGap As String, ByVal strSwingClearance As String, ByVal strPortType As String) As DataTable
        BEDLCastingWithRaisedPortDetails = Nothing
        If strBushingQuantity = 2 Then
            _strQuery = "SELECT * FROM BEDLCastWithRaisedPort WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue "
            _strQuery += " AND LugThickness = " + strBushingWidth + " AND PinHole_Combined <= " + strPinHoleSize
            _strQuery += " AND LugGap >= " + strLugGap + " AND LugGap <= " + Val(Val(strLugGap) + 0.25).ToString
            '26_07_2011  RAGAVA  COmmented
            '_strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            _strQuery += " AND PortType = '" + strPortType + "'"
        ElseIf strBushingQuantity = 0 Then
            _strQuery = "SELECT * FROM BEDLCastWithRaisedPort WHERE BoreDiameter = " + strBoreDiameter
            _strQuery += " AND " + strWallThickness + " BETWEEN WallThicknessLowerValue AND WallThicknessHigherValue "
            _strQuery += " AND LugThickness >= " + strLugThickness + " AND LugThickness <= " + Val(Val(strLugThickness) + 0.25).ToString
            _strQuery += " AND PinHole_Combined <= " + strPinHoleSize
            _strQuery += " AND LugGap >= " + strLugGap + " AND LugGap <= " + Val(Val(strLugGap) + 0.25).ToString
            '26_07_2011  RAGAVA  COmmented
            '_strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            _strQuery += " AND PortType = '" + strPortType + "'"
        End If
        BEDLCastingWithRaisedPortDetails = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(BEDLCastingWithRaisedPortDetails) OrElse BEDLCastingWithRaisedPortDetails.Rows.Count = 0 Then
            BEDLCastingWithRaisedPortDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEDLCastWithRaisedPort table" + vbCrLf
        End If
    End Function

    Public Function BECrossTubeCastingFlushPortDetails(ByVal strBoreDiameter As String, ByVal strWallThickness As String, _
 ByVal strBushingWidth As String, ByVal strPinHoleSize As String, ByVal strBushingQuantity As String, _
 ByVal strSwingClearance As String, ByVal strCrossTubeWidth As String, ByVal strOffSet As String, ByVal strTubeOD As String) As DataTable
        BECrossTubeCastingFlushPortDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BECrossTubeFlushPort WHERE BoreDiameter = " + strBoreDiameter
        _strQuery += " AND " + strWallThickness + " BETWEEN TubeWallThicknessUpperLimit  AND TubeWallThicknessLowerLimit "
        If strBushingQuantity = 2 Then
            _strQuery += " AND CrossTubeWidth >= " + ((Val(strBushingWidth) * 2) + 0.125).ToString + " AND CrossTubeWidth <= " + ((Val(strBushingWidth) * 2) * 1.5).ToString
        ElseIf strBushingQuantity = 1 Then
            _strQuery += " AND CrossTubeWidth = " + strBushingWidth
        ElseIf strBushingQuantity = 0 Then
            _strQuery += " AND CrossTubeWidth >= " + strCrossTubeWidth + " AND CrossTubeWidth <= " + Val(Val(strCrossTubeWidth) + 0.5).ToString
        End If
        _strQuery += " AND PinHole_Combined <= '" + strPinHoleSize + "'"
        '_strQuery += " AND CrossTubeOD >= " + (Val(strPinHoleSize) + 0.5).ToString
        _strQuery += " AND CrossTubeOD >= " + (Val(strPinHoleSize) + 0.5 - 0.015).ToString        '26_09_2011   RAGAVA
        If Val(strOffSet) > 0 Then
            _strQuery += " AND OffSet >= " + strOffSet
        Else
            _strQuery += " AND OffSet <= 0.100"
        End If
        If Val(strCrossTubeWidth) <= Val(strTubeOD) + 0.25 Then
            _strQuery += " AND SwingClearance >= " + strSwingClearance       '27_04_2010   RAGAVA  Column Name Modified
        End If

        'ANUP 20-09-2010 START
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmTubeDetails.IsStyle_2BushingsIndividualBore Then
            _strQuery += " and Is2BushingsIndividualBore = 'Yes'"
        End If
        'ANUP 20-09-2010 TILL HERE

        BECrossTubeCastingFlushPortDetails = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(BECrossTubeCastingFlushPortDetails) OrElse BECrossTubeCastingFlushPortDetails.Rows.Count = 0 Then
            BECrossTubeCastingFlushPortDetails = Nothing
            _strErrorMessage = "Data not retrieved from BECrossTubeCastingWithoutPort table" + vbCrLf
        End If
    End Function

    Public Function GetBECrossTubeCastFlushPortSelectedRowDetails(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow      '15_05_2012   RAGAVA
        GetBECrossTubeCastFlushPortSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BECrossTubeFlushPort WHERE PartCode = '" + strPartCode + "'"
        GetBECrossTubeCastFlushPortSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BECrossTubeFlushPort"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BECrossTubeFlushPort"
        End If
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BECrossTubeFlushPort"
        'Till   Here
        If IsNothing(GetBECrossTubeCastFlushPortSelectedRowDetails) OrElse GetBECrossTubeCastFlushPortSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBECrossTubeCastFlushPortSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from BECrossTubeFluishPort table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "Welded.BECrossTubeFlushPort"      '07_02_2011 
        End If
    End Function

    Public Function GetBEThrededEndCastWithOutPortSelectedRowDetails(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow       '15_05_2012   RAGAVA
        GetBEThrededEndCastWithOutPortSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BEThreadedBaseNoPort WHERE PartCode = '" + strPartCode + "'"
        GetBEThrededEndCastWithOutPortSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        '15_05_2012   RAGAVA
        If str1st_2nd = "1" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEThreadedBaseNoPort"
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BEThreadedBaseNoPort"
        End If
        If IsNothing(GetBEThrededEndCastWithOutPortSelectedRowDetails) OrElse GetBEThrededEndCastWithOutPortSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBEThrededEndCastWithOutPortSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEThreadedBaseNoPort table" + vbCrLf
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = ""
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = ""
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "Welded.BEThreadedBaseNoPort"    '07_02_2011 
        End If
    End Function

    Public Function GetBEThrededEndFlushPortSelectedRowDetails(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow   '15_05_2012   RAGAVA
        GetBEThrededEndFlushPortSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BEThreadedEndFlushPort WHERE PartCode = '" + strPartCode + "'"
        GetBEThrededEndFlushPortSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetBEThrededEndFlushPortSelectedRowDetails) OrElse GetBEThrededEndFlushPortSelectedRowDetails.ItemArray.Length <= 0 Then
            GetBEThrededEndFlushPortSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEThreadedEndFlushPort table" + vbCrLf
        Else
            '15_05_2012   RAGAVA
            If str1st_2nd = "1" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.BEThreadedEndFlushPort"
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.BEThreadedEndFlushPort"
            End If
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndCastingTableName = "Welded.BEThreadedEndFlushPort"    '07_02_2011 
        End If
    End Function

    Public Function GetBEThreadedBaseFlushPortDetails(ByVal dblBoreDiameter As Double, ByVal dblWallThickness As Double, ByVal dblThreadSize As Double, _
   ByVal dblThreadLength As Double, ByVal dblSafetyFactor As Double) As DataTable
        GetBEThreadedBaseFlushPortDetails = Nothing
        _strQuery = "select * from welded.BEThreadedEndFlushPort where BoreDiameter = " + dblBoreDiameter.ToString
        _strQuery += " and " + dblWallThickness.ToString + " between TubeWallThickness_LowerLimit and TubeWallThickness_UpperLimit "      '12_03_2010  RAGAVA   Space is added
        _strQuery += "and ThreadLength >= " + dblThreadLength.ToString + " and ThreadSize = " + dblThreadSize.ToString
        GetBEThreadedBaseFlushPortDetails = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetBEThreadedBaseFlushPortDetails) OrElse GetBEThreadedBaseFlushPortDetails.Rows.Count = 0 Then
            GetBEThreadedBaseFlushPortDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEThreadedEndFlushPort table" + vbCrLf
        End If
    End Function

    Public Function GetWeldSize_RECT(ByVal dblRodDiameter As Double) As Double
        GetWeldSize_RECT = 0
        _strQuery = "select WeldSize from Welded.RodWeldData where WeldType='ManualWeld' and Configuration='CrossTube' and RodDiameter=" + dblRodDiameter.ToString
        GetWeldSize_RECT = MonarchConnectionObject.GetValue(_strQuery)
        If IsNothing(GetWeldSize_RECT) OrElse GetWeldSize_RECT = 0 Then
            GetWeldSize_RECT = 0
            _strErrorMessage = "Data not retrieved from RodWeldData table" + vbCrLf
        End If
    End Function

    'TODO: ANUP 28-04-2010 01.03pm
    Public Function GetWeldSize_ForFabrication(ByVal dblRodDiameter As Double, ByVal CalWeldSize As Double, ByVal Configuration As clsWeldedCylinderFunctionalClass.ConfigurationTypes, ByVal WeldType As clsWeldedCylinderFunctionalClass.WeldType) As DataTable
        GetWeldSize_ForFabrication = Nothing
        Try
            Dim strConfigurationENum As String = [Enum].GetName(GetType(clsWeldedCylinderFunctionalClass.ConfigurationTypes), Configuration)
            Dim strWeldTypeENum As String = [Enum].GetName(GetType(clsWeldedCylinderFunctionalClass.WeldType), WeldType)
            _strQuery = "select WeldSize, WeldPreparation from Welded.RodWeldData where WeldType = '" + strWeldTypeENum + "' and Configuration = '" + strConfigurationENum + "' and RodDiameter = " + dblRodDiameter.ToString + " and WeldSize >= " + CalWeldSize.ToString
            GetWeldSize_ForFabrication = MonarchConnectionObject.GetTable(_strQuery)
            If IsNothing(GetWeldSize_ForFabrication) OrElse GetWeldSize_ForFabrication.Rows.Count <= 0 Then
                GetWeldSize_ForFabrication = Nothing
                _strErrorMessage = "Data not retrieved from RodWeldData table" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function

    'TODO: ANUP 11-05-2010 12.44pm
    Public Function GetWeldSize_Lathe_ForFabrication(ByVal dblRodDiameter As Double, ByVal CalWeldSize As Double) As DataTable
        GetWeldSize_Lathe_ForFabrication = Nothing
        Try
            _strQuery = "select WeldSize, WeldPreparation from Welded.REULug_LatheWeldDetails where  RodDiameter = " + dblRodDiameter.ToString + "  and  WeldSize >=" + CalWeldSize.ToString
            GetWeldSize_Lathe_ForFabrication = MonarchConnectionObject.GetTable(_strQuery)
            If IsNothing(GetWeldSize_Lathe_ForFabrication) OrElse GetWeldSize_Lathe_ForFabrication.Rows.Count <= 0 Then
                GetWeldSize_Lathe_ForFabrication = Nothing
                _strErrorMessage = "Data not retrieved from REULug_LatheWeldDetails table" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function GetWeldSize_ForCasting(ByVal CalWeldSize As Double, ByVal dblRodDia As Double) As DataTable
        GetWeldSize_ForCasting = Nothing
        Try

            '_strQuery = "select WeldSizeNumeric, Width, Radius from Welded.REWeldSizeDetails_Casting where RodDiameter= " + dblRodDia.ToString + "  and  WeldSizeNumeric >=" + CalWeldSize.ToString
            _strQuery = "select WeldSizeNumeric, Width, Radius from RE_JGroveDetails where WeldSizeNumeric >=" + CalWeldSize.ToString         '11_04_2011   RAGAVA  Query modified
            GetWeldSize_ForCasting = MonarchConnectionObject.GetTable(_strQuery)
            If IsNothing(GetWeldSize_ForCasting) OrElse GetWeldSize_ForCasting.Rows.Count <= 0 Then
                GetWeldSize_ForCasting = Nothing
                _strErrorMessage = "Data not retrieved from REWeldSizeDetails_Casting table" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function GetJGroveWidthOrRadius_ForFabrication(ByVal dblWeldSize As Double) As DataRow
        GetJGroveWidthOrRadius_ForFabrication = Nothing
        Try
            '_strQuery = "select Width, Radius from dbo.RE_JGroveDetails where WeldSizeNumeric = " + dblWeldSize.ToString
            _strQuery = "select WeldSizeNumeric, (Width + Convert(numeric(10,4),isnull(Extension,'0'))) as Width, Radius from dbo.RE_JGroveDetails where WeldSizeNumeric =" + dblWeldSize.ToString
            GetJGroveWidthOrRadius_ForFabrication = MonarchConnectionObject.GetDataRow(_strQuery)
            If IsNothing(GetJGroveWidthOrRadius_ForFabrication) OrElse GetJGroveWidthOrRadius_ForFabrication.ItemArray.Length <= 0 Then
                GetJGroveWidthOrRadius_ForFabrication = Nothing
                _strErrorMessage = "Data not retrieved from RE_JGroveDetails table" + vbCrLf
            End If

        Catch ex As Exception

        End Try
    End Function
    '****************

    Public Function GetRECrossTubeCastingDetailsSelectedRowDetails(ByVal strPartCode As String, Optional ByVal str1st_2nd As String = "1") As DataRow       '15_05_2012   RAGAVA
        GetRECrossTubeCastingDetailsSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.RECrossTubeCasting WHERE PartCode='" + strPartCode + "'"
        GetRECrossTubeCastingDetailsSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        '1_03_2010 Aruna
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnd_NewDesign_TableName = "Welded.RECrossTubeCasting"
        If IsNothing(GetRECrossTubeCastingDetailsSelectedRowDetails) OrElse GetRECrossTubeCastingDetailsSelectedRowDetails.ItemArray.Length <= 0 Then
            GetRECrossTubeCastingDetailsSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from RECrossTubeDetails table" + vbCrLf
        Else
            ''15_05_2012   RAGAVA
            'If str1st_2nd = "1" Then
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName = "Welded.RECrossTubeCasting"
            'Else
            '    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEnd_NewDesign_TableName2 = "Welded.RECrossTubeCasting"
            'End If
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndCastingTableName = "Welded.RECrossTubeCasting"    '07_02_2011 
        End If
    End Function

    Public Function GetRECrossTubeDetailsSelectedRowDetails(ByVal strPartCode As String) As DataRow
        GetRECrossTubeDetailsSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BECrossTubeDetails WHERE PartCode='" + strPartCode + "'"
        GetRECrossTubeDetailsSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetRECrossTubeDetailsSelectedRowDetails) OrElse GetRECrossTubeDetailsSelectedRowDetails.ItemArray.Length <= 0 Then
            GetRECrossTubeDetailsSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from RECrossTubeDetails table" + vbCrLf
        End If
    End Function

    '27_02_2010
    Public Function RECrossTubeCastingDetails(ByVal dblRodDiameter As Double, ByVal dblWeldSize As Double, ByVal dblCrossTubeWidth As Double, _
 ByVal dblBushingWidth As Double, ByVal dblRequiredPinHoleSize As Double, ByVal dblCrossTubeOD As Double, ByVal dblBushingQuantity As Double) As DataTable
        RECrossTubeCastingDetails = Nothing
        _strQuery = "select * from Welded.RECrossTubeCasting where RodDiameter =" + dblRodDiameter.ToString
        '_strQuery += " and WeldSize=" + dblWeldSize.ToString
        _strQuery += " and WeldSize >= " + dblWeldSize.ToString         '05_08_2011   RAGAVA
        If dblBushingQuantity = 2 Then
            _strQuery += " and CrossTubeWidth>=" + ((Val(dblBushingQuantity) * 2) + 0.125).ToString + " and CrossTubeWidth<=" + ((Val(dblBushingQuantity) * 2) * 1.5).ToString
        ElseIf dblBushingQuantity = 1 Then
            _strQuery += " and CrossTubeWidth=" + dblBushingWidth.ToString
        ElseIf dblBushingQuantity = 0 Then
            _strQuery += " and CrossTubeWidth>=" + dblCrossTubeWidth.ToString + " and CrossTubeWidth<=" + (Val(dblCrossTubeWidth) + 0.5).ToString
        End If
        'ANUP 12-10-2010 START
        _strQuery += " and PinHoleSizeCombined<='" + dblRequiredPinHoleSize.ToString + "'"
        'ANUP 12-10-2010 TILL HERE
        'If dblCrossTubeOD < dblRequiredPinHoleSize + 0.5 Then
        '    dblCrossTubeOD = dblRequiredPinHoleSize + 0.5
        'End If

        'ANUP 20-09-2010 START
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.IsStyle_2BushingsIndividualBore Then
            _strQuery += " and Is2BushingsIndividualBore = 'Yes' "
        End If
        'ANUP 20-09-2010 TILL HERE

        _strQuery += " and CrossTubeOD>=" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CrossTubeOD_RodEnd.ToString 'dblCrossTubeOD.ToString
        RECrossTubeCastingDetails = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(RECrossTubeCastingDetails) OrElse RECrossTubeCastingDetails.Rows.Count = 0 Then
            RECrossTubeCastingDetails = Nothing
            _strErrorMessage = "Data not retrieved from RECrossTubeCasting table" + vbCrLf
        End If
    End Function

    Public Function RECrossTubeDetails(ByVal strBushingQuantity As String, ByVal strBushingWidth As String, ByVal strPinHoleSize As String, _
    ByVal strSwingClearance As String, ByVal strCrossTubeWidth As String) As DataTable
        RECrossTubeDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BECrossTubeDetails WHERE PinHoleCombined <= '" + strPinHoleSize + "'"
        _strQuery += " AND Diameter >= " + (Val(strPinHoleSize) + 0.5).ToString
        If strBushingQuantity = 2 Then
            _strQuery += " AND Width >= " + ((Val(strBushingWidth) * 2) + 0.125).ToString + "AND Width <= " + ((Val(strBushingWidth) * 2) * 1.5).ToString
        ElseIf strBushingQuantity = 1 Then
            _strQuery += " AND Width = " + strBushingWidth
        ElseIf strBushingQuantity = 0 Then
            _strQuery += " AND Width >= " + strCrossTubeWidth + " AND Width <= " + Val(Val(strCrossTubeWidth) + 0.25).ToString
        End If

        'ANUP 20-09-2010 START
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmRodEndConfiguration.IsStyle_2BushingsIndividualBore Then
            _strQuery += " and Is2BushingsIndividualBore = 'Yes' "
        End If
        'ANUP 20-09-2010 TILL HERE

        RECrossTubeDetails = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(RECrossTubeDetails) OrElse RECrossTubeDetails.Rows.Count = 0 Then
            RECrossTubeDetails = Nothing
            _strErrorMessage = "Data not retrieved from BECrossTubeDetails table" + vbCrLf
        End If
    End Function

    Public Function BEULugDetailsLathe(ByVal strBushingQuantity As String, ByVal strBushingWidth As String, ByVal strPinHoleSize As String, _
       ByVal strLugThickness As String, ByVal strLugGap As String, ByVal strBoreDiameter As String) As DataTable
        BEULugDetailsLathe = Nothing
        If strBushingQuantity = 2 Then
            _strQuery = "SELECT * FROM Welded.BEULDetails WHERE LugThickness = " + strBushingWidth + " AND PinHoleCombined <= '" + strPinHoleSize + "'"
            '_strQuery += " AND LugWidth >= " + strBoreDiameter        '14_04_2010   RAGAVA
            _strQuery += " AND LugGap >= " + strLugGap + " AND LugGap <= " + Val(Val(strLugGap) + 0.25).ToString
            '_strQuery += " AND (LugGap+LugThickness) >= " + strBoreDiameter          '14_04_2010   RAGAVA
            _strQuery += " AND Lathe_Manual = 'Lathe'"
        ElseIf strBushingQuantity = 0 Then
            _strQuery = "SELECT * FROM Welded.BEULDetails WHERE LugThickness >= " + strLugThickness
            _strQuery += " AND LugThickness <= " + Val(Val(strLugThickness) + 0.25).ToString + " AND PinHoleCombined <= '" + strPinHoleSize + "'"
            '_strQuery += " AND LugWidth >= " + strBoreDiameter         '14_04_2010   RAGAVA
            _strQuery += " AND LugGap >= " + strLugGap + " AND LugGap <= " + Val(Val(strLugGap) + 0.25).ToString
            '_strQuery += " AND (LugGap+LugThickness) >= " + strBoreDiameter        '14_04_2010   RAGAVA
            _strQuery += " AND Lathe_Manual = 'Lathe'"
        End If
        BEULugDetailsLathe = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(BEULugDetailsLathe) OrElse BEULugDetailsLathe.Rows.Count = 0 Then
            BEULugDetailsLathe = Nothing
            _strErrorMessage = "Data not retrieved from BEULDetails table" + vbCrLf
        End If
    End Function

    Public Function BEULugDetailsManual(ByVal strBushingQuantity As String, ByVal strBushingWidth As String, ByVal strPinHoleSize As String, _
      ByVal strLugThickness As String, ByVal strLugGap As String, ByVal strBoreDiameter As String) As DataTable
        BEULugDetailsManual = Nothing
        If strBushingQuantity = 2 Then
            _strQuery = "SELECT * FROM Welded.BEULDetails WHERE LugThickness = " + strBushingWidth + " AND PinHoleCombined <= '" + strPinHoleSize + "'"
            '_strQuery += " AND LugWidth >= " + strBoreDiameter            '14_04_2010   RAGAVA
            _strQuery += " AND LugGap >= " + strLugGap + " AND LugGap <= " + Val(Val(strLugGap) + 0.25).ToString
            '_strQuery += " AND (LugGap+LugThickness) >= " + strBoreDiameter            '14_04_2010   RAGAVA
            _strQuery += " AND Lathe_Manual = 'Manual'"
        ElseIf strBushingQuantity = 0 Then
            _strQuery = "SELECT * FROM Welded.BEULDetails WHERE LugThickness >= " + strLugThickness
            _strQuery += " AND LugThickness <= " + Val(Val(strLugThickness) + 0.25).ToString + " AND PinHoleCombined <= '" + strPinHoleSize + "'"
            '_strQuery += " AND LugWidth >= " + strBoreDiameter        '14_04_2010   RAGAVA
            _strQuery += " AND LugGap >= " + strLugGap + " AND LugGap <= " + Val(Val(strLugGap) + 0.25).ToString
            '_strQuery += " AND (LugGap+LugThickness) >= " + strBoreDiameter           '14_04_2010   RAGAVA
            _strQuery += " AND Lathe_Manual = 'Manual'"
        End If
        BEULugDetailsManual = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(BEULugDetailsManual) OrElse BEULugDetailsManual.Rows.Count = 0 Then
            BEULugDetailsManual = Nothing
            _strErrorMessage = "Data not retrieved from BEULDetails table" + vbCrLf
        End If
    End Function


    Public Function GetWallThicknessUpperAndLowerLimits(ByVal boreDiameter As Double, ByVal workingPressure As Double) As DataRow
        GetWallThicknessUpperAndLowerLimits = Nothing
        _strQuery = "SELECT  MIN(TUBEWALLTHICKNESS) AS WALLTHICKNESSLOWERLIMIT, MAX(TUBEWALLTHICKNESS)AS WALLTHICKNESSUPPERLIMIT FROM WELDED.TUBEDETAILS WHERE BOREDIAMETER=" + boreDiameter.ToString + "AND WORKINGPRESSURE>=" + workingPressure.ToString
        GetWallThicknessUpperAndLowerLimits = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetWallThicknessUpperAndLowerLimits) OrElse GetWallThicknessUpperAndLowerLimits.ItemArray.Length <= 0 Then
            GetWallThicknessUpperAndLowerLimits = Nothing
            _strErrorMessage = "Data not retrieved from Welded.TubeDetails Table" + vbCrLf
        End If
    End Function
    Public Function GetPortBossDiaAndBaseDia(ByVal boreDiameter As Double) As DataRow
        GetPortBossDiaAndBaseDia = Nothing
        _strQuery = "SELECT  BaseDia,PortBossDia FROM WELDED.benewcylinderDesignTable  WHERE BOREDIAMETER=" + boreDiameter.ToString + _
                                 " and MinWallThickness= '" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + "'"

        '06_09_2010   RAGAVA
        If ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeBaseEnd.Text.IndexOf("3/4") <> -1 Then
            _strQuery = _strQuery & " order by PortBossDia Desc"
        End If
        'Till   Here
        GetPortBossDiaAndBaseDia = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetPortBossDiaAndBaseDia) OrElse GetPortBossDiaAndBaseDia.ItemArray.Length <= 0 Then
            GetPortBossDiaAndBaseDia = Nothing
            _strErrorMessage = "Data not retrieved from Welded.TubeDetails Table" + vbCrLf
        End If
    End Function

    '------------------Welded data class-------------------


    Public Function GetREDoubleLugCastingDetailsSelectedRowDetails(ByVal strPartCode As String) As DataRow

        GetREDoubleLugCastingDetailsSelectedRowDetails = Nothing
        _strQuery = "select * from Welded.REDLCasting where PartCode='" + strPartCode + "'"
        GetREDoubleLugCastingDetailsSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetREDoubleLugCastingDetailsSelectedRowDetails) OrElse GetREDoubleLugCastingDetailsSelectedRowDetails.ItemArray.Length <= 0 Then
            GetREDoubleLugCastingDetailsSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from REDLCasting table" + vbCrLf
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndCastingTableName = "Welded.REDLCasting"    '07_02_2011 
        End If
    End Function

    Public Function REDLCastingDetails(ByVal strRodDiameter As String, ByVal strWeldSize As String, _
     ByVal strBushingWidth As String, ByVal strPinHoleSize As String, ByVal strBushingQuantity As String, ByVal strLugThickness As String, _
     ByVal strLugGap As String, ByVal strSwingClearance As String) As DataTable
        REDLCastingDetails = Nothing
        If strBushingQuantity = 2 Then
            _strQuery = "SELECT * FROM Welded.REDLCasting WHERE RodDiameter = " + strRodDiameter
            _strQuery += " AND WeldSize>=" + strWeldSize
            _strQuery += " AND LugThickness = " + strBushingWidth + " AND PinHoleSizeCombined <= " + strPinHoleSize
            _strQuery += " AND LugGap >= " + strLugGap + " AND LugGap <= " + Val(Val(strLugGap) + 0.25).ToString
            'MANJULA 09-02-2012
            ' _strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

        ElseIf strBushingQuantity = 0 Then
            _strQuery = "SELECT * FROM Welded.REDLCasting WHERE RodDiameter = " + strRodDiameter
            _strQuery += " AND WeldSize>=" + strWeldSize
            _strQuery += " AND LugThickness >= " + strLugThickness + " AND LugThickness <= " + Val(Val(strLugThickness) + 0.25).ToString
            _strQuery += " AND PinHoleSizeCombined <= " + strPinHoleSize
            _strQuery += " AND LugGap >= " + strLugGap + " AND LugGap <= " + Val(Val(strLugGap) + 0.25).ToString
            'MANJULA 09-02-2012
            '_strQuery += " AND SwingClearanceRadius >= " + strSwingClearance + "  AND SwingClearanceRadius <= " + Val(Val(strSwingClearance) * 1.25).ToString
            '*********

        End If
        REDLCastingDetails = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(REDLCastingDetails) OrElse REDLCastingDetails.Rows.Count = 0 Then
            REDLCastingDetails = Nothing
            _strErrorMessage = "Data not retrieved from BEDLCastWithOutPort table" + vbCrLf
        End If
    End Function

    Public Function GetWeldSize_REDLCasting(ByVal dblRodDiameter As Double) As Double
        GetWeldSize_REDLCasting = 0
        If dblRodDiameter < 1.75 Then
            _strQuery = "select WeldSize from Welded.REDLCasting where RodDiameter < 1.75"
        Else
            _strQuery = "select WeldSize from Welded.REDLCasting where RodDiameter >= 1.75"
        End If
        '_strQuery = "select WeldSize from Welded.REDLCasting where RodDiameter=" + dblRodDiameter.ToString
        GetWeldSize_REDLCasting = MonarchConnectionObject.GetValue(_strQuery)
        If IsNothing(GetWeldSize_REDLCasting) OrElse GetWeldSize_REDLCasting = 0 Then
            GetWeldSize_REDLCasting = 0
            _strErrorMessage = "Data not retrieved from RodWeldData table" + vbCrLf
        End If
    End Function

    Public Function DoubleLugThreadedDetails_RE(ByVal strRodDiameter As String, ByVal strPinHoleSize As String, ByVal strCylinderPullForce As String, ByVal strPinHoleTypeThreaded As String, ByVal strClass As String) As DataTable

        DoubleLugThreadedDetails_RE = Nothing

        _strQuery = "select * from Welded.REDLThreaded where ThreadSize <=" + strRodDiameter
        'ANUP 13-10-2010 START
        _strQuery += " and " + strCylinderPullForce + "<= MaxPullForceClass" + strClass + " and PinHoleType='" + strPinHoleTypeThreaded + "'"
        'ANUP 13-10-2010 TILL HERE
        _strQuery += " and PinHoleStandard =" + strPinHoleSize

        DoubleLugThreadedDetails_RE = MonarchConnectionObject.GetTable(_strQuery)

        If IsNothing(DoubleLugThreadedDetails_RE) OrElse DoubleLugThreadedDetails_RE.Rows.Count = 0 Then

            DoubleLugThreadedDetails_RE = Nothing
            _strErrorMessage = "Data not retrieved from REDLThreaded table" + vbCrLf

        End If

    End Function

    Public Function GetREDoubleLugThreadedSelectedRowDetails(ByVal strPartCode As String) As DataRow

        GetREDoubleLugThreadedSelectedRowDetails = Nothing
        _strQuery = "select * from Welded.REDLThreaded where PartCode ='" + strPartCode + "'"
        GetREDoubleLugThreadedSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetREDoubleLugThreadedSelectedRowDetails) OrElse GetREDoubleLugThreadedSelectedRowDetails.ItemArray.Length <= 0 Then

            GetREDoubleLugThreadedSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from REDLThreaded table" + vbCrLf
        End If

    End Function

    '_____________________________________________________________________________________________________________________________________________

    Public Function GetREBESingleLugDetails_FabricationSelectedRowDetails(ByVal strPartCode As String) As DataRow
        GetREBESingleLugDetails_FabricationSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BESingleLugDetails WHERE PartCode = '" + strPartCode + "'"
        GetREBESingleLugDetails_FabricationSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        '24_02_2010 Aruna
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnd_NewDesign_TableName = "Welded.BESingleLugDetails"

        If IsNothing(GetREBESingleLugDetails_FabricationSelectedRowDetails) OrElse GetREBESingleLugDetails_FabricationSelectedRowDetails.ItemArray.Length <= 0 Then
            GetREBESingleLugDetails_FabricationSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from Welded.BESingleLugDetails table" + vbCrLf
            '24_02_2010 Aruna
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnd_NewDesign_TableName = ""

        End If
    End Function

    Public Function GetREBEBHDetails_FabricationSelectedRowDetails(ByVal strPartCode As String) As DataRow
        GetREBEBHDetails_FabricationSelectedRowDetails = Nothing
        _strQuery = "SELECT * FROM Welded.BEBHDetails WHERE PartCode = '" + strPartCode + "'"
        GetREBEBHDetails_FabricationSelectedRowDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        '24_02_2010 Aruna
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnd_NewDesign_TableName = "Welded.BEBHDetails"

        If IsNothing(GetREBEBHDetails_FabricationSelectedRowDetails) OrElse GetREBEBHDetails_FabricationSelectedRowDetails.ItemArray.Length <= 0 Then
            GetREBEBHDetails_FabricationSelectedRowDetails = Nothing
            _strErrorMessage = "Data not retrieved from Welded.BEBHDetails table" + vbCrLf
            '24_02_2010 Aruna
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEnd_NewDesign_TableName = ""

        End If
    End Function

    Public Function GetMaxPartCode(ByVal code As String, ByVal tableName As String) As String
        _strQuery = "SELECT MAX(" & code & ") FROM" & tableName
        GetMaxPartCode = MonarchConnectionObject.GetValue(_strQuery)
        If IsNothing(GetMaxPistonCode) Then
            GetMaxPartCode = Nothing
            _strErrorMessage = "Data not retrieved from PistonDetails table" + vbCrLf
        End If
    End Function
    '17_02_2010

    Public Function GetMaxWeldedSeriesCode(ByVal strTableName As String) As String
        GetMaxWeldedSeriesCode = Nothing
        Try
            _strQuery = "Delete from " + strTableName + " where codeStatus=0"
            MonarchConnectionObject.ExecuteQuery(_strQuery)
            _strQuery = "SELECT MAX(CodeNumber) FROM " + strTableName + " Where CodeStatus=1"
            GetMaxWeldedSeriesCode = MonarchConnectionObject.GetValue(_strQuery)

            If IsNothing(GetMaxWeldedSeriesCode) Then
                GetMaxWeldedSeriesCode = Nothing
            End If
        Catch ex As Exception

        End Try
    End Function


    '17_02_2010

    Public Function SetCodeStatus() As String
        SetCodeStatus = Nothing
        Try
            _strQuery = "update  welded.WeldedCylinderCodeNumber set codeStatus=1 where codeNumber=" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber
            MonarchConnectionObject.ExecuteQuery(_strQuery)
        Catch ex As Exception
        End Try
    End Function

    'TODO: 18-02-10 for Threaded
    Public Function GetThreadedHeadDetails(ByVal strBoreDiameter As String) As DataRow
        GetThreadedHeadDetails = Nothing
        _strQuery = "SELECT * FROM Welded.ThreadedHeads WHERE BoreDiameter = '" + strBoreDiameter + "'"
        GetThreadedHeadDetails = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(GetThreadedHeadDetails) OrElse GetThreadedHeadDetails.ItemArray.Length <= 0 Then
            GetThreadedHeadDetails = Nothing
            _strErrorMessage = "Data not retrieved from ThreadedHeads table" + vbCrLf
        End If
    End Function

    Public Function GetSingle_DoubleRadii(ByVal strPartCode As String) As String
        _strQuery = "select Single_DoubleRadii from Welded.BEULDetails where PartCode ='" + strPartCode + "'"
        GetSingle_DoubleRadii = MonarchConnectionObject.GetValue(_strQuery)
        If IsNothing(GetSingle_DoubleRadii) Then
            GetSingle_DoubleRadii = Nothing
            _strErrorMessage = "Data not retrieved from BEULDetails table" + vbCrLf
        End If

    End Function

    'Anup 26-02-10
    'Public Function GetButtonToPartCenter(ByVal dblNominalBoreDia As Double, ByVal dblTubeWallThickness As Double, ByVal dblPortDiameter As Double) As Double
    '    GetButtonToPartCenter = Nothing
    '    _strQuery = "select ButtonToPartCenter from Welded.PortIntegralDetails where NominalBoreDia=" + dblNominalBoreDia + "and TubeWallThickness=" + dblTubeWallThickness + _
    '                                                        "and PortDiameter=" + dblPortDiameter
    '    GetButtonToPartCenter = MonarchConnectionObject.GetValue(_strQuery)
    '    If IsNothing(GetButtonToPartCenter) Then
    '        GetButtonToPartCenter = Nothing
    '        _strErrorMessage = "Data not retrieved from PortIntegralDetails table" + vbCrLf
    '    End If
    'End Function

    Public Function GetButtonToPartCenter(ByVal strNominalBoreDia As String, ByVal strTubeWallThickness As String, ByVal strPortDiameter As String) As Double
        GetButtonToPartCenter = Nothing
        '_strQuery = "select ButtonToPartCenter from Welded.PortIntegralDetails where NominalBoreDia=" + strNominalBoreDia + "and TubeWallThickness=" + strTubeWallThickness + _
        '                                                    "and PortDiameter=" + strPortDiameter
        _strQuery = "select ButtonToPartCenter from Welded.PortIntegralDetails where NominalBoreDia=" + strNominalBoreDia + "and TubeWallThickness=" + strTubeWallThickness + _
                                                            " and PortDiameter=" + strPortDiameter         '12_03_2010       RAGAVA
        GetButtonToPartCenter = MonarchConnectionObject.GetValue(_strQuery)
        If IsNothing(GetButtonToPartCenter) Then
            GetButtonToPartCenter = Nothing
            _strErrorMessage = "Data not retrieved from PortIntegralDetails table" + vbCrLf
        End If
    End Function
    '****************

    Public Function GetLugWidthForComparision(ByVal dblLugWidth As Double) As Double
        GetLugWidthForComparision = Nothing
        _strQuery = "select top 1 LugWidth from dbo.LugWidthComparision_SLFabrication where LugWidth >" + dblLugWidth.ToString + " order by LugWidth asc "
        GetLugWidthForComparision = MonarchConnectionObject.GetValue(_strQuery)
        If IsNothing(GetLugWidthForComparision) Then
            GetLugWidthForComparision = Nothing
            _strErrorMessage = "Data not retrieved from LugWidthComparision_SLFabrication table" + vbCrLf
        End If
    End Function

#End Region

#Region "Configuration Related Database Logics"
    Public Function UpdateRecordIntoWeldedConfigurations_PartCodeTable(ByVal TableName As String, ByVal PartCode As String) As Boolean
        UpdateRecordIntoWeldedConfigurations_PartCodeTable = False
        Try
            _strQuery = "update" + TableName + " set ManufacturedPartCode='" + PartCode + "'"
            UpdateRecordIntoWeldedConfigurations_PartCodeTable = True
        Catch ex As Exception

        End Try
    End Function
    ' ''24_02_2010   RAGAVA
    ''Public Function GetPurchaseAndManufactureCode(ByVal strPartName As String) As String
    ''    GetPurchaseAndManufactureCode = Nothing
    ''    Try
    ''        Dim strUpdateQuery As String = String.Empty
    ''        _strQuery = "select Manufactured,Purchased from Welded.Configurations_manufactured_purchased where Configuration_Type = '" + strPartName + "'"
    ''        Dim ObjDr As DataRow = MonarchConnectionObject.GetDataRow(_strQuery)
    ''        If ObjDr("Manufactured") = True Then
    ''            _strQuery = "Select ManufacturedPartCode from welded.Configurations_partcode"
    ''            strUpdateQuery = "Update welded.Configurations_partcode set ManufacturedPartCode = '"
    ''        ElseIf ObjDr("Purchased") = True Then
    ''            _strQuery = "Select PurchasedPartCode from welded.Configurations_partcode"
    ''            strUpdateQuery = "Update welded.Configurations_partcode set PurchasedPartCode = '"
    ''        End If
    ''        Dim strCodeNumber As Double = MonarchConnectionObject.GetValue(_strQuery)
    ''        strUpdateQuery += (strCodeNumber + 1).ToString + "'"
    ''        If (strCodeNumber + 1 >= 750000 AndAlso strCodeNumber + 1 <= 759000) Or (strCodeNumber + 1 >= 720000 AndAlso strCodeNumber + 1 <= 729999) Then
    ''            Dim bln As Boolean = MonarchConnectionObject.ExecuteQuery(strUpdateQuery)
    ''            GetPurchaseAndManufactureCode = strCodeNumber
    ''        Else
    ''            MsgBox("Code generated for manufactured or purchased part is exceeding its maximum limit")
    ''        End If

    ''        If IsNothing(GetPurchaseAndManufactureCode) Then
    ''            GetPurchaseAndManufactureCode = Nothing
    ''        End If
    ''    Catch ex As Exception
    ''    End Try
    ''End Function
#End Region

    'Sandeep 24-02-10-5:30pm
    Public Function GetPortSizeFromDB(ByVal strPortSize As String, ByVal strPortType As String, ByVal strPortOrientation As String) As Double
        GetPortSizeFromDB = 0
        _strQuery = "select ODatWeld from Welded.PortsAndWPDSDetails where PORT_SIZE = '" + strPortSize + "' and PortType = '" + strPortType + "' and PortOrientation = '" + strPortOrientation + "'"
        GetPortSizeFromDB = MonarchConnectionObject.GetValue(_strQuery)
        If IsNothing(GetPortSizeFromDB) OrElse GetPortSizeFromDB = 0 Then
            GetPortSizeFromDB = 0
            _strErrorMessage = "Data not retrieved from PortsAndWPDSDetails table" + vbCrLf
        End If
    End Function

    '02_03_2010 Aruna
    Public Function GetButtonPlane(ByVal Query As String) As DataRow
        GetButtonPlane = Nothing
        GetButtonPlane = MonarchConnectionObject.GetDataRow(Query)
        If IsNothing(GetButtonPlane) OrElse GetButtonPlane.ItemArray.Length <= 0 Then
            GetButtonPlane = Nothing
            _strErrorMessage = "Data not retrieved from Welded.TubeDetails Table" + vbCrLf
        End If
    End Function

    Public Function GetWeldSize_RE(ByVal dblRodDiameter As Double, ByVal minWeldSize As Double) As Double
        GetWeldSize_RE = 0
        If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Cross Tube" Then
            _strQuery = "select WeldSize from Welded.RodWeldData where  Configuration='CrossTube' and RodDiameter=" + dblRodDiameter.ToString + " And WeldSize >=" + minWeldSize.ToString

        Else
            _strQuery = "select WeldSize from Welded.RodWeldData where  Configuration='Ulug' and RodDiameter=" + dblRodDiameter.ToString + " And WeldSize >=" + minWeldSize.ToString

        End If
        GetWeldSize_RE = MonarchConnectionObject.GetValue(_strQuery)
        If IsNothing(GetWeldSize_RE) OrElse GetWeldSize_RE = 0 Then
            GetWeldSize_RE = 0
            _strErrorMessage = "Data not retrieved from RodWeldData table" + vbCrLf
        End If
    End Function

    Public Function GetBushingDataTable(ByVal strMaterial As String, ByVal dblPinHoleSize As Double, ByVal dblBushingWidth As Double) As DataTable
        GetBushingDataTable = Nothing
        Try
            _strQuery = "select * from Welded.Bushings where Material = '" + strMaterial + "' and PinHoleSize = " + dblPinHoleSize.ToString + " and BushingWidth = " + dblBushingWidth.ToString
            GetBushingDataTable = MonarchConnectionObject.GetTable(_strQuery)
            If IsNothing(GetBushingDataTable) OrElse GetBushingDataTable.Rows.Count = 0 Then
                GetBushingDataTable = Nothing
                _strErrorMessage = "Data not retrieved from Welded.Bushings Table" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function


    Public Function GetOrificesSizes_90Deg(ByVal portType As String, ByVal portSize As String, ByVal dblTubeOD As Double) As DataTable
        GetOrificesSizes_90Deg = Nothing
        _strQuery = "SELECT DISTINCT(OrificeSize_for_90Degree) FROM Welded.PortsAndWPDSDetails WHERE PortType = '" + portType + "' and PORT_SIZE = '" + portSize + "' and PortOrientation = '90' and OrificeSize_for_90Degree <> 'N/A' " _
                        + " and MinimumTubeOD <= " + dblTubeOD.ToString + " and MaximumTubeOD >= " + dblTubeOD.ToString
        GetOrificesSizes_90Deg = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetOrificesSizes_90Deg) OrElse GetOrificesSizes_90Deg.Rows.Count = 0 Then
            GetOrificesSizes_90Deg = Nothing
            _strErrorMessage = "Data not retrieved from PortsAndWPDSDetails table" + vbCrLf
        End If
    End Function

    Public Function GetPistonNutSize(ByVal BoreDia As Double, ByVal RodDia As Double) As DataTable

        _strQuery = "Select distinct(NutSize) from Welded.PistonNutSizeDetails where BoreDia= " + BoreDia.ToString + " and RodDia= " + RodDia.ToString

        GetPistonNutSize = MonarchConnectionObject.GetTable(_strQuery)

        If IsNothing(GetPistonNutSize) OrElse GetPistonNutSize.Rows.Count = 0 Then

            GetPistonNutSize = Nothing

            _strErrorMessage = "Data not retrieved from PistonNutSizeDetails table" + vbCrLf

        End If

    End Function
    'ONSITE:19-05-2010 Retreiving the Pinholetype data from REDLThreaded table
    Public Function GetPinHoleTypeData() As DataTable
        _strQuery = "select distinct(PinHoleType) from welded.REDLThreaded"
        GetPinHoleTypeData = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetPinHoleTypeData) OrElse GetPinHoleTypeData.Rows.Count = 0 Then
            GetPinHoleTypeData = Nothing
            _strErrorMessage = "Data not retrieved from REDLThreaded table" + vbCrLf
        End If
    End Function

    '14_07_2010   RAGAVA
    Public Function GetPurchaseAndManufactureCode(ByVal strPartName As String) As String
        GetPurchaseAndManufactureCode = Nothing
        Try
            Dim strUpdateQuery As String = String.Empty
            _strQuery = "Select top 1 CodeNumber from MIL.dbo.CodeNumberDetails"
            strUpdateQuery = "Update MIL.dbo.CodeNumberDetails set CodeNumber = '"
            Dim strCodeNumber As Double = MonarchConnectionObject.GetValue(_strQuery)
            strUpdateQuery += (strCodeNumber + 1).ToString + "'"
            MonarchConnectionObject.ExecuteQuery(strUpdateQuery)
            GetPurchaseAndManufactureCode = strCodeNumber.ToString
            '09_10_2010   RAGAVA
            If strPartName.IndexOf("TUBE_WELDMENT") <> -1 Then
                ObjClsWeldedCylinderFunctionalClass._blnIsNewTube = True
            ElseIf strPartName.IndexOf("ROD_WELDMENT") <> -1 Then
                ObjClsWeldedCylinderFunctionalClass._blnIsNewRod = True
            End If
        Catch ex As Exception
        End Try
    End Function

    ' ANUP 27-05-2010 01.51pm
#Region "Contract Details Queries"

    Public Function GetCustomerName() As DataTable
        GetCustomerName = Nothing
        _strQuery = "select CustomerName from Welded.CustomerDetails order by CustomerName Asc"
        GetCustomerName = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetCustomerName) OrElse GetCustomerName.Rows.Count = 0 Then
            GetCustomerName = Nothing
            _strErrorMessage = "Data not retrieved from CustomerDetails table" + vbCrLf
        End If
    End Function

    Public Function GetCustomerNameInListBox(ByVal strCustomerName As String) As DataTable
        GetCustomerNameInListBox = Nothing
        _strQuery = "Select CustomerName from Welded.CustomerDetails where CustomerName like '" & strCustomerName & "%' order by CustomerName Asc"
        GetCustomerNameInListBox = MonarchConnectionObject.GetTable(_strQuery)
        If IsNothing(GetCustomerNameInListBox) OrElse GetCustomerNameInListBox.Rows.Count = 0 Then
            GetCustomerNameInListBox = Nothing
            _strErrorMessage = "Data not retrieved from CustomerDetails table" + vbCrLf
        End If
    End Function

    Public Function InsertingCustomerName(ByVal strCustomerName As String) As Boolean
        InsertingCustomerName = False
        Dim SerchForExistingCustomerName As String
        _strQuery = "select CustomerName from Welded.CustomerDetails where CustomerName = '" + strCustomerName.ToString + "'"
        SerchForExistingCustomerName = MonarchConnectionObject.GetValue(_strQuery)
        If IsNothing(SerchForExistingCustomerName) Then
            InsertingCustomerName = True
        End If
        If InsertingCustomerName Then
            _strQuery = "Insert into Welded.CustomerDetails(CustomerName) Values ('" & UCase(strCustomerName) & "')"
            InsertingCustomerName = MonarchConnectionObject.ExecuteQuery(_strQuery)
            Return True
        Else
            Return False
            _strErrorMessage = "Data not retrieved from CustomerDetails table" + vbCrLf
        End If
    End Function

    Public Function DeletingCustomerName(ByVal strCustomerName As String) As Boolean
        DeletingCustomerName = False
        Try
            _strQuery = "delete from Welded.CustomerDetails where CustomerName = '" + strCustomerName + "'"
            DeletingCustomerName = MonarchConnectionObject.ExecuteQuery(_strQuery)
            Return True
        Catch ex As Exception

        End Try
    End Function
#End Region
    '**********************
    Public Function GetContractDetails(ByVal strCustomerName As String) As DataTable
        GetContractDetails = Nothing
        Try
            _strQuery = "select ContractNumber,ContractRevision from ContractMaster where CustomerName = '" + strCustomerName + "' order by ContractNumber Asc"   ' ANUP 24-06-2010
            GetContractDetails = MonarchConnectionObject.GetTable(_strQuery)
            If IsNothing(GetContractDetails) OrElse GetContractDetails.Rows.Count = 0 Then
                GetContractDetails = Nothing
                _strErrorMessage = "Data not retrieved from ContractDetails table" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function

    'TODO: ANUP 24-06-2010
    Public Function GetCustomerName_ContractMaster() As DataTable
        GetCustomerName_ContractMaster = Nothing
        Try
            _strQuery = "select distinct CustomerName from ContractMaster "
            GetCustomerName_ContractMaster = MonarchConnectionObject.GetTable(_strQuery)
            If IsNothing(GetCustomerName_ContractMaster) OrElse GetCustomerName_ContractMaster.Rows.Count = 0 Then
                GetCustomerName_ContractMaster = Nothing
                _strErrorMessage = "Data not retrieved from ContractDetails table" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function GetCollarCylinderLength() As Boolean
        Try
            GetCollarCylinderLength = False
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then
                '22_12_2010  RAGAVA
                Dim strQuery As String
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Extension" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Bothends" Then
                    strQuery = "Select * from CollarDetails_RodEndRephasing where BoreDiameter = " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness  and portSize = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.Text.ToString) + "' and PortType = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.Text.ToString) + "' and PortAngle = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text.ToString) + "' and NumberOfPorts = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsRodEnd.Text.ToString) + "'"
                ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Retraction" Then
                    strQuery = "Select * from CollarDetails_BaseEndRephasing where BoreDiameter = " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness  and portSize = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.Text.ToString) + "' and PortType = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.Text.ToString) + "' and PortAngle = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text.ToString) + "' and NumberOfPorts = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsRodEnd.Text.ToString) + "'"
                Else
                    strQuery = "Select * from CollarDetails where BoreDiameter = " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness  and portSize = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortSizeRodEnd.Text.ToString) + "' and PortType = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.Text.ToString) + "' and PortAngle = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text.ToString) + "' and NumberOfPorts = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsRodEnd.Text.ToString) + "'"
                End If
                'Till  Here
                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text.ToString) = "90" Then
                    strQuery = strQuery + " and PortFacingEnd = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortFacingRodEnd.Text.ToString) + "'"
                End If
                Dim _oRow As DataRow = MonarchConnectionObject.GetDataRow(strQuery)
                If IsNothing(_oRow) Then
                    Return True
                End If
            End If
        Catch ex As Exception
            MsgBox("Error in Retrieving CollarCylinderLength")
        End Try
    End Function
    '25_06_2010   RAGAVA
    Public Function GetPortSizes_RodEnd(ByVal strPortSize As String) As Boolean
        Try
            GetPortSizes_RodEnd = False
            'Dim arr As String() = strPortSize.Split("/")
            'Dim Val1 As Double = Val(arr(0))
            'Dim Val2 As Double = Val(arr(1))
            'strPortSize = (Val1 / Val2).ToString
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" Then   '08_10_2010   RAGAVA  Commented   'AndAlso UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then

                '22_12_2010  RAGAVA
                Dim strQuery As String
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Extension" Then
                    strQuery = "Select * from CollarDetails_RodEndRephasing where BoreDiameter = " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness and portSize = '" + (strPortSize) + "' and PortType = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.Text.ToString) + "' and PortAngle = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text.ToString) + "' and NumberOfPorts = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsRodEnd.Text.ToString) + "'"
                Else
                    strQuery = "Select * from CollarDetails where BoreDiameter = " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness  and portSize = '" + (strPortSize) + "' and PortType = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.Text.ToString) + "' and PortAngle = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text.ToString) + "' and NumberOfPorts = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsRodEnd.Text.ToString) + "'"
                End If
                'strQuery = "Select * from CollarDetails where BoreDiameter = " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness  and portSize = '" + (strPortSize) + "' and PortType = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.Text.ToString) + "' and PortAngle = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text.ToString) + "' and NumberOfPorts = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsRodEnd.Text.ToString) + "'"
                'Till  Here

                If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text.ToString) = "90" Then
                    strQuery = strQuery + " and PortFacingEnd = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortFacingRodEnd.Text.ToString) + "'"
                End If
                Dim _oRow As DataRow = MonarchConnectionObject.GetDataRow(strQuery)
                If IsNothing(_oRow) Then
                    Return True
                End If
            End If
        Catch ex As Exception

        End Try
    End Function

    '25_06_2010   RAGAVA
    Public Function GetPortSizes_BaseEnd(ByVal strPortSize As String) As Boolean
        Try
            Dim strPortSize_RephasingatExtension As String = strPortSize        '30_05_2011  RAGAVA
            GetPortSizes_BaseEnd = False
            Dim arr As String() = strPortSize.Split("/")
            Dim Val1 As Double = Val(arr(0))
            Dim Val2 As Double = Val(arr(1))
            strPortSize = (Val1 / Val2).ToString
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.DesignType = "New" AndAlso UCase(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PortInsertion) = "RAISED" Then
                Dim strQuery As String

                '22_12_2010   RAGAVA
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRephasingType = "Rephasing at Extension" Then
                    'strQuery = "Select * from CollarDetails_RodEndRephasing where BoreDiameter = " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness and portSize = '" + (strPortSize) + "' and PortType = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeRodEnd.Text.ToString) + "' and PortAngle = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleRodEnd.Text.ToString) + "' and NumberOfPorts = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsRodEnd.Text.ToString) + "'"
                    strQuery = "Select * from CollarDetails_RodEndRephasing where BoreDiameter = " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness and portSize = '" + strPortSize_RephasingatExtension + "' and PortType = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeBaseEnd.Text.ToString) + "' and PortAngle = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleBaseEnd.Text.ToString) + "' and NumberOfPorts = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsBaseEnd.Text.ToString) + "'"        '30_05_2011   RAGAVA
                Else
                    If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleBaseEnd.Text.ToString) = "90" Then
                        strQuery = "Select * from PortIntegralRaisedPortDetails90   where NominalBoreDia = " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness  and portSize = " + (strPortSize) + " and PortType = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeBaseEnd.Text.ToString) + "' and PortAngle = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleBaseEnd.Text.ToString) + "' and NumberOfPorts = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsBaseEnd.Text.ToString) + "'"
                    Else
                        strQuery = "Select * from  PortIntegralRaisedPortDetails where NominalBoreDia = " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness  and portSize = " + (strPortSize) ' +" and NumberOfPorts = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsBaseEnd.Text.ToString) + "'"  'PortType = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeBaseEnd.Text.ToString) + "' and
                    End If
                End If

                'If Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleBaseEnd.Text.ToString) = "90" Then
                '    strQuery = "Select * from PortIntegralRaisedPortDetails90   where NominalBoreDia = " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness  and portSize = " + (strPortSize) + " and PortType = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeBaseEnd.Text.ToString) + "' and PortAngle = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortAngleBaseEnd.Text.ToString) + "' and NumberOfPorts = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsBaseEnd.Text.ToString) + "'"
                'Else
                '    strQuery = "Select * from  PortIntegralRaisedPortDetails where NominalBoreDia = " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BoreDiameter.ToString + " and " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWallThickness.ToString + " between MinTubeWallThickness and MaxTubeWallThickness  and portSize = " + (strPortSize) ' +" and NumberOfPorts = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbNoofPortsBaseEnd.Text.ToString) + "'"  'PortType = '" + Trim(ObjClsWeldedCylinderFunctionalClass.ObjFrmPortDetails.cmbPortTypeBaseEnd.Text.ToString) + "' and
                'End If
                'Till  Here
                Dim _oRow As DataRow = MonarchConnectionObject.GetDataRow(strQuery)
                If IsNothing(_oRow) Then
                    Return True
                End If
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function GetPistonSeal(ByVal dblBoreDia As Double, ByVal dblNutSize As Double) As DataTable
        GetPistonSeal = Nothing
        Try
            _strQuery = "Select  * "    ', case when PSP <> 'N/A' then 'Wyn Seal' else case when ZMacro <> 'N/A' then 'Glyd-P Seal' end end  as SealType "
            _strQuery += " from welded.PistonDetails where BoreDiameter= " + dblBoreDia.ToString + " And PistonNutSize=" + dblNutSize.ToString + "  And (PSP <> 'N/A' or ZMacro <>  'N/A')"
            GetPistonSeal = MonarchConnectionObject.GetTable(_strQuery)
            If IsNothing(GetPistonSeal) OrElse GetPistonSeal.Rows.Count = 0 Then
                GetPistonSeal = Nothing
                _strErrorMessage = "Data not retrieved from PistonDetails table" + vbCrLf
            End If
        Catch ex As Exception
        End Try
    End Function

    Public Function GetCylinderHeadDetails_WireRing(ByVal strBoreDiameter As String, ByVal strRodDiameter As String) As DataTable
        GetCylinderHeadDetails_WireRing = Nothing
        Try
            _strQuery = "select * from welded.CylinderHeadDetails where HeadType='RR' and BoreDiameter = " + strBoreDiameter + "and RodDiameter = " + strRodDiameter
            GetCylinderHeadDetails_WireRing = MonarchConnectionObject.GetTable(_strQuery)
        Catch ex As Exception

        End Try
        If IsNothing(GetCylinderHeadDetails_WireRing) OrElse GetCylinderHeadDetails_WireRing.Rows.Count <= 0 Then
            GetCylinderHeadDetails_WireRing = Nothing
            _strErrorMessage = "Data not retrieved from CylinderHeadDetails table" + vbCrLf
            _strErrorMessage += "CylinderHeadCode not available for selected values of BoreDiameter, RodDiameter"
        End If
    End Function

    'TODO: ANUP 12-07-2010 12.27pm
    Public Function GetPinsDetails_AccessoriesForm(ByVal dblPinHoleDiameter As Double, ByVal dblWorkingLength As Double) As DataTable
        GetPinsDetails_AccessoriesForm = Nothing
        Try
            _strQuery = "select distinct case when Hardend='Y' then 'Hardend' else 'Standard' end as PinMaterial from welded.PinsDetails where PinDiameter = " + dblPinHoleDiameter.ToString + "  and WorkingLength > " + dblWorkingLength.ToString
            GetPinsDetails_AccessoriesForm = MonarchConnectionObject.GetTable(_strQuery)
            If IsNothing(GetPinsDetails_AccessoriesForm) OrElse GetPinsDetails_AccessoriesForm.Rows.Count <= 0 Then
                GetPinsDetails_AccessoriesForm = Nothing
                _strErrorMessage = "Data not retrieved from PinsDetails table" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function GetPinsClips_AccessoriesForm(ByVal cmbPin As ComboBox, ByVal dblPinHoleDiameter As Double, ByVal dblWorkingLength As Double, ByVal strHardend As String, Optional ByVal strClipsType As String = "") As DataTable
        GetPinsClips_AccessoriesForm = Nothing
        Try

            If cmbPin.Name = "cmbPinMaterial_BaseEnd" OrElse cmbPin.Name = "cmbPinMaterial_RodEnd" Then
                _strQuery = "select * from welded.PinsDetails where PinDiameter = " + dblPinHoleDiameter.ToString + "  and WorkingLength = " + dblWorkingLength.ToString + " and Hardend = '" + strHardend + "'"
            ElseIf cmbPin.Name = "cmbPinClips_BaseEnd" OrElse cmbPin.Name = "cmbPinClips_RodEnd" Then
                _strQuery = "select * from welded.PinsDetails where PinDiameter = " + dblPinHoleDiameter.ToString + "  and WorkingLength = " + dblWorkingLength.ToString + " and Hardend = '" + strHardend + "' and ClipsType = '" + strClipsType + "'"
            End If
            GetPinsClips_AccessoriesForm = MonarchConnectionObject.GetTable(_strQuery)
            If IsNothing(GetPinsClips_AccessoriesForm) OrElse GetPinsClips_AccessoriesForm.Rows.Count <= 0 Then
                GetPinsClips_AccessoriesForm = Nothing
                _strErrorMessage = "Data not retrieved from PinsDetails table" + vbCrLf
            End If

        Catch ex As Exception

        End Try
    End Function

    Public Function GetWorkingLength_Pins(ByVal dblWorkingLength As Double) As Double
        GetWorkingLength_Pins = 0
        Try

            _strQuery = "select WorkingLength from welded.PinsDetails where WorkingLength >=  " + dblWorkingLength.ToString
            GetWorkingLength_Pins = MonarchConnectionObject.GetValue(_strQuery)
            If IsNothing(GetWorkingLength_Pins) Then
                GetWorkingLength_Pins = 0
                _strErrorMessage = "Data not retrieved from PinsDetails table" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function GetGreaseZercs_AccessoriesForm() As DataTable
        GetGreaseZercs_AccessoriesForm = Nothing
        Try
            _strQuery = "select * from welded.GreaseZercsDetails"
            GetGreaseZercs_AccessoriesForm = MonarchConnectionObject.GetTable(_strQuery)
            If IsNothing(GetGreaseZercs_AccessoriesForm) OrElse GetGreaseZercs_AccessoriesForm.Rows.Count <= 0 Then
                GetGreaseZercs_AccessoriesForm = Nothing
                _strErrorMessage = "Data not retrieved from GreaseZercsDetails table" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function GetGreaseZercs_cmbGreaseZercTypeSelected_AccessoriesForm(ByVal strGreaseZercType As String) As DataRow
        GetGreaseZercs_cmbGreaseZercTypeSelected_AccessoriesForm = Nothing
        Try
            _strQuery = "select * from welded.GreaseZercsDetails where Description = '" + strGreaseZercType + "'"
            GetGreaseZercs_cmbGreaseZercTypeSelected_AccessoriesForm = MonarchConnectionObject.GetDataRow(_strQuery)
            If IsNothing(GetGreaseZercs_cmbGreaseZercTypeSelected_AccessoriesForm) Then
                GetGreaseZercs_cmbGreaseZercTypeSelected_AccessoriesForm = Nothing
                _strErrorMessage = "Data not retrieved from GreaseZercsDetails table" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function PortAccessories_DataTable(ByVal clPortAccessory As Control, ByVal strPortSize As String, ByVal strPortType As String, Optional ByVal strPortAccessoryType As String = "") As DataTable
        PortAccessories_DataTable = Nothing
        Try
            'anup 24-12-2010 start
            If clPortAccessory.Name = "chkBaseEndPortAccessories" OrElse clPortAccessory.Name = "chkRodEndPortAccessories" OrElse clPortAccessory.Name = "chkBaseEndPortAccessories2" OrElse clPortAccessory.Name = "chkRodEndPortAccessories2" Then
                _strQuery = "select * from Welded.PortAccessories where PortSize = '" + strPortSize + "' and PortType = '" + strPortType + "'"
            ElseIf clPortAccessory.Name = "cmbAccessoryType_BaseEnd" OrElse clPortAccessory.Name = "cmbAccessoryType_RodEnd" OrElse clPortAccessory.Name = "cmbAccessoryType2_BaseEnd" OrElse clPortAccessory.Name = "cmbAccessoryType2_RodEnd" Then
                _strQuery = "select * from Welded.PortAccessories where PortSize = '" + strPortSize + "' and PortType = '" + strPortType + "' and Accessory = '" + strPortAccessoryType + "'"
            End If
            'anup 24-12-2010 till here
            PortAccessories_DataTable = MonarchConnectionObject.GetTable(_strQuery)
            If IsNothing(PortAccessories_DataTable) OrElse PortAccessories_DataTable.Rows.Count <= 0 Then
                PortAccessories_DataTable = Nothing
                _strErrorMessage = "Data not retrieved from PortAccessories table" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function

    'ANUP 12-08-2010
    Public Function StickOutAdderDefault_RetractedLengthCalculation(ByVal dblPistonNutSize As Double) As Double
        Try
            _strQuery = "select StickOutAdder from Welded.NutDimensionDetails where NutSize = " + dblPistonNutSize.ToString
            StickOutAdderDefault_RetractedLengthCalculation = MonarchConnectionObject.GetValue(_strQuery)
            If IsNothing(StickOutAdderDefault_RetractedLengthCalculation) Then
                StickOutAdderDefault_RetractedLengthCalculation = 0
                _strErrorMessage = "Data not retrieved from NutDimensionDetails table" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function

#Region "CNC Code"
    Public Function GetTH_Per_In(ByVal Nut_ThreadSize As Double) As Double
        _strQuery = "select TH_Per_IN from Nut_Thread_Num where Nut_ThreadSize =" & Nut_ThreadSize
        GetTH_Per_In = MonarchConnectionObject.GetValue(_strQuery)
        If IsNothing(GetTH_Per_In) Then
            GetTH_Per_In = 0
            _strErrorMessage = "Data not retrieved from Nut_Thread_Num table" + vbCrLf
        End If
    End Function

    Public Function GetThreadingSpeeds(ByVal ThreadDia As Double) As ThreadingSpeeds
        _strQuery = "SELECT ThreadDia,RPM,TOOLS,SecondThreadNum,OdSecondTools,Th_Per_In,Specs FROM ThreadingSpeeds  where ThreadDia = " + ThreadDia.ToString
        Dim oDataRow As DataRow = MonarchConnectionObject.GetDataRow(_strQuery)
        If IsNothing(oDataRow) Then
            GetThreadingSpeeds = Nothing
            _strErrorMessage = "Data not retrieved from ThreadingSpeeds table" + vbCrLf
            Return GetThreadingSpeeds
        End If
        GetThreadingSpeeds = New ThreadingSpeeds(oDataRow("ThreadDia"), oDataRow("RPM"), oDataRow("TOOLS"), oDataRow("SecondThreadNum"), oDataRow("OdSecondTools"), oDataRow("Th_Per_In"), oDataRow("Specs"))
    End Function

    Public Function InsertCyl_RodData(ByVal oCyl_Rod As CYL_Rod) As Boolean
        _strQuery = "INSERT INTO CYL_Rod " & _
           "(PartNo,ProgNo,ByName,Description,Drawing_Num,Drawing_Rev,Operation" & _
           ",WorkCenter,AutoDoor,LargeDia,SmallDia,NominalThreadDia" & _
           ",Length,Th_Length,Th_Per_In,ShoulderType,RodType" & _
          " ,Xhome ,Zhome ,output2ndop,Secondoptype ,Secondthreaddia" & _
           ",Secondshoulder,Secondthreadlength" & _
          " ,Secondthreadnum ,Secondthreadcornerrad" & _
           ",Secondchamfer,skimlength,skimdiameter,chamferdepthofcut" & _
          " ,Secondopzzero,DateAndTime) " & _
        "VALUES( " & oCyl_Rod.ToString & ", " & Date.Today & ")"
        InsertCyl_RodData = MonarchConnectionObject.ExecuteQuery(_strQuery)
        If IsNothing(InsertCyl_RodData) Then
            Return False
            _strErrorMessage = "Data not inserted in CYL_Rod table" + vbCrLf
        End If
    End Function

    Public Function DoesPartCodeExist(ByVal oCyl_Rod As CYL_Rod) As Boolean
        Try
            _strQuery = "select PartNo from CYL_Rod where PartNo ='" & oCyl_Rod.PartNo & "'"
            DoesPartCodeExist = MonarchConnectionObject.GetValue(_strQuery)
            If Not DoesPartCodeExist Then
                Return False
                _strErrorMessage = "Data not retrieved in CYL_Rod table" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function UpdateCyl_RodData(ByVal oCyl_Rod As CYL_Rod) As Boolean
        Try

            _strQuery = "Update CYL_Rod SET ByName ='" & oCyl_Rod.ByName & "' , Description ='" & oCyl_Rod.Description & "' , Drawing_Num =" & oCyl_Rod.Drawing_Num.ToString
            _strQuery += " , Drawing_Rev =" & oCyl_Rod.Drawing_Rev.ToString & " , Operation =" & oCyl_Rod.Operation.ToString & " , WorkCenter =" & oCyl_Rod.WorkCenter.ToString
            _strQuery += " , AutoDoor ='" & oCyl_Rod.AutoDoor.ToString & "' , LargeDia =" & oCyl_Rod.LargeDia.ToString & " , SmallDia =" & oCyl_Rod.SmallDia.ToString
            _strQuery += " , NominalThreadDia =" & oCyl_Rod.NominalThreadDia.ToString & " , Length =" & oCyl_Rod.Length.ToString & " , Th_Length =" & oCyl_Rod.Th_Length.ToString
            _strQuery += " , Th_Per_In =" & oCyl_Rod.TH_Per_IN.ToString & " , ShoulderType ='" & oCyl_Rod.ShoulderType & "' , RodType ='" & oCyl_Rod.RodType
            _strQuery += "' , Xhome =" & oCyl_Rod.Xhome.ToString & " , Zhome =" & oCyl_Rod.Zhome.ToString & " , output2ndop ='" & oCyl_Rod.output2ndop.ToString
            _strQuery += "' , Secondoptype ='" & oCyl_Rod.Secondoptype & "' , Secondthreaddia =" & oCyl_Rod.Secondthreaddia.ToString & " , Secondshoulder =" & oCyl_Rod.Secondshoulder.ToString
            _strQuery += " , Secondthreadlength =" & oCyl_Rod.Secondthreadlength.ToString & " , Secondthreadnum =" & oCyl_Rod.Secondthreadnum.ToString & " , Secondthreadcornerrad =" & oCyl_Rod.Secondthreadcornerrad.ToString
            _strQuery += " , Secondchamfer =" & oCyl_Rod.Secondchamfer.ToString & " , skimlength =" & oCyl_Rod.skimlength.ToString & " , skimdiameter =" & oCyl_Rod.skimdiameter.ToString
            _strQuery += " , chamferdepthofcut =" & oCyl_Rod.chamferdepthofcut.ToString & " , Secondopzzero =" & oCyl_Rod.Secondopzzero.ToString
            _strQuery += " where PartNo ='" & oCyl_Rod.PartNo & "'"
            UpdateCyl_RodData = MonarchConnectionObject.ExecuteQuery(_strQuery)
            If Not UpdateCyl_RodData Then
                Return False
                _strErrorMessage = "Data not updated in CYL_Rod table" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function

#End Region

    'ANUP 04-10-2010 START
    Public Function GetCustomerPartCode(ByVal strRevisionPartCode As String) As String
        getCustomerPartCode = String.Empty
        Try
            _strQuery = "select CustomerPartCode from dbo.ContractMaster where ContractNumber =" + strRevisionPartCode
            getCustomerPartCode = MonarchConnectionObject.GetValue(_strQuery)
            If String.IsNullOrEmpty(getCustomerPartCode) Then
                _strErrorMessage = "Data not retrieved from ContractMaster table" + vbCrLf
            End If
        Catch ex As Exception

        End Try
    End Function
    'ANUP 04-10-2010 TILL HERE

End Class

