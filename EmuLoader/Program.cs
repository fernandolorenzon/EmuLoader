using EmuLoader.Forms;
using System;
using System.Threading;
using System.Windows.Forms;

namespace EmuLoader
{
    static class Program
    {
        private static string appGuid = "28f3f92f-34a5-445e-a88c-13a9e13e03fd";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    FormCustomMessage.ShowError("Instance already running");
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
            }
        }
    }
}
