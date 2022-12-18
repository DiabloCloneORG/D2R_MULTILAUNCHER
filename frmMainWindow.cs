using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Security.Cryptography;
using System.Runtime.Versioning;
using System.Configuration;

namespace D2R_MULTILAUNCHER
{
    public partial class frmMainWindow : Form
    {
        private string _MasterPassword = null;
        private bool _UseMasterPassword = false; 
        private string _Salt = null;

        private frmAccountCreate _frmAccountCreate;
        private List<AccountInfo> _AccountProfiles;

        private ConfigurationEntity _configuration;

        private frmItemNameAffixesEditor _frmItemNameAffixesEditor;
        private frmItemNamesEditor _frmItemNamesEditor;
        private frmItemRunesEditor _frmItemRunesEditor;

        private frmItemFilterTemplateEdit _frmItemFilterTemplateEdit;

        Thread threadWaitForWindowTitleRenaming;


        public frmMainWindow(string lMasterPassword, string lSalt)
        {
            InitializeComponent();

            _MasterPassword = lMasterPassword;
            _Salt = lSalt;

            _configuration = new ConfigurationEntity();
        }

        private void frmMainWindow_Load(object sender, EventArgs e)
        {
            

            addApplicationLog("D2R MULTILAUNCHER TOOL v" + Application.ProductVersion + " is starting...", true);

            this.Text = "DiabloClone.ORG - D2R MULTI LAUNCHER - Version: " + Application.ProductVersion;

            #region Loading Configuration Entity
            _configuration.ReadConfiguration();
            if (_configuration == null)
            {
                _configuration = new ConfigurationEntity();
                _configuration.SaveConfiguration();
            }
            #endregion

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

            LoadConfigurationData();

            if (_configuration.UseItemFilter)
            {
                List<ItemFilterEnhancedEntity> _entities = new List<ItemFilterEnhancedEntity>();
                string item_jsondata = null;
                item_jsondata = System.IO.File.ReadAllText(Application.StartupPath + @"\item-names-enhanced.json");
                _entities.Clear();
                _entities = JsonSerializer.Deserialize<List<ItemFilterEnhancedEntity>>(item_jsondata);
                Helpers.saveItemsFilterDataFile(_configuration, _entities, "item-names.json", "item-names-enhanced.json");

                item_jsondata = System.IO.File.ReadAllText(Application.StartupPath + @"\item-nameaffixes-enhanced.json");
                _entities.Clear();
                _entities = JsonSerializer.Deserialize<List<ItemFilterEnhancedEntity>>(item_jsondata);
                Helpers.saveItemsFilterDataFile(_configuration, _entities, "item-nameaffixes.json", "item-nameaffixes-enhanced.json");

                item_jsondata = System.IO.File.ReadAllText(Application.StartupPath + @"\item-runes-enhanced.json");
                _entities.Clear();
                _entities = JsonSerializer.Deserialize<List<ItemFilterEnhancedEntity>>(item_jsondata);
                Helpers.saveItemsFilterDataFile(_configuration, _entities, "item-runes.json", "item-runes-enhanced.json");
            }

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


        [SupportedOSPlatform("windows")]
        private void StartGameWithAccountProfile(AccountInfo accountInfo)
        {
            try
            {
                if (!File.Exists(Application.StartupPath + "\\" + accountInfo.ProfileName + ".encrypted.json"))
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
                    (optArgumentsWindowed.Checked ? " -w " : "") +
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
                // try { threadWaitForWindowTitleRenaming.Abort(); } catch { }
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
                addApplicationLog("_threadedRenameD2RWindowWithDelayThreadSafe failed to access gameProcess PID.\r\nMessage:"+aex.Message);
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

                int limit = 32768;
                txtApplicationLogs.Text += "[" + DateTime.Now.ToShortTimeString() + "] " + logdata + "\r\n";
                if (txtApplicationLogs.TextLength> limit)
                {
                    txtApplicationLogs.Text = txtApplicationLogs.Text.Substring(txtApplicationLogs.TextLength - limit, limit);
                }
                
                txtApplicationLogs.Select(txtApplicationLogs.TextLength, 0);
                txtApplicationLogs.ScrollToCaret();


            }
            catch { }
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
            this.TopMost = chkKeepOnTop.Checked;

            _configuration.KeepMultiLauncherWindowOnTop = chkKeepOnTop.Checked;

            SaveConfiguration();
        }

        private void chkVerbose_CheckedChanged(object sender, EventArgs e)
        {
            this.Size = ((CheckBox)sender).Checked ? (new Size(650, 675)) : (new Size(650, 365));
        }


        frmMasterPassword _frmMasterPasswordCreate;


        private void _frmMasterPasswordCreate_OnCreateMasterPassword(string password)
        {
            #region Writing the Salted Password Hash to Disk
            byte[] _MasterPasswordBytes = Encoding.UTF8.GetBytes(_Salt + password);
            byte[] _MasterPasswordHashBytes;
            using (SHA512 shaM = SHA512.Create())
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
                    Application.StartupPath + "\\" + profileName.ToLowerInvariant() + ".encrypted.json", 
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

        [SupportedOSPlatform("windows")]
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
                                File.Delete(Application.StartupPath + "\\" + ProfileName + ".encrypted.json");
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

        private void LoadConfigurationData()
        {
            chkChangeWindowTitle.CheckedChanged -= chkChangeWindowTitle_CheckedChanged;
            chkChangeWindowTitle.Checked = _configuration.ChangeD2RWindowTitle;
            chkChangeWindowTitle.CheckedChanged += chkChangeWindowTitle_CheckedChanged;

            chkKeepOnTop.CheckedChanged -= chkKeepOnTop_CheckedChanged;
            chkKeepOnTop.Checked = _configuration.KeepMultiLauncherWindowOnTop;
            chkKeepOnTop.CheckedChanged += chkKeepOnTop_CheckedChanged;

            optArgumentsDirectTxt.CheckedChanged -= optArgumentsDirectTxt_CheckedChanged;
            optArgumentsDirectTxt.Checked = _configuration.UseDirectTxt;
            optArgumentsDirectTxt.CheckedChanged += optArgumentsDirectTxt_CheckedChanged;

            optArgumentsNoSound.CheckedChanged -= optArgumentsNoSound_CheckedChanged;
            optArgumentsNoSound.Checked = _configuration.UseNoSound;
            optArgumentsNoSound.CheckedChanged += optArgumentsNoSound_CheckedChanged;

            optArgumentsLowQuality.CheckedChanged -= optArgumentsLowQuality_CheckedChanged;
            optArgumentsLowQuality.Checked = _configuration.UseLowQuality;
            optArgumentsLowQuality.CheckedChanged += optArgumentsLowQuality_CheckedChanged;

            optArgumentsWindowed.CheckedChanged -= optArgumentsWindowed_CheckedChanged;
            optArgumentsWindowed.Checked = _configuration.UseWindowedMode;
            optArgumentsWindowed.CheckedChanged += optArgumentsWindowed_CheckedChanged;

            chkItemFilterEnabled.CheckedChanged -= chkItemFilterEnabled_CheckedChanged;
            chkItemFilterEnabled.Checked = _configuration.UseItemFilter;
            chkItemFilterEnabled.CheckedChanged += chkItemFilterEnabled_CheckedChanged;

            btnItemsFilterAffixes.Enabled = _configuration.UseItemFilter;
            btnItemsFilterNames.Enabled = _configuration.UseItemFilter;
            btnItemsFilterRunesNames.Enabled = _configuration.UseItemFilter;

            ddRealm.SelectedIndexChanged -= ddRealm_SelectedIndexChanged;
            ddRealm.SelectedIndex = _configuration.DefaultRealmIndex;
            ddRealm.SelectedIndexChanged += ddRealm_SelectedIndexChanged;
        }

        private void SaveConfiguration()
        {
            #region Saving Configuration Entity
            if (_configuration == null)
            {
                _configuration = new ConfigurationEntity();
            }
            _configuration.SaveConfiguration();
            #endregion
        }

        private void chkChangeWindowTitle_CheckedChanged(object sender, EventArgs e)
        {
            _configuration.ChangeD2RWindowTitle = chkChangeWindowTitle.Checked;
            
            SaveConfiguration();
        }

        private void optArgumentsDirectTxt_CheckedChanged(object sender, EventArgs e)
        {
            _configuration.UseDirectTxt = optArgumentsDirectTxt.Checked;

            SaveConfiguration();
        }

        private void optArgumentsNoSound_CheckedChanged(object sender, EventArgs e)
        {
            _configuration.UseNoSound = optArgumentsNoSound.Checked;

            SaveConfiguration();
        }

        private void optArgumentsLowQuality_CheckedChanged(object sender, EventArgs e)
        {
            _configuration.UseLowQuality = optArgumentsLowQuality.Checked;

            SaveConfiguration();
        }

        private void optArgumentsWindowed_CheckedChanged(object sender, EventArgs e)
        {
            _configuration.UseWindowedMode = optArgumentsWindowed.Checked;

            SaveConfiguration();
        }

        private void chkItemFilterEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkItemFilterEnabled.Checked)
            {
                addApplicationLog("Disabling the Items Filter Mod System...");

                DialogResult dr = MessageBox.Show(this,
                    "If you disable the Item Filters, any previously customization will be lost and originals files will be restored.\r\n\r\n" + 
                    "We suggest that you backup your customization first, and then disable the Items Filter.\r\n\r\n" +
                    "Do you wish to proceed to disable the Items Filter ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.No)
                {
                    addApplicationLog("The User cancelled the disabling of the Items Filter Mod System.");
                    addApplicationLog("The Items Filter Mod System remain ENABLED.");

                    chkItemFilterEnabled.CheckedChanged -= chkItemFilterEnabled_CheckedChanged;
                    chkItemFilterEnabled.Checked = true;
                    chkItemFilterEnabled.CheckedChanged += chkItemFilterEnabled_CheckedChanged;
                    return;
                }

                addApplicationLog("The Items Filter Mod System is now DISABLED.");

                Helpers.restoreItemsFilterOriginalDataFiles();

                addApplicationLog("The Original Files used by The Items Filter Mod System has been restored.");
            }
            else
            {
                addApplicationLog("Enabling The Items Filter Mod System...");



                addApplicationLog("The Items Filter Mod System is now ENABLED.");
            }
            
            _configuration.UseItemFilter = chkItemFilterEnabled.Checked;

            SaveConfiguration();

            btnItemsFilterAffixes.Enabled = chkItemFilterEnabled.Checked;
            btnItemsFilterNames.Enabled = chkItemFilterEnabled.Checked;
            btnItemsFilterRunesNames.Enabled = chkItemFilterEnabled.Checked;

        }

        private void ddRealm_SelectedIndexChanged(object sender, EventArgs e)
        {
            _configuration.DefaultRealmIndex = ddRealm.SelectedIndex;

            SaveConfiguration();
        }

        private void btnItemsFilterAffixes_Click(object sender, EventArgs e)
        {
            if (_frmItemNameAffixesEditor!=null)
            {
                try
                {
                    _frmItemNameAffixesEditor.Dispose();
                    _frmItemNameAffixesEditor = null;
                }
                catch { }
            }

            _frmItemNameAffixesEditor = new frmItemNameAffixesEditor(_configuration);
            _frmItemNameAffixesEditor.ShowDialog(this);
        }

        private void btnItemsFilterNames_Click(object sender, EventArgs e)
        {
            if (_frmItemNamesEditor != null)
            {
                try
                {
                    _frmItemNamesEditor.Dispose();
                    _frmItemNamesEditor = null;
                }
                catch { }
            }

            _frmItemNamesEditor = new frmItemNamesEditor(_configuration);
            _frmItemNamesEditor.ShowDialog(this);
        }

        private void btnItemsFilterRunesNames_Click(object sender, EventArgs e)
        {
            if (_frmItemRunesEditor != null)
            {
                try
                {
                    _frmItemRunesEditor.Dispose();
                    _frmItemRunesEditor = null;
                }
                catch { }
            }

            _frmItemRunesEditor = new frmItemRunesEditor(_configuration);
            _frmItemRunesEditor.ShowDialog(this);
        }

        private void btnItemsFilterTemplates_Click(object sender, EventArgs e)
        {
            if (_frmItemFilterTemplateEdit != null)
            {
                try
                {
                    _frmItemFilterTemplateEdit.Dispose();
                    _frmItemFilterTemplateEdit = null;
                }
                catch { }
            }

            _frmItemFilterTemplateEdit = new frmItemFilterTemplateEdit(_configuration);
            _frmItemFilterTemplateEdit.onItemFilterTemplateUpdated += _frmItemFilterTemplateEdit_onItemFilterTemplateUpdated;
            _frmItemFilterTemplateEdit.ShowDialog(this);

            
        }

        private void _frmItemFilterTemplateEdit_onItemFilterTemplateUpdated(ConfigurationEntity updated_configuration)
        {
            updated_configuration.SaveConfiguration();

            _configuration = (ConfigurationEntity)updated_configuration.Clone();
        }
    }
}