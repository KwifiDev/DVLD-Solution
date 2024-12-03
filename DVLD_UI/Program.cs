using DVLD_BL;
using System;
using System.Windows.Forms;
using static System.Configuration.ConfigurationManager;

namespace DVLD_UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ClsBL_Settings.SetConnectionString(ConnectionStrings["DBConnection"]?.ConnectionString);
            Application.Run(new FRMLogin());
            //Application.Run(new FRMDebug());

        }
    }
}
