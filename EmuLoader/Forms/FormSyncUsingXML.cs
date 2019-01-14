using EmuLoader.Classes;
using EmuLoader.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace EmuLoader.Forms
{
    public partial class FormSyncUsingXML : FormBase
    {
        Thread threadSetOtherProperties;
        Thread threadSetIdAndYear;
        List<Rom> Roms = new List<Rom>();
        List<Rom> games = new List<Rom>();
        bool StopThread = false;
        bool ThreadStopped = false;
        string platformId;
        int syncRomsCount;
        List<Rom> notSyncedRoms = new List<Rom>();
        List<string> missingBoxartPictures = null;
        List<string> missingTitlePictures = null;
        List<string> missingGameplayPictures = null;

        public FormSyncUsingXML()
        {
            InitializeComponent();
        }

        private void FormSyncRomData_Load(object sender, EventArgs e)
        {
            Updated = false;
            var platforms = Platform.GetAll();
            comboBoxPlatform.DisplayMember = "Name";
            comboBoxPlatform.ValueMember = "Id";
            comboBoxPlatform.DataSource = platforms;
        }

        private void buttonSync_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxXMLPath.Text))
                {
                    MessageBox.Show("Load the XML file first");
                    return;
                }

                if (!File.Exists(textBoxXMLPath.Text))
                {
                    MessageBox.Show("Invalid file path");
                    return;
                }

                if (string.IsNullOrEmpty(comboBoxPlatform.Text))
                {
                    MessageBox.Show("Choose a platform");
                    return;
                }

                XmlDocument doc = new XmlDocument();
                doc.Load(textBoxXMLPath.Text);

                var roms = Rom.GetAll().Where(x => x.Platform != null && x.Platform.Name == comboBoxPlatform.Text);
                XmlNode list = doc.ChildNodes[1];

                int count = 0;

                Dictionary<string, Rom> romsDic = new Dictionary<string, Rom>();
                Dictionary<string, XmlNode> nodesDic = new Dictionary<string, XmlNode>();
                string name = "";

                foreach (var item in roms)
                {
                    name = RomFunctions.TrimRomName(item.Name);

                    if (!romsDic.ContainsKey(name))
                    {
                        romsDic.Add(name, item);
                    }
                }

                foreach (XmlNode node in list)
                {
                    name = RomFunctions.TrimRomName(node.ChildNodes[1].InnerText);

                    if (!nodesDic.ContainsKey(name))
                    {
                        nodesDic.Add(name, node);
                    }
                }

                foreach (string node in nodesDic.Keys)
                {
                    if (!romsDic.ContainsKey(node)) continue;

                    var rom = romsDic[node];
                    XmlNode selectedNode = nodesDic[node];
                    bool updated = false;

                    if (rom != null)
                    {
                        if (string.IsNullOrEmpty(rom.YearReleased) && !string.IsNullOrEmpty(selectedNode.ChildNodes[4].InnerText) && selectedNode.ChildNodes[4].InnerText.Length > 3)
                        {
                            rom.YearReleased = selectedNode.ChildNodes[4].InnerText.Substring(0, 4);
                            updated = true;
                        }

                        if (string.IsNullOrEmpty(rom.DBName))
                        {
                            rom.DBName = selectedNode.ChildNodes[1].InnerText;
                            updated = true;
                        }

                        if (string.IsNullOrEmpty(rom.Description))
                        {
                            rom.Description = selectedNode.ChildNodes[2].InnerText;
                            updated = true;
                        }

                        if (string.IsNullOrEmpty(rom.Publisher))
                        {
                            rom.Publisher = selectedNode.ChildNodes[6].InnerText;
                            updated = true;
                        }

                        if (string.IsNullOrEmpty(rom.Developer))
                        {
                            rom.Developer = selectedNode.ChildNodes[5].InnerText;
                            updated = true;
                        }

                        var genrename = selectedNode.ChildNodes[7].InnerText;

                        if (rom.Genre == null && !string.IsNullOrEmpty(genrename))
                        {
                            updated = true;
                            var genre = Genre.Get(genrename);

                            if (genre == null)
                            {
                                //genre = RomFunctions.CreateNewGenre(genrename);
                            }
                            else
                            {
                                rom.Genre = genre;
                            }
                        }

                        Rom.Set(rom);

                        if (updated)
                        {
                            count++;
                            Updated = true;
                        }
                    }
                }

                XML.SaveXml();
                MessageBox.Show(count + " roms updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            try
            {
                StopThread = true;
                Thread.Sleep(1000);
                Close();
            }
            finally
            {
                XML.SaveXml();
            }
        }

        private void buttonOpenXMLFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = Environment.CurrentDirectory;
            open.Multiselect = false;
            open.Filter = "XML File | *.xml;";
            open.Multiselect = true;

            if (open.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            if (open.FileNames.Length == 0)
            {
                return;
            }

            textBoxXMLPath.Text = open.FileName;
        }
    }
}
