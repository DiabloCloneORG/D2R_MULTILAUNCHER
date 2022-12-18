namespace D2R_MULTILAUNCHER
{
    partial class frmItemRunesEditor
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemRunesEditor));
            this.gridviewEntities = new System.Windows.Forms.DataGridView();
            this.keyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enUSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frFRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zhTWDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deDEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.esESDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itITDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.koKRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plPLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.esMXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jaJPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ptBRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ruRUDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zhCNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highlightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.template1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.template2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.template3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.template4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.template5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.noTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.resetToDefaultValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemFilterAffixeEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtKeywordFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ddSearchTarget = new System.Windows.Forms.ComboBox();
            this.btnResetToOriginal = new System.Windows.Forms.Button();
            this.btnExportToFile = new System.Windows.Forms.Button();
            this.btnImportFromFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewEntities)).BeginInit();
            this.cmsGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemFilterAffixeEntityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridviewEntities
            // 
            this.gridviewEntities.AllowUserToAddRows = false;
            this.gridviewEntities.AllowUserToDeleteRows = false;
            this.gridviewEntities.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Crimson;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridviewEntities.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridviewEntities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyDataGridViewTextBoxColumn,
            this.enUSDataGridViewTextBoxColumn,
            this.frFRDataGridViewTextBoxColumn,
            this.zhTWDataGridViewTextBoxColumn,
            this.deDEDataGridViewTextBoxColumn,
            this.esESDataGridViewTextBoxColumn,
            this.itITDataGridViewTextBoxColumn,
            this.koKRDataGridViewTextBoxColumn,
            this.plPLDataGridViewTextBoxColumn,
            this.esMXDataGridViewTextBoxColumn,
            this.jaJPDataGridViewTextBoxColumn,
            this.ptBRDataGridViewTextBoxColumn,
            this.ruRUDataGridViewTextBoxColumn,
            this.zhCNDataGridViewTextBoxColumn});
            this.gridviewEntities.ContextMenuStrip = this.cmsGridView;
            this.gridviewEntities.DataSource = this.itemFilterAffixeEntityBindingSource;
            this.gridviewEntities.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridviewEntities.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridviewEntities.EnableHeadersVisualStyles = false;
            this.gridviewEntities.Location = new System.Drawing.Point(0, 60);
            this.gridviewEntities.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.gridviewEntities.Name = "gridviewEntities";
            this.gridviewEntities.ReadOnly = true;
            this.gridviewEntities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridviewEntities.Size = new System.Drawing.Size(1095, 448);
            this.gridviewEntities.TabIndex = 2;
            this.gridviewEntities.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridviewEntities_CellMouseDoubleClick);
            // 
            // keyDataGridViewTextBoxColumn
            // 
            this.keyDataGridViewTextBoxColumn.DataPropertyName = "Key";
            this.keyDataGridViewTextBoxColumn.HeaderText = "Key";
            this.keyDataGridViewTextBoxColumn.MinimumWidth = 175;
            this.keyDataGridViewTextBoxColumn.Name = "keyDataGridViewTextBoxColumn";
            this.keyDataGridViewTextBoxColumn.ReadOnly = true;
            this.keyDataGridViewTextBoxColumn.Width = 175;
            // 
            // enUSDataGridViewTextBoxColumn
            // 
            this.enUSDataGridViewTextBoxColumn.DataPropertyName = "enUS";
            this.enUSDataGridViewTextBoxColumn.HeaderText = "enUS";
            this.enUSDataGridViewTextBoxColumn.MinimumWidth = 175;
            this.enUSDataGridViewTextBoxColumn.Name = "enUSDataGridViewTextBoxColumn";
            this.enUSDataGridViewTextBoxColumn.ReadOnly = true;
            this.enUSDataGridViewTextBoxColumn.Width = 175;
            // 
            // frFRDataGridViewTextBoxColumn
            // 
            this.frFRDataGridViewTextBoxColumn.DataPropertyName = "frFR";
            this.frFRDataGridViewTextBoxColumn.HeaderText = "frFR";
            this.frFRDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.frFRDataGridViewTextBoxColumn.Name = "frFRDataGridViewTextBoxColumn";
            this.frFRDataGridViewTextBoxColumn.ReadOnly = true;
            this.frFRDataGridViewTextBoxColumn.Width = 50;
            // 
            // zhTWDataGridViewTextBoxColumn
            // 
            this.zhTWDataGridViewTextBoxColumn.DataPropertyName = "zhTW";
            this.zhTWDataGridViewTextBoxColumn.HeaderText = "zhTW";
            this.zhTWDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.zhTWDataGridViewTextBoxColumn.Name = "zhTWDataGridViewTextBoxColumn";
            this.zhTWDataGridViewTextBoxColumn.ReadOnly = true;
            this.zhTWDataGridViewTextBoxColumn.Width = 50;
            // 
            // deDEDataGridViewTextBoxColumn
            // 
            this.deDEDataGridViewTextBoxColumn.DataPropertyName = "deDE";
            this.deDEDataGridViewTextBoxColumn.HeaderText = "deDE";
            this.deDEDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.deDEDataGridViewTextBoxColumn.Name = "deDEDataGridViewTextBoxColumn";
            this.deDEDataGridViewTextBoxColumn.ReadOnly = true;
            this.deDEDataGridViewTextBoxColumn.Width = 50;
            // 
            // esESDataGridViewTextBoxColumn
            // 
            this.esESDataGridViewTextBoxColumn.DataPropertyName = "esES";
            this.esESDataGridViewTextBoxColumn.HeaderText = "esES";
            this.esESDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.esESDataGridViewTextBoxColumn.Name = "esESDataGridViewTextBoxColumn";
            this.esESDataGridViewTextBoxColumn.ReadOnly = true;
            this.esESDataGridViewTextBoxColumn.Width = 50;
            // 
            // itITDataGridViewTextBoxColumn
            // 
            this.itITDataGridViewTextBoxColumn.DataPropertyName = "itIT";
            this.itITDataGridViewTextBoxColumn.HeaderText = "itIT";
            this.itITDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.itITDataGridViewTextBoxColumn.Name = "itITDataGridViewTextBoxColumn";
            this.itITDataGridViewTextBoxColumn.ReadOnly = true;
            this.itITDataGridViewTextBoxColumn.Width = 50;
            // 
            // koKRDataGridViewTextBoxColumn
            // 
            this.koKRDataGridViewTextBoxColumn.DataPropertyName = "koKR";
            this.koKRDataGridViewTextBoxColumn.HeaderText = "koKR";
            this.koKRDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.koKRDataGridViewTextBoxColumn.Name = "koKRDataGridViewTextBoxColumn";
            this.koKRDataGridViewTextBoxColumn.ReadOnly = true;
            this.koKRDataGridViewTextBoxColumn.Width = 50;
            // 
            // plPLDataGridViewTextBoxColumn
            // 
            this.plPLDataGridViewTextBoxColumn.DataPropertyName = "plPL";
            this.plPLDataGridViewTextBoxColumn.HeaderText = "plPL";
            this.plPLDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.plPLDataGridViewTextBoxColumn.Name = "plPLDataGridViewTextBoxColumn";
            this.plPLDataGridViewTextBoxColumn.ReadOnly = true;
            this.plPLDataGridViewTextBoxColumn.Width = 50;
            // 
            // esMXDataGridViewTextBoxColumn
            // 
            this.esMXDataGridViewTextBoxColumn.DataPropertyName = "esMX";
            this.esMXDataGridViewTextBoxColumn.HeaderText = "esMX";
            this.esMXDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.esMXDataGridViewTextBoxColumn.Name = "esMXDataGridViewTextBoxColumn";
            this.esMXDataGridViewTextBoxColumn.ReadOnly = true;
            this.esMXDataGridViewTextBoxColumn.Width = 50;
            // 
            // jaJPDataGridViewTextBoxColumn
            // 
            this.jaJPDataGridViewTextBoxColumn.DataPropertyName = "jaJP";
            this.jaJPDataGridViewTextBoxColumn.HeaderText = "jaJP";
            this.jaJPDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.jaJPDataGridViewTextBoxColumn.Name = "jaJPDataGridViewTextBoxColumn";
            this.jaJPDataGridViewTextBoxColumn.ReadOnly = true;
            this.jaJPDataGridViewTextBoxColumn.Width = 50;
            // 
            // ptBRDataGridViewTextBoxColumn
            // 
            this.ptBRDataGridViewTextBoxColumn.DataPropertyName = "ptBR";
            this.ptBRDataGridViewTextBoxColumn.HeaderText = "ptBR";
            this.ptBRDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.ptBRDataGridViewTextBoxColumn.Name = "ptBRDataGridViewTextBoxColumn";
            this.ptBRDataGridViewTextBoxColumn.ReadOnly = true;
            this.ptBRDataGridViewTextBoxColumn.Width = 50;
            // 
            // ruRUDataGridViewTextBoxColumn
            // 
            this.ruRUDataGridViewTextBoxColumn.DataPropertyName = "ruRU";
            this.ruRUDataGridViewTextBoxColumn.HeaderText = "ruRU";
            this.ruRUDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.ruRUDataGridViewTextBoxColumn.Name = "ruRUDataGridViewTextBoxColumn";
            this.ruRUDataGridViewTextBoxColumn.ReadOnly = true;
            this.ruRUDataGridViewTextBoxColumn.Width = 50;
            // 
            // zhCNDataGridViewTextBoxColumn
            // 
            this.zhCNDataGridViewTextBoxColumn.DataPropertyName = "zhCN";
            this.zhCNDataGridViewTextBoxColumn.HeaderText = "zhCN";
            this.zhCNDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.zhCNDataGridViewTextBoxColumn.Name = "zhCNDataGridViewTextBoxColumn";
            this.zhCNDataGridViewTextBoxColumn.ReadOnly = true;
            this.zhCNDataGridViewTextBoxColumn.Width = 50;
            // 
            // cmsGridView
            // 
            this.cmsGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setToToolStripMenuItem,
            this.toolStripSeparator3,
            this.resetToDefaultValueToolStripMenuItem});
            this.cmsGridView.Name = "cmsGridView";
            this.cmsGridView.Size = new System.Drawing.Size(189, 76);
            this.cmsGridView.Opening += new System.ComponentModel.CancelEventHandler(this.cmsGridView_Opening);
            // 
            // setToToolStripMenuItem
            // 
            this.setToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideToolStripMenuItem,
            this.grayToolStripMenuItem,
            this.whiteToolStripMenuItem,
            this.highlightToolStripMenuItem,
            this.toolStripSeparator1,
            this.template1ToolStripMenuItem,
            this.template2ToolStripMenuItem,
            this.template3ToolStripMenuItem,
            this.template4ToolStripMenuItem,
            this.template5ToolStripMenuItem,
            this.toolStripSeparator2,
            this.noTemplateToolStripMenuItem});
            this.setToToolStripMenuItem.Name = "setToToolStripMenuItem";
            this.setToToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.setToToolStripMenuItem.Text = "Set to";
            this.setToToolStripMenuItem.Click += new System.EventHandler(this.setToToolStripMenuItem_Click);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // grayToolStripMenuItem
            // 
            this.grayToolStripMenuItem.Name = "grayToolStripMenuItem";
            this.grayToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.grayToolStripMenuItem.Text = "Gray";
            this.grayToolStripMenuItem.Click += new System.EventHandler(this.grayToolStripMenuItem_Click);
            // 
            // whiteToolStripMenuItem
            // 
            this.whiteToolStripMenuItem.Name = "whiteToolStripMenuItem";
            this.whiteToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.whiteToolStripMenuItem.Text = "White";
            this.whiteToolStripMenuItem.Click += new System.EventHandler(this.whiteToolStripMenuItem_Click);
            // 
            // highlightToolStripMenuItem
            // 
            this.highlightToolStripMenuItem.Name = "highlightToolStripMenuItem";
            this.highlightToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.highlightToolStripMenuItem.Text = "Highlight";
            this.highlightToolStripMenuItem.Click += new System.EventHandler(this.highlightToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(138, 6);
            // 
            // template1ToolStripMenuItem
            // 
            this.template1ToolStripMenuItem.Name = "template1ToolStripMenuItem";
            this.template1ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.template1ToolStripMenuItem.Text = "Template1";
            this.template1ToolStripMenuItem.Click += new System.EventHandler(this.template1ToolStripMenuItem_Click);
            // 
            // template2ToolStripMenuItem
            // 
            this.template2ToolStripMenuItem.Name = "template2ToolStripMenuItem";
            this.template2ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.template2ToolStripMenuItem.Text = "Template2";
            this.template2ToolStripMenuItem.Click += new System.EventHandler(this.template2ToolStripMenuItem_Click);
            // 
            // template3ToolStripMenuItem
            // 
            this.template3ToolStripMenuItem.Name = "template3ToolStripMenuItem";
            this.template3ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.template3ToolStripMenuItem.Text = "Template3";
            this.template3ToolStripMenuItem.Click += new System.EventHandler(this.template3ToolStripMenuItem_Click);
            // 
            // template4ToolStripMenuItem
            // 
            this.template4ToolStripMenuItem.Name = "template4ToolStripMenuItem";
            this.template4ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.template4ToolStripMenuItem.Text = "Template4";
            this.template4ToolStripMenuItem.Click += new System.EventHandler(this.template4ToolStripMenuItem_Click);
            // 
            // template5ToolStripMenuItem
            // 
            this.template5ToolStripMenuItem.Name = "template5ToolStripMenuItem";
            this.template5ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.template5ToolStripMenuItem.Text = "Template5";
            this.template5ToolStripMenuItem.Click += new System.EventHandler(this.template5ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(138, 6);
            // 
            // noTemplateToolStripMenuItem
            // 
            this.noTemplateToolStripMenuItem.Name = "noTemplateToolStripMenuItem";
            this.noTemplateToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.noTemplateToolStripMenuItem.Text = "No Template";
            this.noTemplateToolStripMenuItem.Click += new System.EventHandler(this.noTemplateToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(185, 6);
            // 
            // resetToDefaultValueToolStripMenuItem
            // 
            this.resetToDefaultValueToolStripMenuItem.Name = "resetToDefaultValueToolStripMenuItem";
            this.resetToDefaultValueToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.resetToDefaultValueToolStripMenuItem.Text = "Reset to Default Value";
            this.resetToDefaultValueToolStripMenuItem.Click += new System.EventHandler(this.resetToDefaultValueToolStripMenuItem_Click);
            // 
            // itemFilterAffixeEntityBindingSource
            // 
            this.itemFilterAffixeEntityBindingSource.DataSource = typeof(D2R_MULTILAUNCHER.ItemFilterBaseEntity);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Filter by keyword";
            // 
            // txtKeywordFilter
            // 
            this.txtKeywordFilter.Location = new System.Drawing.Point(138, 12);
            this.txtKeywordFilter.Name = "txtKeywordFilter";
            this.txtKeywordFilter.Size = new System.Drawing.Size(180, 23);
            this.txtKeywordFilter.TabIndex = 4;
            this.txtKeywordFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtKeywordFilter_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(138, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Leave blank for all items.";
            // 
            // ddSearchTarget
            // 
            this.ddSearchTarget.BackColor = System.Drawing.Color.White;
            this.ddSearchTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddSearchTarget.FormattingEnabled = true;
            this.ddSearchTarget.Items.AddRange(new object[] {
            "Key",
            "enUS",
            "zhTW",
            "deDE",
            "esES",
            "frFR",
            "itIT",
            "koKR",
            "plPL",
            "esMX",
            "jaJP",
            "ptBR",
            "ruRU",
            "zhCN",
            "All Fields"});
            this.ddSearchTarget.Location = new System.Drawing.Point(324, 12);
            this.ddSearchTarget.Name = "ddSearchTarget";
            this.ddSearchTarget.Size = new System.Drawing.Size(102, 23);
            this.ddSearchTarget.TabIndex = 6;
            this.ddSearchTarget.SelectedIndexChanged += new System.EventHandler(this.ddSearchTarget_SelectedIndexChanged);
            // 
            // btnResetToOriginal
            // 
            this.btnResetToOriginal.Location = new System.Drawing.Point(774, 12);
            this.btnResetToOriginal.Name = "btnResetToOriginal";
            this.btnResetToOriginal.Size = new System.Drawing.Size(309, 36);
            this.btnResetToOriginal.TabIndex = 7;
            this.btnResetToOriginal.Text = "Reset with the un-modified version (reset)";
            this.btnResetToOriginal.UseVisualStyleBackColor = true;
            this.btnResetToOriginal.Click += new System.EventHandler(this.btnResetToOriginal_Click);
            // 
            // btnExportToFile
            // 
            this.btnExportToFile.Location = new System.Drawing.Point(642, 12);
            this.btnExportToFile.Name = "btnExportToFile";
            this.btnExportToFile.Size = new System.Drawing.Size(123, 36);
            this.btnExportToFile.TabIndex = 8;
            this.btnExportToFile.Text = "Export to File";
            this.btnExportToFile.UseVisualStyleBackColor = true;
            this.btnExportToFile.Click += new System.EventHandler(this.btnExportToFile_Click);
            // 
            // btnImportFromFile
            // 
            this.btnImportFromFile.Location = new System.Drawing.Point(492, 12);
            this.btnImportFromFile.Name = "btnImportFromFile";
            this.btnImportFromFile.Size = new System.Drawing.Size(138, 36);
            this.btnImportFromFile.TabIndex = 9;
            this.btnImportFromFile.Text = "Import from File";
            this.btnImportFromFile.UseVisualStyleBackColor = true;
            this.btnImportFromFile.Click += new System.EventHandler(this.btnImportFromFile_Click);
            // 
            // frmItemRunesEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 508);
            this.Controls.Add(this.btnImportFromFile);
            this.Controls.Add(this.btnExportToFile);
            this.Controls.Add(this.btnResetToOriginal);
            this.Controls.Add(this.ddSearchTarget);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKeywordFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridviewEntities);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.MaximizeBox = false;
            this.Name = "frmItemRunesEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Items Filter - RUNES/RUNEWORDS";
            this.Load += new System.EventHandler(this.frmItemRunesEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridviewEntities)).EndInit();
            this.cmsGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemFilterAffixeEntityBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView gridviewEntities;
        private System.Windows.Forms.BindingSource itemFilterAffixeEntityBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn enUSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn frFRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zhTWDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deDEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn esESDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itITDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn koKRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn plPLDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn esMXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jaJPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ptBRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ruRUDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zhCNDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKeywordFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddSearchTarget;
        private System.Windows.Forms.Button btnResetToOriginal;
        private System.Windows.Forms.Button btnExportToFile;
        private System.Windows.Forms.Button btnImportFromFile;
        private System.Windows.Forms.ContextMenuStrip cmsGridView;
        private System.Windows.Forms.ToolStripMenuItem setToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highlightToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem template1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem template2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem template3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem template4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem template5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem noTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem resetToDefaultValueToolStripMenuItem;
    }
}