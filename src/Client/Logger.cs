using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS_Client
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

        public static void Log(string message, LogLevel level = LogLevel.INFO, string Details = "")
        {
            LoggerItem item = new LoggerItem();
            item.Message = message;
            item.Timestamp = DateTime.Now;
            item.Level = level;
            item.Details = Details;

            LogList.Add(item);
            Console.WriteLine(item.ToString());

            string logFile = $"{LogPath}/{DateTime.Now.ToString("yyyy-MM-dd")}.log";

            string fileText = "";
            fileText += $"{item.ToString()}\n";

            foreach (string line in item.Details.Split("\n", StringSplitOptions.RemoveEmptyEntries))
            {
                fileText += "\t" + line + "\n";
            }

            File.AppendAllText(logFile, fileText);
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

        public override string ToString()
        {
            string time = $"[{Timestamp.ToString("yyyy/MM/dd HH:mm:ss")}]";
            string level = $"[{((Level == LogLevel.INFO) ? "INFO" : (Level == LogLevel.OK) ? "OK" : (Level == LogLevel.WARN) ? "WARN" : (Level == LogLevel.ERROR) ? "ERROR" : "FATAL")}]";

            return $"{time} {level}: {Message}";
        }
    }
}
