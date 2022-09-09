using KronosDMS.Api;
using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS.Http.Server;
using KronosDMS.Objects;
using KronosDMS.Utils;
using KronosDMS_Client.Forms;
using KronosDMS_Client.Render;
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
        public static readonly bool AutoUpdate = false;

        public static MainWindow MainWindow { get; private set; }
        public static MainFormWindow MainFormWindow { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            Logger.Init();

            Logger.Log("Starting KronosDMS Client application", LogLevel.INFO, $"Version: {Application.ProductVersion}");

            WindowManager.Init();

            Config = Config.LoadConfig();

            ActiveTheme = ThemeManager.LoadTheme(Config.Theme);
            ActiveTheme.Save();

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
            if (AutoUpdate)
                CheckForUpdates();
            else
                Logger.Log("Skipping update check", LogLevel.WARN, "Client.AutoUpdate is set to false.\n" +
                    "Updates wont be downloaded and installed automatically.\n" +
                    "This may be due to this version being a test build.");

            // Check if our themes exist
            CheckThemesInstall();

            // Run main app window

            // Check DirectX version to see if it is 11 or greater
            Vortice.Direct3D.FeatureLevel directXVer = Vortice.Direct3D11.D3D11.GetSupportedFeatureLevel();
            if (directXVer >= Vortice.Direct3D.FeatureLevel.Level_11_0 && Config.ClientType == ClientType.Current)
            {
                MainWindow = new MainWindow("Test Window");
                MainWindow.Show();
            }
            else
            {
                Logger.Log("DirectX version is incompatible, running legacy client", LogLevel.WARN,
                    $"The new client only supports DirectX version 11 or greater.\n" +
                    $"{Vortice.Direct3D11.D3D11.GetSupportedFeatureLevel()} < {Vortice.Direct3D.FeatureLevel.Level_11_0}");
                Logger.Log("Launching main client window");
                Application.Run(MainFormWindow = new MainFormWindow());
            }

            Response logout = new AccountLogout(Credentials.Username, Credentials.PasswordHash).PerformRequestAsync().Result;
            Logger.Log("Closed KronosDMS Client application", LogLevel.OK);
        }

        public static void Login(string[] args)
        {
            if (args.Count() == 2)
            {
                Requester.BaseAPIAddr = $"http://{Config.IPAddress}";

                PingResponse ping = new Ping().PerformRequestAsync().Result;
                if (!ping.Success)
                {
                    Logger.Log("Failed to connect to the server", LogLevel.ERROR, $"IP Address: {Config.IPAddress}");
                    MessageBox.Show("Failed to connect to the server");
                    return;
                }

                // Get server info if we can connect to the server to try and login
                ServerGetInfo serverGetInfo = new ServerGetInfo();
                Common.ServerInfo = serverGetInfo.PerformRequestAsync().Result.ServerInfo;

                if (!Common.ServerInfo.UseEncryption)
                    Logger.Log("This server does not use encrypted messages!", LogLevel.WARN, 
                        "This means that all messages to and from the server\n" +
                        "can be visible to anyone peeking around on the\n" +
                        "network");

                Logger.Log("Logging in with account details from startup arguments", LogLevel.INFO, $"Username: {args[0]}\nPassword Hash: {args[1].Substring(0, 4)}****");
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
                MessageBox.Show("Failed to download updater.\nManually install the updater to maintain the latest version", "Failed Download");
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
            Logger.Log($"Logged out of the server", LogLevel.OK, $"Username: {Credentials.Username}\nPassword Hash: {Credentials.PasswordHash.Substring(0, 4)}****");
            Application.Exit();
        }
    }
}
