using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using EmuLoader.Classes;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

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
                XML.LoadXml();
                RomLabel.Fill();
                Genre.Fill();
                Platform.Fill();
                FillPlatformGrid();
                //FormMessage.ShowMessage("Loading Roms...");
                Rom.Fill();
                columnPlatform.Visible = showPlatformColumnToolStripMenuItem.Checked = Config.GetElementVisibility("ColumnPlatform");
                columnGenre.Visible = showGenreColumnToolStripMenuItem.Checked = Config.GetElementVisibility("ColumnGenre");
                columnLabels.Visible = showLabelsColumnToolStripMenuItem.Checked = Config.GetElementVisibility("ColumnLabels");
                columnRomPath.Visible = showPathColumnToolStripMenuItem.Checked = Config.GetElementVisibility("ColumnPath");
                columnFilename.Visible = showFilenameToolStripMenuItem.Checked = Config.GetElementVisibility("ColumnFileName");
                columnDeveloper.Visible = showDeveloperColumnToolStripMenuItem.Checked = Config.GetElementVisibility("ColumnDeveloper");
                columnPublisher.Visible = showPublisherColumnToolStripMenuItem.Checked = Config.GetElementVisibility("ColumnPublisher");
                columnYearReleased.Visible = showYearReleasedColumnToolStripMenuItem.Checked = Config.GetElementVisibility("ColumnYearReleased");
                pictureBoxBoxart.Visible = showBoxArtToolStripMenuItem.Checked = Config.GetElementVisibility("BoxArt");
                pictureBoxTitle.Visible = showTitleToolStripMenuItem.Checked = Config.GetElementVisibility("TitleArt");
                pictureBoxGameplay.Visible = showGameplayArtToolStripMenuItem.Checked = Config.GetElementVisibility("GameplayArt");
                dataGridViewPlatforms.Visible = showPlatformsListToolStripMenuItem.Checked = Config.GetElementVisibility("PlatformsList");
                flowLayoutPanelImages.Visible = pictureBoxBoxart.Visible || pictureBoxTitle.Visible || pictureBoxGameplay.Visible;
                //FormMessage.ShowMessage("Filling Grid...");
                FilteredRoms.Clear();
                FilteredRoms.AddRange(Rom.GetAll());
                AddRomsToGrid(FilteredRoms);
                FillEmuFilter();
                FillLabelFilter();
                FillGenreFilter();
                FillPublisherFilter();
                FillDeveloperFilter();
                FillYearReleasedFilter();
                updating = false;
                dataGridView.ClearSelection();

                var height = XML.GetConfig("Height");
                var width = XML.GetConfig("Width");

                if (!string.IsNullOrEmpty(height) && !string.IsNullOrEmpty(width))
                {
                    this.Height = Convert.ToInt32(height);
                    this.Width = Convert.ToInt32(width);
                }

                SelectRandomRom();
                //FormMessage.CloseMessage();
                //DateTime end = DateTime.Now;
                //MessageBox.Show((end - begin).ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void manageLabelToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                FormLabel form = new FormLabel();

                if (form.ShowDialogBool())
                {
                    FillLabelFilter();
                    buttonClear_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void manageGenreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormGenre form = new FormGenre();

                if (form.ShowDialogBool())
                {
                    FillGenreFilter();
                    buttonClear_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void managePlatformToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                FormPlatform form = new FormPlatform();

                if (form.ShowDialogBool() && form.Updated)
                {
                    Platform.Fill();
                    Rom.Fill();
                    FilterRoms();
                    FillEmuFilter();
                    FillPlatformGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addRomDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog open = new FolderBrowserDialog();

            if (open.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            if (open.SelectedPath.Length == 0)
            {
                return;
            }

            var romsPath = Directory.GetFiles(open.SelectedPath);

            List<Rom> romList = new List<Rom>();

            foreach (string s in romsPath)
            {
                Rom r = new Rom(s);
                Rom old = Rom.Get(r.Path);

                if (old != null)
                {
                    r = old;
                }

                romList.Add(r);
            }

            FormChoose.ChoosePlatform(romList);
            FilterRoms();
        }

        private void toolStripButtonAddRom_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();

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

                List<Rom> romList = new List<Rom>();

                foreach (string s in open.FileNames)
                {
                    Rom r = new Rom(s);
                    Rom old = Rom.Get(r.Path);

                    if (old != null)
                    {
                        r = old;
                    }

                    romList.Add(r);
                }

                FormChoose.ChoosePlatform(romList);
                FilterRoms();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBoxBoxart_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            try
            {
                Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;
                ProcessStartInfo sInfo = new ProcessStartInfo(Functions.GetRomPicture(rom, Values.BoxartFolder));
                Process.Start(sInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBoxTitle_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            try
            {
                Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;
                ProcessStartInfo sInfo = new ProcessStartInfo(Functions.GetRomPicture(rom, Values.TitleFolder));
                Process.Start(sInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBoxGameplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            try
            {
                Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;
                ProcessStartInfo sInfo = new ProcessStartInfo(Functions.GetRomPicture(rom, Values.GameplayFolder));
                Process.Start(sInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void changePlatformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<Rom> romList = new List<Rom>();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    romList.Add((Rom)row.Tag);
                }

                FormChoose.ChoosePlatform(romList);

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
                MessageBox.Show(ex.Message);
            }
        }

        private void changeGenreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<Rom> romList = new List<Rom>();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    romList.Add((Rom)row.Tag);
                }

                FormChoose.ChooseGenre(romList);

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
                MessageBox.Show(ex.Message);
            }
        }

        private void changeLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                List<Rom> roms = new List<Rom>();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    if (!row.Visible) continue;
                    roms.Add((Rom)row.Tag);
                }

                FormChooseList.ChooseLabel(roms);

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    FillLabelCell((Rom)row.Tag, row);
                }

                dataGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void removeRomEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    if (!row.Visible) continue;
                    Rom rom = (Rom)row.Tag;

                    var message = MessageBox.Show(string.Format("Do you want to remove {0} ?", rom.Name), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (message.ToString() == "No") continue;

                    Rom.Delete(rom);
                    Functions.RemoveRomPics(rom);
                    dataGridView.Rows.Remove(row);
                    FilteredRoms.Remove(rom);
                }

                labelTotalRomsCount.Text = FilteredRoms.Count.ToString();
                XML.SaveXml();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteRomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = dataGridView.SelectedRows[0];
                Rom rom = (Rom)row.Tag;

                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(rom.Path,
                    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);

                dataGridView.Rows.Remove(row);
                Rom.Delete(rom);
                Functions.RemoveRomPics(rom);
                FilteredRoms.Remove(rom);
                labelTotalRomsCount.Text = FilteredRoms.Count.ToString();
                XML.SaveXml();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItemShowPathColumn_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                columnRomPath.Visible = showPathColumnToolStripMenuItem.Checked;

                if (updating) return;

                Config.SetElementVisibility("ColumnPath", columnRomPath.Visible);
                XML.SaveXml();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showFilenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                columnFilename.Visible = showFilenameToolStripMenuItem.Checked;

                if (updating) return;

                Config.SetElementVisibility("ColumnFileName", columnFilename.Visible);
                XML.SaveXml();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ToolStripMenuItemShowPlatformColumn_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                columnPlatform.Visible = showPlatformColumnToolStripMenuItem.Checked;

                if (updating) return;

                Config.SetElementVisibility("ColumnPlatform", columnPlatform.Visible);
                XML.SaveXml();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showLabelsColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                columnLabels.Visible = showLabelsColumnToolStripMenuItem.Checked;

                if (updating) return;

                Config.SetElementVisibility("ColumnLabels", columnLabels.Visible);
                XML.SaveXml();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showGenreColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                columnGenre.Visible = showGenreColumnToolStripMenuItem.Checked;

                if (updating) return;

                Config.SetElementVisibility("ColumnGenre", columnGenre.Visible);
                XML.SaveXml();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showDeveloperColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                columnDeveloper.Visible = showDeveloperColumnToolStripMenuItem.Checked;

                if (updating) return;

                Config.SetElementVisibility("ColumnDeveloper", columnDeveloper.Visible);
                XML.SaveXml();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showPublisherColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                columnPublisher.Visible = showPublisherColumnToolStripMenuItem.Checked;

                if (updating) return;

                Config.SetElementVisibility("ColumnPublisher", columnPublisher.Visible);
                XML.SaveXml();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showYearReleasedColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                columnYearReleased.Visible = showYearReleasedColumnToolStripMenuItem.Checked;

                if (updating) return;

                Config.SetElementVisibility("ColumnYearReleased", columnYearReleased.Visible);
                XML.SaveXml();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showPlatformsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewPlatforms.Visible = showPlatformsListToolStripMenuItem.Checked;

                if (updating) return;

                Config.SetElementVisibility("PlatformsList", dataGridViewPlatforms.Visible);
                XML.SaveXml();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButtonRemoveInvalid_Click(object sender, EventArgs e)
        {
            try
            {
                List<Rom> roms = Rom.GetAll();

                foreach (Rom rom in roms)
                {
                    if (!File.Exists(rom.Path))
                    {
                        Rom.Delete(rom);
                        Functions.RemoveRomPics(rom);
                    }
                }

                XML.SaveXml();
                FilterRoms();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (updating) return;
                FilterRoms();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
            }
        }

        private void timerFilter_Tick(object sender, EventArgs e)
        {
            timerFilter.Stop();
            FilterRoms();
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            timerFilter.Start();
        }

        private void batchAddImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBatchAddPictures form = new FormBatchAddPictures();
            form.ShowDialog();
        }

        private void batchRemoveImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();
            pictureBoxBoxart.Image = null;
            pictureBoxTitle.Image = null;
            pictureBoxGameplay.Image = null;
            FormBatchRemovePictures form = new FormBatchRemovePictures();
            form.ShowDialog();
        }

        private void manageRomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0) return;

            Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;
            FormManageRom form = new FormManageRom(rom);
            form.ShowDialog();
            dataGridView.SelectedRows[0].Cells["columnRomName"].Value = rom.Name;
            dataGridView.SelectedRows[0].Cells["columnRomPath"].Value = rom.Path;
            dataGridView.SelectedRows[0].Cells["columnDeveloper"].Value = rom.Developer;
            dataGridView.SelectedRows[0].Cells["columnPublisher"].Value = rom.Publisher;
            dataGridView.SelectedRows[0].Cells["columnYearReleased"].Value = rom.YearReleased;
            dataGridView.SelectedRows[0].Cells["columnPlatform"].Value = rom.Platform == null ? "" : rom.Platform.Name;
            dataGridView.SelectedRows[0].Cells["columnPlatform"].Style.BackColor = rom.Platform == null ? dataGridView.SelectedRows[0].Cells["columnPlatform"].Style.BackColor : rom.Platform.Color;
            dataGridView.SelectedRows[0].Cells["columnPlatform"].Style.ForeColor = rom.Platform == null ? dataGridView.SelectedRows[0].Cells["columnPlatform"].Style.ForeColor : Functions.SetFontContrast(rom.Platform.Color);
            dataGridView.SelectedRows[0].Cells["columnGenre"].Value = rom.Genre == null ? "" : rom.Genre.Name;
            dataGridView.SelectedRows[0].Cells["columnGenre"].Style.BackColor = rom.Genre == null ? dataGridView.SelectedRows[0].Cells["columnGenre"].Style.BackColor : rom.Genre.Color;
            dataGridView.SelectedRows[0].Cells["columnGenre"].Style.ForeColor = rom.Genre == null ? dataGridView.SelectedRows[0].Cells["columnGenre"].Style.ForeColor : Functions.SetFontContrast(rom.Genre.Color);

            FillLabelCell(rom, dataGridView.SelectedRows[0]);
            LoadPictures();
        }

        private void showBoxArtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!pictureBoxBoxart.Visible && showBoxArtToolStripMenuItem.Checked)
                {
                    flowLayoutPanelImages.Visible = true;
                }

                pictureBoxBoxart.Visible = showBoxArtToolStripMenuItem.Checked;
                Config.SetElementVisibility("BoxArt", pictureBoxBoxart.Visible);
                XML.SaveXml();

                flowLayoutPanelImages.Visible = pictureBoxBoxart.Visible || pictureBoxTitle.Visible || pictureBoxGameplay.Visible;
                FormMain_ResizeEnd(sender, e);
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!pictureBoxTitle.Visible && showTitleToolStripMenuItem.Checked)
                {
                    flowLayoutPanelImages.Visible = true;
                }

                pictureBoxTitle.Visible = showTitleToolStripMenuItem.Checked;
                Config.SetElementVisibility("TitleArt", pictureBoxTitle.Visible);
                XML.SaveXml();

                flowLayoutPanelImages.Visible = pictureBoxBoxart.Visible || pictureBoxTitle.Visible || pictureBoxGameplay.Visible;
                FormMain_ResizeEnd(sender, e);
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showGameplayArtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!pictureBoxGameplay.Visible && showGameplayArtToolStripMenuItem.Checked)
                {
                    flowLayoutPanelImages.Visible = true;
                }

                pictureBoxGameplay.Visible = showGameplayArtToolStripMenuItem.Checked;
                Config.SetElementVisibility("GameplayArt", pictureBoxGameplay.Visible);
                XML.SaveXml();

                flowLayoutPanelImages.Visible = pictureBoxBoxart.Visible || pictureBoxTitle.Visible || pictureBoxGameplay.Visible;
                FormMain_ResizeEnd(sender, e);
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBoxBoxart_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0) return;

            Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;
            CopyFromUrl(rom, Values.BoxartFolder);
        }

        private void pictureBoxTitle_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0) return;

            Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;
            CopyFromUrl(rom, Values.TitleFolder);
        }

        private void pictureBoxGameplay_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0) return;

            Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;
            CopyFromUrl(rom, Values.GameplayFolder);
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
                MessageBox.Show(ex.Message);
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
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
                MessageBox.Show(ex.Message);
            }
        }

        private void FormMain_ResizeEnd(object sender, EventArgs e)
        {
            XML.SetConfig("Height", this.Height.ToString());
            XML.SetConfig("Width", this.Width.ToString());
            XML.SaveXml();

            int imagesHeightTotal = pictureBoxBoxart.Size.Height * 3;
            int heightLeft = flowLayoutPanelImages.Size.Height - imagesHeightTotal;

            if (heightLeft < 25 && heightLeft > 0) return;

            if (heightLeft > 0)
            {
                int heightForEachImage = Convert.ToInt32(heightLeft / 3) + pictureBoxBoxart.Size.Height - 6;

                flowLayoutPanelImages.Size = new Size(heightForEachImage + 6, dataGridView.Size.Height);
                pictureBoxBoxart.Size = new Size(heightForEachImage, heightForEachImage);
                pictureBoxTitle.Size = new Size(heightForEachImage, heightForEachImage);
                pictureBoxGameplay.Size = new Size(heightForEachImage, heightForEachImage);
            }
            else
            {
                int heightForEachImage = pictureBoxBoxart.Size.Height - 6 - Convert.ToInt32(heightLeft * -1 / 3);

                flowLayoutPanelImages.Size = new Size(heightForEachImage + 6, dataGridView.Size.Height);
                pictureBoxBoxart.Size = new Size(heightForEachImage, heightForEachImage);
                pictureBoxTitle.Size = new Size(heightForEachImage, heightForEachImage);
                pictureBoxGameplay.Size = new Size(heightForEachImage, heightForEachImage);
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
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

        private void addRomPackInDirectoryStructureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog open = new FolderBrowserDialog();

            if (open.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            if (open.SelectedPath.Length == 0)
            {
                return;
            }

            var directories = Directory.GetDirectories(open.SelectedPath);
            List<Rom> romList = new List<Rom>();

            foreach (var path in directories)
            {
                var files = Directory.GetFiles(path);

                foreach (var item in files)
                {
                    if (item.EndsWith(".cue") || item.EndsWith(".ccd") || item.EndsWith(".rom") || item.EndsWith(".gdi"))
                    {
                        Rom r = new Rom(item);
                        Rom old = Rom.Get(r.Path);

                        if (old != null)
                        {
                            r = old;
                        }

                        romList.Add(r);
                    }
                }
            }

            FormChoose.ChoosePlatform(romList);
            FilterRoms();
        }

        #endregion

        #region Grid Events

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Cannot initialize multiple roms", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;
                Functions.RunPlatform(rom);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
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
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (updating) return;
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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewPlatforms_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPlatforms.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Cannot initialize multiple emulators", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                Functions.RunPlatform(platform);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if ((dataGridView.Location.X + dataGridView.Size.Width) < e.X) return;

            if (e.Button == MouseButtons.Right)
            {
                var hti = dataGridView.HitTest(e.X, e.Y);
                dataGridView.ClearSelection();
                dataGridView.Rows[hti.RowIndex].Selected = true;
            }
        }

        private void dataGridViewPlatforms_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                var hti = dataGridViewPlatforms.HitTest(e.X, e.Y);
                dataGridViewPlatforms.ClearSelection();
                dataGridViewPlatforms.Rows[hti.RowIndex].Selected = true;
            }
            catch
            {

            }
        }

        #endregion

        #region Methods

        private void CopyFromUrl(Rom rom, string imageType)
        {
            string url = "http://www.google.com/search?q={0} {1} {2}&source=lnms&tbm=isch&sa=X";
            url = string.Format(url, rom.Name.Replace("[!]", "").Replace("!", "").Replace("&", " "), rom.Platform.Name, imageType);
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
            DateTime begin = DateTime.Now;
            string text;
            Platform emu;
            RomLabel label;
            Genre genre;

            text = textBoxFilter.Text;
            emu = comboBoxPlatform.SelectedItem == null ? (Platform)comboBoxPlatform.Items[0] : (Platform)comboBoxPlatform.SelectedItem;
            label = comboBoxLabels.SelectedItem == null ? (RomLabel)comboBoxLabels.Items[0] : (RomLabel)comboBoxLabels.SelectedItem;
            genre = comboBoxGenre.SelectedItem == null ? (Genre)comboBoxGenre.Items[0] : (Genre)comboBoxGenre.SelectedItem;
            string publisher = comboBoxPublisher.Text;
            string developer = comboBoxDeveloper.Text;
            string year = comboBoxYearReleased.Text;

            string filter = text.ToLower();

            if (updating) return;

            dataGridView.SuspendLayout();
            Thread.BeginCriticalRegion();

            if (filter == "" && emu.Name == "" && label.Name == "" && genre.Name == "" && publisher == "" && developer == "" && year == "")
            {
                foreach (Rom item in Rom.GetAll())
                {
                    FilteredRoms.Add(item);
                }
            }
            else
            {
                int index = 0;
                try
                {
                    foreach (Rom rom in Rom.GetAll())
                    {
                        if ((filter == "" || rom.Name.ToLower().Contains(filter))
                            && (publisher == "" || rom.Publisher == publisher)
                            && (developer == "" || rom.Developer == developer)
                            && (year == "" || rom.YearReleased == year)
                            && ((emu.Name == "<none>" && rom.Platform == null) || (emu.Name == "" || rom.Platform != null && rom.Platform.Name == emu.Name))
                            && ((genre.Name == "<none>" && rom.Genre == null) || (genre.Name == "" || rom.Genre != null && rom.Genre.Name == genre.Name))
                            && ((label.Name == "<none>" && (rom.Labels == null || rom.Labels.Count == 0)) || (label.Name == "" || rom.Labels != null && rom.Labels.Count(l => l.Name == label.Name) > 0)))
                        {

                            FilteredRoms.Add(rom);
                        }

                        index++;
                    }
                }
                catch (Exception ex)
                {

                }
            }

            Thread.EndCriticalRegion();
            dataGridView.ResumeLayout();
            DateTime end = DateTime.Now;
            AddRomsToGrid(FilteredRoms);
            //MessageBox.Show((end - begin).ToString());
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

                row.Cells["columnRomName"].Value = rom.Name;
                row.Cells["columnRomPath"].Value = rom.Path;
                row.Cells["columnFilename"].Value = rom.GetFileName();
                row.Cells["columnDeveloper"].Value = rom.Developer;
                row.Cells["columnPublisher"].Value = rom.Publisher;
                row.Cells["columnYearReleased"].Value = rom.YearReleased;

                if (rom.Platform != null)
                {
                    if (rom.Platform.Icon != null)
                    {
                        row.Cells["ColumnIconMain"].Value = rom.Platform.Icon;
                    }

                    row.Cells["columnPlatform"].Value = rom.Platform.Name;
                    row.Cells["columnPlatform"].Style.BackColor = rom.Platform.Color;
                    row.Cells["columnPlatform"].Style.ForeColor = Functions.SetFontContrast(rom.Platform.Color);
                }

                if (rom.Genre != null)
                {
                    row.Cells["columnGenre"].Value = rom.Genre.Name;
                    row.Cells["columnGenre"].Style.BackColor = rom.Genre.Color;
                    row.Cells["columnGenre"].Style.ForeColor = Functions.SetFontContrast(rom.Genre.Color);
                }

                FillLabelCell(rom, row);
                row.Tag = rom;
            }

            labelTotalRomsCount.Text = roms.Count.ToString();
            dataGridView.ResumeLayout();
        }

        private void FillEmuFilter()
        {
            updating = true;
            List<Platform> emus = Platform.GetAll().Where(x => x.ShowInFilter).ToList();
            emus.Insert(0, new Platform());
            emus.Insert(1, new Platform() { Name = "<none>" });
            comboBoxPlatform.DataSource = emus;
            comboBoxPlatform.DisplayMember = "Name";
            comboBoxPlatform.ValueMember = "Name";
            comboBoxPlatform.SelectedIndex = 0;
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

        private void FillGenreFilter()
        {
            updating = true;
            List<Genre> genres = Genre.GetAll();
            genres.Insert(0, new Genre());
            genres.Insert(1, new Genre() { Name = "<none>" });
            comboBoxGenre.DataSource = genres;
            comboBoxGenre.DisplayMember = "Name";
            comboBoxGenre.ValueMember = "Name";
            comboBoxGenre.SelectedIndex = 0;
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

        private void FillLabelCell(Rom rom, DataGridViewRow row)
        {
            row.Cells["columnLabels"].Value = "";

            if (rom.Labels.Count > 0)
            {
                foreach (RomLabel label in rom.Labels)
                {
                    row.Cells["columnLabels"].Value += " | " + label.Name;
                }

                row.Cells["columnLabels"].Value = row.Cells["columnLabels"].Value.ToString().Substring(3);
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

                if (!string.IsNullOrEmpty(Functions.GetRomPicture(rom, Values.BoxartFolder)))
                {
                    pictureBoxBoxart.Image = Functions.CreateBitmap(Functions.GetRomPicture(rom, Values.BoxartFolder));
                }

                if (!string.IsNullOrEmpty(Functions.GetRomPicture(rom, Values.TitleFolder)))
                {
                    pictureBoxTitle.Image = Functions.CreateBitmap(Functions.GetRomPicture(rom, Values.TitleFolder));
                }

                if (!string.IsNullOrEmpty(Functions.GetRomPicture(rom, Values.GameplayFolder)))
                {
                    pictureBoxGameplay.Image = Functions.CreateBitmap(Functions.GetRomPicture(rom, Values.GameplayFolder));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    row.Cells["ColumnIcon"].Value = platform.Icon;
                }

                row.Cells["columnPlatforms"].Value = platform.Name;
                row.Cells["columnPlatforms"].Style.BackColor = platform.Color;
                row.Cells["columnPlatforms"].Style.ForeColor = Functions.SetFontContrast(platform.Color);
                row.Tag = platform;
            }
        }

        private void SelectRandomRom()
        {
            if (Rom.Count() < 2) return;

            int random = new Random().Next(0, Rom.Count() - 1);
            dataGridView.CurrentCell = dataGridView.Rows[random].Cells[0];
        }

        #endregion

        private void syncRomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSyncRomData form = new FormSyncRomData();
            form.ShowDialog();

            if (form.Updated)
            {
                Rom.Fill();
                FillGenreFilter();
                FilterRoms();
                FillEmuFilter();
                FillPlatformGrid();
                FillPublisherFilter();
                FillDeveloperFilter();
                FillYearReleasedFilter();
            }
        }

    }
}
