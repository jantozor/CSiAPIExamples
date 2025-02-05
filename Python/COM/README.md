## **Requirements for Python COM Examples**

In addition to having the corresponding **CSi Software** (e.g., SAP2000, ETABS, SAFE, CSiBridge, Perform 3D) installed, the **Python COM Examples** require the `comtypes` library for COM automation.

### 1. **Install `comtypes` in Visual Studio Code**

To enable COM functionality in Python, you'll need to install the `comtypes` library using Visual Studio Code's terminal.

#### Installation Steps:

1. Open **Visual Studio Code** and press Ctrl+\` (or Cmd+\` on macOS) to open the integrated terminal.
2. To upgrade pip to the latest version, run the following command:

   ```bash
   python -m pip install --upgrade pip
3. Run the following command to install `comtypes`:

   ```bash
   pip install comtypes
4. If you do not have pip installed, you can install it by running the following commands:
   - Download the get-pip.py script:

      ```bash 
      curl https://bootstrap.pypa.io/get-pip.py -o get-pip.py   
   - Install pip:

      ```bash 
      python get-pip.py
