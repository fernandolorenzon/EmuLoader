using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.IO;
using System;
using System.Net;
using EmuLoader.Core.Business;

namespace EmuLoader.Core.Classes
{
    public class Rom : Base
    {
        private static List<Rom> RomList { get; set; }
        public string Id { get; set; }
        public string DBName { get; set; }
        public string Extension { get; private set; }
        public bool IdLocked { get; set; }
        private string path;
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
                FileName = RomFunctions.GetFileName(path);
                FileNameNoExt = RomFunctions.GetFileNameNoExtension(path);
            }
        }
        public string FileName { get; private set; }
        public string FileNameNoExt { get; private set; }
        public string EmulatorExe { get; set; }
        public string Command { get; set; }
        public string YearReleased { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public bool UseAlternateEmulator { get; set; }
        public List<RomLabel> Labels;
        public Platform Platform { get; set; }
        public Genre Genre { get; set; }

        public Rom()
        {
            Labels = new List<RomLabel>();
            UseAlternateEmulator = false;
        }

        public static Rom NewRom(string path, Platform platform)
        {
            var rom = new Rom();
            rom.Path = path;
            rom.Platform = platform;

            if (platform != null && platform.Id == "23")//arcade
            {
                rom.Name = RomFunctions.GetMAMENameFromCSV(RomFunctions.GetFileNameNoExtension(path));

                if (rom.Name == "")
                {
                    rom.Name = RomFunctions.GetFileNameNoExtension(path);
                }
            }
            else
            {
                rom.Name = RomFunctions.GetFileNameNoExtension(path);
            }
            
            return rom;
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

        public static List<Rom> GetAll(Platform platform)
        {
            return (from r in RomList where r.Platform != null && r.Platform == platform orderby r.Name select r).ToList();
        }

        public static int Count()
        {
            return RomList.Count;
        }

        public static void Fill()
        {
            RomList = new List<Rom>();
            foreach (XmlNode node in XML.GetRomNodes())
            {
                Rom rom = new Rom();
                rom.Path = Functions.GetXmlAttribute(node, "Path");
                rom.Id = Functions.GetXmlAttribute(node, "Id");
                rom.Name = Functions.GetXmlAttribute(node, "Name");
                rom.DBName = Functions.GetXmlAttribute(node, "DBName");
                rom.Platform = Platform.Get(Functions.GetXmlAttribute(node, "Platform"));
                rom.Genre = Genre.Get(Functions.GetXmlAttribute(node, "Genre"));
                rom.Publisher = Functions.GetXmlAttribute(node, "Publisher");
                rom.Developer = Functions.GetXmlAttribute(node, "Developer");
                rom.YearReleased = Functions.GetXmlAttribute(node,"YearReleased");
                rom.Description = Functions.GetXmlAttribute(node, "Description");
                var idLocked = Functions.GetXmlAttribute(node, "IdLocked");
                rom.IdLocked = string.IsNullOrEmpty(idLocked) ? false : Convert.ToBoolean(idLocked);
                var useAlternate = Functions.GetXmlAttribute(node, "UseAlternateEmulator");
                rom.UseAlternateEmulator = string.IsNullOrEmpty(useAlternate) ? false : Convert.ToBoolean(useAlternate);

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
                XML.GetParentNode("Roms").AppendChild(node);
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
            Functions.CreateOrSetXmlAttribute(node, "UseAlternateEmulator", rom.UseAlternateEmulator.ToString());
            Functions.CreateOrSetXmlAttribute(node, "IdLocked", rom.IdLocked.ToString());
            Functions.CreateOrSetXmlAttribute(node, "Rating", rom.Rating == 0 ? string.Empty : rom.Rating.ToString("#.#"));

            RomFunctions.SetRomLabels(rom, node);

            return true;
        }

        public static bool Reset(string oldPath, Rom newRom)
        {
            XmlNode node = XML.GetRomNode(oldPath);

            if (node == null)
            {
                node = SetRomNode();

                node.AppendChild(XML.xmlDoc.CreateNode(XmlNodeType.Element, "Labels", ""));
                XML.GetParentNode("Roms").AppendChild(node);
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
            Functions.CreateOrSetXmlAttribute(node, "UseAlternateEmulator", newRom.UseAlternateEmulator.ToString());
            Functions.CreateOrSetXmlAttribute(node, "IdLocked", newRom.IdLocked.ToString());

            RomFunctions.SetRomLabels(newRom, node);

            return true;
        }

        public static bool Delete(Rom rom)
        {
            RomList.Remove(rom);
            return XML.DelRom(rom.Path);
        }

        public bool IsRomPack()
        {
            var ext = RomFunctions.GetFileExtension(this.Path).ToLower();

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
            node.Attributes.Append(XML.xmlDoc.CreateAttribute("UseAlternateEmulator"));
            return node;
        }
    }
}
