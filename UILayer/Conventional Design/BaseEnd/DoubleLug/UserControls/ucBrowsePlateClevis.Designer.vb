<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucBrowsePlateClevis
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.btnBrowse = New System.Windows.Forms.Button
        Me.lblBrowseULug = New LabelGradient.LabelGradient
        Me.ofdULugBrowse = New System.Windows.Forms.OpenFileDialog
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtClevisPlateThickness = New IFLCustomUILayer.IFLNumericBox
        Me.txtClevisPlateRodStopDistance = New IFLCustomUILayer.IFLNumericBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtClevisPlateOD = New IFLCustomUILayer.IFLTextBox
        Me.lblClevisPlateOD = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtPath
        '
        Me.txtPath.Enabled = False
        Me.txtPath.Location = New System.Drawing.Point(97, 46)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(419, 20)
        Me.txtPath.TabIndex = 25
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(16, 44)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 24
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'lblBrowseULug
        '
        Me.lblBrowseULug.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblBrowseULug.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblBrowseULug.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrowseULug.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBrowseULug.GradientColorOne = System.Drawing.Color.Olive
        Me.lblBrowseULug.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblBrowseULug.Location = New System.Drawing.Point(0, 0)
        Me.lblBrowseULug.Name = "lblBrowseULug"
        Me.lblBrowseULug.Size = New System.Drawing.Size(525, 15)
        Me.lblBrowseULug.TabIndex = 26
        Me.lblBrowseULug.Text = "Import Plate Clevis"
        Me.lblBrowseULug.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ofdULugBrowse
        '
        Me.ofdULugBrowse.FileName = "OpenFileDialog1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Clevis Plate thickness"
        '
        'txtClevisPlateThickness
        '
        Me.txtClevisPlateThickness.AcceptEnterKeyAsTab = True
        Me.txtClevisPlateThickness.ApplyIFLColor = True
        Me.txtClevisPlateThickness.AssociateLabel = Nothing
        Me.txtClevisPlateThickness.DecimalValue = 3
        Me.txtClevisPlateThickness.IFLDataTag = Nothing
        Me.txtClevisPlateThickness.InvalidInputCharacters = ""
        Me.txtClevisPlateThickness.IsAllowNegative = False
        Me.txtClevisPlateThickness.LengthValue = 10
        Me.txtClevisPlateThickness.Location = New System.Drawing.Point(111, 21)
        Me.txtClevisPlateThickness.MaximumValue = 9999999
        Me.txtClevisPlateThickness.MinimumValue = 0
        Me.txtClevisPlateThickness.Name = "txtClevisPlateThickness"
        Me.txtClevisPlateThickness.Size = New System.Drawing.Size(45, 20)
        Me.txtClevisPlateThickness.StatusMessage = Nothing
        Me.txtClevisPlateThickness.StatusObject = Nothing
        Me.txtClevisPlateThickness.TabIndex = 28
        Me.txtClevisPlateThickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtClevisPlateRodStopDistance
        '
        Me.txtClevisPlateRodStopDistance.AcceptEnterKeyAsTab = True
        Me.txtClevisPlateRodStopDistance.ApplyIFLColor = True
        Me.txtClevisPlateRodStopDistance.AssociateLabel = Nothing
        Me.txtClevisPlateRodStopDistance.DecimalValue = 3
        Me.txtClevisPlateRodStopDistance.IFLDataTag = Nothing
        Me.txtClevisPlateRodStopDistance.InvalidInputCharacters = ""
        Me.txtClevisPlateRodStopDistance.IsAllowNegative = False
        Me.txtClevisPlateRodStopDistance.LengthValue = 10
        Me.txtClevisPlateRodStopDistance.Location = New System.Drawing.Point(305, 21)
        Me.txtClevisPlateRodStopDistance.MaximumValue = 99999
        Me.txtClevisPlateRodStopDistance.MinimumValue = 0
        Me.txtClevisPlateRodStopDistance.Name = "txtClevisPlateRodStopDistance"
        Me.txtClevisPlateRodStopDistance.Size = New System.Drawing.Size(57, 20)
        Me.txtClevisPlateRodStopDistance.StatusMessage = Nothing
        Me.txtClevisPlateRodStopDistance.StatusObject = Nothing
        Me.txtClevisPlateRodStopDistance.TabIndex = 30
        Me.txtClevisPlateRodStopDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(162, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Clevis Plate rod stop distance"
        '
        'txtClevisPlateOD
        '
        Me.txtClevisPlateOD.AcceptEnterKeyAsTab = True
        Me.txtClevisPlateOD.ApplyIFLColor = True
        Me.txtClevisPlateOD.AssociateLabel = Nothing
        Me.txtClevisPlateOD.IFLDataTag = Nothing
        Me.txtClevisPlateOD.InvalidInputCharacters = ""
        Me.txtClevisPlateOD.Location = New System.Drawing.Point(461, 22)
        Me.txtClevisPlateOD.MaxLength = 32
        Me.txtClevisPlateOD.Name = "txtClevisPlateOD"
        Me.txtClevisPlateOD.Size = New System.Drawing.Size(55, 20)
        Me.txtClevisPlateOD.StatusMessage = ""
        Me.txtClevisPlateOD.StatusObject = Nothing
        Me.txtClevisPlateOD.TabIndex = 31
        '
        'lblClevisPlateOD
        '
        Me.lblClevisPlateOD.AutoSize = True
        Me.lblClevisPlateOD.Font = New System.Drawing.Font("Lucida Sans Unicode", 8.25!)
        Me.lblClevisPlateOD.Location = New System.Drawing.Point(368, 24)
        Me.lblClevisPlateOD.Name = "lblClevisPlateOD"
        Me.lblClevisPlateOD.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblClevisPlateOD.Size = New System.Drawing.Size(87, 15)
        Me.lblClevisPlateOD.TabIndex = 32
        Me.lblClevisPlateOD.Text = "Clevis Plate OD"
        '
        'ucBrowsePlateClevis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Ivory
        Me.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Controls.Add(Me.txtClevisPlateOD)
        Me.Controls.Add(Me.lblClevisPlateOD)
        Me.Controls.Add(Me.txtClevisPlateRodStopDistance)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtClevisPlateThickness)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.lblBrowseULug)
        Me.Name = "ucBrowsePlateClevis"
        Me.Size = New System.Drawing.Size(525, 69)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents lblBrowseULug As LabelGradient.LabelGradient
    Friend WithEvents ofdULugBrowse As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtClevisPlateThickness As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtClevisPlateRodStopDistance As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtClevisPlateOD As IFLCustomUILayer.IFLTextBox
    Friend WithEvents lblClevisPlateOD As System.Windows.Forms.Label

End Class
