using System;

namespace EmuLoader.Forms
{
    public partial class FormRegister : FormBase
    {
        public FormRegister()
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
