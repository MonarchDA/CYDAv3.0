Public Class frmREThreadedRod

    'TODO: ANUP 22-07-2010 12.14pm
    Private _blnIsPopulated As Boolean = False

    Public Property IsPopulated() As Boolean
        Get
            Return _blnIsPopulated
        End Get
        Set(ByVal value As Boolean)
            _blnIsPopulated = value
        End Set
    End Property

#Region "Sub Procedures"
    Public Sub ManualLoad()
        LoadThreadSize()

        'TODO: ANUP 31-05-2010 09.40am
        ImageLoad()
        '********
    End Sub

    Private Sub LoadThreadSize()
        Try
            cmbThreadSize_RodEnd.DataSource = Nothing
            Dim oThreadSizeDataTable As DataTable = ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedDataClass.GetThreadSizeValues(ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.SelectedClass, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter, ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.PullForce)
            If Not IsNothing(oThreadSizeDataTable) Then
                cmbThreadSize_RodEnd.DataSource = oThreadSizeDataTable
                cmbThreadSize_RodEnd.ValueMember = "ThreadValue"
                cmbThreadSize_RodEnd.DisplayMember = "ThreadDiscription"
                cmbThreadSize_RodEnd.SelectedIndex = 0
            End If

            'For Each oThreadSizeDataRow As DataRow In oThreadSizeDataTable.Rows
            '    If Not IsNothing(oThreadSizeDataRow("ThreadDiscription")) Then
            '        cmbThreadSize_RodEnd.Items.Add(oThreadSizeDataRow("ThreadDiscription"))
            '    End If
            'Next

        Catch ex As Exception

        End Try
    End Sub

    'TODO: ANUP 31-05-2010 09.40am
    Private Sub ImageLoad()
        ObjClsWeldedCylinderFunctionalClass.MdiPictureBox.ImageLocation = ObjClsWeldedCylinderFunctionalClass.CurrentWorkingDirectory + "\Images\THREAD IMAGE.jpg"
    End Sub
    '**********
#End Region

#Region "Events"

    Private Sub frmREThreadedRod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ColorTheForm()
        pnlMilledFlat_RETR.Visible = False
        rdbMilledFlatNo_RETR.Checked = True
        ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlat_RE = "No"
        cmbThreadType_RodEnd.Items.Clear()
        cmbThreadType_RodEnd.Items.Add("Internal")
        cmbThreadType_RodEnd.Items.Add("External")
        cmbThreadType_RodEnd.SelectedIndex = 1
        LoadThreadSize()

        'TODO: ANUP 31-05-2010 09.40am
        ImageLoad()
        '************
    End Sub

    Private Sub rdbMilledFlatYes_RETR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbMilledFlatYes_RETR.CheckedChanged
        If rdbMilledFlatYes_RETR.Checked Then
            pnlMilledFlat_RETR.Visible = True
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlat_RE = "Yes"
        Else
            txtAcrossFlatValue_RodEnd.Text = ""
            txtFlatLength_RodEnd.Text = ""
            pnlMilledFlat_RETR.Visible = False
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.MilledFlat_RE = "No"
        End If
    End Sub

    Private Sub cmbThreadType_RodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbThreadType_RodEnd.SelectedIndexChanged
        If cmbThreadType_RodEnd.Text <> "" Then
            If cmbThreadType_RodEnd.Text <> cmbThreadType_RodEnd.IFLDataTag Then
                cmbThreadType_RodEnd.IFLDataTag = cmbThreadType_RodEnd.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadType_RodEnd = cmbThreadType_RodEnd.Text
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadType_RodEnd = 0
            cmbThreadType_RodEnd.IFLDataTag = ""
        End If
    End Sub


    Private Sub cmbThreadSize_RodEnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbThreadSize_RodEnd.SelectedIndexChanged
        Try
            If cmbThreadSize_RodEnd.Text <> "" Then
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadSize_RodEnd = Val(cmbThreadSize_RodEnd.SelectedValue.ToString)
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadSize_RodEnd = 0
            End If
        Catch ex As Exception

        End Try
   
    End Sub
    Private Sub txtThreadLength_RodEnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtThreadLength_RodEnd.Leave
        If txtThreadLength_RodEnd.Text <> "" Then
            If txtThreadLength_RodEnd.Text <> txtThreadLength_RodEnd.IFLDataTag Then
                txtThreadLength_RodEnd.IFLDataTag = txtThreadLength_RodEnd.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength_RodEnd = txtThreadLength_RodEnd.Text
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.ThreadLength_RodEnd = 0
            txtThreadLength_RodEnd.IFLDataTag = ""
        End If
    End Sub

    Private Sub txtAcrossFlatValue_RodEnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcrossFlatValue_RodEnd.Leave
        If txtAcrossFlatValue_RodEnd.Text <> "" Then
            If txtAcrossFlatValue_RodEnd.Text <> txtAcrossFlatValue_RodEnd.IFLDataTag Then
                If Val(txtAcrossFlatValue_RodEnd.Text) < ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter Then
                    txtAcrossFlatValue_RodEnd.IFLDataTag = txtAcrossFlatValue_RodEnd.Text
                    ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AcrossFlatValue_RodEnd = txtAcrossFlatValue_RodEnd.Text
                Else
                    Dim strMessage As String = " Please enter the value less than Rod diameter ( " + ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.RodDiameter.ToString + " )."
                    MessageBox.Show(strMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtAcrossFlatValue_RodEnd.SelectAll()
                    txtAcrossFlatValue_RodEnd.Focus()
                End If
            End If
            Else
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.AcrossFlatValue_RodEnd = 0
                txtAcrossFlatValue_RodEnd.IFLDataTag = ""
            End If
    End Sub

    Private Sub txtFlatLength_RodEnd_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFlatLength_RodEnd.Leave
        If txtFlatLength_RodEnd.Text <> "" Then
            If txtFlatLength_RodEnd.Text <> txtFlatLength_RodEnd.IFLDataTag Then
                txtFlatLength_RodEnd.IFLDataTag = txtFlatLength_RodEnd.Text
                ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FlatLength_RodEnd = txtFlatLength_RodEnd.Text
            End If
        Else
            ObjClsWeldedCylinderFunctionalClass.ObjClsWeldedGlobalVariables.FlatLength_RodEnd = 0
            txtFlatLength_RodEnd.IFLDataTag = ""
        End If
    End Sub

    'TODO: ANUP 31-05-2010 09.40am
    Private Sub pnlREThreadedRod_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlREThreadedRod.MouseHover, txtThreadLength_RodEnd.MouseHover
        ImageLoad()
    End Sub
    '****************
#End Region

    Private Sub ColorTheForm()
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_GreenBorder_ColoringTheScreens(LabelGradient3, lblSLHeading, LabelGradient4, LabelGradient2)
        ObjClsWeldedCylinderFunctionalClass.LabelGradient_OrangeBorder_ColoringTheScreens(lblBackGround)
        ObjClsWeldedCylinderFunctionalClass.subLabelGradient_Child_ColoringScreens(lblREThreadedRodInsidePanel)
    End Sub
End Class