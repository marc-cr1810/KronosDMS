using System;

namespace KronosDMS_Server
{
    public class KConsole
    {
        private static bool NewLine = true;

        public static void WriteColoredLine(ConsoleColor color, string message)
        {
            if (NewLine)
            {
                PrintTime();
                NewLine = false;
            }
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
            NewLine = true;
        }
        public static void WriteColored(ConsoleColor color, string message)
        {
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
