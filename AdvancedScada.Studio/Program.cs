using System;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.UserSkins;

namespace AdvancedScada.Studio
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        public const string APP_UNIQUE_ID = "0F054E71-9E49-42f0-9782-A0DF741D3F8F";
        [STAThread]
        private static void Main()
        {
            using (var __mutex = new Mutex(false, @"Global\" + APP_UNIQUE_ID)) // unique for all sessions
                //using(Mutex __mutex = new Mutex(false, APP_UNIQUE_ID)) // unique just for the current session
            {
                if (!__mutex.WaitOne(0, false))
                {
                    MessageBox.Show("The application is running.");
                    return;
                }
                GC.Collect();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                BonusSkins.Register();
                SkinManager.EnableFormSkins();
                Application.Run(new TagManagerLibrary.Studio.FormStudio());
            }
        }
    }
}