using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using System;
using System.Text.RegularExpressions;

namespace KronosDMS_CLI.Commands
{
    public static class Command
    {
        public static bool Awaiting = false;

        public static void HandleCommands()
        {
            while (true)
            {
                KConsole.WriteColored(ConsoleColor.Cyan, "> ");
                string cmd = Console.ReadLine();
                string[] cmdArgs = Regex.Split(cmd, "(?<=^[^\"]*(?:\"[^\"]*\"[^\"]*)*) (?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                switch (cmdArgs[0].ToLower())
                {
                    case "makes":
                        CommandMake.HandleCommands(cmd, cmdArgs);
                        break;
                    case "parts":
                        CommandParts.HandleCommands(cmd, cmdArgs);
                        break;
                    case "recalls":
                        CommandRecalls.HandleCommands(cmd, cmdArgs);
                        break;
                    case "ping":
                        {
                            PingResponse ping = new Ping().PerformRequestAsync().Result;
                            if (!ping.IsSuccess)
                                KConsole.WriteColoredLine(ConsoleColor.Red, "Failed!");
                            else
                                KConsole.WriteColoredLine(ConsoleColor.Green, "Success");
                        }
                        break;
                    case "exit":
                        goto exit;
                    default:
                        KConsole.WriteColoredLine(ConsoleColor.Red, $"Unknown command {cmd}!");
                        break;
                }
            }
        exit: return;
        }
    }
}
