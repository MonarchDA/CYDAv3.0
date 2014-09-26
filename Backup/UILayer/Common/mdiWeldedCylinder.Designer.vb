<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mdiWeldedCylinder
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mdiWeldedCylinder))
        Me.pnlInformationArea = New System.Windows.Forms.Panel
        Me.picCommonBox = New System.Windows.Forms.PictureBox
        Me.lvwLoginDetails = New System.Windows.Forms.ListView
        Me.lvwGeneralInformation = New System.Windows.Forms.ListView
        Me.pnlMonarchLogo = New System.Windows.Forms.Panel
        Me.picMIL_Image = New System.Windows.Forms.PictureBox
        Me.lblDate = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.AssemblyMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RevisionMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CastingsUpdationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReleasedMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.pnlChildFormArea = New System.Windows.Forms.Panel
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnHome = New System.Windows.Forms.Button
        Me.btnBack = New System.Windows.Forms.Button
        Me.pnlBottom = New System.Windows.Forms.Panel
        Me.btnExcel = New System.Windows.Forms.Button
        Me.picIFLLOGO = New System.Windows.Forms.PictureBox
        Me.timerCurrentDateAndTime = New System.Windows.Forms.Timer(Me.components)
        Me.pnlInformationArea.SuspendLayout()
        CType(Me.picCommonBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMonarchLogo.SuspendLayout()
        CType(Me.picMIL_Image, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        CType(Me.picIFLLOGO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlInformationArea
        '
        Me.pnlInformationArea.BackColor = System.Drawing.SystemColors.Window
        Me.pnlInformationArea.Controls.Add(Me.picCommonBox)
        Me.pnlInformationArea.Controls.Add(Me.lvwLoginDetails)
        Me.pnlInformationArea.Controls.Add(Me.lvwGeneralInformation)
        Me.pnlInformationArea.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlInformationArea.Location = New System.Drawing.Point(0, 148)
        Me.pnlInformationArea.Name = "pnlInformationArea"
        Me.pnlInformationArea.Size = New System.Drawing.Size(313, 598)
        Me.pnlInformationArea.TabIndex = 9
        '
        'picCommonBox
        '
        Me.picCommonBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picCommonBox.BackColor = System.Drawing.Color.WhiteSmoke
        Me.picCommonBox.Location = New System.Drawing.Point(2, 241)
        Me.picCommonBox.Name = "picCommonBox"
        Me.picCommonBox.Size = New System.Drawing.Size(311, 262)
        Me.picCommonBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picCommonBox.TabIndex = 39
        Me.picCommonBox.TabStop = False
        '
        'lvwLoginDetails
        '
        Me.lvwLoginDetails.BackgroundImage = CType(resources.GetObject("lvwLoginDetails.BackgroundImage"), System.Drawing.Image)
        Me.lvwLoginDetails.BackgroundImageTiled = True
        Me.lvwLoginDetails.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lvwLoginDetails.GridLines = True
        Me.lvwLoginDetails.Location = New System.Drawing.Point(0, 504)
        Me.lvwLoginDetails.Name = "lvwLoginDetails"
        Me.lvwLoginDetails.Size = New System.Drawing.Size(313, 94)
        Me.lvwLoginDetails.TabIndex = 0
        Me.lvwLoginDetails.UseCompatibleStateImageBehavior = False
        Me.lvwLoginDetails.View = System.Windows.Forms.View.Details
        '
        'lvwGeneralInformation
        '
        Me.lvwGeneralInformation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwGeneralInformation.BackgroundImage = CType(resources.GetObject("lvwGeneralInformation.BackgroundImage"), System.Drawing.Image)
        Me.lvwGeneralInformation.BackgroundImageTiled = True
        Me.lvwGeneralInformation.GridLines = True
        Me.lvwGeneralInformation.Location = New System.Drawing.Point(1, 1)
        Me.lvwGeneralInformation.Name = "lvwGeneralInformation"
        Me.lvwGeneralInformation.Size = New System.Drawing.Size(312, 239)
        Me.lvwGeneralInformation.TabIndex = 0
        Me.lvwGeneralInformation.UseCompatibleStateImageBehavior = False
        Me.lvwGeneralInformation.View = System.Windows.Forms.View.Details
        '
        'pnlMonarchLogo
        '
        Me.pnlMonarchLogo.BackColor = System.Drawing.SystemColors.Window
        Me.pnlMonarchLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pnlMonarchLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlMonarchLogo.Controls.Add(Me.picMIL_Image)
        Me.pnlMonarchLogo.Controls.Add(Me.lblDate)
        Me.pnlMonarchLogo.Controls.Add(Me.MenuStrip1)
        Me.pnlMonarchLogo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMonarchLogo.Location = New System.Drawing.Point(0, 0)
        Me.pnlMonarchLogo.Name = "pnlMonarchLogo"
        Me.pnlMonarchLogo.Size = New System.Drawing.Size(1028, 148)
        Me.pnlMonarchLogo.TabIndex = 10
        '
        'picMIL_Image
        '
        Me.picMIL_Image.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picMIL_Image.Location = New System.Drawing.Point(0, 23)
        Me.picMIL_Image.Name = "picMIL_Image"
        Me.picMIL_Image.Size = New System.Drawing.Size(1026, 122)
        Me.picMIL_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picMIL_Image.TabIndex = 5
        Me.picMIL_Image.TabStop = False
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.lblDate.Location = New System.Drawing.Point(1041, 0)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(63, 20)
        Me.lblDate.TabIndex = 1
        Me.lblDate.Text = "Label1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AssemblyMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1024, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AssemblyMenuItem
        '
        Me.AssemblyMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewMenuItem, Me.RevisionMenuItem, Me.CastingsUpdationToolStripMenuItem, Me.ReleasedMenuItem})
        Me.AssemblyMenuItem.Name = "AssemblyMenuItem"
        Me.AssemblyMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.AssemblyMenuItem.Text = "Assembly"
        '
        'NewMenuItem
        '
        Me.NewMenuItem.BackColor = System.Drawing.Color.DarkKhaki
        Me.NewMenuItem.Name = "NewMenuItem"
        Me.NewMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.NewMenuItem.Text = "&New"
        '
        'RevisionMenuItem
        '
        Me.RevisionMenuItem.BackColor = System.Drawing.Color.DarkKhaki
        Me.RevisionMenuItem.Name = "RevisionMenuItem"
        Me.RevisionMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.RevisionMenuItem.Text = "&Revision"
        '
        'CastingsUpdationToolStripMenuItem
        '
        Me.CastingsUpdationToolStripMenuItem.BackColor = System.Drawing.Color.DarkKhaki
        Me.CastingsUpdationToolStripMenuItem.Name = "CastingsUpdationToolStripMenuItem"
        Me.CastingsUpdationToolStripMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.CastingsUpdationToolStripMenuItem.Text = "&Castings Updation"
        '
        'ReleasedMenuItem
        '
        Me.ReleasedMenuItem.BackColor = System.Drawing.Color.DarkKhaki
        Me.ReleasedMenuItem.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ReleasedMenuItem.Name = "ReleasedMenuItem"
        Me.ReleasedMenuItem.Size = New System.Drawing.Size(245, 22)
        Me.ReleasedMenuItem.Text = "&Release"
        '
        'pnlChildFormArea
        '
        Me.pnlChildFormArea.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlChildFormArea.AutoScroll = True
        Me.pnlChildFormArea.BackColor = System.Drawing.SystemColors.Control
        Me.pnlChildFormArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlChildFormArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlChildFormArea.Location = New System.Drawing.Point(313, 148)
        Me.pnlChildFormArea.Name = "pnlChildFormArea"
        Me.pnlChildFormArea.Size = New System.Drawing.Size(713, 469)
        Me.pnlChildFormArea.TabIndex = 11
        '
        'btnNext
        '
        Me.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnNext.BackgroundImage = CType(resources.GetObject("btnNext.BackgroundImage"), System.Drawing.Image)
        Me.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnNext.Location = New System.Drawing.Point(648, 47)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(46, 32)
        Me.btnNext.TabIndex = 2
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnHome
        '
        Me.btnHome.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnHome.BackgroundImage = CType(resources.GetObject("btnHome.BackgroundImage"), System.Drawing.Image)
        Me.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnHome.Location = New System.Drawing.Point(595, 47)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(46, 32)
        Me.btnHome.TabIndex = 1
        Me.btnHome.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnBack.BackgroundImage = CType(resources.GetObject("btnBack.BackgroundImage"), System.Drawing.Image)
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnBack.Location = New System.Drawing.Point(542, 48)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(46, 32)
        Me.btnBack.TabIndex = 0
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlBottom.BackgroundImage = CType(resources.GetObject("pnlBottom.BackgroundImage"), System.Drawing.Image)
        Me.pnlBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlBottom.Controls.Add(Me.btnExcel)
        Me.pnlBottom.Controls.Add(Me.picIFLLOGO)
        Me.pnlBottom.Controls.Add(Me.btnNext)
        Me.pnlBottom.Controls.Add(Me.btnBack)
        Me.pnlBottom.Controls.Add(Me.btnHome)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(313, 618)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(715, 128)
        Me.pnlBottom.TabIndex = 13
        '
        'btnExcel
        '
        Me.btnExcel.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnExcel.BackgroundImage = CType(resources.GetObject("btnExcel.BackgroundImage"), System.Drawing.Image)
        Me.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExcel.Location = New System.Drawing.Point(485, 48)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(50, 34)
        Me.btnExcel.TabIndex = 4
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'picIFLLOGO
        '
        Me.picIFLLOGO.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.picIFLLOGO.BackColor = System.Drawing.Color.Black
        Me.picIFLLOGO.BackgroundImage = CType(resources.GetObject("picIFLLOGO.BackgroundImage"), System.Drawing.Image)
        Me.picIFLLOGO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.picIFLLOGO.Location = New System.Drawing.Point(296, 9)
        Me.picIFLLOGO.Name = "picIFLLOGO"
        Me.picIFLLOGO.Size = New System.Drawing.Size(119, 107)
        Me.picIFLLOGO.TabIndex = 3
        Me.picIFLLOGO.TabStop = False
        '
        'timerCurrentDateAndTime
        '
        Me.timerCurrentDateAndTime.Enabled = True
        '
        'mdiWeldedCylinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 746)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.pnlInformationArea)
        Me.Controls.Add(Me.pnlChildFormArea)
        Me.Controls.Add(Me.pnlMonarchLogo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "mdiWeldedCylinder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Welded Cylinder"
        Me.pnlInformationArea.ResumeLayout(False)
        CType(Me.picCommonBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMonarchLogo.ResumeLayout(False)
        Me.pnlMonarchLogo.PerformLayout()
        CType(Me.picMIL_Image, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.pnlBottom.ResumeLayout(False)
        CType(Me.picIFLLOGO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlInformationArea As System.Windows.Forms.Panel
    Friend WithEvents pnlMonarchLogo As System.Windows.Forms.Panel
    Friend WithEvents pnlChildFormArea As System.Windows.Forms.Panel
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnHome As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents lvwLoginDetails As System.Windows.Forms.ListView
    Friend WithEvents lvwGeneralInformation As System.Windows.Forms.ListView
    Friend WithEvents picIFLLOGO As System.Windows.Forms.PictureBox
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents timerCurrentDateAndTime As System.Windows.Forms.Timer
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents picCommonBox As System.Windows.Forms.PictureBox
    Friend WithEvents AssemblyMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RevisionMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents picMIL_Image As System.Windows.Forms.PictureBox
    Friend WithEvents CastingsUpdationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReleasedMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
