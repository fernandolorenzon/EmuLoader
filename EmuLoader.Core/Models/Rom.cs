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

        public string FileName { get; set; }
        public string FileNameNoExt { get; set; }
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
        public string Series { get; set; }

        public Rom()
        {
            Favorite = false;
        }
    }
}
