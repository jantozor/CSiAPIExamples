

# Plugins NET 8

This folder contains example plugins for **CSI America** software built using **.NET 8**.  
These plugins are compatible with **ETABS v22.0.0+**, **SAFE v22.0.0+**, **SAP2000 v26.0.0+**, and **CSiBridge v26.0.0+**.

## Plugin Overview

These examples demonstrate how to develop and use **.NET 8 plugins** for CSI products. They utilize the cross-product API library **`CSiAPIv1.dll`**, making them compatible with multiple CSI applications.

The examples show how to:
- Properly reference and manage plugin dependencies  
- Implement the required CSI plugin contract  
- Interact with the CSI model via the API

## Key Implementation Notes

- The project targets **.NET 8 for Windows** and enables Windows Forms and dynamic loading in the `.csproj` file:
  ```xml
  <TargetFramework>net8.0-windows</TargetFramework>
  <UseWindowsForms>true</UseWindowsForms>
  <EnableDynamicLoading>true</EnableDynamicLoading>
- Reference the CSI API library (`CSiAPIv1.dll`) from your installed CSI product directory, but ensure it is **not copied** to the output directory:
    ```xml
   <Private>false</Private>
   <ExcludeAssets>runtime</ExcludeAssets>
- R The main plugin class implements 
`cPluginContract` and provides `Info` and `Main` methods as required by CSI products.
- The plugin form (`Form1`) includes a Button (`button1`) used to execute test functions.
- Always call `_pluginCallback.Finish(errorCode)` when the form closes to ensure the CSI product exits the plugin cleanly and avoid hanging the CSI product.

## Plugin Structure and Compilation

### Project Overview

The plugin project consists of the following key parts:

| File | Description |
|------|--------------|
| **`cPlugin.cs`** | Core entry point of the plugin. Implements the `cPluginContract` interface and provides the `Info()` and `Main()` methods required by all CSI plugins. |
| **`Form1.cs`** | Example Windows Form demonstrating how to interact with CSI products, e.g., executing simple API commands like `SapModel.File.NewBlank()`. |
| **`.csproj` file** | Defines the project configuration — including target framework, platform, and references — that control how the plugin is built and loaded by CSI products. |

### ⚙️ Compilation Details

To compile the plugin:

1. **Open the project in Visual Studio.**
2. Verify that the `.csproj` file includes the following essential settings:
   ```xml
    <TargetFramework>net8.0-windows</TargetFramework>
    <UseWindowsForms>true</UseWindowsForms>
    <EnableDynamicLoading>true</EnableDynamicLoading>
    <Private>false</Private>
    <ExcludeAssets>runtime</ExcludeAssets>
3. Build the project in Visual Studio (**Debug** or **Release** configuration).

    The compiled DLL will be generated in:
    `\bin\Debug\net8.0-windows\` or `\bin\Release\net8.0-windows\`
    depending on your selected build configuration.
## Using the Plugin in CSI Products

1. **Build** the plugin project (**AnyCPU** or **x64** platform) to generate the plugin DLL (for example `CSiC_Example_Plugin_NET.dll` in `\bin\Debug\net8.0-windows\`).
2. In your CSI product (**ETABS**, **SAFE**, **SAP2000**, or **CSiBridge**), open:  
   **Tools → Add/Show Plugins** 
3. Click **Add New Plugin** and browse to your compiled DLL.
4. The plugin will now appear in the **Tools** menu and can be launched directly from there.
5. On first launch, a warning message will appear.  
   - To disable it in future runs, check **“Do not show this message again.”**
6. Optionally, you can **assign a keyboard shortcut** to quickly open the plugin.  
   - In your CSI product, go to **Options → Customize → Keyboard Shortcuts**, find your plugin in the list, and assign your preferred key combination.

### 💡 Notes for Developers

- The **`cPlugin`** class manages communication between the CSI application and your plugin.
- The **`Main()`** method receives:
  - A reference to the active **`cSapModel`**.
  - A **`cPluginCallback`** instance used to signal the plugin’s completion.
- Always call **`_pluginCallback.Finish(errorCode)`** when your form closes or your logic completes. Otherwise, the CSI software will remain waiting indefinitely.
- The included **`Form1`** provides a simple example of a Windows Form that demonstrates the plugin’s basic functionality and communication flow.

---