using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml;
using EmuLoader.Classes;

namespace EmuLoader.Business
{
    public static class RomFunctions
    {

        public static string TrimRomName(string name)
        {
            string trimmed = name.ToLower();

            if (trimmed.LastIndexOf("\\") > -1)
            {
                trimmed = trimmed.Substring(trimmed.LastIndexOf("\\") + 1);
            }

            trimmed = RemoveSubstring(trimmed, '(', ')');
            trimmed = RemoveSubstring(trimmed, '[', ']');

            trimmed = trimmed.Replace(" ii", " 2").Replace(" iii", " 3").Replace(" iv", " 4");
            trimmed = trimmed.Replace("the ", "").Replace("the_", "").Replace(" the", "").Replace("_the", "");
            trimmed = trimmed.Replace(".jpg", "").Replace(".gif", "").Replace(".png", "");
            trimmed = trimmed.Replace(" in ", "").Replace(" on ", "").Replace(" at ", "");
            trimmed = trimmed.Replace("-", "").Replace("_", "").Replace(":", "").Replace("'", "").Replace(" ", "").Replace(".", "").Replace(",", "");
            trimmed = trimmed.Replace(" and ", "").Replace("versus", "vs");
            trimmed = trimmed.Replace("[!]", "").Replace("!", "").Replace("?", "").Replace("&", "").Replace("  ", "").Replace(" ", "").Replace(" ", "");

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

        public static Classes.Region DetectRegion(string name)
        {
            int index1 = name.IndexOf("(");
            int index2 = name.IndexOf("[");

            if (index1 == -1 && index2 == -1) return Classes.Region.USA;

            int index = index1 == -1 && index2 > -1 ? index2 : index1;

            if (index == -1) return Classes.Region.USA;

            string substring = name.Substring(index).ToLower();
            substring = substring.Replace("(", " ").Replace(")", " ").Replace("[", " ").Replace("]", " ").Replace(",", " ");
            substring = substring.Replace("  ", " ").Replace("  ", " ");

            var words = substring.Split(' ');
            List<string> wordList = new List<string>(words);

            if (wordList.Any(x => x == "world")) return Classes.Region.USA;
            if (wordList.Any(x => x == "wld")) return Classes.Region.USA;
            if (wordList.Any(x => x == "wrd")) return Classes.Region.USA;
            if (wordList.Any(x => x == "w")) return Classes.Region.USA;

            if (wordList.Any(x => x == "usa")) return Classes.Region.USA;
            if (wordList.Any(x => x == "us")) return Classes.Region.USA;
            if (wordList.Any(x => x == "u")) return Classes.Region.USA;
            if (wordList.Any(x => x == "ju")) return Classes.Region.USA;
            if (wordList.Any(x => x == "jue")) return Classes.Region.USA;

            if (wordList.Any(x => x == "japan")) return Classes.Region.JPN;
            if (wordList.Any(x => x == "jpn")) return Classes.Region.JPN;
            if (wordList.Any(x => x == "j")) return Classes.Region.JPN;

            if (wordList.Any(x => x == "europe")) return Classes.Region.EUR;
            if (wordList.Any(x => x == "eur")) return Classes.Region.EUR;
            if (wordList.Any(x => x == "e")) return Classes.Region.EUR;
            if (wordList.Any(x => x == "france")) return Classes.Region.EUR;
            if (wordList.Any(x => x == "fr")) return Classes.Region.EUR;
            if (wordList.Any(x => x == "f")) return Classes.Region.EUR;
            if (wordList.Any(x => x == "uk")) return Classes.Region.EUR;
            if (wordList.Any(x => x == "germany")) return Classes.Region.EUR;
            if (wordList.Any(x => x == "ger")) return Classes.Region.EUR;
            if (wordList.Any(x => x == "g")) return Classes.Region.EUR;
            if (wordList.Any(x => x == "je")) return Classes.Region.EUR;

            return Classes.Region.UNK;
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
            var boxart = GetRomPicture(rom, Values.BoxartFolder);

            if (!string.IsNullOrEmpty(boxart))
            {
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(boxart,
                Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs,
                Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
            }

            var titleart = GetRomPicture(rom, Values.TitleFolder);

            if (!string.IsNullOrEmpty(titleart))
            {
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(titleart,
                Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs,
                Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
            }

            var gameplayart = GetRomPicture(rom, Values.GameplayFolder);

            if (!string.IsNullOrEmpty(gameplayart))
            {
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(gameplayart,
                Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs,
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

        public static Genre PrioritizeGenre(List<Genre> genres)
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

        public static Genre CreateNewGenre(string name)
        {
            Genre genre = new Genre();
            genre.Name = name;
            genre.CheckState = System.Windows.Forms.CheckState.Checked;
            Random r = new Random();
            genre.Color = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));

            return genre;
        }

        public static List<string> GetRomPicturesByPlatform(string platform, string folder)
        {
            var rootDir = Environment.CurrentDirectory;
            var imagesDir = rootDir + "\\Pictures\\" + platform + "\\" + folder;
            var result = new List<string>();

            if (!Directory.Exists(imagesDir)) return result;

            var images = Directory.GetFiles(imagesDir);

            foreach (var item in images)
            {
                result.Add(GetFileNameNoExtension(item));
            }

            return result;
        }

        public static void SavePicture(Rom rom, string picturePath, string folder, bool saveAsJpg)
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

            var oldPic = GetRomPicture(rom, folder);

            if (!string.IsNullOrEmpty(oldPic))
            {
                File.Delete(oldPic);
            }

            bool convert = saveAsJpg && GetFileExtension(picturePath) != ".jpg";

            if (convert)
            {
                using (Image image = Image.FromFile(picturePath))
                {
                    picturePath = "newfile.jpg";
                    image.Save(picturePath, ImageFormat.Jpeg);
                }
            }

            FileInfo pic = new FileInfo(picturePath);
            string destinationFile = categoryPath + "\\" + rom.Name + pic.Extension;
            pic.CopyTo(destinationFile, true);
            pic = null;

            if (convert)
            {
                File.Delete(picturePath);
            }
        }

        public static string GetRomDirectory(string path)
        {
            return path.Remove(path.LastIndexOf("\\"));
        }


        public static void SetRomLabels(Rom rom, XmlNode node)
        {
            node.ChildNodes[0].RemoveAll();

            if (rom.Labels != null)
            {
                foreach (RomLabel label in rom.Labels)
                {
                    XmlNode labelNode = XML.xmlDoc.CreateNode(XmlNodeType.Element, "Label", "");
                    labelNode.InnerText = label.Name;
                    node.ChildNodes[0].AppendChild(labelNode);
                }
            }
        }


        public static bool AddRomsFiles(Platform platform, string[] files)
        {
            List<Rom> romList = new List<Rom>();

            foreach (var item in files)
            {
                Rom r = new Rom(item);
                Rom old = Rom.Get(r.Path);

                if (old != null)
                {
                    r = old;
                }

                r.Platform = platform;
                Rom.Set(r);
            }

            return true;
        }

        public static bool AddRomsFromDirectory(Platform platform, string directory)
        {
            List<Rom> romList = new List<Rom>();
            var files = Directory.GetFiles(directory);

            foreach (var item in files)
            {
                Rom r = new Rom(item);
                Rom old = Rom.Get(r.Path);

                if (old != null)
                {
                    r = old;
                }

                r.Platform = platform;
                Rom.Set(r);
            }

            return true;
        }

        public static bool AddRomPacksFromDirectory(Platform platform, string directory)
        {
            List<Rom> romList = new List<Rom>();
            var directories = Directory.GetDirectories(directory);
            bool addedAny = false;

            foreach (var path in directories)
            {
                var files = Directory.GetFiles(path);

                foreach (var item in files)
                {
                    if (item.EndsWith(".cue") || item.EndsWith(".ccd") || item.EndsWith(".rom") || item.EndsWith(".gdi"))
                    {
                        Rom r = new Rom(item);
                        Rom old = Rom.Get(r.Path);

                        if (old != null)
                        {
                            r = old;
                        }
                        else
                        {
                            addedAny = true;
                        }

                        r.Platform = platform;
                        Rom.Set(r);
                    }
                }
            }

            return addedAny;
        }

        public static bool ChangeRomsPlatform(List<Rom> roms, Platform platform)
        {
            foreach (var item in roms)
            {
                item.Platform = platform;
                Rom.Set(item);
            }

            return true;
        }

        public static bool ChangeRomLabels(List<Rom> roms, List<RomLabel> labels)
        {
            foreach (var item in roms)
            {
                item.Labels = labels;
                Rom.Set(item);
            }

            return true;
        }
    }
}
