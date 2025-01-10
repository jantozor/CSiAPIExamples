using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSiAPIv1;

namespace CSiC_Example_Net_Framework_4_8
{
    public partial class Form1 : Form
    {
        private cHelper myHelper;
        private cOAPI mySapObject;
        private int ret;
        private cSapModel mySapModel;
        private string ProgramPath;
        private string Programid;
        public Form1()
        {
            InitializeComponent();
        }
        // Button1_Click - Initialize model based on selected program
        private void Button1_Click(object sender, EventArgs e)
        {
            // Initialize model
            ret = mySapModel.InitializeNewModel();

            // Select the right function depending on the selected working program
            switch (CBPrograms.SelectedItem.ToString())
            {
                case "ETABS":
                case "SAFE":
                    // Create steel deck template model
                    ret = mySapModel.File.NewSteelDeck(4, 12, 12, 4, 4, 24, 24);
                    break;
                case "SAP2000":
                case "CSiBridge":
                    // Create a 3D frame model from template
                    ret = mySapModel.File.New3DFrame(e3DFrameType.BeamSlab, 3, 12, 3, 28, 2, 36);
                    break;
                default:
                    // Create a blank model from template
                    ret = mySapModel.File.NewBlank();
                    break;
            }
        }

        // BtnOpen_Click - Open a new instance using the program ID
        private void BtnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                // Create an instance of the CSi object from the latest installed version
                mySapObject = myHelper.CreateObjectProgID(Programid);
                // Start CSi application
                ret = mySapObject.ApplicationStart();
                // Get a reference to cSapModel to access all API classes and functions
                mySapModel = mySapObject.SapModel;
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot start a new instance of the program.");
                return;
            }
        }

        // BtnOpenpath_Click - Open a new instance using the specified path
        private void BtnOpenpath_Click(object sender, EventArgs e)
        {
            try
            {
                // Create an instance from the specified path
                mySapObject = myHelper.CreateObject(ProgramPath);
            }
            catch (Exception)
            {
                // Handle exceptions silently here, as per original code
            }

            // Check if mySapObject was created
            if (mySapObject == null)
            {
                // Ask the user for a new program path
                MessageBox.Show("Cannot start a new instance of the program from " + ProgramPath);
                OpenFileDialog filedialogpath = new OpenFileDialog
                {
                    Filter = "Executable Files (*.exe)|*.exe",
                    Title = "Select the path for the Executable File"
                };
                filedialogpath.ShowDialog();
                if (filedialogpath.CheckPathExists)
                {
                    ProgramPath = filedialogpath.FileName;
                }
                // Try again to create mySapObject
                BtnOpenpath_Click(null, null);
                return;
            }

            // Start application
            ret = mySapObject.ApplicationStart();
            // Get a reference to cSapModel to access all API classes and functions
            mySapModel = mySapObject.SapModel;
        }

        // BtnAttach_Click - Attach to an active CSi instance
        private void BtnAttach_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the active SapObject
                mySapObject = myHelper.GetObject(Programid);
                // Get a reference to cSapModel to access all API classes and functions
                mySapModel = mySapObject.SapModel;
            }
            catch (Exception)
            {
                MessageBox.Show("No running instance of the program found or failed to attach.");
                return;
            }
        }

        // BtnClose_Click - Close CSi Software
        private void BtnClose_Click(object sender, EventArgs e)
        {
            // Close CSi Software
            mySapObject.ApplicationExit(false);

            // Clean up variables
            mySapModel = null;
            mySapObject = null;

            // Check ret value
            if (ret == 0)
            {
                MessageBox.Show("API script completed successfully.");
            }
            else
            {
                MessageBox.Show("API script FAILED to complete.");
            }
        }

        // CBPrograms_SelectedValueChanged - Update path and program ID based on selected program
        private void CBPrograms_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            switch (cb.SelectedItem.ToString())
            {
                case "ETABS":
                    Programid = "CSI.ETABS.API.ETABSObject";
                    ProgramPath = @"C:\Program Files\Computers and Structures\ETABS 22\ETABS.exe";
                    break;
                case "SAP2000":
                    Programid = "CSI.SAP2000.API.SapObject";
                    ProgramPath = @"C:\Program Files\Computers and Structures\SAP2000 26\SAP2000.exe";
                    break;
                case "CSiBridge":
                    Programid = "CSI.CSIBRIDGE.API.SapObject";
                    ProgramPath = @"C:\Program Files\Computers and Structures\CSiBridge 26\CSiBridge.exe";
                    break;
                case "SAFE":
                    Programid = "CSI.SAFE.API.ETABSObject";
                    ProgramPath = @"C:\Program Files\Computers and Structures\SAFE 22\SAFE.exe";
                    break;
            }
        }

        // Form1_Load - Initialize helper and set default program
        private void Form1_Load(object sender, EventArgs e)
        {
            // Select ETABS as default working program
            CBPrograms.SelectedIndex = 0;

            // Create API helper object
            try
            {
                myHelper = new CSiAPIv1.Helper();
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot create an instance of the Helper object");
                return;
            }
        }
    }
}
