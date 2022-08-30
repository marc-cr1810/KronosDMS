using KronosDMS.Api.Endpoints;
using KronosDMS.Api.Responses;
using KronosDMS.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KronosDMS_Client.Forms.Server
{
    public partial class UserGroupsForm : FormWindow
    {
        private bool NewGroup = false;
        private string GroupName = null;
        public Group SelectedGroup = new Group();

        public UserGroupsForm(string name = "", Group group = new Group())
        {
            InitializeComponent();

            this.labelGroup.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.labelLevel.ForeColor = Client.ActiveTheme.Colors.Text.Default;
            this.groupDetails.ForeColor = Client.ActiveTheme.Colors.Text.Default;

            this.Tools.BackColor = Client.ActiveTheme.Colors.Foreground;

            if (name is not null && group.Permissions is not null)
                FillDetails(name, group);
        }

        private void FillDetails(string name, Group group)
        {
            GroupName = name;
            SelectedGroup = group;

            if (this.NewGroup != true)
                this.Text = $"User Group | {name} - Editing";

            foreach (string permission in SelectedGroup.Permissions)
                ListPermissions.Items.Add(permission);

            textGroupName.Text = name;
            textLevel.Text = group.Level.ToString();

            textGroupName.Enabled = false;
            textLevel.Enabled = true;
            textPermission.Enabled = true;
            buttonAddPermission.Enabled = true;
            buttonGroupSearch.Enabled = false;
        }

        private void ClearDetails()
        {
            GroupName = null;
            SelectedGroup = new Group();

            this.Text = $"User Group";

            ListPermissions.Items.Clear();

            textGroupName.Text = "";
            textLevel.Text = "";

            textGroupName.Enabled = true;
            textLevel.Enabled = false;
            textPermission.Enabled = false;
            buttonAddPermission.Enabled = false;
            buttonGroupSearch.Enabled = true;
        }

        private void SearchGroup()
        {
            if (this.textGroupName.Text == "" || this.textGroupName.Text == GroupName)
                return;
            UserGroupsSearchResponse response = new UserGroupsSearch(this.textGroupName.Text.ToUpper()).PerformRequestAsync().Result;
            if (response.Groups.Count != 1)
            {
                if (MessageBox.Show($"Create new user group \"{this.textGroupName.Text}\"?", "Create new user group?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    FillDetails(this.textGroupName.Text, SelectedGroup);
                    this.Text = $"User Group | {this.textGroupName.Text} - Creating new user group";
                    this.NewGroup = true;
                    return;
                }
                else
                {
                    UserGroupsSearchForm form = new UserGroupsSearchForm(this.textGroupName.Text);
                    Client.MainFormWindow.OpenFormDialog(form);
                    FillDetails(form.GroupName, form.Result);
                    form.Dispose();
                }
            }
            else FillDetails(response.Groups.ElementAt(0).Key, response.Groups.ElementAt(0).Value);
        }

        private KeyValuePair<string, Group> SearchForGroup(string id)
        {
            UserGroupsSearchForm form = new UserGroupsSearchForm(this.textGroupName.Text);
            Client.MainFormWindow.OpenFormDialog(form);
            KeyValuePair<string, Group> g = new KeyValuePair<string, Group>(form.GroupName, form.Result);
            form.Dispose();
            return g;
        }

        public override void Save()
        {
            if (GroupName is null)
                return;

            Response response;
            if (NewGroup)
            {
                response = new UserGroupAdd(GroupName, SelectedGroup).PerformRequestAsync().Result;
                if (!response.IsSuccess)
                {
                    MessageBox.Show($"Failed to add user group.\n{response.RawMessage}");
                    return;
                }
            }
            else
            {
                response = new UserGroupSet(GroupName, SelectedGroup).PerformRequestAsync().Result;
                if (!response.IsSuccess)
                {
                    MessageBox.Show($"Failed to save user group.\n{response.RawMessage}");
                    return;
                }
            }
            ClearDetails();
        }

        public override void Delete()
        {
            if (GroupName is null)
                return;

            if (MessageBox.Show($"Delete user group \"{GroupName}\"?", "Delete user group?", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            Response response = new UserGroupRemove(GroupName).PerformRequestAsync().Result;
            if (!response.IsSuccess)
            {
                MessageBox.Show($"Failed to delete user group.\n{response.RawMessage}");
                return;
            }
            ClearDetails();
        }

        private void textGroupNameSearch(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textGroupName.Text != GroupName)
                    SearchGroup();
            }
        }

        private void buttonGroupSearch_Click(object sender, EventArgs e)
        {
            if (textGroupName.Text != GroupName)
            {
                KeyValuePair<string, Group> group = SearchForGroup(textGroupName.Text);
                FillDetails(group.Key, group.Value);
            }
        }

        private void textGroupName_Leave(object sender, EventArgs e)
        {
            if (textGroupName.Text != GroupName && textGroupName.Text != "")
                SearchForGroup(textGroupName.Text);
        }

        private void buttonAddPermission_Click(object sender, EventArgs e)
        {
            if (textPermission.Text == "")
                return;

            ListPermissions.Items.Add(textPermission.Text);
            SelectedGroup.Permissions.Add(textPermission.Text);
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            if (GroupName is null)
                return;
            ClearDetails();
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void PermissionDeleteButton_DropDownOpening(object sender, EventArgs e)
        {
            if (ListPermissions.SelectedItems.Count == 0)
            {
                PermissionDeleteButton.Enabled = false;
                return;
            }
            PermissionDeleteButton.Enabled = true;
        }

        private void PermissionDeleteButton_Click(object sender, EventArgs e)
        {
            if (ListPermissions.SelectedItems.Count != 1)
                return;


            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete permission " + ListPermissions.SelectedItems[0].SubItems[0].Text + " from this group?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int index = ListPermissions.Items.IndexOf(ListPermissions.SelectedItems[0]);

                ListPermissions.Items.RemoveAt(index);
                SelectedGroup.Permissions.RemoveAt(index);
            }
        }
    }
}
