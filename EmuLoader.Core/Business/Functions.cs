using EmuLoader.Core.Classes;
using EmuLoader.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace EmuLoader.Core.Business
{
    public static class Functions
    {
        public static void InitXml()
        {
            XML.LoadXmlConfig();
            XML.LoadXmlGenres();
            XML.LoadXmlLabels();
            XML.LoadXmlPlatforms();
            XML.LoadXmlRoms();
            XML.LoadXmlRomStatus();
            RomLabelBusiness.Fill();
            GenreBusiness.Fill();
            PlatformBusiness.Fill();
            RomStatusBusiness.Fill();
            RomBusiness.Fill();
        }

        public static void SavePictureFromUrl(Rom rom, string url, string pictureType, bool saveAsJpg)
        {
            if (url == "") return;
            string extension = url.Substring(url.LastIndexOf("."));
            string imagePath = "image" + extension;

            if (url.ToLower().Contains("https:"))
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            }

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(url), imagePath);
            }

            RomFunctions.SavePicture(rom, imagePath, pictureType, saveAsJpg);
            File.Delete(imagePath);
        }

        public static string RemoveSubstring(string text, char start, char end)
        {
            char[] textArray = text.ToCharArray();
            StringBuilder result = new StringBuilder();
            bool copy = true;

            foreach (char c in textArray)
            {
                if (c == start)
                {
                    copy = false;
                }

                if (copy)
                {
                    result.Append(c);
                }

                if (c == end)
                {
                    copy = true;
                }
            }

            return result.ToString();
        }

        public static Color SetFontContrast(Color backColor)
        {
            int total = backColor.R + backColor.G + backColor.B;
            bool dark = backColor.R < 10 || backColor.G < 10 || backColor.B < 10;

            Color color = new Color();

            if (total < Values.Threshold && dark)
            {
                color = Color.White;
            }
            else
            {
                color = Color.Black;
            }

            return color;
        }

        public static Bitmap CreateBitmap(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                using (var bmpTemp = new Bitmap(path))
                {
                    return new Bitmap(bmpTemp);
                }
            }

            return null;
        }

        public static Dictionary<string, string> GetPlatformsXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Values.PlatformsXML);

            var platforms = new List<Platform>();

            foreach (XmlNode item in doc.ChildNodes[0].ChildNodes[0].ChildNodes)
            {
                var p = new Platform() { Id = item.ChildNodes[0].InnerText, Name = item.ChildNodes[1].InnerText };
                platforms.Add(p);
            }

            var result = new Dictionary<string, string>();
            platforms = (from p in platforms orderby p.Name select p).ToList();

            result.Add("0", "none");

            foreach (var item in platforms)
            {
                result.Add(item.Id, item.Name);
            }

            return result;
        }

        public static string GetXmlAttribute(XmlNode node, string attributeName)
        {
            if (node.Attributes[attributeName] == null)
            {
                return string.Empty;
            }

            return node.Attributes[attributeName].Value;
        }

        public static void CreateOrSetXmlAttribute(XmlDocument xml, XmlNode node, string attributeName, string value)
        {
            if (node.Attributes[attributeName] == null)
            {
                node.Attributes.Append(xml.CreateAttribute(attributeName));
            }

            node.Attributes[attributeName].Value = value;
        }

        public static string ShowCommandHelp()
        {
            string text =
            "Available variables:" + Environment.NewLine + Environment.NewLine +

            "%EMUPATH% -The emulator exe -> c:\\snes\\snes9x.exe" + Environment.NewLine +
            "%ROMPATH% -The rom path and file -> c:\\snes\\roms\\Super Mario (U).zip" + Environment.NewLine +
            "%ROMNAME% -The rom display name->Super Mario(U)" + Environment.NewLine +
            "%ROMFILE% -The rom file->Super Mario(U).zip" + Environment.NewLine + Environment.NewLine +


            "Most console emulators use the standard: %EMUPATH% %ROMPATH%" + Environment.NewLine +
            "Arcade emulators use this: %EMUPATH% %ROMNAME%" + Environment.NewLine + Environment.NewLine +

            "Retroarch (change the core filename) -> %EMUPATH% -L cores\\[CORE_NAME].dll %ROMPATH%" + Environment.NewLine +
            "Snes9x/ZSnes/VBA/Gens -> %EMUPATH% %ROMPATH%" + Environment.NewLine +
            "nullDC -> %EMUPATH% -config nullDC:Emulator.Autostart=1 -config ImageReader:LoadDefaultImage=1 -config ImageReader:DefaultImage=%ROMPATH% -nogui" + Environment.NewLine +
            "Nebula -> %EMUPATH% %ROMNAME%";

            return text;
        }

        public static string LoadAPIKEY()
        {
            if (!File.Exists(Values.apikeyfile))
            {
                File.Create(Values.apikeyfile);
            }
            else
            {
                var result = File.ReadAllText(Values.apikeyfile);

                if (string.IsNullOrEmpty(result))
                {
                    throw new APIException("APIKEY not found");
                }

                return result.Trim();
            }

            return "";
        }

        public static bool BackupDB()
        {
            if (!Directory.Exists(Values.BackupFolder))
            {
                Directory.CreateDirectory(Values.BackupFolder);
            }

            var date = DateTime.Now.ToString("yyyyMMdd");
            string backupname = date + "-backup.zip";

            if (File.Exists(Values.BackupFolder + "\\" + backupname))
            {
                return true;
            }

            if (Directory.Exists(date))
            {
                Directory.Delete(date, true);
            }

            Directory.CreateDirectory(date);

            File.Copy(Values.xmlPath + "\\" + Values.xmlFileConfig, date + "\\" + Values.xmlFileConfig);
            File.Copy(Values.xmlPath + "\\" + Values.xmlFilePlatforms, date + "\\" + Values.xmlFilePlatforms);
            File.Copy(Values.xmlPath + "\\" + Values.xmlFileRoms, date + "\\" + Values.xmlFileRoms);
            File.Copy(Values.xmlPath + "\\" + Values.xmlFileGenres, date + "\\" + Values.xmlFileGenres);
            File.Copy(Values.xmlPath + "\\" + Values.xmlFileLabels, date + "\\" + Values.xmlFileLabels);
            System.IO.Compression.ZipFile.CreateFromDirectory(date, backupname);
            File.Move(backupname, Values.BackupFolder + "\\" + backupname);
            Directory.Delete(date, true);
            return true;
        }
    }
}
