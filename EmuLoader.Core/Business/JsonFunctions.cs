using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuLoader.Core.Business
{
    public static class JsonFunctions
    {

        public static string GetJsonValue(string json, string key)
        {
            if (key == "") return json;

            var index = json.IndexOf("\"" + key + "\"") + key.Length + 2;

            if (index == -1) return "";

            var result = json.Substring(index);
            var doispontosIndex = result.IndexOf(":");
            result = result.Substring(doispontosIndex + 1);

            var chars = result.ToCharArray();

            //é numero
            int r = 0;
            if (int.TryParse(chars[0].ToString(), out r))
            {
                result = "";

                foreach (var item in chars)
                {
                    if (int.TryParse(item.ToString(), out r))
                    {
                        result += item;
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            else if (chars[0] == 'n' && chars[1] == 'u' && chars[2] == 'l' && chars[3] == 'l')
            {
                return null;
            }

            //é string
            index = result.IndexOf("\"");
            result = result.Substring(index + 1);
            index = result.IndexOf("\"");
            result = result.Substring(0, index);
            return result;
        }

        public static JsonNode ParseJson(string json)
        {
            JsonNode result = new JsonNode();

            bool begin = false;
            bool end = false;
            bool beginkey = false;
            bool endkey = false;
            bool beginvalue = false;
            bool endvalue = false;
            bool pastKey = false;
            bool isnumber = true;
            var chararray = json.ToCharArray();
            string key = "";
            string value = "";

            foreach (var item in chararray)
            {
                if (endkey && endvalue)
                {
                    result.Attributes.Add(key, value);
                    key = "";
                    value = "";
                    beginkey = false;
                    beginvalue = false;
                    endkey = false;
                    endvalue = false;
                    pastKey = false;
                    isnumber = false;
                }

                if (item == '{')
                {
                    begin = true;
                    continue;
                }
                else if (item == '}')
                {
                    end = true;
                    continue;
                }

                if (pastKey && !beginvalue && item == ' ')
                {
                    continue;
                }

                if (endkey && pastKey && item != '"' && !beginvalue)
                {
                    int r = 0;

                    if (int.TryParse(item.ToString(), out r))
                    {
                        beginvalue = true;
                        isnumber = true;
                    }
                    else
                    {
                        value = null;
                        endvalue = true;
                        continue;
                    }
                }

                if (item == '"' && !beginkey && !endkey)
                {
                    beginkey = true;
                    continue;
                }
                else if (item == '"' && beginkey && !endkey)
                {
                    beginkey = false;
                    endkey = true;
                    continue;
                }

                if (beginkey && !endkey)
                {
                    key += item;
                    continue;
                }

                if (item == '"' && !beginvalue && !endvalue)
                {
                    beginvalue = true;
                    continue;
                }
                else if (item == '"' && beginvalue && !endvalue)
                {
                    beginvalue = false;
                    endvalue = true;
                    continue;
                }
                else if (isnumber && (item == ',' || item == '}'))
                {
                    endvalue = true;
                }

                if (item == ':' && endkey && !beginvalue)
                {
                    pastKey = true;
                    continue;
                }

                if (item == ',' && endvalue)
                {
                    continue;
                }

                if (beginvalue && !endvalue)
                {
                    value += item;
                    continue;
                }

            }

            if (end) return result;

            return result;
        }
    }

    public class JsonNode
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
        public Dictionary<string, List<JsonNode>> AttributesChildren { get; set; }
        public List<JsonNode> Children { get; set; }

        public JsonNode()
        {
            Attributes = new Dictionary<string, string>();
            AttributesChildren = new Dictionary<string, List<JsonNode>>();
            Children = new List<JsonNode>();
        }
    }
}
