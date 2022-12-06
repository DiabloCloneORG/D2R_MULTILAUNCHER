using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using handles;
using Microsoft.Win32.SafeHandles;

namespace D2R_MULTILAUNCHER
{
    public delegate void frmAccountCreateOKEventHandler(string profilename, string email, string password);
    public delegate void frmAccountCreateCancelEventHandler();

    public partial class frmAccountCreate : Form
    {

        public event frmAccountCreateOKEventHandler OnCreateAccount;
        public event frmAccountCreateCancelEventHandler OnCancel;

        public frmAccountCreate()
        {
            InitializeComponent();
        }

        bool IsValidEmail(string email)
        {
            if (email.Trim().EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnCreateD2RProfile_Click(object sender, EventArgs e)
        {
            string ProfileName = txtProfileName.Text.Trim();
            string EmailAddress = txtEmailAddress.Text.Trim();
            string Password = txtPassword.Text.Trim();

            if (txtProfileName.TextLength < 1 || txtProfileName.TextLength > 12)
            {
                MessageBox.Show(this, "You must enter a valid profile name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fullpathname = Application.StartupPath + "\\" + ProfileName + ".profile";
            if (File.Exists(fullpathname))
            {
                MessageBox.Show(this, "The profile name already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtEmailAddress.TextLength < 5 || txtEmailAddress.TextLength > 321)
            {
                MessageBox.Show(this, "You must enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!IsValidEmail(txtEmailAddress.Text))
            {
                MessageBox.Show(this, "You must enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPassword.TextLength < 1 || txtPassword.TextLength > 100)
            {
                MessageBox.Show(this, "You must enter a password, between 1 to 100 characters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (OnCreateAccount!=null)
            {
                OnCreateAccount(ProfileName, EmailAddress, Password);
            }

            this.Close();
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

        private void frmAccountCreate_Load(object sender, EventArgs e)
        {

        }

        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar!='*')
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
    }
}
