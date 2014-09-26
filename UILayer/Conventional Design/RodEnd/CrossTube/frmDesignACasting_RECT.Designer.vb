<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDesignACasting_RECT
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
        Me.pnlDesignCasting_RECT = New System.Windows.Forms.Panel
        Me.pnlSafetyFactor_Weight_LugThickness_RECT = New System.Windows.Forms.Panel
        Me.lblSafetyFactorIndex_RECT = New LabelGradient.LabelGradient
        Me.pnlDesignaCasting_RECT = New System.Windows.Forms.Panel
        Me.lblCrossTubeWidth_DesignNewCrossTube = New System.Windows.Forms.Label
        Me.txtCrossTubeWidth_DesignCrossTubeCasting_RECT = New IFLCustomUILayer.IFLNumericBox
        Me.lblCrossTubeOD_DesignCrossTube = New System.Windows.Forms.Label
        Me.txtCrossTubeOD_DesignCrossTubeCasting_RECT = New IFLCustomUILayer.IFLNumericBox
        Me.txtSafetyFactorOfCasting_RECT = New IFLCustomUILayer.IFLNumericBox
        Me.lblSafetyFactor = New System.Windows.Forms.Label
        Me.trbSafetyFactor_RECT = New System.Windows.Forms.TrackBar
        Me.lblDesignNewCasting_RECT = New LabelGradient.LabelGradient
        Me.btnGenerate_RECT = New System.Windows.Forms.Button
        Me.txtSwingClearance_DesignCrossTubeCasting_RECT = New IFLCustomUILayer.IFLNumericBox
        Me.lblSwingClearance2 = New System.Windows.Forms.Label
        Me.txtPinHoleSize_DesignCrossTubeCasting_RECT = New IFLCustomUILayer.IFLNumericBox
        Me.lblPinHoleSize = New System.Windows.Forms.Label
        Me.btnAccept_RECT = New System.Windows.Forms.Button
        Me.lvwSafetyFactor_Weight_RECT = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL
        Me.pnlDesignCasting_RECT.SuspendLayout()
        Me.pnlSafetyFactor_Weight_LugThickness_RECT.SuspendLayout()
        Me.pnlDesignaCasting_RECT.SuspendLayout()
        CType(Me.trbSafetyFactor_RECT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlDesignCasting_RECT
        '
        Me.pnlDesignCasting_RECT.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlDesignCasting_RECT.AutoScroll = True
        Me.pnlDesignCasting_RECT.BackColor = System.Drawing.Color.Ivory
        Me.pnlDesignCasting_RECT.Controls.Add(Me.pnlSafetyFactor_Weight_LugThickness_RECT)
        Me.pnlDesignCasting_RECT.Controls.Add(Me.pnlDesignaCasting_RECT)
        Me.pnlDesignCasting_RECT.Controls.Add(Me.btnAccept_RECT)
        Me.pnlDesignCasting_RECT.Location = New System.Drawing.Point(0, 0)
        Me.pnlDesignCasting_RECT.Name = "pnlDesignCasting_RECT"
        Me.pnlDesignCasting_RECT.Size = New System.Drawing.Size(583, 477)
        Me.pnlDesignCasting_RECT.TabIndex = 8
        '
        'pnlSafetyFactor_Weight_LugThickness_RECT
        '
        Me.pnlSafetyFactor_Weight_LugThickness_RECT.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlSafetyFactor_Weight_LugThickness_RECT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlSafetyFactor_Weight_LugThickness_RECT.Controls.Add(Me.lvwSafetyFactor_Weight_RECT)
        Me.pnlSafetyFactor_Weight_LugThickness_RECT.Controls.Add(Me.lblSafetyFactorIndex_RECT)
        Me.pnlSafetyFactor_Weight_LugThickness_RECT.Location = New System.Drawing.Point(69, 229)
        Me.pnlSafetyFactor_Weight_LugThickness_RECT.Name = "pnlSafetyFactor_Weight_LugThickness_RECT"
        Me.pnlSafetyFactor_Weight_LugThickness_RECT.Size = New System.Drawing.Size(445, 158)
        Me.pnlSafetyFactor_Weight_LugThickness_RECT.TabIndex = 4
        '
        'lblSafetyFactorIndex_RECT
        '
        Me.lblSafetyFactorIndex_RECT.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblSafetyFactorIndex_RECT.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSafetyFactorIndex_RECT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSafetyFactorIndex_RECT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSafetyFactorIndex_RECT.GradientColorOne = System.Drawing.Color.Olive
        Me.lblSafetyFactorIndex_RECT.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblSafetyFactorIndex_RECT.Location = New System.Drawing.Point(0, 0)
        Me.lblSafetyFactorIndex_RECT.Name = "lblSafetyFactorIndex_RECT"
        Me.lblSafetyFactorIndex_RECT.Size = New System.Drawing.Size(441, 19)
        Me.lblSafetyFactorIndex_RECT.TabIndex = 159
        Me.lblSafetyFactorIndex_RECT.Text = "Generated Design Properties"
        Me.lblSafetyFactorIndex_RECT.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlDesignaCasting_RECT
        '
        Me.pnlDesignaCasting_RECT.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pnlDesignaCasting_RECT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDesignaCasting_RECT.Controls.Add(Me.lblCrossTubeWidth_DesignNewCrossTube)
        Me.pnlDesignaCasting_RECT.Controls.Add(Me.txtCrossTubeWidth_DesignCrossTubeCasting_RECT)
        Me.pnlDesignaCasting_RECT.Controls.Add(Me.lblCrossTubeOD_DesignCrossTube)
        Me.pnlDesignaCasting_RECT.Controls.Add(Me.txtCrossTubeOD_DesignCrossTubeCasting_RECT)
        Me.pnlDesignaCasting_RECT.Controls.Add(Me.txtSafetyFactorOfCasting_RECT)
        Me.pnlDesignaCasting_RECT.Controls.Add(Me.lblSafetyFactor)
        Me.pnlDesignaCasting_RECT.Controls.Add(Me.trbSafetyFactor_RECT)
        Me.pnlDesignaCasting_RECT.Controls.Add(Me.lblDesignNewCasting_RECT)
        Me.pnlDesignaCasting_RECT.Controls.Add(Me.btnGenerate_RECT)
        Me.pnlDesignaCasting_RECT.Controls.Add(Me.txtSwingClearance_DesignCrossTubeCasting_RECT)
        Me.pnlDesignaCasting_RECT.Controls.Add(Me.lblSwingClearance2)
        Me.pnlDesignaCasting_RECT.Controls.Add(Me.txtPinHoleSize_DesignCrossTubeCasting_RECT)
        Me.pnlDesignaCasting_RECT.Controls.Add(Me.lblPinHoleSize)
        Me.pnlDesignaCasting_RECT.Location = New System.Drawing.Point(69, 61)
        Me.pnlDesignaCasting_RECT.Name = "pnlDesignaCasting_RECT"
        Me.pnlDesignaCasting_RECT.Size = New System.Drawing.Size(445, 161)
        Me.pnlDesignaCasting_RECT.TabIndex = 3
        '
        'lblCrossTubeWidth_DesignNewCrossTube
        '
        Me.lblCrossTubeWidth_DesignNewCrossTube.AutoSize = True
        Me.lblCrossTubeWidth_DesignNewCrossTube.Location = New System.Drawing.Point(50, 77)
        Me.lblCrossTubeWidth_DesignNewCrossTube.Name = "lblCrossTubeWidth_DesignNewCrossTube"
        Me.lblCrossTubeWidth_DesignNewCrossTube.Size = New System.Drawing.Size(89, 13)
        Me.lblCrossTubeWidth_DesignNewCrossTube.TabIndex = 160
        Me.lblCrossTubeWidth_DesignNewCrossTube.Text = "CrossTube Width"
        '
        'txtCrossTubeWidth_DesignCrossTubeCasting_RECT
        '
        Me.txtCrossTubeWidth_DesignCrossTubeCasting_RECT.AcceptEnterKeyAsTab = True
        Me.txtCrossTubeWidth_DesignCrossTubeCasting_RECT.ApplyIFLColor = True
        Me.txtCrossTubeWidth_DesignCrossTubeCasting_RECT.AssociateLabel = Nothing
        Me.txtCrossTubeWidth_DesignCrossTubeCasting_RECT.DecimalValue = 2
        Me.txtCrossTubeWidth_DesignCrossTubeCasting_RECT.IFLDataTag = Nothing
        Me.txtCrossTubeWidth_DesignCrossTubeCasting_RECT.InvalidInputCharacters = ""
        Me.txtCrossTubeWidth_DesignCrossTubeCasting_RECT.IsAllowNegative = False
        Me.txtCrossTubeWidth_DesignCrossTubeCasting_RECT.LengthValue = 6
        Me.txtCrossTubeWidth_DesignCrossTubeCasting_RECT.Location = New System.Drawing.Point(148, 74)
        Me.txtCrossTubeWidth_DesignCrossTubeCasting_RECT.MaximumValue = 99999
        Me.txtCrossTubeWidth_DesignCrossTubeCasting_RECT.MaxLength = 6
        Me.txtCrossTubeWidth_DesignCrossTubeCasting_RECT.MinimumValue = 0
        Me.txtCrossTubeWidth_DesignCrossTubeCasting_RECT.Name = "txtCrossTubeWidth_DesignCrossTubeCasting_RECT"
        Me.txtCrossTubeWidth_DesignCrossTubeCasting_RECT.Size = New System.Drawing.Size(66, 20)
        Me.txtCrossTubeWidth_DesignCrossTubeCasting_RECT.StatusMessage = ""
        Me.txtCrossTubeWidth_DesignCrossTubeCasting_RECT.StatusObject = Nothing
        Me.txtCrossTubeWidth_DesignCrossTubeCasting_RECT.TabIndex = 159
        Me.txtCrossTubeWidth_DesignCrossTubeCasting_RECT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCrossTubeOD_DesignCrossTube
        '
        Me.lblCrossTubeOD_DesignCrossTube.AutoSize = True
        Me.lblCrossTubeOD_DesignCrossTube.Location = New System.Drawing.Point(50, 104)
        Me.lblCrossTubeOD_DesignCrossTube.Name = "lblCrossTubeOD_DesignCrossTube"
        Me.lblCrossTubeOD_DesignCrossTube.Size = New System.Drawing.Size(77, 13)
        Me.lblCrossTubeOD_DesignCrossTube.TabIndex = 158
        Me.lblCrossTubeOD_DesignCrossTube.Text = "CrossTube OD"
        '
        'txtCrossTubeOD_DesignCrossTubeCasting_RECT
        '
        Me.txtCrossTubeOD_DesignCrossTubeCasting_RECT.AcceptEnterKeyAsTab = True
        Me.txtCrossTubeOD_DesignCrossTubeCasting_RECT.ApplyIFLColor = True
        Me.txtCrossTubeOD_DesignCrossTubeCasting_RECT.AssociateLabel = Nothing
        Me.txtCrossTubeOD_DesignCrossTubeCasting_RECT.DecimalValue = 2
        Me.txtCrossTubeOD_DesignCrossTubeCasting_RECT.IFLDataTag = Nothing
        Me.txtCrossTubeOD_DesignCrossTubeCasting_RECT.InvalidInputCharacters = ""
        Me.txtCrossTubeOD_DesignCrossTubeCasting_RECT.IsAllowNegative = False
        Me.txtCrossTubeOD_DesignCrossTubeCasting_RECT.LengthValue = 6
        Me.txtCrossTubeOD_DesignCrossTubeCasting_RECT.Location = New System.Drawing.Point(148, 101)
        Me.txtCrossTubeOD_DesignCrossTubeCasting_RECT.MaximumValue = 99999
        Me.txtCrossTubeOD_DesignCrossTubeCasting_RECT.MaxLength = 6
        Me.txtCrossTubeOD_DesignCrossTubeCasting_RECT.MinimumValue = 0
        Me.txtCrossTubeOD_DesignCrossTubeCasting_RECT.Name = "txtCrossTubeOD_DesignCrossTubeCasting_RECT"
        Me.txtCrossTubeOD_DesignCrossTubeCasting_RECT.Size = New System.Drawing.Size(66, 20)
        Me.txtCrossTubeOD_DesignCrossTubeCasting_RECT.StatusMessage = ""
        Me.txtCrossTubeOD_DesignCrossTubeCasting_RECT.StatusObject = Nothing
        Me.txtCrossTubeOD_DesignCrossTubeCasting_RECT.TabIndex = 157
        Me.txtCrossTubeOD_DesignCrossTubeCasting_RECT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSafetyFactorOfCasting_RECT
        '
        Me.txtSafetyFactorOfCasting_RECT.AcceptEnterKeyAsTab = True
        Me.txtSafetyFactorOfCasting_RECT.ApplyIFLColor = True
        Me.txtSafetyFactorOfCasting_RECT.AssociateLabel = Nothing
        Me.txtSafetyFactorOfCasting_RECT.DecimalValue = 2
        Me.txtSafetyFactorOfCasting_RECT.IFLDataTag = Nothing
        Me.txtSafetyFactorOfCasting_RECT.InvalidInputCharacters = ""
        Me.txtSafetyFactorOfCasting_RECT.IsAllowNegative = False
        Me.txtSafetyFactorOfCasting_RECT.LengthValue = 6
        Me.txtSafetyFactorOfCasting_RECT.Location = New System.Drawing.Point(374, 33)
        Me.txtSafetyFactorOfCasting_RECT.MaximumValue = 99999
        Me.txtSafetyFactorOfCasting_RECT.MaxLength = 6
        Me.txtSafetyFactorOfCasting_RECT.MinimumValue = 0
        Me.txtSafetyFactorOfCasting_RECT.Name = "txtSafetyFactorOfCasting_RECT"
        Me.txtSafetyFactorOfCasting_RECT.Size = New System.Drawing.Size(40, 20)
        Me.txtSafetyFactorOfCasting_RECT.StatusMessage = ""
        Me.txtSafetyFactorOfCasting_RECT.StatusObject = Nothing
        Me.txtSafetyFactorOfCasting_RECT.TabIndex = 156
        Me.txtSafetyFactorOfCasting_RECT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSafetyFactor
        '
        Me.lblSafetyFactor.AutoSize = True
        Me.lblSafetyFactor.Location = New System.Drawing.Point(26, 33)
        Me.lblSafetyFactor.Name = "lblSafetyFactor"
        Me.lblSafetyFactor.Size = New System.Drawing.Size(70, 13)
        Me.lblSafetyFactor.TabIndex = 153
        Me.lblSafetyFactor.Text = "Safety Factor"
        '
        'trbSafetyFactor_RECT
        '
        Me.trbSafetyFactor_RECT.LargeChange = 1
        Me.trbSafetyFactor_RECT.Location = New System.Drawing.Point(102, 24)
        Me.trbSafetyFactor_RECT.Maximum = 40
        Me.trbSafetyFactor_RECT.Minimum = 2
        Me.trbSafetyFactor_RECT.Name = "trbSafetyFactor_RECT"
        Me.trbSafetyFactor_RECT.Size = New System.Drawing.Size(266, 45)
        Me.trbSafetyFactor_RECT.TabIndex = 152
        Me.trbSafetyFactor_RECT.Value = 2
        '
        'lblDesignNewCasting_RECT
        '
        Me.lblDesignNewCasting_RECT.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblDesignNewCasting_RECT.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDesignNewCasting_RECT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesignNewCasting_RECT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDesignNewCasting_RECT.GradientColorOne = System.Drawing.Color.Olive
        Me.lblDesignNewCasting_RECT.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblDesignNewCasting_RECT.Location = New System.Drawing.Point(0, 0)
        Me.lblDesignNewCasting_RECT.Name = "lblDesignNewCasting_RECT"
        Me.lblDesignNewCasting_RECT.Size = New System.Drawing.Size(441, 19)
        Me.lblDesignNewCasting_RECT.TabIndex = 141
        Me.lblDesignNewCasting_RECT.Text = "Design New CrossTube Casting"
        Me.lblDesignNewCasting_RECT.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnGenerate_RECT
        '
        Me.btnGenerate_RECT.Location = New System.Drawing.Point(164, 127)
        Me.btnGenerate_RECT.Name = "btnGenerate_RECT"
        Me.btnGenerate_RECT.Size = New System.Drawing.Size(113, 23)
        Me.btnGenerate_RECT.TabIndex = 150
        Me.btnGenerate_RECT.Text = "Generate"
        Me.btnGenerate_RECT.UseVisualStyleBackColor = True
        '
        'txtSwingClearance_DesignCrossTubeCasting_RECT
        '
        Me.txtSwingClearance_DesignCrossTubeCasting_RECT.AcceptEnterKeyAsTab = True
        Me.txtSwingClearance_DesignCrossTubeCasting_RECT.ApplyIFLColor = True
        Me.txtSwingClearance_DesignCrossTubeCasting_RECT.AssociateLabel = Nothing
        Me.txtSwingClearance_DesignCrossTubeCasting_RECT.DecimalValue = 2
        Me.txtSwingClearance_DesignCrossTubeCasting_RECT.IFLDataTag = Nothing
        Me.txtSwingClearance_DesignCrossTubeCasting_RECT.InvalidInputCharacters = ""
        Me.txtSwingClearance_DesignCrossTubeCasting_RECT.IsAllowNegative = False
        Me.txtSwingClearance_DesignCrossTubeCasting_RECT.LengthValue = 6
        Me.txtSwingClearance_DesignCrossTubeCasting_RECT.Location = New System.Drawing.Point(324, 100)
        Me.txtSwingClearance_DesignCrossTubeCasting_RECT.MaximumValue = 99999
        Me.txtSwingClearance_DesignCrossTubeCasting_RECT.MaxLength = 6
        Me.txtSwingClearance_DesignCrossTubeCasting_RECT.MinimumValue = 0
        Me.txtSwingClearance_DesignCrossTubeCasting_RECT.Name = "txtSwingClearance_DesignCrossTubeCasting_RECT"
        Me.txtSwingClearance_DesignCrossTubeCasting_RECT.Size = New System.Drawing.Size(66, 20)
        Me.txtSwingClearance_DesignCrossTubeCasting_RECT.StatusMessage = ""
        Me.txtSwingClearance_DesignCrossTubeCasting_RECT.StatusObject = Nothing
        Me.txtSwingClearance_DesignCrossTubeCasting_RECT.TabIndex = 148
        Me.txtSwingClearance_DesignCrossTubeCasting_RECT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSwingClearance2
        '
        Me.lblSwingClearance2.AutoSize = True
        Me.lblSwingClearance2.Location = New System.Drawing.Point(231, 103)
        Me.lblSwingClearance2.Name = "lblSwingClearance2"
        Me.lblSwingClearance2.Size = New System.Drawing.Size(87, 13)
        Me.lblSwingClearance2.TabIndex = 149
        Me.lblSwingClearance2.Text = "Swing Clearance"
        '
        'txtPinHoleSize_DesignCrossTubeCasting_RECT
        '
        Me.txtPinHoleSize_DesignCrossTubeCasting_RECT.AcceptEnterKeyAsTab = True
        Me.txtPinHoleSize_DesignCrossTubeCasting_RECT.ApplyIFLColor = True
        Me.txtPinHoleSize_DesignCrossTubeCasting_RECT.AssociateLabel = Nothing
        Me.txtPinHoleSize_DesignCrossTubeCasting_RECT.DecimalValue = 2
        Me.txtPinHoleSize_DesignCrossTubeCasting_RECT.IFLDataTag = Nothing
        Me.txtPinHoleSize_DesignCrossTubeCasting_RECT.InvalidInputCharacters = ""
        Me.txtPinHoleSize_DesignCrossTubeCasting_RECT.IsAllowNegative = False
        Me.txtPinHoleSize_DesignCrossTubeCasting_RECT.LengthValue = 6
        Me.txtPinHoleSize_DesignCrossTubeCasting_RECT.Location = New System.Drawing.Point(324, 74)
        Me.txtPinHoleSize_DesignCrossTubeCasting_RECT.MaximumValue = 99999
        Me.txtPinHoleSize_DesignCrossTubeCasting_RECT.MaxLength = 6
        Me.txtPinHoleSize_DesignCrossTubeCasting_RECT.MinimumValue = 0
        Me.txtPinHoleSize_DesignCrossTubeCasting_RECT.Name = "txtPinHoleSize_DesignCrossTubeCasting_RECT"
        Me.txtPinHoleSize_DesignCrossTubeCasting_RECT.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleSize_DesignCrossTubeCasting_RECT.StatusMessage = ""
        Me.txtPinHoleSize_DesignCrossTubeCasting_RECT.StatusObject = Nothing
        Me.txtPinHoleSize_DesignCrossTubeCasting_RECT.TabIndex = 146
        Me.txtPinHoleSize_DesignCrossTubeCasting_RECT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPinHoleSize
        '
        Me.lblPinHoleSize.AutoSize = True
        Me.lblPinHoleSize.Location = New System.Drawing.Point(231, 77)
        Me.lblPinHoleSize.Name = "lblPinHoleSize"
        Me.lblPinHoleSize.Size = New System.Drawing.Size(70, 13)
        Me.lblPinHoleSize.TabIndex = 147
        Me.lblPinHoleSize.Text = "Pin Hole Size"
        '
        'btnAccept_RECT
        '
        Me.btnAccept_RECT.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnAccept_RECT.Location = New System.Drawing.Point(235, 393)
        Me.btnAccept_RECT.Name = "btnAccept_RECT"
        Me.btnAccept_RECT.Size = New System.Drawing.Size(113, 23)
        Me.btnAccept_RECT.TabIndex = 151
        Me.btnAccept_RECT.Text = "Accept"
        Me.btnAccept_RECT.UseVisualStyleBackColor = True
        '
        'lvwSafetyFactor_Weight_RECT
        '
        Me.lvwSafetyFactor_Weight_RECT.GridLines = True
        Me.lvwSafetyFactor_Weight_RECT.Location = New System.Drawing.Point(25, 29)
        Me.lvwSafetyFactor_Weight_RECT.Name = "lvwSafetyFactor_Weight_RECT"
        Me.lvwSafetyFactor_Weight_RECT.Size = New System.Drawing.Size(390, 116)
        Me.lvwSafetyFactor_Weight_RECT.TabIndex = 13
        Me.lvwSafetyFactor_Weight_RECT.UseCompatibleStateImageBehavior = False
        Me.lvwSafetyFactor_Weight_RECT.View = System.Windows.Forms.View.Details
        '
        'frmDesignACasting_RECT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(583, 477)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlDesignCasting_RECT)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDesignACasting_RECT"
        Me.Text = "DesignACasting_RECT"
        Me.pnlDesignCasting_RECT.ResumeLayout(False)
        Me.pnlSafetyFactor_Weight_LugThickness_RECT.ResumeLayout(False)
        Me.pnlDesignaCasting_RECT.ResumeLayout(False)
        Me.pnlDesignaCasting_RECT.PerformLayout()
        CType(Me.trbSafetyFactor_RECT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlDesignCasting_RECT As System.Windows.Forms.Panel
    Friend WithEvents pnlSafetyFactor_Weight_LugThickness_RECT As System.Windows.Forms.Panel
    Friend WithEvents lvwSafetyFactor_Weight_RECT As Monarch_WeldedCylinder_01_09_09.clsListViewMIL
    Friend WithEvents lblSafetyFactorIndex_RECT As LabelGradient.LabelGradient
    Friend WithEvents pnlDesignaCasting_RECT As System.Windows.Forms.Panel
    Friend WithEvents lblCrossTubeWidth_DesignNewCrossTube As System.Windows.Forms.Label
    Friend WithEvents txtCrossTubeWidth_DesignCrossTubeCasting_RECT As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblCrossTubeOD_DesignCrossTube As System.Windows.Forms.Label
    Friend WithEvents txtCrossTubeOD_DesignCrossTubeCasting_RECT As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtSafetyFactorOfCasting_RECT As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSafetyFactor As System.Windows.Forms.Label
    Friend WithEvents trbSafetyFactor_RECT As System.Windows.Forms.TrackBar
    Friend WithEvents lblDesignNewCasting_RECT As LabelGradient.LabelGradient
    Friend WithEvents btnAccept_RECT As System.Windows.Forms.Button
    Friend WithEvents btnGenerate_RECT As System.Windows.Forms.Button
    Friend WithEvents txtSwingClearance_DesignCrossTubeCasting_RECT As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSwingClearance2 As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleSize_DesignCrossTubeCasting_RECT As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblPinHoleSize As System.Windows.Forms.Label
End Class
