<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFlatWithChamfer
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
        Me.LabelGradient4 = New LabelGradient.LabelGradient
        Me.LabelGradient3 = New LabelGradient.LabelGradient
        Me.LabelGradient2 = New LabelGradient.LabelGradient
        Me.lblSLHeading = New LabelGradient.LabelGradient
        Me.lblBackGround = New LabelGradient.LabelGradient
        Me.pnlFlatWithChamper = New System.Windows.Forms.Panel
        Me.lblChamferSize = New System.Windows.Forms.Label
        Me.lblChamferAngle = New System.Windows.Forms.Label
        Me.txtChamferSize = New IFLCustomUILayer.IFLNumericBox
        Me.txtChamferAngle = New IFLCustomUILayer.IFLNumericBox
        Me.lblFlatWithChamferInsidePanel = New LabelGradient.LabelGradient
        Me.pnlFlatWithChamper.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelGradient4
        '
        Me.LabelGradient4.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient4.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelGradient4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient4.GradientColorOne = System.Drawing.Color.Olive
        Me.LabelGradient4.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient4.Location = New System.Drawing.Point(1178, 0)
        Me.LabelGradient4.Name = "LabelGradient4"
        Me.LabelGradient4.Size = New System.Drawing.Size(22, 900)
        Me.LabelGradient4.TabIndex = 43
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
        Me.LabelGradient3.Size = New System.Drawing.Size(20, 881)
        Me.LabelGradient3.TabIndex = 45
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
        Me.LabelGradient2.Location = New System.Drawing.Point(0, 881)
        Me.LabelGradient2.Name = "LabelGradient2"
        Me.LabelGradient2.Size = New System.Drawing.Size(1178, 19)
        Me.LabelGradient2.TabIndex = 44
        Me.LabelGradient2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSLHeading
        '
        Me.lblSLHeading.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblSLHeading.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSLHeading.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSLHeading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSLHeading.GradientColorOne = System.Drawing.Color.Olive
        Me.lblSLHeading.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblSLHeading.Location = New System.Drawing.Point(20, 0)
        Me.lblSLHeading.Name = "lblSLHeading"
        Me.lblSLHeading.Size = New System.Drawing.Size(1158, 19)
        Me.lblSLHeading.TabIndex = 46
        Me.lblSLHeading.Text = "Flat With Chamfer"
        Me.lblSLHeading.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblBackGround
        '
        Me.lblBackGround.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblBackGround.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBackGround.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBackGround.GradientColorOne = System.Drawing.Color.DarkGoldenrod
        Me.lblBackGround.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblBackGround.Location = New System.Drawing.Point(26, 28)
        Me.lblBackGround.Name = "lblBackGround"
        Me.lblBackGround.Size = New System.Drawing.Size(361, 236)
        Me.lblBackGround.TabIndex = 121
        Me.lblBackGround.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlFlatWithChamper
        '
        Me.pnlFlatWithChamper.BackColor = System.Drawing.Color.Ivory
        Me.pnlFlatWithChamper.Controls.Add(Me.lblChamferSize)
        Me.pnlFlatWithChamper.Controls.Add(Me.lblChamferAngle)
        Me.pnlFlatWithChamper.Controls.Add(Me.txtChamferSize)
        Me.pnlFlatWithChamper.Controls.Add(Me.txtChamferAngle)
        Me.pnlFlatWithChamper.Controls.Add(Me.lblFlatWithChamferInsidePanel)
        Me.pnlFlatWithChamper.Location = New System.Drawing.Point(46, 48)
        Me.pnlFlatWithChamper.Name = "pnlFlatWithChamper"
        Me.pnlFlatWithChamper.Size = New System.Drawing.Size(320, 196)
        Me.pnlFlatWithChamper.TabIndex = 122
        '
        'lblChamferSize
        '
        Me.lblChamferSize.AutoSize = True
        Me.lblChamferSize.Location = New System.Drawing.Point(65, 112)
        Me.lblChamferSize.Name = "lblChamferSize"
        Me.lblChamferSize.Size = New System.Drawing.Size(69, 13)
        Me.lblChamferSize.TabIndex = 117
        Me.lblChamferSize.Text = "Chamfer Size"
        '
        'lblChamferAngle
        '
        Me.lblChamferAngle.AutoSize = True
        Me.lblChamferAngle.Location = New System.Drawing.Point(65, 71)
        Me.lblChamferAngle.Name = "lblChamferAngle"
        Me.lblChamferAngle.Size = New System.Drawing.Size(76, 13)
        Me.lblChamferAngle.TabIndex = 115
        Me.lblChamferAngle.Text = "Chamfer Angle"
        '
        'txtChamferSize
        '
        Me.txtChamferSize.AcceptEnterKeyAsTab = True
        Me.txtChamferSize.ApplyIFLColor = True
        Me.txtChamferSize.AssociateLabel = Nothing
        Me.txtChamferSize.DecimalValue = 3
        Me.txtChamferSize.IFLDataTag = Nothing
        Me.txtChamferSize.InvalidInputCharacters = ""
        Me.txtChamferSize.IsAllowNegative = False
        Me.txtChamferSize.LengthValue = 6
        Me.txtChamferSize.Location = New System.Drawing.Point(156, 109)
        Me.txtChamferSize.MaximumValue = 100
        Me.txtChamferSize.MinimumValue = 0
        Me.txtChamferSize.Name = "txtChamferSize"
        Me.txtChamferSize.Size = New System.Drawing.Size(100, 20)
        Me.txtChamferSize.StatusMessage = Nothing
        Me.txtChamferSize.StatusObject = Nothing
        Me.txtChamferSize.TabIndex = 114
        Me.txtChamferSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtChamferAngle
        '
        Me.txtChamferAngle.AcceptEnterKeyAsTab = True
        Me.txtChamferAngle.ApplyIFLColor = True
        Me.txtChamferAngle.AssociateLabel = Nothing
        Me.txtChamferAngle.DecimalValue = 0
        Me.txtChamferAngle.IFLDataTag = Nothing
        Me.txtChamferAngle.InvalidInputCharacters = ""
        Me.txtChamferAngle.IsAllowNegative = False
        Me.txtChamferAngle.LengthValue = 10
        Me.txtChamferAngle.Location = New System.Drawing.Point(156, 68)
        Me.txtChamferAngle.MaximumValue = 99999999999999
        Me.txtChamferAngle.MinimumValue = 0
        Me.txtChamferAngle.Name = "txtChamferAngle"
        Me.txtChamferAngle.Size = New System.Drawing.Size(100, 20)
        Me.txtChamferAngle.StatusMessage = Nothing
        Me.txtChamferAngle.StatusObject = Nothing
        Me.txtChamferAngle.TabIndex = 112
        Me.txtChamferAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFlatWithChamferInsidePanel
        '
        Me.lblFlatWithChamferInsidePanel.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblFlatWithChamferInsidePanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlatWithChamferInsidePanel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFlatWithChamferInsidePanel.GradientColorOne = System.Drawing.Color.Olive
        Me.lblFlatWithChamferInsidePanel.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblFlatWithChamferInsidePanel.Location = New System.Drawing.Point(0, 0)
        Me.lblFlatWithChamferInsidePanel.Name = "lblFlatWithChamferInsidePanel"
        Me.lblFlatWithChamferInsidePanel.Size = New System.Drawing.Size(320, 24)
        Me.lblFlatWithChamferInsidePanel.TabIndex = 111
        Me.lblFlatWithChamferInsidePanel.Text = "Flat With Chamfer "
        Me.lblFlatWithChamferInsidePanel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmFlatWithChamfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1200, 900)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlFlatWithChamper)
        Me.Controls.Add(Me.lblBackGround)
        Me.Controls.Add(Me.lblSLHeading)
        Me.Controls.Add(Me.LabelGradient3)
        Me.Controls.Add(Me.LabelGradient2)
        Me.Controls.Add(Me.LabelGradient4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmFlatWithChamfer"
        Me.Text = "FlatWithChamfer"
        Me.pnlFlatWithChamper.ResumeLayout(False)
        Me.pnlFlatWithChamper.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelGradient4 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient3 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient2 As LabelGradient.LabelGradient
    Friend WithEvents lblSLHeading As LabelGradient.LabelGradient
    Friend WithEvents lblBackGround As LabelGradient.LabelGradient
    Friend WithEvents pnlFlatWithChamper As System.Windows.Forms.Panel
    Friend WithEvents lblFlatWithChamferInsidePanel As LabelGradient.LabelGradient
    Friend WithEvents lblChamferSize As System.Windows.Forms.Label
    Friend WithEvents lblChamferAngle As System.Windows.Forms.Label
    Friend WithEvents txtChamferSize As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtChamferAngle As IFLCustomUILayer.IFLNumericBox
End Class
