Public Class MTHL_LugProcess
    Inherits CMS_Process

    Public Sub New()
        MyBase.New(String.Empty)
    End Sub

    Public Overrides Function Start() As String
        Dim strData As New System.Text.StringBuilder
        Dim intSequence As Integer = 10

        strData.AppendLine(DoEachRowProcess(intSequence))

        'Still it is not implemented
        'Return strData.ToString
        Return String.Empty
    End Function

    Private Function DoEachRowProcess(ByVal intSequence As Integer)
        Dim oMthl As New CMS_MTHL()

        oMthl.PartNumbers = _partNumber


        Return oMthl.ToString()
    End Function

    Public Overrides ReadOnly Property FileName() As String
        Get
            Return "MTHL" & _partNumber
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return "MTHL Lug Process"
    End Function

End Class
