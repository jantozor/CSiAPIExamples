## **Requirements for Python NET Examples**

In addition to having the corresponding **CSi Software** (e.g., SAP2000, ETABS, SAFE, CSiBridge, Perform3D) installed, the **PythonNet Examples** require the `pythonnet` library for interacting with .NET-based APIs.

### 1. **Ensure .NET Core Runtime is Installed**
Since pythonnet requires the .NET runtime, make sure you have the latest version of .NET Core Runtime installed. Download it from:
- [dot net microsoft download](https://dotnet.microsoft.com/en-us/download)
### 2. **Install `pythonnet` in Visual Studio Code**

To enable .NET interoperability in Python, you need to install `pythonnet` using Visual Studio Code's terminal.

#### Installation Steps:

1. Open **Visual Studio Code** and press Ctrl+\` (or Cmd+\` on macOS) to open the integrated terminal.
2. To upgrade pip to the latest version, run the following command:

   ```bash
   python -m pip install --upgrade pip
3. Run the following command to install `pythonnet`:

   ```bash
   pip install pythonnet
4. If you do not have pip installed, you can install it by running the following commands:
   - Download the get-pip.py script:

      ```bash 
      curl https://bootstrap.pypa.io/get-pip.py -o get-pip.py   
   - Install pip:

      ```bash 
      python get-pip.py
