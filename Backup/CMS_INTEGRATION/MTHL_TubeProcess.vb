Public Class MTHL_TubeProcess
    Inherits CMS_Process

    Public Sub New()
        MyBase.New(String.Empty)
    End Sub
    'Public Sub New(ByVal partNumber As String)
    '    MyBase.New(partNumber)
    'End Sub

    Public Overrides Function Start() As String
        Try
            Dim strData As New System.Text.StringBuilder
            Dim intSequence As Integer = 10
            '24_09_2010  RAGAVA
            _partNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT")
            Dim ToolList As ArrayList
            Dim oTubeToolList As New CMS_MTHL_TubeTools()
            'Select Case (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube)
            '    Case ("1")
            'End Select
            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "01" Then
                ToolList = oTubeToolList.GetSheet1_Tools()
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "02" Then
                ToolList = oTubeToolList.GetSheet2_Tools()
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "03" Then
                ToolList = oTubeToolList.GetSheet3_Tools()
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "04" Then
                ToolList = oTubeToolList.GetSheet4_Tools()
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "05" Then
                ToolList = oTubeToolList.GetSheet5_Tools()
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "06" Then
                ToolList = oTubeToolList.GetSheet6_Tools()
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "07" Then
                ToolList = oTubeToolList.GetSheet7_Tools()
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "08" Then
                ToolList = oTubeToolList.GetSheet8_Tools()
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "09" Then
                ToolList = oTubeToolList.GetSheet9_Tools()
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "10" Then
                ToolList = oTubeToolList.GetSheet10_Tools()
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "11" Then
                ToolList = oTubeToolList.GetSheet11_Tools()
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "12" Then
                ToolList = oTubeToolList.GetSheet12_Tools()

                '29_02_2012   RAGAVA
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "13" Then
                ToolList = oTubeToolList.GetSheet13_Tools()
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "14" Then
                ToolList = oTubeToolList.GetSheet14_Tools()
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "15" Then
                ToolList = oTubeToolList.GetSheet15_Tools()
            ElseIf ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strSheetNumber_Tube = "16" Then
                ToolList = oTubeToolList.GetSheet16_Tools()
            End If

            Dim icount As Integer = 0
            Dim iCount1 As Integer = 0
            For Each oItem As Object In ToolList
                
                strData.AppendLine(DoEachRowProcess(intSequence, oItem, icount))


                If (icount + 1) >= oTubeToolList.SequenceCount(iCount1) Then
                    iCount1 = iCount1 + 1
                    intSequence = intSequence + 10
                    icount = 0
                Else
                    icount = icount + 1
                End If
            Next
            Return strData.ToString
        Catch ex As Exception
        End Try
        'Return String.Empty
    End Function

    Private Function DoEachRowProcess(ByVal intSequence As Integer, ByVal oItem As String, ByRef icount As Integer)
        Try
            Dim strarr() As String = oItem.Split("&")      '11_10_2010   RAGAVA
            Dim oMthl As New CMS_MTHL()
            oMthl.PartNumbers = _partNumber
            oMthl.ToolNumbers = strarr(1) '11_10_2010      RAGAVA    oItem
            oMthl.LineNumbers = icount + 1
            oMthl.Sequence = Format(Val(strarr(0)), "000").ToString     '13_10_2010      RAGAVA    intSequence
            Return oMthl.ToString()
        Catch ex As Exception
        End Try
    End Function

    Public Overrides ReadOnly Property FileName() As String
        Get
            Return "MTHL" & _partNumber
        End Get
    End Property


    Public Overrides Function ToString() As String
        Return "MTHL Tube Process"
    End Function


    Public Function MTHL_BASEEND_LUG(ByRef strPart As String) As String
        Try
            Dim strData As New System.Text.StringBuilder
            Dim intSequence As Integer = 10
            Dim ToolList As New ArrayList
            'Dim oTubeToolList As New CMS_MTHL_TubeTools()

            If (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType = "Fabricated" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfigurationDesignType2 = "Fabricated") AndAlso _
                    (ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug") Then
                _partNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart)       '19_07_2012   RAGAVA
                If (Trim(_partNumber) <> "" AndAlso Val(_partNumber) >= Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart)) OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Lug_BE Then 'anup 17-02-2011
                    '_partNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ConfigurationCode_BaseEnd      '19_07_2012  RAGAVA
                    strPart = _partNumber
                    ToolList.Add("10&MF-8210") 'anup 18-03-2011
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.BaseEndConfiguration = "Double Lug" Then
                        ToolList.Add("20&MF-8227")  'anup 18-03-2011
                    End If
                    Dim icount As Integer = 0
                    Dim iCount1 As Integer = 0
                    For Each oItem As Object In ToolList
                        strData.AppendLine(DoEachRowProcess(intSequence, oItem, icount))
                        If ToolList.Count > 1 Then
                            icount = icount + 1
                        End If
                    Next
                    Return strData.ToString
                End If
            End If
        Catch ex As Exception

        End Try
    End Function

    Public Function MTHL_RODEND_LUG(ByRef strPart As String) As String
        Try
            Dim strData As New System.Text.StringBuilder
            Dim intSequence As Integer = 10
            Dim ToolList As New ArrayList
            'Dim oTubeToolList As New CMC_MTHL_RodTools()  
            'If Trim(ObjClsWeldedCylinderFunctionalClass.strExistingRodEndPartCode) = "" Then  'anup 18-03-2011
            If ObjClsWeldedCylinderFunctionalClass.strRE_Cast_Fabricated = "Fabricated" Then
                If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Single Lug" OrElse ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" Then
                    If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable.ContainsKey(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName) Then
                        Dim strInternalPartNumber As String = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
                        If (Val(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strNewPartCodeNumber_BeforeContractStart) <= Val(strInternalPartNumber)) OrElse ObjClsWeldedCylinderFunctionalClass.IsExistingButNotReleased_Lug_RE Then 'anup 17-02-2011
                            _partNumber = strInternalPartNumber
                            strPart = _partNumber
                            ToolList.Add("10&MF-8210") 'anup 18-03-2011
                            If ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndConfiguration = "Double Lug" Then
                                ToolList.Add("20&MF-8227") 'anup 18-03-2011
                            End If
                            Dim icount As Integer = 0
                            Dim iCount1 As Integer = 0
                            For Each oItem As Object In ToolList
                                strData.AppendLine(DoEachRowProcess(intSequence, oItem, icount))
                                If ToolList.Count > 1 Then
                                    icount = icount + 1
                                End If
                            Next
                            Return strData.ToString
                        End If
                    End If
                End If
            End If
            '     End If
        Catch ex As Exception

        End Try
    End Function
End Class
