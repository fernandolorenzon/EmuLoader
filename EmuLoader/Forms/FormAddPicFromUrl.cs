using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using EmuLoader.Core.Models;
using System;
using System.Windows.Forms;

namespace EmuLoader.Forms
{
    public partial class FormAddPicFromUrl : FormBase
    {
        private Rom SelectedRom;
        private string PictureType;

        public FormAddPicFromUrl(Rom rom, string imageType)
        {
            InitializeComponent();
            SelectedRom = rom;
            PictureType = imageType;
        }

        private void buttonCopySave_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Clipboard.GetText();

                if (textBox1.Text == "")
                {
                    FormCustomMessage.ShowError("Copy a valid url with the image");
                    return;
                }

                Functions.SavePictureFromUrl(SelectedRom, textBox1.Text, PictureType, checkBoxSaveAsJpg.Checked);
                Close();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void buttonSavePicture_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    FormCustomMessage.ShowError("Paste a valid url with the image");
                    return;
                }

                Functions.SavePictureFromUrl(SelectedRom, textBox1.Text, PictureType, checkBoxSaveAsJpg.Checked);
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
