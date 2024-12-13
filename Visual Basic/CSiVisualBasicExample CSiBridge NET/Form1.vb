Imports CSiBridge1
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

        'create a 3D frame model from template
        ret = mySapModel.File.New3DFrame(e3DFrameType.BeamSlab, 3, 12, 3, 28, 2, 36)
    End Sub
    Private Sub BtnOpen_Click(sender As Object, e As EventArgs) Handles BtnOpen.Click
        'Open a new instance using the program ID
        Try
            'create an instance of the CSi object from the latest installed Version
            mySapObject = myHelper.CreateObjectProgID(Programid)
            'start CSi application
            ret = mySapObject.ApplicationStart()
            'Get a reference to cSapModel to access all API classes and functions
            mySapModel = mySapObject.SapModel
        Catch ex As Exception
            MsgBox("Cannot start a new instance of the program.")
            Return
        End Try
    End Sub
    Private Sub BtnOpenpath_Click(sender As Object, e As EventArgs) Handles BtnOpenpath.Click
        'Open a new instance using the specified path
        Try
            'create an instance from the specified path
            mySapObject = myHelper.CreateObject(ProgramPath)
        Catch ex As Exception
        End Try
        'Check if mySapObject was created
        If (mySapObject Is Nothing) Then
            'If mySapObject was not created ask the user for a new program path
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
            'Try again to create mySapObject
            BtnOpenpath_Click(Nothing, Nothing)
            Return
        End If
        'start application
        ret = mySapObject.ApplicationStart()
        'Get a reference to cSapModel to access all API classes and functions
        mySapModel = mySapObject.SapModel
    End Sub
    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles BtnAttach.Click
        'Attach to an active CSi instance
        Try
            'get the active SapObject
            mySapObject = myHelper.GetObject(Programid)
            'Get a reference to cSapModel to access all API classes and functions
            mySapModel = mySapObject.SapModel
        Catch ex As Exception
            MsgBox("No running instance of the program found or failed to attach.")
            Return
        End Try
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        'Close CSi Software
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
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Set Path and program id
        Programid = "CSI.CSIBRIDGE.API.SapObject"
        ProgramPath = "C:\Program Files\Computers and Structures\CSiBridge 26\CSiBridge.exe"
        'create API helper object
        Try
            myHelper = New CSiBridge1.Helper
        Catch ex As Exception
            MsgBox("Cannot create an instance of the Helper object")
            Return
        End Try
    End Sub
End Class