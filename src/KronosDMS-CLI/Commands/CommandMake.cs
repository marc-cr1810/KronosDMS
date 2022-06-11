using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace KronosDMS_CLI.Commands
{
    public class CommandMake
    {
        public static void HandleCommands(string cmd, string[] cmdArgs)
        {
            if (cmdArgs.Length == 1)
                return;

            switch (cmdArgs[1].ToLower())
            {
                case "search":
                    {
                        string name = "";
                        if (cmdArgs.Length == 3)
                        {
                            name = cmdArgs[2];
                            if (name.StartsWith('\"') && name.EndsWith('\"'))
                                name = name.Replace("\"", "");
                        }

                        MakesSearchResponse response = new MakesSearch(name).PerformRequestAsync().Result;
                        foreach (KeyValuePair<string, Make> make in response.Makes)
                        {
                            KConsole.WriteColoredLine(ConsoleColor.White, $"{make.Value.Name}");
                        }
                    }
                    break;
                case "add":
                    {
                        string name;

                        KConsole.WriteColored(ConsoleColor.DarkGray, "Name: ");
                        name = Console.ReadLine();
                        if (name == "")
                            break;

                        Make make = new Make() { Name = name, Models = new List<string>() };
                        Response response = new MakeAdd(make).PerformRequestAsync().Result;
                        if (!response.IsSuccess)
                            KConsole.WriteColoredLine(ConsoleColor.Red, "Failed to add make!");
                        else
                            KConsole.WriteColoredLine(ConsoleColor.Green, "Successfully added make!");
                    }
                    break;
                case "select":
                    {
                        string name;

                        if (cmdArgs.Length != 3)
                            break;

                        name = cmdArgs[2];
                        if (name.StartsWith('\"') && name.EndsWith('\"'))
                            name = name.Replace("\"", "");

                        MakesSearchResponse response = new MakesSearch(name).PerformRequestAsync().Result;
                        if (response.Makes.Count != 1)
                            break;
                        Make make = response.Makes.ElementAt(0).Value;
                        HandleSelectionCommands(make);
                    }
                    break;
                default:
                    KConsole.WriteColoredLine(ConsoleColor.Red, $"Unknown command {cmd}!");
                    break;
            }
        }

        private static void HandleSelectionCommands(Make make)
        {
            while (true)
            {
                KConsole.WriteColored(ConsoleColor.Cyan, $"FRANCHISE \"{make.Name}\" > ");
                string cmd = Console.ReadLine();
                string[] cmdArgs = Regex.Split(cmd, "(?<=^[^\"]*(?:\"[^\"]*\"[^\"]*)*) (?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                switch (cmdArgs[0].ToLower())
                {
                    case "list":
                        {
                            if (cmdArgs.Length == 1)
                                break;
                            switch (cmdArgs[1].ToLower())
                            {
                                case "models":
                                    if (cmdArgs.Length == 2)
                                    {
                                        foreach (string model in make.Models)
                                            KConsole.WriteColoredLine(ConsoleColor.White, $"{model}");
                                        break;
                                    }
                                    switch (cmdArgs[2].ToLower())
                                    {
                                        case "add":
                                            if (cmdArgs.Length == 4)
                                                make.Models.Add(cmdArgs[3]);
                                            break;
                                        case "remove":
                                            if (cmdArgs.Length == 4)
                                                make.Models.Remove(cmdArgs[3]);
                                            break;
                                        case "clear":
                                            make.Models.Clear();
                                            break;
                                        default:
                                            KConsole.WriteColoredLine(ConsoleColor.Red, $"Unknown action {cmdArgs[2]}!");
                                            break;
                                    }
                                    break;
                                default:
                                    KConsole.WriteColoredLine(ConsoleColor.Red, $"Unknown list item {cmdArgs[1]}!");
                                    break;
                            }
                        }
                        break;
                    case "details":
                        KConsole.WriteColoredLine(ConsoleColor.White, make.ToString());
                        break;
                    case "save":
                        Response response = new MakeSet(make).PerformRequestAsync().Result;
                        if (!response.IsSuccess)
                            KConsole.WriteColoredLine(ConsoleColor.Red, "Failed to save modified make!");
                        else
                            KConsole.WriteColoredLine(ConsoleColor.Green, "Successfully saved modified make!");
                        return;
                    case "exit":
                        return;
                    default:
                        KConsole.WriteColoredLine(ConsoleColor.Red, $"Unknown command {cmd}!");
                        break;
                }
            }
        }
    }
}
