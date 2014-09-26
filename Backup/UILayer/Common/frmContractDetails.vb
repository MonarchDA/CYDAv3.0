Public Class frmContractDetails

    Dim strCustomerName As String

    'ANUP 01-12-2010 START
    Private _strSearchedCustomer As String
    'ANUP 01-12-2010 TILL HERE

#Region "SubProcedures"


    Public Sub ManualLoad()
        CustomerNameLoad(cmbCustomerName)
        InitialSettings()
        Me.AutoScrollPosition = New Point(150, 125)
    End Sub

    Private Sub CustomerNameLoad(ByVal cbCustomerName As ComboBox)
        Dim CustomerNameDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetCustomerName

        If Not IsNothing(CustomerNameDataTable) AndAlso CustomerNameDataTable.Rows.Count > 0 Then
            For Each oCustomerNameDataRow As DataRow In CustomerNameDataTable.Rows
                If Not IsDBNull(oCustomerNameDataRow(0)) Then
                    cbCustomerName.Items.Add(oCustomerNameDataRow(0).ToString)
                End If
            Next
        End If
    End Sub

    Private Sub InitialSettings()

        chkManageCustomers.Checked = False
        LabelGradient1.Enabled = False

        cmbAssemblyType.Items.Clear()
        cmbAssemblyType.Items.Add("Welded Cylinder Assembly")
        cmbAssemblyType.SelectedIndex = 0  '20_12_2010   RAGAVA
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CustomerNameComboBOxChanged = False
    End Sub

    Private Sub btnAddorDeleteClick()

        cmbCustomerName.Items.Clear()
        CustomerNameLoad(cmbCustomerName)

        cmbCustomerName_Delete.Items.Clear()
        CustomerNameLoad(cmbCustomerName_Delete)

    End Sub

#End Region

#Region "Events"

    Private Sub frmContractDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
    End Sub

    Private Sub chkManageCustomers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkManageCustomers.CheckedChanged
        Try
            If chkManageCustomers.Checked = True Then
                GroupBox1.Visible = True
                LabelGradient1.Visible = True
                pnlManageCustomerDetails.Visible = True
                txtCustomerName_Add.Enabled = True
                cmbCustomerName_Delete.Enabled = True

                cmbCustomerName_Delete.Items.Clear()
                CustomerNameLoad(cmbCustomerName_Delete)
            Else
                GroupBox1.Visible = False
                LabelGradient1.Visible = False
                pnlManageCustomerDetails.Visible = False
                txtCustomerName_Add.Enabled = False
                cmbCustomerName_Delete.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    'ANUP 01-12-2010 START
    Private Sub cmbCustomerName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCustomerName.KeyUp
        Try
            If (e.KeyValue >= 65 AndAlso e.KeyValue <= 90) OrElse (e.KeyValue >= 48 AndAlso e.KeyValue <= 57) _
            OrElse (e.KeyValue >= 186 AndAlso e.KeyValue <= 192) OrElse (e.KeyValue >= 219 AndAlso e.KeyValue <= 222) _
            OrElse e.KeyValue = 106 OrElse e.KeyValue = 109 OrElse e.KeyValue = 110 OrElse e.KeyValue = 111 OrElse e.KeyCode = Keys.Space Then


                If e.Shift Then
                    If (e.KeyValue >= 48 AndAlso e.KeyValue <= 57) OrElse e.KeyValue = 190 Then
                        _strSearchedCustomer += HTReturnDKeyCharacters.Item(e.KeyValue)(0).ToString
                    End If
                Else
                    If (e.KeyValue >= 48 AndAlso e.KeyValue <= 57) OrElse e.KeyValue = 190 Then
                        _strSearchedCustomer += HTReturnDKeyCharacters.Item(e.KeyValue)(1).ToString
                    ElseIf e.KeyCode = Keys.Space Then
                        _strSearchedCustomer += " "
                    Else
                        _strSearchedCustomer += e.KeyData.ToString
                    End If
                End If

                Dim strQuery As String = "select CustomerName from Welded.CustomerDetails where CustomerName like '" & _strSearchedCustomer & "%' order by CustomerName Asc"
                Dim CustomerNameDataTable As DataTable = MonarchConnectionObject.GetTable(strQuery)
                If Not IsNothing(CustomerNameDataTable) AndAlso CustomerNameDataTable.Rows.Count > 0 Then
                    For Each oCustomerNameDataRow As DataRow In CustomerNameDataTable.Rows
                        If Not IsDBNull(oCustomerNameDataRow(0)) Then
                            cmbCustomerName.Text = oCustomerNameDataRow(0).ToString
                            Exit For
                        End If
                    Next
                Else
                    _strSearchedCustomer = String.Empty
                    _strSearchedCustomer = e.KeyData.ToString
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private ReadOnly Property HTReturnDKeyCharacters() As Hashtable
        Get
            Dim htReturnDKeyChar As New Hashtable
            htReturnDKeyChar.Add(48, New Object(1) {")", 0})
            htReturnDKeyChar.Add(49, New Object(1) {"!", 1})
            htReturnDKeyChar.Add(50, New Object(1) {"@", 2})
            htReturnDKeyChar.Add(51, New Object(1) {"#", 3})
            htReturnDKeyChar.Add(52, New Object(1) {"$", 4})
            htReturnDKeyChar.Add(53, New Object(1) {"%", 5})
            htReturnDKeyChar.Add(54, New Object(1) {"^", 6})
            htReturnDKeyChar.Add(55, New Object(1) {"&", 7})
            htReturnDKeyChar.Add(56, New Object(1) {"*", 8})
            htReturnDKeyChar.Add(57, New Object(1) {"(", 9})
            htReturnDKeyChar.Add(190, New Object(1) {">", "."})
            Return htReturnDKeyChar
        End Get
    End Property

    Private Sub cmbCustomerName_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCustomerName.DropDownClosed
        Try
            _strSearchedCustomer = String.Empty
        Catch ex As Exception
        End Try
    End Sub
    'ANUP 01-12-2010 TILL HERE

    Private Sub cmbCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCustomerName.SelectedIndexChanged
        If Not cmbCustomerName.Text = "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CustomerName_ContractDetails = cmbCustomerName.Text
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CustomerNameComboBOxChanged = True
        End If
    End Sub

    Private Sub cmbAssemblyType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAssemblyType.SelectedIndexChanged
        If Not cmbAssemblyType.Text = "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AssemblyType_ContractDetails = cmbAssemblyType.Text
        End If
    End Sub

    Private Sub txtlPartCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtlPartCode.TextChanged
        If Not txtlPartCode.Text = "" Then
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PartCode_ContractDetails = txtlPartCode.Text
        End If
    End Sub

