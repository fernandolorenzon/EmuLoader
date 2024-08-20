using System;
using System.Drawing;
using System.Threading;

namespace EmuLoader.Gui.Forms
{
    public partial class FormMessage : FormBase
    {
        private static FormMessage instance;
        private static Thread t;
        private static string messageGlobal;

        public FormMessage()
        {
            InitializeComponent();
        }

        private void FormMessage_Load(object sender, EventArgs e)
        {

        }

        public static void ShowMessage(string message)
        {
            messageGlobal = message;

            if (t != null)
            {
                t.Abort();
            }

            if (instance != null)
            {
                //instance.Close();
            }

            ThreadStart start = new ThreadStart(DoWork);
            t = new Thread(start);
            t.Start();
        }

        private static void DoWork()
        {
            instance = new FormMessage();
            instance.labelMessage.Text = messageGlobal;

            int pos = (int)((instance.Width - instance.labelMessage.Width) / 2);
            instance.labelMessage.Location = new Point(pos, instance.labelMessage.Height);
            instance.ShowDialog();
        }

        public static void CloseMessage()
        {
            instance.Close();
        }
    }
}
