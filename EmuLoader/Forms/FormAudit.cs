﻿using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmuLoader.Forms
{
    public partial class FormAudit : FormBase
    {
        public FormAudit()
        {
            InitializeComponent();

            List<Platform> platforms = Platform.GetAll();
            platforms.Insert(0, new Platform());
            comboBoxPlatform.DataSource = platforms;
            comboBoxPlatform.DisplayMember = "Name";
            comboBoxPlatform.ValueMember = "Name";
        }

        private void buttonCleanIncorrectRomPlatform_Click(object sender, EventArgs e)
        {
            if (comboBoxPlatform.Text == "" || comboBoxPlatform.Text == "none")
            {
                FormCustomMessage.ShowError("Select a platform");
            }

            var json = RomFunctions.GetPlatformJson(comboBoxPlatform.Text);

            if (json == "") return;

            var roms = Rom.GetAll(Platform.Get(comboBoxPlatform.Text));
            int count = 0;

            foreach (var rom in roms)
            {
                if (string.IsNullOrEmpty(rom.Id))
                {
                    continue;
                }

                if (!json.Contains("\"id\": " + rom.Id + ","))
                {
                    rom.Id = "";
                    rom.Name = rom.FileNameNoExt;
                    rom.DBName = "";
                    rom.Description = "";
                    rom.IdLocked = false;
                    rom.Publisher = "";
                    rom.YearReleased = "";
                    rom.Developer = "";
                    rom.Rating = 0;
                    
                    Rom.Set(rom);

                    count++;
                    Updated = true;
                }
            }

            XML.SaveXml();

            FormCustomMessage.ShowSuccess("Roms updated successfully! " + count.ToString() + " roms cleaned");
        }

        private void buttonUpdateAllRomsNames_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxPlatform.Text == "" || comboBoxPlatform.Text == "none")
                {
                    FormCustomMessage.ShowError("Select a platform");
                }

                Platform platform = Platform.Get(comboBoxPlatform.Text);
                var roms = Rom.GetAll(platform);
                int count = 0;

                foreach (var rom in roms)
                {
                    var name = RomFunctions.GetMAMENameFromCSV(rom.FileNameNoExt);

                    if (name == "") continue;

                    if (rom.Name != name)
                    {
                        rom.Name = name;
                        Rom.Set(rom);
                        count++;
                    }
                }

                XML.SaveXml();
                FormCustomMessage.ShowSuccess("Rom names updated successfully! Total:" + count.ToString());
                Updated = true;
            }
            catch (Exception ex)
            {
                //FormWait.CloseWait();
                FormCustomMessage.ShowError(ex.Message);
            }
            finally
            {
                //FormWait.CloseWait();
            }
        }

        private void buttonUpdateNameFromDBName_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxPlatform.Text == "" || comboBoxPlatform.Text == "none")
                {
                    FormCustomMessage.ShowError("Select a platform");
                }

                Platform platform = Platform.Get(comboBoxPlatform.Text);
                var roms = Rom.GetAll(platform);
                int count = 0;

                foreach (var rom in roms)
                {
                    if (!string.IsNullOrEmpty(rom.DBName))
                    {
                        var newname = rom.DBName.Replace(":", " -");

                        if (rom.Name != newname)
                        {
                            rom.Name = newname;
                            Rom.Set(rom);
                            count++;
                        }
                    }
                }

                XML.SaveXml();
                FormCustomMessage.ShowSuccess("Rom names updated successfully! Total:" + count.ToString());
                Updated = true;
            }
            catch (Exception ex)
            {
                //FormWait.CloseWait();
                FormCustomMessage.ShowError(ex.Message);
            }
            finally
            {
                //FormWait.CloseWait();
            }
        }

        private void buttonShowMissingRoms_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxPlatform.Text == "" || comboBoxPlatform.Text == "none")
                {
                    FormCustomMessage.ShowError("Select a platform");
                }

                Platform platform = Platform.Get(comboBoxPlatform.Text);
                var json = RomFunctions.GetPlatformJson(comboBoxPlatform.Text);

                if (string.IsNullOrEmpty(json))
                {
                    FormCustomMessage.ShowError("Json not found. Sync platform first");
                }

                var games = APIFunctions.GetGamesListByPlatform(platform.Id, json);
                var roms = Rom.GetAll(platform);

                StringBuilder builder = new StringBuilder("");

                foreach (var game in games)
                {
                    if (!roms.Any(x => x.Id == game.Id))
                    {
                        builder.Append(game.Id + "-" + game.DBName + Environment.NewLine);
                    }
                }

                FormInfo info = new FormInfo(builder.ToString());
                info.Show();

                Updated = true;
            }
            catch (Exception ex)
            {
                //FormWait.CloseWait();
                FormCustomMessage.ShowError(ex.Message);
            }
            finally
            {
                //FormWait.CloseWait();
            }
        }
    }
}