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

        private void changeSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string selected = "";

                List<Rom> romList = new List<Rom>();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    romList.Add((Rom)row.Tag);
                }

                if (romList.Count == 1)
                {
                    selected = romList[0].Series;
                }
                else if (romList.Count > 1)
                {
                    selected = romList[0].Series;

                    foreach (var rom in romList)
                    {
                        if (rom.Series != selected)
                        {
                            selected = "";
                            break;
                        }
                    }
                }

                if (!FormSeries.ChooseSeries(selected, out selected)) return;

                foreach (var rom in romList)
                {
                    rom.Series = selected;
                }

                RomBusiness.SetRom(romList);

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    Rom rom = (Rom)row.Tag;
                    row.Cells[columnSeries.Index].Value = rom.Series;
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

                List<Rom> romList = new List<Rom>();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    var rom = (Rom)row.Tag;
                    romList.Add(rom);
                }
                
                RomStatusBusiness.SetRomStatus(romList, newstatus);

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
                RomLabels labels = ((Rom)dataGridView.SelectedRows[0].Tag).RomLabels;

                List<Rom> roms = new List<Rom>();

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    roms.Add((Rom)row.Tag);
                }

                if (!FormChooseList.ChooseLabel(roms, out selectedLabels)) return;

                RomLabelsBusiness.SetRomLabel(roms, selectedLabels);

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
                    RomFunctions.RemoveRomPics(rom);
                    FilteredRoms.Remove(rom);
                }

                RomBusiness.DeleteRom(roms);

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    dataGridView.Rows.Remove(row);
                }

                labelTotalRomsCount.Text = FilteredRoms.Count.ToString();
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

                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(rom.Platform.DefaultRomPath + "\\" + rom.FileName,
                    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);

                dataGridView.Rows.Remove(row);
                RomBusiness.DeleteRom(rom);
                RomFunctions.RemoveRomPics(rom);
                FilteredRoms.Remove(rom);
                labelTotalRomsCount.Text = FilteredRoms.Count.ToString();
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
