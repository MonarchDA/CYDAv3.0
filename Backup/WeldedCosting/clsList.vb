Public Class clsList
    Implements IComparable

    Public strPartCode As String
    Public strDescription As String
    Public dblCost As Double
    Public dblQuantity As Double
    Public strUnit As String

    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
        If Not TypeOf obj Is clsList Then
            Throw New Exception("Object is not MyObject")
        End If
        Dim Compare As clsList = CType(obj, clsList)
        Dim result As Integer = Me.strPartCode.CompareTo(Compare.strPartCode)

        If result = 0 Then
            result = Me.strPartCode.CompareTo(Compare.strPartCode)
        End If
        Return result

    End Function
End Class
