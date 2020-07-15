using System.Collections.Generic;
using System.Linq;

namespace EmuLoader.Core.Classes
{
    public static class Publisher
    {
        private static List<string> Publishers { get; set; }

        public static List<string> GetAll()
        {
            return Publishers.OrderBy(x => x).ToList();
        }

        public static void Fill(List<Rom> roms)
        {
            Publishers = new List<string>();

            foreach (var item in roms)
            {
                if (string.IsNullOrEmpty(item.Publisher)) continue;

                if (Publishers.Contains(item.Publisher)) continue;

                Publishers.Add(item.Publisher);
            }
        }
    }
}
