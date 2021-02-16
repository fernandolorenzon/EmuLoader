using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using EmuLoader.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
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
            var platforms = PlatformBusiness.GetAll();
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
                    FormCustomMessage.ShowError("Load the XML file first");
                    return;
                }

                if (!File.Exists(textBoxXMLPath.Text))
                {
                    FormCustomMessage.ShowError("Invalid file path");
                    return;
                }

                if (string.IsNullOrEmpty(comboBoxPlatform.Text))
                {
                    FormCustomMessage.ShowError("Choose a platform");
                    return;
                }

                XmlDocument doc = new XmlDocument();
                doc.Load(textBoxXMLPath.Text);

                var roms = RomBusiness.GetAll().Where(x => x.Platform != null && x.Platform.Name == comboBoxPlatform.Text);
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
                        foreach (XmlNode childNode in selectedNode.ChildNodes)
                        {
                            if (childNode.Name == "releasedate")
                            {
                                if (string.IsNullOrEmpty(rom.YearReleased) && !string.IsNullOrEmpty(selectedNode.InnerText) && selectedNode.InnerText.Length > 3)
                                {
                                    rom.YearReleased = childNode.InnerText.Substring(0, 4);
                                    updated = true;
                                }
                            }
                            else if (childNode.Name == "name")
                            {
                                if (string.IsNullOrEmpty(rom.DBName))
                                {
                                    rom.DBName = childNode.InnerText;
                                    updated = true;
                                }
                            }
                            else if (childNode.Name == "desc")
                            {
                                if (string.IsNullOrEmpty(rom.Description))
                                {
                                    rom.Description = childNode.InnerText;
                                    updated = true;
                                }
                            }
                            else if (childNode.Name == "publisher")
                            {
                                if (string.IsNullOrEmpty(rom.Publisher))
                                {
                                    rom.Publisher = childNode.InnerText;
                                    updated = true;
                                }
                            }
                            else if (childNode.Name == "developer")
                            {
                                if (string.IsNullOrEmpty(rom.Developer))
                                {
                                    rom.Developer = childNode.InnerText;
                                    updated = true;
                                }
                            }
                            else if (childNode.Name == "genre")
                            {
                                var genrename = childNode.InnerText;

                                if (rom.Genre == null && !string.IsNullOrEmpty(genrename))
                                {
                                    updated = true;
                                    var genre = GenreBusiness.Get(genrename);

                                    if (genre == null)
                                    {
                                        //genre = RomFunctions.CreateNewGenre(genrename);
                                    }
                                    else
                                    {
                                        rom.Genre = genre;
                                    }
                                }
                            }
                        }

                        RomBusiness.Set(rom);

                        if (updated)
                        {
                            count++;
                            Updated = true;
                        }
                    }
                }

                XML.SaveXmlRoms();
                FormCustomMessage.ShowSuccess(count + " roms updated");
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
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
                XML.SaveXmlRoms();
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
