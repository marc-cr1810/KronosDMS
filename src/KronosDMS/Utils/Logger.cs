using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS.Utils
{
    public static class Logger
    {
        private static readonly string LogPath = "logs/";
        private static List<LoggerItem> LogList;

        public static void Init()
        {
            LogList = new List<LoggerItem>();

            if (!Directory.Exists(LogPath))
                Directory.CreateDirectory(LogPath);

            Log("Initialized logger", LogLevel.OK);
        }

        public static void Log(string message, LogLevel level = LogLevel.INFO, string details = "", string source = "")
        {
            LoggerItem item = new LoggerItem();
            item.Message = message;
            item.Timestamp = DateTime.Now;
            item.Level = level;
            item.Details = details;
            item.Source = source;

            LogList.Add(item);

            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = level == LogLevel.OK ? ConsoleColor.Green :
                                      level == LogLevel.WARN ? ConsoleColor.Yellow :
                                      level == LogLevel.ERROR ? ConsoleColor.Red :
                                      level == LogLevel.FATAL ? ConsoleColor.DarkRed :
                                      ConsoleColor.White;

            Console.WriteLine(item.ToString());
            foreach (string s in item.Details.Split('\n', StringSplitOptions.RemoveEmptyEntries))
                Console.WriteLine("\t" + s);
            Console.ForegroundColor = currentColor;

            string logFile = $"{LogPath}/{DateTime.Now.ToString("yyyy-MM-dd")}.log";

            string fileText = "";
            fileText += $"{item}\n";

            foreach (string line in item.Details.Split("\n", StringSplitOptions.RemoveEmptyEntries))
            {
                fileText += "\t" + line + "\n";
            }

            File.AppendAllText(logFile, fileText);
        }

        public static void LogException(string message, Exception exception, LogLevel level = LogLevel.ERROR, string details = "", string source = "")
        {
            if (exception != null)
            {
                details += "Description: " + exception.Message + "\n";
                if (exception.InnerException != null)
                    details += "---> " + exception.InnerException.Message + "\n";
                details += exception.StackTrace + "\n";
            }
            Log(message, level, details, source);
        }

        public static LoggerItem Get(int i)
        {
            return LogList[i];
        }

        public static int Count()
        {
            return LogList.Count();
        }
    }

    public enum LogLevel
    {
        INFO,
        OK,
        WARN,
        ERROR,
        FATAL
    }

    public struct LoggerItem
    {
        public LogLevel Level;
        public DateTime Timestamp;
        public string Message;
        public string Details;
        public string Source;
        public override string ToString()
        {
            string time = $"[{Timestamp.ToString("yyyy/MM/dd HH:mm:ss")}]";
            string level = $"[{((Level == LogLevel.INFO) ? "INFO" : (Level == LogLevel.OK) ? "OK" : (Level == LogLevel.WARN) ? "WARN" : (Level == LogLevel.ERROR) ? "ERROR" : "FATAL")}]";
            string source = (Source.Length > 0) ? $" [{Source}]" : "";

            return $"{time} {level}{source}: {Message}";
        }
    }
}
