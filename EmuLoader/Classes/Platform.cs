using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Drawing;
using System.IO;

namespace EmuLoader.Classes
{
    public class Platform : Base
    {
        private static Dictionary<string, Platform> platforms { get; set; }
        public string EmulatorExe { get; set; }
        public Color Color { get; set; }
        public bool ShowInList { get; set; }
        public bool ShowInFilter { get; set; }
        public string Command { get; set; }
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
                platform.ShowInList = Convert.ToBoolean(Functions.GetXmlAttribute(node, "ShowInList"));
                platform.ShowInFilter = Convert.ToBoolean(Functions.GetXmlAttribute(node, "ShowInFilter"));
                platform.Command = Functions.GetXmlAttribute(node, "Command");
                platform.DefaultRomPath = Functions.GetXmlAttribute(node, "DefaultRomPath");
                platform.DefaultRomExtensions = Functions.GetXmlAttribute(node, "DefaultRomExtensions");
                platform.Color = Color.FromArgb(Convert.ToInt32(Functions.GetXmlAttribute(node, "Color")));

                string icon = Functions.GetPlatformPicture(platform.Name);
                platform.Icon = Functions.CreateBitmap(icon);
                platforms.Add(platform.Name, platform);
            }
        }

        public static Platform Get(string name)
        {
            try
            {
                if (name == "")
                    return null;

                if (platforms.ContainsKey(name))
                {
                    return platforms[name];
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
                node.Attributes.Append(XML.xmlDoc.CreateAttribute("Color"));
                node.Attributes.Append(XML.xmlDoc.CreateAttribute("Command"));
                node.Attributes.Append(XML.xmlDoc.CreateAttribute("ShowInList"));
                node.Attributes.Append(XML.xmlDoc.CreateAttribute("ShowInFilter"));
                node.Attributes.Append(XML.xmlDoc.CreateAttribute("DefaultRomPath"));
                node.Attributes.Append(XML.xmlDoc.CreateAttribute("DefaultRomExtensions"));
                XML.GetParentNode("Platforms").AppendChild(node);
                platforms.Add(platform.Name, platform);
            }

            platforms[platform.Name] = platform;
            Functions.CreateOrSetXmlAttribute(node, "Id", platform.Id);
            Functions.CreateOrSetXmlAttribute(node, "Name", platform.Name);
            Functions.CreateOrSetXmlAttribute(node, "EmulatorExe", platform.EmulatorExe);
            Functions.CreateOrSetXmlAttribute(node, "Color", platform.Color.ToArgb().ToString());
            Functions.CreateOrSetXmlAttribute(node, "Command", platform.Command);
            Functions.CreateOrSetXmlAttribute(node, "ShowInList", platform.ShowInList.ToString());
            Functions.CreateOrSetXmlAttribute(node, "ShowInFilter", platform.ShowInFilter.ToString());
            Functions.CreateOrSetXmlAttribute(node, "DefaultRomPath", platform.DefaultRomPath);
            Functions.CreateOrSetXmlAttribute(node, "DefaultRomExtensions", platform.DefaultRomExtensions);
            return true;
        }

        public static bool Delete(string name)
        {
            platforms.Remove(name);
            return XML.DeletePlatform(name);
        }

        public bool RescanRoms()
        {
            if (string.IsNullOrEmpty(DefaultRomPath) || string.IsNullOrEmpty(DefaultRomExtensions))
            {
                return false;
            }

            var extensions = DefaultRomExtensions.Replace(" ", "").Replace(".", "").Split(',');

            if (!Directory.Exists(DefaultRomPath) || extensions.Length == 0)
            {
                return false;
            }

            bool addedAny = false;

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

            return addedAny;
        }

        public bool AddRomsFiles(string[] files)
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

                r.Platform = this;
                Rom.Set(r);
            }

            return true;
        }

        public bool AddRomsFromDirectory(string directory)
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

                r.Platform = this;
                Rom.Set(r);
            }

            return true;
        }

        public bool AddRomPacksFromDirectory(string directory)
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

                        r.Platform = this;
                        Rom.Set(r);
                    }
                }
            }

            return true;
        }

        public bool ChangeRomsPlatform(List<Rom> roms)
        {
            foreach (var item in roms)
            {
                item.Platform = this;
                Rom.Set(item);
            }

            return true;
        }
    }
}
