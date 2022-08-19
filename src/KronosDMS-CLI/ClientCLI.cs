using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS_CLI.Commands;
using System;

namespace KronosDMS_CLI
{
    class ClientCLI
    {
        static void Main(string[] args)
        {
            KConsole.WriteColoredLine(ConsoleColor.DarkCyan, "[KronosDMS Api] Checking API status...");
            PingResponse ping = new Ping().PerformRequestAsync().Result;
            if (!ping.IsSuccess)
            {
                KConsole.WriteColoredLine(ConsoleColor.Red, "Failed!");
                return;
            }
            else
                KConsole.WriteColoredLine(ConsoleColor.Green, "Success");

            Command.HandleCommands();
        }
    }
}
