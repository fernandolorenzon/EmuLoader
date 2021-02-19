using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuLoader.Core.Models
{
    public class RomLabels
    {
        public string Platform { get; set; }
        public string Rom { get; set; }
        public string Label { get; set; }

        public RomLabels(string platform, string rom, string label)
        {
            Platform = platform;
            Rom = rom;
            Label = label;
        }
    }
}
