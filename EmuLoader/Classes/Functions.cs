using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Linq;
using System.Xml;
using System.Net;
using System.Threading;

namespace EmuLoader.Classes
{
    public enum Region
    {
        USA,
        JPN,
        EUR,
        WLD,
        MSC,
        UNK
    }

    public static class Functions
    {
        public static void OpenApplication(Rom rom)
        {
            string exe = rom.Platform.EmulatorExe;
            string command = rom.Platform.Command;

            if (!string.IsNullOrEmpty(rom.EmulatorExe) && !string.IsNullOrEmpty(rom.Command))
            {
                exe = rom.EmulatorExe;
                command = rom.Command;
            }

            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = exe,
                    Arguments = command.Replace("%EMUPATH%", "")
                        .Replace("%ROMPATH%", "\"" + rom.Path + "\"")
                        .Replace("%ROMNAME%", GetFileNameNoExtension(rom.Path))
                        .Replace("%ROMFILE%", GetFileName(rom.Path)),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WorkingDirectory = rom.Platform.EmulatorExe.Substring(0, rom.Platform.EmulatorExe.LastIndexOf("\\"))
                }
            };

            proc.Start();

            //string exe = rom.Platform.Path;
            //string arguments = rom.Platform.Command.Replace("%EMUPATH%", "")
            //    .Replace("%ROMPATH%", "\"" + rom.Path + "\"")
            //    .Replace("%ROMNAME%", GetFileNameNoExtension(rom.Path))
            //    .Replace("%ROMFILE%", GetFileName(rom.Path));

            //ProcessStartInfo startInfo = new ProcessStartInfo(exe);

            //if (arguments.IndexOf(' ') == 0)
            //{
            //    arguments = arguments.Substring(1);
            //}

            //startInfo.Arguments = arguments;
            //Process p = new Process();

