<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCTFabricationNew2
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pnlSafetyFactor_Weight_LugThickness = New System.Windows.Forms.Panel
        Me.lvwSafetyFactor_Weight = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL
        Me.lblSafetyFactorIndex = New LabelGradient.LabelGradient
        Me.pnlDesignULug = New System.Windows.Forms.Panel
        Me.chkOptimizer = New System.Windows.Forms.CheckBox
        Me.txtSafetyFactor_DesignCrossTube = New IFLCustomUILayer.IFLNumericBox
        Me.lblCrossTubeWidth_DesignNewCrossTube = New System.Windows.Forms.Label
        Me.lblSafetyFactor = New System.Windows.Forms.Label
        Me.trbSafetyFactor = New System.Windows.Forms.TrackBar
        Me.txtCrossTubeWidth_DesignCrossTube = New IFLCustomUILayer.IFLNumericBox
        Me.lblDesignNewCasting = New LabelGradient.LabelGradient
        Me.btnGenerate = New System.Windows.Forms.Button
        Me.lblCrossTubeOD_DesignCrossTube = New System.Windows.Forms.Label
        Me.txtCrossTubeOD_DesignCrossTube = New IFLCustomUILayer.IFLNumericBox
        Me.txtSwingClearance_DesignCrossTube = New IFLCustomUILayer.IFLNumericBox
        Me.lblSwingClearance2 = New System.Windows.Forms.Label
        Me.txtPinHoleSize_DesignCrossTube = New IFLCustomUILayer.IFLNumericBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnAccept = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.pnlSafetyFactor_Weight_LugThickness.SuspendLayout()
        Me.pnlDesignULug.SuspendLayout()
        CType(Me.trbSafetyFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.pnlSafetyFactor_Weight_LugThickness)
        Me.Panel1.Controls.Add(Me.pnlDesignULug)
        Me.Panel1.Controls.Add(Me.btnAccept)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(583, 477)
        Me.Panel1.TabIndex = 0
        '
        'pnlSafetyFactor_Weight_LugThickness
        '
        Me.pnlSafetyFactor_Weight_LugThickness.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlSafetyFactor_Weight_LugThickness.Controls.Add(Me.lvwSafetyFactor_Weight)
        Me.pnlSafetyFactor_Weight_LugThickness.Controls.Add(Me.lblSafetyFactorIndex)
        Me.pnlSafetyFactor_Weight_LugThickness.Location = New System.Drawing.Point(69, 246)
        Me.pnlSafetyFactor_Weight_LugThickness.Name = "pnlSafetyFactor_Weight_LugThickness"
        Me.pnlSafetyFactor_Weight_LugThickness.Size = New System.Drawing.Size(445, 131)
        Me.pnlSafetyFactor_Weight_LugThickness.TabIndex = 153
        '
        'lvwSafetyFactor_Weight
        '
        Me.lvwSafetyFactor_Weight.GridLines = True
        Me.lvwSafetyFactor_Weight.Location = New System.Drawing.Point(25, 21)
        Me.lvwSafetyFactor_Weight.Name = "lvwSafetyFactor_Weight"
        Me.lvwSafetyFactor_Weight.Size = New System.Drawing.Size(390, 103)
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
        'pnlDesignULug
        '
        Me.pnlDesignULug.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDesignULug.Controls.Add(Me.chkOptimizer)
        Me.pnlDesignULug.Controls.Add(Me.txtSafetyFactor_DesignCrossTube)
        Me.pnlDesignULug.Controls.Add(Me.lblCrossTubeWidth_DesignNewCrossTube)
        Me.pnlDesignULug.Controls.Add(Me.lblSafetyFactor)
        Me.pnlDesignULug.Controls.Add(Me.trbSafetyFactor)
        Me.pnlDesignULug.Controls.Add(Me.txtCrossTubeWidth_DesignCrossTube)
        Me.pnlDesignULug.Controls.Add(Me.lblDesignNewCasting)
        Me.pnlDesignULug.Controls.Add(Me.btnGenerate)
        Me.pnlDesignULug.Controls.Add(Me.lblCrossTubeOD_DesignCrossTube)
        Me.pnlDesignULug.Controls.Add(Me.txtCrossTubeOD_DesignCrossTube)
        Me.pnlDesignULug.Controls.Add(Me.txtSwingClearance_DesignCrossTube)
        Me.pnlDesignULug.Controls.Add(Me.lblSwingClearance2)
        Me.pnlDesignULug.Controls.Add(Me.txtPinHoleSize_DesignCrossTube)
        Me.pnlDesignULug.Controls.Add(Me.Label1)
        Me.pnlDesignULug.Location = New System.Drawing.Point(69, 71)
        Me.pnlDesignULug.Name = "pnlDesignULug"
        Me.pnlDesignULug.Size = New System.Drawing.Size(445, 169)
        Me.pnlDesignULug.TabIndex = 152
        '
        'chkOptimizer
        '
        Me.chkOptimizer.AutoSize = True
        Me.chkOptimizer.Location = New System.Drawing.Point(325, 136)
        Me.chkOptimizer.Name = "chkOptimizer"
        Me.chkOptimizer.Size = New System.Drawing.Size(66, 17)
        Me.chkOptimizer.TabIndex = 163
        Me.chkOptimizer.Text = "Optimize"
        Me.chkOptimizer.UseVisualStyleBackColor = True
        '
        'txtSafetyFactor_DesignCrossTube
        '
        Me.txtSafetyFactor_DesignCrossTube.AcceptEnterKeyAsTab = True
        Me.txtSafetyFactor_DesignCrossTube.ApplyIFLColor = True
        Me.txtSafetyFactor_DesignCrossTube.AssociateLabel = Nothing
        Me.txtSafetyFactor_DesignCrossTube.DecimalValue = 2
        Me.txtSafetyFactor_DesignCrossTube.IFLDataTag = Nothing
        Me.txtSafetyFactor_DesignCrossTube.InvalidInputCharacters = ""
        Me.txtSafetyFactor_DesignCrossTube.IsAllowNegative = False
        Me.txtSafetyFactor_DesignCrossTube.LengthValue = 6
        Me.txtSafetyFactor_DesignCrossTube.Location = New System.Drawing.Point(385, 33)
        Me.txtSafetyFactor_DesignCrossTube.MaximumValue = 99999
        Me.txtSafetyFactor_DesignCrossTube.MaxLength = 6
        Me.txtSafetyFactor_DesignCrossTube.MinimumValue = 0
        Me.txtSafetyFactor_DesignCrossTube.Name = "txtSafetyFactor_DesignCrossTube"
        Me.txtSafetyFactor_DesignCrossTube.Size = New System.Drawing.Size(40, 20)
        Me.txtSafetyFactor_DesignCrossTube.StatusMessage = ""
        Me.txtSafetyFactor_DesignCrossTube.StatusObject = Nothing
        Me.txtSafetyFactor_DesignCrossTube.TabIndex = 156
        Me.txtSafetyFactor_DesignCrossTube.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCrossTubeWidth_DesignNewCrossTube
        '
        Me.lblCrossTubeWidth_DesignNewCrossTube.AutoSize = True
        Me.lblCrossTubeWidth_DesignNewCrossTube.Location = New System.Drawing.Point(49, 73)
        Me.lblCrossTubeWidth_DesignNewCrossTube.Name = "lblCrossTubeWidth_DesignNewCrossTube"
        Me.lblCrossTubeWidth_DesignNewCrossTube.Size = New System.Drawing.Size(89, 13)
        Me.lblCrossTubeWidth_DesignNewCrossTube.TabIndex = 155
        Me.lblCrossTubeWidth_DesignNewCrossTube.Text = "CrossTube Width"
        '
        'lblSafetyFactor
        '
        Me.lblSafetyFactor.AutoSize = True
        Me.lblSafetyFactor.Location = New System.Drawing.Point(9, 36)
        Me.lblSafetyFactor.Name = "lblSafetyFactor"
        Me.lblSafetyFactor.Size = New System.Drawing.Size(70, 13)
        Me.lblSafetyFactor.TabIndex = 153
        Me.lblSafetyFactor.Text = "Safety Factor"
        '
        'trbSafetyFactor
        '
        Me.trbSafetyFactor.Location = New System.Drawing.Point(113, 24)
        Me.trbSafetyFactor.Maximum = 20
        Me.trbSafetyFactor.Minimum = 2
        Me.trbSafetyFactor.Name = "trbSafetyFactor"
        Me.trbSafetyFactor.Size = New System.Drawing.Size(266, 45)
        Me.trbSafetyFactor.TabIndex = 152
        Me.trbSafetyFactor.Value = 2
        '
        'txtCrossTubeWidth_DesignCrossTube
        '
        Me.txtCrossTubeWidth_DesignCrossTube.AcceptEnterKeyAsTab = True
        Me.txtCrossTubeWidth_DesignCrossTube.ApplyIFLColor = True
        Me.txtCrossTubeWidth_DesignCrossTube.AssociateLabel = Nothing
        Me.txtCrossTubeWidth_DesignCrossTube.DecimalValue = 2
        Me.txtCrossTubeWidth_DesignCrossTube.IFLDataTag = Nothing
        Me.txtCrossTubeWidth_DesignCrossTube.InvalidInputCharacters = ""
        Me.txtCrossTubeWidth_DesignCrossTube.IsAllowNegative = False
        Me.txtCrossTubeWidth_DesignCrossTube.LengthValue = 6
        Me.txtCrossTubeWidth_DesignCrossTube.Location = New System.Drawing.Point(147, 70)
        Me.txtCrossTubeWidth_DesignCrossTube.MaximumValue = 99999
        Me.txtCrossTubeWidth_DesignCrossTube.MaxLength = 6
        Me.txtCrossTubeWidth_DesignCrossTube.MinimumValue = 0
        Me.txtCrossTubeWidth_DesignCrossTube.Name = "txtCrossTubeWidth_DesignCrossTube"
        Me.txtCrossTubeWidth_DesignCrossTube.Size = New System.Drawing.Size(66, 20)
        Me.txtCrossTubeWidth_DesignCrossTube.StatusMessage = ""
        Me.txtCrossTubeWidth_DesignCrossTube.StatusObject = Nothing
        Me.txtCrossTubeWidth_DesignCrossTube.TabIndex = 154
        Me.txtCrossTubeWidth_DesignCrossTube.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.lblDesignNewCasting.Text = "Design New CrossTube2"
        Me.lblDesignNewCasting.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(162, 130)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(116, 23)
        Me.btnGenerate.TabIndex = 150
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'lblCrossTubeOD_DesignCrossTube
        '
        Me.lblCrossTubeOD_DesignCrossTube.AutoSize = True
        Me.lblCrossTubeOD_DesignCrossTube.Location = New System.Drawing.Point(49, 100)
        Me.lblCrossTubeOD_DesignCrossTube.Name = "lblCrossTubeOD_DesignCrossTube"
        Me.lblCrossTubeOD_DesignCrossTube.Size = New System.Drawing.Size(77, 13)
        Me.lblCrossTubeOD_DesignCrossTube.TabIndex = 143
        Me.lblCrossTubeOD_DesignCrossTube.Text = "CrossTube OD"
        '
        'txtCrossTubeOD_DesignCrossTube
        '
        Me.txtCrossTubeOD_DesignCrossTube.AcceptEnterKeyAsTab = True
        Me.txtCrossTubeOD_DesignCrossTube.ApplyIFLColor = True
        Me.txtCrossTubeOD_DesignCrossTube.AssociateLabel = Nothing
        Me.txtCrossTubeOD_DesignCrossTube.DecimalValue = 2
        Me.txtCrossTubeOD_DesignCrossTube.IFLDataTag = Nothing
        Me.txtCrossTubeOD_DesignCrossTube.InvalidInputCharacters = ""
        Me.txtCrossTubeOD_DesignCrossTube.IsAllowNegative = False
        Me.txtCrossTubeOD_DesignCrossTube.LengthValue = 6
        Me.txtCrossTubeOD_DesignCrossTube.Location = New System.Drawing.Point(147, 97)
        Me.txtCrossTubeOD_DesignCrossTube.MaximumValue = 99999
        Me.txtCrossTubeOD_DesignCrossTube.MaxLength = 6
        Me.txtCrossTubeOD_DesignCrossTube.MinimumValue = 0
        Me.txtCrossTubeOD_DesignCrossTube.Name = "txtCrossTubeOD_DesignCrossTube"
        Me.txtCrossTubeOD_DesignCrossTube.Size = New System.Drawing.Size(66, 20)
        Me.txtCrossTubeOD_DesignCrossTube.StatusMessage = ""
        Me.txtCrossTubeOD_DesignCrossTube.StatusObject = Nothing
        Me.txtCrossTubeOD_DesignCrossTube.TabIndex = 142
        Me.txtCrossTubeOD_DesignCrossTube.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSwingClearance_DesignCrossTube
        '
        Me.txtSwingClearance_DesignCrossTube.AcceptEnterKeyAsTab = True
        Me.txtSwingClearance_DesignCrossTube.ApplyIFLColor = True
        Me.txtSwingClearance_DesignCrossTube.AssociateLabel = Nothing
        Me.txtSwingClearance_DesignCrossTube.DecimalValue = 2
        Me.txtSwingClearance_DesignCrossTube.IFLDataTag = Nothing
        Me.txtSwingClearance_DesignCrossTube.InvalidInputCharacters = ""
        Me.txtSwingClearance_DesignCrossTube.IsAllowNegative = False
        Me.txtSwingClearance_DesignCrossTube.LengthValue = 6
        Me.txtSwingClearance_DesignCrossTube.Location = New System.Drawing.Point(325, 97)
        Me.txtSwingClearance_DesignCrossTube.MaximumValue = 99999
        Me.txtSwingClearance_DesignCrossTube.MaxLength = 6
        Me.txtSwingClearance_DesignCrossTube.MinimumValue = 0
        Me.txtSwingClearance_DesignCrossTube.Name = "txtSwingClearance_DesignCrossTube"
        Me.txtSwingClearance_DesignCrossTube.Size = New System.Drawing.Size(66, 20)
        Me.txtSwingClearance_DesignCrossTube.StatusMessage = ""
        Me.txtSwingClearance_DesignCrossTube.StatusObject = Nothing
        Me.txtSwingClearance_DesignCrossTube.TabIndex = 148
        Me.txtSwingClearance_DesignCrossTube.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSwingClearance2
        '
        Me.lblSwingClearance2.AutoSize = True
        Me.lblSwingClearance2.Location = New System.Drawing.Point(228, 100)
        Me.lblSwingClearance2.Name = "lblSwingClearance2"
        Me.lblSwingClearance2.Size = New System.Drawing.Size(87, 13)
        Me.lblSwingClearance2.TabIndex = 149
        Me.lblSwingClearance2.Text = "Swing Clearance"
        '
        'txtPinHoleSize_DesignCrossTube
        '
        Me.txtPinHoleSize_DesignCrossTube.AcceptEnterKeyAsTab = True
        Me.txtPinHoleSize_DesignCrossTube.ApplyIFLColor = True
        Me.txtPinHoleSize_DesignCrossTube.AssociateLabel = Nothing
        Me.txtPinHoleSize_DesignCrossTube.DecimalValue = 2
        Me.txtPinHoleSize_DesignCrossTube.IFLDataTag = Nothing
        Me.txtPinHoleSize_DesignCrossTube.InvalidInputCharacters = ""
        Me.txtPinHoleSize_DesignCrossTube.IsAllowNegative = False
        Me.txtPinHoleSize_DesignCrossTube.LengthValue = 6
        Me.txtPinHoleSize_DesignCrossTube.Location = New System.Drawing.Point(325, 70)
        Me.txtPinHoleSize_DesignCrossTube.MaximumValue = 99999
        Me.txtPinHoleSize_DesignCrossTube.MaxLength = 6
        Me.txtPinHoleSize_DesignCrossTube.MinimumValue = 0
        Me.txtPinHoleSize_DesignCrossTube.Name = "txtPinHoleSize_DesignCrossTube"
        Me.txtPinHoleSize_DesignCrossTube.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleSize_DesignCrossTube.StatusMessage = ""
        Me.txtPinHoleSize_DesignCrossTube.StatusObject = Nothing
        Me.txtPinHoleSize_DesignCrossTube.TabIndex = 146
        Me.txtPinHoleSize_DesignCrossTube.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(228, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 147
        Me.Label1.Text = "Pin Hole Size"
        '
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(233, 383)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(116, 23)
        Me.btnAccept.TabIndex = 151
        Me.btnAccept.Text = "Accept"
        Me.btnAccept.UseVisualStyleBackColor = True
        '
        'frmCTFabricationNew2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Ivory
        Me.ClientSize = New System.Drawing.Size(583, 477)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCTFabricationNew2"
        Me.Text = "frmCTFabricationNew"
        Me.Panel1.ResumeLayout(False)
        Me.pnlSafetyFactor_Weight_LugThickness.ResumeLayout(False)
        Me.pnlDesignULug.ResumeLayout(False)
        Me.pnlDesignULug.PerformLayout()
        CType(Me.trbSafetyFactor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlSafetyFactor_Weight_LugThickness As System.Windows.Forms.Panel
    Friend WithEvents lvwSafetyFactor_Weight As Monarch_WeldedCylinder_01_09_09.clsListViewMIL
    Friend WithEvents lblSafetyFactorIndex As LabelGradient.LabelGradient
    Friend WithEvents pnlDesignULug As System.Windows.Forms.Panel
    Friend WithEvents txtSafetyFactor_DesignCrossTube As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblCrossTubeWidth_DesignNewCrossTube As System.Windows.Forms.Label
    Friend WithEvents lblSafetyFactor As System.Windows.Forms.Label
    Friend WithEvents trbSafetyFactor As System.Windows.Forms.TrackBar
    Friend WithEvents txtCrossTubeWidth_DesignCrossTube As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblDesignNewCasting As LabelGradient.LabelGradient
    Friend WithEvents btnAccept As System.Windows.Forms.Button
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents lblCrossTubeOD_DesignCrossTube As System.Windows.Forms.Label
    Friend WithEvents txtCrossTubeOD_DesignCrossTube As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtSwingClearance_DesignCrossTube As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSwingClearance2 As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleSize_DesignCrossTube As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkOptimizer As System.Windows.Forms.CheckBox
End Class
