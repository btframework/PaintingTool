Public Class fmMain
    Private Sub OpenFile()
        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            Dim Bmp As New Bitmap(OpenFileDialog.FileName)
            ImageEditor.Image = Bmp
            ImageEditor.Mode = ZoomPanelMode.pmMove

            slSize.Text = "Size: " + Bmp.Width.ToString + " x " + Bmp.Height.ToString()

            UpdateButtons()
        End If
    End Sub

    Private Sub SaveImage()
        If SaveFileDialog.ShowDialog = DialogResult.OK Then
            ImageEditor.Image.Save(SaveFileDialog.FileName)
        End If
    End Sub

    Private Sub UpdateButtons()
        tbSave.Enabled = ImageEditor.Image IsNot Nothing
        tbHand.Enabled = tbSave.Enabled
        tbDraw.Enabled = tbSave.Enabled
        tbErase.Enabled = tbSave.Enabled

        tbHand.Checked = ImageEditor.Mode = ZoomPanelMode.pmMove
        tbDraw.Checked = ImageEditor.Mode = ZoomPanelMode.pmPaint
        tbErase.Checked = ImageEditor.Mode = ZoomPanelMode.pmEarse

        miFileSave.Enabled = tbSave.Enabled
    End Sub

    Private Sub UpdateZoom()
        slZoom.Text = "Zoom: " + Convert.ToInt32(ImageEditor.Zoom * 100).ToString() + "%"
    End Sub

    Private Sub miFileExit_Click(sender As Object, e As EventArgs) Handles miFileExit.Click
        Close()
    End Sub

    Private Sub miFileOpen_Click(sender As Object, e As EventArgs) Handles miFileOpen.Click
        OpenFile()
    End Sub

    Private Sub tbOpen_Click(sender As Object, e As EventArgs) Handles tbOpen.Click
        OpenFile()
    End Sub

    Private Sub fmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateButtons()
        UpdateZoom()
        slSize.Text = "Size: 0 x 0"
        slZoom.Text = "Zoom: 100%"
        slPosition.Text = "X: 0; Y: 0"
    End Sub

    Private Sub tbHand_Click(sender As Object, e As EventArgs) Handles tbHand.Click
        ImageEditor.Mode = ZoomPanelMode.pmMove
        UpdateButtons()
    End Sub

    Private Sub tbDraw_Click(sender As Object, e As EventArgs) Handles tbDraw.Click
        ImageEditor.Mode = ZoomPanelMode.pmPaint
        UpdateButtons()
    End Sub

    Private Sub tbErase_Click(sender As Object, e As EventArgs) Handles tbErase.Click
        ImageEditor.Mode = ZoomPanelMode.pmEarse
        UpdateButtons()
    End Sub

    Private Sub ImageEditor_ZoomChanged(e As EventArgs) Handles ImageEditor.ZoomChanged
        UpdateZoom()
    End Sub

    Private Sub ImageEditor_PositionChanged(e As ZoomPanelCoordinatesChangedArgs) Handles ImageEditor.PositionChanged
        slPosition.Text = "X: " + e.X.ToString() + "; Y: " + e.Y.ToString()
    End Sub

    Private Sub tbSave_Click(sender As Object, e As EventArgs) Handles tbSave.Click
        SaveImage()
    End Sub

    Private Sub miFileSave_Click(sender As Object, e As EventArgs) Handles miFileSave.Click
        SaveImage()
    End Sub

    Private Sub tbColor_Click(sender As Object, e As EventArgs) Handles tbColor.Click
        If ColorDialog.ShowDialog = DialogResult.OK Then
            tbColor.BackColor = ColorDialog.Color
            ImageEditor.PenColor = ColorDialog.Color
        End If
    End Sub
End Class
