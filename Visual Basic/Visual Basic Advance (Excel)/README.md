# **Visual Basic Advanced - Excel Integration with CSiSoftware**

## **Overview**

This example demonstrates how to use Visual Basic for Applications (VBA) to interface with **CSiSoftware** products, including **SAP2000**, **ETABS**, **SAFE**, and **CSiBridge**. The examples are provided in Excel files that are saved as **.xlsm** (macro-enabled) files. In order to run these examples, the following steps are required:

- **Excel** must be installed on your machine.
- Macros must be enabled in Excel to run the provided VBA code.
- **CSiSoftware** (e.g., SAP2000, ETABS, SAFE, or CSiBridge) must be installed on your system.
- Add the necessary references to the VBA project to enable communication with the CSiSoftware API.

## **System Requirements**

- **Excel**: You must have Excel installed (either 32-bit or 64-bit version, depending on your environment).
- **CSiSoftware**: Ensure that the corresponding CSiSoftware (SAP2000, ETABS, SAFE, CSiBridge, etc.) is installed on your system.

## **Steps to Set Up the VBA Environment**

### **1. Enable Macros in Excel**

To run the examples provided in this repository, you need to enable macros in your Excel environment.

1. Open the Excel file (saved as `.xlsm`).
2. Go to the **File** tab and select **Options**.
3. In the **Excel Options** window, select **Trust Center** from the left sidebar.
4. Click on **Trust Center Settings...**.
5. In the **Trust Center** dialog, select **Macro Settings**.
6. Choose **Enable all macros** and check **Trust access to the VBA project object model**.
7. Click **OK** to apply the changes.

### **2. Add the Required Reference to the VBA Project**

To interact with CSiSoftware's API, you need to add a reference to the corresponding CSi Software COM library in your VBA project. This step allows you to early bind to the CSi API using the COM interface.

#### **Steps to Add the Reference**:

1. Open the Excel file that contains the VBA code.
2. Press `Alt + F11` to open the **Visual Basic for Applications (VBA) Editor**.
3. In the VBA Editor, go to **Tools** → **References**.
4. In the **References** dialog, click on **Browse...**.

#### **Choosing the Correct TLB File**:

- For **ETABS**

   <p align="center">
       <img src="ETABS TBL file add reference.png" alt="Adding TLB Reference for ETABS" />
   </p>

   - For **32-bit Excel**:
      - Navigate to the ETABS installation directory: `C:\Program Files\Computers and Structures\ETABS 22\NativeAPI\x86\`.
      - Select the file `ETABSv1.tlb`.

   - For **64-bit Excel**:
      - Navigate to the ETABS installation directory: `C:\Program Files\Computers and Structures\ETABS 22\NativeAPI\x64\`.
      - Select the file `ETABSv1.tlb`.

- For **SAFE**

   <p align="center">
       <img src="SAFE TBL file add reference.png" alt="Adding TLB Reference for SAFE" />
   </p>

   - For **32-bit Excel**:
      - Navigate to the SAFE installation directory: `C:\Program Files\Computers and Structures\SAFE 22\NativeAPI\x86\`.
      - Select the file `SAFEv1.tlb`.

   - For **64-bit Excel**:
      - Navigate to the SAFE installation directory: `C:\Program Files\Computers and Structures\SAFE 22\NativeAPI\x64\`.
      - Select the file `SAFEv1.tlb`.

- For **SAP2000**

   <p align="center">
       <img src="SAP2000 TBL file add reference.png" alt="Adding TLB Reference for SAP2000" />
   </p>

   - For **32-bit Excel**:
      - Navigate to the SAP2000 installation directory: `C:\Program Files\Computers and Structures\SAP2000 26\NativeAPI\x86\`.
      - Select the file `SAP2000v1.tlb`.

   - For **64-bit Excel**:
      - Navigate to the SAP2000 installation directory: `C:\Program Files\Computers and Structures\SAP2000 26\NativeAPI\x64\`.
      - Select the file `SAP2000v1.tlb`.

- For **CSiBridge**

   <p align="center">
       <img src="CSiBridge TBL file add reference.png" alt="Adding TLB Reference for CSiBridge" />
   </p>

   - For **32-bit Excel**:
      - Navigate to the CSiBridge installation directory: `C:\Program Files\Computers and Structures\CSiBridge 26\NativeAPI\x86\`.
      - Select the file `CSiBridge1.tlb`.

   - For **64-bit Excel**:
      - Navigate to the CSiBridge installation directory: `C:\Program Files\Computers and Structures\CSiBridge 26\NativeAPI\x64\`.
      - Select the file `CSiBridge1.tlb`.

Ensure you select the correct file that corresponds to the bitness of your version of Excel (32-bit or 64-bit).

### **3. Save and Close the Reference Dialog**
After selecting the correct `.tlb` file for your system, click **OK** to close the **References** dialog and save the changes to your project.

### Step 4: Understanding the Example Buttons

The provided Excel example consists of **5 buttons**, each with specific functionality. These buttons are part of the Visual Basic for Applications (VBA) code and demonstrate how to interact with the CSiSoftware API. To use them effectively:

- Ensure macros are enabled.
- Familiarize yourself with the purpose of each button below.

#### Button Descriptions:

1. **Button 1: Custom User Test**  
   This button is a template for users to add and test their own code. Below is a simple example of initializing a new blank model.
   ```vb
   'Required Variables
   Dim mySapObject As cOAPI
   Dim mySapModel As cSapModel
   Dim ret As Integer

   Sub Button1()
       'Initialize model
       ret = mySapModel.InitializeNewModel()
       'Create a blank model from template
       ret = mySapModel.File.NewBlank()
   End Sub

