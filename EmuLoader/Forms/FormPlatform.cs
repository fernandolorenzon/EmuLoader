using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using EmuLoader.Classes;
using System.IO;
using EmuLoader.Business;

namespace EmuLoader.Forms
{
    public partial class FormPlatform : FormRegister
    {
        #region Members

        private bool updating = false;
        #endregion

        #region Constructors

        public FormPlatform()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void FormEmulator_Load(object sender, EventArgs e)
        {
            buttonAdd.Click += buttonAdd_Click;
            buttonDelete.Click += buttonDelete_Click;
            buttonCancel.Click += buttonCancel_Click;

            updating = true;
            dataGridView.ClearSelection();
            dataGridView.Rows.Clear();

            List<Platform> emus = Platform.GetAll();

            foreach (Platform emu in emus)
            {
                AddToGrid(emu, -1);
            }

            comboBoxPlatformsDB.ValueMember = "Key";
            comboBoxPlatformsDB.DisplayMember = "Value";
            var list = Functions.GetPlatformsXML();
            list.Insert(0, new KeyValuePair<string, string>("0", "none"));
            comboBoxPlatformsDB.DataSource = list;

            updating = false;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                buttonAdd.Enabled = false;
            }
            else
            {
                buttonAdd.Enabled = true;
            }
        }

        private void buttonPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = Environment.CurrentDirectory;

            open.Filter = "EXE | *.exe";
            open.ShowDialog();

            if (string.IsNullOrEmpty(open.FileName)) return;

            textBoxPath.Text = open.FileName;

            if (string.IsNullOrEmpty(open.FileName)) return;

