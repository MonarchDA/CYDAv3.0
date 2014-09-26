<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPortDetails
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
        Me.lblPortDetailsIndex = New LabelGradient.LabelGradient
        Me.LabelGradient4 = New LabelGradient.LabelGradient
        Me.LabelGradient3 = New LabelGradient.LabelGradient
        Me.LabelGradient2 = New LabelGradient.LabelGradient
        Me.grbPortDetails = New System.Windows.Forms.GroupBox
        Me.btnBrowsePort_BaseEnd = New System.Windows.Forms.Button
        Me.txtSecondPortOrientationBaseEnd = New IFLCustomUILayer.IFLNumericBox
        Me.txtFirstPortOrientationBaseEnd = New IFLCustomUILayer.IFLNumericBox
        Me.cmbPortFacingBaseEnd = New IFLCustomUILayer.IFLComboBox
        Me.lblPortFacingBaseEnd = New System.Windows.Forms.Label
        Me.lblSecondPortOrientationBaseEnd = New System.Windows.Forms.Label
        Me.lblFirstPortOrientationBaseEnd = New System.Windows.Forms.Label
        Me.cmbPortSizeBaseEnd = New IFLCustomUILayer.IFLComboBox
        Me.lblPortSizeBaseEnd = New System.Windows.Forms.Label
        Me.cmbOrificeSizeBaseEnd = New IFLCustomUILayer.IFLComboBox
        Me.lblOrificeSizeBaseEnd = New System.Windows.Forms.Label
        Me.cmbPortAngleBaseEnd = New IFLCustomUILayer.IFLComboBox
        Me.lblPortAngleBaseEnd = New System.Windows.Forms.Label
        Me.cmbPortTypeBaseEnd = New IFLCustomUILayer.IFLComboBox
        Me.lblPortTypeBaseEnd = New System.Windows.Forms.Label
        Me.cmbNoofPortsBaseEnd = New IFLCustomUILayer.IFLComboBox
        Me.lblNoofPortsBaseEnd = New System.Windows.Forms.Label
        Me.lblBaseEndPortDetails = New LabelGradient.LabelGradient
        Me.LabelGradient5 = New LabelGradient.LabelGradient
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnBrowsePort_RodEnd = New System.Windows.Forms.Button
        Me.txtSecondPortOrientationRodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.txtFirstPortOrientationRodEnd = New IFLCustomUILayer.IFLNumericBox
        Me.chkRodEndPortSelection = New System.Windows.Forms.CheckBox
        Me.cmbPortFacingRodEnd = New IFLCustomUILayer.IFLComboBox
        Me.lblPortFacingRodEnd = New System.Windows.Forms.Label
        Me.lblSecondPortOrientationRodEnd = New System.Windows.Forms.Label
        Me.lblFirstPortOrientationRodEnd = New System.Windows.Forms.Label
        Me.cmbPortSizeRodEnd = New IFLCustomUILayer.IFLComboBox
        Me.lblPortSizeRodEnd = New System.Windows.Forms.Label
        Me.cmbOrificeSizeRodEnd = New IFLCustomUILayer.IFLComboBox
        Me.lblOrificeSizeRodEnd = New System.Windows.Forms.Label
        Me.cmbPortAngleRodEnd = New IFLCustomUILayer.IFLComboBox
        Me.lblPortAngleRodEnd = New System.Windows.Forms.Label
        Me.cmbPortTypeRodEnd = New IFLCustomUILayer.IFLComboBox
        Me.lblPortTypeRodEnd = New System.Windows.Forms.Label
        Me.cmbNoofPortsRodEnd = New IFLCustomUILayer.IFLComboBox
        Me.lblNoofPortsRodEnd = New System.Windows.Forms.Label
        Me.lblRodEndPortDetails = New LabelGradient.LabelGradient
        Me.LabelGradient6 = New LabelGradient.LabelGradient
        Me.ofdPort = New System.Windows.Forms.OpenFileDialog
        Me.grbPortDetails.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblPortDetailsIndex
        '
        Me.lblPortDetailsIndex.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblPortDetailsIndex.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPortDetailsIndex.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPortDetailsIndex.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPortDetailsIndex.GradientColorOne = System.Drawing.Color.Olive
        Me.lblPortDetailsIndex.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblPortDetailsIndex.Location = New System.Drawing.Point(20, 0)
        Me.lblPortDetailsIndex.Name = "lblPortDetailsIndex"
        Me.lblPortDetailsIndex.Size = New System.Drawing.Size(994, 19)
        Me.lblPortDetailsIndex.TabIndex = 37
        Me.lblPortDetailsIndex.Text = "Port Details"
        Me.lblPortDetailsIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelGradient4
        '
        Me.LabelGradient4.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient4.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelGradient4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient4.GradientColorOne = System.Drawing.Color.Olive
        Me.LabelGradient4.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient4.Location = New System.Drawing.Point(1014, 0)
        Me.LabelGradient4.Name = "LabelGradient4"
        Me.LabelGradient4.Size = New System.Drawing.Size(22, 761)
        Me.LabelGradient4.TabIndex = 36
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
        Me.LabelGradient3.Size = New System.Drawing.Size(20, 761)
        Me.LabelGradient3.TabIndex = 35
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
        Me.LabelGradient2.Location = New System.Drawing.Point(0, 761)
        Me.LabelGradient2.Name = "LabelGradient2"
        Me.LabelGradient2.Size = New System.Drawing.Size(1036, 19)
        Me.LabelGradient2.TabIndex = 34
        Me.LabelGradient2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grbPortDetails
        '
        Me.grbPortDetails.BackColor = System.Drawing.Color.Ivory
        Me.grbPortDetails.Controls.Add(Me.btnBrowsePort_BaseEnd)
        Me.grbPortDetails.Controls.Add(Me.txtSecondPortOrientationBaseEnd)
        Me.grbPortDetails.Controls.Add(Me.txtFirstPortOrientationBaseEnd)
        Me.grbPortDetails.Controls.Add(Me.cmbPortFacingBaseEnd)
        Me.grbPortDetails.Controls.Add(Me.lblPortFacingBaseEnd)
        Me.grbPortDetails.Controls.Add(Me.lblSecondPortOrientationBaseEnd)
        Me.grbPortDetails.Controls.Add(Me.lblFirstPortOrientationBaseEnd)
        Me.grbPortDetails.Controls.Add(Me.cmbPortSizeBaseEnd)
        Me.grbPortDetails.Controls.Add(Me.lblPortSizeBaseEnd)
        Me.grbPortDetails.Controls.Add(Me.cmbOrificeSizeBaseEnd)
        Me.grbPortDetails.Controls.Add(Me.lblOrificeSizeBaseEnd)
        Me.grbPortDetails.Controls.Add(Me.cmbPortAngleBaseEnd)
        Me.grbPortDetails.Controls.Add(Me.lblPortAngleBaseEnd)
        Me.grbPortDetails.Controls.Add(Me.cmbPortTypeBaseEnd)
        Me.grbPortDetails.Controls.Add(Me.lblPortTypeBaseEnd)
        Me.grbPortDetails.Controls.Add(Me.cmbNoofPortsBaseEnd)
        Me.grbPortDetails.Controls.Add(Me.lblNoofPortsBaseEnd)
        Me.grbPortDetails.Controls.Add(Me.lblBaseEndPortDetails)
        Me.grbPortDetails.Location = New System.Drawing.Point(50, 47)
        Me.grbPortDetails.Name = "grbPortDetails"
        Me.grbPortDetails.Size = New System.Drawing.Size(703, 166)
        Me.grbPortDetails.TabIndex = 0
        Me.grbPortDetails.TabStop = False
        '
        'btnBrowsePort_BaseEnd
        '
        Me.btnBrowsePort_BaseEnd.Location = New System.Drawing.Point(512, 117)
        Me.btnBrowsePort_BaseEnd.Name = "btnBrowsePort_BaseEnd"
        Me.btnBrowsePort_BaseEnd.Size = New System.Drawing.Size(87, 23)
        Me.btnBrowsePort_BaseEnd.TabIndex = 19
        Me.btnBrowsePort_BaseEnd.Text = "Import Port"
        Me.btnBrowsePort_BaseEnd.UseVisualStyleBackColor = True
        '
        'txtSecondPortOrientationBaseEnd
        '
        Me.txtSecondPortOrientationBaseEnd.AcceptEnterKeyAsTab = True
        Me.txtSecondPortOrientationBaseEnd.ApplyIFLColor = True
        Me.txtSecondPortOrientationBaseEnd.AssociateLabel = Nothing
        Me.txtSecondPortOrientationBaseEnd.DecimalValue = 2
        Me.txtSecondPortOrientationBaseEnd.IFLDataTag = Nothing
        Me.txtSecondPortOrientationBaseEnd.InvalidInputCharacters = ""
        Me.txtSecondPortOrientationBaseEnd.IsAllowNegative = False
        Me.txtSecondPortOrientationBaseEnd.LengthValue = 6
        Me.txtSecondPortOrientationBaseEnd.Location = New System.Drawing.Point(571, 82)
        Me.txtSecondPortOrientationBaseEnd.MaximumValue = 360
        Me.txtSecondPortOrientationBaseEnd.MaxLength = 10
        Me.txtSecondPortOrientationBaseEnd.MinimumValue = 0
        Me.txtSecondPortOrientationBaseEnd.Name = "txtSecondPortOrientationBaseEnd"
        Me.txtSecondPortOrientationBaseEnd.Size = New System.Drawing.Size(98, 20)
        Me.txtSecondPortOrientationBaseEnd.StatusMessage = ""
        Me.txtSecondPortOrientationBaseEnd.StatusObject = Nothing
        Me.txtSecondPortOrientationBaseEnd.TabIndex = 6
        Me.txtSecondPortOrientationBaseEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFirstPortOrientationBaseEnd
        '
        Me.txtFirstPortOrientationBaseEnd.AcceptEnterKeyAsTab = True
        Me.txtFirstPortOrientationBaseEnd.ApplyIFLColor = True
        Me.txtFirstPortOrientationBaseEnd.AssociateLabel = Nothing
        Me.txtFirstPortOrientationBaseEnd.DecimalValue = 2
        Me.txtFirstPortOrientationBaseEnd.IFLDataTag = Nothing
        Me.txtFirstPortOrientationBaseEnd.InvalidInputCharacters = ""
        Me.txtFirstPortOrientationBaseEnd.IsAllowNegative = False
        Me.txtFirstPortOrientationBaseEnd.LengthValue = 6
        Me.txtFirstPortOrientationBaseEnd.Location = New System.Drawing.Point(323, 82)
        Me.txtFirstPortOrientationBaseEnd.MaximumValue = 360
        Me.txtFirstPortOrientationBaseEnd.MaxLength = 10
        Me.txtFirstPortOrientationBaseEnd.MinimumValue = 0
        Me.txtFirstPortOrientationBaseEnd.Name = "txtFirstPortOrientationBaseEnd"
        Me.txtFirstPortOrientationBaseEnd.Size = New System.Drawing.Size(98, 20)
        Me.txtFirstPortOrientationBaseEnd.StatusMessage = ""
        Me.txtFirstPortOrientationBaseEnd.StatusObject = Nothing
        Me.txtFirstPortOrientationBaseEnd.TabIndex = 5
        Me.txtFirstPortOrientationBaseEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbPortFacingBaseEnd
        '
        Me.cmbPortFacingBaseEnd.AcceptEnterKeyAsTab = True
        Me.cmbPortFacingBaseEnd.AssociateLabel = Nothing
        Me.cmbPortFacingBaseEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPortFacingBaseEnd.FormattingEnabled = True
        Me.cmbPortFacingBaseEnd.IFLDataTag = Nothing
        Me.cmbPortFacingBaseEnd.Location = New System.Drawing.Point(85, 82)
        Me.cmbPortFacingBaseEnd.Name = "cmbPortFacingBaseEnd"
        Me.cmbPortFacingBaseEnd.Size = New System.Drawing.Size(98, 21)
        Me.cmbPortFacingBaseEnd.StatusMessage = Nothing
        Me.cmbPortFacingBaseEnd.StatusObject = Nothing
        Me.cmbPortFacingBaseEnd.TabIndex = 4
        '
        'lblPortFacingBaseEnd
        '
        Me.lblPortFacingBaseEnd.AutoSize = True
        Me.lblPortFacingBaseEnd.Location = New System.Drawing.Point(15, 85)
        Me.lblPortFacingBaseEnd.Name = "lblPortFacingBaseEnd"
        Me.lblPortFacingBaseEnd.Size = New System.Drawing.Size(61, 13)
        Me.lblPortFacingBaseEnd.TabIndex = 46
        Me.lblPortFacingBaseEnd.Text = "Port Facing"
        '
        'lblSecondPortOrientationBaseEnd
        '
        Me.lblSecondPortOrientationBaseEnd.AutoSize = True
        Me.lblSecondPortOrientationBaseEnd.Location = New System.Drawing.Point(445, 87)
        Me.lblSecondPortOrientationBaseEnd.Name = "lblSecondPortOrientationBaseEnd"
        Me.lblSecondPortOrientationBaseEnd.Size = New System.Drawing.Size(120, 13)
        Me.lblSecondPortOrientationBaseEnd.TabIndex = 44
        Me.lblSecondPortOrientationBaseEnd.Text = "Second Port Orientation"
        '
        'lblFirstPortOrientationBaseEnd
        '
        Me.lblFirstPortOrientationBaseEnd.AutoSize = True
        Me.lblFirstPortOrientationBaseEnd.Location = New System.Drawing.Point(215, 85)
        Me.lblFirstPortOrientationBaseEnd.Name = "lblFirstPortOrientationBaseEnd"
        Me.lblFirstPortOrientationBaseEnd.Size = New System.Drawing.Size(102, 13)
        Me.lblFirstPortOrientationBaseEnd.TabIndex = 42
        Me.lblFirstPortOrientationBaseEnd.Text = "First Port Orientation"
        '
        'cmbPortSizeBaseEnd
        '
        Me.cmbPortSizeBaseEnd.AcceptEnterKeyAsTab = True
        Me.cmbPortSizeBaseEnd.AssociateLabel = Nothing
        Me.cmbPortSizeBaseEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPortSizeBaseEnd.FormattingEnabled = True
        Me.cmbPortSizeBaseEnd.IFLDataTag = Nothing
        Me.cmbPortSizeBaseEnd.Location = New System.Drawing.Point(571, 44)
        Me.cmbPortSizeBaseEnd.Name = "cmbPortSizeBaseEnd"
        Me.cmbPortSizeBaseEnd.Size = New System.Drawing.Size(98, 21)
        Me.cmbPortSizeBaseEnd.StatusMessage = Nothing
        Me.cmbPortSizeBaseEnd.StatusObject = Nothing
        Me.cmbPortSizeBaseEnd.TabIndex = 3
        '
        'lblPortSizeBaseEnd
        '
        Me.lblPortSizeBaseEnd.AutoSize = True
        Me.lblPortSizeBaseEnd.Location = New System.Drawing.Point(445, 48)
        Me.lblPortSizeBaseEnd.Name = "lblPortSizeBaseEnd"
        Me.lblPortSizeBaseEnd.Size = New System.Drawing.Size(49, 13)
        Me.lblPortSizeBaseEnd.TabIndex = 37
        Me.lblPortSizeBaseEnd.Text = "Port Size"
        '
        'cmbOrificeSizeBaseEnd
        '
        Me.cmbOrificeSizeBaseEnd.AcceptEnterKeyAsTab = True
        Me.cmbOrificeSizeBaseEnd.AssociateLabel = Nothing
        Me.cmbOrificeSizeBaseEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrificeSizeBaseEnd.FormattingEnabled = True
        Me.cmbOrificeSizeBaseEnd.IFLDataTag = Nothing
        Me.cmbOrificeSizeBaseEnd.Location = New System.Drawing.Point(323, 119)
        Me.cmbOrificeSizeBaseEnd.Name = "cmbOrificeSizeBaseEnd"
        Me.cmbOrificeSizeBaseEnd.Size = New System.Drawing.Size(98, 21)
        Me.cmbOrificeSizeBaseEnd.StatusMessage = Nothing
        Me.cmbOrificeSizeBaseEnd.StatusObject = Nothing
        Me.cmbOrificeSizeBaseEnd.TabIndex = 8
        '
        'lblOrificeSizeBaseEnd
        '
        Me.lblOrificeSizeBaseEnd.AutoSize = True
        Me.lblOrificeSizeBaseEnd.Location = New System.Drawing.Point(215, 122)
        Me.lblOrificeSizeBaseEnd.Name = "lblOrificeSizeBaseEnd"
        Me.lblOrificeSizeBaseEnd.Size = New System.Drawing.Size(60, 13)
        Me.lblOrificeSizeBaseEnd.TabIndex = 29
        Me.lblOrificeSizeBaseEnd.Text = "Orifice Size"
        '
        'cmbPortAngleBaseEnd
        '
        Me.cmbPortAngleBaseEnd.AcceptEnterKeyAsTab = True
        Me.cmbPortAngleBaseEnd.AssociateLabel = Nothing
        Me.cmbPortAngleBaseEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPortAngleBaseEnd.FormattingEnabled = True
        Me.cmbPortAngleBaseEnd.IFLDataTag = Nothing
        Me.cmbPortAngleBaseEnd.Location = New System.Drawing.Point(85, 119)
        Me.cmbPortAngleBaseEnd.Name = "cmbPortAngleBaseEnd"
        Me.cmbPortAngleBaseEnd.Size = New System.Drawing.Size(98, 21)
        Me.cmbPortAngleBaseEnd.StatusMessage = Nothing
        Me.cmbPortAngleBaseEnd.StatusObject = Nothing
        Me.cmbPortAngleBaseEnd.TabIndex = 7
        '
        'lblPortAngleBaseEnd
        '
        Me.lblPortAngleBaseEnd.AutoSize = True
        Me.lblPortAngleBaseEnd.Location = New System.Drawing.Point(15, 122)
        Me.lblPortAngleBaseEnd.Name = "lblPortAngleBaseEnd"
        Me.lblPortAngleBaseEnd.Size = New System.Drawing.Size(56, 13)
        Me.lblPortAngleBaseEnd.TabIndex = 27
        Me.lblPortAngleBaseEnd.Text = "Port Angle"
        '
        'cmbPortTypeBaseEnd
        '
        Me.cmbPortTypeBaseEnd.AcceptEnterKeyAsTab = True
        Me.cmbPortTypeBaseEnd.AssociateLabel = Nothing
        Me.cmbPortTypeBaseEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPortTypeBaseEnd.FormattingEnabled = True
        Me.cmbPortTypeBaseEnd.IFLDataTag = Nothing
        Me.cmbPortTypeBaseEnd.Location = New System.Drawing.Point(323, 44)
        Me.cmbPortTypeBaseEnd.Name = "cmbPortTypeBaseEnd"
        Me.cmbPortTypeBaseEnd.Size = New System.Drawing.Size(98, 21)
        Me.cmbPortTypeBaseEnd.StatusMessage = Nothing
        Me.cmbPortTypeBaseEnd.StatusObject = Nothing
        Me.cmbPortTypeBaseEnd.TabIndex = 2
        '
        'lblPortTypeBaseEnd
        '
        Me.lblPortTypeBaseEnd.AutoSize = True
        Me.lblPortTypeBaseEnd.Location = New System.Drawing.Point(215, 48)
        Me.lblPortTypeBaseEnd.Name = "lblPortTypeBaseEnd"
        Me.lblPortTypeBaseEnd.Size = New System.Drawing.Size(53, 13)
        Me.lblPortTypeBaseEnd.TabIndex = 25
        Me.lblPortTypeBaseEnd.Text = "Port Type"
        '
        'cmbNoofPortsBaseEnd
        '
        Me.cmbNoofPortsBaseEnd.AcceptEnterKeyAsTab = True
        Me.cmbNoofPortsBaseEnd.AssociateLabel = Nothing
        Me.cmbNoofPortsBaseEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNoofPortsBaseEnd.FormattingEnabled = True
        Me.cmbNoofPortsBaseEnd.IFLDataTag = Nothing
        Me.cmbNoofPortsBaseEnd.Location = New System.Drawing.Point(85, 44)
        Me.cmbNoofPortsBaseEnd.Name = "cmbNoofPortsBaseEnd"
        Me.cmbNoofPortsBaseEnd.Size = New System.Drawing.Size(98, 21)
        Me.cmbNoofPortsBaseEnd.StatusMessage = Nothing
        Me.cmbNoofPortsBaseEnd.StatusObject = Nothing
        Me.cmbNoofPortsBaseEnd.TabIndex = 1
        '
        'lblNoofPortsBaseEnd
        '
        Me.lblNoofPortsBaseEnd.AutoSize = True
        Me.lblNoofPortsBaseEnd.Location = New System.Drawing.Point(15, 48)
        Me.lblNoofPortsBaseEnd.Name = "lblNoofPortsBaseEnd"
        Me.lblNoofPortsBaseEnd.Size = New System.Drawing.Size(60, 13)
        Me.lblNoofPortsBaseEnd.TabIndex = 21
        Me.lblNoofPortsBaseEnd.Text = "No of Ports"
        '
        'lblBaseEndPortDetails
        '
        Me.lblBaseEndPortDetails.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblBaseEndPortDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBaseEndPortDetails.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBaseEndPortDetails.GradientColorOne = System.Drawing.Color.Olive
        Me.lblBaseEndPortDetails.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblBaseEndPortDetails.Location = New System.Drawing.Point(0, 0)
        Me.lblBaseEndPortDetails.Name = "lblBaseEndPortDetails"
        Me.lblBaseEndPortDetails.Size = New System.Drawing.Size(703, 19)
        Me.lblBaseEndPortDetails.TabIndex = 20
        Me.lblBaseEndPortDetails.Text = "BaseEnd Port Details"
        Me.lblBaseEndPortDetails.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelGradient5
        '
        Me.LabelGradient5.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient5.GradientColorOne = System.Drawing.Color.DarkGoldenrod
        Me.LabelGradient5.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient5.Location = New System.Drawing.Point(26, 28)
        Me.LabelGradient5.Name = "LabelGradient5"
        Me.LabelGradient5.Size = New System.Drawing.Size(754, 205)
        Me.LabelGradient5.TabIndex = 39
        Me.LabelGradient5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Ivory
        Me.GroupBox1.Controls.Add(Me.btnBrowsePort_RodEnd)
        Me.GroupBox1.Controls.Add(Me.txtSecondPortOrientationRodEnd)
        Me.GroupBox1.Controls.Add(Me.txtFirstPortOrientationRodEnd)
        Me.GroupBox1.Controls.Add(Me.chkRodEndPortSelection)
        Me.GroupBox1.Controls.Add(Me.cmbPortFacingRodEnd)
        Me.GroupBox1.Controls.Add(Me.lblPortFacingRodEnd)
        Me.GroupBox1.Controls.Add(Me.lblSecondPortOrientationRodEnd)
        Me.GroupBox1.Controls.Add(Me.lblFirstPortOrientationRodEnd)
        Me.GroupBox1.Controls.Add(Me.cmbPortSizeRodEnd)
        Me.GroupBox1.Controls.Add(Me.lblPortSizeRodEnd)
        Me.GroupBox1.Controls.Add(Me.cmbOrificeSizeRodEnd)
        Me.GroupBox1.Controls.Add(Me.lblOrificeSizeRodEnd)
        Me.GroupBox1.Controls.Add(Me.cmbPortAngleRodEnd)
        Me.GroupBox1.Controls.Add(Me.lblPortAngleRodEnd)
        Me.GroupBox1.Controls.Add(Me.cmbPortTypeRodEnd)
        Me.GroupBox1.Controls.Add(Me.lblPortTypeRodEnd)
        Me.GroupBox1.Controls.Add(Me.cmbNoofPortsRodEnd)
        Me.GroupBox1.Controls.Add(Me.lblNoofPortsRodEnd)
        Me.GroupBox1.Controls.Add(Me.lblRodEndPortDetails)
        Me.GroupBox1.Location = New System.Drawing.Point(50, 257)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(703, 166)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'btnBrowsePort_RodEnd
        '
        Me.btnBrowsePort_RodEnd.Location = New System.Drawing.Point(525, 132)
        Me.btnBrowsePort_RodEnd.Name = "btnBrowsePort_RodEnd"
        Me.btnBrowsePort_RodEnd.Size = New System.Drawing.Size(87, 23)
        Me.btnBrowsePort_RodEnd.TabIndex = 20
        Me.btnBrowsePort_RodEnd.Text = "Import Port"
        Me.btnBrowsePort_RodEnd.UseVisualStyleBackColor = True
        '
        'txtSecondPortOrientationRodEnd
        '
        Me.txtSecondPortOrientationRodEnd.AcceptEnterKeyAsTab = True
        Me.txtSecondPortOrientationRodEnd.ApplyIFLColor = True
        Me.txtSecondPortOrientationRodEnd.AssociateLabel = Nothing
        Me.txtSecondPortOrientationRodEnd.DecimalValue = 2
        Me.txtSecondPortOrientationRodEnd.IFLDataTag = Nothing
        Me.txtSecondPortOrientationRodEnd.InvalidInputCharacters = ""
        Me.txtSecondPortOrientationRodEnd.IsAllowNegative = False
        Me.txtSecondPortOrientationRodEnd.LengthValue = 6
        Me.txtSecondPortOrientationRodEnd.Location = New System.Drawing.Point(571, 94)
        Me.txtSecondPortOrientationRodEnd.MaximumValue = 360
        Me.txtSecondPortOrientationRodEnd.MaxLength = 10
        Me.txtSecondPortOrientationRodEnd.MinimumValue = 0
        Me.txtSecondPortOrientationRodEnd.Name = "txtSecondPortOrientationRodEnd"
        Me.txtSecondPortOrientationRodEnd.Size = New System.Drawing.Size(98, 20)
        Me.txtSecondPortOrientationRodEnd.StatusMessage = ""
        Me.txtSecondPortOrientationRodEnd.StatusObject = Nothing
        Me.txtSecondPortOrientationRodEnd.TabIndex = 16
        Me.txtSecondPortOrientationRodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFirstPortOrientationRodEnd
        '
        Me.txtFirstPortOrientationRodEnd.AcceptEnterKeyAsTab = True
        Me.txtFirstPortOrientationRodEnd.ApplyIFLColor = True
        Me.txtFirstPortOrientationRodEnd.AssociateLabel = Nothing
        Me.txtFirstPortOrientationRodEnd.DecimalValue = 2
        Me.txtFirstPortOrientationRodEnd.IFLDataTag = Nothing
        Me.txtFirstPortOrientationRodEnd.InvalidInputCharacters = ""
        Me.txtFirstPortOrientationRodEnd.IsAllowNegative = False
        Me.txtFirstPortOrientationRodEnd.LengthValue = 6
        Me.txtFirstPortOrientationRodEnd.Location = New System.Drawing.Point(323, 94)
        Me.txtFirstPortOrientationRodEnd.MaximumValue = 360
        Me.txtFirstPortOrientationRodEnd.MaxLength = 10
        Me.txtFirstPortOrientationRodEnd.MinimumValue = 0
        Me.txtFirstPortOrientationRodEnd.Name = "txtFirstPortOrientationRodEnd"
        Me.txtFirstPortOrientationRodEnd.Size = New System.Drawing.Size(98, 20)
        Me.txtFirstPortOrientationRodEnd.StatusMessage = ""
        Me.txtFirstPortOrientationRodEnd.StatusObject = Nothing
        Me.txtFirstPortOrientationRodEnd.TabIndex = 15
        Me.txtFirstPortOrientationRodEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkRodEndPortSelection
        '
        Me.chkRodEndPortSelection.AutoSize = True
        Me.chkRodEndPortSelection.Location = New System.Drawing.Point(283, 31)
        Me.chkRodEndPortSelection.Name = "chkRodEndPortSelection"
        Me.chkRodEndPortSelection.Size = New System.Drawing.Size(138, 17)
        Me.chkRodEndPortSelection.TabIndex = 10
        Me.chkRodEndPortSelection.Text = "Port Same as Base End"
        Me.chkRodEndPortSelection.UseVisualStyleBackColor = True
        '
        'cmbPortFacingRodEnd
        '
        Me.cmbPortFacingRodEnd.AcceptEnterKeyAsTab = True
        Me.cmbPortFacingRodEnd.AssociateLabel = Nothing
        Me.cmbPortFacingRodEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPortFacingRodEnd.FormattingEnabled = True
        Me.cmbPortFacingRodEnd.IFLDataTag = Nothing
        Me.cmbPortFacingRodEnd.Location = New System.Drawing.Point(85, 94)
        Me.cmbPortFacingRodEnd.Name = "cmbPortFacingRodEnd"
        Me.cmbPortFacingRodEnd.Size = New System.Drawing.Size(98, 21)
        Me.cmbPortFacingRodEnd.StatusMessage = Nothing
        Me.cmbPortFacingRodEnd.StatusObject = Nothing
        Me.cmbPortFacingRodEnd.TabIndex = 14
        '
        'lblPortFacingRodEnd
        '
        Me.lblPortFacingRodEnd.AutoSize = True
        Me.lblPortFacingRodEnd.Location = New System.Drawing.Point(15, 97)
        Me.lblPortFacingRodEnd.Name = "lblPortFacingRodEnd"
        Me.lblPortFacingRodEnd.Size = New System.Drawing.Size(61, 13)
        Me.lblPortFacingRodEnd.TabIndex = 46
        Me.lblPortFacingRodEnd.Text = "Port Facing"
        '
        'lblSecondPortOrientationRodEnd
        '
        Me.lblSecondPortOrientationRodEnd.AutoSize = True
        Me.lblSecondPortOrientationRodEnd.Location = New System.Drawing.Point(445, 97)
        Me.lblSecondPortOrientationRodEnd.Name = "lblSecondPortOrientationRodEnd"
        Me.lblSecondPortOrientationRodEnd.Size = New System.Drawing.Size(120, 13)
        Me.lblSecondPortOrientationRodEnd.TabIndex = 44
        Me.lblSecondPortOrientationRodEnd.Text = "Second Port Orientation"
        '
        'lblFirstPortOrientationRodEnd
        '
        Me.lblFirstPortOrientationRodEnd.AutoSize = True
        Me.lblFirstPortOrientationRodEnd.Location = New System.Drawing.Point(215, 97)
        Me.lblFirstPortOrientationRodEnd.Name = "lblFirstPortOrientationRodEnd"
        Me.lblFirstPortOrientationRodEnd.Size = New System.Drawing.Size(102, 13)
        Me.lblFirstPortOrientationRodEnd.TabIndex = 42
        Me.lblFirstPortOrientationRodEnd.Text = "First Port Orientation"
        '
        'cmbPortSizeRodEnd
        '
        Me.cmbPortSizeRodEnd.AcceptEnterKeyAsTab = True
        Me.cmbPortSizeRodEnd.AssociateLabel = Nothing
        Me.cmbPortSizeRodEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPortSizeRodEnd.FormattingEnabled = True
        Me.cmbPortSizeRodEnd.IFLDataTag = Nothing
        Me.cmbPortSizeRodEnd.Location = New System.Drawing.Point(571, 53)
        Me.cmbPortSizeRodEnd.Name = "cmbPortSizeRodEnd"
        Me.cmbPortSizeRodEnd.Size = New System.Drawing.Size(98, 21)
        Me.cmbPortSizeRodEnd.StatusMessage = Nothing
        Me.cmbPortSizeRodEnd.StatusObject = Nothing
        Me.cmbPortSizeRodEnd.TabIndex = 13
        '
        'lblPortSizeRodEnd
        '
        Me.lblPortSizeRodEnd.AutoSize = True
        Me.lblPortSizeRodEnd.Location = New System.Drawing.Point(445, 57)
        Me.lblPortSizeRodEnd.Name = "lblPortSizeRodEnd"
        Me.lblPortSizeRodEnd.Size = New System.Drawing.Size(49, 13)
        Me.lblPortSizeRodEnd.TabIndex = 37
        Me.lblPortSizeRodEnd.Text = "Port Size"
        '
        'cmbOrificeSizeRodEnd
        '
        Me.cmbOrificeSizeRodEnd.AcceptEnterKeyAsTab = True
        Me.cmbOrificeSizeRodEnd.AssociateLabel = Nothing
        Me.cmbOrificeSizeRodEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrificeSizeRodEnd.FormattingEnabled = True
        Me.cmbOrificeSizeRodEnd.IFLDataTag = Nothing
        Me.cmbOrificeSizeRodEnd.Location = New System.Drawing.Point(323, 134)
        Me.cmbOrificeSizeRodEnd.Name = "cmbOrificeSizeRodEnd"
        Me.cmbOrificeSizeRodEnd.Size = New System.Drawing.Size(98, 21)
        Me.cmbOrificeSizeRodEnd.StatusMessage = Nothing
        Me.cmbOrificeSizeRodEnd.StatusObject = Nothing
        Me.cmbOrificeSizeRodEnd.TabIndex = 18
        '
        'lblOrificeSizeRodEnd
        '
        Me.lblOrificeSizeRodEnd.AutoSize = True
        Me.lblOrificeSizeRodEnd.Location = New System.Drawing.Point(215, 137)
        Me.lblOrificeSizeRodEnd.Name = "lblOrificeSizeRodEnd"
        Me.lblOrificeSizeRodEnd.Size = New System.Drawing.Size(60, 13)
        Me.lblOrificeSizeRodEnd.TabIndex = 29
        Me.lblOrificeSizeRodEnd.Text = "Orifice Size"
        '
        'cmbPortAngleRodEnd
        '
        Me.cmbPortAngleRodEnd.AcceptEnterKeyAsTab = True
        Me.cmbPortAngleRodEnd.AssociateLabel = Nothing
        Me.cmbPortAngleRodEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPortAngleRodEnd.FormattingEnabled = True
        Me.cmbPortAngleRodEnd.IFLDataTag = Nothing
        Me.cmbPortAngleRodEnd.Location = New System.Drawing.Point(85, 134)
        Me.cmbPortAngleRodEnd.Name = "cmbPortAngleRodEnd"
        Me.cmbPortAngleRodEnd.Size = New System.Drawing.Size(98, 21)
        Me.cmbPortAngleRodEnd.StatusMessage = Nothing
        Me.cmbPortAngleRodEnd.StatusObject = Nothing
        Me.cmbPortAngleRodEnd.TabIndex = 17
        '
        'lblPortAngleRodEnd
        '
        Me.lblPortAngleRodEnd.AutoSize = True
        Me.lblPortAngleRodEnd.Location = New System.Drawing.Point(15, 137)
        Me.lblPortAngleRodEnd.Name = "lblPortAngleRodEnd"
        Me.lblPortAngleRodEnd.Size = New System.Drawing.Size(56, 13)
        Me.lblPortAngleRodEnd.TabIndex = 27
        Me.lblPortAngleRodEnd.Text = "Port Angle"
        '
        'cmbPortTypeRodEnd
        '
        Me.cmbPortTypeRodEnd.AcceptEnterKeyAsTab = True
        Me.cmbPortTypeRodEnd.AssociateLabel = Nothing
        Me.cmbPortTypeRodEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPortTypeRodEnd.FormattingEnabled = True
        Me.cmbPortTypeRodEnd.IFLDataTag = Nothing
        Me.cmbPortTypeRodEnd.Location = New System.Drawing.Point(323, 53)
        Me.cmbPortTypeRodEnd.Name = "cmbPortTypeRodEnd"
        Me.cmbPortTypeRodEnd.Size = New System.Drawing.Size(98, 21)
        Me.cmbPortTypeRodEnd.StatusMessage = Nothing
        Me.cmbPortTypeRodEnd.StatusObject = Nothing
        Me.cmbPortTypeRodEnd.TabIndex = 12
        '
        'lblPortTypeRodEnd
        '
        Me.lblPortTypeRodEnd.AutoSize = True
        Me.lblPortTypeRodEnd.Location = New System.Drawing.Point(215, 57)
        Me.lblPortTypeRodEnd.Name = "lblPortTypeRodEnd"
        Me.lblPortTypeRodEnd.Size = New System.Drawing.Size(53, 13)
        Me.lblPortTypeRodEnd.TabIndex = 25
        Me.lblPortTypeRodEnd.Text = "Port Type"
        '
        'cmbNoofPortsRodEnd
        '
        Me.cmbNoofPortsRodEnd.AcceptEnterKeyAsTab = True
        Me.cmbNoofPortsRodEnd.AssociateLabel = Nothing
        Me.cmbNoofPortsRodEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNoofPortsRodEnd.FormattingEnabled = True
        Me.cmbNoofPortsRodEnd.IFLDataTag = Nothing
        Me.cmbNoofPortsRodEnd.Location = New System.Drawing.Point(85, 53)
        Me.cmbNoofPortsRodEnd.Name = "cmbNoofPortsRodEnd"
        Me.cmbNoofPortsRodEnd.Size = New System.Drawing.Size(98, 21)
        Me.cmbNoofPortsRodEnd.StatusMessage = Nothing
        Me.cmbNoofPortsRodEnd.StatusObject = Nothing
        Me.cmbNoofPortsRodEnd.TabIndex = 11
        '
        'lblNoofPortsRodEnd
        '
        Me.lblNoofPortsRodEnd.AutoSize = True
        Me.lblNoofPortsRodEnd.Location = New System.Drawing.Point(15, 57)
        Me.lblNoofPortsRodEnd.Name = "lblNoofPortsRodEnd"
        Me.lblNoofPortsRodEnd.Size = New System.Drawing.Size(60, 13)
        Me.lblNoofPortsRodEnd.TabIndex = 21
        Me.lblNoofPortsRodEnd.Text = "No of Ports"
        '
        'lblRodEndPortDetails
        '
        Me.lblRodEndPortDetails.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblRodEndPortDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRodEndPortDetails.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRodEndPortDetails.GradientColorOne = System.Drawing.Color.Olive
        Me.lblRodEndPortDetails.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblRodEndPortDetails.Location = New System.Drawing.Point(0, 0)
        Me.lblRodEndPortDetails.Name = "lblRodEndPortDetails"
        Me.lblRodEndPortDetails.Size = New System.Drawing.Size(703, 19)
        Me.lblRodEndPortDetails.TabIndex = 20
        Me.lblRodEndPortDetails.Text = "RodEnd Port Details"
        Me.lblRodEndPortDetails.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelGradient6
        '
        Me.LabelGradient6.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient6.GradientColorOne = System.Drawing.Color.DarkGoldenrod
        Me.LabelGradient6.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient6.Location = New System.Drawing.Point(26, 238)
        Me.LabelGradient6.Name = "LabelGradient6"
        Me.LabelGradient6.Size = New System.Drawing.Size(754, 205)
        Me.LabelGradient6.TabIndex = 41
        Me.LabelGradient6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ofdPort
        '
        Me.ofdPort.FileName = "OpenFileDialog1"
        '
        'frmPortDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1036, 780)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LabelGradient6)
        Me.Controls.Add(Me.grbPortDetails)
        Me.Controls.Add(Me.LabelGradient5)
        Me.Controls.Add(Me.lblPortDetailsIndex)
        Me.Controls.Add(Me.LabelGradient4)
        Me.Controls.Add(Me.LabelGradient3)
        Me.Controls.Add(Me.LabelGradient2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPortDetails"
        Me.Text = "frmPortDetails"
        Me.grbPortDetails.ResumeLayout(False)
        Me.grbPortDetails.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblPortDetailsIndex As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient4 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient3 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient2 As LabelGradient.LabelGradient
    Friend WithEvents grbPortDetails As System.Windows.Forms.GroupBox
    Friend WithEvents cmbPortSizeBaseEnd As IFLCustomUILayer.IFLComboBox
    Friend WithEvents lblPortSizeBaseEnd As System.Windows.Forms.Label
    Friend WithEvents cmbOrificeSizeBaseEnd As IFLCustomUILayer.IFLComboBox
    Friend WithEvents lblOrificeSizeBaseEnd As System.Windows.Forms.Label
    Friend WithEvents cmbPortAngleBaseEnd As IFLCustomUILayer.IFLComboBox
    Friend WithEvents lblPortAngleBaseEnd As System.Windows.Forms.Label
    Friend WithEvents cmbPortTypeBaseEnd As IFLCustomUILayer.IFLComboBox
    Friend WithEvents lblPortTypeBaseEnd As System.Windows.Forms.Label
    Friend WithEvents cmbNoofPortsBaseEnd As IFLCustomUILayer.IFLComboBox
    Friend WithEvents lblNoofPortsBaseEnd As System.Windows.Forms.Label
    Friend WithEvents lblBaseEndPortDetails As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient5 As LabelGradient.LabelGradient
    Friend WithEvents cmbPortFacingBaseEnd As IFLCustomUILayer.IFLComboBox
    Friend WithEvents lblPortFacingBaseEnd As System.Windows.Forms.Label
    Friend WithEvents lblSecondPortOrientationBaseEnd As System.Windows.Forms.Label
    Friend WithEvents lblFirstPortOrientationBaseEnd As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbPortFacingRodEnd As IFLCustomUILayer.IFLComboBox
    Friend WithEvents lblPortFacingRodEnd As System.Windows.Forms.Label
    Friend WithEvents lblSecondPortOrientationRodEnd As System.Windows.Forms.Label
    Friend WithEvents lblFirstPortOrientationRodEnd As System.Windows.Forms.Label
    Friend WithEvents cmbPortSizeRodEnd As IFLCustomUILayer.IFLComboBox
    Friend WithEvents lblPortSizeRodEnd As System.Windows.Forms.Label
    Friend WithEvents cmbOrificeSizeRodEnd As IFLCustomUILayer.IFLComboBox
    Friend WithEvents lblOrificeSizeRodEnd As System.Windows.Forms.Label
    Friend WithEvents cmbPortAngleRodEnd As IFLCustomUILayer.IFLComboBox
    Friend WithEvents lblPortAngleRodEnd As System.Windows.Forms.Label
    Friend WithEvents cmbPortTypeRodEnd As IFLCustomUILayer.IFLComboBox
    Friend WithEvents lblPortTypeRodEnd As System.Windows.Forms.Label
    Friend WithEvents cmbNoofPortsRodEnd As IFLCustomUILayer.IFLComboBox
    Friend WithEvents lblNoofPortsRodEnd As System.Windows.Forms.Label
    Friend WithEvents lblRodEndPortDetails As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient6 As LabelGradient.LabelGradient
    Friend WithEvents txtFirstPortOrientationBaseEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtSecondPortOrientationBaseEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents chkRodEndPortSelection As System.Windows.Forms.CheckBox
    Friend WithEvents txtSecondPortOrientationRodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtFirstPortOrientationRodEnd As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents btnBrowsePort_BaseEnd As System.Windows.Forms.Button
    Friend WithEvents btnBrowsePort_RodEnd As System.Windows.Forms.Button
    Friend WithEvents ofdPort As System.Windows.Forms.OpenFileDialog
End Class
