using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EmuLoader.Forms
{
    public partial class FormBatchRemovePictures : FormBase
    {
        public FormBatchRemovePictures()
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

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            Platform emu = (Platform)comboBoxChoosePlatform.SelectedItem;
            var roms = Rom.GetAll().Where
                (x =>
                        x.Platform != null &&
                        x.Platform.Name == emu.Name &&
                        (
                            (radioButtonBoxart.Checked && !string.IsNullOrEmpty(RomFunctions.GetRomPicture(x, Values.BoxartFolder))) ||
                            (radioButtonTitle.Checked && !string.IsNullOrEmpty(RomFunctions.GetRomPicture(x, Values.TitleFolder))) ||
                            (radioButtonGameplay.Checked && !string.IsNullOrEmpty(RomFunctions.GetRomPicture(x, Values.GameplayFolder)))
                        )
                ).ToList();

            int successfulFind = 0;

            string type = radioButtonBoxart.Checked ? Values.BoxartFolder : radioButtonTitle.Checked ? Values.TitleFolder : Values.GameplayFolder;

            foreach (var rom in roms)
            {
                if (type == Values.BoxartFolder)
                {

                    if (File.Exists(RomFunctions.GetRomPicture(rom, Values.BoxartFolder)))
                    {
                        File.Delete(RomFunctions.GetRomPicture(rom, Values.BoxartFolder));
                    }

                    successfulFind++;
                }
                else if (type == Values.TitleFolder)
                {
                    if (File.Exists(RomFunctions.GetRomPicture(rom, Values.TitleFolder)))
                    {
                        File.Delete(RomFunctions.GetRomPicture(rom, Values.TitleFolder));
                    }

                    successfulFind++;
                }
                else if (type == Values.GameplayFolder)
                {
                    if (File.Exists(RomFunctions.GetRomPicture(rom, Values.GameplayFolder)))
                    {
                        File.Delete(RomFunctions.GetRomPicture(rom, Values.GameplayFolder));
                    }

                    successfulFind++;
                }
            }

            FormCustomMessage.ShowSuccess("Number of successful rom pictures removed: " + successfulFind);
        }

        private void buttonRemoveUnused_Click(object sender, EventArgs e)
        {
            Platform emu = (Platform)comboBoxChoosePlatform.SelectedItem;
            var roms = Rom.GetAll().Where(x => x.Platform != null && x.Platform.Name == emu.Name).ToList();
            var path = Environment.CurrentDirectory + "\\" + Values.PicturesPath + "\\" + emu.Name + "\\";
            int successfulFind = 0;

            var images = new List<string>();

            if (radioButtonBoxart.Checked)
            {
                images = RomFunctions.GetRomPicturesByPlatformWithExt(comboBoxChoosePlatform.Text, Values.BoxartFolder);
                path += Values.BoxartFolder + "\\";
            }
            else if(radioButtonTitle.Checked)
            {
                images = RomFunctions.GetRomPicturesByPlatformWithExt(comboBoxChoosePlatform.Text, Values.TitleFolder);
                path += Values.TitleFolder + "\\";
            }
            else if (radioButtonGameplay.Checked)
            {
                images = RomFunctions.GetRomPicturesByPlatformWithExt(comboBoxChoosePlatform.Text, Values.GameplayFolder);
                path += Values.GameplayFolder + "\\";
            }

            foreach (var image in images)
            {
                if (!roms.Any(x => x.FileNameNoExt.ToLower() == RomFunctions.GetFileNameNoExtension(image).ToLower()))
                {
                    File.Delete(path + image);
                    successfulFind++;
                }
            }

            FormCustomMessage.ShowSuccess("Number of successful unused rom pictures removed: " + successfulFind);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
