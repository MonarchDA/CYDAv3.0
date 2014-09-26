<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREBHDetails
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
        Me.plnMatchingBHREFound = New System.Windows.Forms.Panel
        Me.btnPleaseChangeTheRodDiameter = New System.Windows.Forms.Button
        Me.grbREBHDetailsMached_RodEnd = New System.Windows.Forms.GroupBox
        Me.lblUseSelectedBH = New System.Windows.Forms.Label
        Me.rdbUseSelectedBHNo = New System.Windows.Forms.RadioButton
        Me.rdbUseSlectedBHYes = New System.Windows.Forms.RadioButton
        Me.txtPinHoleTole_Neg_Req = New IFLCustomUILayer.IFLNumericBox
        Me.txtPinHoleTole_Pos_Req = New IFLCustomUILayer.IFLNumericBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPinHoleTole_Neg = New IFLCustomUILayer.IFLNumericBox
        Me.txtPinHoleTole_Pos = New IFLCustomUILayer.IFLNumericBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtRequiredLugHeight_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.txtLugHeight_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.lblLugHeight_RodEnd = New System.Windows.Forms.Label
        Me.lblRequired = New System.Windows.Forms.Label
        Me.txtSwingClearance_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredAngle2_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.lblSwingClearance_RodEnd = New System.Windows.Forms.Label
        Me.txtRequiredAngle1_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredSwingClearance_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredGreaseZerk_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredLugsWidth_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredLugThickness_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredPinHoleSize_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.btnPicInformation = New System.Windows.Forms.Button
        Me.picREBHMatched_RodEnd = New System.Windows.Forms.PictureBox
        Me.txtLugThickness_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.lblLugThickness_RodEnd = New System.Windows.Forms.Label
        Me.txtAngle2_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.lblAngle2_RodEnd = New System.Windows.Forms.Label
        Me.txtAngle1_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.lblAngle1_RodEnd = New System.Windows.Forms.Label
        Me.txtGreaseZerk_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.lblGreaseZerk_RodEnd = New System.Windows.Forms.Label
        Me.txtLugsWidth_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.lblLugsWidth_RodEnd = New System.Windows.Forms.Label
        Me.txtPinHoleSize_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.lblPinHoleSize_RodEnd = New System.Windows.Forms.Label
        Me.txtCodeNumber_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.lblCodeNumber_RodEnd = New System.Windows.Forms.Label
        Me.lblExistingBHIndex_RodEnd = New LabelGradient.LabelGradient
        Me.grbUsingSelectedBH_RodEnd = New System.Windows.Forms.GroupBox
        Me.rdbNewCasting_RodEnd = New System.Windows.Forms.RadioButton
        Me.rdbResize_RodEnd = New System.Windows.Forms.RadioButton
        Me.rdbUseSelectedBHYes = New System.Windows.Forms.RadioButton
        Me.lblUsingSelectedBH_RodEnd = New LabelGradient.LabelGradient
        Me.lblBackGround = New LabelGradient.LabelGradient
        Me.grbNotUsingSelectedcrosstubeCasting_RECT = New System.Windows.Forms.GroupBox
        Me.lblNotUsingSelectedBH = New LabelGradient.LabelGradient
        Me.btnClickNextButton = New System.Windows.Forms.Button
        Me.lblBHHeading = New LabelGradient.LabelGradient
        Me.LabelGradient3 = New LabelGradient.LabelGradient
        Me.LabelGradient2 = New LabelGradient.LabelGradient
        Me.LabelGradient4 = New LabelGradient.LabelGradient
        Me.pnlRESLMaching_YesNo = New System.Windows.Forms.Panel
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
        Me.lblSwingClearance_DesignBH_RodEnd = New System.Windows.Forms.Label
        Me.txtPinHoleSize_DesignBH_RodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.lblPinHoleSize_DesignBH_RodEnd = New System.Windows.Forms.Label
        Me.btnMatchedBHNotFound_RodEnd = New System.Windows.Forms.Button
        Me.LabelGradient1 = New LabelGradient.LabelGradient
        Me.btnAccept_RodEnd = New System.Windows.Forms.Button
        Me.LabelGradient5 = New LabelGradient.LabelGradient
        Me.lvwRodEndBHListView_RodEnd = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL
        Me.lvwSafetyFactor_Weight_RodEnd = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL
        Me.plnMatchingBHREFound.SuspendLayout()
        Me.grbREBHDetailsMached_RodEnd.SuspendLayout()
        CType(Me.picREBHMatched_RodEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbUsingSelectedBH_RodEnd.SuspendLayout()
        Me.grbNotUsingSelectedcrosstubeCasting_RECT.SuspendLayout()
        Me.pnlRESLMaching_YesNo.SuspendLayout()
        Me.pnlMatchingBHNotFound.SuspendLayout()
        Me.grbMatchedBHNotFound_RodEnd.SuspendLayout()
        Me.pnlSafetyFactor_Weight_LugThickness_RodEnd.SuspendLayout()
        Me.pnlDesignBH_RodEnd.SuspendLayout()
        CType(Me.trbSafetyFactor_RodEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'plnMatchingBHREFound
        '
        Me.plnMatchingBHREFound.AutoScroll = True
        Me.plnMatchingBHREFound.BackColor = System.Drawing.Color.Black
        Me.plnMatchingBHREFound.Controls.Add(Me.btnPleaseChangeTheRodDiameter)
        Me.plnMatchingBHREFound.Controls.Add(Me.grbREBHDetailsMached_RodEnd)
        Me.plnMatchingBHREFound.Controls.Add(Me.grbUsingSelectedBH_RodEnd)
        Me.plnMatchingBHREFound.Controls.Add(Me.lblBackGround)
        Me.plnMatchingBHREFound.Controls.Add(Me.grbNotUsingSelectedcrosstubeCasting_RECT)
        Me.plnMatchingBHREFound.Location = New System.Drawing.Point(3, 3)
        Me.plnMatchingBHREFound.Name = "plnMatchingBHREFound"
        Me.plnMatchingBHREFound.Size = New System.Drawing.Size(824, 538)
        Me.plnMatchingBHREFound.TabIndex = 41
        '
        'btnPleaseChangeTheRodDiameter
        '
        Me.btnPleaseChangeTheRodDiameter.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.btnPleaseChangeTheRodDiameter.Enabled = False
        Me.btnPleaseChangeTheRodDiameter.Location = New System.Drawing.Point(184, 0)
        Me.btnPleaseChangeTheRodDiameter.Name = "btnPleaseChangeTheRodDiameter"
        Me.btnPleaseChangeTheRodDiameter.Size = New System.Drawing.Size(225, 23)
        Me.btnPleaseChangeTheRodDiameter.TabIndex = 173
        Me.btnPleaseChangeTheRodDiameter.Text = "Please Change The Rod Diameter"
        Me.btnPleaseChangeTheRodDiameter.UseVisualStyleBackColor = False
        '
        'grbREBHDetailsMached_RodEnd
        '
        Me.grbREBHDetailsMached_RodEnd.BackColor = System.Drawing.Color.Ivory
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.lblUseSelectedBH)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.rdbUseSelectedBHNo)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.rdbUseSlectedBHYes)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.txtPinHoleTole_Neg_Req)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.txtPinHoleTole_Pos_Req)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.Label4)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.Label5)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.txtPinHoleTole_Neg)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.txtPinHoleTole_Pos)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.Label6)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.Label2)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.Label1)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.Label7)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.txtRequiredLugHeight_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.txtLugHeight_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.lblLugHeight_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.lblRequired)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.txtSwingClearance_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.txtRequiredAngle2_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.lblSwingClearance_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.txtRequiredAngle1_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.txtRequiredSwingClearance_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.txtRequiredGreaseZerk_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.txtRequiredLugsWidth_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.txtRequiredLugThickness_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.txtRequiredPinHoleSize_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.btnPicInformation)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.picREBHMatched_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.txtLugThickness_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.lblLugThickness_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.txtAngle2_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.lblAngle2_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.txtAngle1_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.lblAngle1_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.txtGreaseZerk_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.lblGreaseZerk_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.txtLugsWidth_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.lblLugsWidth_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.txtPinHoleSize_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.lblPinHoleSize_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.txtCodeNumber_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.lblCodeNumber_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.lvwRodEndBHListView_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Controls.Add(Me.lblExistingBHIndex_RodEnd)
        Me.grbREBHDetailsMached_RodEnd.Location = New System.Drawing.Point(21, 20)
        Me.grbREBHDetailsMached_RodEnd.Name = "grbREBHDetailsMached_RodEnd"
        Me.grbREBHDetailsMached_RodEnd.Size = New System.Drawing.Size(543, 371)
        Me.grbREBHDetailsMached_RodEnd.TabIndex = 15
        Me.grbREBHDetailsMached_RodEnd.TabStop = False
        '
        'lblUseSelectedBH
        '
        Me.lblUseSelectedBH.AutoSize = True
        Me.lblUseSelectedBH.Location = New System.Drawing.Point(288, 332)
        Me.lblUseSelectedBH.Name = "lblUseSelectedBH"
        Me.lblUseSelectedBH.Size = New System.Drawing.Size(89, 13)
        Me.lblUseSelectedBH.TabIndex = 191
        Me.lblUseSelectedBH.Text = "Use Selected BH"
        '
        'rdbUseSelectedBHNo
        '
        Me.rdbUseSelectedBHNo.AutoSize = True
        Me.rdbUseSelectedBHNo.Location = New System.Drawing.Point(477, 330)
        Me.rdbUseSelectedBHNo.Name = "rdbUseSelectedBHNo"
        Me.rdbUseSelectedBHNo.Size = New System.Drawing.Size(39, 17)
        Me.rdbUseSelectedBHNo.TabIndex = 190
        Me.rdbUseSelectedBHNo.TabStop = True
        Me.rdbUseSelectedBHNo.Text = "No"
        Me.rdbUseSelectedBHNo.UseVisualStyleBackColor = True
        '
        'rdbUseSlectedBHYes
        '
        Me.rdbUseSlectedBHYes.AutoSize = True
        Me.rdbUseSlectedBHYes.Location = New System.Drawing.Point(428, 330)
        Me.rdbUseSlectedBHYes.Name = "rdbUseSlectedBHYes"
        Me.rdbUseSlectedBHYes.Size = New System.Drawing.Size(43, 17)
        Me.rdbUseSlectedBHYes.TabIndex = 189
        Me.rdbUseSlectedBHYes.TabStop = True
        Me.rdbUseSlectedBHYes.Text = "Yes"
        Me.rdbUseSlectedBHYes.UseVisualStyleBackColor = True
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
        Me.txtPinHoleTole_Neg_Req.Location = New System.Drawing.Point(200, 325)
        Me.txtPinHoleTole_Neg_Req.MaximumValue = 99999
        Me.txtPinHoleTole_Neg_Req.MaxLength = 6
        Me.txtPinHoleTole_Neg_Req.MinimumValue = 0
        Me.txtPinHoleTole_Neg_Req.Name = "txtPinHoleTole_Neg_Req"
        Me.txtPinHoleTole_Neg_Req.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Neg_Req.StatusMessage = ""
        Me.txtPinHoleTole_Neg_Req.StatusObject = Nothing
        Me.txtPinHoleTole_Neg_Req.TabIndex = 188
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
        Me.txtPinHoleTole_Pos_Req.Location = New System.Drawing.Point(200, 299)
        Me.txtPinHoleTole_Pos_Req.MaximumValue = 99999
        Me.txtPinHoleTole_Pos_Req.MaxLength = 6
        Me.txtPinHoleTole_Pos_Req.MinimumValue = 0
        Me.txtPinHoleTole_Pos_Req.Name = "txtPinHoleTole_Pos_Req"
        Me.txtPinHoleTole_Pos_Req.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Pos_Req.StatusMessage = ""
        Me.txtPinHoleTole_Pos_Req.StatusObject = Nothing
        Me.txtPinHoleTole_Pos_Req.TabIndex = 187
        Me.txtPinHoleTole_Pos_Req.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(113, 328)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 186
        Me.Label4.Text = "-"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(113, 302)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 13)
        Me.Label5.TabIndex = 185
        Me.Label5.Text = "+"
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
        Me.txtPinHoleTole_Neg.Location = New System.Drawing.Point(129, 325)
        Me.txtPinHoleTole_Neg.MaximumValue = 99999
        Me.txtPinHoleTole_Neg.MaxLength = 6
        Me.txtPinHoleTole_Neg.MinimumValue = 0
        Me.txtPinHoleTole_Neg.Name = "txtPinHoleTole_Neg"
        Me.txtPinHoleTole_Neg.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Neg.StatusMessage = ""
        Me.txtPinHoleTole_Neg.StatusObject = Nothing
        Me.txtPinHoleTole_Neg.TabIndex = 184
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
        Me.txtPinHoleTole_Pos.Location = New System.Drawing.Point(129, 299)
        Me.txtPinHoleTole_Pos.MaximumValue = 99999
        Me.txtPinHoleTole_Pos.MaxLength = 6
        Me.txtPinHoleTole_Pos.MinimumValue = 0
        Me.txtPinHoleTole_Pos.Name = "txtPinHoleTole_Pos"
        Me.txtPinHoleTole_Pos.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Pos.StatusMessage = ""
        Me.txtPinHoleTole_Pos.StatusObject = Nothing
        Me.txtPinHoleTole_Pos.TabIndex = 182
        Me.txtPinHoleTole_Pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 302)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 183
        Me.Label6.Text = "Pin Hole Tolerance"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(459, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 173
        Me.Label2.Text = "Required"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(135, 171)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 172
        Me.Label1.Text = "Available"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(383, 167)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 171
        Me.Label7.Text = "Available"
        '
        'txtRequiredLugHeight_RodEnd
        '
        Me.txtRequiredLugHeight_RodEnd.AcceptEnterKeyAsTab = True
        Me.txtRequiredLugHeight_RodEnd.ApplyIFLColor = True
        Me.txtRequiredLugHeight_RodEnd.AssociateLabel = Nothing
        Me.txtRequiredLugHeight_RodEnd.DecimalValue = 2
        Me.txtRequiredLugHeight_RodEnd.IFLDataTag = Nothing
        Me.txtRequiredLugHeight_RodEnd.InvalidInputCharacters = ""
        Me.txtRequiredLugHeight_RodEnd.IsAllowNegative = False
        Me.txtRequiredLugHeight_RodEnd.LengthValue = 6
        Me.txtRequiredLugHeight_RodEnd.Location = New System.Drawing.Point(452, 301)
        Me.txtRequiredLugHeight_RodEnd.MaximumValue = 99999
        Me.txtRequiredLugHeight_RodEnd.MaxLength = 6
        Me.txtRequiredLugHeight_RodEnd.MinimumValue = 0
        Me.txtRequiredLugHeight_RodEnd.Name = "txtRequiredLugHeight_RodEnd"
        Me.txtRequiredLugHeight_RodEnd.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredLugHeight_RodEnd.StatusMessage = ""
        Me.txtRequiredLugHeight_RodEnd.StatusObject = Nothing
        Me.txtRequiredLugHeight_RodEnd.TabIndex = 24
        Me.txtRequiredLugHeight_RodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLugHeight_RodEnd
        '
        Me.txtLugHeight_RodEnd.AcceptEnterKeyAsTab = True
        Me.txtLugHeight_RodEnd.ApplyIFLColor = True
        Me.txtLugHeight_RodEnd.AssociateLabel = Nothing
        Me.txtLugHeight_RodEnd.DecimalValue = 2
        Me.txtLugHeight_RodEnd.IFLDataTag = Nothing
        Me.txtLugHeight_RodEnd.InvalidInputCharacters = ""
        Me.txtLugHeight_RodEnd.IsAllowNegative = False
        Me.txtLugHeight_RodEnd.LengthValue = 6
        Me.txtLugHeight_RodEnd.Location = New System.Drawing.Point(380, 301)
        Me.txtLugHeight_RodEnd.MaximumValue = 99999
        Me.txtLugHeight_RodEnd.MaxLength = 6
        Me.txtLugHeight_RodEnd.MinimumValue = 0
        Me.txtLugHeight_RodEnd.Name = "txtLugHeight_RodEnd"
        Me.txtLugHeight_RodEnd.Size = New System.Drawing.Size(66, 20)
        Me.txtLugHeight_RodEnd.StatusMessage = ""
        Me.txtLugHeight_RodEnd.StatusObject = Nothing
        Me.txtLugHeight_RodEnd.TabIndex = 24
        Me.txtLugHeight_RodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLugHeight_RodEnd
        '
        Me.lblLugHeight_RodEnd.AutoSize = True
        Me.lblLugHeight_RodEnd.Location = New System.Drawing.Point(288, 304)
        Me.lblLugHeight_RodEnd.Name = "lblLugHeight_RodEnd"
        Me.lblLugHeight_RodEnd.Size = New System.Drawing.Size(59, 13)
        Me.lblLugHeight_RodEnd.TabIndex = 143
        Me.lblLugHeight_RodEnd.Text = "Lug Height"
        '
        'lblRequired
        '
        Me.lblRequired.AutoSize = True
        Me.lblRequired.Location = New System.Drawing.Point(207, 171)
        Me.lblRequired.Name = "lblRequired"
        Me.lblRequired.Size = New System.Drawing.Size(50, 13)
        Me.lblRequired.TabIndex = 141
        Me.lblRequired.Text = "Required"
        '
        'txtSwingClearance_RodEnd
        '
        Me.txtSwingClearance_RodEnd.AcceptEnterKeyAsTab = True
        Me.txtSwingClearance_RodEnd.ApplyIFLColor = True
        Me.txtSwingClearance_RodEnd.AssociateLabel = Nothing
        Me.txtSwingClearance_RodEnd.DecimalValue = 2
        Me.txtSwingClearance_RodEnd.IFLDataTag = Nothing
        Me.txtSwingClearance_RodEnd.InvalidInputCharacters = ""
        Me.txtSwingClearance_RodEnd.IsAllowNegative = False
        Me.txtSwingClearance_RodEnd.LengthValue = 6
        Me.txtSwingClearance_RodEnd.Location = New System.Drawing.Point(380, 189)
        Me.txtSwingClearance_RodEnd.MaximumValue = 99999
        Me.txtSwingClearance_RodEnd.MaxLength = 6
        Me.txtSwingClearance_RodEnd.MinimumValue = 0
        Me.txtSwingClearance_RodEnd.Name = "txtSwingClearance_RodEnd"
        Me.txtSwingClearance_RodEnd.Size = New System.Drawing.Size(66, 20)
        Me.txtSwingClearance_RodEnd.StatusMessage = ""
        Me.txtSwingClearance_RodEnd.StatusObject = Nothing
        Me.txtSwingClearance_RodEnd.TabIndex = 25
        Me.txtSwingClearance_RodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredAngle2_RodEnd
        '
        Me.txtRequiredAngle2_RodEnd.AcceptEnterKeyAsTab = True
        Me.txtRequiredAngle2_RodEnd.ApplyIFLColor = True
        Me.txtRequiredAngle2_RodEnd.AssociateLabel = Nothing
        Me.txtRequiredAngle2_RodEnd.DecimalValue = 2
        Me.txtRequiredAngle2_RodEnd.IFLDataTag = Nothing
        Me.txtRequiredAngle2_RodEnd.InvalidInputCharacters = ""
        Me.txtRequiredAngle2_RodEnd.IsAllowNegative = False
        Me.txtRequiredAngle2_RodEnd.LengthValue = 6
        Me.txtRequiredAngle2_RodEnd.Location = New System.Drawing.Point(452, 273)
        Me.txtRequiredAngle2_RodEnd.MaximumValue = 99999
        Me.txtRequiredAngle2_RodEnd.MaxLength = 6
        Me.txtRequiredAngle2_RodEnd.MinimumValue = 0
        Me.txtRequiredAngle2_RodEnd.Name = "txtRequiredAngle2_RodEnd"
        Me.txtRequiredAngle2_RodEnd.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredAngle2_RodEnd.StatusMessage = ""
        Me.txtRequiredAngle2_RodEnd.StatusObject = Nothing
        Me.txtRequiredAngle2_RodEnd.TabIndex = 32
        Me.txtRequiredAngle2_RodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSwingClearance_RodEnd
        '
        Me.lblSwingClearance_RodEnd.AutoSize = True
        Me.lblSwingClearance_RodEnd.Location = New System.Drawing.Point(288, 192)
        Me.lblSwingClearance_RodEnd.Name = "lblSwingClearance_RodEnd"
        Me.lblSwingClearance_RodEnd.Size = New System.Drawing.Size(87, 13)
        Me.lblSwingClearance_RodEnd.TabIndex = 114
        Me.lblSwingClearance_RodEnd.Text = "Swing Clearance"
        '
        'txtRequiredAngle1_RodEnd
        '
        Me.txtRequiredAngle1_RodEnd.AcceptEnterKeyAsTab = True
        Me.txtRequiredAngle1_RodEnd.ApplyIFLColor = True
        Me.txtRequiredAngle1_RodEnd.AssociateLabel = Nothing
        Me.txtRequiredAngle1_RodEnd.DecimalValue = 2
        Me.txtRequiredAngle1_RodEnd.IFLDataTag = Nothing
        Me.txtRequiredAngle1_RodEnd.InvalidInputCharacters = ""
        Me.txtRequiredAngle1_RodEnd.IsAllowNegative = False
        Me.txtRequiredAngle1_RodEnd.LengthValue = 6
        Me.txtRequiredAngle1_RodEnd.Location = New System.Drawing.Point(452, 247)
        Me.txtRequiredAngle1_RodEnd.MaximumValue = 99999
        Me.txtRequiredAngle1_RodEnd.MaxLength = 6
        Me.txtRequiredAngle1_RodEnd.MinimumValue = 0
        Me.txtRequiredAngle1_RodEnd.Name = "txtRequiredAngle1_RodEnd"
        Me.txtRequiredAngle1_RodEnd.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredAngle1_RodEnd.StatusMessage = ""
        Me.txtRequiredAngle1_RodEnd.StatusObject = Nothing
        Me.txtRequiredAngle1_RodEnd.TabIndex = 30
        Me.txtRequiredAngle1_RodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredSwingClearance_RodEnd
        '
        Me.txtRequiredSwingClearance_RodEnd.AcceptEnterKeyAsTab = True
        Me.txtRequiredSwingClearance_RodEnd.ApplyIFLColor = True
        Me.txtRequiredSwingClearance_RodEnd.AssociateLabel = Nothing
        Me.txtRequiredSwingClearance_RodEnd.DecimalValue = 2
        Me.txtRequiredSwingClearance_RodEnd.IFLDataTag = Nothing
        Me.txtRequiredSwingClearance_RodEnd.InvalidInputCharacters = ""
        Me.txtRequiredSwingClearance_RodEnd.IsAllowNegative = False
        Me.txtRequiredSwingClearance_RodEnd.LengthValue = 6
        Me.txtRequiredSwingClearance_RodEnd.Location = New System.Drawing.Point(452, 189)
        Me.txtRequiredSwingClearance_RodEnd.MaximumValue = 99999
        Me.txtRequiredSwingClearance_RodEnd.MaxLength = 6
        Me.txtRequiredSwingClearance_RodEnd.MinimumValue = 0
        Me.txtRequiredSwingClearance_RodEnd.Name = "txtRequiredSwingClearance_RodEnd"
        Me.txtRequiredSwingClearance_RodEnd.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredSwingClearance_RodEnd.StatusMessage = ""
        Me.txtRequiredSwingClearance_RodEnd.StatusObject = Nothing
        Me.txtRequiredSwingClearance_RodEnd.TabIndex = 26
        Me.txtRequiredSwingClearance_RodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredGreaseZerk_RodEnd
        '
        Me.txtRequiredGreaseZerk_RodEnd.AcceptEnterKeyAsTab = True
        Me.txtRequiredGreaseZerk_RodEnd.ApplyIFLColor = True
        Me.txtRequiredGreaseZerk_RodEnd.AssociateLabel = Nothing
        Me.txtRequiredGreaseZerk_RodEnd.DecimalValue = 2
        Me.txtRequiredGreaseZerk_RodEnd.IFLDataTag = Nothing
        Me.txtRequiredGreaseZerk_RodEnd.InvalidInputCharacters = ""
        Me.txtRequiredGreaseZerk_RodEnd.IsAllowNegative = False
        Me.txtRequiredGreaseZerk_RodEnd.LengthValue = 6
        Me.txtRequiredGreaseZerk_RodEnd.Location = New System.Drawing.Point(452, 218)
        Me.txtRequiredGreaseZerk_RodEnd.MaximumValue = 99999
        Me.txtRequiredGreaseZerk_RodEnd.MaxLength = 6
        Me.txtRequiredGreaseZerk_RodEnd.MinimumValue = 0
        Me.txtRequiredGreaseZerk_RodEnd.Name = "txtRequiredGreaseZerk_RodEnd"
        Me.txtRequiredGreaseZerk_RodEnd.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredGreaseZerk_RodEnd.StatusMessage = ""
        Me.txtRequiredGreaseZerk_RodEnd.StatusObject = Nothing
        Me.txtRequiredGreaseZerk_RodEnd.TabIndex = 28
        Me.txtRequiredGreaseZerk_RodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredLugsWidth_RodEnd
        '
        Me.txtRequiredLugsWidth_RodEnd.AcceptEnterKeyAsTab = True
        Me.txtRequiredLugsWidth_RodEnd.ApplyIFLColor = True
        Me.txtRequiredLugsWidth_RodEnd.AssociateLabel = Nothing
        Me.txtRequiredLugsWidth_RodEnd.DecimalValue = 2
        Me.txtRequiredLugsWidth_RodEnd.IFLDataTag = Nothing
        Me.txtRequiredLugsWidth_RodEnd.InvalidInputCharacters = ""
        Me.txtRequiredLugsWidth_RodEnd.IsAllowNegative = False
        Me.txtRequiredLugsWidth_RodEnd.LengthValue = 6
        Me.txtRequiredLugsWidth_RodEnd.Location = New System.Drawing.Point(200, 247)
        Me.txtRequiredLugsWidth_RodEnd.MaximumValue = 99999
        Me.txtRequiredLugsWidth_RodEnd.MaxLength = 6
        Me.txtRequiredLugsWidth_RodEnd.MinimumValue = 0
        Me.txtRequiredLugsWidth_RodEnd.Name = "txtRequiredLugsWidth_RodEnd"
        Me.txtRequiredLugsWidth_RodEnd.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredLugsWidth_RodEnd.StatusMessage = ""
        Me.txtRequiredLugsWidth_RodEnd.StatusObject = Nothing
        Me.txtRequiredLugsWidth_RodEnd.TabIndex = 21
        Me.txtRequiredLugsWidth_RodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredLugThickness_RodEnd
        '
        Me.txtRequiredLugThickness_RodEnd.AcceptEnterKeyAsTab = True
        Me.txtRequiredLugThickness_RodEnd.ApplyIFLColor = True
        Me.txtRequiredLugThickness_RodEnd.AssociateLabel = Nothing
        Me.txtRequiredLugThickness_RodEnd.DecimalValue = 2
        Me.txtRequiredLugThickness_RodEnd.IFLDataTag = Nothing
        Me.txtRequiredLugThickness_RodEnd.InvalidInputCharacters = ""
        Me.txtRequiredLugThickness_RodEnd.IsAllowNegative = False
        Me.txtRequiredLugThickness_RodEnd.LengthValue = 6
        Me.txtRequiredLugThickness_RodEnd.Location = New System.Drawing.Point(201, 217)
        Me.txtRequiredLugThickness_RodEnd.MaximumValue = 99999
        Me.txtRequiredLugThickness_RodEnd.MaxLength = 6
        Me.txtRequiredLugThickness_RodEnd.MinimumValue = 0
        Me.txtRequiredLugThickness_RodEnd.Name = "txtRequiredLugThickness_RodEnd"
        Me.txtRequiredLugThickness_RodEnd.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredLugThickness_RodEnd.StatusMessage = ""
        Me.txtRequiredLugThickness_RodEnd.StatusObject = Nothing
        Me.txtRequiredLugThickness_RodEnd.TabIndex = 19
        Me.txtRequiredLugThickness_RodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredPinHoleSize_RodEnd
        '
        Me.txtRequiredPinHoleSize_RodEnd.AcceptEnterKeyAsTab = True
        Me.txtRequiredPinHoleSize_RodEnd.ApplyIFLColor = True
        Me.txtRequiredPinHoleSize_RodEnd.AssociateLabel = Nothing
        Me.txtRequiredPinHoleSize_RodEnd.DecimalValue = 2
        Me.txtRequiredPinHoleSize_RodEnd.IFLDataTag = Nothing
        Me.txtRequiredPinHoleSize_RodEnd.InvalidInputCharacters = ""
        Me.txtRequiredPinHoleSize_RodEnd.IsAllowNegative = False
        Me.txtRequiredPinHoleSize_RodEnd.LengthValue = 6
        Me.txtRequiredPinHoleSize_RodEnd.Location = New System.Drawing.Point(200, 273)
        Me.txtRequiredPinHoleSize_RodEnd.MaximumValue = 99999
        Me.txtRequiredPinHoleSize_RodEnd.MaxLength = 6
        Me.txtRequiredPinHoleSize_RodEnd.MinimumValue = 0
        Me.txtRequiredPinHoleSize_RodEnd.Name = "txtRequiredPinHoleSize_RodEnd"
        Me.txtRequiredPinHoleSize_RodEnd.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredPinHoleSize_RodEnd.StatusMessage = ""
        Me.txtRequiredPinHoleSize_RodEnd.StatusObject = Nothing
        Me.txtRequiredPinHoleSize_RodEnd.TabIndex = 23
        Me.txtRequiredPinHoleSize_RodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnPicInformation
        '
        Me.btnPicInformation.Enabled = False
        Me.btnPicInformation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPicInformation.Location = New System.Drawing.Point(414, 114)
        Me.btnPicInformation.Name = "btnPicInformation"
        Me.btnPicInformation.Size = New System.Drawing.Size(95, 23)
        Me.btnPicInformation.TabIndex = 131
        Me.btnPicInformation.Text = "Show Image"
        Me.btnPicInformation.UseVisualStyleBackColor = True
        '
        'picREBHMatched_RodEnd
        '
        Me.picREBHMatched_RodEnd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picREBHMatched_RodEnd.Location = New System.Drawing.Point(386, 38)
        Me.picREBHMatched_RodEnd.Name = "picREBHMatched_RodEnd"
        Me.picREBHMatched_RodEnd.Size = New System.Drawing.Size(151, 122)
        Me.picREBHMatched_RodEnd.TabIndex = 130
        Me.picREBHMatched_RodEnd.TabStop = False
        '
        'txtLugThickness_RodEnd
        '
        Me.txtLugThickness_RodEnd.AcceptEnterKeyAsTab = True
        Me.txtLugThickness_RodEnd.ApplyIFLColor = True
        Me.txtLugThickness_RodEnd.AssociateLabel = Nothing
        Me.txtLugThickness_RodEnd.DecimalValue = 2
        Me.txtLugThickness_RodEnd.IFLDataTag = Nothing
        Me.txtLugThickness_RodEnd.InvalidInputCharacters = ""
        Me.txtLugThickness_RodEnd.IsAllowNegative = False
        Me.txtLugThickness_RodEnd.LengthValue = 6
        Me.txtLugThickness_RodEnd.Location = New System.Drawing.Point(129, 217)
        Me.txtLugThickness_RodEnd.MaximumValue = 99999
        Me.txtLugThickness_RodEnd.MaxLength = 6
        Me.txtLugThickness_RodEnd.MinimumValue = 0
        Me.txtLugThickness_RodEnd.Name = "txtLugThickness_RodEnd"
        Me.txtLugThickness_RodEnd.Size = New System.Drawing.Size(66, 20)
        Me.txtLugThickness_RodEnd.StatusMessage = ""
        Me.txtLugThickness_RodEnd.StatusObject = Nothing
        Me.txtLugThickness_RodEnd.TabIndex = 18
        Me.txtLugThickness_RodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLugThickness_RodEnd
        '
        Me.lblLugThickness_RodEnd.AutoSize = True
        Me.lblLugThickness_RodEnd.Location = New System.Drawing.Point(6, 221)
        Me.lblLugThickness_RodEnd.Name = "lblLugThickness_RodEnd"
        Me.lblLugThickness_RodEnd.Size = New System.Drawing.Size(77, 13)
        Me.lblLugThickness_RodEnd.TabIndex = 128
        Me.lblLugThickness_RodEnd.Text = "Lug Thickness"
        '
        'txtAngle2_RodEnd
        '
        Me.txtAngle2_RodEnd.AcceptEnterKeyAsTab = True
        Me.txtAngle2_RodEnd.ApplyIFLColor = True
        Me.txtAngle2_RodEnd.AssociateLabel = Nothing
        Me.txtAngle2_RodEnd.DecimalValue = 2
        Me.txtAngle2_RodEnd.IFLDataTag = Nothing
        Me.txtAngle2_RodEnd.InvalidInputCharacters = ""
        Me.txtAngle2_RodEnd.IsAllowNegative = False
        Me.txtAngle2_RodEnd.LengthValue = 6
        Me.txtAngle2_RodEnd.Location = New System.Drawing.Point(380, 273)
        Me.txtAngle2_RodEnd.MaximumValue = 99999
        Me.txtAngle2_RodEnd.MaxLength = 6
        Me.txtAngle2_RodEnd.MinimumValue = 0
        Me.txtAngle2_RodEnd.Name = "txtAngle2_RodEnd"
        Me.txtAngle2_RodEnd.Size = New System.Drawing.Size(66, 20)
        Me.txtAngle2_RodEnd.StatusMessage = ""
        Me.txtAngle2_RodEnd.StatusObject = Nothing
        Me.txtAngle2_RodEnd.TabIndex = 31
        Me.txtAngle2_RodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAngle2_RodEnd
        '
        Me.lblAngle2_RodEnd.AutoSize = True
        Me.lblAngle2_RodEnd.Location = New System.Drawing.Point(288, 276)
        Me.lblAngle2_RodEnd.Name = "lblAngle2_RodEnd"
        Me.lblAngle2_RodEnd.Size = New System.Drawing.Size(40, 13)
        Me.lblAngle2_RodEnd.TabIndex = 126
        Me.lblAngle2_RodEnd.Text = "Angle2"
        '
        'txtAngle1_RodEnd
        '
        Me.txtAngle1_RodEnd.AcceptEnterKeyAsTab = True
        Me.txtAngle1_RodEnd.ApplyIFLColor = True
        Me.txtAngle1_RodEnd.AssociateLabel = Nothing
        Me.txtAngle1_RodEnd.DecimalValue = 2
        Me.txtAngle1_RodEnd.IFLDataTag = Nothing
        Me.txtAngle1_RodEnd.InvalidInputCharacters = ""
        Me.txtAngle1_RodEnd.IsAllowNegative = False
        Me.txtAngle1_RodEnd.LengthValue = 6
        Me.txtAngle1_RodEnd.Location = New System.Drawing.Point(380, 247)
        Me.txtAngle1_RodEnd.MaximumValue = 99999
        Me.txtAngle1_RodEnd.MaxLength = 6
        Me.txtAngle1_RodEnd.MinimumValue = 0
        Me.txtAngle1_RodEnd.Name = "txtAngle1_RodEnd"
        Me.txtAngle1_RodEnd.Size = New System.Drawing.Size(66, 20)
        Me.txtAngle1_RodEnd.StatusMessage = ""
        Me.txtAngle1_RodEnd.StatusObject = Nothing
        Me.txtAngle1_RodEnd.TabIndex = 29
        Me.txtAngle1_RodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAngle1_RodEnd
        '
        Me.lblAngle1_RodEnd.AutoSize = True
        Me.lblAngle1_RodEnd.Location = New System.Drawing.Point(288, 250)
        Me.lblAngle1_RodEnd.Name = "lblAngle1_RodEnd"
        Me.lblAngle1_RodEnd.Size = New System.Drawing.Size(40, 13)
        Me.lblAngle1_RodEnd.TabIndex = 124
        Me.lblAngle1_RodEnd.Text = "Angle1"
        '
        'txtGreaseZerk_RodEnd
        '
        Me.txtGreaseZerk_RodEnd.AcceptEnterKeyAsTab = True
        Me.txtGreaseZerk_RodEnd.ApplyIFLColor = True
        Me.txtGreaseZerk_RodEnd.AssociateLabel = Nothing
        Me.txtGreaseZerk_RodEnd.DecimalValue = 2
        Me.txtGreaseZerk_RodEnd.IFLDataTag = Nothing
        Me.txtGreaseZerk_RodEnd.InvalidInputCharacters = ""
        Me.txtGreaseZerk_RodEnd.IsAllowNegative = False
        Me.txtGreaseZerk_RodEnd.LengthValue = 6
        Me.txtGreaseZerk_RodEnd.Location = New System.Drawing.Point(380, 218)
        Me.txtGreaseZerk_RodEnd.MaximumValue = 99999
        Me.txtGreaseZerk_RodEnd.MaxLength = 6
        Me.txtGreaseZerk_RodEnd.MinimumValue = 0
        Me.txtGreaseZerk_RodEnd.Name = "txtGreaseZerk_RodEnd"
        Me.txtGreaseZerk_RodEnd.Size = New System.Drawing.Size(66, 20)
        Me.txtGreaseZerk_RodEnd.StatusMessage = ""
        Me.txtGreaseZerk_RodEnd.StatusObject = Nothing
        Me.txtGreaseZerk_RodEnd.TabIndex = 27
        Me.txtGreaseZerk_RodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblGreaseZerk_RodEnd
        '
        Me.lblGreaseZerk_RodEnd.AutoSize = True
        Me.lblGreaseZerk_RodEnd.Location = New System.Drawing.Point(288, 221)
        Me.lblGreaseZerk_RodEnd.Name = "lblGreaseZerk_RodEnd"
        Me.lblGreaseZerk_RodEnd.Size = New System.Drawing.Size(85, 13)
        Me.lblGreaseZerk_RodEnd.TabIndex = 122
        Me.lblGreaseZerk_RodEnd.Text = "Grease Zerk Qty"
        '
        'txtLugsWidth_RodEnd
        '
        Me.txtLugsWidth_RodEnd.AcceptEnterKeyAsTab = True
        Me.txtLugsWidth_RodEnd.ApplyIFLColor = True
        Me.txtLugsWidth_RodEnd.AssociateLabel = Nothing
        Me.txtLugsWidth_RodEnd.DecimalValue = 2
        Me.txtLugsWidth_RodEnd.IFLDataTag = Nothing
        Me.txtLugsWidth_RodEnd.InvalidInputCharacters = ""
        Me.txtLugsWidth_RodEnd.IsAllowNegative = False
        Me.txtLugsWidth_RodEnd.LengthValue = 6
        Me.txtLugsWidth_RodEnd.Location = New System.Drawing.Point(129, 245)
        Me.txtLugsWidth_RodEnd.MaximumValue = 99999
        Me.txtLugsWidth_RodEnd.MaxLength = 6
        Me.txtLugsWidth_RodEnd.MinimumValue = 0
        Me.txtLugsWidth_RodEnd.Name = "txtLugsWidth_RodEnd"
        Me.txtLugsWidth_RodEnd.Size = New System.Drawing.Size(66, 20)
        Me.txtLugsWidth_RodEnd.StatusMessage = ""
        Me.txtLugsWidth_RodEnd.StatusObject = Nothing
        Me.txtLugsWidth_RodEnd.TabIndex = 20
        Me.txtLugsWidth_RodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLugsWidth_RodEnd
        '
        Me.lblLugsWidth_RodEnd.AutoSize = True
        Me.lblLugsWidth_RodEnd.Location = New System.Drawing.Point(6, 250)
        Me.lblLugsWidth_RodEnd.Name = "lblLugsWidth_RodEnd"
        Me.lblLugsWidth_RodEnd.Size = New System.Drawing.Size(56, 13)
        Me.lblLugsWidth_RodEnd.TabIndex = 120
        Me.lblLugsWidth_RodEnd.Text = "Lug Width"
        '
        'txtPinHoleSize_RodEnd
        '
        Me.txtPinHoleSize_RodEnd.AcceptEnterKeyAsTab = True
        Me.txtPinHoleSize_RodEnd.ApplyIFLColor = True
        Me.txtPinHoleSize_RodEnd.AssociateLabel = Nothing
        Me.txtPinHoleSize_RodEnd.DecimalValue = 2
        Me.txtPinHoleSize_RodEnd.IFLDataTag = Nothing
        Me.txtPinHoleSize_RodEnd.InvalidInputCharacters = ""
        Me.txtPinHoleSize_RodEnd.IsAllowNegative = False
        Me.txtPinHoleSize_RodEnd.LengthValue = 6
        Me.txtPinHoleSize_RodEnd.Location = New System.Drawing.Point(129, 273)
        Me.txtPinHoleSize_RodEnd.MaximumValue = 99999
        Me.txtPinHoleSize_RodEnd.MaxLength = 6
        Me.txtPinHoleSize_RodEnd.MinimumValue = 0
        Me.txtPinHoleSize_RodEnd.Name = "txtPinHoleSize_RodEnd"
        Me.txtPinHoleSize_RodEnd.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleSize_RodEnd.StatusMessage = ""
        Me.txtPinHoleSize_RodEnd.StatusObject = Nothing
        Me.txtPinHoleSize_RodEnd.TabIndex = 22
        Me.txtPinHoleSize_RodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPinHoleSize_RodEnd
        '
        Me.lblPinHoleSize_RodEnd.AutoSize = True
        Me.lblPinHoleSize_RodEnd.Location = New System.Drawing.Point(6, 276)
        Me.lblPinHoleSize_RodEnd.Name = "lblPinHoleSize_RodEnd"
        Me.lblPinHoleSize_RodEnd.Size = New System.Drawing.Size(70, 13)
        Me.lblPinHoleSize_RodEnd.TabIndex = 116
        Me.lblPinHoleSize_RodEnd.Text = "Pin Hole Size"
        '
        'txtCodeNumber_RodEnd
        '
        Me.txtCodeNumber_RodEnd.AcceptEnterKeyAsTab = True
        Me.txtCodeNumber_RodEnd.ApplyIFLColor = True
        Me.txtCodeNumber_RodEnd.AssociateLabel = Nothing
        Me.txtCodeNumber_RodEnd.DecimalValue = 2
        Me.txtCodeNumber_RodEnd.IFLDataTag = Nothing
        Me.txtCodeNumber_RodEnd.InvalidInputCharacters = ""
        Me.txtCodeNumber_RodEnd.IsAllowNegative = False
        Me.txtCodeNumber_RodEnd.LengthValue = 6
        Me.txtCodeNumber_RodEnd.Location = New System.Drawing.Point(129, 189)
        Me.txtCodeNumber_RodEnd.MaximumValue = 99999
        Me.txtCodeNumber_RodEnd.MaxLength = 6
        Me.txtCodeNumber_RodEnd.MinimumValue = 0
        Me.txtCodeNumber_RodEnd.Name = "txtCodeNumber_RodEnd"
        Me.txtCodeNumber_RodEnd.Size = New System.Drawing.Size(66, 20)
        Me.txtCodeNumber_RodEnd.StatusMessage = ""
        Me.txtCodeNumber_RodEnd.StatusObject = Nothing
        Me.txtCodeNumber_RodEnd.TabIndex = 17
        Me.txtCodeNumber_RodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCodeNumber_RodEnd
        '
        Me.lblCodeNumber_RodEnd.AutoSize = True
        Me.lblCodeNumber_RodEnd.Location = New System.Drawing.Point(6, 192)
        Me.lblCodeNumber_RodEnd.Name = "lblCodeNumber_RodEnd"
        Me.lblCodeNumber_RodEnd.Size = New System.Drawing.Size(72, 13)
        Me.lblCodeNumber_RodEnd.TabIndex = 112
        Me.lblCodeNumber_RodEnd.Text = "Code Number"
        '
        'lblExistingBHIndex_RodEnd
        '
        Me.lblExistingBHIndex_RodEnd.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblExistingBHIndex_RodEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExistingBHIndex_RodEnd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblExistingBHIndex_RodEnd.GradientColorOne = System.Drawing.Color.Olive
        Me.lblExistingBHIndex_RodEnd.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblExistingBHIndex_RodEnd.Location = New System.Drawing.Point(-3, 0)
        Me.lblExistingBHIndex_RodEnd.Name = "lblExistingBHIndex_RodEnd"
        Me.lblExistingBHIndex_RodEnd.Size = New System.Drawing.Size(546, 19)
        Me.lblExistingBHIndex_RodEnd.TabIndex = 110
        Me.lblExistingBHIndex_RodEnd.Text = "Existing RodEnd BH Details"
        Me.lblExistingBHIndex_RodEnd.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grbUsingSelectedBH_RodEnd
        '
        Me.grbUsingSelectedBH_RodEnd.BackColor = System.Drawing.Color.Ivory
        Me.grbUsingSelectedBH_RodEnd.Controls.Add(Me.rdbNewCasting_RodEnd)
        Me.grbUsingSelectedBH_RodEnd.Controls.Add(Me.rdbResize_RodEnd)
        Me.grbUsingSelectedBH_RodEnd.Controls.Add(Me.rdbUseSelectedBHYes)
        Me.grbUsingSelectedBH_RodEnd.Controls.Add(Me.lblUsingSelectedBH_RodEnd)
        Me.grbUsingSelectedBH_RodEnd.Location = New System.Drawing.Point(21, 397)
        Me.grbUsingSelectedBH_RodEnd.Name = "grbUsingSelectedBH_RodEnd"
        Me.grbUsingSelectedBH_RodEnd.Size = New System.Drawing.Size(543, 115)
        Me.grbUsingSelectedBH_RodEnd.TabIndex = 33
        Me.grbUsingSelectedBH_RodEnd.TabStop = False
        '
        'rdbNewCasting_RodEnd
        '
        Me.rdbNewCasting_RodEnd.AutoSize = True
        Me.rdbNewCasting_RodEnd.Location = New System.Drawing.Point(309, 49)
        Me.rdbNewCasting_RodEnd.Name = "rdbNewCasting_RodEnd"
        Me.rdbNewCasting_RodEnd.Size = New System.Drawing.Size(85, 17)
        Me.rdbNewCasting_RodEnd.TabIndex = 37
        Me.rdbNewCasting_RodEnd.TabStop = True
        Me.rdbNewCasting_RodEnd.Text = "New Casting"
        Me.rdbNewCasting_RodEnd.UseVisualStyleBackColor = True
        '
        'rdbResize_RodEnd
        '
        Me.rdbResize_RodEnd.AutoSize = True
        Me.rdbResize_RodEnd.Location = New System.Drawing.Point(236, 49)
        Me.rdbResize_RodEnd.Name = "rdbResize_RodEnd"
        Me.rdbResize_RodEnd.Size = New System.Drawing.Size(57, 17)
        Me.rdbResize_RodEnd.TabIndex = 36
        Me.rdbResize_RodEnd.TabStop = True
        Me.rdbResize_RodEnd.Text = "Resize"
        Me.rdbResize_RodEnd.UseVisualStyleBackColor = True
        '
        'rdbUseSelectedBHYes
        '
        Me.rdbUseSelectedBHYes.AutoSize = True
        Me.rdbUseSelectedBHYes.Location = New System.Drawing.Point(148, 49)
        Me.rdbUseSelectedBHYes.Name = "rdbUseSelectedBHYes"
        Me.rdbUseSelectedBHYes.Size = New System.Drawing.Size(76, 17)
        Me.rdbUseSelectedBHYes.TabIndex = 143
        Me.rdbUseSelectedBHYes.TabStop = True
        Me.rdbUseSelectedBHYes.Text = "Use as it is"
        Me.rdbUseSelectedBHYes.UseVisualStyleBackColor = True
        '
        'lblUsingSelectedBH_RodEnd
        '
        Me.lblUsingSelectedBH_RodEnd.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblUsingSelectedBH_RodEnd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsingSelectedBH_RodEnd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUsingSelectedBH_RodEnd.GradientColorOne = System.Drawing.Color.Olive
        Me.lblUsingSelectedBH_RodEnd.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblUsingSelectedBH_RodEnd.Location = New System.Drawing.Point(-2, 0)
        Me.lblUsingSelectedBH_RodEnd.Name = "lblUsingSelectedBH_RodEnd"
        Me.lblUsingSelectedBH_RodEnd.Size = New System.Drawing.Size(545, 19)
        Me.lblUsingSelectedBH_RodEnd.TabIndex = 111
        Me.lblUsingSelectedBH_RodEnd.Text = "Using Selected BH"
        Me.lblUsingSelectedBH_RodEnd.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblBackGround.Size = New System.Drawing.Size(578, 529)
        Me.lblBackGround.TabIndex = 120
        Me.lblBackGround.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grbNotUsingSelectedcrosstubeCasting_RECT
        '
        Me.grbNotUsingSelectedcrosstubeCasting_RECT.BackColor = System.Drawing.Color.Ivory
        Me.grbNotUsingSelectedcrosstubeCasting_RECT.Controls.Add(Me.lblNotUsingSelectedBH)
        Me.grbNotUsingSelectedcrosstubeCasting_RECT.Controls.Add(Me.btnClickNextButton)
        Me.grbNotUsingSelectedcrosstubeCasting_RECT.Location = New System.Drawing.Point(21, 397)
        Me.grbNotUsingSelectedcrosstubeCasting_RECT.Name = "grbNotUsingSelectedcrosstubeCasting_RECT"
        Me.grbNotUsingSelectedcrosstubeCasting_RECT.Size = New System.Drawing.Size(543, 115)
        Me.grbNotUsingSelectedcrosstubeCasting_RECT.TabIndex = 149
        Me.grbNotUsingSelectedcrosstubeCasting_RECT.TabStop = False
        '
        'lblNotUsingSelectedBH
        '
        Me.lblNotUsingSelectedBH.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblNotUsingSelectedBH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotUsingSelectedBH.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNotUsingSelectedBH.GradientColorOne = System.Drawing.Color.Olive
        Me.lblNotUsingSelectedBH.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblNotUsingSelectedBH.Location = New System.Drawing.Point(-2, 0)
        Me.lblNotUsingSelectedBH.Name = "lblNotUsingSelectedBH"
        Me.lblNotUsingSelectedBH.Size = New System.Drawing.Size(545, 19)
        Me.lblNotUsingSelectedBH.TabIndex = 111
        Me.lblNotUsingSelectedBH.Text = "Not Using Selected Sngle Lug"
        Me.lblNotUsingSelectedBH.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnClickNextButton
        '
        Me.btnClickNextButton.BackColor = System.Drawing.Color.Ivory
        Me.btnClickNextButton.Enabled = False
        Me.btnClickNextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClickNextButton.Location = New System.Drawing.Point(185, 42)
        Me.btnClickNextButton.Name = "btnClickNextButton"
        Me.btnClickNextButton.Size = New System.Drawing.Size(158, 34)
        Me.btnClickNextButton.TabIndex = 116
        Me.btnClickNextButton.Text = "Click Next Button"
        Me.btnClickNextButton.UseVisualStyleBackColor = False
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
        Me.pnlRESLMaching_YesNo.AutoScroll = True
        Me.pnlRESLMaching_YesNo.Controls.Add(Me.plnMatchingBHREFound)
        Me.pnlRESLMaching_YesNo.Controls.Add(Me.pnlMatchingBHNotFound)
        Me.pnlRESLMaching_YesNo.Location = New System.Drawing.Point(26, 22)
        Me.pnlRESLMaching_YesNo.Name = "pnlRESLMaching_YesNo"
        Me.pnlRESLMaching_YesNo.Size = New System.Drawing.Size(950, 650)
        Me.pnlRESLMaching_YesNo.TabIndex = 44
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
        Me.grbMatchedBHNotFound_RodEnd.Location = New System.Drawing.Point(132, 102)
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
        Me.pnlDesignBH_RodEnd.Controls.Add(Me.lblSwingClearance_DesignBH_RodEnd)
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
        'lblSwingClearance_DesignBH_RodEnd
        '
        Me.lblSwingClearance_DesignBH_RodEnd.AutoSize = True
        Me.lblSwingClearance_DesignBH_RodEnd.Location = New System.Drawing.Point(227, 100)
        Me.lblSwingClearance_DesignBH_RodEnd.Name = "lblSwingClearance_DesignBH_RodEnd"
        Me.lblSwingClearance_DesignBH_RodEnd.Size = New System.Drawing.Size(87, 13)
        Me.lblSwingClearance_DesignBH_RodEnd.TabIndex = 149
        Me.lblSwingClearance_DesignBH_RodEnd.Text = "Swing Clearance"
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
        Me.LabelGradient5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LabelGradient5.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient5.GradientColorOne = System.Drawing.Color.DarkGoldenrod
        Me.LabelGradient5.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient5.Location = New System.Drawing.Point(113, 84)
        Me.LabelGradient5.Name = "LabelGradient5"
        Me.LabelGradient5.Size = New System.Drawing.Size(598, 406)
        Me.LabelGradient5.TabIndex = 149
        Me.LabelGradient5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lvwRodEndBHListView_RodEnd
        '
        Me.lvwRodEndBHListView_RodEnd.FullRowSelect = True
        Me.lvwRodEndBHListView_RodEnd.GridLines = True
        Me.lvwRodEndBHListView_RodEnd.Location = New System.Drawing.Point(6, 33)
        Me.lvwRodEndBHListView_RodEnd.MultiSelect = False
        Me.lvwRodEndBHListView_RodEnd.Name = "lvwRodEndBHListView_RodEnd"
        Me.lvwRodEndBHListView_RodEnd.Scrollable = False
        Me.lvwRodEndBHListView_RodEnd.Size = New System.Drawing.Size(369, 129)
        Me.lvwRodEndBHListView_RodEnd.TabIndex = 16
        Me.lvwRodEndBHListView_RodEnd.UseCompatibleStateImageBehavior = False
        Me.lvwRodEndBHListView_RodEnd.View = System.Windows.Forms.View.Details
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
        'frmREBHDetails
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
        Me.Name = "frmREBHDetails"
        Me.Text = "frmREBHDetails"
        Me.plnMatchingBHREFound.ResumeLayout(False)
        Me.grbREBHDetailsMached_RodEnd.ResumeLayout(False)
        Me.grbREBHDetailsMached_RodEnd.PerformLayout()
        CType(Me.picREBHMatched_RodEnd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbUsingSelectedBH_RodEnd.ResumeLayout(False)
        Me.grbUsingSelectedBH_RodEnd.PerformLayout()
        Me.grbNotUsingSelectedcrosstubeCasting_RECT.ResumeLayout(False)
        Me.pnlRESLMaching_YesNo.ResumeLayout(False)
        Me.pnlMatchingBHNotFound.ResumeLayout(False)
        Me.grbMatchedBHNotFound_RodEnd.ResumeLayout(False)
        Me.pnlSafetyFactor_Weight_LugThickness_RodEnd.ResumeLayout(False)
        Me.pnlDesignBH_RodEnd.ResumeLayout(False)
        Me.pnlDesignBH_RodEnd.PerformLayout()
        CType(Me.trbSafetyFactor_RodEnd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plnMatchingBHREFound As System.Windows.Forms.Panel
    Friend WithEvents btnPleaseChangeTheRodDiameter As System.Windows.Forms.Button
    Friend WithEvents grbREBHDetailsMached_RodEnd As System.Windows.Forms.GroupBox
    Friend WithEvents lblUseSelectedBH As System.Windows.Forms.Label
    Friend WithEvents rdbUseSelectedBHNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbUseSlectedBHYes As System.Windows.Forms.RadioButton
    Friend WithEvents txtPinHoleTole_Neg_Req As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtPinHoleTole_Pos_Req As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleTole_Neg As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtPinHoleTole_Pos As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRequiredLugHeight_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtLugHeight_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblLugHeight_RodEnd As System.Windows.Forms.Label
    Friend WithEvents lblRequired As System.Windows.Forms.Label
    Friend WithEvents txtSwingClearance_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredAngle2_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSwingClearance_RodEnd As System.Windows.Forms.Label
    Friend WithEvents txtRequiredAngle1_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredSwingClearance_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredGreaseZerk_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredLugsWidth_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredLugThickness_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredPinHoleSize_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents btnPicInformation As System.Windows.Forms.Button
    Friend WithEvents picREBHMatched_RodEnd As System.Windows.Forms.PictureBox
    Friend WithEvents txtLugThickness_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblLugThickness_RodEnd As System.Windows.Forms.Label
    Friend WithEvents txtAngle2_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblAngle2_RodEnd As System.Windows.Forms.Label
    Friend WithEvents txtAngle1_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblAngle1_RodEnd As System.Windows.Forms.Label
    Friend WithEvents txtGreaseZerk_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblGreaseZerk_RodEnd As System.Windows.Forms.Label
    Friend WithEvents txtLugsWidth_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblLugsWidth_RodEnd As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleSize_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblPinHoleSize_RodEnd As System.Windows.Forms.Label
    Friend WithEvents txtCodeNumber_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblCodeNumber_RodEnd As System.Windows.Forms.Label
    Friend WithEvents lvwRodEndBHListView_RodEnd As Monarch_WeldedCylinder_01_09_09.clsListViewMIL
    Friend WithEvents lblExistingBHIndex_RodEnd As LabelGradient.LabelGradient
    Friend WithEvents grbUsingSelectedBH_RodEnd As System.Windows.Forms.GroupBox
    Friend WithEvents rdbNewCasting_RodEnd As System.Windows.Forms.RadioButton
    Friend WithEvents rdbResize_RodEnd As System.Windows.Forms.RadioButton
    Friend WithEvents rdbUseSelectedBHYes As System.Windows.Forms.RadioButton
    Friend WithEvents lblUsingSelectedBH_RodEnd As LabelGradient.LabelGradient
    Friend WithEvents lblBackGround As LabelGradient.LabelGradient
    Friend WithEvents grbNotUsingSelectedcrosstubeCasting_RECT As System.Windows.Forms.GroupBox
    Friend WithEvents lblNotUsingSelectedBH As LabelGradient.LabelGradient
    Friend WithEvents btnClickNextButton As System.Windows.Forms.Button
    Friend WithEvents lblBHHeading As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient3 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient2 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient4 As LabelGradient.LabelGradient
    Friend WithEvents pnlRESLMaching_YesNo As System.Windows.Forms.Panel
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
    Friend WithEvents lblSwingClearance_DesignBH_RodEnd As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleSize_DesignBH_RodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblPinHoleSize_DesignBH_RodEnd As System.Windows.Forms.Label
    Friend WithEvents btnMatchedBHNotFound_RodEnd As System.Windows.Forms.Button
    Friend WithEvents LabelGradient1 As LabelGradient.LabelGradient
    Friend WithEvents btnAccept_RodEnd As System.Windows.Forms.Button
    Friend WithEvents LabelGradient5 As LabelGradient.LabelGradient
End Class
