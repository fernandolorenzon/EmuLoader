using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Linq;
using System;

namespace EmuLoader.Core.Classes
{
    internal static class XML
    {
        internal static XmlDocument xmlConfig;
        internal static Dictionary<string, XmlDocument> xmlPlatforms;
        internal static Dictionary<string, XmlDocument> xmlRoms;
        internal static XmlDocument xmlGenres;
        internal static XmlDocument xmlLabels;
        internal static XmlDocument xmlRomStatus;
        internal static XmlDocument xmlRomLabels;

        #region -- General --

        private static void CreateXmlConfig()
        {
            xmlConfig = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlConfig.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlConfig.InsertBefore(xmlDeclaration, xmlConfig.DocumentElement);
            xmlConfig.AppendChild(xmlConfig.CreateElement("Root"));

            XmlElement config = xmlConfig.CreateElement("Config");
            XmlAttribute attrPath = xmlConfig.CreateAttribute("ColumnPath");
            attrPath.Value = "true";
            config.Attributes.Append(attrPath);

            XmlAttribute attrDBName = xmlConfig.CreateAttribute("ColumnRomDBName");
            attrPath.Value = "false";
            config.Attributes.Append(attrDBName);

            XmlAttribute attrFileName = xmlConfig.CreateAttribute("ColumnFileName");
            attrFileName.Value = "false";
            config.Attributes.Append(attrFileName);

            XmlAttribute attrPlatform = xmlConfig.CreateAttribute("ColumnPlatform");
            attrPlatform.Value = "true";
            config.Attributes.Append(attrPlatform);

            XmlAttribute attrGenre = xmlConfig.CreateAttribute("ColumnGenre");
            attrGenre.Value = "true";
            config.Attributes.Append(attrGenre);

            XmlAttribute attrLabels = xmlConfig.CreateAttribute("ColumnLabels");
            attrLabels.Value = "true";
            config.Attributes.Append(attrLabels);

            XmlAttribute attrDeveloper = xmlConfig.CreateAttribute("ColumnDeveloper");
            attrLabels.Value = "true";
            config.Attributes.Append(attrDeveloper);

            XmlAttribute attrPublisher = xmlConfig.CreateAttribute("ColumnPublisher");
            attrLabels.Value = "true";
            config.Attributes.Append(attrPublisher);

            XmlAttribute attrStatus = xmlConfig.CreateAttribute("ColumnStatus");
            attrStatus.Value = "true";
            config.Attributes.Append(attrStatus);

            XmlAttribute attrYearReleased = xmlConfig.CreateAttribute("ColumnYearReleased");
            attrYearReleased.Value = "true";
            config.Attributes.Append(attrYearReleased);

            XmlAttribute attrRating = xmlConfig.CreateAttribute("ColumnRating");
            attrRating.Value = "false";
            config.Attributes.Append(attrRating);

            XmlAttribute attrBoxArt = xmlConfig.CreateAttribute("BoxArt");
            attrBoxArt.Value = "true";
            config.Attributes.Append(attrBoxArt);

            XmlAttribute attrTitle = xmlConfig.CreateAttribute("TitleArt");
            attrTitle.Value = "true";
            config.Attributes.Append(attrTitle);

            XmlAttribute attrGameplay = xmlConfig.CreateAttribute("GameplayArt");
            attrGameplay.Value = "true";
            config.Attributes.Append(attrGameplay);

            XmlAttribute attrPlatformsList = xmlConfig.CreateAttribute("PlatformsList");
            attrPlatformsList.Value = "true";
            config.Attributes.Append(attrPlatformsList);

            XmlAttribute attrExtension = xmlConfig.CreateAttribute("Extension");
            attrExtension.Value = "true";
            config.Attributes.Append(attrExtension);
            xmlConfig.ChildNodes[1].AppendChild(config);

            XmlElement filter = xmlConfig.CreateElement("Filter");
            XmlAttribute attrFilterPlatform = xmlConfig.CreateAttribute("Platform");
            attrFilterPlatform.Value = "";
            config.Attributes.Append(attrFilterPlatform);

            XmlAttribute attrFilterGenre = xmlConfig.CreateAttribute("Genre");
            attrFilterGenre.Value = "";
            config.Attributes.Append(attrFilterGenre);

            XmlAttribute attrFilterLabel = xmlConfig.CreateAttribute("Label");
            attrFilterLabel.Value = "";
            config.Attributes.Append(attrFilterLabel);

            XmlAttribute attrFilterYear = xmlConfig.CreateAttribute("Year");
            attrFilterYear.Value = "";
            config.Attributes.Append(attrFilterYear);

            XmlAttribute attrFilterPublisher = xmlConfig.CreateAttribute("Publisher");
            attrFilterPublisher.Value = "";
            config.Attributes.Append(attrFilterPublisher);

            XmlAttribute attrFilterDeveloper = xmlConfig.CreateAttribute("Developer");
            attrFilterDeveloper.Value = "";
            config.Attributes.Append(attrFilterDeveloper);

            XmlAttribute attrFilterName = xmlConfig.CreateAttribute("Text");
            attrFilterName.Value = "";
            config.Attributes.Append(attrFilterName);

            xmlConfig.ChildNodes[1].AppendChild(filter);

            if (!Directory.Exists(Values.xmlPath))
            {
                Directory.CreateDirectory(Values.xmlPath);
            }

            xmlConfig.Save(Values.xmlPath + "\\" + Values.xmlFileConfig);
        }

