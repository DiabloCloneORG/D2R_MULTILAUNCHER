using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Security.Cryptography;

namespace D2R_MULTILAUNCHER
{
    public partial class frmMainWindow : Form
    {
        private string _MasterPassword = null;
        private bool _UseMasterPassword = false; 
        private string _Salt = null;

        private frmAccountCreate _frmAccountCreate;
        private List<AccountInfo> _AccountProfiles;


        

        Thread threadWaitForWindowTitleRenaming;


        public frmMainWindow(string lMasterPassword, string lSalt)
        {
            InitializeComponent();

            _MasterPassword = lMasterPassword;
            _Salt = lSalt;
        }

        private void frmMainWindow_Load(object sender, EventArgs e)
        {
            

            addApplicationLog("D2R MULTILAUNCHER TOOL v" + Application.ProductVersion + " is starting...", true);

            this.Text = "DiabloClone.ORG - D2R MULTI LAUNCHER - Version: " + Application.ProductVersion;

            #region SALT
            _Salt = Helpers.getCurrentUniqueSeed();
            if (String.IsNullOrEmpty(_Salt))
            {
                MessageBox.Show(this, "The Application failed to create an salt file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }
            Console.WriteLine("SALT: " + _Salt);
            #endregion

            if (File.Exists(Application.StartupPath+"\\masterpassword.sha512"))
            {
                _UseMasterPassword = true;
            }
            else
            {
                _UseMasterPassword = false;
            }

            if (_UseMasterPassword)
            {
                try
                {
                    addApplicationLog("Loading Account(s).", true);

                    ReloadAccountProfiles();
                }
                catch { }


                btnCreateAccount.Visible = true;
                btnCreateAccount.Enabled = true;
                btnRemoveAccount.Visible = false;
                btnRemoveAccount.Enabled = false;
                btnStartAccount.Visible = false;
                btnStartAccount.Enabled = false;

            }
            else
            {
                btnMasterPassword_Click(btnMasterPassword, new EventArgs());
            }

            ddRealm.SelectedIndex = 0;

            addApplicationLog("D2R MULTILAUNCHER TOOL is ready for use", true);
        }


        private void ReloadAccountProfiles()
        {
            if (lstProfiles.InvokeRequired)
            {
                lstProfiles.Invoke(new MethodInvoker(() => { ReloadAccountProfiles(); }));
                return;
            }

            try
            {
                addApplicationLog("ReloadAccountProfiles()::start");

                _AccountProfiles = Helpers.getAccountProfiles(_MasterPassword, _Salt);
                addApplicationLog("ReloadAccountProfiles()::account detected: " + _AccountProfiles.Count.ToString());

                lstProfiles.Items.Clear();
                foreach (AccountInfo account in _AccountProfiles)
                {
                    try
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = account.ProfileName;
                        addApplicationLog("ReloadAccountProfiles()::loading account : " + account.ProfileName.ToLowerInvariant());
                        lstProfiles.Items.Add(lvi);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                addApplicationLog("ReloadAccountProfiles()::end");
            }
            catch { }
        }

       

        private void StartGameWithAccountProfile(AccountInfo accountInfo)
        {
            try
            {
                if (!File.Exists(Application.StartupPath + "\\" + accountInfo.ProfileName + ".encrypted"))
                {
                    addApplicationLog("The provided account (" + accountInfo.ProfileName + ") do not seem to exist on disk. Maybe it was deleted manually ?");
                    return;
                }

                addApplicationLog("Launching Game (D2R.exe) with account: " + accountInfo.ProfileName);

                string realm = "us"; // default
                switch (ddRealm.SelectedIndex)
                {
                    case 0: { realm = "us"; break; }
                    case 1: { realm = "eu"; break; }
                    case 2: { realm = "kr"; break; }
                    default: { realm = "us"; break; }
                }

                Process gameProcess = Helpers.LaunchGame(
                    (optArgumentsDirectTxt.Checked ? " -direct -txt " : "") +
                    (optArgumentsNoSound.Checked ? " -ns -nosound " : "") +
                    (optArgumentsLowQuality.Checked ? " -lq " : "") +
                    (optArgumentsWindowed.Checked ? " -lq " : "") +
                    " -username " + accountInfo.EmailAddress+ " -password "+ accountInfo.Password+ " -address " + realm + ".actual.battle.net ");

                addApplicationLog("New D2R Process ID: " + gameProcess.Id.ToString());

                if (chkChangeWindowTitle.Checked)
                {
                    addApplicationLog("Changing D2R windows title to : " + accountInfo.ProfileName);

                    RenameD2RWindowWithDelayThreadSafe(gameProcess.Id, accountInfo.ProfileName, 7000);
                }

                addApplicationLog("D2R was started and should be running for profile : " + accountInfo.ProfileName);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RenameD2RWindowWithDelayThreadSafe(int PID, string WindowTitle, int DelayMilliseconds)
        {
            addApplicationLog("WaitDelayForWindowTitleRenamingThreadSafe();");
            if (threadWaitForWindowTitleRenaming != null)
            {
                try { threadWaitForWindowTitleRenaming.Abort(); } catch { }
                try { threadWaitForWindowTitleRenaming = null; } catch { }
            }

            object[] parameters = {
                PID.ToString(),
                WindowTitle,
                DelayMilliseconds.ToString()
            };

            addApplicationLog("Starting Thread for WaitDelayForWindowTitleRenamingThreadSafe();");
            threadWaitForWindowTitleRenaming = new Thread(new ParameterizedThreadStart(_threadedRenameD2RWindowWithDelayThreadSafe));
            threadWaitForWindowTitleRenaming.Start(parameters);
        }

        private void _threadedRenameD2RWindowWithDelayThreadSafe(object obj)
        {
            addApplicationLog("_threadedRenameD2RWindowWithDelayThreadSafe();");

            // Grab our parameters back
            object[] parameters = (object[])obj;

            // Attempt to grab a reference to the provided process by the given PID.
            Process gameProcess = null;
            int PID = Convert.ToInt32(parameters[0]);
            string WindowTitle = (string)parameters[1];
            int DelayMilliseconds = Convert.ToInt32(parameters[2]);
            
            if (DelayMilliseconds > 0)
            {
                Thread.Sleep(DelayMilliseconds);
            }

            try
            {
                gameProcess = Process.GetProcessById(PID);
                if (!gameProcess.HasExited)
                {
                    Helpers.SetWindowText(gameProcess.MainWindowHandle, WindowTitle);
                }
            }
            catch (ArgumentException aex)
            { // If for some reason this process do not exist or has died, let return immediately,
                addApplicationLog("_threadedRenameD2RWindowWithDelayThreadSafe failed to access gameProcess PID.");
                return;
            }
        }


        private void addApplicationLog(string logdata, bool force = false)
        {
            try
            {
                if (txtApplicationLogs.InvokeRequired)
                {
                    txtApplicationLogs.Invoke(new MethodInvoker(() => { addApplicationLog(logdata); }));
                    return;
                }

                if (!chkVerbose.Checked && !force)
                {
                    return;
                }

                int limit = 32768;
                txtApplicationLogs.Text += "[" + DateTime.Now.ToShortTimeString() + "] " + logdata + "\r\n";
                if (txtApplicationLogs.TextLength> limit)
                {
                    txtApplicationLogs.Text = txtApplicationLogs.Text.Substring(txtApplicationLogs.TextLength - limit, limit);
                }
                
                txtApplicationLogs.Select(txtApplicationLogs.TextLength, 0);
                txtApplicationLogs.ScrollToCaret();


            }
            catch (Exception ex) { }
        }

        

        










        private void lstProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if  (lstProfiles.Items.Count>0)
            {

                if (_UseMasterPassword)
                {
                    btnRemoveAccount.Visible = (lstProfiles.SelectedItems.Count > 0);
                    btnRemoveAccount.Enabled = (lstProfiles.SelectedItems.Count > 0);
                    btnStartAccount.Visible = (lstProfiles.SelectedItems.Count > 0);
                    btnStartAccount.Enabled = (lstProfiles.SelectedItems.Count > 0);
                }

                

                return;
            }
            btnRemoveAccount.Visible = false;
            btnStartAccount.Visible = false;
        }


        private void chkKeepOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = ((CheckBox)sender).Checked;
        }

        private void chkVerbose_CheckedChanged(object sender, EventArgs e)
        {
            this.Size = ((CheckBox)sender).Checked ? (new Size(650, 655)) : (new Size(650, 330));
        }


        frmMasterPassword _frmMasterPasswordCreate;


        private void _frmMasterPasswordCreate_OnCreateMasterPassword(string password)
        {
            #region Writing the Salted Password Hash to Disk
            byte[] _MasterPasswordBytes = Encoding.UTF8.GetBytes(_Salt + password);
            byte[] _MasterPasswordHashBytes;
            using (SHA512 shaM = new SHA512Managed())
            {
                _MasterPasswordHashBytes = shaM.ComputeHash(_MasterPasswordBytes);

                System.IO.File.WriteAllBytes(Application.StartupPath + "\\masterpassword.sha512", _MasterPasswordHashBytes);
            }

            MessageBox.Show(this, "The Master Password was set successfully.\r\n\r\nThe application will now restart and require your password at startup from now on.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            #endregion

            #region Delete all previous Profile format files.
            try
            {
                var profile_directory_info = new DirectoryInfo(Application.StartupPath);
                foreach (var file in profile_directory_info.EnumerateFiles("*.profile"))
                {
                    try
                    {
                        file.Delete();
                    }
                    catch { }
                }
            }
            catch { }
            #endregion

            #region Restarting the Application in Administrator Mode.
            try
            {
                // Restart program and run as admin
                var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                startInfo.Verb = "runas";
                System.Diagnostics.Process.Start(startInfo);
            }
            catch
            {
                MessageBox.Show(this, "The Application failed to restart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Application.Exit();
            #endregion

            return;
        }

        private void _frmMasterPasswordCreate_OnCancel()
        {
            try
            {
                if (_frmMasterPasswordCreate != null)
                {
                    if (!_frmMasterPasswordCreate.IsDisposed) 
                    { 
                        _frmMasterPasswordCreate.Dispose(); 
                    }
                    _frmMasterPasswordCreate = null;
                }


            }
            catch { }


        }


        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (_frmAccountCreate != null)
                {
                    _frmAccountCreate.Dispose();
                    _frmAccountCreate = null;
                }

                _frmAccountCreate = new frmAccountCreate();
                _frmAccountCreate.OnCreateAccount += _frmAccountCreate_OnCreateAccount;
                _frmAccountCreate.OnCancel += _frmAccountCreate_OnCancel;
                _frmAccountCreate.ShowDialog(this);
            }
            catch { }
        }

        private void _frmAccountCreate_OnCancel()
        {
            try
            {
                if (_frmAccountCreate != null)
                {
                    _frmAccountCreate.Dispose();
                    _frmAccountCreate = null;
                }
                addApplicationLog("Account creation was cancelled by the user.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception (_frmAccountCreate_OnCancel): " + ex.Message);
            }
        }

        private void _frmAccountCreate_OnCreateAccount(string profileName, string email, string password)
        {
            try
            {
                if (_frmAccountCreate != null)
                {
                    _frmAccountCreate.Close();
                    _frmAccountCreate.Dispose();
                    _frmAccountCreate = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception (_frmAccountCreate_OnCreateAccount): " + ex.Message);
            }

            try
            {
                AccountInfo account = new AccountInfo()
                {
                    ProfileName = profileName,
                    EmailAddress = email,
                    Password = password
                };
                account.generateNewIV();

                account.WriteToBinaryFile(
                    Application.StartupPath + "\\" + profileName.ToLowerInvariant() + ".encrypted", 
                    _MasterPassword, 
                    _Salt, 
                    false);
                addApplicationLog("Account saved to disk: " + profileName + ".");

                addApplicationLog("Reloading Accounts."); 
                
                ReloadAccountProfiles();

                MessageBox.Show(this, 
                    "The Account was created with success.\r\n\r\n"+
                    "",
                    "Confirmation", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception (_frmAccountCreate_OnCreateAccount): " + ex.Message);
            }

            addApplicationLog("Account created: " + profileName + ".");
        }

        private void btnStartAccount_Click(object sender, EventArgs e)
        {
            if (lstProfiles.Items.Count > 0)
            {
                if (lstProfiles.SelectedItems.Count > 0)
                {
                    String SelectedProfileName = lstProfiles.SelectedItems[0].Text;
                    AccountInfo accountInfo = null;
                    for (int index = 0; index < _AccountProfiles.Count; index++)
                    {
                        if (_AccountProfiles[index].ProfileName.ToLowerInvariant() == SelectedProfileName.ToLowerInvariant())
                        {
                            accountInfo = _AccountProfiles[index];
                            break;
                        }
                    }

                    if (accountInfo == null) { return; }


                    try
                    {
                        Helpers.killAllBnetLaunchers();
                        Helpers.KillAllD2RInstanceCheckerHandle();
                        StartGameWithAccountProfile(accountInfo);
                    }
                    catch (Exception ex) 
                    {
                        addApplicationLog("KillD2RInstanceChecker -> Exception occured -> " + ex.Message);
                        addApplicationLog("Please retry the operation, if it does fail, please check the logs for possible errors.");
                    }
                }
            }
        }



        private void btnRemoveAccount_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstProfiles.Items.Count > 0)
                {
                    if (lstProfiles.SelectedItems.Count > 0)
                    {
                        DialogResult dr = MessageBox.Show(this, "Are you sure that you want to remove the selected account: " + lstProfiles.SelectedItems[0].Text, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            String ProfileName = lstProfiles.SelectedItems[0].Text;
                            try
                            {
                                File.Delete(Application.StartupPath + "\\" + ProfileName + ".encrypted");
                                lstProfiles.SelectedItems[0].Remove();

                                MessageBox.Show(this, "Removed account: " + ProfileName, "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch { }
                        }
                    }
                }
            }
            catch { }
        }


        private void btnMasterPassword_Click(object sender, EventArgs e)
        {
            StringBuilder sb_msg = new StringBuilder();
            sb_msg.AppendLine("To be able to save your battle accounts and passwords securely, " +
                "using industry best practices, encryption and password hashing, the Application need you " +
                "to configure a Master Password, that will be required everytime you load the application to " +
                "decrypt your Battle.Net Accounts and Password and identify yourself as the owner of these account.");
            sb_msg.AppendLine("");
            sb_msg.AppendLine("IMPORTANT: If you do lose this password, change it (altering files) or else, you will need to recreate all Account Profile, one by one because the saved encrypted data will become unreadable.");
            sb_msg.AppendLine("");
            sb_msg.AppendLine("Do you want to continue ?");

            DialogResult dr = MessageBox.Show(this, sb_msg.ToString(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (File.Exists(Application.StartupPath + "\\masterpassword.hash"))
                    {
                        try
                        {
                            File.Delete(Application.StartupPath + "\\masterpassword.hash");
                        }
                        catch
                        {
                            MessageBox.Show(this, "There was an error while trying to delete the " +
                                "master password file from the disk... Operation Aborted !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (_frmMasterPasswordCreate != null)
                    {
                        if (!_frmMasterPasswordCreate.IsDisposed) { _frmMasterPasswordCreate.Dispose(); }
                        _frmMasterPasswordCreate = null;
                    }
                    _frmMasterPasswordCreate = new frmMasterPassword();
                    _frmMasterPasswordCreate.OnCancel += _frmMasterPasswordCreate_OnCancel;
                    _frmMasterPasswordCreate.OnCreateMasterPassword += _frmMasterPasswordCreate_OnCreateMasterPassword;
                    _frmMasterPasswordCreate.ShowDialog(this);
                }
                catch { }
            }
            else
            {
            }
        }

        private void btnDiscord_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/FQrpzV8Smv");
        }

        private void linkHelpUnpackingD2R_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://tinyurl.com/d2faster");
        }
    }
}