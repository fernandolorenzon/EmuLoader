using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using EmuLoader.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace EmuLoader.Forms
{
    public partial class FormMain
    {

        private void manageLabelToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                FormLabel form = new FormLabel();

                if (form.ShowDialogUpdated())
                {
                    FillLabelFilter();
                    buttonClear_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void manageGenreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string genre = comboBoxGenre.SelectedValue == null ? string.Empty : comboBoxGenre.SelectedValue.ToString();

                FormGenre form = new FormGenre();

                if (form.ShowDialogUpdated())
                {
                    //Genre.Fill();
                    //Rom.Fill();
                    FilterRoms();
                    FillGenreFilter(genre);
                }
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void managePlatformToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                string platform = comboBoxPlatform.SelectedValue == null ? string.Empty : comboBoxPlatform.SelectedValue.ToString();

                FormPlatform form = new FormPlatform();

                if (form.ShowDialogUpdated())
                {
                    FilterRoms();
                    FillPlatformFilter(platform);
                    FillPlatformGrid();
                }
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void addRomDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog open = new FolderBrowserDialog();
                open.SelectedPath = Environment.CurrentDirectory;

                if (open.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                if (open.SelectedPath.Length == 0)
                {
                    return;
                }

                Platform platform = null;
                FormChoose.ChoosePlatform(out platform);
                RomFunctions.AddRomsFromDirectory(platform, open.SelectedPath);
                XML.SaveXmlRoms();
                FilterRoms();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void toolStripButtonAddRom_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.InitialDirectory = Environment.CurrentDirectory;

                open.Filter = "Roms | *.zip;*.smc;*.fig;*.gba;*.gbc;*.gb;*.pce;*.n64;*.smd;*.sms;*.ccd;*.cue;*.bin;*.iso;*.gdi;*.cdi|" +
                              "Zip | *.zip|" +
                              "CD | *.cue|" +
                              "CD | *.ccd|" +
                              "CD ISO | *.iso|" +
                              "CD Image | *.bin|" +
                              "Dreamcast Image | *.cdi;*.gdi|" +
                              "Snes | *.smc|" +
                              "Snes | *.fig|" +
                              "GBA | *.gba|" +
                              "GBC | *.gbc|" +
                              "GB | *.gb|" +
                              "PC Engine | *.pce|" +
                              "N64 | *.n64|" +
                              "Mega Drive | *.smd|" +
                              "Master System | *.sms|" +
                              "All | *.*";
                open.Multiselect = true;

                if (open.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                if (open.FileNames.Length == 0)
                {
                    return;
                }

                Platform platform = null;
                FormChoose.ChoosePlatform(out platform);
                RomFunctions.AddRomsFiles(platform, open.FileNames);
                XML.SaveXmlRoms();

                FilterRoms();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

    }
}
