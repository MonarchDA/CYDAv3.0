Imports System.io
Public Class frmMonarchRevision

    'Public SelectedContract As String

    Private strCustomerName As String

    Public Sub ManualLoad()
        DisplayCustomerDetails()
        'DisplayRevisionAssemblyData()   ' ANUP 24-06-2010
    End Sub

    Private Sub DisplayCustomerDetails()
        'ANUP 02-11-2010  START
        lvwContractDetails.Items.Clear()
        'ANUP 02-11-2010  TILL HERE
        LVCustomer.Items.Clear()
        ' ANUP 24-06-2010
        LVCustomer.Items.Clear()
        Try
            Dim oCustomerNameTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetCustomerName_ContractMaster()
            If Not IsNothing(oCustomerNameTable) Then
                For Each oCustomerNameDataRow As DataRow In oCustomerNameTable.Rows
                    If Not IsDBNull(oCustomerNameDataRow("CustomerName")) Then
                        LVCustomer.Items.Add(oCustomerNameDataRow("CustomerName"))
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub AddColumnsToRevisionListView()
        lvwContractDetails.Columns.Clear()
        lvwContractDetails.Columns.Add("ContractNumber")
        lvwContractDetails.Columns(0).Width = 100
        lvwContractDetails.Columns.Add("ContractRevision")
        lvwContractDetails.Columns(1).Width = 100
        'ANUP 01-11-2010 START
        lvwContractDetails.Columns.Add("IsItReleased")
        lvwContractDetails.Columns(2).Width = 100
        'ANUP 01-11-2010 TILL HERE
    End Sub

    Private Sub DisplayRevisionAssemblyData()
        lvwContractDetails.Items.Clear()
        Dim oTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetContractDetails(strCustomerName)   ' ANUP 24-06-2010
        'ANUP 01-11-2010 START
        oTable = IsReleasedOrNotValidation(oTable, strCustomerName)
        'ANUP 01-11-2010 TILL HERE
        Dim oListviewitem As ListViewItem
        If Not IsNothing(oTable) Then
            For Each oRow As DataRow In oTable.Rows
                oListviewitem = New ListViewItem
                oListviewitem.Text = oRow("ContractNumber")
                oListviewitem.SubItems.Add(oRow("ContractRevision"))
                'ANUP 01-11-2010 START
                If ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Revision" Then
                    If Not IsDBNull(oRow("IsItReleased")) Then
                        oListviewitem.SubItems.Add(oRow("IsItReleased"))
                    Else
                        oListviewitem.SubItems.Add("")
                    End If
                End If
                'ANUP 01-11-2010 TILL HERE
                lvwContractDetails.Items.Add(oListviewitem)
            Next
        Else
            Dim strMessage As String = "There is No Revision Details. Please select New Design"
            MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub

    Private Sub frmMonarchRevision_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ColorTheForm()
        AddColumnsToRevisionListView()
        DisplayCustomerDetails()
        'DisplayRevisionAssemblyData()
    End Sub

    Private Sub lvwContractDetails_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvwContractDetails.SelectedIndexChanged
        Try
            If lvwContractDetails.SelectedItems.Count > 0 Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RevisionContractNo = lvwContractDetails.SelectedItems(0).SubItems(0).Text
                ' ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables._intContractRevisionNumber = Trim(lvwContractDetails.SelectedItems(0).SubItems(1).Text)       '29_06_2010    RAGAVA
                'anup 23-12-2010 start
                If ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Released" Then
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables._intContractRevisionNumber = -1
                    btnRelease.Visible = True     '24_06_2011  RAGAVA
                Else
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables._intContractRevisionNumber = Trim(lvwContractDetails.SelectedItems(0).SubItems(1).Text)       '29_06_2010    RAGAVA
                    btnRelease.Visible = False     '24_06_2011  RAGAVA
                End If
                'anup 23-12-2010 till here
                '05_07_2010   RAGAVA
                If Directory.Exists("C:\WELDED_TESTING\" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RevisionContractNo) Then
                    Directory.Delete("C:\WELDED_TESTING\" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RevisionContractNo, True)
                End If
                Directory.Move("C:\WELDED_TESTING\" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber, "C:\WELDED_TESTING\" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RevisionContractNo)
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath = "C:\WELDED_TESTING\" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RevisionContractNo + "\WELDED_LIBRARY"
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath_Drawings = "C:\WELDED_TESTING\" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RevisionContractNo + "\WELDED_DRAWINGS"
                'Directory.Move("C:\WELDED_TESTING\" + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber + "\WELDED_DRAWINGS", ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.GeneratePath_Drawings)
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RevisionContractNo
                'Till  Here
            Else
                btnRelease.Visible = False     '24_06_2011  RAGAVA
            End If
        Catch ex As Exception
            MsgBox("Error in Renaming ContractFolder")
        End Try
    End Sub

    ' ANUP 24-06-2010
    Private Sub LVCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LVCustomer.SelectedIndexChanged
        If LVCustomer.SelectedItems.Count > 0 Then
            strCustomerName = LVCustomer.SelectedItems(0).Text
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CustomerName_ContractDetails = strCustomerName
            DisplayRevisionAssemblyData()
        End If
    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient6, LabelGradient2, LabelGradient3, LabelGradient7)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(LabelGradient1)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient5)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient4)
    End Sub

    'ANUP 01-11-2010 START
    Private Function IsReleasedOrNotValidation(ByVal dtFinalDataTable As DataTable, ByVal strCustomerName As String) As DataTable
        IsReleasedOrNotValidation = Nothing
        Try

            Dim strQuery As String = "select ContractNumber,ContractRevision from"
            strQuery += " ContractMaster CM,ReleasedCylinderCodes RCC Where CM.ContractNumber = RCC.ReleasedCylinderCodeNumber and CustomerName = '" & strCustomerName & "' order by DateAndTime Desc"
            Dim oTable As DataTable = MonarchConnectionObject.GetTable(strQuery)
            If ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Revision" Then
                dtFinalDataTable.Columns.Add("IsItReleased")
            End If

            If Not IsNothing(oTable) Then
                For Each oDataRow As DataRow In oTable.Rows
                    For Each oFinalDataRow As DataRow In dtFinalDataTable.Rows
                        If oFinalDataRow("ContractNumber") = oDataRow("ContractNumber") Then
                            If ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Revision" Then
                                oFinalDataRow("IsItReleased") = "Released"
                            ElseIf ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Released" Then
                                oFinalDataRow.Delete()
                                dtFinalDataTable.AcceptChanges()
                            End If
                            Exit For
                        End If
                    Next
                Next
            End If
            IsReleasedOrNotValidation = dtFinalDataTable
        Catch ex As Exception

        End Try
    End Function
    'ANUP 01-11-2010 TILL HERE


    Private Sub btnRelease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRelease.Click
        Try
            '22_06_2011   RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Released" Then
                'Me.btnNext.Visible = False
                'Me.btnBack.Visible = False
                Try
                    'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.UpdateExistedCasting()
                    Dim oClsReleaseCylinderFunctionality As New clsReleaseCylinderFunctionality
                    oClsReleaseCylinderFunctionality.RevisionCounterValidation()
                    If Not ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ECR_MainFunctionality() Then
                        MessageBox.Show("Release Cylinder Validation Failed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    End If
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.UpdateExistedCasting()
                    MsgBox(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & " is Released successfully")
                Catch ex As Exception
                    MsgBox("Error in updating Existing Casting Details")
                End Try
                'If Not Directory.Exists("W:\WELDED\CMS\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & "_CMS") Then
                '    Directory.Move("W:\WELDED\CMS_TEMP\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & "_CMS", "W:\WELDED\CMS\" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & "_CMS")
                '    File.Move("W:\WELDED\CNC_TEMP\" & "0" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strRodEndCastingCodeNumber.ToString & "1", "W:\WELDED\CNC\" & "0" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & "1")
                'End If
            End If
            'Till   Here
        Catch ex As Exception

        End Try
    End Sub
End Class