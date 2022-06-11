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
            Logger.Init();

            Config = Config.LoadConfig();

            ActiveTheme = ThemeManager.LoadTheme(Config.Theme);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Login(args);

            // If the user is not logged in, exit
            if (ActiveAccount.Username == null)
            {
                Logger.Log("Closing application");
                return;
            }

            // Check for updates
            CheckForUpdates();

            // Check if our themes exist
            CheckThemesInstall();

            // Run main app window
            Logger.Log("Launching main client window");
            MainWindow = new MainWindow();
            MainWindow.Show();

            Response logout = new AccountLogout(Credentials.Username, Credentials.PasswordHash).PerformRequestAsync().Result;
        }

        public static void Login(string[] args)
        {
            if (args.Count() == 2)
            {
                Logger.Log("Logging in with account details from startup arguments", LogLevel.INFO, $"Username: {args[0]}\nPassword Hash: {args[1].Substring(0, 4)}****");

                Requester.BaseAPIAddr = $"http://{Config.IPAddress}";

                PingResponse ping = new Ping().PerformRequestAsync().Result;
                if (!ping.Success)
                {
                    Logger.Log("Failed to connect to the server", LogLevel.ERROR, $"IP Address: {Config.IPAddress}");
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
                        Logger.Log($"Logged into the server", LogLevel.OK, $"Username: {args[0]}\nPassword Hash: {args[1].Substring(0, 4)}****");
                    }
                    else
                    {
                        MessageBox.Show($"Failed to login to the server\n{response.RawMessage}");
                        Logger.Log($"Failed to login to the server", LogLevel.ERROR, response.RawMessage);
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
            Logger.Log("Checking for updates");
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
                    Logger.Log($"New updater version avaliable ({FileVersionInfo.GetVersionInfo(updaterExe.FullName).ProductVersion} > {response.UpdateInfo.Updater.Version})");
                    InstallUpdater();
                }
            }

            // Check client install
            if (response.UpdateInfo.Client.Version != Application.ProductVersion)
            {
                Logger.Log($"New client version avaliable ({response.UpdateInfo.Client.Version} > {Application.ProductVersion})");

                Response download = new DownloadUpdate().PerformRequestAsync().Result;
                if (download.IsSuccess)
                {
                    Logger.Log("Updated the client successfully", LogLevel.OK);
                    Process p = Process.Start("updater/ClientUpdater.exe", $"{Process.GetCurrentProcess().Id} {Credentials.Username} {Credentials.PasswordHash}");
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    Logger.Log("Failed to download update", LogLevel.ERROR);
                    MessageBox.Show("Failed to download update", "Failed Download");
                }
            }
        }

        private static void InstallUpdater()
        {
            Logger.Log("Installing the updater");

            // Delete the previous version by deleting its directory and recreating it 
            if (Directory.Exists("updater"))
                Directory.Delete("updater", true);
            Directory.CreateDirectory("updater");

            Response download = new DownloadUpdater().PerformRequestAsync().Result;
            if (download.IsSuccess)
            {
                // Extract downloaded zip file
                Logger.Log("Downloaded the updater", LogLevel.OK);
                ZipFile.ExtractToDirectory($"updater.zip", "updater");
                File.Delete("updater.zip");
                return;
            }
            else
            {
                Logger.Log("Failed to download updater", LogLevel.ERROR, "Manually install the updater to maintain the latest version");
                MessageBox.Show("Failed to download updater.\nManually install the updater to maintain the latest version.", "Failed Download");
            }
        }

        public static void CheckThemesInstall()
        {
            Logger.Log("Checking installed themes");

            // Check if our themes already exist
            if (Directory.Exists("themes") && Directory.GetFiles("themes").Length > 0)
                return;

            Logger.Log("No themes are installed, downloading");
            Response download = new DownloadThemes().PerformRequestAsync().Result;
            if (download.IsSuccess)
            {
                // Extract downloaded zip file
                Logger.Log("Installed themes successfully", LogLevel.OK);
                ZipFile.ExtractToDirectory($"themes/themes.zip", "themes");
                File.Delete("themes/themes.zip");

                // Reload the theme
                ActiveTheme = ThemeManager.LoadTheme(Config.Theme);
                return;
            }
            else
            {
                Logger.Log("Failed to download themes", LogLevel.ERROR, "The UI may have issues");
                MessageBox.Show("Failed to download themes.\nThe UI may have issues.", "Failed Download");
            }
        }

        public static void Exit()
        {
            Response logout = new AccountLogout(Credentials.Username, Credentials.PasswordHash).PerformRequestAsync().Result;
            Application.Exit();
        }
    }
}
