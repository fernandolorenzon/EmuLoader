using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml;

namespace EmuLoader.Core.Models
{
    public class Genre : Base
    {
        public Color Color { get; set; }
        public bool Checked { get; set; }

        public Genre()
        {
            Name = "";
            Color = Color.White;
        }
    }
}
