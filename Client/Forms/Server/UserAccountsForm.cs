using KronosDMS;
using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace KronosDMS_Client.Forms.Server
{
    public partial class UserAccountsForm : Window
    {
        bool NewUserAccount = false;
        UserAccount SelectedAccount = new UserAccount();

        public UserAccountsForm()
        {
            InitializeComponent();

            this.labelUserID.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelUsername.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelFirstname.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelLastname.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelGroup.ForeColor = Client.ActiveTheme.Colors.Text.Default;

            this.Tools.BackColor = Client.ActiveTheme.Colors.Foreground;
        }

        private void FillDetails(UserAccount account)
        {
            if (account.Username is null)
                return;

            SelectedAccount = account;

            this.Text = $"User Accounts | {account.Username} \"{account.FirstName} {account.LastName}\" - Editing";
            this.NewUserAccount = false;

            UserGroupsSearchResponse groups = new UserGroupsSearch("").PerformRequestAsync().Result;
            foreach (KeyValuePair<string, Group> group in groups.Groups)
                boxGroups.Items.Add(group.Key);

            if (account.ID != 0)
                textUserID.Text = account.ID.ToString();
            textUserID.Enabled = false;
            textUsername.Text = account.Username;
            textFirstname.Text = account.FirstName;
            textLastname.Text = account.LastName;
            boxGroups.Text = account.Group;
        }

        private void ClearDetails()
        {
            if (SelectedAccount.Username is null)
                return;

            SelectedAccount = new UserAccount();

            this.Text = $"User Accounts";

            boxGroups.Items.Clear();

            textUserID.Text = "";
            textUserID.Enabled = true;
            textUsername.Text = "";
            textFirstname.Text = "";
            textLastname.Text = "";
        }

        private void SearchUserID()
        {
            try
            {
                UserAccountsSearchResponse response = new UserAccountsSearch(int.Parse(this.textUserID.Text)).PerformRequestAsync().Result;
                if (response.UserAccounts.Count == 1)
                {
                    FillDetails(response.UserAccounts.ElementAt(0).Value);
                    return;
                }
                MessageBox.Show("Invalid User ID");
                ClearDetails();
                return;
            }
            catch
            {
                ClearDetails();
                return;
            }
        }

        private void SearchUsername()
        {
            if (this.textUsername.Text == "" || this.textUsername.Text == SelectedAccount.Username)
                return;
            if (this.textUserID.Text != "")
                return;
            UserAccountsSearchResponse response = new UserAccountsSearch(this.textUsername.Text, "", "").PerformRequestAsync().Result;
            if (response.UserAccounts.Count != 1)
            {
                if (MessageBox.Show($"Create new user account \"{this.textUsername.Text}\"?", "Create new user account?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.textUsername.Text = this.textUsername.Text;
                    SelectedAccount.Username = this.textUsername.Text;
                    FillDetails(SelectedAccount);
                    this.Text = $"User Accounts | {this.textUsername.Text.ToUpper()} - Creating new user account";
                    this.NewUserAccount = true;
                    return;
                }
                else
                {
                    UserAccountsSearchForm form = new UserAccountsSearchForm("", this.textUsername.Text);
                    Client.MainWindow.OpenFormDialog(form);
                    FillDetails(form.Result);
                    form.Dispose();
                }
            }
            else FillDetails(response.UserAccounts.ElementAt(0).Value);
            this.NewUserAccount = false;
        }

        private void buttonSearchID_Click(object sender, EventArgs e)
        {
            UserAccountsSearchForm form = new UserAccountsSearchForm(textUserID.Text, "");
            Client.MainWindow.OpenFormDialog(form);
            FillDetails(form.Result);
            form.Dispose();
        }

        private void buttonSearchUsername_Click(object sender, EventArgs e)
        {
            UserAccountsSearchForm form = new UserAccountsSearchForm("", textUsername.Text);
            Client.MainWindow.OpenFormDialog(form);
            FillDetails(form.Result);
            form.Dispose();
        }

        private void textUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchUserID();
            }
        }

        private void textUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchUsername();
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (SelectedAccount.Username is null)
                return;

            SelectedAccount.Username = textUsername.Text;
            SelectedAccount.FirstName = textFirstname.Text;
            SelectedAccount.LastName = textLastname.Text;
            SelectedAccount.Group = boxGroups.Text;

            Response response;
            if (NewUserAccount)
            {
                SelectedAccount.PasswordHash = Utils.SHA256Hash(SelectedAccount.Username);

                response = new UserAccountAdd(SelectedAccount).PerformRequestAsync().Result;
                if (!response.IsSuccess)
                {
                    MessageBox.Show($"Failed to add user account\n{response.RawMessage}");
                    return;
                }
            }
            else
            {
                response = new UserAccountsSet(SelectedAccount).PerformRequestAsync().Result;
                if (!response.IsSuccess)
                {
                    MessageBox.Show($"Failed to save user account\n{response.RawMessage}");
                    return;
                }
            }
            ClearDetails();
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            ClearDetails();
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            if (SelectedAccount.Username is null)
                return;

            Response response = new UserAccountRemove(SelectedAccount.ID).PerformRequestAsync().Result;
            if (!response.IsSuccess)
            {
                MessageBox.Show($"Failed to delete user account\n{response.RawMessage}");
                return;
            }
            ClearDetails();
        }

        private void textUserID_Leave(object sender, EventArgs e)
        {
            if (textUserID.Text != "")
                SearchUserID();
        }

        private void textUsername_Leave(object sender, EventArgs e)
        {
            if (textUserID.Text != "")
                SearchUsername();
        }
    }
}
