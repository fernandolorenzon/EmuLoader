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
    public class RomStatus
    {
        public string Platform { get; set; }
        public string Rom { get; set; }
        public string Status { get; set; }
        public string Key
        {
            get
            {
                return Platform.ToLower() + Rom.ToLower();
            }
        }

        public RomStatus(string platform, string rom, string status)
        {
            Platform = platform;
            Rom = rom;
            Status = status;
        }
    }
}
