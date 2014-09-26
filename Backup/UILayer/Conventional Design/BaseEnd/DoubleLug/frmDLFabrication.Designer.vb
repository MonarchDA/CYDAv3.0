<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDLFabrication
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
        Me.UcBrowsePlateClevis1 = New Monarch_WeldedCylinder_01_09_09.ucBrowsePlateClevis
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.grbMatchedULugNotFound = New System.Windows.Forms.GroupBox
        Me.pnlSafetyFactor_Weight_LugThickness = New System.Windows.Forms.Panel
        Me.lvwSafetyFactor_Weight = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL
        Me.lblSafetyFactorIndex = New LabelGradient.LabelGradient
        Me.pnlDesignULug = New System.Windows.Forms.Panel
        Me.chkOptimizer = New System.Windows.Forms.CheckBox
        Me.txtSafetyFactor_DesignULug = New IFLCustomUILayer.IFLNumericBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblSafetyFactor = New System.Windows.Forms.Label
        Me.trbSafetyFactor = New System.Windows.Forms.TrackBar
        Me.txtLugThickness_DesignULug = New IFLCustomUILayer.IFLNumericBox
        Me.lblDesignNewCasting = New LabelGradient.LabelGradient
        Me.btnGenerate = New System.Windows.Forms.Button
        Me.lblLugWidth2 = New System.Windows.Forms.Label
        Me.txtLugWidth_DesignULug = New IFLCustomUILayer.IFLNumericBox
        Me.txtSwingClearance_DesignULug = New IFLCustomUILayer.IFLNumericBox
        Me.lblSwingClearance2 = New System.Windows.Forms.Label
        Me.txtPinHoleSize_DesignULug = New IFLCustomUILayer.IFLNumericBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblLugGap = New System.Windows.Forms.Label
        Me.txtLugGap_DesignULug = New IFLCustomUILayer.IFLNumericBox
        Me.btnMatchedULugNotFound = New System.Windows.Forms.Button
        Me.LabelGradient2 = New LabelGradient.LabelGradient
        Me.btnAccept = New System.Windows.Forms.Button
        Me.grbMatchedULugsFound = New System.Windows.Forms.GroupBox
        Me.txtPinHoleTole_Neg_Req = New IFLCustomUILayer.IFLNumericBox
        Me.txtPinHoleTole_Pos_Req = New IFLCustomUILayer.IFLNumericBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblRequired = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPinHoleTole_Neg = New IFLCustomUILayer.IFLNumericBox
        Me.txtPinHoleTole_Pos = New IFLCustomUILayer.IFLNumericBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.rdbDesignaULug = New System.Windows.Forms.RadioButton
        Me.rdbUseSelectedULug = New System.Windows.Forms.RadioButton
        Me.txtRequiredLugWidth = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredSwingClearance = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredLugGap = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredPinHoleSize = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredLugHeight = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredLugThickness = New IFLCustomUILayer.IFLNumericBox
        Me.lblPinHoleSize = New System.Windows.Forms.Label
        Me.txtPinHoleSize = New IFLCustomUILayer.IFLNumericBox
        Me.lblShowImage = New LabelGradient.LabelGradient
        Me.lblExistingULugsDetails = New LabelGradient.LabelGradient
        Me.lvwExistingLugListView = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL
        Me.lblLugHeight = New System.Windows.Forms.Label
        Me.picCastingNo = New System.Windows.Forms.PictureBox
        Me.txtLugHeight = New IFLCustomUILayer.IFLNumericBox
        Me.lblLugWidth = New System.Windows.Forms.Label
        Me.txtLugWidth = New IFLCustomUILayer.IFLNumericBox
        Me.txtSwingClearance = New IFLCustomUILayer.IFLNumericBox
        Me.lblLugsGap = New System.Windows.Forms.Label
        Me.lblSwingClearance = New System.Windows.Forms.Label
        Me.txtLugGap = New IFLCustomUILayer.IFLNumericBox
        Me.lblLugThickness = New System.Windows.Forms.Label
        Me.txtLugThickness = New IFLCustomUILayer.IFLNumericBox
        Me.btnRodWeldmentScreensDisplayedNext = New System.Windows.Forms.Button
        Me.pnlFabrication = New System.Windows.Forms.Panel
        Me.grbPlateClevis.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grbMatchedULugNotFound.SuspendLayout()
        Me.pnlSafetyFactor_Weight_LugThickness.SuspendLayout()
        Me.pnlDesignULug.SuspendLayout()
        CType(Me.trbSafetyFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbMatchedULugsFound.SuspendLayout()
        CType(Me.picCastingNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFabrication.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbPlateClevis
        '
        Me.grbPlateClevis.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.grbPlateClevis.Controls.Add(Me.btnPlateClevis)
        Me.grbPlateClevis.Controls.Add(Me.UcBrowsePlateClevis1)
        Me.grbPlateClevis.Location = New System.Drawing.Point(6, 4)
        Me.grbPlateClevis.Name = "grbPlateClevis"
        Me.grbPlateClevis.Size = New System.Drawing.Size(565, 94)
        Me.grbPlateClevis.TabIndex = 146
        Me.grbPlateClevis.TabStop = False
        Me.grbPlateClevis.Text = "Plate Clevis"
        '
        'btnPlateClevis
        '
        Me.btnPlateClevis.Enabled = False
        Me.btnPlateClevis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPlateClevis.Location = New System.Drawing.Point(119, 41)
        Me.btnPlateClevis.Name = "btnPlateClevis"
        Me.btnPlateClevis.Size = New System.Drawing.Size(291, 34)
        Me.btnPlateClevis.TabIndex = 145
        Me.btnPlateClevis.Text = "Matching Plate Clevis found"
        Me.btnPlateClevis.UseVisualStyleBackColor = True
        '
        'UcBrowsePlateClevis1
        '
        Me.UcBrowsePlateClevis1.BackColor = System.Drawing.Color.Ivory
        Me.UcBrowsePlateClevis1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.UcBrowsePlateClevis1.Location = New System.Drawing.Point(10, 13)
        Me.UcBrowsePlateClevis1.Name = "UcBrowsePlateClevis1"
        Me.UcBrowsePlateClevis1.ObjFrmImportPlateClevis = Nothing
        Me.UcBrowsePlateClevis1.Size = New System.Drawing.Size(543, 73)
        Me.UcBrowsePlateClevis1.TabIndex = 107
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox1.Controls.Add(Me.grbMatchedULugsFound)
        Me.GroupBox1.Controls.Add(Me.grbMatchedULugNotFound)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 104)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(571, 366)
        Me.GroupBox1.TabIndex = 147
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "U Lug"
        '
        'grbMatchedULugNotFound
        '
        Me.grbMatchedULugNotFound.Controls.Add(Me.pnlSafetyFactor_Weight_LugThickness)
        Me.grbMatchedULugNotFound.Controls.Add(Me.pnlDesignULug)
        Me.grbMatchedULugNotFound.Controls.Add(Me.btnMatchedULugNotFound)
        Me.grbMatchedULugNotFound.Controls.Add(Me.LabelGradient2)
        Me.grbMatchedULugNotFound.Controls.Add(Me.btnAccept)
        Me.grbMatchedULugNotFound.Location = New System.Drawing.Point(7, 15)
        Me.grbMatchedULugNotFound.Name = "grbMatchedULugNotFound"
        Me.grbMatchedULugNotFound.Size = New System.Drawing.Size(559, 345)
        Me.grbMatchedULugNotFound.TabIndex = 147
        Me.grbMatchedULugNotFound.TabStop = False
        '
        'pnlSafetyFactor_Weight_LugThickness
        '
        Me.pnlSafetyFactor_Weight_LugThickness.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlSafetyFactor_Weight_LugThickness.Controls.Add(Me.lvwSafetyFactor_Weight)
        Me.pnlSafetyFactor_Weight_LugThickness.Controls.Add(Me.lblSafetyFactorIndex)
        Me.pnlSafetyFactor_Weight_LugThickness.Location = New System.Drawing.Point(55, 196)
        Me.pnlSafetyFactor_Weight_LugThickness.Name = "pnlSafetyFactor_Weight_LugThickness"
        Me.pnlSafetyFactor_Weight_LugThickness.Size = New System.Drawing.Size(445, 119)
        Me.pnlSafetyFactor_Weight_LugThickness.TabIndex = 150
        '
        'lvwSafetyFactor_Weight
        '
        Me.lvwSafetyFactor_Weight.GridLines = True
        Me.lvwSafetyFactor_Weight.Location = New System.Drawing.Point(25, 21)
        Me.lvwSafetyFactor_Weight.Name = "lvwSafetyFactor_Weight"
        Me.lvwSafetyFactor_Weight.Size = New System.Drawing.Size(390, 91)
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
        Me.pnlDesignULug.Controls.Add(Me.txtSafetyFactor_DesignULug)
        Me.pnlDesignULug.Controls.Add(Me.Label5)
        Me.pnlDesignULug.Controls.Add(Me.lblSafetyFactor)
        Me.pnlDesignULug.Controls.Add(Me.trbSafetyFactor)
        Me.pnlDesignULug.Controls.Add(Me.txtLugThickness_DesignULug)
        Me.pnlDesignULug.Controls.Add(Me.lblDesignNewCasting)
        Me.pnlDesignULug.Controls.Add(Me.btnGenerate)
        Me.pnlDesignULug.Controls.Add(Me.lblLugWidth2)
        Me.pnlDesignULug.Controls.Add(Me.txtLugWidth_DesignULug)
        Me.pnlDesignULug.Controls.Add(Me.txtSwingClearance_DesignULug)
        Me.pnlDesignULug.Controls.Add(Me.lblSwingClearance2)
        Me.pnlDesignULug.Controls.Add(Me.txtPinHoleSize_DesignULug)
        Me.pnlDesignULug.Controls.Add(Me.Label1)
        Me.pnlDesignULug.Controls.Add(Me.lblLugGap)
        Me.pnlDesignULug.Controls.Add(Me.txtLugGap_DesignULug)
        Me.pnlDesignULug.Location = New System.Drawing.Point(57, 48)
        Me.pnlDesignULug.Name = "pnlDesignULug"
        Me.pnlDesignULug.Size = New System.Drawing.Size(445, 145)
        Me.pnlDesignULug.TabIndex = 148
        '
        'chkOptimizer
        '
        Me.chkOptimizer.AutoSize = True
        Me.chkOptimizer.Location = New System.Drawing.Point(372, 123)
        Me.chkOptimizer.Name = "chkOptimizer"
        Me.chkOptimizer.Size = New System.Drawing.Size(66, 17)
        Me.chkOptimizer.TabIndex = 165
        Me.chkOptimizer.Text = "Optimize"
        Me.chkOptimizer.UseVisualStyleBackColor = True
        '
        'txtSafetyFactor_DesignULug
        '
        Me.txtSafetyFactor_DesignULug.AcceptEnterKeyAsTab = True
        Me.txtSafetyFactor_DesignULug.ApplyIFLColor = True
        Me.txtSafetyFactor_DesignULug.AssociateLabel = Nothing
        Me.txtSafetyFactor_DesignULug.DecimalValue = 2
        Me.txtSafetyFactor_DesignULug.IFLDataTag = Nothing
        Me.txtSafetyFactor_DesignULug.InvalidInputCharacters = ""
        Me.txtSafetyFactor_DesignULug.IsAllowNegative = False
        Me.txtSafetyFactor_DesignULug.LengthValue = 6
        Me.txtSafetyFactor_DesignULug.Location = New System.Drawing.Point(373, 31)
        Me.txtSafetyFactor_DesignULug.MaximumValue = 99999
        Me.txtSafetyFactor_DesignULug.MaxLength = 6
        Me.txtSafetyFactor_DesignULug.MinimumValue = 0
        Me.txtSafetyFactor_DesignULug.Name = "txtSafetyFactor_DesignULug"
        Me.txtSafetyFactor_DesignULug.Size = New System.Drawing.Size(40, 20)
        Me.txtSafetyFactor_DesignULug.StatusMessage = ""
        Me.txtSafetyFactor_DesignULug.StatusObject = Nothing
        Me.txtSafetyFactor_DesignULug.TabIndex = 156
        Me.txtSafetyFactor_DesignULug.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 155
        Me.Label5.Text = "Lug Thickness"
        '
        'lblSafetyFactor
        '
        Me.lblSafetyFactor.AutoSize = True
        Me.lblSafetyFactor.Location = New System.Drawing.Point(25, 34)
        Me.lblSafetyFactor.Name = "lblSafetyFactor"
        Me.lblSafetyFactor.Size = New System.Drawing.Size(70, 13)
        Me.lblSafetyFactor.TabIndex = 153
        Me.lblSafetyFactor.Text = "Safety Factor"
        '
        'trbSafetyFactor
        '
        Me.trbSafetyFactor.LargeChange = 1
        Me.trbSafetyFactor.Location = New System.Drawing.Point(101, 22)
        Me.trbSafetyFactor.Maximum = 20
        Me.trbSafetyFactor.Minimum = 2
        Me.trbSafetyFactor.Name = "trbSafetyFactor"
        Me.trbSafetyFactor.Size = New System.Drawing.Size(266, 45)
        Me.trbSafetyFactor.TabIndex = 152
        Me.trbSafetyFactor.Value = 2
        '
        'txtLugThickness_DesignULug
        '
        Me.txtLugThickness_DesignULug.AcceptEnterKeyAsTab = True
        Me.txtLugThickness_DesignULug.ApplyIFLColor = True
        Me.txtLugThickness_DesignULug.AssociateLabel = Nothing
        Me.txtLugThickness_DesignULug.DecimalValue = 3
        Me.txtLugThickness_DesignULug.IFLDataTag = Nothing
        Me.txtLugThickness_DesignULug.InvalidInputCharacters = ""
        Me.txtLugThickness_DesignULug.IsAllowNegative = False
        Me.txtLugThickness_DesignULug.LengthValue = 6
        Me.txtLugThickness_DesignULug.Location = New System.Drawing.Point(103, 92)
        Me.txtLugThickness_DesignULug.MaximumValue = 99999
        Me.txtLugThickness_DesignULug.MaxLength = 6
        Me.txtLugThickness_DesignULug.MinimumValue = 0
        Me.txtLugThickness_DesignULug.Name = "txtLugThickness_DesignULug"
        Me.txtLugThickness_DesignULug.Size = New System.Drawing.Size(66, 20)
        Me.txtLugThickness_DesignULug.StatusMessage = ""
        Me.txtLugThickness_DesignULug.StatusObject = Nothing
        Me.txtLugThickness_DesignULug.TabIndex = 154
        Me.txtLugThickness_DesignULug.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.lblDesignNewCasting.Text = "Design ULug"
        Me.lblDesignNewCasting.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(202, 116)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(154, 23)
        Me.btnGenerate.TabIndex = 150
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'lblLugWidth2
        '
        Me.lblLugWidth2.AutoSize = True
        Me.lblLugWidth2.Location = New System.Drawing.Point(20, 122)
        Me.lblLugWidth2.Name = "lblLugWidth2"
        Me.lblLugWidth2.Size = New System.Drawing.Size(56, 13)
        Me.lblLugWidth2.TabIndex = 143
        Me.lblLugWidth2.Text = "Lug Width"
        '
        'txtLugWidth_DesignULug
        '
        Me.txtLugWidth_DesignULug.AcceptEnterKeyAsTab = True
        Me.txtLugWidth_DesignULug.ApplyIFLColor = True
        Me.txtLugWidth_DesignULug.AssociateLabel = Nothing
        Me.txtLugWidth_DesignULug.DecimalValue = 2
        Me.txtLugWidth_DesignULug.IFLDataTag = Nothing
        Me.txtLugWidth_DesignULug.InvalidInputCharacters = ""
        Me.txtLugWidth_DesignULug.IsAllowNegative = False
        Me.txtLugWidth_DesignULug.LengthValue = 6
        Me.txtLugWidth_DesignULug.Location = New System.Drawing.Point(103, 119)
        Me.txtLugWidth_DesignULug.MaximumValue = 99999
        Me.txtLugWidth_DesignULug.MaxLength = 6
        Me.txtLugWidth_DesignULug.MinimumValue = 0
        Me.txtLugWidth_DesignULug.Name = "txtLugWidth_DesignULug"
        Me.txtLugWidth_DesignULug.Size = New System.Drawing.Size(66, 20)
        Me.txtLugWidth_DesignULug.StatusMessage = ""
        Me.txtLugWidth_DesignULug.StatusObject = Nothing
        Me.txtLugWidth_DesignULug.TabIndex = 142
        Me.txtLugWidth_DesignULug.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSwingClearance_DesignULug
        '
        Me.txtSwingClearance_DesignULug.AcceptEnterKeyAsTab = True
        Me.txtSwingClearance_DesignULug.ApplyIFLColor = True
        Me.txtSwingClearance_DesignULug.AssociateLabel = Nothing
        Me.txtSwingClearance_DesignULug.DecimalValue = 2
        Me.txtSwingClearance_DesignULug.IFLDataTag = Nothing
        Me.txtSwingClearance_DesignULug.InvalidInputCharacters = ""
        Me.txtSwingClearance_DesignULug.IsAllowNegative = False
        Me.txtSwingClearance_DesignULug.LengthValue = 6
        Me.txtSwingClearance_DesignULug.Location = New System.Drawing.Point(290, 92)
        Me.txtSwingClearance_DesignULug.MaximumValue = 99999
        Me.txtSwingClearance_DesignULug.MaxLength = 6
        Me.txtSwingClearance_DesignULug.MinimumValue = 0
        Me.txtSwingClearance_DesignULug.Name = "txtSwingClearance_DesignULug"
        Me.txtSwingClearance_DesignULug.Size = New System.Drawing.Size(66, 20)
        Me.txtSwingClearance_DesignULug.StatusMessage = ""
        Me.txtSwingClearance_DesignULug.StatusObject = Nothing
        Me.txtSwingClearance_DesignULug.TabIndex = 148
        Me.txtSwingClearance_DesignULug.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSwingClearance2
        '
        Me.lblSwingClearance2.AutoSize = True
        Me.lblSwingClearance2.Location = New System.Drawing.Point(199, 95)
        Me.lblSwingClearance2.Name = "lblSwingClearance2"
        Me.lblSwingClearance2.Size = New System.Drawing.Size(87, 13)
        Me.lblSwingClearance2.TabIndex = 149
        Me.lblSwingClearance2.Text = "Swing Clearance"
        '
        'txtPinHoleSize_DesignULug
        '
        Me.txtPinHoleSize_DesignULug.AcceptEnterKeyAsTab = True
        Me.txtPinHoleSize_DesignULug.ApplyIFLColor = True
        Me.txtPinHoleSize_DesignULug.AssociateLabel = Nothing
        Me.txtPinHoleSize_DesignULug.DecimalValue = 2
        Me.txtPinHoleSize_DesignULug.IFLDataTag = Nothing
        Me.txtPinHoleSize_DesignULug.InvalidInputCharacters = ""
        Me.txtPinHoleSize_DesignULug.IsAllowNegative = False
        Me.txtPinHoleSize_DesignULug.LengthValue = 6
        Me.txtPinHoleSize_DesignULug.Location = New System.Drawing.Point(290, 65)
        Me.txtPinHoleSize_DesignULug.MaximumValue = 99999
        Me.txtPinHoleSize_DesignULug.MaxLength = 6
        Me.txtPinHoleSize_DesignULug.MinimumValue = 0
        Me.txtPinHoleSize_DesignULug.Name = "txtPinHoleSize_DesignULug"
        Me.txtPinHoleSize_DesignULug.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleSize_DesignULug.StatusMessage = ""
        Me.txtPinHoleSize_DesignULug.StatusObject = Nothing
        Me.txtPinHoleSize_DesignULug.TabIndex = 146
        Me.txtPinHoleSize_DesignULug.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(199, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 147
        Me.Label1.Text = "Pin Hole Size"
        '
        'lblLugGap
        '
        Me.lblLugGap.AutoSize = True
        Me.lblLugGap.Location = New System.Drawing.Point(20, 68)
        Me.lblLugGap.Name = "lblLugGap"
        Me.lblLugGap.Size = New System.Drawing.Size(48, 13)
        Me.lblLugGap.TabIndex = 145
        Me.lblLugGap.Text = "Lug Gap"
        '
        'txtLugGap_DesignULug
        '
        Me.txtLugGap_DesignULug.AcceptEnterKeyAsTab = True
        Me.txtLugGap_DesignULug.ApplyIFLColor = True
        Me.txtLugGap_DesignULug.AssociateLabel = Nothing
        Me.txtLugGap_DesignULug.DecimalValue = 2
        Me.txtLugGap_DesignULug.IFLDataTag = Nothing
        Me.txtLugGap_DesignULug.InvalidInputCharacters = ""
        Me.txtLugGap_DesignULug.IsAllowNegative = False
        Me.txtLugGap_DesignULug.LengthValue = 6
        Me.txtLugGap_DesignULug.Location = New System.Drawing.Point(103, 65)
        Me.txtLugGap_DesignULug.MaximumValue = 99999
        Me.txtLugGap_DesignULug.MaxLength = 6
        Me.txtLugGap_DesignULug.MinimumValue = 0
        Me.txtLugGap_DesignULug.Name = "txtLugGap_DesignULug"
        Me.txtLugGap_DesignULug.Size = New System.Drawing.Size(66, 20)
        Me.txtLugGap_DesignULug.StatusMessage = ""
        Me.txtLugGap_DesignULug.StatusObject = Nothing
        Me.txtLugGap_DesignULug.TabIndex = 144
        Me.txtLugGap_DesignULug.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnMatchedULugNotFound
        '
        Me.btnMatchedULugNotFound.Enabled = False
        Me.btnMatchedULugNotFound.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMatchedULugNotFound.Location = New System.Drawing.Point(188, 22)
        Me.btnMatchedULugNotFound.Name = "btnMatchedULugNotFound"
        Me.btnMatchedULugNotFound.Size = New System.Drawing.Size(183, 24)
        Me.btnMatchedULugNotFound.TabIndex = 147
        Me.btnMatchedULugNotFound.Text = "Matching ULug not found"
        Me.btnMatchedULugNotFound.UseVisualStyleBackColor = True
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
        Me.LabelGradient2.Text = "Existing ULug Details"
        Me.LabelGradient2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(293, 316)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(154, 23)
        Me.btnAccept.TabIndex = 151
        Me.btnAccept.Text = "Accept"
        Me.btnAccept.UseVisualStyleBackColor = True
        '
        'grbMatchedULugsFound
        '
        Me.grbMatchedULugsFound.Controls.Add(Me.txtPinHoleTole_Neg_Req)
        Me.grbMatchedULugsFound.Controls.Add(Me.txtPinHoleTole_Pos_Req)
        Me.grbMatchedULugsFound.Controls.Add(Me.Label7)
        Me.grbMatchedULugsFound.Controls.Add(Me.Label8)
        Me.grbMatchedULugsFound.Controls.Add(Me.Label3)
        Me.grbMatchedULugsFound.Controls.Add(Me.lblRequired)
        Me.grbMatchedULugsFound.Controls.Add(Me.Label4)
        Me.grbMatchedULugsFound.Controls.Add(Me.Label2)
        Me.grbMatchedULugsFound.Controls.Add(Me.txtPinHoleTole_Neg)
        Me.grbMatchedULugsFound.Controls.Add(Me.txtPinHoleTole_Pos)
        Me.grbMatchedULugsFound.Controls.Add(Me.Label6)
        Me.grbMatchedULugsFound.Controls.Add(Me.rdbDesignaULug)
        Me.grbMatchedULugsFound.Controls.Add(Me.rdbUseSelectedULug)
        Me.grbMatchedULugsFound.Controls.Add(Me.txtRequiredLugWidth)
        Me.grbMatchedULugsFound.Controls.Add(Me.txtRequiredSwingClearance)
        Me.grbMatchedULugsFound.Controls.Add(Me.txtRequiredLugGap)
        Me.grbMatchedULugsFound.Controls.Add(Me.txtRequiredPinHoleSize)
        Me.grbMatchedULugsFound.Controls.Add(Me.txtRequiredLugHeight)
        Me.grbMatchedULugsFound.Controls.Add(Me.txtRequiredLugThickness)
        Me.grbMatchedULugsFound.Controls.Add(Me.lblPinHoleSize)
        Me.grbMatchedULugsFound.Controls.Add(Me.txtPinHoleSize)
        Me.grbMatchedULugsFound.Controls.Add(Me.lblShowImage)
        Me.grbMatchedULugsFound.Controls.Add(Me.lblExistingULugsDetails)
        Me.grbMatchedULugsFound.Controls.Add(Me.lvwExistingLugListView)
        Me.grbMatchedULugsFound.Controls.Add(Me.lblLugHeight)
        Me.grbMatchedULugsFound.Controls.Add(Me.picCastingNo)
        Me.grbMatchedULugsFound.Controls.Add(Me.txtLugHeight)
        Me.grbMatchedULugsFound.Controls.Add(Me.lblLugWidth)
        Me.grbMatchedULugsFound.Controls.Add(Me.txtLugWidth)
        Me.grbMatchedULugsFound.Controls.Add(Me.txtSwingClearance)
        Me.grbMatchedULugsFound.Controls.Add(Me.lblLugsGap)
        Me.grbMatchedULugsFound.Controls.Add(Me.lblSwingClearance)
        Me.grbMatchedULugsFound.Controls.Add(Me.txtLugGap)
        Me.grbMatchedULugsFound.Controls.Add(Me.lblLugThickness)
        Me.grbMatchedULugsFound.Controls.Add(Me.txtLugThickness)
        Me.grbMatchedULugsFound.Controls.Add(Me.btnRodWeldmentScreensDisplayedNext)
        Me.grbMatchedULugsFound.Location = New System.Drawing.Point(7, 14)
        Me.grbMatchedULugsFound.Name = "grbMatchedULugsFound"
        Me.grbMatchedULugsFound.Size = New System.Drawing.Size(559, 345)
        Me.grbMatchedULugsFound.TabIndex = 11
        Me.grbMatchedULugsFound.TabStop = False
        '
        'txtPinHoleTole_Neg_Req
        '
        Me.txtPinHoleTole_Neg_Req.AcceptEnterKeyAsTab = True
        Me.txtPinHoleTole_Neg_Req.ApplyIFLColor = True
        Me.txtPinHoleTole_Neg_Req.AssociateLabel = Nothing
        Me.txtPinHoleTole_Neg_Req.DecimalValue = 2
        Me.txtPinHoleTole_Neg_Req.IFLDataTag = Nothing
        Me.txtPinHoleTole_Neg_Req.InvalidInputCharacters = ""
        Me.txtPinHoleTole_Neg_Req.IsAllowNegative = False
        Me.txtPinHoleTole_Neg_Req.LengthValue = 6
        Me.txtPinHoleTole_Neg_Req.Location = New System.Drawing.Point(200, 229)
        Me.txtPinHoleTole_Neg_Req.MaximumValue = 99999
        Me.txtPinHoleTole_Neg_Req.MaxLength = 6
        Me.txtPinHoleTole_Neg_Req.MinimumValue = 0
        Me.txtPinHoleTole_Neg_Req.Name = "txtPinHoleTole_Neg_Req"
        Me.txtPinHoleTole_Neg_Req.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Neg_Req.StatusMessage = ""
        Me.txtPinHoleTole_Neg_Req.StatusObject = Nothing
        Me.txtPinHoleTole_Neg_Req.TabIndex = 184
        Me.txtPinHoleTole_Neg_Req.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPinHoleTole_Pos_Req
        '
        Me.txtPinHoleTole_Pos_Req.AcceptEnterKeyAsTab = True
        Me.txtPinHoleTole_Pos_Req.ApplyIFLColor = True
        Me.txtPinHoleTole_Pos_Req.AssociateLabel = Nothing
        Me.txtPinHoleTole_Pos_Req.DecimalValue = 2
        Me.txtPinHoleTole_Pos_Req.IFLDataTag = Nothing
        Me.txtPinHoleTole_Pos_Req.InvalidInputCharacters = ""
        Me.txtPinHoleTole_Pos_Req.IsAllowNegative = False
        Me.txtPinHoleTole_Pos_Req.LengthValue = 6
        Me.txtPinHoleTole_Pos_Req.Location = New System.Drawing.Point(200, 203)
        Me.txtPinHoleTole_Pos_Req.MaximumValue = 99999
        Me.txtPinHoleTole_Pos_Req.MaxLength = 6
        Me.txtPinHoleTole_Pos_Req.MinimumValue = 0
        Me.txtPinHoleTole_Pos_Req.Name = "txtPinHoleTole_Pos_Req"
        Me.txtPinHoleTole_Pos_Req.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Pos_Req.StatusMessage = ""
        Me.txtPinHoleTole_Pos_Req.StatusObject = Nothing
        Me.txtPinHoleTole_Pos_Req.TabIndex = 183
        Me.txtPinHoleTole_Pos_Req.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(399, 156)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 182
        Me.Label7.Text = "Available"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(473, 156)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 181
        Me.Label8.Text = "Required"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(136, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 180
        Me.Label3.Text = "Available"
        '
        'lblRequired
        '
        Me.lblRequired.AutoSize = True
        Me.lblRequired.Location = New System.Drawing.Point(210, 159)
        Me.lblRequired.Name = "lblRequired"
        Me.lblRequired.Size = New System.Drawing.Size(50, 13)
        Me.lblRequired.TabIndex = 179
        Me.lblRequired.Text = "Required"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(112, 232)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 178
        Me.Label4.Text = "-"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(112, 206)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 13)
        Me.Label2.TabIndex = 177
        Me.Label2.Text = "+"
        '
        'txtPinHoleTole_Neg
        '
        Me.txtPinHoleTole_Neg.AcceptEnterKeyAsTab = True
        Me.txtPinHoleTole_Neg.ApplyIFLColor = True
        Me.txtPinHoleTole_Neg.AssociateLabel = Nothing
        Me.txtPinHoleTole_Neg.DecimalValue = 2
        Me.txtPinHoleTole_Neg.IFLDataTag = Nothing
        Me.txtPinHoleTole_Neg.InvalidInputCharacters = ""
        Me.txtPinHoleTole_Neg.IsAllowNegative = False
        Me.txtPinHoleTole_Neg.LengthValue = 6
        Me.txtPinHoleTole_Neg.Location = New System.Drawing.Point(128, 229)
        Me.txtPinHoleTole_Neg.MaximumValue = 99999
        Me.txtPinHoleTole_Neg.MaxLength = 6
        Me.txtPinHoleTole_Neg.MinimumValue = 0
        Me.txtPinHoleTole_Neg.Name = "txtPinHoleTole_Neg"
        Me.txtPinHoleTole_Neg.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Neg.StatusMessage = ""
        Me.txtPinHoleTole_Neg.StatusObject = Nothing
        Me.txtPinHoleTole_Neg.TabIndex = 176
        Me.txtPinHoleTole_Neg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPinHoleTole_Pos
        '
        Me.txtPinHoleTole_Pos.AcceptEnterKeyAsTab = True
        Me.txtPinHoleTole_Pos.ApplyIFLColor = True
        Me.txtPinHoleTole_Pos.AssociateLabel = Nothing
        Me.txtPinHoleTole_Pos.DecimalValue = 2
        Me.txtPinHoleTole_Pos.IFLDataTag = Nothing
        Me.txtPinHoleTole_Pos.InvalidInputCharacters = ""
        Me.txtPinHoleTole_Pos.IsAllowNegative = False
        Me.txtPinHoleTole_Pos.LengthValue = 6
        Me.txtPinHoleTole_Pos.Location = New System.Drawing.Point(128, 203)
        Me.txtPinHoleTole_Pos.MaximumValue = 99999
        Me.txtPinHoleTole_Pos.MaxLength = 6
        Me.txtPinHoleTole_Pos.MinimumValue = 0
        Me.txtPinHoleTole_Pos.Name = "txtPinHoleTole_Pos"
        Me.txtPinHoleTole_Pos.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Pos.StatusMessage = ""
        Me.txtPinHoleTole_Pos.StatusObject = Nothing
        Me.txtPinHoleTole_Pos.TabIndex = 174
        Me.txtPinHoleTole_Pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 206)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 175
        Me.Label6.Text = "Pin Hole Tolerance"
        '
        'rdbDesignaULug
        '
        Me.rdbDesignaULug.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdbDesignaULug.AutoSize = True
        Me.rdbDesignaULug.Location = New System.Drawing.Point(428, 299)
        Me.rdbDesignaULug.Name = "rdbDesignaULug"
        Me.rdbDesignaULug.Size = New System.Drawing.Size(96, 17)
        Me.rdbDesignaULug.TabIndex = 114
        Me.rdbDesignaULug.TabStop = True
        Me.rdbDesignaULug.Text = "Design a ULug"
        Me.rdbDesignaULug.UseVisualStyleBackColor = True
        '
        'rdbUseSelectedULug
        '
        Me.rdbUseSelectedULug.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdbUseSelectedULug.AutoSize = True
        Me.rdbUseSelectedULug.Location = New System.Drawing.Point(290, 299)
        Me.rdbUseSelectedULug.Name = "rdbUseSelectedULug"
        Me.rdbUseSelectedULug.Size = New System.Drawing.Size(118, 17)
        Me.rdbUseSelectedULug.TabIndex = 113
        Me.rdbUseSelectedULug.TabStop = True
        Me.rdbUseSelectedULug.Text = "Use Selected ULug"
        Me.rdbUseSelectedULug.UseVisualStyleBackColor = True
        '
        'txtRequiredLugWidth
        '
        Me.txtRequiredLugWidth.AcceptEnterKeyAsTab = True
        Me.txtRequiredLugWidth.ApplyIFLColor = True
        Me.txtRequiredLugWidth.AssociateLabel = Nothing
        Me.txtRequiredLugWidth.DecimalValue = 2
        Me.txtRequiredLugWidth.IFLDataTag = Nothing
        Me.txtRequiredLugWidth.InvalidInputCharacters = ""
        Me.txtRequiredLugWidth.IsAllowNegative = False
        Me.txtRequiredLugWidth.LengthValue = 6
        Me.txtRequiredLugWidth.Location = New System.Drawing.Point(460, 175)
        Me.txtRequiredLugWidth.MaximumValue = 99999
        Me.txtRequiredLugWidth.MaxLength = 6
        Me.txtRequiredLugWidth.MinimumValue = 0
        Me.txtRequiredLugWidth.Name = "txtRequiredLugWidth"
        Me.txtRequiredLugWidth.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredLugWidth.StatusMessage = ""
        Me.txtRequiredLugWidth.StatusObject = Nothing
        Me.txtRequiredLugWidth.TabIndex = 108
        Me.txtRequiredLugWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredSwingClearance
        '
        Me.txtRequiredSwingClearance.AcceptEnterKeyAsTab = True
        Me.txtRequiredSwingClearance.ApplyIFLColor = True
        Me.txtRequiredSwingClearance.AssociateLabel = Nothing
        Me.txtRequiredSwingClearance.DecimalValue = 2
        Me.txtRequiredSwingClearance.IFLDataTag = Nothing
        Me.txtRequiredSwingClearance.InvalidInputCharacters = ""
        Me.txtRequiredSwingClearance.IsAllowNegative = False
        Me.txtRequiredSwingClearance.LengthValue = 6
        Me.txtRequiredSwingClearance.Location = New System.Drawing.Point(460, 200)
        Me.txtRequiredSwingClearance.MaximumValue = 99999
        Me.txtRequiredSwingClearance.MaxLength = 6
        Me.txtRequiredSwingClearance.MinimumValue = 0
        Me.txtRequiredSwingClearance.Name = "txtRequiredSwingClearance"
        Me.txtRequiredSwingClearance.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredSwingClearance.StatusMessage = ""
        Me.txtRequiredSwingClearance.StatusObject = Nothing
        Me.txtRequiredSwingClearance.TabIndex = 109
        Me.txtRequiredSwingClearance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredLugGap
        '
        Me.txtRequiredLugGap.AcceptEnterKeyAsTab = True
        Me.txtRequiredLugGap.ApplyIFLColor = True
        Me.txtRequiredLugGap.AssociateLabel = Nothing
        Me.txtRequiredLugGap.DecimalValue = 2
        Me.txtRequiredLugGap.IFLDataTag = Nothing
        Me.txtRequiredLugGap.InvalidInputCharacters = ""
        Me.txtRequiredLugGap.IsAllowNegative = False
        Me.txtRequiredLugGap.LengthValue = 6
        Me.txtRequiredLugGap.Location = New System.Drawing.Point(460, 225)
        Me.txtRequiredLugGap.MaximumValue = 99999
        Me.txtRequiredLugGap.MaxLength = 6
        Me.txtRequiredLugGap.MinimumValue = 0
        Me.txtRequiredLugGap.Name = "txtRequiredLugGap"
        Me.txtRequiredLugGap.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredLugGap.StatusMessage = ""
        Me.txtRequiredLugGap.StatusObject = Nothing
        Me.txtRequiredLugGap.TabIndex = 110
        Me.txtRequiredLugGap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredPinHoleSize
        '
        Me.txtRequiredPinHoleSize.AcceptEnterKeyAsTab = True
        Me.txtRequiredPinHoleSize.ApplyIFLColor = True
        Me.txtRequiredPinHoleSize.AssociateLabel = Nothing
        Me.txtRequiredPinHoleSize.DecimalValue = 2
        Me.txtRequiredPinHoleSize.IFLDataTag = Nothing
        Me.txtRequiredPinHoleSize.InvalidInputCharacters = ""
        Me.txtRequiredPinHoleSize.IsAllowNegative = False
        Me.txtRequiredPinHoleSize.LengthValue = 6
        Me.txtRequiredPinHoleSize.Location = New System.Drawing.Point(200, 175)
        Me.txtRequiredPinHoleSize.MaximumValue = 99999
        Me.txtRequiredPinHoleSize.MaxLength = 6
        Me.txtRequiredPinHoleSize.MinimumValue = 0
        Me.txtRequiredPinHoleSize.Name = "txtRequiredPinHoleSize"
        Me.txtRequiredPinHoleSize.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredPinHoleSize.StatusMessage = ""
        Me.txtRequiredPinHoleSize.StatusObject = Nothing
        Me.txtRequiredPinHoleSize.TabIndex = 107
        Me.txtRequiredPinHoleSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredLugHeight
        '
        Me.txtRequiredLugHeight.AcceptEnterKeyAsTab = True
        Me.txtRequiredLugHeight.ApplyIFLColor = True
        Me.txtRequiredLugHeight.AssociateLabel = Nothing
        Me.txtRequiredLugHeight.DecimalValue = 2
        Me.txtRequiredLugHeight.IFLDataTag = Nothing
        Me.txtRequiredLugHeight.InvalidInputCharacters = ""
        Me.txtRequiredLugHeight.IsAllowNegative = False
        Me.txtRequiredLugHeight.LengthValue = 6
        Me.txtRequiredLugHeight.Location = New System.Drawing.Point(200, 255)
        Me.txtRequiredLugHeight.MaximumValue = 99999
        Me.txtRequiredLugHeight.MaxLength = 6
        Me.txtRequiredLugHeight.MinimumValue = 0
        Me.txtRequiredLugHeight.Name = "txtRequiredLugHeight"
        Me.txtRequiredLugHeight.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredLugHeight.StatusMessage = ""
        Me.txtRequiredLugHeight.StatusObject = Nothing
        Me.txtRequiredLugHeight.TabIndex = 105
        Me.txtRequiredLugHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredLugThickness
        '
        Me.txtRequiredLugThickness.AcceptEnterKeyAsTab = True
        Me.txtRequiredLugThickness.ApplyIFLColor = True
        Me.txtRequiredLugThickness.AssociateLabel = Nothing
        Me.txtRequiredLugThickness.DecimalValue = 2
        Me.txtRequiredLugThickness.IFLDataTag = Nothing
        Me.txtRequiredLugThickness.InvalidInputCharacters = ""
        Me.txtRequiredLugThickness.IsAllowNegative = False
        Me.txtRequiredLugThickness.LengthValue = 6
        Me.txtRequiredLugThickness.Location = New System.Drawing.Point(200, 280)
        Me.txtRequiredLugThickness.MaximumValue = 99999
        Me.txtRequiredLugThickness.MaxLength = 6
        Me.txtRequiredLugThickness.MinimumValue = 0
        Me.txtRequiredLugThickness.Name = "txtRequiredLugThickness"
        Me.txtRequiredLugThickness.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredLugThickness.StatusMessage = ""
        Me.txtRequiredLugThickness.StatusObject = Nothing
        Me.txtRequiredLugThickness.TabIndex = 106
        Me.txtRequiredLugThickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPinHoleSize
        '
        Me.lblPinHoleSize.AutoSize = True
        Me.lblPinHoleSize.Location = New System.Drawing.Point(5, 178)
        Me.lblPinHoleSize.Name = "lblPinHoleSize"
        Me.lblPinHoleSize.Size = New System.Drawing.Size(70, 13)
        Me.lblPinHoleSize.TabIndex = 104
        Me.lblPinHoleSize.Text = "Pin Hole Size"
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
        Me.txtPinHoleSize.Location = New System.Drawing.Point(128, 175)
        Me.txtPinHoleSize.MaximumValue = 99999
        Me.txtPinHoleSize.MaxLength = 6
        Me.txtPinHoleSize.MinimumValue = 0
        Me.txtPinHoleSize.Name = "txtPinHoleSize"
        Me.txtPinHoleSize.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleSize.StatusMessage = ""
        Me.txtPinHoleSize.StatusObject = Nothing
        Me.txtPinHoleSize.TabIndex = 103
        Me.txtPinHoleSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblShowImage
        '
        Me.lblShowImage.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblShowImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShowImage.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblShowImage.GradientColorOne = System.Drawing.Color.Olive
        Me.lblShowImage.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblShowImage.Location = New System.Drawing.Point(432, 101)
        Me.lblShowImage.Name = "lblShowImage"
        Me.lblShowImage.Size = New System.Drawing.Size(91, 19)
        Me.lblShowImage.TabIndex = 23
        Me.lblShowImage.Text = "Show Image"
        Me.lblShowImage.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblExistingULugsDetails
        '
        Me.lblExistingULugsDetails.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblExistingULugsDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExistingULugsDetails.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblExistingULugsDetails.GradientColorOne = System.Drawing.Color.Olive
        Me.lblExistingULugsDetails.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblExistingULugsDetails.Location = New System.Drawing.Point(-4, 2)
        Me.lblExistingULugsDetails.Name = "lblExistingULugsDetails"
        Me.lblExistingULugsDetails.Size = New System.Drawing.Size(563, 19)
        Me.lblExistingULugsDetails.TabIndex = 22
        Me.lblExistingULugsDetails.Text = "Existing ULug Details"
        Me.lblExistingULugsDetails.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lvwExistingLugListView
        '
        Me.lvwExistingLugListView.GridLines = True
        Me.lvwExistingLugListView.Location = New System.Drawing.Point(14, 32)
        Me.lvwExistingLugListView.Name = "lvwExistingLugListView"
        Me.lvwExistingLugListView.Size = New System.Drawing.Size(390, 116)
        Me.lvwExistingLugListView.TabIndex = 12
        Me.lvwExistingLugListView.UseCompatibleStateImageBehavior = False
        Me.lvwExistingLugListView.View = System.Windows.Forms.View.Details
        '
        'lblLugHeight
        '
        Me.lblLugHeight.AutoSize = True
        Me.lblLugHeight.Location = New System.Drawing.Point(5, 258)
        Me.lblLugHeight.Name = "lblLugHeight"
        Me.lblLugHeight.Size = New System.Drawing.Size(59, 13)
        Me.lblLugHeight.TabIndex = 87
        Me.lblLugHeight.Text = "Lug Height"
        '
        'picCastingNo
        '
        Me.picCastingNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picCastingNo.Location = New System.Drawing.Point(410, 76)
        Me.picCastingNo.Name = "picCastingNo"
        Me.picCastingNo.Size = New System.Drawing.Size(136, 65)
        Me.picCastingNo.TabIndex = 102
        Me.picCastingNo.TabStop = False
        '
        'txtLugHeight
        '
        Me.txtLugHeight.AcceptEnterKeyAsTab = True
        Me.txtLugHeight.ApplyIFLColor = True
        Me.txtLugHeight.AssociateLabel = Nothing
        Me.txtLugHeight.DecimalValue = 2
        Me.txtLugHeight.IFLDataTag = Nothing
        Me.txtLugHeight.InvalidInputCharacters = ""
        Me.txtLugHeight.IsAllowNegative = False
        Me.txtLugHeight.LengthValue = 6
        Me.txtLugHeight.Location = New System.Drawing.Point(128, 255)
        Me.txtLugHeight.MaximumValue = 99999
        Me.txtLugHeight.MaxLength = 6
        Me.txtLugHeight.MinimumValue = 0
        Me.txtLugHeight.Name = "txtLugHeight"
        Me.txtLugHeight.Size = New System.Drawing.Size(66, 20)
        Me.txtLugHeight.StatusMessage = ""
        Me.txtLugHeight.StatusObject = Nothing
        Me.txtLugHeight.TabIndex = 13
        Me.txtLugHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLugWidth
        '
        Me.lblLugWidth.AutoSize = True
        Me.lblLugWidth.Location = New System.Drawing.Point(295, 178)
        Me.lblLugWidth.Name = "lblLugWidth"
        Me.lblLugWidth.Size = New System.Drawing.Size(56, 13)
        Me.lblLugWidth.TabIndex = 89
        Me.lblLugWidth.Text = "Lug Width"
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
        Me.txtLugWidth.Location = New System.Drawing.Point(388, 175)
        Me.txtLugWidth.MaximumValue = 99999
        Me.txtLugWidth.MaxLength = 6
        Me.txtLugWidth.MinimumValue = 0
        Me.txtLugWidth.Name = "txtLugWidth"
        Me.txtLugWidth.Size = New System.Drawing.Size(66, 20)
        Me.txtLugWidth.StatusMessage = ""
        Me.txtLugWidth.StatusObject = Nothing
        Me.txtLugWidth.TabIndex = 14
        Me.txtLugWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.txtSwingClearance.Location = New System.Drawing.Point(388, 200)
        Me.txtSwingClearance.MaximumValue = 99999
        Me.txtSwingClearance.MaxLength = 6
        Me.txtSwingClearance.MinimumValue = 0
        Me.txtSwingClearance.Name = "txtSwingClearance"
        Me.txtSwingClearance.Size = New System.Drawing.Size(66, 20)
        Me.txtSwingClearance.StatusMessage = ""
        Me.txtSwingClearance.StatusObject = Nothing
        Me.txtSwingClearance.TabIndex = 17
        Me.txtSwingClearance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLugsGap
        '
        Me.lblLugsGap.AutoSize = True
        Me.lblLugsGap.Location = New System.Drawing.Point(295, 228)
        Me.lblLugsGap.Name = "lblLugsGap"
        Me.lblLugsGap.Size = New System.Drawing.Size(53, 13)
        Me.lblLugsGap.TabIndex = 93
        Me.lblLugsGap.Text = "Lugs Gap"
        '
        'lblSwingClearance
        '
        Me.lblSwingClearance.AutoSize = True
        Me.lblSwingClearance.Location = New System.Drawing.Point(295, 203)
        Me.lblSwingClearance.Name = "lblSwingClearance"
        Me.lblSwingClearance.Size = New System.Drawing.Size(87, 13)
        Me.lblSwingClearance.TabIndex = 98
        Me.lblSwingClearance.Text = "Swing Clearance"
        '
        'txtLugGap
        '
        Me.txtLugGap.AcceptEnterKeyAsTab = True
        Me.txtLugGap.ApplyIFLColor = True
        Me.txtLugGap.AssociateLabel = Nothing
        Me.txtLugGap.DecimalValue = 2
        Me.txtLugGap.IFLDataTag = Nothing
        Me.txtLugGap.InvalidInputCharacters = ""
        Me.txtLugGap.IsAllowNegative = False
        Me.txtLugGap.LengthValue = 6
        Me.txtLugGap.Location = New System.Drawing.Point(388, 225)
        Me.txtLugGap.MaximumValue = 99999
        Me.txtLugGap.MaxLength = 6
        Me.txtLugGap.MinimumValue = 0
        Me.txtLugGap.Name = "txtLugGap"
        Me.txtLugGap.Size = New System.Drawing.Size(66, 20)
        Me.txtLugGap.StatusMessage = ""
        Me.txtLugGap.StatusObject = Nothing
        Me.txtLugGap.TabIndex = 18
        Me.txtLugGap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLugThickness
        '
        Me.lblLugThickness.AutoSize = True
        Me.lblLugThickness.Location = New System.Drawing.Point(5, 283)
        Me.lblLugThickness.Name = "lblLugThickness"
        Me.lblLugThickness.Size = New System.Drawing.Size(77, 13)
        Me.lblLugThickness.TabIndex = 95
        Me.lblLugThickness.Text = "Lug Thickness"
        '
        'txtLugThickness
        '
        Me.txtLugThickness.AcceptEnterKeyAsTab = True
        Me.txtLugThickness.ApplyIFLColor = True
        Me.txtLugThickness.AssociateLabel = Nothing
        Me.txtLugThickness.DecimalValue = 2
        Me.txtLugThickness.IFLDataTag = Nothing
        Me.txtLugThickness.InvalidInputCharacters = ""
        Me.txtLugThickness.IsAllowNegative = False
        Me.txtLugThickness.LengthValue = 6
        Me.txtLugThickness.Location = New System.Drawing.Point(128, 280)
        Me.txtLugThickness.MaximumValue = 99999
        Me.txtLugThickness.MaxLength = 6
        Me.txtLugThickness.MinimumValue = 0
        Me.txtLugThickness.Name = "txtLugThickness"
        Me.txtLugThickness.Size = New System.Drawing.Size(66, 20)
        Me.txtLugThickness.StatusMessage = ""
        Me.txtLugThickness.StatusObject = Nothing
        Me.txtLugThickness.TabIndex = 16
        Me.txtLugThickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnRodWeldmentScreensDisplayedNext
        '
        Me.btnRodWeldmentScreensDisplayedNext.Enabled = False
        Me.btnRodWeldmentScreensDisplayedNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRodWeldmentScreensDisplayedNext.Location = New System.Drawing.Point(266, 304)
        Me.btnRodWeldmentScreensDisplayedNext.Name = "btnRodWeldmentScreensDisplayedNext"
        Me.btnRodWeldmentScreensDisplayedNext.Size = New System.Drawing.Size(291, 34)
        Me.btnRodWeldmentScreensDisplayedNext.TabIndex = 112
        Me.btnRodWeldmentScreensDisplayedNext.Text = "Rod Weldment Screens Are Displayed Next"
        Me.btnRodWeldmentScreensDisplayedNext.UseVisualStyleBackColor = True
        '
        'pnlFabrication
        '
        Me.pnlFabrication.BackColor = System.Drawing.Color.Ivory
        Me.pnlFabrication.Controls.Add(Me.grbPlateClevis)
        Me.pnlFabrication.Controls.Add(Me.GroupBox1)
        Me.pnlFabrication.Location = New System.Drawing.Point(0, 0)
        Me.pnlFabrication.Name = "pnlFabrication"
        Me.pnlFabrication.Size = New System.Drawing.Size(583, 477)
        Me.pnlFabrication.TabIndex = 5
        '
        'frmDLFabrication
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(583, 477)
        Me.Controls.Add(Me.pnlFabrication)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDLFabrication"
        Me.Text = "frmFabrication"
        Me.grbPlateClevis.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.grbMatchedULugNotFound.ResumeLayout(False)
        Me.pnlSafetyFactor_Weight_LugThickness.ResumeLayout(False)
        Me.pnlDesignULug.ResumeLayout(False)
        Me.pnlDesignULug.PerformLayout()
        CType(Me.trbSafetyFactor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbMatchedULugsFound.ResumeLayout(False)
        Me.grbMatchedULugsFound.PerformLayout()
        CType(Me.picCastingNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFabrication.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grbMatchedULugsFound As System.Windows.Forms.GroupBox
    Friend WithEvents lblShowImage As LabelGradient.LabelGradient
    Friend WithEvents lblExistingULugsDetails As LabelGradient.LabelGradient
    Friend WithEvents lvwExistingLugListView As clsListViewMIL
    Friend WithEvents lblLugHeight As System.Windows.Forms.Label
    Friend WithEvents picCastingNo As System.Windows.Forms.PictureBox
    Friend WithEvents txtLugHeight As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblLugWidth As System.Windows.Forms.Label
    Friend WithEvents txtLugWidth As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtSwingClearance As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblLugsGap As System.Windows.Forms.Label
    Friend WithEvents lblSwingClearance As System.Windows.Forms.Label
    Friend WithEvents txtLugGap As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblLugThickness As System.Windows.Forms.Label
    Friend WithEvents txtLugThickness As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents grbPlateClevis As System.Windows.Forms.GroupBox
    Friend WithEvents btnPlateClevis As System.Windows.Forms.Button
    Friend WithEvents UcBrowsePlateClevis1 As Monarch_WeldedCylinder_01_09_09.ucBrowsePlateClevis
    Friend WithEvents lblPinHoleSize As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleSize As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredPinHoleSize As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredLugHeight As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredLugThickness As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredLugWidth As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredSwingClearance As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredLugGap As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents btnRodWeldmentScreensDisplayedNext As System.Windows.Forms.Button
    Friend WithEvents rdbUseSelectedULug As System.Windows.Forms.RadioButton
    Friend WithEvents rdbDesignaULug As System.Windows.Forms.RadioButton
    Friend WithEvents grbMatchedULugNotFound As System.Windows.Forms.GroupBox
    Friend WithEvents pnlDesignULug As System.Windows.Forms.Panel
    Friend WithEvents txtSafetyFactor_DesignULug As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLugThickness_DesignULug As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSafetyFactor As System.Windows.Forms.Label
    Friend WithEvents trbSafetyFactor As System.Windows.Forms.TrackBar
    Friend WithEvents lblDesignNewCasting As LabelGradient.LabelGradient
    Friend WithEvents btnAccept As System.Windows.Forms.Button
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents lblLugWidth2 As System.Windows.Forms.Label
    Friend WithEvents txtLugWidth_DesignULug As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtSwingClearance_DesignULug As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSwingClearance2 As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleSize_DesignULug As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblLugGap As System.Windows.Forms.Label
    Friend WithEvents txtLugGap_DesignULug As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents btnMatchedULugNotFound As System.Windows.Forms.Button
    Friend WithEvents LabelGradient2 As LabelGradient.LabelGradient
    Friend WithEvents pnlFabrication As System.Windows.Forms.Panel
    Friend WithEvents pnlSafetyFactor_Weight_LugThickness As System.Windows.Forms.Panel
    Friend WithEvents lvwSafetyFactor_Weight As Monarch_WeldedCylinder_01_09_09.clsListViewMIL
    Friend WithEvents lblSafetyFactorIndex As LabelGradient.LabelGradient
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleTole_Neg As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtPinHoleTole_Pos As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblRequired As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleTole_Neg_Req As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtPinHoleTole_Pos_Req As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents chkOptimizer As System.Windows.Forms.CheckBox
End Class
