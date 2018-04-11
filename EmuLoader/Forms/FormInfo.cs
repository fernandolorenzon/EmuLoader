using EmuLoader.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmuLoader.Forms
{
    public partial class FormInfo : FormBase
    {
        public FormInfo(string text)
        {
            InitializeComponent();

            textBox1.AppendText(text);
        }
    }
}
