using EmuLoader.Core.Business;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml;

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
        public bool UseRetroarch { get; set; }
        
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
                string useRetroarch = Functions.GetXmlAttribute(node, "UseRetroarch");
                platform.UseRetroarch = string.IsNullOrEmpty(useRetroarch) ? false : Convert.ToBoolean(useRetroarch);
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
                node = XML.xmlPlatforms.CreateNode(XmlNodeType.Element, "Platform", "");
                node.Attributes.Append(XML.xmlPlatforms.CreateAttribute("Id"));
                node.Attributes.Append(XML.xmlPlatforms.CreateAttribute("Name"));
                node.Attributes.Append(XML.xmlPlatforms.CreateAttribute("EmulatorExe"));
                node.Attributes.Append(XML.xmlPlatforms.CreateAttribute("Command"));
                node.Attributes.Append(XML.xmlPlatforms.CreateAttribute("EmulatorExeAlt"));
                node.Attributes.Append(XML.xmlPlatforms.CreateAttribute("CommandAlt"));
                node.Attributes.Append(XML.xmlPlatforms.CreateAttribute("Color"));
                node.Attributes.Append(XML.xmlPlatforms.CreateAttribute("ShowInList"));
                node.Attributes.Append(XML.xmlPlatforms.CreateAttribute("ShowInFilter"));
                node.Attributes.Append(XML.xmlPlatforms.CreateAttribute("DefaultRomPath"));
                node.Attributes.Append(XML.xmlPlatforms.CreateAttribute("DefaultRomExtensions"));
                node.Attributes.Append(XML.xmlPlatforms.CreateAttribute("PictureNameByDisplay"));
                node.Attributes.Append(XML.xmlPlatforms.CreateAttribute("UseRetroarch"));
                XML.GetParentNode(XML.xmlPlatforms, "Platforms").AppendChild(node);
                platforms.Add(platform.Name.ToLower(), platform);
            }

            platforms[platform.Name.ToLower()] = platform;
            Functions.CreateOrSetXmlAttribute(XML.xmlPlatforms, node, "Id", platform.Id);
            Functions.CreateOrSetXmlAttribute(XML.xmlPlatforms, node, "Name", platform.Name);
            Functions.CreateOrSetXmlAttribute(XML.xmlPlatforms, node, "EmulatorExe", platform.EmulatorExe);
            Functions.CreateOrSetXmlAttribute(XML.xmlPlatforms, node, "Command", platform.Command);
            Functions.CreateOrSetXmlAttribute(XML.xmlPlatforms, node, "EmulatorExeAlt", platform.EmulatorExeAlt);
            Functions.CreateOrSetXmlAttribute(XML.xmlPlatforms, node, "CommandAlt", platform.CommandAlt);
            Functions.CreateOrSetXmlAttribute(XML.xmlPlatforms, node, "Color", platform.Color.ToArgb().ToString());
            Functions.CreateOrSetXmlAttribute(XML.xmlPlatforms, node, "ShowInList", platform.ShowInList.ToString());
            Functions.CreateOrSetXmlAttribute(XML.xmlPlatforms, node, "ShowInFilter", platform.ShowInFilter.ToString());
            Functions.CreateOrSetXmlAttribute(XML.xmlPlatforms, node, "DefaultRomPath", platform.DefaultRomPath);
            Functions.CreateOrSetXmlAttribute(XML.xmlPlatforms, node, "DefaultRomExtensions", platform.DefaultRomExtensions);
            Functions.CreateOrSetXmlAttribute(XML.xmlPlatforms, node, "UseRetroarch", platform.UseRetroarch.ToString());
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

            var added = RomFunctions.AddRomsFromDirectory(this, DefaultRomPath);
            var addedAnyRomPack = RomFunctions.AddRomPacksFromDirectory(this, DefaultRomPath);

            return added || addedAnyRomPack;
        }
    }
}
