Public Class CMS_MTHL

    Private Shared ReadOnly _methodType As String
    Private Shared ReadOnly _alternateMethodNumber As String
    Private Shared ReadOnly _plantCode As String
    Private Shared ReadOnly _requiredSetup As YesNo
    Private Shared ReadOnly _requiredRun As YesNo
    Private Shared ReadOnly _quantity As String
    Private Shared ReadOnly _units As String

    Private _partNumbers As String
    Private _sequence As String
    Private _lineNumbers As String
    Private _toolNumbers As String
    Private _createdBy As String = String.Empty
    Private _creationDate As String = String.Empty
    Private _updatedBy As String = String.Empty
    Private _updateDate As String = String.Empty
    Private _department As String = String.Empty
    Private _resource As String = String.Empty
    Private _futureUse1 As String = String.Empty
    Private _futureUse2 As String = String.Empty
    Private _futureUse3 As String = String.Empty
    Private _futureUse4 As String = String.Empty
    Private _futureUse5 As String = String.Empty

    Shared Sub New()
        'Defaultly fixed values
        _methodType = 1
        _alternateMethodNumber = 0
        _plantCode = "C01"
        _requiredSetup = YesNo.Yes '"Y"
        _requiredRun = YesNo.Yes '"Y"
        _quantity = 1
        _units = "EA"
    End Sub

    Public WriteOnly Property PartNumbers() As String
        Set(ByVal value As String)
            _partNumbers = value
        End Set
    End Property

    Public WriteOnly Property Sequence() As String
        Set(ByVal value As String)
            _sequence = value
        End Set
    End Property

    Public WriteOnly Property LineNumbers() As String
        Set(ByVal value As String)
            _lineNumbers = value
        End Set
    End Property

    Public WriteOnly Property ToolNumbers() As String
        Set(ByVal value As String)
            _toolNumbers = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Dim strFormat As String
        strFormat = "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21}"

        Return String.Format(strFormat, _methodType, _alternateMethodNumber, _plantCode, _partNumbers, _sequence, _lineNumbers, _
                _toolNumbers, GetYesNo(_requiredSetup), GetYesNo(_requiredRun), _quantity, _units, _createdBy, _creationDate, _updatedBy, _
                _updateDate, _department, _Resource, _futureUse1, _futureUse2, _futureUse3, _futureUse4, _futureUse5)

    End Function

    Private Function GetYesNo(ByVal yesno As YesNo) As String

        If yesno = CMS_MTHL.YesNo.Yes Then
            Return "Y"
        ElseIf yesno = CMS_MTHL.YesNo.No Then
            Return "N"
        Else
            Return "Not Define"
        End If
    End Function

    Public Enum YesNo
        Yes
        No
    End Enum
End Class
