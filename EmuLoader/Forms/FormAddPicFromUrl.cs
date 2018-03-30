using EmuLoader.Classes;
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace EmuLoader.Forms
{
    public partial class FormAddPicFromUrl : FormBase
    {
        private Rom SelectedRom;
        private string ImageType;

        public FormAddPicFromUrl(Rom rom, string imageType)
        {
            InitializeComponent();
            SelectedRom = rom;
            ImageType = imageType;
        }

        private void buttonCopySave_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = Clipboard.GetText();
                string extension = textBox1.Text.Substring(textBox1.Text.LastIndexOf("."));
                string imagePath = "image" + extension;

                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(new Uri(textBox1.Text), imagePath);
                }

                Functions.SavePicture(SelectedRom, imagePath, ImageType);
                File.Delete(imagePath);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSaveImage_Click(object sender, EventArgs e)
        {
            try
            {
                string extension = textBox1.Text.Substring(textBox1.Text.LastIndexOf("."));
                string imagePath = "image" + extension;

                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(new Uri(textBox1.Text), imagePath);
                }

                Functions.SavePicture(SelectedRom, imagePath, ImageType);
                File.Delete(imagePath);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
