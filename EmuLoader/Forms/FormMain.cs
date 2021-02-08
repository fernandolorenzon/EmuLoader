using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace EmuLoader.Forms
{
    public partial class FormMain : FormBase
    {
        #region Attributes

        private bool updating = false;
        private List<Rom> FilteredRoms { get; set; }
        FormWindowState LastWindowState = FormWindowState.Minimized;

        #endregion

        #region Constructors

        public FormMain()
        {
            FilteredRoms = new List<Rom>();
            InitializeComponent();
        }

        #endregion

        #region Events

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                //DateTime begin = DateTime.Now;
                updating = true;
                //FormMessage.ShowMessage("Loading XML...");
                Functions.InitXml();
                FillPlatformGrid();
                //FormMessage.ShowMessage("Loading Roms...");
                Rom.Fill();
                columnPlatform.Visible = showPlatformColumnToolStripMenuItem.Checked = Config.GetElementVisibility(Column.ColumnPlatform);
                columnGenre.Visible = showGenreColumnToolStripMenuItem.Checked = Config.GetElementVisibility(Column.ColumnGenre);
                columnStatus.Visible = showStatusColumnToolStripMenuItem.Checked = Config.GetElementVisibility(Column.ColumnStatus);
                columnLabels.Visible = showLabelsColumnToolStripMenuItem.Checked = Config.GetElementVisibility(Column.ColumnLabels);
                columnRomPath.Visible = showPathColumnToolStripMenuItem.Checked = Config.GetElementVisibility(Column.ColumnPath);
                columnRomDBName.Visible = showRomDBNameColumnToolStripMenuItem.Checked = Config.GetElementVisibility(Column.ColumnRomDBName);
                columnFilename.Visible = showFilenameToolStripMenuItem.Checked = Config.GetElementVisibility(Column.ColumnFileName);
                columnDeveloper.Visible = showDeveloperColumnToolStripMenuItem.Checked = Config.GetElementVisibility(Column.ColumnDeveloper);
                columnPublisher.Visible = showPublisherColumnToolStripMenuItem.Checked = Config.GetElementVisibility(Column.ColumnPublisher);
                columnYearReleased.Visible = showYearReleasedColumnToolStripMenuItem.Checked = Config.GetElementVisibility(Column.ColumnYearReleased);
                columnRating.Visible = showRatingColumnToolStripMenuItem.Checked = Config.GetElementVisibility(Column.ColumnRating);
                pictureBoxBoxart.Visible = showBoxArtToolStripMenuItem.Checked = Config.GetElementVisibility(Column.BoxArt);
                pictureBoxTitle.Visible = showTitleToolStripMenuItem.Checked = Config.GetElementVisibility(Column.TitleArt);
                pictureBoxGameplay.Visible = showGameplayArtToolStripMenuItem.Checked = Config.GetElementVisibility(Column.GameplayArt);
                dataGridViewPlatforms.Visible = showPlatformsListToolStripMenuItem.Checked = Config.GetElementVisibility(Column.PlatformsList);
                flowLayoutPanelPictures.Visible = pictureBoxBoxart.Visible || pictureBoxTitle.Visible || pictureBoxGameplay.Visible;
                //FormMessage.ShowMessage("Filling Grid...");

                FillPlatformFilter();
                FillLabelFilter();
                FillGenreFilter();
                FillPublisherFilter();
                FillDeveloperFilter();
                FillYearReleasedFilter();
                FillStatusFilter();

                Filter filter = FilterFunctions.GetFilter();

                textBoxFilter.Text = filter.text;
                comboBoxFilter.Text = filter.textType;

                if (!string.IsNullOrEmpty(filter.platform))
                {
                    comboBoxPlatform.SelectedValue = filter.platform;
                }

                if (!string.IsNullOrEmpty(filter.label))
                {
                    comboBoxLabels.SelectedValue = filter.label;
                }

                if (!string.IsNullOrEmpty(filter.genre))
                {
                    comboBoxGenre.SelectedValue = filter.genre;
                }

                if (!string.IsNullOrEmpty(filter.developer))
                {
                    comboBoxDeveloper.SelectedText = filter.developer;
                }

                if (!string.IsNullOrEmpty(filter.publisher))
                {
                    comboBoxPublisher.SelectedText = filter.publisher;
                }

                if (!string.IsNullOrEmpty(filter.year))
                {
                    comboBoxYearReleased.SelectedText = filter.year;
                }

                checkBoxFavorite.Checked = filter.favorite;

                FilterRoms();

                updating = false;
                dataGridView.ClearSelection();

                var height = XML.GetConfig("Height");
                var width = XML.GetConfig("Width");

                if (!string.IsNullOrEmpty(height) && !string.IsNullOrEmpty(width))
                {
                    this.Height = Convert.ToInt32(height);
                    this.Width = Convert.ToInt32(width);
                }

                if (string.IsNullOrEmpty(filter.rom))
                {
                    SelectRandomRom();
                }
                else
                {
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        if (dataGridView.Rows[i].Cells[columnRomPath.Index].Value.ToString() == filter.rom)
                        {
                            dataGridView.CurrentCell = dataGridView.Rows[i].Cells[0];
                            break;
                        }
                    }
                }

                this.textBoxFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);

                try
                {
                    Functions.BackupDB();
                }
                catch (Exception backupEx)
                {
                    FormCustomMessage.ShowError(backupEx.Message);
                }

                //FormMessage.CloseMessage();
                //DateTime end = DateTime.Now;
                //FormCustomMessage.Show((end - begin).ToString());
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void FormMain_Close(object sender, FormClosedEventArgs e)
        {
            Filter filter = new Filter();
            filter.platform = comboBoxPlatform.SelectedValue == null ? "" : comboBoxPlatform.SelectedValue.ToString();
            filter.label = comboBoxLabels.SelectedValue == null ? "" : comboBoxLabels.SelectedValue.ToString();
            filter.genre = comboBoxGenre.SelectedValue == null ? "" : comboBoxGenre.SelectedValue.ToString();
            filter.publisher = comboBoxPublisher.SelectedValue == null ? "" : comboBoxPublisher.SelectedValue.ToString();
            filter.developer = comboBoxDeveloper.SelectedValue == null ? "" : comboBoxDeveloper.SelectedValue.ToString();
            filter.year = comboBoxYearReleased.SelectedValue == null ? "" : comboBoxYearReleased.SelectedValue.ToString();
            filter.rom = dataGridView.SelectedRows.Count == 0 ? "" : ((Rom)dataGridView.SelectedRows[0].Tag).Path;
            filter.text = textBoxFilter.Text;
            filter.textType = comboBoxFilter.Text;
            filter.favorite = checkBoxFavorite.Checked;

            FilterFunctions.SaveFilter(filter);
            XML.SaveXmlConfig();
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                FormCustomMessage.ShowError("What the Ctrl+F?");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void manageLabelToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                FormLabel form = new FormLabel();

                if (form.ShowDialogUpdated())
                {
                    FillLabelFilter();
                    buttonClear_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void manageGenreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string genre = comboBoxGenre.SelectedValue == null ? string.Empty : comboBoxGenre.SelectedValue.ToString();

                FormGenre form = new FormGenre();

                if (form.ShowDialogUpdated())
                {
                    //Genre.Fill();
                    //Rom.Fill();
                    FilterRoms();
                    FillGenreFilter(genre);
                }
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void managePlatformToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                string platform = comboBoxPlatform.SelectedValue == null ? string.Empty : comboBoxPlatform.SelectedValue.ToString();

                FormPlatform form = new FormPlatform();

                if (form.ShowDialogUpdated())
                {
                    //Platform.Fill();
                    //Rom.Fill();
                    FilterRoms();
                    FillPlatformFilter(platform);
                    FillPlatformGrid();
                }
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void addRomDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog open = new FolderBrowserDialog();
                open.SelectedPath = Environment.CurrentDirectory;

                if (open.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                if (open.SelectedPath.Length == 0)
                {
                    return;
                }

                Platform platform = null;
                FormChoose.ChoosePlatform(out platform);
                RomFunctions.AddRomsFromDirectory(platform, open.SelectedPath);
                XML.SaveXmlRoms();
                FilterRoms();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void toolStripButtonAddRom_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.InitialDirectory = Environment.CurrentDirectory;

                open.Filter = "Roms | *.zip;*.smc;*.fig;*.gba;*.gbc;*.gb;*.pce;*.n64;*.smd;*.sms;*.ccd;*.cue;*.bin;*.iso;*.gdi;*.cdi|" +
                              "Zip | *.zip|" +
                              "CD | *.cue|" +
                              "CD | *.ccd|" +
                              "CD ISO | *.iso|" +
                              "CD Image | *.bin|" +
                              "Dreamcast Image | *.cdi;*.gdi|" +
                              "Snes | *.smc|" +
                              "Snes | *.fig|" +
                              "GBA | *.gba|" +
                              "GBC | *.gbc|" +
                              "GB | *.gb|" +
                              "PC Engine | *.pce|" +
                              "N64 | *.n64|" +
                              "Mega Drive | *.smd|" +
                              "Master System | *.sms|" +
                              "All | *.*";
                open.Multiselect = true;

                if (open.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                if (open.FileNames.Length == 0)
                {
                    return;
                }

                Platform platform = null;
                FormChoose.ChoosePlatform(out platform);
                RomFunctions.AddRomsFiles(platform, open.FileNames);
                XML.SaveXmlRoms();

                FilterRoms();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void pictureBoxBoxart_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            try
            {
                if (dataGridView.SelectedRows.Count == 0) return;

                Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;
                ProcessStartInfo sInfo = new ProcessStartInfo(RomFunctions.GetRomPicture(rom, Values.BoxartFolder));
                Process.Start(sInfo);
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void pictureBoxTitle_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            try
            {
                if (dataGridView.SelectedRows.Count == 0) return;

                Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;
                ProcessStartInfo sInfo = new ProcessStartInfo(RomFunctions.GetRomPicture(rom, Values.TitleFolder));
                Process.Start(sInfo);
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void pictureBoxGameplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            try
            {
                if (dataGridView.SelectedRows.Count == 0) return;

                Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;
                ProcessStartInfo sInfo = new ProcessStartInfo(RomFunctions.GetRomPicture(rom, Values.GameplayFolder));
                Process.Start(sInfo);
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void changePlatformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Platform selected = null;

                if (!FormChoose.ChoosePlatform(out selected)) return;

                List<Rom> romList = new List<Rom>();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    romList.Add((Rom)row.Tag);
                }

                RomFunctions.ChangeRomsPlatform(romList, selected);
                XML.SaveXmlRoms();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    Rom rom = (Rom)row.Tag;

                    if (rom.Platform != null)
                    {
                        row.Cells[columnPlatform.Index].Value = rom.Platform.Name;
                        row.Cells[columnPlatform.Index].Style.BackColor = rom.Platform.Color;
                        row.Cells[columnPlatform.Index].Style.ForeColor = Functions.SetFontContrast(rom.Platform.Color);
                    }
                    else
                    {
                        row.Cells[columnPlatform.Index].Value = "";
                        row.Cells[columnPlatform.Index].Style.BackColor = Color.White;
                        row.Cells[columnPlatform.Index].Style.ForeColor = Color.Black;
                    }
                }

                dataGridView.Refresh();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void changeGenreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Genre selected = null;

                if (!FormChoose.ChooseGenre(out selected)) return;

                List<Rom> romList = new List<Rom>();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    romList.Add((Rom)row.Tag);
                }

                Genre.ChangeRomsGenre(romList, selected);
                XML.SaveXmlRoms();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    Rom rom = (Rom)row.Tag;

                    if (rom.Genre != null)
                    {
                        row.Cells[columnGenre.Index].Value = rom.Genre.Name;
                        row.Cells[columnGenre.Index].Style.BackColor = rom.Genre.Color;
                        row.Cells[columnGenre.Index].Style.ForeColor = Functions.SetFontContrast(rom.Genre.Color);
                    }
                    else
                    {
                        row.Cells[columnGenre.Index].Value = "";
                        row.Cells[columnGenre.Index].Style.BackColor = Color.White;
                        row.Cells[columnGenre.Index].Style.ForeColor = Color.Black;
                    }
                }

                dataGridView.Refresh();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void changeStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string selected = "";

                if (dataGridView.SelectedRows.Count == 1)
                {
                    selected = ((Rom)dataGridView.SelectedRows[0].Tag).Status;
                }

                if (!FormChoose.ChooseStatus(selected, out selected)) return;

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    var rom = (Rom)row.Tag;
                    rom.Status = selected;
                    Rom.Set(rom);
                }

                XML.SaveXmlRoms();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    Rom rom = (Rom)row.Tag;

                    if (!string.IsNullOrEmpty(rom.Status))
                    {
                        row.Cells[columnStatus.Index].Value = rom.Status;
                        row.Cells[columnStatus.Index].Style.BackColor = Color.Navy;
                        row.Cells[columnStatus.Index].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        row.Cells[columnStatus.Index].Value = "";
                        row.Cells[columnStatus.Index].Style.ForeColor = dataGridView.RowTemplate.DefaultCellStyle.ForeColor;
                        row.Cells[columnStatus.Index].Style.BackColor = dataGridView.RowTemplate.DefaultCellStyle.BackColor;
                    }
                }

                dataGridView.Refresh();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void changeLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<RomLabel> selectedLabels = new List<RomLabel>();
                List<RomLabel> unselectedLabels = new List<RomLabel>();

                List<Rom> roms = new List<Rom>();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    if (!row.Visible) continue;
                    roms.Add((Rom)row.Tag);
                }

                if (!FormChooseList.ChooseLabel(roms, out selectedLabels, out unselectedLabels)) return;

                RomFunctions.ChangeRomLabels(roms, selectedLabels, unselectedLabels);
                XML.SaveXmlRoms();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    FillLabelCell((Rom)row.Tag, row);
                }

                dataGridView.Refresh();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void removeRomEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 0) return;

                List<Rom> roms = new List<Rom>();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    if (!row.Visible) continue;

                    roms.Add((Rom)row.Tag);
                }

                var message = string.Empty;

                if (roms.Count == 1)
                {
                    message = string.Format("Do you want to remove \"{0}\" ? (Keep the rom file)", roms[0].Name);
                }
                else
                {
                    message = string.Format("Do you want to remove {0} roms ? (Keep the rom files)", roms.Count);
                }

                var result = MessageBox.Show(message, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result.ToString() == "No") return;

                foreach (var rom in roms)
                {
                    Rom.Delete(rom);
                    RomFunctions.RemoveRomPics(rom);
                    FilteredRoms.Remove(rom);
                }

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    dataGridView.Rows.Remove(row);
                }

                labelTotalRomsCount.Text = FilteredRoms.Count.ToString();
                XML.SaveXmlRoms();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void deleteRomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 0) return;

                DataGridViewRow row = dataGridView.SelectedRows[0];
                Rom rom = (Rom)row.Tag;

                var message = string.Format("Do you want to remove \"{0}\" ? (Remove to recycle bin)", rom.Name);

                var result = MessageBox.Show(message, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result.ToString() == "No") return;

                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(rom.Path,
                    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);

                dataGridView.Rows.Remove(row);
                Rom.Delete(rom);
                RomFunctions.RemoveRomPics(rom);
                FilteredRoms.Remove(rom);
                labelTotalRomsCount.Text = FilteredRoms.Count.ToString();
                XML.SaveXmlRoms();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void toolStripMenuItemShowPathColumn_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                columnRomPath.Visible = showPathColumnToolStripMenuItem.Checked;

                if (updating) return;

                Config.SetElementVisibility(Column.ColumnPath, columnRomPath.Visible);
                XML.SaveXmlConfig();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void showRomDBNameColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                columnRomDBName.Visible = showRomDBNameColumnToolStripMenuItem.Checked;

                if (updating) return;

                Config.SetElementVisibility(Column.ColumnRomDBName, columnRomDBName.Visible);
                XML.SaveXmlConfig();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void showFilenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                columnFilename.Visible = showFilenameToolStripMenuItem.Checked;

                if (updating) return;

                Config.SetElementVisibility(Column.ColumnFileName, columnFilename.Visible);
                XML.SaveXmlConfig();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void ToolStripMenuItemShowPlatformColumn_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                columnPlatform.Visible = showPlatformColumnToolStripMenuItem.Checked;

                if (updating) return;

                Config.SetElementVisibility(Column.ColumnPlatform, columnPlatform.Visible);
                XML.SaveXmlConfig();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void showLabelsColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                columnLabels.Visible = showLabelsColumnToolStripMenuItem.Checked;

                if (updating) return;

                Config.SetElementVisibility(Column.ColumnLabels, columnLabels.Visible);
                XML.SaveXmlConfig();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void showGenreColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                columnGenre.Visible = showGenreColumnToolStripMenuItem.Checked;

                if (updating) return;

                Config.SetElementVisibility(Column.ColumnGenre, columnGenre.Visible);
                XML.SaveXmlConfig();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void showStatusColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                columnStatus.Visible = showStatusColumnToolStripMenuItem.Checked;

                if (updating) return;

                Config.SetElementVisibility(Column.ColumnStatus, columnStatus.Visible);
                XML.SaveXmlConfig();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void showDeveloperColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                columnDeveloper.Visible = showDeveloperColumnToolStripMenuItem.Checked;

                if (updating) return;

                Config.SetElementVisibility(Column.ColumnDeveloper, columnDeveloper.Visible);
                XML.SaveXmlConfig();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void showPublisherColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                columnPublisher.Visible = showPublisherColumnToolStripMenuItem.Checked;

                if (updating) return;

                Config.SetElementVisibility(Column.ColumnPublisher, columnPublisher.Visible);
                XML.SaveXmlConfig();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void showYearReleasedColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                columnYearReleased.Visible = showYearReleasedColumnToolStripMenuItem.Checked;

                if (updating) return;

                Config.SetElementVisibility(Column.ColumnYearReleased, columnYearReleased.Visible);
                XML.SaveXmlConfig();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void showRatingColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                columnRating.Visible = showRatingColumnToolStripMenuItem.Checked;

                if (updating) return;

                Config.SetElementVisibility(Column.ColumnRating, columnRating.Visible);
                XML.SaveXmlConfig();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void showPlatformsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewPlatforms.Visible = showPlatformsListToolStripMenuItem.Checked;

                if (updating) return;

                Config.SetElementVisibility(Column.PlatformsList, dataGridViewPlatforms.Visible);
                XML.SaveXmlConfig();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void showFileExistsAuditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!showFileExistsAuditToolStripMenuItem.Checked)
                {
                    ColumnFileExists.Visible = false;
                    return;
                }

                dataGridView.SuspendLayout();

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    Rom rom = (Rom)row.Tag;

                    if (File.Exists(rom.Path))
                    {
                        row.Cells[ColumnFileExists.Name].Style.BackColor = Color.Green;
                        row.Cells[ColumnFileExists.Name].Value = "OK";
                    }
                    else
                    {
                        row.Cells[ColumnFileExists.Name].Style.BackColor = Color.Red;
                        row.Cells[ColumnFileExists.Name].Value = "NOT OK";
                    }
                }

                dataGridView.ResumeLayout();

                ColumnFileExists.Visible = showFileExistsAuditToolStripMenuItem.Checked;

                if (updating) return;
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void showIncorrectPlatformAuditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!showIncorrectPlatformAuditToolStripMenuItem.Checked)
                {
                    ColumnIncorrectPlatform.Visible = false;
                    return;
                }

                if (comboBoxPlatform.Text == "" || comboBoxPlatform.Text == "none")
                {
                    FormCustomMessage.ShowError("Select a platform");
                }

                var json = RomFunctions.GetPlatformJson(comboBoxPlatform.Text);

                if (json == "")
                {
                    FormCustomMessage.ShowError("Json not found. Sync platform first");
                    showIncorrectPlatformAuditToolStripMenuItem.Checked = false;
                    ColumnIncorrectPlatform.Visible = false;
                    return;
                }


                dataGridView.SuspendLayout();

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    Rom rom = (Rom)row.Tag;

                    if (string.IsNullOrEmpty(rom.Id))
                    {
                        row.Cells[ColumnIncorrectPlatform.Name].Style.BackColor = Color.Yellow;
                        continue;
                    }

                    if (json.Contains("\"id\": " + rom.Id + ","))
                    {
                        row.Cells[ColumnIncorrectPlatform.Name].Style.BackColor = Color.Green;
                        row.Cells[ColumnIncorrectPlatform.Name].Value = "OK";
                    }
                    else
                    {
                        row.Cells[ColumnIncorrectPlatform.Name].Style.BackColor = Color.Red;
                        row.Cells[ColumnIncorrectPlatform.Name].Value = "NOT OK";
                    }
                }

                dataGridView.ResumeLayout();

                ColumnIncorrectPlatform.Visible = showIncorrectPlatformAuditToolStripMenuItem.Checked;

                if (updating) return;
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void showMissingPicsAuditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!showMissingPicsAuditToolStripMenuItem.Checked)
                {
                    ColumnMissingPics.Visible = false;
                    return;
                }

                if (comboBoxPlatform.Text == "" || comboBoxPlatform.Text == "none")
                {
                    FormCustomMessage.ShowError("Select a platform first");
                    return;
                }

                var boxpics = RomFunctions.GetPics(comboBoxPlatform.Text, PicType.BoxArt, false, true);
                var titlepics = RomFunctions.GetPics(comboBoxPlatform.Text, PicType.Title, false, true);
                var gameplaypics = RomFunctions.GetPics(comboBoxPlatform.Text, PicType.Gameplay, false, true);

                dataGridView.SuspendLayout();

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    Rom rom = (Rom)row.Tag;

                    bool boxExists = boxpics.Any(x => x.ToLower() == rom.FileNameNoExt.ToLower());
                    bool titleExists = titlepics.Any(x => x.ToLower() == rom.FileNameNoExt.ToLower());
                    bool gameplayExists = gameplaypics.Any(x => x.ToLower() == rom.FileNameNoExt.ToLower());

                    int missing = 0;

                    if (!boxExists)
                    {
                        missing++;
                    }

                    if (!titleExists)
                    {
                        missing++;
                    }

                    if (!gameplayExists)
                    {
                        missing++;
                    }

                    if (missing == 0)
                    {
                        row.Cells[ColumnMissingPics.Name].Style.BackColor = Color.Green;
                        row.Cells[ColumnMissingPics.Name].Value = "ALL";
                    }
                    else if (missing == 1)
                    {
                        row.Cells[ColumnMissingPics.Name].Style.BackColor = Color.Yellow;
                        row.Cells[ColumnMissingPics.Name].Value = "Missing 1";
                    }
                    else if (missing == 2)
                    {
                        row.Cells[ColumnMissingPics.Name].Style.BackColor = Color.Orange;
                        row.Cells[ColumnMissingPics.Name].Value = "Missing 2";
                    }
                    else if (missing == 3)
                    {
                        row.Cells[ColumnMissingPics.Name].Style.BackColor = Color.Red;
                        row.Cells[ColumnMissingPics.Name].Value = "Missing 3";
                    }
                }

                dataGridView.ResumeLayout();

                ColumnMissingPics.Visible = showMissingPicsAuditToolStripMenuItem.Checked;

                if (updating) return;
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            try
            {
                updating = true;
                textBoxFilter.Text = "";
                comboBoxPlatform.SelectedIndex = 0;
                comboBoxGenre.SelectedIndex = 0;
                comboBoxLabels.SelectedIndex = 0;
                comboBoxDeveloper.SelectedIndex = 0;
                comboBoxPublisher.SelectedIndex = 0;
                comboBoxYearReleased.SelectedIndex = 0;
                updating = false;
                FilterRoms();
                SelectRandomRom();
                LoadPictures();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void toolStripMenuItemSettings_Click(object sender, EventArgs e)
        {
            try
            {
                FormSettings form = new FormSettings();
                form.ShowDialog();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView.SelectedRows[0];
                Rom rom = (Rom)row.Tag;

                FileInfo file = new FileInfo(rom.Path);
                System.Diagnostics.Process.Start("explorer.exe", file.DirectoryName);
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void toolStripButtonRemoveInvalid_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxPlatform.SelectedValue != null)
                {
                    RomFunctions.RemoveInvalidRomsEntries(Platform.Get(comboBoxPlatform.SelectedValue.ToString()));
                }
                else
                {
                    RomFunctions.RemoveInvalidRomsEntries();
                }

                XML.SaveXmlRoms();
                FilterRoms();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void textBoxFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r')
                {
                    FilterRoms();
                }
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void comboBoxPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (updating) return;

                showFileExistsAuditToolStripMenuItem.Checked = false;
                showIncorrectPlatformAuditToolStripMenuItem.Checked = false;
                showMissingPicsAuditToolStripMenuItem.Checked = false;
                ColumnFileExists.Visible = false;
                ColumnIncorrectPlatform.Visible = false;
                ColumnMissingPics.Visible = false;

                FilterRoms();

                buttonRescan.Enabled = comboBoxPlatform.Text != string.Empty;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void comboBoxPublisher_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (updating) return;
                FilterRoms();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void comboBoxDeveloper_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (updating) return;
                FilterRoms();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void comboBoxYearReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (updating) return;
                FilterRoms();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void comboBoxLabels_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (updating) return;
                FilterRoms();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (updating) return;
                FilterRoms();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void comboBoxGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (updating) return;
                FilterRoms();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void timerFilter_Tick(object sender, EventArgs e)
        {
            timerFilter.Stop();
            if (updating) return;
            FilterRoms();
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;

            if (textBoxFilter.Text.StartsWith("p:"))
            {
                timerFilter.Stop();
            }
            else
            {
                timerFilter.Start();
            }
        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            FilterRoms();
        }

        private void batchAddPicturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormBatchAddPictures form = new FormBatchAddPictures();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void batchRemovePicturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView.ClearSelection();
                pictureBoxBoxart.Image = null;
                pictureBoxTitle.Image = null;
                pictureBoxGameplay.Image = null;
                FormBatchRemovePictures form = new FormBatchRemovePictures();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void manageRomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 0) return;

                var currentGenre = comboBoxGenre.Text;

                var row = dataGridView.SelectedRows[0];
                Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;
                FormManageRom form = new FormManageRom(rom);

                if (form.ShowDialogUpdated())
                {
                    LoadGridRow(rom, row);
                    FillLabelCell(rom, dataGridView.SelectedRows[0]);
                    LoadPictures();

                    if (rom.Genre != null && currentGenre != rom.Genre.Name)
                    {
                        FillGenreFilter();
                        comboBoxGenre.Text = currentGenre;
                    }
                }
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void syncUsingRetropieXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormSyncUsingXML form = new FormSyncUsingXML();

                if (form.ShowDialogUpdated())
                {
                    FilterRoms();
                }
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void showBoxArtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!pictureBoxBoxart.Visible && showBoxArtToolStripMenuItem.Checked)
                {
                    flowLayoutPanelPictures.Visible = true;
                }

                pictureBoxBoxart.Visible = showBoxArtToolStripMenuItem.Checked;
                Config.SetElementVisibility(Column.BoxArt, pictureBoxBoxart.Visible);
                XML.SaveXmlConfig();

                flowLayoutPanelPictures.Visible = pictureBoxBoxart.Visible || pictureBoxTitle.Visible || pictureBoxGameplay.Visible;
                FormMain_ResizeEnd(sender, e);
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void showTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!pictureBoxTitle.Visible && showTitleToolStripMenuItem.Checked)
                {
                    flowLayoutPanelPictures.Visible = true;
                }

                pictureBoxTitle.Visible = showTitleToolStripMenuItem.Checked;
                Config.SetElementVisibility(Column.TitleArt, pictureBoxTitle.Visible);
                XML.SaveXmlConfig();

                flowLayoutPanelPictures.Visible = pictureBoxBoxart.Visible || pictureBoxTitle.Visible || pictureBoxGameplay.Visible;
                FormMain_ResizeEnd(sender, e);
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void showGameplayArtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!pictureBoxGameplay.Visible && showGameplayArtToolStripMenuItem.Checked)
                {
                    flowLayoutPanelPictures.Visible = true;
                }

                pictureBoxGameplay.Visible = showGameplayArtToolStripMenuItem.Checked;
                Config.SetElementVisibility(Column.GameplayArt, pictureBoxGameplay.Visible);
                XML.SaveXmlConfig();

                flowLayoutPanelPictures.Visible = pictureBoxBoxart.Visible || pictureBoxTitle.Visible || pictureBoxGameplay.Visible;
                FormMain_ResizeEnd(sender, e);
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void pictureBoxBoxart_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 0) return;

                Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;
                CopyFromUrl(rom, Values.BoxartFolder);
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void pictureBoxTitle_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 0) return;

                Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;
                CopyFromUrl(rom, Values.TitleFolder);
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void pictureBoxGameplay_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 0) return;

                Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;
                CopyFromUrl(rom, Values.GameplayFolder);
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void openAppFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", Environment.CurrentDirectory);
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 0) return;

                Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;

                try
                {
                    ProcessStartInfo sInfo = new ProcessStartInfo(rom.Path);
                    Process.Start(sInfo);
                }
                catch (Exception ex)
                {
                    FormCustomMessage.ShowError(ex.Message);
                }
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void FormMain_ResizeEnd(object sender, EventArgs e)
        {

            try
            {
                XML.SetConfig("Height", this.Height.ToString());
                XML.SetConfig("Width", this.Width.ToString());
                XML.SaveXmlConfig();

                int imagesHeightTotal = pictureBoxBoxart.Size.Height * 3;
                int heightLeft = flowLayoutPanelPictures.Size.Height - imagesHeightTotal;

                if (heightLeft < 25 && heightLeft > 0) return;

                if (heightLeft > 0)
                {
                    int heightForEachPicture = Convert.ToInt32(heightLeft / 3) + pictureBoxBoxart.Size.Height - 6;

                    flowLayoutPanelPictures.Size = new Size(heightForEachPicture + 6, dataGridView.Size.Height);
                    pictureBoxBoxart.Size = new Size(heightForEachPicture, heightForEachPicture);
                    pictureBoxTitle.Size = new Size(heightForEachPicture, heightForEachPicture);
                    pictureBoxGameplay.Size = new Size(heightForEachPicture, heightForEachPicture);
                }
                else
                {
                    int heightForEachPicture = pictureBoxBoxart.Size.Height - 6 - Convert.ToInt32(heightLeft * -1 / 3);

                    flowLayoutPanelPictures.Size = new Size(heightForEachPicture + 6, dataGridView.Size.Height);
                    pictureBoxBoxart.Size = new Size(heightForEachPicture, heightForEachPicture);
                    pictureBoxTitle.Size = new Size(heightForEachPicture, heightForEachPicture);
                    pictureBoxGameplay.Size = new Size(heightForEachPicture, heightForEachPicture);
                }
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            try
            {
                // When window state changes
                if (WindowState != LastWindowState)
                {
                    LastWindowState = WindowState;

                    if (WindowState == FormWindowState.Maximized)
                    {
                        FormMain_ResizeEnd(sender, e);
                    }

                    if (WindowState == FormWindowState.Normal)
                    {
                        FormMain_ResizeEnd(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void addRomPackInDirectoryStructureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog open = new FolderBrowserDialog();
                open.SelectedPath = Environment.CurrentDirectory;

                if (open.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                if (open.SelectedPath.Length == 0)
                {
                    return;
                }

                Platform selected = null;

                if (FormChoose.ChoosePlatform(out selected))
                {
                    RomFunctions.AddRomPacksFromDirectory(selected, open.SelectedPath);
                    XML.SaveXmlRoms();
                    FilterRoms();
                }
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void syncRomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormSyncRomData form = new FormSyncRomData();
                var currentGenre = comboBoxGenre.Text;

                if (form.ShowDialogUpdated())
                {
                    Rom.Fill();
                    FillGenreFilter();

                    FilterRoms();
                    FillPlatformGrid();
                    FillPublisherFilter();
                    FillDeveloperFilter();
                    FillYearReleasedFilter();
                    comboBoxGenre.Text = currentGenre;
                }
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void purgeRomDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormPurgeRomData form = new FormPurgeRomData();
                form.ShowDialog();

                if (form.Updated)
                {
                    Rom.Fill();
                    FillGenreFilter();
                    FilterRoms();
                    FillPlatformFilter();
                    FillPlatformGrid();
                    FillPublisherFilter();
                    FillDeveloperFilter();
                    FillYearReleasedFilter();
                }
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void buttonRescan_Click(object sender, EventArgs e)
        {
            if (comboBoxPlatform.SelectedItem == null || comboBoxPlatform.SelectedIndex == 1)
            {
                FormCustomMessage.ShowError("No platform selected.");
                return;
            }

            var platform = (Platform)comboBoxPlatform.SelectedItem;

            var result = platform.RescanRoms();

            if (result)
            {
                XML.SaveXmlRoms();
                FilterRoms();
            }
        }

        private void favoriteUnfavoriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 0) return;

                Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;
                rom.Favorite = !rom.Favorite;
                Rom.Set(rom);
                XML.SaveXmlRoms();
                LoadGridRow(rom, dataGridView.SelectedRows[0]);

            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        #endregion

        #region Grid Events

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count > 1)
                {
                    FormCustomMessage.ShowError("Cannot initialize multiple roms");
                    return;
                }

                Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;
                RunAppFunctions.RunPlatform(rom);
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Space)
                {
                    dataGridView_DoubleClick(sender, e);
                }
                else if (e.KeyData == Keys.Delete)
                {
                    removeRomEntryToolStripMenuItem_Click(sender, e);
                }
                else if (e.KeyData == Keys.F5)
                {
                    FilteredRoms.Clear();
                    FilteredRoms.AddRange(Rom.GetAll());
                    AddRomsToGrid(FilteredRoms);
                }
                else if (e.KeyData == Keys.G)
                {
                    changeGenreToolStripMenuItem_Click(sender, null);
                }
                else if (e.KeyData == Keys.L)
                {
                    changeLabelsToolStripMenuItem_Click(sender, null);
                }
                else if (e.KeyData == Keys.P)
                {
                    changePlatformToolStripMenuItem_Click(sender, null);
                }
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void dataGridView_Click(object sender, EventArgs e)
        {
            try
            {
                EnableDisableButtonsBySelection();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (updating) return;

            labelSelectedRomsCount.Text = dataGridView.SelectedRows.Count.ToString();

            EnableDisableButtonsBySelection();
            LoadPictures();
        }

        private void dataGridView_Leave(object sender, EventArgs e)
        {
            try
            {
                selectedRomsOptionsToolStripMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void dataGridView_Enter(object sender, EventArgs e)
        {
            try
            {
                selectedRomsOptionsToolStripMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void dataGridViewPlatforms_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPlatforms.SelectedRows.Count > 1)
                {
                    FormCustomMessage.ShowError("Cannot initialize multiple emulators");
                    return;
                }

                Platform platform = null;

                if (dataGridViewPlatforms.SelectedRows.Count == 0)
                {
                    platform = (Platform)dataGridViewPlatforms.Rows[dataGridViewPlatforms.SelectedCells[0].RowIndex].Tag;
                }
                else
                {
                    platform = (Platform)dataGridViewPlatforms.SelectedRows[0].Tag;
                }

                RunAppFunctions.RunPlatform(platform);
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void dataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if ((dataGridView.Location.X + dataGridView.Size.Width) < e.X) return;

                if (e.Button == MouseButtons.Right)
                {
                    var hti = dataGridView.HitTest(e.X, e.Y);

                    if (hti.RowIndex == -1) return;

                    dataGridView.ClearSelection();
                    dataGridView.Rows[hti.RowIndex].Selected = true;
                }
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void dataGridViewPlatforms_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                var hti = dataGridViewPlatforms.HitTest(e.X, e.Y);

                if (hti.RowIndex == -1) return;

                dataGridViewPlatforms.ClearSelection();
                dataGridViewPlatforms.Rows[hti.RowIndex].Selected = true;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void auditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAudit form = new FormAudit();
            form.ShowDialog();
        }

        private void checkBoxFavorite_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (updating) return;
                FilterRoms();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        #endregion

        #region Methods

        private void CopyFromUrl(Rom rom, string imageType)
        {
            var romName = Functions.RemoveSubstring(rom.Name, '(', ')');
            romName = Functions.RemoveSubstring(romName, '[', ']');
            string url = "http://www.google.com/search?q={0} {1} {2}&source=lnms&tbm=isch&sa=X";
            url = string.Format(url, romName.Replace("[!]", "").Replace("!", "").Replace("&", " "), rom.Platform.Name, imageType);

            url = url.Replace("boxart", "box");

            ProcessStartInfo sInfo = new ProcessStartInfo(url);
            Process.Start(sInfo);

            FormAddPicFromUrl form = new FormAddPicFromUrl(rom, imageType);
            form.ShowDialog();
            LoadPictures();
        }

        private void FilterRoms()
        {
            FilteredRoms.Clear();
            //DateTime begin = DateTime.Now;

            Filter filter = new Filter();
            filter.text = textBoxFilter.Text;
            filter.platform = comboBoxPlatform.Text;
            filter.label = comboBoxLabels.Text;
            filter.genre = comboBoxGenre.Text;
            filter.publisher = comboBoxPublisher.Text;
            filter.developer = comboBoxDeveloper.Text;
            filter.year = comboBoxYearReleased.Text;
            filter.status = comboBoxStatus.Text;
            filter.favorite = checkBoxFavorite.Checked;
            filter.text = filter.text.ToLower();
            filter.textType = comboBoxFilter.Text;

            if (updating) return;

            dataGridView.SuspendLayout();
            Thread.BeginCriticalRegion();

            FilteredRoms = FilterFunctions.FilterRoms(filter);

            Thread.EndCriticalRegion();
            dataGridView.ResumeLayout();
            //DateTime end = DateTime.Now;
            AddRomsToGrid(FilteredRoms);
            //FormCustomMessage.Show((end - begin).ToString());
        }

        private void AddRomsToGrid(List<Rom> roms)
        {
            dataGridView.SuspendLayout();
            dataGridView.DataSource = null;
            dataGridView.Rows.Clear();

            foreach (Rom rom in roms)
            {
                int rowId = dataGridView.Rows.Add();
                DataGridViewRow row = dataGridView.Rows[rowId];
                LoadGridRow(rom, row);
                FillLabelCell(rom, row);
                row.Tag = rom;
            }

            labelTotalRomsCount.Text = roms.Count.ToString();
            dataGridView.ClearSelection();
            dataGridView.ResumeLayout();
        }

        private void LoadGridRow(Rom rom, DataGridViewRow row)
        {
            row.Cells[columnRomName.Index].Value = rom.Name;
            row.Cells[columnRomPath.Index].Value = rom.Path;
            row.Cells[columnRomDBName.Index].Value = rom.DBName;
            row.Cells[columnFilename.Index].Value = rom.FileName;
            row.Cells[columnDeveloper.Index].Value = rom.Developer;
            row.Cells[columnPublisher.Index].Value = rom.Publisher;
            row.Cells[columnYearReleased.Index].Value = rom.YearReleased;
            row.Cells[columnRating.Index].Value = rom.Rating != 0 ? rom.Rating.ToString("0#.#") : string.Empty;

            if (rom.Favorite)
            {
                row.Cells[columnRomName.Index].Style.ForeColor = Color.DarkRed;
                row.Cells[columnRomName.Index].Style.BackColor = Color.Gold;
            }
            else
            {
                row.Cells[columnRomName.Index].Style.ForeColor = dataGridView.RowTemplate.DefaultCellStyle.ForeColor;
                row.Cells[columnRomName.Index].Style.BackColor = dataGridView.RowTemplate.DefaultCellStyle.BackColor;
            }

            if (rom.Rating >= 7)
            {
                row.Cells[columnRating.Index].Style.BackColor = Color.LightGreen;
            }
            else if (rom.Rating >= 4)
            {
                row.Cells[columnRating.Index].Style.BackColor = Color.LightYellow;
            }
            else if (rom.Rating > 0)
            {
                row.Cells[columnRating.Index].Style.BackColor = Color.IndianRed;
            }

            if (rom.Platform != null)
            {
                if (rom.Platform.Icon != null)
                {
                    row.Cells[columnIconMain.Index].Value = rom.Platform.Icon;
                }

                row.Cells[columnPlatform.Index].Value = rom.Platform.Name;
                row.Cells[columnPlatform.Index].Style.BackColor = rom.Platform.Color;
                row.Cells[columnPlatform.Index].Style.ForeColor = Functions.SetFontContrast(rom.Platform.Color);
            }

            if (rom.Genre != null)
            {
                row.Cells[columnGenre.Index].Value = rom.Genre.Name;
                row.Cells[columnGenre.Index].Style.BackColor = rom.Genre.Color;
                row.Cells[columnGenre.Index].Style.ForeColor = Functions.SetFontContrast(rom.Genre.Color);
            }

            if (!string.IsNullOrEmpty(rom.Status))
            {
                row.Cells[columnStatus.Index].Value = rom.Status;
                row.Cells[columnStatus.Index].Style.BackColor = Color.Navy;
                row.Cells[columnStatus.Index].Style.ForeColor = Color.White;
            }
            else
            {
                row.Cells[columnStatus.Index].Value = "";
                row.Cells[columnStatus.Index].Style.ForeColor = dataGridView.RowTemplate.DefaultCellStyle.ForeColor;
                row.Cells[columnStatus.Index].Style.BackColor = dataGridView.RowTemplate.DefaultCellStyle.BackColor;
            }

            row.Cells[columnRating.Index].Style.ForeColor = Color.Black;

            row.Cells[1].ToolTipText = rom.Description;
        }

        private void FillPlatformFilter(string platform = "")
        {
            updating = true;

            List<Platform> platforms = Platform.GetAll().Where(x => x.ShowInFilter).ToList();
            platforms.Insert(0, new Platform());
            platforms.Insert(1, new Platform() { Name = "<none>" });
            comboBoxPlatform.DataSource = platforms;
            comboBoxPlatform.DisplayMember = "Name";
            comboBoxPlatform.ValueMember = "Name";

            if (string.IsNullOrEmpty(platform))
            {
                comboBoxPlatform.SelectedIndex = 0;
            }
            else
            {
                comboBoxPlatform.SelectedValue = platform;
            }

            updating = false;
        }

        private void FillLabelFilter()
        {
            updating = true;
            List<RomLabel> labels = RomLabel.GetAll();
            labels.Insert(0, new RomLabel());
            labels.Insert(1, new RomLabel() { Name = "<none>" });
            comboBoxLabels.DataSource = labels;
            comboBoxLabels.DisplayMember = "Name";
            comboBoxLabels.ValueMember = "Name";
            comboBoxLabels.SelectedIndex = 0;
            updating = false;
        }

        private void FillGenreFilter(string genre = "")
        {
            updating = true;
            List<Genre> genres = Genre.GetAll();
            genres.Insert(0, new Genre());
            genres.Insert(1, new Genre() { Name = "<none>" });
            comboBoxGenre.DataSource = genres;
            comboBoxGenre.DisplayMember = "Name";
            comboBoxGenre.ValueMember = "Name";

            if (genre == "")
            {
                comboBoxGenre.SelectedIndex = 0;
            }
            else
            {
                comboBoxGenre.SelectedValue = genre;
            }

            updating = false;
        }

        private void FillPublisherFilter()
        {
            updating = true;
            Publisher.Fill(Rom.GetAll());
            List<string> publishers = Publisher.GetAll();
            publishers.Insert(0, "");
            comboBoxPublisher.DataSource = publishers;
            comboBoxPublisher.SelectedIndex = 0;
            updating = false;
        }

        private void FillDeveloperFilter()
        {
            updating = true;
            Developer.Fill(Rom.GetAll());
            List<string> developers = Developer.GetAll();
            developers.Insert(0, "");
            comboBoxDeveloper.DataSource = developers;
            comboBoxDeveloper.SelectedIndex = 0;
            updating = false;
        }

        private void FillYearReleasedFilter()
        {
            updating = true;
            YearReleased.Fill(Rom.GetAll());
            List<string> yearReleased = YearReleased.GetAll();
            yearReleased.Insert(0, "");
            comboBoxYearReleased.DataSource = yearReleased;
            comboBoxYearReleased.SelectedIndex = 0;
            updating = false;
        }

        private void FillStatusFilter()
        {
            updating = true;
            var status = Values.Status.ToArray().ToList();
            status.Insert(0, "");
            status.Insert(1, "<none>");
            comboBoxStatus.DataSource = status;
            comboBoxStatus.SelectedIndex = 0;
            updating = false;
        }

        private void FillLabelCell(Rom rom, DataGridViewRow row)
        {
            row.Cells[columnLabels.Index].Value = "";

            if (rom.Labels.Count > 0)
            {
                foreach (RomLabel label in rom.Labels)
                {
                    row.Cells[columnLabels.Index].Value += " | " + label.Name;
                }

                row.Cells[columnLabels.Index].Style.BackColor = rom.Labels[0].Color;
                row.Cells[columnLabels.Index].Style.ForeColor = Functions.SetFontContrast(rom.Labels[0].Color);

                row.Cells[columnLabels.Index].Value = row.Cells[columnLabels.Index].Value.ToString().Substring(3);
            }
            else
            {
                row.Cells[columnLabels.Index].Style.BackColor = dataGridView.RowTemplate.DefaultCellStyle.BackColor;
                row.Cells[columnLabels.Index].Style.ForeColor = dataGridView.RowTemplate.DefaultCellStyle.ForeColor;
            }
        }

        private void EnableDisableButtonsBySelection()
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                selectedRomsOptionsToolStripMenuItem.Enabled = false;
                buttonRomOpenFolder.Enabled = false;
                buttonRomRemoveRom.Enabled = false;
                buttonRomDeleteRomFromDisk.Enabled = false;
                manageRomToolStripMenuItem.Enabled = false;
                changePlatformToolStripMenuItem.Enabled = false;
                changeGenreToolStripMenuItem.Enabled = false;
                changeLabelsToolStripMenuItem.Enabled = false;
                openFileToolStripMenuItem.Enabled = false;
            }
            else if (dataGridView.SelectedRows.Count == 1)
            {
                selectedRomsOptionsToolStripMenuItem.Enabled = true;
                buttonRomOpenFolder.Enabled = true;
                buttonRomRemoveRom.Enabled = true;
                buttonRomDeleteRomFromDisk.Enabled = true;
                manageRomToolStripMenuItem.Enabled = true;
                changePlatformToolStripMenuItem.Enabled = true;
                changeGenreToolStripMenuItem.Enabled = true;
                changeLabelsToolStripMenuItem.Enabled = true;
                openFileToolStripMenuItem.Enabled = true;
            }
            else
            {
                selectedRomsOptionsToolStripMenuItem.Enabled = true;
                buttonRomOpenFolder.Enabled = false;
                buttonRomRemoveRom.Enabled = true;
                buttonRomDeleteRomFromDisk.Enabled = false;
                manageRomToolStripMenuItem.Enabled = false;
                changePlatformToolStripMenuItem.Enabled = true;
                changeGenreToolStripMenuItem.Enabled = true;
                changeLabelsToolStripMenuItem.Enabled = true;
                openFileToolStripMenuItem.Enabled = false;
            }
        }

        private void LoadPictures()
        {
            try
            {
                pictureBoxBoxart.Image = null;
                pictureBoxTitle.Image = null;
                pictureBoxGameplay.Image = null;

                if (dataGridView.SelectedRows.Count == 0) return;

                Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;

                if (rom == null) return;

                if (rom.Platform == null) return;

                var box = RomFunctions.GetRomPicture(rom, Values.BoxartFolder);
                var title = RomFunctions.GetRomPicture(rom, Values.TitleFolder);
                var gameplay = RomFunctions.GetRomPicture(rom, Values.GameplayFolder);

                if (!string.IsNullOrEmpty(box))
                {
                    pictureBoxBoxart.Image = Functions.CreateBitmap(box);
                }

                if (!string.IsNullOrEmpty(title))
                {
                    pictureBoxTitle.Image = Functions.CreateBitmap(title);
                }

                if (!string.IsNullOrEmpty(gameplay))
                {
                    pictureBoxGameplay.Image = Functions.CreateBitmap(gameplay);
                }
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void FillPlatformGrid()
        {
            var emus = Platform.GetAll().Where(x => x.ShowInList).ToList();
            dataGridViewPlatforms.Rows.Clear();

            foreach (var platform in emus)
            {
                int rowId = dataGridViewPlatforms.Rows.Add();
                DataGridViewRow row = dataGridViewPlatforms.Rows[rowId];

                if (platform.Icon != null)
                {
                    row.Cells[ColumnIcon.Index].Value = platform.Icon;
                }

                row.Cells[columnPlatforms.Index].Value = platform.Name;
                row.Cells[columnPlatforms.Index].Style.BackColor = platform.Color;
                row.Cells[columnPlatforms.Index].Style.ForeColor = Functions.SetFontContrast(platform.Color);
                row.Tag = platform;
            }
        }

        private void SelectRandomRom()
        {
            if (dataGridView.Rows.Count < 2) return;

            int random = new Random().Next(0, dataGridView.Rows.Count - 1);
            dataGridView.CurrentCell = dataGridView.Rows[random].Cells[0];
        }

        #endregion

    }
}
