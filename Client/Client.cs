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
        public static void Main()
        {
            ActiveTheme = ThemeManager.LoadTheme("Dark");

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginWindow());

            if (ActiveAccount.Username == null)
                return;

            Application.Run(MainWindow = new MainWindow());
        }

        public static void Exit()
        {
            Response logout = new AccountLogout(ActiveAccount.Username, ActiveAccount.PasswordHash).PerformRequestAsync().Result;
            Application.Exit();
        }
    }
}
