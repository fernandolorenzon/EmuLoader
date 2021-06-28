using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml;

namespace EmuLoader.Core.Models
{
    public static class PlatformBusiness
    {
        private static Dictionary<string, Platform> platforms { get; set; }

        public static void Fill()
        {
            platforms = new Dictionary<string, Platform>();

            if (!Directory.Exists(Values.PlatformsPath))
            {
                Directory.CreateDirectory(Values.PlatformsPath);
            }

            var platformnames = Directory.GetDirectories(Values.PlatformsPath);

            foreach (var platformname in platformnames)
            {
                var name = platformname.Replace(Values.PlatformsPath + "\\", "");
                var platformNode = XML.GetPlatformNode(name);

                if (platformNode == null) continue;

                Platform platform = new Platform();

                platform.Id = Functions.GetXmlAttribute(platformNode, "Id");
                platform.Name = Functions.GetXmlAttribute(platformNode, "Name");
                platform.ShowInList = Convert.ToBoolean(Functions.GetXmlAttribute(platformNode, "ShowInList"));
                platform.ShowInFilter = Convert.ToBoolean(Functions.GetXmlAttribute(platformNode, "ShowInFilter"));
                platform.DefaultRomPath = Functions.GetXmlAttribute(platformNode, "DefaultRomPath");
                platform.DefaultRomExtensions = Functions.GetXmlAttribute(platformNode, "DefaultRomExtensions");
                platform.DefaultEmulator = Functions.GetXmlAttribute(platformNode, "DefaultEmulator");
                platform.Color = Color.FromArgb(Convert.ToInt32(Functions.GetXmlAttribute(platformNode, "Color")));
                string icon = RomFunctions.GetPlatformPicture(platform.Name);
                platform.Icon = Functions.CreateBitmap(icon);
                string useRetroarch = Functions.GetXmlAttribute(platformNode, "UseRetroarch");
                platform.UseRetroarch = string.IsNullOrEmpty(useRetroarch) ? false : Convert.ToBoolean(useRetroarch);

                string arcade = Functions.GetXmlAttribute(platformNode, "Arcade");
                platform.Arcade = string.IsNullOrEmpty(arcade) ? false : Convert.ToBoolean(arcade);

                string console = Functions.GetXmlAttribute(platformNode, "Console");
                platform.Console = string.IsNullOrEmpty(console) ? false : Convert.ToBoolean(console);

                string handheld = Functions.GetXmlAttribute(platformNode, "Handheld");
                platform.Handheld = string.IsNullOrEmpty(handheld) ? false : Convert.ToBoolean(handheld);

                string cd = Functions.GetXmlAttribute(platformNode, "CD");
                platform.CD = string.IsNullOrEmpty(cd) ? false : Convert.ToBoolean(cd);

                platforms.Add(platform.Name.ToLower(), platform);

                if (platformNode.ChildNodes[0] != null)
                {
                    foreach (XmlNode emuNode in platformNode.ChildNodes[0].ChildNodes)
                    {
                        var emu = new Emulator() { Name = emuNode.InnerText, Path = emuNode.Attributes["Path"].Value, Command = emuNode.Attributes["Command"].Value };
                        platform.Emulators.Add(emu);
                    }
                }
            }
        }

