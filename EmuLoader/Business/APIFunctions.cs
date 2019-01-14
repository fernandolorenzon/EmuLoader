using EmuLoader.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace EmuLoader.Business
{
    public static class APIFunctions
    {
        public static string GetGamesListJSONByPlatform(string platformId)
        {
            try
            {
                string games = string.Empty;
                string key = Functions.LoadAPIKEY();
                string json = string.Empty;
                var url = Values.BaseAPIURL + "/Games/ByPlatformID?apikey=" + key + "&id=" + platformId;

                while (true)
                {
                    using (WebClient client = new WebClient())
                    {
                        client.Encoding = System.Text.Encoding.UTF8;
                        json = client.DownloadString(new Uri(url));
                    }

                    if (string.IsNullOrEmpty(json)) return null;

                    var jobject = (JObject)JsonConvert.DeserializeObject(json);
                    games += jobject.SelectToken("data.games").ToString();

                    var next = jobject.SelectToken("pages.next").ToString();

                    if (string.IsNullOrEmpty(next))
                    {
                        break;
                    }

                    url = next;
                }

                games = games.Replace("][", ",");
                File.WriteAllText(games, json);
                return games;
            }
            catch (APIException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static List<Rom> GetGamesListByPlatform(string platformId, string json)
        {
            try
            {
                if (string.IsNullOrEmpty(json))
                {
                    json = GetGamesListJSONByPlatform(platformId);
                }

                if (json == null)
                {
                    throw new APIException("Cound not get json");
                }

                var jobject = (JArray)JsonConvert.DeserializeObject(json);
                List<Rom> games = new List<Rom>();

                foreach (var game in jobject)
                {
                    var objGame = (JObject)game;
                    games.Add(new Rom()
                    {
                        Id = objGame.SelectToken("id").ToString(),
                        DBName = objGame.SelectToken("game_title").ToString(),
                        YearReleased = RomFunctions.GetYear(objGame.SelectToken("release_date").ToString())
                    });
                }

                return games.OrderBy(x => x.Name).ToList();

            }
            catch (APIException ex)
            {
                throw new Exception(ex.Message);
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
                var url = Values.BaseAPIURL + "/Games/ByGameName?apikey=" + key + "&name=" + name + "&platform=" + platformId;

                using (WebClient client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    json = client.DownloadString(new Uri(url));
                }

                if (string.IsNullOrEmpty(json)) return null;

                var genres = Genre.GetAll();

                //var jobject = (JObject)JsonConvert.DeserializeObject(json);
                //var result = jobject.SelectToken("data.games").ToList();

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
            catch (APIException ex)
            {
                throw new Exception(ex.Message);
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
                var publishers = GetPublishers();

                string key = Functions.LoadAPIKEY();
                string json = string.Empty;
                var url = Values.BaseAPIURL + "/Games/ByGameID?apikey=" + key + "&id=" + gameId;

                using (WebClient client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    json = client.DownloadString(new Uri(url));
                }

                if (string.IsNullOrEmpty(json)) return null;

                var genres = Genre.GetAll();

                var result = new Rom();

                var jobject = (JObject)JsonConvert.DeserializeObject(json);
                result.Id = gameId;
                result.DBName = jobject.SelectToken("data.games").ToList()[0].SelectToken("game_title").ToString();
                result.YearReleased = RomFunctions.GetYear(jobject.SelectToken("data.games").ToList()[0].SelectToken("release_date").ToString());

                return result;
            }
            catch (APIException ex)
            {
                throw new Exception(ex.Message);
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
                var url = Values.BaseAPIURL + "/Games/Images?apikey=" + key + "&games_id=" + gameId;

                using (WebClient client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    json = client.DownloadString(new Uri(url));
                }

                if (string.IsNullOrEmpty(json)) return false;

                if (json.Contains(string.Format(@"boxart\/front\/{0}-1.jpg", gameId)))
                {
                    boxArt = string.Format("https://cdn.thegamesdb.net/images/medium/boxart/front/{0}-1.jpg", gameId);
                }

                if (json.Contains(string.Format(@"screenshots\/{0}-1.jpg", gameId)))
                {
                    gameplay = string.Format("https://cdn.thegamesdb.net/images/medium/screenshots/{0}-1.jpg", gameId);
                }

                return true;
            }
            catch (APIException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Dictionary<int, string> GetPublishers()
        {
            var result = new Dictionary<int, string>();

            try
            {
                if (File.Exists(Values.PublishersFile))
                {
                    return readPublishers();
                }

                string key = Functions.LoadAPIKEY();
                string json = string.Empty;
                var url = Values.BaseAPIURL + "/Games/Publishers?apikey=" + key;

                using (WebClient client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    json = client.DownloadString(new Uri(url));
                }

                if (string.IsNullOrEmpty(json)) return result;

                File.WriteAllText(Values.PublishersFile, json);

                return readPublishers();
            }
            catch (APIException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        private static Dictionary<int, string> readPublishers()
        {
            var text = File.ReadAllText(Values.PublishersFile);
            var jobject = (JObject)JsonConvert.DeserializeObject(text);

            var publishers = jobject.SelectToken("data.publishers").ToList();
            Dictionary<int, string> result = new Dictionary<int, string>();

            foreach (var item in publishers)
            {
                result.Add(Convert.ToInt32(item.SelectToken("id")), item.SelectToken("name").ToString());
            }

            return result;
        }
    }
}
