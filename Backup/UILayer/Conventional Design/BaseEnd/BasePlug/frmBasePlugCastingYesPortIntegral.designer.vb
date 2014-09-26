<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBasePlugCastingYesPortIntegral
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
        Me.txtRequiredCost = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredSwingClearance = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredBasePlugDia = New IFLCustomUILayer.IFLNumericBox
        Me.txtCost = New IFLCustomUILayer.IFLNumericBox
        Me.lblCost = New System.Windows.Forms.Label
        Me.txtSwingClearance = New IFLCustomUILayer.IFLNumericBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtBasePlugDia = New IFLCustomUILayer.IFLNumericBox
        Me.lblBasePlugDia = New System.Windows.Forms.Label
        Me.lblRequired = New System.Windows.Forms.Label
        Me.txtRequiredPortSize = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredSecondPortOrientation = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredFirstPortOrientation = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredPortType = New IFLCustomUILayer.IFLNumericBox
        Me.txtSecondPortOrientation = New IFLCustomUILayer.IFLNumericBox
        Me.lblSecondPortOrientation = New System.Windows.Forms.Label
        Me.txtFirstPortOrientation = New IFLCustomUILayer.IFLNumericBox
        Me.lblFirstPort = New System.Windows.Forms.Label
        Me.txtPortSize = New IFLCustomUILayer.IFLNumericBox
        Me.lblPortSize = New System.Windows.Forms.Label
        Me.txtPortType = New IFLCustomUILayer.IFLNumericBox
        Me.lblPortType = New System.Windows.Forms.Label
        Me.grbCastingListView = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblUseSelectedBasePlug = New System.Windows.Forms.Label
        Me.rdbUseSelectedBasePlugNo = New System.Windows.Forms.RadioButton
        Me.rdbUseSelectedBasePlugYes = New System.Windows.Forms.RadioButton
        Me.btnPicInformation = New System.Windows.Forms.Button
        Me.picCastingYes = New System.Windows.Forms.PictureBox
        Me.lblBasePlugCasting = New LabelGradient.LabelGradient
        Me.lblBackGround = New LabelGradient.LabelGradient
        Me.grbUsingSelectedBasePlug = New System.Windows.Forms.GroupBox
        Me.rdbNewCasting = New System.Windows.Forms.RadioButton
        Me.rdbResize = New System.Windows.Forms.RadioButton
        Me.rdbExactMatchYes = New System.Windows.Forms.RadioButton
        Me.lblUsingSelectedDoubleLug = New LabelGradient.LabelGradient
        Me.btnClickNextButton = New System.Windows.Forms.Button
        Me.lvwBasePlugView = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL
        Me.grbCastingListView.SuspendLayout()
        CType(Me.picCastingYes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbUsingSelectedBasePlug.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtRequiredCost
        '
        Me.txtRequiredCost.AcceptEnterKeyAsTab = True
        Me.txtRequiredCost.ApplyIFLColor = True
        Me.txtRequiredCost.AssociateLabel = Nothing
        Me.txtRequiredCost.DecimalValue = 2
        Me.txtRequiredCost.IFLDataTag = Nothing
        Me.txtRequiredCost.InvalidInputCharacters = ""
        Me.txtRequiredCost.IsAllowNegative = False
        Me.txtRequiredCost.LengthValue = 6
        Me.txtRequiredCost.Location = New System.Drawing.Point(507, 240)
        Me.txtRequiredCost.MaximumValue = 99999
        Me.txtRequiredCost.MaxLength = 6
        Me.txtRequiredCost.MinimumValue = 0
        Me.txtRequiredCost.Name = "txtRequiredCost"
        Me.txtRequiredCost.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredCost.StatusMessage = ""
        Me.txtRequiredCost.StatusObject = Nothing
        Me.txtRequiredCost.TabIndex = 155
        Me.txtRequiredCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.txtRequiredSwingClearance.Location = New System.Drawing.Point(507, 214)
        Me.txtRequiredSwingClearance.MaximumValue = 99999
        Me.txtRequiredSwingClearance.MaxLength = 6
        Me.txtRequiredSwingClearance.MinimumValue = 0
        Me.txtRequiredSwingClearance.Name = "txtRequiredSwingClearance"
        Me.txtRequiredSwingClearance.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredSwingClearance.StatusMessage = ""
        Me.txtRequiredSwingClearance.StatusObject = Nothing
        Me.txtRequiredSwingClearance.TabIndex = 154
        Me.txtRequiredSwingClearance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredBasePlugDia
        '
        Me.txtRequiredBasePlugDia.AcceptEnterKeyAsTab = True
        Me.txtRequiredBasePlugDia.ApplyIFLColor = True
        Me.txtRequiredBasePlugDia.AssociateLabel = Nothing
        Me.txtRequiredBasePlugDia.DecimalValue = 2
        Me.txtRequiredBasePlugDia.IFLDataTag = Nothing
        Me.txtRequiredBasePlugDia.InvalidInputCharacters = ""
        Me.txtRequiredBasePlugDia.IsAllowNegative = False
        Me.txtRequiredBasePlugDia.LengthValue = 6
        Me.txtRequiredBasePlugDia.Location = New System.Drawing.Point(507, 189)
        Me.txtRequiredBasePlugDia.MaximumValue = 99999
        Me.txtRequiredBasePlugDia.MaxLength = 6
        Me.txtRequiredBasePlugDia.MinimumValue = 0
        Me.txtRequiredBasePlugDia.Name = "txtRequiredBasePlugDia"
        Me.txtRequiredBasePlugDia.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredBasePlugDia.StatusMessage = ""
        Me.txtRequiredBasePlugDia.StatusObject = Nothing
        Me.txtRequiredBasePlugDia.TabIndex = 153
        Me.txtRequiredBasePlugDia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCost
        '
        Me.txtCost.AcceptEnterKeyAsTab = True
        Me.txtCost.ApplyIFLColor = True
        Me.txtCost.AssociateLabel = Nothing
        Me.txtCost.DecimalValue = 2
        Me.txtCost.IFLDataTag = Nothing
        Me.txtCost.InvalidInputCharacters = ""
        Me.txtCost.IsAllowNegative = False
        Me.txtCost.LengthValue = 6
        Me.txtCost.Location = New System.Drawing.Point(410, 240)
        Me.txtCost.MaximumValue = 99999
        Me.txtCost.MaxLength = 6
        Me.txtCost.MinimumValue = 0
        Me.txtCost.Name = "txtCost"
        Me.txtCost.Size = New System.Drawing.Size(66, 20)
        Me.txtCost.StatusMessage = ""
        Me.txtCost.StatusObject = Nothing
        Me.txtCost.TabIndex = 151
        Me.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCost
        '
        Me.lblCost.AutoSize = True
        Me.lblCost.Location = New System.Drawing.Point(317, 243)
        Me.lblCost.Name = "lblCost"
        Me.lblCost.Size = New System.Drawing.Size(28, 13)
        Me.lblCost.TabIndex = 152
        Me.lblCost.Text = "Cost"
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
        Me.txtSwingClearance.Location = New System.Drawing.Point(410, 214)
        Me.txtSwingClearance.MaximumValue = 99999
        Me.txtSwingClearance.MaxLength = 6
        Me.txtSwingClearance.MinimumValue = 0
        Me.txtSwingClearance.Name = "txtSwingClearance"
        Me.txtSwingClearance.Size = New System.Drawing.Size(66, 20)
        Me.txtSwingClearance.StatusMessage = ""
        Me.txtSwingClearance.StatusObject = Nothing
        Me.txtSwingClearance.TabIndex = 149
        Me.txtSwingClearance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(317, 218)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 150
        Me.Label1.Text = "Swing Clearance"
        '
        'txtBasePlugDia
        '
        Me.txtBasePlugDia.AcceptEnterKeyAsTab = True
        Me.txtBasePlugDia.ApplyIFLColor = True
        Me.txtBasePlugDia.AssociateLabel = Nothing
        Me.txtBasePlugDia.DecimalValue = 2
        Me.txtBasePlugDia.IFLDataTag = Nothing
        Me.txtBasePlugDia.InvalidInputCharacters = ""
        Me.txtBasePlugDia.IsAllowNegative = False
        Me.txtBasePlugDia.LengthValue = 6
        Me.txtBasePlugDia.Location = New System.Drawing.Point(410, 189)
        Me.txtBasePlugDia.MaximumValue = 99999
        Me.txtBasePlugDia.MaxLength = 6
        Me.txtBasePlugDia.MinimumValue = 0
        Me.txtBasePlugDia.Name = "txtBasePlugDia"
        Me.txtBasePlugDia.Size = New System.Drawing.Size(66, 20)
        Me.txtBasePlugDia.StatusMessage = ""
        Me.txtBasePlugDia.StatusObject = Nothing
        Me.txtBasePlugDia.TabIndex = 147
        Me.txtBasePlugDia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBasePlugDia
        '
        Me.lblBasePlugDia.AutoSize = True
        Me.lblBasePlugDia.Location = New System.Drawing.Point(317, 192)
        Me.lblBasePlugDia.Name = "lblBasePlugDia"
        Me.lblBasePlugDia.Size = New System.Drawing.Size(74, 13)
        Me.lblBasePlugDia.TabIndex = 148
        Me.lblBasePlugDia.Text = "Base Plug Dia"
        '
        'lblRequired
        '
        Me.lblRequired.AutoSize = True
        Me.lblRequired.Location = New System.Drawing.Point(234, 172)
        Me.lblRequired.Name = "lblRequired"
        Me.lblRequired.Size = New System.Drawing.Size(50, 13)
        Me.lblRequired.TabIndex = 146
        Me.lblRequired.Text = "Required"
        '
        'txtRequiredPortSize
        '
        Me.txtRequiredPortSize.AcceptEnterKeyAsTab = True
        Me.txtRequiredPortSize.ApplyIFLColor = True
        Me.txtRequiredPortSize.AssociateLabel = Nothing
        Me.txtRequiredPortSize.DecimalValue = 2
        Me.txtRequiredPortSize.IFLDataTag = Nothing
        Me.txtRequiredPortSize.InvalidInputCharacters = ""
        Me.txtRequiredPortSize.IsAllowNegative = False
        Me.txtRequiredPortSize.LengthValue = 6
        Me.txtRequiredPortSize.Location = New System.Drawing.Point(228, 214)
        Me.txtRequiredPortSize.MaximumValue = 99999
        Me.txtRequiredPortSize.MaxLength = 6
        Me.txtRequiredPortSize.MinimumValue = 0
        Me.txtRequiredPortSize.Name = "txtRequiredPortSize"
        Me.txtRequiredPortSize.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredPortSize.StatusMessage = ""
        Me.txtRequiredPortSize.StatusObject = Nothing
        Me.txtRequiredPortSize.TabIndex = 143
        Me.txtRequiredPortSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredSecondPortOrientation
        '
        Me.txtRequiredSecondPortOrientation.AcceptEnterKeyAsTab = True
        Me.txtRequiredSecondPortOrientation.ApplyIFLColor = True
        Me.txtRequiredSecondPortOrientation.AssociateLabel = Nothing
        Me.txtRequiredSecondPortOrientation.DecimalValue = 2
        Me.txtRequiredSecondPortOrientation.IFLDataTag = Nothing
        Me.txtRequiredSecondPortOrientation.InvalidInputCharacters = ""
        Me.txtRequiredSecondPortOrientation.IsAllowNegative = False
        Me.txtRequiredSecondPortOrientation.LengthValue = 6
        Me.txtRequiredSecondPortOrientation.Location = New System.Drawing.Point(228, 266)
        Me.txtRequiredSecondPortOrientation.MaximumValue = 99999
        Me.txtRequiredSecondPortOrientation.MaxLength = 6
        Me.txtRequiredSecondPortOrientation.MinimumValue = 0
        Me.txtRequiredSecondPortOrientation.Name = "txtRequiredSecondPortOrientation"
        Me.txtRequiredSecondPortOrientation.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredSecondPortOrientation.StatusMessage = ""
        Me.txtRequiredSecondPortOrientation.StatusObject = Nothing
        Me.txtRequiredSecondPortOrientation.TabIndex = 145
        Me.txtRequiredSecondPortOrientation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredFirstPortOrientation
        '
        Me.txtRequiredFirstPortOrientation.AcceptEnterKeyAsTab = True
        Me.txtRequiredFirstPortOrientation.ApplyIFLColor = True
        Me.txtRequiredFirstPortOrientation.AssociateLabel = Nothing
        Me.txtRequiredFirstPortOrientation.DecimalValue = 2
        Me.txtRequiredFirstPortOrientation.IFLDataTag = Nothing
        Me.txtRequiredFirstPortOrientation.InvalidInputCharacters = ""
        Me.txtRequiredFirstPortOrientation.IsAllowNegative = False
        Me.txtRequiredFirstPortOrientation.LengthValue = 6
        Me.txtRequiredFirstPortOrientation.Location = New System.Drawing.Point(228, 240)
        Me.txtRequiredFirstPortOrientation.MaximumValue = 99999
        Me.txtRequiredFirstPortOrientation.MaxLength = 6
        Me.txtRequiredFirstPortOrientation.MinimumValue = 0
        Me.txtRequiredFirstPortOrientation.Name = "txtRequiredFirstPortOrientation"
        Me.txtRequiredFirstPortOrientation.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredFirstPortOrientation.StatusMessage = ""
        Me.txtRequiredFirstPortOrientation.StatusObject = Nothing
        Me.txtRequiredFirstPortOrientation.TabIndex = 144
        Me.txtRequiredFirstPortOrientation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredPortType
        '
        Me.txtRequiredPortType.AcceptEnterKeyAsTab = True
        Me.txtRequiredPortType.ApplyIFLColor = True
        Me.txtRequiredPortType.AssociateLabel = Nothing
        Me.txtRequiredPortType.DecimalValue = 2
        Me.txtRequiredPortType.IFLDataTag = Nothing
        Me.txtRequiredPortType.InvalidInputCharacters = ""
        Me.txtRequiredPortType.IsAllowNegative = False
        Me.txtRequiredPortType.LengthValue = 6
        Me.txtRequiredPortType.Location = New System.Drawing.Point(228, 188)
        Me.txtRequiredPortType.MaximumValue = 99999
        Me.txtRequiredPortType.MaxLength = 6
        Me.txtRequiredPortType.MinimumValue = 0
        Me.txtRequiredPortType.Name = "txtRequiredPortType"
        Me.txtRequiredPortType.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredPortType.StatusMessage = ""
        Me.txtRequiredPortType.StatusObject = Nothing
        Me.txtRequiredPortType.TabIndex = 142
        Me.txtRequiredPortType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSecondPortOrientation
        '
        Me.txtSecondPortOrientation.AcceptEnterKeyAsTab = True
        Me.txtSecondPortOrientation.ApplyIFLColor = True
        Me.txtSecondPortOrientation.AssociateLabel = Nothing
        Me.txtSecondPortOrientation.DecimalValue = 2
        Me.txtSecondPortOrientation.IFLDataTag = Nothing
        Me.txtSecondPortOrientation.InvalidInputCharacters = ""
        Me.txtSecondPortOrientation.IsAllowNegative = False
        Me.txtSecondPortOrientation.LengthValue = 6
        Me.txtSecondPortOrientation.Location = New System.Drawing.Point(131, 266)
        Me.txtSecondPortOrientation.MaximumValue = 99999
        Me.txtSecondPortOrientation.MaxLength = 6
        Me.txtSecondPortOrientation.MinimumValue = 0
        Me.txtSecondPortOrientation.Name = "txtSecondPortOrientation"
        Me.txtSecondPortOrientation.Size = New System.Drawing.Size(66, 20)
        Me.txtSecondPortOrientation.StatusMessage = ""
        Me.txtSecondPortOrientation.StatusObject = Nothing
        Me.txtSecondPortOrientation.TabIndex = 138
        Me.txtSecondPortOrientation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSecondPortOrientation
        '
        Me.lblSecondPortOrientation.AutoSize = True
        Me.lblSecondPortOrientation.Location = New System.Drawing.Point(5, 270)
        Me.lblSecondPortOrientation.Name = "lblSecondPortOrientation"
        Me.lblSecondPortOrientation.Size = New System.Drawing.Size(120, 13)
        Me.lblSecondPortOrientation.TabIndex = 139
        Me.lblSecondPortOrientation.Text = "Second Port Orientation"
        '
        'txtFirstPortOrientation
        '
        Me.txtFirstPortOrientation.AcceptEnterKeyAsTab = True
        Me.txtFirstPortOrientation.ApplyIFLColor = True
        Me.txtFirstPortOrientation.AssociateLabel = Nothing
        Me.txtFirstPortOrientation.DecimalValue = 2
        Me.txtFirstPortOrientation.IFLDataTag = Nothing
        Me.txtFirstPortOrientation.InvalidInputCharacters = ""
        Me.txtFirstPortOrientation.IsAllowNegative = False
        Me.txtFirstPortOrientation.LengthValue = 6
        Me.txtFirstPortOrientation.Location = New System.Drawing.Point(131, 240)
        Me.txtFirstPortOrientation.MaximumValue = 99999
        Me.txtFirstPortOrientation.MaxLength = 6
        Me.txtFirstPortOrientation.MinimumValue = 0
        Me.txtFirstPortOrientation.Name = "txtFirstPortOrientation"
        Me.txtFirstPortOrientation.Size = New System.Drawing.Size(66, 20)
        Me.txtFirstPortOrientation.StatusMessage = ""
        Me.txtFirstPortOrientation.StatusObject = Nothing
        Me.txtFirstPortOrientation.TabIndex = 136
        Me.txtFirstPortOrientation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFirstPort
        '
        Me.lblFirstPort.AutoSize = True
        Me.lblFirstPort.Location = New System.Drawing.Point(5, 243)
        Me.lblFirstPort.Name = "lblFirstPort"
        Me.lblFirstPort.Size = New System.Drawing.Size(102, 13)
        Me.lblFirstPort.TabIndex = 137
        Me.lblFirstPort.Text = "First Port Orientation"
        '
        'txtPortSize
        '
        Me.txtPortSize.AcceptEnterKeyAsTab = True
        Me.txtPortSize.ApplyIFLColor = True
        Me.txtPortSize.AssociateLabel = Nothing
        Me.txtPortSize.DecimalValue = 2
        Me.txtPortSize.IFLDataTag = Nothing
        Me.txtPortSize.InvalidInputCharacters = ""
        Me.txtPortSize.IsAllowNegative = False
        Me.txtPortSize.LengthValue = 6
        Me.txtPortSize.Location = New System.Drawing.Point(131, 214)
        Me.txtPortSize.MaximumValue = 99999
        Me.txtPortSize.MaxLength = 6
        Me.txtPortSize.MinimumValue = 0
        Me.txtPortSize.Name = "txtPortSize"
        Me.txtPortSize.Size = New System.Drawing.Size(66, 20)
        Me.txtPortSize.StatusMessage = ""
        Me.txtPortSize.StatusObject = Nothing
        Me.txtPortSize.TabIndex = 134
        Me.txtPortSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPortSize
        '
        Me.lblPortSize.AutoSize = True
        Me.lblPortSize.Location = New System.Drawing.Point(5, 217)
        Me.lblPortSize.Name = "lblPortSize"
        Me.lblPortSize.Size = New System.Drawing.Size(49, 13)
        Me.lblPortSize.TabIndex = 135
        Me.lblPortSize.Text = "Port Size"
        '
        'txtPortType
        '
        Me.txtPortType.AcceptEnterKeyAsTab = True
        Me.txtPortType.ApplyIFLColor = True
        Me.txtPortType.AssociateLabel = Nothing
        Me.txtPortType.DecimalValue = 2
        Me.txtPortType.IFLDataTag = Nothing
        Me.txtPortType.InvalidInputCharacters = ""
        Me.txtPortType.IsAllowNegative = False
        Me.txtPortType.LengthValue = 6
        Me.txtPortType.Location = New System.Drawing.Point(131, 188)
        Me.txtPortType.MaximumValue = 99999
        Me.txtPortType.MaxLength = 6
        Me.txtPortType.MinimumValue = 0
        Me.txtPortType.Name = "txtPortType"
        Me.txtPortType.Size = New System.Drawing.Size(66, 20)
        Me.txtPortType.StatusMessage = ""
        Me.txtPortType.StatusObject = Nothing
        Me.txtPortType.TabIndex = 132
        Me.txtPortType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPortType
        '
        Me.lblPortType.AutoSize = True
        Me.lblPortType.Location = New System.Drawing.Point(5, 192)
        Me.lblPortType.Name = "lblPortType"
        Me.lblPortType.Size = New System.Drawing.Size(53, 13)
        Me.lblPortType.TabIndex = 133
        Me.lblPortType.Text = "Port Type"
        '
        'grbCastingListView
        '
        Me.grbCastingListView.BackColor = System.Drawing.Color.Ivory
        Me.grbCastingListView.Controls.Add(Me.Label4)
        Me.grbCastingListView.Controls.Add(Me.Label3)
        Me.grbCastingListView.Controls.Add(Me.Label2)
        Me.grbCastingListView.Controls.Add(Me.lblUseSelectedBasePlug)
        Me.grbCastingListView.Controls.Add(Me.rdbUseSelectedBasePlugNo)
        Me.grbCastingListView.Controls.Add(Me.rdbUseSelectedBasePlugYes)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredCost)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredSwingClearance)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredBasePlugDia)
        Me.grbCastingListView.Controls.Add(Me.txtCost)
        Me.grbCastingListView.Controls.Add(Me.lblCost)
        Me.grbCastingListView.Controls.Add(Me.txtSwingClearance)
        Me.grbCastingListView.Controls.Add(Me.Label1)
        Me.grbCastingListView.Controls.Add(Me.txtBasePlugDia)
        Me.grbCastingListView.Controls.Add(Me.lblBasePlugDia)
        Me.grbCastingListView.Controls.Add(Me.lblRequired)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredPortSize)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredSecondPortOrientation)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredFirstPortOrientation)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredPortType)
        Me.grbCastingListView.Controls.Add(Me.txtSecondPortOrientation)
        Me.grbCastingListView.Controls.Add(Me.lblSecondPortOrientation)
        Me.grbCastingListView.Controls.Add(Me.txtFirstPortOrientation)
        Me.grbCastingListView.Controls.Add(Me.lblFirstPort)
        Me.grbCastingListView.Controls.Add(Me.txtPortSize)
        Me.grbCastingListView.Controls.Add(Me.lblPortSize)
        Me.grbCastingListView.Controls.Add(Me.txtPortType)
        Me.grbCastingListView.Controls.Add(Me.lblPortType)
        Me.grbCastingListView.Controls.Add(Me.btnPicInformation)
        Me.grbCastingListView.Controls.Add(Me.picCastingYes)
        Me.grbCastingListView.Controls.Add(Me.lvwBasePlugView)
        Me.grbCastingListView.Controls.Add(Me.lblBasePlugCasting)
        Me.grbCastingListView.Location = New System.Drawing.Point(20, 18)
        Me.grbCastingListView.Name = "grbCastingListView"
        Me.grbCastingListView.Size = New System.Drawing.Size(599, 304)
        Me.grbCastingListView.TabIndex = 120
        Me.grbCastingListView.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(514, 172)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 161
        Me.Label4.Text = "Required"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(418, 172)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 160
        Me.Label3.Text = "Available"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(137, 172)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 159
        Me.Label2.Text = "Available"
        '
        'lblUseSelectedBasePlug
        '
        Me.lblUseSelectedBasePlug.AutoSize = True
        Me.lblUseSelectedBasePlug.Location = New System.Drawing.Point(317, 270)
        Me.lblUseSelectedBasePlug.Name = "lblUseSelectedBasePlug"
        Me.lblUseSelectedBasePlug.Size = New System.Drawing.Size(119, 13)
        Me.lblUseSelectedBasePlug.TabIndex = 158
        Me.lblUseSelectedBasePlug.Text = "Use Selected BasePlug"
        '
        'rdbUseSelectedBasePlugNo
        '
        Me.rdbUseSelectedBasePlugNo.AutoSize = True
        Me.rdbUseSelectedBasePlugNo.Location = New System.Drawing.Point(507, 268)
        Me.rdbUseSelectedBasePlugNo.Name = "rdbUseSelectedBasePlugNo"
        Me.rdbUseSelectedBasePlugNo.Size = New System.Drawing.Size(39, 17)
        Me.rdbUseSelectedBasePlugNo.TabIndex = 157
        Me.rdbUseSelectedBasePlugNo.TabStop = True
        Me.rdbUseSelectedBasePlugNo.Text = "No"
        Me.rdbUseSelectedBasePlugNo.UseVisualStyleBackColor = True
        '
        'rdbUseSelectedBasePlugYes
        '
        Me.rdbUseSelectedBasePlugYes.AutoSize = True
        Me.rdbUseSelectedBasePlugYes.Location = New System.Drawing.Point(453, 268)
        Me.rdbUseSelectedBasePlugYes.Name = "rdbUseSelectedBasePlugYes"
        Me.rdbUseSelectedBasePlugYes.Size = New System.Drawing.Size(43, 17)
        Me.rdbUseSelectedBasePlugYes.TabIndex = 156
        Me.rdbUseSelectedBasePlugYes.TabStop = True
        Me.rdbUseSelectedBasePlugYes.Text = "Yes"
        Me.rdbUseSelectedBasePlugYes.UseVisualStyleBackColor = True
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
        'lblBasePlugCasting
        '
        Me.lblBasePlugCasting.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblBasePlugCasting.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBasePlugCasting.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBasePlugCasting.GradientColorOne = System.Drawing.Color.Olive
        Me.lblBasePlugCasting.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblBasePlugCasting.Location = New System.Drawing.Point(-3, 0)
        Me.lblBasePlugCasting.Name = "lblBasePlugCasting"
        Me.lblBasePlugCasting.Size = New System.Drawing.Size(602, 19)
        Me.lblBasePlugCasting.TabIndex = 110
        Me.lblBasePlugCasting.Text = "Existing Base Plug  Casting Details"
        Me.lblBasePlugCasting.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblBackGround.Size = New System.Drawing.Size(616, 453)
        Me.lblBackGround.TabIndex = 121
        Me.lblBackGround.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grbUsingSelectedBasePlug
        '
        Me.grbUsingSelectedBasePlug.BackColor = System.Drawing.Color.Ivory
        Me.grbUsingSelectedBasePlug.Controls.Add(Me.rdbNewCasting)
        Me.grbUsingSelectedBasePlug.Controls.Add(Me.rdbResize)
        Me.grbUsingSelectedBasePlug.Controls.Add(Me.rdbExactMatchYes)
        Me.grbUsingSelectedBasePlug.Controls.Add(Me.lblUsingSelectedDoubleLug)
        Me.grbUsingSelectedBasePlug.Location = New System.Drawing.Point(20, 328)
        Me.grbUsingSelectedBasePlug.Name = "grbUsingSelectedBasePlug"
        Me.grbUsingSelectedBasePlug.Size = New System.Drawing.Size(599, 120)
        Me.grbUsingSelectedBasePlug.TabIndex = 122
        Me.grbUsingSelectedBasePlug.TabStop = False
        '
        'rdbNewCasting
        '
        Me.rdbNewCasting.AutoSize = True
        Me.rdbNewCasting.Location = New System.Drawing.Point(373, 56)
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
        Me.rdbResize.Location = New System.Drawing.Point(294, 56)
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
        Me.rdbExactMatchYes.Location = New System.Drawing.Point(196, 56)
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
        Me.lblUsingSelectedDoubleLug.Size = New System.Drawing.Size(601, 19)
        Me.lblUsingSelectedDoubleLug.TabIndex = 111
        Me.lblUsingSelectedDoubleLug.Text = "Using Selected BasePlug"
        Me.lblUsingSelectedDoubleLug.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnClickNextButton
        '
        Me.btnClickNextButton.BackColor = System.Drawing.Color.Ivory
        Me.btnClickNextButton.Enabled = False
        Me.btnClickNextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClickNextButton.Location = New System.Drawing.Point(497, 328)
        Me.btnClickNextButton.Name = "btnClickNextButton"
        Me.btnClickNextButton.Size = New System.Drawing.Size(158, 34)
        Me.btnClickNextButton.TabIndex = 159
        Me.btnClickNextButton.Text = "Click Next Button"
        Me.btnClickNextButton.UseVisualStyleBackColor = False
        '
        'lvwBasePlugView
        '
        Me.lvwBasePlugView.FullRowSelect = True
        Me.lvwBasePlugView.GridLines = True
        Me.lvwBasePlugView.Location = New System.Drawing.Point(6, 33)
        Me.lvwBasePlugView.MultiSelect = False
        Me.lvwBasePlugView.Name = "lvwBasePlugView"
        Me.lvwBasePlugView.Scrollable = False
        Me.lvwBasePlugView.Size = New System.Drawing.Size(369, 122)
        Me.lvwBasePlugView.TabIndex = 1
        Me.lvwBasePlugView.UseCompatibleStateImageBehavior = False
        Me.lvwBasePlugView.View = System.Windows.Forms.View.Details
        '
        'frmBasePlugCastingYesPortIntegral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(900, 650)
        Me.Controls.Add(Me.btnClickNextButton)
        Me.Controls.Add(Me.grbUsingSelectedBasePlug)
        Me.Controls.Add(Me.grbCastingListView)
        Me.Controls.Add(Me.lblBackGround)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmBasePlugCastingYesPortIntegral"
        Me.Text = "Form2"
        Me.grbCastingListView.ResumeLayout(False)
        Me.grbCastingListView.PerformLayout()
        CType(Me.picCastingYes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbUsingSelectedBasePlug.ResumeLayout(False)
        Me.grbUsingSelectedBasePlug.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtRequiredCost As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredSwingClearance As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredBasePlugDia As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtCost As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblCost As System.Windows.Forms.Label
    Friend WithEvents txtSwingClearance As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBasePlugDia As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblBasePlugDia As System.Windows.Forms.Label
    Friend WithEvents lblRequired As System.Windows.Forms.Label
    Friend WithEvents txtRequiredPortSize As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredSecondPortOrientation As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredFirstPortOrientation As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredPortType As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtSecondPortOrientation As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSecondPortOrientation As System.Windows.Forms.Label
    Friend WithEvents txtFirstPortOrientation As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblFirstPort As System.Windows.Forms.Label
    Friend WithEvents txtPortSize As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblPortSize As System.Windows.Forms.Label
    Friend WithEvents txtPortType As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblPortType As System.Windows.Forms.Label
    Friend WithEvents grbCastingListView As System.Windows.Forms.GroupBox
    Friend WithEvents btnPicInformation As System.Windows.Forms.Button
    Friend WithEvents picCastingYes As System.Windows.Forms.PictureBox
    Friend WithEvents lvwBasePlugView As Monarch_WeldedCylinder_01_09_09.clsListViewMIL
    Friend WithEvents lblBasePlugCasting As LabelGradient.LabelGradient
    Friend WithEvents lblBackGround As LabelGradient.LabelGradient
    Friend WithEvents lblUseSelectedBasePlug As System.Windows.Forms.Label
    Friend WithEvents rdbUseSelectedBasePlugNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbUseSelectedBasePlugYes As System.Windows.Forms.RadioButton
    Friend WithEvents grbUsingSelectedBasePlug As System.Windows.Forms.GroupBox
    Friend WithEvents rdbExactMatchYes As System.Windows.Forms.RadioButton
    Friend WithEvents rdbNewCasting As System.Windows.Forms.RadioButton
    Friend WithEvents rdbResize As System.Windows.Forms.RadioButton
    Friend WithEvents lblUsingSelectedDoubleLug As LabelGradient.LabelGradient
    Friend WithEvents btnClickNextButton As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