2. **Button Open: Open a New Instance (Program ID)**  
Opens a new instance of the software using the specified Program ID.

3. **Button Open Path: Open a New Instance (Specified Path)**  
Opens a new instance of the software using the path specified in cell of the active Excel sheet.

4. **Button Attach: Attach to a Running Instance**  
Attaches to an active CSiSoftware instance using the specified Program ID.

5. **Button Close: Close the CSiSoftware Instance**  
Closes the active instance of CSiSoftware and cleans up variables.

### Detailed Button Functionality:

1. **Button 1: Custom User Code**  
This button is a placeholder for users to implement their own testing logic. The sample code initializes a new blank model in the software.

2. **Button Open: Open a New Instance (Program ID)**  
   ```vb
   Sub BtnOpen()
      On Error GoTo CatchBlock
      Dim Programid As String
      Programid = ThisWorkbook.ActiveSheet.Range("B2").Value
      Set myHelper = New Helper
      Set mySapObject = myHelper.CreateObjectProgID(Programid)
      ret = mySapObject.ApplicationStart()
      Set mySapModel = mySapObject.SapModel
      Exit Sub
   CatchBlock:
      MsgBox ("Cannot start a new instance of the program.")
   End Sub
3. **Button Open Path: Open a New Instance (Specified Path)**  
   ```vb
   Sub BtnOpenpath()
      On Error GoTo CatchBlock
      Dim ProgramPath As String
      ProgramPath = ThisWorkbook.ActiveSheet.Range("B3").Value
      Set myHelper = New Helper
      Set mySapObject = myHelper.CreateObject(ProgramPath)
      ret = mySapObject.ApplicationStart()
      Set mySapModel = mySapObject.SapModel
      Exit Sub
   CatchBlock:
      MsgBox "Cannot start a new instance of the program from " + ProgramPath
   End Sub
4. **Button Attach: Attach to a Running Instance**  
   ```vb
   Sub BtnAttach()
      On Error GoTo CatchBlock
      Dim Programid As String
      Programid = ThisWorkbook.ActiveSheet.Range("B2").Value
      Set myHelper = New Helper
      Set mySapObject = myHelper.GetObject(Programid)
      Set mySapModel = mySapObject.SapModel
      Exit Sub
   CatchBlock:
      MsgBox ("No running instance of the program found or failed to attach.")
   End Sub
5. **Button Close: Close the CSiSoftware Instance**  
   ```vb
   Sub BtnClose()
      mySapObject.ApplicationExit (False)
      Set mySapModel = Nothing
      Set mySapObject = Nothing
      If ret = 0 Then
         MsgBox "API script completed successfully."
      Else
         MsgBox "API script FAILED to complete."
      End If
   End Sub