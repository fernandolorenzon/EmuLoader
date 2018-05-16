using EmuLoader.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;

namespace EmuLoader.Business
{
    public static class SyncDataFunctions
    {
        public static string DiscoverGameId(Rom rom)
        {
            if (rom.Platform == null) return string.Empty;

            if (string.IsNullOrEmpty(rom.Platform.Id)) return string.Empty;

            var games = GetGamesListByPlatform(rom.Platform.Id);
            var romName = RomFunctions.TrimRomName(rom.Name);

            foreach (var game in games)
            {
                var gameName = RomFunctions.TrimRomName(game.DBName);
                
                if (gameName == romName)
                {
                    return game.Id;
                }
            }

            return string.Empty;
        }

        public static List<Rom> GetGamesListByPlatform(string platformId)
        {
            try
            {
                string xml = string.Empty;

                using (WebClient client = new WebClient())
                {
                    xml = client.DownloadString(new Uri("http://thegamesdb.net/api/GetPlatformGames.php?platform=" + platformId));
                }

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                List<Rom> games = new List<Rom>();

                foreach (XmlNode item in doc.ChildNodes[1].ChildNodes)
                {
                    games.Add(new Rom()
                    {
                        Id = item.ChildNodes[0].InnerText,
                        DBName = item.ChildNodes[1].InnerText,
                        YearReleased = RomFunctions.GetYear(item.ChildNodes[2])
                    });
                }

                return games.OrderBy(x => x.Name).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Rom GetGameByName(string platformId, string name)
        {
            Rom game = null;

            try
            {
                string xml = string.Empty;

                using (WebClient client = new WebClient())
                {
                    var url = string.Format("http://thegamesdb.net/api/GetGame.php?name={0}&platformid={1}", name, platformId);
                    xml = client.DownloadString(new Uri(url));
                }

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                var genres = Genre.GetAll();

                var games = new List<string>();

                foreach (XmlNode gameNode in doc.ChildNodes[1].ChildNodes)
                {
                    var platformNode = gameNode.SelectSingleNode("PlatformId");

                    if (platformNode == null || (platformNode != null && platformNode.InnerText != platformId)) continue;

                    foreach (XmlNode contentNode in gameNode.ChildNodes)
                    {
                        if (contentNode.Name.ToLower() == "id")
                        {
                            game = new Rom();
                            game.Id = contentNode.InnerText;
                        }

                        if (contentNode.Name.ToLower() == "gametitle")
                        {
                            if (game == null)
                            {
                                game = new Rom();
                            }

                            game.DBName = contentNode.InnerText;
                        }

                        if (contentNode.Name.ToLower() == "releasedate")
                        {
                            if (game == null)
                            {
                                game = new Rom();
                            }

                            game.YearReleased = RomFunctions.GetYear(contentNode);
                        }
                    }

                    return game;
                }
            }
            catch (Exception ex)
            {
                return game;
            }

            return game;
        }

        public static Rom GetGameDetails(string gameId)
        {
            Rom game = new Rom();

            try
            {
                string xml = string.Empty;

                using (WebClient client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    xml = client.DownloadString(new Uri("http://thegamesdb.net/api/GetGame.php?id=" + gameId));
                }

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                var genres = Genre.GetAll();

                foreach (XmlNode item in doc.ChildNodes[1].ChildNodes[1].ChildNodes)
                {
                    if (item.Name.ToLower() == "releasedate")
                    {
                        game.YearReleased = RomFunctions.GetYear(item);
                    }

                    if (item.Name == "GameTitle")
                    {
                        game.DBName = item.InnerText;
                        continue;
                    }

                    if (item.Name == "Overview")
                    {
                        game.Description = string.IsNullOrEmpty(game.Description) ? item.InnerText : game.Description;
                        continue;
                    }

                    if (item.Name == "Publisher")
                    {
                        game.Publisher = string.IsNullOrEmpty(game.Publisher) ? item.InnerText : game.Publisher;
                        continue;
                    }

                    if (item.Name == "Developer")
                    {
                        game.Developer = string.IsNullOrEmpty(game.Developer) ? item.InnerText : game.Developer;
                        continue;
                    }

                    if (item.Name == "Rating")
                    {
                        game.Rating = game.Rating == 0 || string.IsNullOrEmpty(item.InnerText) ? float.Parse(item.InnerText.Replace(",", "."), CultureInfo.InvariantCulture) : game.Rating;
                        continue;
                    }

                    if (item.Name == "Genres")
                    {
                        if (game.Genre != null) continue;

                        List<Genre> gameGenres = new List<Genre>();

                        foreach (XmlNode genreNode in item.ChildNodes)
                        {
                            if (string.IsNullOrEmpty(genreNode.InnerText)) continue;

                            var matchGenre = genres.Where(x => x.Name == genreNode.InnerText).FirstOrDefault();
                            Genre newGenre = null;

                            if (matchGenre != null)
                            {
                                gameGenres.Add(matchGenre);
                            }
                            else
                            {
                                newGenre = RomFunctions.CreateNewGenre(genreNode.InnerText);
                                gameGenres.Add(newGenre);
                            }

                            game.Genre = RomFunctions.PrioritizeGenre(gameGenres);

                            //If the genre set to the rom is a newly created one, it must be saved
                            if (newGenre != null && (newGenre.Name == game.Genre.Name))
                            {
                                genres.Add(newGenre);
                                Genre.Set(newGenre);
                            }
                        }
                    }
                }

                return game;
            }
            catch (Exception ex)
            {
                return game;
            }
        }

        public static bool GetGameArtUrls(string gameId, out string boxArt, out string title, out string gameplay)
        {
            bool result = false;
            boxArt = string.Empty;
            title = string.Empty;
            gameplay = string.Empty;

            try
            {
                string xml = string.Empty;

                using (WebClient client = new WebClient())
                {
                    xml = client.DownloadString(new Uri("http://thegamesdb.net/api/GetArt.php?id=" + gameId));
                }

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                foreach (XmlNode item in doc.ChildNodes[1].ChildNodes[1].ChildNodes)
                {
                    if (item.Name == "boxart" && item.Attributes.Count > 0 && item.Attributes[0].Name == "side" && item.Attributes[0].Value == "front")
                    {
                        boxArt = "http://thegamesdb.net/banners/" + item.InnerText;
                        result = true;
                        continue;
                    }

                    if (item.Name == "banner")
                    {
                        title = "http://thegamesdb.net/banners/" + item.InnerText;
                        result = true;
                        continue;
                    }

                    if (item.Name == "screenshot")
                    {
                        gameplay = "http://thegamesdb.net/banners/" + item.ChildNodes[0].InnerText;
                        result = true;
                        continue;
                    }

                }

                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public static void SavePictureFromUrl(Rom rom, string url, string folder, bool saveAsJPG)
        {
            try
            {
                if (string.IsNullOrEmpty(url)) return;

                string extension = url.Substring(url.LastIndexOf("."));
                string imagePath = "image" + extension;

                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(new Uri(url), imagePath);
                }

                RomFunctions.SavePicture(rom, imagePath, folder, saveAsJPG);
                File.Delete(imagePath);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
