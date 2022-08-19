using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KronosDMS_Client.Forms.Server
{
    public partial class UserAccountsSearchForm : Window
    {
        public UserAccount Result;

        public UserAccountsSearchForm(string id, string username)
        {
            InitializeComponent();

            this.labelUserID.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelUsername.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelFirstname.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelLastname.ForeColor = Client.ActiveTheme.Colors.Text.Default;

            this.textUserID.Text = id;
            this.textUsername.Text = username;

            if (id != "" || username != "")
                this.Search();

            ListUserAccounts.Columns[2].Width = ListUserAccounts.Width - ListUserAccounts.Columns[0].Width - ListUserAccounts.Columns[1].Width - 5;
        }

        private void Search()
        {
            UserAccountsSearchResponse response = new UserAccountsSearch(this.textUsername.Text, this.textFirstname.Text, this.textLastname.Text).PerformRequestAsync().Result;

            if (!response.IsSuccess)
            {
                MessageBox.Show($"Failed to search for user accounts\n{response.RawMessage}", "Failed");
                return;
            }

            ListUserAccounts.Items.Clear();

            foreach (KeyValuePair<int, UserAccount> account in response.UserAccounts)
            {
                ListViewItem partItem = ListUserAccounts.Items.Add(account.Value.Username);
                partItem.Name = account.Key.ToString();
                partItem.SubItems.Add(account.Value.ID.ToString());
                partItem.SubItems.Add($"{account.Value.FirstName} {account.Value.LastName}");
            };

            ListUserAccounts.Columns[2].Width = ListUserAccounts.Width - ListUserAccounts.Columns[0].Width - ListUserAccounts.Columns[1].Width - 5;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void ListUserAccounts_Resize(object sender, EventArgs e)
        {
            if (ListUserAccounts.Columns.Count > 0)
            {
                ListUserAccounts.Columns[2].Width = ListUserAccounts.Width - ListUserAccounts.Columns[0].Width - ListUserAccounts.Columns[1].Width - 5;
            }
        }

        private void ListUserAccounts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int id = int.Parse(ListUserAccounts.SelectedItems[0].Name);

            UserAccountsSearchResponse response = new UserAccountsSearch(id).PerformRequestAsync().Result;
            Result = response.UserAccounts[id];
            Client.MainWindow.CloseForm(this);
        }
    }
}
