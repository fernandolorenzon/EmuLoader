using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Xml;
using EmuLoader.Core.Classes;
using System.IO;

namespace EmuLoader.Core.Business
{
    public static class RomFunctions
    {
        public static void SaveRomPictures(Rom rom, string boxPath, string titlePath, string gameplayPath, bool saveAsJpg)
        {
            if (!string.IsNullOrEmpty(boxPath) && File.Exists(boxPath))
            {
                RomFunctions.SavePicture(rom, boxPath, Values.BoxartFolder, saveAsJpg);
            }

            if (!string.IsNullOrEmpty(titlePath) && File.Exists(titlePath))
            {
                RomFunctions.SavePicture(rom, titlePath, Values.TitleFolder, saveAsJpg);
            }

            if (!string.IsNullOrEmpty(gameplayPath) && File.Exists(gameplayPath))
            {
                RomFunctions.SavePicture(rom, gameplayPath, Values.GameplayFolder, saveAsJpg);
            }
        }

        public static bool RenameRomFile(Rom rom, string changeFileName, bool changeZipFileName)
        {
            if (changeFileName != rom.FileName)
            {
                string oldPath = rom.Path;
                string newPath = string.Empty;
                string newDir = string.Empty;

                if (rom.IsRomPack())
                {
                    FileInfo file = new FileInfo(rom.Path);
                    newDir = file.Directory.Parent.FullName + "\\" + RomFunctions.GetFileNameNoExtension(changeFileName);
                    newPath = newDir + "\\" + changeFileName;
                }
                else
                {
                    newPath = RomFunctions.GetRomDirectory(rom.Path) + "\\" + changeFileName;
                }

                if (File.Exists(newPath))
                {
                    throw new Exception("A file named \"" + newPath + "\" already exists!");
                }

                if (!string.IsNullOrEmpty(newDir))
                {
                    DirectoryInfo oldPathDir = new FileInfo(oldPath).Directory;
                    oldPathDir.MoveTo(newDir);
                    File.Move(newDir + "\\" + rom.FileName, newPath);
                }
                else
                {
                    File.Move(oldPath, newPath);
                }

                Rom.Delete(rom);
                rom.Path = newPath;

                if (changeZipFileName && RomFunctions.GetFileExtension(newPath) == ".zip")
                {
                    RomFunctions.ChangeRomNameInsideZip(newPath);
                }
            }

            return true;
        }

        public static void RenameRomPictures(Rom rom, string changeRomName)
        {
            if (changeRomName != rom.Name && rom.Platform.PictureNameByDisplay)
            {
                string boxpic = RomFunctions.GetRomPicture(rom, Values.BoxartFolder);
                string titlepic = RomFunctions.GetRomPicture(rom, Values.TitleFolder);
                string gameplaypic = RomFunctions.GetRomPicture(rom, Values.GameplayFolder);

                if (!string.IsNullOrEmpty(boxpic))
                {
                    File.Move(boxpic, boxpic.Substring(0, boxpic.LastIndexOf("\\")) + "\\" + changeRomName + boxpic.Substring(boxpic.LastIndexOf(".")));
                }

                if (!string.IsNullOrEmpty(titlepic))
                {
                    File.Move(titlepic, titlepic.Substring(0, titlepic.LastIndexOf("\\")) + "\\" + changeRomName + titlepic.Substring(titlepic.LastIndexOf(".")));
                }

                if (!string.IsNullOrEmpty(gameplaypic))
                {
                    File.Move(gameplaypic, gameplaypic.Substring(0, gameplaypic.LastIndexOf("\\")) + "\\" + changeRomName + gameplaypic.Substring(gameplaypic.LastIndexOf(".")));
                }
            }
        }

