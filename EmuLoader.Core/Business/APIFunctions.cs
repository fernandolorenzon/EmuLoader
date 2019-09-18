using EmuLoader.Core.Classes;
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
                var url = Values.BaseAPIURL + "/Games/ByPlatformID?apikey=" + key + "&id=" + platformId;

                while (true)
                {
                    using (WebClient client = new WebClient())
                    {
                        client.Encoding = System.Text.Encoding.UTF8;
                        json = client.DownloadString(new Uri(url));
                    }

                    if (string.IsNullOrEmpty(json)) return null;

                    //var jobject = (JObject)JsonConvert.DeserializeObject(json);
                    //games += jobject.SelectToken("data.games").ToString();
                    games += JsonFunctions.GetJsonValue(json, "data.games");

                    //var next = jobject.SelectToken("pages.next").ToString();
                    var next = JsonFunctions.GetJsonValue(json, "pages.next");

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

                //var jobject = (JArray)JsonConvert.DeserializeObject(json);
                var jobject = JsonFunctions.ParseJson(json);
                List<Rom> games = new List<Rom>();

                foreach (var game in jobject.Children)
                {
                    games.Add(new Rom()
                    {
                        Id = game.Children.First(x => x.Key == "id").Value,
                        DBName = game.Children.First(x => x.Key == "game_title").Value,
                        YearReleased = RomFunctions.GetYear(game.Children.First(x => x.Key == "release_date").Value)
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
                //var list = JsonConvert.DeserializeObject<List<API_Game>>(part);
                var list = JsonFunctions.ParseJson(part);

                List<Rom> games = new List<Rom>();

                foreach (var game in list.Children)
                {
                    games.Add(new Rom()
                    {
                        Id = game.Children.First(x => x.Key == "id").Value,
                        DBName = game.Children.First(x => x.Key == "game_title").Value,
                        YearReleased = RomFunctions.GetYear(game.Children.First(x => x.Key == "release_date").Value)
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
                var url = Values.BaseAPIURL + "/Games/ByGameID?apikey=" + key + "&id=" + gameId;

                using (WebClient client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    json = client.DownloadString(new Uri(url));
                }

                if (string.IsNullOrEmpty(json)) return null;

                var genres = Genre.GetAll();

                var result = new Rom();

                //var jobject = (JObject)JsonConvert.DeserializeObject(json);
                var jobject = JsonFunctions.ParseJson(json);
                var jgame = jobject.Children.First();
                result.Id = gameId;
                //result.DBName = jgame.SelectToken("game_title").ToString();
                result.DBName = jgame.Children.First(x => x.Key == "game_title").Value;
                //result.YearReleased = RomFunctions.GetYear(jgame.SelectToken("release_date").ToString());
                result.YearReleased = RomFunctions.GetYear(jgame.Children.First(x => x.Key == "release_date").Value);
                //result.Description = jobject.SelectToken("data.games").First().SelectToken("description").ToString();

                try
                {
                    //result.Publisher = publishers[Convert.ToInt32(jgame.SelectToken("publisher").ToString())];
                    result.Publisher = publishers[Convert.ToInt32(jgame.Children.First(x => x.Key == "publisher").Value)];
                }
                catch
                {

                }

                try
                {
                    //result.Developer = developers[Convert.ToInt32(jgame.SelectToken("developers").First().ToString())];
                    result.Developer = developers[Convert.ToInt32(jgame.Children.First(x => x.Key == "developers").Value)];
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
            //var jobject = (JObject)JsonConvert.DeserializeObject(text);
            var jobject = JsonFunctions.ParseJson(text);

            var publishers = jobject.Children.First(x => x.Key == "data.publishers");
            Dictionary<int, string> result = new Dictionary<int, string>();

            foreach (var item in publishers.Children)
            {
                var key = Convert.ToInt32(item.Children.First(x => x.Key == "id").Value);

                if (result.ContainsKey(key)) continue;

                result.Add(key, item.Children.First(x => x.Key == "name").Value);
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
            //var jobject = (JObject)JsonConvert.DeserializeObject(text);
            var jobject = JsonFunctions.ParseJson(text);

            //var publishers = jobject.SelectToken("data.developers").ToList();
            Dictionary<int, string> result = new Dictionary<int, string>();

            foreach (var item in jobject.Children)
            {
                var key = Convert.ToInt32(item.Key);

                if (result.ContainsKey(key)) continue;

                result.Add(key, item.Value);
            }

            return result;
        }

    }
}
