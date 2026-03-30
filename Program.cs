using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Security.Principal;
using System.Diagnostics;

namespace frmdnschange
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // First: Check Administrator privileges
            if (!IsAdministrator())
            {
                // Request administrator privileges
                RestartAsAdministrator();
                return;
            }

            // Second: Check .NET Framework 3.5
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show check form
            CheckDotNetForm checkForm = new CheckDotNetForm();
            if (checkForm.ShowDialog() == DialogResult.OK)
            {
                // If check passed, show main form
                Application.Run(new Form1());
            }
        }

        /// <summary>
        /// Check if application is running with administrator privileges
        /// </summary>
        private static bool IsAdministrator()
        {
            try
            {
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Restart the application with administrator privileges
        /// </summary>
        private static void RestartAsAdministrator()
        {
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.FileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
                processInfo.UseShellExecute = true;
                processInfo.Verb = "runas";
                Process.Start(processInfo);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to run as administrator:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }
    }
}
