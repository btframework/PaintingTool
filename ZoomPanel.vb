'
' Copyright (C) 2023 Marina Petrichenko
' 
' marina@btframework.com  
'   https://www.facebook.com/marina.petrichenko.1  
'   https://www.btframework.com
' 
' It Is free for non-commercial And/Or education use only.
'   
'

Public Delegate Sub PositionChangedEvent(e As ZoomPanelCoordinatesChangedArgs)
Public Delegate Sub ZoomChangedEvent(e As EventArgs)

Public Class ZoomPanel
    Private FCanvasSize As Size
    Private FImage As Bitmap
    Private FImageCopy As Bitmap
    Private FInterpolationMode As InterpolationMode
    Private FMode As ZoomPanelMode
    Private FMouseDown As Boolean
    Private FMousePoint As Point
    Private FPenColor As Color
    Private FRectHeight As Integer
    Private FRectWidth As Integer
    Private FZoom As Double

    Private Sub CalcMousePosition(MouseX As Integer, MouseY As Integer)
        Dim X As Integer
        Dim Y As Integer

        If FImage Is Nothing Then
            X = 0
            Y = 0
        Else
            Dim Width = FCanvasSize.Width * Zoom
            If MouseX > Width Then
                X = Width
            Else
                X = MouseX
            End If

            Dim Height = FCanvasSize.Height * Zoom
            If MouseY > Height Then
                Y = Height
            Else
                Y = MouseY
            End If
        End If
        DoPositionChanged(X, Y)
    End Sub

    Private Sub CalcRectangles(ByRef SrcRect As Rectangle, ByRef DstRect As Rectangle)
        Dim Pt As Point
        If FCanvasSize.Width * FZoom < FRectWidth And FCanvasSize.Height * FZoom < FRectHeight Then
            Pt = New Point(0, 0)
        Else
            Pt = New Point(sbHorizontal.Value / FZoom, sbVertical.Value / FZoom)
        End If

        SrcRect = New Rectangle(Pt, New Size(FRectWidth / FZoom, FRectHeight / FZoom))
        DstRect = New Rectangle(-SrcRect.Width / 2, -SrcRect.Height / 2, SrcRect.Width, SrcRect.Height)
    End Sub

    Private Sub DisplayScrollbar()
        If FImage IsNot Nothing Then
            FCanvasSize = FImage.Size
        End If

        FRectHeight = Height
        If FRectWidth >= FCanvasSize.Width * FZoom Then
            sbHorizontal.Visible = False
        Else
            sbHorizontal.Visible = True
        End If

        FRectWidth = Width
        If FRectHeight >= FCanvasSize.Height * FZoom Then
            sbVertical.Visible = False
        Else
            sbVertical.Visible = True
        End If

        sbHorizontal.Location = New Point(0, Height - sbHorizontal.Height)
        sbHorizontal.Width = FRectWidth
        sbVertical.Location = New Point(Width - sbVertical.Width, 0)
        sbVertical.Height = FRectHeight

        UpdateCursor()
    End Sub

    Private Sub GetPointsForDraw(e As MouseEventArgs, ByRef StartPoint As Point, ByRef EndPoint As Point, ByRef Graph As Graphics)
        Dim X = FMousePoint.X / FZoom
        If sbHorizontal.Visible Then
            X += sbHorizontal.Value / FZoom
        End If
        Dim Y = FMousePoint.Y / FZoom
        If sbVertical.Visible Then
            Y += sbVertical.Value / FZoom
        End If
        StartPoint = New Point(X, Y)

        X = e.X / FZoom
        If sbHorizontal.Visible Then
            X += sbHorizontal.Value / FZoom
        End If
        Y = e.Y / FZoom
        If sbVertical.Visible Then
            Y += sbVertical.Value / FZoom
        End If
        EndPoint = New Point(X, Y)

        Graph = Graphics.FromImage(FImage)
    End Sub

    Private Sub SetScrollbarValues()
        sbVertical.Minimum = 0
        sbHorizontal.Minimum = 0

        If FCanvasSize.Width * FZoom > FRectWidth Then
            sbHorizontal.Maximum = FCanvasSize.Width * FZoom - FRectWidth
        End If
        If sbVertical.Visible Then
            sbHorizontal.Maximum += sbVertical.Width
        End If
        If sbHorizontal.Visible Then
            sbHorizontal.LargeChange = sbHorizontal.Maximum / 10
            sbHorizontal.SmallChange = sbHorizontal.Maximum / 20
            sbHorizontal.Maximum += sbHorizontal.LargeChange
        End If

        If FCanvasSize.Height * FZoom > FRectHeight Then
            sbVertical.Maximum = FCanvasSize.Height * FZoom - FRectHeight
        End If
        If sbHorizontal.Visible Then
            sbVertical.Maximum += sbHorizontal.Height
        End If
        If sbVertical.Visible Then
            sbVertical.LargeChange = sbVertical.Maximum / 10
            sbVertical.SmallChange = sbVertical.Maximum / 20
            sbVertical.Maximum += sbVertical.LargeChange
        End If
    End Sub

    Private Sub ScrollBarScroll(sender As Object, e As ScrollEventArgs)
        Invalidate()
    End Sub

    Private Sub UpdateCursor()
        If FImage Is Nothing Then
            Cursor = Cursors.Default
        Else
            Select Case FMode
                Case ZoomPanelMode.pmMove
                    If sbHorizontal.Visible Or sbVertical.Visible Then
                        Cursor = Cursors.Hand
                    Else
                        Cursor = Cursors.Default
                    End If

                Case ZoomPanelMode.pmPaint
                    Cursor = Cursors.Cross

                Case ZoomPanelMode.pmEarse
                    Cursor = Cursors.NoMove2D
            End Select
        End If
    End Sub

    Private Sub UseErase(e As MouseEventArgs)
        Dim StartPoint As Point
        Dim EndPoint As Point
        Dim Graph As Graphics = Nothing
        GetPointsForDraw(e, StartPoint, EndPoint, Graph)

        Dim X As Integer
        Dim Y As Integer
        If StartPoint.X > EndPoint.X Then
            X = EndPoint.X
            EndPoint.X = StartPoint.X
            StartPoint.X = X
        End If
        If StartPoint.Y > EndPoint.Y Then
            Y = EndPoint.Y
            EndPoint.Y = StartPoint.Y
            StartPoint.Y = Y
        End If

        If StartPoint.X = EndPoint.X Then
            EndPoint.X += 10
        End If
        If StartPoint.Y = EndPoint.Y Then
            EndPoint.Y += 10
        End If
        Dim Rect = New Rectangle(StartPoint, New Size(EndPoint.X - StartPoint.X, EndPoint.Y - StartPoint.Y))
        Graph.DrawImage(FImageCopy, Rect, Rect, GraphicsUnit.Pixel)

        Invalidate()

        Graph.Dispose()
    End Sub

    Private Sub UseMove(e As MouseEventArgs)
        Dim Point = New Point(e.X, e.Y)
        Dim Changed As Boolean = False

        Dim NewVal As Integer
        If sbVertical.Visible Then
            NewVal = sbVertical.Value + (FMousePoint.Y - Point.Y)
            If NewVal >= sbVertical.Minimum And NewVal <= sbVertical.Maximum Then
                sbVertical.Value = NewVal
                Changed = True
            End If
        End If

        If sbHorizontal.Visible Then
            NewVal = sbHorizontal.Value + (FMousePoint.X - Point.X)
            If NewVal >= sbHorizontal.Minimum And NewVal <= sbHorizontal.Maximum Then
                sbHorizontal.Value = NewVal
                Changed = True
            End If
        End If

        If Changed Then
            Invalidate()
        End If
    End Sub

    Private Sub UsePaint(e As MouseEventArgs)
        Dim StartPoint As Point
        Dim EndPoint As Point
        Dim Graph As Graphics = Nothing
        GetPointsForDraw(e, StartPoint, EndPoint, Graph)
        Graph.CompositingMode = CompositingMode.SourceCopy

        Dim Pen = New Pen(FPenColor)
        Graph.DrawLine(Pen, StartPoint, EndPoint)

        Invalidate()

        Graph.Dispose()
        Pen.Dispose()
    End Sub

    Protected Overrides Sub OnLoad(e As EventArgs)
        DisplayScrollbar()
        SetScrollbarValues()

        UpdateCursor()

        MyBase.OnLoad(e)
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        If FImage IsNot Nothing Then
            FMousePoint = New Point(e.X, e.Y)
            FMouseDown = True

            UpdateCursor()
        End If

        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        If FMouseDown Then
            Select Case FMode
                Case ZoomPanelMode.pmMove
                    UseMove(e)
                Case ZoomPanelMode.pmPaint
                    UsePaint(e)
                Case ZoomPanelMode.pmEarse
                    UseErase(e)
            End Select
            FMousePoint = New Point(e.X, e.Y)
        End If

        CalcMousePosition(e.X, e.Y)

        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        FMouseDown = False
        FMousePoint = Nothing

        UpdateCursor()

        MyBase.OnMouseUp(e)
    End Sub

    Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)
        MyBase.OnMouseWheel(e)

        Dim OldZoom As Double = FZoom
        If e.Delta > 0 Then
            OldZoom += 0.02!
        Else
            If OldZoom > 0.06! Then
                OldZoom -= 0.02!
            End If
        End If

        If OldZoom <> FZoom Then
            Zoom = OldZoom
        End If
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        If FImage IsNot Nothing Then
            Dim SrcRect As Rectangle
            Dim DstRect As Rectangle
            CalcRectangles(SrcRect, DstRect)

            Dim Mx = New Matrix()
            Mx.Scale(FZoom, FZoom)
            Mx.Translate(FRectWidth / 2.0!, FRectHeight / 2.0!, MatrixOrder.Append)

            Dim Graph = e.Graphics
            Graph.InterpolationMode = FInterpolationMode
            Graph.Transform = Mx
            Graph.DrawImage(FImage, DstRect, SrcRect, GraphicsUnit.Pixel)
        End If
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        DisplayScrollbar()
        SetScrollbarValues()

        MyBase.OnResize(e)
    End Sub

    Protected Overridable Sub DoPositionChanged(X As Integer, Y As Integer)
        RaiseEvent PositionChanged(New ZoomPanelCoordinatesChangedArgs(X, Y))
    End Sub

    Protected Overridable Sub DoZoomChanged()
        RaiseEvent ZoomChanged(New EventArgs())
    End Sub

    Public Sub New()
        FCanvasSize = New Size(60, 40)
        FImage = Nothing
        FImageCopy = Nothing
        FInterpolationMode = InterpolationMode.HighQualityBilinear
        FMode = ZoomPanelMode.pmMove
        FMouseDown = False
        FMousePoint = Nothing
        FPenColor = Color.Black
        FRectHeight = 0
        FRectWidth = 0
        FZoom = 1.0!

        InitializeComponent()

        AddHandler sbVertical.Scroll, AddressOf ScrollBarScroll
        AddHandler sbHorizontal.Scroll, AddressOf ScrollBarScroll

        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or
                 ControlStyles.ResizeRedraw Or ControlStyles.UserPaint Or
                 ControlStyles.DoubleBuffer, True)
        Me.Cursor = Cursors.Default
    End Sub

    Public Property CanvasSize As Size
        Get
            Return FCanvasSize
        End Get

        Set(Value As Size)
            FCanvasSize = Value

            DisplayScrollbar()
            SetScrollbarValues()

            Invalidate()
        End Set
    End Property

    Public Property PenColor As Color
        Get
            Return FPenColor
        End Get

        Set(Value As Color)
            FPenColor = Value
        End Set
    End Property

    Public Property Image As Bitmap
        Get
            Return FImage
        End Get

        Set(Value As Bitmap)
            If FImage IsNot Nothing Then
                FImage.Dispose()
                FImageCopy.Dispose()
            End If

            FImage = Value
            If Value Is Nothing Then
                FImageCopy = Nothing
            Else
                FImageCopy = New Bitmap(Value)
            End If

            DisplayScrollbar()
            SetScrollbarValues()

            Invalidate()
        End Set
    End Property

    Public Property InterpolationMode As InterpolationMode
        Get
            Return FInterpolationMode
        End Get

        Set(Value As InterpolationMode)
            FInterpolationMode = Value
        End Set
    End Property

    Public Property Mode As ZoomPanelMode
        Get
            Return FMode
        End Get

        Set(Value As ZoomPanelMode)
            If Value <> FMode Then
                FMode = Value
                UpdateCursor()
            End If
        End Set
    End Property

    Public Property Zoom As Double
        Get
            Return FZoom
        End Get

        Set(Value As Double)
            If Value < 0.001! Then
                Value = 0.001!
            End If

            If Value <> FZoom Then
                FZoom = Value

                DisplayScrollbar()
                SetScrollbarValues()

                Invalidate()

                DoZoomChanged()
            End If
        End Set
    End Property

    Public Event PositionChanged As PositionChangedEvent
    Public Event ZoomChanged As ZoomChangedEvent
End Class
