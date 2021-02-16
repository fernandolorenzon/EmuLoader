using EmuLoader.Core.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
namespace EmuLoader.Core.Models
{
    public class RomLabel : Base
    {
        public Color Color { get; set; }
        public bool Checked { get; set; }

        public RomLabel()
        {
            Name = "";
            Color = Color.White;
        }
    }
}
