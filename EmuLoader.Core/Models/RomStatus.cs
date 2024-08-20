namespace EmuLoader.Core.Models
{
    public class RomStatus
    {
        public string Platform { get; set; }
        public string Rom { get; set; }
        public string Status { get; set; }
        public string Key
        {
            get
            {
                return Platform.ToLower() + Rom.ToLower();
            }
        }

        public RomStatus(string platform, string rom, string status)
        {
            Platform = platform;
            Rom = rom;
            Status = status;
        }
    }
}
