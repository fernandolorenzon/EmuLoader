using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using EmuLoader.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EmuLoader.Forms
{
    public partial class FormPlatform : FormRegisterBase
    {
        #region Members

        private bool updating = false;
        private List<Emulator> emulators;
        private string defaultEmulator;
        #endregion

        #region Constructors

        public FormPlatform()
        {
            InitializeComponent();
            emulators = new List<Emulator>();
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

            List<Platform> emus = PlatformBusiness.GetAll();

            foreach (Platform emu in emus)
            {
                AddToGrid(emu, -1);
            }

            comboBoxPlatformsDB.ValueMember = "Key";
            comboBoxPlatformsDB.DisplayMember = "Value";
            var list = Functions.GetPlatformsXML();

            var keyvalue = new List<KeyValuePair<string, string>>();

            foreach (var item in list)
            {
                keyvalue.Add(new KeyValuePair<string, string>(item.Key, item.Value));
            }

            comboBoxPlatformsDB.DataSource = keyvalue;

            updating = false;
            Clean();
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

            if (textBoxDefaultRomExtensions.Text == string.Empty)
            {
                textBoxDefaultRomExtensions.Text = "zip";
            }

            if (string.IsNullOrEmpty(textBoxCommand.Text))
            {
                textBoxCommand.Text = Values.DefaultCommand;
            }

            textBoxEmuName.Text = RomFunctions.FillEmuName(textBoxEmuName.Text, textBoxPath.Text, checkBoxUseRetroarch.Checked);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Platform platform = null;
            int index = -1;
            updating = true;

            if (string.IsNullOrEmpty(textBoxPlatformName.Text.Trim()))
            {
                FormCustomMessage.ShowError("Can not save without a valid name.");
                return;
            }

            if (textBoxPlatformName.Enabled)
            {
                if (PlatformBusiness.Get(textBoxPlatformName.Text.Trim()) != null)
                {
                    FormCustomMessage.ShowError("A platform with this name already exists.");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(textBoxDefaultRomPath.Text) && string.IsNullOrEmpty(textBoxDefaultRomExtensions.Text))
            {
                FormCustomMessage.ShowError("Default rom extensions must also be filled");
                return;
            }
            if (textBoxPlatformName.Enabled)
            {
                platform = new Platform();
            }
            else
            {
                DataGridViewRow row = dataGridView.SelectedRows[0];
                index = row.Index;
                platform = (Platform)row.Tag;
                textBoxPlatformName.Enabled = true;
                buttonAdd.Text = "Add";
            }

            platform.Id = comboBoxPlatformsDB.SelectedValue.ToString();
            platform.Name = textBoxPlatformName.Text.Trim();
            platform.Color = buttonColor.BackColor;
            platform.ShowInFilter = checkBoxShowInFilters.Checked;
            platform.ShowInList = checkBoxShowInLinksList.Checked;
            platform.DefaultRomPath = textBoxDefaultRomPath.Text;
            platform.DefaultRomExtensions = textBoxDefaultRomExtensions.Text.Replace(".", "");
            platform.UseRetroarch = checkBoxUseRetroarch.Checked;
            platform.DefaultEmulator = defaultEmulator;
            platform.Arcade = checkBoxArcade.Checked;
            platform.Console = checkBoxConsole.Checked;
            platform.Handheld = checkBoxHandheld.Checked;
            platform.CD = checkBoxCD.Checked;
            platform.Emulators = emulators;

            if (File.Exists(textBoxPlatformIcon.Text))
            {
                string platformPath = Values.PicturesPath + "\\Platforms";

                if (!Directory.Exists(platformPath))
                {
                    Directory.CreateDirectory(platformPath);
                }

                FileInfo pic = new FileInfo(textBoxPlatformIcon.Text);
                File.Delete(platformPath + "\\" + textBoxPlatformName.Text + ".gif");
                File.Delete(platformPath + "\\" + textBoxPlatformName.Text + ".jpg");
                File.Delete(platformPath + "\\" + textBoxPlatformName.Text + ".png");

                string filename = pic.FullName.Substring(pic.FullName.LastIndexOf("\\") + 1);
                string destinationFile = platformPath + "\\" + textBoxPlatformName.Text + pic.Extension;
                pic.CopyTo(destinationFile, true);
                pic = null;
            }

            PlatformBusiness.Set(platform);
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

            int romCount = RomBusiness.GetAll().Where(x => x.Platform == platform).Count();

            if (romCount > 0)
            {
                FormCustomMessage.ShowError(string.Format("The platform {0} is associated with {1} roms. You cannot delete it.", platform.Name, romCount));
                return;
            }

            foreach (DataGridViewRow item in dataGridView.SelectedRows)
            {
                PlatformBusiness.Delete(item.Cells[0].Value.ToString());
                dataGridView.Rows.Remove(item);
            }

            Updated = true;
            Clean();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Clean();
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
                Clean();
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
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void dataGridView_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count < 1) return;
            SetForm();
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
            var result = Functions.ShowCommandHelp();
            FormInfo info = new FormInfo(result);
            info.Show();
        }

        private void checkBoxUseRetroarch_Click(object sender, EventArgs e)
        {
            //buttonSelectCore.Enabled = checkBoxUseRetroarch.Checked;
            //textBoxPath.Enabled = !checkBoxUseRetroarch.Checked;
            //textBoxCommand.Enabled = !checkBoxUseRetroarch.Checked;

            if (!checkBoxUseRetroarch.Checked)
            {
                textBoxPath.Text = "";
                textBoxCommand.Text = "";
                return;
            }

            var config = ConfigBusiness.GetFolder(Folder.Retroarch);

            if (string.IsNullOrEmpty(config))
            {
                FormCustomMessage.ShowError("Retroarch folder not added. Please add on Settings menu.");
                return;
            }

            textBoxPath.Text = config + "\\" + "retroarch.exe";

            if (!File.Exists(textBoxPath.Text))
            {
                FormCustomMessage.ShowError("Retroarch exe not found");
                return;
            }

            textBoxCommand.Text = Values.RetroarchCommand;

            if (textBoxCommand.Text.Contains("[CORE]"))
            {
                buttonSelectCore_Click(sender, e);
            }
        }

        private void buttonSelectCore_Click(object sender, EventArgs e)
        {
            var config = ConfigBusiness.GetFolder(Folder.Retroarch);
            OpenFileDialog dialog = new OpenFileDialog();

            if (!string.IsNullOrEmpty(config))
            {
                config = config + "\\" + "cores";

                if (Directory.Exists(config))
                {
                    dialog.InitialDirectory = config;
                }
            }

            dialog.Filter = "Libreto Core | *.dll";
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var corename = RomFunctions.GetFileName(dialog.FileName);
                textBoxCommand.Text = Values.RetroarchCommand.Replace("[CORE]", corename);
                textBoxEmuName.Text = RomFunctions.FillEmuName(textBoxEmuName.Text, textBoxPath.Text, checkBoxUseRetroarch.Checked, corename);
            }
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
            row.Cells["columnColor"].Value = platform.Color.Name;
            row.Cells["columnColor"].Style.BackColor = platform.Color;
            row.Cells["columnColor"].Style.ForeColor = Functions.SetFontContrast(platform.Color);
            row.Cells["columnShowInFilter"].Value = platform.ShowInFilter;
            row.Cells["columnShowInList"].Value = platform.ShowInList;
            row.Tag = platform;
        }

        protected override void Clean()
        {
            base.Clean();
            textBoxPath.Enabled = true;
            textBoxCommand.Enabled = true;
            textBoxPlatformName.Text = string.Empty;
            textBoxEmuName.Text = string.Empty;
            textBoxPath.Text = string.Empty;
            textBoxCommand.Text = string.Empty;
            buttonColor.BackColor = Color.White;
            textBoxPlatformIcon.Text = string.Empty;
            //dataGridView.ClearSelection();
            dataGridViewEmulators.Rows.Clear();
            emulators = new List<Emulator>();
            comboBoxPlatformsDB.SelectedValue = "0";
            textBoxDefaultRomPath.Text = string.Empty;
            textBoxDefaultRomExtensions.Text = string.Empty;
            textBoxPlatformName.Enabled = true;
            checkBoxUseRetroarch.Checked = false;
            checkBoxArcade.Checked = false;
            checkBoxConsole.Checked = false;
            checkBoxHandheld.Checked = false;
            checkBoxCD.Checked = false;
            defaultEmulator = "";
            checkBoxUseRetroarch.CheckState = CheckState.Unchecked;
        }

        protected override void SetForm()
        {
            base.SetForm();
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
            
            checkBoxUseRetroarch.Checked = platform.UseRetroarch;
            buttonSelectCore.Enabled = platform.UseRetroarch;
            comboBoxPlatformsDB.SelectedValue = platform.Id == "" ? "0" : platform.Id;
            textBoxPlatformName.Text = platform.Name;
            buttonColor.BackColor = platform.Color;
            checkBoxShowInFilters.Checked = platform.ShowInFilter;
            checkBoxShowInLinksList.Checked = platform.ShowInList;
            textBoxDefaultRomPath.Text = platform.DefaultRomPath;
            textBoxDefaultRomExtensions.Text = platform.DefaultRomExtensions;
            defaultEmulator = platform.DefaultEmulator;
            checkBoxArcade.Checked = platform.Arcade;
            checkBoxConsole.Checked = platform.Console;
            checkBoxHandheld.Checked = platform.Handheld;
            checkBoxCD.Checked = platform.CD;
            emulators = platform.Emulators;
            dataGridViewEmulators.Rows.Clear();
            textBoxPlatformName.Enabled = false;
            FillGridEmulators();
        }

        #endregion

        private void buttonAddEmulator_Click(object sender, EventArgs e)
        {
            textBoxEmuName.Text = RomFunctions.FillEmuName(textBoxEmuName.Text, textBoxPath.Text, checkBoxUseRetroarch.Checked);

            if (textBoxEmuName.Text == "" || textBoxPath.Text == "" || textBoxCommand.Text == "")
            {
                FormCustomMessage.ShowError("Fill the name, path and command first.");
                return;
            }

            if (emulators.Any(x => x.Name.ToLower() == textBoxEmuName.Text.ToLower()))
            {
                FormCustomMessage.ShowError("There is an emulator using the name " + textBoxEmuName.Text);
                return;
            }

            emulators.Add(new Emulator() { Name = textBoxEmuName.Text, Path = textBoxPath.Text, Command = textBoxCommand.Text });
            FillGridEmulators();
            textBoxEmuName.Text = "";
            textBoxPath.Text = "";
            textBoxCommand.Text = "";
            checkBoxUseRetroarch.CheckState = CheckState.Unchecked;
        }

        private void FillGridEmulators()
        {
            Platform platform = null;

            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView.SelectedRows[0];
                platform = (Platform)row.Tag;
            }

            dataGridViewEmulators.Rows.Clear();

            foreach (var item in emulators)
            {
                int rowId = dataGridViewEmulators.Rows.Add();
                DataGridViewRow row = dataGridViewEmulators.Rows[rowId];
 
                if (platform != null && !string.IsNullOrEmpty(platform.DefaultEmulator) && platform.DefaultEmulator == item.Name)
                {
                    row.Cells["ColumnEmuDefault"].Value = "*";
                }

                row.Cells["ColumnEmuName"].Value = item.Name;
                row.Cells["ColumnEmuPath"].Value = item.Path;
                row.Cells["ColumnEmuCommand"].Value = item.Command;
            }
        }

        private void buttonMakeDefault_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmulators.SelectedRows.Count == 0)
            {
                FormCustomMessage.ShowError("Select an emulator first");
                return;
            }

            foreach (DataGridViewRow item in dataGridViewEmulators.Rows)
            {
                item.Cells["ColumnEmuDefault"].Value = "";
            }

            var row = dataGridViewEmulators.SelectedRows[0];
            row.Cells["ColumnEmuDefault"].Value = "*";
            defaultEmulator = row.Cells["ColumnEmuName"].Value.ToString();
        }

        private void buttonDeleteEmulator_Click(object sender, EventArgs e)
        {
            if (dataGridViewEmulators.SelectedRows.Count == 0)
            {
                FormCustomMessage.ShowError("Select an emulator first");
                return;
            }

            DataGridViewRow platformrow = dataGridView.SelectedRows[0];
            Platform platform = (Platform)platformrow.Tag;

            var row = dataGridViewEmulators.SelectedRows[0];
            var selected = row.Cells["ColumnEmuName"].Value.ToString();
            var emu = emulators.First(x => x.Name == selected);
            emulators.Remove(emu);

            if (emu.Name.ToLower() == platform.DefaultEmulator.ToLower())
            {
                platform.DefaultEmulator = "";
            }

            FillGridEmulators();
        }

        private void textBoxPath_Leave(object sender, EventArgs e)
        {
            if (textBoxPath.Text != "")
            {
                textBoxCommand.Text = Values.DefaultCommand;
            }
        }
    }
}
