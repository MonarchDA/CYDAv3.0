<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDLCastingYes
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
        Me.rdbNewCasting = New System.Windows.Forms.RadioButton()
        Me.rdbResize = New System.Windows.Forms.RadioButton()
        Me.grbCastingListView = New System.Windows.Forms.GroupBox()
        Me.txtPinHoleTole_Neg_Req = New IFLCustomUILayer.IFLNumericBox()
        Me.txtPinHoleTole_Pos_Req = New IFLCustomUILayer.IFLNumericBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPinHoleTole_Neg = New IFLCustomUILayer.IFLNumericBox()
        Me.txtPinHoleTole_Pos = New IFLCustomUILayer.IFLNumericBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblUseSelectedSingleLug = New System.Windows.Forms.Label()
        Me.rdbUseSelectedSingleLugNo = New System.Windows.Forms.RadioButton()
        Me.rdbUseSelectedSingleLugYes = New System.Windows.Forms.RadioButton()
        Me.lblRequired = New System.Windows.Forms.Label()
        Me.txtRequiredAngle2 = New IFLCustomUILayer.IFLNumericBox()
        Me.txtRequiredAngle1 = New IFLCustomUILayer.IFLNumericBox()
        Me.txtRequiredGreaseZerk = New IFLCustomUILayer.IFLNumericBox()
        Me.txtRequiredLugsWidth = New IFLCustomUILayer.IFLNumericBox()
        Me.txtRequiredLugThickness = New IFLCustomUILayer.IFLNumericBox()
        Me.txtRequiredLugsGap = New IFLCustomUILayer.IFLNumericBox()
        Me.txtRequiredPinHoleSize = New IFLCustomUILayer.IFLNumericBox()
        Me.txtRequiredSwingClearance = New IFLCustomUILayer.IFLNumericBox()
        Me.btnPicInformation = New System.Windows.Forms.Button()
        Me.picCastingYes = New System.Windows.Forms.PictureBox()
        Me.txtLugThickness = New IFLCustomUILayer.IFLNumericBox()
        Me.lblLugThickness = New System.Windows.Forms.Label()
        Me.txtAngle2 = New IFLCustomUILayer.IFLNumericBox()
        Me.lblAngle2 = New System.Windows.Forms.Label()
        Me.txtAngle1 = New IFLCustomUILayer.IFLNumericBox()
        Me.lblAngle1 = New System.Windows.Forms.Label()
        Me.txtGreaseZerk = New IFLCustomUILayer.IFLNumericBox()
        Me.lblGreaseZerk = New System.Windows.Forms.Label()
        Me.txtLugsWidth = New IFLCustomUILayer.IFLNumericBox()
        Me.lblLugsWidth = New System.Windows.Forms.Label()
        Me.txtLugsGap = New IFLCustomUILayer.IFLNumericBox()
        Me.lblLugsGap = New System.Windows.Forms.Label()
        Me.txtPinHoleSize = New IFLCustomUILayer.IFLNumericBox()
        Me.lblPinHoleSize = New System.Windows.Forms.Label()
        Me.txtSwingClearance = New IFLCustomUILayer.IFLNumericBox()
        Me.lblSwingClearance = New System.Windows.Forms.Label()
        Me.txtCodeNumber = New IFLCustomUILayer.IFLNumericBox()
        Me.lblCodeNumber = New System.Windows.Forms.Label()
        Me.lvwDoubleLugListView = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL()
        Me.lblDoubleLugCasting = New LabelGradient.LabelGradient()
        Me.grbUsingSelectedDoubleLug = New System.Windows.Forms.GroupBox()
        Me.rdbExactMatchYes = New System.Windows.Forms.RadioButton()
        Me.lblUsingSelectedDoubleLug = New LabelGradient.LabelGradient()
        Me.lblBackGround = New LabelGradient.LabelGradient()
        Me.grbNotUsingSelectedDoubleLugCasting = New System.Windows.Forms.GroupBox()
        Me.lblNotUsingSelectedDoubleLug = New LabelGradient.LabelGradient()
        Me.btnClickNextButton = New System.Windows.Forms.Button()
        Me.chkDoubleLugFabricationRequired = New System.Windows.Forms.CheckBox()
        Me.grbCastingListView.SuspendLayout()
        CType(Me.picCastingYes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbUsingSelectedDoubleLug.SuspendLayout()
        Me.grbNotUsingSelectedDoubleLugCasting.SuspendLayout()
        Me.SuspendLayout()
        '
        'rdbNewCasting
        '
        Me.rdbNewCasting.AutoSize = True
        Me.rdbNewCasting.Location = New System.Drawing.Point(342, 40)
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
        Me.rdbResize.Location = New System.Drawing.Point(255, 40)
        Me.rdbResize.Name = "rdbResize"
        Me.rdbResize.Size = New System.Drawing.Size(57, 17)
        Me.rdbResize.TabIndex = 15
        Me.rdbResize.TabStop = True
        Me.rdbResize.Text = "Resize"
        Me.rdbResize.UseVisualStyleBackColor = True
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
        Me.grbCastingListView.Controls.Add(Me.Label1)
        Me.grbCastingListView.Controls.Add(Me.Label2)
        Me.grbCastingListView.Controls.Add(Me.Label3)
        Me.grbCastingListView.Controls.Add(Me.lblUseSelectedSingleLug)
        Me.grbCastingListView.Controls.Add(Me.rdbUseSelectedSingleLugNo)
        Me.grbCastingListView.Controls.Add(Me.rdbUseSelectedSingleLugYes)
        Me.grbCastingListView.Controls.Add(Me.lblRequired)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredAngle2)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredAngle1)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredGreaseZerk)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredLugsWidth)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredLugThickness)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredLugsGap)
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
        Me.grbCastingListView.Controls.Add(Me.lblLugsWidth)
        Me.grbCastingListView.Controls.Add(Me.txtLugsGap)
        Me.grbCastingListView.Controls.Add(Me.lblLugsGap)
        Me.grbCastingListView.Controls.Add(Me.txtPinHoleSize)
        Me.grbCastingListView.Controls.Add(Me.lblPinHoleSize)
        Me.grbCastingListView.Controls.Add(Me.txtSwingClearance)
        Me.grbCastingListView.Controls.Add(Me.lblSwingClearance)
        Me.grbCastingListView.Controls.Add(Me.txtCodeNumber)
        Me.grbCastingListView.Controls.Add(Me.lblCodeNumber)
        Me.grbCastingListView.Controls.Add(Me.lvwDoubleLugListView)
        Me.grbCastingListView.Controls.Add(Me.lblDoubleLugCasting)
        Me.grbCastingListView.Location = New System.Drawing.Point(30, 29)
        Me.grbCastingListView.Name = "grbCastingListView"
        Me.grbCastingListView.Size = New System.Drawing.Size(543, 393)
        Me.grbCastingListView.TabIndex = 0
        Me.grbCastingListView.TabStop = False
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
        Me.txtPinHoleTole_Neg_Req.Location = New System.Drawing.Point(201, 334)
        Me.txtPinHoleTole_Neg_Req.MaximumValue = 99999.0R
        Me.txtPinHoleTole_Neg_Req.MaxLength = 6
        Me.txtPinHoleTole_Neg_Req.MinimumValue = 0.0R
        Me.txtPinHoleTole_Neg_Req.Name = "txtPinHoleTole_Neg_Req"
        Me.txtPinHoleTole_Neg_Req.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Neg_Req.StatusMessage = ""
        Me.txtPinHoleTole_Neg_Req.StatusObject = Nothing
        Me.txtPinHoleTole_Neg_Req.TabIndex = 175
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
        Me.txtPinHoleTole_Pos_Req.Location = New System.Drawing.Point(201, 308)
        Me.txtPinHoleTole_Pos_Req.MaximumValue = 99999.0R
        Me.txtPinHoleTole_Pos_Req.MaxLength = 6
        Me.txtPinHoleTole_Pos_Req.MinimumValue = 0.0R
        Me.txtPinHoleTole_Pos_Req.Name = "txtPinHoleTole_Pos_Req"
        Me.txtPinHoleTole_Pos_Req.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Pos_Req.StatusMessage = ""
        Me.txtPinHoleTole_Pos_Req.StatusObject = Nothing
        Me.txtPinHoleTole_Pos_Req.TabIndex = 174
        Me.txtPinHoleTole_Pos_Req.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(113, 337)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 173
        Me.Label4.Text = "-"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(113, 311)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(14, 13)
        Me.Label5.TabIndex = 172
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
        Me.txtPinHoleTole_Neg.Location = New System.Drawing.Point(129, 334)
        Me.txtPinHoleTole_Neg.MaximumValue = 99999.0R
        Me.txtPinHoleTole_Neg.MaxLength = 6
        Me.txtPinHoleTole_Neg.MinimumValue = 0.0R
        Me.txtPinHoleTole_Neg.Name = "txtPinHoleTole_Neg"
        Me.txtPinHoleTole_Neg.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Neg.StatusMessage = ""
        Me.txtPinHoleTole_Neg.StatusObject = Nothing
        Me.txtPinHoleTole_Neg.TabIndex = 171
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
        Me.txtPinHoleTole_Pos.Location = New System.Drawing.Point(129, 308)
        Me.txtPinHoleTole_Pos.MaximumValue = 99999.0R
        Me.txtPinHoleTole_Pos.MaxLength = 6
        Me.txtPinHoleTole_Pos.MinimumValue = 0.0R
        Me.txtPinHoleTole_Pos.Name = "txtPinHoleTole_Pos"
        Me.txtPinHoleTole_Pos.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleTole_Pos.StatusMessage = ""
        Me.txtPinHoleTole_Pos.StatusObject = Nothing
        Me.txtPinHoleTole_Pos.TabIndex = 169
        Me.txtPinHoleTole_Pos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 311)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 170
        Me.Label6.Text = "Pin Hole Tolerance"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(400, 170)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 161
        Me.Label1.Text = "Available"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(135, 166)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 160
        Me.Label2.Text = "Available"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(469, 170)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 146
        Me.Label3.Text = "Required"
        '
        'lblUseSelectedSingleLug
        '
        Me.lblUseSelectedSingleLug.AutoSize = True
        Me.lblUseSelectedSingleLug.Location = New System.Drawing.Point(305, 325)
        Me.lblUseSelectedSingleLug.Name = "lblUseSelectedSingleLug"
        Me.lblUseSelectedSingleLug.Size = New System.Drawing.Size(126, 13)
        Me.lblUseSelectedSingleLug.TabIndex = 145
        Me.lblUseSelectedSingleLug.Text = "Use Selected DoubleLug"
        '
        'rdbUseSelectedSingleLugNo
        '
        Me.rdbUseSelectedSingleLugNo.AutoSize = True
        Me.rdbUseSelectedSingleLugNo.Location = New System.Drawing.Point(494, 323)
        Me.rdbUseSelectedSingleLugNo.Name = "rdbUseSelectedSingleLugNo"
        Me.rdbUseSelectedSingleLugNo.Size = New System.Drawing.Size(39, 17)
        Me.rdbUseSelectedSingleLugNo.TabIndex = 144
        Me.rdbUseSelectedSingleLugNo.TabStop = True
        Me.rdbUseSelectedSingleLugNo.Text = "No"
        Me.rdbUseSelectedSingleLugNo.UseVisualStyleBackColor = True
        '
        'rdbUseSelectedSingleLugYes
        '
        Me.rdbUseSelectedSingleLugYes.AutoSize = True
        Me.rdbUseSelectedSingleLugYes.Location = New System.Drawing.Point(445, 323)
        Me.rdbUseSelectedSingleLugYes.Name = "rdbUseSelectedSingleLugYes"
        Me.rdbUseSelectedSingleLugYes.Size = New System.Drawing.Size(43, 17)
        Me.rdbUseSelectedSingleLugYes.TabIndex = 143
        Me.rdbUseSelectedSingleLugYes.TabStop = True
        Me.rdbUseSelectedSingleLugYes.Text = "Yes"
        Me.rdbUseSelectedSingleLugYes.UseVisualStyleBackColor = True
        '
        'lblRequired
        '
        Me.lblRequired.AutoSize = True
        Me.lblRequired.Location = New System.Drawing.Point(209, 166)
        Me.lblRequired.Name = "lblRequired"
        Me.lblRequired.Size = New System.Drawing.Size(50, 13)
        Me.lblRequired.TabIndex = 141
        Me.lblRequired.Text = "Required"
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
        Me.txtRequiredAngle2.Location = New System.Drawing.Point(464, 286)
        Me.txtRequiredAngle2.MaximumValue = 99999.0R
        Me.txtRequiredAngle2.MaxLength = 6
        Me.txtRequiredAngle2.MinimumValue = 0.0R
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
        Me.txtRequiredAngle1.ApplyIFLColor = True
        Me.txtRequiredAngle1.AssociateLabel = Nothing
        Me.txtRequiredAngle1.DecimalValue = 2
        Me.txtRequiredAngle1.IFLDataTag = Nothing
        Me.txtRequiredAngle1.InvalidInputCharacters = ""
        Me.txtRequiredAngle1.IsAllowNegative = False
        Me.txtRequiredAngle1.LengthValue = 6
        Me.txtRequiredAngle1.Location = New System.Drawing.Point(464, 254)
        Me.txtRequiredAngle1.MaximumValue = 99999.0R
        Me.txtRequiredAngle1.MaxLength = 6
        Me.txtRequiredAngle1.MinimumValue = 0.0R
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
        Me.txtRequiredGreaseZerk.ApplyIFLColor = True
        Me.txtRequiredGreaseZerk.AssociateLabel = Nothing
        Me.txtRequiredGreaseZerk.DecimalValue = 2
        Me.txtRequiredGreaseZerk.IFLDataTag = Nothing
        Me.txtRequiredGreaseZerk.InvalidInputCharacters = ""
        Me.txtRequiredGreaseZerk.IsAllowNegative = False
        Me.txtRequiredGreaseZerk.LengthValue = 6
        Me.txtRequiredGreaseZerk.Location = New System.Drawing.Point(464, 222)
        Me.txtRequiredGreaseZerk.MaximumValue = 99999.0R
        Me.txtRequiredGreaseZerk.MaxLength = 6
        Me.txtRequiredGreaseZerk.MinimumValue = 0.0R
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
        Me.txtRequiredLugsWidth.ApplyIFLColor = True
        Me.txtRequiredLugsWidth.AssociateLabel = Nothing
        Me.txtRequiredLugsWidth.DecimalValue = 2
        Me.txtRequiredLugsWidth.IFLDataTag = Nothing
        Me.txtRequiredLugsWidth.InvalidInputCharacters = ""
        Me.txtRequiredLugsWidth.IsAllowNegative = False
        Me.txtRequiredLugsWidth.LengthValue = 6
        Me.txtRequiredLugsWidth.Location = New System.Drawing.Point(464, 190)
        Me.txtRequiredLugsWidth.MaximumValue = 99999.0R
        Me.txtRequiredLugsWidth.MaxLength = 6
        Me.txtRequiredLugsWidth.MinimumValue = 0.0R
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
        Me.txtRequiredLugThickness.ApplyIFLColor = True
        Me.txtRequiredLugThickness.AssociateLabel = Nothing
        Me.txtRequiredLugThickness.DecimalValue = 2
        Me.txtRequiredLugThickness.IFLDataTag = Nothing
        Me.txtRequiredLugThickness.InvalidInputCharacters = ""
        Me.txtRequiredLugThickness.IsAllowNegative = False
        Me.txtRequiredLugThickness.LengthValue = 6
        Me.txtRequiredLugThickness.Location = New System.Drawing.Point(200, 250)
        Me.txtRequiredLugThickness.MaximumValue = 99999.0R
        Me.txtRequiredLugThickness.MaxLength = 6
        Me.txtRequiredLugThickness.MinimumValue = 0.0R
        Me.txtRequiredLugThickness.Name = "txtRequiredLugThickness"
        Me.txtRequiredLugThickness.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredLugThickness.StatusMessage = ""
        Me.txtRequiredLugThickness.StatusObject = Nothing
        Me.txtRequiredLugThickness.TabIndex = 134
        Me.txtRequiredLugThickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredLugsGap
        '
        Me.txtRequiredLugsGap.AcceptEnterKeyAsTab = True
        Me.txtRequiredLugsGap.ApplyIFLColor = True
        Me.txtRequiredLugsGap.AssociateLabel = Nothing
        Me.txtRequiredLugsGap.DecimalValue = 2
        Me.txtRequiredLugsGap.IFLDataTag = Nothing
        Me.txtRequiredLugsGap.InvalidInputCharacters = ""
        Me.txtRequiredLugsGap.IsAllowNegative = False
        Me.txtRequiredLugsGap.LengthValue = 6
        Me.txtRequiredLugsGap.Location = New System.Drawing.Point(200, 364)
        Me.txtRequiredLugsGap.MaximumValue = 99999.0R
        Me.txtRequiredLugsGap.MaxLength = 6
        Me.txtRequiredLugsGap.MinimumValue = 0.0R
        Me.txtRequiredLugsGap.Name = "txtRequiredLugsGap"
        Me.txtRequiredLugsGap.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredLugsGap.StatusMessage = ""
        Me.txtRequiredLugsGap.StatusObject = Nothing
        Me.txtRequiredLugsGap.TabIndex = 136
        Me.txtRequiredLugsGap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.txtRequiredPinHoleSize.Location = New System.Drawing.Point(201, 282)
        Me.txtRequiredPinHoleSize.MaximumValue = 99999.0R
        Me.txtRequiredPinHoleSize.MaxLength = 6
        Me.txtRequiredPinHoleSize.MinimumValue = 0.0R
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
        Me.txtRequiredSwingClearance.ApplyIFLColor = True
        Me.txtRequiredSwingClearance.AssociateLabel = Nothing
        Me.txtRequiredSwingClearance.DecimalValue = 2
        Me.txtRequiredSwingClearance.IFLDataTag = Nothing
        Me.txtRequiredSwingClearance.InvalidInputCharacters = ""
        Me.txtRequiredSwingClearance.IsAllowNegative = False
        Me.txtRequiredSwingClearance.LengthValue = 6
        Me.txtRequiredSwingClearance.Location = New System.Drawing.Point(200, 218)
        Me.txtRequiredSwingClearance.MaximumValue = 99999.0R
        Me.txtRequiredSwingClearance.MaxLength = 6
        Me.txtRequiredSwingClearance.MinimumValue = 0.0R
        Me.txtRequiredSwingClearance.Name = "txtRequiredSwingClearance"
        Me.txtRequiredSwingClearance.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredSwingClearance.StatusMessage = ""
        Me.txtRequiredSwingClearance.StatusObject = Nothing
        Me.txtRequiredSwingClearance.TabIndex = 133
        Me.txtRequiredSwingClearance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'picCastingYes
        '
        Me.picCastingYes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picCastingYes.Location = New System.Drawing.Point(386, 33)
        Me.picCastingYes.Name = "picCastingYes"
        Me.picCastingYes.Size = New System.Drawing.Size(151, 122)
        Me.picCastingYes.TabIndex = 130
        Me.picCastingYes.TabStop = False
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
        Me.txtLugThickness.Location = New System.Drawing.Point(129, 250)
        Me.txtLugThickness.MaximumValue = 99999.0R
        Me.txtLugThickness.MaxLength = 6
        Me.txtLugThickness.MinimumValue = 0.0R
        Me.txtLugThickness.Name = "txtLugThickness"
        Me.txtLugThickness.Size = New System.Drawing.Size(66, 20)
        Me.txtLugThickness.StatusMessage = ""
        Me.txtLugThickness.StatusObject = Nothing
        Me.txtLugThickness.TabIndex = 4
        Me.txtLugThickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLugThickness
        '
        Me.lblLugThickness.AutoSize = True
        Me.lblLugThickness.Location = New System.Drawing.Point(6, 253)
        Me.lblLugThickness.Name = "lblLugThickness"
        Me.lblLugThickness.Size = New System.Drawing.Size(77, 13)
        Me.lblLugThickness.TabIndex = 128
        Me.lblLugThickness.Text = "Lug Thickness"
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
        Me.txtAngle2.Location = New System.Drawing.Point(392, 286)
        Me.txtAngle2.MaximumValue = 99999.0R
        Me.txtAngle2.MaxLength = 6
        Me.txtAngle2.MinimumValue = 0.0R
        Me.txtAngle2.Name = "txtAngle2"
        Me.txtAngle2.Size = New System.Drawing.Size(66, 20)
        Me.txtAngle2.StatusMessage = ""
        Me.txtAngle2.StatusObject = Nothing
        Me.txtAngle2.TabIndex = 10
        Me.txtAngle2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAngle2
        '
        Me.lblAngle2.AutoSize = True
        Me.lblAngle2.Location = New System.Drawing.Point(305, 289)
        Me.lblAngle2.Name = "lblAngle2"
        Me.lblAngle2.Size = New System.Drawing.Size(40, 13)
        Me.lblAngle2.TabIndex = 126
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
        Me.txtAngle1.Location = New System.Drawing.Point(392, 254)
        Me.txtAngle1.MaximumValue = 99999.0R
        Me.txtAngle1.MaxLength = 6
        Me.txtAngle1.MinimumValue = 0.0R
        Me.txtAngle1.Name = "txtAngle1"
        Me.txtAngle1.Size = New System.Drawing.Size(66, 20)
        Me.txtAngle1.StatusMessage = ""
        Me.txtAngle1.StatusObject = Nothing
        Me.txtAngle1.TabIndex = 9
        Me.txtAngle1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAngle1
        '
        Me.lblAngle1.AutoSize = True
        Me.lblAngle1.Location = New System.Drawing.Point(305, 257)
        Me.lblAngle1.Name = "lblAngle1"
        Me.lblAngle1.Size = New System.Drawing.Size(40, 13)
        Me.lblAngle1.TabIndex = 124
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
        Me.txtGreaseZerk.Location = New System.Drawing.Point(392, 222)
        Me.txtGreaseZerk.MaximumValue = 99999.0R
        Me.txtGreaseZerk.MaxLength = 6
        Me.txtGreaseZerk.MinimumValue = 0.0R
        Me.txtGreaseZerk.Name = "txtGreaseZerk"
        Me.txtGreaseZerk.Size = New System.Drawing.Size(66, 20)
        Me.txtGreaseZerk.StatusMessage = ""
        Me.txtGreaseZerk.StatusObject = Nothing
        Me.txtGreaseZerk.TabIndex = 8
        Me.txtGreaseZerk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblGreaseZerk
        '
        Me.lblGreaseZerk.AutoSize = True
        Me.lblGreaseZerk.Location = New System.Drawing.Point(305, 225)
        Me.lblGreaseZerk.Name = "lblGreaseZerk"
        Me.lblGreaseZerk.Size = New System.Drawing.Size(85, 13)
        Me.lblGreaseZerk.TabIndex = 122
        Me.lblGreaseZerk.Text = "Grease Zerk Qty"
        '
        'txtLugsWidth
        '
        Me.txtLugsWidth.AcceptEnterKeyAsTab = True
        Me.txtLugsWidth.ApplyIFLColor = True
        Me.txtLugsWidth.AssociateLabel = Nothing
        Me.txtLugsWidth.DecimalValue = 2
        Me.txtLugsWidth.IFLDataTag = Nothing
        Me.txtLugsWidth.InvalidInputCharacters = ""
        Me.txtLugsWidth.IsAllowNegative = False
        Me.txtLugsWidth.LengthValue = 6
        Me.txtLugsWidth.Location = New System.Drawing.Point(392, 190)
        Me.txtLugsWidth.MaximumValue = 99999.0R
        Me.txtLugsWidth.MaxLength = 6
        Me.txtLugsWidth.MinimumValue = 0.0R
        Me.txtLugsWidth.Name = "txtLugsWidth"
        Me.txtLugsWidth.Size = New System.Drawing.Size(66, 20)
        Me.txtLugsWidth.StatusMessage = ""
        Me.txtLugsWidth.StatusObject = Nothing
        Me.txtLugsWidth.TabIndex = 7
        Me.txtLugsWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLugsWidth
        '
        Me.lblLugsWidth.AutoSize = True
        Me.lblLugsWidth.Location = New System.Drawing.Point(305, 193)
        Me.lblLugsWidth.Name = "lblLugsWidth"
        Me.lblLugsWidth.Size = New System.Drawing.Size(56, 13)
        Me.lblLugsWidth.TabIndex = 120
        Me.lblLugsWidth.Text = "Lug Width"
        '
        'txtLugsGap
        '
        Me.txtLugsGap.AcceptEnterKeyAsTab = True
        Me.txtLugsGap.ApplyIFLColor = True
        Me.txtLugsGap.AssociateLabel = Nothing
        Me.txtLugsGap.DecimalValue = 2
        Me.txtLugsGap.IFLDataTag = Nothing
        Me.txtLugsGap.InvalidInputCharacters = ""
        Me.txtLugsGap.IsAllowNegative = False
        Me.txtLugsGap.LengthValue = 6
        Me.txtLugsGap.Location = New System.Drawing.Point(128, 364)
        Me.txtLugsGap.MaximumValue = 99999.0R
        Me.txtLugsGap.MaxLength = 6
        Me.txtLugsGap.MinimumValue = 0.0R
        Me.txtLugsGap.Name = "txtLugsGap"
        Me.txtLugsGap.Size = New System.Drawing.Size(66, 20)
        Me.txtLugsGap.StatusMessage = ""
        Me.txtLugsGap.StatusObject = Nothing
        Me.txtLugsGap.TabIndex = 6
        Me.txtLugsGap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLugsGap
        '
        Me.lblLugsGap.AutoSize = True
        Me.lblLugsGap.Location = New System.Drawing.Point(6, 367)
        Me.lblLugsGap.Name = "lblLugsGap"
        Me.lblLugsGap.Size = New System.Drawing.Size(48, 13)
        Me.lblLugsGap.TabIndex = 118
        Me.lblLugsGap.Text = "Lug Gap"
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
        Me.txtPinHoleSize.Location = New System.Drawing.Point(129, 282)
        Me.txtPinHoleSize.MaximumValue = 99999.0R
        Me.txtPinHoleSize.MaxLength = 6
        Me.txtPinHoleSize.MinimumValue = 0.0R
        Me.txtPinHoleSize.Name = "txtPinHoleSize"
        Me.txtPinHoleSize.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleSize.StatusMessage = ""
        Me.txtPinHoleSize.StatusObject = Nothing
        Me.txtPinHoleSize.TabIndex = 5
        Me.txtPinHoleSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPinHoleSize
        '
        Me.lblPinHoleSize.AutoSize = True
        Me.lblPinHoleSize.Location = New System.Drawing.Point(6, 285)
        Me.lblPinHoleSize.Name = "lblPinHoleSize"
        Me.lblPinHoleSize.Size = New System.Drawing.Size(70, 13)
        Me.lblPinHoleSize.TabIndex = 116
        Me.lblPinHoleSize.Text = "Pin Hole Size"
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
        Me.txtSwingClearance.Location = New System.Drawing.Point(129, 218)
        Me.txtSwingClearance.MaximumValue = 99999.0R
        Me.txtSwingClearance.MaxLength = 6
        Me.txtSwingClearance.MinimumValue = 0.0R
        Me.txtSwingClearance.Name = "txtSwingClearance"
        Me.txtSwingClearance.Size = New System.Drawing.Size(66, 20)
        Me.txtSwingClearance.StatusMessage = ""
        Me.txtSwingClearance.StatusObject = Nothing
        Me.txtSwingClearance.TabIndex = 3
        Me.txtSwingClearance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSwingClearance
        '
        Me.lblSwingClearance.AutoSize = True
        Me.lblSwingClearance.Location = New System.Drawing.Point(6, 221)
        Me.lblSwingClearance.Name = "lblSwingClearance"
        Me.lblSwingClearance.Size = New System.Drawing.Size(87, 13)
        Me.lblSwingClearance.TabIndex = 114
        Me.lblSwingClearance.Text = "Swing Clearance"
        '
        'txtCodeNumber
        '
        Me.txtCodeNumber.AcceptEnterKeyAsTab = True
        Me.txtCodeNumber.ApplyIFLColor = True
        Me.txtCodeNumber.AssociateLabel = Nothing
        Me.txtCodeNumber.DecimalValue = 2
        Me.txtCodeNumber.IFLDataTag = Nothing
        Me.txtCodeNumber.InvalidInputCharacters = ""
        Me.txtCodeNumber.IsAllowNegative = False
        Me.txtCodeNumber.LengthValue = 6
        Me.txtCodeNumber.Location = New System.Drawing.Point(129, 186)
        Me.txtCodeNumber.MaximumValue = 99999.0R
        Me.txtCodeNumber.MaxLength = 6
        Me.txtCodeNumber.MinimumValue = 0.0R
        Me.txtCodeNumber.Name = "txtCodeNumber"
        Me.txtCodeNumber.Size = New System.Drawing.Size(66, 20)
        Me.txtCodeNumber.StatusMessage = ""
        Me.txtCodeNumber.StatusObject = Nothing
        Me.txtCodeNumber.TabIndex = 2
        Me.txtCodeNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCodeNumber
        '
        Me.lblCodeNumber.AutoSize = True
        Me.lblCodeNumber.Location = New System.Drawing.Point(6, 189)
        Me.lblCodeNumber.Name = "lblCodeNumber"
        Me.lblCodeNumber.Size = New System.Drawing.Size(72, 13)
        Me.lblCodeNumber.TabIndex = 112
        Me.lblCodeNumber.Text = "Code Number"
        '
        'lvwDoubleLugListView
        '
        Me.lvwDoubleLugListView.FullRowSelect = True
        Me.lvwDoubleLugListView.GridLines = True
        Me.lvwDoubleLugListView.Location = New System.Drawing.Point(6, 33)
        Me.lvwDoubleLugListView.MultiSelect = False
        Me.lvwDoubleLugListView.Name = "lvwDoubleLugListView"
        Me.lvwDoubleLugListView.Scrollable = False
        Me.lvwDoubleLugListView.Size = New System.Drawing.Size(369, 122)
        Me.lvwDoubleLugListView.TabIndex = 1
        Me.lvwDoubleLugListView.UseCompatibleStateImageBehavior = False
        Me.lvwDoubleLugListView.View = System.Windows.Forms.View.Details
        '
        'lblDoubleLugCasting
        '
        Me.lblDoubleLugCasting.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblDoubleLugCasting.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDoubleLugCasting.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDoubleLugCasting.GradientColorOne = System.Drawing.Color.Olive
        Me.lblDoubleLugCasting.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblDoubleLugCasting.Location = New System.Drawing.Point(-3, 0)
        Me.lblDoubleLugCasting.Name = "lblDoubleLugCasting"
        Me.lblDoubleLugCasting.Size = New System.Drawing.Size(546, 19)
        Me.lblDoubleLugCasting.TabIndex = 110
        Me.lblDoubleLugCasting.Text = "Existing Double Lug Casting Details"
        Me.lblDoubleLugCasting.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grbUsingSelectedDoubleLug
        '
        Me.grbUsingSelectedDoubleLug.BackColor = System.Drawing.Color.Ivory
        Me.grbUsingSelectedDoubleLug.Controls.Add(Me.chkDoubleLugFabricationRequired)
        Me.grbUsingSelectedDoubleLug.Controls.Add(Me.rdbNewCasting)
        Me.grbUsingSelectedDoubleLug.Controls.Add(Me.rdbResize)
        Me.grbUsingSelectedDoubleLug.Controls.Add(Me.rdbExactMatchYes)
        Me.grbUsingSelectedDoubleLug.Controls.Add(Me.lblUsingSelectedDoubleLug)
        Me.grbUsingSelectedDoubleLug.Location = New System.Drawing.Point(30, 428)
        Me.grbUsingSelectedDoubleLug.Name = "grbUsingSelectedDoubleLug"
        Me.grbUsingSelectedDoubleLug.Size = New System.Drawing.Size(543, 104)
        Me.grbUsingSelectedDoubleLug.TabIndex = 12
        Me.grbUsingSelectedDoubleLug.TabStop = False
        '
        'rdbExactMatchYes
        '
        Me.rdbExactMatchYes.AutoSize = True
        Me.rdbExactMatchYes.Location = New System.Drawing.Point(149, 40)
        Me.rdbExactMatchYes.Name = "rdbExactMatchYes"
        Me.rdbExactMatchYes.Size = New System.Drawing.Size(76, 17)
        Me.rdbExactMatchYes.TabIndex = 146
        Me.rdbExactMatchYes.TabStop = True
        Me.rdbExactMatchYes.Text = "Use as it is"
        Me.rdbExactMatchYes.UseVisualStyleBackColor = True
        '
        'lblUsingSelectedDoubleLug
        '
        Me.lblUsingSelectedDoubleLug.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblUsingSelectedDoubleLug.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsingSelectedDoubleLug.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUsingSelectedDoubleLug.GradientColorOne = System.Drawing.Color.Olive
        Me.lblUsingSelectedDoubleLug.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblUsingSelectedDoubleLug.Location = New System.Drawing.Point(-2, 0)
        Me.lblUsingSelectedDoubleLug.Name = "lblUsingSelectedDoubleLug"
        Me.lblUsingSelectedDoubleLug.Size = New System.Drawing.Size(545, 19)
        Me.lblUsingSelectedDoubleLug.TabIndex = 111
        Me.lblUsingSelectedDoubleLug.Text = "Using Selected DoubleLug"
        Me.lblUsingSelectedDoubleLug.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBackGround
        '
        Me.lblBackGround.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblBackGround.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBackGround.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBackGround.GradientColorOne = System.Drawing.Color.DarkGoldenrod
        Me.lblBackGround.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblBackGround.Location = New System.Drawing.Point(12, 9)
        Me.lblBackGround.Name = "lblBackGround"
        Me.lblBackGround.Size = New System.Drawing.Size(578, 529)
        Me.lblBackGround.TabIndex = 113
        Me.lblBackGround.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grbNotUsingSelectedDoubleLugCasting
        '
        Me.grbNotUsingSelectedDoubleLugCasting.BackColor = System.Drawing.Color.Ivory
        Me.grbNotUsingSelectedDoubleLugCasting.Controls.Add(Me.lblNotUsingSelectedDoubleLug)
        Me.grbNotUsingSelectedDoubleLugCasting.Controls.Add(Me.btnClickNextButton)
        Me.grbNotUsingSelectedDoubleLugCasting.Location = New System.Drawing.Point(30, 428)
        Me.grbNotUsingSelectedDoubleLugCasting.Name = "grbNotUsingSelectedDoubleLugCasting"
        Me.grbNotUsingSelectedDoubleLugCasting.Size = New System.Drawing.Size(543, 97)
        Me.grbNotUsingSelectedDoubleLugCasting.TabIndex = 147
        Me.grbNotUsingSelectedDoubleLugCasting.TabStop = False
        '
        'lblNotUsingSelectedDoubleLug
        '
        Me.lblNotUsingSelectedDoubleLug.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblNotUsingSelectedDoubleLug.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotUsingSelectedDoubleLug.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNotUsingSelectedDoubleLug.GradientColorOne = System.Drawing.Color.Olive
        Me.lblNotUsingSelectedDoubleLug.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblNotUsingSelectedDoubleLug.Location = New System.Drawing.Point(-2, 0)
        Me.lblNotUsingSelectedDoubleLug.Name = "lblNotUsingSelectedDoubleLug"
        Me.lblNotUsingSelectedDoubleLug.Size = New System.Drawing.Size(545, 19)
        Me.lblNotUsingSelectedDoubleLug.TabIndex = 111
        Me.lblNotUsingSelectedDoubleLug.Text = "Not Using Selected Double Lug"
        Me.lblNotUsingSelectedDoubleLug.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnClickNextButton
        '
        Me.btnClickNextButton.BackColor = System.Drawing.Color.Ivory
        Me.btnClickNextButton.Enabled = False
        Me.btnClickNextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClickNextButton.Location = New System.Drawing.Point(188, 31)
        Me.btnClickNextButton.Name = "btnClickNextButton"
        Me.btnClickNextButton.Size = New System.Drawing.Size(158, 34)
        Me.btnClickNextButton.TabIndex = 116
        Me.btnClickNextButton.Text = "Click Next Button"
        Me.btnClickNextButton.UseVisualStyleBackColor = False
        '
        'chkDoubleLugFabricationRequired
        '
        Me.chkDoubleLugFabricationRequired.AutoSize = True
        Me.chkDoubleLugFabricationRequired.Location = New System.Drawing.Point(410, 71)
        Me.chkDoubleLugFabricationRequired.Name = "chkDoubleLugFabricationRequired"
        Me.chkDoubleLugFabricationRequired.Size = New System.Drawing.Size(124, 17)
        Me.chkDoubleLugFabricationRequired.TabIndex = 177
        Me.chkDoubleLugFabricationRequired.Text = "Fabrication Required"
        Me.chkDoubleLugFabricationRequired.UseVisualStyleBackColor = True
        '
        'frmDLCastingYes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(900, 650)
        Me.Controls.Add(Me.grbCastingListView)
        Me.Controls.Add(Me.grbUsingSelectedDoubleLug)
        Me.Controls.Add(Me.grbNotUsingSelectedDoubleLugCasting)
        Me.Controls.Add(Me.lblBackGround)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDLCastingYes"
        Me.Text = "frmCastingYes"
        Me.grbCastingListView.ResumeLayout(False)
        Me.grbCastingListView.PerformLayout()
        CType(Me.picCastingYes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbUsingSelectedDoubleLug.ResumeLayout(False)
        Me.grbUsingSelectedDoubleLug.PerformLayout()
        Me.grbNotUsingSelectedDoubleLugCasting.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rdbNewCasting As System.Windows.Forms.RadioButton
    Friend WithEvents rdbResize As System.Windows.Forms.RadioButton
    Friend WithEvents grbCastingListView As System.Windows.Forms.GroupBox
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
    Friend WithEvents lblLugsWidth As System.Windows.Forms.Label
    Friend WithEvents txtLugsGap As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblLugsGap As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleSize As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblPinHoleSize As System.Windows.Forms.Label
    Friend WithEvents txtSwingClearance As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSwingClearance As System.Windows.Forms.Label
    Friend WithEvents txtCodeNumber As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblCodeNumber As System.Windows.Forms.Label
    Friend WithEvents lvwDoubleLugListView As clsListViewMIL
    Friend WithEvents lblDoubleLugCasting As LabelGradient.LabelGradient
    Friend WithEvents grbUsingSelectedDoubleLug As System.Windows.Forms.GroupBox
    Friend WithEvents lblUsingSelectedDoubleLug As LabelGradient.LabelGradient
    Friend WithEvents lblBackGround As LabelGradient.LabelGradient
    Friend WithEvents txtRequiredAngle2 As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredAngle1 As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredGreaseZerk As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredLugsWidth As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredLugThickness As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredLugsGap As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredPinHoleSize As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredSwingClearance As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblRequired As System.Windows.Forms.Label
    Friend WithEvents lblUseSelectedSingleLug As System.Windows.Forms.Label
    Friend WithEvents rdbUseSelectedSingleLugNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbUseSelectedSingleLugYes As System.Windows.Forms.RadioButton
    Friend WithEvents rdbExactMatchYes As System.Windows.Forms.RadioButton
    Friend WithEvents grbNotUsingSelectedDoubleLugCasting As System.Windows.Forms.GroupBox
    Friend WithEvents lblNotUsingSelectedDoubleLug As LabelGradient.LabelGradient
    Friend WithEvents btnClickNextButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleTole_Neg As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtPinHoleTole_Pos As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPinHoleTole_Neg_Req As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtPinHoleTole_Pos_Req As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents chkDoubleLugFabricationRequired As System.Windows.Forms.CheckBox
End Class
