using System;
using System.Windows.Forms;
using MTAStudentManagementSystem.DAO;
using MTAStudentManagementSystem.GUI.Forms;

namespace MTAStudentManagementSystem
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            DataProvider.TestConnection();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FDashboard());
        }
    }
}