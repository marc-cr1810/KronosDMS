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

            UserGroupsGetResponse groups = new UserGroupsGet("").PerformRequestAsync().Result;
            foreach (KeyValuePair<string, Group> group in groups.Groups)
                boxGroups.Items.Add(group.Key);

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
        }

        private void textUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.textUsername.Text == "" || this.textUsername.Text == SelectedAccount.Username)
                    return;
                if (this.textUserID.Text != "")
                    return;
                UserAccountsSearchResponse response = new UserAccountsSearch(this.textUsername.Text, "", "").PerformRequestAsync().Result;
                if (response.UserAccounts.Count != 1)
                {
                    if (MessageBox.Show($"Create new user account \"{this.textUsername.Text}\"?", "Create new part account?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.Text = $"User Accounts | {this.textUsername.Text.ToUpper()} - Creating new user account";
                        this.textUsername.Text = this.textUsername.Text;
                        this.NewUserAccount = true;
                        SelectedAccount.Username = this.textUsername.Text;
                        FillDetails(SelectedAccount);
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
            }
            this.NewUserAccount = false;
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
                byte[] password256 = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(SelectedAccount.Username));
                StringBuilder pwBuilder = new StringBuilder();
                for (int i = 0; i < password256.Length; i++)
                {
                    pwBuilder.Append(password256[i].ToString("x2"));
                }
                SelectedAccount.PasswordHash = pwBuilder.ToString();

                response = new UserAccountAdd(SelectedAccount).PerformRequestAsync().Result;
                if (!response.IsSuccess)
                {
                    MessageBox.Show($"Failed to add user account\n{response.RawMessage}");
                    return;
                }
            }

            response = new UserAccountsSet(SelectedAccount).PerformRequestAsync().Result;
            if (!response.IsSuccess)
            {
                MessageBox.Show($"Failed to save user account\n{response.RawMessage}");
                return;
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
    }
}
