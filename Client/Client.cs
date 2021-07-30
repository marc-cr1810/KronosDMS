using KronosDMS.Api;
using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KronosDMS_Client
{
    public static class Client
    {
        public static Config Config;

        public static UserAccount ActiveAccount;
        public static Theme ActiveTheme;

        public static bool Disconnected = true;
        public static MainWindow MainWindow { get; private set; }

        /// <summary> 
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            Config = Config.LoadConfig();

            ActiveTheme = ThemeManager.LoadTheme(Config.Theme);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Count() == 2)
            {
                Requester.BaseAPIAddr = $"http://{Config.IPAddress}";

                PingResponse ping = new Ping().PerformRequestAsync().Result;
                if (!ping.Success)
                {
                    MessageBox.Show("Failed to connect to the server");
                    return;
                }

                AccountLoginResponse response = new AccountLogin(args[0], args[1], true).PerformRequestAsync().Result;

                try
                {
                    if (response.IsSuccess)
                    {
                        ActiveAccount = response.Account;
                        Requester.AccessToken = response.Account.AccessToken;
                    }
                    else
                    {
                        MessageBox.Show("Failed to login to the server");
                        return;
                    }
                }
                catch { }
            }
            else
            {
                // Run login prompt
                Application.Run(new LoginWindow());
                Disconnected = false;
            }

            // Check for updates
            GetUpdateInfoResponse updateInfo = new GetUpdateInfo().PerformRequestAsync().Result;
            if (updateInfo.Version != Application.ProductVersion)
            {
                Response download = new DownloadUpdate().PerformRequestAsync().Result;
                if (download.IsSuccess)
                {
                    Process p = Process.Start("updater/ClientUpdater.exe", $"{Process.GetCurrentProcess().Id} {ActiveAccount.Username} {ActiveAccount.PasswordHash}");
                    Process.GetCurrentProcess().Kill();
                }
                else
                    MessageBox.Show("Failed to download update", "Failed Download");
            }

            // If the user is not logged in, exit
            if (ActiveAccount.Username == null)
                return;

            // Run main app window
            Application.Run(MainWindow = new MainWindow());
        }

        public static void Exit()
        {
            Response logout = new AccountLogout(ActiveAccount.Username, ActiveAccount.PasswordHash).PerformRequestAsync().Result;
            Application.Exit();
        }
    }
}
