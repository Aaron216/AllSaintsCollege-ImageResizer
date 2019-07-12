Imports System.Drawing.Imaging
Imports System.IO

''' <summary>
''' 
''' All Saints' College
''' Image Rotate and Resize Tool
''' Picture Class
''' 
''' By Aaron Musgrave
''' 
''' </summary>

Public Class Picture
    ' Declare Constants
    Private Const PROPERTY_INDEX As Integer = 274
    Private Const UPSIDE_DOWN As Integer = 3
    Private Const UPSIDE_LEFT As Integer = 6
    Private Const UPSIDE_RIGHT As Integer = 8

    ' Declare Fields
    Private _originPath As String
    Private _savePath As String
    Private _fileName As String
    Private _photo As Image
    ' Private orientationVal As Integer
    ' Private portraitVal As Boolean

    Public Property OriginPath As String
        Get
            Return _originPath
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentNullException("Origin path")
            End If
            _originPath = value
        End Set
    End Property

    Public Property SavePath As String
        Get
            Return _savePath
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentNullException("Save path")
            End If
            _savePath = value
        End Set
    End Property

    Public Property FileName As String
        Get
            Return _fileName
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then
                Throw New ArgumentNullException("File name")
            End If
            _fileName = value
        End Set
    End Property

    'Public Property Orientation As Integer
    '    Get
    '        Return orientationVal
    '    End Get
    '    Set(value As Integer)
    '        orientationVal = value
    '    End Set
    'End Property

    'Public Property Portrait As Boolean
    '    Get
    '        Return portraitVal
    '    End Get
    '    Set(value As Boolean)
    '        portraitVal = value
    '    End Set
    'End Property

    Public Property Photo As Image
        Get
            Return _photo
        End Get
        Set(value As Image)
            _photo = value
        End Set
    End Property

    ' Constructors
    Public Sub New()
        _originPath = ""
        _savePath = ""
        _fileName = ""
        'orientationVal = 0
        'portraitVal = False
        _photo = Nothing
    End Sub

    Public Sub New(filePath As String)
        OriginPath = filePath
        FileName = Path.GetFileName(filePath)
        SavePath = Path.Combine(Settings.getInstance.SaveFolder, FileName)
        Photo = Image.FromFile(filePath)
    End Sub

    ' Sub modules
    Public Sub Process()
        If Settings.getInstance.Rotate Then
            RotateImage()
        End If

        If Settings.getInstance.Resize Then
            ResizeImage()
        End If
    End Sub

    Public Sub Dispose()
        _originPath = Nothing
        _savePath = Nothing
        _fileName = Nothing
        _photo.Dispose()
        _photo = Nothing
    End Sub

    ' Private Sub modules
    Private Sub RotateImage()
        Dim propertyItem As PropertyItem
        Dim orientation As Integer

        Try
            propertyItem = Photo.GetPropertyItem(PROPERTY_INDEX)
            orientation = BitConverter.ToInt16(propertyItem.Value, 0)
        Catch ex As Exception
            orientation = 0
        End Try

        Select Case orientation
            Case UPSIDE_DOWN
                Photo.RotateFlip(RotateFlipType.Rotate180FlipNone)
            Case UPSIDE_LEFT
                Photo.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Case UPSIDE_RIGHT
                Photo.RotateFlip(RotateFlipType.Rotate270FlipNone)
        End Select

    End Sub

    Private Sub ResizeImage()
        ' Get dimensions
        Dim desiredSize() As Integer = {Settings.getInstance.DesiredWidth, Settings.getInstance.DesiredHeigth}
        Dim originalSize() As Integer = {Photo.Width, Photo.Height}
        Dim portrait As Boolean = Photo.Width < Photo.Height And Settings.getInstance.IgnoreOrientation

        ' Check aspect ratio
        If Settings.getInstance.MaintainAspect Then
            Dim aspectRatio As Double = originalSize.Max / originalSize.Min
            ' desiredWidth = desiredHeight * aspectRatio
        End If

        ' Check to see if image is smaller than desiered size
        If Not (originalSize.Min < desiredSize.Min And Settings.getInstance.ShrinkOnly) Then
            Try
                ' Convert to bitmap
                Dim bitmapSource As New Bitmap(Photo)

                ' Create destination bitmap
                Dim bitmapDestination As Bitmap
                If portrait Then
                    'bitmapDestination = New Bitmap(desiredHeight, desiredWidth)
                Else
                    'bitmapDestination = New Bitmap(desiredWidth, desiredHeight)
                End If


                ' Make graphics object for the result bitmap
                Dim graphicDestination As Graphics = Graphics.FromImage(bitmapDestination)

                ' Copy source image into destination bitmap
                graphicDestination.DrawImage(bitmapSource, 0, 0,
                    bitmapDestination.Width + 1, bitmapDestination.Height + 1)

                ' Copy bitmap back to image
                Photo = bitmapDestination

                ' Dispose of variables no longer needed
                bitmapSource.Dispose()
                graphicDestination.Dispose()
            Catch ex As Exception
                MessageBox.Show("Error resizing image." & vbNewLine & ex.Message)
            End Try
        End If
    End Sub
End Class
