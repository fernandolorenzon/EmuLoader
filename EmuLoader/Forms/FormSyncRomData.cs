using EmuLoader.Classes;
using System;
using System.Collections.Generic;
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
        public bool Updated { get; set; }
        bool StopThread = false;
        bool ThreadStopped = false;

        int syncRomsCount;

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

                textBoxLog.Text = "";
                progressBar.Value = 0;
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

                new Thread(() =>
                {
                    //threadSetIdAndYear.Start();
                    SetIdAndYear();
                    var count = syncRomsCount;

                    //threadSetOtherProperties.Start();
                    SetOtherProperties();
                    var count2 = syncRomsCount;


                    LogMessage(count.ToString() + " roms Id/Year updated successfully!");
                    LogMessage(count2.ToString() + " roms details updated successfully!");

                    MessageBox.Show(count.ToString() + " roms Id/Year updated successfully!" + Environment.NewLine +
                                    count2.ToString() + " roms details updated successfully!"
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
            var notSyncedRoms = Roms.Where(x => string.IsNullOrEmpty(x.Id) || string.IsNullOrEmpty(x.YearReleased)).ToList();
            bool updated = false;
            ThreadStopped = false;
            bool found = false;

            foreach (var rom in notSyncedRoms)
            {
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
                    var gameName = Functions.TrimRomName(game.Name);

                    if (romName == gameName)
                    {
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

                        if (updated)
                        {
                            syncRomsCount++;
                            LogMessage("ID AND YEAR SET - " + rom.Name);
                            Rom.Set(rom);
                            updated = false;
                        }

                        continue;
                    }
                }

                if (!found)
                {
                    LogMessage("NOT FOUND - " + rom.Name);
                }
            }

            ThreadStopped = true;
        }

        private void SetOtherProperties()
        {
            var notSyncedRoms = Roms.Where(x => !string.IsNullOrEmpty(x.Id) && (string.IsNullOrEmpty(x.Publisher) || string.IsNullOrEmpty(x.Developer) || string.IsNullOrEmpty(x.Description) || x.Genre == null)).ToList();

            progressBar.Invoke((MethodInvoker)delegate
            {
                progressBar.Maximum = notSyncedRoms.Count;
            });

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
                    labelProgress.Invoke((MethodInvoker)delegate
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

        private void comboBoxPlatform_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelGenre.Text = "-";
            labelPublisher.Text = "-";
            labelDeveloper.Text = "-";
            labelDescription.Text = "-";
            labelYearReleased.Text = "-";

            Roms.Clear();
            Roms.AddRange(Rom.GetAll().Where(r => r.Platform != null && r.Platform.Name == comboBoxPlatform.Text).ToList());

            labelGenre.Text = Roms.Where(x => x.Genre == null).Count().ToString();
            labelPublisher.Text = Roms.Where(x => string.IsNullOrEmpty(x.Publisher)).Count().ToString();
            labelDeveloper.Text = Roms.Where(x => string.IsNullOrEmpty(x.Developer)).Count().ToString();
            labelDescription.Text = Roms.Where(x => string.IsNullOrEmpty(x.Description)).Count().ToString();
            labelYearReleased.Text = Roms.Where(x => string.IsNullOrEmpty(x.YearReleased)).Count().ToString();
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
