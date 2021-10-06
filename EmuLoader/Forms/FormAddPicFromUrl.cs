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
                var url = GetValidURL(textBox1.Text);

                if (url == "")
                {
                    FormCustomMessage.ShowError("Paste a valid url with the image");
                    return;
                }

                Functions.SavePictureFromUrl(SelectedRom, url, PictureType, checkBoxSaveAsJpg.Checked);
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
                var url = GetValidURL(textBox1.Text);

                if (url == "")
                {
                    FormCustomMessage.ShowError("Paste a valid url with the image");
                    return;
                }

                Functions.SavePictureFromUrl(SelectedRom, url, PictureType, checkBoxSaveAsJpg.Checked);
                Close();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private string GetValidURL(string url)
        {
            if (!url.Contains(".jpg") && !url.Contains(".gif") && !url.Contains(".png") && !url.Contains(".jpeg"))
            {
                return "";
            }

            var jpg = url.LastIndexOf(".jpg");
            var jpeg = url.LastIndexOf(".jpeg");
            var gif = url.LastIndexOf(".gif");
            var png = url.LastIndexOf(".png");

            if (jpg == -1 && jpeg == -1 && gif == -1 && png == -1)
            {
                return "";
            }

            if (jpg > 0)
            {
                url = url.Substring(0, jpg + 4);
            }
            else if (jpeg > 0)
            {
                url = url.Substring(0, jpeg + 5);
            }
            else if (gif > 0)
            {
                url = url.Substring(0, gif + 4);
            }
            else if (png > 0)
            {
                url = url.Substring(0, png + 4);
            }

            return url;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
