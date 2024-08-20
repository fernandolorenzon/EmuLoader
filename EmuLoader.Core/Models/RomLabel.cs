using System.Drawing;
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
