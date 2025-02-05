import sys
from csi_api_manager_COM import CSiAPIManager

def select_program():
    #Prompt the user to select a program and return the program name.
    
    print("Select the program you are working with:")
    print("1. ETABS")
    print("2. SAP2000")
    print("3. CSiBridge")
    print("4. SAFE")
    
    choice = input("Enter the number corresponding to your program: ")

    if choice == '1':
        return "ETABS"
    elif choice == '2':
        return "SAP2000"
    elif choice == '3':
        return "CSiBridge"
    elif choice == '4':
        return "SAFE"
    else:
        print("Invalid selection, please choose a valid program.")
        sys.exit()

# Ask the user which program they are working with
selected_program = select_program()

# Initialize the CSiAPIManager with the selected program
manager = CSiAPIManager(program_name=selected_program)

# Open a new instance of the selected program
mySapModel = manager.open()

if mySapModel is None:
    print("Error: mySapModel is not initialized.")
    sys.exit()
# Initialize the model based on the selected program
ret = mySapModel.InitializeNewModel
if selected_program == "ETABS" or selected_program == "SAFE":
    # Create steel deck template model for ETABS/SAFE
    ret = mySapModel.File.NewSteelDeck(4, 12, 12, 4, 4, 24, 24)
elif selected_program == "SAP2000" or selected_program == "CSiBridge":
    # Create a 3D frame model for SAP2000/CSiBridge
    ret = mySapModel.File.New3DFrame(2, 3, 12, 3, 28, 2, 36)
else:
    # Create a blank model for other programs
    ret = mySapModel.File.Newblank
input("Press Enter to continue and close the model.")
# Close the program
manager.close()