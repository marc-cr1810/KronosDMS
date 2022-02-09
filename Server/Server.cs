using KronosDMS.Files;
using KronosDMS.Http.Server;
using KronosDMS.Http.Server.Models;
using KronosDMS.Objects;
using KronosDMS.Security;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
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

        public static void Main(string[] args)
        {
            KConsole.WriteColored(System.ConsoleColor.DarkCyan, "[KronosDMS Server] Initializing server... ");

            Load();

            KConsole.WriteColoredLine(System.ConsoleColor.DarkGreen, "Done");

            KConsole.WriteColoredLine(System.ConsoleColor.DarkGray, $"   Client version: {UpdateConfig.UpdateInfo.Client.Version}");
            KConsole.WriteColoredLine(System.ConsoleColor.DarkGray, $"  Updater version: {UpdateConfig.UpdateInfo.Updater.Version}");
            KConsole.WriteColoredLine(System.ConsoleColor.DarkGray, $"      Makes count: {Makes.Makes.Count}");
            KConsole.WriteColoredLine(System.ConsoleColor.DarkGray, $"      Parts count: {Parts.Parts.Count}");
            KConsole.WriteColoredLine(System.ConsoleColor.DarkGray, $"       Kits count");
            KConsole.WriteColoredLine(System.ConsoleColor.DarkGray, $"       ├─── General: {Kits.Kits.Count}");
            KConsole.WriteColoredLine(System.ConsoleColor.DarkGray, $"       └─── Recalls: {Recalls.Recalls.Count}");

            log4net.Config.XmlConfigurator.Configure();

            KConsole.WriteColored(System.ConsoleColor.DarkCyan, "[KronosDMS Server] Configuring URL routes... ");
            List<Route> route_config = Routes.GetRoutes();
            KConsole.WriteColoredLine(System.ConsoleColor.DarkGreen, "Done");

            KConsole.WriteColoredLine(System.ConsoleColor.DarkGray, $"  Routes");
            for (int i = 0; i < route_config.Count; i++)
            {
                string prefix = i < route_config.Count - 1 ? "  ├─── " : "  └─── ";
                KConsole.WriteColoredLine(System.ConsoleColor.DarkGray, $"{prefix}{route_config[i].Name}\t{route_config[i].UrlRegex}");
            }

            KConsole.WriteColored(System.ConsoleColor.DarkCyan, "[KronosDMS Server] Starting server... ");
            HttpServer httpServer = new HttpServer(Config.Port, route_config);

            Thread thread = new Thread(new ThreadStart(httpServer.Listen));
            thread.Start();
            KConsole.WriteColoredLine(System.ConsoleColor.DarkGreen, "Done");

            KConsole.WriteColoredLine(System.ConsoleColor.DarkGray, $"  Running server on port: {Config.Port}");
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

            PermissionHandler.GroupsFile = new GroupsFile();
            PermissionHandler.SetDefaultGroup(Config.DefaultGroup);

            Makes.MAX_RESULTS = Config.MaxSearchResults;
            Parts.MAX_RESULTS = Config.MaxSearchResults;
            Recalls.MAX_RESULTS = Config.MaxSearchResults;
            Kits.MAX_RESULTS = Config.MaxSearchResults;
            PermissionHandler.GroupsFile.MAX_RESULTS = Config.MaxSearchResults;
        }
    }
}
