using KronosDMS.Api;
using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KronosDMS_Client
{
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
            this.BackColor = Client.ActiveTheme.Colors.Foreground;
            this.label1.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.label2.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelInvalid.ForeColor = Client.ActiveTheme.Colors.Text.Error;
            this.labelIPAddress.ForeColor = Client.ActiveTheme.Colors.Text.Default;

            this.textIPAddress.Text = Properties.Settings.Default.IPAddress;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Requester.BaseAPIAddr = textIPAddress.Text;

            if (textUsername.Text == "" && textPassword.Text == "")
                return;

            PingResponse ping = new Ping().PerformRequestAsync().Result;
            if (!ping.Success)
            {
                MessageBox.Show("Failed to connect to the server");
                return;
            }

            AccountLoginResponse response = new AccountLogin(textUsername.Text, textPassword.Text).PerformRequestAsync().Result;

            try
            {
                if (response.IsSuccess)
                {
                    Client.ActiveAccount = response.Account;
                    Requester.AccessToken = response.Account.AccessToken;
                    Properties.Settings.Default.IPAddress = this.textIPAddress.Text;
                    Properties.Settings.Default.Save();
                    this.Close();
                }
                else
                {
                    labelInvalid.Visible = true;
                }
            } catch { }
        }

        private void buttonAdvanced_Click(object sender, EventArgs e)
        {

        }
    }
}
