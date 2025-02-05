import os
import sys
from pythonnet import load
load("coreclr")
import clr
from enum import Enum
#Path to the CSi DLL
clr.AddReference(os.path.abspath("../../DLL/CSiAPIv1.dll"))
from CSiAPIv1 import * # type: ignore

class CSiAPIManager:
    def __init__(self, program_name = "ETABS"):
        #Initialize the CSiAPIManager with optional program ID and program path.
        #create API helper object
        self.myHelper = cHelper(Helper())  # type: ignore
        self.mySapObject = None
        self.mySapModel = None
        self.ret = 0
        self.program_name = program_name        
        if self.program_name == "ETABS":
            self.program_id="CSI.ETABS.API.ETABSObject"
            self.program_path=r"C:\Program Files\Computers and Structures\ETABS 22\ETABS.exe"
        elif self.program_name == "SAP2000":
            self.program_id="CSI.SAP2000.API.SapObject"
            self.program_path=r"C:\Program Files\Computers and Structures\SAP2000 26\SAP2000.exe"       
        elif self.program_name == "CSiBridge":
            self.program_id="CSI.CSIBRIDGE.API.SapObject"
            self.program_path=r"C:\Program Files\Computers and Structures\CSiBridge 26\CSiBridge.exe"       
        elif self.program_name == "SAFE":
            self.program_id="CSI.SAFE.API.ETABSObject"
            self.program_path=r"C:\Program Files\Computers and Structures\SAFE 22\SAFE.exe"

    def open(self):
        """
        Open a new instance using the program ID.
        Returns:
            mySapObject: The initialized SAP application object.
        """        
        if not self.myHelper:
            raise RuntimeError("Helper is not initialized. Cannot start a new instance.")

        try:
            # Create an instance of the CSi object from the program ID
            self.mySapObject = cOAPI(self.myHelper.CreateObjectProgID(self.program_id))  # type: ignore
            # Start the application
            self.ret = self.mySapObject.ApplicationStart()
            # Get a reference to cSapModel
            self.mySapModel = cSapModel(self.mySapObject.SapModel)  # type: ignore
            return self.mySapModel
        except Exception as e:
            raise RuntimeError(f"Error: Failed to start a new instance of the program: {e}")

    def open_path(self):
        """
        Open a new instance using the specified program path.
        Returns:
            mySapObject: The initialized SAP application object.
        """
        if not self.program_path:
            raise ValueError("Program path is not specified.")
        
        if not self.myHelper:
            raise RuntimeError("Helper is not initialized. Cannot start a new instance.")

        try:
            # Create an instance from the specified path
            self.mySapObject = cOAPI(self.myHelper.CreateObject(self.program_path)) # type: ignore
            # Start the application
            self.ret = self.mySapObject.ApplicationStart()
            # Get a reference to cSapModel
            self.mySapModel = cSapModel(self.mySapObject.SapModel) # type: ignore
            return self.mySapModel
        except Exception as e:
            raise RuntimeError(f"Error: Failed to start the program from the specified path: {e}")

    def attach(self):
        """
        Attach to an active instance of the program.
        Returns:
            mySapObject: The active SAP application object.
        """
        if not self.myHelper:
            raise RuntimeError("Helper is not initialized. Cannot attach to an instance.")

        try:
            # Get the active SAP application object
            self.mySapObject = cOAPI(self.myHelper.GetObject(self.program_id)) # type: ignore
            # Get a reference to cSapModel
            self.mySapModel = cSapModel(self.mySapObject.SapModel) # type: ignore
            return self.mySapModel
        except Exception as e:
            raise RuntimeError(f"Error: Failed to attach to an active instance: {e}")

    def close(self):
        #Close the SAP application and clean up resources.        
        if not self.mySapObject:
            raise RuntimeError("No active SAP application instance to close.")

        try:
            # Close the application
            self.mySapObject.ApplicationExit(False)
            # Clean up variables
            self.mySapModel = None
            self.mySapObject = None

            if self.ret == 0:
                print("API script completed successfully.")
            else:
                print("API script FAILED to complete.")
        except Exception as e:
            raise RuntimeError(f"Error: Failed to close the application: {e}")

if __name__ == "__main__":
    manager = CSiAPIManager(program_name="ETABS")

    try:
        # Open a new instance
        mySapModel = manager.open()

        if mySapModel is None:
            print("Error: mySapModel is not initialized.")
            sys.exit()

        #Initialize model
        ret = mySapModel.InitializeNewModel()
        #Create File interface
        File = cFile(mySapModel.File) # type: ignore
        # Select the correct function based on the selected program
        if manager.program_name == "ETABS" or manager.program_name == "SAFE":
            # Create steel deck template model
            ret = File.NewSteelDeck(4, 12, 12, 4, 4, 24, 24)
        elif manager.program_name == "SAP2000" or manager.program_name == "CSiBridge":
            # Create a 3D frame model from template
            ret = File.New3DFrame(e3DFrameType(2), 3, 12, 3, 28, 2, 36) # type: ignore
        else:
            # Create a blank model from template
            ret = File.Newblank

        input("Press Enter to continue and close the model.")
        # Close the program
        manager.close()
    except Exception as error:
        print(f"Error: {error}")
