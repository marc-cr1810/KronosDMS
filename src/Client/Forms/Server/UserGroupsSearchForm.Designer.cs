
namespace KronosDMS_Client.Forms.Server
{
    partial class UserGroupsSearchForm
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
            this.labelMakeID = new System.Windows.Forms.Label();
            this.labelMakeName = new System.Windows.Forms.Label();
            this.textLevel = new System.Windows.Forms.TextBox();
            this.ListGroups = new System.Windows.Forms.ListView();
            this.columnName = new System.Windows.Forms.ColumnHeader();
            this.columnLevel = new System.Windows.Forms.ColumnHeader();
            this.textGroupName = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelMakeID
            // 
            this.labelMakeID.AutoSize = true;
            this.labelMakeID.Location = new System.Drawing.Point(12, 13);
            this.labelMakeID.Name = "labelMakeID";
            this.labelMakeID.Size = new System.Drawing.Size(75, 15);
            this.labelMakeID.TabIndex = 0;
            this.labelMakeID.Text = "Group Name";
            // 
            // labelMakeName
            // 
            this.labelMakeName.AutoSize = true;
            this.labelMakeName.Location = new System.Drawing.Point(12, 43);
            this.labelMakeName.Name = "labelMakeName";
            this.labelMakeName.Size = new System.Drawing.Size(34, 15);
            this.labelMakeName.TabIndex = 2;
            this.labelMakeName.Text = "Level";
            // 
            // textLevel
            // 
            this.textLevel.Location = new System.Drawing.Point(93, 40);
            this.textLevel.Name = "textLevel";
            this.textLevel.Size = new System.Drawing.Size(146, 23);
            this.textLevel.TabIndex = 3;
            // 
            // ListGroups
            // 
            this.ListGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListGroups.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnLevel});
            this.ListGroups.FullRowSelect = true;
            this.ListGroups.GridLines = true;
            this.ListGroups.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListGroups.HideSelection = false;
            this.ListGroups.Location = new System.Drawing.Point(12, 69);
            this.ListGroups.MultiSelect = false;
            this.ListGroups.Name = "ListGroups";
            this.ListGroups.Size = new System.Drawing.Size(418, 239);
            this.ListGroups.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.ListGroups.TabIndex = 7;
            this.ListGroups.UseCompatibleStateImageBehavior = false;
            this.ListGroups.View = System.Windows.Forms.View.Details;
            this.ListGroups.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListGroups_MouseDoubleClick);
            this.ListGroups.Resize += new System.EventHandler(this.ListGroups_Resize);
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 200;
            // 
            // columnLevel
            // 
            this.columnLevel.Text = "Level";
            // 
            // textGroupName
            // 
            this.textGroupName.Location = new System.Drawing.Point(93, 10);
            this.textGroupName.Name = "textGroupName";
            this.textGroupName.Size = new System.Drawing.Size(146, 23);
            this.textGroupName.TabIndex = 8;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(355, 40);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 9;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // UserGroupsSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 320);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textGroupName);
            this.Controls.Add(this.ListGroups);
            this.Controls.Add(this.textLevel);
            this.Controls.Add(this.labelMakeName);
            this.Controls.Add(this.labelMakeID);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(458, 278);
            this.Name = "UserGroupsSearchForm";
            this.Text = "User Groups Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMakeID;
        private System.Windows.Forms.Label labelMakeName;
        private System.Windows.Forms.TextBox textLevel;
        private System.Windows.Forms.ListView ListGroups;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnLevel;
        private System.Windows.Forms.TextBox textGroupName;
        private System.Windows.Forms.Button buttonSearch;
    }
}