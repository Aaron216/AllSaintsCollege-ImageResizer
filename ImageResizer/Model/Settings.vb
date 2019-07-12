Imports System.IO

Public Class Settings
    ' Declare Fields
    Private _sourceFolder As String
    Private _saveFolder As String
    Private _rotate As Boolean
    Private _resize As Boolean
    Private _desiredWidth As Integer
    Private _desiredHeigth As Integer
    Private _shrinkOnly As Boolean
    Private _ignoreOrientation As Boolean
    Private _maintainAspect As Boolean
    Private Shared _instance As Settings

    ' Constructor
    Private Sub New()
        _sourceFolder = ""
        _saveFolder = ""
        _rotate = False
        _resize = False
        _desiredWidth = 0
        _desiredHeigth = 0
        _shrinkOnly = True
        _ignoreOrientation = True
        _maintainAspect = True
    End Sub

    Public Shared Function getInstance() As Settings
        If _instance Is Nothing Then
            _instance = New Settings()
        End If
        Return _instance
    End Function

    Public Property SourceFolder As String
        Get
            Return _sourceFolder
        End Get
        Set(value As String)
            _sourceFolder = value
        End Set
    End Property

    Public Property SaveFolder As String
        Get
            Return _saveFolder
        End Get
        Set(value As String)
            _saveFolder = value
        End Set
    End Property

    Public Property Rotate As Boolean
        Get
            Return _rotate
        End Get
        Set(value As Boolean)
            _rotate = value
        End Set
    End Property

    Public Property Resize As Boolean
        Get
            Return _resize
        End Get
        Set(value As Boolean)
            _resize = value
        End Set
    End Property

    Public Property DesiredWidth As Integer
        Get
            Return _desiredWidth
        End Get
        Set(value As Integer)
            If value < 1 Then
                Throw New ArgumentOutOfRangeException("Desiered width")
            End If
            _desiredWidth = value
        End Set
    End Property

    Public Property DesiredHeigth As Integer
        Get
            Return _desiredHeigth
        End Get
        Set(value As Integer)
            If value < 1 Then
                Throw New ArgumentOutOfRangeException("Desired Height")
            End If
            _desiredWidth = value
        End Set
    End Property

    Public Property ShrinkOnly As Boolean
        Get
            Return _shrinkOnly
        End Get
        Set(value As Boolean)
            _shrinkOnly = value
        End Set
    End Property

    Public Property IgnoreOrientation As Boolean
        Get
            Return _ignoreOrientation
        End Get
        Set(value As Boolean)
            _ignoreOrientation = value
        End Set
    End Property

    Public Property MaintainAspect As Boolean
        Get
            Return _maintainAspect
        End Get
        Set(value As Boolean)
            _maintainAspect = value
        End Set
    End Property

    Public Function Ready() As Boolean
        Return _
            (Rotate Or Resize) _
            And Not (String.IsNullOrWhiteSpace(SourceFolder) Or String.IsNullOrWhiteSpace(SaveFolder)) _
            And Directory.Exists(SourceFolder)
    End Function

End Class
