﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EmuLoader.Core.Classes;
using EmuLoader.Core.Business;

namespace EmuLoader.Forms
{
    public partial class FormChooseList : FormRegister
    {
        private static FormChooseList instance;
        private static bool changed = false;
        private List<RomLabel> selectedLabels = null;

        private FormChooseList()
        {
            InitializeComponent();
        }

        private FormChooseList(Type type)
            : this()
        {
            if (type == typeof(RomLabel))
            {
                List<RomLabel> labels = RomLabel.GetAll();

                foreach (RomLabel label in labels)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridView);
                    row.Cells[columnName.Index].Value = label.Name;
                    row.Cells[columnColor.Index].Value = label.Color.ToArgb();
                    row.Cells[columnColor.Index].Style.BackColor = label.Color;
                    row.Cells[columnColor.Index].Style.ForeColor = Functions.SetFontContrast(label.Color);

                    this.Text = "Choose Label";
                    buttonCancel.Visible = false;
                    buttonClose.Text = "Cancel and close";
                    buttonAdd.Text = "Save and close";

                    row.Tag = label;
                    dataGridView.Rows.Add(row);
                }
            }
        }

        private void FormChoose_Load(object sender, EventArgs e)
        {
            buttonAdd.Click += buttonOk_Click;
            buttonDelete.Visible = false;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            changed = true;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (changed)
            {
                selectedLabels = new List<RomLabel>();

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    RomLabel label = (RomLabel)row.Tag;
                    label.Checked = (CheckState)row.Cells[columnCheck.Index].Value == CheckState.Checked;

                    if (label.Checked)
                    {
                        selectedLabels.Add((RomLabel)row.Tag);
                    }
                }
            }

            Updated = true;
            instance.Close();
        }

        public static bool ChooseLabel(out List<RomLabel> labels)
        {
            labels = new List<RomLabel>();
            instance = new FormChooseList(typeof(RomLabel));

            foreach (DataGridViewRow row in instance.dataGridView.Rows)
            {
                row.Cells[instance.columnCheck.Index].Value = CheckState.Unchecked;
                bool found = false;
                bool notfound = false;

                if (found && !notfound)
                {
                    row.Cells[instance.columnCheck.Index].Value = CheckState.Checked;
                }
                else if (!found && notfound)
                {
                    row.Cells[instance.columnCheck.Index].Value = CheckState.Unchecked;
                }
                else if (found && notfound)
                {
                    row.Cells[instance.columnCheck.Index].Value = CheckState.Indeterminate;
                }

                found = false;
                notfound = false;
            }

            var result = instance.ShowDialogUpdated();
            labels = instance.selectedLabels;
            return result;
        }

        public static bool ChooseLabel(List<RomLabel> selectedLabels, out List<RomLabel> labels)
        {
            labels = new List<RomLabel>();
            instance = new FormChooseList(typeof(RomLabel));

            foreach (DataGridViewRow row in instance.dataGridView.Rows)
            {
                bool found = selectedLabels == null ? false : selectedLabels.Exists(x => x.Name == row.Cells[instance.columnName.Index].Value);

                if (found)
                {
                    row.Cells[instance.columnCheck.Index].Value = CheckState.Checked;
                }
                else
                {
                    row.Cells[instance.columnCheck.Index].Value = CheckState.Unchecked;
                }
            }

            var result = instance.ShowDialogUpdated();
            labels = instance.selectedLabels;
            return result;
        }
    }
}
