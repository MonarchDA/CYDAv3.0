Imports IFLBaseDataLayer
Imports IFLCommonLayer

Public Class clsCostingMILDB

    Private _oMILConnectionObject As IFLConnectionClass
    Private _strQuery As String

    Public Property MILConnectionObject() As IFLConnectionClass
        Get
            Return _oMILConnectionObject
        End Get
        Set(ByVal value As IFLConnectionClass)
            _oMILConnectionObject = value
        End Set
    End Property

    Public Sub New()
        Try
            Dim strXMLFilePath As String = System.Environment.CurrentDirectory + "\MILConnection.xml"
            Dim oDataSet As New DataSet
            oDataSet.ReadXml(strXMLFilePath)
            If Not oDataSet.Tables.Count <= 0 Then
                Dim strServer As String = oDataSet.Tables(0).Rows(0).Item(0).ToString
                Dim strDataBase As String = oDataSet.Tables(0).Rows(0).Item(1).ToString
                _oMILConnectionObject = IFLConnectionClass.GetConnectionObject(strServer, strDataBase, "System.Data.SqlClient", , , True)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function GetPartCodeDetails(ByVal strPartCode As String) As DataRow
        GetPartCodeDetails = Nothing
        Try
            _strQuery = "select PartCode,Description,Cost,CostMangementReferenceNumber from CostingDetails where PartCode = '" + strPartCode + "'"
            GetPartCodeDetails = MILConnectionObject.GetDataRow(_strQuery)
            If IsNothing(GetPartCodeDetails) Then
                GetPartCodeDetails = Nothing
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function GetCostMultiplyValue(ByVal strID As String) As Double
        Try
            _strQuery = "select Cost from CostManagementDetails where IFLID = '" + strID + "'"
            GetCostMultiplyValue = MILConnectionObject.GetValue(_strQuery)
        Catch ex As Exception

        End Try
    End Function

    Public Function GetCostingDetails() As DataTable
        GetCostingDetails = Nothing
        Try
            _strQuery = "select * from CostingDetails "
            GetCostingDetails = MILConnectionObject.GetTable(_strQuery)
            'GetCostingDetails.Columns("Cost")
            If IsNothing(GetCostingDetails) OrElse GetCostingDetails.Rows.Count <= 0 Then
                GetCostingDetails = Nothing
            Else
                For Each dr As DataRow In GetCostingDetails.Rows
                    If dr("Cost") < 0.001 Then
                        dr("Cost") = 0
                    End If
                Next
                'Dim strUpdate As String = "Update GetCostingDetails set Cost = 0 where Cost < 0.001"
                'Dim blnsuccess As Boolean = MILConnectionObject.ExecuteQuery(strUpdate)
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function GetRodWeight(ByVal strRodDiameter As String) As Double
        Try
            Dim strQuery1 As String = "select WeightPerFoot from RodWeightDetails where RodDiameter = " + strRodDiameter
            GetRodWeight = MILConnectionObject.GetValue(strQuery1)
        Catch ex As Exception
            GetRodWeight = 0
        End Try
    End Function

    Public Function GetPaintCode(ByVal strPaint As String) As String
        Try
            GetPaintCode = MILConnectionObject.GetValue("Select PaintCode from PaintDetails where PaintColor = '" + strPaint + "'")
        Catch ex As Exception
            GetPaintCode = Nothing
        End Try
    End Function

    Public Sub CloseConnection()
        Try
            If Not IsNothing(MILConnectionObject) Then
                MILConnectionObject.CloseConnection()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function PaintDataTable() As DataTable
        PaintDataTable = Nothing
        Try
            _strQuery = "select * from dbo.PaintDetails"
            PaintDataTable = MILConnectionObject.GetTable(_strQuery)
            If IsNothing(PaintDataTable) AndAlso PaintDataTable.Rows.Count <= 0 Then
                PaintDataTable = Nothing
            End If
        Catch ex As Exception

        End Try
    End Function

    'ANUP 06-10-2010 START
    Public Function GetPurchasedPartCode(ByVal strPartCode As String) As String
        GetPurchasedPartCode = String.Empty
        Try
            _strQuery = "select PurchasePartCode from CostingDetails where PartCode ='" & strPartCode & "' and Purchased_Manfractured='P'"
            GetPurchasedPartCode = MILConnectionObject.GetValue(_strQuery)
            If String.IsNullOrEmpty(GetPurchasedPartCode) Then
                GetPurchasedPartCode = String.Empty
            End If
        Catch ex As Exception

        End Try
    End Function
    'ANUP 06-10-2010 TILL HERE
    'Paint Description Notes From MIL DB vamsi 18-02-2014
    Public Function GetPaintDescription(ByVal cmbText As String) As String
        GetPaintDescription = String.Empty
        Try
            _strQuery = "select description from PaintDetails where PaintColor='" & ObjClsWeldedCylinderFunctionalClass.ObjFrmPin_Port_PaintAccessories.cmbPaint.Text & "'"
            GetPaintDescription = MILConnectionObject.GetValue(_strQuery)
            If IsNothing(GetPaintDescription) Then
                GetPaintDescription = String.Empty
            End If

        Catch ex As Exception

        End Try

    End Function

End Class
