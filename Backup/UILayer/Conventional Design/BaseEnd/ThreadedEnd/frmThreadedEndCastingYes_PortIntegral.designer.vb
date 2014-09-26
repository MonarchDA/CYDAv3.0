<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThreadedEndCastingYes_PortIntegral
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblUseSelectedThreadedEnd = New System.Windows.Forms.Label
        Me.rdbUseSelectedThreadedEndNo = New System.Windows.Forms.RadioButton
        Me.rdbUseSelectedThreadedEndYes = New System.Windows.Forms.RadioButton
        Me.txtRequiredSecondPortOrientation = New IFLCustomUILayer.IFLNumericBox
        Me.txtSecondPortOrientation = New IFLCustomUILayer.IFLNumericBox
        Me.lblSecondPortOrientation = New System.Windows.Forms.Label
        Me.txtRequiredNoOfPorts = New IFLCustomUILayer.IFLNumericBox
        Me.txtNoOfPorts = New IFLCustomUILayer.IFLNumericBox
        Me.lblNoOfPorts = New System.Windows.Forms.Label
        Me.txtRequiredPortSize = New IFLCustomUILayer.IFLNumericBox
        Me.txtPortSize = New IFLCustomUILayer.IFLNumericBox
        Me.lblPortSize = New System.Windows.Forms.Label
        Me.lblRequired = New System.Windows.Forms.Label
        Me.txtRequiredPortType = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredCost = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredSwingClearance = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredThreadDiameter = New IFLCustomUILayer.IFLNumericBox
        Me.txtCost = New IFLCustomUILayer.IFLNumericBox
        Me.lblCost = New System.Windows.Forms.Label
        Me.txtSwingClearance = New IFLCustomUILayer.IFLNumericBox
        Me.lblSwingClearance = New System.Windows.Forms.Label
        Me.txtPortType = New IFLCustomUILayer.IFLNumericBox
        Me.lblPortType = New System.Windows.Forms.Label
        Me.txtThreadDiameter = New IFLCustomUILayer.IFLNumericBox
        Me.lblThreadDiameter = New System.Windows.Forms.Label
        Me.btnPicInformation = New System.Windows.Forms.Button
        Me.picCastingYes = New System.Windows.Forms.PictureBox
        Me.lvwThreadedEndListView = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL
        Me.lbThreadedEndCasting = New LabelGradient.LabelGradient
        Me.lblBackGround = New LabelGradient.LabelGradient
        Me.grbCastingListView.SuspendLayout()
        CType(Me.picCastingYes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbCastingListView
        '
        Me.grbCastingListView.BackColor = System.Drawing.Color.Ivory
        Me.grbCastingListView.Controls.Add(Me.Label3)
        Me.grbCastingListView.Controls.Add(Me.Label2)
        Me.grbCastingListView.Controls.Add(Me.Label1)
        Me.grbCastingListView.Controls.Add(Me.lblUseSelectedThreadedEnd)
        Me.grbCastingListView.Controls.Add(Me.rdbUseSelectedThreadedEndNo)
        Me.grbCastingListView.Controls.Add(Me.rdbUseSelectedThreadedEndYes)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredSecondPortOrientation)
        Me.grbCastingListView.Controls.Add(Me.txtSecondPortOrientation)
        Me.grbCastingListView.Controls.Add(Me.lblSecondPortOrientation)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredNoOfPorts)
        Me.grbCastingListView.Controls.Add(Me.txtNoOfPorts)
        Me.grbCastingListView.Controls.Add(Me.lblNoOfPorts)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredPortSize)
        Me.grbCastingListView.Controls.Add(Me.txtPortSize)
        Me.grbCastingListView.Controls.Add(Me.lblPortSize)
        Me.grbCastingListView.Controls.Add(Me.lblRequired)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredPortType)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredCost)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredSwingClearance)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredThreadDiameter)
        Me.grbCastingListView.Controls.Add(Me.txtCost)
        Me.grbCastingListView.Controls.Add(Me.lblCost)
        Me.grbCastingListView.Controls.Add(Me.txtSwingClearance)
        Me.grbCastingListView.Controls.Add(Me.lblSwingClearance)
        Me.grbCastingListView.Controls.Add(Me.txtPortType)
        Me.grbCastingListView.Controls.Add(Me.lblPortType)
        Me.grbCastingListView.Controls.Add(Me.txtThreadDiameter)
        Me.grbCastingListView.Controls.Add(Me.lblThreadDiameter)
        Me.grbCastingListView.Controls.Add(Me.btnPicInformation)
        Me.grbCastingListView.Controls.Add(Me.picCastingYes)
        Me.grbCastingListView.Controls.Add(Me.lvwThreadedEndListView)
        Me.grbCastingListView.Controls.Add(Me.lbThreadedEndCasting)
        Me.grbCastingListView.Location = New System.Drawing.Point(30, 24)
        Me.grbCastingListView.Name = "grbCastingListView"
        Me.grbCastingListView.Size = New System.Drawing.Size(543, 339)
        Me.grbCastingListView.TabIndex = 118
        Me.grbCastingListView.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(469, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 164
        Me.Label3.Text = "Required"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(391, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 162
        Me.Label2.Text = "Available"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(81, 185)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 163
        Me.Label1.Text = "Available"
        '
        'lblUseSelectedThreadedEnd
        '
        Me.lblUseSelectedThreadedEnd.AutoSize = True
        Me.lblUseSelectedThreadedEnd.Location = New System.Drawing.Point(153, 311)
        Me.lblUseSelectedThreadedEnd.Name = "lblUseSelectedThreadedEnd"
        Me.lblUseSelectedThreadedEnd.Size = New System.Drawing.Size(142, 13)
        Me.lblUseSelectedThreadedEnd.TabIndex = 158
        Me.lblUseSelectedThreadedEnd.Text = "Use Selected Threaded End"
        '
        'rdbUseSelectedThreadedEndNo
        '
        Me.rdbUseSelectedThreadedEndNo.AutoSize = True
        Me.rdbUseSelectedThreadedEndNo.Location = New System.Drawing.Point(350, 309)
        Me.rdbUseSelectedThreadedEndNo.Name = "rdbUseSelectedThreadedEndNo"
        Me.rdbUseSelectedThreadedEndNo.Size = New System.Drawing.Size(39, 17)
        Me.rdbUseSelectedThreadedEndNo.TabIndex = 157
        Me.rdbUseSelectedThreadedEndNo.TabStop = True
        Me.rdbUseSelectedThreadedEndNo.Text = "No"
        Me.rdbUseSelectedThreadedEndNo.UseVisualStyleBackColor = True
        '
        'rdbUseSelectedThreadedEndYes
        '
        Me.rdbUseSelectedThreadedEndYes.AutoSize = True
        Me.rdbUseSelectedThreadedEndYes.Location = New System.Drawing.Point(301, 309)
        Me.rdbUseSelectedThreadedEndYes.Name = "rdbUseSelectedThreadedEndYes"
        Me.rdbUseSelectedThreadedEndYes.Size = New System.Drawing.Size(43, 17)
        Me.rdbUseSelectedThreadedEndYes.TabIndex = 156
        Me.rdbUseSelectedThreadedEndYes.TabStop = True
        Me.rdbUseSelectedThreadedEndYes.Text = "Yes"
        Me.rdbUseSelectedThreadedEndYes.UseVisualStyleBackColor = True
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
        Me.txtRequiredSecondPortOrientation.Location = New System.Drawing.Point(463, 280)
        Me.txtRequiredSecondPortOrientation.MaximumValue = 99999
        Me.txtRequiredSecondPortOrientation.MaxLength = 6
        Me.txtRequiredSecondPortOrientation.MinimumValue = 0
        Me.txtRequiredSecondPortOrientation.Name = "txtRequiredSecondPortOrientation"
        Me.txtRequiredSecondPortOrientation.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredSecondPortOrientation.StatusMessage = ""
        Me.txtRequiredSecondPortOrientation.StatusObject = Nothing
        Me.txtRequiredSecondPortOrientation.TabIndex = 155
        Me.txtRequiredSecondPortOrientation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.txtSecondPortOrientation.Location = New System.Drawing.Point(385, 280)
        Me.txtSecondPortOrientation.MaximumValue = 99999
        Me.txtSecondPortOrientation.MaxLength = 6
        Me.txtSecondPortOrientation.MinimumValue = 0
        Me.txtSecondPortOrientation.Name = "txtSecondPortOrientation"
        Me.txtSecondPortOrientation.Size = New System.Drawing.Size(66, 20)
        Me.txtSecondPortOrientation.StatusMessage = ""
        Me.txtSecondPortOrientation.StatusObject = Nothing
        Me.txtSecondPortOrientation.TabIndex = 153
        Me.txtSecondPortOrientation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSecondPortOrientation
        '
        Me.lblSecondPortOrientation.AutoSize = True
        Me.lblSecondPortOrientation.Location = New System.Drawing.Point(261, 283)
        Me.lblSecondPortOrientation.Name = "lblSecondPortOrientation"
        Me.lblSecondPortOrientation.Size = New System.Drawing.Size(120, 13)
        Me.lblSecondPortOrientation.TabIndex = 154
        Me.lblSecondPortOrientation.Text = "Second Port Orientation"
        '
        'txtRequiredNoOfPorts
        '
        Me.txtRequiredNoOfPorts.AcceptEnterKeyAsTab = True
        Me.txtRequiredNoOfPorts.ApplyIFLColor = True
        Me.txtRequiredNoOfPorts.AssociateLabel = Nothing
        Me.txtRequiredNoOfPorts.DecimalValue = 2
        Me.txtRequiredNoOfPorts.IFLDataTag = Nothing
        Me.txtRequiredNoOfPorts.InvalidInputCharacters = ""
        Me.txtRequiredNoOfPorts.IsAllowNegative = False
        Me.txtRequiredNoOfPorts.LengthValue = 6
        Me.txtRequiredNoOfPorts.Location = New System.Drawing.Point(154, 280)
        Me.txtRequiredNoOfPorts.MaximumValue = 99999
        Me.txtRequiredNoOfPorts.MaxLength = 6
        Me.txtRequiredNoOfPorts.MinimumValue = 0
        Me.txtRequiredNoOfPorts.Name = "txtRequiredNoOfPorts"
        Me.txtRequiredNoOfPorts.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredNoOfPorts.StatusMessage = ""
        Me.txtRequiredNoOfPorts.StatusObject = Nothing
        Me.txtRequiredNoOfPorts.TabIndex = 152
        Me.txtRequiredNoOfPorts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNoOfPorts
        '
        Me.txtNoOfPorts.AcceptEnterKeyAsTab = True
        Me.txtNoOfPorts.ApplyIFLColor = True
        Me.txtNoOfPorts.AssociateLabel = Nothing
        Me.txtNoOfPorts.DecimalValue = 2
        Me.txtNoOfPorts.IFLDataTag = Nothing
        Me.txtNoOfPorts.InvalidInputCharacters = ""
        Me.txtNoOfPorts.IsAllowNegative = False
        Me.txtNoOfPorts.LengthValue = 6
        Me.txtNoOfPorts.Location = New System.Drawing.Point(78, 280)
        Me.txtNoOfPorts.MaximumValue = 99999
        Me.txtNoOfPorts.MaxLength = 6
        Me.txtNoOfPorts.MinimumValue = 0
        Me.txtNoOfPorts.Name = "txtNoOfPorts"
        Me.txtNoOfPorts.Size = New System.Drawing.Size(66, 20)
        Me.txtNoOfPorts.StatusMessage = ""
        Me.txtNoOfPorts.StatusObject = Nothing
        Me.txtNoOfPorts.TabIndex = 150
        Me.txtNoOfPorts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNoOfPorts
        '
        Me.lblNoOfPorts.AutoSize = True
        Me.lblNoOfPorts.Location = New System.Drawing.Point(12, 283)
        Me.lblNoOfPorts.Name = "lblNoOfPorts"
        Me.lblNoOfPorts.Size = New System.Drawing.Size(60, 13)
        Me.lblNoOfPorts.TabIndex = 151
        Me.lblNoOfPorts.Text = "No of Ports"
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
        Me.txtRequiredPortSize.Location = New System.Drawing.Point(154, 249)
        Me.txtRequiredPortSize.MaximumValue = 99999
        Me.txtRequiredPortSize.MaxLength = 6
        Me.txtRequiredPortSize.MinimumValue = 0
        Me.txtRequiredPortSize.Name = "txtRequiredPortSize"
        Me.txtRequiredPortSize.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredPortSize.StatusMessage = ""
        Me.txtRequiredPortSize.StatusObject = Nothing
        Me.txtRequiredPortSize.TabIndex = 149
        Me.txtRequiredPortSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.txtPortSize.Location = New System.Drawing.Point(78, 249)
        Me.txtPortSize.MaximumValue = 99999
        Me.txtPortSize.MaxLength = 6
        Me.txtPortSize.MinimumValue = 0
        Me.txtPortSize.Name = "txtPortSize"
        Me.txtPortSize.Size = New System.Drawing.Size(66, 20)
        Me.txtPortSize.StatusMessage = ""
        Me.txtPortSize.StatusObject = Nothing
        Me.txtPortSize.TabIndex = 147
        Me.txtPortSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPortSize
        '
        Me.lblPortSize.AutoSize = True
        Me.lblPortSize.Location = New System.Drawing.Point(12, 252)
        Me.lblPortSize.Name = "lblPortSize"
        Me.lblPortSize.Size = New System.Drawing.Size(49, 13)
        Me.lblPortSize.TabIndex = 148
        Me.lblPortSize.Text = "Port Size"
        '
        'lblRequired
        '
        Me.lblRequired.AutoSize = True
        Me.lblRequired.Location = New System.Drawing.Point(159, 185)
        Me.lblRequired.Name = "lblRequired"
        Me.lblRequired.Size = New System.Drawing.Size(50, 13)
        Me.lblRequired.TabIndex = 146
        Me.lblRequired.Text = "Required"
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
        Me.txtRequiredPortType.Location = New System.Drawing.Point(154, 215)
        Me.txtRequiredPortType.MaximumValue = 99999
        Me.txtRequiredPortType.MaxLength = 6
        Me.txtRequiredPortType.MinimumValue = 0
        Me.txtRequiredPortType.Name = "txtRequiredPortType"
        Me.txtRequiredPortType.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredPortType.StatusMessage = ""
        Me.txtRequiredPortType.StatusObject = Nothing
        Me.txtRequiredPortType.TabIndex = 143
        Me.txtRequiredPortType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.txtRequiredCost.Location = New System.Drawing.Point(463, 249)
        Me.txtRequiredCost.MaximumValue = 99999
        Me.txtRequiredCost.MaxLength = 6
        Me.txtRequiredCost.MinimumValue = 0
        Me.txtRequiredCost.Name = "txtRequiredCost"
        Me.txtRequiredCost.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredCost.StatusMessage = ""
        Me.txtRequiredCost.StatusObject = Nothing
        Me.txtRequiredCost.TabIndex = 145
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
        Me.txtRequiredSwingClearance.Location = New System.Drawing.Point(463, 215)
        Me.txtRequiredSwingClearance.MaximumValue = 99999
        Me.txtRequiredSwingClearance.MaxLength = 6
        Me.txtRequiredSwingClearance.MinimumValue = 0
        Me.txtRequiredSwingClearance.Name = "txtRequiredSwingClearance"
        Me.txtRequiredSwingClearance.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredSwingClearance.StatusMessage = ""
        Me.txtRequiredSwingClearance.StatusObject = Nothing
        Me.txtRequiredSwingClearance.TabIndex = 144
        Me.txtRequiredSwingClearance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredThreadDiameter
        '
        Me.txtRequiredThreadDiameter.AcceptEnterKeyAsTab = True
        Me.txtRequiredThreadDiameter.ApplyIFLColor = True
        Me.txtRequiredThreadDiameter.AssociateLabel = Nothing
        Me.txtRequiredThreadDiameter.DecimalValue = 2
        Me.txtRequiredThreadDiameter.IFLDataTag = Nothing
        Me.txtRequiredThreadDiameter.InvalidInputCharacters = ""
        Me.txtRequiredThreadDiameter.IsAllowNegative = False
        Me.txtRequiredThreadDiameter.LengthValue = 6
        Me.txtRequiredThreadDiameter.Location = New System.Drawing.Point(463, 182)
        Me.txtRequiredThreadDiameter.MaximumValue = 99999
        Me.txtRequiredThreadDiameter.MaxLength = 6
        Me.txtRequiredThreadDiameter.MinimumValue = 0
        Me.txtRequiredThreadDiameter.Name = "txtRequiredThreadDiameter"
        Me.txtRequiredThreadDiameter.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredThreadDiameter.StatusMessage = ""
        Me.txtRequiredThreadDiameter.StatusObject = Nothing
        Me.txtRequiredThreadDiameter.TabIndex = 142
        Me.txtRequiredThreadDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.txtCost.Location = New System.Drawing.Point(385, 248)
        Me.txtCost.MaximumValue = 99999
        Me.txtCost.MaxLength = 6
        Me.txtCost.MinimumValue = 0
        Me.txtCost.Name = "txtCost"
        Me.txtCost.Size = New System.Drawing.Size(66, 20)
        Me.txtCost.StatusMessage = ""
        Me.txtCost.StatusObject = Nothing
        Me.txtCost.TabIndex = 138
        Me.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCost
        '
        Me.lblCost.AutoSize = True
        Me.lblCost.Location = New System.Drawing.Point(261, 251)
        Me.lblCost.Name = "lblCost"
        Me.lblCost.Size = New System.Drawing.Size(28, 13)
        Me.lblCost.TabIndex = 139
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
        Me.txtSwingClearance.Location = New System.Drawing.Point(385, 215)
        Me.txtSwingClearance.MaximumValue = 99999
        Me.txtSwingClearance.MaxLength = 6
        Me.txtSwingClearance.MinimumValue = 0
        Me.txtSwingClearance.Name = "txtSwingClearance"
        Me.txtSwingClearance.Size = New System.Drawing.Size(66, 20)
        Me.txtSwingClearance.StatusMessage = ""
        Me.txtSwingClearance.StatusObject = Nothing
        Me.txtSwingClearance.TabIndex = 136
        Me.txtSwingClearance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSwingClearance
        '
        Me.lblSwingClearance.AutoSize = True
        Me.lblSwingClearance.Location = New System.Drawing.Point(261, 218)
        Me.lblSwingClearance.Name = "lblSwingClearance"
        Me.lblSwingClearance.Size = New System.Drawing.Size(87, 13)
        Me.lblSwingClearance.TabIndex = 137
        Me.lblSwingClearance.Text = "Swing Clearance"
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
        Me.txtPortType.Location = New System.Drawing.Point(78, 215)
        Me.txtPortType.MaximumValue = 99999
        Me.txtPortType.MaxLength = 6
        Me.txtPortType.MinimumValue = 0
        Me.txtPortType.Name = "txtPortType"
        Me.txtPortType.Size = New System.Drawing.Size(66, 20)
        Me.txtPortType.StatusMessage = ""
        Me.txtPortType.StatusObject = Nothing
        Me.txtPortType.TabIndex = 134
        Me.txtPortType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPortType
        '
        Me.lblPortType.AutoSize = True
        Me.lblPortType.Location = New System.Drawing.Point(12, 218)
        Me.lblPortType.Name = "lblPortType"
        Me.lblPortType.Size = New System.Drawing.Size(53, 13)
        Me.lblPortType.TabIndex = 135
        Me.lblPortType.Text = "Port Type"
        '
        'txtThreadDiameter
        '
        Me.txtThreadDiameter.AcceptEnterKeyAsTab = True
        Me.txtThreadDiameter.ApplyIFLColor = True
        Me.txtThreadDiameter.AssociateLabel = Nothing
        Me.txtThreadDiameter.DecimalValue = 2
        Me.txtThreadDiameter.IFLDataTag = Nothing
        Me.txtThreadDiameter.InvalidInputCharacters = ""
        Me.txtThreadDiameter.IsAllowNegative = False
        Me.txtThreadDiameter.LengthValue = 6
        Me.txtThreadDiameter.Location = New System.Drawing.Point(385, 182)
        Me.txtThreadDiameter.MaximumValue = 99999
        Me.txtThreadDiameter.MaxLength = 6
        Me.txtThreadDiameter.MinimumValue = 0
        Me.txtThreadDiameter.Name = "txtThreadDiameter"
        Me.txtThreadDiameter.Size = New System.Drawing.Size(66, 20)
        Me.txtThreadDiameter.StatusMessage = ""
        Me.txtThreadDiameter.StatusObject = Nothing
        Me.txtThreadDiameter.TabIndex = 132
        Me.txtThreadDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblThreadDiameter
        '
        Me.lblThreadDiameter.AutoSize = True
        Me.lblThreadDiameter.Location = New System.Drawing.Point(261, 185)
        Me.lblThreadDiameter.Name = "lblThreadDiameter"
        Me.lblThreadDiameter.Size = New System.Drawing.Size(86, 13)
        Me.lblThreadDiameter.TabIndex = 133
        Me.lblThreadDiameter.Text = "Thread Diameter"
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
        'lvwThreadedEndListView
        '
        Me.lvwThreadedEndListView.FullRowSelect = True
        Me.lvwThreadedEndListView.GridLines = True
        Me.lvwThreadedEndListView.Location = New System.Drawing.Point(6, 33)
        Me.lvwThreadedEndListView.MultiSelect = False
        Me.lvwThreadedEndListView.Name = "lvwThreadedEndListView"
        Me.lvwThreadedEndListView.Scrollable = False
        Me.lvwThreadedEndListView.Size = New System.Drawing.Size(369, 122)
        Me.lvwThreadedEndListView.TabIndex = 1
        Me.lvwThreadedEndListView.UseCompatibleStateImageBehavior = False
        Me.lvwThreadedEndListView.View = System.Windows.Forms.View.Details
        '
        'lbThreadedEndCasting
        '
        Me.lbThreadedEndCasting.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lbThreadedEndCasting.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbThreadedEndCasting.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbThreadedEndCasting.GradientColorOne = System.Drawing.Color.Olive
        Me.lbThreadedEndCasting.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lbThreadedEndCasting.Location = New System.Drawing.Point(-3, 0)
        Me.lbThreadedEndCasting.Name = "lbThreadedEndCasting"
        Me.lbThreadedEndCasting.Size = New System.Drawing.Size(546, 19)
        Me.lbThreadedEndCasting.TabIndex = 110
        Me.lbThreadedEndCasting.Text = "Existing Threaded End Casting Details"
        Me.lbThreadedEndCasting.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblBackGround.Size = New System.Drawing.Size(578, 370)
        Me.lblBackGround.TabIndex = 119
        Me.lblBackGround.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmThreadedEndCastingYes_PortIntegral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(900, 650)
        Me.ControlBox = False
        Me.Controls.Add(Me.grbCastingListView)
        Me.Controls.Add(Me.lblBackGround)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmThreadedEndCastingYes_PortIntegral"
        Me.Text = "ThreadedEndCastingYes_PortIntegral"
        Me.grbCastingListView.ResumeLayout(False)
        Me.grbCastingListView.PerformLayout()
        CType(Me.picCastingYes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbCastingListView As System.Windows.Forms.GroupBox
    Friend WithEvents lblRequired As System.Windows.Forms.Label
    Friend WithEvents txtRequiredPortType As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredCost As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredSwingClearance As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredThreadDiameter As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtCost As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblCost As System.Windows.Forms.Label
    Friend WithEvents txtSwingClearance As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSwingClearance As System.Windows.Forms.Label
    Friend WithEvents txtPortType As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblPortType As System.Windows.Forms.Label
    Friend WithEvents txtThreadDiameter As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblThreadDiameter As System.Windows.Forms.Label
    Friend WithEvents btnPicInformation As System.Windows.Forms.Button
    Friend WithEvents picCastingYes As System.Windows.Forms.PictureBox
    Friend WithEvents lvwThreadedEndListView As Monarch_WeldedCylinder_01_09_09.clsListViewMIL
    Friend WithEvents lbThreadedEndCasting As LabelGradient.LabelGradient
    Friend WithEvents lblBackGround As LabelGradient.LabelGradient
    Friend WithEvents txtRequiredSecondPortOrientation As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtSecondPortOrientation As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSecondPortOrientation As System.Windows.Forms.Label
    Friend WithEvents txtRequiredNoOfPorts As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtNoOfPorts As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblNoOfPorts As System.Windows.Forms.Label
    Friend WithEvents txtRequiredPortSize As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtPortSize As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblPortSize As System.Windows.Forms.Label
    Friend WithEvents lblUseSelectedThreadedEnd As System.Windows.Forms.Label
    Friend WithEvents rdbUseSelectedThreadedEndNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbUseSelectedThreadedEndYes As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
