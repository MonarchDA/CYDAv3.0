<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCTCastingNo_PortInTube2
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
        Me.plnFabrication_Casting = New System.Windows.Forms.Panel
        Me.grbCastingNotMatched = New System.Windows.Forms.GroupBox
        Me.lblCastingNotMatched = New LabelGradient.LabelGradient
        Me.rdbDesignACasting = New System.Windows.Forms.RadioButton
        Me.rdbFabrication = New System.Windows.Forms.RadioButton
        Me.lblBackGround = New LabelGradient.LabelGradient
        Me.grbCastingNotMatched.SuspendLayout()
        Me.SuspendLayout()
        '
        'plnFabrication_Casting
        '
        Me.plnFabrication_Casting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.plnFabrication_Casting.Location = New System.Drawing.Point(6, 53)
        Me.plnFabrication_Casting.Name = "plnFabrication_Casting"
        Me.plnFabrication_Casting.Size = New System.Drawing.Size(583, 477)
        Me.plnFabrication_Casting.TabIndex = 22
        '
        'grbCastingNotMatched
        '
        Me.grbCastingNotMatched.BackColor = System.Drawing.Color.Ivory
        Me.grbCastingNotMatched.Controls.Add(Me.plnFabrication_Casting)
        Me.grbCastingNotMatched.Controls.Add(Me.lblCastingNotMatched)
        Me.grbCastingNotMatched.Controls.Add(Me.rdbDesignACasting)
        Me.grbCastingNotMatched.Controls.Add(Me.rdbFabrication)
        Me.grbCastingNotMatched.Location = New System.Drawing.Point(24, 18)
        Me.grbCastingNotMatched.Name = "grbCastingNotMatched"
        Me.grbCastingNotMatched.Size = New System.Drawing.Size(595, 536)
        Me.grbCastingNotMatched.TabIndex = 107
        Me.grbCastingNotMatched.TabStop = False
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
        Me.rdbDesignACasting.Location = New System.Drawing.Point(300, 30)
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
        Me.rdbFabrication.Location = New System.Drawing.Point(202, 30)
        Me.rdbFabrication.Name = "rdbFabrication"
        Me.rdbFabrication.Size = New System.Drawing.Size(77, 17)
        Me.rdbFabrication.TabIndex = 1
        Me.rdbFabrication.TabStop = True
        Me.rdbFabrication.Text = "Fabrication"
        Me.rdbFabrication.UseVisualStyleBackColor = True
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
        'frmCTCastingNo_PortInTube2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(900, 650)
        Me.Controls.Add(Me.grbCastingNotMatched)
        Me.Controls.Add(Me.lblBackGround)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCTCastingNo_PortInTube2"
        Me.Text = "Form3"
        Me.grbCastingNotMatched.ResumeLayout(False)
        Me.grbCastingNotMatched.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plnFabrication_Casting As System.Windows.Forms.Panel
    Friend WithEvents grbCastingNotMatched As System.Windows.Forms.GroupBox
    Friend WithEvents lblCastingNotMatched As LabelGradient.LabelGradient
    Friend WithEvents rdbDesignACasting As System.Windows.Forms.RadioButton
    Friend WithEvents rdbFabrication As System.Windows.Forms.RadioButton
    Friend WithEvents lblBackGround As LabelGradient.LabelGradient
End Class
