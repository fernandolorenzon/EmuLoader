﻿using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using EmuLoader.Core.Models;

namespace EmuLoader.Gui.Forms
{
    public partial class FormBatchAddPictures : FormBase
    {
        public FormBatchAddPictures()
        {
            InitializeComponent();
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            List<Platform> emus = PlatformBusiness.GetAll();
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
                FormCustomMessage.ShowError("Directory doesn't exists");
                return;
            }

            Platform platform = (Platform)comboBoxChoosePlatform.SelectedItem;
            var images = Directory.GetFiles(textBoxDir.Text);
            var roms = RomBusiness.GetAll().Where
                (x =>
                        x.Platform != null &&
                        x.Platform.Name == platform.Name &&
                        (
                            (radioButtonBoxart.Checked && string.IsNullOrEmpty(RomFunctions.GetRomPicture(x, Values.BoxartFolder))) ||
                            (radioButtonTitle.Checked && string.IsNullOrEmpty(RomFunctions.GetRomPicture(x, Values.TitleFolder))) ||
                            (radioButtonGameplay.Checked && string.IsNullOrEmpty(RomFunctions.GetRomPicture(x, Values.GameplayFolder)))
                        )
                ).ToList();

            int successfulFind = 0;
            progressBar1.Maximum = roms.Count < images.Length ? roms.Count : images.Length;
            string type = radioButtonBoxart.Checked ? Values.BoxartFolder : radioButtonTitle.Checked ? Values.TitleFolder : Values.GameplayFolder;

            Dictionary<string, Core.Classes.Region> imageRegion = new Dictionary<string, Core.Classes.Region>();

            foreach (var item in images)
            {
                imageRegion.Add(RomFunctions.GetFileName(item), RomFunctions.DetectRegion(item));
            }

            foreach (var rom in roms)
            {
                string imageFoundPath;
                var found = RomFunctions.MatchImagesExact(images, rom.FileNameNoExt, out imageFoundPath);

                if (found)
                {
                    successfulFind++;

                    if (progressBar1.Value < progressBar1.Maximum)
                    {
                        progressBar1.Value++;
                    }

                    RomFunctions.SavePicture(rom, imageFoundPath, type, checkBoxSaveAsJpg.Checked);
                }
                else
                {
                    found = RomFunctions.MatchImages(images, imageRegion, rom.Name, out imageFoundPath);

                    if (found)
                    {
                        successfulFind++;

                        if (progressBar1.Value < progressBar1.Maximum)
                        {
                            progressBar1.Value++;
                        }

                        RomFunctions.SavePicture(rom, imageFoundPath, type, checkBoxSaveAsJpg.Checked);
                    }
                    else
                    {
                        found = RomFunctions.MatchImages(images, imageRegion, rom.FileNameNoExt, out imageFoundPath);

                        if (found)
                        {
                            successfulFind++;

                            if (progressBar1.Value < progressBar1.Maximum)
                            {
                                progressBar1.Value++;
                            }

                            RomFunctions.SavePicture(rom, imageFoundPath, type, checkBoxSaveAsJpg.Checked);
                        }
                    }
                }
            }

            progressBar1.Value = progressBar1.Maximum;
            FormCustomMessage.ShowSuccess("Number of successful rom pictures saved: " + successfulFind);
            progressBar1.Value = 0;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
