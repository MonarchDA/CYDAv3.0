<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHeadDesign
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
        Me.LabelGradient5 = New LabelGradient.LabelGradient
        Me.LabelGradient4 = New LabelGradient.LabelGradient
        Me.LabelGradient3 = New LabelGradient.LabelGradient
        Me.LabelGradient2 = New LabelGradient.LabelGradient
        Me.grbHeadDesign = New System.Windows.Forms.GroupBox
        Me.txtSealType = New System.Windows.Forms.TextBox
        Me.txtCylinderHeadCode = New IFLCustomUILayer.IFLNumericBox
        Me.lblCylinderHeadCode = New System.Windows.Forms.Label
        Me.cmbRodWearRingQty = New IFLCustomUILayer.IFLComboBox
        Me.lblRodWearRingQty = New System.Windows.Forms.Label
        Me.cmbRodWiperType = New IFLCustomUILayer.IFLComboBox
        Me.cmbRodWearRing = New IFLCustomUILayer.IFLComboBox
        Me.lblRodWiperType = New System.Windows.Forms.Label
        Me.lblRodWearRing = New System.Windows.Forms.Label
        Me.cmbRodSeal = New IFLCustomUILayer.IFLComboBox
        Me.cmbHeadType = New IFLCustomUILayer.IFLComboBox
        Me.lblRodSeal = New System.Windows.Forms.Label
        Me.lblHeadDesignIndex = New LabelGradient.LabelGradient
        Me.lblHeadType = New System.Windows.Forms.Label
        Me.lblHeadDesign = New LabelGradient.LabelGradient
        Me.grbInsertCylinderHeadDetailsIntoDB = New System.Windows.Forms.GroupBox
        Me.btnHeadDesignContinue = New System.Windows.Forms.Button
        Me.lblMessage = New System.Windows.Forms.Label
        Me.lblInsertCylinderHeadDetails = New LabelGradient.LabelGradient
        Me.lblInsertIntoDb = New LabelGradient.LabelGradient
        Me.temCylinderHeadCode = New IFLCustomUILayer.IFLNumericBox
        Me.grbHeadDesign.SuspendLayout()
        Me.grbInsertCylinderHeadDetailsIntoDB.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelGradient5
        '
        Me.LabelGradient5.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient5.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelGradient5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient5.GradientColorOne = System.Drawing.Color.Olive
        Me.LabelGradient5.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient5.Location = New System.Drawing.Point(20, 0)
        Me.LabelGradient5.Name = "LabelGradient5"
        Me.LabelGradient5.Size = New System.Drawing.Size(994, 19)
        Me.LabelGradient5.TabIndex = 41
        Me.LabelGradient5.Text = "Head Design"
        Me.LabelGradient5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelGradient4
        '
        Me.LabelGradient4.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient4.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelGradient4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient4.GradientColorOne = System.Drawing.Color.Olive
        Me.LabelGradient4.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient4.Location = New System.Drawing.Point(1014, 0)
        Me.LabelGradient4.Name = "LabelGradient4"
        Me.LabelGradient4.Size = New System.Drawing.Size(22, 761)
        Me.LabelGradient4.TabIndex = 40
        Me.LabelGradient4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelGradient3
        '
        Me.LabelGradient3.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient3.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelGradient3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient3.GradientColorOne = System.Drawing.Color.Olive
        Me.LabelGradient3.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient3.Location = New System.Drawing.Point(0, 0)
        Me.LabelGradient3.Name = "LabelGradient3"
        Me.LabelGradient3.Size = New System.Drawing.Size(20, 761)
        Me.LabelGradient3.TabIndex = 39
        Me.LabelGradient3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelGradient2
        '
        Me.LabelGradient2.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LabelGradient2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient2.GradientColorOne = System.Drawing.Color.Olive
        Me.LabelGradient2.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient2.Location = New System.Drawing.Point(0, 761)
        Me.LabelGradient2.Name = "LabelGradient2"
        Me.LabelGradient2.Size = New System.Drawing.Size(1036, 19)
        Me.LabelGradient2.TabIndex = 38
        Me.LabelGradient2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grbHeadDesign
        '
        Me.grbHeadDesign.BackColor = System.Drawing.Color.Ivory
        Me.grbHeadDesign.Controls.Add(Me.txtSealType)
        Me.grbHeadDesign.Controls.Add(Me.txtCylinderHeadCode)
        Me.grbHeadDesign.Controls.Add(Me.lblCylinderHeadCode)
        Me.grbHeadDesign.Controls.Add(Me.cmbRodWearRingQty)
        Me.grbHeadDesign.Controls.Add(Me.lblRodWearRingQty)
        Me.grbHeadDesign.Controls.Add(Me.cmbRodWiperType)
        Me.grbHeadDesign.Controls.Add(Me.cmbRodWearRing)
        Me.grbHeadDesign.Controls.Add(Me.lblRodWiperType)
        Me.grbHeadDesign.Controls.Add(Me.lblRodWearRing)
        Me.grbHeadDesign.Controls.Add(Me.cmbRodSeal)
        Me.grbHeadDesign.Controls.Add(Me.cmbHeadType)
        Me.grbHeadDesign.Controls.Add(Me.lblRodSeal)
        Me.grbHeadDesign.Controls.Add(Me.lblHeadDesignIndex)
        Me.grbHeadDesign.Controls.Add(Me.lblHeadType)
        Me.grbHeadDesign.Location = New System.Drawing.Point(43, 47)
        Me.grbHeadDesign.Name = "grbHeadDesign"
        Me.grbHeadDesign.Size = New System.Drawing.Size(713, 114)
        Me.grbHeadDesign.TabIndex = 0
        Me.grbHeadDesign.TabStop = False
        '
        'txtSealType
        '
        Me.txtSealType.Location = New System.Drawing.Point(340, 37)
        Me.txtSealType.Name = "txtSealType"
        Me.txtSealType.Size = New System.Drawing.Size(98, 20)
        Me.txtSealType.TabIndex = 156
        Me.txtSealType.Text = "RU9 Rod Seal"
        '
        'txtCylinderHeadCode
        '
        Me.txtCylinderHeadCode.AcceptEnterKeyAsTab = True
        Me.txtCylinderHeadCode.ApplyIFLColor = True
        Me.txtCylinderHeadCode.AssociateLabel = Nothing
        Me.txtCylinderHeadCode.DecimalValue = 2
        Me.txtCylinderHeadCode.IFLDataTag = Nothing
        Me.txtCylinderHeadCode.InvalidInputCharacters = ""
        Me.txtCylinderHeadCode.IsAllowNegative = False
        Me.txtCylinderHeadCode.LengthValue = 5
        Me.txtCylinderHeadCode.Location = New System.Drawing.Point(609, 74)
        Me.txtCylinderHeadCode.MaximumValue = 99999999999999
        Me.txtCylinderHeadCode.MaxLength = 10
        Me.txtCylinderHeadCode.MinimumValue = 0
        Me.txtCylinderHeadCode.Name = "txtCylinderHeadCode"
        Me.txtCylinderHeadCode.Size = New System.Drawing.Size(98, 20)
        Me.txtCylinderHeadCode.StatusMessage = ""
        Me.txtCylinderHeadCode.StatusObject = Nothing
        Me.txtCylinderHeadCode.TabIndex = 6
        Me.txtCylinderHeadCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCylinderHeadCode
        '
        Me.lblCylinderHeadCode.AutoSize = True
        Me.lblCylinderHeadCode.Location = New System.Drawing.Point(496, 77)
        Me.lblCylinderHeadCode.Name = "lblCylinderHeadCode"
        Me.lblCylinderHeadCode.Size = New System.Drawing.Size(101, 13)
        Me.lblCylinderHeadCode.TabIndex = 132
        Me.lblCylinderHeadCode.Text = "Cylinder Head Code"
        '
        'cmbRodWearRingQty
        '
        Me.cmbRodWearRingQty.AcceptEnterKeyAsTab = True
        Me.cmbRodWearRingQty.AssociateLabel = Nothing
        Me.cmbRodWearRingQty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRodWearRingQty.FormattingEnabled = True
        Me.cmbRodWearRingQty.IFLDataTag = Nothing
        Me.cmbRodWearRingQty.Location = New System.Drawing.Point(340, 74)
        Me.cmbRodWearRingQty.Name = "cmbRodWearRingQty"
        Me.cmbRodWearRingQty.Size = New System.Drawing.Size(98, 21)
        Me.cmbRodWearRingQty.StatusMessage = Nothing
        Me.cmbRodWearRingQty.StatusObject = Nothing
        Me.cmbRodWearRingQty.TabIndex = 5
        '
        'lblRodWearRingQty
        '
        Me.lblRodWearRingQty.AutoSize = True
        Me.lblRodWearRingQty.Location = New System.Drawing.Point(229, 77)
        Me.lblRodWearRingQty.Name = "lblRodWearRingQty"
        Me.lblRodWearRingQty.Size = New System.Drawing.Size(100, 13)
        Me.lblRodWearRingQty.TabIndex = 130
        Me.lblRodWearRingQty.Text = "Rod Wear Ring Qty"
        '
        'cmbRodWiperType
        '
        Me.cmbRodWiperType.AcceptEnterKeyAsTab = True
        Me.cmbRodWiperType.AssociateLabel = Nothing
        Me.cmbRodWiperType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRodWiperType.FormattingEnabled = True
        Me.cmbRodWiperType.IFLDataTag = Nothing
        Me.cmbRodWiperType.Location = New System.Drawing.Point(609, 36)
        Me.cmbRodWiperType.Name = "cmbRodWiperType"
        Me.cmbRodWiperType.Size = New System.Drawing.Size(98, 21)
        Me.cmbRodWiperType.StatusMessage = Nothing
        Me.cmbRodWiperType.StatusObject = Nothing
        Me.cmbRodWiperType.TabIndex = 3
        '
        'cmbRodWearRing
        '
        Me.cmbRodWearRing.AcceptEnterKeyAsTab = True
        Me.cmbRodWearRing.AssociateLabel = Nothing
        Me.cmbRodWearRing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRodWearRing.FormattingEnabled = True
        Me.cmbRodWearRing.IFLDataTag = Nothing
        Me.cmbRodWearRing.Items.AddRange(New Object() {"YES"})
        Me.cmbRodWearRing.Location = New System.Drawing.Point(94, 74)
        Me.cmbRodWearRing.Name = "cmbRodWearRing"
        Me.cmbRodWearRing.Size = New System.Drawing.Size(98, 21)
        Me.cmbRodWearRing.StatusMessage = Nothing
        Me.cmbRodWearRing.StatusObject = Nothing
        Me.cmbRodWearRing.TabIndex = 4
        '
        'lblRodWiperType
        '
        Me.lblRodWiperType.AutoSize = True
        Me.lblRodWiperType.Location = New System.Drawing.Point(512, 39)
        Me.lblRodWiperType.Name = "lblRodWiperType"
        Me.lblRodWiperType.Size = New System.Drawing.Size(85, 13)
        Me.lblRodWiperType.TabIndex = 127
        Me.lblRodWiperType.Text = "Rod Wiper Type"
        '
        'lblRodWearRing
        '
        Me.lblRodWearRing.AutoSize = True
        Me.lblRodWearRing.Location = New System.Drawing.Point(7, 77)
        Me.lblRodWearRing.Name = "lblRodWearRing"
        Me.lblRodWearRing.Size = New System.Drawing.Size(81, 13)
        Me.lblRodWearRing.TabIndex = 125
        Me.lblRodWearRing.Text = "Rod Wear Ring"
        '
        'cmbRodSeal
        '
        Me.cmbRodSeal.AcceptEnterKeyAsTab = True
        Me.cmbRodSeal.AssociateLabel = Nothing
        Me.cmbRodSeal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRodSeal.FormattingEnabled = True
        Me.cmbRodSeal.IFLDataTag = Nothing
        Me.cmbRodSeal.Location = New System.Drawing.Point(340, 36)
        Me.cmbRodSeal.Name = "cmbRodSeal"
        Me.cmbRodSeal.Size = New System.Drawing.Size(98, 21)
        Me.cmbRodSeal.StatusMessage = Nothing
        Me.cmbRodSeal.StatusObject = Nothing
        Me.cmbRodSeal.TabIndex = 2
        '
        'cmbHeadType
        '
        Me.cmbHeadType.AcceptEnterKeyAsTab = True
        Me.cmbHeadType.AssociateLabel = Nothing
        Me.cmbHeadType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbHeadType.DropDownWidth = 120
        Me.cmbHeadType.FormattingEnabled = True
        Me.cmbHeadType.IFLDataTag = Nothing
        Me.cmbHeadType.Location = New System.Drawing.Point(94, 36)
        Me.cmbHeadType.Name = "cmbHeadType"
        Me.cmbHeadType.Size = New System.Drawing.Size(98, 21)
        Me.cmbHeadType.StatusMessage = Nothing
        Me.cmbHeadType.StatusObject = Nothing
        Me.cmbHeadType.TabIndex = 1
        '
        'lblRodSeal
        '
        Me.lblRodSeal.AutoSize = True
        Me.lblRodSeal.Location = New System.Drawing.Point(279, 39)
        Me.lblRodSeal.Name = "lblRodSeal"
        Me.lblRodSeal.Size = New System.Drawing.Size(51, 13)
        Me.lblRodSeal.TabIndex = 120
        Me.lblRodSeal.Text = "Rod Seal"
        '
        'lblHeadDesignIndex
        '
        Me.lblHeadDesignIndex.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblHeadDesignIndex.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeadDesignIndex.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHeadDesignIndex.GradientColorOne = System.Drawing.Color.Olive
        Me.lblHeadDesignIndex.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblHeadDesignIndex.Location = New System.Drawing.Point(-2, 0)
        Me.lblHeadDesignIndex.Name = "lblHeadDesignIndex"
        Me.lblHeadDesignIndex.Size = New System.Drawing.Size(715, 19)
        Me.lblHeadDesignIndex.TabIndex = 21
        Me.lblHeadDesignIndex.Text = "Head Design"
        Me.lblHeadDesignIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHeadType
        '
        Me.lblHeadType.AutoSize = True
        Me.lblHeadType.Location = New System.Drawing.Point(28, 39)
        Me.lblHeadType.Name = "lblHeadType"
        Me.lblHeadType.Size = New System.Drawing.Size(60, 13)
        Me.lblHeadType.TabIndex = 114
        Me.lblHeadType.Text = "Head Type"
        '
        'lblHeadDesign
        '
        Me.lblHeadDesign.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblHeadDesign.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeadDesign.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHeadDesign.GradientColorOne = System.Drawing.Color.DarkGoldenrod
        Me.lblHeadDesign.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblHeadDesign.Location = New System.Drawing.Point(26, 28)
        Me.lblHeadDesign.Name = "lblHeadDesign"
        Me.lblHeadDesign.Size = New System.Drawing.Size(747, 152)
        Me.lblHeadDesign.TabIndex = 45
        Me.lblHeadDesign.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'grbInsertCylinderHeadDetailsIntoDB
        '
        Me.grbInsertCylinderHeadDetailsIntoDB.BackColor = System.Drawing.Color.Ivory
        Me.grbInsertCylinderHeadDetailsIntoDB.Controls.Add(Me.btnHeadDesignContinue)
        Me.grbInsertCylinderHeadDetailsIntoDB.Controls.Add(Me.lblMessage)
        Me.grbInsertCylinderHeadDetailsIntoDB.Controls.Add(Me.lblInsertCylinderHeadDetails)
        Me.grbInsertCylinderHeadDetailsIntoDB.Location = New System.Drawing.Point(48, 213)
        Me.grbInsertCylinderHeadDetailsIntoDB.Name = "grbInsertCylinderHeadDetailsIntoDB"
        Me.grbInsertCylinderHeadDetailsIntoDB.Size = New System.Drawing.Size(700, 85)
        Me.grbInsertCylinderHeadDetailsIntoDB.TabIndex = 155
        Me.grbInsertCylinderHeadDetailsIntoDB.TabStop = False
        '
        'btnHeadDesignContinue
        '
        Me.btnHeadDesignContinue.Location = New System.Drawing.Point(583, 41)
        Me.btnHeadDesignContinue.Name = "btnHeadDesignContinue"
        Me.btnHeadDesignContinue.Size = New System.Drawing.Size(72, 23)
        Me.btnHeadDesignContinue.TabIndex = 155
        Me.btnHeadDesignContinue.Text = "Continue"
        Me.btnHeadDesignContinue.UseVisualStyleBackColor = True
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(255, 46)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(191, 15)
        Me.lblMessage.TabIndex = 153
        Me.lblMessage.Text = "This is an Existing CylinderHead"
        '
        'lblInsertCylinderHeadDetails
        '
        Me.lblInsertCylinderHeadDetails.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblInsertCylinderHeadDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInsertCylinderHeadDetails.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInsertCylinderHeadDetails.GradientColorOne = System.Drawing.Color.Olive
        Me.lblInsertCylinderHeadDetails.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblInsertCylinderHeadDetails.Location = New System.Drawing.Point(-2, 0)
        Me.lblInsertCylinderHeadDetails.Name = "lblInsertCylinderHeadDetails"
        Me.lblInsertCylinderHeadDetails.Size = New System.Drawing.Size(702, 19)
        Me.lblInsertCylinderHeadDetails.TabIndex = 21
        Me.lblInsertCylinderHeadDetails.Text = "Information"
        Me.lblInsertCylinderHeadDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblInsertIntoDb
        '
        Me.lblInsertIntoDb.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblInsertIntoDb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInsertIntoDb.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInsertIntoDb.GradientColorOne = System.Drawing.Color.DarkGoldenrod
        Me.lblInsertIntoDb.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblInsertIntoDb.Location = New System.Drawing.Point(28, 192)
        Me.lblInsertIntoDb.Name = "lblInsertIntoDb"
        Me.lblInsertIntoDb.Size = New System.Drawing.Size(742, 126)
        Me.lblInsertIntoDb.TabIndex = 154
        Me.lblInsertIntoDb.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'temCylinderHeadCode
        '
        Me.temCylinderHeadCode.AcceptEnterKeyAsTab = True
        Me.temCylinderHeadCode.ApplyIFLColor = True
        Me.temCylinderHeadCode.AssociateLabel = Nothing
        Me.temCylinderHeadCode.DecimalValue = 2
        Me.temCylinderHeadCode.IFLDataTag = Nothing
        Me.temCylinderHeadCode.InvalidInputCharacters = ""
        Me.temCylinderHeadCode.IsAllowNegative = False
        Me.temCylinderHeadCode.LengthValue = 5
        Me.temCylinderHeadCode.Location = New System.Drawing.Point(605, 193)
        Me.temCylinderHeadCode.MaximumValue = 1.0E+18
        Me.temCylinderHeadCode.MaxLength = 100
        Me.temCylinderHeadCode.MinimumValue = 0
        Me.temCylinderHeadCode.Name = "temCylinderHeadCode"
        Me.temCylinderHeadCode.Size = New System.Drawing.Size(98, 20)
        Me.temCylinderHeadCode.StatusMessage = ""
        Me.temCylinderHeadCode.StatusObject = Nothing
        Me.temCylinderHeadCode.TabIndex = 133
        Me.temCylinderHeadCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmHeadDesign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1036, 780)
        Me.Controls.Add(Me.grbInsertCylinderHeadDetailsIntoDB)
        Me.Controls.Add(Me.grbHeadDesign)
        Me.Controls.Add(Me.lblHeadDesign)
        Me.Controls.Add(Me.LabelGradient5)
        Me.Controls.Add(Me.LabelGradient4)
        Me.Controls.Add(Me.LabelGradient3)
        Me.Controls.Add(Me.LabelGradient2)
        Me.Controls.Add(Me.lblInsertIntoDb)
        Me.Controls.Add(Me.temCylinderHeadCode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmHeadDesign"
        Me.Text = "frmHeadDesign"
        Me.grbHeadDesign.ResumeLayout(False)
        Me.grbHeadDesign.PerformLayout()
        Me.grbInsertCylinderHeadDetailsIntoDB.ResumeLayout(False)
        Me.grbInsertCylinderHeadDetailsIntoDB.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelGradient5 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient4 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient3 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient2 As LabelGradient.LabelGradient
    Friend WithEvents grbHeadDesign As System.Windows.Forms.GroupBox
    Friend WithEvents cmbRodWiperType As IFLCustomUILayer.IFLComboBox
    Friend WithEvents cmbRodWearRing As IFLCustomUILayer.IFLComboBox
    Friend WithEvents lblRodWiperType As System.Windows.Forms.Label
    Friend WithEvents lblRodWearRing As System.Windows.Forms.Label
    Friend WithEvents cmbRodSeal As IFLCustomUILayer.IFLComboBox
    Friend WithEvents cmbHeadType As IFLCustomUILayer.IFLComboBox
    Friend WithEvents lblRodSeal As System.Windows.Forms.Label
    Friend WithEvents lblHeadDesignIndex As LabelGradient.LabelGradient
    Friend WithEvents lblHeadType As System.Windows.Forms.Label
    Friend WithEvents lblHeadDesign As LabelGradient.LabelGradient
    Friend WithEvents cmbRodWearRingQty As IFLCustomUILayer.IFLComboBox
    Friend WithEvents lblRodWearRingQty As System.Windows.Forms.Label
    Friend WithEvents lblCylinderHeadCode As System.Windows.Forms.Label
    Friend WithEvents txtCylinderHeadCode As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents grbInsertCylinderHeadDetailsIntoDB As System.Windows.Forms.GroupBox
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents lblInsertCylinderHeadDetails As LabelGradient.LabelGradient
    Friend WithEvents lblInsertIntoDb As LabelGradient.LabelGradient
    Friend WithEvents temCylinderHeadCode As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents btnHeadDesignContinue As System.Windows.Forms.Button
    Friend WithEvents txtSealType As System.Windows.Forms.TextBox
End Class
