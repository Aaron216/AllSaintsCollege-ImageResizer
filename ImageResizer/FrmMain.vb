Imports System.Drawing.Imaging
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading

Public Class FrmMain
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateWindow()
    End Sub

    ' Text Input lost focus
    Private Sub TxbOpen_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxbOpen.LostFocus
        Settings.getInstance.SourceFolder = TxbOpen.Text
        UpdateWindow()
    End Sub

    Private Sub TxbSave_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxbSave.LostFocus
        Settings.getInstance.SaveFolder = TxbOpen.Text
        UpdateWindow()
    End Sub

    Private Sub TxbWidth_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxbWidth.LostFocus
        Settings.getInstance.DesiredWidth = Integer.Parse(TxbWidth.Text)

    End Sub

    Private Sub TxbHeight_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxbHeight.LostFocus
        Settings.getInstance.DesiredHeigth = Integer.Parse(TxbHeight.Text)
    End Sub

    ' Ensure numerical input only
    Private Sub TxbWidth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxbWidth.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxbWidth_TextChanged(sender As Object, e As EventArgs) Handles TxbWidth.TextChanged
        Dim digitsOnly As Regex = New Regex("[^\d]")
        Try
            TxbWidth.Text = digitsOnly.Replace(TxbWidth.Text, "")
        Catch ex As Exception
            MessageBox.Show("An error occurred during input validation." & vbNewLine & ex.Message)
        End Try
    End Sub

    Private Sub TxbHeight_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxbHeight.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxbHeight_TextChanged(sender As Object, e As EventArgs) Handles TxbHeight.TextChanged
        Dim digitsOnly As Regex = New Regex("[^\d]")
        Try
            TxbHeight.Text = digitsOnly.Replace(TxbHeight.Text, "")
        Catch ex As Exception
            MessageBox.Show("An error occurred during input validation." & vbNewLine & ex.Message)
        End Try
    End Sub

    ' Buttons
    Private Sub BtnOpen_Click(sender As Object, e As EventArgs) Handles BtnOpen.Click
        Dim folderBrowser As FolderBrowserDialog = New FolderBrowserDialog With {
            .Description = "Select folder to open images from.",
            .SelectedPath = TxbOpen.Text,
            .ShowNewFolderButton = False
        }

        If folderBrowser.ShowDialog() = DialogResult.OK Then
            TxbOpen.Text = folderBrowser.SelectedPath
            Settings.getInstance.SourceFolder = folderBrowser.SelectedPath
        End If

        UpdateWindow()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim folderBrowser As FolderBrowserDialog = New FolderBrowserDialog With {
            .Description = "Select folder to save images to.",
            .SelectedPath = TxbSave.Text
        }

        If folderBrowser.ShowDialog() = DialogResult.OK Then
            TxbSave.Text = folderBrowser.SelectedPath
            Settings.getInstance.SaveFolder = folderBrowser.SelectedPath
        End If

        UpdateWindow()
    End Sub

    Private Sub BtnProcess_Click(sender As Object, e As EventArgs) Handles BtnProcess.Click
        ' Disable Button
        BtnProcess.Enabled = False
        Cursor = Cursors.WaitCursor

        ' Declare Variables
        Dim filePaths() As String = FileIO.ScanFolder(Settings.getInstance.SourceFolder)

        Try
            ' Check to see if save folder exists
            If Not Directory.Exists(Settings.getInstance.SaveFolder) Then
                ' Create folder if needed
                Directory.CreateDirectory(Settings.getInstance.SaveFolder)
            End If

            Dim numThreads As Integer = Environment.ProcessorCount
            Debug.WriteLine($"Number of threads: {numThreads}")

            Dim threads(numThreads) As Thread
            For ii As Integer = 0 To numThreads
                threads(ii) = New Thread(AddressOf ThreadWork)
                threads(ii).Start()
            Next

            ' Parallel.ForEach(filePaths, Sub(currFilePath) ProcessImage(currFilePath))
        Catch ex As Exception
            MessageBox.Show("An error occured while processing images." & vbNewLine & ex.Message)
        Finally
            Cursor = Cursors.Default
            UpdateWindow()
        End Try
    End Sub

    ' Check boxes
    Private Sub CkbResize_CheckedChanged(sender As Object, e As EventArgs) Handles CkbResize.CheckedChanged
        Settings.getInstance.Resize = CkbResize.Checked
        UpdateWindow()
    End Sub

    Private Sub CkbRotate_CheckedChanged(sender As Object, e As EventArgs) Handles CkbRotate.CheckedChanged
        Settings.getInstance.Rotate = CkbRotate.Checked
        UpdateWindow()
    End Sub

    Private Sub CkbSmaller_CheckedChanged(sender As Object, e As EventArgs) Handles CkbSmaller.CheckedChanged
        Settings.getInstance.ShrinkOnly = CkbSmaller.Checked
    End Sub

    Private Sub CkbIgnore_CheckedChanged(sender As Object, e As EventArgs) Handles CkbIgnore.CheckedChanged
        Settings.getInstance.IgnoreOrientation = CkbIgnore.Checked
    End Sub

    Private Sub CkbAspect_CheckedChanged(sender As Object, e As EventArgs) Handles CkbAspect.CheckedChanged
        Settings.getInstance.MaintainAspect = CkbAspect.Checked
    End Sub

    ' Private functions
    Private Sub UpdateWindow()
        Dim numImages As Integer = FileIO.CountFiles(Settings.getInstance.SourceFolder)
        Dim enableResize As Boolean = Settings.getInstance.Resize

        TxbHeight.Enabled = enableResize
        TxbWidth.Enabled = enableResize
        CkbAspect.Enabled = enableResize
        CkbIgnore.Enabled = enableResize
        CkbSmaller.Enabled = enableResize
        LblSize.Enabled = enableResize
        LblTimes.Enabled = enableResize
        LblPixels.Enabled = enableResize

        If Not Directory.Exists(Settings.getInstance.SourceFolder) Then
            LblFound.Text = "Folder not found."
        ElseIf numImages <= 0 Then
            LblFound.Text = "No images found."
        ElseIf numImages = 0 Then
            LblFound.Text = "1 image found."
        Else
            LblFound.Text = numImages & " images found."
        End If

        ProgressBar.Maximum = numImages
        ProgressBar.Value = ProgressBar.Minimum

        BtnProcess.Enabled = Settings.getInstance.Ready() And numImages > 0
    End Sub

    Private Sub ThreadWork()
        Debug.Write("Hello" + vbNewLine)
    End Sub

End Class
