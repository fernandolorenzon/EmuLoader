namespace EmuLoader.Gui.Forms
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
