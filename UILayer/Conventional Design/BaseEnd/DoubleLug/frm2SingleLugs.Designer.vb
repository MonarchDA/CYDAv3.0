<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm2SingleLugs
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkULug = New System.Windows.Forms.CheckBox
        Me.chkDoubleLug = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnclose = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(72, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(297, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Please select your option"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkULug
        '
        Me.chkULug.AutoSize = True
        Me.chkULug.Location = New System.Drawing.Point(18, 13)
        Me.chkULug.Name = "chkULug"
        Me.chkULug.Size = New System.Drawing.Size(55, 17)
        Me.chkULug.TabIndex = 3
        Me.chkULug.Text = "U-Lug"
        Me.chkULug.UseVisualStyleBackColor = True
        '
        'chkDoubleLug
        '
        Me.chkDoubleLug.AutoSize = True
        Me.chkDoubleLug.Location = New System.Drawing.Point(190, 12)
        Me.chkDoubleLug.Name = "chkDoubleLug"
        Me.chkDoubleLug.Size = New System.Drawing.Size(81, 17)
        Me.chkDoubleLug.TabIndex = 3
        Me.chkDoubleLug.Text = "Double Lug"
        Me.chkDoubleLug.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkDoubleLug)
        Me.GroupBox2.Controls.Add(Me.chkULug)
        Me.GroupBox2.Location = New System.Drawing.Point(77, 69)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(296, 34)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'btnclose
        '
        Me.btnclose.Location = New System.Drawing.Point(358, 153)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(75, 23)
        Me.btnclose.TabIndex = 3
        Me.btnclose.Text = "Close"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'frm2SingleLugs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Maroon
        Me.ClientSize = New System.Drawing.Size(467, 188)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frm2SingleLugs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm2SingleLugs"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkULug As System.Windows.Forms.CheckBox
    Friend WithEvents chkDoubleLug As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnclose As System.Windows.Forms.Button
End Class
