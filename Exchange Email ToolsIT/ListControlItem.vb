﻿Imports System.Drawing.Drawing2D

Public Class ListControlItem

    Public Event SelectionChanged(sender As Object)

    Friend WithEvents tmrMouseLeave As New System.Windows.Forms.Timer With {.Interval = 10}

#Region "Properties"

    Dim mImage As Image
    Public Property Image() As Image
        Get
            Return mImage
        End Get
        Set(ByVal value As Image)
            mImage = value
            Refresh()
        End Set
    End Property
    Dim folderr As String
    Public Property folder() As String
        Get
            Return folderr
        End Get
        Set(ByVal value As String)
            folderr = value
            Refresh()
        End Set
    End Property

    Dim mfrom As String = "[from]"
    Public Property from() As String
        Get
            Return mfrom
        End Get
        Set(ByVal value As String)
            mfrom = value
            Refresh()
        End Set
    End Property

    Dim msubject As String = "[subject]"
    Public Property subject() As String
        Get
            Return msubject
        End Get
        Set(ByVal value As String)
            msubject = value
            Refresh()
        End Set
    End Property

    Dim mdisplayto As String = "[displayto]"
    Public Property displayto() As String
        Get
            Return mdisplayto
        End Get
        Set(ByVal value As String)
            mdisplayto = value
            Refresh()
        End Set
    End Property
    Dim midmessage As String = ""
    Public Property idmessage() As String
        Get
            Return midmessage
        End Get
        Set(ByVal value As String)
            midmessage = value
            Refresh()
        End Set
    End Property
    Dim mmessagebody As String = ""
    Public Property Messagebody() As String
        Get
            Return mmessagebody
        End Get
        Set(ByVal value As String)
            mmessagebody = value
            Refresh()
        End Set
    End Property

    Dim mDuration As String
    Public Property Duration() As String
        Get
            Return lblDuration.Text
        End Get
        Set(ByVal value As String)
            lblDuration.Text = value
        End Set
    End Property

    Private mSelected As Boolean
    Public Property Selected() As Boolean
        Get
            Return mSelected
        End Get
        Set(ByVal value As Boolean)
            mSelected = value
            Refresh()
        End Set
    End Property

    Public Property Rating() As Integer
        Get
            Return RatingBar1.Stars
        End Get
        Set(ByVal value As Integer)
            RatingBar1.Stars = value
        End Set
    End Property


#End Region

#Region "Mouse coding"

    Private Enum MouseCapture
        Outside
        Inside
    End Enum
    Private Enum ButtonState
        ButtonUp
        ButtonDown
        Disabled
    End Enum
    Dim bState As ButtonState
    Dim bMouse As MouseCapture

    Private Sub ListControlItem_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        If Selected = False Then
            Selected = True
            RaiseEvent SelectionChanged(Me)
        End If
    End Sub

    Private Sub metroRadioGroup_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown ', rdButton.MouseDown
        bState = ButtonState.ButtonDown
        Refresh()
    End Sub

    Private Sub metroRadioGroup_MouseEnter(sender As Object, e As System.EventArgs) Handles Me.MouseEnter
        bMouse = MouseCapture.Inside
        tmrMouseLeave.Start()
        Refresh()
    End Sub

    Private Sub metroRadioGroup_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp ', rdButton.MouseUp
        bState = ButtonState.ButtonUp
        Refresh()
    End Sub

    Private Sub tmrMouseLeave_Tick(sender As System.Object, e As System.EventArgs) Handles tmrMouseLeave.Tick
        Try
            Dim scrPT = Control.MousePosition
            Dim ctlPT As Point = Me.PointToClient(scrPT)
            '
            If ctlPT.X < 0 Or ctlPT.Y < 0 Or ctlPT.X > Me.Width Or ctlPT.Y > Me.Height Then
                ' Stop timer
                tmrMouseLeave.Stop()
                bMouse = MouseCapture.Outside
                Refresh()
            Else
                bMouse = MouseCapture.Inside
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region

