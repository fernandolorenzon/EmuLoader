﻿using System.Drawing;

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
        public string IconPath { get; set; }

        public List<Emulator> Emulators { get; set; }

        public string DefaultEmulator { get; set; }
        public bool Arcade { get; set; }
        public bool Console { get; set; }
        public bool Handheld { get; set; }
        public bool CD { get; set; }

        public Platform()
        {
            Name = "";
            Emulators = new List<Emulator>();
            Color = Color.White;
        }
    }
}
