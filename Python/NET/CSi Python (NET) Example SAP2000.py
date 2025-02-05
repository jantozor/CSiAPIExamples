import os
import sys
from pythonnet import load
load("coreclr")
import clr
from enum import Enum
#Path to the CSi DLL
clr.AddReference(os.path.abspath("../../DLL/SAP2000v1.dll"))
from SAP2000v1 import * # type: ignore

# Initialize global variables
myHelper = cHelper(Helper()) # type: ignore
mySapObject = None
mySapModel = None
ret = 0
program_id="CSI.SAP2000.API.SapObject"
program_path=r"C:\Program Files\Computers and Structures\SAP2000 26\SAP2000.exe" 

def open():
    #Open a new instance using the program ID.
    global myHelper, mySapObject, mySapModel, ret
    if not myHelper:
        raise RuntimeError("Helper is not initialized. Cannot start a new instance.")

    try:
        # Create an instance of the CSi object from the program ID
        mySapObject = cOAPI(myHelper.CreateObjectProgID(program_id)) # type: ignore
        ret = mySapObject.ApplicationStart()
        # Get a reference to cSapModel
        mySapModel = cSapModel(mySapObject.SapModel) # type: ignore
        return mySapModel
    except Exception as e:
        raise RuntimeError(f"Error: Failed to start a new instance of the program: {e}")

def open_path():
    #Open a new instance using the specified program path.
    global myHelper, mySapObject, mySapModel, ret
    if not program_path:
        raise ValueError("Program path is not specified.")
    
    if not myHelper:
        raise RuntimeError("Helper is not initialized. Cannot start a new instance.")

    try:
        # Create an instance from the specified path
        mySapObject = cOAPI(myHelper.CreateObject(program_path)) # type: ignore
        # Start the application
        ret = mySapObject.ApplicationStart()
        # Get a reference to cSapModel
        mySapModel = cSapModel(mySapObject.SapModel) # type: ignore
        return mySapModel
    except Exception as e:
        raise RuntimeError(f"Error: Failed to start the program from the specified path: {e}")

def attach():
    #Attach to an active instance of the program.
    global myHelper, mySapObject, mySapModel
    if not myHelper:
        raise RuntimeError("Helper is not initialized. Cannot attach to an instance.")

    try:
        # Get the active application object
        mySapObject = cOAPI(myHelper.GetObject(program_id)) # type: ignore
        # Get a reference to cSapModel
        mySapModel = cSapModel(mySapObject.SapModel) # type: ignore
        return mySapModel
    except Exception as e:
        raise RuntimeError(f"Error: Failed to attach to an active instance: {e}")

def close():
    #Close the application and clean up resources.
    global mySapObject, mySapModel, ret
    if not mySapObject:
        raise RuntimeError("No active application instance to close.")

    try:
        # Close the application
        mySapObject.ApplicationExit(False)
        # Clean up variables
        mySapModel = None
        mySapObject = None

        if ret == 0:
            print("API script completed successfully.")
        else:
            print("API script FAILED to complete.")
    except Exception as e:
        raise RuntimeError(f"Error: Failed to close the application: {e}")

def Testcode():
    global mySapModel, ret
    #Initialize model
    ret = mySapModel.InitializeNewModel()
    #Create File interface
    File = cFile(mySapModel.File) # type: ignore
    # Create a 3D frame model from template
    ret = File.New3DFrame(e3DFrameType(2), 3, 12, 3, 28, 2, 36) # type: ignore

#Python Running example code
open()
Testcode()
input("Press Enter to continue and close the model.")
# Close the program
close()