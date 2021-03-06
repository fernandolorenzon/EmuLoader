﻿using EmuLoader.Core.Classes;
using EmuLoader.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmuLoader.Core.Business
{
    public static class FilterFunctions
    {
        public static bool SaveFilter(Filter filter)
        {
            XML.SetFilter("Text", filter.text);
            XML.SetFilter("TextType", filter.textType);
            XML.SetFilter("Platform", filter.platform);
            XML.SetFilter("Label", filter.label);
            XML.SetFilter("Genre", filter.genre);
            XML.SetFilter("Publisher", filter.publisher);
            XML.SetFilter("Developer", filter.developer);
            XML.SetFilter("Year", filter.year);
            XML.SetFilter("Status", filter.status);
            XML.SetFilter("Favorite", filter.favorite.ToString());
            XML.SetFilter("RomFile", filter.romfile);
            XML.SetFilter("RomPlatform", filter.romplatform);
            XML.SetFilter("Arcade", filter.arcade.ToString());
            XML.SetFilter("Console", filter.console.ToString());
            XML.SetFilter("Handheld", filter.handheld.ToString());
            XML.SetFilter("CD", filter.cd.ToString());
            XML.SaveXmlConfig();
            return true;
        }

        public static Filter GetFilter()
        {
            Filter filter = new Filter();
            filter.text = XML.GetFilter("Text");
            filter.textType = XML.GetFilter("TextType");
            filter.platform = XML.GetFilter("Platform");
            filter.label = XML.GetFilter("Label");
            filter.genre = XML.GetFilter("Genre");
            filter.publisher = XML.GetFilter("Publisher");
            filter.developer = XML.GetFilter("Developer");
            filter.year = XML.GetFilter("Year");
            filter.status = XML.GetFilter("Status");
            var favorite = XML.GetFilter("Favorite");
            filter.favorite = string.IsNullOrEmpty(favorite) ? false : Convert.ToBoolean(favorite);

            var arcade = XML.GetFilter("Arcade");
            filter.arcade = string.IsNullOrEmpty(arcade) ? false : Convert.ToBoolean(arcade);

            var console = XML.GetFilter("Console");
            filter.console = string.IsNullOrEmpty(console) ? false : Convert.ToBoolean(console);

            var handheld = XML.GetFilter("Handheld");
            filter.handheld = string.IsNullOrEmpty(handheld) ? false : Convert.ToBoolean(handheld);

            var cd = XML.GetFilter("CD");
            filter.cd = string.IsNullOrEmpty(cd) ? false : Convert.ToBoolean(cd);

            filter.romfile = XML.GetFilter("RomFile");
            filter.romplatform = XML.GetFilter("RomPlatform");

            return filter;
        }

        public static List<Rom> FilterRoms(Filter filter)
        {
            List<Rom> FilteredRoms = new List<Rom>();
            //List<Platform> platforms = new List<Platform>();
            List<string> platforms = new List<string>();
            
            if (filter.text.StartsWith("p:"))
            {
                var text = "";
                platforms = GetPlatforms(filter.text, out text);
                filter.text = text;
            }
            
            FilteredRoms = RomBusiness.GetAll();

            if (string.IsNullOrEmpty(filter.text) &&
                string.IsNullOrEmpty(filter.platform) &&
                string.IsNullOrEmpty(filter.label) &&
                string.IsNullOrEmpty(filter.genre) &&
                string.IsNullOrEmpty(filter.publisher) &&
                string.IsNullOrEmpty(filter.developer) &&
                string.IsNullOrEmpty(filter.year) &&
                string.IsNullOrEmpty(filter.status) &&
                !filter.favorite &&
                filter.arcade &&
                filter.console &&
                filter.handheld &&
                filter.cd &&
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
                else if (!string.IsNullOrEmpty(filter.platform))
                {
                    var filterRoms = filter.platform == "<none>" ? FilteredRoms.Where(x => x.Platform == null).ToList() : FilteredRoms.Where(x => x.Platform != null && x.Platform.Name == filter.platform).ToList();
                    FilteredRoms = filterRoms;
                }

                if (!string.IsNullOrEmpty(filter.genre))
                {
                    var filterRoms = filter.genre == "<none>" ? FilteredRoms.Where(x => x.Genre == null).ToList() : FilteredRoms.Where(x => x.Genre != null && x.Genre.Name == filter.genre).ToList();
                    FilteredRoms = filterRoms;
                }

                if (!string.IsNullOrEmpty(filter.status))
                {
                    var filterRoms = filter.status == "<none>" ? FilteredRoms.Where(x => x.Status.Status == string.Empty).ToList() : FilteredRoms.Where(x => x.Status != null && x.Status.Status == filter.status).ToList();
                    FilteredRoms = filterRoms;
                }

                if (!string.IsNullOrEmpty(filter.label))
                {
                    var filterRoms = filter.label == "<none>" ? FilteredRoms.Where(x => x.RomLabels == null || x.RomLabels == null).ToList() : FilteredRoms.Where(x => x.RomLabels != null && x.RomLabels.Labels.Any(l => l == filter.label)).ToList();
                    FilteredRoms = filterRoms;
                }

                if (!string.IsNullOrEmpty(filter.publisher))
                {
                    var filterRoms = filter.publisher == "<none>" ? FilteredRoms.Where(x => x.Publisher == string.Empty).ToList() : FilteredRoms.Where(x => x.Publisher == filter.publisher).ToList();
                    FilteredRoms = filterRoms;
                }

                if (!string.IsNullOrEmpty(filter.developer))
                {
                    var filterRoms = filter.developer == "<none>" ? FilteredRoms.Where(x => x.Developer == string.Empty).ToList() : FilteredRoms.Where(x => x.Developer == filter.developer).ToList();
                    FilteredRoms = filterRoms;
                }

                if (!string.IsNullOrEmpty(filter.year))
                {
                    var filterRoms = filter.year == "<none>" ? FilteredRoms.Where(x => x.YearReleased == string.Empty).ToList() : FilteredRoms.Where(x => x.YearReleased == filter.year).ToList();
                    FilteredRoms = filterRoms;
                }

                if (!string.IsNullOrEmpty(filter.text))
                {
                    var filterRoms = new List<Rom>();

                    if (filter.textType == "Starts with")
                    {
                        filterRoms = FilteredRoms.Where(x => x.Name.ToLower().StartsWith(filter.text.ToLower()) || (x.Series != null && x.Series.ToLower().StartsWith(filter.text.ToLower()))).ToList();
                    }
                    else if (filter.textType == "Ends with")
                    {
                        filterRoms = FilteredRoms.Where(x => x.Name.ToLower().EndsWith(filter.text.ToLower()) || (x.Series != null && x.Series.ToLower().EndsWith(filter.text.ToLower()))).ToList();
                    }
                    else
                    {
                        filterRoms = FilteredRoms.Where(x => x.Name.ToLower().Contains(filter.text.ToLower()) || (x.Series != null && x.Series.ToLower().Contains(filter.text.ToLower()))).ToList();
                    }

                    FilteredRoms = filterRoms;
                }

                if (filter.favorite)
                {
                    var filterRoms = FilteredRoms.Where(x => x.Favorite).ToList();
                    FilteredRoms = filterRoms;
                }

                if (filter.arcade || filter.console || filter.handheld || filter.cd)
                {
                    FilteredRoms = FilteredRoms.Where(x => (filter.arcade && x.Platform.Arcade) 
                        || (filter.console && x.Platform.Console)
                        || (filter.handheld && x.Platform.Handheld)
                        || (filter.cd && x.Platform.CD)
                        ).ToList();
                }
            }
            catch (Exception ex)
            {

            }

            return FilteredRoms;
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

            if (getWord && word != "")
            {
                result.Add(word.ToLower());
            }

            return result;
        }
    }
}
