using EmuLoader.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmuLoader.Core.Business
{
    public static class Developer
    {
        private static List<string> Developers { get; set; }

        public static List<string> GetAll()
        {
            return Developers.OrderBy(x => x).ToList();
        }

        public static void Fill(List<Rom> roms)
        {
            Developers = new List<string>();

            foreach (var item in roms)
            {
                if (string.IsNullOrEmpty(item.Developer)) continue;

                if (Developers.Contains(item.Developer)) continue;

                Developers.Add(item.Developer);
            }
        }
    }
}