            if (string.IsNullOrEmpty(textBoxCommand.Text))
            {
                textBoxCommand.Text = Values.DefaultCommand;
            }
        }


        private void buttonAlternatePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = Environment.CurrentDirectory;

            open.Filter = "EXE | *.exe";
            open.ShowDialog();

            if (string.IsNullOrEmpty(open.FileName)) return;

            textBoxAlternatePath.Text = open.FileName;

            if (string.IsNullOrEmpty(open.FileName)) return;

            if (string.IsNullOrEmpty(textBoxCommand.Text))
            {
                textBoxAlternateCommand.Text = Values.DefaultCommand;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Platform platform = null;
            int index = -1;
            updating = true;

            if (string.IsNullOrEmpty(textBoxName.Text.Trim()))
            {
                MessageBox.Show("Can not save without a valid name.");
                return;
            }

            if (textBoxName.Enabled)
            {
                if (Platform.Get(textBoxName.Text.Trim()) != null)
                {
                    MessageBox.Show("An platform with this name already exists.");
                    return;
                }

                platform = new Platform();
            }
            else
            {
                DataGridViewRow row = dataGridView.SelectedRows[0];
                index = row.Index;
                platform = (Platform)row.Tag;
                textBoxName.Enabled = true;
                buttonAdd.Text = "Add";
            }

            if(!string.IsNullOrEmpty(textBoxDefaultRomPath.Text) && string.IsNullOrEmpty(textBoxDefaultRomExtensions.Text))
            {
                MessageBox.Show("Default rom extensions must also be filled");
                return;
            }

            platform.Id = comboBoxPlatformsDB.SelectedValue.ToString();
            platform.Name = textBoxName.Text.Trim();
            platform.EmulatorExe = textBoxPath.Text.Trim();
            platform.Command = textBoxCommand.Text;
            platform.EmulatorExeAlt = textBoxAlternatePath.Text.Trim();
            platform.CommandAlt = textBoxAlternateCommand.Text;
            platform.Color = buttonColor.BackColor;
            platform.ShowInFilter = checkBoxShowInFilters.Checked;
            platform.ShowInList = checkBoxShowInLinksList.Checked;
            platform.DefaultRomPath = textBoxDefaultRomPath.Text;
            platform.DefaultRomExtensions = textBoxDefaultRomExtensions.Text;

            if (File.Exists(textBoxPlatformIcon.Text))
            {
                string platformPath = Values.PicturesPath + "\\Platforms";

                if (!Directory.Exists(platformPath))
                {
                    Directory.CreateDirectory(platformPath);
                }

                FileInfo pic = new FileInfo(textBoxPlatformIcon.Text);
                File.Delete(platformPath + "\\" + textBoxName.Text + ".bmp");
                File.Delete(platformPath + "\\" + textBoxName.Text + ".gif");
                File.Delete(platformPath + "\\" + textBoxName.Text + ".ico");
                File.Delete(platformPath + "\\" + textBoxName.Text + ".jpg");
                File.Delete(platformPath + "\\" + textBoxName.Text + ".png");

                string filename = pic.FullName.Substring(pic.FullName.LastIndexOf("\\") + 1);
                string destinationFile = platformPath + "\\" + textBoxName.Text + pic.Extension;
                pic.CopyTo(destinationFile, true);
                pic = null;
            }

            Platform.Set(platform);
            AddToGrid(platform, index);
            Updated = true;
            updating = false;
            Clean();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Updated = true;

            if (dataGridView.SelectedRows.Count < 1) return;

            Platform platform = (Platform)dataGridView.SelectedRows[0].Tag;

            if (MessageBox.Show(string.Format("Do you want do delete the platform {0} ?", platform.Name), "Warning", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

            int romCount = Rom.GetAll().Where(x => x.Platform == platform).Count();

            if (romCount > 0)
            {
                MessageBox.Show(string.Format("The platform {0} is associated with {1} roms. You cannot delete it.", platform.Name, romCount));
                return;
            }

            foreach (DataGridViewRow item in dataGridView.SelectedRows)
            {
                Platform.Delete(item.Cells[0].Value.ToString());
                dataGridView.Rows.Remove(item);
            }

            Updated = true;
            Clean();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void FormEmulator_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Updated)
            {
                XML.SaveXml();
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            pictureBoxIcon.Image = null;

            if (updating) return;

            if (dataGridView.SelectedRows.Count == 0)
            {
                buttonDelete.Enabled = false;
            }
            else
            {
                SetForm();
            }
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            try
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    buttonColor.BackColor = colorDialog1.Color;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count < 1) return;
            SetForm();
        }

        private void SetForm()
        {
            DataGridViewRow row = dataGridView.SelectedRows[0];
            Platform platform = (Platform)row.Tag;

            if (platform == null)
            {
                dataGridView.ClearSelection();
                return;
            }

            string iconPath = RomFunctions.GetPlatformPicture(((Platform)dataGridView.SelectedRows[0].Tag).Name);

            if (!string.IsNullOrEmpty(iconPath))
            {
                pictureBoxIcon.Load(iconPath);
            }

            comboBoxPlatformsDB.SelectedValue = platform.Id == "" ? "0" : platform.Id;
            textBoxName.Text = platform.Name;
            textBoxPath.Text = platform.EmulatorExe;
            textBoxCommand.Text = platform.Command;
            textBoxAlternatePath.Text = platform.EmulatorExeAlt;
            textBoxAlternateCommand.Text = platform.CommandAlt;
            buttonColor.BackColor = platform.Color;
            checkBoxShowInFilters.Checked = platform.ShowInFilter;
            checkBoxShowInLinksList.Checked = platform.ShowInList;
            textBoxDefaultRomPath.Text = platform.DefaultRomPath;
            textBoxDefaultRomExtensions.Text = platform.DefaultRomExtensions;
            textBoxName.Enabled = false;
            buttonAdd.Text = "Update";
            buttonDelete.Enabled = true;
        }

        private void buttonIconPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Pictures | *.png;*.jpg;*.ico;*.bmp;*.gif|" +
                              "All | *.*";

            open.ShowDialog();

            if (string.IsNullOrEmpty(open.FileName)) return;

            textBoxPlatformIcon.Text = open.FileName;
        }

        private void buttonDefaultRomPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog open = new FolderBrowserDialog();
            open.SelectedPath = Environment.CurrentDirectory;

            if (open.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            if (open.SelectedPath.Length == 0)
            {
                return;
            }

            textBoxDefaultRomPath.Text = open.SelectedPath;
        }

        private void textBoxEmulatorIcon_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(textBoxPlatformIcon.Text))
            {
                pictureBoxIcon.Load(textBoxPlatformIcon.Text);
            }
            else
            {
                pictureBoxIcon.Image = null;
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            Functions.ShowCommandHelp();
        }

        private void buttonSwap_Click(object sender, EventArgs e)
        {
            var aux = textBoxPath.Text;
            textBoxPath.Text = textBoxAlternatePath.Text;
            textBoxAlternatePath.Text = aux;

            aux = textBoxCommand.Text;
            textBoxCommand.Text = textBoxAlternateCommand.Text;
            textBoxAlternateCommand.Text = aux;

        }

        #endregion

        #region Methods

        private void AddToGrid(Platform platform, int index)
        {
            DataGridViewRow row = null;

            if (index < 0)
            {
                int rowId = dataGridView.Rows.Add();
                row = dataGridView.Rows[rowId];
            }
            else
            {
                row = dataGridView.Rows[index];
            }

            row.Cells["columnName"].Value = platform.Name;
            row.Cells["columnExe"].Value = platform.EmulatorExe;
            row.Cells["columnColor"].Value = platform.Color.Name;
            row.Cells["columnColor"].Style.BackColor = platform.Color;
            row.Cells["columnColor"].Style.ForeColor = Functions.SetFontContrast(platform.Color);
            row.Cells["columnShowInFilter"].Value = platform.ShowInFilter;
            row.Cells["columnShowInList"].Value = platform.ShowInList;
            row.Tag = platform;
        }

        private void Clean()
        {
            textBoxName.Text = string.Empty;
            textBoxPath.Text = string.Empty;
            textBoxCommand.Text = Values.DefaultCommand;
            buttonColor.BackColor = Color.White;
            textBoxPlatformIcon.Text = string.Empty;
            dataGridView.ClearSelection();
            comboBoxPlatformsDB.SelectedValue = "0";
            textBoxDefaultRomPath.Text = string.Empty;
            textBoxDefaultRomExtensions.Text = "zip";

            if (dataGridView.Rows.Count == 0)
            {
                textBoxName.Enabled = true;
                buttonAdd.Enabled = true;
                buttonDelete.Enabled = false;
                buttonAdd.Text = "Add";
            }
        }

        #endregion

    }
}
