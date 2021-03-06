﻿namespace EmuLoader.Core.Models
{
    public class Filter
    {
        public string text { get; set; }
        public string textType { get; set; }
        public string platform { get; set; }
        public string label { get; set; }
        public string genre { get; set; }
        public string status { get; set; }
        public string publisher { get; set; }
        public string developer { get; set; }
        public string year { get; set; }
        public bool favorite { get; set; }
        public string romfile { get; set; }
        public string romplatform { get; set; }
        public bool arcade { get; set;}
        public bool console { get; set; }
        public bool handheld { get; set; }
        public bool cd { get; set; }
    }
}