        public static void CreateXmlPlatform(string platform)
        {
            var xml = new XmlDocument();
            XmlDeclaration xmlDeclaration = xml.CreateXmlDeclaration("1.0", "utf-8", null);
            xml.InsertBefore(xmlDeclaration, xml.DocumentElement);
            xml.AppendChild(xml.CreateElement("Platform"));

            var path = Values.PlatformsPath + "\\" + platform;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            xml.Save(path + "\\" + "config.xml");
            xmlPlatforms.Add(platform, xml);
        }

        public static void CreateXmlRoms(string platform)
        {
            var xml = new XmlDocument();
            XmlDeclaration xmlDeclaration = xml.CreateXmlDeclaration("1.0", "utf-8", null);
            xml.InsertBefore(xmlDeclaration, xml.DocumentElement);
            xml.AppendChild(xml.CreateElement("Roms"));

            var path = Values.PlatformsPath + "\\" + platform;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            xml.Save(path + "\\" + "roms.xml");
            xmlRoms.Add(platform, xml);
        }

        private static void CreateXmlGenres()
        {
            xmlGenres = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlGenres.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlGenres.InsertBefore(xmlDeclaration, xmlGenres.DocumentElement);
            xmlGenres.AppendChild(xmlGenres.CreateElement("Root"));

            xmlGenres.ChildNodes[1].AppendChild(xmlGenres.CreateElement("Genres"));

            if (!Directory.Exists(Values.xmlPath))
            {
                Directory.CreateDirectory(Values.xmlPath);
            }

            xmlGenres.Save(Values.xmlPath + "\\" + Values.xmlFileGenres);
        }

        private static void CreateXmlLabels()
        {
            xmlLabels = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlLabels.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlLabels.InsertBefore(xmlDeclaration, xmlLabels.DocumentElement);
            xmlLabels.AppendChild(xmlLabels.CreateElement("Root"));

            xmlLabels.ChildNodes[1].AppendChild(xmlLabels.CreateElement("Labels"));

            if (!Directory.Exists(Values.xmlPath))
            {
                Directory.CreateDirectory(Values.xmlPath);
            }

            xmlLabels.Save(Values.xmlPath + "\\" + Values.xmlFileLabels);
        }

        private static void CreateXmlRomStatus()
        {
            xmlRomStatus = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlRomStatus.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlRomStatus.InsertBefore(xmlDeclaration, xmlRomStatus.DocumentElement);
            xmlRomStatus.AppendChild(xmlRomStatus.CreateElement("Root"));

            xmlRomStatus.ChildNodes[1].AppendChild(xmlRomStatus.CreateElement("RomStatuses"));

            if (!Directory.Exists(Values.xmlPath))
            {
                Directory.CreateDirectory(Values.xmlPath);
            }

            xmlRomStatus.Save(Values.xmlPath + "\\" + Values.xmlFileRomStatus);
        }

        private static void CreateXmlRomLabels()
        {
            xmlRomLabels = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlRomLabels.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlRomLabels.InsertBefore(xmlDeclaration, xmlRomLabels.DocumentElement);
            xmlRomLabels.AppendChild(xmlRomLabels.CreateElement("Root"));

            xmlRomLabels.ChildNodes[1].AppendChild(xmlRomLabels.CreateElement("RomLabelList"));

            if (!Directory.Exists(Values.xmlPath))
            {
                Directory.CreateDirectory(Values.xmlPath);
            }

            xmlRomLabels.Save(Values.xmlPath + "\\" + Values.xmlFileRomLabels);
        }

