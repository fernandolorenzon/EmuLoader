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

        #region Grid Events

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count > 1)
                {
                    FormCustomMessage.ShowError("Cannot initialize multiple roms");
                    return;
                }

                Rom rom = (Rom)dataGridView.SelectedRows[0].Tag;
                RunAppFunctions.RunPlatform(rom);
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Space)
                {
                    dataGridView_DoubleClick(sender, e);
                }
                else if (e.KeyData == Keys.Delete)
                {
                    removeRomEntryToolStripMenuItem_Click(sender, e);
                }
                else if (e.KeyData == Keys.F5)
                {
                    FilteredRoms.Clear();
                    FilteredRoms.AddRange(RomBusiness.GetAll());
                    AddRomsToGrid(FilteredRoms);
                }
                else if (e.KeyData == Keys.G)
                {
                    changeGenreToolStripMenuItem_Click(sender, null);
                }
                else if (e.KeyData == Keys.L)
                {
                    changeLabelsToolStripMenuItem_Click(sender, null);
                }
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

        private void dataGridView_Click(object sender, EventArgs e)
        {
            try
            {
                EnableDisableButtonsBySelection();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (updating) return;

            labelSelectedRomsCount.Text = dataGridView.SelectedRows.Count.ToString();

            EnableDisableButtonsBySelection();
            LoadComboBoxEmulators();
            LoadPictures();
        }

        private void dataGridView_Leave(object sender, EventArgs e)
        {
            try
            {
                selectedRomsOptionsToolStripMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void dataGridView_Enter(object sender, EventArgs e)
        {
            try
            {
                selectedRomsOptionsToolStripMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void dataGridViewPlatforms_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewPlatforms.SelectedRows.Count > 1)
                {
                    FormCustomMessage.ShowError("Cannot initialize multiple emulators");
                    return;
                }

                Platform platform = null;

                if (dataGridViewPlatforms.SelectedRows.Count == 0)
                {
                    platform = (Platform)dataGridViewPlatforms.Rows[dataGridViewPlatforms.SelectedCells[0].RowIndex].Tag;
                }
                else
                {
                    platform = (Platform)dataGridViewPlatforms.SelectedRows[0].Tag;
                }

                RunAppFunctions.RunPlatform(platform);
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void dataGridView_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if ((dataGridView.Location.X + dataGridView.Size.Width) < e.X) return;

                if (e.Button == MouseButtons.Right)
                {
                    var hti = dataGridView.HitTest(e.X, e.Y);

                    if (hti.RowIndex == -1) return;

                    dataGridView.ClearSelection();
                    dataGridView.Rows[hti.RowIndex].Selected = true;
                }
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void dataGridViewPlatforms_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                var hti = dataGridViewPlatforms.HitTest(e.X, e.Y);

                if (hti.RowIndex == -1) return;

                dataGridViewPlatforms.ClearSelection();
                dataGridViewPlatforms.Rows[hti.RowIndex].Selected = true;
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void auditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAudit form = new FormAudit();
            form.ShowDialog();
        }

        private void checkBoxFavorite_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (updating) return;
                FilterRoms();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void checkBoxArcade_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (updating) return;
                FilterRoms();
                FillPlatformFilter();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void checkBoxConsole_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (updating) return;
                FilterRoms();
                FillPlatformFilter();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void checkBoxHandheld_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (updating) return;
                FilterRoms();
                FillPlatformFilter();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void checkBoxCD_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (updating) return;
                FilterRoms();
                FillPlatformFilter();
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        #endregion

    }
}
