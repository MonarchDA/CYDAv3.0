Public Class METHDR_RodProcess
    Inherits CMS_Process

    Public Sub New()
        MyBase.New(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT"))
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("ROD_WELDMENT")
    End Sub

    Public Overrides Function Start() As String
        Dim strData As New System.Text.StringBuilder
        Dim intSequence As Integer = 10

        Try
            Dim ht As Hashtable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldedRodWCDetails

            If Not ht Is Nothing Then
                For Each strKey As String In ht.Keys
                    strData.AppendLine(DoEachRowProcess(intSequence, ht.Item(strKey)))
                    intSequence += 10
                Next
            End If
        Catch ex As Exception
        End Try

        Return strData.ToString
    End Function

    Private Function DoEachRowProcess(ByVal intSequence As Integer, ByVal oWCDetails As WCStructure)
        Dim oMethdR As New CMS_METHDR(CMS_METHDR.SubTypes.Others)

        oMethdR.PartNumber = _partNumber
        oMethdR.Seq = intSequence

        SetValues(oMethdR, oWCDetails)

        Return oMethdR.ToString()
    End Function

    Public Overrides ReadOnly Property FileName() As String
        Get
            Return "METHDR" & _partNumber
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return "METHDR Rod Process"
    End Function
End Class
