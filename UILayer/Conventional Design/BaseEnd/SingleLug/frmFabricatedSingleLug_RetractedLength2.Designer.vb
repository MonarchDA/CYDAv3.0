<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFabricatedSingleLug_RetractedLength2
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
        Me.grbMatchedSingleLugNotFound = New System.Windows.Forms.GroupBox
        Me.pnlSafetyFactor_Weight_LugThickness = New System.Windows.Forms.Panel
        Me.lvwSafetyFactor_Weight = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL
        Me.lblSafetyFactorIndex = New LabelGradient.LabelGradient
        Me.pnlDesignSingleLug = New System.Windows.Forms.Panel
        Me.chkOptimizer = New System.Windows.Forms.CheckBox
        Me.txtSafetyFactor_DesignSingleLug = New IFLCustomUILayer.IFLNumericBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblSafetyFactor = New System.Windows.Forms.Label
        Me.trbSafetyFactor = New System.Windows.Forms.TrackBar
        Me.txtLugThickness_DesignSingleLug = New IFLCustomUILayer.IFLNumericBox
        Me.lblDesignNewCasting = New LabelGradient.LabelGradient
        Me.btnGenerate = New System.Windows.Forms.Button
        Me.lblLugWidth2 = New System.Windows.Forms.Label
        Me.txtLugWidth_DesignSingleLug = New IFLCustomUILayer.IFLNumericBox
        Me.txtSwingClearance_DesignSingleLug = New IFLCustomUILayer.IFLNumericBox
        Me.lblSwingClearance2 = New System.Windows.Forms.Label
        Me.txtPinHoleSize_DesignSingleLug = New IFLCustomUILayer.IFLNumericBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LabelGradient2 = New LabelGradient.LabelGradient
        Me.btnAccept = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.grbPlateClevis = New System.Windows.Forms.GroupBox
        Me.btnPlateClevis = New System.Windows.Forms.Button
        Me.UcBrowsePlateClevis1 = New Monarch_WeldedCylinder_01_09_09.ucBrowsePlateClevis
        Me.grbMatchedSingleLugNotFound.SuspendLayout()
        Me.pnlSafetyFactor_Weight_LugThickness.SuspendLayout()
        Me.pnlDesignSingleLug.SuspendLayout()
        CType(Me.trbSafetyFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbPlateClevis.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbMatchedSingleLugNotFound
        '
        Me.grbMatchedSingleLugNotFound.Controls.Add(Me.pnlSafetyFactor_Weight_LugThickness)
        Me.grbMatchedSingleLugNotFound.Controls.Add(Me.pnlDesignSingleLug)
        Me.grbMatchedSingleLugNotFound.Controls.Add(Me.LabelGradient2)
        Me.grbMatchedSingleLugNotFound.Controls.Add(Me.btnAccept)
        Me.grbMatchedSingleLugNotFound.Location = New System.Drawing.Point(32, 104)
        Me.grbMatchedSingleLugNotFound.Name = "grbMatchedSingleLugNotFound"
        Me.grbMatchedSingleLugNotFound.Size = New System.Drawing.Size(559, 343)
        Me.grbMatchedSingleLugNotFound.TabIndex = 148
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
        Me.pnlDesignSingleLug.Controls.Add(Me.txtSafetyFactor_DesignSingleLug)
        Me.pnlDesignSingleLug.Controls.Add(Me.Label5)
        Me.pnlDesignSingleLug.Controls.Add(Me.lblSafetyFactor)
        Me.pnlDesignSingleLug.Controls.Add(Me.trbSafetyFactor)
        Me.pnlDesignSingleLug.Controls.Add(Me.txtLugThickness_DesignSingleLug)
        Me.pnlDesignSingleLug.Controls.Add(Me.lblDesignNewCasting)
        Me.pnlDesignSingleLug.Controls.Add(Me.btnGenerate)
        Me.pnlDesignSingleLug.Controls.Add(Me.lblLugWidth2)
        Me.pnlDesignSingleLug.Controls.Add(Me.txtLugWidth_DesignSingleLug)
        Me.pnlDesignSingleLug.Controls.Add(Me.txtSwingClearance_DesignSingleLug)
        Me.pnlDesignSingleLug.Controls.Add(Me.lblSwingClearance2)
        Me.pnlDesignSingleLug.Controls.Add(Me.txtPinHoleSize_DesignSingleLug)
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
        'txtSafetyFactor_DesignSingleLug
        '
        Me.txtSafetyFactor_DesignSingleLug.AcceptEnterKeyAsTab = True
        Me.txtSafetyFactor_DesignSingleLug.ApplyIFLColor = True
        Me.txtSafetyFactor_DesignSingleLug.AssociateLabel = Nothing
        Me.txtSafetyFactor_DesignSingleLug.DecimalValue = 2
        Me.txtSafetyFactor_DesignSingleLug.IFLDataTag = Nothing
        Me.txtSafetyFactor_DesignSingleLug.InvalidInputCharacters = ""
        Me.txtSafetyFactor_DesignSingleLug.IsAllowNegative = False
        Me.txtSafetyFactor_DesignSingleLug.LengthValue = 6
        Me.txtSafetyFactor_DesignSingleLug.Location = New System.Drawing.Point(385, 31)
        Me.txtSafetyFactor_DesignSingleLug.MaximumValue = 99999
        Me.txtSafetyFactor_DesignSingleLug.MaxLength = 6
        Me.txtSafetyFactor_DesignSingleLug.MinimumValue = 0
        Me.txtSafetyFactor_DesignSingleLug.Name = "txtSafetyFactor_DesignSingleLug"
        Me.txtSafetyFactor_DesignSingleLug.Size = New System.Drawing.Size(40, 20)
        Me.txtSafetyFactor_DesignSingleLug.StatusMessage = ""
        Me.txtSafetyFactor_DesignSingleLug.StatusObject = Nothing
        Me.txtSafetyFactor_DesignSingleLug.TabIndex = 156
        Me.txtSafetyFactor_DesignSingleLug.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'txtLugThickness_DesignSingleLug
        '
        Me.txtLugThickness_DesignSingleLug.AcceptEnterKeyAsTab = True
        Me.txtLugThickness_DesignSingleLug.ApplyIFLColor = True
        Me.txtLugThickness_DesignSingleLug.AssociateLabel = Nothing
        Me.txtLugThickness_DesignSingleLug.DecimalValue = 3
        Me.txtLugThickness_DesignSingleLug.IFLDataTag = Nothing
        Me.txtLugThickness_DesignSingleLug.InvalidInputCharacters = ""
        Me.txtLugThickness_DesignSingleLug.IsAllowNegative = False
        Me.txtLugThickness_DesignSingleLug.LengthValue = 7
        Me.txtLugThickness_DesignSingleLug.Location = New System.Drawing.Point(133, 68)
        Me.txtLugThickness_DesignSingleLug.MaximumValue = 99999
        Me.txtLugThickness_DesignSingleLug.MaxLength = 6
        Me.txtLugThickness_DesignSingleLug.MinimumValue = 0
        Me.txtLugThickness_DesignSingleLug.Name = "txtLugThickness_DesignSingleLug"
        Me.txtLugThickness_DesignSingleLug.Size = New System.Drawing.Size(66, 20)
        Me.txtLugThickness_DesignSingleLug.StatusMessage = ""
        Me.txtLugThickness_DesignSingleLug.StatusObject = Nothing
        Me.txtLugThickness_DesignSingleLug.TabIndex = 154
        Me.txtLugThickness_DesignSingleLug.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.lblDesignNewCasting.Text = "Design SingleLug"
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
        'txtLugWidth_DesignSingleLug
        '
        Me.txtLugWidth_DesignSingleLug.AcceptEnterKeyAsTab = True
        Me.txtLugWidth_DesignSingleLug.ApplyIFLColor = True
        Me.txtLugWidth_DesignSingleLug.AssociateLabel = Nothing
        Me.txtLugWidth_DesignSingleLug.DecimalValue = 2
        Me.txtLugWidth_DesignSingleLug.IFLDataTag = Nothing
        Me.txtLugWidth_DesignSingleLug.InvalidInputCharacters = ""
        Me.txtLugWidth_DesignSingleLug.IsAllowNegative = False
        Me.txtLugWidth_DesignSingleLug.LengthValue = 6
        Me.txtLugWidth_DesignSingleLug.Location = New System.Drawing.Point(133, 95)
        Me.txtLugWidth_DesignSingleLug.MaximumValue = 99999
        Me.txtLugWidth_DesignSingleLug.MaxLength = 6
        Me.txtLugWidth_DesignSingleLug.MinimumValue = 0
        Me.txtLugWidth_DesignSingleLug.Name = "txtLugWidth_DesignSingleLug"
        Me.txtLugWidth_DesignSingleLug.Size = New System.Drawing.Size(66, 20)
        Me.txtLugWidth_DesignSingleLug.StatusMessage = ""
        Me.txtLugWidth_DesignSingleLug.StatusObject = Nothing
        Me.txtLugWidth_DesignSingleLug.TabIndex = 142
        Me.txtLugWidth_DesignSingleLug.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSwingClearance_DesignSingleLug
        '
        Me.txtSwingClearance_DesignSingleLug.AcceptEnterKeyAsTab = True
        Me.txtSwingClearance_DesignSingleLug.ApplyIFLColor = True
        Me.txtSwingClearance_DesignSingleLug.AssociateLabel = Nothing
        Me.txtSwingClearance_DesignSingleLug.DecimalValue = 2
        Me.txtSwingClearance_DesignSingleLug.IFLDataTag = Nothing
        Me.txtSwingClearance_DesignSingleLug.InvalidInputCharacters = ""
        Me.txtSwingClearance_DesignSingleLug.IsAllowNegative = False
        Me.txtSwingClearance_DesignSingleLug.LengthValue = 6
        Me.txtSwingClearance_DesignSingleLug.Location = New System.Drawing.Point(324, 95)
        Me.txtSwingClearance_DesignSingleLug.MaximumValue = 99999
        Me.txtSwingClearance_DesignSingleLug.MaxLength = 6
        Me.txtSwingClearance_DesignSingleLug.MinimumValue = 0
        Me.txtSwingClearance_DesignSingleLug.Name = "txtSwingClearance_DesignSingleLug"
        Me.txtSwingClearance_DesignSingleLug.Size = New System.Drawing.Size(66, 20)
        Me.txtSwingClearance_DesignSingleLug.StatusMessage = ""
        Me.txtSwingClearance_DesignSingleLug.StatusObject = Nothing
        Me.txtSwingClearance_DesignSingleLug.TabIndex = 148
        Me.txtSwingClearance_DesignSingleLug.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'txtPinHoleSize_DesignSingleLug
        '
        Me.txtPinHoleSize_DesignSingleLug.AcceptEnterKeyAsTab = True
        Me.txtPinHoleSize_DesignSingleLug.ApplyIFLColor = True
        Me.txtPinHoleSize_DesignSingleLug.AssociateLabel = Nothing
        Me.txtPinHoleSize_DesignSingleLug.DecimalValue = 2
        Me.txtPinHoleSize_DesignSingleLug.IFLDataTag = Nothing
        Me.txtPinHoleSize_DesignSingleLug.InvalidInputCharacters = ""
        Me.txtPinHoleSize_DesignSingleLug.IsAllowNegative = False
        Me.txtPinHoleSize_DesignSingleLug.LengthValue = 6
        Me.txtPinHoleSize_DesignSingleLug.Location = New System.Drawing.Point(324, 68)
        Me.txtPinHoleSize_DesignSingleLug.MaximumValue = 99999
        Me.txtPinHoleSize_DesignSingleLug.MaxLength = 6
        Me.txtPinHoleSize_DesignSingleLug.MinimumValue = 0
        Me.txtPinHoleSize_DesignSingleLug.Name = "txtPinHoleSize_DesignSingleLug"
        Me.txtPinHoleSize_DesignSingleLug.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleSize_DesignSingleLug.StatusMessage = ""
        Me.txtPinHoleSize_DesignSingleLug.StatusObject = Nothing
        Me.txtPinHoleSize_DesignSingleLug.TabIndex = 146
        Me.txtPinHoleSize_DesignSingleLug.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(516, 453)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 157
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grbPlateClevis
        '
        Me.grbPlateClevis.Controls.Add(Me.btnPlateClevis)
        Me.grbPlateClevis.Controls.Add(Me.UcBrowsePlateClevis1)
        Me.grbPlateClevis.Location = New System.Drawing.Point(32, 8)
        Me.grbPlateClevis.Name = "grbPlateClevis"
        Me.grbPlateClevis.Size = New System.Drawing.Size(559, 95)
        Me.grbPlateClevis.TabIndex = 158
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
        'frmFabricatedSingleLug_RetractedLength2
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
        Me.Name = "frmFabricatedSingleLug_RetractedLength2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmFabricatedSingleLug_RetractedLength"
        Me.grbMatchedSingleLugNotFound.ResumeLayout(False)
        Me.pnlSafetyFactor_Weight_LugThickness.ResumeLayout(False)
        Me.pnlDesignSingleLug.ResumeLayout(False)
        Me.pnlDesignSingleLug.PerformLayout()
        CType(Me.trbSafetyFactor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbPlateClevis.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbMatchedSingleLugNotFound As System.Windows.Forms.GroupBox
    Friend WithEvents pnlSafetyFactor_Weight_LugThickness As System.Windows.Forms.Panel
    Friend WithEvents lvwSafetyFactor_Weight As Monarch_WeldedCylinder_01_09_09.clsListViewMIL
    Friend WithEvents lblSafetyFactorIndex As LabelGradient.LabelGradient
    Friend WithEvents pnlDesignSingleLug As System.Windows.Forms.Panel
    Friend WithEvents txtSafetyFactor_DesignSingleLug As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblSafetyFactor As System.Windows.Forms.Label
    Friend WithEvents trbSafetyFactor As System.Windows.Forms.TrackBar
    Friend WithEvents txtLugThickness_DesignSingleLug As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblDesignNewCasting As LabelGradient.LabelGradient
    Friend WithEvents btnAccept As System.Windows.Forms.Button
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents lblLugWidth2 As System.Windows.Forms.Label
    Friend WithEvents txtLugWidth_DesignSingleLug As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtSwingClearance_DesignSingleLug As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSwingClearance2 As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleSize_DesignSingleLug As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelGradient2 As LabelGradient.LabelGradient
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents chkOptimizer As System.Windows.Forms.CheckBox
    Friend WithEvents grbPlateClevis As System.Windows.Forms.GroupBox
    Friend WithEvents UcBrowsePlateClevis1 As Monarch_WeldedCylinder_01_09_09.ucBrowsePlateClevis
    Friend WithEvents btnPlateClevis As System.Windows.Forms.Button
End Class
