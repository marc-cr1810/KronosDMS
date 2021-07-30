using KronosDMS.Files;
using KronosDMS.Http.Server;
using KronosDMS.Objects;
using KronosDMS.Security;
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

        public static void Main(string[] args)
        {
            KConsole.WriteColored(System.ConsoleColor.DarkCyan, "[KromosDMS Server] Initializing server... ");

            Load();

            KConsole.WriteColoredLine(System.ConsoleColor.DarkGreen, "Done");

            log4net.Config.XmlConfigurator.Configure();

            KConsole.WriteColored(System.ConsoleColor.DarkCyan, "[KromosDMS Server] Configuring URL routes... ");
            var route_config = Routes.GetRoutes();
            KConsole.WriteColoredLine(System.ConsoleColor.DarkGreen, "Done");

            KConsole.WriteColored(System.ConsoleColor.DarkCyan, "[KromosDMS Server] Starting server... ");
            HttpServer httpServer = new HttpServer(Config.Port, route_config);

            Thread thread = new Thread(new ThreadStart(httpServer.Listen));
            thread.Start();
            KConsole.WriteColoredLine(System.ConsoleColor.DarkGreen, "Done");
        }

        public static void Load()
        {
            Config = Config.LoadConfig();
            UpdateConfig = UpdateConfig.LoadConfig();

            AccountManager = new UserAccountManager();

            Makes = new MakeFile();
            Parts = new PartsFile();
            Recalls = new RecallFile();
            Kits = new KitFile();

            PermissionHandler.GroupsFile = new GroupsFile();
            PermissionHandler.SetDefaultGroup(Config.DefaultGroup);
        }
    }
}
