<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThreadedEndCastingYes
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
        Me.lblBackGround = New LabelGradient.LabelGradient
        Me.grbCastingListView = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblUseSelectedThreadedEnd = New System.Windows.Forms.Label
        Me.rdbUseSelectedThreadedEndNo = New System.Windows.Forms.RadioButton
        Me.lblRequired = New System.Windows.Forms.Label
        Me.rdbUseSelectedThreadedEndYes = New System.Windows.Forms.RadioButton
        Me.txtRequiredThreadLength = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredCost = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredSwingClearance = New IFLCustomUILayer.IFLNumericBox
        Me.txtRequiredThreadDiameter = New IFLCustomUILayer.IFLNumericBox
        Me.txtCost = New IFLCustomUILayer.IFLNumericBox
        Me.lblCost = New System.Windows.Forms.Label
        Me.txtSwingClearance = New IFLCustomUILayer.IFLNumericBox
        Me.lblSwingClearance = New System.Windows.Forms.Label
        Me.txtThreadLength = New IFLCustomUILayer.IFLNumericBox
        Me.lblThreadLength = New System.Windows.Forms.Label
        Me.txtThreadDiameter = New IFLCustomUILayer.IFLNumericBox
        Me.lblThreadDiameter = New System.Windows.Forms.Label
        Me.btnPicInformation = New System.Windows.Forms.Button
        Me.picCastingYes = New System.Windows.Forms.PictureBox
        Me.lvwThreadedEndListView = New Monarch_WeldedCylinder_01_09_09.clsListViewMIL
        Me.lbThreadedEndCasting = New LabelGradient.LabelGradient
        Me.grbCastingListView.SuspendLayout()
        CType(Me.picCastingYes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.lblBackGround.Size = New System.Drawing.Size(578, 391)
        Me.lblBackGround.TabIndex = 117
        Me.lblBackGround.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grbCastingListView
        '
        Me.grbCastingListView.BackColor = System.Drawing.Color.Ivory
        Me.grbCastingListView.Controls.Add(Me.Label2)
        Me.grbCastingListView.Controls.Add(Me.lblUseSelectedThreadedEnd)
        Me.grbCastingListView.Controls.Add(Me.rdbUseSelectedThreadedEndNo)
        Me.grbCastingListView.Controls.Add(Me.lblRequired)
        Me.grbCastingListView.Controls.Add(Me.rdbUseSelectedThreadedEndYes)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredThreadLength)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredCost)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredSwingClearance)
        Me.grbCastingListView.Controls.Add(Me.txtRequiredThreadDiameter)
        Me.grbCastingListView.Controls.Add(Me.txtCost)
        Me.grbCastingListView.Controls.Add(Me.lblCost)
        Me.grbCastingListView.Controls.Add(Me.txtSwingClearance)
        Me.grbCastingListView.Controls.Add(Me.lblSwingClearance)
        Me.grbCastingListView.Controls.Add(Me.txtThreadLength)
        Me.grbCastingListView.Controls.Add(Me.lblThreadLength)
        Me.grbCastingListView.Controls.Add(Me.txtThreadDiameter)
        Me.grbCastingListView.Controls.Add(Me.lblThreadDiameter)
        Me.grbCastingListView.Controls.Add(Me.btnPicInformation)
        Me.grbCastingListView.Controls.Add(Me.picCastingYes)
        Me.grbCastingListView.Controls.Add(Me.lvwThreadedEndListView)
        Me.grbCastingListView.Controls.Add(Me.lbThreadedEndCasting)
        Me.grbCastingListView.Location = New System.Drawing.Point(30, 18)
        Me.grbCastingListView.Name = "grbCastingListView"
        Me.grbCastingListView.Size = New System.Drawing.Size(543, 367)
        Me.grbCastingListView.TabIndex = 114
        Me.grbCastingListView.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(246, 175)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 162
        Me.Label2.Text = "Available"
        '
        'lblUseSelectedThreadedEnd
        '
        Me.lblUseSelectedThreadedEnd.AutoSize = True
        Me.lblUseSelectedThreadedEnd.Location = New System.Drawing.Point(156, 344)
        Me.lblUseSelectedThreadedEnd.Name = "lblUseSelectedThreadedEnd"
        Me.lblUseSelectedThreadedEnd.Size = New System.Drawing.Size(142, 13)
        Me.lblUseSelectedThreadedEnd.TabIndex = 148
        Me.lblUseSelectedThreadedEnd.Text = "Use Selected Threaded End"
        '
        'rdbUseSelectedThreadedEndNo
        '
        Me.rdbUseSelectedThreadedEndNo.AutoSize = True
        Me.rdbUseSelectedThreadedEndNo.Location = New System.Drawing.Point(353, 342)
        Me.rdbUseSelectedThreadedEndNo.Name = "rdbUseSelectedThreadedEndNo"
        Me.rdbUseSelectedThreadedEndNo.Size = New System.Drawing.Size(39, 17)
        Me.rdbUseSelectedThreadedEndNo.TabIndex = 147
        Me.rdbUseSelectedThreadedEndNo.TabStop = True
        Me.rdbUseSelectedThreadedEndNo.Text = "No"
        Me.rdbUseSelectedThreadedEndNo.UseVisualStyleBackColor = True
        '
        'lblRequired
        '
        Me.lblRequired.AutoSize = True
        Me.lblRequired.Location = New System.Drawing.Point(342, 175)
        Me.lblRequired.Name = "lblRequired"
        Me.lblRequired.Size = New System.Drawing.Size(50, 13)
        Me.lblRequired.TabIndex = 146
        Me.lblRequired.Text = "Required"
        '
        'rdbUseSelectedThreadedEndYes
        '
        Me.rdbUseSelectedThreadedEndYes.AutoSize = True
        Me.rdbUseSelectedThreadedEndYes.Location = New System.Drawing.Point(304, 342)
        Me.rdbUseSelectedThreadedEndYes.Name = "rdbUseSelectedThreadedEndYes"
        Me.rdbUseSelectedThreadedEndYes.Size = New System.Drawing.Size(43, 17)
        Me.rdbUseSelectedThreadedEndYes.TabIndex = 146
        Me.rdbUseSelectedThreadedEndYes.TabStop = True
        Me.rdbUseSelectedThreadedEndYes.Text = "Yes"
        Me.rdbUseSelectedThreadedEndYes.UseVisualStyleBackColor = True
        '
        'txtRequiredThreadLength
        '
        Me.txtRequiredThreadLength.AcceptEnterKeyAsTab = True
        Me.txtRequiredThreadLength.ApplyIFLColor = True
        Me.txtRequiredThreadLength.AssociateLabel = Nothing
        Me.txtRequiredThreadLength.DecimalValue = 2
        Me.txtRequiredThreadLength.IFLDataTag = Nothing
        Me.txtRequiredThreadLength.InvalidInputCharacters = ""
        Me.txtRequiredThreadLength.IsAllowNegative = False
        Me.txtRequiredThreadLength.LengthValue = 6
        Me.txtRequiredThreadLength.Location = New System.Drawing.Point(334, 241)
        Me.txtRequiredThreadLength.MaximumValue = 99999
        Me.txtRequiredThreadLength.MaxLength = 6
        Me.txtRequiredThreadLength.MinimumValue = 0
        Me.txtRequiredThreadLength.Name = "txtRequiredThreadLength"
        Me.txtRequiredThreadLength.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredThreadLength.StatusMessage = ""
        Me.txtRequiredThreadLength.StatusObject = Nothing
        Me.txtRequiredThreadLength.TabIndex = 143
        Me.txtRequiredThreadLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.txtRequiredCost.Location = New System.Drawing.Point(334, 313)
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
        Me.txtRequiredSwingClearance.Location = New System.Drawing.Point(334, 277)
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
        'txtRequiredThreadDiameter
        '
        Me.txtRequiredThreadDiameter.AcceptEnterKeyAsTab = True
        Me.txtRequiredThreadDiameter.ApplyIFLColor = True
        Me.txtRequiredThreadDiameter.AssociateLabel = Nothing
        Me.txtRequiredThreadDiameter.DecimalValue = 2
        Me.txtRequiredThreadDiameter.IFLDataTag = Nothing
        Me.txtRequiredThreadDiameter.InvalidInputCharacters = ""
        Me.txtRequiredThreadDiameter.IsAllowNegative = False
        Me.txtRequiredThreadDiameter.LengthValue = 6
        Me.txtRequiredThreadDiameter.Location = New System.Drawing.Point(334, 205)
        Me.txtRequiredThreadDiameter.MaximumValue = 99999
        Me.txtRequiredThreadDiameter.MaxLength = 6
        Me.txtRequiredThreadDiameter.MinimumValue = 0
        Me.txtRequiredThreadDiameter.Name = "txtRequiredThreadDiameter"
        Me.txtRequiredThreadDiameter.Size = New System.Drawing.Size(66, 20)
        Me.txtRequiredThreadDiameter.StatusMessage = ""
        Me.txtRequiredThreadDiameter.StatusObject = Nothing
        Me.txtRequiredThreadDiameter.TabIndex = 142
        Me.txtRequiredThreadDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.txtCost.Location = New System.Drawing.Point(237, 313)
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
        Me.lblCost.Location = New System.Drawing.Point(163, 317)
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
        Me.txtSwingClearance.Location = New System.Drawing.Point(237, 277)
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
        Me.lblSwingClearance.Location = New System.Drawing.Point(104, 281)
        Me.lblSwingClearance.Name = "lblSwingClearance"
        Me.lblSwingClearance.Size = New System.Drawing.Size(87, 13)
        Me.lblSwingClearance.TabIndex = 137
        Me.lblSwingClearance.Text = "Swing Clearance"
        '
        'txtThreadLength
        '
        Me.txtThreadLength.AcceptEnterKeyAsTab = True
        Me.txtThreadLength.ApplyIFLColor = True
        Me.txtThreadLength.AssociateLabel = Nothing
        Me.txtThreadLength.DecimalValue = 2
        Me.txtThreadLength.IFLDataTag = Nothing
        Me.txtThreadLength.InvalidInputCharacters = ""
        Me.txtThreadLength.IsAllowNegative = False
        Me.txtThreadLength.LengthValue = 6
        Me.txtThreadLength.Location = New System.Drawing.Point(237, 241)
        Me.txtThreadLength.MaximumValue = 99999
        Me.txtThreadLength.MaxLength = 6
        Me.txtThreadLength.MinimumValue = 0
        Me.txtThreadLength.Name = "txtThreadLength"
        Me.txtThreadLength.Size = New System.Drawing.Size(66, 20)
        Me.txtThreadLength.StatusMessage = ""
        Me.txtThreadLength.StatusObject = Nothing
        Me.txtThreadLength.TabIndex = 134
        Me.txtThreadLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblThreadLength
        '
        Me.lblThreadLength.AutoSize = True
        Me.lblThreadLength.Location = New System.Drawing.Point(114, 245)
        Me.lblThreadLength.Name = "lblThreadLength"
        Me.lblThreadLength.Size = New System.Drawing.Size(77, 13)
        Me.lblThreadLength.TabIndex = 135
        Me.lblThreadLength.Text = "Thread Length"
        '
        'txtThreadDiameter
        '
        Me.txtThreadDiameter.AcceptEnterKeyAsTab = True
        Me.txtThreadDiameter.ApplyIFLColor = True
        Me.txtThreadDiameter.AssociateLabel = Nothing
        Me.txtThreadDiameter.DecimalValue = 2
        Me.txtThreadDiameter.IFLDataTag = Nothing
        Me.txtThreadDiameter.InvalidInputCharacters = ""
        Me.txtThreadDiameter.IsAllowNegative = False
        Me.txtThreadDiameter.LengthValue = 6
        Me.txtThreadDiameter.Location = New System.Drawing.Point(237, 205)
        Me.txtThreadDiameter.MaximumValue = 99999
        Me.txtThreadDiameter.MaxLength = 6
        Me.txtThreadDiameter.MinimumValue = 0
        Me.txtThreadDiameter.Name = "txtThreadDiameter"
        Me.txtThreadDiameter.Size = New System.Drawing.Size(66, 20)
        Me.txtThreadDiameter.StatusMessage = ""
        Me.txtThreadDiameter.StatusObject = Nothing
        Me.txtThreadDiameter.TabIndex = 132
        Me.txtThreadDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblThreadDiameter
        '
        Me.lblThreadDiameter.AutoSize = True
        Me.lblThreadDiameter.Location = New System.Drawing.Point(105, 209)
        Me.lblThreadDiameter.Name = "lblThreadDiameter"
        Me.lblThreadDiameter.Size = New System.Drawing.Size(86, 13)
        Me.lblThreadDiameter.TabIndex = 133
        Me.lblThreadDiameter.Text = "Thread Diameter"
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
        'lvwThreadedEndListView
        '
        Me.lvwThreadedEndListView.FullRowSelect = True
        Me.lvwThreadedEndListView.GridLines = True
        Me.lvwThreadedEndListView.Location = New System.Drawing.Point(6, 33)
        Me.lvwThreadedEndListView.MultiSelect = False
        Me.lvwThreadedEndListView.Name = "lvwThreadedEndListView"
        Me.lvwThreadedEndListView.Scrollable = False
        Me.lvwThreadedEndListView.Size = New System.Drawing.Size(369, 122)
        Me.lvwThreadedEndListView.TabIndex = 1
        Me.lvwThreadedEndListView.UseCompatibleStateImageBehavior = False
        Me.lvwThreadedEndListView.View = System.Windows.Forms.View.Details
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
        Me.lbThreadedEndCasting.Text = "Existing Threaded End Casting Details"
        Me.lbThreadedEndCasting.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmThreadedEndCastingYes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(900, 650)
        Me.Controls.Add(Me.grbCastingListView)
        Me.Controls.Add(Me.lblBackGround)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmThreadedEndCastingYes"
        Me.Text = "Form2"
        Me.grbCastingListView.ResumeLayout(False)
        Me.grbCastingListView.PerformLayout()
        CType(Me.picCastingYes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblBackGround As LabelGradient.LabelGradient
    Friend WithEvents grbCastingListView As System.Windows.Forms.GroupBox
    Friend WithEvents btnPicInformation As System.Windows.Forms.Button
    Friend WithEvents picCastingYes As System.Windows.Forms.PictureBox
    Friend WithEvents lvwThreadedEndListView As Monarch_WeldedCylinder_01_09_09.clsListViewMIL
    Friend WithEvents lbThreadedEndCasting As LabelGradient.LabelGradient
    Friend WithEvents txtThreadDiameter As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblThreadDiameter As System.Windows.Forms.Label
    Friend WithEvents txtThreadLength As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblThreadLength As System.Windows.Forms.Label
    Friend WithEvents txtSwingClearance As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblSwingClearance As System.Windows.Forms.Label
    Friend WithEvents txtCost As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblCost As System.Windows.Forms.Label
    Friend WithEvents lblRequired As System.Windows.Forms.Label
    Friend WithEvents txtRequiredThreadLength As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredCost As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredSwingClearance As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtRequiredThreadDiameter As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents lblUseSelectedThreadedEnd As System.Windows.Forms.Label
    Friend WithEvents rdbUseSelectedThreadedEndNo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbUseSelectedThreadedEndYes As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
