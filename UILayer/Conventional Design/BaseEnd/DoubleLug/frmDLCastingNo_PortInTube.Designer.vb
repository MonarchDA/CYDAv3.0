<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDLCastingNo_PortInTube
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
        Me.rdbFabrication = New System.Windows.Forms.RadioButton()
        Me.rdbDesignACasting = New System.Windows.Forms.RadioButton()
        Me.grbCastingNotMatched = New System.Windows.Forms.GroupBox()
        Me.chkDoubleLugFabricationRequired = New System.Windows.Forms.CheckBox()
        Me.grp2SingleLugs = New System.Windows.Forms.GroupBox()
        Me.chkDoubleLug = New System.Windows.Forms.CheckBox()
        Me.chkULug = New System.Windows.Forms.CheckBox()
        Me.plnFabrication_Casting = New System.Windows.Forms.Panel()
        Me.btnRadioButtonsSelectionMessage = New System.Windows.Forms.Button()
        Me.lblCastingNotMatched = New LabelGradient.LabelGradient()
        Me.lblBackGround = New LabelGradient.LabelGradient()
        Me.grbCastingNotMatched.SuspendLayout()
        Me.grp2SingleLugs.SuspendLayout()
        Me.plnFabrication_Casting.SuspendLayout()
        Me.SuspendLayout()
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
        'grbCastingNotMatched
        '
        Me.grbCastingNotMatched.BackColor = System.Drawing.Color.Ivory
        Me.grbCastingNotMatched.Controls.Add(Me.chkDoubleLugFabricationRequired)
        Me.grbCastingNotMatched.Controls.Add(Me.grp2SingleLugs)
        Me.grbCastingNotMatched.Controls.Add(Me.plnFabrication_Casting)
        Me.grbCastingNotMatched.Controls.Add(Me.lblCastingNotMatched)
        Me.grbCastingNotMatched.Controls.Add(Me.rdbDesignACasting)
        Me.grbCastingNotMatched.Controls.Add(Me.rdbFabrication)
        Me.grbCastingNotMatched.Location = New System.Drawing.Point(24, 25)
        Me.grbCastingNotMatched.Name = "grbCastingNotMatched"
        Me.grbCastingNotMatched.Size = New System.Drawing.Size(657, 630)
        Me.grbCastingNotMatched.TabIndex = 0
        Me.grbCastingNotMatched.TabStop = False
        '
        'chkDoubleLugFabricationRequired
        '
        Me.chkDoubleLugFabricationRequired.AutoSize = True
        Me.chkDoubleLugFabricationRequired.Location = New System.Drawing.Point(515, 594)
        Me.chkDoubleLugFabricationRequired.Name = "chkDoubleLugFabricationRequired"
        Me.chkDoubleLugFabricationRequired.Size = New System.Drawing.Size(124, 17)
        Me.chkDoubleLugFabricationRequired.TabIndex = 178
        Me.chkDoubleLugFabricationRequired.Text = "Fabrication Required"
        Me.chkDoubleLugFabricationRequired.UseVisualStyleBackColor = True
        '
        'grp2SingleLugs
        '
        Me.grp2SingleLugs.Controls.Add(Me.chkDoubleLug)
        Me.grp2SingleLugs.Controls.Add(Me.chkULug)
        Me.grp2SingleLugs.Location = New System.Drawing.Point(83, 53)
        Me.grp2SingleLugs.Name = "grp2SingleLugs"
        Me.grp2SingleLugs.Size = New System.Drawing.Size(236, 39)
        Me.grp2SingleLugs.TabIndex = 24
        Me.grp2SingleLugs.TabStop = False
        Me.grp2SingleLugs.Visible = False
        '
        'chkDoubleLug
        '
        Me.chkDoubleLug.AutoSize = True
        Me.chkDoubleLug.Location = New System.Drawing.Point(140, 16)
        Me.chkDoubleLug.Name = "chkDoubleLug"
        Me.chkDoubleLug.Size = New System.Drawing.Size(81, 17)
        Me.chkDoubleLug.TabIndex = 23
        Me.chkDoubleLug.Text = "Double Lug"
        Me.chkDoubleLug.UseVisualStyleBackColor = True
        '
        'chkULug
        '
        Me.chkULug.AutoSize = True
        Me.chkULug.Location = New System.Drawing.Point(6, 16)
        Me.chkULug.Name = "chkULug"
        Me.chkULug.Size = New System.Drawing.Size(55, 17)
        Me.chkULug.TabIndex = 23
        Me.chkULug.Text = "U-Lug"
        Me.chkULug.UseVisualStyleBackColor = True
        '
        'plnFabrication_Casting
        '
        Me.plnFabrication_Casting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.plnFabrication_Casting.Controls.Add(Me.btnRadioButtonsSelectionMessage)
        Me.plnFabrication_Casting.Location = New System.Drawing.Point(6, 95)
        Me.plnFabrication_Casting.Name = "plnFabrication_Casting"
        Me.plnFabrication_Casting.Size = New System.Drawing.Size(645, 492)
        Me.plnFabrication_Casting.TabIndex = 22
        '
        'btnRadioButtonsSelectionMessage
        '
        Me.btnRadioButtonsSelectionMessage.BackColor = System.Drawing.Color.Transparent
        Me.btnRadioButtonsSelectionMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRadioButtonsSelectionMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRadioButtonsSelectionMessage.Location = New System.Drawing.Point(160, 217)
        Me.btnRadioButtonsSelectionMessage.Name = "btnRadioButtonsSelectionMessage"
        Me.btnRadioButtonsSelectionMessage.Size = New System.Drawing.Size(259, 39)
        Me.btnRadioButtonsSelectionMessage.TabIndex = 110
        Me.btnRadioButtonsSelectionMessage.Text = "Select any one of the radio buttons"
        Me.btnRadioButtonsSelectionMessage.UseVisualStyleBackColor = False
        Me.btnRadioButtonsSelectionMessage.Visible = False
        '
        'lblCastingNotMatched
        '
        Me.lblCastingNotMatched.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblCastingNotMatched.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCastingNotMatched.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCastingNotMatched.GradientColorOne = System.Drawing.Color.Olive
        Me.lblCastingNotMatched.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblCastingNotMatched.Location = New System.Drawing.Point(-3, -1)
        Me.lblCastingNotMatched.Name = "lblCastingNotMatched"
        Me.lblCastingNotMatched.Size = New System.Drawing.Size(660, 27)
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
        Me.lblBackGround.Size = New System.Drawing.Size(678, 646)
        Me.lblBackGround.TabIndex = 106
        Me.lblBackGround.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmDLCastingNo_PortInTube
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(949, 664)
        Me.Controls.Add(Me.grbCastingNotMatched)
        Me.Controls.Add(Me.lblBackGround)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDLCastingNo_PortInTube"
        Me.Text = "frmCastingNo"
        Me.grbCastingNotMatched.ResumeLayout(False)
        Me.grbCastingNotMatched.PerformLayout()
        Me.grp2SingleLugs.ResumeLayout(False)
        Me.grp2SingleLugs.PerformLayout()
        Me.plnFabrication_Casting.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rdbFabrication As System.Windows.Forms.RadioButton
    Friend WithEvents rdbDesignACasting As System.Windows.Forms.RadioButton
    Friend WithEvents grbCastingNotMatched As System.Windows.Forms.GroupBox
    Friend WithEvents lblCastingNotMatched As LabelGradient.LabelGradient
    Friend WithEvents lblBackGround As LabelGradient.LabelGradient
    Friend WithEvents plnFabrication_Casting As System.Windows.Forms.Panel
    Friend WithEvents btnRadioButtonsSelectionMessage As System.Windows.Forms.Button
    Friend WithEvents chkULug As System.Windows.Forms.CheckBox
    Friend WithEvents grp2SingleLugs As System.Windows.Forms.GroupBox
    Friend WithEvents chkDoubleLug As System.Windows.Forms.CheckBox
    Friend WithEvents chkDoubleLugFabricationRequired As System.Windows.Forms.CheckBox
End Class
