using System.Collections.Generic;

namespace EmuLoader.Core.Classes
{
    public class API_Game
    {
        public int id { get; set; }
        public string game_title { get; set; }
        public string release_date { get; set; }
        public int platform { get; set; }
        public List<int> developers { get; set; }
        public List<int> publishers { get; set; }
    }
}
