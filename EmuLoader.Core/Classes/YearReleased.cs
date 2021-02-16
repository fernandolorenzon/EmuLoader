using EmuLoader.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmuLoader.Core.Classes
{
    public static class YearReleased
    {
        private static List<string> YearsReleased { get; set; }

        public static List<string> GetAll()
        {
            return YearsReleased.OrderBy(x => x).ToList();
        }

        public static void Fill(List<Rom> roms)
        {
            YearsReleased = new List<string>();

            foreach (var item in roms)
            {
                if (string.IsNullOrEmpty(item.YearReleased)) continue;

                if (YearsReleased.Contains(item.YearReleased)) continue;

                YearsReleased.Add(item.YearReleased);
            }
        }
    }
}
