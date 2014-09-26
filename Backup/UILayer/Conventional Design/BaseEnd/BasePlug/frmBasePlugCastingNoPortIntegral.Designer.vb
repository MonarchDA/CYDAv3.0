<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBasePlugCastingNoPortIntegral
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
        Me.grbBasePlugNotMatched = New System.Windows.Forms.GroupBox
        Me.rdbPortInTube = New System.Windows.Forms.RadioButton
        Me.plnPortInTube_BasePlug = New System.Windows.Forms.Panel
        Me.lbBasePlugNotMatched = New LabelGradient.LabelGradient
        Me.rdbDesignABasePlug = New System.Windows.Forms.RadioButton
        Me.lblBackGround = New LabelGradient.LabelGradient
        Me.btnDisplayPortInTube = New System.Windows.Forms.Button
        Me.grbBasePlugNotMatched.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbBasePlugNotMatched
        '
        Me.grbBasePlugNotMatched.BackColor = System.Drawing.Color.Ivory
        Me.grbBasePlugNotMatched.Controls.Add(Me.rdbPortInTube)
        Me.grbBasePlugNotMatched.Controls.Add(Me.plnPortInTube_BasePlug)
        Me.grbBasePlugNotMatched.Controls.Add(Me.lbBasePlugNotMatched)
        Me.grbBasePlugNotMatched.Controls.Add(Me.rdbDesignABasePlug)
        Me.grbBasePlugNotMatched.Location = New System.Drawing.Point(24, 18)
        Me.grbBasePlugNotMatched.Name = "grbBasePlugNotMatched"
        Me.grbBasePlugNotMatched.Size = New System.Drawing.Size(595, 532)
        Me.grbBasePlugNotMatched.TabIndex = 123
        Me.grbBasePlugNotMatched.TabStop = False
        '
        'rdbPortInTube
        '
        Me.rdbPortInTube.AutoSize = True
        Me.rdbPortInTube.Location = New System.Drawing.Point(321, 30)
        Me.rdbPortInTube.Name = "rdbPortInTube"
        Me.rdbPortInTube.Size = New System.Drawing.Size(81, 17)
        Me.rdbPortInTube.TabIndex = 23
        Me.rdbPortInTube.TabStop = True
        Me.rdbPortInTube.Text = "Port InTube"
        Me.rdbPortInTube.UseVisualStyleBackColor = True
        '
        'plnPortInTube_BasePlug
        '
        Me.plnPortInTube_BasePlug.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.plnPortInTube_BasePlug.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.plnPortInTube_BasePlug.Location = New System.Drawing.Point(6, 51)
        Me.plnPortInTube_BasePlug.Name = "plnPortInTube_BasePlug"
        Me.plnPortInTube_BasePlug.Size = New System.Drawing.Size(583, 477)
        Me.plnPortInTube_BasePlug.TabIndex = 22
        '
        'lbBasePlugNotMatched
        '
        Me.lbBasePlugNotMatched.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lbBasePlugNotMatched.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbBasePlugNotMatched.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbBasePlugNotMatched.GradientColorOne = System.Drawing.Color.Olive
        Me.lbBasePlugNotMatched.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lbBasePlugNotMatched.Location = New System.Drawing.Point(-3, 0)
        Me.lbBasePlugNotMatched.Name = "lbBasePlugNotMatched"
        Me.lbBasePlugNotMatched.Size = New System.Drawing.Size(598, 19)
        Me.lbBasePlugNotMatched.TabIndex = 21
        Me.lbBasePlugNotMatched.Text = "Base Plug Not Matched"
        Me.lbBasePlugNotMatched.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'rdbDesignABasePlug
        '
        Me.rdbDesignABasePlug.AutoSize = True
        Me.rdbDesignABasePlug.Location = New System.Drawing.Point(193, 30)
        Me.rdbDesignABasePlug.Name = "rdbDesignABasePlug"
        Me.rdbDesignABasePlug.Size = New System.Drawing.Size(105, 17)
        Me.rdbDesignABasePlug.TabIndex = 2
        Me.rdbDesignABasePlug.TabStop = True
        Me.rdbDesignABasePlug.Text = "Design a Casting"
        Me.rdbDesignABasePlug.UseVisualStyleBackColor = True
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
        Me.lblBackGround.Size = New System.Drawing.Size(618, 560)
        Me.lblBackGround.TabIndex = 124
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
        Me.btnDisplayPortInTube.TabIndex = 125
        Me.btnDisplayPortInTube.Text = "Click Next Button To View Port In Tube Screen"
        Me.btnDisplayPortInTube.UseVisualStyleBackColor = False
        '
        'frmBasePlugCastingNoPortIntegral
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(950, 650)
        Me.ControlBox = False
        Me.Controls.Add(Me.grbBasePlugNotMatched)
        Me.Controls.Add(Me.lblBackGround)
        Me.Controls.Add(Me.btnDisplayPortInTube)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmBasePlugCastingNoPortIntegral"
        Me.Text = "BasePlugCastingNoPortIntegral"
        Me.grbBasePlugNotMatched.ResumeLayout(False)
        Me.grbBasePlugNotMatched.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbBasePlugNotMatched As System.Windows.Forms.GroupBox
    Friend WithEvents rdbPortInTube As System.Windows.Forms.RadioButton
    Friend WithEvents plnPortInTube_BasePlug As System.Windows.Forms.Panel
    Friend WithEvents lbBasePlugNotMatched As LabelGradient.LabelGradient
    Friend WithEvents rdbDesignABasePlug As System.Windows.Forms.RadioButton
    Friend WithEvents lblBackGround As LabelGradient.LabelGradient
    Friend WithEvents btnDisplayPortInTube As System.Windows.Forms.Button
End Class
