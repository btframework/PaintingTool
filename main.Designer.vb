<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class fmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fmMain))
        Me.MainMenu = New System.Windows.Forms.MenuStrip()
        Me.miFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.miFileOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.miFileSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.miFileSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.tbMain = New System.Windows.Forms.ToolStrip()
        Me.tbOpen = New System.Windows.Forms.ToolStripButton()
        Me.tbSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbHand = New System.Windows.Forms.ToolStripButton()
        Me.tbDraw = New System.Windows.Forms.ToolStripButton()
        Me.tbErase = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.slSize = New System.Windows.Forms.ToolStripStatusLabel()
        Me.slZoom = New System.Windows.Forms.ToolStripStatusLabel()
        Me.slPosition = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.ImageEditor = New PaintingTool.ZoomPanel()
        Me.ColorDialog = New System.Windows.Forms.ColorDialog()
        Me.tbColor = New System.Windows.Forms.ToolStripButton()
        Me.MainMenu.SuspendLayout()
        Me.tbMain.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu
        '
        Me.MainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miFile})
        Me.MainMenu.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu.Name = "MainMenu"
        Me.MainMenu.Size = New System.Drawing.Size(800, 24)
        Me.MainMenu.TabIndex = 0
        Me.MainMenu.Text = "MainMenu"
        '
        'miFile
        '
        Me.miFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miFileOpen, Me.miFileSave, Me.miFileSeparator1, Me.miFileExit})
        Me.miFile.Name = "miFile"
        Me.miFile.Size = New System.Drawing.Size(37, 20)
        Me.miFile.Text = "&File"
        '
        'miFileOpen
        '
        Me.miFileOpen.Name = "miFileOpen"
        Me.miFileOpen.Size = New System.Drawing.Size(103, 22)
        Me.miFileOpen.Text = "&Open"
        '
        'miFileSave
        '
        Me.miFileSave.Name = "miFileSave"
        Me.miFileSave.Size = New System.Drawing.Size(103, 22)
        Me.miFileSave.Text = "&Save"
        '
        'miFileSeparator1
        '
        Me.miFileSeparator1.Name = "miFileSeparator1"
        Me.miFileSeparator1.Size = New System.Drawing.Size(100, 6)
        '
        'miFileExit
        '
        Me.miFileExit.Name = "miFileExit"
        Me.miFileExit.Size = New System.Drawing.Size(103, 22)
        Me.miFileExit.Text = "E&xit"
        '
        'tbMain
        '
        Me.tbMain.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.tbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbOpen, Me.tbSave, Me.ToolStripSeparator1, Me.tbHand, Me.tbDraw, Me.tbErase, Me.tbColor})
        Me.tbMain.Location = New System.Drawing.Point(0, 24)
        Me.tbMain.Name = "tbMain"
        Me.tbMain.Size = New System.Drawing.Size(800, 31)
        Me.tbMain.TabIndex = 2
        Me.tbMain.Text = "Toolbar"
        '
        'tbOpen
        '
        Me.tbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbOpen.Image = CType(resources.GetObject("tbOpen.Image"), System.Drawing.Image)
        Me.tbOpen.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tbOpen.Name = "tbOpen"
        Me.tbOpen.Size = New System.Drawing.Size(28, 28)
        Me.tbOpen.Text = "Open file"
        '
        'tbSave
        '
        Me.tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbSave.Enabled = False
        Me.tbSave.Image = CType(resources.GetObject("tbSave.Image"), System.Drawing.Image)
        Me.tbSave.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tbSave.Name = "tbSave"
        Me.tbSave.Size = New System.Drawing.Size(28, 28)
        Me.tbSave.Text = "Save file"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'tbHand
        '
        Me.tbHand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbHand.Enabled = False
        Me.tbHand.Image = CType(resources.GetObject("tbHand.Image"), System.Drawing.Image)
        Me.tbHand.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tbHand.Name = "tbHand"
        Me.tbHand.Size = New System.Drawing.Size(28, 28)
        Me.tbHand.Text = "Move"
        '
        'tbDraw
        '
        Me.tbDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbDraw.Enabled = False
        Me.tbDraw.Image = CType(resources.GetObject("tbDraw.Image"), System.Drawing.Image)
        Me.tbDraw.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tbDraw.Name = "tbDraw"
        Me.tbDraw.Size = New System.Drawing.Size(28, 28)
        Me.tbDraw.Text = "Draw"
        '
        'tbErase
        '
        Me.tbErase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbErase.Enabled = False
        Me.tbErase.Image = CType(resources.GetObject("tbErase.Image"), System.Drawing.Image)
        Me.tbErase.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.tbErase.Name = "tbErase"
        Me.tbErase.Size = New System.Drawing.Size(28, 28)
        Me.tbErase.Text = "Erase"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.slSize, Me.slZoom, Me.slPosition})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 428)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'slSize
        '
        Me.slSize.AutoSize = False
        Me.slSize.Name = "slSize"
        Me.slSize.Size = New System.Drawing.Size(150, 17)
        Me.slSize.Text = "Size: 0x0"
        Me.slSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'slZoom
        '
        Me.slZoom.AutoSize = False
        Me.slZoom.Name = "slZoom"
        Me.slZoom.Size = New System.Drawing.Size(120, 17)
        Me.slZoom.Text = "Zoom: 100%"
        Me.slZoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'slPosition
        '
        Me.slPosition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.slPosition.Name = "slPosition"
        Me.slPosition.Size = New System.Drawing.Size(51, 17)
        Me.slPosition.Text = "X: 0; Y: 0"
        '
        'ImageEditor
        '
        Me.ImageEditor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImageEditor.CanvasSize = New System.Drawing.Size(700, 300)
        Me.ImageEditor.Cursor = System.Windows.Forms.Cursors.Default
        Me.ImageEditor.Image = Nothing
        Me.ImageEditor.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.[Default]
        Me.ImageEditor.Location = New System.Drawing.Point(12, 58)
        Me.ImageEditor.Mode = PaintingTool.ZoomPanelMode.pmMove
        Me.ImageEditor.Name = "ImageEditor"
        Me.ImageEditor.Size = New System.Drawing.Size(776, 357)
        Me.ImageEditor.TabIndex = 1
        Me.ImageEditor.Zoom = 1.0R
        '
        'tbColor
        '
        Me.tbColor.BackColor = System.Drawing.Color.Black
        Me.tbColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None
        Me.tbColor.Image = CType(resources.GetObject("tbColor.Image"), System.Drawing.Image)
        Me.tbColor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbColor.Margin = New System.Windows.Forms.Padding(2, 6, 2, 6)
        Me.tbColor.Name = "tbColor"
        Me.tbColor.Size = New System.Drawing.Size(23, 19)
        Me.tbColor.Text = "ToolStripButton1"
        '
        'fmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tbMain)
        Me.Controls.Add(Me.MainMenu)
        Me.Controls.Add(Me.ImageEditor)
        Me.Name = "fmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Image Paiting Tool"
        Me.MainMenu.ResumeLayout(False)
        Me.MainMenu.PerformLayout()
        Me.tbMain.ResumeLayout(False)
        Me.tbMain.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents MainMenu As MenuStrip
    Private WithEvents miFile As ToolStripMenuItem
    Private WithEvents miFileExit As ToolStripMenuItem
    Private WithEvents miFileOpen As ToolStripMenuItem
    Private WithEvents miFileSeparator1 As ToolStripSeparator
    Private WithEvents OpenFileDialog As OpenFileDialog
    Private WithEvents ImageEditor As ZoomPanel
    Friend WithEvents tbMain As ToolStrip
    Friend WithEvents tbOpen As ToolStripButton
    Friend WithEvents tbSave As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tbHand As ToolStripButton
    Friend WithEvents tbDraw As ToolStripButton
    Friend WithEvents tbErase As ToolStripButton
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents slSize As ToolStripStatusLabel
    Friend WithEvents slZoom As ToolStripStatusLabel
    Friend WithEvents slPosition As ToolStripStatusLabel
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents miFileSave As ToolStripMenuItem
    Private WithEvents tbColor As ToolStripButton
    Friend WithEvents ColorDialog As ColorDialog
End Class
