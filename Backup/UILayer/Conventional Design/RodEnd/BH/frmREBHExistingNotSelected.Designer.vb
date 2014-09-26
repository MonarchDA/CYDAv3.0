<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREBHExistingNotSelected
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblBHHeading = New LabelGradient.LabelGradient
        Me.LabelGradient3 = New LabelGradient.LabelGradient
        Me.LabelGradient2 = New LabelGradient.LabelGradient
        Me.pnlMatchingBHNotFound = New System.Windows.Forms.Panel
        Me.grbMatchedBHNotFound_RodEnd = New System.Windows.Forms.GroupBox
        Me.pnlSafetyFactor_Weight_LugThickness_RodEnd = New System.Windows.Forms.Panel
        Me.lblSafetyFactorIndex = New LabelGradient.LabelGradient
        Me.pnlDesignBH_RodEnd = New System.Windows.Forms.Panel
        Me.txtSafetyFactor_DesignBH_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.lblLugThicknessNewDesign_RodEnd = New System.Windows.Forms.Label
        Me.lblSafetyFactor_RodEnd = New System.Windows.Forms.Label
        Me.trbSafetyFactor_RodEnd = New System.Windows.Forms.TrackBar
        Me.txtLugThickness_DesignBH_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.lblDesignNewCasting = New LabelGradient.LabelGradient
        Me.btnGenerate_RodEnd = New System.Windows.Forms.Button
        Me.lblLugWidth_RodEnd = New System.Windows.Forms.Label
        Me.txtLugWidth_DesignBH_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.txtSwingClearance_DesignBH_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.lblSwingClearance_DesignSL_RodEnd = New System.Windows.Forms.Label
        Me.txtPinHoleSize_DesignBH_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.lblPinHoleSize_DesignBH_RodEnd = New System.Windows.Forms.Label
        Me.btnMatchedBHNotFound_RodEnd = New System.Windows.Forms.Button
        Me.LabelGradient1 = New LabelGradient.LabelGradient
        Me.btnAccept_RodEnd = New System.Windows.Forms.Button
        Me.LabelGradient5 = New LabelGradient.LabelGradient
        Me.LabelGradient4 = New LabelGradient.LabelGradient
        Me.pnlRESLMaching_YesNo = New System.Windows.Forms.Panel
        Me.lvwSafetyFactor_Weight_RodEnd = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL
        Me.pnlMatchingBHNotFound.SuspendLayout()
        Me.grbMatchedBHNotFound_RodEnd.SuspendLayout()
        Me.pnlSafetyFactor_Weight_LugThickness_RodEnd.SuspendLayout()
        Me.pnlDesignBH_RodEnd.SuspendLayout()
        CType(Me.trbSafetyFactor_RodEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlRESLMaching_YesNo.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblBHHeading
        '
        Me.lblBHHeading.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblBHHeading.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblBHHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBHHeading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBHHeading.GradientColorOne = System.Drawing.Color.Olive
        Me.lblBHHeading.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblBHHeading.Location = New System.Drawing.Point(20, 0)
        Me.lblBHHeading.Name = "lblBHHeading"
        Me.lblBHHeading.Size = New System.Drawing.Size(1158, 19)
        Me.lblBHHeading.TabIndex = 48
        Me.lblBHHeading.Text = "Rod End BH"
        Me.lblBHHeading.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.LabelGradient3.Size = New System.Drawing.Size(20, 881)
        Me.LabelGradient3.TabIndex = 46
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
        Me.LabelGradient2.Location = New System.Drawing.Point(0, 881)
        Me.LabelGradient2.Name = "LabelGradient2"
        Me.LabelGradient2.Size = New System.Drawing.Size(1178, 19)
        Me.LabelGradient2.TabIndex = 45
        Me.LabelGradient2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlMatchingBHNotFound
        '
        Me.pnlMatchingBHNotFound.BackColor = System.Drawing.Color.Black
        Me.pnlMatchingBHNotFound.Controls.Add(Me.grbMatchedBHNotFound_RodEnd)
        Me.pnlMatchingBHNotFound.Controls.Add(Me.LabelGradient5)
        Me.pnlMatchingBHNotFound.Location = New System.Drawing.Point(3, 3)
        Me.pnlMatchingBHNotFound.Name = "pnlMatchingBHNotFound"
        Me.pnlMatchingBHNotFound.Size = New System.Drawing.Size(824, 538)
        Me.pnlMatchingBHNotFound.TabIndex = 2
        '
        'grbMatchedBHNotFound_RodEnd
        '
        Me.grbMatchedBHNotFound_RodEnd.BackColor = System.Drawing.Color.Ivory
        Me.grbMatchedBHNotFound_RodEnd.Controls.Add(Me.pnlSafetyFactor_Weight_LugThickness_RodEnd)
        Me.grbMatchedBHNotFound_RodEnd.Controls.Add(Me.pnlDesignBH_RodEnd)
        Me.grbMatchedBHNotFound_RodEnd.Controls.Add(Me.btnMatchedBHNotFound_RodEnd)
        Me.grbMatchedBHNotFound_RodEnd.Controls.Add(Me.LabelGradient1)
        Me.grbMatchedBHNotFound_RodEnd.Controls.Add(Me.btnAccept_RodEnd)
        Me.grbMatchedBHNotFound_RodEnd.Location = New System.Drawing.Point(23, 20)
        Me.grbMatchedBHNotFound_RodEnd.Name = "grbMatchedBHNotFound_RodEnd"
        Me.grbMatchedBHNotFound_RodEnd.Size = New System.Drawing.Size(559, 366)
        Me.grbMatchedBHNotFound_RodEnd.TabIndex = 3
        Me.grbMatchedBHNotFound_RodEnd.TabStop = False
        '
        'pnlSafetyFactor_Weight_LugThickness_RodEnd
        '
        Me.pnlSafetyFactor_Weight_LugThickness_RodEnd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlSafetyFactor_Weight_LugThickness_RodEnd.Controls.Add(Me.lvwSafetyFactor_Weight_RodEnd)
        Me.pnlSafetyFactor_Weight_LugThickness_RodEnd.Controls.Add(Me.lblSafetyFactorIndex)
        Me.pnlSafetyFactor_Weight_LugThickness_RodEnd.Location = New System.Drawing.Point(57, 206)
        Me.pnlSafetyFactor_Weight_LugThickness_RodEnd.Name = "pnlSafetyFactor_Weight_LugThickness_RodEnd"
        Me.pnlSafetyFactor_Weight_LugThickness_RodEnd.Size = New System.Drawing.Size(445, 125)
        Me.pnlSafetyFactor_Weight_LugThickness_RodEnd.TabIndex = 13
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
        'pnlDesignBH_RodEnd
        '
        Me.pnlDesignBH_RodEnd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDesignBH_RodEnd.Controls.Add(Me.txtSafetyFactor_DesignBH_RodEnd)
        Me.pnlDesignBH_RodEnd.Controls.Add(Me.lblLugThicknessNewDesign_RodEnd)
        Me.pnlDesignBH_RodEnd.Controls.Add(Me.lblSafetyFactor_RodEnd)
        Me.pnlDesignBH_RodEnd.Controls.Add(Me.trbSafetyFactor_RodEnd)
        Me.pnlDesignBH_RodEnd.Controls.Add(Me.txtLugThickness_DesignBH_RodEnd)
        Me.pnlDesignBH_RodEnd.Controls.Add(Me.lblDesignNewCasting)
        Me.pnlDesignBH_RodEnd.Controls.Add(Me.btnGenerate_RodEnd)
        Me.pnlDesignBH_RodEnd.Controls.Add(Me.lblLugWidth_RodEnd)
        Me.pnlDesignBH_RodEnd.Controls.Add(Me.txtLugWidth_DesignBH_RodEnd)
        Me.pnlDesignBH_RodEnd.Controls.Add(Me.txtSwingClearance_DesignBH_RodEnd)
        Me.pnlDesignBH_RodEnd.Controls.Add(Me.lblSwingClearance_DesignSL_RodEnd)
        Me.pnlDesignBH_RodEnd.Controls.Add(Me.txtPinHoleSize_DesignBH_RodEnd)
        Me.pnlDesignBH_RodEnd.Controls.Add(Me.lblPinHoleSize_DesignBH_RodEnd)
        Me.pnlDesignBH_RodEnd.Location = New System.Drawing.Point(57, 52)
        Me.pnlDesignBH_RodEnd.Name = "pnlDesignBH_RodEnd"
        Me.pnlDesignBH_RodEnd.Size = New System.Drawing.Size(445, 151)
        Me.pnlDesignBH_RodEnd.TabIndex = 4
        '
        'txtSafetyFactor_DesignBH_RodEnd
        '
        Me.txtSafetyFactor_DesignBH_RodEnd.AcceptEnterKeyAsTab = True
        Me.txtSafetyFactor_DesignBH_RodEnd.ApplyIFLColor = True
        Me.txtSafetyFactor_DesignBH_RodEnd.AssociateLabel = Nothing
        Me.txtSafetyFactor_DesignBH_RodEnd.DecimalValue = 2
        Me.txtSafetyFactor_DesignBH_RodEnd.IFLDataTag = Nothing
        Me.txtSafetyFactor_DesignBH_RodEnd.InvalidInputCharacters = ""
        Me.txtSafetyFactor_DesignBH_RodEnd.IsAllowNegative = False
        Me.txtSafetyFactor_DesignBH_RodEnd.LengthValue = 6
        Me.txtSafetyFactor_DesignBH_RodEnd.Location = New System.Drawing.Point(385, 31)
        Me.txtSafetyFactor_DesignBH_RodEnd.MaximumValue = 99999
        Me.txtSafetyFactor_DesignBH_RodEnd.MaxLength = 6
        Me.txtSafetyFactor_DesignBH_RodEnd.MinimumValue = 0
        Me.txtSafetyFactor_DesignBH_RodEnd.Name = "txtSafetyFactor_DesignBH_RodEnd"
        Me.txtSafetyFactor_DesignBH_RodEnd.Size = New System.Drawing.Size(40, 20)
        Me.txtSafetyFactor_DesignBH_RodEnd.StatusMessage = ""
        Me.txtSafetyFactor_DesignBH_RodEnd.StatusObject = Nothing
        Me.txtSafetyFactor_DesignBH_RodEnd.TabIndex = 6
        Me.txtSafetyFactor_DesignBH_RodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLugThicknessNewDesign_RodEnd
        '
        Me.lblLugThicknessNewDesign_RodEnd.AutoSize = True
        Me.lblLugThicknessNewDesign_RodEnd.Location = New System.Drawing.Point(50, 73)
        Me.lblLugThicknessNewDesign_RodEnd.Name = "lblLugThicknessNewDesign_RodEnd"
        Me.lblLugThicknessNewDesign_RodEnd.Size = New System.Drawing.Size(77, 13)
        Me.lblLugThicknessNewDesign_RodEnd.TabIndex = 155
        Me.lblLugThicknessNewDesign_RodEnd.Text = "Lug Thickness"
        '
        'lblSafetyFactor_RodEnd
        '
        Me.lblSafetyFactor_RodEnd.AutoSize = True
        Me.lblSafetyFactor_RodEnd.Location = New System.Drawing.Point(9, 34)
        Me.lblSafetyFactor_RodEnd.Name = "lblSafetyFactor_RodEnd"
        Me.lblSafetyFactor_RodEnd.Size = New System.Drawing.Size(70, 13)
        Me.lblSafetyFactor_RodEnd.TabIndex = 153
        Me.lblSafetyFactor_RodEnd.Text = "Safety Factor"
        '
        'trbSafetyFactor_RodEnd
        '
        Me.trbSafetyFactor_RodEnd.Location = New System.Drawing.Point(113, 22)
        Me.trbSafetyFactor_RodEnd.Maximum = 20
        Me.trbSafetyFactor_RodEnd.Minimum = 2
        Me.trbSafetyFactor_RodEnd.Name = "trbSafetyFactor_RodEnd"
        Me.trbSafetyFactor_RodEnd.Size = New System.Drawing.Size(266, 45)
        Me.trbSafetyFactor_RodEnd.TabIndex = 5
        Me.trbSafetyFactor_RodEnd.Value = 2
        '
        'txtLugThickness_DesignBH_RodEnd
        '
        Me.txtLugThickness_DesignBH_RodEnd.AcceptEnterKeyAsTab = True
        Me.txtLugThickness_DesignBH_RodEnd.ApplyIFLColor = True
        Me.txtLugThickness_DesignBH_RodEnd.AssociateLabel = Nothing
        Me.txtLugThickness_DesignBH_RodEnd.DecimalValue = 3
        Me.txtLugThickness_DesignBH_RodEnd.IFLDataTag = Nothing
        Me.txtLugThickness_DesignBH_RodEnd.InvalidInputCharacters = ""
        Me.txtLugThickness_DesignBH_RodEnd.IsAllowNegative = False
        Me.txtLugThickness_DesignBH_RodEnd.LengthValue = 7
        Me.txtLugThickness_DesignBH_RodEnd.Location = New System.Drawing.Point(133, 70)
        Me.txtLugThickness_DesignBH_RodEnd.MaximumValue = 99999
        Me.txtLugThickness_DesignBH_RodEnd.MaxLength = 6
        Me.txtLugThickness_DesignBH_RodEnd.MinimumValue = 0
        Me.txtLugThickness_DesignBH_RodEnd.Name = "txtLugThickness_DesignBH_RodEnd"
        Me.txtLugThickness_DesignBH_RodEnd.Size = New System.Drawing.Size(66, 20)
        Me.txtLugThickness_DesignBH_RodEnd.StatusMessage = ""
        Me.txtLugThickness_DesignBH_RodEnd.StatusObject = Nothing
        Me.txtLugThickness_DesignBH_RodEnd.TabIndex = 7
        Me.txtLugThickness_DesignBH_RodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.lblDesignNewCasting.Text = "Design BH"
        Me.lblDesignNewCasting.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnGenerate_RodEnd
        '
        Me.btnGenerate_RodEnd.Location = New System.Drawing.Point(156, 123)
        Me.btnGenerate_RodEnd.Name = "btnGenerate_RodEnd"
        Me.btnGenerate_RodEnd.Size = New System.Drawing.Size(129, 23)
        Me.btnGenerate_RodEnd.TabIndex = 11
        Me.btnGenerate_RodEnd.Text = "Generate"
        Me.btnGenerate_RodEnd.UseVisualStyleBackColor = True
        '
        'lblLugWidth_RodEnd
        '
        Me.lblLugWidth_RodEnd.AutoSize = True
        Me.lblLugWidth_RodEnd.Location = New System.Drawing.Point(50, 100)
        Me.lblLugWidth_RodEnd.Name = "lblLugWidth_RodEnd"
        Me.lblLugWidth_RodEnd.Size = New System.Drawing.Size(56, 13)
        Me.lblLugWidth_RodEnd.TabIndex = 143
        Me.lblLugWidth_RodEnd.Text = "Lug Width"
        '
        'txtLugWidth_DesignBH_RodEnd
        '
        Me.txtLugWidth_DesignBH_RodEnd.AcceptEnterKeyAsTab = True
        Me.txtLugWidth_DesignBH_RodEnd.ApplyIFLColor = True
        Me.txtLugWidth_DesignBH_RodEnd.AssociateLabel = Nothing
        Me.txtLugWidth_DesignBH_RodEnd.DecimalValue = 2
        Me.txtLugWidth_DesignBH_RodEnd.IFLDataTag = Nothing
        Me.txtLugWidth_DesignBH_RodEnd.InvalidInputCharacters = ""
        Me.txtLugWidth_DesignBH_RodEnd.IsAllowNegative = False
        Me.txtLugWidth_DesignBH_RodEnd.LengthValue = 6
        Me.txtLugWidth_DesignBH_RodEnd.Location = New System.Drawing.Point(133, 97)
        Me.txtLugWidth_DesignBH_RodEnd.MaximumValue = 99999
        Me.txtLugWidth_DesignBH_RodEnd.MaxLength = 6
        Me.txtLugWidth_DesignBH_RodEnd.MinimumValue = 0
        Me.txtLugWidth_DesignBH_RodEnd.Name = "txtLugWidth_DesignBH_RodEnd"
        Me.txtLugWidth_DesignBH_RodEnd.Size = New System.Drawing.Size(66, 20)
        Me.txtLugWidth_DesignBH_RodEnd.StatusMessage = ""
        Me.txtLugWidth_DesignBH_RodEnd.StatusObject = Nothing
        Me.txtLugWidth_DesignBH_RodEnd.TabIndex = 9
        Me.txtLugWidth_DesignBH_RodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSwingClearance_DesignBH_RodEnd
        '
        Me.txtSwingClearance_DesignBH_RodEnd.AcceptEnterKeyAsTab = True
        Me.txtSwingClearance_DesignBH_RodEnd.ApplyIFLColor = True
        Me.txtSwingClearance_DesignBH_RodEnd.AssociateLabel = Nothing
        Me.txtSwingClearance_DesignBH_RodEnd.DecimalValue = 2
        Me.txtSwingClearance_DesignBH_RodEnd.IFLDataTag = Nothing
        Me.txtSwingClearance_DesignBH_RodEnd.InvalidInputCharacters = ""
        Me.txtSwingClearance_DesignBH_RodEnd.IsAllowNegative = False
        Me.txtSwingClearance_DesignBH_RodEnd.LengthValue = 6
        Me.txtSwingClearance_DesignBH_RodEnd.Location = New System.Drawing.Point(324, 97)
        Me.txtSwingClearance_DesignBH_RodEnd.MaximumValue = 99999
        Me.txtSwingClearance_DesignBH_RodEnd.MaxLength = 6
        Me.txtSwingClearance_DesignBH_RodEnd.MinimumValue = 0
        Me.txtSwingClearance_DesignBH_RodEnd.Name = "txtSwingClearance_DesignBH_RodEnd"
        Me.txtSwingClearance_DesignBH_RodEnd.Size = New System.Drawing.Size(66, 20)
        Me.txtSwingClearance_DesignBH_RodEnd.StatusMessage = ""
        Me.txtSwingClearance_DesignBH_RodEnd.StatusObject = Nothing
        Me.txtSwingClearance_DesignBH_RodEnd.TabIndex = 10
        Me.txtSwingClearance_DesignBH_RodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSwingClearance_DesignSL_RodEnd
        '
        Me.lblSwingClearance_DesignSL_RodEnd.AutoSize = True
        Me.lblSwingClearance_DesignSL_RodEnd.Location = New System.Drawing.Point(227, 100)
        Me.lblSwingClearance_DesignSL_RodEnd.Name = "lblSwingClearance_DesignSL_RodEnd"
        Me.lblSwingClearance_DesignSL_RodEnd.Size = New System.Drawing.Size(87, 13)
        Me.lblSwingClearance_DesignSL_RodEnd.TabIndex = 149
        Me.lblSwingClearance_DesignSL_RodEnd.Text = "Swing Clearance"
        '
        'txtPinHoleSize_DesignBH_RodEnd
        '
        Me.txtPinHoleSize_DesignBH_RodEnd.AcceptEnterKeyAsTab = True
        Me.txtPinHoleSize_DesignBH_RodEnd.ApplyIFLColor = True
        Me.txtPinHoleSize_DesignBH_RodEnd.AssociateLabel = Nothing
        Me.txtPinHoleSize_DesignBH_RodEnd.DecimalValue = 2
        Me.txtPinHoleSize_DesignBH_RodEnd.IFLDataTag = Nothing
        Me.txtPinHoleSize_DesignBH_RodEnd.InvalidInputCharacters = ""
        Me.txtPinHoleSize_DesignBH_RodEnd.IsAllowNegative = False
        Me.txtPinHoleSize_DesignBH_RodEnd.LengthValue = 6
        Me.txtPinHoleSize_DesignBH_RodEnd.Location = New System.Drawing.Point(324, 70)
        Me.txtPinHoleSize_DesignBH_RodEnd.MaximumValue = 99999
        Me.txtPinHoleSize_DesignBH_RodEnd.MaxLength = 6
        Me.txtPinHoleSize_DesignBH_RodEnd.MinimumValue = 0
        Me.txtPinHoleSize_DesignBH_RodEnd.Name = "txtPinHoleSize_DesignBH_RodEnd"
        Me.txtPinHoleSize_DesignBH_RodEnd.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleSize_DesignBH_RodEnd.StatusMessage = ""
        Me.txtPinHoleSize_DesignBH_RodEnd.StatusObject = Nothing
        Me.txtPinHoleSize_DesignBH_RodEnd.TabIndex = 8
        Me.txtPinHoleSize_DesignBH_RodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPinHoleSize_DesignBH_RodEnd
        '
        Me.lblPinHoleSize_DesignBH_RodEnd.AutoSize = True
        Me.lblPinHoleSize_DesignBH_RodEnd.Location = New System.Drawing.Point(227, 73)
        Me.lblPinHoleSize_DesignBH_RodEnd.Name = "lblPinHoleSize_DesignBH_RodEnd"
        Me.lblPinHoleSize_DesignBH_RodEnd.Size = New System.Drawing.Size(70, 13)
        Me.lblPinHoleSize_DesignBH_RodEnd.TabIndex = 147
        Me.lblPinHoleSize_DesignBH_RodEnd.Text = "Pin Hole Size"
        '
        'btnMatchedBHNotFound_RodEnd
        '
        Me.btnMatchedBHNotFound_RodEnd.Enabled = False
        Me.btnMatchedBHNotFound_RodEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMatchedBHNotFound_RodEnd.Location = New System.Drawing.Point(188, 24)
        Me.btnMatchedBHNotFound_RodEnd.Name = "btnMatchedBHNotFound_RodEnd"
        Me.btnMatchedBHNotFound_RodEnd.Size = New System.Drawing.Size(183, 24)
        Me.btnMatchedBHNotFound_RodEnd.TabIndex = 147
        Me.btnMatchedBHNotFound_RodEnd.Text = "Matching BH not found"
        Me.btnMatchedBHNotFound_RodEnd.UseVisualStyleBackColor = True
        '
        'LabelGradient1
        '
        Me.LabelGradient1.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient1.GradientColorOne = System.Drawing.Color.Olive
        Me.LabelGradient1.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient1.Location = New System.Drawing.Point(-4, 0)
        Me.LabelGradient1.Name = "LabelGradient1"
        Me.LabelGradient1.Size = New System.Drawing.Size(563, 19)
        Me.LabelGradient1.TabIndex = 22
        Me.LabelGradient1.Text = "Existing BH Details"
        Me.LabelGradient1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAccept_RodEnd
        '
        Me.btnAccept_RodEnd.Location = New System.Drawing.Point(215, 333)
        Me.btnAccept_RodEnd.Name = "btnAccept_RodEnd"
        Me.btnAccept_RodEnd.Size = New System.Drawing.Size(129, 23)
        Me.btnAccept_RodEnd.TabIndex = 12
        Me.btnAccept_RodEnd.Text = "Accept"
        Me.btnAccept_RodEnd.UseVisualStyleBackColor = True
        '
        'LabelGradient5
        '
        Me.LabelGradient5.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient5.GradientColorOne = System.Drawing.Color.DarkGoldenrod
        Me.LabelGradient5.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient5.Location = New System.Drawing.Point(3, 0)
        Me.LabelGradient5.Name = "LabelGradient5"
        Me.LabelGradient5.Size = New System.Drawing.Size(598, 406)
        Me.LabelGradient5.TabIndex = 149
        Me.LabelGradient5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelGradient4
        '
        Me.LabelGradient4.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient4.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelGradient4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient4.GradientColorOne = System.Drawing.Color.Olive
        Me.LabelGradient4.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient4.Location = New System.Drawing.Point(1178, 0)
        Me.LabelGradient4.Name = "LabelGradient4"
        Me.LabelGradient4.Size = New System.Drawing.Size(22, 900)
        Me.LabelGradient4.TabIndex = 47
        Me.LabelGradient4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlRESLMaching_YesNo
        '
        Me.pnlRESLMaching_YesNo.Controls.Add(Me.pnlMatchingBHNotFound)
        Me.pnlRESLMaching_YesNo.Location = New System.Drawing.Point(26, 22)
        Me.pnlRESLMaching_YesNo.Name = "pnlRESLMaching_YesNo"
        Me.pnlRESLMaching_YesNo.Size = New System.Drawing.Size(950, 650)
        Me.pnlRESLMaching_YesNo.TabIndex = 44
        '
        'lvwSafetyFactor_Weight_RodEnd
        '
        Me.lvwSafetyFactor_Weight_RodEnd.GridLines = True
        Me.lvwSafetyFactor_Weight_RodEnd.Location = New System.Drawing.Point(25, 21)
        Me.lvwSafetyFactor_Weight_RodEnd.Name = "lvwSafetyFactor_Weight_RodEnd"
        Me.lvwSafetyFactor_Weight_RodEnd.Size = New System.Drawing.Size(390, 97)
        Me.lvwSafetyFactor_Weight_RodEnd.TabIndex = 14
        Me.lvwSafetyFactor_Weight_RodEnd.UseCompatibleStateImageBehavior = False
        Me.lvwSafetyFactor_Weight_RodEnd.View = System.Windows.Forms.View.Details
        '
        'frmREBHExistingNotSelected
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1200, 900)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblBHHeading)
        Me.Controls.Add(Me.LabelGradient3)
        Me.Controls.Add(Me.LabelGradient2)
        Me.Controls.Add(Me.LabelGradient4)
        Me.Controls.Add(Me.pnlRESLMaching_YesNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmREBHExistingNotSelected"
        Me.Text = "frmREBHExistingNotSelected"
        Me.pnlMatchingBHNotFound.ResumeLayout(False)
        Me.grbMatchedBHNotFound_RodEnd.ResumeLayout(False)
        Me.pnlSafetyFactor_Weight_LugThickness_RodEnd.ResumeLayout(False)
        Me.pnlDesignBH_RodEnd.ResumeLayout(False)
        Me.pnlDesignBH_RodEnd.PerformLayout()
        CType(Me.trbSafetyFactor_RodEnd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlRESLMaching_YesNo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblBHHeading As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient3 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient2 As LabelGradient.LabelGradient
    Friend WithEvents pnlMatchingBHNotFound As System.Windows.Forms.Panel
    Friend WithEvents grbMatchedBHNotFound_RodEnd As System.Windows.Forms.GroupBox
    Friend WithEvents pnlSafetyFactor_Weight_LugThickness_RodEnd As System.Windows.Forms.Panel
    Friend WithEvents lvwSafetyFactor_Weight_RodEnd As Monarch_WeldedCylinder_01_09_09.clsListViewMIL
    Friend WithEvents lblSafetyFactorIndex As LabelGradient.LabelGradient
    Friend WithEvents pnlDesignBH_RodEnd As System.Windows.Forms.Panel
    Friend WithEvents txtSafetyFactor_DesignBH_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblLugThicknessNewDesign_RodEnd As System.Windows.Forms.Label
    Friend WithEvents lblSafetyFactor_RodEnd As System.Windows.Forms.Label
    Friend WithEvents trbSafetyFactor_RodEnd As System.Windows.Forms.TrackBar
    Friend WithEvents txtLugThickness_DesignBH_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblDesignNewCasting As LabelGradient.LabelGradient
    Friend WithEvents btnGenerate_RodEnd As System.Windows.Forms.Button
    Friend WithEvents lblLugWidth_RodEnd As System.Windows.Forms.Label
    Friend WithEvents txtLugWidth_DesignBH_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtSwingClearance_DesignBH_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSwingClearance_DesignSL_RodEnd As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleSize_DesignBH_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblPinHoleSize_DesignBH_RodEnd As System.Windows.Forms.Label
    Friend WithEvents btnMatchedBHNotFound_RodEnd As System.Windows.Forms.Button
    Friend WithEvents LabelGradient1 As LabelGradient.LabelGradient
    Friend WithEvents btnAccept_RodEnd As System.Windows.Forms.Button
    Friend WithEvents LabelGradient5 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient4 As LabelGradient.LabelGradient
    Friend WithEvents pnlRESLMaching_YesNo As System.Windows.Forms.Panel
End Class
