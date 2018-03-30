using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EmuLoader.Classes;
using System.Linq;

namespace EmuLoader.Forms
{
    public partial class FormGenre : FormRegister
    {
        #region Members

        public bool Updated = false;

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

            List<Genre> genres = Genre.GetAll();

            foreach (Genre genre in genres)
            {
                AddToGrid(genre, -1);
            }
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
            Genre genre = null;
            int index = -1;

            if (string.IsNullOrEmpty(textBoxName.Text.Trim()))
            {
                MessageBox.Show("Can not save without a valid name.");
                return;
            }

            if (textBoxName.Enabled)
            {
                if (Genre.Get(textBoxName.Text.Trim()) != null)
                {
                    MessageBox.Show("Este genre já existe.");
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
                Updated = true;
            }

            genre.Name = textBoxName.Text.Trim();
            genre.Color = buttonColor.BackColor;
            AddToGrid(genre, index);
            Genre.Set(genre);
            Clean();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            if (dataGridView.SelectedRows.Count < 1) return;

            Genre genre = (Genre)dataGridView.SelectedRows[0].Tag;

            if (MessageBox.Show(string.Format("Do you want do delete the genre {0} ?", genre.Name), "Warning", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

            int romCount = Rom.GetAll().Where(x => x.Genre == genre).Count();

            if (romCount > 0)
            {
                MessageBox.Show(string.Format("The genre {0} is associated with {1} roms. You cannot delete it.", genre.Name, romCount));
                return;
            }

            foreach (DataGridViewRow item in dataGridView.SelectedRows)
            {
                Genre.Delete(item.Cells[0].Value.ToString());
                dataGridView.Rows.Remove(item);
            }

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
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count < 1) return;

            DataGridViewRow row = dataGridView.SelectedRows[0];
            Genre genre = (Genre)row.Tag;
            textBoxName.Text = genre.Name;
            buttonColor.BackColor = genre.Color;
            textBoxName.Enabled = false;
            buttonAdd.Text = "Update";
        }

        private void FormGenre_FormClosed(object sender, FormClosedEventArgs e)
        {
            XML.SaveXml();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                buttonDelete.Enabled = false;
            }
            else
            {
                buttonDelete.Enabled = true;
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

        public bool ShowDialogBool()
        {
            ShowDialog();
            return Updated;
        }

        private void Clean()
        {
            textBoxName.Text = "";
            buttonColor.BackColor = Color.White;
            dataGridView.ClearSelection();

            if (dataGridView.Rows.Count == 0)
            {
                textBoxName.Enabled = true;
                buttonAdd.Enabled = true;
                buttonDelete.Enabled = false;
                buttonAdd.Text = "Add";
            }
        }

        #endregion
    }
}
