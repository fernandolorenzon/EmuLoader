using EmuLoader.Business;
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
        List<string> missingBoxartPictures = null;
        List<string> missingTitlePictures = null;
        List<string> missingGameplayPictures = null;

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

            var boxartPictures = RomFunctions.GetRomPicturesByPlatform(comboBoxPlatform.Text, Values.BoxartFolder);
            var titlePictures = RomFunctions.GetRomPicturesByPlatform(comboBoxPlatform.Text, Values.TitleFolder);
            var gameplayPictures = RomFunctions.GetRomPicturesByPlatform(comboBoxPlatform.Text, Values.GameplayFolder);

            var romsList = Roms.Select(x => x.Name).ToList();

            missingBoxartPictures = romsList.Except(boxartPictures).ToList();
            missingTitlePictures = romsList.Except(titlePictures).ToList();
            missingGameplayPictures = romsList.Except(gameplayPictures).ToList();

            labelBoxart.Text = missingBoxartPictures.Count().ToString();
            labelTitle.Text = missingTitlePictures.Count().ToString();
            labelGameplay.Text = missingGameplayPictures.Count().ToString();
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

                    if (checkBoxRating.Checked)
                    {
                        item.Rating = 0;
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