        public static Rom SetRom(Rom rom, string id, string fileName,
            string romName, string platform, string genre, List<RomLabel> labels, string publisher,
            string developer, string description, string year, string dbName,
            string rating, bool idLocked, bool changeZipName,
            string boxPath, string titlePath, string gameplayPath, bool saveAsJpg,
            string emulatorExe, string command, bool useAlternate)
        {
            rom.Labels.Clear();

            rom.Platform = string.IsNullOrEmpty(platform) ? null : Platform.Get(platform);
            rom.Genre = string.IsNullOrEmpty(genre) ? null : Genre.Get(genre);

            rom.Publisher = publisher;
            rom.Developer = developer;
            rom.Description = description;
            rom.YearReleased = year;
            rom.DBName = dbName;
            rom.IdLocked = idLocked;

            float ratingParse = 0;

            if (float.TryParse(rating, out ratingParse))
            {
                if (ratingParse > 0 && ratingParse <= 10)
                {
                    rom.Rating = ratingParse;
                }
            }

            rom.Id = id;

            RomFunctions.RenameRomFile(rom, fileName, changeZipName);
            RomFunctions.RenameRomPictures(rom, romName);

            rom.Name = romName;
            rom.Labels.AddRange(labels);

            RomFunctions.SaveRomPictures(rom, boxPath, titlePath, gameplayPath, saveAsJpg);

            if (!string.IsNullOrEmpty(emulatorExe) && !string.IsNullOrEmpty(command))
            {
                rom.EmulatorExe = emulatorExe;
                rom.Command = command;
            }
            else
            {
                rom.EmulatorExe = string.Empty;
                rom.Command = string.Empty;
            }

            rom.UseAlternateEmulator = useAlternate;

            if (string.IsNullOrEmpty(rom.Id))
            {
                rom.DBName = string.Empty;
            }

            return rom;
        }

        public static void CopyDBName(string dbName, bool keepSuffix, out string romName, out string fileName)
        {
            romName = "";
            fileName = "";

            if (string.IsNullOrEmpty(dbName.Trim())) return;

            int bracketindex = fileName.IndexOf('[');
            int parindex = fileName.IndexOf('(');
            int suffixIndex = 0;

            if (bracketindex > -1 && parindex == -1)
            {
                suffixIndex = bracketindex;
            }
            else if (bracketindex == -1 && parindex > -1)
            {
                suffixIndex = parindex;
            }
            else if (bracketindex > -1 && parindex > -1)
            {
                suffixIndex = bracketindex > parindex ? parindex : bracketindex;
            }

            string suffix = suffixIndex == 0 ? string.Empty : RomFunctions.GetFileNameNoExtension(fileName).Substring(suffixIndex);

            if (keepSuffix)
            {
                romName = dbName.Replace(":", " -") + " " + suffix;
            }
            else
            {
                romName = dbName.Replace(":", " -");
            }

            fileName = romName + RomFunctions.GetFileExtension(fileName);

            romName = romName.Trim();
            fileName = fileName.Trim();
        }

        public static string TrimRomName(string name)
        {
            string trimmed = name.ToLower();

            if (trimmed.IndexOf("/") > -1)
            {
                trimmed = trimmed.Substring(0, trimmed.IndexOf("/") - 1);
                trimmed = trimmed.Trim();
            }

            if (trimmed.LastIndexOf("\\") > -1)
            {
                trimmed = trimmed.Substring(trimmed.LastIndexOf("\\") + 1);
            }

            trimmed = Functions.RemoveSubstring(trimmed, '(', ')');
            trimmed = Functions.RemoveSubstring(trimmed, '[', ']');
            trimmed = trimmed.Replace("'s", "").Replace(" no ", "");
            trimmed = trimmed.Replace(" iv", " 4").Replace(" iii", " 3").Replace(" ii", " 2");
            trimmed = trimmed.Replace("the ", "").Replace("the_", "").Replace(" the", "").Replace("_the", "");
            trimmed = trimmed.Replace(".jpg", "").Replace(".gif", "").Replace(".png", "");
            trimmed = trimmed.Replace(" in ", "").Replace(" on ", "").Replace(" at ", "");
            trimmed = trimmed.Replace("ou", "o").Replace("uu", "u").Replace("oh", "o").Replace("yu", "u").Replace("yo", "o").Replace("syo", "sho");
            trimmed = trimmed.Replace("-", "").Replace("_", "").Replace(":", "").Replace("'", "").Replace(".", "").Replace(",", "");
            trimmed = trimmed.Replace(" and ", "").Replace("versus", "vs");
            trimmed = trimmed.Replace("aa", "a").Replace("ee", "e").Replace("oo", "o");
            trimmed = trimmed.Replace("[!]", "").Replace("!", "").Replace("?", "").Replace("&", "").Replace("  ", "").Replace(" ", "").Replace(" ", "");

            return trimmed;
        }

