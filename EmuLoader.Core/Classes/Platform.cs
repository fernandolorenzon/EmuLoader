using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Drawing;
using System.IO;
using EmuLoader.Core.Business;

namespace EmuLoader.Core.Classes
{
    public class Platform : Base
    {
        private static Dictionary<string, Platform> platforms { get; set; }
        public string EmulatorExe { get; set; }
        public string Command { get; set; }
        public string EmulatorExeAlt { get; set; }
        public string CommandAlt { get; set; }
        public Color Color { get; set; }
        public bool ShowInList { get; set; }
        public bool ShowInFilter { get; set; }
        public string DefaultRomPath { get; set; }
        public string DefaultRomExtensions { get; set; }
        public string Id { get; set; }

        public Bitmap Icon { get; set; }

        public Platform()
        {
            Name = "";
            EmulatorExe = "";
            Color = Color.White;
        }

        public static void Fill()
        {
            platforms = new Dictionary<string, Platform>();

            foreach (XmlNode node in XML.GetPlatformNodes())
            {
                Platform platform = new Platform();

                platform.Id = Functions.GetXmlAttribute(node, "Id");
                platform.Name = Functions.GetXmlAttribute(node, "Name");
                platform.EmulatorExe = Functions.GetXmlAttribute(node, "EmulatorExe");
                platform.Command = Functions.GetXmlAttribute(node, "Command");
                platform.EmulatorExeAlt = Functions.GetXmlAttribute(node, "EmulatorExeAlt");
                platform.CommandAlt = Functions.GetXmlAttribute(node, "CommandAlt");
                platform.ShowInList = Convert.ToBoolean(Functions.GetXmlAttribute(node, "ShowInList"));
                platform.ShowInFilter = Convert.ToBoolean(Functions.GetXmlAttribute(node, "ShowInFilter"));
                platform.DefaultRomPath = Functions.GetXmlAttribute(node, "DefaultRomPath");
                platform.DefaultRomExtensions = Functions.GetXmlAttribute(node, "DefaultRomExtensions");
                platform.Color = Color.FromArgb(Convert.ToInt32(Functions.GetXmlAttribute(node, "Color")));

                string icon = RomFunctions.GetPlatformPicture(platform.Name);
                platform.Icon = Functions.CreateBitmap(icon);
                platforms.Add(platform.Name.ToLower(), platform);
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

        public static bool Set(Platform platform)
        {
            XmlNode node = XML.GetPlatformNode(platform.Name);

            if (node == null)
            {
                node = XML.xmlDoc.CreateNode(XmlNodeType.Element, "Platform", "");
                node.Attributes.Append(XML.xmlDoc.CreateAttribute("Id"));
                node.Attributes.Append(XML.xmlDoc.CreateAttribute("Name"));
                node.Attributes.Append(XML.xmlDoc.CreateAttribute("EmulatorExe"));
                node.Attributes.Append(XML.xmlDoc.CreateAttribute("Command"));
                node.Attributes.Append(XML.xmlDoc.CreateAttribute("EmulatorExeAlt"));
                node.Attributes.Append(XML.xmlDoc.CreateAttribute("CommandAlt"));
                node.Attributes.Append(XML.xmlDoc.CreateAttribute("Color"));
                node.Attributes.Append(XML.xmlDoc.CreateAttribute("ShowInList"));
                node.Attributes.Append(XML.xmlDoc.CreateAttribute("ShowInFilter"));
                node.Attributes.Append(XML.xmlDoc.CreateAttribute("DefaultRomPath"));
                node.Attributes.Append(XML.xmlDoc.CreateAttribute("DefaultRomExtensions"));
                XML.GetParentNode("Platforms").AppendChild(node);
                platforms.Add(platform.Name.ToLower(), platform);
            }

            platforms[platform.Name.ToLower()] = platform;
            Functions.CreateOrSetXmlAttribute(node, "Id", platform.Id);
            Functions.CreateOrSetXmlAttribute(node, "Name", platform.Name);
            Functions.CreateOrSetXmlAttribute(node, "EmulatorExe", platform.EmulatorExe);
            Functions.CreateOrSetXmlAttribute(node, "Command", platform.Command);
            Functions.CreateOrSetXmlAttribute(node, "EmulatorExeAlt", platform.EmulatorExeAlt);
            Functions.CreateOrSetXmlAttribute(node, "CommandAlt", platform.CommandAlt);
            Functions.CreateOrSetXmlAttribute(node, "Color", platform.Color.ToArgb().ToString());
            Functions.CreateOrSetXmlAttribute(node, "ShowInList", platform.ShowInList.ToString());
            Functions.CreateOrSetXmlAttribute(node, "ShowInFilter", platform.ShowInFilter.ToString());
            Functions.CreateOrSetXmlAttribute(node, "DefaultRomPath", platform.DefaultRomPath);
            Functions.CreateOrSetXmlAttribute(node, "DefaultRomExtensions", platform.DefaultRomExtensions);
            return true;
        }

        public static bool Delete(string name)
        {
            platforms.Remove(name.ToLower());
            return XML.DeletePlatform(name);
        }

        public bool RescanRoms()
        {
            bool addedAny = false;

            if (string.IsNullOrEmpty(DefaultRomPath) || string.IsNullOrEmpty(DefaultRomExtensions))
            {
                return false;
            }

            if (DefaultRomExtensions == "dir")
            {

                if (!Directory.Exists(DefaultRomPath))
                {
                    return false;
                }

                var dirs = Directory.GetDirectories(DefaultRomPath);

                foreach (var dir in dirs)
                {
                    var rom = Rom.Get(dir);

                    if (rom == null)
                    {
                        rom = new Rom(dir);
                        rom.Platform = this;
                    }

                    Rom.Set(rom);
                    addedAny = true;
                }
            }
            else
            {
                var extensions = DefaultRomExtensions.Replace(" ", "").Replace(".", "").Split(',');

                if (!Directory.Exists(DefaultRomPath) || extensions.Length == 0)
                {
                    return false;
                }

                foreach (var item in extensions)
                {
                    var files = Directory.GetFiles(DefaultRomPath, "*." + item, SearchOption.TopDirectoryOnly);

                    foreach (var file in files)
                    {
                        var rom = Rom.Get(file);

                        if (rom == null)
                        {
                            rom = new Rom(file);
                            rom.Platform = this;
                        }

                        Rom.Set(rom);
                        addedAny = true;
                    }
                }
            }

            var addedAnyRomPack = RomFunctions.AddRomPacksFromDirectory(this, DefaultRomPath);

            return addedAny || addedAnyRomPack;
        }

    }
}
