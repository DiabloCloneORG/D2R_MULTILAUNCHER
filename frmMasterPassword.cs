using System;
using System.Windows.Forms;


namespace D2R_MULTILAUNCHER
{
    public delegate void frmMasterPasswordOKEventHandler(string password);
    public delegate void frmMasterPasswordCancelEventHandler();

    public partial class frmMasterPassword : Form
    {

        public event frmMasterPasswordOKEventHandler OnCreateMasterPassword;
        public event frmMasterPasswordCancelEventHandler OnCancel;

        public frmMasterPassword()
        {
            InitializeComponent();
        }


        private void txtProfileName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtProfileName_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue > 64 && e.KeyValue < 91 && !e.Shift && !e.Control && !e.Alt) ||
                (e.KeyValue > 64 && e.KeyValue < 91 && e.Shift && !e.Control && !e.Alt) ||
                (e.KeyValue > 47 && e.KeyValue < 58 && !e.Shift && !e.Control && !e.Alt) ||
                (e.KeyValue == 8 && !e.Shift && !e.Control && !e.Alt) ||
                (e.KeyValue == 37 && !e.Shift && !e.Control && !e.Alt) ||
                (e.KeyValue == 39 && !e.Shift && !e.Control && !e.Alt))
            {
            }
            else
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                return;
            }
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

        private void btnCreateMasterPassword_Click(object sender, EventArgs e)
        {
            string MasterPassword = txtPassword.Text.Trim();

            if (MasterPassword.Length < 12 || MasterPassword.Length > 100)
            {
                MessageBox.Show(this, "You must enter a valid master password, between 12 and 100 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (OnCreateMasterPassword != null)
            {
                OnCreateMasterPassword(MasterPassword);
            }

            this.Close();
        }

        private void frmMasterPassword_Load(object sender, EventArgs e)
        {

        }

        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar != '*')
            {
                txtPassword.PasswordChar = '*';
                btnShowHidePassword.Text = "Show";
            }
            else
            {
                txtPassword.PasswordChar = '\0';
                btnShowHidePassword.Text = "Hide";
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCreateMasterPassword_Click(btnCreateMasterPassword, new EventArgs());
            }
        }
    }
}