        public static bool MatchImagesExact(string[] images, string romName, out string imageFoundPath)
        {
            imageFoundPath = string.Empty;
            bool found = false;

            foreach (var image in images)
            {
                string imageTrimmed = RomFunctions.TrimRomName(image);

                if (imageTrimmed == romName)
                {
                    found = true;
                    imageFoundPath = image;
                    break;
                }
            }

            return found;
        }

        public static bool MatchImages(string[] images, Dictionary<string, Classes.Region> imageRegion, string romName, out string imageFoundPath)
        {
            imageFoundPath = string.Empty;
            bool found = false;
            string romTrimmed = RomFunctions.TrimRomName(romName);
            var romRegion = RomFunctions.DetectRegion(romName);

            foreach (var image in images)
            {
                string imageTrimmed = RomFunctions.TrimRomName(image);

                if (imageTrimmed == romTrimmed && imageRegion[RomFunctions.GetFileName(image)] == romRegion)
                {
                    found = true;
                    imageFoundPath = image;
                    break;
                }
            }

            if (!found)
            {
                foreach (var image in images)
                {
                    string imageTrimmed = RomFunctions.TrimRomName(image);

                    if (imageTrimmed == romTrimmed)
                    {
                        found = true;
                        imageFoundPath = image;
                        break;
                    }
                }
            }

            return found;
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
            string result = "";

            if (rom.Platform != null && rom.Platform.PictureNameByDisplay)
            {
                result = Values.PicturesPath + "\\" + rom.Platform.Name + "\\" + type + "\\" + rom.Name;
            }
            else if (rom.Platform != null && !rom.Platform.PictureNameByDisplay)
            {
                result = Values.PicturesPath + "\\" + rom.Platform.Name + "\\" + type + "\\" + rom.FileNameNoExt;
            }

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
            var indexExtension = fileName.LastIndexOf(".");

            if (indexExtension == -1)
            {
                return fileName;
            }
            else
            {
                return fileName.Substring(0, fileName.LastIndexOf("."));
            }
        }

        public static bool RemoveInvalidRomsEntries(Platform platform = null)
        {
            bool result = false;

            List<Rom> roms = new List<Rom>();

            if (platform == null)
            {
                roms = Rom.GetAll();
            }
            else
            {
                roms = Rom.GetAll(platform);
            }

            foreach (Rom rom in roms)
            {
                if (!File.Exists(rom.Path))
                {
                    Rom.Delete(rom);
                    RemoveRomPics(rom);
                    result = true;
                }
            }

            return result;
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
                System.IO.Compression.ZipFile.ExtractToDirectory(rompath, folder);
                string romUnzipped = GetFileName(Directory.GetFiles(folder)[0]);
                File.Move(folder + "\\" + romUnzipped, folder + "\\" + GetFileNameNoExtension(rompath) + GetFileExtension(romUnzipped));
                System.IO.Compression.ZipFile.CreateFromDirectory(folder, Environment.CurrentDirectory + "\\" + romZipped);
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

        public static string GetYear(string date)
        {
            if (string.IsNullOrEmpty(date)) return string.Empty;

            if (date.Length == 4) return date;

            if (date.Length == 10) return date.Substring(0, 4);

            return string.Empty;
        }

        public static Genre CreateNewGenre(string name)
        {
            Genre genre = new Genre();
            genre.Name = name;
            genre.Checked = true;
            Random r = new Random();
            genre.Color = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));

            Genre.Set(genre);

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
            string destinationFile = "";

            if (rom.Platform.PictureNameByDisplay)
            {
                destinationFile = categoryPath + "\\" + rom.Name + pic.Extension;
            }
            else
            {
                destinationFile = categoryPath + "\\" + rom.FileNameNoExt + pic.Extension;
            }

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
            bool addedAny = false;

            foreach (var path in files)
            {
                var rom = Rom.Get(path);

                if (rom == null)
                {
                    rom = Rom.NewRom(path, platform);
                    addedAny = true;
                    Rom.Set(rom);
                }
            }

            return addedAny;
        }

        public static bool AddRomsFromDirectory(Platform platform, string directory)
        {
            if (platform == null) return false;

            List<Rom> romList = new List<Rom>();
            var files = Directory.GetFiles(directory);
            var exts = platform.DefaultRomExtensions.Split(',').ToList();
            bool addedAny = false;

            foreach (var path in files)
            {
                var fileExt = GetFileExtension(path);
                if (!exts.Contains(fileExt.Replace(".", "")))
                {
                    continue;
                }

                var rom = Rom.Get(path);

                if (rom == null)
                {
                    rom = Rom.NewRom(path, platform);
                    addedAny = true;
                    Rom.Set(rom);
                }
            }

            return addedAny;
        }

