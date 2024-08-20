using System;

namespace EmuLoader.Gui.Forms
{
    public partial class FormSettingsBase : FormBase
    {
        public FormSettingsBase()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Updated = false;
            Close();
        }
    }
}
