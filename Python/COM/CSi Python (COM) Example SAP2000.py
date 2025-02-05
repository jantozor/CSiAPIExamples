import os
import sys
import comtypes.client

# Initialize global variables
myHelper = None
mySapObject = None
mySapModel = None
ret = 0
program_id="CSI.SAP2000.API.SapObject"
program_path=r"C:\Program Files\Computers and Structures\SAP2000 26\SAP2000.exe" 

def initialize_helper():
    #Initialize the API helper object.        
    global myHelper
    try:            
        #create API helper object        
        myHelper = comtypes.client.CreateObject('SAP2000v1.Helper')
        myHelper = myHelper.QueryInterface(comtypes.gen.SAP2000v1.cHelper)
    except Exception as e:
        print(f"Error: Cannot create an instance of the Helper object: {e}")

def open():
    #Open a new instance using the program ID.
    global myHelper, mySapObject, mySapModel, ret
    if not myHelper:
        raise RuntimeError("Helper is not initialized. Cannot start a new instance.")

    try:
        # Create an instance of the CSi object from the program ID
        mySapObject = myHelper.CreateObjectProgID(program_id)
        # Start the application
        ret = mySapObject.ApplicationStart()
        # Get a reference to cSapModel
        mySapModel = mySapObject.SapModel
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
        mySapObject = myHelper.CreateObject(program_path)
        # Start the application
        ret = mySapObject.ApplicationStart()
        # Get a reference to cSapModel
        mySapModel = mySapObject.SapModel
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
        mySapObject = myHelper.GetObject(program_id)
        # Get a reference to cSapModel
        mySapModel = mySapObject.SapModel
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
    # Create a 3D frame model from template
    ret = mySapModel.File.New3DFrame(2, 3, 12, 3, 28, 2, 36)

#Python Running example code
initialize_helper()
open()
Testcode()
input("Press Enter to continue and close the model.")
# Close the program
close()