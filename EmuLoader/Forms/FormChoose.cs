using EmuLoader.Core.Classes;
using System;
using System.Collections.Generic;

namespace EmuLoader.Forms
{
    public partial class FormChoose : FormRegister
    {
        private static FormChoose instance;
        private static Type selectedType;
        public Platform SelectedPlatform { get; set; }
        public Genre SelectedGenre { get; set; }

        private FormChoose()
        {
            InitializeComponent();
        }

        private FormChoose(Type type)
            : this()
        {
            selectedType = type;

            if (type == typeof(Platform))
            {
                List<Platform> emus = Platform.GetAll();
                emus.Insert(0, new Platform());
                comboBox.DataSource = emus;
                comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "Name";
                labelChoose.Text = "Choose Platform";
                this.Text = "Choose Platform";
                buttonCancel.Visible = false;
                buttonClose.Text = "Cancel and close";
                buttonAdd.Text = "Save and close";
            }
            else if (type == typeof(RomLabel))
            {
                List<RomLabel> labels = RomLabel.GetAll();
                labels.Insert(0, new RomLabel());
                comboBox.DataSource = labels;
                comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "Name";
                labelChoose.Text = "Choose Label";
                this.Text = "Choose Label";
                buttonCancel.Visible = false;
                buttonClose.Text = "Cancel and close";
                buttonAdd.Text = "Save and close";
            }
            else if (type == typeof(Genre))
            {
                List<Genre> genres = Genre.GetAll();
                genres.Insert(0, new Genre());
                comboBox.DataSource = genres;
                comboBox.DisplayMember = "Name";
                comboBox.ValueMember = "Name";
                labelChoose.Text = "Choose Genre";
                this.Text = "Choose Genre";
                buttonCancel.Visible = false;
                buttonClose.Text = "Cancel and close";
                buttonAdd.Text = "Save and close";
            }
        }

        private void FormChoose_Load(object sender, EventArgs e)
        {
            buttonAdd.Click += buttonOk_Click;
            buttonCancel.Click += buttonCancel_Click;
            buttonDelete.Visible = false;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (selectedType == typeof(Platform))
            {
                Platform selected = (Platform)comboBox.SelectedItem;

                if (selected.Name == string.Empty)
                {
                    SelectedPlatform = null;
                }
                else
                {
                    SelectedPlatform = selected;
                }
            }
            else if (selectedType == typeof(Genre))
            {
                Genre selected = (Genre)comboBox.SelectedItem;

                if (selected.Name == string.Empty)
                {
                    SelectedGenre = null;
                }
                else
                {
                    SelectedGenre = selected;
                }
            }

            Updated = true;
            instance.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            SelectedPlatform = null;
            Updated = false;
            instance.Close();
        }

        public static bool ChoosePlatform(out Platform selectedPlatform)
        {
            instance = new FormChoose(typeof(Platform));
            var result = instance.ShowDialogUpdated();
            selectedPlatform = instance.SelectedPlatform;
            return result;
        }

        public static bool ChooseGenre(out Genre selectedGenre)
        {
            instance = new FormChoose(typeof(Genre));
            var result = instance.ShowDialogUpdated();
            selectedGenre = instance.SelectedGenre;
            return result;
        }
    }
}
