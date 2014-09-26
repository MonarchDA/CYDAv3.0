Imports System.Threading
Public NotInheritable Class frmDisplayScreen

    'Sandeep 18-02-10
    Private _intTickCount As Integer

    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblProjectTitle.Text = "CYDA v2.0"
        timerStartUpScreen.Enabled = True
        timerStartUpScreen.Start()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub timerStartUpScreen_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerStartUpScreen.Tick
        _intTickCount = _intTickCount + 1
        If _intTickCount = 15 Then
            Dim oFrmMDIForm As New mdiWeldedCylinder
            oFrmMDIForm.Show()
            timerStartUpScreen.Enabled = False
            Me.Hide()
        End If
    End Sub
    'Sandeep 18-02-10

End Class
