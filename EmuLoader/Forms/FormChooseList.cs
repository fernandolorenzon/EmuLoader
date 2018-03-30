using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using EmuLoader.Classes;

namespace EmuLoader.Forms
{
    public partial class FormChooseList : FormBase
    {
        private static FormChooseList instance;
        private static bool changed = false;
        private List<Rom> RomList;

        private FormChooseList()
        {
            InitializeComponent();
        }

        private FormChooseList(Type type, List<Rom> romList)
            : this()
        {
            RomList = romList;

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

                    this.Text += " Label";

                    row.Tag = label;
                    dataGridView.Rows.Add(row);
                }
            }
        }

        private void FormChoose_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            changed = true;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (changed)
            {
                List<RomLabel> selectedLabels = new List<RomLabel>();

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    RomLabel label = (RomLabel)row.Tag;
                    label.CheckState = (CheckState)row.Cells[columnCheck.Index].Value;

                    if (label.CheckState == CheckState.Checked)
                    {
                        selectedLabels.Add((RomLabel)row.Tag);
                    }
                }

                foreach (var item in RomList)
                {
                    item.Labels = selectedLabels;
                    Rom.Set(item);
                }

                XML.SaveXml();
            }

            instance.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            instance.Close();
        }

        public static void ChooseLabel(List<Rom> roms)
        {
            instance = new FormChooseList(typeof(RomLabel), roms);

            foreach (DataGridViewRow row in instance.dataGridView.Rows)
            {
                row.Cells[instance.columnCheck.Index].Value = CheckState.Unchecked;
                bool found = false;
                bool notfound = false;

                foreach (Rom rom in roms)
                {
                    int count = (from l in rom.Labels where l.Name == ((RomLabel)row.Tag).Name select l).Count();

                    if (count > 0)
                    {
                        found = true;
                    }
                    else
                    {
                        notfound = true;
                    }
                }

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

            instance.ShowDialog();
        }
    }
}
