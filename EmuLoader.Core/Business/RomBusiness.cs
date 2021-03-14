﻿using EmuLoader.Core.Classes;
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

            string oldpath = rom.Path;
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

            if (oldpath != rom.Path)
            {
                Set(rom, oldpath);

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
            XML.SaveXmlRoms();
            return rom;
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

        public static bool SetRom(Rom rom)
        {
            var ret = Set(rom);

            if (ret)
            {
                XML.SaveXmlRoms();
            }

            return ret;
        }

        public static bool SetRom(List<Rom> roms)
        {
            foreach (var item in roms)
            {
                Set(item);
            }

            XML.SaveXmlRoms();
            return true;
        }

        private static bool Set(Rom rom, string oldpath = null)
        {
            XmlNode node = null;

            if (oldpath == null)
            {
                node = XML.GetRomNode(rom.Path);
            }
            else
            {
                node = XML.GetRomNode(oldpath);
            }

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
            Functions.CreateOrSetXmlAttribute(XML.xmlRoms, node, "Series", rom.Series);
            
            return true;
        }

        public static bool DeleteRom(List<Rom> roms)
        {
            foreach (var item in roms)
            {
                Delete(item);
            }
            
            XML.SaveXmlRoms();
            return true;
        }

        public static bool DeleteRom(Rom rom)
        {
            var ret = Delete(rom);
            XML.SaveXmlRoms();
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
            node.Attributes.Append(XML.xmlRoms.CreateAttribute("Series"));
            return node;
        }
    }
}
