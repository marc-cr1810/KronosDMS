
namespace KronosDMS_Client.Forms.Server
{
    partial class UserGroupsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelGroup = new System.Windows.Forms.Label();
            this.textGroupName = new System.Windows.Forms.TextBox();
            this.groupDetails = new System.Windows.Forms.GroupBox();
            this.textLevel = new System.Windows.Forms.TextBox();
            this.labelLevel = new System.Windows.Forms.Label();
            this.ListPermissions = new System.Windows.Forms.ListView();
            this.columnPermission = new System.Windows.Forms.ColumnHeader();
            this.textPermission = new System.Windows.Forms.TextBox();
            this.buttonAddPermission = new System.Windows.Forms.Button();
            this.buttonGroupSearch = new System.Windows.Forms.Button();
            this.Tools = new System.Windows.Forms.ToolStrip();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.PermissionsListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PermissionDeleteButton = new System.Windows.Forms.ToolStripMenuItem();
            this.groupDetails.SuspendLayout();
            this.Tools.SuspendLayout();
            this.PermissionsListMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelGroup
            // 
            this.labelGroup.AutoSize = true;
            this.labelGroup.Location = new System.Drawing.Point(12, 31);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(40, 15);
            this.labelGroup.TabIndex = 0;
            this.labelGroup.Text = "Group";
            // 
            // textGroupName
            // 
            this.textGroupName.Location = new System.Drawing.Point(58, 28);
            this.textGroupName.Name = "textGroupName";
            this.textGroupName.Size = new System.Drawing.Size(175, 23);
            this.textGroupName.TabIndex = 1;
            this.textGroupName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textGroupNameSearch);
            this.textGroupName.Leave += new System.EventHandler(this.textGroupName_Leave);
            // 
            // groupDetails
            // 
            this.groupDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupDetails.Controls.Add(this.textLevel);
            this.groupDetails.Controls.Add(this.labelLevel);
            this.groupDetails.Location = new System.Drawing.Point(12, 57);
            this.groupDetails.Name = "groupDetails";
            this.groupDetails.Size = new System.Drawing.Size(416, 58);
            this.groupDetails.TabIndex = 2;
            this.groupDetails.TabStop = false;
            this.groupDetails.Text = "Details";
            // 
            // textLevel
            // 
            this.textLevel.Enabled = false;
            this.textLevel.Location = new System.Drawing.Point(46, 22);
            this.textLevel.Name = "textLevel";
            this.textLevel.Size = new System.Drawing.Size(71, 23);
            this.textLevel.TabIndex = 1;
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Location = new System.Drawing.Point(6, 25);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(34, 15);
            this.labelLevel.TabIndex = 0;
            this.labelLevel.Text = "Level";
            // 
            // ListPermissions
            // 
            this.ListPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListPermissions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListPermissions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnPermission});
            this.ListPermissions.ContextMenuStrip = this.PermissionsListMenu;
            this.ListPermissions.FullRowSelect = true;
            this.ListPermissions.GridLines = true;
            this.ListPermissions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListPermissions.HideSelection = false;
            this.ListPermissions.Location = new System.Drawing.Point(12, 121);
            this.ListPermissions.MultiSelect = false;
            this.ListPermissions.Name = "ListPermissions";
            this.ListPermissions.Size = new System.Drawing.Size(416, 189);
            this.ListPermissions.TabIndex = 35;
            this.ListPermissions.UseCompatibleStateImageBehavior = false;
            this.ListPermissions.View = System.Windows.Forms.View.Details;
            // 
            // columnPermission
            // 
            this.columnPermission.Text = "Permission";
            this.columnPermission.Width = 300;
            // 
            // textPermission
            // 
            this.textPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textPermission.Enabled = false;
            this.textPermission.Location = new System.Drawing.Point(12, 316);
            this.textPermission.Name = "textPermission";
            this.textPermission.Size = new System.Drawing.Size(179, 23);
            this.textPermission.TabIndex = 36;
            // 
            // buttonAddPermission
            // 
            this.buttonAddPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddPermission.Enabled = false;
            this.buttonAddPermission.Location = new System.Drawing.Point(198, 317);
            this.buttonAddPermission.Name = "buttonAddPermission";
            this.buttonAddPermission.Size = new System.Drawing.Size(75, 23);
            this.buttonAddPermission.TabIndex = 37;
            this.buttonAddPermission.Text = "Add";
            this.buttonAddPermission.UseVisualStyleBackColor = true;
            this.buttonAddPermission.Click += new System.EventHandler(this.buttonAddPermission_Click);
            // 
            // buttonGroupSearch
            // 
            this.buttonGroupSearch.Location = new System.Drawing.Point(232, 28);
            this.buttonGroupSearch.Name = "buttonGroupSearch";
            this.buttonGroupSearch.Size = new System.Drawing.Size(26, 23);
            this.buttonGroupSearch.TabIndex = 38;
            this.buttonGroupSearch.Text = "S";
            this.buttonGroupSearch.UseVisualStyleBackColor = true;
            this.buttonGroupSearch.Click += new System.EventHandler(this.buttonGroupSearch_Click);
            // 
            // Tools
            // 
            this.Tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripButton,
            this.toolStripSeparator1,
            this.refreshToolStripButton,
            this.deleteToolStripButton});
            this.Tools.Location = new System.Drawing.Point(0, 0);
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(440, 25);
            this.Tools.TabIndex = 39;
            this.Tools.Text = "toolStrip1";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = global::KronosDMS_Client.Properties.Resources.floppy_icon;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolStripButton.Image = global::KronosDMS_Client.Properties.Resources.refresh_icon;
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.refreshToolStripButton.Text = "toolStripButton1";
            this.refreshToolStripButton.ToolTipText = "Refresh";
            this.refreshToolStripButton.Click += new System.EventHandler(this.refreshToolStripButton_Click);
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteToolStripButton.Image = global::KronosDMS_Client.Properties.Resources.delete_file_icon;
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.deleteToolStripButton.Text = "toolStripButton2";
            this.deleteToolStripButton.ToolTipText = "Delete";
            this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
            // 
            // PermissionsListMenu
            // 
            this.PermissionsListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PermissionDeleteButton});
            this.PermissionsListMenu.Name = "PermissionsListMenu";
            this.PermissionsListMenu.Size = new System.Drawing.Size(181, 48);
            // 
            // PermissionDeleteButton
            // 
            this.PermissionDeleteButton.Name = "PermissionDeleteButton";
            this.PermissionDeleteButton.Size = new System.Drawing.Size(180, 22);
            this.PermissionDeleteButton.Text = "Delete";
            this.PermissionDeleteButton.DropDownOpening += new System.EventHandler(this.PermissionDeleteButton_DropDownOpening);
            this.PermissionDeleteButton.Click += new System.EventHandler(this.PermissionDeleteButton_Click);
            // 
            // UserGroupsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 351);
            this.Controls.Add(this.Tools);
            this.Controls.Add(this.buttonGroupSearch);
            this.Controls.Add(this.buttonAddPermission);
            this.Controls.Add(this.textPermission);
            this.Controls.Add(this.ListPermissions);
            this.Controls.Add(this.groupDetails);
            this.Controls.Add(this.textGroupName);
            this.Controls.Add(this.labelGroup);
            this.MinimumSize = new System.Drawing.Size(456, 390);
            this.Name = "UserGroupsForm";
            this.Text = "User Group";
            this.groupDetails.ResumeLayout(false);
            this.groupDetails.PerformLayout();
            this.Tools.ResumeLayout(false);
            this.Tools.PerformLayout();
            this.PermissionsListMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.TextBox textGroupName;
        private System.Windows.Forms.GroupBox groupDetails;
        private System.Windows.Forms.TextBox textLevel;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.ListView ListPermissions;
        private System.Windows.Forms.ColumnHeader columnPermission;
        private System.Windows.Forms.TextBox textPermission;
        private System.Windows.Forms.Button buttonAddPermission;
        private System.Windows.Forms.Button buttonGroupSearch;
        private System.Windows.Forms.ToolStrip Tools;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.ToolStripButton deleteToolStripButton;
        private System.Windows.Forms.ContextMenuStrip PermissionsListMenu;
        private System.Windows.Forms.ToolStripMenuItem PermissionDeleteButton;
    }
}