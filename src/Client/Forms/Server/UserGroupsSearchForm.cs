using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KronosDMS_Client.Forms.Server
{
    public partial class UserGroupsSearchForm : FormWindow
    {
        private bool IsDialog;
        public string GroupName;
        public Group Result;

        public UserGroupsSearchForm(string id = "", bool dialog = true)
        {
            InitializeComponent();

            ListGroups.Columns[1].Width = ListGroups.Width - ListGroups.Columns[0].Width - 5;

            this.labelMakeID.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelMakeName.ForeColor = Client.ActiveTheme.Colors.Text.Default;

            this.textGroupName.Text = id;

            if (id != "")
                Search();

            this.IsDialog = dialog;
        }

        private void Search()
        {
            UserGroupsSearchResponse response = new UserGroupsSearch(this.textGroupName.Text).PerformRequestAsync().Result;

            if (!response.IsSuccess)
            {
                MessageBox.Show($"Failed to search for groups.\n{response.RawMessage}", "Failed");
                return;
            }

            ListGroups.Items.Clear();

            foreach (KeyValuePair<string, Group> group in response.Groups)
            {
                ListViewItem partItem = ListGroups.Items.Add(group.Key);
                partItem.Name = group.Key;
                partItem.SubItems.Add(group.Value.Level.ToString());
            };

            ListGroups.Columns[1].Width = ListGroups.Width - ListGroups.Columns[0].Width - 5;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void ListGroups_Resize(object sender, EventArgs e)
        {
            if (ListGroups.Columns.Count > 0)
            {
                ListGroups.Columns[1].Width = ListGroups.Width - ListGroups.Columns[0].Width - 5;
            }
        }

        private void ListGroups_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string id = ListGroups.SelectedItems[0].Name;

            UserGroupsSearchResponse response = new UserGroupsSearch(id).PerformRequestAsync().Result;
            GroupName = ListGroups.SelectedItems[0].Text;
            Result = response.Groups[id];
            if (!IsDialog)
                Client.MainFormWindow.OpenForm(new UserGroupsForm(GroupName, Result));
            Client.MainFormWindow.CloseForm(this);
        }
    }
}
