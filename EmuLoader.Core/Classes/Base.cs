﻿namespace EmuLoader.Core.Classes
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
