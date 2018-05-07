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

        public static void ShowWait()
        {
            if (instance == null)
            {
                instance = new FormWait();
            }

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
