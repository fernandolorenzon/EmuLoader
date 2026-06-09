using EmuLoader.Core.Business;
using EmuLoader.Core.Models;

namespace EmuLoader.Gui.Forms
{
    public partial class FormCloneGenres : FormBase
    {
        public FormCloneGenres()
        {
            InitializeComponent();
        }

        private void FormCloneGenres_Load(object sender, EventArgs e)
        {
            List<Platform> platforms1 = PlatformBusiness.GetAll();
            platforms1.Insert(0, new Platform());
            comboBoxSource.DataSource = platforms1;
            comboBoxSource.DisplayMember = "Name";
            comboBoxSource.ValueMember = "Name";

            List<Platform> platforms2 = PlatformBusiness.GetAll();
            platforms2.Insert(0, new Platform());
            comboBoxTarget.DataSource = platforms2;
            comboBoxTarget.DisplayMember = "Name";
            comboBoxTarget.ValueMember = "Name";
        }

        private void buttonClone_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSource.Text == "") return;
                if (comboBoxTarget.Text == "") return;
                if (comboBoxSource.Text == comboBoxTarget.Text) return;

                if (GenreBusiness.CloneGenres((Platform)comboBoxSource.SelectedItem, (Platform)comboBoxTarget.SelectedItem))
                {
                    FormCustomMessage.ShowSuccess("Genres cloned successfully");
                    Updated = true;
                }
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }
    }
}
