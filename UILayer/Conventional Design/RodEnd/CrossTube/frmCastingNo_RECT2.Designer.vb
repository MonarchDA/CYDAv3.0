<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCastingNo_RECT2
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
        Me.grbCastingNotMatched_RECT = New System.Windows.Forms.GroupBox
        Me.plnFabrication_Casting_RECT = New System.Windows.Forms.Panel
        Me.btnPleaseChangeTheRodDiameter = New System.Windows.Forms.Button
        Me.lblCastingNotMatched_RECT = New LabelGradient.LabelGradient
        Me.rdbDesignACasting_RECT = New System.Windows.Forms.RadioButton
        Me.rdbFabrication_RECT = New System.Windows.Forms.RadioButton
        Me.lblBackGround = New LabelGradient.LabelGradient
        Me.grbCastingNotMatched_RECT.SuspendLayout()
        Me.plnFabrication_Casting_RECT.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbCastingNotMatched_RECT
        '
        Me.grbCastingNotMatched_RECT.BackColor = System.Drawing.Color.Ivory
        Me.grbCastingNotMatched_RECT.Controls.Add(Me.plnFabrication_Casting_RECT)
        Me.grbCastingNotMatched_RECT.Controls.Add(Me.lblCastingNotMatched_RECT)
        Me.grbCastingNotMatched_RECT.Controls.Add(Me.rdbDesignACasting_RECT)
        Me.grbCastingNotMatched_RECT.Controls.Add(Me.rdbFabrication_RECT)
        Me.grbCastingNotMatched_RECT.Location = New System.Drawing.Point(24, 18)
        Me.grbCastingNotMatched_RECT.Name = "grbCastingNotMatched_RECT"
        Me.grbCastingNotMatched_RECT.Size = New System.Drawing.Size(595, 536)
        Me.grbCastingNotMatched_RECT.TabIndex = 109
        Me.grbCastingNotMatched_RECT.TabStop = False
        '
        'plnFabrication_Casting_RECT
        '
        Me.plnFabrication_Casting_RECT.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.plnFabrication_Casting_RECT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.plnFabrication_Casting_RECT.Controls.Add(Me.btnPleaseChangeTheRodDiameter)
        Me.plnFabrication_Casting_RECT.Location = New System.Drawing.Point(6, 53)
        Me.plnFabrication_Casting_RECT.Name = "plnFabrication_Casting_RECT"
        Me.plnFabrication_Casting_RECT.Size = New System.Drawing.Size(583, 477)
        Me.plnFabrication_Casting_RECT.TabIndex = 22
        '
        'btnPleaseChangeTheRodDiameter
        '
        Me.btnPleaseChangeTheRodDiameter.Enabled = False
        Me.btnPleaseChangeTheRodDiameter.Location = New System.Drawing.Point(91, 189)
        Me.btnPleaseChangeTheRodDiameter.Name = "btnPleaseChangeTheRodDiameter"
        Me.btnPleaseChangeTheRodDiameter.Size = New System.Drawing.Size(397, 94)
        Me.btnPleaseChangeTheRodDiameter.TabIndex = 173
        Me.btnPleaseChangeTheRodDiameter.Text = "Calculated Weld Size is more than Existing weld Size. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "so please change Rod Diam" & _
            "ter input.  " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click Next button to go to Primary inputs screen." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnPleaseChangeTheRodDiameter.UseVisualStyleBackColor = True
        '
        'lblCastingNotMatched_RECT
        '
        Me.lblCastingNotMatched_RECT.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblCastingNotMatched_RECT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCastingNotMatched_RECT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCastingNotMatched_RECT.GradientColorOne = System.Drawing.Color.Olive
        Me.lblCastingNotMatched_RECT.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblCastingNotMatched_RECT.Location = New System.Drawing.Point(-3, 0)
        Me.lblCastingNotMatched_RECT.Name = "lblCastingNotMatched_RECT"
        Me.lblCastingNotMatched_RECT.Size = New System.Drawing.Size(598, 19)
        Me.lblCastingNotMatched_RECT.TabIndex = 21
        Me.lblCastingNotMatched_RECT.Text = "Casting Not Matched2"
        Me.lblCastingNotMatched_RECT.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'rdbDesignACasting_RECT
        '
        Me.rdbDesignACasting_RECT.AutoSize = True
        Me.rdbDesignACasting_RECT.Location = New System.Drawing.Point(300, 30)
        Me.rdbDesignACasting_RECT.Name = "rdbDesignACasting_RECT"
        Me.rdbDesignACasting_RECT.Size = New System.Drawing.Size(105, 17)
        Me.rdbDesignACasting_RECT.TabIndex = 2
        Me.rdbDesignACasting_RECT.TabStop = True
        Me.rdbDesignACasting_RECT.Text = "Design a Casting"
        Me.rdbDesignACasting_RECT.UseVisualStyleBackColor = True
        '
        'rdbFabrication_RECT
        '
        Me.rdbFabrication_RECT.AutoSize = True
        Me.rdbFabrication_RECT.Location = New System.Drawing.Point(202, 30)
        Me.rdbFabrication_RECT.Name = "rdbFabrication_RECT"
        Me.rdbFabrication_RECT.Size = New System.Drawing.Size(77, 17)
        Me.rdbFabrication_RECT.TabIndex = 1
        Me.rdbFabrication_RECT.TabStop = True
        Me.rdbFabrication_RECT.Text = "Fabrication"
        Me.rdbFabrication_RECT.UseVisualStyleBackColor = True
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
        Me.lblBackGround.TabIndex = 110
        Me.lblBackGround.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmCastingNo_RECT2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(900, 650)
        Me.ControlBox = False
        Me.Controls.Add(Me.grbCastingNotMatched_RECT)
        Me.Controls.Add(Me.lblBackGround)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCastingNo_RECT2"
        Me.Text = "CastingNo_RECT"
        Me.grbCastingNotMatched_RECT.ResumeLayout(False)
        Me.grbCastingNotMatched_RECT.PerformLayout()
        Me.plnFabrication_Casting_RECT.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbCastingNotMatched_RECT As System.Windows.Forms.GroupBox
    Friend WithEvents plnFabrication_Casting_RECT As System.Windows.Forms.Panel
    Friend WithEvents lblCastingNotMatched_RECT As LabelGradient.LabelGradient
    Friend WithEvents rdbDesignACasting_RECT As System.Windows.Forms.RadioButton
    Friend WithEvents rdbFabrication_RECT As System.Windows.Forms.RadioButton
    Friend WithEvents lblBackGround As LabelGradient.LabelGradient
    Friend WithEvents btnPleaseChangeTheRodDiameter As System.Windows.Forms.Button
End Class
