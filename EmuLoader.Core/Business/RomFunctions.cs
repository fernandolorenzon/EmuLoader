using EmuLoader.Core.Classes;
using EmuLoader.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Xml;

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
                if (RomBusiness.IsRomPack(rom))
                {
                    //FileInfo file = new FileInfo(rom.Platform.DefaultRomPath + "\\" + rom.FileName);
                    //newDir = rom.Platform.DefaultRomPath + "\\" + RomFunctions.GetFileNameNoExtension(changeFileName);
                    //newFile = newDir + "\\" + changeFileName;
                    //if (!string.IsNullOrEmpty(newDir))
                    //{
                    //    DirectoryInfo oldPathDir = new FileInfo(rom.Platform.DefaultRomPath + "\\" + oldFile).Directory;
                    //    oldPathDir.MoveTo(rom.Platform.DefaultRomPath + "\\" + newDir);
                    //    File.Move(rom.Platform.DefaultRomPath + "\\" + newDir + "\\" + rom.FileName, newFile);
                    //}
                    return false;
                }

                if (RomBusiness.IsRomDir(rom))
                {
                    return RenameRomDir(rom, changeFileName);
                }

                return RenameRomFileStandard(rom, changeFileName, changeZipFileName);
            }

            return true;
        }

        private static bool RenameRomDir(Rom rom, string changeFileName)
        {
            string oldFile = rom.Platform.DefaultRomPath + "\\" + rom.FileName;
            string newFile = rom.Platform.DefaultRomPath + "\\" + changeFileName;

            if (Directory.Exists(newFile))
            {
                throw new Exception("A directory named \"" + newFile + "\" already exists!");
            }

            Directory.Move(oldFile, newFile);
            rom.FileName = changeFileName;

            return true;
        }

        private static bool RenameRomFileStandard(Rom rom, string changeFileName, bool changeZipFileName)
        {
            string oldFile = rom.Platform.DefaultRomPath + "\\" + rom.FileName;
            string newFile = rom.Platform.DefaultRomPath + "\\" + changeFileName;

            if (File.Exists(newFile))
            {
                throw new Exception("A file named \"" + newFile + "\" already exists!");
            }

            File.Move(oldFile, newFile);
            rom.FileName = changeFileName;

            if (changeZipFileName && RomFunctions.GetFileExtension(newFile) == ".zip")
            {
                RomFunctions.ChangeRomNameInsideZip(newFile);
            }

            return true;
        }

        public static void RenameRomPictures(Rom rom, string newFileName)
        {
            var newname = RomFunctions.GetFileNameNoExtension(newFileName);
            if (newname != rom.FileNameNoExt)
            {
                string boxpic = RomFunctions.GetRomPicture(rom, Values.BoxartFolder);
                string titlepic = RomFunctions.GetRomPicture(rom, Values.TitleFolder);
                string gameplaypic = RomFunctions.GetRomPicture(rom, Values.GameplayFolder);

                if (!string.IsNullOrEmpty(boxpic))
                {
                    File.Move(boxpic, boxpic.Substring(0, boxpic.LastIndexOf("\\")) + "\\" + newname + boxpic.Substring(boxpic.LastIndexOf(".")));
                }

                if (!string.IsNullOrEmpty(titlepic))
                {
                    File.Move(titlepic, titlepic.Substring(0, titlepic.LastIndexOf("\\")) + "\\" + newname + titlepic.Substring(titlepic.LastIndexOf(".")));
                }

                if (!string.IsNullOrEmpty(gameplaypic))
                {
                    File.Move(gameplaypic, gameplaypic.Substring(0, gameplaypic.LastIndexOf("\\")) + "\\" + newname + gameplaypic.Substring(gameplaypic.LastIndexOf(".")));
                }
            }
        }

        public static void CopyDBName(string dbName, bool keepSuffix, string oldRomName, string oldFileName, out string newRomName, out string newFileName)
        {
            newRomName = "";
            newFileName = "";

            if (string.IsNullOrEmpty(dbName.Trim())) return;

            int bracketindex = oldFileName.IndexOf('[');
            int parindex = oldFileName.IndexOf('(');
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

            string suffix = suffixIndex == 0 ? string.Empty : RomFunctions.GetFileNameNoExtension(oldFileName).Substring(suffixIndex);

            if (keepSuffix)
            {
                newRomName = dbName + " " + suffix;
                newFileName = dbName.Replace(":", " -") + " " + suffix;
            }
            else
            {
                newRomName = dbName;
                newFileName = dbName.Replace(":", " -");
            }

            newFileName = newFileName + RomFunctions.GetFileExtension(oldFileName);

            newRomName = newRomName.Trim();
            newFileName = newFileName.Trim();
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
            string platformPicsPath = Values.PlatformsPath + "\\" + platformName + "\\" + Values.PlatformIcon;
            
            if (File.Exists(platformPicsPath + ".ico"))
            {
                return platformPicsPath + ".ico";
            }

            if (File.Exists(platformPicsPath + ".png"))
            {
                return platformPicsPath + ".png";
            }

            if (File.Exists(platformPicsPath + ".bmp"))
            {
                return platformPicsPath + ".bmp";
            }

            if (File.Exists(platformPicsPath + ".gif"))
            {
                return platformPicsPath + ".gif";
            }

            if (File.Exists(platformPicsPath + ".jpg"))
            {
                return platformPicsPath + ".jpg";
            }

            return "";
        }

        public static string GetRomPicture(Rom rom, string type)
        {
            string result = "";

            if (rom.Platform != null)
            {
                result = Values.PlatformsPath + "\\" + rom.Platform.Name + "\\" + type + "\\" + rom.FileNameNoExt;
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
            var index = file.LastIndexOf(".");

            if (index == -1)
            {
                return "";
            }
            else
            {
                return file.Substring(index);
            }
        }

        public static string GetFileName(string file, bool rompack = false)
        {
            if (string.IsNullOrEmpty(file)) return "";

            if (rompack)
            {
                var filename = file.Substring(file.LastIndexOf("\\")+ 1);
                file = file.Replace("\\" + filename, "");
                filename = file.Substring(file.LastIndexOf("\\") + 1) + "\\" + filename;
                return filename;
            }
            else
            {
                return file.Substring(file.LastIndexOf("\\") + 1);
            }
            
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
                roms = RomBusiness.GetAll();
            }
            else
            {
                roms = RomBusiness.GetAll(platform);
            }

            List<Rom> romList = new List<Rom>();

            foreach (Rom rom in roms)
            {
                if (!File.Exists(rom.FileName))
                {
                    romList.Add(rom);
                    RemoveRomPics(rom);
                    result = true;
                }
            }

            RomBusiness.DeleteRom(romList);

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

            GenreBusiness.Set(genre);

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

        public static List<string> GetRomPicturesByPlatformWithExt(string platform, string folder)
        {
            var rootDir = Environment.CurrentDirectory;
            var imagesDir = rootDir + "\\Pictures\\" + platform + "\\" + folder;
            var result = new List<string>();

            if (!Directory.Exists(imagesDir)) return result;

            var images = Directory.GetFiles(imagesDir);

            foreach (var item in images)
            {
                result.Add(GetFileName(item));
            }

            return result;
        }

        public static void SavePicture(Rom rom, string picturePath, string folder, bool saveAsJpg)
        {
            if (rom == null || string.IsNullOrEmpty(picturePath) || string.IsNullOrEmpty(folder)) return;

            string platformPath = Values.PlatformsPath + "\\" + rom.Platform.Name;
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

            destinationFile = categoryPath + "\\" + rom.FileNameNoExt + pic.Extension;

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

        public static bool AddRomsFiles(Platform platform, string[] files)
        {
            bool addedAny = false;

            foreach (var file in files)
            {
                var rom = RomBusiness.Get(platform.Name, RomFunctions.GetFileName(file));

                if (rom == null)
                {
                    rom = RomBusiness.NewRom(file, platform);
                    addedAny = true;
                    RomBusiness.SetRom(rom);
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

            foreach (var file in files)
            {
                var fileExt = GetFileExtension(file);
                if (!exts.Contains(fileExt.Replace(".", "")))
                {
                    continue;
                }

                var rom = RomBusiness.Get(platform.Name, RomFunctions.GetFileName(file));

                if (rom == null)
                {
                    romList.Add(RomBusiness.NewRom(file, platform));
                    addedAny = true;
                }
            }

            RomBusiness.SetRom(romList);

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
                        var rom = RomBusiness.Get(platform.Name, dir);

                        if (rom == null)
                        {
                            romList.Add(RomBusiness.NewRom(dir, platform));
                            addedAny = true;
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
                            var rom = RomBusiness.Get(platform.Name, RomFunctions.GetFileName(file, true));

                            if (rom == null)
                            {
                                romList.Add(RomBusiness.NewRom(file, platform, true));
                                addedAny = true;
                            }
                        }
                    }
                }
            }

            RomBusiness.SetRom(romList);
            return addedAny;
        }

        public static string GetMAMENameFromMameFolder(string filename)
        {
            var mamepath = ConfigBusiness.GetFolder(Folder.MAME);

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

        public static string GetPlatformJson(string platformName)
        {
            var file = Values.JsonFolder + "\\" + platformName + ".json";
            var json = string.Empty;

            if (File.Exists(file))
            {
                json = File.ReadAllText(file);
            }

            return json;
        }

        public static List<string> GetPics(string platform, PicType type, bool getFullPath, bool skipExtension)
        {
            List<string> result = new List<string>();
            string picfolder = "";

            if (type == PicType.BoxArt)
            {
                picfolder = Values.BoxartFolder;
            }
            else if (type == PicType.Title)
            {
                picfolder = Values.TitleFolder;
            }
            else
            {
                picfolder = Values.GameplayFolder;
            }

            var path = Environment.CurrentDirectory + "\\" + Values.PlatformsPath + "\\" + platform + "\\" + picfolder;

            if (!Directory.Exists(path))
            {
                return result;
            }

            var list = Directory.GetFiles(path).ToList();

            if (!getFullPath)
            {
                foreach (var item in list)
                {
                    if (skipExtension)
                    {
                        result.Add(RomFunctions.GetFileNameNoExtension(item));
                    }
                    else
                    {
                        result.Add(RomFunctions.GetFileName(item));
                    }
                }
            }
            else
            {
                result = list;
            }

            return result;
        }


        public static string FillEmuName(string name, string path, bool userRetroarch, string corename = null)
        {
            if (name == "" && path != "")
            {
                if (path.EndsWith(".exe"))
                {
                    if (File.Exists(path))
                    {
                        FileInfo file = new FileInfo(path);
                        name = file.Name.Replace(".exe", "");

                        if (userRetroarch && name == "retroarch" && !string.IsNullOrEmpty(corename))
                        {
                            name += " (" + RomFunctions.GetFileNameNoExtension(corename).Replace("_libretro", "") + ")";
                            return name;
                        }
                    }
                }
            }

            return name;
        }
    }
}