            //p = Process.Start(startInfo);
        }

        public static void OpenApplicationByCMD(Rom rom)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(@"cmd.exe");
            Process p = new Process();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            string arguments = rom.Platform.Command.Replace("%EMUPATH%", "\"" + rom.Platform.EmulatorExe + "\"")
                .Replace("%ROMPATH%", "\"" + rom.Path + "\"")
                .Replace("%ROMNAME%", GetFileNameNoExtension(rom.Path))
                .Replace("%ROMFILE%", GetFileName(rom.Path));

            startInfo.Arguments = arguments;
            p = Process.Start(startInfo);
        }

        public static void OpenApplicationByCMDWriteLine(Rom rom)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(@"cmd.exe");
            Process p = new Process();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            p = Process.Start(startInfo);

            string path = rom.Platform.Command.Replace("%EMUPATH%", "\"" + rom.Platform.EmulatorExe + "\"")
                .Replace("%ROMPATH%", "\"" + rom.Path + "\"")
                .Replace("%ROMNAME%", GetFileNameNoExtension(rom.Path))
                .Replace("%ROMFILE%", GetFileName(rom.Path));

            p.StandardInput.WriteLine(path);
            p.StandardInput.WriteLine("exit");
        }

        public static void OpenApplicationByCMDWriteLineCD(Rom rom)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("CMD.exe");
            Process p = new Process();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardInput = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            p = Process.Start(startInfo);

            string changeDir = "cd " + GetRomDirectory(rom.Platform.EmulatorExe);
            string exe = rom.Platform.EmulatorExe.Remove(0, rom.Platform.EmulatorExe.LastIndexOf("\\") + 1);
            string path = rom.Platform.Command.Replace("%EMUPATH%", "\"" + exe + "\"")
                .Replace("%ROMPATH%", "\"" + rom.Path + "\"")
                .Replace("%ROMNAME%", GetFileNameNoExtension(rom.Path))
                .Replace("%ROMFILE%", GetFileName(rom.Path));

            p.StandardInput.WriteLine(changeDir);
            p.StandardInput.WriteLine(path);
            p.StandardInput.WriteLine("exit");
        }

        public static void OpenApplication(Platform platform)
        {
            string exe = platform.EmulatorExe;

            ProcessStartInfo startInfo = new ProcessStartInfo(exe);
            Process p = new Process();

            p = Process.Start(startInfo);
        }

        public static void OpenApplicationByCMDWriteLine(Platform platform)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("CMD.exe");
            Process p = new Process();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardInput = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            p = Process.Start(startInfo);

            string changeDir = "cd " + GetRomDirectory(platform.EmulatorExe);
            string exe = platform.EmulatorExe.Remove(0, platform.EmulatorExe.LastIndexOf("\\") + 1);
            string path = "\"" + exe + "\"";

            p.StandardInput.WriteLine(changeDir);
            p.StandardInput.WriteLine(path);
            p.StandardInput.WriteLine("exit");
        }

        public static void RunPlatform(Rom rom)
        {
            if (rom.Platform == null)
            {
                throw new Exception("There ins't a platform associated to this ROM.");
            }

            OpenApplication(rom);
        }

        public static void RunPlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new Exception("Cannot open.");
            }

            OpenApplication(platform);
        }

        public static Color SetFontContrast(Color backColor)
        {
            int total = backColor.R + backColor.G + backColor.B;
            bool dark = backColor.R < 10 || backColor.G < 10 || backColor.B < 10;

            Color color = new Color();

            if (total < Values.Threshold && dark)
            {
                color = Color.White;
            }
            else
            {
                color = Color.Black;
            }

            return color;
        }

        public static string GetRomDirectory(string path)
        {
            return path.Remove(path.LastIndexOf("\\"));
        }

        public static void SavePicture(Rom rom, string picturePath, string folder)
        {
            if (rom == null || string.IsNullOrEmpty(picturePath) || string.IsNullOrEmpty(folder)) return;

            string platformPath = Values.PicturesPath + "\\" + rom.Platform.Name;
            string categoryPath = platformPath + "\\" + folder;

            if (!Directory.Exists(platformPath))
            {
                Directory.CreateDirectory(platformPath);
            }

            if (!Directory.Exists(categoryPath))
            {
                Directory.CreateDirectory(categoryPath);
            }

            var oldPic = Functions.GetRomPicture(rom, folder);

            if (!string.IsNullOrEmpty(oldPic))
            {
                File.Delete(oldPic);
            }

            FileInfo pic = new FileInfo(picturePath);
            string filename = pic.FullName.Substring(pic.FullName.LastIndexOf("\\") + 1);
            string destinationFile = categoryPath + "\\" + rom.Name + pic.Extension;
            pic.CopyTo(destinationFile, true);
            pic = null;
        }

        public static string TrimRomName(string name)
        {
            string trimmed = name.ToLower();

            if (trimmed.LastIndexOf("\\") > -1)
            {
                trimmed = trimmed.Substring(trimmed.LastIndexOf("\\") + 1);
            }

            trimmed = Functions.RemoveSubstring(trimmed, '(', ')');
            trimmed = Functions.RemoveSubstring(trimmed, '[', ']');

            trimmed = trimmed.Replace(" ii", " 2").Replace(" iii", " 3").Replace(" iv", " 4");
            trimmed = trimmed.Replace("the ", "").Replace("the_", "").Replace(" the", "").Replace("_the", "");
            trimmed = trimmed.Replace(".jpg", "").Replace(".gif", "").Replace(".png", "");
            trimmed = trimmed.Replace(" in ", "").Replace(" on ", "").Replace(" at ", "");
            trimmed = trimmed.Replace("-", "").Replace("_", "").Replace("'", "").Replace(" ", "").Replace(".", "").Replace(",", "");
            //trimmed = trimmed.Replace("(u)", "").Replace("(j)", "").Replace("(e)", "");
            //trimmed = trimmed.Replace("(usa)", "").Replace("(jpn)", "").Replace("(eur)", "");
            //trimmed = trimmed.Replace("(japan)", "").Replace("(europe)", "").Replace("(prototype)", "");
            //trimmed = trimmed.Replace("(m3)", "").Replace("(m4)", "").Replace("(m5)", "").Replace("(m6)", "");
            //trimmed = trimmed.Replace("(v1.0)", "").Replace("(v1.1)", "").Replace("(v1.2)", "");
            //trimmed = trimmed.Replace("(world)", "").Replace("(japan, europe)", "").Replace("(usa, europe)", "");
            //trimmed = trimmed.Replace("usa", "").Replace("jpn", "").Replace("eur", "");
            //trimmed = trimmed.Replace("(w)", "").Replace("(ju)", "").Replace("(ue)", "").Replace("[f1]", "");
            //trimmed = trimmed.Replace("(x)", "").Replace("(jue)", "").Replace("[s]", "");
            //trimmed = trimmed.Replace("(b0)", "").Replace("(b1)", "").Replace("[f1]", "").Replace("[c]", "");
            trimmed = trimmed.Replace("[!]", "").Replace("!", "").Replace("?", "").Replace("&", "").Replace(" ", "").Replace(" ", "");

            return trimmed;
        }

        public static string RemoveSubstring(string text, char start, char end)
        {
            char[] textArray = text.ToCharArray();
            StringBuilder result = new StringBuilder();
            bool copy = true;

            foreach (char c in textArray)
            {
                if (c == start)
                {
                    copy = false;
                }

                if (copy)
                {
                    result.Append(c);
                }

                if (c == end)
                {
                    copy = true;
                }
            }

            return result.ToString();
        }

        public static Region DetectRegion(string name)
        {
            int index1 = name.IndexOf("(");
            int index2 = name.IndexOf("[");

            if (index1 == -1 && index2 == -1) return Region.USA;

            int index = index1 == -1 && index2 > -1 ? index2 : index1;

            if (index == -1) return Region.USA;

            string substring = name.Substring(index).ToLower();
            substring = substring.Replace("(", " ").Replace(")", " ").Replace("[", " ").Replace("]", " ").Replace(",", " ");
            substring = substring.Replace("  ", " ").Replace("  ", " ");

            var words = substring.Split(' ');
            List<string> wordList = new List<string>(words);

            if (wordList.Any(x => x == "world")) return Region.USA;
            if (wordList.Any(x => x == "wld")) return Region.USA;
            if (wordList.Any(x => x == "wrd")) return Region.USA;
            if (wordList.Any(x => x == "w")) return Region.USA;

            if (wordList.Any(x => x == "usa")) return Region.USA;
            if (wordList.Any(x => x == "us")) return Region.USA;
            if (wordList.Any(x => x == "u")) return Region.USA;
            if (wordList.Any(x => x == "ju")) return Region.USA;
            if (wordList.Any(x => x == "jue")) return Region.USA;

            if (wordList.Any(x => x == "japan")) return Region.JPN;
            if (wordList.Any(x => x == "jpn")) return Region.JPN;
            if (wordList.Any(x => x == "j")) return Region.JPN;

            if (wordList.Any(x => x == "europe")) return Region.EUR;
            if (wordList.Any(x => x == "eur")) return Region.EUR;
            if (wordList.Any(x => x == "e")) return Region.EUR;
            if (wordList.Any(x => x == "france")) return Region.EUR;
            if (wordList.Any(x => x == "fr")) return Region.EUR;
            if (wordList.Any(x => x == "f")) return Region.EUR;
            if (wordList.Any(x => x == "uk")) return Region.EUR;
            if (wordList.Any(x => x == "germany")) return Region.EUR;
            if (wordList.Any(x => x == "ger")) return Region.EUR;
            if (wordList.Any(x => x == "g")) return Region.EUR;
            if (wordList.Any(x => x == "je")) return Region.EUR;

            return Region.UNK;
        }

        public static string GetPlatformPicture(string platformName)
        {
            string platformPicsPath = Values.PicturesPath + "\\Platforms\\";

            if (File.Exists(platformPicsPath + platformName + ".ico"))
            {
                return platformPicsPath + platformName + ".ico";
            }

            if (File.Exists(platformPicsPath + platformName + ".png"))
            {
                return platformPicsPath + platformName + ".png";
            }

            if (File.Exists(platformPicsPath + platformName + ".bmp"))
            {
                return platformPicsPath + platformName + ".bmp";
            }

            if (File.Exists(platformPicsPath + platformName + ".gif"))
            {
                return platformPicsPath + platformName + ".gif";
            }

            if (File.Exists(platformPicsPath + platformName + ".jpg"))
            {
                return platformPicsPath + platformName + ".jpg";
            }

            return "";
        }

        public static Bitmap CreateBitmap(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                using (var bmpTemp = new Bitmap(path))
                {
                    return new Bitmap(bmpTemp);
                }
            }

            return null;
        }

        public static string GetRomPicture(Rom rom, string type)
        {
            string result = Values.PicturesPath + "\\" + rom.Platform.Name + "\\" + type + "\\" + rom.Name;

            if (File.Exists(result + ".jpg"))
            {
                return result + ".jpg";
            }

            if (File.Exists(result + ".png"))
            {
                return result + ".png";
            }

            if (File.Exists(result + ".gif"))
            {
                return result + ".gif";
            }
            if (File.Exists(result + ".bmp"))
            {
                return result + ".bmp";
            }

            return "";
        }

        public static string GetFileExtension(string file)
        {
            if (string.IsNullOrEmpty(file)) return "";
            return file.Substring(file.LastIndexOf("."));
        }

        public static string GetFileName(string file)
        {
            if (string.IsNullOrEmpty(file)) return "";
            return file.Substring(file.LastIndexOf("\\") + 1);
        }

        public static string GetFileNameNoExtension(string file)
        {
            if (string.IsNullOrEmpty(file)) return "";
            var fileName = file.Substring(file.LastIndexOf("\\") + 1);
            return fileName.Substring(0, fileName.LastIndexOf("."));
        }

        public static void RemoveRomPics(Rom rom)
        {
            var boxart = Functions.GetRomPicture(rom, Values.BoxartFolder);

            if (!string.IsNullOrEmpty(boxart))
            {
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(boxart,
                Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
            }

            var titleart = Functions.GetRomPicture(rom, Values.TitleFolder);

            if (!string.IsNullOrEmpty(titleart))
            {
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(titleart,
                Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
            }

            var gameplayart = Functions.GetRomPicture(rom, Values.GameplayFolder);

            if (!string.IsNullOrEmpty(gameplayart))
            {
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(gameplayart,
                Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
            }
        }

        public static void ChangeRomNameInsideZip(string rompath)
        {
            try
            {
                string folder = Environment.CurrentDirectory + "\\" + GetFileNameNoExtension(rompath);
                string romZipped = GetFileName(rompath);

                Directory.CreateDirectory(folder);
                ZipFile.ExtractToDirectory(rompath, folder);
                string romUnzipped = GetFileName(Directory.GetFiles(folder)[0]);
                File.Move(folder + "\\" + romUnzipped, folder + "\\" + GetFileNameNoExtension(rompath) + GetFileExtension(romUnzipped));
                ZipFile.CreateFromDirectory(folder, Environment.CurrentDirectory + "\\" + romZipped);
                File.Delete(rompath);
                File.Move(Environment.CurrentDirectory + "\\" + romZipped, rompath);
                Directory.Delete(folder, true);
            }
            catch
            {

            }
        }

        public static List<KeyValuePair<string, string>> GetPlatformsXML()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Values.PlatformsXML);

            var result = new List<KeyValuePair<string, string>>();

            foreach (XmlNode item in doc.ChildNodes[0].ChildNodes[0].ChildNodes)
            {
                var kvp = new KeyValuePair<string, string>(item.ChildNodes[0].InnerText, item.ChildNodes[1].InnerText);
                result.Add(kvp);
            }

            return result;
        }

        public static string GetXmlAttribute(XmlNode node, string attributeName)
        {
            if (node.Attributes[attributeName] == null)
            {
                return string.Empty;
            }

            return node.Attributes[attributeName].Value;
        }

        public static void CreateOrSetXmlAttribute(XmlNode node, string attributeName, string value)
        {
            if (node.Attributes[attributeName] == null)
            {
                node.Attributes.Append(XML.xmlDoc.CreateAttribute(attributeName));
            }

            node.Attributes[attributeName].Value = value;
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
                        YearReleased = GetYear(item.ChildNodes[2])
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

                        if (contentNode.Name.ToLower() == "releasedate")
                        {
                            if (game == null)
                            {
                                game = new Rom();
                            }

                            game.YearReleased = GetYear(contentNode);
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

        public static Rom GetGameDetails(string gameId)
        {
            Rom game = new Rom();

            try
            {
                string xml = string.Empty;

                using (WebClient client = new WebClient())
                {
                    xml = client.DownloadString(new Uri("http://thegamesdb.net/api/GetGame.php?id=" + gameId));
                }

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                var genres = Genre.GetAll();

                foreach (XmlNode item in doc.ChildNodes[1].ChildNodes[1].ChildNodes)
                {
                    if (item.Name.ToLower() == "releasedate")
                    {
                        game.YearReleased = GetYear(item);
                    }

                    if (item.Name == "GameTitle")
                    {
                        game.Name = item.InnerText;
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

                    if (item.Name == "Genres")
                    {
                        if (game.Genre != null) continue;

                        bool hasAction = Genre.Get("Action") != null;
                        bool hasAdventure = Genre.Get("Adventure") != null;

                        List<Genre> gameGenres = new List<Genre>();

                        foreach (XmlNode genreNode in item.ChildNodes)
                        {
                            if (string.IsNullOrEmpty(genreNode.InnerText)) continue;

                            var matchGenre = genres.Where(x => x.Name == genreNode.InnerText).FirstOrDefault();

                            if (matchGenre != null)
                            {
                                gameGenres.Add(matchGenre);
                            }
                            else
                            {
                                gameGenres.Add(AddNewGenre(genreNode.InnerText));
                                genres.Add(game.Genre);
                            }

                            game.Genre = PrioritizeGenre(gameGenres);
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

        private static Genre PrioritizeGenre(List<Genre> genres)
        {

            if (genres.Count == 0) return null;

            if (genres.Count == 1) return genres[0];

            bool hasAction = genres.Count(x => x.Name == "Action") == 1;
            bool hasAdventure = genres.Count(x => x.Name == "Adventure") == 1;
            bool hasOther = genres.Count(x => x.Name != "Action" && x.Name != "Adventure") > 0;

            if (hasOther)
            {
                return genres.First(x => x.Name != "Action" && x.Name != "Adventure");
            }

            if (hasAction && hasAdventure)
            {
                return genres.First(x => x.Name == "Adventure");
            }

            return genres[0];
        }

        public static string GetYear(XmlNode date)
        {
            if (date == null) return string.Empty;

            var dateString = date.InnerText;

            if (string.IsNullOrEmpty(dateString)) return string.Empty;

            if (dateString.Length == 4) return dateString;

            if (dateString.Length == 10) return dateString.Substring(6);

            return string.Empty;
        }

        public static Genre AddNewGenre(string name)
        {
            Genre genre = new Genre();
            genre.Name = name;
            genre.CheckState = System.Windows.Forms.CheckState.Checked;
            Random r = new Random();
            genre.Color = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));

            Genre.Set(genre);

            return genre;
        }

        public static List<string> GetRomImagesByPlatform(string platform, string folder)
        {
            var rootDir = Environment.CurrentDirectory;
            var imagesDir = rootDir + "\\Pictures\\" + platform + "\\" + folder;
            var result = new List<string>();

            if (!Directory.Exists(imagesDir)) return result;

            var images = Directory.GetFiles(imagesDir);

            foreach (var item in images)
            {
                result.Add(Functions.GetFileNameNoExtension(item));
            }

            return result;
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
    }
}
