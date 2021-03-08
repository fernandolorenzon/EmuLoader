using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using EmuLoader.Core.Models;
using System;
using System.Windows.Forms;

namespace EmuLoader.Forms
{
    public partial class FormSettings : FormSettingsBase
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            buttonSave.Click += buttonSave_Click;
            textBoxMameFolder.Text = ConfigBusiness.GetFolder(Folder.MAME);
            textBoxRetroarchFolder.Text = ConfigBusiness.GetFolder(Folder.Retroarch);
        }

        private void buttonMameFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog open = new FolderBrowserDialog();
            open.ShowDialog();

            if (string.IsNullOrEmpty(open.SelectedPath)) return;

            textBoxMameFolder.Text = open.SelectedPath;
        }

        private void buttonRetroarchFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog open = new FolderBrowserDialog();
            open.ShowDialog();

            if (string.IsNullOrEmpty(open.SelectedPath)) return;

            textBoxRetroarchFolder.Text = open.SelectedPath;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ConfigBusiness.SetFolder(Folder.Retroarch, textBoxRetroarchFolder.Text);
            ConfigBusiness.SetFolder(Folder.MAME, textBoxMameFolder.Text);
            Close();
        }
    }
}
