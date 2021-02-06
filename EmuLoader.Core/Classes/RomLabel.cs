using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
namespace EmuLoader.Core.Classes
{
    public class RomLabel : Base
    {
        private static Dictionary<string, RomLabel> labels { get; set; }
        public Color Color { get; set; }
        public bool Checked { get; set; }

        public RomLabel()
        {
            Name = "";
            Color = Color.White;
        }

        public static void Fill()
        {
            labels = new Dictionary<string, RomLabel>();

            foreach (XmlNode node in XML.GetLabelNodes())
            {
                RomLabel label = new RomLabel();
                label.Name = node.Attributes["Name"].Value;
                label.Color = Color.FromArgb((Convert.ToInt32(node.Attributes["Color"].Value)));
                labels.Add(label.Name.ToLower(), label);
            }
        }

        public static RomLabel Get(string name)
        {
            try
            {
                if (labels.ContainsKey(name.ToLower()))
                {
                    return labels[name.ToLower()];
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

        public static List<RomLabel> GetAll()
        {
            List<RomLabel> result = new List<RomLabel>();

            foreach (var item in labels.Values)
            {
                result.Add(item);
            }

            return result;
        }

        public static bool Set(RomLabel label)
        {
            XmlNode node = XML.GetLabelNode(label.Name);

            if (node == null)
            {
                node = XML.xmlLabels.CreateNode(XmlNodeType.Element, "Label", "");
                node.Attributes.Append(XML.xmlLabels.CreateAttribute("Name"));
                node.Attributes.Append(XML.xmlLabels.CreateAttribute("Color"));
                XML.GetParentNode(XML.xmlLabels, "Labels").AppendChild(node);
                labels.Add(label.Name.ToLower(), label);
            }

            labels[label.Name.ToLower()] = label;
            node.Attributes["Name"].Value = label.Name;
            node.Attributes["Color"].Value = label.Color.ToArgb().ToString();

            return true;
        }

        public static bool Delete(string name)
        {
            labels.Remove(name.ToLower());
            return XML.DelLabel(name);
        }
    }
}
