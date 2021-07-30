using KronosDMS;
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

namespace KronosDMS_Client.Forms.Account
{
    public partial class ChangePassword : Window
    {
        public ChangePassword()
        {
            InitializeComponent();

            labelOldPassword.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            labelNewPassword.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            labelConfirmPassword.ForeColor = Client.ActiveTheme.Colors.Text.Default;
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (textNewPassword.Text == textConfirmPassword.Text)
            {
                Response response = new UserAccountsSetPassword(textOldPassword.Text, textNewPassword.Text).PerformRequestAsync().Result;
                if (!response.IsSuccess)
                {
                    MessageBox.Show($"Change password failed!\n{response.RawMessage}", "Failed");
                    return;
                }
                MessageBox.Show("Changed password successfully!", "Success");
                Client.ActiveAccount.PasswordHash = Utils.SHA256Hash(textNewPassword.Text);
            }
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
