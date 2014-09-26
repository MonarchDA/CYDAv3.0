Public Class clsFormFinalCostingList

#Region "Private Variables"

#End Region

#Region "Enum"

    Public Enum CostingTableElements
        PartCode = 0
        Description = 1
        Cost = 2
        Purchased_Manfractured = 3
        PurchasePartCode = 4
        ReferenceNumber = 5
        CostMangementReferenceNumber = 6
    End Enum

#End Region

#Region "Procedures"

    Public Function GetFinalCostingList(ByVal htPartCodes As Hashtable) As ArrayList
        Dim oDTCostingDetails As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsMIL_TieRodDataClass.GetCostingDetails
        Return FormFinalList(htPartCodes, oDTCostingDetails)
    End Function

    Private Function FormFinalList(ByVal htPartCodes As Hashtable, ByVal dtCostingDetails As DataTable) As ArrayList
        Dim aFinalCostingList As New ArrayList
        For Each oHTElement As DictionaryEntry In htPartCodes
            Try
                Dim oExistingListItems As clsList = oHTElement.Value
                Dim oNewList As New clsList
                Dim strFilter As String = "PartCode = " + oExistingListItems.strPartCode
                Dim oPartDetails() As DataRow = dtCostingDetails.Select(strFilter)
                If Not IsNothing(oPartDetails) AndAlso oPartDetails.Length > 0 Then
                    Dim oFirstRow As DataRow = oPartDetails(0)
                    oNewList.strPartCode = oFirstRow(CostingTableElements.PartCode)
                    oNewList.strDescription = oFirstRow(CostingTableElements.Description)
                    If oExistingListItems.dblCost <> 0 Then
                        oNewList.dblCost = oExistingListItems.dblCost
                    Else
                        oNewList.dblCost = oFirstRow(CostingTableElements.Cost)
                    End If
                Else
                    oNewList.strPartCode = oExistingListItems.strPartCode
                    oNewList.strDescription = oHTElement.Key
                    If oExistingListItems.dblCost <> 0 Then
                        oNewList.dblCost = oExistingListItems.dblCost
                    Else
                        oNewList.dblCost = 0
                    End If
                End If
                oNewList.dblQuantity = oExistingListItems.dblQuantity
                oNewList.strUnit = oExistingListItems.strUnit
                aFinalCostingList.Add(oNewList)
            Catch ex As Exception

            End Try
        Next
        If aFinalCostingList.Count > 0 Then
            Return aFinalCostingList
        Else
            Return Nothing
        End If
    End Function

#End Region

End Class
