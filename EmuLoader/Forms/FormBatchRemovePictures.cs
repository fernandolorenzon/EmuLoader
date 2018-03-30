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
                            (radioButtonBoxart.Checked && !string.IsNullOrEmpty(Functions.GetRomPicture(x, Values.BoxartFolder))) ||
                            (radioButtonTitle.Checked && !string.IsNullOrEmpty(Functions.GetRomPicture(x, Values.TitleFolder))) ||
                            (radioButtonGameplay.Checked && !string.IsNullOrEmpty(Functions.GetRomPicture(x, Values.GameplayFolder)))
                        )
                ).ToList();

            int successfulFind = 0;

            string type = radioButtonBoxart.Checked ? Values.BoxartFolder : radioButtonTitle.Checked ? Values.TitleFolder : Values.GameplayFolder;

            foreach (var rom in roms)
            {
                if (type == Values.BoxartFolder) {

                    if (File.Exists(Functions.GetRomPicture(rom, Values.BoxartFolder)))
                    {
                        File.Delete(Functions.GetRomPicture(rom, Values.BoxartFolder));
                    }

                    successfulFind++;
                }
                else if (type == Values.TitleFolder)
                {
                    if (File.Exists(Functions.GetRomPicture(rom, Values.TitleFolder)))
                    {
                        File.Delete(Functions.GetRomPicture(rom, Values.TitleFolder));
                    }

                    successfulFind++;
                }
                else if (type == Values.GameplayFolder)
                {
                    if (File.Exists(Functions.GetRomPicture(rom, Values.GameplayFolder)))
                    {
                        File.Delete(Functions.GetRomPicture(rom, Values.GameplayFolder));
                    }

                    successfulFind++;
                }
            }

            MessageBox.Show("Number of successful rom pictures saved: " + successfulFind);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
