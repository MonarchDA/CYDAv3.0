<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportPorts
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
        Me.LabelGradient4 = New LabelGradient.LabelGradient
        Me.LabelGradient3 = New LabelGradient.LabelGradient
        Me.LabelGradient2 = New LabelGradient.LabelGradient
        Me.lblGradientContractDetails = New LabelGradient.LabelGradient
        Me.grpContractDetails = New System.Windows.Forms.GroupBox
        Me.txtOrificeSize = New IFLCustomUILayer.IFLTextBox
        Me.lblOrificeSize = New System.Windows.Forms.Label
        Me.btnAccept = New System.Windows.Forms.Button
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.txtPortODAtWeld = New IFLCustomUILayer.IFLTextBox
        Me.lblPortODAtWeld = New System.Windows.Forms.Label
        Me.txtPortHeight = New IFLCustomUILayer.IFLTextBox
        Me.lblPortHeight = New System.Windows.Forms.Label
        Me.lblPortEndType = New System.Windows.Forms.Label
        Me.lblPortsDetails = New LabelGradient.LabelGradient
        Me.cmbPortEndType = New IFLCustomUILayer.IFLComboBox
        Me.LabelGradient5 = New LabelGradient.LabelGradient
        Me.ofdPortDetails = New System.Windows.Forms.OpenFileDialog
        Me.grpContractDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelGradient4
        '
        Me.LabelGradient4.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient4.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelGradient4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient4.GradientColorOne = System.Drawing.Color.Honeydew
        Me.LabelGradient4.GradientColorTwo = System.Drawing.Color.Olive
        Me.LabelGradient4.Location = New System.Drawing.Point(935, 0)
        Me.LabelGradient4.Name = "LabelGradient4"
        Me.LabelGradient4.Size = New System.Drawing.Size(10, 503)
        Me.LabelGradient4.TabIndex = 118
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
        Me.LabelGradient3.Size = New System.Drawing.Size(10, 503)
        Me.LabelGradient3.TabIndex = 117
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
        Me.LabelGradient2.Location = New System.Drawing.Point(0, 503)
        Me.LabelGradient2.Name = "LabelGradient2"
        Me.LabelGradient2.Size = New System.Drawing.Size(945, 11)
        Me.LabelGradient2.TabIndex = 116
        Me.LabelGradient2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblGradientContractDetails
        '
        Me.lblGradientContractDetails.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblGradientContractDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGradientContractDetails.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGradientContractDetails.GradientColorOne = System.Drawing.Color.DarkGoldenrod
        Me.lblGradientContractDetails.GradientColorTwo = System.Drawing.Color.DarkGoldenrod
        Me.lblGradientContractDetails.Location = New System.Drawing.Point(233, 139)
        Me.lblGradientContractDetails.Name = "lblGradientContractDetails"
        Me.lblGradientContractDetails.Size = New System.Drawing.Size(478, 236)
        Me.lblGradientContractDetails.TabIndex = 120
        Me.lblGradientContractDetails.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grpContractDetails
        '
        Me.grpContractDetails.BackColor = System.Drawing.Color.Ivory
        Me.grpContractDetails.Controls.Add(Me.txtOrificeSize)
        Me.grpContractDetails.Controls.Add(Me.lblOrificeSize)
        Me.grpContractDetails.Controls.Add(Me.btnAccept)
        Me.grpContractDetails.Controls.Add(Me.btnBrowse)
        Me.grpContractDetails.Controls.Add(Me.txtPortODAtWeld)
        Me.grpContractDetails.Controls.Add(Me.lblPortODAtWeld)
        Me.grpContractDetails.Controls.Add(Me.txtPortHeight)
        Me.grpContractDetails.Controls.Add(Me.lblPortHeight)
        Me.grpContractDetails.Controls.Add(Me.lblPortEndType)
        Me.grpContractDetails.Controls.Add(Me.lblPortsDetails)
        Me.grpContractDetails.Controls.Add(Me.cmbPortEndType)
        Me.grpContractDetails.Location = New System.Drawing.Point(236, 150)
        Me.grpContractDetails.Name = "grpContractDetails"
        Me.grpContractDetails.Size = New System.Drawing.Size(469, 211)
        Me.grpContractDetails.TabIndex = 121
        Me.grpContractDetails.TabStop = False
        '
        'txtOrificeSize
        '
        Me.txtOrificeSize.AcceptEnterKeyAsTab = True
        Me.txtOrificeSize.ApplyIFLColor = True
        Me.txtOrificeSize.AssociateLabel = Nothing
        Me.txtOrificeSize.IFLDataTag = Nothing
        Me.txtOrificeSize.InvalidInputCharacters = ""
        Me.txtOrificeSize.Location = New System.Drawing.Point(177, 145)
        Me.txtOrificeSize.MaxLength = 32
        Me.txtOrificeSize.Name = "txtOrificeSize"
        Me.txtOrificeSize.Size = New System.Drawing.Size(238, 20)
        Me.txtOrificeSize.StatusMessage = ""
        Me.txtOrificeSize.StatusObject = Nothing
        Me.txtOrificeSize.TabIndex = 26
        '
        'lblOrificeSize
        '
        Me.lblOrificeSize.AutoSize = True
        Me.lblOrificeSize.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!)
        Me.lblOrificeSize.Location = New System.Drawing.Point(56, 147)
        Me.lblOrificeSize.Name = "lblOrificeSize"
        Me.lblOrificeSize.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblOrificeSize.Size = New System.Drawing.Size(67, 15)
        Me.lblOrificeSize.TabIndex = 25
        Me.lblOrificeSize.Text = "Orifice Size"
        '
        'btnAccept
        '
        Me.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAccept.Location = New System.Drawing.Point(293, 180)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(90, 25)
        Me.btnAccept.TabIndex = 24
        Me.btnAccept.Text = "Accept"
        Me.btnAccept.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnBrowse.Location = New System.Drawing.Point(177, 180)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(90, 25)
        Me.btnBrowse.TabIndex = 23
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtPortODAtWeld
        '
        Me.txtPortODAtWeld.AcceptEnterKeyAsTab = True
        Me.txtPortODAtWeld.ApplyIFLColor = True
        Me.txtPortODAtWeld.AssociateLabel = Nothing
        Me.txtPortODAtWeld.IFLDataTag = Nothing
        Me.txtPortODAtWeld.InvalidInputCharacters = ""
        Me.txtPortODAtWeld.Location = New System.Drawing.Point(177, 107)
        Me.txtPortODAtWeld.MaxLength = 32
        Me.txtPortODAtWeld.Name = "txtPortODAtWeld"
        Me.txtPortODAtWeld.Size = New System.Drawing.Size(238, 20)
        Me.txtPortODAtWeld.StatusMessage = ""
        Me.txtPortODAtWeld.StatusObject = Nothing
        Me.txtPortODAtWeld.TabIndex = 21
        '
        'lblPortODAtWeld
        '
        Me.lblPortODAtWeld.AutoSize = True
        Me.lblPortODAtWeld.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!)
        Me.lblPortODAtWeld.Location = New System.Drawing.Point(56, 109)
        Me.lblPortODAtWeld.Name = "lblPortODAtWeld"
        Me.lblPortODAtWeld.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblPortODAtWeld.Size = New System.Drawing.Size(92, 15)
        Me.lblPortODAtWeld.TabIndex = 22
        Me.lblPortODAtWeld.Text = "Port OD At Weld"
        '
        'txtPortHeight
        '
        Me.txtPortHeight.AcceptEnterKeyAsTab = True
        Me.txtPortHeight.ApplyIFLColor = True
        Me.txtPortHeight.AssociateLabel = Nothing
        Me.txtPortHeight.IFLDataTag = Nothing
        Me.txtPortHeight.InvalidInputCharacters = ""
        Me.txtPortHeight.Location = New System.Drawing.Point(177, 69)
        Me.txtPortHeight.MaxLength = 32
        Me.txtPortHeight.Name = "txtPortHeight"
        Me.txtPortHeight.Size = New System.Drawing.Size(238, 20)
        Me.txtPortHeight.StatusMessage = ""
        Me.txtPortHeight.StatusObject = Nothing
        Me.txtPortHeight.TabIndex = 3
        '
        'lblPortHeight
        '
        Me.lblPortHeight.AutoSize = True
        Me.lblPortHeight.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!)
        Me.lblPortHeight.Location = New System.Drawing.Point(56, 71)
        Me.lblPortHeight.Name = "lblPortHeight"
        Me.lblPortHeight.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblPortHeight.Size = New System.Drawing.Size(67, 15)
        Me.lblPortHeight.TabIndex = 4
        Me.lblPortHeight.Text = "Port Height"
        '
        'lblPortEndType
        '
        Me.lblPortEndType.AutoSize = True
        Me.lblPortEndType.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPortEndType.Location = New System.Drawing.Point(53, 33)
        Me.lblPortEndType.Name = "lblPortEndType"
        Me.lblPortEndType.Size = New System.Drawing.Size(81, 15)
        Me.lblPortEndType.TabIndex = 0
        Me.lblPortEndType.Text = "Port End Type"
        '
        'lblPortsDetails
        '
        Me.lblPortsDetails.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblPortsDetails.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblPortsDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPortsDetails.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblPortsDetails.GradientColorOne = System.Drawing.Color.Olive
        Me.lblPortsDetails.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblPortsDetails.Location = New System.Drawing.Point(-3, 0)
        Me.lblPortsDetails.Name = "lblPortsDetails"
        Me.lblPortsDetails.Size = New System.Drawing.Size(472, 21)
        Me.lblPortsDetails.TabIndex = 20
        Me.lblPortsDetails.Text = "Ports Details"
        Me.lblPortsDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbPortEndType
        '
        Me.cmbPortEndType.AcceptEnterKeyAsTab = True
        Me.cmbPortEndType.AssociateLabel = Nothing
        Me.cmbPortEndType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPortEndType.FormattingEnabled = True
        Me.cmbPortEndType.IFLDataTag = Nothing
        Me.cmbPortEndType.ItemHeight = 13
        Me.cmbPortEndType.Location = New System.Drawing.Point(177, 31)
        Me.cmbPortEndType.Name = "cmbPortEndType"
        Me.cmbPortEndType.Size = New System.Drawing.Size(238, 21)
        Me.cmbPortEndType.StatusMessage = Nothing
        Me.cmbPortEndType.StatusObject = Nothing
        Me.cmbPortEndType.TabIndex = 2
        '
        'LabelGradient5
        '
        Me.LabelGradient5.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient5.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelGradient5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient5.GradientColorOne = System.Drawing.Color.Olive
        Me.LabelGradient5.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient5.Location = New System.Drawing.Point(10, 0)
        Me.LabelGradient5.Name = "LabelGradient5"
        Me.LabelGradient5.Size = New System.Drawing.Size(925, 11)
        Me.LabelGradient5.TabIndex = 119
        Me.LabelGradient5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ofdPortDetails
        '
        Me.ofdPortDetails.FileName = "OpenFileDialog1"
        '
        'frmImportPorts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(945, 514)
        Me.Controls.Add(Me.grpContractDetails)
        Me.Controls.Add(Me.lblGradientContractDetails)
        Me.Controls.Add(Me.LabelGradient5)
        Me.Controls.Add(Me.LabelGradient4)
        Me.Controls.Add(Me.LabelGradient3)
        Me.Controls.Add(Me.LabelGradient2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmImportPorts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.grpContractDetails.ResumeLayout(False)
        Me.grpContractDetails.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelGradient4 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient3 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient2 As LabelGradient.LabelGradient
    Friend WithEvents lblGradientContractDetails As LabelGradient.LabelGradient
    Friend WithEvents grpContractDetails As System.Windows.Forms.GroupBox
    Friend WithEvents txtPortODAtWeld As IFLCustomUILayer.IFLTextBox
    Friend WithEvents lblPortODAtWeld As System.Windows.Forms.Label
    Friend WithEvents txtPortHeight As IFLCustomUILayer.IFLTextBox
    Friend WithEvents lblPortHeight As System.Windows.Forms.Label
    Friend WithEvents lblPortEndType As System.Windows.Forms.Label
    Friend WithEvents lblPortsDetails As LabelGradient.LabelGradient
    Friend WithEvents cmbPortEndType As IFLCustomUILayer.IFLComboBox
    Friend WithEvents LabelGradient5 As LabelGradient.LabelGradient
    Friend WithEvents btnAccept As System.Windows.Forms.Button
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents ofdPortDetails As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtOrificeSize As IFLCustomUILayer.IFLTextBox
    Friend WithEvents lblOrificeSize As System.Windows.Forms.Label
End Class
