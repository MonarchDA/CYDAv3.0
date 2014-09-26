<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSLCastingNo_PortIntegral2
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
        Me.lblCastingNotMatched = New LabelGradient.LabelGradient
        Me.rdbDesignACasting = New System.Windows.Forms.RadioButton
        Me.plnPortInTube_Casting = New System.Windows.Forms.Panel
        Me.lblBackGround = New LabelGradient.LabelGradient
        Me.btnDisplayPortInTube = New System.Windows.Forms.Button
        Me.rdbPortInTube = New System.Windows.Forms.RadioButton
        Me.grbCastingNotMatched = New System.Windows.Forms.GroupBox
        Me.cmbLugInTubeDiameter = New IFLCustomUILayer.IFLComboBox
        Me.lblLugWithInTubeDiameter = New System.Windows.Forms.Label
        Me.rdbFabricated = New System.Windows.Forms.RadioButton
        Me.grbCastingNotMatched.SuspendLayout()
        Me.SuspendLayout()
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
        Me.lblCastingNotMatched.Text = "Casting Not Matched2"
        Me.lblCastingNotMatched.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'rdbDesignACasting
        '
        Me.rdbDesignACasting.AutoSize = True
        Me.rdbDesignACasting.Location = New System.Drawing.Point(245, 30)
        Me.rdbDesignACasting.Name = "rdbDesignACasting"
        Me.rdbDesignACasting.Size = New System.Drawing.Size(105, 17)
        Me.rdbDesignACasting.TabIndex = 2
        Me.rdbDesignACasting.TabStop = True
        Me.rdbDesignACasting.Text = "Design a Casting"
        Me.rdbDesignACasting.UseVisualStyleBackColor = True
        '
        'plnPortInTube_Casting
        '
        Me.plnPortInTube_Casting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.plnPortInTube_Casting.Location = New System.Drawing.Point(6, 95)
        Me.plnPortInTube_Casting.Name = "plnPortInTube_Casting"
        Me.plnPortInTube_Casting.Size = New System.Drawing.Size(583, 477)
        Me.plnPortInTube_Casting.TabIndex = 22
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
        Me.lblBackGround.Size = New System.Drawing.Size(618, 606)
        Me.lblBackGround.TabIndex = 121
        Me.lblBackGround.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnDisplayPortInTube
        '
        Me.btnDisplayPortInTube.BackColor = System.Drawing.Color.Ivory
        Me.btnDisplayPortInTube.Enabled = False
        Me.btnDisplayPortInTube.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDisplayPortInTube.Location = New System.Drawing.Point(200, 257)
        Me.btnDisplayPortInTube.Name = "btnDisplayPortInTube"
        Me.btnDisplayPortInTube.Size = New System.Drawing.Size(242, 34)
        Me.btnDisplayPortInTube.TabIndex = 122
        Me.btnDisplayPortInTube.Text = "Click Next Button To View Port In Tube Screen"
        Me.btnDisplayPortInTube.UseVisualStyleBackColor = False
        '
        'rdbPortInTube
        '
        Me.rdbPortInTube.AutoSize = True
        Me.rdbPortInTube.Location = New System.Drawing.Point(383, 30)
        Me.rdbPortInTube.Name = "rdbPortInTube"
        Me.rdbPortInTube.Size = New System.Drawing.Size(81, 17)
        Me.rdbPortInTube.TabIndex = 23
        Me.rdbPortInTube.TabStop = True
        Me.rdbPortInTube.Text = "Port InTube"
        Me.rdbPortInTube.UseVisualStyleBackColor = True
        '
        'grbCastingNotMatched
        '
        Me.grbCastingNotMatched.BackColor = System.Drawing.Color.Ivory
        Me.grbCastingNotMatched.Controls.Add(Me.cmbLugInTubeDiameter)
        Me.grbCastingNotMatched.Controls.Add(Me.lblLugWithInTubeDiameter)
        Me.grbCastingNotMatched.Controls.Add(Me.rdbFabricated)
        Me.grbCastingNotMatched.Controls.Add(Me.rdbPortInTube)
        Me.grbCastingNotMatched.Controls.Add(Me.plnPortInTube_Casting)
        Me.grbCastingNotMatched.Controls.Add(Me.lblCastingNotMatched)
        Me.grbCastingNotMatched.Controls.Add(Me.rdbDesignACasting)
        Me.grbCastingNotMatched.Location = New System.Drawing.Point(24, 25)
        Me.grbCastingNotMatched.Name = "grbCastingNotMatched"
        Me.grbCastingNotMatched.Size = New System.Drawing.Size(595, 578)
        Me.grbCastingNotMatched.TabIndex = 120
        Me.grbCastingNotMatched.TabStop = False
        '
        'cmbLugInTubeDiameter
        '
        Me.cmbLugInTubeDiameter.AcceptEnterKeyAsTab = True
        Me.cmbLugInTubeDiameter.AssociateLabel = Nothing
        Me.cmbLugInTubeDiameter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLugInTubeDiameter.FormattingEnabled = True
        Me.cmbLugInTubeDiameter.IFLDataTag = Nothing
        Me.cmbLugInTubeDiameter.Location = New System.Drawing.Point(278, 66)
        Me.cmbLugInTubeDiameter.Name = "cmbLugInTubeDiameter"
        Me.cmbLugInTubeDiameter.Size = New System.Drawing.Size(98, 21)
        Me.cmbLugInTubeDiameter.StatusMessage = Nothing
        Me.cmbLugInTubeDiameter.StatusObject = Nothing
        Me.cmbLugInTubeDiameter.TabIndex = 170
        '
        'lblLugWithInTubeDiameter
        '
        Me.lblLugWithInTubeDiameter.AutoSize = True
        Me.lblLugWithInTubeDiameter.Location = New System.Drawing.Point(173, 69)
        Me.lblLugWithInTubeDiameter.Name = "lblLugWithInTubeDiameter"
        Me.lblLugWithInTubeDiameter.Size = New System.Drawing.Size(96, 13)
        Me.lblLugWithInTubeDiameter.TabIndex = 171
        Me.lblLugWithInTubeDiameter.Text = "Lug withinTubeDia"
        '
        'rdbFabricated
        '
        Me.rdbFabricated.AutoSize = True
        Me.rdbFabricated.Location = New System.Drawing.Point(122, 30)
        Me.rdbFabricated.Name = "rdbFabricated"
        Me.rdbFabricated.Size = New System.Drawing.Size(77, 17)
        Me.rdbFabricated.TabIndex = 27
        Me.rdbFabricated.TabStop = True
        Me.rdbFabricated.Text = "Fabrication"
        Me.rdbFabricated.UseVisualStyleBackColor = True
        '
        'frmSLCastingNo_PortIntegral2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(900, 650)
        Me.Controls.Add(Me.btnDisplayPortInTube)
        Me.Controls.Add(Me.grbCastingNotMatched)
        Me.Controls.Add(Me.lblBackGround)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSLCastingNo_PortIntegral2"
        Me.Text = "frmSLCastingNo_PortIntegral"
        Me.grbCastingNotMatched.ResumeLayout(False)
        Me.grbCastingNotMatched.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblCastingNotMatched As LabelGradient.LabelGradient
    Friend WithEvents rdbDesignACasting As System.Windows.Forms.RadioButton
    Friend WithEvents plnPortInTube_Casting As System.Windows.Forms.Panel
    Friend WithEvents lblBackGround As LabelGradient.LabelGradient
    Friend WithEvents btnDisplayPortInTube As System.Windows.Forms.Button
    Friend WithEvents rdbPortInTube As System.Windows.Forms.RadioButton
    Friend WithEvents grbCastingNotMatched As System.Windows.Forms.GroupBox
    Friend WithEvents rdbFabricated As System.Windows.Forms.RadioButton
    Friend WithEvents cmbLugInTubeDiameter As IFLCustomUILayer.IFLComboBox
    Friend WithEvents lblLugWithInTubeDiameter As System.Windows.Forms.Label
End Class