#Region "Painting"

    Private Sub Paint_DrawBackground(gfx As Graphics)
        '
        Try
            Dim rect As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)

            '/// Build a rounded rectangle
            Dim p As New GraphicsPath
            Const Roundness = 5
            p.StartFigure()
            p.AddArc(New Rectangle(rect.Left, rect.Top, Roundness, Roundness), 180, 90)
            p.AddLine(rect.Left + Roundness, 0, rect.Right - Roundness, 0)
            p.AddArc(New Rectangle(rect.Right - Roundness, 0, Roundness, Roundness), -90, 90)
            p.AddLine(rect.Right, Roundness, rect.Right, rect.Bottom - Roundness)
            p.AddArc(New Rectangle(rect.Right - Roundness, rect.Bottom - Roundness, Roundness, Roundness), 0, 90)
            p.AddLine(rect.Right - Roundness, rect.Bottom, rect.Left + Roundness, rect.Bottom)
            p.AddArc(New Rectangle(rect.Left, rect.Height - Roundness, Roundness, Roundness), 90, 90)
            p.CloseFigure()


            '/// Draw the background ///
            Dim ColorScheme As Color() = Nothing
            Dim brdr As SolidBrush = Nothing

            If bState = ButtonState.Disabled Then
                ' normal
                brdr = ColorSchemes.DisabledBorder
                ColorScheme = ColorSchemes.DisabledAllColor
            Else
                If mSelected Then
                    ' Selected
                    brdr = ColorSchemes.SelectedBorder

                    If bState = ButtonState.ButtonUp And bMouse = MouseCapture.Outside Then
                        ' normal
                        ColorScheme = ColorSchemes.SelectedNormal

                    ElseIf bState = ButtonState.ButtonUp And bMouse = MouseCapture.Inside Then
                        '  hover 
                        ColorScheme = ColorSchemes.SelectedHover

                    ElseIf bState = ButtonState.ButtonDown And bMouse = MouseCapture.Outside Then
                        ' no one cares!
                        Exit Sub
                    ElseIf bState = ButtonState.ButtonDown And bMouse = MouseCapture.Inside Then
                        ' pressed
                        ColorScheme = ColorSchemes.SelectedPressed
                    End If

                Else
                    ' Not selected
                    brdr = ColorSchemes.UnSelectedBorder

                    If bState = ButtonState.ButtonUp And bMouse = MouseCapture.Outside Then
                        ' normal
                        brdr = ColorSchemes.DisabledBorder
                        ColorScheme = ColorSchemes.UnSelectedNormal

                    ElseIf bState = ButtonState.ButtonUp And bMouse = MouseCapture.Inside Then
                        '  hover 
                        ColorScheme = ColorSchemes.UnSelectedHover

                    ElseIf bState = ButtonState.ButtonDown And bMouse = MouseCapture.Outside Then
                        ' no one cares!
                        Exit Sub
                    ElseIf bState = ButtonState.ButtonDown And bMouse = MouseCapture.Inside Then
                        ' pressed
                        ColorScheme = ColorSchemes.UnSelectedPressed
                    End If

                End If
            End If

            ' Draw
            Dim b As LinearGradientBrush = New LinearGradientBrush(rect, Color.White, Color.Black, LinearGradientMode.Vertical)
            Dim blend As ColorBlend = New ColorBlend
            blend.Colors = ColorScheme
            blend.Positions = New Single() {0.0F, 0.1, 0.9F, 0.95F, 1.0F}
            b.InterpolationColors = blend
            gfx.FillPath(b, p)

            '// Draw border
            gfx.DrawPath(New Pen(brdr), p)

            '// Draw bottom border if Normal state (not hovered)
            If bMouse = MouseCapture.Outside Then
                rect = New Rectangle(rect.Left, Me.Height - 1, rect.Width, 1)
                b = New LinearGradientBrush(rect, Color.Blue, Color.Yellow, LinearGradientMode.Horizontal)
                blend = New ColorBlend
                blend.Colors = New Color() {Color.White, Color.LightGray, Color.White}
                blend.Positions = New Single() {0.0F, 0.5F, 1.0F}
                b.InterpolationColors = blend
                '
                gfx.FillRectangle(b, rect)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Paint_DrawButton(gfx As Graphics)
        Try
            Dim fnt As Font = Nothing
            Dim sz As SizeF = Nothing
            Dim layoutRect As RectangleF
            Dim SF As New StringFormat With {.Trimming = StringTrimming.EllipsisCharacter}
            Dim workingRect As New Rectangle(40, 0, RatingBar1.Left - 40 - 6, Me.Height)

            ' Draw song name
            fnt = New Font("Segoe UI Light", 14)
            sz = gfx.MeasureString(mfrom, fnt)
            layoutRect = New RectangleF(40, 0, workingRect.Width, sz.Height)
            gfx.DrawString(mfrom, fnt, Brushes.Black, layoutRect, SF)

            ' Draw artist name
            fnt = New Font("Segoe UI Light", 10)
            sz = gfx.MeasureString(msubject, fnt)
            layoutRect = New RectangleF(42, 30, workingRect.Width, sz.Height)
            gfx.DrawString(msubject, fnt, Brushes.Black, layoutRect, SF)

            ' Draw album name
            fnt = New Font("Segoe UI Light", 10)
            sz = gfx.MeasureString(mdisplayto, fnt)
            layoutRect = New RectangleF(42, 49, workingRect.Width, sz.Height)
            gfx.DrawString(mdisplayto, fnt, Brushes.Black, layoutRect, SF)

            ' Album Image
            If mImage IsNot Nothing Then
                gfx.DrawImage(mImage, New Point(7, 7))
            Else
                gfx.DrawImage(ImageList1.Images(0), New Point(7, 7))
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PaintEvent(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Try
            Dim gfx = e.Graphics
            '
            Paint_DrawBackground(gfx)
            Paint_DrawButton(gfx)
        Catch ex As Exception
        End Try
    End Sub

#End Region


 

    Private Sub ListControlItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
