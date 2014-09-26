<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDesignABasePlug
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
        Me.txtWeight = New IFLCustomUILayer.IFLNumericBox
        Me.txtMilledFlatHeight = New IFLCustomUILayer.IFLNumericBox
        Me.txtSwingClearance = New IFLCustomUILayer.IFLNumericBox
        Me.txtMilledFlatWidth = New IFLCustomUILayer.IFLNumericBox
        Me.txtPinHoleSize = New IFLCustomUILayer.IFLNumericBox
        Me.txtOutsidePlugDia = New IFLCustomUILayer.IFLNumericBox
        Me.lblWeight = New System.Windows.Forms.Label
        Me.lblMilledFlatHeight = New System.Windows.Forms.Label
        Me.lblMilledFlatWidth = New System.Windows.Forms.Label
        Me.lblDesignNewBasePlug = New LabelGradient.LabelGradient
        Me.btnAccept = New System.Windows.Forms.Button
        Me.lblSwingClearance2 = New System.Windows.Forms.Label
        Me.lblPinHoleSize = New System.Windows.Forms.Label
        Me.lblOutsidePlugDia = New System.Windows.Forms.Label
        Me.lblBackGround = New LabelGradient.LabelGradient
        Me.pnlDesignaCasting.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlDesignaCasting
        '
        Me.pnlDesignaCasting.BackColor = System.Drawing.Color.Ivory
        Me.pnlDesignaCasting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDesignaCasting.Controls.Add(Me.txtWeight)
        Me.pnlDesignaCasting.Controls.Add(Me.txtMilledFlatHeight)
        Me.pnlDesignaCasting.Controls.Add(Me.txtSwingClearance)
        Me.pnlDesignaCasting.Controls.Add(Me.txtMilledFlatWidth)
        Me.pnlDesignaCasting.Controls.Add(Me.txtPinHoleSize)
        Me.pnlDesignaCasting.Controls.Add(Me.txtOutsidePlugDia)
        Me.pnlDesignaCasting.Controls.Add(Me.lblWeight)
        Me.pnlDesignaCasting.Controls.Add(Me.lblMilledFlatHeight)
        Me.pnlDesignaCasting.Controls.Add(Me.lblMilledFlatWidth)
        Me.pnlDesignaCasting.Controls.Add(Me.lblDesignNewBasePlug)
        Me.pnlDesignaCasting.Controls.Add(Me.btnAccept)
        Me.pnlDesignaCasting.Controls.Add(Me.lblSwingClearance2)
        Me.pnlDesignaCasting.Controls.Add(Me.lblPinHoleSize)
        Me.pnlDesignaCasting.Controls.Add(Me.lblOutsidePlugDia)
        Me.pnlDesignaCasting.Location = New System.Drawing.Point(33, 29)
        Me.pnlDesignaCasting.Name = "pnlDesignaCasting"
        Me.pnlDesignaCasting.Size = New System.Drawing.Size(445, 365)
        Me.pnlDesignaCasting.TabIndex = 3
        '
        'txtWeight
        '
        Me.txtWeight.AcceptEnterKeyAsTab = True
        Me.txtWeight.ApplyIFLColor = True
        Me.txtWeight.AssociateLabel = Nothing
        Me.txtWeight.DecimalValue = 2
        Me.txtWeight.IFLDataTag = Nothing
        Me.txtWeight.InvalidInputCharacters = ""
        Me.txtWeight.IsAllowNegative = False
        Me.txtWeight.LengthValue = 6
        Me.txtWeight.Location = New System.Drawing.Point(253, 239)
        Me.txtWeight.MaximumValue = 99999
        Me.txtWeight.MaxLength = 6
        Me.txtWeight.MinimumValue = 0
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(66, 20)
        Me.txtWeight.StatusMessage = ""
        Me.txtWeight.StatusObject = Nothing
        Me.txtWeight.TabIndex = 165
        Me.txtWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMilledFlatHeight
        '
        Me.txtMilledFlatHeight.AcceptEnterKeyAsTab = True
        Me.txtMilledFlatHeight.ApplyIFLColor = True
        Me.txtMilledFlatHeight.AssociateLabel = Nothing
        Me.txtMilledFlatHeight.DecimalValue = 2
        Me.txtMilledFlatHeight.IFLDataTag = Nothing
        Me.txtMilledFlatHeight.InvalidInputCharacters = ""
        Me.txtMilledFlatHeight.IsAllowNegative = False
        Me.txtMilledFlatHeight.LengthValue = 6
        Me.txtMilledFlatHeight.Location = New System.Drawing.Point(253, 129)
        Me.txtMilledFlatHeight.MaximumValue = 99999
        Me.txtMilledFlatHeight.MaxLength = 6
        Me.txtMilledFlatHeight.MinimumValue = 0
        Me.txtMilledFlatHeight.Name = "txtMilledFlatHeight"
        Me.txtMilledFlatHeight.Size = New System.Drawing.Size(66, 20)
        Me.txtMilledFlatHeight.StatusMessage = ""
        Me.txtMilledFlatHeight.StatusObject = Nothing
        Me.txtMilledFlatHeight.TabIndex = 164
        Me.txtMilledFlatHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.txtSwingClearance.Location = New System.Drawing.Point(253, 202)
        Me.txtSwingClearance.MaximumValue = 99999
        Me.txtSwingClearance.MaxLength = 6
        Me.txtSwingClearance.MinimumValue = 0
        Me.txtSwingClearance.Name = "txtSwingClearance"
        Me.txtSwingClearance.Size = New System.Drawing.Size(66, 20)
        Me.txtSwingClearance.StatusMessage = ""
        Me.txtSwingClearance.StatusObject = Nothing
        Me.txtSwingClearance.TabIndex = 163
        Me.txtSwingClearance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMilledFlatWidth
        '
        Me.txtMilledFlatWidth.AcceptEnterKeyAsTab = True
        Me.txtMilledFlatWidth.ApplyIFLColor = True
        Me.txtMilledFlatWidth.AssociateLabel = Nothing
        Me.txtMilledFlatWidth.DecimalValue = 2
        Me.txtMilledFlatWidth.IFLDataTag = Nothing
        Me.txtMilledFlatWidth.InvalidInputCharacters = ""
        Me.txtMilledFlatWidth.IsAllowNegative = False
        Me.txtMilledFlatWidth.LengthValue = 6
        Me.txtMilledFlatWidth.Location = New System.Drawing.Point(253, 93)
        Me.txtMilledFlatWidth.MaximumValue = 99999
        Me.txtMilledFlatWidth.MaxLength = 6
        Me.txtMilledFlatWidth.MinimumValue = 0
        Me.txtMilledFlatWidth.Name = "txtMilledFlatWidth"
        Me.txtMilledFlatWidth.Size = New System.Drawing.Size(66, 20)
        Me.txtMilledFlatWidth.StatusMessage = ""
        Me.txtMilledFlatWidth.StatusObject = Nothing
        Me.txtMilledFlatWidth.TabIndex = 162
        Me.txtMilledFlatWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPinHoleSize
        '
        Me.txtPinHoleSize.AcceptEnterKeyAsTab = True
        Me.txtPinHoleSize.ApplyIFLColor = True
        Me.txtPinHoleSize.AssociateLabel = Nothing
        Me.txtPinHoleSize.DecimalValue = 2
        Me.txtPinHoleSize.IFLDataTag = Nothing
        Me.txtPinHoleSize.InvalidInputCharacters = ""
        Me.txtPinHoleSize.IsAllowNegative = False
        Me.txtPinHoleSize.LengthValue = 6
        Me.txtPinHoleSize.Location = New System.Drawing.Point(253, 169)
        Me.txtPinHoleSize.MaximumValue = 99999
        Me.txtPinHoleSize.MaxLength = 6
        Me.txtPinHoleSize.MinimumValue = 0
        Me.txtPinHoleSize.Name = "txtPinHoleSize"
        Me.txtPinHoleSize.Size = New System.Drawing.Size(66, 20)
        Me.txtPinHoleSize.StatusMessage = ""
        Me.txtPinHoleSize.StatusObject = Nothing
        Me.txtPinHoleSize.TabIndex = 161
        Me.txtPinHoleSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOutsidePlugDia
        '
        Me.txtOutsidePlugDia.AcceptEnterKeyAsTab = True
        Me.txtOutsidePlugDia.ApplyIFLColor = True
        Me.txtOutsidePlugDia.AssociateLabel = Nothing
        Me.txtOutsidePlugDia.DecimalValue = 2
        Me.txtOutsidePlugDia.IFLDataTag = Nothing
        Me.txtOutsidePlugDia.InvalidInputCharacters = ""
        Me.txtOutsidePlugDia.IsAllowNegative = False
        Me.txtOutsidePlugDia.LengthValue = 6
        Me.txtOutsidePlugDia.Location = New System.Drawing.Point(253, 57)
        Me.txtOutsidePlugDia.MaximumValue = 99999
        Me.txtOutsidePlugDia.MaxLength = 6
        Me.txtOutsidePlugDia.MinimumValue = 0
        Me.txtOutsidePlugDia.Name = "txtOutsidePlugDia"
        Me.txtOutsidePlugDia.Size = New System.Drawing.Size(66, 20)
        Me.txtOutsidePlugDia.StatusMessage = ""
        Me.txtOutsidePlugDia.StatusObject = Nothing
        Me.txtOutsidePlugDia.TabIndex = 160
        Me.txtOutsidePlugDia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblWeight
        '
        Me.lblWeight.AutoSize = True
        Me.lblWeight.Location = New System.Drawing.Point(121, 243)
        Me.lblWeight.Name = "lblWeight"
        Me.lblWeight.Size = New System.Drawing.Size(41, 13)
        Me.lblWeight.TabIndex = 158
        Me.lblWeight.Text = "Weight"
        '
        'lblMilledFlatHeight
        '
        Me.lblMilledFlatHeight.AutoSize = True
        Me.lblMilledFlatHeight.Location = New System.Drawing.Point(121, 133)
        Me.lblMilledFlatHeight.Name = "lblMilledFlatHeight"
        Me.lblMilledFlatHeight.Size = New System.Drawing.Size(88, 13)
        Me.lblMilledFlatHeight.TabIndex = 143
        Me.lblMilledFlatHeight.Text = "Milled Flat Height"
        '
        'lblMilledFlatWidth
        '
        Me.lblMilledFlatWidth.AutoSize = True
        Me.lblMilledFlatWidth.Location = New System.Drawing.Point(121, 97)
        Me.lblMilledFlatWidth.Name = "lblMilledFlatWidth"
        Me.lblMilledFlatWidth.Size = New System.Drawing.Size(85, 13)
        Me.lblMilledFlatWidth.TabIndex = 155
        Me.lblMilledFlatWidth.Text = "Milled Flat Width"
        '
        'lblDesignNewBasePlug
        '
        Me.lblDesignNewBasePlug.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblDesignNewBasePlug.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDesignNewBasePlug.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesignNewBasePlug.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDesignNewBasePlug.GradientColorOne = System.Drawing.Color.Olive
        Me.lblDesignNewBasePlug.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblDesignNewBasePlug.Location = New System.Drawing.Point(0, 0)
        Me.lblDesignNewBasePlug.Name = "lblDesignNewBasePlug"
        Me.lblDesignNewBasePlug.Size = New System.Drawing.Size(441, 19)
        Me.lblDesignNewBasePlug.TabIndex = 141
        Me.lblDesignNewBasePlug.Text = "Design New Base Plug"
        Me.lblDesignNewBasePlug.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAccept
        '
        Me.btnAccept.Location = New System.Drawing.Point(183, 302)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(75, 23)
        Me.btnAccept.TabIndex = 151
        Me.btnAccept.Text = "Accept"
        Me.btnAccept.UseVisualStyleBackColor = True
        '
        'lblSwingClearance2
        '
        Me.lblSwingClearance2.AutoSize = True
        Me.lblSwingClearance2.Location = New System.Drawing.Point(121, 206)
        Me.lblSwingClearance2.Name = "lblSwingClearance2"
        Me.lblSwingClearance2.Size = New System.Drawing.Size(87, 13)
        Me.lblSwingClearance2.TabIndex = 149
        Me.lblSwingClearance2.Text = "Swing Clearance"
        '
        'lblPinHoleSize
        '
        Me.lblPinHoleSize.AutoSize = True
        Me.lblPinHoleSize.Location = New System.Drawing.Point(121, 173)
        Me.lblPinHoleSize.Name = "lblPinHoleSize"
        Me.lblPinHoleSize.Size = New System.Drawing.Size(70, 13)
        Me.lblPinHoleSize.TabIndex = 147
        Me.lblPinHoleSize.Text = "Pin Hole Size"
        '
        'lblOutsidePlugDia
        '
        Me.lblOutsidePlugDia.AutoSize = True
        Me.lblOutsidePlugDia.Location = New System.Drawing.Point(121, 61)
        Me.lblOutsidePlugDia.Name = "lblOutsidePlugDia"
        Me.lblOutsidePlugDia.Size = New System.Drawing.Size(86, 13)
        Me.lblOutsidePlugDia.TabIndex = 145
        Me.lblOutsidePlugDia.Text = "Outside Plug Dia"
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
        Me.lblBackGround.Size = New System.Drawing.Size(489, 405)
        Me.lblBackGround.TabIndex = 120
        Me.lblBackGround.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmDesignABasePlug
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(900, 650)
        Me.Controls.Add(Me.pnlDesignaCasting)
        Me.Controls.Add(Me.lblBackGround)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDesignABasePlug"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "frmDesignABasePlug"
        Me.pnlDesignaCasting.ResumeLayout(False)
        Me.pnlDesignaCasting.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlDesignaCasting As System.Windows.Forms.Panel
    Friend WithEvents lblWeight As System.Windows.Forms.Label
    Friend WithEvents lblMilledFlatHeight As System.Windows.Forms.Label
    Friend WithEvents lblMilledFlatWidth As System.Windows.Forms.Label
    Friend WithEvents lblDesignNewBasePlug As LabelGradient.LabelGradient
    Friend WithEvents btnAccept As System.Windows.Forms.Button
    Friend WithEvents lblSwingClearance2 As System.Windows.Forms.Label
    Friend WithEvents lblPinHoleSize As System.Windows.Forms.Label
    Friend WithEvents lblOutsidePlugDia As System.Windows.Forms.Label
    Friend WithEvents lblBackGround As LabelGradient.LabelGradient
    Friend WithEvents txtOutsidePlugDia As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtPinHoleSize As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtMilledFlatWidth As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtSwingClearance As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtMilledFlatHeight As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtWeight As IFLCustomUILayer.IFLNumericBox
End Class
