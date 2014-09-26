'<<--9-12-2010 Aruna--
Public Class frmUpdateDatabaseRecords
    Private TableName As String
    Private strCodeName As String = ""

    Private Sub populateInListView()
        cmbConfiguration.Items.Clear()
        Me.cmbConfiguration.Items.Add("Base End")
        Me.cmbConfiguration.Items.Add("Rod End")
        Me.cmbPortType.Items.Clear()
        Me.cmbPortAngle.Items.Clear()
        Me.cmbEndPort.Items.Clear()
        Me.cmbEndPort.Visible = False
        Me.lblBaseEndPort.Visible = False
        Me.cmbPortType.Visible = False
        Me.lblTypeOfPort.Visible = False
        Me.lblPortAngle.Visible = False
        Me.cmbPortAngle.Visible = False
        btnUpdateToDatabase.Enabled = False
        txtSearchString.Clear()
        Me.lvwDatabaseRecordView.Items.Clear()
        Me.lvwDatabaseRecordView.Clear()
        txtSearchString.Clear()
        cmbSubConfiguration.Items.Clear()
    End Sub

    Sub TestEvent()
        AddHandler Me.cmbEndPort.SelectedIndexChanged, AddressOf MyEventHandler
        AddHandler Me.cmbPortType.SelectedIndexChanged, AddressOf PortTypeEventHandler
        AddHandler Me.cmbPortAngle.SelectedIndexChanged, AddressOf PortAngleChangedEvent
        AddHandler Me.cmbConfiguration.SelectedIndexChanged, AddressOf LoadConfigurations
        AddHandler Me.cmbSubConfiguration.SelectedIndexChanged, AddressOf LoadEndPorts
        AddHandler Me.lvwDatabaseRecordView.ItemCheck, AddressOf loadDataTableBackToDatabase
        AddHandler Me.lvwDatabaseRecordView.SelectedIndexChanged, AddressOf checkItemsSelected
        AddHandler Me.btnUpdateToDatabase.Click, AddressOf UpdateButtonClicked
        AddHandler Me.txtSearchString.TextChanged, AddressOf SearchRecordfromTextBox

    End Sub

    Private Sub Me_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '  LoadFunctionality()
    End Sub

    Public Sub LoadFunctionality()
        ColorTheForm()
        populateInListView()
        TestEvent()
    End Sub

    Public Sub ManualLoad()
        LoadFunctionality()
    End Sub

    Sub MyEventHandler(ByVal sender As Object, ByVal e As EventArgs)
        Me.lvwDatabaseRecordView.Items.Clear()
        Me.lvwDatabaseRecordView.Clear()
        txtSearchString.Clear()
        If Me.cmbEndPort.Text = "Port Integral" Then
            Me.cmbPortType.Visible = True
            Me.lblTypeOfPort.Text = "Port Type"
            Me.lblTypeOfPort.Visible = True
            Me.cmbPortType.Items.Clear()
            Me.cmbPortType.Items.Add("Flushed")
            Me.cmbPortType.Items.Add("Raised")
            Me.lblPortAngle.Visible = False
            Me.cmbPortAngle.Visible = False
        Else
            Me.cmbPortType.Items.Clear()
            Me.cmbPortType.Visible = False
            Me.lblTypeOfPort.Visible = False
            Me.lblPortAngle.Visible = False
            Me.cmbPortAngle.Visible = False
            If cmbConfiguration.Text = "Rod End" AndAlso cmbSubConfiguration.Text = "Double Lug" Then
                Me.lblTypeOfPort.Visible = True
                Me.lblTypeOfPort.Text = "Connection Type"
                Me.cmbPortType.Visible = True
                Me.cmbPortType.Items.Clear()
                Me.cmbPortType.Items.Add("Threaded")
                Me.cmbPortType.Items.Add("Welded")
                ' checkSubConditionsCases(Me.cmbConfiguration.Text & "_" & Me.cmbSubConfiguration.Text & "_" & Me.cmbEndPort.Text & "_" & Me.cmbPortType.Text)
            Else
                checkSubConditionsCases(Me.cmbConfiguration.Text & "_" & Me.cmbSubConfiguration.Text & "_" & Me.cmbEndPort.Text)
            End If

        End If
    End Sub

    Sub PortTypeEventHandler(ByVal sender As Object, ByVal e As EventArgs)
        Me.lvwDatabaseRecordView.Items.Clear()
        Me.lvwDatabaseRecordView.Clear()
        txtSearchString.Clear()
        If cmbPortType.Text = "Raised" Then
            lblPortAngle.Visible = True
            cmbPortAngle.Visible = True
            cmbPortAngle.Items.Clear()
            cmbPortAngle.Items.Add("Straight")
            cmbPortAngle.Items.Add("90")
        Else
            If cmbConfiguration.Text = "Rod End" AndAlso cmbSubConfiguration.Text = "Double Lug" And Trim(cmbPortType.Text) = "Welded" Then
                Me.lblPortAngle.Visible = True
                Me.lblPortAngle.Text = "Design Type"
                Me.cmbPortAngle.Visible = True
                Me.cmbPortAngle.Items.Clear()
                Me.cmbPortAngle.Items.Add("Fabricated")
                Me.cmbPortAngle.Items.Add("Casting")
            Else
                checkSubConditionsCases(Me.cmbConfiguration.Text & "_" & Me.cmbSubConfiguration.Text & "_" & Me.cmbEndPort.Text & "_" & Me.cmbPortType.Text)
            End If
        End If
    End Sub

    Sub PortAngleChangedEvent(ByVal sender As Object, ByVal e As EventArgs)
        Me.lvwDatabaseRecordView.Items.Clear()
        Me.lvwDatabaseRecordView.Clear()
        txtSearchString.Clear()
        checkSubConditionsCases(Me.cmbConfiguration.Text & "_" & Me.cmbSubConfiguration.Text & "_" & Me.cmbEndPort.Text & "_" & Me.cmbPortType.Text & "_" & Me.cmbPortAngle.Text)
    End Sub

    Sub LoadEndPorts(ByVal sender As Object, ByVal e As EventArgs)
        Me.lvwDatabaseRecordView.Items.Clear()
        Me.lvwDatabaseRecordView.Clear()
        Me.cmbEndPort.Items.Clear()
        txtSearchString.Clear()
        Me.cmbEndPort.Items.Clear()
        If Me.cmbConfiguration.Text = "Rod End" Then
            Me.cmbEndPort.Visible = True
            Me.lblBaseEndPort.Visible = True
            Me.cmbEndPort.Items.Add("Port In Tube")
            Me.lblBaseEndPort.Text = "Rod End Port"
            Me.lbDatabaseRecord.Text = "Rod End Configuration Casting Details"
            Me.cmbEndPort.SelectedIndex = 0
            MyEventHandler(sender, e)
        Else
            Me.cmbEndPort.Items.Add("Port In Tube")
            Me.cmbEndPort.Items.Add("Port Integral")
            Me.cmbPortType.Items.Clear()
            Me.cmbPortAngle.Items.Clear()
            Me.cmbPortType.Visible = False
            Me.lblTypeOfPort.Visible = False
            Me.lblPortAngle.Visible = False
            Me.cmbPortAngle.Visible = False
            Me.cmbEndPort.Visible = True
            Me.lblBaseEndPort.Visible = True
        End If
        
    End Sub

    Public Function GetDataTableValues(ByVal strQuery As String, ByVal TableName As String) As DataTable
        Dim _strErrorMessage As String
        GetDataTableValues = Nothing
        ' MonarchConnectionObject = IFLBaseDataLayer.IFLConnectionClass.GetConnectionObject("ieghpdcws106\sqlexpress", "MIL_welded", "System.Data.SqlClient", "", "", "SSPI")
        GetDataTableValues = MonarchConnectionObject.GetTable(strQuery)
        If IsNothing(GetDataTableValues) OrElse GetDataTableValues.Rows.Count = 0 Then
            GetDataTableValues = Nothing
            _strErrorMessage = "Data not retrieved from BEBasePlugCastWithOutPort table" + vbCrLf
        End If

    End Function

    Public Sub loadListViewData(ByVal dataTable As DataTable, ByVal TableName As String)
        Dim intCount As Integer = 0
        Dim oListItem As ListViewItem
        Me.lvwDatabaseRecordView.CheckBoxes = True
        Me.lvwDatabaseRecordView.HideSelection = False
        Me.lvwDatabaseRecordView.FullRowSelect = True
        Me.lvwDatabaseRecordView.MultiSelect = True
        If Not IsNothing(dataTable) AndAlso dataTable.Rows.Count > 0 Then
            Me.lvwDatabaseRecordView.Items.Clear()
            Me.lvwDatabaseRecordView.Clear()
            Me.lvwDatabaseRecordView.Columns.Add("Code No", 100, HorizontalAlignment.Center)
            Me.lvwDatabaseRecordView.Columns.Add("Description", 220, HorizontalAlignment.Center)
            Me.lvwDatabaseRecordView.Columns.Add("Is Existed?", 200, HorizontalAlignment.Center)

            For Each oDataRow As DataRow In dataTable.Rows
                If TableName = "Welded.ClevisPlateDetails" Then
                    If Not IsDBNull(oDataRow("ClevisPlateCode")) Then
                        oListItem = Me.lvwDatabaseRecordView.Items.Add(oDataRow("ClevisPlateCode"))
                        strCodeName = "ClevisPlateCode"
                    End If
                    Me.lvwDatabaseRecordView.Items(intCount).SubItems.Add("Clevis Plate")
                ElseIf TableName = "WELDED.benewcylinderDesignTable" Then
                    'MessageBox.Show("Code Numbers and Descriptions are not available.", "Records not Available", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'Exit Sub
                ElseIf TableName = "PortIntegralRaisedPortDetails" Then
                    If Not IsDBNull(oDataRow("CodeNumber")) Then
                        oListItem = Me.lvwDatabaseRecordView.Items.Add(oDataRow("CodeNumber"))
                        strCodeName = "CodeNumber"
                    End If
                    If Not IsDBNull(oDataRow("Description")) Then
                        Me.lvwDatabaseRecordView.Items(intCount).SubItems.Add(oDataRow("Description"))
                    End If
                ElseIf TableName = "PortIntegralRaisedPortDetails90" Then
                    If Not IsDBNull(oDataRow("CodeNumber")) Then
                        oListItem = Me.lvwDatabaseRecordView.Items.Add(oDataRow("CodeNumber"))
                    End If
                    Me.lvwDatabaseRecordView.Items(intCount).SubItems.Add("Clevis Plate")
                ElseIf TableName = "welded.BEThreadedBaseNoPort" OrElse TableName = "welded.BEThreadedEndFlushPort" OrElse TableName = "BEThreadedEndRaisedPort" Then
                    If Not IsDBNull(oDataRow("PartCode")) Then
                        oListItem = Me.lvwDatabaseRecordView.Items.Add(oDataRow("PartCode"))
                        strCodeName = "PartCode"
                    End If
                    If Not IsDBNull(oDataRow("PartDescription")) Then
                        Me.lvwDatabaseRecordView.Items(intCount).SubItems.Add(oDataRow("PartDescription"))
                    End If
                Else
                    If Not IsDBNull(oDataRow("PartCode")) Then
                        oListItem = Me.lvwDatabaseRecordView.Items.Add(oDataRow("PartCode"))
                        strCodeName = "PartCode"
                    End If
                    If Not IsDBNull(oDataRow("Description")) Then
                        Me.lvwDatabaseRecordView.Items(intCount).SubItems.Add(oDataRow("Description"))
                    End If
                End If
                Try
                    If Not IsDBNull(oDataRow("IsExisted")) Then
                        If oDataRow("IsExisted") = True Then
                            Me.lvwDatabaseRecordView.Items(intCount).SubItems.Add("Yes")
                            Me.lvwDatabaseRecordView.Items(intCount).Checked = True
                        Else
                            Me.lvwDatabaseRecordView.Items(intCount).SubItems.Add("No")
                        End If
                    Else
                        Me.lvwDatabaseRecordView.Items(intCount).SubItems.Add("No")
                    End If
                Catch ex As Exception
                    Me.lvwDatabaseRecordView.Items(intCount).SubItems.Add("No")
                End Try
                intCount += 1
            Next
        Else
            MessageBox.Show("Code Numbers and Descriptions are not available.", "Records not Available", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Me.lvwDatabaseRecordView.Refresh()
    End Sub

    Private Sub checkSubConditionsCases(ByVal strCombinedString As String)
        Dim strQuery As String = String.Empty
        Dim strTableName As String = String.Empty
        Select Case strCombinedString
            Case "Base End_Base Plug_Port In Tube"
                strQuery = "SELECT * FROM Welded.BEBasePlugCastWithOutPort"
                strTableName = "Welded.BEBasePlugCastWithOutPort"
            Case "Base End_Base Plug_Port Integral_Flushed"
                strQuery = "SELECT * FROM Welded.BasePlugFlushedPort"
                strTableName = "Welded.BEBasePlugCastWithOutPort"
            Case "Base End_Base Plug_Port Integral_Raised_Straight"
                strQuery = "SELECT * FROM BasePlugRaisedPort"
                strTableName = "BasePlugRaisedPort"
            Case "Base End_Base Plug_Port Integral_Raised_90"
                strQuery = "SELECT * FROM BasePlugRaisedPort90"
                strTableName = "BasePlugRaisedPort90"
            Case "Base End_Cross Tube_Port In Tube"
                strQuery = "SELECT * FROM Welded.BECrossTubeCastingWithoutPort"
                strTableName = "Welded.BECrossTubeCastingWithoutPort"
            Case "Base End_Cross Tube_Port Integral_Flushed"
                strQuery = "SELECT * FROM Welded.BECrossTubeFlushPort"
                strTableName = "Welded.BECrossTubeFlushPort"
            Case "Base End_Cross Tube_Port Integral_Raised_Straight"
                strQuery = "SELECT * FROM BECrossTubeRaisedPort"
                strTableName = "BECrossTubeRaisedPort"
            Case "Base End_Cross Tube_Port Integral_Raised_90"
                strQuery = "SELECT * FROM BECrossTubeRaisedPort90"
                strTableName = "BECrossTubeRaisedPort90"
            Case "Base End_Double Lug_Port In Tube"
                strQuery = "SELECT * FROM Welded.BEDLCastWithOutPort"
                strTableName = "Welded.BEDLCastWithOutPort"
            Case "Base End_Double Lug_Port Integral_Flushed"
                strQuery = "SELECT * FROM Welded.BEDLCastWithFlushPort"
                strTableName = "Welded.BEDLCastWithFlushPort"
            Case "Base End_Double Lug_Port Integral_Raised_Straight"
                strQuery = "SELECT * FROM BEDLCastWithRaisedPort"
                strTableName = "BEDLCastWithRaisedPort"
            Case "Base End_Double Lug_Port Integral_Raised_90"
                strQuery = "SELECT * FROM BEDLCastWithRaisedPort90"
                strTableName = "BEDLCastWithRaisedPort90"
            Case "Base End_Plate Clevis_Port In Tube"
                strQuery = "select * from Welded.ClevisPlateDetails"
                strTableName = "Welded.ClevisPlateDetails"
            Case "Base End_Plate Clevis_Port Integral_Flushed"
                strQuery = "SELECT * FROM WELDED.benewcylinderDesignTable"
                strTableName = "WELDED.benewcylinderDesignTable"
            Case "Base End_Plate Clevis_Port Integral_Raised_Straight"
                strQuery = "Select * from PortIntegralRaisedPortDetails"
                strTableName = "PortIntegralRaisedPortDetails"
            Case "Base End_Plate Clevis_Port Integral_Raised_90"
                strQuery = "Select * from PortIntegralRaisedPortDetails90"
                strTableName = "PortIntegralRaisedPortDetails90"
            Case "Base End_Single Lug_Port In Tube"
                strQuery = "SELECT * FROM Welded.BESLCastingNoPort"
                strTableName = "Welded.BESLCastingNoPort"
            Case "Base End_Single Lug_Port Integral_Flushed"
                strQuery = "SELECT * FROM Welded.BESLCastingFlushPort"
                strTableName = "Welded.BESLCastingFlushPort"
            Case "Base End_Single Lug_Port Integral_Raised_Straight"
                strQuery = "SELECT * FROM BESLCastingRaisedPort"
                strTableName = "BESLCastingRaisedPort"
            Case "Base End_Single Lug_Port Integral_Raised_90"
                strQuery = "SELECT * FROM BESLCastingRaisedPort90"
                strTableName = "BESLCastingRaisedPort90"
            Case "Base End_Threaded End_Port In Tube"
                strQuery = "select * from welded.BEThreadedBaseNoPort"
                strTableName = "welded.BEThreadedBaseNoPort"
            Case "Base End_Threaded End_Port Integral_Flushed"
                strQuery = "select * from welded.BEThreadedEndFlushPort"
                strTableName = "welded.BEThreadedEndFlushPort"
            Case "Base End_Threaded End_Port Integral_Raised_Straight"
                strQuery = "select * from BEThreadedEndRaisedPort"
                strTableName = "BEThreadedEndRaisedPort"
            Case "Base End_Threaded End_Port Integral_Raised_90"
                strQuery = "select * from BEThreadedEndRaisedPort90"
                strTableName = "BEThreadedEndRaisedPort90"
                '------------------------------------------------------------
                '-----------Rod End Configuration----------------------------
            Case "Rod End_Cross Tube_Port In Tube"
                strQuery = "select * from Welded.RECrossTubeCasting"
                strTableName = "Welded.RECrossTubeCasting"
            Case "Rod End_Double Lug_Port In Tube_Welded_Casting"
                strQuery = "SELECT * FROM Welded.REDLCasting"
                strTableName = "Welded.REDLCasting"
            Case "Rod End_Single Lug_Port In Tube"
                strQuery = "SELECT * FROM Welded.RESLDetails"
                strTableName = "Welded.RESLDetails"
            Case "Rod End_Double Lug_Port In Tube_Welded_Fabricated"
                strQuery = "SELECT * FROM Welded.BEULDetails"
                strTableName = "Welded.BEULDetails"
            Case "Rod End_Double Lug_Port In Tube_Threaded"
                strQuery = "SELECT * FROM Welded.BEULDetails"
                strTableName = "Welded.BEULDetails"
        End Select
        Dim oDataTable As DataTable
        oDataTable = GetDataTableValues(strQuery, strTableName)
        loadListViewData(oDataTable, strTableName)
        If Me.lvwDatabaseRecordView.Items.Count = 0 Then
            MessageBox.Show("Code Numbers and Descriptions are not available.", "Records not Available", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        TableName = strTableName
    End Sub

    Sub LoadConfigurations(ByVal sender As Object, ByVal e As EventArgs)
        Me.lvwDatabaseRecordView.Items.Clear()
        Me.lvwDatabaseRecordView.Clear()
        txtSearchString.Clear()
        If Trim(sender.Text) <> "" Then
            If sender.Text = "Base End" Then
                Me.cmbSubConfiguration.Items.Clear()
                Me.cmbSubConfiguration.Items.Add("Plate Clevis")
                Me.cmbSubConfiguration.Items.Add("Cross Tube")
                Me.cmbSubConfiguration.Items.Add("Single Lug")
                Me.cmbSubConfiguration.Items.Add("Double Lug")
                Me.cmbSubConfiguration.Items.Add("Base Plug")
                Me.cmbSubConfiguration.Items.Add("Threaded End")
                Me.cmbEndPort.Items.Clear()
                Me.cmbEndPort.Items.Add("Port In Tube")
                Me.cmbEndPort.Items.Add("Port Integral")
                Me.cmbEndPort.Visible = False
                Me.lblBaseEndPort.Visible = False
                Me.lblBaseEndPort.Text = "Base End Port"
                Me.lbDatabaseRecord.Text = "Base End Configuration Casting Details"
            Else
                Me.cmbSubConfiguration.Items.Clear()
                Me.cmbSubConfiguration.Items.Add("Cross Tube")
                Me.cmbSubConfiguration.Items.Add("Single Lug")
                Me.cmbSubConfiguration.Items.Add("Double Lug")
                Me.cmbEndPort.Visible = False
                Me.lblBaseEndPort.Visible = False
                Me.lblBaseEndPort.Text = "Rod End Port"
                Me.lbDatabaseRecord.Text = "Rod End Configuration Casting Details"
            End If
        End If

    End Sub

    Sub loadDataTableBackToDatabase(ByVal sender As Object, ByVal e As ItemCheckEventArgs)
        ' Dim item As ListViewItem
        Dim checkedItems As ListView.CheckedListViewItemCollection = Me.lvwDatabaseRecordView.CheckedItems
        'If checkedItems.Count > 0 Then
        btnUpdateToDatabase.Enabled = False
        '  For Each item In checkedItems
        If (e.NewValue = CheckState.Unchecked) Then
            Try
                Me.lvwDatabaseRecordView.Items(e.Index).SubItems(2).Text = "No"
                btnUpdateToDatabase.Enabled = True
            Catch ex As Exception
            End Try

        ElseIf (e.NewValue = CheckState.Checked) Then
            Try
                Me.lvwDatabaseRecordView.Items(e.Index).SubItems(2).Text = "Yes"
                btnUpdateToDatabase.Enabled = True
            Catch ex As Exception
                btnUpdateToDatabase.Enabled = False
            End Try
        End If
        '  Next
        ' Else
        ' btnUpdateToDatabase.Enabled = False
        ' End If
    End Sub

    Sub checkItemsSelected(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item As ListViewItem
        Dim selectedItems As ListView.SelectedListViewItemCollection = Me.lvwDatabaseRecordView.SelectedItems
        If selectedItems.Count > 0 Then
            For Each item In selectedItems
                If item.Selected = True AndAlso item.Focused = True Then
                    Me.lvwDatabaseRecordView.Items(item.Index).SubItems(2).Text = "Yes"
                    Me.lvwDatabaseRecordView.Items(item.Index).Checked = True
                End If
            Next
            btnUpdateToDatabase.Enabled = True
        Else
            btnUpdateToDatabase.Enabled = False
        End If

    End Sub

    Sub UpdateButtonClicked(ByVal sender As Object, ByVal e As EventArgs)
        Dim arbLVI As ListViewItem
        Dim _strQuery As String = ""
        Dim _strErrorMsg As String = ""
        Dim strResult
        Dim _sqlCommand As New SqlClient.SqlCommand()
        _strQuery = "begin Tran" + vbNewLine
        For Each arbLVI In Me.lvwDatabaseRecordView.Items
            _strQuery += "Update " & TableName & " Set IsExisted = " & IIf(arbLVI.SubItems(2).Text = "Yes", "'True'", "'False'").ToString & _
             " Where " & strCodeName & " = '" & arbLVI.Text & "'" + vbNewLine
        Next
        _strQuery += "Commit"
        Try
            Dim _da As New SqlClient.SqlDataAdapter(_strQuery, MonarchConnectionObject.ConnectionString)
            _sqlCommand = New SqlClient.SqlCommand(_strQuery, MonarchConnectionObject.ConnectionObject)
            _sqlCommand.Connection.Open()
            Try
                _sqlCommand.ExecuteNonQuery()
                MessageBox.Show("Data updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                _sqlCommand.Connection.Close()
                _strErrorMsg = String.Empty
                _strErrorMsg = ex.Message

                strResult = Split(_strErrorMsg, vbNewLine)

            Finally
                MsgBox("Column Name not existed --" + vbNewLine + strResult(0).ToString, MsgBoxStyle.Information)
        End Try
            If _sqlCommand.Connection.State = ConnectionState.Open Then
                _sqlCommand.Connection.Close()
            End If
        Catch ex As Exception
            ' MsgBox(ex.Message)
            _sqlCommand.Connection.Close()
            Exit Sub
        End Try
    End Sub

    Sub SearchRecordfromTextBox(ByVal sender As Object, ByVal e As EventArgs)
        If Trim(sender.Text) <> "" Then
            For Each oitem As ListViewItem In Me.lvwDatabaseRecordView.Items
                If Trim(sender.Text).Equals(oitem.Text) Then
                    Me.lvwDatabaseRecordView.Items(oitem.Index).Checked = True
                    Me.lvwDatabaseRecordView.Items(oitem.Index).Selected = True

                End If
            Next
        End If
    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(lblGreen4, lblGreen1, lblGreen2, lblGreen3)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblOrange)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lbDatabaseRecord)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Visible = False
    End Sub

End Class


