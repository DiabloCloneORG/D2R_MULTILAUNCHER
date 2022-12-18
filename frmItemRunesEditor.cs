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
    public partial class frmItemRunesEditor : Form
    {
        List<ItemFilterEnhancedEntity> _entities;
        ConfigurationEntity _configuration;

        public frmItemRunesEditor(ConfigurationEntity configuration)
        {
            InitializeComponent();

            _entities = new List<ItemFilterEnhancedEntity>();
            _configuration = configuration;
        }

        private void frmItemRunesEditor_Load(object sender, EventArgs e)
        {
            LoadEntities();

            ddSearchTarget.SelectedIndex = 1;
        }

        private void LoadEntities()
        {
            try
            {
                string item_jsondata = System.IO.File.ReadAllText(Application.StartupPath + @"\item-runes-enhanced.json");

                _entities.Clear();
                _entities = JsonSerializer.Deserialize<List<ItemFilterEnhancedEntity>>(item_jsondata);

                gridviewEntities.DataSource = null;
                gridviewEntities.Refresh();

                gridviewEntities.DataSource = _entities;

                this.Text = "Items Filter [" + _entities.Count.ToString() + " RUNES/RUNEWORDS]";

                colorGridView();

            }
            catch
            {
                
            }
        }
        
        private void colorGridView()
        {
            for (int index = 0; index < gridviewEntities.Rows.Count; index++)
            {
                ItemFilterEnhancedEntity entity = (ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem;
                if (entity.useHideTemplateOveride)
                {
                    for (int index2 = 0; index2 < gridviewEntities.Columns.Count; index2++)
                    {
                        gridviewEntities.Rows[index].Cells[index2].Style.ForeColor = Color.Gray;
                        gridviewEntities.Rows[index].Cells[index2].Style.BackColor = Color.DarkGray;
                    }
                }
                else if (entity.useGrayTemplateOveride)
                {
                    for (int index2 = 0; index2 < gridviewEntities.Columns.Count; index2++)
                    {
                        gridviewEntities.Rows[index].Cells[index2].Style.ForeColor = Color.Black;
                        gridviewEntities.Rows[index].Cells[index2].Style.BackColor = Color.Gray;
                    }
                }
                else if (entity.useWhiteTemplateOveride)
                {
                    for (int index2 = 0; index2 < gridviewEntities.Columns.Count; index2++)
                    {
                        gridviewEntities.Rows[index].Cells[index2].Style.ForeColor = Color.White;
                        gridviewEntities.Rows[index].Cells[index2].Style.BackColor = Color.Black;
                    }
                }
                else
                {
                    for (int index2 = 0; index2 < gridviewEntities.Columns.Count; index2++)
                    {
                        gridviewEntities.Rows[index].Cells[index2].Style.ForeColor = Color.Black;
                        gridviewEntities.Rows[index].Cells[index2].Style.BackColor = Color.White;
                    }
                }
            }
        }

        private void txtKeywordFilter_KeyUp(object sender, KeyEventArgs e)
        {
            filterEntitiesByKeyword(txtKeywordFilter.Text);
        }

        private void filterEntitiesByKeyword(string keyword)
        {
            try
            {
                if (keyword.Length > 0)
                {
                    List<ItemFilterEnhancedEntity> _filtered_entities = new List<ItemFilterEnhancedEntity>();

                    foreach (ItemFilterEnhancedEntity entity in _entities)
                    {
                        if ((ddSearchTarget.SelectedIndex == 0 || ddSearchTarget.SelectedIndex == 14) && entity.Key.Contains(keyword, StringComparison.InvariantCultureIgnoreCase)) { _filtered_entities.Add(entity); continue; }
                        if ((ddSearchTarget.SelectedIndex == 1 || ddSearchTarget.SelectedIndex == 14) && entity.enUS.Contains(keyword, StringComparison.InvariantCultureIgnoreCase)) { _filtered_entities.Add(entity); continue; }
                        if ((ddSearchTarget.SelectedIndex == 2 || ddSearchTarget.SelectedIndex == 14) && entity.zhTW.Contains(keyword, StringComparison.InvariantCultureIgnoreCase)) { _filtered_entities.Add(entity); continue; }
                        if ((ddSearchTarget.SelectedIndex == 3 || ddSearchTarget.SelectedIndex == 14) && entity.deDE.Contains(keyword, StringComparison.InvariantCultureIgnoreCase)) { _filtered_entities.Add(entity); continue; }
                        if ((ddSearchTarget.SelectedIndex == 4 || ddSearchTarget.SelectedIndex == 14) && entity.esES.Contains(keyword, StringComparison.InvariantCultureIgnoreCase)) { _filtered_entities.Add(entity); continue; }
                        if ((ddSearchTarget.SelectedIndex == 5 || ddSearchTarget.SelectedIndex == 14) && entity.frFR.Contains(keyword, StringComparison.InvariantCultureIgnoreCase)) { _filtered_entities.Add(entity); continue; }
                        if ((ddSearchTarget.SelectedIndex == 6 || ddSearchTarget.SelectedIndex == 14) && entity.itIT.Contains(keyword, StringComparison.InvariantCultureIgnoreCase)) { _filtered_entities.Add(entity); continue; }
                        if ((ddSearchTarget.SelectedIndex == 7 || ddSearchTarget.SelectedIndex == 14) && entity.koKR.Contains(keyword, StringComparison.InvariantCultureIgnoreCase)) { _filtered_entities.Add(entity); continue; }
                        if ((ddSearchTarget.SelectedIndex == 8 || ddSearchTarget.SelectedIndex == 14) && entity.plPL.Contains(keyword, StringComparison.InvariantCultureIgnoreCase)) { _filtered_entities.Add(entity); continue; }
                        if ((ddSearchTarget.SelectedIndex == 9 || ddSearchTarget.SelectedIndex == 14) && entity.esMX.Contains(keyword, StringComparison.InvariantCultureIgnoreCase)) { _filtered_entities.Add(entity); continue; }
                        if ((ddSearchTarget.SelectedIndex == 10 || ddSearchTarget.SelectedIndex == 14) && entity.jaJP.Contains(keyword, StringComparison.InvariantCultureIgnoreCase)) { _filtered_entities.Add(entity); continue; }
                        if ((ddSearchTarget.SelectedIndex == 11 || ddSearchTarget.SelectedIndex == 14) && entity.ptBR.Contains(keyword, StringComparison.InvariantCultureIgnoreCase)) { _filtered_entities.Add(entity); continue; }
                        if ((ddSearchTarget.SelectedIndex == 12 || ddSearchTarget.SelectedIndex == 14) && entity.ruRU.Contains(keyword, StringComparison.InvariantCultureIgnoreCase)) { _filtered_entities.Add(entity); continue; }
                        if ((ddSearchTarget.SelectedIndex == 13 || ddSearchTarget.SelectedIndex == 14) && entity.zhCN.Contains(keyword, StringComparison.InvariantCultureIgnoreCase)) { _filtered_entities.Add(entity); continue; }
                        
                    }

                    gridviewEntities.DataSource = null;
                    gridviewEntities.Refresh();

                    gridviewEntities.DataSource = _filtered_entities;
                    this.Text = "Items Filter [" + _filtered_entities.Count.ToString() + " RUNES/RUNEWORDS MATCHING]";

                    colorGridView();
                }
                else
                {
                    gridviewEntities.DataSource = _entities;
                    this.Text = "Items Filter [" + _entities.Count.ToString() + " RUNES/RUNEWORDS MATCHING]";

                    colorGridView();
                }

                

            }
            catch
            {
                
            }
        }

        private void ddSearchTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterEntitiesByKeyword(txtKeywordFilter.Text);
        }

        frmItemFilterEntityEditRecord _frmItemRunesEditorEditRecord;
        private void gridviewEntities_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gridviewEntities.SelectedRows.Count == 0) { return; }
            else if (gridviewEntities.SelectedRows.Count == 1) 
            {
                ItemFilterEnhancedEntity dataBindObject = (ItemFilterEnhancedEntity)gridviewEntities.SelectedRows[0].DataBoundItem;

                if (_frmItemRunesEditorEditRecord != null)
                {
                    try
                    {
                        _frmItemRunesEditorEditRecord.Dispose();
                        _frmItemRunesEditorEditRecord = null;
                    }
                    catch { }
                }
                _frmItemRunesEditorEditRecord = new frmItemFilterEntityEditRecord(dataBindObject, "item-runes.json");
                _frmItemRunesEditorEditRecord.onItemFilterEnhancedEntityUpdated += _frmItemRunesEditorEditRecord_onItemFilterEnhancedEntityUpdated;
                _frmItemRunesEditorEditRecord.ShowDialog(this);
            }
        }

        private void _frmItemRunesEditorEditRecord_onItemFilterEnhancedEntityUpdated(ItemFilterEnhancedEntity updated_entity)
        {

            updateGridViewRowByEntity(updated_entity);

            Helpers.saveItemsFilterDataFile(_configuration, _entities, "item-runes.json", "item-runes-enhanced.json");
        }

        private void updateGridViewRowByEntity(ItemFilterEnhancedEntity updated_entity)
        {
            for (int index = 0; index < gridviewEntities.Rows.Count; index++)
            {
                if (((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).id == updated_entity.id)
                {
                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).deDE = updated_entity.deDE;
                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).enUS = updated_entity.enUS;
                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).esES = updated_entity.esES;
                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).esMX = updated_entity.esMX;
                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).frFR = updated_entity.frFR;
                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).itIT = updated_entity.itIT;
                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).jaJP = updated_entity.jaJP;
                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).koKR = updated_entity.koKR;
                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).plPL = updated_entity.plPL;
                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).ptBR = updated_entity.ptBR;
                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).ruRU = updated_entity.ruRU;
                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).zhCN = updated_entity.zhCN;
                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).zhTW = updated_entity.zhTW;

                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).NoTemplateOveride = updated_entity.NoTemplateOveride;
                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).useGrayTemplateOveride = updated_entity.useGrayTemplateOveride;
                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).useWhiteTemplateOveride = updated_entity.useWhiteTemplateOveride;
                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).useHighlightTemplateOveride = updated_entity.useHighlightTemplateOveride;
                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).useHideTemplateOveride = updated_entity.useHideTemplateOveride;
                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).useCustomTemplate1Overide = updated_entity.useCustomTemplate1Overide;
                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).useCustomTemplate2Overide = updated_entity.useCustomTemplate2Overide;
                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).useCustomTemplate3Overide = updated_entity.useCustomTemplate3Overide;
                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).useCustomTemplate4Overide = updated_entity.useCustomTemplate4Overide;
                    ((ItemFilterEnhancedEntity)gridviewEntities.Rows[index].DataBoundItem).useCustomTemplate5Overide = updated_entity.useCustomTemplate5Overide;

                    break;
                }
            }
        }

        private void btnResetToOriginal_Click(object sender, EventArgs e)
        {
            Helpers.restoreItemsFilterCustomItemRunesDataFile();

            LoadEntities();

            ddSearchTarget.SelectedIndex = 1;

            MessageBox.Show(this, "The Data has been reset successfully.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnImportFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.AddExtension = false;
            dialog.CheckFileExists = true;
            dialog.Filter = "Items JSON Files (item-runes-enhanced.json)|item-runes-enhanced.json";
            dialog.InitialDirectory = Application.StartupPath;
            dialog.Title = "Please select a VALID item-runes-enhanced.json (ENHANCED VERSION) to restore:";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string import_filepath = dialog.FileName;

                Helpers.importItemsFilterDataFile(
                    import_filepath,
                    "item-runes.json",
                    "item-runes-enhanced.json");
                
                LoadEntities();

                MessageBox.Show(this, "File imported successfully.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportToFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            // dialog.ShowHiddenFiles = false;
            // dialog.ShowPinnedPlaces = false;
            dialog.ShowNewFolderButton = true;
            dialog.UseDescriptionForTitle = true;
            dialog.Description = "Please select a location to SAVE A BACKUP of the item-names.json:";
            dialog.InitialDirectory = Application.StartupPath;
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = dialog.SelectedPath + "\\item-runes.json";
                Helpers.exportItemsFilterDataFile(filepath, "item-runes-enhanced.json");

                MessageBox.Show(this, "File exported successfully to -> " + filepath, "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridviewEntities.SelectedRows.Count>0)
            {

                for (int rowindex = 0; rowindex < gridviewEntities.SelectedRows.Count; rowindex++)
                {
                    for (int index = 0; index < _entities.Count; index++)
                    {
                        if (_entities[index].id == ((ItemFilterEnhancedEntity)gridviewEntities.SelectedRows[rowindex].DataBoundItem).id) {
                            _entities[index].useHideTemplateOveride = true;
                            _entities[index].useGrayTemplateOveride = false;
                            _entities[index].useWhiteTemplateOveride = false;
                            _entities[index].useHighlightTemplateOveride = false;
                            _entities[index].useCustomTemplate1Overide = false;
                            _entities[index].useCustomTemplate2Overide = false;
                            _entities[index].useCustomTemplate3Overide = false;
                            _entities[index].useCustomTemplate4Overide = false;
                            _entities[index].useCustomTemplate5Overide = false;
                            _entities[index].NoTemplateOveride = false;
                            break; 
                        }
                    }
                }

                Helpers.saveItemsFilterDataFile(_configuration, _entities, "item-runes.json", "item-runes-enhanced.json");

                gridviewEntities.DataSource = null;
                gridviewEntities.Refresh();

                gridviewEntities.DataSource = _entities;
                gridviewEntities.Refresh();

                this.Text = "Items Filter [" + _entities.Count.ToString() + " RUNES/RUNEWORDS]";

                if (txtKeywordFilter.Text.Length > 0)
                {
                    filterEntitiesByKeyword(txtKeywordFilter.Text);
                }
                
                colorGridView();
            }
        }

        private void resetToDefaultValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridviewEntities.SelectedRows.Count > 0)
            {
                List<ItemFilterBaseEntity> _originalEntities = new List<ItemFilterBaseEntity>();
                _originalEntities = Helpers.getItemsFilterOriginalDataEntitiesByResourceName("item-runes.json");

                for (int rowindex = 0; rowindex < gridviewEntities.SelectedRows.Count; rowindex++)
                {
                    for (int index = 0; index < _entities.Count; index++)
                    {
                        if (_entities[index].id == ((ItemFilterEnhancedEntity)gridviewEntities.SelectedRows[rowindex].DataBoundItem).id)
                        {
                            foreach (ItemFilterBaseEntity original_entity in _originalEntities)
                            {
                                if (original_entity.id == _entities[index].id)
                                {
                                    _entities[index].enUS = original_entity.enUS;
                                    _entities[index].esMX = original_entity.esMX;
                                    _entities[index].frFR = original_entity.frFR;
                                    _entities[index].itIT = original_entity.itIT;
                                    _entities[index].jaJP = original_entity.jaJP;
                                    _entities[index].koKR = original_entity.koKR;
                                    _entities[index].plPL = original_entity.plPL;
                                    _entities[index].ptBR = original_entity.ptBR;
                                    _entities[index].ruRU = original_entity.ruRU;
                                    _entities[index].zhCN = original_entity.zhCN;
                                    _entities[index].zhTW = original_entity.zhTW;

                                    break;
                                }
                            }
                            break;
                        }
                    }
                }

                Helpers.saveItemsFilterDataFile(_configuration, _entities, "item-runes.json", "item-runes-enhanced.json");

                gridviewEntities.DataSource = null;
                gridviewEntities.Refresh();

                gridviewEntities.DataSource = _entities;
                gridviewEntities.Refresh();

                this.Text = "Items Filter [" + _entities.Count.ToString() + " RUNES/RUNEWORDS]";

                if (txtKeywordFilter.Text.Length > 0)
                {
                    filterEntitiesByKeyword(txtKeywordFilter.Text);
                }

                colorGridView();
            }
        }

        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridviewEntities.SelectedRows.Count > 0)
            {

                for (int rowindex = 0; rowindex < gridviewEntities.SelectedRows.Count; rowindex++)
                {
                    for (int index = 0; index < _entities.Count; index++)
                    {
                        if (_entities[index].id == ((ItemFilterEnhancedEntity)gridviewEntities.SelectedRows[rowindex].DataBoundItem).id)
                        {
                            _entities[index].useHideTemplateOveride = false;
                            _entities[index].useGrayTemplateOveride = true;
                            _entities[index].useWhiteTemplateOveride = false;
                            _entities[index].useHighlightTemplateOveride = false;
                            _entities[index].useCustomTemplate1Overide = false;
                            _entities[index].useCustomTemplate2Overide = false;
                            _entities[index].useCustomTemplate3Overide = false;
                            _entities[index].useCustomTemplate4Overide = false;
                            _entities[index].useCustomTemplate5Overide = false;
                            _entities[index].NoTemplateOveride = false;
                            break;
                        }
                    }
                }

                Helpers.saveItemsFilterDataFile(_configuration, _entities, "item-runes.json", "item-runes-enhanced.json");

                gridviewEntities.DataSource = null;
                gridviewEntities.Refresh();

                gridviewEntities.DataSource = _entities;
                gridviewEntities.Refresh();

                this.Text = "Items Filter [" + _entities.Count.ToString() + " RUNES/RUNEWORDS]";

                if (txtKeywordFilter.Text.Length > 0)
                {
                    filterEntitiesByKeyword(txtKeywordFilter.Text);
                }

                colorGridView();
            }
        }

        private void setToToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridviewEntities.SelectedRows.Count > 0)
            {

                for (int rowindex = 0; rowindex < gridviewEntities.SelectedRows.Count; rowindex++)
                {
                    for (int index = 0; index < _entities.Count; index++)
                    {
                        if (_entities[index].id == ((ItemFilterEnhancedEntity)gridviewEntities.SelectedRows[rowindex].DataBoundItem).id)
                        {
                            _entities[index].useHideTemplateOveride = false;
                            _entities[index].useGrayTemplateOveride = false;
                            _entities[index].useWhiteTemplateOveride = true;
                            _entities[index].useHighlightTemplateOveride = false;
                            _entities[index].useCustomTemplate1Overide = false;
                            _entities[index].useCustomTemplate2Overide = false;
                            _entities[index].useCustomTemplate3Overide = false;
                            _entities[index].useCustomTemplate4Overide = false;
                            _entities[index].useCustomTemplate5Overide = false;
                            _entities[index].NoTemplateOveride = false;
                            break;
                        }
                    }
                }

                Helpers.saveItemsFilterDataFile(_configuration, _entities, "item-runes.json", "item-runes-enhanced.json");

                gridviewEntities.DataSource = null;
                gridviewEntities.Refresh();

                gridviewEntities.DataSource = _entities;
                gridviewEntities.Refresh();

                this.Text = "Items Filter [" + _entities.Count.ToString() + " RUNES/RUNEWORDS]";

                if (txtKeywordFilter.Text.Length > 0)
                {
                    filterEntitiesByKeyword(txtKeywordFilter.Text);
                }

                colorGridView();
            }
        }

        private void highlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridviewEntities.SelectedRows.Count > 0)
            {

                for (int rowindex = 0; rowindex < gridviewEntities.SelectedRows.Count; rowindex++)
                {
                    for (int index = 0; index < _entities.Count; index++)
                    {
                        if (_entities[index].id == ((ItemFilterEnhancedEntity)gridviewEntities.SelectedRows[rowindex].DataBoundItem).id)
                        {
                            _entities[index].useHideTemplateOveride = false;
                            _entities[index].useGrayTemplateOveride = false;
                            _entities[index].useWhiteTemplateOveride = false;
                            _entities[index].useHighlightTemplateOveride = true;
                            _entities[index].useCustomTemplate1Overide = false;
                            _entities[index].useCustomTemplate2Overide = false;
                            _entities[index].useCustomTemplate3Overide = false;
                            _entities[index].useCustomTemplate4Overide = false;
                            _entities[index].useCustomTemplate5Overide = false;
                            _entities[index].NoTemplateOveride = false;
                            
                            break;
                        }
                    }
                }

                Helpers.saveItemsFilterDataFile(_configuration, _entities, "item-runes.json", "item-runes-enhanced.json");

                gridviewEntities.DataSource = null;
                gridviewEntities.Refresh();

                gridviewEntities.DataSource = _entities;
                gridviewEntities.Refresh();

                this.Text = "Items Filter [" + _entities.Count.ToString() + " RUNES/RUNEWORDS]";

                if (txtKeywordFilter.Text.Length > 0)
                {
                    filterEntitiesByKeyword(txtKeywordFilter.Text);
                }

                colorGridView();
            }
        }

        private void template1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridviewEntities.SelectedRows.Count > 0)
            {

                for (int rowindex = 0; rowindex < gridviewEntities.SelectedRows.Count; rowindex++)
                {
                    for (int index = 0; index < _entities.Count; index++)
                    {
                        if (_entities[index].id == ((ItemFilterEnhancedEntity)gridviewEntities.SelectedRows[rowindex].DataBoundItem).id)
                        {
                            _entities[index].useHideTemplateOveride = false;
                            _entities[index].useGrayTemplateOveride = false;
                            _entities[index].useWhiteTemplateOveride = false;
                            _entities[index].useHighlightTemplateOveride = false;
                            _entities[index].useCustomTemplate1Overide = true;
                            _entities[index].useCustomTemplate2Overide = false;
                            _entities[index].useCustomTemplate3Overide = false;
                            _entities[index].useCustomTemplate4Overide = false;
                            _entities[index].useCustomTemplate5Overide = false;
                            _entities[index].NoTemplateOveride = false;

                            break;
                        }
                    }
                }

                Helpers.saveItemsFilterDataFile(_configuration, _entities, "item-runes.json", "item-runes-enhanced.json");

                gridviewEntities.DataSource = null;
                gridviewEntities.Refresh();

                gridviewEntities.DataSource = _entities;
                gridviewEntities.Refresh();

                this.Text = "Items Filter [" + _entities.Count.ToString() + " RUNES/RUNEWORDS]";

                if (txtKeywordFilter.Text.Length > 0)
                {
                    filterEntitiesByKeyword(txtKeywordFilter.Text);
                }

                colorGridView();
            }
        }

        private void template2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridviewEntities.SelectedRows.Count > 0)
            {

                for (int rowindex = 0; rowindex < gridviewEntities.SelectedRows.Count; rowindex++)
                {
                    for (int index = 0; index < _entities.Count; index++)
                    {
                        if (_entities[index].id == ((ItemFilterEnhancedEntity)gridviewEntities.SelectedRows[rowindex].DataBoundItem).id)
                        {
                            _entities[index].useHideTemplateOveride = false;
                            _entities[index].useGrayTemplateOveride = false;
                            _entities[index].useWhiteTemplateOveride = false;
                            _entities[index].useHighlightTemplateOveride = false;
                            _entities[index].useCustomTemplate1Overide = false;
                            _entities[index].useCustomTemplate2Overide = true;
                            _entities[index].useCustomTemplate3Overide = false;
                            _entities[index].useCustomTemplate4Overide = false;
                            _entities[index].useCustomTemplate5Overide = false;
                            _entities[index].NoTemplateOveride = false;
                            break;
                        }
                    }
                }

                Helpers.saveItemsFilterDataFile(_configuration, _entities, "item-runes.json", "item-runes-enhanced.json");

                gridviewEntities.DataSource = null;
                gridviewEntities.Refresh();

                gridviewEntities.DataSource = _entities;
                gridviewEntities.Refresh();

                this.Text = "Items Filter [" + _entities.Count.ToString() + " RUNES/RUNEWORDS]";

                if (txtKeywordFilter.Text.Length > 0)
                {
                    filterEntitiesByKeyword(txtKeywordFilter.Text);
                }

                colorGridView();
            }
        }

        private void template3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridviewEntities.SelectedRows.Count > 0)
            {

                for (int rowindex = 0; rowindex < gridviewEntities.SelectedRows.Count; rowindex++)
                {
                    for (int index = 0; index < _entities.Count; index++)
                    {
                        if (_entities[index].id == ((ItemFilterEnhancedEntity)gridviewEntities.SelectedRows[rowindex].DataBoundItem).id)
                        {
                            _entities[index].useHideTemplateOveride = false;
                            _entities[index].useGrayTemplateOveride = false;
                            _entities[index].useWhiteTemplateOveride = false;
                            _entities[index].useHighlightTemplateOveride = false;
                            _entities[index].useCustomTemplate1Overide = false;
                            _entities[index].useCustomTemplate2Overide = false;
                            _entities[index].useCustomTemplate3Overide = true;
                            _entities[index].useCustomTemplate4Overide = false;
                            _entities[index].useCustomTemplate5Overide = false;
                            _entities[index].NoTemplateOveride = false;

                            break;
                        }
                    }
                }

                Helpers.saveItemsFilterDataFile(_configuration, _entities, "item-runes.json", "item-runes-enhanced.json");

                gridviewEntities.DataSource = null;
                gridviewEntities.Refresh();

                gridviewEntities.DataSource = _entities;
                gridviewEntities.Refresh();

                this.Text = "Items Filter [" + _entities.Count.ToString() + " RUNES/RUNEWORDS]";

                if (txtKeywordFilter.Text.Length > 0)
                {
                    filterEntitiesByKeyword(txtKeywordFilter.Text);
                }

                colorGridView();
            }
        }

        private void template4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridviewEntities.SelectedRows.Count > 0)
            {

                for (int rowindex = 0; rowindex < gridviewEntities.SelectedRows.Count; rowindex++)
                {
                    for (int index = 0; index < _entities.Count; index++)
                    {
                        if (_entities[index].id == ((ItemFilterEnhancedEntity)gridviewEntities.SelectedRows[rowindex].DataBoundItem).id)
                        {
                            _entities[index].useHideTemplateOveride = false;
                            _entities[index].useGrayTemplateOveride = false;
                            _entities[index].useWhiteTemplateOveride = false;
                            _entities[index].useHighlightTemplateOveride = false;
                            _entities[index].useCustomTemplate1Overide = false;
                            _entities[index].useCustomTemplate2Overide = false;
                            _entities[index].useCustomTemplate3Overide = false;
                            _entities[index].useCustomTemplate4Overide = true;
                            _entities[index].useCustomTemplate5Overide = false;
                            _entities[index].NoTemplateOveride = false;
                            break;
                        }
                    }
                }

                Helpers.saveItemsFilterDataFile(_configuration, _entities, "item-runes.json", "item-runes-enhanced.json");

                gridviewEntities.DataSource = null;
                gridviewEntities.Refresh();

                gridviewEntities.DataSource = _entities;
                gridviewEntities.Refresh();

                this.Text = "Items Filter [" + _entities.Count.ToString() + " RUNES/RUNEWORDS]";

                if (txtKeywordFilter.Text.Length > 0)
                {
                    filterEntitiesByKeyword(txtKeywordFilter.Text);
                }

                colorGridView();
            }
        }

        private void template5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridviewEntities.SelectedRows.Count > 0)
            {

                for (int rowindex = 0; rowindex < gridviewEntities.SelectedRows.Count; rowindex++)
                {
                    for (int index = 0; index < _entities.Count; index++)
                    {
                        if (_entities[index].id == ((ItemFilterEnhancedEntity)gridviewEntities.SelectedRows[rowindex].DataBoundItem).id)
                        {
                            _entities[index].useHideTemplateOveride = false;
                            _entities[index].useGrayTemplateOveride = false;
                            _entities[index].useWhiteTemplateOveride = false;
                            _entities[index].useHighlightTemplateOveride = false;
                            _entities[index].useCustomTemplate1Overide = false;
                            _entities[index].useCustomTemplate2Overide = false;
                            _entities[index].useCustomTemplate3Overide = false;
                            _entities[index].useCustomTemplate4Overide = false;
                            _entities[index].useCustomTemplate5Overide = true;
                            _entities[index].NoTemplateOveride = false;
                            break;
                        }
                    }
                }

                Helpers.saveItemsFilterDataFile(_configuration, _entities, "item-runes.json", "item-runes-enhanced.json");

                gridviewEntities.DataSource = null;
                gridviewEntities.Refresh();

                gridviewEntities.DataSource = _entities;
                gridviewEntities.Refresh();

                this.Text = "Items Filter [" + _entities.Count.ToString() + " RUNES/RUNEWORDS]";

                if (txtKeywordFilter.Text.Length > 0)
                {
                    filterEntitiesByKeyword(txtKeywordFilter.Text);
                }

                colorGridView();
            }
        }

        private void noTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridviewEntities.SelectedRows.Count > 0)
            {

                for (int rowindex = 0; rowindex < gridviewEntities.SelectedRows.Count; rowindex++)
                {
                    for (int index = 0; index < _entities.Count; index++)
                    {
                        if (_entities[index].id == ((ItemFilterEnhancedEntity)gridviewEntities.SelectedRows[rowindex].DataBoundItem).id)
                        {

                            _entities[index].useHideTemplateOveride = false;
                            _entities[index].useGrayTemplateOveride = false;
                            _entities[index].useWhiteTemplateOveride = false;
                            _entities[index].useHighlightTemplateOveride = false;
                            _entities[index].useCustomTemplate1Overide = false;
                            _entities[index].useCustomTemplate2Overide = false;
                            _entities[index].useCustomTemplate3Overide = false;
                            _entities[index].useCustomTemplate4Overide = false;
                            _entities[index].useCustomTemplate5Overide = false;
                            _entities[index].NoTemplateOveride = true;
                            break;
                        }
                    }
                }

                Helpers.saveItemsFilterDataFile(_configuration, _entities, "item-runes.json", "item-runes-enhanced.json");

                gridviewEntities.DataSource = null;
                gridviewEntities.Refresh();

                gridviewEntities.DataSource = _entities;
                gridviewEntities.Refresh();

                this.Text = "Items Filter [" + _entities.Count.ToString() + " RUNES/RUNEWORDS]";

                if (txtKeywordFilter.Text.Length > 0)
                {
                    filterEntitiesByKeyword(txtKeywordFilter.Text);
                }

                colorGridView();
            }
        }

        private void cmsGridView_Opening(object sender, CancelEventArgs e)
        {
            bool enabled = (gridviewEntities.SelectedRows.Count > 0);
            setToToolStripMenuItem.Enabled = enabled;
            hideToolStripMenuItem.Enabled = enabled;
            grayToolStripMenuItem.Enabled = enabled;
            whiteToolStripMenuItem.Enabled = enabled;
            highlightToolStripMenuItem.Enabled = enabled;
            toolStripSeparator1.Enabled = enabled;
            template1ToolStripMenuItem.Enabled = enabled;
            template2ToolStripMenuItem.Enabled = enabled;
            template3ToolStripMenuItem.Enabled = enabled;
            template4ToolStripMenuItem.Enabled = enabled;
            template5ToolStripMenuItem.Enabled = enabled;
            toolStripSeparator2.Enabled = enabled;
            noTemplateToolStripMenuItem.Enabled = enabled;
            toolStripSeparator3.Enabled = enabled;
            resetToDefaultValueToolStripMenuItem.Enabled = enabled;
        }
    }
}
