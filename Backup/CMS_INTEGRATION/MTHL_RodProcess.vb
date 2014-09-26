Public Class MTHL_RodProcess
    Inherits CMS_Process

    Public Sub New()
        MyBase.New(String.Empty)
    End Sub

    Public Overrides Function Start() As String
        Dim strData As New System.Text.StringBuilder
        Dim intSequence As Integer = 10
        Dim oRodToolList As New CMS_MTHL_TubeTools()
        'ANUP 27-09-2010 START 
        _partNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT")
        Dim oRodTools As New CMC_MTHL_RodTools
        Dim ToolList As ArrayList = oRodTools.CMSMainFunction_Rod
        'ANUP 27-09-2010 TILL HERE


        Dim icount As Integer = 0
        Dim iCount1 As Integer = 0
        For Each oItem As Object In ToolList
            
            strData.AppendLine(DoEachRowProcess(intSequence, oItem, icount))


            If (icount + 1) >= oRodTools.SequenceCount(iCount1) Then
                iCount1 = iCount1 + 1
                intSequence = intSequence + 10
                icount = 0
            Else
                icount = icount + 1
            End If

        Next
        Return strData.ToString
        'Return String.Empty
    End Function

    Private Function DoEachRowProcess(ByVal intSequence As Integer, ByVal oTool As String, ByVal iCount As Integer)
        Dim oMthl As New CMS_MTHL()
        Dim strarr() As String = oTool.Split("&")       '11_10_2010   RAGAVA
        oMthl.PartNumbers = _partNumber
        oMthl.ToolNumbers = strarr(1) '11_10_2010
        oMthl.LineNumbers = iCount + 1
        oMthl.Sequence = Format(Val(strarr(0)), "000").ToString   '13_10_2010
        Return oMthl.ToString()
    End Function

    Public Overrides ReadOnly Property FileName() As String
        Get
            Return "MTHL" & _partNumber
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return "MTHL Rod Process"
    End Function
End Class
