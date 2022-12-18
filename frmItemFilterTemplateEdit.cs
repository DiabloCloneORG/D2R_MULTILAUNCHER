using Accessibility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D2R_MULTILAUNCHER
{
    public delegate void onItemFilterTemplateUpdatedEventHandler(ConfigurationEntity updated_configuration);
    public partial class frmItemFilterTemplateEdit : Form
    {
        public event onItemFilterTemplateUpdatedEventHandler onItemFilterTemplateUpdated;
        
        private ConfigurationEntity _configuration;

        public frmItemFilterTemplateEdit(ConfigurationEntity configuration)
        {
            InitializeComponent();

            _configuration = configuration;
        }

        private void frmItemFilterTemplateEdit_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                txtTemplateCustomName1.Text = _configuration.ItemsFilterCustomTemplate1Name;
                txtTemplateCustomPrefix1.Text = _configuration.ItemsFilterCustomTemplate1Preffix;
                txtTemplateCustomSuffix1.Text = _configuration.ItemsFilterCustomTemplate1Suffix;

                txtTemplateCustomName2.Text = _configuration.ItemsFilterCustomTemplate2Name;
                txtTemplateCustomPrefix2.Text = _configuration.ItemsFilterCustomTemplate2Preffix;
                txtTemplateCustomSuffix2.Text = _configuration.ItemsFilterCustomTemplate2Suffix;

                txtTemplateCustomName3.Text = _configuration.ItemsFilterCustomTemplate3Name;
                txtTemplateCustomPrefix3.Text = _configuration.ItemsFilterCustomTemplate3Preffix;
                txtTemplateCustomSuffix3.Text = _configuration.ItemsFilterCustomTemplate3Suffix;

                txtTemplateCustomName4.Text = _configuration.ItemsFilterCustomTemplate4Name;
                txtTemplateCustomPrefix4.Text = _configuration.ItemsFilterCustomTemplate4Preffix;
                txtTemplateCustomSuffix4.Text = _configuration.ItemsFilterCustomTemplate4Suffix;

                txtTemplateCustomName5.Text = _configuration.ItemsFilterCustomTemplate5Name;
                txtTemplateCustomPrefix5.Text = _configuration.ItemsFilterCustomTemplate5Preffix;
                txtTemplateCustomSuffix5.Text = _configuration.ItemsFilterCustomTemplate5Suffix;

                txtTemplateHide.Text = _configuration.ItemsFilterHideTemplateReplacement;
            }
            catch
            {
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (onItemFilterTemplateUpdated!=null)
            {
                onItemFilterTemplateUpdated(_configuration);
            }

            this.Close();
        }

        private void txtTemplateHide_TextChanged(object sender, EventArgs e)
        {
            _configuration.ItemsFilterHideTemplateReplacement = txtTemplateHide.Text;
        }

        private void txtTemplateCustomPrefix1_TextChanged(object sender, EventArgs e)
        {
            _configuration.ItemsFilterCustomTemplate1Preffix = txtTemplateCustomPrefix1.Text;
        }

        private void txtTemplateCustomSuffix1_TextChanged(object sender, EventArgs e)
        {
            _configuration.ItemsFilterCustomTemplate1Suffix = txtTemplateCustomSuffix1.Text;
        }

        private void txtTemplateCustomPrefix2_TextChanged(object sender, EventArgs e)
        {
            _configuration.ItemsFilterCustomTemplate2Preffix = txtTemplateCustomPrefix2.Text;
        }

        private void txtTemplateCustomSuffix2_TextChanged(object sender, EventArgs e)
        {
            _configuration.ItemsFilterCustomTemplate2Suffix = txtTemplateCustomSuffix2.Text;
        }

        private void txtTemplateCustomPrefix3_TextChanged(object sender, EventArgs e)
        {
            _configuration.ItemsFilterCustomTemplate3Preffix = txtTemplateCustomPrefix3.Text;
        }

        private void txtTemplateCustomSuffix3_TextChanged(object sender, EventArgs e)
        {
            _configuration.ItemsFilterCustomTemplate3Suffix = txtTemplateCustomSuffix3.Text;
        }

        private void txtTemplateCustomPrefix4_TextChanged(object sender, EventArgs e)
        {
            _configuration.ItemsFilterCustomTemplate4Preffix = txtTemplateCustomPrefix4.Text;
        }

        private void txtTemplateCustomSuffix4_TextChanged(object sender, EventArgs e)
        {
            _configuration.ItemsFilterCustomTemplate4Suffix = txtTemplateCustomSuffix4.Text;
        }

        private void txtTemplateCustomPrefix5_TextChanged(object sender, EventArgs e)
        {
            _configuration.ItemsFilterCustomTemplate5Preffix = txtTemplateCustomPrefix5.Text;
        }

        private void txtTemplateCustomSuffix5_TextChanged(object sender, EventArgs e)
        {
            _configuration.ItemsFilterCustomTemplate5Suffix = txtTemplateCustomSuffix5.Text;
        }

        private void txtTemplateCustomName1_TextChanged(object sender, EventArgs e)
        {
            _configuration.ItemsFilterCustomTemplate1Name = txtTemplateCustomName1.Text;
        }

        private void txtTemplateCustomName2_TextChanged(object sender, EventArgs e)
        {
            _configuration.ItemsFilterCustomTemplate2Name = txtTemplateCustomName2.Text;
        }

        private void txtTemplateCustomName3_TextChanged(object sender, EventArgs e)
        {
            _configuration.ItemsFilterCustomTemplate3Name = txtTemplateCustomName3.Text;
        }

        private void txtTemplateCustomName4_TextChanged(object sender, EventArgs e)
        {
            _configuration.ItemsFilterCustomTemplate4Name = txtTemplateCustomName4.Text;
        }

        private void txtTemplateCustomName5_TextChanged(object sender, EventArgs e)
        {
            _configuration.ItemsFilterCustomTemplate5Name = txtTemplateCustomName5.Text;
        }
    }
}
