<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        BtnOpen = New Button()
        BtnAttach = New Button()
        BtnClose = New Button()
        Button1 = New Button()
        CBPrograms = New ComboBox()
        BtnOpenpath = New Button()
        SuspendLayout()
        ' 
        ' BtnOpen
        ' 
        BtnOpen.Location = New Point(14, 14)
        BtnOpen.Margin = New Padding(4, 3, 4, 3)
        BtnOpen.Name = "BtnOpen"
        BtnOpen.Size = New Size(88, 27)
        BtnOpen.TabIndex = 0
        BtnOpen.Text = "Open"
        BtnOpen.UseVisualStyleBackColor = True
        ' 
        ' BtnAttach
        ' 
        BtnAttach.Location = New Point(14, 47)
        BtnAttach.Margin = New Padding(4, 3, 4, 3)
        BtnAttach.Name = "BtnAttach"
        BtnAttach.Size = New Size(88, 27)
        BtnAttach.TabIndex = 1
        BtnAttach.Text = "Attach"
        BtnAttach.UseVisualStyleBackColor = True
        ' 
        ' BtnClose
        ' 
        BtnClose.Location = New Point(14, 81)
        BtnClose.Margin = New Padding(4, 3, 4, 3)
        BtnClose.Name = "BtnClose"
        BtnClose.Size = New Size(88, 27)
        BtnClose.TabIndex = 2
        BtnClose.Text = "Close"
        BtnClose.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(119, 47)
        Button1.Margin = New Padding(4, 3, 4, 3)
        Button1.Name = "Button1"
        Button1.Size = New Size(88, 27)
        Button1.TabIndex = 3
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' CBPrograms
        ' 
        CBPrograms.FormattingEnabled = True
        CBPrograms.Items.AddRange(New Object() {"ETABS", "SAP2000", "SAFE", "CSiBridge"})
        CBPrograms.Location = New Point(14, 114)
        CBPrograms.Margin = New Padding(4, 3, 4, 3)
        CBPrograms.Name = "CBPrograms"
        CBPrograms.Size = New Size(192, 23)
        CBPrograms.TabIndex = 4
        ' 
        ' BtnOpenpath
        ' 
        BtnOpenpath.Location = New Point(119, 14)
        BtnOpenpath.Margin = New Padding(4, 3, 4, 3)
        BtnOpenpath.Name = "BtnOpenpath"
        BtnOpenpath.Size = New Size(88, 27)
        BtnOpenpath.TabIndex = 5
        BtnOpenpath.Text = "Open Path"
        BtnOpenpath.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(226, 152)
        Controls.Add(BtnOpenpath)
        Controls.Add(CBPrograms)
        Controls.Add(Button1)
        Controls.Add(BtnClose)
        Controls.Add(BtnAttach)
        Controls.Add(BtnOpen)
        Margin = New Padding(4, 3, 4, 3)
        Name = "Form1"
        ShowIcon = False
        Text = "CSiAmerica Visual Basic Example"
        ResumeLayout(False)

    End Sub

    Friend WithEvents BtnOpen As Button
    Friend WithEvents BtnAttach As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents CBPrograms As ComboBox
    Friend WithEvents BtnOpenpath As Button
End Class
