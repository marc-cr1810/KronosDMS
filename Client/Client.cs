using KronosDMS.Objects;
using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using System;
using System.Windows.Forms;

namespace KronosDMS_Client
{
    public static class Client
    {
        public static UserAccount ActiveAccount;
        public static Theme ActiveTheme;

        public static MainWindow MainWindow { get; private set; }

        /// <summary> 
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ActiveTheme = ThemeManager.LoadTheme("Dark");

            PingResponse ping = new Ping().PerformRequestAsync().Result;
            if (!ping.Success)
            {
                MessageBox.Show("Failed to connect to the server");
                return;
            }

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginWindow());

            if (ActiveAccount.Username == null)
                return;

            Application.Run(MainWindow = new MainWindow());
        }
    }
}
