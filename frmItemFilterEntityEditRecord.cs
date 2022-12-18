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
    
    public partial class frmItemFilterEntityEditRecord : Form
    {
        public event onItemFilterEnhancedEntityUpdatedEventHandler onItemFilterEnhancedEntityUpdated;
        private ItemFilterEnhancedEntity _entity;
        private string _resourceName;
        private ConfigurationEntity _configuration;


        public frmItemFilterEntityEditRecord(ItemFilterEnhancedEntity entity, string resourceName)
        {
            InitializeComponent();

            _entity = (ItemFilterEnhancedEntity)entity.Clone();

            _resourceName = resourceName;

            _configuration = new ConfigurationEntity();
        }

        private void frmItemFilterEntityEditRecord_Load(object sender, EventArgs e)
        {
            _configuration.ReadConfiguration();

            LoadData();

            LoadPreviews();
        }

        private void LoadData()
        {
            txtenUS.Text = _entity.enUS;
            txtesMX.Text = _entity.esMX;
            txtfrFR.Text = _entity.frFR;
            txtitIT.Text = _entity.itIT;
            txtjaJP.Text = _entity.jaJP;
            lblKeyValue.Text = _entity.Key;
            txtkoKO.Text = _entity.koKR;
            txtplPL.Text = _entity.plPL;
            txtptBR.Text = _entity.ptBR;
            txtruRU.Text = _entity.ruRU;
            txtzhCN.Text = _entity.zhCN;
            txtzhTW.Text = _entity.zhTW;

            ddPreviewTarget.SelectedIndexChanged -= ddPreviewTarget_SelectedIndexChanged;
            ddPreviewTarget.SelectedIndex = 1;
            ddPreviewTarget.SelectedIndexChanged += ddPreviewTarget_SelectedIndexChanged;

            if (_entity.NoTemplateOveride) { radioTemplateNone.Checked = true; } else { radioTemplateNone.Checked = false; }
            if (_entity.useGrayTemplateOveride) { radioTemplateGray.Checked = true; } else { radioTemplateGray.Checked = false; }
            if (_entity.useWhiteTemplateOveride) { radioTemplateWhite.Checked = true; } else { radioTemplateWhite.Checked = false; }
            if (_entity.useHideTemplateOveride) { radioTemplateHide.Checked = true; } else { radioTemplateHide.Checked = false; }
            if (_entity.useHighlightTemplateOveride) { radioTemplateHighlight.Checked = true; } else { radioTemplateHighlight.Checked = false; }
            if (_entity.useCustomTemplate1Overide) { radioTemplateCustom1.Checked = true; } else { radioTemplateCustom1.Checked = false; }
            if (_entity.useCustomTemplate2Overide) { radioTemplateCustom2.Checked = true; } else { radioTemplateCustom2.Checked = false; }
            if (_entity.useCustomTemplate3Overide) { radioTemplateCustom3.Checked = true; } else { radioTemplateCustom3.Checked = false; }
            if (_entity.useCustomTemplate4Overide) { radioTemplateCustom4.Checked = true; } else { radioTemplateCustom4.Checked = false; }
            if (_entity.useCustomTemplate5Overide) { radioTemplateCustom5.Checked = true; } else { radioTemplateCustom5.Checked = false; }

            radioTemplateCustom1.Text = "Template: " + _configuration.ItemsFilterCustomTemplate1Name;
            radioTemplateCustom2.Text = "Template: " + _configuration.ItemsFilterCustomTemplate2Name;
            radioTemplateCustom3.Text = "Template: " + _configuration.ItemsFilterCustomTemplate3Name;
            radioTemplateCustom4.Text = "Template: " + _configuration.ItemsFilterCustomTemplate4Name;
            radioTemplateCustom5.Text = "Template: " + _configuration.ItemsFilterCustomTemplate5Name;

        }

        private void LoadPreviews()
        {
            // Clear all previews
            rtbPreview.Text = string.Empty;
            string dataToPreview = txtenUS.Text;
            string dataRemainingToParse = dataToPreview;
            Color currentTextColor = Color.WhiteSmoke;
            bool currentBoldFlag = false;

            if (radioTemplateHide.Checked)
            {
                AppendPreviewText("_", Color.Black);
                return;
            }
            else if (radioTemplateGray.Checked)
            {
                AppendPreviewText(dataToPreview, Color.DarkGray);
                return;
            }
            else if (radioTemplateWhite.Checked)
            {
                AppendPreviewText(dataToPreview, Color.White);
                return;
            }
            else if (radioTemplateHighlight.Checked)
            {
                AppendPreviewText("-= " + dataToPreview.ToUpperInvariant() + " =-", Color.White);
                return;
            }
            else if (radioTemplateCustom1.Checked)
            {
                AppendPreviewText(
                    _configuration.ItemsFilterCustomTemplate1Preffix + dataToPreview + _configuration.ItemsFilterCustomTemplate1Suffix,
                    Color.White);
                return;
            }
            else if (radioTemplateCustom2.Checked)
            {
                AppendPreviewText(
                    _configuration.ItemsFilterCustomTemplate2Preffix + dataToPreview + _configuration.ItemsFilterCustomTemplate2Suffix,
                    Color.White);
                return;
            }
            else if (radioTemplateCustom3.Checked)
            {
                AppendPreviewText(
                    _configuration.ItemsFilterCustomTemplate3Preffix + dataToPreview + _configuration.ItemsFilterCustomTemplate3Suffix,
                    Color.White);
                return;
            }
            else if (radioTemplateCustom4.Checked)
            {
                AppendPreviewText(
                    _configuration.ItemsFilterCustomTemplate4Preffix + dataToPreview + _configuration.ItemsFilterCustomTemplate4Suffix,
                    Color.White);
                return;
            }
            else if (radioTemplateCustom5.Checked)
            {
                AppendPreviewText(
                    _configuration.ItemsFilterCustomTemplate5Preffix + dataToPreview + _configuration.ItemsFilterCustomTemplate5Suffix,
                    Color.White);
                return;
            }
            else
            {

                while (dataRemainingToParse != string.Empty)
                {
                    /* 
                    ÿc1 = Red
                    ÿc2 = Blue
                    ÿc3 = Green
                    ÿc4 = Gold
                    ÿc8 = Orange
                    ÿc- = Normal White
                    ÿc: = Dark Green
                    ÿc0 = Other White
                    ÿc5 = Grey
                    ÿc6 = Black
                    ÿc7 = Gold
                    ÿc9 = Yellow
                    ÿc; = Purple
                    ÿc- = Bold
                    ÿc+ = Light Blue 

                    ÿc0 - Light Gray (Item Descriptions)
                    ÿc1 - Red
                    ÿc2 - Bright Green (Set Items)
                    ÿc3 - Blue (Magic Items)
                    ÿc4 - Gold (Unique Items)
                    ÿc5 - Dark Gray (Socketed/Ethereal Items)
                    ÿc6 - Transparent (Text Doesn't Show)
                    ÿc7 - Tan
                    ÿc8 - Orange (Crafted Items)
                    ÿc9 - Yellow (Rare Items)
                    ÿc: - Dark Green
                    ÿc; - Purple
                    ÿc/ - White (Brighter than Light Gray)
                    ÿc. - Messed Up White (Same as above but text is messed up) */

                    if (dataRemainingToParse.StartsWith("ÿc0", StringComparison.InvariantCultureIgnoreCase)) { currentTextColor = Color.White; dataRemainingToParse = dataRemainingToParse.Remove(0, 3); continue; }
                    if (dataRemainingToParse.StartsWith("ÿc1", StringComparison.InvariantCultureIgnoreCase)) { currentTextColor = Color.Red; dataRemainingToParse = dataRemainingToParse.Remove(0, 3); continue; }
                    if (dataRemainingToParse.StartsWith("ÿc2", StringComparison.InvariantCultureIgnoreCase)) { currentTextColor = Color.Green; dataRemainingToParse = dataRemainingToParse.Remove(0, 3); continue; }
                    if (dataRemainingToParse.StartsWith("ÿc3", StringComparison.InvariantCultureIgnoreCase)) { currentTextColor = Color.Blue; dataRemainingToParse = dataRemainingToParse.Remove(0, 3); continue; }
                    if (dataRemainingToParse.StartsWith("ÿc4", StringComparison.InvariantCultureIgnoreCase)) { currentTextColor = Color.Gold; dataRemainingToParse = dataRemainingToParse.Remove(0, 3); continue; }
                    if (dataRemainingToParse.StartsWith("ÿc5", StringComparison.InvariantCultureIgnoreCase)) { currentTextColor = Color.DarkGray; dataRemainingToParse = dataRemainingToParse.Remove(0, 3); continue; }
                    if (dataRemainingToParse.StartsWith("ÿc6", StringComparison.InvariantCultureIgnoreCase)) { currentTextColor = Color.Black; dataRemainingToParse = dataRemainingToParse.Remove(0, 3); continue; }
                    if (dataRemainingToParse.StartsWith("ÿc7", StringComparison.InvariantCultureIgnoreCase)) { currentTextColor = Color.Tan; dataRemainingToParse = dataRemainingToParse.Remove(0, 3); continue; }
                    if (dataRemainingToParse.StartsWith("ÿc8", StringComparison.InvariantCultureIgnoreCase)) { currentTextColor = Color.Orange; dataRemainingToParse = dataRemainingToParse.Remove(0, 3); continue; }
                    if (dataRemainingToParse.StartsWith("ÿc9", StringComparison.InvariantCultureIgnoreCase)) { currentTextColor = Color.Yellow; dataRemainingToParse = dataRemainingToParse.Remove(0, 3); continue; }
                    if (dataRemainingToParse.StartsWith("ÿc:", StringComparison.InvariantCultureIgnoreCase)) { currentTextColor = Color.DarkGreen; dataRemainingToParse = dataRemainingToParse.Remove(0, 3); continue; }
                    if (dataRemainingToParse.StartsWith("ÿc;", StringComparison.InvariantCultureIgnoreCase)) { currentTextColor = Color.DarkViolet; dataRemainingToParse = dataRemainingToParse.Remove(0, 3); continue; }
                    if (dataRemainingToParse.StartsWith("ÿc/", StringComparison.InvariantCultureIgnoreCase)) { currentTextColor = Color.White; dataRemainingToParse = dataRemainingToParse.Remove(0, 3); continue; }
                    if (dataRemainingToParse.StartsWith("ÿc.", StringComparison.InvariantCultureIgnoreCase)) { currentTextColor = Color.WhiteSmoke; dataRemainingToParse = dataRemainingToParse.Remove(0, 3); continue; }
                    if (dataRemainingToParse.StartsWith("ÿcT", StringComparison.InvariantCultureIgnoreCase)) { currentTextColor = Color.SkyBlue; dataRemainingToParse = dataRemainingToParse.Remove(0, 3); continue; }
                    if (dataRemainingToParse.StartsWith("ÿcN", StringComparison.InvariantCultureIgnoreCase)) { currentTextColor = Color.DeepSkyBlue; dataRemainingToParse = dataRemainingToParse.Remove(0, 3); continue; }
                    if (dataRemainingToParse.StartsWith("ÿc-", StringComparison.InvariantCultureIgnoreCase)) { currentBoldFlag = true; dataRemainingToParse = dataRemainingToParse.Remove(0, 3); continue; }

                    if (dataRemainingToParse.Length > 0)
                    {
                        string charToPrint = dataRemainingToParse.Substring(0, 1);
                        dataRemainingToParse = dataRemainingToParse.Remove(0, 1);

                        AppendPreviewText(charToPrint, currentTextColor);
                    }

                }
            }

        }



        private void AppendPreviewText(string text, Color color)
        {
            

            rtbPreview.SelectionStart = rtbPreview.TextLength;
            rtbPreview.SelectionLength = 0;
            rtbPreview.SelectionColor = color;
            rtbPreview.AppendText(text);
            rtbPreview.SelectionColor = rtbPreview.ForeColor;

        }

 
        private void ddPreviewTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPreviews();
        }

        private void txtenUS_KeyUp(object sender, KeyEventArgs e)
        {
            LoadPreviews();
            _entity.enUS = txtenUS.Text;
        }

        private void txtzhTW_KeyUp(object sender, KeyEventArgs e)
        {
            LoadPreviews();
            _entity.zhTW= txtzhTW.Text;
        }

        private void txdeDE_KeyUp(object sender, KeyEventArgs e)
        {
            LoadPreviews();
            _entity.deDE= txdeDE.Text;
        }

        private void txesES_KeyUp(object sender, KeyEventArgs e)
        {
            LoadPreviews();
            _entity.esES= txesES.Text;
        }

        private void txtfrFR_KeyUp(object sender, KeyEventArgs e)
        {
            LoadPreviews();
            _entity.frFR= txtfrFR.Text;
        }

        private void txtitIT_KeyUp(object sender, KeyEventArgs e)
        {
            LoadPreviews();
            _entity.itIT = txtitIT.Text;
        }

        private void txtkoKO_KeyUp(object sender, KeyEventArgs e)
        {
            LoadPreviews();
            _entity.koKR= txtkoKO.Text;
        }

        private void txtplPL_KeyUp(object sender, KeyEventArgs e)
        {
            LoadPreviews();
            _entity.plPL= txtplPL.Text;
        }

        private void txtesMX_KeyUp(object sender, KeyEventArgs e)
        {
            LoadPreviews();
            _entity.esMX= txtesMX.Text;
        }

        private void txtjaJP_KeyUp(object sender, KeyEventArgs e)
        {
            LoadPreviews();
            _entity.jaJP = txtjaJP.Text;
        }

        private void txtptBR_KeyUp(object sender, KeyEventArgs e)
        {
            LoadPreviews();
            _entity.ptBR= txtptBR.Text;
        }

        private void txtruRU_KeyUp(object sender, KeyEventArgs e)
        {
            LoadPreviews();
            _entity.ruRU= txtruRU.Text;
        }

        private void txtzhCN_KeyUp(object sender, KeyEventArgs e)
        {
            LoadPreviews();
            _entity.zhCN= txtzhCN.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {


            try
            {
                if (onItemFilterEnhancedEntityUpdated != null)
                {
                    onItemFilterEnhancedEntityUpdated(this._entity);
                }

                this.Close();
            }
            catch
            { }
        }

        private void ucItemsFilterCharsButtonsHelper1_Load(object sender, EventArgs e)
        {

        }

        private void btnRestoreDefaultData_Click(object sender, EventArgs e)
        {
            List<ItemFilterBaseEntity> _originalEntities = new List<ItemFilterBaseEntity>();

            switch (_resourceName)
            {
                case "item-runes.json": { _originalEntities = Helpers.getItemsFilterOriginalDataEntitiesByResourceName("item-runes.json"); break; }
                case "item-names.json": { _originalEntities = Helpers.getItemsFilterOriginalDataEntitiesByResourceName("item-names.json"); break; }
                case "item-nameaffixes.json": { _originalEntities = Helpers.getItemsFilterOriginalDataEntitiesByResourceName("item-nameaffixes.json"); break; }
            }

            foreach (ItemFilterBaseEntity entity in _originalEntities)
            {
                if (entity.id == _entity.id)
                {
                    _entity.enUS = entity.enUS;
                    _entity.esMX = entity.esMX;
                    _entity.frFR = entity.frFR;
                    _entity.itIT = entity.itIT;
                    _entity.jaJP = entity.jaJP;
                    _entity.koKR = entity.koKR;
                    _entity.plPL = entity.plPL;
                    _entity.ptBR = entity.ptBR;
                    _entity.ruRU = entity.ruRU;
                    _entity.zhCN = entity.zhCN;
                    _entity.zhTW = entity.zhTW;

                    _entity.NoTemplateOveride = true;
                    _entity.useHideTemplateOveride = false;
                    _entity.useGrayTemplateOveride = false;
                    _entity.useWhiteTemplateOveride = false;
                    _entity.useHighlightTemplateOveride = false;
                    _entity.useCustomTemplate1Overide = false;
                    _entity.useCustomTemplate2Overide = false;
                    _entity.useCustomTemplate3Overide = false;
                    _entity.useCustomTemplate4Overide = false;
                    _entity.useCustomTemplate5Overide = false;

                    LoadData();

                    LoadPreviews();

                    radioTemplateNone.Checked = true;
                    break;
                }
            }
        }

        private void radioTemplateNone_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                _entity.NoTemplateOveride = true;
                _entity.useHideTemplateOveride = false;
                _entity.useGrayTemplateOveride = false;
                _entity.useWhiteTemplateOveride = false;
                _entity.useHighlightTemplateOveride = false;
                _entity.useCustomTemplate1Overide = false;
                _entity.useCustomTemplate2Overide = false;
                _entity.useCustomTemplate3Overide = false;
                _entity.useCustomTemplate4Overide = false;
                _entity.useCustomTemplate5Overide = false;
            }

            LoadPreviews();
        }

        private void radioTemplateHide_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                _entity.NoTemplateOveride = false;
                _entity.useHideTemplateOveride = true;
                _entity.useGrayTemplateOveride = false;
                _entity.useWhiteTemplateOveride = false;
                _entity.useHighlightTemplateOveride = false;
                _entity.useCustomTemplate1Overide = false;
                _entity.useCustomTemplate2Overide = false;
                _entity.useCustomTemplate3Overide = false;
                _entity.useCustomTemplate4Overide = false;
                _entity.useCustomTemplate5Overide = false;
            }

            LoadPreviews();
        }

        private void radioTemplateGray_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                _entity.NoTemplateOveride = false;
                _entity.useHideTemplateOveride = false;
                _entity.useGrayTemplateOveride = true;
                _entity.useWhiteTemplateOveride = false;
                _entity.useHighlightTemplateOveride = false;
                _entity.useCustomTemplate1Overide = false;
                _entity.useCustomTemplate2Overide = false;
                _entity.useCustomTemplate3Overide = false;
                _entity.useCustomTemplate4Overide = false;
                _entity.useCustomTemplate5Overide = false;
            }

            LoadPreviews();
        }

        private void radioTemplateWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                _entity.NoTemplateOveride = false;
                _entity.useHideTemplateOveride = false;
                _entity.useGrayTemplateOveride = false;
                _entity.useWhiteTemplateOveride = true;
                _entity.useHighlightTemplateOveride = false;
                _entity.useCustomTemplate1Overide = false;
                _entity.useCustomTemplate2Overide = false;
                _entity.useCustomTemplate3Overide = false;
                _entity.useCustomTemplate4Overide = false;
                _entity.useCustomTemplate5Overide = false;
            }

            LoadPreviews();
        }

        private void radioTemplateHighlight_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                _entity.NoTemplateOveride = false;
                _entity.useHideTemplateOveride = false;
                _entity.useGrayTemplateOveride = false;
                _entity.useWhiteTemplateOveride = false;
                _entity.useHighlightTemplateOveride = true;
                _entity.useCustomTemplate1Overide = false;
                _entity.useCustomTemplate2Overide = false;
                _entity.useCustomTemplate3Overide = false;
                _entity.useCustomTemplate4Overide = false;
                _entity.useCustomTemplate5Overide = false;
            }

            LoadPreviews();
        }

        private void radioTemplateCustom1_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                _entity.NoTemplateOveride = false;
                _entity.useHideTemplateOveride = false;
                _entity.useGrayTemplateOveride = false;
                _entity.useWhiteTemplateOveride = false;
                _entity.useHighlightTemplateOveride = false;
                _entity.useCustomTemplate1Overide = true;
                _entity.useCustomTemplate2Overide = false;
                _entity.useCustomTemplate3Overide = false;
                _entity.useCustomTemplate4Overide = false;
                _entity.useCustomTemplate5Overide = false;
            }

            LoadPreviews();
        }

        private void radioTemplateCustom2_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                _entity.NoTemplateOveride = false;
                _entity.useHideTemplateOveride = false;
                _entity.useGrayTemplateOveride = false;
                _entity.useWhiteTemplateOveride = false;
                _entity.useHighlightTemplateOveride = false;
                _entity.useCustomTemplate1Overide = false;
                _entity.useCustomTemplate2Overide = true;
                _entity.useCustomTemplate3Overide = false;
                _entity.useCustomTemplate4Overide = false;
                _entity.useCustomTemplate5Overide = false;
            }

            LoadPreviews();
        }

        private void radioTemplateCustom3_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                _entity.NoTemplateOveride = false;
                _entity.useHideTemplateOveride = false;
                _entity.useGrayTemplateOveride = false;
                _entity.useWhiteTemplateOveride = false;
                _entity.useHighlightTemplateOveride = false;
                _entity.useCustomTemplate1Overide = false;
                _entity.useCustomTemplate2Overide = false;
                _entity.useCustomTemplate3Overide = true;
                _entity.useCustomTemplate4Overide = false;
                _entity.useCustomTemplate5Overide = false;
            }

            LoadPreviews();
        }

        private void radioTemplateCustom4_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                _entity.NoTemplateOveride = false;
                _entity.useHideTemplateOveride = false;
                _entity.useGrayTemplateOveride = false;
                _entity.useWhiteTemplateOveride = false;
                _entity.useHighlightTemplateOveride = false;
                _entity.useCustomTemplate1Overide = false;
                _entity.useCustomTemplate2Overide = false;
                _entity.useCustomTemplate3Overide = false;
                _entity.useCustomTemplate4Overide = true;
                _entity.useCustomTemplate5Overide = false;
            }

            LoadPreviews();
        }

        private void radioTemplateCustom5_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                _entity.NoTemplateOveride = false;
                _entity.useHideTemplateOveride = false;
                _entity.useGrayTemplateOveride = false;
                _entity.useWhiteTemplateOveride = false;
                _entity.useHighlightTemplateOveride = false;
                _entity.useCustomTemplate1Overide = false;
                _entity.useCustomTemplate2Overide = false;
                _entity.useCustomTemplate3Overide = false;
                _entity.useCustomTemplate4Overide = false;
                _entity.useCustomTemplate5Overide = true;
            }

            LoadPreviews();
        }
    }
}
