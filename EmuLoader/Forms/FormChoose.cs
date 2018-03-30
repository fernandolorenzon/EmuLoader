using System;
using System.Collections.Generic;
using EmuLoader.Classes;

namespace EmuLoader.Forms
{
    public partial class FormChoose : FormBase
    {
        private static FormChoose instance;
        private static Type selectedType;
        private List<Rom> RomList;

        private FormChoose()
        {
            InitializeComponent();
        }

        private FormChoose(Type type, List<Rom> romList)
            : this()
        {
            selectedType = type;
            RomList = romList;

            if (type == typeof(Platform))
            {
                List<Platform> emus = Platform.GetAll();
                emus.Insert(0, new Platform());
                comboBox.DataSource = emus;
                comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "Name";
                labelChoose.Text += " Emulator";
                this.Text += " Emulator";
            }
            else if (type == typeof(RomLabel))
            {
                List<RomLabel> labels = RomLabel.GetAll();
                labels.Insert(0, new RomLabel());
                comboBox.DataSource = labels;
                comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "Name";
                labelChoose.Text += " Label";
                this.Text += " Label";
            }
            else if (type == typeof(Genre))
            {
                List<Genre> genres = Genre.GetAll();
                genres.Insert(0, new Genre());
                comboBox.DataSource = genres;
                comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "Name";
                labelChoose.Text += " Genre";
                this.Text += " Genre";
            }
        }

        private void FormChoose_Load(object sender, EventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (selectedType == typeof(Platform))
            {
                Platform selected = (Platform)comboBox.SelectedItem;

                if (selected.Name == "")
                {
                    selected = null;
                }

                foreach (var item in RomList)
                {
                    item.Platform = selected;
                    Rom.Set(item);
                }
            }
            else if (selectedType == typeof(Genre))
            {
                Genre selected = (Genre)comboBox.SelectedItem;

                if (selected.Name == "")
                {
                    selected = null;
                }

                foreach (var item in RomList)
                {
                    item.Genre = selected;
                    Rom.Set(item);
                }
            }

            XML.SaveXml();
            instance.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            instance.Close();
        }

        public static void ChoosePlatform(List<Rom> romList)
        {
            instance = new FormChoose(typeof(Platform), romList);
            instance.ShowDialog();
        }

        public static void ChooseGenre(List<Rom> romList)
        {
            instance = new FormChoose(typeof(Genre), romList);
            instance.ShowDialog();
        }
    }
}
