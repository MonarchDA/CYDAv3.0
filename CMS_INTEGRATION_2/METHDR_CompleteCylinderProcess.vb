Public Class METHDR_CompleteCylinderProcess
    Inherits CMS_Process

    Public Overrides ReadOnly Property FileName() As String
        Get
            Return "METHDR" & _partNumber
        End Get
    End Property

    Public Sub New()
        MyBase.New(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber)
        'ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.CodeNumber
    End Sub


    Public Overrides Function Start() As String
        Dim strData As New System.Text.StringBuilder

        Dim ht As Hashtable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.WeldedCompleteCylinderWCDetails

        If Not ht.Count = 3 Then
            Return ""
        End If


        Try

            strData.AppendLine(AssemblyPart(ht.Item("WC619")))

            strData.AppendLine(OilTestingPart(ht.Item("WC626")))      '20_09_2010   RAGAVA changed from 625 to 626

            strData.AppendLine(PaintingPart(ht.Item("WC631")))


        Catch ex As Exception

        End Try
        Return strData.ToString
    End Function

    Private Function AssemblyPart(ByVal oWCDetails As WCStructure) As String
        Dim oMethdR As New CMS_METHDR(CMS_METHDR.SubTypes.Assembly)

        oMethdR.PartNumber = _partNumber
        oMethdR.Seq = 10

        SetValues(oMethdR, oWCDetails)

        Return oMethdR.ToString()
    End Function


    Private Function OilTestingPart(ByVal oWCDetails As WCStructure) As String
        Dim oMethdR As New CMS_METHDR(CMS_METHDR.SubTypes.OilTesting)

        oMethdR.PartNumber = _partNumber
        oMethdR.Seq = 20

        SetValues(oMethdR, oWCDetails)

        Return oMethdR.ToString()
    End Function

    Private Function PaintingPart(ByVal oWCDetails As WCStructure) As String
        Dim oMethdR As New CMS_METHDR(CMS_METHDR.SubTypes.Others)

        oMethdR.PartNumber = _partNumber
        oMethdR.Seq = 30

        SetValues(oMethdR, oWCDetails)

        Return oMethdR.ToString()
    End Function

    Public Overrides Function ToString() As String
        Return "METHDR Complete Cylinder Process"
    End Function
End Class
