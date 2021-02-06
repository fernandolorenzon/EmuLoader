using EmuLoader.Core.Classes;
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
            textBoxMameFolder.Text = Config.GetFolder(Folder.MAME);
            textBoxRetroarchFolder.Text = Config.GetFolder(Folder.Retroarch);
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
            Config.SetFolder(Folder.Retroarch, textBoxRetroarchFolder.Text);
            Config.SetFolder(Folder.MAME, textBoxMameFolder.Text);
            XML.SaveXmlConfig();
            Close();
        }
    }
}
