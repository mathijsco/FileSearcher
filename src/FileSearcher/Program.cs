using System;
using System.Windows.Forms;
using FileSearcher.Helpers;
using FileSearcher.Ui;
using Microsoft.Win32;

namespace FileSearcher
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var argument = args.Length > 0 ? args[0] : string.Empty;

            // Install in registry
            if (argument.Equals("/i", StringComparison.OrdinalIgnoreCase) || argument.Equals("/install", StringComparison.OrdinalIgnoreCase))
            {
                if (UacUtility.Evaluate())
                    RegisterFolders();
                return;
            }
            // Remove from registry
            if (argument.Equals("/u", StringComparison.OrdinalIgnoreCase) || argument.Equals("/uninstall", StringComparison.OrdinalIgnoreCase))
            {
                if (UacUtility.Evaluate())
                    UnregisterFolders();
                return;
            }

            Application.Run(new MainForm(argument.Trim('"')));
        }

        private static void RegisterFolders()
        {
            Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\filesearcher", "", "Lost a file?", RegistryValueKind.String);
            Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\filesearcher\command", "", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
            Registry.SetValue(@"HKEY_CLASSES_ROOT\Directory\shell\filesearcher", "Icon", Application.ExecutablePath + ",0", RegistryValueKind.ExpandString);

            Registry.SetValue(@"HKEY_CLASSES_ROOT\Drive\shell\filesearcher", "", "Lost a file?", RegistryValueKind.String);
            Registry.SetValue(@"HKEY_CLASSES_ROOT\Drive\shell\filesearcher\command", "", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
            Registry.SetValue(@"HKEY_CLASSES_ROOT\Drive\shell\filesearcher", "Icon", Application.ExecutablePath + ",0", RegistryValueKind.ExpandString);
        }

        private static void UnregisterFolders()
        {
            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"Directory\shell", true))
            {
                if (key != null)
                    key.DeleteSubKeyTree("filesearcher");
            }

            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"Drive\shell", true))
            {
                if (key != null)
                    key.DeleteSubKeyTree("filesearcher");
            }
        }
    }
}