#Region "Customer Name in ListBox Functionality"

    Private Sub txtCustomerName_Add_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustomerName_Add.KeyUp
        Try
            If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Then
                ListBox1.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtCustomerName_Add_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomerName_Add.TextChanged
        Try
            strCustomerName = txtCustomerName_Add.Text
            If strCustomerName <> "" Then
                Dim GetCustomerNameInListBoxDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetCustomerNameInListBox(strCustomerName)
                ListBox1.BringToFront()
                ListBox1.Items.Clear()
                If Not IsNothing(GetCustomerNameInListBoxDataTable) AndAlso GetCustomerNameInListBoxDataTable.Rows.Count > 0 Then
                    ListBox1.Visible = True
                    For Each GetCustomerNameInListBoxDataRow As DataRow In GetCustomerNameInListBoxDataTable.Rows
                        If Not IsDBNull(GetCustomerNameInListBoxDataRow(0)) Then
                            ListBox1.Items.Add(GetCustomerNameInListBoxDataRow(0).ToString)
                        End If
                    Next
                Else
                    ListBox1.Visible = False
                End If
            Else
                ListBox1.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.Leave
        Try
            txtCustomerName_Add.Text = ListBox1.SelectedItem.ToString()
            txtCustomerName_Add.SelectionStart = txtCustomerName_Add.Text.Length
            ListBox1.SendToBack()
            txtCustomerName_Add.Focus()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ListBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.LostFocus
        ListBox1.Visible = False
    End Sub

    Private Sub ListBox1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDoubleClick
        Try
            txtCustomerName_Add.Text = ListBox1.SelectedItem
            txtCustomerName_Add.Focus()
        Catch ex As Exception
        End Try
    End Sub

#End Region

#End Region

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If Not strCustomerName = "" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.InsertingCustomerName(strCustomerName) Then
                    MessageBox.Show("Customer Name Added", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    btnAddorDeleteClick()
                Else
                    MessageBox.Show("Customer Name already present", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                txtCustomerName_Add.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If Not cmbCustomerName_Delete.Text = "" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.DeletingCustomerName(cmbCustomerName_Delete.Text) Then
                    btnAddorDeleteClick()
                    MessageBox.Show("Customer Name Deleted", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Customer Name cannot be Deleted", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
               
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, LabelGradient5, LabelGradient4, LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblGradientContractDetails)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(LabelGradient1)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblGradientPrimaryInformation)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(LabelGradient6)
    End Sub
End Class