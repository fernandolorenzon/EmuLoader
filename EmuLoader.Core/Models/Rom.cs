using EmuLoader.Core.Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace EmuLoader.Core.Models
{
    public class Rom : Base
    {
        public string Id { get; set; }
        public string DBName { get; set; }
        public string Extension { get; private set; }
        public bool IdLocked { get; set; }
        public string Key
        {
            get
            {
                if (Platform == null) return "";
                return Platform.Name.ToLower() + FileName.ToLower();
            }
        }

        private string path;
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
                FileName = RomFunctions.GetFileName(path);
                FileNameNoExt = RomFunctions.GetFileNameNoExtension(path);
            }
        }
        public string FileName { get; private set; }
        public string FileNameNoExt { get; private set; }
        public string YearReleased { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public RomLabels RomLabels { get; set; }
        public Platform Platform { get; set; }
        public Genre Genre { get; set; }
        public bool Favorite { get; set; }
        public RomStatus Status { get; set; }
        public string Emulator { get; set; }

        public Rom()
        {
            Favorite = false;
        }
    }
}