        public static Platform Get(string name)
        {
            try
            {
                if (name == "")
                    return null;

                if (platforms.ContainsKey(name.ToLower()))
                {
                    return platforms[name.ToLower()];
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public static List<Platform> GetAll()
        {
            List<Platform> result = new List<Platform>();

            foreach (var item in platforms.Values)
            {
                result.Add(item);
            }

            return (from r in result orderby r.Name select r).ToList();
        }

        public static List<Platform> GetAllFiltered(bool arcade, bool console, bool handheld, bool cd)
        {
            List<Platform> result = new List<Platform>();

            if ((arcade && console && handheld && cd)
                || (!arcade && !console && !handheld && !cd))
            {
                foreach (var item in platforms.Values)
                {
                    result.Add(item);
                }
            }
            else
            {
                foreach (var item in platforms.Values)
                {
                    if ((arcade && item.Arcade) || (console && item.Console) || (handheld && item.Handheld) || (cd && item.CD))
                    {
                        result.Add(item);
                    }
                }
            }

            return (from r in result orderby r.Name select r).ToList();
        }

        private static void CreatePlatform(string platform)
        {
            XML.CreateXmlPlatform(platform);
        }

        public static bool Set(Platform platform)
        {
            if (File.Exists(platform.IconPath))
            {
                string platformPath = Values.PlatformsPath + "\\" + platform.Name;

                if (!Directory.Exists(platformPath))
                {
                    Directory.CreateDirectory(platformPath);
                }

                FileInfo pic = new FileInfo(platform.IconPath);
                File.Delete(platformPath + "\\" + Values.PlatformIcon + ".gif");
                File.Delete(platformPath + "\\" + Values.PlatformIcon + ".jpg");
                File.Delete(platformPath + "\\" + Values.PlatformIcon + ".png");
                File.Delete(platformPath + "\\" + Values.PlatformIcon + ".ico");

                string destinationFile = platformPath + "\\" + Values.PlatformIcon + pic.Extension;
                pic.CopyTo(destinationFile, true);
                pic = null;
            }

            var filepath = Values.PlatformsPath + "\\" + platform.Name + "\\config.xml";

            if (File.Exists(filepath))
            {
                XmlNode n = XML.GetPlatformNode(platform.Name);

                if (n == null)
                {
                    File.Delete(filepath);
                }
            }

            if (!File.Exists(filepath))
            {
                CreatePlatform(platform.Name);

                var xml = XML.xmlPlatforms[platform.Name];
                var newnode = xml.ChildNodes[1];
                newnode.Attributes.Append(xml.CreateAttribute("Id"));
                newnode.Attributes.Append(xml.CreateAttribute("Name"));
                newnode.Attributes.Append(xml.CreateAttribute("Color"));
                newnode.Attributes.Append(xml.CreateAttribute("ShowInList"));
                newnode.Attributes.Append(xml.CreateAttribute("ShowInFilter"));
                newnode.Attributes.Append(xml.CreateAttribute("DefaultRomPath"));
                newnode.Attributes.Append(xml.CreateAttribute("DefaultRomExtensions"));
                newnode.Attributes.Append(xml.CreateAttribute("PictureNameByDisplay"));
                newnode.Attributes.Append(xml.CreateAttribute("UseRetroarch"));
                newnode.Attributes.Append(xml.CreateAttribute("DefaultEmulator"));
                newnode.Attributes.Append(xml.CreateAttribute("Arcade"));
                newnode.Attributes.Append(xml.CreateAttribute("Console"));
                newnode.Attributes.Append(xml.CreateAttribute("Handheld"));
                newnode.Attributes.Append(xml.CreateAttribute("CD"));

                platforms.Add(platform.Name.ToLower(), platform);
            }

            XmlNode node = XML.GetPlatformNode(platform.Name);
            var xmlPlatform = XML.xmlPlatforms[platform.Name];

            platforms[platform.Name.ToLower()] = platform;
            Functions.CreateOrSetXmlAttribute(xmlPlatform, node, "Id", platform.Id);
            Functions.CreateOrSetXmlAttribute(xmlPlatform, node, "Name", platform.Name);
            Functions.CreateOrSetXmlAttribute(xmlPlatform, node, "Color", platform.Color.ToArgb().ToString());
            Functions.CreateOrSetXmlAttribute(xmlPlatform, node, "ShowInList", platform.ShowInList.ToString());
            Functions.CreateOrSetXmlAttribute(xmlPlatform, node, "ShowInFilter", platform.ShowInFilter.ToString());
            Functions.CreateOrSetXmlAttribute(xmlPlatform, node, "DefaultRomPath", platform.DefaultRomPath);
            Functions.CreateOrSetXmlAttribute(xmlPlatform, node, "DefaultRomExtensions", platform.DefaultRomExtensions);
            Functions.CreateOrSetXmlAttribute(xmlPlatform, node, "UseRetroarch", platform.UseRetroarch.ToString());
            Functions.CreateOrSetXmlAttribute(xmlPlatform, node, "DefaultEmulator", platform.DefaultEmulator);
            Functions.CreateOrSetXmlAttribute(xmlPlatform, node, "Arcade", platform.Arcade.ToString());
            Functions.CreateOrSetXmlAttribute(xmlPlatform, node, "Console", platform.Console.ToString());
            Functions.CreateOrSetXmlAttribute(xmlPlatform, node, "Handheld", platform.Handheld.ToString());
            Functions.CreateOrSetXmlAttribute(xmlPlatform, node, "CD", platform.CD.ToString());
            SetPlatformEmulators(platform, node);

            XML.SaveXmlPlatforms(platform.Name);
            return true;
        }

        public static void SetPlatformEmulators(Platform platform, XmlNode node)
        {
            var xmlPlatform = XML.xmlPlatforms[platform.Name];

            if (node.ChildNodes.Count > 0)
            {
                node.ChildNodes[0].RemoveAll();
            }
            else
            {
                XmlNode emus = xmlPlatform.CreateNode(XmlNodeType.Element, "Emulators", "");
                node.AppendChild(emus);
            }

            if (platform.Emulators != null)
            {
                foreach (Emulator emu in platform.Emulators)
                {
                    XmlNode emuNode = xmlPlatform.CreateNode(XmlNodeType.Element, "Emulator", "");
                    emuNode.InnerText = emu.Name;
                    XmlAttribute attrPath = xmlPlatform.CreateAttribute("Path");
                    attrPath.Value = emu.Path;
                    emuNode.Attributes.Append(attrPath);

                    XmlAttribute attrCommand = xmlPlatform.CreateAttribute("Command");
                    attrCommand.Value = emu.Command;
                    emuNode.Attributes.Append(attrCommand);
                    node.ChildNodes[0].AppendChild(emuNode);
                }
            }
        }

        public static bool Delete(string name)
        {
            platforms.Remove(name.ToLower());

            Directory.Delete(name);

            return true;
        }

        public static bool RescanRoms(Platform platform)
        {
            if (string.IsNullOrEmpty(platform.DefaultRomPath) || string.IsNullOrEmpty(platform.DefaultRomExtensions))
            {
                return false;
            }

            var added = RomFunctions.AddRomsFromDirectory(platform, platform.DefaultRomPath);
            var addedAnyRomPack = RomFunctions.AddRomPacksFromDirectory(platform, platform.DefaultRomPath);

            if (added || addedAnyRomPack)
            {
                XML.SaveXmlRoms(platform.Name);
            }

            return added || addedAnyRomPack;
        }
    }
}
