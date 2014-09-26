Public Class METHDR_LugProcess
    Inherits CMS_Process

    Public Sub New()
        MyBase.New(String.Empty)
    End Sub

    Public Overrides Function Start() As String
        Dim strData As New System.Text.StringBuilder
        Dim intSequence As Integer = 10

        Try
            Dim ht As Hashtable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldedBELugWCDetails

            If Not ht Is Nothing Then
                For Each strKey As String In ht.Keys
                    _partNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.strBaseEndFabricationPart)       '19_07_2012   RAGAVA
                    strData.AppendLine(DoEachRowProcess(intSequence, ht.Item(strKey)))

                    intSequence += 10
                Next
            End If

            ht = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldedRELugWCDetails

            If Not ht Is Nothing Then
                For Each strKey As String In ht.Keys
                    _partNumber = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodEndPartName)
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
        Return "METHDR Lug Process"
    End Function

End Class
