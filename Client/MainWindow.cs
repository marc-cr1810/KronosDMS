using KronosDMS.Api;
using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS_Client.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KronosDMS_Client
{
    public partial class MainWindow : Form
    {
        public Window FocusedWindow;
        List<Window> Windows = new List<Window>();

        public MainWindow()
        {
            InitializeComponent();
            this.BackColor = Client.ActiveTheme.Colors.Background;

            this.Menu.BackColor = Client.ActiveTheme.Colors.Foreground;
            foreach (ToolStripMenuItem item in this.Menu.Items)
                item.ForeColor = Client.ActiveTheme.Colors.Text.Default;

            this.WindowView.BackColor = Client.ActiveTheme.Colors.Background;
            this.OpenedWindowsPanel.BackColor = Client.ActiveTheme.Colors.Foreground;

            this.Text = $"KronosDMS | Currently logged in as {Client.ActiveAccount.FirstName} {Client.ActiveAccount.LastName} ({Client.ActiveAccount.Username})";
        }

        public void OpenForm(Window window)
        {
            window.TopLevel = false;
            window.AutoScroll = true;
            window.Parent = this.WindowView;
            window.StartPosition = FormStartPosition.CenterParent;
            this.WindowView.Controls.Add(window);
            window.Show();
            window.BringToFront();
            this.Windows.Add(window);
        }

        public void OpenFormDialog(Window window)
        {
            window.ShowDialog();
        }

        public void CloseForm(Window window)
        {
            this.Windows.Remove(window);
            window.Close();
            window.Dispose();
        }

        private void Relogin()
        {
            AccountLoginResponse response = new AccountLogin(Client.ActiveAccount.Username, Client.ActiveAccount.PasswordHash, true).PerformRequestAsync().Result;

            try
            {
                if (response.IsSuccess)
                {
                    Client.Disconnected = false;
                    Client.ActiveAccount = response.Account;
                    Requester.AccessToken = response.Account.AccessToken;
                    this.Text = $"KronosDMS | Currently logged in as {Client.ActiveAccount.FirstName} {Client.ActiveAccount.LastName} ({Client.ActiveAccount.Username})";
                }
            }
            catch { }
        }

        private void PingServerTimer_Tick(object sender, EventArgs e)
        {
            PingResponse ping = new Ping().PerformRequestAsync().Result;
            if (!ping.Success)
            {
                if (!Client.Disconnected)
                {
                    this.Text = $"KronosDMS | Disconnected";
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
            Client.Disconnected = false;
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
            if (FocusedWindow == null)
                return;
            FocusedWindow.Save();
        }

        private void FileMenuDelete_Click(object sender, EventArgs e)
        {
            if (FocusedWindow == null)
                return;
            FocusedWindow.Delete();
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
    }
}
