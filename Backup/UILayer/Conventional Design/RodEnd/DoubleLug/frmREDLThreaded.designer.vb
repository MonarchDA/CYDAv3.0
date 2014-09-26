<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmREDLThreaded
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
        Me.pnlREDLThreaded_YesNo = New System.Windows.Forms.Panel
        Me.pnlDLThreadedYes = New System.Windows.Forms.Panel
        Me.grbREDLThreadedMatched = New System.Windows.Forms.GroupBox
        Me.txtPinHoleTole_Neg_Req = New IFLCustomUILayer.IFLNumericBox
        Me.txtPinHoleTole_Pos_Req = New IFLCustomUILayer.IFLNumericBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPinHoleTole_Neg = New IFLCustomUILayer.IFLNumericBox
        Me.txtPinHoleTole_Pos = New IFLCustomUILayer.IFLNumericBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblUseSelectedSingleLug = New System.Windows.Forms.Label
        Me.rdbUseSelectedSingleLugNo = New System.Windows.Forms.RadioButton
        Me.rdbUseSelectedSingleLugYes = New System.Windows.Forms.RadioButton
        Me.txtRequiredLugGap_Threaded = New IFLCustomUILayer.IFLNumericBox
        Me.txtLugGap_Threaded = New IFLCustomUILayer.IFLNumericBox
        Me.lblThreadSize_Threaded = New System.Windows.Forms.Label
        Me.lblLugGap_Threaded = New System.Windows.Forms.Label
        Me.lblThreadLength_Threaded = New System.Windows.Forms.Label
        Me.txtThreadSize_Threaded = New IFLCustomUILayer.IFLNumericBox
        Me.lblRequired = New System.Windows.Forms.Label
        Me.txtThreadLength_Threaded = New IFLCustomUILayer.IFLNumericBox
        Me.txtSwingClearance_Threaded = New IFLCustomUILayer.IFLNumericBox
        Me.lblSwingClearance_Threaded = New System.Windows.Forms.Label
        Me.txtRequiredSwingClearance_Threaded = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredLugThickness_Threaded = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredPinHoleSize_Threaded = New IFLCustomUILayer.IFLNumericBox
        Me.btnPicInformation = New System.Windows.Forms.Button
        Me.picDLThreaded = New System.Windows.Forms.PictureBox
        Me.txtLugThickness_Threaded = New IFLCustomUILayer.IFLNumericBox
        Me.lblLugThickness_Threaded = New System.Windows.Forms.Label
        Me.txtLugWidth_Threaded = New IFLCustomUILayer.IFLNumericBox
        Me.lblLugWidth_Threaded = New System.Windows.Forms.Label
        Me.txtPinHoleSize_Threaded = New IFLCustomUILayer.IFLNumericBox
        Me.lblPinHoleSize_Threaded = New System.Windows.Forms.Label
        Me.txtCodeNumber_Threaded = New IFLCustomUILayer.IFLNumericBox
        Me.lblCodeNumber_Threaded = New System.Windows.Forms.Label
        Me.lvwDLThreadedDetails = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL
        Me.lblExistingDoubleLugIndex_RodEnd = New LabelGradient.LabelGradient
        Me.grbUsingSelectedDLThreaded = New System.Windows.Forms.GroupBox
        Me.rdbNewCastingThreaded = New System.Windows.Forms.RadioButton
        Me.rdbResizeThreaded = New System.Windows.Forms.RadioButton
        Me.lblIsExactMatch = New System.Windows.Forms.Label
        Me.rdbExactMatchYes = New System.Windows.Forms.RadioButton
        Me.lblUseSelectedThreadedDoubleLug = New LabelGradient.LabelGradient
        Me.grbNotUsingSelectedDoubleLug = New System.Windows.Forms.GroupBox
        Me.btnShowWeldedScreenMessage = New System.Windows.Forms.Button
        Me.LabelGradient1 = New LabelGradient.LabelGradient
        Me.lblBackGround = New LabelGradient.LabelGradient
        Me.pnlDLThreadedNo = New System.Windows.Forms.Panel
        Me.btnDLThreadedNotFound = New System.Windows.Forms.Button
        Me.LabelGradient5 = New LabelGradient.LabelGradient
        Me.pnlREDLThreaded_YesNo.SuspendLayout()
        Me.pnlDLThreadedYes.SuspendLayout()
        Me.grbREDLThreadedMatched.SuspendLayout()
        CType(Me.picDLThreaded, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbUsingSelectedDLThreaded.SuspendLayout()
        Me.grbNotUsingSelectedDoubleLug.SuspendLayout()
        Me.pnlDLThreadedNo.SuspendLayout()
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
        Me.lblDLHeading.TabIndex = 47
        Me.lblDLHeading.Text = "Rod End Double Lug Threaded"
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
        Me.LabelGradient4.TabIndex = 46
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
        Me.LabelGradient3.TabIndex = 45
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
        Me.LabelGradient2.TabIndex = 44
        Me.LabelGradient2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlREDLThreaded_YesNo
        '
        Me.pnlREDLThreaded_YesNo.AutoScroll = True
        Me.pnlREDLThreaded_YesNo.Controls.Add(Me.pnlDLThreadedYes)
        Me.pnlREDLThreaded_YesNo.Controls.Add(Me.pnlDLThreadedNo)
        Me.pnlREDLThreaded_YesNo.Location = New System.Drawing.Point(26, 22)
        Me.pnlREDLThreaded_YesNo.Name = "pnlREDLThreaded_YesNo"
        Me.pnlREDLThreaded_YesNo.Size = New System.Drawing.Size(927, 563)
        Me.pnlREDLThreaded_YesNo.TabIndex = 48
        '
        'pnlDLThreadedYes
        '
        Me.pnlDLThreadedYes.BackColor = System.Drawing.Color.Black
        Me.pnlDLThreadedYes.Controls.Add(Me.grbREDLThreadedMatched)
        Me.pnlDLThreadedYes.Controls.Add(Me.grbUsingSelectedDLThreaded)
        Me.pnlDLThreadedYes.Controls.Add(Me.grbNotUsingSelectedDoubleLug)
        Me.pnlDLThreadedYes.Controls.Add(Me.lblBackGround)
        Me.pnlDLThreadedYes.Location = New System.Drawing.Point(3, 3)
        Me.pnlDLThreadedYes.Name = "pnlDLThreadedYes"
        Me.pnlDLThreadedYes.Size = New System.Drawing.Size(824, 538)
        Me.pnlDLThreadedYes.TabIndex = 41
        '
        'grbREDLThreadedMatched
        '
        Me.grbREDLThreadedMatched.BackColor = System.Drawing.Color.Ivory
        Me.grbREDLThreadedMatched.Controls.Add(Me.txtPinHoleTole_Neg_Req)
        Me.grbREDLThreadedMatched.Controls.Add(Me.txtPinHoleTole_Pos_Req)
        Me.grbREDLThreadedMatched.Controls.Add(Me.Label4)
        Me.grbREDLThreadedMatched.Controls.Add(Me.Label5)
        Me.grbREDLThreadedMatched.Controls.Add(Me.txtPinHoleTole_Neg)
        Me.grbREDLThreadedMatched.Controls.Add(Me.txtPinHoleTole_Pos)
        Me.grbREDLThreadedMatched.Controls.Add(Me.Label6)
        Me.grbREDLThreadedMatched.Controls.Add(Me.Label3)
        Me.grbREDLThreadedMatched.Controls.Add(Me.Label1)
        Me.grbREDLThreadedMatched.Controls.Add(Me.Label2)
        Me.grbREDLThreadedMatched.Controls.Add(Me.lblUseSelectedSingleLug)
        Me.grbREDLThreadedMatched.Controls.Add(Me.rdbUseSelectedSingleLugNo)
        Me.grbREDLThreadedMatched.Controls.Add(Me.rdbUseSelectedSingleLugYes)
        Me.grbREDLThreadedMatched.Controls.Add(Me.txtRequiredLugGap_Threaded)
        Me.grbREDLThreadedMatched.Controls.Add(Me.txtLugGap_Threaded)
        Me.grbREDLThreadedMatched.Controls.Add(Me.lblThreadSize_Threaded)
        Me.grbREDLThreadedMatched.Controls.Add(Me.lblLugGap_Threaded)
        Me.grbREDLThreadedMatched.Controls.Add(Me.lblThreadLength_Threaded)
        Me.grbREDLThreadedMatched.Controls.Add(Me.txtThreadSize_Threaded)
        Me.grbREDLThreadedMatched.Controls.Add(Me.lblRequired)
        Me.grbREDLThreadedMatched.Controls.Add(Me.txtThreadLength_Threaded)
        Me.grbREDLThreadedMatched.Controls.Add(Me.txtSwingClearance_Threaded)
        Me.grbREDLThreadedMatched.Controls.Add(Me.lblSwingClearance_Threaded)
        Me.grbREDLThreadedMatched.Controls.Add(Me.txtRequiredSwingClearance_Threaded)
        Me.grbREDLThreadedMatched.Controls.Add(Me.txtRequiredLugThickness_Threaded)
        Me.grbREDLThreadedMatched.Controls.Add(Me.txtRequiredPinHoleSize_Threaded)
        Me.grbREDLThreadedMatched.Controls.Add(Me.btnPicInformation)
        Me.grbREDLThreadedMatched.Controls.Add(Me.picDLThreaded)
        Me.grbREDLThreadedMatched.Controls.Add(Me.txtLugThickness_Threaded)
        Me.grbREDLThreadedMatched.Controls.Add(Me.lblLugThickness_Threaded)
        Me.grbREDLThreadedMatched.Controls.Add(Me.txtLugWidth_Threaded)
        Me.grbREDLThreadedMatched.Controls.Add(Me.lblLugWidth_Threaded)
        Me.grbREDLThreadedMatched.Controls.Add(Me.txtPinHoleSize_Threaded)
        Me.grbREDLThreadedMatched.Controls.Add(Me.lblPinHoleSize_Threaded)
        Me.grbREDLThreadedMatched.Controls.Add(Me.txtCodeNumber_Threaded)
        Me.grbREDLThreadedMatched.Controls.Add(Me.lblCodeNumber_Threaded)
        Me.grbREDLThreadedMatched.Controls.Add(Me.lvwDLThreadedDetails)
        Me.grbREDLThreadedMatched.Controls.Add(Me.lblExistingDoubleLugIndex_RodEnd)
        Me.grbREDLThreadedMatched.Location = New System.Drawing.Point(21, 9)
        Me.grbREDLThreadedMatched.Name = "grbREDLThreadedMatched"
        Me.grbREDLThreadedMatched.Size = New System.Drawing.Size(543, 379)
        Me.grbREDLThreadedMatched.TabIndex = 15
        Me.grbREDLThreadedMatched.TabStop = False
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
        Me.txtPinHoleTole_Neg_Req.Location = New System.Drawing.Point(464, 323)
        Me.txtPinHoleTole_Neg_Req.MaximumValue = 99999
        Me.txtPinHoleTole_Neg_Req.MaxLength = 6
        Me.txtPinHoleTole_Neg_Req.MinimumValue = 0
        Me.txtPinHoleTole_Neg_Req.Name = "txtPinHoleTole_Neg_Req"
        Me.txtPinHoleTole_Neg_Req.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Neg_Req.StatusMessage = ""
        Me.txtPinHoleTole_Neg_Req.StatusObject = Nothing
        Me.txtPinHoleTole_Neg_Req.TabIndex = 183
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
        Me.txtPinHoleTole_Pos_Req.Location = New System.Drawing.Point(464, 297)
        Me.txtPinHoleTole_Pos_Req.MaximumValue = 99999
        Me.txtPinHoleTole_Pos_Req.MaxLength = 6
        Me.txtPinHoleTole_Pos_Req.MinimumValue = 0
        Me.txtPinHoleTole_Pos_Req.Name = "txtPinHoleTole_Pos_Req"
        Me.txtPinHoleTole_Pos_Req.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Pos_Req.StatusMessage = ""
        Me.txtPinHoleTole_Pos_Req.StatusObject = Nothing
        Me.txtPinHoleTole_Pos_Req.TabIndex = 182
        Me.txtPinHoleTole_Pos_Req.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(377, 326)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 181
        Me.Label4.Text = "-"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(377, 300)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 13)
        Me.Label5.TabIndex = 180
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
        Me.txtPinHoleTole_Neg.Location = New System.Drawing.Point(393, 323)
        Me.txtPinHoleTole_Neg.MaximumValue = 99999
        Me.txtPinHoleTole_Neg.MaxLength = 6
        Me.txtPinHoleTole_Neg.MinimumValue = 0
        Me.txtPinHoleTole_Neg.Name = "txtPinHoleTole_Neg"
        Me.txtPinHoleTole_Neg.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Neg.StatusMessage = ""
        Me.txtPinHoleTole_Neg.StatusObject = Nothing
        Me.txtPinHoleTole_Neg.TabIndex = 179
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
        Me.txtPinHoleTole_Pos.Location = New System.Drawing.Point(393, 297)
        Me.txtPinHoleTole_Pos.MaximumValue = 99999
        Me.txtPinHoleTole_Pos.MaxLength = 6
        Me.txtPinHoleTole_Pos.MinimumValue = 0
        Me.txtPinHoleTole_Pos.Name = "txtPinHoleTole_Pos"
        Me.txtPinHoleTole_Pos.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Pos.StatusMessage = ""
        Me.txtPinHoleTole_Pos.StatusObject = Nothing
        Me.txtPinHoleTole_Pos.TabIndex = 177
        Me.txtPinHoleTole_Pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(270, 300)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 178
        Me.Label6.Text = "Pin Hole Tolerance"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(469, 165)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 168
        Me.Label3.Text = "Required"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(399, 165)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 166
        Me.Label1.Text = "Available"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(115, 165)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 167
        Me.Label2.Text = "Available"
        '
        'lblUseSelectedSingleLug
        '
        Me.lblUseSelectedSingleLug.AutoSize = True
        Me.lblUseSelectedSingleLug.Location = New System.Drawing.Point(27, 338)
        Me.lblUseSelectedSingleLug.Name = "lblUseSelectedSingleLug"
        Me.lblUseSelectedSingleLug.Size = New System.Drawing.Size(126, 13)
        Me.lblUseSelectedSingleLug.TabIndex = 147
        Me.lblUseSelectedSingleLug.Text = "Use Selected DoubleLug"
        '
        'rdbUseSelectedSingleLugNo
        '
        Me.rdbUseSelectedSingleLugNo.AutoSize = True
        Me.rdbUseSelectedSingleLugNo.Location = New System.Drawing.Point(219, 338)
        Me.rdbUseSelectedSingleLugNo.Name = "rdbUseSelectedSingleLugNo"
        Me.rdbUseSelectedSingleLugNo.Size = New System.Drawing.Size(39, 17)
        Me.rdbUseSelectedSingleLugNo.TabIndex = 146
        Me.rdbUseSelectedSingleLugNo.TabStop = True
        Me.rdbUseSelectedSingleLugNo.Text = "No"
        Me.rdbUseSelectedSingleLugNo.UseVisualStyleBackColor = True
        '
        'rdbUseSelectedSingleLugYes
        '
        Me.rdbUseSelectedSingleLugYes.AutoSize = True
        Me.rdbUseSelectedSingleLugYes.Location = New System.Drawing.Point(170, 338)
        Me.rdbUseSelectedSingleLugYes.Name = "rdbUseSelectedSingleLugYes"
        Me.rdbUseSelectedSingleLugYes.Size = New System.Drawing.Size(43, 17)
        Me.rdbUseSelectedSingleLugYes.TabIndex = 145
        Me.rdbUseSelectedSingleLugYes.TabStop = True
        Me.rdbUseSelectedSingleLugYes.Text = "Yes"
        Me.rdbUseSelectedSingleLugYes.UseVisualStyleBackColor = True
        '
        'txtRequiredLugGap_Threaded
        '
        Me.txtRequiredLugGap_Threaded.AcceptEnterKeyAsTab = True
        Me.txtRequiredLugGap_Threaded.ApplyIFLColor = True
        Me.txtRequiredLugGap_Threaded.AssociateLabel = Nothing
        Me.txtRequiredLugGap_Threaded.DecimalValue = 2
        Me.txtRequiredLugGap_Threaded.IFLDataTag = Nothing
        Me.txtRequiredLugGap_Threaded.InvalidInputCharacters = ""
        Me.txtRequiredLugGap_Threaded.IsAllowNegative = False
        Me.txtRequiredLugGap_Threaded.LengthValue = 6
        Me.txtRequiredLugGap_Threaded.Location = New System.Drawing.Point(180, 271)
        Me.txtRequiredLugGap_Threaded.MaximumValue = 99999
        Me.txtRequiredLugGap_Threaded.MaxLength = 6
        Me.txtRequiredLugGap_Threaded.MinimumValue = 0
        Me.txtRequiredLugGap_Threaded.Name = "txtRequiredLugGap_Threaded"
        Me.txtRequiredLugGap_Threaded.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredLugGap_Threaded.StatusMessage = ""
        Me.txtRequiredLugGap_Threaded.StatusObject = Nothing
        Me.txtRequiredLugGap_Threaded.TabIndex = 24
        Me.txtRequiredLugGap_Threaded.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLugGap_Threaded
        '
        Me.txtLugGap_Threaded.AcceptEnterKeyAsTab = True
        Me.txtLugGap_Threaded.ApplyIFLColor = True
        Me.txtLugGap_Threaded.AssociateLabel = Nothing
        Me.txtLugGap_Threaded.DecimalValue = 2
        Me.txtLugGap_Threaded.IFLDataTag = Nothing
        Me.txtLugGap_Threaded.InvalidInputCharacters = ""
        Me.txtLugGap_Threaded.IsAllowNegative = False
        Me.txtLugGap_Threaded.LengthValue = 6
        Me.txtLugGap_Threaded.Location = New System.Drawing.Point(109, 271)
        Me.txtLugGap_Threaded.MaximumValue = 99999
        Me.txtLugGap_Threaded.MaxLength = 6
        Me.txtLugGap_Threaded.MinimumValue = 0
        Me.txtLugGap_Threaded.Name = "txtLugGap_Threaded"
        Me.txtLugGap_Threaded.Size = New System.Drawing.Size(66, 20)
        Me.txtLugGap_Threaded.StatusMessage = ""
        Me.txtLugGap_Threaded.StatusObject = Nothing
        Me.txtLugGap_Threaded.TabIndex = 24
        Me.txtLugGap_Threaded.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblThreadSize_Threaded
        '
        Me.lblThreadSize_Threaded.AutoSize = True
        Me.lblThreadSize_Threaded.Location = New System.Drawing.Point(270, 219)
        Me.lblThreadSize_Threaded.Name = "lblThreadSize_Threaded"
        Me.lblThreadSize_Threaded.Size = New System.Drawing.Size(64, 13)
        Me.lblThreadSize_Threaded.TabIndex = 122
        Me.lblThreadSize_Threaded.Text = "Thread Size"
        '
        'lblLugGap_Threaded
        '
        Me.lblLugGap_Threaded.AutoSize = True
        Me.lblLugGap_Threaded.Location = New System.Drawing.Point(27, 274)
        Me.lblLugGap_Threaded.Name = "lblLugGap_Threaded"
        Me.lblLugGap_Threaded.Size = New System.Drawing.Size(48, 13)
        Me.lblLugGap_Threaded.TabIndex = 143
        Me.lblLugGap_Threaded.Text = "Lug Gap"
        '
        'lblThreadLength_Threaded
        '
        Me.lblThreadLength_Threaded.AutoSize = True
        Me.lblThreadLength_Threaded.Location = New System.Drawing.Point(270, 190)
        Me.lblThreadLength_Threaded.Name = "lblThreadLength_Threaded"
        Me.lblThreadLength_Threaded.Size = New System.Drawing.Size(77, 13)
        Me.lblThreadLength_Threaded.TabIndex = 124
        Me.lblThreadLength_Threaded.Text = "Thread Length"
        '
        'txtThreadSize_Threaded
        '
        Me.txtThreadSize_Threaded.AcceptEnterKeyAsTab = True
        Me.txtThreadSize_Threaded.ApplyIFLColor = True
        Me.txtThreadSize_Threaded.AssociateLabel = Nothing
        Me.txtThreadSize_Threaded.DecimalValue = 2
        Me.txtThreadSize_Threaded.IFLDataTag = Nothing
        Me.txtThreadSize_Threaded.InvalidInputCharacters = ""
        Me.txtThreadSize_Threaded.IsAllowNegative = False
        Me.txtThreadSize_Threaded.LengthValue = 6
        Me.txtThreadSize_Threaded.Location = New System.Drawing.Point(393, 214)
        Me.txtThreadSize_Threaded.MaximumValue = 99999
        Me.txtThreadSize_Threaded.MaxLength = 6
        Me.txtThreadSize_Threaded.MinimumValue = 0
        Me.txtThreadSize_Threaded.Name = "txtThreadSize_Threaded"
        Me.txtThreadSize_Threaded.Size = New System.Drawing.Size(66, 20)
        Me.txtThreadSize_Threaded.StatusMessage = ""
        Me.txtThreadSize_Threaded.StatusObject = Nothing
        Me.txtThreadSize_Threaded.TabIndex = 27
        Me.txtThreadSize_Threaded.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblRequired
        '
        Me.lblRequired.AutoSize = True
        Me.lblRequired.Location = New System.Drawing.Point(185, 165)
        Me.lblRequired.Name = "lblRequired"
        Me.lblRequired.Size = New System.Drawing.Size(50, 13)
        Me.lblRequired.TabIndex = 141
        Me.lblRequired.Text = "Required"
        '
        'txtThreadLength_Threaded
        '
        Me.txtThreadLength_Threaded.AcceptEnterKeyAsTab = True
        Me.txtThreadLength_Threaded.ApplyIFLColor = True
        Me.txtThreadLength_Threaded.AssociateLabel = Nothing
        Me.txtThreadLength_Threaded.DecimalValue = 2
        Me.txtThreadLength_Threaded.IFLDataTag = Nothing
        Me.txtThreadLength_Threaded.InvalidInputCharacters = ""
        Me.txtThreadLength_Threaded.IsAllowNegative = False
        Me.txtThreadLength_Threaded.LengthValue = 6
        Me.txtThreadLength_Threaded.Location = New System.Drawing.Point(393, 187)
        Me.txtThreadLength_Threaded.MaximumValue = 99999
        Me.txtThreadLength_Threaded.MaxLength = 6
        Me.txtThreadLength_Threaded.MinimumValue = 0
        Me.txtThreadLength_Threaded.Name = "txtThreadLength_Threaded"
        Me.txtThreadLength_Threaded.Size = New System.Drawing.Size(66, 20)
        Me.txtThreadLength_Threaded.StatusMessage = ""
        Me.txtThreadLength_Threaded.StatusObject = Nothing
        Me.txtThreadLength_Threaded.TabIndex = 29
        Me.txtThreadLength_Threaded.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSwingClearance_Threaded
        '
        Me.txtSwingClearance_Threaded.AcceptEnterKeyAsTab = True
        Me.txtSwingClearance_Threaded.ApplyIFLColor = True
        Me.txtSwingClearance_Threaded.AssociateLabel = Nothing
        Me.txtSwingClearance_Threaded.DecimalValue = 2
        Me.txtSwingClearance_Threaded.IFLDataTag = Nothing
        Me.txtSwingClearance_Threaded.InvalidInputCharacters = ""
        Me.txtSwingClearance_Threaded.IsAllowNegative = False
        Me.txtSwingClearance_Threaded.LengthValue = 6
        Me.txtSwingClearance_Threaded.Location = New System.Drawing.Point(393, 244)
        Me.txtSwingClearance_Threaded.MaximumValue = 99999
        Me.txtSwingClearance_Threaded.MaxLength = 6
        Me.txtSwingClearance_Threaded.MinimumValue = 0
        Me.txtSwingClearance_Threaded.Name = "txtSwingClearance_Threaded"
        Me.txtSwingClearance_Threaded.Size = New System.Drawing.Size(66, 20)
        Me.txtSwingClearance_Threaded.StatusMessage = ""
        Me.txtSwingClearance_Threaded.StatusObject = Nothing
        Me.txtSwingClearance_Threaded.TabIndex = 25
        Me.txtSwingClearance_Threaded.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSwingClearance_Threaded
        '
        Me.lblSwingClearance_Threaded.AutoSize = True
        Me.lblSwingClearance_Threaded.Location = New System.Drawing.Point(270, 248)
        Me.lblSwingClearance_Threaded.Name = "lblSwingClearance_Threaded"
        Me.lblSwingClearance_Threaded.Size = New System.Drawing.Size(87, 13)
        Me.lblSwingClearance_Threaded.TabIndex = 114
        Me.lblSwingClearance_Threaded.Text = "Swing Clearance"
        '
        'txtRequiredSwingClearance_Threaded
        '
        Me.txtRequiredSwingClearance_Threaded.AcceptEnterKeyAsTab = True
        Me.txtRequiredSwingClearance_Threaded.ApplyIFLColor = True
        Me.txtRequiredSwingClearance_Threaded.AssociateLabel = Nothing
        Me.txtRequiredSwingClearance_Threaded.DecimalValue = 2
        Me.txtRequiredSwingClearance_Threaded.IFLDataTag = Nothing
        Me.txtRequiredSwingClearance_Threaded.InvalidInputCharacters = ""
        Me.txtRequiredSwingClearance_Threaded.IsAllowNegative = False
        Me.txtRequiredSwingClearance_Threaded.LengthValue = 6
        Me.txtRequiredSwingClearance_Threaded.Location = New System.Drawing.Point(464, 245)
        Me.txtRequiredSwingClearance_Threaded.MaximumValue = 99999
        Me.txtRequiredSwingClearance_Threaded.MaxLength = 6
        Me.txtRequiredSwingClearance_Threaded.MinimumValue = 0
        Me.txtRequiredSwingClearance_Threaded.Name = "txtRequiredSwingClearance_Threaded"
        Me.txtRequiredSwingClearance_Threaded.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredSwingClearance_Threaded.StatusMessage = ""
        Me.txtRequiredSwingClearance_Threaded.StatusObject = Nothing
        Me.txtRequiredSwingClearance_Threaded.TabIndex = 26
        Me.txtRequiredSwingClearance_Threaded.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredLugThickness_Threaded
        '
        Me.txtRequiredLugThickness_Threaded.AcceptEnterKeyAsTab = True
        Me.txtRequiredLugThickness_Threaded.ApplyIFLColor = True
        Me.txtRequiredLugThickness_Threaded.AssociateLabel = Nothing
        Me.txtRequiredLugThickness_Threaded.DecimalValue = 2
        Me.txtRequiredLugThickness_Threaded.IFLDataTag = Nothing
        Me.txtRequiredLugThickness_Threaded.InvalidInputCharacters = ""
        Me.txtRequiredLugThickness_Threaded.IsAllowNegative = False
        Me.txtRequiredLugThickness_Threaded.LengthValue = 6
        Me.txtRequiredLugThickness_Threaded.Location = New System.Drawing.Point(181, 244)
        Me.txtRequiredLugThickness_Threaded.MaximumValue = 99999
        Me.txtRequiredLugThickness_Threaded.MaxLength = 6
        Me.txtRequiredLugThickness_Threaded.MinimumValue = 0
        Me.txtRequiredLugThickness_Threaded.Name = "txtRequiredLugThickness_Threaded"
        Me.txtRequiredLugThickness_Threaded.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredLugThickness_Threaded.StatusMessage = ""
        Me.txtRequiredLugThickness_Threaded.StatusObject = Nothing
        Me.txtRequiredLugThickness_Threaded.TabIndex = 19
        Me.txtRequiredLugThickness_Threaded.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredPinHoleSize_Threaded
        '
        Me.txtRequiredPinHoleSize_Threaded.AcceptEnterKeyAsTab = True
        Me.txtRequiredPinHoleSize_Threaded.ApplyIFLColor = True
        Me.txtRequiredPinHoleSize_Threaded.AssociateLabel = Nothing
        Me.txtRequiredPinHoleSize_Threaded.DecimalValue = 2
        Me.txtRequiredPinHoleSize_Threaded.IFLDataTag = Nothing
        Me.txtRequiredPinHoleSize_Threaded.InvalidInputCharacters = ""
        Me.txtRequiredPinHoleSize_Threaded.IsAllowNegative = False
        Me.txtRequiredPinHoleSize_Threaded.LengthValue = 6
        Me.txtRequiredPinHoleSize_Threaded.Location = New System.Drawing.Point(464, 271)
        Me.txtRequiredPinHoleSize_Threaded.MaximumValue = 99999
        Me.txtRequiredPinHoleSize_Threaded.MaxLength = 6
        Me.txtRequiredPinHoleSize_Threaded.MinimumValue = 0
        Me.txtRequiredPinHoleSize_Threaded.Name = "txtRequiredPinHoleSize_Threaded"
        Me.txtRequiredPinHoleSize_Threaded.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredPinHoleSize_Threaded.StatusMessage = ""
        Me.txtRequiredPinHoleSize_Threaded.StatusObject = Nothing
        Me.txtRequiredPinHoleSize_Threaded.TabIndex = 23
        Me.txtRequiredPinHoleSize_Threaded.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'picDLThreaded
        '
        Me.picDLThreaded.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picDLThreaded.Location = New System.Drawing.Point(386, 33)
        Me.picDLThreaded.Name = "picDLThreaded"
        Me.picDLThreaded.Size = New System.Drawing.Size(151, 122)
        Me.picDLThreaded.TabIndex = 130
        Me.picDLThreaded.TabStop = False
        '
        'txtLugThickness_Threaded
        '
        Me.txtLugThickness_Threaded.AcceptEnterKeyAsTab = True
        Me.txtLugThickness_Threaded.ApplyIFLColor = True
        Me.txtLugThickness_Threaded.AssociateLabel = Nothing
        Me.txtLugThickness_Threaded.DecimalValue = 2
        Me.txtLugThickness_Threaded.IFLDataTag = Nothing
        Me.txtLugThickness_Threaded.InvalidInputCharacters = ""
        Me.txtLugThickness_Threaded.IsAllowNegative = False
        Me.txtLugThickness_Threaded.LengthValue = 6
        Me.txtLugThickness_Threaded.Location = New System.Drawing.Point(109, 244)
        Me.txtLugThickness_Threaded.MaximumValue = 99999
        Me.txtLugThickness_Threaded.MaxLength = 6
        Me.txtLugThickness_Threaded.MinimumValue = 0
        Me.txtLugThickness_Threaded.Name = "txtLugThickness_Threaded"
        Me.txtLugThickness_Threaded.Size = New System.Drawing.Size(66, 20)
        Me.txtLugThickness_Threaded.StatusMessage = ""
        Me.txtLugThickness_Threaded.StatusObject = Nothing
        Me.txtLugThickness_Threaded.TabIndex = 18
        Me.txtLugThickness_Threaded.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLugThickness_Threaded
        '
        Me.lblLugThickness_Threaded.AutoSize = True
        Me.lblLugThickness_Threaded.Location = New System.Drawing.Point(27, 248)
        Me.lblLugThickness_Threaded.Name = "lblLugThickness_Threaded"
        Me.lblLugThickness_Threaded.Size = New System.Drawing.Size(77, 13)
        Me.lblLugThickness_Threaded.TabIndex = 128
        Me.lblLugThickness_Threaded.Text = "Lug Thickness"
        '
        'txtLugWidth_Threaded
        '
        Me.txtLugWidth_Threaded.AcceptEnterKeyAsTab = True
        Me.txtLugWidth_Threaded.ApplyIFLColor = True
        Me.txtLugWidth_Threaded.AssociateLabel = Nothing
        Me.txtLugWidth_Threaded.DecimalValue = 2
        Me.txtLugWidth_Threaded.IFLDataTag = Nothing
        Me.txtLugWidth_Threaded.InvalidInputCharacters = ""
        Me.txtLugWidth_Threaded.IsAllowNegative = False
        Me.txtLugWidth_Threaded.LengthValue = 6
        Me.txtLugWidth_Threaded.Location = New System.Drawing.Point(109, 214)
        Me.txtLugWidth_Threaded.MaximumValue = 99999
        Me.txtLugWidth_Threaded.MaxLength = 6
        Me.txtLugWidth_Threaded.MinimumValue = 0
        Me.txtLugWidth_Threaded.Name = "txtLugWidth_Threaded"
        Me.txtLugWidth_Threaded.Size = New System.Drawing.Size(66, 20)
        Me.txtLugWidth_Threaded.StatusMessage = ""
        Me.txtLugWidth_Threaded.StatusObject = Nothing
        Me.txtLugWidth_Threaded.TabIndex = 20
        Me.txtLugWidth_Threaded.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLugWidth_Threaded
        '
        Me.lblLugWidth_Threaded.AutoSize = True
        Me.lblLugWidth_Threaded.Location = New System.Drawing.Point(27, 219)
        Me.lblLugWidth_Threaded.Name = "lblLugWidth_Threaded"
        Me.lblLugWidth_Threaded.Size = New System.Drawing.Size(56, 13)
        Me.lblLugWidth_Threaded.TabIndex = 120
        Me.lblLugWidth_Threaded.Text = "Lug Width"
        '
        'txtPinHoleSize_Threaded
        '
        Me.txtPinHoleSize_Threaded.AcceptEnterKeyAsTab = True
        Me.txtPinHoleSize_Threaded.ApplyIFLColor = True
        Me.txtPinHoleSize_Threaded.AssociateLabel = Nothing
        Me.txtPinHoleSize_Threaded.DecimalValue = 2
        Me.txtPinHoleSize_Threaded.IFLDataTag = Nothing
        Me.txtPinHoleSize_Threaded.InvalidInputCharacters = ""
        Me.txtPinHoleSize_Threaded.IsAllowNegative = False
        Me.txtPinHoleSize_Threaded.LengthValue = 6
        Me.txtPinHoleSize_Threaded.Location = New System.Drawing.Point(393, 271)
        Me.txtPinHoleSize_Threaded.MaximumValue = 99999
        Me.txtPinHoleSize_Threaded.MaxLength = 6
        Me.txtPinHoleSize_Threaded.MinimumValue = 0
        Me.txtPinHoleSize_Threaded.Name = "txtPinHoleSize_Threaded"
        Me.txtPinHoleSize_Threaded.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleSize_Threaded.StatusMessage = ""
        Me.txtPinHoleSize_Threaded.StatusObject = Nothing
        Me.txtPinHoleSize_Threaded.TabIndex = 22
        Me.txtPinHoleSize_Threaded.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPinHoleSize_Threaded
        '
        Me.lblPinHoleSize_Threaded.AutoSize = True
        Me.lblPinHoleSize_Threaded.Location = New System.Drawing.Point(270, 274)
        Me.lblPinHoleSize_Threaded.Name = "lblPinHoleSize_Threaded"
        Me.lblPinHoleSize_Threaded.Size = New System.Drawing.Size(70, 13)
        Me.lblPinHoleSize_Threaded.TabIndex = 116
        Me.lblPinHoleSize_Threaded.Text = "Pin Hole Size"
        '
        'txtCodeNumber_Threaded
        '
        Me.txtCodeNumber_Threaded.AcceptEnterKeyAsTab = True
        Me.txtCodeNumber_Threaded.ApplyIFLColor = True
        Me.txtCodeNumber_Threaded.AssociateLabel = Nothing
        Me.txtCodeNumber_Threaded.DecimalValue = 2
        Me.txtCodeNumber_Threaded.IFLDataTag = Nothing
        Me.txtCodeNumber_Threaded.InvalidInputCharacters = ""
        Me.txtCodeNumber_Threaded.IsAllowNegative = False
        Me.txtCodeNumber_Threaded.LengthValue = 6
        Me.txtCodeNumber_Threaded.Location = New System.Drawing.Point(109, 187)
        Me.txtCodeNumber_Threaded.MaximumValue = 99999
        Me.txtCodeNumber_Threaded.MaxLength = 6
        Me.txtCodeNumber_Threaded.MinimumValue = 0
        Me.txtCodeNumber_Threaded.Name = "txtCodeNumber_Threaded"
        Me.txtCodeNumber_Threaded.Size = New System.Drawing.Size(66, 20)
        Me.txtCodeNumber_Threaded.StatusMessage = ""
        Me.txtCodeNumber_Threaded.StatusObject = Nothing
        Me.txtCodeNumber_Threaded.TabIndex = 17
        Me.txtCodeNumber_Threaded.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCodeNumber_Threaded
        '
        Me.lblCodeNumber_Threaded.AutoSize = True
        Me.lblCodeNumber_Threaded.Location = New System.Drawing.Point(27, 190)
        Me.lblCodeNumber_Threaded.Name = "lblCodeNumber_Threaded"
        Me.lblCodeNumber_Threaded.Size = New System.Drawing.Size(72, 13)
        Me.lblCodeNumber_Threaded.TabIndex = 112
        Me.lblCodeNumber_Threaded.Text = "Code Number"
        '
        'lvwDLThreadedDetails
        '
        Me.lvwDLThreadedDetails.FullRowSelect = True
        Me.lvwDLThreadedDetails.GridLines = True
        Me.lvwDLThreadedDetails.Location = New System.Drawing.Point(6, 33)
        Me.lvwDLThreadedDetails.MultiSelect = False
        Me.lvwDLThreadedDetails.Name = "lvwDLThreadedDetails"
        Me.lvwDLThreadedDetails.Scrollable = False
        Me.lvwDLThreadedDetails.Size = New System.Drawing.Size(369, 122)
        Me.lvwDLThreadedDetails.TabIndex = 16
        Me.lvwDLThreadedDetails.UseCompatibleStateImageBehavior = False
        Me.lvwDLThreadedDetails.View = System.Windows.Forms.View.Details
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
        Me.lblExistingDoubleLugIndex_RodEnd.Text = "Existing RodEnd Threaded Double Lug  Details"
        Me.lblExistingDoubleLugIndex_RodEnd.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grbUsingSelectedDLThreaded
        '
        Me.grbUsingSelectedDLThreaded.BackColor = System.Drawing.Color.Ivory
        Me.grbUsingSelectedDLThreaded.Controls.Add(Me.rdbNewCastingThreaded)
        Me.grbUsingSelectedDLThreaded.Controls.Add(Me.rdbResizeThreaded)
        Me.grbUsingSelectedDLThreaded.Controls.Add(Me.lblIsExactMatch)
        Me.grbUsingSelectedDLThreaded.Controls.Add(Me.rdbExactMatchYes)
        Me.grbUsingSelectedDLThreaded.Controls.Add(Me.lblUseSelectedThreadedDoubleLug)
        Me.grbUsingSelectedDLThreaded.Location = New System.Drawing.Point(22, 394)
        Me.grbUsingSelectedDLThreaded.Name = "grbUsingSelectedDLThreaded"
        Me.grbUsingSelectedDLThreaded.Size = New System.Drawing.Size(543, 105)
        Me.grbUsingSelectedDLThreaded.TabIndex = 33
        Me.grbUsingSelectedDLThreaded.TabStop = False
        '
        'rdbNewCastingThreaded
        '
        Me.rdbNewCastingThreaded.AutoSize = True
        Me.rdbNewCastingThreaded.Location = New System.Drawing.Point(343, 49)
        Me.rdbNewCastingThreaded.Name = "rdbNewCastingThreaded"
        Me.rdbNewCastingThreaded.Size = New System.Drawing.Size(85, 17)
        Me.rdbNewCastingThreaded.TabIndex = 37
        Me.rdbNewCastingThreaded.TabStop = True
        Me.rdbNewCastingThreaded.Text = "New Casting"
        Me.rdbNewCastingThreaded.UseVisualStyleBackColor = True
        '
        'rdbResizeThreaded
        '
        Me.rdbResizeThreaded.AutoSize = True
        Me.rdbResizeThreaded.Location = New System.Drawing.Point(272, 49)
        Me.rdbResizeThreaded.Name = "rdbResizeThreaded"
        Me.rdbResizeThreaded.Size = New System.Drawing.Size(57, 17)
        Me.rdbResizeThreaded.TabIndex = 36
        Me.rdbResizeThreaded.TabStop = True
        Me.rdbResizeThreaded.Text = "Resize"
        Me.rdbResizeThreaded.UseVisualStyleBackColor = True
        '
        'lblIsExactMatch
        '
        Me.lblIsExactMatch.AutoSize = True
        Me.lblIsExactMatch.Location = New System.Drawing.Point(114, 51)
        Me.lblIsExactMatch.Name = "lblIsExactMatch"
        Me.lblIsExactMatch.Size = New System.Drawing.Size(87, 13)
        Me.lblIsExactMatch.TabIndex = 148
        Me.lblIsExactMatch.Text = "Is Exact Match ?"
        '
        'rdbExactMatchYes
        '
        Me.rdbExactMatchYes.AutoSize = True
        Me.rdbExactMatchYes.Location = New System.Drawing.Point(215, 49)
        Me.rdbExactMatchYes.Name = "rdbExactMatchYes"
        Me.rdbExactMatchYes.Size = New System.Drawing.Size(43, 17)
        Me.rdbExactMatchYes.TabIndex = 146
        Me.rdbExactMatchYes.TabStop = True
        Me.rdbExactMatchYes.Text = "Yes"
        Me.rdbExactMatchYes.UseVisualStyleBackColor = True
        '
        'lblUseSelectedThreadedDoubleLug
        '
        Me.lblUseSelectedThreadedDoubleLug.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblUseSelectedThreadedDoubleLug.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUseSelectedThreadedDoubleLug.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUseSelectedThreadedDoubleLug.GradientColorOne = System.Drawing.Color.Olive
        Me.lblUseSelectedThreadedDoubleLug.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblUseSelectedThreadedDoubleLug.Location = New System.Drawing.Point(-2, 0)
        Me.lblUseSelectedThreadedDoubleLug.Name = "lblUseSelectedThreadedDoubleLug"
        Me.lblUseSelectedThreadedDoubleLug.Size = New System.Drawing.Size(545, 19)
        Me.lblUseSelectedThreadedDoubleLug.TabIndex = 111
        Me.lblUseSelectedThreadedDoubleLug.Text = "Use Selected Threaded Double Lug "
        Me.lblUseSelectedThreadedDoubleLug.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grbNotUsingSelectedDoubleLug
        '
        Me.grbNotUsingSelectedDoubleLug.BackColor = System.Drawing.Color.Ivory
        Me.grbNotUsingSelectedDoubleLug.Controls.Add(Me.btnShowWeldedScreenMessage)
        Me.grbNotUsingSelectedDoubleLug.Controls.Add(Me.LabelGradient1)
        Me.grbNotUsingSelectedDoubleLug.Location = New System.Drawing.Point(22, 394)
        Me.grbNotUsingSelectedDoubleLug.Name = "grbNotUsingSelectedDoubleLug"
        Me.grbNotUsingSelectedDoubleLug.Size = New System.Drawing.Size(543, 105)
        Me.grbNotUsingSelectedDoubleLug.TabIndex = 113
        Me.grbNotUsingSelectedDoubleLug.TabStop = False
        '
        'btnShowWeldedScreenMessage
        '
        Me.btnShowWeldedScreenMessage.BackColor = System.Drawing.Color.Ivory
        Me.btnShowWeldedScreenMessage.Enabled = False
        Me.btnShowWeldedScreenMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowWeldedScreenMessage.Location = New System.Drawing.Point(138, 31)
        Me.btnShowWeldedScreenMessage.Name = "btnShowWeldedScreenMessage"
        Me.btnShowWeldedScreenMessage.Size = New System.Drawing.Size(264, 53)
        Me.btnShowWeldedScreenMessage.TabIndex = 148
        Me.btnShowWeldedScreenMessage.Text = "Seleted Threaded DoubleLug not used," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click next button to access Welded screen."
        Me.btnShowWeldedScreenMessage.UseVisualStyleBackColor = False
        '
        'LabelGradient1
        '
        Me.LabelGradient1.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient1.GradientColorOne = System.Drawing.Color.Olive
        Me.LabelGradient1.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient1.Location = New System.Drawing.Point(-2, 0)
        Me.LabelGradient1.Name = "LabelGradient1"
        Me.LabelGradient1.Size = New System.Drawing.Size(545, 19)
        Me.LabelGradient1.TabIndex = 111
        Me.LabelGradient1.Text = "Not Using Selected Double Lug"
        Me.LabelGradient1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBackGround
        '
        Me.lblBackGround.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblBackGround.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBackGround.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBackGround.GradientColorOne = System.Drawing.Color.DarkGoldenrod
        Me.lblBackGround.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblBackGround.Location = New System.Drawing.Point(3, 9)
        Me.lblBackGround.Name = "lblBackGround"
        Me.lblBackGround.Size = New System.Drawing.Size(578, 507)
        Me.lblBackGround.TabIndex = 120
        Me.lblBackGround.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlDLThreadedNo
        '
        Me.pnlDLThreadedNo.BackColor = System.Drawing.Color.Black
        Me.pnlDLThreadedNo.Controls.Add(Me.btnDLThreadedNotFound)
        Me.pnlDLThreadedNo.Controls.Add(Me.LabelGradient5)
        Me.pnlDLThreadedNo.Location = New System.Drawing.Point(3, 3)
        Me.pnlDLThreadedNo.Name = "pnlDLThreadedNo"
        Me.pnlDLThreadedNo.Size = New System.Drawing.Size(824, 538)
        Me.pnlDLThreadedNo.TabIndex = 2
        '
        'btnDLThreadedNotFound
        '
        Me.btnDLThreadedNotFound.BackColor = System.Drawing.Color.Ivory
        Me.btnDLThreadedNotFound.Enabled = False
        Me.btnDLThreadedNotFound.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDLThreadedNotFound.Location = New System.Drawing.Point(280, 227)
        Me.btnDLThreadedNotFound.Name = "btnDLThreadedNotFound"
        Me.btnDLThreadedNotFound.Size = New System.Drawing.Size(264, 80)
        Me.btnDLThreadedNotFound.TabIndex = 147
        Me.btnDLThreadedNotFound.Text = "Matching Double Lug Threaded not found" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click Next Button To Access Welded "
        Me.btnDLThreadedNotFound.UseVisualStyleBackColor = False
        '
        'LabelGradient5
        '
        Me.LabelGradient5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LabelGradient5.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient5.GradientColorOne = System.Drawing.Color.DarkGoldenrod
        Me.LabelGradient5.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient5.Location = New System.Drawing.Point(271, 218)
        Me.LabelGradient5.Name = "LabelGradient5"
        Me.LabelGradient5.Size = New System.Drawing.Size(283, 100)
        Me.LabelGradient5.TabIndex = 149
        Me.LabelGradient5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmREDLThreaded
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1200, 900)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblDLHeading)
        Me.Controls.Add(Me.LabelGradient4)
        Me.Controls.Add(Me.LabelGradient3)
        Me.Controls.Add(Me.LabelGradient2)
        Me.Controls.Add(Me.pnlREDLThreaded_YesNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmREDLThreaded"
        Me.Text = "REDLThreaded"
        Me.pnlREDLThreaded_YesNo.ResumeLayout(False)
        Me.pnlDLThreadedYes.ResumeLayout(False)
        Me.grbREDLThreadedMatched.ResumeLayout(False)
        Me.grbREDLThreadedMatched.PerformLayout()
        CType(Me.picDLThreaded, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbUsingSelectedDLThreaded.ResumeLayout(False)
        Me.grbUsingSelectedDLThreaded.PerformLayout()
        Me.grbNotUsingSelectedDoubleLug.ResumeLayout(False)
        Me.pnlDLThreadedNo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblDLHeading As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient4 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient3 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient2 As LabelGradient.LabelGradient
    Friend WithEvents pnlREDLThreaded_YesNo As System.Windows.Forms.Panel
    Friend WithEvents pnlDLThreadedYes As System.Windows.Forms.Panel
    Friend WithEvents grbUsingSelectedDLThreaded As System.Windows.Forms.GroupBox
    Friend WithEvents rdbNewCastingThreaded As System.Windows.Forms.RadioButton
    Friend WithEvents rdbResizeThreaded As System.Windows.Forms.RadioButton
    Friend WithEvents lblUseSelectedThreadedDoubleLug As LabelGradient.LabelGradient
    Friend WithEvents grbREDLThreadedMatched As System.Windows.Forms.GroupBox
    Friend WithEvents txtRequiredLugGap_Threaded As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtLugGap_Threaded As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblLugGap_Threaded As System.Windows.Forms.Label
    Friend WithEvents lblRequired As System.Windows.Forms.Label
    Friend WithEvents txtSwingClearance_Threaded As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSwingClearance_Threaded As System.Windows.Forms.Label
    Friend WithEvents txtRequiredSwingClearance_Threaded As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredLugThickness_Threaded As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredPinHoleSize_Threaded As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents btnPicInformation As System.Windows.Forms.Button
    Friend WithEvents picDLThreaded As System.Windows.Forms.PictureBox
    Friend WithEvents txtLugThickness_Threaded As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblLugThickness_Threaded As System.Windows.Forms.Label
    Friend WithEvents txtThreadLength_Threaded As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblThreadLength_Threaded As System.Windows.Forms.Label
    Friend WithEvents txtThreadSize_Threaded As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblThreadSize_Threaded As System.Windows.Forms.Label
    Friend WithEvents txtLugWidth_Threaded As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblLugWidth_Threaded As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleSize_Threaded As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblPinHoleSize_Threaded As System.Windows.Forms.Label
    Friend WithEvents txtCodeNumber_Threaded As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblCodeNumber_Threaded As System.Windows.Forms.Label
    Friend WithEvents lvwDLThreadedDetails As Monarch_WeldedCylinder_01_09_09.clsListViewMIL
    Friend WithEvents lblExistingDoubleLugIndex_RodEnd As LabelGradient.LabelGradient
    Friend WithEvents lblBackGround As LabelGradient.LabelGradient
    Friend WithEvents pnlDLThreadedNo As System.Windows.Forms.Panel
    Friend WithEvents LabelGradient5 As LabelGradient.LabelGradient
    Friend WithEvents btnDLThreadedNotFound As System.Windows.Forms.Button
    Friend WithEvents btnShowWeldedScreenMessage As System.Windows.Forms.Button
    Friend WithEvents grbNotUsingSelectedDoubleLug As System.Windows.Forms.GroupBox
    Friend WithEvents LabelGradient1 As LabelGradient.LabelGradient
    Friend WithEvents lblUseSelectedSingleLug As System.Windows.Forms.Label
    Friend WithEvents rdbUseSelectedSingleLugNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbUseSelectedSingleLugYes As System.Windows.Forms.RadioButton
    Friend WithEvents lblIsExactMatch As System.Windows.Forms.Label
    Friend WithEvents rdbExactMatchYes As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleTole_Neg As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtPinHoleTole_Pos As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleTole_Neg_Req As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtPinHoleTole_Pos_Req As IFLCustomUILayer.IFLNumericBox
End Class
