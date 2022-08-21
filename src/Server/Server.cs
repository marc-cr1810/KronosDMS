using KronosDMS.Files;
using KronosDMS.Http.Server;
using KronosDMS.Http.Server.Models;
using KronosDMS.Objects;
using KronosDMS.Security;
using KronosDMS.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace KronosDMS_Server
{
    class Server
    {
        public static Config Config { get; set; }
        public static UpdateConfig UpdateConfig { get; set; }

        public static UserAccountManager AccountManager { get; set; }

        public static PartsFile Parts { get; set; }
        public static MakeFile Makes { get; set; }
        public static RecallFile Recalls { get; set; }
        public static KitFile Kits { get; set; }
        public static CSVFormatsFile CSVFormats { get; set; }
        public static ROCheckedFile ROChecked { get; set; }

        public static void Main(string[] args)
        {
            Logger.Init();

            Logger.Log("Initializing server... ");

            Load();

            Logger.Log($"   Use Encryption: {Config.ServerInfo.UseEncryption}");
            Logger.Log($"   Client version: {UpdateConfig.UpdateInfo.Client.Version}");
            Logger.Log($"  Updater version: {UpdateConfig.UpdateInfo.Updater.Version}");
            Logger.Log($"      Makes count: {Makes.Makes.Count}");
            Logger.Log($"      Parts count: {Parts.Parts.Count}");
            Logger.Log($"       Kits count");
            Logger.Log($"       ├─── General: {Kits.Kits.Count}");
            Logger.Log($"       └─── Recalls: {Recalls.Recalls.Count}");

            Logger.Log("Initialized server", LogLevel.OK);

            Logger.Log("Configuring URL routes... ");
            List<Route> route_config = Routes.GetRoutes();

            Logger.Log($"  Routes");
            for (int i = 0; i < route_config.Count; i++)
            {
                string prefix = i < route_config.Count - 1 ? "  ├─── " : "  └─── ";
                Logger.Log($"{prefix}{route_config[i].Name}\t{route_config[i].UrlRegex}");
            }

            Logger.Log("Configured routes successfully", LogLevel.OK);

            Logger.Log("Starting server... ");
            HttpServer httpServer = new HttpServer(Config.Port, route_config);

            Thread thread = new Thread(new ThreadStart(httpServer.Listen));
            thread.Start();
            Logger.Log("Server started", LogLevel.OK, $"Running server on port: {Config.Port}");
        }

        public static void Load()
        {
            Config = Config.LoadConfig();
            UpdateConfig = new UpdateConfig();
            UpdateConfig.Save();

            AccountManager = new UserAccountManager();

            Makes = new MakeFile();
            Parts = new PartsFile();
            Recalls = new RecallFile();
            Kits = new KitFile();
            CSVFormats = new CSVFormatsFile();
            ROChecked = new ROCheckedFile();

            PermissionHandler.GroupsFile = new GroupsFile();
            PermissionHandler.SetDefaultGroup(Config.DefaultGroup);

            Makes.MAX_RESULTS = Config.MaxSearchResults;
            Parts.MAX_RESULTS = Config.MaxSearchResults;
            Recalls.MAX_RESULTS = Config.MaxSearchResults;
            Kits.MAX_RESULTS = Config.MaxSearchResults;
            CSVFormats.MAX_RESULTS = Config.MaxSearchResults;
            ROChecked.MAX_RESULTS = Config.MaxSearchResults;
            PermissionHandler.GroupsFile.MAX_RESULTS = Config.MaxSearchResults;
        }
    }
}
