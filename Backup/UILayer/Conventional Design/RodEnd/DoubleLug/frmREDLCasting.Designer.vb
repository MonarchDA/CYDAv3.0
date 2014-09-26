<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREDLCasting
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
        Me.lblDLHeading = New LabelGradient.LabelGradient
        Me.LabelGradient4 = New LabelGradient.LabelGradient
        Me.LabelGradient3 = New LabelGradient.LabelGradient
        Me.LabelGradient2 = New LabelGradient.LabelGradient
        Me.pnlREDLCasting_YesNo = New System.Windows.Forms.Panel
        Me.pnlREDLCastingYes = New System.Windows.Forms.Panel
        Me.btnPleaseChangeTheRodDiameter = New System.Windows.Forms.Button
        Me.grbREDLCastingMatched = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblUseSelectedSingleLug = New System.Windows.Forms.Label
        Me.rdbUseSelectedSingleLugNo = New System.Windows.Forms.RadioButton
        Me.rdbUseSelectedSingleLugYes = New System.Windows.Forms.RadioButton
        Me.txtRequiredLugGap_DLCasting = New IFLCustomUILayer.IFLNumericBox
        Me.txtLugGap_DLCasting = New IFLCustomUILayer.IFLNumericBox
        Me.lblLugGap_DLCasting = New System.Windows.Forms.Label
        Me.lblRequired = New System.Windows.Forms.Label
        Me.txtSwingClearance_DLCasting = New IFLCustomUILayer.IFLNumericBox
        Me.lblSwingClearance_DLCasting = New System.Windows.Forms.Label
        Me.txtRequiredSwingClearance_DLCasting = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredLugThickness_DLCasting = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredPinHoleSize_DLCasting = New IFLCustomUILayer.IFLNumericBox
        Me.btnPicInformation = New System.Windows.Forms.Button
        Me.picDLcasting = New System.Windows.Forms.PictureBox
        Me.txtLugThickness_DLCasting = New IFLCustomUILayer.IFLNumericBox
        Me.lblLugThickness_DLCasting = New System.Windows.Forms.Label
        Me.txtWeldSize_DLCasting = New IFLCustomUILayer.IFLNumericBox
        Me.lblWeldSize_DLCasting = New System.Windows.Forms.Label
        Me.txtLugWidth_DLCasting = New IFLCustomUILayer.IFLNumericBox
        Me.lblLugsWidth_DLCasting = New System.Windows.Forms.Label
        Me.txtPinHoleSize_DLCasting = New IFLCustomUILayer.IFLNumericBox
        Me.lblPinHoleSize_DLCasting = New System.Windows.Forms.Label
        Me.txtCodeNumber_DLCasting = New IFLCustomUILayer.IFLNumericBox
        Me.lblCodeNumber_DLCasting = New System.Windows.Forms.Label
        Me.lvwDLCastingDetails = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL
        Me.lblExistingDoubleLugIndex_RodEnd = New LabelGradient.LabelGradient
        Me.grbUsingSelectedDLCasting = New System.Windows.Forms.GroupBox
        Me.rdbNewCasting_DlCasting = New System.Windows.Forms.RadioButton
        Me.rdbResize_DLCasting = New System.Windows.Forms.RadioButton
        Me.lblIsExactMatch = New System.Windows.Forms.Label
        Me.rdbExactMatchYes = New System.Windows.Forms.RadioButton
        Me.lblUseSelectedDoubleLugCasting = New LabelGradient.LabelGradient
        Me.lblBackGround = New LabelGradient.LabelGradient
        Me.pnlREDLCastingNo = New System.Windows.Forms.Panel
        Me.pnlREDLSafetyFactor_Weight_LugThickness = New System.Windows.Forms.Panel
        Me.lvwREDLSafetyFactor_Weight = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL
        Me.lblSafetyFactorIndex_REDL = New LabelGradient.LabelGradient
        Me.btnAccept_REDL = New System.Windows.Forms.Button
        Me.pnlREDLDesignaCasting = New System.Windows.Forms.Panel
        Me.txtSafetyFactorOfCasting_REDL = New IFLCustomUILayer.IFLNumericBox
        Me.txtLugWidth_REDL = New IFLCustomUILayer.IFLNumericBox
        Me.lblLugWidth_REDL = New System.Windows.Forms.Label
        Me.lblLugThickness_REDL = New System.Windows.Forms.Label
        Me.txtLugThickness_REDL = New IFLCustomUILayer.IFLNumericBox
        Me.lblSafetyFactor_REDL = New System.Windows.Forms.Label
        Me.trbSafetyFactor_REDL = New System.Windows.Forms.TrackBar
        Me.lblDesignNewCasting = New LabelGradient.LabelGradient
        Me.btnGenerate_REDL = New System.Windows.Forms.Button
        Me.txtSwingClearance_REDL = New IFLCustomUILayer.IFLNumericBox
        Me.lblSwingClearance_REDL = New System.Windows.Forms.Label
        Me.txtPinHoleSize_REDL = New IFLCustomUILayer.IFLNumericBox
        Me.lblPinHoleSize_REDL = New System.Windows.Forms.Label
        Me.lblLugGap_REDL = New System.Windows.Forms.Label
        Me.txtLugGap_REDL = New IFLCustomUILayer.IFLNumericBox
        Me.LabelGradient5 = New LabelGradient.LabelGradient
        Me.pnlREDLCasting_YesNo.SuspendLayout()
        Me.pnlREDLCastingYes.SuspendLayout()
        Me.grbREDLCastingMatched.SuspendLayout()
        CType(Me.picDLcasting, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbUsingSelectedDLCasting.SuspendLayout()
        Me.pnlREDLCastingNo.SuspendLayout()
        Me.pnlREDLSafetyFactor_Weight_LugThickness.SuspendLayout()
        Me.pnlREDLDesignaCasting.SuspendLayout()
        CType(Me.trbSafetyFactor_REDL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDLHeading
        '
        Me.lblDLHeading.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblDLHeading.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDLHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDLHeading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDLHeading.GradientColorOne = System.Drawing.Color.Olive
        Me.lblDLHeading.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblDLHeading.Location = New System.Drawing.Point(20, 0)
        Me.lblDLHeading.Name = "lblDLHeading"
        Me.lblDLHeading.Size = New System.Drawing.Size(1158, 19)
        Me.lblDLHeading.TabIndex = 51
        Me.lblDLHeading.Text = "Rod End Double Lug Casting"
        Me.lblDLHeading.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.LabelGradient4.Size = New System.Drawing.Size(22, 881)
        Me.LabelGradient4.TabIndex = 50
        Me.LabelGradient4.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.LabelGradient3.TabIndex = 49
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
        Me.LabelGradient2.Size = New System.Drawing.Size(1200, 19)
        Me.LabelGradient2.TabIndex = 48
        Me.LabelGradient2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlREDLCasting_YesNo
        '
        Me.pnlREDLCasting_YesNo.AutoScroll = True
        Me.pnlREDLCasting_YesNo.Controls.Add(Me.pnlREDLCastingYes)
        Me.pnlREDLCasting_YesNo.Controls.Add(Me.pnlREDLCastingNo)
        Me.pnlREDLCasting_YesNo.Location = New System.Drawing.Point(26, 22)
        Me.pnlREDLCasting_YesNo.Name = "pnlREDLCasting_YesNo"
        Me.pnlREDLCasting_YesNo.Size = New System.Drawing.Size(927, 563)
        Me.pnlREDLCasting_YesNo.TabIndex = 52
        '
        'pnlREDLCastingYes
        '
        Me.pnlREDLCastingYes.AutoScroll = True
        Me.pnlREDLCastingYes.BackColor = System.Drawing.Color.Black
        Me.pnlREDLCastingYes.Controls.Add(Me.btnPleaseChangeTheRodDiameter)
        Me.pnlREDLCastingYes.Controls.Add(Me.grbREDLCastingMatched)
        Me.pnlREDLCastingYes.Controls.Add(Me.grbUsingSelectedDLCasting)
        Me.pnlREDLCastingYes.Controls.Add(Me.lblBackGround)
        Me.pnlREDLCastingYes.Location = New System.Drawing.Point(3, 3)
        Me.pnlREDLCastingYes.Name = "pnlREDLCastingYes"
        Me.pnlREDLCastingYes.Size = New System.Drawing.Size(824, 538)
        Me.pnlREDLCastingYes.TabIndex = 41
        '
        'btnPleaseChangeTheRodDiameter
        '
        Me.btnPleaseChangeTheRodDiameter.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.btnPleaseChangeTheRodDiameter.Enabled = False
        Me.btnPleaseChangeTheRodDiameter.Location = New System.Drawing.Point(164, -2)
        Me.btnPleaseChangeTheRodDiameter.Name = "btnPleaseChangeTheRodDiameter"
        Me.btnPleaseChangeTheRodDiameter.Size = New System.Drawing.Size(225, 23)
        Me.btnPleaseChangeTheRodDiameter.TabIndex = 173
        Me.btnPleaseChangeTheRodDiameter.Text = "Please Change The Rod Diameter"
        Me.btnPleaseChangeTheRodDiameter.UseVisualStyleBackColor = False
        '
        'grbREDLCastingMatched
        '
        Me.grbREDLCastingMatched.BackColor = System.Drawing.Color.Ivory
        Me.grbREDLCastingMatched.Controls.Add(Me.Label1)
        Me.grbREDLCastingMatched.Controls.Add(Me.Label2)
        Me.grbREDLCastingMatched.Controls.Add(Me.Label3)
        Me.grbREDLCastingMatched.Controls.Add(Me.lblUseSelectedSingleLug)
        Me.grbREDLCastingMatched.Controls.Add(Me.rdbUseSelectedSingleLugNo)
        Me.grbREDLCastingMatched.Controls.Add(Me.rdbUseSelectedSingleLugYes)
        Me.grbREDLCastingMatched.Controls.Add(Me.txtRequiredLugGap_DLCasting)
        Me.grbREDLCastingMatched.Controls.Add(Me.txtLugGap_DLCasting)
        Me.grbREDLCastingMatched.Controls.Add(Me.lblLugGap_DLCasting)
        Me.grbREDLCastingMatched.Controls.Add(Me.lblRequired)
        Me.grbREDLCastingMatched.Controls.Add(Me.txtSwingClearance_DLCasting)
        Me.grbREDLCastingMatched.Controls.Add(Me.lblSwingClearance_DLCasting)
        Me.grbREDLCastingMatched.Controls.Add(Me.txtRequiredSwingClearance_DLCasting)
        Me.grbREDLCastingMatched.Controls.Add(Me.txtRequiredLugThickness_DLCasting)
        Me.grbREDLCastingMatched.Controls.Add(Me.txtRequiredPinHoleSize_DLCasting)
        Me.grbREDLCastingMatched.Controls.Add(Me.btnPicInformation)
        Me.grbREDLCastingMatched.Controls.Add(Me.picDLcasting)
        Me.grbREDLCastingMatched.Controls.Add(Me.txtLugThickness_DLCasting)
        Me.grbREDLCastingMatched.Controls.Add(Me.lblLugThickness_DLCasting)
        Me.grbREDLCastingMatched.Controls.Add(Me.txtWeldSize_DLCasting)
        Me.grbREDLCastingMatched.Controls.Add(Me.lblWeldSize_DLCasting)
        Me.grbREDLCastingMatched.Controls.Add(Me.txtLugWidth_DLCasting)
        Me.grbREDLCastingMatched.Controls.Add(Me.lblLugsWidth_DLCasting)
        Me.grbREDLCastingMatched.Controls.Add(Me.txtPinHoleSize_DLCasting)
        Me.grbREDLCastingMatched.Controls.Add(Me.lblPinHoleSize_DLCasting)
        Me.grbREDLCastingMatched.Controls.Add(Me.txtCodeNumber_DLCasting)
        Me.grbREDLCastingMatched.Controls.Add(Me.lblCodeNumber_DLCasting)
        Me.grbREDLCastingMatched.Controls.Add(Me.lvwDLCastingDetails)
        Me.grbREDLCastingMatched.Controls.Add(Me.lblExistingDoubleLugIndex_RodEnd)
        Me.grbREDLCastingMatched.Location = New System.Drawing.Point(21, 20)
        Me.grbREDLCastingMatched.Name = "grbREDLCastingMatched"
        Me.grbREDLCastingMatched.Size = New System.Drawing.Size(543, 314)
        Me.grbREDLCastingMatched.TabIndex = 15
        Me.grbREDLCastingMatched.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(383, 166)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 165
        Me.Label1.Text = "Available"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(116, 166)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 164
        Me.Label2.Text = "Available"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(454, 166)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 149
        Me.Label3.Text = "Required"
        '
        'lblUseSelectedSingleLug
        '
        Me.lblUseSelectedSingleLug.AutoSize = True
        Me.lblUseSelectedSingleLug.Location = New System.Drawing.Point(286, 281)
        Me.lblUseSelectedSingleLug.Name = "lblUseSelectedSingleLug"
        Me.lblUseSelectedSingleLug.Size = New System.Drawing.Size(121, 13)
        Me.lblUseSelectedSingleLug.TabIndex = 148
        Me.lblUseSelectedSingleLug.Text = "Use Selected SingleLug"
        '
        'rdbUseSelectedSingleLugNo
        '
        Me.rdbUseSelectedSingleLugNo.AutoSize = True
        Me.rdbUseSelectedSingleLugNo.Location = New System.Drawing.Point(477, 279)
        Me.rdbUseSelectedSingleLugNo.Name = "rdbUseSelectedSingleLugNo"
        Me.rdbUseSelectedSingleLugNo.Size = New System.Drawing.Size(39, 17)
        Me.rdbUseSelectedSingleLugNo.TabIndex = 147
        Me.rdbUseSelectedSingleLugNo.TabStop = True
        Me.rdbUseSelectedSingleLugNo.Text = "No"
        Me.rdbUseSelectedSingleLugNo.UseVisualStyleBackColor = True
        '
        'rdbUseSelectedSingleLugYes
        '
        Me.rdbUseSelectedSingleLugYes.AutoSize = True
        Me.rdbUseSelectedSingleLugYes.Location = New System.Drawing.Point(423, 279)
        Me.rdbUseSelectedSingleLugYes.Name = "rdbUseSelectedSingleLugYes"
        Me.rdbUseSelectedSingleLugYes.Size = New System.Drawing.Size(43, 17)
        Me.rdbUseSelectedSingleLugYes.TabIndex = 146
        Me.rdbUseSelectedSingleLugYes.TabStop = True
        Me.rdbUseSelectedSingleLugYes.Text = "Yes"
        Me.rdbUseSelectedSingleLugYes.UseVisualStyleBackColor = True
        '
        'txtRequiredLugGap_DLCasting
        '
        Me.txtRequiredLugGap_DLCasting.AcceptEnterKeyAsTab = True
        Me.txtRequiredLugGap_DLCasting.ApplyIFLColor = True
        Me.txtRequiredLugGap_DLCasting.AssociateLabel = Nothing
        Me.txtRequiredLugGap_DLCasting.DecimalValue = 2
        Me.txtRequiredLugGap_DLCasting.IFLDataTag = Nothing
        Me.txtRequiredLugGap_DLCasting.InvalidInputCharacters = ""
        Me.txtRequiredLugGap_DLCasting.IsAllowNegative = False
        Me.txtRequiredLugGap_DLCasting.LengthValue = 6
        Me.txtRequiredLugGap_DLCasting.Location = New System.Drawing.Point(180, 278)
        Me.txtRequiredLugGap_DLCasting.MaximumValue = 99999
        Me.txtRequiredLugGap_DLCasting.MaxLength = 6
        Me.txtRequiredLugGap_DLCasting.MinimumValue = 0
        Me.txtRequiredLugGap_DLCasting.Name = "txtRequiredLugGap_DLCasting"
        Me.txtRequiredLugGap_DLCasting.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredLugGap_DLCasting.StatusMessage = ""
        Me.txtRequiredLugGap_DLCasting.StatusObject = Nothing
        Me.txtRequiredLugGap_DLCasting.TabIndex = 24
        Me.txtRequiredLugGap_DLCasting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLugGap_DLCasting
        '
        Me.txtLugGap_DLCasting.AcceptEnterKeyAsTab = True
        Me.txtLugGap_DLCasting.ApplyIFLColor = True
        Me.txtLugGap_DLCasting.AssociateLabel = Nothing
        Me.txtLugGap_DLCasting.DecimalValue = 2
        Me.txtLugGap_DLCasting.IFLDataTag = Nothing
        Me.txtLugGap_DLCasting.InvalidInputCharacters = ""
        Me.txtLugGap_DLCasting.IsAllowNegative = False
        Me.txtLugGap_DLCasting.LengthValue = 6
        Me.txtLugGap_DLCasting.Location = New System.Drawing.Point(109, 278)
        Me.txtLugGap_DLCasting.MaximumValue = 99999
        Me.txtLugGap_DLCasting.MaxLength = 6
        Me.txtLugGap_DLCasting.MinimumValue = 0
        Me.txtLugGap_DLCasting.Name = "txtLugGap_DLCasting"
        Me.txtLugGap_DLCasting.Size = New System.Drawing.Size(66, 20)
        Me.txtLugGap_DLCasting.StatusMessage = ""
        Me.txtLugGap_DLCasting.StatusObject = Nothing
        Me.txtLugGap_DLCasting.TabIndex = 24
        Me.txtLugGap_DLCasting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLugGap_DLCasting
        '
        Me.lblLugGap_DLCasting.AutoSize = True
        Me.lblLugGap_DLCasting.Location = New System.Drawing.Point(27, 281)
        Me.lblLugGap_DLCasting.Name = "lblLugGap_DLCasting"
        Me.lblLugGap_DLCasting.Size = New System.Drawing.Size(48, 13)
        Me.lblLugGap_DLCasting.TabIndex = 143
        Me.lblLugGap_DLCasting.Text = "Lug Gap"
        '
        'lblRequired
        '
        Me.lblRequired.AutoSize = True
        Me.lblRequired.Location = New System.Drawing.Point(189, 166)
        Me.lblRequired.Name = "lblRequired"
        Me.lblRequired.Size = New System.Drawing.Size(50, 13)
        Me.lblRequired.TabIndex = 141
        Me.lblRequired.Text = "Required"
        '
        'txtSwingClearance_DLCasting
        '
        Me.txtSwingClearance_DLCasting.AcceptEnterKeyAsTab = True
        Me.txtSwingClearance_DLCasting.ApplyIFLColor = True
        Me.txtSwingClearance_DLCasting.AssociateLabel = Nothing
        Me.txtSwingClearance_DLCasting.DecimalValue = 2
        Me.txtSwingClearance_DLCasting.IFLDataTag = Nothing
        Me.txtSwingClearance_DLCasting.InvalidInputCharacters = ""
        Me.txtSwingClearance_DLCasting.IsAllowNegative = False
        Me.txtSwingClearance_DLCasting.LengthValue = 6
        Me.txtSwingClearance_DLCasting.Location = New System.Drawing.Point(379, 251)
        Me.txtSwingClearance_DLCasting.MaximumValue = 99999
        Me.txtSwingClearance_DLCasting.MaxLength = 6
        Me.txtSwingClearance_DLCasting.MinimumValue = 0
        Me.txtSwingClearance_DLCasting.Name = "txtSwingClearance_DLCasting"
        Me.txtSwingClearance_DLCasting.Size = New System.Drawing.Size(66, 20)
        Me.txtSwingClearance_DLCasting.StatusMessage = ""
        Me.txtSwingClearance_DLCasting.StatusObject = Nothing
        Me.txtSwingClearance_DLCasting.TabIndex = 25
        Me.txtSwingClearance_DLCasting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSwingClearance_DLCasting
        '
        Me.lblSwingClearance_DLCasting.AutoSize = True
        Me.lblSwingClearance_DLCasting.Location = New System.Drawing.Point(286, 255)
        Me.lblSwingClearance_DLCasting.Name = "lblSwingClearance_DLCasting"
        Me.lblSwingClearance_DLCasting.Size = New System.Drawing.Size(87, 13)
        Me.lblSwingClearance_DLCasting.TabIndex = 114
        Me.lblSwingClearance_DLCasting.Text = "Swing Clearance"
        '
        'txtRequiredSwingClearance_DLCasting
        '
        Me.txtRequiredSwingClearance_DLCasting.AcceptEnterKeyAsTab = True
        Me.txtRequiredSwingClearance_DLCasting.ApplyIFLColor = True
        Me.txtRequiredSwingClearance_DLCasting.AssociateLabel = Nothing
        Me.txtRequiredSwingClearance_DLCasting.DecimalValue = 2
        Me.txtRequiredSwingClearance_DLCasting.IFLDataTag = Nothing
        Me.txtRequiredSwingClearance_DLCasting.InvalidInputCharacters = ""
        Me.txtRequiredSwingClearance_DLCasting.IsAllowNegative = False
        Me.txtRequiredSwingClearance_DLCasting.LengthValue = 6
        Me.txtRequiredSwingClearance_DLCasting.Location = New System.Drawing.Point(450, 251)
        Me.txtRequiredSwingClearance_DLCasting.MaximumValue = 99999
        Me.txtRequiredSwingClearance_DLCasting.MaxLength = 6
        Me.txtRequiredSwingClearance_DLCasting.MinimumValue = 0
        Me.txtRequiredSwingClearance_DLCasting.Name = "txtRequiredSwingClearance_DLCasting"
        Me.txtRequiredSwingClearance_DLCasting.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredSwingClearance_DLCasting.StatusMessage = ""
        Me.txtRequiredSwingClearance_DLCasting.StatusObject = Nothing
        Me.txtRequiredSwingClearance_DLCasting.TabIndex = 26
        Me.txtRequiredSwingClearance_DLCasting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredLugThickness_DLCasting
        '
        Me.txtRequiredLugThickness_DLCasting.AcceptEnterKeyAsTab = True
        Me.txtRequiredLugThickness_DLCasting.ApplyIFLColor = True
        Me.txtRequiredLugThickness_DLCasting.AssociateLabel = Nothing
        Me.txtRequiredLugThickness_DLCasting.DecimalValue = 2
        Me.txtRequiredLugThickness_DLCasting.IFLDataTag = Nothing
        Me.txtRequiredLugThickness_DLCasting.InvalidInputCharacters = ""
        Me.txtRequiredLugThickness_DLCasting.IsAllowNegative = False
        Me.txtRequiredLugThickness_DLCasting.LengthValue = 6
        Me.txtRequiredLugThickness_DLCasting.Location = New System.Drawing.Point(181, 251)
        Me.txtRequiredLugThickness_DLCasting.MaximumValue = 99999
        Me.txtRequiredLugThickness_DLCasting.MaxLength = 6
        Me.txtRequiredLugThickness_DLCasting.MinimumValue = 0
        Me.txtRequiredLugThickness_DLCasting.Name = "txtRequiredLugThickness_DLCasting"
        Me.txtRequiredLugThickness_DLCasting.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredLugThickness_DLCasting.StatusMessage = ""
        Me.txtRequiredLugThickness_DLCasting.StatusObject = Nothing
        Me.txtRequiredLugThickness_DLCasting.TabIndex = 19
        Me.txtRequiredLugThickness_DLCasting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredPinHoleSize_DLCasting
        '
        Me.txtRequiredPinHoleSize_DLCasting.AcceptEnterKeyAsTab = True
        Me.txtRequiredPinHoleSize_DLCasting.ApplyIFLColor = True
        Me.txtRequiredPinHoleSize_DLCasting.AssociateLabel = Nothing
        Me.txtRequiredPinHoleSize_DLCasting.DecimalValue = 2
        Me.txtRequiredPinHoleSize_DLCasting.IFLDataTag = Nothing
        Me.txtRequiredPinHoleSize_DLCasting.InvalidInputCharacters = ""
        Me.txtRequiredPinHoleSize_DLCasting.IsAllowNegative = False
        Me.txtRequiredPinHoleSize_DLCasting.LengthValue = 6
        Me.txtRequiredPinHoleSize_DLCasting.Location = New System.Drawing.Point(450, 223)
        Me.txtRequiredPinHoleSize_DLCasting.MaximumValue = 99999
        Me.txtRequiredPinHoleSize_DLCasting.MaxLength = 6
        Me.txtRequiredPinHoleSize_DLCasting.MinimumValue = 0
        Me.txtRequiredPinHoleSize_DLCasting.Name = "txtRequiredPinHoleSize_DLCasting"
        Me.txtRequiredPinHoleSize_DLCasting.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredPinHoleSize_DLCasting.StatusMessage = ""
        Me.txtRequiredPinHoleSize_DLCasting.StatusObject = Nothing
        Me.txtRequiredPinHoleSize_DLCasting.TabIndex = 23
        Me.txtRequiredPinHoleSize_DLCasting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnPicInformation
        '
        Me.btnPicInformation.Enabled = False
        Me.btnPicInformation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPicInformation.Location = New System.Drawing.Point(415, 88)
        Me.btnPicInformation.Name = "btnPicInformation"
        Me.btnPicInformation.Size = New System.Drawing.Size(95, 23)
        Me.btnPicInformation.TabIndex = 131
        Me.btnPicInformation.Text = "Show Image"
        Me.btnPicInformation.UseVisualStyleBackColor = True
        '
        'picDLcasting
        '
        Me.picDLcasting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picDLcasting.Location = New System.Drawing.Point(386, 33)
        Me.picDLcasting.Name = "picDLcasting"
        Me.picDLcasting.Size = New System.Drawing.Size(151, 122)
        Me.picDLcasting.TabIndex = 130
        Me.picDLcasting.TabStop = False
        '
        'txtLugThickness_DLCasting
        '
        Me.txtLugThickness_DLCasting.AcceptEnterKeyAsTab = True
        Me.txtLugThickness_DLCasting.ApplyIFLColor = True
        Me.txtLugThickness_DLCasting.AssociateLabel = Nothing
        Me.txtLugThickness_DLCasting.DecimalValue = 2
        Me.txtLugThickness_DLCasting.IFLDataTag = Nothing
        Me.txtLugThickness_DLCasting.InvalidInputCharacters = ""
        Me.txtLugThickness_DLCasting.IsAllowNegative = False
        Me.txtLugThickness_DLCasting.LengthValue = 6
        Me.txtLugThickness_DLCasting.Location = New System.Drawing.Point(109, 251)
        Me.txtLugThickness_DLCasting.MaximumValue = 99999
        Me.txtLugThickness_DLCasting.MaxLength = 6
        Me.txtLugThickness_DLCasting.MinimumValue = 0
        Me.txtLugThickness_DLCasting.Name = "txtLugThickness_DLCasting"
        Me.txtLugThickness_DLCasting.Size = New System.Drawing.Size(66, 20)
        Me.txtLugThickness_DLCasting.StatusMessage = ""
        Me.txtLugThickness_DLCasting.StatusObject = Nothing
        Me.txtLugThickness_DLCasting.TabIndex = 18
        Me.txtLugThickness_DLCasting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLugThickness_DLCasting
        '
        Me.lblLugThickness_DLCasting.AutoSize = True
        Me.lblLugThickness_DLCasting.Location = New System.Drawing.Point(27, 255)
        Me.lblLugThickness_DLCasting.Name = "lblLugThickness_DLCasting"
        Me.lblLugThickness_DLCasting.Size = New System.Drawing.Size(77, 13)
        Me.lblLugThickness_DLCasting.TabIndex = 128
        Me.lblLugThickness_DLCasting.Text = "Lug Thickness"
        '
        'txtWeldSize_DLCasting
        '
        Me.txtWeldSize_DLCasting.AcceptEnterKeyAsTab = True
        Me.txtWeldSize_DLCasting.ApplyIFLColor = True
        Me.txtWeldSize_DLCasting.AssociateLabel = Nothing
        Me.txtWeldSize_DLCasting.DecimalValue = 2
        Me.txtWeldSize_DLCasting.IFLDataTag = Nothing
        Me.txtWeldSize_DLCasting.InvalidInputCharacters = ""
        Me.txtWeldSize_DLCasting.IsAllowNegative = False
        Me.txtWeldSize_DLCasting.LengthValue = 6
        Me.txtWeldSize_DLCasting.Location = New System.Drawing.Point(378, 194)
        Me.txtWeldSize_DLCasting.MaximumValue = 99999
        Me.txtWeldSize_DLCasting.MaxLength = 6
        Me.txtWeldSize_DLCasting.MinimumValue = 0
        Me.txtWeldSize_DLCasting.Name = "txtWeldSize_DLCasting"
        Me.txtWeldSize_DLCasting.Size = New System.Drawing.Size(66, 20)
        Me.txtWeldSize_DLCasting.StatusMessage = ""
        Me.txtWeldSize_DLCasting.StatusObject = Nothing
        Me.txtWeldSize_DLCasting.TabIndex = 27
        Me.txtWeldSize_DLCasting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblWeldSize_DLCasting
        '
        Me.lblWeldSize_DLCasting.AutoSize = True
        Me.lblWeldSize_DLCasting.Location = New System.Drawing.Point(286, 197)
        Me.lblWeldSize_DLCasting.Name = "lblWeldSize_DLCasting"
        Me.lblWeldSize_DLCasting.Size = New System.Drawing.Size(55, 13)
        Me.lblWeldSize_DLCasting.TabIndex = 122
        Me.lblWeldSize_DLCasting.Text = "Weld Size"
        '
        'txtLugWidth_DLCasting
        '
        Me.txtLugWidth_DLCasting.AcceptEnterKeyAsTab = True
        Me.txtLugWidth_DLCasting.ApplyIFLColor = True
        Me.txtLugWidth_DLCasting.AssociateLabel = Nothing
        Me.txtLugWidth_DLCasting.DecimalValue = 2
        Me.txtLugWidth_DLCasting.IFLDataTag = Nothing
        Me.txtLugWidth_DLCasting.InvalidInputCharacters = ""
        Me.txtLugWidth_DLCasting.IsAllowNegative = False
        Me.txtLugWidth_DLCasting.LengthValue = 6
        Me.txtLugWidth_DLCasting.Location = New System.Drawing.Point(109, 221)
        Me.txtLugWidth_DLCasting.MaximumValue = 99999
        Me.txtLugWidth_DLCasting.MaxLength = 6
        Me.txtLugWidth_DLCasting.MinimumValue = 0
        Me.txtLugWidth_DLCasting.Name = "txtLugWidth_DLCasting"
        Me.txtLugWidth_DLCasting.Size = New System.Drawing.Size(66, 20)
        Me.txtLugWidth_DLCasting.StatusMessage = ""
        Me.txtLugWidth_DLCasting.StatusObject = Nothing
        Me.txtLugWidth_DLCasting.TabIndex = 20
        Me.txtLugWidth_DLCasting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLugsWidth_DLCasting
        '
        Me.lblLugsWidth_DLCasting.AutoSize = True
        Me.lblLugsWidth_DLCasting.Location = New System.Drawing.Point(27, 226)
        Me.lblLugsWidth_DLCasting.Name = "lblLugsWidth_DLCasting"
        Me.lblLugsWidth_DLCasting.Size = New System.Drawing.Size(56, 13)
        Me.lblLugsWidth_DLCasting.TabIndex = 120
        Me.lblLugsWidth_DLCasting.Text = "Lug Width"
        '
        'txtPinHoleSize_DLCasting
        '
        Me.txtPinHoleSize_DLCasting.AcceptEnterKeyAsTab = True
        Me.txtPinHoleSize_DLCasting.ApplyIFLColor = True
        Me.txtPinHoleSize_DLCasting.AssociateLabel = Nothing
        Me.txtPinHoleSize_DLCasting.DecimalValue = 2
        Me.txtPinHoleSize_DLCasting.IFLDataTag = Nothing
        Me.txtPinHoleSize_DLCasting.InvalidInputCharacters = ""
        Me.txtPinHoleSize_DLCasting.IsAllowNegative = False
        Me.txtPinHoleSize_DLCasting.LengthValue = 6
        Me.txtPinHoleSize_DLCasting.Location = New System.Drawing.Point(378, 223)
        Me.txtPinHoleSize_DLCasting.MaximumValue = 99999
        Me.txtPinHoleSize_DLCasting.MaxLength = 6
        Me.txtPinHoleSize_DLCasting.MinimumValue = 0
        Me.txtPinHoleSize_DLCasting.Name = "txtPinHoleSize_DLCasting"
        Me.txtPinHoleSize_DLCasting.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleSize_DLCasting.StatusMessage = ""
        Me.txtPinHoleSize_DLCasting.StatusObject = Nothing
        Me.txtPinHoleSize_DLCasting.TabIndex = 22
        Me.txtPinHoleSize_DLCasting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPinHoleSize_DLCasting
        '
        Me.lblPinHoleSize_DLCasting.AutoSize = True
        Me.lblPinHoleSize_DLCasting.Location = New System.Drawing.Point(286, 226)
        Me.lblPinHoleSize_DLCasting.Name = "lblPinHoleSize_DLCasting"
        Me.lblPinHoleSize_DLCasting.Size = New System.Drawing.Size(70, 13)
        Me.lblPinHoleSize_DLCasting.TabIndex = 116
        Me.lblPinHoleSize_DLCasting.Text = "Pin Hole Size"
        '
        'txtCodeNumber_DLCasting
        '
        Me.txtCodeNumber_DLCasting.AcceptEnterKeyAsTab = True
        Me.txtCodeNumber_DLCasting.ApplyIFLColor = True
        Me.txtCodeNumber_DLCasting.AssociateLabel = Nothing
        Me.txtCodeNumber_DLCasting.DecimalValue = 2
        Me.txtCodeNumber_DLCasting.IFLDataTag = Nothing
        Me.txtCodeNumber_DLCasting.InvalidInputCharacters = ""
        Me.txtCodeNumber_DLCasting.IsAllowNegative = False
        Me.txtCodeNumber_DLCasting.LengthValue = 6
        Me.txtCodeNumber_DLCasting.Location = New System.Drawing.Point(109, 194)
        Me.txtCodeNumber_DLCasting.MaximumValue = 99999
        Me.txtCodeNumber_DLCasting.MaxLength = 6
        Me.txtCodeNumber_DLCasting.MinimumValue = 0
        Me.txtCodeNumber_DLCasting.Name = "txtCodeNumber_DLCasting"
        Me.txtCodeNumber_DLCasting.Size = New System.Drawing.Size(66, 20)
        Me.txtCodeNumber_DLCasting.StatusMessage = ""
        Me.txtCodeNumber_DLCasting.StatusObject = Nothing
        Me.txtCodeNumber_DLCasting.TabIndex = 17
        Me.txtCodeNumber_DLCasting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCodeNumber_DLCasting
        '
        Me.lblCodeNumber_DLCasting.AutoSize = True
        Me.lblCodeNumber_DLCasting.Location = New System.Drawing.Point(27, 197)
        Me.lblCodeNumber_DLCasting.Name = "lblCodeNumber_DLCasting"
        Me.lblCodeNumber_DLCasting.Size = New System.Drawing.Size(72, 13)
        Me.lblCodeNumber_DLCasting.TabIndex = 112
        Me.lblCodeNumber_DLCasting.Text = "Code Number"
        '
        'lvwDLCastingDetails
        '
        Me.lvwDLCastingDetails.FullRowSelect = True
        Me.lvwDLCastingDetails.GridLines = True
        Me.lvwDLCastingDetails.Location = New System.Drawing.Point(6, 33)
        Me.lvwDLCastingDetails.MultiSelect = False
        Me.lvwDLCastingDetails.Name = "lvwDLCastingDetails"
        Me.lvwDLCastingDetails.Scrollable = False
        Me.lvwDLCastingDetails.Size = New System.Drawing.Size(369, 122)
        Me.lvwDLCastingDetails.TabIndex = 16
        Me.lvwDLCastingDetails.UseCompatibleStateImageBehavior = False
        Me.lvwDLCastingDetails.View = System.Windows.Forms.View.Details
        '
        'lblExistingDoubleLugIndex_RodEnd
        '
        Me.lblExistingDoubleLugIndex_RodEnd.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblExistingDoubleLugIndex_RodEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExistingDoubleLugIndex_RodEnd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblExistingDoubleLugIndex_RodEnd.GradientColorOne = System.Drawing.Color.Olive
        Me.lblExistingDoubleLugIndex_RodEnd.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblExistingDoubleLugIndex_RodEnd.Location = New System.Drawing.Point(-3, 0)
        Me.lblExistingDoubleLugIndex_RodEnd.Name = "lblExistingDoubleLugIndex_RodEnd"
        Me.lblExistingDoubleLugIndex_RodEnd.Size = New System.Drawing.Size(546, 19)
        Me.lblExistingDoubleLugIndex_RodEnd.TabIndex = 110
        Me.lblExistingDoubleLugIndex_RodEnd.Text = "Existing RodEnd  Double Lug Casting Details"
        Me.lblExistingDoubleLugIndex_RodEnd.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grbUsingSelectedDLCasting
        '
        Me.grbUsingSelectedDLCasting.BackColor = System.Drawing.Color.Ivory
        Me.grbUsingSelectedDLCasting.Controls.Add(Me.rdbNewCasting_DlCasting)
        Me.grbUsingSelectedDLCasting.Controls.Add(Me.rdbResize_DLCasting)
        Me.grbUsingSelectedDLCasting.Controls.Add(Me.lblIsExactMatch)
        Me.grbUsingSelectedDLCasting.Controls.Add(Me.rdbExactMatchYes)
        Me.grbUsingSelectedDLCasting.Controls.Add(Me.lblUseSelectedDoubleLugCasting)
        Me.grbUsingSelectedDLCasting.Location = New System.Drawing.Point(22, 340)
        Me.grbUsingSelectedDLCasting.Name = "grbUsingSelectedDLCasting"
        Me.grbUsingSelectedDLCasting.Size = New System.Drawing.Size(543, 148)
        Me.grbUsingSelectedDLCasting.TabIndex = 33
        Me.grbUsingSelectedDLCasting.TabStop = False
        '
        'rdbNewCasting_DlCasting
        '
        Me.rdbNewCasting_DlCasting.AutoSize = True
        Me.rdbNewCasting_DlCasting.Location = New System.Drawing.Point(341, 65)
        Me.rdbNewCasting_DlCasting.Name = "rdbNewCasting_DlCasting"
        Me.rdbNewCasting_DlCasting.Size = New System.Drawing.Size(85, 17)
        Me.rdbNewCasting_DlCasting.TabIndex = 37
        Me.rdbNewCasting_DlCasting.TabStop = True
        Me.rdbNewCasting_DlCasting.Text = "New Casting"
        Me.rdbNewCasting_DlCasting.UseVisualStyleBackColor = True
        '
        'rdbResize_DLCasting
        '
        Me.rdbResize_DLCasting.AutoSize = True
        Me.rdbResize_DLCasting.Location = New System.Drawing.Point(271, 65)
        Me.rdbResize_DLCasting.Name = "rdbResize_DLCasting"
        Me.rdbResize_DLCasting.Size = New System.Drawing.Size(57, 17)
        Me.rdbResize_DLCasting.TabIndex = 36
        Me.rdbResize_DLCasting.TabStop = True
        Me.rdbResize_DLCasting.Text = "Resize"
        Me.rdbResize_DLCasting.UseVisualStyleBackColor = True
        '
        'lblIsExactMatch
        '
        Me.lblIsExactMatch.AutoSize = True
        Me.lblIsExactMatch.Location = New System.Drawing.Point(115, 67)
        Me.lblIsExactMatch.Name = "lblIsExactMatch"
        Me.lblIsExactMatch.Size = New System.Drawing.Size(87, 13)
        Me.lblIsExactMatch.TabIndex = 151
        Me.lblIsExactMatch.Text = "Is Exact Match ?"
        '
        'rdbExactMatchYes
        '
        Me.rdbExactMatchYes.AutoSize = True
        Me.rdbExactMatchYes.Location = New System.Drawing.Point(215, 65)
        Me.rdbExactMatchYes.Name = "rdbExactMatchYes"
        Me.rdbExactMatchYes.Size = New System.Drawing.Size(43, 17)
        Me.rdbExactMatchYes.TabIndex = 149
        Me.rdbExactMatchYes.TabStop = True
        Me.rdbExactMatchYes.Text = "Yes"
        Me.rdbExactMatchYes.UseVisualStyleBackColor = True
        '
        'lblUseSelectedDoubleLugCasting
        '
        Me.lblUseSelectedDoubleLugCasting.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblUseSelectedDoubleLugCasting.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUseSelectedDoubleLugCasting.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUseSelectedDoubleLugCasting.GradientColorOne = System.Drawing.Color.Olive
        Me.lblUseSelectedDoubleLugCasting.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblUseSelectedDoubleLugCasting.Location = New System.Drawing.Point(-2, 0)
        Me.lblUseSelectedDoubleLugCasting.Name = "lblUseSelectedDoubleLugCasting"
        Me.lblUseSelectedDoubleLugCasting.Size = New System.Drawing.Size(545, 19)
        Me.lblUseSelectedDoubleLugCasting.TabIndex = 111
        Me.lblUseSelectedDoubleLugCasting.Text = "Use Selected  Double Lug Casting"
        Me.lblUseSelectedDoubleLugCasting.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBackGround
        '
        Me.lblBackGround.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblBackGround.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBackGround.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBackGround.GradientColorOne = System.Drawing.Color.DarkGoldenrod
        Me.lblBackGround.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblBackGround.Location = New System.Drawing.Point(3, 0)
        Me.lblBackGround.Name = "lblBackGround"
        Me.lblBackGround.Size = New System.Drawing.Size(578, 507)
        Me.lblBackGround.TabIndex = 120
        Me.lblBackGround.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlREDLCastingNo
        '
        Me.pnlREDLCastingNo.BackColor = System.Drawing.Color.Black
        Me.pnlREDLCastingNo.Controls.Add(Me.pnlREDLSafetyFactor_Weight_LugThickness)
        Me.pnlREDLCastingNo.Controls.Add(Me.pnlREDLDesignaCasting)
        Me.pnlREDLCastingNo.Controls.Add(Me.LabelGradient5)
        Me.pnlREDLCastingNo.Location = New System.Drawing.Point(3, 3)
        Me.pnlREDLCastingNo.Name = "pnlREDLCastingNo"
        Me.pnlREDLCastingNo.Size = New System.Drawing.Size(824, 538)
        Me.pnlREDLCastingNo.TabIndex = 2
        '
        'pnlREDLSafetyFactor_Weight_LugThickness
        '
        Me.pnlREDLSafetyFactor_Weight_LugThickness.BackColor = System.Drawing.Color.Ivory
        Me.pnlREDLSafetyFactor_Weight_LugThickness.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlREDLSafetyFactor_Weight_LugThickness.Controls.Add(Me.lvwREDLSafetyFactor_Weight)
        Me.pnlREDLSafetyFactor_Weight_LugThickness.Controls.Add(Me.lblSafetyFactorIndex_REDL)
        Me.pnlREDLSafetyFactor_Weight_LugThickness.Controls.Add(Me.btnAccept_REDL)
        Me.pnlREDLSafetyFactor_Weight_LugThickness.Location = New System.Drawing.Point(190, 274)
        Me.pnlREDLSafetyFactor_Weight_LugThickness.Name = "pnlREDLSafetyFactor_Weight_LugThickness"
        Me.pnlREDLSafetyFactor_Weight_LugThickness.Size = New System.Drawing.Size(445, 184)
        Me.pnlREDLSafetyFactor_Weight_LugThickness.TabIndex = 151
        '
        'lvwREDLSafetyFactor_Weight
        '
        Me.lvwREDLSafetyFactor_Weight.GridLines = True
        Me.lvwREDLSafetyFactor_Weight.Location = New System.Drawing.Point(25, 29)
        Me.lvwREDLSafetyFactor_Weight.Name = "lvwREDLSafetyFactor_Weight"
        Me.lvwREDLSafetyFactor_Weight.Size = New System.Drawing.Size(390, 116)
        Me.lvwREDLSafetyFactor_Weight.TabIndex = 13
        Me.lvwREDLSafetyFactor_Weight.UseCompatibleStateImageBehavior = False
        Me.lvwREDLSafetyFactor_Weight.View = System.Windows.Forms.View.Details
        '
        'lblSafetyFactorIndex_REDL
        '
        Me.lblSafetyFactorIndex_REDL.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblSafetyFactorIndex_REDL.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSafetyFactorIndex_REDL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSafetyFactorIndex_REDL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSafetyFactorIndex_REDL.GradientColorOne = System.Drawing.Color.Olive
        Me.lblSafetyFactorIndex_REDL.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblSafetyFactorIndex_REDL.Location = New System.Drawing.Point(0, 0)
        Me.lblSafetyFactorIndex_REDL.Name = "lblSafetyFactorIndex_REDL"
        Me.lblSafetyFactorIndex_REDL.Size = New System.Drawing.Size(441, 19)
        Me.lblSafetyFactorIndex_REDL.TabIndex = 159
        Me.lblSafetyFactorIndex_REDL.Text = "Generated Design Properties"
        Me.lblSafetyFactorIndex_REDL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAccept_REDL
        '
        Me.btnAccept_REDL.Location = New System.Drawing.Point(233, 152)
        Me.btnAccept_REDL.Name = "btnAccept_REDL"
        Me.btnAccept_REDL.Size = New System.Drawing.Size(135, 23)
        Me.btnAccept_REDL.TabIndex = 151
        Me.btnAccept_REDL.Text = "Accept"
        Me.btnAccept_REDL.UseVisualStyleBackColor = True
        '
        'pnlREDLDesignaCasting
        '
        Me.pnlREDLDesignaCasting.BackColor = System.Drawing.Color.Ivory
        Me.pnlREDLDesignaCasting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlREDLDesignaCasting.Controls.Add(Me.txtSafetyFactorOfCasting_REDL)
        Me.pnlREDLDesignaCasting.Controls.Add(Me.txtLugWidth_REDL)
        Me.pnlREDLDesignaCasting.Controls.Add(Me.lblLugWidth_REDL)
        Me.pnlREDLDesignaCasting.Controls.Add(Me.lblLugThickness_REDL)
        Me.pnlREDLDesignaCasting.Controls.Add(Me.txtLugThickness_REDL)
        Me.pnlREDLDesignaCasting.Controls.Add(Me.lblSafetyFactor_REDL)
        Me.pnlREDLDesignaCasting.Controls.Add(Me.trbSafetyFactor_REDL)
        Me.pnlREDLDesignaCasting.Controls.Add(Me.lblDesignNewCasting)
        Me.pnlREDLDesignaCasting.Controls.Add(Me.btnGenerate_REDL)
        Me.pnlREDLDesignaCasting.Controls.Add(Me.txtSwingClearance_REDL)
        Me.pnlREDLDesignaCasting.Controls.Add(Me.lblSwingClearance_REDL)
        Me.pnlREDLDesignaCasting.Controls.Add(Me.txtPinHoleSize_REDL)
        Me.pnlREDLDesignaCasting.Controls.Add(Me.lblPinHoleSize_REDL)
        Me.pnlREDLDesignaCasting.Controls.Add(Me.lblLugGap_REDL)
        Me.pnlREDLDesignaCasting.Controls.Add(Me.txtLugGap_REDL)
        Me.pnlREDLDesignaCasting.Location = New System.Drawing.Point(190, 106)
        Me.pnlREDLDesignaCasting.Name = "pnlREDLDesignaCasting"
        Me.pnlREDLDesignaCasting.Size = New System.Drawing.Size(445, 161)
        Me.pnlREDLDesignaCasting.TabIndex = 150
        '
        'txtSafetyFactorOfCasting_REDL
        '
        Me.txtSafetyFactorOfCasting_REDL.AcceptEnterKeyAsTab = True
        Me.txtSafetyFactorOfCasting_REDL.ApplyIFLColor = True
        Me.txtSafetyFactorOfCasting_REDL.AssociateLabel = Nothing
        Me.txtSafetyFactorOfCasting_REDL.DecimalValue = 2
        Me.txtSafetyFactorOfCasting_REDL.IFLDataTag = Nothing
        Me.txtSafetyFactorOfCasting_REDL.InvalidInputCharacters = ""
        Me.txtSafetyFactorOfCasting_REDL.IsAllowNegative = False
        Me.txtSafetyFactorOfCasting_REDL.LengthValue = 6
        Me.txtSafetyFactorOfCasting_REDL.Location = New System.Drawing.Point(374, 33)
        Me.txtSafetyFactorOfCasting_REDL.MaximumValue = 99999
        Me.txtSafetyFactorOfCasting_REDL.MaxLength = 6
        Me.txtSafetyFactorOfCasting_REDL.MinimumValue = 0
        Me.txtSafetyFactorOfCasting_REDL.Name = "txtSafetyFactorOfCasting_REDL"
        Me.txtSafetyFactorOfCasting_REDL.Size = New System.Drawing.Size(40, 20)
        Me.txtSafetyFactorOfCasting_REDL.StatusMessage = ""
        Me.txtSafetyFactorOfCasting_REDL.StatusObject = Nothing
        Me.txtSafetyFactorOfCasting_REDL.TabIndex = 156
        Me.txtSafetyFactorOfCasting_REDL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLugWidth_REDL
        '
        Me.txtLugWidth_REDL.AcceptEnterKeyAsTab = True
        Me.txtLugWidth_REDL.ApplyIFLColor = True
        Me.txtLugWidth_REDL.AssociateLabel = Nothing
        Me.txtLugWidth_REDL.DecimalValue = 2
        Me.txtLugWidth_REDL.IFLDataTag = Nothing
        Me.txtLugWidth_REDL.InvalidInputCharacters = ""
        Me.txtLugWidth_REDL.IsAllowNegative = False
        Me.txtLugWidth_REDL.LengthValue = 6
        Me.txtLugWidth_REDL.Location = New System.Drawing.Point(134, 126)
        Me.txtLugWidth_REDL.MaximumValue = 99999
        Me.txtLugWidth_REDL.MaxLength = 6
        Me.txtLugWidth_REDL.MinimumValue = 0
        Me.txtLugWidth_REDL.Name = "txtLugWidth_REDL"
        Me.txtLugWidth_REDL.Size = New System.Drawing.Size(66, 20)
        Me.txtLugWidth_REDL.StatusMessage = ""
        Me.txtLugWidth_REDL.StatusObject = Nothing
        Me.txtLugWidth_REDL.TabIndex = 142
        Me.txtLugWidth_REDL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLugWidth_REDL
        '
        Me.lblLugWidth_REDL.AutoSize = True
        Me.lblLugWidth_REDL.Location = New System.Drawing.Point(51, 129)
        Me.lblLugWidth_REDL.Name = "lblLugWidth_REDL"
        Me.lblLugWidth_REDL.Size = New System.Drawing.Size(56, 13)
        Me.lblLugWidth_REDL.TabIndex = 143
        Me.lblLugWidth_REDL.Text = "Lug Width"
        '
        'lblLugThickness_REDL
        '
        Me.lblLugThickness_REDL.AutoSize = True
        Me.lblLugThickness_REDL.Location = New System.Drawing.Point(51, 103)
        Me.lblLugThickness_REDL.Name = "lblLugThickness_REDL"
        Me.lblLugThickness_REDL.Size = New System.Drawing.Size(77, 13)
        Me.lblLugThickness_REDL.TabIndex = 155
        Me.lblLugThickness_REDL.Text = "Lug Thickness"
        '
        'txtLugThickness_REDL
        '
        Me.txtLugThickness_REDL.AcceptEnterKeyAsTab = True
        Me.txtLugThickness_REDL.ApplyIFLColor = True
        Me.txtLugThickness_REDL.AssociateLabel = Nothing
        Me.txtLugThickness_REDL.DecimalValue = 2
        Me.txtLugThickness_REDL.IFLDataTag = Nothing
        Me.txtLugThickness_REDL.InvalidInputCharacters = ""
        Me.txtLugThickness_REDL.IsAllowNegative = False
        Me.txtLugThickness_REDL.LengthValue = 6
        Me.txtLugThickness_REDL.Location = New System.Drawing.Point(134, 100)
        Me.txtLugThickness_REDL.MaximumValue = 99999
        Me.txtLugThickness_REDL.MaxLength = 6
        Me.txtLugThickness_REDL.MinimumValue = 0
        Me.txtLugThickness_REDL.Name = "txtLugThickness_REDL"
        Me.txtLugThickness_REDL.Size = New System.Drawing.Size(66, 20)
        Me.txtLugThickness_REDL.StatusMessage = ""
        Me.txtLugThickness_REDL.StatusObject = Nothing
        Me.txtLugThickness_REDL.TabIndex = 154
        Me.txtLugThickness_REDL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSafetyFactor_REDL
        '
        Me.lblSafetyFactor_REDL.AutoSize = True
        Me.lblSafetyFactor_REDL.Location = New System.Drawing.Point(26, 33)
        Me.lblSafetyFactor_REDL.Name = "lblSafetyFactor_REDL"
        Me.lblSafetyFactor_REDL.Size = New System.Drawing.Size(70, 13)
        Me.lblSafetyFactor_REDL.TabIndex = 153
        Me.lblSafetyFactor_REDL.Text = "Safety Factor"
        '
        'trbSafetyFactor_REDL
        '
        Me.trbSafetyFactor_REDL.LargeChange = 1
        Me.trbSafetyFactor_REDL.Location = New System.Drawing.Point(102, 24)
        Me.trbSafetyFactor_REDL.Maximum = 20
        Me.trbSafetyFactor_REDL.Minimum = 2
        Me.trbSafetyFactor_REDL.Name = "trbSafetyFactor_REDL"
        Me.trbSafetyFactor_REDL.Size = New System.Drawing.Size(266, 45)
        Me.trbSafetyFactor_REDL.TabIndex = 152
        Me.trbSafetyFactor_REDL.Value = 2
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
        'btnGenerate_REDL
        '
        Me.btnGenerate_REDL.Location = New System.Drawing.Point(233, 129)
        Me.btnGenerate_REDL.Name = "btnGenerate_REDL"
        Me.btnGenerate_REDL.Size = New System.Drawing.Size(135, 23)
        Me.btnGenerate_REDL.TabIndex = 150
        Me.btnGenerate_REDL.Text = "Generate"
        Me.btnGenerate_REDL.UseVisualStyleBackColor = True
        '
        'txtSwingClearance_REDL
        '
        Me.txtSwingClearance_REDL.AcceptEnterKeyAsTab = True
        Me.txtSwingClearance_REDL.ApplyIFLColor = True
        Me.txtSwingClearance_REDL.AssociateLabel = Nothing
        Me.txtSwingClearance_REDL.DecimalValue = 2
        Me.txtSwingClearance_REDL.IFLDataTag = Nothing
        Me.txtSwingClearance_REDL.InvalidInputCharacters = ""
        Me.txtSwingClearance_REDL.IsAllowNegative = False
        Me.txtSwingClearance_REDL.LengthValue = 6
        Me.txtSwingClearance_REDL.Location = New System.Drawing.Point(323, 100)
        Me.txtSwingClearance_REDL.MaximumValue = 99999
        Me.txtSwingClearance_REDL.MaxLength = 6
        Me.txtSwingClearance_REDL.MinimumValue = 0
        Me.txtSwingClearance_REDL.Name = "txtSwingClearance_REDL"
        Me.txtSwingClearance_REDL.Size = New System.Drawing.Size(66, 20)
        Me.txtSwingClearance_REDL.StatusMessage = ""
        Me.txtSwingClearance_REDL.StatusObject = Nothing
        Me.txtSwingClearance_REDL.TabIndex = 148
        Me.txtSwingClearance_REDL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSwingClearance_REDL
        '
        Me.lblSwingClearance_REDL.AutoSize = True
        Me.lblSwingClearance_REDL.Location = New System.Drawing.Point(230, 103)
        Me.lblSwingClearance_REDL.Name = "lblSwingClearance_REDL"
        Me.lblSwingClearance_REDL.Size = New System.Drawing.Size(87, 13)
        Me.lblSwingClearance_REDL.TabIndex = 149
        Me.lblSwingClearance_REDL.Text = "Swing Clearance"
        '
        'txtPinHoleSize_REDL
        '
        Me.txtPinHoleSize_REDL.AcceptEnterKeyAsTab = True
        Me.txtPinHoleSize_REDL.ApplyIFLColor = True
        Me.txtPinHoleSize_REDL.AssociateLabel = Nothing
        Me.txtPinHoleSize_REDL.DecimalValue = 2
        Me.txtPinHoleSize_REDL.IFLDataTag = Nothing
        Me.txtPinHoleSize_REDL.InvalidInputCharacters = ""
        Me.txtPinHoleSize_REDL.IsAllowNegative = False
        Me.txtPinHoleSize_REDL.LengthValue = 6
        Me.txtPinHoleSize_REDL.Location = New System.Drawing.Point(323, 74)
        Me.txtPinHoleSize_REDL.MaximumValue = 99999
        Me.txtPinHoleSize_REDL.MaxLength = 6
        Me.txtPinHoleSize_REDL.MinimumValue = 0
        Me.txtPinHoleSize_REDL.Name = "txtPinHoleSize_REDL"
        Me.txtPinHoleSize_REDL.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleSize_REDL.StatusMessage = ""
        Me.txtPinHoleSize_REDL.StatusObject = Nothing
        Me.txtPinHoleSize_REDL.TabIndex = 146
        Me.txtPinHoleSize_REDL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPinHoleSize_REDL
        '
        Me.lblPinHoleSize_REDL.AutoSize = True
        Me.lblPinHoleSize_REDL.Location = New System.Drawing.Point(230, 77)
        Me.lblPinHoleSize_REDL.Name = "lblPinHoleSize_REDL"
        Me.lblPinHoleSize_REDL.Size = New System.Drawing.Size(70, 13)
        Me.lblPinHoleSize_REDL.TabIndex = 147
        Me.lblPinHoleSize_REDL.Text = "Pin Hole Size"
        '
        'lblLugGap_REDL
        '
        Me.lblLugGap_REDL.AutoSize = True
        Me.lblLugGap_REDL.Location = New System.Drawing.Point(51, 77)
        Me.lblLugGap_REDL.Name = "lblLugGap_REDL"
        Me.lblLugGap_REDL.Size = New System.Drawing.Size(48, 13)
        Me.lblLugGap_REDL.TabIndex = 145
        Me.lblLugGap_REDL.Text = "Lug Gap"
        '
        'txtLugGap_REDL
        '
        Me.txtLugGap_REDL.AcceptEnterKeyAsTab = True
        Me.txtLugGap_REDL.ApplyIFLColor = True
        Me.txtLugGap_REDL.AssociateLabel = Nothing
        Me.txtLugGap_REDL.DecimalValue = 2
        Me.txtLugGap_REDL.IFLDataTag = Nothing
        Me.txtLugGap_REDL.InvalidInputCharacters = ""
        Me.txtLugGap_REDL.IsAllowNegative = False
        Me.txtLugGap_REDL.LengthValue = 6
        Me.txtLugGap_REDL.Location = New System.Drawing.Point(134, 74)
        Me.txtLugGap_REDL.MaximumValue = 99999
        Me.txtLugGap_REDL.MaxLength = 6
        Me.txtLugGap_REDL.MinimumValue = 0
        Me.txtLugGap_REDL.Name = "txtLugGap_REDL"
        Me.txtLugGap_REDL.Size = New System.Drawing.Size(66, 20)
        Me.txtLugGap_REDL.StatusMessage = ""
        Me.txtLugGap_REDL.StatusObject = Nothing
        Me.txtLugGap_REDL.TabIndex = 144
        Me.txtLugGap_REDL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelGradient5
        '
        Me.LabelGradient5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LabelGradient5.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient5.GradientColorOne = System.Drawing.Color.DarkGoldenrod
        Me.LabelGradient5.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient5.Location = New System.Drawing.Point(171, 89)
        Me.LabelGradient5.Name = "LabelGradient5"
        Me.LabelGradient5.Size = New System.Drawing.Size(485, 383)
        Me.LabelGradient5.TabIndex = 149
        Me.LabelGradient5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmREDLCasting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1200, 900)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlREDLCasting_YesNo)
        Me.Controls.Add(Me.lblDLHeading)
        Me.Controls.Add(Me.LabelGradient4)
        Me.Controls.Add(Me.LabelGradient3)
        Me.Controls.Add(Me.LabelGradient2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmREDLCasting"
        Me.Text = "frmREDLCasting"
        Me.pnlREDLCasting_YesNo.ResumeLayout(False)
        Me.pnlREDLCastingYes.ResumeLayout(False)
        Me.grbREDLCastingMatched.ResumeLayout(False)
        Me.grbREDLCastingMatched.PerformLayout()
        CType(Me.picDLcasting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbUsingSelectedDLCasting.ResumeLayout(False)
        Me.grbUsingSelectedDLCasting.PerformLayout()
        Me.pnlREDLCastingNo.ResumeLayout(False)
        Me.pnlREDLSafetyFactor_Weight_LugThickness.ResumeLayout(False)
        Me.pnlREDLDesignaCasting.ResumeLayout(False)
        Me.pnlREDLDesignaCasting.PerformLayout()
        CType(Me.trbSafetyFactor_REDL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblDLHeading As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient4 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient3 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient2 As LabelGradient.LabelGradient
    Friend WithEvents pnlREDLCasting_YesNo As System.Windows.Forms.Panel
    Friend WithEvents pnlREDLCastingYes As System.Windows.Forms.Panel
    Friend WithEvents grbUsingSelectedDLCasting As System.Windows.Forms.GroupBox
    Friend WithEvents rdbNewCasting_DlCasting As System.Windows.Forms.RadioButton
    Friend WithEvents rdbResize_DLCasting As System.Windows.Forms.RadioButton
    Friend WithEvents lblUseSelectedDoubleLugCasting As LabelGradient.LabelGradient
    Friend WithEvents grbREDLCastingMatched As System.Windows.Forms.GroupBox
    Friend WithEvents txtRequiredLugGap_DLCasting As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtLugGap_DLCasting As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblLugGap_DLCasting As System.Windows.Forms.Label
    Friend WithEvents lblRequired As System.Windows.Forms.Label
    Friend WithEvents txtSwingClearance_DLCasting As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSwingClearance_DLCasting As System.Windows.Forms.Label
    Friend WithEvents txtRequiredSwingClearance_DLCasting As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredLugThickness_DLCasting As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredPinHoleSize_DLCasting As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents btnPicInformation As System.Windows.Forms.Button
    Friend WithEvents picDLcasting As System.Windows.Forms.PictureBox
    Friend WithEvents txtLugThickness_DLCasting As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblLugThickness_DLCasting As System.Windows.Forms.Label
    Friend WithEvents txtWeldSize_DLCasting As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblWeldSize_DLCasting As System.Windows.Forms.Label
    Friend WithEvents txtLugWidth_DLCasting As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblLugsWidth_DLCasting As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleSize_DLCasting As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblPinHoleSize_DLCasting As System.Windows.Forms.Label
    Friend WithEvents txtCodeNumber_DLCasting As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblCodeNumber_DLCasting As System.Windows.Forms.Label
    Friend WithEvents lvwDLCastingDetails As Monarch_WeldedCylinder_01_09_09.clsListViewMIL
    Friend WithEvents lblExistingDoubleLugIndex_RodEnd As LabelGradient.LabelGradient
    Friend WithEvents lblBackGround As LabelGradient.LabelGradient
    Friend WithEvents pnlREDLCastingNo As System.Windows.Forms.Panel
    Friend WithEvents LabelGradient5 As LabelGradient.LabelGradient
    Friend WithEvents pnlREDLSafetyFactor_Weight_LugThickness As System.Windows.Forms.Panel
    Friend WithEvents lvwREDLSafetyFactor_Weight As Monarch_WeldedCylinder_01_09_09.clsListViewMIL
    Friend WithEvents lblSafetyFactorIndex_REDL As LabelGradient.LabelGradient
    Friend WithEvents pnlREDLDesignaCasting As System.Windows.Forms.Panel
    Friend WithEvents txtSafetyFactorOfCasting_REDL As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtLugWidth_REDL As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblLugWidth_REDL As System.Windows.Forms.Label
    Friend WithEvents lblLugThickness_REDL As System.Windows.Forms.Label
    Friend WithEvents txtLugThickness_REDL As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSafetyFactor_REDL As System.Windows.Forms.Label
    Friend WithEvents trbSafetyFactor_REDL As System.Windows.Forms.TrackBar
    Friend WithEvents lblDesignNewCasting As LabelGradient.LabelGradient
    Friend WithEvents btnAccept_REDL As System.Windows.Forms.Button
    Friend WithEvents btnGenerate_REDL As System.Windows.Forms.Button
    Friend WithEvents txtSwingClearance_REDL As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSwingClearance_REDL As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleSize_REDL As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblPinHoleSize_REDL As System.Windows.Forms.Label
    Friend WithEvents lblLugGap_REDL As System.Windows.Forms.Label
    Friend WithEvents txtLugGap_REDL As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblUseSelectedSingleLug As System.Windows.Forms.Label
    Friend WithEvents rdbUseSelectedSingleLugNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbUseSelectedSingleLugYes As System.Windows.Forms.RadioButton
    Friend WithEvents lblIsExactMatch As System.Windows.Forms.Label
    Friend WithEvents rdbExactMatchYes As System.Windows.Forms.RadioButton
    Friend WithEvents btnPleaseChangeTheRodDiameter As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
