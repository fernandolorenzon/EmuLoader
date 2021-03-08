using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using EmuLoader.Core.Models;
using System.Xml;

namespace EmuLoader.Core.Models
{
    public static class RomLabelsBusiness
    {
        private static Dictionary<string, RomLabels> romLabelsList { get; set; }

        public static RomLabels Get(string platform, string rom)
        {
            try
            {
                if (romLabelsList.ContainsKey(platform.ToLower() + rom.ToLower()))
                {
                    return romLabelsList[platform.ToLower() + rom.ToLower()];
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

        public static List<RomLabels> GetAll()
        {
            List<RomLabels> result = new List<RomLabels>();

            foreach (var item in romLabelsList.Values)
            {
                result.Add(item);
            }

            return (from r in result select r).ToList();
        }

        public static bool SetRomLabel(Rom rom, List<RomLabel> list)
        {
            Set(rom, list);
            XML.SaveXmlRomLabels();
            return true;
        }

        public static bool SetRomLabel(List<Rom> roms, List<RomLabel> list)
        {
            foreach (var item in roms)
            {
                Set(item, list);
            }
            
            XML.SaveXmlRomLabels();
            return true;
        }

        private static bool Set(Rom rom, List<RomLabel> list)
        {
            if (list == null || list.Count == 0)
            {
                XML.DelRomLabels(rom.Platform.Name, rom.FileName);
                if (romLabelsList.ContainsKey(rom.Platform.Name.ToLower() + rom.FileName.ToLower()))
                {
                    romLabelsList.Remove(rom.Platform.Name.ToLower() + rom.FileName.ToLower());
                }

                rom.RomLabels = null;
            }
            else
            {
                SetNode(rom.Platform.Name, rom.FileName, list);
                var labels = new List<string>();

                foreach (var item in list)
                {
                    labels.Add(item.Name);
                }

                var romlabels = new RomLabels(rom.Platform.Name, rom.FileName, labels);

                romLabelsList.Remove(romlabels.Key);
                romLabelsList.Add(romlabels.Key, romlabels);

                rom.RomLabels = romlabels;
            }

            return true;
        }

        private static XmlNode CreateNode()
        {
            XmlNode node = XML.xmlRomLabels.CreateNode(XmlNodeType.Element, "Romlabels", "");
            node.Attributes.Append(XML.xmlRomLabels.CreateAttribute("Platform"));
            node.Attributes.Append(XML.xmlRomLabels.CreateAttribute("Rom"));
            return node;
        }

        private static void SetNode(string platform, string rom, List<RomLabel> list)
        {
            XmlNode node = XML.GetRomLabelsNode(platform.ToLower(), rom.ToLower());

            if (node == null)
            {
                node = CreateNode();
                XML.GetParentNode(XML.xmlRomLabels, "RomLabelList").AppendChild(node);
            }

            Functions.CreateOrSetXmlAttribute(XML.xmlRomLabels, node, "Platform", platform.ToLower());
            Functions.CreateOrSetXmlAttribute(XML.xmlRomLabels, node, "Rom", rom.ToLower());

            if (node.ChildNodes.Count == 0)
            {
                node.AppendChild(XML.xmlRomLabels.CreateNode(XmlNodeType.Element, "Labels", ""));
            }

            node.ChildNodes[0].RemoveAll();

            foreach (var item in list)
            {
                var child = node.ChildNodes[0].AppendChild(XML.xmlRomLabels.CreateNode(XmlNodeType.Element, "Label", ""));
                child.InnerText = item.Name;
            }
        }

        public static void Fill()
        {
            romLabelsList = new Dictionary<string, RomLabels>();

            foreach (XmlNode node in XML.GetRomLabelsNodes())
            {
                var labels = new List<string>();

                foreach (XmlNode nodelabels in node.ChildNodes[0].ChildNodes)
                {
                    labels.Add(nodelabels.InnerText);
                }

                RomLabels romLabels = new RomLabels(node.Attributes["Platform"].Value, node.Attributes["Rom"].Value, labels);
                romLabelsList.Add(romLabels.Key, romLabels);
            }
        }
    }
}
