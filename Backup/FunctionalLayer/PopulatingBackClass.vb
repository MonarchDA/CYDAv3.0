Public Class PopulatingBackClass
    Private Shared _oPopulatingBackClass As PopulatingBackClass
    Private _Dataset As DataSet
    Private _strExecutionPath As String
    Private _strContractNumber As String
    Private _strRevisionConractNo As String
    Private _strDescription As String

    'Private _strAssemblyType As String
    'Private _strCustomerPartCode As String

    'Using this property , we are using the single instance in etire application

    Public Shared ReadOnly Property GetPopulatingObject() As PopulatingBackClass
        Get
            If IsNothing(_oPopulatingBackClass) Then
                _oPopulatingBackClass = New PopulatingBackClass
            End If
            Return _oPopulatingBackClass
        End Get
    End Property

    Private Sub New()
        _Dataset = New DataSet
        _strDescription = "First"
        _strExecutionPath = Application.StartupPath
    End Sub

    Public ReadOnly Property Dataset() As DataSet
        Get
            Return _Dataset
        End Get
    End Property

    Public Property ContractNumber() As String
        Get
            Return _strContractNumber
        End Get
        Set(ByVal value As String)
            _strContractNumber = value
        End Set
    End Property

    Public Property RevisionContractNumber() As String
        Get
            Return _strRevisionConractNo
        End Get
        Set(ByVal value As String)
            _strRevisionConractNo = value
        End Set
    End Property

    Public Property ExecutionPath() As String
        Get
            Return _strExecutionPath
        End Get
        Set(ByVal value As String)
            _strExecutionPath = value
        End Set
    End Property

    Public Function StoreFormDataIntoDB() As Boolean
        Dim oTable As DataTable
        _Dataset = New DataSet
        For Each oItem As Object In ObjClsWeldedCylinderFunctionalClass.FormNavigationOrder
            oTable = GetDataToSave(oItem(clsWeldedCylinderFunctionalClass.EOrderOfFormNavigationArraylist.CurrentFormObject))
            Dataset.Tables.Add(oTable)
        Next
        _strContractNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber
        StoreFormDataIntoDB = StoreContractDetails()
    End Function

    'It is used to find the form in the dataset and if form is available , then set available data to the form
    Public Function SetDataToForm(ByVal oForm As Form) As Boolean
        Dim intIndex As Integer = Dataset.Tables.IndexOf(oForm.Name)
        If intIndex >= 0 Then
            Dim oTable As DataTable = Dataset.Tables(intIndex)
            Dim IFLBaseData As New IFLGetSetUI.IFLGetSetUIClass
            IFLBaseData.SetDataToForm(oTable, oForm)
            Return True
        End If
        Return False
    End Function

    Private Function GetByteArray() As Byte()
        Dataset.WriteXml(ExecutionPath + "\MIL.xml")
        Dim fsBLOBFile As New System.IO.FileStream(ExecutionPath + "\MIL.xml", IO.FileMode.Open)
        Dim bytBLOBData(fsBLOBFile.Length() - 1) As Byte
        fsBLOBFile.Read(bytBLOBData, 0, bytBLOBData.Length)
        fsBLOBFile.Close()
        Return bytBLOBData
    End Function

    Private Function GetDataToSave(ByVal oForm As Form) As DataTable
        Dim oGetSetUIClass As New IFLGetSetUI.IFLGetSetUIClass
        setPrimaryInputsScreen(oForm)
        Dim oTable As DataTable = oGetSetUIClass.StoreFormData(oForm)
        Return oTable
    End Function

    Private Sub setPrimaryInputsScreen(ByVal oForm As Object)

        If oForm.Name = "frmPrimaryInputs" Then
            Dim oPrimaryInputs As frmPrimaryInputs = CType(oForm, frmPrimaryInputs)
            Dim count As Integer = oPrimaryInputs.lvwPressureSelection.SelectedItems.Count
            'rod diamter List view 
            If count = 0 Then
                Dim oListviewItem As ListViewItem = oPrimaryInputs.lvwPressureSelection.FindItemWithText(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter)
                Dim Position As Integer = oPrimaryInputs.lvwPressureSelection.Items.IndexOf(oListviewItem)
                If Position >= 0 Then
                    oPrimaryInputs.lvwPressureSelection.Items(Position).Selected = True
                End If
            End If
            'Piston List View
            count = oPrimaryInputs.lvwPistonDetails.SelectedItems.Count
            If count = 0 Then
                Dim oListviewItem As ListViewItem = oPrimaryInputs.lvwPistonDetails.FindItemWithText(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PistonNutSizeInFractions)
                Dim Position As Integer = oPrimaryInputs.lvwPistonDetails.Items.IndexOf(oListviewItem)
                If Position >= 0 Then
                    oPrimaryInputs.lvwPistonDetails.Items(Position).Selected = True
                End If
            End If
        End If
    End Sub

    Public Function GetFormDataFromDB(ByVal ContractNumber) As Boolean
        Try
            Dim strQuery As String
            strQuery = "SELECT PROJECT_XML FROM ContractMaster WHERE ContractNumber='" + ContractNumber + "'"
            Dim strByte() As Byte = MonarchConnectionObject.GetValue(strQuery)
            Dim strXMLFilePath As String = _strExecutionPath + "\MIL.xml"
            If IO.File.Exists(strXMLFilePath) Then
                IO.File.Delete(strXMLFilePath)
            End If
            Dim fstream As New System.IO.FileStream(strXMLFilePath, IO.FileMode.OpenOrCreate)
            Dim bw As System.IO.BinaryWriter = New System.IO.BinaryWriter(fstream)
            Dim br As System.IO.BinaryReader = New System.IO.BinaryReader(fstream)
            bw.Write(strByte)
            br.Close()

            _Dataset = New DataSet(ContractNumber)
            Dataset.ReadXml(strXMLFilePath)
            If IO.File.Exists(strXMLFilePath) Then
                IO.File.Delete(strXMLFilePath)
            End If
            Return True

        Catch ex As Exception

        End Try
    End Function

    Private Function StoreContractDetails() As Boolean
        Try
            Dim oRow As DataRow
            Dim oDataBaseClass As New IFLBaseDataLayer.IFLBaseDataClass(MonarchConnectionObject)
            Dim IsNewRecord As Boolean = False
            Dim strContractNo As String
            Dim aData As Byte() = GetByteArray()

            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.New_Revision = "New'" Then
                strContractNo = _strContractNumber
            Else
                strContractNo = _strRevisionConractNo
            End If
            oDataBaseClass.LoadTable("ContractMaster", , "ContractNumber", strContractNo, , )
            Dim oTable As DataTable = oDataBaseClass.GetDataTable("ContractMaster")
            If oTable.Rows.Count = 0 Then
                oRow = oDataBaseClass.GetNewRecord("ContractMaster")
                oRow("CustomerName") = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CustomerName_ContractDetails
                oRow("ContractNumber") = _strContractNumber
                oRow("ContractRevision") = 0
                oRow("Description") = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AssemblyType_ContractDetails
                oRow("AssemblyType") = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AssemblyType_ContractDetails
                oRow("Project_XML") = aData
                oRow("CustomerPartCode") = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PartCode_ContractDetails
                oDataBaseClass.AddNewRecord("ContractMaster", oRow)
            Else
                oRow = oTable.Rows(0)
                'oRow("ContractRevision") = oTable.Rows.Count
                oRow("ContractRevision") = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables._intContractRevisionNumber + 1                '05_07_2010           RAGAVA
                oRow("Project_XML") = aData
            End If
            StoreContractDetails = oDataBaseClass.SaveData
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

End Class
