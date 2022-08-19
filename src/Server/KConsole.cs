using System;
using System.IO;

namespace KronosDMS_Server
{
    public class Logger
    {
        private static readonly string LogPath = "logs/";

        public static void Log(string text, bool newline = false)
        {
            string logFile = $"{LogPath}/{DateTime.Now.ToString("yyyy-MM-dd")}.log";

            if (!Directory.Exists(LogPath))
                Directory.CreateDirectory(LogPath);

            string fileText = "";
            if (newline)
                fileText += $"[{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}] {text}";
            else
                fileText += text;

            File.AppendAllText(logFile, fileText);
        }
    }

    public class KConsole
    {
        private static bool NewLine = true;

        public static void WriteColoredLine(ConsoleColor color, string message)
        {
            WriteColored(color, message + '\n');
            NewLine = true;
        }
        public static void WriteColored(ConsoleColor color, string message)
        {
            Logger.Log(message, NewLine);
            if (NewLine)
            {
                PrintTime();
                NewLine = false;
            }
            ConsoleColor currentColor = Console.ForegroundColor; 
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = currentColor;
        }

        private static void PrintTime()
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"[{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}] ");
            Console.ForegroundColor = currentColor;
        }
    }
}
