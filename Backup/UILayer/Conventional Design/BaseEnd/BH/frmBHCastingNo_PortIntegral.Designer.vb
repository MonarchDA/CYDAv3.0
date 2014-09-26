<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBHCastingNo_PortIntegral
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
        Me.grbCastingNotMatched = New System.Windows.Forms.GroupBox
        Me.rdbFabricated = New System.Windows.Forms.RadioButton
        Me.rdbPortInTube = New System.Windows.Forms.RadioButton
        Me.plnPortInTube_Casting = New System.Windows.Forms.Panel
        Me.lblCastingNotMatched = New LabelGradient.LabelGradient
        Me.rdbDesignACasting = New System.Windows.Forms.RadioButton
        Me.lblBackGround = New LabelGradient.LabelGradient
        Me.btnDisplayPortInTube = New System.Windows.Forms.Button
        Me.grbCastingNotMatched.SuspendLayout()
        Me.plnPortInTube_Casting.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbCastingNotMatched
        '
        Me.grbCastingNotMatched.BackColor = System.Drawing.Color.Ivory
        Me.grbCastingNotMatched.Controls.Add(Me.rdbFabricated)
        Me.grbCastingNotMatched.Controls.Add(Me.rdbPortInTube)
        Me.grbCastingNotMatched.Controls.Add(Me.plnPortInTube_Casting)
        Me.grbCastingNotMatched.Controls.Add(Me.lblCastingNotMatched)
        Me.grbCastingNotMatched.Controls.Add(Me.rdbDesignACasting)
        Me.grbCastingNotMatched.Location = New System.Drawing.Point(24, 25)
        Me.grbCastingNotMatched.Name = "grbCastingNotMatched"
        Me.grbCastingNotMatched.Size = New System.Drawing.Size(595, 578)
        Me.grbCastingNotMatched.TabIndex = 122
        Me.grbCastingNotMatched.TabStop = False
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
        'plnPortInTube_Casting
        '
        Me.plnPortInTube_Casting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.plnPortInTube_Casting.Controls.Add(Me.btnDisplayPortInTube)
        Me.plnPortInTube_Casting.Location = New System.Drawing.Point(6, 95)
        Me.plnPortInTube_Casting.Name = "plnPortInTube_Casting"
        Me.plnPortInTube_Casting.Size = New System.Drawing.Size(583, 477)
        Me.plnPortInTube_Casting.TabIndex = 22
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
        Me.lblBackGround.TabIndex = 123
        Me.lblBackGround.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnDisplayPortInTube
        '
        Me.btnDisplayPortInTube.BackColor = System.Drawing.Color.Ivory
        Me.btnDisplayPortInTube.Enabled = False
        Me.btnDisplayPortInTube.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDisplayPortInTube.Location = New System.Drawing.Point(164, 180)
        Me.btnDisplayPortInTube.Name = "btnDisplayPortInTube"
        Me.btnDisplayPortInTube.Size = New System.Drawing.Size(242, 34)
        Me.btnDisplayPortInTube.TabIndex = 123
        Me.btnDisplayPortInTube.Text = "Click Next Button To View Port In Tube Screen"
        Me.btnDisplayPortInTube.UseVisualStyleBackColor = False
        '
        'frmBHCastingNo_PortIntegral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(900, 650)
        Me.Controls.Add(Me.grbCastingNotMatched)
        Me.Controls.Add(Me.lblBackGround)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmBHCastingNo_PortIntegral"
        Me.Text = "frmBHCastingNo_PortIntegral"
        Me.grbCastingNotMatched.ResumeLayout(False)
        Me.grbCastingNotMatched.PerformLayout()
        Me.plnPortInTube_Casting.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbCastingNotMatched As System.Windows.Forms.GroupBox
    Friend WithEvents rdbFabricated As System.Windows.Forms.RadioButton
    Friend WithEvents rdbPortInTube As System.Windows.Forms.RadioButton
    Friend WithEvents plnPortInTube_Casting As System.Windows.Forms.Panel
    Friend WithEvents lblCastingNotMatched As LabelGradient.LabelGradient
    Friend WithEvents rdbDesignACasting As System.Windows.Forms.RadioButton
    Friend WithEvents lblBackGround As LabelGradient.LabelGradient
    Friend WithEvents btnDisplayPortInTube As System.Windows.Forms.Button
End Class
