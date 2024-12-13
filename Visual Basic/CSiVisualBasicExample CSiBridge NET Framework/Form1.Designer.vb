<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BtnOpen = New System.Windows.Forms.Button()
        Me.BtnAttach = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BtnOpenpath = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnOpen
        '
        Me.BtnOpen.Location = New System.Drawing.Point(12, 12)
        Me.BtnOpen.Name = "BtnOpen"
        Me.BtnOpen.Size = New System.Drawing.Size(75, 23)
        Me.BtnOpen.TabIndex = 0
        Me.BtnOpen.Text = "Open"
        Me.BtnOpen.UseVisualStyleBackColor = True
        '
        'BtnAttach
        '
        Me.BtnAttach.Location = New System.Drawing.Point(12, 41)
        Me.BtnAttach.Name = "BtnAttach"
        Me.BtnAttach.Size = New System.Drawing.Size(75, 23)
        Me.BtnAttach.TabIndex = 1
        Me.BtnAttach.Text = "Attach"
        Me.BtnAttach.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Location = New System.Drawing.Point(12, 70)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 23)
        Me.BtnClose.TabIndex = 2
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(102, 41)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BtnOpenpath
        '
        Me.BtnOpenpath.Location = New System.Drawing.Point(102, 12)
        Me.BtnOpenpath.Name = "BtnOpenpath"
        Me.BtnOpenpath.Size = New System.Drawing.Size(75, 23)
        Me.BtnOpenpath.TabIndex = 5
        Me.BtnOpenpath.Text = "Open Path"
        Me.BtnOpenpath.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(193, 99)
        Me.Controls.Add(Me.BtnOpenpath)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnAttach)
        Me.Controls.Add(Me.BtnOpen)
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.Text = "CSiAmerica Visual Basic Example"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnOpen As Button
    Friend WithEvents BtnAttach As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents BtnOpenpath As Button
End Class
