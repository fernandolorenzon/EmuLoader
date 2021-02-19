﻿using EmuLoader.Core.Business;
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

        public static bool Set(Rom rom, string status)
        {
            XmlNode node = XML.GetRomStatusNode(rom.Platform.Name, status);

            if (node == null)
            {
                node = SetNode();
                XML.GetParentNode(XML.xmlRomStatus, "RomStatuses").AppendChild(node);
            }

            Functions.CreateOrSetXmlAttribute(XML.xmlRomStatus, node, "Platform", rom.Platform.Name);
            Functions.CreateOrSetXmlAttribute(XML.xmlRomStatus, node, "Rom", rom.FileName);
            node.InnerText = status;

            var romstatus = new RomStatus(rom.Platform.Name, rom.Name, status);
            
            if (!romStatuses.ContainsKey(romstatus.Platform + romstatus.Rom))
            {
                romStatuses.Add(romstatus.Platform + romstatus.Rom, romstatus);
            }

            rom.Status = romstatus;

            return true;
        }

        public static bool Set(RomStatus romstatus)
        {
            XmlNode node = XML.GetRomStatusNode(romstatus.Platform, romstatus.Rom);

            if (node == null)
            {
                node = SetNode();
                XML.GetParentNode(XML.xmlRomStatus, "RomStatuses").AppendChild(node);
            }

            Functions.CreateOrSetXmlAttribute(XML.xmlRomStatus, node, "Platform", romstatus.Platform);
            Functions.CreateOrSetXmlAttribute(XML.xmlRomStatus, node, "Rom", romstatus.Rom);
            node.InnerText = romstatus.Status;

            if (!romStatuses.ContainsKey(romstatus.Platform + romstatus.Rom))
            {
                romStatuses.Add(romstatus.Platform + romstatus.Rom, romstatus);
            }
            
            return true;
        }

        private static XmlNode SetNode()
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