        public static bool AddRomPacksFromDirectory(Platform platform, string directory)
        {
            if (platform == null) return false;

            List<Rom> romList = new List<Rom>();
            var directories = Directory.GetDirectories(directory);
            bool addedAny = false;

            foreach (var path in directories)
            {
                if (platform.DefaultRomExtensions == "dir")
                {

                    if (!Directory.Exists(platform.DefaultRomPath))
                    {
                        return false;
                    }

                    var dirs = Directory.GetDirectories(platform.DefaultRomPath);

                    foreach (var dir in dirs)
                    {
                        var rom = Rom.Get(dir);

                        if (rom == null)
                        {
                            rom = Rom.NewRom(dir, platform);
                            addedAny = true;
                            Rom.Set(rom);
                        }
                    }
                }
                else
                {
                    var files = Directory.GetFiles(path);
                    foreach (var file in files)
                    {
                        var exts = platform.DefaultRomExtensions.Split(',').ToList();
                        var fileExt = GetFileExtension(file);

                        if (exts.Contains(fileExt.Replace(".", "")))
                        {
                            var rom = Rom.Get(file);

                            if (rom == null)
                            {
                                rom = Rom.NewRom(file, platform);
                                addedAny = true;
                                Rom.Set(rom);
                            }
                        }
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

        public static bool ChangeRomLabels(List<Rom> roms, List<RomLabel> selectedLabels, List<RomLabel> unselectedLabels)
        {
            foreach (var rom in roms)
            {
                foreach (var label in selectedLabels)
                {
                    if (!rom.Labels.Any(x => x.Name == label.Name))
                    {
                        rom.Labels.Add(label);
                    }
                }

                foreach (var label in unselectedLabels)
                {
                    if (rom.Labels.Any(x => x.Name == label.Name))
                    {
                        var selected = rom.Labels.First(x => x.Name == label.Name);
                        rom.Labels.Remove(selected);
                    }
                }

                Rom.Set(rom);
            }

            return true;
        }

        public static string GetMAMENameFromMameFolder(string filename)
        {
            var mamepath = Config.GetFolder(Folder.MAME);

            if (string.IsNullOrEmpty(mamepath)) return "";

            if (Values.MAMERomNames == null)
            {
                Values.MAMERomNames = new Dictionary<string, string>();
                var files = Directory.GetFiles(mamepath + "\\hash", "*.xml");

                foreach (var file in files)
                {
                    var xmlcontent = File.ReadAllText(file);
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(xmlcontent);
                    if (doc.ChildNodes == null || doc.ChildNodes.Count == 0) continue;

                    foreach (XmlNode node in doc.ChildNodes[doc.ChildNodes.Count - 1].ChildNodes)
                    {
                        if (node.Attributes == null || node.Attributes.Count == 0) continue;

                        if (!Values.MAMERomNames.ContainsKey(node.Attributes["name"].Value))
                        {
                            foreach (XmlNode child in node.ChildNodes)
                            {
                                if (child.Name == "description")
                                {
                                    Values.MAMERomNames.Add(node.Attributes["name"].Value, child.InnerText);
                                    break;
                                }
                            }

                        }
                    }
                }
            }

            if (Values.MAMERomNames.ContainsKey(filename))
            {
                return Values.MAMERomNames[filename];
            }

            return "";
        }

        public static string GetMAMENameFromCSV(string filename)
        {
            var mame = EmuLoader.Core.Properties.ResourceCore.mame;

            if (Values.MAMERomNames == null)
            {
                Values.MAMERomNames = new Dictionary<string, string>();
                var lines = mame.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var line in lines)
                {
                    var names = line.Split(';');

                    if (names.Length != 2) continue;

                    if (!Values.MAMERomNames.ContainsKey(names[0]))
                    {
                        Values.MAMERomNames.Add(names[0], names[1]);
                    }
                }
            }

            if (Values.MAMERomNames.ContainsKey(filename))
            {
                return Values.MAMERomNames[filename];
            }

            return "";
        }
    }
}
