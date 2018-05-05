using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.IO;
using System;

namespace EmuLoader.Classes
{
    public class Rom : Base
    {
        private static List<Rom> RomList { get; set; }
        private string path;

        public string Id { get; set; }

        public string DBName { get; set; }

        public string Extension { get; private set; }

        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;

                if (string.IsNullOrEmpty(Name))
                {
                    Name = path.Substring(path.LastIndexOf("\\") + 1);
                    Extension = Name.Substring(Name.LastIndexOf(".") + 1);
                    Name = Name.Replace("." + Extension, "");
                }
            }
        }

        public string EmulatorExe { get; set; }

        public string Command { get; set; }

        public string YearReleased { get; set; }

        public string Developer { get; set; }

        public string Publisher { get; set; }

        public string Description { get; set; }

        public float Rating { get; set; }

        public List<RomLabel> Labels;

        public Platform Platform { get; set; }

        public Genre Genre { get; set; }

        public Rom()
        {
            Labels = new List<RomLabel>();
        }

        public Rom(string path)
        {
            Path = path;
            Labels = new List<RomLabel>();
        }

        public static Rom Get(string path)
        {
            try
            {
                return RomList.FirstOrDefault(x => x.Path.ToLower() == path.ToLower());
            }
            catch
            {
                return null;
            }
        }

        public static List<Rom> GetAll()
        {
            return (from r in RomList orderby r.Name select r).ToList();
        }
        public static int Count()
        {
            return RomList.Count;
        }

        public string GetFileName()
        {
            return this.Path.Substring(this.Path.LastIndexOf("\\") + 1);
        }

        public static void Fill()
        {
            RomList = new List<Rom>();
            foreach (XmlNode node in XML.GetRomNodes())
            {
                Rom rom = new Rom(Functions.GetXmlAttribute(node, "Path"));
                rom.Id = Functions.GetXmlAttribute(node, "Id");
                rom.Name = Functions.GetXmlAttribute(node, "Name");
                rom.DBName = Functions.GetXmlAttribute(node, "DBName");
                rom.Platform = Platform.Get(Functions.GetXmlAttribute(node, "Platform"));
                rom.Genre = Genre.Get(Functions.GetXmlAttribute(node, "Genre"));
                rom.Publisher = Functions.GetXmlAttribute(node, "Publisher");
                rom.Developer = Functions.GetXmlAttribute(node, "Developer");
                rom.YearReleased = Functions.GetXmlAttribute(node,"YearReleased");
                rom.Description = Functions.GetXmlAttribute(node, "Description");

                float result = 0;

                if (float.TryParse(Functions.GetXmlAttribute(node, "Rating"), out result))
                {
                    rom.Rating = result;
                }

                foreach (XmlNode labelNode in node.ChildNodes[0].ChildNodes)
                {
                    rom.Labels.Add(RomLabel.Get(labelNode.InnerText));
                }

                RomList.Add(rom);
            }
        }

        public static bool Set(Rom rom)
        {
            XmlNode node = XML.GetRomNode(rom.Path);

            if (node == null)
            {
                node = SetRomNode();

                node.AppendChild(XML.xmlDoc.CreateNode(XmlNodeType.Element, "Labels", ""));
                XML.GetRomParentNode().AppendChild(node);
                RomList.Add(rom);
            }

            Functions.CreateOrSetXmlAttribute(node, "Id", rom.Id);
            Functions.CreateOrSetXmlAttribute(node, "Name", rom.Name);
            Functions.CreateOrSetXmlAttribute(node, "DBName", rom.DBName);
            Functions.CreateOrSetXmlAttribute(node, "Path", rom.Path);
            Functions.CreateOrSetXmlAttribute(node, "Platform", rom.Platform == null ? "" : rom.Platform.Name);
            Functions.CreateOrSetXmlAttribute(node, "Genre", rom.Genre == null ? "" : rom.Genre.Name);
            Functions.CreateOrSetXmlAttribute(node, "EmulatorExe", rom.EmulatorExe);
            Functions.CreateOrSetXmlAttribute(node, "Command", rom.Command);
            Functions.CreateOrSetXmlAttribute(node, "YearReleased", rom.YearReleased);
            Functions.CreateOrSetXmlAttribute(node, "Publisher", rom.Publisher);
            Functions.CreateOrSetXmlAttribute(node, "Developer", rom.Developer);
            Functions.CreateOrSetXmlAttribute(node, "Description", rom.Description);
            Functions.CreateOrSetXmlAttribute(node, "Rating", rom.Rating == 0 ? string.Empty : rom.Rating.ToString("#.#"));

            SetRomLabels(rom, node);

            return true;
        }

        public static bool Reset(string oldPath, Rom newRom)
        {
            XmlNode node = XML.GetRomNode(oldPath);

            if (node == null)
            {
                node = SetRomNode();

                node.AppendChild(XML.xmlDoc.CreateNode(XmlNodeType.Element, "Labels", ""));
                XML.GetRomParentNode().AppendChild(node);
                RomList.Add(newRom);
            }

            Functions.CreateOrSetXmlAttribute(node, "Id", newRom.Id);
            Functions.CreateOrSetXmlAttribute(node, "Name", newRom.Name);
            Functions.CreateOrSetXmlAttribute(node, "DBName", newRom.DBName);
            Functions.CreateOrSetXmlAttribute(node, "Path", newRom.Path);
            Functions.CreateOrSetXmlAttribute(node, "Platform", newRom.Platform == null ? "" : newRom.Platform.Name);
            Functions.CreateOrSetXmlAttribute(node, "Genre", newRom.Genre == null ? "" : newRom.Genre.Name);
            Functions.CreateOrSetXmlAttribute(node, "EmulatorExe", newRom.EmulatorExe);
            Functions.CreateOrSetXmlAttribute(node, "Command", newRom.Command);
            Functions.CreateOrSetXmlAttribute(node, "YearReleased", newRom.YearReleased);
            Functions.CreateOrSetXmlAttribute(node, "Publisher", newRom.Publisher);
            Functions.CreateOrSetXmlAttribute(node, "Developer", newRom.Developer);
            Functions.CreateOrSetXmlAttribute(node, "Description", newRom.Description);

            SetRomLabels(newRom, node);

            return true;
        }

        public static bool Delete(Rom rom)
        {
            RomList.Remove(rom);
            return XML.DelRom(rom.Path);
        }

        public bool IsRomPack()
        {
            var ext = Functions.GetFileExtension(this.Path).ToLower();

            if (ext == ".gdi" || ext == ".ccd" || ext == ".cue" || ext == ".rom")
            {
                FileInfo file = new FileInfo(this.Path);
                if (file.Directory.Name.ToLower() == this.Name.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        private static XmlNode SetRomNode()
        {
            XmlNode node = XML.xmlDoc.CreateNode(XmlNodeType.Element, "Rom", "");
            node.Attributes.Append(XML.xmlDoc.CreateAttribute("Name"));
            node.Attributes.Append(XML.xmlDoc.CreateAttribute("DBName"));
            node.Attributes.Append(XML.xmlDoc.CreateAttribute("Path"));
            node.Attributes.Append(XML.xmlDoc.CreateAttribute("Platform"));
            node.Attributes.Append(XML.xmlDoc.CreateAttribute("Genre"));
            node.Attributes.Append(XML.xmlDoc.CreateAttribute("EmulatorExe"));
            node.Attributes.Append(XML.xmlDoc.CreateAttribute("Command"));
            node.Attributes.Append(XML.xmlDoc.CreateAttribute("YearReleased"));
            node.Attributes.Append(XML.xmlDoc.CreateAttribute("Publisher"));
            node.Attributes.Append(XML.xmlDoc.CreateAttribute("Developer"));
            node.Attributes.Append(XML.xmlDoc.CreateAttribute("Description"));
            return node;
        }

        private static void SetRomLabels(Rom rom, XmlNode node)
        {
            node.ChildNodes[0].RemoveAll();

            if (rom.Labels != null)
            {
                foreach (RomLabel label in rom.Labels)
                {
                    XmlNode labelNode = XML.xmlDoc.CreateNode(XmlNodeType.Element, "Label", "");
                    labelNode.InnerText = label.Name;
                    node.ChildNodes[0].AppendChild(labelNode);
                }
            }
        }


        public static bool AddRomsFiles(Platform platform, string[] files)
        {
            List<Rom> romList = new List<Rom>();

            foreach (var item in files)
            {
                Rom r = new Rom(item);
                Rom old = Rom.Get(r.Path);

                if (old != null)
                {
                    r = old;
                }

                r.Platform = platform;
                Rom.Set(r);
            }

            return true;
        }

        public static bool AddRomsFromDirectory(Platform platform, string directory)
        {
            List<Rom> romList = new List<Rom>();
            var files = Directory.GetFiles(directory);

            foreach (var item in files)
            {
                Rom r = new Rom(item);
                Rom old = Rom.Get(r.Path);

                if (old != null)
                {
                    r = old;
                }

                r.Platform = platform;
                Rom.Set(r);
            }

            return true;
        }

        public static bool AddRomPacksFromDirectory(Platform platform, string directory)
        {
            List<Rom> romList = new List<Rom>();
            var directories = Directory.GetDirectories(directory);

            foreach (var path in directories)
            {
                var files = Directory.GetFiles(path);

                foreach (var item in files)
                {
                    if (item.EndsWith(".cue") || item.EndsWith(".ccd") || item.EndsWith(".rom") || item.EndsWith(".gdi"))
                    {
                        Rom r = new Rom(item);
                        Rom old = Rom.Get(r.Path);

                        if (old != null)
                        {
                            r = old;
                        }

                        r.Platform = platform;
                        Rom.Set(r);
                    }
                }
            }

            return true;
        }

        public static bool ChangeRomsPlatform(List<Rom> roms, Platform platform)
        {
            foreach (var item in roms)
            {
                item.Platform = platform;
                Rom.Set(item);
            }

            return true;
        }

        public static bool ChangeRomLabels(List<Rom> roms, List<RomLabel> labels)
        {
            foreach (var item in roms)
            {
                item.Labels = labels;
                Rom.Set(item);
            }

            return true;
        }
    }
}
