using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace EmuLoader.Core.Classes
{
    public static class XML
    {
        public static XmlDocument xmlConfig;
        public static XmlDocument xmlPlatforms;
        public static XmlDocument xmlRoms;
        public static XmlDocument xmlGenres;
        public static XmlDocument xmlLabels;
        public static XmlDocument xmlRomStatus;
        public static XmlDocument xmlRomLabels;

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

        private static void CreateXmlPlatforms()
        {
            xmlPlatforms = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlPlatforms.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlPlatforms.InsertBefore(xmlDeclaration, xmlPlatforms.DocumentElement);
            xmlPlatforms.AppendChild(xmlPlatforms.CreateElement("Root"));

            xmlPlatforms.ChildNodes[1].AppendChild(xmlPlatforms.CreateElement("Platforms"));

            if (!Directory.Exists(Values.xmlPath))
            {
                Directory.CreateDirectory(Values.xmlPath);
            }

            xmlPlatforms.Save(Values.xmlPath + "\\" + Values.xmlFilePlatforms);
        }

        private static void CreateXmlRoms()
        {
            xmlRoms = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlRoms.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlRoms.InsertBefore(xmlDeclaration, xmlRoms.DocumentElement);
            xmlRoms.AppendChild(xmlRoms.CreateElement("Root"));

            xmlRoms.ChildNodes[1].AppendChild(xmlRoms.CreateElement("Roms"));

            if (!Directory.Exists(Values.xmlPath))
            {
                Directory.CreateDirectory(Values.xmlPath);
            }

            xmlRoms.Save(Values.xmlPath + "\\" + Values.xmlFileRoms);
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

        public static XmlDocument LoadXmlConfig()
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

        public static XmlDocument LoadXmlPlatforms()
        {
            string path = Values.xmlPath + "\\" + Values.xmlFilePlatforms;
            xmlPlatforms = new XmlDocument();

            try
            {
                if (File.Exists(path))
                {
                    xmlPlatforms.Load(path);
                }
                else
                {
                    CreateXmlPlatforms();
                }
            }
            catch
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    LoadXmlPlatforms();
                }
            }

            return xmlPlatforms;
        }

        public static XmlDocument LoadXmlRoms()
        {
            string path = Values.xmlPath + "\\" + Values.xmlFileRoms;
            xmlRoms = new XmlDocument();

            try
            {
                if (File.Exists(path))
                {
                    xmlRoms.Load(path);
                }
                else
                {
                    CreateXmlRoms();
                }
            }
            catch
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    LoadXmlRoms();
                }
            }

            return xmlRoms;
        }

        public static XmlDocument LoadXmlLabels()
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

        public static XmlDocument LoadXmlGenres()
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

        public static XmlDocument LoadXmlRomStatus()
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

        public static XmlDocument LoadXmlRomLabels()
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

        public static void SaveXmlConfig()
        {
            string path = Values.xmlPath + "\\" + Values.xmlFileConfig;
            xmlConfig.Save(path);
        }

        public static void SaveXmlPlatforms()
        {
            string path = Values.xmlPath + "\\" + Values.xmlFilePlatforms;
            xmlPlatforms.Save(path);
        }

        public static void SaveXmlRoms()
        {
            string path = Values.xmlPath + "\\" + Values.xmlFileRoms;
            xmlRoms.Save(path);
        }

        public static void SaveXmlGenres()
        {
            string path = Values.xmlPath + "\\" + Values.xmlFileGenres;
            xmlGenres.Save(path);
        }

        public static void SaveXmlLabels()
        {
            string path = Values.xmlPath + "\\" + Values.xmlFileLabels;
            xmlLabels.Save(path);
        }

        public static void SaveXmlRomStatus()
        {
            string path = Values.xmlPath + "\\" + Values.xmlFileRomStatus;
            xmlRomStatus.Save(path);
        }

        public static void SaveXmlRomLabels()
        {
            string path = Values.xmlPath + "\\" + Values.xmlFileRomLabels;
            xmlRomLabels.Save(path);
        }

        public static XmlNode GetParentNode(XmlDocument xml, string elementName)
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

        public static string GetConfig(string key)
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

        public static bool SetConfig(string key, string value)
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
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region -- Platform --

        public static XmlNodeList GetPlatformNodes()
        {
            try
            {
                return GetParentNode(xmlPlatforms, "Platforms").ChildNodes;
            }
            catch
            {
                return null;
            }
        }

        public static XmlNode GetPlatformNode(string name)
        {
            foreach (XmlNode node in GetPlatformNodes())
            {
                if (node.Attributes["Name"].Value == name)
                {
                    return node;
                }
            }

            return null;
        }

        public static bool DeletePlatform(string name)
        {
            XmlNode node = null;

            foreach (XmlNode item in GetPlatformNodes())
            {
                if (item.Attributes["Name"].Value.ToLower() == name.ToLower())
                {
                    node = item;
                    break;
                }
            }

            if (node != null)
            {
                GetParentNode(xmlPlatforms, "Platforms").RemoveChild(node);
                return true;
            }

            return false;
        }

        #endregion

        #region -- Label --

        public static XmlNodeList GetLabelNodes()
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

        public static XmlNode GetLabelNode(string name)
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

        public static bool DelLabel(string name)
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

        public static XmlNodeList GetGenreNodes()
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

        public static XmlNode GetGenreNode(string name)
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

        public static bool DelGenre(string name)
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

        public static XmlNodeList GetRomNodes()
        {
            try
            {
                return GetParentNode(xmlRoms, "Roms").ChildNodes;
            }
            catch
            {
                return null;
            }
        }

        public static XmlNode GetRomNode(string path)
        {
            foreach (XmlNode node in GetRomNodes())
            {
                if (node.Attributes["Path"].Value == path)
                {
                    return node;
                }
            }

            return null;
        }

        public static bool DelRom(string path)
        {
            XmlNode node = null;

            foreach (XmlNode item in GetRomNodes())
            {
                if (item.Attributes["Path"].Value == path)
                {
                    node = item;
                    break;
                }
            }

            if (node != null)
            {
                GetParentNode(xmlRoms, "Roms").RemoveChild(node);
                return true;
            }

            return false;
        }

        #endregion

        #region -- Filter --

        public static string GetFilter(string key)
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

        public static bool SetFilter(string key, string value)
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

        public static XmlNodeList GetRomStatusNodes()
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

        public static XmlNode GetRomStatusNode(string platform, string rom)
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

        public static bool DelRomStatus(string platform, string rom)
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

        public static XmlNodeList GetRomLabelsNodes()
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

        public static XmlNode GetRomLabelsNode(string platform, string rom)
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

        public static bool DelRomLabels(string platform, string rom)
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
