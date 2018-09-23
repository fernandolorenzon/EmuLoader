using EmuLoader.Classes;
using System;
using System.IO;
using System.Net;

namespace EmuLoader.Business
{
    public static class SyncDataFunctions
    {
        public static string DiscoverGameId(Rom rom)
        {
            if (rom.Platform == null) return string.Empty;

            if (string.IsNullOrEmpty(rom.Platform.Id)) return string.Empty;

            var games = APIFunctions.GetGamesListByPlatform(rom.Platform.Id);

            if (games == null) return string.Empty;

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

        public static void SavePictureFromUrl(Rom rom, string url, string folder, bool saveAsJPG)
        {
            try
            {
                if (string.IsNullOrEmpty(url)) return;

                string extension = url.Substring(url.LastIndexOf("."));
                string imagePath = "image" + extension;

                using (WebClient client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
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
