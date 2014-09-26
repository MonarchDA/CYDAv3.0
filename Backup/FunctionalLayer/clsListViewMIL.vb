Public Class clsListViewMIL
    Inherits Windows.Forms.ListView

    Private _WM_KILLFOCUS = &H8

    Public Sub New()
        Me.View = Windows.Forms.View.Details
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg <> _WM_KILLFOCUS Then
            MyBase.WndProc(m)
        End If
    End Sub
       
End Class
