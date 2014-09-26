
Public Class CMS_METHDR

    Private Shared ReadOnly _methodType As String
    Private Shared ReadOnly _alternateMethodNumber As String
    Private Shared ReadOnly _plantCode As String
    Private Shared ReadOnly _processNumbers As String
    Private Shared ReadOnly _runType As String
    Private Shared ReadOnly _cycleTimeSecPerPart As String
    Private Shared ReadOnly _transferBatch As String
    Private Shared ReadOnly _multipleParts As String
    Private Shared ReadOnly _reportingPoint As String
    Private Shared ReadOnly _operationEfficiency As String
    Private Shared ReadOnly _schedPriorityGroup As String
    Private Shared ReadOnly _burdenDriverRateFactor As String
    Private Shared ReadOnly _MRPCreateRepetitiveJobsByTransfrBatchQty As String
    Private Shared ReadOnly _standardCostRollpByTransferBatch As String
    Private Shared ReadOnly _concurrentResources As String
    Private Shared ReadOnly _lineNumbers As String
    Private Shared ReadOnly _standardUnits As String
    Private Shared ReadOnly _efficiencyFactorBeforeSeq As String
    Private Shared ReadOnly _efficiencyFactorAfterSeq As String

    Private _partNumber As String
    Private _seq As String
    Private _department As String
    Private _resource As String
    Private _operation As String
    Private _setupStandard As String
    Private _setupCrewSize As String
    Private _numberOfMen As String
    Private _numberOfMachines As String
    Private _scheduleRunStandard As String
    Private _costingRunStandard As String
    Private _lagTime As String

    'Future Use
    Private _futureUse3 As String = String.Empty
    Private _futureUse4 As String = String.Empty
    Private _futureUse5 As String = String.Empty
    Private _futureUse6 As String = String.Empty
    Private _futureUse7 As String = String.Empty
    Private _futureUse8 As String = String.Empty
    Private _futureUse9 As String = String.Empty
    Private _futureUseA As String = String.Empty
    Private _futureUseB As String = String.Empty
    Private _futureUseC As String = String.Empty
    Private _futureUseD As String = String.Empty
    Private _futureUseE As String = String.Empty
    Private _futureUseF As String = String.Empty


    Shared Sub New()
        'Defaultly fixed values
        _methodType = 1
        _alternateMethodNumber = 0
        _plantCode = "C01"
        _processNumbers = String.Empty
        _runType = "A"
        _cycleTimeSecPerPart = 0
        _transferBatch = 1
        _multipleParts = 0
        _reportingPoint = "Y"
        _operationEfficiency = 100
        _schedPriorityGroup = String.Empty
        _burdenDriverRateFactor = 0
        _MRPCreateRepetitiveJobsByTransfrBatchQty = 2
        _standardCostRollpByTransferBatch = 2
        _concurrentResources = String.Empty
        _lineNumbers = String.Empty
        _standardUnits = String.Empty
        _efficiencyFactorAfterSeq = String.Empty
        _efficiencyFactorBeforeSeq = String.Empty
    End Sub


    Public Sub New(ByVal oType As SubTypes)
        'In Future change values
        _setupCrewSize = 1
        _numberOfMen = 1
        _numberOfMachines = 1

        'Others
        If oType = SubTypes.Others Then
            _lagTime = 0
        Else
            _lagTime = 24
        End If
    End Sub

    Public WriteOnly Property PartNumber() As String
        Set(ByVal value As String)
            _partNumber = value
        End Set
    End Property

    Public WriteOnly Property Seq() As String
        Set(ByVal value As String)
            _seq = value
        End Set
    End Property

    ''' <summary>
    ''' set the department value with 'C01' defaultly
    ''' </summary>
    ''' <value>department name only</value>
    ''' <remarks></remarks>
    Public WriteOnly Property Department() As String
        Set(ByVal value As String)
            _department = "C01" & value
        End Set
    End Property

    Public WriteOnly Property Resource() As String
        Set(ByVal value As String)
            _resource = value
        End Set
    End Property

    Public WriteOnly Property Operation() As String
        Set(ByVal value As String)
            _operation = value
        End Set
    End Property

    Public WriteOnly Property SetupStandard() As String
        Set(ByVal value As String)
            _setupStandard = value
        End Set
    End Property

    Public WriteOnly Property SetupCrewSize() As String
        Set(ByVal value As String)
            _setupCrewSize = value
        End Set
    End Property

    Public WriteOnly Property NumberOfMen() As String
        Set(ByVal value As String)
            _numberOfMen = value
        End Set
    End Property

    Public WriteOnly Property NumberOfMachines() As String
        Set(ByVal value As String)
            _numberOfMachines = value
        End Set
    End Property

    Public WriteOnly Property ScheduleRunStandard() As String
        Set(ByVal value As String)
            _scheduleRunStandard = value
            _costingRunStandard = value
        End Set
    End Property

    'Public WriteOnly Property CostingRunStandard() As String
    '    Set(ByVal value As String)
    '        _costingRunStandard = value
    '    End Set
    'End Property

    Public WriteOnly Property LagTime() As String
        Set(ByVal value As String)
            _lagTime = value
        End Set
    End Property

    Public WriteOnly Property FutureUse4() As String
        Set(ByVal value As String)
            _futureUse4 = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Dim strFormat As String
        strFormat = "{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22}," & _
                    "{23},{24},{25},{26},{27},{28},{29},{30},{31},{32},{33},{34},{35},{36},{37},{38},{39},{40},{41},{42},{43}"
        'strFormat = GetTestString()

        Return String.Format(strFormat, _methodType, _alternateMethodNumber, _plantCode, _partNumber, _
                _seq, _processNumbers, _department, _resource, _operation, _setupStandard, _setupCrewSize, _
                 _numberOfMen, _numberOfMachines, GetDecimalString(_scheduleRunStandard), GetDecimalString(_costingRunStandard), _
                _runType, _lagTime, _cycleTimeSecPerPart, _transferBatch, _multipleParts, _reportingPoint, _
                _operationEfficiency, _schedPriorityGroup, _burdenDriverRateFactor, _MRPCreateRepetitiveJobsByTransfrBatchQty, _
                _standardCostRollpByTransferBatch, _concurrentResources, _lineNumbers, _
                _standardUnits, _efficiencyFactorBeforeSeq, _efficiencyFactorAfterSeq, _
                _futureUse3, _futureUse4, _futureUse5, _futureUse6, _futureUse7, _futureUse8, _futureUse9, _futureUseA, _
                _futureUseB, _futureUseC, _futureUseD, _futureUseE, _futureUseF)

    End Function

    Private Function GetDecimalString(ByVal strValue As String) As String
        Dim dblValue As Double = Val(strValue)
        dblValue = Math.Round(dblValue, 2)

        Return Format(dblValue, "00.00")
    End Function

    Private Function GetTestString() As String
        Dim strFormat As New System.Text.StringBuilder

        For intCount As Integer = 0 To 43
            strFormat.Append("{")
            strFormat.Append(intCount)
            strFormat.Append("},")
        Next
        Return strFormat.ToString
    End Function

    ''' <summary>
    ''' Sub Types of Main Types for _lagTime variable.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum SubTypes
        Assembly
        OilTesting
        Others
    End Enum
End Class
