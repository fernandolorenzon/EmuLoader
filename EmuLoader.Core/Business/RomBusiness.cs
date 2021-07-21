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

        public static Rom SetRom(Rom rom, string id, string fileName,
            string romName, string series, string genre, string status, List<RomLabel> labels, string publisher,
            string developer, string description, string year, string dbName,
            string rating, bool idLocked, bool changeZipName,
            string boxPath, string titlePath, string gameplayPath, bool saveAsJpg, string emulator)
        {
            rom.Genre = string.IsNullOrEmpty(genre) ? null : GenreBusiness.Get(genre);

            string oldfile = rom.FileName;

            rom.Id = id;
            rom.Name = romName;
            rom.Publisher = publisher;
            rom.Developer = developer;
            rom.Description = description;
            rom.YearReleased = year;
            rom.DBName = dbName;
            rom.Series = series;
            rom.IdLocked = idLocked;
            rom.Emulator = emulator;

            float ratingParse = 0;

            if (float.TryParse(rating, out ratingParse))
            {
                if (ratingParse > 0 && ratingParse <= 10)
                {
                    rom.Rating = ratingParse;
                }
            }

            RomFunctions.RenameRomPictures(rom, fileName);
            RomFunctions.RenameRomFile(rom, fileName, changeZipName);

            if (string.IsNullOrEmpty(rom.Id))
            {
                rom.DBName = string.Empty;
            }

            if (oldfile != rom.FileName)
            {
                Set(rom, oldfile);

                if (rom.Status != null)
                {
                    RomStatusBusiness.DeleteRomStatus(rom.Status);
                    rom.Status = null;
                }

                if (rom.RomLabels != null)
                {
                    RomLabelsBusiness.DeleteRomLabels(rom.Platform.Name, oldfile);
                    rom.RomLabels = null;
                }
            }
            else
            {
                Set(rom);
            }

            RomFunctions.SaveRomPictures(rom, boxPath, titlePath, gameplayPath, saveAsJpg);
            RomLabelsBusiness.SetRomLabel(rom, labels);
            RomStatusBusiness.SetRomStatus(rom, status);
            XML.SaveXmlRoms(rom.Platform.Name);
            return rom;
        }

        public static Rom NewRom(string file, Platform platform)
        {
            var rom = new Rom();
            rom.FileName = file;
            rom.FileNameNoExt = RomFunctions.GetFileNameNoExtension(file);
            rom.Platform = platform;

            if (platform != null && platform.Id == "23")//arcade
            {
                rom.Name = RomFunctions.GetMAMENameFromCSV(RomFunctions.GetFileNameNoExtension(file));

                if (rom.Name == "")
                {
                    rom.Name = RomFunctions.GetFileNameNoExtension(file);
                }
            }
            else
            {
                rom.Name = RomFunctions.GetFileNameNoExtension(file);
            }

            return rom;
        }

        public static Rom Get(string platform, string file)
        {
            try
            {
                return RomList.FirstOrDefault(x => x.FileName.ToLower() == file.ToLower() && x.Platform.Name.ToLower() == platform.ToLower());
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
            var platformnames = Directory.GetDirectories(Values.PlatformsPath);

            if (!Directory.Exists(Values.PlatformsPath))
            {
                Directory.CreateDirectory(Values.PlatformsPath);
            }

            foreach (var platformname in platformnames)
            {
                var name = platformname.Replace(Values.PlatformsPath + "\\", "");

                var romNodes = XML.GetRomNodes(name);

                if (romNodes == null) continue;

                foreach (XmlNode node in romNodes)
                {
                    Rom rom = new Rom();
                    rom.FileName = Functions.GetXmlAttribute(node, "FileName");
                    rom.FileNameNoExt = RomFunctions.GetFileNameNoExtension(rom.FileName);
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
                    rom.Series = Functions.GetXmlAttribute(node, "Series");
                    float result = 0;

                    if (float.TryParse(Functions.GetXmlAttribute(node, "Rating"), out result))
                    {
                        rom.Rating = result;
                    }

                    rom.Status = RomStatusBusiness.Get(rom.Platform.Name, rom.FileName);
                    rom.RomLabels = RomLabelsBusiness.Get(rom.Platform.Name, rom.FileName);

                    RomList.Add(rom);
                }
            }
        }

        public static bool SetRom(Rom rom)
        {
            var ret = Set(rom);

            if (ret)
            {
                XML.SaveXmlRoms(rom.Platform.Name);
            }

            return ret;
        }

        public static bool SetRom(List<Rom> roms)
        {
            foreach (var item in roms)
            {
                Set(item);
            }

            var platforms = GetPlatforms(roms);

            foreach (var item in platforms)
            {
                XML.SaveXmlRoms(item);
            }
            
            return true;
        }

        public static List<string> GetPlatforms(List<Rom> roms)
        {
            List<string> result = new List<string>();

            foreach (var item in roms)
            {
                if (!result.Contains(item.Platform.Name))
                {
                    result.Add(item.Platform.Name);
                }
            }

            return result;
        }

        private static void CreateRomXML(string platform)
        {
            XML.CreateXmlRoms(platform);
        }

        private static bool Set(Rom rom, string oldfile = null)
        {
            if (!XML.xmlRoms.ContainsKey(rom.Platform.Name))
            {
                if (!File.Exists(Values.PlatformsPath + "\\" + rom.Platform.Name + "\\roms.xml"))
                {
                    CreateRomXML(rom.Platform.Name);
                }
            }

            XmlNode node = null;
            var xmlRoms = XML.xmlRoms[rom.Platform.Name];

            if (oldfile == null)
            {
                node = XML.GetRomNode(rom.Platform.Name, rom.FileName);
            }
            else
            {
                node = XML.GetRomNode(rom.Platform.Name, oldfile);
            }

            if (node == null)
            {
                node = SetRomNode(rom.Platform.Name);
                var parent = XML.GetParentNode(xmlRoms, "Roms");
                xmlRoms.ChildNodes[1].AppendChild(node);
                RomList.Add(rom);
            }

            Functions.CreateOrSetXmlAttribute(xmlRoms, node, "Id", rom.Id);
            Functions.CreateOrSetXmlAttribute(xmlRoms, node, "Name", rom.Name);
            Functions.CreateOrSetXmlAttribute(xmlRoms, node, "DBName", rom.DBName);
            Functions.CreateOrSetXmlAttribute(xmlRoms, node, "FileName", rom.FileName);
            Functions.CreateOrSetXmlAttribute(xmlRoms, node, "Platform", rom.Platform == null ? "" : rom.Platform.Name);
            Functions.CreateOrSetXmlAttribute(xmlRoms, node, "Genre", rom.Genre == null ? "" : rom.Genre.Name);
            Functions.CreateOrSetXmlAttribute(xmlRoms, node, "YearReleased", rom.YearReleased);
            Functions.CreateOrSetXmlAttribute(xmlRoms, node, "Publisher", rom.Publisher);
            Functions.CreateOrSetXmlAttribute(xmlRoms, node, "Developer", rom.Developer);
            Functions.CreateOrSetXmlAttribute(xmlRoms, node, "Description", rom.Description);
            Functions.CreateOrSetXmlAttribute(xmlRoms, node, "IdLocked", rom.IdLocked.ToString());
            Functions.CreateOrSetXmlAttribute(xmlRoms, node, "Rating", rom.Rating == 0 ? string.Empty : rom.Rating.ToString("#.#"));
            Functions.CreateOrSetXmlAttribute(xmlRoms, node, "Favorite", rom.Favorite.ToString());
            Functions.CreateOrSetXmlAttribute(xmlRoms, node, "Emulator", rom.Emulator);
            Functions.CreateOrSetXmlAttribute(xmlRoms, node, "Series", rom.Series);
            
            return true;
        }

        public static bool DeleteRom(List<Rom> roms)
        {
            foreach (var item in roms)
            {
                Delete(item);
            }

            var platforms = GetPlatforms(roms);

            foreach (var item in platforms)
            {
                XML.SaveXmlRoms(item);
            }

            return true;
        }

        public static bool DeleteRom(Rom rom)
        {
            var ret = Delete(rom);
            XML.SaveXmlRoms(rom.Platform.Name);
            return ret;
        }

        private static bool Delete(Rom rom)
        {
            RomList.Remove(rom);

            if (rom.Status != null)
            {
                RomStatusBusiness.DeleteRomStatus(rom.Status);
                XML.SaveXmlRomStatus();
            }

            if (rom.RomLabels != null)
            {
                RomLabelsBusiness.DeleteRomLabels(rom.Platform.Name, rom.FileName);
                XML.SaveXmlRomLabels();
            }

            return XML.DelRom(rom.Platform.Name, rom.FileName);
        }

        public static bool IsRomPack(Rom rom)
        {
            var ext = RomFunctions.GetFileExtension(rom.FileName).ToLower();

            if (ext == ".gdi" || ext == ".ccd" || ext == ".cue" || ext == ".rom")
            {
                FileInfo file = new FileInfo(rom.FileName);
                if (file.Directory.Name.ToLower() == rom.Name.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        private static XmlNode SetRomNode(string platform)
        {
            var xmlRoms = XML.xmlRoms[platform];
            XmlNode node = xmlRoms.CreateNode(XmlNodeType.Element, "Rom", "");
            node.Attributes.Append(xmlRoms.CreateAttribute("Name"));
            node.Attributes.Append(xmlRoms.CreateAttribute("DBName"));
            node.Attributes.Append(xmlRoms.CreateAttribute("FileName"));
            node.Attributes.Append(xmlRoms.CreateAttribute("Platform"));
            node.Attributes.Append(xmlRoms.CreateAttribute("Genre"));
            node.Attributes.Append(xmlRoms.CreateAttribute("YearReleased"));
            node.Attributes.Append(xmlRoms.CreateAttribute("Publisher"));
            node.Attributes.Append(xmlRoms.CreateAttribute("Developer"));
            node.Attributes.Append(xmlRoms.CreateAttribute("Description"));
            node.Attributes.Append(xmlRoms.CreateAttribute("Emulator"));
            node.Attributes.Append(xmlRoms.CreateAttribute("Series"));
            return node;
        }
    }
}
