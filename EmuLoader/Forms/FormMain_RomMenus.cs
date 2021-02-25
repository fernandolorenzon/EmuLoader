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

        private void changePlatformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Platform selected = null;

                if (!FormChoose.ChoosePlatform(out selected)) return;

                List<Rom> romList = new List<Rom>();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    romList.Add((Rom)row.Tag);
                }

                RomFunctions.ChangeRomsPlatform(romList, selected);
                XML.SaveXmlRoms();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    Rom rom = (Rom)row.Tag;

                    if (rom.Platform != null)
                    {
                        row.Cells[columnPlatform.Index].Value = rom.Platform.Name;
                        row.Cells[columnPlatform.Index].Style.BackColor = rom.Platform.Color;
                        row.Cells[columnPlatform.Index].Style.ForeColor = Functions.SetFontContrast(rom.Platform.Color);
                    }
                    else
                    {
                        row.Cells[columnPlatform.Index].Value = "";
                        row.Cells[columnPlatform.Index].Style.BackColor = Color.White;
                        row.Cells[columnPlatform.Index].Style.ForeColor = Color.Black;
                    }
                }

                dataGridView.Refresh();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void changeGenreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Genre selected = null;

                if (!FormChoose.ChooseGenre(out selected)) return;

                List<Rom> romList = new List<Rom>();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    romList.Add((Rom)row.Tag);
                }

                GenreBusiness.ChangeRomsGenre(romList, selected);
                XML.SaveXmlRoms();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    Rom rom = (Rom)row.Tag;

                    if (rom.Genre != null)
                    {
                        row.Cells[columnGenre.Index].Value = rom.Genre.Name;
                        row.Cells[columnGenre.Index].Style.BackColor = rom.Genre.Color;
                        row.Cells[columnGenre.Index].Style.ForeColor = Functions.SetFontContrast(rom.Genre.Color);
                    }
                    else
                    {
                        row.Cells[columnGenre.Index].Value = "";
                        row.Cells[columnGenre.Index].Style.BackColor = Color.White;
                        row.Cells[columnGenre.Index].Style.ForeColor = Color.Black;
                    }
                }

                dataGridView.Refresh();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void changeStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 0) return;

                RomStatus status = ((Rom)dataGridView.SelectedRows[0].Tag).Status;
                var statusvalue = status == null ? "" : status.Status;
                string newstatus = "";

                if (!FormChoose.ChooseStatus(statusvalue, out newstatus)) return;

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    var rom = (Rom)row.Tag;

                    if (status == null)
                    {
                        RomStatusBusiness.Set(rom, newstatus);
                    }
                    else
                    {
                        status.Status = newstatus;
                        RomStatusBusiness.Set(status);
                    }
                }

                XML.SaveXmlRomStatus();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    Rom rom = (Rom)row.Tag;

                    if (rom.Status != null && !string.IsNullOrEmpty(rom.Status.Status))
                    {
                        row.Cells[columnStatus.Index].Value = rom.Status.Status;
                        row.Cells[columnStatus.Index].Style.BackColor = Color.Navy;
                        row.Cells[columnStatus.Index].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        row.Cells[columnStatus.Index].Value = "";
                        row.Cells[columnStatus.Index].Style.ForeColor = dataGridView.RowTemplate.DefaultCellStyle.ForeColor;
                        row.Cells[columnStatus.Index].Style.BackColor = dataGridView.RowTemplate.DefaultCellStyle.BackColor;
                    }
                }

                dataGridView.Refresh();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void changeLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 0) return;

                List<RomLabel> selectedLabels = new List<RomLabel>();
                List<RomLabel> unselectedLabels = new List<RomLabel>();
                RomLabels labels = ((Rom)dataGridView.SelectedRows[0].Tag).RomLabels;

                List<Rom> roms = new List<Rom>();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    roms.Add((Rom)row.Tag);
                }

                if (!FormChooseList.ChooseLabel(roms, out selectedLabels, out unselectedLabels)) return;

                foreach (var rom in roms)
                {
                    RomLabelsBusiness.Set(rom, selectedLabels);
                }

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    FillLabelCell((Rom)row.Tag, row);
                }

                dataGridView.Refresh();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void removeRomEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 0) return;

                List<Rom> roms = new List<Rom>();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    if (!row.Visible) continue;

                    roms.Add((Rom)row.Tag);
                }

                var message = string.Empty;

                if (roms.Count == 1)
                {
                    message = string.Format("Do you want to remove \"{0}\" ? (Keep the rom file)", roms[0].Name);
                }
                else
                {
                    message = string.Format("Do you want to remove {0} roms ? (Keep the rom files)", roms.Count);
                }

                var result = MessageBox.Show(message, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result.ToString() == "No") return;

                foreach (var rom in roms)
                {
                    RomBusiness.Delete(rom);
                    RomFunctions.RemoveRomPics(rom);
                    FilteredRoms.Remove(rom);
                }

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    dataGridView.Rows.Remove(row);
                }

                labelTotalRomsCount.Text = FilteredRoms.Count.ToString();
                XML.SaveXmlRoms();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void deleteRomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 0) return;

                DataGridViewRow row = dataGridView.SelectedRows[0];
                Rom rom = (Rom)row.Tag;

                var message = string.Format("Do you want to remove \"{0}\" ? (Remove to recycle bin)", rom.Name);

                var result = MessageBox.Show(message, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result.ToString() == "No") return;

                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(rom.Path,
                    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);

                dataGridView.Rows.Remove(row);
                RomBusiness.Delete(rom);
                RomFunctions.RemoveRomPics(rom);
                FilteredRoms.Remove(rom);
                labelTotalRomsCount.Text = FilteredRoms.Count.ToString();
                XML.SaveXmlRoms();
            }
            catch (OperationCanceledException ioex)
            {
                return;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

    }
}
