using System;
using System.Windows.Forms;

namespace EmuLoader.Forms
{
    public partial class FormBase : Form
    {
        protected bool Updated { get; set; }

        public FormBase()
        {
            InitializeComponent();
            Updated = false;
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public bool ShowDialogUpdated()
        {
            ShowDialog();
            return Updated;
        }

    }
}
