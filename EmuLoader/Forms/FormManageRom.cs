using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using EmuLoader.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EmuLoader.Forms
{
    public partial class FormManageRom : FormSettingsBase
    {
        #region Members

        private Rom SelectedRom { get; set; }
        private string boxToDeleteIfCanceled;
        private string titleToDeleteIfCanceled;
        private string gameplayToDeleteIfCanceled;

        #endregion

        #region Contructors

        public FormManageRom()
        {
            buttonSave.Click += buttonSave_Click;
            buttonCancel.Click += buttonCancel_Click;
            InitializeComponent();
        }

        public FormManageRom(Rom rom)
            : this()
        {
            labelRom.Text = rom.Name;
            SelectedRom = rom;
            textBoxFileName.Text = rom.Path.Substring(rom.Path.LastIndexOf("\\") + 1);
            textBoxRomName.Text = rom.Name;
            textBoxDBName.Text = rom.DBName;
            textBoxPublisher.Text = rom.Publisher;
            textBoxDeveloper.Text = rom.Developer;
            textBoxDescription.Text = rom.Description;
            textBoxYearReleased.Text = rom.YearReleased;
            textBoxId.Text = rom.Id;
            labelPlatform.Text = rom.Platform == null ? "-" : rom.Platform.Name;
            textBoxRating.Text = rom.Rating != 0 ? rom.Rating.ToString("#.#") : string.Empty;
            checkBoxIdLocked.Checked = rom.IdLocked;

            if (rom.Platform.Emulators != null)
            {
                foreach (var item in rom.Platform.Emulators)
                {
                    comboBoxChooseEmulator.Items.Add(item);
                }
            }

            comboBoxChooseEmulator.ValueMember = "Name";
            comboBoxChooseEmulator.DisplayMember = "Name";
            comboBoxChooseEmulator.Items.Insert(0, new Emulator() { Name = "<default>"});

            if (rom.Emulator != "")
            {
                if (rom.Platform.Emulators.Any(x => x.Name.ToLower() == rom.Emulator.ToLower()))
                {
                    comboBoxChooseEmulator.Text = rom.Emulator;
                }
                else
                {
                    comboBoxChooseEmulator.SelectedIndex = 0;
                }
            }
            else
            {
                comboBoxChooseEmulator.SelectedIndex = 0;
            }

            List<RomLabel> labels = RomLabelBusiness.GetAll();

            foreach (RomLabel label in labels)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView);
                row.Cells[columnName.Index].Value = label.Name;
                row.Cells[columnColor.Index].Value = label.Color.ToArgb();
                row.Cells[columnColor.Index].Style.BackColor = label.Color;
                row.Cells[columnColor.Index].Style.ForeColor = Functions.SetFontContrast(label.Color);

                if (SelectedRom.RomLabels != null && SelectedRom.RomLabels.Labels.Any(x => x == label.Name))
                {
                    row.Cells[columnCheck.Index].Value = CheckState.Checked;
                }
                else
                {
                    row.Cells[columnCheck.Index].Value = CheckState.Unchecked;
                }

                row.Tag = label;
                dataGridView.Rows.Add(row);
            }

            LoadComboBoxPlatform();
            LoadComboBoxGenres();
            LoadComboBoxStatus();

            comboBoxPlatform.SelectedValue = SelectedRom.Platform == null ? string.Empty : SelectedRom.Platform.Name;
            comboBoxGenre.SelectedValue = SelectedRom.Genre == null ? string.Empty : SelectedRom.Genre.Name;
            comboBoxChooseStatus.SelectedItem = SelectedRom.Status;

            LoadPictures();
        }

        private void LoadComboBoxPlatform()
        {
            List<Platform> platforms = PlatformBusiness.GetAll();
            platforms.Insert(0, new Platform());
            comboBoxPlatform.DataSource = platforms;
            comboBoxPlatform.DisplayMember = "Name";
            comboBoxPlatform.ValueMember = "Name";
        }

        private void LoadComboBoxGenres()
        {
            List<Genre> genres = GenreBusiness.GetAll();
            genres.Insert(0, new Genre());
            comboBoxGenre.DataSource = genres;
            comboBoxGenre.DisplayMember = "Name";
            comboBoxGenre.ValueMember = "Name";
        }

        private void LoadComboBoxStatus()
        {
            var status = Values.Status.ToArray().ToList();
            status.Insert(0, "");
            comboBoxChooseStatus.DataSource = status;
        }

        #endregion

        #region Events

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<RomLabel> labels = new List<RomLabel>();

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (((CheckState)row.Cells[columnCheck.Index].Value) == CheckState.Checked)
                    {
                        RomLabel label = (RomLabel)row.Tag;
                        labels.Add(label);
                    }
                }

                var emulator = comboBoxChooseEmulator.Text;

                if (comboBoxChooseEmulator.SelectedIndex == 0)
                {
                    emulator = "";
                }

                SelectedRom = RomFunctions.SetRom(SelectedRom,
                    textBoxId.Text,
                    textBoxFileName.Text,
                    textBoxRomName.Text,
                    comboBoxPlatform.Text,
                    comboBoxGenre.Text,
                    labels,
                    textBoxPublisher.Text,
                    textBoxDeveloper.Text,
                    textBoxDescription.Text,
                    textBoxYearReleased.Text,
                    textBoxDBName.Text,
                    textBoxRating.Text,
                    checkBoxIdLocked.Checked,
                    checkBoxChangeZippedName.Checked,
                    textBoxBoxartPicture.Text,
                    textBoxTitlePicture.Text,
                    textBoxGameplayPicture.Text,
                    checkBoxSaveAsJpg.Checked,
                    emulator);

                RomBusiness.Set(SelectedRom);
                XML.SaveXmlRoms();
                Updated = true;
                Close();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(boxToDeleteIfCanceled))
            {
                File.Delete(boxToDeleteIfCanceled);
            }

            if (!string.IsNullOrEmpty(titleToDeleteIfCanceled))
            {
                File.Delete(titleToDeleteIfCanceled);
            }

            if (!string.IsNullOrEmpty(gameplayToDeleteIfCanceled))
            {
                File.Delete(gameplayToDeleteIfCanceled);
            }

            Updated = false;
            Close();
        }

        private void buttonFindBoxartPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            textBoxBoxartPicture.Text = open.FileName;
        }

        private void buttonFindTitlePicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            textBoxTitlePicture.Text = open.FileName;
        }

        private void buttonFindGameplayPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            textBoxGameplayPicture.Text = open.FileName;
        }

        private void buttonCopyToFile_Click(object sender, EventArgs e)
        {
            textBoxFileName.Text = textBoxRomName.Text.Trim() + RomFunctions.GetFileExtension(textBoxFileName.Text);
        }

        private void buttonCopyToRom_Click(object sender, EventArgs e)
        {
            textBoxRomName.Text = textBoxFileName.Text.Trim().Replace(RomFunctions.GetFileExtension(textBoxFileName.Text), string.Empty);
        }

        private void buttonOpenDB_Click(object sender, EventArgs e)
        {
            if (textBoxId.Text == string.Empty)
            {
                FormCustomMessage.ShowError("TheGameDB Id is empty.");
                return;
            }

            var access = "";
            var game = APIFunctions.GetGameDetails(textBoxId.Text, SelectedRom.Platform, out access);
            game.Id = textBoxId.Text;
            StringBuilder text = new StringBuilder("");

            text.Append("ID" + Environment.NewLine);
            text.Append(game.Id + Environment.NewLine + Environment.NewLine);

            text.Append("NAME" + Environment.NewLine);
            text.Append(game.DBName + Environment.NewLine + Environment.NewLine);

            text.Append("PLATFORM" + Environment.NewLine);
            text.Append(game.Platform.Id + " - " + game.Platform.Name + Environment.NewLine + Environment.NewLine);

            text.Append("PUBLISHER" + Environment.NewLine);
            text.Append(game.Publisher + Environment.NewLine + Environment.NewLine);

            text.Append("DEVELOPER" + Environment.NewLine);
            text.Append(game.Developer + Environment.NewLine + Environment.NewLine);

            text.Append("DESCRIPTION" + Environment.NewLine);
            text.Append(game.Description + Environment.NewLine + Environment.NewLine);

            text.Append("YEAR RELEASED" + Environment.NewLine);
            text.Append(game.YearReleased + Environment.NewLine + Environment.NewLine);

            text.Append("GENRE" + Environment.NewLine);
            text.Append(game.Genre != null ? game.Genre.Name + Environment.NewLine + Environment.NewLine : "" + Environment.NewLine + Environment.NewLine);

            text.Append("RATING" + Environment.NewLine);
            text.Append(game.Rating != 0 ? game.Rating.ToString("#.#") : "" + Environment.NewLine + Environment.NewLine);

            text.Append("remaining access to api" + Environment.NewLine);
            text.Append(access);



            FormInfo info = new FormInfo(text.ToString());
            info.Show();
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            Functions.ShowCommandHelp();
        }

        private void buttonGetRomData_Click(object sender, EventArgs e)
        {
            try
            {
                //FormWait.ShowWait(this);

                if (textBoxId.Text == string.Empty)
                {
                    textBoxId.Text = SyncDataFunctions.DiscoverGameId(SelectedRom);

                    if (string.IsNullOrEmpty(textBoxId.Text))
                    {
                        FormCustomMessage.ShowError("Could not discover TheGamesDB Id");
                        return;
                    }
                }

                var access = "";
                var game = APIFunctions.GetGameDetails(textBoxId.Text, SelectedRom.Platform, out access);

                if (game == null)
                {
                    FormCustomMessage.ShowError("Could not get rom data");
                    return;
                }

                textBoxDBName.Text = game.DBName;

                if (radioButtonOnlyMissing.Checked)
                {
                    if (string.IsNullOrEmpty(textBoxPublisher.Text))
                    {
                        textBoxPublisher.Text = game.Publisher;
                    }

                    if (string.IsNullOrEmpty(textBoxDeveloper.Text))
                    {
                        textBoxDeveloper.Text = game.Developer;
                    }

                    if (string.IsNullOrEmpty(textBoxDescription.Text))
                    {
                        textBoxDescription.Text = game.Description;
                    }

                    if (string.IsNullOrEmpty(textBoxYearReleased.Text))
                    {
                        textBoxYearReleased.Text = game.YearReleased;
                    }

                    if (string.IsNullOrEmpty(textBoxRating.Text))
                    {
                        textBoxRating.Text = game.Rating.ToString("#.#");
                    }

                    if (string.IsNullOrEmpty(comboBoxGenre.Text))
                    {
                        comboBoxGenre.SelectedValue = game.Genre != null ? game.Genre.Name : string.Empty;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(game.Publisher))
                    {
                        textBoxPublisher.Text = game.Publisher;
                    }

                    if (!string.IsNullOrEmpty(game.Developer))
                    {
                        textBoxDeveloper.Text = game.Developer;
                    }

                    if (!string.IsNullOrEmpty(game.Description))
                    {
                        textBoxDescription.Text = game.Description;
                    }

                    if (!string.IsNullOrEmpty(game.YearReleased))
                    {
                        textBoxYearReleased.Text = game.YearReleased;
                    }

                    if (game.Rating != 0)
                    {
                        textBoxRating.Text = game.Rating.ToString("#.#");
                    }
                }

                var box = RomFunctions.GetRomPicture(SelectedRom, Values.BoxartFolder);
                var title = RomFunctions.GetRomPicture(SelectedRom, Values.TitleFolder);
                var gameplay = RomFunctions.GetRomPicture(SelectedRom, Values.GameplayFolder);

                bool missingBox = string.IsNullOrEmpty(box);
                bool missingTitle = string.IsNullOrEmpty(title);
                bool missingGameplay = string.IsNullOrEmpty(gameplay);

                if (!missingBox && !missingTitle && !missingGameplay)
                {
                    //FormWait.CloseWait();
                    return;
                }

                string boxUrl = string.Empty;
                string titleUrl = string.Empty;
                string gameplayUrl = string.Empty;

                var found = APIFunctions.GetGameArtUrls(textBoxId.Text, out boxUrl, out titleUrl, out gameplayUrl, out access);

                if (!found)
                {
                    //FormWait.CloseWait();
                    return;
                }

                if (missingBox)
                {
                    Functions.SavePictureFromUrl(SelectedRom, boxUrl, Values.BoxartFolder, checkBoxSaveAsJpg.Checked);
                    boxToDeleteIfCanceled = RomFunctions.GetRomPicture(SelectedRom, Values.BoxartFolder);
                }

                if (missingTitle && !string.IsNullOrEmpty(titleUrl))
                {
                    Functions.SavePictureFromUrl(SelectedRom, titleUrl, Values.TitleFolder, checkBoxSaveAsJpg.Checked);
                    titleToDeleteIfCanceled = RomFunctions.GetRomPicture(SelectedRom, Values.TitleFolder);
                }

                if (missingGameplay && !string.IsNullOrEmpty(gameplayUrl))
                {
                    Functions.SavePictureFromUrl(SelectedRom, gameplayUrl, Values.GameplayFolder, checkBoxSaveAsJpg.Checked);
                    gameplayToDeleteIfCanceled = RomFunctions.GetRomPicture(SelectedRom, Values.GameplayFolder);
                }

                MessageBox.Show("Remaining access: " + access);
            }
            catch (Exception ex)
            {
                //FormWait.CloseWait();
                FormCustomMessage.ShowError(ex.Message);
            }
            finally
            {
                //FormWait.CloseWait();
            }
        }

        private void buttonSearchInDB_Click(object sender, EventArgs e)
        {
            string url = "https://thegamesdb.net/search.php?name={0}&platform_id%5B%5D={1}";
            string name = textBoxRomName.Text.Replace("[!]", string.Empty).Replace("!", string.Empty).Replace("&", " ").Replace(" ", "+");

            name = Functions.RemoveSubstring(name, '[', ']');
            name = Functions.RemoveSubstring(name, '(', ')');
            var platform = PlatformBusiness.GetAll().Where(x => x.Name == comboBoxPlatform.SelectedValue.ToString()).FirstOrDefault();

            if (platform != null)
            {
                url = string.Format(url, name, platform.Id);
            }
            else
            {
                url = string.Format(url, name, comboBoxPlatform.SelectedValue);
            }

            ProcessStartInfo sInfo = new ProcessStartInfo(url);
            Process.Start(sInfo);
        }

        private void buttonCopyDBName_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxDBName.Text.Trim())) return;

            string romName = "";
            string fileName = "";

            RomFunctions.CopyDBName(textBoxDBName.Text, checkBoxKeepSuffix.Checked, textBoxRomName.Text, textBoxFileName.Text, out romName, out fileName);

            textBoxRomName.Text = romName;
            textBoxFileName.Text = fileName;
        }

        private void buttonCheckList_Click(object sender, EventArgs e)
        {
            if (SelectedRom.Platform == null) return;
            if (string.IsNullOrEmpty(SelectedRom.Platform.Id)) return;

            var file = Values.JsonFolder + "\\" + SelectedRom.Platform.Name + ".json";
            string json = string.Empty;

            if (!File.Exists(file))
            {
                FormCustomMessage.ShowError("Json not found. Sync platform first");
                return;
            }

            ProcessStartInfo sInfo = new ProcessStartInfo(file);
            Process.Start(sInfo);
        }

        private void textBoxYearReleased_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonGetMAMEName_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxRomName.Text = RomFunctions.GetMAMENameFromCSV(RomFunctions.GetFileNameNoExtension(textBoxFileName.Text));
            }
            catch (Exception ex)
            {
                //FormWait.CloseWait();
                FormCustomMessage.ShowError(ex.Message);
            }
            finally
            {
                //FormWait.CloseWait();
            }
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            textBoxId.Text = "";
            textBoxDBName.Text = "";
            textBoxDescription.Text = "";
            textBoxPublisher.Text = "";
            textBoxDeveloper.Text = "";
            textBoxYearReleased.Text = "";
            textBoxRating.Text = "";

            textBoxRomName.Text = textBoxFileName.Text.Trim().Replace(RomFunctions.GetFileExtension(textBoxFileName.Text), string.Empty);
        }

        #endregion

        #region Methods

        private void LoadPictures()
        {
            try
            {
                pictureBoxBoxart.Image = null;
                pictureBoxTitle.Image = null;
                pictureBoxGameplay.Image = null;

                if (!string.IsNullOrEmpty(RomFunctions.GetRomPicture(SelectedRom, Values.BoxartFolder)))
                {
                    pictureBoxBoxart.Image = Functions.CreateBitmap(RomFunctions.GetRomPicture(SelectedRom, Values.BoxartFolder));
                }

                if (!string.IsNullOrEmpty(RomFunctions.GetRomPicture(SelectedRom, Values.TitleFolder)))
                {
                    pictureBoxTitle.Image = Functions.CreateBitmap(RomFunctions.GetRomPicture(SelectedRom, Values.TitleFolder));
                }

                if (!string.IsNullOrEmpty(RomFunctions.GetRomPicture(SelectedRom, Values.GameplayFolder)))
                {
                    pictureBoxGameplay.Image = Functions.CreateBitmap(RomFunctions.GetRomPicture(SelectedRom, Values.GameplayFolder));
                }
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        #endregion

    }
}