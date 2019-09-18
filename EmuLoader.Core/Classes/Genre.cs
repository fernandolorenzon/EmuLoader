using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Xml;

namespace EmuLoader.Core.Classes
{
    public class Genre : Base
    {
        private static Dictionary<string, Genre> genres { get; set; }
        public Color Color {get; set;}
        public bool Checked { get; set; }

        public Genre()
        {
            Name = "";
            Color = Color.White;
        }

        public static void Fill()
        {
            genres = new Dictionary<string, Genre>();

            foreach (XmlNode node in XML.GetGenreNodes())
            {
                Genre genre = new Genre();
                genre.Name = node.Attributes["Name"].Value;
                genre.Color = Color.FromArgb((Convert.ToInt32(node.Attributes["Color"].Value)));
                genres.Add(genre.Name, genre);
            }
        }

        public static Genre Get(string name)
        {
            try
            {
                if (genres.ContainsKey(name))
                {
                    return genres[name];
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public static List<Genre> GetAll()
        {
            List<Genre> result = new List<Genre>();

            foreach (var item in genres.Values)
            {
                result.Add(item);
            }

            return (from r in result orderby r.Name select r).ToList();
        }

        public static bool Set(Genre genre)
        {
            XmlNode node = XML.GetGenreNode(genre.Name);
            
            if (node == null)
            {
                node = XML.xmlDoc.CreateNode(XmlNodeType.Element, "Genre", "");
                node.Attributes.Append(XML.xmlDoc.CreateAttribute("Name"));
                node.Attributes.Append(XML.xmlDoc.CreateAttribute("Color"));
                XML.GetParentNode("Genres").AppendChild(node);
                genres.Add(genre.Name, genre);
            }

            genres[genre.Name] = genre;
            node.Attributes["Name"].Value = genre.Name;
            node.Attributes["Color"].Value = genre.Color.ToArgb().ToString();
            
            return true;
        }

        public static bool ChangeRomsGenre(List<Rom> roms, Genre genre)
        {
            foreach (var item in roms)
            {
                item.Genre = genre;
                Rom.Set(item);
            }

            return true;
        }

        public static bool Delete(string name)
        {
            genres.Remove(name);
            return XML.DelGenre(name);
        }
    }
}
