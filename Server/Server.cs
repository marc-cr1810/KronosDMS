using KronosDMS.Objects;
using KronosDMS.Files;
using KronosDMS.Http.Server;
using System.Threading;
using KronosDMS.Manager;
using KronosDMS.Security;
using System.Collections.Generic;

namespace KronosDMS_Server
{
    class Server
    {
        public static UserAccountManager AccountManager { get; set; }

        public static PartsFile Parts { get; set; }
        public static MakeFile Makes { get; set; }
        public static RecallFile Recalls { get; set; }

        static void Main(string[] args)
        {
            KConsole.WriteColored(System.ConsoleColor.DarkCyan, "[KromosDMS Server] Initializing server... ");
            AccountManager = new UserAccountManager();

            Makes = new MakeFile();
            Parts = new PartsFile();
            Recalls = new RecallFile();

            PermissionHandler.GroupsFile = new GroupsFile();

            KConsole.WriteColoredLine(System.ConsoleColor.DarkGreen, "Done");

            log4net.Config.XmlConfigurator.Configure();

            KConsole.WriteColored(System.ConsoleColor.DarkCyan, "[KromosDMS Server] Configuring URL routes... ");
            var route_config = Routes.GetRoutes();
            KConsole.WriteColoredLine(System.ConsoleColor.DarkGreen, "Done");

            KConsole.WriteColored(System.ConsoleColor.DarkCyan, "[KromosDMS Server] Starting server... ");
            HttpServer httpServer = new HttpServer(8080, route_config);

            Thread thread = new Thread(new ThreadStart(httpServer.Listen));
            thread.Start();
            KConsole.WriteColoredLine(System.ConsoleColor.DarkGreen, "Done");
        }
    }
}
