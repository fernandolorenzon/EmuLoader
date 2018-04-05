using EmuLoader.Classes;
using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
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
                SaveImageFromUrl();
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
                SaveImageFromUrl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveImageFromUrl()
        {
            string extension = textBox1.Text.Substring(textBox1.Text.LastIndexOf("."));
            string imagePath = "image" + extension;

            if (textBox1.Text.ToLower().Contains("https:"))
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            }

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(textBox1.Text), imagePath);
            }

            Functions.SavePicture(SelectedRom, imagePath, ImageType, checkBoxSaveAsJpg.Checked);
            File.Delete(imagePath);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
