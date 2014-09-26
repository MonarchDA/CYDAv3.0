<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCTFabrication
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
        Me.rdbUseSelectedULug = New System.Windows.Forms.RadioButton()
        Me.lblShowImage = New LabelGradient.LabelGradient()
        Me.lblExistingULugsDetails = New LabelGradient.LabelGradient()
        Me.pnlFabrication = New System.Windows.Forms.Panel()
        Me.grbPlateClevis = New System.Windows.Forms.GroupBox()
        Me.btnPlateClevis = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grbMatchedCrossTubeFound = New System.Windows.Forms.GroupBox()
        Me.txtPinHoleTole_Neg_Req = New IFLCustomUILayer.IFLNumericBox()
        Me.txtPinHoleTole_Pos_Req = New IFLCustomUILayer.IFLNumericBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblRequired = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPinHoleTole_Neg = New IFLCustomUILayer.IFLNumericBox()
        Me.txtPinHoleTole_Pos = New IFLCustomUILayer.IFLNumericBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRequiredAngle2 = New IFLCustomUILayer.IFLNumericBox()
        Me.txtRequiredAngle1 = New IFLCustomUILayer.IFLNumericBox()
        Me.txtRequiredGreaseZerk = New IFLCustomUILayer.IFLNumericBox()
        Me.txtRequiredCrossTubeWidth = New IFLCustomUILayer.IFLNumericBox()
        Me.txtRequiredPinHoleSize = New IFLCustomUILayer.IFLNumericBox()
        Me.txtCrossTubeWidth = New IFLCustomUILayer.IFLNumericBox()
        Me.lblCrossTubeWidth = New System.Windows.Forms.Label()
        Me.txtAngle2 = New IFLCustomUILayer.IFLNumericBox()
        Me.lblAngle2 = New System.Windows.Forms.Label()
        Me.txtAngle1 = New IFLCustomUILayer.IFLNumericBox()
        Me.lblAngle1 = New System.Windows.Forms.Label()
        Me.txtGreaseZerk = New IFLCustomUILayer.IFLNumericBox()
        Me.lblGreaseZerk = New System.Windows.Forms.Label()
        Me.txtPinHoleSize = New IFLCustomUILayer.IFLNumericBox()
        Me.lblPinHoleSize = New System.Windows.Forms.Label()
        Me.txtCrossTubeOD = New IFLCustomUILayer.IFLNumericBox()
        Me.lblCrossTubeOD = New System.Windows.Forms.Label()
        Me.rdbDesignaCrossTube = New System.Windows.Forms.RadioButton()
        Me.picCastingNo = New System.Windows.Forms.PictureBox()
        Me.grbMatchedCrossTubeNotFound = New System.Windows.Forms.GroupBox()
        Me.pnlSafetyFactor_Weight_LugThickness = New System.Windows.Forms.Panel()
        Me.lblSafetyFactorIndex = New LabelGradient.LabelGradient()
        Me.pnlDesignULug = New System.Windows.Forms.Panel()
        Me.chkOptimizer = New System.Windows.Forms.CheckBox()
        Me.txtSafetyFactor_DesignCrossTube = New IFLCustomUILayer.IFLNumericBox()
        Me.lblCrossTubeWidth_DesignNewCrossTube = New System.Windows.Forms.Label()
        Me.lblSafetyFactor = New System.Windows.Forms.Label()
        Me.trbSafetyFactor = New System.Windows.Forms.TrackBar()
        Me.txtCrossTubeWidth_DesignCrossTube = New IFLCustomUILayer.IFLNumericBox()
        Me.lblDesignNewCasting = New LabelGradient.LabelGradient()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.lblCrossTubeOD_DesignCrossTube = New System.Windows.Forms.Label()
        Me.txtCrossTubeOD_DesignCrossTube = New IFLCustomUILayer.IFLNumericBox()
        Me.txtSwingClearance_DesignCrossTube = New IFLCustomUILayer.IFLNumericBox()
        Me.lblSwingClearance2 = New System.Windows.Forms.Label()
        Me.txtPinHoleSize_DesignCrossTube = New IFLCustomUILayer.IFLNumericBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnMatchedULugNotFound = New System.Windows.Forms.Button()
        Me.LabelGradient2 = New LabelGradient.LabelGradient()
        Me.btnAccept = New System.Windows.Forms.Button()
        Me.UcBrowsePlateClevis1 = New Monarch_WeldedCylinder_01_09_09.ucBrowsePlateClevis()
        Me.lvwExistingCrossTubeListView = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL()
        Me.lvwSafetyFactor_Weight = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL()
        Me.pnlFabrication.SuspendLayout()
        Me.grbPlateClevis.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grbMatchedCrossTubeFound.SuspendLayout()
        CType(Me.picCastingNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbMatchedCrossTubeNotFound.SuspendLayout()
        Me.pnlSafetyFactor_Weight_LugThickness.SuspendLayout()
        Me.pnlDesignULug.SuspendLayout()
        CType(Me.trbSafetyFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rdbUseSelectedULug
        '
        Me.rdbUseSelectedULug.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdbUseSelectedULug.AutoSize = True
        Me.rdbUseSelectedULug.Location = New System.Drawing.Point(261, 326)
        Me.rdbUseSelectedULug.Name = "rdbUseSelectedULug"
        Me.rdbUseSelectedULug.Size = New System.Drawing.Size(143, 17)
        Me.rdbUseSelectedULug.TabIndex = 113
        Me.rdbUseSelectedULug.TabStop = True
        Me.rdbUseSelectedULug.Text = "Use Selected CrossTube"
        Me.rdbUseSelectedULug.UseVisualStyleBackColor = True
        '
        'lblShowImage
        '
        Me.lblShowImage.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblShowImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShowImage.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblShowImage.GradientColorOne = System.Drawing.Color.Olive
        Me.lblShowImage.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblShowImage.Location = New System.Drawing.Point(432, 117)
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
        Me.lblExistingULugsDetails.Text = "Existing CrossTube Details"
        Me.lblExistingULugsDetails.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlFabrication
        '
        Me.pnlFabrication.AutoScroll = True
        Me.pnlFabrication.BackColor = System.Drawing.Color.Ivory
        Me.pnlFabrication.Controls.Add(Me.grbPlateClevis)
        Me.pnlFabrication.Controls.Add(Me.GroupBox1)
        Me.pnlFabrication.Location = New System.Drawing.Point(0, 0)
        Me.pnlFabrication.Name = "pnlFabrication"
        Me.pnlFabrication.Size = New System.Drawing.Size(575, 473)
        Me.pnlFabrication.TabIndex = 6
        '
        'grbPlateClevis
        '
        Me.grbPlateClevis.Controls.Add(Me.btnPlateClevis)
        Me.grbPlateClevis.Controls.Add(Me.UcBrowsePlateClevis1)
        Me.grbPlateClevis.Location = New System.Drawing.Point(4, 1)
        Me.grbPlateClevis.Name = "grbPlateClevis"
        Me.grbPlateClevis.Size = New System.Drawing.Size(566, 89)
        Me.grbPlateClevis.TabIndex = 146
        Me.grbPlateClevis.TabStop = False
        Me.grbPlateClevis.Text = "Plate Clevis"
        '
        'btnPlateClevis
        '
        Me.btnPlateClevis.Enabled = False
        Me.btnPlateClevis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPlateClevis.Location = New System.Drawing.Point(152, 34)
        Me.btnPlateClevis.Name = "btnPlateClevis"
        Me.btnPlateClevis.Size = New System.Drawing.Size(291, 34)
        Me.btnPlateClevis.TabIndex = 145
        Me.btnPlateClevis.Text = "Matching Plate Clevis found"
        Me.btnPlateClevis.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grbMatchedCrossTubeFound)
        Me.GroupBox1.Controls.Add(Me.grbMatchedCrossTubeNotFound)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 96)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(571, 376)
        Me.GroupBox1.TabIndex = 147
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cross Tube"
        '
        'grbMatchedCrossTubeFound
        '
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.txtPinHoleTole_Neg_Req)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.txtPinHoleTole_Pos_Req)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.Label6)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.Label7)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.Label5)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.lblRequired)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.Label4)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.Label3)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.txtPinHoleTole_Neg)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.txtPinHoleTole_Pos)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.Label2)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.txtRequiredAngle2)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.txtRequiredAngle1)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.txtRequiredGreaseZerk)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.txtRequiredCrossTubeWidth)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.txtRequiredPinHoleSize)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.txtCrossTubeWidth)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.lblCrossTubeWidth)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.txtAngle2)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.lblAngle2)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.txtAngle1)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.lblAngle1)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.txtGreaseZerk)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.lblGreaseZerk)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.txtPinHoleSize)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.lblPinHoleSize)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.txtCrossTubeOD)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.lblCrossTubeOD)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.rdbDesignaCrossTube)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.rdbUseSelectedULug)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.lblShowImage)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.lblExistingULugsDetails)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.lvwExistingCrossTubeListView)
        Me.grbMatchedCrossTubeFound.Controls.Add(Me.picCastingNo)
        Me.grbMatchedCrossTubeFound.Location = New System.Drawing.Point(7, 17)
        Me.grbMatchedCrossTubeFound.Name = "grbMatchedCrossTubeFound"
        Me.grbMatchedCrossTubeFound.Size = New System.Drawing.Size(559, 356)
        Me.grbMatchedCrossTubeFound.TabIndex = 11
        Me.grbMatchedCrossTubeFound.TabStop = False
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
        Me.txtPinHoleTole_Neg_Req.Location = New System.Drawing.Point(217, 306)
        Me.txtPinHoleTole_Neg_Req.MaximumValue = 99999.0R
        Me.txtPinHoleTole_Neg_Req.MaxLength = 6
        Me.txtPinHoleTole_Neg_Req.MinimumValue = 0.0R
        Me.txtPinHoleTole_Neg_Req.Name = "txtPinHoleTole_Neg_Req"
        Me.txtPinHoleTole_Neg_Req.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Neg_Req.StatusMessage = ""
        Me.txtPinHoleTole_Neg_Req.StatusObject = Nothing
        Me.txtPinHoleTole_Neg_Req.TabIndex = 169
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
        Me.txtPinHoleTole_Pos_Req.Location = New System.Drawing.Point(217, 280)
        Me.txtPinHoleTole_Pos_Req.MaximumValue = 99999.0R
        Me.txtPinHoleTole_Pos_Req.MaxLength = 6
        Me.txtPinHoleTole_Pos_Req.MinimumValue = 0.0R
        Me.txtPinHoleTole_Pos_Req.Name = "txtPinHoleTole_Pos_Req"
        Me.txtPinHoleTole_Pos_Req.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Pos_Req.StatusMessage = ""
        Me.txtPinHoleTole_Pos_Req.StatusObject = Nothing
        Me.txtPinHoleTole_Pos_Req.TabIndex = 168
        Me.txtPinHoleTole_Pos_Req.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(416, 197)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 167
        Me.Label6.Text = "Available"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(490, 197)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 166
        Me.Label7.Text = "Required"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(155, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 165
        Me.Label5.Text = "Available"
        '
        'lblRequired
        '
        Me.lblRequired.AutoSize = True
        Me.lblRequired.Location = New System.Drawing.Point(229, 176)
        Me.lblRequired.Name = "lblRequired"
        Me.lblRequired.Size = New System.Drawing.Size(50, 13)
        Me.lblRequired.TabIndex = 164
        Me.lblRequired.Text = "Required"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(129, 309)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 163
        Me.Label4.Text = "-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(129, 283)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 13)
        Me.Label3.TabIndex = 162
        Me.Label3.Text = "+"
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
        Me.txtPinHoleTole_Neg.Location = New System.Drawing.Point(145, 306)
        Me.txtPinHoleTole_Neg.MaximumValue = 99999.0R
        Me.txtPinHoleTole_Neg.MaxLength = 6
        Me.txtPinHoleTole_Neg.MinimumValue = 0.0R
        Me.txtPinHoleTole_Neg.Name = "txtPinHoleTole_Neg"
        Me.txtPinHoleTole_Neg.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Neg.StatusMessage = ""
        Me.txtPinHoleTole_Neg.StatusObject = Nothing
        Me.txtPinHoleTole_Neg.TabIndex = 161
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
        Me.txtPinHoleTole_Pos.Location = New System.Drawing.Point(145, 280)
        Me.txtPinHoleTole_Pos.MaximumValue = 99999.0R
        Me.txtPinHoleTole_Pos.MaxLength = 6
        Me.txtPinHoleTole_Pos.MinimumValue = 0.0R
        Me.txtPinHoleTole_Pos.Name = "txtPinHoleTole_Pos"
        Me.txtPinHoleTole_Pos.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Pos.StatusMessage = ""
        Me.txtPinHoleTole_Pos.StatusObject = Nothing
        Me.txtPinHoleTole_Pos.TabIndex = 159
        Me.txtPinHoleTole_Pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 283)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 160
        Me.Label2.Text = "Pin Hole Tolerance"
        '
        'txtRequiredAngle2
        '
        Me.txtRequiredAngle2.AcceptEnterKeyAsTab = True
        Me.txtRequiredAngle2.ApplyIFLColor = True
        Me.txtRequiredAngle2.AssociateLabel = Nothing
        Me.txtRequiredAngle2.DecimalValue = 2
        Me.txtRequiredAngle2.IFLDataTag = Nothing
        Me.txtRequiredAngle2.InvalidInputCharacters = ""
        Me.txtRequiredAngle2.IsAllowNegative = False
        Me.txtRequiredAngle2.LengthValue = 6
        Me.txtRequiredAngle2.Location = New System.Drawing.Point(474, 276)
        Me.txtRequiredAngle2.MaximumValue = 99999.0R
        Me.txtRequiredAngle2.MaxLength = 6
        Me.txtRequiredAngle2.MinimumValue = 0.0R
        Me.txtRequiredAngle2.Name = "txtRequiredAngle2"
        Me.txtRequiredAngle2.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredAngle2.StatusMessage = ""
        Me.txtRequiredAngle2.StatusObject = Nothing
        Me.txtRequiredAngle2.TabIndex = 158
        Me.txtRequiredAngle2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredAngle1
        '
        Me.txtRequiredAngle1.AcceptEnterKeyAsTab = True
        Me.txtRequiredAngle1.ApplyIFLColor = True
        Me.txtRequiredAngle1.AssociateLabel = Nothing
        Me.txtRequiredAngle1.DecimalValue = 2
        Me.txtRequiredAngle1.IFLDataTag = Nothing
        Me.txtRequiredAngle1.InvalidInputCharacters = ""
        Me.txtRequiredAngle1.IsAllowNegative = False
        Me.txtRequiredAngle1.LengthValue = 6
        Me.txtRequiredAngle1.Location = New System.Drawing.Point(474, 248)
        Me.txtRequiredAngle1.MaximumValue = 99999.0R
        Me.txtRequiredAngle1.MaxLength = 6
        Me.txtRequiredAngle1.MinimumValue = 0.0R
        Me.txtRequiredAngle1.Name = "txtRequiredAngle1"
        Me.txtRequiredAngle1.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredAngle1.StatusMessage = ""
        Me.txtRequiredAngle1.StatusObject = Nothing
        Me.txtRequiredAngle1.TabIndex = 157
        Me.txtRequiredAngle1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredGreaseZerk
        '
        Me.txtRequiredGreaseZerk.AcceptEnterKeyAsTab = True
        Me.txtRequiredGreaseZerk.ApplyIFLColor = True
        Me.txtRequiredGreaseZerk.AssociateLabel = Nothing
        Me.txtRequiredGreaseZerk.DecimalValue = 2
        Me.txtRequiredGreaseZerk.IFLDataTag = Nothing
        Me.txtRequiredGreaseZerk.InvalidInputCharacters = ""
        Me.txtRequiredGreaseZerk.IsAllowNegative = False
        Me.txtRequiredGreaseZerk.LengthValue = 6
        Me.txtRequiredGreaseZerk.Location = New System.Drawing.Point(474, 220)
        Me.txtRequiredGreaseZerk.MaximumValue = 99999.0R
        Me.txtRequiredGreaseZerk.MaxLength = 6
        Me.txtRequiredGreaseZerk.MinimumValue = 0.0R
        Me.txtRequiredGreaseZerk.Name = "txtRequiredGreaseZerk"
        Me.txtRequiredGreaseZerk.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredGreaseZerk.StatusMessage = ""
        Me.txtRequiredGreaseZerk.StatusObject = Nothing
        Me.txtRequiredGreaseZerk.TabIndex = 156
        Me.txtRequiredGreaseZerk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredCrossTubeWidth
        '
        Me.txtRequiredCrossTubeWidth.AcceptEnterKeyAsTab = True
        Me.txtRequiredCrossTubeWidth.ApplyIFLColor = True
        Me.txtRequiredCrossTubeWidth.AssociateLabel = Nothing
        Me.txtRequiredCrossTubeWidth.DecimalValue = 2
        Me.txtRequiredCrossTubeWidth.IFLDataTag = Nothing
        Me.txtRequiredCrossTubeWidth.InvalidInputCharacters = ""
        Me.txtRequiredCrossTubeWidth.IsAllowNegative = False
        Me.txtRequiredCrossTubeWidth.LengthValue = 6
        Me.txtRequiredCrossTubeWidth.Location = New System.Drawing.Point(217, 225)
        Me.txtRequiredCrossTubeWidth.MaximumValue = 99999.0R
        Me.txtRequiredCrossTubeWidth.MaxLength = 6
        Me.txtRequiredCrossTubeWidth.MinimumValue = 0.0R
        Me.txtRequiredCrossTubeWidth.Name = "txtRequiredCrossTubeWidth"
        Me.txtRequiredCrossTubeWidth.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredCrossTubeWidth.StatusMessage = ""
        Me.txtRequiredCrossTubeWidth.StatusObject = Nothing
        Me.txtRequiredCrossTubeWidth.TabIndex = 154
        Me.txtRequiredCrossTubeWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.txtRequiredPinHoleSize.Location = New System.Drawing.Point(217, 254)
        Me.txtRequiredPinHoleSize.MaximumValue = 99999.0R
        Me.txtRequiredPinHoleSize.MaxLength = 6
        Me.txtRequiredPinHoleSize.MinimumValue = 0.0R
        Me.txtRequiredPinHoleSize.Name = "txtRequiredPinHoleSize"
        Me.txtRequiredPinHoleSize.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredPinHoleSize.StatusMessage = ""
        Me.txtRequiredPinHoleSize.StatusObject = Nothing
        Me.txtRequiredPinHoleSize.TabIndex = 155
        Me.txtRequiredPinHoleSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCrossTubeWidth
        '
        Me.txtCrossTubeWidth.AcceptEnterKeyAsTab = True
        Me.txtCrossTubeWidth.ApplyIFLColor = True
        Me.txtCrossTubeWidth.AssociateLabel = Nothing
        Me.txtCrossTubeWidth.DecimalValue = 2
        Me.txtCrossTubeWidth.IFLDataTag = Nothing
        Me.txtCrossTubeWidth.InvalidInputCharacters = ""
        Me.txtCrossTubeWidth.IsAllowNegative = False
        Me.txtCrossTubeWidth.LengthValue = 6
        Me.txtCrossTubeWidth.Location = New System.Drawing.Point(145, 225)
        Me.txtCrossTubeWidth.MaximumValue = 99999.0R
        Me.txtCrossTubeWidth.MaxLength = 6
        Me.txtCrossTubeWidth.MinimumValue = 0.0R
        Me.txtCrossTubeWidth.Name = "txtCrossTubeWidth"
        Me.txtCrossTubeWidth.Size = New System.Drawing.Size(66, 20)
        Me.txtCrossTubeWidth.StatusMessage = ""
        Me.txtCrossTubeWidth.StatusObject = Nothing
        Me.txtCrossTubeWidth.TabIndex = 142
        Me.txtCrossTubeWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCrossTubeWidth
        '
        Me.lblCrossTubeWidth.AutoSize = True
        Me.lblCrossTubeWidth.Location = New System.Drawing.Point(22, 228)
        Me.lblCrossTubeWidth.Name = "lblCrossTubeWidth"
        Me.lblCrossTubeWidth.Size = New System.Drawing.Size(92, 13)
        Me.lblCrossTubeWidth.TabIndex = 152
        Me.lblCrossTubeWidth.Text = "Cross Tube Width"
        '
        'txtAngle2
        '
        Me.txtAngle2.AcceptEnterKeyAsTab = True
        Me.txtAngle2.ApplyIFLColor = True
        Me.txtAngle2.AssociateLabel = Nothing
        Me.txtAngle2.DecimalValue = 2
        Me.txtAngle2.IFLDataTag = Nothing
        Me.txtAngle2.InvalidInputCharacters = ""
        Me.txtAngle2.IsAllowNegative = False
        Me.txtAngle2.LengthValue = 6
        Me.txtAngle2.Location = New System.Drawing.Point(406, 276)
        Me.txtAngle2.MaximumValue = 99999.0R
        Me.txtAngle2.MaxLength = 6
        Me.txtAngle2.MinimumValue = 0.0R
        Me.txtAngle2.Name = "txtAngle2"
        Me.txtAngle2.Size = New System.Drawing.Size(66, 20)
        Me.txtAngle2.StatusMessage = ""
        Me.txtAngle2.StatusObject = Nothing
        Me.txtAngle2.TabIndex = 146
        Me.txtAngle2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAngle2
        '
        Me.lblAngle2.AutoSize = True
        Me.lblAngle2.Location = New System.Drawing.Point(321, 279)
        Me.lblAngle2.Name = "lblAngle2"
        Me.lblAngle2.Size = New System.Drawing.Size(40, 13)
        Me.lblAngle2.TabIndex = 151
        Me.lblAngle2.Text = "Angle2"
        '
        'txtAngle1
        '
        Me.txtAngle1.AcceptEnterKeyAsTab = True
        Me.txtAngle1.ApplyIFLColor = True
        Me.txtAngle1.AssociateLabel = Nothing
        Me.txtAngle1.DecimalValue = 2
        Me.txtAngle1.IFLDataTag = Nothing
        Me.txtAngle1.InvalidInputCharacters = ""
        Me.txtAngle1.IsAllowNegative = False
        Me.txtAngle1.LengthValue = 6
        Me.txtAngle1.Location = New System.Drawing.Point(406, 248)
        Me.txtAngle1.MaximumValue = 99999.0R
        Me.txtAngle1.MaxLength = 6
        Me.txtAngle1.MinimumValue = 0.0R
        Me.txtAngle1.Name = "txtAngle1"
        Me.txtAngle1.Size = New System.Drawing.Size(66, 20)
        Me.txtAngle1.StatusMessage = ""
        Me.txtAngle1.StatusObject = Nothing
        Me.txtAngle1.TabIndex = 145
        Me.txtAngle1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAngle1
        '
        Me.lblAngle1.AutoSize = True
        Me.lblAngle1.Location = New System.Drawing.Point(321, 251)
        Me.lblAngle1.Name = "lblAngle1"
        Me.lblAngle1.Size = New System.Drawing.Size(40, 13)
        Me.lblAngle1.TabIndex = 150
        Me.lblAngle1.Text = "Angle1"
        '
        'txtGreaseZerk
        '
        Me.txtGreaseZerk.AcceptEnterKeyAsTab = True
        Me.txtGreaseZerk.ApplyIFLColor = True
        Me.txtGreaseZerk.AssociateLabel = Nothing
        Me.txtGreaseZerk.DecimalValue = 2
        Me.txtGreaseZerk.IFLDataTag = Nothing
        Me.txtGreaseZerk.InvalidInputCharacters = ""
        Me.txtGreaseZerk.IsAllowNegative = False
        Me.txtGreaseZerk.LengthValue = 6
        Me.txtGreaseZerk.Location = New System.Drawing.Point(406, 220)
        Me.txtGreaseZerk.MaximumValue = 99999.0R
        Me.txtGreaseZerk.MaxLength = 6
        Me.txtGreaseZerk.MinimumValue = 0.0R
        Me.txtGreaseZerk.Name = "txtGreaseZerk"
        Me.txtGreaseZerk.Size = New System.Drawing.Size(66, 20)
        Me.txtGreaseZerk.StatusMessage = ""
        Me.txtGreaseZerk.StatusObject = Nothing
        Me.txtGreaseZerk.TabIndex = 144
        Me.txtGreaseZerk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblGreaseZerk
        '
        Me.lblGreaseZerk.AutoSize = True
        Me.lblGreaseZerk.Location = New System.Drawing.Point(321, 223)
        Me.lblGreaseZerk.Name = "lblGreaseZerk"
        Me.lblGreaseZerk.Size = New System.Drawing.Size(85, 13)
        Me.lblGreaseZerk.TabIndex = 149
        Me.lblGreaseZerk.Text = "Grease Zerk Qty"
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
        Me.txtPinHoleSize.Location = New System.Drawing.Point(145, 254)
        Me.txtPinHoleSize.MaximumValue = 99999.0R
        Me.txtPinHoleSize.MaxLength = 6
        Me.txtPinHoleSize.MinimumValue = 0.0R
        Me.txtPinHoleSize.Name = "txtPinHoleSize"
        Me.txtPinHoleSize.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleSize.StatusMessage = ""
        Me.txtPinHoleSize.StatusObject = Nothing
        Me.txtPinHoleSize.TabIndex = 143
        Me.txtPinHoleSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPinHoleSize
        '
        Me.lblPinHoleSize.AutoSize = True
        Me.lblPinHoleSize.Location = New System.Drawing.Point(22, 257)
        Me.lblPinHoleSize.Name = "lblPinHoleSize"
        Me.lblPinHoleSize.Size = New System.Drawing.Size(70, 13)
        Me.lblPinHoleSize.TabIndex = 148
        Me.lblPinHoleSize.Text = "Pin Hole Size"
        '
        'txtCrossTubeOD
        '
        Me.txtCrossTubeOD.AcceptEnterKeyAsTab = True
        Me.txtCrossTubeOD.ApplyIFLColor = True
        Me.txtCrossTubeOD.AssociateLabel = Nothing
        Me.txtCrossTubeOD.DecimalValue = 2
        Me.txtCrossTubeOD.IFLDataTag = Nothing
        Me.txtCrossTubeOD.InvalidInputCharacters = ""
        Me.txtCrossTubeOD.IsAllowNegative = False
        Me.txtCrossTubeOD.LengthValue = 6
        Me.txtCrossTubeOD.Location = New System.Drawing.Point(145, 197)
        Me.txtCrossTubeOD.MaximumValue = 99999.0R
        Me.txtCrossTubeOD.MaxLength = 6
        Me.txtCrossTubeOD.MinimumValue = 0.0R
        Me.txtCrossTubeOD.Name = "txtCrossTubeOD"
        Me.txtCrossTubeOD.Size = New System.Drawing.Size(66, 20)
        Me.txtCrossTubeOD.StatusMessage = ""
        Me.txtCrossTubeOD.StatusObject = Nothing
        Me.txtCrossTubeOD.TabIndex = 141
        Me.txtCrossTubeOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCrossTubeOD
        '
        Me.lblCrossTubeOD.AutoSize = True
        Me.lblCrossTubeOD.Location = New System.Drawing.Point(22, 200)
        Me.lblCrossTubeOD.Name = "lblCrossTubeOD"
        Me.lblCrossTubeOD.Size = New System.Drawing.Size(80, 13)
        Me.lblCrossTubeOD.TabIndex = 147
        Me.lblCrossTubeOD.Text = "Cross Tube OD"
        '
        'rdbDesignaCrossTube
        '
        Me.rdbDesignaCrossTube.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rdbDesignaCrossTube.AutoSize = True
        Me.rdbDesignaCrossTube.Location = New System.Drawing.Point(411, 326)
        Me.rdbDesignaCrossTube.Name = "rdbDesignaCrossTube"
        Me.rdbDesignaCrossTube.Size = New System.Drawing.Size(121, 17)
        Me.rdbDesignaCrossTube.TabIndex = 114
        Me.rdbDesignaCrossTube.TabStop = True
        Me.rdbDesignaCrossTube.Text = "Design a CrossTube"
        Me.rdbDesignaCrossTube.UseVisualStyleBackColor = True
        '
        'picCastingNo
        '
        Me.picCastingNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picCastingNo.Location = New System.Drawing.Point(410, 92)
        Me.picCastingNo.Name = "picCastingNo"
        Me.picCastingNo.Size = New System.Drawing.Size(136, 65)
        Me.picCastingNo.TabIndex = 102
        Me.picCastingNo.TabStop = False
        '
        'grbMatchedCrossTubeNotFound
        '
        Me.grbMatchedCrossTubeNotFound.Controls.Add(Me.pnlSafetyFactor_Weight_LugThickness)
        Me.grbMatchedCrossTubeNotFound.Controls.Add(Me.pnlDesignULug)
        Me.grbMatchedCrossTubeNotFound.Controls.Add(Me.btnMatchedULugNotFound)
        Me.grbMatchedCrossTubeNotFound.Controls.Add(Me.LabelGradient2)
        Me.grbMatchedCrossTubeNotFound.Controls.Add(Me.btnAccept)
        Me.grbMatchedCrossTubeNotFound.Location = New System.Drawing.Point(7, 14)
        Me.grbMatchedCrossTubeNotFound.Name = "grbMatchedCrossTubeNotFound"
        Me.grbMatchedCrossTubeNotFound.Size = New System.Drawing.Size(559, 356)
        Me.grbMatchedCrossTubeNotFound.TabIndex = 147
        Me.grbMatchedCrossTubeNotFound.TabStop = False
        '
        'pnlSafetyFactor_Weight_LugThickness
        '
        Me.pnlSafetyFactor_Weight_LugThickness.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlSafetyFactor_Weight_LugThickness.Controls.Add(Me.lvwSafetyFactor_Weight)
        Me.pnlSafetyFactor_Weight_LugThickness.Controls.Add(Me.lblSafetyFactorIndex)
        Me.pnlSafetyFactor_Weight_LugThickness.Location = New System.Drawing.Point(64, 211)
        Me.pnlSafetyFactor_Weight_LugThickness.Name = "pnlSafetyFactor_Weight_LugThickness"
        Me.pnlSafetyFactor_Weight_LugThickness.Size = New System.Drawing.Size(445, 115)
        Me.pnlSafetyFactor_Weight_LugThickness.TabIndex = 151
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
        Me.pnlDesignULug.Location = New System.Drawing.Point(64, 54)
        Me.pnlDesignULug.Name = "pnlDesignULug"
        Me.pnlDesignULug.Size = New System.Drawing.Size(445, 155)
        Me.pnlDesignULug.TabIndex = 148
        '
        'chkOptimizer
        '
        Me.chkOptimizer.AutoSize = True
        Me.chkOptimizer.Location = New System.Drawing.Point(325, 127)
        Me.chkOptimizer.Name = "chkOptimizer"
        Me.chkOptimizer.Size = New System.Drawing.Size(66, 17)
        Me.chkOptimizer.TabIndex = 162
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
        Me.txtSafetyFactor_DesignCrossTube.MaximumValue = 99999.0R
        Me.txtSafetyFactor_DesignCrossTube.MaxLength = 6
        Me.txtSafetyFactor_DesignCrossTube.MinimumValue = 0.0R
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
        Me.lblCrossTubeWidth_DesignNewCrossTube.Location = New System.Drawing.Point(49, 71)
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
        Me.trbSafetyFactor.Location = New System.Drawing.Point(113, 22)
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
        Me.txtCrossTubeWidth_DesignCrossTube.Location = New System.Drawing.Point(147, 68)
        Me.txtCrossTubeWidth_DesignCrossTube.MaximumValue = 99999.0R
        Me.txtCrossTubeWidth_DesignCrossTube.MaxLength = 6
        Me.txtCrossTubeWidth_DesignCrossTube.MinimumValue = 0.0R
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
        Me.lblDesignNewCasting.Text = "Design New CrossTube"
        Me.lblDesignNewCasting.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(164, 121)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(112, 23)
        Me.btnGenerate.TabIndex = 150
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'lblCrossTubeOD_DesignCrossTube
        '
        Me.lblCrossTubeOD_DesignCrossTube.AutoSize = True
        Me.lblCrossTubeOD_DesignCrossTube.Location = New System.Drawing.Point(49, 98)
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
        Me.txtCrossTubeOD_DesignCrossTube.Location = New System.Drawing.Point(147, 95)
        Me.txtCrossTubeOD_DesignCrossTube.MaximumValue = 99999.0R
        Me.txtCrossTubeOD_DesignCrossTube.MaxLength = 6
        Me.txtCrossTubeOD_DesignCrossTube.MinimumValue = 0.0R
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
        Me.txtSwingClearance_DesignCrossTube.Location = New System.Drawing.Point(325, 95)
        Me.txtSwingClearance_DesignCrossTube.MaximumValue = 99999.0R
        Me.txtSwingClearance_DesignCrossTube.MaxLength = 6
        Me.txtSwingClearance_DesignCrossTube.MinimumValue = 0.0R
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
        Me.lblSwingClearance2.Location = New System.Drawing.Point(228, 98)
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
        Me.txtPinHoleSize_DesignCrossTube.Location = New System.Drawing.Point(325, 68)
        Me.txtPinHoleSize_DesignCrossTube.MaximumValue = 99999.0R
        Me.txtPinHoleSize_DesignCrossTube.MaxLength = 6
        Me.txtPinHoleSize_DesignCrossTube.MinimumValue = 0.0R
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
        Me.Label1.Location = New System.Drawing.Point(228, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 147
        Me.Label1.Text = "Pin Hole Size"
        '
        'btnMatchedULugNotFound
        '
        Me.btnMatchedULugNotFound.Enabled = False
        Me.btnMatchedULugNotFound.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMatchedULugNotFound.Location = New System.Drawing.Point(197, 24)
        Me.btnMatchedULugNotFound.Name = "btnMatchedULugNotFound"
        Me.btnMatchedULugNotFound.Size = New System.Drawing.Size(183, 24)
        Me.btnMatchedULugNotFound.TabIndex = 147
        Me.btnMatchedULugNotFound.Text = "Matching CrossTube  not found"
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
        Me.LabelGradient2.Text = "Existing CrossTube Details"
        Me.LabelGradient2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(223, 327)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(112, 23)
        Me.btnAccept.TabIndex = 151
        Me.btnAccept.Text = "Accept"
        Me.btnAccept.UseVisualStyleBackColor = True
        '
        'UcBrowsePlateClevis1
        '
        Me.UcBrowsePlateClevis1.BackColor = System.Drawing.Color.Ivory
        Me.UcBrowsePlateClevis1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.UcBrowsePlateClevis1.Location = New System.Drawing.Point(17, 12)
        Me.UcBrowsePlateClevis1.Name = "UcBrowsePlateClevis1"
        Me.UcBrowsePlateClevis1.ObjFrmImportPlateClevis = Nothing
        Me.UcBrowsePlateClevis1.Size = New System.Drawing.Size(530, 76)
        Me.UcBrowsePlateClevis1.TabIndex = 107
        '
        'lvwExistingCrossTubeListView
        '
        Me.lvwExistingCrossTubeListView.GridLines = True
        Me.lvwExistingCrossTubeListView.Location = New System.Drawing.Point(14, 29)
        Me.lvwExistingCrossTubeListView.Name = "lvwExistingCrossTubeListView"
        Me.lvwExistingCrossTubeListView.Size = New System.Drawing.Size(390, 143)
        Me.lvwExistingCrossTubeListView.TabIndex = 12
        Me.lvwExistingCrossTubeListView.UseCompatibleStateImageBehavior = False
        Me.lvwExistingCrossTubeListView.View = System.Windows.Forms.View.Details
        '
        'lvwSafetyFactor_Weight
        '
        Me.lvwSafetyFactor_Weight.GridLines = True
        Me.lvwSafetyFactor_Weight.Location = New System.Drawing.Point(25, 21)
        Me.lvwSafetyFactor_Weight.Name = "lvwSafetyFactor_Weight"
        Me.lvwSafetyFactor_Weight.Size = New System.Drawing.Size(390, 86)
        Me.lvwSafetyFactor_Weight.TabIndex = 13
        Me.lvwSafetyFactor_Weight.UseCompatibleStateImageBehavior = False
        Me.lvwSafetyFactor_Weight.View = System.Windows.Forms.View.Details
        '
        'frmCTFabrication
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Ivory
        Me.ClientSize = New System.Drawing.Size(571, 476)
        Me.Controls.Add(Me.pnlFabrication)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCTFabrication"
        Me.Text = "Form3"
        Me.pnlFabrication.ResumeLayout(False)
        Me.grbPlateClevis.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.grbMatchedCrossTubeFound.ResumeLayout(False)
        Me.grbMatchedCrossTubeFound.PerformLayout()
        CType(Me.picCastingNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbMatchedCrossTubeNotFound.ResumeLayout(False)
        Me.pnlSafetyFactor_Weight_LugThickness.ResumeLayout(False)
        Me.pnlDesignULug.ResumeLayout(False)
        Me.pnlDesignULug.PerformLayout()
        CType(Me.trbSafetyFactor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rdbUseSelectedULug As System.Windows.Forms.RadioButton
    Friend WithEvents lblShowImage As LabelGradient.LabelGradient
    Friend WithEvents lblExistingULugsDetails As LabelGradient.LabelGradient
    Friend WithEvents lvwExistingCrossTubeListView As Monarch_WeldedCylinder_01_09_09.clsListViewMIL
    Friend WithEvents pnlFabrication As System.Windows.Forms.Panel
    Friend WithEvents grbPlateClevis As System.Windows.Forms.GroupBox
    Friend WithEvents btnPlateClevis As System.Windows.Forms.Button
    Friend WithEvents UcBrowsePlateClevis1 As Monarch_WeldedCylinder_01_09_09.ucBrowsePlateClevis
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grbMatchedCrossTubeNotFound As System.Windows.Forms.GroupBox
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
    Friend WithEvents btnMatchedULugNotFound As System.Windows.Forms.Button
    Friend WithEvents LabelGradient2 As LabelGradient.LabelGradient
    Friend WithEvents grbMatchedCrossTubeFound As System.Windows.Forms.GroupBox
    Friend WithEvents rdbDesignaCrossTube As System.Windows.Forms.RadioButton
    Friend WithEvents picCastingNo As System.Windows.Forms.PictureBox
    Friend WithEvents txtRequiredAngle2 As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredAngle1 As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredGreaseZerk As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredCrossTubeWidth As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredPinHoleSize As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtCrossTubeWidth As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblCrossTubeWidth As System.Windows.Forms.Label
    Friend WithEvents txtAngle2 As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblAngle2 As System.Windows.Forms.Label
    Friend WithEvents txtAngle1 As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblAngle1 As System.Windows.Forms.Label
    Friend WithEvents txtGreaseZerk As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblGreaseZerk As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleSize As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblPinHoleSize As System.Windows.Forms.Label
    Friend WithEvents txtCrossTubeOD As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblCrossTubeOD As System.Windows.Forms.Label
    Friend WithEvents pnlSafetyFactor_Weight_LugThickness As System.Windows.Forms.Panel
    Friend WithEvents lvwSafetyFactor_Weight As Monarch_WeldedCylinder_01_09_09.clsListViewMIL
    Friend WithEvents lblSafetyFactorIndex As LabelGradient.LabelGradient
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleTole_Neg As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtPinHoleTole_Pos As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblRequired As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleTole_Neg_Req As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtPinHoleTole_Pos_Req As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents chkOptimizer As System.Windows.Forms.CheckBox
End Class
