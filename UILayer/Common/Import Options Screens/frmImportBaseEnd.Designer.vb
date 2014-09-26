<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportBaseEnd
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
        Me.txtTubeEndToRodStopDistance = New IFLCustomUILayer.IFLTextBox
        Me.btnAccept = New System.Windows.Forms.Button
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.txtPinHoleToRodStopDistance = New IFLCustomUILayer.IFLTextBox
        Me.lblPinHoleToRodStopDistance = New System.Windows.Forms.Label
        Me.lblTubeEndToRodStopDistance = New System.Windows.Forms.Label
        Me.lblBaseEndDetails = New LabelGradient.LabelGradient
        Me.lblGradientContractDetails = New LabelGradient.LabelGradient
        Me.ofdImportBaseEnd = New System.Windows.Forms.OpenFileDialog
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
        Me.LabelGradient5.Size = New System.Drawing.Size(904, 11)
        Me.LabelGradient5.TabIndex = 127
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
        Me.LabelGradient4.Location = New System.Drawing.Point(914, 0)
        Me.LabelGradient4.Name = "LabelGradient4"
        Me.LabelGradient4.Size = New System.Drawing.Size(10, 541)
        Me.LabelGradient4.TabIndex = 126
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
        Me.LabelGradient3.Size = New System.Drawing.Size(10, 541)
        Me.LabelGradient3.TabIndex = 125
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
        Me.LabelGradient2.Location = New System.Drawing.Point(0, 541)
        Me.LabelGradient2.Name = "LabelGradient2"
        Me.LabelGradient2.Size = New System.Drawing.Size(924, 11)
        Me.LabelGradient2.TabIndex = 124
        Me.LabelGradient2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grpContractDetails
        '
        Me.grpContractDetails.BackColor = System.Drawing.Color.Ivory
        Me.grpContractDetails.Controls.Add(Me.txtTubeEndToRodStopDistance)
        Me.grpContractDetails.Controls.Add(Me.btnAccept)
        Me.grpContractDetails.Controls.Add(Me.btnBrowse)
        Me.grpContractDetails.Controls.Add(Me.txtPinHoleToRodStopDistance)
        Me.grpContractDetails.Controls.Add(Me.lblPinHoleToRodStopDistance)
        Me.grpContractDetails.Controls.Add(Me.lblTubeEndToRodStopDistance)
        Me.grpContractDetails.Controls.Add(Me.lblBaseEndDetails)
        Me.grpContractDetails.Location = New System.Drawing.Point(228, 192)
        Me.grpContractDetails.Name = "grpContractDetails"
        Me.grpContractDetails.Size = New System.Drawing.Size(469, 168)
        Me.grpContractDetails.TabIndex = 129
        Me.grpContractDetails.TabStop = False
        '
        'txtTubeEndToRodStopDistance
        '
        Me.txtTubeEndToRodStopDistance.AcceptEnterKeyAsTab = True
        Me.txtTubeEndToRodStopDistance.ApplyIFLColor = True
        Me.txtTubeEndToRodStopDistance.AssociateLabel = Nothing
        Me.txtTubeEndToRodStopDistance.IFLDataTag = Nothing
        Me.txtTubeEndToRodStopDistance.InvalidInputCharacters = ""
        Me.txtTubeEndToRodStopDistance.Location = New System.Drawing.Point(263, 33)
        Me.txtTubeEndToRodStopDistance.MaxLength = 32
        Me.txtTubeEndToRodStopDistance.Name = "txtTubeEndToRodStopDistance"
        Me.txtTubeEndToRodStopDistance.Size = New System.Drawing.Size(186, 20)
        Me.txtTubeEndToRodStopDistance.StatusMessage = ""
        Me.txtTubeEndToRodStopDistance.StatusObject = Nothing
        Me.txtTubeEndToRodStopDistance.TabIndex = 25
        '
        'btnAccept
        '
        Me.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAccept.Location = New System.Drawing.Point(359, 124)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(90, 25)
        Me.btnAccept.TabIndex = 24
        Me.btnAccept.Text = "Accept"
        Me.btnAccept.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnBrowse.Location = New System.Drawing.Point(263, 124)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(90, 25)
        Me.btnBrowse.TabIndex = 23
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtPinHoleToRodStopDistance
        '
        Me.txtPinHoleToRodStopDistance.AcceptEnterKeyAsTab = True
        Me.txtPinHoleToRodStopDistance.ApplyIFLColor = True
        Me.txtPinHoleToRodStopDistance.AssociateLabel = Nothing
        Me.txtPinHoleToRodStopDistance.IFLDataTag = Nothing
        Me.txtPinHoleToRodStopDistance.InvalidInputCharacters = ""
        Me.txtPinHoleToRodStopDistance.Location = New System.Drawing.Point(263, 71)
        Me.txtPinHoleToRodStopDistance.MaxLength = 32
        Me.txtPinHoleToRodStopDistance.Name = "txtPinHoleToRodStopDistance"
        Me.txtPinHoleToRodStopDistance.Size = New System.Drawing.Size(186, 20)
        Me.txtPinHoleToRodStopDistance.StatusMessage = ""
        Me.txtPinHoleToRodStopDistance.StatusObject = Nothing
        Me.txtPinHoleToRodStopDistance.TabIndex = 3
        '
        'lblPinHoleToRodStopDistance
        '
        Me.lblPinHoleToRodStopDistance.AutoSize = True
        Me.lblPinHoleToRodStopDistance.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!)
        Me.lblPinHoleToRodStopDistance.Location = New System.Drawing.Point(56, 73)
        Me.lblPinHoleToRodStopDistance.Name = "lblPinHoleToRodStopDistance"
        Me.lblPinHoleToRodStopDistance.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblPinHoleToRodStopDistance.Size = New System.Drawing.Size(164, 15)
        Me.lblPinHoleToRodStopDistance.TabIndex = 4
        Me.lblPinHoleToRodStopDistance.Text = "Pin Hole to Rod Stop Distance"
        '
        'lblTubeEndToRodStopDistance
        '
        Me.lblTubeEndToRodStopDistance.AutoSize = True
        Me.lblTubeEndToRodStopDistance.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTubeEndToRodStopDistance.Location = New System.Drawing.Point(53, 35)
        Me.lblTubeEndToRodStopDistance.Name = "lblTubeEndToRodStopDistance"
        Me.lblTubeEndToRodStopDistance.Size = New System.Drawing.Size(171, 15)
        Me.lblTubeEndToRodStopDistance.TabIndex = 0
        Me.lblTubeEndToRodStopDistance.Text = "Tube End to Rod Stop Distance"
        '
        'lblBaseEndDetails
        '
        Me.lblBaseEndDetails.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblBaseEndDetails.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblBaseEndDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBaseEndDetails.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblBaseEndDetails.GradientColorOne = System.Drawing.Color.Olive
        Me.lblBaseEndDetails.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblBaseEndDetails.Location = New System.Drawing.Point(-3, 0)
        Me.lblBaseEndDetails.Name = "lblBaseEndDetails"
        Me.lblBaseEndDetails.Size = New System.Drawing.Size(472, 21)
        Me.lblBaseEndDetails.TabIndex = 20
        Me.lblBaseEndDetails.Text = "Base End Details"
        Me.lblBaseEndDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGradientContractDetails
        '
        Me.lblGradientContractDetails.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblGradientContractDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGradientContractDetails.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGradientContractDetails.GradientColorOne = System.Drawing.Color.DarkGoldenrod
        Me.lblGradientContractDetails.GradientColorTwo = System.Drawing.Color.DarkGoldenrod
        Me.lblGradientContractDetails.Location = New System.Drawing.Point(212, 176)
        Me.lblGradientContractDetails.Name = "lblGradientContractDetails"
        Me.lblGradientContractDetails.Size = New System.Drawing.Size(501, 201)
        Me.lblGradientContractDetails.TabIndex = 128
        Me.lblGradientContractDetails.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ofdImportBaseEnd
        '
        Me.ofdImportBaseEnd.FileName = "OpenFileDialog1"
        '
        'frmImportBaseEnd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(924, 552)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpContractDetails)
        Me.Controls.Add(Me.lblGradientContractDetails)
        Me.Controls.Add(Me.LabelGradient5)
        Me.Controls.Add(Me.LabelGradient4)
        Me.Controls.Add(Me.LabelGradient3)
        Me.Controls.Add(Me.LabelGradient2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmImportBaseEnd"
        Me.Text = "frmImportBaseEnd"
        Me.grpContractDetails.ResumeLayout(False)
        Me.grpContractDetails.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelGradient5 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient4 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient3 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient2 As LabelGradient.LabelGradient
    Friend WithEvents grpContractDetails As System.Windows.Forms.GroupBox
    Friend WithEvents txtTubeEndToRodStopDistance As IFLCustomUILayer.IFLTextBox
    Friend WithEvents btnAccept As System.Windows.Forms.Button
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtPinHoleToRodStopDistance As IFLCustomUILayer.IFLTextBox
    Friend WithEvents lblPinHoleToRodStopDistance As System.Windows.Forms.Label
    Friend WithEvents lblTubeEndToRodStopDistance As System.Windows.Forms.Label
    Friend WithEvents lblBaseEndDetails As LabelGradient.LabelGradient
    Friend WithEvents lblGradientContractDetails As LabelGradient.LabelGradient
    Friend WithEvents ofdImportBaseEnd As System.Windows.Forms.OpenFileDialog
End Class
