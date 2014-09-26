<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBasePlugCastingYes
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblUseSelectedBasePlug = New System.Windows.Forms.Label
        Me.rdbUseSelectedBasePlugNo = New System.Windows.Forms.RadioButton
        Me.rdbUseSelectedBasePlugYes = New System.Windows.Forms.RadioButton
        Me.lblRequired = New System.Windows.Forms.Label
        Me.txtRequiredCost = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredSwingClearance = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredBasePlugDia = New IFLCustomUILayer.IFLNumericBox
        Me.txtCost = New IFLCustomUILayer.IFLNumericBox
        Me.lblCost = New System.Windows.Forms.Label
        Me.txtSwingClearance = New IFLCustomUILayer.IFLNumericBox
        Me.lblSwingClearance = New System.Windows.Forms.Label
        Me.txtBasePlugDia = New IFLCustomUILayer.IFLNumericBox
        Me.lblBasePlugDia = New System.Windows.Forms.Label
        Me.btnPicInformation = New System.Windows.Forms.Button
        Me.picCastingYes = New System.Windows.Forms.PictureBox
        Me.lvwBasePlugView = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL
        Me.lbThreadedEndCasting = New LabelGradient.LabelGradient
        Me.lblBackGround = New LabelGradient.LabelGradient
        Me.btnClickNextButton = New System.Windows.Forms.Button
        Me.grbCastingListView.SuspendLayout()
        CType(Me.picCastingYes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grbCastingListView
        '
        Me.grbCastingListView.BackColor = System.Drawing.Color.Ivory
        Me.grbCastingListView.Controls.Add(Me.Label3)
        Me.grbCastingListView.Controls.Add(Me.Label1)
        Me.grbCastingListView.Controls.Add(Me.Label2)
        Me.grbCastingListView.Controls.Add(Me.lblUseSelectedBasePlug)
        Me.grbCastingListView.Controls.Add(Me.rdbUseSelectedBasePlugNo)
        Me.grbCastingListView.Controls.Add(Me.rdbUseSelectedBasePlugYes)
        Me.grbCastingListView.Controls.Add(Me.lblRequired)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredCost)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredSwingClearance)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredBasePlugDia)
        Me.grbCastingListView.Controls.Add(Me.txtCost)
        Me.grbCastingListView.Controls.Add(Me.lblCost)
        Me.grbCastingListView.Controls.Add(Me.txtSwingClearance)
        Me.grbCastingListView.Controls.Add(Me.lblSwingClearance)
        Me.grbCastingListView.Controls.Add(Me.txtBasePlugDia)
        Me.grbCastingListView.Controls.Add(Me.lblBasePlugDia)
        Me.grbCastingListView.Controls.Add(Me.btnPicInformation)
        Me.grbCastingListView.Controls.Add(Me.picCastingYes)
        Me.grbCastingListView.Controls.Add(Me.lvwBasePlugView)
        Me.grbCastingListView.Controls.Add(Me.lbThreadedEndCasting)
        Me.grbCastingListView.Location = New System.Drawing.Point(30, 25)
        Me.grbCastingListView.Name = "grbCastingListView"
        Me.grbCastingListView.Size = New System.Drawing.Size(543, 268)
        Me.grbCastingListView.TabIndex = 118
        Me.grbCastingListView.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(449, 171)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 162
        Me.Label3.Text = "Required"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(104, 171)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 161
        Me.Label1.Text = "Available"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(352, 171)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 160
        Me.Label2.Text = "Available"
        '
        'lblUseSelectedBasePlug
        '
        Me.lblUseSelectedBasePlug.AutoSize = True
        Me.lblUseSelectedBasePlug.Location = New System.Drawing.Point(310, 230)
        Me.lblUseSelectedBasePlug.Name = "lblUseSelectedBasePlug"
        Me.lblUseSelectedBasePlug.Size = New System.Drawing.Size(119, 13)
        Me.lblUseSelectedBasePlug.TabIndex = 150
        Me.lblUseSelectedBasePlug.Text = "Use Selected BasePlug"
        '
        'rdbUseSelectedBasePlugNo
        '
        Me.rdbUseSelectedBasePlugNo.AutoSize = True
        Me.rdbUseSelectedBasePlugNo.Location = New System.Drawing.Point(486, 228)
        Me.rdbUseSelectedBasePlugNo.Name = "rdbUseSelectedBasePlugNo"
        Me.rdbUseSelectedBasePlugNo.Size = New System.Drawing.Size(39, 17)
        Me.rdbUseSelectedBasePlugNo.TabIndex = 149
        Me.rdbUseSelectedBasePlugNo.TabStop = True
        Me.rdbUseSelectedBasePlugNo.Text = "No"
        Me.rdbUseSelectedBasePlugNo.UseVisualStyleBackColor = True
        '
        'rdbUseSelectedBasePlugYes
        '
        Me.rdbUseSelectedBasePlugYes.AutoSize = True
        Me.rdbUseSelectedBasePlugYes.Location = New System.Drawing.Point(437, 228)
        Me.rdbUseSelectedBasePlugYes.Name = "rdbUseSelectedBasePlugYes"
        Me.rdbUseSelectedBasePlugYes.Size = New System.Drawing.Size(43, 17)
        Me.rdbUseSelectedBasePlugYes.TabIndex = 148
        Me.rdbUseSelectedBasePlugYes.TabStop = True
        Me.rdbUseSelectedBasePlugYes.Text = "Yes"
        Me.rdbUseSelectedBasePlugYes.UseVisualStyleBackColor = True
        '
        'lblRequired
        '
        Me.lblRequired.AutoSize = True
        Me.lblRequired.Location = New System.Drawing.Point(200, 171)
        Me.lblRequired.Name = "lblRequired"
        Me.lblRequired.Size = New System.Drawing.Size(50, 13)
        Me.lblRequired.TabIndex = 146
        Me.lblRequired.Text = "Required"
        '
        'txtRequiredCost
        '
        Me.txtRequiredCost.AcceptEnterKeyAsTab = True
        Me.txtRequiredCost.ApplyIFLColor = True
        Me.txtRequiredCost.AssociateLabel = Nothing
        Me.txtRequiredCost.DecimalValue = 2
        Me.txtRequiredCost.IFLDataTag = Nothing
        Me.txtRequiredCost.InvalidInputCharacters = ""
        Me.txtRequiredCost.IsAllowNegative = False
        Me.txtRequiredCost.LengthValue = 6
        Me.txtRequiredCost.Location = New System.Drawing.Point(442, 192)
        Me.txtRequiredCost.MaximumValue = 99999
        Me.txtRequiredCost.MaxLength = 6
        Me.txtRequiredCost.MinimumValue = 0
        Me.txtRequiredCost.Name = "txtRequiredCost"
        Me.txtRequiredCost.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredCost.StatusMessage = ""
        Me.txtRequiredCost.StatusObject = Nothing
        Me.txtRequiredCost.TabIndex = 145
        Me.txtRequiredCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredSwingClearance
        '
        Me.txtRequiredSwingClearance.AcceptEnterKeyAsTab = True
        Me.txtRequiredSwingClearance.ApplyIFLColor = True
        Me.txtRequiredSwingClearance.AssociateLabel = Nothing
        Me.txtRequiredSwingClearance.DecimalValue = 2
        Me.txtRequiredSwingClearance.IFLDataTag = Nothing
        Me.txtRequiredSwingClearance.InvalidInputCharacters = ""
        Me.txtRequiredSwingClearance.IsAllowNegative = False
        Me.txtRequiredSwingClearance.LengthValue = 6
        Me.txtRequiredSwingClearance.Location = New System.Drawing.Point(194, 226)
        Me.txtRequiredSwingClearance.MaximumValue = 99999
        Me.txtRequiredSwingClearance.MaxLength = 6
        Me.txtRequiredSwingClearance.MinimumValue = 0
        Me.txtRequiredSwingClearance.Name = "txtRequiredSwingClearance"
        Me.txtRequiredSwingClearance.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredSwingClearance.StatusMessage = ""
        Me.txtRequiredSwingClearance.StatusObject = Nothing
        Me.txtRequiredSwingClearance.TabIndex = 144
        Me.txtRequiredSwingClearance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRequiredBasePlugDia
        '
        Me.txtRequiredBasePlugDia.AcceptEnterKeyAsTab = True
        Me.txtRequiredBasePlugDia.ApplyIFLColor = True
        Me.txtRequiredBasePlugDia.AssociateLabel = Nothing
        Me.txtRequiredBasePlugDia.DecimalValue = 2
        Me.txtRequiredBasePlugDia.IFLDataTag = Nothing
        Me.txtRequiredBasePlugDia.InvalidInputCharacters = ""
        Me.txtRequiredBasePlugDia.IsAllowNegative = False
        Me.txtRequiredBasePlugDia.LengthValue = 6
        Me.txtRequiredBasePlugDia.Location = New System.Drawing.Point(194, 192)
        Me.txtRequiredBasePlugDia.MaximumValue = 99999
        Me.txtRequiredBasePlugDia.MaxLength = 6
        Me.txtRequiredBasePlugDia.MinimumValue = 0
        Me.txtRequiredBasePlugDia.Name = "txtRequiredBasePlugDia"
        Me.txtRequiredBasePlugDia.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredBasePlugDia.StatusMessage = ""
        Me.txtRequiredBasePlugDia.StatusObject = Nothing
        Me.txtRequiredBasePlugDia.TabIndex = 142
        Me.txtRequiredBasePlugDia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCost
        '
        Me.txtCost.AcceptEnterKeyAsTab = True
        Me.txtCost.ApplyIFLColor = True
        Me.txtCost.AssociateLabel = Nothing
        Me.txtCost.DecimalValue = 2
        Me.txtCost.IFLDataTag = Nothing
        Me.txtCost.InvalidInputCharacters = ""
        Me.txtCost.IsAllowNegative = False
        Me.txtCost.LengthValue = 6
        Me.txtCost.Location = New System.Drawing.Point(345, 192)
        Me.txtCost.MaximumValue = 99999
        Me.txtCost.MaxLength = 6
        Me.txtCost.MinimumValue = 0
        Me.txtCost.Name = "txtCost"
        Me.txtCost.Size = New System.Drawing.Size(66, 20)
        Me.txtCost.StatusMessage = ""
        Me.txtCost.StatusObject = Nothing
        Me.txtCost.TabIndex = 138
        Me.txtCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCost
        '
        Me.lblCost.AutoSize = True
        Me.lblCost.Location = New System.Drawing.Point(310, 196)
        Me.lblCost.Name = "lblCost"
        Me.lblCost.Size = New System.Drawing.Size(28, 13)
        Me.lblCost.TabIndex = 139
        Me.lblCost.Text = "Cost"
        '
        'txtSwingClearance
        '
        Me.txtSwingClearance.AcceptEnterKeyAsTab = True
        Me.txtSwingClearance.ApplyIFLColor = True
        Me.txtSwingClearance.AssociateLabel = Nothing
        Me.txtSwingClearance.DecimalValue = 2
        Me.txtSwingClearance.IFLDataTag = Nothing
        Me.txtSwingClearance.InvalidInputCharacters = ""
        Me.txtSwingClearance.IsAllowNegative = False
        Me.txtSwingClearance.LengthValue = 6
        Me.txtSwingClearance.Location = New System.Drawing.Point(97, 226)
        Me.txtSwingClearance.MaximumValue = 99999
        Me.txtSwingClearance.MaxLength = 6
        Me.txtSwingClearance.MinimumValue = 0
        Me.txtSwingClearance.Name = "txtSwingClearance"
        Me.txtSwingClearance.Size = New System.Drawing.Size(66, 20)
        Me.txtSwingClearance.StatusMessage = ""
        Me.txtSwingClearance.StatusObject = Nothing
        Me.txtSwingClearance.TabIndex = 136
        Me.txtSwingClearance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSwingClearance
        '
        Me.lblSwingClearance.AutoSize = True
        Me.lblSwingClearance.Location = New System.Drawing.Point(3, 230)
        Me.lblSwingClearance.Name = "lblSwingClearance"
        Me.lblSwingClearance.Size = New System.Drawing.Size(87, 13)
        Me.lblSwingClearance.TabIndex = 137
        Me.lblSwingClearance.Text = "Swing Clearance"
        '
        'txtBasePlugDia
        '
        Me.txtBasePlugDia.AcceptEnterKeyAsTab = True
        Me.txtBasePlugDia.ApplyIFLColor = True
        Me.txtBasePlugDia.AssociateLabel = Nothing
        Me.txtBasePlugDia.DecimalValue = 2
        Me.txtBasePlugDia.IFLDataTag = Nothing
        Me.txtBasePlugDia.InvalidInputCharacters = ""
        Me.txtBasePlugDia.IsAllowNegative = False
        Me.txtBasePlugDia.LengthValue = 6
        Me.txtBasePlugDia.Location = New System.Drawing.Point(97, 192)
        Me.txtBasePlugDia.MaximumValue = 99999
        Me.txtBasePlugDia.MaxLength = 6
        Me.txtBasePlugDia.MinimumValue = 0
        Me.txtBasePlugDia.Name = "txtBasePlugDia"
        Me.txtBasePlugDia.Size = New System.Drawing.Size(66, 20)
        Me.txtBasePlugDia.StatusMessage = ""
        Me.txtBasePlugDia.StatusObject = Nothing
        Me.txtBasePlugDia.TabIndex = 132
        Me.txtBasePlugDia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBasePlugDia
        '
        Me.lblBasePlugDia.AutoSize = True
        Me.lblBasePlugDia.Location = New System.Drawing.Point(16, 196)
        Me.lblBasePlugDia.Name = "lblBasePlugDia"
        Me.lblBasePlugDia.Size = New System.Drawing.Size(74, 13)
        Me.lblBasePlugDia.TabIndex = 133
        Me.lblBasePlugDia.Text = "Base Plug Dia"
        '
        'btnPicInformation
        '
        Me.btnPicInformation.Enabled = False
        Me.btnPicInformation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPicInformation.Location = New System.Drawing.Point(415, 88)
        Me.btnPicInformation.Name = "btnPicInformation"
        Me.btnPicInformation.Size = New System.Drawing.Size(95, 23)
        Me.btnPicInformation.TabIndex = 131
        Me.btnPicInformation.Text = "Show Image"
        Me.btnPicInformation.UseVisualStyleBackColor = True
        '
        'picCastingYes
        '
        Me.picCastingYes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picCastingYes.Location = New System.Drawing.Point(386, 33)
        Me.picCastingYes.Name = "picCastingYes"
        Me.picCastingYes.Size = New System.Drawing.Size(151, 122)
        Me.picCastingYes.TabIndex = 130
        Me.picCastingYes.TabStop = False
        '
        'lvwBasePlugView
        '
        Me.lvwBasePlugView.FullRowSelect = True
        Me.lvwBasePlugView.GridLines = True
        Me.lvwBasePlugView.Location = New System.Drawing.Point(6, 33)
        Me.lvwBasePlugView.MultiSelect = False
        Me.lvwBasePlugView.Name = "lvwBasePlugView"
        Me.lvwBasePlugView.Scrollable = False
        Me.lvwBasePlugView.Size = New System.Drawing.Size(369, 122)
        Me.lvwBasePlugView.TabIndex = 1
        Me.lvwBasePlugView.UseCompatibleStateImageBehavior = False
        Me.lvwBasePlugView.View = System.Windows.Forms.View.Details
        '
        'lbThreadedEndCasting
        '
        Me.lbThreadedEndCasting.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lbThreadedEndCasting.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbThreadedEndCasting.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbThreadedEndCasting.GradientColorOne = System.Drawing.Color.Olive
        Me.lbThreadedEndCasting.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lbThreadedEndCasting.Location = New System.Drawing.Point(-3, 0)
        Me.lbThreadedEndCasting.Name = "lbThreadedEndCasting"
        Me.lbThreadedEndCasting.Size = New System.Drawing.Size(546, 19)
        Me.lbThreadedEndCasting.TabIndex = 110
        Me.lbThreadedEndCasting.Text = "Existing  Base Plug Casting Details"
        Me.lbThreadedEndCasting.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.lblBackGround.Size = New System.Drawing.Size(578, 298)
        Me.lblBackGround.TabIndex = 119
        Me.lblBackGround.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnClickNextButton
        '
        Me.btnClickNextButton.BackColor = System.Drawing.Color.Ivory
        Me.btnClickNextButton.Enabled = False
        Me.btnClickNextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClickNextButton.Location = New System.Drawing.Point(283, 310)
        Me.btnClickNextButton.Name = "btnClickNextButton"
        Me.btnClickNextButton.Size = New System.Drawing.Size(158, 34)
        Me.btnClickNextButton.TabIndex = 121
        Me.btnClickNextButton.Text = "Click Next Button"
        Me.btnClickNextButton.UseVisualStyleBackColor = False
        '
        'frmBasePlugCastingYes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(900, 650)
        Me.Controls.Add(Me.btnClickNextButton)
        Me.Controls.Add(Me.grbCastingListView)
        Me.Controls.Add(Me.lblBackGround)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmBasePlugCastingYes"
        Me.Text = "Form2"
        Me.grbCastingListView.ResumeLayout(False)
        Me.grbCastingListView.PerformLayout()
        CType(Me.picCastingYes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbCastingListView As System.Windows.Forms.GroupBox
    Friend WithEvents lblRequired As System.Windows.Forms.Label
    Friend WithEvents txtRequiredCost As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredSwingClearance As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredBasePlugDia As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtCost As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblCost As System.Windows.Forms.Label
    Friend WithEvents txtSwingClearance As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSwingClearance As System.Windows.Forms.Label
    Friend WithEvents txtBasePlugDia As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblBasePlugDia As System.Windows.Forms.Label
    Friend WithEvents btnPicInformation As System.Windows.Forms.Button
    Friend WithEvents picCastingYes As System.Windows.Forms.PictureBox
    Friend WithEvents lvwBasePlugView As Monarch_WeldedCylinder_01_09_09.clsListViewMIL
    Friend WithEvents lbThreadedEndCasting As LabelGradient.LabelGradient
    Friend WithEvents lblBackGround As LabelGradient.LabelGradient
    Friend WithEvents lblUseSelectedBasePlug As System.Windows.Forms.Label
    Friend WithEvents rdbUseSelectedBasePlugNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbUseSelectedBasePlugYes As System.Windows.Forms.RadioButton
    Friend WithEvents btnClickNextButton As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
