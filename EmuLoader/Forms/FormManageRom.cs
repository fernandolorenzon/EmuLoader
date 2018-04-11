using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EmuLoader.Classes;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace EmuLoader.Forms
{
    public partial class FormManageRom : FormBase
    {
        #region Members

        private Rom SelectedRom { get; set; }

        #endregion

        #region Contructors

        public FormManageRom()
        {
            InitializeComponent();
        }

        public FormManageRom(Rom rom)
            : this()
        {
            labelRom.Text = rom.Name;
            SelectedRom = rom;
            textBoxChangeFileName.Text = rom.Path.Substring(rom.Path.LastIndexOf("\\") + 1);
            textBoxChangeRomName.Text = rom.Name;
            textBoxDBName.Text = rom.DBName;
            textBoxPublisher.Text = rom.Publisher;
            textBoxDeveloper.Text = rom.Developer;
            textBoxDescription.Text = rom.Description;
            textBoxYearReleased.Text = rom.YearReleased;
            textBoxId.Text = rom.Id;
            labelPlatform.Text = rom.Platform == null ? "-" : rom.Platform.Name;

            List<RomLabel> labels = RomLabel.GetAll();

            foreach (RomLabel label in labels)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView);
                row.Cells[columnName.Index].Value = label.Name;
                row.Cells[columnColor.Index].Value = label.Color.ToArgb();
                row.Cells[columnColor.Index].Style.BackColor = label.Color;
                row.Cells[columnColor.Index].Style.ForeColor = Functions.SetFontContrast(label.Color);

                if (SelectedRom.Labels.Any(x => x.Name == label.Name))
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

            List<Platform> platforms = Platform.GetAll();
            platforms.Insert(0, new Platform());
            comboBoxPlatform.DataSource = platforms;
            comboBoxPlatform.DisplayMember = "Name";
            comboBoxPlatform.ValueMember = "Name";

            List<Genre> genres = Genre.GetAll();
            genres.Insert(0, new Genre());
            comboBoxGenre.DataSource = genres;
            comboBoxGenre.DisplayMember = "Name";
            comboBoxGenre.ValueMember = "Name";

            comboBoxPlatform.SelectedValue = SelectedRom.Platform == null ? string.Empty : SelectedRom.Platform.Name;
            comboBoxGenre.SelectedValue = SelectedRom.Genre == null ? string.Empty : SelectedRom.Genre.Name;

            if (!string.IsNullOrEmpty(rom.EmulatorExe) && !string.IsNullOrEmpty(rom.Command))
            {
                textBoxEmulatorExe.Text = SelectedRom.EmulatorExe;
                textBoxCommand.Text = SelectedRom.Command;
            }
            else
            {
                SelectedRom.EmulatorExe = string.Empty;
                SelectedRom.Command = string.Empty;
            }

            LoadPictures();
        }

        #endregion

        #region Events

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                SelectedRom.Labels.Clear();

                SelectedRom.Platform = (Platform)comboBoxPlatform.SelectedItem;
                SelectedRom.Genre = (Genre)comboBoxGenre.SelectedItem;

                SelectedRom.Publisher = textBoxPublisher.Text;
                SelectedRom.Developer = textBoxDeveloper.Text;
                SelectedRom.Description = textBoxDescription.Text;
                SelectedRom.YearReleased = textBoxYearReleased.Text;
                SelectedRom.DBName = textBoxDBName.Text;

                SelectedRom.Id = textBoxId.Text;

                if (textBoxChangeFileName.Text != SelectedRom.GetFileName())
                {
                    string oldPath = SelectedRom.Path;
                    string newPath = Functions.GetRomDirectory(SelectedRom.Path) + "\\" + textBoxChangeFileName.Text;

                    if (File.Exists(newPath))
                    {
                        MessageBox.Show("A file named \"" + newPath + "\" already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    File.Move(oldPath, newPath);
                    Rom.Delete(SelectedRom);
                    SelectedRom.Path = newPath;

                    if (checkBoxChangeZippedName.Checked && Functions.GetFileExtension(newPath) == ".zip")
                    {
                        Functions.ChangeRomNameInsideZip(newPath);
                    }
                }

                if (textBoxChangeRomName.Text != SelectedRom.Name)
                {
                    string boxpic = Functions.GetRomPicture(SelectedRom, Values.BoxartFolder);
                    string titlepic = Functions.GetRomPicture(SelectedRom, Values.TitleFolder);
                    string gameplaypic = Functions.GetRomPicture(SelectedRom, Values.GameplayFolder);

                    if (!string.IsNullOrEmpty(boxpic))
                    {
                        File.Move(boxpic, boxpic.Substring(0, boxpic.LastIndexOf("\\")) + "\\" + textBoxChangeRomName.Text + boxpic.Substring(boxpic.LastIndexOf(".")));
                    }

                    if (!string.IsNullOrEmpty(titlepic))
                    {
                        File.Move(titlepic, titlepic.Substring(0, titlepic.LastIndexOf("\\")) + "\\" + textBoxChangeRomName.Text + titlepic.Substring(titlepic.LastIndexOf(".")));
                    }

                    if (!string.IsNullOrEmpty(gameplaypic))
                    {
                        File.Move(gameplaypic, gameplaypic.Substring(0, gameplaypic.LastIndexOf("\\")) + "\\" + textBoxChangeRomName.Text + gameplaypic.Substring(gameplaypic.LastIndexOf(".")));
                    }

                    SelectedRom.Name = textBoxChangeRomName.Text;
                }

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (((CheckState)row.Cells[columnCheck.Index].Value) == CheckState.Checked)
                    {
                        RomLabel label = (RomLabel)row.Tag;
                        SelectedRom.Labels.Add((RomLabel)row.Tag);
                    }
                }

                if (!string.IsNullOrEmpty(textBoxBoxartPicture.Text) && File.Exists(textBoxBoxartPicture.Text))
                {
                    Functions.SavePicture(SelectedRom, textBoxBoxartPicture.Text, Values.BoxartFolder, checkBoxSaveAsJpg.Checked);
                }

                if (!string.IsNullOrEmpty(textBoxTitlePicture.Text) && File.Exists(textBoxTitlePicture.Text))
                {
                    Functions.SavePicture(SelectedRom, textBoxTitlePicture.Text, Values.TitleFolder, checkBoxSaveAsJpg.Checked);
                }

                if (!string.IsNullOrEmpty(textBoxGameplayPicture.Text) && File.Exists(textBoxGameplayPicture.Text))
                {
                    Functions.SavePicture(SelectedRom, textBoxGameplayPicture.Text, Values.GameplayFolder, checkBoxSaveAsJpg.Checked);
                }

                if (!string.IsNullOrEmpty(textBoxEmulatorExe.Text) && !string.IsNullOrEmpty(textBoxCommand.Text))
                {
                    SelectedRom.EmulatorExe = textBoxEmulatorExe.Text;
                    SelectedRom.Command = textBoxCommand.Text;
                }
                else
                {
                    SelectedRom.EmulatorExe = string.Empty;
                    SelectedRom.Command = string.Empty;
                }

                if (string.IsNullOrEmpty(SelectedRom.Id))
                {
                    SelectedRom.DBName = string.Empty;
                }

                Rom.Set(SelectedRom);
                XML.SaveXml();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
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
            textBoxChangeFileName.Text = textBoxChangeRomName.Text + Functions.GetFileExtension(textBoxChangeFileName.Text);
        }

        private void buttonCopyToRom_Click(object sender, EventArgs e)
        {
            textBoxChangeRomName.Text = textBoxChangeFileName.Text.Replace(Functions.GetFileExtension(textBoxChangeFileName.Text), string.Empty);
        }

        private void buttonOpenDB_Click(object sender, EventArgs e)
        {
            if (textBoxId.Text == string.Empty)
            {
                MessageBox.Show("TheGameDB Id is empty.");
                return;
            }

            var game = Functions.GetGameDetails(textBoxId.Text);
            game.Id = textBoxId.Text;
            StringBuilder text = new StringBuilder("");

            text.Append("ID" + Environment.NewLine);
            text.Append(game.Id + Environment.NewLine + Environment.NewLine);

            text.Append("NAME" + Environment.NewLine);
            text.Append(game.Name + Environment.NewLine + Environment.NewLine);

            text.Append("PUBLISHER" + Environment.NewLine);
            text.Append(game.Publisher + Environment.NewLine + Environment.NewLine);

            text.Append("DEVELOPER" + Environment.NewLine);
            text.Append(game.Developer + Environment.NewLine + Environment.NewLine);

            text.Append("DESCRIPTION" + Environment.NewLine);
            text.Append(game.Description + Environment.NewLine + Environment.NewLine);

            text.Append("YEAR RELEASED" + Environment.NewLine);
            text.Append(game.YearReleased + Environment.NewLine + Environment.NewLine);

            text.Append("GENRE" + Environment.NewLine);
            text.Append(game.Genre != null ? game.Genre.Name : "" + Environment.NewLine + Environment.NewLine);


            FormInfo info = new FormInfo(text.ToString());
            info.Show();
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            Functions.ShowCommandHelp();
        }

        private void buttonGetRomData_Click(object sender, EventArgs e)
        {
            if (textBoxId.Text == string.Empty)
            {
                MessageBox.Show("TheGameDB Id is empty.");
                return;
            }

            //string boxUrl = string.Empty;
            //string titleUrl = string.Empty;
            //string gameplayUrl = string.Empty;

            //var found = Functions.GetGameArtUrls(textBoxId.Text, out boxUrl, out titleUrl, out gameplayUrl);

            var game = Functions.GetGameDetails(textBoxId.Text);
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
            }
            else
            {
                textBoxPublisher.Text = game.Publisher;
                textBoxDeveloper.Text = game.Developer;
                textBoxDescription.Text = game.Description;
                textBoxYearReleased.Text = game.YearReleased;
            }

            if (string.IsNullOrEmpty(comboBoxGenre.SelectedText))
            {
                comboBoxGenre.SelectedValue = game.Genre;
            }
        }

        private void buttonSearchInDB_Click(object sender, EventArgs e)
        {
            string url = "http://thegamesdb.net/search/?string={0}&function=Search";
            string name = textBoxChangeRomName.Text.Replace("[!]", string.Empty).Replace("!", string.Empty).Replace("&", " ").Replace(" ", "+");

            name = Functions.RemoveSubstring(name, '[', ']');
            name = Functions.RemoveSubstring(name, '(', ')');
            url = string.Format(url, name);

            ProcessStartInfo sInfo = new ProcessStartInfo(url);
            Process.Start(sInfo);
        }

        private void buttonCopyDBName_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxDBName.Text.Trim())) return;

            int bracketindex = textBoxChangeFileName.Text.IndexOf('[');
            int parindex = textBoxChangeFileName.Text.IndexOf('(');
            int suffixIndex = 0;

            if (bracketindex > -1 && parindex == -1)
            {
                suffixIndex = bracketindex;
            }
            else if (bracketindex == -1 && parindex > -1)
            {
                suffixIndex = parindex;
            }
            else if (bracketindex > -1 && parindex > -1)
            {
                suffixIndex = bracketindex > parindex ? parindex : bracketindex;
            }

            string suffix = suffixIndex == 0 ? string.Empty : Functions.GetFileNameNoExtension(textBoxChangeFileName.Text).Substring(suffixIndex);

            textBoxChangeRomName.Text = textBoxDBName.Text.Replace(":", " -") + " " + suffix;
            textBoxChangeFileName.Text = textBoxChangeRomName.Text + Functions.GetFileExtension(textBoxChangeFileName.Text);
        }

        private void buttonCheckList_Click(object sender, EventArgs e)
        {
            if (SelectedRom.Platform == null) return;
            if (string.IsNullOrEmpty(SelectedRom.Platform.Id)) return;

            var url = "http://thegamesdb.net/api/GetPlatformGames.php?platform=" + SelectedRom.Platform.Id;
            ProcessStartInfo sInfo = new ProcessStartInfo(url);
            Process.Start(sInfo);
        }

        private void buttonPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "EXE | *.exe";
            open.ShowDialog();

            if (string.IsNullOrEmpty(open.FileName)) return;

            textBoxEmulatorExe.Text = open.FileName;

            if (string.IsNullOrEmpty(textBoxCommand.Text))
            {
                textBoxCommand.Text = Values.DefaultCommand;
            }
        }

        private void textBoxYearReleased_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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

                if (!string.IsNullOrEmpty(Functions.GetRomPicture(SelectedRom, Values.BoxartFolder)))
                {
                    pictureBoxBoxart.Image = Functions.CreateBitmap(Functions.GetRomPicture(SelectedRom, Values.BoxartFolder));
                }

                if (!string.IsNullOrEmpty(Functions.GetRomPicture(SelectedRom, Values.TitleFolder)))
                {
                    pictureBoxTitle.Image = Functions.CreateBitmap(Functions.GetRomPicture(SelectedRom, Values.TitleFolder));
                }

                if (!string.IsNullOrEmpty(Functions.GetRomPicture(SelectedRom, Values.GameplayFolder)))
                {
                    pictureBoxGameplay.Image = Functions.CreateBitmap(Functions.GetRomPicture(SelectedRom, Values.GameplayFolder));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

    }
}