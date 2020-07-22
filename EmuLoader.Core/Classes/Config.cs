using System;

namespace EmuLoader.Core.Classes
{
    public static class Config
    {
        public static bool SaveFilter(Filter filter)
        {
            XML.SetFilter("Text", filter.text);
            XML.SetFilter("Platform", filter.platform);
            XML.SetFilter("Label", filter.label);
            XML.SetFilter("Genre", filter.genre);
            XML.SetFilter("Publisher", filter.publisher);
            XML.SetFilter("Developer", filter.developer);
            XML.SetFilter("Year", filter.year);
            XML.SetFilter("Favorite", filter.favorite.ToString());
            XML.SetFilter("Rom", filter.rom);

            return true;
        }

        public static Filter GetFilter()
        {
            Filter filter = new Filter();
            filter.text = XML.GetFilter("Text");
            filter.platform = XML.GetFilter("Platform");
            filter.label = XML.GetFilter("Label");
            filter.genre = XML.GetFilter("Genre");
            filter.publisher = XML.GetFilter("Publisher");
            filter.developer = XML.GetFilter("Developer");
            filter.year = XML.GetFilter("Year");
            var favorite = XML.GetFilter("Favorite");
            filter.favorite = string.IsNullOrEmpty(favorite) ? false : Convert.ToBoolean(favorite);
            filter.rom = XML.GetFilter("Rom");

            return filter;
        }

        public static bool GetElementVisibility(Column column)
        {
            try
            {
                string value = XML.GetConfig(column.ToString());

                if (string.IsNullOrEmpty(value)) return true;

                return Convert.ToBoolean(value);
            }
            catch
            {
                return true;
            }
        }

        public static void SetElementVisibility(Column column, bool value)
        {
            XML.SetConfig(column.ToString(), Convert.ToString(value));
        }

        public static string GetFolder(Folder folder)
        {
            try
            {
                string value = XML.GetConfig(folder.ToString());

                if (string.IsNullOrEmpty(value)) return "";

                return value;
            }
            catch
            {
                return "";
            }
        }

        public static void SetFolder(Folder folder, string path)
        {
            XML.SetConfig(folder.ToString(), path);
        }
    }
}
