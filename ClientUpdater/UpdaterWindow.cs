using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientUpdater
{
    public partial class UpdaterWindow : Form
    {
        bool FromMainApp = false;

        public UpdaterWindow(bool fromMainApp)
        {
            InitializeComponent();

            this.FromMainApp = fromMainApp;
        }

        private void UpdaterWindow_Load(object sender, EventArgs e)
        {
            string prefix = FromMainApp ? "updater/" : "./";
            if (!File.Exists($"{prefix}client.zip"))
            {
                MessageBox.Show("Updater could not locate downloaded data");
                Application.Exit();
            }

            DirectoryInfo dir = new DirectoryInfo(FromMainApp ? "./" : "../");

            // Remove all old application files except for the config file and the themes and updater dir
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                if (d.Name != "themes" && d.Name != "updater" && d.Name != "net5.0-windows")
                    Directory.Delete(d.FullName, true);
            }

            foreach (FileInfo file in dir.GetFiles())
            {
                if (file.Name != "config.json")
                    File.Delete(file.FullName);
            }

            // Extract downloaded zip file
            ZipFile.ExtractToDirectory($"{prefix}client.zip", dir.FullName);

            File.Delete($"{prefix}client.zip");

            this.Close();
        }
    }
}
