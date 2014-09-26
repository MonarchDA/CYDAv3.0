<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSLCastingNo_PortInTube
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
        Me.plnFabrication_Casting = New System.Windows.Forms.Panel()
        Me.btnRadioButtonsSelectionMessage = New System.Windows.Forms.Button()
        Me.cmbLugInTubeDiameter = New IFLCustomUILayer.IFLComboBox()
        Me.lblLugWithInTubeDiameter = New System.Windows.Forms.Label()
        Me.lblCastingNotMatched = New LabelGradient.LabelGradient()
        Me.lblBackGround = New LabelGradient.LabelGradient()
        Me.rdbDesignACasting = New System.Windows.Forms.RadioButton()
        Me.rdbFabrication = New System.Windows.Forms.RadioButton()
        Me.grbCastingNotMatched = New System.Windows.Forms.GroupBox()
        Me.chkSingleLugFabricationRequired = New System.Windows.Forms.CheckBox()
        Me.plnFabrication_Casting.SuspendLayout()
        Me.grbCastingNotMatched.SuspendLayout()
        Me.SuspendLayout()
        '
        'plnFabrication_Casting
        '
        Me.plnFabrication_Casting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.plnFabrication_Casting.Controls.Add(Me.btnRadioButtonsSelectionMessage)
        Me.plnFabrication_Casting.Location = New System.Drawing.Point(6, 53)
        Me.plnFabrication_Casting.Name = "plnFabrication_Casting"
        Me.plnFabrication_Casting.Size = New System.Drawing.Size(583, 451)
        Me.plnFabrication_Casting.TabIndex = 22
        '
        'btnRadioButtonsSelectionMessage
        '
        Me.btnRadioButtonsSelectionMessage.BackColor = System.Drawing.Color.Transparent
        Me.btnRadioButtonsSelectionMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRadioButtonsSelectionMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRadioButtonsSelectionMessage.Location = New System.Drawing.Point(160, 210)
        Me.btnRadioButtonsSelectionMessage.Name = "btnRadioButtonsSelectionMessage"
        Me.btnRadioButtonsSelectionMessage.Size = New System.Drawing.Size(259, 39)
        Me.btnRadioButtonsSelectionMessage.TabIndex = 109
        Me.btnRadioButtonsSelectionMessage.Text = "Select any one of the radio buttons"
        Me.btnRadioButtonsSelectionMessage.UseVisualStyleBackColor = False
        Me.btnRadioButtonsSelectionMessage.Visible = False
        '
        'cmbLugInTubeDiameter
        '
        Me.cmbLugInTubeDiameter.AcceptEnterKeyAsTab = True
        Me.cmbLugInTubeDiameter.AssociateLabel = Nothing
        Me.cmbLugInTubeDiameter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLugInTubeDiameter.FormattingEnabled = True
        Me.cmbLugInTubeDiameter.IFLDataTag = Nothing
        Me.cmbLugInTubeDiameter.Location = New System.Drawing.Point(415, 29)
        Me.cmbLugInTubeDiameter.Name = "cmbLugInTubeDiameter"
        Me.cmbLugInTubeDiameter.Size = New System.Drawing.Size(98, 21)
        Me.cmbLugInTubeDiameter.StatusMessage = Nothing
        Me.cmbLugInTubeDiameter.StatusObject = Nothing
        Me.cmbLugInTubeDiameter.TabIndex = 168
        '
        'lblLugWithInTubeDiameter
        '
        Me.lblLugWithInTubeDiameter.AutoSize = True
        Me.lblLugWithInTubeDiameter.Location = New System.Drawing.Point(310, 32)
        Me.lblLugWithInTubeDiameter.Name = "lblLugWithInTubeDiameter"
        Me.lblLugWithInTubeDiameter.Size = New System.Drawing.Size(96, 13)
        Me.lblLugWithInTubeDiameter.TabIndex = 169
        Me.lblLugWithInTubeDiameter.Text = "Lug withinTubeDia"
        '
        'lblCastingNotMatched
        '
        Me.lblCastingNotMatched.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblCastingNotMatched.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCastingNotMatched.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCastingNotMatched.GradientColorOne = System.Drawing.Color.Olive
        Me.lblCastingNotMatched.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblCastingNotMatched.Location = New System.Drawing.Point(-3, 0)
        Me.lblCastingNotMatched.Name = "lblCastingNotMatched"
        Me.lblCastingNotMatched.Size = New System.Drawing.Size(598, 19)
        Me.lblCastingNotMatched.TabIndex = 21
        Me.lblCastingNotMatched.Text = "Casting Not Matched"
        Me.lblCastingNotMatched.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblBackGround.Size = New System.Drawing.Size(618, 552)
        Me.lblBackGround.TabIndex = 108
        Me.lblBackGround.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'rdbDesignACasting
        '
        Me.rdbDesignACasting.AutoSize = True
        Me.rdbDesignACasting.Location = New System.Drawing.Point(180, 30)
        Me.rdbDesignACasting.Name = "rdbDesignACasting"
        Me.rdbDesignACasting.Size = New System.Drawing.Size(105, 17)
        Me.rdbDesignACasting.TabIndex = 2
        Me.rdbDesignACasting.TabStop = True
        Me.rdbDesignACasting.Text = "Design a Casting"
        Me.rdbDesignACasting.UseVisualStyleBackColor = True
        '
        'rdbFabrication
        '
        Me.rdbFabrication.AutoSize = True
        Me.rdbFabrication.Location = New System.Drawing.Point(82, 30)
        Me.rdbFabrication.Name = "rdbFabrication"
        Me.rdbFabrication.Size = New System.Drawing.Size(77, 17)
        Me.rdbFabrication.TabIndex = 1
        Me.rdbFabrication.TabStop = True
        Me.rdbFabrication.Text = "Fabrication"
        Me.rdbFabrication.UseVisualStyleBackColor = True
        '
        'grbCastingNotMatched
        '
        Me.grbCastingNotMatched.BackColor = System.Drawing.Color.Ivory
        Me.grbCastingNotMatched.Controls.Add(Me.chkSingleLugFabricationRequired)
        Me.grbCastingNotMatched.Controls.Add(Me.cmbLugInTubeDiameter)
        Me.grbCastingNotMatched.Controls.Add(Me.plnFabrication_Casting)
        Me.grbCastingNotMatched.Controls.Add(Me.lblLugWithInTubeDiameter)
        Me.grbCastingNotMatched.Controls.Add(Me.lblCastingNotMatched)
        Me.grbCastingNotMatched.Controls.Add(Me.rdbDesignACasting)
        Me.grbCastingNotMatched.Controls.Add(Me.rdbFabrication)
        Me.grbCastingNotMatched.Location = New System.Drawing.Point(24, 18)
        Me.grbCastingNotMatched.Name = "grbCastingNotMatched"
        Me.grbCastingNotMatched.Size = New System.Drawing.Size(595, 536)
        Me.grbCastingNotMatched.TabIndex = 107
        Me.grbCastingNotMatched.TabStop = False
        '
        'chkSingleLugFabricationRequired
        '
        Me.chkSingleLugFabricationRequired.AutoSize = True
        Me.chkSingleLugFabricationRequired.Location = New System.Drawing.Point(465, 511)
        Me.chkSingleLugFabricationRequired.Name = "chkSingleLugFabricationRequired"
        Me.chkSingleLugFabricationRequired.Size = New System.Drawing.Size(124, 17)
        Me.chkSingleLugFabricationRequired.TabIndex = 179
        Me.chkSingleLugFabricationRequired.Text = "Fabrication Required"
        Me.chkSingleLugFabricationRequired.UseVisualStyleBackColor = True
        '
        'frmSLCastingNo_PortInTube
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(900, 650)
        Me.Controls.Add(Me.grbCastingNotMatched)
        Me.Controls.Add(Me.lblBackGround)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSLCastingNo_PortInTube"
        Me.Text = "frmSLCastingNo_PortInTube"
        Me.plnFabrication_Casting.ResumeLayout(False)
        Me.grbCastingNotMatched.ResumeLayout(False)
        Me.grbCastingNotMatched.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plnFabrication_Casting As System.Windows.Forms.Panel
    Friend WithEvents lblCastingNotMatched As LabelGradient.LabelGradient
    Friend WithEvents lblBackGround As LabelGradient.LabelGradient
    Friend WithEvents rdbDesignACasting As System.Windows.Forms.RadioButton
    Friend WithEvents rdbFabrication As System.Windows.Forms.RadioButton
    Friend WithEvents grbCastingNotMatched As System.Windows.Forms.GroupBox
    Friend WithEvents btnRadioButtonsSelectionMessage As System.Windows.Forms.Button
    Friend WithEvents cmbLugInTubeDiameter As IFLCustomUILayer.IFLComboBox
    Friend WithEvents lblLugWithInTubeDiameter As System.Windows.Forms.Label
    Friend WithEvents chkSingleLugFabricationRequired As System.Windows.Forms.CheckBox
End Class
