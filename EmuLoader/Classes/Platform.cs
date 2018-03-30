using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Drawing;
using System.IO;

namespace EmuLoader.Classes
{
    public class Platform
    {
        private static Dictionary<string, Platform> platforms { get; set; }
        public string Name { get; set; }
        public string EmulatorExe { get; set; }
        public Color Color { get; set; }
        public bool ShowInList { get; set; }
        public bool ShowInFilter { get; set; }
        public string Command { get; set; }
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
            return true;
        }

        public static bool Delete(string name)
        {
            platforms.Remove(name);
            return XML.DeletePlatform(name);
        }
    }
}
