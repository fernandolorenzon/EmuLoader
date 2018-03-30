using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EmuLoader.Classes;

namespace EmuLoader.Forms
{
    public partial class FormRename : FormBase
    {
        private static FormRename instance;
        private static string newName;
        
        private FormRename()
        {
            InitializeComponent();
        }

        private void FormRename_Load(object sender, EventArgs e)
        {
            FormRename.newName = "";
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
           
           if (textBox1.Text.Trim() != "")
               FormRename.newName = textBox1.Text;

            instance.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            instance.Close();
        }

        public static string Rename(string oldName)
        {
            instance = new FormRename();
            instance.textBox1.Text = oldName;
            FormRename.newName = oldName;
            instance.textBox1.Focus();
            instance.ShowDialog();
            return newName;
        }
    }
}
