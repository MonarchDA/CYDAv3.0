<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportPlateClevis
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LabelGradient5 = New LabelGradient.LabelGradient
        Me.LabelGradient4 = New LabelGradient.LabelGradient
        Me.LabelGradient3 = New LabelGradient.LabelGradient
        Me.LabelGradient2 = New LabelGradient.LabelGradient
        Me.grpContractDetails = New System.Windows.Forms.GroupBox
        Me.txtPlateClevisThicknessFromTubeEnd = New IFLCustomUILayer.IFLTextBox
        Me.btnAccept = New System.Windows.Forms.Button
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.txtClevisPlateOD = New IFLCustomUILayer.IFLTextBox
        Me.lblClevisPlateOD = New System.Windows.Forms.Label
        Me.txtRodStopDistanceFromTubeEnd = New IFLCustomUILayer.IFLTextBox
        Me.lblRodStopDistanceFromTubeEnd = New System.Windows.Forms.Label
        Me.lblPlateClevisThicknessFromTubeEnd = New System.Windows.Forms.Label
        Me.lblPlateClevisDetails = New LabelGradient.LabelGradient
        Me.lblGradientContractDetails = New LabelGradient.LabelGradient
        Me.ofdPlateClevisDetails = New System.Windows.Forms.OpenFileDialog
        Me.grpContractDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelGradient5
        '
        Me.LabelGradient5.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient5.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelGradient5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient5.GradientColorOne = System.Drawing.Color.Olive
        Me.LabelGradient5.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient5.Location = New System.Drawing.Point(10, 0)
        Me.LabelGradient5.Name = "LabelGradient5"
        Me.LabelGradient5.Size = New System.Drawing.Size(887, 11)
        Me.LabelGradient5.TabIndex = 123
        Me.LabelGradient5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelGradient4
        '
        Me.LabelGradient4.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient4.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelGradient4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient4.GradientColorOne = System.Drawing.Color.Honeydew
        Me.LabelGradient4.GradientColorTwo = System.Drawing.Color.Olive
        Me.LabelGradient4.Location = New System.Drawing.Point(897, 0)
        Me.LabelGradient4.Name = "LabelGradient4"
        Me.LabelGradient4.Size = New System.Drawing.Size(10, 500)
        Me.LabelGradient4.TabIndex = 122
        Me.LabelGradient4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelGradient3
        '
        Me.LabelGradient3.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient3.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelGradient3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient3.GradientColorOne = System.Drawing.Color.Olive
        Me.LabelGradient3.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient3.Location = New System.Drawing.Point(0, 0)
        Me.LabelGradient3.Name = "LabelGradient3"
        Me.LabelGradient3.Size = New System.Drawing.Size(10, 500)
        Me.LabelGradient3.TabIndex = 121
        Me.LabelGradient3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelGradient2
        '
        Me.LabelGradient2.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LabelGradient2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient2.GradientColorOne = System.Drawing.Color.Olive
        Me.LabelGradient2.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient2.Location = New System.Drawing.Point(0, 500)
        Me.LabelGradient2.Name = "LabelGradient2"
        Me.LabelGradient2.Size = New System.Drawing.Size(907, 11)
        Me.LabelGradient2.TabIndex = 120
        Me.LabelGradient2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grpContractDetails
        '
        Me.grpContractDetails.BackColor = System.Drawing.Color.Ivory
        Me.grpContractDetails.Controls.Add(Me.txtPlateClevisThicknessFromTubeEnd)
        Me.grpContractDetails.Controls.Add(Me.btnAccept)
        Me.grpContractDetails.Controls.Add(Me.btnBrowse)
        Me.grpContractDetails.Controls.Add(Me.txtClevisPlateOD)
        Me.grpContractDetails.Controls.Add(Me.lblClevisPlateOD)
        Me.grpContractDetails.Controls.Add(Me.txtRodStopDistanceFromTubeEnd)
        Me.grpContractDetails.Controls.Add(Me.lblRodStopDistanceFromTubeEnd)
        Me.grpContractDetails.Controls.Add(Me.lblPlateClevisThicknessFromTubeEnd)
        Me.grpContractDetails.Controls.Add(Me.lblPlateClevisDetails)
        Me.grpContractDetails.Location = New System.Drawing.Point(217, 148)
        Me.grpContractDetails.Name = "grpContractDetails"
        Me.grpContractDetails.Size = New System.Drawing.Size(469, 211)
        Me.grpContractDetails.TabIndex = 125
        Me.grpContractDetails.TabStop = False
        '
        'txtPlateClevisThicknessFromTubeEnd
        '
        Me.txtPlateClevisThicknessFromTubeEnd.AcceptEnterKeyAsTab = True
        Me.txtPlateClevisThicknessFromTubeEnd.ApplyIFLColor = True
        Me.txtPlateClevisThicknessFromTubeEnd.AssociateLabel = Nothing
        Me.txtPlateClevisThicknessFromTubeEnd.IFLDataTag = Nothing
        Me.txtPlateClevisThicknessFromTubeEnd.InvalidInputCharacters = ""
        Me.txtPlateClevisThicknessFromTubeEnd.Location = New System.Drawing.Point(263, 31)
        Me.txtPlateClevisThicknessFromTubeEnd.MaxLength = 32
        Me.txtPlateClevisThicknessFromTubeEnd.Name = "txtPlateClevisThicknessFromTubeEnd"
        Me.txtPlateClevisThicknessFromTubeEnd.Size = New System.Drawing.Size(152, 20)
        Me.txtPlateClevisThicknessFromTubeEnd.StatusMessage = ""
        Me.txtPlateClevisThicknessFromTubeEnd.StatusObject = Nothing
        Me.txtPlateClevisThicknessFromTubeEnd.TabIndex = 25
        '
        'btnAccept
        '
        Me.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAccept.Location = New System.Drawing.Point(247, 158)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(90, 25)
        Me.btnAccept.TabIndex = 24
        Me.btnAccept.Text = "Accept"
        Me.btnAccept.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnBrowse.Location = New System.Drawing.Point(131, 158)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(90, 25)
        Me.btnBrowse.TabIndex = 23
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtClevisPlateOD
        '
        Me.txtClevisPlateOD.AcceptEnterKeyAsTab = True
        Me.txtClevisPlateOD.ApplyIFLColor = True
        Me.txtClevisPlateOD.AssociateLabel = Nothing
        Me.txtClevisPlateOD.IFLDataTag = Nothing
        Me.txtClevisPlateOD.InvalidInputCharacters = ""
        Me.txtClevisPlateOD.Location = New System.Drawing.Point(263, 107)
        Me.txtClevisPlateOD.MaxLength = 32
        Me.txtClevisPlateOD.Name = "txtClevisPlateOD"
        Me.txtClevisPlateOD.Size = New System.Drawing.Size(152, 20)
        Me.txtClevisPlateOD.StatusMessage = ""
        Me.txtClevisPlateOD.StatusObject = Nothing
        Me.txtClevisPlateOD.TabIndex = 21
        '
        'lblClevisPlateOD
        '
        Me.lblClevisPlateOD.AutoSize = True
        Me.lblClevisPlateOD.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!)
        Me.lblClevisPlateOD.Location = New System.Drawing.Point(56, 109)
        Me.lblClevisPlateOD.Name = "lblClevisPlateOD"
        Me.lblClevisPlateOD.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblClevisPlateOD.Size = New System.Drawing.Size(87, 15)
        Me.lblClevisPlateOD.TabIndex = 22
        Me.lblClevisPlateOD.Text = "Clevis Plate OD"
        '
        'txtRodStopDistanceFromTubeEnd
        '
        Me.txtRodStopDistanceFromTubeEnd.AcceptEnterKeyAsTab = True
        Me.txtRodStopDistanceFromTubeEnd.ApplyIFLColor = True
        Me.txtRodStopDistanceFromTubeEnd.AssociateLabel = Nothing
        Me.txtRodStopDistanceFromTubeEnd.IFLDataTag = Nothing
        Me.txtRodStopDistanceFromTubeEnd.InvalidInputCharacters = ""
        Me.txtRodStopDistanceFromTubeEnd.Location = New System.Drawing.Point(263, 69)
        Me.txtRodStopDistanceFromTubeEnd.MaxLength = 32
        Me.txtRodStopDistanceFromTubeEnd.Name = "txtRodStopDistanceFromTubeEnd"
        Me.txtRodStopDistanceFromTubeEnd.Size = New System.Drawing.Size(152, 20)
        Me.txtRodStopDistanceFromTubeEnd.StatusMessage = ""
        Me.txtRodStopDistanceFromTubeEnd.StatusObject = Nothing
        Me.txtRodStopDistanceFromTubeEnd.TabIndex = 3
        '
        'lblRodStopDistanceFromTubeEnd
        '
        Me.lblRodStopDistanceFromTubeEnd.AutoSize = True
        Me.lblRodStopDistanceFromTubeEnd.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!)
        Me.lblRodStopDistanceFromTubeEnd.Location = New System.Drawing.Point(56, 71)
        Me.lblRodStopDistanceFromTubeEnd.Name = "lblRodStopDistanceFromTubeEnd"
        Me.lblRodStopDistanceFromTubeEnd.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblRodStopDistanceFromTubeEnd.Size = New System.Drawing.Size(184, 15)
        Me.lblRodStopDistanceFromTubeEnd.TabIndex = 4
        Me.lblRodStopDistanceFromTubeEnd.Text = "Rod Stop Distance from TubeEnd"
        '
        'lblPlateClevisThicknessFromTubeEnd
        '
        Me.lblPlateClevisThicknessFromTubeEnd.AutoSize = True
        Me.lblPlateClevisThicknessFromTubeEnd.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlateClevisThicknessFromTubeEnd.Location = New System.Drawing.Point(53, 33)
        Me.lblPlateClevisThicknessFromTubeEnd.Name = "lblPlateClevisThicknessFromTubeEnd"
        Me.lblPlateClevisThicknessFromTubeEnd.Size = New System.Drawing.Size(204, 15)
        Me.lblPlateClevisThicknessFromTubeEnd.TabIndex = 0
        Me.lblPlateClevisThicknessFromTubeEnd.Text = "Plate Clevis Thickness from TubeEnd"
        '
        'lblPlateClevisDetails
        '
        Me.lblPlateClevisDetails.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblPlateClevisDetails.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblPlateClevisDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlateClevisDetails.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblPlateClevisDetails.GradientColorOne = System.Drawing.Color.Olive
        Me.lblPlateClevisDetails.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblPlateClevisDetails.Location = New System.Drawing.Point(-3, 0)
        Me.lblPlateClevisDetails.Name = "lblPlateClevisDetails"
        Me.lblPlateClevisDetails.Size = New System.Drawing.Size(472, 21)
        Me.lblPlateClevisDetails.TabIndex = 20
        Me.lblPlateClevisDetails.Text = "Plate Clevis Details"
        Me.lblPlateClevisDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGradientContractDetails
        '
        Me.lblGradientContractDetails.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblGradientContractDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGradientContractDetails.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGradientContractDetails.GradientColorOne = System.Drawing.Color.DarkGoldenrod
        Me.lblGradientContractDetails.GradientColorTwo = System.Drawing.Color.DarkGoldenrod
        Me.lblGradientContractDetails.Location = New System.Drawing.Point(214, 137)
        Me.lblGradientContractDetails.Name = "lblGradientContractDetails"
        Me.lblGradientContractDetails.Size = New System.Drawing.Size(478, 236)
        Me.lblGradientContractDetails.TabIndex = 124
        Me.lblGradientContractDetails.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ofdPlateClevisDetails
        '
        Me.ofdPlateClevisDetails.FileName = "OpenFileDialog1"
        '
        'frmImportPlateClevis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(907, 511)
        Me.Controls.Add(Me.grpContractDetails)
        Me.Controls.Add(Me.lblGradientContractDetails)
        Me.Controls.Add(Me.LabelGradient5)
        Me.Controls.Add(Me.LabelGradient4)
        Me.Controls.Add(Me.LabelGradient3)
        Me.Controls.Add(Me.LabelGradient2)
        Me.Name = "frmImportPlateClevis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.grpContractDetails.ResumeLayout(False)
        Me.grpContractDetails.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelGradient5 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient4 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient3 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient2 As LabelGradient.LabelGradient
    Friend WithEvents grpContractDetails As System.Windows.Forms.GroupBox
    Friend WithEvents btnAccept As System.Windows.Forms.Button
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtClevisPlateOD As IFLCustomUILayer.IFLTextBox
    Friend WithEvents lblClevisPlateOD As System.Windows.Forms.Label
    Friend WithEvents txtRodStopDistanceFromTubeEnd As IFLCustomUILayer.IFLTextBox
    Friend WithEvents lblRodStopDistanceFromTubeEnd As System.Windows.Forms.Label
    Friend WithEvents lblPlateClevisThicknessFromTubeEnd As System.Windows.Forms.Label
    Friend WithEvents lblPlateClevisDetails As LabelGradient.LabelGradient
    Friend WithEvents lblGradientContractDetails As LabelGradient.LabelGradient
    Friend WithEvents txtPlateClevisThicknessFromTubeEnd As IFLCustomUILayer.IFLTextBox
    Friend WithEvents ofdPlateClevisDetails As System.Windows.Forms.OpenFileDialog
End Class
