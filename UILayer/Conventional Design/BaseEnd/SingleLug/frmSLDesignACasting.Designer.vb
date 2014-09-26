<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSLDesignACasting
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
        Me.btnAccept = New System.Windows.Forms.Button
        Me.btnGenerate = New System.Windows.Forms.Button
        Me.txtSwingClearance = New IFLCustomUILayer.IFLNumericBox
        Me.lblSwingClearance2 = New System.Windows.Forms.Label
        Me.txtPinHoleSize = New IFLCustomUILayer.IFLNumericBox
        Me.pnlDesignCasting = New System.Windows.Forms.Panel
        Me.pnlSafetyFactor_Weight_LugThickness = New System.Windows.Forms.Panel
        Me.lvwSafetyFactor_Weight = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL
        Me.lblSafetyFactorIndex = New LabelGradient.LabelGradient
        Me.pnlDesignaCasting = New System.Windows.Forms.Panel
        Me.chkOptimizer = New System.Windows.Forms.CheckBox
        Me.txtSafetyFactorOfCasting = New IFLCustomUILayer.IFLNumericBox
        Me.txtLugWidth = New IFLCustomUILayer.IFLNumericBox
        Me.lblLugWidth2 = New System.Windows.Forms.Label
        Me.lblLugThickness = New System.Windows.Forms.Label
        Me.txtLugThickness = New IFLCustomUILayer.IFLNumericBox
        Me.lblSafetyFactor = New System.Windows.Forms.Label
        Me.trbSafetyFactor = New System.Windows.Forms.TrackBar
        Me.lblDesignNewCasting = New LabelGradient.LabelGradient
        Me.lblPinHoleSize = New System.Windows.Forms.Label
        Me.pnlDesignCasting.SuspendLayout()
        Me.pnlSafetyFactor_Weight_LugThickness.SuspendLayout()
        Me.pnlDesignaCasting.SuspendLayout()
        CType(Me.trbSafetyFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(230, 396)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(123, 23)
        Me.btnAccept.TabIndex = 151
        Me.btnAccept.Text = "Accept"
        Me.btnAccept.UseVisualStyleBackColor = True
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(159, 129)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(123, 23)
        Me.btnGenerate.TabIndex = 150
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'txtSwingClearance
        '
        Me.txtSwingClearance.AcceptEnterKeyAsTab = True
        Me.txtSwingClearance.ApplyIFLColor = True
        Me.txtSwingClearance.AssociateLabel = Nothing
        Me.txtSwingClearance.DecimalValue = 2
        Me.txtSwingClearance.IFLDataTag = Nothing
        Me.txtSwingClearance.InvalidInputCharacters = ""
        Me.txtSwingClearance.IsAllowNegative = False
        Me.txtSwingClearance.LengthValue = 6
        Me.txtSwingClearance.Location = New System.Drawing.Point(325, 94)
        Me.txtSwingClearance.MaximumValue = 99999
        Me.txtSwingClearance.MaxLength = 6
        Me.txtSwingClearance.MinimumValue = 0
        Me.txtSwingClearance.Name = "txtSwingClearance"
        Me.txtSwingClearance.Size = New System.Drawing.Size(66, 20)
        Me.txtSwingClearance.StatusMessage = ""
        Me.txtSwingClearance.StatusObject = Nothing
        Me.txtSwingClearance.TabIndex = 148
        Me.txtSwingClearance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSwingClearance2
        '
        Me.lblSwingClearance2.AutoSize = True
        Me.lblSwingClearance2.Location = New System.Drawing.Point(228, 97)
        Me.lblSwingClearance2.Name = "lblSwingClearance2"
        Me.lblSwingClearance2.Size = New System.Drawing.Size(87, 13)
        Me.lblSwingClearance2.TabIndex = 149
        Me.lblSwingClearance2.Text = "Swing Clearance"
        '
        'txtPinHoleSize
        '
        Me.txtPinHoleSize.AcceptEnterKeyAsTab = True
        Me.txtPinHoleSize.ApplyIFLColor = True
        Me.txtPinHoleSize.AssociateLabel = Nothing
        Me.txtPinHoleSize.DecimalValue = 2
        Me.txtPinHoleSize.IFLDataTag = Nothing
        Me.txtPinHoleSize.InvalidInputCharacters = ""
        Me.txtPinHoleSize.IsAllowNegative = False
        Me.txtPinHoleSize.LengthValue = 6
        Me.txtPinHoleSize.Location = New System.Drawing.Point(325, 67)
        Me.txtPinHoleSize.MaximumValue = 99999
        Me.txtPinHoleSize.MaxLength = 6
        Me.txtPinHoleSize.MinimumValue = 0
        Me.txtPinHoleSize.Name = "txtPinHoleSize"
        Me.txtPinHoleSize.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleSize.StatusMessage = ""
        Me.txtPinHoleSize.StatusObject = Nothing
        Me.txtPinHoleSize.TabIndex = 146
        Me.txtPinHoleSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlDesignCasting
        '
        Me.pnlDesignCasting.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlDesignCasting.AutoScroll = True
        Me.pnlDesignCasting.BackColor = System.Drawing.Color.Ivory
        Me.pnlDesignCasting.Controls.Add(Me.pnlSafetyFactor_Weight_LugThickness)
        Me.pnlDesignCasting.Controls.Add(Me.pnlDesignaCasting)
        Me.pnlDesignCasting.Controls.Add(Me.btnAccept)
        Me.pnlDesignCasting.Location = New System.Drawing.Point(1, 0)
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
        Me.pnlSafetyFactor_Weight_LugThickness.TabIndex = 1
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
        Me.pnlDesignaCasting.Controls.Add(Me.txtSafetyFactorOfCasting)
        Me.pnlDesignaCasting.Controls.Add(Me.txtLugWidth)
        Me.pnlDesignaCasting.Controls.Add(Me.lblLugWidth2)
        Me.pnlDesignaCasting.Controls.Add(Me.lblLugThickness)
        Me.pnlDesignaCasting.Controls.Add(Me.txtLugThickness)
        Me.pnlDesignaCasting.Controls.Add(Me.lblSafetyFactor)
        Me.pnlDesignaCasting.Controls.Add(Me.trbSafetyFactor)
        Me.pnlDesignaCasting.Controls.Add(Me.lblDesignNewCasting)
        Me.pnlDesignaCasting.Controls.Add(Me.btnGenerate)
        Me.pnlDesignaCasting.Controls.Add(Me.txtSwingClearance)
        Me.pnlDesignaCasting.Controls.Add(Me.lblSwingClearance2)
        Me.pnlDesignaCasting.Controls.Add(Me.txtPinHoleSize)
        Me.pnlDesignaCasting.Controls.Add(Me.lblPinHoleSize)
        Me.pnlDesignaCasting.Location = New System.Drawing.Point(69, 58)
        Me.pnlDesignaCasting.Name = "pnlDesignaCasting"
        Me.pnlDesignaCasting.Size = New System.Drawing.Size(445, 168)
        Me.pnlDesignaCasting.TabIndex = 0
        '
        'chkOptimizer
        '
        Me.chkOptimizer.AutoSize = True
        Me.chkOptimizer.Location = New System.Drawing.Point(325, 135)
        Me.chkOptimizer.Name = "chkOptimizer"
        Me.chkOptimizer.Size = New System.Drawing.Size(66, 17)
        Me.chkOptimizer.TabIndex = 166
        Me.chkOptimizer.Text = "Optimize"
        Me.chkOptimizer.UseVisualStyleBackColor = True
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
        Me.txtSafetyFactorOfCasting.Location = New System.Drawing.Point(385, 27)
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
        'txtLugWidth
        '
        Me.txtLugWidth.AcceptEnterKeyAsTab = True
        Me.txtLugWidth.ApplyIFLColor = True
        Me.txtLugWidth.AssociateLabel = Nothing
        Me.txtLugWidth.DecimalValue = 2
        Me.txtLugWidth.IFLDataTag = Nothing
        Me.txtLugWidth.InvalidInputCharacters = ""
        Me.txtLugWidth.IsAllowNegative = False
        Me.txtLugWidth.LengthValue = 6
        Me.txtLugWidth.Location = New System.Drawing.Point(132, 94)
        Me.txtLugWidth.MaximumValue = 99999
        Me.txtLugWidth.MaxLength = 6
        Me.txtLugWidth.MinimumValue = 0
        Me.txtLugWidth.Name = "txtLugWidth"
        Me.txtLugWidth.Size = New System.Drawing.Size(66, 20)
        Me.txtLugWidth.StatusMessage = ""
        Me.txtLugWidth.StatusObject = Nothing
        Me.txtLugWidth.TabIndex = 142
        Me.txtLugWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLugWidth2
        '
        Me.lblLugWidth2.AutoSize = True
        Me.lblLugWidth2.Location = New System.Drawing.Point(49, 97)
        Me.lblLugWidth2.Name = "lblLugWidth2"
        Me.lblLugWidth2.Size = New System.Drawing.Size(56, 13)
        Me.lblLugWidth2.TabIndex = 143
        Me.lblLugWidth2.Text = "Lug Width"
        '
        'lblLugThickness
        '
        Me.lblLugThickness.AutoSize = True
        Me.lblLugThickness.Location = New System.Drawing.Point(49, 70)
        Me.lblLugThickness.Name = "lblLugThickness"
        Me.lblLugThickness.Size = New System.Drawing.Size(77, 13)
        Me.lblLugThickness.TabIndex = 155
        Me.lblLugThickness.Text = "Lug Thickness"
        '
        'txtLugThickness
        '
        Me.txtLugThickness.AcceptEnterKeyAsTab = True
        Me.txtLugThickness.ApplyIFLColor = True
        Me.txtLugThickness.AssociateLabel = Nothing
        Me.txtLugThickness.DecimalValue = 3
        Me.txtLugThickness.IFLDataTag = Nothing
        Me.txtLugThickness.InvalidInputCharacters = ""
        Me.txtLugThickness.IsAllowNegative = False
        Me.txtLugThickness.LengthValue = 7
        Me.txtLugThickness.Location = New System.Drawing.Point(132, 67)
        Me.txtLugThickness.MaximumValue = 99999
        Me.txtLugThickness.MaxLength = 6
        Me.txtLugThickness.MinimumValue = 0
        Me.txtLugThickness.Name = "txtLugThickness"
        Me.txtLugThickness.Size = New System.Drawing.Size(66, 20)
        Me.txtLugThickness.StatusMessage = ""
        Me.txtLugThickness.StatusObject = Nothing
        Me.txtLugThickness.TabIndex = 154
        Me.txtLugThickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSafetyFactor
        '
        Me.lblSafetyFactor.AutoSize = True
        Me.lblSafetyFactor.Location = New System.Drawing.Point(9, 34)
        Me.lblSafetyFactor.Name = "lblSafetyFactor"
        Me.lblSafetyFactor.Size = New System.Drawing.Size(70, 13)
        Me.lblSafetyFactor.TabIndex = 153
        Me.lblSafetyFactor.Text = "Safety Factor"
        '
        'trbSafetyFactor
        '
        Me.trbSafetyFactor.Location = New System.Drawing.Point(113, 22)
        Me.trbSafetyFactor.Maximum = 20
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
        Me.lblDesignNewCasting.Text = "Design New Casting"
        Me.lblDesignNewCasting.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblPinHoleSize
        '
        Me.lblPinHoleSize.AutoSize = True
        Me.lblPinHoleSize.Location = New System.Drawing.Point(228, 70)
        Me.lblPinHoleSize.Name = "lblPinHoleSize"
        Me.lblPinHoleSize.Size = New System.Drawing.Size(70, 13)
        Me.lblPinHoleSize.TabIndex = 147
        Me.lblPinHoleSize.Text = "Pin Hole Size"
        '
        'frmSLDesignACasting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(583, 477)
        Me.Controls.Add(Me.pnlDesignCasting)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSLDesignACasting"
        Me.Text = "frmSLDesignACasting"
        Me.pnlDesignCasting.ResumeLayout(False)
        Me.pnlSafetyFactor_Weight_LugThickness.ResumeLayout(False)
        Me.pnlDesignaCasting.ResumeLayout(False)
        Me.pnlDesignaCasting.PerformLayout()
        CType(Me.trbSafetyFactor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAccept As System.Windows.Forms.Button
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents txtSwingClearance As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSwingClearance2 As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleSize As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents pnlDesignCasting As System.Windows.Forms.Panel
    Friend WithEvents pnlDesignaCasting As System.Windows.Forms.Panel
    Friend WithEvents txtSafetyFactorOfCasting As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtLugWidth As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblLugWidth2 As System.Windows.Forms.Label
    Friend WithEvents lblLugThickness As System.Windows.Forms.Label
    Friend WithEvents txtLugThickness As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSafetyFactor As System.Windows.Forms.Label
    Friend WithEvents trbSafetyFactor As System.Windows.Forms.TrackBar
    Friend WithEvents lblDesignNewCasting As LabelGradient.LabelGradient
    Friend WithEvents lblPinHoleSize As System.Windows.Forms.Label
    Friend WithEvents pnlSafetyFactor_Weight_LugThickness As System.Windows.Forms.Panel
    Friend WithEvents lblSafetyFactorIndex As LabelGradient.LabelGradient
    Friend WithEvents lvwSafetyFactor_Weight As Monarch_WeldedCylinder_01_09_09.clsListViewMIL
    Friend WithEvents chkOptimizer As System.Windows.Forms.CheckBox
End Class
