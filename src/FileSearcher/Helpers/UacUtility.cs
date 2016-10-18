using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace FileSearcher.Helpers
{
    /// <summary>
    /// Utility to run the application with administrator permissions.
    /// </summary>
    internal static class UacUtility
    {
        /// <summary>
        /// Make sure that the application is run as administrator. if not, request it and restart the program.
        /// </summary>
        /// <returns>Return true if application is running as administrator, otherwise return false.</returns>
        public static bool Evaluate()
        {
            if (!IsRunAsAdministrator())
            {
                RerunAsAdministrator();
                return false;
            }

            return true;
        }

        private static bool IsRunAsAdministrator()
        {
            var wi = WindowsIdentity.GetCurrent();
            if (wi == null) return false;
            var wp = new WindowsPrincipal(wi);
            return wp.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private static void RerunAsAdministrator()
        {
            var args = Environment.GetCommandLineArgs();
            string arg = null;
            if (args.Length > 1)
                arg = "\"" + string.Join("\" \"", args.Skip(1)) + "\"";

            // It is not possible to launch a ClickOnce app as administrator directly, so instead we launch the
            // app as administrator in a new process.
            var processInfo = new ProcessStartInfo(Application.ExecutablePath, arg);

            // The following properties run the new process as administrator
            processInfo.UseShellExecute = true;
            processInfo.Verb = "runas";

            // Start the new process
            try
            {
                Process.Start(processInfo);
            }
            catch (Exception)
            {
                // The user did not allow the application to run as administrator
                MessageBox.Show(@"This action must be run with Administrator privileges.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Shut down the current process
            Application.Exit();
        }
    }
}
