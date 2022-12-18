using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Versioning;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D2R_MULTILAUNCHER
{
    static class Program
    {
        static string _Salt = null;
        static bool _UseMasterPassword = false;
        static byte[] _MasterPasswordHash = null;

        [SupportedOSPlatform("windows")]
        private static bool IsAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        [SupportedOSPlatform("windows")]
        static void Main()
        {

            if (IsAdministrator() == false && !Debugger.IsAttached)
            {
                try
                {
                    // Restart program and run as admin
                    // var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                    var exeName = Application.ExecutablePath;

                    ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                    startInfo.UseShellExecute = true;
                    startInfo.Verb = "runas";
                    
                    System.Diagnostics.Process.Start(startInfo);
                }
                catch
                {
                    MessageBox.Show(
                        "The Application failed to restart in Administrator Mode.", 
                        "Error", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }

                Application.Exit();
                return;
            }


            #region SALT
            _Salt = Helpers.getCurrentUniqueSeed();
            if (String.IsNullOrEmpty(_Salt))
            {
                MessageBox.Show(
                    "The Application failed to create an salt file.", 
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            #endregion

            #region MASTER PASSWORD VERIFICATION
            
            _UseMasterPassword = System.IO.File.Exists(Application.StartupPath + "\\masterpassword.sha512");
            if (_UseMasterPassword)
            {
                _MasterPasswordHash = System.IO.File.ReadAllBytes(Application.StartupPath + "\\masterpassword.sha512");
            }
            else
            {
                _MasterPasswordHash = null;
            }

            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMasterPasswordVerificator(_Salt, _MasterPasswordHash, _UseMasterPassword));
            #endregion


        }
    }
}
