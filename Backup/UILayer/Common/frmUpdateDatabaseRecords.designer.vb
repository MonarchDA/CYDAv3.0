<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdateDatabaseRecords
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
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnUpdateToDatabase = New System.Windows.Forms.Button
        Me.lvwDatabaseRecordView = New System.Windows.Forms.ListView
        Me.cmbPortAngle = New IFLCustomUILayer.IFLComboBox
        Me.lblPortAngle = New System.Windows.Forms.Label
        Me.txtSearchString = New System.Windows.Forms.TextBox
        Me.lblSearch = New System.Windows.Forms.Label
        Me.cmbPortType = New IFLCustomUILayer.IFLComboBox
        Me.lblTypeOfPort = New System.Windows.Forms.Label
        Me.cmbEndPort = New IFLCustomUILayer.IFLComboBox
        Me.lblBaseEndPort = New System.Windows.Forms.Label
        Me.cmbSubConfiguration = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbConfiguration = New System.Windows.Forms.ComboBox
        Me.lblConfiguration = New System.Windows.Forms.Label
        Me.lbDatabaseRecord = New LabelGradient.LabelGradient
        Me.lblOrange = New LabelGradient.LabelGradient
        Me.lblGreen1 = New LabelGradient.LabelGradient
        Me.lblGreen2 = New LabelGradient.LabelGradient
        Me.lblGreen4 = New LabelGradient.LabelGradient
        Me.lblGreen3 = New LabelGradient.LabelGradient
        Me.grbCastingListView.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbCastingListView
        '
        Me.grbCastingListView.BackColor = System.Drawing.Color.Ivory
        Me.grbCastingListView.Controls.Add(Me.btnCancel)
        Me.grbCastingListView.Controls.Add(Me.btnUpdateToDatabase)
        Me.grbCastingListView.Controls.Add(Me.lvwDatabaseRecordView)
        Me.grbCastingListView.Controls.Add(Me.cmbPortAngle)
        Me.grbCastingListView.Controls.Add(Me.lblPortAngle)
        Me.grbCastingListView.Controls.Add(Me.txtSearchString)
        Me.grbCastingListView.Controls.Add(Me.lblSearch)
        Me.grbCastingListView.Controls.Add(Me.cmbPortType)
        Me.grbCastingListView.Controls.Add(Me.lblTypeOfPort)
        Me.grbCastingListView.Controls.Add(Me.cmbEndPort)
        Me.grbCastingListView.Controls.Add(Me.lblBaseEndPort)
        Me.grbCastingListView.Controls.Add(Me.cmbSubConfiguration)
        Me.grbCastingListView.Controls.Add(Me.Label1)
        Me.grbCastingListView.Controls.Add(Me.cmbConfiguration)
        Me.grbCastingListView.Controls.Add(Me.lblConfiguration)
        Me.grbCastingListView.Controls.Add(Me.lbDatabaseRecord)
        Me.grbCastingListView.Location = New System.Drawing.Point(31, 47)
        Me.grbCastingListView.Name = "grbCastingListView"
        Me.grbCastingListView.Size = New System.Drawing.Size(565, 363)
        Me.grbCastingListView.TabIndex = 122
        Me.grbCastingListView.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(429, 141)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(94, 20)
        Me.btnCancel.TabIndex = 125
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnUpdateToDatabase
        '
        Me.btnUpdateToDatabase.Location = New System.Drawing.Point(329, 141)
        Me.btnUpdateToDatabase.Name = "btnUpdateToDatabase"
        Me.btnUpdateToDatabase.Size = New System.Drawing.Size(94, 20)
        Me.btnUpdateToDatabase.TabIndex = 124
        Me.btnUpdateToDatabase.Text = "Update"
        Me.btnUpdateToDatabase.UseVisualStyleBackColor = True
        '
        'lvwDatabaseRecordView
        '
        Me.lvwDatabaseRecordView.GridLines = True
        Me.lvwDatabaseRecordView.Location = New System.Drawing.Point(47, 174)
        Me.lvwDatabaseRecordView.MultiSelect = False
        Me.lvwDatabaseRecordView.Name = "lvwDatabaseRecordView"
        Me.lvwDatabaseRecordView.Size = New System.Drawing.Size(476, 158)
        Me.lvwDatabaseRecordView.TabIndex = 123
        Me.lvwDatabaseRecordView.UseCompatibleStateImageBehavior = False
        Me.lvwDatabaseRecordView.View = System.Windows.Forms.View.Details
        '
        'cmbPortAngle
        '
        Me.cmbPortAngle.AcceptEnterKeyAsTab = True
        Me.cmbPortAngle.AssociateLabel = Nothing
        Me.cmbPortAngle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPortAngle.FormattingEnabled = True
        Me.cmbPortAngle.IFLDataTag = Nothing
        Me.cmbPortAngle.Location = New System.Drawing.Point(373, 86)
        Me.cmbPortAngle.Name = "cmbPortAngle"
        Me.cmbPortAngle.Size = New System.Drawing.Size(151, 21)
        Me.cmbPortAngle.StatusMessage = Nothing
        Me.cmbPortAngle.StatusObject = Nothing
        Me.cmbPortAngle.TabIndex = 121
        '
        'lblPortAngle
        '
        Me.lblPortAngle.AutoSize = True
        Me.lblPortAngle.Location = New System.Drawing.Point(295, 90)
        Me.lblPortAngle.Name = "lblPortAngle"
        Me.lblPortAngle.Size = New System.Drawing.Size(59, 13)
        Me.lblPortAngle.TabIndex = 122
        Me.lblPortAngle.Text = " Port Angle"
        '
        'txtSearchString
        '
        Me.txtSearchString.Location = New System.Drawing.Point(127, 141)
        Me.txtSearchString.Name = "txtSearchString"
        Me.txtSearchString.Size = New System.Drawing.Size(151, 20)
        Me.txtSearchString.TabIndex = 120
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(40, 145)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(47, 13)
        Me.lblSearch.TabIndex = 119
        Me.lblSearch.Text = "Search.."
        '
        'cmbPortType
        '
        Me.cmbPortType.AcceptEnterKeyAsTab = True
        Me.cmbPortType.AssociateLabel = Nothing
        Me.cmbPortType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPortType.FormattingEnabled = True
        Me.cmbPortType.IFLDataTag = Nothing
        Me.cmbPortType.Location = New System.Drawing.Point(373, 59)
        Me.cmbPortType.Name = "cmbPortType"
        Me.cmbPortType.Size = New System.Drawing.Size(151, 21)
        Me.cmbPortType.StatusMessage = Nothing
        Me.cmbPortType.StatusObject = Nothing
        Me.cmbPortType.TabIndex = 117
        '
        'lblTypeOfPort
        '
        Me.lblTypeOfPort.AutoSize = True
        Me.lblTypeOfPort.Location = New System.Drawing.Point(295, 63)
        Me.lblTypeOfPort.Name = "lblTypeOfPort"
        Me.lblTypeOfPort.Size = New System.Drawing.Size(56, 13)
        Me.lblTypeOfPort.TabIndex = 118
        Me.lblTypeOfPort.Text = " Port Type"
        '
        'cmbEndPort
        '
        Me.cmbEndPort.AcceptEnterKeyAsTab = True
        Me.cmbEndPort.AssociateLabel = Nothing
        Me.cmbEndPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEndPort.FormattingEnabled = True
        Me.cmbEndPort.IFLDataTag = Nothing
        Me.cmbEndPort.Location = New System.Drawing.Point(127, 62)
        Me.cmbEndPort.Name = "cmbEndPort"
        Me.cmbEndPort.Size = New System.Drawing.Size(151, 21)
        Me.cmbEndPort.StatusMessage = Nothing
        Me.cmbEndPort.StatusObject = Nothing
        Me.cmbEndPort.TabIndex = 115
        '
        'lblBaseEndPort
        '
        Me.lblBaseEndPort.AutoSize = True
        Me.lblBaseEndPort.Location = New System.Drawing.Point(40, 66)
        Me.lblBaseEndPort.Name = "lblBaseEndPort"
        Me.lblBaseEndPort.Size = New System.Drawing.Size(75, 13)
        Me.lblBaseEndPort.TabIndex = 116
        Me.lblBaseEndPort.Text = "Base End Port"
        '
        'cmbSubConfiguration
        '
        Me.cmbSubConfiguration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSubConfiguration.FormattingEnabled = True
        Me.cmbSubConfiguration.Location = New System.Drawing.Point(373, 32)
        Me.cmbSubConfiguration.Name = "cmbSubConfiguration"
        Me.cmbSubConfiguration.Size = New System.Drawing.Size(151, 21)
        Me.cmbSubConfiguration.TabIndex = 114
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(295, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 113
        Me.Label1.Text = "Configuration"
        '
        'cmbConfiguration
        '
        Me.cmbConfiguration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbConfiguration.FormattingEnabled = True
        Me.cmbConfiguration.Location = New System.Drawing.Point(127, 31)
        Me.cmbConfiguration.Name = "cmbConfiguration"
        Me.cmbConfiguration.Size = New System.Drawing.Size(151, 21)
        Me.cmbConfiguration.TabIndex = 112
        '
        'lblConfiguration
        '
        Me.lblConfiguration.AutoSize = True
        Me.lblConfiguration.Location = New System.Drawing.Point(40, 35)
        Me.lblConfiguration.Name = "lblConfiguration"
        Me.lblConfiguration.Size = New System.Drawing.Size(69, 13)
        Me.lblConfiguration.TabIndex = 111
        Me.lblConfiguration.Text = "Configuration"
        '
        'lbDatabaseRecord
        '
        Me.lbDatabaseRecord.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lbDatabaseRecord.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDatabaseRecord.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbDatabaseRecord.GradientColorOne = System.Drawing.Color.Olive
        Me.lbDatabaseRecord.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lbDatabaseRecord.Location = New System.Drawing.Point(0, 0)
        Me.lbDatabaseRecord.Name = "lbDatabaseRecord"
        Me.lbDatabaseRecord.Size = New System.Drawing.Size(565, 19)
        Me.lbDatabaseRecord.TabIndex = 110
        Me.lbDatabaseRecord.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblOrange
        '
        Me.lblOrange.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblOrange.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrange.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOrange.GradientColorOne = System.Drawing.Color.DarkGoldenrod
        Me.lblOrange.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblOrange.Location = New System.Drawing.Point(26, 28)
        Me.lblOrange.Name = "lblOrange"
        Me.lblOrange.Size = New System.Drawing.Size(578, 396)
        Me.lblOrange.TabIndex = 123
        Me.lblOrange.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblGreen1
        '
        Me.lblGreen1.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblGreen1.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblGreen1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGreen1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblGreen1.GradientColorOne = System.Drawing.Color.Olive
        Me.lblGreen1.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblGreen1.Location = New System.Drawing.Point(0, 0)
        Me.lblGreen1.Name = "lblGreen1"
        Me.lblGreen1.Size = New System.Drawing.Size(1036, 19)
        Me.lblGreen1.TabIndex = 124
        Me.lblGreen1.Text = "Casting Details"
        Me.lblGreen1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGreen2
        '
        Me.lblGreen2.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblGreen2.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblGreen2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGreen2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGreen2.GradientColorOne = System.Drawing.Color.Olive
        Me.lblGreen2.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblGreen2.Location = New System.Drawing.Point(1014, 19)
        Me.lblGreen2.Name = "lblGreen2"
        Me.lblGreen2.Size = New System.Drawing.Size(22, 761)
        Me.lblGreen2.TabIndex = 125
        Me.lblGreen2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblGreen4
        '
        Me.lblGreen4.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblGreen4.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblGreen4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGreen4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGreen4.GradientColorOne = System.Drawing.Color.Olive
        Me.lblGreen4.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblGreen4.Location = New System.Drawing.Point(0, 19)
        Me.lblGreen4.Name = "lblGreen4"
        Me.lblGreen4.Size = New System.Drawing.Size(20, 761)
        Me.lblGreen4.TabIndex = 126
        Me.lblGreen4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblGreen3
        '
        Me.lblGreen3.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblGreen3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblGreen3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGreen3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGreen3.GradientColorOne = System.Drawing.Color.Olive
        Me.lblGreen3.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblGreen3.Location = New System.Drawing.Point(20, 761)
        Me.lblGreen3.Name = "lblGreen3"
        Me.lblGreen3.Size = New System.Drawing.Size(994, 19)
        Me.lblGreen3.TabIndex = 127
        Me.lblGreen3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmUpdateDatabaseRecords
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1036, 780)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblGreen3)
        Me.Controls.Add(Me.lblGreen4)
        Me.Controls.Add(Me.lblGreen2)
        Me.Controls.Add(Me.lblGreen1)
        Me.Controls.Add(Me.grbCastingListView)
        Me.Controls.Add(Me.lblOrange)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmUpdateDatabaseRecords"
        Me.Text = "frmUpdateDatabaseRecords"
        Me.grbCastingListView.ResumeLayout(False)
        Me.grbCastingListView.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbCastingListView As System.Windows.Forms.GroupBox
    Friend WithEvents lbDatabaseRecord As LabelGradient.LabelGradient
    Friend WithEvents lblOrange As LabelGradient.LabelGradient
    Friend WithEvents lblConfiguration As System.Windows.Forms.Label
    Friend WithEvents cmbConfiguration As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSubConfiguration As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbEndPort As IFLCustomUILayer.IFLComboBox
    Friend WithEvents lblBaseEndPort As System.Windows.Forms.Label
    Friend WithEvents cmbPortType As IFLCustomUILayer.IFLComboBox
    Friend WithEvents lblTypeOfPort As System.Windows.Forms.Label
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtSearchString As System.Windows.Forms.TextBox
    Friend WithEvents cmbPortAngle As IFLCustomUILayer.IFLComboBox
    Friend WithEvents lblPortAngle As System.Windows.Forms.Label
    Friend WithEvents lvwDatabaseRecordView As System.Windows.Forms.ListView
    Friend WithEvents btnUpdateToDatabase As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblGreen1 As LabelGradient.LabelGradient
    Friend WithEvents lblGreen2 As LabelGradient.LabelGradient
    Friend WithEvents lblGreen4 As LabelGradient.LabelGradient
    Friend WithEvents lblGreen3 As LabelGradient.LabelGradient
End Class
