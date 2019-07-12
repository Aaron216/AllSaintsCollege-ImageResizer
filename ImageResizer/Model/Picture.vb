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
    Private _image As Image
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

    Public Property Image As Image
        Get
            Return _image
        End Get
        Set(value As Image)
            _image = value
        End Set
    End Property

    ' Constructors
    Public Sub New()
        _originPath = ""
        _savePath = ""
        _fileName = ""
        'orientationVal = 0
        'portraitVal = False
        _image = Nothing
    End Sub

    Public Sub New(filePath As String)
        OriginPath = filePath
        FileName = Path.GetFileName(filePath)
        SavePath = Path.Combine(Settings.getInstance.SaveFolder, FileName)
        Image = Image.FromFile(filePath)
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
        _image.Dispose()
        _image = Nothing
    End Sub

    ' Private Sub modules
    Private Sub RotateImage()
        Dim propertyItem As PropertyItem
        Dim orientation As Integer

        Try
            propertyItem = Image.GetPropertyItem(PROPERTY_INDEX)
            orientation = BitConverter.ToInt16(propertyItem.Value, 0)
        Catch ex As Exception
            orientation = 0
        End Try

        Select Case orientation
            Case UPSIDE_DOWN
                Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            Case UPSIDE_LEFT
                Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Case UPSIDE_RIGHT
                Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
        End Select

    End Sub

    Private Sub ResizeImage()

    End Sub
End Class
