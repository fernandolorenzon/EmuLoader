using EmuLoader.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace EmuLoader.Forms
{
    public partial class FormSyncRomData : FormBase
    {
        Thread threadSetOtherProperties;
        Thread threadSetIdAndYear;
        List<Rom> Roms = new List<Rom>();
        List<Rom> games = new List<Rom>();
        public bool Updated { get; set; }
        bool StopThread = false;
        bool ThreadStopped = false;
        string platformId;
        int syncRomsCount;
        List<Rom> notSyncedRoms = new List<Rom>();
        List<string> missingBoxartImages = null;
        List<string> missingTitleImages = null;
        List<string> missingGameplayImages = null;

        public FormSyncRomData()
        {
            InitializeComponent();
        }

        private void FormSyncRomData_Load(object sender, EventArgs e)
        {
            Updated = false;
            var platforms = Platform.GetAll();
            comboBoxPlatform.DisplayMember = "Name";
            comboBoxPlatform.ValueMember = "Id";
            comboBoxPlatform.DataSource = platforms;
            threadSetIdAndYear = new Thread(SetIdAndYear);
            threadSetOtherProperties = new Thread(SetOtherProperties);
        }

        private void buttonSync_Click(object sender, EventArgs e)
        {
            try
            {
                platformId = comboBoxPlatform.SelectedValue.ToString();
                textBoxLog.Text = "";
                progressBar.Value = 0;
                notSyncedRoms = Roms.Where(x => string.IsNullOrEmpty(x.Id) || string.IsNullOrEmpty(x.YearReleased) || string.IsNullOrEmpty(x.DBName)).ToList();
                LogMessage("GETTING GAMES LIST...");

                Updated = true;

                if (comboBoxPlatform.SelectedValue == null || string.IsNullOrEmpty(comboBoxPlatform.SelectedValue.ToString()) || comboBoxPlatform.SelectedValue.ToString() == "0")
                {
                    MessageBox.Show(string.Format("The platform {0} doesn't have an associated TheGamesDB.net Id. Update the platform Id in the Platform screen first.", comboBoxPlatform.SelectedText));
                    return;
                }

                games = Functions.GetGamesListByPlatform(comboBoxPlatform.SelectedValue.ToString());

                LogMessage(string.Format("{0} games found at online DB for the {1} platform", games.Count, comboBoxPlatform.Text));

                if (games == null)
                {
                    MessageBox.Show("An Error ocurred", "Error");
                    return;
                }

                progressBar.Maximum = notSyncedRoms.Count * 2;

                new Thread(() =>
                {
                    //threadSetIdAndYear.Start();
                    SetIdAndYear();
                    var count = syncRomsCount;

                    //threadSetOtherProperties.Start();
                    SetOtherProperties();
                    var count2 = syncRomsCount;

                    SetImages();
                    var count3 = syncRomsCount;

                    XML.SaveXml();

                    progressBar.Invoke((MethodInvoker)delegate
                    {
                        progressBar.Value = progressBar.Maximum;
                    });

                    LogMessage(count.ToString() + " roms Id/Year updated successfully!");
                    LogMessage(count2.ToString() + " roms details updated successfully!");
                    LogMessage(count3.ToString() + " roms images updated successfully!");

                MessageBox.Show(count.ToString() + " roms Id/Year updated successfully!" + Environment.NewLine +
                                count2.ToString() + " roms details updated successfully!" + Environment.NewLine +
                                count3.ToString() + " roms images updated successfully!"
                        );

                    comboBoxPlatform_SelectedIndexChanged(sender, e);
                }).Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                XML.SaveXml();
            }
        }

        private void SetIdAndYear()
        {
            syncRomsCount = 0;
            
            bool updated = false;
            ThreadStopped = false;
            bool found = false;
            string gameNameToDelete = string.Empty;

            foreach (var rom in notSyncedRoms)
            {
                if (found && !string.IsNullOrEmpty(gameNameToDelete))
                {
                    games.RemoveAll(x => x.DBName == gameNameToDelete);
                    gameNameToDelete = string.Empty;
                }

                if (progressBar.Maximum > progressBar.Value)
                {
                    labelProgress.Invoke((MethodInvoker)delegate
                    {
                        progressBar.Value++;
                    });
                }

                if (StopThread)
                {
                    StopThread = false;
                    Thread.CurrentThread.Abort();
                    comboBoxPlatform_SelectedIndexChanged(null, new EventArgs());
                }

                var romName = Functions.TrimRomName(rom.Name);
                found = false;

                foreach (var game in games)
                {
                    var gameName = Functions.TrimRomName(game.DBName);

                    if (romName == gameName)
                    {
                        gameNameToDelete = game.DBName;
                        found = true;

                        if (string.IsNullOrEmpty(rom.Id) && !string.IsNullOrEmpty(game.Id))
                        {
                            rom.Id = game.Id;
                            updated = true;
                        }

                        if (string.IsNullOrEmpty(rom.YearReleased) && !string.IsNullOrEmpty(game.YearReleased))
                        {
                            rom.YearReleased = game.YearReleased;
                            updated = true;
                        }

                        if (string.IsNullOrEmpty(rom.DBName) && !string.IsNullOrEmpty(game.DBName))
                        {
                            rom.DBName = game.DBName;
                            updated = true;
                        }

                        if (updated)
                        {
                            syncRomsCount++;
                            LogMessage("ID AND YEAR SET - " + rom.Name);
                            Rom.Set(rom);
                            updated = false;
                        }

                        break;
                    }
                }

                if (!found)
                {
                    LogMessage("NOT FOUND - " + rom.Name);
                    LogMessage("TRYING THE HARD WAY - " + rom.Name);
                    var gameName = Functions.RemoveSubstring(rom.Name, '(', ')');
                    gameName = Functions.RemoveSubstring(gameName, '[', ']').Trim();

                    var game = Functions.GetGameByName(platformId, gameName);

                    if (game == null)
                    {
                        LogMessage("REALLY NOT FOUND - " + rom.Name);
                        continue;
                    }

                    found = true;

                    if (string.IsNullOrEmpty(rom.Id) && !string.IsNullOrEmpty(game.Id))
                    {
                        rom.Id = game.Id;
                        updated = true;
                    }

                    if (string.IsNullOrEmpty(rom.YearReleased) && !string.IsNullOrEmpty(game.YearReleased))
                    {
                        rom.YearReleased = game.YearReleased;
                        updated = true;
                    }

                    if (string.IsNullOrEmpty(rom.DBName) && !string.IsNullOrEmpty(game.DBName))
                    {
                        rom.DBName = game.DBName;
                        updated = true;
                    }

                    if (updated)
                    {
                        syncRomsCount++;
                        LogMessage("ID AND YEAR SET - " + rom.Name);
                        Rom.Set(rom);
                        updated = false;
                    }
                }
            }

            ThreadStopped = true;
        }

        private void SetOtherProperties()
        {
            var notSyncedRoms = Roms.Where(x => !string.IsNullOrEmpty(x.Id) && (string.IsNullOrEmpty(x.Publisher) || string.IsNullOrEmpty(x.Developer) || string.IsNullOrEmpty(x.Description) || x.Genre == null)).ToList();

            bool updated = false;
            syncRomsCount = 0;
            ThreadStopped = false;

            foreach (var rom in notSyncedRoms)
            {
                if (StopThread)
                {
                    StopThread = false;
                    Thread.CurrentThread.Abort();
                    comboBoxPlatform_SelectedIndexChanged(null, new EventArgs());
                }

                if (progressBar.Maximum > progressBar.Value)
                {
                    progressBar.Invoke((MethodInvoker)delegate
                    {
                        progressBar.Value++;
                    });
                }

                LogMessage("UPDATING - " + rom.Name);
                var game = Functions.GetGameDetails(rom.Id);

                if (game == null) continue;

                if (string.IsNullOrEmpty(rom.Publisher) && !string.IsNullOrEmpty(game.Publisher))
                {
                    rom.Publisher = game.Publisher;
                    updated = true;
                }

                if (string.IsNullOrEmpty(rom.Developer) && !string.IsNullOrEmpty(game.Developer))
                {
                    rom.Developer = game.Developer;
                    updated = true;
                }

                if (string.IsNullOrEmpty(rom.Description) && !string.IsNullOrEmpty(game.Description))
                {
                    rom.Description = game.Description;
                    updated = true;
                }

                if (rom.Genre == null && game.Genre != null)
                {
                    rom.Genre = game.Genre;
                    updated = true;
                }

                if (updated)
                {
                    syncRomsCount++;
                    Rom.Set(rom);
                    updated = false;
                }

                ThreadStopped = true;
            }
        }


        private void SetImages()
        {
            if (progressBar.Maximum > progressBar.Value)
            {
                progressBar.Invoke((MethodInvoker)delegate
                {
                    progressBar.Maximum = progressBar.Value;
                });
            }

            syncRomsCount = 0;

            var romsList = Roms.Select(x => x.Name).ToList();

            var notSyncedRoms = Roms.Where(x => !string.IsNullOrEmpty(x.Id) && 
                                    (missingBoxartImages.Contains(x.Name) || 
                                    missingTitleImages.Contains(x.Name) || 
                                    missingGameplayImages.Contains(x.Name))).ToList();

            bool updated = false;
            syncRomsCount = 0;
            ThreadStopped = false;

            progressBar.Invoke((MethodInvoker)delegate
            {
                progressBar.Value = 0;
            });

            foreach (var rom in notSyncedRoms)
            {
                if (StopThread)
                {
                    StopThread = false;
                    Thread.CurrentThread.Abort();
                    comboBoxPlatform_SelectedIndexChanged(null, new EventArgs());
                }

                if (progressBar.Maximum > progressBar.Value)
                {
                    progressBar.Invoke((MethodInvoker)delegate
                    {
                        progressBar.Value++;
                    });
                }

                var boxArtMissing = missingBoxartImages.Contains(rom.Name);
                var titleMissing = missingTitleImages.Contains(rom.Name);
                var gameplayMissing = missingGameplayImages.Contains(rom.Name);

                if (boxArtMissing || titleMissing || gameplayMissing)
                {
                    string boxUrl = string.Empty;
                    string titleUrl = string.Empty;
                    string gameplayUrl = string.Empty;

                    var found = Functions.GetGameArtUrls(rom.Id, out boxUrl, out titleUrl, out gameplayUrl);

                    if (!found) continue;

                    syncRomsCount++;

                    if (boxArtMissing && !string.IsNullOrEmpty(boxUrl))
                    {
                        LogMessage("UPDATING BOXART IMAGE - " + rom.Name);
                        SaveImage(boxUrl, rom, Values.BoxartFolder);
                    }

                    if (titleMissing && !string.IsNullOrEmpty(titleUrl))
                    {
                        LogMessage("UPDATING TILE IMAGE - " + rom.Name);
                        SaveImage(titleUrl, rom, Values.TitleFolder);
                    }

                    if (gameplayMissing && !string.IsNullOrEmpty(gameplayUrl))
                    {
                        LogMessage("UPDATING GAMEPLAY IMAGE - " + rom.Name);
                        SaveImage(gameplayUrl, rom, Values.GameplayFolder);
                    }
                }
            }
        }

        private void SaveImage(string url, Rom rom, string folder)
        {
            if (string.IsNullOrEmpty(url)) return;

            string extension = url.Substring(url.LastIndexOf("."));
            string imagePath = "image" + extension;

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(url), imagePath);
            }

            Functions.SavePicture(rom, imagePath, folder, checkBoxSaveAsJpg.Checked);
            File.Delete(imagePath);
        }

        private void comboBoxPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelId.Text = "-";
            labelGenre.Text = "-";
            labelPublisher.Text = "-";
            labelDeveloper.Text = "-";
            labelDescription.Text = "-";
            labelYearReleased.Text = "-";
            labelBoxart.Text = "-";
            labelTitle.Text = "-";
            labelGameplay.Text = "-";

            Roms.Clear();
            Roms.AddRange(Rom.GetAll().Where(r => r.Platform != null && r.Platform.Name == comboBoxPlatform.Text).ToList());

            labelId.Text = Roms.Where(x => string.IsNullOrEmpty(x.Id)).Count().ToString();
            labelGenre.Text = Roms.Where(x => x.Genre == null).Count().ToString();
            labelPublisher.Text = Roms.Where(x => string.IsNullOrEmpty(x.Publisher)).Count().ToString();
            labelDeveloper.Text = Roms.Where(x => string.IsNullOrEmpty(x.Developer)).Count().ToString();
            labelDescription.Text = Roms.Where(x => string.IsNullOrEmpty(x.Description)).Count().ToString();
            labelYearReleased.Text = Roms.Where(x => string.IsNullOrEmpty(x.YearReleased)).Count().ToString();

            var boxartImages = Functions.GetRomImagesByPlatform(comboBoxPlatform.Text, Values.BoxartFolder);
            var titleImages = Functions.GetRomImagesByPlatform(comboBoxPlatform.Text, Values.TitleFolder);
            var gameplayImages = Functions.GetRomImagesByPlatform(comboBoxPlatform.Text, Values.GameplayFolder);

            var romsList = Roms.Select(x => x.Name).ToList();

            missingBoxartImages = romsList.Except(boxartImages).ToList();
            missingTitleImages = romsList.Except(titleImages).ToList();
            missingGameplayImages = romsList.Except(gameplayImages).ToList();

            labelBoxart.Text = missingBoxartImages.Count().ToString();
            labelTitle.Text = missingTitleImages.Count().ToString();
            labelGameplay.Text = missingGameplayImages.Count().ToString();
        }

        private void LogMessage(string message)
        {
            labelProgress.Invoke((MethodInvoker)delegate
            {
                labelProgress.Text = message;
                labelProgress.Refresh();
            });

            labelProgress.Invoke((MethodInvoker)delegate
            {
                textBoxLog.AppendText(message + Environment.NewLine);
                textBoxLog.Refresh();
            });
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            StopThread = true;
            Thread.Sleep(1000);
            XML.SaveXml();
            Close();
        }

        private void buttonStopProcess_Click(object sender, EventArgs e)
        {
            StopThread = true;
            XML.SaveXml();
        }
    }
}
