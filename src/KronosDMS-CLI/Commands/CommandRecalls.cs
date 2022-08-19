using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using KronosDMS.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace KronosDMS_CLI.Commands
{
    public class CommandRecalls
    {
        public static void HandleCommands(string cmd, string[] cmdArgs)
        {
            if (cmdArgs.Length == 1)
                return;

            switch (cmdArgs[1].ToLower())
            {
                case "search":
                    {
                        string make = "", model = "", number = "", description = "";
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
                                    case "-model":
                                    case "-m":
                                        model = value;
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

                        RecallsSearchResponse response = new RecallsSearch(make, model, number, description).PerformRequestAsync().Result;
                        foreach (KeyValuePair<string, Recall> recall in response.Recalls)
                        {
                            KConsole.WriteColoredLine(ConsoleColor.White, $"{recall.Value.Make}: {recall.Value.Number} \"{recall.Value.Description}\"");
                        }
                    }
                    break;
                case "add":
                    {
                        string make, model, number, description;

                        KConsole.WriteColored(ConsoleColor.DarkGray, "Make: ");
                        make = Console.ReadLine();
                        if (make == "")
                            break;

                        KConsole.WriteColored(ConsoleColor.DarkGray, "Model: ");
                        model = Console.ReadLine();
                        if (model == "")
                            break;

                        KConsole.WriteColored(ConsoleColor.DarkGray, "Number: ");
                        number = Console.ReadLine().ToUpper();
                        if (number == "")
                            break;

                        KConsole.WriteColored(ConsoleColor.DarkGray, "Description: ");
                        description = Console.ReadLine();
                        if (description == "")
                            break;

                        Recall recall = new Recall() { Make = make, Model = model, Number = number, Description = description, Parts = new List<PartQuantityPair>() };
                        Response response = new RecallAdd(recall).PerformRequestAsync().Result;
                        if (!response.IsSuccess)
                            KConsole.WriteColoredLine(ConsoleColor.Red, "Failed to add recall!");
                        else
                            KConsole.WriteColoredLine(ConsoleColor.Green, "Successfully added recall!");
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

                        RecallsSearchResponse response = new RecallsSearch("", "", number, "").PerformRequestAsync().Result;
                        if (response.Recalls.Count != 1)
                            break;
                        Recall recall = response.Recalls.ElementAt(0).Value;
                        HandleSelectionCommands(recall);
                    }
                    break;
                default:
                    KConsole.WriteColoredLine(ConsoleColor.Red, $"Unknown command {cmd}!");
                    break;
            }
        }
        private static void HandleSelectionCommands(Recall recall)
        {
            while (true)
            {
                KConsole.WriteColored(ConsoleColor.Cyan, $"RECALL \"{recall.Number}\" > ");
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

                                        recall.Make = value;
                                    }
                                    break;
                                case "model":
                                    {
                                        string value;

                                        if (cmdArgs.Length != 3)
                                            break;

                                        value = cmdArgs[2];
                                        if (value.StartsWith('\"') && value.EndsWith('\"'))
                                            value = value.Replace("\"", "");

                                        recall.Model = value;
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

                                        recall.Description = value;
                                    }
                                    break;
                                default:
                                    KConsole.WriteColoredLine(ConsoleColor.Red, $"Unknown item {cmdArgs[1]}!");
                                    break;
                            }
                            break;
                        }
                    case "list":
                        {
                            if (cmdArgs.Length == 1)
                                break;
                            switch (cmdArgs[1].ToLower())
                            {
                                case "parts":
                                    if (cmdArgs.Length == 2)
                                    {
                                        foreach (PartQuantityPair kvPair in recall.Parts)
                                            KConsole.WriteColoredLine(ConsoleColor.White, $"{kvPair.Number}\tx{kvPair.Quantity}");
                                        break;
                                    }
                                    switch (cmdArgs[2].ToLower())
                                    {
                                        case "add":
                                            if (cmdArgs.Length == 5)
                                            {
                                                try
                                                {
                                                    recall.Parts.Add(new PartQuantityPair(cmdArgs[3], int.Parse(cmdArgs[4])));
                                                }
                                                catch { }
                                            }
                                            break;
                                        case "remove":
                                            if (cmdArgs.Length == 4)
                                            {
                                                for (int i = 0; i < recall.Parts.Count; i++)
                                                {
                                                    if (recall.Parts[i].Number == cmdArgs[3])
                                                    {
                                                        recall.Parts.RemoveAt(i);
                                                        break;
                                                    }
                                                }
                                            }
                                            break;
                                        case "clear":
                                            recall.Parts.Clear();
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
                        KConsole.WriteColoredLine(ConsoleColor.White, recall.ToString());
                        break;
                    case "save":
                        Response response = new RecallSet(recall).PerformRequestAsync().Result;
                        if (!response.IsSuccess)
                            KConsole.WriteColoredLine(ConsoleColor.Red, "Failed to save modified recall!");
                        else
                            KConsole.WriteColoredLine(ConsoleColor.Green, "Successfully saved modified recall!");
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
