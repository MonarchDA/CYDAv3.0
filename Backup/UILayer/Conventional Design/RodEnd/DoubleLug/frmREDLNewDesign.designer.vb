<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREDLNewDesign
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
        Me.pnlLathe_ExistingDetails = New System.Windows.Forms.Panel
        Me.grbNewDesign = New System.Windows.Forms.GroupBox
        Me.pnlGeneratedDesignProperties_NewDesign = New System.Windows.Forms.Panel
        Me.lvwDesignULug_NewDesign = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL
        Me.LabelGradient8 = New LabelGradient.LabelGradient
        Me.pnlNewDesignDetails = New System.Windows.Forms.Panel
        Me.txtSafetyFactor_NewDesign = New IFLCustomUILayer.IFLNumericBox
        Me.lblLugThickness_NewDesign = New System.Windows.Forms.Label
        Me.lblSafetyFactor_NewDesign = New System.Windows.Forms.Label
        Me.trbSafetyFactor_NewDesign = New System.Windows.Forms.TrackBar
        Me.txtLugThickness_NewDesign = New IFLCustomUILayer.IFLNumericBox
        Me.lblContentName = New LabelGradient.LabelGradient
        Me.btnGenerate_NewDesign = New System.Windows.Forms.Button
        Me.lblLugWidth_NewDesign = New System.Windows.Forms.Label
        Me.txtLugWidth_NewDesign = New IFLCustomUILayer.IFLNumericBox
        Me.txtSwingClearance_NewDesign = New IFLCustomUILayer.IFLNumericBox
        Me.lblSwingClearance_NewDesign = New System.Windows.Forms.Label
        Me.txtPinHoleSize_NewDesign = New IFLCustomUILayer.IFLNumericBox
        Me.lblPinHoleSize_NewDesign = New System.Windows.Forms.Label
        Me.lblLugGap_NewDesign = New System.Windows.Forms.Label
        Me.txtLugGap_NewDesign = New IFLCustomUILayer.IFLNumericBox
        Me.lblNewDesign = New LabelGradient.LabelGradient
        Me.btnAccept_NewDesign = New System.Windows.Forms.Button
        Me.LabelGradient6 = New LabelGradient.LabelGradient
        Me.grbCalculatedWeldSize = New System.Windows.Forms.GroupBox
        Me.btnTesting = New System.Windows.Forms.Button
        Me.pnlHigh_LowVolumeProduct = New System.Windows.Forms.Panel
        Me.rdbLowVolumeProduct = New System.Windows.Forms.RadioButton
        Me.rdbHighVolumeProduct = New System.Windows.Forms.RadioButton
        Me.pnlDesignULugLathe_DoubleLugCasting = New System.Windows.Forms.Panel
        Me.rdbDesignDoubleLugCasting = New System.Windows.Forms.RadioButton
        Me.rdbDesignULugLathe = New System.Windows.Forms.RadioButton
        Me.pnlLathe_ExistingDetails.SuspendLayout()
        Me.grbNewDesign.SuspendLayout()
        Me.pnlGeneratedDesignProperties_NewDesign.SuspendLayout()
        Me.pnlNewDesignDetails.SuspendLayout()
        CType(Me.trbSafetyFactor_NewDesign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbCalculatedWeldSize.SuspendLayout()
        Me.pnlHigh_LowVolumeProduct.SuspendLayout()
        Me.pnlDesignULugLathe_DoubleLugCasting.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlLathe_ExistingDetails
        '
        Me.pnlLathe_ExistingDetails.AutoScroll = True
        Me.pnlLathe_ExistingDetails.Controls.Add(Me.grbNewDesign)
        Me.pnlLathe_ExistingDetails.Controls.Add(Me.LabelGradient6)
        Me.pnlLathe_ExistingDetails.Controls.Add(Me.grbCalculatedWeldSize)
        Me.pnlLathe_ExistingDetails.Location = New System.Drawing.Point(11, 88)
        Me.pnlLathe_ExistingDetails.Name = "pnlLathe_ExistingDetails"
        Me.pnlLathe_ExistingDetails.Size = New System.Drawing.Size(912, 463)
        Me.pnlLathe_ExistingDetails.TabIndex = 1
        '
        'grbNewDesign
        '
        Me.grbNewDesign.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.grbNewDesign.BackColor = System.Drawing.Color.Ivory
        Me.grbNewDesign.Controls.Add(Me.pnlGeneratedDesignProperties_NewDesign)
        Me.grbNewDesign.Controls.Add(Me.pnlNewDesignDetails)
        Me.grbNewDesign.Controls.Add(Me.lblNewDesign)
        Me.grbNewDesign.Controls.Add(Me.btnAccept_NewDesign)
        Me.grbNewDesign.Location = New System.Drawing.Point(18, 58)
        Me.grbNewDesign.Name = "grbNewDesign"
        Me.grbNewDesign.Size = New System.Drawing.Size(543, 348)
        Me.grbNewDesign.TabIndex = 126
        Me.grbNewDesign.TabStop = False
        '
        'pnlGeneratedDesignProperties_NewDesign
        '
        Me.pnlGeneratedDesignProperties_NewDesign.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlGeneratedDesignProperties_NewDesign.Controls.Add(Me.lvwDesignULug_NewDesign)
        Me.pnlGeneratedDesignProperties_NewDesign.Controls.Add(Me.LabelGradient8)
        Me.pnlGeneratedDesignProperties_NewDesign.Location = New System.Drawing.Point(50, 200)
        Me.pnlGeneratedDesignProperties_NewDesign.Name = "pnlGeneratedDesignProperties_NewDesign"
        Me.pnlGeneratedDesignProperties_NewDesign.Size = New System.Drawing.Size(445, 108)
        Me.pnlGeneratedDesignProperties_NewDesign.TabIndex = 152
        '
        'lvwDesignULug_NewDesign
        '
        Me.lvwDesignULug_NewDesign.GridLines = True
        Me.lvwDesignULug_NewDesign.Location = New System.Drawing.Point(25, 22)
        Me.lvwDesignULug_NewDesign.Name = "lvwDesignULug_NewDesign"
        Me.lvwDesignULug_NewDesign.Size = New System.Drawing.Size(390, 76)
        Me.lvwDesignULug_NewDesign.TabIndex = 13
        Me.lvwDesignULug_NewDesign.UseCompatibleStateImageBehavior = False
        Me.lvwDesignULug_NewDesign.View = System.Windows.Forms.View.Details
        '
        'LabelGradient8
        '
        Me.LabelGradient8.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient8.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelGradient8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient8.GradientColorOne = System.Drawing.Color.Olive
        Me.LabelGradient8.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient8.Location = New System.Drawing.Point(0, 0)
        Me.LabelGradient8.Name = "LabelGradient8"
        Me.LabelGradient8.Size = New System.Drawing.Size(441, 19)
        Me.LabelGradient8.TabIndex = 159
        Me.LabelGradient8.Text = "Generated Design Properties"
        Me.LabelGradient8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlNewDesignDetails
        '
        Me.pnlNewDesignDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlNewDesignDetails.Controls.Add(Me.txtSafetyFactor_NewDesign)
        Me.pnlNewDesignDetails.Controls.Add(Me.lblLugThickness_NewDesign)
        Me.pnlNewDesignDetails.Controls.Add(Me.lblSafetyFactor_NewDesign)
        Me.pnlNewDesignDetails.Controls.Add(Me.trbSafetyFactor_NewDesign)
        Me.pnlNewDesignDetails.Controls.Add(Me.txtLugThickness_NewDesign)
        Me.pnlNewDesignDetails.Controls.Add(Me.lblContentName)
        Me.pnlNewDesignDetails.Controls.Add(Me.btnGenerate_NewDesign)
        Me.pnlNewDesignDetails.Controls.Add(Me.lblLugWidth_NewDesign)
        Me.pnlNewDesignDetails.Controls.Add(Me.txtLugWidth_NewDesign)
        Me.pnlNewDesignDetails.Controls.Add(Me.txtSwingClearance_NewDesign)
        Me.pnlNewDesignDetails.Controls.Add(Me.lblSwingClearance_NewDesign)
        Me.pnlNewDesignDetails.Controls.Add(Me.txtPinHoleSize_NewDesign)
        Me.pnlNewDesignDetails.Controls.Add(Me.lblPinHoleSize_NewDesign)
        Me.pnlNewDesignDetails.Controls.Add(Me.lblLugGap_NewDesign)
        Me.pnlNewDesignDetails.Controls.Add(Me.txtLugGap_NewDesign)
        Me.pnlNewDesignDetails.Location = New System.Drawing.Point(50, 23)
        Me.pnlNewDesignDetails.Name = "pnlNewDesignDetails"
        Me.pnlNewDesignDetails.Size = New System.Drawing.Size(445, 171)
        Me.pnlNewDesignDetails.TabIndex = 151
        '
        'txtSafetyFactor_NewDesign
        '
        Me.txtSafetyFactor_NewDesign.AcceptEnterKeyAsTab = True
        Me.txtSafetyFactor_NewDesign.ApplyIFLColor = True
        Me.txtSafetyFactor_NewDesign.AssociateLabel = Nothing
        Me.txtSafetyFactor_NewDesign.DecimalValue = 2
        Me.txtSafetyFactor_NewDesign.IFLDataTag = Nothing
        Me.txtSafetyFactor_NewDesign.InvalidInputCharacters = ""
        Me.txtSafetyFactor_NewDesign.IsAllowNegative = False
        Me.txtSafetyFactor_NewDesign.LengthValue = 6
        Me.txtSafetyFactor_NewDesign.Location = New System.Drawing.Point(373, 38)
        Me.txtSafetyFactor_NewDesign.MaximumValue = 99999
        Me.txtSafetyFactor_NewDesign.MaxLength = 6
        Me.txtSafetyFactor_NewDesign.MinimumValue = 0
        Me.txtSafetyFactor_NewDesign.Name = "txtSafetyFactor_NewDesign"
        Me.txtSafetyFactor_NewDesign.Size = New System.Drawing.Size(40, 20)
        Me.txtSafetyFactor_NewDesign.StatusMessage = ""
        Me.txtSafetyFactor_NewDesign.StatusObject = Nothing
        Me.txtSafetyFactor_NewDesign.TabIndex = 6
        Me.txtSafetyFactor_NewDesign.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLugThickness_NewDesign
        '
        Me.lblLugThickness_NewDesign.AutoSize = True
        Me.lblLugThickness_NewDesign.Location = New System.Drawing.Point(52, 116)
        Me.lblLugThickness_NewDesign.Name = "lblLugThickness_NewDesign"
        Me.lblLugThickness_NewDesign.Size = New System.Drawing.Size(77, 13)
        Me.lblLugThickness_NewDesign.TabIndex = 155
        Me.lblLugThickness_NewDesign.Text = "Lug Thickness"
        '
        'lblSafetyFactor_NewDesign
        '
        Me.lblSafetyFactor_NewDesign.AutoSize = True
        Me.lblSafetyFactor_NewDesign.Location = New System.Drawing.Point(25, 41)
        Me.lblSafetyFactor_NewDesign.Name = "lblSafetyFactor_NewDesign"
        Me.lblSafetyFactor_NewDesign.Size = New System.Drawing.Size(70, 13)
        Me.lblSafetyFactor_NewDesign.TabIndex = 153
        Me.lblSafetyFactor_NewDesign.Text = "Safety Factor"
        '
        'trbSafetyFactor_NewDesign
        '
        Me.trbSafetyFactor_NewDesign.LargeChange = 1
        Me.trbSafetyFactor_NewDesign.Location = New System.Drawing.Point(101, 29)
        Me.trbSafetyFactor_NewDesign.Maximum = 20
        Me.trbSafetyFactor_NewDesign.Minimum = 2
        Me.trbSafetyFactor_NewDesign.Name = "trbSafetyFactor_NewDesign"
        Me.trbSafetyFactor_NewDesign.Size = New System.Drawing.Size(266, 45)
        Me.trbSafetyFactor_NewDesign.TabIndex = 5
        Me.trbSafetyFactor_NewDesign.Value = 2
        '
        'txtLugThickness_NewDesign
        '
        Me.txtLugThickness_NewDesign.AcceptEnterKeyAsTab = True
        Me.txtLugThickness_NewDesign.ApplyIFLColor = True
        Me.txtLugThickness_NewDesign.AssociateLabel = Nothing
        Me.txtLugThickness_NewDesign.DecimalValue = 2
        Me.txtLugThickness_NewDesign.IFLDataTag = Nothing
        Me.txtLugThickness_NewDesign.InvalidInputCharacters = ""
        Me.txtLugThickness_NewDesign.IsAllowNegative = False
        Me.txtLugThickness_NewDesign.LengthValue = 6
        Me.txtLugThickness_NewDesign.Location = New System.Drawing.Point(135, 113)
        Me.txtLugThickness_NewDesign.MaximumValue = 99999
        Me.txtLugThickness_NewDesign.MaxLength = 6
        Me.txtLugThickness_NewDesign.MinimumValue = 0
        Me.txtLugThickness_NewDesign.Name = "txtLugThickness_NewDesign"
        Me.txtLugThickness_NewDesign.Size = New System.Drawing.Size(66, 20)
        Me.txtLugThickness_NewDesign.StatusMessage = ""
        Me.txtLugThickness_NewDesign.StatusObject = Nothing
        Me.txtLugThickness_NewDesign.TabIndex = 8
        Me.txtLugThickness_NewDesign.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblContentName
        '
        Me.lblContentName.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblContentName.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblContentName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContentName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblContentName.GradientColorOne = System.Drawing.Color.Olive
        Me.lblContentName.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblContentName.Location = New System.Drawing.Point(0, 0)
        Me.lblContentName.Name = "lblContentName"
        Me.lblContentName.Size = New System.Drawing.Size(441, 19)
        Me.lblContentName.TabIndex = 141
        Me.lblContentName.Text = "Design ULug Manual"
        Me.lblContentName.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnGenerate_NewDesign
        '
        Me.btnGenerate_NewDesign.Location = New System.Drawing.Point(234, 137)
        Me.btnGenerate_NewDesign.Name = "btnGenerate_NewDesign"
        Me.btnGenerate_NewDesign.Size = New System.Drawing.Size(133, 23)
        Me.btnGenerate_NewDesign.TabIndex = 12
        Me.btnGenerate_NewDesign.Text = "Generate"
        Me.btnGenerate_NewDesign.UseVisualStyleBackColor = True
        '
        'lblLugWidth_NewDesign
        '
        Me.lblLugWidth_NewDesign.AutoSize = True
        Me.lblLugWidth_NewDesign.Location = New System.Drawing.Point(52, 143)
        Me.lblLugWidth_NewDesign.Name = "lblLugWidth_NewDesign"
        Me.lblLugWidth_NewDesign.Size = New System.Drawing.Size(56, 13)
        Me.lblLugWidth_NewDesign.TabIndex = 143
        Me.lblLugWidth_NewDesign.Text = "Lug Width"
        '
        'txtLugWidth_NewDesign
        '
        Me.txtLugWidth_NewDesign.AcceptEnterKeyAsTab = True
        Me.txtLugWidth_NewDesign.ApplyIFLColor = True
        Me.txtLugWidth_NewDesign.AssociateLabel = Nothing
        Me.txtLugWidth_NewDesign.DecimalValue = 2
        Me.txtLugWidth_NewDesign.IFLDataTag = Nothing
        Me.txtLugWidth_NewDesign.InvalidInputCharacters = ""
        Me.txtLugWidth_NewDesign.IsAllowNegative = False
        Me.txtLugWidth_NewDesign.LengthValue = 6
        Me.txtLugWidth_NewDesign.Location = New System.Drawing.Point(135, 140)
        Me.txtLugWidth_NewDesign.MaximumValue = 99999
        Me.txtLugWidth_NewDesign.MaxLength = 6
        Me.txtLugWidth_NewDesign.MinimumValue = 0
        Me.txtLugWidth_NewDesign.Name = "txtLugWidth_NewDesign"
        Me.txtLugWidth_NewDesign.Size = New System.Drawing.Size(66, 20)
        Me.txtLugWidth_NewDesign.StatusMessage = ""
        Me.txtLugWidth_NewDesign.StatusObject = Nothing
        Me.txtLugWidth_NewDesign.TabIndex = 9
        Me.txtLugWidth_NewDesign.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSwingClearance_NewDesign
        '
        Me.txtSwingClearance_NewDesign.AcceptEnterKeyAsTab = True
        Me.txtSwingClearance_NewDesign.ApplyIFLColor = True
        Me.txtSwingClearance_NewDesign.AssociateLabel = Nothing
        Me.txtSwingClearance_NewDesign.DecimalValue = 2
        Me.txtSwingClearance_NewDesign.IFLDataTag = Nothing
        Me.txtSwingClearance_NewDesign.InvalidInputCharacters = ""
        Me.txtSwingClearance_NewDesign.IsAllowNegative = False
        Me.txtSwingClearance_NewDesign.LengthValue = 6
        Me.txtSwingClearance_NewDesign.Location = New System.Drawing.Point(322, 113)
        Me.txtSwingClearance_NewDesign.MaximumValue = 99999
        Me.txtSwingClearance_NewDesign.MaxLength = 6
        Me.txtSwingClearance_NewDesign.MinimumValue = 0
        Me.txtSwingClearance_NewDesign.Name = "txtSwingClearance_NewDesign"
        Me.txtSwingClearance_NewDesign.Size = New System.Drawing.Size(66, 20)
        Me.txtSwingClearance_NewDesign.StatusMessage = ""
        Me.txtSwingClearance_NewDesign.StatusObject = Nothing
        Me.txtSwingClearance_NewDesign.TabIndex = 11
        Me.txtSwingClearance_NewDesign.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSwingClearance_NewDesign
        '
        Me.lblSwingClearance_NewDesign.AutoSize = True
        Me.lblSwingClearance_NewDesign.Location = New System.Drawing.Point(231, 116)
        Me.lblSwingClearance_NewDesign.Name = "lblSwingClearance_NewDesign"
        Me.lblSwingClearance_NewDesign.Size = New System.Drawing.Size(87, 13)
        Me.lblSwingClearance_NewDesign.TabIndex = 149
        Me.lblSwingClearance_NewDesign.Text = "Swing Clearance"
        '
        'txtPinHoleSize_NewDesign
        '
        Me.txtPinHoleSize_NewDesign.AcceptEnterKeyAsTab = True
        Me.txtPinHoleSize_NewDesign.ApplyIFLColor = True
        Me.txtPinHoleSize_NewDesign.AssociateLabel = Nothing
        Me.txtPinHoleSize_NewDesign.DecimalValue = 2
        Me.txtPinHoleSize_NewDesign.IFLDataTag = Nothing
        Me.txtPinHoleSize_NewDesign.InvalidInputCharacters = ""
        Me.txtPinHoleSize_NewDesign.IsAllowNegative = False
        Me.txtPinHoleSize_NewDesign.LengthValue = 6
        Me.txtPinHoleSize_NewDesign.Location = New System.Drawing.Point(322, 86)
        Me.txtPinHoleSize_NewDesign.MaximumValue = 99999
        Me.txtPinHoleSize_NewDesign.MaxLength = 6
        Me.txtPinHoleSize_NewDesign.MinimumValue = 0
        Me.txtPinHoleSize_NewDesign.Name = "txtPinHoleSize_NewDesign"
        Me.txtPinHoleSize_NewDesign.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleSize_NewDesign.StatusMessage = ""
        Me.txtPinHoleSize_NewDesign.StatusObject = Nothing
        Me.txtPinHoleSize_NewDesign.TabIndex = 10
        Me.txtPinHoleSize_NewDesign.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPinHoleSize_NewDesign
        '
        Me.lblPinHoleSize_NewDesign.AutoSize = True
        Me.lblPinHoleSize_NewDesign.Location = New System.Drawing.Point(231, 89)
        Me.lblPinHoleSize_NewDesign.Name = "lblPinHoleSize_NewDesign"
        Me.lblPinHoleSize_NewDesign.Size = New System.Drawing.Size(70, 13)
        Me.lblPinHoleSize_NewDesign.TabIndex = 147
        Me.lblPinHoleSize_NewDesign.Text = "Pin Hole Size"
        '
        'lblLugGap_NewDesign
        '
        Me.lblLugGap_NewDesign.AutoSize = True
        Me.lblLugGap_NewDesign.Location = New System.Drawing.Point(52, 89)
        Me.lblLugGap_NewDesign.Name = "lblLugGap_NewDesign"
        Me.lblLugGap_NewDesign.Size = New System.Drawing.Size(48, 13)
        Me.lblLugGap_NewDesign.TabIndex = 145
        Me.lblLugGap_NewDesign.Text = "Lug Gap"
        '
        'txtLugGap_NewDesign
        '
        Me.txtLugGap_NewDesign.AcceptEnterKeyAsTab = True
        Me.txtLugGap_NewDesign.ApplyIFLColor = True
        Me.txtLugGap_NewDesign.AssociateLabel = Nothing
        Me.txtLugGap_NewDesign.DecimalValue = 2
        Me.txtLugGap_NewDesign.IFLDataTag = Nothing
        Me.txtLugGap_NewDesign.InvalidInputCharacters = ""
        Me.txtLugGap_NewDesign.IsAllowNegative = False
        Me.txtLugGap_NewDesign.LengthValue = 6
        Me.txtLugGap_NewDesign.Location = New System.Drawing.Point(135, 86)
        Me.txtLugGap_NewDesign.MaximumValue = 99999
        Me.txtLugGap_NewDesign.MaxLength = 6
        Me.txtLugGap_NewDesign.MinimumValue = 0
        Me.txtLugGap_NewDesign.Name = "txtLugGap_NewDesign"
        Me.txtLugGap_NewDesign.Size = New System.Drawing.Size(66, 20)
        Me.txtLugGap_NewDesign.StatusMessage = ""
        Me.txtLugGap_NewDesign.StatusObject = Nothing
        Me.txtLugGap_NewDesign.TabIndex = 7
        Me.txtLugGap_NewDesign.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNewDesign
        '
        Me.lblNewDesign.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblNewDesign.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewDesign.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNewDesign.GradientColorOne = System.Drawing.Color.Olive
        Me.lblNewDesign.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblNewDesign.Location = New System.Drawing.Point(-2, 0)
        Me.lblNewDesign.Name = "lblNewDesign"
        Me.lblNewDesign.Size = New System.Drawing.Size(545, 19)
        Me.lblNewDesign.TabIndex = 111
        Me.lblNewDesign.Text = "New Design"
        Me.lblNewDesign.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAccept_NewDesign
        '
        Me.btnAccept_NewDesign.Location = New System.Drawing.Point(286, 314)
        Me.btnAccept_NewDesign.Name = "btnAccept_NewDesign"
        Me.btnAccept_NewDesign.Size = New System.Drawing.Size(133, 23)
        Me.btnAccept_NewDesign.TabIndex = 14
        Me.btnAccept_NewDesign.Text = "Accept"
        Me.btnAccept_NewDesign.UseVisualStyleBackColor = True
        '
        'LabelGradient6
        '
        Me.LabelGradient6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LabelGradient6.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient6.GradientColorOne = System.Drawing.Color.DarkGoldenrod
        Me.LabelGradient6.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient6.Location = New System.Drawing.Point(3, 41)
        Me.LabelGradient6.Name = "LabelGradient6"
        Me.LabelGradient6.Size = New System.Drawing.Size(578, 374)
        Me.LabelGradient6.TabIndex = 125
        Me.LabelGradient6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grbCalculatedWeldSize
        '
        Me.grbCalculatedWeldSize.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.grbCalculatedWeldSize.BackColor = System.Drawing.Color.Ivory
        Me.grbCalculatedWeldSize.Controls.Add(Me.btnTesting)
        Me.grbCalculatedWeldSize.Location = New System.Drawing.Point(12, 52)
        Me.grbCalculatedWeldSize.Name = "grbCalculatedWeldSize"
        Me.grbCalculatedWeldSize.Size = New System.Drawing.Size(543, 348)
        Me.grbCalculatedWeldSize.TabIndex = 153
        Me.grbCalculatedWeldSize.TabStop = False
        '
        'btnTesting
        '
        Me.btnTesting.Location = New System.Drawing.Point(19, 120)
        Me.btnTesting.Name = "btnTesting"
        Me.btnTesting.Size = New System.Drawing.Size(504, 86)
        Me.btnTesting.TabIndex = 153
        Me.btnTesting.Text = "Calculated Weld Size is more than Existing weld Size. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "so please change Rod Diam" & _
            "ter input.  " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click Next button to go to Primary inputs screen."
        Me.btnTesting.UseVisualStyleBackColor = True
        '
        'pnlHigh_LowVolumeProduct
        '
        Me.pnlHigh_LowVolumeProduct.AutoScroll = True
        Me.pnlHigh_LowVolumeProduct.BackColor = System.Drawing.Color.Ivory
        Me.pnlHigh_LowVolumeProduct.Controls.Add(Me.rdbLowVolumeProduct)
        Me.pnlHigh_LowVolumeProduct.Controls.Add(Me.rdbHighVolumeProduct)
        Me.pnlHigh_LowVolumeProduct.Location = New System.Drawing.Point(140, 2)
        Me.pnlHigh_LowVolumeProduct.Name = "pnlHigh_LowVolumeProduct"
        Me.pnlHigh_LowVolumeProduct.Size = New System.Drawing.Size(308, 37)
        Me.pnlHigh_LowVolumeProduct.TabIndex = 1
        '
        'rdbLowVolumeProduct
        '
        Me.rdbLowVolumeProduct.AutoSize = True
        Me.rdbLowVolumeProduct.Location = New System.Drawing.Point(19, 10)
        Me.rdbLowVolumeProduct.Name = "rdbLowVolumeProduct"
        Me.rdbLowVolumeProduct.Size = New System.Drawing.Size(123, 17)
        Me.rdbLowVolumeProduct.TabIndex = 1
        Me.rdbLowVolumeProduct.TabStop = True
        Me.rdbLowVolumeProduct.Text = "Low Volume Product"
        Me.rdbLowVolumeProduct.UseVisualStyleBackColor = True
        '
        'rdbHighVolumeProduct
        '
        Me.rdbHighVolumeProduct.AutoSize = True
        Me.rdbHighVolumeProduct.Location = New System.Drawing.Point(148, 10)
        Me.rdbHighVolumeProduct.Name = "rdbHighVolumeProduct"
        Me.rdbHighVolumeProduct.Size = New System.Drawing.Size(125, 17)
        Me.rdbHighVolumeProduct.TabIndex = 2
        Me.rdbHighVolumeProduct.TabStop = True
        Me.rdbHighVolumeProduct.Text = "High Volume Product"
        Me.rdbHighVolumeProduct.UseVisualStyleBackColor = True
        '
        'pnlDesignULugLathe_DoubleLugCasting
        '
        Me.pnlDesignULugLathe_DoubleLugCasting.AutoScroll = True
        Me.pnlDesignULugLathe_DoubleLugCasting.BackColor = System.Drawing.Color.Ivory
        Me.pnlDesignULugLathe_DoubleLugCasting.Controls.Add(Me.rdbDesignDoubleLugCasting)
        Me.pnlDesignULugLathe_DoubleLugCasting.Controls.Add(Me.rdbDesignULugLathe)
        Me.pnlDesignULugLathe_DoubleLugCasting.Location = New System.Drawing.Point(140, 45)
        Me.pnlDesignULugLathe_DoubleLugCasting.Name = "pnlDesignULugLathe_DoubleLugCasting"
        Me.pnlDesignULugLathe_DoubleLugCasting.Size = New System.Drawing.Size(308, 37)
        Me.pnlDesignULugLathe_DoubleLugCasting.TabIndex = 2
        '
        'rdbDesignDoubleLugCasting
        '
        Me.rdbDesignDoubleLugCasting.AutoSize = True
        Me.rdbDesignDoubleLugCasting.Location = New System.Drawing.Point(148, 10)
        Me.rdbDesignDoubleLugCasting.Name = "rdbDesignDoubleLugCasting"
        Me.rdbDesignDoubleLugCasting.Size = New System.Drawing.Size(154, 17)
        Me.rdbDesignDoubleLugCasting.TabIndex = 4
        Me.rdbDesignDoubleLugCasting.TabStop = True
        Me.rdbDesignDoubleLugCasting.Text = "Design Double Lug Casting"
        Me.rdbDesignDoubleLugCasting.UseVisualStyleBackColor = True
        '
        'rdbDesignULugLathe
        '
        Me.rdbDesignULugLathe.AutoSize = True
        Me.rdbDesignULugLathe.Location = New System.Drawing.Point(20, 10)
        Me.rdbDesignULugLathe.Name = "rdbDesignULugLathe"
        Me.rdbDesignULugLathe.Size = New System.Drawing.Size(117, 17)
        Me.rdbDesignULugLathe.TabIndex = 3
        Me.rdbDesignULugLathe.TabStop = True
        Me.rdbDesignULugLathe.Text = "Design ULug Lathe"
        Me.rdbDesignULugLathe.UseVisualStyleBackColor = True
        '
        'frmREDLNewDesign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1200, 900)
        Me.Controls.Add(Me.pnlDesignULugLathe_DoubleLugCasting)
        Me.Controls.Add(Me.pnlHigh_LowVolumeProduct)
        Me.Controls.Add(Me.pnlLathe_ExistingDetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmREDLNewDesign"
        Me.Text = "frmREDLNewDesign"
        Me.pnlLathe_ExistingDetails.ResumeLayout(False)
        Me.grbNewDesign.ResumeLayout(False)
        Me.pnlGeneratedDesignProperties_NewDesign.ResumeLayout(False)
        Me.pnlNewDesignDetails.ResumeLayout(False)
        Me.pnlNewDesignDetails.PerformLayout()
        CType(Me.trbSafetyFactor_NewDesign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbCalculatedWeldSize.ResumeLayout(False)
        Me.pnlHigh_LowVolumeProduct.ResumeLayout(False)
        Me.pnlHigh_LowVolumeProduct.PerformLayout()
        Me.pnlDesignULugLathe_DoubleLugCasting.ResumeLayout(False)
        Me.pnlDesignULugLathe_DoubleLugCasting.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlLathe_ExistingDetails As System.Windows.Forms.Panel
    Friend WithEvents pnlHigh_LowVolumeProduct As System.Windows.Forms.Panel
    Friend WithEvents rdbLowVolumeProduct As System.Windows.Forms.RadioButton
    Friend WithEvents rdbHighVolumeProduct As System.Windows.Forms.RadioButton
    Friend WithEvents pnlDesignULugLathe_DoubleLugCasting As System.Windows.Forms.Panel
    Friend WithEvents rdbDesignDoubleLugCasting As System.Windows.Forms.RadioButton
    Friend WithEvents rdbDesignULugLathe As System.Windows.Forms.RadioButton
    Friend WithEvents LabelGradient6 As LabelGradient.LabelGradient
    Friend WithEvents grbNewDesign As System.Windows.Forms.GroupBox
    Friend WithEvents pnlGeneratedDesignProperties_NewDesign As System.Windows.Forms.Panel
    Friend WithEvents lvwDesignULug_NewDesign As Monarch_WeldedCylinder_01_09_09.clsListViewMIL
    Friend WithEvents LabelGradient8 As LabelGradient.LabelGradient
    Friend WithEvents pnlNewDesignDetails As System.Windows.Forms.Panel
    Friend WithEvents txtSafetyFactor_NewDesign As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblLugThickness_NewDesign As System.Windows.Forms.Label
    Friend WithEvents lblSafetyFactor_NewDesign As System.Windows.Forms.Label
    Friend WithEvents trbSafetyFactor_NewDesign As System.Windows.Forms.TrackBar
    Friend WithEvents txtLugThickness_NewDesign As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblContentName As LabelGradient.LabelGradient
    Friend WithEvents btnAccept_NewDesign As System.Windows.Forms.Button
    Friend WithEvents btnGenerate_NewDesign As System.Windows.Forms.Button
    Friend WithEvents lblLugWidth_NewDesign As System.Windows.Forms.Label
    Friend WithEvents txtLugWidth_NewDesign As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtSwingClearance_NewDesign As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSwingClearance_NewDesign As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleSize_NewDesign As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblPinHoleSize_NewDesign As System.Windows.Forms.Label
    Friend WithEvents lblLugGap_NewDesign As System.Windows.Forms.Label
    Friend WithEvents txtLugGap_NewDesign As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblNewDesign As LabelGradient.LabelGradient
    Friend WithEvents btnTesting As System.Windows.Forms.Button
    Friend WithEvents grbCalculatedWeldSize As System.Windows.Forms.GroupBox
End Class
