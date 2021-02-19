using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static bool Set(RomLabels romLabels)
        {
            XmlNode node = XML.GetRomLabelsNode(romLabels.Platform, romLabels.Rom);

            if (node == null)
            {
                node = SetNode();
                XML.GetParentNode(XML.xmlRomLabels, "RomLabelList").AppendChild(node);
            }

            Functions.CreateOrSetXmlAttribute(XML.xmlRomLabels, node, "Platform", romLabels.Platform);
            Functions.CreateOrSetXmlAttribute(XML.xmlRomLabels, node, "Rom", romLabels.Rom);
            node.InnerText = romLabels.Label;
            return true;
        }

        public static bool SetList(List<RomLabels> list)
        {

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
                RomLabels romLabels = new RomLabels(node.Attributes["Platform"].Value, node.Attributes["Rom"].Value, node.InnerText);
                romLabelsList.Add(romLabels.Platform.ToLower() + romLabels.Rom.ToLower(), romLabels);
            }
        }
    }
}
