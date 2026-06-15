using CSiAPIv1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSiC_Example_Plugin_NET
{
    public partial class Form1 : Form
    {
        private cSapModel _sapModel;
        private cPluginCallback _pluginCallback;
        private int errorCode = 0; // default return code is no error
        public Form1()
        {
            InitializeComponent();
        }

        public void SetSapModel(ref cSapModel inSapModel, ref cPluginCallback inPluginCallback)
        {
            _sapModel = inSapModel;
            _pluginCallback = inPluginCallback;

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // It is very important to call _pluginCallback.Finish(errorCode) when the form closes, !!!
            // otherwise, the CSI program will wait and be hung !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            _pluginCallback.Finish(errorCode);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _sapModel.File.NewBlank();
        }
    }
}
