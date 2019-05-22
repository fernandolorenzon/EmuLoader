using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace EmuLoader.Classes
{
    public static class XML
    {
        public static XmlDocument xmlDoc;

        #region -- General --

        private static void CreateXml()
        {
            xmlDoc = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.InsertBefore(xmlDeclaration, xmlDoc.DocumentElement);
            xmlDoc.AppendChild(xmlDoc.CreateElement("Root"));

            XmlElement config = xmlDoc.CreateElement("Config");
            XmlAttribute attrPath = xmlDoc.CreateAttribute("ColumnPath");
            attrPath.Value = "true";
            config.Attributes.Append(attrPath);

            XmlAttribute attrDBName = xmlDoc.CreateAttribute("ColumnRomDBName");
            attrPath.Value = "false";
            config.Attributes.Append(attrDBName);

            XmlAttribute attrFileName = xmlDoc.CreateAttribute("ColumnFileName");
            attrFileName.Value = "false";
            config.Attributes.Append(attrFileName);

            XmlAttribute attrPlatform = xmlDoc.CreateAttribute("ColumnPlatform");
            attrPlatform.Value = "true";
            config.Attributes.Append(attrPlatform);

            XmlAttribute attrGenre = xmlDoc.CreateAttribute("ColumnGenre");
            attrGenre.Value = "true";
            config.Attributes.Append(attrGenre);

            XmlAttribute attrLabels = xmlDoc.CreateAttribute("ColumnLabels");
            attrLabels.Value = "true";
            config.Attributes.Append(attrLabels);

            XmlAttribute attrDeveloper = xmlDoc.CreateAttribute("ColumnDeveloper");
            attrLabels.Value = "true";
            config.Attributes.Append(attrDeveloper);

            XmlAttribute attrPublisher = xmlDoc.CreateAttribute("ColumnPublisher");
            attrLabels.Value = "true";
            config.Attributes.Append(attrPublisher);

            XmlAttribute attrYearReleased = xmlDoc.CreateAttribute("ColumnYearReleased");
            attrYearReleased.Value = "true";
            config.Attributes.Append(attrYearReleased);

            XmlAttribute attrBoxArt = xmlDoc.CreateAttribute("BoxArt");
            attrBoxArt.Value = "true";
            config.Attributes.Append(attrBoxArt);

            XmlAttribute attrTitle = xmlDoc.CreateAttribute("TitleArt");
            attrTitle.Value = "true";
            config.Attributes.Append(attrTitle);

            XmlAttribute attrGameplay = xmlDoc.CreateAttribute("GameplayArt");
            attrGameplay.Value = "true";
            config.Attributes.Append(attrGameplay);

            XmlAttribute attrPlatformsList = xmlDoc.CreateAttribute("PlatformsList");
            attrPlatformsList.Value = "true";
            config.Attributes.Append(attrPlatformsList);

            XmlAttribute attrExtension = xmlDoc.CreateAttribute("Extension");
            attrExtension.Value = "true";
            config.Attributes.Append(attrExtension);
            xmlDoc.ChildNodes[1].AppendChild(config);

            xmlDoc.ChildNodes[1].AppendChild(xmlDoc.CreateElement("Platforms"));
            xmlDoc.ChildNodes[1].AppendChild(xmlDoc.CreateElement("Labels"));
            xmlDoc.ChildNodes[1].AppendChild(xmlDoc.CreateElement("Genres"));
            xmlDoc.ChildNodes[1].AppendChild(xmlDoc.CreateElement("Roms"));

            XmlElement filter = xmlDoc.CreateElement("Filter");
            XmlAttribute attrFilterPlatform = xmlDoc.CreateAttribute("Platform");
            attrFilterPlatform.Value = "";
            config.Attributes.Append(attrFilterPlatform);

            XmlAttribute attrFilterGenre = xmlDoc.CreateAttribute("Genre");
            attrFilterGenre.Value = "";
            config.Attributes.Append(attrFilterGenre);

            XmlAttribute attrFilterLabel = xmlDoc.CreateAttribute("Label");
            attrFilterLabel.Value = "";
            config.Attributes.Append(attrFilterLabel);

            XmlAttribute attrFilterYear = xmlDoc.CreateAttribute("Year");
            attrFilterYear.Value = "";
            config.Attributes.Append(attrFilterYear);

            XmlAttribute attrFilterPublisher = xmlDoc.CreateAttribute("Publisher");
            attrFilterPublisher.Value = "";
            config.Attributes.Append(attrFilterPublisher);

            XmlAttribute attrFilterDeveloper = xmlDoc.CreateAttribute("Developer");
            attrFilterDeveloper.Value = "";
            config.Attributes.Append(attrFilterDeveloper);

            XmlAttribute attrFilterName = xmlDoc.CreateAttribute("Name");
            attrFilterName.Value = "";
            config.Attributes.Append(attrFilterName);

            xmlDoc.ChildNodes[1].AppendChild(filter);
            xmlDoc.Save(Values.xmlPath);
        }

        public static XmlDocument LoadXml()
        {
            xmlDoc = new XmlDocument();

            try
            {
                if (File.Exists(Values.xmlPath))
                {
                    xmlDoc.Load(Values.xmlPath);
                }
                else
                {
                    CreateXml();
                }
            }
            catch
            {
                if (File.Exists(Values.xmlPath))
                {
                    File.Delete(Values.xmlPath);
                    LoadXml();
                }
            }

            return xmlDoc;
        }

        public static void SaveXml()
        {
            xmlDoc.Save(Values.xmlPath);
        }

        public static XmlNode GetParentNode(string elementName)
        {
            try
            {
                foreach (var item in xmlDoc.ChildNodes[1].ChildNodes)
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
                return GetParentNode("Config").Attributes[key].Value;
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
                XmlNode config = GetParentNode("Config");
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

                XmlAttribute attr = xmlDoc.CreateAttribute(key);
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
                return GetParentNode("Platforms").ChildNodes;
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
                if (item.Attributes["Name"].Value == name)
                {
                    node = item;
                    break;
                }
            }

            if (node != null)
            {
                GetParentNode("Platforms").RemoveChild(node);
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
                return GetParentNode("Labels").ChildNodes;
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
                if (item.Attributes["Name"].Value == name)
                {
                    node = item;
                }
            }

            if (node != null)
            {
                GetParentNode("Labels").RemoveChild(node);
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
                return GetParentNode("Genres").ChildNodes;
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
                if (item.Attributes["Name"].Value == name)
                {
                    node = item;
                }
            }

            if (node != null)
            {
                GetParentNode("Genres").RemoveChild(node);
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
                return GetParentNode("Roms").ChildNodes;
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
                GetParentNode("Roms").RemoveChild(node);
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
                return GetParentNode("Filter").Attributes[key].Value;
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
                XmlNode config = GetParentNode("Filter");
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

                XmlAttribute attr = xmlDoc.CreateAttribute(key);
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

    }
}
