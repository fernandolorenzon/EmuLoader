using EmuLoader.Core.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace EmuLoader.Core.Business
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
                var url = Values.BaseAPIURL + "/v1/Games/ByPlatformID?apikey=" + key + "&id=" + platformId;

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

                var platform = Platform.GetAll().FirstOrDefault(x => x.Id == platformId);

                if (platform != null)
                {
                    if (!Directory.Exists(Values.JsonFolder))
                    {
                        Directory.CreateDirectory(Values.JsonFolder);
                    }

                    File.WriteAllText(Values.JsonFolder + "\\" + platform.Name + ".json", games);
                }

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
                var url = Values.BaseAPIURL + "/v1.1/Games/ByGameName?apikey=" + key + "&name=" + name + "&platform=" + platformId;

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
                    if (game.platform.ToString() != platformId) continue;
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
                var developers = GetDevelopers();

                string key = Functions.LoadAPIKEY();
                string json = string.Empty;
                var url = Values.BaseAPIURL + "/v1/Games/ByGameID?apikey=" + key + "&id=" + gameId;

                using (WebClient client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    json = client.DownloadString(new Uri(url));
                }

                if (string.IsNullOrEmpty(json)) return null;

                var result = new Rom();

                var jobject = (JObject)JsonConvert.DeserializeObject(json);
                var jgame = jobject.SelectToken("data.games").First();
                result.Id = gameId;
                result.DBName = jgame.SelectToken("game_title").ToString();
                result.YearReleased = RomFunctions.GetYear(jgame.SelectToken("release_date").ToString());
                //result.Description = jobject.SelectToken("data.games").First().SelectToken("description").ToString();
                
                result.Platform = new Platform();

                try
                {
                    var jplatform = jgame.SelectToken("platform");

                    if (jplatform != null)
                    {
                        result.Platform.Id = jplatform.ToString();
                        var list = Functions.GetPlatformsXML();
                        result.Platform.Name = list[result.Platform.Id];
                    }
                }
                catch
                {

                }

                try
                {
                    var jpublisher = jgame.SelectToken("publisher");

                    if (jpublisher != null)
                    {
                        result.Publisher = publishers[Convert.ToInt32(jpublisher.ToString())];
                    }
                }
                catch
                {

                }

                try
                {
                    var jdevelopers = jgame.SelectToken("developers");

                    if (jdevelopers != null)
                    {
                        result.Developer = developers[Convert.ToInt32(jdevelopers.First().ToString())];
                    }
                }
                catch
                {

                }

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
                var url = Values.BaseAPIURL + "/v1/Games/Images?apikey=" + key + "&games_id=" + gameId;

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

                if (json.Contains(string.Format(@"titlescreen\/{0}-1.jpg", gameId)))
                {
                    title = string.Format("https://cdn.thegamesdb.net/images/medium/titlescreen/{0}-1.jpg", gameId);
                }

                if (json.Contains(string.Format(@"screenshot\/{0}-1.jpg", gameId)))
                {
                    gameplay = string.Format("https://cdn.thegamesdb.net/images/medium/screenshot/{0}-1.jpg", gameId);
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
                if (File.Exists(Values.JsonFolder + "\\" + Values.PublishersFile))
                {
                    return readPublishers();
                }

                string key = Functions.LoadAPIKEY();
                string json = string.Empty;
                var url = Values.BaseAPIURL + "/Publishers?apikey=" + key;

                using (WebClient client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    json = client.DownloadString(new Uri(url));
                }

                if (string.IsNullOrEmpty(json)) return result;

                File.WriteAllText(Values.JsonFolder + "\\" + Values.PublishersFile, json);

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
            var text = File.ReadAllText(Values.JsonFolder + "\\" + Values.PublishersFile);
            var jobject = (JObject)JsonConvert.DeserializeObject(text);

            var publishers = jobject.SelectToken("data.publishers").ToList();
            Dictionary<int, string> result = new Dictionary<int, string>();

            foreach (var item in publishers)
            {
                var key = Convert.ToInt32(item.First().SelectToken("id"));

                if (result.ContainsKey(key)) continue;

                result.Add(key, item.First().SelectToken("name").ToString());
            }

            return result;
        }

        public static Dictionary<int, string> GetDevelopers()
        {
            var result = new Dictionary<int, string>();

            try
            {
                if (File.Exists(Values.JsonFolder + "\\" + Values.DevelopersFile))
                {
                    return readDevelopers();
                }

                string key = Functions.LoadAPIKEY();
                string json = string.Empty;
                var url = Values.BaseAPIURL + "/Developers?apikey=" + key;

                using (WebClient client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    json = client.DownloadString(new Uri(url));
                }

                if (string.IsNullOrEmpty(json)) return result;

                File.WriteAllText(Values.JsonFolder + "\\" + Values.DevelopersFile, json);

                return readDevelopers();
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

        private static Dictionary<int, string> readDevelopers()
        {
            var text = File.ReadAllText(Values.JsonFolder + "\\" + Values.DevelopersFile);
            var jobject = (JObject)JsonConvert.DeserializeObject(text);

            var publishers = jobject.SelectToken("data.developers").ToList();
            Dictionary<int, string> result = new Dictionary<int, string>();

            foreach (var item in publishers)
            {
                var key = Convert.ToInt32(item.First().SelectToken("id"));

                if (result.ContainsKey(key)) continue;

                result.Add(key, item.First().SelectToken("name").ToString());
            }

            return result;
        }
    }
}
