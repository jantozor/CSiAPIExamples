using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAP2000v1;

namespace CSiC_Example_SAP2000_Net_Framework
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

            // Create a 3D frame model from template
            ret = mySapModel.File.New3DFrame(e3DFrameType.BeamSlab, 3, 12, 3, 28, 2, 36);
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

        // Form1_Load - Initialize helper and set default program
        private void Form1_Load(object sender, EventArgs e)
        {
            // Set Path and program id
            Programid = "CSI.SAP2000.API.SapObject";
            ProgramPath = @"C:\Program Files\Computers and Structures\SAP2000 26\SAP2000.exe";

            // Create API helper object
            try
            {
                myHelper = new SAP2000v1.Helper();
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot create an instance of the Helper object");
                return;
            }
        }
    }
}
