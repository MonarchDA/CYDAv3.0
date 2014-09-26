Imports System.Threading
Public NotInheritable Class frmDisplayScreen

    'Sandeep 18-02-10
    Private _intTickCount As Integer

    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblProjectTitle.Text = "CYDA v3.0"
        timerStartUpScreen.Enabled = True
        timerStartUpScreen.Start()
        StartScreenTimer.Enabled = True
        StartScreenTimer.Start()


    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub timerStartUpScreen_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerStartUpScreen.Tick
        _intTickCount = _intTickCount + 1

        If _intTickCount = 15 Then
            Dim oFrmMDIForm As New mdiWeldedCylinder
            oFrmMDIForm.Show()
            oFrmMDIForm.ManualLoad2()
            StartScreenTimer.Enabled = False
            timerStartUpScreen.Enabled = False
            Me.Hide()
        End If
    End Sub


    'Sandeep 18-02-10

    'Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
    '    Dim progress As New ProgressBar
    '    progress = ProgressBar1
    '    Dim watch As New Stopwatch
    '    Dim i As Integer
    '    watch.Start()
    '    Do
    '        i = i + 1

    '        ProgressBar1.PerformStep()

    '    Loop Until watch.ElapsedMilliseconds = 5000

    '    If watch.ElapsedMilliseconds = 5000 Then
    '        watch.Stop()
    '        Exit Sub
    '    End If
    'End Sub


    Private Sub StartScreenTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartScreenTimer.Tick
        StartScreenPb.PerformStep()
    End Sub

 
End Class
