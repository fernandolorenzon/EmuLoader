﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace EmuLoader.Gui.Forms
{
    public partial class FormCustomMessage : Form
    {
        private static FormCustomMessage instance;

        private FormCustomMessage()
        {
            InitializeComponent();
        }

        public static void ShowSuccess(string message)
        {
            instance = new FormCustomMessage();
            instance.labelTitle.Text = "Success";
            instance.labelTitle.ForeColor = Color.DarkGreen;
            instance.labelMessage.Text = message;
            instance.ShowDialog();
            instance.BringToFront();
        }

        public static void ShowInfo(string message)
        {
            instance = new FormCustomMessage();
            instance.labelTitle.Text = "Info";
            instance.labelTitle.ForeColor = Color.Blue;
            instance.labelMessage.Text = message;
            instance.ShowDialog();
            instance.BringToFront();
        }

        public static void ShowError(string message)
        {
            instance = new FormCustomMessage();
            instance.labelTitle.Text = "Error";
            instance.labelTitle.ForeColor = Color.Red;
            instance.labelMessage.Text = message;
            instance.ShowDialog();
            instance.BringToFront();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            instance.Close();
        }
    }
}
