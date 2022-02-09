using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace KronosDMS_CLI.Commands
{
    public class CommandParts
    {
        public static void HandleCommands(string cmd, string[] cmdArgs)
        {
            if (cmdArgs.Length == 1)
                return;

            switch (cmdArgs[1].ToLower())
            {
                case "search":
                    {
                        string make = "", number = "", description = "";
                        int i = 2;
                        while (i < cmdArgs.Length)
                        {
                            if (cmdArgs[i].StartsWith('-'))
                            {
                                int separator = cmdArgs[i].IndexOf('=');
                                string value = cmdArgs[i].Substring(separator + 1, cmdArgs[i].Length - (separator + 1));
                                if (value.StartsWith('\"') && value.EndsWith('\"'))
                                    value = value.Replace("\"", "");
                                switch (cmdArgs[i].Substring(0, separator))
                                {
                                    case "-make":
                                    case "-f":
                                        make = value;
                                        break;
                                    case "-number":
                                    case "-n":
                                        number = value;
                                        break;
                                    case "-description":
                                    case "-d":
                                        description = value;
                                        break;
                                }
                            }
                            else if (cmdArgs.Length == 3)
                            {
                                description = cmdArgs[i];
                                if (description.StartsWith('\"') && description.EndsWith('\"'))
                                    description = description.Replace("\"", "");
                            }
                            i++;
                        }

                        PartsSearchResponse response = new PartsSearch(make, number, description).PerformRequestAsync().Result;
                        foreach (KeyValuePair<string, Group> part in response.Parts)
                        {
                            KConsole.WriteColoredLine(ConsoleColor.White, $"{part.Value.Make}: {part.Value.Number} \"{part.Value.Description}\"");
                        }
                    }
                    break;
                case "add":
                    {
                        string make, number, description;

                        KConsole.WriteColored(ConsoleColor.DarkGray, "Make: ");
                        make = Console.ReadLine();
                        if (make == "")
                            break;

                        KConsole.WriteColored(ConsoleColor.DarkGray, "Number: ");
                        number = Console.ReadLine().ToUpper();
                        if (number == "")
                            break;

                        KConsole.WriteColored(ConsoleColor.DarkGray, "Description: ");
                        description = Console.ReadLine();
                        if (description == "")
                            break;

                        Group part = new Group() { Make = make, Number = number, Description = description };
                        Response response = new PartAdd(part).PerformRequestAsync().Result;
                        if (!response.IsSuccess)
                            KConsole.WriteColoredLine(ConsoleColor.Red, "Failed to add part!");
                        else
                            KConsole.WriteColoredLine(ConsoleColor.Green, "Successfully added part!");
                    }
                    break;
                case "select":
                    {
                        string number;

                        if (cmdArgs.Length != 3)
                            break;

                        number = cmdArgs[2];
                        if (number.StartsWith('\"') && number.EndsWith('\"'))
                            number = number.Replace("\"", "");

                        PartsSearchResponse response = new PartsSearch("", number, "").PerformRequestAsync().Result;
                        if (response.Parts.Count != 1)
                            break;
                        Group part = response.Parts.ElementAt(0).Value;
                        HandleSelectionCommands(part);
                    }
                    break;
                default:
                    KConsole.WriteColoredLine(ConsoleColor.Red, $"Unknown command {cmd}!");
                    break;
            }
        }

        private static void HandleSelectionCommands(Group part)
        {
            while (true)
            {
                KConsole.WriteColored(ConsoleColor.Cyan, $"PART \"{part.Number}\" > ");
                string cmd = Console.ReadLine();
                string[] cmdArgs = Regex.Split(cmd, "(?<=^[^\"]*(?:\"[^\"]*\"[^\"]*)*) (?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                switch (cmdArgs[0].ToLower())
                {
                    case "modify":
                        {
                            if (cmdArgs.Length == 1)
                                break;
                            switch (cmdArgs[1].ToLower())
                            {
                                case "make":
                                    {
                                        string value;

                                        if (cmdArgs.Length != 3)
                                            break;

                                        value = cmdArgs[2];
                                        if (value.StartsWith('\"') && value.EndsWith('\"'))
                                            value = value.Replace("\"", "");

                                        part.Make = value;
                                    }
                                    break;
                                case "description":
                                    {
                                        string value;

                                        if (cmdArgs.Length != 3)
                                            break;

                                        value = cmdArgs[2];
                                        if (value.StartsWith('\"') && value.EndsWith('\"'))
                                            value = value.Replace("\"", "");

                                        part.Description = value;
                                    }
                                    break;
                                case "predecessor":
                                    {
                                        string value;

                                        if (cmdArgs.Length != 3)
                                            break;

                                        value = cmdArgs[2];
                                        if (value.StartsWith('\"') && value.EndsWith('\"'))
                                            value = value.Replace("\"", "");

                                        part.Predecessor = value;
                                    }
                                    break;
                                case "successor":
                                    {
                                        string value;

                                        if (cmdArgs.Length != 3)
                                            break;

                                        value = cmdArgs[2];
                                        if (value.StartsWith('\"') && value.EndsWith('\"'))
                                            value = value.Replace("\"", "");

                                        part.Successor = value;
                                    }
                                    break;
                                default:
                                    KConsole.WriteColoredLine(ConsoleColor.Red, $"Unknown item {cmdArgs[1]}!");
                                    break;
                            }
                            break;
                        }
                    case "details":
                        KConsole.WriteColoredLine(ConsoleColor.White, part.ToString());
                        break;
                    case "save":
                        Response response = new PartSet(part).PerformRequestAsync().Result;
                        if (!response.IsSuccess)
                            KConsole.WriteColoredLine(ConsoleColor.Red, "Failed to save modified part!");
                        else
                            KConsole.WriteColoredLine(ConsoleColor.Green, "Successfully saved modified part!");
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
