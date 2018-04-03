using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EmuLoader.Classes;
using System.IO;
using System.Diagnostics;

namespace EmuLoader.Forms
{
    public partial class FormManageRom : FormBase
    {
        #region Members

        public bool Updated = false;
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

            comboBoxPlatform.SelectedValue = SelectedRom.Platform == null ? "" : SelectedRom.Platform.Name;
            comboBoxGenre.SelectedValue = SelectedRom.Genre == null ? "" : SelectedRom.Genre.Name;

            if (!string.IsNullOrEmpty(rom.EmulatorExe) && !string.IsNullOrEmpty(rom.Command))
            {
                textBoxEmulatorExe.Text = SelectedRom.EmulatorExe;
                textBoxCommand.Text = SelectedRom.Command;
            }
            else
            {
                SelectedRom.EmulatorExe = "";
                SelectedRom.Command = "";
            }

            LoadPictures();
        }

        #endregion

        #region Events

        private void buttonSave_Click(object sender, EventArgs e)
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

            if (!string.IsNullOrEmpty(textBoxBoxartImage.Text) && File.Exists(textBoxBoxartImage.Text))
            {
                Functions.SavePicture(SelectedRom, textBoxBoxartImage.Text, Values.BoxartFolder);
            }

            if (!string.IsNullOrEmpty(textBoxTitleImage.Text) && File.Exists(textBoxTitleImage.Text))
            {
                Functions.SavePicture(SelectedRom, textBoxTitleImage.Text, Values.TitleFolder);
            }

            if (!string.IsNullOrEmpty(textBoxGameplayImage.Text) && File.Exists(textBoxGameplayImage.Text))
            {
                Functions.SavePicture(SelectedRom, textBoxGameplayImage.Text, Values.GameplayFolder);
            }

            if (!string.IsNullOrEmpty(textBoxEmulatorExe.Text) && !string.IsNullOrEmpty(textBoxCommand.Text))
            {
                SelectedRom.EmulatorExe = textBoxEmulatorExe.Text;
                SelectedRom.Command = textBoxCommand.Text;
            }
            else
            {
                SelectedRom.EmulatorExe = "";
                SelectedRom.Command = "";
            }

            Rom.Set(SelectedRom);
            XML.SaveXml();
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonFindBoxartImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            textBoxBoxartImage.Text = open.FileName;
        }

        private void buttonFindTitleImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            textBoxTitleImage.Text = open.FileName;
        }

        private void buttonFindGameplayImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            textBoxGameplayImage.Text = open.FileName;
        }

        private void buttonCopyToFile_Click(object sender, EventArgs e)
        {
            textBoxChangeFileName.Text = textBoxChangeRomName.Text + Functions.GetFileExtension(textBoxChangeFileName.Text);
        }

        private void buttonCopyToRom_Click(object sender, EventArgs e)
        {
            textBoxChangeRomName.Text = textBoxChangeFileName.Text.Replace(Functions.GetFileExtension(textBoxChangeFileName.Text), "");
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

        private void buttonOpenDB_Click(object sender, EventArgs e)
        {
            if (textBoxId.Text == string.Empty)
            {
                MessageBox.Show("TheGameDB Id is empty.");
                return;
            }

            var game = Functions.GetGameDetails(textBoxId.Text);
            game.Id = textBoxId.Text;
            FormInfo info = new FormInfo(game);
            info.Show();
        }

        private void buttonSearchInDB_Click(object sender, EventArgs e)
        {
            string url = "http://thegamesdb.net/search/?string={0}&function=Search";
            string name = textBoxChangeRomName.Text.Replace("[!]", "").Replace("!", "").Replace("&", " ").Replace(" ", "+");

            name = Functions.RemoveSubstring(name, '[', ']');
            name = Functions.RemoveSubstring(name, '(', ')');
            url = string.Format(url, name);

            ProcessStartInfo sInfo = new ProcessStartInfo(url);
            Process.Start(sInfo);
        }
    }
}