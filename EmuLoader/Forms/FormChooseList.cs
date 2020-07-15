using EmuLoader.Core.Business;
using EmuLoader.Core.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EmuLoader.Forms
{
    public partial class FormChooseList : FormRegisterBase
    {
        private static FormChooseList instance;
        private static bool changed = false;
        private List<RomLabel> selectedLabels = null;
        private List<RomLabel> unselectedLabels = null;

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
                unselectedLabels = new List<RomLabel>();

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if ((CheckState)row.Cells[columnCheck.Index].Value == CheckState.Checked)
                    {
                        selectedLabels.Add((RomLabel)row.Tag);
                    }
                    else if ((CheckState)row.Cells[columnCheck.Index].Value == CheckState.Unchecked)
                    {
                        unselectedLabels.Add((RomLabel)row.Tag);
                    }
                }
            }

            Updated = true;
            instance.Close();
        }

        public static bool ChooseLabel(List<Rom> roms, out List<RomLabel> selectedLabels, out List<RomLabel> unselectedLabels)
        {
            selectedLabels = new List<RomLabel>();
            unselectedLabels = new List<RomLabel>();
            instance = new FormChooseList(typeof(RomLabel));

            foreach (DataGridViewRow row in instance.dataGridView.Rows)
            {
                row.Cells[instance.columnCheck.Index].Value = CheckState.Unchecked;
                bool found = false;
                bool all = false;
                bool checkFound = false;
                bool notFound = false;
                string labelName = row.Cells[instance.columnName.Index].Value.ToString();

                foreach (var rom in roms)
                {
                    checkFound = rom.Labels.Any(x => x.Name == labelName);

                    if (checkFound)
                    {
                        found = true;
                    }
                    else
                    {
                        notFound = true;
                    }
                }

                all = found && !notFound;


                if (found && all)
                {
                    row.Cells[instance.columnCheck.Index].Value = CheckState.Checked;
                }
                else if (!found)
                {
                    row.Cells[instance.columnCheck.Index].Value = CheckState.Unchecked;
                }
                else if (found && !all)
                {
                    row.Cells[instance.columnCheck.Index].Value = CheckState.Indeterminate;
                }

                found = false;
                all = false;
            }

            var result = instance.ShowDialogUpdated();
            selectedLabels = instance.selectedLabels;
            unselectedLabels = instance.unselectedLabels;
            return result;
        }
    }
}
