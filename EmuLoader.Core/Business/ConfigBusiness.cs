using EmuLoader.Core.Classes;
using System;

namespace EmuLoader.Core.Business
{
    public static class ConfigBusiness
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
            XML.SaveXmlConfig();
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
            XML.SaveXmlConfig();
        }

        public static string GetHeight()
        {
            return XML.GetConfig("Height");
        }

        public static string GetWidth()
        {
            return XML.GetConfig("Width");
        }

        public static bool SetHeight(string height)
        {
            return XML.SetConfig("Height", height);
        }

        public static bool SetWidth(string width)
        {
            return XML.SetConfig("Width", width);
        }
    }
}
