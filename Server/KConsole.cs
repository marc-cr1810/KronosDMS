using System;

namespace KronosDMS_Server
{
    public class KConsole
    {
        public static void WriteColoredLine(ConsoleColor color, string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor; Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }
        public static void WriteColored(ConsoleColor color, string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor; Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = currentColor;
        }
    }
}
