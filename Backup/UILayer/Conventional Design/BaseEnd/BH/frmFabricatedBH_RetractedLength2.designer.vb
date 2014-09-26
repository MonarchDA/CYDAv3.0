<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFabricatedBH_RetractedLength2
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
        Me.grbPlateClevis = New System.Windows.Forms.GroupBox
        Me.btnPlateClevis = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.grbMatchedSingleLugNotFound = New System.Windows.Forms.GroupBox
        Me.pnlSafetyFactor_Weight_LugThickness = New System.Windows.Forms.Panel
        Me.lblSafetyFactorIndex = New LabelGradient.LabelGradient
        Me.pnlDesignSingleLug = New System.Windows.Forms.Panel
        Me.chkOptimizer = New System.Windows.Forms.CheckBox
        Me.txtSafetyFactor_DesignBH = New IFLCustomUILayer.IFLNumericBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblSafetyFactor = New System.Windows.Forms.Label
        Me.trbSafetyFactor = New System.Windows.Forms.TrackBar
        Me.txtLugThickness_DesignBH = New IFLCustomUILayer.IFLNumericBox
        Me.lblDesignNewCasting = New LabelGradient.LabelGradient
        Me.btnGenerate = New System.Windows.Forms.Button
        Me.lblLugWidth2 = New System.Windows.Forms.Label
        Me.txtLugWidth_DesignBH = New IFLCustomUILayer.IFLNumericBox
        Me.txtSwingClearance_DesignBH = New IFLCustomUILayer.IFLNumericBox
        Me.lblSwingClearance2 = New System.Windows.Forms.Label
        Me.txtPinHoleSize_DesignBH = New IFLCustomUILayer.IFLNumericBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LabelGradient2 = New LabelGradient.LabelGradient
        Me.btnAccept = New System.Windows.Forms.Button
        Me.UcBrowsePlateClevis1 = New Monarch_WeldedCylinder_01_09_09.ucBrowsePlateClevis
        Me.lvwSafetyFactor_Weight = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL
        Me.grbPlateClevis.SuspendLayout()
        Me.grbMatchedSingleLugNotFound.SuspendLayout()
        Me.pnlSafetyFactor_Weight_LugThickness.SuspendLayout()
        Me.pnlDesignSingleLug.SuspendLayout()
        CType(Me.trbSafetyFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbPlateClevis
        '
        Me.grbPlateClevis.Controls.Add(Me.btnPlateClevis)
        Me.grbPlateClevis.Controls.Add(Me.UcBrowsePlateClevis1)
        Me.grbPlateClevis.Location = New System.Drawing.Point(37, 11)
        Me.grbPlateClevis.Name = "grbPlateClevis"
        Me.grbPlateClevis.Size = New System.Drawing.Size(559, 95)
        Me.grbPlateClevis.TabIndex = 161
        Me.grbPlateClevis.TabStop = False
        Me.grbPlateClevis.Text = "Plate Clevis"
        '
        'btnPlateClevis
        '
        Me.btnPlateClevis.Enabled = False
        Me.btnPlateClevis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPlateClevis.Location = New System.Drawing.Point(129, 38)
        Me.btnPlateClevis.Name = "btnPlateClevis"
        Me.btnPlateClevis.Size = New System.Drawing.Size(291, 34)
        Me.btnPlateClevis.TabIndex = 159
        Me.btnPlateClevis.Text = "Matching Plate Clevis found"
        Me.btnPlateClevis.UseVisualStyleBackColor = True
        Me.btnPlateClevis.Visible = False
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(521, 456)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 160
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grbMatchedSingleLugNotFound
        '
        Me.grbMatchedSingleLugNotFound.Controls.Add(Me.pnlSafetyFactor_Weight_LugThickness)
        Me.grbMatchedSingleLugNotFound.Controls.Add(Me.pnlDesignSingleLug)
        Me.grbMatchedSingleLugNotFound.Controls.Add(Me.LabelGradient2)
        Me.grbMatchedSingleLugNotFound.Controls.Add(Me.btnAccept)
        Me.grbMatchedSingleLugNotFound.Location = New System.Drawing.Point(37, 107)
        Me.grbMatchedSingleLugNotFound.Name = "grbMatchedSingleLugNotFound"
        Me.grbMatchedSingleLugNotFound.Size = New System.Drawing.Size(559, 343)
        Me.grbMatchedSingleLugNotFound.TabIndex = 159
        Me.grbMatchedSingleLugNotFound.TabStop = False
        '
        'pnlSafetyFactor_Weight_LugThickness
        '
        Me.pnlSafetyFactor_Weight_LugThickness.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlSafetyFactor_Weight_LugThickness.Controls.Add(Me.lvwSafetyFactor_Weight)
        Me.pnlSafetyFactor_Weight_LugThickness.Controls.Add(Me.lblSafetyFactorIndex)
        Me.pnlSafetyFactor_Weight_LugThickness.Location = New System.Drawing.Point(57, 185)
        Me.pnlSafetyFactor_Weight_LugThickness.Name = "pnlSafetyFactor_Weight_LugThickness"
        Me.pnlSafetyFactor_Weight_LugThickness.Size = New System.Drawing.Size(445, 125)
        Me.pnlSafetyFactor_Weight_LugThickness.TabIndex = 149
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
        'pnlDesignSingleLug
        '
        Me.pnlDesignSingleLug.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDesignSingleLug.Controls.Add(Me.chkOptimizer)
        Me.pnlDesignSingleLug.Controls.Add(Me.txtSafetyFactor_DesignBH)
        Me.pnlDesignSingleLug.Controls.Add(Me.Label5)
        Me.pnlDesignSingleLug.Controls.Add(Me.lblSafetyFactor)
        Me.pnlDesignSingleLug.Controls.Add(Me.trbSafetyFactor)
        Me.pnlDesignSingleLug.Controls.Add(Me.txtLugThickness_DesignBH)
        Me.pnlDesignSingleLug.Controls.Add(Me.lblDesignNewCasting)
        Me.pnlDesignSingleLug.Controls.Add(Me.btnGenerate)
        Me.pnlDesignSingleLug.Controls.Add(Me.lblLugWidth2)
        Me.pnlDesignSingleLug.Controls.Add(Me.txtLugWidth_DesignBH)
        Me.pnlDesignSingleLug.Controls.Add(Me.txtSwingClearance_DesignBH)
        Me.pnlDesignSingleLug.Controls.Add(Me.lblSwingClearance2)
        Me.pnlDesignSingleLug.Controls.Add(Me.txtPinHoleSize_DesignBH)
        Me.pnlDesignSingleLug.Controls.Add(Me.Label1)
        Me.pnlDesignSingleLug.Location = New System.Drawing.Point(57, 27)
        Me.pnlDesignSingleLug.Name = "pnlDesignSingleLug"
        Me.pnlDesignSingleLug.Size = New System.Drawing.Size(445, 152)
        Me.pnlDesignSingleLug.TabIndex = 148
        '
        'chkOptimizer
        '
        Me.chkOptimizer.AutoSize = True
        Me.chkOptimizer.Location = New System.Drawing.Point(324, 127)
        Me.chkOptimizer.Name = "chkOptimizer"
        Me.chkOptimizer.Size = New System.Drawing.Size(66, 17)
        Me.chkOptimizer.TabIndex = 167
        Me.chkOptimizer.Text = "Optimize"
        Me.chkOptimizer.UseVisualStyleBackColor = True
        '
        'txtSafetyFactor_DesignBH
        '
        Me.txtSafetyFactor_DesignBH.AcceptEnterKeyAsTab = True
        Me.txtSafetyFactor_DesignBH.ApplyIFLColor = True
        Me.txtSafetyFactor_DesignBH.AssociateLabel = Nothing
        Me.txtSafetyFactor_DesignBH.DecimalValue = 2
        Me.txtSafetyFactor_DesignBH.IFLDataTag = Nothing
        Me.txtSafetyFactor_DesignBH.InvalidInputCharacters = ""
        Me.txtSafetyFactor_DesignBH.IsAllowNegative = False
        Me.txtSafetyFactor_DesignBH.LengthValue = 6
        Me.txtSafetyFactor_DesignBH.Location = New System.Drawing.Point(385, 31)
        Me.txtSafetyFactor_DesignBH.MaximumValue = 99999
        Me.txtSafetyFactor_DesignBH.MaxLength = 6
        Me.txtSafetyFactor_DesignBH.MinimumValue = 0
        Me.txtSafetyFactor_DesignBH.Name = "txtSafetyFactor_DesignBH"
        Me.txtSafetyFactor_DesignBH.Size = New System.Drawing.Size(40, 20)
        Me.txtSafetyFactor_DesignBH.StatusMessage = ""
        Me.txtSafetyFactor_DesignBH.StatusObject = Nothing
        Me.txtSafetyFactor_DesignBH.TabIndex = 156
        Me.txtSafetyFactor_DesignBH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(50, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 155
        Me.Label5.Text = "Lug Thickness"
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
        'txtLugThickness_DesignBH
        '
        Me.txtLugThickness_DesignBH.AcceptEnterKeyAsTab = True
        Me.txtLugThickness_DesignBH.ApplyIFLColor = True
        Me.txtLugThickness_DesignBH.AssociateLabel = Nothing
        Me.txtLugThickness_DesignBH.DecimalValue = 3
        Me.txtLugThickness_DesignBH.IFLDataTag = Nothing
        Me.txtLugThickness_DesignBH.InvalidInputCharacters = ""
        Me.txtLugThickness_DesignBH.IsAllowNegative = False
        Me.txtLugThickness_DesignBH.LengthValue = 7
        Me.txtLugThickness_DesignBH.Location = New System.Drawing.Point(133, 68)
        Me.txtLugThickness_DesignBH.MaximumValue = 99999
        Me.txtLugThickness_DesignBH.MaxLength = 6
        Me.txtLugThickness_DesignBH.MinimumValue = 0
        Me.txtLugThickness_DesignBH.Name = "txtLugThickness_DesignBH"
        Me.txtLugThickness_DesignBH.Size = New System.Drawing.Size(66, 20)
        Me.txtLugThickness_DesignBH.StatusMessage = ""
        Me.txtLugThickness_DesignBH.StatusObject = Nothing
        Me.txtLugThickness_DesignBH.TabIndex = 154
        Me.txtLugThickness_DesignBH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.lblDesignNewCasting.Text = "Design SingleLug2"
        Me.lblDesignNewCasting.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(156, 121)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(129, 23)
        Me.btnGenerate.TabIndex = 150
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'lblLugWidth2
        '
        Me.lblLugWidth2.AutoSize = True
        Me.lblLugWidth2.Location = New System.Drawing.Point(50, 98)
        Me.lblLugWidth2.Name = "lblLugWidth2"
        Me.lblLugWidth2.Size = New System.Drawing.Size(56, 13)
        Me.lblLugWidth2.TabIndex = 143
        Me.lblLugWidth2.Text = "Lug Width"
        '
        'txtLugWidth_DesignBH
        '
        Me.txtLugWidth_DesignBH.AcceptEnterKeyAsTab = True
        Me.txtLugWidth_DesignBH.ApplyIFLColor = True
        Me.txtLugWidth_DesignBH.AssociateLabel = Nothing
        Me.txtLugWidth_DesignBH.DecimalValue = 2
        Me.txtLugWidth_DesignBH.IFLDataTag = Nothing
        Me.txtLugWidth_DesignBH.InvalidInputCharacters = ""
        Me.txtLugWidth_DesignBH.IsAllowNegative = False
        Me.txtLugWidth_DesignBH.LengthValue = 6
        Me.txtLugWidth_DesignBH.Location = New System.Drawing.Point(133, 95)
        Me.txtLugWidth_DesignBH.MaximumValue = 99999
        Me.txtLugWidth_DesignBH.MaxLength = 6
        Me.txtLugWidth_DesignBH.MinimumValue = 0
        Me.txtLugWidth_DesignBH.Name = "txtLugWidth_DesignBH"
        Me.txtLugWidth_DesignBH.Size = New System.Drawing.Size(66, 20)
        Me.txtLugWidth_DesignBH.StatusMessage = ""
        Me.txtLugWidth_DesignBH.StatusObject = Nothing
        Me.txtLugWidth_DesignBH.TabIndex = 142
        Me.txtLugWidth_DesignBH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSwingClearance_DesignBH
        '
        Me.txtSwingClearance_DesignBH.AcceptEnterKeyAsTab = True
        Me.txtSwingClearance_DesignBH.ApplyIFLColor = True
        Me.txtSwingClearance_DesignBH.AssociateLabel = Nothing
        Me.txtSwingClearance_DesignBH.DecimalValue = 2
        Me.txtSwingClearance_DesignBH.IFLDataTag = Nothing
        Me.txtSwingClearance_DesignBH.InvalidInputCharacters = ""
        Me.txtSwingClearance_DesignBH.IsAllowNegative = False
        Me.txtSwingClearance_DesignBH.LengthValue = 6
        Me.txtSwingClearance_DesignBH.Location = New System.Drawing.Point(324, 95)
        Me.txtSwingClearance_DesignBH.MaximumValue = 99999
        Me.txtSwingClearance_DesignBH.MaxLength = 6
        Me.txtSwingClearance_DesignBH.MinimumValue = 0
        Me.txtSwingClearance_DesignBH.Name = "txtSwingClearance_DesignBH"
        Me.txtSwingClearance_DesignBH.Size = New System.Drawing.Size(66, 20)
        Me.txtSwingClearance_DesignBH.StatusMessage = ""
        Me.txtSwingClearance_DesignBH.StatusObject = Nothing
        Me.txtSwingClearance_DesignBH.TabIndex = 148
        Me.txtSwingClearance_DesignBH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSwingClearance2
        '
        Me.lblSwingClearance2.AutoSize = True
        Me.lblSwingClearance2.Location = New System.Drawing.Point(227, 98)
        Me.lblSwingClearance2.Name = "lblSwingClearance2"
        Me.lblSwingClearance2.Size = New System.Drawing.Size(87, 13)
        Me.lblSwingClearance2.TabIndex = 149
        Me.lblSwingClearance2.Text = "Swing Clearance"
        '
        'txtPinHoleSize_DesignBH
        '
        Me.txtPinHoleSize_DesignBH.AcceptEnterKeyAsTab = True
        Me.txtPinHoleSize_DesignBH.ApplyIFLColor = True
        Me.txtPinHoleSize_DesignBH.AssociateLabel = Nothing
        Me.txtPinHoleSize_DesignBH.DecimalValue = 2
        Me.txtPinHoleSize_DesignBH.IFLDataTag = Nothing
        Me.txtPinHoleSize_DesignBH.InvalidInputCharacters = ""
        Me.txtPinHoleSize_DesignBH.IsAllowNegative = False
        Me.txtPinHoleSize_DesignBH.LengthValue = 6
        Me.txtPinHoleSize_DesignBH.Location = New System.Drawing.Point(324, 68)
        Me.txtPinHoleSize_DesignBH.MaximumValue = 99999
        Me.txtPinHoleSize_DesignBH.MaxLength = 6
        Me.txtPinHoleSize_DesignBH.MinimumValue = 0
        Me.txtPinHoleSize_DesignBH.Name = "txtPinHoleSize_DesignBH"
        Me.txtPinHoleSize_DesignBH.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleSize_DesignBH.StatusMessage = ""
        Me.txtPinHoleSize_DesignBH.StatusObject = Nothing
        Me.txtPinHoleSize_DesignBH.TabIndex = 146
        Me.txtPinHoleSize_DesignBH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(227, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 147
        Me.Label1.Text = "Pin Hole Size"
        '
        'LabelGradient2
        '
        Me.LabelGradient2.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient2.GradientColorOne = System.Drawing.Color.Olive
        Me.LabelGradient2.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient2.Location = New System.Drawing.Point(-4, 2)
        Me.LabelGradient2.Name = "LabelGradient2"
        Me.LabelGradient2.Size = New System.Drawing.Size(563, 19)
        Me.LabelGradient2.TabIndex = 22
        Me.LabelGradient2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(215, 311)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(129, 23)
        Me.btnAccept.TabIndex = 151
        Me.btnAccept.Text = "Accept"
        Me.btnAccept.UseVisualStyleBackColor = True
        '
        'UcBrowsePlateClevis1
        '
        Me.UcBrowsePlateClevis1.BackColor = System.Drawing.Color.Ivory
        Me.UcBrowsePlateClevis1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.UcBrowsePlateClevis1.Location = New System.Drawing.Point(16, 14)
        Me.UcBrowsePlateClevis1.Name = "UcBrowsePlateClevis1"
        Me.UcBrowsePlateClevis1.ObjFrmImportPlateClevis = Nothing
        Me.UcBrowsePlateClevis1.Size = New System.Drawing.Size(525, 74)
        Me.UcBrowsePlateClevis1.TabIndex = 0
        '
        'lvwSafetyFactor_Weight
        '
        Me.lvwSafetyFactor_Weight.GridLines = True
        Me.lvwSafetyFactor_Weight.Location = New System.Drawing.Point(25, 21)
        Me.lvwSafetyFactor_Weight.Name = "lvwSafetyFactor_Weight"
        Me.lvwSafetyFactor_Weight.Size = New System.Drawing.Size(390, 97)
        Me.lvwSafetyFactor_Weight.TabIndex = 13
        Me.lvwSafetyFactor_Weight.UseCompatibleStateImageBehavior = False
        Me.lvwSafetyFactor_Weight.View = System.Windows.Forms.View.Details
        '
        'frmFabricatedBH_RetractedLength2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Ivory
        Me.ClientSize = New System.Drawing.Size(633, 490)
        Me.ControlBox = False
        Me.Controls.Add(Me.grbPlateClevis)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grbMatchedSingleLugNotFound)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmFabricatedBH_RetractedLength2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmFabricatedBH_RetractedLength"
        Me.grbPlateClevis.ResumeLayout(False)
        Me.grbMatchedSingleLugNotFound.ResumeLayout(False)
        Me.pnlSafetyFactor_Weight_LugThickness.ResumeLayout(False)
        Me.pnlDesignSingleLug.ResumeLayout(False)
        Me.pnlDesignSingleLug.PerformLayout()
        CType(Me.trbSafetyFactor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbPlateClevis As System.Windows.Forms.GroupBox
    Friend WithEvents btnPlateClevis As System.Windows.Forms.Button
    Friend WithEvents UcBrowsePlateClevis1 As Monarch_WeldedCylinder_01_09_09.ucBrowsePlateClevis
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents grbMatchedSingleLugNotFound As System.Windows.Forms.GroupBox
    Friend WithEvents pnlSafetyFactor_Weight_LugThickness As System.Windows.Forms.Panel
    Friend WithEvents lvwSafetyFactor_Weight As Monarch_WeldedCylinder_01_09_09.clsListViewMIL
    Friend WithEvents lblSafetyFactorIndex As LabelGradient.LabelGradient
    Friend WithEvents pnlDesignSingleLug As System.Windows.Forms.Panel
    Friend WithEvents chkOptimizer As System.Windows.Forms.CheckBox
    Friend WithEvents txtSafetyFactor_DesignBH As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblSafetyFactor As System.Windows.Forms.Label
    Friend WithEvents trbSafetyFactor As System.Windows.Forms.TrackBar
    Friend WithEvents txtLugThickness_DesignBH As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblDesignNewCasting As LabelGradient.LabelGradient
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents lblLugWidth2 As System.Windows.Forms.Label
    Friend WithEvents txtLugWidth_DesignBH As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtSwingClearance_DesignBH As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSwingClearance2 As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleSize_DesignBH As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelGradient2 As LabelGradient.LabelGradient
    Friend WithEvents btnAccept As System.Windows.Forms.Button
End Class
