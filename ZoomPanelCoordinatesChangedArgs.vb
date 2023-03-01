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

Public Class ZoomPanelCoordinatesChangedArgs
    Inherits EventArgs

    Private ReadOnly FX As Integer
    Private ReadOnly FY As Integer

    Public Sub New(X As Integer, Y As Integer)
        FX = X
        FY = Y
    End Sub

    Public ReadOnly Property X As Integer
        Get
            Return FX
        End Get
    End Property

    Public ReadOnly Property Y As Integer
        Get
            Return FY
        End Get
    End Property
End Class
