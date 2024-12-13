Imports CSiAPIv1

Public Class Form1
    Dim myHelper As cHelper
    Dim mySapObject As cOAPI
    Dim ret As Integer
    Dim mySapModel As cSapModel
    Dim ProgramPath As String
    Dim Programid As String


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Initialize model
        ret = mySapModel.InitializeNewModel()

        'Create steel deck template model
        ret = mySapModel.File.NewSteelDeck(4, 12, 12, 4, 4, 24, 24)
    End Sub
    Private Sub BtnOpen_Click(sender As Object, e As EventArgs) Handles BtnOpen.Click
        'Open a new instance using the program ID
        Try
            'create an instance of the CSi object from the latest installed ETABS
            mySapObject = myHelper.CreateObjectProgID("CSI.ETABS.API.ETABSObject")
            'start CSi application
            ret = mySapObject.ApplicationStart()
        Catch ex As Exception
            MsgBox("Cannot start a new instance of the program.")
            Return
        End Try
    End Sub
    Private Sub BtnOpenpath_Click(sender As Object, e As EventArgs) Handles BtnOpenpath.Click
        'Open a new instance using the specified path
        Try
            'create an instance of the ETABS object from the specified path
            mySapObject = myHelper.CreateObject(ProgramPath)
        Catch ex As Exception
        End Try
        If (mySapObject Is Nothing) Then
            MsgBox("Cannot start a new instance of the program from " + ProgramPath)
            Dim filedialogpath As OpenFileDialog = New OpenFileDialog
            ' Set the filter to only show .exe files
            filedialogpath.Filter = "Executable Files (*.exe)|*.exe"
            ' Set the dialog title (optional)
            filedialogpath.Title = "Select the path for the Executable File"
            filedialogpath.ShowDialog()
            If filedialogpath.CheckPathExists Then
                ProgramPath = filedialogpath.FileName
            End If
            BtnOpenpath_Click(Nothing, Nothing)
            Return
        End If
        'start ETABS application
        ret = mySapObject.ApplicationStart()
    End Sub
    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles BtnAttach.Click
        'Attach to an active CSi instance
        Try
            'get the active SapObject
            'mySapObject = DirectCast(System.Runtime.InteropServices.Marshal.GetActiveObject(Programid), cOAPI)
            mySapObject = myHelper.GetObject(Programid)
        Catch ex As Exception
            MsgBox("No running instance of the program found or failed to attach.")
            Return
        End Try
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        'Close ETABS
        mySapObject.ApplicationExit(False)

        'Clean up variables
        mySapModel = Nothing
        mySapObject = Nothing

        'Check ret value
        If ret = 0 Then
            MsgBox("API script completed successfully.")
        Else
            MsgBox("API script FAILED to complete.")
        End If
    End Sub
    Private Sub CBPrograms_SelectedValueChanged(sender As Object, e As EventArgs) Handles CBPrograms.SelectedValueChanged
        Dim cb As ComboBox = sender
        Select Case cb.SelectedItem
            Case "ETABS"
                Programid = "CSI.ETABS.API.ETABSObject"
                ProgramPath = "C:\Program Files\Computers and Structures\ETABS 22\ETABS.exe"
            Case "SAP2000"
                Programid = "CSI.SAP2000.API.SapObject"
                ProgramPath = "C:\Program Files\Computers and Structures\SAP2000 26\SAP2000.exe"
            Case "CSiBridge"
                Programid = "CSI.CSIBRIDGE.API.SapObject"
                ProgramPath = "C:\Program Files\Computers and Structures\CSiBridge 26\CSiBridge.exe"
            Case "SAFE"
                Programid = "CSI.SAFE.API.ETABSObject"
                ProgramPath = "C:\Program Files\Computers and Structures\SAFE 22\SAFE.exe"
        End Select
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CBPrograms.SelectedIndex = 0
        'create API helper object
        Try
            myHelper = New CSiAPIv1.Helper
        Catch ex As Exception
            MsgBox("Cannot create an instance of the Helper object")
            Return
        End Try
    End Sub
End Class
