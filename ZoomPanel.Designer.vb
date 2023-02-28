<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ZoomPanel
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.sbVertical = New System.Windows.Forms.VScrollBar()
        Me.sbHorizontal = New System.Windows.Forms.HScrollBar()
        Me.SuspendLayout()
        '
        'sbVertical
        '
        Me.sbVertical.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.sbVertical.Location = New System.Drawing.Point(95, 21)
        Me.sbVertical.Name = "sbVertical"
        Me.sbVertical.Size = New System.Drawing.Size(17, 80)
        Me.sbVertical.TabIndex = 0
        '
        'sbHorizontal
        '
        Me.sbHorizontal.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.sbHorizontal.Location = New System.Drawing.Point(32, 119)
        Me.sbHorizontal.Name = "sbHorizontal"
        Me.sbHorizontal.Size = New System.Drawing.Size(80, 17)
        Me.sbHorizontal.TabIndex = 1
        '
        'ZoomPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.sbHorizontal)
        Me.Controls.Add(Me.sbVertical)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Name = "ZoomPanel"
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents sbVertical As VScrollBar
    Private WithEvents sbHorizontal As HScrollBar
End Class
