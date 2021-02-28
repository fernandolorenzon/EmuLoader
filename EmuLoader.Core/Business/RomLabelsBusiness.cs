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

        public static bool Set(Rom rom, List<RomLabel> list)
        {
            XmlNode node = XML.GetRomLabelsNode(rom.Platform.Name, rom.FileName);

            if (node == null)
            {
                node = SetNode();
                XML.GetParentNode(XML.xmlRomLabels, "RomLabelList").AppendChild(node);
            }

            Functions.CreateOrSetXmlAttribute(XML.xmlRomLabels, node, "Platform", rom.Platform.Name);
            Functions.CreateOrSetXmlAttribute(XML.xmlRomLabels, node, "Rom", rom.FileName);

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

            var labels = new List<string>();

            foreach (var item in list)
            {
                labels.Add(item.Name);
            }

            var romlabels = new RomLabels(rom.Platform.Name, rom.FileName, labels);

            romLabelsList.Remove(romlabels.Key);
            romLabelsList.Add(romlabels.Key, romlabels);

            rom.RomLabels = romlabels;
            return true;
        }

        private static XmlNode SetNode()
        {
            XmlNode node = XML.xmlRomLabels.CreateNode(XmlNodeType.Element, "Romlabels", "");
            node.Attributes.Append(XML.xmlRomLabels.CreateAttribute("Platform"));
            node.Attributes.Append(XML.xmlRomLabels.CreateAttribute("Rom"));
            return node;
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
