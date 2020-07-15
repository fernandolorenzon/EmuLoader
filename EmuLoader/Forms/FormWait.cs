using System;
using System.Windows.Forms;

namespace EmuLoader.Forms
{
    public partial class FormWait : FormBase
    {
        private static FormWait instance = null;

        private FormWait()
        {
            InitializeComponent();
        }

        public static void ShowWait(Form parent)
        {
            if (instance == null)
            {
                instance = new FormWait();
            }

            var centerX = parent.Width + (parent.Location.X / 2);
            var centerY = parent.Height + (parent.Location.Y / 2);

            instance.Location = new System.Drawing.Point(centerX - Convert.ToInt32((instance.Width / 2)), centerY - Convert.ToInt32((instance.Height / 2)));
            instance.Show();
        }

        public static void CloseWait()
        {
            if (instance != null)
            {
                instance.Close();
            }

            instance = null;
        }
    }
}
