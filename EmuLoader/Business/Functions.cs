﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using EmuLoader.Forms;
using EmuLoader.Classes;
using System.IO;

namespace EmuLoader.Business
{
    public static class Functions
    {
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

        public static List<KeyValuePair<string, string>> GetPlatformsXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Values.PlatformsXML);

            var result = new List<KeyValuePair<string, string>>();

            foreach (XmlNode item in doc.ChildNodes[0].ChildNodes[0].ChildNodes)
            {
                var kvp = new KeyValuePair<string, string>(item.ChildNodes[0].InnerText, item.ChildNodes[1].InnerText);
                result.Add(kvp);
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

        public static void CreateOrSetXmlAttribute(XmlNode node, string attributeName, string value)
        {
            if (node.Attributes[attributeName] == null)
            {
                node.Attributes.Append(XML.xmlDoc.CreateAttribute(attributeName));
            }

            node.Attributes[attributeName].Value = value;
        }

        public static void ShowCommandHelp()
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

            FormInfo info = new FormInfo(text.ToString());
            info.Show();
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
    }
}
