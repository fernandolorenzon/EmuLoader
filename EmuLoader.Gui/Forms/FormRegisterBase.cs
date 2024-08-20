using System;

namespace EmuLoader.Gui.Forms
{
    public partial class FormRegisterBase : FormBase
    {
        public FormRegisterBase()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected virtual void SetForm()
        {
            buttonDelete.Enabled = true;
            buttonCancel.Enabled = true;
            buttonAdd.Text = "Update";
        }

        protected virtual void Clean()
        {
            buttonCancel.Enabled = false;
            buttonAdd.Enabled = true;
            buttonAdd.Text = "Add";
        }
    }
}
