using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuLoader.Core.Classes
{
    public abstract class Base
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
