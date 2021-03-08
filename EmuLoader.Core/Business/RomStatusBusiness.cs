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
    public static class RomStatusBusiness
    {
        private static Dictionary<string, RomStatus> romStatuses { get; set; }

        public static RomStatus Get(string platform, string rom)
        {
            try
            {
                if (romStatuses.ContainsKey(platform.ToLower() + rom.ToLower()))
                {
                    return romStatuses[platform.ToLower() + rom.ToLower()];
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

        public static List<RomStatus> GetAll()
        {
            List<RomStatus> result = new List<RomStatus>();

            foreach (var item in romStatuses.Values)
            {
                result.Add(item);
            }

            return (from r in result select r).ToList();
        }

        public static bool SetRomStatus(List<Rom> roms, string status)
        {
            foreach (var item in roms)
            {
                Set(item, status);
            }
            
            XML.SaveXmlRomStatus();
            return true;
        }

        public static bool SetRomStatus(Rom rom, string status)
        {
            var ret = Set(rom, status);
            XML.SaveXmlRomStatus();
            return ret;
        }

        private static bool Set(Rom rom, string status)
        {
            RomStatus romstatus = new RomStatus(rom.Platform.Name, rom.FileName, status);
            rom.Status = romstatus;
            Set(romstatus);
            return true;
        }

        //public static bool SetRomStatus(List<RomStatus> romstatuses)
        //{
        //    foreach (var item in romstatuses)
        //    {
        //        Set(item);
        //    }
            
        //    XML.SaveXmlRomStatus();
        //    return true;
        //}

        public static bool SetRomStatus(RomStatus romstatus)
        {
            var ret = Set(romstatus);
            XML.SaveXmlRomStatus();
            return ret;
        }

        private static bool Set(RomStatus romstatus)
        {
            if (string.IsNullOrEmpty(romstatus.Status))
            {
                XML.DelRomStatus(romstatus.Platform, romstatus.Rom);
                if (romStatuses.ContainsKey(romstatus.Key))
                {
                    romStatuses.Remove(romstatus.Key);
                }
            }
            else
            {
                SetNode(romstatus.Platform, romstatus.Rom, romstatus.Status);

                if (!romStatuses.ContainsKey(romstatus.Key))
                {
                    romStatuses.Add(romstatus.Key, romstatus);
                }
                else
                {
                    romStatuses[romstatus.Key] = romstatus;
                }
            }

            
            return true;
        }

        private static void SetNode(string platform, string rom, string status)
        {
            XmlNode node = XML.GetRomStatusNode(platform.ToLower(), rom.ToLower());

            if (node == null)
            {
                node = CreateNode();
                XML.GetParentNode(XML.xmlRomStatus, "RomStatuses").AppendChild(node);
            }

            Functions.CreateOrSetXmlAttribute(XML.xmlRomStatus, node, "Platform", platform.ToLower());
            Functions.CreateOrSetXmlAttribute(XML.xmlRomStatus, node, "Rom", rom.ToLower());
            node.InnerText = status;
        }

        private static XmlNode CreateNode()
        {
            XmlNode node = XML.xmlRomStatus.CreateNode(XmlNodeType.Element, "RomStatus", "");
            node.Attributes.Append(XML.xmlRomStatus.CreateAttribute("Platform"));
            node.Attributes.Append(XML.xmlRomStatus.CreateAttribute("Rom"));
            return node;
        }

        public static void Fill()
        {
            romStatuses = new Dictionary<string, RomStatus>();

            foreach (XmlNode node in XML.GetRomStatusNodes())
            {
                RomStatus romstatus = new RomStatus(node.Attributes["Platform"].Value, node.Attributes["Rom"].Value, node.InnerText);
                romStatuses.Add(romstatus.Platform.ToLower() + romstatus.Rom.ToLower(), romstatus);
            }
        }
    }
}
