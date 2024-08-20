using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using EmuLoader.Core.Models;
using System.Diagnostics;

namespace EmuLoader.Gui.Forms
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

                columnSeries.Visible = showSeriesToolStripMenuItem.Checked = ConfigBusiness.GetElementVisibility(Column.ColumnRomSeries);
                columnPlatform.Visible = showPlatformColumnToolStripMenuItem.Checked = ConfigBusiness.GetElementVisibility(Column.ColumnPlatform);
                columnGenre.Visible = showGenreColumnToolStripMenuItem.Checked = ConfigBusiness.GetElementVisibility(Column.ColumnGenre);
                columnStatus.Visible = showStatusColumnToolStripMenuItem.Checked = ConfigBusiness.GetElementVisibility(Column.ColumnStatus);
                columnLabels.Visible = showLabelsColumnToolStripMenuItem.Checked = ConfigBusiness.GetElementVisibility(Column.ColumnLabels);
                columnRomDBName.Visible = showRomDBNameColumnToolStripMenuItem.Checked = ConfigBusiness.GetElementVisibility(Column.ColumnRomDBName);
                columnFilename.Visible = showFilenameToolStripMenuItem.Checked = ConfigBusiness.GetElementVisibility(Column.ColumnFileName);
                columnDeveloper.Visible = showDeveloperColumnToolStripMenuItem.Checked = ConfigBusiness.GetElementVisibility(Column.ColumnDeveloper);
                columnPublisher.Visible = showPublisherColumnToolStripMenuItem.Checked = ConfigBusiness.GetElementVisibility(Column.ColumnPublisher);
                columnYearReleased.Visible = showYearReleasedColumnToolStripMenuItem.Checked = ConfigBusiness.GetElementVisibility(Column.ColumnYearReleased);
                columnRating.Visible = showRatingColumnToolStripMenuItem.Checked = ConfigBusiness.GetElementVisibility(Column.ColumnRating);
                pictureBoxBoxart.Visible = showBoxArtToolStripMenuItem.Checked = ConfigBusiness.GetElementVisibility(Column.BoxArt);
                pictureBoxTitle.Visible = showTitleToolStripMenuItem.Checked = ConfigBusiness.GetElementVisibility(Column.TitleArt);
                pictureBoxGameplay.Visible = showGameplayArtToolStripMenuItem.Checked = ConfigBusiness.GetElementVisibility(Column.GameplayArt);
                dataGridViewPlatforms.Visible = showPlatformsListToolStripMenuItem.Checked = ConfigBusiness.GetElementVisibility(Column.PlatformsList);
                flowLayoutPanelPictures.Visible = pictureBoxBoxart.Visible || pictureBoxTitle.Visible || pictureBoxGameplay.Visible;
                //FormMessage.ShowMessage("Filling Grid...");

                FillLabelFilter();
                FillGenreFilter();
                FillPublisherFilter();
                FillDeveloperFilter();
                FillYearReleasedFilter();
                FillStatusFilter();

                updating = true;
                Filter filter = FilterFunctions.GetFilter();

                textBoxFilter.Text = filter.text;

                if (!string.IsNullOrEmpty(filter.textType))
                {
                    comboBoxFilter.Text = filter.textType;
                }

                if (!string.IsNullOrEmpty(filter.platform))
                {
                    comboBoxPlatform.Text = filter.platform;
                }

                if (!string.IsNullOrEmpty(filter.label))
                {
                    comboBoxLabels.Text = filter.label;
                }

                if (!string.IsNullOrEmpty(filter.genre))
                {
                    comboBoxGenre.Text = filter.genre;
                }

                if (!string.IsNullOrEmpty(filter.status))
                {
                    comboBoxStatus.Text = filter.status;
                }

                if (!string.IsNullOrEmpty(filter.developer))
                {
                    comboBoxDeveloper.Text = filter.developer;
                }

                if (!string.IsNullOrEmpty(filter.publisher))
                {
                    comboBoxPublisher.Text = filter.publisher;
                }

                if (!string.IsNullOrEmpty(filter.year))
                {
                    comboBoxYearReleased.Text = filter.year;
                }

                checkBoxFavorite.Checked = filter.favorite;
                checkBoxArcade.Checked = filter.arcade;
                checkBoxConsole.Checked = filter.console;
                checkBoxHandheld.Checked = filter.handheld;
                checkBoxCD.Checked = filter.cd;
                FillPlatformFilter(filter.platform);

                updating = false;

                FilterRoms(filter);
                dataGridView.ClearSelection();

                var height = ConfigBusiness.GetHeight();
                var width = ConfigBusiness.GetWidth();

                if (!string.IsNullOrEmpty(height) && !string.IsNullOrEmpty(width))
                {
                    this.Height = Convert.ToInt32(height);
                    this.Width = Convert.ToInt32(width);
                }

                if (string.IsNullOrEmpty(filter.romfile))
                {
                    SelectRandomRom();
                }
                else
                {
                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        if (dataGridView.Rows[i].Cells[columnPlatform.Index].Value.ToString() == filter.romplatform &&
                            dataGridView.Rows[i].Cells[columnFilename.Index].Value.ToString() == filter.romfile)
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
            filter.romfile = dataGridView.SelectedRows.Count == 0 ? "" : ((Rom)dataGridView.SelectedRows[0].Tag).FileName;
            filter.romplatform = dataGridView.SelectedRows.Count == 0 ? "" : ((Rom)dataGridView.SelectedRows[0].Tag).Platform.Name;
            filter.text = textBoxFilter.Text;
            filter.textType = comboBoxFilter.SelectedText;
            filter.favorite = checkBoxFavorite.Checked;
            filter.arcade = checkBoxArcade.Checked;
            filter.console = checkBoxConsole.Checked;
            filter.handheld = checkBoxHandheld.Checked;
            filter.status = comboBoxStatus.Text;
            filter.cd = checkBoxCD.Checked;

            FilterFunctions.SaveFilter(filter);
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

        private void pictureBoxBoxart_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            try
            {
                OpenPicture(Values.BoxartFolder);
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
                OpenPicture(Values.TitleFolder);
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
                OpenPicture(Values.GameplayFolder);
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

                ConfigBusiness.SetElementVisibility(Column.ColumnRomDBName, columnRomDBName.Visible);
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

        private void showSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                columnSeries.Visible = showSeriesToolStripMenuItem.Checked;

                if (updating) return;

                ConfigBusiness.SetElementVisibility(Column.ColumnRomSeries, columnSeries.Visible);
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

                ConfigBusiness.SetElementVisibility(Column.ColumnFileName, columnFilename.Visible);
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

                ConfigBusiness.SetElementVisibility(Column.ColumnPlatform, columnPlatform.Visible);
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

                ConfigBusiness.SetElementVisibility(Column.ColumnLabels, columnLabels.Visible);
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

                ConfigBusiness.SetElementVisibility(Column.ColumnGenre, columnGenre.Visible);
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

                ConfigBusiness.SetElementVisibility(Column.ColumnStatus, columnStatus.Visible);
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

                ConfigBusiness.SetElementVisibility(Column.ColumnDeveloper, columnDeveloper.Visible);
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

                ConfigBusiness.SetElementVisibility(Column.ColumnPublisher, columnPublisher.Visible);
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

                ConfigBusiness.SetElementVisibility(Column.ColumnYearReleased, columnYearReleased.Visible);
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

                ConfigBusiness.SetElementVisibility(Column.ColumnRating, columnRating.Visible);
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

                ConfigBusiness.SetElementVisibility(Column.PlatformsList, dataGridViewPlatforms.Visible);
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

                    if (File.Exists(rom.Platform.DefaultRomPath + "\\" + rom.FileName))
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
                comboBoxStatus.SelectedIndex = 0;
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

                FileInfo file = new FileInfo(rom.Platform.DefaultRomPath + "\\" + rom.FileName);
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
                    RomFunctions.RemoveInvalidRomsEntries(PlatformBusiness.Get(comboBoxPlatform.SelectedValue.ToString()));
                }
                else
                {
                    RomFunctions.RemoveInvalidRomsEntries();
                }

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
                ConfigBusiness.SetElementVisibility(Column.BoxArt, pictureBoxBoxart.Visible);

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
                ConfigBusiness.SetElementVisibility(Column.TitleArt, pictureBoxTitle.Visible);

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
                ConfigBusiness.SetElementVisibility(Column.GameplayArt, pictureBoxGameplay.Visible);

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
                    ProcessStartInfo sInfo = new ProcessStartInfo(rom.Platform.DefaultRomPath + "\\" + rom.FileName);
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
                ConfigBusiness.SetHeight(Height.ToString());
                ConfigBusiness.SetWidth(Width.ToString());

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
                    RomBusiness.Fill();
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
                    RomBusiness.Fill();
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

            var platform = PlatformBusiness.Get(comboBoxPlatform.Text);

            var result = PlatformBusiness.RescanRoms(platform);

            if (result)
            {
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
                RomBusiness.SetRom(rom);
                LoadGridRow(rom, dataGridView.SelectedRows[0]);

            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void pictureBoxRun_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0) return;
            if (comboBoxEmulators.SelectedItem == null) return;
            Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;
            Emulator emu = (Emulator)comboBoxEmulators.SelectedItem;
            RunAppFunctions.OpenApplication(rom, emu);
        }

        private void buttonOpenEmu_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0) return;
            if (comboBoxEmulators.SelectedItem == null) return;
            Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;
            Emulator emu = (Emulator)comboBoxEmulators.SelectedItem;
            RunAppFunctions.RunPlatform(emu);
        }

        #endregion

    }
}
