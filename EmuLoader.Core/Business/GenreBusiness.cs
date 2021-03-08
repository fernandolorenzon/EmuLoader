using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using EmuLoader.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml;

namespace EmuLoader.Core.Business
{
    public static class GenreBusiness
    {
        private static Dictionary<string, Genre> genres { get; set; }

        public static void Fill()
        {
            genres = new Dictionary<string, Genre>();

            foreach (XmlNode node in XML.GetGenreNodes())
            {
                Genre genre = new Genre();
                genre.Name = node.Attributes["Name"].Value;
                genre.Color = Color.FromArgb((Convert.ToInt32(node.Attributes["Color"].Value)));
                genres.Add(genre.Name.ToLower(), genre);
            }
        }

        public static Genre Get(string name)
        {
            try
            {
                if (genres.ContainsKey(name.ToLower()))
                {
                    return genres[name.ToLower()];
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
                node = XML.xmlGenres.CreateNode(XmlNodeType.Element, "Genre", "");
                node.Attributes.Append(XML.xmlGenres.CreateAttribute("Name"));
                node.Attributes.Append(XML.xmlGenres.CreateAttribute("Color"));
                XML.GetParentNode(XML.xmlGenres, "Genres").AppendChild(node);
                genres.Add(genre.Name.ToLower(), genre);
            }

            genres[genre.Name.ToLower()] = genre;
            node.Attributes["Name"].Value = genre.Name;
            node.Attributes["Color"].Value = genre.Color.ToArgb().ToString();
            XML.SaveXmlGenres();
            return true;
        }

        public static bool ChangeRomsGenre(List<Rom> roms, Genre genre)
        {
            foreach (var item in roms)
            {
                item.Genre = genre;
            }

            RomBusiness.SetRom(roms);

            return true;
        }

        public static bool Delete(string name)
        {
            genres.Remove(name.ToLower());
            return XML.DelGenre(name);
        }
    }
}
