using CSiAPIv1;

namespace CSiC_Example_Plugin_NET
{
    // Implementing the cPluginContract interface is not required, however
    // it is recommended to ensure that the required cPlugin methods are created correctly.
    // Do not implement the Info or Main methods explicitly,
    // i.e. their method signatures are correct as is
    public class cPlugin : cPluginContract
    {
        private int errorCode = 0; // default return code is no error
        public int Info(ref string Text)
        {
            try
            {
                Text = "This ready to use plugin serves as a simple example for developers creating new plugins " +
                    "for CSI products. \n\nFor more information, visit:\n\n" + "https://github.com/jantozor/CSiAPIExamples.";
            }
            catch (Exception)
            {
            }

            return 0;
        }

        public void Main(ref cSapModel SapModel, ref cPluginCallback ISapPlugin)
        {
            Form1 form = new Form1();
            try
            {
                bool modal = true;
                form.SetSapModel(ref SapModel, ref ISapPlugin);

                if (modal)
                {
                    // Modal form, will not return to CSI program until form is closed,
                    // but may cause errors when refreshing the view.                    
                    form.ShowDialog();
                }
                else
                {
                    // Non-modal form, allows graphics refresh operations in CSI program, 
                    // but Main will return to CSI program before the form is closed.
                    form.Show();
                }

                // It is very important to call pluginCallback.Finish(errorCode) when the form closes, !!!
                // otherwise, the CSI program will wait and be hung !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                // This must be done inside the closing event for the form itself, not here !!!!!!!!!!!!!!

                // If you have only algorithmic code here without any forms, 
                // then call pluginCallback.Finish(errorCode) here before returning to the CSI program

                // errorCode = 0 indicates that the plugin completed successfully
                // ie pluginCallback.Finish(0)
                // errorCode = (Any non-zero integer) indicates that the plugin closed with an error
                // ie pluginCallback.Finish(1)
                // If an error occurs, the errorCode value will be displayed
                // to the plugin end-user in a message box, for debugging purposes.

                // If your code will run for more than a few seconds, you should exercise
                // the Windows messaging loop to keep the program responsive. You may 
                // also want to provide an opportunity for the user to cancel operations.
            }
            catch (Exception ex)
            {
                errorCode = 1;
                MessageBox.Show("The following error terminated the plugin:" + Environment.NewLine + ex.Message);

                // call Finish to inform the CSI program that the plugin has terminated
                try
                {
                    ISapPlugin.Finish(errorCode); // error code 1 will be visible to plugin end-user for debugging purposes
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
