﻿using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using EmuLoader.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EmuLoader.Gui.Forms
{
    public partial class FormGenre : FormRegisterBase
    {
        #region Members

        private bool updating = false;

        #endregion

        #region Contructors

        public FormGenre()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void FormGenre_Load(object sender, EventArgs e)
        {
            buttonAdd.Click += buttonAdd_Click;
            buttonDelete.Click += buttonDelete_Click;
            buttonCancel.Click += buttonCancel_Click;

            updating = true;
            dataGridView.ClearSelection();
            dataGridView.Rows.Clear();

            List<Genre> genres = GenreBusiness.GetAll();

            foreach (Genre genre in genres)
            {
                AddToGrid(genre, -1);
            }

            updating = false;
            Clean();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                buttonAdd.Enabled = false;
            }
            else
            {
                buttonAdd.Enabled = true;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            updating = true;
            Genre genre = null;
            int index = -1;

            if (string.IsNullOrEmpty(textBoxName.Text.Trim()))
            {
                FormCustomMessage.ShowError("Can not save without a valid name.");
                return;
            }

            if (textBoxName.Enabled)
            {
                if (GenreBusiness.Get(textBoxName.Text.Trim()) != null)
                {
                    FormCustomMessage.ShowError("This genre already exists.");
                    return;
                }

                genre = new Genre();

            }
            else
            {
                DataGridViewRow row = dataGridView.SelectedRows[0];
                index = row.Index;
                genre = (Genre)row.Tag;
                textBoxName.Enabled = true;
                buttonAdd.Text = "Add";
            }

            genre.Name = textBoxName.Text.Trim();
            genre.Color = buttonColor.BackColor;
            AddToGrid(genre, index);
            GenreBusiness.Set(genre);
            updating = false;
            Updated = true;
            Clean();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            if (dataGridView.SelectedRows.Count < 1) return;

            Genre genre = (Genre)dataGridView.SelectedRows[0].Tag;

            if (MessageBox.Show(string.Format("Do you want do delete the genre {0} ?", genre.Name), "Warning", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

            int romCount = RomBusiness.GetAll().Where(x => x.Genre == genre).Count();

            if (romCount > 0)
            {
                FormCustomMessage.ShowError(string.Format("The genre {0} is associated with {1} roms. You cannot delete it.", genre.Name, romCount));
                return;
            }

            foreach (DataGridViewRow item in dataGridView.SelectedRows)
            {
                GenreBusiness.Delete(item.Cells[0].Value.ToString());
                dataGridView.Rows.Remove(item);
            }

            Updated = true;
            Clean();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            try
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    buttonColor.BackColor = colorDialog1.Color;
                }
            }
            catch (Exception ex)
            {
                FormCustomMessage.ShowError(ex.Message);
            }
        }

        private void dataGridView_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count < 1) return;

            SetForm();
        }

        private void FormGenre_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (updating) return;

            if (dataGridView.SelectedRows.Count == 0)
            {
                buttonDelete.Enabled = false;
            }
            else
            {
                SetForm();
            }
        }

        #endregion

        #region Methods

        private void AddToGrid(Genre genre, int index)
        {
            DataGridViewRow row = null;

            if (index < 0)
            {
                int rowId = dataGridView.Rows.Add();
                row = dataGridView.Rows[rowId];
            }
            else
            {
                row = dataGridView.Rows[index];
            }

            row.Cells["columnName"].Value = genre.Name;
            row.Cells["columnColor"].Value = genre.Color.Name;
            row.Cells["columnColor"].Style.BackColor = genre.Color;
            row.Cells["columnColor"].Style.ForeColor = Functions.SetFontContrast(genre.Color);
            row.Tag = genre;
        }

        protected override void Clean()
        {
            base.Clean();
            textBoxName.Text = "";
            buttonColor.BackColor = Color.White;
            dataGridView.ClearSelection();
            textBoxName.Enabled = true;
        }

        protected override void SetForm()
        {
            base.SetForm();
            DataGridViewRow row = dataGridView.SelectedRows[0];
            Genre genre = (Genre)row.Tag;
            textBoxName.Text = genre.Name;
            buttonColor.BackColor = genre.Color;
            textBoxName.Enabled = false;
            buttonAdd.Text = "Update";
        }

        #endregion
    }
}
