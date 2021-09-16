using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using EmuLoader.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        bool StopThread = false;
        bool ThreadStopped = false;
        string platformId;
        int syncRomsCount;
        List<Rom> notSyncedRoms = new List<Rom>();
        List<string> missingBoxartPictures = null;
        List<string> missingTitlePictures = null;
        List<string> missingGameplayPictures = null;

        public FormSyncRomData()
        {
            InitializeComponent();
        }

        private void FormSyncRomData_Load(object sender, EventArgs e)
        {
            Updated = false;
            var platforms = PlatformBusiness.GetAll();
            comboBoxPlatform.DisplayMember = "Name";
            comboBoxPlatform.ValueMember = "Id";
            comboBoxPlatform.DataSource = platforms;
            threadSetIdAndYear = new Thread(SetIdAndYear);
            threadSetOtherProperties = new Thread(SetOtherProperties);
            checkBoxBasicSync_CheckedChanged(sender, e);
        }

        private void buttonSync_Click(object sender, EventArgs e)
        {
            try
            {
                comboBoxPlatform.Enabled = false;
                buttonSync.Enabled = false;
                platformId = comboBoxPlatform.SelectedValue.ToString();
                textBoxLog.Text = "";
                progressBar.Value = 0;

                if (checkBoxBasicSync.Checked)
                {
                    notSyncedRoms = Roms.Where(x => !x.IdLocked && (string.IsNullOrEmpty(x.Id))).ToList();
                }
                else
                {
                    notSyncedRoms = Roms.Where(x => !x.IdLocked && (string.IsNullOrEmpty(x.Id) || string.IsNullOrEmpty(x.YearReleased) || string.IsNullOrEmpty(x.DBName))).ToList();
                }
                
                LogMessage("GETTING GAMES LIST...");

                Updated = true;

                if (comboBoxPlatform.SelectedValue == null || string.IsNullOrEmpty(comboBoxPlatform.SelectedValue.ToString()) || comboBoxPlatform.SelectedValue.ToString() == "0")
                {
                    FormCustomMessage.ShowInfo(string.Format("The platform {0} doesn't have an associated TheGamesDB.net Id. Update the platform Id in the Platform screen first.", comboBoxPlatform.SelectedText));
                    comboBoxPlatform.Enabled = true;
                    buttonSync.Enabled = true;
                    return;
                }

                var json = RomFunctions.GetPlatformJson(comboBoxPlatform.Text);

                games = APIFunctions.GetGamesListByPlatform(comboBoxPlatform.SelectedValue.ToString(), json, comboBoxPlatform.Text);

                if (games == null)
                {
                    FormCustomMessage.ShowError("An Error ocurred");
                    comboBoxPlatform.Enabled = true;
                    buttonSync.Enabled = true;
                    return;
                }

                LogMessage(string.Format("{0} games found at online DB for the {1} platform", games.Count, comboBoxPlatform.Text));

                progressBar.Maximum = notSyncedRoms.Count * 2;

                new Thread(() =>
                {
                    if (radioButtonSyncAll.Checked)
                    {
                        //threadSetIdAndYear.Start();
                        SetIdAndYear();
                    }

                    int count = 0;
                    int count2 = 0;
                    int count3 = 0;

                    count = syncRomsCount;

                    if (!checkBoxBasicSync.Checked)
                    {
                        if (radioButtonSyncAll.Checked)
                        {
                            //threadSetOtherProperties.Start();
                            SetOtherProperties();
                            count2 = syncRomsCount;
                        }

                        SetPictures();
                        count3 = syncRomsCount;
                    }

                    progressBar.Invoke((MethodInvoker)delegate
                    {
                        progressBar.Value = progressBar.Maximum;
                    });

                    LogMessage(count.ToString() + " roms Id/Year updated successfully!");
                    LogMessage(count2.ToString() + " roms details updated successfully!");
                    LogMessage(count3.ToString() + " roms images updated successfully!");

                    FormCustomMessage.ShowSuccess(count.ToString() + " roms Id/Year updated successfully!" + Environment.NewLine +
                                count2.ToString() + " roms details updated successfully!" + Environment.NewLine +
                                count3.ToString() + " roms images updated successfully!"
                            );

                    comboBoxPlatform_SelectedIndexChanged(sender, e);

                    comboBoxPlatform.Invoke((MethodInvoker)delegate
                    {
                        comboBoxPlatform.Enabled = true;
                    });

                    buttonSync.Invoke((MethodInvoker)delegate
                    {
                        buttonSync.Enabled = true;
                    });
                }).Start();

            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
                buttonStopProcess_Click(null, e);
                textBoxLog.Text = "";
            }
        }

        private void buttonLockIds_Click(object sender, EventArgs e)
        {
            var roms = RomBusiness.GetAll().Where(x => x.Platform != null && x.Platform.Name == comboBoxPlatform.Text && !x.IdLocked && (string.IsNullOrEmpty(x.Id) || x.Id.Length == 10)).ToList();

            if (roms == null || roms.Count == 0)
            {
                FormCustomMessage.ShowInfo("There are no roms with empty Ids");
                comboBoxPlatform.Enabled = true;
                buttonSync.Enabled = true;
                return;
            }

            progressBar.Maximum = roms.Count;
            progressBar.Value = 0;

            foreach (var item in roms)
            {
                item.IdLocked = true;
                item.Id = string.Empty;
                progressBar.Value++;
            }

            RomBusiness.SetRom(roms);
            FormCustomMessage.ShowSuccess(string.Format("{0} rom Ids locked successfully!", roms.Count));
        }

        private void buttonUnlockIds_Click(object sender, EventArgs e)
        {
            var roms = RomBusiness.GetAll().Where(x => x.Platform.Name == comboBoxPlatform.Text && x.IdLocked).ToList();

            if (roms == null || roms.Count == 0)
            {
                FormCustomMessage.ShowInfo("There are no roms with locked Ids");
                comboBoxPlatform.Enabled = true;
                buttonSync.Enabled = true;
                return;
            }

            progressBar.Maximum = roms.Count;
            progressBar.Value = 0;

            foreach (var item in roms)
            {
                item.IdLocked = false;
                progressBar.Value++;
            }

            RomBusiness.SetRom(roms);
            FormCustomMessage.ShowSuccess(string.Format("{0} rom Ids unlocked successfully!", roms.Count));
        }

        private void SetIdAndYear()
        {
            syncRomsCount = 0;

            bool updated = false;
            ThreadStopped = false;
            bool found = false;
            string gameNameToDelete = string.Empty;
            List<Rom> romList = new List<Rom>();

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
                    RomBusiness.SetRom(romList);
                    Thread.CurrentThread.Abort();
                    comboBoxPlatform_SelectedIndexChanged(null, new EventArgs());
                }

                var romName = RomFunctions.TrimRomName(rom.Name);
                found = false;

                foreach (var game in games)
                {
                    var gameName = RomFunctions.TrimRomName(game.DBName);

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
                            romList.Add(rom);
                            updated = false;
                        }

                        break;
                    }
                }

                if (!found)
                {
                    LogMessage("NOT FOUND - " + rom.Name);

                    if (!checkBoxBasicSync.Checked)
                    {
                        LogMessage("TRYING BY NAME - " + rom.Name);
                        var gameName = Functions.RemoveSubstring(rom.Name, '(', ')');
                        gameName = Functions.RemoveSubstring(gameName, '[', ']').Trim();
                        string acessos = "";
                        var game = APIFunctions.GetGameByName(platformId, gameName, out acessos);

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
                            romList.Add(rom);
                            updated = false;
                        }
                    }
                }
            }

            RomBusiness.SetRom(romList);
            ThreadStopped = true;
        }

        private void SetOtherProperties()
        {
            var notSyncedRoms = Roms.Where(x => !string.IsNullOrEmpty(x.Id) && (string.IsNullOrEmpty(x.DBName) || string.IsNullOrEmpty(x.Publisher) || string.IsNullOrEmpty(x.Developer))).ToList();

            bool updated = false;
            syncRomsCount = 0;
            ThreadStopped = false;
            List<Rom> romList = new List<Rom>();

            foreach (var rom in notSyncedRoms)
            {
                if (StopThread)
                {
                    StopThread = false;
                    RomBusiness.SetRom(romList);
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

                var access = "";
                LogMessage("UPDATING - " + rom.Name);
                var game = APIFunctions.GetGameDetails(rom.Id, rom.Platform, out access);
                labelAccessLeftCount.Text = access;

                if (game == null) continue;

                if (string.IsNullOrEmpty(rom.DBName) && !string.IsNullOrEmpty(game.DBName))
                {
                    rom.DBName = game.DBName;
                    updated = true;
                }

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

                if ((rom.Rating == null || rom.Rating == 0) && (game.Rating != null && game.Rating > 0))
                {
                    rom.Rating = game.Rating;
                    updated = true;
                }

                if (updated)
                {
                    syncRomsCount++;
                    romList.Add(rom);
                    updated = false;
                }
            }

            RomBusiness.SetRom(romList);
            ThreadStopped = true;
        }


        private void SetPictures()
        {
            if (progressBar.Maximum > progressBar.Value)
            {
                progressBar.Invoke((MethodInvoker)delegate
                {
                    progressBar.Maximum = progressBar.Value;
                });
            }

            syncRomsCount = 0;

            var notSyncedRoms = Roms.Where(x => !string.IsNullOrEmpty(x.Id) &&
                                    (missingBoxartPictures.Contains(x.Name) ||
                                    missingTitlePictures.Contains(x.Name) ||
                                    missingGameplayPictures.Contains(x.Name))).ToList();

            syncRomsCount = 0;
            ThreadStopped = false;

            progressBar.Invoke((MethodInvoker)delegate
            {
                progressBar.Value = 0;
                progressBar.Maximum = notSyncedRoms.Count;
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

                var boxArtMissing = missingBoxartPictures.Contains(rom.Name);
                var titleMissing = missingTitlePictures.Contains(rom.Name);
                var gameplayMissing = missingGameplayPictures.Contains(rom.Name);

                if (boxArtMissing || titleMissing || gameplayMissing)
                {
                    string boxUrl = string.Empty;
                    string titleUrl = string.Empty;
                    string gameplayUrl = string.Empty;

                    var access = "";
                    var found = APIFunctions.GetGameArtUrls(rom.Id, out boxUrl, out titleUrl, out gameplayUrl, out access);
                    labelAccessLeftCount.Text = access;

                    var updateBoxart = boxArtMissing && !string.IsNullOrEmpty(boxUrl);
                    var updateTitle = titleMissing && !string.IsNullOrEmpty(titleUrl);
                    var updateGameplay = gameplayMissing && !string.IsNullOrEmpty(gameplayUrl);

                    if (!found || (!updateBoxart && !updateTitle && !updateGameplay))
                    {
                        LogMessage("MISSING PICTURES NOT FOUND - " + rom.Name);
                        continue;
                    }

                    syncRomsCount++;

                    if (updateBoxart)
                    {
                        LogMessage("UPDATING BOXART PICTURE - " + rom.Name);
                        SyncDataFunctions.SavePictureFromUrl(rom, boxUrl, Values.BoxartFolder, checkBoxSaveAsJpg.Checked);
                    }

                    if (updateTitle)
                    {
                        LogMessage("UPDATING TITLE PICTURE - " + rom.Name);
                        SyncDataFunctions.SavePictureFromUrl(rom, titleUrl, Values.TitleFolder, checkBoxSaveAsJpg.Checked);
                    }

                    if (updateGameplay)
                    {
                        LogMessage("UPDATING GAMEPLAY PICTURE - " + rom.Name);
                        SyncDataFunctions.SavePictureFromUrl(rom, gameplayUrl, Values.GameplayFolder, checkBoxSaveAsJpg.Checked);
                    }
                }
            }
        }

        private void comboBoxPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                labelId.Invoke((MethodInvoker)delegate
                {
                    labelId.Text = "-";
                });

                labelGenre.Invoke((MethodInvoker)delegate
                {
                    labelGenre.Text = "-";
                });

                labelPublisher.Invoke((MethodInvoker)delegate
                {
                    labelPublisher.Text = "-";
                });

                labelDeveloper.Invoke((MethodInvoker)delegate
                {
                    labelDeveloper.Text = "-";
                });

                labelDescription.Invoke((MethodInvoker)delegate
                {
                    labelDescription.Text = "-";
                });

                labelYearReleased.Invoke((MethodInvoker)delegate
                {
                    labelYearReleased.Text = "-";
                });

                labelBoxart.Invoke((MethodInvoker)delegate
                {
                    labelBoxart.Text = "-";
                });

                labelTitle.Invoke((MethodInvoker)delegate
                {
                    labelTitle.Text = "-";
                });

                labelGameplay.Invoke((MethodInvoker)delegate
                {
                    labelGameplay.Text = "-";
                });

                labelRating.Invoke((MethodInvoker)delegate
                {
                    labelRating.Text = "-";
                });

                Roms.Clear();
                Roms.AddRange(RomBusiness.GetAll().Where(r => r.Platform != null && r.Platform.Name == comboBoxPlatform.Text).ToList());

                labelId.Invoke((MethodInvoker)delegate
                {
                    labelId.Text = Roms.Where(x => string.IsNullOrEmpty(x.Id)).Count().ToString();
                });

                labelGenre.Invoke((MethodInvoker)delegate
                {
                    labelGenre.Text = Roms.Where(x => x.Genre == null).Count().ToString();
                });

                labelPublisher.Invoke((MethodInvoker)delegate
                {
                    labelPublisher.Text = Roms.Where(x => string.IsNullOrEmpty(x.Publisher)).Count().ToString();
                });

                labelDeveloper.Invoke((MethodInvoker)delegate
                {
                    labelDeveloper.Text = Roms.Where(x => string.IsNullOrEmpty(x.Developer)).Count().ToString();
                });

                labelDescription.Invoke((MethodInvoker)delegate
                {
                    labelDescription.Text = Roms.Where(x => string.IsNullOrEmpty(x.Description)).Count().ToString();
                });

                labelYearReleased.Invoke((MethodInvoker)delegate
                {
                    labelYearReleased.Text = Roms.Where(x => string.IsNullOrEmpty(x.YearReleased)).Count().ToString();
                });

                labelRating.Invoke((MethodInvoker)delegate
                {
                    labelRating.Text = Roms.Where(x => x.Rating == null || x.Rating == 0).Count().ToString();
                });

                var boxartPictures = RomFunctions.GetRomPicturesByPlatform(comboBoxPlatform.Text, Values.BoxartFolder);
                var titlePictures = RomFunctions.GetRomPicturesByPlatform(comboBoxPlatform.Text, Values.TitleFolder);
                var gameplayPictures = RomFunctions.GetRomPicturesByPlatform(comboBoxPlatform.Text, Values.GameplayFolder);

                var romsList = Roms.Select(x => x.FileNameNoExt).ToList();

                missingBoxartPictures = romsList.Except(boxartPictures).ToList();
                missingTitlePictures = romsList.Except(titlePictures).ToList();
                missingGameplayPictures = romsList.Except(gameplayPictures).ToList();

                labelBoxart.Invoke((MethodInvoker)delegate
                {
                    labelBoxart.Text = missingBoxartPictures.Count().ToString();
                });

                labelTitle.Invoke((MethodInvoker)delegate
                {
                    labelTitle.Text = missingTitlePictures.Count().ToString();
                });

                labelGameplay.Invoke((MethodInvoker)delegate
                {
                    labelGameplay.Text = missingGameplayPictures.Count().ToString();
                });
            }
            catch
            {
            }
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
            try
            {
                StopThread = true;
                Thread.Sleep(1000);
                Close();
            }
            finally
            {
            }
        }

        private void buttonStopProcess_Click(object sender, EventArgs e)
        {
            try
            {
                StopThread = true;
                comboBoxPlatform.Enabled = true;
                buttonSync.Enabled = true;
            }
            finally
            {
            }
        }

        private void checkBoxBasicSync_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBasicSync.Checked)
            {
                radioButtonSyncAll.Enabled = false;
                radioButtonImages.Enabled = false;
            }
            else
            {
                radioButtonSyncAll.Enabled = true;
                radioButtonImages.Enabled = true;
            }
        }
    }
}
