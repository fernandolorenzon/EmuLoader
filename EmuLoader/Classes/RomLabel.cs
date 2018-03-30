using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;

namespace EmuLoader.Classes
{
    public class RomLabel
    {
        private static Dictionary<string, RomLabel> labels { get; set; }
        public string Name {get; set;}
        public Color Color {get; set;}
        public CheckState CheckState { get; set; }

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
                labels.Add(label.Name, label);
            }
        }

        public static RomLabel Get(string name)
        {
            try
            {
                if (labels.ContainsKey(name))
                {
                    return labels[name];
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
                node = XML.xmlDoc.CreateNode(XmlNodeType.Element, "Label", "");
                node.Attributes.Append(XML.xmlDoc.CreateAttribute("Name"));
                node.Attributes.Append(XML.xmlDoc.CreateAttribute("Color"));
                XML.GetParentNode("Labels").AppendChild(node);
                labels.Add(label.Name, label);
            }

            labels[label.Name] = label;
            node.Attributes["Name"].Value = label.Name;
            node.Attributes["Color"].Value = label.Color.ToArgb().ToString();
            
            return true;
        }

        public static bool Delete(string name)
        {
            labels.Remove(name);
            return XML.DelLabel(name);
        }
    }
}
