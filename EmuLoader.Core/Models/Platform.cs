using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml;

namespace EmuLoader.Core.Models
{
    public class Platform : Base
    {
        private static Dictionary<string, Platform> platforms { get; set; }
        public Color Color { get; set; }
        public bool ShowInList { get; set; }
        public bool ShowInFilter { get; set; }
        public string DefaultRomPath { get; set; }
        public string DefaultRomExtensions { get; set; }
        public bool UseRetroarch { get; set; }
        
        public string Id { get; set; }

        public Bitmap Icon { get; set; }

        public List<Emulator> Emulators { get; set; }

        public string DefaultEmulator { get; set; }
        public Platform()
        {
            Name = "";
            Emulators = new List<Emulator>();
            Color = Color.White;
        }
    }
}
