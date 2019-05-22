using EmuLoader.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmuLoader.Business
{
    public static class FilterFunctions
    {
        public static List<Rom> FilterRoms(string filter, string platform, string label, string genre, string publisher, string developer, string year)
        {
            List<Rom> FilteredRoms = new List<Rom>();
            //List<Platform> platforms = new List<Platform>();
            List<string> platforms = new List<string>();

            if (filter.StartsWith("p:"))
            {
                platforms = GetPlatforms(filter, out filter);
            }

            FilteredRoms = Rom.GetAll();

            if (string.IsNullOrEmpty(filter) &&
                string.IsNullOrEmpty(platform) &&
                string.IsNullOrEmpty(label) &&
                string.IsNullOrEmpty(genre) &&
                string.IsNullOrEmpty(publisher) &&
                string.IsNullOrEmpty(developer) &&
                string.IsNullOrEmpty(year) &&
                platforms.Count == 0)
            {
                return FilteredRoms;
            }

            try
            {
                if (platforms.Count > 0)
                {
                    var filterRoms = FilteredRoms.Where(x => x.Platform != null && platforms.Contains(x.Platform.Name.ToLower())).ToList();
                    FilteredRoms = filterRoms;
                }
                else if (!string.IsNullOrEmpty(platform))
                {
                    var filterRoms = platform == "<none>" ? FilteredRoms.Where(x => x.Platform == null).ToList() : FilteredRoms.Where(x => x.Platform != null && x.Platform.Name == platform).ToList();
                    FilteredRoms = filterRoms;
                }

                if (!string.IsNullOrEmpty(genre))
                {
                    var filterRoms = genre == "<none>" ? FilteredRoms.Where(x => x.Genre == null).ToList() : FilteredRoms.Where(x => x.Genre != null && x.Genre.Name == genre).ToList();
                    FilteredRoms = filterRoms;
                }

                if (!string.IsNullOrEmpty(label))
                {
                    var filterRoms = label == "<none>" ? FilteredRoms.Where(x => x.Labels == null || x.Labels.Count == 0).ToList() : FilteredRoms.Where(x => x.Labels.Any(l => l.Name == label)).ToList();
                    FilteredRoms = filterRoms;
                }

                if (!string.IsNullOrEmpty(label))
                {
                    var filterRoms = label == "<none>" ? FilteredRoms.Where(x => x.Labels == null || x.Labels.Count == 0).ToList() : FilteredRoms.Where(x => x.Labels.Any(l => l.Name == label)).ToList();
                    FilteredRoms = filterRoms;
                }

                if (!string.IsNullOrEmpty(publisher))
                {
                    var filterRoms = publisher == "<none>" ? FilteredRoms.Where(x => x.Publisher == string.Empty).ToList() : FilteredRoms.Where(x => x.Publisher == publisher).ToList();
                    FilteredRoms = filterRoms;
                }

                if (!string.IsNullOrEmpty(developer))
                {
                    var filterRoms = developer == "<none>" ? FilteredRoms.Where(x => x.Developer == string.Empty).ToList() : FilteredRoms.Where(x => x.Developer == developer).ToList();
                    FilteredRoms = filterRoms;
                }

                if (!string.IsNullOrEmpty(year))
                {
                    var filterRoms = year == "<none>" ? FilteredRoms.Where(x => x.YearReleased == string.Empty).ToList() : FilteredRoms.Where(x => x.YearReleased == year).ToList();
                    FilteredRoms = filterRoms;
                }

                if (!string.IsNullOrEmpty(filter))
                {
                    var filterRoms = FilteredRoms.Where(x => x.Name.ToLower().Contains(filter.ToLower())).ToList();
                    FilteredRoms = filterRoms;
                }
            }
            catch (Exception ex)
            {

            }

            return FilteredRoms;
        }

        public static bool SaveFilter(string name, string platform, string label, string genre, string publisher, string developer, string year)
        {
            XML.SetFilter("Name", name);
            XML.SetFilter("Platform", platform);
            XML.SetFilter("Label", label);
            XML.SetFilter("Genre", genre);
            XML.SetFilter("Publisher", publisher);
            XML.SetFilter("Developer", developer);
            XML.SetFilter("Year", year);

            return true;
        }

        public static bool GetFilter(out string name, out string platform, out string label, out string genre, out string publisher, out string developer, out string year)
        {
            name = XML.GetFilter("Name");
            platform = XML.GetFilter("Platform");
            label = XML.GetFilter("Label");
            genre = XML.GetFilter("Genre");
            publisher = XML.GetFilter("Publisher");
            developer = XML.GetFilter("Developer");
            year = XML.GetFilter("Year");

            return true;
        }

        private static List<string> GetPlatforms(string filter, out string romFilter)
        {
            romFilter = "";
            List<string> result = new List<string>();
            var term = filter.Replace("p:", "").ToCharArray();

            bool getWord = false;
            string word = "";
            bool getSpace = false;

            for (int i = 0; i < term.Length; i++)
            {
                var c = term[i];

                if (c == '\'')
                {
                    getSpace = !getSpace;
                }

                if (c == '|' && getSpace)
                {
                    getSpace = false;
                }

                if (c == '|' || c == '\'' || i == term.Length)
                {
                    getWord = false;
                }
                else
                {
                    getWord = true;
                }

                if (c == ' ' && !getSpace)
                {
                    result.Add(word.ToLower());
                    romFilter = filter.Substring(i + 3);
                    return result;
                }

                if (getWord)
                {
                    word += c;
                }

                if ((c == '|' || c == '\'') && !getWord && word != "")
                {
                    getWord = true;
                    result.Add(word.ToLower());
                    word = "";
                }
            }

            if(getWord && word != "")
            {
                result.Add(word.ToLower());
            }

            return result;
        }
    }
}
