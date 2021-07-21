using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using EmuLoader.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace EmuLoader.Forms
{
    public partial class FormAudit : FormBase
    {
        public FormAudit()
        {
            InitializeComponent();

            List<Platform> platforms = PlatformBusiness.GetAll();
            platforms.Insert(0, new Platform());
            comboBoxPlatform.DataSource = platforms;
            comboBoxPlatform.DisplayMember = "Name";
            comboBoxPlatform.ValueMember = "Name";
        }

        private void buttonCleanIncorrectRomPlatform_Click(object sender, EventArgs e)
        {
            if (comboBoxPlatform.Text == "" || comboBoxPlatform.Text == "none")
            {
                FormCustomMessage.ShowError("Select a platform");
            }

            var json = RomFunctions.GetPlatformJson(comboBoxPlatform.Text);

            if (json == "") return;

            var roms = RomBusiness.GetAll(PlatformBusiness.Get(comboBoxPlatform.Text));
            int count = 0;
            List<Rom> romsUpdate = new List<Rom>();

            foreach (var rom in roms)
            {
                if (string.IsNullOrEmpty(rom.Id))
                {
                    continue;
                }

                if (!json.Contains("\"id\": " + rom.Id + ","))
                {
                    rom.Id = "";
                    rom.Name = rom.FileNameNoExt;
                    rom.DBName = "";
                    rom.Description = "";
                    rom.IdLocked = false;
                    rom.Publisher = "";
                    rom.YearReleased = "";
                    rom.Developer = "";
                    rom.Rating = 0;

                    romsUpdate.Add(rom);

                    count++;
                    Updated = true;
                }
            }

            RomBusiness.SetRom(romsUpdate);

            FormCustomMessage.ShowSuccess("Roms updated successfully! " + count.ToString() + " roms cleaned");
        }

        private void buttonUpdateAllRomsNames_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxPlatform.Text == "" || comboBoxPlatform.Text == "none")
                {
                    FormCustomMessage.ShowError("Select a platform");
                }

                Platform platform = PlatformBusiness.Get(comboBoxPlatform.Text);
                var roms = RomBusiness.GetAll(platform);
                int count = 0;
                List<Rom> romsUpdate = new List<Rom>();

                foreach (var rom in roms)
                {
                    var name = RomFunctions.GetMAMENameFromCSV(rom.FileNameNoExt);

                    if (name == "") continue;

                    if (rom.Name != name)
                    {
                        rom.Name = name;
                        romsUpdate.Add(rom);
                        count++;
                    }
                }

                RomBusiness.SetRom(romsUpdate);
                FormCustomMessage.ShowSuccess("Rom names updated successfully! Total:" + count.ToString());
                Updated = true;
            }
            catch (Exception ex)
            {
                //FormWait.CloseWait();
                FormCustomMessage.ShowError(ex.Message);
            }
            finally
            {
                //FormWait.CloseWait();
            }
        }

        private void buttonUpdateNameFromDBName_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxPlatform.Text == "" || comboBoxPlatform.Text == "none")
                {
                    FormCustomMessage.ShowError("Select a platform");
                }

                Platform platform = PlatformBusiness.Get(comboBoxPlatform.Text);
                var roms = RomBusiness.GetAll(platform);
                int count = 0;
                List<Rom> romsUpdate = new List<Rom>();

                foreach (var rom in roms)
                {
                    if (!string.IsNullOrEmpty(rom.DBName))
                    {
                        var newname = rom.DBName.Replace(":", " -");

                        if (rom.Name != newname)
                        {
                            rom.Name = newname;
                            romsUpdate.Add(rom);
                            count++;
                        }
                    }
                }

                RomBusiness.SetRom(romsUpdate);
                FormCustomMessage.ShowSuccess("Rom names updated successfully! Total:" + count.ToString());
                Updated = true;
            }
            catch (Exception ex)
            {
                //FormWait.CloseWait();
                FormCustomMessage.ShowError(ex.Message);
            }
            finally
            {
                //FormWait.CloseWait();
            }
        }

        private void buttonShowMissingRoms_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxPlatform.Text == "" || comboBoxPlatform.Text == "none")
                {
                    FormCustomMessage.ShowError("Select a platform");
                }

                Platform platform = PlatformBusiness.Get(comboBoxPlatform.Text);
                var json = RomFunctions.GetPlatformJson(comboBoxPlatform.Text);

                if (string.IsNullOrEmpty(json))
                {
                    FormCustomMessage.ShowError("Json not found. Sync platform first");
                }

                var games = APIFunctions.GetGamesListByPlatform(platform.Id, json, platform.Name);
                var roms = RomBusiness.GetAll(platform);

                StringBuilder builder = new StringBuilder("");

                foreach (var game in games)
                {
                    if (!roms.Any(x => x.Id == game.Id))
                    {
                        builder.Append(game.Id + "-" + game.DBName + Environment.NewLine);
                    }
                }

                FormInfo info = new FormInfo(builder.ToString());
                info.Show();

                Updated = true;
            }
            catch (Exception ex)
            {
                //FormWait.CloseWait();
                FormCustomMessage.ShowError(ex.Message);
            }
            finally
            {
                //FormWait.CloseWait();
            }
        }

        private void buttonConvertPlatformsXML_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "XML|*.xml";
            var result = dialog.ShowDialog();

            if (result != DialogResult.OK) return;

            XmlDocument doc = new XmlDocument();
            doc.Load(dialog.FileName);

            foreach (XmlNode item in doc.ChildNodes[1].ChildNodes[0].ChildNodes)
            {
                var dir = Environment.CurrentDirectory + "\\dump\\" + item.Attributes["Name"].Value;
                var path = dir + "\\config.xml";

                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine;
                xml += item.OuterXml;

                File.WriteAllText(path, xml);
            }
        }

        private void buttonConvertRomsXML_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "XML|roms.xml";
            var result = dialog.ShowDialog();

            if (result != DialogResult.OK) return;

            XmlDocument doc = new XmlDocument();
            doc.Load(dialog.FileName);

            Dictionary<string, StringBuilder> dic = new Dictionary<string, StringBuilder>();

            foreach (XmlNode item in doc.ChildNodes[1].ChildNodes[0].ChildNodes)
            {
                var platform = item.Attributes["Platform"].Value;

                if (!dic.ContainsKey(platform))
                {
                    StringBuilder sb = new StringBuilder("<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine);
                    sb.Append("<Roms>" + Environment.NewLine);
                    dic.Add(platform, sb);
                }

                dic[platform].Append(item.OuterXml + Environment.NewLine);
            }

            foreach (var item in dic.Keys)
            {
                var dir = Environment.CurrentDirectory + "\\dump\\" + item;
                var path = dir + "\\roms.xml";

                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                dic[item].Append("</Roms>" + Environment.NewLine);

                File.WriteAllText(path, dic[item].ToString());
            }
        }

        private void buttonChangePath_Click(object sender, EventArgs e)
        {
            var dir = Environment.CurrentDirectory + "\\" + Values.PlatformsPath;
            var dirs = Directory.GetDirectories(dir);

            foreach (var item in dirs)
            {
                var platformname = item.Substring(item.LastIndexOf("\\") + 1);
                var platform = PlatformBusiness.Get(platformname);

                var file = item + "\\roms.xml";
                
                if (!File.Exists(file)) continue;

                var text = File.ReadAllText(file);
                text = text.Replace("Path=", "FileName=");
                text = text.Replace(platform.DefaultRomPath + "\\", "");

                File.WriteAllText(file, text);
            }
        }
    }
}
