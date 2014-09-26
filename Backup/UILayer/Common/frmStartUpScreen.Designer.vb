<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDisplayScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents lblProjectTitle As System.Windows.Forms.Label
    Friend WithEvents frmFlashScreen As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DetailsLayoutPanel As System.Windows.Forms.TableLayoutPanel

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDisplayScreen))
        Me.frmFlashScreen = New System.Windows.Forms.TableLayoutPanel
        Me.DetailsLayoutPanel = New System.Windows.Forms.TableLayoutPanel
        Me.lblCompany = New System.Windows.Forms.Label
        Me.lblProjectTitle = New System.Windows.Forms.Label
        Me.timerStartUpScreen = New System.Windows.Forms.Timer(Me.components)
        Me.frmFlashScreen.SuspendLayout()
        Me.DetailsLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'frmFlashScreen
        '
        Me.frmFlashScreen.BackgroundImage = CType(resources.GetObject("frmFlashScreen.BackgroundImage"), System.Drawing.Image)
        Me.frmFlashScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.frmFlashScreen.ColumnCount = 2
        Me.frmFlashScreen.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 243.0!))
        Me.frmFlashScreen.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.frmFlashScreen.Controls.Add(Me.DetailsLayoutPanel, 1, 1)
        Me.frmFlashScreen.Controls.Add(Me.lblProjectTitle, 1, 0)
        Me.frmFlashScreen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.frmFlashScreen.Location = New System.Drawing.Point(0, 0)
        Me.frmFlashScreen.Name = "frmFlashScreen"
        Me.frmFlashScreen.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 218.0!))
        Me.frmFlashScreen.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.frmFlashScreen.Size = New System.Drawing.Size(496, 303)
        Me.frmFlashScreen.TabIndex = 0
        '
        'DetailsLayoutPanel
        '
        Me.DetailsLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.DetailsLayoutPanel.BackColor = System.Drawing.Color.Transparent
        Me.DetailsLayoutPanel.ColumnCount = 1
        Me.DetailsLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 247.0!))
        Me.DetailsLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142.0!))
        Me.DetailsLayoutPanel.Controls.Add(Me.lblCompany, 0, 0)
        Me.DetailsLayoutPanel.Location = New System.Drawing.Point(246, 221)
        Me.DetailsLayoutPanel.Name = "DetailsLayoutPanel"
        Me.DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.DetailsLayoutPanel.Size = New System.Drawing.Size(247, 79)
        Me.DetailsLayoutPanel.TabIndex = 1
        '
        'lblCompany
        '
        Me.lblCompany.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblCompany.BackColor = System.Drawing.Color.Transparent
        Me.lblCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompany.Location = New System.Drawing.Point(3, 29)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(241, 20)
        Me.lblCompany.TabIndex = 1
        Me.lblCompany.Text = "Idola Fori Design Ltd"
        Me.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblProjectTitle
        '
        Me.lblProjectTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblProjectTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblProjectTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProjectTitle.Location = New System.Drawing.Point(251, 3)
        Me.lblProjectTitle.Name = "lblProjectTitle"
        Me.lblProjectTitle.Size = New System.Drawing.Size(237, 212)
        Me.lblProjectTitle.TabIndex = 0
        Me.lblProjectTitle.Text = "CYDA v2.0"
        Me.lblProjectTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'timerStartUpScreen
        '
        '
        'frmDisplayScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(496, 303)
        Me.ControlBox = False
        Me.Controls.Add(Me.frmFlashScreen)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDisplayScreen"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.frmFlashScreen.ResumeLayout(False)
        Me.DetailsLayoutPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblCompany As System.Windows.Forms.Label
    Friend WithEvents timerStartUpScreen As System.Windows.Forms.Timer

End Class
