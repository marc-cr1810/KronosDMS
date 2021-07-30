using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientUpdater
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Count() == 0)
            {
                Console.WriteLine("args is null");
            }
            else
            {
                Process mainApp = Process.GetProcessById(int.Parse(args[0]));
                Console.WriteLine(args[0]);
                mainApp.WaitForExit();
            }

            Application.Run(new UpdaterWindow(args.Count() >= 1));

            if (args.Count() == 3)
            {
                Process p = Process.Start("Client.exe", $"{args[1]} {args[2]}");
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}
