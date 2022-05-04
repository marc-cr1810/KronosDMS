using KronosDMS.Api;
using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;

namespace KronosDMS_Client
{
    public struct UserCredentials
    {
        public string Username;
        public string PasswordHash;
    }

    public static class Client
    {
        public static Config Config;

        public static UserCredentials Credentials;
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

            Login(args);

            // If the user is not logged in, exit
            if (ActiveAccount.Username == null)
                return;

            // Check for updates
            CheckForUpdates();

            // Check if our themes exist
            CheckThemesInstall();

            // Run main app window
            Application.Run(MainWindow = new MainWindow());

            Response logout = new AccountLogout(Credentials.Username, Credentials.PasswordHash).PerformRequestAsync().Result;
        }

        public static void Login(string[] args)
        {
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
                        Client.Credentials = new UserCredentials() { Username = args[0], PasswordHash = args[1] };
                        Requester.AccessToken = response.Account.AccessToken;
                    }
                    else
                    {
                        MessageBox.Show($"Failed to login to the server\n{response.RawMessage}");
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
        }

        public static void CheckForUpdates()
        {
            GetUpdateInfoResponse response = new GetUpdateInfo().PerformRequestAsync().Result;

            // Check updater install
            if (!File.Exists("updater/ClientUpdater.exe"))
            {
                InstallUpdater();
            }
            else
            {
                FileInfo updaterExe = new FileInfo("updater/ClientUpdater.exe");
                if (response.UpdateInfo.Updater.Version != FileVersionInfo.GetVersionInfo(updaterExe.FullName).ProductVersion)
                {
                    InstallUpdater();
                }
            }

            // Check client install
            if (response.UpdateInfo.Client.Version != Application.ProductVersion)
            {
                Response download = new DownloadUpdate().PerformRequestAsync().Result;
                if (download.IsSuccess)
                {
                    Process p = Process.Start("updater/ClientUpdater.exe", $"{Process.GetCurrentProcess().Id} {Credentials.Username} {Credentials.PasswordHash}");
                    Process.GetCurrentProcess().Kill();
                }
                else
                    MessageBox.Show("Failed to download update", "Failed Download");
            }
        }

        private static void InstallUpdater()
        {
            // Delete the previous version by deleting its directory and recreating it 
            if (Directory.Exists("updater"))
                Directory.Delete("updater", true);
            Directory.CreateDirectory("updater");

            Response download = new DownloadUpdater().PerformRequestAsync().Result;
            if (download.IsSuccess)
            {
                // Extract downloaded zip file
                ZipFile.ExtractToDirectory($"updater.zip", "updater");
                File.Delete("updater.zip");
                return;
            }
            else
                MessageBox.Show("Failed to download updater.\nManually install the updater to maintain the latest version", "Failed Download");
        }

        public static void CheckThemesInstall()
        {
            // Check if our themes already exist
            if (Directory.Exists("themes") && Directory.GetFiles("themes").Length > 0)
                return;

            Response download = new DownloadThemes().PerformRequestAsync().Result;
            if (download.IsSuccess)
            {
                // Extract downloaded zip file
                ZipFile.ExtractToDirectory($"themes/themes.zip", "themes");
                File.Delete("themes/themes.zip");

                // Reload the theme
                ActiveTheme = ThemeManager.LoadTheme(Config.Theme);
                return;
            }
            else
                MessageBox.Show("Failed to download themes.\nThe UI may have issues.", "Failed Download");
        }

        public static void Exit()
        {
            Response logout = new AccountLogout(Credentials.Username, Credentials.PasswordHash).PerformRequestAsync().Result;
            Application.Exit();
        }
    }
}
