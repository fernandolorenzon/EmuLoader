﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EmuLoader.Classes;
using EmuLoader.Business;

namespace EmuLoader.Forms
{
    public partial class FormLabel : FormRegister
    {
        #region Members

        private bool updating = false;

        #endregion

        #region Contructors

        public FormLabel()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void FormLabel_Load(object sender, EventArgs e)
        {
            buttonAdd.Click += buttonAdd_Click;
            buttonDelete.Click += buttonDelete_Click;
            buttonCancel.Click += buttonCancel_Click;

            updating = true;
            dataGridView.ClearSelection();
            dataGridView.Rows.Clear();

            List<RomLabel> labels = RomLabel.GetAll();

            foreach (RomLabel label in labels)
            {
                AddToGrid(label, -1);
            }

            updating = false;
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

            int index = -1;
            RomLabel label = null;

            if (string.IsNullOrEmpty(textBoxName.Text.Trim()))
            {
                MessageBox.Show("Can not save without a valid name.");
                return;
            }

            if (textBoxName.Enabled)
            {
                if (RomLabel.Get(textBoxName.Text.Trim()) != null)
                {
                    MessageBox.Show("This label already exists.");
                    return;
                }

                label = new RomLabel();
            }
            else
            {
                DataGridViewRow row = dataGridView.SelectedRows[0];
                index = row.Index;
                label = (RomLabel)row.Tag;
                textBoxName.Enabled = true;
                buttonAdd.Text = "Add";
            }

            label.Name = textBoxName.Text.Trim();
            label.Color = buttonColor.BackColor;
            RomLabel.Set(label);
            AddToGrid(label, index);
            updating = false;
            Updated = true;
            Clean();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count < 1) return;

            RomLabel label = (RomLabel)dataGridView.SelectedRows[0].Tag;

            if (MessageBox.Show(string.Format("Do you want do delete the label {0} ?", label.Name), "Warning", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

            int romCount = Rom.GetAll().Where(x => x.Labels.Contains(label)).Count();

            if (romCount > 0)
            {
                MessageBox.Show(string.Format("The label {0} is associated with {1} roms. You cannot delete it.", label.Name, romCount));
                return;
            }

            foreach (DataGridViewRow item in dataGridView.SelectedRows)
            {
                EmuLoader.Classes.RomLabel.Delete(item.Cells[0].Value.ToString());
                dataGridView.Rows.Remove(item);
            }

            Updated = true;
            Clean();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void FormLabel_FormClosed(object sender, FormClosedEventArgs e)
        {
            XML.SaveXml();
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

            SetForm();
        }

        private void SetForm()
        {
            DataGridViewRow row = dataGridView.SelectedRows[0];
            EmuLoader.Classes.RomLabel label = (EmuLoader.Classes.RomLabel)row.Tag;
            textBoxName.Text = label.Name;
            buttonColor.BackColor = label.Color;
            textBoxName.Enabled = false;
            buttonAdd.Text = "Update";
            buttonDelete.Enabled = true;
        }

        #endregion

        #region Methods

        private void AddToGrid(RomLabel label, int index)
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

            row.Cells["columnName"].Value = label.Name;
            row.Cells["columnColor"].Value = label.Color.Name;
            row.Cells["columnColor"].Style.BackColor = label.Color;
            row.Cells["columnColor"].Style.ForeColor = Functions.SetFontContrast(label.Color);
            row.Tag = label;
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
