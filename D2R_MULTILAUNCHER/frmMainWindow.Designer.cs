
namespace D2R_MULTILAUNCHER
{
    partial class frmMainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainWindow));
            this.lstProfiles = new System.Windows.Forms.ListView();
            this.colProfileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtApplicationLogs = new System.Windows.Forms.TextBox();
            this.lblApplicationLogs = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optArgumentsWindowed = new System.Windows.Forms.CheckBox();
            this.optArgumentsLowQuality = new System.Windows.Forms.CheckBox();
            this.optArgumentsNoSound = new System.Windows.Forms.CheckBox();
            this.optArgumentsDirectTxt = new System.Windows.Forms.CheckBox();
            this.chkVerbose = new System.Windows.Forms.CheckBox();
            this.chkKeepOnTop = new System.Windows.Forms.CheckBox();
            this.chkChangeWindowTitle = new System.Windows.Forms.CheckBox();
            this.btnStartAccount = new System.Windows.Forms.Button();
            this.btnRemoveAccount = new System.Windows.Forms.Button();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.btnMasterPassword = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ddRealm = new System.Windows.Forms.ComboBox();
            this.btnDiscord = new System.Windows.Forms.Button();
            this.linkHelpUnpackingD2R = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstProfiles
            // 
            this.lstProfiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProfileName});
            this.lstProfiles.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstProfiles.FullRowSelect = true;
            this.lstProfiles.HideSelection = false;
            this.lstProfiles.Location = new System.Drawing.Point(15, 12);
            this.lstProfiles.MultiSelect = false;
            this.lstProfiles.Name = "lstProfiles";
            this.lstProfiles.Size = new System.Drawing.Size(188, 264);
            this.lstProfiles.TabIndex = 7;
            this.lstProfiles.UseCompatibleStateImageBehavior = false;
            this.lstProfiles.View = System.Windows.Forms.View.Details;
            this.lstProfiles.SelectedIndexChanged += new System.EventHandler(this.lstProfiles_SelectedIndexChanged);
            // 
            // colProfileName
            // 
            this.colProfileName.Text = "Profile Name";
            this.colProfileName.Width = 135;
            // 
            // txtApplicationLogs
            // 
            this.txtApplicationLogs.Location = new System.Drawing.Point(15, 322);
            this.txtApplicationLogs.Multiline = true;
            this.txtApplicationLogs.Name = "txtApplicationLogs";
            this.txtApplicationLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtApplicationLogs.Size = new System.Drawing.Size(601, 279);
            this.txtApplicationLogs.TabIndex = 13;
            // 
            // lblApplicationLogs
            // 
            this.lblApplicationLogs.AutoSize = true;
            this.lblApplicationLogs.Location = new System.Drawing.Point(12, 302);
            this.lblApplicationLogs.Name = "lblApplicationLogs";
            this.lblApplicationLogs.Size = new System.Drawing.Size(108, 17);
            this.lblApplicationLogs.TabIndex = 14;
            this.lblApplicationLogs.Text = "Application Logs";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkHelpUnpackingD2R);
            this.groupBox1.Controls.Add(this.optArgumentsWindowed);
            this.groupBox1.Controls.Add(this.optArgumentsLowQuality);
            this.groupBox1.Controls.Add(this.optArgumentsNoSound);
            this.groupBox1.Controls.Add(this.optArgumentsDirectTxt);
            this.groupBox1.Controls.Add(this.chkVerbose);
            this.groupBox1.Controls.Add(this.chkKeepOnTop);
            this.groupBox1.Controls.Add(this.chkChangeWindowTitle);
            this.groupBox1.Location = new System.Drawing.Point(397, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 209);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // optArgumentsWindowed
            // 
            this.optArgumentsWindowed.Checked = true;
            this.optArgumentsWindowed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optArgumentsWindowed.Location = new System.Drawing.Point(15, 179);
            this.optArgumentsWindowed.Name = "optArgumentsWindowed";
            this.optArgumentsWindowed.Size = new System.Drawing.Size(183, 22);
            this.optArgumentsWindowed.TabIndex = 25;
            this.optArgumentsWindowed.Text = "Use -w";
            this.optArgumentsWindowed.UseVisualStyleBackColor = true;
            // 
            // optArgumentsLowQuality
            // 
            this.optArgumentsLowQuality.Checked = true;
            this.optArgumentsLowQuality.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optArgumentsLowQuality.Location = new System.Drawing.Point(15, 154);
            this.optArgumentsLowQuality.Name = "optArgumentsLowQuality";
            this.optArgumentsLowQuality.Size = new System.Drawing.Size(183, 22);
            this.optArgumentsLowQuality.TabIndex = 24;
            this.optArgumentsLowQuality.Text = "Use -lq";
            this.optArgumentsLowQuality.UseVisualStyleBackColor = true;
            // 
            // optArgumentsNoSound
            // 
            this.optArgumentsNoSound.Location = new System.Drawing.Point(15, 129);
            this.optArgumentsNoSound.Name = "optArgumentsNoSound";
            this.optArgumentsNoSound.Size = new System.Drawing.Size(183, 22);
            this.optArgumentsNoSound.TabIndex = 23;
            this.optArgumentsNoSound.Text = "Use -ns";
            this.optArgumentsNoSound.UseVisualStyleBackColor = true;
            // 
            // optArgumentsDirectTxt
            // 
            this.optArgumentsDirectTxt.Checked = true;
            this.optArgumentsDirectTxt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optArgumentsDirectTxt.Location = new System.Drawing.Point(15, 103);
            this.optArgumentsDirectTxt.Name = "optArgumentsDirectTxt";
            this.optArgumentsDirectTxt.Size = new System.Drawing.Size(183, 22);
            this.optArgumentsDirectTxt.TabIndex = 22;
            this.optArgumentsDirectTxt.Text = "Use -direct -txt";
            this.optArgumentsDirectTxt.UseVisualStyleBackColor = true;
            // 
            // chkVerbose
            // 
            this.chkVerbose.Location = new System.Drawing.Point(15, 76);
            this.chkVerbose.Name = "chkVerbose";
            this.chkVerbose.Size = new System.Drawing.Size(183, 22);
            this.chkVerbose.TabIndex = 20;
            this.chkVerbose.Text = "Verbose Logs";
            this.chkVerbose.UseVisualStyleBackColor = true;
            this.chkVerbose.CheckedChanged += new System.EventHandler(this.chkVerbose_CheckedChanged);
            // 
            // chkKeepOnTop
            // 
            this.chkKeepOnTop.Location = new System.Drawing.Point(15, 49);
            this.chkKeepOnTop.Name = "chkKeepOnTop";
            this.chkKeepOnTop.Size = new System.Drawing.Size(183, 22);
            this.chkKeepOnTop.TabIndex = 19;
            this.chkKeepOnTop.Text = "Keep this window on-top";
            this.chkKeepOnTop.UseVisualStyleBackColor = true;
            this.chkKeepOnTop.CheckedChanged += new System.EventHandler(this.chkKeepOnTop_CheckedChanged);
            // 
            // chkChangeWindowTitle
            // 
            this.chkChangeWindowTitle.Checked = true;
            this.chkChangeWindowTitle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChangeWindowTitle.Location = new System.Drawing.Point(15, 24);
            this.chkChangeWindowTitle.Name = "chkChangeWindowTitle";
            this.chkChangeWindowTitle.Size = new System.Drawing.Size(199, 22);
            this.chkChangeWindowTitle.TabIndex = 17;
            this.chkChangeWindowTitle.Text = "Change the Window Title";
            this.chkChangeWindowTitle.UseVisualStyleBackColor = true;
            // 
            // btnStartAccount
            // 
            this.btnStartAccount.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartAccount.Location = new System.Drawing.Point(219, 241);
            this.btnStartAccount.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartAccount.Name = "btnStartAccount";
            this.btnStartAccount.Size = new System.Drawing.Size(162, 35);
            this.btnStartAccount.TabIndex = 23;
            this.btnStartAccount.Text = "Start Account";
            this.btnStartAccount.UseVisualStyleBackColor = true;
            this.btnStartAccount.Visible = false;
            this.btnStartAccount.Click += new System.EventHandler(this.btnStartAccount_Click);
            // 
            // btnRemoveAccount
            // 
            this.btnRemoveAccount.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveAccount.Location = new System.Drawing.Point(292, 139);
            this.btnRemoveAccount.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveAccount.Name = "btnRemoveAccount";
            this.btnRemoveAccount.Size = new System.Drawing.Size(89, 35);
            this.btnRemoveAccount.TabIndex = 22;
            this.btnRemoveAccount.Text = "Remove";
            this.btnRemoveAccount.UseVisualStyleBackColor = true;
            this.btnRemoveAccount.Visible = false;
            this.btnRemoveAccount.Click += new System.EventHandler(this.btnRemoveAccount_Click);
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateAccount.Location = new System.Drawing.Point(219, 139);
            this.btnCreateAccount.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(65, 35);
            this.btnCreateAccount.TabIndex = 21;
            this.btnCreateAccount.Text = "Add";
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // btnMasterPassword
            // 
            this.btnMasterPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasterPassword.Location = new System.Drawing.Point(219, 73);
            this.btnMasterPassword.Margin = new System.Windows.Forms.Padding(4);
            this.btnMasterPassword.Name = "btnMasterPassword";
            this.btnMasterPassword.Size = new System.Drawing.Size(162, 35);
            this.btnMasterPassword.TabIndex = 24;
            this.btnMasterPassword.Text = "Set Master Password";
            this.btnMasterPassword.UseVisualStyleBackColor = true;
            this.btnMasterPassword.Click += new System.EventHandler(this.btnMasterPassword_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ddRealm);
            this.groupBox2.Location = new System.Drawing.Point(397, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 57);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Realm";
            // 
            // ddRealm
            // 
            this.ddRealm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddRealm.FormattingEnabled = true;
            this.ddRealm.Items.AddRange(new object[] {
            "NA - NORTH AMERICA",
            "EU - EUROPE",
            "KR - ASIA"});
            this.ddRealm.Location = new System.Drawing.Point(6, 24);
            this.ddRealm.Name = "ddRealm";
            this.ddRealm.Size = new System.Drawing.Size(208, 25);
            this.ddRealm.TabIndex = 0;
            // 
            // btnDiscord
            // 
            this.btnDiscord.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscord.Location = new System.Drawing.Point(219, 12);
            this.btnDiscord.Margin = new System.Windows.Forms.Padding(4);
            this.btnDiscord.Name = "btnDiscord";
            this.btnDiscord.Size = new System.Drawing.Size(162, 35);
            this.btnDiscord.TabIndex = 26;
            this.btnDiscord.Text = "Join our Discord Server";
            this.btnDiscord.UseVisualStyleBackColor = true;
            this.btnDiscord.Click += new System.EventHandler(this.btnDiscord_Click);
            // 
            // linkHelpUnpackingD2R
            // 
            this.linkHelpUnpackingD2R.AutoSize = true;
            this.linkHelpUnpackingD2R.Location = new System.Drawing.Point(135, 105);
            this.linkHelpUnpackingD2R.Name = "linkHelpUnpackingD2R";
            this.linkHelpUnpackingD2R.Size = new System.Drawing.Size(46, 17);
            this.linkHelpUnpackingD2R.TabIndex = 26;
            this.linkHelpUnpackingD2R.TabStop = true;
            this.linkHelpUnpackingD2R.Text = "Help ?";
            this.linkHelpUnpackingD2R.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHelpUnpackingD2R_LinkClicked);
            // 
            // frmMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 289);
            this.Controls.Add(this.btnDiscord);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnMasterPassword);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblApplicationLogs);
            this.Controls.Add(this.txtApplicationLogs);
            this.Controls.Add(this.lstProfiles);
            this.Controls.Add(this.btnCreateAccount);
            this.Controls.Add(this.btnStartAccount);
            this.Controls.Add(this.btnRemoveAccount);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmMainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DiabloClone.ORG - D2R_MULTILAUNCHER TOOL";
            this.Load += new System.EventHandler(this.frmMainWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lstProfiles;
        private System.Windows.Forms.ColumnHeader colProfileName;
        private System.Windows.Forms.TextBox txtApplicationLogs;
        private System.Windows.Forms.Label lblApplicationLogs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkChangeWindowTitle;
        private System.Windows.Forms.CheckBox chkKeepOnTop;
        private System.Windows.Forms.CheckBox chkVerbose;
        private System.Windows.Forms.Button btnStartAccount;
        private System.Windows.Forms.Button btnRemoveAccount;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.CheckBox optArgumentsDirectTxt;
        private System.Windows.Forms.CheckBox optArgumentsNoSound;
        private System.Windows.Forms.Button btnMasterPassword;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox ddRealm;
        private System.Windows.Forms.Button btnDiscord;
        private System.Windows.Forms.CheckBox optArgumentsLowQuality;
        private System.Windows.Forms.CheckBox optArgumentsWindowed;
        private System.Windows.Forms.LinkLabel linkHelpUnpackingD2R;
    }
}

