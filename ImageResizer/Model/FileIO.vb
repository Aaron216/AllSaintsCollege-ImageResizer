Imports System.IO

Public Class FileIO
    ' Global Constants
    ' Supports: BMP, GIF, JPEG, PNG, TIFF
    Private Const SEARCH_PATTERN As String = "*.jpg"

    Public Shared Function ScanFolder(folderPath As String) As String()
        Dim filePaths() As String = {}

        If Not String.IsNullOrEmpty(folderPath) And Directory.Exists(folderPath) Then
            Try
                filePaths = IO.Directory.GetFiles(folderPath, SEARCH_PATTERN)
            Catch ex As Exception
                MessageBox.Show("An error occured while atempting to open the folder." & vbNewLine & ex.Message)
            End Try
        End If

        Return filePaths
    End Function

    Public Shared Function CountFiles(folderPath As String) As Integer
        Return ScanFolder(folderPath).Count
    End Function

    Public Shared Function openImage(filePath As String) As Image

    End Function

    Public Shared Sub SaveImage(image As Image, filePath As String)

    End Sub
End Class
