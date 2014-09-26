Imports System.Data.SqlClient
Imports System.Data
Imports System.io
Imports Microsoft.Win32.Registry
Imports Microsoft.Win32.RegistryKey
Imports System.Diagnostics.Process
Imports Microsoft.Office.Interop
Imports Microsoft.Win32

Public Class frmRevisionTable

    'TODO: ANUP 22-07-2010 12.14pm
    Private _blnIsPopulated As Boolean = False

    Public Property IsPopulated() As Boolean
        Get
            Return _blnIsPopulated
        End Get
        Set(ByVal value As Boolean)
            _blnIsPopulated = value
        End Set
    End Property

    Dim Objdt As DataTable
    Dim strSql As String
    Dim intCount As Integer = 0
    Private m_SelectedStyle As DataGridViewCellStyle
    Private m_SelectedRow As Integer = -1
    Private Sub btnUpdateRevision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateRevision.Click
        Try
            Objdt = Objdt.GetChanges(DataRowState.Modified)
            For Each dr As DataRow In Objdt.Rows
                'If Trim(dr("Description")) <> "" Then
                strSql = "Update RevisionTable Set ContractNumber = '" & dr("ContractNumber") & "' , ECR_Number = '" _
                & dr("ECR_Number") & "' , Description = '" & dr("Description") & "',RevisedBy='" & dr("RevisedBy") & "', Date='" & Format(Date.Today, "dMMMyy") & "',RevisionNumber = " & dr("RevisionNumber") & "Where ContractNumber = '" _
                & dr("ContractNumber") & "' and revisionNumber=" & dr("revisionNumber")
                Dim objDT1 As DataTable = GetDataTable(strSql)
                'End If
            Next
            Me.Dispose()
        Catch ex As Exception
            Me.Dispose()
        End Try
    End Sub

    Public Function GetTableData(ByVal _strTableName As String) As DataTable
        Dim _dt As New DataTable
        'Dim _da As New SqlDataAdapter("Select * from " & _strTableName, strConnectionString)
        Dim _da As New SqlDataAdapter("Select * from " & _strTableName, MonarchConnectionObject.ConnectionString)
        Try
            _da.Fill(_dt)
        Catch ex As Exception
            MsgBox("Error in Filling DataTable " & _strTableName)
        End Try
        Return _dt
    End Function

    Public Function GetDataTable(ByVal _strQueryString As String) As DataTable
        Dim _dt As New DataTable
        'Dim _da As New SqlDataAdapter(_strQueryString, strConnectionString)
        Dim _da As New SqlDataAdapter(_strQueryString, MonarchConnectionObject.ConnectionString)
        Dim _sqlCommand As New SqlCommand()
        Try
            _da.Fill(_dt)
        Catch ex As Exception
            MsgBox("Error in Processing Below Query " & Environment.NewLine & _strQueryString)
        End Try
        Return _dt
    End Function

    Public Function DisplayEmptyDescription() As DataTable
        DisplayEmptyDescription = Nothing
        Try
            Dim StrSql As String
            Dim objDT As DataTable
            StrSql = "Select top 7 ContractNumber,ECR_Number,Description,RevisedBy,Date,RevisionNumber from RevisionTable where ContractNumber = '" & ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber.ToString & "' order by RevisionNumber Desc" 'and Description is Null  or CompiledBy is Null or ApprovedBy is Null"
            objDT = GetDataTable(StrSql)
            Return objDT
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub frmRevisionTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ColorTheForm()
            ' oDataClass.UpdateRevision_Details()
            Objdt = DisplayEmptyDescription()

            'anup 23-12-2010 start
            Try
                If ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Released" OrElse (Not ObjClsWeldedCylinderFunctionalClass.ObjFrmPrimaryInputs.ReleasedRevisionFunctionality() Is Nothing AndAlso ObjClsWeldedCylinderFunctionalClass.IsNew_Revision_Released = "Revision") Then
                    For Each oDataRow As DataRow In Objdt.Rows
                        If IsDBNull(oDataRow("ECR_Number")) Then
                            oDataRow("ECR_Number") = GetECR_Number()
                        End If
                    Next
                End If
            Catch ex As Exception
            End Try
            'anup 23-12-2010 till here


            Objdt.Columns("ContractNumber").ReadOnly = True
            Objdt.Columns("ECR_Number").ReadOnly = False
            Objdt.Columns("Description").ReadOnly = False
            Objdt.Columns("RevisedBy").ReadOnly = False
            Objdt.Columns("Date").ReadOnly = True
            Objdt.Columns("RevisionNumber").ReadOnly = True
            dgvRevisionTable.DataSource = Objdt
            dgvRevisionTable.AllowUserToAddRows = False
            ' dgvRevisionTable.DefaultCellStyle.BackColor = Color.Blue
            'SetGridColors()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'anup 23-12-2010 start
    Private Function GetECR_Number() As String
        Try
            Dim TempExcelApp As Excel.Application
            Dim TempWorkBook As Excel.Workbook
            Dim tempWorkSheet As Excel.Worksheet
            TempExcelApp = New Excel.Application
            TempExcelApp.Visible = False

            'anup 04-02-2011 start
            'If File.Exists("W:\ECR_Welded\ECR_Codes.xls") Then
            '    TempWorkBook = TempExcelApp.Workbooks.Open("W:\ECR_Welded\ECR_Codes.xls")
            If File.Exists("W:\ECR\ECR_Codes.xls") Then
                TempWorkBook = TempExcelApp.Workbooks.Open("W:\ECR\ECR_Codes.xls")
                'anup 04-02-2011 till here
                tempWorkSheet = TempExcelApp.Sheets(1)
                Dim intTotalCostExcelRange As Integer = 2
                Do
                    Try
                        If IsNothing(tempWorkSheet.Range("A" + intTotalCostExcelRange.ToString).Value) Then
                            GetECR_Number = tempWorkSheet.Range("A" + Val(intTotalCostExcelRange - 1).ToString).Value
                            GetECR_Number += tempWorkSheet.Range("B" + Val(intTotalCostExcelRange - 1).ToString).Value
                            GetECR_Number += ((tempWorkSheet.Range("C" + Val(intTotalCostExcelRange - 1).ToString).Value) + 1).ToString
                            Exit Do
                        End If
                    Catch ex As Exception
                        GetECR_Number = "11IFL-1" 'anup 04-02-2011

                    End Try
                    intTotalCostExcelRange += 1
                Loop
            Else
                GetECR_Number = "11IFL-1" 'anup 04-02-2011
            End If


        Catch ex As Exception

        End Try

    End Function
    'anup 23-12-2010 till here


    'Public Sub UpdateRevision_Details(ByVal strContractNumber As String, ByVal revisionNumber As Integer)
    '    Try
    '        Dim StrSql As String
    '        Dim objDT As DataTable
    '        StrSql = "Delete from RevisionTable where ContractNumber='" & strContractNumber & "' and RevisionNumber=" & revisionNumber
    '        objDT = GetDataTable(StrSql)
    '        objDT.Clear()
    '        StrSql = "Insert into RevisionTable(ContractNumber,Date,RevisionNumber) values('" & strContractNumber & "','" & Format(Date.Today, "dMMMyy") & "'," & revisionNumber & ")"
    '        objDT = GetDataTable(StrSql)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub


    'anup 23-12-2010 start
    Public Sub UpdateRevision_Details(ByVal strContractNumber As String, ByVal revisionNumber As Integer, Optional ByVal IsReleased As String = "")
        Try
            Dim StrSql As String
            Dim objDT As DataTable
            StrSql = "Delete from RevisionTable where ContractNumber='" & strContractNumber & "' and RevisionNumber=" & revisionNumber
            objDT = GetDataTable(StrSql)
            objDT.Clear()
            If IsReleased = "Release" Then
                StrSql = "Insert into RevisionTable(ContractNumber,Description,Date,RevisionNumber) values('" & strContractNumber & "','" & IsReleased & "','" & Format(Date.Today, "dMMMyy") & "'," & revisionNumber & ")"
            Else
                StrSql = "Insert into RevisionTable(ContractNumber,Date,RevisionNumber) values('" & strContractNumber & "','" & Format(Date.Today, "dMMMyy") & "'," & revisionNumber & ")"
            End If
            objDT = GetDataTable(StrSql)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    'anup 23-12-2010 till here

    Private Sub SetGridColors()
        ' Initialize basic DataGridView properties.
        dgvRevisionTable.Dock = DockStyle.Fill
        dgvRevisionTable.BackgroundColor = Color.LightGray
        dgvRevisionTable.BorderStyle = BorderStyle.Fixed3D

        ' Set property values appropriate for read-only display and 
        ' limited interactivity. 
        dgvRevisionTable.AllowUserToAddRows = False
        dgvRevisionTable.AllowUserToDeleteRows = False
        dgvRevisionTable.AllowUserToOrderColumns = True
        '  dgvRevisionTable.ReadOnly = True
        'dgvRevisionTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        ' dgvRevisionTable.MultiSelect = False
        dgvRevisionTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
        dgvRevisionTable.AllowUserToResizeColumns = False
        dgvRevisionTable.ColumnHeadersHeightSizeMode = _
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvRevisionTable.AllowUserToResizeRows = False
        dgvRevisionTable.RowHeadersWidthSizeMode = _
            DataGridViewRowHeadersWidthSizeMode.DisableResizing

        ' Set the selection background color for all the cells.
        dgvRevisionTable.DefaultCellStyle.SelectionBackColor = Color.White
        dgvRevisionTable.DefaultCellStyle.SelectionForeColor = Color.Black

        ' Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default
        ' value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
        dgvRevisionTable.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty

        ' Set the background color for all rows and for alternating rows. 
        ' The value for alternating rows overrides the value for all rows. 
        dgvRevisionTable.RowsDefaultCellStyle.BackColor = Color.LightGray
        dgvRevisionTable.AlternatingRowsDefaultCellStyle.BackColor = Color.Black

        ' Set the row and column header styles.
        dgvRevisionTable.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvRevisionTable.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        dgvRevisionTable.RowHeadersDefaultCellStyle.BackColor = Color.Black

        ' Set the Format property on the "Last Prepared" column to cause
        ' the DateTime to be formatted as "Month, Year".
        'dgvRevisionTable.Columns("ECR_Number").DefaultCellStyle.Format = "y"

        ' Specify a larger font for the "Ratings" column. 
        Dim font As New Font( _
            dgvRevisionTable.DefaultCellStyle.Font.FontFamily, 10, FontStyle.Bold)
        Try
            dgvRevisionTable.Columns("ECR_Number").DefaultCellStyle.Font = font
            dgvRevisionTable.Columns("Description").DefaultCellStyle.Font = font
            dgvRevisionTable.Columns("RevisedBy").DefaultCellStyle.Font = font
        Finally
            font.Dispose()
        End Try

    End Sub

    Private Sub dgvRevisionTable_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRevisionTable.SelectionChanged
        If m_SelectedRow >= 0 Then
            dgvRevisionTable.Rows(m_SelectedRow).DefaultCellStyle = Nothing
        End If
        m_SelectedRow = dgvRevisionTable.CurrentRow.Index
        Dim dt As DataGridViewTextBoxColumn = TryCast(Me.dgvRevisionTable.Columns(3), DataGridViewTextBoxColumn)
        dt.MaxInputLength = 2
        dgvRevisionTable.CurrentRow.DefaultCellStyle = m_SelectedStyle
    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, LabelGradient5, LabelGradient4, LabelGradient2)
    End Sub

End Class