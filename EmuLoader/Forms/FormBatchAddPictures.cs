using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EmuLoader.Classes;
using System.IO;

namespace EmuLoader.Forms
{
    public partial class FormBatchAddPictures : FormBase
    {
        public FormBatchAddPictures()
        {
            InitializeComponent();
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            List<Platform> emus = Platform.GetAll();
            comboBoxChoosePlatform.DataSource = emus;
            comboBoxChoosePlatform.DisplayMember = "Name";
            comboBoxChoosePlatform.ValueMember = "Name";
            comboBoxChoosePlatform.SelectedIndex = 0;
        }

        private void buttonDir_Click(object sender, EventArgs e)
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

            textBoxDir.Text = open.SelectedPath;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;

            if (!Directory.Exists(textBoxDir.Text))
            {
                MessageBox.Show("Directory doesn't exists");
                return;
            }

            Platform emu = (Platform)comboBoxChoosePlatform.SelectedItem;
            var images = Directory.GetFiles(textBoxDir.Text);
            var roms = Rom.GetAll().Where
                (x =>
                        x.Platform != null &&
                        x.Platform.Name == emu.Name &&
                        (
                            (radioButtonBoxart.Checked && string.IsNullOrEmpty(Functions.GetRomPicture(x, Values.BoxartFolder))) ||
                            (radioButtonTitle.Checked && string.IsNullOrEmpty(Functions.GetRomPicture(x, Values.TitleFolder))) ||
                            (radioButtonGameplay.Checked && string.IsNullOrEmpty(Functions.GetRomPicture(x, Values.GameplayFolder)))
                        )
                ).ToList();

            int successfulFind = 0;
            progressBar1.Maximum = roms.Count < images.Length ? roms.Count : images.Length;
            string type = radioButtonBoxart.Checked ? Values.BoxartFolder : radioButtonTitle.Checked ? Values.TitleFolder : Values.GameplayFolder;

            Dictionary<string, EmuLoader.Classes.Region> imageRegion = new Dictionary<string, Classes.Region>();

            foreach (var item in images)
            {
                imageRegion.Add(Functions.GetFileName(item), Functions.DetectRegion(item));
            }

            foreach (var rom in roms)
            {
                bool found = false;
                string romTrimmed = Functions.TrimRomName(rom.Name);

                var romRegion = Functions.DetectRegion(rom.Name);
                string imageFound = "";

                foreach (var image in images)
                {
                    string imageTrimmed = Functions.TrimRomName(image);

                    if (imageTrimmed == romTrimmed && imageRegion[Functions.GetFileName(image)] == romRegion)
                    {
                        found = true;
                        imageFound = image;
                        break;
                    }
                }

                if (!found)
                {
                    foreach (var image in images)
                    {
                        string imageTrimmed = Functions.TrimRomName(image);

                        if (imageTrimmed == romTrimmed)
                        {
                            found = true;
                            imageFound = image;
                            break;
                        }
                    }
                }

                if (found)
                {
                    progressBar1.Value++;
                    successfulFind++;
                    Functions.SavePicture(rom, imageFound, type, checkBoxSaveAsJpg.Checked);
                }
                else
                {
                    string log = "image: " + romTrimmed;
                }
            }

            progressBar1.Value = progressBar1.Maximum;
            MessageBox.Show("Number of successful rom pictures saved: " + successfulFind);
            progressBar1.Value = 0;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
