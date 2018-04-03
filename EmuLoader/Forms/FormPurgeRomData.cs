using EmuLoader.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmuLoader.Forms
{
    public partial class FormPurgeRomData : FormBase
    {
        List<Rom> Roms = new List<Rom>();
        string platformId;
        public bool Updated { get; set; }
        List<string> missingBoxartImages = null;
        List<string> missingTitleImages = null;
        List<string> missingGameplayImages = null;

        public FormPurgeRomData()
        {
            InitializeComponent();
        }

        private void FormPurgeRomData_Load(object sender, EventArgs e)
        {
            Updated = false;
            var platforms = Platform.GetAll();
            comboBoxPlatform.DisplayMember = "Name";
            comboBoxPlatform.ValueMember = "Id";
            comboBoxPlatform.DataSource = platforms;
        }

        private void comboBoxPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelId.Text = "-";
            labelGenre.Text = "-";
            labelPublisher.Text = "-";
            labelDeveloper.Text = "-";
            labelDescription.Text = "-";
            labelYearReleased.Text = "-";
            labelBoxart.Text = "-";
            labelTitle.Text = "-";
            labelGameplay.Text = "-";

            Roms.Clear();
            Roms.AddRange(Rom.GetAll().Where(r => r.Platform != null && r.Platform.Name == comboBoxPlatform.Text).ToList());

            labelId.Text = Roms.Where(x => string.IsNullOrEmpty(x.Id)).Count().ToString();
            labelGenre.Text = Roms.Where(x => x.Genre == null).Count().ToString();
            labelPublisher.Text = Roms.Where(x => string.IsNullOrEmpty(x.Publisher)).Count().ToString();
            labelDeveloper.Text = Roms.Where(x => string.IsNullOrEmpty(x.Developer)).Count().ToString();
            labelDescription.Text = Roms.Where(x => string.IsNullOrEmpty(x.Description)).Count().ToString();
            labelYearReleased.Text = Roms.Where(x => string.IsNullOrEmpty(x.YearReleased)).Count().ToString();

            var boxartImages = Functions.GetRomImagesByPlatform(comboBoxPlatform.Text, Values.BoxartFolder);
            var titleImages = Functions.GetRomImagesByPlatform(comboBoxPlatform.Text, Values.TitleFolder);
            var gameplayImages = Functions.GetRomImagesByPlatform(comboBoxPlatform.Text, Values.GameplayFolder);

            var romsList = Roms.Select(x => x.Name).ToList();

            missingBoxartImages = romsList.Except(boxartImages).ToList();
            missingTitleImages = romsList.Except(titleImages).ToList();
            missingGameplayImages = romsList.Except(gameplayImages).ToList();

            labelBoxart.Text = missingBoxartImages.Count().ToString();
            labelTitle.Text = missingTitleImages.Count().ToString();
            labelGameplay.Text = missingGameplayImages.Count().ToString();
        }

        private void buttonPurge_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in Roms)
                {

                    if (checkBoxId.Checked)
                    {
                        item.Id = string.Empty;
                    }

                    if (checkBoxPublisher.Checked)
                    {
                        item.Publisher = string.Empty;
                    }

                    if (checkBoxDeveloper.Checked)
                    {
                        item.Developer = string.Empty;
                    }

                    if (checkBoxDescription.Checked)
                    {
                        item.Description = string.Empty;
                    }

                    if (checkBoxDBName.Checked)
                    {
                        item.DBName = string.Empty;
                    }

                    if (checkBoxYearReleased.Checked)
                    {
                        item.YearReleased = string.Empty;
                    }

                    if (checkBoxGenre.Checked)
                    {
                        item.Genre = null;
                    }

                    Rom.Set(item);
                }

                XML.SaveXml();

                MessageBox.Show("Data purged successfully!");
                comboBoxPlatform_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Updated = true;
        }
    }
}
