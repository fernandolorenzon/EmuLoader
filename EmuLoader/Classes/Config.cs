using System;
using System.Collections.Generic;
using System.Text;

namespace EmuLoader.Classes
{
    public static class Config
    {
        public static bool GetElementVisibility(string columName)
        {
            try
            {
                string value = XML.GetConfig(columName);

                if (string.IsNullOrEmpty(value)) return true;

                return Convert.ToBoolean(value);
            }
            catch
            {
                return true;
            }
        }

        public static void SetElementVisibility(string columnName, bool value)
        {
            XML.SetConfig(columnName, Convert.ToString(value));
        }
    }
}
