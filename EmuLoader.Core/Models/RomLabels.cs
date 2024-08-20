namespace EmuLoader.Core.Models
{
    public class RomLabels
    {
        public string Platform { get; set; }
        public string Rom { get; set; }
        public List<string> Labels { get; set; }
        public string Key
        {
            get
            {
                return Platform.ToLower() + Rom.ToLower();
            }
        }

        public RomLabels(string platform, string rom, List<string> labels)
        {
            Platform = platform;
            Rom = rom;
            Labels = labels;
        }
    }
}
