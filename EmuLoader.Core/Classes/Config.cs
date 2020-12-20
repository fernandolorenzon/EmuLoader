using System;

namespace EmuLoader.Core.Classes
{
    public static class Config
    {

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
