<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCTDesignACasting2
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
        Me.pnlDesignCasting = New System.Windows.Forms.Panel
        Me.pnlSafetyFactor_Weight_LugThickness = New System.Windows.Forms.Panel
        Me.lvwSafetyFactor_Weight = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL
        Me.lblSafetyFactorIndex = New LabelGradient.LabelGradient
        Me.pnlDesignaCasting = New System.Windows.Forms.Panel
        Me.chkOptimizer = New System.Windows.Forms.CheckBox
        Me.lblCrossTubeWidth_DesignNewCrossTube = New System.Windows.Forms.Label
        Me.txtCrossTubeWidth_DesignCrossTubeCasting = New IFLCustomUILayer.IFLNumericBox
        Me.lblCrossTubeOD_DesignCrossTube = New System.Windows.Forms.Label
        Me.txtCrossTubeOD_DesignCrossTubeCasting = New IFLCustomUILayer.IFLNumericBox
        Me.txtSafetyFactorOfCasting = New IFLCustomUILayer.IFLNumericBox
        Me.lblSafetyFactor = New System.Windows.Forms.Label
        Me.trbSafetyFactor = New System.Windows.Forms.TrackBar
        Me.lblDesignNewCasting = New LabelGradient.LabelGradient
        Me.btnGenerate = New System.Windows.Forms.Button
        Me.txtSwingClearance_DesignCrossTubeCasting = New IFLCustomUILayer.IFLNumericBox
        Me.lblSwingClearance2 = New System.Windows.Forms.Label
        Me.txtPinHoleSize_DesignCrossTubeCasting = New IFLCustomUILayer.IFLNumericBox
        Me.lblPinHoleSize = New System.Windows.Forms.Label
        Me.btnAccept = New System.Windows.Forms.Button
        Me.pnlDesignCasting.SuspendLayout()
        Me.pnlSafetyFactor_Weight_LugThickness.SuspendLayout()
        Me.pnlDesignaCasting.SuspendLayout()
        CType(Me.trbSafetyFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlDesignCasting
        '
        Me.pnlDesignCasting.AutoScroll = True
        Me.pnlDesignCasting.BackColor = System.Drawing.Color.Ivory
        Me.pnlDesignCasting.Controls.Add(Me.pnlSafetyFactor_Weight_LugThickness)
        Me.pnlDesignCasting.Controls.Add(Me.pnlDesignaCasting)
        Me.pnlDesignCasting.Controls.Add(Me.btnAccept)
        Me.pnlDesignCasting.Location = New System.Drawing.Point(0, 0)
        Me.pnlDesignCasting.Name = "pnlDesignCasting"
        Me.pnlDesignCasting.Size = New System.Drawing.Size(583, 477)
        Me.pnlDesignCasting.TabIndex = 7
        '
        'pnlSafetyFactor_Weight_LugThickness
        '
        Me.pnlSafetyFactor_Weight_LugThickness.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlSafetyFactor_Weight_LugThickness.Controls.Add(Me.lvwSafetyFactor_Weight)
        Me.pnlSafetyFactor_Weight_LugThickness.Controls.Add(Me.lblSafetyFactorIndex)
        Me.pnlSafetyFactor_Weight_LugThickness.Location = New System.Drawing.Point(69, 232)
        Me.pnlSafetyFactor_Weight_LugThickness.Name = "pnlSafetyFactor_Weight_LugThickness"
        Me.pnlSafetyFactor_Weight_LugThickness.Size = New System.Drawing.Size(445, 158)
        Me.pnlSafetyFactor_Weight_LugThickness.TabIndex = 4
        '
        'lvwSafetyFactor_Weight
        '
        Me.lvwSafetyFactor_Weight.GridLines = True
        Me.lvwSafetyFactor_Weight.Location = New System.Drawing.Point(25, 29)
        Me.lvwSafetyFactor_Weight.Name = "lvwSafetyFactor_Weight"
        Me.lvwSafetyFactor_Weight.Size = New System.Drawing.Size(390, 116)
        Me.lvwSafetyFactor_Weight.TabIndex = 13
        Me.lvwSafetyFactor_Weight.UseCompatibleStateImageBehavior = False
        Me.lvwSafetyFactor_Weight.View = System.Windows.Forms.View.Details
        '
        'lblSafetyFactorIndex
        '
        Me.lblSafetyFactorIndex.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblSafetyFactorIndex.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSafetyFactorIndex.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSafetyFactorIndex.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSafetyFactorIndex.GradientColorOne = System.Drawing.Color.Olive
        Me.lblSafetyFactorIndex.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblSafetyFactorIndex.Location = New System.Drawing.Point(0, 0)
        Me.lblSafetyFactorIndex.Name = "lblSafetyFactorIndex"
        Me.lblSafetyFactorIndex.Size = New System.Drawing.Size(441, 19)
        Me.lblSafetyFactorIndex.TabIndex = 159
        Me.lblSafetyFactorIndex.Text = "Generated Design Properties"
        Me.lblSafetyFactorIndex.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlDesignaCasting
        '
        Me.pnlDesignaCasting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDesignaCasting.Controls.Add(Me.chkOptimizer)
        Me.pnlDesignaCasting.Controls.Add(Me.lblCrossTubeWidth_DesignNewCrossTube)
        Me.pnlDesignaCasting.Controls.Add(Me.txtCrossTubeWidth_DesignCrossTubeCasting)
        Me.pnlDesignaCasting.Controls.Add(Me.lblCrossTubeOD_DesignCrossTube)
        Me.pnlDesignaCasting.Controls.Add(Me.txtCrossTubeOD_DesignCrossTubeCasting)
        Me.pnlDesignaCasting.Controls.Add(Me.txtSafetyFactorOfCasting)
        Me.pnlDesignaCasting.Controls.Add(Me.lblSafetyFactor)
        Me.pnlDesignaCasting.Controls.Add(Me.trbSafetyFactor)
        Me.pnlDesignaCasting.Controls.Add(Me.lblDesignNewCasting)
        Me.pnlDesignaCasting.Controls.Add(Me.btnGenerate)
        Me.pnlDesignaCasting.Controls.Add(Me.txtSwingClearance_DesignCrossTubeCasting)
        Me.pnlDesignaCasting.Controls.Add(Me.lblSwingClearance2)
        Me.pnlDesignaCasting.Controls.Add(Me.txtPinHoleSize_DesignCrossTubeCasting)
        Me.pnlDesignaCasting.Controls.Add(Me.lblPinHoleSize)
        Me.pnlDesignaCasting.Location = New System.Drawing.Point(69, 57)
        Me.pnlDesignaCasting.Name = "pnlDesignaCasting"
        Me.pnlDesignaCasting.Size = New System.Drawing.Size(445, 174)
        Me.pnlDesignaCasting.TabIndex = 3
        '
        'chkOptimizer
        '
        Me.chkOptimizer.AutoSize = True
        Me.chkOptimizer.Location = New System.Drawing.Point(312, 140)
        Me.chkOptimizer.Name = "chkOptimizer"
        Me.chkOptimizer.Size = New System.Drawing.Size(66, 17)
        Me.chkOptimizer.TabIndex = 161
        Me.chkOptimizer.Text = "Optimize"
        Me.chkOptimizer.UseVisualStyleBackColor = True
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
        'txtCrossTubeWidth_DesignCrossTubeCasting
        '
        Me.txtCrossTubeWidth_DesignCrossTubeCasting.AcceptEnterKeyAsTab = True
        Me.txtCrossTubeWidth_DesignCrossTubeCasting.ApplyIFLColor = True
        Me.txtCrossTubeWidth_DesignCrossTubeCasting.AssociateLabel = Nothing
        Me.txtCrossTubeWidth_DesignCrossTubeCasting.DecimalValue = 2
        Me.txtCrossTubeWidth_DesignCrossTubeCasting.IFLDataTag = Nothing
        Me.txtCrossTubeWidth_DesignCrossTubeCasting.InvalidInputCharacters = ""
        Me.txtCrossTubeWidth_DesignCrossTubeCasting.IsAllowNegative = False
        Me.txtCrossTubeWidth_DesignCrossTubeCasting.LengthValue = 6
        Me.txtCrossTubeWidth_DesignCrossTubeCasting.Location = New System.Drawing.Point(148, 74)
        Me.txtCrossTubeWidth_DesignCrossTubeCasting.MaximumValue = 99999
        Me.txtCrossTubeWidth_DesignCrossTubeCasting.MaxLength = 6
        Me.txtCrossTubeWidth_DesignCrossTubeCasting.MinimumValue = 0
        Me.txtCrossTubeWidth_DesignCrossTubeCasting.Name = "txtCrossTubeWidth_DesignCrossTubeCasting"
        Me.txtCrossTubeWidth_DesignCrossTubeCasting.Size = New System.Drawing.Size(66, 20)
        Me.txtCrossTubeWidth_DesignCrossTubeCasting.StatusMessage = ""
        Me.txtCrossTubeWidth_DesignCrossTubeCasting.StatusObject = Nothing
        Me.txtCrossTubeWidth_DesignCrossTubeCasting.TabIndex = 159
        Me.txtCrossTubeWidth_DesignCrossTubeCasting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'txtCrossTubeOD_DesignCrossTubeCasting
        '
        Me.txtCrossTubeOD_DesignCrossTubeCasting.AcceptEnterKeyAsTab = True
        Me.txtCrossTubeOD_DesignCrossTubeCasting.ApplyIFLColor = True
        Me.txtCrossTubeOD_DesignCrossTubeCasting.AssociateLabel = Nothing
        Me.txtCrossTubeOD_DesignCrossTubeCasting.DecimalValue = 2
        Me.txtCrossTubeOD_DesignCrossTubeCasting.IFLDataTag = Nothing
        Me.txtCrossTubeOD_DesignCrossTubeCasting.InvalidInputCharacters = ""
        Me.txtCrossTubeOD_DesignCrossTubeCasting.IsAllowNegative = False
        Me.txtCrossTubeOD_DesignCrossTubeCasting.LengthValue = 6
        Me.txtCrossTubeOD_DesignCrossTubeCasting.Location = New System.Drawing.Point(148, 101)
        Me.txtCrossTubeOD_DesignCrossTubeCasting.MaximumValue = 99999
        Me.txtCrossTubeOD_DesignCrossTubeCasting.MaxLength = 6
        Me.txtCrossTubeOD_DesignCrossTubeCasting.MinimumValue = 0
        Me.txtCrossTubeOD_DesignCrossTubeCasting.Name = "txtCrossTubeOD_DesignCrossTubeCasting"
        Me.txtCrossTubeOD_DesignCrossTubeCasting.Size = New System.Drawing.Size(66, 20)
        Me.txtCrossTubeOD_DesignCrossTubeCasting.StatusMessage = ""
        Me.txtCrossTubeOD_DesignCrossTubeCasting.StatusObject = Nothing
        Me.txtCrossTubeOD_DesignCrossTubeCasting.TabIndex = 157
        Me.txtCrossTubeOD_DesignCrossTubeCasting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSafetyFactorOfCasting
        '
        Me.txtSafetyFactorOfCasting.AcceptEnterKeyAsTab = True
        Me.txtSafetyFactorOfCasting.ApplyIFLColor = True
        Me.txtSafetyFactorOfCasting.AssociateLabel = Nothing
        Me.txtSafetyFactorOfCasting.DecimalValue = 2
        Me.txtSafetyFactorOfCasting.IFLDataTag = Nothing
        Me.txtSafetyFactorOfCasting.InvalidInputCharacters = ""
        Me.txtSafetyFactorOfCasting.IsAllowNegative = False
        Me.txtSafetyFactorOfCasting.LengthValue = 6
        Me.txtSafetyFactorOfCasting.Location = New System.Drawing.Point(374, 33)
        Me.txtSafetyFactorOfCasting.MaximumValue = 99999
        Me.txtSafetyFactorOfCasting.MaxLength = 6
        Me.txtSafetyFactorOfCasting.MinimumValue = 0
        Me.txtSafetyFactorOfCasting.Name = "txtSafetyFactorOfCasting"
        Me.txtSafetyFactorOfCasting.Size = New System.Drawing.Size(40, 20)
        Me.txtSafetyFactorOfCasting.StatusMessage = ""
        Me.txtSafetyFactorOfCasting.StatusObject = Nothing
        Me.txtSafetyFactorOfCasting.TabIndex = 156
        Me.txtSafetyFactorOfCasting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'trbSafetyFactor
        '
        Me.trbSafetyFactor.LargeChange = 1
        Me.trbSafetyFactor.Location = New System.Drawing.Point(102, 24)
        Me.trbSafetyFactor.Maximum = 40
        Me.trbSafetyFactor.Minimum = 2
        Me.trbSafetyFactor.Name = "trbSafetyFactor"
        Me.trbSafetyFactor.Size = New System.Drawing.Size(266, 45)
        Me.trbSafetyFactor.TabIndex = 152
        Me.trbSafetyFactor.Value = 2
        '
        'lblDesignNewCasting
        '
        Me.lblDesignNewCasting.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblDesignNewCasting.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDesignNewCasting.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesignNewCasting.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDesignNewCasting.GradientColorOne = System.Drawing.Color.Olive
        Me.lblDesignNewCasting.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblDesignNewCasting.Location = New System.Drawing.Point(0, 0)
        Me.lblDesignNewCasting.Name = "lblDesignNewCasting"
        Me.lblDesignNewCasting.Size = New System.Drawing.Size(441, 19)
        Me.lblDesignNewCasting.TabIndex = 141
        Me.lblDesignNewCasting.Text = "Design New CrossTube Casting2"
        Me.lblDesignNewCasting.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(161, 135)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(118, 23)
        Me.btnGenerate.TabIndex = 150
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'txtSwingClearance_DesignCrossTubeCasting
        '
        Me.txtSwingClearance_DesignCrossTubeCasting.AcceptEnterKeyAsTab = True
        Me.txtSwingClearance_DesignCrossTubeCasting.ApplyIFLColor = True
        Me.txtSwingClearance_DesignCrossTubeCasting.AssociateLabel = Nothing
        Me.txtSwingClearance_DesignCrossTubeCasting.DecimalValue = 2
        Me.txtSwingClearance_DesignCrossTubeCasting.IFLDataTag = Nothing
        Me.txtSwingClearance_DesignCrossTubeCasting.InvalidInputCharacters = ""
        Me.txtSwingClearance_DesignCrossTubeCasting.IsAllowNegative = False
        Me.txtSwingClearance_DesignCrossTubeCasting.LengthValue = 6
        Me.txtSwingClearance_DesignCrossTubeCasting.Location = New System.Drawing.Point(324, 100)
        Me.txtSwingClearance_DesignCrossTubeCasting.MaximumValue = 99999
        Me.txtSwingClearance_DesignCrossTubeCasting.MaxLength = 6
        Me.txtSwingClearance_DesignCrossTubeCasting.MinimumValue = 0
        Me.txtSwingClearance_DesignCrossTubeCasting.Name = "txtSwingClearance_DesignCrossTubeCasting"
        Me.txtSwingClearance_DesignCrossTubeCasting.Size = New System.Drawing.Size(66, 20)
        Me.txtSwingClearance_DesignCrossTubeCasting.StatusMessage = ""
        Me.txtSwingClearance_DesignCrossTubeCasting.StatusObject = Nothing
        Me.txtSwingClearance_DesignCrossTubeCasting.TabIndex = 148
        Me.txtSwingClearance_DesignCrossTubeCasting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'txtPinHoleSize_DesignCrossTubeCasting
        '
        Me.txtPinHoleSize_DesignCrossTubeCasting.AcceptEnterKeyAsTab = True
        Me.txtPinHoleSize_DesignCrossTubeCasting.ApplyIFLColor = True
        Me.txtPinHoleSize_DesignCrossTubeCasting.AssociateLabel = Nothing
        Me.txtPinHoleSize_DesignCrossTubeCasting.DecimalValue = 2
        Me.txtPinHoleSize_DesignCrossTubeCasting.IFLDataTag = Nothing
        Me.txtPinHoleSize_DesignCrossTubeCasting.InvalidInputCharacters = ""
        Me.txtPinHoleSize_DesignCrossTubeCasting.IsAllowNegative = False
        Me.txtPinHoleSize_DesignCrossTubeCasting.LengthValue = 6
        Me.txtPinHoleSize_DesignCrossTubeCasting.Location = New System.Drawing.Point(324, 74)
        Me.txtPinHoleSize_DesignCrossTubeCasting.MaximumValue = 99999
        Me.txtPinHoleSize_DesignCrossTubeCasting.MaxLength = 6
        Me.txtPinHoleSize_DesignCrossTubeCasting.MinimumValue = 0
        Me.txtPinHoleSize_DesignCrossTubeCasting.Name = "txtPinHoleSize_DesignCrossTubeCasting"
        Me.txtPinHoleSize_DesignCrossTubeCasting.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleSize_DesignCrossTubeCasting.StatusMessage = ""
        Me.txtPinHoleSize_DesignCrossTubeCasting.StatusObject = Nothing
        Me.txtPinHoleSize_DesignCrossTubeCasting.TabIndex = 146
        Me.txtPinHoleSize_DesignCrossTubeCasting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(232, 396)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(118, 23)
        Me.btnAccept.TabIndex = 151
        Me.btnAccept.Text = "Accept"
        Me.btnAccept.UseVisualStyleBackColor = True
        '
        'frmCTDesignACasting2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Ivory
        Me.ClientSize = New System.Drawing.Size(583, 477)
        Me.Controls.Add(Me.pnlDesignCasting)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCTDesignACasting2"
        Me.Text = "Form2"
        Me.pnlDesignCasting.ResumeLayout(False)
        Me.pnlSafetyFactor_Weight_LugThickness.ResumeLayout(False)
        Me.pnlDesignaCasting.ResumeLayout(False)
        Me.pnlDesignaCasting.PerformLayout()
        CType(Me.trbSafetyFactor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlDesignCasting As System.Windows.Forms.Panel
    Friend WithEvents pnlSafetyFactor_Weight_LugThickness As System.Windows.Forms.Panel
    Friend WithEvents lvwSafetyFactor_Weight As Monarch_WeldedCylinder_01_09_09.clsListViewMIL
    Friend WithEvents lblSafetyFactorIndex As LabelGradient.LabelGradient
    Friend WithEvents pnlDesignaCasting As System.Windows.Forms.Panel
    Friend WithEvents txtSafetyFactorOfCasting As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSafetyFactor As System.Windows.Forms.Label
    Friend WithEvents trbSafetyFactor As System.Windows.Forms.TrackBar
    Friend WithEvents lblDesignNewCasting As LabelGradient.LabelGradient
    Friend WithEvents btnAccept As System.Windows.Forms.Button
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents txtSwingClearance_DesignCrossTubeCasting As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSwingClearance2 As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleSize_DesignCrossTubeCasting As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblPinHoleSize As System.Windows.Forms.Label
    Friend WithEvents lblCrossTubeWidth_DesignNewCrossTube As System.Windows.Forms.Label
    Friend WithEvents txtCrossTubeWidth_DesignCrossTubeCasting As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblCrossTubeOD_DesignCrossTube As System.Windows.Forms.Label
    Friend WithEvents txtCrossTubeOD_DesignCrossTubeCasting As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents chkOptimizer As System.Windows.Forms.CheckBox
End Class
