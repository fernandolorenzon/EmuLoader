using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using EmuLoader.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace EmuLoader.Core.Business
{
    public static class RomBusiness
    {
        private static List<Rom> RomList { get; set; }

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
            var romNodes = XML.GetRomNodes();
            foreach (XmlNode node in romNodes)
            {
                Rom rom = new Rom();
                rom.Path = Functions.GetXmlAttribute(node, "Path");
                rom.Id = Functions.GetXmlAttribute(node, "Id");
                rom.Name = Functions.GetXmlAttribute(node, "Name");
                rom.DBName = Functions.GetXmlAttribute(node, "DBName");
                rom.Platform = PlatformBusiness.Get(Functions.GetXmlAttribute(node, "Platform"));
                rom.Genre = GenreBusiness.Get(Functions.GetXmlAttribute(node, "Genre"));
                rom.Publisher = Functions.GetXmlAttribute(node, "Publisher");
                rom.Developer = Functions.GetXmlAttribute(node, "Developer");
                rom.YearReleased = Functions.GetXmlAttribute(node, "YearReleased");
                rom.Description = Functions.GetXmlAttribute(node, "Description");
                var idLocked = Functions.GetXmlAttribute(node, "IdLocked");
                rom.IdLocked = string.IsNullOrEmpty(idLocked) ? false : Convert.ToBoolean(idLocked);
                var favorite = Functions.GetXmlAttribute(node, "Favorite");
                rom.Favorite = string.IsNullOrEmpty(favorite) ? false : Convert.ToBoolean(favorite);
                rom.Emulator = Functions.GetXmlAttribute(node, "Emulator");
                float result = 0;

                if (float.TryParse(Functions.GetXmlAttribute(node, "Rating"), out result))
                {
                    rom.Rating = result;
                }

                foreach (XmlNode labelNode in node.ChildNodes[0].ChildNodes)
                {
                    rom.Labels.Add(RomLabelsBusiness.Get(rom.Platform.Name, rom.FileName));
                }

                rom.Status = RomStatusBusiness.Get(rom.Platform.Name, rom.FileName);
                rom.Labels = new List<RomLabels>();

                RomList.Add(rom);
            }
        }

        public static bool Set(Rom rom)
        {
            XmlNode node = XML.GetRomNode(rom.Path);

            if (node == null)
            {
                node = SetRomNode();

                node.AppendChild(XML.xmlRoms.CreateNode(XmlNodeType.Element, "Labels", ""));
                XML.GetParentNode(XML.xmlRoms, "Roms").AppendChild(node);
                RomList.Add(rom);
            }

            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "Id", rom.Id);
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "Name", rom.Name);
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "DBName", rom.DBName);
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "Path", rom.Path);
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "Platform", rom.Platform == null ? "" : rom.Platform.Name);
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "Genre", rom.Genre == null ? "" : rom.Genre.Name);
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "YearReleased", rom.YearReleased);
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "Publisher", rom.Publisher);
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "Developer", rom.Developer);
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "Description", rom.Description);
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "IdLocked", rom.IdLocked.ToString());
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "Rating", rom.Rating == 0 ? string.Empty : rom.Rating.ToString("#.#"));
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "Favorite", rom.Favorite.ToString());
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "Emulator", rom.Emulator);

            return true;
        }

        public static bool Reset(string oldPath, Rom newRom)
        {
            XmlNode node = XML.GetRomNode(oldPath);

            if (node == null)
            {
                node = SetRomNode();

                node.AppendChild(XML.xmlRoms.CreateNode(XmlNodeType.Element, "Labels", ""));
                XML.GetParentNode(XML.xmlRoms, "Roms").AppendChild(node);
                RomList.Add(newRom);
            }

            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "Id", newRom.Id);
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "Name", newRom.Name);
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "DBName", newRom.DBName);
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "Path", newRom.Path);
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "Platform", newRom.Platform == null ? "" : newRom.Platform.Name);
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "Genre", newRom.Genre == null ? "" : newRom.Genre.Name);
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "YearReleased", newRom.YearReleased);
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "Publisher", newRom.Publisher);
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "Developer", newRom.Developer);
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "Description", newRom.Description);
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "Emulator", newRom.Emulator);
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "IdLocked", newRom.IdLocked.ToString());

            return true;
        }

        public static bool Delete(Rom rom)
        {
            RomList.Remove(rom);
            return XML.DelRom(rom.Path);
        }

        public static bool IsRomPack(Rom rom)
        {
            var ext = RomFunctions.GetFileExtension(rom.Path).ToLower();

            if (ext == ".gdi" || ext == ".ccd" || ext == ".cue" || ext == ".rom")
            {
                FileInfo file = new FileInfo(rom.Path);
                if (file.Directory.Name.ToLower() == rom.Name.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        private static XmlNode SetRomNode()
        {
            XmlNode node = XML.xmlRoms.CreateNode(XmlNodeType.Element, "Rom", "");
            node.Attributes.Append(XML.xmlRoms.CreateAttribute("Name"));
            node.Attributes.Append(XML.xmlRoms.CreateAttribute("DBName"));
            node.Attributes.Append(XML.xmlRoms.CreateAttribute("Path"));
            node.Attributes.Append(XML.xmlRoms.CreateAttribute("Platform"));
            node.Attributes.Append(XML.xmlRoms.CreateAttribute("Genre"));
            node.Attributes.Append(XML.xmlRoms.CreateAttribute("YearReleased"));
            node.Attributes.Append(XML.xmlRoms.CreateAttribute("Publisher"));
            node.Attributes.Append(XML.xmlRoms.CreateAttribute("Developer"));
            node.Attributes.Append(XML.xmlRoms.CreateAttribute("Description"));
            node.Attributes.Append(XML.xmlRoms.CreateAttribute("Emulator"));
            return node;
        }
    }
}
