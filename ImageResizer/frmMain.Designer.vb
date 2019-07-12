<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.BtnOpen = New System.Windows.Forms.Button()
        Me.LblFound = New System.Windows.Forms.Label()
        Me.CkbRotate = New System.Windows.Forms.CheckBox()
        Me.CkbResize = New System.Windows.Forms.CheckBox()
        Me.LblTimes = New System.Windows.Forms.Label()
        Me.TxbWidth = New System.Windows.Forms.TextBox()
        Me.TxbHeight = New System.Windows.Forms.TextBox()
        Me.LblSize = New System.Windows.Forms.Label()
        Me.LblPixels = New System.Windows.Forms.Label()
        Me.BtnProcess = New System.Windows.Forms.Button()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.LblOpen = New System.Windows.Forms.Label()
        Me.LblSave = New System.Windows.Forms.Label()
        Me.TxbOpen = New System.Windows.Forms.TextBox()
        Me.TxbSave = New System.Windows.Forms.TextBox()
        Me.CkbSmaller = New System.Windows.Forms.CheckBox()
        Me.CkbIgnore = New System.Windows.Forms.CheckBox()
        Me.CkbAspect = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'BtnOpen
        '
        Me.BtnOpen.Location = New System.Drawing.Point(197, 23)
        Me.BtnOpen.Name = "BtnOpen"
        Me.BtnOpen.Size = New System.Drawing.Size(75, 23)
        Me.BtnOpen.TabIndex = 2
        Me.BtnOpen.Text = "Browse"
        Me.BtnOpen.UseVisualStyleBackColor = True
        '
        'LblFound
        '
        Me.LblFound.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFound.Location = New System.Drawing.Point(12, 49)
        Me.LblFound.Name = "LblFound"
        Me.LblFound.Size = New System.Drawing.Size(260, 15)
        Me.LblFound.TabIndex = 1
        Me.LblFound.Text = "No images found."
        Me.LblFound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CkbRotate
        '
        Me.CkbRotate.AutoSize = True
        Me.CkbRotate.Location = New System.Drawing.Point(12, 120)
        Me.CkbRotate.Name = "CkbRotate"
        Me.CkbRotate.Size = New System.Drawing.Size(175, 17)
        Me.CkbRotate.TabIndex = 5
        Me.CkbRotate.Text = "Correct the orienation of images"
        Me.CkbRotate.UseVisualStyleBackColor = True
        '
        'CkbResize
        '
        Me.CkbResize.AutoSize = True
        Me.CkbResize.Location = New System.Drawing.Point(12, 143)
        Me.CkbResize.Name = "CkbResize"
        Me.CkbResize.Size = New System.Drawing.Size(94, 17)
        Me.CkbResize.TabIndex = 6
        Me.CkbResize.Text = "Resize images"
        Me.CkbResize.UseVisualStyleBackColor = True
        '
        'LblTimes
        '
        Me.LblTimes.AutoSize = True
        Me.LblTimes.Enabled = False
        Me.LblTimes.Location = New System.Drawing.Point(134, 169)
        Me.LblTimes.Name = "LblTimes"
        Me.LblTimes.Size = New System.Drawing.Size(13, 13)
        Me.LblTimes.TabIndex = 5
        Me.LblTimes.Text = "×"
        '
        'TxbWidth
        '
        Me.TxbWidth.Enabled = False
        Me.TxbWidth.Location = New System.Drawing.Point(48, 166)
        Me.TxbWidth.Name = "TxbWidth"
        Me.TxbWidth.Size = New System.Drawing.Size(80, 20)
        Me.TxbWidth.TabIndex = 7
        Me.TxbWidth.Text = "4000"
        Me.TxbWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxbHeight
        '
        Me.TxbHeight.Enabled = False
        Me.TxbHeight.Location = New System.Drawing.Point(153, 166)
        Me.TxbHeight.Name = "TxbHeight"
        Me.TxbHeight.Size = New System.Drawing.Size(80, 20)
        Me.TxbHeight.TabIndex = 8
        Me.TxbHeight.Text = "3000"
        Me.TxbHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblSize
        '
        Me.LblSize.AutoSize = True
        Me.LblSize.Enabled = False
        Me.LblSize.Location = New System.Drawing.Point(12, 169)
        Me.LblSize.Name = "LblSize"
        Me.LblSize.Size = New System.Drawing.Size(30, 13)
        Me.LblSize.TabIndex = 8
        Me.LblSize.Text = "Size:"
        '
        'LblPixels
        '
        Me.LblPixels.AutoSize = True
        Me.LblPixels.Enabled = False
        Me.LblPixels.Location = New System.Drawing.Point(239, 169)
        Me.LblPixels.Name = "LblPixels"
        Me.LblPixels.Size = New System.Drawing.Size(33, 13)
        Me.LblPixels.TabIndex = 9
        Me.LblPixels.Text = "pixels"
        '
        'BtnProcess
        '
        Me.BtnProcess.Enabled = False
        Me.BtnProcess.Location = New System.Drawing.Point(12, 290)
        Me.BtnProcess.Name = "BtnProcess"
        Me.BtnProcess.Size = New System.Drawing.Size(260, 23)
        Me.BtnProcess.TabIndex = 12
        Me.BtnProcess.Text = "Process"
        Me.BtnProcess.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(12, 261)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(260, 23)
        Me.ProgressBar.Step = 1
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar.TabIndex = 11
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(197, 85)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 4
        Me.BtnSave.Text = "Browse"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'LblOpen
        '
        Me.LblOpen.AutoSize = True
        Me.LblOpen.Location = New System.Drawing.Point(12, 9)
        Me.LblOpen.Name = "LblOpen"
        Me.LblOpen.Size = New System.Drawing.Size(137, 13)
        Me.LblOpen.TabIndex = 13
        Me.LblOpen.Text = "Folder to open images from:"
        '
        'LblSave
        '
        Me.LblSave.AutoSize = True
        Me.LblSave.Location = New System.Drawing.Point(12, 71)
        Me.LblSave.Name = "LblSave"
        Me.LblSave.Size = New System.Drawing.Size(125, 13)
        Me.LblSave.TabIndex = 14
        Me.LblSave.Text = "Folder to save images to:"
        '
        'TxbOpen
        '
        Me.TxbOpen.Location = New System.Drawing.Point(12, 25)
        Me.TxbOpen.Name = "TxbOpen"
        Me.TxbOpen.Size = New System.Drawing.Size(179, 20)
        Me.TxbOpen.TabIndex = 1
        '
        'TxbSave
        '
        Me.TxbSave.Location = New System.Drawing.Point(12, 87)
        Me.TxbSave.Name = "TxbSave"
        Me.TxbSave.Size = New System.Drawing.Size(179, 20)
        Me.TxbSave.TabIndex = 3
        '
        'CkbSmaller
        '
        Me.CkbSmaller.AutoSize = True
        Me.CkbSmaller.Checked = True
        Me.CkbSmaller.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkbSmaller.Enabled = False
        Me.CkbSmaller.Location = New System.Drawing.Point(12, 192)
        Me.CkbSmaller.Name = "CkbSmaller"
        Me.CkbSmaller.Size = New System.Drawing.Size(189, 17)
        Me.CkbSmaller.TabIndex = 9
        Me.CkbSmaller.Text = "Make images smaller but not larger"
        Me.CkbSmaller.UseVisualStyleBackColor = True
        '
        'CkbIgnore
        '
        Me.CkbIgnore.AutoSize = True
        Me.CkbIgnore.Checked = True
        Me.CkbIgnore.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkbIgnore.Enabled = False
        Me.CkbIgnore.Location = New System.Drawing.Point(12, 215)
        Me.CkbIgnore.Name = "CkbIgnore"
        Me.CkbIgnore.Size = New System.Drawing.Size(218, 17)
        Me.CkbIgnore.TabIndex = 10
        Me.CkbIgnore.Text = "Ignore orientation of images during resize"
        Me.CkbIgnore.UseVisualStyleBackColor = True
        '
        'CkbAspect
        '
        Me.CkbAspect.AutoSize = True
        Me.CkbAspect.Checked = True
        Me.CkbAspect.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkbAspect.Enabled = False
        Me.CkbAspect.Location = New System.Drawing.Point(12, 238)
        Me.CkbAspect.Name = "CkbAspect"
        Me.CkbAspect.Size = New System.Drawing.Size(160, 17)
        Me.CkbAspect.TabIndex = 11
        Me.CkbAspect.Text = "Maintain original aspect ratio"
        Me.CkbAspect.UseVisualStyleBackColor = True
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 325)
        Me.Controls.Add(Me.CkbAspect)
        Me.Controls.Add(Me.CkbIgnore)
        Me.Controls.Add(Me.CkbSmaller)
        Me.Controls.Add(Me.TxbSave)
        Me.Controls.Add(Me.TxbOpen)
        Me.Controls.Add(Me.LblSave)
        Me.Controls.Add(Me.LblOpen)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.BtnProcess)
        Me.Controls.Add(Me.LblPixels)
        Me.Controls.Add(Me.LblSize)
        Me.Controls.Add(Me.TxbHeight)
        Me.Controls.Add(Me.TxbWidth)
        Me.Controls.Add(Me.LblTimes)
        Me.Controls.Add(Me.CkbResize)
        Me.Controls.Add(Me.CkbRotate)
        Me.Controls.Add(Me.LblFound)
        Me.Controls.Add(Me.BtnOpen)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FrmMain"
        Me.Text = "Image Resizer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnOpen As Button
    Friend WithEvents LblFound As Label
    Friend WithEvents CkbRotate As CheckBox
    Friend WithEvents CkbResize As CheckBox
    Friend WithEvents LblTimes As Label
    Friend WithEvents TxbWidth As TextBox
    Friend WithEvents TxbHeight As TextBox
    Friend WithEvents LblSize As Label
    Friend WithEvents LblPixels As Label
    Friend WithEvents BtnProcess As Button
    Friend WithEvents ProgressBar As ProgressBar
    Friend WithEvents BtnSave As Button
    Friend WithEvents LblOpen As Label
    Friend WithEvents LblSave As Label
    Friend WithEvents TxbOpen As TextBox
    Friend WithEvents TxbSave As TextBox
    Friend WithEvents CkbSmaller As CheckBox
    Friend WithEvents CkbIgnore As CheckBox
    Friend WithEvents CkbAspect As CheckBox
End Class
