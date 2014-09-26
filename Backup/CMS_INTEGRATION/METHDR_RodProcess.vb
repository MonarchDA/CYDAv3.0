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

                '11_10_2010    RAGAVA
                For Each item As String In ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodWorkCenterList
                    'strData.AppendLine(DoEachRowProcess(intSequence, ht.Item(item)))
                    strData.AppendLine(DoEachRowProcess(intSequence, ht.Item(item), item))     '03_11_2010   RAGAVA
                    intSequence += 10
                Next
                'For Each strKey As String In ht.Keys
                '    strData.AppendLine(DoEachRowProcess(intSequence, ht.Item(strKey)))
                '    intSequence += 10
                'Next
                'Till   Here
            End If
        Catch ex As Exception
        End Try

        Return strData.ToString
    End Function

    Private Function DoEachRowProcess(ByVal intSequence As Integer, ByVal oWCDetails As WCStructure, ByVal item As String)       '03_11_2010   RAGAVA   item is added
        Dim oMethdR As New CMS_METHDR(CMS_METHDR.SubTypes.Others)

        oMethdR.PartNumber = _partNumber
        '12_10_2010     RAGAVA
        Try
            If ObjClsWeldedCylinderFunctionalClass.RodSequence_Details.ContainsKey(oWCDetails.WorkCenter) = True Then
                '03_11_2010   RAGAVA
                If item = "WC550_1" Then
                    oMethdR.Seq = Format(41, "000").ToString
                Else
                    oMethdR.Seq = Format(Val(ObjClsWeldedCylinderFunctionalClass.RodSequence_Details(oWCDetails.WorkCenter)), "000").ToString   '13_10_2010   RAGAVA   ' intSequence
                End If
                'oMethdR.Seq = Format(Val(ObjClsWeldedCylinderFunctionalClass.RodSequence_Details(oWCDetails.WorkCenter)), "000").ToString   '13_10_2010   RAGAVA   ' intSequence
                'Till   Here
            End If
        Catch ex As Exception
        End Try
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
