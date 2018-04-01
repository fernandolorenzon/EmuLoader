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
        public FormInfo(Rom rom)
        {
            InitializeComponent();

            textBox1.AppendText("ID" + Environment.NewLine);
            textBox1.AppendText(rom.Id + Environment.NewLine + Environment.NewLine);

            textBox1.AppendText("NAME" + Environment.NewLine);
            textBox1.AppendText(rom.Name + Environment.NewLine + Environment.NewLine);

            textBox1.AppendText("PUBLISHER" + Environment.NewLine);
            textBox1.AppendText(rom.Publisher + Environment.NewLine + Environment.NewLine);

            textBox1.AppendText("DEVELOPER" + Environment.NewLine);
            textBox1.AppendText(rom.Developer + Environment.NewLine + Environment.NewLine);

            textBox1.AppendText("DESCRIPTION" + Environment.NewLine);
            textBox1.AppendText(rom.Description + Environment.NewLine + Environment.NewLine);

            textBox1.AppendText("YEAR RELEASED" + Environment.NewLine);
            textBox1.AppendText(rom.YearReleased + Environment.NewLine + Environment.NewLine);

            textBox1.AppendText("GENRE" + Environment.NewLine);
            textBox1.AppendText(rom.Genre != null ? rom.Genre.Name : "" + Environment.NewLine + Environment.NewLine);
        }
    }
}
