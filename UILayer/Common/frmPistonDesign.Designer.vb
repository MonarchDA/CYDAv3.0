<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPistonDesign
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
        Me.LabelGradient5 = New LabelGradient.LabelGradient()
        Me.LabelGradient4 = New LabelGradient.LabelGradient()
        Me.LabelGradient3 = New LabelGradient.LabelGradient()
        Me.LabelGradient2 = New LabelGradient.LabelGradient()
        Me.cmbPistonWearRing = New IFLCustomUILayer.IFLComboBox()
        Me.cmbPistonSeal = New IFLCustomUILayer.IFLComboBox()
        Me.lblPistonWearRing = New System.Windows.Forms.Label()
        Me.lblWearRingQty = New System.Windows.Forms.Label()
        Me.lblPistonSeal = New System.Windows.Forms.Label()
        Me.grbPistonDesign = New System.Windows.Forms.GroupBox()
        Me.txtPistonCode = New IFLCustomUILayer.IFLNumericBox()
        Me.lblPistonCode = New System.Windows.Forms.Label()
        Me.cmbWearRingQuantity = New IFLCustomUILayer.IFLComboBox()
        Me.lblPistonDesignIndex = New LabelGradient.LabelGradient()
        Me.lblPistonDesign = New LabelGradient.LabelGradient()
        Me.grbPistonDesign.SuspendLayout()
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
        Me.LabelGradient5.TabIndex = 37
        Me.LabelGradient5.Text = "Piston Design"
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
        Me.LabelGradient4.TabIndex = 36
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
        Me.LabelGradient3.TabIndex = 35
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
        Me.LabelGradient2.TabIndex = 34
        Me.LabelGradient2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmbPistonWearRing
        '
        Me.cmbPistonWearRing.AcceptEnterKeyAsTab = True
        Me.cmbPistonWearRing.AssociateLabel = Nothing
        Me.cmbPistonWearRing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPistonWearRing.FormattingEnabled = True
        Me.cmbPistonWearRing.IFLDataTag = Nothing
        Me.cmbPistonWearRing.Location = New System.Drawing.Point(330, 36)
        Me.cmbPistonWearRing.Name = "cmbPistonWearRing"
        Me.cmbPistonWearRing.Size = New System.Drawing.Size(98, 21)
        Me.cmbPistonWearRing.StatusMessage = Nothing
        Me.cmbPistonWearRing.StatusObject = Nothing
        Me.cmbPistonWearRing.TabIndex = 2
        '
        'cmbPistonSeal
        '
        Me.cmbPistonSeal.AcceptEnterKeyAsTab = True
        Me.cmbPistonSeal.AssociateLabel = Nothing
        Me.cmbPistonSeal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPistonSeal.FormattingEnabled = True
        Me.cmbPistonSeal.IFLDataTag = Nothing
        Me.cmbPistonSeal.Location = New System.Drawing.Point(94, 36)
        Me.cmbPistonSeal.Name = "cmbPistonSeal"
        Me.cmbPistonSeal.Size = New System.Drawing.Size(98, 21)
        Me.cmbPistonSeal.StatusMessage = Nothing
        Me.cmbPistonSeal.StatusObject = Nothing
        Me.cmbPistonSeal.TabIndex = 1
        '
        'lblPistonWearRing
        '
        Me.lblPistonWearRing.AutoSize = True
        Me.lblPistonWearRing.Location = New System.Drawing.Point(234, 39)
        Me.lblPistonWearRing.Name = "lblPistonWearRing"
        Me.lblPistonWearRing.Size = New System.Drawing.Size(90, 13)
        Me.lblPistonWearRing.TabIndex = 120
        Me.lblPistonWearRing.Text = "Piston Wear Ring"
        '
        'lblWearRingQty
        '
        Me.lblWearRingQty.AutoSize = True
        Me.lblWearRingQty.Location = New System.Drawing.Point(466, 39)
        Me.lblWearRingQty.Name = "lblWearRingQty"
        Me.lblWearRingQty.Size = New System.Drawing.Size(100, 13)
        Me.lblWearRingQty.TabIndex = 116
        Me.lblWearRingQty.Text = "Wear Ring Quantity"
        '
        'lblPistonSeal
        '
        Me.lblPistonSeal.AutoSize = True
        Me.lblPistonSeal.Location = New System.Drawing.Point(24, 39)
        Me.lblPistonSeal.Name = "lblPistonSeal"
        Me.lblPistonSeal.Size = New System.Drawing.Size(60, 13)
        Me.lblPistonSeal.TabIndex = 114
        Me.lblPistonSeal.Text = "Piston Seal"
        '
        'grbPistonDesign
        '
        Me.grbPistonDesign.BackColor = System.Drawing.Color.Ivory
        Me.grbPistonDesign.Controls.Add(Me.txtPistonCode)
        Me.grbPistonDesign.Controls.Add(Me.lblPistonCode)
        Me.grbPistonDesign.Controls.Add(Me.cmbWearRingQuantity)
        Me.grbPistonDesign.Controls.Add(Me.lblWearRingQty)
        Me.grbPistonDesign.Controls.Add(Me.cmbPistonWearRing)
        Me.grbPistonDesign.Controls.Add(Me.lblPistonWearRing)
        Me.grbPistonDesign.Controls.Add(Me.cmbPistonSeal)
        Me.grbPistonDesign.Controls.Add(Me.lblPistonSeal)
        Me.grbPistonDesign.Controls.Add(Me.lblPistonDesignIndex)
        Me.grbPistonDesign.Location = New System.Drawing.Point(47, 48)
        Me.grbPistonDesign.Name = "grbPistonDesign"
        Me.grbPistonDesign.Size = New System.Drawing.Size(701, 120)
        Me.grbPistonDesign.TabIndex = 0
        Me.grbPistonDesign.TabStop = False
        '
        'txtPistonCode
        '
        Me.txtPistonCode.AcceptEnterKeyAsTab = True
        Me.txtPistonCode.ApplyIFLColor = True
        Me.txtPistonCode.AssociateLabel = Nothing
        Me.txtPistonCode.DecimalValue = 2
        Me.txtPistonCode.IFLDataTag = Nothing
        Me.txtPistonCode.InvalidInputCharacters = ""
        Me.txtPistonCode.IsAllowNegative = False
        Me.txtPistonCode.LengthValue = 5
        Me.txtPistonCode.Location = New System.Drawing.Point(94, 80)
        Me.txtPistonCode.MaximumValue = 1000000.0R
        Me.txtPistonCode.MaxLength = 10
        Me.txtPistonCode.MinimumValue = 6.0R
        Me.txtPistonCode.Name = "txtPistonCode"
        Me.txtPistonCode.Size = New System.Drawing.Size(98, 20)
        Me.txtPistonCode.StatusMessage = ""
        Me.txtPistonCode.StatusObject = Nothing
        Me.txtPistonCode.TabIndex = 4
        Me.txtPistonCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPistonCode
        '
        Me.lblPistonCode.AutoSize = True
        Me.lblPistonCode.Location = New System.Drawing.Point(24, 83)
        Me.lblPistonCode.Name = "lblPistonCode"
        Me.lblPistonCode.Size = New System.Drawing.Size(64, 13)
        Me.lblPistonCode.TabIndex = 152
        Me.lblPistonCode.Text = "Piston Code"
        '
        'cmbWearRingQuantity
        '
        Me.cmbWearRingQuantity.AcceptEnterKeyAsTab = True
        Me.cmbWearRingQuantity.AssociateLabel = Nothing
        Me.cmbWearRingQuantity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWearRingQuantity.FormattingEnabled = True
        Me.cmbWearRingQuantity.IFLDataTag = Nothing
        Me.cmbWearRingQuantity.Location = New System.Drawing.Point(572, 36)
        Me.cmbWearRingQuantity.Name = "cmbWearRingQuantity"
        Me.cmbWearRingQuantity.Size = New System.Drawing.Size(98, 21)
        Me.cmbWearRingQuantity.StatusMessage = Nothing
        Me.cmbWearRingQuantity.StatusObject = Nothing
        Me.cmbWearRingQuantity.TabIndex = 3
        '
        'lblPistonDesignIndex
        '
        Me.lblPistonDesignIndex.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblPistonDesignIndex.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPistonDesignIndex.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPistonDesignIndex.GradientColorOne = System.Drawing.Color.Olive
        Me.lblPistonDesignIndex.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblPistonDesignIndex.Location = New System.Drawing.Point(-2, 0)
        Me.lblPistonDesignIndex.Name = "lblPistonDesignIndex"
        Me.lblPistonDesignIndex.Size = New System.Drawing.Size(703, 19)
        Me.lblPistonDesignIndex.TabIndex = 21
        Me.lblPistonDesignIndex.Text = "Piston Design"
        Me.lblPistonDesignIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPistonDesign
        '
        Me.lblPistonDesign.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblPistonDesign.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPistonDesign.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPistonDesign.GradientColorOne = System.Drawing.Color.DarkGoldenrod
        Me.lblPistonDesign.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblPistonDesign.Location = New System.Drawing.Point(26, 28)
        Me.lblPistonDesign.Name = "lblPistonDesign"
        Me.lblPistonDesign.Size = New System.Drawing.Size(745, 158)
        Me.lblPistonDesign.TabIndex = 39
        Me.lblPistonDesign.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmPistonDesign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1036, 780)
        Me.Controls.Add(Me.grbPistonDesign)
        Me.Controls.Add(Me.lblPistonDesign)
        Me.Controls.Add(Me.LabelGradient5)
        Me.Controls.Add(Me.LabelGradient4)
        Me.Controls.Add(Me.LabelGradient3)
        Me.Controls.Add(Me.LabelGradient2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPistonDesign"
        Me.Text = "frmPistonDesign"
        Me.grbPistonDesign.ResumeLayout(False)
        Me.grbPistonDesign.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelGradient5 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient4 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient3 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient2 As LabelGradient.LabelGradient
    Friend WithEvents lblPistonWearRing As System.Windows.Forms.Label
    Friend WithEvents lblWearRingQty As System.Windows.Forms.Label
    Friend WithEvents lblPistonSeal As System.Windows.Forms.Label
    Friend WithEvents grbPistonDesign As System.Windows.Forms.GroupBox
    Friend WithEvents lblPistonDesignIndex As LabelGradient.LabelGradient
    Friend WithEvents lblPistonDesign As LabelGradient.LabelGradient
    Friend WithEvents cmbPistonWearRing As IFLCustomUILayer.IFLComboBox
    Friend WithEvents cmbPistonSeal As IFLCustomUILayer.IFLComboBox
    Friend WithEvents cmbWearRingQuantity As IFLCustomUILayer.IFLComboBox
    Friend WithEvents lblPistonCode As System.Windows.Forms.Label
    Friend WithEvents txtPistonCode As IFLCustomUILayer.IFLNumericBox
End Class