        internal static XmlDocument LoadXmlConfig()
        {
            string path = Values.xmlPath + "\\" + Values.xmlFileConfig;
            xmlConfig = new XmlDocument();

            try
            {
                if (File.Exists(path))
                {
                    xmlConfig.Load(path);
                }
                else
                {
                    CreateXmlConfig();
                }
            }
            catch
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    LoadXmlConfig();
                }
            }

            return xmlConfig;
        }

        internal static Dictionary<string, XmlDocument> LoadXmlPlatforms()
        {
            var platforms = Directory.GetDirectories(Values.PlatformsPath);
            xmlPlatforms = new Dictionary<string, XmlDocument>();

            try
            {
                foreach (var platform in platforms)
                {
                    var name = platform.Replace(Values.PlatformsPath + "\\", "");
                    var files = Directory.GetFiles(platform).ToList();

                    if (!files.Contains(platform + "\\" + Values.PlatformXML)) continue;

                    var config = files.First(x => x == platform + "\\" + Values.PlatformXML);
                    XmlDocument doc = new XmlDocument();
                    doc.Load(config);
                    xmlPlatforms.Add(name, doc);
                }
            }
            catch(Exception ex)
            {

            }

            return xmlPlatforms;
        }

        internal static Dictionary<string, XmlDocument> LoadXmlRoms()
        {
            var platforms = Directory.GetDirectories(Values.PlatformsPath);
            string path = Values.xmlPath + "\\" + Values.xmlFileRoms;
            xmlRoms = new Dictionary<string, XmlDocument>();

            try
            {
                foreach (var platform in platforms)
                {
                    var name = platform.Replace(Values.PlatformsPath + "\\", "");
                    var files = Directory.GetFiles(platform).ToList();

                    if (!files.Contains(platform + "\\" + Values.PlatformXML)) continue;

                    if (!files.Contains(platform + "\\" + Values.xmlFileRoms)) continue;

                    var config = files.First(x => x == platform + "\\" + Values.xmlFileRoms);
                    XmlDocument doc = new XmlDocument();
                    doc.Load(config);
                    xmlRoms.Add(name, doc);
                }
            }
            catch
            {

            }

            return xmlRoms;
        }

        internal static XmlDocument LoadXmlLabels()
        {
            string path = Values.xmlPath + "\\" + Values.xmlFileLabels;
            xmlLabels = new XmlDocument();

            try
            {
                if (File.Exists(path))
                {
                    xmlLabels.Load(path);
                }
                else
                {
                    CreateXmlLabels();
                }
            }
            catch
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    LoadXmlLabels();
                }
            }

            return xmlLabels;
        }

        internal static XmlDocument LoadXmlGenres()
        {
            string path = Values.xmlPath + "\\" + Values.xmlFileGenres;
            xmlGenres = new XmlDocument();

            try
            {
                if (File.Exists(path))
                {
                    xmlGenres.Load(path);
                }
                else
                {
                    CreateXmlGenres();
                }
            }
            catch
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    LoadXmlGenres();
                }
            }

            return xmlGenres;
        }

        internal static XmlDocument LoadXmlRomStatus()
        {
            string path = Values.xmlPath + "\\" + Values.xmlFileRomStatus;
            xmlRomStatus = new XmlDocument();

            try
            {
                if (File.Exists(path))
                {
                    xmlRomStatus.Load(path);
                }
                else
                {
                    CreateXmlRomStatus();
                }
            }
            catch
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    LoadXmlRomStatus();
                }
            }

            return xmlRomStatus;
        }

        internal static XmlDocument LoadXmlRomLabels()
        {
            string path = Values.xmlPath + "\\" + Values.xmlFileRomLabels;
            xmlRomLabels = new XmlDocument();

            try
            {
                if (File.Exists(path))
                {
                    xmlRomLabels.Load(path);
                }
                else
                {
                    CreateXmlRomLabels();
                }
            }
            catch
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    LoadXmlRomLabels();
                }
            }

            return xmlRomLabels;
        }

        internal static void SaveXmlConfig()
        {
            string path = Values.xmlPath + "\\" + Values.xmlFileConfig;
            xmlConfig.Save(path);
        }

        internal static void SaveXmlPlatforms(string platform)
        {
            string path = Values.PlatformsPath + "\\" + platform + "\\" + Values.PlatformXML;
            xmlPlatforms[platform].Save(path);
        }

        internal static void SaveXmlRoms(string platform)
        {
            string path = Values.PlatformsPath + "\\" + platform + "\\" + Values.xmlFileRoms;
            xmlRoms[platform].Save(path);
        }

        internal static void SaveXmlGenres()
        {
            string path = Values.xmlPath + "\\" + Values.xmlFileGenres;
            xmlGenres.Save(path);
        }

        internal static void SaveXmlLabels()
        {
            string path = Values.xmlPath + "\\" + Values.xmlFileLabels;
            xmlLabels.Save(path);
        }

        internal static void SaveXmlRomStatus()
        {
            string path = Values.xmlPath + "\\" + Values.xmlFileRomStatus;
            xmlRomStatus.Save(path);
        }

        internal static void SaveXmlRomLabels()
        {
            string path = Values.xmlPath + "\\" + Values.xmlFileRomLabels;
            xmlRomLabels.Save(path);
        }

        internal static XmlNode GetParentNode(XmlDocument xml, string elementName)
        {
            try
            {
                foreach (var item in xml.ChildNodes[1].ChildNodes)
                {
                    if (((System.Xml.XmlElement)item).LocalName == elementName) return (XmlNode)item;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region -- Config --

        internal static string GetConfig(string key)
        {
            try
            {
                if (GetParentNode(xmlConfig, "Config").Attributes.Count == 0) return "";

                return GetParentNode(xmlConfig, "Config").Attributes[key].Value;
            }
            catch
            {
                return "";
            }
        }

        internal static bool SetConfig(string key, string value)
        {
            try
            {
                XmlNode config = GetParentNode(xmlConfig, "Config");
                bool ok = false;

                foreach (XmlAttribute item in config.Attributes)
                {
                    if (item.Name == key)
                    {
                        item.Value = value;
                        ok = true;
                    }
                }

                if (ok) return true;

                XmlAttribute attr = xmlConfig.CreateAttribute(key);
                attr.Value = value;
                config.Attributes.Append(attr);
                XML.SaveXmlConfig();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region -- Platform --

        public static XmlNode GetPlatformNode(string platform)
        {
            if (!xmlPlatforms.ContainsKey(platform))
            {
                return null;
            }

            if (xmlPlatforms[platform].ChildNodes.Count != 2) return null;

            return xmlPlatforms[platform].ChildNodes[1];
        }

        #endregion

        #region -- Label --

        internal static XmlNodeList GetLabelNodes()
        {
            try
            {
                return GetParentNode(xmlLabels, "Labels").ChildNodes;
            }
            catch
            {
                return null;
            }
        }

        internal static XmlNode GetLabelNode(string name)
        {
            if (GetLabelNodes() == null)
            {
                return null;
            }

            foreach (XmlNode node in GetLabelNodes())
            {
                if (node.Attributes["Name"].Value == name)
                {
                    return node;
                }
            }

            return null;
        }

        internal static bool DelLabel(string name)
        {
            XmlNode node = null;

            foreach (XmlNode item in GetLabelNodes())
            {
                if (item.Attributes["Name"].Value.ToLower() == name.ToLower())
                {
                    node = item;
                }
            }

            if (node != null)
            {
                GetParentNode(xmlLabels, "Labels").RemoveChild(node);
                return true;
            }

            return false;
        }

        #endregion

        #region -- Genre --

        internal static XmlNodeList GetGenreNodes()
        {
            try
            {
                return GetParentNode(xmlGenres, "Genres").ChildNodes;
            }
            catch
            {
                return null;
            }
        }

        internal static XmlNode GetGenreNode(string name)
        {
            if (GetGenreNodes() == null)
            {
                return null;
            }

            foreach (XmlNode node in GetGenreNodes())
            {
                if (node.Attributes["Name"].Value == name)
                {
                    return node;
                }
            }

            return null;
        }

        internal static bool DelGenre(string name)
        {
            XmlNode node = null;

            foreach (XmlNode item in GetGenreNodes())
            {
                if (item.Attributes["Name"].Value.ToLower() == name.ToLower())
                {
                    node = item;
                }
            }

            if (node != null)
            {
                GetParentNode(xmlGenres,"Genres").RemoveChild(node);
                return true;
            }

            return false;
        }

        #endregion

        #region -- Rom --

        public static XmlNode GetRomNodes(string platform)
        {
            if (!xmlRoms.ContainsKey(platform))
            {
                return null;
            }

            if (xmlRoms[platform].ChildNodes.Count != 2) return null;

            return xmlRoms[platform].ChildNodes[1];
        }

        public static XmlNode GetRomNode(string platform, string path)
        {
            var nodes = GetRomNodes(platform);

            if (nodes == null) return null;

            foreach (XmlNode node in nodes)
            {
                if (node.Attributes["Path"].Value == path)
                {
                    return node;
                }
            }

            return null;
        }

        internal static bool DelRom(string platform, string path)
        {
            XmlNode node = null;

            foreach (XmlNode item in GetRomNodes(platform))
            {
                if (item.Attributes["Path"].Value == path)
                {
                    node = item;
                    break;
                }
            }

            if (node != null)
            {
                GetParentNode(xmlRoms[platform], "Roms").RemoveChild(node);
                return true;
            }

            return false;
        }

        #endregion

        #region -- Filter --

        internal static string GetFilter(string key)
        {
            try
            {
                if (GetParentNode(xmlConfig, "Filter").Attributes.Count == 0) return "";

                return GetParentNode(xmlConfig, "Filter").Attributes[key].Value;
            }
            catch
            {
                return "";
            }
        }

        internal static bool SetFilter(string key, string value)
        {
            try
            {
                XmlNode config = GetParentNode(xmlConfig, "Filter");
                bool ok = false;

                foreach (XmlAttribute item in config.Attributes)
                {
                    if (item.Name == key)
                    {
                        item.Value = value;
                        ok = true;
                    }
                }

                if (ok) return true;

                XmlAttribute attr = xmlConfig.CreateAttribute(key);
                attr.Value = value;
                config.Attributes.Append(attr);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region -- RomStatus --

        internal static XmlNodeList GetRomStatusNodes()
        {
            try
            {
                return GetParentNode(xmlRomStatus, "RomStatuses").ChildNodes;
            }
            catch
            {
                return null;
            }
        }

        internal static XmlNode GetRomStatusNode(string platform, string rom)
        {
            if (GetRomStatusNodes() == null)
            {
                return null;
            }

            foreach (XmlNode node in GetRomStatusNodes())
            {
                if (node.Attributes["Platform"].Value == platform && node.Attributes["Rom"].Value == rom)
                {
                    return node;
                }
            }

            return null;
        }

        internal static bool DelRomStatus(string platform, string rom)
        {
            XmlNode node = null;

            foreach (XmlNode item in GetRomStatusNodes())
            {
                if (item.Attributes["Platform"].Value == platform.ToLower() && item.Attributes["Rom"].Value == rom.ToLower())
                {
                    node = item;
                    break;
                }
            }

            if (node != null)
            {
                GetParentNode(xmlRomStatus, "RomStatuses").RemoveChild(node);
                return true;
            }

            return false;
        }

        #endregion

        #region -- RomLabels --

        internal static XmlNodeList GetRomLabelsNodes()
        {
            try
            {
                return GetParentNode(xmlRomLabels, "RomLabelList").ChildNodes;
            }
            catch
            {
                return null;
            }
        }

        internal static XmlNode GetRomLabelsNode(string platform, string rom)
        {
            if (GetRomLabelsNodes() == null)
            {
                return null;
            }

            foreach (XmlNode node in GetRomLabelsNodes())
            {
                if (node.Attributes["Platform"].Value == platform && node.Attributes["Rom"].Value == rom)
                {
                    return node;
                }
            }

            return null;
        }

        internal static bool DelRomLabels(string platform, string rom)
        {
            List<XmlNode> nodes = new List<XmlNode>();

            foreach (XmlNode item in GetRomLabelsNodes())
            {
                if (item.Attributes["Platform"].Value == platform.ToLower() && item.Attributes["Rom"].Value == rom.ToLower())
                {
                    nodes.Add(item);
                }
            }

            foreach (XmlNode item in nodes)
            {
                GetParentNode(xmlRomLabels, "RomLabelList").RemoveChild(item);
                return true;
            }

            return false;
        }

        #endregion

    }
}
