<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportRodEnd
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
        Me.LabelGradient5 = New LabelGradient.LabelGradient
        Me.LabelGradient4 = New LabelGradient.LabelGradient
        Me.LabelGradient3 = New LabelGradient.LabelGradient
        Me.LabelGradient2 = New LabelGradient.LabelGradient
        Me.grpContractDetails = New System.Windows.Forms.GroupBox
        Me.gbConnectionType = New System.Windows.Forms.GroupBox
        Me.IflTextBox2 = New IFLCustomUILayer.IFLTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.IflTextBox1 = New IFLCustomUILayer.IFLTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbConnectionType = New IFLCustomUILayer.IFLComboBox
        Me.lblConnectionType = New System.Windows.Forms.Label
        Me.txtRodEndPinHoleToRodStopDistance = New IFLCustomUILayer.IFLTextBox
        Me.lblRodEndPinHoleToRodStopDistance = New System.Windows.Forms.Label
        Me.btnAccept = New System.Windows.Forms.Button
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.lblRodEndDetails = New LabelGradient.LabelGradient
        Me.lblGradientContractDetails = New LabelGradient.LabelGradient
        Me.ofdImportRodEnd = New System.Windows.Forms.OpenFileDialog
        Me.grpContractDetails.SuspendLayout()
        Me.gbConnectionType.SuspendLayout()
        Me.SuspendLayout()
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
        Me.LabelGradient5.Size = New System.Drawing.Size(973, 11)
        Me.LabelGradient5.TabIndex = 131
        Me.LabelGradient5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelGradient4
        '
        Me.LabelGradient4.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient4.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelGradient4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient4.GradientColorOne = System.Drawing.Color.Honeydew
        Me.LabelGradient4.GradientColorTwo = System.Drawing.Color.Olive
        Me.LabelGradient4.Location = New System.Drawing.Point(983, 0)
        Me.LabelGradient4.Name = "LabelGradient4"
        Me.LabelGradient4.Size = New System.Drawing.Size(10, 611)
        Me.LabelGradient4.TabIndex = 130
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
        Me.LabelGradient3.Size = New System.Drawing.Size(10, 611)
        Me.LabelGradient3.TabIndex = 129
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
        Me.LabelGradient2.Location = New System.Drawing.Point(0, 611)
        Me.LabelGradient2.Name = "LabelGradient2"
        Me.LabelGradient2.Size = New System.Drawing.Size(993, 11)
        Me.LabelGradient2.TabIndex = 128
        Me.LabelGradient2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grpContractDetails
        '
        Me.grpContractDetails.BackColor = System.Drawing.Color.Ivory
        Me.grpContractDetails.Controls.Add(Me.gbConnectionType)
        Me.grpContractDetails.Controls.Add(Me.cmbConnectionType)
        Me.grpContractDetails.Controls.Add(Me.lblConnectionType)
        Me.grpContractDetails.Controls.Add(Me.txtRodEndPinHoleToRodStopDistance)
        Me.grpContractDetails.Controls.Add(Me.lblRodEndPinHoleToRodStopDistance)
        Me.grpContractDetails.Controls.Add(Me.btnAccept)
        Me.grpContractDetails.Controls.Add(Me.btnBrowse)
        Me.grpContractDetails.Controls.Add(Me.lblRodEndDetails)
        Me.grpContractDetails.Location = New System.Drawing.Point(262, 235)
        Me.grpContractDetails.Name = "grpContractDetails"
        Me.grpContractDetails.Size = New System.Drawing.Size(469, 177)
        Me.grpContractDetails.TabIndex = 133
        Me.grpContractDetails.TabStop = False
        '
        'gbConnectionType
        '
        Me.gbConnectionType.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gbConnectionType.Controls.Add(Me.IflTextBox2)
        Me.gbConnectionType.Controls.Add(Me.Label2)
        Me.gbConnectionType.Controls.Add(Me.IflTextBox1)
        Me.gbConnectionType.Controls.Add(Me.Label1)
        Me.gbConnectionType.Location = New System.Drawing.Point(6, 95)
        Me.gbConnectionType.Name = "gbConnectionType"
        Me.gbConnectionType.Size = New System.Drawing.Size(457, 36)
        Me.gbConnectionType.TabIndex = 117
        Me.gbConnectionType.TabStop = False
        '
        'IflTextBox2
        '
        Me.IflTextBox2.AcceptEnterKeyAsTab = True
        Me.IflTextBox2.ApplyIFLColor = True
        Me.IflTextBox2.AssociateLabel = Nothing
        Me.IflTextBox2.IFLDataTag = Nothing
        Me.IflTextBox2.InvalidInputCharacters = ""
        Me.IflTextBox2.Location = New System.Drawing.Point(345, 10)
        Me.IflTextBox2.MaxLength = 32
        Me.IflTextBox2.Name = "IflTextBox2"
        Me.IflTextBox2.Size = New System.Drawing.Size(93, 20)
        Me.IflTextBox2.StatusMessage = ""
        Me.IflTextBox2.StatusObject = Nothing
        Me.IflTextBox2.TabIndex = 120
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(240, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 119
        Me.Label2.Text = "label2"
        '
        'IflTextBox1
        '
        Me.IflTextBox1.AcceptEnterKeyAsTab = True
        Me.IflTextBox1.ApplyIFLColor = True
        Me.IflTextBox1.AssociateLabel = Nothing
        Me.IflTextBox1.IFLDataTag = Nothing
        Me.IflTextBox1.InvalidInputCharacters = ""
        Me.IflTextBox1.Location = New System.Drawing.Point(130, 10)
        Me.IflTextBox1.MaxLength = 32
        Me.IflTextBox1.Name = "IflTextBox1"
        Me.IflTextBox1.Size = New System.Drawing.Size(93, 20)
        Me.IflTextBox1.StatusMessage = ""
        Me.IflTextBox1.StatusObject = Nothing
        Me.IflTextBox1.TabIndex = 118
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "Label1"
        '
        'cmbConnectionType
        '
        Me.cmbConnectionType.AcceptEnterKeyAsTab = True
        Me.cmbConnectionType.AssociateLabel = Nothing
        Me.cmbConnectionType.BackColor = System.Drawing.Color.White
        Me.cmbConnectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbConnectionType.FormattingEnabled = True
        Me.cmbConnectionType.IFLDataTag = Nothing
        Me.cmbConnectionType.Location = New System.Drawing.Point(267, 68)
        Me.cmbConnectionType.Name = "cmbConnectionType"
        Me.cmbConnectionType.Size = New System.Drawing.Size(152, 21)
        Me.cmbConnectionType.StatusMessage = Nothing
        Me.cmbConnectionType.StatusObject = Nothing
        Me.cmbConnectionType.TabIndex = 115
        '
        'lblConnectionType
        '
        Me.lblConnectionType.AutoSize = True
        Me.lblConnectionType.Location = New System.Drawing.Point(47, 71)
        Me.lblConnectionType.Name = "lblConnectionType"
        Me.lblConnectionType.Size = New System.Drawing.Size(88, 13)
        Me.lblConnectionType.TabIndex = 116
        Me.lblConnectionType.Text = "Connection Type"
        '
        'txtRodEndPinHoleToRodStopDistance
        '
        Me.txtRodEndPinHoleToRodStopDistance.AcceptEnterKeyAsTab = True
        Me.txtRodEndPinHoleToRodStopDistance.ApplyIFLColor = True
        Me.txtRodEndPinHoleToRodStopDistance.AssociateLabel = Nothing
        Me.txtRodEndPinHoleToRodStopDistance.IFLDataTag = Nothing
        Me.txtRodEndPinHoleToRodStopDistance.InvalidInputCharacters = ""
        Me.txtRodEndPinHoleToRodStopDistance.Location = New System.Drawing.Point(267, 37)
        Me.txtRodEndPinHoleToRodStopDistance.MaxLength = 32
        Me.txtRodEndPinHoleToRodStopDistance.Name = "txtRodEndPinHoleToRodStopDistance"
        Me.txtRodEndPinHoleToRodStopDistance.Size = New System.Drawing.Size(152, 20)
        Me.txtRodEndPinHoleToRodStopDistance.StatusMessage = ""
        Me.txtRodEndPinHoleToRodStopDistance.StatusObject = Nothing
        Me.txtRodEndPinHoleToRodStopDistance.TabIndex = 25
        '
        'lblRodEndPinHoleToRodStopDistance
        '
        Me.lblRodEndPinHoleToRodStopDistance.AutoSize = True
        Me.lblRodEndPinHoleToRodStopDistance.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!)
        Me.lblRodEndPinHoleToRodStopDistance.Location = New System.Drawing.Point(50, 39)
        Me.lblRodEndPinHoleToRodStopDistance.Name = "lblRodEndPinHoleToRodStopDistance"
        Me.lblRodEndPinHoleToRodStopDistance.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblRodEndPinHoleToRodStopDistance.Size = New System.Drawing.Size(211, 15)
        Me.lblRodEndPinHoleToRodStopDistance.TabIndex = 26
        Me.lblRodEndPinHoleToRodStopDistance.Text = "Rod End Pin Hole to Rod Stop Distance"
        '
        'btnAccept
        '
        Me.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnAccept.Location = New System.Drawing.Point(305, 140)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(90, 25)
        Me.btnAccept.TabIndex = 24
        Me.btnAccept.Text = "Accept"
        Me.btnAccept.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnBrowse.Location = New System.Drawing.Point(191, 140)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(90, 25)
        Me.btnBrowse.TabIndex = 23
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'lblRodEndDetails
        '
        Me.lblRodEndDetails.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblRodEndDetails.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblRodEndDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRodEndDetails.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblRodEndDetails.GradientColorOne = System.Drawing.Color.Olive
        Me.lblRodEndDetails.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblRodEndDetails.Location = New System.Drawing.Point(-3, 0)
        Me.lblRodEndDetails.Name = "lblRodEndDetails"
        Me.lblRodEndDetails.Size = New System.Drawing.Size(472, 21)
        Me.lblRodEndDetails.TabIndex = 20
        Me.lblRodEndDetails.Text = "Rod End Details"
        Me.lblRodEndDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGradientContractDetails
        '
        Me.lblGradientContractDetails.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblGradientContractDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGradientContractDetails.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGradientContractDetails.GradientColorOne = System.Drawing.Color.DarkGoldenrod
        Me.lblGradientContractDetails.GradientColorTwo = System.Drawing.Color.DarkGoldenrod
        Me.lblGradientContractDetails.Location = New System.Drawing.Point(246, 223)
        Me.lblGradientContractDetails.Name = "lblGradientContractDetails"
        Me.lblGradientContractDetails.Size = New System.Drawing.Size(501, 197)
        Me.lblGradientContractDetails.TabIndex = 132
        Me.lblGradientContractDetails.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ofdImportRodEnd
        '
        Me.ofdImportRodEnd.FileName = "OpenFileDialog1"
        '
        'frmImportRodEnd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(993, 622)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpContractDetails)
        Me.Controls.Add(Me.lblGradientContractDetails)
        Me.Controls.Add(Me.LabelGradient5)
        Me.Controls.Add(Me.LabelGradient4)
        Me.Controls.Add(Me.LabelGradient3)
        Me.Controls.Add(Me.LabelGradient2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmImportRodEnd"
        Me.Text = "frmImportRodEnd"
        Me.grpContractDetails.ResumeLayout(False)
        Me.grpContractDetails.PerformLayout()
        Me.gbConnectionType.ResumeLayout(False)
        Me.gbConnectionType.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelGradient5 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient4 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient3 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient2 As LabelGradient.LabelGradient
    Friend WithEvents grpContractDetails As System.Windows.Forms.GroupBox
    Friend WithEvents btnAccept As System.Windows.Forms.Button
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents lblRodEndDetails As LabelGradient.LabelGradient
    Friend WithEvents lblGradientContractDetails As LabelGradient.LabelGradient
    Friend WithEvents txtRodEndPinHoleToRodStopDistance As IFLCustomUILayer.IFLTextBox
    Friend WithEvents lblRodEndPinHoleToRodStopDistance As System.Windows.Forms.Label
    Friend WithEvents ofdImportRodEnd As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmbConnectionType As IFLCustomUILayer.IFLComboBox
    Friend WithEvents lblConnectionType As System.Windows.Forms.Label
    Friend WithEvents gbConnectionType As System.Windows.Forms.GroupBox
    Friend WithEvents IflTextBox2 As IFLCustomUILayer.IFLTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents IflTextBox1 As IFLCustomUILayer.IFLTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
