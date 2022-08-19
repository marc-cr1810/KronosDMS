using KronosDMS.Api;
using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ClientInstaller
{
    public partial class InstallerWindow : Form
    {
        public InstallerWindow()
        {
            InitializeComponent();
        }

        private void buttonTestConnection_Click(object sender, EventArgs e)
        {
            if (textServerIP.Text == "" || textServerPort.Text == "")
                return;

            Requester.BaseAPIAddr = $"http://{textServerIP.Text}:{textServerPort.Text}";

            PingResponse ping = new Ping().PerformRequestAsync().Result;
            if (!ping.Success)
            {
                MessageBox.Show("Failed to connect to the server");
                labelConnection.Text = "Disconnected";
            }
            else
            {
                labelConnection.Text = "Connected";
            }
            labelConnection.Visible = true;
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            if (textServerIP.Text == "" || textServerPort.Text == "" || textDirectory.Text == "")
                return;

            string dir = $"{textDirectory.Text}/KronosDMS/";
            if (Directory.Exists(dir))
            {
                if (MessageBox.Show("KronosDMS Client is already installed.\nReinstall?", "Reinstall", MessageBoxButtons.YesNoCancel) == DialogResult.No)
                    return;
                else
                    Directory.Delete(dir, true);
            }
            Directory.CreateDirectory(dir);

            Response clientDownload = new DownloadUpdate(dir).PerformRequestAsync().Result;
            Response updaterDownload = new DownloadUpdater(dir).PerformRequestAsync().Result;
            Response themesDownload = new DownloadThemes(dir).PerformRequestAsync().Result;

            if (clientDownload.IsSuccess && updaterDownload.IsSuccess && themesDownload.IsSuccess)
            {
                // Extract downloaded zip files
                System.IO.Compression.ZipFile.ExtractToDirectory($"{dir}client.zip", dir);
                File.Delete($"{dir}client.zip");

                Directory.CreateDirectory($"{dir}updater/");
                System.IO.Compression.ZipFile.ExtractToDirectory($"{dir}updater.zip", $"{dir}updater");
                File.Delete($"{dir}updater.zip");

                Directory.CreateDirectory($"{dir}themes/");
                System.IO.Compression.ZipFile.ExtractToDirectory($"{dir}themes.zip", $"{dir}themes");
                File.Delete($"{dir}themes.zip");

                if (checkRun.Checked)
                {
                    ProcessStartInfo info = new ProcessStartInfo
                    {
                        FileName = $"{dir}Client.exe",
                        WorkingDirectory = dir
                    };
                    Process p = Process.Start(info);
                    Process.GetCurrentProcess().Kill();
                }

                return;
            }
        }
    }
}
