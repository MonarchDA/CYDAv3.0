<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRetractedLengthValidation
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
        Me.pnlRetractedLength = New System.Windows.Forms.Panel
        Me.txtCounterBoreClevisPlate = New System.Windows.Forms.TextBox
        Me.chkCounterBoreClevisPlate = New IFLCustomUILayer.IFLCheckBox
        Me.lblRodeEndSwingClearanceMinMax = New System.Windows.Forms.Label
        Me.lblBaseEndSwingClearanceMinMax = New System.Windows.Forms.Label
        Me.txtAdjustSwingClearance_RE = New IFLCustomUILayer.IFLNumericBox
        Me.chkAdjustSwingClearance_RE = New IFLCustomUILayer.IFLCheckBox
        Me.lblReductionInRetractedLength = New System.Windows.Forms.Label
        Me.lblOptions = New System.Windows.Forms.Label
        Me.txtAdjustSwingClearance_BE = New IFLCustomUILayer.IFLNumericBox
        Me.txtReplaceFabricatedULugwithFabricatedDoubleLug = New System.Windows.Forms.TextBox
        Me.txtReducingSkimLengthOfRod = New System.Windows.Forms.TextBox
        Me.txtCompressCylinderHead = New System.Windows.Forms.TextBox
        Me.txtOffsetPortOrifice = New System.Windows.Forms.TextBox
        Me.lblBaseEndSelection = New LabelGradient.LabelGradient
        Me.chkAdjustSwingClearance_BE = New IFLCustomUILayer.IFLCheckBox
        Me.chkReplaceFabricatedULugwithFabricatedDoubleLug = New IFLCustomUILayer.IFLCheckBox
        Me.chkReducingSkimLengthOfRod = New IFLCustomUILayer.IFLCheckBox
        Me.chkCompressCylinderHead = New IFLCustomUILayer.IFLCheckBox
        Me.chkCounterBorePistonAndOffsetPortOrifice = New IFLCustomUILayer.IFLCheckBox
        Me.lblHeadDesign = New LabelGradient.LabelGradient
        Me.LabelGradient1 = New LabelGradient.LabelGradient
        Me.lblStickOutDistance = New System.Windows.Forms.Label
        Me.lblRecommendedRetractedLength = New System.Windows.Forms.Label
        Me.txtStickOutDistance = New System.Windows.Forms.TextBox
        Me.txtRecommendedRetractedLength = New System.Windows.Forms.TextBox
        Me.pnlRetractedLengthCalculation = New System.Windows.Forms.Panel
        Me.txtRequiredRetractedLength = New System.Windows.Forms.TextBox
        Me.lblRequiredRetractedLength = New System.Windows.Forms.Label
        Me.LabelGradient6 = New LabelGradient.LabelGradient
        Me.btnAcceptRetractedLength = New System.Windows.Forms.Button
        Me.pnlRetractedLength.SuspendLayout()
        Me.pnlRetractedLengthCalculation.SuspendLayout()
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
        Me.LabelGradient5.Text = "Retracted Length Validation"
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
        'pnlRetractedLength
        '
        Me.pnlRetractedLength.BackColor = System.Drawing.Color.Ivory
        Me.pnlRetractedLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlRetractedLength.Controls.Add(Me.txtCounterBoreClevisPlate)
        Me.pnlRetractedLength.Controls.Add(Me.chkCounterBoreClevisPlate)
        Me.pnlRetractedLength.Controls.Add(Me.lblRodeEndSwingClearanceMinMax)
        Me.pnlRetractedLength.Controls.Add(Me.lblBaseEndSwingClearanceMinMax)
        Me.pnlRetractedLength.Controls.Add(Me.txtAdjustSwingClearance_RE)
        Me.pnlRetractedLength.Controls.Add(Me.chkAdjustSwingClearance_RE)
        Me.pnlRetractedLength.Controls.Add(Me.lblReductionInRetractedLength)
        Me.pnlRetractedLength.Controls.Add(Me.lblOptions)
        Me.pnlRetractedLength.Controls.Add(Me.txtAdjustSwingClearance_BE)
        Me.pnlRetractedLength.Controls.Add(Me.txtReplaceFabricatedULugwithFabricatedDoubleLug)
        Me.pnlRetractedLength.Controls.Add(Me.txtReducingSkimLengthOfRod)
        Me.pnlRetractedLength.Controls.Add(Me.txtCompressCylinderHead)
        Me.pnlRetractedLength.Controls.Add(Me.txtOffsetPortOrifice)
        Me.pnlRetractedLength.Controls.Add(Me.lblBaseEndSelection)
        Me.pnlRetractedLength.Controls.Add(Me.chkAdjustSwingClearance_BE)
        Me.pnlRetractedLength.Controls.Add(Me.chkReplaceFabricatedULugwithFabricatedDoubleLug)
        Me.pnlRetractedLength.Controls.Add(Me.chkReducingSkimLengthOfRod)
        Me.pnlRetractedLength.Controls.Add(Me.chkCompressCylinderHead)
        Me.pnlRetractedLength.Controls.Add(Me.chkCounterBorePistonAndOffsetPortOrifice)
        Me.pnlRetractedLength.Location = New System.Drawing.Point(38, 37)
        Me.pnlRetractedLength.Name = "pnlRetractedLength"
        Me.pnlRetractedLength.Size = New System.Drawing.Size(521, 326)
        Me.pnlRetractedLength.TabIndex = 38
        '
        'txtCounterBoreClevisPlate
        '
        Me.txtCounterBoreClevisPlate.Location = New System.Drawing.Point(384, 291)
        Me.txtCounterBoreClevisPlate.Name = "txtCounterBoreClevisPlate"
        Me.txtCounterBoreClevisPlate.Size = New System.Drawing.Size(100, 20)
        Me.txtCounterBoreClevisPlate.TabIndex = 43
        '
        'chkCounterBoreClevisPlate
        '
        Me.chkCounterBoreClevisPlate.AutoSize = True
        Me.chkCounterBoreClevisPlate.IFLDataTag = Nothing
        Me.chkCounterBoreClevisPlate.Location = New System.Drawing.Point(28, 291)
        Me.chkCounterBoreClevisPlate.Name = "chkCounterBoreClevisPlate"
        Me.chkCounterBoreClevisPlate.Size = New System.Drawing.Size(146, 17)
        Me.chkCounterBoreClevisPlate.StatusMessage = Nothing
        Me.chkCounterBoreClevisPlate.StatusObject = Nothing
        Me.chkCounterBoreClevisPlate.TabIndex = 42
        Me.chkCounterBoreClevisPlate.Text = "Counter Bore Clevis Plate"
        Me.chkCounterBoreClevisPlate.UseVisualStyleBackColor = True
        '
        'lblRodeEndSwingClearanceMinMax
        '
        Me.lblRodeEndSwingClearanceMinMax.Location = New System.Drawing.Point(25, 239)
        Me.lblRodeEndSwingClearanceMinMax.Name = "lblRodeEndSwingClearanceMinMax"
        Me.lblRodeEndSwingClearanceMinMax.Size = New System.Drawing.Size(461, 12)
        Me.lblRodeEndSwingClearanceMinMax.TabIndex = 41
        Me.lblRodeEndSwingClearanceMinMax.Text = "Label1"
        '
        'lblBaseEndSwingClearanceMinMax
        '
        Me.lblBaseEndSwingClearanceMinMax.Location = New System.Drawing.Point(27, 185)
        Me.lblBaseEndSwingClearanceMinMax.Name = "lblBaseEndSwingClearanceMinMax"
        Me.lblBaseEndSwingClearanceMinMax.Size = New System.Drawing.Size(461, 12)
        Me.lblBaseEndSwingClearanceMinMax.TabIndex = 40
        Me.lblBaseEndSwingClearanceMinMax.Text = "Label1"
        '
        'txtAdjustSwingClearance_RE
        '
        Me.txtAdjustSwingClearance_RE.AcceptEnterKeyAsTab = True
        Me.txtAdjustSwingClearance_RE.ApplyIFLColor = True
        Me.txtAdjustSwingClearance_RE.AssociateLabel = Nothing
        Me.txtAdjustSwingClearance_RE.DecimalValue = 3
        Me.txtAdjustSwingClearance_RE.IFLDataTag = Nothing
        Me.txtAdjustSwingClearance_RE.InvalidInputCharacters = ""
        Me.txtAdjustSwingClearance_RE.IsAllowNegative = False
        Me.txtAdjustSwingClearance_RE.LengthValue = 10
        Me.txtAdjustSwingClearance_RE.Location = New System.Drawing.Point(384, 255)
        Me.txtAdjustSwingClearance_RE.MaximumValue = 99999999999999
        Me.txtAdjustSwingClearance_RE.MinimumValue = 0
        Me.txtAdjustSwingClearance_RE.Name = "txtAdjustSwingClearance_RE"
        Me.txtAdjustSwingClearance_RE.Size = New System.Drawing.Size(100, 20)
        Me.txtAdjustSwingClearance_RE.StatusMessage = Nothing
        Me.txtAdjustSwingClearance_RE.StatusObject = Nothing
        Me.txtAdjustSwingClearance_RE.TabIndex = 39
        Me.txtAdjustSwingClearance_RE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkAdjustSwingClearance_RE
        '
        Me.chkAdjustSwingClearance_RE.AutoSize = True
        Me.chkAdjustSwingClearance_RE.IFLDataTag = Nothing
        Me.chkAdjustSwingClearance_RE.Location = New System.Drawing.Point(28, 262)
        Me.chkAdjustSwingClearance_RE.Name = "chkAdjustSwingClearance_RE"
        Me.chkAdjustSwingClearance_RE.Size = New System.Drawing.Size(189, 17)
        Me.chkAdjustSwingClearance_RE.StatusMessage = Nothing
        Me.chkAdjustSwingClearance_RE.StatusObject = Nothing
        Me.chkAdjustSwingClearance_RE.TabIndex = 38
        Me.chkAdjustSwingClearance_RE.Text = "Adjust Swing Clearance (Rod End)"
        Me.chkAdjustSwingClearance_RE.UseVisualStyleBackColor = True
        '
        'lblReductionInRetractedLength
        '
        Me.lblReductionInRetractedLength.AutoSize = True
        Me.lblReductionInRetractedLength.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblReductionInRetractedLength.Location = New System.Drawing.Point(331, 27)
        Me.lblReductionInRetractedLength.Name = "lblReductionInRetractedLength"
        Me.lblReductionInRetractedLength.Size = New System.Drawing.Size(153, 13)
        Me.lblReductionInRetractedLength.TabIndex = 35
        Me.lblReductionInRetractedLength.Text = "Reduction in Retracted Length"
        '
        'lblOptions
        '
        Me.lblOptions.AutoSize = True
        Me.lblOptions.BackColor = System.Drawing.Color.Ivory
        Me.lblOptions.Location = New System.Drawing.Point(26, 27)
        Me.lblOptions.Name = "lblOptions"
        Me.lblOptions.Size = New System.Drawing.Size(43, 13)
        Me.lblOptions.TabIndex = 33
        Me.lblOptions.Text = "Options"
        '
        'txtAdjustSwingClearance_BE
        '
        Me.txtAdjustSwingClearance_BE.AcceptEnterKeyAsTab = True
        Me.txtAdjustSwingClearance_BE.ApplyIFLColor = True
        Me.txtAdjustSwingClearance_BE.AssociateLabel = Nothing
        Me.txtAdjustSwingClearance_BE.DecimalValue = 3
        Me.txtAdjustSwingClearance_BE.IFLDataTag = Nothing
        Me.txtAdjustSwingClearance_BE.InvalidInputCharacters = ""
        Me.txtAdjustSwingClearance_BE.IsAllowNegative = False
        Me.txtAdjustSwingClearance_BE.LengthValue = 10
        Me.txtAdjustSwingClearance_BE.Location = New System.Drawing.Point(384, 204)
        Me.txtAdjustSwingClearance_BE.MaximumValue = 99999999999999
        Me.txtAdjustSwingClearance_BE.MinimumValue = 0
        Me.txtAdjustSwingClearance_BE.Name = "txtAdjustSwingClearance_BE"
        Me.txtAdjustSwingClearance_BE.Size = New System.Drawing.Size(100, 20)
        Me.txtAdjustSwingClearance_BE.StatusMessage = Nothing
        Me.txtAdjustSwingClearance_BE.StatusObject = Nothing
        Me.txtAdjustSwingClearance_BE.TabIndex = 32
        Me.txtAdjustSwingClearance_BE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReplaceFabricatedULugwithFabricatedDoubleLug
        '
        Me.txtReplaceFabricatedULugwithFabricatedDoubleLug.Location = New System.Drawing.Point(384, 152)
        Me.txtReplaceFabricatedULugwithFabricatedDoubleLug.Name = "txtReplaceFabricatedULugwithFabricatedDoubleLug"
        Me.txtReplaceFabricatedULugwithFabricatedDoubleLug.Size = New System.Drawing.Size(100, 20)
        Me.txtReplaceFabricatedULugwithFabricatedDoubleLug.TabIndex = 30
        '
        'txtReducingSkimLengthOfRod
        '
        Me.txtReducingSkimLengthOfRod.Location = New System.Drawing.Point(384, 130)
        Me.txtReducingSkimLengthOfRod.Name = "txtReducingSkimLengthOfRod"
        Me.txtReducingSkimLengthOfRod.Size = New System.Drawing.Size(100, 20)
        Me.txtReducingSkimLengthOfRod.TabIndex = 28
        '
        'txtCompressCylinderHead
        '
        Me.txtCompressCylinderHead.Location = New System.Drawing.Point(384, 92)
        Me.txtCompressCylinderHead.Name = "txtCompressCylinderHead"
        Me.txtCompressCylinderHead.Size = New System.Drawing.Size(100, 20)
        Me.txtCompressCylinderHead.TabIndex = 26
        '
        'txtOffsetPortOrifice
        '
        Me.txtOffsetPortOrifice.Location = New System.Drawing.Point(384, 54)
        Me.txtOffsetPortOrifice.Name = "txtOffsetPortOrifice"
        Me.txtOffsetPortOrifice.Size = New System.Drawing.Size(100, 20)
        Me.txtOffsetPortOrifice.TabIndex = 24
        '
        'lblBaseEndSelection
        '
        Me.lblBaseEndSelection.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.lblBaseEndSelection.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBaseEndSelection.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBaseEndSelection.GradientColorOne = System.Drawing.Color.Olive
        Me.lblBaseEndSelection.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.lblBaseEndSelection.Location = New System.Drawing.Point(-2, 0)
        Me.lblBaseEndSelection.Name = "lblBaseEndSelection"
        Me.lblBaseEndSelection.Size = New System.Drawing.Size(521, 19)
        Me.lblBaseEndSelection.TabIndex = 21
        Me.lblBaseEndSelection.Text = "Retracted Length Validation"
        Me.lblBaseEndSelection.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'chkAdjustSwingClearance_BE
        '
        Me.chkAdjustSwingClearance_BE.AutoSize = True
        Me.chkAdjustSwingClearance_BE.IFLDataTag = Nothing
        Me.chkAdjustSwingClearance_BE.Location = New System.Drawing.Point(29, 210)
        Me.chkAdjustSwingClearance_BE.Name = "chkAdjustSwingClearance_BE"
        Me.chkAdjustSwingClearance_BE.Size = New System.Drawing.Size(193, 17)
        Me.chkAdjustSwingClearance_BE.StatusMessage = Nothing
        Me.chkAdjustSwingClearance_BE.StatusObject = Nothing
        Me.chkAdjustSwingClearance_BE.TabIndex = 5
        Me.chkAdjustSwingClearance_BE.Text = "Adjust Swing Clearance (Base End)"
        Me.chkAdjustSwingClearance_BE.UseVisualStyleBackColor = True
        '
        'chkReplaceFabricatedULugwithFabricatedDoubleLug
        '
        Me.chkReplaceFabricatedULugwithFabricatedDoubleLug.AutoSize = True
        Me.chkReplaceFabricatedULugwithFabricatedDoubleLug.IFLDataTag = Nothing
        Me.chkReplaceFabricatedULugwithFabricatedDoubleLug.Location = New System.Drawing.Point(29, 152)
        Me.chkReplaceFabricatedULugwithFabricatedDoubleLug.Name = "chkReplaceFabricatedULugwithFabricatedDoubleLug"
        Me.chkReplaceFabricatedULugwithFabricatedDoubleLug.Size = New System.Drawing.Size(287, 17)
        Me.chkReplaceFabricatedULugwithFabricatedDoubleLug.StatusMessage = Nothing
        Me.chkReplaceFabricatedULugwithFabricatedDoubleLug.StatusObject = Nothing
        Me.chkReplaceFabricatedULugwithFabricatedDoubleLug.TabIndex = 4
        Me.chkReplaceFabricatedULugwithFabricatedDoubleLug.Text = "Replace Fabricated U Lug with Fabricated Double Lug "
        Me.chkReplaceFabricatedULugwithFabricatedDoubleLug.UseVisualStyleBackColor = True
        '
        'chkReducingSkimLengthOfRod
        '
        Me.chkReducingSkimLengthOfRod.AutoSize = True
        Me.chkReducingSkimLengthOfRod.IFLDataTag = Nothing
        Me.chkReducingSkimLengthOfRod.Location = New System.Drawing.Point(28, 120)
        Me.chkReducingSkimLengthOfRod.Name = "chkReducingSkimLengthOfRod"
        Me.chkReducingSkimLengthOfRod.Size = New System.Drawing.Size(169, 17)
        Me.chkReducingSkimLengthOfRod.StatusMessage = Nothing
        Me.chkReducingSkimLengthOfRod.StatusObject = Nothing
        Me.chkReducingSkimLengthOfRod.TabIndex = 3
        Me.chkReducingSkimLengthOfRod.Text = "Reducing Skim Length of Rod"
        Me.chkReducingSkimLengthOfRod.UseVisualStyleBackColor = True
        '
        'chkCompressCylinderHead
        '
        Me.chkCompressCylinderHead.AutoSize = True
        Me.chkCompressCylinderHead.IFLDataTag = Nothing
        Me.chkCompressCylinderHead.Location = New System.Drawing.Point(28, 88)
        Me.chkCompressCylinderHead.Name = "chkCompressCylinderHead"
        Me.chkCompressCylinderHead.Size = New System.Drawing.Size(141, 17)
        Me.chkCompressCylinderHead.StatusMessage = Nothing
        Me.chkCompressCylinderHead.StatusObject = Nothing
        Me.chkCompressCylinderHead.TabIndex = 2
        Me.chkCompressCylinderHead.Text = "Compress Cylinder Head"
        Me.chkCompressCylinderHead.UseVisualStyleBackColor = True
        '
        'chkCounterBorePistonAndOffsetPortOrifice
        '
        Me.chkCounterBorePistonAndOffsetPortOrifice.AutoSize = True
        Me.chkCounterBorePistonAndOffsetPortOrifice.IFLDataTag = Nothing
        Me.chkCounterBorePistonAndOffsetPortOrifice.Location = New System.Drawing.Point(28, 56)
        Me.chkCounterBorePistonAndOffsetPortOrifice.Name = "chkCounterBorePistonAndOffsetPortOrifice"
        Me.chkCounterBorePistonAndOffsetPortOrifice.Size = New System.Drawing.Size(227, 17)
        Me.chkCounterBorePistonAndOffsetPortOrifice.StatusMessage = Nothing
        Me.chkCounterBorePistonAndOffsetPortOrifice.StatusObject = Nothing
        Me.chkCounterBorePistonAndOffsetPortOrifice.TabIndex = 1
        Me.chkCounterBorePistonAndOffsetPortOrifice.Text = "Counter Bore Piston and Offset Port Orifice"
        Me.chkCounterBorePistonAndOffsetPortOrifice.UseVisualStyleBackColor = True
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
        Me.lblHeadDesign.Size = New System.Drawing.Size(547, 346)
        Me.lblHeadDesign.TabIndex = 46
        Me.lblHeadDesign.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelGradient1
        '
        Me.LabelGradient1.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient1.GradientColorOne = System.Drawing.Color.Olive
        Me.LabelGradient1.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient1.Location = New System.Drawing.Point(0, 0)
        Me.LabelGradient1.Name = "LabelGradient1"
        Me.LabelGradient1.Size = New System.Drawing.Size(521, 19)
        Me.LabelGradient1.TabIndex = 22
        Me.LabelGradient1.Text = "Retracted Length Calculation"
        Me.LabelGradient1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblStickOutDistance
        '
        Me.lblStickOutDistance.AutoSize = True
        Me.lblStickOutDistance.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblStickOutDistance.Location = New System.Drawing.Point(49, 30)
        Me.lblStickOutDistance.Name = "lblStickOutDistance"
        Me.lblStickOutDistance.Size = New System.Drawing.Size(96, 13)
        Me.lblStickOutDistance.TabIndex = 36
        Me.lblStickOutDistance.Text = "Stick Out Distance"
        '
        'lblRecommendedRetractedLength
        '
        Me.lblRecommendedRetractedLength.AutoSize = True
        Me.lblRecommendedRetractedLength.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblRecommendedRetractedLength.Location = New System.Drawing.Point(49, 98)
        Me.lblRecommendedRetractedLength.Name = "lblRecommendedRetractedLength"
        Me.lblRecommendedRetractedLength.Size = New System.Drawing.Size(165, 13)
        Me.lblRecommendedRetractedLength.TabIndex = 37
        Me.lblRecommendedRetractedLength.Text = "Recommended Retracted Length"
        '
        'txtStickOutDistance
        '
        Me.txtStickOutDistance.Location = New System.Drawing.Point(386, 27)
        Me.txtStickOutDistance.Name = "txtStickOutDistance"
        Me.txtStickOutDistance.Size = New System.Drawing.Size(100, 20)
        Me.txtStickOutDistance.TabIndex = 38
        '
        'txtRecommendedRetractedLength
        '
        Me.txtRecommendedRetractedLength.Location = New System.Drawing.Point(386, 95)
        Me.txtRecommendedRetractedLength.Name = "txtRecommendedRetractedLength"
        Me.txtRecommendedRetractedLength.Size = New System.Drawing.Size(100, 20)
        Me.txtRecommendedRetractedLength.TabIndex = 39
        '
        'pnlRetractedLengthCalculation
        '
        Me.pnlRetractedLengthCalculation.BackColor = System.Drawing.Color.Ivory
        Me.pnlRetractedLengthCalculation.Controls.Add(Me.txtRequiredRetractedLength)
        Me.pnlRetractedLengthCalculation.Controls.Add(Me.lblRequiredRetractedLength)
        Me.pnlRetractedLengthCalculation.Controls.Add(Me.txtRecommendedRetractedLength)
        Me.pnlRetractedLengthCalculation.Controls.Add(Me.txtStickOutDistance)
        Me.pnlRetractedLengthCalculation.Controls.Add(Me.lblRecommendedRetractedLength)
        Me.pnlRetractedLengthCalculation.Controls.Add(Me.lblStickOutDistance)
        Me.pnlRetractedLengthCalculation.Controls.Add(Me.LabelGradient1)
        Me.pnlRetractedLengthCalculation.Location = New System.Drawing.Point(42, 397)
        Me.pnlRetractedLengthCalculation.Name = "pnlRetractedLengthCalculation"
        Me.pnlRetractedLengthCalculation.Size = New System.Drawing.Size(521, 121)
        Me.pnlRetractedLengthCalculation.TabIndex = 47
        '
        'txtRequiredRetractedLength
        '
        Me.txtRequiredRetractedLength.Location = New System.Drawing.Point(386, 61)
        Me.txtRequiredRetractedLength.Name = "txtRequiredRetractedLength"
        Me.txtRequiredRetractedLength.Size = New System.Drawing.Size(100, 20)
        Me.txtRequiredRetractedLength.TabIndex = 41
        '
        'lblRequiredRetractedLength
        '
        Me.lblRequiredRetractedLength.AutoSize = True
        Me.lblRequiredRetractedLength.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblRequiredRetractedLength.Location = New System.Drawing.Point(49, 64)
        Me.lblRequiredRetractedLength.Name = "lblRequiredRetractedLength"
        Me.lblRequiredRetractedLength.Size = New System.Drawing.Size(136, 13)
        Me.lblRequiredRetractedLength.TabIndex = 40
        Me.lblRequiredRetractedLength.Text = "Required Retracted Length"
        '
        'LabelGradient6
        '
        Me.LabelGradient6.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust
        Me.LabelGradient6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradient6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelGradient6.GradientColorOne = System.Drawing.Color.DarkGoldenrod
        Me.LabelGradient6.GradientColorTwo = System.Drawing.Color.Honeydew
        Me.LabelGradient6.Location = New System.Drawing.Point(29, 387)
        Me.LabelGradient6.Name = "LabelGradient6"
        Me.LabelGradient6.Size = New System.Drawing.Size(544, 165)
        Me.LabelGradient6.TabIndex = 48
        Me.LabelGradient6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnAcceptRetractedLength
        '
        Me.btnAcceptRetractedLength.Location = New System.Drawing.Point(220, 524)
        Me.btnAcceptRetractedLength.Name = "btnAcceptRetractedLength"
        Me.btnAcceptRetractedLength.Size = New System.Drawing.Size(136, 24)
        Me.btnAcceptRetractedLength.TabIndex = 49
        Me.btnAcceptRetractedLength.Text = "Accept "
        Me.btnAcceptRetractedLength.UseVisualStyleBackColor = True
        '
        'frmRetractedLengthValidation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1036, 780)
        Me.Controls.Add(Me.btnAcceptRetractedLength)
        Me.Controls.Add(Me.pnlRetractedLength)
        Me.Controls.Add(Me.LabelGradient5)
        Me.Controls.Add(Me.LabelGradient4)
        Me.Controls.Add(Me.LabelGradient3)
        Me.Controls.Add(Me.LabelGradient2)
        Me.Controls.Add(Me.pnlRetractedLengthCalculation)
        Me.Controls.Add(Me.lblHeadDesign)
        Me.Controls.Add(Me.LabelGradient6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmRetractedLengthValidation"
        Me.Text = "frmRetractedLengthValidation"
        Me.pnlRetractedLength.ResumeLayout(False)
        Me.pnlRetractedLength.PerformLayout()
        Me.pnlRetractedLengthCalculation.ResumeLayout(False)
        Me.pnlRetractedLengthCalculation.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelGradient5 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient4 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient3 As LabelGradient.LabelGradient
    Friend WithEvents LabelGradient2 As LabelGradient.LabelGradient
    Friend WithEvents pnlRetractedLength As System.Windows.Forms.Panel
    Friend WithEvents lblHeadDesign As LabelGradient.LabelGradient
    Friend WithEvents chkAdjustSwingClearance_BE As IFLCustomUILayer.IFLCheckBox
    Friend WithEvents chkReplaceFabricatedULugwithFabricatedDoubleLug As IFLCustomUILayer.IFLCheckBox
    Friend WithEvents chkReducingSkimLengthOfRod As IFLCustomUILayer.IFLCheckBox
    Friend WithEvents chkCompressCylinderHead As IFLCustomUILayer.IFLCheckBox
    Friend WithEvents chkCounterBorePistonAndOffsetPortOrifice As IFLCustomUILayer.IFLCheckBox
    Friend WithEvents lblBaseEndSelection As LabelGradient.LabelGradient
    Friend WithEvents txtAdjustSwingClearance_BE As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents txtReplaceFabricatedULugwithFabricatedDoubleLug As System.Windows.Forms.TextBox
    Friend WithEvents txtReducingSkimLengthOfRod As System.Windows.Forms.TextBox
    Friend WithEvents txtCompressCylinderHead As System.Windows.Forms.TextBox
    Friend WithEvents txtOffsetPortOrifice As System.Windows.Forms.TextBox
    Friend WithEvents lblReductionInRetractedLength As System.Windows.Forms.Label
    Friend WithEvents lblOptions As System.Windows.Forms.Label
    Friend WithEvents LabelGradient1 As LabelGradient.LabelGradient
    Friend WithEvents lblStickOutDistance As System.Windows.Forms.Label
    Friend WithEvents lblRecommendedRetractedLength As System.Windows.Forms.Label
    Friend WithEvents txtStickOutDistance As System.Windows.Forms.TextBox
    Friend WithEvents txtRecommendedRetractedLength As System.Windows.Forms.TextBox
    Friend WithEvents pnlRetractedLengthCalculation As System.Windows.Forms.Panel
    Friend WithEvents LabelGradient6 As LabelGradient.LabelGradient
    Friend WithEvents txtRequiredRetractedLength As System.Windows.Forms.TextBox
    Friend WithEvents lblRequiredRetractedLength As System.Windows.Forms.Label
    Friend WithEvents txtAdjustSwingClearance_RE As IFLCustomUILayer.IFLNumericBox
    Friend WithEvents chkAdjustSwingClearance_RE As IFLCustomUILayer.IFLCheckBox
    Friend WithEvents btnAcceptRetractedLength As System.Windows.Forms.Button
    Friend WithEvents lblBaseEndSwingClearanceMinMax As System.Windows.Forms.Label
    Friend WithEvents lblRodeEndSwingClearanceMinMax As System.Windows.Forms.Label
    Friend WithEvents txtCounterBoreClevisPlate As System.Windows.Forms.TextBox
    Friend WithEvents chkCounterBoreClevisPlate As IFLCustomUILayer.IFLCheckBox
End Class
