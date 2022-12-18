using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace D2R_MULTILAUNCHER
{
    public delegate void frmMasterPasswordVerificatorOKEventHandler(string password);
    public delegate void frmMasterPasswordVerificatorCancelEventHandler();

    public partial class frmMasterPasswordVerificator : Form
    {
        private frmMainWindow _frmMainWindow;

        public event frmMasterPasswordVerificatorOKEventHandler OnMasterPasswordAuthenticated;
        public event frmMasterPasswordVerificatorCancelEventHandler OnCancel;

        private string _Salt = null;
        private bool _UseMasterPassword = false;
        private byte[] _MasterPasswordHashedBytes;

        public frmMasterPasswordVerificator(
            String lSalt, 
            byte[] lMasterPasswordHashedBytes, 
            bool lUseMasterPassword)
        {
            InitializeComponent();

            _Salt = lSalt;
            _MasterPasswordHashedBytes = lMasterPasswordHashedBytes;
            _UseMasterPassword = lUseMasterPassword;
        }


        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (OnCancel != null)
                {
                    OnCancel();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnVerifyMasterPassword_Click(object sender, EventArgs e)
        {
            byte[] _VerifyMasterPasswordBytes = Encoding.UTF8.GetBytes(_Salt + txtPassword.Text);
            byte[] _VerifyMasterPasswordHashBytes;
            using (SHA512 shaM = SHA512.Create())
            {
                _VerifyMasterPasswordHashBytes = shaM.ComputeHash(_VerifyMasterPasswordBytes);

                if (!Helpers.ByteArrayCompare(_VerifyMasterPasswordHashBytes, _MasterPasswordHashedBytes))
                {
                    MessageBox.Show(this, "Password is invalid or do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    TopMost = false;
                    OpenMainWindow();
                }

                
            }
        }

        private void frmMasterPasswordVerificator_Load(object sender, EventArgs e)
        {

            if (_UseMasterPassword)
            {
                tmrBackgroundAnimation.Enabled = true;
            }
            else
            {
                OpenMainWindow();
            }

        }

        private void OpenMainWindow()
        {
            try
            {
                if (_frmMainWindow != null)
                {
                    if (!_frmMainWindow.IsDisposed) { _frmMainWindow.Dispose(); }
                    _frmMainWindow = null;
                }

                String Password = txtPassword.Text;
                txtPassword.Text = "";

                this.Hide();

                _frmMainWindow = new frmMainWindow(Password, _Salt);
                _frmMainWindow.FormClosed += _frmMainWindow_FormClosed;
                _frmMainWindow.ShowDialog(this);

            }
            catch { }
        }

        private void _frmMainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (_frmMainWindow!=null)
                {
                    if (!_frmMainWindow.IsDisposed) { _frmMainWindow.Dispose();  }
                }

                Application.Exit();
            }
            catch {
            }
            
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                btnVerifyMasterPassword_Click(btnVerifyMasterPassword, new EventArgs());
            }
        }

        private void btnResetMasterPassword_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                this, 
                "Are you sure that you want to reset your Master Password ?\r\n\r\n" + 
                    "This will also delete any saved account profile, and you will have to re-create "+
                    "each regular profiles or to set a new master password and then re-create each account profiles", 
                "Confirmation", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (System.IO.File.Exists(Application.StartupPath + "\\masterpassword.sha512"))
                    {
                        System.IO.File.Delete(Application.StartupPath + "\\masterpassword.sha512");
                    }
                }
                catch {  }

                MessageBox.Show(this, "The Master Password should be removed.\r\n\r\nThe application will now restart.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    MessageBox.Show(
                        "The Application failed to restart in Administrator Mode.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                Application.Exit();
                return;
            }
        }

        int index_color = 9;

        private void tmrBackgroundAnimation_Tick(object sender, EventArgs e)
        {
            try
            {
                if (index_color >= 48) { index_color = 9; }

                if (index_color >= 9 && index_color <= 18)
                {
                    panel1.BackColor = System.Drawing.Color.FromArgb(index_color * 5, 0, 0);
                }
                else if (index_color >= 19 && index_color <= 24)
                {
                    panel1.BackColor = System.Drawing.Color.FromArgb(index_color * 5, index_color * 2, 0);
                }
                else if (index_color >= 25 && index_color <= 30)
                {
                    panel1.BackColor = System.Drawing.Color.FromArgb((48 - index_color) * 5, (48 - index_color) * 2, 0);
                }
                else if (index_color >= 31 && index_color <= 39)
                {
                    panel1.BackColor = System.Drawing.Color.FromArgb((48 - index_color) * 5, 0, 0);
                }

                index_color++;
            }
            catch { }
        }
    }
}
