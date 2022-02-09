using KronosDMS.Api;
using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS_Client.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KronosDMS_Client
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            this.WindowState = Client.Config.StartMaximized ? FormWindowState.Maximized : FormWindowState.Normal;

            this.BackColor = Client.ActiveTheme.Colors.Background;

            this.Menu.BackColor = Client.ActiveTheme.Colors.Foreground;
            foreach (ToolStripMenuItem item in this.Menu.Items)
                item.ForeColor = Client.ActiveTheme.Colors.Text.Default;

            this.OpenedWindowsPanel.BackColor = Client.ActiveTheme.Colors.Foreground;

            SetStatusTitle($"Currently logged in as {Client.ActiveAccount.FirstName} {Client.ActiveAccount.LastName} ({Client.ActiveAccount.Username})");
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Set the background color
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Client.ActiveTheme.Colors.Background;
        }

        public void SetStatusTitle(string status)
        {
            if (status is null || status == "")
                this.Text = $"KronosDMS v{Application.ProductVersion}";
            else
                this.Text = $"KronosDMS v{Application.ProductVersion} | {status}";
        }

        public void OpenForm(Window window)
        {
            //window.StartPosition = FormStartPosition.CenterParent;
            window.MdiParent = this;
            window.Show();

            FileMenuWindowMinimize.Enabled = true;
            FileMenuWindowMaximize.Enabled = true;
            FileMenuWindowClose.Enabled = true;
        }

        public void OpenFormDialog(Window window)
        {
            window.IsDialog = true;
            window.ShowDialog();
        }

        public void CloseForm(Window window)
        {
            //window.Close();
            window.Dispose();

            if (this.ActiveMdiChild is null)
            {
                FileMenuWindowMinimize.Enabled = false;
                FileMenuWindowMaximize.Enabled = false;
                FileMenuWindowClose.Enabled = false;
            }
        }

        private void Relogin()
        {
            AccountLoginResponse response = new AccountLogin(Client.Credentials.Username, Client.Credentials.PasswordHash, true).PerformRequestAsync().Result;

            try
            {
                if (response.IsSuccess)
                {
                    Client.Disconnected = false;
                    Client.ActiveAccount = response.Account;
                    Requester.AccessToken = response.Account.AccessToken;
                    SetStatusTitle($"Currently logged in as {Client.ActiveAccount.FirstName} {Client.ActiveAccount.LastName} ({Client.ActiveAccount.Username})");
                }
            }
            catch { }
            Client.Disconnected = true;
        }

        private void PingServerTimer_Tick(object sender, EventArgs e)
        {
            PingResponse ping = new Ping().PerformRequestAsync().Result;
            if (!ping.Success)
            {
                if (!Client.Disconnected)
                {
                    SetStatusTitle("Disconnected");
                    MessageBox.Show("Failed to connect to the server");
                    Client.Disconnected = true;
                }
                return;
            }

            Response validateAccount = new AccountValidate().PerformRequestAsync().Result;
            if (!validateAccount.IsSuccess)
            {
                Relogin();
            }
        }

        private void FileMenu_DropDownOpening(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is null)
            {
                this.FileMenuSave.Enabled = false;
                this.FileMenuDelete.Enabled = false;
                this.FileMenuImport.Enabled = false;
                this.FileMenuExport.Enabled = false;
                return;
            }
            this.FileMenuSave.Enabled = true;
            this.FileMenuDelete.Enabled = true;
            this.FileMenuImport.Enabled = true;
            this.FileMenuExport.Enabled = true;
        }

        private void FileMenuExit_Click(object sender, EventArgs e)
        {
            Client.Exit();
        }

        private void PartsMenuMaintenance_Click(object sender, EventArgs e)
        {
            OpenForm(new Forms.Parts.PartsMaintenanceForm());
        }

        private void PartsMenuKitsGeneral_Click(object sender, EventArgs e)
        {
            OpenForm(new Forms.Parts.KitForm());
        }

        private void PartsMenuKitsRecalls_Click(object sender, EventArgs e)
        {
            OpenForm(new Forms.Parts.RecallForm());
        }

        private void SetupUserAccounts_Click(object sender, EventArgs e)
        {
            OpenForm(new Forms.Server.UserAccountsForm());
        }

        private void SetupUserGroups_Click(object sender, EventArgs e)
        {
            OpenForm(new Forms.Server.UserGroupsForm());
        }

        private void PartsMenuSearch_Click(object sender, EventArgs e)
        {
            OpenForm(new Forms.Parts.PartsSearchForm("", false));
        }

        private void RecallsMenuSearch_Click(object sender, EventArgs e)
        {
            OpenForm(new Forms.Parts.RecallsSearchForm("", false));
        }

        private void KitsMenuSearch_Click(object sender, EventArgs e)
        {
            OpenForm(new Forms.Parts.KitsSearchForm("", false));
        }

        private void FileMenuSave_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is null)
                return;
            Window w = (Window)this.ActiveMdiChild;
            w.Save();
        }

        private void FileMenuDelete_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is null)
                return;
            Window w = (Window)this.ActiveMdiChild;
            w.Delete();
        }

        private void FileMenuImportCSV_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is null)
                return;
            Window w = (Window)this.ActiveMdiChild;
            w.ImportCSV();
        }

        private void FileMenuExportCSV_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is null)
                return;
            Window w = (Window)this.ActiveMdiChild;
            w.ExportCSV();
        }

        private void SetupMenuServerReload_Click(object sender, EventArgs e)
        {
            Response response = new ServerReload().PerformRequestAsync().Result;
        }

        private void SetupMenuAccountChangePassword_Click(object sender, EventArgs e)
        {
            OpenForm(new Forms.Account.ChangePassword());
        }

        private void SetupMenuAccountRelogin_Click(object sender, EventArgs e)
        {
            Relogin();
        }

        private void SetupMenuMakesMaintenance_Click(object sender, EventArgs e)
        {
            OpenForm(new Forms.Server.MakesMaintenanceForm());
        }

        private void FileMenuWindowMinimize_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is null)
                return;

            Window w = (Window)this.ActiveMdiChild;
            if (w.CurrentWindowState == FormWindowState.Normal)
                w.WindowState = FormWindowState.Minimized;
            else if (w.CurrentWindowState == FormWindowState.Maximized)
                w.WindowState = FormWindowState.Normal;
        }

        private void FileMenuWindowMaximize_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is null)
                return;

            Window w = (Window)this.ActiveMdiChild;
            if (w.CurrentWindowState == FormWindowState.Normal)
                w.WindowState = FormWindowState.Maximized;
            else if (w.CurrentWindowState == FormWindowState.Minimized)
                w.WindowState = FormWindowState.Normal;
        }

        private void FileMenuWindowClose_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is null)
                return;
            Window w = (Window)this.ActiveMdiChild;
            w.Close();
        }
    }
}
