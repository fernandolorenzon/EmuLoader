using EmuLoader.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Xml;

namespace EmuLoader.Business
{
    public static class APIFunctions
    {
        static string baseurl = "https://api.thegamesdb.net";

        public static List<Rom> GetGamesListByPlatform(string platformId)
        {
            try
            {
                string key = Functions.LoadAPIKEY();
                string json = string.Empty;
                var url = baseurl + "/Games/ByPlatformID?apikey=" + key + "&id=" + platformId;

                using (WebClient client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    json = client.DownloadString(new Uri(url));
                }

                if (string.IsNullOrEmpty(json)) return null;

                var part = json.Substring(json.IndexOf("games\":") + 7);
                part = part.Substring(0, part.IndexOf("]},\"pages") + 1);
                var list = JsonConvert.DeserializeObject<List<API_Game>>(part);

                List<Rom> games = new List<Rom>();

                foreach (var game in list)
                {
                    games.Add(new Rom()
                    {
                        Id = game.id.ToString(),
                        DBName = game.game_title,
                        YearReleased = RomFunctions.GetYear(game.release_date)
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
            try
            {
                string key = Functions.LoadAPIKEY();
                string json = string.Empty;
                var url = baseurl + "/Games/ByGameName?apikey=" + key + "&name=" + name + "&platform=" + platformId;

                using (WebClient client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    json = client.DownloadString(new Uri(url));
                }

                if (string.IsNullOrEmpty(json)) return null;

                var genres = Genre.GetAll();

                var part = json.Substring(json.IndexOf("games\":") + 7);
                part = part.Substring(0, part.IndexOf("]},\"pages") + 1);
                var list = JsonConvert.DeserializeObject<List<API_Game>>(part);

                List<Rom> games = new List<Rom>();

                foreach (var game in list)
                {
                    games.Add(new Rom()
                    {
                        Id = game.id.ToString(),
                        DBName = game.game_title,
                        YearReleased = RomFunctions.GetYear(game.release_date)
                    });

                    return games[0];
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return null;
        }

        public static Rom GetGameDetails(string gameId)
        {
            try
            {
                string key = Functions.LoadAPIKEY();
                string json = string.Empty;
                var url = baseurl + "/Games/ByGameID?apikey=" + key + "&id=" + gameId;

                using (WebClient client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    json = client.DownloadString(new Uri(url));
                }

                if (string.IsNullOrEmpty(json)) return null;

                var genres = Genre.GetAll();

                var part = json.Substring(json.IndexOf("games\":") + 7);
                part = part.Substring(0, part.IndexOf("]},\"pages") + 1);
                var raw = JsonConvert.DeserializeObject(part);
                var game = JsonConvert.DeserializeObject<API_Game>(part);

                var result = new Rom();
                result.Id = game.id.ToString();
                result.DBName = game.game_title;
                result.YearReleased = RomFunctions.GetYear(game.release_date);

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }

            return null;
        }

        public static bool GetGameArtUrls(string gameId, out string boxArt, out string title, out string gameplay)
        {
            boxArt = string.Empty;
            title = string.Empty;
            gameplay = string.Empty;

            try
            {
                string key = Functions.LoadAPIKEY();
                string json = string.Empty;
                var url = baseurl + "/Games/Images?apikey=" + key + "&games_id=" + gameId;

                using (WebClient client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    json = client.DownloadString(new Uri(url));
                }

                if (string.IsNullOrEmpty(json)) return false;

                var genres = Genre.GetAll();

                var part = json.Substring(json.IndexOf("games\":") + 7);
                part = part.Substring(0, part.IndexOf("]},\"pages") + 1);
                var list = JsonConvert.DeserializeObject<List<API_Image>>(part);

                foreach (var item in list)
                {
                    if(item.type == "boxart")
                    {
                        boxArt = item.filename;
                        continue;
                    }

                    if (item.type == "screenshot")
                    {
                        title = item.filename;
                        continue;
                    }

                    if (item.type == "screenshot")
                    {
                        gameplay = item.filename;
                        continue;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            return false;
        }
    }
}
