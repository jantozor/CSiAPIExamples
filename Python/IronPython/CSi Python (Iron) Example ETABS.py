import os
import sys
import clr # type: ignore
from enum import Enum
clr.AddReference("System")
import System # type: ignore
clr.AddReferenceToFileAndPath("C:\Program Files\Computers and Structures\ETABS 22\ETABSv1.dll")
from ETABSv1 import * # type: ignore

# Initialize global variables
myHelper = Helper() # type: ignore
mySapObject = None
mySapModel = None
ret = 0
program_id="CSI.ETABS.API.ETABSObject"
program_path=r"C:\Program Files\Computers and Structures\ETABS 22\ETABS.exe" 

def open():
    #Open a new instance using the program ID.
    global myHelper, mySapObject, mySapModel, ret
    if not myHelper:
        raise RuntimeError("Helper is not initialized. Cannot start a new instance.")

    try:
        # Create an instance of the CSi object from the program ID
        mySapObject = myHelper.CreateObjectProgID(program_id)
        ret = mySapObject.ApplicationStart()
        # Get a reference to cSapModel
        mySapModel = mySapObject.SapModel
        return mySapModel
    except Exception as e:
        raise RuntimeError("Error: Failed to start a new instance of the program: " + str(e))

def open_path():
    #Open a new instance using the specified program path.
    global myHelper, mySapObject, mySapModel, ret
    if not program_path:
        raise ValueError("Program path is not specified.")
    
    if not myHelper:
        raise RuntimeError("Helper is not initialized. Cannot start a new instance.")

    try:
        # Create an instance from the specified path
        mySapObject = myHelper.CreateObject(program_path)
        # Start the application
        ret = mySapObject.ApplicationStart()
        # Get a reference to cSapModel
        mySapModel = mySapObject.SapModel
        return mySapModel
    except Exception as e:
        raise RuntimeError("Error: Failed to start the program from the specified path: " + str(e))

def attach():
    #Attach to an active instance of the program.
    global myHelper, mySapObject, mySapModel
    if not myHelper:
        raise RuntimeError("Helper is not initialized. Cannot attach to an instance.")

    try:
        # Get the active application object
        mySapObject = myHelper.GetObject(program_id)
        # Get a reference to cSapModel
        mySapModel = mySapObject.SapModel
        return mySapModel
    except Exception as e:
        raise RuntimeError("Error: Failed to attach to an active instance: " + str(e))

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
        raise RuntimeError("Error: Failed to close the application: " + str(e))

def Testcode():
    global mySapModel, ret
    #Initialize model
    ret = mySapModel.InitializeNewModel()
    #Create File interface
    File = mySapModel.File
    # Create steel deck template model
    ret = File.NewSteelDeck(4, 12, 12, 4, 4, 24, 24)

#Python Running example code
open()
Testcode()
input("Press Enter to continue and close the model.")
# Close the program
close()