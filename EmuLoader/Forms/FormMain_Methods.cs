using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using EmuLoader.Core.Models;
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
    public partial class FormMain
    {

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

        private void FilterRoms(Filter filter = null)
        {
            if (updating) return;

            FilteredRoms.Clear();
            //DateTime begin = DateTime.Now;

            if (filter == null)
            {
                filter = new Filter();
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
                filter.arcade = checkBoxArcade.Checked;
                filter.console = checkBoxConsole.Checked;
                filter.handheld = checkBoxHandheld.Checked;
                filter.cd = checkBoxCD.Checked;
                filter.rom = dataGridView.SelectedRows.Count == 0 ? "" : ((Rom)dataGridView.SelectedRows[0].Tag).Name;
            }

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
            row.Cells[columnSeries.Index].Value = rom.Series;
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

            if (rom.Status != null && !string.IsNullOrEmpty(rom.Status.Status))
            {
                row.Cells[columnStatus.Index].Value = rom.Status.Status;
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

            List<Platform> platforms = PlatformBusiness.GetAllFiltered(checkBoxArcade.Checked, checkBoxConsole.Checked, checkBoxHandheld.Checked, checkBoxCD.Checked).Where(x => x.ShowInFilter).ToList();
            platforms.Insert(0, new Platform() { Name = ""});
            platforms.Insert(1, new Platform() { Name = "<none>" });
            comboBoxPlatform.DataSource = platforms.Select(x => x.Name).ToList();

            if (string.IsNullOrEmpty(platform))
            {
                comboBoxPlatform.SelectedIndex = 0;
            }
            else
            {
                comboBoxPlatform.SelectedText = platform;
                comboBoxPlatform.Text = platform;
            }

            buttonRescan.Enabled = comboBoxPlatform.Text != string.Empty;
            updating = false;
        }

        private void FillLabelFilter()
        {
            updating = true;
            List<RomLabel> labels = RomLabelBusiness.GetAll();
            labels.Insert(0, new RomLabel());
            labels.Insert(1, new RomLabel() { Name = "<none>" });
            comboBoxLabels.DataSource = labels.Select(x => x.Name).ToList();
            comboBoxLabels.SelectedIndex = 0;
            updating = false;
        }

        private void FillGenreFilter(string genre = "")
        {
            updating = true;
            List<Genre> genres = GenreBusiness.GetAll();
            genres.Insert(0, new Genre());
            genres.Insert(1, new Genre() { Name = "<none>" });
            comboBoxGenre.DataSource = genres.Select(x => x.Name).ToList();

            if (genre == "")
            {
                comboBoxGenre.SelectedIndex = 0;
            }
            else
            {
                comboBoxGenre.Text = genre;
            }

            updating = false;
        }

        private void FillPublisherFilter()
        {
            updating = true;
            Publisher.Fill(RomBusiness.GetAll());
            List<string> publishers = Publisher.GetAll();
            publishers.Insert(0, "");
            comboBoxPublisher.DataSource = publishers;
            comboBoxPublisher.SelectedIndex = 0;
            updating = false;
        }

        private void FillDeveloperFilter()
        {
            updating = true;
            Developer.Fill(RomBusiness.GetAll());
            List<string> developers = Developer.GetAll();
            developers.Insert(0, "");
            comboBoxDeveloper.DataSource = developers;
            comboBoxDeveloper.SelectedIndex = 0;
            updating = false;
        }

        private void FillYearReleasedFilter()
        {
            updating = true;
            YearReleased.Fill(RomBusiness.GetAll());
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

            if (rom.RomLabels != null && rom.RomLabels.Labels != null && rom.RomLabels.Labels.Count > 0)
            {
                foreach (string label in rom.RomLabels.Labels)
                {
                    row.Cells[columnLabels.Index].Value += " | " + label;
                }

                var romlabel = RomLabelBusiness.Get(rom.RomLabels.Labels[0]);

                row.Cells[columnLabels.Index].Style.BackColor = romlabel.Color;
                row.Cells[columnLabels.Index].Style.ForeColor = Functions.SetFontContrast(romlabel.Color);

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
                changeGenreToolStripMenuItem.Enabled = true;
                changeLabelsToolStripMenuItem.Enabled = true;
                openFileToolStripMenuItem.Enabled = false;
            }
        }

        private void LoadComboBoxEmulators()
        {
            comboBoxEmulators.Items.Clear();
            comboBoxEmulators.Text = "";

            if (dataGridView.SelectedRows.Count == 0) return;

            Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;

            if (rom == null) return;

            if (rom.Platform.Emulators == null || rom.Platform.Emulators.Count == 0) return;

            foreach (var item in rom.Platform.Emulators)
            {
                comboBoxEmulators.Items.Add(item);
            }

            comboBoxEmulators.ValueMember = "Name";
            comboBoxEmulators.DisplayMember = "Name";

            if (!string.IsNullOrEmpty(rom.Emulator))
            {
                if (rom.Platform.Emulators.Any(x => x.Name.ToLower() == rom.Emulator.ToLower()))
                {
                    comboBoxEmulators.Text = rom.Emulator;
                }
                else
                {
                    comboBoxEmulators.SelectedIndex = 0;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(rom.Platform.DefaultEmulator) && rom.Platform.Emulators.Any(x => x.Name.ToLower() == rom.Platform.DefaultEmulator.ToLower()))
                {
                    comboBoxEmulators.Text = rom.Platform.DefaultEmulator;
                }
                else
                {
                    comboBoxEmulators.SelectedIndex = 0;
                }
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
            var emus = PlatformBusiness.GetAll().Where(x => x.ShowInList).ToList();
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