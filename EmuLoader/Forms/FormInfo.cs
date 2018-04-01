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

            textBox1.AppendText("Id" + Environment.NewLine);
            textBox1.AppendText(rom.Id + Environment.NewLine + Environment.NewLine);

            textBox1.AppendText("Name" + Environment.NewLine);
            textBox1.AppendText(rom.Name + Environment.NewLine + Environment.NewLine);

            textBox1.AppendText("Developer" + Environment.NewLine);
            textBox1.AppendText(rom.Developer + Environment.NewLine + Environment.NewLine);

            textBox1.AppendText("Publisher" + Environment.NewLine);
            textBox1.AppendText(rom.Publisher + Environment.NewLine + Environment.NewLine);

            textBox1.AppendText("Description" + Environment.NewLine);
            textBox1.AppendText(rom.Description + Environment.NewLine + Environment.NewLine);

            textBox1.AppendText("Year Released" + Environment.NewLine);
            textBox1.AppendText(rom.YearReleased + Environment.NewLine + Environment.NewLine);

            textBox1.AppendText("Genre" + Environment.NewLine);
            textBox1.AppendText(rom.Genre != null ? rom.Genre.Name : "" + Environment.NewLine + Environment.NewLine);
        }
    }
}
