
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
            this.colProfileName = new System.Windows.Forms.ColumnHeader();
            this.txtApplicationLogs = new System.Windows.Forms.TextBox();
            this.lblApplicationLogs = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkHelpUnpackingD2R = new System.Windows.Forms.LinkLabel();
            this.optArgumentsWindowed = new System.Windows.Forms.CheckBox();
            this.optArgumentsLowQuality = new System.Windows.Forms.CheckBox();
            this.optArgumentsNoSound = new System.Windows.Forms.CheckBox();
            this.optArgumentsDirectTxt = new System.Windows.Forms.CheckBox();
            this.chkKeepOnTop = new System.Windows.Forms.CheckBox();
            this.chkChangeWindowTitle = new System.Windows.Forms.CheckBox();
            this.btnStartAccount = new System.Windows.Forms.Button();
            this.btnRemoveAccount = new System.Windows.Forms.Button();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.btnMasterPassword = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ddRealm = new System.Windows.Forms.ComboBox();
            this.btnDiscord = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnItemsFilterTemplates = new System.Windows.Forms.Button();
            this.btnItemsFilterRunesNames = new System.Windows.Forms.Button();
            this.btnItemsFilterNames = new System.Windows.Forms.Button();
            this.chkItemFilterEnabled = new System.Windows.Forms.CheckBox();
            this.btnItemsFilterAffixes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstProfiles
            // 
            this.lstProfiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProfileName});
            this.lstProfiles.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lstProfiles.FullRowSelect = true;
            this.lstProfiles.Location = new System.Drawing.Point(18, 36);
            this.lstProfiles.MultiSelect = false;
            this.lstProfiles.Name = "lstProfiles";
            this.lstProfiles.Size = new System.Drawing.Size(176, 258);
            this.lstProfiles.TabIndex = 7;
            this.lstProfiles.UseCompatibleStateImageBehavior = false;
            this.lstProfiles.View = System.Windows.Forms.View.Details;
            this.lstProfiles.SelectedIndexChanged += new System.EventHandler(this.lstProfiles_SelectedIndexChanged);
            // 
            // colProfileName
            // 
            this.colProfileName.Text = "Account Name";
            this.colProfileName.Width = 135;
            // 
            // txtApplicationLogs
            // 
            this.txtApplicationLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApplicationLogs.Location = new System.Drawing.Point(16, 336);
            this.txtApplicationLogs.Multiline = true;
            this.txtApplicationLogs.Name = "txtApplicationLogs";
            this.txtApplicationLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtApplicationLogs.Size = new System.Drawing.Size(840, 168);
            this.txtApplicationLogs.TabIndex = 13;
            // 
            // lblApplicationLogs
            // 
            this.lblApplicationLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblApplicationLogs.AutoSize = true;
            this.lblApplicationLogs.Location = new System.Drawing.Point(18, 315);
            this.lblApplicationLogs.Name = "lblApplicationLogs";
            this.lblApplicationLogs.Size = new System.Drawing.Size(126, 17);
            this.lblApplicationLogs.TabIndex = 14;
            this.lblApplicationLogs.Text = "APPLICATION LOGS";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkHelpUnpackingD2R);
            this.groupBox1.Controls.Add(this.optArgumentsWindowed);
            this.groupBox1.Controls.Add(this.optArgumentsLowQuality);
            this.groupBox1.Controls.Add(this.optArgumentsNoSound);
            this.groupBox1.Controls.Add(this.optArgumentsDirectTxt);
            this.groupBox1.Controls.Add(this.chkKeepOnTop);
            this.groupBox1.Controls.Add(this.chkChangeWindowTitle);
            this.groupBox1.Location = new System.Drawing.Point(396, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 210);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GENERAL OPTIONS";
            // 
            // linkHelpUnpackingD2R
            // 
            this.linkHelpUnpackingD2R.AutoSize = true;
            this.linkHelpUnpackingD2R.Location = new System.Drawing.Point(144, 90);
            this.linkHelpUnpackingD2R.Name = "linkHelpUnpackingD2R";
            this.linkHelpUnpackingD2R.Size = new System.Drawing.Size(46, 17);
            this.linkHelpUnpackingD2R.TabIndex = 26;
            this.linkHelpUnpackingD2R.TabStop = true;
            this.linkHelpUnpackingD2R.Text = "Help ?";
            this.linkHelpUnpackingD2R.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHelpUnpackingD2R_LinkClicked);
            // 
            // optArgumentsWindowed
            // 
            this.optArgumentsWindowed.Checked = true;
            this.optArgumentsWindowed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optArgumentsWindowed.Location = new System.Drawing.Point(16, 180);
            this.optArgumentsWindowed.Name = "optArgumentsWindowed";
            this.optArgumentsWindowed.Size = new System.Drawing.Size(183, 22);
            this.optArgumentsWindowed.TabIndex = 25;
            this.optArgumentsWindowed.Text = "Use -w";
            this.optArgumentsWindowed.UseVisualStyleBackColor = true;
            this.optArgumentsWindowed.CheckedChanged += new System.EventHandler(this.optArgumentsWindowed_CheckedChanged);
            // 
            // optArgumentsLowQuality
            // 
            this.optArgumentsLowQuality.Checked = true;
            this.optArgumentsLowQuality.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optArgumentsLowQuality.Location = new System.Drawing.Point(16, 150);
            this.optArgumentsLowQuality.Name = "optArgumentsLowQuality";
            this.optArgumentsLowQuality.Size = new System.Drawing.Size(183, 22);
            this.optArgumentsLowQuality.TabIndex = 24;
            this.optArgumentsLowQuality.Text = "Use -lq";
            this.optArgumentsLowQuality.UseVisualStyleBackColor = true;
            this.optArgumentsLowQuality.CheckedChanged += new System.EventHandler(this.optArgumentsLowQuality_CheckedChanged);
            // 
            // optArgumentsNoSound
            // 
            this.optArgumentsNoSound.Location = new System.Drawing.Point(16, 120);
            this.optArgumentsNoSound.Name = "optArgumentsNoSound";
            this.optArgumentsNoSound.Size = new System.Drawing.Size(183, 22);
            this.optArgumentsNoSound.TabIndex = 23;
            this.optArgumentsNoSound.Text = "Use -ns";
            this.optArgumentsNoSound.UseVisualStyleBackColor = true;
            this.optArgumentsNoSound.CheckedChanged += new System.EventHandler(this.optArgumentsNoSound_CheckedChanged);
            // 
            // optArgumentsDirectTxt
            // 
            this.optArgumentsDirectTxt.Checked = true;
            this.optArgumentsDirectTxt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optArgumentsDirectTxt.Location = new System.Drawing.Point(16, 90);
            this.optArgumentsDirectTxt.Name = "optArgumentsDirectTxt";
            this.optArgumentsDirectTxt.Size = new System.Drawing.Size(120, 22);
            this.optArgumentsDirectTxt.TabIndex = 22;
            this.optArgumentsDirectTxt.Text = "Use -direct -txt";
            this.optArgumentsDirectTxt.UseVisualStyleBackColor = true;
            this.optArgumentsDirectTxt.CheckedChanged += new System.EventHandler(this.optArgumentsDirectTxt_CheckedChanged);
            // 
            // chkKeepOnTop
            // 
            this.chkKeepOnTop.Location = new System.Drawing.Point(16, 60);
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
            this.chkChangeWindowTitle.Location = new System.Drawing.Point(16, 32);
            this.chkChangeWindowTitle.Name = "chkChangeWindowTitle";
            this.chkChangeWindowTitle.Size = new System.Drawing.Size(208, 22);
            this.chkChangeWindowTitle.TabIndex = 17;
            this.chkChangeWindowTitle.Text = "Change the D2R Window Title";
            this.chkChangeWindowTitle.UseVisualStyleBackColor = true;
            this.chkChangeWindowTitle.CheckedChanged += new System.EventHandler(this.chkChangeWindowTitle_CheckedChanged);
            // 
            // btnStartAccount
            // 
            this.btnStartAccount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStartAccount.Location = new System.Drawing.Point(208, 192);
            this.btnStartAccount.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartAccount.Name = "btnStartAccount";
            this.btnStartAccount.Size = new System.Drawing.Size(160, 32);
            this.btnStartAccount.TabIndex = 23;
            this.btnStartAccount.Text = "Start Account";
            this.btnStartAccount.UseVisualStyleBackColor = true;
            this.btnStartAccount.Visible = false;
            this.btnStartAccount.Click += new System.EventHandler(this.btnStartAccount_Click);
            // 
            // btnRemoveAccount
            // 
            this.btnRemoveAccount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRemoveAccount.Location = new System.Drawing.Point(208, 128);
            this.btnRemoveAccount.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveAccount.Name = "btnRemoveAccount";
            this.btnRemoveAccount.Size = new System.Drawing.Size(160, 32);
            this.btnRemoveAccount.TabIndex = 22;
            this.btnRemoveAccount.Text = "Remove";
            this.btnRemoveAccount.UseVisualStyleBackColor = true;
            this.btnRemoveAccount.Visible = false;
            this.btnRemoveAccount.Click += new System.EventHandler(this.btnRemoveAccount_Click);
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCreateAccount.Location = new System.Drawing.Point(208, 88);
            this.btnCreateAccount.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(160, 32);
            this.btnCreateAccount.TabIndex = 21;
            this.btnCreateAccount.Text = "Add";
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // btnMasterPassword
            // 
            this.btnMasterPassword.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMasterPassword.Location = new System.Drawing.Point(208, 40);
            this.btnMasterPassword.Margin = new System.Windows.Forms.Padding(4);
            this.btnMasterPassword.Name = "btnMasterPassword";
            this.btnMasterPassword.Size = new System.Drawing.Size(160, 32);
            this.btnMasterPassword.TabIndex = 24;
            this.btnMasterPassword.Text = "Set Master Password";
            this.btnMasterPassword.UseVisualStyleBackColor = true;
            this.btnMasterPassword.Click += new System.EventHandler(this.btnMasterPassword_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ddRealm);
            this.groupBox2.Location = new System.Drawing.Point(208, 240);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(160, 57);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Realm";
            // 
            // ddRealm
            // 
            this.ddRealm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddRealm.FormattingEnabled = true;
            this.ddRealm.Items.AddRange(new object[] {
            "NA - AMERICA",
            "EU - EUROPE",
            "KR - ASIA"});
            this.ddRealm.Location = new System.Drawing.Point(6, 24);
            this.ddRealm.Name = "ddRealm";
            this.ddRealm.Size = new System.Drawing.Size(146, 25);
            this.ddRealm.TabIndex = 0;
            this.ddRealm.SelectedIndexChanged += new System.EventHandler(this.ddRealm_SelectedIndexChanged);
            // 
            // btnDiscord
            // 
            this.btnDiscord.BackColor = System.Drawing.Color.Crimson;
            this.btnDiscord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDiscord.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDiscord.ForeColor = System.Drawing.Color.White;
            this.btnDiscord.Location = new System.Drawing.Point(396, 252);
            this.btnDiscord.Margin = new System.Windows.Forms.Padding(4);
            this.btnDiscord.Name = "btnDiscord";
            this.btnDiscord.Size = new System.Drawing.Size(258, 41);
            this.btnDiscord.TabIndex = 26;
            this.btnDiscord.Text = "Join our Discord Server";
            this.btnDiscord.UseVisualStyleBackColor = false;
            this.btnDiscord.Click += new System.EventHandler(this.btnDiscord_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnItemsFilterTemplates);
            this.groupBox3.Controls.Add(this.btnItemsFilterRunesNames);
            this.groupBox3.Controls.Add(this.btnItemsFilterNames);
            this.groupBox3.Controls.Add(this.chkItemFilterEnabled);
            this.groupBox3.Controls.Add(this.btnItemsFilterAffixes);
            this.groupBox3.Location = new System.Drawing.Point(672, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(184, 276);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ITEMS FILTER MOD";
            // 
            // btnItemsFilterTemplates
            // 
            this.btnItemsFilterTemplates.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnItemsFilterTemplates.Location = new System.Drawing.Point(12, 228);
            this.btnItemsFilterTemplates.Margin = new System.Windows.Forms.Padding(4);
            this.btnItemsFilterTemplates.Name = "btnItemsFilterTemplates";
            this.btnItemsFilterTemplates.Size = new System.Drawing.Size(162, 32);
            this.btnItemsFilterTemplates.TabIndex = 33;
            this.btnItemsFilterTemplates.Text = "Templates";
            this.btnItemsFilterTemplates.UseVisualStyleBackColor = true;
            this.btnItemsFilterTemplates.Click += new System.EventHandler(this.btnItemsFilterTemplates_Click);
            // 
            // btnItemsFilterRunesNames
            // 
            this.btnItemsFilterRunesNames.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnItemsFilterRunesNames.Location = new System.Drawing.Point(12, 152);
            this.btnItemsFilterRunesNames.Margin = new System.Windows.Forms.Padding(4);
            this.btnItemsFilterRunesNames.Name = "btnItemsFilterRunesNames";
            this.btnItemsFilterRunesNames.Size = new System.Drawing.Size(162, 32);
            this.btnItemsFilterRunesNames.TabIndex = 32;
            this.btnItemsFilterRunesNames.Text = "Runes";
            this.btnItemsFilterRunesNames.UseVisualStyleBackColor = true;
            this.btnItemsFilterRunesNames.Click += new System.EventHandler(this.btnItemsFilterRunesNames_Click);
            // 
            // btnItemsFilterNames
            // 
            this.btnItemsFilterNames.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnItemsFilterNames.Location = new System.Drawing.Point(12, 112);
            this.btnItemsFilterNames.Margin = new System.Windows.Forms.Padding(4);
            this.btnItemsFilterNames.Name = "btnItemsFilterNames";
            this.btnItemsFilterNames.Size = new System.Drawing.Size(162, 32);
            this.btnItemsFilterNames.TabIndex = 31;
            this.btnItemsFilterNames.Text = "Items Names";
            this.btnItemsFilterNames.UseVisualStyleBackColor = true;
            this.btnItemsFilterNames.Click += new System.EventHandler(this.btnItemsFilterNames_Click);
            // 
            // chkItemFilterEnabled
            // 
            this.chkItemFilterEnabled.Checked = true;
            this.chkItemFilterEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkItemFilterEnabled.Location = new System.Drawing.Point(16, 32);
            this.chkItemFilterEnabled.Name = "chkItemFilterEnabled";
            this.chkItemFilterEnabled.Size = new System.Drawing.Size(160, 22);
            this.chkItemFilterEnabled.TabIndex = 30;
            this.chkItemFilterEnabled.Text = "Enable (Experimental)";
            this.chkItemFilterEnabled.UseVisualStyleBackColor = true;
            this.chkItemFilterEnabled.CheckedChanged += new System.EventHandler(this.chkItemFilterEnabled_CheckedChanged);
            // 
            // btnItemsFilterAffixes
            // 
            this.btnItemsFilterAffixes.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnItemsFilterAffixes.Location = new System.Drawing.Point(12, 72);
            this.btnItemsFilterAffixes.Margin = new System.Windows.Forms.Padding(4);
            this.btnItemsFilterAffixes.Name = "btnItemsFilterAffixes";
            this.btnItemsFilterAffixes.Size = new System.Drawing.Size(162, 32);
            this.btnItemsFilterAffixes.TabIndex = 28;
            this.btnItemsFilterAffixes.Text = "Items Affixes";
            this.btnItemsFilterAffixes.UseVisualStyleBackColor = true;
            this.btnItemsFilterAffixes.Click += new System.EventHandler(this.btnItemsFilterAffixes_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(396, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "LOOKING FOR SUPPORT ?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 30;
            this.label3.Text = "PROFILES LIST";
            // 
            // frmMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 517);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
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
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            this.groupBox3.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnItemsFilterAffixes;
        private System.Windows.Forms.CheckBox chkItemFilterEnabled;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnItemsFilterRunesNames;
        private System.Windows.Forms.Button btnItemsFilterNames;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnItemsFilterTemplates;
    }
}

