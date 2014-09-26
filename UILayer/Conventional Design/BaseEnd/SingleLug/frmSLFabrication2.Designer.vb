<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSLFabrication2
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
        Me.rdbUseSelectedSingleLug = New System.Windows.Forms.RadioButton
        Me.txtRequiredLugWidth = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredSwingClearance = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredLugGap = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredPinHoleSize = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredLugHeight = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredLugThickness = New IFLCustomUILayer.IFLNumericBox
        Me.lblPinHoleSize = New System.Windows.Forms.Label
        Me.txtPinHoleSize = New IFLCustomUILayer.IFLNumericBox
        Me.lblShowImage = New LabelGradient.LabelGradient
        Me.lblExistingSingleLugsDetails = New LabelGradient.LabelGradient
        Me.lblLugHeight = New System.Windows.Forms.Label
        Me.pnlFabrication = New System.Windows.Forms.Panel
        Me.grbPlateClevis = New System.Windows.Forms.GroupBox
        Me.btnPlateClevis = New System.Windows.Forms.Button
        Me.UcBrowsePlateClevis1 = New Monarch_WeldedCylinder_01_09_09.ucBrowsePlateClevis
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
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
        Me.btnMatchedSingleLugNotFound = New System.Windows.Forms.Button
        Me.LabelGradient2 = New LabelGradient.LabelGradient
        Me.btnAccept = New System.Windows.Forms.Button
        Me.grbMatchedSingleLugsFound = New System.Windows.Forms.GroupBox
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
        Me.rdbDesignaSingleLug = New System.Windows.Forms.RadioButton
        Me.lvwExistingSingleLugListView = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL
        Me.picCastingNo = New System.Windows.Forms.PictureBox
        Me.txtLugHeight = New IFLCustomUILayer.IFLNumericBox
        Me.lblLugWidth = New System.Windows.Forms.Label
        Me.txtLugWidth = New IFLCustomUILayer.IFLNumericBox
        Me.txtSwingClearance = New IFLCustomUILayer.IFLNumericBox
        Me.lblLugGap = New System.Windows.Forms.Label
        Me.lblSwingClearance = New System.Windows.Forms.Label
        Me.txtLugGap = New IFLCustomUILayer.IFLNumericBox
        Me.lblLugThickness = New System.Windows.Forms.Label
        Me.txtLugThickness = New IFLCustomUILayer.IFLNumericBox
        Me.btnRodWeldmentScreensDisplayedNext = New System.Windows.Forms.Button
        Me.pnlFabrication.SuspendLayout()
        Me.grbPlateClevis.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grbMatchedSingleLugNotFound.SuspendLayout()
        Me.pnlSafetyFactor_Weight_LugThickness.SuspendLayout()
        Me.pnlDesignSingleLug.SuspendLayout()
        CType(Me.trbSafetyFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbMatchedSingleLugsFound.SuspendLayout()
        CType(Me.picCastingNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rdbUseSelectedSingleLug
        '
        Me.rdbUseSelectedSingleLug.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdbUseSelectedSingleLug.AutoSize = True
        Me.rdbUseSelectedSingleLug.Location = New System.Drawing.Point(276, 273)
        Me.rdbUseSelectedSingleLug.Name = "rdbUseSelectedSingleLug"
        Me.rdbUseSelectedSingleLug.Size = New System.Drawing.Size(139, 17)
        Me.rdbUseSelectedSingleLug.TabIndex = 113
        Me.rdbUseSelectedSingleLug.TabStop = True
        Me.rdbUseSelectedSingleLug.Text = "Use Selected SingleLug"
        Me.rdbUseSelectedSingleLug.UseVisualStyleBackColor = True
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
        Me.txtRequiredLugWidth.Location = New System.Drawing.Point(483, 160)
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
        Me.txtRequiredSwingClearance.Location = New System.Drawing.Point(483, 185)
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
        Me.txtRequiredLugGap.Location = New System.Drawing.Point(483, 210)
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
        Me.txtRequiredPinHoleSize.Location = New System.Drawing.Point(199, 186)
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
        Me.txtRequiredLugHeight.Location = New System.Drawing.Point(199, 265)
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
        Me.txtRequiredLugThickness.Location = New System.Drawing.Point(199, 290)
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
        Me.lblPinHoleSize.Location = New System.Drawing.Point(4, 189)
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
        Me.txtPinHoleSize.Location = New System.Drawing.Point(127, 186)
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
        Me.lblShowImage.Location = New System.Drawing.Point(432, 97)
        Me.lblShowImage.Name = "lblShowImage"
        Me.lblShowImage.Size = New System.Drawing.Size(91, 19)
        Me.lblShowImage.TabIndex = 23
        Me.lblShowImage.Text = "Show Image"
        Me.lblShowImage.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblExistingSingleLugsDetails
        '
        Me.lblExistingSingleLugsDetails.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblExistingSingleLugsDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExistingSingleLugsDetails.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblExistingSingleLugsDetails.GradientColorOne = System.Drawing.Color.Olive
        Me.lblExistingSingleLugsDetails.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblExistingSingleLugsDetails.Location = New System.Drawing.Point(-4, 2)
        Me.lblExistingSingleLugsDetails.Name = "lblExistingSingleLugsDetails"
        Me.lblExistingSingleLugsDetails.Size = New System.Drawing.Size(563, 19)
        Me.lblExistingSingleLugsDetails.TabIndex = 22
        Me.lblExistingSingleLugsDetails.Text = "Existing SingleLug Details2"
        Me.lblExistingSingleLugsDetails.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLugHeight
        '
        Me.lblLugHeight.AutoSize = True
        Me.lblLugHeight.Location = New System.Drawing.Point(5, 268)
        Me.lblLugHeight.Name = "lblLugHeight"
        Me.lblLugHeight.Size = New System.Drawing.Size(59, 13)
        Me.lblLugHeight.TabIndex = 87
        Me.lblLugHeight.Text = "Lug Height"
        '
        'pnlFabrication
        '
        Me.pnlFabrication.BackColor = System.Drawing.Color.Ivory
        Me.pnlFabrication.Controls.Add(Me.grbPlateClevis)
        Me.pnlFabrication.Controls.Add(Me.GroupBox1)
        Me.pnlFabrication.Location = New System.Drawing.Point(0, 0)
        Me.pnlFabrication.Name = "pnlFabrication"
        Me.pnlFabrication.Size = New System.Drawing.Size(583, 477)
        Me.pnlFabrication.TabIndex = 6
        '
        'grbPlateClevis
        '
        Me.grbPlateClevis.Controls.Add(Me.btnPlateClevis)
        Me.grbPlateClevis.Controls.Add(Me.UcBrowsePlateClevis1)
        Me.grbPlateClevis.Location = New System.Drawing.Point(12, 4)
        Me.grbPlateClevis.Name = "grbPlateClevis"
        Me.grbPlateClevis.Size = New System.Drawing.Size(560, 99)
        Me.grbPlateClevis.TabIndex = 146
        Me.grbPlateClevis.TabStop = False
        Me.grbPlateClevis.Text = "Plate Clevis"
        '
        'btnPlateClevis
        '
        Me.btnPlateClevis.Enabled = False
        Me.btnPlateClevis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPlateClevis.Location = New System.Drawing.Point(103, 31)
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
        Me.UcBrowsePlateClevis1.Location = New System.Drawing.Point(17, 19)
        Me.UcBrowsePlateClevis1.Name = "UcBrowsePlateClevis1"
        Me.UcBrowsePlateClevis1.ObjFrmImportPlateClevis = Nothing
        Me.UcBrowsePlateClevis1.Size = New System.Drawing.Size(533, 74)
        Me.UcBrowsePlateClevis1.TabIndex = 107
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grbMatchedSingleLugsFound)
        Me.GroupBox1.Controls.Add(Me.grbMatchedSingleLugNotFound)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 109)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(571, 359)
        Me.GroupBox1.TabIndex = 147
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Single Lug"
        '
        'grbMatchedSingleLugNotFound
        '
        Me.grbMatchedSingleLugNotFound.Controls.Add(Me.pnlSafetyFactor_Weight_LugThickness)
        Me.grbMatchedSingleLugNotFound.Controls.Add(Me.pnlDesignSingleLug)
        Me.grbMatchedSingleLugNotFound.Controls.Add(Me.btnMatchedSingleLugNotFound)
        Me.grbMatchedSingleLugNotFound.Controls.Add(Me.LabelGradient2)
        Me.grbMatchedSingleLugNotFound.Controls.Add(Me.btnAccept)
        Me.grbMatchedSingleLugNotFound.Location = New System.Drawing.Point(7, 16)
        Me.grbMatchedSingleLugNotFound.Name = "grbMatchedSingleLugNotFound"
        Me.grbMatchedSingleLugNotFound.Size = New System.Drawing.Size(559, 343)
        Me.grbMatchedSingleLugNotFound.TabIndex = 147
        Me.grbMatchedSingleLugNotFound.TabStop = False
        '
        'pnlSafetyFactor_Weight_LugThickness
        '
        Me.pnlSafetyFactor_Weight_LugThickness.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlSafetyFactor_Weight_LugThickness.Controls.Add(Me.lvwSafetyFactor_Weight)
        Me.pnlSafetyFactor_Weight_LugThickness.Controls.Add(Me.lblSafetyFactorIndex)
        Me.pnlSafetyFactor_Weight_LugThickness.Location = New System.Drawing.Point(57, 203)
        Me.pnlSafetyFactor_Weight_LugThickness.Name = "pnlSafetyFactor_Weight_LugThickness"
        Me.pnlSafetyFactor_Weight_LugThickness.Size = New System.Drawing.Size(445, 110)
        Me.pnlSafetyFactor_Weight_LugThickness.TabIndex = 149
        '
        'lvwSafetyFactor_Weight
        '
        Me.lvwSafetyFactor_Weight.GridLines = True
        Me.lvwSafetyFactor_Weight.Location = New System.Drawing.Point(25, 21)
        Me.lvwSafetyFactor_Weight.Name = "lvwSafetyFactor_Weight"
        Me.lvwSafetyFactor_Weight.Size = New System.Drawing.Size(390, 81)
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
        Me.pnlDesignSingleLug.Location = New System.Drawing.Point(57, 52)
        Me.pnlDesignSingleLug.Name = "pnlDesignSingleLug"
        Me.pnlDesignSingleLug.Size = New System.Drawing.Size(445, 148)
        Me.pnlDesignSingleLug.TabIndex = 148
        '
        'chkOptimizer
        '
        Me.chkOptimizer.AutoSize = True
        Me.chkOptimizer.Location = New System.Drawing.Point(324, 124)
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
        Me.Label5.Location = New System.Drawing.Point(50, 67)
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
        Me.trbSafetyFactor.Location = New System.Drawing.Point(113, 19)
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
        Me.txtLugThickness_DesignSingleLug.Location = New System.Drawing.Point(133, 64)
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
        Me.btnGenerate.Location = New System.Drawing.Point(161, 118)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(118, 23)
        Me.btnGenerate.TabIndex = 150
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'lblLugWidth2
        '
        Me.lblLugWidth2.AutoSize = True
        Me.lblLugWidth2.Location = New System.Drawing.Point(50, 94)
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
        Me.txtLugWidth_DesignSingleLug.Location = New System.Drawing.Point(133, 91)
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
        Me.txtSwingClearance_DesignSingleLug.Location = New System.Drawing.Point(324, 91)
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
        Me.lblSwingClearance2.Location = New System.Drawing.Point(227, 94)
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
        Me.txtPinHoleSize_DesignSingleLug.Location = New System.Drawing.Point(324, 64)
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
        Me.Label1.Location = New System.Drawing.Point(227, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 147
        Me.Label1.Text = "Pin Hole Size"
        '
        'btnMatchedSingleLugNotFound
        '
        Me.btnMatchedSingleLugNotFound.Enabled = False
        Me.btnMatchedSingleLugNotFound.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMatchedSingleLugNotFound.Location = New System.Drawing.Point(188, 24)
        Me.btnMatchedSingleLugNotFound.Name = "btnMatchedSingleLugNotFound"
        Me.btnMatchedSingleLugNotFound.Size = New System.Drawing.Size(183, 24)
        Me.btnMatchedSingleLugNotFound.TabIndex = 147
        Me.btnMatchedSingleLugNotFound.Text = "Matching SingleLug not found"
        Me.btnMatchedSingleLugNotFound.UseVisualStyleBackColor = True
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
        Me.LabelGradient2.Text = "Existing SingleLug Details"
        Me.LabelGradient2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(220, 313)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(118, 23)
        Me.btnAccept.TabIndex = 151
        Me.btnAccept.Text = "Accept"
        Me.btnAccept.UseVisualStyleBackColor = True
        '
        'grbMatchedSingleLugsFound
        '
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.txtPinHoleTole_Neg_Req)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.txtPinHoleTole_Pos_Req)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.Label7)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.Label8)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.Label3)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.lblRequired)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.Label4)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.Label2)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.txtPinHoleTole_Neg)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.txtPinHoleTole_Pos)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.Label6)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.rdbDesignaSingleLug)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.rdbUseSelectedSingleLug)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.txtRequiredLugWidth)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.txtRequiredSwingClearance)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.txtRequiredLugGap)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.txtRequiredPinHoleSize)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.txtRequiredLugHeight)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.txtRequiredLugThickness)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.lblPinHoleSize)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.txtPinHoleSize)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.lblShowImage)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.lblExistingSingleLugsDetails)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.lvwExistingSingleLugListView)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.lblLugHeight)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.picCastingNo)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.txtLugHeight)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.lblLugWidth)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.txtLugWidth)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.txtSwingClearance)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.lblLugGap)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.lblSwingClearance)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.txtLugGap)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.lblLugThickness)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.txtLugThickness)
        Me.grbMatchedSingleLugsFound.Controls.Add(Me.btnRodWeldmentScreensDisplayedNext)
        Me.grbMatchedSingleLugsFound.Location = New System.Drawing.Point(7, 16)
        Me.grbMatchedSingleLugsFound.Name = "grbMatchedSingleLugsFound"
        Me.grbMatchedSingleLugsFound.Size = New System.Drawing.Size(559, 337)
        Me.grbMatchedSingleLugsFound.TabIndex = 11
        Me.grbMatchedSingleLugsFound.TabStop = False
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
        Me.txtPinHoleTole_Neg_Req.Location = New System.Drawing.Point(199, 241)
        Me.txtPinHoleTole_Neg_Req.MaximumValue = 99999
        Me.txtPinHoleTole_Neg_Req.MaxLength = 6
        Me.txtPinHoleTole_Neg_Req.MinimumValue = 0
        Me.txtPinHoleTole_Neg_Req.Name = "txtPinHoleTole_Neg_Req"
        Me.txtPinHoleTole_Neg_Req.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Neg_Req.StatusMessage = ""
        Me.txtPinHoleTole_Neg_Req.StatusObject = Nothing
        Me.txtPinHoleTole_Neg_Req.TabIndex = 189
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
        Me.txtPinHoleTole_Pos_Req.Location = New System.Drawing.Point(199, 215)
        Me.txtPinHoleTole_Pos_Req.MaximumValue = 99999
        Me.txtPinHoleTole_Pos_Req.MaxLength = 6
        Me.txtPinHoleTole_Pos_Req.MinimumValue = 0
        Me.txtPinHoleTole_Pos_Req.Name = "txtPinHoleTole_Pos_Req"
        Me.txtPinHoleTole_Pos_Req.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Pos_Req.StatusMessage = ""
        Me.txtPinHoleTole_Pos_Req.StatusObject = Nothing
        Me.txtPinHoleTole_Pos_Req.TabIndex = 188
        Me.txtPinHoleTole_Pos_Req.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(414, 144)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 187
        Me.Label7.Text = "Available"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(480, 144)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 186
        Me.Label8.Text = "Required"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(130, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 185
        Me.Label3.Text = "Available"
        '
        'lblRequired
        '
        Me.lblRequired.AutoSize = True
        Me.lblRequired.Location = New System.Drawing.Point(196, 163)
        Me.lblRequired.Name = "lblRequired"
        Me.lblRequired.Size = New System.Drawing.Size(50, 13)
        Me.lblRequired.TabIndex = 184
        Me.lblRequired.Text = "Required"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(111, 244)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 183
        Me.Label4.Text = "-"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(111, 218)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(14, 13)
        Me.Label2.TabIndex = 182
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
        Me.txtPinHoleTole_Neg.Location = New System.Drawing.Point(127, 241)
        Me.txtPinHoleTole_Neg.MaximumValue = 99999
        Me.txtPinHoleTole_Neg.MaxLength = 6
        Me.txtPinHoleTole_Neg.MinimumValue = 0
        Me.txtPinHoleTole_Neg.Name = "txtPinHoleTole_Neg"
        Me.txtPinHoleTole_Neg.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Neg.StatusMessage = ""
        Me.txtPinHoleTole_Neg.StatusObject = Nothing
        Me.txtPinHoleTole_Neg.TabIndex = 181
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
        Me.txtPinHoleTole_Pos.Location = New System.Drawing.Point(127, 215)
        Me.txtPinHoleTole_Pos.MaximumValue = 99999
        Me.txtPinHoleTole_Pos.MaxLength = 6
        Me.txtPinHoleTole_Pos.MinimumValue = 0
        Me.txtPinHoleTole_Pos.Name = "txtPinHoleTole_Pos"
        Me.txtPinHoleTole_Pos.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Pos.StatusMessage = ""
        Me.txtPinHoleTole_Pos.StatusObject = Nothing
        Me.txtPinHoleTole_Pos.TabIndex = 179
        Me.txtPinHoleTole_Pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 218)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 180
        Me.Label6.Text = "Pin Hole Tolerance"
        '
        'rdbDesignaSingleLug
        '
        Me.rdbDesignaSingleLug.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdbDesignaSingleLug.AutoSize = True
        Me.rdbDesignaSingleLug.Location = New System.Drawing.Point(429, 273)
        Me.rdbDesignaSingleLug.Name = "rdbDesignaSingleLug"
        Me.rdbDesignaSingleLug.Size = New System.Drawing.Size(117, 17)
        Me.rdbDesignaSingleLug.TabIndex = 114
        Me.rdbDesignaSingleLug.TabStop = True
        Me.rdbDesignaSingleLug.Text = "Design a SingleLug"
        Me.rdbDesignaSingleLug.UseVisualStyleBackColor = True
        '
        'lvwExistingSingleLugListView
        '
        Me.lvwExistingSingleLugListView.GridLines = True
        Me.lvwExistingSingleLugListView.Location = New System.Drawing.Point(14, 31)
        Me.lvwExistingSingleLugListView.Name = "lvwExistingSingleLugListView"
        Me.lvwExistingSingleLugListView.Size = New System.Drawing.Size(390, 116)
        Me.lvwExistingSingleLugListView.TabIndex = 12
        Me.lvwExistingSingleLugListView.UseCompatibleStateImageBehavior = False
        Me.lvwExistingSingleLugListView.View = System.Windows.Forms.View.Details
        '
        'picCastingNo
        '
        Me.picCastingNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picCastingNo.Location = New System.Drawing.Point(410, 72)
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
        Me.txtLugHeight.Location = New System.Drawing.Point(127, 265)
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
        Me.lblLugWidth.Location = New System.Drawing.Point(318, 163)
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
        Me.txtLugWidth.Location = New System.Drawing.Point(411, 160)
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
        Me.txtSwingClearance.Location = New System.Drawing.Point(411, 185)
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
        'lblLugGap
        '
        Me.lblLugGap.AutoSize = True
        Me.lblLugGap.Location = New System.Drawing.Point(318, 213)
        Me.lblLugGap.Name = "lblLugGap"
        Me.lblLugGap.Size = New System.Drawing.Size(48, 13)
        Me.lblLugGap.TabIndex = 93
        Me.lblLugGap.Text = "Lug Gap"
        '
        'lblSwingClearance
        '
        Me.lblSwingClearance.AutoSize = True
        Me.lblSwingClearance.Location = New System.Drawing.Point(318, 188)
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
        Me.txtLugGap.Location = New System.Drawing.Point(411, 210)
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
        Me.lblLugThickness.Location = New System.Drawing.Point(5, 293)
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
        Me.txtLugThickness.Location = New System.Drawing.Point(127, 290)
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
        Me.btnRodWeldmentScreensDisplayedNext.Location = New System.Drawing.Point(267, 282)
        Me.btnRodWeldmentScreensDisplayedNext.Name = "btnRodWeldmentScreensDisplayedNext"
        Me.btnRodWeldmentScreensDisplayedNext.Size = New System.Drawing.Size(291, 34)
        Me.btnRodWeldmentScreensDisplayedNext.TabIndex = 112
        Me.btnRodWeldmentScreensDisplayedNext.Text = "Rod Weldment Screens Are Displayed Next"
        Me.btnRodWeldmentScreensDisplayedNext.UseVisualStyleBackColor = True
        '
        'frmSLFabrication2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(583, 477)
        Me.Controls.Add(Me.pnlFabrication)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSLFabrication2"
        Me.Text = "frmSLFabrication"
        Me.pnlFabrication.ResumeLayout(False)
        Me.grbPlateClevis.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.grbMatchedSingleLugNotFound.ResumeLayout(False)
        Me.pnlSafetyFactor_Weight_LugThickness.ResumeLayout(False)
        Me.pnlDesignSingleLug.ResumeLayout(False)
        Me.pnlDesignSingleLug.PerformLayout()
        CType(Me.trbSafetyFactor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbMatchedSingleLugsFound.ResumeLayout(False)
        Me.grbMatchedSingleLugsFound.PerformLayout()
        CType(Me.picCastingNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rdbUseSelectedSingleLug As System.Windows.Forms.RadioButton
    Friend WithEvents txtRequiredLugWidth As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredSwingClearance As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredLugGap As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredPinHoleSize As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredLugHeight As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredLugThickness As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblPinHoleSize As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleSize As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblShowImage As LabelGradient.LabelGradient
    Friend WithEvents lblExistingSingleLugsDetails As LabelGradient.LabelGradient
    Friend WithEvents lvwExistingSingleLugListView As Monarch_WeldedCylinder_01_09_09.clsListViewMIL
    Friend WithEvents lblLugHeight As System.Windows.Forms.Label
    Friend WithEvents pnlFabrication As System.Windows.Forms.Panel
    Friend WithEvents grbPlateClevis As System.Windows.Forms.GroupBox
    Friend WithEvents btnPlateClevis As System.Windows.Forms.Button
    Friend WithEvents UcBrowsePlateClevis1 As Monarch_WeldedCylinder_01_09_09.ucBrowsePlateClevis
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grbMatchedSingleLugNotFound As System.Windows.Forms.GroupBox
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
    Friend WithEvents btnMatchedSingleLugNotFound As System.Windows.Forms.Button
    Friend WithEvents LabelGradient2 As LabelGradient.LabelGradient
    Friend WithEvents grbMatchedSingleLugsFound As System.Windows.Forms.GroupBox
    Friend WithEvents rdbDesignaSingleLug As System.Windows.Forms.RadioButton
    Friend WithEvents picCastingNo As System.Windows.Forms.PictureBox
    Friend WithEvents txtLugHeight As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblLugWidth As System.Windows.Forms.Label
    Friend WithEvents txtLugWidth As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtSwingClearance As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblLugGap As System.Windows.Forms.Label
    Friend WithEvents lblSwingClearance As System.Windows.Forms.Label
    Friend WithEvents txtLugGap As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblLugThickness As System.Windows.Forms.Label
    Friend WithEvents txtLugThickness As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents btnRodWeldmentScreensDisplayedNext As System.Windows.Forms.Button
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
