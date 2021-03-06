Public Class METHDR_TubeProcess
    Inherits CMS_Process

    Public Sub New()
        MyBase.New(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT"))
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.oRenamingHashTable("TUBE_WELDMENT")
    End Sub

    Public Overrides Function Start() As String
        Dim strData As New System.Text.StringBuilder
        Dim intSequence As Integer = 10

        Try
            Dim ht As Hashtable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldedTubeWCDetails

            If Not ht Is Nothing Then

                '11_10_2010    RAGAVA
                For Each item As String In ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.TubeWorkCenterList

                    '06_04_2011  RAGAVA Commented
                    ''anup 11-03-2011 start
                    'If item = "WC085" Then
                    '    Continue For
                    'End If
                    ''anup 11-03-2011 till here
                    
                    strData.AppendLine(DoEachRowProcess(intSequence, ht.Item(item)))
                    intSequence += 10

                Next
                'For Each strKey As String In ht.Keys
                '    strData.AppendLine(DoEachRowProcess(intSequence, ht.Item(strKey)))
                '    intSequence += 10
                'Next
                'Till  Here
            End If
           
        Catch ex As Exception
        End Try

        Return strData.ToString
    End Function

    Private Function DoEachRowProcess(ByVal intSequence As Integer, ByVal oWCDetails As WCStructure)
        Dim oMethdR As New CMS_METHDR(CMS_METHDR.SubTypes.Others)

        oMethdR.PartNumber = _partNumber
        Try
            '12_10_2010     RAGAVA
            If ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details.ContainsKey(oWCDetails.WorkCenter) = True Then
                intSequence = Val(ObjClsWeldedCylinderFunctionalClass.TubeSequence_Details(oWCDetails.WorkCenter))
            End If
            'Till   Here
        Catch ex As Exception
        End Try
        oMethdR.Seq = Format(intSequence, "000").ToString

        SetValues(oMethdR, oWCDetails)

        Return oMethdR.ToString()
    End Function

    Public Overrides ReadOnly Property FileName() As String
        Get
            Return "METHDR" & _partNumber
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return "METHDR Tube Process"
    End Function
End Class
