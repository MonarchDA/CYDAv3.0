<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBHCastingYes2
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
        Me.grbCastingListView = New System.Windows.Forms.GroupBox
        Me.txtPinHoleTole_Neg_Req = New IFLCustomUILayer.IFLNumericBox
        Me.txtPinHoleTole_Pos_Req = New IFLCustomUILayer.IFLNumericBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPinHoleTole_Neg = New IFLCustomUILayer.IFLNumericBox
        Me.txtPinHoleTole_Pos = New IFLCustomUILayer.IFLNumericBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblUseSelectedSingleLug = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.rdbUseSelectedBHNo = New System.Windows.Forms.RadioButton
        Me.rdbUseSelectedBHYes = New System.Windows.Forms.RadioButton
        Me.lblRequired = New System.Windows.Forms.Label
        Me.txtRequiredAngle2 = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredAngle1 = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredGreaseZerk = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredLugsWidth = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredLugThickness = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredPinHoleSize = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredSwingClearance = New IFLCustomUILayer.IFLNumericBox
        Me.btnPicInformation = New System.Windows.Forms.Button
        Me.picCastingYes = New System.Windows.Forms.PictureBox
        Me.txtLugThickness = New IFLCustomUILayer.IFLNumericBox
        Me.lblLugThickness = New System.Windows.Forms.Label
        Me.txtAngle2 = New IFLCustomUILayer.IFLNumericBox
        Me.lblAngle2 = New System.Windows.Forms.Label
        Me.txtAngle1 = New IFLCustomUILayer.IFLNumericBox
        Me.lblAngle1 = New System.Windows.Forms.Label
        Me.txtGreaseZerk = New IFLCustomUILayer.IFLNumericBox
        Me.lblGreaseZerk = New System.Windows.Forms.Label
        Me.txtLugsWidth = New IFLCustomUILayer.IFLNumericBox
        Me.lblLugWidth = New System.Windows.Forms.Label
        Me.txtPinHoleSize = New IFLCustomUILayer.IFLNumericBox
        Me.lblPinHoleSize = New System.Windows.Forms.Label
        Me.txtSwingClearance = New IFLCustomUILayer.IFLNumericBox
        Me.lblSwingClearance = New System.Windows.Forms.Label
        Me.txtCodeNumber = New IFLCustomUILayer.IFLNumericBox
        Me.lblCodeNumber = New System.Windows.Forms.Label
        Me.lblBHCasting = New LabelGradient.LabelGradient
        Me.grbUsingSelectedBH = New System.Windows.Forms.GroupBox
        Me.rdbNewCasting = New System.Windows.Forms.RadioButton
        Me.rdbResize = New System.Windows.Forms.RadioButton
        Me.rdbExactMatchYes = New System.Windows.Forms.RadioButton
        Me.lblUsingSelectedBH = New LabelGradient.LabelGradient
        Me.grbNotUsingSelectedBHCasting = New System.Windows.Forms.GroupBox
        Me.lblNotUsingSelectedBH = New LabelGradient.LabelGradient
        Me.btnClickNextButton = New System.Windows.Forms.Button
        Me.lblBackGround = New LabelGradient.LabelGradient
        Me.lvwBHListView = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL
        Me.grbCastingListView.SuspendLayout()
        CType(Me.picCastingYes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbUsingSelectedBH.SuspendLayout()
        Me.grbNotUsingSelectedBHCasting.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbCastingListView
        '
        Me.grbCastingListView.BackColor = System.Drawing.Color.Ivory
        Me.grbCastingListView.Controls.Add(Me.txtPinHoleTole_Neg_Req)
        Me.grbCastingListView.Controls.Add(Me.txtPinHoleTole_Pos_Req)
        Me.grbCastingListView.Controls.Add(Me.Label4)
        Me.grbCastingListView.Controls.Add(Me.Label5)
        Me.grbCastingListView.Controls.Add(Me.txtPinHoleTole_Neg)
        Me.grbCastingListView.Controls.Add(Me.txtPinHoleTole_Pos)
        Me.grbCastingListView.Controls.Add(Me.Label6)
        Me.grbCastingListView.Controls.Add(Me.Label3)
        Me.grbCastingListView.Controls.Add(Me.Label2)
        Me.grbCastingListView.Controls.Add(Me.lblUseSelectedSingleLug)
        Me.grbCastingListView.Controls.Add(Me.Label1)
        Me.grbCastingListView.Controls.Add(Me.rdbUseSelectedBHNo)
        Me.grbCastingListView.Controls.Add(Me.rdbUseSelectedBHYes)
        Me.grbCastingListView.Controls.Add(Me.lblRequired)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredAngle2)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredAngle1)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredGreaseZerk)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredLugsWidth)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredLugThickness)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredPinHoleSize)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredSwingClearance)
        Me.grbCastingListView.Controls.Add(Me.btnPicInformation)
        Me.grbCastingListView.Controls.Add(Me.picCastingYes)
        Me.grbCastingListView.Controls.Add(Me.txtLugThickness)
        Me.grbCastingListView.Controls.Add(Me.lblLugThickness)
        Me.grbCastingListView.Controls.Add(Me.txtAngle2)
        Me.grbCastingListView.Controls.Add(Me.lblAngle2)
        Me.grbCastingListView.Controls.Add(Me.txtAngle1)
        Me.grbCastingListView.Controls.Add(Me.lblAngle1)
        Me.grbCastingListView.Controls.Add(Me.txtGreaseZerk)
        Me.grbCastingListView.Controls.Add(Me.lblGreaseZerk)
        Me.grbCastingListView.Controls.Add(Me.txtLugsWidth)
        Me.grbCastingListView.Controls.Add(Me.lblLugWidth)
        Me.grbCastingListView.Controls.Add(Me.txtPinHoleSize)
        Me.grbCastingListView.Controls.Add(Me.lblPinHoleSize)
        Me.grbCastingListView.Controls.Add(Me.txtSwingClearance)
        Me.grbCastingListView.Controls.Add(Me.lblSwingClearance)
        Me.grbCastingListView.Controls.Add(Me.txtCodeNumber)
        Me.grbCastingListView.Controls.Add(Me.lblCodeNumber)
        Me.grbCastingListView.Controls.Add(Me.lvwBHListView)
        Me.grbCastingListView.Controls.Add(Me.lblBHCasting)
        Me.grbCastingListView.Location = New System.Drawing.Point(19, 27)
        Me.grbCastingListView.Name = "grbCastingListView"
        Me.grbCastingListView.Size = New System.Drawing.Size(550, 372)
        Me.grbCastingListView.TabIndex = 147
        Me.grbCastingListView.TabStop = False
        '
        'txtPinHoleTole_Neg_Req
        '
        Me.txtPinHoleTole_Neg_Req.AcceptEnterKeyAsTab = True
        Me.txtPinHoleTole_Neg_Req.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtPinHoleTole_Neg_Req.ApplyIFLColor = True
        Me.txtPinHoleTole_Neg_Req.AssociateLabel = Nothing
        Me.txtPinHoleTole_Neg_Req.DecimalValue = 2
        Me.txtPinHoleTole_Neg_Req.IFLDataTag = Nothing
        Me.txtPinHoleTole_Neg_Req.InvalidInputCharacters = ""
        Me.txtPinHoleTole_Neg_Req.IsAllowNegative = False
        Me.txtPinHoleTole_Neg_Req.LengthValue = 6
        Me.txtPinHoleTole_Neg_Req.Location = New System.Drawing.Point(201, 350)
        Me.txtPinHoleTole_Neg_Req.MaximumValue = 99999
        Me.txtPinHoleTole_Neg_Req.MaxLength = 6
        Me.txtPinHoleTole_Neg_Req.MinimumValue = 0
        Me.txtPinHoleTole_Neg_Req.Name = "txtPinHoleTole_Neg_Req"
        Me.txtPinHoleTole_Neg_Req.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Neg_Req.StatusMessage = ""
        Me.txtPinHoleTole_Neg_Req.StatusObject = Nothing
        Me.txtPinHoleTole_Neg_Req.TabIndex = 180
        Me.txtPinHoleTole_Neg_Req.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPinHoleTole_Pos_Req
        '
        Me.txtPinHoleTole_Pos_Req.AcceptEnterKeyAsTab = True
        Me.txtPinHoleTole_Pos_Req.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtPinHoleTole_Pos_Req.ApplyIFLColor = True
        Me.txtPinHoleTole_Pos_Req.AssociateLabel = Nothing
        Me.txtPinHoleTole_Pos_Req.DecimalValue = 2
        Me.txtPinHoleTole_Pos_Req.IFLDataTag = Nothing
        Me.txtPinHoleTole_Pos_Req.InvalidInputCharacters = ""
        Me.txtPinHoleTole_Pos_Req.IsAllowNegative = False
        Me.txtPinHoleTole_Pos_Req.LengthValue = 6
        Me.txtPinHoleTole_Pos_Req.Location = New System.Drawing.Point(201, 324)
        Me.txtPinHoleTole_Pos_Req.MaximumValue = 99999
        Me.txtPinHoleTole_Pos_Req.MaxLength = 6
        Me.txtPinHoleTole_Pos_Req.MinimumValue = 0
        Me.txtPinHoleTole_Pos_Req.Name = "txtPinHoleTole_Pos_Req"
        Me.txtPinHoleTole_Pos_Req.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Pos_Req.StatusMessage = ""
        Me.txtPinHoleTole_Pos_Req.StatusObject = Nothing
        Me.txtPinHoleTole_Pos_Req.TabIndex = 179
        Me.txtPinHoleTole_Pos_Req.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(113, 353)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 178
        Me.Label4.Text = "-"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(113, 327)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 13)
        Me.Label5.TabIndex = 177
        Me.Label5.Text = "+"
        '
        'txtPinHoleTole_Neg
        '
        Me.txtPinHoleTole_Neg.AcceptEnterKeyAsTab = True
        Me.txtPinHoleTole_Neg.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtPinHoleTole_Neg.ApplyIFLColor = True
        Me.txtPinHoleTole_Neg.AssociateLabel = Nothing
        Me.txtPinHoleTole_Neg.DecimalValue = 2
        Me.txtPinHoleTole_Neg.IFLDataTag = Nothing
        Me.txtPinHoleTole_Neg.InvalidInputCharacters = ""
        Me.txtPinHoleTole_Neg.IsAllowNegative = False
        Me.txtPinHoleTole_Neg.LengthValue = 6
        Me.txtPinHoleTole_Neg.Location = New System.Drawing.Point(129, 350)
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
        Me.txtPinHoleTole_Pos.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtPinHoleTole_Pos.ApplyIFLColor = True
        Me.txtPinHoleTole_Pos.AssociateLabel = Nothing
        Me.txtPinHoleTole_Pos.DecimalValue = 2
        Me.txtPinHoleTole_Pos.IFLDataTag = Nothing
        Me.txtPinHoleTole_Pos.InvalidInputCharacters = ""
        Me.txtPinHoleTole_Pos.IsAllowNegative = False
        Me.txtPinHoleTole_Pos.LengthValue = 6
        Me.txtPinHoleTole_Pos.Location = New System.Drawing.Point(129, 324)
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
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 324)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 175
        Me.Label6.Text = "Pin Hole Tolerance"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(467, 175)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 163
        Me.Label3.Text = "Required"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(394, 175)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 161
        Me.Label2.Text = "Available"
        '
        'lblUseSelectedSingleLug
        '
        Me.lblUseSelectedSingleLug.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblUseSelectedSingleLug.AutoSize = True
        Me.lblUseSelectedSingleLug.Location = New System.Drawing.Point(299, 305)
        Me.lblUseSelectedSingleLug.Name = "lblUseSelectedSingleLug"
        Me.lblUseSelectedSingleLug.Size = New System.Drawing.Size(89, 13)
        Me.lblUseSelectedSingleLug.TabIndex = 142
        Me.lblUseSelectedSingleLug.Text = "Use Selected BH"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(136, 192)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 162
        Me.Label1.Text = "Available"
        '
        'rdbUseSelectedBHNo
        '
        Me.rdbUseSelectedBHNo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.rdbUseSelectedBHNo.AutoSize = True
        Me.rdbUseSelectedBHNo.Location = New System.Drawing.Point(488, 303)
        Me.rdbUseSelectedBHNo.Name = "rdbUseSelectedBHNo"
        Me.rdbUseSelectedBHNo.Size = New System.Drawing.Size(39, 17)
        Me.rdbUseSelectedBHNo.TabIndex = 18
        Me.rdbUseSelectedBHNo.TabStop = True
        Me.rdbUseSelectedBHNo.Text = "No"
        Me.rdbUseSelectedBHNo.UseVisualStyleBackColor = True
        '
        'rdbUseSelectedBHYes
        '
        Me.rdbUseSelectedBHYes.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.rdbUseSelectedBHYes.AutoSize = True
        Me.rdbUseSelectedBHYes.Location = New System.Drawing.Point(439, 303)
        Me.rdbUseSelectedBHYes.Name = "rdbUseSelectedBHYes"
        Me.rdbUseSelectedBHYes.Size = New System.Drawing.Size(43, 17)
        Me.rdbUseSelectedBHYes.TabIndex = 17
        Me.rdbUseSelectedBHYes.TabStop = True
        Me.rdbUseSelectedBHYes.Text = "Yes"
        Me.rdbUseSelectedBHYes.UseVisualStyleBackColor = True
        '
        'lblRequired
        '
        Me.lblRequired.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblRequired.AutoSize = True
        Me.lblRequired.Location = New System.Drawing.Point(202, 192)
        Me.lblRequired.Name = "lblRequired"
        Me.lblRequired.Size = New System.Drawing.Size(50, 13)
        Me.lblRequired.TabIndex = 141
        Me.lblRequired.Text = "Required"
        '
        'txtRequiredAngle2
        '
        Me.txtRequiredAngle2.AcceptEnterKeyAsTab = True
        Me.txtRequiredAngle2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtRequiredAngle2.ApplyIFLColor = True
        Me.txtRequiredAngle2.AssociateLabel = Nothing
        Me.txtRequiredAngle2.DecimalValue = 2
        Me.txtRequiredAngle2.IFLDataTag = Nothing
        Me.txtRequiredAngle2.InvalidInputCharacters = ""
        Me.txtRequiredAngle2.IsAllowNegative = False
        Me.txtRequiredAngle2.LengthValue = 6
        Me.txtRequiredAngle2.Location = New System.Drawing.Point(459, 274)
        Me.txtRequiredAngle2.MaximumValue = 99999
        Me.txtRequiredAngle2.MaxLength = 6
        Me.txtRequiredAngle2.MinimumValue = 0
        Me.txtRequiredAngle2.Name = "txtRequiredAngle2"
        Me.txtRequiredAngle2.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredAngle2.StatusMessage = ""
        Me.txtRequiredAngle2.StatusObject = Nothing
        Me.txtRequiredAngle2.TabIndex = 140
        Me.txtRequiredAngle2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredAngle1
        '
        Me.txtRequiredAngle1.AcceptEnterKeyAsTab = True
        Me.txtRequiredAngle1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtRequiredAngle1.ApplyIFLColor = True
        Me.txtRequiredAngle1.AssociateLabel = Nothing
        Me.txtRequiredAngle1.DecimalValue = 2
        Me.txtRequiredAngle1.IFLDataTag = Nothing
        Me.txtRequiredAngle1.InvalidInputCharacters = ""
        Me.txtRequiredAngle1.IsAllowNegative = False
        Me.txtRequiredAngle1.LengthValue = 6
        Me.txtRequiredAngle1.Location = New System.Drawing.Point(459, 245)
        Me.txtRequiredAngle1.MaximumValue = 99999
        Me.txtRequiredAngle1.MaxLength = 6
        Me.txtRequiredAngle1.MinimumValue = 0
        Me.txtRequiredAngle1.Name = "txtRequiredAngle1"
        Me.txtRequiredAngle1.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredAngle1.StatusMessage = ""
        Me.txtRequiredAngle1.StatusObject = Nothing
        Me.txtRequiredAngle1.TabIndex = 139
        Me.txtRequiredAngle1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredGreaseZerk
        '
        Me.txtRequiredGreaseZerk.AcceptEnterKeyAsTab = True
        Me.txtRequiredGreaseZerk.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtRequiredGreaseZerk.ApplyIFLColor = True
        Me.txtRequiredGreaseZerk.AssociateLabel = Nothing
        Me.txtRequiredGreaseZerk.DecimalValue = 2
        Me.txtRequiredGreaseZerk.IFLDataTag = Nothing
        Me.txtRequiredGreaseZerk.InvalidInputCharacters = ""
        Me.txtRequiredGreaseZerk.IsAllowNegative = False
        Me.txtRequiredGreaseZerk.LengthValue = 6
        Me.txtRequiredGreaseZerk.Location = New System.Drawing.Point(459, 216)
        Me.txtRequiredGreaseZerk.MaximumValue = 99999
        Me.txtRequiredGreaseZerk.MaxLength = 6
        Me.txtRequiredGreaseZerk.MinimumValue = 0
        Me.txtRequiredGreaseZerk.Name = "txtRequiredGreaseZerk"
        Me.txtRequiredGreaseZerk.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredGreaseZerk.StatusMessage = ""
        Me.txtRequiredGreaseZerk.StatusObject = Nothing
        Me.txtRequiredGreaseZerk.TabIndex = 138
        Me.txtRequiredGreaseZerk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredLugsWidth
        '
        Me.txtRequiredLugsWidth.AcceptEnterKeyAsTab = True
        Me.txtRequiredLugsWidth.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtRequiredLugsWidth.ApplyIFLColor = True
        Me.txtRequiredLugsWidth.AssociateLabel = Nothing
        Me.txtRequiredLugsWidth.DecimalValue = 2
        Me.txtRequiredLugsWidth.IFLDataTag = Nothing
        Me.txtRequiredLugsWidth.InvalidInputCharacters = ""
        Me.txtRequiredLugsWidth.IsAllowNegative = False
        Me.txtRequiredLugsWidth.LengthValue = 6
        Me.txtRequiredLugsWidth.Location = New System.Drawing.Point(459, 191)
        Me.txtRequiredLugsWidth.MaximumValue = 99999
        Me.txtRequiredLugsWidth.MaxLength = 6
        Me.txtRequiredLugsWidth.MinimumValue = 0
        Me.txtRequiredLugsWidth.Name = "txtRequiredLugsWidth"
        Me.txtRequiredLugsWidth.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredLugsWidth.StatusMessage = ""
        Me.txtRequiredLugsWidth.StatusObject = Nothing
        Me.txtRequiredLugsWidth.TabIndex = 137
        Me.txtRequiredLugsWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredLugThickness
        '
        Me.txtRequiredLugThickness.AcceptEnterKeyAsTab = True
        Me.txtRequiredLugThickness.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtRequiredLugThickness.ApplyIFLColor = True
        Me.txtRequiredLugThickness.AssociateLabel = Nothing
        Me.txtRequiredLugThickness.DecimalValue = 2
        Me.txtRequiredLugThickness.IFLDataTag = Nothing
        Me.txtRequiredLugThickness.InvalidInputCharacters = ""
        Me.txtRequiredLugThickness.IsAllowNegative = False
        Me.txtRequiredLugThickness.LengthValue = 6
        Me.txtRequiredLugThickness.Location = New System.Drawing.Point(201, 270)
        Me.txtRequiredLugThickness.MaximumValue = 99999
        Me.txtRequiredLugThickness.MaxLength = 6
        Me.txtRequiredLugThickness.MinimumValue = 0
        Me.txtRequiredLugThickness.Name = "txtRequiredLugThickness"
        Me.txtRequiredLugThickness.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredLugThickness.StatusMessage = ""
        Me.txtRequiredLugThickness.StatusObject = Nothing
        Me.txtRequiredLugThickness.TabIndex = 134
        Me.txtRequiredLugThickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredPinHoleSize
        '
        Me.txtRequiredPinHoleSize.AcceptEnterKeyAsTab = True
        Me.txtRequiredPinHoleSize.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtRequiredPinHoleSize.ApplyIFLColor = True
        Me.txtRequiredPinHoleSize.AssociateLabel = Nothing
        Me.txtRequiredPinHoleSize.DecimalValue = 2
        Me.txtRequiredPinHoleSize.IFLDataTag = Nothing
        Me.txtRequiredPinHoleSize.InvalidInputCharacters = ""
        Me.txtRequiredPinHoleSize.IsAllowNegative = False
        Me.txtRequiredPinHoleSize.LengthValue = 6
        Me.txtRequiredPinHoleSize.Location = New System.Drawing.Point(201, 299)
        Me.txtRequiredPinHoleSize.MaximumValue = 99999
        Me.txtRequiredPinHoleSize.MaxLength = 6
        Me.txtRequiredPinHoleSize.MinimumValue = 0
        Me.txtRequiredPinHoleSize.Name = "txtRequiredPinHoleSize"
        Me.txtRequiredPinHoleSize.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredPinHoleSize.StatusMessage = ""
        Me.txtRequiredPinHoleSize.StatusObject = Nothing
        Me.txtRequiredPinHoleSize.TabIndex = 135
        Me.txtRequiredPinHoleSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredSwingClearance
        '
        Me.txtRequiredSwingClearance.AcceptEnterKeyAsTab = True
        Me.txtRequiredSwingClearance.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtRequiredSwingClearance.ApplyIFLColor = True
        Me.txtRequiredSwingClearance.AssociateLabel = Nothing
        Me.txtRequiredSwingClearance.DecimalValue = 2
        Me.txtRequiredSwingClearance.IFLDataTag = Nothing
        Me.txtRequiredSwingClearance.InvalidInputCharacters = ""
        Me.txtRequiredSwingClearance.IsAllowNegative = False
        Me.txtRequiredSwingClearance.LengthValue = 6
        Me.txtRequiredSwingClearance.Location = New System.Drawing.Point(201, 241)
        Me.txtRequiredSwingClearance.MaximumValue = 99999
        Me.txtRequiredSwingClearance.MaxLength = 6
        Me.txtRequiredSwingClearance.MinimumValue = 0
        Me.txtRequiredSwingClearance.Name = "txtRequiredSwingClearance"
        Me.txtRequiredSwingClearance.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredSwingClearance.StatusMessage = ""
        Me.txtRequiredSwingClearance.StatusObject = Nothing
        Me.txtRequiredSwingClearance.TabIndex = 133
        Me.txtRequiredSwingClearance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnPicInformation
        '
        Me.btnPicInformation.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnPicInformation.Enabled = False
        Me.btnPicInformation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPicInformation.Location = New System.Drawing.Point(415, 119)
        Me.btnPicInformation.Name = "btnPicInformation"
        Me.btnPicInformation.Size = New System.Drawing.Size(95, 23)
        Me.btnPicInformation.TabIndex = 131
        Me.btnPicInformation.Text = "Show Image"
        Me.btnPicInformation.UseVisualStyleBackColor = True
        '
        'picCastingYes
        '
        Me.picCastingYes.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.picCastingYes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picCastingYes.Location = New System.Drawing.Point(397, 40)
        Me.picCastingYes.Name = "picCastingYes"
        Me.picCastingYes.Size = New System.Drawing.Size(135, 122)
        Me.picCastingYes.TabIndex = 130
        Me.picCastingYes.TabStop = False
        '
        'txtLugThickness
        '
        Me.txtLugThickness.AcceptEnterKeyAsTab = True
        Me.txtLugThickness.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtLugThickness.ApplyIFLColor = True
        Me.txtLugThickness.AssociateLabel = Nothing
        Me.txtLugThickness.DecimalValue = 2
        Me.txtLugThickness.IFLDataTag = Nothing
        Me.txtLugThickness.InvalidInputCharacters = ""
        Me.txtLugThickness.IsAllowNegative = False
        Me.txtLugThickness.LengthValue = 6
        Me.txtLugThickness.Location = New System.Drawing.Point(129, 270)
        Me.txtLugThickness.MaximumValue = 99999
        Me.txtLugThickness.MaxLength = 6
        Me.txtLugThickness.MinimumValue = 0
        Me.txtLugThickness.Name = "txtLugThickness"
        Me.txtLugThickness.Size = New System.Drawing.Size(66, 20)
        Me.txtLugThickness.StatusMessage = ""
        Me.txtLugThickness.StatusObject = Nothing
        Me.txtLugThickness.TabIndex = 4
        Me.txtLugThickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLugThickness
        '
        Me.lblLugThickness.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLugThickness.AutoSize = True
        Me.lblLugThickness.Location = New System.Drawing.Point(15, 270)
        Me.lblLugThickness.Name = "lblLugThickness"
        Me.lblLugThickness.Size = New System.Drawing.Size(77, 13)
        Me.lblLugThickness.TabIndex = 128
        Me.lblLugThickness.Text = "Lug Thickness"
        '
        'txtAngle2
        '
        Me.txtAngle2.AcceptEnterKeyAsTab = True
        Me.txtAngle2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtAngle2.ApplyIFLColor = True
        Me.txtAngle2.AssociateLabel = Nothing
        Me.txtAngle2.DecimalValue = 2
        Me.txtAngle2.IFLDataTag = Nothing
        Me.txtAngle2.InvalidInputCharacters = ""
        Me.txtAngle2.IsAllowNegative = False
        Me.txtAngle2.LengthValue = 6
        Me.txtAngle2.Location = New System.Drawing.Point(387, 274)
        Me.txtAngle2.MaximumValue = 99999
        Me.txtAngle2.MaxLength = 6
        Me.txtAngle2.MinimumValue = 0
        Me.txtAngle2.Name = "txtAngle2"
        Me.txtAngle2.Size = New System.Drawing.Size(66, 20)
        Me.txtAngle2.StatusMessage = ""
        Me.txtAngle2.StatusObject = Nothing
        Me.txtAngle2.TabIndex = 10
        Me.txtAngle2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAngle2
        '
        Me.lblAngle2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblAngle2.AutoSize = True
        Me.lblAngle2.Location = New System.Drawing.Point(299, 277)
        Me.lblAngle2.Name = "lblAngle2"
        Me.lblAngle2.Size = New System.Drawing.Size(40, 13)
        Me.lblAngle2.TabIndex = 126
        Me.lblAngle2.Text = "Angle2"
        '
        'txtAngle1
        '
        Me.txtAngle1.AcceptEnterKeyAsTab = True
        Me.txtAngle1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtAngle1.ApplyIFLColor = True
        Me.txtAngle1.AssociateLabel = Nothing
        Me.txtAngle1.DecimalValue = 2
        Me.txtAngle1.IFLDataTag = Nothing
        Me.txtAngle1.InvalidInputCharacters = ""
        Me.txtAngle1.IsAllowNegative = False
        Me.txtAngle1.LengthValue = 6
        Me.txtAngle1.Location = New System.Drawing.Point(387, 245)
        Me.txtAngle1.MaximumValue = 99999
        Me.txtAngle1.MaxLength = 6
        Me.txtAngle1.MinimumValue = 0
        Me.txtAngle1.Name = "txtAngle1"
        Me.txtAngle1.Size = New System.Drawing.Size(66, 20)
        Me.txtAngle1.StatusMessage = ""
        Me.txtAngle1.StatusObject = Nothing
        Me.txtAngle1.TabIndex = 9
        Me.txtAngle1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAngle1
        '
        Me.lblAngle1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblAngle1.AutoSize = True
        Me.lblAngle1.Location = New System.Drawing.Point(299, 248)
        Me.lblAngle1.Name = "lblAngle1"
        Me.lblAngle1.Size = New System.Drawing.Size(40, 13)
        Me.lblAngle1.TabIndex = 124
        Me.lblAngle1.Text = "Angle1"
        '
        'txtGreaseZerk
        '
        Me.txtGreaseZerk.AcceptEnterKeyAsTab = True
        Me.txtGreaseZerk.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtGreaseZerk.ApplyIFLColor = True
        Me.txtGreaseZerk.AssociateLabel = Nothing
        Me.txtGreaseZerk.DecimalValue = 2
        Me.txtGreaseZerk.IFLDataTag = Nothing
        Me.txtGreaseZerk.InvalidInputCharacters = ""
        Me.txtGreaseZerk.IsAllowNegative = False
        Me.txtGreaseZerk.LengthValue = 6
        Me.txtGreaseZerk.Location = New System.Drawing.Point(387, 216)
        Me.txtGreaseZerk.MaximumValue = 99999
        Me.txtGreaseZerk.MaxLength = 6
        Me.txtGreaseZerk.MinimumValue = 0
        Me.txtGreaseZerk.Name = "txtGreaseZerk"
        Me.txtGreaseZerk.Size = New System.Drawing.Size(66, 20)
        Me.txtGreaseZerk.StatusMessage = ""
        Me.txtGreaseZerk.StatusObject = Nothing
        Me.txtGreaseZerk.TabIndex = 8
        Me.txtGreaseZerk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblGreaseZerk
        '
        Me.lblGreaseZerk.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblGreaseZerk.AutoSize = True
        Me.lblGreaseZerk.Location = New System.Drawing.Point(299, 219)
        Me.lblGreaseZerk.Name = "lblGreaseZerk"
        Me.lblGreaseZerk.Size = New System.Drawing.Size(85, 13)
        Me.lblGreaseZerk.TabIndex = 122
        Me.lblGreaseZerk.Text = "Grease Zerk Qty"
        '
        'txtLugsWidth
        '
        Me.txtLugsWidth.AcceptEnterKeyAsTab = True
        Me.txtLugsWidth.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtLugsWidth.ApplyIFLColor = True
        Me.txtLugsWidth.AssociateLabel = Nothing
        Me.txtLugsWidth.DecimalValue = 2
        Me.txtLugsWidth.IFLDataTag = Nothing
        Me.txtLugsWidth.InvalidInputCharacters = ""
        Me.txtLugsWidth.IsAllowNegative = False
        Me.txtLugsWidth.LengthValue = 6
        Me.txtLugsWidth.Location = New System.Drawing.Point(387, 191)
        Me.txtLugsWidth.MaximumValue = 99999
        Me.txtLugsWidth.MaxLength = 6
        Me.txtLugsWidth.MinimumValue = 0
        Me.txtLugsWidth.Name = "txtLugsWidth"
        Me.txtLugsWidth.Size = New System.Drawing.Size(66, 20)
        Me.txtLugsWidth.StatusMessage = ""
        Me.txtLugsWidth.StatusObject = Nothing
        Me.txtLugsWidth.TabIndex = 7
        Me.txtLugsWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLugWidth
        '
        Me.lblLugWidth.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblLugWidth.AutoSize = True
        Me.lblLugWidth.Location = New System.Drawing.Point(299, 194)
        Me.lblLugWidth.Name = "lblLugWidth"
        Me.lblLugWidth.Size = New System.Drawing.Size(61, 13)
        Me.lblLugWidth.TabIndex = 120
        Me.lblLugWidth.Text = "Lugs Width"
        '
        'txtPinHoleSize
        '
        Me.txtPinHoleSize.AcceptEnterKeyAsTab = True
        Me.txtPinHoleSize.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtPinHoleSize.ApplyIFLColor = True
        Me.txtPinHoleSize.AssociateLabel = Nothing
        Me.txtPinHoleSize.DecimalValue = 2
        Me.txtPinHoleSize.IFLDataTag = Nothing
        Me.txtPinHoleSize.InvalidInputCharacters = ""
        Me.txtPinHoleSize.IsAllowNegative = False
        Me.txtPinHoleSize.LengthValue = 6
        Me.txtPinHoleSize.Location = New System.Drawing.Point(129, 299)
        Me.txtPinHoleSize.MaximumValue = 99999
        Me.txtPinHoleSize.MaxLength = 6
        Me.txtPinHoleSize.MinimumValue = 0
        Me.txtPinHoleSize.Name = "txtPinHoleSize"
        Me.txtPinHoleSize.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleSize.StatusMessage = ""
        Me.txtPinHoleSize.StatusObject = Nothing
        Me.txtPinHoleSize.TabIndex = 5
        Me.txtPinHoleSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPinHoleSize
        '
        Me.lblPinHoleSize.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblPinHoleSize.AutoSize = True
        Me.lblPinHoleSize.Location = New System.Drawing.Point(15, 299)
        Me.lblPinHoleSize.Name = "lblPinHoleSize"
        Me.lblPinHoleSize.Size = New System.Drawing.Size(70, 13)
        Me.lblPinHoleSize.TabIndex = 116
        Me.lblPinHoleSize.Text = "Pin Hole Size"
        '
        'txtSwingClearance
        '
        Me.txtSwingClearance.AcceptEnterKeyAsTab = True
        Me.txtSwingClearance.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtSwingClearance.ApplyIFLColor = True
        Me.txtSwingClearance.AssociateLabel = Nothing
        Me.txtSwingClearance.DecimalValue = 2
        Me.txtSwingClearance.IFLDataTag = Nothing
        Me.txtSwingClearance.InvalidInputCharacters = ""
        Me.txtSwingClearance.IsAllowNegative = False
        Me.txtSwingClearance.LengthValue = 6
        Me.txtSwingClearance.Location = New System.Drawing.Point(129, 241)
        Me.txtSwingClearance.MaximumValue = 99999
        Me.txtSwingClearance.MaxLength = 6
        Me.txtSwingClearance.MinimumValue = 0
        Me.txtSwingClearance.Name = "txtSwingClearance"
        Me.txtSwingClearance.Size = New System.Drawing.Size(66, 20)
        Me.txtSwingClearance.StatusMessage = ""
        Me.txtSwingClearance.StatusObject = Nothing
        Me.txtSwingClearance.TabIndex = 3
        Me.txtSwingClearance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSwingClearance
        '
        Me.lblSwingClearance.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblSwingClearance.AutoSize = True
        Me.lblSwingClearance.Location = New System.Drawing.Point(15, 241)
        Me.lblSwingClearance.Name = "lblSwingClearance"
        Me.lblSwingClearance.Size = New System.Drawing.Size(87, 13)
        Me.lblSwingClearance.TabIndex = 114
        Me.lblSwingClearance.Text = "Swing Clearance"
        '
        'txtCodeNumber
        '
        Me.txtCodeNumber.AcceptEnterKeyAsTab = True
        Me.txtCodeNumber.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCodeNumber.ApplyIFLColor = True
        Me.txtCodeNumber.AssociateLabel = Nothing
        Me.txtCodeNumber.DecimalValue = 2
        Me.txtCodeNumber.IFLDataTag = Nothing
        Me.txtCodeNumber.InvalidInputCharacters = ""
        Me.txtCodeNumber.IsAllowNegative = False
        Me.txtCodeNumber.LengthValue = 6
        Me.txtCodeNumber.Location = New System.Drawing.Point(129, 212)
        Me.txtCodeNumber.MaximumValue = 99999
        Me.txtCodeNumber.MaxLength = 6
        Me.txtCodeNumber.MinimumValue = 0
        Me.txtCodeNumber.Name = "txtCodeNumber"
        Me.txtCodeNumber.Size = New System.Drawing.Size(66, 20)
        Me.txtCodeNumber.StatusMessage = ""
        Me.txtCodeNumber.StatusObject = Nothing
        Me.txtCodeNumber.TabIndex = 2
        Me.txtCodeNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCodeNumber
        '
        Me.lblCodeNumber.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblCodeNumber.AutoSize = True
        Me.lblCodeNumber.Location = New System.Drawing.Point(15, 212)
        Me.lblCodeNumber.Name = "lblCodeNumber"
        Me.lblCodeNumber.Size = New System.Drawing.Size(72, 13)
        Me.lblCodeNumber.TabIndex = 112
        Me.lblCodeNumber.Text = "Code Number"
        '
        'lblBHCasting
        '
        Me.lblBHCasting.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblBHCasting.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBHCasting.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBHCasting.GradientColorOne = System.Drawing.Color.Olive
        Me.lblBHCasting.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblBHCasting.Location = New System.Drawing.Point(-3, 0)
        Me.lblBHCasting.Name = "lblBHCasting"
        Me.lblBHCasting.Size = New System.Drawing.Size(553, 19)
        Me.lblBHCasting.TabIndex = 110
        Me.lblBHCasting.Text = "Existing BH Casting Details2"
        Me.lblBHCasting.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grbUsingSelectedBH
        '
        Me.grbUsingSelectedBH.BackColor = System.Drawing.Color.Ivory
        Me.grbUsingSelectedBH.Controls.Add(Me.rdbNewCasting)
        Me.grbUsingSelectedBH.Controls.Add(Me.rdbResize)
        Me.grbUsingSelectedBH.Controls.Add(Me.rdbExactMatchYes)
        Me.grbUsingSelectedBH.Controls.Add(Me.lblUsingSelectedBH)
        Me.grbUsingSelectedBH.Location = New System.Drawing.Point(20, 405)
        Me.grbUsingSelectedBH.Name = "grbUsingSelectedBH"
        Me.grbUsingSelectedBH.Size = New System.Drawing.Size(549, 114)
        Me.grbUsingSelectedBH.TabIndex = 148
        Me.grbUsingSelectedBH.TabStop = False
        '
        'rdbNewCasting
        '
        Me.rdbNewCasting.AutoSize = True
        Me.rdbNewCasting.Location = New System.Drawing.Point(311, 59)
        Me.rdbNewCasting.Name = "rdbNewCasting"
        Me.rdbNewCasting.Size = New System.Drawing.Size(85, 17)
        Me.rdbNewCasting.TabIndex = 16
        Me.rdbNewCasting.TabStop = True
        Me.rdbNewCasting.Text = "New Casting"
        Me.rdbNewCasting.UseVisualStyleBackColor = True
        '
        'rdbResize
        '
        Me.rdbResize.AutoSize = True
        Me.rdbResize.Location = New System.Drawing.Point(226, 59)
        Me.rdbResize.Name = "rdbResize"
        Me.rdbResize.Size = New System.Drawing.Size(57, 17)
        Me.rdbResize.TabIndex = 15
        Me.rdbResize.TabStop = True
        Me.rdbResize.Text = "Resize"
        Me.rdbResize.UseVisualStyleBackColor = True
        '
        'rdbExactMatchYes
        '
        Me.rdbExactMatchYes.AutoSize = True
        Me.rdbExactMatchYes.Location = New System.Drawing.Point(116, 59)
        Me.rdbExactMatchYes.Name = "rdbExactMatchYes"
        Me.rdbExactMatchYes.Size = New System.Drawing.Size(76, 17)
        Me.rdbExactMatchYes.TabIndex = 143
        Me.rdbExactMatchYes.TabStop = True
        Me.rdbExactMatchYes.Text = "Use as it is"
        Me.rdbExactMatchYes.UseVisualStyleBackColor = True
        '
        'lblUsingSelectedBH
        '
        Me.lblUsingSelectedBH.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblUsingSelectedBH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsingSelectedBH.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUsingSelectedBH.GradientColorOne = System.Drawing.Color.Olive
        Me.lblUsingSelectedBH.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblUsingSelectedBH.Location = New System.Drawing.Point(-4, 2)
        Me.lblUsingSelectedBH.Name = "lblUsingSelectedBH"
        Me.lblUsingSelectedBH.Size = New System.Drawing.Size(551, 19)
        Me.lblUsingSelectedBH.TabIndex = 111
        Me.lblUsingSelectedBH.Text = "Using Selected BH"
        Me.lblUsingSelectedBH.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grbNotUsingSelectedBHCasting
        '
        Me.grbNotUsingSelectedBHCasting.BackColor = System.Drawing.Color.Ivory
        Me.grbNotUsingSelectedBHCasting.Controls.Add(Me.lblNotUsingSelectedBH)
        Me.grbNotUsingSelectedBHCasting.Controls.Add(Me.btnClickNextButton)
        Me.grbNotUsingSelectedBHCasting.Location = New System.Drawing.Point(19, 407)
        Me.grbNotUsingSelectedBHCasting.Name = "grbNotUsingSelectedBHCasting"
        Me.grbNotUsingSelectedBHCasting.Size = New System.Drawing.Size(550, 114)
        Me.grbNotUsingSelectedBHCasting.TabIndex = 150
        Me.grbNotUsingSelectedBHCasting.TabStop = False
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
        Me.lblNotUsingSelectedBH.Size = New System.Drawing.Size(562, 19)
        Me.lblNotUsingSelectedBH.TabIndex = 111
        Me.lblNotUsingSelectedBH.Text = "Not Using Selected Single Lug"
        Me.lblNotUsingSelectedBH.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnClickNextButton
        '
        Me.btnClickNextButton.BackColor = System.Drawing.Color.Ivory
        Me.btnClickNextButton.Enabled = False
        Me.btnClickNextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClickNextButton.Location = New System.Drawing.Point(192, 50)
        Me.btnClickNextButton.Name = "btnClickNextButton"
        Me.btnClickNextButton.Size = New System.Drawing.Size(158, 34)
        Me.btnClickNextButton.TabIndex = 116
        Me.btnClickNextButton.Text = "Click Next Button"
        Me.btnClickNextButton.UseVisualStyleBackColor = False
        '
        'lblBackGround
        '
        Me.lblBackGround.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblBackGround.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBackGround.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBackGround.GradientColorOne = System.Drawing.Color.DarkGoldenrod
        Me.lblBackGround.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblBackGround.Location = New System.Drawing.Point(1, 9)
        Me.lblBackGround.Name = "lblBackGround"
        Me.lblBackGround.Size = New System.Drawing.Size(617, 529)
        Me.lblBackGround.TabIndex = 149
        Me.lblBackGround.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lvwBHListView
        '
        Me.lvwBHListView.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lvwBHListView.FullRowSelect = True
        Me.lvwBHListView.GridLines = True
        Me.lvwBHListView.Location = New System.Drawing.Point(18, 33)
        Me.lvwBHListView.MultiSelect = False
        Me.lvwBHListView.Name = "lvwBHListView"
        Me.lvwBHListView.Scrollable = False
        Me.lvwBHListView.Size = New System.Drawing.Size(369, 136)
        Me.lvwBHListView.TabIndex = 1
        Me.lvwBHListView.UseCompatibleStateImageBehavior = False
        Me.lvwBHListView.View = System.Windows.Forms.View.Details
        '
        'frmBHCastingYes2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(900, 650)
        Me.Controls.Add(Me.grbCastingListView)
        Me.Controls.Add(Me.grbUsingSelectedBH)
        Me.Controls.Add(Me.grbNotUsingSelectedBHCasting)
        Me.Controls.Add(Me.lblBackGround)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmBHCastingYes2"
        Me.Text = "frmBHCastingYes"
        Me.grbCastingListView.ResumeLayout(False)
        Me.grbCastingListView.PerformLayout()
        CType(Me.picCastingYes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbUsingSelectedBH.ResumeLayout(False)
        Me.grbUsingSelectedBH.PerformLayout()
        Me.grbNotUsingSelectedBHCasting.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbCastingListView As System.Windows.Forms.GroupBox
    Friend WithEvents txtPinHoleTole_Neg_Req As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtPinHoleTole_Pos_Req As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleTole_Neg As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtPinHoleTole_Pos As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblUseSelectedSingleLug As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rdbUseSelectedBHNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbUseSelectedBHYes As System.Windows.Forms.RadioButton
    Friend WithEvents lblRequired As System.Windows.Forms.Label
    Friend WithEvents txtRequiredAngle2 As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredAngle1 As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredGreaseZerk As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredLugsWidth As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredLugThickness As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredPinHoleSize As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredSwingClearance As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents btnPicInformation As System.Windows.Forms.Button
    Friend WithEvents picCastingYes As System.Windows.Forms.PictureBox
    Friend WithEvents txtLugThickness As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblLugThickness As System.Windows.Forms.Label
    Friend WithEvents txtAngle2 As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblAngle2 As System.Windows.Forms.Label
    Friend WithEvents txtAngle1 As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblAngle1 As System.Windows.Forms.Label
    Friend WithEvents txtGreaseZerk As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblGreaseZerk As System.Windows.Forms.Label
    Friend WithEvents txtLugsWidth As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblLugWidth As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleSize As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblPinHoleSize As System.Windows.Forms.Label
    Friend WithEvents txtSwingClearance As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSwingClearance As System.Windows.Forms.Label
    Friend WithEvents txtCodeNumber As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblCodeNumber As System.Windows.Forms.Label
    Friend WithEvents lvwBHListView As Monarch_WeldedCylinder_01_09_09.clsListViewMIL
    Friend WithEvents lblBHCasting As LabelGradient.LabelGradient
    Friend WithEvents grbUsingSelectedBH As System.Windows.Forms.GroupBox
    Friend WithEvents rdbNewCasting As System.Windows.Forms.RadioButton
    Friend WithEvents rdbResize As System.Windows.Forms.RadioButton
    Friend WithEvents rdbExactMatchYes As System.Windows.Forms.RadioButton
    Friend WithEvents lblUsingSelectedBH As LabelGradient.LabelGradient
    Friend WithEvents grbNotUsingSelectedBHCasting As System.Windows.Forms.GroupBox
    Friend WithEvents lblNotUsingSelectedBH As LabelGradient.LabelGradient
    Friend WithEvents btnClickNextButton As System.Windows.Forms.Button
    Friend WithEvents lblBackGround As LabelGradient.LabelGradient
End Class
