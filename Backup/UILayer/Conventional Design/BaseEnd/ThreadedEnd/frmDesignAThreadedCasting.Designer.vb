<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDesignAThreadedCasting
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
        Me.pnlDesignaCasting = New System.Windows.Forms.Panel
        Me.btnGenerate = New System.Windows.Forms.Button
        Me.txtSwingClearance = New IFLCustomUILayer.IFLNumericBox
        Me.txtThreadedLength = New IFLCustomUILayer.IFLNumericBox
        Me.cmbThreadedDiameter = New IFLCustomUILayer.IFLComboBox
        Me.lblThreadedLength = New System.Windows.Forms.Label
        Me.lblDesignNewCasting = New LabelGradient.LabelGradient
        Me.lblSwingClearance2 = New System.Windows.Forms.Label
        Me.lblThreadedDiameter = New System.Windows.Forms.Label
        Me.btnAccept = New System.Windows.Forms.Button
        Me.lblBackGround = New LabelGradient.LabelGradient
        Me.pnlSafetyFactor_Weight_LugThickness = New System.Windows.Forms.Panel
        Me.lvwSafetyFactor_Weight = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL
        Me.lblSafetyFactorIndex = New LabelGradient.LabelGradient
        Me.pnlDesignaCasting.SuspendLayout()
        Me.pnlSafetyFactor_Weight_LugThickness.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlDesignaCasting
        '
        Me.pnlDesignaCasting.BackColor = System.Drawing.Color.Ivory
        Me.pnlDesignaCasting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDesignaCasting.Controls.Add(Me.btnGenerate)
        Me.pnlDesignaCasting.Controls.Add(Me.txtSwingClearance)
        Me.pnlDesignaCasting.Controls.Add(Me.txtThreadedLength)
        Me.pnlDesignaCasting.Controls.Add(Me.cmbThreadedDiameter)
        Me.pnlDesignaCasting.Controls.Add(Me.lblThreadedLength)
        Me.pnlDesignaCasting.Controls.Add(Me.lblDesignNewCasting)
        Me.pnlDesignaCasting.Controls.Add(Me.lblSwingClearance2)
        Me.pnlDesignaCasting.Controls.Add(Me.lblThreadedDiameter)
        Me.pnlDesignaCasting.Location = New System.Drawing.Point(21, 17)
        Me.pnlDesignaCasting.Name = "pnlDesignaCasting"
        Me.pnlDesignaCasting.Size = New System.Drawing.Size(447, 196)
        Me.pnlDesignaCasting.TabIndex = 3
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(156, 157)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(128, 23)
        Me.btnGenerate.TabIndex = 164
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'txtSwingClearance
        '
        Me.txtSwingClearance.AcceptEnterKeyAsTab = True
        Me.txtSwingClearance.ApplyIFLColor = True
        Me.txtSwingClearance.AssociateLabel = Nothing
        Me.txtSwingClearance.DecimalValue = 3
        Me.txtSwingClearance.IFLDataTag = Nothing
        Me.txtSwingClearance.InvalidInputCharacters = ""
        Me.txtSwingClearance.IsAllowNegative = False
        Me.txtSwingClearance.LengthValue = 6
        Me.txtSwingClearance.Location = New System.Drawing.Point(247, 122)
        Me.txtSwingClearance.MaximumValue = 99999
        Me.txtSwingClearance.MaxLength = 6
        Me.txtSwingClearance.MinimumValue = 0
        Me.txtSwingClearance.Name = "txtSwingClearance"
        Me.txtSwingClearance.Size = New System.Drawing.Size(93, 20)
        Me.txtSwingClearance.StatusMessage = ""
        Me.txtSwingClearance.StatusObject = Nothing
        Me.txtSwingClearance.TabIndex = 163
        Me.txtSwingClearance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtThreadedLength
        '
        Me.txtThreadedLength.AcceptEnterKeyAsTab = True
        Me.txtThreadedLength.ApplyIFLColor = True
        Me.txtThreadedLength.AssociateLabel = Nothing
        Me.txtThreadedLength.DecimalValue = 3
        Me.txtThreadedLength.IFLDataTag = Nothing
        Me.txtThreadedLength.InvalidInputCharacters = ""
        Me.txtThreadedLength.IsAllowNegative = False
        Me.txtThreadedLength.LengthValue = 6
        Me.txtThreadedLength.Location = New System.Drawing.Point(247, 83)
        Me.txtThreadedLength.MaximumValue = 99999
        Me.txtThreadedLength.MaxLength = 6
        Me.txtThreadedLength.MinimumValue = 0
        Me.txtThreadedLength.Name = "txtThreadedLength"
        Me.txtThreadedLength.Size = New System.Drawing.Size(93, 20)
        Me.txtThreadedLength.StatusMessage = ""
        Me.txtThreadedLength.StatusObject = Nothing
        Me.txtThreadedLength.TabIndex = 162
        Me.txtThreadedLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbThreadedDiameter
        '
        Me.cmbThreadedDiameter.AcceptEnterKeyAsTab = True
        Me.cmbThreadedDiameter.AssociateLabel = Nothing
        Me.cmbThreadedDiameter.Enabled = False
        Me.cmbThreadedDiameter.IFLDataTag = Nothing
        Me.cmbThreadedDiameter.Location = New System.Drawing.Point(247, 40)
        Me.cmbThreadedDiameter.MaxLength = 6
        Me.cmbThreadedDiameter.Name = "cmbThreadedDiameter"
        Me.cmbThreadedDiameter.Size = New System.Drawing.Size(93, 21)
        Me.cmbThreadedDiameter.StatusMessage = ""
        Me.cmbThreadedDiameter.StatusObject = Nothing
        Me.cmbThreadedDiameter.TabIndex = 161
        '
        'lblThreadedLength
        '
        Me.lblThreadedLength.AutoSize = True
        Me.lblThreadedLength.Location = New System.Drawing.Point(127, 86)
        Me.lblThreadedLength.Name = "lblThreadedLength"
        Me.lblThreadedLength.Size = New System.Drawing.Size(89, 13)
        Me.lblThreadedLength.TabIndex = 155
        Me.lblThreadedLength.Text = "Threaded Length"
        '
        'lblDesignNewCasting
        '
        Me.lblDesignNewCasting.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblDesignNewCasting.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDesignNewCasting.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesignNewCasting.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDesignNewCasting.GradientColorOne = System.Drawing.Color.Olive
        Me.lblDesignNewCasting.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblDesignNewCasting.Location = New System.Drawing.Point(0, 0)
        Me.lblDesignNewCasting.Name = "lblDesignNewCasting"
        Me.lblDesignNewCasting.Size = New System.Drawing.Size(443, 19)
        Me.lblDesignNewCasting.TabIndex = 141
        Me.lblDesignNewCasting.Text = "Design New Casting"
        Me.lblDesignNewCasting.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSwingClearance2
        '
        Me.lblSwingClearance2.AutoSize = True
        Me.lblSwingClearance2.Location = New System.Drawing.Point(127, 129)
        Me.lblSwingClearance2.Name = "lblSwingClearance2"
        Me.lblSwingClearance2.Size = New System.Drawing.Size(87, 13)
        Me.lblSwingClearance2.TabIndex = 149
        Me.lblSwingClearance2.Text = "Swing Clearance"
        '
        'lblThreadedDiameter
        '
        Me.lblThreadedDiameter.AutoSize = True
        Me.lblThreadedDiameter.Location = New System.Drawing.Point(127, 43)
        Me.lblThreadedDiameter.Name = "lblThreadedDiameter"
        Me.lblThreadedDiameter.Size = New System.Drawing.Size(76, 13)
        Me.lblThreadedDiameter.TabIndex = 145
        Me.lblThreadedDiameter.Text = "Threaded Size"
        '
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(156, 152)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(128, 23)
        Me.btnAccept.TabIndex = 151
        Me.btnAccept.Text = "Accept"
        Me.btnAccept.UseVisualStyleBackColor = True
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
        Me.lblBackGround.Size = New System.Drawing.Size(464, 396)
        Me.lblBackGround.TabIndex = 118
        Me.lblBackGround.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlSafetyFactor_Weight_LugThickness
        '
        Me.pnlSafetyFactor_Weight_LugThickness.BackColor = System.Drawing.Color.Ivory
        Me.pnlSafetyFactor_Weight_LugThickness.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlSafetyFactor_Weight_LugThickness.Controls.Add(Me.lvwSafetyFactor_Weight)
        Me.pnlSafetyFactor_Weight_LugThickness.Controls.Add(Me.lblSafetyFactorIndex)
        Me.pnlSafetyFactor_Weight_LugThickness.Controls.Add(Me.btnAccept)
        Me.pnlSafetyFactor_Weight_LugThickness.Location = New System.Drawing.Point(21, 215)
        Me.pnlSafetyFactor_Weight_LugThickness.Name = "pnlSafetyFactor_Weight_LugThickness"
        Me.pnlSafetyFactor_Weight_LugThickness.Size = New System.Drawing.Size(445, 183)
        Me.pnlSafetyFactor_Weight_LugThickness.TabIndex = 119
        '
        'lvwSafetyFactor_Weight
        '
        Me.lvwSafetyFactor_Weight.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lvwSafetyFactor_Weight.GridLines = True
        Me.lvwSafetyFactor_Weight.Location = New System.Drawing.Point(25, 30)
        Me.lvwSafetyFactor_Weight.Name = "lvwSafetyFactor_Weight"
        Me.lvwSafetyFactor_Weight.Size = New System.Drawing.Size(390, 116)
        Me.lvwSafetyFactor_Weight.TabIndex = 13
        Me.lvwSafetyFactor_Weight.UseCompatibleStateImageBehavior = False
        Me.lvwSafetyFactor_Weight.View = System.Windows.Forms.View.Details
        '
        'lblSafetyFactorIndex
        '
        Me.lblSafetyFactorIndex.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblSafetyFactorIndex.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSafetyFactorIndex.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSafetyFactorIndex.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSafetyFactorIndex.GradientColorOne = System.Drawing.Color.Olive
        Me.lblSafetyFactorIndex.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblSafetyFactorIndex.Location = New System.Drawing.Point(0, 0)
        Me.lblSafetyFactorIndex.Name = "lblSafetyFactorIndex"
        Me.lblSafetyFactorIndex.Size = New System.Drawing.Size(441, 19)
        Me.lblSafetyFactorIndex.TabIndex = 159
        Me.lblSafetyFactorIndex.Text = "Generated Design Properties"
        Me.lblSafetyFactorIndex.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmDesignAThreadedCasting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(900, 650)
        Me.Controls.Add(Me.pnlSafetyFactor_Weight_LugThickness)
        Me.Controls.Add(Me.pnlDesignaCasting)
        Me.Controls.Add(Me.lblBackGround)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDesignAThreadedCasting"
        Me.Text = "frmDesignAThreadedCasting"
        Me.pnlDesignaCasting.ResumeLayout(False)
        Me.pnlDesignaCasting.PerformLayout()
        Me.pnlSafetyFactor_Weight_LugThickness.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlDesignaCasting As System.Windows.Forms.Panel
    Friend WithEvents lblThreadedLength As System.Windows.Forms.Label
    Friend WithEvents lblDesignNewCasting As LabelGradient.LabelGradient
    Friend WithEvents btnAccept As System.Windows.Forms.Button
    Friend WithEvents lblSwingClearance2 As System.Windows.Forms.Label
    Friend WithEvents lblThreadedDiameter As System.Windows.Forms.Label
    Friend WithEvents cmbThreadedDiameter As IFLCustomUILayer.IFLComboBox
    Friend WithEvents txtThreadedLength As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtSwingClearance As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblBackGround As LabelGradient.LabelGradient
    Friend WithEvents pnlSafetyFactor_Weight_LugThickness As System.Windows.Forms.Panel
    Friend WithEvents lvwSafetyFactor_Weight As Monarch_WeldedCylinder_01_09_09.clsListViewMIL
    Friend WithEvents lblSafetyFactorIndex As LabelGradient.LabelGradient
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
End Class
