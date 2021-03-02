using EmuLoader.Core.Classes;
using System;
using System.Linq;
using System.Collections.Generic;
using EmuLoader.Core.Models;
using EmuLoader.Core.Business;

namespace EmuLoader.Forms
{
    public partial class FormSeries : FormRegisterBase
    {
        private static FormSeries instance;
        public string Series { get; set; }

        private FormSeries()
        {
            InitializeComponent();
        }

        private FormSeries(string series)
            : this()
        {
            Series = series;
            textBoxSeries.Text = series;
            buttonClose.Text = "Cancel and close";
            buttonAdd.Text = "Save and close";
        }

        private void FormSeries_Load(object sender, EventArgs e)
        {
            buttonAdd.Click += buttonOk_Click;
            buttonCancel.Click += buttonCancel_Click;
            buttonDelete.Visible = false;
            buttonCancel.Visible = false;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Updated = true;
            Series = textBoxSeries.Text;
            instance.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Updated = false;
            instance.Close();
        }

        public static bool ChooseSeries(string currentSeries, out string newSeries)
        {
            newSeries = "";
            instance = new FormSeries(currentSeries);
            var result = instance.ShowDialogUpdated();
            newSeries = instance.Series;
            return result;
        }
    }
}
